namespace eidss.winclient.AggregateCase
{
    partial class AggregateSummaryHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AggregateSummaryHeader));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.CaseGrid = new DevExpress.XtraGrid.GridControl();
            this.CaseView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.RemoveAllButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.cbAdminLevel = new DevExpress.XtraEditors.LookUpEdit();
            this.cbTimeInterval = new DevExpress.XtraEditors.LookUpEdit();
            this.RemoveButton = new DevExpress.XtraEditors.SimpleButton();
            this.EditButton = new DevExpress.XtraEditors.SimpleButton();
            this.NewButton = new DevExpress.XtraEditors.SimpleButton();
            this.SelectButton = new DevExpress.XtraEditors.SimpleButton();
            this.MainGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.SettingsGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.AdministrativeLevelItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.TimeIntervalItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.SelectedCasesGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.CasesGridItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptyItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.NewButtonItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.EditButtonItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.SelectButtonItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.RemoveButtonItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.RemoveAllButtonItem = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.CaseGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaseView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAdminLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTimeInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdministrativeLevelItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeIntervalItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedCasesGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CasesGridItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptyItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewButtonItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditButtonItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectButtonItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemoveButtonItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemoveAllButtonItem)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(AggregateSummaryHeader), out resources);
            // Form Is Localizable: True
            // 
            // CaseGrid
            // 
            resources.ApplyResources(this.CaseGrid, "CaseGrid");
            this.CaseGrid.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.CaseGrid.MainView = this.CaseView;
            this.CaseGrid.Name = "CaseGrid";
            this.CaseGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CaseView});
            // 
            // CaseView
            // 
            this.CaseView.GridControl = this.CaseGrid;
            this.CaseView.Name = "CaseView";
            this.CaseView.OptionsBehavior.Editable = false;
            this.CaseView.OptionsBehavior.ReadOnly = true;
            this.CaseView.OptionsDetail.EnableMasterViewMode = false;
            this.CaseView.OptionsSelection.MultiSelect = true;
            this.CaseView.OptionsView.ShowDetailButtons = false;
            this.CaseView.OptionsView.ShowGroupPanel = false;
            this.CaseView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.CaseView_SelectionChanged);
            this.CaseView.RowCountChanged += new System.EventHandler(this.CaseView_RowCountChanged);
            // 
            // RemoveAllButton
            // 
            resources.ApplyResources(this.RemoveAllButton, "RemoveAllButton");
            this.RemoveAllButton.Appearance.Options.UseFont = true;
            this.RemoveAllButton.Name = "RemoveAllButton";
            this.RemoveAllButton.StyleController = this.layoutControl;
            this.RemoveAllButton.Click += new System.EventHandler(this.RemoveAllButton_Click);
            // 
            // layoutControl
            // 
            this.layoutControl.Appearance.Control.Options.UseFont = true;
            this.layoutControl.Appearance.ControlDisabled.Options.UseFont = true;
            this.layoutControl.Appearance.ControlDropDown.Options.UseFont = true;
            this.layoutControl.Appearance.ControlDropDownHeader.Options.UseFont = true;
            this.layoutControl.Appearance.ControlFocused.Options.UseFont = true;
            this.layoutControl.Appearance.ControlReadOnly.Options.UseFont = true;
            this.layoutControl.Controls.Add(this.cbAdminLevel);
            this.layoutControl.Controls.Add(this.cbTimeInterval);
            this.layoutControl.Controls.Add(this.CaseGrid);
            this.layoutControl.Controls.Add(this.RemoveButton);
            this.layoutControl.Controls.Add(this.RemoveAllButton);
            this.layoutControl.Controls.Add(this.EditButton);
            this.layoutControl.Controls.Add(this.NewButton);
            this.layoutControl.Controls.Add(this.SelectButton);
            resources.ApplyResources(this.layoutControl, "layoutControl");
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(44, 136, 250, 350);
            this.layoutControl.Root = this.MainGroup;
            // 
            // cbAdminLevel
            // 
            resources.ApplyResources(this.cbAdminLevel, "cbAdminLevel");
            this.cbAdminLevel.Name = "cbAdminLevel";
            this.cbAdminLevel.Properties.Appearance.Options.UseFont = true;
            this.cbAdminLevel.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbAdminLevel.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbAdminLevel.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbAdminLevel.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbAdminLevel.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject1.Options.UseFont = true;
            this.cbAdminLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbAdminLevel.Properties.Buttons"))), resources.GetString("cbAdminLevel.Properties.Buttons1"), ((int)(resources.GetObject("cbAdminLevel.Properties.Buttons2"))), ((bool)(resources.GetObject("cbAdminLevel.Properties.Buttons3"))), ((bool)(resources.GetObject("cbAdminLevel.Properties.Buttons4"))), ((bool)(resources.GetObject("cbAdminLevel.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbAdminLevel.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbAdminLevel.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("cbAdminLevel.Properties.Buttons8"), ((object)(resources.GetObject("cbAdminLevel.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbAdminLevel.Properties.Buttons10"))), ((bool)(resources.GetObject("cbAdminLevel.Properties.Buttons11"))))});
            this.cbAdminLevel.Properties.NullText = resources.GetString("cbAdminLevel.Properties.NullText");
            this.cbAdminLevel.StyleController = this.layoutControl;
            this.cbAdminLevel.Tag = "{M}";
            this.cbAdminLevel.EditValueChanged += new System.EventHandler(this.cbAdminLevel_EditValueChanged);
            this.cbAdminLevel.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.cbAdminLevel_EditValueChanging);
            // 
            // cbTimeInterval
            // 
            resources.ApplyResources(this.cbTimeInterval, "cbTimeInterval");
            this.cbTimeInterval.Name = "cbTimeInterval";
            this.cbTimeInterval.Properties.Appearance.Options.UseFont = true;
            this.cbTimeInterval.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbTimeInterval.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbTimeInterval.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbTimeInterval.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbTimeInterval.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject2.Options.UseFont = true;
            this.cbTimeInterval.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbTimeInterval.Properties.Buttons"))), resources.GetString("cbTimeInterval.Properties.Buttons1"), ((int)(resources.GetObject("cbTimeInterval.Properties.Buttons2"))), ((bool)(resources.GetObject("cbTimeInterval.Properties.Buttons3"))), ((bool)(resources.GetObject("cbTimeInterval.Properties.Buttons4"))), ((bool)(resources.GetObject("cbTimeInterval.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbTimeInterval.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbTimeInterval.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, resources.GetString("cbTimeInterval.Properties.Buttons8"), ((object)(resources.GetObject("cbTimeInterval.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbTimeInterval.Properties.Buttons10"))), ((bool)(resources.GetObject("cbTimeInterval.Properties.Buttons11"))))});
            this.cbTimeInterval.Properties.NullText = resources.GetString("cbTimeInterval.Properties.NullText");
            this.cbTimeInterval.StyleController = this.layoutControl;
            this.cbTimeInterval.Tag = "{M}";
            this.cbTimeInterval.EditValueChanged += new System.EventHandler(this.cbTimeInterval_EditValueChanged);
            this.cbTimeInterval.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.cbTimeInterval_EditValueChanging);
            // 
            // RemoveButton
            // 
            resources.ApplyResources(this.RemoveButton, "RemoveButton");
            this.RemoveButton.Appearance.Options.UseFont = true;
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.StyleController = this.layoutControl;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // EditButton
            // 
            resources.ApplyResources(this.EditButton, "EditButton");
            this.EditButton.Appearance.Options.UseFont = true;
            this.EditButton.Name = "EditButton";
            this.EditButton.StyleController = this.layoutControl;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // NewButton
            // 
            resources.ApplyResources(this.NewButton, "NewButton");
            this.NewButton.Appearance.Options.UseFont = true;
            this.NewButton.Name = "NewButton";
            this.NewButton.StyleController = this.layoutControl;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // SelectButton
            // 
            resources.ApplyResources(this.SelectButton, "SelectButton");
            this.SelectButton.Appearance.Options.UseFont = true;
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.StyleController = this.layoutControl;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // MainGroup
            // 
            this.MainGroup.AppearanceGroup.Options.UseFont = true;
            this.MainGroup.AppearanceItemCaption.Options.UseFont = true;
            this.MainGroup.AppearanceTabPage.Header.Options.UseFont = true;
            this.MainGroup.AppearanceTabPage.HeaderActive.Options.UseFont = true;
            this.MainGroup.AppearanceTabPage.HeaderDisabled.Options.UseFont = true;
            this.MainGroup.AppearanceTabPage.HeaderHotTracked.Options.UseFont = true;
            this.MainGroup.AppearanceTabPage.PageClient.Options.UseFont = true;
            resources.ApplyResources(this.MainGroup, "MainGroup");
            this.MainGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.MainGroup.GroupBordersVisible = false;
            this.MainGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.SettingsGroup,
            this.SelectedCasesGroup});
            this.MainGroup.Location = new System.Drawing.Point(0, 0);
            this.MainGroup.Name = "MainGroup";
            this.MainGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.MainGroup.ShowInCustomizationForm = false;
            this.MainGroup.Size = new System.Drawing.Size(812, 234);
            this.MainGroup.TextVisible = false;
            // 
            // SettingsGroup
            // 
            this.SettingsGroup.AppearanceGroup.Options.UseFont = true;
            this.SettingsGroup.AppearanceItemCaption.Options.UseFont = true;
            this.SettingsGroup.AppearanceTabPage.Header.Options.UseFont = true;
            this.SettingsGroup.AppearanceTabPage.HeaderActive.Options.UseFont = true;
            this.SettingsGroup.AppearanceTabPage.HeaderDisabled.Options.UseFont = true;
            this.SettingsGroup.AppearanceTabPage.HeaderHotTracked.Options.UseFont = true;
            this.SettingsGroup.AppearanceTabPage.PageClient.Options.UseFont = true;
            resources.ApplyResources(this.SettingsGroup, "SettingsGroup");
            this.SettingsGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.AdministrativeLevelItem,
            this.TimeIntervalItem});
            this.SettingsGroup.Location = new System.Drawing.Point(0, 0);
            this.SettingsGroup.Name = "SettingsGroup";
            this.SettingsGroup.OptionsItemText.TextToControlDistance = 4;
            this.SettingsGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.SettingsGroup.Size = new System.Drawing.Size(812, 58);
            // 
            // AdministrativeLevelItem
            // 
            this.AdministrativeLevelItem.AppearanceItemCaption.Options.UseFont = true;
            this.AdministrativeLevelItem.Control = this.cbAdminLevel;
            resources.ApplyResources(this.AdministrativeLevelItem, "AdministrativeLevelItem");
            this.AdministrativeLevelItem.Location = new System.Drawing.Point(0, 0);
            this.AdministrativeLevelItem.Name = "AdministrativeLevelItem";
            this.AdministrativeLevelItem.Size = new System.Drawing.Size(356, 24);
            this.AdministrativeLevelItem.TextSize = new System.Drawing.Size(96, 13);
            // 
            // TimeIntervalItem
            // 
            this.TimeIntervalItem.AppearanceItemCaption.Options.UseFont = true;
            this.TimeIntervalItem.Control = this.cbTimeInterval;
            resources.ApplyResources(this.TimeIntervalItem, "TimeIntervalItem");
            this.TimeIntervalItem.Location = new System.Drawing.Point(356, 0);
            this.TimeIntervalItem.Name = "TimeIntervalItem";
            this.TimeIntervalItem.Size = new System.Drawing.Size(442, 24);
            this.TimeIntervalItem.TextSize = new System.Drawing.Size(96, 13);
            // 
            // SelectedCasesGroup
            // 
            this.SelectedCasesGroup.AppearanceGroup.Options.UseFont = true;
            this.SelectedCasesGroup.AppearanceItemCaption.Options.UseFont = true;
            this.SelectedCasesGroup.AppearanceTabPage.Header.Options.UseFont = true;
            this.SelectedCasesGroup.AppearanceTabPage.HeaderActive.Options.UseFont = true;
            this.SelectedCasesGroup.AppearanceTabPage.HeaderDisabled.Options.UseFont = true;
            this.SelectedCasesGroup.AppearanceTabPage.HeaderHotTracked.Options.UseFont = true;
            this.SelectedCasesGroup.AppearanceTabPage.PageClient.Options.UseFont = true;
            resources.ApplyResources(this.SelectedCasesGroup, "SelectedCasesGroup");
            this.SelectedCasesGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.CasesGridItem,
            this.emptyItem1,
            this.NewButtonItem,
            this.EditButtonItem,
            this.SelectButtonItem,
            this.RemoveButtonItem,
            this.RemoveAllButtonItem});
            this.SelectedCasesGroup.Location = new System.Drawing.Point(0, 58);
            this.SelectedCasesGroup.Name = "SelectedCasesGroup";
            this.SelectedCasesGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.SelectedCasesGroup.Size = new System.Drawing.Size(812, 176);
            // 
            // CasesGridItem
            // 
            this.CasesGridItem.AppearanceItemCaption.Options.UseFont = true;
            this.CasesGridItem.Control = this.CaseGrid;
            resources.ApplyResources(this.CasesGridItem, "CasesGridItem");
            this.CasesGridItem.Location = new System.Drawing.Point(0, 26);
            this.CasesGridItem.Name = "CasesGridItem";
            this.CasesGridItem.Size = new System.Drawing.Size(798, 116);
            this.CasesGridItem.TextSize = new System.Drawing.Size(0, 0);
            this.CasesGridItem.TextToControlDistance = 0;
            this.CasesGridItem.TextVisible = false;
            // 
            // emptyItem1
            // 
            this.emptyItem1.AllowHotTrack = false;
            this.emptyItem1.AppearanceItemCaption.Options.UseFont = true;
            resources.ApplyResources(this.emptyItem1, "emptyItem1");
            this.emptyItem1.Location = new System.Drawing.Point(0, 0);
            this.emptyItem1.Name = "emptyItem1";
            this.emptyItem1.Size = new System.Drawing.Size(225, 26);
            this.emptyItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // NewButtonItem
            // 
            this.NewButtonItem.AppearanceItemCaption.Options.UseFont = true;
            this.NewButtonItem.Control = this.NewButton;
            resources.ApplyResources(this.NewButtonItem, "NewButtonItem");
            this.NewButtonItem.Location = new System.Drawing.Point(225, 0);
            this.NewButtonItem.Name = "NewButtonItem";
            this.NewButtonItem.Size = new System.Drawing.Size(115, 26);
            this.NewButtonItem.TextSize = new System.Drawing.Size(0, 0);
            this.NewButtonItem.TextToControlDistance = 0;
            this.NewButtonItem.TextVisible = false;
            // 
            // EditButtonItem
            // 
            this.EditButtonItem.AppearanceItemCaption.Options.UseFont = true;
            this.EditButtonItem.Control = this.EditButton;
            resources.ApplyResources(this.EditButtonItem, "EditButtonItem");
            this.EditButtonItem.Location = new System.Drawing.Point(340, 0);
            this.EditButtonItem.Name = "EditButtonItem";
            this.EditButtonItem.Size = new System.Drawing.Size(114, 26);
            this.EditButtonItem.TextSize = new System.Drawing.Size(0, 0);
            this.EditButtonItem.TextToControlDistance = 0;
            this.EditButtonItem.TextVisible = false;
            // 
            // SelectButtonItem
            // 
            this.SelectButtonItem.AppearanceItemCaption.Options.UseFont = true;
            this.SelectButtonItem.Control = this.SelectButton;
            resources.ApplyResources(this.SelectButtonItem, "SelectButtonItem");
            this.SelectButtonItem.Location = new System.Drawing.Point(454, 0);
            this.SelectButtonItem.Name = "SelectButtonItem";
            this.SelectButtonItem.Size = new System.Drawing.Size(115, 26);
            this.SelectButtonItem.TextSize = new System.Drawing.Size(0, 0);
            this.SelectButtonItem.TextToControlDistance = 0;
            this.SelectButtonItem.TextVisible = false;
            // 
            // RemoveButtonItem
            // 
            this.RemoveButtonItem.AppearanceItemCaption.Options.UseFont = true;
            this.RemoveButtonItem.Control = this.RemoveButton;
            resources.ApplyResources(this.RemoveButtonItem, "RemoveButtonItem");
            this.RemoveButtonItem.Location = new System.Drawing.Point(569, 0);
            this.RemoveButtonItem.Name = "RemoveButtonItem";
            this.RemoveButtonItem.Size = new System.Drawing.Size(114, 26);
            this.RemoveButtonItem.TextSize = new System.Drawing.Size(0, 0);
            this.RemoveButtonItem.TextToControlDistance = 0;
            this.RemoveButtonItem.TextVisible = false;
            // 
            // RemoveAllButtonItem
            // 
            this.RemoveAllButtonItem.AppearanceItemCaption.Options.UseFont = true;
            this.RemoveAllButtonItem.Control = this.RemoveAllButton;
            resources.ApplyResources(this.RemoveAllButtonItem, "RemoveAllButtonItem");
            this.RemoveAllButtonItem.Location = new System.Drawing.Point(683, 0);
            this.RemoveAllButtonItem.Name = "RemoveAllButtonItem";
            this.RemoveAllButtonItem.Size = new System.Drawing.Size(115, 26);
            this.RemoveAllButtonItem.TextSize = new System.Drawing.Size(0, 0);
            this.RemoveAllButtonItem.TextToControlDistance = 0;
            this.RemoveAllButtonItem.TextVisible = false;
            // 
            // AggregateSummaryHeader
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Name = "AggregateSummaryHeader";
            ((System.ComponentModel.ISupportInitialize)(this.CaseGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaseView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbAdminLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTimeInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdministrativeLevelItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeIntervalItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedCasesGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CasesGridItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptyItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewButtonItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditButtonItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectButtonItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemoveButtonItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemoveAllButtonItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl CaseGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView CaseView;
        private DevExpress.XtraEditors.SimpleButton RemoveAllButton;
        private DevExpress.XtraEditors.SimpleButton RemoveButton;
        private DevExpress.XtraEditors.SimpleButton SelectButton;
        private DevExpress.XtraEditors.SimpleButton EditButton;
        private DevExpress.XtraEditors.SimpleButton NewButton;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup MainGroup;
        internal DevExpress.XtraEditors.LookUpEdit cbAdminLevel;
        private DevExpress.XtraLayout.LayoutControlItem AdministrativeLevelItem;
        internal DevExpress.XtraEditors.LookUpEdit cbTimeInterval;
        private DevExpress.XtraLayout.LayoutControlItem TimeIntervalItem;
        private DevExpress.XtraLayout.LayoutControlGroup SettingsGroup;
        private DevExpress.XtraLayout.LayoutControlGroup SelectedCasesGroup;
        private DevExpress.XtraLayout.LayoutControlItem CasesGridItem;
        private DevExpress.XtraLayout.EmptySpaceItem emptyItem1;
        private DevExpress.XtraLayout.LayoutControlItem RemoveAllButtonItem;
        private DevExpress.XtraLayout.LayoutControlItem RemoveButtonItem;
        private DevExpress.XtraLayout.LayoutControlItem SelectButtonItem;
        private DevExpress.XtraLayout.LayoutControlItem EditButtonItem;
        private DevExpress.XtraLayout.LayoutControlItem NewButtonItem;
    }
}
