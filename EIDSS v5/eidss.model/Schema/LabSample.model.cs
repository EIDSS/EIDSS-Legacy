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
    public abstract partial class LabSample : 
        EditableObject<LabSample>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfContainer), NonUpdatable, PrimaryKey]
        public abstract Int64 idfContainer { get; set; }
                
        [LocalizedDisplayName(_str_idfsContainerStatus)]
        [MapField(_str_idfsContainerStatus)]
        public abstract Int64? idfsContainerStatus { get; set; }
        #if MONO
        protected Int64? idfsContainerStatus_Original { get { return idfsContainerStatus; } }
        protected Int64? idfsContainerStatus_Previous { get { return idfsContainerStatus; } }
        #else
        protected Int64? idfsContainerStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsContainerStatus).OriginalValue; } }
        protected Int64? idfsContainerStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsContainerStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datCreationDate)]
        [MapField(_str_datCreationDate)]
        public abstract DateTime? datCreationDate { get; set; }
        #if MONO
        protected DateTime? datCreationDate_Original { get { return datCreationDate; } }
        protected DateTime? datCreationDate_Previous { get { return datCreationDate; } }
        #else
        protected DateTime? datCreationDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCreationDate).OriginalValue; } }
        protected DateTime? datCreationDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCreationDate).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_SpecimenType)]
        [MapField(_str_SpecimenType)]
        public abstract String SpecimenType { get; set; }
        #if MONO
        protected String SpecimenType_Original { get { return SpecimenType; } }
        protected String SpecimenType_Previous { get { return SpecimenType; } }
        #else
        protected String SpecimenType_Original { get { return ((EditableValue<String>)((dynamic)this)._specimenType).OriginalValue; } }
        protected String SpecimenType_Previous { get { return ((EditableValue<String>)((dynamic)this)._specimenType).PreviousValue; } }
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
                
        [LocalizedDisplayName("strPatientInfo")]
        [MapField(_str_HumanName)]
        public abstract String HumanName { get; set; }
        #if MONO
        protected String HumanName_Original { get { return HumanName; } }
        protected String HumanName_Previous { get { return HumanName; } }
        #else
        protected String HumanName_Original { get { return ((EditableValue<String>)((dynamic)this)._humanName).OriginalValue; } }
        protected String HumanName_Previous { get { return ((EditableValue<String>)((dynamic)this)._humanName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_DiagnosisName)]
        [MapField(_str_DiagnosisName)]
        public abstract String DiagnosisName { get; set; }
        #if MONO
        protected String DiagnosisName_Original { get { return DiagnosisName; } }
        protected String DiagnosisName_Previous { get { return DiagnosisName; } }
        #else
        protected String DiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).OriginalValue; } }
        protected String DiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsShowDiagnosis)]
        [MapField(_str_idfsShowDiagnosis)]
        public abstract Int64? idfsShowDiagnosis { get; set; }
        #if MONO
        protected Int64? idfsShowDiagnosis_Original { get { return idfsShowDiagnosis; } }
        protected Int64? idfsShowDiagnosis_Previous { get { return idfsShowDiagnosis; } }
        #else
        protected Int64? idfsShowDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsShowDiagnosis).OriginalValue; } }
        protected Int64? idfsShowDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsShowDiagnosis).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfFieldCollectedByOffice)]
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
                
        [LocalizedDisplayName(_str_idfFieldCollectedByPerson)]
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
                
        [LocalizedDisplayName("strNotes")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        #if MONO
        protected String strNote_Original { get { return strNote; } }
        protected String strNote_Previous { get { return strNote; } }
        #else
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfParentContainer)]
        [MapField(_str_idfParentContainer)]
        public abstract Int64? idfParentContainer { get; set; }
        #if MONO
        protected Int64? idfParentContainer_Original { get { return idfParentContainer; } }
        protected Int64? idfParentContainer_Previous { get { return idfParentContainer; } }
        #else
        protected Int64? idfParentContainer_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParentContainer).OriginalValue; } }
        protected Int64? idfParentContainer_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParentContainer).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strParentBarcode)]
        [MapField(_str_strParentBarcode)]
        public abstract String strParentBarcode { get; set; }
        #if MONO
        protected String strParentBarcode_Original { get { return strParentBarcode; } }
        protected String strParentBarcode_Previous { get { return strParentBarcode; } }
        #else
        protected String strParentBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strParentBarcode).OriginalValue; } }
        protected String strParentBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strParentBarcode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strCaseType")]
        [MapField(_str_CaseType)]
        public abstract String CaseType { get; set; }
        #if MONO
        protected String CaseType_Original { get { return CaseType; } }
        protected String CaseType_Previous { get { return CaseType; } }
        #else
        protected String CaseType_Original { get { return ((EditableValue<String>)((dynamic)this)._caseType).OriginalValue; } }
        protected String CaseType_Previous { get { return ((EditableValue<String>)((dynamic)this)._caseType).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsBirdStatus)]
        [MapField(_str_idfsBirdStatus)]
        public abstract Int64? idfsBirdStatus { get; set; }
        #if MONO
        protected Int64? idfsBirdStatus_Original { get { return idfsBirdStatus; } }
        protected Int64? idfsBirdStatus_Previous { get { return idfsBirdStatus; } }
        #else
        protected Int64? idfsBirdStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBirdStatus).OriginalValue; } }
        protected Int64? idfsBirdStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBirdStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int32 intHACode { get; set; }
        #if MONO
        protected Int32 intHACode_Original { get { return intHACode; } }
        protected Int32 intHACode_Previous { get { return intHACode; } }
        #else
        protected Int32 intHACode_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32 intHACode_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intHACode).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<LabSample, object> _get_func;
            internal Action<LabSample, string> _set_func;
            internal Action<LabSample, LabSample, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfContainer = "idfContainer";
        internal const string _str_idfsContainerStatus = "idfsContainerStatus";
        internal const string _str_datCreationDate = "datCreationDate";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_strMonitoringSessionID = "strMonitoringSessionID";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_SpecimenType = "SpecimenType";
        internal const string _str_SpeciesName = "SpeciesName";
        internal const string _str_strAnimalCode = "strAnimalCode";
        internal const string _str_HumanName = "HumanName";
        internal const string _str_DiagnosisName = "DiagnosisName";
        internal const string _str_idfsShowDiagnosis = "idfsShowDiagnosis";
        internal const string _str_idfInDepartment = "idfInDepartment";
        internal const string _str_idfSubdivision = "idfSubdivision";
        internal const string _str_idfFieldCollectedByOffice = "idfFieldCollectedByOffice";
        internal const string _str_strFieldCollectedByOffice = "strFieldCollectedByOffice";
        internal const string _str_idfFieldCollectedByPerson = "idfFieldCollectedByPerson";
        internal const string _str_strFieldCollectedByPerson = "strFieldCollectedByPerson";
        internal const string _str_strNote = "strNote";
        internal const string _str_idfParentContainer = "idfParentContainer";
        internal const string _str_strParentBarcode = "strParentBarcode";
        internal const string _str_CaseType = "CaseType";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_idfsBirdStatus = "idfsBirdStatus";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_strFreezer = "strFreezer";
        internal const string _str_strCaseInfo = "strCaseInfo";
        internal const string _str_Department = "Department";
        internal const string _str_Freezer = "Freezer";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfContainer, _type = "Int64",
              _get_func = o => o.idfContainer,
              _set_func = (o, val) => { o.idfContainer = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfContainer != c.idfContainer || o.IsRIRPropChanged(_str_idfContainer, c)) 
                  m.Add(_str_idfContainer, o.ObjectIdent + _str_idfContainer, "Int64", o.idfContainer == null ? "" : o.idfContainer.ToString(), o.IsReadOnly(_str_idfContainer), o.IsInvisible(_str_idfContainer), o.IsRequired(_str_idfContainer)); }
              }, 
        
            new field_info {
              _name = _str_idfsContainerStatus, _type = "Int64?",
              _get_func = o => o.idfsContainerStatus,
              _set_func = (o, val) => { o.idfsContainerStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsContainerStatus != c.idfsContainerStatus || o.IsRIRPropChanged(_str_idfsContainerStatus, c)) 
                  m.Add(_str_idfsContainerStatus, o.ObjectIdent + _str_idfsContainerStatus, "Int64?", o.idfsContainerStatus == null ? "" : o.idfsContainerStatus.ToString(), o.IsReadOnly(_str_idfsContainerStatus), o.IsInvisible(_str_idfsContainerStatus), o.IsRequired(_str_idfsContainerStatus)); }
              }, 
        
            new field_info {
              _name = _str_datCreationDate, _type = "DateTime?",
              _get_func = o => o.datCreationDate,
              _set_func = (o, val) => { o.datCreationDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datCreationDate != c.datCreationDate || o.IsRIRPropChanged(_str_datCreationDate, c)) 
                  m.Add(_str_datCreationDate, o.ObjectIdent + _str_datCreationDate, "DateTime?", o.datCreationDate == null ? "" : o.datCreationDate.ToString(), o.IsReadOnly(_str_datCreationDate), o.IsInvisible(_str_datCreationDate), o.IsRequired(_str_datCreationDate)); }
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
              _name = _str_strCaseID, _type = "String",
              _get_func = o => o.strCaseID,
              _set_func = (o, val) => { o.strCaseID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCaseID != c.strCaseID || o.IsRIRPropChanged(_str_strCaseID, c)) 
                  m.Add(_str_strCaseID, o.ObjectIdent + _str_strCaseID, "String", o.strCaseID == null ? "" : o.strCaseID.ToString(), o.IsReadOnly(_str_strCaseID), o.IsInvisible(_str_strCaseID), o.IsRequired(_str_strCaseID)); }
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
              _name = _str_idfVectorSurveillanceSession, _type = "Int64?",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { o.idfVectorSurveillanceSession = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, "Int64?", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); }
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
              _name = _str_SpecimenType, _type = "String",
              _get_func = o => o.SpecimenType,
              _set_func = (o, val) => { o.SpecimenType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.SpecimenType != c.SpecimenType || o.IsRIRPropChanged(_str_SpecimenType, c)) 
                  m.Add(_str_SpecimenType, o.ObjectIdent + _str_SpecimenType, "String", o.SpecimenType == null ? "" : o.SpecimenType.ToString(), o.IsReadOnly(_str_SpecimenType), o.IsInvisible(_str_SpecimenType), o.IsRequired(_str_SpecimenType)); }
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
              _name = _str_strAnimalCode, _type = "String",
              _get_func = o => o.strAnimalCode,
              _set_func = (o, val) => { o.strAnimalCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strAnimalCode != c.strAnimalCode || o.IsRIRPropChanged(_str_strAnimalCode, c)) 
                  m.Add(_str_strAnimalCode, o.ObjectIdent + _str_strAnimalCode, "String", o.strAnimalCode == null ? "" : o.strAnimalCode.ToString(), o.IsReadOnly(_str_strAnimalCode), o.IsInvisible(_str_strAnimalCode), o.IsRequired(_str_strAnimalCode)); }
              }, 
        
            new field_info {
              _name = _str_HumanName, _type = "String",
              _get_func = o => o.HumanName,
              _set_func = (o, val) => { o.HumanName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.HumanName != c.HumanName || o.IsRIRPropChanged(_str_HumanName, c)) 
                  m.Add(_str_HumanName, o.ObjectIdent + _str_HumanName, "String", o.HumanName == null ? "" : o.HumanName.ToString(), o.IsReadOnly(_str_HumanName), o.IsInvisible(_str_HumanName), o.IsRequired(_str_HumanName)); }
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
              _name = _str_idfsShowDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsShowDiagnosis,
              _set_func = (o, val) => { o.idfsShowDiagnosis = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsShowDiagnosis != c.idfsShowDiagnosis || o.IsRIRPropChanged(_str_idfsShowDiagnosis, c)) 
                  m.Add(_str_idfsShowDiagnosis, o.ObjectIdent + _str_idfsShowDiagnosis, "Int64?", o.idfsShowDiagnosis == null ? "" : o.idfsShowDiagnosis.ToString(), o.IsReadOnly(_str_idfsShowDiagnosis), o.IsInvisible(_str_idfsShowDiagnosis), o.IsRequired(_str_idfsShowDiagnosis)); }
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
              _name = _str_idfSubdivision, _type = "Int64?",
              _get_func = o => o.idfSubdivision,
              _set_func = (o, val) => { o.idfSubdivision = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSubdivision != c.idfSubdivision || o.IsRIRPropChanged(_str_idfSubdivision, c)) 
                  m.Add(_str_idfSubdivision, o.ObjectIdent + _str_idfSubdivision, "Int64?", o.idfSubdivision == null ? "" : o.idfSubdivision.ToString(), o.IsReadOnly(_str_idfSubdivision), o.IsInvisible(_str_idfSubdivision), o.IsRequired(_str_idfSubdivision)); }
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
              _name = _str_strNote, _type = "String",
              _get_func = o => o.strNote,
              _set_func = (o, val) => { o.strNote = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNote != c.strNote || o.IsRIRPropChanged(_str_strNote, c)) 
                  m.Add(_str_strNote, o.ObjectIdent + _str_strNote, "String", o.strNote == null ? "" : o.strNote.ToString(), o.IsReadOnly(_str_strNote), o.IsInvisible(_str_strNote), o.IsRequired(_str_strNote)); }
              }, 
        
            new field_info {
              _name = _str_idfParentContainer, _type = "Int64?",
              _get_func = o => o.idfParentContainer,
              _set_func = (o, val) => { o.idfParentContainer = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfParentContainer != c.idfParentContainer || o.IsRIRPropChanged(_str_idfParentContainer, c)) 
                  m.Add(_str_idfParentContainer, o.ObjectIdent + _str_idfParentContainer, "Int64?", o.idfParentContainer == null ? "" : o.idfParentContainer.ToString(), o.IsReadOnly(_str_idfParentContainer), o.IsInvisible(_str_idfParentContainer), o.IsRequired(_str_idfParentContainer)); }
              }, 
        
            new field_info {
              _name = _str_strParentBarcode, _type = "String",
              _get_func = o => o.strParentBarcode,
              _set_func = (o, val) => { o.strParentBarcode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strParentBarcode != c.strParentBarcode || o.IsRIRPropChanged(_str_strParentBarcode, c)) 
                  m.Add(_str_strParentBarcode, o.ObjectIdent + _str_strParentBarcode, "String", o.strParentBarcode == null ? "" : o.strParentBarcode.ToString(), o.IsReadOnly(_str_strParentBarcode), o.IsInvisible(_str_strParentBarcode), o.IsRequired(_str_strParentBarcode)); }
              }, 
        
            new field_info {
              _name = _str_CaseType, _type = "String",
              _get_func = o => o.CaseType,
              _set_func = (o, val) => { o.CaseType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.CaseType != c.CaseType || o.IsRIRPropChanged(_str_CaseType, c)) 
                  m.Add(_str_CaseType, o.ObjectIdent + _str_CaseType, "String", o.CaseType == null ? "" : o.CaseType.ToString(), o.IsReadOnly(_str_CaseType), o.IsInvisible(_str_CaseType), o.IsRequired(_str_CaseType)); }
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
              _name = _str_idfsBirdStatus, _type = "Int64?",
              _get_func = o => o.idfsBirdStatus,
              _set_func = (o, val) => { o.idfsBirdStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsBirdStatus != c.idfsBirdStatus || o.IsRIRPropChanged(_str_idfsBirdStatus, c)) 
                  m.Add(_str_idfsBirdStatus, o.ObjectIdent + _str_idfsBirdStatus, "Int64?", o.idfsBirdStatus == null ? "" : o.idfsBirdStatus.ToString(), o.IsReadOnly(_str_idfsBirdStatus), o.IsInvisible(_str_idfsBirdStatus), o.IsRequired(_str_idfsBirdStatus)); }
              }, 
        
            new field_info {
              _name = _str_intHACode, _type = "Int32",
              _get_func = o => o.intHACode,
              _set_func = (o, val) => { o.intHACode = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intHACode != c.intHACode || o.IsRIRPropChanged(_str_intHACode, c)) 
                  m.Add(_str_intHACode, o.ObjectIdent + _str_intHACode, "Int32", o.intHACode == null ? "" : o.intHACode.ToString(), o.IsReadOnly(_str_intHACode), o.IsInvisible(_str_intHACode), o.IsRequired(_str_intHACode)); }
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
              _name = _str_strCaseInfo, _type = "string",
              _get_func = o => o.strCaseInfo,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strCaseInfo != c.strCaseInfo || o.IsRIRPropChanged(_str_strCaseInfo, c)) 
                  m.Add(_str_strCaseInfo, o.ObjectIdent + _str_strCaseInfo, "string", o.strCaseInfo == null ? "" : o.strCaseInfo.ToString(), o.IsReadOnly(_str_strCaseInfo), o.IsInvisible(_str_strCaseInfo), o.IsRequired(_str_strCaseInfo));
                 }
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
            LabSample obj = (LabSample)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
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
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Department:
                    return new BvSelectList(DepartmentLookup, eidss.model.Schema.DepartmentLookup._str_idfDepartment, null, Department, _str_idfInDepartment);
            
                case _str_Freezer:
                    return new BvSelectList(FreezerLookup, eidss.model.Schema.FreezerTreeLookup._str_ID, null, Freezer, _str_idfSubdivision);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strFreezer)]
        public string strFreezer
        {
            get { return new Func<LabSample, string>(c => c.Freezer == null ? "" : c.Freezer.Path)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strCaseInfo)]
        public string strCaseInfo
        {
            get { return new Func<LabSample, string>(c => c.strCaseID + ", " + c.DiagnosisName)(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LabSample";

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
            var ret = base.Clone() as LabSample;
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
            var ret = base.Clone() as LabSample;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public LabSample CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabSample;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfContainer; } }
        public string KeyName { get { return "idfContainer"; } }
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
        
            var _prev_idfInDepartment_Department = idfInDepartment;
            var _prev_idfSubdivision_Freezer = idfSubdivision;
            base.RejectChanges();
        
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

      private bool IsRIRPropChanged(string fld, LabSample c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabSample()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabSample_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabSample_PropertyChanged);
        }
        private void LabSample_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabSample).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Freezer)
                OnPropertyChanged(_str_strFreezer);
                  
            if (e.PropertyName == _str_idfSubdivision)
                OnPropertyChanged(_str_strFreezer);
                  
            if (e.PropertyName == _str_strCaseID)
                OnPropertyChanged(_str_strCaseInfo);
                  
            if (e.PropertyName == _str_DiagnosisName)
                OnPropertyChanged(_str_strCaseInfo);
                  
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
            LabSample obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabSample obj = this;
            
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
            get { return FormSize.Small; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private static string[] readonly_names1 = "strNote".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "Department,idfInDepartment".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "strFieldCollectedByOffice,strFieldCollectedByPerson".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "strFreezer,Freezer,idfSubdivision".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LabSample, bool>(c => false)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LabSample, bool>(c => string.IsNullOrEmpty(c.strBarcode))(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LabSample, bool>(c => true)(this);
            
            if (readonly_names4.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LabSample, bool>(c => true)(this);
            
            return ReadOnly || new Func<LabSample, bool>(c => true)(this);
                
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


        public Dictionary<string, Func<LabSample, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabSample, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabSample, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabSample, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabSample, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<LabSample, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LabSample()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("DepartmentLookup", this);
                
                LookupManager.RemoveObject("FreezerTreeLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
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
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<LabSample>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(LabSample obj);
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
            private DepartmentLookup.Accessor DepartmentAccessor { get { return eidss.model.Schema.DepartmentLookup.Accessor.Instance(m_CS); } }
            private FreezerTreeLookup.Accessor FreezerAccessor { get { return eidss.model.Schema.FreezerTreeLookup.Accessor.Instance(m_CS); } }
            

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

            
            public virtual LabSample SelectByKey(DbManagerProxy manager
                , Int64? idfContainer
                )
            {
                return _SelectByKey(manager
                    , idfContainer
                    , null, null
                    );
            }
            
      
            private LabSample _SelectByKey(DbManagerProxy manager
                , Int64? idfContainer
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<LabSample> objs = new List<LabSample>();
                sets[0] = new MapResultSet(typeof(LabSample), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spLabSample_SelectDetail"
                            , manager.Parameter("@idfContainer", idfContainer)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    LabSample obj = objs[0];
                    obj.m_CS = m_CS;
                    
                    if (loading != null)
                        loading(obj);
                    _SetupLoad(manager, obj);
                    
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabSample obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LabSample obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabSample _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabSample obj = LabSample.CreateInstance();
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

            
            public LabSample CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public LabSample CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(LabSample obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabSample obj)
            {
                
            }
    
            public void LoadLookup_Department(DbManagerProxy manager, LabSample obj)
            {
                
                obj.DepartmentLookup.Clear();
                
                obj.DepartmentLookup.Add(DepartmentAccessor.CreateNewT(manager, null));
                
                obj.DepartmentLookup.AddRange(DepartmentAccessor.SelectLookupList(manager
                    
                    , new Func<LabSample, long>(c => eidss.model.Core.EidssSiteContext.Instance.OrganizationID)(obj)
                            
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
            
            public void LoadLookup_Freezer(DbManagerProxy manager, LabSample obj)
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
            

            private void _LoadLookups(DbManagerProxy manager, LabSample obj)
            {
                
                LoadLookup_Department(manager, obj);
                
                LoadLookup_Freezer(manager, obj);
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spLabSample_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] LabSample obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] LabSample obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    LabSample bo = obj as LabSample;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("Sample", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("Sample", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("Sample", "Update");
                    }
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        long mainObject = bo.idfContainer;
                        
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
                    bSuccess = _PostNonTransaction(manager, obj as LabSample, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, LabSample obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(LabSample obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, LabSample obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as LabSample, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabSample obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(LabSample obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LabSample obj)
    {
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName))
      {
      
            obj
              .AddHiddenPersonalData("HumanName", c=>true);
            
      }
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabSample) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabSample) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabSampleDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private LabSample m_obj;
            internal Permissions(LabSample obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spLabSample_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spLabSample_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabSample, bool>> RequiredByField = new Dictionary<string, Func<LabSample, bool>>();
            public static Dictionary<string, Func<LabSample, bool>> RequiredByProperty = new Dictionary<string, Func<LabSample, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strCaseID, 200);
                Sizes.Add(_str_strMonitoringSessionID, 50);
                Sizes.Add(_str_SpecimenType, 2000);
                Sizes.Add(_str_SpeciesName, 4000);
                Sizes.Add(_str_strAnimalCode, 200);
                Sizes.Add(_str_HumanName, 602);
                Sizes.Add(_str_DiagnosisName, 2000);
                Sizes.Add(_str_strFieldCollectedByOffice, 2000);
                Sizes.Add(_str_strFieldCollectedByPerson, 602);
                Sizes.Add(_str_strNote, 500);
                Sizes.Add(_str_strParentBarcode, 200);
                Sizes.Add(_str_CaseType, 2000);
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabSample>().Post(manager, (LabSample)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabSample>().Post(manager, (LabSample)c), c),
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
	