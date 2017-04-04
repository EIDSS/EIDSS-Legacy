using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors.Controls;
using eidss.model.Core;
using eidss.model.Reports.AZ;
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

        public string[] m_CheckedCounters = new string[0];

        public ComparativeTwoYearsAZReportKeeper()
            : base(new Dictionary<string, string>())
        {
            ReportType = typeof (ComparativeTwoYearsAZReport);
            InitializeComponent();
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                SetMandatory();

                Year1SpinEdit.Value = DateTime.Now.Year - 1;
                Year2SpinEdit.Value = DateTime.Now.Year;

                Year1SpinEdit.Properties.MaxValue = DateTime.Now.Year - 1;
                Year2SpinEdit.Properties.MaxValue = DateTime.Now.Year;

                regionFilter.ShowTransportCHE = true;
                rayonFilter.ShowTransportCHE = true;

                CounterFilter.SelectAllItemVisible = false;
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

        #endregion

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }
            var model = new ComparativeTwoYearsSurrogateModel(CurrentCulture.ShortName,
                Year1Param, Year2Param,
                m_CheckedCounters,
                DiagnosisIdParam, diagnosisFilter.SelectedText,
                RegionIdParam, RayonIdParam,
                regionFilter.SelectedText, rayonFilter.SelectedText,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);
            var reportAz = (ComparativeTwoYearsAZReport) CreateReportObject();
            reportAz.SetParameters(model, manager, archiveManager);
            return reportAz;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;

                base.ApplyResources(manager);

                m_Resources.ApplyResources(FromLabel, "FromLabel");
                m_Resources.ApplyResources(ToLabel, "ToLabel");

                CounterFilter.DefineBinding();

                diagnosisFilter.DefineBinding();

                regionFilter.DefineBinding();
                rayonFilter.DefineBinding();

                if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
                {
                    LocationHelper.SetDefaultFilters(manager, ContextKeeper, regionFilter, rayonFilter, true);
                    CounterFilter.SetCounter(1);
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
                        ErrorForm.ShowWarning("msgComparativeReportCorrectYear",
                            @"The Year selected in the ""To"" filter shall be less than the Year selected in the ""From"" filter");
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
            CounterFilter.SetMandatory();
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

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RegionFilterValueChanged(regionFilter, rayonFilter, e);
            }
        }

        private void rayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RayonFilterValueChanged(regionFilter, rayonFilter, e);
            }
        }

        private void CounterFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_CheckedCounters = e.KeyArray;
        }

        private void CounterFilter_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }
    }
}