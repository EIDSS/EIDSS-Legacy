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
    public class HumanCaseInfoIn
    {
        public string lang { get; set; }

        public long id { get; set; }
        public string offlineCaseID { get; set; }
        public string caseID { get; set; }
        public string localIdentifier { get; set; }
        public long tentativeDiagnosis { get; set; }
        public DateTime tentativeDiagnosisDate { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int patientAge { get; set; }
        public long patientAgeType { get; set; }
        public long patientGender { get; set; }
        public long country { get; set; }
        public long region { get; set; }
        public long rayon { get; set; }
        public long settlement { get; set; }
        public string building { get; set; }
        public string house { get; set; }
        public string apartment { get; set; }
        public string street { get; set; }
        public string zipCode { get; set; }
        public string homePhone { get; set; }
        public DateTime onsetDate { get; set; }
        public long patientState { get; set; }
        public long hospitalization { get; set; }

        private long find_by_offline_id(DbManagerProxy manager)
        {
            long ret = HumanCaseListItem.Accessor.Instance(null)
                .SelectListT(manager, new FilterParams().Add("uidOfflineCaseID", "=", offlineCaseID))
                .Select(c => c.idfCase).FirstOrDefault();
            return ret;
        }

        public HumanCaseInfoIn()
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

        public HumanCaseInfoIn(XElement xml)
        {
            lang = bv.common.Core.Localizer.lngEn;

            id = GetLong(xml, "id", id);
            offlineCaseID = GetString(xml, "offlineCaseID", offlineCaseID);
            caseID = GetString(xml, "caseID", caseID);
            localIdentifier = GetString(xml, "localIdentifier", localIdentifier);
            tentativeDiagnosis = GetLong(xml, "tentativeDiagnosis", tentativeDiagnosis);
            tentativeDiagnosisDate = GetDateTime(xml, "tentativeDiagnosisDate", tentativeDiagnosisDate);
            firstName = GetString(xml, "firstName", firstName);
            lastName = GetString(xml, "lastName", lastName);
            dateOfBirth = GetDateTime(xml, "dateOfBirth", dateOfBirth);
            patientAge = GetInt(xml, "patientAge", patientAge);
            patientAgeType = GetLong(xml, "patientAgeType", patientAgeType);
            patientGender = GetLong(xml, "patientGender", patientGender);
            country = GetLong(xml, "country", country);
            region = GetLong(xml, "region", region);
            rayon = GetLong(xml, "rayon", rayon);
            settlement = GetLong(xml, "settlement", settlement);
            building = GetString(xml, "building", building);
            house = GetString(xml, "house", house);
            apartment = GetString(xml, "apartment", apartment);
            street = GetString(xml, "street", street);
            zipCode = GetString(xml, "zipCode", zipCode);
            homePhone = GetString(xml, "homePhone", homePhone);
            onsetDate = GetDateTime(xml, "onsetDate", onsetDate);
            patientState = GetLong(xml, "patientState", patientState);
            hospitalization = GetLong(xml, "hospitalization", hospitalization);
        }

        public static IList<HumanCaseInfoOut> Save(XDocument doc)
        {
            var ret = new List<HumanCaseInfoOut>();
            doc.Root.Element("human").Elements("case").ToList().ForEach(c => ret.Add(new HumanCaseInfoIn(c).Save()));
            return ret;
        }

        public HumanCaseInfoOut Save()
        {
            HumanCaseInfoOut ret = new HumanCaseInfoOut(this);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanCase.Accessor.Instance(null);
                HumanCase hc = null;
                var find = find_by_offline_id(manager);
                if (find != 0)
                {
                    hc = acc.SelectByKey(manager, find);
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
                        filters.Add("idfsObjectType", "=", (long)EIDSSAuditObject.daoHumanCase);
                        filters.Add("idfsActionName", "=", (long)AuditEventType.daeDelete);
                        List<DataAuditListItem> list = audit_acc.SelectListT(manager, filters,
                            new[] { new KeyValuePair<string, System.ComponentModel.ListSortDirection>("datEnteringDate", System.ComponentModel.ListSortDirection.Descending) });
                        if (list.Count > 0)
                        {
                            DataAuditListItem.Accessor.Instance(null).Restore(manager, list[0]);

                            find = find_by_offline_id(manager);
                            if (find != 0)
                            {
                                hc = acc.SelectByKey(manager, find);
                                ret.isUpdated = true;
                            }
                        }
                    }

                    if (hc == null)
                    {
                        hc = acc.CreateNewT(manager, null);
                        ret.isCreated = true;
                    }
                }

                hc.uidOfflineCaseID = new Guid(offlineCaseID);
                hc.strLocalIdentifier = localIdentifier;
                hc.datOnSetDate = onsetDate == DateTime.MinValue ? new DateTime?() : onsetDate;
                hc.TentativeDiagnosis = tentativeDiagnosis == 0 ? null
                    : hc.TentativeDiagnosisLookup.SingleOrDefault(c => c.idfsDiagnosis == tentativeDiagnosis);
                hc.datTentativeDiagnosisDate = tentativeDiagnosisDate == DateTime.MinValue ? new DateTime?() : tentativeDiagnosisDate;
                hc.intPatientAge = patientAge > 0 ? new int?(patientAge) : null;
                hc.Patient.intPatientAgeFromCase = hc.intPatientAge;
                hc.Patient.strFirstName = firstName;
                hc.Patient.strLastName = lastName;
                hc.Patient.HumanAgeType = patientAgeType == 0 ? null :
                    hc.Patient.HumanAgeTypeLookup.SingleOrDefault(c => c.idfsBaseReference == patientAgeType);
                hc.Patient.Gender = patientGender == 0 ? null :
                    hc.Patient.GenderLookup.SingleOrDefault(c => c.idfsBaseReference == patientGender);
                hc.Hospitalization = hospitalization == 0 ? null :
                    hc.HospitalizationLookup.SingleOrDefault(c => c.idfsBaseReference == hospitalization);
                hc.PatientState = patientState == 0 ? null :
                    hc.PatientStateLookup.SingleOrDefault(c => c.idfsBaseReference == patientState);
                hc.Patient.datDateofBirth = dateOfBirth == DateTime.MinValue ? new DateTime?() : dateOfBirth;

                hc.Patient.CurrentResidenceAddress.Country = country == 0 ? null :
                    hc.Patient.CurrentResidenceAddress.CountryLookup.SingleOrDefault(c => c.idfsCountry == country);
                hc.Patient.CurrentResidenceAddress.Region = region == 0 ? null :
                    hc.Patient.CurrentResidenceAddress.RegionLookup.SingleOrDefault(c => c.idfsRegion == region);
                hc.Patient.CurrentResidenceAddress.Rayon = rayon == 0 ? null :
                    hc.Patient.CurrentResidenceAddress.RayonLookup.SingleOrDefault(c => c.idfsRayon == rayon);
                hc.Patient.CurrentResidenceAddress.Settlement = settlement == 0 ? null :
                    hc.Patient.CurrentResidenceAddress.SettlementLookup.SingleOrDefault(c => c.idfsSettlement == settlement);
                hc.Patient.CurrentResidenceAddress.strBuilding = building;
                hc.Patient.CurrentResidenceAddress.strHouse = house;
                hc.Patient.CurrentResidenceAddress.strApartment = apartment;
                hc.Patient.CurrentResidenceAddress.strStreetName = street;
                hc.Patient.CurrentResidenceAddress.strPostCode = zipCode;
                hc.Patient.strHomePhone = homePhone;

                if (id == 0)
                {
                    hc.datNotificationDate = DateTime.Today;
                    hc.idfSentByOffice = EidssSiteContext.Instance.OrganizationID;
                    hc.strSentByOffice = EidssSiteContext.Instance.OrganizationName;
                    hc.idfSentByPerson = (long)EidssUserContext.User.EmployeeID;
                    hc.strSentByPerson = EidssUserContext.User.FullName;
                    //hc.SentByOffice = hc.SentByOfficeLookup.SingleOrDefault(c => c.idfInstitution == EidssSiteContext.Instance.OrganizationID);
                    //hc.SentByPerson = hc.SentByPersonLookup.SingleOrDefault(c => c.idfPerson == (long)EidssUserContext.User.EmployeeID);
                }

                hc.Validation += (sender, args) =>
                {
                    ret.lastErrorDescription = GetErrorMessage(args);
                    ret.isCreated = false;
                    ret.isUpdated = false;
                    ret.isFailed = true;
                };

                try
                {
                    acc.Post(manager, hc);
                }
                catch (Exception e)
                {
                    ret.lastErrorDescription = e.InnerException == null ? e.Message : e.InnerException.Message;
                    ret.isCreated = false;
                    ret.isUpdated = false;
                    ret.isFailed = true;
                }

                ret.id = hc.idfCase;
                ret.caseID = hc.strCaseID;
                ret.notificationDate = hc.datNotificationDate.Value;
                ret.notificationSentBy = hc.strSentByOffice;//.name;
                ret.notificationSentByPerson = hc.strSentByPerson;//.FullName;
            }

            return ret;
        }

        private static string GetErrorMessage(ValidationEventArgs args)
        {
            return string.Format(EidssMessages.Get(args.MessageId), args.Pars);
        }
    }
}