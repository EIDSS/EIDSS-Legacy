using System;
using System.Xml.Linq;
using eidss.model.Schema;
using eidss.model.Model.FlexibleForms.Helpers;

namespace eidss.smartphone.web.Models
{
    public partial class AnimalInfoIn : InfoInBase
    {
        public FFModelIn FFPresenterCs { get; set; }

        public AnimalInfoIn()
        {
        }

        public AnimalInfoIn(AnimalListItem a)
        {
            uidOfflineCaseID = a.uidOfflineCaseID.HasValue ? a.uidOfflineCaseID.Value.ToString("D") : "";
            idfHerd = a.idfHerd;
            idfAnimal = a.idfAnimal;
            idfsSpeciesType = a.idfsSpeciesType;
            strAnimalCode = a.strAnimalCode == null ? "" : a.strAnimalCode;
            idfsAnimalCondition = a.idfsAnimalCondition.HasValue ? a.idfsAnimalCondition.Value : 0;
            idfsAnimalAge = a.idfsAnimalAge.HasValue ? a.idfsAnimalAge.Value : 0;
            idfsAnimalGender = a.idfsAnimalGender.HasValue ? a.idfsAnimalGender.Value : 0;
            idfObservation = a.idfObservation.HasValue ? a.idfObservation.Value : 0;
        } 

        public static AnimalInfoIn Init(XElement xml)
        {
            AnimalInfoIn ret = new AnimalInfoIn(xml);
            ret.FFPresenterCs = new FFModelIn(xml.Element("ffmodel"));
            return ret;
        }

        public void FillVetCaseAnimal(AnimalListItem a, long idfHerd, long? idfSpecies)
        {
            a.uidOfflineCaseID = String.IsNullOrEmpty(uidOfflineCaseID) ? new Guid?() : new Guid(uidOfflineCaseID);
            a.idfHerd = idfHerd;
            a.idfsSpeciesType = idfsSpeciesType;
            a.idfSpecies = idfSpecies;

            a.strAnimalCode = strAnimalCode;
            a.idfsAnimalAge = idfsAnimalAge == 0 ? null : (long?)idfsAnimalAge;
            a.idfsAnimalCondition = idfsAnimalCondition == 0 ? null : (long?)idfsAnimalCondition;
            a.idfsAnimalGender = idfsAnimalGender == 0 ? null : (long?)idfsAnimalGender;

            //FF
            foreach (var p in FFPresenterCs.parameters)
            {
                var ap = a.FFPresenterCs.ActivityParameters.SetActivityParameterValue(
                    a.FFPresenterCs.CurrentTemplate
                    , a.idfObservation.Value
                    , p.idfsParameter
                    , p.Value
                    );
                if (ap != null) ap.IsDynamicParameter = true; //just in case
            }
        }


    }
}