using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.BaseControls.Report
{
    public partial class BaseIntervalReport : BaseReport
    {
        public BaseIntervalReport()
        {
            InitializeComponent();
        }

        public virtual void SetParameters(DbManagerProxy manager, BaseIntervalModel model)
        {
            Utils.CheckNotNullOrEmpty(model.Language, "model.Language");

            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(model.Language, this);
            cellInputStartDate.Text = rebinder.ToDateString(model.StartDate);
            cellInputEndDate.Text = rebinder.ToDateString(model.EndDate);

            tableInterval.Left = lblReportName.Left;
            tableInterval.Width = lblReportName.Width;

            SetLanguage(manager, model.Language);

            ShowWarningIfDataInArchive(manager, model.StartDate, model.UseArchive);
        }
    }
}