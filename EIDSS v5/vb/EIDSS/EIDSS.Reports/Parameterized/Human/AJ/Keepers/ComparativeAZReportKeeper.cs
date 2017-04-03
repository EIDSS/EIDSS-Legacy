using System.ComponentModel;
using bv.winclient.BasePanel;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.OperationContext;
using EIDSS.Reports.Parameterized.Filters;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;
using bv.common.win;
using bv.model.BLToolkit;
using eidss.model.Reports.AZ;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class ComparativeAZReportKeeper : BaseComparativeReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (ComparativeAZReportKeeper));

        public ComparativeAZReportKeeper()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        protected long? OrganizationIdParam
        {
            get { return OrganizationFilter.EditValueId > 0 ? (long?) OrganizationFilter.EditValueId : null; }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFirstLoading))
            {
                FiltersHelper.SetDefaultFiltes(manager, ContextKeeper, region1Filter, rayon1Filter);
            }

            var reportAz = new ComparativeAZReport();
            var model = new ComparativeSurrogateModel(CurrentCulture.ShortName,
                                                      CounterParam,
                                                      StartMonthParam, EndMonthParam,
                                                      Year1Param, Year2Param,
                                                      FirstRegionIdParam, FirstRayonIdParam,
                                                      SecondRegionIdParam, SecondRayonIdParam,
                                                      OrganizationIdParam,
                                                      UseArchive);
            reportAz.SetParameters(manager, model);
            return reportAz;
        }

        protected override void ApplyResources()
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;

                base.ApplyResources();

                m_Resources.ApplyResources(StartMonthLookUp, "StartMonthLookUp");
                m_Resources.ApplyResources(EndMonthLookUp, "EndMonthLookUp");
                m_Resources.ApplyResources(EndMonthLabel, "EndMonthLabel");
                m_Resources.ApplyResources(OrganizationFilter, "OrganizationFilter");
                OrganizationFilter.DefineBinding();

                region1Filter.Caption += " 1";
                rayon1Filter.Caption += " 1";
                region2Filter.Caption += " 2";
                rayon2Filter.Caption += " 2";
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
        }

        protected override void CorrectYearRange()
        {
            if (Year2Param <= Year1Param)
            {
                if (!ContextKeeper.ContainsContext(ContextValue.ReportFilterLoading))
                {
                    if (!BaseFormManager.IsReportsServiceRunning && !BaseFormManager.IsAvrServiceRunning)
                    {
                        ErrorForm.ShowWarning("msgComparativeReportCorrectYear", "Year 1 shall be greater than Year 2");
                    }
                }
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
                    Year1SpinEdit.EditValue = Year2Param - 1;
                }
            }
        }

        private void OrganizationFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            bool hasOrg = OrganizationIdParam.HasValue;
            region1Filter.Enabled = !hasOrg;
            rayon1Filter.Enabled = !hasOrg;
            region2Filter.Enabled = !hasOrg;
            rayon2Filter.Enabled = !hasOrg;

            ReloadReportIfFormLoaded(OrganizationFilter);
        }

        private void RegionRayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            //note: base handler of region and rayon value changing is implemented in base class
            bool hasAddress = FirstRegionIdParam.HasValue || FirstRayonIdParam.HasValue ||
                              SecondRegionIdParam.HasValue || SecondRayonIdParam.HasValue;

            OrganizationFilter.Enabled = !hasAddress;
        }
    }
}