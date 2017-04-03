using System.ComponentModel;
using System.Windows.Forms;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.OperationContext;
using EIDSS.Reports.Parameterized.Filters;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;
using bv.model.BLToolkit;
using eidss.model.Reports.AZ;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class VetLabKeeper : AFPIndicatorsReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (VetLabKeeper));

        public VetLabKeeper()
        {
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

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFirstLoading))
            {
                FiltersHelper.SetDefaultFiltes(manager, ContextKeeper, regionFilter, rayonFilter);
            }

            var model = new VetLabSurrogateModel(CurrentCulture.ShortName,
                                                 GetYearParam, Period, PeriodType,
                                                 OrganizationID, organizationFilter.SelectedText,
                                                 RegionID, RayonID, regionFilter.SelectedText, rayonFilter.SelectedText,UseArchive);
            var report = new VetLabReport();
            report.SetParameters(manager, model);
            return report;
        }

        protected override void ApplyResources()
        {
            try
            {
                IsResourceLoading = true;

                m_HasLoad = false;

                regionFilter.DefineBinding();
                rayonFilter.DefineBinding();
                m_Resources.ApplyResources(organizationFilter, "OrganizationFilter");
                organizationFilter.DefineBinding();

                m_Resources.ApplyResources(CountryLabel, "CountryLabel");
                m_Resources.ApplyResources(CountryTextBox, "CountryTextBox");
                base.ApplyResources();
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
                FiltersHelper.RegionFilterValueChanged(this, regionFilter, rayonFilter, e);
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
                FiltersHelper.RayonFilterValueChanged(this, regionFilter, rayonFilter, e);
            }
        }

        private void organizationFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            ReloadReportIfFormLoaded(sender as Control);
        }
    }
}