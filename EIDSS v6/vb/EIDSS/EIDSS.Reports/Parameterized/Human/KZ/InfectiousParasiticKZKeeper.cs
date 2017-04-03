using System;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Reports.KZ;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.KZ
{
    public sealed partial class InfectiousParasiticKZKeeper : BaseDateKeeper
    {
        private static readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (InfectiousParasiticKZKeeper));

        public InfectiousParasiticKZKeeper() : base(typeof (FormN1Report))
        {
            ReportType = typeof (InfectiousParasiticKZReport);
            InitializeComponent();
            SetCurrentStartMonth();
            m_HasLoad = true;
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

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            var model = new InfectiousParasiticKZSurrogateModel(CurrentCulture.ShortName,
                YearParam, StartMonthParam, EndMonthParam,
                RegionIdParam, RayonIdParam, regionFilter.SelectedText, rayonFilter.SelectedText,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);

            var report = (InfectiousParasiticKZReport) CreateReportObject();
            report.SetParameters(manager, model);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);

            CountryLabel.Text = m_Resources.GetString("CountryLabel.Text");
            CountryTextBox.Text = m_Resources.GetString("CountryTextBox.Text");

            regionFilter.DefineBinding();
            rayonFilter.DefineBinding();

            if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
            {
                LocationHelper.SetDefaultFilters(manager, ContextKeeper, regionFilter, rayonFilter);
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
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RayonFilterValueChanged(regionFilter, rayonFilter, e);
            }
        }

        private void CountryLabel_Click(object sender, EventArgs e)
        {
        }
    }
}