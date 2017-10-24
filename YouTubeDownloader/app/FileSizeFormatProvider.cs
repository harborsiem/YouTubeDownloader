using System;
using System.Globalization;

namespace YouTubeDownloader {
    public class FileSizeFormatProvider : IFormatProvider, ICustomFormatter {
        public object GetFormat(Type formatType) {
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }

        private const string FileSizeFormat = "fs", SpeedFormat = "s";
        private const Decimal OneKiloByte = 1024M;
        private const Decimal OneMegaByte = OneKiloByte * 1024M;
        private const Decimal OneGigaByte = OneMegaByte * 1024M;

        public string Format(string format, object arg, IFormatProvider formatProvider) {
            if (format == null || (!format.StartsWith(FileSizeFormat, StringComparison.Ordinal) && !format.StartsWith(SpeedFormat, StringComparison.Ordinal))) {
                return defaultFormat(format, arg, formatProvider);
            }

            if (arg is string) {
                return defaultFormat(format, arg, formatProvider);
            }

            Decimal size;

            try {
                size = Convert.ToDecimal(arg, CultureInfo.InvariantCulture);
            }
            catch (InvalidCastException) {
                return defaultFormat(format, arg, formatProvider);
            }

            string suffix;
            if (size > OneGigaByte) {
                size /= OneGigaByte;
                suffix = "GB";
            } else if (size > OneMegaByte) {
                size /= OneMegaByte;
                suffix = "MB";
            } else if (size > OneKiloByte) {
                size /= OneKiloByte;
                suffix = "KB";
            } else {
                suffix = "Bytes";
            }
            if (format.StartsWith(SpeedFormat, StringComparison.Ordinal)) {
                suffix += "/sec";
            }
            int position = format.StartsWith(SpeedFormat, StringComparison.Ordinal) ? SpeedFormat.Length : FileSizeFormat.Length;
            string precision = format.Substring(position);
            if (String.IsNullOrEmpty(precision)) {
                precision = "2";
            }
            return String.Format(CultureInfo.CurrentCulture, "{0:N" + precision + "}{1}", size, " " + suffix);
        }

        private static string defaultFormat(string format, object arg, IFormatProvider formatProvider) {
            IFormattable formattableArg = arg as IFormattable;
            if (formattableArg != null) {
                return formattableArg.ToString(format, formatProvider);
            }
            return arg.ToString();
        }
    }
}
