using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SourceLiveTimer.View
{
    class OnPasteEvtArgs : EventArgs    {

        public List<DataGridViewCell> ChangedCells;

        public OnPasteEvtArgs(List<DataGridViewCell> changedCells)
        {
            this.ChangedCells = changedCells;
        }
    }
}
