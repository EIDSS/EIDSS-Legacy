using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using bv.common.Configuration;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.model.Trace;
using hmis2eidss.service.HMIS;
using hmis2eidss.service.Schema;

namespace hmis2eidss.service.Import
{
    public class Hmis2EidssImport
    {
        private const string TraceTitle = "hmis2eidss";

        private static CasesResultContract _testData()
        {
            return new CasesResultContract()
                {
                    Result = new List<CaseContract>()
                        {
                            new CaseContract()
                                {
                                    ID = Guid.Parse("9E88DA32-2570-44E1-B622-11F28C663E07"),
                                    Messages = new List<MessageContract>()
                                        {
                                            new MessageContract()
                                                {
                                                    Diagnoses = new List<DiagnosisContract>()
                                                        {
                                                            new DiagnosisContract()
                                                                {
                                                                    Id = Guid.Parse("9E88DA32-2570-44E1-B622-11F28C663DFC"),
                                                                }
                                                        },
                                                    PatientPerson = new PersonContract()
                                                        {
                                                            LastName = "LastName",
                                                            FirstName = "FirstName",
                                                            PersonalID = "1234567890",
                                                            FactualRegionID = Guid.Parse("31520D88-870E-485E-A833-5CA9E20E84FA"),
                                                            FactualMunicipalityID = Guid.Parse("057B6A5E-E0AE-41ED-99E5-A425A367F69B"),
                                                        },
                                                    CurrentProvider = new OrganizationContract()
                                                        {
                                                            Id = Guid.Parse("9E88DA32-2570-44E1-B622-11F28C663DFC"),
                                                        },
                                                    NotifierPerson = new PersonContract()
                                                        {
                                                            LastName = "OrgLastName",
                                                            FirstName = "OrgFirstName",
                                                        }
                                                }
                                        }
                                }
                        }
                };
        }

        private static string Authorize()
        {
            var Organization = Config.GetSetting("DefaultOrganization");
            var UserName = Config.GetSetting("DefaultUser");
            var Password = Config.GetSetting("DefaultPassword");
            var security = new EidssSecurityManager();
            var result = security.LogIn(Organization, UserName, Password);
            switch (result)
            {
                case 0:
                    return null;
                case 6:
                    int lockInMinutes = security.GetAccountLockTimeout(Organization, UserName);
                    string err = BvMessages.Get("ErrLoginIsLocked", "You have exceeded the number of incorrect login attempts. Please try again in {0} minutes.");
                    return string.Format(err, lockInMinutes);
                default:
                    return SecurityMessages.GetLoginErrorMessage(result);
            }

        }

        public static void Import(TraceHelper tracer)
        {
            tracer.TraceInfo(TraceTitle, "Import is started");
            try
            {
                using (var client = new CaseRegistrationWcfClient())
                {
                    var userName = Config.GetSetting("HMISUsr");
                    var userPwd = Config.GetSetting("HMISPwd");
                    var startDate = Config.GetSetting("HMISStartDate");
                    var daysBack = Config.GetIntSetting("HMISDaysBack", 30);
                    var loginResult = client.Login(userName, userPwd);
                    if (loginResult.HasValue)
                    {
                        DateTime dateTo; 
                        if (!DateTime.TryParseExact(startDate, "yyyy-MM-dd", null, DateTimeStyles.None, out dateTo))
                            dateTo = DateTime.Today;//.AddDays(-60);
                        DateTime dateStart = dateTo.AddDays(-daysBack);
                        var ICDList = ICD10Codes;

                        var loginStatus = Authorize();
                        if (loginStatus == null)
                        {
                            //var listCases = _testData();
                            var listCases = client.GetFilteredCasesByAndDateRange(loginResult.Value, dateStart, dateTo, ICDList);

                            if (listCases.Result != null)
                            {
                                tracer.TraceInfo(TraceTitle, "Found {0} cases", listCases.Result.Count);

                                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                                {
                                    new Hmis2EidssImport(tracer).ParseHmisCases(manager, listCases.Result);
                                }
                            }
                            else
                            {
                                tracer.TraceError(TraceTitle, "List of HMIS cases is null");
                            }
                        }
                        else
                        {
                            tracer.TraceError(TraceTitle, "EIDSS login failed: " + loginStatus);
                        }
                    }
                    else
                    {
                        tracer.TraceError(TraceTitle, "Login to HMIS is failed");
                    }
                }
            }
            catch (Exception e)
            {
                tracer.TraceError(e);
            }
            finally
            {
                tracer.TraceInfo(TraceTitle, "Import is finished");
            }
        }


        private static List<string> ICD10Codes
        {
            get
            {
                //return new List<string>() {"B07", "A00.1"};
                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    return HmisDiagnosisLookup.Accessor.Instance(null).SelectLookupList(manager).Select(c => c.strHmisICD10Code).ToList();
                }
            }
        }

        private readonly TraceHelper _mTracer;
        private Hmis2EidssImport(TraceHelper tracer)
        {
            _mTracer = tracer;
        }
        private void ParseHmisCases(DbManagerProxy manager, List<CaseContract> cases)
        {
            cases.Reverse();
            cases.ForEach(c => ParseHmisMessages(manager, cases, c));
        }
        private void ParseHmisMessages(DbManagerProxy manager, List<CaseContract> cases, CaseContract cs)
        {
            if (cs.Messages != null)
                cs.Messages.ForEach(c => ParseHmisMessage(manager, cases, cs, c));
        }
        private void ParseHmisMessage(DbManagerProxy manager, List<CaseContract> cases, CaseContract cs, MessageContract message)
        {
            if (message.Diagnoses != null)
                message.Diagnoses.ForEach(c =>
                {
                    var log = ParseHmisMessageAndDiagnosis(manager, cases, cs, message, c);
                    if (log != null)
                    {
                        var accLog = HmisLog.Accessor.Instance(null);
                        accLog.Post(manager, log);
                    }
                });
        }
        private bool IsNeedImportHmisMessageAndDiagnosis(DbManagerProxy manager, List<CaseContract> cases, CaseContract cs, MessageContract message, DiagnosisContract diagnosis)
        {
            // (1)	Diagnosis corresponds to the reportable diagnosis utilized by EIDSS;
            var d = HmisDiagnosis(manager, diagnosis);
            if (d == null) return false;

            // (2)	It has not been transferred to EIDSS yet;
            var id = strLocalIdentifier(cs);
            HumanCaseListWithDeletedItem.Accessor acclist = HumanCaseListWithDeletedItem.Accessor.Instance(null);
            var filters = new FilterParams();
            filters.Add("strLocalIdentifier", "=", id);
            filters.Add("idfsTentativeDiagnosis", "=", d.idfsDiagnosis);
            List<HumanCaseListWithDeletedItem> list = acclist.SelectListT(manager, filters);
            if (list.Count > 0) return false;

            // (3)	It is not a duplicate of another HMIS case in the context of HMIS-EIDSS Integration. 
            //(1)	It has a link to the same patient (on the basis of personal ID);
            var chk = cases.TakeWhile(c => c.ID != cs.ID).Where(c => c.Messages.Any(i => i.PatientPerson.PersonalID == message.PatientPerson.PersonalID));
            if (chk.Any())
            {
                //AND
                //(2)	It has “transferred” value in field “How patient came to healthcare facility” (MessageContract.PatientArrival) in HMIS case in any MessageContract;
                if (cs.Messages.Any(i => i.PatientArrival.HasValue && i.PatientArrival.Value == 1)) // 1?
                {
                    //AND
                    //(3)	Value of the HMIS fields “Transferred to” (MessageContract.DestProvider) in the case equals the value of the HMIS field “Transferred from” (MessageContract.SourceProvider) in duplicated case in any MessageContract;
                    chk = chk.Where(c => c.Messages.Any(i => i.SourceProvider != null && message.DestProvider != null && i.SourceProvider.Id == message.DestProvider.Id));
                    if (chk.Any())
                    {
                        //AND
                        //(4)	It includes at least one reportable diagnosis (that corresponds to the reportable diagnosis utilized by EIDSS) equal to reportable diagnosis specified in the case by facility from which the patient was transferred (HMIS fields “Transferred from” (MessageContract.SourceProvider) ) in any MessageConatrct;
                        chk = chk.Where(c => c.Messages.Any(i => i.Diagnoses.Any(j => j.Id == diagnosis.Id)));
                        if (chk.Any())
                        {
                            //AND
                            //(5)	The time difference between the case and a duplicated case (MessageContract.DateCreated field in HMIS) is less than 3 days in any MessageContract.
                            var daysDuplicateCase = Config.GetIntSetting("HMISDaysDuplicateCase", 3);
                            chk = chk.Where(c => c.Messages.Any(i => i.DateCreated.Subtract(message.DateCreated).Days < daysDuplicateCase));
                            if (chk.Any())
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        private string strLocalIdentifier(CaseContract cs)
        {
            return cs == null ? "" : cs.ID.ToString();
        }
        private DateTime? datNotificationDate(MessageContract message)
        {
            return message == null || message.DateCreated == DateTime.MinValue ? new DateTime?() : message.DateCreated.Date;
        }
        private string strLastName(PersonContract person)
        {
            return person == null ? "" : person.LastName;
        }
        private string strFirstName(PersonContract person)
        {
            return person == null ? "" : person.FirstName;
        }
        private DateTime? datDateofBirth(PersonContract person)
        {
            return person == null ? null : person.BirthDate;
        }
        private string strStreetName(PersonContract person)
        {
            return person == null ? "" : person.FactualAddress;
        }
        private string strRegistrationPhone(PersonContract person)
        {
            return person == null ? "" : person.Tel;
        }
        private int? intPatientAge(PersonContract person)
        {
            return person == null ? null : person.Age;
        }
        private string strPersonID(PersonContract person)
        {
            return person == null ? "" : person.PersonalID;
        }
        private DateTime? datDischargeDate(MessageContract message)
        {
            return message == null ? null : message.DateClosed;
        }

        private IEnumerable<HmisDiagnosisLookup> HmisDiagnosis(DbManagerProxy manager)
        {
            return HmisDiagnosisLookup.Accessor.Instance(null).SelectLookupList(manager);
        }
        private HmisDiagnosisLookup HmisDiagnosis(DbManagerProxy manager, DiagnosisContract diagnosis)
        {
            //return HmisDiagnosis(manager).FirstOrDefault(c => c.strHmisDiagnosis.ToUpperInvariant() == diagnosis.FinancingItemID.ToString().ToUpperInvariant());
            return string.IsNullOrEmpty(diagnosis.IClassCode) 
                ? null
                : HmisDiagnosis(manager).FirstOrDefault(c => c.strHmisICD10Code.ToUpperInvariant() == diagnosis.IClassCode.ToUpperInvariant());
        }
        private DiagnosisLookup TentativeDiagnosis(DbManagerProxy manager, DiagnosisContract diagnosis, HumanCase hc)
        {
            var d = HmisDiagnosis(manager, diagnosis);
            return d == null ? null : hc.TentativeDiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == d.idfsDiagnosis);
        }

        private DateTime? datTentativeDiagnosisDate(DiagnosisContract diagnosis)
        {
            return diagnosis == null ? null : diagnosis.DateAdded;
        }

        private BaseReference PatientLocationType(MessageContract message, HumanCase hc)
        {
            return hc.PatientLocationTypeLookup.FirstOrDefault(
                c => c.idfsBaseReference == (message.PatientStatus == PatientStatusEnums.NotInMedicalFacility
                     ? (long) HospitalizationStatus.Other
                     : (message.PatientStatus == PatientStatusEnums.Treating
                            ? (long) HospitalizationStatus.Hospital
                            : 0)
                       ));
        }
        private BaseReference Gender(PersonContract person, HumanCase hc)
        {
            return hc.Patient.GenderLookup.FirstOrDefault(
                c => c.idfsBaseReference == (person.Gender == "Male"
                     ? (long)GenderType.Male
                     : (person.Gender == "Female"
                            ? (long)GenderType.Female
                            : 0)
                       ));
        }

        private IEnumerable<HmisRegionLookup> HmisRegion(DbManagerProxy manager, long countryId)
        {
            return HmisRegionLookup.Accessor.Instance(null).SelectLookupList(manager, countryId);
        }
        private HmisRegionLookup HmisRegion(DbManagerProxy manager, Guid region, long countryId)
        {
            return HmisRegion(manager, countryId).FirstOrDefault(c => c.strHmisRegion.ToUpperInvariant() == region.ToString().ToUpperInvariant());
        }
        private RegionLookup Region(DbManagerProxy manager, Guid? region, Address ad)
        {
            if (!region.HasValue || !ad.idfsCountry.HasValue) return null;
            var d = HmisRegion(manager, region.Value, ad.idfsCountry.Value);
            return d == null ? null : ad.RegionLookup.FirstOrDefault(c => c.idfsRegion == d.idfsRegion);
        }

        private IEnumerable<HmisRayonLookup> HmisRayon(DbManagerProxy manager, long regionId)
        {
            return HmisRayonLookup.Accessor.Instance(null).SelectLookupList(manager, regionId);
        }
        private HmisRayonLookup HmisRayon(DbManagerProxy manager, Guid rayon, long regionId)
        {
            return HmisRayon(manager, regionId).FirstOrDefault(c => c.strHmisRayon.ToUpperInvariant() == rayon.ToString().ToUpperInvariant());
        }
        private RayonLookup Rayon(DbManagerProxy manager, Guid? rayon, Address ad)
        {
            if (!rayon.HasValue || !ad.idfsRegion.HasValue) return null;
            var d = HmisRayon(manager, rayon.Value, ad.idfsRegion.Value);
            return d == null ? null : ad.RayonLookup.FirstOrDefault(c => c.idfsRayon == d.idfsRayon);
        }

        private IEnumerable<HmisSettlementLookup> HmisSettlement(DbManagerProxy manager, long rayonId)
        {
            return HmisSettlementLookup.Accessor.Instance(null).SelectLookupList(manager, rayonId);
        }
        private HmisSettlementLookup HmisSettlement(DbManagerProxy manager, Guid settlement, long rayonId)
        {
            return HmisSettlement(manager, rayonId).FirstOrDefault(c => c.strHmisSettlement.ToUpperInvariant() == settlement.ToString().ToUpperInvariant());
        }
        private SettlementLookup Settlement(DbManagerProxy manager, Guid? settlement, Address ad)
        {
            if (!settlement.HasValue || !ad.idfsRayon.HasValue) return null;
            var d = HmisSettlement(manager, settlement.Value, ad.idfsRayon.Value);
            return d == null ? null : ad.SettlementLookup.FirstOrDefault(c => c.idfsSettlement == d.idfsSettlement);
        }


        private Patient Patient(DbManagerProxy manager, string strPersonId)
        {
            PatientListItem.Accessor acclist = PatientListItem.Accessor.Instance(null);
            var filters = new FilterParams();
            filters.Add("strPersonID", "=", strPersonId);
            List<PatientListItem> list = acclist.SelectListT(manager, filters);
            if (list.Count > 0)
            {
                Patient.Accessor acc = eidss.model.Schema.Patient.Accessor.Instance(null);
                return acc.SelectByKey(manager, list[0].idfHumanActual);
            }
            return null;
        }

        private OrganizationLookup Organization(IEnumerable<OrganizationLookup> list, OrganizationContract orgHmis, HmisLog log)
        {
            var ret = (orgHmis == null ? null : list.FirstOrDefault(c => c.strOrganizationID.ToUpperInvariant() == orgHmis.Id.ToString().ToUpperInvariant()));
            if (ret == null)
            {
                log.intStatus = 1;
                log.strComments += string.Format(
                    "Organization <{0}> is not found in EIDSS. Notification Sent By Facility field left blank. ",
                        orgHmis == null ? "" : orgHmis.Id.ToString());
            }
            return ret;
        }

        private WiderPersonLookup Person(DbManagerProxy manager, OrganizationLookup org, List<WiderPersonLookup> list, PersonContract person, HmisLog log)
        {
            if (org == null || person == null || string.IsNullOrEmpty(person.LastName) || string.IsNullOrEmpty(person.FirstName))
            {
                log.intStatus = 1;
                log.strComments += string.Format(
                    "Employee with the following <{0}> <{1}> cannot be created. Notification Sent By Person field left blank. ",
                    person == null ? "" : person.LastName, person == null ? "" : person.FirstName);
                return null;
            }

            var p = list.FirstOrDefault(c => c.strFamilyName == person.LastName && c.strFirstName == person.FirstName);
            if (p != null) 
                return p;

            var acc = eidss.model.Schema.Person.Accessor.Instance(null);
            var newPerson = acc.CreateNewT(manager, null);
            newPerson.Institution = newPerson.InstitutionLookup.FirstOrDefault(c => c.idfInstitution == org.idfInstitution);
            newPerson.strFamilyName = person.LastName;
            newPerson.strFirstName = person.FirstName;
            if (!acc.Post(manager, newPerson))
            {
                log.intStatus = 1;
                log.strComments += string.Format(
                    "Employee with the following <{0}> <{1}> cannot be created. Notification Sent By Person field left blank. ",
                        person.LastName, person.FirstName);
                return null;
            }

            LookupManager.ClearAndReloadOnIdle();
            p = list.FirstOrDefault(c => c.strFamilyName == person.LastName && c.strFirstName == person.FirstName);
            return p;
        }


        private HmisLog ParseHmisMessageAndDiagnosis(DbManagerProxy manager, List<CaseContract> cases, CaseContract cs, MessageContract message, DiagnosisContract diagnosis)
        {

            if (!IsNeedImportHmisMessageAndDiagnosis(manager, cases, cs, message, diagnosis))
            {
                return null;
            }

            var accLog = HmisLog.Accessor.Instance(null);
            var strHmisCaseId = cs.ID.ToString();
            var strHmisICD10Code = diagnosis.IClassCode;
            var strHmisPatientLastName = message.PatientPerson == null ? "" : message.PatientPerson.LastName;
            var strHmisRegionId = message.PatientPerson == null || !message.PatientPerson.FactualRegionID.HasValue ? "" : message.PatientPerson.FactualRegionID.ToString();
            var strHmisRayonId = message.PatientPerson == null || !message.PatientPerson.FactualMunicipalityID.HasValue ? "" : message.PatientPerson.FactualMunicipalityID.ToString();
            var log = accLog.SelectByKey(manager, strHmisCaseId, strHmisICD10Code);
            if (log == null)
            {
                log = accLog.CreateNewT(manager, null);
                log.strHmisCaseId = strHmisCaseId;
                log.strHmisICD10Code = strHmisICD10Code;
            }
            log.strHmisPatientLastName = strHmisPatientLastName;
            log.strHmisRegionId = strHmisRegionId;
            log.strHmisRayonId = strHmisRayonId;

            var acc = HumanCase.Accessor.Instance(null);
            var hc = acc.CreateNewT(manager, null);

            //1	Human Case Local Identifier*	Text		CaseContract.ID	Reject a case	
            hc.strLocalIdentifier = strLocalIdentifier(cs);
            if (string.IsNullOrEmpty(hc.strLocalIdentifier))
            {
                _mTracer.TraceError(TraceTitle, "Case ID is missing");
                log.strComments = "Mandatory field HMIS Case Contract ID is empty";
                log.intStatus = -1;
                return log;
            }

            //19	Diagnosis ID*	Reference	"6. Diagnosis Type;7. Diagnosis"	Diagnoses.Type; Diagnoses.ID	N/A	HMIS Diagnosis Type= "Main" or HMIS Diagnosis Type="Secondary"
            hc.TentativeDiagnosis = TentativeDiagnosis(manager, diagnosis, hc);
            if (hc.TentativeDiagnosis == null)
            {
                _mTracer.TraceError(TraceTitle, String.Format("Diagnosis is missing in case {0}, diagnosis {1}", cs.ID, diagnosis.IClassCode));
                log.strComments = "Mandatory field Diagnosis is empty";
                log.intStatus = -1;
                return log;
            }
                
            //3	Human Case Notification Date	Date		MessageContract.DateCreated	Accept a case	
            hc.datNotificationDate = datNotificationDate(message);

            //4	HMIS Case Status	Reference	1. Case Status	MessageContract.CaseStatus	Accept a case	The value is not intended to be transferred in EIDSS
            // do nothing 

            //5	HMIS Outcome	Reference	2. Outcome	MessageContract.FinalSolution	Accept a case	The value is not intended to be transferred in EIDSS
            // do nothing 

            //6	Current Location of Patient	Reference	3. Case Type	MessageContract.PatientStatus	Accept a case	
            hc.PatientLocationType = PatientLocationType(message, hc);

            //7	Notification Sent By Facility	ID		MessageContract.CurrentProvider	"Accept a case and leave the organization balnk. 
            //Unique Organization ID (OrganizationContract.ID) is a key attribute for search organizations"	Unique Organization ID attribute is available in the organization object
            hc.SentByOffice = Organization(hc.SentByOfficeLookup, message.CurrentProvider, log);

            //8	Notification Sent By Person	ID		MessageContract.NotifierPerson	"1. Accept a case and create new employee if the following attributes are available:
            //- First Name (PersonConatrct.FirstName)
            //- LastName (PersonConatrct.LastName)
            //- Unique Organization ID (OrganizationContract.ID)
            //2. Accept a case and leave employee balnk If any of the mentioned attirbutes are missing
            //First Name (PersonConatrct.FirstName) AND LastName (PersonConatrct.LastName) are key attribute for search employeey."	
            hc.SentByPerson = Person(manager, hc.SentByOffice, hc.SentByPersonLookup, message.NotifierPerson, log);

            //9	HMIS How Patient Came to Healthcare Facility	Reference	4. How Patient Came To Facility	MessageContract.PatientArrival	Accept a case	The value is not intended to be transferred in EIDSS
            // do nothing 

            //10	HMIS Transffered from Health Provider ID	ID		MessageContract.SourceProvider	Accept a case	The value is not intended to be transferred in EIDSS
            // do nothing 

            //11	HMIS Transferred to Healthcare Provider ID	ID		MessageContract.DestProvider	Accept a case	The value is not intended to be transferred in EIDSS
            // do nothing 


            var personEidss = Patient(manager, strPersonID(message.PatientPerson));
            if (personEidss != null)
                hc.Patient = hc.Patient.CopyFrom(manager, personEidss);

            //12	Personal ID	Text		MessageContract.PatientPersons.PersonalID	Accept a case	Personal ID Type = "Passport"
            hc.Patient.strPersonID = strPersonID(message.PatientPerson);
            long PassportIdType = 51389580000000; //georgian reference value
            if (!string.IsNullOrEmpty(hc.Patient.strPersonID))
                hc.Patient.PersonIDType = hc.Patient.PersonIDTypeLookup.FirstOrDefault(c => c.idfsBaseReference == PassportIdType);

            //13	Patient's First Name	Text		MessageContract.PatientPersons.FirstName	Accept a case	
            hc.Patient.strFirstName = strFirstName(message.PatientPerson);

            //14	Patient's Last Name*	Text		MessageContract.PatientPersons.LastName	Reject	
            hc.Patient.strLastName = strLastName(message.PatientPerson);
            if (string.IsNullOrEmpty(hc.Patient.strLastName))
            {
                _mTracer.TraceError(TraceTitle, String.Format("Patient Last Name is missing in case {0}, diagnosis {1}", cs.ID, diagnosis.IClassCode));
                log.strComments = "Mandatory field Patient’s Last Name is empty";
                log.intStatus = -1;
                return log;
            }

            //15	Patient's Date of Birth	Date		MessageContract.PatientPersons.BirthDate	Accept a case	
            hc.Patient.datDateofBirth = datDateofBirth(message.PatientPerson);

            //16	Patient's Gender	Reference	5. Gender	MessageContract.PatientPersons.Gender	Accept a case	
            hc.Patient.Gender = Gender(message.PatientPerson, hc);

            //17	Patient's Age	Integer		PersonContract.Age	Accept a case	Always In Years
            hc.Patient.intPatientAgeFromCase = hc.intPatientAge = intPatientAge(message.PatientPerson);
            if (hc.intPatientAge.HasValue)
            {
                hc.Patient.HumanAgeType = hc.Patient.HumanAgeTypeLookup.FirstOrDefault(c => c.idfsBaseReference == (long)HumanAgeTypeEnum.Years);
                hc.idfsHumanAgeType = hc.Patient.idfsHumanAgeTypeFromCase;
            }

            //23	Patient's Current Residence- Phone Number	Text		MessageContract.PatientPersons.Tel	Accept a case	
            hc.Patient.strRegistrationPhone = strRegistrationPhone(message.PatientPerson);

            //24	Patient's Current Residence -Region*	Reference	8. Region	MessageContract.PatientPersons.FactualRegionID	Reject	
            if (message.PatientPerson != null)
                hc.Patient.CurrentResidenceAddress.Region = Region(manager, message.PatientPerson.FactualRegionID, hc.Patient.CurrentResidenceAddress);
            if (hc.Patient.CurrentResidenceAddress.Region == null)
            {
                _mTracer.TraceError(TraceTitle, String.Format("Region is missing in case {0}, diagnosis {1}", cs.ID, diagnosis.IClassCode));
                log.strComments = "Mandatory field Patient’s Current Residence – Region is empty";
                log.intStatus = -1;
                return log;
            }

            //25	Patient's Current Residence -Rayon*	Reference	9.Raqyon	MessageContract.PatientPerson.FactualMunicipalityID	Reject	
            if (message.PatientPerson != null)
                hc.Patient.CurrentResidenceAddress.Rayon = Rayon(manager, message.PatientPerson.FactualMunicipalityID, hc.Patient.CurrentResidenceAddress);
            if (hc.Patient.CurrentResidenceAddress.Rayon == null)
            {
                _mTracer.TraceError(TraceTitle, String.Format("Rayon is missing in case {0}, diagnosis {1}", cs.ID, diagnosis.IClassCode));
                log.strComments = "Mandatory field Patient’s Current Residence – Rayon is empty";
                log.intStatus = -1;
                return log;
            }

            //26	Patient's Current Residence -Town or Village	Reference	10. Settlement	MessageContract.PatientPersons.FactualSettlementID	Accept a case	
            if (message.PatientPerson != null)
                hc.Patient.CurrentResidenceAddress.Settlement = Settlement(manager, message.PatientPerson.FactualSettlementID, hc.Patient.CurrentResidenceAddress);

            //27	Patient's Current Residence -Street	Text		MessageContract.PatientPersons.FactualAdress	Accept a case	
            if (message.PatientPerson != null)
                hc.Patient.CurrentResidenceAddress.strStreetName = strStreetName(message.PatientPerson);

                
            //18	Date of Discharge	Date		MessageContract.DateClosed 	Accept a case	Outcome ="Recovered"
            if (datDischargeDate(message).HasValue)
                hc.Outcome = hc.OutcomeLookup.FirstOrDefault(c => c.idfsBaseReference == (long)OutcomeTypeEnum.Recovered);
            hc.datDischargeDate = datDischargeDate(message);

               
            //20	Diagnosis Date	Date		Diagnoses.DateAdded	Accept a case	
            hc.datTentativeDiagnosisDate = datTentativeDiagnosisDate(diagnosis);
                
            //28	Additional Information/Comments including movement of patient during period of maximum incubation	შემთხვევა ავტომატურად მიღებულია ჯანმრთელობის დაცვის ერთიანი საინფორმაციო სისტემიდან.		N/A	N/A	All imported cases have the mentioned text in the specified comment field.
            hc.strNote = "შემთხვევა ავტომატურად მიღებულია ჯანმრთელობის დაცვის ერთიანი საინფორმაციო სისტემიდან";


            // initial case status - probable
            hc.InitialCaseClassification = hc.InitialCaseClassificationLookup.FirstOrDefault(c => c.idfsReference == (long)eidss.model.Enums.CaseClassification.Suspect);

            hc.Validation += HcOnValidation;
            if (acc.Post(manager, hc))
            {
                log.idfsHumanCase = hc.idfCase;
            }
            else
            {
                _mTracer.TraceError(TraceTitle, "Persisting error");
                log.strComments = "Persisting error";
                log.intStatus = -1;
            }
            hc.Validation -= HcOnValidation;

            _mTracer.TraceInfo(TraceTitle, String.Format("Import for case {0}, diagnosis {1} is completed", cs.ID, diagnosis.IClassCode));
            return log;
        }
        private void HcOnValidation(object sender, ValidationEventArgs args)
        {
            _mTracer.TraceError(TraceTitle, args.MessageId);
        }
    }
}
