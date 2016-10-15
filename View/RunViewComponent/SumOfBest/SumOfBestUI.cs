using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SourceLiveTimer.Speedrun;
using SourceLiveTimer.Util;

namespace SourceLiveTimer.View
{
    partial class SumOfBestUI : UserControl, RunViewComponent
    {
        private Run run;

        private const int SUM_OF_BEST_HEIGHT = 20;
        private Font SUM_OF_BEST_TEXT_FONT = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Font SUM_OF_BEST_TIME_FONT = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Color SUM_OF_BEST_TEXT_COLOR = System.Drawing.Color.White;
        private TimeFormatter TIME_FORMATTER = new FancyTimeFormatter("-");

        public SumOfBestUI()
        {
            InitializeComponent();
            this.sumOfBestTextLabel.Font = SUM_OF_BEST_TEXT_FONT;
            this.sumOfBestTimeLabel.Font = SUM_OF_BEST_TIME_FONT;
            this.sumOfBestTextLabel.ForeColor = SUM_OF_BEST_TEXT_COLOR;
            this.sumOfBestTimeLabel.ForeColor = SUM_OF_BEST_TEXT_COLOR;
            this.tableLayoutPanel.RowStyles[0].Height = SUM_OF_BEST_HEIGHT;
        }

        public void LoadRun(Run run)
        {
            this.run = run;
            UpdateComponent();
        }

        public void UpdateComponent()
        {
            int? sumOfBest = run.GetSumOfBest();
            sumOfBestTimeLabel.Text = TIME_FORMATTER.FormatTicks(sumOfBest, run.Category.TicksPerSecond);
        }

        public void UnloadRun()
        {
            run = null;
            sumOfBestTimeLabel.Text = TIME_FORMATTER.NullTime;
        }        

    }
}
