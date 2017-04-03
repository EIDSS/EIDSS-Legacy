using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.Core;
using eidss.model.Reports.AberrationAnalisys;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.AberrationAnalysis.Reports;

namespace EIDSS.Reports.Parameterized.AberrationAnalysis.Keepers
{
    public partial class VetAberrationKeeper : AberrationKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (VetAberrationKeeper));

        private string[] m_Diagnosis;
        private string[] m_CaseClassification;

        public VetAberrationKeeper()
        {
            ReportType = typeof (VetAberrationReport);
            InitializeComponent();
            caseReportTypeLookupFilter.SetMandatory();
            vetCaseTypeLookupFilter.SetMandatory();
            intType = 2;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            var report = (VetAberrationReport) CreateReportObject();
            using (
                var model = new VetAberrationModel(CurrentCulture.ShortName, StartDateTruncated, EndDateTruncated, RegionIdParam,
                    RayonIdParam, SettlementIdParam, LocationParam,
                    ThresholdParam, TimeUnitsParam, TimeUnitsTextParam, BaselineParam, LagParam, DateFieldsParam, DateFieldsTextParam,
                    m_Diagnosis, vetCaseTypeLookupFilter.EditValueId, vetCaseTypeLookupFilter.SelectedText,
                    caseReportTypeLookupFilter.EditValueId,
                    caseReportTypeLookupFilter.SelectedText, m_CaseClassification,
                    UseArchive))
            {
                report.SetParameters(manager, model);
            }

            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);
            m_Resources.ApplyResources(pnlSettings, "pnlSettings");
            m_Resources.ApplyResources(this, "$this");

            caseReportTypeLookupFilter.DefineBinding();
            vetCaseTypeLookupFilter.DefineBinding();
            diagnosisFilter.DefineBinding();
            caseClassificationMultiFilter.DefineBinding();

            m_Resources.ApplyResources(diagnosisFilter, "diagnosisFilter");
        }

        private void diagnosisFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_Diagnosis = e.KeyArray;
        }

        private void caseClassificationMultiFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_CaseClassification = e.KeyArray;
        }

        private void vetCaseTypeLookupFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            int intHACode = vetCaseTypeLookupFilter.EditValueId == (long) CaseType.Livestock ? (int) HACode.Livestock : (int) HACode.Avian;
            diagnosisFilter.intHACode = intHACode;
            diagnosisFilter.DefineBinding();
            caseClassificationMultiFilter.intHACode = intHACode;
            caseClassificationMultiFilter.DefineBinding();
        }
    }
}