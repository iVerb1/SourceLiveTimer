using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using SourceLiveTimer.Util;
using SourceLiveTimer.Speedrun;

namespace SourceLiveTimer.View
{
    class DifferenceLabel : Label
    {
        private Font FONT = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Color DEFAULT_TEXT_COLOR = Color.White;

        private Color BEHIND_GAIN_TEXT_COLOR = Color.FromArgb(197, 82, 70);
        private Color BEHIND_LOSS_TEXT_COLOR = Color.FromArgb(204, 55, 41);
        private Color AHEAD_GAIN_TEXT_COLOR = Color.FromArgb(134, 195, 37);
        private Color AHEAD_LOSS_TEXT_COLOR = Color.FromArgb(112, 204, 137);
        private Color EVEN_TEXT_COLOR = Color.White;
        private Color BEST_TEXT_COLOR = Color.FromArgb(216, 175, 31);

        public TimeFormatter TIME_FORMATTER = new FancyTimeFormatter("");
        public bool ADVANCED_COMPARISON = true;


        public DifferenceLabel()
        {
            Font = FONT;
            ForeColor = DEFAULT_TEXT_COLOR;
        }

        public void SetDifference(Run run, Split split, Func<Split, int?> differenceFunction)
        {
            int? difference = differenceFunction(split);

            if (difference == null)
            {
                SetNull();
            }
            else
            {
                ForeColor = GetDiffColor(run, split, differenceFunction);
                string diff = TIME_FORMATTER.FormatTicks(Math.Abs((int)difference), run.Category.TicksPerSecond);
                if (difference < 0)
                {
                    Text = "-" + diff;
                }
                else
                {
                    Text = "+" + diff;
                }
            }
        }

        private Color GetDiffColor(Run run, Split split, Func<Split, int?> differenceFunction)
        {
            int splitIndex = run.IndexOf(split);
            int? diff = differenceFunction(split);

            if (split.IsBest())
                return BEST_TEXT_COLOR;
            if (diff == 0)
                return EVEN_TEXT_COLOR;
            if (splitIndex == 0 || !ADVANCED_COMPARISON)
            {
                if (diff <= 0)
                    return AHEAD_GAIN_TEXT_COLOR;
                else
                    return BEHIND_LOSS_TEXT_COLOR;
            }
            else
            {
                int? previousDiff = differenceFunction(run[splitIndex - 1]);
                if (diff > 0)
                {
                    if (diff >= previousDiff)
                        return BEHIND_LOSS_TEXT_COLOR;
                    if (diff < previousDiff)
                        return BEHIND_GAIN_TEXT_COLOR;
                }
                else
                {
                    if (diff <= previousDiff)
                        return AHEAD_GAIN_TEXT_COLOR;
                    if (diff > previousDiff)
                        return AHEAD_LOSS_TEXT_COLOR;
                }
            }
            throw new Exception();
        }

        public void SetNull()
        {
            ForeColor = DEFAULT_TEXT_COLOR;
            Text = TIME_FORMATTER.NullTime;
        }

    }
}
