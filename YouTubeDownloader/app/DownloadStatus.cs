using System;

namespace YouTubeDownloader {

    public enum DownloadStatus {
        None,
        Downloading,
        Paused,
        Success,
        Failed,
        Canceled
    }
}