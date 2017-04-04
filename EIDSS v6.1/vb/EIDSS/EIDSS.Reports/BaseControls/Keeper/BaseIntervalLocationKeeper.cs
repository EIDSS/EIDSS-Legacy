using System;
using System.ComponentModel;
using bv.model.BLToolkit;
using eidss.model.Reports.OperationContext;
using eidss.model.Resources;
using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public partial class BaseIntervalLocationKeeper : BaseIntervalKeeper
    {
        public BaseIntervalLocationKeeper()
        {
            try
            {
                IsResourceLoading = true;
                InitializeComponent();
                dtEnd.EditValue = TruncateDate(DateTime.Now);
                dtStart.EditValue = TruncateDate(DateTime.Now.AddMonths(-1));
            }
            finally
            {
                IsResourceLoading = false;
            }

            rayonFilter.Enabled = false;
            settlementFilter.Enabled = false;
            m_HasLoad = true;
        }

        [Browsable(false)]
        protected long? RegionIdParam
        {
            get { return regionFilter.RegionId > 0 ? (long?) regionFilter.RegionId : null; }
        }

        [Browsable(false)]
        protected string RegionParam
        {
            get { return regionFilter.RegionId > 0 ? regionFilter.SelectedText : ""; }
        }

        [Browsable(false)]
        protected long? RayonIdParam
        {
            get { return regionFilter.RegionId > 0 ? (rayonFilter.RayonId > 0 ? (long?) rayonFilter.RayonId : null) : null; }
        }

        [Browsable(false)]
        protected string RayonParam
        {
            get { return regionFilter.RegionId > 0 ? (rayonFilter.RayonId > 0 ? rayonFilter.SelectedText : "") : ""; }
        }

        [Browsable(false)]
        protected long? SettlementIdParam
        {
            get
            {
                return rayonFilter.RayonId > 0 ? (settlementFilter.SettlementId > 0 ? (long?) settlementFilter.SettlementId : null) : null;
            }
        }

        [Browsable(false)]
        protected string SettlementParam
        {
            get { return rayonFilter.RayonId > 0 ? (settlementFilter.SettlementId > 0 ? settlementFilter.SelectedText : "") : ""; }
        }

        [Browsable(false)]
        protected string LocationParam
        {
            get
            {
                if (regionFilter.RegionId > 0)
                {
                    if (rayonFilter.RayonId > 0)
                    {
                        return regionFilter.SelectedText + ", " + rayonFilter.SelectedText +
                               (settlementFilter.SettlementId > 0
                                   ? ", " + settlementFilter.SelectedText
                                   : "");
                    }
                    return regionFilter.SelectedText;
                }
                return "";
            }
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);

            regionFilter.DefineBinding();
            rayonFilter.DefineBinding();
            settlementFilter.DefineBinding();
            lblStart.Text = EidssMessages.Get("DateFrom", "Date From");
            lblEnd.Text = EidssMessages.Get("DateTo", "Date To");
        }

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                if (regionFilter.RegionId == -1)
                {
                    rayonFilter.Enabled = false;
                    settlementFilter.Enabled = false;
                }
                else
                {
                    rayonFilter.Enabled = true;
                }

                if (regionFilter.RegionId == -1 || regionFilter.RegionId != rayonFilter.RegionId)
                {
                    rayonFilter.RayonId = -1;
                }
                rayonFilter.RegionId = regionFilter.RegionId;
            }
        }

        private void rayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                settlementFilter.Enabled = rayonFilter.RayonId != -1;

                if (rayonFilter.RayonId == -1 || rayonFilter.RayonId != settlementFilter.RayonId)
                {
                    settlementFilter.SettlementId = -1;
                }
                settlementFilter.RayonId = rayonFilter.RayonId;
            }
        }

        private void regionFilter_Load(object sender, EventArgs e)
        {
        }
    }
}