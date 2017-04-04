using System;
using System.Text;
using bv.common.Core;
using DevExpress.XtraTreeList.Nodes;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;
using eidss.model.Avr.Tree;

namespace eidss.avr.QueryLayoutTree
{
    public static class TreeListNodeExtender
    {
        public const string DefaultColumnName = "DefaultName";
        public const string NationalColumnName = "NationalName";

        public const string ColumnIsLayoutName = "IsLayout";
        public const string ColumnReadOnlyName = "ReadOnly";
        public const string ColumnIDName = "ID";
        public const string ColumnParentIDName = "ParentID";
        public const string ColumnShareName = "blnShareLayout";
        public const string ColumnIsQueryName = "IsQuery";

        #region Node Tree methods

        public static AvrTreeSelectedElementEventArgs GetTreeElementEventArgs(this TreeListNode node)
        {
            if (node == null)
            {
                return new AvrTreeSelectedElementEventArgs();
            }
            TreeListNode queryNode = node.IsQueryNode() ? node : node.RootNode;
            if (!queryNode.IsQueryNode())
            {
                throw new AvrException(String.Format("Internal Error. Node {0} has no root query", node.GetNodeDefaultName()));
            }

            long queryId = queryNode.GetNodeId();
            long elementId = node.GetNodeId();
            long? parentId = node.ParentNode != null ? node.ParentNode.GetNodeId() : (long?)null;

            long folderId = -1;
            if (node.IsFolderNode())
            {
                folderId = node.GetNodeId();
            }
            else if (node.ParentNode != null && node.ParentNode.IsFolderNode())
            {
                folderId = node.ParentNode.GetNodeId();
            }

            AvrTreeElementType type = node.GetNodeType();

            return new AvrTreeSelectedElementEventArgs(queryId, elementId, parentId, folderId, type);
        }

        public static bool EditDisabled(this TreeListNode node)
        {
            return node == null || node.IsLayoutNode() || node.IsQueryNode() ||
                   node.IsReadOnlyNode();
        }

        #endregion

        #region Node Path

        public static string GetPath(this TreeListNode node)
        {
            if (node == null/* || node.ParentNode == null*/)
            {
                return String.Empty;
            }

            var path = new StringBuilder();
            AppendPath(node, path);
            return path.ToString();
        }

        private static void AppendPath(TreeListNode node, StringBuilder path)
        {
            if (node == null)
            {
                return;
            }

            path.Insert(0, String.Format(" {0} ", node.GetNodeNationalName()));
            if (node.ParentNode != null)
            {
                path.Insert(0, "\\");
            }

            AppendPath(node.ParentNode, path);
        }

        #endregion

        #region Node Depth

        public static int GetChildDepth(this TreeListNode node)
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

        public static int GetParentDepth(this TreeListNode node)
        {
            int count = 0;
            while (node != null)
            {
                if (!node.IsLayoutNode())
                {
                    count++;
                }

                node = node.ParentNode;
            }
            return count;
        }

        #endregion
   
        #region Node Attributes

        public static AvrTreeElementType GetNodeType(this TreeListNode node)
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

        public static long GetNodeId(this TreeListNode node)
        {
            Utils.CheckNotNull(node, "node");
            object oValue = node.GetValue(ColumnIDName);
            return (oValue == null) ? -1 : (long) oValue;
        }

        public static string GetNodeDefaultName(this TreeListNode node)
        {
            Utils.CheckNotNull(node, "node");
            object oValue = node.GetValue(DefaultColumnName);
            return (string) oValue;
        }

        public static string GetNodeNationalName(this TreeListNode node)
        {
            Utils.CheckNotNull(node, "node");
            object oValue = node.GetValue(NationalColumnName);
            return (string) oValue;
        }

        public static bool IsLayoutNode(this TreeListNode node)
        {
            return node.IsNodeHasFlagInColumn(ColumnIsLayoutName);
        }

        public static bool IsFolderNode(this TreeListNode node)
        {
            return !IsLayoutNode(node) && !IsQueryNode(node);
        }

        public static bool IsQueryNode(this TreeListNode node)
        {
            return node.IsNodeHasFlagInColumn(ColumnIsQueryName);
        }

        public static bool IsReadOnlyNode(this TreeListNode node)
        {
            return node.IsNodeHasFlagInColumn(ColumnReadOnlyName);
        }

        private static bool IsNodeHasFlagInColumn(this TreeListNode node, string columnId)
        {
            Utils.CheckNotNull(node, "node");
            object oValue = node.GetValue(columnId);
            return (!Utils.IsEmpty(oValue)) && (bool) oValue;
        }

        #endregion
    }
}