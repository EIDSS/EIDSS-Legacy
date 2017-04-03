using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.Report;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.GG;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    public sealed partial class InfectiousDiseasesMonthKeeper : BaseDateKeeper
    {
        private readonly bool m_IsNew;
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
            m_IsNew = isNew;
            InitializeComponent();
            SetMandatory();
            rayonFilter.SetMandatory();
            ceAddSignature.Visible = m_IsNew &&
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

            dynamic report = m_IsNew
                                 ? (dynamic) new InfectiousDiseasesMonthNew {ShowGlobalHeader = false}
                                 : new InfectiousDiseasesMonth {ShowGlobalHeader = false};
            report.SetParameters(manager, model);
            return report;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            ceAddSignature.Properties.Caption = m_Resources.GetString("ceAddSignature.Properties.Caption");

            rayonFilter.DefineBinding();
        }

        private void rayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            ReloadReportIfFormLoaded(rayonFilter);
        }

        private void ceAddSignature_CheckedChanged(object sender, EventArgs e)
        {
            ReloadReportIfFormLoaded(ceAddSignature);
        }
    }
}