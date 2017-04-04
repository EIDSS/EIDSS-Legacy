using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace eidss.smartphone.web.Models
{
public partial class AnimalInfoIn
{
    public String lang { get; set; }
    public int intChanged { get; set; }
      public String uidOfflineCaseID { get; set; }
      public long idParent { get; set; }
      public long idfHerd { get; set; }
      public long idfAnimal { get; set; }
      public long idfsSpeciesType { get; set; }
      public String strAnimalCode { get; set; }
      public long idfsAnimalAge { get; set; }
      public long idfsAnimalGender { get; set; }
      public long idfsAnimalCondition { get; set; }
      public long idfObservation { get; set; }

    public AnimalInfoIn(XElement xml)
    {
          lang = GetString(xml, "lang", lang);
          intChanged = GetInt(xml, "intChanged", intChanged);
          uidOfflineCaseID = GetString(xml, "uidOfflineCaseID", uidOfflineCaseID);
          idParent = GetLong(xml, "idParent", idParent);
          idfHerd = GetLong(xml, "idfHerd", idfHerd);
          idfAnimal = GetLong(xml, "idfAnimal", idfAnimal);
          idfsSpeciesType = GetLong(xml, "idfsSpeciesType", idfsSpeciesType);
          strAnimalCode = GetString(xml, "strAnimalCode", strAnimalCode);
          idfsAnimalAge = GetLong(xml, "idfsAnimalAge", idfsAnimalAge);
          idfsAnimalGender = GetLong(xml, "idfsAnimalGender", idfsAnimalGender);
          idfsAnimalCondition = GetLong(xml, "idfsAnimalCondition", idfsAnimalCondition);
          idfObservation = GetLong(xml, "idfObservation", idfObservation);
        }
    }
}
