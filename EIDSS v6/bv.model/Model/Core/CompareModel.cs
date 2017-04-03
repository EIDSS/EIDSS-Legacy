using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace bv.model.Model.Core
{
    public class CompareModel
    {
        public class ComboBoxItem
        {
            public object id;
            public string name;
        }

        public class CompareModelItem
        {
            public string propertyName; 
            public string controlName; // {root object name (HumanCase,...}_{id of root object}_{name of field}
            public string typeName; // type of data (string, DateTime, ...)
            public string value; // control's value
            public bool readOnly;
            public bool invisible;
            public bool mandatory;
            public ComboBoxItem[] items;
        }

        public Dictionary<string, CompareModelItem> Values { get; protected set; }

        public CompareModel()
        {
            Values = new Dictionary<string, CompareModelItem>();
        }

        public void Add(string property, string control1, string type, string val, bool rdonly, bool invis, bool mand)
        {
            Add(property, control1, null, null, type, val, rdonly, invis, mand);
        }

        public void Add(string property, string control1, string control2, string control3, string type, string val, bool rdonly, bool invis, bool mand)
        {
            var item = new CompareModelItem() { propertyName = property, controlName = control1, typeName = type, value = val, readOnly = rdonly, invisible = invis, mandatory = mand };
            if (Values.ContainsKey(control1))
                Values[control1] = item;
            else
                Values.Add(control1, item);
            if (control2 != null && control1.CompareTo(control2) != 0)
            {
                item = new CompareModelItem() { propertyName = property, controlName = control2, typeName = type, value = val, readOnly = rdonly, invisible = invis, mandatory = mand };
                if (Values.ContainsKey(control2))
                    Values[control2] = item;
                else
                    Values.Add(control2, item);
            }
            if (control3 != null && control1.CompareTo(control3) != 0)
            {
                item = new CompareModelItem() { propertyName = property, controlName = control3, typeName = type, value = val, readOnly = rdonly, invisible = invis, mandatory = mand };
                if (Values.ContainsKey(control3))
                    Values[control3] = item;
                else
                    Values.Add(control3, item);
            }
        }
    }
}
