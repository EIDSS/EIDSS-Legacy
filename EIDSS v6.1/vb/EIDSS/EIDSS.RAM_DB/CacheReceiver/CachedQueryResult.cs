using eidss.model.AVR.ServiceData;
using eidss.model.AVR.SourceData;

namespace eidss.avr.db.CacheReceiver
{
    public class CachedQueryResult
    {
        //stores datatable only
        public CachedQueryResult(long queryId, AvrDataTable queryTable)
        {
            QueryId = queryId;
            QueryTable = queryTable;
            QueryHeader = null;
            QueryPackets = null;
        }

        //stores zipped source of datatable
        public CachedQueryResult(long queryId, QueryTableHeaderDTO queryHeader, QueryTablePacketDTO[] queryPackets)
        {
            QueryId = queryId;
            QueryTable = null;
            QueryHeader = queryHeader;
            QueryPackets = queryPackets;
        }

        // stores both data table and it's zipped source
        public CachedQueryResult
            (long queryId, AvrDataTable queryTable,QueryTableHeaderDTO queryHeader, QueryTablePacketDTO[] queryPackets)
        {
            QueryId = queryId;
            QueryTable = queryTable;
            QueryHeader = queryHeader;
            QueryPackets = queryPackets;
        }

        // stores empty data table and it's zipped source because of the error
        public CachedQueryResult
            (long queryId, AvrDataTable queryTable, QueryTableHeaderDTO queryHeader,  string errorMessage)
        {
            QueryId = queryId;
            QueryTable = queryTable;
            QueryHeader = queryHeader;
            QueryPackets = new QueryTablePacketDTO[0];
            ErrorMessage = errorMessage;
        }

        public long QueryId { get; private set; }
        public QueryTableHeaderDTO QueryHeader { get; private set; }
        public QueryTablePacketDTO[] QueryPackets { get; private set; }
        public AvrDataTable QueryTable { get; private set; }
        public string ErrorMessage { get; private set; }

        public long QueryCacheId
        {
            get { return QueryHeader == null ? -1 : QueryHeader.QueryCacheId; }
        }

        public bool HasTable
        {
            get { return QueryTable != null; }
        }

        public bool HasZippedSource
        {
            get { return QueryHeader != null; }
        }
    }
}