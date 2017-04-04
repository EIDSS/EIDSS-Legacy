using System;
using System.Data;

namespace EIDSS.Reports.BaseControls.Filters
{
    public partial class LabAZLookupFilter : BaseLookupFilter
    {
        private DataView m_DataSource;

        public LabAZLookupFilter()
        {
            InitializeComponent();
        }

        protected override string KeyColumnName
        {
            get { return "idfsReference"; }
        }

        protected override string ValueColumnName
        {
            get { return "strName"; }
        }

        protected override string LookupCaption
        {
            get { return lblLookupName.Text; }
        }

        public bool EntityNotFound
        {
            get { return m_DataSource.Count == 0 || (long) m_DataSource[0][KeyColumnName] == -2; }
        }

        public bool BadEntityFound
        {
            get { return m_DataSource.Count == 0 || (long) m_DataSource[0][KeyColumnName] == -1; }
        }

        public void ClearBinding()
        {
            m_DataSource.Table.Rows.Clear();
            EditValue = null;
            LookUpenabled = !EntityNotFound && !BadEntityFound;
        }

        public void DefineBinding(string lang, string entityId)
        {
            var table = CreateTable(lang, entityId);
            InitDataSource(table);
            DefineBinding();
        }

        protected override DataView CreateDataSource()
        {
            if (m_DataSource == null)
            {
                var table = CreateTable();
                InitDataSource(table);
            }
            return m_DataSource;
        }

        protected virtual DataTable CreateTable(string lang, string entityId)
        {
            throw new NotImplementedException("Method should be overriden in child class");
        }

        private DataTable CreateTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(KeyColumnName, typeof (long));
            table.Columns.Add(ValueColumnName, typeof (string));
            return table;
        }

        private void InitDataSource(DataTable table)
        {
            if (table == null || !table.Columns.Contains(KeyColumnName) || !table.Columns.Contains(ValueColumnName))
            {
                throw new ArgumentException(string.Format("Table should contains following columns '{0}' '{1}'",
                    KeyColumnName, ValueColumnName));
            }
            m_DataSource = new DataView(table);
            LookUpenabled = !EntityNotFound && !BadEntityFound;
        }
    }
}