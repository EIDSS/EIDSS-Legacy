using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.smartphone.web.Models
{
    public class UploadModel
    {
        public IList<HumanCaseInfoOut> HumanCases { get; set; }
        public IList<VetCaseInfoOut> VetCases { get; set; }
        public IList<ASSessionInfoOut> ASSessions { get; set; }

        public string ErrorMessage { get; set; }
    }
}