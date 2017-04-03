using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.smartphone.web.Models
{
    public class VetCaseInfoOut
    {
        public long id { get; set; }
        public string offlineCaseID { get; set; }
        public string caseID { get; set; }
        public string farmCode { get; set; }
        public long herd { get; set; }
        public string reportedByOrganization { get; set; }
        public string reportedByPerson { get; set; }

        public string lastErrorDescription { get; set; }

        public bool isCreated { get; set; }
        public bool isUpdated { get; set; }
        public bool isFailed { get; set; }

        public VetCaseInfoOut(VetCaseInfoIn vcin)
        {
            id = vcin.id;
            offlineCaseID = vcin.offlineCaseID;
            caseID = vcin.caseID;
            herd = vcin.species.Count > 0 ? vcin.species.First().herd : 0;
            lastErrorDescription = "";
        }
    }
}