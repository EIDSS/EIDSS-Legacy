using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;

namespace eidss.model.Schema
{
    public partial class GeoLocation
    {
        string[] FIELDS_NOT_FOR_COPY = new string[] { "ObjectIdent", "ObjectName", "Key", "idfGeoLocation" };

        public void CopyFieldsTo(GeoLocation target)
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                if (!FIELDS_NOT_FOR_COPY.Contains(prop.Name) && this.GetValue(prop.Name) != null)
                    target.SetValue(prop.Name, this.GetValue(prop.Name).ToString());
            }
        }

        public bool IsWinClient { get; set; }
        public GeoLocation GetForEdit()
        {
            var ret = CloneWithSetup();
            bool isNew = ret.idfsGeoLocationType == (long) GeoLocationTypeEnum.ExactPoint && ret.idfsRegion == null;
            if (ret.Parent is HumanCase && isNew)
            {
                var hc = ret.Parent as HumanCase;
                ret.Country = hc.Patient.CurrentResidenceAddress.Country;
                ret.Region = hc.Patient.CurrentResidenceAddress.Region;
                ret.Rayon = hc.Patient.CurrentResidenceAddress.Rayon;
            }
            if (ret.idfsGeoLocationType != (long)GeoLocationTypeEnum.Address && ret.idfsCountry == null)
            {
                ret.SetDefaultCountry();
            }
            ret.bNeedChangeContryOnTypeChange = true;
            return ret;
        }

        public void SetDefaultCountry()
        {
            Country = CountryLookup.SingleOrDefault(i => i.idfsCountry == Core.EidssSiteContext.Instance.CountryID);
        }

        private string CreateGeoLocationString()
        {
            if (IsNull) return "";
            if (bNeedCreateGeoLocationString || Utils.IsEmpty(strAddressStringTranslate))
            {
                try
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        strAddressStringTranslate = manager.SetCommand(@"select dbo.fnCreateGeoLocationString(@LangID, @GeoLocationType, @Country, @Region, @Rayon, @Latitude, @Longitude, @PostCode, @SettlementType, @Settlement, @Street, @House, @Building, @Apartment, @Alignment, @Distance, @blnForeignAddress, @strForeignAddress)",
                        manager.Parameter("@LangID", ModelUserContext.CurrentLanguage),
                        manager.Parameter("@GeoLocationType", idfsGeoLocationType),
                        manager.Parameter("@Country", Country == null ? "" : Country.strCountryName),
                        manager.Parameter("@Region", Region == null ? "" : Region.strRegionName),
                        manager.Parameter("@Rayon", Rayon == null ? "" : Rayon.strRayonName),
                        manager.Parameter("@Latitude", dblLatitude == null ? "0" : dblLatitude.Value.ToString("0.00000")),
                        manager.Parameter("@Longitude", dblLongitude == null ? "0" : dblLongitude.Value.ToString("0.00000")),
                        manager.Parameter("@PostCode", strPostCode ?? ""),
                        manager.Parameter("@SettlementType", Settlement == null ? "" : Settlement.strSettlementType),
                        manager.Parameter("@Settlement", Settlement == null ? "" : Settlement.strSettlementName),
                        manager.Parameter("@Street", strStreetName ?? ""),
                        manager.Parameter("@House", strHouse ?? ""),
                        manager.Parameter("@Building", strBuilding ?? ""),
                        manager.Parameter("@Apartment", strApartment ?? ""),
                            manager.Parameter("@Alignment", dblAlignment ?? 0),
                            manager.Parameter("@Distance", dblDistance ?? 0),
                        manager.Parameter("@blnForeignAddress", idfsGeoLocationType == (long)GeoLocationTypeEnum.Address),
                        manager.Parameter("@strForeignAddress", strForeignAddress ?? "")
                        ).ExecuteScalar<string>();
                    }

                }
                catch
                {
                    strAddressStringTranslate = "";
                }
                bNeedCreateGeoLocationString = false;
            }
            return strAddressStringTranslate;
        }

        /*public GeoLocation DeepClone()
        {
            GeoLocation ret = base.Clone() as GeoLocation;
            Accessor acc = Accessor.Instance(null);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc._SetupLoad(manager, ret);
            }
            ret._permissions = _permissions;
            ret.m_IsNew = IsNew;
            return ret;
        }*/

        public void CopyAddressValues(Address source)
        {
            //match properties to copy             
            var props = from a in this.GetType().GetProperties()
                        join g in source.GetType().GetProperties()
                        on new { a.Name } equals new { g.Name }
                        into pros
                        select new { Name = a.Name };
            foreach (var prop in props.Where(p => !FIELDS_NOT_FOR_COPY.Contains(p.Name)))
            {
                if (source.GetValue(prop.Name) != null)
                    this.SetValue(prop.Name, source.GetValue(prop.Name).ToString());
            }
        }

        public bool IsValid()
        {
            if (this.idfsGeoLocationType == (long)GeoLocationTypeEnum.ExactPoint)
                return idfsCountry != null && idfsRegion != null & idfsRayon != null;
            else if (this.idfsGeoLocationType == (long) GeoLocationTypeEnum.Address)
                return idfsCountry != null;
            else
                return idfsCountry != null && idfsRegion != null & idfsRayon != null && idfsSettlement != null;
        }
        public string LocationDisplayName
        {
            get
            {
                if (!IsValid())
                    return "";
                return CreateGeoLocationString();
            }
        }

        public void CalcCoordinates()
        {
            if (idfsGeoLocationType == (long) GeoLocationTypeEnum.Address)
            {
                dblLongitude = null;
                dblLatitude = null;
                return;
            }
            if (!idfsSettlement.HasValue)
            {
                if (idfsGeoLocationType == (long) GeoLocationTypeEnum.RelativePoint)
                {
                    ClearCalculatedCoordinates();
                }

                //dblLongitude = null;
                //dblLatitude = null;
                return;
            }
            double longitude, latitude;
            if (gis.GisInterface.GetSettlementCoordinates((long)idfsSettlement, out longitude, out latitude))
            {
                var bSave = bCancelCoordinationValidation;
                bCancelCoordinationValidation = true;
                dblLongitude = longitude;
                dblLatitude = latitude;
                bCancelCoordinationValidation = bSave;
            }
            if (idfsGeoLocationType == (long)GeoLocationTypeEnum.RelativePoint)
            {
                CalcRelCoordinates();
            }

        }
        private void CalcRelCoordinates()
        {
            if (!dblDistance.HasValue || !dblAlignment.HasValue || !idfsSettlement.HasValue)
            {
                ClearCalculatedCoordinates();
                return;
            }
            double longitude, latitude;
            if (gis.GisInterface.GetRelativeCoordinates((long)idfsSettlement, (double)dblAlignment, (double)dblDistance, out longitude, out latitude))
            {
                dblRelLongitude = longitude;
                dblRelLatitude = latitude;
            }
        }
        private void ClearCalculatedCoordinates()
        {
            dblRelLongitude = null;
            dblRelLatitude = null;
        }
        public static void ValidateLocationCoordinates(GeoLocation location)
        {
            if (location.bCancelCoordinationValidation)
                return;

            if (!location.dblLatitude.HasValue && !location.dblLongitude.HasValue)
                return;
            long? idfsCountry = null;
            long? idfsRegion = null;
            long? idfsRayon = null;
            if (!location.dblLatitude.HasValue || !location.dblLongitude.HasValue)
            {
                throw new ValidationModelException("msgCoordinatesAreNotDefined", "", "", new object[] { },
                                                       null, false, location);

            }
            if (!gis.common.CoordinatesUtils.CoordToAdm(out idfsCountry, out idfsRegion, out idfsRayon, new ConnectionCredentials().ConnectionString,
                location.dblLatitude.Value, location.dblLongitude.Value))
                return;
            if (location.idfsCountry.HasValue)
            {
                if (!idfsCountry.HasValue || !location.idfsCountry.Value.Equals(idfsCountry.Value))
                    throw new ValidationModelException("msgCoordinatesOutOfCountryGeoLocation", "", "", new object[] { },
                                                       null, false, location);

            }
            //Such situation is possible because of unideal map data
            //Let's consider such coordinates as correct
            if (!idfsRegion.HasValue || !idfsRayon.HasValue || !location.idfsRayon.HasValue || !location.idfsRegion.HasValue)
                return;
            if (!location.idfsRayon.Value.Equals(idfsRayon.Value)
                || !location.idfsRegion.Value.Equals(idfsRegion.Value))
            {
                //location.Region = location.RegionLookup.SingleOrDefault(c => c.idfsRegion == idfsRegion.Value);
                //location.Rayon = location.RayonLookup.SingleOrDefault(c => c.idfsRayon == idfsRayon.Value);

                throw new ValidationModelException("msgCoordinatesAutoCorrection", "", "", new object[] { idfsRegion, idfsRayon },
                                                  null, false, location);

            }

        }

        public void SetLocationCoordinates()
        {
            if (this.bCancelCoordinationValidation)
                return;

            if (!this.dblLatitude.HasValue || !this.dblLongitude.HasValue)
                return;

            long? idfsCountryNew = null;
            long? idfsRegionNew = null;
            long? idfsRayonNew = null;
            if (!gis.common.CoordinatesUtils.CoordToAdm(out idfsCountryNew, out idfsRegionNew, out idfsRayonNew, new ConnectionCredentials().ConnectionString,
                this.dblLatitude.Value, this.dblLongitude.Value))
                return;

            if (this.idfsCountry.HasValue)
            {
                if (!idfsCountry.HasValue || !this.idfsCountry.Value.Equals(idfsCountry.Value))
                    return;
            }

            if (this.idfsRegion != idfsRegionNew)
                this.Region = this.RegionLookup.SingleOrDefault(c => c.idfsRegion == idfsRegionNew);
            if (this.idfsRayon != idfsRayonNew)
                this.Rayon = this.RayonLookup.SingleOrDefault(c => c.idfsRayon == idfsRayonNew);
        }

        public GeoLocation CopyFrom(DbManagerProxy manager, GeoLocation source)
        {
            // copy all fields, except primaryKey
            /*
            var ret = source.CloneWithSetup(manager) as GeoLocation;

            if (ret == null)
            {
                return null;
            }

            ret.idfGeoLocation = idfGeoLocation;
            ret.SetChange();

            return ret;
            */
            source.CopyFieldsTo(this);
            return this;
        }


    }
}
