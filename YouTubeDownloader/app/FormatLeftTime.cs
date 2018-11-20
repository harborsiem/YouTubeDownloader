using System;
using System.Collections.Generic;
using System.Text;

namespace YouTubeDownloader {
    public static class FormatLeftTime {

        private static string[] TimeUnitsNames = { "Milli", "Sec", "Min", "Hour", "Day", "Month", "Year", "Decade", "Century" };
        private static int[] TimeUnitsValue = { 1000, 60, 60, 24, 30, 12, 10, 10 }; //reference unit is milliSecond

        public static string Format(long millis) {
            string format = string.Empty;
            for (int i = 0; i < TimeUnitsValue.Length; i++) {
                long y = millis % TimeUnitsValue[i];
                millis = millis / TimeUnitsValue[i];
                if (y == 0) {
                    continue;
                }
                format = y + " " + TimeUnitsNames[i] + " , " + format;
            }

            format = format.Trim(',', ' ');
            if (string.IsNullOrEmpty(format)) {
                return "0 Sec";
            } else {
                return format;
            }
        }
    }
}
