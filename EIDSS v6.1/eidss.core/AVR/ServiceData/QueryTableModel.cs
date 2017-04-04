using System.Collections.Generic;

namespace eidss.model.AVR.ServiceData
{
    public class QueryTableModel
    {
        public QueryTableModel(long queryId, string language)
        {
            QueryId = queryId;
            Language = language;
            Header = new QueryTablePacketDTO();
            BodyPackets = new List<QueryTablePacketDTO>();
        }

        public QueryTablePacketDTO Header { get; set; }
        public IList<QueryTablePacketDTO> BodyPackets { get; set; }
        public long QueryId { get; set; }
        public string Language { get; set; }
        public bool UseArchivedData { get; set; }
    }
}