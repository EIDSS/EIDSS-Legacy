using System.Collections.Generic;
using bv.model.BLToolkit;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.Report;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    public sealed partial class InfectiousDiseasesYearKeeper : BaseYearKeeper
    {
        public InfectiousDiseasesYearKeeper() : this(new Dictionary<string, string>())
        {
        }

        public InfectiousDiseasesYearKeeper(Dictionary<string, string> parameters)
            : base(typeof (BaseYearReport), parameters)
        {
            ReportType = typeof (InfectiousDiseasesYear);
            InitializeComponent();
            rayonFilter.SetMandatory();
            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            // when rayon  not selected we should use RegionId == -1 and RayonId == -1 because we should show empty report
            string regionRayonId = string.Format("{0}__{1}", rayonFilter.RegionId, rayonFilter.RayonId);
            var rayonModel = new RayonModel {RegionRayonComplexId = regionRayonId};
            var model = new AnnualInfectiousDiseaseModel(CurrentCulture.ShortName, YearParam, UseArchive)
            {RayonFilter = rayonModel};

            var report = (InfectiousDiseasesYear) CreateReportObject();
            report.ShowGlobalHeader = false;
            report.SetParameters(manager, model);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);
            rayonFilter.DefineBinding();
        }
    }
}