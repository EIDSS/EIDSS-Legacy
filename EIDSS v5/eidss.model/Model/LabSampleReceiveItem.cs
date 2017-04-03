using System.Collections.Generic;
using eidss.model.Enums;

namespace eidss.model.Schema
{
    public partial class LabSampleReceiveItem
    {
        /*public LabSampleReceiveItem DeepClone()
        {
            LabSampleReceiveItem ret = base.Clone() as LabSampleReceiveItem;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
            Accessor acc = Accessor.Instance(null);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc._SetupLoad(manager, ret);
            }
            return ret;
        }*/

        /*partial void Cloned(DbManagerProxy manager, IObject clone)
        {
            ((LabSampleReceiveItem)clone).m_IsNew = this.m_IsNew;
        }*/

        public class SampleTypeForDiagnosisLookupComparator : EqualityComparer<SampleTypeForDiagnosisLookup>
        {
            public override bool Equals(SampleTypeForDiagnosisLookup x, SampleTypeForDiagnosisLookup y)
            {
                return x.idfsReference.Equals(y.idfsReference);
            }

            public override int GetHashCode(SampleTypeForDiagnosisLookup obj)
            {
                return (obj == null) ? base.GetHashCode() : obj.idfsReference.GetHashCode();
            }
        }

        public partial class LabSampleReceiveItemGridModelList
        {
            partial void filter(List<LabSampleReceiveItem> items)
            {
                items.RemoveAll(c => c.idfsSpecimenType == (long) SampleTypeEnum.Unknown || c.idfsSpecimenType == 0);
            }
        }
    }
}