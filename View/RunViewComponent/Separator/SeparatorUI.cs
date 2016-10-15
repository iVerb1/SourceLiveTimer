using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SourceLiveTimer.Speedrun;

namespace SourceLiveTimer.View
{
    partial class SeparatorUI : UserControl, RunViewComponent
    {

        private const int SEPARATOR_HEIGHT = 10;
        
        public SeparatorUI()
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(-1, SEPARATOR_HEIGHT);
            this.MaximumSize = new System.Drawing.Size(-1, SEPARATOR_HEIGHT);
        }

        public void LoadRun(Run run)
        {

        }

        public void UpdateComponent()
        {

        }

        public void UnloadRun()
        {

        }
    }
}
