using System;
using bv.model.BLToolkit;
using eidss.model.Reports.KZ;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Veterinary.KZ.Keepers
{
    public partial class VetProphMeasuresKeeper : BaseIntervalKeeper
    {
        public string[] m_MeasureType = new string[0];
        private long? m_Region;

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
            dynamic report = CreateReportObject();
            report.SetParameters(manager, model);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);

            regionFilter1.DefineBinding();
            measureTypeFilter1.DefineBinding();
        }

        private void regionFilter1_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            m_Region = regionFilter1.RegionId > 0 ? (long?) regionFilter1.RegionId : null;
        }

        private void measureTypeFilter1_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_MeasureType = e.KeyArray;
        }
    }
}