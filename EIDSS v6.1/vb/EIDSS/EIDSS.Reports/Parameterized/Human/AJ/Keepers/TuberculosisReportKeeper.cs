using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.Core;
using DevExpress.XtraEditors.Controls;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class TuberculosisComparativeReportKeeper : BaseReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (TuberculosisComparativeReportKeeper));
        private List<ItemWrapper> m_MonthCollection;

        private string[] m_Years = new string[0];

        public TuberculosisComparativeReportKeeper()
            : base(new Dictionary<string, string>())
        {
            ReportType = typeof (TuberculosisCasesTestedReport);
            InitializeComponent();
            SetMandatory();

            BindLookup(StartMonthLookUp, MonthCollection, StartMonthLabel.Text);
            BindLookup(EndMonthLookUp, MonthCollection, EndMonthLabel.Text);

            StartMonthLookUp.EditValue = MonthCollection[DateTime.Now.Month - 1];
            EndMonthLookUp.EditValue = MonthCollection[DateTime.Now.Month - 1];

            m_HasLoad = true;
        }

        #region Properties

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
        private long? DiagnosisIdParam
        {
            get { return DiagnosisFilter.EditValueId > 0 ? (long?) DiagnosisFilter.EditValueId : null; }
        }

        protected List<ItemWrapper> MonthCollection
        {
            get { return m_MonthCollection ?? (m_MonthCollection = FilterHelper.GetWinMonthList()); }
        }

        protected int MaxCount
        {
            get { return TuberculosisSurrogateModel.MaxYearsCount; }
        }

        #endregion

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            if (m_Years.Length > TuberculosisSurrogateModel.MaxYearsCount)
            {
                const string defaultFormat = "Only {0} selected years will be represented in the report.";
                ErrorForm.ShowWarningFormat("msgTooManyYears", defaultFormat, MaxCount);
            }

            var model = new TuberculosisSurrogateModel(CurrentCulture.ShortName,
                DiagnosisIdParam, DiagnosisFilter.SelectedText,
                m_Years, StartMonthParam, EndMonthParam,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);
            var reportAz = (TuberculosisCasesTestedReport) CreateReportObject();
            reportAz.SetParameters( model,manager,archiveManager);
            return reportAz;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            m_MonthCollection = null;
            base.ApplyResources(manager);

            m_Resources.ApplyResources(StartMonthLabel, "StartMonthLabel");
            m_Resources.ApplyResources(EndMonthLabel, "EndMonthLabel");

            ApplyLookupResources(StartMonthLookUp, MonthCollection, StartMonthParam, StartMonthLabel.Text);
            ApplyLookupResources(EndMonthLookUp, MonthCollection, EndMonthParam, EndMonthLabel.Text);

            DiagnosisFilter.DefineBinding();
            YearFilter.DefineBinding();
            YearFilter.SetYears(new[] {DateTime.Now.Year.ToString()});
        }

        private void SetMandatory()
        {
            YearFilter.SetMandatory();
        }

        private void Year_EditValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_Years = e.KeyArray;
        }

        private void StartMonth_EditValueChanged(object sender, EventArgs e)
        {
            CorrectLookupRange(StartMonthLookUp, EndMonthLookUp, MonthLookupEnum.Start);
        }

        private void EndMonth_EditValueChanged(object sender, EventArgs e)
        {
            CorrectLookupRange(StartMonthLookUp, EndMonthLookUp,MonthLookupEnum.End);
        }

        private void Month_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ClearLookUpButtonClick(sender, e, StartMonthLookUp, EndMonthLookUp);
        }
    }
}