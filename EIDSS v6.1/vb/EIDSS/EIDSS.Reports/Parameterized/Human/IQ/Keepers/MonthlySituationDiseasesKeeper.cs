using System;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.Core;
using eidss.model.Reports.IQ;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.IQ.Reports;

namespace EIDSS.Reports.Parameterized.Human.IQ.Keepers
{
    public partial class MonthlySituationDiseasesKeeper : BaseDateKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (MonthlySituationDiseasesKeeper));

        public MonthlySituationDiseasesKeeper() : this(true)
        {
        }

        public MonthlySituationDiseasesKeeper(bool isByDistrics)
        {
            ReportType = isByDistrics
                ? typeof(DiseasesByDistrictsReport)
                : typeof(DiseasesByAgeGroupAndSexReport);

            InitializeComponent();

            MaxYear = DateTime.Now.Year;

            SetMandatory();

            regionFilter.SetMandatory();

            SetCurrentStartMonth();

            m_HasLoad = true;
        }

        public DateTime StartDate
        {
            get { return new DateTime(YearParam, StartMonthParam ?? 1, 1); }
        }

        public DateTime EndDate
        {
            get { return StartDate.AddMonths(1).AddDays(-1); }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            long? regionId = regionFilter.RegionId > 0 ? (long?) regionFilter.RegionId : null;
            var model = new SituationOnInfectiousDiseasesSurrogateModel(CurrentCulture.ShortName,
                YearParam, eidss.model.Enums.StatisticPeriodType.Month, StartMonthParam ?? 1,
                StartDate, EndDate,
                regionId, regionFilter.SelectedText,
                UseArchive);
            dynamic report = CreateReportObject();
            report.SetParameters( model,manager,archiveManager);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;
                base.ApplyResources(manager);

                // Note: do not load resources for spinEdit because it reset it's value
                //m_Resources.ApplyResources(spinEdit, "spinEdit");

                regionFilter.DefineBinding();

                regionFilter.Caption = m_Resources.GetString("ProvinceLabel.Text");

                if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
                {
                    LocationHelper.SetDefaultFilters(manager, ContextKeeper, regionFilter, rayonFilter);
                }
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
        }
    }
}