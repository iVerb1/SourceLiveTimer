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
    partial class ComparisonBestUI : UserControl, RunViewComponent
    {
        private Run run;

        private const int PREVIOUS_SEGMENT_BEST_HEIGHT = 20;
        private Font PREVIOUS_SEGMENT_BEST_TEXT_FONT = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Color PREVIOUS_SEGMENT_BEST_TEXT_COLOR = System.Drawing.Color.White;
        private TimeFormatter TIME_FORMATTER = new FancyTimeFormatter("-");

        public ComparisonBestUI()
        {
            InitializeComponent();
            this.PreviousSegmentBestDiffLabel.ADVANCED_COMPARISON = false;
            this.PreviousSegmentBestDiffLabel.TIME_FORMATTER = TIME_FORMATTER;
            this.PreviousSegmentBestTextLabel.Font = PREVIOUS_SEGMENT_BEST_TEXT_FONT;
            this.PreviousSegmentBestTextLabel.ForeColor = PREVIOUS_SEGMENT_BEST_TEXT_COLOR;
            this.PreviousSegmentBestDiffLabel.ForeColor = PREVIOUS_SEGMENT_BEST_TEXT_COLOR;
            this.tableLayoutPanel.RowStyles[0].Height = PREVIOUS_SEGMENT_BEST_HEIGHT;
        }

        public void LoadRun(Run run)
        {
            this.run = run;
            UpdateComponent();
        }

        public void UpdateComponent()
        {
            if (run.AtFirstSplit())
            {
                PreviousSegmentBestDiffLabel.SetNull();
            }
            else
            {
                PreviousSegmentBestDiffLabel.SetDifference(run, run.GetPreviousSplit(), DifferenceWithBest);
            }
        }

        public void UnloadRun()
        {
            run = null;
            PreviousSegmentBestDiffLabel.Text = TIME_FORMATTER.NullTime;
        }

        private int? DifferenceWithBest(Split split)
        {
            return split.LiveSegment - split.BestSegment;
        }

    }
}
