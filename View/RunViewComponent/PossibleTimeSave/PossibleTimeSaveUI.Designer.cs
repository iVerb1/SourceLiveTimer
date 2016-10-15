namespace SourceLiveTimer.View
{
    partial class PossibleTimeSaveUI
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
            this.PossibleTimeSaveTimeLabel = new System.Windows.Forms.Label();
            this.PossibleTimeSaveTextLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PossibleTimeSaveTimeLabel
            // 
            this.PossibleTimeSaveTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PossibleTimeSaveTimeLabel.AutoSize = true;
            this.PossibleTimeSaveTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.PossibleTimeSaveTimeLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PossibleTimeSaveTimeLabel.ForeColor = System.Drawing.Color.Black;
            this.PossibleTimeSaveTimeLabel.Location = new System.Drawing.Point(167, 4);
            this.PossibleTimeSaveTimeLabel.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.PossibleTimeSaveTimeLabel.Name = "PossibleTimeSaveTimeLabel";
            this.PossibleTimeSaveTimeLabel.Size = new System.Drawing.Size(12, 22);
            this.PossibleTimeSaveTimeLabel.TabIndex = 3;
            this.PossibleTimeSaveTimeLabel.Text = "-";
            this.PossibleTimeSaveTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PossibleTimeSaveTextLabel
            // 
            this.PossibleTimeSaveTextLabel.AutoSize = true;
            this.PossibleTimeSaveTextLabel.BackColor = System.Drawing.Color.Transparent;
            this.PossibleTimeSaveTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PossibleTimeSaveTextLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PossibleTimeSaveTextLabel.ForeColor = System.Drawing.Color.Black;
            this.PossibleTimeSaveTextLabel.Location = new System.Drawing.Point(3, 0);
            this.PossibleTimeSaveTextLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.PossibleTimeSaveTextLabel.Name = "PossibleTimeSaveTextLabel";
            this.PossibleTimeSaveTextLabel.Size = new System.Drawing.Size(106, 30);
            this.PossibleTimeSaveTextLabel.TabIndex = 3;
            this.PossibleTimeSaveTextLabel.Text = "Possible Time Save";
            this.PossibleTimeSaveTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel.Controls.Add(this.PossibleTimeSaveTextLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.PossibleTimeSaveTimeLabel, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(183, 30);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // PossibleTimeSaveUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PossibleTimeSaveUI";
            this.Size = new System.Drawing.Size(183, 30);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PossibleTimeSaveTimeLabel;
        private System.Windows.Forms.Label PossibleTimeSaveTextLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;


    }
}
