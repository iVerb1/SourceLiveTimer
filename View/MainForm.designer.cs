namespace SourceLiveTimer.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.demoDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editSplitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSplitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSplitsFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromDemosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveSplitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSplitsAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeSplitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryScannerWorker = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.splitsUI = new SourceLiveTimer.View.SplitsUI();
            this.separatorUI = new SourceLiveTimer.View.SeparatorUI();
            this.possibleTimeSaveUI = new SourceLiveTimer.View.PossibleTimeSaveUI();
            this.comparisonBestUI = new SourceLiveTimer.View.ComparisonBestUI();
            this.sumOfBestUI = new SourceLiveTimer.View.SumOfBestUI();
            this.currentDemoUI = new SourceLiveTimer.View.CurrentDemoUI();
            this.runNameUI = new SourceLiveTimer.View.RunNameUI();
            this.contextMenuStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.demoDirectoryToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editSplitsToolStripMenuItem,
            this.openSplitsToolStripMenuItem,
            this.saveSplitsToolStripMenuItem,
            this.saveSplitsAsToolStripMenuItem,
            this.closeSplitsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.quitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(158, 192);
            // 
            // demoDirectoryToolStripMenuItem
            // 
            this.demoDirectoryToolStripMenuItem.Name = "demoDirectoryToolStripMenuItem";
            this.demoDirectoryToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.demoDirectoryToolStripMenuItem.Text = "Demo Directory";
            this.demoDirectoryToolStripMenuItem.Click += new System.EventHandler(this.DemoDirectoryToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Enabled = false;
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.ResetToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 6);
            // 
            // editSplitsToolStripMenuItem
            // 
            this.editSplitsToolStripMenuItem.Enabled = false;
            this.editSplitsToolStripMenuItem.Name = "editSplitsToolStripMenuItem";
            this.editSplitsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.editSplitsToolStripMenuItem.Text = "Edit Splits";
            this.editSplitsToolStripMenuItem.Click += new System.EventHandler(this.EditSplitsToolStripMenuItem_Click);
            // 
            // openSplitsToolStripMenuItem
            // 
            this.openSplitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSplitsFromFileToolStripMenuItem,
            this.fromDemosToolStripMenuItem,
            this.toolStripMenuItem3});
            this.openSplitsToolStripMenuItem.Name = "openSplitsToolStripMenuItem";
            this.openSplitsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.openSplitsToolStripMenuItem.Text = "Open Splits";
            // 
            // openSplitsFromFileToolStripMenuItem
            // 
            this.openSplitsFromFileToolStripMenuItem.Name = "openSplitsFromFileToolStripMenuItem";
            this.openSplitsFromFileToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.openSplitsFromFileToolStripMenuItem.Text = "From File";
            this.openSplitsFromFileToolStripMenuItem.Click += new System.EventHandler(this.OpenSplitsFromFileToolStripMenuItem_Click);
            // 
            // fromDemosToolStripMenuItem
            // 
            this.fromDemosToolStripMenuItem.Name = "fromDemosToolStripMenuItem";
            this.fromDemosToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.fromDemosToolStripMenuItem.Text = "From Demos";
            this.fromDemosToolStripMenuItem.Click += new System.EventHandler(this.OpenSplitsFromDemosToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(139, 6);
            // 
            // saveSplitsToolStripMenuItem
            // 
            this.saveSplitsToolStripMenuItem.Enabled = false;
            this.saveSplitsToolStripMenuItem.Name = "saveSplitsToolStripMenuItem";
            this.saveSplitsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveSplitsToolStripMenuItem.Text = "Save Splits";
            this.saveSplitsToolStripMenuItem.Click += new System.EventHandler(this.SaveSplitsToolStripMenuItem_Click);
            // 
            // saveSplitsAsToolStripMenuItem
            // 
            this.saveSplitsAsToolStripMenuItem.Enabled = false;
            this.saveSplitsAsToolStripMenuItem.Name = "saveSplitsAsToolStripMenuItem";
            this.saveSplitsAsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveSplitsAsToolStripMenuItem.Text = "Save Splits As...";
            this.saveSplitsAsToolStripMenuItem.Click += new System.EventHandler(this.SaveSplitsAsToolStripMenuItem_Click);
            // 
            // closeSplitsToolStripMenuItem
            // 
            this.closeSplitsToolStripMenuItem.Enabled = false;
            this.closeSplitsToolStripMenuItem.Name = "closeSplitsToolStripMenuItem";
            this.closeSplitsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.closeSplitsToolStripMenuItem.Text = "Close Splits";
            this.closeSplitsToolStripMenuItem.Click += new System.EventHandler(this.CloseSplitsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(154, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // directoryScannerWorker
            // 
            this.directoryScannerWorker.WorkerReportsProgress = true;
            this.directoryScannerWorker.WorkerSupportsCancellation = true;
            this.directoryScannerWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DirectoryScannerWorker_DoWork);
            this.directoryScannerWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DirectoryScannerWorker_ProgressChanged);
            this.directoryScannerWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DirectoryScannerWorker_SwitchDirectory);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.splitsUI, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.separatorUI, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.possibleTimeSaveUI, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.comparisonBestUI, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.sumOfBestUI, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.currentDemoUI, 0, 5);
            this.tableLayoutPanel.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 45);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.MinimumSize = new System.Drawing.Size(220, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(220, 370);
            this.tableLayoutPanel.TabIndex = 7;
            this.tableLayoutPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Borderless_MouseDown);
            this.tableLayoutPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Borderless_MouseMove);
            this.tableLayoutPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Borderless_MouseUp);
            // 
            // splitsUI
            // 
            this.splitsUI.AutoSize = true;
            this.splitsUI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.splitsUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitsUI.Location = new System.Drawing.Point(0, 0);
            this.splitsUI.Margin = new System.Windows.Forms.Padding(0);
            this.splitsUI.Name = "splitsUI";
            this.splitsUI.Size = new System.Drawing.Size(220, 272);
            this.splitsUI.TabIndex = 0;
            // 
            // separatorUI
            // 
            this.separatorUI.AutoSize = true;
            this.separatorUI.BackColor = System.Drawing.Color.Transparent;
            this.separatorUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.separatorUI.Location = new System.Drawing.Point(0, 272);
            this.separatorUI.Margin = new System.Windows.Forms.Padding(0);
            this.separatorUI.MaximumSize = new System.Drawing.Size(0, 15);
            this.separatorUI.MinimumSize = new System.Drawing.Size(0, 15);
            this.separatorUI.Name = "separatorUI";
            this.separatorUI.Size = new System.Drawing.Size(220, 15);
            this.separatorUI.TabIndex = 10;
            // 
            // possibleTimeSaveUI
            // 
            this.possibleTimeSaveUI.AutoSize = true;
            this.possibleTimeSaveUI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.possibleTimeSaveUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.possibleTimeSaveUI.Location = new System.Drawing.Point(0, 287);
            this.possibleTimeSaveUI.Margin = new System.Windows.Forms.Padding(0);
            this.possibleTimeSaveUI.Name = "possibleTimeSaveUI";
            this.possibleTimeSaveUI.Size = new System.Drawing.Size(220, 20);
            this.possibleTimeSaveUI.TabIndex = 9;
            // 
            // comparisonBestUI
            // 
            this.comparisonBestUI.AutoSize = true;
            this.comparisonBestUI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.comparisonBestUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comparisonBestUI.Location = new System.Drawing.Point(0, 307);
            this.comparisonBestUI.Margin = new System.Windows.Forms.Padding(0);
            this.comparisonBestUI.Name = "comparisonBestUI";
            this.comparisonBestUI.Size = new System.Drawing.Size(220, 20);
            this.comparisonBestUI.TabIndex = 9;
            // 
            // sumOfBestUI
            // 
            this.sumOfBestUI.AutoSize = true;
            this.sumOfBestUI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sumOfBestUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sumOfBestUI.Location = new System.Drawing.Point(0, 327);
            this.sumOfBestUI.Margin = new System.Windows.Forms.Padding(0);
            this.sumOfBestUI.Name = "sumOfBestUI";
            this.sumOfBestUI.Size = new System.Drawing.Size(220, 20);
            this.sumOfBestUI.TabIndex = 8;
            // 
            // currentDemoUI
            // 
            this.currentDemoUI.AutoSize = true;
            this.currentDemoUI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.currentDemoUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentDemoUI.Location = new System.Drawing.Point(0, 347);
            this.currentDemoUI.Margin = new System.Windows.Forms.Padding(0);
            this.currentDemoUI.Name = "currentDemoUI";
            this.currentDemoUI.Size = new System.Drawing.Size(220, 20);
            this.currentDemoUI.TabIndex = 11;
            // 
            // runNameUI
            // 
            this.runNameUI.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.runNameUI.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.runNameUI.ForeColor = System.Drawing.Color.White;
            this.runNameUI.Location = new System.Drawing.Point(21, 9);
            this.runNameUI.Name = "runNameUI";
            this.runNameUI.Size = new System.Drawing.Size(178, 19);
            this.runNameUI.TabIndex = 6;
            this.runNameUI.Text = "Source Live Timer";
            this.runNameUI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.ClientSize = new System.Drawing.Size(220, 414);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.runNameUI);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker directoryScannerWorker;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem demoDirectoryToolStripMenuItem;
        private RunNameUI runNameUI;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ToolStripMenuItem editSplitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSplitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSplitsFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSplitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSplitsAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeSplitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private SplitsUI splitsUI;
        private SumOfBestUI sumOfBestUI;
        private PossibleTimeSaveUI possibleTimeSaveUI;
        private SeparatorUI separatorUI;
        private ComparisonBestUI comparisonBestUI;
        private System.Windows.Forms.ToolStripMenuItem fromDemosToolStripMenuItem;
        private CurrentDemoUI currentDemoUI;

    }
}