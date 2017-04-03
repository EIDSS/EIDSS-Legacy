using System;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public class AFPHeader
    {
        private readonly string m_Caption;
        private readonly DateTime m_StartDate;
        private readonly DateTime m_EndDate;

        public AFPHeader(string caption, DateTime startDate, DateTime endDate)
        {
            m_Caption = caption;
            m_StartDate = startDate;
            m_EndDate = endDate;
        }

        public string Caption
        {
            get { return m_Caption; }
        }

        public DateTime StartDate
        {
            get { return m_StartDate; }
        }

        public DateTime EndDate
        {
            get { return m_EndDate; }
        }
    }
}