using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors.Controls;
using eidss.model.Core.CultureInfo;
using eidss.model.Reports.AZ;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class VetSummaryReportKeeper : BaseIntervalKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (VetSummaryReportKeeper));

        public string[] m_CheckedSpeciesType = new string[0];
        CultureInfo m_CultureInfo = Thread.CurrentThread.CurrentUICulture;

        public VetSummaryReportKeeper()
        {
            try
            {
                IsResourceLoading = true;

                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
                    ReportType = typeof (VetSummaryReport);

                    InitializeComponent();

                    dtEnd.Properties.MinValue = new DateTime(2000, 01, 01);
                    dtEnd.Properties.MaxValue = TruncateDate(DateTime.Now);
                    dtEnd.EditValue = TruncateDate(DateTime.Now);

                    dtStart.Properties.MinValue = new DateTime(2000, 01, 01);
                    dtStart.Properties.MaxValue = TruncateDate(DateTime.Now);
                    dtStart.EditValue = TruncateDate(DateTime.Now.AddMonths(-1));

                    VetDiagnosisFilter.SetMandatory();
                    SpeciesTypeFilter.SetMandatory();

                    LayoutCorrector.SetStyleController(SurveillanceTypeGroup, LayoutCorrector.MandatoryStyleController);

                    NameOfInvestigationOrMeasure.SetMandatory();
                    SurveillanceTypeGroup_SelectedIndexChanged(this, EventArgs.Empty);
                }
            }
            finally
            {
                IsResourceLoading = false;
                m_HasLoad = true;
            }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            string surveillanceType = string.Empty;
            var surveillanceIndex = SurveillanceTypeGroup.SelectedIndex;
            if (surveillanceIndex >= 0 && surveillanceIndex < SurveillanceTypeGroup.Properties.Items.Count)
            {
                surveillanceType = (SurveillanceTypeGroup.Properties.Items[surveillanceIndex]).Description;
            }

            var model = new VetSummaryModel(CurrentCulture.ShortName,
                StartDateTruncated, EndDateTruncated,
                (VetSummarySurveillanceType) surveillanceIndex, surveillanceType,
                VetDiagnosisFilter.EditValueId, VetDiagnosisFilter.SelectedText,
                NameOfInvestigationOrMeasure.EditValueId, NameOfInvestigationOrMeasure.SelectedText,
                m_CheckedSpeciesType, UseArchive);
            dynamic report = CreateReportObject();
            report.SetParameters(model, manager, archiveManager);
            return (BaseReport) report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);
            m_CultureInfo = Thread.CurrentThread.CurrentUICulture;

            m_Resources.ApplyResources(pnlSettings, "pnlSettings");
            m_Resources.ApplyResources(SurveillanceTypeLabel, "SurveillanceTypeLabel");

            VetDiagnosisFilter.DefineBinding();
            NameOfInvestigationOrMeasure.DefineBinding();
            SpeciesTypeFilter.DefineBinding();

            
            SurveillanceTypeGroup.Properties.Items[(int) VetSummarySurveillanceType.ActiveSurveillanceIndex].Description =
                m_Resources.GetString("SurveillanceTypeGroup.Properties.Items1");
            SurveillanceTypeGroup.Properties.Items[(int) VetSummarySurveillanceType.PassiveSurveillanceIndex].Description =
                m_Resources.GetString("SurveillanceTypeGroup.Properties.Items3");
            SurveillanceTypeGroup.Properties.Items[(int) VetSummarySurveillanceType.AggregateActionsIndex].Description =
                m_Resources.GetString("SurveillanceTypeGroup.Properties.Items5");

            SurveillanceTypeGroup_SelectedIndexChanged(this, EventArgs.Empty);
            VetDiagnosisFilter.Top = NameOfInvestigationOrMeasure.Top;
            dtEnd.Left = VetDiagnosisFilter.Left;
            dtEnd.Width = 136;
            dtStart.Width = 136;
            lblEnd.Left = VetDiagnosisFilter.Left;
        }

        private void SurveillanceTypeGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            var isAggregateActions = (SurveillanceTypeGroup.SelectedIndex == (int) VetSummarySurveillanceType.AggregateActionsIndex);
            if (isAggregateActions)
            {
                NameOfInvestigationOrMeasure.SetMandatory();
            }
            else
            {
                NameOfInvestigationOrMeasure.SetReadOnly();
            }
            NameOfInvestigationOrMeasure.Enabled = isAggregateActions;

            using (new CultureInfoTransaction(m_CultureInfo))
            {
                VetDiagnosisFilter.SurveillanceType = (VetSummarySurveillanceType) SurveillanceTypeGroup.SelectedIndex;
                VetDiagnosisFilter.DefineBinding();

                SpeciesTypeFilter.Code = VetDiagnosisFilter.Code;
                SpeciesTypeFilter.DefineBinding();    
            }
        }

        private void VetDiagnosisFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (new CultureInfoTransaction(m_CultureInfo))
            {
                SpeciesTypeFilter.Code = VetDiagnosisFilter.Code;
                SpeciesTypeFilter.DefineBinding();    
            }
            
        }

        private void SpeciesFilter_ValueChanging(object sender, ChangingEventArgs e)
        {
            string newValue = Utils.Str(e.NewValue);
            if (newValue.Split(',').Count() > VetSummaryModel.VetMaxSpeciesTypeCount)
            {
                if (!BaseFormManager.IsReportsServiceRunning && !BaseFormManager.IsAvrServiceRunning)
                {
                    const string defaultFormat = "You can specify not more than three species in Species type filter.";
                    ErrorForm.ShowWarningFormat("msgTooManySpeciesType", defaultFormat, VetSummaryModel.VetMaxSpeciesTypeCount);
                }
                e.Cancel = true;
            }
        }

        private void SpeciesFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_CheckedSpeciesType = e.KeyArray.Take(VetSummaryModel.VetMaxSpeciesTypeCount).ToArray();
        }
    }
}