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
    public partial class LabTestingTesultsReportKeeper : BaseReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (LabTestingTesultsReportKeeper));

        public LabTestingTesultsReportKeeper()
        {
            ReportType = typeof (LabTestingTesultsReportNew);

            InitializeComponent();
            LayoutCorrector.SetStyleController(SampleId, LayoutCorrector.MandatoryStyleController);
            Department.SetMandatory();
            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            var report = ((LabTestingTesultsReportNew) CreateReportObject());

            var caseModel = new LabTestingTesultsModel(CurrentCulture.ShortName, SampleId.Text, Department.EditValueId, UseArchive);

            report.SetParameters(caseModel, manager, archiveManager);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)

        {
            base.ApplyResources(manager);

            m_Resources.ApplyResources(lblSampleID, "lblSampleID");
            m_Resources.ApplyResources(SearchButton, "SearchButton");
            SearchSample();
            SetSearchButtonEnable();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            using (new CultureInfoTransaction(CurrentCulture.CultureInfo))
            {
                SearchSample();
                if (Department.SampleNotFound)
                {
                    ErrorForm.ShowWarning("msgReportAzSampleNotFound", "Sample not found.");
                }
                else if (Department.DepartmentsNotFound)
                {
                    ErrorForm.ShowWarning("msgReportAzDepartmentsNotFound",
                        "Sample exists in the system, but the laboratory, where it is located, does not contain departments.");
                }
            }
        }

        private void SampleId_EditValueChanged(object sender, EventArgs e)
        {
            Department.ClearBinding();
            SetSearchButtonEnable();
        }

        private void SearchSample()
        {
            Department.DefineBinding(CurrentCulture.ShortName, SampleId.Text);
        }

        private void SetSearchButtonEnable()
        {
            SearchButton.Enabled = !string.IsNullOrEmpty(SampleId.Text);
        }

    }
}