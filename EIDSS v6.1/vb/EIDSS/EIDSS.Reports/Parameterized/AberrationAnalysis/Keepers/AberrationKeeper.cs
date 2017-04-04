using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.Layout;
using eidss.model.Reports.Common;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;

namespace EIDSS.Reports.Parameterized.AberrationAnalysis.Keepers
{
    public partial class AberrationKeeper : BaseIntervalLocationKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (AberrationKeeper));
        private List<ItemWrapper> m_TimeUnitsCollection;
        private List<ItemWrapper> m_DateFieldsCollection;
        private List<ItemWrapper> m_AnalysisMethodsCollection;
        private string[] m_DateFields;
        private bool m_FirstTime = true;
        private int m_Type;

        public AberrationKeeper()
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                try
                {
                    IsResourceLoading = true;
                    InitializeComponent();
                    dtEnd.EditValue = TruncateDate(DateTime.Now);
                    dtStart.EditValue = TruncateDate(DateTime.Now.AddMonths(-1));

                    BindLookup(TimeUnitsLookUp, TimeUnitsCollection, TimeUnitsLabel.Text);
                    TimeUnitsLookUp.EditValue = TimeUnitsCollection[1];

                    BindLookup(AnalysisMethodLookUp, AnalysisMethodCollection, AnalysisMethodLabel.Text);
                    AnalysisMethodLookUp.EditValue = AnalysisMethodCollection[0];

                    threshold.Value = 2.5M;
                    baseline.Value = 4;
                    lag.Value = 1;

                    DateFieldsLookUp.SetMandatory();
                    LayoutCorrector.SetStyleController(AnalysisMethodLookUp, LayoutCorrector.MandatoryStyleController);
                    LayoutCorrector.SetStyleController(TimeUnitsLookUp, LayoutCorrector.MandatoryStyleController);
                    LayoutCorrector.SetStyleController(threshold, LayoutCorrector.MandatoryStyleController);
                    LayoutCorrector.SetStyleController(baseline, LayoutCorrector.MandatoryStyleController);
                    LayoutCorrector.SetStyleController(lag, LayoutCorrector.MandatoryStyleController);
                }
                finally
                {
                    IsResourceLoading = false;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int intType
        {
            get { return m_Type; }
            set
            {
                m_Type = value;
                DateFieldsLookUp.intType = m_Type;
            }
        }

        [Browsable(false)]
        protected int TimeUnitsParam
        {
            get { return ((ItemWrapper) TimeUnitsLookUp.EditValue).Number; }
        }

        [Browsable(false)]
        protected string TimeUnitsTextParam
        {
            get { return TimeUnitsLookUp.Text; }
        }

        [Browsable(false)]
        protected decimal ThresholdParam
        {
            get { return threshold.Value; }
        }

        [Browsable(false)]
        protected int BaselineParam
        {
            get { return (int) baseline.Value; }
        }

        [Browsable(false)]
        protected int LagParam
        {
            get { return (int) lag.Value; }
        }

        [Browsable(false)]
        protected List<ItemWrapper> DateFieldsCollection
        {
            get { return m_DateFieldsCollection ?? (m_DateFieldsCollection = FilterHelper.GetWinAberrationDateFieldsList(m_Type)); }
        }

        [Browsable(false)]
        protected string[] DateFieldsParam
        {
            get { return m_DateFields; }
        }

        [Browsable(false)]
        protected string DateFieldsTextParam { get; set; }

        [Browsable(false)]
        protected List<ItemWrapper> TimeUnitsCollection
        {
            get { return m_TimeUnitsCollection ?? (m_TimeUnitsCollection = FilterHelper.GetWinTimeUnitsList()); }
        }

        [Browsable(false)]
        protected List<ItemWrapper> AnalysisMethodCollection
        {
            get { return m_AnalysisMethodsCollection ?? (m_AnalysisMethodsCollection = FilterHelper.GetWinAnalysisMethodsList()); }
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;

                m_TimeUnitsCollection = null;
                m_DateFieldsCollection = null;

                base.ApplyResources(manager);

                m_Resources.ApplyResources(TimeUnitsLabel, "TimeUnitsLabel");
                m_Resources.ApplyResources(TimeUnitsLookUp, "TimeUnitsLookUp");
                ApplyLookupResources(TimeUnitsLookUp, TimeUnitsCollection, TimeUnitsParam, TimeUnitsLabel.Text);

                DateFieldsLookUp.DefineBinding();
                m_Resources.ApplyResources(DateFieldsLookUp, "DateFieldsLookUp");

                if (m_FirstTime)
                {
                    dtStart.EditValue = null;
                    dtEnd.EditValue = null;
                    m_FirstTime = false;
                }
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
        }

        private void TimeUnitsLookUp_EditValueChanged(object sender, EventArgs e)
        {
            LagUnits.Text = TimeUnitsTextParam;
            BaselineUnits.Text = TimeUnitsTextParam;
        }

        private void DateFieldsLookUp_EditValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_DateFields = e.KeyArray;
            DateFieldsTextParam = e.TextResult;
        }
    }
}