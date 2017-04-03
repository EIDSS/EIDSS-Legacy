using System.Collections.Generic;

namespace EIDSS.Reports.Document.Veterinary.LivestockInvestigation
{
    public class VetObservationData
    {
        private long m_CaseId;
        private long m_CaseObservationId;
        private long m_FarmObservationId;
        private readonly Dictionary<long, string> m_SpeciesObservationIdList = new Dictionary<long, string>();
        private readonly Dictionary<long, string> m_AnimalObservationIdList = new Dictionary<long, string>();

        public long CaseId
        {
            get { return m_CaseId; }
            set { m_CaseId = value; }
        }

        public long CaseObservationId
        {
            get { return m_CaseObservationId; }
            set { m_CaseObservationId = value; }
        }

        public long FarmObservationId
        {
            get { return m_FarmObservationId; }
            set { m_FarmObservationId = value; }
        }

        public Dictionary<long, string> SpeciesObservationIdList
        {
            get { return m_SpeciesObservationIdList; }
        }

        public Dictionary<long, string> AnimalObservationIdList
        {
            get { return m_AnimalObservationIdList; }
        }
    }
}