using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eidss.model.Enums;
using bv.model.Model.Core;
using eidss.model.Schema;
namespace eidss.winclient.AggregateCase
{
    class AreaComparer : IEqualityComparer<IObject>
    {
        private StatisticAreaType m_AreaType;
        public AreaComparer(StatisticAreaType areaType)
        {
            m_AreaType = areaType;
        }
        public bool Equals(IObject x, IObject y)
        {
            //Check whether the compared objects reference the same data.

            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            switch (m_AreaType)
            {
                case StatisticAreaType.Country:
                    return x.GetValue("idfsCountry").Equals(y.GetValue("idfsCountry"));
                case StatisticAreaType.Rayon:
                    return x.GetValue("idfsRayon").Equals(y.GetValue("idfsRayon"));
                case StatisticAreaType.Region:
                    return x.GetValue("idfsRegion").Equals(y.GetValue("idfsRegion"));
                case StatisticAreaType.Settlement:
                    return x.GetValue("idfsSettlement").Equals(y.GetValue("idfsSettlement"));
                default:
                    return true;

            }

        }

        public int GetHashCode(IObject obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;
            switch (m_AreaType)
            {
                case StatisticAreaType.Country:
                    return obj.GetValue("idfsCountry") == null ? 0 : obj.GetValue("idfsCountry").GetHashCode();
                case StatisticAreaType.Rayon:
                    return obj.GetValue("idfsRayon") == null ? 0 : obj.GetValue("idfsRayon").GetHashCode();
                case StatisticAreaType.Region:
                    return obj.GetValue("idfsRegion") == null ? 0 : obj.GetValue("idfsRegion").GetHashCode();
                case StatisticAreaType.Settlement:
                    return obj.GetValue("idfsSettlement") == null ? 0 : obj.GetValue("idfsSettlement").GetHashCode();
                default:
                    return 0;

            }
        }
    }
}
