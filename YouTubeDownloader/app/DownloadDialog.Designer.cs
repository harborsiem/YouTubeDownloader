namespace YouTubeDownloader {
    partial class DownloadDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameInfoLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusInfoLabel = new System.Windows.Forms.Label();
            this.topLayout = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bottomLayout = new System.Windows.Forms.TableLayoutPanel();
            this.dialogLayout = new System.Windows.Forms.TableLayoutPanel();
            this.topLayout.SuspendLayout();
            this.bottomLayout.SuspendLayout();
            this.dialogLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.ForeColor = System.Drawing.Color.DimGray;
            this.nameLabel.Location = new System.Drawing.Point(3, 3);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // nameInfoLabel
            // 
            this.nameInfoLabel.AutoEllipsis = true;
            this.nameInfoLabel.AutoSize = true;
            this.nameInfoLabel.Location = new System.Drawing.Point(49, 3);
            this.nameInfoLabel.Margin = new System.Windows.Forms.Padding(3);
            this.nameInfoLabel.Name = "nameInfoLabel";
            this.nameInfoLabel.Size = new System.Drawing.Size(62, 13);
            this.nameInfoLabel.TabIndex = 1;
            this.nameInfoLabel.Text = "{File Name}";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.ForeColor = System.Drawing.Color.DimGray;
            this.statusLabel.Location = new System.Drawing.Point(3, 22);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(3);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Status:";
            // 
            // statusInfoLabel
            // 
            this.statusInfoLabel.AutoEllipsis = true;
            this.statusInfoLabel.AutoSize = true;
            this.statusInfoLabel.Location = new System.Drawing.Point(49, 22);
            this.statusInfoLabel.Margin = new System.Windows.Forms.Padding(3);
            this.statusInfoLabel.Name = "statusInfoLabel";
            this.statusInfoLabel.Size = new System.Drawing.Size(45, 13);
            this.statusInfoLabel.TabIndex = 3;
            this.statusInfoLabel.Text = "{Status}";
            // 
            // topLayout
            // 
            this.topLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topLayout.AutoSize = true;
            this.topLayout.ColumnCount = 2;
            this.topLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topLayout.Controls.Add(this.nameLabel, 0, 0);
            this.topLayout.Controls.Add(this.nameInfoLabel, 1, 0);
            this.topLayout.Controls.Add(this.statusLabel, 0, 1);
            this.topLayout.Controls.Add(this.statusInfoLabel, 1, 1);
            this.topLayout.Location = new System.Drawing.Point(12, 12);
            this.topLayout.Margin = new System.Windows.Forms.Padding(12);
            this.topLayout.Name = "topLayout";
            this.topLayout.RowCount = 2;
            this.topLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topLayout.Size = new System.Drawing.Size(352, 38);
            this.topLayout.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 74);
            this.progressBar.Margin = new System.Windows.Forms.Padding(12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(352, 18);
            this.progressBar.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(208, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Pause";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSize = true;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(289, 12);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 12, 12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // bottomLayout
            // 
            this.bottomLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomLayout.AutoSize = true;
            this.bottomLayout.BackColor = System.Drawing.Color.Gainsboro;
            this.bottomLayout.ColumnCount = 3;
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bottomLayout.Controls.Add(this.button1, 1, 0);
            this.bottomLayout.Controls.Add(this.button2, 2, 0);
            this.bottomLayout.Location = new System.Drawing.Point(0, 104);
            this.bottomLayout.Margin = new System.Windows.Forms.Padding(0);
            this.bottomLayout.Name = "bottomLayout";
            this.bottomLayout.RowCount = 1;
            this.bottomLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bottomLayout.Size = new System.Drawing.Size(376, 47);
            this.bottomLayout.TabIndex = 0;
            // 
            // dialogLayout
            // 
            this.dialogLayout.AutoSize = true;
            this.dialogLayout.BackColor = System.Drawing.Color.White;
            this.dialogLayout.ColumnCount = 1;
            this.dialogLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.dialogLayout.Controls.Add(this.topLayout, 0, 0);
            this.dialogLayout.Controls.Add(this.progressBar, 1, 0);
            this.dialogLayout.Controls.Add(this.bottomLayout, 2, 0);
            this.dialogLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dialogLayout.Location = new System.Drawing.Point(0, 0);
            this.dialogLayout.Name = "dialogLayout";
            this.dialogLayout.RowCount = 3;
            this.dialogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dialogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dialogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dialogLayout.Size = new System.Drawing.Size(376, 151);
            this.dialogLayout.TabIndex = 0;
            // 
            // DownloadDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(376, 151);
            this.Controls.Add(this.dialogLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DownloadDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Downloader";
            this.topLayout.ResumeLayout(false);
            this.topLayout.PerformLayout();
            this.bottomLayout.ResumeLayout(false);
            this.bottomLayout.PerformLayout();
            this.dialogLayout.ResumeLayout(false);
            this.dialogLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel dialogLayout;
        private System.Windows.Forms.TableLayoutPanel topLayout;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label statusInfoLabel;
        private System.Windows.Forms.TableLayoutPanel bottomLayout;
        private System.Windows.Forms.Label nameInfoLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label statusLabel;
    }
}