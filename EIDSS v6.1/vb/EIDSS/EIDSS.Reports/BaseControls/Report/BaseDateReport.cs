using System;
using System.Threading;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.BaseControls.Report
{
    public partial class BaseDateReport : BaseReport
    {
        public BaseDateReport()
        {
            InitializeComponent();
        }

        public virtual void SetParameters(BaseDateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "lang");
            if (model.Year < model.MinYear)
            {
                model.Year = model.MinYear;
            }
            cellInputYear.Text = (model.Year + DeltaYear).ToString(Thread.CurrentThread.CurrentCulture);

            string startName = FilterHelper.GetMonthName(model.Month);
            string endName = FilterHelper.GetMonthName(model.MonthEnd);
            cellInputMonth.Text = string.IsNullOrEmpty(endName)
                ? startName
                : string.Format("{0} - {1}", startName, endName);

            SetLanguage(model, manager);

            ShowWarningIfDataInArchive(manager, new DateTime(model.Year, model.Month ?? 1, 1), model.UseArchive);

            ReportRtlHelper.SetRTL(this);
        }
    }
}