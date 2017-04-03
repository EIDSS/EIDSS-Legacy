using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Utils;
using EIDSS.Reports.BaseControls.Report;
using bv.common.win;
using bv.model.BLToolkit;
using bv.winclient.Layout;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public partial class BaseIntervalKeeper : BaseReportKeeper
    {
        private readonly Type m_ReportType;
        private bool m_IntervalChanging;
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (BaseIntervalKeeper));
        private long m_OldDates;

        // For design-time only
        internal BaseIntervalKeeper()
            : this(typeof (BaseIntervalReport), new Dictionary<string, string>())
        {
        }

        public BaseIntervalKeeper(Type reportType)
            : this(reportType, new Dictionary<string, string>())
        {
        }

        public BaseIntervalKeeper(Type reportType, Dictionary<string, string> parameters)
            : base(parameters)
        {
            m_ReportType = reportType;
            if (!(typeof (BaseIntervalReport)).IsAssignableFrom(reportType))
            {
                throw new ApplicationException("Report Type should be child of BaseIntervalReport");
            }

            InitializeComponent();
            LayoutCorrector.SetStyleController(dtEnd, LayoutCorrector.MandatoryStyleController);
            dtEnd.Properties.AllowNullInput = DefaultBoolean.False;
            dtEnd.Properties.ShowClear = false;
            dtEnd.EditValue = TruncateDate(DateTime.Now);

            LayoutCorrector.SetStyleController(dtStart, LayoutCorrector.MandatoryStyleController);
            dtStart.Properties.AllowNullInput = DefaultBoolean.False;
            dtStart.Properties.ShowClear = false;
            dtStart.EditValue = TruncateDate(DateTime.Now.AddMonths(-1));
            m_HasLoad = true;
        }

        public Type ReportType
        {
            get { return m_ReportType; }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            object reportObject = Activator.CreateInstance(m_ReportType);
            var report = ((BaseIntervalReport) reportObject);
            report.SetParameters(manager,new BaseIntervalModel(CurrentCulture.ShortName, StartDateTruncated, EndDateTruncated, UseArchive));
            return report;
        }

        protected override void ApplyResources()
        {
            try
            {
                IsResourceLoading = true;

                base.ApplyResources();
                object start = dtStart.EditValue;
                object end = dtEnd.EditValue;

                m_Resources.ApplyResources(dtStart, "dtStart");
                m_Resources.ApplyResources(lblStart, "lblStart");
                m_Resources.ApplyResources(dtEnd, "dtEnd");
                m_Resources.ApplyResources(lblEnd, "lblEnd");

                dtStart.EditValue = start;
                dtEnd.EditValue = end;
            }
            finally
            {
                IsResourceLoading = false;
            }
        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            DateValueChanged(true);
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            DateValueChanged(false);
        }

        private void DateValueChanged(bool isStartDateChanged)
        {
            if (m_IntervalChanging || IsResourceLoading)
            {
                return;
            }

            if (StartDateTruncated > EndDateTruncated)
            {
                m_IntervalChanging = true;
                if (isStartDateChanged)
                {
                    dtStart.EditValue = dtEnd.EditValue;
                }
                else
                {
                    dtEnd.EditValue = dtStart.EditValue;
                }
                m_IntervalChanging = false;
            }
            ReloadReportIfDatesChanged();
        }

        private void ReloadReportIfDatesChanged()
        {
            long newDates = StartDateTruncated.Ticks + EndDateTruncated.Ticks;
            if (m_OldDates != newDates)
            {
                m_OldDates = newDates;
                ReloadReportIfFormLoaded();
            }
        }

        protected DateTime StartDateTruncated
        {
            get
            {
                return (dtStart.EditValue == null)
                           ? new DateTime(1900, 01, 02)
                           : TruncateDate(dtStart.EditValue);
            }
        }

        protected DateTime EndDateTruncated
        {
            get
            {
                return (dtEnd.EditValue == null)
                           ? new DateTime(2100, 01, 01)
                           : TruncateDate(dtEnd.EditValue);
            }
        }

        private static DateTime TruncateDate(object value)
        {
            DateTime dateTime = (value is DateTime) ? (DateTime) value : DateTime.Now;
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }
    }
}