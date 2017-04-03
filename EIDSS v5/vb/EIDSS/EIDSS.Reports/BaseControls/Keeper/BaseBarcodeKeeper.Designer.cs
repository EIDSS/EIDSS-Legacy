

using DevExpress.XtraEditors;

namespace EIDSS.Reports.BaseControls.Keeper
{
    partial class BaseBarcodeKeeper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseBarcodeKeeper));
            this.grcHeader = new DevExpress.XtraEditors.GroupControl();
            this.lblCopies = new System.Windows.Forms.Label();
            this.numCopies = new DevExpress.XtraEditors.SpinEdit();
            this.numQuantity = new DevExpress.XtraEditors.SpinEdit();
            this.cbTemplateTypes = new DevExpress.XtraEditors.LookUpEdit();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblTemplateType = new System.Windows.Forms.Label();
            this.reportView1 = new EIDSS.Reports.BaseControls.ReportView();
            ((System.ComponentModel.ISupportInitialize)(this.grcHeader)).BeginInit();
            this.grcHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCopies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTemplateTypes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grcHeader
            // 
            this.grcHeader.Controls.Add(this.lblCopies);
            this.grcHeader.Controls.Add(this.numCopies);
            this.grcHeader.Controls.Add(this.numQuantity);
            this.grcHeader.Controls.Add(this.cbTemplateTypes);
            this.grcHeader.Controls.Add(this.lblQuantity);
            this.grcHeader.Controls.Add(this.lblTemplateType);
            resources.ApplyResources(this.grcHeader, "grcHeader");
            this.grcHeader.Name = "grcHeader";
            // 
            // lblCopies
            // 
            resources.ApplyResources(this.lblCopies, "lblCopies");
            this.lblCopies.Name = "lblCopies";
            // 
            // numCopies
            // 
            resources.ApplyResources(this.numCopies, "numCopies");
            this.numCopies.Name = "numCopies";
            this.numCopies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.numCopies.Properties.IsFloatValue = false;
            this.numCopies.Properties.Mask.EditMask = resources.GetString("numCopies.Properties.Mask.EditMask");
            this.numCopies.Properties.MaxValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numCopies.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numQuantity
            // 
            resources.ApplyResources(this.numQuantity, "numQuantity");
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.numQuantity.Properties.IsFloatValue = false;
            this.numQuantity.Properties.Mask.EditMask = resources.GetString("numQuantity.Properties.Mask.EditMask");
            this.numQuantity.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numQuantity.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.EditValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            // 
            // cbTemplateTypes
            // 
            resources.ApplyResources(this.cbTemplateTypes, "cbTemplateTypes");
            this.cbTemplateTypes.Name = "cbTemplateTypes";
            this.cbTemplateTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbTemplateTypes.Properties.Buttons"))))});
            this.cbTemplateTypes.Properties.NullText = resources.GetString("cbTemplateTypes.Properties.NullText");
            this.cbTemplateTypes.EditValueChanged += new System.EventHandler(this.cbTemplateTypes_EditValueChanged);
            // 
            // lblQuantity
            // 
            resources.ApplyResources(this.lblQuantity, "lblQuantity");
            this.lblQuantity.Name = "lblQuantity";
            // 
            // lblTemplateType
            // 
            resources.ApplyResources(this.lblTemplateType, "lblTemplateType");
            this.lblTemplateType.Name = "lblTemplateType";
            // 
            // reportView1
            // 
            resources.ApplyResources(this.reportView1, "reportView1");
            this.reportView1.IsBarcode = true;
            this.reportView1.Name = "reportView1";
            this.reportView1.Report = null;
            // 
            // BaseBarcodeKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportView1);
            this.Controls.Add(this.grcHeader);
            this.MinimumSize = new System.Drawing.Size(320, 200);
            this.Name = "BaseBarcodeKeeper";
            ((System.ComponentModel.ISupportInitialize)(this.grcHeader)).EndInit();
            this.grcHeader.ResumeLayout(false);
            this.grcHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCopies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTemplateTypes.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupControl grcHeader;
        private ReportView reportView1;
        private System.Windows.Forms.Label lblTemplateType;
        private System.Windows.Forms.Label lblQuantity;
        private DevExpress.XtraEditors.LookUpEdit cbTemplateTypes;
        private SpinEdit numQuantity;
        private System.Windows.Forms.Label lblCopies;
        private SpinEdit numCopies;
    }
}
