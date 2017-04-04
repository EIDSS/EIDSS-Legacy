using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors.Controls;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class BorderRayonsComparativeReportKeeper : BaseReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (BorderRayonsComparativeReportKeeper));
        private List<ItemWrapper> m_MonthCollection;
        private List<ItemWrapper> m_CounterCollection;
        private string[] m_Diagnosis = new string[0];

        public string[] m_CheckedCounters = new string[0];

        public BorderRayonsComparativeReportKeeper()
            : base(new Dictionary<string, string>())
        {
            ReportType = typeof (BorderRayonsComparativeAZReport);
            InitializeComponent();
            SetMandatory();

            YearSpinEdit.Properties.MaxValue = DateTime.Now.Year;
            YearSpinEdit.Value = DateTime.Now.Year;

            BindLookup(StartMonthLookUp, MonthCollection, StartMonthLabel.Text);
            BindLookup(EndMonthLookUp, MonthCollection, EndMonthLabel.Text);

            StartMonthLookUp.EditValue = MonthCollection[DateTime.Now.Month - 1];
            EndMonthLookUp.EditValue = MonthCollection[DateTime.Now.Month - 1];

            CounterFilter.SelectAllItemVisible = false;

            m_HasLoad = true;
        }

        #region Properties

        [Browsable(false)]
        protected int YearParam
        {
            get { return (int) YearSpinEdit.Value; }
        }

        [Browsable(false)]
        protected int? StartMonthParam
        {
            get
            {
                return (StartMonthLookUp.EditValue == null)
                    ? (int?) null
                    : ((ItemWrapper) StartMonthLookUp.EditValue).Number;
            }
        }

        [Browsable(false)]
        protected int? EndMonthParam
        {
            get
            {
                return (EndMonthLookUp.EditValue == null)
                    ? (int?) null
                    : ((ItemWrapper) EndMonthLookUp.EditValue).Number;
            }
        }

        [Browsable(false)]
        protected long? RegionIdParam
        {
            get { return RegionFilter.RegionId > 0 ? (long?) RegionFilter.RegionId : null; }
        }

        [Browsable(false)]
        protected long? RayonIdParam
        {
            get { return RayonFilter.RayonId > 0 ? (long?) RayonFilter.RayonId : null; }
        }

        protected List<ItemWrapper> MonthCollection
        {
            get { return m_MonthCollection ?? (m_MonthCollection = FilterHelper.GetWinMonthList()); }
        }

        protected List<ItemWrapper> CounterCollection
        {
            get { return m_CounterCollection ?? (m_CounterCollection = FilterHelper.GetWinCounterList()); }
        }

        #endregion

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            var model = new BorderRayonsSurrogateModel(CurrentCulture.ShortName,
                YearParam, StartMonthParam, EndMonthParam,
                RegionIdParam, RayonIdParam,
                RegionFilter.SelectedText, RayonFilter.SelectedText,
                m_Diagnosis, m_CheckedCounters,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);
            var reportAz = (BorderRayonsComparativeAZReport) CreateReportObject();
            reportAz.SetParameters(model, manager, archiveManager);
            return reportAz;
        }

        protected override bool CheckBusinessRules(bool printException)
        {
            if (m_Diagnosis.Length > 12)
            {
                const string defaultFormat =
                    "Too many diagnoses are selected for displaying in the report. The number of selected diagnoses shall not exceed twelve. Please clear some diagnoses and try to generate the report again.";
                ErrorForm.ShowWarning("msgTooManyDiagnosis12", defaultFormat);
                return false;
            }
            return true;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            m_MonthCollection = null;
            m_CounterCollection = null;
            base.ApplyResources(manager);

            m_Resources.ApplyResources(StartYearLabel, "StartYearLabel");
            m_Resources.ApplyResources(StartMonthLabel, "StartMonthLabel");
            m_Resources.ApplyResources(EndMonthLabel, "EndMonthLabel");

            ApplyLookupResources(StartMonthLookUp, MonthCollection, StartMonthParam, StartMonthLabel.Text);
            ApplyLookupResources(EndMonthLookUp, MonthCollection, EndMonthParam, EndMonthLabel.Text);

            CounterFilter.DefineBinding();

            diagnosisFilter.DefineBinding();
            RegionFilter.DefineBinding();
            RayonFilter.DefineBinding();
            if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
            {
                LocationHelper.SetDefaultFilters(manager, ContextKeeper, RegionFilter, RayonFilter);
                CounterFilter.SetCounter(1);
            }
        }

        private void SetMandatory()
        {
            LayoutCorrector.SetStyleController(YearSpinEdit, LayoutCorrector.MandatoryStyleController);

            CounterFilter.SetMandatory();
            RegionFilter.SetMandatory();
            RayonFilter.SetMandatory();
        }

        private void StartMonth_EditValueChanged(object sender, EventArgs e)
        {
            CorrectLookupRange(StartMonthLookUp, EndMonthLookUp, MonthLookupEnum.Start);
        }

        private void EndMonth_EditValueChanged(object sender, EventArgs e)
        {
            CorrectLookupRange(StartMonthLookUp, EndMonthLookUp, MonthLookupEnum.End);
        }

        private void Month_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ClearLookUpButtonClick(sender, e, StartMonthLookUp, EndMonthLookUp);
        }

        private void Region_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RegionFilterValueChanged(RegionFilter, RayonFilter, e);
            }
        }

        private void Rayon_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFilterResetting))
            {
                return;
            }
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RayonFilterValueChanged(RegionFilter, RayonFilter, e);
            }
        }

        private void Diagnosis_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_Diagnosis = e.KeyArray;
        }

        private void CounterFilter_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }

        private void CounterFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_CheckedCounters = e.KeyArray;
        }
    }
}