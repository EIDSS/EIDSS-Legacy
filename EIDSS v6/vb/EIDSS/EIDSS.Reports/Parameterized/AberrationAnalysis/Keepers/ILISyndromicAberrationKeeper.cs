using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.Core;
using eidss.model.Reports.AberrationAnalisys;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.AberrationAnalysis.Reports;

namespace EIDSS.Reports.Parameterized.AberrationAnalysis.Keepers
{
    public partial class ILISyndromicAberrationKeeper : AberrationKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (ILISyndromicAberrationKeeper));

        public ILISyndromicAberrationKeeper()
        {
            ReportType = typeof (ILIAberrationReport);
            InitializeComponent();
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                DateFieldsLookUp.Visible = false;
                TimeUnitsLookUp.Enabled = false;
                ageGroupLookupFilter.SetMandatory();
            }
            intType = 4;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            var model = new ILISyndromicAberrationModel(CurrentCulture.ShortName, StartDateTruncated, EndDateTruncated, RegionIdParam,
                RayonIdParam, LocationParam,
                ThresholdParam, TimeUnitsParam, TimeUnitsTextParam, BaselineParam, LagParam, DateFieldsParam, DateFieldsTextParam,
                AgeGroup, ageGroupLookupFilter.SelectedText, Hospital, syndrOrganizationFilter.SelectedText,
                UseArchive);
            var report = (ILIAberrationReport)CreateReportObject();

            report.SetParameters(manager, model);

            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;

                base.ApplyResources(manager);

                m_Resources.ApplyResources(pnlSettings, "pnlSettings");
                m_Resources.ApplyResources(this, "$this");

                ageGroupLookupFilter.DefineBinding();
                syndrOrganizationFilter.DefineBinding();
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
        }

        [Browsable(false)]
        protected int AgeGroup
        {
            get
            {
                if (ageGroupLookupFilter != null)
                {
                    return (int) ageGroupLookupFilter.EditValueId;
                }
                return -1;
            }
        }

        [Browsable(false)]
        protected long? Hospital
        {
            get
            {
                if (syndrOrganizationFilter != null && syndrOrganizationFilter.EditValueId > 0)
                {
                    return syndrOrganizationFilter.EditValueId;
                }
                return null;
            }
        }
    }
}