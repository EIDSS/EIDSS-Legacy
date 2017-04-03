using System.Collections.Generic;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters.RamPivotGrid.PivotSummary;
using EIDSS.RAM_DB.Components;

namespace EIDSS.RAM.Layout
{
    partial class PivotForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PivotForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grcMain = new DevExpress.XtraEditors.GroupControl();
            this.grcGrid = new DevExpress.XtraEditors.GroupControl();
            this.grcPivot = new DevExpress.XtraEditors.GroupControl();
            this.pivotGrid = new EIDSS.RAM.Components.RamPivotGrid();
            this.pnFilter = new DevExpress.XtraEditors.PanelControl();
            this.chkApplyFilter = new DevExpress.XtraEditors.CheckEdit();
            this.btnValidateFilter = new DevExpress.XtraEditors.SimpleButton();
            this.tcLayoutDetails = new DevExpress.XtraTab.XtraTabControl();
            this.pageLayoutDetails = new DevExpress.XtraTab.XtraTabPage();
            this.grcLayout = new DevExpress.XtraEditors.GroupControl();
            this.tbDefaultLayoutName = new DevExpress.XtraEditors.TextEdit();
            this.tbLayoutName = new DevExpress.XtraEditors.TextEdit();
            this.lblLayoutName = new System.Windows.Forms.Label();
            this.memDescription = new DevExpress.XtraEditors.MemoEdit();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblLayoutDefaultName = new System.Windows.Forms.Label();
            this.pageAdditionalSettings = new DevExpress.XtraTab.XtraTabPage();
            this.grcSettings = new DevExpress.XtraEditors.GroupControl();
            this.ceUseArchiveData = new DevExpress.XtraEditors.CheckEdit();
            this.ceCompactLayout = new DevExpress.XtraEditors.CheckEdit();
            this.DeleteFieldsCopyButton = new DevExpress.XtraEditors.SimpleButton();
            this.CreateFieldsCopyButton = new DevExpress.XtraEditors.SimpleButton();
            this.cbAggregate = new DevExpress.XtraEditors.LookUpEdit();
            this.cbForDate = new DevExpress.XtraEditors.LookUpEdit();
            this.cbDenominator = new DevExpress.XtraEditors.LookUpEdit();
            this.lblShowTotals = new DevExpress.XtraEditors.LabelControl();
            this.ccbShowTotals = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.cbAdministrativeUnit = new DevExpress.XtraEditors.LookUpEdit();
            this.lblAggregate = new System.Windows.Forms.Label();
            this.ceShareLayout = new DevExpress.XtraEditors.CheckEdit();
            this.tbAggregateColumnName = new DevExpress.XtraEditors.TextEdit();
            this.cbGroupInterval = new DevExpress.XtraEditors.LookUpEdit();
            this.lblForColumn = new System.Windows.Forms.Label();
            this.lblGroupInterval = new System.Windows.Forms.Label();
            this.lblAdministrativeUnit = new System.Windows.Forms.Label();
            this.lblDenominator = new System.Windows.Forms.Label();
            this.lblForDate = new System.Windows.Forms.Label();
            this.pageFilter = new DevExpress.XtraTab.XtraTabPage();
            this.filterControl = new DevExpress.XtraEditors.FilterControl();
            this.splitter = new DevExpress.XtraEditors.SplitterControl();
            this.nbCustomization = new DevExpress.XtraNavBar.NavBarControl();
            this.nbCustomizationGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbContainerCustomization = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.grcCustomization = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).BeginInit();
            this.grcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcGrid)).BeginInit();
            this.grcGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcPivot)).BeginInit();
            this.grcPivot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnFilter)).BeginInit();
            this.pnFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkApplyFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcLayoutDetails)).BeginInit();
            this.tcLayoutDetails.SuspendLayout();
            this.pageLayoutDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcLayout)).BeginInit();
            this.grcLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDefaultLayoutName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLayoutName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            this.pageAdditionalSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcSettings)).BeginInit();
            this.grcSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceCompactLayout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAggregate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbForDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDenominator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbShowTotals.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAdministrativeUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceShareLayout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAggregateColumnName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGroupInterval.Properties)).BeginInit();
            this.pageFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbCustomization)).BeginInit();
            this.nbCustomization.SuspendLayout();
            this.nbContainerCustomization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcCustomization)).BeginInit();
            this.SuspendLayout();
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
            this.grcGrid.Controls.Add(this.grcPivot);
            this.grcGrid.Controls.Add(this.tcLayoutDetails);
            resources.ApplyResources(this.grcGrid, "grcGrid");
            this.grcGrid.Name = "grcGrid";
            this.grcGrid.ShowCaption = false;
            // 
            // grcPivot
            // 
            this.grcPivot.Appearance.Options.UseFont = true;
            this.grcPivot.AppearanceCaption.Options.UseFont = true;
            this.grcPivot.Controls.Add(this.pivotGrid);
            this.grcPivot.Controls.Add(this.pnFilter);
            resources.ApplyResources(this.grcPivot, "grcPivot");
            this.grcPivot.Name = "grcPivot";
            // 
            // pivotGrid
            // 
            this.pivotGrid.Appearance.Cell.Options.UseFont = true;
            this.pivotGrid.Appearance.Cell.Options.UseTextOptions = true;
            this.pivotGrid.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
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
            this.pivotGrid.OptionsBehavior.HorizontalScrolling = DevExpress.XtraPivotGrid.PivotGridScrolling.Control;
            this.pivotGrid.OptionsCustomization.AllowPrefilter = false;
            this.pivotGrid.OptionsMenu.EnableHeaderAreaMenu = false;
            this.pivotGrid.OptionsMenu.EnableHeaderMenu = false;
            this.pivotGrid.OptionsPrint.UsePrintAppearance = true;
            this.pivotGrid.CellClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pivotGrid_CellClick);
            this.pivotGrid.FocusedCellChanged += new System.EventHandler(this.pivotGrid_FocusedCellChanged);
            this.pivotGrid.CellSelectionChanged += new System.EventHandler(this.pivotGrid_CellSelectionChanged);
            // 
            // pnFilter
            // 
            this.pnFilter.Appearance.Options.UseFont = true;
            this.pnFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnFilter.Controls.Add(this.chkApplyFilter);
            this.pnFilter.Controls.Add(this.btnValidateFilter);
            resources.ApplyResources(this.pnFilter, "pnFilter");
            this.pnFilter.Name = "pnFilter";
            // 
            // chkApplyFilter
            // 
            resources.ApplyResources(this.chkApplyFilter, "chkApplyFilter");
            this.chkApplyFilter.Name = "chkApplyFilter";
            this.chkApplyFilter.Properties.Appearance.Options.UseFont = true;
            this.chkApplyFilter.Properties.AppearanceDisabled.Options.UseFont = true;
            this.chkApplyFilter.Properties.AppearanceFocused.Options.UseFont = true;
            this.chkApplyFilter.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.chkApplyFilter.Properties.Caption = resources.GetString("chkApplyFilter.Properties.Caption");
            this.chkApplyFilter.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.chkApplyFilter.Tag = "{alwayseditable}";
            // 
            // btnValidateFilter
            // 
            this.btnValidateFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.btnValidateFilter, "btnValidateFilter");
            this.btnValidateFilter.Image = global::EIDSS.RAM.Properties.Resources.validate2;
            this.btnValidateFilter.Name = "btnValidateFilter";
            this.btnValidateFilter.Tag = "{alwayseditable}";
            this.btnValidateFilter.Click += new System.EventHandler(this.btnValidateFilter_Click);
            // 
            // tcLayoutDetails
            // 
            this.tcLayoutDetails.Appearance.Options.UseFont = true;
            this.tcLayoutDetails.AppearancePage.Header.Options.UseFont = true;
            this.tcLayoutDetails.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tcLayoutDetails.AppearancePage.HeaderDisabled.Options.UseFont = true;
            this.tcLayoutDetails.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            this.tcLayoutDetails.AppearancePage.PageClient.Options.UseFont = true;
            resources.ApplyResources(this.tcLayoutDetails, "tcLayoutDetails");
            this.tcLayoutDetails.Name = "tcLayoutDetails";
            this.tcLayoutDetails.SelectedTabPage = this.pageLayoutDetails;
            this.tcLayoutDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageLayoutDetails,
            this.pageAdditionalSettings,
            this.pageFilter});
            // 
            // pageLayoutDetails
            // 
            this.pageLayoutDetails.Appearance.Header.Options.UseFont = true;
            this.pageLayoutDetails.Appearance.HeaderActive.Options.UseFont = true;
            this.pageLayoutDetails.Appearance.HeaderDisabled.Options.UseFont = true;
            this.pageLayoutDetails.Appearance.HeaderHotTracked.Options.UseFont = true;
            this.pageLayoutDetails.Appearance.PageClient.Options.UseFont = true;
            this.pageLayoutDetails.Controls.Add(this.grcLayout);
            this.pageLayoutDetails.Name = "pageLayoutDetails";
            resources.ApplyResources(this.pageLayoutDetails, "pageLayoutDetails");
            // 
            // grcLayout
            // 
            this.grcLayout.Appearance.Options.UseFont = true;
            this.grcLayout.AppearanceCaption.Options.UseFont = true;
            this.grcLayout.Controls.Add(this.tbDefaultLayoutName);
            this.grcLayout.Controls.Add(this.tbLayoutName);
            this.grcLayout.Controls.Add(this.lblLayoutName);
            this.grcLayout.Controls.Add(this.memDescription);
            this.grcLayout.Controls.Add(this.lblDescription);
            this.grcLayout.Controls.Add(this.lblLayoutDefaultName);
            resources.ApplyResources(this.grcLayout, "grcLayout");
            this.grcLayout.Name = "grcLayout";
            this.grcLayout.ShowCaption = false;
            // 
            // tbDefaultLayoutName
            // 
            resources.ApplyResources(this.tbDefaultLayoutName, "tbDefaultLayoutName");
            this.tbDefaultLayoutName.Name = "tbDefaultLayoutName";
            this.tbDefaultLayoutName.Properties.Appearance.Options.UseFont = true;
            this.tbDefaultLayoutName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.tbDefaultLayoutName.Properties.AppearanceFocused.Options.UseFont = true;
            this.tbDefaultLayoutName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.tbDefaultLayoutName.Tag = "{M}[en]";
            this.tbDefaultLayoutName.EditValueChanged += new System.EventHandler(this.tbDefaultLayoutName_EditValueChanged);
            this.tbDefaultLayoutName.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.tbDefaultLayoutName_EditValueChanging);
            // 
            // tbLayoutName
            // 
            resources.ApplyResources(this.tbLayoutName, "tbLayoutName");
            this.tbLayoutName.Name = "tbLayoutName";
            this.tbLayoutName.Properties.Appearance.Options.UseFont = true;
            this.tbLayoutName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.tbLayoutName.Properties.AppearanceFocused.Options.UseFont = true;
            this.tbLayoutName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.tbLayoutName.Tag = "{M}";
            this.tbLayoutName.EditValueChanged += new System.EventHandler(this.tbLayoutName_EditValueChanged);
            // 
            // lblLayoutName
            // 
            resources.ApplyResources(this.lblLayoutName, "lblLayoutName");
            this.lblLayoutName.Name = "lblLayoutName";
            // 
            // memDescription
            // 
            resources.ApplyResources(this.memDescription, "memDescription");
            this.memDescription.Name = "memDescription";
            this.memDescription.Properties.Appearance.Options.UseFont = true;
            this.memDescription.Properties.AppearanceDisabled.Options.UseFont = true;
            this.memDescription.Properties.AppearanceFocused.Options.UseFont = true;
            this.memDescription.Properties.AppearanceReadOnly.Options.UseFont = true;
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // lblLayoutDefaultName
            // 
            resources.ApplyResources(this.lblLayoutDefaultName, "lblLayoutDefaultName");
            this.lblLayoutDefaultName.Name = "lblLayoutDefaultName";
            // 
            // pageAdditionalSettings
            // 
            this.pageAdditionalSettings.Appearance.Header.Options.UseFont = true;
            this.pageAdditionalSettings.Appearance.HeaderActive.Options.UseFont = true;
            this.pageAdditionalSettings.Appearance.HeaderDisabled.Options.UseFont = true;
            this.pageAdditionalSettings.Appearance.HeaderHotTracked.Options.UseFont = true;
            this.pageAdditionalSettings.Appearance.PageClient.Options.UseFont = true;
            this.pageAdditionalSettings.Controls.Add(this.grcSettings);
            this.pageAdditionalSettings.Name = "pageAdditionalSettings";
            resources.ApplyResources(this.pageAdditionalSettings, "pageAdditionalSettings");
            // 
            // grcSettings
            // 
            this.grcSettings.Appearance.Options.UseFont = true;
            this.grcSettings.AppearanceCaption.Options.UseFont = true;
            this.grcSettings.Controls.Add(this.ceUseArchiveData);
            this.grcSettings.Controls.Add(this.ceCompactLayout);
            this.grcSettings.Controls.Add(this.DeleteFieldsCopyButton);
            this.grcSettings.Controls.Add(this.CreateFieldsCopyButton);
            this.grcSettings.Controls.Add(this.cbAggregate);
            this.grcSettings.Controls.Add(this.cbForDate);
            this.grcSettings.Controls.Add(this.cbDenominator);
            this.grcSettings.Controls.Add(this.lblShowTotals);
            this.grcSettings.Controls.Add(this.ccbShowTotals);
            this.grcSettings.Controls.Add(this.cbAdministrativeUnit);
            this.grcSettings.Controls.Add(this.lblAggregate);
            this.grcSettings.Controls.Add(this.ceShareLayout);
            this.grcSettings.Controls.Add(this.tbAggregateColumnName);
            this.grcSettings.Controls.Add(this.cbGroupInterval);
            this.grcSettings.Controls.Add(this.lblForColumn);
            this.grcSettings.Controls.Add(this.lblGroupInterval);
            this.grcSettings.Controls.Add(this.lblAdministrativeUnit);
            this.grcSettings.Controls.Add(this.lblDenominator);
            this.grcSettings.Controls.Add(this.lblForDate);
            resources.ApplyResources(this.grcSettings, "grcSettings");
            this.grcSettings.Name = "grcSettings";
            this.grcSettings.ShowCaption = false;
            // 
            // ceUseArchiveData
            // 
            resources.ApplyResources(this.ceUseArchiveData, "ceUseArchiveData");
            this.ceUseArchiveData.Name = "ceUseArchiveData";
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ceUseArchiveData.Properties.Caption = resources.GetString("ceUseArchiveData.Properties.Caption");
            this.ceUseArchiveData.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.ceUseArchiveData.Tag = "{alwayseditable}";
            this.ceUseArchiveData.CheckedChanged += new System.EventHandler(this.ceUseArchiveData_CheckedChanged);
            // 
            // ceCompactLayout
            // 
            resources.ApplyResources(this.ceCompactLayout, "ceCompactLayout");
            this.ceCompactLayout.Name = "ceCompactLayout";
            this.ceCompactLayout.Properties.Appearance.Options.UseFont = true;
            this.ceCompactLayout.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceCompactLayout.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceCompactLayout.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ceCompactLayout.Properties.Caption = resources.GetString("ceCompactLayout.Properties.Caption");
            this.ceCompactLayout.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.ceCompactLayout.Tag = "{alwayseditable}";
            this.ceCompactLayout.CheckedChanged += new System.EventHandler(this.ceCompactLayout_CheckedChanged);
            // 
            // DeleteFieldsCopyButton
            // 
            resources.ApplyResources(this.DeleteFieldsCopyButton, "DeleteFieldsCopyButton");
            this.DeleteFieldsCopyButton.Image = global::EIDSS.RAM.Properties.Resources.deleted_small;
            this.DeleteFieldsCopyButton.Name = "DeleteFieldsCopyButton";
            this.DeleteFieldsCopyButton.Click += new System.EventHandler(this.DeleteFieldsCopyButton_Click);
            // 
            // CreateFieldsCopyButton
            // 
            resources.ApplyResources(this.CreateFieldsCopyButton, "CreateFieldsCopyButton");
            this.CreateFieldsCopyButton.Image = global::EIDSS.RAM.Properties.Resources.plus;
            this.CreateFieldsCopyButton.Name = "CreateFieldsCopyButton";
            this.CreateFieldsCopyButton.Click += new System.EventHandler(this.CreateFieldsCopyButton_Click);
            // 
            // cbAggregate
            // 
            resources.ApplyResources(this.cbAggregate, "cbAggregate");
            this.cbAggregate.Name = "cbAggregate";
            this.cbAggregate.Properties.Appearance.Options.UseFont = true;
            this.cbAggregate.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbAggregate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbAggregate.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbAggregate.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbAggregate.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject1.Options.UseFont = true;
            this.cbAggregate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbAggregate.Properties.Buttons"))), resources.GetString("cbAggregate.Properties.Buttons1"), ((int)(resources.GetObject("cbAggregate.Properties.Buttons2"))), ((bool)(resources.GetObject("cbAggregate.Properties.Buttons3"))), ((bool)(resources.GetObject("cbAggregate.Properties.Buttons4"))), ((bool)(resources.GetObject("cbAggregate.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbAggregate.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbAggregate.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("cbAggregate.Properties.Buttons8"), ((object)(resources.GetObject("cbAggregate.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbAggregate.Properties.Buttons10"))), ((bool)(resources.GetObject("cbAggregate.Properties.Buttons11"))))});
            this.cbAggregate.Properties.DropDownRows = 13;
            this.cbAggregate.Properties.NullText = resources.GetString("cbAggregate.Properties.NullText");
            this.cbAggregate.Properties.PopupWidth = 200;
            this.cbAggregate.EditValueChanged += new System.EventHandler(this.cbAggregate_EditValueChanged);
            // 
            // cbForDate
            // 
            resources.ApplyResources(this.cbForDate, "cbForDate");
            this.cbForDate.Name = "cbForDate";
            this.cbForDate.Properties.Appearance.Options.UseFont = true;
            this.cbForDate.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbForDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbForDate.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbForDate.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbForDate.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject2.Options.UseFont = true;
            this.cbForDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbForDate.Properties.Buttons"))), resources.GetString("cbForDate.Properties.Buttons1"), ((int)(resources.GetObject("cbForDate.Properties.Buttons2"))), ((bool)(resources.GetObject("cbForDate.Properties.Buttons3"))), ((bool)(resources.GetObject("cbForDate.Properties.Buttons4"))), ((bool)(resources.GetObject("cbForDate.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbForDate.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbForDate.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, resources.GetString("cbForDate.Properties.Buttons8"), ((object)(resources.GetObject("cbForDate.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbForDate.Properties.Buttons10"))), ((bool)(resources.GetObject("cbForDate.Properties.Buttons11"))))});
            this.cbForDate.Properties.DropDownRows = 5;
            this.cbForDate.Properties.NullText = resources.GetString("cbForDate.Properties.NullText");
            this.cbForDate.Properties.PopupWidth = 200;
            this.cbForDate.EditValueChanged += new System.EventHandler(this.cbForDate_EditValueChanged);
            // 
            // cbDenominator
            // 
            resources.ApplyResources(this.cbDenominator, "cbDenominator");
            this.cbDenominator.Name = "cbDenominator";
            this.cbDenominator.Properties.Appearance.Options.UseFont = true;
            this.cbDenominator.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbDenominator.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbDenominator.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbDenominator.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbDenominator.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject3.Options.UseFont = true;
            this.cbDenominator.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbDenominator.Properties.Buttons"))), resources.GetString("cbDenominator.Properties.Buttons1"), ((int)(resources.GetObject("cbDenominator.Properties.Buttons2"))), ((bool)(resources.GetObject("cbDenominator.Properties.Buttons3"))), ((bool)(resources.GetObject("cbDenominator.Properties.Buttons4"))), ((bool)(resources.GetObject("cbDenominator.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbDenominator.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbDenominator.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, resources.GetString("cbDenominator.Properties.Buttons8"), ((object)(resources.GetObject("cbDenominator.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbDenominator.Properties.Buttons10"))), ((bool)(resources.GetObject("cbDenominator.Properties.Buttons11"))))});
            this.cbDenominator.Properties.DropDownRows = 5;
            this.cbDenominator.Properties.NullText = resources.GetString("cbDenominator.Properties.NullText");
            this.cbDenominator.Properties.PopupWidth = 200;
            this.cbDenominator.EditValueChanged += new System.EventHandler(this.cbDenominator_EditValueChanged);
            // 
            // lblShowTotals
            // 
            this.lblShowTotals.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblShowTotals, "lblShowTotals");
            this.lblShowTotals.Name = "lblShowTotals";
            // 
            // ccbShowTotals
            // 
            resources.ApplyResources(this.ccbShowTotals, "ccbShowTotals");
            this.ccbShowTotals.Name = "ccbShowTotals";
            this.ccbShowTotals.Properties.AllowFocused = false;
            this.ccbShowTotals.Properties.Appearance.Options.UseFont = true;
            this.ccbShowTotals.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ccbShowTotals.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ccbShowTotals.Properties.AppearanceFocused.Options.UseFont = true;
            this.ccbShowTotals.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject4.Options.UseFont = true;
            this.ccbShowTotals.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ccbShowTotals.Properties.Buttons"))), resources.GetString("ccbShowTotals.Properties.Buttons1"), ((int)(resources.GetObject("ccbShowTotals.Properties.Buttons2"))), ((bool)(resources.GetObject("ccbShowTotals.Properties.Buttons3"))), ((bool)(resources.GetObject("ccbShowTotals.Properties.Buttons4"))), ((bool)(resources.GetObject("ccbShowTotals.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("ccbShowTotals.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("ccbShowTotals.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, resources.GetString("ccbShowTotals.Properties.Buttons8"), ((object)(resources.GetObject("ccbShowTotals.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("ccbShowTotals.Properties.Buttons10"))), ((bool)(resources.GetObject("ccbShowTotals.Properties.Buttons11"))))});
            this.ccbShowTotals.Properties.DropDownRows = 6;
            this.ccbShowTotals.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("ccbShowTotals.Properties.Items"), resources.GetString("ccbShowTotals.Properties.Items1")),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("ccbShowTotals.Properties.Items2"), resources.GetString("ccbShowTotals.Properties.Items3")),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("ccbShowTotals.Properties.Items4"), resources.GetString("ccbShowTotals.Properties.Items5")),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("ccbShowTotals.Properties.Items6"), resources.GetString("ccbShowTotals.Properties.Items7")),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("ccbShowTotals.Properties.Items8"), resources.GetString("ccbShowTotals.Properties.Items9"))});
            this.ccbShowTotals.Tag = "{alwayseditable}";
            this.ccbShowTotals.EditValueChanged += new System.EventHandler(this.ccbShowTotals_EditValueChanged);
            // 
            // cbAdministrativeUnit
            // 
            resources.ApplyResources(this.cbAdministrativeUnit, "cbAdministrativeUnit");
            this.cbAdministrativeUnit.Name = "cbAdministrativeUnit";
            this.cbAdministrativeUnit.Properties.Appearance.Options.UseFont = true;
            this.cbAdministrativeUnit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbAdministrativeUnit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbAdministrativeUnit.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbAdministrativeUnit.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbAdministrativeUnit.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject5.Options.UseFont = true;
            this.cbAdministrativeUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbAdministrativeUnit.Properties.Buttons"))), resources.GetString("cbAdministrativeUnit.Properties.Buttons1"), ((int)(resources.GetObject("cbAdministrativeUnit.Properties.Buttons2"))), ((bool)(resources.GetObject("cbAdministrativeUnit.Properties.Buttons3"))), ((bool)(resources.GetObject("cbAdministrativeUnit.Properties.Buttons4"))), ((bool)(resources.GetObject("cbAdministrativeUnit.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbAdministrativeUnit.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbAdministrativeUnit.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, resources.GetString("cbAdministrativeUnit.Properties.Buttons8"), ((object)(resources.GetObject("cbAdministrativeUnit.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbAdministrativeUnit.Properties.Buttons10"))), ((bool)(resources.GetObject("cbAdministrativeUnit.Properties.Buttons11"))))});
            this.cbAdministrativeUnit.Properties.DropDownRows = 5;
            this.cbAdministrativeUnit.Properties.NullText = resources.GetString("cbAdministrativeUnit.Properties.NullText");
            this.cbAdministrativeUnit.Properties.PopupWidth = 200;
            this.cbAdministrativeUnit.EditValueChanged += new System.EventHandler(this.cbAdministrativeUnit_EditValueChanged);
            // 
            // lblAggregate
            // 
            resources.ApplyResources(this.lblAggregate, "lblAggregate");
            this.lblAggregate.Name = "lblAggregate";
            // 
            // ceShareLayout
            // 
            resources.ApplyResources(this.ceShareLayout, "ceShareLayout");
            this.ceShareLayout.Name = "ceShareLayout";
            this.ceShareLayout.Properties.Appearance.Options.UseFont = true;
            this.ceShareLayout.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceShareLayout.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceShareLayout.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ceShareLayout.Properties.Caption = resources.GetString("ceShareLayout.Properties.Caption");
            this.ceShareLayout.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.ceShareLayout.CheckedChanged += new System.EventHandler(this.ceShareLayout_CheckedChanged);
            // 
            // tbAggregateColumnName
            // 
            resources.ApplyResources(this.tbAggregateColumnName, "tbAggregateColumnName");
            this.tbAggregateColumnName.Name = "tbAggregateColumnName";
            this.tbAggregateColumnName.Properties.Appearance.Options.UseFont = true;
            this.tbAggregateColumnName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.tbAggregateColumnName.Properties.AppearanceFocused.Options.UseFont = true;
            this.tbAggregateColumnName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.tbAggregateColumnName.Properties.ReadOnly = true;
            this.tbAggregateColumnName.Tag = "{R}";
            // 
            // cbGroupInterval
            // 
            resources.ApplyResources(this.cbGroupInterval, "cbGroupInterval");
            this.cbGroupInterval.Name = "cbGroupInterval";
            this.cbGroupInterval.Properties.Appearance.Options.UseFont = true;
            this.cbGroupInterval.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbGroupInterval.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbGroupInterval.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbGroupInterval.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbGroupInterval.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject6.Options.UseFont = true;
            this.cbGroupInterval.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbGroupInterval.Properties.Buttons"))), resources.GetString("cbGroupInterval.Properties.Buttons1"), ((int)(resources.GetObject("cbGroupInterval.Properties.Buttons2"))), ((bool)(resources.GetObject("cbGroupInterval.Properties.Buttons3"))), ((bool)(resources.GetObject("cbGroupInterval.Properties.Buttons4"))), ((bool)(resources.GetObject("cbGroupInterval.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbGroupInterval.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbGroupInterval.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, resources.GetString("cbGroupInterval.Properties.Buttons8"), ((object)(resources.GetObject("cbGroupInterval.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbGroupInterval.Properties.Buttons10"))), ((bool)(resources.GetObject("cbGroupInterval.Properties.Buttons11"))))});
            this.cbGroupInterval.Properties.DropDownRows = 9;
            this.cbGroupInterval.Properties.NullText = resources.GetString("cbGroupInterval.Properties.NullText");
            this.cbGroupInterval.Properties.PopupWidth = 200;
            this.cbGroupInterval.EditValueChanged += new System.EventHandler(this.cbGroupInterval_EditValueChanged);
            // 
            // lblForColumn
            // 
            resources.ApplyResources(this.lblForColumn, "lblForColumn");
            this.lblForColumn.Name = "lblForColumn";
            // 
            // lblGroupInterval
            // 
            resources.ApplyResources(this.lblGroupInterval, "lblGroupInterval");
            this.lblGroupInterval.Name = "lblGroupInterval";
            // 
            // lblAdministrativeUnit
            // 
            resources.ApplyResources(this.lblAdministrativeUnit, "lblAdministrativeUnit");
            this.lblAdministrativeUnit.Name = "lblAdministrativeUnit";
            // 
            // lblDenominator
            // 
            resources.ApplyResources(this.lblDenominator, "lblDenominator");
            this.lblDenominator.Name = "lblDenominator";
            // 
            // lblForDate
            // 
            resources.ApplyResources(this.lblForDate, "lblForDate");
            this.lblForDate.Name = "lblForDate";
            // 
            // pageFilter
            // 
            this.pageFilter.Appearance.Header.Options.UseFont = true;
            this.pageFilter.Appearance.HeaderActive.Options.UseFont = true;
            this.pageFilter.Appearance.HeaderDisabled.Options.UseFont = true;
            this.pageFilter.Appearance.HeaderHotTracked.Options.UseFont = true;
            this.pageFilter.Appearance.PageClient.Options.UseFont = true;
            this.pageFilter.Controls.Add(this.filterControl);
            this.pageFilter.Name = "pageFilter";
            resources.ApplyResources(this.pageFilter, "pageFilter");
            // 
            // filterControl
            // 
            this.filterControl.Appearance.Options.UseFont = true;
            this.filterControl.AppearanceTreeLine.Options.UseFont = true;
            this.filterControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.filterControl, "filterControl");
            this.filterControl.Name = "filterControl";
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
            resources.ApplyResources(this.grcCustomization, "grcCustomization");
            this.grcCustomization.Name = "grcCustomization";
            this.grcCustomization.ShowCaption = false;
            // 
            // PivotForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcMain);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.HelpTopicID = "AVR_Pivot_Table";
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "PivotForm";
            this.Status = bv.common.win.FormStatus.Draft;
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).EndInit();
            this.grcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcGrid)).EndInit();
            this.grcGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcPivot)).EndInit();
            this.grcPivot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnFilter)).EndInit();
            this.pnFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkApplyFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcLayoutDetails)).EndInit();
            this.tcLayoutDetails.ResumeLayout(false);
            this.pageLayoutDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcLayout)).EndInit();
            this.grcLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbDefaultLayoutName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLayoutName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            this.pageAdditionalSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcSettings)).EndInit();
            this.grcSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceCompactLayout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAggregate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbForDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDenominator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbShowTotals.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAdministrativeUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceShareLayout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAggregateColumnName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGroupInterval.Properties)).EndInit();
            this.pageFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nbCustomization)).EndInit();
            this.nbCustomization.ResumeLayout(false);
            this.nbContainerCustomization.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcCustomization)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcMain;
        private DevExpress.XtraEditors.SplitterControl splitter;
        private DevExpress.XtraEditors.GroupControl grcCustomization;
        private DevExpress.XtraEditors.GroupControl grcGrid;
        
        private DevExpress.XtraEditors.GroupControl grcLayout;
        private RamPivotGrid pivotGrid;
        private System.Windows.Forms.Label lblLayoutDefaultName;
        private DevExpress.XtraEditors.TextEdit tbDefaultLayoutName;
        private DevExpress.XtraNavBar.NavBarControl nbCustomization;
        private DevExpress.XtraNavBar.NavBarGroup nbCustomizationGroup;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer nbContainerCustomization;
        private DevExpress.XtraEditors.CheckEdit ceShareLayout;
        private DevExpress.XtraEditors.TextEdit tbAggregateColumnName;
        private System.Windows.Forms.Label lblForColumn;
        private DevExpress.XtraEditors.LookUpEdit cbAggregate;
        private System.Windows.Forms.Label lblAggregate;
        private System.Windows.Forms.Label lblGroupInterval;
        private DevExpress.XtraEditors.LookUpEdit cbGroupInterval;
        private DevExpress.XtraEditors.GroupControl grcSettings;
        private DevExpress.XtraEditors.MemoEdit memDescription;
        private System.Windows.Forms.Label lblDescription;
        private DevExpress.XtraTab.XtraTabControl tcLayoutDetails;
        private DevExpress.XtraTab.XtraTabPage pageLayoutDetails;
        private DevExpress.XtraTab.XtraTabPage pageAdditionalSettings;
        private DevExpress.XtraEditors.TextEdit tbLayoutName;
        private System.Windows.Forms.Label lblLayoutName;
        private System.Windows.Forms.Label lblAdministrativeUnit;
        private DevExpress.XtraEditors.LookUpEdit cbAdministrativeUnit;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ccbShowTotals;
        private DevExpress.XtraEditors.LabelControl lblShowTotals;
        private DevExpress.XtraEditors.GroupControl grcPivot;
        private DevExpress.XtraEditors.PanelControl pnFilter;
        private DevExpress.XtraTab.XtraTabPage pageFilter;
        internal DevExpress.XtraEditors.FilterControl filterControl;
        private DevExpress.XtraEditors.CheckEdit chkApplyFilter;
        
        private DevExpress.XtraEditors.SimpleButton btnValidateFilter;
        
        
        private System.Windows.Forms.Label lblDenominator;
        private DevExpress.XtraEditors.LookUpEdit cbDenominator;
        private DevExpress.XtraEditors.LookUpEdit cbForDate;
        private System.Windows.Forms.Label lblForDate;
        private DevExpress.XtraEditors.CheckEdit ceCompactLayout;
        private DevExpress.XtraEditors.SimpleButton DeleteFieldsCopyButton;
        private DevExpress.XtraEditors.SimpleButton CreateFieldsCopyButton;
        
        private DevExpress.XtraEditors.CheckEdit ceUseArchiveData;
    }
}