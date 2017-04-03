using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.Common;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.Core;
using eidss.model.Resources;
using Localizer = bv.common.Core.Localizer;

namespace EIDSS.RAM.Layout
{
    public partial class LayoutTreeListKeeper : XtraUserControl
    {
        public event EventHandler<EventArgs> OnSelect;
        public event EventHandler<QueryResultValueEventArgs> OnSelectChanged;
        private const int IndexExpanded = 1;
        private const int IndexCollapsed = 0;
        private const int IndexLayout = 5;
        private readonly string m_MessageFolderExists;
        private readonly string m_DefaultFolderName;
        private readonly string m_NationalFolderName;
        private string m_OldDefaultName;
        private string m_OldNationalName;

        private TreeListNode m_SavedFocused;
        private List<LayoutTreeElement> m_DataSource;
        private List<LayoutTreeElement> m_DataSourceOriginal;

        private bool m_NeedRestoreFocused;
        private LayoutInfoPresenter m_LayoutInfoPresenter;
        private bool m_ReadOnly;
        private bool m_AllowEdit;

        public LayoutTreeListKeeper()
        {
            InitializeComponent();

            if (WinUtils.IsComponentInDesignMode(this))
            {
                return;
            }

            m_DefaultFolderName = EidssMessages.Get("msgDefaultFolderName", "New folder", Localizer.lngEn);
            m_NationalFolderName = EidssMessages.Get("msgDefaultFolderName", "New folder");
            m_MessageFolderExists = EidssMessages.Get("msgFolderExists",
                                                      "Cannot rename {0}: A folder with the name you specified already exists. Specify a different folder name.");

            columnNationalName.Visible = (ModelUserContext.CurrentLanguage != Localizer.lngEn);
        }

        #region Properties

        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReadOnly
        {
            get { return m_ReadOnly; }
            set
            {
                m_ReadOnly = value;
                tree.AllowDrop = !value;
                panelButtons.Visible = value;
            }
        }

        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Cancel { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LayoutInfoPresenter LayoutInfoPresenter
        {
            get { return m_LayoutInfoPresenter; }
            set { m_LayoutInfoPresenter = value; }
        }

        [DefaultValue(null)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<LayoutTreeElement> DataSource
        {
            get { return m_DataSource; }
            set
            {
                m_DataSource = value ?? new List<LayoutTreeElement>();
                m_DataSourceOriginal = new List<LayoutTreeElement>(m_DataSource.ToArray());
                tree.Nodes.Clear();
                tree.DataSource = m_DataSource;
                tree.ExpandAll();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<LayoutTreeElement> DataSourceOriginal
        {
            get { return m_DataSourceOriginal; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LayoutPopupElement SelectedElement
        {
            get { return new LayoutPopupElement(SelectedId, SelectedLayoutName); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedLayoutName
        {
            get
            {
                TreeListNode node = tree.FocusedNode;
                bool isLayout = ((node != null) && IsLayoutNode(node));
                return isLayout ? GetNodeNationalName(node) : string.Empty;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedPath
        {
            get
            {
                TreeListNode node = tree.FocusedNode;
                var path = new StringBuilder();
                AppendPath(node, path);
                return path.ToString();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long SelectedId
        {
            get
            {
                TreeListNode node = tree.FocusedNode;
                
                
                return (node != null) ? GetNodeId(node) : -1;
            }
            set { tree.FocusedNode = GetNode(value, tree.Nodes); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long SelectedFolderId
        {
            get { return ExtractFolderId(tree.FocusedNode); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private long ExtractFolderId(TreeListNode node)
        {
            if (node == null)
            {
                return -1;
            }
            return !IsLayoutNode(node)
                       ? GetNodeId(node)
                       : ExtractFolderId(node.ParentNode);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AllowCreateFolder
        {
            get
            {
                if (ReadOnly || !RamPermissions.InsertPermission)
                {
                    return false;
                }
                if (tree.FocusedNode == null)
                {
                    return true;
                }
                return (!IsLayoutNode(tree.FocusedNode));
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AllowDeleteFolder
        {
            get { return AllowCreateFolder && CanDelete(tree.FocusedNode); }
        }

        #endregion

        #region Folder operations

        public void CreateFolder()
        {
            if (m_LayoutInfoPresenter == null)
            {
                throw new RamException(@"LayoutInfoPresenter is not initialized for LayoutTreeListKeeper");
            }

            if (IsFolderDepthTooBig())
            {
                return;
            }

            var newNode = new LayoutTreeElement(m_LayoutInfoPresenter.NewId(), SelectedFolderId,
                                                m_LayoutInfoPresenter.SharedPresenter.SharedModel.
                                                    SelectedQueryId, false,
                                                GetFolderNameWithPrefix(false),
                                                GetFolderNameWithPrefix(true), false, true);
            newNode.SetChanges();
            DataSource.Add(newNode);

            tree.RefreshDataSource();
            if (tree.FocusedNode != null)
            {
                tree.FocusedNode.ExpandAll();
            }
        }

        public void DeleteFolder()
        {
            TreeListNode focusedNode = tree.FocusedNode;
            if (DisableEditNode(focusedNode))
            {
                return;
            }
            string baseMsg = EidssMessages.Get("msgConfirmDeleteFolder",
                                               "Are you sure you want to delete the folder '{0}' and all its contents?");
            string msgDelete = string.Format(baseMsg, GetNodeNationalName(focusedNode));
            if (MessageForm.Show(msgDelete, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // todo:[Ivan] (Old) check that therer are no hidden layout (belong to other users) here
                tree.DeleteNode(focusedNode);
                tree.RefreshDataSource();
            }
        }

        private string GetFolderNameWithPrefix(bool isNational)
        {
            string initialFolderName = isNational ? m_NationalFolderName : m_DefaultFolderName;
            string folderName = initialFolderName;
            for (int index = 2; index < int.MaxValue; index++)
            {
                bool isDublicate = DataSource.Any(
                    element =>
                    ((element.NationalName == folderName) && isNational) ||
                    (element.DefaultName == folderName && !isNational));
                if (!isDublicate)
                {
                    break;
                }

                folderName = string.Format("{0} ({1})", Utils.Str(initialFolderName), index);
            }
            return folderName;
        }

        #endregion

        #region click handlers

        private void tree_EditorKeyDown(object sender, KeyEventArgs e)
        {
            m_OldDefaultName = GetNodeDefaultName(tree.FocusedNode);
            m_OldNationalName = GetNodeNationalName(tree.FocusedNode);
        }

        private void tree_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            foreach (LayoutTreeElement element in DataSource)
            {
                if ((e.Column == columnName) &&
                    (element.DefaultName.ToLowerInvariant() == Utils.Str(e.Value).ToLowerInvariant()) &&
                    (GetNodeId(e.Node) != element.ID))
                {
                    MessageForm.Show(string.Format(m_MessageFolderExists, Utils.Str(e.Value)));
                    e.Node.SetValue(columnName.FieldName, m_OldDefaultName);
                }
                if ((e.Column == columnNationalName) &&
                    (element.NationalName.ToLowerInvariant() == Utils.Str(e.Value).ToLowerInvariant()) &&
                    (GetNodeId(e.Node) != element.ID))
                {
                    MessageForm.Show(string.Format(m_MessageFolderExists, Utils.Str(e.Value)));
                    e.Node.SetValue(columnNationalName.FieldName, m_OldNationalName);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Cancel = false;
            OnSelectChanged.SafeRaise(this, new QueryResultValueEventArgs(SelectedElement));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel = true;
            OnSelectChanged.SafeRaise(this, new QueryResultValueEventArgs(SelectedElement));
        }

        private void tree_DoubleClick(object sender, EventArgs e)
        {
            if ((e is MouseEventArgs) && ((MouseEventArgs) e).Button == MouseButtons.Left)
            {
                if (ReadOnly)
                {
                    btnOK_Click(sender, e);
                }
                else
                {
                    foreach (TreeListColumn column in tree.Columns)
                    {
                        column.OptionsColumn.AllowEdit = m_AllowEdit;
                    }
                }
            }
        }

        private void tree_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnOK_Click(sender, e);
                    break;
                case Keys.Escape:
                    btnCancel_Click(sender, e);
                    break;
            }
        }

       

        #endregion

        #region Appearence

        private void tree_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            if (IsLayoutNode(e.Node))
            {
                e.NodeImageIndex = IndexLayout;
            }
            else
            {
                e.NodeImageIndex = e.Node.Expanded ? IndexExpanded : IndexCollapsed;
            }
        }

        private void tree_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            OnSelect.SafeRaise(this, EventArgs.Empty);

            if (e.Node == null)
            {
                return;
            }
            m_AllowEdit = !(DisableEditNode(e.Node));
            foreach (TreeListColumn column in tree.Columns)
            {
                column.OptionsColumn.AllowEdit = false;
            }

//            if (e.Node == null)
//                return;
//            bool allowEdit = !(DisableEditNode(e.Node));
//            foreach (TreeListColumn column in tree.Columns)
//            {
//                column.OptionsColumn.AllowEdit = allowEdit;
//            }
        }

        private void tree_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (IsReadOnlyNode(e.Node))
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        #endregion

        #region Drag Methods

        private void tree_DragOver(object sender, DragEventArgs e)
        {
            DragHandler(e);
        }

        private void tree_DragDrop(object sender, DragEventArgs e)
        {
            DragHandler(e);
            if (e.Effect == DragDropEffects.None)
            {
                return;
            }

            LayoutTreeElement childElement = GetSourceElement(e);
            TreeListNode parentNode = GetDestNode(e);
            if (IsFolderDepthTooBig(parentNode, GetNode(childElement.ID, tree.Nodes)))
            {
                return;
            }

            long? parentId = (parentNode == null) ? null : (long?) GetNodeId(parentNode);

            childElement.ParentID = parentId;

            tree.RefreshDataSource();
            if (parentNode != null)
            {
                parentNode.ExpandAll();
            }
            e.Effect = DragDropEffects.None;
        }

        private void DragHandler(DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

            TreeListNode sourceNode = GetSourceNode(e);
            TreeListNode destNode = GetDestNode(e);
            if (ReadOnly || IsReadOnlyNode(sourceNode) || (destNode != null && IsLayoutNode(destNode)))
            {
                e.Effect = DragDropEffects.None;
            }
        }

        #endregion

        #region Popup Menu

        #region process popup

        private void treePopupMenu_CloseUp(object sender, EventArgs e)
        {
            if (m_NeedRestoreFocused)
            {
                tree.FocusedNode = m_SavedFocused;
            }
        }

        private void tree_MouseUp(object sender, MouseEventArgs e)
        {
            if (!IsRightClick(e))
            {
                return;
            }

            TreeListNode focusedNode;
            if (!AllowPopupMenu(out focusedNode))
            {
                return;
            }

            ShowPopupMenu(focusedNode);
        }

        private bool IsRightClick(MouseEventArgs e)
        {
            return (e.Button == MouseButtons.Right &&
                    ModifierKeys == Keys.None &&
                    tree.State == TreeListState.Regular);
        }

        private bool AllowPopupMenu(out TreeListNode focusedNode)
        {
            Point point = tree.PointToClient(MousePosition);
            TreeListHitInfo info = tree.CalcHitInfo(point);
            focusedNode = info.Node;

            if (ReadOnly)
            {
                return false;
            }
            if (focusedNode == null)
            {
                return true;
            }
            return (info.HitInfoType == HitInfoType.Cell &&
                    !IsLayoutNode(focusedNode));
        }

        private void ShowPopupMenu(TreeListNode focusedNode)
        {
            biDeleteFolder.Enabled = CanDelete(focusedNode);
            biNewFolder.Enabled = RamPermissions.InsertPermission;

            m_SavedFocused = tree.FocusedNode;
            m_NeedRestoreFocused = true;
            tree.FocusedNode = focusedNode;
            treePopupMenu.ShowPopup(MousePosition);
        }

        private bool CanDelete(TreeListNode node)
        {
            if (DisableEditNode(node) || (!RamPermissions.DeletePermission))
            {
                return false;
            }

            IEnumerable<TreeListNode> listNodes = node.Nodes.Cast<TreeListNode>();
            return listNodes.All(CanDelete);
        }

        #endregion

        #region button handlers

        private void biNewFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateFolder();
        }

        private void biDeleteFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteFolder();
        }

        #endregion

        #endregion

        #region Helper methods

        private bool DisableEditNode(TreeListNode node)
        {
            return node == null || ReadOnly || IsLayoutNode(node) || IsReadOnlyNode(node);
        }

        private LayoutTreeElement GetSourceElement(DragEventArgs e)
        {
            TreeListNode childNode = GetSourceNode(e);
            long childId = GetNodeId(childNode);
            LayoutTreeElement childElement = DataSource.Find(element => element.ID == childId);
            if (childElement == null)
            {
                throw new Exception(string.Format("Internal Error: cannot find element with ID {0} in the tree", childId));
            }
            return childElement;
        }

        private static TreeListNode GetSourceNode(DragEventArgs e)
        {
            return GetDragNode(e.Data);
        }

        private TreeListNode GetDestNode(DragEventArgs e)
        {
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(new Point(e.X, e.Y)));
            return hi.Node;
        }

        private bool IsLayoutNode(TreeListNode node)
        {
            Utils.CheckNotNull(node, "node");
            object oValue = node.GetValue(columnIsLayout.FieldName);

            return (!Utils.IsEmpty(oValue)) && (bool) oValue;
        }

        private bool IsReadOnlyNode(TreeListNode node)
        {
            Utils.CheckNotNull(node, "node");
            object oValue = node.GetValue(columnReadOnly.FieldName);
            return (!Utils.IsEmpty(oValue)) && (bool) oValue;
        }

        private long GetNodeId(TreeListNode node)
        {
            Utils.CheckNotNull(node, "node");
            object oValue = node.GetValue(columnID.FieldName);
            return (oValue == null) ? -1 : (long) oValue;
        }

        private string GetNodeDefaultName(TreeListNode node)
        {
            Utils.CheckNotNull(node, "node");
            object oValue = node.GetValue(columnName.FieldName);
            return (string) oValue;
        }

        private string GetNodeNationalName(TreeListNode node)
        {
            Utils.CheckNotNull(node, "node");
            object oValue = node.GetValue(columnNationalName.FieldName);
            return (string) oValue;
        }

        private static TreeListNode GetDragNode(IDataObject data)
        {
            Utils.CheckNotNull(data, "data");
            return data.GetData(typeof (TreeListNode)) as TreeListNode;
        }

        private TreeListNode GetNode(long id, TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                if (GetNodeId(node) == id)
                {
                    return node;
                }

                TreeListNode foundNode = GetNode(id, node.Nodes);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }
            return null;
        }

        private void AppendPath(TreeListNode node, StringBuilder path)
        {
            if (node == null)
            {
                return;
            }

            path.Insert(0, string.Format("\\ {0} ", GetNodeNationalName(node)));
            AppendPath(node.ParentNode, path);
        }

        private bool IsFolderDepthTooBig()
        {
            int count = GetParentDepth(GetNode(SelectedFolderId, tree.Nodes));
            return ShowMessageIfFolderDepthTooBig(count);
        }

        private bool IsFolderDepthTooBig(TreeListNode parentNode, TreeListNode childNode)
        {
            int count = GetParentDepth(parentNode) + GetChildDepth(childNode);
            return ShowMessageIfFolderDepthTooBig(count);
        }

        private static bool ShowMessageIfFolderDepthTooBig(int count)
        {
            int maxDepth = Math.Min(Config.GetIntSetting("MaxRamFolderDepth", 16), 30);
            bool isFolderDepthTooBig = count >= maxDepth;
            if (isFolderDepthTooBig)
            {
                MessageForm.Show(EidssMessages.Get("msgTooBigFolderDepth"));
            }
            return isFolderDepthTooBig;
        }

        private int GetParentDepth(TreeListNode node)
        {
            int count = 0;
            while (node != null)
            {
                if (!IsLayoutNode(node))
                {
                    count++;
                }

                node = node.ParentNode;
            }
            return count;
        }

        private static int GetChildDepth(TreeListNode node)
        {
            if ((node == null) || (node.Nodes.Count == 0))
            {
                return 0;
            }

            int depth = 0;
            foreach (TreeListNode child in node.Nodes)
            {
                int childDepth = GetChildDepth(child);
                if (childDepth > depth)
                {
                    depth = childDepth;
                }
            }
            return depth + 1;
        }

        #endregion
    }
}