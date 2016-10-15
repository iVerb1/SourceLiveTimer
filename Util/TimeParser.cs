using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SourceLiveTimer.Util
{
    static class TimeParser
    {
        private static Regex Regex = new Regex(
            @"^(((?<hours>\d{1,2}):)(?=\d{2}:\d{2}))?"
                + @"(((?<minutes>\d{1,2}):)(?=\d{2}))?"
                + @"(?<seconds>\d{1,2})"
                + @"((\.|\,)(?<mantissa>\d+))?$");

        public static TimeSpan Parse(string input)
        {
            Match match = Regex.Match(input);

            int hours = 0;
            int minutes = 0;
            int seconds = 0;
            int milliseconds = 0;

            if (match.Success)
            {
                if (match.Groups["hours"].Success)
                    hours = Int32.Parse(match.Groups["hours"].Value);
                if (match.Groups["minutes"].Success)
                    minutes = Int32.Parse(match.Groups["minutes"].Value);
                if (match.Groups["seconds"].Success)
                    seconds = Int32.Parse(match.Groups["seconds"].Value);
                if (match.Groups["mantissa"].Success)
                {
                    double mantissa = Double.Parse("." + match.Groups["mantissa"].Value, new CultureInfo("en-US"));
                    milliseconds = TimeSpan.FromSeconds(mantissa).Milliseconds;
                }
            }
            if (!match.Success || input == "" || hours >= 24 || minutes >= 60 || seconds >= 60)
            {
                throw new FormatException();
            }

            return new TimeSpan(0, hours, minutes, seconds, milliseconds);
        }

    }
}
