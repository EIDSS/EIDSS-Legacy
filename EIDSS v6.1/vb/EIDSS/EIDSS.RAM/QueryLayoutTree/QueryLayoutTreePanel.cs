using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.Core;
using DevExpress.Utils;
using DevExpress.XtraGrid;
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

            AvrQueryLayoutTreeDbHelper.InitWarnings();

            columnAuthor.Visible = AvrPermissions.AccessToAVRAdministrationPermission;

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
            get { return tree.FocusedNode != null && tree.FocusedNode.IsReadOnlyNode(); }
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
                : node.GetNodeDefaultName();
            string nationalName = isNewObject
                ? GetFolderNameWithPrefix(true)
                : node.GetNodeNationalName();

            using (var form = new RenameFolderDialog(englishName, nationalName, e, !isNewObject && node.IsReadOnlyNode(), isNewObject))
            {
                if (form.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    englishName = form.EnglishName;
                    nationalName = form.NationalName;

                    if (isNewObject)
                    {
                        TreeListNode queryNode = node.IsQueryNode() ? node : node.RootNode;
                        long queryId = queryNode.GetNodeId();
                        TreeListNode parentNode = node.IsLayoutNode() ? node.ParentNode : node;
                        long parentId = parentNode.GetNodeId();
                        long? folderId = parentNode.IsFolderNode() ? parentId : (long?) null;

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
                        long queryId = node.RootNode.GetNodeId();
                        long parentId = node.ParentNode.GetNodeId();
                        long? folderId = node.ParentNode.IsFolderNode() ? parentId : (long?) null;
                        long nodeId = node.GetNodeId();

                        TreePresenter.SaveFolder(nodeId, folderId, queryId, englishName, nationalName);
                        ReloadQueryLayoutFolder(nodeId, AvrTreeElementType.Folder);
                    }
                }
            }
        }


        #endregion

        #region click handlers

        private void tree_EditorKeyDown(object sender, KeyEventArgs e)
        {
            m_OldDefaultName = tree.FocusedNode.GetNodeDefaultName();
            m_OldNationalName = tree.FocusedNode.GetNodeNationalName();
        }

        private void tree_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            TreeListNode node = e.Node;
            if (!node.IsFolderNode())
            {
                throw new AvrException("Could not change Node that is not a folder");
            }

            foreach (AvrTreeElement element in DataSource)
            {
                if ((e.Column == columnName) &&
                    (element.DefaultName.ToLowerInvariant() == Utils.Str(e.Value).ToLowerInvariant()) &&
                    (node.GetNodeId() != element.ID))
                {
                    MessageForm.Show(string.Format(m_MessageFolderExists, Utils.Str(e.Value)));
                    node.SetValue(TreeListNodeExtender.DefaultColumnName, m_OldDefaultName);
                    return;
                }
                if ((e.Column == columnNationalName) &&
                    (element.NationalName.ToLowerInvariant() == Utils.Str(e.Value).ToLowerInvariant()) &&
                    (node.GetNodeId() != element.ID))
                {
                    MessageForm.Show(string.Format(m_MessageFolderExists, Utils.Str(e.Value)));
                    node.SetValue(TreeListNodeExtender.NationalColumnName, m_OldNationalName);
                    return;
                }
            }

            long? parentFolderId = node.ParentNode.IsFolderNode()
                ? node.ParentNode.GetNodeId()
                : (long?) null;
            string defaultName = Utils.Str(node.GetValue(TreeListNodeExtender.DefaultColumnName));
            string nationalName = (ModelUserContext.CurrentLanguage == Localizer.lngEn)
                ? defaultName
                : Utils.Str(node.GetValue(TreeListNodeExtender.NationalColumnName));
            TreePresenter.SaveFolder(node.GetNodeId(), parentFolderId, node.RootNode.GetNodeId(),
                defaultName, nationalName);
        }

        private void tree_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !tree.FocusedNode.IsFolderNode())
            {
                OnElementEdit.SafeRaise(this, tree.FocusedNode.GetTreeElementEventArgs());
            }
        }

        private void tree_DoubleClick(object sender, EventArgs e)
        {
            if ((e is MouseEventArgs) && ((MouseEventArgs) e).Button == MouseButtons.Left)
            {
                OnElementEdit.SafeRaise(this, tree.FocusedNode.GetTreeElementEventArgs());
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
                    OnElementPopup.SafeRaise(this, info.Node.GetTreeElementEventArgs());
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
            return tree.FocusedNode.GetTreeElementEventArgs();
        }

        public TreeListNode GetNodeByElementId(long elementId)
        {
            TreeListNode node = GetNode(elementId, tree.Nodes);
            return node;
        }

        public void SetTreeFocusedNodeByElementId(long elementId)
        {
            TreeListNode node = GetNode(elementId, tree.Nodes);
            tree.FocusedNode = node;
        }

        public void FocusedNodeReload()
        {
            tree_FocusedNodeChanged(this, new FocusedNodeChangedEventArgs(tree.FocusedNode, tree.FocusedNode));
        }

        private void tree_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            OnElementSelect.SafeRaise(this, e.Node.GetTreeElementEventArgs());
        }

        private void tree_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            if (e.Node.IsLayoutNode())
            {
                e.NodeImageIndex = ImageIndexLayout;
            }
            else if (e.Node.IsQueryNode())
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
            bool readOnly = e.Node.IsReadOnlyNode();
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
                    AvrTreeElement element = DataSource.SingleOrDefault(n => n.ID == hit.Node.GetNodeId());
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
            AvrTreeElement childElement = DataSource.Find(element => element.ID == sourceNode.GetNodeId());
            TreeListNode parentNode = GetDestNode(e);
            if (IsFolderDepthTooBig(parentNode, GetNode(childElement.ID, tree.Nodes)))
            {
                return;
            }

            long? parentId = (parentNode == null) ? null : (long?) parentNode.GetNodeId();
            childElement.ParentID = parentId;

            tree.RefreshDataSource();
            if (parentNode != null)
            {
                parentNode.ExpandAll();
            }
            e.Effect = DragDropEffects.None;

            long? folderId = parentNode.IsFolderNode() ? parentId : null;
            if (sourceNode.IsLayoutNode())
            {
                TreePresenter.SaveLayoutLocation(childElement.ID, folderId);
            }
            else if (sourceNode.IsFolderNode())
            {
                TreePresenter.SaveFolder(childElement.ID, folderId, sourceNode.RootNode.GetNodeId(),
                    childElement.DefaultName, childElement.NationalName);
            }
        }

        private void DragHandler(DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

            TreeListNode sourceNode = GetSourceNode(e);
            TreeListNode destNode = GetDestNode(e);

            if (ReadOnly ||
                sourceNode.IsReadOnlyNode() ||
                sourceNode.IsQueryNode() ||
                sourceNode == destNode ||
                destNode == null ||
                destNode.IsLayoutNode() ||
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
                        (element.ElementType == AvrTreeElementType.Folder) &&
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

        private static TreeListNode GetSourceNode(DragEventArgs e)
        {
            return GetDragNode(e.Data);
        }

        private TreeListNode GetDestNode(DragEventArgs e)
        {
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(new Point(e.X, e.Y)));
            return hi.Node;
        }

        private static TreeListNode GetDragNode(IDataObject data)
        {
            Utils.CheckNotNull(data, "data");
            return data.GetData(typeof (TreeListNode)) as TreeListNode;
        }

        private TreeListNode GetNode(long id, IEnumerable<TreeListNode> nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                if (node.GetNodeId() == id)
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

        private bool IsFolderDepthTooBig()
        {
            int count = tree.FocusedNode.GetParentDepth();
            if (tree.FocusedNode.IsLayoutNode())
            {
                count--;
            }
            return ShowMessageIfFolderDepthTooBig(count);
        }

        private bool IsFolderDepthTooBig(TreeListNode parentNode, TreeListNode childNode)
        {
            int count = parentNode.GetParentDepth() + childNode.GetChildDepth();
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

        #endregion
    }
}