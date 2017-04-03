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

            string startName = GetMonthName(model.Month);
            string endName = GetMonthName(model.MonthEnd);
            cellInputMonth.Text = string.IsNullOrEmpty(endName)
                                      ? startName
                                      : string.Format("{0} - {1}", startName, endName);

            SetLanguage(manager, model.Language);

            ShowWarningIfDataInArchive(manager, new DateTime(model.Year, model.Month ?? 1, 1), model.UseArchive);
        }

        protected static string GetMonthName(int? month)
        {
            string monthName = string.Empty;
            if (month.HasValue)
            {
                var dtMont = new DateTime(2000, month.Value, 1);
                monthName = dtMont.ToString("MMMM", Thread.CurrentThread.CurrentCulture);
            }

            return monthName;
        }
    }
}