namespace SourceLiveTimer.View
{
    partial class SplitsUI
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
            this.splitsTable = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // splitsTable
            // 
            this.splitsTable.AutoSize = true;
            this.splitsTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.splitsTable.ColumnCount = 3;
            this.splitsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.splitsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.splitsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.splitsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitsTable.Location = new System.Drawing.Point(0, 0);
            this.splitsTable.Margin = new System.Windows.Forms.Padding(0);
            this.splitsTable.Name = "splitsTable";
            this.splitsTable.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.splitsTable.Size = new System.Drawing.Size(0, 2);
            this.splitsTable.TabIndex = 4;
            this.splitsTable.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.SplitsTableCellPaint);
            // 
            // SplitsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.splitsTable);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SplitsUI";
            this.Size = new System.Drawing.Size(0, 2);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel splitsTable;

    }
}
