using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using SourceLiveTimer.Speedrun;

namespace SourceLiveTimer.View
{
    class RunNameUI : Label, RunViewComponent
    {
        private Run run;

        private Font FONT = new System.Drawing.Font("Segoe UI", 10F);
        private Color TEXT_COLOR = System.Drawing.Color.White;

        public RunNameUI()
        {
            this.Font = FONT;
            this.ForeColor = TEXT_COLOR;
        }

        public void LoadRun(Run run)
        {
            this.run = run;
            UpdateComponent();
        }

        public void UpdateComponent()
        {
            Text = run.Name;
        }

        public void UnloadRun()
        {
            run = null;
            Text = "Source Live Timer";
        }        
    }
}
