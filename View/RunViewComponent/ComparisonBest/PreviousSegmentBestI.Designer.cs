using System.Drawing;

namespace SourceLiveTimer
{
    partial class PreviousSegmentBestUI
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
            this.sumOfBestTextLabel = new System.Windows.Forms.Label();
            this.sumOfBestTimeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.sumOfBestTextLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.sumOfBestTimeLabel, 1, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.MaximumSize = new System.Drawing.Size(202, 0);
            this.tableLayoutPanel.MinimumSize = new System.Drawing.Size(202, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(202, 30);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // sumOfBestTextLabel
            // 
            this.sumOfBestTextLabel.BackColor = System.Drawing.Color.Transparent;
            this.sumOfBestTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sumOfBestTextLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sumOfBestTextLabel.ForeColor = System.Drawing.Color.Black;
            this.sumOfBestTextLabel.Location = new System.Drawing.Point(3, 3);
            this.sumOfBestTextLabel.Margin = new System.Windows.Forms.Padding(3);
            this.sumOfBestTextLabel.Name = "sumOfBestTextLabel";
            this.sumOfBestTextLabel.Size = new System.Drawing.Size(95, 24);
            this.sumOfBestTextLabel.TabIndex = 3;
            this.sumOfBestTextLabel.Text = "Sum of Best";
            this.sumOfBestTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sumOfBestTimeLabel
            // 
            this.sumOfBestTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sumOfBestTimeLabel.AutoSize = true;
            this.sumOfBestTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.sumOfBestTimeLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sumOfBestTimeLabel.ForeColor = System.Drawing.Color.Black;
            this.sumOfBestTimeLabel.Location = new System.Drawing.Point(186, 4);
            this.sumOfBestTimeLabel.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.sumOfBestTimeLabel.Name = "sumOfBestTimeLabel";
            this.sumOfBestTimeLabel.Size = new System.Drawing.Size(12, 22);
            this.sumOfBestTimeLabel.TabIndex = 3;
            this.sumOfBestTimeLabel.Text = "-";
            this.sumOfBestTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SumOfBestUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SumOfBestUI";
            this.Size = new System.Drawing.Size(202, 30);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label sumOfBestTextLabel;
        private System.Windows.Forms.Label sumOfBestTimeLabel;
    }
}
