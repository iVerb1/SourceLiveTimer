using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SourceLiveTimer.Speedrun;
using SourceLiveTimer.Util;

namespace SourceLiveTimer.View
{
    partial class EditSplitsForm : Form
    {

        private Dictionary<DataGridViewRow, Split> Splits
        {
            get;
            set;
        }
        public Run Run
        {
            get;
            set;
        }
        
        private TimeFormatter TIME_FORMATTER = new ExactTimeFormatter("");


        public EditSplitsForm(Run run)
        {
            InitializeComponent();
            Run = run;

            RunNameTextBox.Text = run.Name;
            Splits = new Dictionary<DataGridViewRow, Split>();

            foreach (Split split in run)
            {
                DataGridViewRow row = new DataGridViewRow();                
                Splits.Add(row, split);
                row.CreateCells(SplitGrid);
                UpdateCells(row);
                SplitGrid.Rows.Add(row);
                SplitGrid.Height += row.Height;
            }
        }

        private void splitGrid_OnPaste(ClipBoardDgv obj, OnPasteEvtArgs e)
        {
            foreach (DataGridViewCell cell in e.ChangedCells)
            {
                RevalidateRow(cell);
            }             
        }

        private void splitList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                RevalidateRow(SplitGrid[e.ColumnIndex, e.RowIndex]);
            }
        }

        private void RevalidateRow(DataGridViewCell changedCell)
        {
            DataGridViewRow row = this.SplitGrid.Rows[changedCell.RowIndex];
            Split split = Splits[row];
            string value = (string)changedCell.Value;

            try
            {
                switch (changedCell.ColumnIndex)
                {
                    case 0:
                        split.Name = value;
                        break;
                    case 1:
                        Run.setTicks(split, GetTicksFromTime(value));
                        break;
                    case 2:
                        Run.setTicks(split, ToNullableInt(value));
                        break;
                    case 3:
                        split.BestSegment = GetTicksFromTime(value);
                        break;
                    case 4:
                        split.BestSegment = ToNullableInt(value);
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Illegal format!");
            }
            catch (InvalidSplitsException)
            {
                Console.WriteLine("Illegal splits!");
            }
            UpdateCells(row);
        }

        private void UpdateCells(DataGridViewRow row)
        {
            Split split = Splits[row];
            row.Cells[0].Value = split.Name;
            row.Cells[1].Value = TIME_FORMATTER.FormatTicks(split.Ticks, Run.Category.TicksPerSecond);
            row.Cells[2].Value = split.Ticks.ToString();
            row.Cells[3].Value = TIME_FORMATTER.FormatTicks(split.BestSegment, Run.Category.TicksPerSecond);
            row.Cells[4].Value = split.BestSegment.ToString();
        }

        private int? ToNullableInt(string value)
        {
            if (value == TIME_FORMATTER.NullTime || value == "" || value == null)
            {
                return null;
            }
            else
            {
                return int.Parse(value, NumberStyles.None);
            }
        }

        private int? GetTicksFromTime(string value)
        {
            if (value == TIME_FORMATTER.NullTime || value == "" || value == null)
            {
                return null;
            }
            else
            {
                TimeSpan timeSpan = TimeParser.Parse(value);
                int ticksFromSeconds = (int)((int)timeSpan.TotalSeconds * Run.Category.TicksPerSecond);
                int ticksFromMantissa = (int)Math.Round(timeSpan.Milliseconds * Run.Category.TicksPerSecond / 1000);
                return ticksFromSeconds + ticksFromMantissa;
            }
        }

        private void RunNameTextBox_TextChanged(object sender, EventArgs e)
        {
            Run.Name = RunNameTextBox.Text;
        }

        private void SplitGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewCell c in SplitGrid.SelectedCells)
                {
                    c.Value = null;
                    RevalidateRow(c);
                }
            }
        }

    }
}
