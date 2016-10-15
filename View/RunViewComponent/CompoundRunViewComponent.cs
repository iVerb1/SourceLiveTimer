using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using SourceLiveTimer.Speedrun;

namespace SourceLiveTimer.View
{
    class CompoundRunViewComponent : HashSet<RunViewComponent>, RunViewComponent
    {                
        public void LoadRun(Run run)
        {
            foreach (RunViewComponent r in this)
            {
                r.LoadRun(run);
            }
        }

        public void UpdateComponent()
        {
            foreach (RunViewComponent r in this)
            {
                r.UpdateComponent();
            }
        }

        public void UnloadRun()
        {
            foreach (RunViewComponent r in this)
            {
                r.UnloadRun();
            }
        }

    }
}
