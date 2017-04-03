#pragma warning disable 0472
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
    public abstract partial class LabSampleReceive : 
        EditableObject<LabSampleReceive>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_ID), NonUpdatable, PrimaryKey]
        public abstract Int64 ID { get; set; }
                
        [LocalizedDisplayName(_str_IDCase)]
        [MapField(_str_IDCase)]
        public abstract Int64 IDCase { get; set; }
        #if MONO
        protected Int64 IDCase_Original { get { return IDCase; } }
        protected Int64 IDCase_Previous { get { return IDCase; } }
        #else
        protected Int64 IDCase_Original { get { return ((EditableValue<Int64>)((dynamic)this)._iDCase).OriginalValue; } }
        protected Int64 IDCase_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._iDCase).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64? idfCase { get; set; }
        #if MONO
        protected Int64? idfCase_Original { get { return idfCase; } }
        protected Int64? idfCase_Previous { get { return idfCase; } }
        #else
        protected Int64? idfCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64? idfCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCaseType)]
        [MapField(_str_idfsCaseType)]
        public abstract Int64? idfsCaseType { get; set; }
        #if MONO
        protected Int64? idfsCaseType_Original { get { return idfsCaseType; } }
        protected Int64? idfsCaseType_Previous { get { return idfsCaseType; } }
        #else
        protected Int64? idfsCaseType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).OriginalValue; } }
        protected Int64? idfsCaseType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfMonitoringSession)]
        [MapField(_str_idfMonitoringSession)]
        public abstract Int64? idfMonitoringSession { get; set; }
        #if MONO
        protected Int64? idfMonitoringSession_Original { get { return idfMonitoringSession; } }
        protected Int64? idfMonitoringSession_Previous { get { return idfMonitoringSession; } }
        #else
        protected Int64? idfMonitoringSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).OriginalValue; } }
        protected Int64? idfMonitoringSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strMonitoringSessionID)]
        [MapField(_str_strMonitoringSessionID)]
        public abstract String strMonitoringSessionID { get; set; }
        #if MONO
        protected String strMonitoringSessionID_Original { get { return strMonitoringSessionID; } }
        protected String strMonitoringSessionID_Previous { get { return strMonitoringSessionID; } }
        #else
        protected String strMonitoringSessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strMonitoringSessionID).OriginalValue; } }
        protected String strMonitoringSessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strMonitoringSessionID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCampaignID)]
        [MapField(_str_strCampaignID)]
        public abstract String strCampaignID { get; set; }
        #if MONO
        protected String strCampaignID_Original { get { return strCampaignID; } }
        protected String strCampaignID_Previous { get { return strCampaignID; } }
        #else
        protected String strCampaignID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCampaignID).OriginalValue; } }
        protected String strCampaignID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCampaignID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCampaignName)]
        [MapField(_str_strCampaignName)]
        public abstract String strCampaignName { get; set; }
        #if MONO
        protected String strCampaignName_Original { get { return strCampaignName; } }
        protected String strCampaignName_Previous { get { return strCampaignName; } }
        #else
        protected String strCampaignName_Original { get { return ((EditableValue<String>)((dynamic)this)._strCampaignName).OriginalValue; } }
        protected String strCampaignName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCampaignName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_SessionStatus)]
        [MapField(_str_SessionStatus)]
        public abstract String SessionStatus { get; set; }
        #if MONO
        protected String SessionStatus_Original { get { return SessionStatus; } }
        protected String SessionStatus_Previous { get { return SessionStatus; } }
        #else
        protected String SessionStatus_Original { get { return ((EditableValue<String>)((dynamic)this)._sessionStatus).OriginalValue; } }
        protected String SessionStatus_Previous { get { return ((EditableValue<String>)((dynamic)this)._sessionStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_CampaignType)]
        [MapField(_str_CampaignType)]
        public abstract String CampaignType { get; set; }
        #if MONO
        protected String CampaignType_Original { get { return CampaignType; } }
        protected String CampaignType_Previous { get { return CampaignType; } }
        #else
        protected String CampaignType_Original { get { return ((EditableValue<String>)((dynamic)this)._campaignType).OriginalValue; } }
        protected String CampaignType_Previous { get { return ((EditableValue<String>)((dynamic)this)._campaignType).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_datOnSetDate)]
        [MapField(_str_datOnSetDate)]
        public abstract DateTime? datOnSetDate { get; set; }
        #if MONO
        protected DateTime? datOnSetDate_Original { get { return datOnSetDate; } }
        protected DateTime? datOnSetDate_Previous { get { return datOnSetDate; } }
        #else
        protected DateTime? datOnSetDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datOnSetDate).OriginalValue; } }
        protected DateTime? datOnSetDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datOnSetDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSampleNotes)]
        [MapField(_str_strSampleNotes)]
        public abstract String strSampleNotes { get; set; }
        #if MONO
        protected String strSampleNotes_Original { get { return strSampleNotes; } }
        protected String strSampleNotes_Previous { get { return strSampleNotes; } }
        #else
        protected String strSampleNotes_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleNotes).OriginalValue; } }
        protected String strSampleNotes_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleNotes).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strLocalId")]
        [MapField(_str_strLocalIdentifier)]
        public abstract String strLocalIdentifier { get; set; }
        #if MONO
        protected String strLocalIdentifier_Original { get { return strLocalIdentifier; } }
        protected String strLocalIdentifier_Previous { get { return strLocalIdentifier; } }
        #else
        protected String strLocalIdentifier_Original { get { return ((EditableValue<String>)((dynamic)this)._strLocalIdentifier).OriginalValue; } }
        protected String strLocalIdentifier_Previous { get { return ((EditableValue<String>)((dynamic)this)._strLocalIdentifier).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strFieldAccessionID)]
        [MapField(_str_strFieldAccessionID)]
        public abstract String strFieldAccessionID { get; set; }
        #if MONO
        protected String strFieldAccessionID_Original { get { return strFieldAccessionID; } }
        protected String strFieldAccessionID_Previous { get { return strFieldAccessionID; } }
        #else
        protected String strFieldAccessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldAccessionID).OriginalValue; } }
        protected String strFieldAccessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldAccessionID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_FarmAddress)]
        [MapField(_str_FarmAddress)]
        public abstract String FarmAddress { get; set; }
        #if MONO
        protected String FarmAddress_Original { get { return FarmAddress; } }
        protected String FarmAddress_Previous { get { return FarmAddress; } }
        #else
        protected String FarmAddress_Original { get { return ((EditableValue<String>)((dynamic)this)._farmAddress).OriginalValue; } }
        protected String FarmAddress_Previous { get { return ((EditableValue<String>)((dynamic)this)._farmAddress).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strNationalName)]
        [MapField(_str_strNationalName)]
        public abstract String strNationalName { get; set; }
        #if MONO
        protected String strNationalName_Original { get { return strNationalName; } }
        protected String strNationalName_Previous { get { return strNationalName; } }
        #else
        protected String strNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._strNationalName).OriginalValue; } }
        protected String strNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNationalName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_FarmOwner)]
        [MapField(_str_FarmOwner)]
        public abstract String FarmOwner { get; set; }
        #if MONO
        protected String FarmOwner_Original { get { return FarmOwner; } }
        protected String FarmOwner_Previous { get { return FarmOwner; } }
        #else
        protected String FarmOwner_Original { get { return ((EditableValue<String>)((dynamic)this)._farmOwner).OriginalValue; } }
        protected String FarmOwner_Previous { get { return ((EditableValue<String>)((dynamic)this)._farmOwner).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfHuman)]
        [MapField(_str_idfHuman)]
        public abstract Int64? idfHuman { get; set; }
        #if MONO
        protected Int64? idfHuman_Original { get { return idfHuman; } }
        protected Int64? idfHuman_Previous { get { return idfHuman; } }
        #else
        protected Int64? idfHuman_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHuman).OriginalValue; } }
        protected Int64? idfHuman_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHuman).PreviousValue; } }
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
                
        [LocalizedDisplayName("idfsDiagnosis")]
        [MapField(_str_idfsInitialDiagnosis)]
        public abstract String idfsInitialDiagnosis { get; set; }
        #if MONO
        protected String idfsInitialDiagnosis_Original { get { return idfsInitialDiagnosis; } }
        protected String idfsInitialDiagnosis_Previous { get { return idfsInitialDiagnosis; } }
        #else
        protected String idfsInitialDiagnosis_Original { get { return ((EditableValue<String>)((dynamic)this)._idfsInitialDiagnosis).OriginalValue; } }
        protected String idfsInitialDiagnosis_Previous { get { return ((EditableValue<String>)((dynamic)this)._idfsInitialDiagnosis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("titleCurrentResidence")]
        [MapField(_str_CurrentResidence)]
        public abstract String CurrentResidence { get; set; }
        #if MONO
        protected String CurrentResidence_Original { get { return CurrentResidence; } }
        protected String CurrentResidence_Previous { get { return CurrentResidence; } }
        #else
        protected String CurrentResidence_Original { get { return ((EditableValue<String>)((dynamic)this)._currentResidence).OriginalValue; } }
        protected String CurrentResidence_Previous { get { return ((EditableValue<String>)((dynamic)this)._currentResidence).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_datDiagnosisDate)]
        [MapField(_str_datDiagnosisDate)]
        public abstract DateTime? datDiagnosisDate { get; set; }
        #if MONO
        protected DateTime? datDiagnosisDate_Original { get { return datDiagnosisDate; } }
        protected DateTime? datDiagnosisDate_Previous { get { return datDiagnosisDate; } }
        #else
        protected DateTime? datDiagnosisDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDiagnosisDate).OriginalValue; } }
        protected DateTime? datDiagnosisDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDiagnosisDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfVectorSurveillanceSession)]
        [MapField(_str_idfVectorSurveillanceSession)]
        public abstract Int64? idfVectorSurveillanceSession { get; set; }
        #if MONO
        protected Int64? idfVectorSurveillanceSession_Original { get { return idfVectorSurveillanceSession; } }
        protected Int64? idfVectorSurveillanceSession_Previous { get { return idfVectorSurveillanceSession; } }
        #else
        protected Int64? idfVectorSurveillanceSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).OriginalValue; } }
        protected Int64? idfVectorSurveillanceSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSessionID)]
        [MapField(_str_strSessionID)]
        public abstract String strSessionID { get; set; }
        #if MONO
        protected String strSessionID_Original { get { return strSessionID; } }
        protected String strSessionID_Previous { get { return strSessionID; } }
        #else
        protected String strSessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strSessionID).OriginalValue; } }
        protected String strSessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSessionID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strRegion)]
        [MapField(_str_strRegion)]
        public abstract String strRegion { get; set; }
        #if MONO
        protected String strRegion_Original { get { return strRegion; } }
        protected String strRegion_Previous { get { return strRegion; } }
        #else
        protected String strRegion_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegion).OriginalValue; } }
        protected String strRegion_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegion).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strRayon)]
        [MapField(_str_strRayon)]
        public abstract String strRayon { get; set; }
        #if MONO
        protected String strRayon_Original { get { return strRayon; } }
        protected String strRayon_Previous { get { return strRayon; } }
        #else
        protected String strRayon_Original { get { return ((EditableValue<String>)((dynamic)this)._strRayon).OriginalValue; } }
        protected String strRayon_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRayon).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSettlement)]
        [MapField(_str_strSettlement)]
        public abstract String strSettlement { get; set; }
        #if MONO
        protected String strSettlement_Original { get { return strSettlement; } }
        protected String strSettlement_Previous { get { return strSettlement; } }
        #else
        protected String strSettlement_Original { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).OriginalValue; } }
        protected String strSettlement_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<LabSampleReceive, object> _get_func;
            internal Action<LabSampleReceive, string> _set_func;
            internal Action<LabSampleReceive, LabSampleReceive, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_ID = "ID";
        internal const string _str_IDCase = "IDCase";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_strMonitoringSessionID = "strMonitoringSessionID";
        internal const string _str_strCampaignID = "strCampaignID";
        internal const string _str_strCampaignName = "strCampaignName";
        internal const string _str_SessionStatus = "SessionStatus";
        internal const string _str_CampaignType = "CampaignType";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_datOnSetDate = "datOnSetDate";
        internal const string _str_strSampleNotes = "strSampleNotes";
        internal const string _str_strLocalIdentifier = "strLocalIdentifier";
        internal const string _str_strFieldAccessionID = "strFieldAccessionID";
        internal const string _str_FarmAddress = "FarmAddress";
        internal const string _str_strNationalName = "strNationalName";
        internal const string _str_FarmOwner = "FarmOwner";
        internal const string _str_PatientName = "PatientName";
        internal const string _str_idfHuman = "idfHuman";
        internal const string _str_Age = "Age";
        internal const string _str_idfsInitialDiagnosis = "idfsInitialDiagnosis";
        internal const string _str_CurrentResidence = "CurrentResidence";
        internal const string _str_datDateofBirth = "datDateofBirth";
        internal const string _str_datDiagnosisDate = "datDiagnosisDate";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_strSessionID = "strSessionID";
        internal const string _str_strRegion = "strRegion";
        internal const string _str_strRayon = "strRayon";
        internal const string _str_strSettlement = "strSettlement";
        internal const string _str_strAntibiotics = "strAntibiotics";
        internal const string _str_Samples = "Samples";
        internal const string _str_Animals = "Animals";
        internal const string _str_Antibiotics = "Antibiotics";
        internal const string _str_Vectors = "Vectors";
        internal const string _str_Diagnosis = "Diagnosis";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_ID, _type = "Int64",
              _get_func = o => o.ID,
              _set_func = (o, val) => { o.ID = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.ID != c.ID || o.IsRIRPropChanged(_str_ID, c)) 
                  m.Add(_str_ID, o.ObjectIdent + _str_ID, "Int64", o.ID == null ? "" : o.ID.ToString(), o.IsReadOnly(_str_ID), o.IsInvisible(_str_ID), o.IsRequired(_str_ID)); }
              }, 
        
            new field_info {
              _name = _str_IDCase, _type = "Int64",
              _get_func = o => o.IDCase,
              _set_func = (o, val) => { o.IDCase = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.IDCase != c.IDCase || o.IsRIRPropChanged(_str_IDCase, c)) 
                  m.Add(_str_IDCase, o.ObjectIdent + _str_IDCase, "Int64", o.IDCase == null ? "" : o.IDCase.ToString(), o.IsReadOnly(_str_IDCase), o.IsInvisible(_str_IDCase), o.IsRequired(_str_IDCase)); }
              }, 
        
            new field_info {
              _name = _str_idfCase, _type = "Int64?",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { o.idfCase = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, "Int64?", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); }
              }, 
        
            new field_info {
              _name = _str_idfsCaseType, _type = "Int64?",
              _get_func = o => o.idfsCaseType,
              _set_func = (o, val) => { o.idfsCaseType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_idfsCaseType, c)) 
                  m.Add(_str_idfsCaseType, o.ObjectIdent + _str_idfsCaseType, "Int64?", o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(), o.IsReadOnly(_str_idfsCaseType), o.IsInvisible(_str_idfsCaseType), o.IsRequired(_str_idfsCaseType)); }
              }, 
        
            new field_info {
              _name = _str_idfMonitoringSession, _type = "Int64?",
              _get_func = o => o.idfMonitoringSession,
              _set_func = (o, val) => { o.idfMonitoringSession = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfMonitoringSession != c.idfMonitoringSession || o.IsRIRPropChanged(_str_idfMonitoringSession, c)) 
                  m.Add(_str_idfMonitoringSession, o.ObjectIdent + _str_idfMonitoringSession, "Int64?", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_idfMonitoringSession), o.IsInvisible(_str_idfMonitoringSession), o.IsRequired(_str_idfMonitoringSession)); }
              }, 
        
            new field_info {
              _name = _str_strMonitoringSessionID, _type = "String",
              _get_func = o => o.strMonitoringSessionID,
              _set_func = (o, val) => { o.strMonitoringSessionID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strMonitoringSessionID != c.strMonitoringSessionID || o.IsRIRPropChanged(_str_strMonitoringSessionID, c)) 
                  m.Add(_str_strMonitoringSessionID, o.ObjectIdent + _str_strMonitoringSessionID, "String", o.strMonitoringSessionID == null ? "" : o.strMonitoringSessionID.ToString(), o.IsReadOnly(_str_strMonitoringSessionID), o.IsInvisible(_str_strMonitoringSessionID), o.IsRequired(_str_strMonitoringSessionID)); }
              }, 
        
            new field_info {
              _name = _str_strCampaignID, _type = "String",
              _get_func = o => o.strCampaignID,
              _set_func = (o, val) => { o.strCampaignID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCampaignID != c.strCampaignID || o.IsRIRPropChanged(_str_strCampaignID, c)) 
                  m.Add(_str_strCampaignID, o.ObjectIdent + _str_strCampaignID, "String", o.strCampaignID == null ? "" : o.strCampaignID.ToString(), o.IsReadOnly(_str_strCampaignID), o.IsInvisible(_str_strCampaignID), o.IsRequired(_str_strCampaignID)); }
              }, 
        
            new field_info {
              _name = _str_strCampaignName, _type = "String",
              _get_func = o => o.strCampaignName,
              _set_func = (o, val) => { o.strCampaignName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCampaignName != c.strCampaignName || o.IsRIRPropChanged(_str_strCampaignName, c)) 
                  m.Add(_str_strCampaignName, o.ObjectIdent + _str_strCampaignName, "String", o.strCampaignName == null ? "" : o.strCampaignName.ToString(), o.IsReadOnly(_str_strCampaignName), o.IsInvisible(_str_strCampaignName), o.IsRequired(_str_strCampaignName)); }
              }, 
        
            new field_info {
              _name = _str_SessionStatus, _type = "String",
              _get_func = o => o.SessionStatus,
              _set_func = (o, val) => { o.SessionStatus = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.SessionStatus != c.SessionStatus || o.IsRIRPropChanged(_str_SessionStatus, c)) 
                  m.Add(_str_SessionStatus, o.ObjectIdent + _str_SessionStatus, "String", o.SessionStatus == null ? "" : o.SessionStatus.ToString(), o.IsReadOnly(_str_SessionStatus), o.IsInvisible(_str_SessionStatus), o.IsRequired(_str_SessionStatus)); }
              }, 
        
            new field_info {
              _name = _str_CampaignType, _type = "String",
              _get_func = o => o.CampaignType,
              _set_func = (o, val) => { o.CampaignType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.CampaignType != c.CampaignType || o.IsRIRPropChanged(_str_CampaignType, c)) 
                  m.Add(_str_CampaignType, o.ObjectIdent + _str_CampaignType, "String", o.CampaignType == null ? "" : o.CampaignType.ToString(), o.IsReadOnly(_str_CampaignType), o.IsInvisible(_str_CampaignType), o.IsRequired(_str_CampaignType)); }
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
              _name = _str_datOnSetDate, _type = "DateTime?",
              _get_func = o => o.datOnSetDate,
              _set_func = (o, val) => { o.datOnSetDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datOnSetDate != c.datOnSetDate || o.IsRIRPropChanged(_str_datOnSetDate, c)) 
                  m.Add(_str_datOnSetDate, o.ObjectIdent + _str_datOnSetDate, "DateTime?", o.datOnSetDate == null ? "" : o.datOnSetDate.ToString(), o.IsReadOnly(_str_datOnSetDate), o.IsInvisible(_str_datOnSetDate), o.IsRequired(_str_datOnSetDate)); }
              }, 
        
            new field_info {
              _name = _str_strSampleNotes, _type = "String",
              _get_func = o => o.strSampleNotes,
              _set_func = (o, val) => { o.strSampleNotes = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSampleNotes != c.strSampleNotes || o.IsRIRPropChanged(_str_strSampleNotes, c)) 
                  m.Add(_str_strSampleNotes, o.ObjectIdent + _str_strSampleNotes, "String", o.strSampleNotes == null ? "" : o.strSampleNotes.ToString(), o.IsReadOnly(_str_strSampleNotes), o.IsInvisible(_str_strSampleNotes), o.IsRequired(_str_strSampleNotes)); }
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
              _name = _str_strFieldAccessionID, _type = "String",
              _get_func = o => o.strFieldAccessionID,
              _set_func = (o, val) => { o.strFieldAccessionID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFieldAccessionID != c.strFieldAccessionID || o.IsRIRPropChanged(_str_strFieldAccessionID, c)) 
                  m.Add(_str_strFieldAccessionID, o.ObjectIdent + _str_strFieldAccessionID, "String", o.strFieldAccessionID == null ? "" : o.strFieldAccessionID.ToString(), o.IsReadOnly(_str_strFieldAccessionID), o.IsInvisible(_str_strFieldAccessionID), o.IsRequired(_str_strFieldAccessionID)); }
              }, 
        
            new field_info {
              _name = _str_FarmAddress, _type = "String",
              _get_func = o => o.FarmAddress,
              _set_func = (o, val) => { o.FarmAddress = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.FarmAddress != c.FarmAddress || o.IsRIRPropChanged(_str_FarmAddress, c)) 
                  m.Add(_str_FarmAddress, o.ObjectIdent + _str_FarmAddress, "String", o.FarmAddress == null ? "" : o.FarmAddress.ToString(), o.IsReadOnly(_str_FarmAddress), o.IsInvisible(_str_FarmAddress), o.IsRequired(_str_FarmAddress)); }
              }, 
        
            new field_info {
              _name = _str_strNationalName, _type = "String",
              _get_func = o => o.strNationalName,
              _set_func = (o, val) => { o.strNationalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNationalName != c.strNationalName || o.IsRIRPropChanged(_str_strNationalName, c)) 
                  m.Add(_str_strNationalName, o.ObjectIdent + _str_strNationalName, "String", o.strNationalName == null ? "" : o.strNationalName.ToString(), o.IsReadOnly(_str_strNationalName), o.IsInvisible(_str_strNationalName), o.IsRequired(_str_strNationalName)); }
              }, 
        
            new field_info {
              _name = _str_FarmOwner, _type = "String",
              _get_func = o => o.FarmOwner,
              _set_func = (o, val) => { o.FarmOwner = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.FarmOwner != c.FarmOwner || o.IsRIRPropChanged(_str_FarmOwner, c)) 
                  m.Add(_str_FarmOwner, o.ObjectIdent + _str_FarmOwner, "String", o.FarmOwner == null ? "" : o.FarmOwner.ToString(), o.IsReadOnly(_str_FarmOwner), o.IsInvisible(_str_FarmOwner), o.IsRequired(_str_FarmOwner)); }
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
              _name = _str_idfHuman, _type = "Int64?",
              _get_func = o => o.idfHuman,
              _set_func = (o, val) => { o.idfHuman = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfHuman != c.idfHuman || o.IsRIRPropChanged(_str_idfHuman, c)) 
                  m.Add(_str_idfHuman, o.ObjectIdent + _str_idfHuman, "Int64?", o.idfHuman == null ? "" : o.idfHuman.ToString(), o.IsReadOnly(_str_idfHuman), o.IsInvisible(_str_idfHuman), o.IsRequired(_str_idfHuman)); }
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
              _name = _str_idfsInitialDiagnosis, _type = "String",
              _get_func = o => o.idfsInitialDiagnosis,
              _set_func = (o, val) => { o.idfsInitialDiagnosis = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsInitialDiagnosis != c.idfsInitialDiagnosis || o.IsRIRPropChanged(_str_idfsInitialDiagnosis, c)) 
                  m.Add(_str_idfsInitialDiagnosis, o.ObjectIdent + _str_idfsInitialDiagnosis, "String", o.idfsInitialDiagnosis == null ? "" : o.idfsInitialDiagnosis.ToString(), o.IsReadOnly(_str_idfsInitialDiagnosis), o.IsInvisible(_str_idfsInitialDiagnosis), o.IsRequired(_str_idfsInitialDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_CurrentResidence, _type = "String",
              _get_func = o => o.CurrentResidence,
              _set_func = (o, val) => { o.CurrentResidence = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.CurrentResidence != c.CurrentResidence || o.IsRIRPropChanged(_str_CurrentResidence, c)) 
                  m.Add(_str_CurrentResidence, o.ObjectIdent + _str_CurrentResidence, "String", o.CurrentResidence == null ? "" : o.CurrentResidence.ToString(), o.IsReadOnly(_str_CurrentResidence), o.IsInvisible(_str_CurrentResidence), o.IsRequired(_str_CurrentResidence)); }
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
              _name = _str_datDiagnosisDate, _type = "DateTime?",
              _get_func = o => o.datDiagnosisDate,
              _set_func = (o, val) => { o.datDiagnosisDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datDiagnosisDate != c.datDiagnosisDate || o.IsRIRPropChanged(_str_datDiagnosisDate, c)) 
                  m.Add(_str_datDiagnosisDate, o.ObjectIdent + _str_datDiagnosisDate, "DateTime?", o.datDiagnosisDate == null ? "" : o.datDiagnosisDate.ToString(), o.IsReadOnly(_str_datDiagnosisDate), o.IsInvisible(_str_datDiagnosisDate), o.IsRequired(_str_datDiagnosisDate)); }
              }, 
        
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _type = "Int64?",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { o.idfVectorSurveillanceSession = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, "Int64?", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); }
              }, 
        
            new field_info {
              _name = _str_strSessionID, _type = "String",
              _get_func = o => o.strSessionID,
              _set_func = (o, val) => { o.strSessionID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSessionID != c.strSessionID || o.IsRIRPropChanged(_str_strSessionID, c)) 
                  m.Add(_str_strSessionID, o.ObjectIdent + _str_strSessionID, "String", o.strSessionID == null ? "" : o.strSessionID.ToString(), o.IsReadOnly(_str_strSessionID), o.IsInvisible(_str_strSessionID), o.IsRequired(_str_strSessionID)); }
              }, 
        
            new field_info {
              _name = _str_strRegion, _type = "String",
              _get_func = o => o.strRegion,
              _set_func = (o, val) => { o.strRegion = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strRegion != c.strRegion || o.IsRIRPropChanged(_str_strRegion, c)) 
                  m.Add(_str_strRegion, o.ObjectIdent + _str_strRegion, "String", o.strRegion == null ? "" : o.strRegion.ToString(), o.IsReadOnly(_str_strRegion), o.IsInvisible(_str_strRegion), o.IsRequired(_str_strRegion)); }
              }, 
        
            new field_info {
              _name = _str_strRayon, _type = "String",
              _get_func = o => o.strRayon,
              _set_func = (o, val) => { o.strRayon = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strRayon != c.strRayon || o.IsRIRPropChanged(_str_strRayon, c)) 
                  m.Add(_str_strRayon, o.ObjectIdent + _str_strRayon, "String", o.strRayon == null ? "" : o.strRayon.ToString(), o.IsReadOnly(_str_strRayon), o.IsInvisible(_str_strRayon), o.IsRequired(_str_strRayon)); }
              }, 
        
            new field_info {
              _name = _str_strSettlement, _type = "String",
              _get_func = o => o.strSettlement,
              _set_func = (o, val) => { o.strSettlement = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSettlement != c.strSettlement || o.IsRIRPropChanged(_str_strSettlement, c)) 
                  m.Add(_str_strSettlement, o.ObjectIdent + _str_strSettlement, "String", o.strSettlement == null ? "" : o.strSettlement.ToString(), o.IsReadOnly(_str_strSettlement), o.IsInvisible(_str_strSettlement), o.IsRequired(_str_strSettlement)); }
              }, 
        
            new field_info {
              _name = _str_strAntibiotics, _type = "string",
              _get_func = o => o.strAntibiotics,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strAntibiotics != c.strAntibiotics || o.IsRIRPropChanged(_str_strAntibiotics, c)) 
                  m.Add(_str_strAntibiotics, o.ObjectIdent + _str_strAntibiotics, "string", o.strAntibiotics == null ? "" : o.strAntibiotics.ToString(), o.IsReadOnly(_str_strAntibiotics), o.IsInvisible(_str_strAntibiotics), o.IsRequired(_str_strAntibiotics));
                 }
              }, 
        
            new field_info {
              _name = _str_Samples, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Samples.Count != c.Samples.Count || o.IsReadOnly(_str_Samples) != c.IsReadOnly(_str_Samples) || o.IsInvisible(_str_Samples) != c.IsInvisible(_str_Samples) || o.IsRequired(_str_Samples) != c.IsRequired(_str_Samples)) 
                  m.Add(_str_Samples, o.ObjectIdent + _str_Samples, "Child", o.IDCase == null ? "" : o.IDCase.ToString(), o.IsReadOnly(_str_Samples), o.IsInvisible(_str_Samples), o.IsRequired(_str_Samples)); }
              }, 
        
            new field_info {
              _name = _str_Animals, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Animals.Count != c.Animals.Count || o.IsReadOnly(_str_Animals) != c.IsReadOnly(_str_Animals) || o.IsInvisible(_str_Animals) != c.IsInvisible(_str_Animals) || o.IsRequired(_str_Animals) != c.IsRequired(_str_Animals)) 
                  m.Add(_str_Animals, o.ObjectIdent + _str_Animals, "Child", o.IDCase == null ? "" : o.IDCase.ToString(), o.IsReadOnly(_str_Animals), o.IsInvisible(_str_Animals), o.IsRequired(_str_Animals)); }
              }, 
        
            new field_info {
              _name = _str_Antibiotics, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Antibiotics.Count != c.Antibiotics.Count || o.IsReadOnly(_str_Antibiotics) != c.IsReadOnly(_str_Antibiotics) || o.IsInvisible(_str_Antibiotics) != c.IsInvisible(_str_Antibiotics) || o.IsRequired(_str_Antibiotics) != c.IsRequired(_str_Antibiotics)) 
                  m.Add(_str_Antibiotics, o.ObjectIdent + _str_Antibiotics, "Child", o.IDCase == null ? "" : o.IDCase.ToString(), o.IsReadOnly(_str_Antibiotics), o.IsInvisible(_str_Antibiotics), o.IsRequired(_str_Antibiotics)); }
              }, 
        
            new field_info {
              _name = _str_Vectors, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Vectors.Count != c.Vectors.Count || o.IsReadOnly(_str_Vectors) != c.IsReadOnly(_str_Vectors) || o.IsInvisible(_str_Vectors) != c.IsInvisible(_str_Vectors) || o.IsRequired(_str_Vectors) != c.IsRequired(_str_Vectors)) 
                  m.Add(_str_Vectors, o.ObjectIdent + _str_Vectors, "Child", o.IDCase == null ? "" : o.IDCase.ToString(), o.IsReadOnly(_str_Vectors), o.IsInvisible(_str_Vectors), o.IsRequired(_str_Vectors)); }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Diagnosis.Count != c.Diagnosis.Count || o.IsReadOnly(_str_Diagnosis) != c.IsReadOnly(_str_Diagnosis) || o.IsInvisible(_str_Diagnosis) != c.IsInvisible(_str_Diagnosis) || o.IsRequired(_str_Diagnosis) != c.IsRequired(_str_Diagnosis)) 
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, "Child", o.IDCase == null ? "" : o.IDCase.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis)); }
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
            LabSampleReceive obj = (LabSampleReceive)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(LabSampleReceiveItem), eidss.model.Schema.LabSampleReceiveItem._str_ParentID, _str_IDCase)]
        public EditableList<LabSampleReceiveItem> Samples
        {
            get 
            {   
                return _Samples; 
            }
            set 
            {
                _Samples = value;
            }
        }
        protected EditableList<LabSampleReceiveItem> _Samples = new EditableList<LabSampleReceiveItem>();
                    
        [Relation(typeof(LabSampleReceiveAnimal), eidss.model.Schema.LabSampleReceiveAnimal._str_ParentID, _str_IDCase)]
        public EditableList<LabSampleReceiveAnimal> Animals
        {
            get 
            {   
                return _Animals; 
            }
            set 
            {
                _Animals = value;
            }
        }
        protected EditableList<LabSampleReceiveAnimal> _Animals = new EditableList<LabSampleReceiveAnimal>();
                    
        [Relation(typeof(LabSampleReceiveAntibiotic), eidss.model.Schema.LabSampleReceiveAntibiotic._str_idfHumanCase, _str_IDCase)]
        public EditableList<LabSampleReceiveAntibiotic> Antibiotics
        {
            get 
            {   
                return _Antibiotics; 
            }
            set 
            {
                _Antibiotics = value;
            }
        }
        protected EditableList<LabSampleReceiveAntibiotic> _Antibiotics = new EditableList<LabSampleReceiveAntibiotic>();
                    
        [Relation(typeof(LabSampleReceiveVector), eidss.model.Schema.LabSampleReceiveVector._str_ParentID, _str_IDCase)]
        public EditableList<LabSampleReceiveVector> Vectors
        {
            get 
            {   
                return _Vectors; 
            }
            set 
            {
                _Vectors = value;
            }
        }
        protected EditableList<LabSampleReceiveVector> _Vectors = new EditableList<LabSampleReceiveVector>();
                    
        [Relation(typeof(LabSampleReceiveDiagnosis), eidss.model.Schema.LabSampleReceiveDiagnosis._str_idfCase, _str_IDCase)]
        public EditableList<LabSampleReceiveDiagnosis> Diagnosis
        {
            get 
            {   
                return _Diagnosis; 
            }
            set 
            {
                _Diagnosis = value;
            }
        }
        protected EditableList<LabSampleReceiveDiagnosis> _Diagnosis = new EditableList<LabSampleReceiveDiagnosis>();
                    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strAntibiotics)]
        public string strAntibiotics
        {
            get { return new Func<LabSampleReceive, string>(c => c.Antibiotics.Aggregate("", (a,b) => (a == "" ? "" : a + ", ") + b.strAntimicrobialTherapyName))(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LabSampleReceive";

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
        Samples.ForEach(c => { c.Parent = this; });
                Animals.ForEach(c => { c.Parent = this; });
                Antibiotics.ForEach(c => { c.Parent = this; });
                Vectors.ForEach(c => { c.Parent = this; });
                Diagnosis.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as LabSampleReceive;
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
            var ret = base.Clone() as LabSampleReceive;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public LabSampleReceive CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabSampleReceive;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return ID; } }
        public string KeyName { get { return "ID"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || Samples.IsDirty
                    || Samples.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Animals.IsDirty
                    || Animals.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Antibiotics.IsDirty
                    || Antibiotics.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Vectors.IsDirty
                    || Vectors.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Diagnosis.IsDirty
                    || Diagnosis.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            base.RejectChanges();
        
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        Samples.RejectChanges();
                Animals.RejectChanges();
                Antibiotics.RejectChanges();
                Vectors.RejectChanges();
                Diagnosis.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        Samples.AcceptChanges();
                Animals.AcceptChanges();
                Antibiotics.AcceptChanges();
                Vectors.AcceptChanges();
                Diagnosis.AcceptChanges();
                
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
        Samples.ForEach(c => c.SetChange());
                Animals.ForEach(c => c.SetChange());
                Antibiotics.ForEach(c => c.SetChange());
                Vectors.ForEach(c => c.SetChange());
                Diagnosis.ForEach(c => c.SetChange());
                
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

      private bool IsRIRPropChanged(string fld, LabSampleReceive c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabSampleReceive()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabSampleReceive_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabSampleReceive_PropertyChanged);
        }
        private void LabSampleReceive_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabSampleReceive).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Antibiotics)
                OnPropertyChanged(_str_strAntibiotics);
                  
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
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            LabSampleReceive obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabSampleReceive obj = this;
            
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

    
        private static string[] readonly_names1 = "strSampleNotes,Samples".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strFieldCollectedByOffice,strFieldCollectedByPerson".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LabSampleReceive, bool>(c => false)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LabSampleReceive, bool>(c => true)(this);
            
            return ReadOnly || new Func<LabSampleReceive, bool>(c => true)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _Samples)
                    o.ReadOnly = value;
                
                foreach(var o in _Animals)
                    o.ReadOnly = value;
                
                foreach(var o in _Antibiotics)
                    o.ReadOnly = value;
                
                foreach(var o in _Vectors)
                    o.ReadOnly = value;
                
                foreach(var o in _Diagnosis)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<LabSampleReceive, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabSampleReceive, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabSampleReceive, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabSampleReceive, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabSampleReceive, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<LabSampleReceive, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LabSampleReceive()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
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
        
            if (_Samples != null) _Samples.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Animals != null) _Animals.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Antibiotics != null) _Antibiotics.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Vectors != null) _Vectors.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Diagnosis != null) _Diagnosis.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<LabSampleReceive>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(LabSampleReceive obj);
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
            private LabSampleReceiveItem.Accessor SamplesAccessor { get { return eidss.model.Schema.LabSampleReceiveItem.Accessor.Instance(m_CS); } }
            private LabSampleReceiveAnimal.Accessor AnimalsAccessor { get { return eidss.model.Schema.LabSampleReceiveAnimal.Accessor.Instance(m_CS); } }
            private LabSampleReceiveAntibiotic.Accessor AntibioticsAccessor { get { return eidss.model.Schema.LabSampleReceiveAntibiotic.Accessor.Instance(m_CS); } }
            private LabSampleReceiveVector.Accessor VectorsAccessor { get { return eidss.model.Schema.LabSampleReceiveVector.Accessor.Instance(m_CS); } }
            private LabSampleReceiveDiagnosis.Accessor DiagnosisAccessor { get { return eidss.model.Schema.LabSampleReceiveDiagnosis.Accessor.Instance(m_CS); } }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual LabSampleReceive SelectByKey(DbManagerProxy manager
                , Int64? CaseID
                )
            {
                return _SelectByKey(manager
                    , CaseID
                    , null, null
                    );
            }
            
      
            private LabSampleReceive _SelectByKey(DbManagerProxy manager
                , Int64? CaseID
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[6];
                List<LabSampleReceive> objs = new List<LabSampleReceive>();
                sets[0] = new MapResultSet(typeof(LabSampleReceive), objs);
                
                List<LabSampleReceiveItem> objs_LabSampleReceiveItem = new List<LabSampleReceiveItem>();
                sets[1] = new MapResultSet(typeof(LabSampleReceiveItem), objs_LabSampleReceiveItem);
                
                List<LabSampleReceiveAnimal> objs_LabSampleReceiveAnimal = new List<LabSampleReceiveAnimal>();
                sets[2] = new MapResultSet(typeof(LabSampleReceiveAnimal), objs_LabSampleReceiveAnimal);
                
                List<LabSampleReceiveAntibiotic> objs_LabSampleReceiveAntibiotic = new List<LabSampleReceiveAntibiotic>();
                sets[3] = new MapResultSet(typeof(LabSampleReceiveAntibiotic), objs_LabSampleReceiveAntibiotic);
                
                List<LabSampleReceiveVector> objs_LabSampleReceiveVector = new List<LabSampleReceiveVector>();
                sets[4] = new MapResultSet(typeof(LabSampleReceiveVector), objs_LabSampleReceiveVector);
                
                List<LabSampleReceiveDiagnosis> objs_LabSampleReceiveDiagnosis = new List<LabSampleReceiveDiagnosis>();
                sets[5] = new MapResultSet(typeof(LabSampleReceiveDiagnosis), objs_LabSampleReceiveDiagnosis);
                
        
                try
                {
                    manager
                        .SetSpCommand("spLabSampleReceive_SelectDetail"
                            , manager.Parameter("@CaseID", CaseID)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    LabSampleReceive obj = objs[0];
                    obj.m_CS = m_CS;
                    
                    if (loading != null)
                        loading(obj);
                    _SetupLoad(manager, obj);
                    
                    obj.Samples.ForEach(c => SamplesAccessor._SetupLoad(manager, c));
                        
                    obj.Animals.ForEach(c => AnimalsAccessor._SetupLoad(manager, c));
                        
                    obj.Antibiotics.ForEach(c => AntibioticsAccessor._SetupLoad(manager, c));
                        
                    obj.Vectors.ForEach(c => VectorsAccessor._SetupLoad(manager, c));
                        
                    obj.Diagnosis.ForEach(c => DiagnosisAccessor._SetupLoad(manager, c));
                        
                    //obj._setParent();
                    if (loaded != null)
                        loaded(obj);
                    obj.Loaded(manager);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(e);
                }
                
            }
    
            private void _SetupAddChildHandlerSamples(LabSampleReceive obj)
            {
                obj.Samples.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerAnimals(LabSampleReceive obj)
            {
                obj.Animals.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerAntibiotics(LabSampleReceive obj)
            {
                obj.Antibiotics.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerVectors(LabSampleReceive obj)
            {
                obj.Vectors.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerDiagnosis(LabSampleReceive obj)
            {
                obj.Diagnosis.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabSampleReceive obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.Samples.ForEach(t => { t.Animals = new Func<LabSampleReceive, EditableList<LabSampleReceiveAnimal>>(c => c.Animals)(obj); } );
                obj.Samples.ForEach(t => { t.Diagnosis = new Func<LabSampleReceive, EditableList<LabSampleReceiveDiagnosis>>(c => c.Diagnosis)(obj); } );
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerSamples(obj);
                
                _SetupAddChildHandlerAnimals(obj);
                
                _SetupAddChildHandlerAntibiotics(obj);
                
                _SetupAddChildHandlerVectors(obj);
                
                _SetupAddChildHandlerDiagnosis(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, LabSampleReceive obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.Samples.ForEach(c => SamplesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Animals.ForEach(c => AnimalsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Antibiotics.ForEach(c => AntibioticsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Vectors.ForEach(c => VectorsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Diagnosis.ForEach(c => DiagnosisAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private LabSampleReceive _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabSampleReceive obj = LabSampleReceive.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.ID = new Func<LabSampleReceive, long>(c => 0)(obj);
                obj.IDCase = new Func<LabSampleReceive, long>(c => 0)(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerSamples(obj);
                    
                    _SetupAddChildHandlerAnimals(obj);
                    
                    _SetupAddChildHandlerAntibiotics(obj);
                    
                    _SetupAddChildHandlerVectors(obj);
                    
                    _SetupAddChildHandlerDiagnosis(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
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

            
            public LabSampleReceive CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public LabSampleReceive CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult AccessionInReport(DbManagerProxy manager, LabSampleReceive obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("ObjID", typeof(long));
                
                return AccessionInReport(manager, obj
                    , (long)pars[0]
                    );
            }
            public ActResult AccessionInReport(DbManagerProxy manager, LabSampleReceive obj
                , long ObjID
                )
            {
                
                return true;
                
            }
            
            private void _SetupChildHandlers(LabSampleReceive obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabSampleReceive obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, LabSampleReceive obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spLabSampleReceive_ModifyCase")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] LabSampleReceive obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] LabSampleReceive obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    LabSampleReceive bo = obj as LabSampleReceive;
                    
                    if (!bo.GetPermissions().CanExecute("AccessionIn1"))
                        throw new PermissionException("AccessionIn1", "Execute");
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        long mainObject = bo.ID;
                        
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoSample;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbMaterial;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as LabSampleReceive, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, LabSampleReceive obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                                        
                    if (obj.Samples != null)
                    {
                        foreach (var i in obj.Samples)
                        {
                            i.MarkToDelete();
                            if (!SamplesAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                            
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (!obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, obj);
                                    
                    if (obj.IsNew)
                    {
                        if (obj.Samples != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.Samples)
                                if (!SamplesAccessor.Post(manager, i, true))
                                    return false;
                            obj.Samples.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.Samples.Remove(c));
                            obj.Samples.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._Samples != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._Samples)
                                if (!SamplesAccessor.Post(manager, i, true))
                                    return false;
                            obj._Samples.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._Samples.Remove(c));
                            obj._Samples.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(LabSampleReceive obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, LabSampleReceive obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as LabSampleReceive, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabSampleReceive obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessionIn1.Execute"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessionIn1.Execute"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessionIn1.Execute"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessionIn1.Execute"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(LabSampleReceive obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LabSampleReceive obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabSampleReceive) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabSampleReceive) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabSampleReceiveDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private LabSampleReceive m_obj;
            internal Permissions(LabSampleReceive obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessionIn1.Execute"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessionIn1.Execute"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessionIn1.Execute"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessionIn1.Execute"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spLabSampleReceive_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spLabSampleReceive_ModifyCase";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabSampleReceive, bool>> RequiredByField = new Dictionary<string, Func<LabSampleReceive, bool>>();
            public static Dictionary<string, Func<LabSampleReceive, bool>> RequiredByProperty = new Dictionary<string, Func<LabSampleReceive, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strMonitoringSessionID, 50);
                Sizes.Add(_str_strCampaignID, 50);
                Sizes.Add(_str_strCampaignName, 200);
                Sizes.Add(_str_SessionStatus, 2000);
                Sizes.Add(_str_CampaignType, 2000);
                Sizes.Add(_str_strCaseID, 200);
                Sizes.Add(_str_strSampleNotes, 1000);
                Sizes.Add(_str_strLocalIdentifier, 200);
                Sizes.Add(_str_strFieldAccessionID, 200);
                Sizes.Add(_str_FarmAddress, 1000);
                Sizes.Add(_str_strNationalName, 200);
                Sizes.Add(_str_FarmOwner, 602);
                Sizes.Add(_str_PatientName, 602);
                Sizes.Add(_str_Age, 2013);
                Sizes.Add(_str_idfsInitialDiagnosis, 2000);
                Sizes.Add(_str_CurrentResidence, 1000);
                Sizes.Add(_str_strSessionID, 50);
                Sizes.Add(_str_strRegion, 300);
                Sizes.Add(_str_strRayon, 300);
                Sizes.Add(_str_strSettlement, 300);
                Actions.Add(new ActionMetaItem(
                    "AccessionInReport",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).AccessionInReport(manager, (LabSampleReceive)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titlePaperForms",
                        "Report",
                        /*from BvMessages*/"titlePaperForms",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabSampleReceive>().Post(manager, (LabSampleReceive)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
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
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabSampleReceive>().Post(manager, (LabSampleReceive)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
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
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class LabSampleReceiveItem : 
        EditableObject<LabSampleReceiveItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfMaterial), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMaterial { get; set; }
                
        [LocalizedDisplayName(_str_idfsSpecimenType)]
        [MapField(_str_idfsSpecimenType)]
        public abstract Int64 idfsSpecimenType { get; set; }
        #if MONO
        protected Int64 idfsSpecimenType_Original { get { return idfsSpecimenType; } }
        protected Int64 idfsSpecimenType_Previous { get { return idfsSpecimenType; } }
        #else
        protected Int64 idfsSpecimenType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSpecimenType).OriginalValue; } }
        protected Int64 idfsSpecimenType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSpecimenType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfRootParentMaterial)]
        [MapField(_str_idfRootParentMaterial)]
        public abstract Int64? idfRootParentMaterial { get; set; }
        #if MONO
        protected Int64? idfRootParentMaterial_Original { get { return idfRootParentMaterial; } }
        protected Int64? idfRootParentMaterial_Previous { get { return idfRootParentMaterial; } }
        #else
        protected Int64? idfRootParentMaterial_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootParentMaterial).OriginalValue; } }
        protected Int64? idfRootParentMaterial_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootParentMaterial).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfParty)]
        [MapField(_str_idfParty)]
        public abstract Int64? idfParty { get; set; }
        #if MONO
        protected Int64? idfParty_Original { get { return idfParty; } }
        protected Int64? idfParty_Previous { get { return idfParty; } }
        #else
        protected Int64? idfParty_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParty).OriginalValue; } }
        protected Int64? idfParty_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParty).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_AnimalName)]
        [MapField(_str_AnimalName)]
        public abstract String AnimalName { get; set; }
        #if MONO
        protected String AnimalName_Original { get { return AnimalName; } }
        protected String AnimalName_Previous { get { return AnimalName; } }
        #else
        protected String AnimalName_Original { get { return ((EditableValue<String>)((dynamic)this)._animalName).OriginalValue; } }
        protected String AnimalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._animalName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strAnimalCode)]
        [MapField(_str_strAnimalCode)]
        public abstract String strAnimalCode { get; set; }
        #if MONO
        protected String strAnimalCode_Original { get { return strAnimalCode; } }
        protected String strAnimalCode_Previous { get { return strAnimalCode; } }
        #else
        protected String strAnimalCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strAnimalCode).OriginalValue; } }
        protected String strAnimalCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAnimalCode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_SpeciesName)]
        [MapField(_str_SpeciesName)]
        public abstract String SpeciesName { get; set; }
        #if MONO
        protected String SpeciesName_Original { get { return SpeciesName; } }
        protected String SpeciesName_Previous { get { return SpeciesName; } }
        #else
        protected String SpeciesName_Original { get { return ((EditableValue<String>)((dynamic)this)._speciesName).OriginalValue; } }
        protected String SpeciesName_Previous { get { return ((EditableValue<String>)((dynamic)this)._speciesName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strFarmCode)]
        [MapField(_str_strFarmCode)]
        public abstract String strFarmCode { get; set; }
        #if MONO
        protected String strFarmCode_Original { get { return strFarmCode; } }
        protected String strFarmCode_Previous { get { return strFarmCode; } }
        #else
        protected String strFarmCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).OriginalValue; } }
        protected String strFarmCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSpeciesType)]
        [MapField(_str_idfsSpeciesType)]
        public abstract Int64? idfsSpeciesType { get; set; }
        #if MONO
        protected Int64? idfsSpeciesType_Original { get { return idfsSpeciesType; } }
        protected Int64? idfsSpeciesType_Previous { get { return idfsSpeciesType; } }
        #else
        protected Int64? idfsSpeciesType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).OriginalValue; } }
        protected Int64? idfsSpeciesType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strFieldCollectedByPerson")]
        [MapField(_str_idfFieldCollectedByPerson)]
        public abstract Int64? idfFieldCollectedByPerson { get; set; }
        #if MONO
        protected Int64? idfFieldCollectedByPerson_Original { get { return idfFieldCollectedByPerson; } }
        protected Int64? idfFieldCollectedByPerson_Previous { get { return idfFieldCollectedByPerson; } }
        #else
        protected Int64? idfFieldCollectedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByPerson).OriginalValue; } }
        protected Int64? idfFieldCollectedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strFieldCollectedByPerson)]
        [MapField(_str_strFieldCollectedByPerson)]
        public abstract String strFieldCollectedByPerson { get; set; }
        #if MONO
        protected String strFieldCollectedByPerson_Original { get { return strFieldCollectedByPerson; } }
        protected String strFieldCollectedByPerson_Previous { get { return strFieldCollectedByPerson; } }
        #else
        protected String strFieldCollectedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByPerson).OriginalValue; } }
        protected String strFieldCollectedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strFieldCollectedByOffice")]
        [MapField(_str_idfFieldCollectedByOffice)]
        public abstract Int64? idfFieldCollectedByOffice { get; set; }
        #if MONO
        protected Int64? idfFieldCollectedByOffice_Original { get { return idfFieldCollectedByOffice; } }
        protected Int64? idfFieldCollectedByOffice_Previous { get { return idfFieldCollectedByOffice; } }
        #else
        protected Int64? idfFieldCollectedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).OriginalValue; } }
        protected Int64? idfFieldCollectedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strFieldCollectedByOffice)]
        [MapField(_str_strFieldCollectedByOffice)]
        public abstract String strFieldCollectedByOffice { get; set; }
        #if MONO
        protected String strFieldCollectedByOffice_Original { get { return strFieldCollectedByOffice; } }
        protected String strFieldCollectedByOffice_Previous { get { return strFieldCollectedByOffice; } }
        #else
        protected String strFieldCollectedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByOffice).OriginalValue; } }
        protected String strFieldCollectedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfSendToOffice)]
        [MapField(_str_idfSendToOffice)]
        public abstract Int64? idfSendToOffice { get; set; }
        #if MONO
        protected Int64? idfSendToOffice_Original { get { return idfSendToOffice; } }
        protected Int64? idfSendToOffice_Previous { get { return idfSendToOffice; } }
        #else
        protected Int64? idfSendToOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).OriginalValue; } }
        protected Int64? idfSendToOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSendToOffice)]
        [MapField(_str_strSendToOffice)]
        public abstract String strSendToOffice { get; set; }
        #if MONO
        protected String strSendToOffice_Original { get { return strSendToOffice; } }
        protected String strSendToOffice_Previous { get { return strSendToOffice; } }
        #else
        protected String strSendToOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strSendToOffice).OriginalValue; } }
        protected String strSendToOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSendToOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfTesting)]
        [MapField(_str_idfTesting)]
        public abstract Int64? idfTesting { get; set; }
        #if MONO
        protected Int64? idfTesting_Original { get { return idfTesting; } }
        protected Int64? idfTesting_Previous { get { return idfTesting; } }
        #else
        protected Int64? idfTesting_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTesting).OriginalValue; } }
        protected Int64? idfTesting_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTesting).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datFieldCollectionDate)]
        [MapField(_str_datFieldCollectionDate)]
        public abstract DateTime? datFieldCollectionDate { get; set; }
        #if MONO
        protected DateTime? datFieldCollectionDate_Original { get { return datFieldCollectionDate; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return datFieldCollectionDate; } }
        #else
        protected DateTime? datFieldCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).OriginalValue; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datFieldSentDate)]
        [MapField(_str_datFieldSentDate)]
        public abstract DateTime? datFieldSentDate { get; set; }
        #if MONO
        protected DateTime? datFieldSentDate_Original { get { return datFieldSentDate; } }
        protected DateTime? datFieldSentDate_Previous { get { return datFieldSentDate; } }
        #else
        protected DateTime? datFieldSentDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldSentDate).OriginalValue; } }
        protected DateTime? datFieldSentDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldSentDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strFieldBarcodeLocal")]
        [MapField(_str_strFieldBarcode)]
        public abstract String strFieldBarcode { get; set; }
        #if MONO
        protected String strFieldBarcode_Original { get { return strFieldBarcode; } }
        protected String strFieldBarcode_Previous { get { return strFieldBarcode; } }
        #else
        protected String strFieldBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).OriginalValue; } }
        protected String strFieldBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64? idfCase { get; set; }
        #if MONO
        protected Int64? idfCase_Original { get { return idfCase; } }
        protected Int64? idfCase_Previous { get { return idfCase; } }
        #else
        protected Int64? idfCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64? idfCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfMonitoringSession)]
        [MapField(_str_idfMonitoringSession)]
        public abstract Int64? idfMonitoringSession { get; set; }
        #if MONO
        protected Int64? idfMonitoringSession_Original { get { return idfMonitoringSession; } }
        protected Int64? idfMonitoringSession_Previous { get { return idfMonitoringSession; } }
        #else
        protected Int64? idfMonitoringSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).OriginalValue; } }
        protected Int64? idfMonitoringSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsSpecimenType")]
        [MapField(_str_strSpecimenName)]
        public abstract String strSpecimenName { get; set; }
        #if MONO
        protected String strSpecimenName_Original { get { return strSpecimenName; } }
        protected String strSpecimenName_Previous { get { return strSpecimenName; } }
        #else
        protected String strSpecimenName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSpecimenName).OriginalValue; } }
        protected String strSpecimenName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSpecimenName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64? idfsSite { get; set; }
        #if MONO
        protected Int64? idfsSite_Original { get { return idfsSite; } }
        protected Int64? idfsSite_Previous { get { return idfsSite; } }
        #else
        protected Int64? idfsSite_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64? idfsSite_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSite).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datAccession)]
        [MapField(_str_datAccession)]
        public abstract DateTime? datAccession { get; set; }
        #if MONO
        protected DateTime? datAccession_Original { get { return datAccession; } }
        protected DateTime? datAccession_Previous { get { return datAccession; } }
        #else
        protected DateTime? datAccession_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).OriginalValue; } }
        protected DateTime? datAccession_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfContainer)]
        [MapField(_str_idfContainer)]
        public abstract Int64? idfContainer { get; set; }
        #if MONO
        protected Int64? idfContainer_Original { get { return idfContainer; } }
        protected Int64? idfContainer_Previous { get { return idfContainer; } }
        #else
        protected Int64? idfContainer_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfContainer).OriginalValue; } }
        protected Int64? idfContainer_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfContainer).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCondition)]
        [MapField(_str_strCondition)]
        public abstract String strCondition { get; set; }
        #if MONO
        protected String strCondition_Original { get { return strCondition; } }
        protected String strCondition_Previous { get { return strCondition; } }
        #else
        protected String strCondition_Original { get { return ((EditableValue<String>)((dynamic)this)._strCondition).OriginalValue; } }
        protected String strCondition_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCondition).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsAccessionCondition)]
        [MapField(_str_idfsAccessionCondition)]
        public abstract Int64? idfsAccessionCondition { get; set; }
        #if MONO
        protected Int64? idfsAccessionCondition_Original { get { return idfsAccessionCondition; } }
        protected Int64? idfsAccessionCondition_Previous { get { return idfsAccessionCondition; } }
        #else
        protected Int64? idfsAccessionCondition_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAccessionCondition).OriginalValue; } }
        protected Int64? idfsAccessionCondition_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAccessionCondition).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strFieldCollectedByPerson")]
        [MapField(_str_idfAccesionByPerson)]
        public abstract Int64? idfAccesionByPerson { get; set; }
        #if MONO
        protected Int64? idfAccesionByPerson_Original { get { return idfAccesionByPerson; } }
        protected Int64? idfAccesionByPerson_Previous { get { return idfAccesionByPerson; } }
        #else
        protected Int64? idfAccesionByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAccesionByPerson).OriginalValue; } }
        protected Int64? idfAccesionByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAccesionByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_Used)]
        [MapField(_str_Used)]
        public abstract Int32 Used { get; set; }
        #if MONO
        protected Int32 Used_Original { get { return Used; } }
        protected Int32 Used_Previous { get { return Used; } }
        #else
        protected Int32 Used_Original { get { return ((EditableValue<Int32>)((dynamic)this)._used).OriginalValue; } }
        protected Int32 Used_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._used).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfVectorSurveillanceSession)]
        [MapField(_str_idfVectorSurveillanceSession)]
        public abstract Int64? idfVectorSurveillanceSession { get; set; }
        #if MONO
        protected Int64? idfVectorSurveillanceSession_Original { get { return idfVectorSurveillanceSession; } }
        protected Int64? idfVectorSurveillanceSession_Previous { get { return idfVectorSurveillanceSession; } }
        #else
        protected Int64? idfVectorSurveillanceSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).OriginalValue; } }
        protected Int64? idfVectorSurveillanceSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfVector)]
        [MapField(_str_idfVector)]
        public abstract Int64? idfVector { get; set; }
        #if MONO
        protected Int64? idfVector_Original { get { return idfVector; } }
        protected Int64? idfVector_Previous { get { return idfVector; } }
        #else
        protected Int64? idfVector_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVector).OriginalValue; } }
        protected Int64? idfVector_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVector).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strComment")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        #if MONO
        protected String strNote_Original { get { return strNote; } }
        protected String strNote_Previous { get { return strNote; } }
        #else
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsVectorType)]
        [MapField(_str_idfsVectorType)]
        public abstract Int64? idfsVectorType { get; set; }
        #if MONO
        protected Int64? idfsVectorType_Original { get { return idfsVectorType; } }
        protected Int64? idfsVectorType_Previous { get { return idfsVectorType; } }
        #else
        protected Int64? idfsVectorType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVectorType).OriginalValue; } }
        protected Int64? idfsVectorType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVectorType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsVectorSubType)]
        [MapField(_str_idfsVectorSubType)]
        public abstract Int64? idfsVectorSubType { get; set; }
        #if MONO
        protected Int64? idfsVectorSubType_Original { get { return idfsVectorSubType; } }
        protected Int64? idfsVectorSubType_Previous { get { return idfsVectorSubType; } }
        #else
        protected Int64? idfsVectorSubType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVectorSubType).OriginalValue; } }
        protected Int64? idfsVectorSubType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVectorSubType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intQuantity)]
        [MapField(_str_intQuantity)]
        public abstract Int32? intQuantity { get; set; }
        #if MONO
        protected Int32? intQuantity_Original { get { return intQuantity; } }
        protected Int32? intQuantity_Previous { get { return intQuantity; } }
        #else
        protected Int32? intQuantity_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intQuantity).OriginalValue; } }
        protected Int32? intQuantity_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intQuantity).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datCollectionDateTime)]
        [MapField(_str_datCollectionDateTime)]
        public abstract DateTime? datCollectionDateTime { get; set; }
        #if MONO
        protected DateTime? datCollectionDateTime_Original { get { return datCollectionDateTime; } }
        protected DateTime? datCollectionDateTime_Previous { get { return datCollectionDateTime; } }
        #else
        protected DateTime? datCollectionDateTime_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCollectionDateTime).OriginalValue; } }
        protected DateTime? datCollectionDateTime_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCollectionDateTime).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfLocation)]
        [MapField(_str_idfLocation)]
        public abstract Int64? idfLocation { get; set; }
        #if MONO
        protected Int64? idfLocation_Original { get { return idfLocation; } }
        protected Int64? idfLocation_Previous { get { return idfLocation; } }
        #else
        protected Int64? idfLocation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfLocation).OriginalValue; } }
        protected Int64? idfLocation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfLocation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strLabBarcode")]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        #if MONO
        protected String strBarcode_Original { get { return strBarcode; } }
        protected String strBarcode_Previous { get { return strBarcode; } }
        #else
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strVectorID)]
        [MapField(_str_strVectorID)]
        public abstract String strVectorID { get; set; }
        #if MONO
        protected String strVectorID_Original { get { return strVectorID; } }
        protected String strVectorID_Previous { get { return strVectorID; } }
        #else
        protected String strVectorID_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).OriginalValue; } }
        protected String strVectorID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strVectorType)]
        [MapField(_str_strVectorType)]
        public abstract String strVectorType { get; set; }
        #if MONO
        protected String strVectorType_Original { get { return strVectorType; } }
        protected String strVectorType_Previous { get { return strVectorType; } }
        #else
        protected String strVectorType_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).OriginalValue; } }
        protected String strVectorType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strVectorSpecies)]
        [MapField(_str_strVectorSpecies)]
        public abstract String strVectorSpecies { get; set; }
        #if MONO
        protected String strVectorSpecies_Original { get { return strVectorSpecies; } }
        protected String strVectorSpecies_Previous { get { return strVectorSpecies; } }
        #else
        protected String strVectorSpecies_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorSpecies).OriginalValue; } }
        protected String strVectorSpecies_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorSpecies).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strFieldBarcodeField")]
        [MapField(_str_strFieldBarcode2)]
        public abstract String strFieldBarcode2 { get; set; }
        #if MONO
        protected String strFieldBarcode2_Original { get { return strFieldBarcode2; } }
        protected String strFieldBarcode2_Previous { get { return strFieldBarcode2; } }
        #else
        protected String strFieldBarcode2_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode2).OriginalValue; } }
        protected String strFieldBarcode2_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode2).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCaseType)]
        [MapField(_str_idfsCaseType)]
        public abstract Int64? idfsCaseType { get; set; }
        #if MONO
        protected Int64? idfsCaseType_Original { get { return idfsCaseType; } }
        protected Int64? idfsCaseType_Previous { get { return idfsCaseType; } }
        #else
        protected Int64? idfsCaseType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).OriginalValue; } }
        protected Int64? idfsCaseType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("DepartmentName")]
        [MapField(_str_idfInDepartment)]
        public abstract Int64? idfInDepartment { get; set; }
        #if MONO
        protected Int64? idfInDepartment_Original { get { return idfInDepartment; } }
        protected Int64? idfInDepartment_Previous { get { return idfInDepartment; } }
        #else
        protected Int64? idfInDepartment_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInDepartment).OriginalValue; } }
        protected Int64? idfInDepartment_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInDepartment).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfDepartment)]
        [MapField(_str_idfDepartment)]
        public abstract Int64? idfDepartment { get; set; }
        #if MONO
        protected Int64? idfDepartment_Original { get { return idfDepartment; } }
        protected Int64? idfDepartment_Previous { get { return idfDepartment; } }
        #else
        protected Int64? idfDepartment_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDepartment).OriginalValue; } }
        protected Int64? idfDepartment_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDepartment).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfSubdivision)]
        [MapField(_str_idfSubdivision)]
        public abstract Int64? idfSubdivision { get; set; }
        #if MONO
        protected Int64? idfSubdivision_Original { get { return idfSubdivision; } }
        protected Int64? idfSubdivision_Previous { get { return idfSubdivision; } }
        #else
        protected Int64? idfSubdivision_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSubdivision).OriginalValue; } }
        protected Int64? idfSubdivision_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSubdivision).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strTests)]
        [MapField(_str_strTests)]
        public abstract Int32 strTests { get; set; }
        #if MONO
        protected Int32 strTests_Original { get { return strTests; } }
        protected Int32 strTests_Previous { get { return strTests; } }
        #else
        protected Int32 strTests_Original { get { return ((EditableValue<Int32>)((dynamic)this)._strTests).OriginalValue; } }
        protected Int32 strTests_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._strTests).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_ParentID)]
        [MapField(_str_ParentID)]
        public abstract Int64? ParentID { get; set; }
        #if MONO
        protected Int64? ParentID_Original { get { return ParentID; } }
        protected Int64? ParentID_Previous { get { return ParentID; } }
        #else
        protected Int64? ParentID_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._parentID).OriginalValue; } }
        protected Int64? ParentID_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._parentID).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<LabSampleReceiveItem, object> _get_func;
            internal Action<LabSampleReceiveItem, string> _set_func;
            internal Action<LabSampleReceiveItem, LabSampleReceiveItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_idfsSpecimenType = "idfsSpecimenType";
        internal const string _str_idfRootParentMaterial = "idfRootParentMaterial";
        internal const string _str_idfParty = "idfParty";
        internal const string _str_AnimalName = "AnimalName";
        internal const string _str_strAnimalCode = "strAnimalCode";
        internal const string _str_SpeciesName = "SpeciesName";
        internal const string _str_strFarmCode = "strFarmCode";
        internal const string _str_idfsSpeciesType = "idfsSpeciesType";
        internal const string _str_idfFieldCollectedByPerson = "idfFieldCollectedByPerson";
        internal const string _str_strFieldCollectedByPerson = "strFieldCollectedByPerson";
        internal const string _str_idfFieldCollectedByOffice = "idfFieldCollectedByOffice";
        internal const string _str_strFieldCollectedByOffice = "strFieldCollectedByOffice";
        internal const string _str_idfSendToOffice = "idfSendToOffice";
        internal const string _str_strSendToOffice = "strSendToOffice";
        internal const string _str_idfTesting = "idfTesting";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_datFieldSentDate = "datFieldSentDate";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_strSpecimenName = "strSpecimenName";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_datAccession = "datAccession";
        internal const string _str_idfContainer = "idfContainer";
        internal const string _str_strCondition = "strCondition";
        internal const string _str_idfsAccessionCondition = "idfsAccessionCondition";
        internal const string _str_idfAccesionByPerson = "idfAccesionByPerson";
        internal const string _str_Used = "Used";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfVector = "idfVector";
        internal const string _str_strNote = "strNote";
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_idfsVectorSubType = "idfsVectorSubType";
        internal const string _str_intQuantity = "intQuantity";
        internal const string _str_datCollectionDateTime = "datCollectionDateTime";
        internal const string _str_idfLocation = "idfLocation";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_strVectorID = "strVectorID";
        internal const string _str_strVectorType = "strVectorType";
        internal const string _str_strVectorSpecies = "strVectorSpecies";
        internal const string _str_strFieldBarcode2 = "strFieldBarcode2";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_idfInDepartment = "idfInDepartment";
        internal const string _str_idfDepartment = "idfDepartment";
        internal const string _str_idfSubdivision = "idfSubdivision";
        internal const string _str_strTests = "strTests";
        internal const string _str_ParentID = "ParentID";
        internal const string _str_NewObject = "NewObject";
        internal const string _str_IsNewAcceeded = "IsNewAcceeded";
        internal const string _str_FilterByDiagnosis = "FilterByDiagnosis";
        internal const string _str_strNoteSaved = "strNoteSaved";
        internal const string _str_Animals = "Animals";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_IsAccessionAllowed = "IsAccessionAllowed";
        internal const string _str_strAccessionByPerson = "strAccessionByPerson";
        internal const string _str_strAccessionCondition = "strAccessionCondition";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_strDepartment = "strDepartment";
        internal const string _str_strFreezer = "strFreezer";
        internal const string _str_AnimalID = "AnimalID";
        internal const string _str_Species = "Species";
        internal const string _str_CaseHACode = "CaseHACode";
        internal const string _str_SampleType = "SampleType";
        internal const string _str_AccessionCondition = "AccessionCondition";
        internal const string _str_AccessionByPerson = "AccessionByPerson";
        internal const string _str_Department = "Department";
        internal const string _str_Freezer = "Freezer";
        internal const string _str_Animal = "Animal";
        internal const string _str_Spec = "Spec";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfMaterial, _type = "Int64",
              _get_func = o => o.idfMaterial,
              _set_func = (o, val) => { o.idfMaterial = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfMaterial != c.idfMaterial || o.IsRIRPropChanged(_str_idfMaterial, c)) 
                  m.Add(_str_idfMaterial, o.ObjectIdent + _str_idfMaterial, "Int64", o.idfMaterial == null ? "" : o.idfMaterial.ToString(), o.IsReadOnly(_str_idfMaterial), o.IsInvisible(_str_idfMaterial), o.IsRequired(_str_idfMaterial)); }
              }, 
        
            new field_info {
              _name = _str_idfsSpecimenType, _type = "Int64",
              _get_func = o => o.idfsSpecimenType,
              _set_func = (o, val) => { o.idfsSpecimenType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpecimenType != c.idfsSpecimenType || o.IsRIRPropChanged(_str_idfsSpecimenType, c)) 
                  m.Add(_str_idfsSpecimenType, o.ObjectIdent + _str_idfsSpecimenType, "Int64", o.idfsSpecimenType == null ? "" : o.idfsSpecimenType.ToString(), o.IsReadOnly(_str_idfsSpecimenType), o.IsInvisible(_str_idfsSpecimenType), o.IsRequired(_str_idfsSpecimenType)); }
              }, 
        
            new field_info {
              _name = _str_idfRootParentMaterial, _type = "Int64?",
              _get_func = o => o.idfRootParentMaterial,
              _set_func = (o, val) => { o.idfRootParentMaterial = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfRootParentMaterial != c.idfRootParentMaterial || o.IsRIRPropChanged(_str_idfRootParentMaterial, c)) 
                  m.Add(_str_idfRootParentMaterial, o.ObjectIdent + _str_idfRootParentMaterial, "Int64?", o.idfRootParentMaterial == null ? "" : o.idfRootParentMaterial.ToString(), o.IsReadOnly(_str_idfRootParentMaterial), o.IsInvisible(_str_idfRootParentMaterial), o.IsRequired(_str_idfRootParentMaterial)); }
              }, 
        
            new field_info {
              _name = _str_idfParty, _type = "Int64?",
              _get_func = o => o.idfParty,
              _set_func = (o, val) => { o.idfParty = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_idfParty, c)) 
                  m.Add(_str_idfParty, o.ObjectIdent + _str_idfParty, "Int64?", o.idfParty == null ? "" : o.idfParty.ToString(), o.IsReadOnly(_str_idfParty), o.IsInvisible(_str_idfParty), o.IsRequired(_str_idfParty)); }
              }, 
        
            new field_info {
              _name = _str_AnimalName, _type = "String",
              _get_func = o => o.AnimalName,
              _set_func = (o, val) => { o.AnimalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.AnimalName != c.AnimalName || o.IsRIRPropChanged(_str_AnimalName, c)) 
                  m.Add(_str_AnimalName, o.ObjectIdent + _str_AnimalName, "String", o.AnimalName == null ? "" : o.AnimalName.ToString(), o.IsReadOnly(_str_AnimalName), o.IsInvisible(_str_AnimalName), o.IsRequired(_str_AnimalName)); }
              }, 
        
            new field_info {
              _name = _str_strAnimalCode, _type = "String",
              _get_func = o => o.strAnimalCode,
              _set_func = (o, val) => { o.strAnimalCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strAnimalCode != c.strAnimalCode || o.IsRIRPropChanged(_str_strAnimalCode, c)) 
                  m.Add(_str_strAnimalCode, o.ObjectIdent + _str_strAnimalCode, "String", o.strAnimalCode == null ? "" : o.strAnimalCode.ToString(), o.IsReadOnly(_str_strAnimalCode), o.IsInvisible(_str_strAnimalCode), o.IsRequired(_str_strAnimalCode)); }
              }, 
        
            new field_info {
              _name = _str_SpeciesName, _type = "String",
              _get_func = o => o.SpeciesName,
              _set_func = (o, val) => { o.SpeciesName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.SpeciesName != c.SpeciesName || o.IsRIRPropChanged(_str_SpeciesName, c)) 
                  m.Add(_str_SpeciesName, o.ObjectIdent + _str_SpeciesName, "String", o.SpeciesName == null ? "" : o.SpeciesName.ToString(), o.IsReadOnly(_str_SpeciesName), o.IsInvisible(_str_SpeciesName), o.IsRequired(_str_SpeciesName)); }
              }, 
        
            new field_info {
              _name = _str_strFarmCode, _type = "String",
              _get_func = o => o.strFarmCode,
              _set_func = (o, val) => { o.strFarmCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFarmCode != c.strFarmCode || o.IsRIRPropChanged(_str_strFarmCode, c)) 
                  m.Add(_str_strFarmCode, o.ObjectIdent + _str_strFarmCode, "String", o.strFarmCode == null ? "" : o.strFarmCode.ToString(), o.IsReadOnly(_str_strFarmCode), o.IsInvisible(_str_strFarmCode), o.IsRequired(_str_strFarmCode)); }
              }, 
        
            new field_info {
              _name = _str_idfsSpeciesType, _type = "Int64?",
              _get_func = o => o.idfsSpeciesType,
              _set_func = (o, val) => { o.idfsSpeciesType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_idfsSpeciesType, c)) 
                  m.Add(_str_idfsSpeciesType, o.ObjectIdent + _str_idfsSpeciesType, "Int64?", o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(), o.IsReadOnly(_str_idfsSpeciesType), o.IsInvisible(_str_idfsSpeciesType), o.IsRequired(_str_idfsSpeciesType)); }
              }, 
        
            new field_info {
              _name = _str_idfFieldCollectedByPerson, _type = "Int64?",
              _get_func = o => o.idfFieldCollectedByPerson,
              _set_func = (o, val) => { o.idfFieldCollectedByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfFieldCollectedByPerson != c.idfFieldCollectedByPerson || o.IsRIRPropChanged(_str_idfFieldCollectedByPerson, c)) 
                  m.Add(_str_idfFieldCollectedByPerson, o.ObjectIdent + _str_idfFieldCollectedByPerson, "Int64?", o.idfFieldCollectedByPerson == null ? "" : o.idfFieldCollectedByPerson.ToString(), o.IsReadOnly(_str_idfFieldCollectedByPerson), o.IsInvisible(_str_idfFieldCollectedByPerson), o.IsRequired(_str_idfFieldCollectedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_strFieldCollectedByPerson, _type = "String",
              _get_func = o => o.strFieldCollectedByPerson,
              _set_func = (o, val) => { o.strFieldCollectedByPerson = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFieldCollectedByPerson != c.strFieldCollectedByPerson || o.IsRIRPropChanged(_str_strFieldCollectedByPerson, c)) 
                  m.Add(_str_strFieldCollectedByPerson, o.ObjectIdent + _str_strFieldCollectedByPerson, "String", o.strFieldCollectedByPerson == null ? "" : o.strFieldCollectedByPerson.ToString(), o.IsReadOnly(_str_strFieldCollectedByPerson), o.IsInvisible(_str_strFieldCollectedByPerson), o.IsRequired(_str_strFieldCollectedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_idfFieldCollectedByOffice, _type = "Int64?",
              _get_func = o => o.idfFieldCollectedByOffice,
              _set_func = (o, val) => { o.idfFieldCollectedByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfFieldCollectedByOffice != c.idfFieldCollectedByOffice || o.IsRIRPropChanged(_str_idfFieldCollectedByOffice, c)) 
                  m.Add(_str_idfFieldCollectedByOffice, o.ObjectIdent + _str_idfFieldCollectedByOffice, "Int64?", o.idfFieldCollectedByOffice == null ? "" : o.idfFieldCollectedByOffice.ToString(), o.IsReadOnly(_str_idfFieldCollectedByOffice), o.IsInvisible(_str_idfFieldCollectedByOffice), o.IsRequired(_str_idfFieldCollectedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_strFieldCollectedByOffice, _type = "String",
              _get_func = o => o.strFieldCollectedByOffice,
              _set_func = (o, val) => { o.strFieldCollectedByOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFieldCollectedByOffice != c.strFieldCollectedByOffice || o.IsRIRPropChanged(_str_strFieldCollectedByOffice, c)) 
                  m.Add(_str_strFieldCollectedByOffice, o.ObjectIdent + _str_strFieldCollectedByOffice, "String", o.strFieldCollectedByOffice == null ? "" : o.strFieldCollectedByOffice.ToString(), o.IsReadOnly(_str_strFieldCollectedByOffice), o.IsInvisible(_str_strFieldCollectedByOffice), o.IsRequired(_str_strFieldCollectedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfSendToOffice, _type = "Int64?",
              _get_func = o => o.idfSendToOffice,
              _set_func = (o, val) => { o.idfSendToOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSendToOffice != c.idfSendToOffice || o.IsRIRPropChanged(_str_idfSendToOffice, c)) 
                  m.Add(_str_idfSendToOffice, o.ObjectIdent + _str_idfSendToOffice, "Int64?", o.idfSendToOffice == null ? "" : o.idfSendToOffice.ToString(), o.IsReadOnly(_str_idfSendToOffice), o.IsInvisible(_str_idfSendToOffice), o.IsRequired(_str_idfSendToOffice)); }
              }, 
        
            new field_info {
              _name = _str_strSendToOffice, _type = "String",
              _get_func = o => o.strSendToOffice,
              _set_func = (o, val) => { o.strSendToOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSendToOffice != c.strSendToOffice || o.IsRIRPropChanged(_str_strSendToOffice, c)) 
                  m.Add(_str_strSendToOffice, o.ObjectIdent + _str_strSendToOffice, "String", o.strSendToOffice == null ? "" : o.strSendToOffice.ToString(), o.IsReadOnly(_str_strSendToOffice), o.IsInvisible(_str_strSendToOffice), o.IsRequired(_str_strSendToOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfTesting, _type = "Int64?",
              _get_func = o => o.idfTesting,
              _set_func = (o, val) => { o.idfTesting = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTesting != c.idfTesting || o.IsRIRPropChanged(_str_idfTesting, c)) 
                  m.Add(_str_idfTesting, o.ObjectIdent + _str_idfTesting, "Int64?", o.idfTesting == null ? "" : o.idfTesting.ToString(), o.IsReadOnly(_str_idfTesting), o.IsInvisible(_str_idfTesting), o.IsRequired(_str_idfTesting)); }
              }, 
        
            new field_info {
              _name = _str_datFieldCollectionDate, _type = "DateTime?",
              _get_func = o => o.datFieldCollectionDate,
              _set_func = (o, val) => { o.datFieldCollectionDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datFieldCollectionDate != c.datFieldCollectionDate || o.IsRIRPropChanged(_str_datFieldCollectionDate, c)) 
                  m.Add(_str_datFieldCollectionDate, o.ObjectIdent + _str_datFieldCollectionDate, "DateTime?", o.datFieldCollectionDate == null ? "" : o.datFieldCollectionDate.ToString(), o.IsReadOnly(_str_datFieldCollectionDate), o.IsInvisible(_str_datFieldCollectionDate), o.IsRequired(_str_datFieldCollectionDate)); }
              }, 
        
            new field_info {
              _name = _str_datFieldSentDate, _type = "DateTime?",
              _get_func = o => o.datFieldSentDate,
              _set_func = (o, val) => { o.datFieldSentDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datFieldSentDate != c.datFieldSentDate || o.IsRIRPropChanged(_str_datFieldSentDate, c)) 
                  m.Add(_str_datFieldSentDate, o.ObjectIdent + _str_datFieldSentDate, "DateTime?", o.datFieldSentDate == null ? "" : o.datFieldSentDate.ToString(), o.IsReadOnly(_str_datFieldSentDate), o.IsInvisible(_str_datFieldSentDate), o.IsRequired(_str_datFieldSentDate)); }
              }, 
        
            new field_info {
              _name = _str_strFieldBarcode, _type = "String",
              _get_func = o => o.strFieldBarcode,
              _set_func = (o, val) => { o.strFieldBarcode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFieldBarcode != c.strFieldBarcode || o.IsRIRPropChanged(_str_strFieldBarcode, c)) 
                  m.Add(_str_strFieldBarcode, o.ObjectIdent + _str_strFieldBarcode, "String", o.strFieldBarcode == null ? "" : o.strFieldBarcode.ToString(), o.IsReadOnly(_str_strFieldBarcode), o.IsInvisible(_str_strFieldBarcode), o.IsRequired(_str_strFieldBarcode)); }
              }, 
        
            new field_info {
              _name = _str_idfCase, _type = "Int64?",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { o.idfCase = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, "Int64?", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); }
              }, 
        
            new field_info {
              _name = _str_idfMonitoringSession, _type = "Int64?",
              _get_func = o => o.idfMonitoringSession,
              _set_func = (o, val) => { o.idfMonitoringSession = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfMonitoringSession != c.idfMonitoringSession || o.IsRIRPropChanged(_str_idfMonitoringSession, c)) 
                  m.Add(_str_idfMonitoringSession, o.ObjectIdent + _str_idfMonitoringSession, "Int64?", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_idfMonitoringSession), o.IsInvisible(_str_idfMonitoringSession), o.IsRequired(_str_idfMonitoringSession)); }
              }, 
        
            new field_info {
              _name = _str_strSpecimenName, _type = "String",
              _get_func = o => o.strSpecimenName,
              _set_func = (o, val) => { o.strSpecimenName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSpecimenName != c.strSpecimenName || o.IsRIRPropChanged(_str_strSpecimenName, c)) 
                  m.Add(_str_strSpecimenName, o.ObjectIdent + _str_strSpecimenName, "String", o.strSpecimenName == null ? "" : o.strSpecimenName.ToString(), o.IsReadOnly(_str_strSpecimenName), o.IsInvisible(_str_strSpecimenName), o.IsRequired(_str_strSpecimenName)); }
              }, 
        
            new field_info {
              _name = _str_idfsSite, _type = "Int64?",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { o.idfsSite = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_idfsSite, c)) 
                  m.Add(_str_idfsSite, o.ObjectIdent + _str_idfsSite, "Int64?", o.idfsSite == null ? "" : o.idfsSite.ToString(), o.IsReadOnly(_str_idfsSite), o.IsInvisible(_str_idfsSite), o.IsRequired(_str_idfsSite)); }
              }, 
        
            new field_info {
              _name = _str_datAccession, _type = "DateTime?",
              _get_func = o => o.datAccession,
              _set_func = (o, val) => { o.datAccession = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datAccession != c.datAccession || o.IsRIRPropChanged(_str_datAccession, c)) 
                  m.Add(_str_datAccession, o.ObjectIdent + _str_datAccession, "DateTime?", o.datAccession == null ? "" : o.datAccession.ToString(), o.IsReadOnly(_str_datAccession), o.IsInvisible(_str_datAccession), o.IsRequired(_str_datAccession)); }
              }, 
        
            new field_info {
              _name = _str_idfContainer, _type = "Int64?",
              _get_func = o => o.idfContainer,
              _set_func = (o, val) => { o.idfContainer = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfContainer != c.idfContainer || o.IsRIRPropChanged(_str_idfContainer, c)) 
                  m.Add(_str_idfContainer, o.ObjectIdent + _str_idfContainer, "Int64?", o.idfContainer == null ? "" : o.idfContainer.ToString(), o.IsReadOnly(_str_idfContainer), o.IsInvisible(_str_idfContainer), o.IsRequired(_str_idfContainer)); }
              }, 
        
            new field_info {
              _name = _str_strCondition, _type = "String",
              _get_func = o => o.strCondition,
              _set_func = (o, val) => { o.strCondition = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCondition != c.strCondition || o.IsRIRPropChanged(_str_strCondition, c)) 
                  m.Add(_str_strCondition, o.ObjectIdent + _str_strCondition, "String", o.strCondition == null ? "" : o.strCondition.ToString(), o.IsReadOnly(_str_strCondition), o.IsInvisible(_str_strCondition), o.IsRequired(_str_strCondition)); }
              }, 
        
            new field_info {
              _name = _str_idfsAccessionCondition, _type = "Int64?",
              _get_func = o => o.idfsAccessionCondition,
              _set_func = (o, val) => { o.idfsAccessionCondition = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsAccessionCondition != c.idfsAccessionCondition || o.IsRIRPropChanged(_str_idfsAccessionCondition, c)) 
                  m.Add(_str_idfsAccessionCondition, o.ObjectIdent + _str_idfsAccessionCondition, "Int64?", o.idfsAccessionCondition == null ? "" : o.idfsAccessionCondition.ToString(), o.IsReadOnly(_str_idfsAccessionCondition), o.IsInvisible(_str_idfsAccessionCondition), o.IsRequired(_str_idfsAccessionCondition)); }
              }, 
        
            new field_info {
              _name = _str_idfAccesionByPerson, _type = "Int64?",
              _get_func = o => o.idfAccesionByPerson,
              _set_func = (o, val) => { o.idfAccesionByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfAccesionByPerson != c.idfAccesionByPerson || o.IsRIRPropChanged(_str_idfAccesionByPerson, c)) 
                  m.Add(_str_idfAccesionByPerson, o.ObjectIdent + _str_idfAccesionByPerson, "Int64?", o.idfAccesionByPerson == null ? "" : o.idfAccesionByPerson.ToString(), o.IsReadOnly(_str_idfAccesionByPerson), o.IsInvisible(_str_idfAccesionByPerson), o.IsRequired(_str_idfAccesionByPerson)); }
              }, 
        
            new field_info {
              _name = _str_Used, _type = "Int32",
              _get_func = o => o.Used,
              _set_func = (o, val) => { o.Used = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.Used != c.Used || o.IsRIRPropChanged(_str_Used, c)) 
                  m.Add(_str_Used, o.ObjectIdent + _str_Used, "Int32", o.Used == null ? "" : o.Used.ToString(), o.IsReadOnly(_str_Used), o.IsInvisible(_str_Used), o.IsRequired(_str_Used)); }
              }, 
        
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _type = "Int64?",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { o.idfVectorSurveillanceSession = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, "Int64?", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); }
              }, 
        
            new field_info {
              _name = _str_idfVector, _type = "Int64?",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { o.idfVector = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) 
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, "Int64?", o.idfVector == null ? "" : o.idfVector.ToString(), o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector)); }
              }, 
        
            new field_info {
              _name = _str_strNote, _type = "String",
              _get_func = o => o.strNote,
              _set_func = (o, val) => { o.strNote = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNote != c.strNote || o.IsRIRPropChanged(_str_strNote, c)) 
                  m.Add(_str_strNote, o.ObjectIdent + _str_strNote, "String", o.strNote == null ? "" : o.strNote.ToString(), o.IsReadOnly(_str_strNote), o.IsInvisible(_str_strNote), o.IsRequired(_str_strNote)); }
              }, 
        
            new field_info {
              _name = _str_idfsVectorType, _type = "Int64?",
              _get_func = o => o.idfsVectorType,
              _set_func = (o, val) => { o.idfsVectorType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_idfsVectorType, c)) 
                  m.Add(_str_idfsVectorType, o.ObjectIdent + _str_idfsVectorType, "Int64?", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_idfsVectorType), o.IsInvisible(_str_idfsVectorType), o.IsRequired(_str_idfsVectorType)); }
              }, 
        
            new field_info {
              _name = _str_idfsVectorSubType, _type = "Int64?",
              _get_func = o => o.idfsVectorSubType,
              _set_func = (o, val) => { o.idfsVectorSubType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorSubType != c.idfsVectorSubType || o.IsRIRPropChanged(_str_idfsVectorSubType, c)) 
                  m.Add(_str_idfsVectorSubType, o.ObjectIdent + _str_idfsVectorSubType, "Int64?", o.idfsVectorSubType == null ? "" : o.idfsVectorSubType.ToString(), o.IsReadOnly(_str_idfsVectorSubType), o.IsInvisible(_str_idfsVectorSubType), o.IsRequired(_str_idfsVectorSubType)); }
              }, 
        
            new field_info {
              _name = _str_intQuantity, _type = "Int32?",
              _get_func = o => o.intQuantity,
              _set_func = (o, val) => { o.intQuantity = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intQuantity != c.intQuantity || o.IsRIRPropChanged(_str_intQuantity, c)) 
                  m.Add(_str_intQuantity, o.ObjectIdent + _str_intQuantity, "Int32?", o.intQuantity == null ? "" : o.intQuantity.ToString(), o.IsReadOnly(_str_intQuantity), o.IsInvisible(_str_intQuantity), o.IsRequired(_str_intQuantity)); }
              }, 
        
            new field_info {
              _name = _str_datCollectionDateTime, _type = "DateTime?",
              _get_func = o => o.datCollectionDateTime,
              _set_func = (o, val) => { o.datCollectionDateTime = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datCollectionDateTime != c.datCollectionDateTime || o.IsRIRPropChanged(_str_datCollectionDateTime, c)) 
                  m.Add(_str_datCollectionDateTime, o.ObjectIdent + _str_datCollectionDateTime, "DateTime?", o.datCollectionDateTime == null ? "" : o.datCollectionDateTime.ToString(), o.IsReadOnly(_str_datCollectionDateTime), o.IsInvisible(_str_datCollectionDateTime), o.IsRequired(_str_datCollectionDateTime)); }
              }, 
        
            new field_info {
              _name = _str_idfLocation, _type = "Int64?",
              _get_func = o => o.idfLocation,
              _set_func = (o, val) => { o.idfLocation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfLocation != c.idfLocation || o.IsRIRPropChanged(_str_idfLocation, c)) 
                  m.Add(_str_idfLocation, o.ObjectIdent + _str_idfLocation, "Int64?", o.idfLocation == null ? "" : o.idfLocation.ToString(), o.IsReadOnly(_str_idfLocation), o.IsInvisible(_str_idfLocation), o.IsRequired(_str_idfLocation)); }
              }, 
        
            new field_info {
              _name = _str_strBarcode, _type = "String",
              _get_func = o => o.strBarcode,
              _set_func = (o, val) => { o.strBarcode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strBarcode != c.strBarcode || o.IsRIRPropChanged(_str_strBarcode, c)) 
                  m.Add(_str_strBarcode, o.ObjectIdent + _str_strBarcode, "String", o.strBarcode == null ? "" : o.strBarcode.ToString(), o.IsReadOnly(_str_strBarcode), o.IsInvisible(_str_strBarcode), o.IsRequired(_str_strBarcode)); }
              }, 
        
            new field_info {
              _name = _str_strVectorID, _type = "String",
              _get_func = o => o.strVectorID,
              _set_func = (o, val) => { o.strVectorID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorID != c.strVectorID || o.IsRIRPropChanged(_str_strVectorID, c)) 
                  m.Add(_str_strVectorID, o.ObjectIdent + _str_strVectorID, "String", o.strVectorID == null ? "" : o.strVectorID.ToString(), o.IsReadOnly(_str_strVectorID), o.IsInvisible(_str_strVectorID), o.IsRequired(_str_strVectorID)); }
              }, 
        
            new field_info {
              _name = _str_strVectorType, _type = "String",
              _get_func = o => o.strVectorType,
              _set_func = (o, val) => { o.strVectorType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorType != c.strVectorType || o.IsRIRPropChanged(_str_strVectorType, c)) 
                  m.Add(_str_strVectorType, o.ObjectIdent + _str_strVectorType, "String", o.strVectorType == null ? "" : o.strVectorType.ToString(), o.IsReadOnly(_str_strVectorType), o.IsInvisible(_str_strVectorType), o.IsRequired(_str_strVectorType)); }
              }, 
        
            new field_info {
              _name = _str_strVectorSpecies, _type = "String",
              _get_func = o => o.strVectorSpecies,
              _set_func = (o, val) => { o.strVectorSpecies = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorSpecies != c.strVectorSpecies || o.IsRIRPropChanged(_str_strVectorSpecies, c)) 
                  m.Add(_str_strVectorSpecies, o.ObjectIdent + _str_strVectorSpecies, "String", o.strVectorSpecies == null ? "" : o.strVectorSpecies.ToString(), o.IsReadOnly(_str_strVectorSpecies), o.IsInvisible(_str_strVectorSpecies), o.IsRequired(_str_strVectorSpecies)); }
              }, 
        
            new field_info {
              _name = _str_strFieldBarcode2, _type = "String",
              _get_func = o => o.strFieldBarcode2,
              _set_func = (o, val) => { o.strFieldBarcode2 = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFieldBarcode2 != c.strFieldBarcode2 || o.IsRIRPropChanged(_str_strFieldBarcode2, c)) 
                  m.Add(_str_strFieldBarcode2, o.ObjectIdent + _str_strFieldBarcode2, "String", o.strFieldBarcode2 == null ? "" : o.strFieldBarcode2.ToString(), o.IsReadOnly(_str_strFieldBarcode2), o.IsInvisible(_str_strFieldBarcode2), o.IsRequired(_str_strFieldBarcode2)); }
              }, 
        
            new field_info {
              _name = _str_idfsCaseType, _type = "Int64?",
              _get_func = o => o.idfsCaseType,
              _set_func = (o, val) => { o.idfsCaseType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_idfsCaseType, c)) 
                  m.Add(_str_idfsCaseType, o.ObjectIdent + _str_idfsCaseType, "Int64?", o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(), o.IsReadOnly(_str_idfsCaseType), o.IsInvisible(_str_idfsCaseType), o.IsRequired(_str_idfsCaseType)); }
              }, 
        
            new field_info {
              _name = _str_idfInDepartment, _type = "Int64?",
              _get_func = o => o.idfInDepartment,
              _set_func = (o, val) => { o.idfInDepartment = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfInDepartment != c.idfInDepartment || o.IsRIRPropChanged(_str_idfInDepartment, c)) 
                  m.Add(_str_idfInDepartment, o.ObjectIdent + _str_idfInDepartment, "Int64?", o.idfInDepartment == null ? "" : o.idfInDepartment.ToString(), o.IsReadOnly(_str_idfInDepartment), o.IsInvisible(_str_idfInDepartment), o.IsRequired(_str_idfInDepartment)); }
              }, 
        
            new field_info {
              _name = _str_idfDepartment, _type = "Int64?",
              _get_func = o => o.idfDepartment,
              _set_func = (o, val) => { o.idfDepartment = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfDepartment != c.idfDepartment || o.IsRIRPropChanged(_str_idfDepartment, c)) 
                  m.Add(_str_idfDepartment, o.ObjectIdent + _str_idfDepartment, "Int64?", o.idfDepartment == null ? "" : o.idfDepartment.ToString(), o.IsReadOnly(_str_idfDepartment), o.IsInvisible(_str_idfDepartment), o.IsRequired(_str_idfDepartment)); }
              }, 
        
            new field_info {
              _name = _str_idfSubdivision, _type = "Int64?",
              _get_func = o => o.idfSubdivision,
              _set_func = (o, val) => { o.idfSubdivision = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSubdivision != c.idfSubdivision || o.IsRIRPropChanged(_str_idfSubdivision, c)) 
                  m.Add(_str_idfSubdivision, o.ObjectIdent + _str_idfSubdivision, "Int64?", o.idfSubdivision == null ? "" : o.idfSubdivision.ToString(), o.IsReadOnly(_str_idfSubdivision), o.IsInvisible(_str_idfSubdivision), o.IsRequired(_str_idfSubdivision)); }
              }, 
        
            new field_info {
              _name = _str_strTests, _type = "Int32",
              _get_func = o => o.strTests,
              _set_func = (o, val) => { o.strTests = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.strTests != c.strTests || o.IsRIRPropChanged(_str_strTests, c)) 
                  m.Add(_str_strTests, o.ObjectIdent + _str_strTests, "Int32", o.strTests == null ? "" : o.strTests.ToString(), o.IsReadOnly(_str_strTests), o.IsInvisible(_str_strTests), o.IsRequired(_str_strTests)); }
              }, 
        
            new field_info {
              _name = _str_ParentID, _type = "Int64?",
              _get_func = o => o.ParentID,
              _set_func = (o, val) => { o.ParentID = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.ParentID != c.ParentID || o.IsRIRPropChanged(_str_ParentID, c)) 
                  m.Add(_str_ParentID, o.ObjectIdent + _str_ParentID, "Int64?", o.ParentID == null ? "" : o.ParentID.ToString(), o.IsReadOnly(_str_ParentID), o.IsInvisible(_str_ParentID), o.IsRequired(_str_ParentID)); }
              }, 
        
            new field_info {
              _name = _str_NewObject, _type = "bool",
              _get_func = o => o.NewObject,
              _set_func = (o, val) => { o.NewObject = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.NewObject != c.NewObject || o.IsRIRPropChanged(_str_NewObject, c)) 
                  m.Add(_str_NewObject, o.ObjectIdent + _str_NewObject, "bool", o.NewObject == null ? "" : o.NewObject.ToString(), o.IsReadOnly(_str_NewObject), o.IsInvisible(_str_NewObject), o.IsRequired(_str_NewObject));
                 }
              }, 
        
            new field_info {
              _name = _str_IsNewAcceeded, _type = "bool",
              _get_func = o => o.IsNewAcceeded,
              _set_func = (o, val) => { o.IsNewAcceeded = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.IsNewAcceeded != c.IsNewAcceeded || o.IsRIRPropChanged(_str_IsNewAcceeded, c)) 
                  m.Add(_str_IsNewAcceeded, o.ObjectIdent + _str_IsNewAcceeded, "bool", o.IsNewAcceeded == null ? "" : o.IsNewAcceeded.ToString(), o.IsReadOnly(_str_IsNewAcceeded), o.IsInvisible(_str_IsNewAcceeded), o.IsRequired(_str_IsNewAcceeded));
                 }
              }, 
        
            new field_info {
              _name = _str_FilterByDiagnosis, _type = "bool",
              _get_func = o => o.FilterByDiagnosis,
              _set_func = (o, val) => { o.FilterByDiagnosis = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.FilterByDiagnosis != c.FilterByDiagnosis || o.IsRIRPropChanged(_str_FilterByDiagnosis, c)) 
                  m.Add(_str_FilterByDiagnosis, o.ObjectIdent + _str_FilterByDiagnosis, "bool", o.FilterByDiagnosis == null ? "" : o.FilterByDiagnosis.ToString(), o.IsReadOnly(_str_FilterByDiagnosis), o.IsInvisible(_str_FilterByDiagnosis), o.IsRequired(_str_FilterByDiagnosis));
                 }
              }, 
        
            new field_info {
              _name = _str_strNoteSaved, _type = "string",
              _get_func = o => o.strNoteSaved,
              _set_func = (o, val) => { o.strNoteSaved = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
              
                if (o.strNoteSaved != c.strNoteSaved || o.IsRIRPropChanged(_str_strNoteSaved, c)) 
                  m.Add(_str_strNoteSaved, o.ObjectIdent + _str_strNoteSaved, "string", o.strNoteSaved == null ? "" : o.strNoteSaved.ToString(), o.IsReadOnly(_str_strNoteSaved), o.IsInvisible(_str_strNoteSaved), o.IsRequired(_str_strNoteSaved));
                 }
              }, 
        
            new field_info {
              _name = _str_Animals, _type = "EditableList<LabSampleReceiveAnimal>",
              _get_func = o => o.Animals,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _type = "EditableList<LabSampleReceiveDiagnosis>",
              _get_func = o => o.Diagnosis,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_IsAccessionAllowed, _type = "bool",
              _get_func = o => o.IsAccessionAllowed,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.IsAccessionAllowed != c.IsAccessionAllowed || o.IsRIRPropChanged(_str_IsAccessionAllowed, c)) 
                  m.Add(_str_IsAccessionAllowed, o.ObjectIdent + _str_IsAccessionAllowed, "bool", o.IsAccessionAllowed == null ? "" : o.IsAccessionAllowed.ToString(), o.IsReadOnly(_str_IsAccessionAllowed), o.IsInvisible(_str_IsAccessionAllowed), o.IsRequired(_str_IsAccessionAllowed));
                 }
              }, 
        
            new field_info {
              _name = _str_strAccessionByPerson, _type = "string",
              _get_func = o => o.strAccessionByPerson,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strAccessionByPerson != c.strAccessionByPerson || o.IsRIRPropChanged(_str_strAccessionByPerson, c)) 
                  m.Add(_str_strAccessionByPerson, o.ObjectIdent + _str_strAccessionByPerson, "string", o.strAccessionByPerson == null ? "" : o.strAccessionByPerson.ToString(), o.IsReadOnly(_str_strAccessionByPerson), o.IsInvisible(_str_strAccessionByPerson), o.IsRequired(_str_strAccessionByPerson));
                 }
              }, 
        
            new field_info {
              _name = _str_strAccessionCondition, _type = "string",
              _get_func = o => o.strAccessionCondition,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strAccessionCondition != c.strAccessionCondition || o.IsRIRPropChanged(_str_strAccessionCondition, c)) 
                  m.Add(_str_strAccessionCondition, o.ObjectIdent + _str_strAccessionCondition, "string", o.strAccessionCondition == null ? "" : o.strAccessionCondition.ToString(), o.IsReadOnly(_str_strAccessionCondition), o.IsInvisible(_str_strAccessionCondition), o.IsRequired(_str_strAccessionCondition));
                 }
              }, 
        
            new field_info {
              _name = _str_CaseObjectIdent, _type = "string",
              _get_func = o => o.CaseObjectIdent,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.CaseObjectIdent != c.CaseObjectIdent || o.IsRIRPropChanged(_str_CaseObjectIdent, c)) 
                  m.Add(_str_CaseObjectIdent, o.ObjectIdent + _str_CaseObjectIdent, "string", o.CaseObjectIdent == null ? "" : o.CaseObjectIdent.ToString(), o.IsReadOnly(_str_CaseObjectIdent), o.IsInvisible(_str_CaseObjectIdent), o.IsRequired(_str_CaseObjectIdent));
                 }
              }, 
        
            new field_info {
              _name = _str_strDepartment, _type = "string",
              _get_func = o => o.strDepartment,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strDepartment != c.strDepartment || o.IsRIRPropChanged(_str_strDepartment, c)) 
                  m.Add(_str_strDepartment, o.ObjectIdent + _str_strDepartment, "string", o.strDepartment == null ? "" : o.strDepartment.ToString(), o.IsReadOnly(_str_strDepartment), o.IsInvisible(_str_strDepartment), o.IsRequired(_str_strDepartment));
                 }
              }, 
        
            new field_info {
              _name = _str_strFreezer, _type = "string",
              _get_func = o => o.strFreezer,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strFreezer != c.strFreezer || o.IsRIRPropChanged(_str_strFreezer, c)) 
                  m.Add(_str_strFreezer, o.ObjectIdent + _str_strFreezer, "string", o.strFreezer == null ? "" : o.strFreezer.ToString(), o.IsReadOnly(_str_strFreezer), o.IsInvisible(_str_strFreezer), o.IsRequired(_str_strFreezer));
                 }
              }, 
        
            new field_info {
              _name = _str_AnimalID, _type = "string",
              _get_func = o => o.AnimalID,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.AnimalID != c.AnimalID || o.IsRIRPropChanged(_str_AnimalID, c)) 
                  m.Add(_str_AnimalID, o.ObjectIdent + _str_AnimalID, "string", o.AnimalID == null ? "" : o.AnimalID.ToString(), o.IsReadOnly(_str_AnimalID), o.IsInvisible(_str_AnimalID), o.IsRequired(_str_AnimalID));
                 }
              }, 
        
            new field_info {
              _name = _str_Species, _type = "string",
              _get_func = o => o.Species,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.Species != c.Species || o.IsRIRPropChanged(_str_Species, c)) 
                  m.Add(_str_Species, o.ObjectIdent + _str_Species, "string", o.Species == null ? "" : o.Species.ToString(), o.IsReadOnly(_str_Species), o.IsInvisible(_str_Species), o.IsRequired(_str_Species));
                 }
              }, 
        
            new field_info {
              _name = _str_CaseHACode, _type = "int?",
              _get_func = o => o.CaseHACode,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.CaseHACode != c.CaseHACode || o.IsRIRPropChanged(_str_CaseHACode, c)) 
                  m.Add(_str_CaseHACode, o.ObjectIdent + _str_CaseHACode, "int?", o.CaseHACode == null ? "" : o.CaseHACode.ToString(), o.IsReadOnly(_str_CaseHACode), o.IsInvisible(_str_CaseHACode), o.IsRequired(_str_CaseHACode));
                 }
              }, 
        
            new field_info {
              _name = _str_SampleType, _type = "Lookup",
              _get_func = o => { if (o.SampleType == null) return null; return o.SampleType.idfsReference; },
              _set_func = (o, val) => { o.SampleType = o.SampleTypeLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpecimenType != c.idfsSpecimenType || o.IsRIRPropChanged(_str_SampleType, c)) 
                  m.Add(_str_SampleType, o.ObjectIdent + _str_SampleType, "Lookup", o.idfsSpecimenType == null ? "" : o.idfsSpecimenType.ToString(), o.IsReadOnly(_str_SampleType), o.IsInvisible(_str_SampleType), o.IsRequired(_str_SampleType)); }
              }, 
        
            new field_info {
              _name = _str_AccessionCondition, _type = "Lookup",
              _get_func = o => { if (o.AccessionCondition == null) return null; return o.AccessionCondition.idfsBaseReference; },
              _set_func = (o, val) => { o.AccessionCondition = o.AccessionConditionLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAccessionCondition != c.idfsAccessionCondition || o.IsRIRPropChanged(_str_AccessionCondition, c)) 
                  m.Add(_str_AccessionCondition, o.ObjectIdent + _str_AccessionCondition, "Lookup", o.idfsAccessionCondition == null ? "" : o.idfsAccessionCondition.ToString(), o.IsReadOnly(_str_AccessionCondition), o.IsInvisible(_str_AccessionCondition), o.IsRequired(_str_AccessionCondition)); }
              }, 
        
            new field_info {
              _name = _str_AccessionByPerson, _type = "Lookup",
              _get_func = o => { if (o.AccessionByPerson == null) return null; return o.AccessionByPerson.idfPerson; },
              _set_func = (o, val) => { o.AccessionByPerson = o.AccessionByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfAccesionByPerson != c.idfAccesionByPerson || o.IsRIRPropChanged(_str_AccessionByPerson, c)) 
                  m.Add(_str_AccessionByPerson, o.ObjectIdent + _str_AccessionByPerson, "Lookup", o.idfAccesionByPerson == null ? "" : o.idfAccesionByPerson.ToString(), o.IsReadOnly(_str_AccessionByPerson), o.IsInvisible(_str_AccessionByPerson), o.IsRequired(_str_AccessionByPerson)); }
              }, 
        
            new field_info {
              _name = _str_Department, _type = "Lookup",
              _get_func = o => { if (o.Department == null) return null; return o.Department.idfDepartment; },
              _set_func = (o, val) => { o.Department = o.DepartmentLookup.Where(c => c.idfDepartment.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfInDepartment != c.idfInDepartment || o.IsRIRPropChanged(_str_Department, c)) 
                  m.Add(_str_Department, o.ObjectIdent + _str_Department, "Lookup", o.idfInDepartment == null ? "" : o.idfInDepartment.ToString(), o.IsReadOnly(_str_Department), o.IsInvisible(_str_Department), o.IsRequired(_str_Department)); }
              }, 
        
            new field_info {
              _name = _str_Freezer, _type = "Lookup",
              _get_func = o => { if (o.Freezer == null) return null; return o.Freezer.ID; },
              _set_func = (o, val) => { o.Freezer = o.FreezerLookup.Where(c => c.ID.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfSubdivision != c.idfSubdivision || o.IsRIRPropChanged(_str_Freezer, c)) 
                  m.Add(_str_Freezer, o.ObjectIdent + _str_Freezer, "Lookup", o.idfSubdivision == null ? "" : o.idfSubdivision.ToString(), o.IsReadOnly(_str_Freezer), o.IsInvisible(_str_Freezer), o.IsRequired(_str_Freezer)); }
              }, 
        
            new field_info {
              _name = _str_Animal, _type = "Lookup",
              _get_func = o => { if (o.Animal == null) return null; return o.Animal.idfAnimal; },
              _set_func = (o, val) => { o.Animal = o.AnimalLookup.Where(c => c.idfAnimal.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_Animal, c)) 
                  m.Add(_str_Animal, o.ObjectIdent + _str_Animal, "Lookup", o.idfParty == null ? "" : o.idfParty.ToString(), o.IsReadOnly(_str_Animal), o.IsInvisible(_str_Animal), o.IsRequired(_str_Animal)); }
              }, 
        
            new field_info {
              _name = _str_Spec, _type = "Lookup",
              _get_func = o => { if (o.Spec == null) return null; return o.Spec.idfSpecies; },
              _set_func = (o, val) => { o.Spec = o.SpecLookup.Where(c => c.idfSpecies.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_Spec, c)) 
                  m.Add(_str_Spec, o.ObjectIdent + _str_Spec, "Lookup", o.idfParty == null ? "" : o.idfParty.ToString(), o.IsReadOnly(_str_Spec), o.IsInvisible(_str_Spec), o.IsRequired(_str_Spec)); }
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
            LabSampleReceiveItem obj = (LabSampleReceiveItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(SampleTypeForDiagnosisLookup), eidss.model.Schema.SampleTypeForDiagnosisLookup._str_idfsReference, _str_idfsSpecimenType)]
        public SampleTypeForDiagnosisLookup SampleType
        {
            get { return _SampleType == null ? null : ((long)_SampleType.Key == 0 ? null : _SampleType); }
            set 
            { 
                _SampleType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsSpecimenType = _SampleType == null 
                    ? new Int64()
                    : _SampleType.idfsReference; 
                OnPropertyChanged(_str_SampleType); 
            }
        }
        private SampleTypeForDiagnosisLookup _SampleType;

        
        public List<SampleTypeForDiagnosisLookup> SampleTypeLookup
        {
            get { return _SampleTypeLookup; }
        }
        private List<SampleTypeForDiagnosisLookup> _SampleTypeLookup = new List<SampleTypeForDiagnosisLookup>();
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAccessionCondition)]
        public BaseReference AccessionCondition
        {
            get { return _AccessionCondition == null ? null : ((long)_AccessionCondition.Key == 0 ? null : _AccessionCondition); }
            set 
            { 
                _AccessionCondition = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAccessionCondition = _AccessionCondition == null 
                    ? new Int64?()
                    : _AccessionCondition.idfsBaseReference; 
                OnPropertyChanged(_str_AccessionCondition); 
            }
        }
        private BaseReference _AccessionCondition;

        
        public BaseReferenceList AccessionConditionLookup
        {
            get { return _AccessionConditionLookup; }
        }
        private BaseReferenceList _AccessionConditionLookup = new BaseReferenceList("rftAccessionCondition");
            
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfAccesionByPerson)]
        public PersonLookup AccessionByPerson
        {
            get { return _AccessionByPerson == null ? null : ((long)_AccessionByPerson.Key == 0 ? null : _AccessionByPerson); }
            set 
            { 
                _AccessionByPerson = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfAccesionByPerson = _AccessionByPerson == null 
                    ? new Int64?()
                    : _AccessionByPerson.idfPerson; 
                OnPropertyChanged(_str_AccessionByPerson); 
            }
        }
        private PersonLookup _AccessionByPerson;

        
        public List<PersonLookup> AccessionByPersonLookup
        {
            get { return _AccessionByPersonLookup; }
        }
        private List<PersonLookup> _AccessionByPersonLookup = new List<PersonLookup>();
            
        [Relation(typeof(DepartmentLookup), eidss.model.Schema.DepartmentLookup._str_idfDepartment, _str_idfInDepartment)]
        public DepartmentLookup Department
        {
            get { return _Department == null ? null : ((long)_Department.Key == 0 ? null : _Department); }
            set 
            { 
                _Department = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfInDepartment = _Department == null 
                    ? new Int64?()
                    : _Department.idfDepartment; 
                OnPropertyChanged(_str_Department); 
            }
        }
        private DepartmentLookup _Department;

        
        public List<DepartmentLookup> DepartmentLookup
        {
            get { return _DepartmentLookup; }
        }
        private List<DepartmentLookup> _DepartmentLookup = new List<DepartmentLookup>();
            
        [Relation(typeof(FreezerTreeLookup), eidss.model.Schema.FreezerTreeLookup._str_ID, _str_idfSubdivision)]
        public FreezerTreeLookup Freezer
        {
            get { return _Freezer == null ? null : ((long)_Freezer.Key == 0 ? null : _Freezer); }
            set 
            { 
                _Freezer = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfSubdivision = _Freezer == null 
                    ? new Int64?()
                    : _Freezer.ID; 
                OnPropertyChanged(_str_Freezer); 
            }
        }
        private FreezerTreeLookup _Freezer;

        
        public List<FreezerTreeLookup> FreezerLookup
        {
            get { return _FreezerLookup; }
        }
        private List<FreezerTreeLookup> _FreezerLookup = new List<FreezerTreeLookup>();
            
        [Relation(typeof(LabSampleReceiveAnimal), eidss.model.Schema.LabSampleReceiveAnimal._str_idfAnimal, _str_idfParty)]
        public LabSampleReceiveAnimal Animal
        {
            get { return _Animal == null ? null : ((long)_Animal.Key == 0 ? null : _Animal); }
            set 
            { 
                _Animal = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfParty = _Animal == null 
                    ? new Int64?()
                    : _Animal.idfAnimal; 
                OnPropertyChanged(_str_Animal); 
            }
        }
        private LabSampleReceiveAnimal _Animal;

        
        public List<LabSampleReceiveAnimal> AnimalLookup
        {
            get 
            { 
                var ret = new List<LabSampleReceiveAnimal>();
                using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    ret.Add(eidss.model.Schema.LabSampleReceiveAnimal.Accessor.Instance(null).CreateNewT(manager, null));
                if (Animals != null)
                    ret.AddRange(Animals
                        .Where(c => c.idfAnimal != null)
                            
                    );
                return ret;
            }
        }
            
        [Relation(typeof(LabSampleReceiveAnimal), eidss.model.Schema.LabSampleReceiveAnimal._str_idfSpecies, _str_idfParty)]
        public LabSampleReceiveAnimal Spec
        {
            get { return _Spec == null ? null : ((long)_Spec.Key == 0 ? null : _Spec); }
            set 
            { 
                _Spec = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfParty = _Spec == null 
                    ? new Int64?()
                    : _Spec.idfSpecies; 
                OnPropertyChanged(_str_Spec); 
            }
        }
        private LabSampleReceiveAnimal _Spec;

        
        public List<LabSampleReceiveAnimal> SpecLookup
        {
            get 
            { 
                var ret = new List<LabSampleReceiveAnimal>();
                using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    ret.Add(eidss.model.Schema.LabSampleReceiveAnimal.Accessor.Instance(null).CreateNewT(manager, null));
                if (Animals != null)
                    ret.AddRange(Animals
                        .Where(c => c.idfAnimal == null)
                            
                    );
                return ret;
            }
        }
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_SampleType:
                    return new BvSelectList(SampleTypeLookup, eidss.model.Schema.SampleTypeForDiagnosisLookup._str_idfsReference, null, SampleType, _str_idfsSpecimenType);
            
                case _str_AccessionCondition:
                    return new BvSelectList(AccessionConditionLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AccessionCondition, _str_idfsAccessionCondition);
            
                case _str_AccessionByPerson:
                    return new BvSelectList(AccessionByPersonLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, AccessionByPerson, _str_idfAccesionByPerson);
            
                case _str_Department:
                    return new BvSelectList(DepartmentLookup, eidss.model.Schema.DepartmentLookup._str_idfDepartment, null, Department, _str_idfInDepartment);
            
                case _str_Freezer:
                    return new BvSelectList(FreezerLookup, eidss.model.Schema.FreezerTreeLookup._str_ID, null, Freezer, _str_idfSubdivision);
            
                case _str_Animal:
                    return new BvSelectList(AnimalLookup, eidss.model.Schema.LabSampleReceiveAnimal._str_idfAnimal, null, Animal, _str_idfParty);
            
                case _str_Spec:
                    return new BvSelectList(SpecLookup, eidss.model.Schema.LabSampleReceiveAnimal._str_idfSpecies, null, Spec, _str_idfParty);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsAccessionAllowed)]
        public bool IsAccessionAllowed
        {
            get { return new Func<LabSampleReceiveItem, bool>(c => c.AccessionCondition == null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strAccessionByPerson)]
        public string strAccessionByPerson
        {
            get { return new Func<LabSampleReceiveItem, string>(c => c.AccessionByPerson == null ? "" : c.AccessionByPerson.FullName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("idfsAccessionCondition")]
        public string strAccessionCondition
        {
            get { return new Func<LabSampleReceiveItem, string>(c => c.AccessionCondition == null ? "" : c.AccessionCondition.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<LabSampleReceiveItem, string>(c => "LabSampleReceive_" + (c.idfCase == null ? c.idfMonitoringSession + 1 : c.idfCase + 1) + "_")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strDepartment)]
        public string strDepartment
        {
            get { return new Func<LabSampleReceiveItem, string>(c => c.Department == null ? "" : c.Department.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("strFreezerName")]
        public string strFreezer
        {
            get { return new Func<LabSampleReceiveItem, string>(c => c.Freezer == null ? "" : c.Freezer.Path)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_AnimalID)]
        public string AnimalID
        {
            get { return new Func<LabSampleReceiveItem, string>(c => c.idfCase == null || c.Animals == null || c.Animals.Count == 0 || c.idfParty == null ? "" : c.Animals.Where(a => a.idfParty == c.idfParty).Single().strAnimalCode)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Species)]
        public string Species
        {
            get { return new Func<LabSampleReceiveItem, string>(c => c.Animals == null || c.Animals.Count == 0 || c.idfParty == null ? c.SpeciesName : c.Animals.Where(a => a.idfParty == c.idfParty).Single().strSpecies)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseHACode)]
        public int? CaseHACode
        {
            get { return new Func<LabSampleReceiveItem, int?>(c => (c.idfsCaseType == (long)eidss.model.Enums.CaseTypeEnum.Human ? (int)HACode.Human :
                                       (c.idfsCaseType == (long)eidss.model.Enums.CaseTypeEnum.Livestock ? (int)HACode.Livestock : 
                                       (c.idfsCaseType == (long)eidss.model.Enums.CaseTypeEnum.Avian ? (int)HACode.Avian : 
                                       (int)HACode.Livestock))))(this); }
            
        }
        
          [LocalizedDisplayName(_str_NewObject)]
        public bool NewObject
        {
            get { return m_NewObject; }
            set { if (m_NewObject != value) { m_NewObject = value; OnPropertyChanged(_str_NewObject); } }
        }
        private bool m_NewObject;
        
          [LocalizedDisplayName(_str_IsNewAcceeded)]
        public bool IsNewAcceeded
        {
            get { return m_IsNewAcceeded; }
            set { if (m_IsNewAcceeded != value) { m_IsNewAcceeded = value; OnPropertyChanged(_str_IsNewAcceeded); } }
        }
        private bool m_IsNewAcceeded;
        
          [LocalizedDisplayName(_str_FilterByDiagnosis)]
        public bool FilterByDiagnosis
        {
            get { return m_FilterByDiagnosis; }
            set { if (m_FilterByDiagnosis != value) { m_FilterByDiagnosis = value; OnPropertyChanged(_str_FilterByDiagnosis); } }
        }
        private bool m_FilterByDiagnosis;
        
          [LocalizedDisplayName(_str_strNoteSaved)]
        public string strNoteSaved
        {
            get { return m_strNoteSaved; }
            set { if (m_strNoteSaved != value) { m_strNoteSaved = value; OnPropertyChanged(_str_strNoteSaved); } }
        }
        private string m_strNoteSaved;
        
          [LocalizedDisplayName(_str_Animals)]
        public EditableList<LabSampleReceiveAnimal> Animals
        {
            get { return m_Animals; }
            set { if (m_Animals != value) { m_Animals = value; OnPropertyChanged(_str_Animals); } }
        }
        private EditableList<LabSampleReceiveAnimal> m_Animals;
        
          [LocalizedDisplayName(_str_Diagnosis)]
        public EditableList<LabSampleReceiveDiagnosis> Diagnosis
        {
            get { return m_Diagnosis; }
            set { if (m_Diagnosis != value) { m_Diagnosis = value; OnPropertyChanged(_str_Diagnosis); } }
        }
        private EditableList<LabSampleReceiveDiagnosis> m_Diagnosis;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LabSampleReceiveItem";

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
            var ret = base.Clone() as LabSampleReceiveItem;
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
            var ret = base.Clone() as LabSampleReceiveItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public LabSampleReceiveItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabSampleReceiveItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfMaterial; } }
        public string KeyName { get { return "idfMaterial"; } }
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
        
            var _prev_idfsSpecimenType_SampleType = idfsSpecimenType;
            var _prev_idfsAccessionCondition_AccessionCondition = idfsAccessionCondition;
            var _prev_idfAccesionByPerson_AccessionByPerson = idfAccesionByPerson;
            var _prev_idfInDepartment_Department = idfInDepartment;
            var _prev_idfSubdivision_Freezer = idfSubdivision;
            base.RejectChanges();
        
            if (_prev_idfsSpecimenType_SampleType != idfsSpecimenType)
            {
                _SampleType = _SampleTypeLookup.FirstOrDefault(c => c.idfsReference == idfsSpecimenType);
            }
            if (_prev_idfsAccessionCondition_AccessionCondition != idfsAccessionCondition)
            {
                _AccessionCondition = _AccessionConditionLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAccessionCondition);
            }
            if (_prev_idfAccesionByPerson_AccessionByPerson != idfAccesionByPerson)
            {
                _AccessionByPerson = _AccessionByPersonLookup.FirstOrDefault(c => c.idfPerson == idfAccesionByPerson);
            }
            if (_prev_idfInDepartment_Department != idfInDepartment)
            {
                _Department = _DepartmentLookup.FirstOrDefault(c => c.idfDepartment == idfInDepartment);
            }
            if (_prev_idfSubdivision_Freezer != idfSubdivision)
            {
                _Freezer = _FreezerLookup.FirstOrDefault(c => c.ID == idfSubdivision);
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

      private bool IsRIRPropChanged(string fld, LabSampleReceiveItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabSampleReceiveItem()
        {
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabSampleReceiveItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabSampleReceiveItem_PropertyChanged);
        }
        private void LabSampleReceiveItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabSampleReceiveItem).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfsAccessionCondition)
                OnPropertyChanged(_str_IsAccessionAllowed);
                  
            if (e.PropertyName == _str_idfAccesionByPerson)
                OnPropertyChanged(_str_strAccessionByPerson);
                  
            if (e.PropertyName == _str_idfsAccessionCondition)
                OnPropertyChanged(_str_strAccessionCondition);
                  
            if (e.PropertyName == _str_idfCase)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
            if (e.PropertyName == _str_idfMonitoringSession)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
            if (e.PropertyName == _str_Department)
                OnPropertyChanged(_str_strDepartment);
                  
            if (e.PropertyName == _str_idfInDepartment)
                OnPropertyChanged(_str_strDepartment);
                  
            if (e.PropertyName == _str_Freezer)
                OnPropertyChanged(_str_strFreezer);
                  
            if (e.PropertyName == _str_idfSubdivision)
                OnPropertyChanged(_str_strFreezer);
                  
            if (e.PropertyName == _str_idfParty)
                OnPropertyChanged(_str_AnimalID);
                  
            if (e.PropertyName == _str_Animals)
                OnPropertyChanged(_str_AnimalID);
                  
            if (e.PropertyName == _str_SpeciesName)
                OnPropertyChanged(_str_Species);
                  
            if (e.PropertyName == _str_idfParty)
                OnPropertyChanged(_str_Species);
                  
            if (e.PropertyName == _str_Animals)
                OnPropertyChanged(_str_Species);
                  
            if (e.PropertyName == _str_idfsCaseType)
                OnPropertyChanged(_str_CaseHACode);
                  
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
            LabSampleReceiveItem obj = this;
            try
            {
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.idfsAccessionCondition == null || c.IsNew
                    );
            
            }
            catch(ValidationModelException ex)
            {
                if (bReport && !OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                {
                    OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                }
                
                return false;
            }
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            LabSampleReceiveItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabSampleReceiveItem obj = this;
            
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

    
        private static string[] readonly_names1 = "Animal,Spec,SampleType,FilterByDiagnosis,strFieldBarcode,datFieldCollectionDate,AccessionByPerson,idfFieldCollectedByOffice,idfFieldCollectedByPerson".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strBarcode,datAccession,strCondition,AccessionCondition,strNote,Department".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LabSampleReceiveItem, bool>(c => !c.IsNew)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LabSampleReceiveItem, bool>(c => !c.IsNewAcceeded)(this);
            
            return ReadOnly || new Func<LabSampleReceiveItem, bool>(c => true)(this);
                
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


        public Dictionary<string, Func<LabSampleReceiveItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabSampleReceiveItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabSampleReceiveItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabSampleReceiveItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabSampleReceiveItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<LabSampleReceiveItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LabSampleReceiveItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("SampleTypeForDiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftAccessionCondition", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                LookupManager.RemoveObject("DepartmentLookup", this);
                
                LookupManager.RemoveObject("FreezerTreeLookup", this);
                
                LookupManager.RemoveObject("LabSampleReceiveAnimal", this);
                
                LookupManager.RemoveObject("LabSampleReceiveAnimal", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "SampleTypeForDiagnosisLookup")
                _getAccessor().LoadLookup_SampleType(manager, this);
            
            if (lookup_object == "rftAccessionCondition")
                _getAccessor().LoadLookup_AccessionCondition(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_AccessionByPerson(manager, this);
            
            if (lookup_object == "DepartmentLookup")
                _getAccessor().LoadLookup_Department(manager, this);
            
            if (lookup_object == "FreezerTreeLookup")
                _getAccessor().LoadLookup_Freezer(manager, this);
            
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
        public class LabSampleReceiveItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfMaterial { get; set; }
        
            public Int64? idfsAccessionCondition { get; set; }
        
            public string strSpecimenName { get; set; }
        
            public string strFieldBarcode2 { get; set; }
        
            public string strFieldBarcode { get; set; }
        
            public string AnimalID { get; set; }
        
            public string Species { get; set; }
        
            public string strBarcode { get; set; }
        
            public DateTime? datFieldCollectionDate { get; set; }
        
            public DateTime? datAccession { get; set; }
        
            public string strAccessionCondition { get; set; }
        
            public string strNote { get; set; }
        
            public string strDepartment { get; set; }
        
            public string strFreezer { get; set; }
        
        }
        public partial class LabSampleReceiveItemGridModelList : List<LabSampleReceiveItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public LabSampleReceiveItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabSampleReceiveItem>, errMes);
            }
            public LabSampleReceiveItemGridModelList(long key, IEnumerable<LabSampleReceiveItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<LabSampleReceiveItem> items);
            private void LoadGridModelList(long key, IEnumerable<LabSampleReceiveItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strSpecimenName,_str_strFieldBarcode2,_str_strFieldBarcode,_str_AnimalID,_str_Species,_str_strBarcode,_str_datFieldCollectionDate,_str_datAccession,_str_strAccessionCondition,_str_strNote,_str_strDepartment,_str_strFreezer};
                    
                Hiddens = new List<string> {_str_idfMaterial,_str_idfsAccessionCondition};
                Keys = new List<string> {_str_idfMaterial};
                Labels = new Dictionary<string, string> {{_str_strSpecimenName, "idfsSpecimenType"},{_str_strFieldBarcode2, "strFieldBarcodeField"},{_str_strFieldBarcode, "strFieldBarcodeLocal"},{_str_AnimalID, _str_AnimalID},{_str_Species, _str_Species},{_str_strBarcode, "strLabBarcode"},{_str_datFieldCollectionDate, _str_datFieldCollectionDate},{_str_datAccession, _str_datAccession},{_str_strAccessionCondition, "idfsAccessionCondition"},{_str_strNote, "strComment"},{_str_strDepartment, _str_strDepartment},{_str_strFreezer, "strFreezerName"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<LabSampleReceiveItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new LabSampleReceiveItemGridModel()
                {
                    ItemKey=c.idfMaterial,idfsAccessionCondition=c.idfsAccessionCondition,strSpecimenName=c.strSpecimenName,strFieldBarcode2=c.strFieldBarcode2,strFieldBarcode=c.strFieldBarcode,AnimalID=c.AnimalID,Species=c.Species,strBarcode=c.strBarcode,datFieldCollectionDate=c.datFieldCollectionDate,datAccession=c.datAccession,strAccessionCondition=c.strAccessionCondition,strNote=c.strNote,strDepartment=c.strDepartment,strFreezer=c.strFreezer
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
        : DataAccessor<LabSampleReceiveItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(LabSampleReceiveItem obj);
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
            private SampleTypeForDiagnosisLookup.Accessor SampleTypeAccessor { get { return eidss.model.Schema.SampleTypeForDiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AccessionConditionAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor AccessionByPersonAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            private DepartmentLookup.Accessor DepartmentAccessor { get { return eidss.model.Schema.DepartmentLookup.Accessor.Instance(m_CS); } }
            private FreezerTreeLookup.Accessor FreezerAccessor { get { return eidss.model.Schema.FreezerTreeLookup.Accessor.Instance(m_CS); } }
            private LabSampleReceiveAnimal.Accessor AnimalAccessor { get { return eidss.model.Schema.LabSampleReceiveAnimal.Accessor.Instance(m_CS); } }
            private LabSampleReceiveAnimal.Accessor SpecAccessor { get { return eidss.model.Schema.LabSampleReceiveAnimal.Accessor.Instance(m_CS); } }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual LabSampleReceiveItem SelectByKey(DbManagerProxy manager
                , Int64? CaseID
                )
            {
                return _SelectByKey(manager
                    , CaseID
                    , null, null
                    );
            }
            
      
            private LabSampleReceiveItem _SelectByKey(DbManagerProxy manager
                , Int64? CaseID
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabSampleReceiveItem obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj.FilterByDiagnosis = new Func<LabSampleReceiveItem, bool>(c => false)(obj);
                obj.strNoteSaved = new Func<LabSampleReceiveItem, string>(c => c.strNote)(obj);
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LabSampleReceiveItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabSampleReceiveItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabSampleReceiveItem obj = LabSampleReceiveItem.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.FilterByDiagnosis = new Func<LabSampleReceiveItem, bool>(c => false)(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
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

            
            public LabSampleReceiveItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public LabSampleReceiveItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public LabSampleReceiveItem CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 5) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long?)) 
                    throw new TypeMismatchException("idfCase", typeof(long?));
                if (pars[1] != null && !(pars[1] is long?)) 
                    throw new TypeMismatchException("idfMonitoringSession", typeof(long?));
                if (pars[2] != null && !(pars[2] is long?)) 
                    throw new TypeMismatchException("idfsCaseType", typeof(long?));
                if (pars[3] != null && !(pars[3] is EditableList<LabSampleReceiveAnimal>)) 
                    throw new TypeMismatchException("Animals", typeof(EditableList<LabSampleReceiveAnimal>));
                if (pars[4] != null && !(pars[4] is EditableList<LabSampleReceiveDiagnosis>)) 
                    throw new TypeMismatchException("Diagnosis", typeof(EditableList<LabSampleReceiveDiagnosis>));
                
                return Create(manager, Parent
                    , (long?)pars[0]
                    , (long?)pars[1]
                    , (long?)pars[2]
                    , (EditableList<LabSampleReceiveAnimal>)pars[3]
                    , (EditableList<LabSampleReceiveDiagnosis>)pars[4]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public LabSampleReceiveItem Create(DbManagerProxy manager, IObject Parent
                , long? idfCase
                , long? idfMonitoringSession
                , long? idfsCaseType
                , EditableList<LabSampleReceiveAnimal> Animals
                , EditableList<LabSampleReceiveDiagnosis> Diagnosis
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfCase = new Func<LabSampleReceiveItem, long?>(c => idfCase)(obj);
                obj.idfMonitoringSession = new Func<LabSampleReceiveItem, long?>(c => idfMonitoringSession)(obj);
                obj.idfsCaseType = new Func<LabSampleReceiveItem, long?>(c => idfsCaseType)(obj);
                obj.idfMaterial = (new GetNewIDExtender<LabSampleReceiveItem>()).GetScalar(manager, obj);
                obj.datFieldCollectionDate = new Func<LabSampleReceiveItem, DateTime?>(c => DateTime.Now.Date)(obj);
                obj.datAccession = new Func<LabSampleReceiveItem, DateTime?>(c => DateTime.Now.Date)(obj);
                obj.Animals = new Func<LabSampleReceiveItem, EditableList<LabSampleReceiveAnimal>>(c => Animals)(obj);
                obj.Diagnosis = new Func<LabSampleReceiveItem, EditableList<LabSampleReceiveDiagnosis>>(c => Diagnosis)(obj);
                }
                    , obj =>
                {
                obj.AccessionCondition = new Func<LabSampleReceiveItem, BaseReference>(c => c.AccessionConditionLookup.Where(l => l.idfsBaseReference == (long)AccessionConditionEnum.AcceptedInGoodCondition).SingleOrDefault())(obj);
                obj.AccessionByPerson = new Func<LabSampleReceiveItem, PersonLookup>(c => c.AccessionByPersonLookup.Where(l => l.idfPerson == (long)EidssUserContext.User.EmployeeID).SingleOrDefault())(obj);
                obj.strBarcode = new Func<LabSampleReceiveItem, DbManagerProxy, string>((c,m) => 
                            m.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.Specimen, DBNull.Value, DBNull.Value)
                            .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue"))(obj, manager);
                obj.IsNewAcceeded = new Func<LabSampleReceiveItem, bool>(c => true)(obj);
                }
                );
            }
            
            public ActResult AccessionIn(DbManagerProxy manager, LabSampleReceiveItem obj, List<object> pars)
            {
                
                return AccessionIn(manager, obj
                    );
            }
            public ActResult AccessionIn(DbManagerProxy manager, LabSampleReceiveItem obj
                )
            {
                
                        obj.AccessionCondition = obj.AccessionConditionLookup.Where(l => l.idfsBaseReference == (long)AccessionConditionEnum.AcceptedInGoodCondition).SingleOrDefault();
                        obj.AccessionByPerson = obj.AccessionByPersonLookup.Where(l => l.idfPerson == (long)EidssUserContext.User.EmployeeID).SingleOrDefault();
                        obj.strBarcode = manager.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.Specimen, DBNull.Value, DBNull.Value)
                            .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue");
                        obj.datAccession = DateTime.Now;
                        obj.IsNewAcceeded = true;
                        return true;
                    
            }
            
            private void _SetupChildHandlers(LabSampleReceiveItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabSampleReceiveItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datFieldCollectionDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Collection Date_Sent Date", "datFieldCollectionDate", "datFieldCollectionDate", "datFieldCollectionDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datFieldCollectionDate, c.datFieldSentDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFieldCollectionDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datFieldSentDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Collection Date_Sent Date", "datFieldSentDate", "datFieldSentDate", "datFieldSentDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datFieldCollectionDate, c.datFieldSentDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFieldSentDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datFieldSentDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date Sent_Accession Date", "datFieldSentDate", "datFieldSentDate", "datFieldSentDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datFieldSentDate, c.datAccession)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFieldSentDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datAccession)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date Sent_Accession Date", "datAccession", "datAccession", "datAccession",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datFieldSentDate, c.datAccession)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datAccession);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_idfsSpecimenType)
                        {
                    
                obj.strSpecimenName = new Func<LabSampleReceiveItem, string>(c => c.SampleType == null ? "" : c.SampleType.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsAccessionCondition)
                        {
                    
                obj.strNote = new Func<LabSampleReceiveItem, string>(c => c.idfsAccessionCondition == (long)AccessionConditionEnum.Rejected ? "" : c.strNoteSaved)(obj);
                        }
                    
                        if (e.PropertyName == _str_strNote)
                        {
                    
                obj.strNoteSaved = new Func<LabSampleReceiveItem, string>(c => string.IsNullOrEmpty(c.strNote) ? c.strNoteSaved : c.strNote)(obj);
                        }
                    
                        if (e.PropertyName == _str_strFieldBarcode)
                        {
                    
                obj.strFieldBarcode2 = new Func<LabSampleReceiveItem, string>(c => c.strFieldBarcode)(obj);
                        }
                    
                        if (e.PropertyName == _str_FilterByDiagnosis)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_SampleType(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfParty)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_SampleType(manager, obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_SampleType(DbManagerProxy manager, LabSampleReceiveItem obj)
            {
                
                obj.SampleTypeLookup.Clear();
                
                obj.SampleTypeLookup.Add(SampleTypeAccessor.CreateNewT(manager, null));
                
                obj.SampleTypeLookup.AddRange(SampleTypeAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intHACode & obj.CaseHACode) != 0 || c.idfsReference == obj.idfsSpecimenType)
                        
                    .Where(c => !obj.FilterByDiagnosis ? 
                                (
                                    c.idfsDiagnosis == 0
                                )
                                :
                                (
                                    obj.Diagnosis
                                        .Where(i => i.idfsSpeciesType == 0 || i.idfsSpeciesType == null || (obj.Animal != null && i.idfsSpeciesType == obj.Animal.idfsSpeciesType))
                                        .Any(i => i.idfsDiagnosis == c.idfsDiagnosis) 
                                ))
                        
                    .Where(c => c.idfsReference != (long)SampleTypeEnum.Unknown)
                        
                    .Distinct(new SampleTypeForDiagnosisLookupComparator())
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsSpecimenType))
                    
                    .ToList());
                
                if (obj.idfsSpecimenType != 0)
                {
                    obj.SampleType = obj.SampleTypeLookup
                        .Where(c => c.idfsReference == obj.idfsSpecimenType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("SampleTypeForDiagnosisLookup", obj, SampleTypeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_AccessionCondition(DbManagerProxy manager, LabSampleReceiveItem obj)
            {
                
                obj.AccessionConditionLookup.Clear();
                
                obj.AccessionConditionLookup.Add(AccessionConditionAccessor.CreateNewT(manager, null));
                
                obj.AccessionConditionLookup.AddRange(AccessionConditionAccessor.rftAccessionCondition_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAccessionCondition))
                    
                    .ToList());
                
                if (obj.idfsAccessionCondition != null && obj.idfsAccessionCondition != 0)
                {
                    obj.AccessionCondition = obj.AccessionConditionLookup
                        .Where(c => c.idfsBaseReference == obj.idfsAccessionCondition)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftAccessionCondition", obj, AccessionConditionAccessor.GetType(), "rftAccessionCondition_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_AccessionByPerson(DbManagerProxy manager, LabSampleReceiveItem obj)
            {
                
                obj.AccessionByPersonLookup.Clear();
                
                obj.AccessionByPersonLookup.Add(AccessionByPersonAccessor.CreateNewT(manager, null));
                
                obj.AccessionByPersonLookup.AddRange(AccessionByPersonAccessor.SelectLookupList(manager
                    
                    , new Func<LabSampleReceiveItem, long>(c => eidss.model.Core.EidssSiteContext.Instance.OrganizationID)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfAccesionByPerson))
                    
                    .ToList());
                
                if (obj.idfAccesionByPerson != null && obj.idfAccesionByPerson != 0)
                {
                    obj.AccessionByPerson = obj.AccessionByPersonLookup
                        .Where(c => c.idfPerson == obj.idfAccesionByPerson)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("PersonLookup", obj, AccessionByPersonAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Department(DbManagerProxy manager, LabSampleReceiveItem obj)
            {
                
                obj.DepartmentLookup.Clear();
                
                obj.DepartmentLookup.Add(DepartmentAccessor.CreateNewT(manager, null));
                
                obj.DepartmentLookup.AddRange(DepartmentAccessor.SelectLookupList(manager
                    
                    , new Func<LabSampleReceiveItem, long>(c => eidss.model.Core.EidssSiteContext.Instance.OrganizationID)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfDepartment == obj.idfInDepartment))
                    
                    .ToList());
                
                if (obj.idfInDepartment != null && obj.idfInDepartment != 0)
                {
                    obj.Department = obj.DepartmentLookup
                        .Where(c => c.idfDepartment == obj.idfInDepartment)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("DepartmentLookup", obj, DepartmentAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Freezer(DbManagerProxy manager, LabSampleReceiveItem obj)
            {
                
                obj.FreezerLookup.Clear();
                
                obj.FreezerLookup.Add(FreezerAccessor.CreateNewT(manager, null));
                
                obj.FreezerLookup.AddRange(FreezerAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.ID == obj.idfSubdivision))
                    
                    .ToList());
                
                if (obj.idfSubdivision != null && obj.idfSubdivision != 0)
                {
                    obj.Freezer = obj.FreezerLookup
                        .Where(c => c.ID == obj.idfSubdivision)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("FreezerTreeLookup", obj, FreezerAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, LabSampleReceiveItem obj)
            {
                
                LoadLookup_SampleType(manager, obj);
                
                LoadLookup_AccessionCondition(manager, obj);
                
                LoadLookup_AccessionByPerson(manager, obj);
                
                LoadLookup_Department(manager, obj);
                
                LoadLookup_Freezer(manager, obj);
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spLabSampleReceive_PostDetail")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] LabSampleReceiveItem obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] LabSampleReceiveItem obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    LabSampleReceiveItem bo = obj as LabSampleReceiveItem;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as LabSampleReceiveItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, LabSampleReceiveItem obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (!obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(LabSampleReceiveItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, LabSampleReceiveItem obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as LabSampleReceiveItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabSampleReceiveItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsSpecimenType", "SampleType","",
                false
              )).Validate(c => true, obj, obj.idfsSpecimenType);
            
                (new RequiredValidator( "Spec", "Spec","Species",
                false
              )).Validate(c => c.idfsCaseType == (long)eidss.model.Enums.CaseTypeEnum.Avian, obj, obj.Spec);
            
                (new RequiredValidator( "Animal", "Animal","AnimalID",
                false
              )).Validate(c => c.idfsCaseType == null || c.idfsCaseType == (long)eidss.model.Enums.CaseTypeEnum.Livestock, obj, obj.Animal);
            
                (new RequiredValidator( "strBarcode", "strBarcode","strLabBarcode",
                false
              )).Validate(c => c.IsNewAcceeded /*&& c.idfsAccessionCondition != (long)AccessionConditionEnum.Rejected*/, obj, obj.strBarcode);
            
                (new RequiredValidator( "idfsAccessionCondition", "AccessionCondition","",
                false
              )).Validate(c => c.IsNewAcceeded, obj, obj.idfsAccessionCondition);
            
                (new RequiredValidator( "datAccession", "datAccession","",
                false
              )).Validate(c => c.IsNewAcceeded, obj, obj.datAccession);
            
                (new RequiredValidator( "strNote", "strNote","strComments",
                false
              )).Validate(c => c.IsNewAcceeded && c.idfsAccessionCondition != (long)AccessionConditionEnum.AcceptedInGoodCondition, obj, obj.strNote);
            
                (new RequiredValidator( "idfAccesionByPerson", "AccessionByPerson","strFieldCollectedByPerson",
                false
              )).Validate(c => c.IsNewAcceeded, obj, obj.idfAccesionByPerson);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                (new PredicateValidator("Collection Date_Sent Date", "datFieldCollectionDate", "datFieldCollectionDate", "datFieldCollectionDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datFieldCollectionDate, c.datFieldSentDate)
                    );
            
                (new PredicateValidator("Collection Date_Sent Date", "datFieldSentDate", "datFieldSentDate", "datFieldSentDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datFieldCollectionDate, c.datFieldSentDate)
                    );
            
                (new PredicateValidator("Date Sent_Accession Date", "datFieldSentDate", "datFieldSentDate", "datFieldSentDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datFieldSentDate, c.datAccession)
                    );
            
                (new PredicateValidator("Date Sent_Accession Date", "datAccession", "datAccession", "datAccession",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datFieldSentDate, c.datAccession)
                    );
            
                    }
                    
                    if (bDeepValidation)
                    {
                
                    }
                }
                catch(ValidationModelException ex)
                {
                    if (bRethrowException)
                        throw;
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                        return false;
                    }
                }
                
                return true;
            }
           
    
            private void _SetupRequired(LabSampleReceiveItem obj)
            {
            
                obj
                    .AddRequired("SampleType", c => true);
                    
                obj
                    .AddRequired("Spec", c => c.idfsCaseType == (long)eidss.model.Enums.CaseTypeEnum.Avian);
                    
                obj
                    .AddRequired("Animal", c => c.idfsCaseType == null || c.idfsCaseType == (long)eidss.model.Enums.CaseTypeEnum.Livestock);
                    
                obj
                    .AddRequired("strBarcode", c => c.IsNewAcceeded /*&& c.idfsAccessionCondition != (long)AccessionConditionEnum.Rejected*/);
                    
                obj
                    .AddRequired("AccessionCondition", c => c.IsNewAcceeded);
                    
                obj
                    .AddRequired("datAccession", c => c.IsNewAcceeded);
                    
                obj
                    .AddRequired("strNote", c => c.IsNewAcceeded && c.idfsAccessionCondition != (long)AccessionConditionEnum.AcceptedInGoodCondition);
                    
                obj
                    .AddRequired("AccessionByPerson", c => c.IsNewAcceeded);
                    
            }
    
    private void _SetupPersonalDataRestrictions(LabSampleReceiveItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabSampleReceiveItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabSampleReceiveItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabSampleReceiveItemDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spLabSampleReceive_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spLabSampleReceive_PostDetail";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabSampleReceiveItem, bool>> RequiredByField = new Dictionary<string, Func<LabSampleReceiveItem, bool>>();
            public static Dictionary<string, Func<LabSampleReceiveItem, bool>> RequiredByProperty = new Dictionary<string, Func<LabSampleReceiveItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_AnimalName, 2000);
                Sizes.Add(_str_strAnimalCode, 200);
                Sizes.Add(_str_SpeciesName, 2000);
                Sizes.Add(_str_strFarmCode, 200);
                Sizes.Add(_str_strFieldCollectedByPerson, 602);
                Sizes.Add(_str_strFieldCollectedByOffice, 2000);
                Sizes.Add(_str_strSendToOffice, 2000);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strSpecimenName, 2000);
                Sizes.Add(_str_strCondition, 200);
                Sizes.Add(_str_strNote, 500);
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strVectorID, 50);
                Sizes.Add(_str_strVectorType, 2000);
                Sizes.Add(_str_strVectorSpecies, 2000);
                Sizes.Add(_str_strFieldBarcode2, 200);
                if (!RequiredByField.ContainsKey("idfsSpecimenType")) RequiredByField.Add("idfsSpecimenType", c => true);
                if (!RequiredByProperty.ContainsKey("SampleType")) RequiredByProperty.Add("SampleType", c => true);
                
                if (!RequiredByField.ContainsKey("Spec")) RequiredByField.Add("Spec", c => c.idfsCaseType == (long)eidss.model.Enums.CaseTypeEnum.Avian);
                if (!RequiredByProperty.ContainsKey("Spec")) RequiredByProperty.Add("Spec", c => c.idfsCaseType == (long)eidss.model.Enums.CaseTypeEnum.Avian);
                
                if (!RequiredByField.ContainsKey("Animal")) RequiredByField.Add("Animal", c => c.idfsCaseType == null || c.idfsCaseType == (long)eidss.model.Enums.CaseTypeEnum.Livestock);
                if (!RequiredByProperty.ContainsKey("Animal")) RequiredByProperty.Add("Animal", c => c.idfsCaseType == null || c.idfsCaseType == (long)eidss.model.Enums.CaseTypeEnum.Livestock);
                
                if (!RequiredByField.ContainsKey("strBarcode")) RequiredByField.Add("strBarcode", c => c.IsNewAcceeded /*&& c.idfsAccessionCondition != (long)AccessionConditionEnum.Rejected*/);
                if (!RequiredByProperty.ContainsKey("strBarcode")) RequiredByProperty.Add("strBarcode", c => c.IsNewAcceeded /*&& c.idfsAccessionCondition != (long)AccessionConditionEnum.Rejected*/);
                
                if (!RequiredByField.ContainsKey("idfsAccessionCondition")) RequiredByField.Add("idfsAccessionCondition", c => c.IsNewAcceeded);
                if (!RequiredByProperty.ContainsKey("AccessionCondition")) RequiredByProperty.Add("AccessionCondition", c => c.IsNewAcceeded);
                
                if (!RequiredByField.ContainsKey("datAccession")) RequiredByField.Add("datAccession", c => c.IsNewAcceeded);
                if (!RequiredByProperty.ContainsKey("datAccession")) RequiredByProperty.Add("datAccession", c => c.IsNewAcceeded);
                
                if (!RequiredByField.ContainsKey("strNote")) RequiredByField.Add("strNote", c => c.IsNewAcceeded && c.idfsAccessionCondition != (long)AccessionConditionEnum.AcceptedInGoodCondition);
                if (!RequiredByProperty.ContainsKey("strNote")) RequiredByProperty.Add("strNote", c => c.IsNewAcceeded && c.idfsAccessionCondition != (long)AccessionConditionEnum.AcceptedInGoodCondition);
                
                if (!RequiredByField.ContainsKey("idfAccesionByPerson")) RequiredByField.Add("idfAccesionByPerson", c => c.IsNewAcceeded);
                if (!RequiredByProperty.ContainsKey("AccessionByPerson")) RequiredByProperty.Add("AccessionByPerson", c => c.IsNewAcceeded);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfMaterial,
                    _str_idfMaterial, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsAccessionCondition,
                    _str_idfsAccessionCondition, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpecimenName,
                    "idfsSpecimenType", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode2,
                    "strFieldBarcodeField", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode,
                    "strFieldBarcodeLocal", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalID,
                    _str_AnimalID, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Species,
                    _str_Species, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBarcode,
                    "strLabBarcode", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldCollectionDate,
                    _str_datFieldCollectionDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datAccession,
                    _str_datAccession, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAccessionCondition,
                    "idfsAccessionCondition", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNote,
                    "strComment", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDepartment,
                    _str_strDepartment, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFreezer,
                    "strFreezerName", null, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).Create(manager, c, pars)),
                        
                    null,
                    
                    null,
                      false,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "AccessionIn",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).AccessionIn(manager, (LabSampleReceiveItem)c, pars),
                        
                    null,
                    
                    null,
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
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, null, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
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
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((LabSampleReceiveItem)c).MarkToDelete() && ObjectAccessor.PostInterface<LabSampleReceiveItem>().Post(manager, (LabSampleReceiveItem)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabSampleReceiveItem>().Post(manager, (LabSampleReceiveItem)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
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
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabSampleReceiveItem>().Post(manager, (LabSampleReceiveItem)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
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
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class LabSampleReceiveAnimal : 
        EditableObject<LabSampleReceiveAnimal>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfParty), NonUpdatable, PrimaryKey]
        public abstract Int64 idfParty { get; set; }
                
        [LocalizedDisplayName(_str_idfSpecies)]
        [MapField(_str_idfSpecies)]
        public abstract Int64? idfSpecies { get; set; }
        #if MONO
        protected Int64? idfSpecies_Original { get { return idfSpecies; } }
        protected Int64? idfSpecies_Previous { get { return idfSpecies; } }
        #else
        protected Int64? idfSpecies_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).OriginalValue; } }
        protected Int64? idfSpecies_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfAnimal)]
        [MapField(_str_idfAnimal)]
        public abstract Int64? idfAnimal { get; set; }
        #if MONO
        protected Int64? idfAnimal_Original { get { return idfAnimal; } }
        protected Int64? idfAnimal_Previous { get { return idfAnimal; } }
        #else
        protected Int64? idfAnimal_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAnimal).OriginalValue; } }
        protected Int64? idfAnimal_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAnimal).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strAnimalCode)]
        [MapField(_str_strAnimalCode)]
        public abstract String strAnimalCode { get; set; }
        #if MONO
        protected String strAnimalCode_Original { get { return strAnimalCode; } }
        protected String strAnimalCode_Previous { get { return strAnimalCode; } }
        #else
        protected String strAnimalCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strAnimalCode).OriginalValue; } }
        protected String strAnimalCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAnimalCode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSpecies)]
        [MapField(_str_strSpecies)]
        public abstract String strSpecies { get; set; }
        #if MONO
        protected String strSpecies_Original { get { return strSpecies; } }
        protected String strSpecies_Previous { get { return strSpecies; } }
        #else
        protected String strSpecies_Original { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).OriginalValue; } }
        protected String strSpecies_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSpeciesType)]
        [MapField(_str_idfsSpeciesType)]
        public abstract Int64? idfsSpeciesType { get; set; }
        #if MONO
        protected Int64? idfsSpeciesType_Original { get { return idfsSpeciesType; } }
        protected Int64? idfsSpeciesType_Previous { get { return idfsSpeciesType; } }
        #else
        protected Int64? idfsSpeciesType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).OriginalValue; } }
        protected Int64? idfsSpeciesType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strGender)]
        [MapField(_str_strGender)]
        public abstract String strGender { get; set; }
        #if MONO
        protected String strGender_Original { get { return strGender; } }
        protected String strGender_Previous { get { return strGender; } }
        #else
        protected String strGender_Original { get { return ((EditableValue<String>)((dynamic)this)._strGender).OriginalValue; } }
        protected String strGender_Previous { get { return ((EditableValue<String>)((dynamic)this)._strGender).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_ParentID)]
        [MapField(_str_ParentID)]
        public abstract Int64? ParentID { get; set; }
        #if MONO
        protected Int64? ParentID_Original { get { return ParentID; } }
        protected Int64? ParentID_Previous { get { return ParentID; } }
        #else
        protected Int64? ParentID_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._parentID).OriginalValue; } }
        protected Int64? ParentID_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._parentID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strTests)]
        [MapField(_str_strTests)]
        public abstract Int32 strTests { get; set; }
        #if MONO
        protected Int32 strTests_Original { get { return strTests; } }
        protected Int32 strTests_Previous { get { return strTests; } }
        #else
        protected Int32 strTests_Original { get { return ((EditableValue<Int32>)((dynamic)this)._strTests).OriginalValue; } }
        protected Int32 strTests_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._strTests).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<LabSampleReceiveAnimal, object> _get_func;
            internal Action<LabSampleReceiveAnimal, string> _set_func;
            internal Action<LabSampleReceiveAnimal, LabSampleReceiveAnimal, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfParty = "idfParty";
        internal const string _str_idfSpecies = "idfSpecies";
        internal const string _str_idfAnimal = "idfAnimal";
        internal const string _str_strAnimalCode = "strAnimalCode";
        internal const string _str_strSpecies = "strSpecies";
        internal const string _str_idfsSpeciesType = "idfsSpeciesType";
        internal const string _str_strGender = "strGender";
        internal const string _str_ParentID = "ParentID";
        internal const string _str_strTests = "strTests";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfParty, _type = "Int64",
              _get_func = o => o.idfParty,
              _set_func = (o, val) => { o.idfParty = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_idfParty, c)) 
                  m.Add(_str_idfParty, o.ObjectIdent + _str_idfParty, "Int64", o.idfParty == null ? "" : o.idfParty.ToString(), o.IsReadOnly(_str_idfParty), o.IsInvisible(_str_idfParty), o.IsRequired(_str_idfParty)); }
              }, 
        
            new field_info {
              _name = _str_idfSpecies, _type = "Int64?",
              _get_func = o => o.idfSpecies,
              _set_func = (o, val) => { o.idfSpecies = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSpecies != c.idfSpecies || o.IsRIRPropChanged(_str_idfSpecies, c)) 
                  m.Add(_str_idfSpecies, o.ObjectIdent + _str_idfSpecies, "Int64?", o.idfSpecies == null ? "" : o.idfSpecies.ToString(), o.IsReadOnly(_str_idfSpecies), o.IsInvisible(_str_idfSpecies), o.IsRequired(_str_idfSpecies)); }
              }, 
        
            new field_info {
              _name = _str_idfAnimal, _type = "Int64?",
              _get_func = o => o.idfAnimal,
              _set_func = (o, val) => { o.idfAnimal = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfAnimal != c.idfAnimal || o.IsRIRPropChanged(_str_idfAnimal, c)) 
                  m.Add(_str_idfAnimal, o.ObjectIdent + _str_idfAnimal, "Int64?", o.idfAnimal == null ? "" : o.idfAnimal.ToString(), o.IsReadOnly(_str_idfAnimal), o.IsInvisible(_str_idfAnimal), o.IsRequired(_str_idfAnimal)); }
              }, 
        
            new field_info {
              _name = _str_strAnimalCode, _type = "String",
              _get_func = o => o.strAnimalCode,
              _set_func = (o, val) => { o.strAnimalCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strAnimalCode != c.strAnimalCode || o.IsRIRPropChanged(_str_strAnimalCode, c)) 
                  m.Add(_str_strAnimalCode, o.ObjectIdent + _str_strAnimalCode, "String", o.strAnimalCode == null ? "" : o.strAnimalCode.ToString(), o.IsReadOnly(_str_strAnimalCode), o.IsInvisible(_str_strAnimalCode), o.IsRequired(_str_strAnimalCode)); }
              }, 
        
            new field_info {
              _name = _str_strSpecies, _type = "String",
              _get_func = o => o.strSpecies,
              _set_func = (o, val) => { o.strSpecies = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSpecies != c.strSpecies || o.IsRIRPropChanged(_str_strSpecies, c)) 
                  m.Add(_str_strSpecies, o.ObjectIdent + _str_strSpecies, "String", o.strSpecies == null ? "" : o.strSpecies.ToString(), o.IsReadOnly(_str_strSpecies), o.IsInvisible(_str_strSpecies), o.IsRequired(_str_strSpecies)); }
              }, 
        
            new field_info {
              _name = _str_idfsSpeciesType, _type = "Int64?",
              _get_func = o => o.idfsSpeciesType,
              _set_func = (o, val) => { o.idfsSpeciesType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_idfsSpeciesType, c)) 
                  m.Add(_str_idfsSpeciesType, o.ObjectIdent + _str_idfsSpeciesType, "Int64?", o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(), o.IsReadOnly(_str_idfsSpeciesType), o.IsInvisible(_str_idfsSpeciesType), o.IsRequired(_str_idfsSpeciesType)); }
              }, 
        
            new field_info {
              _name = _str_strGender, _type = "String",
              _get_func = o => o.strGender,
              _set_func = (o, val) => { o.strGender = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strGender != c.strGender || o.IsRIRPropChanged(_str_strGender, c)) 
                  m.Add(_str_strGender, o.ObjectIdent + _str_strGender, "String", o.strGender == null ? "" : o.strGender.ToString(), o.IsReadOnly(_str_strGender), o.IsInvisible(_str_strGender), o.IsRequired(_str_strGender)); }
              }, 
        
            new field_info {
              _name = _str_ParentID, _type = "Int64?",
              _get_func = o => o.ParentID,
              _set_func = (o, val) => { o.ParentID = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.ParentID != c.ParentID || o.IsRIRPropChanged(_str_ParentID, c)) 
                  m.Add(_str_ParentID, o.ObjectIdent + _str_ParentID, "Int64?", o.ParentID == null ? "" : o.ParentID.ToString(), o.IsReadOnly(_str_ParentID), o.IsInvisible(_str_ParentID), o.IsRequired(_str_ParentID)); }
              }, 
        
            new field_info {
              _name = _str_strTests, _type = "Int32",
              _get_func = o => o.strTests,
              _set_func = (o, val) => { o.strTests = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.strTests != c.strTests || o.IsRIRPropChanged(_str_strTests, c)) 
                  m.Add(_str_strTests, o.ObjectIdent + _str_strTests, "Int32", o.strTests == null ? "" : o.strTests.ToString(), o.IsReadOnly(_str_strTests), o.IsInvisible(_str_strTests), o.IsRequired(_str_strTests)); }
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
            LabSampleReceiveAnimal obj = (LabSampleReceiveAnimal)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LabSampleReceiveAnimal";

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
            var ret = base.Clone() as LabSampleReceiveAnimal;
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
            var ret = base.Clone() as LabSampleReceiveAnimal;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public LabSampleReceiveAnimal CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabSampleReceiveAnimal;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfParty; } }
        public string KeyName { get { return "idfParty"; } }
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
        
            base.RejectChanges();
        
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

      private bool IsRIRPropChanged(string fld, LabSampleReceiveAnimal c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      
        public override string ToString()
        {
            return new Func<LabSampleReceiveAnimal, string>(c => c.idfAnimal == null ? c.strSpecies : c.strAnimalCode)(this);
        }
        

        public LabSampleReceiveAnimal()
        {
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabSampleReceiveAnimal_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabSampleReceiveAnimal_PropertyChanged);
        }
        private void LabSampleReceiveAnimal_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabSampleReceiveAnimal).Changed(e.PropertyName);
            
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
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            LabSampleReceiveAnimal obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabSampleReceiveAnimal obj = this;
            
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

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
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


        public Dictionary<string, Func<LabSampleReceiveAnimal, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabSampleReceiveAnimal, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabSampleReceiveAnimal, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabSampleReceiveAnimal, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabSampleReceiveAnimal, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<LabSampleReceiveAnimal, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LabSampleReceiveAnimal()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
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
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<LabSampleReceiveAnimal>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(LabSampleReceiveAnimal obj);
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
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual LabSampleReceiveAnimal SelectByKey(DbManagerProxy manager
                , Int64? CaseID
                )
            {
                return _SelectByKey(manager
                    , CaseID
                    , null, null
                    );
            }
            
      
            private LabSampleReceiveAnimal _SelectByKey(DbManagerProxy manager
                , Int64? CaseID
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabSampleReceiveAnimal obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LabSampleReceiveAnimal obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabSampleReceiveAnimal _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabSampleReceiveAnimal obj = LabSampleReceiveAnimal.CreateInstance();
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

            
            public LabSampleReceiveAnimal CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public LabSampleReceiveAnimal CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(LabSampleReceiveAnimal obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabSampleReceiveAnimal obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, LabSampleReceiveAnimal obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as LabSampleReceiveAnimal, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabSampleReceiveAnimal obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(LabSampleReceiveAnimal obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LabSampleReceiveAnimal obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabSampleReceiveAnimal) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabSampleReceiveAnimal) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabSampleReceiveAnimalDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spLabSampleReceive_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabSampleReceiveAnimal, bool>> RequiredByField = new Dictionary<string, Func<LabSampleReceiveAnimal, bool>>();
            public static Dictionary<string, Func<LabSampleReceiveAnimal, bool>> RequiredByProperty = new Dictionary<string, Func<LabSampleReceiveAnimal, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strAnimalCode, 200);
                Sizes.Add(_str_strSpecies, 2000);
                Sizes.Add(_str_strGender, 2000);
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, null, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
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
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((LabSampleReceiveAnimal)c).MarkToDelete() && ObjectAccessor.PostInterface<LabSampleReceiveAnimal>().Post(manager, (LabSampleReceiveAnimal)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabSampleReceiveAnimal>().Post(manager, (LabSampleReceiveAnimal)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
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
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabSampleReceiveAnimal>().Post(manager, (LabSampleReceiveAnimal)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
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
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class LabSampleReceiveAntibiotic : 
        EditableObject<LabSampleReceiveAntibiotic>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfAntimicrobialTherapy), NonUpdatable, PrimaryKey]
        public abstract Int64 idfAntimicrobialTherapy { get; set; }
                
        [LocalizedDisplayName(_str_strAntimicrobialTherapyName)]
        [MapField(_str_strAntimicrobialTherapyName)]
        public abstract String strAntimicrobialTherapyName { get; set; }
        #if MONO
        protected String strAntimicrobialTherapyName_Original { get { return strAntimicrobialTherapyName; } }
        protected String strAntimicrobialTherapyName_Previous { get { return strAntimicrobialTherapyName; } }
        #else
        protected String strAntimicrobialTherapyName_Original { get { return ((EditableValue<String>)((dynamic)this)._strAntimicrobialTherapyName).OriginalValue; } }
        protected String strAntimicrobialTherapyName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAntimicrobialTherapyName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfHumanCase)]
        [MapField(_str_idfHumanCase)]
        public abstract Int64 idfHumanCase { get; set; }
        #if MONO
        protected Int64 idfHumanCase_Original { get { return idfHumanCase; } }
        protected Int64 idfHumanCase_Previous { get { return idfHumanCase; } }
        #else
        protected Int64 idfHumanCase_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfHumanCase).OriginalValue; } }
        protected Int64 idfHumanCase_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfHumanCase).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<LabSampleReceiveAntibiotic, object> _get_func;
            internal Action<LabSampleReceiveAntibiotic, string> _set_func;
            internal Action<LabSampleReceiveAntibiotic, LabSampleReceiveAntibiotic, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfAntimicrobialTherapy = "idfAntimicrobialTherapy";
        internal const string _str_strAntimicrobialTherapyName = "strAntimicrobialTherapyName";
        internal const string _str_idfHumanCase = "idfHumanCase";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfAntimicrobialTherapy, _type = "Int64",
              _get_func = o => o.idfAntimicrobialTherapy,
              _set_func = (o, val) => { o.idfAntimicrobialTherapy = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfAntimicrobialTherapy != c.idfAntimicrobialTherapy || o.IsRIRPropChanged(_str_idfAntimicrobialTherapy, c)) 
                  m.Add(_str_idfAntimicrobialTherapy, o.ObjectIdent + _str_idfAntimicrobialTherapy, "Int64", o.idfAntimicrobialTherapy == null ? "" : o.idfAntimicrobialTherapy.ToString(), o.IsReadOnly(_str_idfAntimicrobialTherapy), o.IsInvisible(_str_idfAntimicrobialTherapy), o.IsRequired(_str_idfAntimicrobialTherapy)); }
              }, 
        
            new field_info {
              _name = _str_strAntimicrobialTherapyName, _type = "String",
              _get_func = o => o.strAntimicrobialTherapyName,
              _set_func = (o, val) => { o.strAntimicrobialTherapyName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strAntimicrobialTherapyName != c.strAntimicrobialTherapyName || o.IsRIRPropChanged(_str_strAntimicrobialTherapyName, c)) 
                  m.Add(_str_strAntimicrobialTherapyName, o.ObjectIdent + _str_strAntimicrobialTherapyName, "String", o.strAntimicrobialTherapyName == null ? "" : o.strAntimicrobialTherapyName.ToString(), o.IsReadOnly(_str_strAntimicrobialTherapyName), o.IsInvisible(_str_strAntimicrobialTherapyName), o.IsRequired(_str_strAntimicrobialTherapyName)); }
              }, 
        
            new field_info {
              _name = _str_idfHumanCase, _type = "Int64",
              _get_func = o => o.idfHumanCase,
              _set_func = (o, val) => { o.idfHumanCase = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfHumanCase != c.idfHumanCase || o.IsRIRPropChanged(_str_idfHumanCase, c)) 
                  m.Add(_str_idfHumanCase, o.ObjectIdent + _str_idfHumanCase, "Int64", o.idfHumanCase == null ? "" : o.idfHumanCase.ToString(), o.IsReadOnly(_str_idfHumanCase), o.IsInvisible(_str_idfHumanCase), o.IsRequired(_str_idfHumanCase)); }
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
            LabSampleReceiveAntibiotic obj = (LabSampleReceiveAntibiotic)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LabSampleReceiveAntibiotic";

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
            var ret = base.Clone() as LabSampleReceiveAntibiotic;
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
            var ret = base.Clone() as LabSampleReceiveAntibiotic;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public LabSampleReceiveAntibiotic CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabSampleReceiveAntibiotic;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfAntimicrobialTherapy; } }
        public string KeyName { get { return "idfAntimicrobialTherapy"; } }
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
        
            base.RejectChanges();
        
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

      private bool IsRIRPropChanged(string fld, LabSampleReceiveAntibiotic c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabSampleReceiveAntibiotic()
        {
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabSampleReceiveAntibiotic_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabSampleReceiveAntibiotic_PropertyChanged);
        }
        private void LabSampleReceiveAntibiotic_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabSampleReceiveAntibiotic).Changed(e.PropertyName);
            
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
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            LabSampleReceiveAntibiotic obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabSampleReceiveAntibiotic obj = this;
            
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

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
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


        public Dictionary<string, Func<LabSampleReceiveAntibiotic, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabSampleReceiveAntibiotic, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabSampleReceiveAntibiotic, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabSampleReceiveAntibiotic, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabSampleReceiveAntibiotic, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<LabSampleReceiveAntibiotic, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LabSampleReceiveAntibiotic()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
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
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<LabSampleReceiveAntibiotic>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(LabSampleReceiveAntibiotic obj);
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
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual LabSampleReceiveAntibiotic SelectByKey(DbManagerProxy manager
                , Int64? CaseID
                )
            {
                return _SelectByKey(manager
                    , CaseID
                    , null, null
                    );
            }
            
      
            private LabSampleReceiveAntibiotic _SelectByKey(DbManagerProxy manager
                , Int64? CaseID
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabSampleReceiveAntibiotic obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LabSampleReceiveAntibiotic obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabSampleReceiveAntibiotic _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabSampleReceiveAntibiotic obj = LabSampleReceiveAntibiotic.CreateInstance();
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

            
            public LabSampleReceiveAntibiotic CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public LabSampleReceiveAntibiotic CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(LabSampleReceiveAntibiotic obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabSampleReceiveAntibiotic obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, LabSampleReceiveAntibiotic obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as LabSampleReceiveAntibiotic, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabSampleReceiveAntibiotic obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(LabSampleReceiveAntibiotic obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LabSampleReceiveAntibiotic obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabSampleReceiveAntibiotic) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabSampleReceiveAntibiotic) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabSampleReceiveAntibioticDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spLabSampleReceive_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabSampleReceiveAntibiotic, bool>> RequiredByField = new Dictionary<string, Func<LabSampleReceiveAntibiotic, bool>>();
            public static Dictionary<string, Func<LabSampleReceiveAntibiotic, bool>> RequiredByProperty = new Dictionary<string, Func<LabSampleReceiveAntibiotic, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strAntimicrobialTherapyName, 200);
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, null, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
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
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((LabSampleReceiveAntibiotic)c).MarkToDelete() && ObjectAccessor.PostInterface<LabSampleReceiveAntibiotic>().Post(manager, (LabSampleReceiveAntibiotic)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabSampleReceiveAntibiotic>().Post(manager, (LabSampleReceiveAntibiotic)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
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
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabSampleReceiveAntibiotic>().Post(manager, (LabSampleReceiveAntibiotic)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
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
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class LabSampleReceiveVector : 
        EditableObject<LabSampleReceiveVector>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfParty), NonUpdatable, PrimaryKey]
        public abstract Int64 idfParty { get; set; }
                
        [LocalizedDisplayName(_str_idfVector)]
        [MapField(_str_idfVector)]
        public abstract Int64 idfVector { get; set; }
        #if MONO
        protected Int64 idfVector_Original { get { return idfVector; } }
        protected Int64 idfVector_Previous { get { return idfVector; } }
        #else
        protected Int64 idfVector_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfVector).OriginalValue; } }
        protected Int64 idfVector_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfVector).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsVectorType)]
        [MapField(_str_idfsVectorType)]
        public abstract Int64 idfsVectorType { get; set; }
        #if MONO
        protected Int64 idfsVectorType_Original { get { return idfsVectorType; } }
        protected Int64 idfsVectorType_Previous { get { return idfsVectorType; } }
        #else
        protected Int64 idfsVectorType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).OriginalValue; } }
        protected Int64 idfsVectorType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strVectorID)]
        [MapField(_str_strVectorID)]
        public abstract String strVectorID { get; set; }
        #if MONO
        protected String strVectorID_Original { get { return strVectorID; } }
        protected String strVectorID_Previous { get { return strVectorID; } }
        #else
        protected String strVectorID_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).OriginalValue; } }
        protected String strVectorID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strVectorType)]
        [MapField(_str_strVectorType)]
        public abstract String strVectorType { get; set; }
        #if MONO
        protected String strVectorType_Original { get { return strVectorType; } }
        protected String strVectorType_Previous { get { return strVectorType; } }
        #else
        protected String strVectorType_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).OriginalValue; } }
        protected String strVectorType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strVectorSpecies)]
        [MapField(_str_strVectorSpecies)]
        public abstract String strVectorSpecies { get; set; }
        #if MONO
        protected String strVectorSpecies_Original { get { return strVectorSpecies; } }
        protected String strVectorSpecies_Previous { get { return strVectorSpecies; } }
        #else
        protected String strVectorSpecies_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorSpecies).OriginalValue; } }
        protected String strVectorSpecies_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorSpecies).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_ParentID)]
        [MapField(_str_ParentID)]
        public abstract Int64 ParentID { get; set; }
        #if MONO
        protected Int64 ParentID_Original { get { return ParentID; } }
        protected Int64 ParentID_Previous { get { return ParentID; } }
        #else
        protected Int64 ParentID_Original { get { return ((EditableValue<Int64>)((dynamic)this)._parentID).OriginalValue; } }
        protected Int64 ParentID_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._parentID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strTests)]
        [MapField(_str_strTests)]
        public abstract Int32 strTests { get; set; }
        #if MONO
        protected Int32 strTests_Original { get { return strTests; } }
        protected Int32 strTests_Previous { get { return strTests; } }
        #else
        protected Int32 strTests_Original { get { return ((EditableValue<Int32>)((dynamic)this)._strTests).OriginalValue; } }
        protected Int32 strTests_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._strTests).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_SampleFilter)]
        [MapField(_str_SampleFilter)]
        public abstract String SampleFilter { get; set; }
        #if MONO
        protected String SampleFilter_Original { get { return SampleFilter; } }
        protected String SampleFilter_Previous { get { return SampleFilter; } }
        #else
        protected String SampleFilter_Original { get { return ((EditableValue<String>)((dynamic)this)._sampleFilter).OriginalValue; } }
        protected String SampleFilter_Previous { get { return ((EditableValue<String>)((dynamic)this)._sampleFilter).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<LabSampleReceiveVector, object> _get_func;
            internal Action<LabSampleReceiveVector, string> _set_func;
            internal Action<LabSampleReceiveVector, LabSampleReceiveVector, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfParty = "idfParty";
        internal const string _str_idfVector = "idfVector";
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_strVectorID = "strVectorID";
        internal const string _str_strVectorType = "strVectorType";
        internal const string _str_strVectorSpecies = "strVectorSpecies";
        internal const string _str_ParentID = "ParentID";
        internal const string _str_strTests = "strTests";
        internal const string _str_SampleFilter = "SampleFilter";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfParty, _type = "Int64",
              _get_func = o => o.idfParty,
              _set_func = (o, val) => { o.idfParty = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_idfParty, c)) 
                  m.Add(_str_idfParty, o.ObjectIdent + _str_idfParty, "Int64", o.idfParty == null ? "" : o.idfParty.ToString(), o.IsReadOnly(_str_idfParty), o.IsInvisible(_str_idfParty), o.IsRequired(_str_idfParty)); }
              }, 
        
            new field_info {
              _name = _str_idfVector, _type = "Int64",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { o.idfVector = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) 
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, "Int64", o.idfVector == null ? "" : o.idfVector.ToString(), o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector)); }
              }, 
        
            new field_info {
              _name = _str_idfsVectorType, _type = "Int64",
              _get_func = o => o.idfsVectorType,
              _set_func = (o, val) => { o.idfsVectorType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_idfsVectorType, c)) 
                  m.Add(_str_idfsVectorType, o.ObjectIdent + _str_idfsVectorType, "Int64", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_idfsVectorType), o.IsInvisible(_str_idfsVectorType), o.IsRequired(_str_idfsVectorType)); }
              }, 
        
            new field_info {
              _name = _str_strVectorID, _type = "String",
              _get_func = o => o.strVectorID,
              _set_func = (o, val) => { o.strVectorID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorID != c.strVectorID || o.IsRIRPropChanged(_str_strVectorID, c)) 
                  m.Add(_str_strVectorID, o.ObjectIdent + _str_strVectorID, "String", o.strVectorID == null ? "" : o.strVectorID.ToString(), o.IsReadOnly(_str_strVectorID), o.IsInvisible(_str_strVectorID), o.IsRequired(_str_strVectorID)); }
              }, 
        
            new field_info {
              _name = _str_strVectorType, _type = "String",
              _get_func = o => o.strVectorType,
              _set_func = (o, val) => { o.strVectorType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorType != c.strVectorType || o.IsRIRPropChanged(_str_strVectorType, c)) 
                  m.Add(_str_strVectorType, o.ObjectIdent + _str_strVectorType, "String", o.strVectorType == null ? "" : o.strVectorType.ToString(), o.IsReadOnly(_str_strVectorType), o.IsInvisible(_str_strVectorType), o.IsRequired(_str_strVectorType)); }
              }, 
        
            new field_info {
              _name = _str_strVectorSpecies, _type = "String",
              _get_func = o => o.strVectorSpecies,
              _set_func = (o, val) => { o.strVectorSpecies = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorSpecies != c.strVectorSpecies || o.IsRIRPropChanged(_str_strVectorSpecies, c)) 
                  m.Add(_str_strVectorSpecies, o.ObjectIdent + _str_strVectorSpecies, "String", o.strVectorSpecies == null ? "" : o.strVectorSpecies.ToString(), o.IsReadOnly(_str_strVectorSpecies), o.IsInvisible(_str_strVectorSpecies), o.IsRequired(_str_strVectorSpecies)); }
              }, 
        
            new field_info {
              _name = _str_ParentID, _type = "Int64",
              _get_func = o => o.ParentID,
              _set_func = (o, val) => { o.ParentID = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.ParentID != c.ParentID || o.IsRIRPropChanged(_str_ParentID, c)) 
                  m.Add(_str_ParentID, o.ObjectIdent + _str_ParentID, "Int64", o.ParentID == null ? "" : o.ParentID.ToString(), o.IsReadOnly(_str_ParentID), o.IsInvisible(_str_ParentID), o.IsRequired(_str_ParentID)); }
              }, 
        
            new field_info {
              _name = _str_strTests, _type = "Int32",
              _get_func = o => o.strTests,
              _set_func = (o, val) => { o.strTests = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.strTests != c.strTests || o.IsRIRPropChanged(_str_strTests, c)) 
                  m.Add(_str_strTests, o.ObjectIdent + _str_strTests, "Int32", o.strTests == null ? "" : o.strTests.ToString(), o.IsReadOnly(_str_strTests), o.IsInvisible(_str_strTests), o.IsRequired(_str_strTests)); }
              }, 
        
            new field_info {
              _name = _str_SampleFilter, _type = "String",
              _get_func = o => o.SampleFilter,
              _set_func = (o, val) => { o.SampleFilter = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.SampleFilter != c.SampleFilter || o.IsRIRPropChanged(_str_SampleFilter, c)) 
                  m.Add(_str_SampleFilter, o.ObjectIdent + _str_SampleFilter, "String", o.SampleFilter == null ? "" : o.SampleFilter.ToString(), o.IsReadOnly(_str_SampleFilter), o.IsInvisible(_str_SampleFilter), o.IsRequired(_str_SampleFilter)); }
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
            LabSampleReceiveVector obj = (LabSampleReceiveVector)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LabSampleReceiveVector";

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
            var ret = base.Clone() as LabSampleReceiveVector;
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
            var ret = base.Clone() as LabSampleReceiveVector;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public LabSampleReceiveVector CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabSampleReceiveVector;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfParty; } }
        public string KeyName { get { return "idfParty"; } }
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
        
            base.RejectChanges();
        
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

      private bool IsRIRPropChanged(string fld, LabSampleReceiveVector c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabSampleReceiveVector()
        {
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabSampleReceiveVector_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabSampleReceiveVector_PropertyChanged);
        }
        private void LabSampleReceiveVector_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabSampleReceiveVector).Changed(e.PropertyName);
            
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
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            LabSampleReceiveVector obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabSampleReceiveVector obj = this;
            
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

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
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


        public Dictionary<string, Func<LabSampleReceiveVector, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabSampleReceiveVector, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabSampleReceiveVector, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabSampleReceiveVector, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabSampleReceiveVector, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<LabSampleReceiveVector, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LabSampleReceiveVector()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
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
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<LabSampleReceiveVector>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(LabSampleReceiveVector obj);
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
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual LabSampleReceiveVector SelectByKey(DbManagerProxy manager
                , Int64? CaseID
                )
            {
                return _SelectByKey(manager
                    , CaseID
                    , null, null
                    );
            }
            
      
            private LabSampleReceiveVector _SelectByKey(DbManagerProxy manager
                , Int64? CaseID
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabSampleReceiveVector obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LabSampleReceiveVector obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabSampleReceiveVector _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabSampleReceiveVector obj = LabSampleReceiveVector.CreateInstance();
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

            
            public LabSampleReceiveVector CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public LabSampleReceiveVector CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(LabSampleReceiveVector obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabSampleReceiveVector obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, LabSampleReceiveVector obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as LabSampleReceiveVector, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabSampleReceiveVector obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(LabSampleReceiveVector obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LabSampleReceiveVector obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabSampleReceiveVector) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabSampleReceiveVector) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabSampleReceiveVectorDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spLabSampleReceive_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabSampleReceiveVector, bool>> RequiredByField = new Dictionary<string, Func<LabSampleReceiveVector, bool>>();
            public static Dictionary<string, Func<LabSampleReceiveVector, bool>> RequiredByProperty = new Dictionary<string, Func<LabSampleReceiveVector, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strVectorID, 50);
                Sizes.Add(_str_strVectorType, 2000);
                Sizes.Add(_str_strVectorSpecies, 2000);
                Sizes.Add(_str_SampleFilter, 2147483647);
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, null, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
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
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((LabSampleReceiveVector)c).MarkToDelete() && ObjectAccessor.PostInterface<LabSampleReceiveVector>().Post(manager, (LabSampleReceiveVector)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabSampleReceiveVector>().Post(manager, (LabSampleReceiveVector)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
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
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabSampleReceiveVector>().Post(manager, (LabSampleReceiveVector)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
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
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class LabSampleReceiveDiagnosis : 
        EditableObject<LabSampleReceiveDiagnosis>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64 idfCase { get; set; }
        #if MONO
        protected Int64 idfCase_Original { get { return idfCase; } }
        protected Int64 idfCase_Previous { get { return idfCase; } }
        #else
        protected Int64 idfCase_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64 idfCase_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfCase).PreviousValue; } }
        #endif
                
        [MapField(_str_idfsDiagnosis), NonUpdatable, PrimaryKey]
        public abstract Int64? idfsDiagnosis { get; set; }
                
        [LocalizedDisplayName(_str_idfsSpeciesType)]
        [MapField(_str_idfsSpeciesType)]
        public abstract Int64? idfsSpeciesType { get; set; }
        #if MONO
        protected Int64? idfsSpeciesType_Original { get { return idfsSpeciesType; } }
        protected Int64? idfsSpeciesType_Previous { get { return idfsSpeciesType; } }
        #else
        protected Int64? idfsSpeciesType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).OriginalValue; } }
        protected Int64? idfsSpeciesType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_name)]
        [MapField(_str_name)]
        public abstract String name { get; set; }
        #if MONO
        protected String name_Original { get { return name; } }
        protected String name_Previous { get { return name; } }
        #else
        protected String name_Original { get { return ((EditableValue<String>)((dynamic)this)._name).OriginalValue; } }
        protected String name_Previous { get { return ((EditableValue<String>)((dynamic)this)._name).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<LabSampleReceiveDiagnosis, object> _get_func;
            internal Action<LabSampleReceiveDiagnosis, string> _set_func;
            internal Action<LabSampleReceiveDiagnosis, LabSampleReceiveDiagnosis, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_idfsSpeciesType = "idfsSpeciesType";
        internal const string _str_name = "name";
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
              _name = _str_idfsSpeciesType, _type = "Int64?",
              _get_func = o => o.idfsSpeciesType,
              _set_func = (o, val) => { o.idfsSpeciesType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_idfsSpeciesType, c)) 
                  m.Add(_str_idfsSpeciesType, o.ObjectIdent + _str_idfsSpeciesType, "Int64?", o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(), o.IsReadOnly(_str_idfsSpeciesType), o.IsInvisible(_str_idfsSpeciesType), o.IsRequired(_str_idfsSpeciesType)); }
              }, 
        
            new field_info {
              _name = _str_name, _type = "String",
              _get_func = o => o.name,
              _set_func = (o, val) => { o.name = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.name != c.name || o.IsRIRPropChanged(_str_name, c)) 
                  m.Add(_str_name, o.ObjectIdent + _str_name, "String", o.name == null ? "" : o.name.ToString(), o.IsReadOnly(_str_name), o.IsInvisible(_str_name), o.IsRequired(_str_name)); }
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
            LabSampleReceiveDiagnosis obj = (LabSampleReceiveDiagnosis)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LabSampleReceiveDiagnosis";

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
            var ret = base.Clone() as LabSampleReceiveDiagnosis;
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
            var ret = base.Clone() as LabSampleReceiveDiagnosis;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public LabSampleReceiveDiagnosis CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabSampleReceiveDiagnosis;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsDiagnosis; } }
        public string KeyName { get { return "idfsDiagnosis"; } }
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
        
            base.RejectChanges();
        
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

      private bool IsRIRPropChanged(string fld, LabSampleReceiveDiagnosis c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabSampleReceiveDiagnosis()
        {
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabSampleReceiveDiagnosis_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabSampleReceiveDiagnosis_PropertyChanged);
        }
        private void LabSampleReceiveDiagnosis_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabSampleReceiveDiagnosis).Changed(e.PropertyName);
            
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
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            LabSampleReceiveDiagnosis obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabSampleReceiveDiagnosis obj = this;
            
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

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
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


        public Dictionary<string, Func<LabSampleReceiveDiagnosis, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabSampleReceiveDiagnosis, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabSampleReceiveDiagnosis, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabSampleReceiveDiagnosis, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabSampleReceiveDiagnosis, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<LabSampleReceiveDiagnosis, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LabSampleReceiveDiagnosis()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
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
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<LabSampleReceiveDiagnosis>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(LabSampleReceiveDiagnosis obj);
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
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual LabSampleReceiveDiagnosis SelectByKey(DbManagerProxy manager
                , Int64? CaseID
                )
            {
                return _SelectByKey(manager
                    , CaseID
                    , null, null
                    );
            }
            
      
            private LabSampleReceiveDiagnosis _SelectByKey(DbManagerProxy manager
                , Int64? CaseID
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabSampleReceiveDiagnosis obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LabSampleReceiveDiagnosis obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabSampleReceiveDiagnosis _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabSampleReceiveDiagnosis obj = LabSampleReceiveDiagnosis.CreateInstance();
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

            
            public LabSampleReceiveDiagnosis CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public LabSampleReceiveDiagnosis CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(LabSampleReceiveDiagnosis obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabSampleReceiveDiagnosis obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, LabSampleReceiveDiagnosis obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as LabSampleReceiveDiagnosis, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabSampleReceiveDiagnosis obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(LabSampleReceiveDiagnosis obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LabSampleReceiveDiagnosis obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabSampleReceiveDiagnosis) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabSampleReceiveDiagnosis) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabSampleReceiveDiagnosisDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spLabSampleReceive_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabSampleReceiveDiagnosis, bool>> RequiredByField = new Dictionary<string, Func<LabSampleReceiveDiagnosis, bool>>();
            public static Dictionary<string, Func<LabSampleReceiveDiagnosis, bool>> RequiredByProperty = new Dictionary<string, Func<LabSampleReceiveDiagnosis, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_name, 2000);
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, null, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
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
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((LabSampleReceiveDiagnosis)c).MarkToDelete() && ObjectAccessor.PostInterface<LabSampleReceiveDiagnosis>().Post(manager, (LabSampleReceiveDiagnosis)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabSampleReceiveDiagnosis>().Post(manager, (LabSampleReceiveDiagnosis)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
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
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabSampleReceiveDiagnosis>().Post(manager, (LabSampleReceiveDiagnosis)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
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
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	