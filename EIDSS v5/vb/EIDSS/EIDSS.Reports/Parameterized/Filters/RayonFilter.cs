using System.ComponentModel;
using System.Data;
using bv.common;
using bv.common.db.Core;
using bv.common.win;
using EIDSS.Reports.BaseControls.Filters;
using bv.winclient.Core;
using eidss.model.Resources;
namespace EIDSS.Reports.Parameterized.Filters
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
            get { return EidssMessages.Get("colRayonName", "Rayon Name", null); }
        }

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }

            DataView rayons = LookupCache.Get(LookupTables.Rayon);
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
        public long RayonId
        {
            get { return EditValueId; }
            set { EditValueId = value; }
        }

        [Browsable(false)]
        public string CountryFilter
        {
            get { return string.Format("idfsCountry = {0}", eidss.model.Core.EidssSiteContext.Instance.CountryID); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long RegionId
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
                    return;

                string newFilter = value > 0
                                       ? string.Format("{0} and idfsRegion = {1}", CountryFilter, value)
                                       : CountryFilter;

                DataSource.RowFilter = newFilter;
            }
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            m_Resources.ApplyResources(lblLookupName, "lblLookupName");
            m_Resources.ApplyResources(this, "$this");
        }
    }
}