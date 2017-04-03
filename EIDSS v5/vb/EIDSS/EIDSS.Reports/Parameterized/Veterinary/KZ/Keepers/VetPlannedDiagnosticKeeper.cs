using System;
using System.ComponentModel;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.KZ;

namespace EIDSS.Reports.Parameterized.Veterinary.KZ.Keepers
{
    public partial class VetPlannedDiagnosticKeeper : BaseIntervalKeeper
    {
        private readonly ComponentResourceManager m_Resources =
            new ComponentResourceManager(typeof (VetPlannedDiagnosticKeeper));

        private string []m_Diagnosis;
        private string []m_InvestigationType;
        private string []m_Species;
        private long? m_Region;

        internal VetPlannedDiagnosticKeeper()
        {
            InitializeComponent();
        }

        public VetPlannedDiagnosticKeeper(Type reportType) : base(reportType)
        {
            InitializeComponent();
            if (ReportType == typeof (VetCountryPlannedDiagnostic))
            {
                regionFilter1.Hide();
            }
            regionFilter1.SetMandatory();
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            var model = new DiagnosticInvestigationModel(CurrentCulture.ShortName, StartDateTruncated, EndDateTruncated, m_Region,
                                    m_Diagnosis, m_Species, m_InvestigationType, UseArchive);
            dynamic report;
            if (ReportType == typeof (VetRegionPlannedDiagnostic))
            {
                 report = new VetRegionPlannedDiagnostic();
            }
            else if (ReportType == typeof (VetCountryPlannedDiagnostic))
            {
                 report = new VetCountryPlannedDiagnostic();
            }
            else
            {

                throw new ApplicationException(string.Format("Unsupported report type {0}", ReportType));
            }
            report.SetParameters(manager, model);
            return report;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            m_Resources.ApplyResources(pnlSettings, "pnlSettings");
            m_Resources.ApplyResources(this, "$this");

            regionFilter1.DefineBinding();
            diagnosisFilter1.DefineBinding();
            investigationTypeFilter1.DefineBinding();
            speciesFilter1.DefineBinding();

            m_Resources.ApplyResources(diagnosisFilter1, "diagnosisFilter1");
            m_Resources.ApplyResources(regionFilter1, "regionFilter1");
            m_Resources.ApplyResources(speciesFilter1, "speciesFilter1");
            m_Resources.ApplyResources(investigationTypeFilter1, "investigationTypeFilter1");
        }

        private void regionFilter1_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            m_Region = regionFilter1.RegionId > 0 ? (long?) regionFilter1.RegionId : null;
            ReloadReportIfFormLoaded(regionFilter1);
        }

        private void diagnosisFilter1_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_Diagnosis = e.KeyArray;
            ReloadReportIfFormLoaded(diagnosisFilter1);
        }

        private void investigationTypeFilter1_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_InvestigationType = e.KeyArray;
            ReloadReportIfFormLoaded(investigationTypeFilter1);
        }

        private void speciesFilter1_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_Species = e.KeyArray;
            ReloadReportIfFormLoaded(speciesFilter1);
        }
    }
}