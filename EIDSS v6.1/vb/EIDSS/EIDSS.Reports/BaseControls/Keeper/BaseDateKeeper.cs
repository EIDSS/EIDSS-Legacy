using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPivotGrid.Customization;
using eidss.model.Reports.Common;
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

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected int MaxYear
        {
            get { return (int) spinEdit.Properties.MaxValue; }
            set { spinEdit.Properties.MaxValue = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected int MinYear
        {
            get { return (int) spinEdit.Properties.MinValue; }
            set { spinEdit.Properties.MinValue = value; }
        }

        [Browsable(true)]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected int YearParam
        {
            get { return (int) spinEdit.Value; }
            set { spinEdit.Value = value; }
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

        // for using in override mehtods in child classes
        [Browsable(false)]
        protected LookUpEdit StartMonth
        {
            get { return cbMonth; }
        }

        // for using in override mehtods in child classes
        [Browsable(false)]
        protected LookUpEdit EndMonth
        {
            get { return cbMonthEnd; }
        }

        [Browsable(false)]
        [DefaultValue(false)]
        protected bool MonthEndFollowsMonth { get; set; }

        private List<ItemWrapper> MonthCollection
        {
            get { return m_MonthCollection ?? (m_MonthCollection = FilterHelper.GetWinMonthList()); }
        }

        protected void SetAllowedMonthes(IList<int> allowed )
        {
            var allowedItems = MonthCollection.Where(m => allowed.Contains(m.Number)).ToList();
            BindLookup(cbMonth, allowedItems, label2.Text);
        }

        public void SetMandatory()
        {
            BaseFilter.SetLookupMandatory(cbMonth);
            BaseFilter.SetLookupMandatory(cbMonthEnd);
        }

        protected void RemoveClearButtonMonthEnd()
        {
            WinUtils.RemoveClearButton(cbMonthEnd);
        }

        protected void SetCurrentStartMonth()
        {
            SetCurrentMonth(cbMonth);
        }

        protected void ClearYear()
        {
            spinEdit.EditValue = null;
        }

        private void EndMonthLabel_VisibleChanged(object sender, EventArgs e)
        {
            EndMonthLabel.Visible = IsMonthRange;
        }

        private void SetCurrentMonth(LookUpEdit lookUpEdit)
        {
            lookUpEdit.ItemIndex = DateTime.Now.Month - 1;
            lookUpEdit.EditValue = MonthCollection[DateTime.Now.Month - 1];
        }
        
        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            var report = ((BaseDateReport) CreateReportObject());
            var model = new BaseDateModel(CurrentCulture.ShortName, YearParam, StartMonthParam, EndMonthParam, UseArchive);
            report.SetParameters( model,manager,archiveManager);
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

        protected virtual void cbMonth_EditValueChanging(object sender, ChangingEventArgs e)
        {
        }

        protected virtual void cbMonth_EditValueChanged(object sender, EventArgs e)
        {
            CorrectLookupRange(cbMonth, cbMonthEnd, MonthLookupEnum.Start);
        }

        protected virtual void cbMonthEnd_EditValueChanged(object sender, EventArgs e)
        {
            CorrectLookupRange(cbMonth, cbMonthEnd, MonthLookupEnum.End);
        }

        protected virtual void cbMonth_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ClearLookUpButtonClick(sender, e, cbMonth, cbMonthEnd);
        }

        protected virtual void Year_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}