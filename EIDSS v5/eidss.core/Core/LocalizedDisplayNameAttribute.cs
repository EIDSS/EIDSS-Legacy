using System;
using System.ComponentModel;
using eidss.model.Resources;

namespace eidss.model.Core
{
    public class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {


        public LocalizedDisplayNameAttribute(string displayNameKey)
            : base(displayNameKey)
        {

        }

        public override string DisplayName
        {
            get
            {
                try
                {
                    var result = (EidssFields.Instance).GetString(base.DisplayName);
                    if (String.IsNullOrWhiteSpace(result))
                        result = base.DisplayName;
                    return result;

                }
                catch (Exception)
                {
                    return base.DisplayName;
                }
            }
        }

        public string DisplayNameBase
        {
            get
            {
                return base.DisplayName;
            }
        }

    }
}
