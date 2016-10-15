using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using SourceLiveTimer.Speedrun;
using SourceLiveTimer.Demo;

namespace SourceLiveTimer.View
{
    public partial class MainForm : Form
    {
        private bool Dragging;
        private Point Offset;
        private CompoundRunViewComponent RunView;

        private Run _Run = null;
        private string _SplitsFile = null;
        private string _DemoDirectory = null;
        private bool _Saved = false;

        private Run Run
        {
            get
            {
                return _Run;
            }
            set
            {
                _Run = value;
                UpdateContextMenu();
            }
        }
        private string SplitsFile
        {
            get
            {
                return _SplitsFile;
            }
            set
            {
                _SplitsFile = value;
                UpdateContextMenu();
            }
        }
        private string DemoDirectory
        {
            get
            {
                return _DemoDirectory;
            }
            set
            {
                _DemoDirectory = value;
                UpdateContextMenu();
            }
        }
        private bool Saved
        {
            get
            {
                return _Saved;
            }
            set
            {
                bool oldSaved = _Saved;
                _Saved = value;
                if (oldSaved != _Saved)
                    UpdateContextMenu();
            }
        }

        private const int DIRECTORY_SCANNER_REFRESH_RATE = 500;


        public MainForm()
        {
            InitializeComponent();

            RunView = new CompoundRunViewComponent();
            RunView.Add(splitsUI);
            RunView.Add(separatorUI);
            RunView.Add(possibleTimeSaveUI);
            RunView.Add(comparisonBestUI);
            RunView.Add(sumOfBestUI);
            RunView.Add(currentDemoUI);
            RunView.Add(runNameUI);

            LoadCategories();
            LoadSettings();
        }

        private void LoadCategories()
        {
            for (int i = 0; i < Category.Values.Count(); i++)
            {
                Category category = Category.Values.ElementAt(i);
                ToolStripMenuItem categoryMenuItem = new ToolStripMenuItem();
                categoryMenuItem.Size = new System.Drawing.Size(157, 22);
                categoryMenuItem.Text = category.Name;
                categoryMenuItem.Click += (o, e) =>
                {
                    if (CheckForUnsavedChanges())
                    {
                        Run run = new Run(category);
                        LoadRun(run);
                    }
                };
                this.openSplitsToolStripMenuItem.DropDownItems.Add(categoryMenuItem);
            }
        }

        private void LoadSettings()
        {

            if (!String.IsNullOrEmpty((string)Properties.Settings.Default["DemoDirectory"]))
            {
                DemoDirectory = (string)Properties.Settings.Default["DemoDirectory"];
                directoryScannerWorker.RunWorkerAsync(DemoDirectory);
            }
            
            if (!String.IsNullOrEmpty((string)Properties.Settings.Default["SplitsFile"]))
            {
                OpenSplitsFile((string)Properties.Settings.Default["SplitsFile"]);
            }             
        }

        private void UpdateContextMenu()
        {
            bool runIsNull = Run == null;
            bool demoDirectoryIsNull = DemoDirectory == null;
            bool splitsFileIsNull = SplitsFile == null;
            bool runHasUnsavedChanges = !runIsNull ? (RunHasUnsavedChanges() ? true : false) : false;

            demoDirectoryToolStripMenuItem.Checked = !demoDirectoryIsNull ? true : false;
            demoDirectoryToolStripMenuItem.ToolTipText = !demoDirectoryIsNull ? DemoDirectory : "";
            editSplitsToolStripMenuItem.Enabled = !runIsNull ? Run.AtFirstSplit() : false;
            saveSplitsAsToolStripMenuItem.Enabled = !runIsNull ? true : false;
            saveSplitsToolStripMenuItem.ToolTipText = (!splitsFileIsNull) ? SplitsFile : null;
            saveSplitsToolStripMenuItem.Enabled = (!splitsFileIsNull && runHasUnsavedChanges) ? true : false;
            closeSplitsToolStripMenuItem.Enabled = !runIsNull ? true : false;
            resetToolStripMenuItem.Enabled = !runIsNull ? !Run.AtFirstSplit() : false;
        }

        private void DemoDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openDirectoryDialog = new FolderBrowserDialog()
            {
                Description = "Please select the demo directory to monitor"
            };

            if (openDirectoryDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DemoDirectory = openDirectoryDialog.SelectedPath;
                Properties.Settings.Default["DemoDirectory"] = DemoDirectory;
                Properties.Settings.Default.Save();

                if (directoryScannerWorker.IsBusy)
                    directoryScannerWorker.CancelAsync();
                else
                    directoryScannerWorker.RunWorkerAsync(DemoDirectory);
            }
        }

        private void DirectoryScannerWorker_SwitchDirectory(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            directoryScannerWorker.RunWorkerAsync(DemoDirectory);
        }

        private void DirectoryScannerWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            DateTime startTime = DateTime.Now;

            while (!worker.CancellationPending)
            {
                IEnumerable<string> allDemos = Directory.GetFiles((string)e.Argument, "*.dem");
                
                foreach (string demo in allDemos)
                {                    
                    DateTime writeTime = File.GetLastWriteTime(demo);                    
                    if (writeTime.CompareTo(startTime) > 0)
                    {
                        worker.ReportProgress(0, Path.GetFileName(demo));
                        MonitorDemo(worker, demo);
                        worker.ReportProgress(0, null);
                        startTime = DateTime.Now;
                        break;
                    }
                    Thread.Sleep(1);
                }
            }
        }

        private void MonitorDemo(BackgroundWorker worker, string demo)
        {
            Thread.Sleep(DIRECTORY_SCANNER_REFRESH_RATE);
            while (!worker.CancellationPending)
            {
                try
                {
                    DemoParseResult demoParseResult = DemoParser.ParseDemo(demo);
                    worker.ReportProgress(0, demoParseResult);
                    return;
                }
                catch
                {
                    //demo still being written to
                }
                Thread.Sleep(DIRECTORY_SCANNER_REFRESH_RATE);
            }
        }

        private void DirectoryScannerWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Run != null)
            {
                if (e.UserState == null)
                {
                    Run.CurrentDemo = null;
                }
                else if (e.UserState is string)
                {
                    string demo = ((string)e.UserState);
                    Run.CurrentDemo = demo;
                }
                else if (e.UserState is DemoParseResult)
                {
                    DemoParseResult demoParseResult = ((DemoParseResult)e.UserState);
                    Run.Update(demoParseResult);
                }
                RunView.UpdateComponent();
            }
        }

        private void OpenSplitsFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckForUnsavedChanges())
            {
                OpenFileDialog openSplitsDialog = new OpenFileDialog()
                {
                    Multiselect = false,
                    Title = "Please select the splits you want to open",
                    Filter = "Text files (*.txt)|*.txt"
                };

                if (openSplitsDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (OpenSplitsFile(openSplitsDialog.FileName))
                    {
                        Properties.Settings.Default["SplitsFile"] = SplitsFile;
                        Properties.Settings.Default.Save();
                    }
                }
            }
        }

        private void OpenSplitsFromDemosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckForUnsavedChanges())
            {
                OpenFileDialog openDemosDialog = new OpenFileDialog()
                {
                    Multiselect = true,
                    Title = "Please select all the demos of your run",
                    Filter = "Demo files (*.dem)|*.dem"
                };

                if (openDemosDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    List<FileInfo> demos = openDemosDialog.FileNames.Select(f => new FileInfo(f)).ToList();
                    List<FileInfo> orderedDemos = demos.OrderBy(f => f.LastWriteTime).ToList();
                    List<DemoParseResult> orderedDemoResults = orderedDemos.Select(f => DemoParser.ParseDemo(f.FullName)).ToList();

                    foreach (Category category in Category.Values)
                    {
                        string[] demoMaps = orderedDemoResults.Select(r => r.MapName).ToArray();
                        if (category.Maps.All(m => demoMaps.Contains(m)))
                        {
                            Run run = new Run(category, orderedDemoResults);
                            LoadRun(run);
                            return;
                        }
                    }
                    MessageBox.Show("An error occured while trying to create splits from the selected demos. Did you forget any?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool OpenSplitsFile(string splitsFile)
        {
            try
            {
                string json = System.IO.File.ReadAllText(splitsFile);
                JToken jToken = JToken.Parse(json);
                string categoryName = jToken.SelectToken("Category").ToString();
                string runName = jToken.SelectToken("RunName").ToString();
                List<Split> splits = JsonConvert.DeserializeObject<List<Split>>(jToken.SelectToken("Splits").ToString());
                Category category = Category.FromName(categoryName);

                Run run = new Run(category, runName, splits);
                LoadRun(run);

                Saved = true;
                SplitsFile = splitsFile;
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured while trying to open the splits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void EditSplitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Run != null)
            {
                TopMost = false;
                Run runClone = (Run)Run.Clone();
                runClone.OnSplitUpdate += (o, ev) => { Saved = false; };
                runClone.OnNameUpdate += (o, ev) => { Saved = false; };
                EditSplitsForm editSplitsForm = new EditSplitsForm(runClone);
                if (editSplitsForm.ShowDialog() == DialogResult.OK)
                {
                    Run.Clear();
                    Run.AddRange(editSplitsForm.Run);
                    Run.Name = editSplitsForm.Run.Name;
                    RunView.UpdateComponent();
                }
                TopMost = true;
            }
        }

        private void SaveSplitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SplitsFile != null)
            {
                SaveSplits();
            }
        }

        private void SaveSplitsAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Run != null)
            {
                ShowSaveAsDialog();
            }
        }

        private bool ShowSaveAsDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Save splits as",
                Filter = "Source Live Split Files (*.txt)|*.txt"
            };
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SplitsFile = saveFileDialog.FileName;
                if (SaveSplits())
                {
                    Properties.Settings.Default["SplitsFile"] = SplitsFile;
                    Properties.Settings.Default.Save();
                    return true;
                }
            }
            return false;
        }

        private bool SaveSplits()
        {
            Run.UpdateBests(true);

            if (Run.IsPersonalBest())
                Run.Reset(true);            

            try
            {
                string json = JsonConvert.SerializeObject(Run, Formatting.Indented);
                StreamWriter splitsFileWriter = File.CreateText(SplitsFile);
                splitsFileWriter.Write(json);
                splitsFileWriter.Close();
                Saved = true;
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured while trying to save the splits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }            
        }

        private void CloseSplitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Run != null)
            {
                if (CheckForUnsavedChanges())
                {
                    UnloadRun();                    
                }
            }
        }
        
        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Run != null && !Run.AtFirstSplit())
            {
                bool lastSplitAccurate = false;
                if (Run.IsPersonalBest() || Run.ContainsBests())
                {
                    DialogResult dialogResult = MessageBox.Show("Is the last split accurate?", "Reset", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                        lastSplitAccurate = true;
                    else if (dialogResult == DialogResult.No)
                        lastSplitAccurate = false;
                    else if (dialogResult == DialogResult.Cancel)
                        return;
                }

                Run.Reset(lastSplitAccurate);
                RunView.UpdateComponent();
            }
        }
        
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckForUnsavedChanges())
                Close();
        }

        private bool CheckForUnsavedChanges()
        {
            if (Run != null)
            {
                if (RunHasUnsavedChanges())
                {
                    DialogResult result = MessageBox.Show("Save splits before closing?", "Closing splits...", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (SplitsFile != null)
                        {
                            SaveSplits();
                            return true;
                        }
                        else
                            return ShowSaveAsDialog();
                    }
                    else if (result == DialogResult.Cancel)
                        return false;
                }
            }            
            return true;
        }

        private void LoadRun(Run run)
        {
            if (Run != null)
                UnloadRun();

            Run = run;

            Run.OnSplitUpdate += (o, e) => { Saved = false; };
            Run.OnBest += (o, e) => { UpdateContextMenu(); };
            Run.OnPersonalBest += (o, e) => { UpdateContextMenu(); };
            Run.OnSplit += (o, e) => { UpdateContextMenu(); };
            Run.OnResplit += (o, e) => { UpdateContextMenu(); };
            Run.OnReset += (o, e) => { UpdateContextMenu(); };

            RunView.LoadRun(run);
            
            foreach (Control c in tableLayoutPanel.Controls)
            {
                EnableDragging(c);
            }
        }

        private void UnloadRun()
        {
            Run = null;
            SplitsFile = null;
            Saved = false;
            RunView.UnloadRun();            
        }

        private bool RunHasUnsavedChanges()
        {
            return !Run.AtFirstSplit()
                ? !Saved || Run.IsPersonalBest() || Run.ContainsBests()
                : !Saved || Run.IsPersonalBest();            
        }

        private void EnableDragging(Control c)
        {
            c.MouseDown += this.Borderless_MouseDown;
            c.MouseUp += this.Borderless_MouseUp;
            c.MouseMove += this.Borderless_MouseMove;
            foreach (Control childControl in c.Controls)
            {
                EnableDragging(childControl);
            }
        }

        public void Borderless_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - Offset.X, currentScreenPos.Y - Offset.Y);
            }
        }

        public void Borderless_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Offset.X = e.X;
                Offset.Y = e.Y;
                Dragging = true;
            }
        }

        public void Borderless_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Drawing.Rectangle bounds = this.WindowState != FormWindowState.Normal ? this.RestoreBounds : this.DesktopBounds;
            Properties.Settings.Default.ScreenPos = bounds.Location;
            Properties.Settings.Default.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.DesktopLocation = Properties.Settings.Default.ScreenPos;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

    }
}
