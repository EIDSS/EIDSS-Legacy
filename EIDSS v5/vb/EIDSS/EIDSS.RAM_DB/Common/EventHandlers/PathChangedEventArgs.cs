using System;
using bv.common.db.Core;

namespace EIDSS.RAM_DB.Common.EventHandlers
{
    public class PathChangedEventArgs : EventArgs
    {
        private readonly long m_QueryId;
        private readonly string m_LayoutPath;
        private readonly long m_FolderId;

        public PathChangedEventArgs(long queryId, string layoutPath, long folderId)
        {
            m_QueryId = queryId;
            m_LayoutPath = layoutPath;
            m_FolderId = folderId;
        }

        public long QueryId
        {
            get { return m_QueryId; }
        }

        public string QueryName
        {
            get { return LookupCache.GetLookupValue(QueryId, LookupTables.Query, "QueryName"); }
        }

        public string LayoutPath
        {
            get { return m_LayoutPath; }
        }

        public long FolderId
        {
            get { return m_FolderId; }
        }

        public string FullPath
        {
            get
            {
                return string.IsNullOrEmpty(LayoutPath)
                           ? QueryName
                           : string.Format("{0} {1}", QueryName, LayoutPath);
            }
        }
    }
}