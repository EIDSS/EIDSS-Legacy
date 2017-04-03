using eidss.avr.FilterForm;
using eidss.avr.PivotComponents;

namespace eidss.avr.PivotForm
{
    partial class PivotDetailPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PivotDetailPanel));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grcMain = new DevExpress.XtraEditors.GroupControl();
            this.grcGrid = new DevExpress.XtraEditors.GroupControl();
            this.pivotGrid = new eidss.avr.PivotComponents.AvrPivotGrid();
            this.splitter = new DevExpress.XtraEditors.SplitterControl();
            this.nbCustomization = new DevExpress.XtraNavBar.NavBarControl();
            this.nbCustomizationGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbContainerCustomization = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.grcCustomization = new DevExpress.XtraEditors.GroupControl();
            this.nbControlSettings = new DevExpress.XtraNavBar.NavBarControl();
            this.nbGroupSettings = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbContainerSettings = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.grcSettings = new DevExpress.XtraEditors.GroupControl();
            this.filterControl = new eidss.avr.FilterForm.PivotFilterControl();
            this.AggregateLookupEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.AdministrativeUnitLookupEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.RefreshDataButton = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonsImageList = new System.Windows.Forms.ImageList();
            this.EditFiltersButton = new DevExpress.XtraEditors.SimpleButton();
            this.ShowDataCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.AdmUnitLabel = new System.Windows.Forms.Label();
            this.ApplyFilterCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.AggregateLabel = new System.Windows.Forms.Label();
            this.GroupIntervalLookupEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.ShowMissedValuesCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.DefaultGroupDateLabel = new System.Windows.Forms.Label();
            this.ForDateLookupEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.CompactLayoutCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.PrecisionSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.SplitterPanel = new DevExpress.XtraEditors.PanelControl();
            this.FreezeRowHeadersCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.DateFieldLabel = new System.Windows.Forms.Label();
            this.PrecisionLabel = new System.Windows.Forms.Label();
            this.AggregateColumnNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ShowTotalsComboBoxEdit = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.ShowTotalsLabel = new DevExpress.XtraEditors.LabelControl();
            this.ForDataFieldLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).BeginInit();
            this.grcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcGrid)).BeginInit();
            this.grcGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbCustomization)).BeginInit();
            this.nbCustomization.SuspendLayout();
            this.nbContainerCustomization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcCustomization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbControlSettings)).BeginInit();
            this.nbControlSettings.SuspendLayout();
            this.nbContainerSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcSettings)).BeginInit();
            this.grcSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AggregateLookupEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdministrativeUnitLookupEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowDataCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyFilterCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupIntervalLookupEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowMissedValuesCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForDateLookupEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompactLayoutCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecisionSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitterPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FreezeRowHeadersCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AggregateColumnNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowTotalsComboBoxEdit.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(PivotDetailPanel), out resources);
            // Form Is Localizable: True
            // 
            // grcMain
            // 
            this.grcMain.Appearance.Options.UseFont = true;
            this.grcMain.AppearanceCaption.Options.UseFont = true;
            this.grcMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcMain.Controls.Add(this.grcGrid);
            this.grcMain.Controls.Add(this.splitter);
            this.grcMain.Controls.Add(this.nbCustomization);
            resources.ApplyResources(this.grcMain, "grcMain");
            this.grcMain.Name = "grcMain";
            this.grcMain.ShowCaption = false;
            // 
            // grcGrid
            // 
            this.grcGrid.Appearance.Options.UseFont = true;
            this.grcGrid.AppearanceCaption.Options.UseFont = true;
            this.grcGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcGrid.Controls.Add(this.pivotGrid);
            resources.ApplyResources(this.grcGrid, "grcGrid");
            this.grcGrid.Name = "grcGrid";
            this.grcGrid.ShowCaption = false;
            // 
            // pivotGrid
            // 
            this.pivotGrid.Appearance.Cell.Options.UseFont = true;
            this.pivotGrid.Appearance.Cell.Options.UseTextOptions = true;
            this.pivotGrid.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.pivotGrid.Appearance.Cell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.pivotGrid.Appearance.ColumnHeaderArea.Options.UseFont = true;
            this.pivotGrid.Appearance.CustomTotalCell.Options.UseFont = true;
            this.pivotGrid.Appearance.DataHeaderArea.Options.UseFont = true;
            this.pivotGrid.Appearance.Empty.Options.UseFont = true;
            this.pivotGrid.Appearance.ExpandButton.Options.UseFont = true;
            this.pivotGrid.Appearance.FieldHeader.Options.UseFont = true;
            this.pivotGrid.Appearance.FieldValue.Options.UseFont = true;
            this.pivotGrid.Appearance.FieldValueGrandTotal.Options.UseFont = true;
            this.pivotGrid.Appearance.FieldValueTotal.Options.UseFont = true;
            this.pivotGrid.Appearance.FilterHeaderArea.Options.UseFont = true;
            this.pivotGrid.Appearance.FilterSeparator.Options.UseFont = true;
            this.pivotGrid.Appearance.FocusedCell.Options.UseFont = true;
            this.pivotGrid.Appearance.GrandTotalCell.Options.UseFont = true;
            this.pivotGrid.Appearance.HeaderArea.Options.UseFont = true;
            this.pivotGrid.Appearance.HeaderFilterButton.Options.UseFont = true;
            this.pivotGrid.Appearance.HeaderFilterButtonActive.Options.UseFont = true;
            this.pivotGrid.Appearance.HeaderGroupLine.Options.UseFont = true;
            this.pivotGrid.Appearance.Lines.Options.UseFont = true;
            this.pivotGrid.Appearance.PrefilterPanel.Options.UseFont = true;
            this.pivotGrid.Appearance.RowHeaderArea.Options.UseFont = true;
            this.pivotGrid.Appearance.SelectedCell.Options.UseFont = true;
            this.pivotGrid.Appearance.TotalCell.Options.UseFont = true;
            this.pivotGrid.AppearancePrint.Cell.Options.UseFont = true;
            this.pivotGrid.AppearancePrint.CustomTotalCell.Options.UseFont = true;
            this.pivotGrid.AppearancePrint.FieldHeader.Options.UseFont = true;
            this.pivotGrid.AppearancePrint.FieldValue.Options.UseFont = true;
            this.pivotGrid.AppearancePrint.FieldValueGrandTotal.Options.UseFont = true;
            this.pivotGrid.AppearancePrint.FieldValueTotal.Options.UseFont = true;
            this.pivotGrid.AppearancePrint.FilterSeparator.Options.UseFont = true;
            this.pivotGrid.AppearancePrint.GrandTotalCell.Options.UseFont = true;
            this.pivotGrid.AppearancePrint.HeaderGroupLine.Options.UseFont = true;
            this.pivotGrid.AppearancePrint.Lines.Options.UseFont = true;
            this.pivotGrid.AppearancePrint.TotalCell.Options.UseFont = true;
            this.pivotGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pivotGrid.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.pivotGrid, "pivotGrid");
            this.pivotGrid.Name = "pivotGrid";
            this.pivotGrid.OptionsCustomization.AllowPrefilter = false;
            this.pivotGrid.OptionsMenu.EnableHeaderAreaMenu = false;
            this.pivotGrid.OptionsMenu.EnableHeaderMenu = false;
            this.pivotGrid.OptionsPrint.UsePrintAppearance = true;
            this.pivotGrid.OptionsView.HeaderHeightOffset = 4;
            this.pivotGrid.CellClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pivotGrid_CellClick);
            this.pivotGrid.FocusedCellChanged += new System.EventHandler(this.pivotGrid_FocusedCellChanged);
            this.pivotGrid.CellSelectionChanged += new System.EventHandler(this.pivotGrid_CellSelectionChanged);
            // 
            // splitter
            // 
            this.splitter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.splitter, "splitter");
            this.splitter.Name = "splitter";
            this.splitter.TabStop = false;
            // 
            // nbCustomization
            // 
            this.nbCustomization.ActiveGroup = this.nbCustomizationGroup;
            this.nbCustomization.Appearance.Background.Options.UseFont = true;
            this.nbCustomization.Appearance.Button.Options.UseFont = true;
            this.nbCustomization.Appearance.ButtonDisabled.Options.UseFont = true;
            this.nbCustomization.Appearance.ButtonHotTracked.Options.UseFont = true;
            this.nbCustomization.Appearance.ButtonPressed.Options.UseFont = true;
            this.nbCustomization.Appearance.GroupBackground.Options.UseFont = true;
            this.nbCustomization.Appearance.GroupHeader.Options.UseFont = true;
            this.nbCustomization.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.nbCustomization.Appearance.GroupHeaderHotTracked.Options.UseFont = true;
            this.nbCustomization.Appearance.GroupHeaderPressed.Options.UseFont = true;
            this.nbCustomization.Appearance.Hint.Options.UseFont = true;
            this.nbCustomization.Appearance.Item.Options.UseFont = true;
            this.nbCustomization.Appearance.ItemActive.Options.UseFont = true;
            this.nbCustomization.Appearance.ItemDisabled.Options.UseFont = true;
            this.nbCustomization.Appearance.ItemHotTracked.Options.UseFont = true;
            this.nbCustomization.Appearance.ItemPressed.Options.UseFont = true;
            this.nbCustomization.Appearance.LinkDropTarget.Options.UseFont = true;
            this.nbCustomization.Appearance.NavigationPaneHeader.Options.UseFont = true;
            this.nbCustomization.Appearance.NavPaneContentButton.Options.UseFont = true;
            this.nbCustomization.Appearance.NavPaneContentButtonHotTracked.Options.UseFont = true;
            this.nbCustomization.Appearance.NavPaneContentButtonPressed.Options.UseFont = true;
            this.nbCustomization.Appearance.NavPaneContentButtonReleased.Options.UseFont = true;
            this.nbCustomization.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.nbCustomization.ContentButtonHint = null;
            this.nbCustomization.Controls.Add(this.nbContainerCustomization);
            resources.ApplyResources(this.nbCustomization, "nbCustomization");
            this.nbCustomization.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbCustomizationGroup});
            this.nbCustomization.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.nbCustomization.Name = "nbCustomization";
            this.nbCustomization.NavigationPaneMaxVisibleGroups = 0;
            this.nbCustomization.NavigationPaneOverflowPanelUseSmallImages = false;
            this.nbCustomization.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth")));
            this.nbCustomization.OptionsNavPane.ShowOverflowPanel = false;
            this.nbCustomization.OptionsNavPane.ShowSplitter = false;
            this.nbCustomization.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
            // 
            // nbCustomizationGroup
            // 
            resources.ApplyResources(this.nbCustomizationGroup, "nbCustomizationGroup");
            this.nbCustomizationGroup.ControlContainer = this.nbContainerCustomization;
            this.nbCustomizationGroup.Expanded = true;
            this.nbCustomizationGroup.GroupClientHeight = 702;
            this.nbCustomizationGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbCustomizationGroup.Name = "nbCustomizationGroup";
            // 
            // nbContainerCustomization
            // 
            this.nbContainerCustomization.Controls.Add(this.grcCustomization);
            this.nbContainerCustomization.Name = "nbContainerCustomization";
            resources.ApplyResources(this.nbContainerCustomization, "nbContainerCustomization");
            // 
            // grcCustomization
            // 
            this.grcCustomization.Appearance.Options.UseFont = true;
            this.grcCustomization.AppearanceCaption.Options.UseFont = true;
            this.grcCustomization.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.grcCustomization, "grcCustomization");
            this.grcCustomization.Name = "grcCustomization";
            this.grcCustomization.ShowCaption = false;
            // 
            // nbControlSettings
            // 
            this.nbControlSettings.ActiveGroup = this.nbGroupSettings;
            this.nbControlSettings.Appearance.Background.Options.UseFont = true;
            this.nbControlSettings.Appearance.Button.Options.UseFont = true;
            this.nbControlSettings.Appearance.ButtonDisabled.Options.UseFont = true;
            this.nbControlSettings.Appearance.ButtonHotTracked.Options.UseFont = true;
            this.nbControlSettings.Appearance.ButtonPressed.Options.UseFont = true;
            this.nbControlSettings.Appearance.GroupBackground.Options.UseFont = true;
            this.nbControlSettings.Appearance.GroupHeader.Options.UseFont = true;
            this.nbControlSettings.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.nbControlSettings.Appearance.GroupHeaderHotTracked.Options.UseFont = true;
            this.nbControlSettings.Appearance.GroupHeaderPressed.Options.UseFont = true;
            this.nbControlSettings.Appearance.Hint.Options.UseFont = true;
            this.nbControlSettings.Appearance.Item.Options.UseFont = true;
            this.nbControlSettings.Appearance.ItemActive.Options.UseFont = true;
            this.nbControlSettings.Appearance.ItemDisabled.Options.UseFont = true;
            this.nbControlSettings.Appearance.ItemHotTracked.Options.UseFont = true;
            this.nbControlSettings.Appearance.ItemPressed.Options.UseFont = true;
            this.nbControlSettings.Appearance.LinkDropTarget.Options.UseFont = true;
            this.nbControlSettings.Appearance.NavigationPaneHeader.Options.UseFont = true;
            this.nbControlSettings.Appearance.NavPaneContentButton.Options.UseFont = true;
            this.nbControlSettings.Appearance.NavPaneContentButtonHotTracked.Options.UseFont = true;
            this.nbControlSettings.Appearance.NavPaneContentButtonPressed.Options.UseFont = true;
            this.nbControlSettings.Appearance.NavPaneContentButtonReleased.Options.UseFont = true;
            this.nbControlSettings.ContentButtonHint = null;
            this.nbControlSettings.Controls.Add(this.nbContainerSettings);
            resources.ApplyResources(this.nbControlSettings, "nbControlSettings");
            this.nbControlSettings.ExplorerBarGroupInterval = 1;
            this.nbControlSettings.ExplorerBarGroupOuterIndent = 0;
            this.nbControlSettings.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbGroupSettings});
            this.nbControlSettings.Name = "nbControlSettings";
            this.nbControlSettings.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth1")));
            this.nbControlSettings.OptionsNavPane.ShowOverflowPanel = false;
            this.nbControlSettings.OptionsNavPane.ShowSplitter = false;
            this.nbControlSettings.StoreDefaultPaintStyleName = true;
            this.nbControlSettings.GroupExpanded += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.nbControlSettings_GroupExpanded);
            this.nbControlSettings.GroupCollapsed += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.nbControlSettings_GroupCollapsed);
            // 
            // nbGroupSettings
            // 
            resources.ApplyResources(this.nbGroupSettings, "nbGroupSettings");
            this.nbGroupSettings.ControlContainer = this.nbContainerSettings;
            this.nbGroupSettings.Expanded = true;
            this.nbGroupSettings.GroupClientHeight = 145;
            this.nbGroupSettings.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbGroupSettings.Name = "nbGroupSettings";
            // 
            // nbContainerSettings
            // 
            this.nbContainerSettings.Controls.Add(this.grcSettings);
            this.nbContainerSettings.Name = "nbContainerSettings";
            resources.ApplyResources(this.nbContainerSettings, "nbContainerSettings");
            // 
            // grcSettings
            // 
            this.grcSettings.Appearance.Options.UseFont = true;
            this.grcSettings.AppearanceCaption.Options.UseFont = true;
            this.grcSettings.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcSettings.Controls.Add(this.filterControl);
            this.grcSettings.Controls.Add(this.AggregateLookupEdit);
            this.grcSettings.Controls.Add(this.AdministrativeUnitLookupEdit);
            this.grcSettings.Controls.Add(this.RefreshDataButton);
            this.grcSettings.Controls.Add(this.EditFiltersButton);
            this.grcSettings.Controls.Add(this.ShowDataCheckEdit);
            this.grcSettings.Controls.Add(this.AdmUnitLabel);
            this.grcSettings.Controls.Add(this.ApplyFilterCheckEdit);
            this.grcSettings.Controls.Add(this.AggregateLabel);
            this.grcSettings.Controls.Add(this.GroupIntervalLookupEdit);
            this.grcSettings.Controls.Add(this.ShowMissedValuesCheckEdit);
            this.grcSettings.Controls.Add(this.DefaultGroupDateLabel);
            this.grcSettings.Controls.Add(this.ForDateLookupEdit);
            this.grcSettings.Controls.Add(this.CompactLayoutCheckEdit);
            this.grcSettings.Controls.Add(this.PrecisionSpinEdit);
            this.grcSettings.Controls.Add(this.SplitterPanel);
            this.grcSettings.Controls.Add(this.FreezeRowHeadersCheckEdit);
            this.grcSettings.Controls.Add(this.DateFieldLabel);
            this.grcSettings.Controls.Add(this.PrecisionLabel);
            this.grcSettings.Controls.Add(this.AggregateColumnNameTextEdit);
            this.grcSettings.Controls.Add(this.ShowTotalsComboBoxEdit);
            this.grcSettings.Controls.Add(this.ShowTotalsLabel);
            this.grcSettings.Controls.Add(this.ForDataFieldLabel);
            resources.ApplyResources(this.grcSettings, "grcSettings");
            this.grcSettings.Name = "grcSettings";
            this.grcSettings.ShowCaption = false;
            // 
            // filterControl
            // 
            this.filterControl.Appearance.Options.UseFont = true;
            this.filterControl.AppearanceTreeLine.Options.UseFont = true;
            this.filterControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.filterControl.HasChanges = false;
            resources.ApplyResources(this.filterControl, "filterControl");
            this.filterControl.Name = "filterControl";
            this.filterControl.ObjectHACode = EIDSS.HACode.None;
            // 
            // AggregateLookupEdit
            // 
            resources.ApplyResources(this.AggregateLookupEdit, "AggregateLookupEdit");
            this.AggregateLookupEdit.Name = "AggregateLookupEdit";
            this.AggregateLookupEdit.Properties.Appearance.Options.UseFont = true;
            this.AggregateLookupEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.AggregateLookupEdit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.AggregateLookupEdit.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.AggregateLookupEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.AggregateLookupEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject1.Options.UseFont = true;
            this.AggregateLookupEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("AggregateLookupEdit.Properties.Buttons"))), resources.GetString("AggregateLookupEdit.Properties.Buttons1"), ((int)(resources.GetObject("AggregateLookupEdit.Properties.Buttons2"))), ((bool)(resources.GetObject("AggregateLookupEdit.Properties.Buttons3"))), ((bool)(resources.GetObject("AggregateLookupEdit.Properties.Buttons4"))), ((bool)(resources.GetObject("AggregateLookupEdit.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("AggregateLookupEdit.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("AggregateLookupEdit.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("AggregateLookupEdit.Properties.Buttons8"), ((object)(resources.GetObject("AggregateLookupEdit.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("AggregateLookupEdit.Properties.Buttons10"))), ((bool)(resources.GetObject("AggregateLookupEdit.Properties.Buttons11"))))});
            this.AggregateLookupEdit.Properties.DropDownRows = 13;
            this.AggregateLookupEdit.Properties.NullText = resources.GetString("AggregateLookupEdit.Properties.NullText");
            this.AggregateLookupEdit.Properties.PopupWidth = 200;
            this.AggregateLookupEdit.EditValueChanged += new System.EventHandler(this.cbAggregate_EditValueChanged);
            // 
            // AdministrativeUnitLookupEdit
            // 
            resources.ApplyResources(this.AdministrativeUnitLookupEdit, "AdministrativeUnitLookupEdit");
            this.AdministrativeUnitLookupEdit.Name = "AdministrativeUnitLookupEdit";
            this.AdministrativeUnitLookupEdit.Properties.Appearance.Options.UseFont = true;
            this.AdministrativeUnitLookupEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.AdministrativeUnitLookupEdit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.AdministrativeUnitLookupEdit.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.AdministrativeUnitLookupEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.AdministrativeUnitLookupEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject2.Options.UseFont = true;
            this.AdministrativeUnitLookupEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("AdministrativeUnitLookupEdit.Properties.Buttons"))), resources.GetString("AdministrativeUnitLookupEdit.Properties.Buttons1"), ((int)(resources.GetObject("AdministrativeUnitLookupEdit.Properties.Buttons2"))), ((bool)(resources.GetObject("AdministrativeUnitLookupEdit.Properties.Buttons3"))), ((bool)(resources.GetObject("AdministrativeUnitLookupEdit.Properties.Buttons4"))), ((bool)(resources.GetObject("AdministrativeUnitLookupEdit.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("AdministrativeUnitLookupEdit.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("AdministrativeUnitLookupEdit.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, resources.GetString("AdministrativeUnitLookupEdit.Properties.Buttons8"), ((object)(resources.GetObject("AdministrativeUnitLookupEdit.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("AdministrativeUnitLookupEdit.Properties.Buttons10"))), ((bool)(resources.GetObject("AdministrativeUnitLookupEdit.Properties.Buttons11"))))});
            this.AdministrativeUnitLookupEdit.Properties.DropDownRows = 5;
            this.AdministrativeUnitLookupEdit.Properties.NullText = resources.GetString("AdministrativeUnitLookupEdit.Properties.NullText");
            this.AdministrativeUnitLookupEdit.Properties.PopupWidth = 200;
            this.AdministrativeUnitLookupEdit.EditValueChanged += new System.EventHandler(this.cbAdministrativeUnit_EditValueChanged);
            // 
            // RefreshDataButton
            // 
            this.RefreshDataButton.ImageIndex = 1;
            this.RefreshDataButton.ImageList = this.ButtonsImageList;
            resources.ApplyResources(this.RefreshDataButton, "RefreshDataButton");
            this.RefreshDataButton.Name = "RefreshDataButton";
            this.RefreshDataButton.Tag = "{alwayseditable}";
            this.RefreshDataButton.Click += new System.EventHandler(this.RefreshDataButton_Click);
            // 
            // ButtonsImageList
            // 
            this.ButtonsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonsImageList.ImageStream")));
            this.ButtonsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ButtonsImageList.Images.SetKeyName(0, "filter_16x16.png");
            this.ButtonsImageList.Images.SetKeyName(1, "refresh_data_16x16.png");
            // 
            // EditFiltersButton
            // 
            this.EditFiltersButton.ImageIndex = 0;
            this.EditFiltersButton.ImageList = this.ButtonsImageList;
            resources.ApplyResources(this.EditFiltersButton, "EditFiltersButton");
            this.EditFiltersButton.Name = "EditFiltersButton";
            this.EditFiltersButton.Tag = "{alwayseditable}";
            this.EditFiltersButton.Click += new System.EventHandler(this.EditFiltersButton_Click);
            // 
            // ShowDataCheckEdit
            // 
            resources.ApplyResources(this.ShowDataCheckEdit, "ShowDataCheckEdit");
            this.ShowDataCheckEdit.Name = "ShowDataCheckEdit";
            this.ShowDataCheckEdit.Properties.Appearance.Options.UseFont = true;
            this.ShowDataCheckEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ShowDataCheckEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.ShowDataCheckEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ShowDataCheckEdit.Properties.Caption = resources.GetString("ShowDataCheckEdit.Properties.Caption");
            this.ShowDataCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.ShowDataCheckEdit.Tag = "{alwayseditable}";
            this.ShowDataCheckEdit.CheckedChanged += new System.EventHandler(this.ShowDataCheckEdit_CheckedChanged);
            // 
            // AdmUnitLabel
            // 
            resources.ApplyResources(this.AdmUnitLabel, "AdmUnitLabel");
            this.AdmUnitLabel.Name = "AdmUnitLabel";
            // 
            // ApplyFilterCheckEdit
            // 
            resources.ApplyResources(this.ApplyFilterCheckEdit, "ApplyFilterCheckEdit");
            this.ApplyFilterCheckEdit.Name = "ApplyFilterCheckEdit";
            this.ApplyFilterCheckEdit.Properties.Appearance.Options.UseFont = true;
            this.ApplyFilterCheckEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ApplyFilterCheckEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.ApplyFilterCheckEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ApplyFilterCheckEdit.Properties.Caption = resources.GetString("ApplyFilterCheckEdit.Properties.Caption");
            this.ApplyFilterCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.ApplyFilterCheckEdit.Tag = "{alwayseditable}";
            // 
            // AggregateLabel
            // 
            resources.ApplyResources(this.AggregateLabel, "AggregateLabel");
            this.AggregateLabel.Name = "AggregateLabel";
            // 
            // GroupIntervalLookupEdit
            // 
            resources.ApplyResources(this.GroupIntervalLookupEdit, "GroupIntervalLookupEdit");
            this.GroupIntervalLookupEdit.Name = "GroupIntervalLookupEdit";
            this.GroupIntervalLookupEdit.Properties.Appearance.Options.UseFont = true;
            this.GroupIntervalLookupEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.GroupIntervalLookupEdit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.GroupIntervalLookupEdit.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.GroupIntervalLookupEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.GroupIntervalLookupEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject3.Options.UseFont = true;
            this.GroupIntervalLookupEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("GroupIntervalLookupEdit.Properties.Buttons"))), resources.GetString("GroupIntervalLookupEdit.Properties.Buttons1"), ((int)(resources.GetObject("GroupIntervalLookupEdit.Properties.Buttons2"))), ((bool)(resources.GetObject("GroupIntervalLookupEdit.Properties.Buttons3"))), ((bool)(resources.GetObject("GroupIntervalLookupEdit.Properties.Buttons4"))), ((bool)(resources.GetObject("GroupIntervalLookupEdit.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("GroupIntervalLookupEdit.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("GroupIntervalLookupEdit.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, resources.GetString("GroupIntervalLookupEdit.Properties.Buttons8"), ((object)(resources.GetObject("GroupIntervalLookupEdit.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("GroupIntervalLookupEdit.Properties.Buttons10"))), ((bool)(resources.GetObject("GroupIntervalLookupEdit.Properties.Buttons11"))))});
            this.GroupIntervalLookupEdit.Properties.DropDownRows = 9;
            this.GroupIntervalLookupEdit.Properties.NullText = resources.GetString("GroupIntervalLookupEdit.Properties.NullText");
            this.GroupIntervalLookupEdit.Properties.PopupWidth = 200;
            this.GroupIntervalLookupEdit.EditValueChanged += new System.EventHandler(this.cbGroupInterval_EditValueChanged);
            // 
            // ShowMissedValuesCheckEdit
            // 
            resources.ApplyResources(this.ShowMissedValuesCheckEdit, "ShowMissedValuesCheckEdit");
            this.ShowMissedValuesCheckEdit.Name = "ShowMissedValuesCheckEdit";
            this.ShowMissedValuesCheckEdit.Properties.Appearance.Options.UseFont = true;
            this.ShowMissedValuesCheckEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ShowMissedValuesCheckEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.ShowMissedValuesCheckEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ShowMissedValuesCheckEdit.Properties.Caption = resources.GetString("ShowMissedValuesCheckEdit.Properties.Caption");
            this.ShowMissedValuesCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.ShowMissedValuesCheckEdit.Tag = "{alwayseditable}";
            this.ShowMissedValuesCheckEdit.CheckedChanged += new System.EventHandler(this.ShowMissedValuesCheckEdit_CheckedChanged);
            // 
            // DefaultGroupDateLabel
            // 
            resources.ApplyResources(this.DefaultGroupDateLabel, "DefaultGroupDateLabel");
            this.DefaultGroupDateLabel.Name = "DefaultGroupDateLabel";
            // 
            // ForDateLookupEdit
            // 
            resources.ApplyResources(this.ForDateLookupEdit, "ForDateLookupEdit");
            this.ForDateLookupEdit.Name = "ForDateLookupEdit";
            this.ForDateLookupEdit.Properties.Appearance.Options.UseFont = true;
            this.ForDateLookupEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ForDateLookupEdit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ForDateLookupEdit.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.ForDateLookupEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.ForDateLookupEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject4.Options.UseFont = true;
            this.ForDateLookupEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ForDateLookupEdit.Properties.Buttons"))), resources.GetString("ForDateLookupEdit.Properties.Buttons1"), ((int)(resources.GetObject("ForDateLookupEdit.Properties.Buttons2"))), ((bool)(resources.GetObject("ForDateLookupEdit.Properties.Buttons3"))), ((bool)(resources.GetObject("ForDateLookupEdit.Properties.Buttons4"))), ((bool)(resources.GetObject("ForDateLookupEdit.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("ForDateLookupEdit.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("ForDateLookupEdit.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, resources.GetString("ForDateLookupEdit.Properties.Buttons8"), ((object)(resources.GetObject("ForDateLookupEdit.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("ForDateLookupEdit.Properties.Buttons10"))), ((bool)(resources.GetObject("ForDateLookupEdit.Properties.Buttons11"))))});
            this.ForDateLookupEdit.Properties.DropDownRows = 5;
            this.ForDateLookupEdit.Properties.NullText = resources.GetString("ForDateLookupEdit.Properties.NullText");
            this.ForDateLookupEdit.Properties.PopupWidth = 200;
            this.ForDateLookupEdit.EditValueChanged += new System.EventHandler(this.cbForDate_EditValueChanged);
            // 
            // CompactLayoutCheckEdit
            // 
            resources.ApplyResources(this.CompactLayoutCheckEdit, "CompactLayoutCheckEdit");
            this.CompactLayoutCheckEdit.Name = "CompactLayoutCheckEdit";
            this.CompactLayoutCheckEdit.Properties.Appearance.Options.UseFont = true;
            this.CompactLayoutCheckEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.CompactLayoutCheckEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.CompactLayoutCheckEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.CompactLayoutCheckEdit.Properties.Caption = resources.GetString("CompactLayoutCheckEdit.Properties.Caption");
            this.CompactLayoutCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CompactLayoutCheckEdit.Tag = "{alwayseditable}";
            this.CompactLayoutCheckEdit.CheckedChanged += new System.EventHandler(this.CompactLayoutCheckEdit_CheckedChanged);
            // 
            // PrecisionSpinEdit
            // 
            resources.ApplyResources(this.PrecisionSpinEdit, "PrecisionSpinEdit");
            this.PrecisionSpinEdit.Name = "PrecisionSpinEdit";
            this.PrecisionSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("PrecisionSpinEdit.Properties.Buttons"))))});
            this.PrecisionSpinEdit.Properties.IsFloatValue = false;
            this.PrecisionSpinEdit.Properties.Mask.EditMask = resources.GetString("PrecisionSpinEdit.Properties.Mask.EditMask");
            this.PrecisionSpinEdit.Properties.MaxValue = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.PrecisionSpinEdit.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.PrecisionSpinEdit.EditValueChanged += new System.EventHandler(this.PrecisionSpinEdit_EditValueChanged);
            // 
            // SplitterPanel
            // 
            resources.ApplyResources(this.SplitterPanel, "SplitterPanel");
            this.SplitterPanel.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("SplitterPanel.Appearance.BackColor")));
            this.SplitterPanel.Appearance.Options.UseBackColor = true;
            this.SplitterPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.SplitterPanel.Name = "SplitterPanel";
            // 
            // FreezeRowHeadersCheckEdit
            // 
            resources.ApplyResources(this.FreezeRowHeadersCheckEdit, "FreezeRowHeadersCheckEdit");
            this.FreezeRowHeadersCheckEdit.Name = "FreezeRowHeadersCheckEdit";
            this.FreezeRowHeadersCheckEdit.Properties.Appearance.Options.UseFont = true;
            this.FreezeRowHeadersCheckEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.FreezeRowHeadersCheckEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.FreezeRowHeadersCheckEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.FreezeRowHeadersCheckEdit.Properties.Caption = resources.GetString("FreezeRowHeadersCheckEdit.Properties.Caption");
            this.FreezeRowHeadersCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.FreezeRowHeadersCheckEdit.Tag = "{alwayseditable}";
            this.FreezeRowHeadersCheckEdit.CheckedChanged += new System.EventHandler(this.FreezeRowHeadersCheckEdit_CheckedChanged);
            // 
            // DateFieldLabel
            // 
            resources.ApplyResources(this.DateFieldLabel, "DateFieldLabel");
            this.DateFieldLabel.Name = "DateFieldLabel";
            // 
            // PrecisionLabel
            // 
            resources.ApplyResources(this.PrecisionLabel, "PrecisionLabel");
            this.PrecisionLabel.Name = "PrecisionLabel";
            // 
            // AggregateColumnNameTextEdit
            // 
            resources.ApplyResources(this.AggregateColumnNameTextEdit, "AggregateColumnNameTextEdit");
            this.AggregateColumnNameTextEdit.Name = "AggregateColumnNameTextEdit";
            this.AggregateColumnNameTextEdit.Properties.Appearance.Options.UseFont = true;
            this.AggregateColumnNameTextEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.AggregateColumnNameTextEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.AggregateColumnNameTextEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.AggregateColumnNameTextEdit.Properties.ReadOnly = true;
            this.AggregateColumnNameTextEdit.Tag = "{R}";
            // 
            // ShowTotalsComboBoxEdit
            // 
            resources.ApplyResources(this.ShowTotalsComboBoxEdit, "ShowTotalsComboBoxEdit");
            this.ShowTotalsComboBoxEdit.Name = "ShowTotalsComboBoxEdit";
            this.ShowTotalsComboBoxEdit.Properties.AllowFocused = false;
            this.ShowTotalsComboBoxEdit.Properties.Appearance.Options.UseFont = true;
            this.ShowTotalsComboBoxEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ShowTotalsComboBoxEdit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ShowTotalsComboBoxEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.ShowTotalsComboBoxEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject5.Options.UseFont = true;
            this.ShowTotalsComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ShowTotalsComboBoxEdit.Properties.Buttons"))), resources.GetString("ShowTotalsComboBoxEdit.Properties.Buttons1"), ((int)(resources.GetObject("ShowTotalsComboBoxEdit.Properties.Buttons2"))), ((bool)(resources.GetObject("ShowTotalsComboBoxEdit.Properties.Buttons3"))), ((bool)(resources.GetObject("ShowTotalsComboBoxEdit.Properties.Buttons4"))), ((bool)(resources.GetObject("ShowTotalsComboBoxEdit.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("ShowTotalsComboBoxEdit.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("ShowTotalsComboBoxEdit.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, resources.GetString("ShowTotalsComboBoxEdit.Properties.Buttons8"), ((object)(resources.GetObject("ShowTotalsComboBoxEdit.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("ShowTotalsComboBoxEdit.Properties.Buttons10"))), ((bool)(resources.GetObject("ShowTotalsComboBoxEdit.Properties.Buttons11"))))});
            this.ShowTotalsComboBoxEdit.Properties.DropDownRows = 6;
            this.ShowTotalsComboBoxEdit.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("ShowTotalsComboBoxEdit.Properties.Items"), resources.GetString("ShowTotalsComboBoxEdit.Properties.Items1")),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("ShowTotalsComboBoxEdit.Properties.Items2"), resources.GetString("ShowTotalsComboBoxEdit.Properties.Items3")),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("ShowTotalsComboBoxEdit.Properties.Items4"), resources.GetString("ShowTotalsComboBoxEdit.Properties.Items5")),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("ShowTotalsComboBoxEdit.Properties.Items6"), resources.GetString("ShowTotalsComboBoxEdit.Properties.Items7")),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("ShowTotalsComboBoxEdit.Properties.Items8"), resources.GetString("ShowTotalsComboBoxEdit.Properties.Items9"))});
            this.ShowTotalsComboBoxEdit.Tag = "{alwayseditable}";
            this.ShowTotalsComboBoxEdit.EditValueChanged += new System.EventHandler(this.ShowTotalsComboBoxEdit_EditValueChanged);
            // 
            // ShowTotalsLabel
            // 
            resources.ApplyResources(this.ShowTotalsLabel, "ShowTotalsLabel");
            this.ShowTotalsLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.ShowTotalsLabel.Name = "ShowTotalsLabel";
            // 
            // ForDataFieldLabel
            // 
            resources.ApplyResources(this.ForDataFieldLabel, "ForDataFieldLabel");
            this.ForDataFieldLabel.Name = "ForDataFieldLabel";
            // 
            // PivotDetailPanel
            // 
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcMain);
            this.Controls.Add(this.nbControlSettings);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.HelpTopicID = "AVR_Pivot_Table";
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "PivotDetailPanel";
            this.Status = bv.common.win.FormStatus.Draft;
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).EndInit();
            this.grcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcGrid)).EndInit();
            this.grcGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbCustomization)).EndInit();
            this.nbCustomization.ResumeLayout(false);
            this.nbContainerCustomization.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcCustomization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbControlSettings)).EndInit();
            this.nbControlSettings.ResumeLayout(false);
            this.nbContainerSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcSettings)).EndInit();
            this.grcSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AggregateLookupEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdministrativeUnitLookupEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowDataCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyFilterCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupIntervalLookupEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowMissedValuesCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForDateLookupEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompactLayoutCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecisionSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitterPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FreezeRowHeadersCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AggregateColumnNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowTotalsComboBoxEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcMain;
        private DevExpress.XtraEditors.SplitterControl splitter;
        private DevExpress.XtraEditors.GroupControl grcCustomization;
        private DevExpress.XtraEditors.GroupControl grcGrid;
        private AvrPivotGrid pivotGrid;
        private DevExpress.XtraNavBar.NavBarControl nbCustomization;
        private DevExpress.XtraNavBar.NavBarGroup nbCustomizationGroup;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer nbContainerCustomization;
        private DevExpress.XtraEditors.TextEdit AggregateColumnNameTextEdit;
        private DevExpress.XtraEditors.LookUpEdit AggregateLookupEdit;
        private System.Windows.Forms.Label AggregateLabel;
        private DevExpress.XtraEditors.LookUpEdit GroupIntervalLookupEdit;
        private DevExpress.XtraEditors.LookUpEdit AdministrativeUnitLookupEdit;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ShowTotalsComboBoxEdit;
        private DevExpress.XtraEditors.LabelControl ShowTotalsLabel;
        
        internal PivotFilterControl filterControl;
        private DevExpress.XtraEditors.CheckEdit ApplyFilterCheckEdit;




        private DevExpress.XtraEditors.LookUpEdit ForDateLookupEdit;
        private DevExpress.XtraEditors.CheckEdit CompactLayoutCheckEdit;
        private DevExpress.XtraEditors.GroupControl grcSettings;
        
        private DevExpress.XtraEditors.SimpleButton EditFiltersButton;
        private System.Windows.Forms.Label DefaultGroupDateLabel;
        private DevExpress.XtraEditors.SimpleButton RefreshDataButton;
        private DevExpress.XtraNavBar.NavBarControl nbControlSettings;
        private DevExpress.XtraNavBar.NavBarGroup nbGroupSettings;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer nbContainerSettings;
        private DevExpress.XtraEditors.CheckEdit ShowMissedValuesCheckEdit;
        private DevExpress.XtraEditors.CheckEdit FreezeRowHeadersCheckEdit;
        private DevExpress.XtraEditors.CheckEdit ShowDataCheckEdit;
        private System.Windows.Forms.Label DateFieldLabel;
        private System.Windows.Forms.Label AdmUnitLabel;
        private System.Windows.Forms.Label PrecisionLabel;
        private System.Windows.Forms.Label ForDataFieldLabel;
        private DevExpress.XtraEditors.SpinEdit PrecisionSpinEdit;
        private DevExpress.XtraEditors.PanelControl SplitterPanel;
        private System.Windows.Forms.ImageList ButtonsImageList;
    }
}