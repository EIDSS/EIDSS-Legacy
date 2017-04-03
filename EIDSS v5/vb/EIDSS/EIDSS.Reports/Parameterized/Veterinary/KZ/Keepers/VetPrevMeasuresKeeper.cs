using System;
using System.ComponentModel;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.KZ;

namespace EIDSS.Reports.Parameterized.Veterinary.KZ.Keepers
{
    public partial class VetPrevMeasuresKeeper : BaseIntervalKeeper
    {
        private long? m_Region;

        private string[] m_Diagnosis;
        private string[] m_MeasureType;
        private string[] m_Species;

        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (VetPrevMeasuresKeeper));

        public VetPrevMeasuresKeeper()
        {
            InitializeComponent();
        }

        public VetPrevMeasuresKeeper(Type reportType)
            : base(reportType)
        {
            InitializeComponent();
            if (ReportType == typeof (VetCountryPreventiveMeasures))
            {
                regionFilter1.Hide();
            }
            regionFilter1.SetMandatory();
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            var model = new ProphylacticModel(CurrentCulture.ShortName, StartDateTruncated, EndDateTruncated, m_Region,
                                              m_Diagnosis, m_Species, m_MeasureType, UseArchive);
            dynamic report;
            if (ReportType == typeof (VetRegionPreventiveMeasures))
            {
                report = new VetRegionPreventiveMeasures();
            }
            else if (ReportType == typeof (VetCountryPreventiveMeasures))
            {
                report = new VetCountryPreventiveMeasures();
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
            measureTypeFilter1.DefineBinding();
            speciesFilter1.DefineBinding();

            m_Resources.ApplyResources(regionFilter1, "regionFilter1");
            m_Resources.ApplyResources(measureTypeFilter1, "measureTypeFilter1");
            m_Resources.ApplyResources(diagnosisFilter1, "diagnosisFilter1");
            m_Resources.ApplyResources(speciesFilter1, "speciesFilter1");
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

        private void measureTypeFilter1_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_MeasureType = e.KeyArray;
            ReloadReportIfFormLoaded(measureTypeFilter1);
        }

        private void speciesFilter1_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_Species = e.KeyArray;
            ReloadReportIfFormLoaded(speciesFilter1);
        }
    }
}