using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.GG;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.Report;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    public sealed partial class InfectiousDiseasesMonthKeeper : BaseDateKeeper
    {
        private static readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (InfectiousDiseasesMonthKeeper));
        private readonly InfectiousDiseasesProcessor m_Processor;
        //for designer
        public InfectiousDiseasesMonthKeeper() : this(ReportVersion.Version61)
        {
        }

        public InfectiousDiseasesMonthKeeper(ReportVersion version, Dictionary<string, string> parameters = null)
            : base(typeof (BaseDateReport), parameters ?? new Dictionary<string, string>())
        {
            m_Processor = new InfectiousDiseasesProcessor(version);
            ReportType = m_Processor.GetReportType();

            InitializeComponent();

            MaxYear = m_Processor.MaxYear;
            MinYear = m_Processor.MinYear;
            if (m_Processor.DefaultYear.HasValue)
            {
                YearParam = m_Processor.DefaultYear.Value;
            }
            else
            {
                ClearYear();
            }

            SetMandatory();
            rayonFilter.SetMandatory();

            ceAddSignature.Enabled = m_Processor.AddSignature;
            m_HasLoad = true;
        }

        [Browsable(false)]
        public bool AddSignature
        {
            get { return ceAddSignature.CheckState == CheckState.Checked; }
        }

        protected override void Year_EditValueChanged(object sender, EventArgs e)
        {
            if (m_Processor != null)
            {
                if (YearParam == MinYear)
                {
                    SetAllowedMonthes(m_Processor.AllowedMinimumMonthes);
                }
                else if (YearParam == MaxYear)
                {
                    SetAllowedMonthes(m_Processor.AllowedMaximumMonthes);
                }
                else
                {
                    SetAllowedMonthes(m_Processor.AllMonthes);
                }
            }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            // when rayon  not selected we should use RegionId == -1 and RayonId == -1 because we should show empty report

            string regionRayonId = string.Format("{0}__{1}", rayonFilter.RegionId, rayonFilter.RayonId);
            var model = new MonthInfectiousDiseaseModel(CurrentCulture.ShortName, YearParam, StartMonthParam, AddSignature, UseArchive)
            {
                RayonFilter = new RayonModel {RegionRayonComplexId = regionRayonId}
            };

            dynamic report = CreateReportObject();
            report.ShowGlobalHeader = false;
            report.SetParameters(model, manager, archiveManager);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);
            ceAddSignature.Properties.Caption = m_Resources.GetString("ceAddSignature.Properties.Caption");

            rayonFilter.DefineBinding();

            if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
            {
                LocationHelper.SetDefaultFilters(manager, ContextKeeper, null, rayonFilter);
            }
        }
    }
}