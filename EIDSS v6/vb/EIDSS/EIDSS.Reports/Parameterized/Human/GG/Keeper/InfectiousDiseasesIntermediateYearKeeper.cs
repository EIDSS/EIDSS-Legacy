using System;
using System.Collections.Generic;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.Report;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    public sealed partial class InfectiousDiseasesIntermediateYearKeeper : BaseIntervalKeeper
    {
        public InfectiousDiseasesIntermediateYearKeeper() : this(new Dictionary<string, string>())
        {
        }

        public InfectiousDiseasesIntermediateYearKeeper(Dictionary<string, string> parameters)
            : base(typeof (InfectiousDiseasesYear), parameters)
        {
            ReportType = typeof (InfectiousDiseasesYear);
            InitializeComponent();
            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            long? regionId = regionFilter.RegionId > 0 ? (long?) regionFilter.RegionId : null;
            long? rayonId = rayonFilter.RayonId > 0 ? (long?) rayonFilter.RayonId : null;

            var model = new IntermediateInfectiousDiseaseSurrogateModel(CurrentCulture.ShortName,
                StartDateTruncated, EndDateTruncated,
                regionId, rayonId, regionFilter.Text, rayonFilter.Text,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);

            var report = (InfectiousDiseasesYear) CreateReportObject();
            report.ShowGlobalHeader = true;
            report.SetParameters(manager, model);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);
            rayonFilter.DefineBinding();
            regionFilter.DefineBinding();
        }

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            LocationHelper.RegionFilterValueChanged(regionFilter, rayonFilter, e);
        }

        private void rayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            LocationHelper.RayonFilterValueChanged(regionFilter, rayonFilter, e);
        }
    }
}