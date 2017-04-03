using System;
using System.ComponentModel;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;
using bv.model.BLToolkit;
using eidss.model.Reports.AZ;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class DataQualityIndicatorsKeeper : AFPIndicatorsReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (DataQualityIndicatorsKeeper));
        private string[] m_Diagnosis;
        private readonly bool m_IsByRayons;

        public DataQualityIndicatorsKeeper(bool isByRayons)
        {
            InitializeComponent();

            m_IsByRayons = isByRayons;
            diagnosisFilter1.SetMandatory();
            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {


            var model = new DataQualityIndicatorsModel(CurrentCulture.ShortName, GetYearParam,
                                                       m_Diagnosis, Period, PeriodType, UseArchive);

            dynamic report = m_IsByRayons
                                 ? (dynamic) new DataQualityIndicatorsRayonsReport()
                                 : new DataQualityIndicatorsReport();

            report.SetParameters(manager, model);
            return report;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            m_Resources.ApplyResources(pnlSettings, "pnlSettings");
            m_Resources.ApplyResources(this, "$this");

            diagnosisFilter1.DefineBinding();

            m_Resources.ApplyResources(diagnosisFilter1, "diagnosisFilter1");
        }

        private void diagnosisFilter1_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_Diagnosis = e.KeyArray;
            ReloadReportIfFormLoaded(diagnosisFilter1);
        }

        private void diagnosisFilter1_Load(object sender, EventArgs e)
        {
        }
    }
}