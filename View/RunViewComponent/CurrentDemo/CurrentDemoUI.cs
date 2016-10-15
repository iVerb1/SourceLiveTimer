using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SourceLiveTimer.Speedrun;

namespace SourceLiveTimer.View
{
    partial class CurrentDemoUI : UserControl, RunViewComponent
    {
        private Run run;

        private const int SUM_OF_BEST_HEIGHT = 20;
        private Font CURRENT_DEMO_TEXT_FONT = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Font CURRENT_DEMO_DEMO_FONT = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Color CURRENT_DEMO_TEXT_COLOR = System.Drawing.Color.White;

        public CurrentDemoUI()
        {
            InitializeComponent();
            this.currentDemoTextLabel.Font = CURRENT_DEMO_TEXT_FONT;
            this.currentDemoDemoLabel.Font = CURRENT_DEMO_DEMO_FONT;
            this.currentDemoTextLabel.ForeColor = CURRENT_DEMO_TEXT_COLOR;
            this.currentDemoDemoLabel.ForeColor = CURRENT_DEMO_TEXT_COLOR;
            this.tableLayoutPanel.RowStyles[0].Height = SUM_OF_BEST_HEIGHT;
        }

        public void LoadRun(Run run)
        {
            this.run = run;
            UpdateComponent();
        }

        public void UpdateComponent()
        {
            if (run.CurrentDemo != null)
            {
                currentDemoDemoLabel.Text = Path.GetFileName(Path.GetFileNameWithoutExtension(run.CurrentDemo));
            }
            else
            {
                currentDemoDemoLabel.Text = "-";
            }
        }

        public void UnloadRun()
        {
            run = null;
            currentDemoDemoLabel.Text = "-";
        }
    }
}
