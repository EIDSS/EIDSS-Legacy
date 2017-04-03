using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public sealed partial class ComparativeTwoYearsAZReportKeeper : BaseReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (ComparativeTwoYearsAZReportKeeper));

        private List<ItemWrapper> m_CounterCollection;

        public ComparativeTwoYearsAZReportKeeper()
            : base(new Dictionary<string, string>())
        {
            ReportType = typeof (ComparativeTwoYearsAZReport);
            InitializeComponent();
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                SetMandatory();

                Year2SpinEdit.Value = DateTime.Now.Year;
                Year1SpinEdit.Value = DateTime.Now.Year - 1;

                CounterLookUp.EditValue = CounterCollection[0];
            }

            m_HasLoad = true;
        }

        #region Properties

        [Browsable(false)]
        private int Year1Param
        {
            get { return (int) Year1SpinEdit.Value; }
        }

        [Browsable(false)]
        private int Year2Param
        {
            get { return (int) Year2SpinEdit.Value; }
        }

        [Browsable(false)]
        private long? OrganizationIdParam
        {
            get { return OrganizationFilter.EditValueId > 0 ? (long?) OrganizationFilter.EditValueId : null; }
        }

        [Browsable(false)]
        private long? RegionIdParam
        {
            get { return regionFilter.RegionId > 0 ? (long?) regionFilter.RegionId : null; }
        }

        [Browsable(false)]
        private long? RayonIdParam
        {
            get { return rayonFilter.RayonId > 0 ? (long?) rayonFilter.RayonId : null; }
        }

        [Browsable(false)]
        private long? DiagnosisIdParam
        {
            get { return diagnosisFilter.EditValueId > 0 ? (long?) diagnosisFilter.EditValueId : null; }
        }

        [Browsable(false)]
        private int CounterParam
        {
            get
            {
                return (CounterLookUp.EditValue == null)
                    ? -1
                    : ((ItemWrapper) CounterLookUp.EditValue).Number;
            }
        }

        private List<ItemWrapper> CounterCollection
        {
            get { return m_CounterCollection ?? (m_CounterCollection = FilterHelper.GetWinCounterList()); }
        }

        #endregion

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }
            var model = new ComparativeTwoYearsSurrogateModel(CurrentCulture.ShortName,
                Year1Param, Year2Param,
                CounterParam, DiagnosisIdParam, diagnosisFilter.SelectedText,
                RegionIdParam, RayonIdParam,
                regionFilter.SelectedText, rayonFilter.SelectedText,
                OrganizationIdParam, OrganizationFilter.SelectedText,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);
            var reportAz = (ComparativeTwoYearsAZReport) CreateReportObject();
            reportAz.SetParameters(manager, model);
            return reportAz;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;

                base.ApplyResources(manager);

                m_CounterCollection = null;
                ApplyLookupResources(CounterLookUp, CounterCollection, CounterParam, CounterLabel.Text);

                m_Resources.ApplyResources(StartYearLabel, "StartYearLabel");
                m_Resources.ApplyResources(EndYearLabel, "EndYearLabel");

                m_Resources.ApplyResources(CounterLabel, "CounterLabel");
                //m_Resources.ApplyResources(OrganizationFilter, "OrganizationFilter");
                OrganizationFilter.DefineBinding();

                //m_Resources.ApplyResources(diagnosisFilter, "diagnosisFilter");
                diagnosisFilter.DefineBinding();

                regionFilter.DefineBinding();
                rayonFilter.DefineBinding();

                if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
                {
                    LocationHelper.SetDefaultFilters(manager, ContextKeeper, regionFilter, rayonFilter);
                }
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
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

        private void CounterLookUp_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                OrganizationFilter.Enabled = !RegionIdParam.HasValue && !RayonIdParam.HasValue;
                LocationHelper.RegionFilterValueChanged(regionFilter, rayonFilter, e);
            }
        }

        private void rayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                OrganizationFilter.Enabled = !RegionIdParam.HasValue && !RayonIdParam.HasValue;
                LocationHelper.RayonFilterValueChanged(regionFilter, rayonFilter, e);
            }
        }

        private void OrganizationFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            bool hasOrg = OrganizationIdParam.HasValue;
            regionFilter.Enabled = !hasOrg;
            rayonFilter.Enabled = !hasOrg;
        }
    }
}