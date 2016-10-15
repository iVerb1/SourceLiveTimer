using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceLiveTimer.Util
{
    class FancyTimeFormatter : TimeFormatter
    {

        public FancyTimeFormatter(string nullTime) : base(nullTime)
        {
        }

        public override string GetTimeFormat(TimeSpan timeSpan)
        {
            if (timeSpan.TotalSeconds < 10)
            {
                return "{0:s\\.ff}";
            }
            if (timeSpan.TotalSeconds < 60)
            {
                return "{0:ss\\.f}";
            }
            if (timeSpan.TotalMinutes < 10)
            {
                return "{0:m\\:ss}";
            }
            if (timeSpan.TotalMinutes < 60)
            {
                return "{0:mm\\:ss}";
            }
            if (timeSpan.TotalHours < 10)
            {
                return "{0:h\\:mm\\:ss}";
            }
            return "{0:hh\\:mm\\:ss}";
        }

    }
}
