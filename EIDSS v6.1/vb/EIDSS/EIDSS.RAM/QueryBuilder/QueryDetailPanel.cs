using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using bv.common;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;
using bv.common.Enums;
using bv.common.Objects;
using bv.common.win;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using EIDSS;
using eidss.avr.BaseComponents;
using eidss.avr.db.DBService.QueryBuilder;
using eidss.avr.db.Interfaces;
using EIDSS.Core;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Tree;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using BaseReferenceType = bv.common.db.BaseReferenceType;
using Localizer = bv.common.Core.Localizer;

namespace eidss.avr.QueryBuilder
{
    public sealed partial  class QueryDetailPanel : BaseAvrDetailPresenterPanel, IQueryDetailView
    {
        private QueryDetailPresenter m_QueryDetailPresenter;

        #region Init

        
        public ChildQueryObjectList m_ObjectList;
        private readonly Query_DB m_QueryDbService;
        private bool m_Modified;
        private readonly bool m_ReadOnlyMode;
        private bool m_IsNewOrCopy;

        public QueryDetailPanel()
        {
            LayoutCorrector.Reset();
            InitializeComponent();
            if (IsDesignMode() || bv.common.Configuration.BaseSettings.ScanFormsMode)
                return;
            m_QueryDbService = new Query_DB();
            DbService = m_QueryDbService;

            RegisterChildObject(qsoRoot, RelatedPostOrder.PostLast);
            m_ObjectList = new ChildQueryObjectList(
                qsoRoot.Parent, qsoRoot.Left, qsoRoot.Top, qsoRoot.Width, qsoRoot.Height, qsoRoot.TabIndex);
            AuditObject = new AuditObject((long) EIDSSAuditObject.daoReference, (long) AuditTable.tasQuery);

            LookupTableNames = new[] {"Query"};

            m_QueryDetailPresenter = (QueryDetailPresenter) SharedPresenter[this];

            if (WinUtils.IsComponentInDesignMode(this))
            {
                return;
            }
            UpdateGeneralQueryInfoView();
            RtlHelper.SetRTL(this);
            m_Modified = false;
        }

        public QueryDetailPanel(bool aReadOnlyMode) : this()
        {
            m_ReadOnlyMode = aReadOnlyMode;
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"> true if managed resources should be disposed; otherwise, false. </param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (m_QueryDetailPresenter != null)
                {
                    if (m_QueryDetailPresenter.SharedPresenter != null)
                    {
                        m_QueryDetailPresenter.SharedPresenter.UnregisterView(this);
                    }
                    m_QueryDetailPresenter.Dispose();
                    m_QueryDetailPresenter = null;
                }
                if (eventManager != null)
                {
                    eventManager.ClearAllReferences();
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

        #region  Command handlers

        public void ProcessQueryLayoutCommand(QueryLayoutCommand queryLayoutCommand)
        {
            queryLayoutCommand.State = CommandState.Pending;
            switch (queryLayoutCommand.Operation)
            {
                case QueryLayoutOperation.CopyQuery:
                    cmdCopy_Click(this, EventArgs.Empty);
                    break;
                case QueryLayoutOperation.Publish:
                    ProcessAfterPost(() => PublishUnpublishAfterPost(true));
                    break;
                case QueryLayoutOperation.Unpublish:
                    ProcessAfterPost(() => PublishUnpublishAfterPost(false));
                    break;
                default:

                    queryLayoutCommand.State = CommandState.Unprocessed;
                    break;
            }
            if (queryLayoutCommand.State == CommandState.Pending)
            {
                queryLayoutCommand.State = CommandState.Processed;
            }
        }

        private void PublishUnpublishAfterPost(bool isPublish)
        {
            if (UserConfirmPublishUnpublish(AvrTreeElementType.Query, isPublish))
            {
                object id = m_QueryDbService.ID;

                m_QueryDetailPresenter.QueryDbService.PublishUnpublish((long)id, isPublish);
                LoadData(ref id);
            }
        }
        #endregion

        private void UpdateGeneralQueryInfoView()
        {
            PermissionObject = EIDSSPermissionObject.AVRReport;
            cmdCopy.Enabled = AvrPermissions.InsertPermission;

            if (Utils.IsEmpty(lblQueryName.Text) == false)
            {
                int bracketInd = lblQueryName.Text.IndexOf("(", StringComparison.Ordinal);
                if (bracketInd >= 0)
                {
                    lblQueryName.Text = lblQueryName.Text.Substring(0, bracketInd).Trim();
                }
                lblQueryName.Text = lblQueryName.Text +
                                    @" (" + Localizer.GetLanguageName(ModelUserContext.CurrentLanguage) + @")";
            }

            const int step = 4;
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
            {
                int curTop = lblDefQueryName.Top + lblDefQueryName.Height + step;
                lblQueryName.Enabled = false;
                lblQueryName.Visible = false;
                SetMandatoryFieldVisible(txtQueryName, false);

                lblDescription.Top = curTop;
                memDescription.Top = curTop;
                memDescription.Height = grpGeneralInfo.GroupClientHeight - curTop - 2*step;
                chAddAllKeyFieldValues.Top = curTop;
            }
            else
            {
                int curTop = lblDefQueryName.Top + lblDefQueryName.Height + step;
                lblQueryName.Enabled = true;
                lblQueryName.Visible = true;
                lblQueryName.Top = curTop;
                SetMandatoryFieldVisible(txtQueryName, true);
                txtQueryName.Top = curTop;
                curTop = curTop + lblQueryName.Height + step;

                lblDescription.Top = curTop;
                memDescription.Top = curTop;
                memDescription.Height = grpGeneralInfo.GroupClientHeight - curTop - 2*step;
                chAddAllKeyFieldValues.Top = curTop;
            }
        }

        #endregion

        #region Keys

        public override object GetKey(string tableName = null, string keyFieldName = null)
        {
            return m_QueryDbService.ID;
        }

        public override object GetChildKey(IRelatedObject child)
        {
            if (child is QuerySearchObjectInfo)
            {
                var qsoInfo = child as QuerySearchObjectInfo;
                if (baseDataSet.Tables.Contains(Query_DB.TasQueryObjectTree) &&
                    (baseDataSet.Tables[Query_DB.TasQueryObjectTree].Rows.Count > 0))
                {
                    DataRow[] dr =
                        baseDataSet.Tables[Query_DB.TasQueryObjectTree].Select(
                            string.Format("idfsSearchObject = '{0}'", qsoInfo.SearchObject), "intOrder",
                            DataViewRowState.OriginalRows | DataViewRowState.Added);
                    if (dr.Length > 0)
                    {
                        return (dr[0].RowState != DataRowState.Added)
                            ? dr[0]["idfQuerySearchObject", DataRowVersion.Original]
                            : dr[0]["idfQuerySearchObject"];
                    }
                }
                return null;
            }
            return GetKey(Query_DB.TasQuery, "idflQuery");
        }

        #endregion

        #region Bindings

        private bool m_CopyDefaultQueryName;

        private void BindQueryInfo()
        {
            m_CopyDefaultQueryName = m_QueryDbService.IsNewObject;
            LookupBinder.BindTextEdit(txtDefQueryName, baseDataSet, Query_DB.TasQuery + ".DefQueryName");
            txtDefQueryName.Properties.Mask.MaskType = MaskType.RegEx;
            txtDefQueryName.Properties.Mask.EditMask = @"[a-zA-Z0-9~-+!-) \*\.,\-@\^_?/`=<>\|\\]*";
            txtDefQueryName.Properties.Mask.UseMaskAsDisplayFormat = true;

            LookupBinder.BindTextEdit(txtQueryName, baseDataSet, Query_DB.TasQuery + ".QueryName");

            LookupBinder.BindTextEdit(memDescription, baseDataSet, Query_DB.TasQuery + ".QueryDescription");
            memDescription.Properties.NullText = "";
            memDescription.Properties.MaxLength = 2000;

            chAddAllKeyFieldValues.DataBindings.Clear();
            chAddAllKeyFieldValues.DataBindings.Add("EditValue", baseDataSet, Query_DB.TasQuery + ".blnAddAllKeyFieldValues");
        }

        private void BindQueryObjectTree()
        {
            trlQuery.DataSource = new DataView(baseDataSet.Tables[Query_DB.TasQueryObjectTree]);
            trlQuery.KeyFieldName = "idfQuerySearchObject";
            trlQuery.ParentFieldName = "idfParentQuerySearchObject";

            LookupBinder.BindBaseRepositoryLookup(cbSearchObject,
                BaseReferenceType.rftSearchObject, false);
            foreach (EditorButton btn in cbSearchObject.Buttons)
            {
                btn.Visible = false;
            }

            trlQuery.ExpandAll();
            if (trlQuery.Nodes.Count > 0)
            {
                BeginUpdate();
                trlQuery.FocusedNode = trlQuery.Nodes[0];
                EndUpdate();
            }

            if (ReadOnly)
            {
                trlQuery.OptionsBehavior.Editable = false;
            }
        }

        /// <summary>
        ///     Check if the user has permission to the specified AVR search object
        /// </summary>
        /// <param name="searchObjectId">Id of the search object to check permissions</param>
        /// <returns>Returns boolean value. True if the user has permission to the object, otherwise - false.</returns>
        private bool HasUserPermissionToTheObject
            (
            object searchObjectId
            )
        {
            DataView dvSearchObjectToSystemFunction = LookupCache.Get(LookupTables.SearchObjectToSystemFunction);
            bool okToAddMenuItem = true;
            long soId;
            if ((searchObjectId == null) || (!(long.TryParse(Utils.Str(searchObjectId), out soId))))
            {
                return (false);
            }
            if (dvSearchObjectToSystemFunction != null)
            {
                dvSearchObjectToSystemFunction.RowFilter = string.Format("idfsSearchObject = {0}",
                    Utils.Str(searchObjectId));
                if (dvSearchObjectToSystemFunction.Count > 0)
                {
                    foreach (DataRowView drSearchObjectToSystemFunction in dvSearchObjectToSystemFunction)
                    {
                        EIDSSPermissionObject sf;
                        if (
                            !Enum.TryParse(
                                Utils.Str(drSearchObjectToSystemFunction["idfsSystemFunction"]), true,
                                out sf))
                        {
                            continue;
                        }
                        if ((EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(sf))))
                        {
                            continue;
                        }
                        okToAddMenuItem = false;
                        break;
                    }
                }
            }
            return (okToAddMenuItem);
        }

        private void InitQueryTypeMenu()
        {
            mnuQueryType.Items.Clear();
            using (DataView dv = LookupCache.Get(LookupTables.SearchObject))
            {
                foreach (DataRowView r in dv)
                {
                    if (!Utils.IsEmpty(r["blnPrimary"])
                        && ((bool) r["blnPrimary"]))
                    {
                        var it = new ToolStripMenuItem
                        {
                            Name = "so" + Utils.Str(r["idfsSearchObject"]),
                            Tag = r["idfsSearchObject"],
                            Text = Utils.Str(r["Name"])
                        };

                        if (HasUserPermissionToTheObject(r["idfsSearchObject"]))
                        {
                            mnuQueryType.Items.Add(it);
                        }
                    }
                }
            }
            UpdateQueryTypeMenu();
        }

        private void UpdateQueryTypeMenu()
        {
            for (int i = 0; i < mnuQueryType.Items.Count; i++)
            {
                mnuQueryType.Items[i].Enabled = true;
            }
            DataRow r = RootObjectRow;
            if (r != null)
            {
                ToolStripItem curRoot = mnuQueryType.Items["so" + Utils.Str(r["idfsSearchObject"])];
                if (curRoot != null)
                {
                    curRoot.Enabled = false;
                }
            }
            FillChildObjectMenu();
        }

        private void FillChildObjectMenu()
        {
            mnuChildObject.Items.Clear();
            DataRow rRoot = RootObjectRow;
            if ((rRoot == null) || Utils.IsEmpty(rRoot["idfsSearchObject"]))
            {
                return;
            }
            using (DataView dv = LookupCache.Get(LookupTables.SearchObjectRelation))
            {
                dv.RowFilter = string.Format("idfsParentSearchObject = '{0}' ", rRoot["idfsSearchObject"]);
                foreach (DataRowView r in dv)
                {
                    if (Utils.Str(r["idfsParentSearchObject"]) == Utils.Str(rRoot["idfsSearchObject"]))
                    {
                        var it = new ToolStripMenuItem
                        {
                            Name = "so" + Utils.Str(r["idfsChildSearchObject"]),
                            Tag = r["idfsChildSearchObject"],
                            Text = Utils.Str(r["ChildSearchObjectName"])
                        };

                        if (HasUserPermissionToTheObject(r["idfsChildSearchObject"]))
                        {
                            mnuChildObject.Items.Add(it);
                        }
                    }
                }
            }
            UpdateChildObjectMenu();
        }

        private void UpdateChildObjectMenu()
        {
            for (int i = 0; i < mnuChildObject.Items.Count; i++)
            {
                mnuChildObject.Items[i].Enabled = true;
            }
            btnAddChildObject.Enabled = true;

            if (baseDataSet.Tables.Contains(Query_DB.TasQueryObjectTree) &&
                (baseDataSet.Tables[Query_DB.TasQueryObjectTree].Rows.Count > 0))
            {
                DataRow[] dr = baseDataSet.Tables[Query_DB.TasQueryObjectTree].Select("idfParentQuerySearchObject is not null", "",
                    DataViewRowState.CurrentRows);
                foreach (DataRow r in dr)
                {
                    ToolStripItem curObj = mnuChildObject.Items["so" + Utils.Str(r["idfsSearchObject"])];
                    if (curObj != null)
                    {
                        curObj.Enabled = false;
                    }
                }
                btnAddChildObject.Enabled = CanAddSearchObject && (!ReadOnly);
            }
        }

        private void InitRootObject()
        {
            DataRow r = RootObjectRow;
            if (r != null)
            {
                long aSearchObject = QuerySearchObjectInfo.DefaultSearchObject;
                if ((!Utils.IsEmpty(r["idfsSearchObject"])) &&
                    (r["idfsSearchObject"] is long) && ((long) r["idfsSearchObject"] != -1L))
                {
                    aSearchObject = (long) r["idfsSearchObject"];
                }

                int aOrder = 0;
                if (Utils.IsEmpty(r["intOrder"]) == false)
                {
                    aOrder = (int) r["intOrder"];
                }
                qsoRoot.SearchObject = aSearchObject;
                qsoRoot.Order = aOrder;
            }
        }

        //  private bool m_Copying;

        private void InitChildObjectList()
        {
            // Commented because m_Copying is always false, this code never executing
//            if (m_Copying)
//            {
//                qsoRoot.Visible = false;
//                m_ObjectList.SetAllSearchObjectsInVisible();
//                qsoRoot.Visible = true;
//                btnRemoveChildObject.Enabled = (m_ObjectList.Count > 0) && (!ReadOnly);
//                return;
//            }

            m_ObjectList.Clear();
            qsoRoot.Visible = false;
            if (baseDataSet.Tables.Contains(Query_DB.TasQueryObjectTree) &&
                (baseDataSet.Tables[Query_DB.TasQueryObjectTree].Rows.Count > 0))
            {
                DataRow[] dr = baseDataSet.Tables[Query_DB.TasQueryObjectTree].Select("idfParentQuerySearchObject is not null", "intOrder",
                    DataViewRowState.CurrentRows);
                foreach (DataRow r in dr)
                {
                    var aSearchObject = (long) r["idfsSearchObject"];
                    int aOrder = 0;
                    if (Utils.IsEmpty(r["intOrder"]) == false)
                    {
                        aOrder = (int) r["intOrder"];
                    }
                    QuerySearchObjectInfo qsoInfo = m_ObjectList.Add(aSearchObject, aOrder);
                    RegisterChildObject(qsoInfo, RelatedPostOrder.PostLast);
                    //object id = r["idfQuerySearchObject"];
                    //qsoInfo.LoadData(ref id);

                    if (ReadOnly)
                    {
                        qsoInfo.ReadOnly = true;
                    }
                }
            }
            m_ObjectList.SetAllSearchObjectsInVisible();
            qsoRoot.Visible = true;
            btnRemoveChildObject.Enabled = (m_ObjectList.Count > 0) && (!ReadOnly);
        }

        private void RegisterObjectInfo()
        {
            if (baseDataSet.Tables.Contains(Query_DB.TasQueryObjectTree) &&
                (baseDataSet.Tables[Query_DB.TasQueryObjectTree].Rows.Count > 0))
            {
                DataRow[] dr = baseDataSet.Tables[Query_DB.TasQueryObjectTree].Select("idfParentQuerySearchObject is not null", "intOrder",
                    DataViewRowState.CurrentRows);
                foreach (DataRow r in dr)
                {
                    QuerySearchObjectInfo qsoInfo = m_ObjectList.Item((long) r["idfsSearchObject"]);
                    RegisterChildObject(qsoInfo, RelatedPostOrder.PostLast);
                }
            }
        }

        protected override void DefineBinding()
        {
            BindQueryInfo();
            BindQueryObjectTree();
            InitQueryTypeMenu();
            InitRootObject();
            InitChildObjectList();
        }

        public bool QueryPost(PostType postType = PostType.FinalPosting)
        {
            return m_QueryDetailPresenter.SharedPresenter.SharedModel.ParentForm.Post(postType);
        }

        /// <summary>
        /// Don't Call this method directly!!! It should be called when parent form performs post. Use QueryPost() instead.
        /// </summary>
        /// <param name="postType"></param>
        /// <returns></returns>
        public override bool Post(PostType postType = PostType.FinalPosting)
        {
            bool post = base.Post(postType);
            if (post)
            {
                m_IsNewOrCopy = false;
            }
            return post;
        }

        public override bool HasChanges()
        {
            return m_IsNewOrCopy || base.HasChanges();
        }

        private void QueryDetail_AfterLoadData(object sender, EventArgs e)
        {
            RegisterObjectInfo();
            if ((baseDataSet != null) && baseDataSet.Tables.Contains(Query_DB.TasQuery) &&
                (baseDataSet.Tables[Query_DB.TasQuery].Rows.Count > 0) &&
                (Utils.IsEmpty(baseDataSet.Tables[Query_DB.TasQuery].Rows[0]["idflQuery"]) == false) &&
                (baseDataSet.Tables[Query_DB.TasQuery].Rows[0]["blnReadOnly"] is bool) &&
                (bool) baseDataSet.Tables[Query_DB.TasQuery].Rows[0]["blnReadOnly"])
            {
                ReadOnly = true;
            }
            else if (ReadOnly != m_ReadOnlyMode)
            {
                ReadOnly = m_ReadOnlyMode;
            }
        }

        #endregion

        #region Properties

        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                value = value || m_ReadOnlyMode;
                base.ReadOnly = value;

                cmdNew.Enabled = AvrPermissions.InsertPermission;
                cmdDelete.Enabled = (!value) && AvrPermissions.DeletePermission;
                cmdSave.Enabled = (!value) && AvrPermissions.UpdatePermission;
                cmdCopy.Enabled = AvrPermissions.InsertPermission;
                cmdCancelChanges.Enabled = (!value);
                cmdClose.Enabled = true;

                qsoRoot.ReadOnly = value;
                btnRemoveChildObject.Enabled = false;
                if (m_ObjectList != null)
                {
                    for (int aOrder = 1; aOrder <= m_ObjectList.Count; aOrder++)
                    {
                        QuerySearchObjectInfo qsoInfo = m_ObjectList.Item(aOrder);
                        qsoInfo.ReadOnly = value;
                    }
                    btnRemoveChildObject.Enabled = (!value) && (m_ObjectList.Count > 0);
                }
                btnEditQueryType.Enabled = !value;
                btnAddChildObject.Enabled = (!value) && CanAddSearchObject;
            }
        }

        public bool Modified
        {
            get { return m_Modified; }
        }

        private bool CanAddSearchObject
        {
            get
            {
                int disabledCount = mnuChildObject.Items
                    .Cast<ToolStripItem>()
                    .Count(curObj => curObj.Enabled == false);

                return (disabledCount < mnuChildObject.Items.Count);
            }
        }

        private DataRow RootObjectRow
        {
            get
            {
                if (baseDataSet.Tables.Contains(Query_DB.TasQueryObjectTree) &&
                    (baseDataSet.Tables[Query_DB.TasQueryObjectTree].Rows.Count > 0))
                {
                    DataRow[] dr = baseDataSet.Tables[Query_DB.TasQueryObjectTree].Select("idfParentQuerySearchObject is null", "",
                        DataViewRowState.CurrentRows);
                    if (dr.Length > 0)
                    {
                        return dr[0];
                    }
                }
                return null;
            }
        }

        private long NewNegativeQuerySearchObjectID
        {
            get
            {
                if (baseDataSet.Tables.Contains(Query_DB.TasQueryObjectTree) == false)
                {
                    return -1;
                }

                long querySearchObjectID = -2;
                DataRow[] r = baseDataSet.Tables[Query_DB.TasQueryObjectTree].Select(
                    string.Format("idfQuerySearchObject <= {0}", querySearchObjectID), "idfQuerySearchObject");
                if (r.Length > 0)
                {
                    if (r[0].RowState != DataRowState.Deleted)
                    {
                        querySearchObjectID = (long) (r[0]["idfQuerySearchObject"]) - 1;
                    }
                    else
                    {
                        querySearchObjectID = (long) (r[0]["idfQuerySearchObject", DataRowVersion.Original]) - 1;
                    }
                }
                return querySearchObjectID;
            }
        }

        #endregion

        #region Handlers

        private void txtDefQueryName_EditValueChanged(object sender, EventArgs e)
        {
            if ((Loading == false) && m_CopyDefaultQueryName)
            {
                txtQueryName.Text = txtDefQueryName.Text;
            }
            RaiseRefreshCaption();
        }

        private void txtQueryName_EditValueChanged(object sender, EventArgs e)
        {
            if ((Loading == false) && (txtQueryName.Text != txtDefQueryName.Text))
            {
                m_CopyDefaultQueryName = false;
            }
            RaiseRefreshCaption();
        }

        private void btnEditQueryType_Click(object sender, EventArgs e)
        {
            if (mnuQueryType.Items.Count > 0)
            {
                mnuQueryType.Show(btnEditQueryType, new Point(0, btnEditQueryType.Height));
            }
        }

        private void mnuQueryType_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (qsoRoot.SearchObject != (long) e.ClickedItem.Tag)
            {
                if (baseDataSet.Tables.Contains(Query_DB.TasQueryObjectTree) &&
                    (baseDataSet.Tables[Query_DB.TasQueryObjectTree].Rows.Count > 0))
                {
                    for (int i = baseDataSet.Tables[Query_DB.TasQueryObjectTree].Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow r = baseDataSet.Tables[Query_DB.TasQueryObjectTree].Rows[i];
                        if (r.RowState != DataRowState.Deleted)
                        {
                            if (Utils.IsEmpty(r["idfParentQuerySearchObject"]) == false)
                            {
                                QuerySearchObjectInfo qsoInfo = m_ObjectList.Item((long) r["idfsSearchObject"]);
                                if (qsoInfo != null)
                                {
                                    UnRegisterChildObject(qsoInfo);
                                    m_ObjectList.Remove(qsoInfo);
                                }
                                r.Delete();
                            }
                            else
                            {
                                r["idfsSearchObject"] = (long) e.ClickedItem.Tag;
                                qsoRoot.SearchObject = (long) e.ClickedItem.Tag;
                            }
                        }
                    }
                }
            }
            mnuQueryType.Close();
            UpdateQueryTypeMenu();
            btnAddChildObject.Enabled = CanAddSearchObject && (!ReadOnly);
            btnRemoveChildObject.Enabled = (m_ObjectList.Count > 0) && (!ReadOnly);
        }

        private void btnAddChildObject_Click(object sender, EventArgs e)
        {
            if (trlQuery.Nodes.Count == 0)
            {
                return;
            }
            BeginUpdate();
            trlQuery.FocusedNode = trlQuery.Nodes[0];
            EndUpdate();

            if (mnuChildObject.Items.Count > 0)
            {
                mnuChildObject.Show(btnAddChildObject, new Point(0, btnAddChildObject.Height));
            }
        }

        private void mnuChildObject_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            AddChildObject((long) e.ClickedItem.Tag);
            mnuChildObject.Close();
            UpdateChildObjectMenu();
            btnAddChildObject.Enabled = CanAddSearchObject && (!ReadOnly);
            btnRemoveChildObject.Enabled = (m_ObjectList.Count > 0) && (!ReadOnly);
        }

        private void AddChildObject(long aSearchObject)
        {
            BeginUpdate();
            DataRow rRoot = RootObjectRow;
            if ((rRoot != null) && (Utils.IsEmpty(aSearchObject) == false))
            {
                object newObjID = NewNegativeQuerySearchObjectID;
                DataRow rChild = baseDataSet.Tables[Query_DB.TasQueryObjectTree].NewRow();
                rChild["idflQuery"] = m_QueryDbService.ID;
                rChild["idfParentQuerySearchObject"] = rRoot["idfQuerySearchObject"];
                rChild["idfsSearchObject"] = aSearchObject;
                rChild["idfQuerySearchObject"] = newObjID;
                baseDataSet.Tables[Query_DB.TasQueryObjectTree].Rows.Add(rChild);

                qsoRoot.Visible = false;
                QuerySearchObjectInfo qsoInfo = m_ObjectList.Add(aSearchObject);
                rChild["intOrder"] = qsoInfo.Order;
                RegisterChildObject(qsoInfo, RelatedPostOrder.PostLast);
                qsoInfo.LoadData(ref newObjID);

                TreeListNode node = trlQuery.FindNodeByKeyID(rChild["idfQuerySearchObject"]);
                if (node != null)
                {
                    node.ParentNode.ExpandAll();
                    trlQuery.FocusedNode = node;
                    trlQuery.FocusedColumn = trlQuery.Columns["idfsSearchObject"];
                    m_ObjectList.SetSearchObjectVisible(aSearchObject);
                }
                else
                {
                    m_ObjectList.SetAllSearchObjectsInVisible();
                    qsoRoot.Visible = true;
                }
            }
            EndUpdate();
        }

        private void UpdateChildOrder()
        {
            if ((baseDataSet == null) || (baseDataSet.Tables.Contains(Query_DB.TasQueryObjectTree) == false) ||
                (m_ObjectList == null))
            {
                return;
            }
            foreach (DataRow r in baseDataSet.Tables[Query_DB.TasQueryObjectTree].Rows)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    if (m_ObjectList.Contains((long) r["idfsSearchObject"]))
                    {
                        r["intOrder"] = m_ObjectList.Item((long) r["idfsSearchObject"]).Order;
                    }
                }
            }
        }

        private void btnRemoveChildObject_Click(object sender, EventArgs e)
        {
            if ((trlQuery.FocusedNode == null) || (trlQuery.FocusedNode.Level == 0))
            {
                return;
            }
            if (DeletePromptDialog() != DialogResult.Yes)
            {
                return;
            }
            BeginUpdate();
            QuerySearchObjectInfo qsoInfo = m_ObjectList.Item((long) trlQuery.FocusedNode.GetValue(trlQuery.Columns["idfsSearchObject"]));
            if (qsoInfo != null)
            {
                UnRegisterChildObject(qsoInfo);
                m_ObjectList.Remove(qsoInfo);
                UpdateChildOrder();
            }
            trlQuery.DeleteNode(trlQuery.FocusedNode);
            EndUpdate();
            UpdateChildObjectMenu();
            btnAddChildObject.Enabled = CanAddSearchObject && (!ReadOnly);
            btnRemoveChildObject.Enabled = (m_ObjectList.Count > 0) && (!ReadOnly);
        }

        private void trlQuery_AfterFocusNode(object sender, NodeEventArgs e)
        {
            if ((e.Node == null) || (e.Node.Level == 0))
            {
                m_ObjectList.SetAllSearchObjectsInVisible();
                qsoRoot.Visible = true;
            }
            else
            {
                var aSearchObject = (long) (trlQuery.FocusedNode.GetValue(trlQuery.Columns["idfsSearchObject"]));
                if (m_ObjectList.Contains(aSearchObject))
                {
                    qsoRoot.Visible = false;
                    m_ObjectList.SetSearchObjectVisible(aSearchObject);
                }
                else
                {
                    m_ObjectList.SetAllSearchObjectsInVisible();
                    qsoRoot.Visible = true;
                }
            }
        }

        private bool IsBlankQuery()
        {
            if ((baseDataSet == null) || (baseDataSet.Tables.Contains(Query_DB.TasQuery) == false)
                || (baseDataSet.Tables[Query_DB.TasQuery].Rows.Count == 0))
            {
                return true;
            }
            return Utils.IsEmpty(baseDataSet.Tables[Query_DB.TasQuery].Rows[0]["DefQueryName"]);
        }

        private bool m_ShowClearFormPrompt = true;

        private DataRow GetObjectRowBySearchObject(long aSearchObject)
        {
            if (baseDataSet.Tables.Contains(Query_DB.TasQueryObjectTree) == false)
            {
                return null;
            }
            DataRow[] dr =
                baseDataSet.Tables[Query_DB.TasQueryObjectTree].Select(string.Format("idfsSearchObject = {0}", aSearchObject));
            if (dr.Length == 0)
            {
                return null;
            }
            // Find row that could be edited
            DataRow r = baseDataSet.Tables[Query_DB.TasQueryObjectTree].Rows.Find(dr[0]["idfQuerySearchObject"]);
            return r;
        }

        private bool DefaultQueryNameExists(string defQueryName)
        {
            LookupTableInfo info = LookupCache.LookupTables[LookupTables.Query.ToString()];
            DataTable dtQuery = LookupCache.Fill(info);
            DataRow[] dr = dtQuery.Select(string.Format("DefQueryName = '{0}'", Utils.Str(defQueryName).Replace("'", "''")));
            if (dr.Length > 1)
            {
                return true;
            }
            if ((dr.Length == 1) && ((long) dr[0]["idflQuery"] != (long) m_QueryDbService.ID))
            {
                return true;
            }
            return false;
        }

        private bool QueryNameExists(string queryName)
        {
            LookupTableInfo info = LookupCache.LookupTables[LookupTables.Query.ToString()];
            DataTable dtQuery = LookupCache.Fill(info);
            DataRow[] dr = dtQuery.Select(string.Format("QueryName = '{0}'", Utils.Str(queryName).Replace("'", "''")));
            if (dr.Length > 1)
            {
                return true;
            }
            if ((dr.Length == 1) && ((long) dr[0]["idflQuery"] != (long) m_QueryDbService.ID))
            {
                return true;
            }
            return false;
        }

        private object GetCopyDefaultQueryName(object defQueryName)
        {
            if (Utils.IsEmpty(defQueryName))
            {
                return defQueryName;
            }

            string copyPrefix = EidssMessages.Get("msgCopyPrefix", "Copy{0} of", "en");
            int copyIndex = 0; //-1;
            string copyDefQueryName = string.Format("{0} {1}", string.Format(Utils.Str(copyPrefix).Trim(), ""), Utils.Str(defQueryName));
            //Utils.Str(defQueryName);

            bool isNameReady = false;
            while (isNameReady == false)
            {
                if (DefaultQueryNameExists(copyDefQueryName))
                {
                    copyIndex = copyIndex + 1;
                    if (copyIndex > 0)
                    {
                        copyDefQueryName = string.Format("{0} {1}",
                            string.Format(Utils.Str(copyPrefix).Trim(), string.Format(" ({0})", copyIndex)),
                            Utils.Str(defQueryName));
                    }
                    else
                    {
                        copyDefQueryName = string.Format("{0} {1}", string.Format(Utils.Str(copyPrefix).Trim(), ""), Utils.Str(defQueryName));
                    }
                }
                else
                {
                    isNameReady = true;
                }
            }
            return copyDefQueryName;
        }

        private object GetCopyQueryName(object queryName)
        {
            if (Utils.IsEmpty(queryName))
            {
                return queryName;
            }

            string copyPrefix = EidssMessages.Get("msgCopyPrefix", "Copy{0} of");
            int copyIndex = 0; //-1;
            string copyQueryName = string.Format("{0} {1}", string.Format(Utils.Str(copyPrefix).Trim(), ""), Utils.Str(queryName));
            //Utils.Str(queryName);

            bool isNameReady = false;
            while (isNameReady == false)
            {
                if (QueryNameExists(copyQueryName))
                {
                    copyIndex = copyIndex + 1;
                    if (copyIndex > 0)
                    {
                        copyQueryName = string.Format("{0} {1}",
                            string.Format(Utils.Str(copyPrefix).Trim(), string.Format(" ({0})", copyIndex)),
                            Utils.Str(queryName));
                    }
                    else
                    {
                        copyQueryName = string.Format("{0} {1}", string.Format(Utils.Str(copyPrefix).Trim(), ""), Utils.Str(queryName));
                    }
                }
                else
                {
                    isNameReady = true;
                }
            }
            return copyQueryName;
        }

        #endregion

        #region Validate Methods

        private DataTable m_SearchTable;

        private void InitSearchTable()
        {
            m_SearchTable = new DataTable("SearchTable");

            var colPk = new DataColumn("idfSearchTableForUnionTable", typeof (String));
            m_SearchTable.Columns.Add(colPk);

            var colID = new DataColumn("idfSearchTable", typeof (Int64));
            m_SearchTable.Columns.Add(colID);

            var colName = new DataColumn("strTableName", typeof (String));
            m_SearchTable.Columns.Add(colName);

            var colParentID = new DataColumn("idfParentSearchTable", typeof (Int64));
            m_SearchTable.Columns.Add(colParentID);

            var colUnionID = new DataColumn("idfUnionSearchTable", typeof (Int64));
            m_SearchTable.Columns.Add(colUnionID);

            var colCount = new DataColumn("intTableCount", typeof (Int32));
            m_SearchTable.Columns.Add(colCount);

            m_SearchTable.PrimaryKey = new[] {m_SearchTable.Columns["idfSearchTableForUnionTable"]};
        }

        private int GetQueryComplexity()
        {
            int complexity = 1;
            if (Utils.IsEmpty(qsoRoot.SearchObject))
            {
                return complexity;
            }

            // Union tables for query
            DataView dvMainTableForObject = LookupCache.Get(LookupTables.MainTableForObject);
            if ((dvMainTableForObject == null) || (dvMainTableForObject.Count == 0))
            {
                return complexity;
            }
            dvMainTableForObject.RowFilter = string.Format("idfsSearchObject = {0} ", qsoRoot.SearchObject);

            // Main table for root object in case root object is connected just to one main table
            object idfUniqueMainSearchTable = null;
            if (dvMainTableForObject.Count == 0)
            {
                return complexity;
            }
            if (dvMainTableForObject.Count == 1)
            {
                idfUniqueMainSearchTable = dvMainTableForObject[0]["idfMainSearchTable"];
                if (Utils.IsEmpty(idfUniqueMainSearchTable))
                {
                    return complexity;
                }
            }

            // Determine union tables for query
            foreach (IRelatedObject qsoTable in Children)
            {
                if (qsoTable is QuerySearchObjectInfo)
                {
                    var qsoMainTableInfo = qsoTable as QuerySearchObjectInfo;
                    if (Utils.IsEmpty(qsoMainTableInfo.SearchObject) == false)
                    {
                        dvMainTableForObject.RowFilter = string.Format("idfsSearchObject = {0} ", qsoMainTableInfo.SearchObject);
                        if (dvMainTableForObject.Count > 1)
                        {
                            break;
                        }
                    }
                }
            }

            //DataRow rRootObject = LookupCache.GetLookupRow(qsoRoot.SearchObject, LookupTables.SearchObject.ToString());
            //if ((rRootObject == null) || (Utils.IsEmpty(rRootObject["idfMainSearchTable"]))) { return complexity; }
            //long idfMainSearchTable = (long)(rRootObject["idfMainSearchTable"]);

            // Define new table with all search tables of the query with specified union table
            InitSearchTable();

            foreach (IRelatedObject qso in Children)
            {
                if (qso is QuerySearchObjectInfo)
                {
                    var qsoInfo = qso as QuerySearchObjectInfo;
                    DataView dvField = qsoInfo.GetQuerySearchFieldView();
                    if (dvField != null)
                    {
                        foreach (DataRowView r in dvField)
                        {
                            DataRow rFieldLookup = LookupCache.GetLookupRow(r["idfsSearchField"], LookupTables.SearchField.ToString());
                            if (rFieldLookup != null)
                            {
                                foreach (DataRowView rUnionTable in dvMainTableForObject)
                                {
                                    object unionSearchTableID = rUnionTable["idfUnionSearchTable"];
                                    object mainSearchTableID = idfUniqueMainSearchTable;
                                    if (Utils.IsEmpty(idfUniqueMainSearchTable))
                                    {
                                        mainSearchTableID = unionSearchTableID;
                                    }
                                    DataRow rFieldSource =
                                        LookupCache.GetLookupRow(
                                            string.Format("{0}__{1}", rFieldLookup["idfsSearchField"], unionSearchTableID),
                                            LookupTables.FieldSourceForTable.ToString());
                                    if (rFieldSource != null)
                                    {
                                        DataRow rLookup =
                                            LookupCache.GetLookupRow(
                                                string.Format("{0}__{1}__{2}", unionSearchTableID, mainSearchTableID,
                                                    rFieldSource["idfFieldSourceTable"]), LookupTables.SearchTable.ToString());

                                        if (rLookup != null)
                                        {
                                            object searchTableID = rLookup["idfSearchTable"];
                                            string searchTableForUnionTableID = string.Format("{0}__{1}", unionSearchTableID, searchTableID);
                                            if (m_SearchTable.Rows.Find(searchTableForUnionTableID) == null)
                                            {
                                                DataRow dr = m_SearchTable.NewRow();
                                                dr["idfSearchTableForUnionTable"] = searchTableForUnionTableID;
                                                dr["idfSearchTable"] = searchTableID;
                                                dr["idfUnionSearchTable"] = unionSearchTableID;
                                                dr["strTableName"] = rLookup["strTableName"];
                                                dr["idfParentSearchTable"] = rLookup["idfParentSearchTable"];
                                                if (qsoInfo.IsFFObject)
                                                {
                                                    dr["intTableCount"] = 0;
                                                }
                                                else
                                                {
                                                    if (rLookup["intTableCount"] is int)
                                                    {
                                                        dr["intTableCount"] = (int) rLookup["intTableCount"];
                                                    }
                                                    else
                                                    {
                                                        dr["intTableCount"] = 0;
                                                    }
                                                }
                                                m_SearchTable.Rows.Add(dr);
                                            }

                                            DataRow rCurTable = m_SearchTable.Rows.Find(searchTableForUnionTableID);
                                            if (rCurTable != null)
                                            {
                                                if (qsoInfo.IsFFObject)
                                                {
                                                    DataRow rFFField = LookupCache.GetLookupRow(r["FieldAlias"],
                                                        LookupTables.ParameterForFFType.ToString());
                                                    rCurTable["intTableCount"] = (int) rCurTable["intTableCount"] + 1;
                                                    if (Utils.IsEmpty(rFFField["idfsReferenceType"]) == false)
                                                    {
                                                        rCurTable["intTableCount"] = (int) rCurTable["intTableCount"] + 1;
                                                    }
                                                }
                                                else if ((Utils.IsEmpty(rFieldLookup["idfsReferenceType"]) == false) ||
                                                         (Utils.IsEmpty(rFieldLookup["idfsGISReferenceType"]) == false) ||
                                                         (Utils.Str(rFieldLookup["blnGeoLocationString"], "0") == "1")
                                                    )
                                                {
                                                    rCurTable["intTableCount"] = (int) rCurTable["intTableCount"] + 1;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            m_SearchTable.AcceptChanges();
            foreach (DataRowView rUnionTable in dvMainTableForObject)
            {
                object unionSearchTableID = rUnionTable["idfUnionSearchTable"];
                object mainSearchTableID = idfUniqueMainSearchTable;
                if (Utils.IsEmpty(idfUniqueMainSearchTable))
                {
                    mainSearchTableID = unionSearchTableID;
                }

                DataRow[] drNew =
                    m_SearchTable.Select(
                        string.Format("idfUnionSearchTable = {0} and idfParentSearchTable is not null ", unionSearchTableID),
                        "idfSearchTableForUnionTable", DataViewRowState.Added);
                while (drNew.Length > 0)
                {
                    DataRow rLookup =
                        LookupCache.GetLookupRow(
                            string.Format("{0}__{1}__{2}", unionSearchTableID, mainSearchTableID, drNew[0]["idfParentSearchTable"]),
                            LookupTables.SearchTable.ToString());
                    if (rLookup != null)
                    {
                        object searchTableID = rLookup["idfSearchTable"];
                        string searchTableForUnionTableID = string.Format("{0}__{1}", unionSearchTableID, searchTableID);
                        if (m_SearchTable.Rows.Find(searchTableID) == null)
                        {
                            DataRow dr = m_SearchTable.NewRow();
                            dr["idfSearchTableForUnionTable"] = searchTableForUnionTableID;
                            dr["idfSearchTable"] = searchTableID;
                            dr["idfUnionSearchTable"] = unionSearchTableID;
                            dr["strTableName"] = rLookup["strTableName"];
                            dr["idfParentSearchTable"] = rLookup["idfParentSearchTable"];
                            dr["intTableCount"] = rLookup["intTableCount"];
                            m_SearchTable.Rows.Add(dr);
                        }
                    }
                    DataRow rNew = m_SearchTable.Rows.Find(drNew[0]["idfSearchTableForUnionTable"]);
                    if (rNew != null)
                    {
                        rNew.AcceptChanges();
                    }
                }

                int curUnionPartComplexity = 1;
                foreach (DataRow rTable in m_SearchTable.Select(string.Format("idfUnionSearchTable = {0} ", unionSearchTableID)))
                {
                    if ((Utils.IsEmpty(rTable["intTableCount"]) == false) && (rTable["intTableCount"] is int))
                    {
                        curUnionPartComplexity = curUnionPartComplexity + (int) rTable["intTableCount"];
                    }
                }

                if (complexity < curUnionPartComplexity)
                {
                    complexity = curUnionPartComplexity;
                }
            }

            return complexity;
        }

        public override bool ValidateData()
        {
            if (base.ValidateData() == false)
            {
                return false;
            }
            if ((baseDataSet == null) || (baseDataSet.Tables.Contains(Query_DB.TasQuery) == false))
            {
                return true;
            }
            if (DefaultQueryNameExists(Utils.Str(baseDataSet.Tables[Query_DB.TasQuery].Rows[0]["DefQueryName"])))
            {
                MessageForm.Show(EidssMessages.Get("msgNoUniqueQueryName", "Query with that name already exists. Please modify it."));
                return false;
            }
            if ((ModelUserContext.CurrentLanguage != Localizer.lngEn) &&
                QueryNameExists(Utils.Str(baseDataSet.Tables[Query_DB.TasQuery].Rows[0]["DefQueryName"])))
            {
                MessageForm.Show(EidssMessages.Get("msgNoUniqueNatQueryName",
                    "Query with that national name already exists. Please modify it."));
                return false;
            }

            if (qsoRoot.ValidateQSOInfo() == false)
            {
                trlQuery.Select();
                trlQuery.FocusedNode = trlQuery.Nodes[0];
                qsoRoot.ShowQSOInfoError();
                return false;
            }

            for (int aOrder = 1; aOrder <= m_ObjectList.Count; aOrder++)
            {
                QuerySearchObjectInfo qsoInfo = m_ObjectList.Item(aOrder);
                if (qsoInfo.ValidateQSOInfo() == false)
                {
                    TreeListNode node = trlQuery.FindNodeByFieldValue("idfsSearchObject", qsoInfo.SearchObject);
                    if (node != null)
                    {
                        trlQuery.Select();
                        trlQuery.FocusedNode = node;
                        qsoInfo.ShowQSOInfoError();
                        return false;
                    }
                }
            }

            int queryComplexity = GetQueryComplexity();
            if (queryComplexity > 256)
            {
                MessageForm.Show(
                    string.Format(
                        EidssMessages.Get("msgQueryComplexity",
                            "Complexity of query is greater than allowed value. Please remove {0} flexible form fields or change query."),
                        EidssMessages.Get("msgSeveral", "several")));
                return false;
            }
            return true;
        }

        #endregion

        #region CreateFunction

        private void QueryDetail_OnAfterPost(object sender, EventArgs e)
        {
            m_QueryDbService.CreateFunction();
            m_Modified = true;
        }

        #endregion

        private void navBarControl1_GroupCollapsed(object sender, NavBarGroupEventArgs e)
        {
            int height = 0;
            foreach (NavBarGroup group in navBarControl1.Groups)
            {
                height += BaseAvrPresenter.NavBarGroupHeaderHeight;
                if (group.Expanded)
                {
                    height += group.ControlContainer.Height;
                }
            }
            navBarControl1.ClientSize = new Size(navBarControl1.ClientSize.Width, height);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            var baseForm = ParentObject as BaseForm;
            if (baseForm != null)
            {
                baseForm.SetClosingMode(ClosingMode.Cancel);
            }
            ProcessAfterPost(() =>
            {
                Hide();
                RaiseSendCommand(new QueryLayoutCloseCommand(sender));
            });
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            ProcessAfterPost(null);
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            ProcessAfterPost(() =>
            {
                State = BusinessObjectState.NewObject | BusinessObjectState.IntermediateObject;
                ReadOnly = false;
                object id = null;
                LoadData(ref id);
                m_IsNewOrCopy = true;
            });
        }

        private void ProcessAfterPost(Action handler)
        {
            if (LockHandler())
            {
                try
                {
                    if (QueryPost())
                    {
                        if (handler != null)
                        {
                            handler();
                        }
                    }
                    else
                    {
                        SelectLastFocusedControl();
                    }
                }
                finally
                {
                    UnlockHandler();
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            object key = GetKey();
            if (!(key is long))
            {
                throw new AvrException(string.Format("QueryDetail key {0} is not long", key));
            }

            RaiseSendCommand(new QueryLayoutDeleteCommand(sender, (long) key, AvrTreeElementType.Query));
        }

        private void cmdCancelChanges_Click(object sender, EventArgs e)
        {
            DataEventManager.Flush();
            if ((HasChanges() == false) && ((m_QueryDbService.IsNewObject == false) || IsBlankQuery()))
            {
                return;
            }
            string msg = EidssMessages.Get("msgConfirmCancelChangesForm",
                "Return the form to the last saved state?");
            if (m_QueryDbService.IsNewObject && m_ShowClearFormPrompt)
            {
                msg = EidssMessages.Get("msgConfirmClearForm", "Clear the form content?");
            }

            if (m_ShowClearFormPrompt && MessageForm.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                SelectLastFocusedControl();
                return;
            }
            if (m_ObjectList != null)
            {
                for (int i = Children.Count - 1; i >= 0; i--)
                {
                    IRelatedObject qso = Children[i];
                    if (qso is QuerySearchObjectInfo)
                    {
                        var qsoInfo = qso as QuerySearchObjectInfo;
                        if (m_ObjectList.Contains(qsoInfo))
                        {
                            UnRegisterChildObject(qsoInfo);
                        }
                    }
                }
                m_ObjectList.Clear();
            }
            if (m_QueryDbService.IsNewObject)
            {
                object id = null;
                LoadData(ref id);
            }
            else
            {
                object id = m_QueryDbService.ID;
                LoadData(ref id);
            }
            DefineBinding();
        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            if (QueryPost())
            {
              
                m_QueryDbService.Copy(baseDataSet, null);
                baseDataSet.Tables[Query_DB.TasQuery].Rows[0]["DefQueryName"] =
                    GetCopyDefaultQueryName(baseDataSet.Tables[Query_DB.TasQuery].Rows[0]["DefQueryName"]);
                if (ModelUserContext.CurrentLanguage != Localizer.lngEn)
                {
                    baseDataSet.Tables[Query_DB.TasQuery].Rows[0]["QueryName"] =
                        GetCopyQueryName(baseDataSet.Tables[Query_DB.TasQuery].Rows[0]["QueryName"]);
                }
                else
                {
                    baseDataSet.Tables[Query_DB.TasQuery].Rows[0]["QueryName"] =
                        baseDataSet.Tables[Query_DB.TasQuery].Rows[0]["DefQueryName"];
                }

                long qsoRootID = -1L;
                qsoRoot.Copy(qsoRootID, (long) m_QueryDbService.ID);
                DataRow rRoot = GetObjectRowBySearchObject(qsoRoot.SearchObject);
                if ((rRoot != null) && Utils.IsEmpty(rRoot["idfParentQuerySearchObject"]))
                {
                    rRoot["idfQuerySearchObject"] = qsoRootID;
                    rRoot["idflQuery"] = m_QueryDbService.ID;
                }
                qsoRoot.baseDataSet.AcceptChanges();

                for (int aOrder = 1; aOrder <= m_ObjectList.Count; aOrder++)
                {
                    QuerySearchObjectInfo qsoInfo = m_ObjectList.Item(aOrder);
                    qsoInfo.Copy((-aOrder - 1), (long) m_QueryDbService.ID);
                    DataRow rChild = GetObjectRowBySearchObject(qsoInfo.SearchObject);
                    if ((rChild != null) && (Utils.IsEmpty(rChild["idfParentQuerySearchObject"]) == false))
                    {
                        rChild["idfQuerySearchObject"] = (long) (-aOrder - 1);
                        rChild["idfParentQuerySearchObject"] = qsoRootID;
                        rChild["idflQuery"] = m_QueryDbService.ID;
                    }
                    qsoInfo.baseDataSet.AcceptChanges();
                }

                baseDataSet.AcceptChanges();

                m_IsNewOrCopy = true;

                if (ReadOnly != m_ReadOnlyMode)
                {
                    ReadOnly = m_ReadOnlyMode;
                }
            }
        }

        private void RaiseRefreshCaption()
        {
            string queryName = IsNationalLanguage
                ? txtQueryName.Text
                : txtDefQueryName.Text;
            RaiseSendCommand(new RefreshCaptionCommand(this, queryName));
        }

    }
}