using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace eidss.smartphone.web.Models
{
public partial class SpeciesInfoIn
{
    public String lang { get; set; }
    public int intChanged { get; set; }
      public long idParent { get; set; }
      public long idfsFormTemplate { get; set; }
      public long idfObservation { get; set; }
      public long idfsSpeciesType { get; set; }
      public int intTotalAnimalQty { get; set; }
      public int intDeadAnimalQty { get; set; }
      public int intSickAnimalQty { get; set; }
      public String strNote { get; set; }
      public int intAverageAge { get; set; }
      public DateTime datStartOfSignsDate { get; set; }

    public SpeciesInfoIn(XElement xml)
    {
          lang = GetString(xml, "lang", lang);
          intChanged = GetInt(xml, "intChanged", intChanged);
          idParent = GetLong(xml, "idParent", idParent);
          idfsFormTemplate = GetLong(xml, "idfsFormTemplate", idfsFormTemplate);
          idfObservation = GetLong(xml, "idfObservation", idfObservation);
          idfsSpeciesType = GetLong(xml, "idfsSpeciesType", idfsSpeciesType);
          intTotalAnimalQty = GetInt(xml, "intTotalAnimalQty", intTotalAnimalQty);
          intDeadAnimalQty = GetInt(xml, "intDeadAnimalQty", intDeadAnimalQty);
          intSickAnimalQty = GetInt(xml, "intSickAnimalQty", intSickAnimalQty);
          strNote = GetString(xml, "strNote", strNote);
          intAverageAge = GetInt(xml, "intAverageAge", intAverageAge);
          datStartOfSignsDate = GetDateTime(xml, "datStartOfSignsDate", datStartOfSignsDate);
        }
    }
}
