using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceLiveTimer.Util
{
    abstract class TimeFormatter
    {

        public string NullTime { get; private set; }

        public TimeFormatter(string nullTime)
        {
            NullTime = nullTime;
        }

        public string FormatTicks(int? ticks, double ticksPerSecond)
        {
            if (ticks == null)
            {
                return NullTime;
            }
            else
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds((double)ticks / ticksPerSecond);
                string timeFormat = GetTimeFormat(timeSpan);
                return string.Format(timeFormat, timeSpan);
            }           
        }

        public abstract string GetTimeFormat(TimeSpan timeSpan);

    }
}
