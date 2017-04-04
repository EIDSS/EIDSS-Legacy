using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.win.BaseForms;
using bv.winclient.Core;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using EIDSS;
using eidss.avr.db.DBService.QueryBuilder;
using eidss.avr.PivotComponents;
using EIDSS.Core;
using eidss.model.Resources;
using Localizer = bv.common.Core.Localizer;
using System.Collections.Generic;


namespace eidss.avr.QueryBuilder
{
    public partial class QuerySearchObjectInfo : BaseAvrDetailPanel
    {
        //old filter//private readonly FilterControlHelper m_FilterControlHelper;
        public const long DefaultSearchObject = 10082000; // "sobHumanCases"
        private long m_SearchObject = -1L;
        private int m_Order;
        private bool m_IsFFObject;
        private HACode m_ObjectHACode = HACode.None;
        private object m_ReportType = DBNull.Value;
        private int m_SavedSplitPosition;

        #region Init

        public QuerySearchObjectInfo()
        {
            InitializeComponent();
            Init();
            //QuerySearchObjectDbService = new QuerySearchObject_DB();
            //DbService = QuerySearchObjectDbService;
            //SearchObject = DefaultSearchObject;
            //Order = 0;
            ////old filter//m_FilterControlHelper = new FilterControlHelper(QuerySearchFilter);
            ////old filter//m_FilterControlHelper.OnFilterChanged += DisplayFilter;
            //qsoFilter.OnFilterChanged += DisplayFilter;
            //splitContainerFilters.SetPanelCollapsed(Config.GetBoolSetting("CollapseFilterPanel"));
            //imlbcAvailableField.ImageList = AvrFieldIcons.ImageList;
            //imTypeImage.SmallImages = AvrFieldIcons.ImageList;
        }

        public QuerySearchObjectInfo(long aSearchObject)
        {
            InitializeComponent();
            Init(aSearchObject);
            //QuerySearchObjectDbService = new QuerySearchObject_DB();
            //DbService = QuerySearchObjectDbService;
            //SearchObject = aSearchObject;
            //Order = 0;
            ////old filter//m_FilterControlHelper = new FilterControlHelper(QuerySearchFilter);
            ////old filter//m_FilterControlHelper.OnFilterChanged += DisplayFilter;
            //qsoFilter.OnFilterChanged += DisplayFilter;
            //splitContainerFilters.SetPanelCollapsed(Config.GetBoolSetting("CollapseFilterPanel"));
            //imlbcAvailableField.ImageList = AvrFieldIcons.ImageList;
            //imTypeImage.SmallImages = AvrFieldIcons.ImageList;
        }

        public QuerySearchObjectInfo(long aSearchObject, int aOrder)
        {
            InitializeComponent();
            Init(aSearchObject, aOrder);

            //QuerySearchObjectDbService = new QuerySearchObject_DB();
            //DbService = QuerySearchObjectDbService;
            //SearchObject = aSearchObject;
            //Order = aOrder >= 0 ? aOrder : 0;
            ////old filter//m_FilterControlHelper = new FilterControlHelper(QuerySearchFilter);
            ////old filter//m_FilterControlHelper.OnFilterChanged += DisplayFilter;
            //qsoFilter.OnFilterChanged += DisplayFilter;
            //splitContainerFilters.SetPanelCollapsed(Config.GetBoolSetting("CollapseFilterPanel"));
            //imlbcAvailableField.ImageList = AvrFieldIcons.ImageList;
            //imTypeImage.SmallImages = AvrFieldIcons.ImageList;
        }

        public QuerySearchObjectInfo(long aSearchObject = DefaultSearchObject, int aOrder = 0, object aReportType = null)
        {
            InitializeComponent();
            Init(aSearchObject, aOrder, aReportType);
        }

        public void Init(long aSearchObject = DefaultSearchObject, int aOrder = 0, object aReportType = null)
        {
            if (IsDesignMode())
                return;
            QuerySearchObjectDbService = new QuerySearchObject_DB();
            DbService = QuerySearchObjectDbService;
            SearchObject = aSearchObject;
            Order = aOrder >= 0 ? aOrder : 0;
            ReportType = aReportType;
            //old filter//m_FilterControlHelper = new FilterControlHelper(QuerySearchFilter);
            //old filter//m_FilterControlHelper.OnFilterChanged += DisplayFilter;
            qsoFilter.OnFilterChanged += DisplayFilter;
            splitContainerFilters.SetPanelCollapsed(Config.GetBoolSetting("CollapseFilterPanel"));
            imlbcAvailableField.ImageList = AvrFieldIcons.ImageList;
            imTypeImage.SmallImages = AvrFieldIcons.ImageList;
            imlbcAvailableField.Height = splitContainerFields.Panel1.Height - imlbcAvailableField.Top - 4;
            gcSelectedField.Height = splitContainerFields.Panel2.Height - gcSelectedField.Top - 4;
            m_SavedSplitPosition = splitContainerFields.SplitterPosition;

            if (Localizer.IsRtl)
            {
                splitContainerFields.CollapsePanel = SplitCollapsePanel.Panel2;
                splitContainerFields.FixedPanel = SplitFixedPanel.Panel1;
                navSearchFields.Dock = DockStyle.Right;
                splitFields.Dock = DockStyle.Right;
                //SwapContent(splitContainerFields);
            }
        }

        private void SwapContent(SplitContainerControl splitContainerControl)
        {
            splitContainerControl.SuspendLayout();
            var controls1 = splitContainerControl.Panel1.Controls.Cast<Control>().ToArray();
            var controls2 = splitContainerControl.Panel2.Controls.Cast<Control>().ToArray();
            var width1 = splitContainerControl.Panel1.Width;
            var width2 = splitContainerControl.Panel2.Width;
            splitContainerControl.Panel1.Controls.Clear();
            splitContainerControl.Panel2.Controls.Clear();
            splitContainerControl.Panel1.Width = width2;
            splitContainerControl.Panel2.Width = width1;
            splitContainerControl.Panel1.Controls.AddRange(controls2);
            splitContainerControl.Panel2.Controls.AddRange(controls1);
            imlbcAvailableField.Height = splitContainerControl.Panel1.Height - imlbcAvailableField.Top - 4;
            gcSelectedField.Height = splitContainerControl.Panel2.Height - gcSelectedField.Top - 4;
            splitContainerControl.ResumeLayout();
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                //            if (Utils.IsCalledFromUnitTest())
                //                return;

                //old filter//m_FilterControlHelper.OnFilterChanged -= DisplayFilter;
                //TODO: Is the next line needed?
                if (qsoFilter != null) qsoFilter.OnFilterChanged -= DisplayFilter;
                //old filter//m_FilterControlHelper.Dispose();
                eventManager.ClearAllReferences();
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

        #endregion

        #region Keys

        public override object GetKey(string tableName = null, string keyFieldName = null)
        {
            return QuerySearchObjectDbService.ID;
        }

        #endregion

        #region Properties

        [Browsable(false), DefaultValue(-1L), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long SearchObject
        {
            get { return m_SearchObject; }
            set
            {
                if (m_SearchObject != value)
                {
                    m_SearchObject = value;
                    UpdateQuerySearchObjectID();
                }
            }
        }

        [Browsable(false), DefaultValue(-1L), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public QuerySearchObject_DB QuerySearchObjectDbService { get; set; }

        [Browsable(false), DefaultValue(0), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Order
        {
            get { return m_Order; }
            set
            {
                if (m_Order != value)
                {
                    m_Order = value;
                    UpdateQuerySearchObjectOrder();
                }
            }
        }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsFFObject
        {
            get { return m_IsFFObject; }
        }

        private long m_FormType = -1L;

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new long FormType
        {
            get { return m_FormType; }
        }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HACode ObjectHACode
        {
            get { return m_ObjectHACode; }
        }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object ReportType
        {
            get { return m_ReportType; }
            set
            {
                if (m_ReportType != value)
                {
                    m_ReportType = value;
                }
            }
        }

        [Browsable(false), DefaultValue(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowReportType
        {
            get
            {
                if (((m_SearchObject == 10082020) || // Vet Case
                     (m_SearchObject == 10082021) || // Vet Case Sample
                     (m_SearchObject == 10082022) || // Vet Case Test
                     (m_SearchObject == 10082038) // Zoonotic disease
                    ) &&
                    (m_Order == 0)
                   )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
                    caption = string.Format("{0} - {1}", caption, EidssMessages.Get("msgFieldGroupSuffix", "Fields"));
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
                    caption = string.Format("{0} - {1}", caption, EidssMessages.Get("msgFilterGroupSuffix", "Filters"));
                }
                return caption;
            }
        }

        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                base.ReadOnly = value;
                btnAdd.Enabled = (!value);
                btnAddAll.Enabled = (!value);
                btnRemove.Enabled = (!value);
                btnRemoveAll.Enabled = (!value);
                cbFilterByDiagnosis.Enabled = (!value);
                gvSelectedField.OptionsBehavior.Editable = (!value);
                cbReportType.Enabled = (!value);
                //old filter//QuerySearchFilter.Enabled = (!value);
                qsoFilter.Enabled = (!value);
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
                LookupBinder.BindParameterForFFTypeLookup(imlbcAvailableField);

                if ((m_FormType == 10034010) || //Human Clinical Signs
                    (m_FormType == 10034011)) //Human Epi Investigations
                {
                    LookupBinder.BindDiagnosisHACodeLookup(cbFilterByDiagnosis, baseDataSet, LookupTables.HumanStandardDiagnosis, null);
                    filterByDiagnosis = " and DiagnosisString like '%'";
                }
            }
            else
            {
                //Core.LookupBinder.BindSearchFieldLookup(lbcAvailableField);
                LookupBinder.BindSearchFieldLookup(imlbcAvailableField);
            }
            //DataView dv = (DataView)lbcAvailableField.DataSource;
            var dv = (DataView)imlbcAvailableField.DataSource;
            dv.RowFilter = string.Format("idfsSearchObject = '{0}' and blnAvailable = 1 {1}", m_SearchObject, filterByDiagnosis);
        }

        private void BindSelectedFieldList()
        {
            gcSelectedField.DataSource = null;
            gcSelectedField.DataSource = new DataView(
                baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField],
                "",
                "FieldCaption",
                DataViewRowState.CurrentRows);

            imTypeImage.BorderStyle = BorderStyles.NoBorder;
            imTypeImage.Items.Clear();
            imTypeImage.Items.AddRange(new[]
            {
                new ImageComboBoxItem("", 0, 0),
                new ImageComboBoxItem("", 1, 1),
                new ImageComboBoxItem("", 2, 2),
                new ImageComboBoxItem("", 3, 3),
                new ImageComboBoxItem("", 4, 4),
                new ImageComboBoxItem("", 5, 5),
                new ImageComboBoxItem("", 6, 6),
                new ImageComboBoxItem("", 7, 7),
                new ImageComboBoxItem("", 8, 8)
            });

            if (ReadOnly)
            {
                gvSelectedField.OptionsBehavior.Editable = false;
            }
        }

        private void UpdateFieldList()
        {
            //if ((lbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null))
            if ((imlbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null))
            {
                var dvSelectedField = (DataView)gcSelectedField.DataSource;
                //DataView dvAvailableField = (DataView)lbcAvailableField.DataSource;
                var dvAvailableField = (DataView)imlbcAvailableField.DataSource;
                int ind;
                foreach (DataRow r in dvAvailableField.Table.Rows)
                {
                    if (Utils.Str(r["idfsSearchObject"]) == Utils.Str(m_SearchObject))
                    {
                        r["blnAvailable"] = true;
                    }
                }
                for (ind = 0; ind < dvSelectedField.Count; ind++)
                {
                    DataRowView rSelected = dvSelectedField[ind];
                    DataRow rAvailable;
                    if (m_IsFFObject)
                    {
                        string fieldKey = Utils.Str(rSelected["FieldAlias"]);
                        rAvailable = dvAvailableField.Table.Rows.Find(fieldKey);
                    }
                    else
                    {
                        rAvailable = dvAvailableField.Table.Rows.Find(rSelected["idfsSearchField"]);
                    }
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

        private void BindReportType()
        {
            LookupBinder.BindBaseLookup(cbReportType, baseDataSet, QuerySearchObject_DB.TasQuerySearchObject + ".idfsReportType", bv.common.db.BaseReferenceType.rftCaseReportType, false);
        }


        private void BindFilterTree()
        {
            //if (baseDataSet.Tables.Contains(QuerySearchObject_DB.tasQuerySearchField))
            //{
            //    m_FilterControlHelper.Bind(
            //        (long) baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfQuerySearchObject"],
            //        baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].DefaultView,
            //        baseDataSet.Tables[QuerySearchObject_DB.tasQueryConditionGroup].DefaultView);
            //}
            //else
            //{
            //    m_FilterControlHelper.Bind(
            //        (long) baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfQuerySearchObject"], null,
            //        baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].DefaultView);
            //}
            // TODO: check if new filter control shall be binded in two different ways
            qsoFilter.Bind((long)baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["idfQuerySearchObject"], baseDataSet);
        }

        protected override void DefineBinding()
        {
            if ((baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQuerySearchObject)) &&
                (baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows.Count > 0) &&
                (Utils.IsEmpty(baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["idfsSearchObject"]) == false) &&
                (baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["idfsSearchObject"] is long) &&
                ((long)baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["idfsSearchObject"] != -1L))
            {
                m_SearchObject =
                    (long)baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["idfsSearchObject"];
            }

            BindAvailableFieldList();
            BindSelectedFieldList();
            BindFilterTree();
            BindReportType();
        }

        private void QuerySearchObjectInfo_AfterLoadData(object sender, EventArgs e)
        {
            SuspendLayout();
            splitContainerFields.SuspendLayout();
            qsoFilter.SuspendLayout();
            gcSelectedField.SuspendLayout();
            gcSelectedField.BeginUpdate();
            imlbcAvailableField.SuspendLayout();
            imlbcAvailableField.BeginUpdate();
            UpdateQuerySearchObjectID();
            UpdateFieldList();
            UpdateConditionText();
            imlbcAvailableField.EndUpdate();
            imlbcAvailableField.ResumeLayout();
            gcSelectedField.EndUpdate();
            gcSelectedField.ResumeLayout();
            qsoFilter.ResumeLayout();
            splitContainerFields.ResumeLayout();
            ResumeLayout();
        }

        #endregion

        #region Update Methods

        private void UpdateConditionList(object aQuerySearchFieldID)
        {
            if (Utils.IsEmpty(aQuerySearchFieldID))
            {
                return;
            }
            if ((baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQueryConditionGroup)))
            {
                UpdateConditionText();
            }
        }

        /// <summary>
        ///     Updates visibility of Report Type control and location of other controls depending on specified Search Object Id.
        /// </summary>
        /// <param name="searchObjectId">Search Object Identifier to determine state of visibility.</param>
        /// <param name="order">Search Object order in the tree to determine state of visibility.</param>
        private void UpdateVisibilityOfReportTypeBySearchObject
            (
            long searchObjectId,
            int order
            )
        {
            bool isVisible = ((searchObjectId == 10082020) || // Vet Case
                              (searchObjectId == 10082021) || // Vet Case Sample
                              (searchObjectId == 10082022) || // Vet Case Test
                              (searchObjectId == 10082038) // Zoonotic disease
                             ) &&
                             (order == 0);
            if (lblReportType != null)
            {
                lblReportType.Visible = isVisible;
            }
            if (cbReportType != null)
            {
                cbReportType.Visible = isVisible;
            }
            if (isVisible)
            {
                if ((cbReportType.Tag == null) || ((cbReportType.Tag != null) && (cbReportType.Tag.ToString() != "{M}")))
                {
                    cbReportType.Tag = "{M}";
                    SetControlMandatoryState(cbReportType);
                }
                if (lblFilter != null)
                {
                    lblFilter.Top = 30;
                }
                //old filter//if ((QuerySearchFilter != null) && (splitContainerFilters.Panel1 != null))
                //old filter//{
                //old filter//    QuerySearchFilter.Top = 48;
                //old filter//    QuerySearchFilter.Height = splitContainerFilters.Panel1.Height - 48;
                //old filter//}
                if ((qsoFilter != null) && (splitContainerFilters.Panel1 != null))
                {
                    qsoFilter.Top = 48;
                    qsoFilter.Height = splitContainerFilters.Panel1.Height - 48;
                }
            }
            else
            {
                if ((cbReportType.Tag == null) || ((cbReportType.Tag != null) && (!string.IsNullOrWhiteSpace(cbReportType.Tag.ToString()))))
                {
                    cbReportType.Tag = "";
                }
                if (lblFilter != null)
                {
                    lblFilter.Top = 2;
                }
                //old filter//if ((QuerySearchFilter != null) && (splitContainerFilters.Panel1 != null))
                //old filter//{
                //old filter//    QuerySearchFilter.Top = 22;
                //old filter//    QuerySearchFilter.Height = splitContainerFilters.Panel1.Height - 22;
                //old filter//}
                if ((qsoFilter != null) && (splitContainerFilters.Panel1 != null))
                {
                    qsoFilter.Top = 22;
                    qsoFilter.Height = splitContainerFilters.Panel1.Height - 22;
                }
            }
        }


        /// <summary>
        ///     Updates visibility of diagnosis controls and location of other controls depending on specified form type.
        /// </summary>
        /// <param name="formType">Form type to determine state of visibility.</param>
        private void UpdateVisibilityOfDiagnosisByFormType
            (
            long formType
            )
        {
            bool isVisible = (formType == 10034010) || // Human Clinical Signs
                             (formType == 10034011); // Human Epi Investigations
            pnFilterByDiagnosis.Visible = isVisible;
            //bool ret = false;

            //if (lblFilterByDiagnosis != null)
            //{
            //    if (lblFilterByDiagnosis.Visible == isVisible)
            //    {
            //        ret = true;
            //    }
            //    lblFilterByDiagnosis.Visible = isVisible;
            //}
            //if (cbFilterByDiagnosis != null)
            //{
            //    cbFilterByDiagnosis.Visible = isVisible;
            //}
            //if (ret)
            //{
            //    return;
            //}
            //if (isVisible)
            //{
            //    if (splitContainerFields != null)
            //    {
            //        splitContainerFields.Top = 26;
            //        splitContainerFields.Height = navSearchFields.Height - 64;
            //        // Height of Navigator bar is greater that 64. Validaion is not needed.
            //    }
            //}
            //else
            //{
            //    if (splitContainerFields != null)
            //    {
            //        splitContainerFields.Top = 0;
            //        splitContainerFields.Height = navSearchFields.Height - 38;
            //        // Height of Navigator bar is greater that 38. Validaion is not needed.
            //    }
            //}
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
                    //old filter//if (m_FilterControlHelper != null)
                    //old filter//{
                    //old filter//    m_FilterControlHelper.ObjectHACode = m_ObjectHACode;
                    //old filter//}
                    if (qsoFilter != null)
                    {
                        qsoFilter.ObjectHACode = m_ObjectHACode;
                    }
                    return;
                }
            }
            m_ObjectHACode = HACode.None;
            //old filter//if (m_FilterControlHelper != null)
            //old filter//{
            //old filter//    m_FilterControlHelper.ObjectHACode = m_ObjectHACode;
            //old filter//}
            if (qsoFilter != null)
            {
                qsoFilter.ObjectHACode = m_ObjectHACode;
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

            UpdateVisibilityOfReportTypeBySearchObject(m_SearchObject, m_Order);
            UpdateFFType();
            UpdateObjectHACode();

            if ((baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQuerySearchObject)) &&
                (baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows.Count > 0))
            {
                if (Utils.Str(baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["idfsSearchObject"]) !=
                    Utils.Str(m_SearchObject))
                {
                    baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["idfsReportType"] = DBNull.Value;
                    if ((baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQuerySearchField)) &&
                        (baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].Rows.Count > 0))
                    {
                        int ind;
                        for (ind = baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].Rows.Count - 1; ind >= 0; ind--)
                        {
                            if (baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].Rows[ind].RowState != DataRowState.Deleted)
                            {
                                UpdateConditionList(
                                    baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].Rows[ind]["idfQuerySearchField"]);
                                baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].Rows[ind].Delete();
                                //old filter//m_FilterControlHelper.Refresh();
                            }
                        }
                    }
                    UpdateFieldList();
                    if (Utils.IsEmpty(m_SearchObject))
                    {
                        baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["idfsSearchObject"] = DBNull.Value;
                    }
                    else
                    {
                        baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["idfsSearchObject"] = m_SearchObject;
                    }
                    qsoFilter.RefreshNodes();
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

            if ((baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQuerySearchObject)) &&
                (baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows.Count > 0))
            {
                baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["intOrder"] = m_Order;
            }

            UpdateVisibilityOfReportTypeBySearchObject(m_SearchObject, m_Order);
        }

        private string GetConditionText(long aQueryConditionGroupID, bool addOperation)
        {
            if ((baseDataSet == null) || (baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQueryConditionGroup) == false))
            {
                return "";
            }
            DataRow rGroup = baseDataSet.Tables[QuerySearchObject_DB.TasQueryConditionGroup].Rows.Find(aQueryConditionGroupID);
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
            DataRow[] dr =
                baseDataSet.Tables[QuerySearchObject_DB.TasQueryConditionGroup].Select(
                    string.Format("idfParentQueryConditionGroup = {0} ", aQueryConditionGroupID), "intOrder", DataViewRowState.CurrentRows);
            foreach (DataRow r in dr)
            {
                cond = string.Format(cond, GetConditionText((long)r["idfQueryConditionGroup"], true) + "{0}");
            }
            return string.Format(cond, "");
        }

        private void UpdateConditionText()
        {
            if ((baseDataSet == null) || (baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQueryConditionGroup) == false))
            {
                return;
            }
            foreach (DataRow r in baseDataSet.Tables[QuerySearchObject_DB.TasQueryConditionGroup].Rows)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    if (r["idfQueryConditionGroup"] != DBNull.Value)
                        r["SearchFieldConditionText"] = GetConditionText((long)r["idfQueryConditionGroup"], false);
                    else if (r["idfParentQueryConditionGroup"] != DBNull.Value)
                        r["SearchFieldConditionText"] = GetConditionText((long)r["idfParentQueryConditionGroup"], false);
                }
            }
        }

        #endregion

        #region Handlers

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((imlbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null) &&
                (baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQuerySearchField)))
            {
                var dvAvailable = (DataView)imlbcAvailableField.DataSource;

                if ((imlbcAvailableField.SelectedIndices != null) &&
                    (imlbcAvailableField.SelectedIndices.Count >= 0))
                {
                    int i = 0;
                    object[] selectedItems = new object[1];
                    Array.Resize(ref selectedItems, imlbcAvailableField.SelectedIndices.Count);
                    foreach (object it in imlbcAvailableField.SelectedIndices)
                    {
                        selectedItems.SetValue(it, i);
                        i++;
                    }
                    i = 0;
                    foreach (object it in selectedItems)
                    {
                        if ((it == null) || !(it is int))
                        {
                            continue;
                        }

                        int selectedInd = ((int)(it)) - i;

                        if ((selectedInd < 0) || (selectedInd >= dvAvailable.Count))
                        {
                            continue;
                        }

                        DataRow rAvailable = dvAvailable[selectedInd].Row;

                        if (rAvailable == null)
                        {
                            continue;
                        }

                        rAvailable.BeginEdit();
                        rAvailable["blnAvailable"] = false;
                        rAvailable.EndEdit();

                        long querySearchFieldID = -1L;

                        DataRow[] r = baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].Select(
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

                        DataRow rSelected = baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].NewRow();
                        rSelected["idfQuerySearchField"] = querySearchFieldID;
                        rSelected["idfQuerySearchObject"] =
                            baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["idfQuerySearchObject"];
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
                        baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].Rows.Add(rSelected);
                        //m_FilterControlHelper.Refresh();
                        qsoFilter.RefreshNodes();

                        i++;
                    }
                }




                //if ((imlbcAvailableField.SelectedIndex >= 0) &&
                //    (imlbcAvailableField.SelectedIndex < dvAvailable.Count))
                //{
                //    //DataRow rAvailable = dvAvailable[lbcAvailableField.SelectedIndex].Row;
                //    DataRow rAvailable = dvAvailable[imlbcAvailableField.SelectedIndex].Row;
                //    rAvailable.BeginEdit();
                //    rAvailable["blnAvailable"] = false;
                //    rAvailable.EndEdit();

                //    long querySearchFieldID = -1L;

                //    DataRow[] r = baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Select(
                //        string.Format("idfQuerySearchField <= {0}", querySearchFieldID), "idfQuerySearchField");
                //    if (r.Length > 0)
                //    {
                //        if (r[0].RowState != DataRowState.Deleted)
                //        {
                //            querySearchFieldID = (long) (r[0]["idfQuerySearchField"]) - 1;
                //        }
                //        else
                //        {
                //            querySearchFieldID = (long) (r[0]["idfQuerySearchField", DataRowVersion.Original]) - 1;
                //        }
                //    }

                //    DataRow rSelected = baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].NewRow();
                //    rSelected["idfQuerySearchField"] = querySearchFieldID;
                //    rSelected["idfQuerySearchObject"] =
                //        baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfQuerySearchObject"];
                //    rSelected["idfsSearchField"] = rAvailable["idfsSearchField"];
                //    if (m_IsFFObject)
                //    {
                //        rSelected["FieldCaption"] = rAvailable["ParameterName"];
                //        rSelected["blnShow"] = 1;
                //        rSelected["idfsParameter"] = rAvailable["idfsParameter"];
                //        rSelected["FieldAlias"] = rAvailable["FieldAlias"];
                //        rSelected["TypeImageIndex"] = rAvailable["TypeImageIndex"];
                //    }
                //    else
                //    {
                //        rSelected["FieldCaption"] = rAvailable["FieldCaption"];
                //        rSelected["blnShow"] = 1;
                //        rSelected["idfsParameter"] = DBNull.Value;
                //        rSelected["FieldAlias"] = rAvailable["strSearchFieldAlias"];
                //        rSelected["TypeImageIndex"] = rAvailable["TypeImageIndex"];
                //    }
                //    baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows.Add(rSelected);
                //    m_FilterControlHelper.Refresh();
                //    qsoFilter.RefreshNodes();
                //}
            }
        }

        private void imlbcAvailableField_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((!ReadOnly) &&
                (e.Button == MouseButtons.Left) &&
                (imlbcAvailableField.SelectedIndex >= 0) &&
                imlbcAvailableField.GetItemRectangle(imlbcAvailableField.SelectedIndex).Contains(e.Location))
            {
                btnAdd_Click(sender, new EventArgs());
            }
        }

        private void imlbcAvailableField_MouseMove(object sender, MouseEventArgs e)
        {
            var listBoxControl = sender as ImageListBoxControl;
            if (listBoxControl != null)
            {
                int index = listBoxControl.IndexFromPoint(new Point(e.X, e.Y));
                string item = "";
                var point = new Point(e.X, e.Y);
                if ((imlbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null) &&
                    (baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQuerySearchField)))
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
                        point = new Point(
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
                (baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQuerySearchField)))
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
                    ttcAvailableField.ShowHint(item, imlbcAvailableField.PointToScreen(new Point(
                        imlbcAvailableField.Right,
                        imlbcAvailableField.GetItemRectangle(imlbcAvailableField.SelectedIndex).Top)));
                }
                else
                {
                    ttcAvailableField.HideHint();
                }
            }
        }

        private object[] GetSelectedValues(DevExpress.XtraGrid.Views.Grid.GridView view, string fieldName)
        {
            int[] selectedRows = view.GetSelectedRows();
            object[] result = new object[selectedRows.Length];
            for (int i = 0; i < selectedRows.Length; i++)
            {
                int rowHandle = selectedRows[i];
                if (!view.IsGroupRow(rowHandle))
                {
                    result[i] = view.GetRowCellValue(rowHandle, fieldName);
                }
                else
                    result[i] = DBNull.Value; // default value
            }
            return result;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if ((imlbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null) &&
                (baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQuerySearchField)))
            {
                var dvSelected = (DataView)gcSelectedField.DataSource;
                var dvAvailable = (DataView)imlbcAvailableField.DataSource;

                if ((gvSelectedField.FocusedRowHandle >= 0) &&
                    (gvSelectedField.FocusedRowHandle < dvSelected.Count) &&
                    (gvSelectedField.GetSelectedRows() != null) &&
                    (gvSelectedField.GetSelectedRows().Length > 0))
                {
                    object[] selectedItems = GetSelectedValues(gvSelectedField, "idfQuerySearchField");

                    foreach (object it in selectedItems)
                    {
                        if ((it == null) || ((!(it is long)) && (!(it is int))))
                        {
                            continue;
                        }

                        long selectedValue = ((long)(it));

                        DataRow rSelected = baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].Rows.Find(selectedValue);

                        if ((rSelected != null) && (rSelected.RowState != DataRowState.Deleted))
                        {
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
                            //old filter//m_FilterControlHelper.Refresh();
                            qsoFilter.RefreshNodes();
                        }

                    }
                    //DataRow rSelected = baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows.Find(
                    //    gvSelectedField.GetFocusedRowCellValue("idfQuerySearchField"));
                    //if ((rSelected != null) && (rSelected.RowState != DataRowState.Deleted))
                    //{
                    //    //DataView dvAvailable = (DataView)lbcAvailableField.DataSource;
                    //    var dvAvailable = (DataView) imlbcAvailableField.DataSource;
                    //    DataRow rAvailable;
                    //    if (m_IsFFObject)
                    //    {
                    //        string fieldKey = Utils.Str(rSelected["FieldAlias"]);
                    //        rAvailable = dvAvailable.Table.Rows.Find(fieldKey);
                    //    }
                    //    else
                    //    {
                    //        rAvailable = dvAvailable.Table.Rows.Find(rSelected["idfsSearchField"]);
                    //    }
                    //    if (rAvailable != null)
                    //    {
                    //        rAvailable.BeginEdit();
                    //        rAvailable["blnAvailable"] = true;
                    //        rAvailable.EndEdit();
                    //    }

                    //    UpdateConditionList(rSelected["idfQuerySearchField"]);
                    //    rSelected.Delete();
                    //    m_FilterControlHelper.Refresh();
                    //    qsoFilter.RefreshNodes();
                    //}
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
                (baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQuerySearchField)))
            {
                //DataView dvAvailable = (DataView)lbcAvailableField.DataSource;
                var dvAvailable = (DataView)imlbcAvailableField.DataSource;
                long querySearchFieldID = -1L;

                if (dvAvailable.Count > 0)
                {
                    int ind;
                    DataRow[] r = baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].Select(
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
                        DataRow rAvailable = dvAvailable[ind].Row;
                        rAvailable.BeginEdit();
                        rAvailable["blnAvailable"] = false;
                        rAvailable.EndEdit();

                        DataRow rSelected = baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].NewRow();
                        rSelected["idfQuerySearchField"] = querySearchFieldID;
                        rSelected["idfQuerySearchObject"] =
                            baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["idfQuerySearchObject"];
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
                        baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].Rows.Add(rSelected);

                        querySearchFieldID = querySearchFieldID - 1;
                    }
                    //old filter//m_FilterControlHelper.Refresh();
                    qsoFilter.RefreshNodes();
                }
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            //if ((lbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null) &&
            if ((imlbcAvailableField.DataSource != null) && (gcSelectedField.DataSource != null) &&
                (baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQuerySearchField)))
            {
                for (int ind = baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].Rows.Count - 1; ind >= 0; ind--)
                {
                    DataRow rSelected = baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].Rows[ind];
                    if (rSelected.RowState != DataRowState.Deleted)
                    {
                        //DataView dvAvailable = (DataView)lbcAvailableField.DataSource;
                        var dvAvailable = (DataView)imlbcAvailableField.DataSource;
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
                    }
                }
                //old filter//m_FilterControlHelper.Refresh();
                qsoFilter.RefreshNodes();
            }
        }

        private void cbFilterByDiagnosis_EditValueChanged(object sender, EventArgs e)
        {
            if ((m_FormType != 10034010) && //Human Clinical Signs
                (m_FormType != 10034011)) //Human Epi Investigations
            {
                return;
            }
            if (imlbcAvailableField.DataSource == null)
            {
                return;
            }

            string filterByDiagnosis = " and DiagnosisString like '{0}'";
            filterByDiagnosis = string.Format(filterByDiagnosis, Utils.IsEmpty(cbFilterByDiagnosis.EditValue)
                ? "%"
                : string.Format("%{0};%", Utils.Str(cbFilterByDiagnosis.EditValue)));

            var dv = (DataView)imlbcAvailableField.DataSource;
            dv.RowFilter = string.Format("idfsSearchObject = '{0}' and blnAvailable = 1 {1}", m_SearchObject, filterByDiagnosis);
        }

        #endregion

        #region Special Methods

        private void DisplayFilter(object sender, FilterChangedEventArgs e)
        {
            //old filter//txtFilterText.Lines = m_FilterControlHelper.FilterLines;
            txtFilterText.Lines = qsoFilter.FilterLines;
        }

        //public void SaveQuerySearchObjectInfo()
        //{
        //    if (baseDataSet == null)
        //    {
        //        m_DataSet = null;
        //        return;
        //    }
        //    m_DataSet = baseDataSet.Copy();
        //}

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

        //public void RestoreQuerySearchObjectInfo(long qsoID)
        //{
        //    if (m_DataSet == null)
        //    {
        //        return;
        //    }
        //    object id = qsoID;
        //    LoadData(ref id);
        //    foreach (DataTable dt in baseDataSet.Tables)
        //    {
        //        dt.Rows.Clear();
        //    }
        //    baseDataSet.Merge(m_DataSet);
        //    baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchObject].Rows[0]["idfQuerySearchObject"] = QuerySearchObjectDbService.ID;

        //    long fieldID = -1L;
        //    var fieldList = new long[baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows.Count];
        //    foreach (DataRow rField in baseDataSet.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows)
        //    {
        //        if (rField.RowState != DataRowState.Deleted)
        //        {
        //            fieldList[-fieldID - 1] = (long)rField["idfnQuerySearchField"];
        //            rField["idfQuerySearchField"] = fieldID;
        //            rField["idfQuerySearchObject"] = QuerySearchObjectDbService.ID;
        //            fieldID = fieldID - 1;
        //        }
        //    }

        //    long groupID = -1L;
        //    var groupList = new long[baseDataSet.Tables[QuerySearchObject_DB.tasQueryConditionGroup].Rows.Count];
        //    foreach (DataRow rGroup in baseDataSet.Tables[QuerySearchObject_DB.tasQueryConditionGroup].Rows)
        //    {
        //        if (rGroup.RowState != DataRowState.Deleted)
        //        {
        //            rGroup["idfQueryConditionGroup"] = groupID;
        //            rGroup["idfQuerySearchObject"] = QuerySearchObjectDbService.ID;
        //            groupID = groupID - 1;
        //        }
        //    }
        //    foreach (DataRow rGroup in baseDataSet.Tables[QuerySearchObject_DB.tasQueryConditionGroup].Rows)
        //    {
        //        if (rGroup.RowState != DataRowState.Deleted)
        //        {
        //            if (Utils.IsEmpty(rGroup["idfParentQueryConditionGroup"]) == false)
        //            {
        //                long groupIDNew = GetNewNegativeID(groupList, (long)rGroup["idfParentQueryConditionGroup"]);
        //                rGroup["idfParentQueryConditionGroup"] = groupIDNew;
        //            }
        //        }
        //    }

        //    DefineBinding();
        //    AfterLoad();
        //    m_DataSet = null;
        //}

        public void Copy(long qsoID, long queryID)
        {
            var mainQsoIdEx = (long)QuerySearchObjectDbService.ID;

            QuerySearchObjectDbService.Copy(baseDataSet, qsoID, queryID);

            long fieldId = -1L;
            var fieldList = new long[baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].Rows.Count];
            foreach (DataRow rField in baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField].Rows)
            {
                if (rField.RowState != DataRowState.Deleted)
                {
                    fieldList[(int)(-fieldId - 1)] = (long)rField["idfQuerySearchField"];
                    rField["idfQuerySearchField"] = fieldId;
                    rField["idfQuerySearchObject"] = QuerySearchObjectDbService.ID;
                    fieldId = fieldId - 1;
                }
            }

            long subqueryId = -1L;
            var subQueryList = new long[baseDataSet.Tables[QuerySearchObject_DB.TasSubquery].Rows.Count];
            foreach (DataRow rSubQuery in baseDataSet.Tables[QuerySearchObject_DB.TasSubquery].Rows)
            {
                if (rSubQuery.RowState != DataRowState.Deleted)
                {
                    subQueryList[(int)(-subqueryId - 1)] = (long)rSubQuery["idfQuerySearchObject"];
                    rSubQuery["idflQuery"] = subqueryId;
                    rSubQuery["idfQuerySearchObject"] = subqueryId - 10000;
                    subqueryId = subqueryId - 1;
                }
            }

            fieldId = -1L;
            var subQueryFieldList = new long[baseDataSet.Tables[QuerySearchObject_DB.TasSubquerySearchField].Rows.Count];
            foreach (DataRow rSubQueryField in baseDataSet.Tables[QuerySearchObject_DB.TasSubquerySearchField].Rows)
            {
                if (rSubQueryField.RowState != DataRowState.Deleted)
                {
                    subQueryFieldList[(int)(-fieldId - 1)] = (long)rSubQueryField["idfQuerySearchField"];
                    rSubQueryField["idfQuerySearchField"] = fieldId - 100000;
                    rSubQueryField["idfQuerySearchObject"] = GetNewNegativeID(subQueryList, (long)rSubQueryField["idfQuerySearchObject"]) - 10000;
                    fieldId = fieldId - 1;
                }
            }


            long groupId = 0;
            var groupList = new long[baseDataSet.Tables[QuerySearchObject_DB.TasQueryConditionGroup].Rows.Count];
            long lastGroupId = 0;
            foreach (DataRow rGroup in baseDataSet.Tables[QuerySearchObject_DB.TasQueryConditionGroup].Rows)
            {
                if (rGroup.RowState != DataRowState.Deleted)
                {
                    if (Utils.IsEmpty(rGroup["idfQueryConditionGroup"]) == false)
                    {
                        var groupIdEx = (long)rGroup["idfQueryConditionGroup"];
                        if (groupIdEx != lastGroupId)
                        {
                            groupId = groupId - 1;
                            lastGroupId = groupIdEx;
                            groupList[(int)(-groupId - 1)] = groupIdEx;
                        }
                        rGroup["idfQueryConditionGroup"] = groupId;
                    }
                    if (Utils.IsEmpty(rGroup["idfSubQuerySearchObject"]) == false)
                    {
                        rGroup["idfSubQuerySearchObject"] = GetNewNegativeID(subQueryList, (long)rGroup["idfSubQuerySearchObject"]) - 10000;
                    }
                    if (Utils.IsEmpty(rGroup["idfQuerySearchObject"]) == true)
                        continue;
                    var groupQsoIdEx = (long)rGroup["idfQuerySearchObject"];
                    if (groupQsoIdEx == mainQsoIdEx)
                    {
                        rGroup["idfQuerySearchObject"] = QuerySearchObjectDbService.ID;
                        if (Utils.IsEmpty(rGroup["idfQuerySearchField"]) == false)
                        {
                            rGroup["idfQuerySearchField"] = GetNewNegativeID(fieldList, (long)rGroup["idfQuerySearchField"]);
                        }
                    }
                    else
                    {
                        rGroup["idfQuerySearchObject"] = GetNewNegativeID(subQueryList, groupQsoIdEx) - 10000;
                        if (Utils.IsEmpty(rGroup["idfQuerySearchField"]) == false)
                        {
                            rGroup["idfQuerySearchField"] = GetNewNegativeID(subQueryFieldList, (long)rGroup["idfQuerySearchField"]) - 100000;
                        }
                    }
                }
            }

            foreach (DataRow rGroup in baseDataSet.Tables[QuerySearchObject_DB.TasQueryConditionGroup].Rows)
            {
                if (rGroup.RowState != DataRowState.Deleted)
                {
                    if (Utils.IsEmpty(rGroup["idfParentQueryConditionGroup"]) == false)
                    {
                        long groupIdNew = GetNewNegativeID(groupList, (long)rGroup["idfParentQueryConditionGroup"]);
                        rGroup["idfParentQueryConditionGroup"] = groupIdNew;
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
            if ((baseDataSet == null) || (baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQuerySearchObject) == false))
            {
                return true;
            }
            var dvField = new DataView(baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField], "", "", DataViewRowState.CurrentRows);
            if (dvField.Count == 0)
            {
                return false;
            }
            //return m_FilterControlHelper.Validate();
            return qsoFilter.Validate(true);
        }

        public void ShowQSOInfoError()
        {
            var dvField = new DataView(baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField], "", "", DataViewRowState.CurrentRows);
            if (dvField.Count == 0)
            {
                MessageForm.Show(EidssMessages.Get("msgNoSearchField",
                    "No fields are selected. Remove this search object or select some available fields."));
            }
        }

        #endregion

        #region Post Methods

        public override bool HasChanges()
        {
            //old filter//return m_FilterControlHelper.HasChanges || base.HasChanges();
            return qsoFilter.HasChanges || base.HasChanges();
        }

        private void QuerySearchObjectInfo_OnAfterPost(object sender, EventArgs e)
        {
            if ((baseDataSet == null) ||
                (baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQueryConditionGroup) == false))
            {
                return;
            }
            baseDataSet.AcceptChanges();
            //old filter//m_FilterControlHelper.UpdateFieldInfo();
            //old filter//m_FilterControlHelper.HasChanges = false;
            qsoFilter.UpdateFieldInfo();
            qsoFilter.HasChanges = false;
        }

        private void QuerySearchObjectInfo_OnBeforePost(object sender, EventArgs e)
        {
            //m_FilterControlHelper.Flush(null, 0);
            qsoFilter.Flush();
        }

        #endregion

        #region Get Functions

        internal DataView GetQuerySearchFieldView()
        {
            DataView dvField = null;
            if ((baseDataSet != null) && baseDataSet.Tables.Contains(QuerySearchObject_DB.TasQuerySearchField))
            {
                dvField = new DataView(
                    baseDataSet.Tables[QuerySearchObject_DB.TasQuerySearchField],
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

        private void QuerySearchObjectInfo_Load(object sender, EventArgs e)
        {
            if (Localizer.IsRtl)
            {
                splitContainerFields.SplitterPosition = m_SavedSplitPosition;
            }
        }
    }
}