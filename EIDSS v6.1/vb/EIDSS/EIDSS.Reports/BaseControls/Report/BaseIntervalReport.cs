using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.BaseControls.Report
{
    public partial class BaseIntervalReport : BaseReport
    {
        public BaseIntervalReport()
        {
            InitializeComponent();
        }

        public virtual void SetParameters(BaseIntervalModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNullOrEmpty(model.Language, "model.Language");

            ReportRebinder rebinder = this.GetDateRebinder(model.Language);
            cellInputStartDate.Text = rebinder.ToDateString(model.StartDate);
            cellInputEndDate.Text = rebinder.ToDateString(model.EndDate);

            tableInterval.Left = lblReportName.Left;
            tableInterval.Width = lblReportName.Width;

            SetLanguage(model, manager);

            ShowWarningIfDataInArchive(manager, model.StartDate, model.UseArchive);

            ReportRtlHelper.SetRTL(this);
        }
    }
}