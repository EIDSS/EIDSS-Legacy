using System;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Keepers;
using EIDSS.Reports.Parameterized.Human.IQ.Reports;

namespace EIDSS.Reports.Parameterized.Human.IQ.Keepers
{
    public partial class ComparativeIQReportKeeper : BaseComparativeReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (ComparativeIQReportKeeper));

        public ComparativeIQReportKeeper()
        {
            ReportType = typeof (ComparativeIQReport);
            InitializeComponent();
            Year1SpinEdit.Properties.MaxValue = DateTime.Now.Year - 1;
            Year2SpinEdit.Properties.MaxValue = DateTime.Now.Year;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            var model = new ComparativeSurrogateModel(CurrentCulture.ShortName,
                CounterParam,
                StartMonthParam, EndMonthParam,
                Year1Param, Year2Param,
                FirstRegionIdParam, FirstRayonIdParam,
                SecondRegionIdParam, SecondRayonIdParam,
                -1,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);

            var reportIq = (ComparativeIQReport) CreateReportObject();
            reportIq.SetParameters( model,manager,archiveManager);
            return reportIq;
        }
        protected override void CorrectYearRange()
        {
            if (Year2Param <= Year1Param)
            {
                if (!ContextKeeper.ContainsContext(ContextValue.ReportFilterLoading))
                {
                    if (!BaseFormManager.IsReportsServiceRunning && !BaseFormManager.IsAvrServiceRunning)
                    {
                        ErrorForm.ShowWarning("msgComparativeReportIQCorrectYear", "Year 2 shall be greater than Year 1");
                    }
                }
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
                {
                    Year1SpinEdit.EditValue = Year2Param - 1;
                }
            }
        }
        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;

                base.ApplyResources(manager);

                region1Filter.Caption = m_Resources.GetString("Province1Label.Text");
                rayon1Filter.Caption = m_Resources.GetString("District1Label.Text");
                region2Filter.Caption = m_Resources.GetString("Province2Label.Text");
                rayon2Filter.Caption = m_Resources.GetString("District2Label.Text");
                // Note: counter filter is not applicable in IQ comparative report
                CounterLabel.Hide();
                CounterLookUp.Hide();
                //

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
    }
}