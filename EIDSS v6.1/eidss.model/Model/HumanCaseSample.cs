using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;

namespace eidss.model.Schema
{
    public partial class HumanCaseSample
    {
        /*public HumanCaseSample DeepClone()
        {
            HumanCaseSample ret = base.Clone() as HumanCaseSample;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
            Accessor acc = Accessor.Instance(null);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc._SetupLoad(manager, ret);
            }
            return ret;
        }*/

        public partial class HumanCaseSampleGridModelList
        {
            partial void filter(List<HumanCaseSample> items)
            {
                items.RemoveAll(c => c.idfsSampleType == (long)SampleTypeEnum.Unknown);
            }
        }

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
