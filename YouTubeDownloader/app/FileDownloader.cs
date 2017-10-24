using System;
using System.ComponentModel;
using System.IO;

namespace YouTubeDownloader {

    /// <summary>
    /// Downloads and resumes files from HTTP, FTP, and File (file://) URLS
    /// </summary>
    public class FileDownloader {
        // Block size to download is by default 1K.
        public const int DownloadBlockSize = 1024 * 200;

        private string downloadingTo;

        public string FileUrl { get; private set; }
        public string DestinationFolder { get; private set; }
        public string DestinationFileName { get; private set; }
        /// <summary>
        /// Gets the current DownloadStatus
        /// </summary>
        public DownloadStatus DownloadStatus { get; private set; }
        /// <summary>
        /// Gets the current DownloadData
        /// </summary>
        public DownloadData DownloadData { get; private set; }
        /// <summary>
        /// Gets the current DownloadSpeed
        /// </summary>
        public int DownloadSpeed { get; private set; }
        /// <summary>
        /// Gets the estimate time to finish downloading, the time is in seconds
        /// </summary>
        public long Eta {
            get {
                if (DownloadData == null || DownloadSpeed == 0) {
                    return 0;
                }
                long remainBytes = DownloadData.FileSize - totalDownloaded;
                return remainBytes / DownloadSpeed;
            }
        }

        public FileDownloader(string fileUrl, string destinationFolder, string destinationFileName, BackgroundWorker worker) {
            this.FileUrl = fileUrl;
            this.DestinationFolder = destinationFolder;
            this.DestinationFileName = destinationFileName;
            worker.DoWork += Download;
        }

        public void Completed(AsyncCompletedEventArgs e) {
            try {
                if (DownloadData != null) {
                    DownloadData.Close();
                }
            }
            catch {
            }
            try {
                if (fileStream != null) {
                    fileStream.Close();
                }
            }
            catch {
            }
            if (e.Cancelled) {
                DownloadStatus = DownloadStatus.Canceled;
            } else if (e.Error != null) {
                DownloadStatus = DownloadStatus.Failed;
            } else {
                DownloadStatus = DownloadStatus.Success;
            }
            DownloadSpeed = 0;
        }

        private int Progress { get; set; }

        /// <summary>
        /// Make the download to Pause
        /// </summary>
        public void Pause() {
            _pause = true;
        }

        /// <summary>
        /// Make the download to resume
        /// </summary>
        public void Resume() {
            _pause = false;
        }

        private bool _pause;
        static long SecondTicks = TimeSpan.FromSeconds(1).Ticks;
        FileStream fileStream;
        long totalDownloaded;

        /// <summary>
        /// Begin downloading the file at the specified url, and save it to the given folder.
        /// </summary>
        private void Download(object sender, DoWorkEventArgs e) {
            BackgroundWorker worker = sender as BackgroundWorker;
            _pause = false;
            DownloadStatus = DownloadStatus.Downloading;
            DownloadData = DownloadData.Create(FileUrl, DestinationFolder, this.DestinationFileName, Helper.InitialProxy());
            if (string.IsNullOrEmpty(DestinationFileName)) {
                Path.GetFileName(DownloadData.Response.ResponseUri.ToString());
            }
            this.downloadingTo = Path.Combine(DestinationFolder, DestinationFileName);
            FileMode mode = DownloadData.StartPoint > 0 ? FileMode.Append : FileMode.OpenOrCreate;
            fileStream = File.Open(downloadingTo, mode, FileAccess.Write);
            byte[] buffer = new byte[DownloadBlockSize];
            totalDownloaded = DownloadData.StartPoint;
            double totalDownloadedInTime = 0;
            long totalDownloadedTime = 0;
            bool callProgress;
            while (true) {
                callProgress = true;
                if (worker.CancellationPending) {
                    DownloadSpeed = Progress = 0;
                    e.Cancel = true;
                    break;
                }
                if (_pause) {
                    DownloadSpeed = 0;
                    DownloadStatus = DownloadStatus.Paused;
                    System.Threading.Thread.Sleep(200);
                } else {
                    DownloadStatus = DownloadStatus.Downloading;
                    long startTime = DateTime.Now.Ticks;
                    int readCount = DownloadData.DownloadStream.Read(buffer, 0, DownloadBlockSize);
                    if (readCount == 0) {
                        Progress = 100;
                        break;
                    }
                    totalDownloadedInTime += readCount;
                    totalDownloadedTime += DateTime.Now.Ticks - startTime;
                    if (callProgress = totalDownloadedTime >= SecondTicks) {
                        DownloadSpeed = (int)(totalDownloadedInTime / TimeSpan.FromTicks(totalDownloadedTime).TotalSeconds);
                        totalDownloadedInTime = 0;
                        totalDownloadedTime = 0;
                    }
                    totalDownloaded += readCount;
                    fileStream.Write(buffer, 0, readCount);
                    fileStream.Flush();
                }
                Progress = (int)(100.0 * totalDownloaded / DownloadData.FileSize);
                if (callProgress && DownloadData.IsProgressKnown) {
                    worker.ReportProgress(Progress);
                }
            }
            worker.ReportProgress(Progress);
        }
    }
}

