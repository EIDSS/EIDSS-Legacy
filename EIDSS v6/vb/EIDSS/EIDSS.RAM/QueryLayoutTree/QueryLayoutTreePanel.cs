using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.Core;
using DevExpress.Utils;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.ViewInfo;
using eidss.avr.BaseComponents;
using eidss.avr.BaseComponents.Views;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;
using eidss.model.Avr;
using eidss.model.Avr.Tree;
using eidss.model.Core;
using eidss.model.Reports.OperationContext;
using eidss.model.Resources;

namespace eidss.avr.QueryLayoutTree
{
    public sealed partial class QueryLayoutTreePanel : BaseAvrDetailPresenterPanel, IQueryLayoutTreeView
    {
        private const int ImageIndexFolderCollapsed = 0;
        private const int ImageIndexFolderExpanded = 1;
        private const int ImageIndexQueryCollapsed = 2;
        private const int ImageIndexQueryExpanded = 3;
        private const int ImageIndexLayout = 4;

        private readonly string m_MessageFolderExists;
        private readonly string m_DefaultFolderName;
        private readonly string m_NationalFolderName;

        public event EventHandler<AvrTreeSelectedElementEventArgs> OnElementSelect;
        public event EventHandler<AvrTreeSelectedElementEventArgs> OnElementEdit;
        public event EventHandler<AvrTreeSelectedElementEventArgs> OnElementPopup;

        private string m_OldDefaultName;
        private string m_OldNationalName;

        private List<AvrTreeElement> m_DataSource;

        private bool m_ReadOnly;

        public QueryLayoutTreePanel()
        {
            InitializeComponent();

            if (WinUtils.IsComponentInDesignMode(this))
            {
                return;
            }

            TreePresenter = (QueryLayoutTreePresenter) BaseAvrPresenter;

            m_DefaultFolderName = EidssMessages.Get("msgDefaultFolderName", "New folder", Localizer.lngEn);
            m_NationalFolderName = EidssMessages.Get("msgDefaultFolderName", "New folder");
            m_MessageFolderExists = EidssMessages.Get("msgFolderExists",
                "Cannot rename {0}: A folder with the name you specified already exists. Specify a different folder name.");
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (toolTipController != null)
                {
                    toolTipController.GetActiveObjectInfo -= toolTipController_GetActiveObjectInfo;
                    toolTipController.Dispose();
                    toolTipController = null;
                }

                if (TreePresenter != null)
                {
                    if (TreePresenter.SharedPresenter != null)
                    {
                        TreePresenter.SharedPresenter.UnregisterView(this);
                    }
                    TreePresenter.Dispose();
                    TreePresenter = null;
                }
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        protected override void DefineBinding()
        {
            if (!BaseSettings.ScanFormsMode)
            {
                using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.DefineBinding))
                {
                    EidssUserContext.CheckUserLoggedIn();
                    DataSource = TreePresenter.LoadData();
                }
            }
        }

        #region Properties

        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool ReadOnly
        {
            get { return m_ReadOnly; }
            set
            {
                m_ReadOnly = value;
                tree.AllowDrop = !value;
            }
        }

        private QueryLayoutTreePresenter TreePresenter { get; set; }

        private List<AvrTreeElement> DataSource
        {
            get { return m_DataSource; }
            set
            {
                m_DataSource = value ?? new List<AvrTreeElement>();
                tree.Nodes.Clear();
                tree.DataSource = m_DataSource;
                tree.ExpandAll();
            }
        }

        /// <summary>
        ///     this field need for workaround because of DevExpress issue
        ///     http://www.devexpress.com/Support/Center/Question/Details/B136845
        /// </summary>
        //public bool WorkaroundIsFocusedNode { get; set; }
        public bool IsFocusedNodeReadOnly
        {
            get { return tree.FocusedNode != null && IsReadOnlyNode(tree.FocusedNode); }
        }

        #endregion

        #region Query Layout update operations

        public void ReloadQueryLayoutFolder(long id, AvrTreeElementType type)
        {
            AvrTreeElement element = null;

            switch (type)
            {
                case AvrTreeElementType.Query:
                    element = AvrQueryLayoutTreeDbHelper.ReloadQuery(id);
                    break;
                case AvrTreeElementType.Layout:
                    element = AvrQueryLayoutTreeDbHelper.ReloadLayout(id);
                    break;
                case AvrTreeElementType.Folder:
                    element = AvrQueryLayoutTreeDbHelper.ReloadFolder(id);
                    break;
            }
            if (element != null)
            {
                UpdateNode(element);
                Refresh();
            }
        }

        private void UpdateNode(AvrTreeElement newElement)
        {
            if (DataSource != null)
            {
                AvrTreeElement currentElement = DataSource.SingleOrDefault(n => n.ID == newElement.ID);
                if (currentElement != null)
                {
                    currentElement.DefaultName = newElement.DefaultName;
                    currentElement.NationalName = newElement.NationalName;
                    currentElement.Description = newElement.Description;

                    if (newElement.ReadOnly)
                    {
                        SetAllParentsReadonly(currentElement);
                    }
                    else
                    {
                        ClearAllChildrenReadonly(currentElement);
                    }
                }
                else
                {
                    DataSource.Add(newElement);
                }
                tree.RefreshDataSource();
                tree.BeginSort();
                tree.Columns[0].SortIndex = 0;
                tree.Columns[0].SortMode = ColumnSortMode.DisplayText;
                tree.Columns[0].SortOrder = SortOrder.Ascending;
                tree.EndSort();
            }
        }

        private void SetAllParentsReadonly(AvrTreeElement element)
        {
            while (element != null)
            {
                element.ReadOnly = true;
                element = DataSource.SingleOrDefault(c => c.ID == element.ParentID);
            }
        }

        private void ClearAllChildrenReadonly(AvrTreeElement element)
        {
            element.ReadOnly = false;
            List<AvrTreeElement> elements = DataSource.Where(c => c.ParentID == element.ID).ToList();
            foreach (AvrTreeElement child in elements)
            {
                ClearAllChildrenReadonly(child);
            }
        }

        #endregion

        #region Folder operations

        public void EditFolder(AvrTreeSelectedElementEventArgs e, bool isNewObject = false)
        {
            if (TreePresenter == null)
            {
                throw new AvrException(@"QuaryLayoutTreePresenter is not initialized for LayoutTreeListKeeper");
            }

            if (!e.ElementId.HasValue)
            {
                return;
            }
            TreeListNode node = GetNode(e.ElementId.Value, tree.Nodes);

            if (node == null || ReadOnly || !AvrPermissions.InsertPermission || IsFolderDepthTooBig())
            {
                return;
            }

            string englishName = isNewObject
                ? GetFolderNameWithPrefix(false)
                : GetNodeDefaultName(node);
            string nationalName = isNewObject
                ? GetFolderNameWithPrefix(true)
                : GetNodeNationalName(node);

            using (var form = new RenameFolderDialog(englishName, nationalName))
            {
                if (form.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    englishName = form.EnglishName;
                    nationalName = form.NationalName;

                    if (isNewObject)
                    {
                        TreeListNode queryNode = IsQueryNode(node) ? node : node.RootNode;
                        long queryId = GetNodeId(queryNode);
                        TreeListNode parentNode = IsLayoutNode(node) ? node.ParentNode : node;
                        long parentId = GetNodeId(parentNode);
                        long? folderId = IsFolderNode(parentNode) ? parentId : (long?) null;

                        long nodeId = TreePresenter.NewId();
                        var newElement = new AvrTreeElement(nodeId, parentId, null, AvrTreeElementType.Folder, queryId,
                            englishName, nationalName, string.Empty, false);

                        DataSource.Add(newElement);

                        tree.RefreshDataSource();

                        TreeListNode folder = GetNode(nodeId, tree.Nodes);
                        tree.FocusedNode = folder;

                        TreePresenter.SaveFolder(nodeId, folderId, queryId, newElement.DefaultName, newElement.NationalName);
                    }
                    else
                    {
                        long queryId = GetNodeId(node.RootNode);
                        long parentId = GetNodeId(node.ParentNode);
                        long? folderId = IsFolderNode(node.ParentNode) ? parentId : (long?) null;
                        long nodeId = GetNodeId(node);

                        TreePresenter.SaveFolder(nodeId, folderId, queryId, englishName, nationalName);
                        ReloadQueryLayoutFolder(nodeId, AvrTreeElementType.Folder);
                    }
                }
            }
        }

        public void DeleteFolder()
        {
            TreeListNode focusedNode = tree.FocusedNode;
            if (!CanDeleteFolder(focusedNode))
            {
                return;
            }
            string baseMsg = EidssMessages.Get("msgConfirmDeleteFolder",
                "Are you sure you want to delete the folder '{0}' and all its contents?");
            string msgDelete = string.Format(baseMsg, GetNodeNationalName(focusedNode));
            if (MessageForm.Show(msgDelete, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // todo:[Ivan] (Old) check that therer are no hidden layout (belong to other users) here
                TreePresenter.DeleteFolder(GetNodeId(focusedNode));
                TreeListNode parentNode = focusedNode.ParentNode;

                DeleteFocusedNode();

                tree.FocusedNode = parentNode;
            }
        }

        private bool CanDeleteFolder(TreeListNode node)
        {
            if (DisableEditNode(node) || (!AvrPermissions.DeletePermission) || ReadOnly || !IsFolderNode(node))
            {
                return false;
            }

            return node.Nodes.All(CanDeleteFolder);
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
            TreeListNode node = e.Node;
            if (!IsFolderNode(node))
            {
                throw new AvrException("Could not change Node that is not a folder");
            }

            foreach (AvrTreeElement element in DataSource)
            {
                if ((e.Column == columnName) &&
                    (element.DefaultName.ToLowerInvariant() == Utils.Str(e.Value).ToLowerInvariant()) &&
                    (GetNodeId(node) != element.ID))
                {
                    MessageForm.Show(string.Format(m_MessageFolderExists, Utils.Str(e.Value)));
                    node.SetValue(columnName.FieldName, m_OldDefaultName);
                    return;
                }
                if ((e.Column == columnNationalName) &&
                    (element.NationalName.ToLowerInvariant() == Utils.Str(e.Value).ToLowerInvariant()) &&
                    (GetNodeId(node) != element.ID))
                {
                    MessageForm.Show(string.Format(m_MessageFolderExists, Utils.Str(e.Value)));
                    node.SetValue(columnNationalName.FieldName, m_OldNationalName);
                    return;
                }
            }

            long? parentFolderId = IsFolderNode(node.ParentNode)
                ? GetNodeId(node.ParentNode)
                : (long?) null;
            string defaultName = Utils.Str(node.GetValue(columnName.FieldName));
            string nationalName = (ModelUserContext.CurrentLanguage == Localizer.lngEn)
                ? defaultName
                : Utils.Str(node.GetValue(columnNationalName.FieldName));
            TreePresenter.SaveFolder(GetNodeId(node), parentFolderId, GetNodeId(node.RootNode), defaultName, nationalName);
        }

        private void tree_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !IsFolderNode(tree.FocusedNode))
            {
                OnElementEdit.SafeRaise(this, GetTreeElementEventArgs(tree.FocusedNode));
            }
        }

        private void tree_DoubleClick(object sender, EventArgs e)
        {
            if ((e is MouseEventArgs) && ((MouseEventArgs) e).Button == MouseButtons.Left)
            {
                OnElementEdit.SafeRaise(this, GetTreeElementEventArgs(tree.FocusedNode));
                FocusedNodeReload();
            }
        }

        private void tree_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && tree.State == TreeListState.Regular)
            {
                Point pt = tree.PointToClient(MousePosition);
                TreeListHitInfo info = tree.CalcHitInfo(pt);
                if (info != null && info.HitInfoType == HitInfoType.Cell)
                {
                    tree.FocusedNode = info.Node;
                    OnElementPopup.SafeRaise(this, GetTreeElementEventArgs(info.Node));
                }
            }
        }

        #endregion

        #region Appearence

        public void DeleteFocusedNode()
        {
            tree.DeleteNode(tree.FocusedNode);
            tree.RefreshDataSource();
        }

        public void DeleteNodeWithId(long id)
        {
            TreeListNode node = GetNode(id, tree.Nodes);
            if (node != null)
            {
                tree.DeleteNode(node);
                tree.RefreshDataSource();
            }
        }

        public AvrTreeSelectedElementEventArgs GetTreeSelectedElementEventArgs()
        {
            return GetTreeElementEventArgs(tree.FocusedNode);
        }

        public AvrTreeSelectedElementEventArgs GetTreeElementEventArgs(TreeListNode node)
        {
            if (node == null)
            {
                return new AvrTreeSelectedElementEventArgs();
            }
            TreeListNode queryNode = IsQueryNode(node) ? node : node.RootNode;
            if (!IsQueryNode(queryNode))
            {
                throw new AvrException(string.Format("Internal Error. Node {0} has no root query", GetNodeDefaultName(node)));
            }

            long queryId = GetNodeId(queryNode);
            long elementId = GetNodeId(node);
            long? parentId = node.ParentNode != null ? GetNodeId(node.ParentNode) : (long?) null;

            long folderId = -1;
            if (IsFolderNode(node))
            {
                folderId = GetNodeId(node);
            }
            else if (node.ParentNode != null && IsFolderNode(node.ParentNode))
            {
                folderId = GetNodeId(node.ParentNode);
            }

            AvrTreeElementType type = GetNodeType(node);

            return new AvrTreeSelectedElementEventArgs(queryId, elementId, parentId, folderId, type, GetPath(node));
        }

        public void FocusedNodeReload()
        {
            tree_FocusedNodeChanged(this, new FocusedNodeChangedEventArgs(tree.FocusedNode, tree.FocusedNode));
        }

        private void tree_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            OnElementSelect.SafeRaise(this, GetTreeElementEventArgs(e.Node));
        }

        private void tree_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            if (IsLayoutNode(e.Node))
            {
                e.NodeImageIndex = ImageIndexLayout;
            }
            else if (IsQueryNode(e.Node))
            {
                e.NodeImageIndex = e.Node.Expanded ? ImageIndexQueryExpanded : ImageIndexQueryCollapsed;
            }
            else
            {
                e.NodeImageIndex = e.Node.Expanded ? ImageIndexFolderExpanded : ImageIndexFolderCollapsed;
            }
        }

        private void tree_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            bool readOnly = IsReadOnlyNode(e.Node);
            if (readOnly && e.Appearance.Font.Style != FontStyle.Bold)
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
            if (!readOnly && e.Appearance.Font.Style != FontStyle.Regular)
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Regular);
            }
        }

        private void toolTipController_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl is TreeList)
            {
                //  TreeList tree = (TreeList)e.SelectedControl;

                TreeListHitInfo hit = tree.CalcHitInfo(e.ControlMousePosition);
                if (hit != null && hit.Node != null)
                {
                    AvrTreeElement element = DataSource.SingleOrDefault(n => n.ID == GetNodeId(hit.Node));
                    if (element != null)
                    {
                        object cellInfo = new TreeListCellToolTipInfo(hit.Node, hit.Column, null);
                        string toolTip = element.Description;
                        e.Info = new ToolTipControlInfo(cellInfo, toolTip);
                    }
                }
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

            TreeListNode sourceNode = GetSourceNode(e);
            AvrTreeElement childElement = DataSource.Find(element => element.ID == GetNodeId(sourceNode));
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

            long? folderId = IsFolderNode(parentNode) ? parentId : null;
            if (IsLayoutNode(sourceNode))
            {
                TreePresenter.SaveLayoutLocation(childElement.ID, folderId);
            }
            else if (IsFolderNode(sourceNode))
            {
                TreePresenter.SaveFolder(childElement.ID, folderId, GetNodeId(sourceNode.RootNode),
                    childElement.DefaultName, childElement.NationalName);
            }
        }

        private void DragHandler(DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

            TreeListNode sourceNode = GetSourceNode(e);
            TreeListNode destNode = GetDestNode(e);

            if (ReadOnly ||
                IsReadOnlyNode(sourceNode) ||
                IsQueryNode(sourceNode) ||
                sourceNode == destNode ||
                destNode == null ||
                IsLayoutNode(destNode) ||
                sourceNode.RootNode != destNode.RootNode ||
                ContainsNodeInParentTree(destNode, sourceNode))
            {
                e.Effect = DragDropEffects.None;
            }
        }

        #endregion

        #region Helper methods

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

        private bool DisableEditNode(TreeListNode node)
        {
            return node == null || ReadOnly || IsLayoutNode(node) || IsQueryNode(node) || IsReadOnlyNode(node);
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
            return IsNodeHasFlagInColumn(node, columnIsLayout.FieldName);
        }

        private bool IsFolderNode(TreeListNode node)
        {
            return !IsLayoutNode(node) && !IsQueryNode(node);
        }

        private bool IsQueryNode(TreeListNode node)
        {
            return IsNodeHasFlagInColumn(node, columnIsQuery.FieldName);
        }

        private bool IsReadOnlyNode(TreeListNode node)
        {
            return IsNodeHasFlagInColumn(node, columnReadOnly.FieldName);
        }

        private bool IsNodeHasFlagInColumn(TreeListNode node, string columnId)
        {
            Utils.CheckNotNull(node, "node");
            object oValue = node.GetValue(columnId);
            return (!Utils.IsEmpty(oValue)) && (bool) oValue;
        }

        private long GetNodeId(TreeListNode node)
        {
            Utils.CheckNotNull(node, "node");
            object oValue = node.GetValue(columnID.FieldName);
            return (oValue == null) ? -1 : (long) oValue;
        }

        private AvrTreeElementType GetNodeType(TreeListNode node)
        {
            Utils.CheckNotNull(node, "node");
            if (IsQueryNode(node))
            {
                return AvrTreeElementType.Query;
            }
            if (IsLayoutNode(node))
            {
                return AvrTreeElementType.Layout;
            }
            return AvrTreeElementType.Folder;
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

        private string GetPath(TreeListNode node)
        {
            var path = new StringBuilder();
            AppendPath(node, path);
            return path.ToString();
        }

        private void AppendPath(TreeListNode node, StringBuilder path)
        {
            if (node == null)
            {
                return;
            }

            path.Insert(0, string.Format(" {0} ", GetNodeNationalName(node)));
            if (node.ParentNode != null)
            {
                path.Insert(0, "\\");
            }

            AppendPath(node.ParentNode, path);
        }

        private bool IsFolderDepthTooBig()
        {
            int count = GetParentDepth(tree.FocusedNode);
            if (IsLayoutNode(tree.FocusedNode))
            {
                count--;
            }
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
                MessageForm.Show(string.Format(EidssMessages.Get("msgTooBigFolderDepth"), count, maxDepth));
            }
            return isFolderDepthTooBig;
        }

        private bool ContainsNodeInParentTree(TreeListNode destNode, TreeListNode searchingNode)
        {
            TreeListNode parentNode = destNode;
            while (parentNode != null)
            {
                if (parentNode == searchingNode)
                {
                    return true;
                }

                parentNode = parentNode.ParentNode;
            }
            return false;
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