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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "BvForm";
        }

        #endregion

        public ActionMetaItem GetLastExecutedAction()
        {
            return null; //TODO если на форме есть какие-то ActionPanel, то можно от них получать сведения о последнем действии
        }
    }
}