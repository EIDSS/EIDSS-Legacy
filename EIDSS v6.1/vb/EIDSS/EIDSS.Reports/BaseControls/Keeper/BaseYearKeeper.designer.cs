
namespace EIDSS.Reports.BaseControls.Keeper
{
    partial class BaseYearKeeper
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseYearKeeper));
            this.label1 = new System.Windows.Forms.Label();
            this.spinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.spinEdit);
            this.pnlSettings.Controls.Add(this.label1);
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.label1, 0);
            this.pnlSettings.Controls.SetChildIndex(this.spinEdit, 0);
            // 
            // ceUseArchiveData
            // 
            resources.ApplyResources(this.ceUseArchiveData, "ceUseArchiveData");
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            // 
            // GenerateReportButton
            // 
            resources.ApplyResources(this.GenerateReportButton, "GenerateReportButton");
            
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(BaseYearKeeper), out resources);
            // Form Is Localizable: True
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // spinEdit
            // 
            resources.ApplyResources(this.spinEdit, "spinEdit");
            this.spinEdit.Name = "spinEdit";
            this.spinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit.Properties.Mask.EditMask = resources.GetString("spinEdit.Properties.Mask.EditMask");
            this.spinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("spinEdit.Properties.Mask.MaskType")));
            this.spinEdit.Properties.MaxValue = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.spinEdit.Properties.MinValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.spinEdit.EditValueChanged += new System.EventHandler(this.spinEdit_EditValueChanged);
            // 
            // BaseYearKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "BaseYearKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SpinEdit spinEdit;
    }
}