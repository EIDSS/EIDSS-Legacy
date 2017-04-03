using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace bv.model.Model.Core
{
    public class CompareModel
    {
        public class CompareModelItem
        {
            public string propertyName;
            public string controlName;
            public string typeName;
            public string value;
            public bool readOnly;
            public bool invisible;
            public bool mandatory;
        }

        public Dictionary<string, CompareModelItem> Values { get; protected set; }

        public CompareModel()
        {
            Values = new Dictionary<string, CompareModelItem>();
        }

        public void Add(string property, string control, string type, string val, bool rdonly, bool invis, bool mand)
        {
            var item = new CompareModelItem() { propertyName = property, controlName = control, typeName = type, value = val, readOnly = rdonly, invisible = invis, mandatory = mand };
            if (Values.ContainsKey(control))
                Values[control] = item;
            else
                Values.Add(control, item);
        }
    }
}
