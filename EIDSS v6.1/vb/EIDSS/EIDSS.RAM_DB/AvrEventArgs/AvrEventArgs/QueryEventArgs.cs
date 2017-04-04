using System;

namespace eidss.avr.db.AvrEventArgs.AvrEventArgs
{
    public class QueryEventArgs : EventArgs
    {
        private readonly long m_QueryId;

        public QueryEventArgs(long queryId)
        {
            m_QueryId = queryId;
        }

        public long QueryId
        {
            get { return m_QueryId; }
        }
    }
}