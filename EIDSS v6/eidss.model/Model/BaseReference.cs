using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace eidss.model.Schema
{
    public partial class BaseReference
    {
        public static implicit operator AsSessionAnimalSample.AsSessionBaseReference(BaseReference o)
        {
            if (o == null)
                return null;

            return new AsSessionAnimalSample.AsSessionBaseReference()
            {
                Key = o.idfsBaseReference,
                name = o.name
            };
        }
    }

    public class BaseReferenceList : List<BaseReference>
    {
        public string Section { get; protected set; }
        public BaseReferenceList(string section)
        {
            Section = section;
        }

    }

    public static class BaseReferenceListUtil
    {
        public static BaseReferenceList ToBaseReferenceList(this IEnumerable<BaseReference> source, string section)
        {
            var ret = new BaseReferenceList(section);
            ret.AddRange(source);
            return ret;
        }
    }
}
