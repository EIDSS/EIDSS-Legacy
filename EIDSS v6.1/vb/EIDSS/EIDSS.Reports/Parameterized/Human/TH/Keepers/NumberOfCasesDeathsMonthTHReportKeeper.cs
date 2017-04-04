using System;
using System.ComponentModel;
using System.Linq;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Reports.OperationContext;
using eidss.model.Reports.TH;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.TH.Reports;

namespace EIDSS.Reports.Parameterized.Human.TH.Keepers
{
    public partial class NumberOfCasesDeathsMonthTHReportKeeper : BaseYearKeeper
    {
        private readonly ComponentResourceManager m_Resources =
            new ComponentResourceManager(typeof (NumberOfCasesDeathsMonthTHReportKeeper));

        public string[] m_CheckedDiagnosis = new string[0];
        public string[] m_CheckedZones = new string[0];
        public string[] m_CheckedRegions = new string[0];
        private string[] m_CheckedProvinces = new string[0];
        private bool m_IsThaiCulture;
        private int m_Year;

        public NumberOfCasesDeathsMonthTHReportKeeper()
        {
            try
            {
                IsResourceLoading = true;
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
                    ReportType = typeof (NumberOfCasesDeathsMonthTHReport);
                    InitializeComponent();

                    m_Year = DateTime.Now.Year;
                    ApplyYearResources();
                }
            }
            finally
            {
                IsResourceLoading = false;
                m_HasLoad = true;
            }
        }

        [Browsable(false)]
        protected long? CaseClassification
        {
            get { return CaseClassificationFilter.EditValueId > 0 ? (long?) CaseClassificationFilter.EditValueId : null; }
        }

        private int DeltaYear
        {
            get { return m_IsThaiCulture ? 543 : 0; }
        }

        private void DiagnosisFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_CheckedDiagnosis = e.KeyArray.ToArray();
        }

        private void ZonesFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_CheckedZones = e.KeyArray.ToArray();
            ProvinceFilter.Enabled = RegionFilter.Enabled = m_CheckedZones.Length == 0;
        }

        private void RegionFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_CheckedRegions = e.KeyArray.ToArray();
            ProvinceFilter.Enabled = ThaiZonesFilter.Enabled = m_CheckedRegions.Length == 0;
        }

        private void ProvinceFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_CheckedProvinces = e.KeyArray;
            RegionFilter.Enabled = ThaiZonesFilter.Enabled = m_CheckedProvinces.Length == 0;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            var model = new NumberOfCasesDeathsMonthTHModel(CurrentCulture.ShortName,
                m_Year,
                m_CheckedDiagnosis, m_CheckedRegions, m_CheckedZones, m_CheckedProvinces,
                CaseClassification,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);

            dynamic report = CreateReportObject();
            report.SetParameters( model,manager,archiveManager);
            return (BaseReport) report;
        }

        protected override void OnBeforeYearChange()
        {
            if (!ContextKeeper.ContainsContext(ContextValue.ReportFilterResetting))
            {
                m_Year = YearParam - DeltaYear;
            }
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);

            m_Resources.ApplyResources(pnlSettings, "pnlSettings");
            ApplyYearResources();

            DiagnosesFilter.DefineBinding();
            RegionFilter.DefineBinding();
            ThaiZonesFilter.DefineBinding();
            CaseClassificationFilter.DefineBinding();
            ProvinceFilter.DefineBinding();

        }

        private void ApplyYearResources()
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                m_IsThaiCulture = ModelUserContext.CurrentLanguage == Localizer.lngThai;

                MaxYear = DeltaYear + DateTime.Now.Year;
                MinYear = m_IsThaiCulture ? 2550 : 2000;
                YearParam = m_Year + DeltaYear;
            }
        }
    }
}