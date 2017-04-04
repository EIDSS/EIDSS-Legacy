using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using bv.common.Core;
using DevExpress.XtraEditors.Controls;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class YearMultiFilter : BaseMultilineFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (YearMultiFilter));

        public YearMultiFilter()
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
            get { return "key"; }
        }

        protected override string ValueColumnName
        {
            get { return "name"; }
        }

        protected override DataView CreateDataSource()
        {
            var table = new DataTable("Table");
            var column = new DataColumn("key", typeof (long));
            table.Columns.Add(column);
            column = new DataColumn("name", typeof (string));
            table.Columns.Add(column);

            foreach (int year in Enumerable.Range(2000, Math.Max(0, DateTime.Now.Year - 2000 + 1)))
            {
                DataRow row = table.NewRow();
                row["key"] = (long) year;
                row["name"] = year.ToString();
                table.Rows.Add(row);
            }
            table.AcceptChanges();
            var view = new DataView(table) {Sort = "key Desc"};

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