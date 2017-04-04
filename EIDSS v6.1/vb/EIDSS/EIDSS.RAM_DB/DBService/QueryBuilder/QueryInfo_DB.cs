using System.Data;
using bv.common.db;

namespace eidss.avr.db.DBService.QueryBuilder
{
    public class QueryInfo_DB : BaseDbService
    {
        public QueryInfo_DB()
        {
            ObjectName = "AsQuery";
        }

        public override DataSet GetDetail(object id)
        {
            var ds = new DataSet();
            m_ID = id;
            return (ds);
        }

        public override bool PostDetail(DataSet ds, int postType, IDbTransaction transaction)
        {
            return true;
        }
    }
}