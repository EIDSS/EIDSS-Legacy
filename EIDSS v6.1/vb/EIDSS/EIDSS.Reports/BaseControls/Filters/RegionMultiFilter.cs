using System.ComponentModel;
using System.Data;
using bv.common.db.Core;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Resources;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class RegionMultiFilter : BaseMultilineFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (RegionMultiFilter));

        public RegionMultiFilter()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Caption
        {
            get { return lblcheckedComboBoxName.Text; }
            set { lblcheckedComboBoxName.Text = value; }
        }

        protected override string KeyColumnName
        {
            get { return "idfsRegion"; }
        }

        protected override string ValueColumnName
        {
            get { return "strRegionName"; }
        }

        //protected string LookupCaption
        //{
        //    get { return EidssMessages.Get("colRegionName", "Region Name"); }
        //}

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }
            DataView regions = LookupCache.Get(LookupTables.Region);
            regions.RowFilter = string.Format("(idfsCountry = {0} OR idfsCountry = {1})", EidssSiteContext.Instance.CountryID, -101);
            return regions;
        }


        protected override void ApplyResources()
        {
            base.ApplyResources();

            lblcheckedComboBoxName.Text = m_Resources.GetString("lblcheckedComboBoxName.Text");
        }
    }
}