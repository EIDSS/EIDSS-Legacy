namespace eidss.avr.QueryBuilder
{
    partial class QuerySearchObjectInfo
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuerySearchObjectInfo));
            this.splitContainerFilters = new DevExpress.XtraEditors.SplitContainerControl();
            this.qsoFilter = new eidss.avr.FilterForm.QueryFilterControl();
            this.cbReportType = new DevExpress.XtraEditors.LookUpEdit();
            //old filter//this.QuerySearchFilter = new DevExpress.XtraEditors.FilterControl();
            this.lblFilter = new DevExpress.XtraEditors.LabelControl();
            this.lblReportType = new DevExpress.XtraEditors.LabelControl();
            this.txtFilterText = new DevExpress.XtraEditors.MemoEdit();
            this.splitContainerFields = new DevExpress.XtraEditors.SplitContainerControl();
            this.lblAvailableField = new DevExpress.XtraEditors.LabelControl();
            this.imlbcAvailableField = new DevExpress.XtraEditors.ImageListBoxControl();
            this.ttcAvailableField = new DevExpress.Utils.ToolTipController(this.components);
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.lblSelectedField = new DevExpress.XtraEditors.LabelControl();
            this.gcSelectedField = new DevExpress.XtraGrid.GridControl();
            this.gvSelectedField = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colQuerySearchField = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chShow = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcolTypeImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imTypeImage = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colFieldCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcQueryObjectFiltration = new DevExpress.XtraEditors.GroupControl();
            this.navSearchFields = new DevExpress.XtraNavBar.NavBarControl();
            this.grpSearchFields = new DevExpress.XtraNavBar.NavBarGroup();
            this.navSearchFieldsContainer = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.cbFilterByDiagnosis = new DevExpress.XtraEditors.LookUpEdit();
            this.lblFilterByDiagnosis = new DevExpress.XtraEditors.LabelControl();
            this.splitFields = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFilters)).BeginInit();
            this.splitContainerFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbReportType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFields)).BeginInit();
            this.splitContainerFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imlbcAvailableField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSelectedField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSelectedField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imTypeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcQueryObjectFiltration)).BeginInit();
            this.grcQueryObjectFiltration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navSearchFields)).BeginInit();
            this.navSearchFields.SuspendLayout();
            this.navSearchFieldsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFilterByDiagnosis.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(QuerySearchObjectInfo), out resources);
            // Form Is Localizable: True
            // 
            // splitContainerFilters
            // 
            this.splitContainerFilters.Appearance.Options.UseFont = true;
            this.splitContainerFilters.AppearanceCaption.Options.UseFont = true;
            this.splitContainerFilters.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            resources.ApplyResources(this.splitContainerFilters, "splitContainerFilters");
            this.splitContainerFilters.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerFilters.Horizontal = false;
            this.splitContainerFilters.Name = "splitContainerFilters";
            this.splitContainerFilters.Panel1.Appearance.Options.UseFont = true;
            this.splitContainerFilters.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerFilters.Panel1.Controls.Add(this.qsoFilter);
            this.splitContainerFilters.Panel1.Controls.Add(this.cbReportType);
            //old filter//this.splitContainerFilters.Panel1.Controls.Add(this.QuerySearchFilter);
            this.splitContainerFilters.Panel1.Controls.Add(this.lblFilter);
            this.splitContainerFilters.Panel1.Controls.Add(this.lblReportType);
            this.splitContainerFilters.Panel1.MinSize = 100;
            this.splitContainerFilters.Panel2.Appearance.Options.UseFont = true;
            this.splitContainerFilters.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerFilters.Panel2.Controls.Add(this.txtFilterText);
            this.splitContainerFilters.Panel2.MinSize = 40;
            resources.ApplyResources(this.splitContainerFilters.Panel2, "splitContainerFilters.Panel2");
            this.splitContainerFilters.SplitterPosition = 75;
            this.splitContainerFilters.SplitGroupPanelCollapsed += new DevExpress.XtraEditors.SplitGroupPanelCollapsedEventHandler(this.splitContainer_SplitGroupPanelCollapsed);
            // 
            // qsoFilter
            // 
            resources.ApplyResources(this.qsoFilter, "qsoFilter");
            this.qsoFilter.Appearance.Options.UseFont = true;
            this.qsoFilter.AppearanceTreeLine.Options.UseFont = true;
            this.qsoFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.qsoFilter.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.qsoFilter.HasChanges = false;
            this.qsoFilter.Name = "qsoFilter";
            this.qsoFilter.ObjectHACode = EIDSS.HACode.None;
            // 
            // cbReportType
            // 
            resources.ApplyResources(this.cbReportType, "cbReportType");
            this.cbReportType.Name = "cbReportType";
            this.cbReportType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbReportType.Properties.Buttons"))))});
            this.cbReportType.Properties.NullText = resources.GetString("cbReportType.Properties.NullText");
            //old filter//// 
            //old filter//// QuerySearchFilter
            //old filter//// 
            //old filter//resources.ApplyResources(this.QuerySearchFilter, "QuerySearchFilter");
            //old filter//this.QuerySearchFilter.Appearance.Options.UseFont = true;
            //old filter//this.QuerySearchFilter.AppearanceTreeLine.Options.UseFont = true;
            //old filter//this.QuerySearchFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            //old filter//this.QuerySearchFilter.Cursor = System.Windows.Forms.Cursors.Arrow;
            //old filter//this.QuerySearchFilter.Name = "QuerySearchFilter";
            // 
            // lblFilter
            // 
            resources.ApplyResources(this.lblFilter, "lblFilter");
            this.lblFilter.Name = "lblFilter";
            // 
            // lblReportType
            // 
            resources.ApplyResources(this.lblReportType, "lblReportType");
            this.lblReportType.Name = "lblReportType";
            // 
            // txtFilterText
            // 
            resources.ApplyResources(this.txtFilterText, "txtFilterText");
            this.txtFilterText.Name = "txtFilterText";
            this.txtFilterText.Properties.Appearance.Options.UseFont = true;
            this.txtFilterText.Properties.AppearanceDisabled.BackColor = ((System.Drawing.Color)(resources.GetObject("txtFilterText.Properties.AppearanceDisabled.BackColor")));
            this.txtFilterText.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtFilterText.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtFilterText.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtFilterText.Properties.AppearanceReadOnly.BackColor = ((System.Drawing.Color)(resources.GetObject("txtFilterText.Properties.AppearanceReadOnly.BackColor")));
            this.txtFilterText.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtFilterText.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtFilterText.Properties.ReadOnly = true;
            this.txtFilterText.Tag = "{R}";
            this.txtFilterText.UseOptimizedRendering = true;
            // 
            // splitContainerFields
            // 
            resources.ApplyResources(this.splitContainerFields, "splitContainerFields");
            this.splitContainerFields.Appearance.Options.UseFont = true;
            this.splitContainerFields.AppearanceCaption.Options.UseFont = true;
            this.splitContainerFields.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.splitContainerFields.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerFields.Name = "splitContainerFields";
            this.splitContainerFields.Panel1.Appearance.Options.UseFont = true;
            this.splitContainerFields.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerFields.Panel1.Controls.Add(this.lblAvailableField);
            this.splitContainerFields.Panel1.Controls.Add(this.imlbcAvailableField);
            this.splitContainerFields.Panel1.Controls.Add(this.btnAdd);
            this.splitContainerFields.Panel1.Controls.Add(this.btnRemoveAll);
            this.splitContainerFields.Panel1.Controls.Add(this.btnAddAll);
            this.splitContainerFields.Panel1.Controls.Add(this.btnRemove);
            this.splitContainerFields.Panel1.MinSize = 200;
            this.splitContainerFields.Panel2.Appearance.Options.UseFont = true;
            this.splitContainerFields.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerFields.Panel2.Controls.Add(this.lblSelectedField);
            this.splitContainerFields.Panel2.Controls.Add(this.gcSelectedField);
            this.splitContainerFields.Panel2.MinSize = 100;
            resources.ApplyResources(this.splitContainerFields.Panel2, "splitContainerFields.Panel2");
            this.splitContainerFields.SplitterPosition = 211;
            // 
            // lblAvailableField
            // 
            resources.ApplyResources(this.lblAvailableField, "lblAvailableField");
            this.lblAvailableField.Name = "lblAvailableField";
            // 
            // imlbcAvailableField
            // 
            resources.ApplyResources(this.imlbcAvailableField, "imlbcAvailableField");
            this.imlbcAvailableField.HorizontalScrollbar = true;
            this.imlbcAvailableField.Name = "imlbcAvailableField";
            this.imlbcAvailableField.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.imlbcAvailableField.ToolTipController = this.ttcAvailableField;
            this.imlbcAvailableField.SelectedIndexChanged += new System.EventHandler(this.imlbcAvailableField_SelectedIndexChanged);
            this.imlbcAvailableField.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imlbcAvailableField_MouseDoubleClick);
            this.imlbcAvailableField.MouseLeave += new System.EventHandler(this.imlbcAvailableField_MouseLeave);
            this.imlbcAvailableField.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imlbcAvailableField_MouseMove);
            // 
            // ttcAvailableField
            // 
            this.ttcAvailableField.CloseOnClick = DevExpress.Utils.DefaultBoolean.True;
            this.ttcAvailableField.InitialDelay = 1000;
            this.ttcAvailableField.ReshowDelay = 200;
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnAdd.Appearance.Font")));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageIndex = 0;
            this.btnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Tag = "FixFont";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemoveAll
            // 
            resources.ApplyResources(this.btnRemoveAll, "btnRemoveAll");
            this.btnRemoveAll.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnRemoveAll.Appearance.Font")));
            this.btnRemoveAll.Appearance.Options.UseFont = true;
            this.btnRemoveAll.ImageIndex = 3;
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Tag = "FixFont";
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnAddAll
            // 
            resources.ApplyResources(this.btnAddAll, "btnAddAll");
            this.btnAddAll.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnAddAll.Appearance.Font")));
            this.btnAddAll.Appearance.Options.UseFont = true;
            this.btnAddAll.ImageIndex = 2;
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Tag = "FixFont";
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnRemove
            // 
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnRemove.Appearance.Font")));
            this.btnRemove.Appearance.Options.UseFont = true;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Tag = "FixFont";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblSelectedField
            // 
            resources.ApplyResources(this.lblSelectedField, "lblSelectedField");
            this.lblSelectedField.Name = "lblSelectedField";
            // 
            // gcSelectedField
            // 
            resources.ApplyResources(this.gcSelectedField, "gcSelectedField");
            this.gcSelectedField.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcSelectedField.MainView = this.gvSelectedField;
            this.gcSelectedField.Name = "gcSelectedField";
            this.gcSelectedField.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chShow,
            this.imTypeImage});
            this.gcSelectedField.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSelectedField});
            // 
            // gvSelectedField
            // 
            this.gvSelectedField.ActiveFilterEnabled = false;
            this.gvSelectedField.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colQuerySearchField,
            this.colShow,
            this.gcolTypeImage,
            this.colFieldCaption});
            this.gvSelectedField.GridControl = this.gcSelectedField;
            this.gvSelectedField.Name = "gvSelectedField";
            this.gvSelectedField.OptionsCustomization.AllowColumnMoving = false;
            this.gvSelectedField.OptionsCustomization.AllowFilter = false;
            this.gvSelectedField.OptionsCustomization.AllowGroup = false;
            this.gvSelectedField.OptionsCustomization.AllowSort = false;
            this.gvSelectedField.OptionsNavigation.AutoFocusNewRow = true;
            this.gvSelectedField.OptionsSelection.MultiSelect = true;
            this.gvSelectedField.OptionsView.ShowColumnHeaders = false;
            this.gvSelectedField.OptionsView.ShowDetailButtons = false;
            this.gvSelectedField.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvSelectedField.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gvSelectedField.OptionsView.ShowGroupPanel = false;
            this.gvSelectedField.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvSelectedField.OptionsView.ShowIndicator = false;
            this.gvSelectedField.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvSelectedField.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvSelectedField_RowCellClick);
            // 
            // colQuerySearchField
            // 
            resources.ApplyResources(this.colQuerySearchField, "colQuerySearchField");
            this.colQuerySearchField.FieldName = "idfQuerySearchField";
            this.colQuerySearchField.Name = "colQuerySearchField";
            // 
            // colShow
            // 
            resources.ApplyResources(this.colShow, "colShow");
            this.colShow.ColumnEdit = this.chShow;
            this.colShow.FieldName = "blnShow";
            this.colShow.Name = "colShow";
            this.colShow.OptionsColumn.AllowMove = false;
            this.colShow.OptionsColumn.AllowSize = false;
            this.colShow.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // chShow
            // 
            this.chShow.Appearance.Options.UseFont = true;
            this.chShow.AppearanceDisabled.Options.UseFont = true;
            this.chShow.AppearanceFocused.Options.UseFont = true;
            this.chShow.AppearanceReadOnly.Options.UseFont = true;
            resources.ApplyResources(this.chShow, "chShow");
            this.chShow.Name = "chShow";
            // 
            // gcolTypeImage
            // 
            resources.ApplyResources(this.gcolTypeImage, "gcolTypeImage");
            this.gcolTypeImage.ColumnEdit = this.imTypeImage;
            this.gcolTypeImage.FieldName = "TypeImageIndex";
            this.gcolTypeImage.Name = "gcolTypeImage";
            this.gcolTypeImage.OptionsColumn.AllowEdit = false;
            this.gcolTypeImage.OptionsColumn.AllowMove = false;
            this.gcolTypeImage.OptionsColumn.AllowSize = false;
            this.gcolTypeImage.OptionsColumn.ShowInCustomizationForm = false;
            this.gcolTypeImage.OptionsColumn.TabStop = false;
            // 
            // imTypeImage
            // 
            resources.ApplyResources(this.imTypeImage, "imTypeImage");
            this.imTypeImage.Name = "imTypeImage";
            this.imTypeImage.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            // 
            // colFieldCaption
            // 
            resources.ApplyResources(this.colFieldCaption, "colFieldCaption");
            this.colFieldCaption.FieldName = "FieldCaption";
            this.colFieldCaption.Name = "colFieldCaption";
            this.colFieldCaption.OptionsColumn.AllowEdit = false;
            this.colFieldCaption.OptionsColumn.AllowMove = false;
            this.colFieldCaption.OptionsColumn.AllowShowHide = false;
            this.colFieldCaption.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // grcQueryObjectFiltration
            // 
            this.grcQueryObjectFiltration.Appearance.Options.UseFont = true;
            this.grcQueryObjectFiltration.AppearanceCaption.Options.UseFont = true;
            this.grcQueryObjectFiltration.Controls.Add(this.splitContainerFilters);
            resources.ApplyResources(this.grcQueryObjectFiltration, "grcQueryObjectFiltration");
            this.grcQueryObjectFiltration.Name = "grcQueryObjectFiltration";
            // 
            // navSearchFields
            // 
            this.navSearchFields.ActiveGroup = this.grpSearchFields;
            this.navSearchFields.Appearance.Background.Options.UseFont = true;
            this.navSearchFields.Appearance.Button.Options.UseFont = true;
            this.navSearchFields.Appearance.ButtonDisabled.Options.UseFont = true;
            this.navSearchFields.Appearance.ButtonHotTracked.Options.UseFont = true;
            this.navSearchFields.Appearance.ButtonPressed.Options.UseFont = true;
            this.navSearchFields.Appearance.GroupBackground.Options.UseFont = true;
            this.navSearchFields.Appearance.GroupHeader.Options.UseFont = true;
            this.navSearchFields.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.navSearchFields.Appearance.GroupHeaderHotTracked.Options.UseFont = true;
            this.navSearchFields.Appearance.GroupHeaderPressed.Options.UseFont = true;
            this.navSearchFields.Appearance.Hint.Options.UseFont = true;
            this.navSearchFields.Appearance.Item.Options.UseFont = true;
            this.navSearchFields.Appearance.ItemActive.Options.UseFont = true;
            this.navSearchFields.Appearance.ItemDisabled.Options.UseFont = true;
            this.navSearchFields.Appearance.ItemHotTracked.Options.UseFont = true;
            this.navSearchFields.Appearance.ItemPressed.Options.UseFont = true;
            this.navSearchFields.Appearance.LinkDropTarget.Options.UseFont = true;
            this.navSearchFields.Appearance.NavigationPaneHeader.Options.UseFont = true;
            this.navSearchFields.Appearance.NavPaneContentButton.Options.UseFont = true;
            this.navSearchFields.Appearance.NavPaneContentButtonHotTracked.Options.UseFont = true;
            this.navSearchFields.Appearance.NavPaneContentButtonPressed.Options.UseFont = true;
            this.navSearchFields.Appearance.NavPaneContentButtonReleased.Options.UseFont = true;
            this.navSearchFields.ContentButtonHint = null;
            this.navSearchFields.Controls.Add(this.navSearchFieldsContainer);
            resources.ApplyResources(this.navSearchFields, "navSearchFields");
            this.navSearchFields.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.grpSearchFields});
            this.navSearchFields.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.navSearchFields.Name = "navSearchFields";
            this.navSearchFields.NavigationPaneOverflowPanelUseSmallImages = false;
            this.navSearchFields.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth")));
            this.navSearchFields.OptionsNavPane.ShowOverflowPanel = false;
            this.navSearchFields.OptionsNavPane.ShowSplitter = false;
            this.navSearchFields.ShowGroupHint = false;
            this.navSearchFields.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
            // 
            // grpSearchFields
            // 
            resources.ApplyResources(this.grpSearchFields, "grpSearchFields");
            this.grpSearchFields.ControlContainer = this.navSearchFieldsContainer;
            this.grpSearchFields.Expanded = true;
            this.grpSearchFields.GroupClientHeight = 308;
            this.grpSearchFields.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.grpSearchFields.Name = "grpSearchFields";
            this.grpSearchFields.NavigationPaneVisible = false;
            // 
            // navSearchFieldsContainer
            // 
            this.navSearchFieldsContainer.Controls.Add(this.splitContainerFields);
            this.navSearchFieldsContainer.Controls.Add(this.cbFilterByDiagnosis);
            this.navSearchFieldsContainer.Controls.Add(this.lblFilterByDiagnosis);
            this.navSearchFieldsContainer.Name = "navSearchFieldsContainer";
            resources.ApplyResources(this.navSearchFieldsContainer, "navSearchFieldsContainer");
            // 
            // cbFilterByDiagnosis
            // 
            resources.ApplyResources(this.cbFilterByDiagnosis, "cbFilterByDiagnosis");
            this.cbFilterByDiagnosis.Name = "cbFilterByDiagnosis";
            this.cbFilterByDiagnosis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbFilterByDiagnosis.Properties.Buttons"))))});
            this.cbFilterByDiagnosis.Properties.NullText = resources.GetString("cbFilterByDiagnosis.Properties.NullText");
            this.cbFilterByDiagnosis.EditValueChanged += new System.EventHandler(this.cbFilterByDiagnosis_EditValueChanged);
            // 
            // lblFilterByDiagnosis
            // 
            resources.ApplyResources(this.lblFilterByDiagnosis, "lblFilterByDiagnosis");
            this.lblFilterByDiagnosis.Name = "lblFilterByDiagnosis";
            // 
            // splitFields
            // 
            resources.ApplyResources(this.splitFields, "splitFields");
            this.splitFields.Name = "splitFields";
            this.splitFields.TabStop = false;
            // 
            // QuerySearchObjectInfo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcQueryObjectFiltration);
            this.Controls.Add(this.splitFields);
            this.Controls.Add(this.navSearchFields);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.KeyFieldName = "idfQuerySearchObject";
            this.MinHeight = 300;
            this.Name = "QuerySearchObjectInfo";
            this.ObjectName = "QuerySearchObject";
            this.Status = bv.common.win.FormStatus.Draft;
            this.TableName = "tasQuerySearchObject";
            this.OnBeforePost += new System.EventHandler(this.QuerySearchObjectInfo_OnBeforePost);
            this.OnAfterPost += new System.EventHandler(this.QuerySearchObjectInfo_OnAfterPost);
            this.AfterLoadData += new System.EventHandler(this.QuerySearchObjectInfo_AfterLoadData);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFilters)).EndInit();
            this.splitContainerFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbReportType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFields)).EndInit();
            this.splitContainerFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imlbcAvailableField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSelectedField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSelectedField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imTypeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcQueryObjectFiltration)).EndInit();
            this.grcQueryObjectFiltration.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navSearchFields)).EndInit();
            this.navSearchFields.ResumeLayout(false);
            this.navSearchFieldsContainer.ResumeLayout(false);
            this.navSearchFieldsContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFilterByDiagnosis.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblSelectedField;
        private DevExpress.XtraEditors.LabelControl lblAvailableField;
        private DevExpress.XtraEditors.GroupControl grcQueryObjectFiltration;
        private DevExpress.XtraEditors.LabelControl lblFilter;
        private DevExpress.XtraGrid.GridControl gcSelectedField;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSelectedField;
        private DevExpress.XtraGrid.Columns.GridColumn colShow;
        private DevExpress.XtraGrid.Columns.GridColumn colQuerySearchField;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chShow;
        private DevExpress.XtraGrid.Columns.GridColumn colFieldCaption;
        //old filter//private DevExpress.XtraEditors.FilterControl QuerySearchFilter;
        private DevExpress.XtraEditors.MemoEdit txtFilterText;
        private DevExpress.XtraNavBar.NavBarControl navSearchFields;
        private DevExpress.XtraNavBar.NavBarGroup grpSearchFields;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navSearchFieldsContainer;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerFilters;
        private DevExpress.XtraEditors.SplitterControl splitFields;
        private DevExpress.XtraGrid.Columns.GridColumn gcolTypeImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox imTypeImage;
        private DevExpress.Utils.ToolTipController ttcAvailableField;
        private DevExpress.XtraEditors.LookUpEdit cbFilterByDiagnosis;
        private DevExpress.XtraEditors.LabelControl lblFilterByDiagnosis;
        private DevExpress.XtraEditors.LookUpEdit cbReportType;
        private DevExpress.XtraEditors.LabelControl lblReportType;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerFields;
        private DevExpress.XtraEditors.ImageListBoxControl imlbcAvailableField;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnRemoveAll;
        private DevExpress.XtraEditors.SimpleButton btnAddAll;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private FilterForm.QueryFilterControl qsoFilter;
    }
}
