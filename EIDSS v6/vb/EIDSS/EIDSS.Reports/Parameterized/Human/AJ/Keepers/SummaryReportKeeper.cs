using System.ComponentModel;
using System.Linq;
using bv.model.BLToolkit;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Reports.AZ;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class SummaryReportKeeper : BaseIntervalKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (SummaryReportKeeper));
        private readonly bool m_IsVet;

        public string[] m_CheckedDiagnosis = new string[0];

        public SummaryReportKeeper(bool isVet = false)
        {
            m_IsVet = isVet;
            ReportType = m_IsVet
                ? typeof (VetSummaryReport)
                : typeof (HumSummaryReport);

            InitializeComponent();

            if (m_IsVet)
            {
                VetDiagnosisFilter.intHACode = (int)HACode.Livestock;
                VetDiagnosisFilter.SetMandatory();
                VetDiagnosisFilter.Left = HumDiagnosisFilter.Left;
                VetDiagnosisFilter.Top = HumDiagnosisFilter.Top;
                HumDiagnosisFilter.Hide();
            }
            else
            {
                HumDiagnosisFilter.SetMandatory();
                VetDiagnosisFilter.Hide();
            }

            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            var model = new SummaryByRayonDiagnosisModel(CurrentCulture.ShortName, StartDateTruncated, EndDateTruncated, m_IsVet,
                UseArchive)
            {
                MultipleDiagnosisFilter = {CheckedItems = m_CheckedDiagnosis, IsRequired = true}
            };
            dynamic report = CreateReportObject();
            report.SetParameters(manager, model);
            return (BaseReport) report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);
            m_Resources.ApplyResources(pnlSettings, "pnlSettings");

            if (m_IsVet)
            {
                VetDiagnosisFilter.DefineBinding();
            }
            else
            {
                HumDiagnosisFilter.DefineBinding();
            }
        }

        private void DiagnosisFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            var maxCount = m_IsVet ? SummaryByRayonDiagnosisModel.VetMaxDiagnosisCount : SummaryByRayonDiagnosisModel.HumMaxDiagnosisCount;
            if (e.Dictionary.Count > maxCount)
            {
                if (!BaseFormManager.IsReportsServiceRunning && !BaseFormManager.IsAvrServiceRunning)
                {
                    const string defaultFormat = "You have selected too many diagnoses. Only first {0} will be displayed in the report.";
                    ErrorForm.ShowWarningFormat("msgTooManyDiagnosis", defaultFormat, maxCount);
                }
            }
            m_CheckedDiagnosis = e.KeyArray.Take(maxCount).ToArray();
        }
    }
}