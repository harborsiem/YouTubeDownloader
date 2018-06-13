//Copy rights are reserved for Akram kamal qassas
//Email me, Akramnet4u@hotmail.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Globalization;

namespace YouTubeDownloader {
    public partial class MainForm : Form {

        private SaveFileDialog saveFileDialog;
        private BackgroundWorker backgroundWorker;
        private System.Threading.Timer timer2;

        public MainForm() {
            if (!this.DesignMode) {
                this.Font = SystemFonts.MessageBoxFont;
            }
            InitializeComponent();
            //this.Shown += MainForm_Shown;
            //this.FormClosing += MainForm_FormClosing;
            urlHeaderLabel.Font = new Font(this.Font.FontFamily, 12.0f);
            this.topPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TopPanel_Paint);
            this.bottomLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.BottomLayout_Paint);
            this.secondLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.SecondLayout_Paint);
            this.middleLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.MiddleLayout_Paint);
            InitBackgroundWorker();
            this.urlTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UrlTextBox_KeyPress);
            this.urlTextBox.TextChanged += new System.EventHandler(this.UrlTextBox_TextChanged);
            this.pasteButton.Click += new System.EventHandler(this.PasteButton_Click);
            this.getVideoButton.Click += new System.EventHandler(this.GetVideoButton_Click);
            this.qualityComboBox.EnabledChanged += new System.EventHandler(this.QualityComboBox_EnabledChanged);
            this.downloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            this.copyUrlButton.Click += new System.EventHandler(this.CopyUrlButton_Click);
            this.aboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            //this.timer1.Enabled = false;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save the downloaded file";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            timer2.Change(Timeout.Infinite, Timeout.Infinite);
            timer2.Dispose();
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            timer2 = new System.Threading.Timer(ThreadingTimer, null, 100, 100);
        }

        private void ThreadingTimer(object state) {
            if (this.InvokeRequired) {
                this.Invoke(new Action(SetPasteButtonEnabled));
            } else {
                SetPasteButtonEnabled();
            }
        }

        private void InitBackgroundWorker() {
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            //this.backgroundWorker.WorkerReportsProgress = true;
            //this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            SetPasteButtonEnabled();
        }

        private void SetPasteButtonEnabled() {
            pasteButton.Enabled = !backgroundWorker.IsBusy && !String.IsNullOrEmpty(Clipboard.GetText());
        }

        private void SecondLayout_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawRectangle(new Pen(Color.Gainsboro), new Rectangle(0, 0, secondLayout.Width - 1, secondLayout.Height - 1));
            e.Graphics.DrawRectangle(new Pen(Color.White), new Rectangle(1, 1, secondLayout.Width - 3, secondLayout.Height - 3));
        }

        private void MiddleLayout_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawRectangle(new Pen(Color.Gainsboro), new Rectangle(0, 0, middleLayout.Width - 1, middleLayout.Height - 1));
            e.Graphics.DrawRectangle(new Pen(Color.White), new Rectangle(1, 1, middleLayout.Width - 3, middleLayout.Height - 3));
        }

        private void BottomLayout_Paint(object sender, PaintEventArgs e) {
            //e.Graphics.DrawLine(new Pen(Color.Silver, 2), new Point(0, 1), new Point(panel1.Width, 1));
            //Rectangle Rec1 = new Rectangle(0, 0, panel1.Width, panel1.Height);
            //Brush LGBrush = new System.Drawing.Drawing2D.LinearGradientBrush(Rec1, Color.WhiteSmoke, Color.Gainsboro, 90);
            //e.Graphics.FillRectangle(LGBrush, Rec1);
            e.Graphics.DrawLine(new Pen(Color.Silver, 2), new Point(0, 1), new Point(bottomLayout.Width, 1));
            //e.Graphics.DrawLine(new Pen(Color.White), new Point(0, 1), new Point(panel1.Width, 1));
        }

        private void TopPanel_Paint(object sender, PaintEventArgs e) {
            //Rectangle Rec1 = new Rectangle(0, 0, panel2.Width, panel2.Height);
            //Brush LGBrush = new System.Drawing.Drawing2D.LinearGradientBrush(Rec1, Color.WhiteSmoke, Color.Gainsboro, 90);
            //e.Graphics.FillRectangle(LGBrush, Rec1);
            e.Graphics.DrawLine(new Pen(Color.DarkRed), new Point(0, topPanel.Height - 1), new Point(topPanel.Width, topPanel.Height - 1));
            //e.Graphics.DrawLine(new Pen(Color.FromArgb(100, Color.White)), new Point(0, panel2.Height - 2), new Point(panel2.Width, panel2.Height - 2));
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            IList<VideoQuality> list = null;
            list = YouTubeDownloader.GetYouTubeVideoUrls((string)e.Argument);
            e.Result = list;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            try {
                UseWaitCursor = false;
                if (e.Error != null) {
                    DownloaderException dlEx = e.Error as DownloaderException;
                    if (dlEx != null) {
                        MessageBox.Show(this, dlEx.Message, dlEx.ErrorCode != 0 ? "ErrorCode: " + dlEx.ErrorCode.ToString(CultureInfo.InvariantCulture) : "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        Exception ex = e.Error;
                        ex = ex.InnerException ?? ex;
                        MessageBox.Show(this, ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    urlTextBox.Enabled = true;
                    progressBar.Hide();
                    return;
                }

                IList<VideoQuality> urls = e.Result as IList<VideoQuality>;
                qualityComboBox.DataSource = urls;
                if (urls.Count > 0) {
                    TimeSpan videoLength = TimeSpan.FromSeconds(urls[0].Length);
                    if (videoLength.Hours > 0) {
                        DrawVideoLength(String.Format(CultureInfo.InvariantCulture, "{0}:{1}:{2}", videoLength.Hours, videoLength.Minutes, videoLength.Seconds));
                    } else {
                        DrawVideoLength(String.Format(CultureInfo.InvariantCulture, "{0}:{1}", videoLength.Minutes, videoLength.Seconds));
                    }

                    nameTextLabel.Text = FormatTitle(urls[0].VideoTitle);
                } else {
                    DrawVideoLength("");
                    nameTextLabel.Text = "";
                }
                qualityComboBox.Enabled = urlTextBox.Enabled = true;
                progressBar.Visible = false;

            }
            catch (Exception ex) {
                ex = ex.InnerException ?? ex;
                MessageBox.Show(this, ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                urlTextBox.Enabled = true;
                progressBar.Hide();
            }
        }

        private void UrlTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                e.Handled = true;
                GetVideoButton_Click(sender, EventArgs.Empty);
            }
        }

        private void PasteButton_Click(object sender, EventArgs e) {
            urlTextBox.Clear();
            urlTextBox.Text = Clipboard.GetText().Trim();
        }

        private void GetVideoButton_Click(object sender, EventArgs e) {
            try {
                if (!Helper.IsValidUrl(urlTextBox.Text) || !urlTextBox.Text.ToLowerInvariant().Contains("youtube.com/watch?")) { //@org: "www.youtube.com/watch?"
                    MessageBox.Show(this, "You enter invalid YouTube URL, Please correct it.\r\n\nNote: URL should start with:\r\nhttp://www.youtube.com/watch?",
                        "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else {
                    getVideoButton.Enabled = urlTextBox.Enabled = false;
                    progressBar.Visible = true;
                    videoPictureBox.ImageLocation = string.Format(CultureInfo.InvariantCulture, "http://i3.ytimg.com/vi/{0}/default.jpg", YouTubeDownloader.GetVideoIdFromUrl(urlTextBox.Text));
                    backgroundWorker.RunWorkerAsync(urlTextBox.Text);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(this, ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DownloadButton_Click(object sender, EventArgs e) {
            try {
                VideoQuality tempItem = qualityComboBox.SelectedItem as VideoQuality;
                saveFileDialog.Filter = String.Format(CultureInfo.InvariantCulture, "{0} Files|*.{1}", tempItem.Extension.ToUpperInvariant(), tempItem.Extension.ToLowerInvariant());
                saveFileDialog.FileName = FormatTitle(tempItem.VideoTitle);

                if (DialogResult.OK != saveFileDialog.ShowDialog(this)) {
                    return;
                }
                new DownloadDialog(tempItem.DownloadUrl, saveFileDialog.FileName).Show(this);
            }
            catch (Exception ex) {
                MessageBox.Show(this, ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CopyUrlButton_Click(object sender, EventArgs e) {
            try {
                Clipboard.SetText((qualityComboBox.SelectedItem as VideoQuality).DownloadUrl);
                MessageBox.Show(this, "URL copied to clipboard", "YouTube Downloader", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(this, ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UrlTextBox_TextChanged(object sender, EventArgs e) {
            getVideoButton.Enabled = !String.IsNullOrEmpty(urlTextBox.Text);

            videoPictureBox.Image = null;
            qualityComboBox.DataSource = null;
            qualityComboBox.Enabled = false;
            nameTextLabel.Text = "--";
        }

        private void QualityComboBox_EnabledChanged(object sender, EventArgs e) {
            downloadButton.Enabled = qualityComboBox.Enabled;
            copyUrlButton.Enabled = qualityComboBox.Enabled;
        }

        private void AboutButton_Click(object sender, EventArgs e) {
            new AboutDialog().ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void DrawVideoLength(string length) {
            videoPictureBox.Refresh();

            Graphics graphics = videoPictureBox.CreateGraphics();
            Font mFont = new Font(this.Font.Name, 10.0F, FontStyle.Bold, GraphicsUnit.Point);
            SizeF mSize = graphics.MeasureString(length, mFont);
            Rectangle mRec = new Rectangle((int)(videoPictureBox.Width - mSize.Width - 6),
                                           (int)(videoPictureBox.Height - mSize.Height - 6),
                                           (int)(mSize.Width + 2),
                                           (int)(mSize.Height + 2));

            graphics.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.Black)), mRec);
            graphics.DrawString(length, mFont, new SolidBrush(Color.Gainsboro), new PointF((videoPictureBox.Width - mSize.Width - 5),
                                                                                (videoPictureBox.Height - mSize.Height - 5)));
            graphics.Dispose();
        }

        public static string FormatTitle(string title) {
            return title.Replace(@"\", "").Replace("&#39;", "'").Replace("&quot;", "'").Replace("&lt;", "(").Replace("&gt;", ")").Replace("+", " ").Replace(":", "-");
        }
    }
}
