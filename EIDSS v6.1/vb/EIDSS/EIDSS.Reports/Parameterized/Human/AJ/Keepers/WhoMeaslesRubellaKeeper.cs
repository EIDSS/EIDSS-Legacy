using System.ComponentModel;
using bv.model.BLToolkit;
using eidss.model.Reports.AZ;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class WhoMeaslesRubellaKeeper : BaseDateKeeper
    {
        public WhoMeaslesRubellaKeeper()
        {
            ReportType = typeof (WhoMeaslesRubellaReport);
            MonthEndFollowsMonth = true;

            InitializeComponent();

            SetCurrentStartMonth();

            RemoveClearButtonMonthEnd();

            DiagnosisFilter.AdditionalFilter = string.Format("idfsDiagnosis = {0} OR idfsDiagnosis = {1}",
                WhoMeaslesRubellaModel.MeaslesId, WhoMeaslesRubellaModel.RubellaId);
            m_HasLoad = true;
        }

        [Browsable(false)]
        private long? DiagnosisIdParam
        {
            get { return DiagnosisFilter.EditValueId > 0 ? (long?) DiagnosisFilter.EditValueId : null; }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            var model = new WhoMeaslesRubellaModel(CurrentCulture.ShortName,
                YearParam, StartMonthParam, DiagnosisIdParam, UseArchive);

            var report = (WhoMeaslesRubellaReport) CreateReportObject();

            report.SetParameters( model,manager,archiveManager);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);
            DiagnosisFilter.DefineBinding();


        }
    }
}