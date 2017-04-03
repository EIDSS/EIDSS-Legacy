using System.Data;

namespace eidss.avr.db.CacheReceiver
{
    public class CachedQueryResult
    {
        public long QueryCacheId { get; private set; }
        public DataTable QueryTable { get; private set; }

        public CachedQueryResult(long queryCacheId, DataTable queryTable)
        {
            QueryCacheId = queryCacheId;
            QueryTable = queryTable;
        }
    }
}