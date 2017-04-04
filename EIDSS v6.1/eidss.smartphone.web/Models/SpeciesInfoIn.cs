using System;
using System.Xml.Linq;
using eidss.model.Schema;

namespace eidss.smartphone.web.Models
{
    public partial class SpeciesInfoIn : InfoInBase
    {
        public FFModelIn FFPresenterCs { get; set; }

        public SpeciesInfoIn()
        {
        }

        public SpeciesInfoIn(VetFarmTree s)
        {
            idfsFormTemplate = s.idfsFormTemplate.HasValue ? s.idfsFormTemplate.Value : 0;
            idfsSpeciesType = s.idfsSpeciesTypeReference.HasValue ? s.idfsSpeciesTypeReference.Value : 0;
            datStartOfSignsDate = s.datStartOfSignsDate.HasValue ? s.datStartOfSignsDate.Value : DateTime.MinValue;
            intTotalAnimalQty = s.intTotalAnimalQty.HasValue ? s.intTotalAnimalQty.Value : 0;
            intSickAnimalQty = s.intSickAnimalQty.HasValue ? s.intSickAnimalQty.Value : 0;
            intDeadAnimalQty = s.intDeadAnimalQty.HasValue ? s.intDeadAnimalQty.Value : 0;
            idfObservation = s.idfObservation.HasValue ? s.idfObservation.Value : 0;
            intAverageAge = s.strAverageAge.HasValue ? s.strAverageAge.Value : 0;
            strNote = s.strNote;
        }

        public static SpeciesInfoIn Init(XElement xml)
        {
            SpeciesInfoIn ret = new SpeciesInfoIn(xml);
            ret.FFPresenterCs = new FFModelIn(xml.Element("ffmodel"));
            return ret;
        }
   }
}