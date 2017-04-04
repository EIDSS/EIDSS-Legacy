using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using eidss.model.Core;

namespace eidss.smartphone.web.Models
{
    public partial class FarmInfoIn : InfoInBase
    {
        public List<SpeciesInfoIn> species { get; set; }

        public static IEnumerable<FarmInfoIn> GetList(long idfsRegion)
        {
            var list = new List<long>();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                list = FarmListItem.Accessor.Instance(null)
                    .SelectListT(manager, new FilterParams().Add("idfsRegion", "=", idfsRegion))
                    .Where(c => !string.IsNullOrEmpty(c.strOwnerName) || !string.IsNullOrEmpty(c.strNationalName))
                    .Select(c => c.idfFarm).ToList();
                return list.Select(c => new FarmInfoIn(FarmRoot.Accessor.Instance(null).SelectByKey(manager, c))).ToList();
            }
        }

        public FarmInfoIn()
        {
            species = new List<SpeciesInfoIn>();
        }

        public FarmInfoIn(FarmRoot f)
        {
            blnIsRoot = true;
            uidOfflineCaseID = null;
            idfFarm = f.idfFarm;
            idfRootFarm = f.idfRootFarm.GetValueOrDefault();
            strFarmCode = f.strFarmCode;
            strFarmName = f.strNationalName;
            strOwnerLastName = f.strOwnerLastName;
            strOwnerFirstName = f.strOwnerFirstName;
            strOwnerMiddleName = f.strOwnerMiddleName;
            idfsRegion = f.Address.idfsRegion.GetValueOrDefault();
            idfsRayon = f.Address.idfsRayon.GetValueOrDefault();
            idfsSettlement = f.Address.idfsSettlement.GetValueOrDefault();
            strStreetName = f.Address.strStreetName;
            strBuilding = f.Address.strBuilding;
            strHouse = f.Address.strHouse;
            strApartment = f.Address.strApartment;
            strPostCode = f.Address.strPostCode;
            strPhone = f.strContactPhone;
            strFax = f.strFax;
            strEmail = f.strEmail;
            dblLongitude = f.Address.dblLongitude.GetValueOrDefault();
            dblLatitude = f.Address.dblLatitude.GetValueOrDefault();

            species = new List<SpeciesInfoIn>();
        }

        public FarmInfoIn(AsSessionFarm f)
        {
            blnIsRoot = false;
            uidOfflineCaseID = f.Farm.uidOfflineCaseID.HasValue ? f.Farm.uidOfflineCaseID.ToString() : "";
            idfFarm = f.Farm.idfFarm;
            idfRootFarm = f.Farm.idfRootFarm.GetValueOrDefault();
            strFarmCode = f.Farm.strFarmCode;
            strFarmName = f.Farm.strNationalName;
            strOwnerLastName = f.Farm.strOwnerLastName;
            strOwnerFirstName = f.Farm.strOwnerFirstName;
            strOwnerMiddleName = f.Farm.strOwnerMiddleName;
            idfsRegion = f.Farm.Address.idfsRegion.GetValueOrDefault();
            idfsRayon = f.Farm.Address.idfsRayon.GetValueOrDefault();
            idfsSettlement = f.Farm.Address.idfsSettlement.GetValueOrDefault();
            strStreetName = f.Farm.Address.strStreetName;
            strBuilding = f.Farm.Address.strBuilding;
            strHouse = f.Farm.Address.strHouse;
            strApartment = f.Farm.Address.strApartment;
            strPostCode = f.Farm.Address.strPostCode;
            strPhone = f.Farm.strContactPhone;
            strFax = f.Farm.strFax;
            strEmail = f.Farm.strEmail;
            dblLongitude = f.Farm.Address.dblLongitude.GetValueOrDefault();
            dblLatitude = f.Farm.Address.dblLatitude.GetValueOrDefault();

            species = new List<SpeciesInfoIn>();
        }

        public void FillAsSessionFarm(AsSessionFarm f)
        {
            blnIsRoot = false;
            f.Farm.uidOfflineCaseID = String.IsNullOrEmpty(uidOfflineCaseID) ? new Guid?() : new Guid(uidOfflineCaseID);
            f.Farm.idfRootFarm = f.idfRootFarm;
            f.Farm.strFarmCode = strFarmCode;
            f.Farm.strNationalName = strFarmName;
            f.Farm.strOwnerLastName = strOwnerLastName;
            f.Farm.strOwnerFirstName = strOwnerFirstName;
            f.Farm.strOwnerMiddleName = strOwnerMiddleName;
            f.Farm.Address.Region = f.Farm.Address.RegionLookup.FirstOrDefault(c => c.idfsRegion == idfsRegion);
            f.Farm.Address.Rayon = f.Farm.Address.RayonLookup.FirstOrDefault(c => c.idfsRayon == idfsRayon);
            f.Farm.Address.Settlement = f.Farm.Address.SettlementLookup.FirstOrDefault(c => c.idfsSettlement == idfsSettlement);
            f.Farm.Address.strStreetName = strStreetName;
            f.Farm.Address.strBuilding = strBuilding;
            f.Farm.Address.strHouse = strHouse;
            f.Farm.Address.strApartment = strApartment;
            f.Farm.Address.strPostCode = strPostCode;
            f.Farm.strContactPhone = strPhone;
            f.Farm.strFax = strFax;
            f.Farm.strEmail = strEmail;
            f.Farm.Address.dblLongitude = dblLongitude == 0 ? new double?() : dblLongitude;
            f.Farm.Address.dblLatitude = dblLatitude == 0 ? new double?() : dblLatitude;
        }


        public static FarmInfoIn Init(XElement xml)
        {
            FarmInfoIn ret = new FarmInfoIn(xml);
            ret.species = new List<SpeciesInfoIn>();
            xml.Element("species").Elements("kind").ToList().ForEach(c => ret.species.Add(SpeciesInfoIn.Init(c)));
            return ret;
        }
    }
}