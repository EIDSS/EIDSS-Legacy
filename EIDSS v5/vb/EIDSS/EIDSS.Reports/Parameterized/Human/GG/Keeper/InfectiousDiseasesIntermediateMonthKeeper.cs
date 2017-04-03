using System.Collections.Generic;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Filters;
using EIDSS.Reports.Parameterized.Human.GG.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    public sealed partial class InfectiousDiseasesIntermediateMonthKeeper : BaseIntervalKeeper
    {
        private readonly bool m_IsNew;

        public InfectiousDiseasesIntermediateMonthKeeper() : this(true, new Dictionary<string, string>())
        {
        }

        public InfectiousDiseasesIntermediateMonthKeeper(bool isNew)
            : this(isNew, new Dictionary<string, string>())
        {
        }

        public InfectiousDiseasesIntermediateMonthKeeper(bool isNew, Dictionary<string, string> parameters)
            : base(typeof (InfectiousDiseasesMonth), parameters)
        {
            m_IsNew = isNew;
            InitializeComponent();
            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            long? regionId = regionFilter.RegionId > 0 ? (long?) regionFilter.RegionId : null;
            long? rayonId = rayonFilter.RayonId > 0 ? (long?) rayonFilter.RayonId : null;
            
            var model = new IntermediateInfectiousDiseaseSurrogateModel(CurrentCulture.ShortName,
                                                                StartDateTruncated, EndDateTruncated,
                                                                regionId, rayonId, regionFilter.Text, rayonFilter.Text
                                                                , UseArchive);

            dynamic report = m_IsNew
                                 ? (dynamic) new InfectiousDiseasesMonthNew {ShowGlobalHeader = true}
                                 : new InfectiousDiseasesMonth {ShowGlobalHeader = true};
            report.SetParameters(manager, model);
            return report;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            rayonFilter.DefineBinding();
            regionFilter.DefineBinding();
        }

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            FiltersHelper.RegionFilterValueChanged(this, regionFilter, rayonFilter, e);
        }

        private void rayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            FiltersHelper.RayonFilterValueChanged(this, regionFilter, rayonFilter, e);
        }
    }
}