using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.model.BLToolkit;
using DevExpress.CodeParser;
using eidss.model.Core;
using eidss.model.Reports.Common;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.DToChangedD
{
    public partial class DToChangedDKeeper : BaseDateKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (DToChangedDKeeper));
        private string[] m_InitialDiagnoses;
        private string[] m_FinalDiagnoses;

        public DToChangedDKeeper() : base(typeof (DToChangedDReport), new Dictionary<string, string>())
        {
            ReportType = typeof (DToChangedDReport);
            InitializeComponent();
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

        [Browsable(false)]
        private long? SettlementIdParam
        {
            get { return settlementFilter.SettlementId > 0 ? (long?) settlementFilter.SettlementId : null; }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            string location = AddressModel.GetLocation(CurrentCulture.ShortName,
                RegionIdParam, regionFilter.SelectedText,
                RayonIdParam, rayonFilter.SelectedText,
                settlementFilter.SelectedText);

            var model = new DToChangedDSurrogateModel(CurrentCulture.ShortName,
                YearParam, StartMonthParam,
                RegionIdParam, RayonIdParam, SettlementIdParam, location,
                m_InitialDiagnoses, m_FinalDiagnoses,
                (int) ConcordanceSpinEdit.Value,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);

            var report = (DToChangedDReport)CreateReportObject();
            report.SetParameters( model,manager,archiveManager);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);

            regionFilter.DefineBinding();
            rayonFilter.DefineBinding();
            settlementFilter.DefineBinding();

            initialDiagnosisFilter.DefineBinding();
            finalDiagnosisFilter.DefineBinding();

            ConcordanceLabel.Text = m_Resources.GetString("ConcordanceLabel.Text");
            InitialDiagnosisLabel.Text = m_Resources.GetString("InitialDiagnosisLabel.Text");
            FinalDiagnosisLabel.Text = m_Resources.GetString("FinalDiagnosisLabel.Text");
        }

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RegionFilterValueChanged(regionFilter, rayonFilter, e);
            }
            rayonFilter.Enabled = RegionIdParam.HasValue;
            settlementFilter.Enabled = false;
        }

        private void rayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                if (rayonFilter.RayonId == -1 || rayonFilter.RayonId != settlementFilter.RayonId)
                {
                    settlementFilter.SettlementId = -1;
                }
                settlementFilter.RayonId = rayonFilter.RayonId;
            }
            settlementFilter.Enabled = RayonIdParam.HasValue;
        }

        private void initialDiagnosisFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_InitialDiagnoses = e.KeyArray;
        }

        private void finalDiagnosisFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_FinalDiagnoses = e.KeyArray;
        }
    }
}