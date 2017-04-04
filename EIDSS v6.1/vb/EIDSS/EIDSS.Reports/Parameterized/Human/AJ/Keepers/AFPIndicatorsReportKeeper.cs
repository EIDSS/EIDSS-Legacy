using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.model.BLToolkit;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class AFPIndicatorsReportKeeper : BaseYearKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (AFPIndicatorsReportKeeper));
        private List<ItemWrapper> m_MonthCollection;
        private List<ItemWrapper> m_HalfYearCollection;
        private List<ItemWrapper> m_QuarterCollection;
        private List<ItemWrapper> m_PeriodTypeCollection;

        public AFPIndicatorsReportKeeper(bool isMain) 
        {
            ReportType = isMain
               ? typeof(MainAFPIndicatorsReport)
               : typeof(AdditionalAFPIndicatorsReport);
            InitializeComponent();
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                BaseFilter.SetLookupMandatory(PeriodTypeLookUp);
                BaseFilter.SetLookupMandatory(MonthLookUp);
                BaseFilter.SetLookupMandatory(QuarterLookUp);
                BaseFilter.SetLookupMandatory(HalfYearLookUp);

                BindLookup(MonthLookUp, MonthCollection, PeriodLabel.Text);
                BindLookup(QuarterLookUp, QuarterCollection, PeriodLabel.Text);
                BindLookup(HalfYearLookUp, HalfYearCollection, PeriodLabel.Text);
                BindLookup(PeriodTypeLookUp, PeriodTypeCollection, PeriodTypeLabel.Text);

                HalfYearLookUp.Location = QuarterLookUp.Location = MonthLookUp.Location;

                PeriodTypeLookUp.EditValue = PeriodTypeCollection[0];
                MonthLookUp.EditValue = MonthCollection[0];
                QuarterLookUp.EditValue = QuarterCollection[0];
                HalfYearLookUp.EditValue = HalfYearCollection[0];
            }
            m_HasLoad = true;
        }

        public AFPIndicatorsReportKeeper():this(false)
        {
           
        }

        [Browsable(false)]
        protected int? PeriodTypeParam
        {
            get
            {
                return (PeriodTypeLookUp.EditValue == null)
                    ? (int?) null
                    : ((ItemWrapper) PeriodTypeLookUp.EditValue).Number;
            }
        }

        [Browsable(false)]
        protected int? MonthParam
        {
            get
            {
                return (MonthLookUp.EditValue == null)
                    ? (int?) null
                    : ((ItemWrapper) MonthLookUp.EditValue).Number;
            }
        }

        [Browsable(false)]
        protected int? QuarterParam
        {
            get
            {
                return (QuarterLookUp.EditValue == null)
                    ? (int?) null
                    : ((ItemWrapper) QuarterLookUp.EditValue).Number;
            }
        }

        [Browsable(false)]
        protected int? HalfYearParam
        {
            get
            {
                return (HalfYearLookUp.EditValue == null)
                    ? (int?) null
                    : ((ItemWrapper) HalfYearLookUp.EditValue).Number;
            }
        }

        [Browsable(false)]
        protected List<ItemWrapper> MonthCollection
        {
            get { return m_MonthCollection ?? (m_MonthCollection = FilterHelper.GetWinMonthList()); }
        }

        [Browsable(false)]
        protected List<ItemWrapper> HalfYearCollection
        {
            get { return m_HalfYearCollection ?? (m_HalfYearCollection = FilterHelper.GetWinHalfYearList()); }
        }

        [Browsable(false)]
        protected List<ItemWrapper> QuarterCollection
        {
            get { return m_QuarterCollection ?? (m_QuarterCollection = FilterHelper.GetWinQuarterList()); }
        }

        [Browsable(false)]
        protected List<ItemWrapper> PeriodTypeCollection
        {
            get { return m_PeriodTypeCollection ?? (m_PeriodTypeCollection = FilterHelper.GetWinPeriodTypeList()); }
        }

        [Browsable(false)]
        protected bool IsMonthSelected
        {
            get { return (PeriodTypeLookUp.EditValue == PeriodTypeCollection[3]); }
        }

        [Browsable(false)]
        protected bool IsQuarterSelected
        {
            get { return (PeriodTypeLookUp.EditValue == PeriodTypeCollection[2]); }
        }

        [Browsable(false)]
        protected bool IsHalfYearSelected
        {
            get { return (PeriodTypeLookUp.EditValue == PeriodTypeCollection[1]); }
        }

        [Browsable(false)]
        protected int PeriodType
        {
            get
            {
                var periodTypeWrapper = PeriodTypeLookUp.EditValue as ItemWrapper;
                int periodType = (periodTypeWrapper != null)
                    ? PeriodTypeCollection.IndexOf(periodTypeWrapper)
                    : 0;
                return periodType;
            }
        }

        [Browsable(false)]
        protected int Period
        {
            get
            {
                ItemWrapper wrapper = null;
                if (IsHalfYearSelected)
                {
                    wrapper = HalfYearLookUp.EditValue as ItemWrapper;
                }
                else if (IsQuarterSelected)
                {
                    wrapper = QuarterLookUp.EditValue as ItemWrapper;
                }
                else if (IsMonthSelected)
                {
                    wrapper = MonthLookUp.EditValue as ItemWrapper;
                }
                int period = wrapper != null
                    ? wrapper.Number - 1
                    : 0;
                return period;
            }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            var model = new AFPModel(CurrentCulture.ShortName, YearParam, Period, PeriodType, UseArchive);

            dynamic report = CreateReportObject();
            report.SetParameters( model,manager,archiveManager);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;

                m_MonthCollection = null;
                m_HalfYearCollection = null;
                m_QuarterCollection = null;
                m_PeriodTypeCollection = null;

                base.ApplyResources(manager);

                m_Resources.ApplyResources(PeriodTypeLabel, "PeriodTypeLabel");
                //  m_Resources.ApplyResources(PeriodTypeLookUp, "PeriodTypeLookUp");
                m_Resources.ApplyResources(PeriodLabel, "PeriodLabel");
                //  m_Resources.ApplyResources(MonthLookUp, "MonthLookUp");
                //   m_Resources.ApplyResources(QuarterLookUp, "QuarterLookUp");
                //   m_Resources.ApplyResources(HalfYearLookUp, "HalfYearLookUp");

                ApplyLookupResources(PeriodTypeLookUp, PeriodTypeCollection, PeriodTypeParam, PeriodTypeLabel.Text);
                ApplyLookupResources(MonthLookUp, MonthCollection, MonthParam, PeriodLabel.Text);
                ApplyLookupResources(QuarterLookUp, QuarterCollection, QuarterParam, PeriodLabel.Text);
                ApplyLookupResources(HalfYearLookUp, HalfYearCollection, HalfYearParam, PeriodLabel.Text);

                HalfYearLookUp.Location = QuarterLookUp.Location = MonthLookUp.Location;
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
        }

        private void PeriodTypeLookUp_EditValueChanged(object sender, EventArgs e)
        {
            HalfYearLookUp.Visible = IsHalfYearSelected;
            QuarterLookUp.Visible = IsQuarterSelected;
            MonthLookUp.Visible = IsMonthSelected;
            PeriodLabel.Visible = HalfYearLookUp.Visible || QuarterLookUp.Visible || MonthLookUp.Visible;
        }
    }
}