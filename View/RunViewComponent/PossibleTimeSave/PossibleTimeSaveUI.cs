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
    partial class PossibleTimeSaveUI : UserControl, RunViewComponent
    {
        private Run run;

        private const int POSSIBLE_TIME_SAVE_HEIGHT = 20;
        private Font POSSIBLE_TIME_SAVE_TEXT_FONT = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Font POSSIBLE_TIME_SAVE_TIME_FONT = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Color POSSIBLE_TIME_SAVE_TEXT_COLOR = System.Drawing.Color.White;
        private TimeFormatter TIME_FORMATTER = new FancyTimeFormatter("-");
        
        public PossibleTimeSaveUI()
        {
            InitializeComponent();
            this.PossibleTimeSaveTextLabel.Font = POSSIBLE_TIME_SAVE_TEXT_FONT;
            this.PossibleTimeSaveTimeLabel.Font = POSSIBLE_TIME_SAVE_TIME_FONT;
            this.PossibleTimeSaveTextLabel.ForeColor = POSSIBLE_TIME_SAVE_TEXT_COLOR;
            this.PossibleTimeSaveTimeLabel.ForeColor = POSSIBLE_TIME_SAVE_TEXT_COLOR;
            this.tableLayoutPanel.RowStyles[0].Height = POSSIBLE_TIME_SAVE_HEIGHT;
        }

        public void LoadRun(Run run)
        {
            this.run = run;
            UpdateComponent();
        }

        public void UpdateComponent()
        {
            if (!run.LastSplitDone())
            {
                int? possibleTimeSave = run.GetCurrentSplit().Segment - run.GetCurrentSplit().BestSegment;
                PossibleTimeSaveTimeLabel.Text = TIME_FORMATTER.FormatTicks(possibleTimeSave, run.Category.TicksPerSecond);
            }
            else
            {
                PossibleTimeSaveTimeLabel.Text = TIME_FORMATTER.NullTime;
            }
        }

        public void UnloadRun()
        {
            run = null;
            PossibleTimeSaveTimeLabel.Text = TIME_FORMATTER.NullTime;
        }

    }
}
