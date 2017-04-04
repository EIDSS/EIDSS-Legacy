using System;
using System.ComponentModel;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class VetLabKeeper : AFPIndicatorsReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (VetLabKeeper));

        public VetLabKeeper()
        {
            ReportType = typeof (VetLabReport);
            InitializeComponent();

            m_HasLoad = true;
        }

        #region Properties

        [Browsable(false)]
        protected long? RegionID
        {
            get { return regionFilter.RegionId > 0 ? (long?) regionFilter.RegionId : null; }
        }

        [Browsable(false)]
        protected long? RayonID
        {
            get { return rayonFilter.RayonId > 0 ? (long?) rayonFilter.RayonId : null; }
        }

        [Browsable(false)]
        protected long? OrganizationID
        {
            get { return organizationFilter.EditValueId > 0 ? (long?) organizationFilter.EditValueId : null; }
        }

        #endregion

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            var model = new VetLabSurrogateModel(CurrentCulture.ShortName,
                YearParam, Period, PeriodType,
                OrganizationID, organizationFilter.SelectedText,
                RegionID, RayonID, regionFilter.SelectedText, rayonFilter.SelectedText,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);
            var report = (VetLabReport) CreateReportObject();
            report.SetParameters( model,manager,archiveManager);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;

                m_HasLoad = false;

                base.ApplyResources(manager);

                regionFilter.DefineBinding();
                rayonFilter.DefineBinding();
                organizationFilter.DefineBinding();

                CountryLabel.Text = m_Resources.GetString("CountryLabel.Text");
                CountryTextBox.Text = m_Resources.GetString("CountryTextBox.Text");
                
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

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RegionFilterValueChanged(regionFilter, rayonFilter, e);
            }
        }

        private void rayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFilterResetting))
            {
                return;
            }
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RayonFilterValueChanged(regionFilter, rayonFilter, e);
            }
        }
    }
}