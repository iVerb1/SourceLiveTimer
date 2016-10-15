using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SourceLiveTimer.Speedrun;

namespace SourceLiveTimer.View
{
    interface RunViewComponent
    {       
        void LoadRun(Run run);

        void UpdateComponent();

        void UnloadRun();
    }
}
