using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using System.Reflection;

namespace eidss.model.Schema
{   
    public partial class Address
    {
        private class PropertySorterByName : IComparer<PropertyInfo>
        {
            public int Compare(PropertyInfo x, PropertyInfo y)
            {
                if (x == null)
                {
                    if (y == null)
                        return 0;
                    else
                        return -1;
                }
                else
                {
                    if (y == null)
                        return 1;
                    else
                    {
                        string[] helper = new string[] { x.Name, y.Name };
                        Array.Sort(helper);
                        if (helper[0] == x.Name)
                            return -1;
                        if (helper[0] == y.Name)
                            return 1;
                        return 0;
                    }
                }

            }
        }

        string[] FIELDS_NOT_FOR_COPY = new string[] { "ObjectIdent", "ObjectName", "Key", "idfGeoLocation" };
        string[] FIELDS_FOR_COPY = new string[] {
                "idfsCountry",
                "idfsRegion",
                "idfsRayon",
                "idfsSettlement",
                "Country",
                "Region",
                "Rayon",                                
                "Settlement",
                "Street",
                "PostCode",
                "strApartment",
                "strPostCode",
                "strHouse",
                "strBuilding",
                "strStreetName"                                
        };
        public void CopyFieldsTo(Address target)
        {                         
            foreach (var prop in FIELDS_FOR_COPY)
            {
                if (this.GetValue(prop) != null)
                    target.SetValue(prop, this.GetValue(prop).ToString());
            }
        }

        private string CreateAddressString()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return manager.SetCommand(@"select dbo.fnCreateAddressString(@LangID, @Country, @Region, @Rayon, @PostCode, @SettlementType, @Settlement, @Street, @House, @Building, @Appartment, @ResType)",
                    manager.Parameter("@LangID", ModelUserContext.CurrentLanguage),
                    manager.Parameter("@Country", Country == null ? "" : Country.strCountryName),
                    manager.Parameter("@Region", Region == null ? "" : Region.strRegionName),
                    manager.Parameter("@Rayon", Rayon == null ? "" : Rayon.strRayonName),
                    manager.Parameter("@PostCode", strPostCode ?? ""),
                    manager.Parameter("@SettlementType", ""),
                    manager.Parameter("@Settlement", Settlement == null ? "" : Settlement.strSettlementName),
                    manager.Parameter("@Street", strStreetName ?? ""),
                    manager.Parameter("@House", strHouse ?? ""),
                    manager.Parameter("@Building", strBuilding ?? ""),
                    manager.Parameter("@Appartment", strApartment ?? ""),
                    manager.Parameter("@ResType", ResidentType == null ? "" : ResidentType.name)
                    ).ExecuteScalar<string>();
            }
        }

        /*public Address DeepClone()
        {
            var ret = base.Clone() as Address;
            Accessor acc = Accessor.Instance(null);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc._SetupLoad(manager, ret);
            }
            ret._permissions = _permissions;
            return ret;
        }*/

        public Address CopyFrom(Address source)
        {
            // copy all fields, except primaryKey
            Address ret = source.CloneWithSetup();
            
            if (ret == null)
            {
                return null;
            }

            ret.idfGeoLocation = idfGeoLocation;
            ret.SetChange();
            
            return ret;
        }

        public void CopyGeoLocationValues(GeoLocation source)
        {
            //match properties to copy             
            var props = from a in this.GetType().GetProperties()
                        join g in source.GetType().GetProperties()                                                  
                        on new {a.Name} equals new {g.Name} 
                        into pros
                        select new {Name = a.Name};
            foreach (var prop in props.Where(p => !FIELDS_NOT_FOR_COPY.Contains(p.Name)))
            {
                if (source.GetValue(prop.Name) != null)
                    this.SetValue(prop.Name, source.GetValue(prop.Name).ToString());
            }
        }

        public bool IsCoordinatesInRayon()
        {
            if (!dblLatitude.HasValue && !dblLongitude.HasValue)
            {
                return true;
            }

            if (!dblLatitude.HasValue || !dblLongitude.HasValue)
            {
                return false;
            }

            long? countryId;
            long? regionId;
            long? rayonId;

            if (!gis.common.CoordinatesUtils.CoordToAdm(out countryId, out regionId, out rayonId, new ConnectionCredentials().ConnectionString,
                dblLatitude.Value, dblLongitude.Value))
            {
                return true;
            }

            if (idfsRayon.HasValue)
            {
                if (!rayonId.HasValue || !idfsRayon.Value.Equals(rayonId.Value))
                {
                    return false;
                }
                    
            }
            return true;
        }

        public bool IsCoordinatesInRegion()
        {
            if (!dblLatitude.HasValue && !dblLongitude.HasValue)
            {
                return true;
            }

            if (!dblLatitude.HasValue || !dblLongitude.HasValue)
            {
                return false;
            }

            long? countryId;
            long? regionId;
            long? rayonId;

            if (!gis.common.CoordinatesUtils.CoordToAdm(out countryId, out regionId, out rayonId, new ConnectionCredentials().ConnectionString,
                dblLatitude.Value, dblLongitude.Value))
            {
                return true;
            }

            if (!idfsRayon.HasValue && idfsRegion.HasValue)
            {
                if (!regionId.HasValue || !idfsRegion.Value.Equals(regionId.Value))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsCoordinatesInCountry()
        {
            if (!dblLatitude.HasValue && !dblLongitude.HasValue)
            {
                return true;
            }
            
            if (!dblLatitude.HasValue || !dblLongitude.HasValue)
            {
                return false;
            }

            long? countryId;
            long? regionId;
            long? rayonId;

            if (!gis.common.CoordinatesUtils.CoordToAdm(out countryId, out regionId, out rayonId, new ConnectionCredentials().ConnectionString,
                dblLatitude.Value, dblLongitude.Value))
            {
                return true;
            }

            if (!idfsRegion.HasValue && idfsCountry.HasValue)
            {
                if (!countryId.HasValue || !idfsCountry.Value.Equals(countryId.Value))
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}
