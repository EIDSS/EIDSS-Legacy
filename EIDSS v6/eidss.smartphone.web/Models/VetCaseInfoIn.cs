using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.common;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.model.Schema;
using System.Xml.Linq;
using System.IO;
using eidss.model.Enums;

namespace eidss.smartphone.web.Models
{
    public class VetCaseInfoIn
    {
        public string lang { get; set; }

        public long id { get; set; }
        public string offlineCaseID { get; set; }
        public string caseID { get; set; }
        public string localIdentifier { get; set; }
        public long caseType { get; set; }
        public int caseHACode { get; set; }
        public long caseReportType { get; set; }
        public long tentativeDiagnosis { get; set; }
        public DateTime tentativeDiagnosisDate { get; set; }
        public string farmName { get; set; }
        public string ownerLastName { get; set; }
        public string ownerFirstName { get; set; }
        public string ownerMiddleName { get; set; }
        public long country { get; set; }
        public long region { get; set; }
        public long rayon { get; set; }
        public long settlement { get; set; }
        public string building { get; set; }
        public string house { get; set; }
        public string apartment { get; set; }
        public string street { get; set; }
        public string zipCode { get; set; }
        public string phone { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public DateTime enteredDate { get; set; }
        public List<SpeciesInfoIn> species { get; set; }
        public class SpeciesInfoIn
        {
            public long herd { get; set; }
            public long speciesType { get; set; }
            public DateTime startOfSignsDate { get; set; }
            public int totalAnimalQty { get; set; }
            public int deadAnimalQty { get; set; }
            public int sickAnimalQty { get; set; }
        }

        private long find_by_offline_id(DbManagerProxy manager)
        {
            long ret = VetCaseListItem.Accessor.Instance(null)
                .SelectListT(manager, new FilterParams().Add("uidOfflineCaseID", "=", offlineCaseID))
                .Select(c => c.idfCase).FirstOrDefault();
            return ret;
        }

        public VetCaseInfoIn()
        {
        }

        private long GetLong(XElement xml, string name, long def)
        {
            if (xml.Attribute(name) != null) return long.Parse(xml.Attribute(name).Value);
            return def;
        }
        private int GetInt(XElement xml, string name, int def)
        {
            if (xml.Attribute(name) != null) return int.Parse(xml.Attribute(name).Value);
            return def;
        }
        private double GetDouble(XElement xml, string name, double def)
        {
            if (xml.Attribute(name) != null) return double.Parse(xml.Attribute(name).Value);
            return def;
        }
        private string GetString(XElement xml, string name, string def)
        {
            if (xml.Attribute(name) != null) return xml.Attribute(name).Value;
            return def;
        }
        private DateTime GetDateTime(XElement xml, string name, DateTime def)
        {
            if (xml.Attribute(name) != null) return DateTime.ParseExact(xml.Attribute(name).Value, "yyyy-MM-ddTHH:mm:ss", null); ;
            return def;
        }

        public VetCaseInfoIn(XElement xml)
        {
            lang = bv.common.Core.Localizer.lngEn;

            id = GetLong(xml, "id", id);
            offlineCaseID = GetString(xml, "offlineCaseID", offlineCaseID);
            caseID = GetString(xml, "caseID", caseID);
            localIdentifier = GetString(xml, "localIdentifier", localIdentifier);
            caseType = GetLong(xml, "caseType", caseType);
            caseHACode = GetInt(xml, "caseHACode", caseHACode);
            caseReportType = GetLong(xml, "reportType", caseReportType);
            tentativeDiagnosis = GetLong(xml, "tentativeDiagnosis", tentativeDiagnosis);
            tentativeDiagnosisDate = GetDateTime(xml, "tentativeDiagnosisDate", tentativeDiagnosisDate);
            farmName = GetString(xml, "farmName", farmName);
            ownerFirstName = GetString(xml, "ownerFirstName", ownerFirstName);
            ownerLastName = GetString(xml, "ownerLastName", ownerLastName);
            ownerMiddleName = GetString(xml, "ownerMiddleName", ownerMiddleName);
            country = GetLong(xml, "country", country);
            region = GetLong(xml, "region", region);
            rayon = GetLong(xml, "rayon", rayon);
            settlement = GetLong(xml, "settlement", settlement);
            building = GetString(xml, "building", building);
            house = GetString(xml, "house", house);
            apartment = GetString(xml, "apartment", apartment);
            street = GetString(xml, "street", street);
            zipCode = GetString(xml, "zipCode", zipCode);
            phone = GetString(xml, "phone", phone);
            longitude = GetDouble(xml, "longitude", longitude);
            latitude = GetDouble(xml, "latitude", latitude);
            enteredDate = GetDateTime(xml, "enteredDate", enteredDate);
            species = new List<SpeciesInfoIn>();
            xml.Element("species").Elements("kind").ToList().ForEach(c =>
                {
                    var sp = new SpeciesInfoIn();
                    sp.herd = GetLong(c, "herd", sp.herd);
                    sp.speciesType = GetLong(c, "speciesType", sp.speciesType);
                    sp.startOfSignsDate = GetDateTime(c, "startOfSignsDate", sp.startOfSignsDate);
                    sp.totalAnimalQty = GetInt(c, "totalAnimalQty", sp.totalAnimalQty);
                    sp.deadAnimalQty = GetInt(c, "deadAnimalQty", sp.deadAnimalQty);
                    sp.sickAnimalQty = GetInt(c, "sickAnimalQty", sp.sickAnimalQty);
                    species.Add(sp);
                });
        }

        public static IList<VetCaseInfoOut> Save(XDocument doc)
        {
            var ret = new List<VetCaseInfoOut>();
            doc.Root.Element("veterinary").Elements("case").ToList().ForEach(c => ret.Add(new VetCaseInfoIn(c).Save()));
            return ret;
        }

        public VetCaseInfoOut Save()
        {
            VetCaseInfoOut ret = new VetCaseInfoOut(this);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = VetCase.Accessor.Instance(null);
                var vftacc = VetFarmTree.Accessor.Instance(null);
                VetCase vc = null;
                VetFarmTree herd = null;
                var find = find_by_offline_id(manager);
                if (find != 0)
                {
                    vc = acc.SelectByKey(manager, find);
                    ret.isUpdated = true;
                }
                else
                {
                    if (id != 0)
                    {
                        var audit_acc = DataAuditListItem.Accessor.Instance(null);
                        DataAuditListItem item = audit_acc.CreateNewT(manager, null);
                        var filters = new FilterParams();
                        filters.Add("idfMainObject", "=", id);
                        filters.Add("idfsObjectType", "=", (long)EIDSSAuditObject.daoVetCase);
                        filters.Add("idfsActionName", "=", (long)AuditEventType.daeDelete);
                        List<DataAuditListItem> list = audit_acc.SelectListT(manager, filters,
                            new[] { new KeyValuePair<string, System.ComponentModel.ListSortDirection>("datEnteringDate", System.ComponentModel.ListSortDirection.Descending) });
                        if (list.Count > 0)
                        {
                            DataAuditListItem.Accessor.Instance(null).Restore(manager, list[0]);

                            find = find_by_offline_id(manager);
                            if (find != 0)
                            {
                                vc = acc.SelectByKey(manager, find);
                                ret.isUpdated = true;
                            }
                        }
                    }

                    if (vc == null)
                    {
                        vc = acc.CreateNewT(manager, null, caseHACode);
                        ret.isCreated = true;
                        var farm = vc.Farm.FarmTree.First(t => t.idfsPartyType == (long)PartyTypeEnum.Farm);
                        herd = vftacc.CreateHerd(manager, vc.Farm, farm);
                        vc.Farm.FarmTree.Add(herd);
                    }
                }

                vc.uidOfflineCaseID = new Guid(offlineCaseID);
                vc.CaseType = caseType == 0 ? null
                    : vc.CaseTypeLookup.SingleOrDefault(c => c.idfsBaseReference == caseType);
                vc.CaseReportType = caseReportType == 0 ? null
                    : vc.CaseReportTypeLookup.SingleOrDefault(c => c.idfsBaseReference == caseReportType);
                vc.strFieldAccessionID = localIdentifier;
                vc.TentativeDiagnosis = tentativeDiagnosis == 0 ? null
                    : vc.TentativeDiagnosisLookup.SingleOrDefault(c => c.idfsDiagnosis == tentativeDiagnosis);
                vc.datTentativeDiagnosisDate = tentativeDiagnosisDate == DateTime.MinValue ? new DateTime?() : tentativeDiagnosisDate;
                vc.Farm.strFullName = farmName;
                vc.Farm.strOwnerLastName = ownerLastName;
                vc.Farm.strOwnerFirstName = ownerFirstName;
                vc.Farm.strOwnerMiddleName = ownerMiddleName;

                vc.Farm.Address.Country = country == 0 ? null :
                    vc.Farm.Address.CountryLookup.SingleOrDefault(c => c.idfsCountry == country);
                vc.Farm.Address.Region = region == 0 ? null :
                    vc.Farm.Address.RegionLookup.SingleOrDefault(c => c.idfsRegion == region);
                vc.Farm.Address.Rayon = rayon == 0 ? null :
                    vc.Farm.Address.RayonLookup.SingleOrDefault(c => c.idfsRayon == rayon);
                vc.Farm.Address.Settlement = settlement == 0 ? null :
                    vc.Farm.Address.SettlementLookup.SingleOrDefault(c => c.idfsSettlement == settlement);
                vc.Farm.Address.strBuilding = building;
                vc.Farm.Address.strHouse = house;
                vc.Farm.Address.strApartment = apartment;
                vc.Farm.Address.strStreetName = street;
                vc.Farm.Address.strPostCode = zipCode;
                vc.Farm.strContactPhone = phone;
                vc.Farm.Address.dblLatitude = latitude;
                vc.Farm.Address.dblLongitude = longitude;
                vc.datReportDate = enteredDate == DateTime.MinValue ? new DateTime?() : enteredDate;

                if (herd == null)   //earlier existed case
                    herd = vc.Farm.FarmTree.FirstOrDefault(t => t.idfParty == (long)ret.herd);
                if (herd == null)   //if herd id was not transfered to android accidentally
                    herd = vc.Farm.FarmTree.FirstOrDefault(t => t.idfsPartyType == (long)PartyTypeEnum.Herd);
                if (herd == null)   // very strange situation: earlier synchronized case doesn't have any herd
                {
                    var farm = vc.Farm.FarmTree.First(t => t.idfsPartyType == (long)PartyTypeEnum.Farm);
                    herd = vftacc.CreateHerd(manager, vc.Farm, farm);
                    vc.Farm.FarmTree.Add(herd);
                }
                foreach (SpeciesInfoIn s in species)
                {
                    var vetFarmTree = vc.Farm.FarmTree
                            .FirstOrDefault(t => t.idfsPartyType == (long)PartyTypeEnum.Species && t.idfParentParty == ret.herd && t.idfsSpeciesTypeReference == s.speciesType);
                    if (vetFarmTree == null)
                    {
                        vetFarmTree = vftacc.CreateSpecies(manager, vc.Farm, herd);
                        vetFarmTree.SpeciesType = vetFarmTree.SpeciesTypeLookup.SingleOrDefault(c => c.idfsBaseReference == s.speciesType);
                        vc.Farm.FarmTree.Add(vetFarmTree);
                    }
                    vetFarmTree.datStartOfSignsDate = s.startOfSignsDate == DateTime.MinValue ? new DateTime?() : s.startOfSignsDate;
                    vetFarmTree.intTotalAnimalQty = s.totalAnimalQty;
                    vetFarmTree.intDeadAnimalQty = s.deadAnimalQty;
                    vetFarmTree.intSickAnimalQty = s.sickAnimalQty;
                }

                if (id == 0)
                {
                    vc.idfReportedByOffice = EidssSiteContext.Instance.OrganizationID;
                    vc.strReportedByOffice = EidssSiteContext.Instance.OrganizationName;
                    vc.idfPersonReportedBy = (long)EidssUserContext.User.EmployeeID;
                    vc.strPersonReportedBy = EidssUserContext.User.FullName;
                }

                vc.Validation += (sender, args) =>
                {
                    ret.lastErrorDescription = GetErrorMessage(args);
                    ret.isCreated = false;
                    ret.isUpdated = false;
                    ret.isFailed = true;
                };

                try
                {
                    acc.Post(manager, vc);
                }
                catch (Exception e)
                {
                    ret.lastErrorDescription = e.InnerException == null ? e.Message : e.InnerException.Message;
                    ret.isCreated = false;
                    ret.isUpdated = false;
                    ret.isFailed = true;
                }

                ret.id = vc.idfCase;
                ret.caseID = vc.strCaseID;
                ret.herd = herd.idfParty;
                ret.farmCode = vc.Farm.strFarmCode;
                ret.reportedByOrganization = vc.strReportedByOffice;
                ret.reportedByPerson = vc.strPersonReportedBy;
            }

            return ret;
        }

        private static string GetErrorMessage(ValidationEventArgs args)
        {
            return string.Format(EidssMessages.Get(args.MessageId), args.Pars);
        }
    }
}