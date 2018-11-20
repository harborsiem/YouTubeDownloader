using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace YouTubeDownloader {
    public partial class DownloadDialog : Form {

        private enum ButtonFunction {
            None,
            Pause,
            Resume,
            Open,
            Stop,
            Close
        }

        private DownloadModelView modelView;
        private ButtonFunction button1Function;
        private ButtonFunction button2Function;
        private bool progressProcessing;

        private DownloadDialog() {
            if (!DesignMode) {
                this.Font = SystemFonts.MessageBoxFont;
            }
            InitializeComponent();
            button1Function = ButtonFunction.Pause;
            button2Function = ButtonFunction.Stop;
            this.bottomLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.BottomLayout_Paint);
        }

        public DownloadDialog(string url, string saveTo)
            : this() {
            modelView = new DownloadModelView(url, saveTo);
            nameInfoLabel.Text = modelView.NameInfoLabelText;
            modelView.BackgroundWorker.ProgressChanged += Worker_ProgressChanged;
            modelView.BackgroundWorker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            this.button2.Click += new System.EventHandler(this.Button2_Click);

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadDialog_FormClosing);
            modelView.DownloaderRunWorkerAsync();
        }

        void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            modelView.DownloaderCompleted(e);
            if (e.Error != null) {
                this.Close();
                MessageBox.Show("Exception in file download with Message: " + e.Error.Message, e.Error.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (e.Cancelled) {
                this.Close();
                return;
            }
            if (modelView.ClosePending) {
                modelView.ClosePending = false;
                this.Close();
                return;
            }
            RefreshStatus();
        }

        void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (progressProcessing) {
                return;
            }
            try {
                progressProcessing = true;
                progressBar.Value = e.ProgressPercentage > 100 ? 100 : e.ProgressPercentage;
                this.Text = "File Downloader - " + e.ProgressPercentage + " %";
                statusInfoLabel.Text = modelView.ProgressStatusInfo;
                RefreshStatus();
            }
            catch { }
            finally {
                progressProcessing = false;
            }
        }

        private void Button1_Click(object sender, EventArgs e) {
            switch (button1Function) {
                case ButtonFunction.Pause:
                case ButtonFunction.Resume: {
                        modelView.Pause();
                        RefreshStatus();
                        break;
                    }
                case ButtonFunction.Open: {
                        try {
                            modelView.DownloaderOpen();
                        }
                        catch (Exception ex) {
                            MessageBox.Show(this, ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
                default: { break; }
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            switch (button2Function) {
                case ButtonFunction.Stop: {
                        button1.Enabled = false;
                        button2.Enabled = false;
                        modelView.DownloaderCancelAsync();
                        break;
                    }
                case ButtonFunction.Close: {
                        this.Close();
                        break;
                    }
                default: {
                        break;
                    }
            }
        }

        private void RefreshStatus() {
            String statusInfoText = modelView.RefreshStatusInfo();
            if (!String.IsNullOrEmpty(statusInfoText)) {
                statusInfoLabel.Text = statusInfoText;
            }

            ButtonFunctions functions = modelView.RefreshButtonFunctions();
            switch (functions) {
                case ButtonFunctions.PauseStop: {
                        button1.Visible = button2.Visible = true;
                        button1.Text = "Pause";
                        button2.Text = "Stop";
                        button1Function = ButtonFunction.Pause;
                        button2Function = ButtonFunction.Stop;
                        break;
                    }
                case ButtonFunctions.NoneClose: {
                        button1.Visible = false;
                        button2.Visible = true;
                        button2.Text = "Close";
                        button1Function = ButtonFunction.None;
                        button2Function = ButtonFunction.Close;
                        break;
                    }
                case ButtonFunctions.ResumeStop: {
                        button1.Visible = button2.Visible = true;
                        button1.Text = "Resume";
                        button2.Text = "Stop";
                        button1Function = ButtonFunction.Resume;
                        button2Function = ButtonFunction.Stop;
                        break;
                    }
                case ButtonFunctions.OpenClose: {
                        button1.Visible = button2.Visible = true;
                        button1.Text = "Open";
                        button2.Text = "Close";
                        button1Function = ButtonFunction.Open;
                        button2Function = ButtonFunction.Close;
                        break;
                    }
                default: {
                        button1.Visible = button2.Visible = false;
                        button1Function = ButtonFunction.None;
                        button2Function = ButtonFunction.None;
                        break;
                    }
            }
        }

        private void DownloadDialog_FormClosing(object sender, FormClosingEventArgs e) {
            if (modelView.FormClosingPending()) {
                e.Cancel = true;
                this.Enabled = false;   // or this.Hide()
            }
        }

        private void BottomLayout_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawLine(new Pen(Color.Silver, 2), new Point(0, 1), new Point(bottomLayout.Width, 1));
        }
    }
}
