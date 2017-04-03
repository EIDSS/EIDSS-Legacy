using System.ComponentModel;
using System.Data;
using bv.winclient.Core;

namespace EIDSS.Reports.BaseControls.Filters
{
    public partial class AgeGroupLookupFilter : BaseLookupFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (AgeGroupLookupFilter));

        public AgeGroupLookupFilter()
        {
            InitializeComponent();
        }

        protected override string KeyColumnName
        {
            get { return "idfsReference"; }
        }

        protected override string ValueColumnName
        {
            get { return "name"; }
        }

        protected override string LookupCaption
        {
            get { return lblLookupName.Text; }
        }

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }
            DataTable dataTable = CreateTableStructure();

            FillTableData(dataTable);

            return CreateView(dataTable);
        }

        private DataTable CreateTableStructure()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(KeyColumnName, typeof (int));
            dataTable.Columns.Add(ValueColumnName, typeof (string));
            return dataTable;
        }

        private void FillTableData(DataTable dataTable)
        {
            DataRow row = dataTable.NewRow();
            row[KeyColumnName] = 1;
            row[ValueColumnName] = "0 - 4 years";
            dataTable.Rows.Add(row);
            row = dataTable.NewRow();
            row[KeyColumnName] = 2;
            row[ValueColumnName] = "5 - 14 years";
            dataTable.Rows.Add(row);
            row = dataTable.NewRow();
            row[KeyColumnName] = 3;
            row[ValueColumnName] = "15 - 29 years";
            dataTable.Rows.Add(row);
            row = dataTable.NewRow();
            row[KeyColumnName] = 4;
            row[ValueColumnName] = "30 - 64 years";
            dataTable.Rows.Add(row);
            row = dataTable.NewRow();
            row[KeyColumnName] = 5;
            row[ValueColumnName] = ">= 65 years";
            dataTable.Rows.Add(row);
            row = dataTable.NewRow();
            row[KeyColumnName] = 6;
            row[ValueColumnName] = "Total";
            dataTable.Rows.Add(row);
            dataTable.AcceptChanges();
        }

        private DataView CreateView(DataTable dataTable)
        {
            string filter = "";
            var view = new DataView(dataTable, filter, KeyColumnName, DataViewRowState.OriginalRows);
            return view;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            lblLookupName.Text = m_Resources.GetString("lblLookupName.Text");
        }
    }
}