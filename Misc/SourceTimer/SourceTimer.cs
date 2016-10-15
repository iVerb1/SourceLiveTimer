using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using SourceLiveTimer.Demo;

namespace SourceLiveTimer
{
    public partial class SourceTimer : Form
    {
        private List<DemoParseResult> _demoResults;        

        public SourceTimer()
        {
            this.InitializeComponent();
            this._demoResults = new List<DemoParseResult>();
            this.listView.ListViewItemSorter = new SortByDemoName();
        }    

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Multiselect = true,
                Title = "Please select ALL the demos you wish to analyze",
                Filter = "Portal Demo Files (*.dem)|*.dem"
            };
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.listView.Items.Clear();
                this.ParseRun(openFileDialog.FileNames);
            }
        }

        private void ParseRun(string[] demos)
        {
            DemoParseResult demoParseResult;
            this.listView.Items.Clear();
            this._demoResults.Clear();
            int num = 0;
            bool gameDir = false;
            ListViewItem listViewItem = new ListViewItem();
            System.Drawing.Font font = new System.Drawing.Font(listViewItem.Font.FontFamily, listViewItem.Font.Size, FontStyle.Bold);
            string[] strArrays = demos;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str = strArrays[i];
                try
                {
                    demoParseResult = DemoParser.ParseDemo(str);
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    MessageBox.Show(string.Concat("Couldn't parse demo: ", Path.GetFileName(str), " - ", exception.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                }
                this._demoResults.Add(demoParseResult);
                gameDir = demoParseResult.GameDir == "portal2";
                int totalTicks = demoParseResult.TotalTicks;
                ListViewItem fileName = new ListViewItem(new string[this.listView.Columns.Count])
                {
                    UseItemStyleForSubItems = false
                };
                fileName.SubItems[0].Text = Path.GetFileName(str);
                fileName.SubItems[1].Text = string.Concat(demoParseResult.GameDir, " / ", demoParseResult.MapName);
                fileName.SubItems[2].Text = demoParseResult.PlayerName;
                fileName.SubItems[3].Text = demoParseResult.TotalTicks.ToString();
                if (demoParseResult.StartAdjustmentTick <= -1 || demoParseResult.EndAdjustmentTick <= -1)
                {
                    if (demoParseResult.StartAdjustmentTick <= -1)
                    {
                        fileName.SubItems[4].Text = "0";
                    }
                    else
                    {
                        totalTicks = demoParseResult.TotalTicks - demoParseResult.StartAdjustmentTick;
                        fileName.SubItems[4].Text = demoParseResult.StartAdjustmentTick.ToString();
                        if (!gameDir)
                        {
                            fileName.SubItems[4].Font = font;
                        }
                    }
                    if (demoParseResult.EndAdjustmentTick <= -1)
                    {
                        fileName.SubItems[5].Text = demoParseResult.TotalTicks.ToString();
                    }
                    else
                    {
                        totalTicks = demoParseResult.EndAdjustmentTick;
                        fileName.SubItems[5].Text = demoParseResult.EndAdjustmentTick.ToString();
                        if (!gameDir)
                        {
                            fileName.SubItems[5].Font = font;
                        }
                    }
                }
                else
                {
                    totalTicks = demoParseResult.EndAdjustmentTick - demoParseResult.StartAdjustmentTick;
                    fileName.SubItems[4].Text = demoParseResult.StartAdjustmentTick.ToString();
                    fileName.SubItems[5].Text = demoParseResult.EndAdjustmentTick.ToString();
                }
                if (demoParseResult.StartAdjustmentType != null)
                {
                    ListViewItem.ListViewSubItem item = fileName.SubItems[4];
                    item.Text = string.Concat(item.Text, " (", demoParseResult.StartAdjustmentType, ")");
                }
                if (demoParseResult.EndAdjustmentType != null)
                {
                    ListViewItem.ListViewSubItem listViewSubItem = fileName.SubItems[5];
                    listViewSubItem.Text = string.Concat(listViewSubItem.Text, " (", demoParseResult.EndAdjustmentType, ")");
                }
                fileName.SubItems[6].Text = totalTicks.ToString();
                if (!gameDir && totalTicks != demoParseResult.TotalTicks)
                {
                    fileName.SubItems[6].Font = font;
                }
                num = num + totalTicks;
                string str1 = string.Format("{0:hh\\:mm\\:ss\\.fff}", TimeSpan.FromSeconds(this.TicksToSecs(totalTicks, gameDir)));
                fileName.SubItems[7].Text = str1;
                this.listView.Items.Add(fileName);
            }
            ListViewItem listViewItem1 = new ListViewItem(new string[this.listView.Columns.Count])
            {
                Font = font
            };
            listViewItem1.SubItems[0].Text = "-- TOTAL --";
            listViewItem1.SubItems[6].Text = num.ToString();
            string str2 = string.Format("{0:hh\\:mm\\:ss\\.fff}", TimeSpan.FromSeconds(this.TicksToSecs(num, gameDir)));
            listViewItem1.SubItems[7].Text = str2;
            this.listView.Items.Add(listViewItem1);
            this.listView.Sort();
            this.listView.EnsureVisible(listViewItem1.Index);
        }

        private double TicksToSecs(int ticks, bool portal2)
        {
            if (portal2)
            {
                return (double)ticks / 60;
            }
            return (double)ticks / 66.6666666666667;
        }

        private void validateRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._demoResults.Count == 0)
            {
                return;
            }
            string gameDir = this._demoResults[0].GameDir;
            foreach (DemoParseResult _demoResult in this._demoResults)
            {
                if (_demoResult.GameDir == gameDir)
                {
                    continue;
                }
                MessageBox.Show("Demos must all be from the same game", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
        }

        private void wikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://cronikeys.com/portal/");
        }

        private enum ListViewColumns
        {
            File,
            Map,
            Player,
            TotalTicks,
            StartTick,
            StopTick,
            AdjustedTicks,
            Time
        }
    }
}