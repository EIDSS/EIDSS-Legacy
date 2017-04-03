using System.ComponentModel;
using System.Linq;
using bv.winclient.BasePanel;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;
using bv.model.BLToolkit;
using bv.winclient.Core;
using eidss.model.Reports.AZ;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class SummaryReportKeeper : BaseIntervalKeeper
    {
        private const int MaxDiagnosisCount = 5;
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (SummaryReportKeeper));

        public string[] m_CheckedDiagnosis = new string[0];

        public SummaryReportKeeper()
        {
            InitializeComponent();
            diagnosisFilter1.SetMandatory();
            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            var report = new SummaryReport();
            var model = new SummaryByRayonDiagnosisAgeGroupsModel(CurrentCulture.ShortName, StartDateTruncated, EndDateTruncated, UseArchive)
                {
                    MultipleDiagnosisFilter = {CheckedDiagnosis = m_CheckedDiagnosis}
                };
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
            if (e.Dictionary.Count > MaxDiagnosisCount)
            {
                if (!BaseFormManager.IsReportsServiceRunning && !BaseFormManager.IsAvrServiceRunning)
                {
                    ErrorForm.ShowWarning("msgTooMamyDiagnosis");
                }
            }
            m_CheckedDiagnosis = e.KeyArray.Take(MaxDiagnosisCount).ToArray();
            ReloadReportIfFormLoaded(diagnosisFilter1);
        }
    }
}