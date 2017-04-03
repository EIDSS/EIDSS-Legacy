using System;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class ComparativeAZReportKeeper : BaseComparativeReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (ComparativeAZReportKeeper));

        public ComparativeAZReportKeeper()
        {
            ReportType = typeof (ComparativeAZReport);
            InitializeComponent();
        }

        [Browsable(false)]
        protected long? OrganizationIdParam
        {
            get { return OrganizationFilter.EditValueId > 0 ? (long?) OrganizationFilter.EditValueId : null; }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            var model = new ComparativeSurrogateModel(CurrentCulture.ShortName,
                CounterParam,
                StartMonthParam, EndMonthParam,
                Year1Param, Year2Param,
                FirstRegionIdParam, FirstRayonIdParam,
                SecondRegionIdParam, SecondRayonIdParam,
                OrganizationIdParam,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);

            var reportAz = (ComparativeAZReport) CreateReportObject();
            reportAz.SetParameters(manager, model);
            return reportAz;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;

                base.ApplyResources(manager);

                //  m_Resources.ApplyResources(StartMonthLookUp, "StartMonthLookUp");
                //  m_Resources.ApplyResources(EndMonthLookUp, "EndMonthLookUp");
                m_Resources.ApplyResources(EndMonthLabel, "EndMonthLabel");

                ApplyLookupResources(StartMonthLookUp, MonthCollection, StartMonthParam, EndYearLabel.Text);
                ApplyLookupResources(EndMonthLookUp, MonthCollection, EndMonthParam, EndMonthLabel.Text);

                OrganizationFilter.DefineBinding();

                region1Filter.Caption += " 1";
                rayon1Filter.Caption += " 1";
                region2Filter.Caption += " 2";
                rayon2Filter.Caption += " 2";

                if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
                {
                    LocationHelper.SetDefaultFilters(manager, ContextKeeper, region1Filter, rayon1Filter);
                }
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