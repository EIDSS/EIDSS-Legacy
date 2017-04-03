using System;
using System.Linq;
using System.Data;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Serialization;
using bv.common;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.model.Schema;


namespace Eidss.Web
{
    public class HumanCaseInfo
    {
        //[XmlIgnore]
        //[FieldName("idfHuman")]
        //public long idfHuman { get; set; }
        //[XmlIgnore]
        //[FieldName("idfEpiObservation")]
        //public long idfEpiObservation { get; set; }
        //[XmlIgnore]
        //[FieldName("idfCSObservation")]
        //public long idfCSObservation { get; set; }
        //[XmlIgnore]
        //[FieldName("idfPointGeoLocation")]
        //public long idfPointGeoLocation { get; set; }

        [FieldName("uidOfflineCaseID")]
        public string OfflineCaseID { get; set; }
        [FieldName("idfCase")]
        public long Id { get; set; }
        [FieldName("strCaseID")]
        public string CaseID { get; set; }
        [FieldName("strLocalIdentifier")]
        public string LocalID { get; set; }
        //[FieldName("strLocalIdentifier")]
        //public string LocalIdentifier { get; set; }
        [FieldName("datCompletionPaperFormDate")]
        public DateTime? CompletionPaperFormDate  { get; set; }
        //[XmlIgnore]
        //[FieldName("datEnteredDate")]
        //public DateTime EnteredDate { get; set; }
        //[XmlIgnore]
        //[FieldName("datModificationDate")]
        //public DateTime? ModificationDate  { get; set; }
        [FieldName("datFacilityLastVisit")]
        public DateTime? FacilityLastVisitDate { get; set; }
        [FieldName("datOnSetDate")]
        public DateTime? OnsetDate { get; set; }
        [FieldName("datNotificationDate")]
        public DateTime? NotificationDate { get; set; }
        [FieldName("idfsTentativeDiagnosis")]
        public BaseReferenceItem TentativeDiagnosis { get; set; }
        [FieldName("datTentativeDiagnosisDate")]
        public DateTime? TentativeDiagnosisDate { get; set; }
        [FieldName("idfsFinalDiagnosis")]
        public BaseReferenceItem FinalDiagnosis { get; set; }
        [FieldName("datFinalDiagnosisDate")]
        public DateTime? FinalDiagnosisDate { get; set; }
        [FieldName("intPatientAge")]
        public int? PatientAge { get; set; }
        [FieldName("strFirstName")]
        public string FirstName { get; set; }
        [FieldName("strSecondName")]
        public string MiddleName { get; set; }
        [FieldName("strLastName")]
        public string LastName { get; set; }
        [FieldName("idfsHumanAgeType")]
        public BaseReferenceItem PatientAgeType { get; set; }
        [FieldName("idfsHumanGender")]
        public BaseReferenceItem PatientGender  { get; set; }
        [FieldName("idfsCaseProgressStatus")]
        public BaseReferenceItem CaseStatus  { get; set; }
        [FieldName("idfsYNRelatedToOutbreak")]
        public BaseReferenceItem RelatedToOutbreak  { get; set; }
        [FieldName("idfsHospitalizationStatus")]
        public BaseReferenceItem CurrentLocation  { get; set; }
        [FieldName("idfsYNHospitalization")]
        public BaseReferenceItem Hospitalization  { get; set; }
        [FieldName("idfsInitialCaseStatus")]
        public BaseReferenceItem CaseClassification { get; set; }
        [FieldName("idfsFinalCaseStatus")]
        public BaseReferenceItem FinalCaseStatus { get; set; }
        [FieldName("idfsFinalState")]
        public BaseReferenceItem PatientState  { get; set; }
        [FieldName("datDateOfBirth")]
        public DateTime? DateOfBirth { get; set; }
        [FieldName("idfsNationality")]
        public BaseReferenceItem Citizenship { get; set; }
        [FieldName("strNote")]
        public string AdditionalComment { get; set; }
        [FieldName("idfsOutcome")]
        public BaseReferenceItem Outcome { get; set; }
        [FieldName("CurrentResidence")]
        public AddressInfo CurrentResidence { get; set; }
        [FieldName("EmployerAddress")]
        public AddressInfo EmployerAddress { get; set; }
        [FieldName("strEmployerName")]
        public string EmployerName { get; set; }
        [FieldName("strCurrentLocation")]
        public string CurrentLocationName { get; set; }
        [FieldName("idfSentByOffice")]
        public BaseReferenceItem NotificationSentBy { get; set; }
        [FieldName("idfSentByPerson")]
        public BaseReferenceItem NotificationSentByPerson { get; set; }
        [FieldName("strSentByFirstName")]
        public string NotificationSentByFirstName { get; set; }
        [FieldName("strSentByPatronymicName")]
        public string NotificationSentByPatronymicName { get; set; }
        [FieldName("strSentByLastName")]
        public string NotificationSentByLastName { get; set; }
        [FieldName("idfReceivedByOffice")]
        public BaseReferenceItem NotificationReceivedBy { get; set; }
        [FieldName("strReceivedByFirstName")]
        public string NotificationReceivedByFirstName { get; set; }
        [FieldName("strReceivedByPatronymicName")]
        public string NotificationReceivedByPatronymicName { get; set; }
        [FieldName("strReceivedByLastName")]
        public string NotificationReceivedByLastName { get; set; }
        [FieldName("strHomePhone")]
        public string PhoneNumber { get; set; }

        public string LastErrorDescription { get; set; }
        public bool MarkedToDelete { get; set; }

        public static HumanCaseInfo GetById(string id)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var hc = HumanCase.Accessor.Instance(null).SelectByKey(manager, long.Parse(id));

                if (hc == null)
                    throw new SoapException(string.Format("Case with id='{0}' is not found", id), new XmlQualifiedName("id"));

                return new HumanCaseInfo()
                {
                    Id = hc.idfCase,
                    CaseID = hc.strCaseID,
                    LocalID = hc.strLocalIdentifier,
                    //LocalIdentifier = hc.strLocalIdentifier,
                    CompletionPaperFormDate = hc.datCompletionPaperFormDate,
                    FacilityLastVisitDate = hc.datFacilityLastVisit,
                    OnsetDate = hc.datOnSetDate,
                    NotificationDate = hc.datNotificationDate,
                    TentativeDiagnosis = new BaseReferenceItem() { Id = hc.idfsTentativeDiagnosis, Name = hc.TentativeDiagnosis != null ? hc.TentativeDiagnosis.name : "" },
                    TentativeDiagnosisDate = hc.datTentativeDiagnosisDate,
                    FinalDiagnosis = new BaseReferenceItem() { Id = hc.idfsFinalDiagnosis, Name = hc.FinalDiagnosis != null ? hc.FinalDiagnosis.name : "" },
                    FinalDiagnosisDate = hc.datFinalDiagnosisDate,
                    PatientAge = hc.intPatientAge,
                    FirstName = hc.Patient.strFirstName,
                    MiddleName = hc.Patient.strSecondName,
                    LastName = hc.Patient.strLastName,
                    PatientAgeType = new BaseReferenceItem() { Id = hc.idfsHumanAgeType, Name = hc.Patient.HumanAgeType != null ? hc.Patient.HumanAgeType.name : "" },
                    PatientGender = new BaseReferenceItem() { Id = hc.Patient.idfsHumanGender, Name = hc.Patient.Gender != null ? hc.Patient.Gender.name : "" },
                    CaseStatus = new BaseReferenceItem() { Id = hc.idfsCaseProgressStatus, Name = hc.CaseProgressStatus != null ? hc.CaseProgressStatus.name : "" },
                    RelatedToOutbreak = new BaseReferenceItem() { Id = hc.idfsYNRelatedToOutbreak, Name = hc.RelatedToOutbreak != null ? hc.RelatedToOutbreak.name : "" },
                    CurrentLocation = new BaseReferenceItem() { Id = hc.idfsHospitalizationStatus, Name = hc.PatientLocationType != null ? hc.PatientLocationType.name : "" },
                    Hospitalization = new BaseReferenceItem() { Id = hc.idfsYNHospitalization, Name = hc.Hospitalization != null ? hc.Hospitalization.name : "" },
                    CaseClassification = new BaseReferenceItem() { Id = hc.idfsInitialCaseStatus, Name = hc.InitialCaseStatus != null ? hc.InitialCaseStatus.name : "" },
                    FinalCaseStatus = new BaseReferenceItem() { Id = hc.idfsFinalCaseStatus, Name = hc.FinalCaseStatus != null ? hc.FinalCaseStatus.name : "" },
                    PatientState = new BaseReferenceItem() { Id = hc.idfsFinalState, Name = hc.PatientState != null ? hc.PatientState.name : "" },
                    DateOfBirth = hc.Patient.datDateofBirth,
                    Citizenship = new BaseReferenceItem() { Id = hc.Patient.idfsNationality, Name = hc.Patient.Nationality != null ? hc.Patient.Nationality.name : "" },
                    AdditionalComment = hc.strNote,
                    Outcome = new BaseReferenceItem() { Id = hc.idfsOutcome, Name = hc.Outcome != null ? hc.Outcome.name : "" },
                    CurrentResidence = new AddressInfo()
                    {
                        idfGeoLocation = hc.Patient.CurrentResidenceAddress.idfGeoLocation,
                        Country = new BaseReferenceItem() { Id = hc.Patient.CurrentResidenceAddress.idfsCountry, Name = hc.Patient.CurrentResidenceAddress.Country != null ? hc.Patient.CurrentResidenceAddress.Country.strCountryName : "" },
                        Region = new BaseReferenceItem() { Id = hc.Patient.CurrentResidenceAddress.idfsRegion, Name = hc.Patient.CurrentResidenceAddress.Region != null ? hc.Patient.CurrentResidenceAddress.Region.strRegionName : "" },
                        Rayon = new BaseReferenceItem() { Id = hc.Patient.CurrentResidenceAddress.idfsRayon, Name = hc.Patient.CurrentResidenceAddress.Rayon != null ? hc.Patient.CurrentResidenceAddress.Rayon.strRayonName : "" },
                        Settlement = new BaseReferenceItem() { Id = hc.Patient.CurrentResidenceAddress.idfsSettlement, Name = hc.Patient.CurrentResidenceAddress.Settlement != null ? hc.Patient.CurrentResidenceAddress.Settlement.strSettlementName : "" },
                        Street = hc.Patient.CurrentResidenceAddress.strStreetName,
                        ZipCode = hc.Patient.CurrentResidenceAddress.strPostCode
                    },
                    EmployerAddress = new AddressInfo()
                    {
                        idfGeoLocation = hc.Patient.EmployerAddress.idfGeoLocation,
                        Country = new BaseReferenceItem() { Id = hc.Patient.EmployerAddress.idfsCountry, Name = hc.Patient.EmployerAddress.Country != null ? hc.Patient.EmployerAddress.Country.strCountryName : "" },
                        Region = new BaseReferenceItem() { Id = hc.Patient.EmployerAddress.idfsRegion, Name = hc.Patient.EmployerAddress.Region != null ? hc.Patient.EmployerAddress.Region.strRegionName : "" },
                        Rayon = new BaseReferenceItem() { Id = hc.Patient.EmployerAddress.idfsRayon, Name = hc.Patient.EmployerAddress.Rayon != null ? hc.Patient.EmployerAddress.Rayon.strRayonName : "" },
                        Settlement = new BaseReferenceItem() { Id = hc.Patient.EmployerAddress.idfsSettlement, Name = hc.Patient.EmployerAddress.Settlement != null ? hc.Patient.EmployerAddress.Settlement.strSettlementName : "" },
                        Street = hc.Patient.EmployerAddress.strStreetName,
                        ZipCode = hc.Patient.EmployerAddress.strPostCode
                    },
                    EmployerName = hc.Patient.strEmployerName,
                    CurrentLocationName = hc.strCurrentLocation,
                    NotificationSentBy = new BaseReferenceItem() { Id = hc.idfSentByOffice, Name = hc.SentByOffice != null ? hc.SentByOffice.name : "" },
                    NotificationSentByPerson = new BaseReferenceItem() { Id = hc.idfSentByPerson, Name = hc.SentByPerson != null ? hc.SentByPerson.FullName : "" },
                    NotificationSentByFirstName = hc.strSentByFirstName,
                    NotificationSentByPatronymicName = hc.strSentByPatronymicName,
                    NotificationSentByLastName = hc.strSentByLastName,
                    NotificationReceivedBy = new BaseReferenceItem() { Id = hc.idfReceivedByOffice, Name = hc.ReceivedByOffice != null ? hc.ReceivedByOffice.name : "" },
                    NotificationReceivedByFirstName = hc.strReceivedByFirstName,
                    NotificationReceivedByPatronymicName = hc.strReceivedByPatronymicName,
                    NotificationReceivedByLastName = hc.strReceivedByLastName,
                    PhoneNumber = hc.Patient.strHomePhone
                };
            }
        }

        private long find_by_offline_id(DbManagerProxy manager)
        {
            long ret = HumanCaseListItem.Accessor.Instance(null)
                .SelectListT(manager, new FilterParams().Add("uidOfflineCaseID", "=", OfflineCaseID))
                .Select(c => c.idfCase).FirstOrDefault();
            return ret;
        }

        public bool Save(bool bSaveNotification)
        {
            bool ret = false;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanCase.Accessor.Instance(null);
                HumanCase hc = null;
                if (string.IsNullOrEmpty(OfflineCaseID))
                {
                    hc = (Id != 0) ? acc.SelectByKey(manager, Id) : acc.CreateNewT(manager, null);
                }
                else
                {
                    var find = find_by_offline_id(manager);
                    if (find != 0)
                        hc = acc.SelectByKey(manager, find);
                    else
                    {
                        hc = acc.CreateNewT(manager, null);
                        if (Id != 0)
                        {
                            MarkedToDelete = true;
                            return true;
                        }
                    }
                }

                if (hc == null)
                    throw new SoapException(string.Format("Case with id='{0}' is not found", Id != 0 ? Id.ToString() : OfflineCaseID), new XmlQualifiedName("id"));

                hc.strCaseID = CaseID ?? "";
                try { hc.uidOfflineCaseID = new Guid(OfflineCaseID); } catch {}
                hc.strLocalIdentifier = LocalID;
                //hc.strLocalIdentifier = LocalIdentifier;
                hc.datCompletionPaperFormDate = CompletionPaperFormDate;
                hc.datFacilityLastVisit = FacilityLastVisitDate;
                hc.datOnSetDate = OnsetDate;
                if (bSaveNotification)
                    hc.datNotificationDate = NotificationDate;
                hc.TentativeDiagnosis = TentativeDiagnosis == null ? null 
                    : hc.TentativeDiagnosisLookup.SingleOrDefault(c => c.idfsDiagnosis == TentativeDiagnosis.Id);
                hc.datTentativeDiagnosisDate = TentativeDiagnosisDate;
                hc.FinalDiagnosis = FinalDiagnosis == null ? null : 
                    hc.FinalDiagnosisLookup.SingleOrDefault(c => c.idfsDiagnosis == FinalDiagnosis.Id);
                hc.datFinalDiagnosisDate = FinalDiagnosisDate;
                hc.intPatientAge = PatientAge.HasValue && PatientAge.Value > 0 ? PatientAge : null;
                hc.Patient.intPatientAgeFromCase = hc.intPatientAge;
                hc.Patient.strFirstName = FirstName;
                hc.Patient.strSecondName = MiddleName;
                hc.Patient.strLastName = LastName;
                hc.Patient.HumanAgeType = PatientAgeType == null ? null : 
                    hc.Patient.HumanAgeTypeLookup.SingleOrDefault(c => c.idfsBaseReference == PatientAgeType.Id);
                hc.Patient.Gender = PatientGender == null ? null : 
                    hc.Patient.GenderLookup.SingleOrDefault(c => c.idfsBaseReference == PatientGender.Id);
                hc.CaseProgressStatus = CaseStatus == null ? null : 
                    hc.CaseProgressStatusLookup.SingleOrDefault(c => c.idfsBaseReference == CaseStatus.Id);
                hc.RelatedToOutbreak = RelatedToOutbreak == null ? null : 
                    hc.RelatedToOutbreakLookup.SingleOrDefault(c => c.idfsBaseReference == RelatedToOutbreak.Id);
                hc.PatientLocationType = CurrentLocation == null ? null : 
                    hc.PatientLocationTypeLookup.SingleOrDefault(c => c.idfsBaseReference == CurrentLocation.Id);
                hc.Hospitalization = Hospitalization == null ? null : 
                    hc.HospitalizationLookup.SingleOrDefault(c => c.idfsBaseReference == Hospitalization.Id);
                hc.InitialCaseStatus = CaseClassification == null ? null : 
                    hc.InitialCaseStatusLookup.SingleOrDefault(c => c.idfsBaseReference == CaseClassification.Id);
                hc.FinalCaseStatus = FinalCaseStatus == null ? null : 
                    hc.FinalCaseStatusLookup.SingleOrDefault(c => c.idfsBaseReference == FinalCaseStatus.Id);
                hc.PatientState = PatientState == null ? null : 
                    hc.PatientStateLookup.SingleOrDefault(c => c.idfsBaseReference == PatientState.Id);
                hc.Patient.datDateofBirth = DateOfBirth;
                hc.Patient.Nationality = Citizenship == null ? null : 
                    hc.Patient.NationalityLookup.SingleOrDefault(c => c.idfsBaseReference == Citizenship.Id);
                hc.strNote = AdditionalComment;
                hc.Outcome = Outcome == null ? null : 
                    hc.OutcomeLookup.SingleOrDefault(c => c.idfsBaseReference == Outcome.Id);

                hc.Patient.CurrentResidenceAddress.Country = CurrentResidence == null || CurrentResidence.Country == null ? null : 
                    hc.Patient.CurrentResidenceAddress.CountryLookup.SingleOrDefault(c => c.idfsCountry == CurrentResidence.Country.Id);
                hc.Patient.CurrentResidenceAddress.Region = CurrentResidence == null || CurrentResidence.Region == null ? null : 
                    hc.Patient.CurrentResidenceAddress.RegionLookup.SingleOrDefault(c => c.idfsRegion == CurrentResidence.Region.Id);
                hc.Patient.CurrentResidenceAddress.Rayon = CurrentResidence == null || CurrentResidence.Rayon == null ? null : 
                    hc.Patient.CurrentResidenceAddress.RayonLookup.SingleOrDefault(c => c.idfsRayon == CurrentResidence.Rayon.Id);
                hc.Patient.CurrentResidenceAddress.Settlement = CurrentResidence == null || CurrentResidence.Settlement == null ? null : 
                    hc.Patient.CurrentResidenceAddress.SettlementLookup.SingleOrDefault(c => c.idfsSettlement == CurrentResidence.Settlement.Id);
                hc.Patient.CurrentResidenceAddress.strStreetName = CurrentResidence == null ? null : CurrentResidence.Street;
                hc.Patient.CurrentResidenceAddress.strPostCode = CurrentResidence == null ? null : CurrentResidence.ZipCode;

                hc.Patient.EmployerAddress.Country = EmployerAddress == null || EmployerAddress.Country == null ? null : 
                    hc.Patient.EmployerAddress.CountryLookup.SingleOrDefault(c => c.idfsCountry == EmployerAddress.Country.Id);
                hc.Patient.EmployerAddress.Region = EmployerAddress == null || EmployerAddress.Region == null ? null : 
                    hc.Patient.EmployerAddress.RegionLookup.SingleOrDefault(c => c.idfsRegion == EmployerAddress.Region.Id);
                hc.Patient.EmployerAddress.Rayon = EmployerAddress == null || EmployerAddress.Rayon == null ? null : 
                    hc.Patient.EmployerAddress.RayonLookup.SingleOrDefault(c => c.idfsRayon == EmployerAddress.Rayon.Id);
                hc.Patient.EmployerAddress.Settlement = EmployerAddress == null || EmployerAddress.Settlement == null ? null : 
                    hc.Patient.EmployerAddress.SettlementLookup.SingleOrDefault(c => c.idfsSettlement == EmployerAddress.Settlement.Id);
                hc.Patient.EmployerAddress.strStreetName = EmployerAddress == null ? null : EmployerAddress.Street;
                hc.Patient.EmployerAddress.strPostCode = EmployerAddress == null ? null : EmployerAddress.ZipCode;

                hc.Patient.strEmployerName = EmployerName;
                hc.strCurrentLocation = CurrentLocationName;
                if (bSaveNotification)
                {
                    hc.SentByOffice = NotificationSentBy == null ? null : 
                        hc.SentByOfficeLookup.SingleOrDefault(c => c.idfInstitution == NotificationSentBy.Id);
                    hc.SentByPerson = NotificationSentByPerson == null ? null :
                        hc.SentByPersonLookup.SingleOrDefault(c => c.idfPerson == NotificationSentByPerson.Id);
                    hc.strSentByFirstName = NotificationSentByFirstName;
                    hc.strSentByPatronymicName = NotificationSentByPatronymicName;
                    hc.strSentByLastName = NotificationSentByLastName;
                    hc.ReceivedByOffice = NotificationReceivedBy == null ? null : 
                        hc.ReceivedByOfficeLookup.SingleOrDefault(c => c.idfInstitution == NotificationReceivedBy.Id);
                    hc.strReceivedByFirstName = NotificationReceivedByFirstName;
                    hc.strReceivedByPatronymicName = NotificationReceivedByPatronymicName;
                    hc.strReceivedByLastName = NotificationReceivedByLastName;
                }
                hc.Patient.strHomePhone = PhoneNumber;

                hc.Validation += (sender, args) =>
                {
                    LastErrorDescription = GetErrorMessage(args);
                    throw new SoapException(EidssMessages.GetValidationErrorMessage(args, "en"), new XmlQualifiedName(args.FieldName));
                };

                ret = acc.Post(manager, hc);
                if (!ret)
                {
                    LastErrorDescription = "Unknown error is occured during posting case";
                    throw new SoapException("Unknown error is occured during posting case", new XmlQualifiedName("post"));
                }

                Id = hc.idfCase;
                CaseID = hc.strCaseID;
            }

            return ret;
        }

        private static string GetString(string key)
        {
            var value = EidssFields.Instance.GetString(key);
            if (string.IsNullOrWhiteSpace(value))
            {
                return key;
            }
            return value;
        }
        private static string GetErrorMessage(ValidationEventArgs args)
        {
            if (args.Type == typeof(RequiredValidator))
            {
                return string.Format(EidssMessages.Get(args.MessageId), GetString(args.Pars[0].ToString()));
            }
            return EidssMessages.Get(args.MessageId);
        }

        /*
        protected override string SavingProcedureName
        {
            get
            {
                return "spHumanCase_Post";
            }
        }

        protected override void OnSaving(IDbConnection connection, IDbTransaction transaction)
        {
            //ValidationResult res = Validate();
            //if (res.IsValid == false)
                //throw new ModelValidationException(res);

            if ( Id==null )
            {
                Id = BaseDbService.NewIntID(transaction);
                bv.common.ErrorMessage err = new bv.common.ErrorMessage();
                CaseID = NumberingService.GetNextNumber(NumberingObject.HumanCase, null, connection, ref err, transaction);
                EnteredDate = DateTime.Now;
            }

            idfGeoLocation=BaseDbService.NewIntID(transaction);
            idfCSObservation = BaseDbService.NewIntID(transaction);
            idfEpiObservation = BaseDbService.NewIntID(transaction);

            ModificationDate = DateTime.Now;

            Address residence = new Address();
            if (CurrentResidence != null)
            {
                if (CurrentResidence.Country.Id != null) residence.CountryId = CurrentResidence.Country.Id.Value;
                if (CurrentResidence.Region.Id  != null) residence.RegionId = CurrentResidence.Region.Id.Value;
                if (CurrentResidence.Rayon.Id != null) residence.RayonId = CurrentResidence.Rayon.Id.Value;
                residence.Save(connection, transaction);
            }

            Patient p = new Patient();
            p.CaseId = Id.Value;
            p.CurrentResidenceId = residence.Id.Value;
            if(PatientGender!=null)p.HumanGenderId = PatientGender.Id;
            p.FirstName = FirstName;
            p.LastName = LastName;
            p.Save(connection, transaction);
            idfHuman = p.Id.Value;

            //Patient.CurrentResidence.Save(connection, transaction);
            //Patient.CurrentResidenceId = Patient.CurrentResidence.Id;
            //Patient.Save(connection, transaction);
            //PatientId = Patient.Id;
        }
        */
    }
}
