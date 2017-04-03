using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace eidss.model.Schema
{
    public partial class AsSessionAnimalSample
    {
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
    }
}
