using System.ComponentModel;
using System.Data;
using bv.common.db.Core;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Resources;

namespace EIDSS.Reports.BaseControls.Filters
{
    public partial class RayonFilter : BaseLookupFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (RayonFilter));

        public RayonFilter()
        {
            InitializeComponent();
        }

        protected override string KeyColumnName
        {
            get { return "idfsRayon"; }
        }

        protected override string ValueColumnName
        {
            get { return "strRayonName"; }
        }

        protected override string LookupCaption
        {
            get { return EidssMessages.Get("colRayonName", "Rayon Name"); }
        }

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }

            DataView rayons = ShowTransportCHE
                ? LookupCache.Get(LookupTables.RayonForAggregate)
                : LookupCache.Get(LookupTables.Rayon);
            rayons.RowFilter = CountryFilter;
            return rayons;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Caption
        {
            get { return lblLookupName.Text; }
            set { lblLookupName.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowTransportCHE { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long RayonId
        {
            get { return EditValueId; }
            set { EditValueId = value; }
        }

        [Browsable(false)]
        public static string CountryFilter
        {
            get { return string.Format("(idfsCountry = {0} OR idfsCountry = {1})", EidssSiteContext.Instance.CountryID, -101); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual long RegionId
        {
            get
            {
                string strRegion = LookupCache.GetLookupValue(RayonId, LookupTables.Rayon, "idfsRegion");
                long regionId;
                return long.TryParse(strRegion, out regionId) ? regionId : -1;
            }
            set
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return;
                }

                string newFilter = value > 0
                    ? string.Format("{0} and idfsRegion = {1}", CountryFilter, value)
                    : CountryFilter;

                DataSource.RowFilter = newFilter;
            }
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            lblLookupName.Text = m_Resources.GetString("lblLookupName.Text");
        }
    }
}