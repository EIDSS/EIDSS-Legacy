using System;

namespace EIDSS.RAM_DB.Common
{
    [Serializable]
    public class LayoutTreeElement
    {
        private readonly long m_ID;
        private long? m_ParentID;
        private readonly long m_QueryID;
        private readonly bool m_IsLayout;
        private string m_DefaultName;
        private string m_NationalName;
        private readonly bool m_ReadOnly;
        private bool m_IsChanged;
        private readonly bool m_Share;

        public LayoutTreeElement(long id, long? parentID, long queryID, bool isLayout, string defaultName,
                                 string nationalName, bool readOnly, bool share)
        {
            m_ID = id;
            m_ParentID = parentID;
            m_QueryID = queryID;
            m_IsLayout = isLayout;
            m_DefaultName = defaultName;
            m_NationalName = nationalName;
            m_ReadOnly = readOnly;
            m_Share = share;
        }

        public long ID
        {
            get { return m_ID; }
        }

        public long? ParentID
        {
            get { return m_ParentID; }
            set
            {
                SetChanges();
                m_ParentID = value;
            }
        }

        public long QueryID
        {
            get { return m_QueryID; }
        }

        public bool IsLayout
        {
            get { return m_IsLayout; }
        }

        public string DefaultName
        {
            get { return m_DefaultName; }
            set
            {
                SetChanges();
                m_DefaultName = value;
            }
        }

        public string NationalName
        {
            get { return m_NationalName; }
            set
            {
                SetChanges();
                m_NationalName = value;
            }
        }

        public bool ReadOnly
        {
            get { return m_ReadOnly; }
        }

        public bool IsChanged
        {
            get { return m_IsChanged; }
        }

        public bool Share
        {
            get { return m_Share; }
        }

        public void SetChanges()
        {
            m_IsChanged = true;
        }


        public override string ToString()
        {
            string type = IsLayout ? "Layout" : "Folder";
            return string.Format("{0} ID:{1}, ParentID:{2}, Name:{3}", type, ID, ParentID, DefaultName);
        }
    }
}