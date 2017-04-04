using System.ComponentModel;
using System.Data;
using bv.common.db.Core;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class RegionAZFilter : RegionFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (RegionAZFilter));

        public RegionAZFilter()
        {
            InitializeComponent();
        }

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }

            var regions = LookupCache.Get(LookupTables.RegionForAz);
            regions.Sort = "intOrder, strRegionName";
            if (!ShowTransportCHE)
            {
                regions.RowFilter = string.Format("(idfsRegion <> {0})", AddressModel.TransportCheId);
            }
            return regions;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            lblLookupName.Text = m_Resources.GetString("lblLookupName.Text");
        }
    }
}