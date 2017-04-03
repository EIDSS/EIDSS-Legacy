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
    public partial class WeeklySituationDiseasesKeeper : BaseYearKeeper
    {
        public WeeklySituationDiseasesKeeper() : this(true)
        {
        }

        public WeeklySituationDiseasesKeeper(bool isByDistrics)
        {
            ReportType = isByDistrics
                ? typeof (WeeklySituationDiseasesByDistrictsReport)
                : typeof (WeeklySituationDiseasesByAgeGroupAndSexReport);

            InitializeComponent();
            weekFilter.ExactFormat = "dd/MM/yyyy";
            weekFilter.SetMandatory();

            regionFilter.SetMandatory();

            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            UpdateWeekFilter();

            long? regionId = regionFilter.RegionId > 0 ? (long?) regionFilter.RegionId : null;
            var model = new WeeklySituationDiseasesModel(CurrentCulture.ShortName, YearParam, weekFilter.StartDate,
                weekFilter.SelectedText, regionId, UseArchive);
            dynamic report = CreateReportObject();
            report.SetParameters(manager, model);
            return report;
        }

        private void UpdateWeekFilter()
        {
            int oldIndex = weekFilter.ItemIndex;

            weekFilter.YearNumber = YearParam;

            if (oldIndex < 0)
            {
                weekFilter.SetCurrentDate();
            }
            else
            {
                weekFilter.ItemIndex = (oldIndex >= weekFilter.Count)
                    ? weekFilter.Count - 1
                    : oldIndex;
            }
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
                weekFilter.DefineBinding();

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