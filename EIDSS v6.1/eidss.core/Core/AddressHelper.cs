using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eidss.model.Resources;

namespace eidss.model.Core
{
    public class AddressHelper
    {
        public static string GetHouseBuildingAptCaption()
        {
            return String.Join("/", EidssFields.Get("strHouse"), EidssFields.Get("strBuilding"),
                               EidssFields.Get("strApartment"));
        }
        public static string GetBuildingHouseAptCaption()
        {
            return String.Join("/", EidssFields.Get("strBuilding"), EidssFields.Get("strHouse"),
                               EidssFields.Get("strApartment"));

        }
    }
}
