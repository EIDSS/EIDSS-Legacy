using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.Resources;
using bv.winclient.Core;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace EIDSS.Reports.BaseControls.Filters
{
    public partial class GroupsMultiFilter : BaseFilter
    {
        /// <summary>
        ///     Fires immediately after lookup edit value has been changed
        /// </summary>
        public event EventHandler<MultiFilterEventArgs> ValueChanged;

        private bool m_Checking;
        private readonly IDictionary<long, string> m_CheckedItems = new Dictionary<long, string>();

        public GroupsMultiFilter()
        {
            InitializeComponent();
        }

        protected virtual string ParentColumnName
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return string.Empty;
                }
                throw new InvalidOperationException("Property  should be overrided in child class.");
            }
        }

        protected virtual string SecondColumnName
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return string.Empty;
                }
                throw new InvalidOperationException("Property  should be overrided in child class.");
            }
        }

        protected virtual string SecondColumnCaption
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return string.Empty;
                }
                throw new InvalidOperationException("Property  should be overrided in child class.");
            }
        }

        protected virtual string CheckedComboBoxName
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return string.Empty;
                }
                throw new InvalidOperationException("Property  should be overrided in child class.");
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool ShowCheckBoxes
        {
            get { return treeList.OptionsView.ShowCheckBoxes; }
            set { treeList.OptionsView.ShowCheckBoxes = value; }
        }

        /// <summary>
        ///     Bind Datasouce to the Lookup Control and Customize Filter
        /// </summary>
        public override void DefineBinding()
        {
            ResetDataSource();

            treeList.DataSource = DataSource;

            treeList.KeyFieldName = KeyColumnName;
            treeList.ParentFieldName = ParentColumnName;
            for (int i = 0; i < treeList.Columns.Count; i++)
            {
                if (treeList.Columns[i].FieldName == ValueColumnName)
                {
                    treeList.Columns[i].Caption = CheckedComboBoxName;
                }
                else if (treeList.Columns[i].FieldName == SecondColumnName)
                {
                    treeList.Columns[i].Caption = SecondColumnCaption;
                }
                else
                {
                    treeList.Columns[i].Visible = false;
                }
            }
            //  treeList.OptionsView.ShowCheckBoxes = false;
            treeList.ExpandAll();

            treeListLookUp.Properties.PopupFormWidth = treeListLookUp.Width;
            
            treeList.NodesIterator.DoOperation(node =>
            {
                var idItem = (long)node.GetValue(KeyColumnName);
                if (m_CheckedItems.ContainsKey(idItem))
                {
                    m_CheckedItems[idItem] = node.GetDisplayText("name");
                    node.Checked = true;
                }
            });
            treeListLookUp.Text = GetDisplayText();
            ApplyResources();
        }
      

        protected override void ApplyResources()
        {
            base.ApplyResources();
            lblcheckedComboBoxName.Text = CheckedComboBoxName;
        }

      

        private void SetParentNodeState(TreeListNode node)
        {
            if (node.ParentNode != null)
            {
                if (node.ParentNode.Nodes.All(n => n.CheckState == CheckState.Checked))
                {
                    node.ParentNode.CheckState = CheckState.Checked;
                }
                else if (node.ParentNode.Nodes.All(n => n.CheckState == CheckState.Unchecked))
                {
                    node.ParentNode.CheckState = CheckState.Unchecked;
                }
                else
                {
                    node.ParentNode.CheckState = CheckState.Indeterminate;
                }
                SetParentNodeState(node.ParentNode);
            }
        }

        public string GetDisplayText()
        {
            return string.Join(", ", m_CheckedItems.Values.ToArray());
        }

        private void CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            e.DisplayText = GetDisplayText();
        }

        private void AfterCheckNode(object sender, NodeEventArgs e)
        {
            if (m_Checking || !ShowCheckBoxes)
            {
                return;
            }
            try
            {
                m_Checking = true;
                if (e.Node.Checked)
                {
                    e.Node.CheckAll();
                }
                else
                {
                    e.Node.UncheckAll();
                }
                SetParentNodeState(e.Node);
                var checkedNodes = treeList.GetAllCheckedNodes();
                m_CheckedItems.Clear();
                foreach (var node in checkedNodes)
                {
                    var idGroup = node.GetValue("blnGroup");
                    if (idGroup != DBNull.Value && !(bool) idGroup)
                    {
                        var idItem = (long) node.GetValue(KeyColumnName);
                        string name = node.GetDisplayText("name");

                        m_CheckedItems.Add(idItem, name);
                    }
                }
                treeListLookUp.Text = GetDisplayText();
                var args = new MultiFilterEventArgs(m_CheckedItems);
                ValueChanged.SafeRaise(sender, args);
            }
            finally
            {
                m_Checking = false;
            }
        }

        private void FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (ShowCheckBoxes || e.Node == null)
            {
                return;
            }

            var idItem = (long) e.Node.GetValue(KeyColumnName);
            string name = e.Node.GetDisplayText("name");
            treeListLookUp.Text = name;
            m_CheckedItems.Clear();
            if (idItem > 0)
            {
                m_CheckedItems.Add(idItem, name);
            }
            var args = new MultiFilterEventArgs(m_CheckedItems);
            ValueChanged.SafeRaise(sender, args);
        }
    }
}