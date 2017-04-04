using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.Report;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    public partial class RBEReportKeeper : BaseYearKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (RBEReportKeeper));
        private string[] m_Regions;
        private string[] m_Rayons;
        private string[] m_QuarterFields;

        public RBEReportKeeper()
        {
            ReportType = typeof (RBEReport);
            InitializeComponent();
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                QuarterFilter.SetMandatory();

                RayonFilter.SetRegions(null);

                MinYear = 2000;
                MaxYear = DateTime.Now.Year;

               

                ceAddSignature.Visible =
                    EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanSignReport));
            }
            m_HasLoad = true;
        }

        [Browsable(false)]
        public bool AddSignature
        {
            get { return ceAddSignature.CheckState == CheckState.Checked; }
        }


        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            List<int> q = m_QuarterFields.Select(s => Convert.ToInt32(s) % 10).ToList();
            var quarters = new QuartersModel(q.Contains(1), q.Contains(2), q.Contains(3), q.Contains(4));

            var model = new RBESurrogateModel(CurrentCulture.ShortName, YearParam, quarters,
                m_Regions, m_Rayons, AddSignature, UseArchive);

            var report = (RBEReport)CreateReportObject();
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

                string[] oldRayons = m_Rayons;
                RayonFilter.DefineBinding();
                RegionFilter.DefineBinding();
                RayonFilter.SetRegions(m_Regions);
                RayonFilter.SetRayons(oldRayons);
                

                QuarterFilter.DefineBinding();
             //   m_Resources.ApplyResources(QuarterFilter, "QuarterFilter");
                ceAddSignature.Properties.Caption = m_Resources.GetString("ceAddSignature.Properties.Caption");
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
        }

        protected override void OnBeforeYearChange()
        {
            if (!m_HasLoad || ContextKeeper.ContainsContext(ContextValue.ReportLoading))
            {
                return;
            }
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                QuarterFilter.SetYear(YearParam);
            }
        }

        private void RegionFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                m_Regions = e.KeyArray;
                RayonFilter.SetRegions(m_Regions);

                var editValue = Utils.Str(RayonFilter.EditValue);
                m_Rayons = editValue.Split(new[]{", "}, StringSplitOptions.RemoveEmptyEntries);
            }
            
        }

        private void RayonFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_Rayons = e.KeyArray;
            
        }

        private void QuarterFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_QuarterFields = e.KeyArray;

            
        }

    }
}