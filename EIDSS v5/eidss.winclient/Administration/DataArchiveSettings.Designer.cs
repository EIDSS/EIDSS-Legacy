namespace eidss.winclient.Security
{
    partial class DataArchiveSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataArchiveSettings));
            this.lbSchedule = new DevExpress.XtraEditors.LabelControl();
            this.txtSchedule = new DevExpress.XtraEditors.MemoEdit();
            this.lbInterval = new DevExpress.XtraEditors.LabelControl();
            this.txtInterval = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchedule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbSchedule
            // 
            this.lbSchedule.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbSchedule.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbSchedule, "lbSchedule");
            this.lbSchedule.Name = "lbSchedule";
            // 
            // txtSchedule
            // 
            resources.ApplyResources(this.txtSchedule, "txtSchedule");
            this.txtSchedule.Name = "txtSchedule";
            // 
            // lbInterval
            // 
            this.lbInterval.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbInterval.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbInterval, "lbInterval");
            this.lbInterval.Name = "lbInterval";
            // 
            // txtInterval
            // 
            resources.ApplyResources(this.txtInterval, "txtInterval");
            this.txtInterval.Name = "txtInterval";
            // 
            // DataArchiveSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.lbInterval);
            this.Controls.Add(this.txtSchedule);
            this.Controls.Add(this.lbSchedule);
            this.Icon = global::eidss.winclient.Properties.Resources.DataArchiveSettings_Large1;
            this.Name = "DataArchiveSettings";
            ((System.ComponentModel.ISupportInitialize)(this.txtSchedule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbSchedule;
        private DevExpress.XtraEditors.MemoEdit txtSchedule;
        private DevExpress.XtraEditors.LabelControl lbInterval;
        private DevExpress.XtraEditors.TextEdit txtInterval;
    }
}
