using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.OperationContext;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.winclient.Layout;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public partial class BaseDateKeeper : BaseReportKeeper
    {
        private readonly Type m_ReportType;
        private static readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (BaseDateKeeper));
        public bool m_IsMonthRange;
        private List<ItemWrapper> m_MonthCollection;

        //For design-time only
        internal BaseDateKeeper()
            : this(typeof (BaseDateReport), new Dictionary<string, string>())
        {
        }

        public BaseDateKeeper(Type reportType)
            : this(reportType, new Dictionary<string, string>())
        {
        }

        public BaseDateKeeper(Type reportType, Dictionary<string, string> parameters)
            : base(parameters)
        {
            Utils.CheckNotNull(reportType, "reportType");

            m_ReportType = reportType;
            if (!(typeof (BaseDateReport)).IsAssignableFrom(reportType))
            {
                throw new ApplicationException("Repor Type should be child of BaseDateReport");
            }

            InitializeComponent();
            EndMonthLabel.VisibleChanged += EndMonthLabel_VisibleChanged;

            LayoutCorrector.SetStyleController(spinEdit, LayoutCorrector.MandatoryStyleController);

            spinEdit.Value = DateTime.Now.Year;

            BindLookup(cbMonth, MonthCollection, label2.Text);
            BindLookup(cbMonthEnd, MonthCollection, EndMonthLabel.Text);

            cbMonth.ItemIndex = DateTime.Now.Month - 1;
            cbMonth.EditValue = MonthCollection[DateTime.Now.Month - 1];

            m_HasLoad = true;
        }

        private void EndMonthLabel_VisibleChanged(object sender, EventArgs e)
        {
            EndMonthLabel.Visible = IsMonthRange;
        }

        [Browsable(true)]
        [DefaultValue(false)]
        public bool IsMonthRange
        {
            get { return m_IsMonthRange; }
            set
            {
                m_IsMonthRange = value;
                cbMonthEnd.Visible = m_IsMonthRange;
                EndMonthLabel.Visible = m_IsMonthRange;
                if (m_IsMonthRange)
                {
                    label2.Text = StartMonthLabel.Text;
                }
            }
        }

        [Browsable(false)]
        protected int YearParam
        {
            get { return (int) spinEdit.Value; }
        }

        [Browsable(false)]
        protected int? StartMonthParam
        {
            get
            {
                return (cbMonth.EditValue == null)
                           ? (int?) null
                           : ((ItemWrapper) cbMonth.EditValue).Number;
            }
        }

        [Browsable(false)]
        protected int? EndMonthParam
        {
            get
            {
                return (cbMonthEnd.EditValue == null)
                           ? (int?) null
                           : ((ItemWrapper) cbMonthEnd.EditValue).Number;
            }
        }

        public void SetMandatory()
        {
            BaseFilter.SetLookupMandatory(cbMonth);
            BaseFilter.SetLookupMandatory(cbMonthEnd);
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            object reportObject = Activator.CreateInstance(m_ReportType, 0, null, null, CurrentCulture.CultureInfo);
            var report = ((BaseDateReport) reportObject);
            var model = new BaseDateModel(CurrentCulture.ShortName, YearParam, StartMonthParam, EndMonthParam, UseArchive);
            report.SetParameters(manager, model);
            return report;
        }

        protected override void ApplyResources()
        {
            try
            {
                IsResourceLoading = true;
                m_MonthCollection = null;

                m_HasLoad = false;
                base.ApplyResources();

                m_Resources.ApplyResources(cbMonth, "cbMonth");
                m_Resources.ApplyResources(label2, "label2");
                m_Resources.ApplyResources(label1, "label1");
                m_Resources.ApplyResources(StartMonthLabel, "StartMonthLabel");
                m_Resources.ApplyResources(EndMonthLabel, "EndMonthLabel");
                if (IsMonthRange)
                {
                    label2.Text = StartMonthLabel.Text;
                }
                // Note: do not load resources for spinEdit because it reset it's value
                //m_Resources.ApplyResources(spinEdit, "spinEdit");

                ApplyLookupResources(cbMonth, MonthCollection, StartMonthParam, label2.Text);
                ApplyLookupResources(cbMonthEnd, MonthCollection, EndMonthParam, EndMonthLabel.Text);
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
        }

        private List<ItemWrapper> MonthCollection
        {
            get
            {
                if (m_MonthCollection == null)
                {
                    m_MonthCollection = CreateMonthCollection();
                }
                return m_MonthCollection;
            }
        }

        private void spinEdit_EditValueChanged(object sender, EventArgs e)
        {
            ReloadReportIfFormLoaded(spinEdit);
        }

        private void cbMonth_EditValueChanged(object sender, EventArgs e)
        {
            CorrectMonthRange();
            ReloadReportIfFormLoaded(cbMonth);

            cbMonthEnd.Enabled = true;
        }

        private void cbMonthEnd_EditValueChanged(object sender, EventArgs e)
        {
            CorrectMonthRange();
            ReloadReportIfFormLoaded(cbMonthEnd);
        }

        private void CorrectMonthRange()
        {
            if ((cbMonthEnd.EditValue != null) && (cbMonth.EditValue != null))
            {
                var startMonth = ((ItemWrapper) (cbMonth.EditValue));
                var endMonth = ((ItemWrapper) (cbMonthEnd.EditValue));
                if (endMonth.Number < startMonth.Number)
                {
                    using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                    {
                        cbMonthEnd.EditValue = cbMonth.EditValue;
                    }
                }
            }
        }

        private void cbMonth_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete && sender is LookUpEdit)
            {
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
                    if (sender == cbMonth)
                    {
                        cbMonth.EditValue = null;
                        cbMonthEnd.EditValue = null;
                        cbMonthEnd.Enabled = false;
                    }
                    if (sender == cbMonthEnd)
                    {
                        cbMonthEnd.EditValue = null;
                    }
                }
                ReloadReportIfFormLoaded((LookUpEdit) sender);
            }
        }

        public static List<ItemWrapper> CreateMonthCollection()
        {
            var defaultMonth = new[]
                {
                    "January", "February", "March", "April", "May", "June", "July", "August",
                    "September", "October", "November", "December"
                };
            return CreateCollection(defaultMonth, "cbMonth");
        }

        public static List<ItemWrapper> CreateCounterCollection()
        {
            var defaults = new[] {"Absolute number", "For 10.000 population", "For 100.000 population", "For 1.000.000 population"};
            return CreateCollection(defaults, "cbCounter");
        }

        public static List<ItemWrapper> CreatePeriodTypeCollection()
        {
            var defaults = new[] {"Year", "Half-year", "Quarter", "Month"};
            return CreateCollection(defaults, "cbPeriodType");
        }

        public static List<ItemWrapper> CreateHalfYearCollection()
        {
            return CreateCollection(new[] {"I", "II"}, "cbHalfYear");
        }

        public static List<ItemWrapper> CreateQuarterCollection()
        {
            return CreateCollection(new[] {"1", "2", "3", "4"}, "cbQuarter");
        }

        public static List<ItemWrapper> CreateCollection(string[] englishDefaults, string resourcename)
        {
            var collection = new List<ItemWrapper>();

            for (int index = 0; index < englishDefaults.Length; index++)
            {
                string counterName = m_Resources.GetString(resourcename + index);
                if (String.IsNullOrEmpty(counterName))
                {
                    counterName = englishDefaults[index];
                }

                collection.Add(new ItemWrapper(counterName, index + 1));
            }
            return collection;
        }
    }
}