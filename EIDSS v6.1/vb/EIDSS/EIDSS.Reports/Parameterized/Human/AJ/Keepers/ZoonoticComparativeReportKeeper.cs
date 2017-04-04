using System;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class ZoonoticComparativeReportKeeper : BaseYearKeeper
    {
        public ZoonoticComparativeReportKeeper()
        {
            ReportType = typeof (ZoonoticAZReport);
            InitializeComponent();
            SetMandatory();
            m_HasLoad = true;
        }

        #region Properties

        [Browsable(false)]
        protected long? RegionIdParam
        {
            get { return RegionFilter.RegionId > 0 ? (long?) RegionFilter.RegionId : null; }
        }

        [Browsable(false)]
        protected long? RayonIdParam
        {
            get { return RayonFilter.RayonId > 0 ? (long?) RayonFilter.RayonId : null; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private long? DiagnosisIdParam { get; set; }

        #endregion

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }
            var model = new ZoonoticSurrogateModel(CurrentCulture.ShortName, YearParam,
                RegionIdParam, RayonIdParam,
                RegionFilter.SelectedText, RayonFilter.SelectedText,
                DiagnosisIdParam, diagnosisFilter.GetDisplayText(),
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);
            var reportAz = (ZoonoticAZReport) CreateReportObject();
            reportAz.SetParameters(model, manager, archiveManager);
            return reportAz;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);

            // Note: do not load resources for spinEdit because it reset it's value
            //m_Resources.ApplyResources(spinEdit, "spinEdit");

            diagnosisFilter.DefineBinding();
            RegionFilter.DefineBinding();
            RayonFilter.DefineBinding();
            if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
            {
                LocationHelper.SetDefaultFilters(manager, ContextKeeper, RegionFilter, RayonFilter);
            }
        }

        private void SetMandatory()
        {
//            LayoutCorrector.SetStyleController(YearSpinEdit, LayoutCorrector.MandatoryStyleController);
        }

        private void region1Filter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RegionFilterValueChanged(RegionFilter, RayonFilter, e);
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
                LocationHelper.RayonFilterValueChanged(RegionFilter, RayonFilter, e);
            }
        }

        private void Diagnosis_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            DiagnosisIdParam = null;

            if (e.KeyArray.Length > 0)
            {
                long id;
                if (long.TryParse(e.KeyArray[0], out id))
                {
                    DiagnosisIdParam = id;
                }
            }
        }
    }
}