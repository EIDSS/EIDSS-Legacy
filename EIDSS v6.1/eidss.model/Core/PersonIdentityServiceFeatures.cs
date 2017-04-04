using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.model.Core
{
    public class PersonIdentityServiceFeatures
    {
        public bool IsAvailable { get; set; }
        public bool IsOnHumanCase { get; set; }
        public bool IsOnPatient { get; set; }
        public bool IsOnHumanCasePatient { get; set; }
        public bool IsOnContactedPerson { get; set; }
        public string ButtonResId { get; set; }
    }
}
