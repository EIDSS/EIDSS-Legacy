using System.Data;
using bv.common.db;

namespace EIDSS.RAM_DB.DBService.QueryBuilder
{
    public class QueryInfo_DB : BaseDbService
    {
        public QueryInfo_DB()
        {
            base.ObjectName = "Query";
        }

        public override DataSet GetDetail(object ID)
        {
            DataSet ds = new DataSet();
            m_ID = ID;
            return (ds);
        }

        public override bool PostDetail(DataSet ds, int PostType, IDbTransaction transaction)
        {
            return true;
        }
    }
}