namespace SourceLiveTimer.View
{
    partial class EditSplitsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSplitsForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SplitGrid = new SourceLiveTimer.View.ClipBoardDgv();
            this.Map = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeInTicks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BestSegment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BestSegmentInTicks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.RunNameTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.SplitGrid, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(585, 129);
            this.tableLayoutPanel.TabIndex = 5;
            // 
            // SplitGrid
            // 
            this.SplitGrid.AllowUserToAddRows = false;
            this.SplitGrid.AllowUserToDeleteRows = false;
            this.SplitGrid.AllowUserToResizeColumns = false;
            this.SplitGrid.AllowUserToResizeRows = false;
            this.SplitGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.SplitGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SplitGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.SplitGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Map,
            this.Time,
            this.TimeInTicks,
            this.BestSegment,
            this.BestSegmentInTicks});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SplitGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.SplitGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitGrid.Location = new System.Drawing.Point(0, 60);
            this.SplitGrid.Margin = new System.Windows.Forms.Padding(0);
            this.SplitGrid.MaximumSize = new System.Drawing.Size(593, 500);
            this.SplitGrid.Name = "SplitGrid";
            this.SplitGrid.RowHeadersVisible = false;
            this.SplitGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SplitGrid.Size = new System.Drawing.Size(585, 24);
            this.SplitGrid.TabIndex = 3;
            this.SplitGrid.OnPaste += new SourceLiveTimer.View.ClipBoardDgv.OnPasteHandler(this.splitGrid_OnPaste);
            this.SplitGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.splitList_CellEndEdit);
            this.SplitGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SplitGrid_KeyDown);
            // 
            // Map
            // 
            this.Map.HeaderText = "Map";
            this.Map.Name = "Map";
            this.Map.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Map.Width = 155;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Time.Width = 93;
            // 
            // TimeInTicks
            // 
            this.TimeInTicks.HeaderText = "Time (Ticks)";
            this.TimeInTicks.Name = "TimeInTicks";
            this.TimeInTicks.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TimeInTicks.Width = 93;
            // 
            // BestSegment
            // 
            this.BestSegment.HeaderText = "Best Segment";
            this.BestSegment.Name = "BestSegment";
            this.BestSegment.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BestSegment.Width = 93;
            // 
            // BestSegmentInTicks
            // 
            this.BestSegmentInTicks.HeaderText = "Best Segment (Ticks)";
            this.BestSegmentInTicks.Name = "BestSegmentInTicks";
            this.BestSegmentInTicks.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BestSegmentInTicks.Width = 133;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.OkButton);
            this.panel2.Controls.Add(this.CancelButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 45);
            this.panel2.TabIndex = 4;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(429, 22);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton1
            // 
            this.CancelButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton1.Location = new System.Drawing.Point(510, 22);
            this.CancelButton1.Name = "CancelButton1";
            this.CancelButton1.Size = new System.Drawing.Size(75, 23);
            this.CancelButton1.TabIndex = 2;
            this.CancelButton1.Text = "Cancel";
            this.CancelButton1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RunNameTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 54);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Run name";
            // 
            // RunNameTextBox
            // 
            this.RunNameTextBox.Location = new System.Drawing.Point(-3, 16);
            this.RunNameTextBox.Name = "RunNameTextBox";
            this.RunNameTextBox.Size = new System.Drawing.Size(568, 20);
            this.RunNameTextBox.TabIndex = 0;
            this.RunNameTextBox.TextChanged += new System.EventHandler(this.RunNameTextBox_TextChanged);
            // 
            // EditSplitsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(609, 153);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSplitsForm";
            this.ShowIcon = false;
            this.Text = "Edit Splits";
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private ClipBoardDgv SplitGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Map;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeInTicks;
        private System.Windows.Forms.DataGridViewTextBoxColumn BestSegment;
        private System.Windows.Forms.DataGridViewTextBoxColumn BestSegmentInTicks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RunNameTextBox;
    }
}