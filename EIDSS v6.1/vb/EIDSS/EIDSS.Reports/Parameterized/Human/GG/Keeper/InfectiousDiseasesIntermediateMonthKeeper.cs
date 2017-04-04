using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using DevExpress.XtraEditors.Controls;
using eidss.model.Core;
using eidss.model.Reports;
using eidss.model.Reports.GG;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.Report;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    public sealed partial class InfectiousDiseasesIntermediateMonthKeeper : BaseIntervalKeeper
    {
        private readonly ComponentResourceManager m_Resources =
            new ComponentResourceManager(typeof (InfectiousDiseasesIntermediateMonthKeeper));

        public InfectiousDiseasesIntermediateMonthKeeper() : this(ReportVersion.Version6)
        {
        }

        public InfectiousDiseasesIntermediateMonthKeeper(ReportVersion version, Dictionary<string, string> parameters = null)
            : base(typeof (InfectiousDiseasesMonthV4), parameters ?? new Dictionary<string, string>())
        {
            var processor = new InfectiousDiseasesProcessor(version);
            ReportType = processor.GetReportType();

            InitializeComponent();

            dtEnd.Properties.MinValue = processor.MinDate;
            dtEnd.Properties.MaxValue = processor.MaxDate;
            dtEnd.EditValue = null;
            dtEnd.EditValueChanging += dtEnd_EditValueChanging;

            dtStart.Properties.MinValue = processor.MinDate;
            dtStart.Properties.MaxValue = processor.MaxDate;
            dtStart.EditValue = null;
            dtStart.EditValueChanging += dtStart_EditValueChanging;
            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            long? regionId = regionFilter.RegionId > 0 ? (long?) regionFilter.RegionId : null;
            long? rayonId = rayonFilter.RayonId > 0 ? (long?) rayonFilter.RayonId : null;

            var model = new IntermediateInfectiousDiseaseSurrogateModel(CurrentCulture.ShortName,
                StartDateTruncated, EndDateTruncated,
                regionId, rayonId, regionFilter.Text, rayonFilter.Text,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);

            dynamic report = CreateReportObject();
            report.ShowGlobalHeader = true;
            report.SetParameters(model, manager, archiveManager);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);
            rayonFilter.DefineBinding();
            regionFilter.DefineBinding();

            lblStart.Text = m_Resources.GetString("lblStart.Text");
            lblEnd.Text = m_Resources.GetString("lblEnd.Text");

            if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
            {
                LocationHelper.SetDefaultFilters(manager, ContextKeeper, regionFilter, rayonFilter);
            }
        }
        private void dtStart_EditValueChanging(object sender, ChangingEventArgs e)
        {
            e.Cancel = !(e.NewValue is DateTime) || CorrectRange((DateTime)e.NewValue, EndDateTruncated);
        }

        private void dtEnd_EditValueChanging(object sender, ChangingEventArgs e)
        {
            e.Cancel = !(e.NewValue is DateTime) || CorrectRange(StartDateTruncated, (DateTime)e.NewValue);
        }

        private bool CorrectRange(DateTime startDate, DateTime endDate)
        {
            if (!ContextKeeper.ContainsContext(ContextValue.ReportFilterResetting) &&
                !ContextKeeper.ContainsContext(ContextValue.ReportFilterLoading))
            {
                startDate = TruncateDate(startDate);
                endDate = TruncateDate(endDate);

                if (startDate >= endDate)
                {
                    if (!BaseFormManager.IsReportsServiceRunning && !BaseFormManager.IsAvrServiceRunning)
                    {
                        ErrorForm.ShowWarning("msgInfectiousDiseasesCorrectDate",
                            @"The date selected in the “Start Date” filter shall be less than the date selected in the “End Date” filter");
                    }
                    return true;
                }
            }
            return false;
        }

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            LocationHelper.RegionFilterValueChanged(regionFilter, rayonFilter, e);
        }

        private void rayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            LocationHelper.RayonFilterValueChanged(regionFilter, rayonFilter, e);
        }
    }
}