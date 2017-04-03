using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors.Filtering;

namespace eidss.avr.QueryBuilder
{
    public class QueryFilterColumnCollection : DataColumnInfoFilterColumnCollection
    {
        public QueryFilterColumnCollection(DataColumnInfo[] columns)
            : base(columns)
        {
        }

        public QueryFilterColumnCollection(BindingContext context, object dataSource, string dataMember, FilterTreeNodeModel model)
            : base(context, dataSource, dataMember, model)
        {
        }

        public QueryFilterColumnCollection(object dataSource, FilterTreeNodeModel model)
            : base(dataSource, model)
        {
        }

        protected override FilterColumn CreateFilterColumn(DataColumnInfo column)
        {
            return new QueryFilterColumn(column);
        }
    }
}