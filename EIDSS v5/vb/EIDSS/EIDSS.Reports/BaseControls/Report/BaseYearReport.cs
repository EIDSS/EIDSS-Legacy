using System;
using System.Threading;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.BaseControls.Report
{
    public partial class BaseYearReport : BaseReport
    {
        public BaseYearReport()
        {
            InitializeComponent();
        }

        public virtual void SetParameters(DbManagerProxy manager, BaseYearModel model)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "lang");

            cellInputYear.Text = model.Year.ToString(Thread.CurrentThread.CurrentCulture);
            SetLanguage(manager, model.Language);

            ShowWarningIfDataInArchive(manager, new DateTime(model.Year, 1, 1), model.UseArchive);
        }
    }
}