using System;
using System.ComponentModel;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.KZ;

namespace EIDSS.Reports.Parameterized.Veterinary.KZ.Keepers
{
    public partial class VetProphMeasuresKeeper : BaseIntervalKeeper
    {
        public string[] m_MeasureType = new string[0];
        private long? m_Region;
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (VetProphMeasuresKeeper));

        public VetProphMeasuresKeeper()
        {
            InitializeComponent();
        }

        public VetProphMeasuresKeeper(Type reportType)
            : base(reportType)
        {
            InitializeComponent();
            if (ReportType == typeof (VetCountryProphilacticMeasures))
            {
                regionFilter1.Hide();
            }
            regionFilter1.SetMandatory();
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            var model = new SanitaryModel(CurrentCulture.ShortName, StartDateTruncated, EndDateTruncated,
                                          m_Region, m_MeasureType, UseArchive);
            dynamic report;
            if (ReportType == typeof (VetRegionProphilacticMeasures))
            {
                report = new VetRegionProphilacticMeasures();
            }
            else if (ReportType == typeof (VetCountryProphilacticMeasures))
            {
                report = new VetCountryProphilacticMeasures();
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
            m_Resources.ApplyResources(this, "$this");

            regionFilter1.DefineBinding();
            measureTypeFilter1.DefineBinding();

            m_Resources.ApplyResources(regionFilter1, "regionFilter1");
            m_Resources.ApplyResources(measureTypeFilter1, "measureTypeFilter1");
        }

        private void regionFilter1_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            m_Region = regionFilter1.RegionId > 0 ? (long?) regionFilter1.RegionId : null;
            ReloadReportIfFormLoaded(regionFilter1);
        }

        private void measureTypeFilter1_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_MeasureType = e.KeyArray;
            ReloadReportIfFormLoaded(measureTypeFilter1);
        }
    }
}