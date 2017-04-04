using System;
using System.Threading;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.BaseControls.Report
{
    public partial class BaseYearReport : BaseReport
    {
        public BaseYearReport()
        {
            InitializeComponent();
        }

        public virtual void SetParameters(BaseYearModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "lang");

            cellInputYear.Text = model.Year.ToString(Thread.CurrentThread.CurrentCulture);
            SetLanguage(model, manager);

            ShowWarningIfDataInArchive(manager, new DateTime(model.Year, 1, 1), model.UseArchive);

            ReportRtlHelper.SetRTL(this);
        }
    }
}