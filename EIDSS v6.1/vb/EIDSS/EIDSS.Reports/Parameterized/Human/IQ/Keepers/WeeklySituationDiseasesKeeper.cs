using System;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.Core;
using eidss.model.Reports.IQ;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.IQ.Reports;

namespace EIDSS.Reports.Parameterized.Human.IQ.Keepers
{
    public partial class WeeklySituationDiseasesKeeper : BaseYearKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (WeeklySituationDiseasesKeeper));

        public WeeklySituationDiseasesKeeper() : this(true)
        {
        }

        public WeeklySituationDiseasesKeeper(bool isByDistrics)
        {
            ReportType = isByDistrics
                ? typeof (DiseasesByDistrictsReport)
                : typeof (DiseasesByAgeGroupAndSexReport);

            InitializeComponent();

            MaxYear = DateTime.Now.Year;

            weekFilter.ExactFormat = "dd/MM/yyyy";
            weekFilter.SetMandatory();

            regionFilter.SetMandatory();

            m_HasLoad = true;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            long? regionId = regionFilter.RegionId > 0 ? (long?) regionFilter.RegionId : null;
            var model = new SituationOnInfectiousDiseasesSurrogateModel(CurrentCulture.ShortName,
                YearParam, eidss.model.Enums.StatisticPeriodType.Week,  weekFilter.WeekNumber,
                weekFilter.StartDate, weekFilter.EndDate,
                regionId, regionFilter.SelectedText, 
                UseArchive);
            dynamic report = CreateReportObject();
            report.SetParameters( model,manager,archiveManager);
            return report;
        }

        protected override void OnBeforeYearChange()
        {
            if (!m_HasLoad || ContextKeeper.ContainsContext(ContextValue.ReportLoading))
            {
                return;
            }
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                
                weekFilter.YearNumber = YearParam;
                weekFilter.UpdateWeekNumber();
            }
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;
                base.ApplyResources(manager);

                // Note: do not load resources for spinEdit because it reset it's value
                //m_Resources.ApplyResources(spinEdit, "spinEdit");

                regionFilter.DefineBinding();
                weekFilter.DefineBinding();
                regionFilter.Caption = m_Resources.GetString("ProvinceLabel.Text");

                if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
                {
                    LocationHelper.SetDefaultFilters(manager, ContextKeeper, regionFilter, rayonFilter);
                    weekFilter.YearNumber = YearParam;
                    weekFilter.SetCurrentWeek();
                }
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
        }
    }
}