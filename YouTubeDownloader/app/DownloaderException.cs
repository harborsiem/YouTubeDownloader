using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace YouTubeDownloader {
    [Serializable]
    public sealed class DownloaderException : Exception, ISerializable {

        public int ErrorCode { get; private set; }
        public bool ErrorDetail { get; private set; }

        public DownloaderException(String message, int errorCode, bool errorDetail)
            : base(message) {
            ErrorCode = errorCode;
            ErrorDetail = errorDetail;
        }

        public DownloaderException()
            : base() { }

        public DownloaderException(String message, Exception innerException)
            : base(message, innerException) { }

        public DownloaderException(String message)
            : base(message) { }

        public DownloaderException(Exception innerException)
            : base(innerException.Message, innerException) { }

        private DownloaderException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
            ErrorCode = info.GetInt32("ErrorCode");
            ErrorDetail = info.GetBoolean("ErrorDetail");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            base.GetObjectData(info, context);
            info.AddValue("ErrorCode", ErrorCode);
            info.AddValue("ErrorDetail", ErrorDetail);
        }
    }
}
