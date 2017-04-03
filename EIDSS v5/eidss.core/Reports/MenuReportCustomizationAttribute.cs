using System;
using eidss.model.Enums;

namespace eidss.model.Reports
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class MenuReportCustomizationAttribute:Attribute
    {
        public MenuReportCustomizationAttribute()
        {
            ForbiddenCountry =new Country[0];
        }

        public MenuReportCustomizationAttribute(Country allowedCountry)
        {
            AllowedCountry = allowedCountry;
            ForbiddenCountry = new Country[0];
        }

        public Country AllowedCountry { get; private set; }
        public Country[] ForbiddenCountry { get;  set; }
        public bool PresentInDtraCustomization { get; set; }
         
    }
}