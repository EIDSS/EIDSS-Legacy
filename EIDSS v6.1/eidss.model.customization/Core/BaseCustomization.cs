using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eidss.model.Core;
using eidss.model.customization.Core;

namespace eidss.model.customization.Core
{
    class BaseCustomization : ICustomization
    {
        public virtual PersonIdentityServiceFeatures PersonIdentityServiceFeatures
        {
            get
            {
                return new PersonIdentityServiceFeatures()
                {
                    IsAvailable = false,
                    IsOnHumanCase = false,
                    IsOnPatient = false,
                    IsOnHumanCasePatient = false,
                    IsOnContactedPerson = false,
                    ButtonResId = "",
                };
            }
        }

        public virtual Tuple<Schema.Patient, string> GetFromPersonIdentityService(Schema.Patient p)
        {
            throw new NotImplementedException();
        }

        public virtual VisibilityFeatures VisibilityFeatures 
        {
            get { 
                return new VisibilityFeatures() 
                { 
                    IsPersonIDBeforeName = false,
                    IsHumanCaseSampleMainTestVisible = true,
                    IsHerdEpiControlMeasuresVisible = true,
                    IsLastNameBeforeFirstName = true,
                    IsOnlyHouseUseInAddress = false,
                }; 
            }
        }

        public virtual string BuildFullName(string last, string first, string middle)
        {
            last = string.IsNullOrWhiteSpace(last) ? "" : last.Trim();
            first = string.IsNullOrWhiteSpace(first) ? "" : first.Trim();
            middle = string.IsNullOrWhiteSpace(middle) ? "" : middle.Trim();
            return (last + " " + first + " " + middle).Trim();
        }
    }
}
