using System.ComponentModel;
using System.Data;
using bv.common.db.Core;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Resources;

namespace EIDSS.Reports.BaseControls.Filters
{
    public partial class RegionFilter : BaseLookupFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (RegionFilter));

        public RegionFilter()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long RegionId
        {
            get { return EditValueId; }
            set { EditValueId = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Caption
        {
            get { return lblLookupName.Text; }
            set { lblLookupName.Text = value; }
        }

        protected override string KeyColumnName
        {
            get { return "idfsRegion"; }
        }

        protected override string ValueColumnName
        {
            get { return "strRegionName"; }
        }

        protected override string LookupCaption
        {
            get { return EidssMessages.Get("colRegionName", "Region Name"); }
        }

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }

            DataView regions = ShowTransportCHE
                                   ? LookupCache.Get(LookupTables.RegionForAggregate)
                                   : LookupCache.Get(LookupTables.Region);
            regions.RowFilter = string.Format("(idfsCountry = {0} OR idfsCountry = {1})", EidssSiteContext.Instance.CountryID, -101);
            return regions;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            lblLookupName.Text = m_Resources.GetString("lblLookupName.Text");
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowTransportCHE { get; set; }
    }
}