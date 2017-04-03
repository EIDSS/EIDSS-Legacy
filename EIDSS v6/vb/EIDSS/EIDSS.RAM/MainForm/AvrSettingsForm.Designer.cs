namespace eidss.avr.MainForm
{
    partial class AvrSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvrSettingsForm));
            this.tbSettings = new DevExpress.XtraTab.XtraTabControl();
            this.tpFunction = new DevExpress.XtraTab.XtraTabPage();
            this.cbSearchObject = new DevExpress.XtraEditors.LookUpEdit();
            this.lbSearchObject = new DevExpress.XtraEditors.LabelControl();
            this.FunctionsGrid = new DevExpress.XtraGrid.GridControl();
            this.FunctionsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSearchObject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFunction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbFunction = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tpPrecision = new DevExpress.XtraTab.XtraTabPage();
            this.PrecisionGrid = new DevExpress.XtraGrid.GridControl();
            this.PrecisionView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAggregateFunction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtPrecision = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSettings)).BeginInit();
            this.tbSettings.SuspendLayout();
            this.tpFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSearchObject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FunctionsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FunctionsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFunction)).BeginInit();
            this.tpPrecision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrecisionGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecisionView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecision)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(AvrSettingsForm), out resources);
            // Form Is Localizable: True
            // 
            // tbSettings
            // 
            resources.ApplyResources(this.tbSettings, "tbSettings");
            this.tbSettings.Name = "tbSettings";
            this.tbSettings.SelectedTabPage = this.tpFunction;
            this.tbSettings.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpFunction,
            this.tpPrecision});
            // 
            // tpFunction
            // 
            this.tpFunction.Controls.Add(this.cbSearchObject);
            this.tpFunction.Controls.Add(this.lbSearchObject);
            this.tpFunction.Controls.Add(this.FunctionsGrid);
            this.tpFunction.Name = "tpFunction";
            resources.ApplyResources(this.tpFunction, "tpFunction");
            // 
            // cbSearchObject
            // 
            resources.ApplyResources(this.cbSearchObject, "cbSearchObject");
            this.cbSearchObject.Name = "cbSearchObject";
            this.cbSearchObject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbSearchObject.Properties.Buttons"))))});
            // 
            // lbSearchObject
            // 
            this.lbSearchObject.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbSearchObject, "lbSearchObject");
            this.lbSearchObject.Name = "lbSearchObject";
            // 
            // FunctionsGrid
            // 
            resources.ApplyResources(this.FunctionsGrid, "FunctionsGrid");
            this.FunctionsGrid.MainView = this.FunctionsView;
            this.FunctionsGrid.Name = "FunctionsGrid";
            this.FunctionsGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbFunction});
            this.FunctionsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.FunctionsView});
            // 
            // FunctionsView
            // 
            this.FunctionsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSearchObject,
            this.colFunction});
            this.FunctionsView.GridControl = this.FunctionsGrid;
            this.FunctionsView.Name = "FunctionsView";
            this.FunctionsView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.FunctionsView.OptionsView.ShowGroupPanel = false;
            // 
            // colSearchObject
            // 
            resources.ApplyResources(this.colSearchObject, "colSearchObject");
            this.colSearchObject.FieldName = "strFieldCaption";
            this.colSearchObject.Name = "colSearchObject";
            this.colSearchObject.OptionsColumn.AllowEdit = false;
            this.colSearchObject.OptionsColumn.ReadOnly = true;
            // 
            // colFunction
            // 
            resources.ApplyResources(this.colFunction, "colFunction");
            this.colFunction.ColumnEdit = this.cbFunction;
            this.colFunction.FieldName = "idfsDefaultAggregateFunction";
            this.colFunction.Name = "colFunction";
            // 
            // cbFunction
            // 
            resources.ApplyResources(this.cbFunction, "cbFunction");
            this.cbFunction.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbFunction.Buttons"))))});
            this.cbFunction.Name = "cbFunction";
            // 
            // tpPrecision
            // 
            this.tpPrecision.Controls.Add(this.PrecisionGrid);
            this.tpPrecision.Name = "tpPrecision";
            resources.ApplyResources(this.tpPrecision, "tpPrecision");
            // 
            // PrecisionGrid
            // 
            resources.ApplyResources(this.PrecisionGrid, "PrecisionGrid");
            this.PrecisionGrid.MainView = this.PrecisionView;
            this.PrecisionGrid.Name = "PrecisionGrid";
            this.PrecisionGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtPrecision});
            this.PrecisionGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PrecisionView});
            // 
            // PrecisionView
            // 
            this.PrecisionView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAggregateFunction,
            this.colPrecision});
            this.PrecisionView.GridControl = this.PrecisionGrid;
            this.PrecisionView.Name = "PrecisionView";
            this.PrecisionView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.PrecisionView.OptionsView.ShowGroupPanel = false;
            // 
            // colAggregateFunction
            // 
            resources.ApplyResources(this.colAggregateFunction, "colAggregateFunction");
            this.colAggregateFunction.FieldName = "strAggregateFunction";
            this.colAggregateFunction.Name = "colAggregateFunction";
            this.colAggregateFunction.OptionsColumn.AllowEdit = false;
            this.colAggregateFunction.OptionsColumn.ReadOnly = true;
            // 
            // colPrecision
            // 
            resources.ApplyResources(this.colPrecision, "colPrecision");
            this.colPrecision.ColumnEdit = this.txtPrecision;
            this.colPrecision.FieldName = "intDefaultPrecision";
            this.colPrecision.Name = "colPrecision";
            // 
            // txtPrecision
            // 
            resources.ApplyResources(this.txtPrecision, "txtPrecision");
            this.txtPrecision.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("txtPrecision.Buttons"))))});
            this.txtPrecision.IsFloatValue = false;
            this.txtPrecision.Mask.EditMask = resources.GetString("txtPrecision.Mask.EditMask");
            this.txtPrecision.MaxValue = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.txtPrecision.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txtPrecision.Name = "txtPrecision";
            // 
            // AvrSettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tbSettings);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.HelpTopicID = "Set_search_object_fields_defau";
            this.Name = "AvrSettingsForm";
            this.ObjectName = "AvrSettings";
            this.ShowDeleteButton = false;
            this.Sizable = true;
            this.Status = bv.common.win.FormStatus.Draft;
            this.TableName = "SearchObject";
            this.Controls.SetChildIndex(this.tbSettings, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tbSettings)).EndInit();
            this.tbSettings.ResumeLayout(false);
            this.tpFunction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbSearchObject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FunctionsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FunctionsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFunction)).EndInit();
            this.tpPrecision.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrecisionGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecisionView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecision)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private DevExpress.XtraTab.XtraTabControl tbSettings;
        private DevExpress.XtraTab.XtraTabPage tpPrecision;
        private DevExpress.XtraGrid.GridControl PrecisionGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PrecisionView;
        private DevExpress.XtraGrid.Columns.GridColumn colAggregateFunction;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecision;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit txtPrecision;
        private DevExpress.XtraTab.XtraTabPage tpFunction;
        private DevExpress.XtraEditors.LookUpEdit cbSearchObject;
        private DevExpress.XtraEditors.LabelControl lbSearchObject;
        private DevExpress.XtraGrid.GridControl FunctionsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView FunctionsView;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchObject;
        private DevExpress.XtraGrid.Columns.GridColumn colFunction;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbFunction;
    }
}