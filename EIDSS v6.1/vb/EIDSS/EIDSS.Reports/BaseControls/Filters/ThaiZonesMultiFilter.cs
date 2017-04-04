using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.db.Core;
using DevExpress.XtraEditors.Controls;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class ThaiZonesMultiFilter : BaseMultilineFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (ThaiZonesMultiFilter));

        public ThaiZonesMultiFilter()
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
            get { return "idfsBaseReference"; }
        }

        protected override string ValueColumnName
        {
            get { return "name"; }
        }

        protected override DataView CreateDataSource()
        {
            DataView view = LookupCache.Get(LookupTables.ThaiZones);
            view.Sort = "name";
            return view;
        }

        public void SetYears(string[] years)
        {
            if (years == null)
            {
                years = new string[0];
            }

            foreach (string year in years)
            {
                List<CheckedListBoxItem> items = GetCheckedListBoxItems().ToList();
                CheckedListBoxItem foundItem = items.FirstOrDefault(item => Utils.Str(item.Value) == year);
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