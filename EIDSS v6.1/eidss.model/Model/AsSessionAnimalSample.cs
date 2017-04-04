using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using System.Collections.Specialized;

namespace eidss.model.Schema
{
    public partial class AsSessionAnimalSample
    {
        partial void ParsingFormCollection(NameValueCollection form)
        {
            var a = _field_infos.FirstOrDefault(i => i._name == _str_bIsLinkToNewAnimal);
            if (a != null)
            {
                if (form.AllKeys.Contains(ObjectIdent + a._formname))
                {
                    a._set_func(this, form[ObjectIdent + a._formname]);
                }
            }
        }

        public class AsSessionAnimalAge : IComparable<AsSessionAnimalAge>
        {
            public long Key;
            public string name;
            public long? idfsSpeciesType;

            int IComparable<AsSessionAnimalAge>.CompareTo(AsSessionAnimalAge other)
            {
                return (name == null ? "" : name).CompareTo(other.name == null ? "" : other.name);
            }
        }

        public class AsSessionBaseReference : IComparable<AsSessionBaseReference>
        {
            public long Key;
            public string name;

            int IComparable<AsSessionBaseReference>.CompareTo(AsSessionBaseReference other)
            {
                return (name == null ? "" : name).CompareTo(other.name == null ? "" : other.name);
            }
        }

        public class AsSessionSampleTypeForDiagnosis : IComparable<AsSessionSampleTypeForDiagnosis>
        {
            public long Key;
            public string name;
            public string classname;

            int IComparable<AsSessionSampleTypeForDiagnosis>.CompareTo(AsSessionSampleTypeForDiagnosis other)
            {
                return (name == null ? "" : name).CompareTo(other.name == null ? "" : other.name);
            }
        }

        /*public AsSessionAnimalSample CloneAsSample()
        {
            var ret = CloneWithSetup();
            ret.ClonedAsSample = true;
            return ret;
        }*/

        partial void ClonedWithSetup()
        {
            Animals = AnimalsLookup.SingleOrDefault(i => i.idfAnimal == idfAnimal);
        }

        public class AnimalComparator : EqualityComparer<AsSessionAnimalSample>
        {
            public override bool Equals(AsSessionAnimalSample x, AsSessionAnimalSample y)
            {
                return x.idfAnimal.Equals(y.idfAnimal);
            }

            public override int GetHashCode(AsSessionAnimalSample obj)
            {
                return obj.idfAnimal.GetHashCode();
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
