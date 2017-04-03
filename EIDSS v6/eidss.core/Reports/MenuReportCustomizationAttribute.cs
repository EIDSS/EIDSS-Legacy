using System;
using eidss.model.Enums;

namespace eidss.model.Reports
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class MenuReportCustomizationAttribute:Attribute
    {
        public MenuReportCustomizationAttribute()
        {
            Forbidden = new CustomizationPackage[0];
        }

        public MenuReportCustomizationAttribute(CustomizationPackage allowed)
        {
            Allowed = allowed;
            Forbidden = new CustomizationPackage[0];
        }

        public CustomizationPackage Allowed { get; private set; }
        public CustomizationPackage[] Forbidden { get; set; }
        public bool AbsentInWeb { get; set; }
         
    }
}