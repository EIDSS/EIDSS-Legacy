using System;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.IQ.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class ComparativeIQReportKeeper : BaseComparativeReportKeeper
    {
        public ComparativeIQReportKeeper()
        {
            ReportType = typeof (ComparativeIQReport);
            InitializeComponent();
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
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

            var reportIq = (ComparativeIQReport)CreateReportObject();
            reportIq.SetParameters(manager, model);
            return reportIq;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;

                base.ApplyResources(manager);

                region1Filter.Caption = ProvinceLabel.Text + " 1";
                rayon1Filter.Caption = DistrictLabel.Text + " 1";
                region2Filter.Caption = ProvinceLabel.Text + " 2";
                rayon2Filter.Caption = DistrictLabel.Text + " 2";
                // TODO: [ivan] Unhide controls when Iraq statistics will be filled in the DataBase
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