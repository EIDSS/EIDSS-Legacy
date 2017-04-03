namespace EIDSS.RAM.QueryBuilder
{
    partial class QueryDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryDetail));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pncQuery = new DevExpress.XtraEditors.PanelControl();
            this.pnSearchObjectContainer = new DevExpress.XtraEditors.PanelControl();
            this.qsoRoot = new EIDSS.RAM.QueryBuilder.QuerySearchObjectInfo();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.grpGeneralInfo = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.grcQueryInfo = new DevExpress.XtraEditors.GroupControl();
            this.chAddAllKeyFieldValues = new DevExpress.XtraEditors.CheckEdit();
            this.txtQueryName = new DevExpress.XtraEditors.TextEdit();
            this.lblQueryName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDefQueryName = new DevExpress.XtraEditors.TextEdit();
            this.lblDefQueryName = new System.Windows.Forms.Label();
            this.memDescription = new DevExpress.XtraEditors.MemoEdit();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.grcQueryObjectTree = new DevExpress.XtraEditors.GroupControl();
            this.btnRemoveChildObject = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddChildObject = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditQueryType = new DevExpress.XtraEditors.SimpleButton();
            this.trlQuery = new DevExpress.XtraTreeList.TreeList();
            this.colQuerySearchObjectID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colParentQuerySearchObjectID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSearchObject = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cbSearchObject = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colOrder = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.grpSearchObjectTree = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnCancelChanges = new DevExpress.XtraEditors.SimpleButton();
            this.mnuQueryType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuChildObject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pncQuery)).BeginInit();
            this.pncQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnSearchObjectContainer)).BeginInit();
            this.pnSearchObjectContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.navBarControl1.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcQueryInfo)).BeginInit();
            this.grcQueryInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chAddAllKeyFieldValues.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueryName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefQueryName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            this.navBarGroupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcQueryObjectTree)).BeginInit();
            this.grcQueryObjectTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSearchObject)).BeginInit();
            this.SuspendLayout();
            // 
            // pncQuery
            // 
            this.pncQuery.Appearance.Options.UseFont = true;
            this.pncQuery.Controls.Add(this.pnSearchObjectContainer);
            this.pncQuery.Controls.Add(this.navBarControl1);
            resources.ApplyResources(this.pncQuery, "pncQuery");
            this.pncQuery.MinimumSize = new System.Drawing.Size(732, 412);
            this.pncQuery.Name = "pncQuery";
            // 
            // pnSearchObjectContainer
            // 
            this.pnSearchObjectContainer.Appearance.Options.UseFont = true;
            this.pnSearchObjectContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnSearchObjectContainer.Controls.Add(this.qsoRoot);
            resources.ApplyResources(this.pnSearchObjectContainer, "pnSearchObjectContainer");
            this.pnSearchObjectContainer.Name = "pnSearchObjectContainer";
            // 
            // qsoRoot
            // 
            this.qsoRoot.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.qsoRoot, "qsoRoot");
            this.qsoRoot.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.qsoRoot.FormID = null;
            this.qsoRoot.HelpTopicID = null;
            this.qsoRoot.IsStatusReadOnly = false;
            this.qsoRoot.KeyFieldName = "idfnQuerySearchObject";
            this.qsoRoot.MinHeight = 300;
            this.qsoRoot.MultiSelect = false;
            this.qsoRoot.Name = "qsoRoot";
            this.qsoRoot.ObjectName = "QuerySearchObject";
            this.qsoRoot.Status = bv.common.win.FormStatus.Draft;
            this.qsoRoot.TableName = "QuerySearchObject";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.grpGeneralInfo;
            this.navBarControl1.Appearance.Background.Options.UseFont = true;
            this.navBarControl1.Appearance.Button.Options.UseFont = true;
            this.navBarControl1.Appearance.ButtonDisabled.Options.UseFont = true;
            this.navBarControl1.Appearance.ButtonHotTracked.Options.UseFont = true;
            this.navBarControl1.Appearance.ButtonPressed.Options.UseFont = true;
            this.navBarControl1.Appearance.GroupBackground.Options.UseFont = true;
            this.navBarControl1.Appearance.GroupHeader.Options.UseFont = true;
            this.navBarControl1.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.navBarControl1.Appearance.GroupHeaderHotTracked.Options.UseFont = true;
            this.navBarControl1.Appearance.GroupHeaderPressed.Options.UseFont = true;
            this.navBarControl1.Appearance.Hint.Options.UseFont = true;
            this.navBarControl1.Appearance.Item.Options.UseFont = true;
            this.navBarControl1.Appearance.ItemActive.Options.UseFont = true;
            this.navBarControl1.Appearance.ItemDisabled.Options.UseFont = true;
            this.navBarControl1.Appearance.ItemHotTracked.Options.UseFont = true;
            this.navBarControl1.Appearance.ItemPressed.Options.UseFont = true;
            this.navBarControl1.Appearance.LinkDropTarget.Options.UseFont = true;
            this.navBarControl1.Appearance.NavigationPaneHeader.Options.UseFont = true;
            this.navBarControl1.Appearance.NavPaneContentButton.Options.UseFont = true;
            this.navBarControl1.Appearance.NavPaneContentButtonHotTracked.Options.UseFont = true;
            this.navBarControl1.Appearance.NavPaneContentButtonPressed.Options.UseFont = true;
            this.navBarControl1.Appearance.NavPaneContentButtonReleased.Options.UseFont = true;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer2);
            resources.ApplyResources(this.navBarControl1, "navBarControl1");
            this.navBarControl1.ExplorerBarGroupInterval = 1;
            this.navBarControl1.ExplorerBarGroupOuterIndent = 0;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.grpGeneralInfo,
            this.grpSearchObjectTree});
            this.navBarControl1.LookAndFeel.SkinName = "Black";
            this.navBarControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth")));
            this.navBarControl1.OptionsNavPane.ShowOverflowPanel = false;
            this.navBarControl1.OptionsNavPane.ShowSplitter = false;
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Blue");
            this.navBarControl1.GroupExpanded += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.navBarControl1_GroupCollapsed);
            this.navBarControl1.GroupCollapsed += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.navBarControl1_GroupCollapsed);
            // 
            // grpGeneralInfo
            // 
            resources.ApplyResources(this.grpGeneralInfo, "grpGeneralInfo");
            this.grpGeneralInfo.ControlContainer = this.navBarGroupControlContainer1;
            this.grpGeneralInfo.Expanded = true;
            this.grpGeneralInfo.GroupClientHeight = 104;
            this.grpGeneralInfo.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.grpGeneralInfo.Name = "grpGeneralInfo";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.grcQueryInfo);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            resources.ApplyResources(this.navBarGroupControlContainer1, "navBarGroupControlContainer1");
            // 
            // grcQueryInfo
            // 
            this.grcQueryInfo.Appearance.Options.UseFont = true;
            this.grcQueryInfo.AppearanceCaption.Options.UseFont = true;
            this.grcQueryInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.grcQueryInfo.Controls.Add(this.chAddAllKeyFieldValues);
            this.grcQueryInfo.Controls.Add(this.txtQueryName);
            this.grcQueryInfo.Controls.Add(this.lblQueryName);
            this.grcQueryInfo.Controls.Add(this.lblDescription);
            this.grcQueryInfo.Controls.Add(this.txtDefQueryName);
            this.grcQueryInfo.Controls.Add(this.lblDefQueryName);
            this.grcQueryInfo.Controls.Add(this.memDescription);
            resources.ApplyResources(this.grcQueryInfo, "grcQueryInfo");
            this.grcQueryInfo.Name = "grcQueryInfo";
            this.grcQueryInfo.ShowCaption = false;
            // 
            // chAddAllKeyFieldValues
            // 
            resources.ApplyResources(this.chAddAllKeyFieldValues, "chAddAllKeyFieldValues");
            this.chAddAllKeyFieldValues.Name = "chAddAllKeyFieldValues";
            this.chAddAllKeyFieldValues.Properties.Appearance.Options.UseFont = true;
            this.chAddAllKeyFieldValues.Properties.Appearance.Options.UseTextOptions = true;
            this.chAddAllKeyFieldValues.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.chAddAllKeyFieldValues.Properties.AppearanceDisabled.Options.UseFont = true;
            this.chAddAllKeyFieldValues.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.chAddAllKeyFieldValues.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.chAddAllKeyFieldValues.Properties.AppearanceFocused.Options.UseFont = true;
            this.chAddAllKeyFieldValues.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.chAddAllKeyFieldValues.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.chAddAllKeyFieldValues.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.chAddAllKeyFieldValues.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.chAddAllKeyFieldValues.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.chAddAllKeyFieldValues.Properties.Caption = resources.GetString("chAddAllKeyFieldValues.Properties.Caption");
            this.chAddAllKeyFieldValues.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // txtQueryName
            // 
            resources.ApplyResources(this.txtQueryName, "txtQueryName");
            this.txtQueryName.Name = "txtQueryName";
            this.txtQueryName.Properties.Appearance.Options.UseFont = true;
            this.txtQueryName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtQueryName.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtQueryName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtQueryName.Properties.MaxLength = 2000;
            this.txtQueryName.Tag = "{M}";
            this.txtQueryName.EditValueChanged += new System.EventHandler(this.txtQueryName_EditValueChanged);
            // 
            // lblQueryName
            // 
            resources.ApplyResources(this.lblQueryName, "lblQueryName");
            this.lblQueryName.Name = "lblQueryName";
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // txtDefQueryName
            // 
            resources.ApplyResources(this.txtDefQueryName, "txtDefQueryName");
            this.txtDefQueryName.Name = "txtDefQueryName";
            this.txtDefQueryName.Properties.Appearance.Options.UseFont = true;
            this.txtDefQueryName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtDefQueryName.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtDefQueryName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtDefQueryName.Properties.MaxLength = 2000;
            this.txtDefQueryName.Tag = "[en]{M}";
            this.txtDefQueryName.EditValueChanged += new System.EventHandler(this.txtDefQueryName_EditValueChanged);
            // 
            // lblDefQueryName
            // 
            resources.ApplyResources(this.lblDefQueryName, "lblDefQueryName");
            this.lblDefQueryName.Name = "lblDefQueryName";
            // 
            // memDescription
            // 
            resources.ApplyResources(this.memDescription, "memDescription");
            this.memDescription.Name = "memDescription";
            this.memDescription.Properties.Appearance.Options.UseFont = true;
            this.memDescription.Properties.AppearanceDisabled.Options.UseFont = true;
            this.memDescription.Properties.AppearanceFocused.Options.UseFont = true;
            this.memDescription.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.memDescription.Properties.MaxLength = 2000;
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Controls.Add(this.grcQueryObjectTree);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            resources.ApplyResources(this.navBarGroupControlContainer2, "navBarGroupControlContainer2");
            // 
            // grcQueryObjectTree
            // 
            this.grcQueryObjectTree.Appearance.Options.UseFont = true;
            this.grcQueryObjectTree.AppearanceCaption.Options.UseFont = true;
            this.grcQueryObjectTree.Controls.Add(this.btnRemoveChildObject);
            this.grcQueryObjectTree.Controls.Add(this.btnAddChildObject);
            this.grcQueryObjectTree.Controls.Add(this.btnEditQueryType);
            this.grcQueryObjectTree.Controls.Add(this.trlQuery);
            resources.ApplyResources(this.grcQueryObjectTree, "grcQueryObjectTree");
            this.grcQueryObjectTree.Name = "grcQueryObjectTree";
            this.grcQueryObjectTree.ShowCaption = false;
            // 
            // btnRemoveChildObject
            // 
            resources.ApplyResources(this.btnRemoveChildObject, "btnRemoveChildObject");
            this.btnRemoveChildObject.Appearance.Options.UseFont = true;
            this.btnRemoveChildObject.Name = "btnRemoveChildObject";
            this.btnRemoveChildObject.Click += new System.EventHandler(this.btnRemoveChildObject_Click);
            // 
            // btnAddChildObject
            // 
            resources.ApplyResources(this.btnAddChildObject, "btnAddChildObject");
            this.btnAddChildObject.Appearance.Options.UseFont = true;
            this.btnAddChildObject.Name = "btnAddChildObject";
            this.btnAddChildObject.Click += new System.EventHandler(this.btnAddChildObject_Click);
            // 
            // btnEditQueryType
            // 
            resources.ApplyResources(this.btnEditQueryType, "btnEditQueryType");
            this.btnEditQueryType.Appearance.Options.UseFont = true;
            this.btnEditQueryType.Name = "btnEditQueryType";
            this.btnEditQueryType.Click += new System.EventHandler(this.btnEditQueryType_Click);
            // 
            // trlQuery
            // 
            resources.ApplyResources(this.trlQuery, "trlQuery");
            this.trlQuery.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colQuerySearchObjectID,
            this.colParentQuerySearchObjectID,
            this.colSearchObject,
            this.colOrder});
            this.trlQuery.Name = "trlQuery";
            this.trlQuery.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbSearchObject});
            this.trlQuery.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.trlQuery_AfterFocusNode);
            // 
            // colQuerySearchObjectID
            // 
            resources.ApplyResources(this.colQuerySearchObjectID, "colQuerySearchObjectID");
            this.colQuerySearchObjectID.FieldName = "idfnQuerySearchObject";
            this.colQuerySearchObjectID.Name = "colQuerySearchObjectID";
            // 
            // colParentQuerySearchObjectID
            // 
            resources.ApplyResources(this.colParentQuerySearchObjectID, "colParentQuerySearchObjectID");
            this.colParentQuerySearchObjectID.FieldName = "idfnParentQuerySearchObject";
            this.colParentQuerySearchObjectID.Name = "colParentQuerySearchObjectID";
            // 
            // colSearchObject
            // 
            resources.ApplyResources(this.colSearchObject, "colSearchObject");
            this.colSearchObject.ColumnEdit = this.cbSearchObject;
            this.colSearchObject.FieldName = "idfsSearchObject";
            this.colSearchObject.Name = "colSearchObject";
            this.colSearchObject.OptionsColumn.AllowEdit = false;
            this.colSearchObject.OptionsColumn.AllowMove = false;
            this.colSearchObject.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colSearchObject.OptionsColumn.AllowSort = false;
            // 
            // cbSearchObject
            // 
            this.cbSearchObject.Appearance.Options.UseFont = true;
            this.cbSearchObject.AppearanceDisabled.Options.UseFont = true;
            this.cbSearchObject.AppearanceDropDown.Options.UseFont = true;
            this.cbSearchObject.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbSearchObject.AppearanceFocused.Options.UseFont = true;
            this.cbSearchObject.AppearanceReadOnly.Options.UseFont = true;
            resources.ApplyResources(this.cbSearchObject, "cbSearchObject");
            serializableAppearanceObject1.Options.UseFont = true;
            this.cbSearchObject.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbSearchObject.Buttons"))), resources.GetString("cbSearchObject.Buttons1"), ((int)(resources.GetObject("cbSearchObject.Buttons2"))), ((bool)(resources.GetObject("cbSearchObject.Buttons3"))), ((bool)(resources.GetObject("cbSearchObject.Buttons4"))), ((bool)(resources.GetObject("cbSearchObject.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbSearchObject.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbSearchObject.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("cbSearchObject.Buttons8"), ((object)(resources.GetObject("cbSearchObject.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbSearchObject.Buttons10"))), ((bool)(resources.GetObject("cbSearchObject.Buttons11"))))});
            this.cbSearchObject.Name = "cbSearchObject";
            // 
            // colOrder
            // 
            resources.ApplyResources(this.colOrder, "colOrder");
            this.colOrder.FieldName = "intOrder";
            this.colOrder.Name = "colOrder";
            // 
            // grpSearchObjectTree
            // 
            resources.ApplyResources(this.grpSearchObjectTree, "grpSearchObjectTree");
            this.grpSearchObjectTree.ControlContainer = this.navBarGroupControlContainer2;
            this.grpSearchObjectTree.Expanded = true;
            this.grpSearchObjectTree.GroupClientHeight = 135;
            this.grpSearchObjectTree.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.grpSearchObjectTree.Name = "grpSearchObjectTree";
            // 
            // btnCancelChanges
            // 
            resources.ApplyResources(this.btnCancelChanges, "btnCancelChanges");
            this.btnCancelChanges.Appearance.Options.UseFont = true;
            this.btnCancelChanges.Image = global::EIDSS.RAM.Properties.Resources.Clear_Cancel_Changes1;
            this.btnCancelChanges.Name = "btnCancelChanges";
            this.btnCancelChanges.Click += new System.EventHandler(this.btnCancelChanges_Click);
            // 
            // mnuQueryType
            // 
            this.mnuQueryType.Name = "mnuQueryType";
            resources.ApplyResources(this.mnuQueryType, "mnuQueryType");
            this.mnuQueryType.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuQueryType_ItemClicked);
            // 
            // mnuChildObject
            // 
            this.mnuChildObject.Name = "mnuQueryType";
            resources.ApplyResources(this.mnuChildObject, "mnuChildObject");
            this.mnuChildObject.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuChildObject_ItemClicked);
            // 
            // btnCopy
            // 
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.Appearance.Options.UseFont = true;
            this.btnCopy.Image = global::EIDSS.RAM.Properties.Resources.copy;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // QueryDetail
            // 
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnCancelChanges);
            this.Controls.Add(this.pncQuery);
            this.FormID = "R02";
            this.HelpTopicID = "AVR_Query_Builder";
            this.KeyFieldName = "idflQuery";
            this.LeftIcon = global::EIDSS.RAM.Properties.Resources.query_big;
            this.MinHeight = 600;
            this.MinimumSize = new System.Drawing.Size(732, 462);
            this.MinWidth = 732;
            this.Name = "QueryDetail";
            this.ObjectName = "Query";
            this.ShowNewButton = true;
            this.Sizable = true;
            this.TableName = "tasQuery";
            this.OnAfterPost += new System.EventHandler(this.QueryDetail_OnAfterPost);
            this.AfterLoadData += new System.EventHandler(this.QueryDetail_AfterLoadData);
            this.Controls.SetChildIndex(this.pncQuery, 0);
            this.Controls.SetChildIndex(this.btnCancelChanges, 0);
            this.Controls.SetChildIndex(this.btnCopy, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pncQuery)).EndInit();
            this.pncQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnSearchObjectContainer)).EndInit();
            this.pnSearchObjectContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.navBarControl1.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcQueryInfo)).EndInit();
            this.grcQueryInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chAddAllKeyFieldValues.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueryName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefQueryName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            this.navBarGroupControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcQueryObjectTree)).EndInit();
            this.grcQueryObjectTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSearchObject)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pncQuery;
        private QuerySearchObjectInfo qsoRoot;
        private DevExpress.XtraEditors.MemoEdit memDescription;
        private DevExpress.XtraEditors.GroupControl grcQueryInfo;
        private DevExpress.XtraEditors.TextEdit txtDefQueryName;
        private System.Windows.Forms.Label lblDefQueryName;
        private System.Windows.Forms.Label lblDescription;
        private DevExpress.XtraEditors.SimpleButton btnCancelChanges;
        private DevExpress.XtraEditors.SimpleButton btnEditQueryType;
        private System.Windows.Forms.ContextMenuStrip mnuQueryType;
        private DevExpress.XtraEditors.GroupControl grcQueryObjectTree;
        private DevExpress.XtraTreeList.TreeList trlQuery;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSearchObject;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbSearchObject;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colQuerySearchObjectID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentQuerySearchObjectID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colOrder;
        private DevExpress.XtraEditors.SimpleButton btnRemoveChildObject;
        private DevExpress.XtraEditors.SimpleButton btnAddChildObject;
        private System.Windows.Forms.ContextMenuStrip mnuChildObject;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private DevExpress.XtraEditors.TextEdit txtQueryName;
        private System.Windows.Forms.Label lblQueryName;
        private DevExpress.XtraEditors.PanelControl pnSearchObjectContainer;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup grpGeneralInfo;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private DevExpress.XtraNavBar.NavBarGroup grpSearchObjectTree;
        private DevExpress.XtraEditors.CheckEdit chAddAllKeyFieldValues;

    }
}
