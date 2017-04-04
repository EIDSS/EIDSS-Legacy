using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.smartphone.web.Models
{
    public class HumanCaseInfoOut : HumanCaseInfoIn
    {
        public string lastErrorDescription { get; set; }

        public bool isCreated { get; set; }
        public bool isUpdated { get; set; }
        public bool isFailed { get; set; }

        public HumanCaseInfoOut(HumanCaseInfoIn hcin)
        {
            idfCase = hcin.idfCase;
            uidOfflineCaseID = hcin.uidOfflineCaseID;
            strCaseID = hcin.strCaseID;
            lastErrorDescription = "";
        }
    }
}