//using bv.common.Core;
using System.Data;
using System;
//using bv.common.db.Core;
//using bv.common.db;
using System.Windows.Forms;
using System.Collections;
//using bv.common.Objects;
using Microsoft.VisualBasic;
using System.Diagnostics;
using bv.winclient.Core;

//using bv.common.win;
//using bv.common.Diagnostics;
//using bv.common;
//using bv.common.win.Core;



namespace eidss.main.Autolock
{

    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class AutoLockForm : BvForm
    {
        // Inherits Form

        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.Container components = null;

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoLockForm));
            this.tbConfPass = new DevExpress.XtraEditors.TextEdit();
            this.lLockMessage = new System.Windows.Forms.Label();
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.sbLogout = new DevExpress.XtraEditors.SimpleButton();
            this.lbPassLng = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tbConfPass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tbConfPass
            // 
            resources.ApplyResources(this.tbConfPass, "tbConfPass");
            this.tbConfPass.Name = "tbConfPass";
            this.tbConfPass.Properties.PasswordChar = '*';
            this.tbConfPass.Tag = "{M}";
            // 
            // lLockMessage
            // 
            resources.ApplyResources(this.lLockMessage, "lLockMessage");
            this.lLockMessage.Name = "lLockMessage";
            // 
            // btOk
            // 
            resources.ApplyResources(this.btOk, "btOk");
            this.btOk.Name = "btOk";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // sbLogout
            // 
            resources.ApplyResources(this.sbLogout, "sbLogout");
            this.sbLogout.Name = "sbLogout";
            this.sbLogout.Click += new System.EventHandler(this.sbLogout_Click);
            // 
            // lbPassLng
            // 
            this.lbPassLng.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lbPassLng.Appearance.BackColor")));
            this.lbPassLng.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lbPassLng.Appearance.ForeColor")));
            this.lbPassLng.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.lbPassLng, "lbPassLng");
            this.lbPassLng.Name = "lbPassLng";
            // 
            // AutoLockForm
            // 
            this.AcceptButton = this.btOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbPassLng);
            this.Controls.Add(this.sbLogout);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.lLockMessage);
            this.Controls.Add(this.tbConfPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpTopicId = "Logging_on";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoLockForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoLockForm_FormClosing);
            this.Load += new System.EventHandler(this.AutoLockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbConfPass.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        internal DevExpress.XtraEditors.TextEdit tbConfPass;
        internal System.Windows.Forms.Label lLockMessage;
        internal DevExpress.XtraEditors.SimpleButton btOk;
        internal DevExpress.XtraEditors.SimpleButton sbLogout;
        internal DevExpress.XtraEditors.LabelControl lbPassLng;
    }
}

