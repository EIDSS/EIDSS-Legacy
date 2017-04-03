﻿#pragma warning disable 0472
using System;
using System.Text;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Xml.Serialization;
using BLToolkit.Aspects;
using BLToolkit.DataAccess;
using BLToolkit.EditableObjects;
using BLToolkit.Data;
using BLToolkit.Data.DataProvider;
using BLToolkit.Mapping;
using BLToolkit.Reflection;
using bv.common.Configuration;
using bv.common.Enums;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model;
using bv.model.Helpers;
using bv.model.Model.Extenders;
using bv.model.Model.Core;
using bv.model.Model.Handlers;
using bv.model.Model.Validators;
using eidss.model.Core;
using eidss.model.Enums;
		

namespace eidss.model.Schema
{
        
        
    [XmlType(AnonymousType = true)]
    public abstract partial class HumanCaseListItem : 
        EditableObject<HumanCaseListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfCase { get; set; }
                
        [LocalizedDisplayName(_str_idfsDiagnosis)]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64? idfsDiagnosis { get; set; }
        #if MONO
        protected Int64? idfsDiagnosis_Original { get { return idfsDiagnosis; } }
        protected Int64? idfsDiagnosis_Previous { get { return idfsDiagnosis; } }
        #else
        protected Int64? idfsDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64? idfsDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("FinalDiagnosisName")]
        [MapField(_str_DiagnosisName)]
        public abstract String DiagnosisName { get; set; }
        #if MONO
        protected String DiagnosisName_Original { get { return DiagnosisName; } }
        protected String DiagnosisName_Previous { get { return DiagnosisName; } }
        #else
        protected String DiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).OriginalValue; } }
        protected String DiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCaseStatus)]
        [MapField(_str_idfsCaseStatus)]
        public abstract Int64? idfsCaseStatus { get; set; }
        #if MONO
        protected Int64? idfsCaseStatus_Original { get { return idfsCaseStatus; } }
        protected Int64? idfsCaseStatus_Previous { get { return idfsCaseStatus; } }
        #else
        protected Int64? idfsCaseStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseStatus).OriginalValue; } }
        protected Int64? idfsCaseStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCaseProgressStatus)]
        [MapField(_str_idfsCaseProgressStatus)]
        public abstract Int64? idfsCaseProgressStatus { get; set; }
        #if MONO
        protected Int64? idfsCaseProgressStatus_Original { get { return idfsCaseProgressStatus; } }
        protected Int64? idfsCaseProgressStatus_Previous { get { return idfsCaseProgressStatus; } }
        #else
        protected Int64? idfsCaseProgressStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseProgressStatus).OriginalValue; } }
        protected Int64? idfsCaseProgressStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseProgressStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_CaseStatusName)]
        [MapField(_str_CaseStatusName)]
        public abstract String CaseStatusName { get; set; }
        #if MONO
        protected String CaseStatusName_Original { get { return CaseStatusName; } }
        protected String CaseStatusName_Previous { get { return CaseStatusName; } }
        #else
        protected String CaseStatusName_Original { get { return ((EditableValue<String>)((dynamic)this)._caseStatusName).OriginalValue; } }
        protected String CaseStatusName_Previous { get { return ((EditableValue<String>)((dynamic)this)._caseStatusName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_CaseProgressStatusName)]
        [MapField(_str_CaseProgressStatusName)]
        public abstract String CaseProgressStatusName { get; set; }
        #if MONO
        protected String CaseProgressStatusName_Original { get { return CaseProgressStatusName; } }
        protected String CaseProgressStatusName_Previous { get { return CaseProgressStatusName; } }
        #else
        protected String CaseProgressStatusName_Original { get { return ((EditableValue<String>)((dynamic)this)._caseProgressStatusName).OriginalValue; } }
        protected String CaseProgressStatusName_Previous { get { return ((EditableValue<String>)((dynamic)this)._caseProgressStatusName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("datEnteredDateSearchPanel")]
        [MapField(_str_datEnteredDate)]
        public abstract DateTime? datEnteredDate { get; set; }
        #if MONO
        protected DateTime? datEnteredDate_Original { get { return datEnteredDate; } }
        protected DateTime? datEnteredDate_Previous { get { return datEnteredDate; } }
        #else
        protected DateTime? datEnteredDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).OriginalValue; } }
        protected DateTime? datEnteredDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCaseID)]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        #if MONO
        protected String strCaseID_Original { get { return strCaseID; } }
        protected String strCaseID_Previous { get { return strCaseID; } }
        #else
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64 idfsSite { get; set; }
        #if MONO
        protected Int64 idfsSite_Original { get { return idfsSite; } }
        protected Int64 idfsSite_Previous { get { return idfsSite; } }
        #else
        protected Int64 idfsSite_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64 idfsSite_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datCompletionPaperFormDate)]
        [MapField(_str_datCompletionPaperFormDate)]
        public abstract DateTime? datCompletionPaperFormDate { get; set; }
        #if MONO
        protected DateTime? datCompletionPaperFormDate_Original { get { return datCompletionPaperFormDate; } }
        protected DateTime? datCompletionPaperFormDate_Previous { get { return datCompletionPaperFormDate; } }
        #else
        protected DateTime? datCompletionPaperFormDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCompletionPaperFormDate).OriginalValue; } }
        protected DateTime? datCompletionPaperFormDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCompletionPaperFormDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strLocalIdentifier)]
        [MapField(_str_strLocalIdentifier)]
        public abstract String strLocalIdentifier { get; set; }
        #if MONO
        protected String strLocalIdentifier_Original { get { return strLocalIdentifier; } }
        protected String strLocalIdentifier_Previous { get { return strLocalIdentifier; } }
        #else
        protected String strLocalIdentifier_Original { get { return ((EditableValue<String>)((dynamic)this)._strLocalIdentifier).OriginalValue; } }
        protected String strLocalIdentifier_Previous { get { return ((EditableValue<String>)((dynamic)this)._strLocalIdentifier).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfPersonEnteredBy)]
        [MapField(_str_idfPersonEnteredBy)]
        public abstract Int64? idfPersonEnteredBy { get; set; }
        #if MONO
        protected Int64? idfPersonEnteredBy_Original { get { return idfPersonEnteredBy; } }
        protected Int64? idfPersonEnteredBy_Previous { get { return idfPersonEnteredBy; } }
        #else
        protected Int64? idfPersonEnteredBy_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonEnteredBy).OriginalValue; } }
        protected Int64? idfPersonEnteredBy_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonEnteredBy).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfHuman)]
        [MapField(_str_idfHuman)]
        public abstract Int64 idfHuman { get; set; }
        #if MONO
        protected Int64 idfHuman_Original { get { return idfHuman; } }
        protected Int64 idfHuman_Previous { get { return idfHuman; } }
        #else
        protected Int64 idfHuman_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfHuman).OriginalValue; } }
        protected Int64 idfHuman_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfHuman).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strLastName)]
        [MapField(_str_strLastName)]
        public abstract String strLastName { get; set; }
        #if MONO
        protected String strLastName_Original { get { return strLastName; } }
        protected String strLastName_Previous { get { return strLastName; } }
        #else
        protected String strLastName_Original { get { return ((EditableValue<String>)((dynamic)this)._strLastName).OriginalValue; } }
        protected String strLastName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strLastName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strFirstName)]
        [MapField(_str_strFirstName)]
        public abstract String strFirstName { get; set; }
        #if MONO
        protected String strFirstName_Original { get { return strFirstName; } }
        protected String strFirstName_Previous { get { return strFirstName; } }
        #else
        protected String strFirstName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).OriginalValue; } }
        protected String strFirstName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSecondName)]
        [MapField(_str_strSecondName)]
        public abstract String strSecondName { get; set; }
        #if MONO
        protected String strSecondName_Original { get { return strSecondName; } }
        protected String strSecondName_Previous { get { return strSecondName; } }
        #else
        protected String strSecondName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSecondName).OriginalValue; } }
        protected String strSecondName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSecondName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_PatientName)]
        [MapField(_str_PatientName)]
        public abstract String PatientName { get; set; }
        #if MONO
        protected String PatientName_Original { get { return PatientName; } }
        protected String PatientName_Previous { get { return PatientName; } }
        #else
        protected String PatientName_Original { get { return ((EditableValue<String>)((dynamic)this)._patientName).OriginalValue; } }
        protected String PatientName_Previous { get { return ((EditableValue<String>)((dynamic)this)._patientName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datDateofBirth)]
        [MapField(_str_datDateofBirth)]
        public abstract DateTime? datDateofBirth { get; set; }
        #if MONO
        protected DateTime? datDateofBirth_Original { get { return datDateofBirth; } }
        protected DateTime? datDateofBirth_Previous { get { return datDateofBirth; } }
        #else
        protected DateTime? datDateofBirth_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateofBirth).OriginalValue; } }
        protected DateTime? datDateofBirth_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateofBirth).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intPatientAge)]
        [MapField(_str_intPatientAge)]
        public abstract Int32? intPatientAge { get; set; }
        #if MONO
        protected Int32? intPatientAge_Original { get { return intPatientAge; } }
        protected Int32? intPatientAge_Previous { get { return intPatientAge; } }
        #else
        protected Int32? intPatientAge_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intPatientAge).OriginalValue; } }
        protected Int32? intPatientAge_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intPatientAge).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsHumanAgeType)]
        [MapField(_str_idfsHumanAgeType)]
        public abstract Int64? idfsHumanAgeType { get; set; }
        #if MONO
        protected Int64? idfsHumanAgeType_Original { get { return idfsHumanAgeType; } }
        protected Int64? idfsHumanAgeType_Previous { get { return idfsHumanAgeType; } }
        #else
        protected Int64? idfsHumanAgeType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanAgeType).OriginalValue; } }
        protected Int64? idfsHumanAgeType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanAgeType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_Age)]
        [MapField(_str_Age)]
        public abstract String Age { get; set; }
        #if MONO
        protected String Age_Original { get { return Age; } }
        protected String Age_Previous { get { return Age; } }
        #else
        protected String Age_Original { get { return ((EditableValue<String>)((dynamic)this)._age).OriginalValue; } }
        protected String Age_Previous { get { return ((EditableValue<String>)((dynamic)this)._age).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfAddress)]
        [MapField(_str_idfAddress)]
        public abstract Int64? idfAddress { get; set; }
        #if MONO
        protected Int64? idfAddress_Original { get { return idfAddress; } }
        protected Int64? idfAddress_Previous { get { return idfAddress; } }
        #else
        protected Int64? idfAddress_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAddress).OriginalValue; } }
        protected Int64? idfAddress_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAddress).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfGeoLocation)]
        [MapField(_str_idfGeoLocation)]
        public abstract Int64? idfGeoLocation { get; set; }
        #if MONO
        protected Int64? idfGeoLocation_Original { get { return idfGeoLocation; } }
        protected Int64? idfGeoLocation_Previous { get { return idfGeoLocation; } }
        #else
        protected Int64? idfGeoLocation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfGeoLocation).OriginalValue; } }
        protected Int64? idfGeoLocation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfGeoLocation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_GeoLocationName)]
        [MapField(_str_GeoLocationName)]
        public abstract String GeoLocationName { get; set; }
        #if MONO
        protected String GeoLocationName_Original { get { return GeoLocationName; } }
        protected String GeoLocationName_Previous { get { return GeoLocationName; } }
        #else
        protected String GeoLocationName_Original { get { return ((EditableValue<String>)((dynamic)this)._geoLocationName).OriginalValue; } }
        protected String GeoLocationName_Previous { get { return ((EditableValue<String>)((dynamic)this)._geoLocationName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfEpiObservation)]
        [MapField(_str_idfEpiObservation)]
        public abstract Int64? idfEpiObservation { get; set; }
        #if MONO
        protected Int64? idfEpiObservation_Original { get { return idfEpiObservation; } }
        protected Int64? idfEpiObservation_Previous { get { return idfEpiObservation; } }
        #else
        protected Int64? idfEpiObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfEpiObservation).OriginalValue; } }
        protected Int64? idfEpiObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfEpiObservation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfCSObservation)]
        [MapField(_str_idfCSObservation)]
        public abstract Int64? idfCSObservation { get; set; }
        #if MONO
        protected Int64? idfCSObservation_Original { get { return idfCSObservation; } }
        protected Int64? idfCSObservation_Previous { get { return idfCSObservation; } }
        #else
        protected Int64? idfCSObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCSObservation).OriginalValue; } }
        protected Int64? idfCSObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCSObservation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsTentativeDiagnosis)]
        [MapField(_str_idfsTentativeDiagnosis)]
        public abstract Int64? idfsTentativeDiagnosis { get; set; }
        #if MONO
        protected Int64? idfsTentativeDiagnosis_Original { get { return idfsTentativeDiagnosis; } }
        protected Int64? idfsTentativeDiagnosis_Previous { get { return idfsTentativeDiagnosis; } }
        #else
        protected Int64? idfsTentativeDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis).OriginalValue; } }
        protected Int64? idfsTentativeDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsInitialCaseStatus)]
        [MapField(_str_idfsInitialCaseStatus)]
        public abstract Int64? idfsInitialCaseStatus { get; set; }
        #if MONO
        protected Int64? idfsInitialCaseStatus_Original { get { return idfsInitialCaseStatus; } }
        protected Int64? idfsInitialCaseStatus_Previous { get { return idfsInitialCaseStatus; } }
        #else
        protected Int64? idfsInitialCaseStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsInitialCaseStatus).OriginalValue; } }
        protected Int64? idfsInitialCaseStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsInitialCaseStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSettlement)]
        [MapField(_str_idfsSettlement)]
        public abstract Int64? idfsSettlement { get; set; }
        #if MONO
        protected Int64? idfsSettlement_Original { get { return idfsSettlement; } }
        protected Int64? idfsSettlement_Previous { get { return idfsSettlement; } }
        #else
        protected Int64? idfsSettlement_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).OriginalValue; } }
        protected Int64? idfsSettlement_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsRegion)]
        [MapField(_str_idfsRegion)]
        public abstract Int64? idfsRegion { get; set; }
        #if MONO
        protected Int64? idfsRegion_Original { get { return idfsRegion; } }
        protected Int64? idfsRegion_Previous { get { return idfsRegion; } }
        #else
        protected Int64? idfsRegion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).OriginalValue; } }
        protected Int64? idfsRegion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsRayon)]
        [MapField(_str_idfsRayon)]
        public abstract Int64? idfsRayon { get; set; }
        #if MONO
        protected Int64? idfsRayon_Original { get { return idfsRayon; } }
        protected Int64? idfsRayon_Previous { get { return idfsRayon; } }
        #else
        protected Int64? idfsRayon_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).OriginalValue; } }
        protected Int64? idfsRayon_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCountry)]
        [MapField(_str_idfsCountry)]
        public abstract Int64? idfsCountry { get; set; }
        #if MONO
        protected Int64? idfsCountry_Original { get { return idfsCountry; } }
        protected Int64? idfsCountry_Previous { get { return idfsCountry; } }
        #else
        protected Int64? idfsCountry_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).OriginalValue; } }
        protected Int64? idfsCountry_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<HumanCaseListItem, object> _get_func;
            internal Action<HumanCaseListItem, string> _set_func;
            internal Action<HumanCaseListItem, HumanCaseListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_DiagnosisName = "DiagnosisName";
        internal const string _str_idfsCaseStatus = "idfsCaseStatus";
        internal const string _str_idfsCaseProgressStatus = "idfsCaseProgressStatus";
        internal const string _str_CaseStatusName = "CaseStatusName";
        internal const string _str_CaseProgressStatusName = "CaseProgressStatusName";
        internal const string _str_datEnteredDate = "datEnteredDate";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_datCompletionPaperFormDate = "datCompletionPaperFormDate";
        internal const string _str_strLocalIdentifier = "strLocalIdentifier";
        internal const string _str_idfPersonEnteredBy = "idfPersonEnteredBy";
        internal const string _str_idfHuman = "idfHuman";
        internal const string _str_strLastName = "strLastName";
        internal const string _str_strFirstName = "strFirstName";
        internal const string _str_strSecondName = "strSecondName";
        internal const string _str_PatientName = "PatientName";
        internal const string _str_datDateofBirth = "datDateofBirth";
        internal const string _str_intPatientAge = "intPatientAge";
        internal const string _str_idfsHumanAgeType = "idfsHumanAgeType";
        internal const string _str_Age = "Age";
        internal const string _str_idfAddress = "idfAddress";
        internal const string _str_idfGeoLocation = "idfGeoLocation";
        internal const string _str_GeoLocationName = "GeoLocationName";
        internal const string _str_idfEpiObservation = "idfEpiObservation";
        internal const string _str_idfCSObservation = "idfCSObservation";
        internal const string _str_idfsTentativeDiagnosis = "idfsTentativeDiagnosis";
        internal const string _str_idfsInitialCaseStatus = "idfsInitialCaseStatus";
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_idfsHumanGender = "idfsHumanGender";
        internal const string _str_idfSentByOffice = "idfSentByOffice";
        internal const string _str_idfReceivedByOffice = "idfReceivedByOffice";
        internal const string _str_idfsNationality = "idfsNationality";
        internal const string _str_idfsFinalState = "idfsFinalState";
        internal const string _str_idfsHospitalizationStatus = "idfsHospitalizationStatus";
        internal const string _str_idfsFinalDiagnosis = "idfsFinalDiagnosis";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_TentativeDiagnosis = "TentativeDiagnosis";
        internal const string _str_FinalDiagnosis = "FinalDiagnosis";
        internal const string _str_CaseStatus = "CaseStatus";
        internal const string _str_CaseProgressStatus = "CaseProgressStatus";
        internal const string _str_HumanAgeType = "HumanAgeType";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Settlement = "Settlement";
        internal const string _str_HumanGender = "HumanGender";
        internal const string _str_SentByOffice = "SentByOffice";
        internal const string _str_ReceivedByOffice = "ReceivedByOffice";
        internal const string _str_Nationality = "Nationality";
        internal const string _str_PatientState = "PatientState";
        internal const string _str_PatientLocationType = "PatientLocationType";
        internal const string _str_InitialCaseStatus = "InitialCaseStatus";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfCase, _type = "Int64",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { o.idfCase = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, "Int64", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { o.idfsDiagnosis = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, "Int64?", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_DiagnosisName, _type = "String",
              _get_func = o => o.DiagnosisName,
              _set_func = (o, val) => { o.DiagnosisName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.DiagnosisName != c.DiagnosisName || o.IsRIRPropChanged(_str_DiagnosisName, c)) 
                  m.Add(_str_DiagnosisName, o.ObjectIdent + _str_DiagnosisName, "String", o.DiagnosisName == null ? "" : o.DiagnosisName.ToString(), o.IsReadOnly(_str_DiagnosisName), o.IsInvisible(_str_DiagnosisName), o.IsRequired(_str_DiagnosisName)); }
              }, 
        
            new field_info {
              _name = _str_idfsCaseStatus, _type = "Int64?",
              _get_func = o => o.idfsCaseStatus,
              _set_func = (o, val) => { o.idfsCaseStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseStatus != c.idfsCaseStatus || o.IsRIRPropChanged(_str_idfsCaseStatus, c)) 
                  m.Add(_str_idfsCaseStatus, o.ObjectIdent + _str_idfsCaseStatus, "Int64?", o.idfsCaseStatus == null ? "" : o.idfsCaseStatus.ToString(), o.IsReadOnly(_str_idfsCaseStatus), o.IsInvisible(_str_idfsCaseStatus), o.IsRequired(_str_idfsCaseStatus)); }
              }, 
        
            new field_info {
              _name = _str_idfsCaseProgressStatus, _type = "Int64?",
              _get_func = o => o.idfsCaseProgressStatus,
              _set_func = (o, val) => { o.idfsCaseProgressStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseProgressStatus != c.idfsCaseProgressStatus || o.IsRIRPropChanged(_str_idfsCaseProgressStatus, c)) 
                  m.Add(_str_idfsCaseProgressStatus, o.ObjectIdent + _str_idfsCaseProgressStatus, "Int64?", o.idfsCaseProgressStatus == null ? "" : o.idfsCaseProgressStatus.ToString(), o.IsReadOnly(_str_idfsCaseProgressStatus), o.IsInvisible(_str_idfsCaseProgressStatus), o.IsRequired(_str_idfsCaseProgressStatus)); }
              }, 
        
            new field_info {
              _name = _str_CaseStatusName, _type = "String",
              _get_func = o => o.CaseStatusName,
              _set_func = (o, val) => { o.CaseStatusName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.CaseStatusName != c.CaseStatusName || o.IsRIRPropChanged(_str_CaseStatusName, c)) 
                  m.Add(_str_CaseStatusName, o.ObjectIdent + _str_CaseStatusName, "String", o.CaseStatusName == null ? "" : o.CaseStatusName.ToString(), o.IsReadOnly(_str_CaseStatusName), o.IsInvisible(_str_CaseStatusName), o.IsRequired(_str_CaseStatusName)); }
              }, 
        
            new field_info {
              _name = _str_CaseProgressStatusName, _type = "String",
              _get_func = o => o.CaseProgressStatusName,
              _set_func = (o, val) => { o.CaseProgressStatusName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.CaseProgressStatusName != c.CaseProgressStatusName || o.IsRIRPropChanged(_str_CaseProgressStatusName, c)) 
                  m.Add(_str_CaseProgressStatusName, o.ObjectIdent + _str_CaseProgressStatusName, "String", o.CaseProgressStatusName == null ? "" : o.CaseProgressStatusName.ToString(), o.IsReadOnly(_str_CaseProgressStatusName), o.IsInvisible(_str_CaseProgressStatusName), o.IsRequired(_str_CaseProgressStatusName)); }
              }, 
        
            new field_info {
              _name = _str_datEnteredDate, _type = "DateTime?",
              _get_func = o => o.datEnteredDate,
              _set_func = (o, val) => { o.datEnteredDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datEnteredDate != c.datEnteredDate || o.IsRIRPropChanged(_str_datEnteredDate, c)) 
                  m.Add(_str_datEnteredDate, o.ObjectIdent + _str_datEnteredDate, "DateTime?", o.datEnteredDate == null ? "" : o.datEnteredDate.ToString(), o.IsReadOnly(_str_datEnteredDate), o.IsInvisible(_str_datEnteredDate), o.IsRequired(_str_datEnteredDate)); }
              }, 
        
            new field_info {
              _name = _str_strCaseID, _type = "String",
              _get_func = o => o.strCaseID,
              _set_func = (o, val) => { o.strCaseID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCaseID != c.strCaseID || o.IsRIRPropChanged(_str_strCaseID, c)) 
                  m.Add(_str_strCaseID, o.ObjectIdent + _str_strCaseID, "String", o.strCaseID == null ? "" : o.strCaseID.ToString(), o.IsReadOnly(_str_strCaseID), o.IsInvisible(_str_strCaseID), o.IsRequired(_str_strCaseID)); }
              }, 
        
            new field_info {
              _name = _str_idfsSite, _type = "Int64",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { o.idfsSite = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_idfsSite, c)) 
                  m.Add(_str_idfsSite, o.ObjectIdent + _str_idfsSite, "Int64", o.idfsSite == null ? "" : o.idfsSite.ToString(), o.IsReadOnly(_str_idfsSite), o.IsInvisible(_str_idfsSite), o.IsRequired(_str_idfsSite)); }
              }, 
        
            new field_info {
              _name = _str_datCompletionPaperFormDate, _type = "DateTime?",
              _get_func = o => o.datCompletionPaperFormDate,
              _set_func = (o, val) => { o.datCompletionPaperFormDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datCompletionPaperFormDate != c.datCompletionPaperFormDate || o.IsRIRPropChanged(_str_datCompletionPaperFormDate, c)) 
                  m.Add(_str_datCompletionPaperFormDate, o.ObjectIdent + _str_datCompletionPaperFormDate, "DateTime?", o.datCompletionPaperFormDate == null ? "" : o.datCompletionPaperFormDate.ToString(), o.IsReadOnly(_str_datCompletionPaperFormDate), o.IsInvisible(_str_datCompletionPaperFormDate), o.IsRequired(_str_datCompletionPaperFormDate)); }
              }, 
        
            new field_info {
              _name = _str_strLocalIdentifier, _type = "String",
              _get_func = o => o.strLocalIdentifier,
              _set_func = (o, val) => { o.strLocalIdentifier = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strLocalIdentifier != c.strLocalIdentifier || o.IsRIRPropChanged(_str_strLocalIdentifier, c)) 
                  m.Add(_str_strLocalIdentifier, o.ObjectIdent + _str_strLocalIdentifier, "String", o.strLocalIdentifier == null ? "" : o.strLocalIdentifier.ToString(), o.IsReadOnly(_str_strLocalIdentifier), o.IsInvisible(_str_strLocalIdentifier), o.IsRequired(_str_strLocalIdentifier)); }
              }, 
        
            new field_info {
              _name = _str_idfPersonEnteredBy, _type = "Int64?",
              _get_func = o => o.idfPersonEnteredBy,
              _set_func = (o, val) => { o.idfPersonEnteredBy = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfPersonEnteredBy != c.idfPersonEnteredBy || o.IsRIRPropChanged(_str_idfPersonEnteredBy, c)) 
                  m.Add(_str_idfPersonEnteredBy, o.ObjectIdent + _str_idfPersonEnteredBy, "Int64?", o.idfPersonEnteredBy == null ? "" : o.idfPersonEnteredBy.ToString(), o.IsReadOnly(_str_idfPersonEnteredBy), o.IsInvisible(_str_idfPersonEnteredBy), o.IsRequired(_str_idfPersonEnteredBy)); }
              }, 
        
            new field_info {
              _name = _str_idfHuman, _type = "Int64",
              _get_func = o => o.idfHuman,
              _set_func = (o, val) => { o.idfHuman = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfHuman != c.idfHuman || o.IsRIRPropChanged(_str_idfHuman, c)) 
                  m.Add(_str_idfHuman, o.ObjectIdent + _str_idfHuman, "Int64", o.idfHuman == null ? "" : o.idfHuman.ToString(), o.IsReadOnly(_str_idfHuman), o.IsInvisible(_str_idfHuman), o.IsRequired(_str_idfHuman)); }
              }, 
        
            new field_info {
              _name = _str_strLastName, _type = "String",
              _get_func = o => o.strLastName,
              _set_func = (o, val) => { o.strLastName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strLastName != c.strLastName || o.IsRIRPropChanged(_str_strLastName, c)) 
                  m.Add(_str_strLastName, o.ObjectIdent + _str_strLastName, "String", o.strLastName == null ? "" : o.strLastName.ToString(), o.IsReadOnly(_str_strLastName), o.IsInvisible(_str_strLastName), o.IsRequired(_str_strLastName)); }
              }, 
        
            new field_info {
              _name = _str_strFirstName, _type = "String",
              _get_func = o => o.strFirstName,
              _set_func = (o, val) => { o.strFirstName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFirstName != c.strFirstName || o.IsRIRPropChanged(_str_strFirstName, c)) 
                  m.Add(_str_strFirstName, o.ObjectIdent + _str_strFirstName, "String", o.strFirstName == null ? "" : o.strFirstName.ToString(), o.IsReadOnly(_str_strFirstName), o.IsInvisible(_str_strFirstName), o.IsRequired(_str_strFirstName)); }
              }, 
        
            new field_info {
              _name = _str_strSecondName, _type = "String",
              _get_func = o => o.strSecondName,
              _set_func = (o, val) => { o.strSecondName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSecondName != c.strSecondName || o.IsRIRPropChanged(_str_strSecondName, c)) 
                  m.Add(_str_strSecondName, o.ObjectIdent + _str_strSecondName, "String", o.strSecondName == null ? "" : o.strSecondName.ToString(), o.IsReadOnly(_str_strSecondName), o.IsInvisible(_str_strSecondName), o.IsRequired(_str_strSecondName)); }
              }, 
        
            new field_info {
              _name = _str_PatientName, _type = "String",
              _get_func = o => o.PatientName,
              _set_func = (o, val) => { o.PatientName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.PatientName != c.PatientName || o.IsRIRPropChanged(_str_PatientName, c)) 
                  m.Add(_str_PatientName, o.ObjectIdent + _str_PatientName, "String", o.PatientName == null ? "" : o.PatientName.ToString(), o.IsReadOnly(_str_PatientName), o.IsInvisible(_str_PatientName), o.IsRequired(_str_PatientName)); }
              }, 
        
            new field_info {
              _name = _str_datDateofBirth, _type = "DateTime?",
              _get_func = o => o.datDateofBirth,
              _set_func = (o, val) => { o.datDateofBirth = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datDateofBirth != c.datDateofBirth || o.IsRIRPropChanged(_str_datDateofBirth, c)) 
                  m.Add(_str_datDateofBirth, o.ObjectIdent + _str_datDateofBirth, "DateTime?", o.datDateofBirth == null ? "" : o.datDateofBirth.ToString(), o.IsReadOnly(_str_datDateofBirth), o.IsInvisible(_str_datDateofBirth), o.IsRequired(_str_datDateofBirth)); }
              }, 
        
            new field_info {
              _name = _str_intPatientAge, _type = "Int32?",
              _get_func = o => o.intPatientAge,
              _set_func = (o, val) => { o.intPatientAge = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intPatientAge != c.intPatientAge || o.IsRIRPropChanged(_str_intPatientAge, c)) 
                  m.Add(_str_intPatientAge, o.ObjectIdent + _str_intPatientAge, "Int32?", o.intPatientAge == null ? "" : o.intPatientAge.ToString(), o.IsReadOnly(_str_intPatientAge), o.IsInvisible(_str_intPatientAge), o.IsRequired(_str_intPatientAge)); }
              }, 
        
            new field_info {
              _name = _str_idfsHumanAgeType, _type = "Int64?",
              _get_func = o => o.idfsHumanAgeType,
              _set_func = (o, val) => { o.idfsHumanAgeType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsHumanAgeType != c.idfsHumanAgeType || o.IsRIRPropChanged(_str_idfsHumanAgeType, c)) 
                  m.Add(_str_idfsHumanAgeType, o.ObjectIdent + _str_idfsHumanAgeType, "Int64?", o.idfsHumanAgeType == null ? "" : o.idfsHumanAgeType.ToString(), o.IsReadOnly(_str_idfsHumanAgeType), o.IsInvisible(_str_idfsHumanAgeType), o.IsRequired(_str_idfsHumanAgeType)); }
              }, 
        
            new field_info {
              _name = _str_Age, _type = "String",
              _get_func = o => o.Age,
              _set_func = (o, val) => { o.Age = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.Age != c.Age || o.IsRIRPropChanged(_str_Age, c)) 
                  m.Add(_str_Age, o.ObjectIdent + _str_Age, "String", o.Age == null ? "" : o.Age.ToString(), o.IsReadOnly(_str_Age), o.IsInvisible(_str_Age), o.IsRequired(_str_Age)); }
              }, 
        
            new field_info {
              _name = _str_idfAddress, _type = "Int64?",
              _get_func = o => o.idfAddress,
              _set_func = (o, val) => { o.idfAddress = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfAddress != c.idfAddress || o.IsRIRPropChanged(_str_idfAddress, c)) 
                  m.Add(_str_idfAddress, o.ObjectIdent + _str_idfAddress, "Int64?", o.idfAddress == null ? "" : o.idfAddress.ToString(), o.IsReadOnly(_str_idfAddress), o.IsInvisible(_str_idfAddress), o.IsRequired(_str_idfAddress)); }
              }, 
        
            new field_info {
              _name = _str_idfGeoLocation, _type = "Int64?",
              _get_func = o => o.idfGeoLocation,
              _set_func = (o, val) => { o.idfGeoLocation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfGeoLocation != c.idfGeoLocation || o.IsRIRPropChanged(_str_idfGeoLocation, c)) 
                  m.Add(_str_idfGeoLocation, o.ObjectIdent + _str_idfGeoLocation, "Int64?", o.idfGeoLocation == null ? "" : o.idfGeoLocation.ToString(), o.IsReadOnly(_str_idfGeoLocation), o.IsInvisible(_str_idfGeoLocation), o.IsRequired(_str_idfGeoLocation)); }
              }, 
        
            new field_info {
              _name = _str_GeoLocationName, _type = "String",
              _get_func = o => o.GeoLocationName,
              _set_func = (o, val) => { o.GeoLocationName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.GeoLocationName != c.GeoLocationName || o.IsRIRPropChanged(_str_GeoLocationName, c)) 
                  m.Add(_str_GeoLocationName, o.ObjectIdent + _str_GeoLocationName, "String", o.GeoLocationName == null ? "" : o.GeoLocationName.ToString(), o.IsReadOnly(_str_GeoLocationName), o.IsInvisible(_str_GeoLocationName), o.IsRequired(_str_GeoLocationName)); }
              }, 
        
            new field_info {
              _name = _str_idfEpiObservation, _type = "Int64?",
              _get_func = o => o.idfEpiObservation,
              _set_func = (o, val) => { o.idfEpiObservation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfEpiObservation != c.idfEpiObservation || o.IsRIRPropChanged(_str_idfEpiObservation, c)) 
                  m.Add(_str_idfEpiObservation, o.ObjectIdent + _str_idfEpiObservation, "Int64?", o.idfEpiObservation == null ? "" : o.idfEpiObservation.ToString(), o.IsReadOnly(_str_idfEpiObservation), o.IsInvisible(_str_idfEpiObservation), o.IsRequired(_str_idfEpiObservation)); }
              }, 
        
            new field_info {
              _name = _str_idfCSObservation, _type = "Int64?",
              _get_func = o => o.idfCSObservation,
              _set_func = (o, val) => { o.idfCSObservation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCSObservation != c.idfCSObservation || o.IsRIRPropChanged(_str_idfCSObservation, c)) 
                  m.Add(_str_idfCSObservation, o.ObjectIdent + _str_idfCSObservation, "Int64?", o.idfCSObservation == null ? "" : o.idfCSObservation.ToString(), o.IsReadOnly(_str_idfCSObservation), o.IsInvisible(_str_idfCSObservation), o.IsRequired(_str_idfCSObservation)); }
              }, 
        
            new field_info {
              _name = _str_idfsTentativeDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsTentativeDiagnosis,
              _set_func = (o, val) => { o.idfsTentativeDiagnosis = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTentativeDiagnosis != c.idfsTentativeDiagnosis || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis, c)) 
                  m.Add(_str_idfsTentativeDiagnosis, o.ObjectIdent + _str_idfsTentativeDiagnosis, "Int64?", o.idfsTentativeDiagnosis == null ? "" : o.idfsTentativeDiagnosis.ToString(), o.IsReadOnly(_str_idfsTentativeDiagnosis), o.IsInvisible(_str_idfsTentativeDiagnosis), o.IsRequired(_str_idfsTentativeDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_idfsInitialCaseStatus, _type = "Int64?",
              _get_func = o => o.idfsInitialCaseStatus,
              _set_func = (o, val) => { o.idfsInitialCaseStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsInitialCaseStatus != c.idfsInitialCaseStatus || o.IsRIRPropChanged(_str_idfsInitialCaseStatus, c)) 
                  m.Add(_str_idfsInitialCaseStatus, o.ObjectIdent + _str_idfsInitialCaseStatus, "Int64?", o.idfsInitialCaseStatus == null ? "" : o.idfsInitialCaseStatus.ToString(), o.IsReadOnly(_str_idfsInitialCaseStatus), o.IsInvisible(_str_idfsInitialCaseStatus), o.IsRequired(_str_idfsInitialCaseStatus)); }
              }, 
        
            new field_info {
              _name = _str_idfsSettlement, _type = "Int64?",
              _get_func = o => o.idfsSettlement,
              _set_func = (o, val) => { o.idfsSettlement = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_idfsSettlement, c)) 
                  m.Add(_str_idfsSettlement, o.ObjectIdent + _str_idfsSettlement, "Int64?", o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(), o.IsReadOnly(_str_idfsSettlement), o.IsInvisible(_str_idfsSettlement), o.IsRequired(_str_idfsSettlement)); }
              }, 
        
            new field_info {
              _name = _str_idfsRegion, _type = "Int64?",
              _get_func = o => o.idfsRegion,
              _set_func = (o, val) => { o.idfsRegion = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_idfsRegion, c)) 
                  m.Add(_str_idfsRegion, o.ObjectIdent + _str_idfsRegion, "Int64?", o.idfsRegion == null ? "" : o.idfsRegion.ToString(), o.IsReadOnly(_str_idfsRegion), o.IsInvisible(_str_idfsRegion), o.IsRequired(_str_idfsRegion)); }
              }, 
        
            new field_info {
              _name = _str_idfsRayon, _type = "Int64?",
              _get_func = o => o.idfsRayon,
              _set_func = (o, val) => { o.idfsRayon = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_idfsRayon, c)) 
                  m.Add(_str_idfsRayon, o.ObjectIdent + _str_idfsRayon, "Int64?", o.idfsRayon == null ? "" : o.idfsRayon.ToString(), o.IsReadOnly(_str_idfsRayon), o.IsInvisible(_str_idfsRayon), o.IsRequired(_str_idfsRayon)); }
              }, 
        
            new field_info {
              _name = _str_idfsCountry, _type = "Int64?",
              _get_func = o => o.idfsCountry,
              _set_func = (o, val) => { o.idfsCountry = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_idfsCountry, c)) 
                  m.Add(_str_idfsCountry, o.ObjectIdent + _str_idfsCountry, "Int64?", o.idfsCountry == null ? "" : o.idfsCountry.ToString(), o.IsReadOnly(_str_idfsCountry), o.IsInvisible(_str_idfsCountry), o.IsRequired(_str_idfsCountry)); }
              }, 
        
            new field_info {
              _name = _str_idfsHumanGender, _type = "long?",
              _get_func = o => o.idfsHumanGender,
              _set_func = (o, val) => { o.idfsHumanGender = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfsHumanGender != c.idfsHumanGender || o.IsRIRPropChanged(_str_idfsHumanGender, c)) 
                  m.Add(_str_idfsHumanGender, o.ObjectIdent + _str_idfsHumanGender, "long?", o.idfsHumanGender == null ? "" : o.idfsHumanGender.ToString(), o.IsReadOnly(_str_idfsHumanGender), o.IsInvisible(_str_idfsHumanGender), o.IsRequired(_str_idfsHumanGender));
                 }
              }, 
        
            new field_info {
              _name = _str_idfSentByOffice, _type = "long?",
              _get_func = o => o.idfSentByOffice,
              _set_func = (o, val) => { o.idfSentByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfSentByOffice != c.idfSentByOffice || o.IsRIRPropChanged(_str_idfSentByOffice, c)) 
                  m.Add(_str_idfSentByOffice, o.ObjectIdent + _str_idfSentByOffice, "long?", o.idfSentByOffice == null ? "" : o.idfSentByOffice.ToString(), o.IsReadOnly(_str_idfSentByOffice), o.IsInvisible(_str_idfSentByOffice), o.IsRequired(_str_idfSentByOffice));
                 }
              }, 
        
            new field_info {
              _name = _str_idfReceivedByOffice, _type = "long?",
              _get_func = o => o.idfReceivedByOffice,
              _set_func = (o, val) => { o.idfReceivedByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfReceivedByOffice != c.idfReceivedByOffice || o.IsRIRPropChanged(_str_idfReceivedByOffice, c)) 
                  m.Add(_str_idfReceivedByOffice, o.ObjectIdent + _str_idfReceivedByOffice, "long?", o.idfReceivedByOffice == null ? "" : o.idfReceivedByOffice.ToString(), o.IsReadOnly(_str_idfReceivedByOffice), o.IsInvisible(_str_idfReceivedByOffice), o.IsRequired(_str_idfReceivedByOffice));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsNationality, _type = "long?",
              _get_func = o => o.idfsNationality,
              _set_func = (o, val) => { o.idfsNationality = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfsNationality != c.idfsNationality || o.IsRIRPropChanged(_str_idfsNationality, c)) 
                  m.Add(_str_idfsNationality, o.ObjectIdent + _str_idfsNationality, "long?", o.idfsNationality == null ? "" : o.idfsNationality.ToString(), o.IsReadOnly(_str_idfsNationality), o.IsInvisible(_str_idfsNationality), o.IsRequired(_str_idfsNationality));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsFinalState, _type = "long?",
              _get_func = o => o.idfsFinalState,
              _set_func = (o, val) => { o.idfsFinalState = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfsFinalState != c.idfsFinalState || o.IsRIRPropChanged(_str_idfsFinalState, c)) 
                  m.Add(_str_idfsFinalState, o.ObjectIdent + _str_idfsFinalState, "long?", o.idfsFinalState == null ? "" : o.idfsFinalState.ToString(), o.IsReadOnly(_str_idfsFinalState), o.IsInvisible(_str_idfsFinalState), o.IsRequired(_str_idfsFinalState));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsHospitalizationStatus, _type = "long?",
              _get_func = o => o.idfsHospitalizationStatus,
              _set_func = (o, val) => { o.idfsHospitalizationStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfsHospitalizationStatus != c.idfsHospitalizationStatus || o.IsRIRPropChanged(_str_idfsHospitalizationStatus, c)) 
                  m.Add(_str_idfsHospitalizationStatus, o.ObjectIdent + _str_idfsHospitalizationStatus, "long?", o.idfsHospitalizationStatus == null ? "" : o.idfsHospitalizationStatus.ToString(), o.IsReadOnly(_str_idfsHospitalizationStatus), o.IsInvisible(_str_idfsHospitalizationStatus), o.IsRequired(_str_idfsHospitalizationStatus));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsFinalDiagnosis, _type = "long?",
              _get_func = o => o.idfsFinalDiagnosis,
              _set_func = (o, val) => { o.idfsFinalDiagnosis = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfsFinalDiagnosis != c.idfsFinalDiagnosis || o.IsRIRPropChanged(_str_idfsFinalDiagnosis, c)) 
                  m.Add(_str_idfsFinalDiagnosis, o.ObjectIdent + _str_idfsFinalDiagnosis, "long?", o.idfsFinalDiagnosis == null ? "" : o.idfsFinalDiagnosis.ToString(), o.IsReadOnly(_str_idfsFinalDiagnosis), o.IsInvisible(_str_idfsFinalDiagnosis), o.IsRequired(_str_idfsFinalDiagnosis));
                 }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnosis, c)) 
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis)); }
              }, 
        
            new field_info {
              _name = _str_TentativeDiagnosis, _type = "Lookup",
              _get_func = o => { if (o.TentativeDiagnosis == null) return null; return o.TentativeDiagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.TentativeDiagnosis = o.TentativeDiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTentativeDiagnosis != c.idfsTentativeDiagnosis || o.IsRIRPropChanged(_str_TentativeDiagnosis, c)) 
                  m.Add(_str_TentativeDiagnosis, o.ObjectIdent + _str_TentativeDiagnosis, "Lookup", o.idfsTentativeDiagnosis == null ? "" : o.idfsTentativeDiagnosis.ToString(), o.IsReadOnly(_str_TentativeDiagnosis), o.IsInvisible(_str_TentativeDiagnosis), o.IsRequired(_str_TentativeDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_FinalDiagnosis, _type = "Lookup",
              _get_func = o => { if (o.FinalDiagnosis == null) return null; return o.FinalDiagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.FinalDiagnosis = o.FinalDiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsFinalDiagnosis != c.idfsFinalDiagnosis || o.IsRIRPropChanged(_str_FinalDiagnosis, c)) 
                  m.Add(_str_FinalDiagnosis, o.ObjectIdent + _str_FinalDiagnosis, "Lookup", o.idfsFinalDiagnosis == null ? "" : o.idfsFinalDiagnosis.ToString(), o.IsReadOnly(_str_FinalDiagnosis), o.IsInvisible(_str_FinalDiagnosis), o.IsRequired(_str_FinalDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_CaseStatus, _type = "Lookup",
              _get_func = o => { if (o.CaseStatus == null) return null; return o.CaseStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.CaseStatus = o.CaseStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseStatus != c.idfsCaseStatus || o.IsRIRPropChanged(_str_CaseStatus, c)) 
                  m.Add(_str_CaseStatus, o.ObjectIdent + _str_CaseStatus, "Lookup", o.idfsCaseStatus == null ? "" : o.idfsCaseStatus.ToString(), o.IsReadOnly(_str_CaseStatus), o.IsInvisible(_str_CaseStatus), o.IsRequired(_str_CaseStatus)); }
              }, 
        
            new field_info {
              _name = _str_CaseProgressStatus, _type = "Lookup",
              _get_func = o => { if (o.CaseProgressStatus == null) return null; return o.CaseProgressStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.CaseProgressStatus = o.CaseProgressStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseProgressStatus != c.idfsCaseProgressStatus || o.IsRIRPropChanged(_str_CaseProgressStatus, c)) 
                  m.Add(_str_CaseProgressStatus, o.ObjectIdent + _str_CaseProgressStatus, "Lookup", o.idfsCaseProgressStatus == null ? "" : o.idfsCaseProgressStatus.ToString(), o.IsReadOnly(_str_CaseProgressStatus), o.IsInvisible(_str_CaseProgressStatus), o.IsRequired(_str_CaseProgressStatus)); }
              }, 
        
            new field_info {
              _name = _str_HumanAgeType, _type = "Lookup",
              _get_func = o => { if (o.HumanAgeType == null) return null; return o.HumanAgeType.idfsBaseReference; },
              _set_func = (o, val) => { o.HumanAgeType = o.HumanAgeTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsHumanAgeType != c.idfsHumanAgeType || o.IsRIRPropChanged(_str_HumanAgeType, c)) 
                  m.Add(_str_HumanAgeType, o.ObjectIdent + _str_HumanAgeType, "Lookup", o.idfsHumanAgeType == null ? "" : o.idfsHumanAgeType.ToString(), o.IsReadOnly(_str_HumanAgeType), o.IsInvisible(_str_HumanAgeType), o.IsRequired(_str_HumanAgeType)); }
              }, 
        
            new field_info {
              _name = _str_Country, _type = "Lookup",
              _get_func = o => { if (o.Country == null) return null; return o.Country.idfsCountry; },
              _set_func = (o, val) => { o.Country = o.CountryLookup.Where(c => c.idfsCountry.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_Country, c)) 
                  m.Add(_str_Country, o.ObjectIdent + _str_Country, "Lookup", o.idfsCountry == null ? "" : o.idfsCountry.ToString(), o.IsReadOnly(_str_Country), o.IsInvisible(_str_Country), o.IsRequired(_str_Country)); }
              }, 
        
            new field_info {
              _name = _str_Region, _type = "Lookup",
              _get_func = o => { if (o.Region == null) return null; return o.Region.idfsRegion; },
              _set_func = (o, val) => { o.Region = o.RegionLookup.Where(c => c.idfsRegion.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_Region, c)) 
                  m.Add(_str_Region, o.ObjectIdent + _str_Region, "Lookup", o.idfsRegion == null ? "" : o.idfsRegion.ToString(), o.IsReadOnly(_str_Region), o.IsInvisible(_str_Region), o.IsRequired(_str_Region)); }
              }, 
        
            new field_info {
              _name = _str_Rayon, _type = "Lookup",
              _get_func = o => { if (o.Rayon == null) return null; return o.Rayon.idfsRayon; },
              _set_func = (o, val) => { o.Rayon = o.RayonLookup.Where(c => c.idfsRayon.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_Rayon, c)) 
                  m.Add(_str_Rayon, o.ObjectIdent + _str_Rayon, "Lookup", o.idfsRayon == null ? "" : o.idfsRayon.ToString(), o.IsReadOnly(_str_Rayon), o.IsInvisible(_str_Rayon), o.IsRequired(_str_Rayon)); }
              }, 
        
            new field_info {
              _name = _str_Settlement, _type = "Lookup",
              _get_func = o => { if (o.Settlement == null) return null; return o.Settlement.idfsSettlement; },
              _set_func = (o, val) => { o.Settlement = o.SettlementLookup.Where(c => c.idfsSettlement.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_Settlement, c)) 
                  m.Add(_str_Settlement, o.ObjectIdent + _str_Settlement, "Lookup", o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(), o.IsReadOnly(_str_Settlement), o.IsInvisible(_str_Settlement), o.IsRequired(_str_Settlement)); }
              }, 
        
            new field_info {
              _name = _str_HumanGender, _type = "Lookup",
              _get_func = o => { if (o.HumanGender == null) return null; return o.HumanGender.idfsBaseReference; },
              _set_func = (o, val) => { o.HumanGender = o.HumanGenderLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsHumanGender != c.idfsHumanGender || o.IsRIRPropChanged(_str_HumanGender, c)) 
                  m.Add(_str_HumanGender, o.ObjectIdent + _str_HumanGender, "Lookup", o.idfsHumanGender == null ? "" : o.idfsHumanGender.ToString(), o.IsReadOnly(_str_HumanGender), o.IsInvisible(_str_HumanGender), o.IsRequired(_str_HumanGender)); }
              }, 
        
            new field_info {
              _name = _str_SentByOffice, _type = "Lookup",
              _get_func = o => { if (o.SentByOffice == null) return null; return o.SentByOffice.idfInstitution; },
              _set_func = (o, val) => { o.SentByOffice = o.SentByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfSentByOffice != c.idfSentByOffice || o.IsRIRPropChanged(_str_SentByOffice, c)) 
                  m.Add(_str_SentByOffice, o.ObjectIdent + _str_SentByOffice, "Lookup", o.idfSentByOffice == null ? "" : o.idfSentByOffice.ToString(), o.IsReadOnly(_str_SentByOffice), o.IsInvisible(_str_SentByOffice), o.IsRequired(_str_SentByOffice)); }
              }, 
        
            new field_info {
              _name = _str_ReceivedByOffice, _type = "Lookup",
              _get_func = o => { if (o.ReceivedByOffice == null) return null; return o.ReceivedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.ReceivedByOffice = o.ReceivedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfReceivedByOffice != c.idfReceivedByOffice || o.IsRIRPropChanged(_str_ReceivedByOffice, c)) 
                  m.Add(_str_ReceivedByOffice, o.ObjectIdent + _str_ReceivedByOffice, "Lookup", o.idfReceivedByOffice == null ? "" : o.idfReceivedByOffice.ToString(), o.IsReadOnly(_str_ReceivedByOffice), o.IsInvisible(_str_ReceivedByOffice), o.IsRequired(_str_ReceivedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_Nationality, _type = "Lookup",
              _get_func = o => { if (o.Nationality == null) return null; return o.Nationality.idfsBaseReference; },
              _set_func = (o, val) => { o.Nationality = o.NationalityLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsNationality != c.idfsNationality || o.IsRIRPropChanged(_str_Nationality, c)) 
                  m.Add(_str_Nationality, o.ObjectIdent + _str_Nationality, "Lookup", o.idfsNationality == null ? "" : o.idfsNationality.ToString(), o.IsReadOnly(_str_Nationality), o.IsInvisible(_str_Nationality), o.IsRequired(_str_Nationality)); }
              }, 
        
            new field_info {
              _name = _str_PatientState, _type = "Lookup",
              _get_func = o => { if (o.PatientState == null) return null; return o.PatientState.idfsBaseReference; },
              _set_func = (o, val) => { o.PatientState = o.PatientStateLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsFinalState != c.idfsFinalState || o.IsRIRPropChanged(_str_PatientState, c)) 
                  m.Add(_str_PatientState, o.ObjectIdent + _str_PatientState, "Lookup", o.idfsFinalState == null ? "" : o.idfsFinalState.ToString(), o.IsReadOnly(_str_PatientState), o.IsInvisible(_str_PatientState), o.IsRequired(_str_PatientState)); }
              }, 
        
            new field_info {
              _name = _str_PatientLocationType, _type = "Lookup",
              _get_func = o => { if (o.PatientLocationType == null) return null; return o.PatientLocationType.idfsBaseReference; },
              _set_func = (o, val) => { o.PatientLocationType = o.PatientLocationTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsHospitalizationStatus != c.idfsHospitalizationStatus || o.IsRIRPropChanged(_str_PatientLocationType, c)) 
                  m.Add(_str_PatientLocationType, o.ObjectIdent + _str_PatientLocationType, "Lookup", o.idfsHospitalizationStatus == null ? "" : o.idfsHospitalizationStatus.ToString(), o.IsReadOnly(_str_PatientLocationType), o.IsInvisible(_str_PatientLocationType), o.IsRequired(_str_PatientLocationType)); }
              }, 
        
            new field_info {
              _name = _str_InitialCaseStatus, _type = "Lookup",
              _get_func = o => { if (o.InitialCaseStatus == null) return null; return o.InitialCaseStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.InitialCaseStatus = o.InitialCaseStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsInitialCaseStatus != c.idfsInitialCaseStatus || o.IsRIRPropChanged(_str_InitialCaseStatus, c)) 
                  m.Add(_str_InitialCaseStatus, o.ObjectIdent + _str_InitialCaseStatus, "Lookup", o.idfsInitialCaseStatus == null ? "" : o.idfsInitialCaseStatus.ToString(), o.IsReadOnly(_str_InitialCaseStatus), o.IsInvisible(_str_InitialCaseStatus), o.IsRequired(_str_InitialCaseStatus)); }
              }, 
        
            new field_info()
        };
        #endregion
        
        private string _getType(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? "" : i._type;
        }
        private object _getValue(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? null : i._get_func(this);
        }
        private void _setValue(string name, string val)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            if (i != null) i._set_func(this, val);
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            HumanCaseListItem obj = (HumanCaseListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis; }
            set 
            { 
                _Diagnosis = value;
                idfsDiagnosis = _Diagnosis == null 
                    ? new Int64?()
                    : _Diagnosis.idfsDiagnosis; 
                OnPropertyChanged(_str_Diagnosis); 
            }
        }
        private DiagnosisLookup _Diagnosis;

        
        public List<DiagnosisLookup> DiagnosisLookup
        {
            get { return _DiagnosisLookup; }
        }
        private List<DiagnosisLookup> _DiagnosisLookup = new List<DiagnosisLookup>();
            
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsTentativeDiagnosis)]
        public DiagnosisLookup TentativeDiagnosis
        {
            get { return _TentativeDiagnosis == null ? null : ((long)_TentativeDiagnosis.Key == 0 ? null : _TentativeDiagnosis); }
            set 
            { 
                _TentativeDiagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsTentativeDiagnosis = _TentativeDiagnosis == null 
                    ? new Int64?()
                    : _TentativeDiagnosis.idfsDiagnosis; 
                OnPropertyChanged(_str_TentativeDiagnosis); 
            }
        }
        private DiagnosisLookup _TentativeDiagnosis;

        
        public List<DiagnosisLookup> TentativeDiagnosisLookup
        {
            get { return _TentativeDiagnosisLookup; }
        }
        private List<DiagnosisLookup> _TentativeDiagnosisLookup = new List<DiagnosisLookup>();
            
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsFinalDiagnosis)]
        public DiagnosisLookup FinalDiagnosis
        {
            get { return _FinalDiagnosis == null ? null : ((long)_FinalDiagnosis.Key == 0 ? null : _FinalDiagnosis); }
            set 
            { 
                _FinalDiagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsFinalDiagnosis = _FinalDiagnosis == null 
                    ? new long?()
                    : _FinalDiagnosis.idfsDiagnosis; 
                OnPropertyChanged(_str_FinalDiagnosis); 
            }
        }
        private DiagnosisLookup _FinalDiagnosis;

        
        public List<DiagnosisLookup> FinalDiagnosisLookup
        {
            get { return _FinalDiagnosisLookup; }
        }
        private List<DiagnosisLookup> _FinalDiagnosisLookup = new List<DiagnosisLookup>();
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCaseStatus)]
        public BaseReference CaseStatus
        {
            get { return _CaseStatus == null ? null : ((long)_CaseStatus.Key == 0 ? null : _CaseStatus); }
            set 
            { 
                _CaseStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsCaseStatus = _CaseStatus == null 
                    ? new Int64?()
                    : _CaseStatus.idfsBaseReference; 
                OnPropertyChanged(_str_CaseStatus); 
            }
        }
        private BaseReference _CaseStatus;

        
        public BaseReferenceList CaseStatusLookup
        {
            get { return _CaseStatusLookup; }
        }
        private BaseReferenceList _CaseStatusLookup = new BaseReferenceList("rftCaseStatus");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCaseProgressStatus)]
        public BaseReference CaseProgressStatus
        {
            get { return _CaseProgressStatus == null ? null : ((long)_CaseProgressStatus.Key == 0 ? null : _CaseProgressStatus); }
            set 
            { 
                _CaseProgressStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsCaseProgressStatus = _CaseProgressStatus == null 
                    ? new Int64?()
                    : _CaseProgressStatus.idfsBaseReference; 
                OnPropertyChanged(_str_CaseProgressStatus); 
            }
        }
        private BaseReference _CaseProgressStatus;

        
        public BaseReferenceList CaseProgressStatusLookup
        {
            get { return _CaseProgressStatusLookup; }
        }
        private BaseReferenceList _CaseProgressStatusLookup = new BaseReferenceList("rftCaseProgressStatus");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsHumanAgeType)]
        public BaseReference HumanAgeType
        {
            get { return _HumanAgeType == null ? null : ((long)_HumanAgeType.Key == 0 ? null : _HumanAgeType); }
            set 
            { 
                _HumanAgeType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsHumanAgeType = _HumanAgeType == null 
                    ? new Int64?()
                    : _HumanAgeType.idfsBaseReference; 
                OnPropertyChanged(_str_HumanAgeType); 
            }
        }
        private BaseReference _HumanAgeType;

        
        public BaseReferenceList HumanAgeTypeLookup
        {
            get { return _HumanAgeTypeLookup; }
        }
        private BaseReferenceList _HumanAgeTypeLookup = new BaseReferenceList("rftHumanAgeType");
            
        [Relation(typeof(CountryLookup), eidss.model.Schema.CountryLookup._str_idfsCountry, _str_idfsCountry)]
        public CountryLookup Country
        {
            get { return _Country == null ? null : ((long)_Country.Key == 0 ? null : _Country); }
            set 
            { 
                _Country = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsCountry = _Country == null 
                    ? new Int64?()
                    : _Country.idfsCountry; 
                OnPropertyChanged(_str_Country); 
            }
        }
        private CountryLookup _Country;

        
        public List<CountryLookup> CountryLookup
        {
            get { return _CountryLookup; }
        }
        private List<CountryLookup> _CountryLookup = new List<CountryLookup>();
            
        [Relation(typeof(RegionLookup), eidss.model.Schema.RegionLookup._str_idfsRegion, _str_idfsRegion)]
        public RegionLookup Region
        {
            get { return _Region == null ? null : ((long)_Region.Key == 0 ? null : _Region); }
            set 
            { 
                _Region = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsRegion = _Region == null 
                    ? new Int64?()
                    : _Region.idfsRegion; 
                OnPropertyChanged(_str_Region); 
            }
        }
        private RegionLookup _Region;

        
        public List<RegionLookup> RegionLookup
        {
            get { return _RegionLookup; }
        }
        private List<RegionLookup> _RegionLookup = new List<RegionLookup>();
            
        [Relation(typeof(RayonLookup), eidss.model.Schema.RayonLookup._str_idfsRayon, _str_idfsRayon)]
        public RayonLookup Rayon
        {
            get { return _Rayon == null ? null : ((long)_Rayon.Key == 0 ? null : _Rayon); }
            set 
            { 
                _Rayon = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsRayon = _Rayon == null 
                    ? new Int64?()
                    : _Rayon.idfsRayon; 
                OnPropertyChanged(_str_Rayon); 
            }
        }
        private RayonLookup _Rayon;

        
        public List<RayonLookup> RayonLookup
        {
            get { return _RayonLookup; }
        }
        private List<RayonLookup> _RayonLookup = new List<RayonLookup>();
            
        [Relation(typeof(SettlementLookup), eidss.model.Schema.SettlementLookup._str_idfsSettlement, _str_idfsSettlement)]
        public SettlementLookup Settlement
        {
            get { return _Settlement == null ? null : ((long)_Settlement.Key == 0 ? null : _Settlement); }
            set 
            { 
                _Settlement = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsSettlement = _Settlement == null 
                    ? new Int64?()
                    : _Settlement.idfsSettlement; 
                OnPropertyChanged(_str_Settlement); 
            }
        }
        private SettlementLookup _Settlement;

        
        public List<SettlementLookup> SettlementLookup
        {
            get { return _SettlementLookup; }
        }
        private List<SettlementLookup> _SettlementLookup = new List<SettlementLookup>();
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsHumanGender)]
        public BaseReference HumanGender
        {
            get { return _HumanGender == null ? null : ((long)_HumanGender.Key == 0 ? null : _HumanGender); }
            set 
            { 
                _HumanGender = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsHumanGender = _HumanGender == null 
                    ? new long?()
                    : _HumanGender.idfsBaseReference; 
                OnPropertyChanged(_str_HumanGender); 
            }
        }
        private BaseReference _HumanGender;

        
        public BaseReferenceList HumanGenderLookup
        {
            get { return _HumanGenderLookup; }
        }
        private BaseReferenceList _HumanGenderLookup = new BaseReferenceList("rftHumanGender");
            
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfSentByOffice)]
        public OrganizationLookup SentByOffice
        {
            get { return _SentByOffice == null ? null : ((long)_SentByOffice.Key == 0 ? null : _SentByOffice); }
            set 
            { 
                _SentByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfSentByOffice = _SentByOffice == null 
                    ? new long?()
                    : _SentByOffice.idfInstitution; 
                OnPropertyChanged(_str_SentByOffice); 
            }
        }
        private OrganizationLookup _SentByOffice;

        
        public List<OrganizationLookup> SentByOfficeLookup
        {
            get { return _SentByOfficeLookup; }
        }
        private List<OrganizationLookup> _SentByOfficeLookup = new List<OrganizationLookup>();
            
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfReceivedByOffice)]
        public OrganizationLookup ReceivedByOffice
        {
            get { return _ReceivedByOffice == null ? null : ((long)_ReceivedByOffice.Key == 0 ? null : _ReceivedByOffice); }
            set 
            { 
                _ReceivedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfReceivedByOffice = _ReceivedByOffice == null 
                    ? new long?()
                    : _ReceivedByOffice.idfInstitution; 
                OnPropertyChanged(_str_ReceivedByOffice); 
            }
        }
        private OrganizationLookup _ReceivedByOffice;

        
        public List<OrganizationLookup> ReceivedByOfficeLookup
        {
            get { return _ReceivedByOfficeLookup; }
        }
        private List<OrganizationLookup> _ReceivedByOfficeLookup = new List<OrganizationLookup>();
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsNationality)]
        public BaseReference Nationality
        {
            get { return _Nationality == null ? null : ((long)_Nationality.Key == 0 ? null : _Nationality); }
            set 
            { 
                _Nationality = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsNationality = _Nationality == null 
                    ? new long?()
                    : _Nationality.idfsBaseReference; 
                OnPropertyChanged(_str_Nationality); 
            }
        }
        private BaseReference _Nationality;

        
        public BaseReferenceList NationalityLookup
        {
            get { return _NationalityLookup; }
        }
        private BaseReferenceList _NationalityLookup = new BaseReferenceList("rftNationality");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsFinalState)]
        public BaseReference PatientState
        {
            get { return _PatientState == null ? null : ((long)_PatientState.Key == 0 ? null : _PatientState); }
            set 
            { 
                _PatientState = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsFinalState = _PatientState == null 
                    ? new long?()
                    : _PatientState.idfsBaseReference; 
                OnPropertyChanged(_str_PatientState); 
            }
        }
        private BaseReference _PatientState;

        
        public BaseReferenceList PatientStateLookup
        {
            get { return _PatientStateLookup; }
        }
        private BaseReferenceList _PatientStateLookup = new BaseReferenceList("rftFinalState");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsHospitalizationStatus)]
        public BaseReference PatientLocationType
        {
            get { return _PatientLocationType == null ? null : ((long)_PatientLocationType.Key == 0 ? null : _PatientLocationType); }
            set 
            { 
                _PatientLocationType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsHospitalizationStatus = _PatientLocationType == null 
                    ? new long?()
                    : _PatientLocationType.idfsBaseReference; 
                OnPropertyChanged(_str_PatientLocationType); 
            }
        }
        private BaseReference _PatientLocationType;

        
        public BaseReferenceList PatientLocationTypeLookup
        {
            get { return _PatientLocationTypeLookup; }
        }
        private BaseReferenceList _PatientLocationTypeLookup = new BaseReferenceList("rftHospStatus");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsInitialCaseStatus)]
        public BaseReference InitialCaseStatus
        {
            get { return _InitialCaseStatus == null ? null : ((long)_InitialCaseStatus.Key == 0 ? null : _InitialCaseStatus); }
            set 
            { 
                _InitialCaseStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsInitialCaseStatus = _InitialCaseStatus == null 
                    ? new Int64?()
                    : _InitialCaseStatus.idfsBaseReference; 
                OnPropertyChanged(_str_InitialCaseStatus); 
            }
        }
        private BaseReference _InitialCaseStatus;

        
        public BaseReferenceList InitialCaseStatusLookup
        {
            get { return _InitialCaseStatusLookup; }
        }
        private BaseReferenceList _InitialCaseStatusLookup = new BaseReferenceList("rftCaseStatus");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_TentativeDiagnosis:
                    return new BvSelectList(TentativeDiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, TentativeDiagnosis, _str_idfsTentativeDiagnosis);
            
                case _str_FinalDiagnosis:
                    return new BvSelectList(FinalDiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, FinalDiagnosis, _str_idfsFinalDiagnosis);
            
                case _str_CaseStatus:
                    return new BvSelectList(CaseStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CaseStatus, _str_idfsCaseStatus);
            
                case _str_CaseProgressStatus:
                    return new BvSelectList(CaseProgressStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CaseProgressStatus, _str_idfsCaseProgressStatus);
            
                case _str_HumanAgeType:
                    return new BvSelectList(HumanAgeTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, HumanAgeType, _str_idfsHumanAgeType);
            
                case _str_Country:
                    return new BvSelectList(CountryLookup, eidss.model.Schema.CountryLookup._str_idfsCountry, null, Country, _str_idfsCountry);
            
                case _str_Region:
                    return new BvSelectList(RegionLookup, eidss.model.Schema.RegionLookup._str_idfsRegion, null, Region, _str_idfsRegion);
            
                case _str_Rayon:
                    return new BvSelectList(RayonLookup, eidss.model.Schema.RayonLookup._str_idfsRayon, null, Rayon, _str_idfsRayon);
            
                case _str_Settlement:
                    return new BvSelectList(SettlementLookup, eidss.model.Schema.SettlementLookup._str_idfsSettlement, null, Settlement, _str_idfsSettlement);
            
                case _str_HumanGender:
                    return new BvSelectList(HumanGenderLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, HumanGender, _str_idfsHumanGender);
            
                case _str_SentByOffice:
                    return new BvSelectList(SentByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, SentByOffice, _str_idfSentByOffice);
            
                case _str_ReceivedByOffice:
                    return new BvSelectList(ReceivedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, ReceivedByOffice, _str_idfReceivedByOffice);
            
                case _str_Nationality:
                    return new BvSelectList(NationalityLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Nationality, _str_idfsNationality);
            
                case _str_PatientState:
                    return new BvSelectList(PatientStateLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, PatientState, _str_idfsFinalState);
            
                case _str_PatientLocationType:
                    return new BvSelectList(PatientLocationTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, PatientLocationType, _str_idfsHospitalizationStatus);
            
                case _str_InitialCaseStatus:
                    return new BvSelectList(InitialCaseStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, InitialCaseStatus, _str_idfsInitialCaseStatus);
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str_idfsHumanGender)]
        public long? idfsHumanGender
        {
            get { return m_idfsHumanGender; }
            set { if (m_idfsHumanGender != value) { m_idfsHumanGender = value; OnPropertyChanged(_str_idfsHumanGender); } }
        }
        private long? m_idfsHumanGender;
        
          [LocalizedDisplayName(_str_idfSentByOffice)]
        public long? idfSentByOffice
        {
            get { return m_idfSentByOffice; }
            set { if (m_idfSentByOffice != value) { m_idfSentByOffice = value; OnPropertyChanged(_str_idfSentByOffice); } }
        }
        private long? m_idfSentByOffice;
        
          [LocalizedDisplayName(_str_idfReceivedByOffice)]
        public long? idfReceivedByOffice
        {
            get { return m_idfReceivedByOffice; }
            set { if (m_idfReceivedByOffice != value) { m_idfReceivedByOffice = value; OnPropertyChanged(_str_idfReceivedByOffice); } }
        }
        private long? m_idfReceivedByOffice;
        
          [LocalizedDisplayName(_str_idfsNationality)]
        public long? idfsNationality
        {
            get { return m_idfsNationality; }
            set { if (m_idfsNationality != value) { m_idfsNationality = value; OnPropertyChanged(_str_idfsNationality); } }
        }
        private long? m_idfsNationality;
        
          [LocalizedDisplayName(_str_idfsFinalState)]
        public long? idfsFinalState
        {
            get { return m_idfsFinalState; }
            set { if (m_idfsFinalState != value) { m_idfsFinalState = value; OnPropertyChanged(_str_idfsFinalState); } }
        }
        private long? m_idfsFinalState;
        
          [LocalizedDisplayName(_str_idfsHospitalizationStatus)]
        public long? idfsHospitalizationStatus
        {
            get { return m_idfsHospitalizationStatus; }
            set { if (m_idfsHospitalizationStatus != value) { m_idfsHospitalizationStatus = value; OnPropertyChanged(_str_idfsHospitalizationStatus); } }
        }
        private long? m_idfsHospitalizationStatus;
        
          [LocalizedDisplayName(_str_idfsFinalDiagnosis)]
        public long? idfsFinalDiagnosis
        {
            get { return m_idfsFinalDiagnosis; }
            set { if (m_idfsFinalDiagnosis != value) { m_idfsFinalDiagnosis = value; OnPropertyChanged(_str_idfsFinalDiagnosis); } }
        }
        private long? m_idfsFinalDiagnosis;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "HumanCaseListItem";

        #region Parent and Clone supporting
        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; /*OnPropertyChanged(_str_Parent);*/ }
        }
        private IObject m_Parent;
        internal void _setParent()
        {
        
        }
        public override object Clone()
        {
            var ret = base.Clone() as HumanCaseListItem;
            ret.m_Parent = this.Parent;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager)
        {
            var ret = base.Clone() as HumanCaseListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public HumanCaseListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as HumanCaseListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfCase; } }
        public string KeyName { get { return "idfCase"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfsTentativeDiagnosis_TentativeDiagnosis = idfsTentativeDiagnosis;
            var _prev_idfsFinalDiagnosis_FinalDiagnosis = idfsFinalDiagnosis;
            var _prev_idfsCaseStatus_CaseStatus = idfsCaseStatus;
            var _prev_idfsCaseProgressStatus_CaseProgressStatus = idfsCaseProgressStatus;
            var _prev_idfsHumanAgeType_HumanAgeType = idfsHumanAgeType;
            var _prev_idfsCountry_Country = idfsCountry;
            var _prev_idfsRegion_Region = idfsRegion;
            var _prev_idfsRayon_Rayon = idfsRayon;
            var _prev_idfsSettlement_Settlement = idfsSettlement;
            var _prev_idfsHumanGender_HumanGender = idfsHumanGender;
            var _prev_idfSentByOffice_SentByOffice = idfSentByOffice;
            var _prev_idfReceivedByOffice_ReceivedByOffice = idfReceivedByOffice;
            var _prev_idfsNationality_Nationality = idfsNationality;
            var _prev_idfsFinalState_PatientState = idfsFinalState;
            var _prev_idfsHospitalizationStatus_PatientLocationType = idfsHospitalizationStatus;
            var _prev_idfsInitialCaseStatus_InitialCaseStatus = idfsInitialCaseStatus;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsTentativeDiagnosis_TentativeDiagnosis != idfsTentativeDiagnosis)
            {
                _TentativeDiagnosis = _TentativeDiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsTentativeDiagnosis);
            }
            if (_prev_idfsFinalDiagnosis_FinalDiagnosis != idfsFinalDiagnosis)
            {
                _FinalDiagnosis = _FinalDiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsFinalDiagnosis);
            }
            if (_prev_idfsCaseStatus_CaseStatus != idfsCaseStatus)
            {
                _CaseStatus = _CaseStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCaseStatus);
            }
            if (_prev_idfsCaseProgressStatus_CaseProgressStatus != idfsCaseProgressStatus)
            {
                _CaseProgressStatus = _CaseProgressStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCaseProgressStatus);
            }
            if (_prev_idfsHumanAgeType_HumanAgeType != idfsHumanAgeType)
            {
                _HumanAgeType = _HumanAgeTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsHumanAgeType);
            }
            if (_prev_idfsCountry_Country != idfsCountry)
            {
                _Country = _CountryLookup.FirstOrDefault(c => c.idfsCountry == idfsCountry);
            }
            if (_prev_idfsRegion_Region != idfsRegion)
            {
                _Region = _RegionLookup.FirstOrDefault(c => c.idfsRegion == idfsRegion);
            }
            if (_prev_idfsRayon_Rayon != idfsRayon)
            {
                _Rayon = _RayonLookup.FirstOrDefault(c => c.idfsRayon == idfsRayon);
            }
            if (_prev_idfsSettlement_Settlement != idfsSettlement)
            {
                _Settlement = _SettlementLookup.FirstOrDefault(c => c.idfsSettlement == idfsSettlement);
            }
            if (_prev_idfsHumanGender_HumanGender != idfsHumanGender)
            {
                _HumanGender = _HumanGenderLookup.FirstOrDefault(c => c.idfsBaseReference == idfsHumanGender);
            }
            if (_prev_idfSentByOffice_SentByOffice != idfSentByOffice)
            {
                _SentByOffice = _SentByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfSentByOffice);
            }
            if (_prev_idfReceivedByOffice_ReceivedByOffice != idfReceivedByOffice)
            {
                _ReceivedByOffice = _ReceivedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfReceivedByOffice);
            }
            if (_prev_idfsNationality_Nationality != idfsNationality)
            {
                _Nationality = _NationalityLookup.FirstOrDefault(c => c.idfsBaseReference == idfsNationality);
            }
            if (_prev_idfsFinalState_PatientState != idfsFinalState)
            {
                _PatientState = _PatientStateLookup.FirstOrDefault(c => c.idfsBaseReference == idfsFinalState);
            }
            if (_prev_idfsHospitalizationStatus_PatientLocationType != idfsHospitalizationStatus)
            {
                _PatientLocationType = _PatientLocationTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsHospitalizationStatus);
            }
            if (_prev_idfsInitialCaseStatus_InitialCaseStatus != idfsInitialCaseStatus)
            {
                _InitialCaseStatus = _InitialCaseStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsInitialCaseStatus);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
      public IObjectAccessor GetAccessor() { return _getAccessor(); }
      public IObjectPermissions GetPermissions() { return _permissions; }
      public bool ReadOnly { get { return _readOnly; } set { _readOnly = value; } }
      public bool IsReadOnly(string name) { return _isReadOnly(name); }
      public bool IsInvisible(string name) { return _isInvisible(name); }
      public bool IsRequired(string name) { return _isRequired(name); }
      public bool IsHiddenPersonalData(string name) { return _isHiddenPersonalData(name); }
      public string GetType(string name) { return _getType(name); }
      public object GetValue(string name) { return _getValue(name); }
      public void SetValue(string name, string val) { _setValue(name, val); }
      public CompareModel Compare(IObject o) { return _compare(o, null); }
      public BvSelectList GetList(string name) { return _getList(name); }
      public event ValidationEvent Validation;
      public event ValidationEvent ValidationEnd;
      public event AfterPostEvent AfterPost;
      
        public Dictionary<string, string> GetFieldTags(string name)
        {
          return null;
        }
      #endregion

      private bool IsRIRPropChanged(string fld, HumanCaseListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public HumanCaseListItem()
        {
            
            m_permissions = new Permissions(this);
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();

        

        private bool m_IsForcedToDelete;
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(HumanCaseListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(HumanCaseListItem_PropertyChanged);
        }
        private void HumanCaseListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as HumanCaseListItem).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete(bool bReport = true)
        {
            
            return Accessor.Instance(null).ValidateCanDelete(this);
              
        }
        private void _DeletingExtenders()
        {
            HumanCaseListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            HumanCaseListItem obj = this;
            
        }
        
        public bool OnValidation(string msgId, string fldName, string prpName, object[] pars, Type type, bool shouldAsk)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(msgId, fldName, prpName, pars, type, this, shouldAsk);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(string msgId, string fldName, string prpName, object[] pars, Type type, bool shouldAsk)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(msgId, fldName, prpName, pars, type, this, shouldAsk);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }

        public void OnAfterPost()
        {
            if (AfterPost != null)
            {
                AfterPost(this, EventArgs.Empty);
            }
        }

        public FormSize FormSize
        {
            get { return FormSize.Undefined; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private static string[] readonly_names1 = "Region,idfsRegion".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "Rayon,idfsRayon".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "Settlement,idfsSettlement".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCaseListItem, bool>(c => c.idfsCountry == null)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCaseListItem, bool>(c => c.idfsRegion == null)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCaseListItem, bool>(c => c.idfsRayon == null)(this);
            
            return ReadOnly || new Func<HumanCaseListItem, bool>(c => false)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
            }
        }


        public Dictionary<string, Func<HumanCaseListItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<HumanCaseListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<HumanCaseListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<HumanCaseListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<HumanCaseListItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<HumanCaseListItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~HumanCaseListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftCaseStatus", this);
                
                LookupManager.RemoveObject("rftCaseProgressStatus", this);
                
                LookupManager.RemoveObject("rftHumanAgeType", this);
                
                LookupManager.RemoveObject("CountryLookup", this);
                
                LookupManager.RemoveObject("RegionLookup", this);
                
                LookupManager.RemoveObject("RayonLookup", this);
                
                LookupManager.RemoveObject("SettlementLookup", this);
                
                LookupManager.RemoveObject("rftHumanGender", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("rftNationality", this);
                
                LookupManager.RemoveObject("rftFinalState", this);
                
                LookupManager.RemoveObject("rftHospStatus", this);
                
                LookupManager.RemoveObject("rftCaseStatus", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_TentativeDiagnosis(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_FinalDiagnosis(manager, this);
            
            if (lookup_object == "rftCaseStatus")
                _getAccessor().LoadLookup_CaseStatus(manager, this);
            
            if (lookup_object == "rftCaseProgressStatus")
                _getAccessor().LoadLookup_CaseProgressStatus(manager, this);
            
            if (lookup_object == "rftHumanAgeType")
                _getAccessor().LoadLookup_HumanAgeType(manager, this);
            
            if (lookup_object == "CountryLookup")
                _getAccessor().LoadLookup_Country(manager, this);
            
            if (lookup_object == "RegionLookup")
                _getAccessor().LoadLookup_Region(manager, this);
            
            if (lookup_object == "RayonLookup")
                _getAccessor().LoadLookup_Rayon(manager, this);
            
            if (lookup_object == "SettlementLookup")
                _getAccessor().LoadLookup_Settlement(manager, this);
            
            if (lookup_object == "rftHumanGender")
                _getAccessor().LoadLookup_HumanGender(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_SentByOffice(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_ReceivedByOffice(manager, this);
            
            if (lookup_object == "rftNationality")
                _getAccessor().LoadLookup_Nationality(manager, this);
            
            if (lookup_object == "rftFinalState")
                _getAccessor().LoadLookup_PatientState(manager, this);
            
            if (lookup_object == "rftHospStatus")
                _getAccessor().LoadLookup_PatientLocationType(manager, this);
            
            if (lookup_object == "rftCaseStatus")
                _getAccessor().LoadLookup_InitialCaseStatus(manager, this);
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._name] != null) a._set_func(this, form[ObjectIdent + a._name]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._name)) a._set_func(this, form[ObjectIdent + a._name]);} );
      
            if (bParseRelations)
            {
        
            }
        }
    
        #region Class for web grid
        public class HumanCaseListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfCase { get; set; }
        
            public String strCaseID { get; set; }
        
            public DateTime? datEnteredDate { get; set; }
        
            public String DiagnosisName { get; set; }
        
            public String CaseStatusName { get; set; }
        
            public String GeoLocationName { get; set; }
        
            public String PatientName { get; set; }
        
            public DateTime? datDateofBirth { get; set; }
        
            public string Age { get; set; }
        
            public String CaseProgressStatusName { get; set; }
        
            public Int64? idfsSettlement { get; set; }
        
            public Int64? idfsRegion { get; set; }
        
            public Int64? idfsRayon { get; set; }
        
        }
        public partial class HumanCaseListItemGridModelList : List<HumanCaseListItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public HumanCaseListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<HumanCaseListItem>, errMes);
            }
            public HumanCaseListItemGridModelList(long key, IEnumerable<HumanCaseListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<HumanCaseListItem> items);
            private void LoadGridModelList(long key, IEnumerable<HumanCaseListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strCaseID,_str_datEnteredDate,_str_DiagnosisName,_str_CaseStatusName,_str_GeoLocationName,_str_PatientName,_str_datDateofBirth,_str_Age,_str_CaseProgressStatusName};
                    
                Hiddens = new List<string> {_str_idfCase,_str_idfsSettlement,_str_idfsRegion,_str_idfsRayon};
                Keys = new List<string> {_str_idfCase};
                Labels = new Dictionary<string, string> {{_str_strCaseID, _str_strCaseID},{_str_datEnteredDate, "datEnteredDateSearchPanel"},{_str_DiagnosisName, "FinalDiagnosisName"},{_str_CaseStatusName, _str_CaseStatusName},{_str_GeoLocationName, _str_GeoLocationName},{_str_PatientName, _str_PatientName},{_str_datDateofBirth, _str_datDateofBirth},{_str_Age, _str_Age},{_str_CaseProgressStatusName, _str_CaseProgressStatusName}};
                Actions = new Dictionary<string, ActionMetaItem> {{_str_strCaseID, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "ActionEditHumanCase")}};
                var list = new List<HumanCaseListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new HumanCaseListItemGridModel()
                {
                    ItemKey=c.idfCase,strCaseID=c.strCaseID,datEnteredDate=c.datEnteredDate,DiagnosisName=c.DiagnosisName,CaseStatusName=c.CaseStatusName,GeoLocationName=c.GeoLocationName,PatientName=c.PatientName,datDateofBirth=c.datDateofBirth,Age=c.Age,CaseProgressStatusName=c.CaseProgressStatusName,idfsSettlement=c.idfsSettlement,idfsRegion=c.idfsRegion,idfsRayon=c.idfsRayon
                }));
                if (Count > 0)
                {
                    this.Last().ErrorMessage = errMes;
                }
            }
        }
        #endregion
        

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<HumanCaseListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectList
                    
            , IObjectPost
                    
        {
            private delegate void on_action(HumanCaseListItem obj);
            private static Accessor g_Instance = CreateInstance<Accessor>();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance<Accessor>();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor TentativeDiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor FinalDiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CaseStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CaseProgressStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor HumanAgeTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private CountryLookup.Accessor CountryAccessor { get { return eidss.model.Schema.CountryLookup.Accessor.Instance(m_CS); } }
            private RegionLookup.Accessor RegionAccessor { get { return eidss.model.Schema.RegionLookup.Accessor.Instance(m_CS); } }
            private RayonLookup.Accessor RayonAccessor { get { return eidss.model.Schema.RayonLookup.Accessor.Instance(m_CS); } }
            private SettlementLookup.Accessor SettlementAccessor { get { return eidss.model.Schema.SettlementLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor HumanGenderAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor SentByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor ReceivedByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor NationalityAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor PatientStateAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor PatientLocationTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor InitialCaseStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<HumanCaseListItem> SelectListT(DbManagerProxy manager
                , FilterParams filters = null
                , KeyValuePair<string, ListSortDirection>[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager
                , null, null
                , filters
                , sorts
                , serverSort
                );
            }
            public virtual List<IObject> SelectList(DbManagerProxy manager
                , FilterParams filters = null
                , KeyValuePair<string, ListSortDirection>[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager
                , null, null
                , filters
                , sorts
                , serverSort
                ).Cast<IObject>().ToList();
            }
            
            private List<HumanCaseListItem> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                , FilterParams filters
                , KeyValuePair<string, ListSortDirection>[] sorts
                , bool serverSort = false
                )
            {
                if (filters == null) filters = new FilterParams();
                var sql = new StringBuilder();
                string maxtop = BaseSettings.SelectTopMaxCount.ToString();
                sql.Append(@"select ");
                
                sql.Append(@"top ");
                sql.Append(maxtop);
                sql.Append(@" dbo.fn_HumanCase_SelectList.* from dbo.fn_HumanCase_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("idfsRegion") || filters.Contains("idfsRayon") || filters.Contains("idfsSettlement"))
                {
                    
                    sql.Append(" " + @"
                        left join
	                        (   tlbHuman as h_gl_home
		                        inner join tlbGeoLocation as gl_home on gl_home.idfGeoLocation = h_gl_home.idfCurrentResidenceAddress
			                        and gl_home.idfsGeoLocationType = 10036001 /*'lctAddress'*/
			                        and gl_home.intRowStatus = 0
	                        ) on h_gl_home.idfHuman = fn_HumanCase_SelectList.idfHuman
                    ");
                      
                }
                
                if (filters.Contains("datModificationDate") || filters.Contains("datCompletionPaperFormDate") || filters.Contains("idfsTentativeDiagnosis") || filters.Contains("datTentativeDiagnosisDate") || filters.Contains("idfsFinalDiagnosis") || filters.Contains("datFinalDiagnosisDate") || filters.Contains("idfSentByOffice") || filters.Contains("idfReceivedByOffice") || filters.Contains("strSentByLast") || filters.Contains("strSentByFirst") || filters.Contains("strSentByPatronimyc") || filters.Contains("strReceivedByLast") || filters.Contains("strReceivedByFirst") || filters.Contains("strReceivedByPatronimyc") || filters.Contains("datFacilityLastVisit") || filters.Contains("datOnSetDate") || filters.Contains("idfsFinalState") || filters.Contains("idfsHospitalizationStatus") || filters.Contains("strCurrentLocation") || filters.Contains("strNote") || filters.Contains("datNotificationDate") || filters.Contains("uidOfflineCaseID"))
                {
                    
                    sql.Append(" " + @"
                        left join   
                            (   tlbHumanCase as hc    
                                inner join  tlbCase as c_hc 
                                  on c_hc.idfCase = hc.idfHumanCase and c_hc.intRowStatus = 0
                                left join	tlbPerson as tlbSentByPerson
                                  on tlbSentByPerson.idfPerson = hc.idfSentByPerson
                                left join	tlbPerson as tlbReceivedByPerson
                                  on tlbReceivedByPerson.idfPerson = hc.idfReceivedByPerson
                            ) on hc.idfHumanCase = fn_HumanCase_SelectList.idfCase
                    ");
                      
                }
                
                if (filters.Contains("idfsHumanGender") || filters.Contains("strHomePhone") || filters.Contains("idfsNationality") || filters.Contains("strEmployerName"))
                {
                    
                    sql.Append(" " + @"
                        left join tlbHuman as h
                            on h.idfHuman = fn_HumanCase_SelectList.idfHuman
                    ");
                      
                }
                
                if (filters.Contains("strFieldBarcode"))
                {
                    
                    sql.Append(" " + @"
                  left outer join (
                    select distinct idfCase, strFieldBarcode from tlbMaterial as mi
                    where mi.strFieldBarcode = @strFieldBarcode
                    ) as m 
                    on m.idfCase = fn_HumanCase_SelectList.idfCase
                ");
                      
                }
                
                if (filters.Contains("idfPerson"))
                {
                    
                    sql.Append(" " + @"
                        left join tlbPerson as person
                            on person.idfPerson = fn_HumanCase_SelectList.idfPersonEnteredBy
                    ");
                      
                }
                
                if (ModelUserContext.IsWebContext && EidssSiteContext.Instance.SiteType == SiteType.SS)
                {
                    sql.Append(" " + @"inner join tflCaseFiltered f on f.idfCase = fn_HumanCase_SelectList.idfCase and f.idfsSite = " + EidssSiteContext.Instance.SiteID.ToString());
                }
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfsRegion"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsRegion") == 1)
                    {
                        sql.AppendFormat("isnull(gl_home.idfsRegion,0) {0} @idfsRegion", filters.Operation("idfsRegion"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsRegion"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsRegion") ? " or " : " and ");
                            sql.AppendFormat("isnull(gl_home.idfsRegion,0) {0} @idfsRegion_{1}", filters.Operation("idfsRegion", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsRayon"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsRayon") == 1)
                    {
                        sql.AppendFormat("isnull(gl_home.idfsRayon,0) {0} @idfsRayon", filters.Operation("idfsRayon"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsRayon"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsRayon") ? " or " : " and ");
                            sql.AppendFormat("isnull(gl_home.idfsRayon,0) {0} @idfsRayon_{1}", filters.Operation("idfsRayon", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsSettlement"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsSettlement") == 1)
                    {
                        sql.AppendFormat("isnull(gl_home.idfsSettlement,0) {0} @idfsSettlement", filters.Operation("idfsSettlement"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsSettlement"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsSettlement") ? " or " : " and ");
                            sql.AppendFormat("isnull(gl_home.idfsSettlement,0) {0} @idfsSettlement_{1}", filters.Operation("idfsSettlement", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("datModificationDate"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("datModificationDate") == 1)
                    {
                        sql.AppendFormat("CONVERT(NVARCHAR(8), hc.datModificationDate, 112) {0} CONVERT(NVARCHAR(8), @datModificationDate, 112)", filters.Operation("datModificationDate"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("datModificationDate"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("datModificationDate") ? " or " : " and ");
                            sql.AppendFormat("CONVERT(NVARCHAR(8), hc.datModificationDate, 112) {0} CONVERT(NVARCHAR(8), @datModificationDate_{1}, 112)", filters.Operation("datModificationDate", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("datCompletionPaperFormDate"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("datCompletionPaperFormDate") == 1)
                    {
                        sql.AppendFormat("CONVERT(NVARCHAR(8), hc.datCompletionPaperFormDate, 112) {0} CONVERT(NVARCHAR(8), @datCompletionPaperFormDate, 112)", filters.Operation("datCompletionPaperFormDate"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("datCompletionPaperFormDate"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("datCompletionPaperFormDate") ? " or " : " and ");
                            sql.AppendFormat("CONVERT(NVARCHAR(8), hc.datCompletionPaperFormDate, 112) {0} CONVERT(NVARCHAR(8), @datCompletionPaperFormDate_{1}, 112)", filters.Operation("datCompletionPaperFormDate", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsTentativeDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsTentativeDiagnosis") == 1)
                    {
                        sql.AppendFormat("isnull(hc.idfsTentativeDiagnosis,0) {0} @idfsTentativeDiagnosis", filters.Operation("idfsTentativeDiagnosis"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsTentativeDiagnosis"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsTentativeDiagnosis") ? " or " : " and ");
                            sql.AppendFormat("isnull(hc.idfsTentativeDiagnosis,0) {0} @idfsTentativeDiagnosis_{1}", filters.Operation("idfsTentativeDiagnosis", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("datTentativeDiagnosisDate"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("datTentativeDiagnosisDate") == 1)
                    {
                        sql.AppendFormat("CONVERT(NVARCHAR(8), hc.datTentativeDiagnosisDate, 112) {0} CONVERT(NVARCHAR(8), @datTentativeDiagnosisDate, 112)", filters.Operation("datTentativeDiagnosisDate"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("datTentativeDiagnosisDate"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("datTentativeDiagnosisDate") ? " or " : " and ");
                            sql.AppendFormat("CONVERT(NVARCHAR(8), hc.datTentativeDiagnosisDate, 112) {0} CONVERT(NVARCHAR(8), @datTentativeDiagnosisDate_{1}, 112)", filters.Operation("datTentativeDiagnosisDate", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsFinalDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsFinalDiagnosis") == 1)
                    {
                        sql.AppendFormat("hc.idfsFinalDiagnosis {0} @idfsFinalDiagnosis", filters.Operation("idfsFinalDiagnosis"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsFinalDiagnosis"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsFinalDiagnosis") ? " or " : " and ");
                            sql.AppendFormat("hc.idfsFinalDiagnosis {0} @idfsFinalDiagnosis_{1}", filters.Operation("idfsFinalDiagnosis", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("datFinalDiagnosisDate"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("datFinalDiagnosisDate") == 1)
                    {
                        sql.AppendFormat("CONVERT(NVARCHAR(8), hc.datFinalDiagnosisDate, 112) {0} CONVERT(NVARCHAR(8), @datFinalDiagnosisDate, 112)", filters.Operation("datFinalDiagnosisDate"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("datFinalDiagnosisDate"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("datFinalDiagnosisDate") ? " or " : " and ");
                            sql.AppendFormat("CONVERT(NVARCHAR(8), hc.datFinalDiagnosisDate, 112) {0} CONVERT(NVARCHAR(8), @datFinalDiagnosisDate_{1}, 112)", filters.Operation("datFinalDiagnosisDate", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfSentByOffice"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfSentByOffice") == 1)
                    {
                        sql.AppendFormat("isnull(hc.idfSentByOffice,0) {0} @idfSentByOffice", filters.Operation("idfSentByOffice"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfSentByOffice"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfSentByOffice") ? " or " : " and ");
                            sql.AppendFormat("isnull(hc.idfSentByOffice,0) {0} @idfSentByOffice_{1}", filters.Operation("idfSentByOffice", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfReceivedByOffice"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfReceivedByOffice") == 1)
                    {
                        sql.AppendFormat("isnull(hc.idfReceivedByOffice,0) {0} @idfReceivedByOffice", filters.Operation("idfReceivedByOffice"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfReceivedByOffice"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfReceivedByOffice") ? " or " : " and ");
                            sql.AppendFormat("isnull(hc.idfReceivedByOffice,0) {0} @idfReceivedByOffice_{1}", filters.Operation("idfReceivedByOffice", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("strSentByLast"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strSentByLast") == 1)
                    {
                        sql.AppendFormat("tlbSentByPerson.strFamilyName {0} @strSentByLast", filters.Operation("strSentByLast"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strSentByLast"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strSentByLast") ? " or " : " and ");
                            sql.AppendFormat("tlbSentByPerson.strFamilyName {0} @strSentByLast_{1}", filters.Operation("strSentByLast", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("strSentByFirst"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strSentByFirst") == 1)
                    {
                        sql.AppendFormat("tlbSentByPerson.strFirstName {0} @strSentByFirst", filters.Operation("strSentByFirst"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strSentByFirst"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strSentByFirst") ? " or " : " and ");
                            sql.AppendFormat("tlbSentByPerson.strFirstName {0} @strSentByFirst_{1}", filters.Operation("strSentByFirst", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("strSentByPatronimyc"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strSentByPatronimyc") == 1)
                    {
                        sql.AppendFormat("tlbSentByPerson.strSecondName {0} @strSentByPatronimyc", filters.Operation("strSentByPatronimyc"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strSentByPatronimyc"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strSentByPatronimyc") ? " or " : " and ");
                            sql.AppendFormat("tlbSentByPerson.strSecondName {0} @strSentByPatronimyc_{1}", filters.Operation("strSentByPatronimyc", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("strReceivedByLast"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strReceivedByLast") == 1)
                    {
                        sql.AppendFormat("tlbReceivedByPerson.strFamilyName {0} @strReceivedByLast", filters.Operation("strReceivedByLast"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strReceivedByLast"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strReceivedByLast") ? " or " : " and ");
                            sql.AppendFormat("tlbReceivedByPerson.strFamilyName {0} @strReceivedByLast_{1}", filters.Operation("strReceivedByLast", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("strReceivedByFirst"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strReceivedByFirst") == 1)
                    {
                        sql.AppendFormat("tlbReceivedByPerson.strFirstName {0} @strReceivedByFirst", filters.Operation("strReceivedByFirst"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strReceivedByFirst"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strReceivedByFirst") ? " or " : " and ");
                            sql.AppendFormat("tlbReceivedByPerson.strFirstName {0} @strReceivedByFirst_{1}", filters.Operation("strReceivedByFirst", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("strReceivedByPatronimyc"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strReceivedByPatronimyc") == 1)
                    {
                        sql.AppendFormat("tlbReceivedByPerson.strSecondName {0} @strReceivedByPatronimyc", filters.Operation("strReceivedByPatronimyc"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strReceivedByPatronimyc"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strReceivedByPatronimyc") ? " or " : " and ");
                            sql.AppendFormat("tlbReceivedByPerson.strSecondName {0} @strReceivedByPatronimyc_{1}", filters.Operation("strReceivedByPatronimyc", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("datFacilityLastVisit"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("datFacilityLastVisit") == 1)
                    {
                        sql.AppendFormat("CONVERT(NVARCHAR(8), hc.datFacilityLastVisit, 112) {0} CONVERT(NVARCHAR(8), @datFacilityLastVisit, 112)", filters.Operation("datFacilityLastVisit"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("datFacilityLastVisit"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("datFacilityLastVisit") ? " or " : " and ");
                            sql.AppendFormat("CONVERT(NVARCHAR(8), hc.datFacilityLastVisit, 112) {0} CONVERT(NVARCHAR(8), @datFacilityLastVisit_{1}, 112)", filters.Operation("datFacilityLastVisit", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("datOnSetDate"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("datOnSetDate") == 1)
                    {
                        sql.AppendFormat("CONVERT(NVARCHAR(8), hc.datOnSetDate, 112) {0} CONVERT(NVARCHAR(8), @datOnSetDate, 112)", filters.Operation("datOnSetDate"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("datOnSetDate"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("datOnSetDate") ? " or " : " and ");
                            sql.AppendFormat("CONVERT(NVARCHAR(8), hc.datOnSetDate, 112) {0} CONVERT(NVARCHAR(8), @datOnSetDate_{1}, 112)", filters.Operation("datOnSetDate", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsFinalState"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsFinalState") == 1)
                    {
                        sql.AppendFormat("isnull(hc.idfsFinalState,0) {0} @idfsFinalState", filters.Operation("idfsFinalState"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsFinalState"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsFinalState") ? " or " : " and ");
                            sql.AppendFormat("isnull(hc.idfsFinalState,0) {0} @idfsFinalState_{1}", filters.Operation("idfsFinalState", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsHospitalizationStatus"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsHospitalizationStatus") == 1)
                    {
                        sql.AppendFormat("isnull(hc.idfsHospitalizationStatus,0) {0} @idfsHospitalizationStatus", filters.Operation("idfsHospitalizationStatus"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsHospitalizationStatus"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsHospitalizationStatus") ? " or " : " and ");
                            sql.AppendFormat("isnull(hc.idfsHospitalizationStatus,0) {0} @idfsHospitalizationStatus_{1}", filters.Operation("idfsHospitalizationStatus", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("strCurrentLocation"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strCurrentLocation") == 1)
                    {
                        sql.AppendFormat("hc.strCurrentLocation {0} @strCurrentLocation", filters.Operation("strCurrentLocation"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strCurrentLocation"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strCurrentLocation") ? " or " : " and ");
                            sql.AppendFormat("hc.strCurrentLocation {0} @strCurrentLocation_{1}", filters.Operation("strCurrentLocation", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("strNote"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strNote") == 1)
                    {
                        sql.AppendFormat("hc.strNote {0} @strNote", filters.Operation("strNote"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strNote"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strNote") ? " or " : " and ");
                            sql.AppendFormat("hc.strNote {0} @strNote_{1}", filters.Operation("strNote", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("datNotificationDate"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("datNotificationDate") == 1)
                    {
                        sql.AppendFormat("CONVERT(NVARCHAR(8), hc.datNotificationDate, 112) {0} CONVERT(NVARCHAR(8), @datNotificationDate, 112)", filters.Operation("datNotificationDate"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("datNotificationDate"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("datNotificationDate") ? " or " : " and ");
                            sql.AppendFormat("CONVERT(NVARCHAR(8), hc.datNotificationDate, 112) {0} CONVERT(NVARCHAR(8), @datNotificationDate_{1}, 112)", filters.Operation("datNotificationDate", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("uidOfflineCaseID"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("uidOfflineCaseID") == 1)
                    {
                        sql.AppendFormat("c_hc.uidOfflineCaseID {0} @uidOfflineCaseID", filters.Operation("uidOfflineCaseID"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("uidOfflineCaseID"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("uidOfflineCaseID") ? " or " : " and ");
                            sql.AppendFormat("c_hc.uidOfflineCaseID {0} @uidOfflineCaseID_{1}", filters.Operation("uidOfflineCaseID", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsHumanGender"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsHumanGender") == 1)
                    {
                        sql.AppendFormat("isnull(h.idfsHumanGender,0) {0} @idfsHumanGender", filters.Operation("idfsHumanGender"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsHumanGender"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsHumanGender") ? " or " : " and ");
                            sql.AppendFormat("isnull(h.idfsHumanGender,0) {0} @idfsHumanGender_{1}", filters.Operation("idfsHumanGender", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("strHomePhone"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strHomePhone") == 1)
                    {
                        sql.AppendFormat("isnull(h.strHomePhone,'') {0} @strHomePhone", filters.Operation("strHomePhone"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strHomePhone"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strHomePhone") ? " or " : " and ");
                            sql.AppendFormat("isnull(h.strHomePhone,'') {0} @strHomePhone_{1}", filters.Operation("strHomePhone", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsNationality"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsNationality") == 1)
                    {
                        sql.AppendFormat("isnull(h.idfsNationality,0) {0} @idfsNationality", filters.Operation("idfsNationality"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsNationality"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsNationality") ? " or " : " and ");
                            sql.AppendFormat("isnull(h.idfsNationality,0) {0} @idfsNationality_{1}", filters.Operation("idfsNationality", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("strEmployerName"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strEmployerName") == 1)
                    {
                        sql.AppendFormat("isnull(h.strEmployerName,'') {0} @strEmployerName", filters.Operation("strEmployerName"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strEmployerName"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strEmployerName") ? " or " : " and ");
                            sql.AppendFormat("isnull(h.strEmployerName,'') {0} @strEmployerName_{1}", filters.Operation("strEmployerName", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("strFieldBarcode"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strFieldBarcode") == 1)
                    {
                        sql.AppendFormat("m.strFieldBarcode {0} @strFieldBarcode", filters.Operation("strFieldBarcode"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strFieldBarcode"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strFieldBarcode") ? " or " : " and ");
                            sql.AppendFormat("m.strFieldBarcode {0} @strFieldBarcode_{1}", filters.Operation("strFieldBarcode", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfPerson"))
                    sql.AppendFormat(" and " + new Func<string>(() => (String.IsNullOrEmpty(EidssUserContext.User.EmployeeID.ToString())) ? "@idfPerson = 0" : String.Format("(@idfPerson = 0 OR person.idfPerson = {0})",EidssUserContext.User.EmployeeID.ToString()))());
                            
                if (filters.Contains("idfCase"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfCase"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfCase") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanCase_SelectList.idfCase,0) {0} @idfCase_{1}", filters.Operation("idfCase", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsDiagnosis"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsDiagnosis") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanCase_SelectList.idfsDiagnosis,0) {0} @idfsDiagnosis_{1}", filters.Operation("idfsDiagnosis", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("DiagnosisName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("DiagnosisName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("DiagnosisName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCase_SelectList.DiagnosisName {0} @DiagnosisName_{1}", filters.Operation("DiagnosisName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCaseStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCaseStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCaseStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanCase_SelectList.idfsCaseStatus,0) {0} @idfsCaseStatus_{1}", filters.Operation("idfsCaseStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCaseProgressStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCaseProgressStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCaseProgressStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanCase_SelectList.idfsCaseProgressStatus,0) {0} @idfsCaseProgressStatus_{1}", filters.Operation("idfsCaseProgressStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("CaseStatusName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("CaseStatusName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("CaseStatusName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCase_SelectList.CaseStatusName {0} @CaseStatusName_{1}", filters.Operation("CaseStatusName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("CaseProgressStatusName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("CaseProgressStatusName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("CaseProgressStatusName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCase_SelectList.CaseProgressStatusName {0} @CaseProgressStatusName_{1}", filters.Operation("CaseProgressStatusName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datEnteredDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datEnteredDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datEnteredDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_HumanCase_SelectList.datEnteredDate, 112) {0} CONVERT(NVARCHAR(8), @datEnteredDate_{1}, 112)", filters.Operation("datEnteredDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCaseID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCaseID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCaseID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCase_SelectList.strCaseID {0} @strCaseID_{1}", filters.Operation("strCaseID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSite"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSite"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSite") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanCase_SelectList.idfsSite,0) {0} @idfsSite_{1}", filters.Operation("idfsSite", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strLocalIdentifier"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strLocalIdentifier"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strLocalIdentifier") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCase_SelectList.strLocalIdentifier {0} @strLocalIdentifier_{1}", filters.Operation("strLocalIdentifier", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfPersonEnteredBy"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfPersonEnteredBy"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfPersonEnteredBy") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanCase_SelectList.idfPersonEnteredBy,0) {0} @idfPersonEnteredBy_{1}", filters.Operation("idfPersonEnteredBy", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfHuman"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfHuman"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfHuman") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanCase_SelectList.idfHuman,0) {0} @idfHuman_{1}", filters.Operation("idfHuman", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strLastName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strLastName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strLastName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCase_SelectList.strLastName {0} @strLastName_{1}", filters.Operation("strLastName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFirstName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFirstName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFirstName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCase_SelectList.strFirstName {0} @strFirstName_{1}", filters.Operation("strFirstName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSecondName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSecondName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSecondName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCase_SelectList.strSecondName {0} @strSecondName_{1}", filters.Operation("strSecondName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("PatientName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("PatientName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("PatientName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCase_SelectList.PatientName {0} @PatientName_{1}", filters.Operation("PatientName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datDateofBirth"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datDateofBirth"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datDateofBirth") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_HumanCase_SelectList.datDateofBirth, 112) {0} CONVERT(NVARCHAR(8), @datDateofBirth_{1}, 112)", filters.Operation("datDateofBirth", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intPatientAge"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intPatientAge"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intPatientAge") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanCase_SelectList.intPatientAge,0) {0} @intPatientAge_{1}", filters.Operation("intPatientAge", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsHumanAgeType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsHumanAgeType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsHumanAgeType") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanCase_SelectList.idfsHumanAgeType,0) {0} @idfsHumanAgeType_{1}", filters.Operation("idfsHumanAgeType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("Age"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("Age"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("Age") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCase_SelectList.Age {0} @Age_{1}", filters.Operation("Age", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfAddress"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfAddress"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfAddress") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanCase_SelectList.idfAddress,0) {0} @idfAddress_{1}", filters.Operation("idfAddress", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfGeoLocation"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfGeoLocation"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfGeoLocation") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanCase_SelectList.idfGeoLocation,0) {0} @idfGeoLocation_{1}", filters.Operation("idfGeoLocation", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("GeoLocationName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("GeoLocationName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("GeoLocationName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCase_SelectList.GeoLocationName {0} @GeoLocationName_{1}", filters.Operation("GeoLocationName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfEpiObservation"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfEpiObservation"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfEpiObservation") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanCase_SelectList.idfEpiObservation,0) {0} @idfEpiObservation_{1}", filters.Operation("idfEpiObservation", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfCSObservation"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfCSObservation"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfCSObservation") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanCase_SelectList.idfCSObservation,0) {0} @idfCSObservation_{1}", filters.Operation("idfCSObservation", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsInitialCaseStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsInitialCaseStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsInitialCaseStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanCase_SelectList.idfsInitialCaseStatus,0) {0} @idfsInitialCaseStatus_{1}", filters.Operation("idfsInitialCaseStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCountry"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCountry"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCountry") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanCase_SelectList.idfsCountry,0) {0} @idfsCountry_{1}", filters.Operation("idfsCountry", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (serverSort && sorts != null && sorts.Length > 0)
                {
                    sql.Append(" order by");
                    bool bFirst = true;
                    foreach(var sort in sorts)
                    {
                        sql.Append((bFirst ? " " : ", ") + sort.Key + " " + (sort.Value == ListSortDirection.Ascending ? "ASC" : "DESC"));
                        bFirst = false;
                    }
                }

                bool bTransactionStarted = false;
                try
                {
                    if (!manager.IsTransactionStarted)
                    {
                        bTransactionStarted = true;
                        manager.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                    }
                    manager
                        .SetCommand(sql.ToString()
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                        );
                    
                    if (filters.Contains("idfPerson"))
                        
                        if (filters.Count("idfPerson") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfPerson", ParsingHelper.CorrectLikeValue(filters.Operation("idfPerson"), filters.Value("idfPerson"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfPerson"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfPerson", i), filters.Value("idfPerson", i))));
                        }
                            
                    if (filters.Contains("idfsRegion"))
                        
                        if (filters.Count("idfsRegion") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion", ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion"), filters.Value("idfsRegion"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsRegion"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion", i), filters.Value("idfsRegion", i))));
                        }
                            
                    if (filters.Contains("idfsRayon"))
                        
                        if (filters.Count("idfsRayon") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon", ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon"), filters.Value("idfsRayon"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsRayon"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon", i), filters.Value("idfsRayon", i))));
                        }
                            
                    if (filters.Contains("idfsSettlement"))
                        
                        if (filters.Count("idfsSettlement") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSettlement", ParsingHelper.CorrectLikeValue(filters.Operation("idfsSettlement"), filters.Value("idfsSettlement"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsSettlement"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSettlement_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSettlement", i), filters.Value("idfsSettlement", i))));
                        }
                            
                    if (filters.Contains("idfSentByOffice"))
                        
                        if (filters.Count("idfSentByOffice") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfSentByOffice", ParsingHelper.CorrectLikeValue(filters.Operation("idfSentByOffice"), filters.Value("idfSentByOffice"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfSentByOffice"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfSentByOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfSentByOffice", i), filters.Value("idfSentByOffice", i))));
                        }
                            
                    if (filters.Contains("idfReceivedByOffice"))
                        
                        if (filters.Count("idfReceivedByOffice") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfReceivedByOffice", ParsingHelper.CorrectLikeValue(filters.Operation("idfReceivedByOffice"), filters.Value("idfReceivedByOffice"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfReceivedByOffice"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfReceivedByOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfReceivedByOffice", i), filters.Value("idfReceivedByOffice", i))));
                        }
                            
                    if (filters.Contains("idfsTentativeDiagnosis"))
                        
                        if (filters.Count("idfsTentativeDiagnosis") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTentativeDiagnosis", ParsingHelper.CorrectLikeValue(filters.Operation("idfsTentativeDiagnosis"), filters.Value("idfsTentativeDiagnosis"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsTentativeDiagnosis"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTentativeDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTentativeDiagnosis", i), filters.Value("idfsTentativeDiagnosis", i))));
                        }
                            
                    if (filters.Contains("datTentativeDiagnosisDate"))
                        
                        for (int i = 0; i < filters.Count("datTentativeDiagnosisDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datTentativeDiagnosisDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datTentativeDiagnosisDate", i), filters.Value("datTentativeDiagnosisDate", i))));
                            
                    if (filters.Contains("idfsFinalDiagnosis"))
                        
                        if (filters.Count("idfsFinalDiagnosis") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsFinalDiagnosis", ParsingHelper.CorrectLikeValue(filters.Operation("idfsFinalDiagnosis"), filters.Value("idfsFinalDiagnosis"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsFinalDiagnosis"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsFinalDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsFinalDiagnosis", i), filters.Value("idfsFinalDiagnosis", i))));
                        }
                            
                    if (filters.Contains("datFinalDiagnosisDate"))
                        
                        for (int i = 0; i < filters.Count("datFinalDiagnosisDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datFinalDiagnosisDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datFinalDiagnosisDate", i), filters.Value("datFinalDiagnosisDate", i))));
                            
                    if (filters.Contains("strFieldBarcode"))
                        
                        if (filters.Count("strFieldBarcode") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFieldBarcode", ParsingHelper.CorrectLikeValue(filters.Operation("strFieldBarcode"), filters.Value("strFieldBarcode"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strFieldBarcode"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFieldBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFieldBarcode", i), filters.Value("strFieldBarcode", i))));
                        }
                            
                    if (filters.Contains("datModificationDate"))
                        
                        if (filters.Count("datModificationDate") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datModificationDate", ParsingHelper.CorrectLikeValue(filters.Operation("datModificationDate"), filters.Value("datModificationDate"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("datModificationDate"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@datModificationDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datModificationDate", i), filters.Value("datModificationDate", i))));
                        }
                            
                    if (filters.Contains("datCompletionPaperFormDate"))
                        
                        if (filters.Count("datCompletionPaperFormDate") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datCompletionPaperFormDate", ParsingHelper.CorrectLikeValue(filters.Operation("datCompletionPaperFormDate"), filters.Value("datCompletionPaperFormDate"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("datCompletionPaperFormDate"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@datCompletionPaperFormDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datCompletionPaperFormDate", i), filters.Value("datCompletionPaperFormDate", i))));
                        }
                            
                    if (filters.Contains("idfsHumanGender"))
                        
                        if (filters.Count("idfsHumanGender") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsHumanGender", ParsingHelper.CorrectLikeValue(filters.Operation("idfsHumanGender"), filters.Value("idfsHumanGender"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsHumanGender"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsHumanGender_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsHumanGender", i), filters.Value("idfsHumanGender", i))));
                        }
                            
                    if (filters.Contains("strHomePhone"))
                        
                        if (filters.Count("strHomePhone") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strHomePhone", ParsingHelper.CorrectLikeValue(filters.Operation("strHomePhone"), filters.Value("strHomePhone"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strHomePhone"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strHomePhone_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strHomePhone", i), filters.Value("strHomePhone", i))));
                        }
                            
                    if (filters.Contains("idfsNationality"))
                        
                        if (filters.Count("idfsNationality") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsNationality", ParsingHelper.CorrectLikeValue(filters.Operation("idfsNationality"), filters.Value("idfsNationality"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsNationality"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsNationality_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsNationality", i), filters.Value("idfsNationality", i))));
                        }
                            
                    if (filters.Contains("strEmployerName"))
                        
                        if (filters.Count("strEmployerName") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strEmployerName", ParsingHelper.CorrectLikeValue(filters.Operation("strEmployerName"), filters.Value("strEmployerName"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strEmployerName"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strEmployerName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strEmployerName", i), filters.Value("strEmployerName", i))));
                        }
                            
                    if (filters.Contains("datFacilityLastVisit"))
                        
                        if (filters.Count("datFacilityLastVisit") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datFacilityLastVisit", ParsingHelper.CorrectLikeValue(filters.Operation("datFacilityLastVisit"), filters.Value("datFacilityLastVisit"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("datFacilityLastVisit"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@datFacilityLastVisit_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datFacilityLastVisit", i), filters.Value("datFacilityLastVisit", i))));
                        }
                            
                    if (filters.Contains("datOnSetDate"))
                        
                        if (filters.Count("datOnSetDate") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datOnSetDate", ParsingHelper.CorrectLikeValue(filters.Operation("datOnSetDate"), filters.Value("datOnSetDate"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("datOnSetDate"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@datOnSetDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datOnSetDate", i), filters.Value("datOnSetDate", i))));
                        }
                            
                    if (filters.Contains("idfsFinalState"))
                        
                        if (filters.Count("idfsFinalState") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsFinalState", ParsingHelper.CorrectLikeValue(filters.Operation("idfsFinalState"), filters.Value("idfsFinalState"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsFinalState"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsFinalState_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsFinalState", i), filters.Value("idfsFinalState", i))));
                        }
                            
                    if (filters.Contains("idfsHospitalizationStatus"))
                        
                        if (filters.Count("idfsHospitalizationStatus") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsHospitalizationStatus", ParsingHelper.CorrectLikeValue(filters.Operation("idfsHospitalizationStatus"), filters.Value("idfsHospitalizationStatus"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsHospitalizationStatus"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsHospitalizationStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsHospitalizationStatus", i), filters.Value("idfsHospitalizationStatus", i))));
                        }
                            
                    if (filters.Contains("strCurrentLocation"))
                        
                        if (filters.Count("strCurrentLocation") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCurrentLocation", ParsingHelper.CorrectLikeValue(filters.Operation("strCurrentLocation"), filters.Value("strCurrentLocation"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strCurrentLocation"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCurrentLocation_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCurrentLocation", i), filters.Value("strCurrentLocation", i))));
                        }
                            
                    if (filters.Contains("strNote"))
                        
                        if (filters.Count("strNote") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strNote", ParsingHelper.CorrectLikeValue(filters.Operation("strNote"), filters.Value("strNote"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strNote"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strNote_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strNote", i), filters.Value("strNote", i))));
                        }
                            
                    if (filters.Contains("datNotificationDate"))
                        
                        if (filters.Count("datNotificationDate") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datNotificationDate", ParsingHelper.CorrectLikeValue(filters.Operation("datNotificationDate"), filters.Value("datNotificationDate"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("datNotificationDate"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@datNotificationDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datNotificationDate", i), filters.Value("datNotificationDate", i))));
                        }
                            
                    if (filters.Contains("strSentByFirst"))
                        
                        if (filters.Count("strSentByFirst") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSentByFirst", ParsingHelper.CorrectLikeValue(filters.Operation("strSentByFirst"), filters.Value("strSentByFirst"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strSentByFirst"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSentByFirst_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSentByFirst", i), filters.Value("strSentByFirst", i))));
                        }
                            
                    if (filters.Contains("strSentByPatronimyc"))
                        
                        if (filters.Count("strSentByPatronimyc") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSentByPatronimyc", ParsingHelper.CorrectLikeValue(filters.Operation("strSentByPatronimyc"), filters.Value("strSentByPatronimyc"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strSentByPatronimyc"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSentByPatronimyc_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSentByPatronimyc", i), filters.Value("strSentByPatronimyc", i))));
                        }
                            
                    if (filters.Contains("strSentByLast"))
                        
                        if (filters.Count("strSentByLast") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSentByLast", ParsingHelper.CorrectLikeValue(filters.Operation("strSentByLast"), filters.Value("strSentByLast"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strSentByLast"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSentByLast_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSentByLast", i), filters.Value("strSentByLast", i))));
                        }
                            
                    if (filters.Contains("strReceivedByFirst"))
                        
                        if (filters.Count("strReceivedByFirst") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strReceivedByFirst", ParsingHelper.CorrectLikeValue(filters.Operation("strReceivedByFirst"), filters.Value("strReceivedByFirst"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strReceivedByFirst"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strReceivedByFirst_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strReceivedByFirst", i), filters.Value("strReceivedByFirst", i))));
                        }
                            
                    if (filters.Contains("strReceivedByPatronimyc"))
                        
                        if (filters.Count("strReceivedByPatronimyc") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strReceivedByPatronimyc", ParsingHelper.CorrectLikeValue(filters.Operation("strReceivedByPatronimyc"), filters.Value("strReceivedByPatronimyc"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strReceivedByPatronimyc"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strReceivedByPatronimyc_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strReceivedByPatronimyc", i), filters.Value("strReceivedByPatronimyc", i))));
                        }
                            
                    if (filters.Contains("strReceivedByLast"))
                        
                        if (filters.Count("strReceivedByLast") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strReceivedByLast", ParsingHelper.CorrectLikeValue(filters.Operation("strReceivedByLast"), filters.Value("strReceivedByLast"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strReceivedByLast"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strReceivedByLast_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strReceivedByLast", i), filters.Value("strReceivedByLast", i))));
                        }
                            
                    if (filters.Contains("uidOfflineCaseID"))
                        
                        if (filters.Count("uidOfflineCaseID") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@uidOfflineCaseID", ParsingHelper.CorrectLikeValue(filters.Operation("uidOfflineCaseID"), filters.Value("uidOfflineCaseID"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("uidOfflineCaseID"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@uidOfflineCaseID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("uidOfflineCaseID", i), filters.Value("uidOfflineCaseID", i))));
                        }
                            
                    if (filters.Contains("idfCase"))
                        for (int i = 0; i < filters.Count("idfCase"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfCase_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfCase", i), filters.Value("idfCase", i))));
                      
                    if (filters.Contains("idfsDiagnosis"))
                        for (int i = 0; i < filters.Count("idfsDiagnosis"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosis", i), filters.Value("idfsDiagnosis", i))));
                      
                    if (filters.Contains("DiagnosisName"))
                        for (int i = 0; i < filters.Count("DiagnosisName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@DiagnosisName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("DiagnosisName", i), filters.Value("DiagnosisName", i))));
                      
                    if (filters.Contains("idfsCaseStatus"))
                        for (int i = 0; i < filters.Count("idfsCaseStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseStatus", i), filters.Value("idfsCaseStatus", i))));
                      
                    if (filters.Contains("idfsCaseProgressStatus"))
                        for (int i = 0; i < filters.Count("idfsCaseProgressStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseProgressStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseProgressStatus", i), filters.Value("idfsCaseProgressStatus", i))));
                      
                    if (filters.Contains("CaseStatusName"))
                        for (int i = 0; i < filters.Count("CaseStatusName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@CaseStatusName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("CaseStatusName", i), filters.Value("CaseStatusName", i))));
                      
                    if (filters.Contains("CaseProgressStatusName"))
                        for (int i = 0; i < filters.Count("CaseProgressStatusName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@CaseProgressStatusName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("CaseProgressStatusName", i), filters.Value("CaseProgressStatusName", i))));
                      
                    if (filters.Contains("datEnteredDate"))
                        for (int i = 0; i < filters.Count("datEnteredDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datEnteredDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datEnteredDate", i), filters.Value("datEnteredDate", i))));
                      
                    if (filters.Contains("strCaseID"))
                        for (int i = 0; i < filters.Count("strCaseID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCaseID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCaseID", i), filters.Value("strCaseID", i))));
                      
                    if (filters.Contains("idfsSite"))
                        for (int i = 0; i < filters.Count("idfsSite"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSite_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSite", i), filters.Value("idfsSite", i))));
                      
                    if (filters.Contains("strLocalIdentifier"))
                        for (int i = 0; i < filters.Count("strLocalIdentifier"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strLocalIdentifier_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strLocalIdentifier", i), filters.Value("strLocalIdentifier", i))));
                      
                    if (filters.Contains("idfPersonEnteredBy"))
                        for (int i = 0; i < filters.Count("idfPersonEnteredBy"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfPersonEnteredBy_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfPersonEnteredBy", i), filters.Value("idfPersonEnteredBy", i))));
                      
                    if (filters.Contains("idfHuman"))
                        for (int i = 0; i < filters.Count("idfHuman"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfHuman_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfHuman", i), filters.Value("idfHuman", i))));
                      
                    if (filters.Contains("strLastName"))
                        for (int i = 0; i < filters.Count("strLastName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strLastName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strLastName", i), filters.Value("strLastName", i))));
                      
                    if (filters.Contains("strFirstName"))
                        for (int i = 0; i < filters.Count("strFirstName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFirstName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFirstName", i), filters.Value("strFirstName", i))));
                      
                    if (filters.Contains("strSecondName"))
                        for (int i = 0; i < filters.Count("strSecondName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSecondName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSecondName", i), filters.Value("strSecondName", i))));
                      
                    if (filters.Contains("PatientName"))
                        for (int i = 0; i < filters.Count("PatientName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@PatientName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("PatientName", i), filters.Value("PatientName", i))));
                      
                    if (filters.Contains("datDateofBirth"))
                        for (int i = 0; i < filters.Count("datDateofBirth"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datDateofBirth_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datDateofBirth", i), filters.Value("datDateofBirth", i))));
                      
                    if (filters.Contains("intPatientAge"))
                        for (int i = 0; i < filters.Count("intPatientAge"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intPatientAge_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intPatientAge", i), filters.Value("intPatientAge", i))));
                      
                    if (filters.Contains("idfsHumanAgeType"))
                        for (int i = 0; i < filters.Count("idfsHumanAgeType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsHumanAgeType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsHumanAgeType", i), filters.Value("idfsHumanAgeType", i))));
                      
                    if (filters.Contains("Age"))
                        for (int i = 0; i < filters.Count("Age"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@Age_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("Age", i), filters.Value("Age", i))));
                      
                    if (filters.Contains("idfAddress"))
                        for (int i = 0; i < filters.Count("idfAddress"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfAddress_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfAddress", i), filters.Value("idfAddress", i))));
                      
                    if (filters.Contains("idfGeoLocation"))
                        for (int i = 0; i < filters.Count("idfGeoLocation"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfGeoLocation_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfGeoLocation", i), filters.Value("idfGeoLocation", i))));
                      
                    if (filters.Contains("GeoLocationName"))
                        for (int i = 0; i < filters.Count("GeoLocationName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@GeoLocationName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("GeoLocationName", i), filters.Value("GeoLocationName", i))));
                      
                    if (filters.Contains("idfEpiObservation"))
                        for (int i = 0; i < filters.Count("idfEpiObservation"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfEpiObservation_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfEpiObservation", i), filters.Value("idfEpiObservation", i))));
                      
                    if (filters.Contains("idfCSObservation"))
                        for (int i = 0; i < filters.Count("idfCSObservation"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfCSObservation_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfCSObservation", i), filters.Value("idfCSObservation", i))));
                      
                    if (filters.Contains("idfsInitialCaseStatus"))
                        for (int i = 0; i < filters.Count("idfsInitialCaseStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsInitialCaseStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsInitialCaseStatus", i), filters.Value("idfsInitialCaseStatus", i))));
                      
                    if (filters.Contains("idfsCountry"))
                        for (int i = 0; i < filters.Count("idfsCountry"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCountry_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCountry", i), filters.Value("idfsCountry", i))));
                      
                    List<HumanCaseListItem> objs = manager.ExecuteList<HumanCaseListItem>();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                    }
                    return objs;
                }
                catch(DataException e)
                {
                    if (bTransactionStarted)
                    {
                        manager.RollbackTransaction();
                    }
                    throw DbModelException.Create(e);
                }
            }
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spHumanCase_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, HumanCaseListItem obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, HumanCaseListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private HumanCaseListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    HumanCaseListItem obj = HumanCaseListItem.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.Country = new Func<HumanCaseListItem, CountryLookup>(c => 
                                     c.CountryLookup.Where(a => a.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID)
                                     .SingleOrDefault())(obj);
                obj.Region = new Func<HumanCaseListItem, RegionLookup>(c => 
                                     c.RegionLookup.Where(a => a.idfsRegion == eidss.model.Core.EidssSiteContext.Instance.RegionID)
                                     .SingleOrDefault())(obj);
                obj.datEnteredDate = new Func<HumanCaseListItem, DateTime>(c => DateTime.Now)(obj);
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(e);
                }
            }

            
            public HumanCaseListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public HumanCaseListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult ActionEditHumanCase(DbManagerProxy manager, HumanCaseListItem obj, List<object> pars)
            {
                
                return ActionEditHumanCase(manager, obj
                    );
            }
            public ActResult ActionEditHumanCase(DbManagerProxy manager, HumanCaseListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ActionEditHumanCase"))
                    throw new PermissionException("HumanCase", "ActionEditHumanCase");
                
                return true;
                
            }
            
            private void _SetupChildHandlers(HumanCaseListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(HumanCaseListItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.Region = new Func<HumanCaseListItem, RegionLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.Rayon = new Func<HumanCaseListItem, RayonLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                obj.Settlement = new Func<HumanCaseListItem, SettlementLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Region(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Rayon(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Settlement(manager, obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Diagnosis(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => !EidssUserContext.User.DenyDiagnosis.ContainsKey(c.idfsDiagnosis))
                        
                    .Where(c => ((c.intHACode & (int)HACode.Human) != 0) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != null && obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .Where(c => c.idfsDiagnosis == obj.idfsDiagnosis)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_TentativeDiagnosis(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.TentativeDiagnosisLookup.Clear();
                
                obj.TentativeDiagnosisLookup.Add(TentativeDiagnosisAccessor.CreateNewT(manager, null));
                
                obj.TentativeDiagnosisLookup.AddRange(TentativeDiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => !EidssUserContext.User.DenyDiagnosis.ContainsKey(c.idfsDiagnosis))
                        
                    .Where(c => ((c.intHACode & (int)HACode.Human) != 0) || c.idfsDiagnosis == obj.idfsTentativeDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsTentativeDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsTentativeDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsTentativeDiagnosis != null && obj.idfsTentativeDiagnosis != 0)
                {
                    obj.TentativeDiagnosis = obj.TentativeDiagnosisLookup
                        .Where(c => c.idfsDiagnosis == obj.idfsTentativeDiagnosis)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, TentativeDiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_FinalDiagnosis(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.FinalDiagnosisLookup.Clear();
                
                obj.FinalDiagnosisLookup.Add(FinalDiagnosisAccessor.CreateNewT(manager, null));
                
                obj.FinalDiagnosisLookup.AddRange(FinalDiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => !EidssUserContext.User.DenyDiagnosis.ContainsKey(c.idfsDiagnosis))
                        
                    .Where(c => ((c.intHACode & (int)HACode.Human) != 0) || c.idfsDiagnosis == obj.idfsFinalDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsFinalDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsFinalDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsFinalDiagnosis != null && obj.idfsFinalDiagnosis != 0)
                {
                    obj.FinalDiagnosis = obj.FinalDiagnosisLookup
                        .Where(c => c.idfsDiagnosis == obj.idfsFinalDiagnosis)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, FinalDiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_CaseStatus(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.CaseStatusLookup.Clear();
                
                obj.CaseStatusLookup.Add(CaseStatusAccessor.CreateNewT(manager, null));
                
                obj.CaseStatusLookup.AddRange(CaseStatusAccessor.rftCaseStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCaseStatus))
                    
                    .ToList());
                
                if (obj.idfsCaseStatus != null && obj.idfsCaseStatus != 0)
                {
                    obj.CaseStatus = obj.CaseStatusLookup
                        .Where(c => c.idfsBaseReference == obj.idfsCaseStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftCaseStatus", obj, CaseStatusAccessor.GetType(), "rftCaseStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_CaseProgressStatus(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.CaseProgressStatusLookup.Clear();
                
                obj.CaseProgressStatusLookup.Add(CaseProgressStatusAccessor.CreateNewT(manager, null));
                
                obj.CaseProgressStatusLookup.AddRange(CaseProgressStatusAccessor.rftCaseProgressStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCaseProgressStatus))
                    
                    .ToList());
                
                if (obj.idfsCaseProgressStatus != null && obj.idfsCaseProgressStatus != 0)
                {
                    obj.CaseProgressStatus = obj.CaseProgressStatusLookup
                        .Where(c => c.idfsBaseReference == obj.idfsCaseProgressStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftCaseProgressStatus", obj, CaseProgressStatusAccessor.GetType(), "rftCaseProgressStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_HumanAgeType(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.HumanAgeTypeLookup.Clear();
                
                obj.HumanAgeTypeLookup.Add(HumanAgeTypeAccessor.CreateNewT(manager, null));
                
                obj.HumanAgeTypeLookup.AddRange(HumanAgeTypeAccessor.rftHumanAgeType_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode.GetValueOrDefault() & (int)HACode.Human) != 0)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsHumanAgeType))
                    
                    .ToList());
                
                if (obj.idfsHumanAgeType != null && obj.idfsHumanAgeType != 0)
                {
                    obj.HumanAgeType = obj.HumanAgeTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsHumanAgeType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftHumanAgeType", obj, HumanAgeTypeAccessor.GetType(), "rftHumanAgeType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Country(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.CountryLookup.Clear();
                
                obj.CountryLookup.Add(CountryAccessor.CreateNewT(manager, null));
                
                obj.CountryLookup.AddRange(CountryAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsCountry == obj.idfsCountry))
                    
                    .ToList());
                
                if (obj.idfsCountry != null && obj.idfsCountry != 0)
                {
                    obj.Country = obj.CountryLookup
                        .Where(c => c.idfsCountry == obj.idfsCountry)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("CountryLookup", obj, CountryAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Region(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<HumanCaseListItem, long>(c => c.idfsCountry ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRegion == obj.idfsRegion))
                    
                    .ToList());
                
                if (obj.idfsRegion != null && obj.idfsRegion != 0)
                {
                    obj.Region = obj.RegionLookup
                        .Where(c => c.idfsRegion == obj.idfsRegion)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("RegionLookup", obj, RegionAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Rayon(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<HumanCaseListItem, long>(c => c.idfsRegion ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRayon == obj.idfsRayon))
                    
                    .ToList());
                
                if (obj.idfsRayon != null && obj.idfsRayon != 0)
                {
                    obj.Rayon = obj.RayonLookup
                        .Where(c => c.idfsRayon == obj.idfsRayon)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("RayonLookup", obj, RayonAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Settlement(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.SettlementLookup.Clear();
                
                obj.SettlementLookup.Add(SettlementAccessor.CreateNewT(manager, null));
                
                obj.SettlementLookup.AddRange(SettlementAccessor.SelectLookupList(manager
                    
                    , new Func<HumanCaseListItem, long>(c => c.idfsRayon ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSettlement == obj.idfsSettlement))
                    
                    .ToList());
                
                if (obj.idfsSettlement != null && obj.idfsSettlement != 0)
                {
                    obj.Settlement = obj.SettlementLookup
                        .Where(c => c.idfsSettlement == obj.idfsSettlement)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("SettlementLookup", obj, SettlementAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_HumanGender(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.HumanGenderLookup.Clear();
                
                obj.HumanGenderLookup.Add(HumanGenderAccessor.CreateNewT(manager, null));
                
                obj.HumanGenderLookup.AddRange(HumanGenderAccessor.rftHumanGender_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsHumanGender))
                    
                    .ToList());
                
                if (obj.idfsHumanGender != null && obj.idfsHumanGender != 0)
                {
                    obj.HumanGender = obj.HumanGenderLookup
                        .Where(c => c.idfsBaseReference == obj.idfsHumanGender)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftHumanGender", obj, HumanGenderAccessor.GetType(), "rftHumanGender_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_SentByOffice(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.SentByOfficeLookup.Clear();
                
                obj.SentByOfficeLookup.Add(SentByOfficeAccessor.CreateNewT(manager, null));
                
                obj.SentByOfficeLookup.AddRange(SentByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfSentByOffice))
                    
                    .ToList());
                
                if (obj.idfSentByOffice != null && obj.idfSentByOffice != 0)
                {
                    obj.SentByOffice = obj.SentByOfficeLookup
                        .Where(c => c.idfInstitution == obj.idfSentByOffice)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("OrganizationLookup", obj, SentByOfficeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_ReceivedByOffice(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.ReceivedByOfficeLookup.Clear();
                
                obj.ReceivedByOfficeLookup.Add(ReceivedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.ReceivedByOfficeLookup.AddRange(ReceivedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfReceivedByOffice))
                    
                    .ToList());
                
                if (obj.idfReceivedByOffice != null && obj.idfReceivedByOffice != 0)
                {
                    obj.ReceivedByOffice = obj.ReceivedByOfficeLookup
                        .Where(c => c.idfInstitution == obj.idfReceivedByOffice)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("OrganizationLookup", obj, ReceivedByOfficeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Nationality(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.NationalityLookup.Clear();
                
                obj.NationalityLookup.Add(NationalityAccessor.CreateNewT(manager, null));
                
                obj.NationalityLookup.AddRange(NationalityAccessor.rftNationality_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsNationality))
                    
                    .ToList());
                
                if (obj.idfsNationality != null && obj.idfsNationality != 0)
                {
                    obj.Nationality = obj.NationalityLookup
                        .Where(c => c.idfsBaseReference == obj.idfsNationality)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftNationality", obj, NationalityAccessor.GetType(), "rftNationality_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_PatientState(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.PatientStateLookup.Clear();
                
                obj.PatientStateLookup.Add(PatientStateAccessor.CreateNewT(manager, null));
                
                obj.PatientStateLookup.AddRange(PatientStateAccessor.rftFinalState_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsFinalState))
                    
                    .ToList());
                
                if (obj.idfsFinalState != null && obj.idfsFinalState != 0)
                {
                    obj.PatientState = obj.PatientStateLookup
                        .Where(c => c.idfsBaseReference == obj.idfsFinalState)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftFinalState", obj, PatientStateAccessor.GetType(), "rftFinalState_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_PatientLocationType(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.PatientLocationTypeLookup.Clear();
                
                obj.PatientLocationTypeLookup.Add(PatientLocationTypeAccessor.CreateNewT(manager, null));
                
                obj.PatientLocationTypeLookup.AddRange(PatientLocationTypeAccessor.rftHospStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsHospitalizationStatus))
                    
                    .ToList());
                
                if (obj.idfsHospitalizationStatus != null && obj.idfsHospitalizationStatus != 0)
                {
                    obj.PatientLocationType = obj.PatientLocationTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsHospitalizationStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftHospStatus", obj, PatientLocationTypeAccessor.GetType(), "rftHospStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_InitialCaseStatus(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                obj.InitialCaseStatusLookup.Clear();
                
                obj.InitialCaseStatusLookup.Add(InitialCaseStatusAccessor.CreateNewT(manager, null));
                
                obj.InitialCaseStatusLookup.AddRange(InitialCaseStatusAccessor.rftCaseStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsInitialCaseStatus))
                    
                    .ToList());
                
                if (obj.idfsInitialCaseStatus != null && obj.idfsInitialCaseStatus != 0)
                {
                    obj.InitialCaseStatus = obj.InitialCaseStatusLookup
                        .Where(c => c.idfsBaseReference == obj.idfsInitialCaseStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftCaseStatus", obj, InitialCaseStatusAccessor.GetType(), "rftCaseStatus_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, HumanCaseListItem obj)
            {
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_TentativeDiagnosis(manager, obj);
                
                LoadLookup_FinalDiagnosis(manager, obj);
                
                LoadLookup_CaseStatus(manager, obj);
                
                LoadLookup_CaseProgressStatus(manager, obj);
                
                LoadLookup_HumanAgeType(manager, obj);
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Settlement(manager, obj);
                
                LoadLookup_HumanGender(manager, obj);
                
                LoadLookup_SentByOffice(manager, obj);
                
                LoadLookup_ReceivedByOffice(manager, obj);
                
                LoadLookup_Nationality(manager, obj);
                
                LoadLookup_PatientState(manager, obj);
                
                LoadLookup_PatientLocationType(manager, obj);
                
                LoadLookup_InitialCaseStatus(manager, obj);
                
            }
    
            [SprocName("spHumanCase_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spHumanCase_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    HumanCaseListItem bo = obj as HumanCaseListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("HumanCase", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("HumanCase", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("HumanCase", "Update");
                    }
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        long mainObject = bo.idfCase;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeDelete;
                            
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeCreate;
                            
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeEdit;
                            
                        }
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoHumanCase;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbHumanCase;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as HumanCaseListItem, bChildObject);
                    if (bTransactionStarted)
                    {
                        if (bSuccess)
                        {
                            manager.CommitTransaction();
                            
                        }
                        else
                        {
                            manager.RollbackTransaction();
                        }
                        
                    }
                    if (bSuccess && bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        bo.m_IsNew = false;
                    }
                    if (bSuccess && bTransactionStarted)
                    {
                        bo.OnAfterPost();
                    }
                }
                catch(Exception e)
                {
                    if (bTransactionStarted)
                    {
                        manager.RollbackTransaction();
                        
                    }
                    
                    if (e is DataException)
                    {
                        throw DbModelException.Create(e as DataException);
                    }
                    else 
                        throw;
                }
                return bSuccess;
            }
            private bool _PostNonTransaction(DbManagerProxy manager, HumanCaseListItem obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfCase
                        );
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(HumanCaseListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, HumanCaseListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfCase
                            , out result
                            );
                        if (!result) 
                        {
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, false);
                        }
                     }
                }
                catch(ValidationModelException ex)
                {
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                        return false;
                    }
                    else
                        obj.m_IsForcedToDelete = true;
                }
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as HumanCaseListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, HumanCaseListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(HumanCaseListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(HumanCaseListItem obj)
    {
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName))
      {
      
            obj
              .AddHiddenPersonalData("PatientName", c=>true);
            
            obj
              .AddHiddenPersonalData("strLastName", c=>true);
            
            obj
              .AddHiddenPersonalData("strFirstName", c=>true);
            
            obj
              .AddHiddenPersonalData("strMiddleName", c=>true);
            
            obj
              .AddHiddenPersonalData("strSecondName", c=>true);
            
            obj
              .AddHiddenPersonalData("strName", c=>true);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonSex))
      {
      
            obj
              .AddHiddenPersonalData("idfsHumanGender", c=>true);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonAge))
      {
      
            obj
              .AddHiddenPersonalData("datDateofBirth", c=>true);
            
            obj
              .AddHiddenPersonalData("Age", c=>true);
            
            obj
              .AddHiddenPersonalData("datDateofBirth", c=>true);
            
            obj
              .AddHiddenPersonalData("intPatientAgeFromCase", c=>true);
            
            obj
              .AddHiddenPersonalData("idfsHumanAgeTypeFromCase", c=>true);
            
            obj
              .AddHiddenPersonalData("HumanAgeType", c=>true);
            
            obj
              .AddHiddenPersonalData("intPatientAge", c=>true);
            
            obj
              .AddHiddenPersonalData("idfsHumanAgeType", c=>true);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_CurrentResidence_Details))
      {
      
            obj
              .AddHiddenPersonalData("GeoLocationName", c=>true);
            
            obj
              .AddHiddenPersonalData("PostCode", c=>true);
            
            obj
              .AddHiddenPersonalData("Street", c=>true);
            
            obj
              .AddHiddenPersonalData("strPostCode", c=>true);
            
            obj
              .AddHiddenPersonalData("strStreetName", c=>true);
            
            obj
              .AddHiddenPersonalData("strApartment", c=>true);
            
            obj
              .AddHiddenPersonalData("strHouse", c=>true);
            
            obj
              .AddHiddenPersonalData("strBuilding", c=>true);
            
            obj
              .AddHiddenPersonalData("strHomePhone", c=>true);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_CurrentResidence_Settlement))
      {
      
            obj
              .AddHiddenPersonalData("idfsSettlement", c=>true);
            
            obj
              .AddHiddenPersonalData("Settlement", c=>true);
            
            obj
              .AddHiddenPersonalData("GeoLocationName", c=>true);
            
            obj
              .AddHiddenPersonalData("PostCode", c=>true);
            
            obj
              .AddHiddenPersonalData("Street", c=>true);
            
            obj
              .AddHiddenPersonalData("strPostCode", c=>true);
            
            obj
              .AddHiddenPersonalData("strStreetName", c=>true);
            
            obj
              .AddHiddenPersonalData("strApartment", c=>true);
            
            obj
              .AddHiddenPersonalData("strHouse", c=>true);
            
            obj
              .AddHiddenPersonalData("strBuilding", c=>true);
            
            obj
              .AddHiddenPersonalData("strHomePhone", c=>true);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Employer_Details))
      {
      
            obj
              .AddHiddenPersonalData("strEmployerName", c=>true);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Employer_Settlement))
      {
      
            obj
              .AddHiddenPersonalData("strEmployerName", c=>true);
            
      }
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as HumanCaseListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as HumanCaseListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "HumanCaseListItemDetail"; } }
            public string HelpIdWin { get { return "HumanCaseListForm"; } }
            public string HelpIdWeb { get { return "web_humancaselistform"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private HumanCaseListItem m_obj;
            internal Permissions(HumanCaseListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_HumanCase_SelectList";
            public static string spCount = "spHumanCase_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spHumanCase_Delete";
            public static string spCanDelete = "spHumanCase_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<HumanCaseListItem, bool>> RequiredByField = new Dictionary<string, Func<HumanCaseListItem, bool>>();
            public static Dictionary<string, Func<HumanCaseListItem, bool>> RequiredByProperty = new Dictionary<string, Func<HumanCaseListItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_DiagnosisName, 2000);
                Sizes.Add(_str_CaseStatusName, 2000);
                Sizes.Add(_str_CaseProgressStatusName, 2000);
                Sizes.Add(_str_strCaseID, 200);
                Sizes.Add(_str_strLocalIdentifier, 200);
                Sizes.Add(_str_strLastName, 200);
                Sizes.Add(_str_strFirstName, 200);
                Sizes.Add(_str_strSecondName, 200);
                Sizes.Add(_str_PatientName, 602);
                Sizes.Add(_str_Age, 2013);
                Sizes.Add(_str_GeoLocationName, 2000);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfPerson",
                    EditorType.Flag,
                    false, false, 
                    "lblMyCases",
                    null, null, false, false, SearchPanelLocation.Main, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strCaseID",
                    EditorType.Text,
                    false, false, 
                    "strCaseID",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strLocalIdentifier",
                    EditorType.Text,
                    false, false, 
                    "strLocalIdentifier",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsDiagnosis",
                    EditorType.Lookup,
                    false, false, 
                    "FinalDiagnosisName",
                    null, null, false, true, SearchPanelLocation.Main, false, null, "DiagnosisLookup", typeof(DiagnosisLookup), (o) => { var c = (DiagnosisLookup)o; return c.idfsDiagnosis; }, (o) => { var c = (DiagnosisLookup)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsCaseStatus",
                    EditorType.Lookup,
                    false, false, 
                    "CaseStatusName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "CaseStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsCaseProgressStatus",
                    EditorType.Lookup,
                    false, false, 
                    "CaseProgressStatusName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "CaseProgressStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strLastName",
                    EditorType.Text,
                    false, false, 
                    "strLastName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFirstName",
                    EditorType.Text,
                    false, false, 
                    "strFirstName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strSecondName",
                    EditorType.Text,
                    false, false, 
                    "strSecondName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datDateofBirth",
                    EditorType.Date,
                    true, false, 
                    "HumanCase.SearchPanel.datDateofBirth",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datEnteredDate",
                    EditorType.Date,
                    true, true, 
                    "datEnteredDateSearchPanel",
                    () => DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter), null, true, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRegion",
                    EditorType.Lookup,
                    false, false, 
                    "idfsRegion",
                    null, "=", false, false, SearchPanelLocation.Main, true, "idfsRayon", "RegionLookup", typeof(RegionLookup), (o) => { var c = (RegionLookup)o; return c.idfsRegion; }, (o) => { var c = (RegionLookup)o; return c.strRegionName; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRayon",
                    EditorType.Lookup,
                    false, false, 
                    "idfsRayon",
                    null, null, false, false, SearchPanelLocation.Main, true, "idfsSettlement", "RayonLookup", typeof(RayonLookup), (o) => { var c = (RayonLookup)o; return c.idfsRayon; }, (o) => { var c = (RayonLookup)o; return c.strRayonName; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSettlement",
                    EditorType.Lookup,
                    false, false, 
                    "strTownOrVillage",
                    null, null, false, false, SearchPanelLocation.Main, true, null, "SettlementLookup", typeof(SettlementLookup), (o) => { var c = (SettlementLookup)o; return c.idfsSettlement; }, (o) => { var c = (SettlementLookup)o; return c.strSettlementName; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfSentByOffice",
                    EditorType.Lookup,
                    false, false, 
                    "HumanCaseListItem.idfSentByOffice",
                    null, null, false, false, SearchPanelLocation.Additional, true, null, "SentByOfficeLookup", typeof(OrganizationLookup), (o) => { var c = (OrganizationLookup)o; return c.idfInstitution; }, (o) => { var c = (OrganizationLookup)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfReceivedByOffice",
                    EditorType.Lookup,
                    false, false, 
                    "HumanCaseListItem.idfReceivedByOffice",
                    null, null, false, false, SearchPanelLocation.Additional, true, null, "ReceivedByOfficeLookup", typeof(OrganizationLookup), (o) => { var c = (OrganizationLookup)o; return c.idfInstitution; }, (o) => { var c = (OrganizationLookup)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTentativeDiagnosis",
                    EditorType.Lookup,
                    false, false, 
                    "idfsTentativeDiagnosis",
                    null, null, false, false, SearchPanelLocation.Additional, true, null, "TentativeDiagnosisLookup", typeof(DiagnosisLookup), (o) => { var c = (DiagnosisLookup)o; return c.idfsDiagnosis; }, (o) => { var c = (DiagnosisLookup)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datTentativeDiagnosisDate",
                    EditorType.Date,
                    true, false, 
                    "datTentativeDiagnosisDate",
                    null, null, false, false, SearchPanelLocation.Additional, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsFinalDiagnosis",
                    EditorType.Lookup,
                    false, false, 
                    "strChangedDiagnosis",
                    null, null, false, false, SearchPanelLocation.Additional, true, null, "FinalDiagnosisLookup", typeof(DiagnosisLookup), (o) => { var c = (DiagnosisLookup)o; return c.idfsDiagnosis; }, (o) => { var c = (DiagnosisLookup)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datFinalDiagnosisDate",
                    EditorType.Date,
                    true, false, 
                    "strDatChangedDiagnosis",
                    null, null, false, false, SearchPanelLocation.Additional, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFieldBarcode",
                    EditorType.Text,
                    false, false, 
                    "strFieldBarcodeLocal",
                    null, "=", false, false, SearchPanelLocation.Additional, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strCaseID",
                    EditorType.Text,
                    false, false, 
                    "strCaseID",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsCaseProgressStatus",
                    EditorType.Lookup,
                    false, false, 
                    "CaseProgressStatusName",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, "CaseProgressStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datEnteredDate",
                    EditorType.Date,
                    false, false, 
                    "datEnteredDateFull",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datModificationDate",
                    EditorType.Date,
                    false, false, 
                    "datModificationDate",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datCompletionPaperFormDate",
                    EditorType.Date,
                    false, false, 
                    "datCompletionPaperFormDate",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strLocalIdentifier",
                    EditorType.Text,
                    false, false, 
                    "strLocalIdentifier",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strLastName",
                    EditorType.Text,
                    false, false, 
                    "strLastName",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFirstName",
                    EditorType.Text,
                    false, false, 
                    "strFirstName",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strSecondName",
                    EditorType.Text,
                    false, false, 
                    "strSecondName",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datDateofBirth",
                    EditorType.Date,
                    false, false, 
                    "datDateofBirth",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "intPatientAge",
                    EditorType.Numeric,
                    false, false, 
                    "Age",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsHumanAgeType",
                    EditorType.Lookup,
                    false, false, 
                    "idfsHumanAgeType",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, "HumanAgeTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsHumanGender",
                    EditorType.Lookup,
                    false, false, 
                    "idfsHumanGender",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, "HumanGenderLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strHomePhone",
                    EditorType.Text,
                    false, false, 
                    "strHomePhone",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsNationality",
                    EditorType.Lookup,
                    false, false, 
                    "idfsNationality",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, "NationalityLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strEmployerName",
                    EditorType.Text,
                    false, false, 
                    "strEmployerName",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datFacilityLastVisit",
                    EditorType.Date,
                    false, false, 
                    "HumanCaseListItem.datFacilityLastVisit",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datOnSetDate",
                    EditorType.Date,
                    false, false, 
                    "datOnSetDate",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsFinalState",
                    EditorType.Lookup,
                    false, false, 
                    "idfsFinalState",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, "PatientStateLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsHospitalizationStatus",
                    EditorType.Lookup,
                    false, false, 
                    "idfsHospitalizationStatus",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, "PatientLocationTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strCurrentLocation",
                    EditorType.Text,
                    false, false, 
                    "strCurrentLocation",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strNote",
                    EditorType.Text,
                    false, false, 
                    "strAdditionalInformation",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datNotificationDate",
                    EditorType.Date,
                    false, false, 
                    "datNotificationDate",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strSentByFirst",
                    EditorType.Text,
                    false, false, 
                    "strSentByFirst",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strSentByPatronimyc",
                    EditorType.Text,
                    false, false, 
                    "strSentByPatronimyc",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strSentByLast",
                    EditorType.Text,
                    false, false, 
                    "strSentByLast",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strReceivedByFirst",
                    EditorType.Text,
                    false, false, 
                    "strReceivedByFirst",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strReceivedByPatronimyc",
                    EditorType.Text,
                    false, false, 
                    "strReceivedByPatronimyc",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strReceivedByLast",
                    EditorType.Text,
                    false, false, 
                    "strReceivedByLast",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "uidOfflineCaseID",
                    EditorType.Text,
                    false, false, 
                    "",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfCase,
                    _str_idfCase, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCaseID,
                    _str_strCaseID, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datEnteredDate,
                    "datEnteredDateSearchPanel", null, true, true, ListSortDirection.Descending
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DiagnosisName,
                    "FinalDiagnosisName", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_CaseStatusName,
                    _str_CaseStatusName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_GeoLocationName,
                    _str_GeoLocationName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_PatientName,
                    _str_PatientName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datDateofBirth,
                    _str_datDateofBirth, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Age,
                    _str_Age, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_CaseProgressStatusName,
                    _str_CaseProgressStatusName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsSettlement,
                    _str_idfsSettlement, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsRegion,
                    _str_idfsRegion, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsRayon,
                    _str_idfsRayon, null, false, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "ActionEditHumanCase",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ActionEditHumanCase(manager, (HumanCaseListItem)c, pars),
                        
                    null,
                    
                    null,
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "SelectAll",
                    ActionTypes.SelectAll,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelectAll_Id",
                        "selectall",
                        /*from BvMessages*/"tooltipSelectAll_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSelectAll_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Select",
                    ActionTypes.Select,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelect_Id",
                        "select",
                        /*from BvMessages*/"tooltipSelect_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSelect_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<HumanCase>().CreateNew(manager, null, pars == null ? null : (int?)pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Edit",
                    ActionTypes.Edit,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<HumanCase>().SelectDetail(manager, pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strEdit_Id",
                        "edit",
                        /*from BvMessages*/"tooltipEdit_Id",
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"tooltipEdit_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => 
                        {
                            if (c == null)
                            {
                                c = ObjectAccessor.CreatorInterface<HumanCaseListItem>().CreateWithParams(manager, null, pars);
                                ((HumanCaseListItem)c).idfCase = (long)pars[0];
                                ((HumanCaseListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((HumanCaseListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<HumanCaseListItem>().Post(manager, (HumanCaseListItem)c), c);
                        }
                                            ,
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Refresh",
                    ActionTypes.Refresh,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strRefresh_Id",
                        "iconRefresh_Id",
                        /*from BvMessages*/"tooltipRefresh_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipRefresh_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Close",
                    ActionTypes.Close,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strClose_Id",
                        "Close",
                        /*from BvMessages*/"tooltipClose_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipClose_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Report",
                    ActionTypes.Report,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strReport_Id",
                        "Report",
                        /*from BvMessages*/"tooltipReport_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipReport_Id",
                        ActionsAlignment.Left,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	