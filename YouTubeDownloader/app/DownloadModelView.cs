using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;

namespace YouTubeDownloader {

    public enum ButtonFunctions {
        PauseStop,
        ResumeStop,
        NoneClose,
        OpenClose,
    }

    class DownloadModelView {

        //private CopyFile downloader;
        private FileDownloader downloader;
        private BackgroundWorker backgroundWorker;
        public bool ClosePending { get; set; }

        public DownloadModelView(string url, string saveTo) {
            var folder = Path.GetDirectoryName(saveTo);
            string file = Path.GetFileName(saveTo);
            NameInfoLabelText = file;
            BackgroundWorker = new BackgroundWorker();
            BackgroundWorker.WorkerReportsProgress = true;
            BackgroundWorker.WorkerSupportsCancellation = true;

            //downloader = new CopyFile(url, folder, file, BackgroundWorker);
            downloader = new FileDownloader(url, folder, file, BackgroundWorker);
        }

        public bool FormClosingPending() {
            if (BackgroundWorker != null && BackgroundWorker.IsBusy) {
                ClosePending = true;
                BackgroundWorker.CancelAsync();
                return true;
            }
            return false;
        }

        //public CopyFile Downloader {
        //    get { return downloader; }
        //    private set { downloader = value; }
        //}

        public FileDownloader Downloader {
            get { return downloader; }
            private set { downloader = value; }
        }

        public BackgroundWorker BackgroundWorker {
            get { return backgroundWorker; }
            private set { backgroundWorker = value; }
        }

        public void DownloaderRunWorkerAsync() {
            BackgroundWorker.RunWorkerAsync();
        }

        public void DownloaderCancelAsync() {
            BackgroundWorker.CancelAsync();
        }

        public void DownloaderOpen() {
            Process.Start(downloader.DestinationFolder + "\\" + downloader.DestinationFileName);
        }

        public void DownloaderCompleted(RunWorkerCompletedEventArgs e) {
            downloader.Completed(e);
        }

        public DownloadStatus DownloadStatus {
            get { return downloader.DownloadStatus; }
        }

        public void Pause() {
            if (DownloadStatus == DownloadStatus.Downloading) {
                downloader.Pause();
            } else if (DownloadStatus == DownloadStatus.Paused) {
                downloader.Resume();
            }
        }

        public ButtonFunctions RefreshButtonFunctions() {
            ButtonFunctions result = ButtonFunctions.PauseStop;
            DownloadStatus status = DownloadStatus;
            if (status == DownloadStatus.Downloading) {
                result = ButtonFunctions.PauseStop;
            }
            if (status == DownloadStatus.Paused) {
                result = ButtonFunctions.ResumeStop;
            }
            if (status == DownloadStatus.Success) {
                result = ButtonFunctions.OpenClose;
            }
            if (status == DownloadStatus.Failed) {
                result = ButtonFunctions.NoneClose;
            }
            return result;
        }

        public String RefreshStatusInfo() {
            String result = String.Empty;
            if (DownloadStatus == DownloadStatus.Success) {
                result = "Completed";
            } else if (DownloadStatus == DownloadStatus.Paused) {
                result = "Paused";
            }
            return result;
        }

        public String ProgressStatusInfo {
            get {
                string speed = String.Format(new FileSizeFormatProvider(), "{0:s}", downloader.DownloadSpeed);
                string ETA = downloader.Eta == 0 ? "" : "  [ " + FormatLeftTime.Format(((long)downloader.Eta) * 1000) + " ]";
                return speed + ETA;
            }
        }

        public String NameInfoLabelText {
            get; private set;
        }

    }
}
