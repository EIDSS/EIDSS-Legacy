using eidss.model.Core;
using eidss.model.customization.Azerbaijan;
using eidss.model.customization.Thailand;
using eidss.model.customization.Georgia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eidss.model.Enums;

namespace eidss.model.customization.Core
{
    public static class CustomizationCreator
    {
        public static ICustomization Create(long CustomizationPackageID)
        {
            switch(CustomizationPackageID)
            {
                case (long)CustomizationPackage.Azerbaijan:
                    return new AzerbaijanCustomization();
                case (long)CustomizationPackage.Georgia: //DTRA:
                    return new GeorgiaCustomization();
                case (long)CustomizationPackage.Thailand:
                    return new ThailandCustomization();
                default:
                    return new BaseCustomization();
            }
        }
    }
}
