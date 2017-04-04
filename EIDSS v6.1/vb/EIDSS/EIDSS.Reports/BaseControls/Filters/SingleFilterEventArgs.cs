using System;

namespace EIDSS.Reports.BaseControls.Filters
{
    public class SingleFilterEventArgs : EventArgs
    {
        private readonly long m_Id;
        private readonly string m_Name;
        private readonly bool m_IsClear;

        public SingleFilterEventArgs(long id, string name, bool isClear)
        {
            m_Id = id;
            m_Name = name;
            m_IsClear = isClear;
        }

        public long Id
        {
            get { return m_Id; }
        }

        public string Name
        {
            get { return m_Name; }
        }

        public bool IsClear
        {
            get { return m_IsClear; }
        }
    }
}