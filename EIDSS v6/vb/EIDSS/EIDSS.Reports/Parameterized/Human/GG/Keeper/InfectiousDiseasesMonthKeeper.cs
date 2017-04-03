using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.Report;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    public sealed partial class InfectiousDiseasesMonthKeeper : BaseDateKeeper
    {
        private static readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (InfectiousDiseasesMonthKeeper));

        public InfectiousDiseasesMonthKeeper() : this(true, new Dictionary<string, string>())
        {
        }

        public InfectiousDiseasesMonthKeeper(bool isNew) : this(isNew, new Dictionary<string, string>())
        {
        }

        public InfectiousDiseasesMonthKeeper(bool isNew, Dictionary<string, string> parameters)
            : base(typeof (BaseDateReport), parameters)
        {
            ReportType = isNew
                ? typeof (InfectiousDiseasesMonthNew)
                : typeof (InfectiousDiseasesMonth);

            InitializeComponent();
            SetCurrentStartMonth();
            SetMandatory();
            rayonFilter.SetMandatory();
            ceAddSignature.Visible = isNew &&
                                     EidssUserContext.User.HasPermission(
                                         PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanSignReport));
            m_HasLoad = true;
        }

        [Browsable(false)]
        public bool AddSignature
        {
            get { return ceAddSignature.CheckState == CheckState.Checked; }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            // when rayon  not selected we should use RegionId == -1 and RayonId == -1 because we should show empty report

            string regionRayonId = string.Format("{0}__{1}", rayonFilter.RegionId, rayonFilter.RayonId);
            var model = new MonthInfectiousDiseaseModel(CurrentCulture.ShortName, YearParam, StartMonthParam, AddSignature, UseArchive)
            {
                RayonFilter = new RayonModel {RegionRayonComplexId = regionRayonId}
            };

            dynamic report = CreateReportObject();
            report.ShowGlobalHeader = false;
            report.SetParameters(manager, model);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);
            ceAddSignature.Properties.Caption = m_Resources.GetString("ceAddSignature.Properties.Caption");

            rayonFilter.DefineBinding();
        }
    }
}