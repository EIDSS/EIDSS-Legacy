namespace eidss.smartphone.web.Models
{
    public class VetCaseInfoOut : VetCaseInfoIn
    {
        public string lastErrorDescription { get; set; }

        public bool isCreated { get; set; }
        public bool isUpdated { get; set; }
        public bool isFailed { get; set; }

        public VetCaseInfoOut(VetCaseInfoIn vcin)
        {
            idfCase = vcin.idfCase;
            uidOfflineCaseID = vcin.uidOfflineCaseID;
            strCaseID = vcin.strCaseID;
            lastErrorDescription = string.Empty;
        }
    }
}