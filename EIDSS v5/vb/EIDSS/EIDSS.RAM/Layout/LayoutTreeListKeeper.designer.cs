namespace EIDSS.RAM.Layout
{
    partial class LayoutTreeListKeeper
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutTreeListKeeper));
            this.stateImageList = new System.Windows.Forms.ImageList(this.components);
            this.tree = new DevExpress.XtraTreeList.TreeList();
            this.columnName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnNationalName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnIsLayout = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnReadOnly = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnParentID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnShare = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.treeBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.biNewFolder = new DevExpress.XtraBars.BarButtonItem();
            this.biDeleteFolder = new DevExpress.XtraBars.BarButtonItem();
            this.treePopupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.panelButtons = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treePopupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelButtons)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // stateImageList
            // 
            this.stateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stateImageList.ImageStream")));
            this.stateImageList.TransparentColor = System.Drawing.Color.Magenta;
            this.stateImageList.Images.SetKeyName(0, "");
            this.stateImageList.Images.SetKeyName(1, "");
            this.stateImageList.Images.SetKeyName(2, "");
            this.stateImageList.Images.SetKeyName(3, "");
            this.stateImageList.Images.SetKeyName(4, "layout_common.bmp");
            this.stateImageList.Images.SetKeyName(5, "Table.gif");
            // 
            // tree
            // 
            this.tree.AllowDrop = true;
            this.tree.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.tree.Appearance.EvenRow.Options.UseBackColor = true;
            this.tree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.columnName,
            this.columnNationalName,
            this.columnIsLayout,
            this.columnReadOnly,
            this.columnID,
            this.columnParentID,
            this.columnShare});
            resources.ApplyResources(this.tree, "tree");
            this.tree.DragNodesMode = DevExpress.XtraTreeList.TreeListDragNodesMode.Advanced;
            this.tree.Name = "tree";
            this.tree.OptionsBehavior.AutoChangeParent = false;
            this.tree.OptionsBehavior.AutoNodeHeight = false;
            this.tree.OptionsBehavior.CanCloneNodesOnDrop = true;
            this.tree.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.tree.OptionsBehavior.DragNodes = true;
            this.tree.OptionsBehavior.KeepSelectedOnClick = false;
            this.tree.OptionsBehavior.ShowEditorOnMouseUp = true;
            this.tree.OptionsBehavior.SmartMouseHover = false;
            this.tree.OptionsView.ShowHorzLines = false;
            this.tree.OptionsView.ShowIndicator = false;
            this.tree.OptionsView.ShowVertLines = false;
            this.tree.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryImageComboBox1});
            this.tree.StateImageList = this.stateImageList;
            this.tree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tree_MouseUp);
            this.tree.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.tree_CustomDrawNodeCell);
            this.tree.DragOver += new System.Windows.Forms.DragEventHandler(this.tree_DragOver);
            this.tree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tree_FocusedNodeChanged);
            this.tree.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.tree_GetStateImage);
            this.tree.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tree_KeyUp);
            this.tree.DoubleClick += new System.EventHandler(this.tree_DoubleClick);
            this.tree.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.tree_CellValueChanged);
            this.tree.EditorKeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_EditorKeyDown);
            this.tree.DragDrop += new System.Windows.Forms.DragEventHandler(this.tree_DragDrop);
            // 
            // columnName
            // 
            resources.ApplyResources(this.columnName, "columnName");
            this.columnName.FieldName = "DefaultName";
            this.columnName.Name = "columnName";
            this.columnName.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            // 
            // columnNationalName
            // 
            resources.ApplyResources(this.columnNationalName, "columnNationalName");
            this.columnNationalName.FieldName = "NationalName";
            this.columnNationalName.Name = "columnNationalName";
            this.columnNationalName.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            // 
            // columnIsLayout
            // 
            resources.ApplyResources(this.columnIsLayout, "columnIsLayout");
            this.columnIsLayout.FieldName = "IsLayout";
            this.columnIsLayout.Name = "columnIsLayout";
            this.columnIsLayout.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Boolean;
            // 
            // columnReadOnly
            // 
            resources.ApplyResources(this.columnReadOnly, "columnReadOnly");
            this.columnReadOnly.FieldName = "ReadOnly";
            this.columnReadOnly.Name = "columnReadOnly";
            this.columnReadOnly.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Boolean;
            // 
            // columnID
            // 
            resources.ApplyResources(this.columnID, "columnID");
            this.columnID.FieldName = "ID";
            this.columnID.Name = "columnID";
            // 
            // columnParentID
            // 
            resources.ApplyResources(this.columnParentID, "columnParentID");
            this.columnParentID.FieldName = "ParentID";
            this.columnParentID.Name = "columnParentID";
            // 
            // columnShare
            // 
            resources.ApplyResources(this.columnShare, "columnShare");
            this.columnShare.FieldName = "blnShareLayout";
            this.columnShare.Name = "columnShare";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AllowFocused = false;
            resources.ApplyResources(this.repositoryItemDateEdit1, "repositoryItemDateEdit1");
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemDateEdit1.Buttons"))))});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repositoryImageComboBox1
            // 
            this.repositoryImageComboBox1.AllowFocused = false;
            resources.ApplyResources(this.repositoryImageComboBox1, "repositoryImageComboBox1");
            this.repositoryImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryImageComboBox1.Buttons"))))});
            this.repositoryImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("repositoryImageComboBox1.Items"), ((object)(resources.GetObject("repositoryImageComboBox1.Items1"))), ((int)(resources.GetObject("repositoryImageComboBox1.Items2")))),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("repositoryImageComboBox1.Items3"), ((object)(resources.GetObject("repositoryImageComboBox1.Items4"))), ((int)(resources.GetObject("repositoryImageComboBox1.Items5")))),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("repositoryImageComboBox1.Items6"), ((object)(resources.GetObject("repositoryImageComboBox1.Items7"))), ((int)(resources.GetObject("repositoryImageComboBox1.Items8"))))});
            this.repositoryImageComboBox1.Name = "repositoryImageComboBox1";
            // 
            // treeBarManager
            // 
            this.treeBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.treeBarManager.DockControls.Add(this.barDockControlTop);
            this.treeBarManager.DockControls.Add(this.barDockControlBottom);
            this.treeBarManager.DockControls.Add(this.barDockControlLeft);
            this.treeBarManager.DockControls.Add(this.barDockControlRight);
            this.treeBarManager.Form = this;
            this.treeBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.biNewFolder,
            this.biDeleteFolder});
            this.treeBarManager.MainMenu = this.bar2;
            this.treeBarManager.MaxItemId = 2;
            this.treeBarManager.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            resources.ApplyResources(this.bar1, "bar1");
            this.bar1.Visible = false;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.bar2, "bar2");
            this.bar2.Visible = false;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.bar3, "bar3");
            this.bar3.Visible = false;
            // 
            // barDockControlTop
            // 
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            // 
            // barDockControlBottom
            // 
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            // 
            // barDockControlLeft
            // 
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            // 
            // barDockControlRight
            // 
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            // 
            // biNewFolder
            // 
            resources.ApplyResources(this.biNewFolder, "biNewFolder");
            this.biNewFolder.Id = 0;
            this.biNewFolder.Name = "biNewFolder";
            this.biNewFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biNewFolder_ItemClick);
            // 
            // biDeleteFolder
            // 
            resources.ApplyResources(this.biDeleteFolder, "biDeleteFolder");
            this.biDeleteFolder.Id = 1;
            this.biDeleteFolder.Name = "biDeleteFolder";
            this.biDeleteFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biDeleteFolder_ItemClick);
            // 
            // treePopupMenu
            // 
            this.treePopupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biNewFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.biDeleteFolder)});
            this.treePopupMenu.Manager = this.treeBarManager;
            this.treePopupMenu.Name = "treePopupMenu";
            this.treePopupMenu.CloseUp += new System.EventHandler(this.treePopupMenu_CloseUp);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnOK);
            this.panelButtons.Controls.Add(this.btnCancel);
            resources.ApplyResources(this.panelButtons, "panelButtons");
            this.panelButtons.Name = "panelButtons";
            // 
            // LayoutTreeListKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tree);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "LayoutTreeListKeeper";
            ((System.ComponentModel.ISupportInitialize)(this.tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treePopupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelButtons)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList stateImageList;
        private DevExpress.XtraTreeList.TreeList tree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnNationalName;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnIsLayout;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryImageComboBox1;
        private DevExpress.XtraBars.BarManager treeBarManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.PopupMenu treePopupMenu;
        private DevExpress.XtraBars.BarButtonItem biNewFolder;
        private DevExpress.XtraBars.BarButtonItem biDeleteFolder;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnReadOnly;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnParentID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnShare;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.PanelControl panelButtons;
    }
}