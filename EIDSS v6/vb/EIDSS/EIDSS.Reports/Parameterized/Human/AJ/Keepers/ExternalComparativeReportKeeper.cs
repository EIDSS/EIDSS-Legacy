using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;
using eidss.winclient.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class ExternalComparativeReportKeeper : BaseReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (ExternalComparativeReportKeeper));
        private readonly ComponentResourceManager m_BaseResources = new ComponentResourceManager(typeof (BaseComparativeReportKeeper));
        private List<ItemWrapper> m_MonthCollection;

        public ExternalComparativeReportKeeper()
            : base(new Dictionary<string, string>())
        {
            ReportType = typeof (ExternalComparativeReport);
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
            get { return m_MonthCollection ?? (m_MonthCollection = FilterHelper.GetWinMonthList()); }
        }

        #endregion

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            long? firstRegionID = region1Filter.RegionId > 0 ? (long?) region1Filter.RegionId : null;
            long? firstRayonID = rayon1Filter.RayonId > 0 ? (long?) rayon1Filter.RayonId : null;

            
            var model = new ExternalComparativeSurrogateModel(CurrentCulture.ShortName,
                firstRegionID, firstRayonID,
                Year1Param, Year2Param,
                StartMonthParam, EndMonthParam,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);

            var report = (ExternalComparativeReport) CreateReportObject();
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

//                m_Resources.ApplyResources(StartMonthLookUp, "StartMonthLookUp");
//                m_Resources.ApplyResources(EndMonthLookUp, "EndMonthLookUp");
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
                region1Filter.Top = rayon1Filter.Top + 1;


                if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
                {
                    LocationHelper.SetDefaultFilters(manager, ContextKeeper, region1Filter, rayon1Filter);
                }

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
        }

        private void seYear2_EditValueChanged(object sender, EventArgs e)
        {
            CorrectYearRange();
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
                LocationHelper.RegionFilterValueChanged(region1Filter, rayon1Filter, e);
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
                LocationHelper.RayonFilterValueChanged(region1Filter, rayon1Filter, e);
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
            }
        }

        private void StartMonthLookUp_EditValueChanged(object sender, EventArgs e)
        {
            CorrectMonthRange();
        }

        private void EndMonthLookUp_EditValueChanged(object sender, EventArgs e)
        {
            CorrectMonthRange();
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