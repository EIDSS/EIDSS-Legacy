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
            // 
            // CaseGrid
            // 
            resources.ApplyResources(this.CaseGrid, "CaseGrid");
            this.CaseGrid.EmbeddedNavigator.AccessibleDescription = resources.GetString("CaseGrid.EmbeddedNavigator.AccessibleDescription");
            this.CaseGrid.EmbeddedNavigator.AccessibleName = resources.GetString("CaseGrid.EmbeddedNavigator.AccessibleName");
            this.CaseGrid.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("CaseGrid.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.CaseGrid.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("CaseGrid.EmbeddedNavigator.Anchor")));
            this.CaseGrid.EmbeddedNavigator.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("CaseGrid.EmbeddedNavigator.Appearance.GradientMode")));
            this.CaseGrid.EmbeddedNavigator.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("CaseGrid.EmbeddedNavigator.Appearance.Image")));
            this.CaseGrid.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.CaseGrid.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CaseGrid.EmbeddedNavigator.BackgroundImage")));
            this.CaseGrid.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("CaseGrid.EmbeddedNavigator.BackgroundImageLayout")));
            this.CaseGrid.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("CaseGrid.EmbeddedNavigator.ImeMode")));
            this.CaseGrid.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("CaseGrid.EmbeddedNavigator.TextLocation")));
            this.CaseGrid.EmbeddedNavigator.ToolTip = resources.GetString("CaseGrid.EmbeddedNavigator.ToolTip");
            this.CaseGrid.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("CaseGrid.EmbeddedNavigator.ToolTipIconType")));
            this.CaseGrid.EmbeddedNavigator.ToolTipTitle = resources.GetString("CaseGrid.EmbeddedNavigator.ToolTipTitle");
            this.CaseGrid.MainView = this.CaseView;
            this.CaseGrid.Name = "CaseGrid";
            this.CaseGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CaseView});
            // 
            // CaseView
            // 
            resources.ApplyResources(this.CaseView, "CaseView");
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
            this.RemoveAllButton.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("RemoveAllButton.Appearance.GradientMode")));
            this.RemoveAllButton.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("RemoveAllButton.Appearance.Image")));
            this.RemoveAllButton.Appearance.Options.UseFont = true;
            this.RemoveAllButton.Name = "RemoveAllButton";
            this.RemoveAllButton.StyleController = this.layoutControl;
            this.RemoveAllButton.Click += new System.EventHandler(this.RemoveAllButton_Click);
            // 
            // layoutControl
            // 
            resources.ApplyResources(this.layoutControl, "layoutControl");
            this.layoutControl.Appearance.Control.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("layoutControl.Appearance.Control.GradientMode")));
            this.layoutControl.Appearance.Control.Image = ((System.Drawing.Image)(resources.GetObject("layoutControl.Appearance.Control.Image")));
            this.layoutControl.Appearance.Control.Options.UseFont = true;
            this.layoutControl.Appearance.ControlDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("layoutControl.Appearance.ControlDisabled.GradientMode")));
            this.layoutControl.Appearance.ControlDisabled.Image = ((System.Drawing.Image)(resources.GetObject("layoutControl.Appearance.ControlDisabled.Image")));
            this.layoutControl.Appearance.ControlDisabled.Options.UseFont = true;
            this.layoutControl.Appearance.ControlDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("layoutControl.Appearance.ControlDropDown.GradientMode")));
            this.layoutControl.Appearance.ControlDropDown.Image = ((System.Drawing.Image)(resources.GetObject("layoutControl.Appearance.ControlDropDown.Image")));
            this.layoutControl.Appearance.ControlDropDown.Options.UseFont = true;
            this.layoutControl.Appearance.ControlDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("layoutControl.Appearance.ControlDropDownHeader.GradientMode")));
            this.layoutControl.Appearance.ControlDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("layoutControl.Appearance.ControlDropDownHeader.Image")));
            this.layoutControl.Appearance.ControlDropDownHeader.Options.UseFont = true;
            this.layoutControl.Appearance.ControlFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("layoutControl.Appearance.ControlFocused.GradientMode")));
            this.layoutControl.Appearance.ControlFocused.Image = ((System.Drawing.Image)(resources.GetObject("layoutControl.Appearance.ControlFocused.Image")));
            this.layoutControl.Appearance.ControlFocused.Options.UseFont = true;
            this.layoutControl.Appearance.ControlReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("layoutControl.Appearance.ControlReadOnly.GradientMode")));
            this.layoutControl.Appearance.ControlReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("layoutControl.Appearance.ControlReadOnly.Image")));
            this.layoutControl.Appearance.ControlReadOnly.Options.UseFont = true;
            this.layoutControl.Controls.Add(this.cbAdminLevel);
            this.layoutControl.Controls.Add(this.cbTimeInterval);
            this.layoutControl.Controls.Add(this.CaseGrid);
            this.layoutControl.Controls.Add(this.RemoveButton);
            this.layoutControl.Controls.Add(this.RemoveAllButton);
            this.layoutControl.Controls.Add(this.EditButton);
            this.layoutControl.Controls.Add(this.NewButton);
            this.layoutControl.Controls.Add(this.SelectButton);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(44, 136, 250, 350);
            this.layoutControl.Root = this.MainGroup;
            // 
            // cbAdminLevel
            // 
            resources.ApplyResources(this.cbAdminLevel, "cbAdminLevel");
            this.cbAdminLevel.Name = "cbAdminLevel";
            this.cbAdminLevel.Properties.AccessibleDescription = resources.GetString("cbAdminLevel.Properties.AccessibleDescription");
            this.cbAdminLevel.Properties.AccessibleName = resources.GetString("cbAdminLevel.Properties.AccessibleName");
            this.cbAdminLevel.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbAdminLevel.Properties.Appearance.GradientMode")));
            this.cbAdminLevel.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("cbAdminLevel.Properties.Appearance.Image")));
            this.cbAdminLevel.Properties.Appearance.Options.UseFont = true;
            this.cbAdminLevel.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbAdminLevel.Properties.AppearanceDisabled.GradientMode")));
            this.cbAdminLevel.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("cbAdminLevel.Properties.AppearanceDisabled.Image")));
            this.cbAdminLevel.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbAdminLevel.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbAdminLevel.Properties.AppearanceDropDown.GradientMode")));
            this.cbAdminLevel.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("cbAdminLevel.Properties.AppearanceDropDown.Image")));
            this.cbAdminLevel.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbAdminLevel.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbAdminLevel.Properties.AppearanceDropDownHeader.GradientMode")));
            this.cbAdminLevel.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("cbAdminLevel.Properties.AppearanceDropDownHeader.Image")));
            this.cbAdminLevel.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbAdminLevel.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbAdminLevel.Properties.AppearanceFocused.GradientMode")));
            this.cbAdminLevel.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("cbAdminLevel.Properties.AppearanceFocused.Image")));
            this.cbAdminLevel.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbAdminLevel.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbAdminLevel.Properties.AppearanceReadOnly.GradientMode")));
            this.cbAdminLevel.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("cbAdminLevel.Properties.AppearanceReadOnly.Image")));
            this.cbAdminLevel.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cbAdminLevel.Properties.AutoHeight = ((bool)(resources.GetObject("cbAdminLevel.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject1, "serializableAppearanceObject1");
            serializableAppearanceObject1.Options.UseFont = true;
            this.cbAdminLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbAdminLevel.Properties.Buttons"))), resources.GetString("cbAdminLevel.Properties.Buttons1"), ((int)(resources.GetObject("cbAdminLevel.Properties.Buttons2"))), ((bool)(resources.GetObject("cbAdminLevel.Properties.Buttons3"))), ((bool)(resources.GetObject("cbAdminLevel.Properties.Buttons4"))), ((bool)(resources.GetObject("cbAdminLevel.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbAdminLevel.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbAdminLevel.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("cbAdminLevel.Properties.Buttons8"), ((object)(resources.GetObject("cbAdminLevel.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbAdminLevel.Properties.Buttons10"))), ((bool)(resources.GetObject("cbAdminLevel.Properties.Buttons11"))))});
            this.cbAdminLevel.Properties.NullText = resources.GetString("cbAdminLevel.Properties.NullText");
            this.cbAdminLevel.Properties.NullValuePrompt = resources.GetString("cbAdminLevel.Properties.NullValuePrompt");
            this.cbAdminLevel.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbAdminLevel.Properties.NullValuePromptShowForEmptyValue")));
            this.cbAdminLevel.StyleController = this.layoutControl;
            this.cbAdminLevel.Tag = "{M}";
            this.cbAdminLevel.EditValueChanged += new System.EventHandler(this.cbAdminLevel_EditValueChanged);
            this.cbAdminLevel.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.cbAdminLevel_EditValueChanging);
            // 
            // cbTimeInterval
            // 
            resources.ApplyResources(this.cbTimeInterval, "cbTimeInterval");
            this.cbTimeInterval.Name = "cbTimeInterval";
            this.cbTimeInterval.Properties.AccessibleDescription = resources.GetString("cbTimeInterval.Properties.AccessibleDescription");
            this.cbTimeInterval.Properties.AccessibleName = resources.GetString("cbTimeInterval.Properties.AccessibleName");
            this.cbTimeInterval.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbTimeInterval.Properties.Appearance.GradientMode")));
            this.cbTimeInterval.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("cbTimeInterval.Properties.Appearance.Image")));
            this.cbTimeInterval.Properties.Appearance.Options.UseFont = true;
            this.cbTimeInterval.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbTimeInterval.Properties.AppearanceDisabled.GradientMode")));
            this.cbTimeInterval.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("cbTimeInterval.Properties.AppearanceDisabled.Image")));
            this.cbTimeInterval.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbTimeInterval.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbTimeInterval.Properties.AppearanceDropDown.GradientMode")));
            this.cbTimeInterval.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("cbTimeInterval.Properties.AppearanceDropDown.Image")));
            this.cbTimeInterval.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbTimeInterval.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbTimeInterval.Properties.AppearanceDropDownHeader.GradientMode")));
            this.cbTimeInterval.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("cbTimeInterval.Properties.AppearanceDropDownHeader.Image")));
            this.cbTimeInterval.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbTimeInterval.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbTimeInterval.Properties.AppearanceFocused.GradientMode")));
            this.cbTimeInterval.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("cbTimeInterval.Properties.AppearanceFocused.Image")));
            this.cbTimeInterval.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbTimeInterval.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbTimeInterval.Properties.AppearanceReadOnly.GradientMode")));
            this.cbTimeInterval.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("cbTimeInterval.Properties.AppearanceReadOnly.Image")));
            this.cbTimeInterval.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cbTimeInterval.Properties.AutoHeight = ((bool)(resources.GetObject("cbTimeInterval.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject2, "serializableAppearanceObject2");
            serializableAppearanceObject2.Options.UseFont = true;
            this.cbTimeInterval.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbTimeInterval.Properties.Buttons"))), resources.GetString("cbTimeInterval.Properties.Buttons1"), ((int)(resources.GetObject("cbTimeInterval.Properties.Buttons2"))), ((bool)(resources.GetObject("cbTimeInterval.Properties.Buttons3"))), ((bool)(resources.GetObject("cbTimeInterval.Properties.Buttons4"))), ((bool)(resources.GetObject("cbTimeInterval.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbTimeInterval.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbTimeInterval.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, resources.GetString("cbTimeInterval.Properties.Buttons8"), ((object)(resources.GetObject("cbTimeInterval.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbTimeInterval.Properties.Buttons10"))), ((bool)(resources.GetObject("cbTimeInterval.Properties.Buttons11"))))});
            this.cbTimeInterval.Properties.NullText = resources.GetString("cbTimeInterval.Properties.NullText");
            this.cbTimeInterval.Properties.NullValuePrompt = resources.GetString("cbTimeInterval.Properties.NullValuePrompt");
            this.cbTimeInterval.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbTimeInterval.Properties.NullValuePromptShowForEmptyValue")));
            this.cbTimeInterval.StyleController = this.layoutControl;
            this.cbTimeInterval.Tag = "{M}";
            this.cbTimeInterval.EditValueChanged += new System.EventHandler(this.cbTimeInterval_EditValueChanged);
            this.cbTimeInterval.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.cbTimeInterval_EditValueChanging);
            // 
            // RemoveButton
            // 
            resources.ApplyResources(this.RemoveButton, "RemoveButton");
            this.RemoveButton.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("RemoveButton.Appearance.GradientMode")));
            this.RemoveButton.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("RemoveButton.Appearance.Image")));
            this.RemoveButton.Appearance.Options.UseFont = true;
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.StyleController = this.layoutControl;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // EditButton
            // 
            resources.ApplyResources(this.EditButton, "EditButton");
            this.EditButton.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("EditButton.Appearance.GradientMode")));
            this.EditButton.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("EditButton.Appearance.Image")));
            this.EditButton.Appearance.Options.UseFont = true;
            this.EditButton.Name = "EditButton";
            this.EditButton.StyleController = this.layoutControl;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // NewButton
            // 
            resources.ApplyResources(this.NewButton, "NewButton");
            this.NewButton.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("NewButton.Appearance.GradientMode")));
            this.NewButton.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("NewButton.Appearance.Image")));
            this.NewButton.Appearance.Options.UseFont = true;
            this.NewButton.Name = "NewButton";
            this.NewButton.StyleController = this.layoutControl;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // SelectButton
            // 
            resources.ApplyResources(this.SelectButton, "SelectButton");
            this.SelectButton.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SelectButton.Appearance.GradientMode")));
            this.SelectButton.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("SelectButton.Appearance.Image")));
            this.SelectButton.Appearance.Options.UseFont = true;
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.StyleController = this.layoutControl;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // MainGroup
            // 
            this.MainGroup.AppearanceGroup.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("MainGroup.AppearanceGroup.GradientMode")));
            this.MainGroup.AppearanceGroup.Image = ((System.Drawing.Image)(resources.GetObject("MainGroup.AppearanceGroup.Image")));
            this.MainGroup.AppearanceGroup.Options.UseFont = true;
            this.MainGroup.AppearanceItemCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("MainGroup.AppearanceItemCaption.GradientMode")));
            this.MainGroup.AppearanceItemCaption.Image = ((System.Drawing.Image)(resources.GetObject("MainGroup.AppearanceItemCaption.Image")));
            this.MainGroup.AppearanceItemCaption.Options.UseFont = true;
            this.MainGroup.AppearanceTabPage.Header.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("MainGroup.AppearanceTabPage.Header.GradientMode")));
            this.MainGroup.AppearanceTabPage.Header.Image = ((System.Drawing.Image)(resources.GetObject("MainGroup.AppearanceTabPage.Header.Image")));
            this.MainGroup.AppearanceTabPage.Header.Options.UseFont = true;
            this.MainGroup.AppearanceTabPage.HeaderActive.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("MainGroup.AppearanceTabPage.HeaderActive.GradientMode")));
            this.MainGroup.AppearanceTabPage.HeaderActive.Image = ((System.Drawing.Image)(resources.GetObject("MainGroup.AppearanceTabPage.HeaderActive.Image")));
            this.MainGroup.AppearanceTabPage.HeaderActive.Options.UseFont = true;
            this.MainGroup.AppearanceTabPage.HeaderDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("MainGroup.AppearanceTabPage.HeaderDisabled.GradientMode")));
            this.MainGroup.AppearanceTabPage.HeaderDisabled.Image = ((System.Drawing.Image)(resources.GetObject("MainGroup.AppearanceTabPage.HeaderDisabled.Image")));
            this.MainGroup.AppearanceTabPage.HeaderDisabled.Options.UseFont = true;
            this.MainGroup.AppearanceTabPage.HeaderHotTracked.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("MainGroup.AppearanceTabPage.HeaderHotTracked.GradientMode")));
            this.MainGroup.AppearanceTabPage.HeaderHotTracked.Image = ((System.Drawing.Image)(resources.GetObject("MainGroup.AppearanceTabPage.HeaderHotTracked.Image")));
            this.MainGroup.AppearanceTabPage.HeaderHotTracked.Options.UseFont = true;
            this.MainGroup.AppearanceTabPage.PageClient.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("MainGroup.AppearanceTabPage.PageClient.GradientMode")));
            this.MainGroup.AppearanceTabPage.PageClient.Image = ((System.Drawing.Image)(resources.GetObject("MainGroup.AppearanceTabPage.PageClient.Image")));
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
            this.MainGroup.Size = new System.Drawing.Size(815, 234);
            this.MainGroup.TextVisible = false;
            // 
            // SettingsGroup
            // 
            this.SettingsGroup.AppearanceGroup.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SettingsGroup.AppearanceGroup.GradientMode")));
            this.SettingsGroup.AppearanceGroup.Image = ((System.Drawing.Image)(resources.GetObject("SettingsGroup.AppearanceGroup.Image")));
            this.SettingsGroup.AppearanceGroup.Options.UseFont = true;
            this.SettingsGroup.AppearanceItemCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SettingsGroup.AppearanceItemCaption.GradientMode")));
            this.SettingsGroup.AppearanceItemCaption.Image = ((System.Drawing.Image)(resources.GetObject("SettingsGroup.AppearanceItemCaption.Image")));
            this.SettingsGroup.AppearanceItemCaption.Options.UseFont = true;
            this.SettingsGroup.AppearanceTabPage.Header.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SettingsGroup.AppearanceTabPage.Header.GradientMode")));
            this.SettingsGroup.AppearanceTabPage.Header.Image = ((System.Drawing.Image)(resources.GetObject("SettingsGroup.AppearanceTabPage.Header.Image")));
            this.SettingsGroup.AppearanceTabPage.Header.Options.UseFont = true;
            this.SettingsGroup.AppearanceTabPage.HeaderActive.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SettingsGroup.AppearanceTabPage.HeaderActive.GradientMode")));
            this.SettingsGroup.AppearanceTabPage.HeaderActive.Image = ((System.Drawing.Image)(resources.GetObject("SettingsGroup.AppearanceTabPage.HeaderActive.Image")));
            this.SettingsGroup.AppearanceTabPage.HeaderActive.Options.UseFont = true;
            this.SettingsGroup.AppearanceTabPage.HeaderDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SettingsGroup.AppearanceTabPage.HeaderDisabled.GradientMode")));
            this.SettingsGroup.AppearanceTabPage.HeaderDisabled.Image = ((System.Drawing.Image)(resources.GetObject("SettingsGroup.AppearanceTabPage.HeaderDisabled.Image")));
            this.SettingsGroup.AppearanceTabPage.HeaderDisabled.Options.UseFont = true;
            this.SettingsGroup.AppearanceTabPage.HeaderHotTracked.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SettingsGroup.AppearanceTabPage.HeaderHotTracked.GradientMode")));
            this.SettingsGroup.AppearanceTabPage.HeaderHotTracked.Image = ((System.Drawing.Image)(resources.GetObject("SettingsGroup.AppearanceTabPage.HeaderHotTracked.Image")));
            this.SettingsGroup.AppearanceTabPage.HeaderHotTracked.Options.UseFont = true;
            this.SettingsGroup.AppearanceTabPage.PageClient.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SettingsGroup.AppearanceTabPage.PageClient.GradientMode")));
            this.SettingsGroup.AppearanceTabPage.PageClient.Image = ((System.Drawing.Image)(resources.GetObject("SettingsGroup.AppearanceTabPage.PageClient.Image")));
            this.SettingsGroup.AppearanceTabPage.PageClient.Options.UseFont = true;
            resources.ApplyResources(this.SettingsGroup, "SettingsGroup");
            this.SettingsGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.AdministrativeLevelItem,
            this.TimeIntervalItem});
            this.SettingsGroup.Location = new System.Drawing.Point(0, 0);
            this.SettingsGroup.Name = "SettingsGroup";
            this.SettingsGroup.OptionsItemText.TextToControlDistance = 4;
            this.SettingsGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.SettingsGroup.Size = new System.Drawing.Size(815, 56);
            // 
            // AdministrativeLevelItem
            // 
            this.AdministrativeLevelItem.AppearanceItemCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("AdministrativeLevelItem.AppearanceItemCaption.GradientMode")));
            this.AdministrativeLevelItem.AppearanceItemCaption.Image = ((System.Drawing.Image)(resources.GetObject("AdministrativeLevelItem.AppearanceItemCaption.Image")));
            this.AdministrativeLevelItem.AppearanceItemCaption.Options.UseFont = true;
            this.AdministrativeLevelItem.Control = this.cbAdminLevel;
            resources.ApplyResources(this.AdministrativeLevelItem, "AdministrativeLevelItem");
            this.AdministrativeLevelItem.Location = new System.Drawing.Point(0, 0);
            this.AdministrativeLevelItem.Name = "AdministrativeLevelItem";
            this.AdministrativeLevelItem.Size = new System.Drawing.Size(357, 23);
            this.AdministrativeLevelItem.TextSize = new System.Drawing.Size(163, 13);
            // 
            // TimeIntervalItem
            // 
            this.TimeIntervalItem.AppearanceItemCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("TimeIntervalItem.AppearanceItemCaption.GradientMode")));
            this.TimeIntervalItem.AppearanceItemCaption.Image = ((System.Drawing.Image)(resources.GetObject("TimeIntervalItem.AppearanceItemCaption.Image")));
            this.TimeIntervalItem.AppearanceItemCaption.Options.UseFont = true;
            this.TimeIntervalItem.Control = this.cbTimeInterval;
            resources.ApplyResources(this.TimeIntervalItem, "TimeIntervalItem");
            this.TimeIntervalItem.Location = new System.Drawing.Point(357, 0);
            this.TimeIntervalItem.Name = "TimeIntervalItem";
            this.TimeIntervalItem.Size = new System.Drawing.Size(444, 23);
            this.TimeIntervalItem.TextSize = new System.Drawing.Size(163, 13);
            // 
            // SelectedCasesGroup
            // 
            this.SelectedCasesGroup.AppearanceGroup.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SelectedCasesGroup.AppearanceGroup.GradientMode")));
            this.SelectedCasesGroup.AppearanceGroup.Image = ((System.Drawing.Image)(resources.GetObject("SelectedCasesGroup.AppearanceGroup.Image")));
            this.SelectedCasesGroup.AppearanceGroup.Options.UseFont = true;
            this.SelectedCasesGroup.AppearanceItemCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SelectedCasesGroup.AppearanceItemCaption.GradientMode")));
            this.SelectedCasesGroup.AppearanceItemCaption.Image = ((System.Drawing.Image)(resources.GetObject("SelectedCasesGroup.AppearanceItemCaption.Image")));
            this.SelectedCasesGroup.AppearanceItemCaption.Options.UseFont = true;
            this.SelectedCasesGroup.AppearanceTabPage.Header.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SelectedCasesGroup.AppearanceTabPage.Header.GradientMode")));
            this.SelectedCasesGroup.AppearanceTabPage.Header.Image = ((System.Drawing.Image)(resources.GetObject("SelectedCasesGroup.AppearanceTabPage.Header.Image")));
            this.SelectedCasesGroup.AppearanceTabPage.Header.Options.UseFont = true;
            this.SelectedCasesGroup.AppearanceTabPage.HeaderActive.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SelectedCasesGroup.AppearanceTabPage.HeaderActive.GradientMode")));
            this.SelectedCasesGroup.AppearanceTabPage.HeaderActive.Image = ((System.Drawing.Image)(resources.GetObject("SelectedCasesGroup.AppearanceTabPage.HeaderActive.Image")));
            this.SelectedCasesGroup.AppearanceTabPage.HeaderActive.Options.UseFont = true;
            this.SelectedCasesGroup.AppearanceTabPage.HeaderDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SelectedCasesGroup.AppearanceTabPage.HeaderDisabled.GradientMode")));
            this.SelectedCasesGroup.AppearanceTabPage.HeaderDisabled.Image = ((System.Drawing.Image)(resources.GetObject("SelectedCasesGroup.AppearanceTabPage.HeaderDisabled.Image")));
            this.SelectedCasesGroup.AppearanceTabPage.HeaderDisabled.Options.UseFont = true;
            this.SelectedCasesGroup.AppearanceTabPage.HeaderHotTracked.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SelectedCasesGroup.AppearanceTabPage.HeaderHotTracked.GradientMode")));
            this.SelectedCasesGroup.AppearanceTabPage.HeaderHotTracked.Image = ((System.Drawing.Image)(resources.GetObject("SelectedCasesGroup.AppearanceTabPage.HeaderHotTracked.Image")));
            this.SelectedCasesGroup.AppearanceTabPage.HeaderHotTracked.Options.UseFont = true;
            this.SelectedCasesGroup.AppearanceTabPage.PageClient.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SelectedCasesGroup.AppearanceTabPage.PageClient.GradientMode")));
            this.SelectedCasesGroup.AppearanceTabPage.PageClient.Image = ((System.Drawing.Image)(resources.GetObject("SelectedCasesGroup.AppearanceTabPage.PageClient.Image")));
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
            this.SelectedCasesGroup.Location = new System.Drawing.Point(0, 56);
            this.SelectedCasesGroup.Name = "SelectedCasesGroup";
            this.SelectedCasesGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.SelectedCasesGroup.Size = new System.Drawing.Size(815, 178);
            // 
            // CasesGridItem
            // 
            this.CasesGridItem.AppearanceItemCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("CasesGridItem.AppearanceItemCaption.GradientMode")));
            this.CasesGridItem.AppearanceItemCaption.Image = ((System.Drawing.Image)(resources.GetObject("CasesGridItem.AppearanceItemCaption.Image")));
            this.CasesGridItem.AppearanceItemCaption.Options.UseFont = true;
            this.CasesGridItem.Control = this.CaseGrid;
            resources.ApplyResources(this.CasesGridItem, "CasesGridItem");
            this.CasesGridItem.Location = new System.Drawing.Point(0, 26);
            this.CasesGridItem.Name = "CasesGridItem";
            this.CasesGridItem.Size = new System.Drawing.Size(801, 119);
            this.CasesGridItem.TextSize = new System.Drawing.Size(0, 0);
            this.CasesGridItem.TextToControlDistance = 0;
            this.CasesGridItem.TextVisible = false;
            // 
            // emptyItem1
            // 
            this.emptyItem1.AllowHotTrack = false;
            this.emptyItem1.AppearanceItemCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("emptyItem1.AppearanceItemCaption.GradientMode")));
            this.emptyItem1.AppearanceItemCaption.Image = ((System.Drawing.Image)(resources.GetObject("emptyItem1.AppearanceItemCaption.Image")));
            this.emptyItem1.AppearanceItemCaption.Options.UseFont = true;
            resources.ApplyResources(this.emptyItem1, "emptyItem1");
            this.emptyItem1.Location = new System.Drawing.Point(0, 0);
            this.emptyItem1.Name = "emptyItem1";
            this.emptyItem1.Size = new System.Drawing.Size(226, 26);
            this.emptyItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // NewButtonItem
            // 
            this.NewButtonItem.AppearanceItemCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("NewButtonItem.AppearanceItemCaption.GradientMode")));
            this.NewButtonItem.AppearanceItemCaption.Image = ((System.Drawing.Image)(resources.GetObject("NewButtonItem.AppearanceItemCaption.Image")));
            this.NewButtonItem.AppearanceItemCaption.Options.UseFont = true;
            this.NewButtonItem.Control = this.NewButton;
            resources.ApplyResources(this.NewButtonItem, "NewButtonItem");
            this.NewButtonItem.Location = new System.Drawing.Point(226, 0);
            this.NewButtonItem.Name = "NewButtonItem";
            this.NewButtonItem.Size = new System.Drawing.Size(115, 26);
            this.NewButtonItem.TextSize = new System.Drawing.Size(0, 0);
            this.NewButtonItem.TextToControlDistance = 0;
            this.NewButtonItem.TextVisible = false;
            // 
            // EditButtonItem
            // 
            this.EditButtonItem.AppearanceItemCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("EditButtonItem.AppearanceItemCaption.GradientMode")));
            this.EditButtonItem.AppearanceItemCaption.Image = ((System.Drawing.Image)(resources.GetObject("EditButtonItem.AppearanceItemCaption.Image")));
            this.EditButtonItem.AppearanceItemCaption.Options.UseFont = true;
            this.EditButtonItem.Control = this.EditButton;
            resources.ApplyResources(this.EditButtonItem, "EditButtonItem");
            this.EditButtonItem.Location = new System.Drawing.Point(341, 0);
            this.EditButtonItem.Name = "EditButtonItem";
            this.EditButtonItem.Size = new System.Drawing.Size(115, 26);
            this.EditButtonItem.TextSize = new System.Drawing.Size(0, 0);
            this.EditButtonItem.TextToControlDistance = 0;
            this.EditButtonItem.TextVisible = false;
            // 
            // SelectButtonItem
            // 
            this.SelectButtonItem.AppearanceItemCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SelectButtonItem.AppearanceItemCaption.GradientMode")));
            this.SelectButtonItem.AppearanceItemCaption.Image = ((System.Drawing.Image)(resources.GetObject("SelectButtonItem.AppearanceItemCaption.Image")));
            this.SelectButtonItem.AppearanceItemCaption.Options.UseFont = true;
            this.SelectButtonItem.Control = this.SelectButton;
            resources.ApplyResources(this.SelectButtonItem, "SelectButtonItem");
            this.SelectButtonItem.Location = new System.Drawing.Point(456, 0);
            this.SelectButtonItem.Name = "SelectButtonItem";
            this.SelectButtonItem.Size = new System.Drawing.Size(115, 26);
            this.SelectButtonItem.TextSize = new System.Drawing.Size(0, 0);
            this.SelectButtonItem.TextToControlDistance = 0;
            this.SelectButtonItem.TextVisible = false;
            // 
            // RemoveButtonItem
            // 
            this.RemoveButtonItem.AppearanceItemCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("RemoveButtonItem.AppearanceItemCaption.GradientMode")));
            this.RemoveButtonItem.AppearanceItemCaption.Image = ((System.Drawing.Image)(resources.GetObject("RemoveButtonItem.AppearanceItemCaption.Image")));
            this.RemoveButtonItem.AppearanceItemCaption.Options.UseFont = true;
            this.RemoveButtonItem.Control = this.RemoveButton;
            resources.ApplyResources(this.RemoveButtonItem, "RemoveButtonItem");
            this.RemoveButtonItem.Location = new System.Drawing.Point(571, 0);
            this.RemoveButtonItem.Name = "RemoveButtonItem";
            this.RemoveButtonItem.Size = new System.Drawing.Size(115, 26);
            this.RemoveButtonItem.TextSize = new System.Drawing.Size(0, 0);
            this.RemoveButtonItem.TextToControlDistance = 0;
            this.RemoveButtonItem.TextVisible = false;
            // 
            // RemoveAllButtonItem
            // 
            this.RemoveAllButtonItem.AppearanceItemCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("RemoveAllButtonItem.AppearanceItemCaption.GradientMode")));
            this.RemoveAllButtonItem.AppearanceItemCaption.Image = ((System.Drawing.Image)(resources.GetObject("RemoveAllButtonItem.AppearanceItemCaption.Image")));
            this.RemoveAllButtonItem.AppearanceItemCaption.Options.UseFont = true;
            this.RemoveAllButtonItem.Control = this.RemoveAllButton;
            resources.ApplyResources(this.RemoveAllButtonItem, "RemoveAllButtonItem");
            this.RemoveAllButtonItem.Location = new System.Drawing.Point(686, 0);
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
