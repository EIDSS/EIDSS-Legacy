using System;
using bv.common.Core;

namespace eidss.model.AVR.ServiceData
{
    public class BaseColumnModel
    {
        public BaseColumnModel(string name, Type type) : this(name, name, type)
        {
        }

        public BaseColumnModel(string name, string caption, Type type)
        {
            Utils.CheckNotNullOrEmpty(name, "name");
            Name = name;
            Caption = caption;
            Type = type;
        }

        public string Name { get; private set; }
        public string Caption { get; private set; }
        public Type Type { get; private set; }
    }
}