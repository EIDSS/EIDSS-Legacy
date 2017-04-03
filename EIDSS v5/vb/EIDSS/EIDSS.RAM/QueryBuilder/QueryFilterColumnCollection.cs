using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors.Filtering;

namespace EIDSS.RAM.QueryBuilder
{
    public class QueryFilterColumnCollection : DataColumnInfoFilterColumnCollection
    {
        public QueryFilterColumnCollection(DataColumnInfo[] columns) : base(columns)
        {
        }

        public QueryFilterColumnCollection(BindingContext context, object dataSource, string dataMember)
            : base(context, dataSource, dataMember)
        {
        }

        public QueryFilterColumnCollection(object dataSource) : base(dataSource)
        {
        }

        protected override FilterColumn CreateFilterColumn(DataColumnInfo column)
        {
            return new QueryFilterColumn(column);
        }
    }
}