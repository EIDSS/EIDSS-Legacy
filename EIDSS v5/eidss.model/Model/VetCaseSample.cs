using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace eidss.model.Schema
{
    public partial class VetCaseSample
    {
        /*public VetCaseSample DeepClone()
        {
            VetCaseSample ret = base.Clone() as VetCaseSample;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
            Accessor acc = Accessor.Instance(null);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc._SetupLoad(manager, ret);
            }
            return ret;
        }*/

        public class SampleTypeForDiagnosisLookupComparator : EqualityComparer<SampleTypeForDiagnosisLookup>
        {
            public override bool Equals(SampleTypeForDiagnosisLookup x, SampleTypeForDiagnosisLookup y)
            {
                return x.idfsReference.Equals(y.idfsReference);
            }

            public override int GetHashCode(SampleTypeForDiagnosisLookup obj)
            {
                return obj.idfsReference.GetHashCode();
            }
        }
    }
}
