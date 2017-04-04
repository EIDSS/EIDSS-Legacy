using System;
using System.ComponentModel;
using System.Linq;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using DevExpress.XtraEditors.Controls;
using eidss.model.Reports.AZ;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class HumSummaryReportKeeper : BaseIntervalKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (HumSummaryReportKeeper));

        public string[] m_CheckedDiagnosis = new string[0];

        public HumSummaryReportKeeper()
        {
            try
            {
                IsResourceLoading = true;

                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
                    ReportType = typeof (HumSummaryReport);

                    InitializeComponent();

                    dtEnd.EditValue = TruncateDate(DateTime.Now);
                    dtStart.EditValue = TruncateDate(DateTime.Now.AddMonths(-1));

                    HumDiagnosisFilter.SetMandatory();
                }
            }
            finally
            {
                IsResourceLoading = false;
                m_HasLoad = true;
            }
        }

        protected int MaxCount
        {
            get { return SummaryByRayonDiagnosisModel.HumMaxDiagnosisCount; }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            var model = new SummaryByRayonDiagnosisModel(CurrentCulture.ShortName,
                StartDateTruncated, EndDateTruncated,UseArchive)
            {
                MultipleDiagnosisFilter = {CheckedItems = m_CheckedDiagnosis, IsRequired = true}
            };
            dynamic report = CreateReportObject();
            report.SetParameters(model, manager, archiveManager);
            return (BaseReport) report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);
            m_Resources.ApplyResources(pnlSettings, "pnlSettings");

            HumDiagnosisFilter.DefineBinding();
        }

        private void DiagnosisFilter_ValueChanging(object sender, ChangingEventArgs e)
        {
            string newValue = Utils.Str(e.NewValue);
            if (newValue.Split(',').Count() > MaxCount)
            {
                if (!BaseFormManager.IsReportsServiceRunning && !BaseFormManager.IsAvrServiceRunning)
                {
                    const string defaultFormat = "You have selected too many diagnoses. Only first {0} will be displayed in the report.";
                    ErrorForm.ShowWarningFormat("msgTooManyDiagnosis", defaultFormat, MaxCount);
                }
                e.Cancel = true;
            }
        }

        private void DiagnosisFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_CheckedDiagnosis = e.KeyArray.Take(MaxCount).ToArray();
        }
    }
}