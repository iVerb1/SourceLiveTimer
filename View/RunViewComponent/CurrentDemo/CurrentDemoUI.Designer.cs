namespace SourceLiveTimer.View
{
    partial class CurrentDemoUI
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
            this.currentDemoTextLabel = new System.Windows.Forms.Label();
            this.currentDemoDemoLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel.Controls.Add(this.currentDemoTextLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.currentDemoDemoLabel, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(189, 30);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // currentDemoTextLabel
            // 
            this.currentDemoTextLabel.AutoSize = true;
            this.currentDemoTextLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentDemoTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentDemoTextLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentDemoTextLabel.ForeColor = System.Drawing.Color.Black;
            this.currentDemoTextLabel.Location = new System.Drawing.Point(3, 0);
            this.currentDemoTextLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.currentDemoTextLabel.Name = "currentDemoTextLabel";
            this.currentDemoTextLabel.Size = new System.Drawing.Size(82, 30);
            this.currentDemoTextLabel.TabIndex = 3;
            this.currentDemoTextLabel.Text = "Current Demo";
            this.currentDemoTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // currentDemoDemoLabel
            // 
            this.currentDemoDemoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentDemoDemoLabel.AutoEllipsis = true;
            this.currentDemoDemoLabel.AutoSize = true;
            this.currentDemoDemoLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentDemoDemoLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.currentDemoDemoLabel.ForeColor = System.Drawing.Color.Black;
            this.currentDemoDemoLabel.Location = new System.Drawing.Point(173, 3);
            this.currentDemoDemoLabel.Margin = new System.Windows.Forms.Padding(0, 3, 4, 3);
            this.currentDemoDemoLabel.Name = "currentDemoDemoLabel";
            this.currentDemoDemoLabel.Size = new System.Drawing.Size(12, 24);
            this.currentDemoDemoLabel.TabIndex = 3;
            this.currentDemoDemoLabel.Text = "-";
            this.currentDemoDemoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CurrentDemoUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CurrentDemoUI";
            this.Size = new System.Drawing.Size(189, 30);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label currentDemoTextLabel;
        private System.Windows.Forms.Label currentDemoDemoLabel;
    }
}
