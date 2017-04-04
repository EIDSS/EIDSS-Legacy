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
            InitilalType = type;
            FinalType = type;
        }

        protected BaseColumnModel(BaseColumnModel original)
        {
            Utils.CheckNotNull(original, "original");

            Name = original.Name;
            Caption = original.Caption;
            InitilalType = original.InitilalType;
            FinalType = original.FinalType;
        }

        public string Name { get; private set; }
        public string Caption { get; private set; }
        public Type InitilalType { get; private set; }
        public Type FinalType { get; private set; }

        public bool TryChangeType(Type newType)
        {
            if (FinalType == newType)
            {
                return true;
            }
            if (FinalType == typeof (object))
            {
                FinalType = newType;
                return true;
            }

            return false;
        }

        public BaseColumnModel Clone()
        {
            return new BaseColumnModel(this);
        }

        public override string ToString()
        {
            return string.Format("{0}, Type='{1}'", Name, FinalType);
        }
    }
}