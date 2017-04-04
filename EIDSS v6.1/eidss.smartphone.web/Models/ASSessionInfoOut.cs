using System.Collections.Generic;

namespace eidss.smartphone.web.Models
{
    public class ASSessionInfoOut : ASSessionInfoIn
    {
        public string lastErrorDescription { get; set; }

        public bool isCreated { get; set; }
        public bool isUpdated { get; set; }
        public bool isFailed { get; set; }

        public ASSessionInfoOut(ASSessionInfoIn asin)
        {
            idfMonitoringSession = asin.idfMonitoringSession;
            uidOfflineCaseID = asin.uidOfflineCaseID;
            strMonitoringSessionID = asin.strMonitoringSessionID;
            lastErrorDescription = string.Empty;

            asdiseases = new List<ASDiseaseInfoIn>();
            farms = new List<FarmInfoIn>();
            assamples = new List<ASSampleInfoIn>();
        }
    }
}