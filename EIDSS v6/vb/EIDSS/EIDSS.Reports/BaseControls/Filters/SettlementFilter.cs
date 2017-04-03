using System.ComponentModel;
using System.Data;
using bv.common.db.Core;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Resources;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial  class SettlementFilter : BaseLookupFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (SettlementFilter));

        public SettlementFilter()
        {
            InitializeComponent();
        }

        protected override string KeyColumnName
        {
            get { return "idfsSettlement"; }
        }

        protected override string ValueColumnName
        {
            get { return "strSettlementName"; }
        }

        protected override string LookupCaption
        {
            get { return EidssMessages.Get("colSettlementName", "Settlement Name"); }
        }

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }

            DataView settlements = LookupCache.Get(LookupTables.Settlement);
            settlements.RowFilter = CountryFilter;
            return settlements;
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
        public long SettlementId
        {
            get { return EditValueId; }
            set { EditValueId = value; }
        }

        [Browsable(false)]
        public string CountryFilter
        {
            get { return string.Format("(idfsCountry = {0} OR idfsCountry = {1})", EidssSiteContext.Instance.CountryID, -101); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long RayonId
        {
            get
            {
                string strRayon = LookupCache.GetLookupValue(SettlementId, LookupTables.Settlement, "idfsRayon");
                long rayonId;
                return long.TryParse(strRayon, out rayonId) ? rayonId : -1;
            }
            set
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return;
                }

                string newFilter = string.Format("{0} and idfsRayon = {1}", CountryFilter, value); //result will be empty if value = -1

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