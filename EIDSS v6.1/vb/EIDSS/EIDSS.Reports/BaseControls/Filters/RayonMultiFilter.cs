using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.db.Core;
using bv.winclient.Core;
using DevExpress.XtraEditors.Controls;
using eidss.model.Resources;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class RayonMultiFilter : BaseMultilineFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (RayonMultiFilter));

        public RayonMultiFilter()
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
            get { return "idfsRayon"; }
        }

        protected override string ValueColumnName
        {
            get { return "strRayonName"; }
        }

        //protected string LookupCaption
        //{
        //    get { return EidssMessages.Get("colRayonName", "Rayon Name"); }
        //}

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }
            DataView rayons = LookupCache.Get(LookupTables.Rayon);
            rayons.RowFilter = RayonFilter.CountryFilter;
            return rayons;
        }

        public void SetRegions(string[] regions)
        {
            if (regions == null || regions.Length == 0)
            {
                DataSource.RowFilter = "0=1";
            }
            else
            {
                var sbFilter = new StringBuilder(RayonFilter.CountryFilter);
                sbFilter.Append(" AND (");
                bool firstRegion = true;
                foreach (string region in regions)
                {
                    if (!firstRegion)
                    {
                        sbFilter.Append(" OR ");
                    }
                    sbFilter.AppendFormat("idfsRegion = {0}", region);
                    firstRegion = false;
                }
                sbFilter.Append(")");
                DataSource.RowFilter = sbFilter.ToString();
            }
            RefreshEditValue();
        }

        public void SetRayons(string[] regions)
        {
            if (regions == null)
            {
                regions = new string[0];
            }

            foreach (string region in regions)
            {
                List<CheckedListBoxItem> items = GetCheckedListBoxItems().ToList();
                CheckedListBoxItem foundItem = items.FirstOrDefault(item => Utils.Str(item.Value) == region);
                if (foundItem != null)
                {
                    foundItem.CheckState = CheckState.Checked;
                }
            }
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            lblcheckedComboBoxName.Text = m_Resources.GetString("lblcheckedComboBoxName.Text");
        }
    }
}