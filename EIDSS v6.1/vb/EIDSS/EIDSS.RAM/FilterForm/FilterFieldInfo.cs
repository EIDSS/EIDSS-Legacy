using DevExpress.XtraEditors.Repository;

namespace eidss.avr.FilterForm
{
    public class FilterFieldInfo
    {
        //QuerySearchFieldID and SearchFieldID with SearchObjectID are selfexcluded
        //This constructor initializes QuerySearchFieldID for root object
        public FilterFieldInfo(long querySearchFieldID, string caption, RepositoryItem editor)
        {
            QuerySearchFieldID = querySearchFieldID;
            m_Caption = caption;
            Editor = editor;
            SearchFieldID = 0;
            SearchObjectID = 0; 
        }

        //This constructor initializes SearchFieldID with SearchObjectID for child subquery objects
        public FilterFieldInfo(long searchFieldID, long searchObjectID, string caption, RepositoryItem editor)
        {
            QuerySearchFieldID = 0;
            m_Caption = caption;
            Editor = editor;
            SearchFieldID = searchFieldID;
            SearchObjectID = searchObjectID;
        }
        private readonly string m_Caption;
        public string Caption
        {
            get { return m_Caption; }
        }

        public RepositoryItem Editor { get; set; }

        public long QuerySearchFieldID { get; set; }
        public long SearchFieldID { get; set; }
        public long SearchObjectID { get; set; }
    }
}
