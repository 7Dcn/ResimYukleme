﻿namespace Istagram
{
    partial class frmProfilePage
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
            this.btnBack = new System.Windows.Forms.Button();
            this.cmbMenu = new System.Windows.Forms.ComboBox();
            this.flwProfilePageImages = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(23, 23);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // cmbMenu
            // 
            this.cmbMenu.BackColor = System.Drawing.SystemColors.Control;
            this.cmbMenu.FormattingEnabled = true;
            this.cmbMenu.Location = new System.Drawing.Point(251, 12);
            this.cmbMenu.Name = "cmbMenu";
            this.cmbMenu.Size = new System.Drawing.Size(121, 21);
            this.cmbMenu.TabIndex = 1;
            this.cmbMenu.SelectedIndexChanged += new System.EventHandler(this.cmbMenu_SelectedIndexChanged);
            // 
            // flwProfilePageImages
            // 
            this.flwProfilePageImages.AutoScroll = true;
            this.flwProfilePageImages.Location = new System.Drawing.Point(15, 53);
            this.flwProfilePageImages.Name = "flwProfilePageImages";
            this.flwProfilePageImages.Size = new System.Drawing.Size(357, 583);
            this.flwProfilePageImages.TabIndex = 2;
            // 
            // frmProfilePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 681);
            this.Controls.Add(this.flwProfilePageImages);
            this.Controls.Add(this.cmbMenu);
            this.Controls.Add(this.btnBack);
            this.Name = "frmProfilePage";
            this.Text = "frmProfilePage";
            this.Load += new System.EventHandler(this.frmProfilePage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cmbMenu;
        private System.Windows.Forms.FlowLayoutPanel flwProfilePageImages;
    }
}