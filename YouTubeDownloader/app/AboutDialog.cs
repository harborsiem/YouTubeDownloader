﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace YouTubeDownloader {
    partial class AboutDialog : Form {

        private AboutModelView modelView;

        public AboutDialog() {
            if (!DesignMode) {
                this.Font = SystemFonts.MessageBoxFont;
            }
            InitializeComponent();
            modelView = new AboutModelView();
            this.dialogLayout.Paint += DialogLayout_Paint;
            this.titleLabel.Font = new System.Drawing.Font(this.Font.FontFamily, this.Font.SizeInPoints + 2);
            this.bottomLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.BottomLayout_Paint);
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            InitControls();
        }

        private void DialogLayout_Paint(object sender, PaintEventArgs e) {
            int y = ((this.cpolLabel.Height) / 2) + this.cpolLabel.Location.Y + 1;
            e.Graphics.DrawLine(new Pen(Color.LightGray, 1), new Point(0, y), new Point(this.cpolLabel.Left, y));
            e.Graphics.DrawLine(new Pen(Color.LightGray, 1), new Point(this.cpolLabel.Right, y), new Point(this.dialogLayout.Right, y));
        }

        private void BottomLayout_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawLine(new Pen(Color.Silver, 2), new Point(0, 1), new Point(bottomLayout.Width, 1));
        }

        private void OkButton_Click(object sender, EventArgs e) {
            modelView.Close(CloseForm);
        }

        private void CloseForm() {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            modelView.ShowProjectPage();
        }

        private void InitControls() {
            this.Text = modelView.DisplayAssemblyTitle;
            this.titleLabel.Text = modelView.AssemblyProduct;
            this.versionLabel.Text = modelView.DisplayAssemblyFileVersion;
            this.authorLabel.Text = modelView.DisplayAuthor;
            this.modifiedLabel.Text = modelView.DisplayModified;
            this.copyrightLabel.Text = modelView.AssemblyCopyright;
            //this.textBoxDescription.Text = modelView.AssemblyDescription;
        }

        //private void InitBindings() {
        //    this.DataBindings.Add(new Binding("Text", modelView, "DisplayAssemblyTitle"));
        //    this.titleLabel.DataBindings.Add(new Binding("Text", modelView, "AssemblyProduct"));
        //    this.versionLabel.DataBindings.Add(new Binding("Text", modelView, "DisplayAssemblyFileVersion"));
        //    this.authorLabel.DataBindings.Add(new Binding("Text", modelView, "DisplayAuthor"));
        //    this.modifiedLabel.DataBindings.Add(new Binding("Text", modelView, "DisplayModified"));
        //    this.copyrightLabel.DataBindings.Add(new Binding("Text", modelView, "AssemblyCopyright"));
        //}
    }
}
