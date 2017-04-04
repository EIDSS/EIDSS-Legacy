using System;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public sealed partial class FormN1Keeper : BaseDateKeeper
    {
        public FormN1Keeper() : base(typeof (FormN1Report))
        {
            ReportType = typeof (FormN1Report);
            InitializeComponent();
            SetCurrentStartMonth();
            m_HasLoad = true;
        }

        public bool IsA3Format { get; set; }

        [Browsable(false)]
        private long? OrganizationIdParam
        {
            get { return OrganizationFilter.EditValueId > 0 ? (long?) OrganizationFilter.EditValueId : null; }
        }

        [Browsable(false)]
        private long? RegionIdParam
        {
            get { return regionFilter.RegionId > 0 ? (long?) regionFilter.RegionId : null; }
        }

        [Browsable(false)]
        private long? RayonIdParam
        {
            get { return rayonFilter.RayonId > 0 ? (long?) rayonFilter.RayonId : null; }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            var model = new FormNo1SurrogateModel(CurrentCulture.ShortName, YearParam, StartMonthParam, EndMonthParam, IsA3Format,
                RegionIdParam, RayonIdParam, regionFilter.SelectedText, rayonFilter.SelectedText,
                OrganizationIdParam, OrganizationFilter.SelectedText,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);

            var report = (FormN1Report)CreateReportObject();
            report.SetParameters( model,manager,archiveManager);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);

            regionFilter.DefineBinding();
            rayonFilter.DefineBinding();
            OrganizationFilter.DefineBinding();

            if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
            {
                LocationHelper.SetDefaultFilters(manager, ContextKeeper, regionFilter, rayonFilter);
            }
        }

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                OrganizationFilter.Enabled = !RegionIdParam.HasValue && !RayonIdParam.HasValue;
                LocationHelper.RegionFilterValueChanged(regionFilter, rayonFilter, e);
            }
        }

        private void rayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                OrganizationFilter.Enabled = !RegionIdParam.HasValue && !RayonIdParam.HasValue;
                LocationHelper.RayonFilterValueChanged(regionFilter, rayonFilter, e);
            }
        }

        private void OrganizationFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            bool hasOrg = OrganizationIdParam.HasValue;
            regionFilter.Enabled = !hasOrg;
            rayonFilter.Enabled = !hasOrg;
        }
    }
}