namespace eidss.avr.QueryLayoutTree
{
    partial class QueryLayoutTreePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryLayoutTreePanel));
            this.stateImageList = new System.Windows.Forms.ImageList(this.components);
            this.tree = new DevExpress.XtraTreeList.TreeList();
            this.columnName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnNationalName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnIsLayout = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnReadOnly = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnParentID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnShare = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnIsQuery = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryImageComboBox1)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(QueryLayoutTreePanel), out resources);
            // Form Is Localizable: True
            // 
            // stateImageList
            // 
            this.stateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stateImageList.ImageStream")));
            this.stateImageList.TransparentColor = System.Drawing.Color.Magenta;
            this.stateImageList.Images.SetKeyName(0, "folder_16x16.png");
            this.stateImageList.Images.SetKeyName(1, "folder_open_16x16.png");
            this.stateImageList.Images.SetKeyName(2, "query_common.ico");
            this.stateImageList.Images.SetKeyName(3, "query_open_16x16.png");
            this.stateImageList.Images.SetKeyName(4, "layout_16x16.png");
            // 
            // tree
            // 
            this.tree.AllowDrop = true;
            this.tree.Appearance.Empty.BackColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.Empty.BackColor")));
            this.tree.Appearance.Empty.Options.UseBackColor = true;
            this.tree.Appearance.EvenRow.BackColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.EvenRow.BackColor")));
            this.tree.Appearance.EvenRow.ForeColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.EvenRow.ForeColor")));
            this.tree.Appearance.EvenRow.Options.UseBackColor = true;
            this.tree.Appearance.EvenRow.Options.UseForeColor = true;
            this.tree.Appearance.FocusedRow.BackColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.FocusedRow.BackColor")));
            this.tree.Appearance.FocusedRow.ForeColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.FocusedRow.ForeColor")));
            this.tree.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tree.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tree.Appearance.FooterPanel.BackColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.FooterPanel.BackColor")));
            this.tree.Appearance.FooterPanel.BackColor2 = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.FooterPanel.BackColor2")));
            this.tree.Appearance.FooterPanel.BorderColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.FooterPanel.BorderColor")));
            this.tree.Appearance.FooterPanel.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("tree.Appearance.FooterPanel.GradientMode")));
            this.tree.Appearance.FooterPanel.Options.UseBackColor = true;
            this.tree.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.tree.Appearance.GroupButton.BackColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.GroupButton.BackColor")));
            this.tree.Appearance.GroupButton.BorderColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.GroupButton.BorderColor")));
            this.tree.Appearance.GroupButton.ForeColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.GroupButton.ForeColor")));
            this.tree.Appearance.GroupButton.Options.UseBackColor = true;
            this.tree.Appearance.GroupButton.Options.UseBorderColor = true;
            this.tree.Appearance.GroupButton.Options.UseForeColor = true;
            this.tree.Appearance.GroupFooter.BackColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.GroupFooter.BackColor")));
            this.tree.Appearance.GroupFooter.BorderColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.GroupFooter.BorderColor")));
            this.tree.Appearance.GroupFooter.ForeColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.GroupFooter.ForeColor")));
            this.tree.Appearance.GroupFooter.Options.UseBackColor = true;
            this.tree.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.tree.Appearance.GroupFooter.Options.UseForeColor = true;
            this.tree.Appearance.HeaderPanel.BackColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.HeaderPanel.BackColor")));
            this.tree.Appearance.HeaderPanel.BackColor2 = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.HeaderPanel.BackColor2")));
            this.tree.Appearance.HeaderPanel.BorderColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.HeaderPanel.BorderColor")));
            this.tree.Appearance.HeaderPanel.ForeColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.HeaderPanel.ForeColor")));
            this.tree.Appearance.HeaderPanel.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("tree.Appearance.HeaderPanel.GradientMode")));
            this.tree.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.tree.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.tree.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tree.Appearance.HideSelectionRow.BackColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.HideSelectionRow.BackColor")));
            this.tree.Appearance.HideSelectionRow.ForeColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.HideSelectionRow.ForeColor")));
            this.tree.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tree.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tree.Appearance.HorzLine.BackColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.HorzLine.BackColor")));
            this.tree.Appearance.HorzLine.Options.UseBackColor = true;
            this.tree.Appearance.OddRow.BackColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.OddRow.BackColor")));
            this.tree.Appearance.OddRow.ForeColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.OddRow.ForeColor")));
            this.tree.Appearance.OddRow.Options.UseBackColor = true;
            this.tree.Appearance.OddRow.Options.UseForeColor = true;
            this.tree.Appearance.Preview.BackColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.Preview.BackColor")));
            this.tree.Appearance.Preview.ForeColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.Preview.ForeColor")));
            this.tree.Appearance.Preview.Options.UseBackColor = true;
            this.tree.Appearance.Preview.Options.UseForeColor = true;
            this.tree.Appearance.Row.BackColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.Row.BackColor")));
            this.tree.Appearance.Row.ForeColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.Row.ForeColor")));
            this.tree.Appearance.Row.Options.UseBackColor = true;
            this.tree.Appearance.Row.Options.UseForeColor = true;
            this.tree.Appearance.SelectedRow.BackColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.SelectedRow.BackColor")));
            this.tree.Appearance.SelectedRow.ForeColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.SelectedRow.ForeColor")));
            this.tree.Appearance.SelectedRow.Options.UseBackColor = true;
            this.tree.Appearance.SelectedRow.Options.UseForeColor = true;
            this.tree.Appearance.TreeLine.BackColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.TreeLine.BackColor")));
            this.tree.Appearance.TreeLine.Options.UseBackColor = true;
            this.tree.Appearance.VertLine.BackColor = ((System.Drawing.Color)(resources.GetObject("tree.Appearance.VertLine.BackColor")));
            this.tree.Appearance.VertLine.Options.UseBackColor = true;
            this.tree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.columnName,
            this.columnNationalName,
            this.columnIsLayout,
            this.columnReadOnly,
            this.columnID,
            this.columnParentID,
            this.columnShare,
            this.columnIsQuery});
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
            this.tree.OptionsMenu.EnableColumnMenu = false;
            this.tree.OptionsMenu.EnableFooterMenu = false;
            this.tree.OptionsMenu.ShowAutoFilterRowItem = false;
            this.tree.OptionsView.EnableAppearanceEvenRow = true;
            this.tree.OptionsView.EnableAppearanceOddRow = true;
            this.tree.OptionsView.ShowHorzLines = false;
            this.tree.OptionsView.ShowIndentAsRowStyle = true;
            this.tree.OptionsView.ShowIndicator = false;
            this.tree.OptionsView.ShowVertLines = false;
            this.tree.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryImageComboBox1});
            this.tree.StateImageList = this.stateImageList;
            this.tree.ToolTipController = this.toolTipController;
            this.tree.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.tree_GetStateImage);
            this.tree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tree_FocusedNodeChanged);
            this.tree.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.tree_CustomDrawNodeCell);
            this.tree.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.tree_CellValueChanged);
            this.tree.EditorKeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_EditorKeyDown);
            this.tree.DragDrop += new System.Windows.Forms.DragEventHandler(this.tree_DragDrop);
            this.tree.DragOver += new System.Windows.Forms.DragEventHandler(this.tree_DragOver);
            this.tree.DoubleClick += new System.EventHandler(this.tree_DoubleClick);
            this.tree.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tree_KeyUp);
            this.tree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tree_MouseClick);
            // 
            // columnName
            // 
            resources.ApplyResources(this.columnName, "columnName");
            this.columnName.FieldName = "DefaultName";
            this.columnName.Name = "columnName";
            // 
            // columnNationalName
            // 
            resources.ApplyResources(this.columnNationalName, "columnNationalName");
            this.columnNationalName.FieldName = "NationalName";
            this.columnNationalName.Name = "columnNationalName";
            this.columnNationalName.OptionsColumn.AllowEdit = false;
            // 
            // columnIsLayout
            // 
            resources.ApplyResources(this.columnIsLayout, "columnIsLayout");
            this.columnIsLayout.FieldName = "IsLayout";
            this.columnIsLayout.Name = "columnIsLayout";
            // 
            // columnReadOnly
            // 
            resources.ApplyResources(this.columnReadOnly, "columnReadOnly");
            this.columnReadOnly.FieldName = "ReadOnly";
            this.columnReadOnly.Name = "columnReadOnly";
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
            // columnIsQuery
            // 
            resources.ApplyResources(this.columnIsQuery, "columnIsQuery");
            this.columnIsQuery.FieldName = "IsQuery";
            this.columnIsQuery.Name = "columnIsQuery";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AllowFocused = false;
            resources.ApplyResources(this.repositoryItemDateEdit1, "repositoryItemDateEdit1");
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemDateEdit1.Buttons"))))});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
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
            // toolTipController
            // 
            this.toolTipController.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.toolTipController_GetActiveObjectInfo);
            // 
            // QueryLayoutTreePanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tree);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.Name = "QueryLayoutTreePanel";
            this.Status = bv.common.win.FormStatus.Draft;
            ((System.ComponentModel.ISupportInitialize)(this.tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryImageComboBox1)).EndInit();
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
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnReadOnly;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnParentID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnShare;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnIsQuery;
        private DevExpress.Utils.ToolTipController toolTipController;
    }
}