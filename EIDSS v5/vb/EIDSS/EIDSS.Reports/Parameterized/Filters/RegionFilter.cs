using System.ComponentModel;
using System.Data;
using EIDSS.Reports.BaseControls.Report;
using bv.common;
using bv.common.db.Core;
using EIDSS.Reports.BaseControls.Filters;
using bv.winclient.Core;
using eidss.model.Resources;

namespace EIDSS.Reports.Parameterized.Filters
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
            get { return EidssMessages.Get("colRegionName", "Region Name", null); }
        }

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }
            DataView regions = LookupCache.Get(LookupTables.Region);
            regions.RowFilter = string.Format("idfsCountry = {0}", eidss.model.Core.EidssSiteContext.Instance.CountryID);
            return regions;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            m_Resources.ApplyResources(lblLookupName, "lblLookupName");
            m_Resources.ApplyResources(this, "$this");
        }
    }
}