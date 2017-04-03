using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using eidss.model.Reports.Common;
using eidss.winclient.Reports;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class QuarterMultiFilter : BaseMultilineFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (QuarterMultiFilter));

        public QuarterMultiFilter()
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
            List<ItemWrapper> lis = CreateQuarterCollection();

            var table = new DataTable("Table");
            var column = new DataColumn("key", typeof (long));
            table.Columns.Add(column);
            column = new DataColumn("name", typeof (string));
            table.Columns.Add(column);
            column = new DataColumn("year", typeof (long));
            table.Columns.Add(column);

            lis.ForEach(it =>
            {
                DataRow row = table.NewRow();
                row["key"] = (long) it.Number;
                row["name"] = it.NativeName;
                row["year"] = ((long) it.Number) / 10;
                table.Rows.Add(row);
            });
            table.AcceptChanges();
            var view = new DataView(table) {Sort = "key", RowFilter = "year = " + DateTime.Now.Year};

            return view;
        }

        public void SetYear(int year)
        {
            DataSource.RowFilter = "year = " + year;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();

            lblcheckedComboBoxName.Text = m_Resources.GetString("lblcheckedComboBoxName.Text");
        }

        private List<ItemWrapper> CreateQuarterCollection()
        {
            var result = new List<ItemWrapper>();
            for (int year = BaseYearQuarterModel.MinYear; year <= DateTime.Now.Year; year++)
            {
                result.AddRange(
                    QuartersModel.QuartersFormat.Select((format, i) => new ItemWrapper(string.Format(format, year), 10 * year + i + 1)));
            }

            return result;
        }
    }
}