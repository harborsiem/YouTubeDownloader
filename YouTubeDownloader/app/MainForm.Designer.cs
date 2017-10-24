namespace YouTubeDownloader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.topPanel = new System.Windows.Forms.Panel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.urlHeaderLabel = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.pasteButton = new System.Windows.Forms.Button();
            this.getVideoButton = new System.Windows.Forms.Button();
            this.secondLayout = new System.Windows.Forms.TableLayoutPanel();
            this.firstLayout = new System.Windows.Forms.TableLayoutPanel();
            this.videoPictureBox = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextLabel = new System.Windows.Forms.Label();
            this.qualityLabel = new System.Windows.Forms.Label();
            this.qualityComboBox = new System.Windows.Forms.ComboBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.copyUrlButton = new System.Windows.Forms.Button();
            this.middleLayout = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.aboutButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.bottomLayout = new System.Windows.Forms.TableLayoutPanel();
            this.dialogLayout = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.secondLayout.SuspendLayout();
            this.firstLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoPictureBox)).BeginInit();
            this.middleLayout.SuspendLayout();
            this.bottomLayout.SuspendLayout();
            this.dialogLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Red;
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(447, 4);
            this.topPanel.TabIndex = 3;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logoPictureBox.Image = global::YouTubeDownloader.Properties.Resources.App_Logo;
            this.logoPictureBox.Location = new System.Drawing.Point(0, 2);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(90, 90);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logoPictureBox.TabIndex = 3;
            this.logoPictureBox.TabStop = false;
            // 
            // urlHeaderLabel
            // 
            this.urlHeaderLabel.AutoSize = true;
            this.secondLayout.SetColumnSpan(this.urlHeaderLabel, 4);
            this.urlHeaderLabel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.urlHeaderLabel.Location = new System.Drawing.Point(9, 9);
            this.urlHeaderLabel.Margin = new System.Windows.Forms.Padding(3);
            this.urlHeaderLabel.Name = "urlHeaderLabel";
            this.urlHeaderLabel.Size = new System.Drawing.Size(113, 19);
            this.urlHeaderLabel.TabIndex = 0;
            this.urlHeaderLabel.Text = "YouTube URL:";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secondLayout.SetColumnSpan(this.urlTextBox, 4);
            this.urlTextBox.Location = new System.Drawing.Point(9, 34);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(309, 20);
            this.urlTextBox.TabIndex = 1;
            // 
            // pasteButton
            // 
            this.pasteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pasteButton.AutoSize = true;
            this.pasteButton.Enabled = false;
            this.pasteButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.pasteButton.Location = new System.Drawing.Point(162, 60);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(75, 23);
            this.pasteButton.TabIndex = 2;
            this.pasteButton.Text = "Paste";
            this.pasteButton.UseVisualStyleBackColor = true;
            // 
            // getVideoButton
            // 
            this.getVideoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.getVideoButton.AutoSize = true;
            this.getVideoButton.Enabled = false;
            this.getVideoButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.getVideoButton.Location = new System.Drawing.Point(243, 60);
            this.getVideoButton.Name = "getVideoButton";
            this.getVideoButton.Size = new System.Drawing.Size(75, 23);
            this.getVideoButton.TabIndex = 3;
            this.getVideoButton.Text = "Get Video";
            this.getVideoButton.UseVisualStyleBackColor = true;
            // 
            // secondLayout
            // 
            this.secondLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secondLayout.AutoSize = true;
            this.secondLayout.BackColor = System.Drawing.Color.WhiteSmoke;
            this.secondLayout.ColumnCount = 4;
            this.secondLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.secondLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.secondLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.secondLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.secondLayout.Controls.Add(this.urlHeaderLabel, 0, 0);
            this.secondLayout.Controls.Add(this.urlTextBox, 0, 1);
            this.secondLayout.Controls.Add(this.pasteButton, 2, 2);
            this.secondLayout.Controls.Add(this.getVideoButton, 3, 2);
            this.secondLayout.Location = new System.Drawing.Point(96, 0);
            this.secondLayout.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.secondLayout.Name = "secondLayout";
            this.secondLayout.Padding = new System.Windows.Forms.Padding(6);
            this.secondLayout.RowCount = 3;
            this.secondLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.secondLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.secondLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.secondLayout.Size = new System.Drawing.Size(327, 92);
            this.secondLayout.TabIndex = 0;
            // 
            // firstLayout
            // 
            this.firstLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstLayout.AutoSize = true;
            this.firstLayout.BackColor = System.Drawing.Color.White;
            this.firstLayout.ColumnCount = 2;
            this.firstLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.firstLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.firstLayout.Controls.Add(this.logoPictureBox, 0, 0);
            this.firstLayout.Controls.Add(this.secondLayout, 1, 0);
            this.firstLayout.Location = new System.Drawing.Point(12, 16);
            this.firstLayout.Margin = new System.Windows.Forms.Padding(12);
            this.firstLayout.Name = "firstLayout";
            this.firstLayout.RowCount = 1;
            this.firstLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.firstLayout.Size = new System.Drawing.Size(423, 92);
            this.firstLayout.TabIndex = 0;
            // 
            // videoPictureBox
            // 
            this.videoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.videoPictureBox.BackColor = System.Drawing.Color.Gainsboro;
            this.videoPictureBox.ErrorImage = global::YouTubeDownloader.Properties.Resources.Image_Error;
            this.videoPictureBox.InitialImage = global::YouTubeDownloader.Properties.Resources.Image_Wait;
            this.videoPictureBox.Location = new System.Drawing.Point(9, 9);
            this.videoPictureBox.Name = "videoPictureBox";
            this.middleLayout.SetRowSpan(this.videoPictureBox, 3);
            this.videoPictureBox.Size = new System.Drawing.Size(125, 93);
            this.videoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.videoPictureBox.TabIndex = 11;
            this.videoPictureBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoEllipsis = true;
            this.nameLabel.AutoSize = true;
            this.nameLabel.ForeColor = System.Drawing.Color.DimGray;
            this.nameLabel.Location = new System.Drawing.Point(140, 21);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // nameTextLabel
            // 
            this.nameTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.middleLayout.SetColumnSpan(this.nameTextLabel, 2);
            this.nameTextLabel.Location = new System.Drawing.Point(188, 6);
            this.nameTextLabel.Name = "nameTextLabel";
            this.nameTextLabel.Size = new System.Drawing.Size(226, 43);
            this.nameTextLabel.TabIndex = 1;
            this.nameTextLabel.Text = "--";
            this.nameTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qualityLabel
            // 
            this.qualityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.qualityLabel.AutoEllipsis = true;
            this.qualityLabel.AutoSize = true;
            this.qualityLabel.ForeColor = System.Drawing.Color.DimGray;
            this.qualityLabel.Location = new System.Drawing.Point(140, 52);
            this.qualityLabel.Margin = new System.Windows.Forms.Padding(3);
            this.qualityLabel.Name = "qualityLabel";
            this.qualityLabel.Size = new System.Drawing.Size(42, 21);
            this.qualityLabel.TabIndex = 2;
            this.qualityLabel.Text = "Quality:";
            this.qualityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qualityComboBox
            // 
            this.qualityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.middleLayout.SetColumnSpan(this.qualityComboBox, 2);
            this.qualityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qualityComboBox.Enabled = false;
            this.qualityComboBox.FormattingEnabled = true;
            this.qualityComboBox.Location = new System.Drawing.Point(188, 52);
            this.qualityComboBox.Name = "qualityComboBox";
            this.qualityComboBox.Size = new System.Drawing.Size(226, 21);
            this.qualityComboBox.TabIndex = 3;
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadButton.AutoSize = true;
            this.downloadButton.Enabled = false;
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.downloadButton.Location = new System.Drawing.Point(188, 79);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(110, 23);
            this.downloadButton.TabIndex = 4;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            // 
            // copyUrlButton
            // 
            this.copyUrlButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.copyUrlButton.AutoSize = true;
            this.copyUrlButton.Enabled = false;
            this.copyUrlButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.copyUrlButton.Location = new System.Drawing.Point(304, 79);
            this.copyUrlButton.Name = "copyUrlButton";
            this.copyUrlButton.Size = new System.Drawing.Size(110, 23);
            this.copyUrlButton.TabIndex = 5;
            this.copyUrlButton.Text = "Copy URL";
            this.copyUrlButton.UseVisualStyleBackColor = true;
            // 
            // middleLayout
            // 
            this.middleLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.middleLayout.AutoSize = true;
            this.middleLayout.BackColor = System.Drawing.Color.WhiteSmoke;
            this.middleLayout.ColumnCount = 4;
            this.middleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.middleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.middleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.middleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.middleLayout.Controls.Add(this.videoPictureBox, 0, 0);
            this.middleLayout.Controls.Add(this.nameLabel, 1, 0);
            this.middleLayout.Controls.Add(this.nameTextLabel, 2, 0);
            this.middleLayout.Controls.Add(this.qualityLabel, 1, 1);
            this.middleLayout.Controls.Add(this.qualityComboBox, 2, 1);
            this.middleLayout.Controls.Add(this.downloadButton, 2, 2);
            this.middleLayout.Controls.Add(this.copyUrlButton, 3, 2);
            this.middleLayout.Location = new System.Drawing.Point(12, 120);
            this.middleLayout.Margin = new System.Windows.Forms.Padding(12, 0, 12, 12);
            this.middleLayout.Name = "middleLayout";
            this.middleLayout.Padding = new System.Windows.Forms.Padding(6);
            this.middleLayout.RowCount = 3;
            this.middleLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.middleLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.middleLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.middleLayout.Size = new System.Drawing.Size(423, 111);
            this.middleLayout.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(12, 16);
            this.progressBar.Margin = new System.Windows.Forms.Padding(12, 16, 3, 16);
            this.progressBar.MarqueeAnimationSpeed = 50;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(189, 15);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 0;
            this.progressBar.Visible = false;
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutButton.AutoSize = true;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.aboutButton.Location = new System.Drawing.Point(279, 12);
            this.aboutButton.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(75, 23);
            this.aboutButton.TabIndex = 1;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.AutoSize = true;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.exitButton.Location = new System.Drawing.Point(360, 12);
            this.exitButton.Margin = new System.Windows.Forms.Padding(3, 12, 12, 12);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // bottomLayout
            // 
            this.bottomLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomLayout.AutoSize = true;
            this.bottomLayout.BackColor = System.Drawing.Color.Gainsboro;
            this.bottomLayout.ColumnCount = 4;
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bottomLayout.Controls.Add(this.progressBar, 0, 0);
            this.bottomLayout.Controls.Add(this.aboutButton, 2, 0);
            this.bottomLayout.Controls.Add(this.exitButton, 3, 0);
            this.bottomLayout.Location = new System.Drawing.Point(0, 243);
            this.bottomLayout.Margin = new System.Windows.Forms.Padding(0);
            this.bottomLayout.Name = "bottomLayout";
            this.bottomLayout.RowCount = 1;
            this.bottomLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bottomLayout.Size = new System.Drawing.Size(447, 47);
            this.bottomLayout.TabIndex = 2;
            // 
            // dialogLayout
            // 
            this.dialogLayout.AutoSize = true;
            this.dialogLayout.BackColor = System.Drawing.Color.White;
            this.dialogLayout.ColumnCount = 1;
            this.dialogLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.dialogLayout.Controls.Add(this.topPanel, 0, 0);
            this.dialogLayout.Controls.Add(this.firstLayout, 1, 0);
            this.dialogLayout.Controls.Add(this.middleLayout, 2, 0);
            this.dialogLayout.Controls.Add(this.bottomLayout, 3, 0);
            this.dialogLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dialogLayout.Location = new System.Drawing.Point(0, 0);
            this.dialogLayout.Name = "dialogLayout";
            this.dialogLayout.RowCount = 4;
            this.dialogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dialogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dialogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dialogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dialogLayout.Size = new System.Drawing.Size(447, 288);
            this.dialogLayout.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(447, 288);
            this.Controls.Add(this.dialogLayout);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YouTube Downloader";
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.secondLayout.ResumeLayout(false);
            this.secondLayout.PerformLayout();
            this.firstLayout.ResumeLayout(false);
            this.firstLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoPictureBox)).EndInit();
            this.middleLayout.ResumeLayout(false);
            this.middleLayout.PerformLayout();
            this.bottomLayout.ResumeLayout(false);
            this.bottomLayout.PerformLayout();
            this.dialogLayout.ResumeLayout(false);
            this.dialogLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel dialogLayout;
        private System.Windows.Forms.TableLayoutPanel firstLayout;
        private System.Windows.Forms.Button getVideoButton;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label urlHeaderLabel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TableLayoutPanel bottomLayout;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel secondLayout;
        private System.Windows.Forms.TableLayoutPanel middleLayout;
        private System.Windows.Forms.Label nameTextLabel;
        private System.Windows.Forms.Button copyUrlButton;
        private System.Windows.Forms.ComboBox qualityComboBox;
        private System.Windows.Forms.Label qualityLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.PictureBox videoPictureBox;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Panel topPanel;
    }
}