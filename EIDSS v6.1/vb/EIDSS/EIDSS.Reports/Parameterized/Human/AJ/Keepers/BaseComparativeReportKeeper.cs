using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.Layout;
using DevExpress.XtraEditors.Controls;
using eidss.model.Reports.Common;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class BaseComparativeReportKeeper : BaseReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (BaseComparativeReportKeeper));
        private List<ItemWrapper> m_MonthCollection;
        private List<ItemWrapper> m_CounterCollection;

        public BaseComparativeReportKeeper()
            : base(new Dictionary<string, string>())
        {
            InitializeComponent();
            SetMandatory();

            Year2SpinEdit.Value = DateTime.Now.Year;
            Year1SpinEdit.Value = DateTime.Now.Year - 1;

            BindLookup(StartMonthLookUp, MonthCollection, EndYearLabel.Text);
            BindLookup(EndMonthLookUp, MonthCollection, EndMonthLabel.Text);

            StartMonthLookUp.EditValue = MonthCollection[0];
            EndMonthLookUp.EditValue = MonthCollection[DateTime.Now.Month - 1];
            //WinUtils.RemoveClearButton(EndMonthLookUp);

            CounterLookUp.EditValue = CounterCollection[0];

            m_HasLoad = true;
        }

        #region Properties

        [Browsable(false)]
        protected int Year1Param
        {
            get { return (int) Year1SpinEdit.Value; }
        }

        [Browsable(false)]
        protected int Year2Param
        {
            get { return (int) Year2SpinEdit.Value; }
        }

        [Browsable(false)]
        protected int? StartMonthParam
        {
            get
            {
                return (StartMonthLookUp.EditValue == null)
                    ? (int?) null
                    : ((ItemWrapper) StartMonthLookUp.EditValue).Number;
            }
        }

        [Browsable(false)]
        protected int? EndMonthParam
        {
            get
            {
                return (EndMonthLookUp.EditValue == null)
                    ? (int?) null
                    : ((ItemWrapper) EndMonthLookUp.EditValue).Number;
            }
        }

        [Browsable(false)]
        protected int CounterParam
        {
            get
            {
                return (CounterLookUp.EditValue == null)
                    ? -1
                    : ((ItemWrapper) CounterLookUp.EditValue).Number;
            }
        }

        [Browsable(false)]
        protected long? FirstRegionIdParam
        {
            get { return region1Filter.RegionId > 0 ? (long?) region1Filter.RegionId : null; }
        }

        [Browsable(false)]
        protected long? FirstRayonIdParam
        {
            get { return rayon1Filter.RayonId > 0 ? (long?) rayon1Filter.RayonId : null; }
        }

        [Browsable(false)]
        protected long? SecondRegionIdParam
        {
            get { return region2Filter.RegionId > 0 ? (long?) region2Filter.RegionId : null; }
        }

        [Browsable(false)]
        protected long? SecondRayonIdParam
        {
            get { return rayon2Filter.RayonId > 0 ? (long?) rayon2Filter.RayonId : null; }
        }

        protected List<ItemWrapper> MonthCollection
        {
            get { return m_MonthCollection ?? (m_MonthCollection = FilterHelper.GetWinMonthList()); }
        }

        protected List<ItemWrapper> CounterCollection
        {
            get { return m_CounterCollection ?? (m_CounterCollection = FilterHelper.GetWinCounterList()); }
        }

        #endregion

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            m_MonthCollection = null;
            m_CounterCollection = null;
            base.ApplyResources(manager);

            m_Resources.ApplyResources(StartYearLabel, "StartYearLabel");
            m_Resources.ApplyResources(EndYearLabel, "EndYearLabel");
            m_Resources.ApplyResources(StartMonthLabel, "StartMonthLabel");
            m_Resources.ApplyResources(EndMonthLabel, "EndMonthLabel");
            m_Resources.ApplyResources(CounterLabel, "CounterLabel");

            // Note: do not load resources for spinEdit because it reset it's value
            //m_Resources.ApplyResources(spinEdit, "spinEdit");

            ApplyLookupResources(StartMonthLookUp, MonthCollection, StartMonthParam, EndYearLabel.Text);
            ApplyLookupResources(EndMonthLookUp, MonthCollection, EndMonthParam, EndMonthLabel.Text);
            ApplyLookupResources(CounterLookUp, CounterCollection, CounterParam, CounterLabel.Text);

            region1Filter.DefineBinding();
            rayon1Filter.DefineBinding();
            region2Filter.DefineBinding();
            rayon2Filter.DefineBinding();

            region1Filter.Top = 56;
            rayon1Filter.Top = 55;
            region2Filter.Top = 100;
            rayon2Filter.Top = 99;
        }

        protected virtual void CorrectYearRange()
        {
            if (Year2Param <= Year1Param)
            {
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
                {
                    Year2SpinEdit.EditValue = Year1Param + 1;
                }
            }
        }

        private void SetMandatory()
        {
            BaseFilter.SetLookupMandatory(CounterLookUp);
            LayoutCorrector.SetStyleController(Year1SpinEdit, LayoutCorrector.MandatoryStyleController);
            LayoutCorrector.SetStyleController(Year2SpinEdit, LayoutCorrector.MandatoryStyleController);
        }

        private void seYear1_EditValueChanged(object sender, EventArgs e)
        {
            CorrectYearRange();
        }

        private void seYear2_EditValueChanged(object sender, EventArgs e)
        {
            CorrectYearRange();
        }

        private void StartMonth_EditValueChanged(object sender, EventArgs e)
        {
            CorrectLookupRange(StartMonthLookUp, EndMonthLookUp, MonthLookupEnum.Start);
        }

        private void EndMonth_EditValueChanged(object sender, EventArgs e)
        {
            CorrectLookupRange(StartMonthLookUp, EndMonthLookUp, MonthLookupEnum.End);
        }

        private void cbMonth_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ClearLookUpButtonClick(sender, e, StartMonthLookUp, EndMonthLookUp);
        }

        private void Region1_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RegionFilterValueChanged(region1Filter, rayon1Filter, e);
            }
        }

        private void Rayon1_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFilterResetting))
            {
                return;
            }
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RayonFilterValueChanged(region1Filter, rayon1Filter, e);
            }
        }

        private void Region2_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RegionFilterValueChanged(region2Filter, rayon2Filter, e);
            }
        }

        private void Rayon2_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFilterResetting))
            {
                return;
            }
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RayonFilterValueChanged(region2Filter, rayon2Filter, e);
            }
        }
    }
}