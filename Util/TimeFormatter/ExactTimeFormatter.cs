using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceLiveTimer.Util
{
    class ExactTimeFormatter : TimeFormatter
    {

        public ExactTimeFormatter(string nullTime) : base(nullTime)
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
                return "{0:ss\\.ff}";
            }
            if (timeSpan.TotalMinutes < 10)
            {
                return "{0:m\\:ss\\.ff}";
            }
            if (timeSpan.TotalMinutes < 60)
            {
                return "{0:mm\\:ss\\.ff}";
            }
            if (timeSpan.TotalHours < 10)
            {
                return "{0:h\\:mm\\:ss\\.ff}";
            }
            return "{0:hh\\:mm\\:ss\\.ff}";
        }

    }
}
