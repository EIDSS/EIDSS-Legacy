using System.ComponentModel;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.OperationContext;
using EIDSS.Reports.Parameterized.Filters;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;
using bv.model.BLToolkit;
using bv.winclient.Core;
using eidss.model.Reports.AZ;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public sealed partial class FormN1Keeper : BaseDateKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof(FormN1Keeper));

        public FormN1Keeper() : base(typeof (FormN1Report))
        {
            InitializeComponent();
            m_HasLoad = true;
        }

        public bool IsA3Format { get; set; }

        [Browsable(false)]
        private long? OrganizationIdParam
        {
            get { return OrganizationFilter.EditValueId > 0 ? (long?)OrganizationFilter.EditValueId : null; }
        }


        [Browsable(false)]
        private long? RegionIdParam
        {
            get { return regionFilter.RegionId > 0 ? (long?)regionFilter.RegionId : null; }
        }

        [Browsable(false)]
        private long? RayonIdParam
        {
            get { return rayonFilter.RayonId > 0 ? (long?)rayonFilter.RayonId : null; }
        }


        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }
            if (ContextKeeper.ContainsContext(ContextValue.ReportFirstLoading))
            {
                FiltersHelper.SetDefaultFiltes(manager, ContextKeeper, regionFilter, rayonFilter);
            }
            
            var model = new FormNo1SurrogateModel(CurrentCulture.ShortName, YearParam, StartMonthParam, EndMonthParam,IsA3Format, 
                                         RegionIdParam, RayonIdParam, regionFilter.SelectedText, rayonFilter.SelectedText,
                                         OrganizationIdParam, OrganizationFilter.SelectedText, UseArchive);
            var report = new FormN1Report(model.IsA3Format);
            report.SetParameters(manager, model);
            return report;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();

            regionFilter.DefineBinding();
            rayonFilter.DefineBinding();

            m_Resources.ApplyResources(OrganizationFilter, "OrganizationFilter");
            OrganizationFilter.DefineBinding();

        }

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                OrganizationFilter.Enabled = !RegionIdParam.HasValue && !RayonIdParam.HasValue;
                FiltersHelper.RegionFilterValueChanged(this, regionFilter, rayonFilter, e);
            }
        }

        private void rayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                OrganizationFilter.Enabled = !RegionIdParam.HasValue && !RayonIdParam.HasValue;
                FiltersHelper.RayonFilterValueChanged(this, regionFilter, rayonFilter, e);
            }
        }

        private void OrganizationFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            bool hasOrg = OrganizationIdParam.HasValue;
            regionFilter.Enabled = !hasOrg;
            rayonFilter.Enabled = !hasOrg;

            ReloadReportIfFormLoaded(OrganizationFilter);
        }
    }
}