using System;
using System.Threading;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.BaseControls.Report
{
    public partial class BaseDateReport : BaseReport
    {
        public BaseDateReport()
        {
            InitializeComponent();
        }

        public virtual void SetParameters(DbManagerProxy manager, BaseDateModel model)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "lang");

            cellInputYear.Text = model.Year.ToString(Thread.CurrentThread.CurrentCulture);

            string startName = FilterHelper.GetMonthName(model.Month);
            string endName = FilterHelper.GetMonthName(model.MonthEnd);
            cellInputMonth.Text = string.IsNullOrEmpty(endName)
                                      ? startName
                                      : string.Format("{0} - {1}", startName, endName);

            SetLanguage(manager, model);

            ShowWarningIfDataInArchive(manager, new DateTime(model.Year, model.Month ?? 1, 1), model.UseArchive);
        }
    }
}