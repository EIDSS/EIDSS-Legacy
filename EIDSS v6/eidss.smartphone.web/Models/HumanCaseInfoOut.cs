using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.smartphone.web.Models
{
    public class HumanCaseInfoOut
    {
        public long id { get; set; }
        public string offlineCaseID { get; set; }
        public string caseID { get; set; }
        public DateTime notificationDate { get; set; }
        public string notificationSentBy { get; set; }
        public string notificationSentByPerson { get; set; }

        public string lastErrorDescription { get; set; }

        public bool isCreated { get; set; }
        public bool isUpdated { get; set; }
        public bool isFailed { get; set; }

        public HumanCaseInfoOut(HumanCaseInfoIn hcin)
        {
            id = hcin.id;
            offlineCaseID = hcin.offlineCaseID;
            caseID = hcin.caseID;
            lastErrorDescription = "";
        }
    }
}