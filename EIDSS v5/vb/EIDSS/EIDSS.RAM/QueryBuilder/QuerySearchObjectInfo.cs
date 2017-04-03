using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using DevExpress.XtraEditors;
using bv.common.win;
using bv.common.db.Core;
using DevExpress.XtraGrid.Views.Grid;
using EIDSS.RAM_DB.DBService.QueryBuilder;
using EIDSS.RAM.Components;
using eidss.model.Resources;
using bv.winclient.Core;

namespace EIDSS.RAM.QueryBuilder
{
    public partial class QuerySearchObjectInfo : BaseRamDetailPanel
    {
        
        
        private readonly FilterControlHelper m_FilterControlHelper;

        #region Init

        public QuerySearchObjectInfo()
        {
            InitializeComponent();
            QuerySearchObjectDbService = new QuerySearchObject_DB();
            DbService = QuerySearchObjectDbService;
            SearchObject = DefaultSearchObject;
            Order = 0;
            m_FilterControlHelper = new FilterControlHelper(QuerySearchFilter);
            m_FilterControlHelper.OnFilterChanged += DisplayFilter;
            splitContainer.SetPanelCollapsed(Config.GetBoolSetting("CollapseFilterPanel"));
            imlbcAvailableField.ImageList = RamFieldIcons.ImageList;
            imTypeImage.SmallImages = RamFieldIcons.ImageList;
        }

        public QuerySearchObjectInfo(long aSearchObject)
        {
            InitializeComponent();
            QuerySearchObjectDbService = new QuerySearchObject_DB();
            DbService = QuerySearchObjectDbService;
            SearchObject = aSearchObject;
            Order = 0;
            m_FilterControlHelper = new FilterControlHelper(QuerySearchFilter);
            m_FilterControlHelper.OnFilterChanged += DisplayFilter;
            splitContainer.SetPanelCollapsed(Config.GetBoolSetting("CollapseFilterPanel"));
            imlbcAvailableField.ImageList = RamFieldIcons.ImageList;
            imTypeImage.SmallImages = RamFieldIcons.ImageList;
        }

        public QuerySearchObjectInfo(long aSearchObject, int aOrder)
        {
            InitializeComponent();
            QuerySearchObjectDbService = new QuerySearchObject_DB();
            DbService = QuerySearchObjectDbService;
            SearchObject = aSearchObject;
            Order = aOrder >= 0 ? aOrder : 0;
            m_FilterControlHelper = new FilterControlHelper(QuerySearchFilter);
            m_FilterControlHelper.OnFilterChanged += DisplayFilter;
            splitContainer.SetPanelCollapsed(Config.GetBoolSetting("CollapseFilterPanel"));
            imlbcAvailableField.ImageList = RamFieldIcons.ImageList;
            imTypeImage.SmallImages = RamFieldIcons.ImageList;
        }


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
//            if (Utils.IsCalledFromUnitTest())
//                return;
            m_FilterControlHelper.OnFilterChanged -= DisplayFilter;
            m_FilterControlHelper.Dispose();
            eventManager.ClearAllReferences();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Keys

        public override object GetKey(string tableName, string keyFieldName)
        {
            return QuerySearchObjectDbService.ID;
        }
        #endregion

        #region Properties

        public readonly static long DefaultSearchObject = 10082000; // "sobHumanCases"

        private long m_SearchObject = -1L;

        

        [BrowsableAttribute(false), DefaultValueAttribute(-1L), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long SearchObject
        {
            get
            {
                return m_SearchObject;
            }
            set
            {
                if (m_SearchObject != value)
                {
                    m_SearchObject = value;
                    UpdateQuerySearchObjectID();
                }
            }
        }
        [BrowsableAttribute(false), DefaultValueAttribute(-1L), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public QuerySearchObject_DB QuerySearchObjectDbService { get; set; }

        private int m_Order = 0;
        [BrowsableAttribute(false), DefaultValueAttribute(0), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Order
        {
            get
            {
                return m_Order;
            }
            set
            {
                if (m_Order != value)
                {
                    m_Order = value;
                    UpdateQuerySearchObjectOrder();
                }
            }
        }

        private bool m_IsFFObject = false;
        [BrowsableAttribute(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsFFObject
        {
            get
            {
                return m_IsFFObject;
            }
        }

        private long m_FormType = -1L;
        [BrowsableAttribute(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new long FormType
        {
            get
            {
                return m_FormType;
            }
        }

        private HACode m_ObjectHACode = HACode.None;
        [BrowsableAttribute(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HACode ObjectHACode
        {
            get
            {
                return m_ObjectHACode;
            }
        }

        [BrowsableAttribute(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CaptionText
        {
            get
            {
                if (Utils.IsEmpty(m_SearchObject) == false)
                {
                    if (m_Order > 0)
                    {
                        return string.Format(
                                "{0} # {1}",
                                LookupCache.GetLookupValue(
                                    m_SearchObject, LookupTables.SearchObject, "Name"),
                                    m_Order);
                    }
                    return LookupCache.GetLookupValue(
                        m_SearchObject, LookupTables.SearchObject, "Name");
                }
                return ("");
            }
        }

        private string GetFieldGroupCaption
        {
            get
            {
                string caption = CaptionText;
                if (Utils.IsEmpty(caption) == false)
                {
                    caption = string.Format("{0} - {1}", caption, EidssMessages.Get("msgFieldGroupSuffix", "Fields", null));
                }
                return caption;
            }
        }

        private string GetFilterGroupCaption
        {
            get
            {
                string caption = CaptionText;
                if (Utils.IsEmpty(caption) == false)
                {
                    caption = string.Format("{0} - {1}", caption, EidssMessages.Get("msgFilterGroupSuffix", "Filters", null));
                }
                return caption;
            }
        }

        public override bool ReadOnly
        {
            get
            {
                return base.ReadOnly;
            }
            set
            {
                base.ReadOnly = value;
                btnAdd.Enabled = (!value);
                btnAddAll.Enabled = (!value);
                btnRemove.Enabled = (!value);
                btnRemoveAll.Enabled = (!value);
                gvSelectedField.OptionsBehavior.Editable = (!value);
                QuerySearchFilter.Enabled = (!value);
            }
        }

        #endregion

        #region Bindings

        private void BindAvailableFieldList()
        {
            string filterByDiagnosis = "";
            if (m_IsFFObject)
            {
                //Core.LookupBinder.BindParameterForFFTypeLookup(lbcAvailableField);
                Core.LookupBinder.BindParameterForFFTypeLookup(imlbcAvailableField);

                if ((m_FormType == 10034010) || //Human Clinical Signs
                    (m_FormType == 10034011))	//Human Epi Investigations
                {
                    Core.LookupBinder.BindDiagnosisHACodeLookup(cbFilterByDiagnosis, baseDataSet, LookupTables.HumanStandardDiagnosis, null, true, true);
                    filterByDiagnosis = " and DiagnosisString like '%'";
                }

            }
            else
            {
                //Core.LookupBinder.BindSearchFieldLookup(lbcAvailableField);
                Core.LookupBinder.BindSearchFieldLookup(imlbcAvailableField);
            }
            //DataView dv = (DataView)lbcAvailableField.DataSource;
            DataView dv = (DataView)imlbcAvailableField.DataSource;
            dv.RowFilter = string.Format("idfsSearchObject = '{0}' and blnAvailable = 1 {1}", m_SearchObject, filterByDiagnosis);
        }

        private void BindSelectedFieldList()
        {
            gcSelectedField.DataSource = null;
            gcSelectedField.DataSource = new DataView(
                                                baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField],
                                                "",
                                                "FieldCaption",
                                                DataViewRowState.CurrentRows);

            imTypeImage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            imTypeImage.Items.Clear();
            imTypeImage.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, 0),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 1, 1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 2, 2),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 3, 3),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 4, 4),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 5, 5),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 6, 6),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 7, 7),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 8, 8)});

            if (ReadOnly)
                gvSelectedField.OptionsBehavior.Editable = false;
        }

        private void UpdateFieldList()
        {
            //if ((lbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null))
            if ((imlbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null))
            {
                DataView dvSelectedField = (DataView)gcSelectedField.DataSource;
                //DataView dvAvailableField = (DataView)lbcAvailableField.DataSource;
                DataView dvAvailableField = (DataView)imlbcAvailableField.DataSource;
                int ind;
                DataRow rAvailable = null;
                foreach (DataRow r in dvAvailableField.Table.Rows)
                {
                    if (Utils.Str(r["idfsSearchObject"]) == Utils.Str(m_SearchObject))
                        r["blnAvailable"] = true;
                }
                for (ind = 0; ind < dvSelectedField.Count; ind++)
                {
                    DataRowView rSelected = null;
                    rSelected = dvSelectedField[ind];
                    if (m_IsFFObject)
                    {
                        string fieldKey = Utils.Str(rSelected["FieldAlias"]);
                        rAvailable = dvAvailableField.Table.Rows.Find(fieldKey);
                    }
                    else
                        rAvailable = dvAvailableField.Table.Rows.Find(rSelected["idfsSearchField"]);
                    if (rAvailable != null)
                    {
                        rAvailable.BeginEdit();
                        rAvailable["blnAvailable"] = false;
                        rAvailable.EndEdit();
                    }
                }
                if (dvAvailableField.Count >= 0)
                {
                    //lbcAvailableField.SelectedIndex = 0;
                    imlbcAvailableField.SelectedIndex = 0;
                }
            }
        }

        private void BindFilterTree()
        {
            if (baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQuerySearchField))
                m_FilterControlHelper.Bind((long)baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfQuerySearchObject"], baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].DefaultView, baseDataSet.Tables[QuerySearchObject_DB.tasQueryConditionGroup].DefaultView);
            else
                m_FilterControlHelper.Bind((long)baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfQuerySearchObject"], null, baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].DefaultView);
        }

        protected override void DefineBinding()
        {
            if ((baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQuerySearchObject)) &&
                (baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows.Count > 0) &&
                (Utils.IsEmpty(baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfsSearchObject"]) == false) &&
                (baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfsSearchObject"] is long) &&
                ((long)baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfsSearchObject"] != -1L))
            {
                m_SearchObject =
                    (long)baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfsSearchObject"];
            }

            BindAvailableFieldList();
            BindSelectedFieldList();
            BindFilterTree();
        }

        private void QuerySearchObjectInfo_AfterLoadData(object sender, EventArgs e)
        {
            UpdateQuerySearchObjectID();
            UpdateFieldList();
            UpdateConditionText();
        }

        #endregion

        #region Update Methods

        private void UpdateConditionList(object aQuerySearchFieldID)
        {
            if (Utils.IsEmpty(aQuerySearchFieldID))
            {
                return;
            }
            if ((baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQueryConditionGroup)))
                UpdateConditionText();
        }

        /// <summary>
        /// Updates visibility of diagnosis controls and location of other controls depending on specified form type.
        /// </summary>
        /// <param name="formType">Form type to determine state of visibility.</param>
        private void UpdateVisibilityOfDiagnosisByFormType
        (
            long formType
        )
        {
            bool isVisible = (formType == 10034010) ||	// Human Clinical Signs
                             (formType == 10034011);    // Human Epi Investigations
            bool ret = false;
            if (lblFilterByDiagnosis != null)
            {
                if (lblFilterByDiagnosis.Visible == isVisible)
                { ret = true; }
                lblFilterByDiagnosis.Visible = isVisible;
            }
            if (cbFilterByDiagnosis != null)
            {
                if (ret && (cbFilterByDiagnosis.Visible == isVisible))
                { ret = true; }
                cbFilterByDiagnosis.Visible = isVisible;
            }
            if (ret) { return; }
            if (isVisible)
            {
                if (lblAvailableField != null)
                {
                    lblAvailableField.Top = 28;
                }
                if (lblSelectedField != null)
                {
                    lblSelectedField.Top = 28;
                }
                if (imlbcAvailableField != null)
                {
                    imlbcAvailableField.Top = 47;
                    imlbcAvailableField.Height = navSearchFields.Height - 85; // Height of Navigator bar is greater that 85. Validaion is not needed.
                }
                if (gcSelectedField != null)
                {
                    gcSelectedField.Top = 47;
                    gcSelectedField.Height = navSearchFields.Height - 85; // Height of Navigator bar is greater that 85. Validaion is not needed.
                }
                if (btnAdd != null)
                {
                    btnAdd.Top = 116;
                }
                if (btnRemove != null)
                {
                    btnRemove.Top = 148;
                }
                if (btnAddAll != null)
                {
                    btnAddAll.Top = 180;
                }
                if (btnRemoveAll != null)
                {
                    btnRemoveAll.Top = 212;
                }
            }
            else
            {
                if (lblAvailableField != null)
                {
                    lblAvailableField.Top = 2;
                }
                if (lblSelectedField != null)
                {
                    lblSelectedField.Top = 2;
                }
                if (imlbcAvailableField != null)
                {
                    imlbcAvailableField.Top = 21;
                    imlbcAvailableField.Height = navSearchFields.Height - 59; // Height of Navigator bar is greater that 59. Validaion is not needed.
                }
                if (gcSelectedField != null)
                {
                    gcSelectedField.Top = 21;
                    gcSelectedField.Height = navSearchFields.Height - 59; // Height of Navigator bar is greater that 59. Validaion is not needed.
                }
                if (btnAdd != null)
                {
                    btnAdd.Top = 90;
                }
                if (btnRemove != null)
                {
                    btnRemove.Top = 122;
                }
                if (btnAddAll != null)
                {
                    btnAddAll.Top = 154;
                }
                if (btnRemoveAll != null)
                {
                    btnRemoveAll.Top = 186;
                }
                
            }
        }

        private void UpdateFFType()
        {
            DataView dvObject = LookupCache.Get(LookupTables.SearchObject);
            if (dvObject != null)
            {
                dvObject.RowFilter = string.Format("idfsSearchObject = {0}", m_SearchObject);
                if ((dvObject.Count > 0) && (Utils.IsEmpty(dvObject[0]["idfsFormType"]) == false) &&
                    (dvObject[0]["idfsFormType"] is long) && ((long)dvObject[0]["idfsFormType"] != -1L))
                {
                    //if ((m_IsFFObject == false) && (lbcAvailableField.DataSource != null))
                    if ((m_IsFFObject == false) && (imlbcAvailableField.DataSource != null))
                    {
                    BindAvailableFieldList();
                    }
                    m_IsFFObject = true;
                    m_FormType = (long)dvObject[0]["idfsFormType"];
                    UpdateVisibilityOfDiagnosisByFormType(m_FormType);
                    return;
                }
            }
            //if (m_IsFFObject && lbcAvailableField.DataSource != null)
            if (m_IsFFObject && imlbcAvailableField.DataSource != null)
            {
                BindAvailableFieldList();
            }
            m_IsFFObject = false;
            m_FormType = -1L;
            UpdateVisibilityOfDiagnosisByFormType(m_FormType);
        }

        private void UpdateObjectHACode()
        {
            DataView dvObject = LookupCache.Get(LookupTables.SearchObject);
            if (dvObject != null)
            {
                dvObject.RowFilter = string.Format("idfsSearchObject = {0}", m_SearchObject);
                if ((dvObject.Count > 0) && (Utils.IsEmpty(dvObject[0]["intHACode"]) == false))
                {
                    m_ObjectHACode = (HACode)dvObject[0]["intHACode"];
                    if (m_FilterControlHelper != null)
                    {
                        m_FilterControlHelper.ObjectHACode = m_ObjectHACode;
                    }
                    return;
                }
            }
            m_ObjectHACode = HACode.None;
            if (m_FilterControlHelper != null)
            {
                m_FilterControlHelper.ObjectHACode = m_ObjectHACode;
            }
        }

        private void UpdateQuerySearchObjectID()
        {
            if (IsDesignMode())
            {
                return;
            }
            grpSearchFields.Caption = GetFieldGroupCaption;
            grcQueryObjectFiltration.Text = GetFilterGroupCaption;

            UpdateFFType();
            UpdateObjectHACode();

            if ((baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQuerySearchObject)) &&
                (baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows.Count > 0))
            {
                if (Utils.Str(baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfsSearchObject"]) !=
                    Utils.Str(m_SearchObject))
                {
                    if ((baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQuerySearchField)) &&
                        (baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows.Count > 0))
                    {
                        int ind;
                        for (ind = baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows.Count - 1; ind >= 0; ind--)
                        {
                            if (baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows[ind].RowState != DataRowState.Deleted)
                            {
                                UpdateConditionList(
                                    baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows[ind]["idfQuerySearchField"]);
                                baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows[ind].Delete();
                                m_FilterControlHelper.Refresh();
                            }
                        }
                    }
                    UpdateFieldList();
                }
                if (Utils.IsEmpty(m_SearchObject))
                {
                    baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfsSearchObject"] = DBNull.Value;
                }
                else
                {
                    baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfsSearchObject"] = m_SearchObject;
                }
            }
            //if (lbcAvailableField.DataSource != null)
            if (imlbcAvailableField.DataSource != null)
            {
                //DataView dv = (DataView)lbcAvailableField.DataSource;
                var dv = (DataView)imlbcAvailableField.DataSource;
                dv.RowFilter = string.Format("idfsSearchObject = {0} and blnAvailable = 1 ", m_SearchObject);
            }
        }


        private void UpdateQuerySearchObjectOrder()
        {
            grpSearchFields.Caption = GetFieldGroupCaption;
            grcQueryObjectFiltration.Text = GetFilterGroupCaption;

            if ((baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQuerySearchObject)) &&
                (baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows.Count > 0))
            {
                baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["intOrder"] = m_Order;
            }
        }

        private string GetConditionText(long aQueryConditionGroupID, bool addOperation)
        {
            if ((baseDataSet == null) || (baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQueryConditionGroup) == false))
            {
                return "";
            }
            DataRow rGroup = baseDataSet.Tables[QuerySearchObject_DB.tasQueryConditionGroup].Rows.Find(aQueryConditionGroupID);
            if ((rGroup == null) || (rGroup.RowState == DataRowState.Deleted))
            {
                return "";
            }
            string strOr = "";
            string strNot = "";
            if (addOperation)
            {
                if (Utils.IsEmpty(rGroup["blnJoinByOr"]) == false)
                {

                    if ((bool)rGroup["blnJoinByOr"])
                    {
                        strOr = " " + EidssMessages.Get("msgOR", "OR");
                    }
                    else
                    {
                        strOr = " " + EidssMessages.Get("msgAND", "AND");
                    }
                }
                if (!Utils.IsEmpty(rGroup["blnUseNot"]) && ((bool)rGroup["blnUseNot"]))
                {
                    strNot = " " + EidssMessages.Get("msgNOT", "NOT");
                }
            }
            string cond = strOr + strNot;
            if (cond.Length > 0)
            {
                cond = cond + " ";
            }
            cond = cond + "{0}";
            if (Utils.IsEmpty(rGroup["idfQuerySearchFieldCondition"]) == false)
            {
                return string.Format(cond, rGroup["SearchFieldConditionText"]);
            }
            cond = string.Format(cond, "({0})");
            DataRow[] dr = baseDataSet.Tables[QuerySearchObject_DB.tasQueryConditionGroup].Select(string.Format("idfParentQueryConditionGroup = {0} ", aQueryConditionGroupID), "intOrder", DataViewRowState.CurrentRows);
            foreach (DataRow r in dr)
            {
                cond = string.Format(cond, GetConditionText((long)r["idfQueryConditionGroup"], true) + "{0}");
            }
            return string.Format(cond, "");
        }

        private void UpdateConditionText()
        {
            if ((baseDataSet == null) || (baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQueryConditionGroup) == false))
            {
                return;
            }
            foreach (DataRow r in baseDataSet.Tables[QuerySearchObject_DB.tasQueryConditionGroup].Rows)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    r["SearchFieldConditionText"] = GetConditionText((long)r["idfQueryConditionGroup"], false);
                }
            }
        }

        #endregion

        #region Handlers

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if ((lbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null) &&
            if ((imlbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null) &&
                (baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQuerySearchField)))
            {
                //DataView dvAvailable = (DataView)lbcAvailableField.DataSource;
                var dvAvailable = (DataView)imlbcAvailableField.DataSource;
                //if ((lbcAvailableField.SelectedIndex >= 0) &&
                //    (lbcAvailableField.SelectedIndex < dvAvailable.Count))
                if ((imlbcAvailableField.SelectedIndex >= 0) &&
                    (imlbcAvailableField.SelectedIndex < dvAvailable.Count))
                {
                    //DataRow rAvailable = dvAvailable[lbcAvailableField.SelectedIndex].Row;
                    DataRow rAvailable = dvAvailable[imlbcAvailableField.SelectedIndex].Row;
                    rAvailable.BeginEdit();
                    rAvailable["blnAvailable"] = false;
                    rAvailable.EndEdit();

                    long querySearchFieldID = -1L;

                    DataRow[] r = baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Select(
                                    string.Format("idfQuerySearchField <= {0}", querySearchFieldID), "idfQuerySearchField");
                    if (r.Length > 0)
                    {
                        if (r[0].RowState != DataRowState.Deleted)
                        {
                            querySearchFieldID = (long)(r[0]["idfQuerySearchField"]) - 1;
                        }
                        else
                        {
                            querySearchFieldID = (long)(r[0]["idfQuerySearchField", DataRowVersion.Original]) - 1;
                        }
                    }

                    DataRow rSelected = baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].NewRow();
                    rSelected["idfQuerySearchField"] = querySearchFieldID;
                    rSelected["idfQuerySearchObject"] =
                        baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfQuerySearchObject"];
                    rSelected["idfsSearchField"] = rAvailable["idfsSearchField"];
                    if (m_IsFFObject)
                    {
                        rSelected["FieldCaption"] = rAvailable["ParameterName"];
                        rSelected["blnShow"] = 1;
                        rSelected["idfsParameter"] = rAvailable["idfsParameter"];
                        rSelected["FieldAlias"] = rAvailable["FieldAlias"];
                        rSelected["TypeImageIndex"] = rAvailable["TypeImageIndex"];
                    }
                    else
                    {
                        rSelected["FieldCaption"] = rAvailable["FieldCaption"];
                        rSelected["blnShow"] = 1;
                        rSelected["idfsParameter"] = DBNull.Value;
                        rSelected["FieldAlias"] = rAvailable["strSearchFieldAlias"];
                        rSelected["TypeImageIndex"] = rAvailable["TypeImageIndex"];
                    }
                    baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows.Add(rSelected);
                    m_FilterControlHelper.Refresh();
                }
            }
        }

        private void imlbcAvailableField_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((!ReadOnly) &&
                (e.Button == MouseButtons.Left) &&
                //(lbcAvailableField.SelectedIndex >= 0) &&
                //(lbcAvailableField.GetItemRectangle(lbcAvailableField.SelectedIndex) != null) &&
                //(lbcAvailableField.GetItemRectangle(lbcAvailableField.SelectedIndex).Contains(e.Location) == true))
                (imlbcAvailableField.SelectedIndex >= 0) &&
                (imlbcAvailableField.GetItemRectangle(imlbcAvailableField.SelectedIndex) != null) &&
                imlbcAvailableField.GetItemRectangle(imlbcAvailableField.SelectedIndex).Contains(e.Location))
            {
                btnAdd_Click(sender, new EventArgs());
            }
        }

        private void imlbcAvailableField_MouseMove(object sender, MouseEventArgs e)
        {
            ImageListBoxControl listBoxControl = sender as ImageListBoxControl;
            if (listBoxControl != null)
            {
                int index = listBoxControl.IndexFromPoint(new System.Drawing.Point(e.X, e.Y));
                string item = "";
                var point = new System.Drawing.Point(e.X, e.Y);
                if ((imlbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null) &&
                (baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQuerySearchField)))
                {
                    var dvAvailable = (DataView)imlbcAvailableField.DataSource;
                    DataRowView r = null;
                    if (index != -1)
                    {
                        r = listBoxControl.GetItem(index) as DataRowView;
                    }
                    else if ((imlbcAvailableField.SelectedIndex >= 0) &&
                             (imlbcAvailableField.SelectedIndex < dvAvailable.Count))
                    {
                        r = dvAvailable[imlbcAvailableField.SelectedIndex];
                        point = new System.Drawing.Point(
                                                    imlbcAvailableField.Right,
                                                    imlbcAvailableField.GetItemRectangle(imlbcAvailableField.SelectedIndex).Top);
                    }
                    if (r != null)
                    {
                        if (m_IsFFObject)
                        {
                            item = r["ParameterName"] as string;
                        }
                        else
                        {
                            item = r["FieldCaption"] as string;
                        }
                    }
                }
                if (Utils.IsEmpty(item) == false)
                {
                    ttcAvailableField.ShowHint(item, listBoxControl.PointToScreen(point));
                }
                else
                {
                    ttcAvailableField.HideHint();
                }
            }
        }


        private void imlbcAvailableField_MouseLeave(object sender, EventArgs e)
        {
            ttcAvailableField.HideHint();
        }


        private void imlbcAvailableField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((imlbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null) &&
                (baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQuerySearchField)))
            {
                var dvAvailable = (DataView)imlbcAvailableField.DataSource;
                string item = "";
                if ((imlbcAvailableField.SelectedIndex >= 0) &&
                    (imlbcAvailableField.SelectedIndex < dvAvailable.Count))
                {
                    DataRowView r = dvAvailable[imlbcAvailableField.SelectedIndex];
                    if (r != null)
                    {
                        if (m_IsFFObject)
                        {
                            item = r["ParameterName"] as string;
                        }
                        else
                        {
                            item = r["FieldCaption"] as string;
                        }
                    }
                }
                if (Utils.IsEmpty(item) == false)
                {
                    ttcAvailableField.ShowHint(item, imlbcAvailableField.PointToScreen(new System.Drawing.Point(
                                                            imlbcAvailableField.Right, 
                                                            imlbcAvailableField.GetItemRectangle(imlbcAvailableField.SelectedIndex).Top)));
                }
                else
                {
                    ttcAvailableField.HideHint();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //if ((lbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null) &&
            if ((imlbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null) &&
                (baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQuerySearchField)))
            {
                var dvSelected = (DataView) gcSelectedField.DataSource;
                if ((gvSelectedField.FocusedRowHandle >= 0) &&
                    (gvSelectedField.FocusedRowHandle < dvSelected.Count))
                {
                    DataRow rSelected = baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows.Find(
                            gvSelectedField.GetFocusedRowCellValue("idfQuerySearchField"));
                    if ((rSelected != null) && (rSelected.RowState != DataRowState.Deleted))
                    {
                        //DataView dvAvailable = (DataView)lbcAvailableField.DataSource;
                        var dvAvailable = (DataView) imlbcAvailableField.DataSource;
                        DataRow rAvailable;
                        if (m_IsFFObject)
                        {
                            string fieldKey = Utils.Str(rSelected["FieldAlias"]);
                            rAvailable = dvAvailable.Table.Rows.Find(fieldKey);
                        }
                        else
                        {
                            rAvailable = dvAvailable.Table.Rows.Find(rSelected["idfsSearchField"]);
                        }
                        if (rAvailable != null)
                        {
                            rAvailable.BeginEdit();
                            rAvailable["blnAvailable"] = true;
                            rAvailable.EndEdit();
                        }

                        UpdateConditionList(rSelected["idfQuerySearchField"]);
                        rSelected.Delete();
                        m_FilterControlHelper.Refresh();

                    }
                }
            }
        }

        private void gvSelectedField_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if ((!ReadOnly) &&
                (e.Button == MouseButtons.Left) &&
                (e.Clicks == 2) &&
                (e.RowHandle >= 0) &&
                (e.Column.FieldName == "FieldCaption"))
            {
                btnRemove_Click(sender, new EventArgs());
            }
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            //if ((lbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null) &&
            if ((imlbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null) &&
                (baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQuerySearchField)))
            {
                //DataView dvAvailable = (DataView)lbcAvailableField.DataSource;
                var dvAvailable = (DataView)imlbcAvailableField.DataSource;
                DataRow rAvailable;
                long querySearchFieldID = -1L;

                if (dvAvailable.Count > 0)
                {
                    int ind;
                    DataRow[] r = baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Select(
                                    string.Format("idfQuerySearchField <= {0}", querySearchFieldID), "idfQuerySearchField");
                    if (r.Length > 0)
                    {
                        if (r[0].RowState != DataRowState.Deleted)
                        {
                            querySearchFieldID = (long)(r[0]["idfQuerySearchField"]) - 1;
                        }
                        else
                        {
                            querySearchFieldID = (long)(r[0]["idfQuerySearchField", DataRowVersion.Original]) - 1;
                        }
                    }

                    for (ind = dvAvailable.Count - 1; ind >= 0; ind--)
                    {
                        rAvailable = dvAvailable[ind].Row;
                        rAvailable.BeginEdit();
                        rAvailable["blnAvailable"] = false;
                        rAvailable.EndEdit();

                        DataRow rSelected = baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].NewRow();
                        rSelected["idfQuerySearchField"] = querySearchFieldID;
                        rSelected["idfQuerySearchObject"] =
                            baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfQuerySearchObject"];
                        rSelected["idfsSearchField"] = rAvailable["idfsSearchField"];
                        if (m_IsFFObject)
                        {
                            rSelected["FieldCaption"] = rAvailable["ParameterName"];
                            rSelected["blnShow"] = 1;
                            rSelected["idfsParameter"] = rAvailable["idfsParameter"];
                            rSelected["FieldAlias"] = rAvailable["FieldAlias"];
                            rSelected["TypeImageIndex"] = rAvailable["TypeImageIndex"];
                        }
                        else
                        {
                            rSelected["FieldCaption"] = rAvailable["FieldCaption"];
                            rSelected["blnShow"] = 1;
                            rSelected["idfsParameter"] = DBNull.Value;
                            rSelected["FieldAlias"] = rAvailable["strSearchFieldAlias"];
                            rSelected["TypeImageIndex"] = rAvailable["TypeImageIndex"];
                        }
                        baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows.Add(rSelected);

                        querySearchFieldID = querySearchFieldID - 1;
                    }
                    m_FilterControlHelper.Refresh();

                }
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            //if ((lbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null) &&
            if ((imlbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null) &&
                (baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQuerySearchField)))
            {
                int ind;
                DataRow rSelected;
                for (ind = baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows.Count - 1; ind >= 0; ind--)
                {
                    rSelected = baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows[ind];
                    if (rSelected.RowState != DataRowState.Deleted)
                    {
                        //DataView dvAvailable = (DataView)lbcAvailableField.DataSource;
                        DataView dvAvailable = (DataView)imlbcAvailableField.DataSource;
                        DataRow rAvailable = null;
                        if (m_IsFFObject)
                        {
                            string fieldKey = Utils.Str(rSelected["FieldAlias"]);
                            rAvailable = dvAvailable.Table.Rows.Find(fieldKey);
                        }
                        else
                        {
                            rAvailable = dvAvailable.Table.Rows.Find(rSelected["idfsSearchField"]);
                        }
                        if (rAvailable != null)
                        {
                            rAvailable.BeginEdit();
                            rAvailable["blnAvailable"] = true;
                            rAvailable.EndEdit();
                        }

                        UpdateConditionList(rSelected["idfQuerySearchField"]);
                        rSelected.Delete();
                    }
                }
                m_FilterControlHelper.Refresh();
            }
        }


        private void cbFilterByDiagnosis_EditValueChanged(object sender, EventArgs e)
        {
            if ((m_FormType != 10034010) && //Human Clinical Signs
                (m_FormType != 10034011))	//Human Epi Investigations
            {
                return;
            }
            if (imlbcAvailableField.DataSource == null)
            {
                return;
            }

            string filterByDiagnosis = " and DiagnosisString like '{0}'";
            if (Utils.IsEmpty(cbFilterByDiagnosis.EditValue))
            {
                filterByDiagnosis = string.Format(filterByDiagnosis, "%");
            }
            else
            {
                filterByDiagnosis = string.Format(filterByDiagnosis, string.Format("%{0};%", Utils.Str(cbFilterByDiagnosis.EditValue)));
            }

            DataView dv = (DataView)imlbcAvailableField.DataSource;
            dv.RowFilter = string.Format("idfsSearchObject = '{0}' and blnAvailable = 1 {1}", m_SearchObject, filterByDiagnosis);
        }


        #endregion

        #region Special Methods

        private void DisplayFilter(object sender, FilterChangedEventArgs e)
        {
            txtFilterText.Lines = m_FilterControlHelper.FilterLines;
        }

        private DataSet m_DS;

        public void SaveQuerySearchObjectInfo()
        {
            if (baseDataSet == null)
            {
                m_DS = null;
                return;
            }
            m_DS = baseDataSet.Copy();
            if (baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQueryConditionGroup) == false)
            {
                return;
            }
        }

        private static long GetNewNegativeID(long[] oldList, long idEx)
        {
            for (int i = 0; i < oldList.Length; i++)
            {
                if (oldList[i] == idEx)
                {
                    return -(i + 1);
                }
            }
            return 0;
        }

        public void RestoreQuerySearchObjectInfo(long qsoID)
        {
            if (m_DS == null)
            {
                return;
            }
            object id = qsoID;
            LoadData(ref id);
            foreach (DataTable dt in baseDataSet.Tables)
            {
                dt.Rows.Clear();
            }
            baseDataSet.Merge(m_DS);
            baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfQuerySearchObject"] = QuerySearchObjectDbService.ID;

            long fieldID = -1L;
            var fieldList = new long[baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows.Count];
            foreach (DataRow rField in baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows)
            {
                if (rField.RowState != DataRowState.Deleted)
                {
                    fieldList[-fieldID - 1] = (long) rField["idfnQuerySearchField"];
                    rField["idfQuerySearchField"] = fieldID;
                    rField["idfQuerySearchObject"] = QuerySearchObjectDbService.ID;
                    fieldID = fieldID - 1;
                }
            }

            long groupID = -1L;
            var groupList = new long[baseDataSet.Tables[QuerySearchObject_DB.tasQueryConditionGroup].Rows.Count];
            foreach (DataRow rGroup in baseDataSet.Tables[QuerySearchObject_DB.tasQueryConditionGroup].Rows)
            {
                if (rGroup.RowState != DataRowState.Deleted)
                {
                    rGroup["idfQueryConditionGroup"] = groupID;
                    rGroup["idfQuerySearchObject"] = QuerySearchObjectDbService.ID;
                    groupID = groupID - 1;
                }
            }
            foreach (DataRow rGroup in baseDataSet.Tables[QuerySearchObject_DB.tasQueryConditionGroup].Rows)
            {
                if (rGroup.RowState != DataRowState.Deleted)
                {
                    if (Utils.IsEmpty(rGroup["idfParentQueryConditionGroup"]) == false)
                    {
                        long groupIDNew = GetNewNegativeID(groupList, (long)rGroup["idfParentQueryConditionGroup"]);
                        rGroup["idfParentQueryConditionGroup"] = groupIDNew;
                    }
                }
            }

            DefineBinding();
            AfterLoad();
            m_DS = null;
        }

        public void Copy(long qsoID, long queryID)
        {
            QuerySearchObjectDbService.Copy(baseDataSet, qsoID, queryID);

            long fieldID = -1L;
            var fieldList = new long[baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows.Count];
            foreach (DataRow rField in baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows)
            {
                if (rField.RowState != DataRowState.Deleted)
                {
                    fieldList[(int)(-fieldID - 1)] = (long)rField["idfQuerySearchField"];
                    rField["idfQuerySearchField"] = fieldID;
                    rField["idfQuerySearchObject"] = QuerySearchObjectDbService.ID;
                    fieldID = fieldID - 1;
                }
            }

            long groupID = 0;
            var groupList = new long[baseDataSet.Tables[QuerySearchObject_DB.tasQueryConditionGroup].Rows.Count];
            long lastGroupID = 0;
            foreach (DataRow rGroup in baseDataSet.Tables[QuerySearchObject_DB.tasQueryConditionGroup].Rows)
            {
                if (rGroup.RowState != DataRowState.Deleted)
                {
                    var groupIDEx = (long)rGroup["idfQueryConditionGroup"];
                    if (groupIDEx != lastGroupID)
                    {
                        groupID = groupID - 1;
                        lastGroupID = groupIDEx;
                        groupList[(int)(-groupID - 1)] = groupIDEx;
                    }
                    rGroup["idfQueryConditionGroup"] = groupID;
                    if (Utils.IsEmpty(rGroup["idfQuerySearchField"]) == false)
                    {
                        rGroup["idfQuerySearchField"] = GetNewNegativeID(fieldList, (long)rGroup["idfQuerySearchField"]);
                    }
                    rGroup["idfQuerySearchObject"] = QuerySearchObjectDbService.ID;
                }
            }
            foreach (DataRow rGroup in baseDataSet.Tables[QuerySearchObject_DB.tasQueryConditionGroup].Rows)
            {
                if (rGroup.RowState != DataRowState.Deleted)
                {
                    if (Utils.IsEmpty(rGroup["idfParentQueryConditionGroup"]) == false)
                    {
                        long groupIDNew = GetNewNegativeID(groupList, (long)rGroup["idfParentQueryConditionGroup"]);
                        rGroup["idfParentQueryConditionGroup"] = groupIDNew;
                    }
                }
            }
            BindFilterTree();
        }

        private void splitContainer_SplitGroupPanelCollapsed(object sender, SplitGroupPanelCollapsedEventArgs e)
        {
            UserConfigWriter.Instance.SetItem("CollapseFilterPanel", e.Collapsed.ToString());
            UserConfigWriter.Instance.Save();
            Config.ReloadSettings();
        }

        #endregion

        #region Validate Methods

        public bool ValidateQSOInfo()
        {
            if ((baseDataSet == null) || (baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQuerySearchObject) == false))
                return true;
            var dvField =new DataView(baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField], "", "", DataViewRowState.CurrentRows);
            if (dvField.Count == 0)
                return false;
            return m_FilterControlHelper.Validate();
        }

        public void ShowQSOInfoError()
        {
            var dvField =new DataView(baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField], "", "", DataViewRowState.CurrentRows);
            if (dvField.Count == 0)
                MessageForm.Show(EidssMessages.Get("msgNoSearchField", "No fields are selected. Remove this search object or select some available fields."));
        }

        #endregion

        #region Post Methods

        public override bool HasChanges()
        {
            return m_FilterControlHelper.HasChanges || base.HasChanges();
        }

        private void QuerySearchObjectInfo_OnAfterPost(object sender, EventArgs e)
        {
            if ((baseDataSet == null) ||
                (baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQueryConditionGroup) == false))
                return;
            baseDataSet.AcceptChanges();
            m_FilterControlHelper.UpdateFieldInfo();
            m_FilterControlHelper.HasChanges = false;
        }
        private void QuerySearchObjectInfo_OnBeforePost(object sender, EventArgs e)
        {
            m_FilterControlHelper.Flush(null, 0);
        }

        #endregion

        #region Get Functions

        internal DataView GetQuerySearchFieldView()
        {
            DataView dvField = null;
            if ((baseDataSet != null) && baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQuerySearchField))
            {
                dvField = new DataView(
                            baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField], 
                            "", 
                            "idfQuerySearchField", 
                            DataViewRowState.CurrentRows);
                if (dvField.Count == 0)
                {
                    dvField = null;
                }
            }
            return dvField;
        }

        #endregion
       
    }
}
