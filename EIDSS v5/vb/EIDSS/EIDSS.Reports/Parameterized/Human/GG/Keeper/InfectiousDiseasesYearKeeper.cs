using System.Collections.Generic;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.GG;

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
            InitializeComponent();
            rayonFilter.SetMandatory();
            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            var report = new InfectiousDiseasesYear {ShowGlobalHeader = false};
            // when rayon  not selected we should use RegionId == -1 and RayonId == -1 because we should show empty report
            string regionRayonId = string.Format("{0}__{1}", rayonFilter.RegionId, rayonFilter.RayonId);
            var rayonModel = new RayonModel {RegionRayonComplexId = regionRayonId};
            var model = new AnnualInfectiousDiseaseModel(CurrentCulture.ShortName, GetYearParam, UseArchive)
                {RayonFilter = rayonModel};

            report.SetParameters(manager, model);
            return report;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            rayonFilter.DefineBinding();
        }

        private void RayonValueChanged(object sender, SingleFilterEventArgs e)
        {
            ReloadReportIfFormLoaded(rayonFilter);
        }
    }
}