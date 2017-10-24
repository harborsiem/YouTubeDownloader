using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Drawing;

namespace YouTubeDownloader {

    /// <summary>
    /// Contains information about the video url extension and dimension
    /// </summary>
    public class VideoQuality {

        /// <summary>
        /// Gets or Sets the file name
        /// </summary>
        public string VideoTitle { get; set; }

        /// <summary>
        /// Gets or Sets the file extension
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Gets or Sets the file url
        /// </summary>
        public string DownloadUrl { get; set; }

        /// <summary>
        /// Gets or Sets the youtube video url
        /// </summary>
        public string VideoUrl { get; set; }

        /// <summary>
        /// Gets or Sets the youtube video size
        /// </summary>
        public long VideoSize { get; set; }

        /// <summary>
        /// Gets or Sets the youtube video dimension
        /// </summary>
        public Size Dimension { get; set; }

        /// <summary>
        /// Gets the youtube video length
        /// </summary>
        public long Length { get; set; }

        public override string ToString() {
            string videoExtension = this.Extension;
            string videoDimension = FormatSize(this.Dimension);
            string videoSize = String.Format(new FileSizeFormatProvider(), "{0:fs}", this.VideoSize);

            return String.Format(CultureInfo.CurrentCulture, "{0} ({1}) - {2}", videoExtension.ToUpperInvariant(), videoDimension, videoSize);
        }

        private string FormatSize(Size value) {
            string s = value.Height >= 720 ? " HD" : "";
            return ((Size)value).Width + " x " + value.Height + s;
        }
    }
}
