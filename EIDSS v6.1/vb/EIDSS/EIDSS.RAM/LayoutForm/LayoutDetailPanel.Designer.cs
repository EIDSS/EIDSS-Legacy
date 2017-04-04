
using eidss.avr.ChartForm;

using eidss.avr.MapForm;

using eidss.avr.PivotForm;

namespace eidss.avr.LayoutForm
{
    partial class LayoutDetailPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutDetailPanel));
            this.grcLayout = new DevExpress.XtraEditors.GroupControl();
            this.cmdClose = new DevExpress.XtraEditors.SimpleButton();
            this.cmdCopy = new DevExpress.XtraEditors.SimpleButton();
            this.cmdNew = new DevExpress.XtraEditors.SimpleButton();
            this.cmdSave = new DevExpress.XtraEditors.SimpleButton();
            this.cmdDelete = new DevExpress.XtraEditors.SimpleButton();
            this.cmdCancelChanges = new DevExpress.XtraEditors.SimpleButton();
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.tabPagePivotGrid = new DevExpress.XtraTab.XtraTabPage();
            this.pivotForm = new eidss.avr.PivotForm.PivotDetailPanel();
            this.tabPagePivotInfo = new DevExpress.XtraTab.XtraTabPage();
            this.pivotInfo = new eidss.avr.PivotForm.PivotInfoDetailPanel();
            this.tabPageView = new DevExpress.XtraTab.XtraTabPage();
            this.viewForm = new eidss.avr.ViewForm.ViewDetailPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grcLayout)).BeginInit();
            this.grcLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPagePivotGrid.SuspendLayout();
            this.tabPagePivotInfo.SuspendLayout();
            this.tabPageView.SuspendLayout();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(LayoutDetailPanel), out resources);
            // Form Is Localizable: True
            // 
            // grcLayout
            // 
            this.grcLayout.Appearance.Options.UseFont = true;
            this.grcLayout.AppearanceCaption.Options.UseFont = true;
            this.grcLayout.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcLayout.Controls.Add(this.cmdClose);
            this.grcLayout.Controls.Add(this.cmdCopy);
            this.grcLayout.Controls.Add(this.cmdNew);
            this.grcLayout.Controls.Add(this.cmdSave);
            this.grcLayout.Controls.Add(this.cmdDelete);
            this.grcLayout.Controls.Add(this.cmdCancelChanges);
            this.grcLayout.Controls.Add(this.tabControl);
            resources.ApplyResources(this.grcLayout, "grcLayout");
            this.grcLayout.Name = "grcLayout";
            this.grcLayout.ShowCaption = false;
            // 
            // cmdClose
            // 
            resources.ApplyResources(this.cmdClose, "cmdClose");
            this.cmdClose.Image = global::eidss.avr.Properties.Resources.Close;
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdCopy
            // 
            resources.ApplyResources(this.cmdCopy, "cmdCopy");
            this.cmdCopy.Image = global::eidss.avr.Properties.Resources.copy;
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
            // 
            // cmdNew
            // 
            resources.ApplyResources(this.cmdNew, "cmdNew");
            this.cmdNew.Image = global::eidss.avr.Properties.Resources.layout_create_16x16;
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdSave
            // 
            resources.ApplyResources(this.cmdSave, "cmdSave");
            this.cmdSave.Image = global::eidss.avr.Properties.Resources.lauout_save_16x16;
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdDelete
            // 
            resources.ApplyResources(this.cmdDelete, "cmdDelete");
            this.cmdDelete.Image = global::eidss.avr.Properties.Resources.layout_delete16x16;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdCancelChanges
            // 
            resources.ApplyResources(this.cmdCancelChanges, "cmdCancelChanges");
            this.cmdCancelChanges.Image = global::eidss.avr.Properties.Resources.layout_cancel_16x16;
            this.cmdCancelChanges.Name = "cmdCancelChanges";
            this.cmdCancelChanges.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Appearance.Options.UseFont = true;
            this.tabControl.AppearancePage.Header.Options.UseFont = true;
            this.tabControl.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabControl.AppearancePage.HeaderDisabled.Options.UseFont = true;
            this.tabControl.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            this.tabControl.AppearancePage.PageClient.Options.UseFont = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.tabPageView;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPagePivotInfo,
            this.tabPagePivotGrid,
            this.tabPageView});
            this.tabControl.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.tabControl_SelectedPageChanging);
            // 
            // tabPagePivotGrid
            // 
            this.tabPagePivotGrid.Appearance.Header.Options.UseFont = true;
            this.tabPagePivotGrid.Appearance.HeaderActive.Options.UseFont = true;
            this.tabPagePivotGrid.Appearance.HeaderDisabled.Options.UseFont = true;
            this.tabPagePivotGrid.Appearance.HeaderHotTracked.Options.UseFont = true;
            this.tabPagePivotGrid.Appearance.PageClient.Options.UseFont = true;
            this.tabPagePivotGrid.Controls.Add(this.pivotForm);
            resources.ApplyResources(this.tabPagePivotGrid, "tabPagePivotGrid");
            this.tabPagePivotGrid.Name = "tabPagePivotGrid";
            // 
            // pivotForm
            // 
            resources.ApplyResources(this.pivotForm, "pivotForm");
            this.pivotForm.FormID = null;
            this.pivotForm.HelpTopicID = null;
            this.pivotForm.KeyFieldName = null;
            this.pivotForm.MultiSelect = false;
            this.pivotForm.Name = "pivotForm";
            this.pivotForm.ObjectName = null;
            this.pivotForm.TableName = null;
            // 
            // tabPagePivotInfo
            // 
            this.tabPagePivotInfo.Controls.Add(this.pivotInfo);
            this.tabPagePivotInfo.Name = "tabPagePivotInfo";
            resources.ApplyResources(this.tabPagePivotInfo, "tabPagePivotInfo");
            // 
            // pivotInfo
            // 
            this.pivotInfo.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.pivotInfo, "pivotInfo");
            this.pivotInfo.FormID = null;
            this.pivotInfo.HelpTopicID = "AVR_Pivot_Table";
            this.pivotInfo.KeyFieldName = null;
            this.pivotInfo.MultiSelect = false;
            this.pivotInfo.Name = "pivotInfo";
            this.pivotInfo.ObjectName = null;
            this.pivotInfo.TableName = null;
            // 
            // tabPageView
            // 
            this.tabPageView.Controls.Add(this.viewForm);
            this.tabPageView.Name = "tabPageView";
            resources.ApplyResources(this.tabPageView, "tabPageView");
            // 
            // viewForm
            // 
            resources.ApplyResources(this.viewForm, "viewForm");
            this.viewForm.FormID = null;
            this.viewForm.HelpTopicID = null;
            this.viewForm.KeyFieldName = null;
            this.viewForm.MultiSelect = false;
            this.viewForm.Name = "viewForm";
            this.viewForm.ObjectName = null;
            this.viewForm.TableName = null;
            // 
            // LayoutDetailPanel
            // 
            this.Controls.Add(this.grcLayout);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.HelpTopicID = "Predefined_Layouts_List";
            this.Name = "LayoutDetailPanel";
            resources.ApplyResources(this, "$this");
            this.Status = bv.common.win.FormStatus.Draft;
            ((System.ComponentModel.ISupportInitialize)(this.grcLayout)).EndInit();
            this.grcLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPagePivotGrid.ResumeLayout(false);
            this.tabPagePivotInfo.ResumeLayout(false);
            this.tabPageView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcLayout;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage tabPagePivotGrid;
        private PivotDetailPanel pivotForm;
        
        
        
        
        
        protected DevExpress.XtraEditors.SimpleButton cmdNew;
        protected DevExpress.XtraEditors.SimpleButton cmdSave;
        protected DevExpress.XtraEditors.SimpleButton cmdDelete;
        protected internal DevExpress.XtraEditors.SimpleButton cmdCancelChanges;
        protected internal DevExpress.XtraEditors.SimpleButton cmdCopy;
        
        private DevExpress.XtraTab.XtraTabPage tabPagePivotInfo;
        private DevExpress.XtraTab.XtraTabPage tabPageView;
        private PivotInfoDetailPanel pivotInfo;
        private ViewForm.ViewDetailPanel viewForm;
        protected DevExpress.XtraEditors.SimpleButton cmdClose;
    }
}