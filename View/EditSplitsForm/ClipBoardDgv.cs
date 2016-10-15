using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SourceLiveTimer.View
{
    class ClipBoardDgv : DataGridView
    {
        public delegate void OnPasteHandler(ClipBoardDgv obj, OnPasteEvtArgs e);

        public event OnPasteHandler OnPaste;


        public ClipBoardDgv()
        {
            System.ComponentModel.IContainer components = new System.ComponentModel.Container();
            ContextMenuStrip contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            ToolStripMenuItem copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem pasteCtrlVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            copyToolStripMenuItem,
            pasteCtrlVToolStripMenuItem});
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(145, 48);

            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            copyToolStripMenuItem.Text = "&Copy";
            copyToolStripMenuItem.Click += new System.EventHandler(CopyToolStripMenuItem_Click);

            pasteCtrlVToolStripMenuItem.Name = "pasteCtrlVToolStripMenuItem";
            pasteCtrlVToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            pasteCtrlVToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            pasteCtrlVToolStripMenuItem.Text = "Paste";
            pasteCtrlVToolStripMenuItem.Click += new System.EventHandler(PasteCtrlVToolStripMenuItem_Click);
            
            ContextMenuStrip = contextMenuStrip1;
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyClipboard();
		}

		private void CopyClipboard()
		{
			DataObject d = GetClipboardContent();
			Clipboard.SetDataObject(d);
		}

		private void PasteCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PasteClipboard();
		}

		private void PasteClipboard()
		{
		    string s = Clipboard.GetText();
		    string[] lines = s.Split('\n');
            int iRow = CurrentCell.RowIndex;
		    int iCol = CurrentCell.ColumnIndex;
		    DataGridViewCell oCell;
            List<DataGridViewCell> updatedCells = new List<DataGridViewCell>();

		    foreach (string line in lines)
		    {
			    if (iRow < RowCount && line.Length > 0)
			    {
				    string[] sCells = line.TrimEnd('\r').Split('\t');
				    for (int i = 0; i < sCells.Length; ++i)
				    {
					    if (iCol + i < this.ColumnCount)
					    {
						    oCell = this[iCol + i, iRow];
						    if (!oCell.ReadOnly)
						    {
                                oCell.Value = sCells[i];
                                updatedCells.Add(oCell);
						    }
					    }
					    else
                            break;
				    }
				    iRow++;
			    }
			    else
                    break;
		    }
            OnPaste(this, new OnPasteEvtArgs(updatedCells));
		}
        
    }
}
