using System;
using bv.common.Enums;
using bv.model.Model.Core;

namespace bv.winclient.Core
{
    partial class BvForm
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
            this.bvResourceManagerChanger1 = new bv.common.Resources.BvResourceManagerChanger();
            this.SuspendLayout();
            // Form Is Localizable: False
            // 
            // BvForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            if (bv.common.Configuration.BaseSettings.TranslationMode)
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            else
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "BvForm";
            this.Text = "BvForm";
            this.Load += new System.EventHandler(this.BvForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private common.Resources.BvResourceManagerChanger bvResourceManagerChanger1;
    }
}