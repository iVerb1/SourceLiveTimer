using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Dynamic;
using SourceLiveTimer.Speedrun;
using SourceLiveTimer.Util;

namespace SourceLiveTimer.View
{
    partial class SplitsUI : UserControl, RunViewComponent
    {
        private Run Run;
        private dynamic Splits;
        private bool Scrollable;

        private int NUM_PREVIOUS_SPLITS = 5;
        private int NUM_UPCOMING_SPLITS = 2;
        private bool SHOW_FINAL_SPLIT = true;

        private float SPLIT_HEIGHT = 30F;
        private Color SPLIT_DEFAULT_TEXT_COLOR = Color.White;
        private Font SPLIT_TEXT_FONT = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Font SPLIT_TIME_FONT = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        private Color CURRENT_SPLIT_BACKGROUND_COLOR = Color.FromArgb(9, 78, 118);

        private TimeFormatter TIME_TIME_FORMATTER = new FancyTimeFormatter("-");
        private TimeFormatter DIFF_TIME_FORMATTER = new FancyTimeFormatter("");


        public SplitsUI()
        {
            InitializeComponent();
            CreateSplits(GetNumSplits());
        }

        private void CreateSplits(int numSplits)
        {
            splitsTable.Controls.Clear();
            splitsTable.RowStyles.Clear();

            splitsTable.RowCount = numSplits;
            Splits = new ExpandoObject[numSplits];

            for (int i = 0; i < Splits.Length; i++)
            {
                Splits[i] = new ExpandoObject();
                Splits[i].NameLabel = CreateNameLabel();
                Splits[i].DiffLabel = CreateDiffLabel();
                Splits[i].DiffLabel.TIME_FORMATTER = DIFF_TIME_FORMATTER;
                Splits[i].TimeLabel = CreateTimeLabel();
                splitsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, SPLIT_HEIGHT));
                splitsTable.Controls.Add(Splits[i].NameLabel, 0, i);
                splitsTable.Controls.Add(Splits[i].DiffLabel, 1, i);
                splitsTable.Controls.Add(Splits[i].TimeLabel, 2, i);
            }
        }

        private Label CreateNameLabel()
        {
            Label nameLabel = new Label();
            nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left);
            nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            nameLabel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            nameLabel.BackColor = Color.Transparent;
            nameLabel.AutoEllipsis = true;
            nameLabel.AutoSize = false;
            nameLabel.Dock = DockStyle.Fill;
            nameLabel.Font = SPLIT_TEXT_FONT;
            nameLabel.ForeColor = SPLIT_DEFAULT_TEXT_COLOR;
            nameLabel.Location = new System.Drawing.Point(160, 0);
            nameLabel.Margin = new System.Windows.Forms.Padding(0);
            nameLabel.Location = new System.Drawing.Point(0, 0);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "-";
            return nameLabel;
        }

        private Label CreateDiffLabel()
        {
            DifferenceLabel diffLabel = new DifferenceLabel();
            diffLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom))));
            diffLabel.BackColor = Color.Transparent;
            diffLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            diffLabel.AutoSize = true;
            diffLabel.Location = new System.Drawing.Point(160, 0);
            diffLabel.Margin = new System.Windows.Forms.Padding(0);
            diffLabel.Location = new System.Drawing.Point(0, 0);
            diffLabel.Size = new System.Drawing.Size(34, 13);
            diffLabel.TabIndex = 3;
            diffLabel.Text = "";
            return diffLabel;
        }

        private Label CreateTimeLabel()
        {
            Label timeLabel = new Label();
            timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right))));
            timeLabel.BackColor = Color.Transparent;
            timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            timeLabel.AutoSize = true;
            timeLabel.Font = SPLIT_TIME_FONT;
            timeLabel.ForeColor = SPLIT_DEFAULT_TEXT_COLOR;
            timeLabel.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            timeLabel.Location = new System.Drawing.Point(160, 0);
            timeLabel.Margin = new System.Windows.Forms.Padding(0);
            timeLabel.Location = new System.Drawing.Point(0, 0);
            timeLabel.Size = new System.Drawing.Size(34, 13);
            timeLabel.TabIndex = 3;
            timeLabel.Text = "-";
            return timeLabel;
        }

        public void LoadRun(Run run)
        {
            this.Run = run;
            this.Scrollable = (Run.Count > NUM_PREVIOUS_SPLITS + NUM_UPCOMING_SPLITS + 1);

            CreateSplits(Scrollable ? GetNumSplits() : run.Count);
            UpdateComponent();
        }

        public void UpdateComponent()
        {           
            if (!Scrollable)
            {
                for (int i = 0; i < Run.Count; i++)
                {
                    Split split = Run.GetSplit(i);
                    LoadSplit(i, split);
                }
            }
            else
            {
                int firstSplitIndex;

                if (Run.CurrentSplitIndex >= Run.Count - NUM_UPCOMING_SPLITS)
                {
                    firstSplitIndex = Run.Count - GetNumSplits();
                }
                else
                {
                    firstSplitIndex = Math.Max(Run.CurrentSplitIndex - NUM_PREVIOUS_SPLITS, 0);
                }

                for (int i = 0; i < GetNumSplitsWithoutFinal(); i++)
                {
                    Split split = Run.GetSplit(firstSplitIndex + i);
                    LoadSplit(i, split);
                }
                if (SHOW_FINAL_SPLIT)
                {
                    Split split = Run.GetSplit(Run.Count - 1);
                    LoadSplit(Splits.Length - 1, split);
                }
            }
        }

        private void LoadSplit(int i, Split split)
        {
            dynamic s = Splits[i];
            s.Split = split;
            s.NameLabel.Text = split.Name;
            DifferenceLabel diffLabel = s.DiffLabel;
            diffLabel.SetDifference(Run, split, GetDifference);
            s.TimeLabel.Text = TIME_TIME_FORMATTER.FormatTicks(GetRelevantTicks(split), Run.Category.TicksPerSecond);
        }

        public void UnloadRun()
        {
            Run = null;
            foreach (dynamic s in Splits)
            {
                s.Split = null;
                s.NameLabel.Text = "-";
                s.DiffLabel.SetNull();
                s.TimeLabel.Text = TIME_TIME_FORMATTER.NullTime;
            }
        }

        private int? GetRelevantTicks(Split split)
        {
            if (split.LiveTicks != null)
            {
                return split.LiveTicks;
            }
            else
            {
                return split.Ticks;
            }
        }

        private int? GetDifference(Split split)
        {
            return split.LiveTicks - split.Ticks;
        }

        private int GetNumSplits()
        {
            if (SHOW_FINAL_SPLIT)
                return GetNumSplitsWithoutFinal() + 1;
            else
                return GetNumSplitsWithoutFinal();
        }

        private int GetNumSplitsWithoutFinal()
        {
            return NUM_PREVIOUS_SPLITS + NUM_UPCOMING_SPLITS + 1;
        }

        private void SplitsTableCellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

            int leftX = e.CellBounds.X;
            int rightX = e.CellBounds.X + e.CellBounds.Width;
            int topY = e.CellBounds.Y;
            int bottomY = e.CellBounds.Y + e.CellBounds.Height;

            if (SHOW_FINAL_SPLIT && Scrollable)
            {
                if (e.Row == GetNumSplitsWithoutFinal())
                {
                    //bottom line
                    e.Graphics.DrawLine(new Pen(Color.Gray), leftX, bottomY, rightX, bottomY);

                    //top line
                    if (Run != null)
                    {
                        if (Run.CurrentSplitIndex < Run.Count - NUM_UPCOMING_SPLITS - 2)
                            e.Graphics.DrawLine(new Pen(Color.Gray), leftX, topY, rightX, topY);
                    }
                    else
                        e.Graphics.DrawLine(new Pen(Color.Gray), leftX, topY, rightX, topY);
                }
            }

            if (Run != null)
            {
                if (!Run.LastSplitDone())
                {
                    for (int i = 0; i < Splits.Length; i++)
                    {
                        if (Run.GetCurrentSplit() == Splits[i].Split && e.Row == i)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(CURRENT_SPLIT_BACKGROUND_COLOR), e.CellBounds);
                        }
                    }
                }
            }
        }

    }
}
