using System.Collections.Generic;

namespace EIDSS.RAM.Presenters.RamForm
{
    public class WebReportLink
    {
        private readonly string m_Name;
        private readonly long? m_LayoutId;
        private readonly bool m_IsFolder;
        private readonly List<WebReportLink> m_Children;

        public WebReportLink(string name)
        {
            m_Name = name;
            m_IsFolder = true;
            m_Children = new List<WebReportLink>();
        }

        public WebReportLink(string name, long? queryId, long? layoutId)
        {
            m_Name = name;
            QueryId = queryId;
            m_LayoutId = layoutId;
            m_IsFolder = false;
            m_Children = new List<WebReportLink>();
        }

        public string Name
        {
            get { return m_Name; }
        }

        public long? QueryId { get; set; }

        public long? LayoutId
        {
            get { return m_LayoutId; }
        }

        public bool IsFolder
        {
            get { return m_IsFolder; }
        }

        public List<WebReportLink> Children
        {
            get { return m_Children; }
        }
    }
}