using System;
using System.Collections.Generic;
using bv.model.BLToolkit;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using DevExpress.XtraEditors.Controls;
using eidss.model.Core;
using eidss.model.Reports.GG;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.Report;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    public sealed partial class InfectiousDiseasesIntermediateYearKeeper : BaseIntervalKeeper
    {
        public InfectiousDiseasesIntermediateYearKeeper() : this(new Dictionary<string, string>())
        {
        }

        public InfectiousDiseasesIntermediateYearKeeper(Dictionary<string, string> parameters)
            : base(typeof (InfectiousDiseasesYear), parameters)
        {
            ReportType = typeof (InfectiousDiseasesYear);
            InitializeComponent();

            dtEnd.Properties.MinValue = new DateTime(2005, 01, 01);
            dtEnd.Properties.MaxValue = new DateTime(2012, 12, 31);
            dtEnd.EditValue = null;
            dtEnd.EditValueChanging += dtEnd_EditValueChanging;

            dtStart.Properties.MinValue = new DateTime(2005, 01, 01);
            dtStart.Properties.MaxValue = new DateTime(2012, 12, 31);
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

            var report = (InfectiousDiseasesYear) CreateReportObject();
            report.ShowGlobalHeader = true;
            report.SetParameters(model, manager, archiveManager);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);
            rayonFilter.DefineBinding();
            regionFilter.DefineBinding();
        }

        private void dtStart_EditValueChanging(object sender, ChangingEventArgs e)
        {
            e.Cancel = !(e.NewValue is DateTime) || CorrectRange((DateTime) e.NewValue, EndDateTruncated);
        }

        private void dtEnd_EditValueChanging(object sender, ChangingEventArgs e)
        {
            e.Cancel = !(e.NewValue is DateTime) || CorrectRange(StartDateTruncated, (DateTime) e.NewValue);
        }

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            LocationHelper.RegionFilterValueChanged(regionFilter, rayonFilter, e);
        }

        private void rayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            LocationHelper.RayonFilterValueChanged(regionFilter, rayonFilter, e);
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
    }
}