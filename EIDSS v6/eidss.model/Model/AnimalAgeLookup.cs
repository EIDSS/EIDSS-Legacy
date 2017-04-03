using System;
using System.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;

namespace eidss.model.Schema
{
    public partial class AnimalAgeLookup
    {
        public static implicit operator AsSessionAnimalSample.AsSessionAnimalAge(AnimalAgeLookup o)
        {
            if (o == null)
                return null;

            return new AsSessionAnimalSample.AsSessionAnimalAge()
                {
                    Key = o.idfsReference,
                    name = o.name,
                    idfsSpeciesType = o.idfsSpeciesType
                };
        }
    }
}
