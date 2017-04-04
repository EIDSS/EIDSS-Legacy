using System.ComponentModel;
using System.Data;
using bv.common.db.Core;
using bv.winclient.Core;
using eidss.model.Resources;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class DistrictFilter : RayonFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (DistrictFilter));

        public enum Visibility
        {
            AllDistricts,
            ParentDistrictsOnly,
            SubdistrictsOnly,
        }

        public DistrictFilter()
        {
            InitializeComponent();
        }

        protected override string KeyColumnName
        {
            get { return "idfsDistrict"; }
        }

        protected override string ValueColumnName
        {
            get { return "strDistrictName"; }
        }

        protected override string LookupCaption
        {
            get { return EidssMessages.Get("colDistrictName", "District"); }
        }

        [DefaultValue(Visibility.AllDistricts)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Visibility DistrictVisibility { get; set; }

        private string DistrictsFilter
        {
            get
            {
                switch (DistrictVisibility)
                {
                    case Visibility.ParentDistrictsOnly:
                        return "idfsParentDistrict is NULL";
                    case Visibility.SubdistrictsOnly:
                        return "idfsParentDistrict is NOT NULL";
                    default:
                        return "1=1";
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long DistrictId
        {
            get { return RayonId; }
            set { RayonId = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override long RegionId
        {
            get
            {
                string strRegion = LookupCache.GetLookupValue(DistrictId, LookupTables.District, "idfsProvince");
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
                    ? string.Format("{0} AND {1} AND idfsProvince = {2}", CountryFilter, DistrictsFilter, value)
                    : "0=1";

                DataSource.RowFilter = newFilter;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long ProvinceId
        {
            get { return RegionId; }
            set { RegionId = value; }
        }

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }
            DataView districts = LookupCache.Get(LookupTables.District);

            districts.RowFilter = string.Format("{0} AND {1} ", CountryFilter, DistrictsFilter);
            return districts;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            lblLookupName.Text = m_Resources.GetString("lblLookupName.Text");
        }
    }
}