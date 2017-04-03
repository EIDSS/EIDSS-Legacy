using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.winclient.BasePanel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.OperationContext;
using EIDSS.Reports.Parameterized.Filters;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;
using bv.common.win;
using bv.model.BLToolkit;
using bv.winclient.Layout;
using eidss.model.Reports.AZ;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class ExternalComparativeReportKeeper : BaseReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (ExternalComparativeReportKeeper));
        private readonly ComponentResourceManager m_BaseResources = new ComponentResourceManager(typeof(BaseComparativeReportKeeper));
        private List<ItemWrapper> m_MonthCollection;

        public ExternalComparativeReportKeeper()
            : base(new Dictionary<string, string>())
        {
            InitializeComponent();
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                SetMandatory();

                Year2SpinEdit.Value = DateTime.Now.Year;
                Year1SpinEdit.Value = DateTime.Now.Year - 1;

                BindLookup(StartMonthLookUp, MonthCollection, EndYearLabel.Text);
                BindLookup(EndMonthLookUp, MonthCollection, EndMonthLabel.Text);

                StartMonthLookUp.EditValue = MonthCollection[0];
                EndMonthLookUp.EditValue = MonthCollection[DateTime.Now.Month - 1];
            }

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

        protected List<ItemWrapper> MonthCollection
        {
            get { return m_MonthCollection ?? (m_MonthCollection = BaseDateKeeper.CreateMonthCollection()); }
        }

        #endregion

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFirstLoading))
            {
                FiltersHelper.SetDefaultFiltes(manager, ContextKeeper, region1Filter, rayon1Filter);
            }
            long? firstRegionID = region1Filter.RegionId > 0 ? (long?) region1Filter.RegionId : null;
            long? firstRayonID = rayon1Filter.RayonId > 0 ? (long?) rayon1Filter.RayonId : null;

            var report = new ExternalComparativeReport();
            var model = new ExternalComparativeSurrogateModel(CurrentCulture.ShortName,
                                                              firstRegionID, firstRayonID,
                                                              Year1Param, Year2Param,
                                                              StartMonthParam, EndMonthParam
                                                              , UseArchive
                );
            report.SetParameters(manager, model);
            return report;
        }

        protected override void ApplyResources()
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;
                base.ApplyResources();

                m_Resources.ApplyResources(StartMonthLookUp, "StartMonthLookUp");
                m_Resources.ApplyResources(EndMonthLookUp, "EndMonthLookUp");
                m_Resources.ApplyResources(StartYearLabel, "StartYearLabel");
                m_Resources.ApplyResources(EndYearLabel, "EndYearLabel");
                m_BaseResources.ApplyResources(StartMonthLabel, "StartMonthLabel");
                m_BaseResources.ApplyResources(EndMonthLabel, "EndMonthLabel");

                ApplyLookupResources(StartMonthLookUp, MonthCollection, StartMonthParam, EndYearLabel.Text);
                ApplyLookupResources(EndMonthLookUp, MonthCollection, EndMonthParam, EndMonthLabel.Text);

                // Note: do not load resources for spinEdit because it reset it's value
                //m_Resources.ApplyResources(spinEdit, "spinEdit");
                region1Filter.DefineBinding();
                rayon1Filter.DefineBinding();
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
        }

        public void SetMandatory()
        {
            LayoutCorrector.SetStyleController(Year1SpinEdit, LayoutCorrector.MandatoryStyleController);
            LayoutCorrector.SetStyleController(Year2SpinEdit, LayoutCorrector.MandatoryStyleController);
        }

        private void seYear1_EditValueChanged(object sender, EventArgs e)
        {
            CorrectYearRange();
            ReloadReportIfFormLoaded(Year1SpinEdit);
        }

        private void seYear2_EditValueChanged(object sender, EventArgs e)
        {
            CorrectYearRange();
            ReloadReportIfFormLoaded(Year2SpinEdit);
        }

        private void CorrectYearRange()
        {
            if (Year2Param <= Year1Param)
            {
                if (!ContextKeeper.ContainsContext(ContextValue.ReportFilterLoading))
                {
                    if (!BaseFormManager.IsReportsServiceRunning && !BaseFormManager.IsAvrServiceRunning)
                    {
                        ErrorForm.ShowWarning("msgComparativeReportCorrectYear", "Year 1 shall be greater than Year 2");
                    }
                }
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
                    Year1SpinEdit.EditValue = Year2Param - 1;
                }
            }
        }

        private void region1Filter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                FiltersHelper.RegionFilterValueChanged(this, region1Filter, rayon1Filter, e);
            }
        }

        private void rayon1Filter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFilterResetting))
            {
                return;
            }
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                FiltersHelper.RayonFilterValueChanged(this, region1Filter, rayon1Filter, e);
            }
        }

        private void MonthLookUp_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete && sender is LookUpEdit)
            {
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
                    StartMonthLookUp.EditValue = null;
                    EndMonthLookUp.EditValue = null;
                }
                ReloadReportIfFormLoaded((LookUpEdit) sender);
            }
        }

        private void StartMonthLookUp_EditValueChanged(object sender, EventArgs e)
        {
            CorrectMonthRange();
            ReloadReportIfFormLoaded(StartMonthLookUp);
        }

        private void EndMonthLookUp_EditValueChanged(object sender, EventArgs e)
        {
            CorrectMonthRange();
            ReloadReportIfFormLoaded(EndMonthLookUp);
        }

        private void CorrectMonthRange()
        {
            if ((EndMonthLookUp.EditValue != null) && (StartMonthLookUp.EditValue != null))
            {
                var startMonth = ((ItemWrapper) (StartMonthLookUp.EditValue));
                var endMonth = ((ItemWrapper) (EndMonthLookUp.EditValue));
                if (endMonth.Number < startMonth.Number)
                {
                    using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                    {
                        EndMonthLookUp.EditValue = StartMonthLookUp.EditValue;
                    }
                }
            }
        }
    }
}