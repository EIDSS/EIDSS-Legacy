using System;
using System.ComponentModel;
using System.Linq;
using bv.model.BLToolkit;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using DevExpress.XtraEditors.Controls;
using eidss.model.Core;
using eidss.model.Reports.OperationContext;
using eidss.model.Reports.TH;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.TH.Reports;

namespace EIDSS.Reports.Parameterized.Human.TH.Keepers
{
    public partial class NumberOfCasesDeathsMortalityTHReportKeeper : BaseIntervalKeeper
    {
        private readonly ComponentResourceManager m_Resources =
            new ComponentResourceManager(typeof (NumberOfCasesDeathsMortalityTHReportKeeper));

        public string[] m_CheckedDiagnosis = new string[0];
        public string[] m_CheckedZones = new string[0];
        public string[] m_CheckedRegions = new string[0];
        private string[] m_CheckedProvinces = new string[0];

        public NumberOfCasesDeathsMortalityTHReportKeeper()
        {
            try
            {
                IsResourceLoading = true;

                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
                    ReportType = typeof (NumberOfCasesDeathsMorbidityMortalityTHReport);

                    InitializeComponent();

                    dtEnd.EditValue = TruncateDate(DateTime.Now);
                    dtStart.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
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

        private void DiagnosisFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_CheckedDiagnosis = e.KeyArray.ToArray();
        }

        private void ZonesFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_CheckedZones = e.KeyArray.ToArray();
            var enabled = m_CheckedZones.Length == 0;
            RegionFilter.Enabled = enabled;
            ProvinceFilter.Enabled = enabled;
        }

        private void RegionFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_CheckedRegions = e.KeyArray.ToArray();
            var enabled = m_CheckedRegions.Length == 0 ;
            ThaiZonesFilter.Enabled = enabled;
            ProvinceFilter.Enabled = enabled;
        }

        private void ProvincesFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_CheckedProvinces = e.KeyArray;

            var enabled = m_CheckedProvinces.Length == 0;
            ThaiZonesFilter.Enabled = enabled;
            RegionFilter.Enabled = enabled;
        }

        private void dtStart_EditValueChanging(object sender, ChangingEventArgs e)
        {
            e.Cancel = !(e.NewValue is DateTime) || CorrectRange((DateTime) e.NewValue, EndDateTruncated);
        }

        private void dtEnd_EditValueChanging(object sender, ChangingEventArgs e)
        {
            e.Cancel = !(e.NewValue is DateTime) || CorrectRange(StartDateTruncated, (DateTime) e.NewValue);
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            var model = new NumberOfCasesDeathsMorbidityMortalityTHModel(CurrentCulture.ShortName,
                StartDateTruncated, EndDateTruncated,
                m_CheckedDiagnosis, m_CheckedRegions, m_CheckedZones, m_CheckedProvinces,
                CaseClassification,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);

            dynamic report = CreateReportObject();
            report.SetParameters( model,manager,archiveManager);
            return (BaseReport) report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);

            m_Resources.ApplyResources(pnlSettings, "pnlSettings");

            DiagnosesFilter.DefineBinding();
            RegionFilter.DefineBinding();
            ThaiZonesFilter.DefineBinding();
            CaseClassificationFilter.DefineBinding();
            ProvinceFilter.DefineBinding();
        }

        private bool CorrectRange(DateTime startDate, DateTime endDate)
        {
            if (!ContextKeeper.ContainsContext(ContextValue.ReportFilterResetting) &&
                !ContextKeeper.ContainsContext(ContextValue.ReportFilterLoading))
            {
                startDate = TruncateDate(startDate);
                endDate = TruncateDate(endDate);

                if (startDate > endDate)
                {
                    if (!BaseFormManager.IsReportsServiceRunning && !BaseFormManager.IsAvrServiceRunning)
                    {
                        ErrorForm.ShowWarning("msgNumberOfCasesDeathsTHCorrectDate",
                            @"The Date selected in the To filter shall be greater than or equal to the Date selected in the From filter");
                    }
                    return true;
                }
            }
            return false;
        }
    }
}