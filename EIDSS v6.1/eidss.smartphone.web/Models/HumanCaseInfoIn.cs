using System;
using System.Collections.Generic;
using System.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Helpers;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.model.Schema;
using System.Xml.Linq;
using eidss.model.Enums;
using eidss.model.Model.FlexibleForms.Helpers;

namespace eidss.smartphone.web.Models
{
    public partial class HumanCaseInfoIn : InfoInBase
    {
        public FFModelIn FFModelCS { get; set; }
        public FFModelIn FFModelEpi { get; set; }
        public List<HumanCaseSampleInfoIn> samples { get; set; }

        private long find_by_offline_id(DbManagerProxy manager)
        {
            long ret = HumanCaseListItem.Accessor.Instance(null)
                .SelectListT(manager, new FilterParams().Add("uidOfflineCaseID", "=", uidOfflineCaseID))
                .Select(c => c.idfCase).FirstOrDefault();
            return ret;
        }

        public HumanCaseInfoIn()
        {
            samples = new List<HumanCaseSampleInfoIn>();
        }

        public static HumanCaseInfoOut Init(XElement xml)
        {
            HumanCaseInfoIn ret = new HumanCaseInfoIn(xml);
            ret.samples = new List<HumanCaseSampleInfoIn>();
            xml.Element("samples").Elements("sample").ToList().ForEach(c => ret.samples.Add(HumanCaseSampleInfoIn.Init(c)));
            xml.Elements("ffmodel").ToList().ForEach(c =>
            {
                if ((string)c.Attribute("idfsFormType") == "10034010")
                    ret.FFModelCS = new FFModelIn(c);
                else if ((string)c.Attribute("idfsFormType") == "10034011")
                    ret.FFModelEpi = new FFModelIn(c);
            });
            return ret.Save();
        }

        public static IList<HumanCaseInfoOut> Save(XDocument doc)
        {
            var ret = new List<HumanCaseInfoOut>();
            if (doc.Root != null)
            {
                var human = doc.Root.Element("human");
                if (human != null)
                    human.Elements("case").ToList().ForEach(c => ret.Add(Init(c)));
            }
            return ret;
        }

        public HumanCaseInfoOut Save()
        {
            var ret = new HumanCaseInfoOut(this);
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanCase.Accessor.Instance(null);
                HumanCase hc = null;
                var find = find_by_offline_id(manager);
                if (find != 0)
                {
                    hc = acc.SelectByKey(manager, find);
                    ret.isUpdated = true;
                    idfCase = hc.idfCase;
                }
                else
                {
                    if (idfCase != 0)
                    {
                        var audit_acc = DataAuditListItem.Accessor.Instance(null);
                        DataAuditListItem item = audit_acc.CreateNewT(manager, null);
                        var filters = new FilterParams();
                        filters.Add("idfMainObject", "=", idfCase);
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
                        // check unique for Personal ID Type and Personal ID
                        long idfHumanActual = 0;
                        if (idfsPersonIDType != 0 && !string.IsNullOrEmpty(strPersonID))
                        {
                            var idfHumanActualOnlyID = PatientListItem.Accessor.Instance(null)
                                .SelectListT(manager, new FilterParams()
                                    .Add("idfsPersonIDType", "=", idfsPersonIDType)
                                    .Add("strPersonID", "=", strPersonID)
                                    ).Select(c => c.idfHumanActual).FirstOrDefault();
                            if (idfHumanActualOnlyID != 0)
                            {
                                FilterParams fp = new FilterParams()
                                    .Add("idfsPersonIDType", "=", idfsPersonIDType)
                                    .Add("strPersonID", "=", strPersonID)
                                    .Add("strLastName", "=", strFamilyName)
                                    .Add("strFirstName", "=", strFirstName)
                                    .Add("strSecondName", "=", strSecondName)
                                    .Add("idfsHumanGender", "=", idfsHumanGender);
                                if (datDateofBirth != DateTime.MinValue)
                                    fp = fp.Add("datDateofBirth", "=", datDateofBirth);
                                idfHumanActual = PatientListItem.Accessor.Instance(null)
                                    .SelectListT(manager, fp).Select(c => c.idfHumanActual).FirstOrDefault();
                                
                                if (idfHumanActual == 0) // not found
                                {
                                    var patient = Patient.Accessor.Instance(null).SelectByKey(manager, idfHumanActualOnlyID);
                                    var strFullName = patient.strLastName + " " + patient.strFirstName + " " + strSecondName;
                                    var strBirthDate = patient.datDateofBirth.HasValue ? patient.datDateofBirth.Value.ToShortDateString() : "";
                                    var strSex = patient.Gender != null ? patient.Gender.ToStringProp : "";
                                    var strAddress = patient.CurrentResidenceAddress != null ? patient.CurrentResidenceAddress.strReadOnlyAdaptiveFullName : "";
                                    ret.lastErrorDescription = string.Format(EidssMessages.Get("strDuplicatePersonalIDError"), strPersonID, strFullName, strBirthDate, strSex, strAddress);
                                    ret.isCreated = false;
                                    ret.isUpdated = false;
                                    ret.isFailed = true;
                                }
                            }
                        }

                        if (!ret.isFailed)
                        {
                            hc = acc.CreateNewT(manager, null);
                            if (idfHumanActual != 0)
                            {
                                // set found patient
                                /*
                                var patient = Patient.Accessor.Instance(null).SelectByKey(manager, idfHumanActual);
                                hc.Patient = hc.Patient.CopyFrom(manager, patient);
                                hc.Patient.intPatientAgeFromCase = hc.CalcPatientAge();
                                hc.Patient.HumanAgeType = hc.Patient.HumanAgeTypeLookup.SingleOrDefault(a => a.idfsBaseReference == hc.CalcPatientAgeType());
                                HumanCase.Accessor.Instance(null).SetupChildHandlers(hc, hc.Patient);
                                */
                                hc.Patient.SetFromRoot(manager, idfHumanActual, hc);
                            }
                            ret.isCreated = true;
                        }
                    }
                }

                if (!ret.isFailed)
                    hc.Validation += (sender, args) =>
                    {
                        if (args.ShouldAsk)
                            args.Continue = true;
                        else
                        {
                            ret.lastErrorDescription = GetErrorMessage(args);
                            ret.isCreated = false;
                            ret.isUpdated = false;
                            ret.isFailed = true;
                        }
                    };

                var bCaseModifyedInServer = false;
                if (!ret.isFailed)
                    bCaseModifyedInServer = hc.datModificationDate.HasValue
                        && hc.datModificationDate.Value.AddMilliseconds(-hc.datModificationDate.Value.Millisecond) != datModificationDate;

                if (!ret.isFailed)
                    hc.uidOfflineCaseID = new Guid(uidOfflineCaseID);

                // Sync group 1
                if (!ret.isFailed)
                    hc.datCompletionPaperFormDate = datCompletionPaperFormDate == DateTime.MinValue ? new DateTime?() : datCompletionPaperFormDate;
                if (!ret.isFailed)
                    hc.strLocalIdentifier = strLocalIdentifier;
                if (!ret.isFailed)
                {
                    hc.TentativeDiagnosis = null;
                    hc.idfsTentativeDiagnosis = idfsTentativeDiagnosis == 0 ? new long?() : idfsTentativeDiagnosis;
                    HumanCase.Accessor.Instance(null).LoadLookup_TentativeDiagnosis(manager, hc);
                }
                if (!ret.isFailed)
                    hc.datTentativeDiagnosisDate = datTentativeDiagnosisDate == DateTime.MinValue ? new DateTime?() : datTentativeDiagnosisDate;
                if (!ret.isFailed)
                    hc.Patient.strLastName = strFamilyName;
                if (!ret.isFailed)
                    hc.Patient.strFirstName = strFirstName;
                if (!ret.isFailed)
                    hc.Patient.strSecondName = strSecondName;
                if (!ret.isFailed)
                    hc.Patient.datDateofBirth = datDateofBirth == DateTime.MinValue ? new DateTime?() : datDateofBirth;
                if (!ret.isFailed)
                {
                    hc.Patient.HumanAgeType = null;
                    hc.Patient.idfsHumanAgeTypeFromCase = idfsHumanAgeType == 0 ? new long?() : idfsHumanAgeType;
                    Patient.Accessor.Instance(null).LoadLookup_HumanAgeType(manager, hc.Patient);
                }
                if (!ret.isFailed)
                    hc.intPatientAge = intPatientAge > 0 ? new int?(intPatientAge) : null;
                if (!ret.isFailed)
                    hc.Patient.intPatientAgeFromCase = hc.intPatientAge;
                if (!ret.isFailed)
                {
                    hc.Patient.Gender = null;
                    hc.Patient.idfsHumanGender = idfsHumanGender == 0 ? new long?() : idfsHumanGender;
                    Patient.Accessor.Instance(null).LoadLookup_Gender(manager, hc.Patient);
                }
                if (!ret.isFailed)
                {
                    hc.Patient.PersonIDType = null;
                    hc.Patient.idfsPersonIDType = idfsPersonIDType == 0 ? new long?() : idfsPersonIDType;
                    Patient.Accessor.Instance(null).LoadLookup_PersonIDType(manager, hc.Patient);
                }
                if (!ret.isFailed)
                    hc.Patient.strPersonID = strPersonID;
                if (!ret.isFailed)
                {
                    hc.Patient.Nationality = null;
                    hc.Patient.idfsNationality = idfsNationality == 0 ? new long?() : idfsNationality;
                    Patient.Accessor.Instance(null).LoadLookup_Nationality(manager, hc.Patient);
                }
                if (!ret.isFailed)
                {
                    hc.Patient.CurrentResidenceAddress.Country = hc.Patient.CurrentResidenceAddress.CountryLookup.SingleOrDefault(c => c.idfsCountry == EidssSiteContext.Instance.CountryID);
                }
                if (!ret.isFailed)
                {
                    hc.Patient.CurrentResidenceAddress.Region = null;
                    hc.Patient.CurrentResidenceAddress.idfsRegion = idfsRegionCurrentResidence == 0 ? new long?() : idfsRegionCurrentResidence;
                    Address.Accessor.Instance(null).LoadLookup_Region(manager, hc.Patient.CurrentResidenceAddress);
                }
                if (!ret.isFailed)
                {
                    hc.Patient.CurrentResidenceAddress.Rayon = null;
                    hc.Patient.CurrentResidenceAddress.idfsRayon = idfsRayonCurrentResidence == 0 ? new long?() : idfsRayonCurrentResidence;
                    Address.Accessor.Instance(null).LoadLookup_Rayon(manager, hc.Patient.CurrentResidenceAddress);
                }
                if (!ret.isFailed)
                {
                    hc.Patient.CurrentResidenceAddress.Settlement = null;
                    hc.Patient.CurrentResidenceAddress.idfsSettlement = idfsSettlementCurrentResidence == 0 ? new long?() : idfsSettlementCurrentResidence;
                    Address.Accessor.Instance(null).LoadLookup_Settlement(manager, hc.Patient.CurrentResidenceAddress);
                }
                if (!ret.isFailed)
                    hc.Patient.CurrentResidenceAddress.strStreetName = strStreetName;
                if (!ret.isFailed)
                    hc.Patient.CurrentResidenceAddress.strBuilding = strBuilding;
                if (!ret.isFailed)
                    hc.Patient.CurrentResidenceAddress.strHouse = strHouse;
                if (!ret.isFailed)
                    hc.Patient.CurrentResidenceAddress.strApartment = strApartment;
                if (!ret.isFailed)
                    hc.Patient.CurrentResidenceAddress.strPostCode = strPostCode;
                if (!ret.isFailed)
                    hc.Patient.strHomePhone = strHomePhone;
                if (!ret.isFailed)
                    hc.Patient.strRegistrationPhone = strPermanentResidencePhone;
                if (!ret.isFailed)
                    hc.Patient.strEmployerName = strEmployerName;
                if (!ret.isFailed)
                    hc.Patient.strWorkPhone = strWorkPhone;
                if (!ret.isFailed)
                    hc.datOnSetDate = datOnSetDate == DateTime.MinValue ? new DateTime?() : datOnSetDate;
                if (!ret.isFailed)
                {
                    hc.PatientState = null;
                    hc.idfsFinalState = idfsFinalState == 0 ? new long?() : idfsFinalState;
                    HumanCase.Accessor.Instance(null).LoadLookup_PatientState(manager, hc);
                }
                if (!ret.isFailed)
                {
                    hc.PatientLocationType = null;
                    hc.idfsHospitalizationStatus = idfsHospitalizationStatus == 0 ? new long?() : idfsHospitalizationStatus;
                    HumanCase.Accessor.Instance(null).LoadLookup_PatientLocationType(manager, hc);
                }
                if (!ret.isFailed)
                {
                    hc.Hospital = null;
                    hc.idfHospital = idfHospital == 0 ? new long?() : idfHospital;
                    HumanCase.Accessor.Instance(null).LoadLookup_Hospital(manager, hc);
                }
                // Location of explosure // TODO
                if (!ret.isFailed)
                    hc.datExposureDate = datExposureDate == DateTime.MinValue ? new DateTime?() : datExposureDate;
                if (!ret.isFailed)
                    hc.strNote = strComment;


                // Sync group 2
                if (!bCaseModifyedInServer)
                {
                    if (!ret.isFailed)
                    {
                        hc.InitialCaseClassification = null;
                        hc.idfsInitialCaseStatus = idfsInitialCaseStatus == 0 ? new long?() : idfsInitialCaseStatus;
                        HumanCase.Accessor.Instance(null).LoadLookup_InitialCaseClassification(manager, hc);
                    }
                    if (!ret.isFailed)
                    {
                        hc.SoughtCareFacility = null;
                        hc.idfSoughtCareFacility = idfSoughtCareFacility == 0 ? new long?() : idfSoughtCareFacility;
                        HumanCase.Accessor.Instance(null).LoadLookup_SoughtCareFacility(manager, hc);
                    }
                    if (!ret.isFailed)
                        hc.datFirstSoughtCareDate = datFirstSoughtCareDate == DateTime.MinValue ? new DateTime?() : datFirstSoughtCareDate;
                    if (!ret.isFailed)
                    {
                        hc.Hospitalization = null;
                        hc.idfsYNHospitalization = idfsYNHospitalization == 0 ? new long?() : idfsYNHospitalization;
                        HumanCase.Accessor.Instance(null).LoadLookup_Hospitalization(manager, hc);
                    }
                    if (!ret.isFailed)
                        hc.strHospitalizationPlace = strHospitalizationPlace;
                    if (!ret.isFailed)
                        hc.datHospitalizationDate = datHospitalizationDate == DateTime.MinValue ? new DateTime?() : datHospitalizationDate;
                    if (!ret.isFailed && hc.Samples.Count == 0)
                    {
                        hc.SpecimenCollected = null;
                        hc.idfsYNSpecimenCollected = idfsYNSpecimenCollected == 0 ? new long?() : idfsYNSpecimenCollected;
                        HumanCase.Accessor.Instance(null).LoadLookup_SpecimenCollected(manager, hc);
                    }
                    if (!ret.isFailed)
                    {
                        hc.NotCollectedReason = null;
                        hc.idfsNotCollectedReason = idfsNotCollectedReason == 0 ? new long?() : idfsNotCollectedReason;
                        HumanCase.Accessor.Instance(null).LoadLookup_NotCollectedReason(manager, hc);
                    }
                }

                if (!ret.isFailed)
                {
                    foreach (var p in FFModelCS.parameters)
                    {
                        var ap = hc.FFPresenterCs.ActivityParameters.SetActivityParameterValue(
                            hc.FFPresenterCs.CurrentTemplate
                            , hc.idfCSObservation.Value
                            , p.idfsParameter
                            , p.Value
                            );
                        if (ap != null) ap.IsDynamicParameter = true; //just in case
                    }
                    foreach (var p in FFModelEpi.parameters)
                    {
                        var ap = hc.FFPresenterEpi.ActivityParameters.SetActivityParameterValue(
                            hc.FFPresenterEpi.CurrentTemplate
                            , hc.idfEpiObservation.Value
                            , p.idfsParameter
                            , p.Value
                            );
                        if (ap != null) ap.IsDynamicParameter = true; //just in case
                    }
                }

                if (!ret.isFailed)
                    foreach (var a in samples.Where(i => i.intChanged == 1).ToList())
                    {
                        HumanCaseSample sample;
                        if (a.idfMaterial <= 0)
                            sample = hc.Samples.FirstOrDefault(i => i.uidOfflineCaseID.HasValue && !string.IsNullOrEmpty(a.uidOfflineCaseID) && i.uidOfflineCaseID.Value == new Guid(a.uidOfflineCaseID));
                        else
                            sample = hc.Samples.FirstOrDefault(i => i.idfMaterial == a.idfMaterial);

                        if (sample == null)
                        {
                            sample = HumanCaseSample.Accessor.Instance(null).Create(manager, hc,
                                a.idfSendToOffice, null, null, "_organization", "", "");
                            a.FillHumanCaseSample(sample);
                            hc.Samples.Add(sample);
                        }
                        else
                        {
                            a.FillHumanCaseSample(sample);
                        }
                    }

                if (!ret.isFailed)
                    if (idfCase == 0)
                    {
                        hc.datNotificationDate = DateTime.Today;
                        hc.idfSentByOffice = EidssSiteContext.Instance.OrganizationID;
                        hc.strSentByOffice = EidssSiteContext.Instance.OrganizationName;
                        hc.idfSentByPerson = (long)EidssUserContext.User.EmployeeID;
                        hc.strSentByPerson = EidssUserContext.User.FullName;
                        //hc.SentByOffice = hc.SentByOfficeLookup.SingleOrDefault(c => c.idfInstitution == EidssSiteContext.Instance.OrganizationID);
                        //hc.SentByPerson = hc.SentByPersonLookup.SingleOrDefault(c => c.idfPerson == (long)EidssUserContext.User.EmployeeID);
                    }

                if (!ret.isFailed)
                {
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
                }


                // Sync group 3
                if (!ret.isFailed)
                {
                    ret.idfCase = hc.idfCase;
                    ret.strCaseID = hc.strCaseID;
                    ret.datNotificationDate = hc.datNotificationDate.Value;
                    ret.idfSentByOffice = hc.idfSentByOffice.HasValue ? hc.idfSentByOffice.Value : 0;
                    ret.strSentByPerson = hc.SentByPerson == null ? hc.strSentByPerson : hc.SentByPerson.FullName;
                    ret.idfReceivedByOffice = hc.idfReceivedByOffice.HasValue ? hc.idfReceivedByOffice.Value : 0;
                    ret.strReceivedByPerson = hc.strReceivedByPerson;
                    ret.idfInvestigatedByOffice = hc.idfInvestigatedByOffice.HasValue ? hc.idfInvestigatedByOffice.Value : 0;
                    ret.datInvestigationStartDate = hc.datInvestigationStartDate.HasValue ? hc.datInvestigationStartDate.Value : DateTime.MinValue;
                    ret.idfsYNTestsConducted = hc.idfsYNTestsConducted.HasValue ? hc.idfsYNTestsConducted.Value : 0;
                    ret.idfsFinalCaseStatus = hc.idfsFinalCaseStatus.HasValue ? hc.idfsFinalCaseStatus.Value : 0;
                    ret.datFinalCaseClassificationDate = hc.datFinalCaseClassificationDate.HasValue ? hc.datFinalCaseClassificationDate.Value : DateTime.MinValue;
                    ret.strEpidemiologistsName = hc.InvestigatedByPerson == null ? "" : hc.InvestigatedByPerson.FullName; ;
                    ret.idfsFinalDiagnosis = hc.idfsDiagnosis.HasValue ? hc.idfsDiagnosis.Value : 0;
                    ret.datFinalDiagnosisDate = hc.datFinalDiagnosisDate.HasValue ? hc.datFinalDiagnosisDate.Value : DateTime.MinValue;
                    ret.blnClinicalDiagBasis = hc.blnClinicalDiagBasis.HasValue ? hc.blnClinicalDiagBasis.Value : false;
                    ret.blnEpiDiagBasis = hc.blnEpiDiagBasis.HasValue ? hc.blnEpiDiagBasis.Value : false;
                    ret.blnLabDiagBasis = hc.blnLabDiagBasis.HasValue ? hc.blnLabDiagBasis.Value : false;
                    ret.idfsOutcome = hc.idfsOutcome.HasValue ? hc.idfsOutcome.Value : 0;
                    ret.idfsYNRelatedToOutbreak = hc.idfsYNRelatedToOutbreak.HasValue ? hc.idfsYNRelatedToOutbreak.Value : 0;
                    ret.datModificationDate = hc.datModificationDate.HasValue ? hc.datModificationDate.Value : ret.datModificationDate;

                    // Sync group 2
                    ret.idfsInitialCaseStatus = hc.idfsInitialCaseStatus.HasValue ? hc.idfsInitialCaseStatus.Value : 0;
                    ret.idfSoughtCareFacility = hc.idfSoughtCareFacility.HasValue ? hc.idfSoughtCareFacility.Value : 0;
                    ret.datFirstSoughtCareDate = hc.datFirstSoughtCareDate.HasValue ? hc.datFirstSoughtCareDate.Value : DateTime.MinValue;
                    ret.idfsYNHospitalization = hc.idfsYNHospitalization.HasValue ? hc.idfsYNHospitalization.Value : 0;
                    ret.strHospitalizationPlace = hc.strHospitalizationPlace;
                    ret.datHospitalizationDate = hc.datHospitalizationDate.HasValue ? hc.datHospitalizationDate.Value : DateTime.MinValue;
                    ret.idfsYNSpecimenCollected = hc.idfsYNSpecimenCollected.HasValue ? hc.idfsYNSpecimenCollected.Value : 0;
                    ret.idfsNotCollectedReason = hc.idfsNotCollectedReason.HasValue ? hc.idfsNotCollectedReason.Value : 0;
                    if (bCaseModifyedInServer && !ret.isFailed)
                    {
                        var listOfChanges = new List<Tuple<string, string, string>>();
                        if (ret.idfsInitialCaseStatus != idfsInitialCaseStatus)
                            listOfChanges.Add(new Tuple<string, string, string>(
                                EidssFields.Get("idfsInitialCaseStatus"),
                                hc.InitialCaseClassificationLookup.FirstOrDefault(i => i.idfsReference == idfsInitialCaseStatus, i => i.name, () => ""),
                                hc.InitialCaseClassificationLookup.FirstOrDefault(i => i.idfsReference == ret.idfsInitialCaseStatus, i => i.name, () => "")
                                ));
                        if (ret.idfSoughtCareFacility != idfSoughtCareFacility)
                            listOfChanges.Add(new Tuple<string, string, string>(
                                EidssFields.Get("strSoughtCareFacility"),
                                hc.SoughtCareFacilityLookup.FirstOrDefault(i => i.idfInstitution == idfSoughtCareFacility, i => i.name, () => ""),
                                hc.SoughtCareFacilityLookup.FirstOrDefault(i => i.idfInstitution == ret.idfSoughtCareFacility, i => i.name, () => "")
                                ));
                        if (ret.datFirstSoughtCareDate != datFirstSoughtCareDate)
                            listOfChanges.Add(new Tuple<string, string, string>(
                                EidssFields.Get("datFirstSoughtCareDate"),
                                datFirstSoughtCareDate == DateTime.MinValue ? "" : datFirstSoughtCareDate.ToShortDateString(),
                                ret.datFirstSoughtCareDate == DateTime.MinValue ? "" : ret.datFirstSoughtCareDate.ToShortDateString()
                                ));
                        if (ret.idfsYNHospitalization != idfsYNHospitalization)
                            listOfChanges.Add(new Tuple<string, string, string>(
                                EidssFields.Get("idfsYNHospitalization"),
                                hc.HospitalizationLookup.FirstOrDefault(i => i.idfsBaseReference == idfsYNHospitalization, i => i.name, () => ""),
                                hc.HospitalizationLookup.FirstOrDefault(i => i.idfsBaseReference == ret.idfsYNHospitalization, i => i.name, () => "")
                                ));
                        if ((ret.strHospitalizationPlace ?? "") != (strHospitalizationPlace ?? ""))
                            listOfChanges.Add(new Tuple<string, string, string>(
                                EidssFields.Get("strHospitalizationPlace"),
                                strHospitalizationPlace,
                                ret.strHospitalizationPlace
                                ));
                        if (ret.datHospitalizationDate != datHospitalizationDate)
                            listOfChanges.Add(new Tuple<string, string, string>(
                                EidssFields.Get("datHospitalizationDate"),
                                datHospitalizationDate == DateTime.MinValue ? "" : datHospitalizationDate.ToShortDateString(),
                                ret.datHospitalizationDate == DateTime.MinValue ? "" : ret.datHospitalizationDate.ToShortDateString()
                                ));
                        if (ret.idfsYNSpecimenCollected != idfsYNSpecimenCollected)
                            listOfChanges.Add(new Tuple<string, string, string>(
                                EidssFields.Get("idfsYNSpecimenCollected"),
                                hc.SpecimenCollectedLookup.FirstOrDefault(i => i.idfsBaseReference == idfsYNSpecimenCollected, i => i.name, () => ""),
                                hc.SpecimenCollectedLookup.FirstOrDefault(i => i.idfsBaseReference == ret.idfsYNSpecimenCollected, i => i.name, () => "")
                                ));
                        if (ret.idfsNotCollectedReason != idfsNotCollectedReason)
                            listOfChanges.Add(new Tuple<string, string, string>(
                                EidssFields.Get("NotCollectedReason"),
                                hc.NotCollectedReasonLookup.FirstOrDefault(i => i.idfsBaseReference == idfsNotCollectedReason, i => i.name, () => ""),
                                hc.NotCollectedReasonLookup.FirstOrDefault(i => i.idfsBaseReference == ret.idfsNotCollectedReason, i => i.name, () => "")
                                ));
                        if (listOfChanges.Count > 0)
                        {
                            var fldList = "";
                            listOfChanges.ForEach(c => fldList += (fldList.Length > 0 ? ", " : "") + c.Item1 + " = " + " '" + c.Item2 + "'");
                            ret.lastErrorDescription = string.Format(EidssMessages.Get("msgSyncGroup2"), fldList);
                        }
                    }

                    foreach (var s in hc.Samples)
                    {
                        ret.samples.Add(new HumanCaseSampleInfoIn(s));
                    }

                    // FF
                    ret.idfCSObservation = hc.FFPresenterCs.CurrentObservation.Value;
                    ret.idfEpiObservation = hc.FFPresenterEpi.CurrentObservation.Value;

                }
            }

            return ret;
        }

    }
}