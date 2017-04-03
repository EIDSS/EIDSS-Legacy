using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.OperationContext;
using EIDSS.Reports.Parameterized.Filters;
using EIDSS.Reports.Parameterized.Human.IQ.Reports;
using bv.model.BLToolkit;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class ComparativeIQReportKeeper : BaseComparativeReportKeeper
    {
        public ComparativeIQReportKeeper()
        {
            InitializeComponent();
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFirstLoading))
            {
                FiltersHelper.SetDefaultFiltes(manager, ContextKeeper, region1Filter, rayon1Filter);
            }

            var reportIq = new ComparativeIQReport();
            reportIq.SetParameters(manager, CurrentCulture.ShortName,
                                   Year1Param, Year2Param,
                                   StartMonthParam, EndMonthParam,
                                   FirstRegionIdParam, FirstRayonIdParam, SecondRegionIdParam, SecondRayonIdParam,
                                   CounterParam, UseArchive);
            return reportIq;
        }

        protected override void ApplyResources()
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;

                base.ApplyResources();

                region1Filter.Caption = ProvinceLabel.Text + " 1";
                rayon1Filter.Caption = DistrictLabel.Text + " 1";
                region2Filter.Caption = ProvinceLabel.Text + " 2";
                rayon2Filter.Caption = DistrictLabel.Text + " 2";
                // TODO: [ivan] Unhide controls when Iraq statistics will be filled in the DataBase
                CounterLabel.Hide();
                CounterLookUp.Hide();
                //
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
        }
    }
}