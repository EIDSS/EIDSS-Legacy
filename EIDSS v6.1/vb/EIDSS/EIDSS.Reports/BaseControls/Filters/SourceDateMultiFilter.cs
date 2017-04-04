using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class SourceDateMultiFilter : BaseMultilineFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (SourceDateMultiFilter));
        private int m_Type;

        public SourceDateMultiFilter()
        {
            InitializeComponent();
            SetMandatory();
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
            List<ItemWrapper> lis = FilterHelper.GetWinAberrationDateFieldsList(m_Type);

            var table = new DataTable("Table");
            var column = new DataColumn("key", typeof (long));
            table.Columns.Add(column);
            column = new DataColumn("name", typeof (string));
            table.Columns.Add(column);

            lis.ForEach(it =>
            {
                DataRow row = table.NewRow();
                row["key"] = (long) it.Number;
                row["name"] = it.NativeName;
                table.Rows.Add(row);
            });
            table.AcceptChanges();
            var view = new DataView(table) {Sort = "key"};
            return view;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int intType
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();

            lblcheckedComboBoxName.Text = m_Resources.GetString("lblcheckedComboBoxName.Text");
        }
    }
}