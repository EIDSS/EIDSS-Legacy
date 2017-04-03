using System;
using System.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;

namespace eidss.model.Schema
{
    public partial class SampleTypeForDiagnosisLookup
    {
        public static implicit operator AsSessionAnimalSample.AsSessionSampleTypeForDiagnosis(SampleTypeForDiagnosisLookup o)
        {
            if (o == null)
                return null;

            return new AsSessionAnimalSample.AsSessionSampleTypeForDiagnosis()
                {
                    Key = o.idfsReference,
                    name = o.name,
                    classname = ""
                };
        }
    }
}
