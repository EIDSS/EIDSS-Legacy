using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using bv.common;
using bv.common.Core;
using bv.common.Enums;
using bv.common.Objects;
using bv.common.win;
using eidss.model.Enums;

namespace EIDSS
{
    public class FreezerTree : BaseDetailForm
    {
        private TreeView treeFreezer;
        private IContainer components = null;
        private ImageList SelectImageList;
        private bool isClickable = false;
        //public	string selected = "";
//		private bool expandflag = false;

        public FreezerTree()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            base.DbService = new FreezerTree_DB();
            AuditObject = new AuditObject((long) EIDSSAuditObject.daoRepositoryScheme, (long) AuditTable.tlbFreezer);
            PermissionObject = EIDSSPermissionObject.RepositoryScheme;
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public override object GetKey(string aTableName = null, string aKeyFieldName = null)
        {
            var ret = base.GetKey(aTableName, aKeyFieldName);

            TreeNode treeNode = treeFreezer.SelectedNode;
            if (treeNode != null)
            {
                var row = (treeNode.Tag as DataRow);
                if (row != null)
                {
                    return row["ID"];
                }
            }
            return ret;
        }

        #region Component Designer generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreezerTree));
            this.treeFreezer = new System.Windows.Forms.TreeView();
            this.SelectImageList = new System.Windows.Forms.ImageList();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(FreezerTree), out resources);
            // Form Is Localizable: True
            // 
            // treeFreezer
            // 
            resources.ApplyResources(this.treeFreezer, "treeFreezer");
            this.treeFreezer.ItemHeight = 16;
            this.treeFreezer.Name = "treeFreezer";
            this.treeFreezer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFreezer_AfterSelect);
            this.treeFreezer.DoubleClick += new System.EventHandler(this.treeFreezer_DoubleClick);
            // 
            // SelectImageList
            // 
            this.SelectImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SelectImageList.ImageStream")));
            this.SelectImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.SelectImageList.Images.SetKeyName(0, "");
            this.SelectImageList.Images.SetKeyName(1, "");
            this.SelectImageList.Images.SetKeyName(2, "");
            // 
            // FreezerTree
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.treeFreezer);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.FormID = "L28";
            this.HelpTopicID = "lab_l02";
            this.LeftIcon = ((System.Drawing.Image)(resources.GetObject("$this.LeftIcon")));
            this.Name = "FreezerTree";
            this.ShowDeleteButton = false;
            this.ShowSaveButton = false;
            this.Status = bv.common.win.FormStatus.Draft;
            this.Controls.SetChildIndex(this.treeFreezer, 0);
            this.ResumeLayout(false);

        }

        #endregion

        protected override void RefreshLayout()
        {
            DataTable treeTable;
//			DataView	dataView;
//			DataView	view;
//			DataRow		row;
//			string		filter;

            base.RefreshLayout();

            treeTable = baseDataSet.Tables["ContainerTree"];
            if (treeTable == null)
            {
                throw new ApplicationException("Invalid dataset.");
            }
            var view = new DataView(treeTable);
            FillNode(view, null);
            //this.FillTree(view, false, this.selected);
        }

        private string NodeText(string nodeName, string nodeBarcode, object used, object total)
        {
            string ret = nodeName;
            if (nodeBarcode.Length > 0)
            {
                ret += " - " + nodeBarcode;
            }
            if (!Utils.IsEmpty(total))
            {
                ret += " " + used + "/" + total;
            }
            return ret;
        }

        private void FillNode(DataView view, TreeNode parent)
        {
            string filter;
            if (parent == null)
            {
                filter = "idfParentSubdivision is null";
            }
            else
            {
                filter = "idfParentSubdivision=" + ((DataRow) (parent.Tag))["ID"];
            }
            view.RowFilter = filter;
            var list = new List<TreeNode>();
            foreach (DataRowView row in view)
            {
                var current =
                    new TreeNode(NodeText(row["Path"].ToString(), row["SubdivisionBarcode"].ToString(), row["intUsed"], row["intCapacity"]));
                current.SelectedImageIndex = current.ImageIndex = (parent == null ? 0 : 1);
                current.Tag = row.Row;
                if (parent == null)
                {
                    treeFreezer.Nodes.Add(current);
                }
                else
                {
                    parent.Nodes.Add(current);
                }
                if (row["ID"].ToString() == Utils.Str(DbService.ID))
                {
                    treeFreezer.SelectedNode = current;
                }
                list.Add(current);
            }
            foreach (TreeNode node in list)
            {
                FillNode(view, node);
            }
            if (parent != null)
            {
                parent.Expand();
            }
        }

        // copy-pasted from VialTransferDetail
        //
        /*
                private void FillTree(DataView treeTable, bool withContainers, string selectedID)
                {
                    TreeNode treeNode = null;
                    TreeNode parentNode = null;
                    TreeNode focusNode = null;
                    DataRow row = null;
			
                    this.treeFreezer.Nodes.Clear();

                    if(treeTable == null)
                    {
                        throw new ApplicationException("Invalid dataset");
                    }
		
        //			this.expandflag = true;
                    foreach (DataRowView rowView in treeTable)
                    {
                        parentNode = null;
                        row = rowView.Row;
                        // freezer
                        parentNode = this.FindNode(this.treeFreezer.Nodes, "idfFreezer", row["idfFreezer"].ToString());
                        if (parentNode == null){
                            treeNode = new TreeNode(NodeText(row["strFreezerName"].ToString(), row["FreezerBarcode"].ToString(), row["intUsed"], row["intCapacity"]));
                            treeNode.ImageIndex = 0;
                            treeNode.SelectedImageIndex = 0;

                            treeNode.Tag = row;
                            this.treeFreezer.Nodes.Add(treeNode);
                            parentNode = treeNode;
                        }
                        // ParentSubdivision
                        if (row.IsNull("idfParentsubDivision") == false) 
                        {
                            treeNode = this.FindNode(parentNode.Nodes, "idfSubdivision", row["idfParentsubDivision"].ToString());
                            if (treeNode == null)
                            {
                                treeNode = new TreeNode(NodeText(row["Subdivision_Name"].ToString(), row["Subdivision_Barcode"].ToString(),row["intUsed"],row["intCapacity"]));
                                treeNode.ImageIndex = 1;
                                treeNode.SelectedImageIndex = 1;
                                treeNode.Tag = row;
                                parentNode.Nodes.Add(treeNode);
                            }
                            parentNode = treeNode;
                        }
				            
                        // Subdivision
                        if (row.IsNull("idfSubdivision") == false)
                        {
                            treeNode = this.FindNode(parentNode.Nodes, "idfSubdivision", row["idfSubdivision"].ToString());
					
                            if (treeNode == null) 
                            {
                                treeNode = new TreeNode(NodeText(row["SubdivisionName"].ToString(), row["SubdivisionBarcode"].ToString(), row["intUsed"], row["intCapacity"]));
                                treeNode.ImageIndex = 1;
                                treeNode.SelectedImageIndex = 1;
                                treeNode.Tag = row;
                                parentNode.Nodes.Add(treeNode);

                                if ((selectedID.Length > 0) && (selectedID.ToLower(System.Globalization.CultureInfo.InvariantCulture).CompareTo(row["idfSubdivision"].ToString().ToLowerInvariant()) == 0))
                                {
                                    focusNode = treeNode;
                                }
                            }
                            parentNode = treeNode;
                        }

				            
                        // Container
                    }

                    if ((focusNode == null) && (this.treeFreezer.Nodes.Count > 0)) 
                    {
                        focusNode = this.treeFreezer.Nodes[0];

                        foreach (TreeNode trNode in this.treeFreezer.Nodes)
                        {
                            trNode.Expand();
                        }
                    }
                    if (focusNode != null)
                    {
                        focusNode.EnsureVisible();
                        this.treeFreezer.SelectedNode = focusNode;
                    }
                    // Switch off expand control
        //			this.expandflag = false;
                }


                // copy-pasted from VialTransferDetail
                //
                private TreeNode FindNode(TreeNodeCollection nodes, string field, string Id)
                {
                    DataRow row  = null;
                    TreeNode returnNode = null;

                    foreach(TreeNode node in nodes)
                    {
                        row = node.Tag as DataRow;
                        if (row != null)
                        {
                            if (row[field].ToString().ToLower(System.Globalization.CultureInfo.InvariantCulture).CompareTo(Id.ToLower(System.Globalization.CultureInfo.InvariantCulture)) == 0)
                            {
                                returnNode = node;
                                break;
                            }
                            if (node.Nodes.Count > 0)
                            {
                                returnNode = this.FindNode(node.Nodes, field, Id);
                                if (returnNode != null)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    return returnNode;
                }
        */

        public new DataRow GetCurrentRow(string aTableName)
        {
            TreeNode treeNode = treeFreezer.SelectedNode;
            if (treeNode == null)
            {
                return null;
            }
            return treeNode.Tag as DataRow;
        }

        public override DataRow[] GetSelectedRows()
        {
            TreeNode treeNode;
            DataRow dataRow;

            treeNode = treeFreezer.SelectedNode;
            if ((treeNode == null) && (treeNode.Tag as DataRow == null))
            {
                throw new ApplicationException("Ivalid item selected");
            }
            dataRow = treeNode.Tag as DataRow;
            return (new DataRow[] {dataRow});
        }

        private void treeFreezer_DoubleClick(object sender, EventArgs e)
        {
            if (isClickable)
            {
                if (BusinessObjectState.SelectObject > 0)
                {
                    if (Post())
                    {
                        DoOk();
                    }
                }
            }
        }

        public override bool Post(PostType postType = PostType.FinalPosting)
        {
            base.Post(postType);
            m_PromptResult = DialogResult.Yes;
            return true;
        }

        private void treeFreezer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetIsClickable((DataRow) e.Node.Tag);
            OkButton.Enabled = isClickable;
        }

        private void SetIsClickable(DataRow e)
        {
            DataRow row = e;
            object u = row["intUsed"];
            object t = row["intCapacity"];
            int used = Utils.IsEmpty(u) ? 0 : (int) u;
            int total = Utils.IsEmpty(t) ? 0 : (int) t;
            isClickable =
                //row["ID"].ToString()==Utils.Str(this.DbService.ID) || 
                (Utils.IsEmpty(row["idfSubdivision"]) == false && used < total);
        }
    }
}