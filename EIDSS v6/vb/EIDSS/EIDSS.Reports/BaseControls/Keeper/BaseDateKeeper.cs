using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using eidss.model.Reports.Common;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public partial class BaseDateKeeper : BaseReportKeeper
    {
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

            ReportType = reportType;
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

        [Browsable(false)]
        [DefaultValue(false)]
        protected bool MonthEndFollowsMonth { get; set; }

        public void SetMandatory()
        {
            BaseFilter.SetLookupMandatory(cbMonth);
            BaseFilter.SetLookupMandatory(cbMonthEnd);
        }

        protected void RemoveClearButtonMonthEnd()
        {
            WinUtils.RemoveClearButton(cbMonthEnd);
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            var report = ((BaseDateReport) CreateReportObject());
            var model = new BaseDateModel(CurrentCulture.ShortName, YearParam, StartMonthParam, EndMonthParam, UseArchive);
            report.SetParameters(manager, model);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                m_MonthCollection = null;

                m_HasLoad = false;
                base.ApplyResources(manager);

                label2.Text = m_Resources.GetString("label2.Text");
                label1.Text = m_Resources.GetString("label1.Text");
                StartMonthLabel.Text = m_Resources.GetString("StartMonthLabel.Text");
                EndMonthLabel.Text = m_Resources.GetString("EndMonthLabel.Text");
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
            get { return m_MonthCollection ?? (m_MonthCollection = FilterHelper.GetWinMonthList()); }
        }

        private bool m_SetMonthEndEqualToMonth;

        private void cbMonth_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (Utils.IsEmpty(e.OldValue) && MonthEndFollowsMonth)
            {
                m_SetMonthEndEqualToMonth = true;
            }
        }

        private void cbMonth_EditValueChanged(object sender, EventArgs e)
        {
            if (m_SetMonthEndEqualToMonth)
            {
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
                    cbMonthEnd.EditValue = cbMonth.EditValue;
                }
                m_SetMonthEndEqualToMonth = false;
            }
            CorrectMonthRange();

            cbMonthEnd.Enabled = true;
        }

        private void cbMonthEnd_EditValueChanged(object sender, EventArgs e)
        {
            CorrectMonthRange();
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
            }
        }

        protected void SetCurrentStartMonth()
        {
            SetCurrentMonth(cbMonth);
        }

        private void SetCurrentMonth(LookUpEdit lookUpEdit)
        {
            lookUpEdit.ItemIndex = DateTime.Now.Month - 1;
            lookUpEdit.EditValue = MonthCollection[DateTime.Now.Month - 1];
        }
    }
}