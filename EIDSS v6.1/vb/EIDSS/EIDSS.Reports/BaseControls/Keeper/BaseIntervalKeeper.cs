using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Layout;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using eidss.model.Core.CultureInfo;
using eidss.model.Reports.Common;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Report;
using Localizer = bv.common.Core.Localizer;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public partial class BaseIntervalKeeper : BaseReportKeeper
    {
        private bool m_IntervalChanging;
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (BaseIntervalKeeper));
        private long m_OldDates;
        private string m_LocalCultureName;
        private readonly string m_GlobalCultureName;
        private CultureInfoTransaction m_DateStartTransaction;
        private CultureInfoTransaction m_DateEndTransaction;


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
            Utils.CheckNotNull(reportType, "reportType");
            if (!(typeof (BaseIntervalReport)).IsAssignableFrom(reportType))
            {
                throw new ApplicationException("Report Type should be child of BaseIntervalReport");
            }

            try
            {
                IsResourceLoading = true;

                m_GlobalCultureName = Localizer.AllSupportedLanguages[ModelUserContext.CurrentLanguage];
                m_LocalCultureName = m_GlobalCultureName;

                ReportType = reportType;
                InitializeComponent();
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
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
            }
            finally
            {
                IsResourceLoading = false;
            }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            var report = ((BaseIntervalReport) CreateReportObject());
            var model = new BaseIntervalModel(CurrentCulture.ShortName, StartDateTruncated, EndDateTruncated, UseArchive);
            report.SetParameters( model, manager, archiveManager);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                base.ApplyResources(manager);

                m_LocalCultureName = Localizer.AllSupportedLanguages[ModelUserContext.CurrentLanguage];
                object start = dtStart.EditValue;
                object end = dtEnd.EditValue;

                m_Resources.ApplyResources(dtStart, "dtStart");
                m_Resources.ApplyResources(dtEnd, "dtEnd");
                dtStart.Top = 28;
                dtEnd.Top = 28;
                m_Resources.ApplyResources(lblStart, "lblStart");
                m_Resources.ApplyResources(lblEnd, "lblEnd");

                dtStart.EditValue = start;
                dtEnd.EditValue = end;
                
                dtStart.Properties.Mask.Culture = new CultureInfo(m_LocalCultureName);
                dtStart.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtEnd.Properties.Mask.Culture = new CultureInfo(m_LocalCultureName);
                dtEnd.Properties.Mask.UseMaskAsDisplayFormat = true;


            }
            finally
            {
                IsResourceLoading = false;
            }
        }

        private void dtStart_QueryPopUp(object sender, CancelEventArgs e)
        {
            DisposeTransaction(ref m_DateEndTransaction);
            DisposeTransaction(ref m_DateStartTransaction);
            m_DateStartTransaction = CreateCultureInfoTransaction();
        }

        private void dtStart_Closed(object sender, ClosedEventArgs e)
        {
            DisposeTransaction(ref m_DateStartTransaction);
        }

        private void dtEnd_QueryPopUp(object sender, CancelEventArgs e)
        {
            DisposeTransaction(ref m_DateStartTransaction);
            DisposeTransaction(ref m_DateEndTransaction);
            m_DateEndTransaction = CreateCultureInfoTransaction();
        }

        private void dtEnd_Closed(object sender, ClosedEventArgs e)
        {
            DisposeTransaction(ref m_DateEndTransaction);
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
            set
            {
                dtStart.EditValue = value;
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
            set
            {
                dtEnd.EditValue = value;
            }
        }

        protected static DateTime TruncateDate(object value)
        {
            DateTime dateTime = (value is DateTime) ? (DateTime) value : DateTime.Now;
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        protected CultureInfoTransaction CreateCultureInfoTransaction()
        {
            return m_LocalCultureName == m_GlobalCultureName
                ? null
                : new CultureInfoTransaction(new CultureInfo(m_LocalCultureName));
        }

        protected static void DisposeTransaction(ref CultureInfoTransaction tran)
        {
            if (tran != null)
            {
                tran.Dispose();
                tran = null;
            }
        }

    }
}