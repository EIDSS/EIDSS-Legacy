namespace EIDSS.RAM.Layout
{
    partial class LayoutDetail
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutDetail));
            this.grcLayout = new DevExpress.XtraEditors.GroupControl();
            this.cmdCopy = new DevExpress.XtraEditors.SimpleButton();
            this.cmdNew = new DevExpress.XtraEditors.SimpleButton();
            this.cmdSave = new DevExpress.XtraEditors.SimpleButton();
            this.cmdDelete = new DevExpress.XtraEditors.SimpleButton();
            this.cmdCancelChanges = new DevExpress.XtraEditors.SimpleButton();
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageGrid = new DevExpress.XtraTab.XtraTabPage();
            this.pivotForm = new EIDSS.RAM.Layout.PivotForm();
            this.tabPageReport = new DevExpress.XtraTab.XtraTabPage();
            this.grcReport = new DevExpress.XtraEditors.GroupControl();
            this.pivotReportForm = new EIDSS.RAM.Layout.PivotReportForm();
            this.tabPageChart = new DevExpress.XtraTab.XtraTabPage();
            this.chartForm = new EIDSS.RAM.Layout.ChartForm();
            this.tabPageMap = new DevExpress.XtraTab.XtraTabPage();
            this.mapForm = new EIDSS.RAM.Layout.MapForm();
            this.timerUpdateChart = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grcLayout)).BeginInit();
            this.grcLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageGrid.SuspendLayout();
            this.tabPageReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcReport)).BeginInit();
            this.grcReport.SuspendLayout();
            this.tabPageChart.SuspendLayout();
            this.tabPageMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // grcLayout
            // 
            this.grcLayout.Appearance.Options.UseFont = true;
            this.grcLayout.AppearanceCaption.Options.UseFont = true;
            this.grcLayout.Controls.Add(this.cmdCopy);
            this.grcLayout.Controls.Add(this.cmdNew);
            this.grcLayout.Controls.Add(this.cmdSave);
            this.grcLayout.Controls.Add(this.cmdDelete);
            this.grcLayout.Controls.Add(this.cmdCancelChanges);
            this.grcLayout.Controls.Add(this.tabControl);
            resources.ApplyResources(this.grcLayout, "grcLayout");
            this.grcLayout.MinimumSize = new System.Drawing.Size(500, 300);
            this.grcLayout.Name = "grcLayout";
            this.grcLayout.ShowCaption = false;
            // 
            // cmdCopy
            // 
            resources.ApplyResources(this.cmdCopy, "cmdCopy");
            this.cmdCopy.Image = global::EIDSS.RAM.Properties.Resources.query_copy;
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
            // 
            // cmdNew
            // 
            resources.ApplyResources(this.cmdNew, "cmdNew");
            this.cmdNew.Image = global::EIDSS.RAM.Properties.Resources.layout_new;
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdSave
            // 
            resources.ApplyResources(this.cmdSave, "cmdSave");
            this.cmdSave.Image = global::EIDSS.RAM.Properties.Resources.layout_save_1;
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdDelete
            // 
            resources.ApplyResources(this.cmdDelete, "cmdDelete");
            this.cmdDelete.Image = global::EIDSS.RAM.Properties.Resources.layout_deleted;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdCancelChanges
            // 
            resources.ApplyResources(this.cmdCancelChanges, "cmdCancelChanges");
            this.cmdCancelChanges.Image = global::EIDSS.RAM.Properties.Resources.layout_undo3;
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
            this.tabControl.SelectedTabPage = this.tabPageGrid;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageGrid,
            this.tabPageReport,
            this.tabPageChart,
            this.tabPageMap});
            this.tabControl.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.tabControl_SelectedPageChanging);
            // 
            // tabPageGrid
            // 
            this.tabPageGrid.Appearance.Header.Options.UseFont = true;
            this.tabPageGrid.Appearance.HeaderActive.Options.UseFont = true;
            this.tabPageGrid.Appearance.HeaderDisabled.Options.UseFont = true;
            this.tabPageGrid.Appearance.HeaderHotTracked.Options.UseFont = true;
            this.tabPageGrid.Appearance.PageClient.Options.UseFont = true;
            this.tabPageGrid.Controls.Add(this.pivotForm);
            resources.ApplyResources(this.tabPageGrid, "tabPageGrid");
            this.tabPageGrid.Name = "tabPageGrid";
            // 
            // pivotForm
            // 
            resources.ApplyResources(this.pivotForm, "pivotForm");
            this.pivotForm.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.pivotForm.FormID = null;
            this.pivotForm.HelpTopicID = null;
            this.pivotForm.IsStatusReadOnly = false;
            this.pivotForm.KeyFieldName = null;
            this.pivotForm.MinimumSize = new System.Drawing.Size(500, 300);
            this.pivotForm.MultiSelect = false;
            this.pivotForm.Name = "pivotForm";
            this.pivotForm.ObjectName = null;
            this.pivotForm.Status = bv.common.win.FormStatus.Draft;
            this.pivotForm.TableName = null;
            // 
            // tabPageReport
            // 
            this.tabPageReport.Appearance.Header.Options.UseFont = true;
            this.tabPageReport.Appearance.HeaderActive.Options.UseFont = true;
            this.tabPageReport.Appearance.HeaderDisabled.Options.UseFont = true;
            this.tabPageReport.Appearance.HeaderHotTracked.Options.UseFont = true;
            this.tabPageReport.Appearance.PageClient.Options.UseFont = true;
            this.tabPageReport.Controls.Add(this.grcReport);
            this.tabPageReport.Name = "tabPageReport";
            resources.ApplyResources(this.tabPageReport, "tabPageReport");
            // 
            // grcReport
            // 
            this.grcReport.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcReport.Controls.Add(this.pivotReportForm);
            resources.ApplyResources(this.grcReport, "grcReport");
            this.grcReport.Name = "grcReport";
            // 
            // pivotReportForm
            // 
            resources.ApplyResources(this.pivotReportForm, "pivotReportForm");
            this.pivotReportForm.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.pivotReportForm.FilterText = "";
            this.pivotReportForm.FormID = null;
            this.pivotReportForm.HelpTopicID = null;
            this.pivotReportForm.IsStatusReadOnly = false;
            this.pivotReportForm.KeyFieldName = null;
            this.pivotReportForm.MultiSelect = false;
            this.pivotReportForm.Name = "pivotReportForm";
            this.pivotReportForm.ObjectName = null;
            this.pivotReportForm.PivotName = "";
            this.pivotReportForm.Status = bv.common.win.FormStatus.Draft;
            this.pivotReportForm.TableName = null;
            this.pivotReportForm.UseParentDataset = true;
            // 
            // tabPageChart
            // 
            this.tabPageChart.Appearance.Header.Options.UseFont = true;
            this.tabPageChart.Appearance.HeaderActive.Options.UseFont = true;
            this.tabPageChart.Appearance.HeaderDisabled.Options.UseFont = true;
            this.tabPageChart.Appearance.HeaderHotTracked.Options.UseFont = true;
            this.tabPageChart.Appearance.PageClient.Options.UseFont = true;
            this.tabPageChart.Controls.Add(this.chartForm);
            this.tabPageChart.Name = "tabPageChart";
            resources.ApplyResources(this.tabPageChart, "tabPageChart");
            // 
            // chartForm
            // 
            resources.ApplyResources(this.chartForm, "chartForm");
            this.chartForm.ChartName = "";
            this.chartForm.DataSource = null;
            this.chartForm.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.chartForm.FilterText = "";
            this.chartForm.FormID = null;
            this.chartForm.HelpTopicID = null;
            this.chartForm.IsStatusReadOnly = false;
            this.chartForm.KeyFieldName = null;
            this.chartForm.MinimumSize = new System.Drawing.Size(500, 300);
            this.chartForm.MultiSelect = false;
            this.chartForm.Name = "chartForm";
            this.chartForm.ObjectName = null;
            this.chartForm.Status = bv.common.win.FormStatus.Draft;
            this.chartForm.TableName = null;
            this.chartForm.UseParentDataset = true;
            // 
            // tabPageMap
            // 
            this.tabPageMap.Appearance.Header.Options.UseFont = true;
            this.tabPageMap.Appearance.HeaderActive.Options.UseFont = true;
            this.tabPageMap.Appearance.HeaderDisabled.Options.UseFont = true;
            this.tabPageMap.Appearance.HeaderHotTracked.Options.UseFont = true;
            this.tabPageMap.Appearance.PageClient.Options.UseFont = true;
            this.tabPageMap.Controls.Add(this.mapForm);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.PageEnabled = false;
            resources.ApplyResources(this.tabPageMap, "tabPageMap");
            // 
            // mapForm
            // 
            resources.ApplyResources(this.mapForm, "mapForm");
            this.mapForm.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.mapForm.FilterText = "";
            this.mapForm.FormID = null;
            this.mapForm.HelpTopicID = null;
            this.mapForm.IsStatusReadOnly = false;
            this.mapForm.KeyFieldName = null;
            this.mapForm.MapName = "";
            this.mapForm.MinimumSize = new System.Drawing.Size(500, 300);
            this.mapForm.MultiSelect = false;
            this.mapForm.Name = "mapForm";
            this.mapForm.ObjectName = null;
            this.mapForm.Status = bv.common.win.FormStatus.Draft;
            this.mapForm.TableName = null;
            this.mapForm.UseParentDataset = true;
            // 
            // timerUpdateChart
            // 
            this.timerUpdateChart.Tick += new System.EventHandler(this.timerUpdateChart_Tick);
            // 
            // LayoutDetail
            // 
            this.Controls.Add(this.grcLayout);
            this.HelpTopicID = "Predefined_Layouts_List";
            this.Name = "LayoutDetail";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.grcLayout)).EndInit();
            this.grcLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageGrid.ResumeLayout(false);
            this.tabPageReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcReport)).EndInit();
            this.grcReport.ResumeLayout(false);
            this.tabPageChart.ResumeLayout(false);
            this.tabPageMap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcLayout;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage tabPageGrid;
        private PivotForm pivotForm;
        private DevExpress.XtraTab.XtraTabPage tabPageReport;
        private PivotReportForm pivotReportForm;
        private DevExpress.XtraTab.XtraTabPage tabPageChart;
        private ChartForm chartForm;
        private DevExpress.XtraTab.XtraTabPage tabPageMap;
        private MapForm mapForm;
        protected DevExpress.XtraEditors.SimpleButton cmdNew;
        protected DevExpress.XtraEditors.SimpleButton cmdSave;
        protected DevExpress.XtraEditors.SimpleButton cmdDelete;
        protected internal DevExpress.XtraEditors.SimpleButton cmdCancelChanges;
        protected internal DevExpress.XtraEditors.SimpleButton cmdCopy;
        private System.Windows.Forms.Timer timerUpdateChart;
        private DevExpress.XtraEditors.GroupControl grcReport;
    }
}