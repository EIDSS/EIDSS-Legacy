using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using DevExpress.XtraGrid.Columns;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Helpers;

namespace eidss.winclient.AggregateCase
{
    public partial class AggregateSummaryHeader : UserControl
    {
        private int m_ColIndex;
        private readonly ActionLocker m_ActionLocker = new ActionLocker();
        public AggregateSummaryHeader()
        {
            InitializeComponent();
            m_ColIndex = 0;
            AddColumn("strCaseID", "strCaseID");
            AddColumn("datStartDate", "datStartDate");
            AddColumn("strPeriodName", "idfsPeriodType");
            AddColumn("strRegion", "idfsRegion");
            AddColumn("strRayon", "idfsRayon");
            AddColumn("strSettlement", "strSettlement");

            if (WinUtils.IsComponentInDesignMode(this))
                return;
            var accessor = (IObjectCreator)ObjectAccessor.AccessorInterface(typeof(HumanAggregateCaseListItem));
            using (DbManagerProxy managerProxy = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var obj = (HumanAggregateCaseListItem)accessor.CreateNew(managerProxy, null, null);
                var areaType = obj.StatisticAreaTypeLookup;
                var periodType = obj.StatisticPeriodTypeLookup;
                LookupBinder.BindBaseLookup(cbTimeInterval, obj, null, periodType, false, false);
                LookupBinder.BindBaseLookup(cbAdminLevel, obj, null, areaType, false, false);
            }
            UpdateButtonsState();
        }

        private void AddColumn(string fieldName, string captionId)
        {
            string caption = WinClientContext.FieldCaptions != null ? WinClientContext.FieldCaptions.GetString(captionId, captionId) : captionId;
            var column = new GridColumn
                             {
                                 Caption = caption,
                                 FieldName = fieldName,
                                 Name = fieldName,
                                 Visible = true,
                                 VisibleIndex = m_ColIndex++
                             };
            CaseView.Columns.Add(column);

        }
        private AggregateCaseType m_CaseType = AggregateCaseType.None;
        public AggregateCaseType CaseType
        {
            get
            {
                return m_CaseType;
            }
            set
            {
                m_CaseType = value;
                NewButton.Visible = EidssUserContext.User.HasPermission(GetInsertPermission());
                SelectedCasesGroup.Text = (m_CaseType == AggregateCaseType.VetAggregateAction) ? EidssMessages.Get("strSelectedAggregateActions") : EidssMessages.Get("strSelectedAggregateCases");
                CaseView.Columns["strCaseID"].Caption = (m_CaseType == AggregateCaseType.VetAggregateAction) ? EidssFields.Get("strActionID", "Action ID") : EidssFields.Get("strCaseID", "Case ID");
            }
        }

        private StatisticPeriodType CurrentPeriodType
        {
            get { return (CaseView.RowCount > 0) ? (StatisticPeriodType)((IObject)CaseView.GetRow(0)).GetValue("idfsPeriodType") : StatisticPeriodType.None; }
        }
        private StatisticAreaType CurrentAreaType
        {
            get { return (CaseView.RowCount > 0) ? (StatisticAreaType)((IObject)CaseView.GetRow(0)).GetValue("idfsAreaType") : StatisticAreaType.None; }
        }

        private StatisticPeriodType ReportPeriodType
        {
            get { return (Utils.IsEmpty(cbTimeInterval.EditValue)) ? StatisticPeriodType.None : (StatisticPeriodType)((BaseReference)cbTimeInterval.EditValue).idfsBaseReference; }
        }
        private StatisticAreaType ReportAreaType
        {
            get { return (Utils.IsEmpty(cbAdminLevel.EditValue)) ? StatisticAreaType.None : (StatisticAreaType)((BaseReference)cbAdminLevel.EditValue).idfsBaseReference; }
        }


        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (m_ActionLocker.Lock())
            {
                try
                {
                    IList<IObject> selection;
                    var startupParams = new Dictionary<string, object>();
                    if (CaseView.RowCount > 0)
                    {
                        startupParams.Add("PeriodType", (long)CurrentPeriodType);
                        startupParams.Add("AreaType", (long)CurrentAreaType);
                    }
                    startupParams.Add("ReportPeriodType", (long)ReportPeriodType);
                    startupParams.Add("ReportAreaType", (long)ReportAreaType);
                    switch (CaseType)
                    {
                        case AggregateCaseType.HumanAggregateCase:
                            selection = BaseFormManager.ShowForMultiSelection(new HumanAggregateCaseList(), FindForm(), startupParams);
                            break;
                        case AggregateCaseType.VetAggregateCase:
                            selection = BaseFormManager.ShowForMultiSelection(new VetAggregateCaseList(), FindForm(), startupParams);
                            break;
                        case AggregateCaseType.VetAggregateAction:
                            selection = BaseFormManager.ShowForMultiSelection(new VetAggregateActionList(), FindForm(), startupParams);
                            break;
                        default:
                            selection = null;
                            break;
                    }
                    MergeSelection(selection);
                }
                finally
                {
                    m_ActionLocker.Unlock();
                }
            }
        }

        private void MergeSelection(IEnumerable<IObject> selection)
        {
            if (selection != null)
            {
                switch (CaseType)
                {
                    case AggregateCaseType.HumanAggregateCase:
                        Merge<HumanAggregateCaseListItem>(selection);
                        break;
                    case AggregateCaseType.VetAggregateCase:
                        Merge<VetAggregateCaseListItem>(selection);
                        break;
                    case AggregateCaseType.VetAggregateAction:
                        Merge<VetAggregateActionListItem>(selection);
                        break;
                    default:
                        CaseGrid.DataSource = null;
                        break;
                }
            }
        }
        private void Merge<T>(IEnumerable<IObject> selection) where T : class, IObject
        {
            var currentCases = (IList<T>)CaseGrid.DataSource;
            if (currentCases != null && currentCases.Count > 0)
            {
                var selectedCases = selection.Cast<T>().ToList();
                var union = selectedCases.Union(currentCases, new ObjectComparer());
                CaseGrid.DataSource = union.Cast<T>().ToList();
            }
            else
                CaseGrid.DataSource = selection.Cast<T>().ToList();
        }

        public List<long> GetObservarionsList(string observationFieldName)
        {
            if (CaseGrid.DataSource != null)
            {
                var observations = (from object bo in CaseGrid.DataSource as IEnumerable
                                    select (long)((IObject)bo).GetValue(observationFieldName)).ToList();
                return observations.Count > 0 ? observations : null;
            }
            return null;
        }

        private string GetDetailFormName()
        {
            switch (CaseType)
            {
                case AggregateCaseType.HumanAggregateCase:
                    return "AggregateCaseDetail";
                case AggregateCaseType.VetAggregateCase:
                    return "VetAggregateCaseDetail";
                case AggregateCaseType.VetAggregateAction:
                    return "VetAggregateActionDetail";
                default:
                    return null;
            }

        }

        private IList<IObject> GetCreatedAggregateEntry(object id)
        {
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                IObjectSelectList accessor = null;
                var filter = new FilterParams();
                filter.Add("idfAggrCase", "=", id);
                switch (CaseType)
                {
                    case AggregateCaseType.HumanAggregateCase:
                        accessor = ObjectAccessor.SelectListInterface(typeof(HumanAggregateCaseListItem));
                        break;
                    case AggregateCaseType.VetAggregateCase:
                        accessor = ObjectAccessor.SelectListInterface(typeof(VetAggregateCaseListItem));
                        break;
                    case AggregateCaseType.VetAggregateAction:
                        accessor = ObjectAccessor.SelectListInterface(typeof(VetAggregateActionListItem));
                        break;
                }
                if (accessor != null)
                {
                    return accessor.SelectList(manager, filter);
                }

            }
            return null;

        }

        private object FocusedKey
        {
            get
            {
                int focusedRowHandle = CaseView.FocusedRowHandle < 0 ? 0 : CaseView.FocusedRowHandle;
                int focusedIndex = CaseView.GetDataSourceRowIndex(focusedRowHandle);
                if (CaseGrid.DataSource != null && focusedIndex < ((IList)CaseGrid.DataSource).Count)
                {
                    return ((IObject)((IList)CaseGrid.DataSource)[focusedIndex]).Key;
                }

                return null;
            }
        }
        private void NewButton_Click(object sender, EventArgs e)
        {
            if (m_ActionLocker.Lock())
            {
                try
                {
                    object form = ClassLoader.LoadClass(GetDetailFormName());
                    object id = null;
                    if (form != null)
                    {
                        if (BaseFormManager.ShowModal(form as IApplicationForm, FindForm(), ref id, null, null))
                        {
                            var selection = GetCreatedAggregateEntry(id);
                            if (AggregateHelper.ValidateSelection(selection, (long)CurrentPeriodType, (long)CurrentAreaType, (long)ReportPeriodType, (long)ReportAreaType))
                                MergeSelection(selection);
                        }
                    }
                }
                finally
                {
                    m_ActionLocker.Unlock();
                }
            }


        }

        private string GetInsertPermission()
        {
            switch (CaseType)
            {
                case AggregateCaseType.HumanAggregateCase:
                    return PermissionHelper.InsertPermission(EIDSSPermissionObject.HumanCase);
                case AggregateCaseType.VetAggregateCase:
                case AggregateCaseType.VetAggregateAction:
                    return PermissionHelper.InsertPermission(EIDSSPermissionObject.VetCase);
                default:
                    return "";
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (m_ActionLocker.Lock())
            {
                try
                {
                    if (CaseView.RowCount > 0 && CaseView.FocusedRowHandle < 0)
                        return;
                    object form = ClassLoader.LoadClass(GetDetailFormName());
                    object key = FocusedKey;
                    if (form != null && key != null && BaseFormManager.ShowModal(form as IApplicationForm, FindForm(), ref key, null, null))
                    {
                        var selection = GetCreatedAggregateEntry(key);
                        if (AggregateHelper.ValidateSelection(selection, (long)CurrentPeriodType, (long)CurrentAreaType, (long)ReportPeriodType, (long)ReportAreaType))
                            MergeSelection(selection);
                    }
                }
                finally
                {
                    m_ActionLocker.Unlock();
                }
            }


        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (m_ActionLocker.Lock())
            {
                try
                {
                    if (CaseView.SelectedRowsCount > 0)
                        CaseView.DeleteSelectedRows();
                    else if (CaseView.RowCount > 0 && CaseView.FocusedRowHandle >= 0)
                        CaseView.DeleteRow(CaseView.FocusedRowHandle);
                }
                finally
                {
                    m_ActionLocker.Unlock();
                }
            }

        }

        private void RemoveAllButton_Click(object sender, EventArgs e)
        {
            if (m_ActionLocker.Lock())
            {
                try
                {
                    CaseGrid.DataSource = null;
                    UpdateButtonsState();
                }
                finally
                {
                    m_ActionLocker.Unlock();
                }
            }

        }


        private void CaseView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            UpdateButtonsState();
        }

        private void CaseView_RowCountChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            RemoveButton.Enabled = CaseView.RowCount > 0 && CaseView.FocusedRowHandle >= 0;
            EditButton.Enabled = CaseView.RowCount > 0 && CaseView.FocusedRowHandle >= 0 && CaseView.SelectedRowsCount <= 1;
            RemoveAllButton.Enabled = CaseView.RowCount > 0;
            SelectButton.Enabled = !Utils.IsEmpty(cbAdminLevel.EditValue) && !Utils.IsEmpty(cbTimeInterval.EditValue);
        }
        public bool EnableReports
        {
            get { return CaseView.RowCount > 0; }
        }

        private void cbAdminLevel_EditValueChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void cbTimeInterval_EditValueChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void cbTimeInterval_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            e.Cancel = !IsValidTimeInterval(((BaseReference)e.NewValue).idfsBaseReference);
        }

        private bool IsValidTimeInterval(object ti)
        {
            if (Utils.IsEmpty(ti))
                return false;
            if (CaseView.RowCount <= 0)
                return true;
            return AggregateHelper.ValidatePeriodType(CurrentPeriodType, (StatisticPeriodType)ti);
        }


        private void cbAdminLevel_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            e.Cancel = !IsValidAdminLevel(CurrentAreaType, ((BaseReference)e.NewValue).idfsBaseReference);
        }

        private bool IsValidAdminLevel(object areaType, object reportAreaType)
        {
            if (Utils.IsEmpty(areaType))
                return false;
            if (CaseView.RowCount <= 0)
                return true;
            return AggregateHelper.ValidateAreaType((StatisticAreaType)areaType, (StatisticAreaType)reportAreaType);
        }
        #region Parameters XML support
        private string GetAdminUnit(IObject bo)
        {
            switch (ReportAreaType)
            {
                case StatisticAreaType.Country:
                    return Utils.Str(bo.GetValue("idfsCountry") ?? 0);
                case StatisticAreaType.Rayon:
                    return Utils.Str(bo.GetValue("idfsRayon") ?? 0);
                case StatisticAreaType.Region:
                    return Utils.Str(bo.GetValue("idfsRegion") ?? 0);
                case StatisticAreaType.Settlement:
                    return Utils.Str(bo.GetValue("idfsSettlement") ?? 0);
                default:
                    return "0";
            }

        }
        public string GetCurrentParametersXML()
        {

            if (!Utils.IsEmpty(cbAdminLevel.EditValue) && !Utils.IsEmpty(cbTimeInterval.EditValue) && CaseView.RowCount > 0)
            {

                XmlNode adminNode = null;
                XmlNode timeIntervalNode = null;
                XmlDocument xmlDoc = InitXml(ReportAreaType.ToString(), ReportPeriodType.ToString(), ref adminNode, ref timeIntervalNode);
                IEnumerable<IObject> areas = ((IEnumerable<IObject>)CaseView.DataSource).Distinct(new AreaComparer(ReportAreaType));
                foreach (IObject area in areas)
                {
                    AddAdminUnitNode(xmlDoc, adminNode, GetAdminUnit(area));
                }
                IEnumerable<IObject> periods = ((IEnumerable<IObject>)CaseView.DataSource).Distinct(new PeriodComparer());
                foreach (IObject period in periods)
                {
                    AddTimeIntervalUnitNode(xmlDoc, timeIntervalNode, Convert.ToDateTime(period.GetValue("datStartDate")), Convert.ToDateTime(period.GetValue("datFinishDate")));
                }
                var sb = new System.Text.StringBuilder();
                var sw = new System.IO.StringWriter(sb);
                var xmlW = new XmlTextWriter(sw);
                xmlDoc.WriteTo(xmlW);
                xmlW.Close();
                sw.Close();
                var aggrXml = sb.ToString();
                return aggrXml;
            }

            return null;
        }
        private XmlDocument InitXml(string areaType, string periodType, ref XmlNode adminNode, ref XmlNode timeIntervalNode)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<?xml version=\"1.0\" encoding =\"UTF-16\"?><ROOT/>");

            XmlNode root = xmlDoc.DocumentElement;

            if (root != null)
            {
                adminNode = xmlDoc.CreateNode(XmlNodeType.Element, "AdminLevel", root.NamespaceURI);

                var attrAreaType = xmlDoc.CreateAttribute("AreaType");
                attrAreaType.Value = Utils.Str(areaType);
                if (adminNode.Attributes != null)
                {
                    adminNode.Attributes.Append(attrAreaType);
                }

                root.AppendChild(adminNode);

                timeIntervalNode = xmlDoc.CreateNode(XmlNodeType.Element, "TimeInterval", root.NamespaceURI);

                var attrPeriodType = xmlDoc.CreateAttribute("PeriodType");
                attrPeriodType.Value = Utils.Str(periodType);
                if (timeIntervalNode.Attributes != null)
                {
                    timeIntervalNode.Attributes.Append(attrPeriodType);
                }
                root.AppendChild(timeIntervalNode);
            }
            return xmlDoc;
        }

        private void AddAdminUnitNode(XmlDocument xmlDoc, XmlNode adminNode, string adminUnitID)
        {
            var adminUnitNode = xmlDoc.CreateNode(XmlNodeType.Element, "AdminUnit", adminNode.NamespaceURI);
            Debug.Assert(adminUnitNode.Attributes != null, "adminUnitNode.Attributes != null");
            var attrAuid = xmlDoc.CreateAttribute("AdminUnitID");
            attrAuid.Value = Utils.Str(adminUnitID);
            adminUnitNode.Attributes.Append(attrAuid);
            adminNode.AppendChild(adminUnitNode);
        }

        private void AddTimeIntervalUnitNode(XmlDocument xmlDoc, XmlNode timeIntervalNode, DateTime startDate, DateTime finishDate)
        {
            var timeIntervalUnitNode = xmlDoc.CreateNode(XmlNodeType.Element, "TimeIntervalUnit", timeIntervalNode.NamespaceURI);

            var attrSd = xmlDoc.CreateAttribute("StartDate");
            attrSd.Value = startDate.ToString("yyyy-MM-dd");
            Debug.Assert(timeIntervalUnitNode.Attributes != null, "timeIntervalUnitNode.Attributes != null");
            timeIntervalUnitNode.Attributes.Append(attrSd);

            var attrFd = xmlDoc.CreateAttribute("FinishDate");
            attrFd.Value = finishDate.ToString("yyyy-MM-dd");
            timeIntervalUnitNode.Attributes.Append(attrFd);

            timeIntervalNode.AppendChild(timeIntervalUnitNode);
        }

        #endregion


    }

}


