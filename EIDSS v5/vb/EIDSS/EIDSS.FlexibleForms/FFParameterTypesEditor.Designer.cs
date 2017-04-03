namespace EIDSS.FlexibleForms
{
    partial class FFParameterTypesEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FFParameterTypesEditor));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gcParameterTypes = new DevExpress.XtraGrid.GridControl();
            this.gvParameterTypes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colParameterTypeDefaultName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParameterTypeNationalName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParameterTypeSystem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.icbParameterTypeSystem = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imglst = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barParameterTypes = new DevExpress.XtraBars.Bar();
            this.btnAddParameterType = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveParameterType = new DevExpress.XtraBars.BarButtonItem();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barFixedePresetValues = new DevExpress.XtraBars.Bar();
            this.btnAddFixedPresetValue = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveFixedPresetValue = new DevExpress.XtraBars.BarButtonItem();
            this.btnUp = new DevExpress.XtraBars.BarButtonItem();
            this.btnDown = new DevExpress.XtraBars.BarButtonItem();
            this.standaloneBarDockControl2 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gcFixedPresetValues = new DevExpress.XtraGrid.GridControl();
            this.gvFixedPresetValues = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFixedPresetValueDefaultName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcolFixedPresetValueNationalName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlReferenceType = new DevExpress.XtraEditors.PanelControl();
            this.leReferenceType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.bar2 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcParameterTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvParameterTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbParameterTypeSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imglst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFixedPresetValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFixedPresetValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlReferenceType)).BeginInit();
            this.pnlReferenceType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leReferenceType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gcParameterTypes);
            this.panelControl1.Controls.Add(this.standaloneBarDockControl1);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // gcParameterTypes
            // 
            resources.ApplyResources(this.gcParameterTypes, "gcParameterTypes");
            this.gcParameterTypes.MainView = this.gvParameterTypes;
            this.gcParameterTypes.MenuManager = this.barManager1;
            this.gcParameterTypes.Name = "gcParameterTypes";
            this.gcParameterTypes.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.icbParameterTypeSystem});
            this.gcParameterTypes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvParameterTypes});
            // 
            // gvParameterTypes
            // 
            this.gvParameterTypes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colParameterTypeDefaultName,
            this.colParameterTypeNationalName,
            this.colParameterTypeSystem});
            this.gvParameterTypes.GridControl = this.gcParameterTypes;
            this.gvParameterTypes.Name = "gvParameterTypes";
            this.gvParameterTypes.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvParameterTypes.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvParameterTypes.OptionsCustomization.AllowColumnMoving = false;
            this.gvParameterTypes.OptionsCustomization.AllowFilter = false;
            this.gvParameterTypes.OptionsDetail.ShowDetailTabs = false;
            this.gvParameterTypes.OptionsDetail.SmartDetailExpand = false;
            this.gvParameterTypes.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvParameterTypes.OptionsView.ShowGroupPanel = false;
            this.gvParameterTypes.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.OnGvParameterTypesFocusedRowChanged);
            // 
            // colParameterTypeDefaultName
            // 
            resources.ApplyResources(this.colParameterTypeDefaultName, "colParameterTypeDefaultName");
            this.colParameterTypeDefaultName.FieldName = "DefaultName";
            this.colParameterTypeDefaultName.Name = "colParameterTypeDefaultName";
            // 
            // colParameterTypeNationalName
            // 
            resources.ApplyResources(this.colParameterTypeNationalName, "colParameterTypeNationalName");
            this.colParameterTypeNationalName.FieldName = "NationalName";
            this.colParameterTypeNationalName.Name = "colParameterTypeNationalName";
            // 
            // colParameterTypeSystem
            // 
            resources.ApplyResources(this.colParameterTypeSystem, "colParameterTypeSystem");
            this.colParameterTypeSystem.ColumnEdit = this.icbParameterTypeSystem;
            this.colParameterTypeSystem.FieldName = "System";
            this.colParameterTypeSystem.Name = "colParameterTypeSystem";
            // 
            // icbParameterTypeSystem
            // 
            resources.ApplyResources(this.icbParameterTypeSystem, "icbParameterTypeSystem");
            this.icbParameterTypeSystem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("icbParameterTypeSystem.Buttons"))))});
            this.icbParameterTypeSystem.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("icbParameterTypeSystem.Items"), resources.GetString("icbParameterTypeSystem.Items1"), ((int)(resources.GetObject("icbParameterTypeSystem.Items2")))),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("icbParameterTypeSystem.Items3"), resources.GetString("icbParameterTypeSystem.Items4"), ((int)(resources.GetObject("icbParameterTypeSystem.Items5"))))});
            this.icbParameterTypeSystem.Name = "icbParameterTypeSystem";
            this.icbParameterTypeSystem.SmallImages = this.imglst;
            // 
            // imglst
            // 
            this.imglst.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imglst.ImageStream")));
            this.imglst.Images.SetKeyName(0, "Books.bmp");
            this.imglst.Images.SetKeyName(1, "Document 2 Edit 2.png");
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barParameterTypes,
            this.barFixedePresetValues});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl2);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddParameterType,
            this.btnRemoveParameterType,
            this.btnAddFixedPresetValue,
            this.btnRemoveFixedPresetValue,
            this.btnUp,
            this.btnDown});
            this.barManager1.MaxItemId = 6;
            // 
            // barParameterTypes
            // 
            this.barParameterTypes.BarName = "ParameterTypes";
            this.barParameterTypes.DockCol = 0;
            this.barParameterTypes.DockRow = 0;
            this.barParameterTypes.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.barParameterTypes.FloatLocation = new System.Drawing.Point(114, 259);
            this.barParameterTypes.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddParameterType),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRemoveParameterType)});
            this.barParameterTypes.OptionsBar.AllowQuickCustomization = false;
            this.barParameterTypes.OptionsBar.DisableClose = true;
            this.barParameterTypes.OptionsBar.DisableCustomization = true;
            this.barParameterTypes.StandaloneBarDockControl = this.standaloneBarDockControl1;
            resources.ApplyResources(this.barParameterTypes, "barParameterTypes");
            // 
            // btnAddParameterType
            // 
            resources.ApplyResources(this.btnAddParameterType, "btnAddParameterType");
            this.btnAddParameterType.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddParameterType.Glyph")));
            this.btnAddParameterType.Id = 0;
            this.btnAddParameterType.Name = "btnAddParameterType";
            this.btnAddParameterType.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnBtnAddParameterTypeItemClick);
            // 
            // btnRemoveParameterType
            // 
            resources.ApplyResources(this.btnRemoveParameterType, "btnRemoveParameterType");
            this.btnRemoveParameterType.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRemoveParameterType.Glyph")));
            this.btnRemoveParameterType.Id = 1;
            this.btnRemoveParameterType.Name = "btnRemoveParameterType";
            this.btnRemoveParameterType.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnBtnRemoveParameterTypeItemClick);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            resources.ApplyResources(this.standaloneBarDockControl1, "standaloneBarDockControl1");
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            // 
            // barFixedePresetValues
            // 
            this.barFixedePresetValues.BarName = "FixedePresetValues";
            this.barFixedePresetValues.DockCol = 0;
            this.barFixedePresetValues.DockRow = 0;
            this.barFixedePresetValues.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.barFixedePresetValues.FloatLocation = new System.Drawing.Point(310, 166);
            this.barFixedePresetValues.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddFixedPresetValue),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRemoveFixedPresetValue),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUp),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDown)});
            this.barFixedePresetValues.Offset = 3;
            this.barFixedePresetValues.OptionsBar.AllowQuickCustomization = false;
            this.barFixedePresetValues.OptionsBar.AllowRename = true;
            this.barFixedePresetValues.OptionsBar.DisableClose = true;
            this.barFixedePresetValues.OptionsBar.DisableCustomization = true;
            this.barFixedePresetValues.StandaloneBarDockControl = this.standaloneBarDockControl2;
            resources.ApplyResources(this.barFixedePresetValues, "barFixedePresetValues");
            // 
            // btnAddFixedPresetValue
            // 
            resources.ApplyResources(this.btnAddFixedPresetValue, "btnAddFixedPresetValue");
            this.btnAddFixedPresetValue.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddFixedPresetValue.Glyph")));
            this.btnAddFixedPresetValue.Id = 2;
            this.btnAddFixedPresetValue.Name = "btnAddFixedPresetValue";
            this.btnAddFixedPresetValue.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnBtnAddFixedPresetValueItemClick);
            // 
            // btnRemoveFixedPresetValue
            // 
            resources.ApplyResources(this.btnRemoveFixedPresetValue, "btnRemoveFixedPresetValue");
            this.btnRemoveFixedPresetValue.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRemoveFixedPresetValue.Glyph")));
            this.btnRemoveFixedPresetValue.Id = 3;
            this.btnRemoveFixedPresetValue.Name = "btnRemoveFixedPresetValue";
            this.btnRemoveFixedPresetValue.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnBtnRemoveFixedPresetValueItemClick);
            // 
            // btnUp
            // 
            resources.ApplyResources(this.btnUp, "btnUp");
            this.btnUp.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUp.Glyph")));
            this.btnUp.Id = 4;
            this.btnUp.Name = "btnUp";
            this.btnUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnBtnUpItemClick);
            // 
            // btnDown
            // 
            resources.ApplyResources(this.btnDown, "btnDown");
            this.btnDown.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDown.Glyph")));
            this.btnDown.Id = 5;
            this.btnDown.Name = "btnDown";
            this.btnDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnBtnDownItemClick);
            // 
            // standaloneBarDockControl2
            // 
            this.standaloneBarDockControl2.CausesValidation = false;
            resources.ApplyResources(this.standaloneBarDockControl2, "standaloneBarDockControl2");
            this.standaloneBarDockControl2.Name = "standaloneBarDockControl2";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gcFixedPresetValues);
            this.panelControl2.Controls.Add(this.pnlReferenceType);
            this.panelControl2.Controls.Add(this.standaloneBarDockControl2);
            resources.ApplyResources(this.panelControl2, "panelControl2");
            this.panelControl2.Name = "panelControl2";
            // 
            // gcFixedPresetValues
            // 
            resources.ApplyResources(this.gcFixedPresetValues, "gcFixedPresetValues");
            this.gcFixedPresetValues.MainView = this.gvFixedPresetValues;
            this.gcFixedPresetValues.MenuManager = this.barManager1;
            this.gcFixedPresetValues.Name = "gcFixedPresetValues";
            this.gcFixedPresetValues.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFixedPresetValues});
            // 
            // gvFixedPresetValues
            // 
            this.gvFixedPresetValues.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFixedPresetValueDefaultName,
            this.colcolFixedPresetValueNationalName});
            this.gvFixedPresetValues.GridControl = this.gcFixedPresetValues;
            this.gvFixedPresetValues.Name = "gvFixedPresetValues";
            this.gvFixedPresetValues.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvFixedPresetValues.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvFixedPresetValues.OptionsCustomization.AllowColumnMoving = false;
            this.gvFixedPresetValues.OptionsCustomization.AllowFilter = false;
            this.gvFixedPresetValues.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvFixedPresetValues.OptionsView.ShowGroupPanel = false;
            // 
            // colFixedPresetValueDefaultName
            // 
            resources.ApplyResources(this.colFixedPresetValueDefaultName, "colFixedPresetValueDefaultName");
            this.colFixedPresetValueDefaultName.FieldName = "DefaultName";
            this.colFixedPresetValueDefaultName.Name = "colFixedPresetValueDefaultName";
            // 
            // colcolFixedPresetValueNationalName
            // 
            resources.ApplyResources(this.colcolFixedPresetValueNationalName, "colcolFixedPresetValueNationalName");
            this.colcolFixedPresetValueNationalName.FieldName = "NationalName";
            this.colcolFixedPresetValueNationalName.Name = "colcolFixedPresetValueNationalName";
            // 
            // pnlReferenceType
            // 
            this.pnlReferenceType.Controls.Add(this.leReferenceType);
            this.pnlReferenceType.Controls.Add(this.labelControl1);
            resources.ApplyResources(this.pnlReferenceType, "pnlReferenceType");
            this.pnlReferenceType.Name = "pnlReferenceType";
            // 
            // leReferenceType
            // 
            resources.ApplyResources(this.leReferenceType, "leReferenceType");
            this.leReferenceType.MenuManager = this.barManager1;
            this.leReferenceType.Name = "leReferenceType";
            this.leReferenceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leReferenceType.Properties.Buttons"))))});
            this.leReferenceType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("leReferenceType.Properties.Columns"), resources.GetString("leReferenceType.Properties.Columns1"))});
            this.leReferenceType.Properties.DisplayMember = "NationalName";
            this.leReferenceType.Properties.NullText = resources.GetString("leReferenceType.Properties.NullText");
            this.leReferenceType.Properties.ShowFooter = false;
            this.leReferenceType.Properties.ShowHeader = false;
            this.leReferenceType.Properties.ValueMember = "idfsReferenceType";
            this.leReferenceType.EditValueChanged += new System.EventHandler(this.OnLeReferenceTypeEditValueChanged);
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // splitterControl1
            // 
            resources.ApplyResources(this.splitterControl1, "splitterControl1");
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.TabStop = false;
            // 
            // bar2
            // 
            this.bar2.BarName = "Tools";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar2.FloatLocation = new System.Drawing.Point(114, 259);
            this.bar2.StandaloneBarDockControl = this.standaloneBarDockControl1;
            resources.ApplyResources(this.bar2, "bar2");
            // 
            // FFParameterTypesEditor
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormID = "F02";
            this.HelpTopicID = "Parameter_types_matrix";
            this.LeftIcon = global::EIDSS.FlexibleForms.Properties.Resources.Parameter_Types_Editor__large__48_;
            this.Name = "FFParameterTypesEditor";
            this.ShowDeleteButton = false;
            this.Sizable = true;
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.cmdOk, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcParameterTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvParameterTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbParameterTypeSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imglst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcFixedPresetValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFixedPresetValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlReferenceType)).EndInit();
            this.pnlReferenceType.ResumeLayout(false);
            this.pnlReferenceType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leReferenceType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barParameterTypes;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gcParameterTypes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvParameterTypes;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl2;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar barFixedePresetValues;
        private DevExpress.XtraGrid.Columns.GridColumn colParameterTypeDefaultName;
        private DevExpress.XtraGrid.Columns.GridColumn colParameterTypeNationalName;
        private DevExpress.XtraGrid.Columns.GridColumn colParameterTypeSystem;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox icbParameterTypeSystem;
        private DevExpress.Utils.ImageCollection imglst;
        private DevExpress.XtraBars.BarButtonItem btnAddParameterType;
        private DevExpress.XtraBars.BarButtonItem btnRemoveParameterType;
        private DevExpress.XtraBars.BarButtonItem btnAddFixedPresetValue;
        private DevExpress.XtraBars.BarButtonItem btnRemoveFixedPresetValue;
        private DevExpress.XtraGrid.GridControl gcFixedPresetValues;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFixedPresetValues;
        private DevExpress.XtraGrid.Columns.GridColumn colFixedPresetValueDefaultName;
        private DevExpress.XtraGrid.Columns.GridColumn colcolFixedPresetValueNationalName;
        private DevExpress.XtraEditors.PanelControl pnlReferenceType;
        private DevExpress.XtraEditors.LookUpEdit leReferenceType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.BarButtonItem btnUp;
        private DevExpress.XtraBars.BarButtonItem btnDown;

    }
}
