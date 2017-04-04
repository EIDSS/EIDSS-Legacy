using System;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Core.CultureInfo;
using eidss.model.Reports.AZ;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class AssignmentLabDiagnosticReportKeeper : BaseReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (AssignmentLabDiagnosticReportKeeper));

        public AssignmentLabDiagnosticReportKeeper()
        {
            ReportType = typeof (AssignmentLabDiagnosticReportNew);

            InitializeComponent();
            LayoutCorrector.SetStyleController(CaseId, LayoutCorrector.MandatoryStyleController);
            SentTo.SetMandatory();
            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            var report = ((AssignmentLabDiagnosticReportNew) CreateReportObject());

            var caseModel = new AssignmentLabDiagnosticModel(CurrentCulture.ShortName, CaseId.Text, SentTo.EditValueId, UseArchive);

            report.SetParameters(caseModel, manager, archiveManager);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)

        {
            base.ApplyResources(manager);

            m_Resources.ApplyResources(lblCaseID, "lblCaseID");
            m_Resources.ApplyResources(ValidateButton, "ValidateButton");
            ValidateCase();
            SetValidationEnabled();
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            using (new CultureInfoTransaction(CurrentCulture.CultureInfo))
            {
                ValidateCase();
                if (SentTo.CaseNotFound)
                {
                    ErrorForm.ShowWarning("msgReportAzCaseNotFound", "Case not found");
                }
                else if (SentTo.SamplesNotFound)
                {
                    ErrorForm.ShowWarning("msgReportAzSamplesNotFound",
                        "Case with specified Case ID exists in the system, but it does not contain samples");
                }
            }
        }

        private void CaseId_EditValueChanged(object sender, EventArgs e)
        {
            SentTo.ClearBinding();
            SetValidationEnabled();
        }

        private void SetValidationEnabled()
        {
            ValidateButton.Enabled = !string.IsNullOrEmpty(CaseId.Text);
        }

        private void ValidateCase()
        {
            SentTo.DefineBinding(CurrentCulture.ShortName, CaseId.Text);
        }
    }
}