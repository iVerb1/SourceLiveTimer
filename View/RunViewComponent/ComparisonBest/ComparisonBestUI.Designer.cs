using System.Drawing;

namespace SourceLiveTimer.View
{
    partial class ComparisonBestUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PreviousSegmentBestTextLabel = new System.Windows.Forms.Label();
            this.PreviousSegmentBestDiffLabel = new SourceLiveTimer.View.DifferenceLabel();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.Controls.Add(this.PreviousSegmentBestTextLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.PreviousSegmentBestDiffLabel, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(143, 30);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // PreviousSegmentBestTextLabel
            // 
            this.PreviousSegmentBestTextLabel.AutoSize = true;
            this.PreviousSegmentBestTextLabel.BackColor = System.Drawing.Color.Transparent;
            this.PreviousSegmentBestTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviousSegmentBestTextLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviousSegmentBestTextLabel.ForeColor = System.Drawing.Color.Black;
            this.PreviousSegmentBestTextLabel.Location = new System.Drawing.Point(3, 0);
            this.PreviousSegmentBestTextLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.PreviousSegmentBestTextLabel.Name = "PreviousSegmentBestTextLabel";
            this.PreviousSegmentBestTextLabel.Size = new System.Drawing.Size(97, 30);
            this.PreviousSegmentBestTextLabel.TabIndex = 3;
            this.PreviousSegmentBestTextLabel.Text = "Comparison Best";
            this.PreviousSegmentBestTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PreviousSegmentBestDiffLabel
            // 
            this.PreviousSegmentBestDiffLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviousSegmentBestDiffLabel.AutoSize = true;
            this.PreviousSegmentBestDiffLabel.BackColor = System.Drawing.Color.Transparent;
            this.PreviousSegmentBestDiffLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviousSegmentBestDiffLabel.ForeColor = System.Drawing.Color.Black;
            this.PreviousSegmentBestDiffLabel.Location = new System.Drawing.Point(127, 4);
            this.PreviousSegmentBestDiffLabel.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.PreviousSegmentBestDiffLabel.Name = "PreviousSegmentBestDiffLabel";
            this.PreviousSegmentBestDiffLabel.Size = new System.Drawing.Size(12, 22);
            this.PreviousSegmentBestDiffLabel.TabIndex = 3;
            this.PreviousSegmentBestDiffLabel.Text = "-";
            this.PreviousSegmentBestDiffLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ComparisonBestUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ComparisonBestUI";
            this.Size = new System.Drawing.Size(143, 30);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label PreviousSegmentBestTextLabel;
        private DifferenceLabel PreviousSegmentBestDiffLabel;
    }
}
