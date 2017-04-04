using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Reports.ARM;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.ARM.Report;

namespace EIDSS.Reports.Parameterized.Human.ARM.Keeper
{
    public partial class FormN85Keeper : BaseDateKeeper
    {
        public FormN85Keeper()
            : base(typeof (FormN85JointReport), new Dictionary<string, string>())
        {
            ReportType = typeof (FormN85JointReport);
            InitializeComponent();

            MinYear = 2010;
            MaxYear = DateTime.Now.Year;
            SetCurrentStartMonth();
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
            var model = new FormN85SurrogateModel(CurrentCulture.ShortName,
                YearParam, StartMonthParam,
                RegionIdParam, RayonIdParam,
                regionFilter.SelectedText, rayonFilter.SelectedText,
                EidssUserContext.User.FullName,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);

            var report = (FormN85JointReport) CreateReportObject();
            report.SetParameters(model, manager, archiveManager);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);

            regionFilter.DefineBinding();
            rayonFilter.DefineBinding();
            if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
            {
                LocationHelper.SetDefaultFilters(manager, ContextKeeper, regionFilter, rayonFilter);
            }
        }

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RegionFilterValueChanged(regionFilter, rayonFilter, e);
            }
            rayonFilter.Enabled = RegionIdParam.HasValue;
        }
    }
}