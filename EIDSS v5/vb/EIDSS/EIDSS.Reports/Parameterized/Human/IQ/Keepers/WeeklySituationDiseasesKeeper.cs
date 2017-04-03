using System.ComponentModel;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.OperationContext;
using EIDSS.Reports.Parameterized.Filters;
using EIDSS.Reports.Parameterized.Human.IQ.Reports;
using bv.model.BLToolkit;
using bv.winclient.Core;
using eidss.model.Reports.IQ;

namespace EIDSS.Reports.Parameterized.Human.IQ.Keepers
{
    public partial class WeeklySituationDiseasesKeeper : BaseYearKeeper
    {
        private readonly ComponentResourceManager m_Resources =
            new ComponentResourceManager(typeof (WeeklySituationDiseasesKeeper));

        private readonly bool m_IsByDistrics;

        public WeeklySituationDiseasesKeeper() : this(true)
        {
        }

        public WeeklySituationDiseasesKeeper(bool isByDistrics)
        {
            m_IsByDistrics = isByDistrics;
            InitializeComponent();
            weekFilter.ExactFormat = "dd/MM/yyyy";
            weekFilter.SetMandatory();

            regionFilter.SetMandatory();
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            UpdateWeekFilter();

            UpdateRegionFilter(manager);

            long? regionId = regionFilter.RegionId > 0 ? (long?) regionFilter.RegionId : null;
            var model = new WeeklySituationDiseasesModel(CurrentCulture.ShortName, GetYearParam, weekFilter.StartDate,
                                                         weekFilter.SelectedText, regionId, UseArchive);
            dynamic report = m_IsByDistrics
                                 ? (dynamic) new WeeklySituationDiseasesByDistrictsReport()
                                 : new WeeklySituationDiseasesByAgeGroupAndSexReport();
            report.SetParameters(manager, model);
            return report;
        }

        private void UpdateRegionFilter(DbManagerProxy manager)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFirstLoading))
            {
                FiltersHelper.SetDefaultFiltes(manager, ContextKeeper, regionFilter, rayonFilter);
            }
        }

        private void UpdateWeekFilter()
        {
            int oldIndex = weekFilter.ItemIndex;

            weekFilter.YearNumber = GetYearParam;

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

        protected override void ApplyResources()
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;
                base.ApplyResources();

                // Note: do not load resources for spinEdit because it reset it's value
                //m_Resources.ApplyResources(spinEdit, "spinEdit");

                regionFilter.DefineBinding();
                weekFilter.DefineBinding();
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
        }

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                ReloadReportIfFormLoaded(regionFilter);
            }
        }

        private void weekFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            ReloadReportIfFormLoaded(regionFilter);
        }
    }
}