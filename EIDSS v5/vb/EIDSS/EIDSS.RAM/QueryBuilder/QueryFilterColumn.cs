using DevExpress.Data;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraEditors.Filtering;

namespace EIDSS.RAM.QueryBuilder
{
    public class QueryFilterColumn : DataColumnInfoFilterColumn
    {
        public QueryFilterColumn(DataColumnInfo column)
            : base(column)
        {
        }
        public override bool IsValidClause(ClauseType clause)
        {

            if (clause == ClauseType.Equals || clause == ClauseType.DoesNotEqual || 
                clause == ClauseType.Greater || clause == ClauseType.GreaterOrEqual || 
                clause == ClauseType.Less || clause == ClauseType.LessOrEqual)
                return true;
            return false;
        }
    }



}