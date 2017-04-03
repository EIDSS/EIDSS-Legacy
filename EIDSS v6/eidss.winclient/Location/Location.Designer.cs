namespace eidss.winclient.Location
{
    partial class Location
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Location));
            this.lbRelLongitude = new System.Windows.Forms.Label();
            this.seLongitude = new DevExpress.XtraEditors.SpinEdit();
            this.btnMAP = new DevExpress.XtraEditors.SimpleButton();
            this.seLatitude = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.seLongitude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLatitude.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(Location), out resources);
            // Form Is Localizable: True
            // 
            // lbRelLongitude
            // 
            resources.ApplyResources(this.lbRelLongitude, "lbRelLongitude");
            this.lbRelLongitude.Name = "lbRelLongitude";
            // 
            // seLongitude
            // 
            resources.ApplyResources(this.seLongitude, "seLongitude");
            this.seLongitude.Name = "seLongitude";
            this.seLongitude.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seLongitude.Properties.DisplayFormat.FormatString = "f5";
            this.seLongitude.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seLongitude.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seLongitude.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.seLongitude.Properties.Mask.EditMask = resources.GetString("seLongitude.Properties.Mask.EditMask");
            this.seLongitude.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("seLongitude.Properties.Mask.UseMaskAsDisplayFormat")));
            this.seLongitude.Properties.MaxValue = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.seLongitude.Properties.MinValue = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.seLongitude.Properties.ValidateOnEnterKey = true;
            // 
            // btnMAP
            // 
            resources.ApplyResources(this.btnMAP, "btnMAP");
            this.btnMAP.Image = ((System.Drawing.Image)(resources.GetObject("btnMAP.Image")));
            this.btnMAP.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnMAP.Name = "btnMAP";
            this.btnMAP.Click += new System.EventHandler(this.btnMAP_Click);
            // 
            // seLatitude
            // 
            resources.ApplyResources(this.seLatitude, "seLatitude");
            this.seLatitude.Name = "seLatitude";
            this.seLatitude.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seLatitude.Properties.DisplayFormat.FormatString = "f5";
            this.seLatitude.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seLatitude.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seLatitude.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.seLatitude.Properties.Mask.EditMask = resources.GetString("seLatitude.Properties.Mask.EditMask");
            this.seLatitude.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("seLatitude.Properties.Mask.UseMaskAsDisplayFormat")));
            this.seLatitude.Properties.MaxValue = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.seLatitude.Properties.MinValue = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            // 
            // Location
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.seLatitude);
            this.Controls.Add(this.seLongitude);
            this.Controls.Add(this.btnMAP);
            this.Controls.Add(this.lbRelLongitude);
            this.Name = "Location";
            ((System.ComponentModel.ISupportInitialize)(this.seLongitude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLatitude.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lbRelLongitude;
        internal DevExpress.XtraEditors.SpinEdit seLongitude;
        internal DevExpress.XtraEditors.SimpleButton btnMAP;
        internal DevExpress.XtraEditors.SpinEdit seLatitude;
    }
}
