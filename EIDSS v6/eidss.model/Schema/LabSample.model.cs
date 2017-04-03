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
        
        [MapField(_str_idfMaterial), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMaterial { get; set; }
                
        [LocalizedDisplayName(_str_idfsSampleStatus)]
        [MapField(_str_idfsSampleStatus)]
        public abstract Int64? idfsSampleStatus { get; set; }
        protected Int64? idfsSampleStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleStatus).OriginalValue; } }
        protected Int64? idfsSampleStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datAccession)]
        [MapField(_str_datAccession)]
        public abstract DateTime? datAccession { get; set; }
        protected DateTime? datAccession_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).OriginalValue; } }
        protected DateTime? datAccession_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).PreviousValue; } }
                
        [LocalizedDisplayName("strLabBarcode")]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64? idfCase { get; set; }
        protected Int64? idfCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64? idfCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMonitoringSession)]
        [MapField(_str_idfMonitoringSession)]
        public abstract Int64? idfMonitoringSession { get; set; }
        protected Int64? idfMonitoringSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).OriginalValue; } }
        protected Int64? idfMonitoringSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCaseID)]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strMonitoringSessionID)]
        [MapField(_str_strMonitoringSessionID)]
        public abstract String strMonitoringSessionID { get; set; }
        protected String strMonitoringSessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strMonitoringSessionID).OriginalValue; } }
        protected String strMonitoringSessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strMonitoringSessionID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfVectorSurveillanceSession)]
        [MapField(_str_idfVectorSurveillanceSession)]
        public abstract Int64? idfVectorSurveillanceSession { get; set; }
        protected Int64? idfVectorSurveillanceSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).OriginalValue; } }
        protected Int64? idfVectorSurveillanceSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCaseType)]
        [MapField(_str_idfsCaseType)]
        public abstract Int64? idfsCaseType { get; set; }
        protected Int64? idfsCaseType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).OriginalValue; } }
        protected Int64? idfsCaseType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSampleName)]
        [MapField(_str_strSampleName)]
        public abstract String strSampleName { get; set; }
        protected String strSampleName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).OriginalValue; } }
        protected String strSampleName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_SpeciesName)]
        [MapField(_str_SpeciesName)]
        public abstract String SpeciesName { get; set; }
        protected String SpeciesName_Original { get { return ((EditableValue<String>)((dynamic)this)._speciesName).OriginalValue; } }
        protected String SpeciesName_Previous { get { return ((EditableValue<String>)((dynamic)this)._speciesName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strAnimalCode)]
        [MapField(_str_strAnimalCode)]
        public abstract String strAnimalCode { get; set; }
        protected String strAnimalCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strAnimalCode).OriginalValue; } }
        protected String strAnimalCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAnimalCode).PreviousValue; } }
                
        [LocalizedDisplayName("strPatientInfo")]
        [MapField(_str_HumanName)]
        public abstract String HumanName { get; set; }
        protected String HumanName_Original { get { return ((EditableValue<String>)((dynamic)this)._humanName).OriginalValue; } }
        protected String HumanName_Previous { get { return ((EditableValue<String>)((dynamic)this)._humanName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DiagnosisName)]
        [MapField(_str_DiagnosisName)]
        public abstract String DiagnosisName { get; set; }
        protected String DiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).OriginalValue; } }
        protected String DiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_SessionDiagnosisName)]
        [MapField(_str_SessionDiagnosisName)]
        public abstract String SessionDiagnosisName { get; set; }
        protected String SessionDiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._sessionDiagnosisName).OriginalValue; } }
        protected String SessionDiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._sessionDiagnosisName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsShowDiagnosis)]
        [MapField(_str_idfsShowDiagnosis)]
        public abstract Int64? idfsShowDiagnosis { get; set; }
        protected Int64? idfsShowDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsShowDiagnosis).OriginalValue; } }
        protected Int64? idfsShowDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsShowDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName("DepartmentName")]
        [MapField(_str_idfInDepartment)]
        public abstract Int64? idfInDepartment { get; set; }
        protected Int64? idfInDepartment_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInDepartment).OriginalValue; } }
        protected Int64? idfInDepartment_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInDepartment).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfSubdivision)]
        [MapField(_str_idfSubdivision)]
        public abstract Int64? idfSubdivision { get; set; }
        protected Int64? idfSubdivision_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSubdivision).OriginalValue; } }
        protected Int64? idfSubdivision_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSubdivision).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfFieldCollectedByOffice)]
        [MapField(_str_idfFieldCollectedByOffice)]
        public abstract Int64? idfFieldCollectedByOffice { get; set; }
        protected Int64? idfFieldCollectedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).OriginalValue; } }
        protected Int64? idfFieldCollectedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFieldCollectedByOffice)]
        [MapField(_str_strFieldCollectedByOffice)]
        public abstract String strFieldCollectedByOffice { get; set; }
        protected String strFieldCollectedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByOffice).OriginalValue; } }
        protected String strFieldCollectedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfFieldCollectedByPerson)]
        [MapField(_str_idfFieldCollectedByPerson)]
        public abstract Int64? idfFieldCollectedByPerson { get; set; }
        protected Int64? idfFieldCollectedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByPerson).OriginalValue; } }
        protected Int64? idfFieldCollectedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFieldCollectedByPerson)]
        [MapField(_str_strFieldCollectedByPerson)]
        public abstract String strFieldCollectedByPerson { get; set; }
        protected String strFieldCollectedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByPerson).OriginalValue; } }
        protected String strFieldCollectedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName("strNotes")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfParentMaterial)]
        [MapField(_str_idfParentMaterial)]
        public abstract Int64? idfParentMaterial { get; set; }
        protected Int64? idfParentMaterial_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParentMaterial).OriginalValue; } }
        protected Int64? idfParentMaterial_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParentMaterial).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strParentBarcode)]
        [MapField(_str_strParentBarcode)]
        public abstract String strParentBarcode { get; set; }
        protected String strParentBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strParentBarcode).OriginalValue; } }
        protected String strParentBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strParentBarcode).PreviousValue; } }
                
        [LocalizedDisplayName("strCaseType")]
        [MapField(_str_CaseType)]
        public abstract String CaseType { get; set; }
        protected String CaseType_Original { get { return ((EditableValue<String>)((dynamic)this)._caseType).OriginalValue; } }
        protected String CaseType_Previous { get { return ((EditableValue<String>)((dynamic)this)._caseType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFieldCollectionDate)]
        [MapField(_str_datFieldCollectionDate)]
        public abstract DateTime? datFieldCollectionDate { get; set; }
        protected DateTime? datFieldCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).OriginalValue; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsBirdStatus)]
        [MapField(_str_idfsBirdStatus)]
        public abstract Int64? idfsBirdStatus { get; set; }
        protected Int64? idfsBirdStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBirdStatus).OriginalValue; } }
        protected Int64? idfsBirdStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBirdStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int32 intHACode { get; set; }
        protected Int32 intHACode_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32 intHACode_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intHACode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsDestructionMethod)]
        [MapField(_str_idfsDestructionMethod)]
        public abstract Int64? idfsDestructionMethod { get; set; }
        protected Int64? idfsDestructionMethod_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDestructionMethod).OriginalValue; } }
        protected Int64? idfsDestructionMethod_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDestructionMethod).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64 idfsSite { get; set; }
        protected Int64 idfsSite_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64 idfsSite_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCurrentSite)]
        [MapField(_str_idfsCurrentSite)]
        public abstract Int64? idfsCurrentSite { get; set; }
        protected Int64? idfsCurrentSite_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCurrentSite).OriginalValue; } }
        protected Int64? idfsCurrentSite_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCurrentSite).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnSampleTransferred)]
        [MapField(_str_blnSampleTransferred)]
        public abstract Boolean? blnSampleTransferred { get; set; }
        protected Boolean? blnSampleTransferred_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnSampleTransferred).OriginalValue; } }
        protected Boolean? blnSampleTransferred_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnSampleTransferred).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<LabSample, object> _get_func;
            internal Action<LabSample, string> _set_func;
            internal Action<LabSample, LabSample, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_idfsSampleStatus = "idfsSampleStatus";
        internal const string _str_datAccession = "datAccession";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_strMonitoringSessionID = "strMonitoringSessionID";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_strSampleName = "strSampleName";
        internal const string _str_SpeciesName = "SpeciesName";
        internal const string _str_strAnimalCode = "strAnimalCode";
        internal const string _str_HumanName = "HumanName";
        internal const string _str_DiagnosisName = "DiagnosisName";
        internal const string _str_SessionDiagnosisName = "SessionDiagnosisName";
        internal const string _str_idfsShowDiagnosis = "idfsShowDiagnosis";
        internal const string _str_idfInDepartment = "idfInDepartment";
        internal const string _str_idfSubdivision = "idfSubdivision";
        internal const string _str_idfFieldCollectedByOffice = "idfFieldCollectedByOffice";
        internal const string _str_strFieldCollectedByOffice = "strFieldCollectedByOffice";
        internal const string _str_idfFieldCollectedByPerson = "idfFieldCollectedByPerson";
        internal const string _str_strFieldCollectedByPerson = "strFieldCollectedByPerson";
        internal const string _str_strNote = "strNote";
        internal const string _str_idfParentMaterial = "idfParentMaterial";
        internal const string _str_strParentBarcode = "strParentBarcode";
        internal const string _str_CaseType = "CaseType";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_idfsBirdStatus = "idfsBirdStatus";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_idfsDestructionMethod = "idfsDestructionMethod";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_idfsCurrentSite = "idfsCurrentSite";
        internal const string _str_blnSampleTransferred = "blnSampleTransferred";
        internal const string _str_strFreezer = "strFreezer";
        internal const string _str_strCaseInfo = "strCaseInfo";
        internal const string _str_strMonitoringSessionInfo = "strMonitoringSessionInfo";
        internal const string _str_Department = "Department";
        internal const string _str_Freezer = "Freezer";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfMaterial, _formname = _str_idfMaterial, _type = "Int64",
              _get_func = o => o.idfMaterial,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfMaterial != newval) o.idfMaterial = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfMaterial != c.idfMaterial || o.IsRIRPropChanged(_str_idfMaterial, c)) 
                  m.Add(_str_idfMaterial, o.ObjectIdent + _str_idfMaterial, o.ObjectIdent2 + _str_idfMaterial, o.ObjectIdent3 + _str_idfMaterial, "Int64", 
                    o.idfMaterial == null ? "" : o.idfMaterial.ToString(),                  
                  o.IsReadOnly(_str_idfMaterial), o.IsInvisible(_str_idfMaterial), o.IsRequired(_str_idfMaterial)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSampleStatus, _formname = _str_idfsSampleStatus, _type = "Int64?",
              _get_func = o => o.idfsSampleStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSampleStatus != newval) o.idfsSampleStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSampleStatus != c.idfsSampleStatus || o.IsRIRPropChanged(_str_idfsSampleStatus, c)) 
                  m.Add(_str_idfsSampleStatus, o.ObjectIdent + _str_idfsSampleStatus, o.ObjectIdent2 + _str_idfsSampleStatus, o.ObjectIdent3 + _str_idfsSampleStatus, "Int64?", 
                    o.idfsSampleStatus == null ? "" : o.idfsSampleStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsSampleStatus), o.IsInvisible(_str_idfsSampleStatus), o.IsRequired(_str_idfsSampleStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datAccession, _formname = _str_datAccession, _type = "DateTime?",
              _get_func = o => o.datAccession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datAccession != newval) o.datAccession = newval; },
              _compare_func = (o, c, m) => {
                if (o.datAccession != c.datAccession || o.IsRIRPropChanged(_str_datAccession, c)) 
                  m.Add(_str_datAccession, o.ObjectIdent + _str_datAccession, o.ObjectIdent2 + _str_datAccession, o.ObjectIdent3 + _str_datAccession, "DateTime?", 
                    o.datAccession == null ? "" : o.datAccession.ToString(),                  
                  o.IsReadOnly(_str_datAccession), o.IsInvisible(_str_datAccession), o.IsRequired(_str_datAccession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strBarcode, _formname = _str_strBarcode, _type = "String",
              _get_func = o => o.strBarcode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strBarcode != newval) o.strBarcode = newval; },
              _compare_func = (o, c, m) => {
                if (o.strBarcode != c.strBarcode || o.IsRIRPropChanged(_str_strBarcode, c)) 
                  m.Add(_str_strBarcode, o.ObjectIdent + _str_strBarcode, o.ObjectIdent2 + _str_strBarcode, o.ObjectIdent3 + _str_strBarcode, "String", 
                    o.strBarcode == null ? "" : o.strBarcode.ToString(),                  
                  o.IsReadOnly(_str_strBarcode), o.IsInvisible(_str_strBarcode), o.IsRequired(_str_strBarcode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfCase, _formname = _str_idfCase, _type = "Int64?",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfCase != newval) o.idfCase = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, o.ObjectIdent2 + _str_idfCase, o.ObjectIdent3 + _str_idfCase, "Int64?", 
                    o.idfCase == null ? "" : o.idfCase.ToString(),                  
                  o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfMonitoringSession, _formname = _str_idfMonitoringSession, _type = "Int64?",
              _get_func = o => o.idfMonitoringSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfMonitoringSession != newval) o.idfMonitoringSession = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfMonitoringSession != c.idfMonitoringSession || o.IsRIRPropChanged(_str_idfMonitoringSession, c)) 
                  m.Add(_str_idfMonitoringSession, o.ObjectIdent + _str_idfMonitoringSession, o.ObjectIdent2 + _str_idfMonitoringSession, o.ObjectIdent3 + _str_idfMonitoringSession, "Int64?", 
                    o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(),                  
                  o.IsReadOnly(_str_idfMonitoringSession), o.IsInvisible(_str_idfMonitoringSession), o.IsRequired(_str_idfMonitoringSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCaseID, _formname = _str_strCaseID, _type = "String",
              _get_func = o => o.strCaseID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCaseID != newval) o.strCaseID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strCaseID != c.strCaseID || o.IsRIRPropChanged(_str_strCaseID, c)) 
                  m.Add(_str_strCaseID, o.ObjectIdent + _str_strCaseID, o.ObjectIdent2 + _str_strCaseID, o.ObjectIdent3 + _str_strCaseID, "String", 
                    o.strCaseID == null ? "" : o.strCaseID.ToString(),                  
                  o.IsReadOnly(_str_strCaseID), o.IsInvisible(_str_strCaseID), o.IsRequired(_str_strCaseID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strMonitoringSessionID, _formname = _str_strMonitoringSessionID, _type = "String",
              _get_func = o => o.strMonitoringSessionID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strMonitoringSessionID != newval) o.strMonitoringSessionID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strMonitoringSessionID != c.strMonitoringSessionID || o.IsRIRPropChanged(_str_strMonitoringSessionID, c)) 
                  m.Add(_str_strMonitoringSessionID, o.ObjectIdent + _str_strMonitoringSessionID, o.ObjectIdent2 + _str_strMonitoringSessionID, o.ObjectIdent3 + _str_strMonitoringSessionID, "String", 
                    o.strMonitoringSessionID == null ? "" : o.strMonitoringSessionID.ToString(),                  
                  o.IsReadOnly(_str_strMonitoringSessionID), o.IsInvisible(_str_strMonitoringSessionID), o.IsRequired(_str_strMonitoringSessionID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _formname = _str_idfVectorSurveillanceSession, _type = "Int64?",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfVectorSurveillanceSession != newval) o.idfVectorSurveillanceSession = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, o.ObjectIdent2 + _str_idfVectorSurveillanceSession, o.ObjectIdent3 + _str_idfVectorSurveillanceSession, "Int64?", 
                    o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(),                  
                  o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCaseType, _formname = _str_idfsCaseType, _type = "Int64?",
              _get_func = o => o.idfsCaseType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsCaseType != newval) o.idfsCaseType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_idfsCaseType, c)) 
                  m.Add(_str_idfsCaseType, o.ObjectIdent + _str_idfsCaseType, o.ObjectIdent2 + _str_idfsCaseType, o.ObjectIdent3 + _str_idfsCaseType, "Int64?", 
                    o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseType), o.IsInvisible(_str_idfsCaseType), o.IsRequired(_str_idfsCaseType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSampleName, _formname = _str_strSampleName, _type = "String",
              _get_func = o => o.strSampleName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSampleName != newval) o.strSampleName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSampleName != c.strSampleName || o.IsRIRPropChanged(_str_strSampleName, c)) 
                  m.Add(_str_strSampleName, o.ObjectIdent + _str_strSampleName, o.ObjectIdent2 + _str_strSampleName, o.ObjectIdent3 + _str_strSampleName, "String", 
                    o.strSampleName == null ? "" : o.strSampleName.ToString(),                  
                  o.IsReadOnly(_str_strSampleName), o.IsInvisible(_str_strSampleName), o.IsRequired(_str_strSampleName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_SpeciesName, _formname = _str_SpeciesName, _type = "String",
              _get_func = o => o.SpeciesName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.SpeciesName != newval) o.SpeciesName = newval; },
              _compare_func = (o, c, m) => {
                if (o.SpeciesName != c.SpeciesName || o.IsRIRPropChanged(_str_SpeciesName, c)) 
                  m.Add(_str_SpeciesName, o.ObjectIdent + _str_SpeciesName, o.ObjectIdent2 + _str_SpeciesName, o.ObjectIdent3 + _str_SpeciesName, "String", 
                    o.SpeciesName == null ? "" : o.SpeciesName.ToString(),                  
                  o.IsReadOnly(_str_SpeciesName), o.IsInvisible(_str_SpeciesName), o.IsRequired(_str_SpeciesName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strAnimalCode, _formname = _str_strAnimalCode, _type = "String",
              _get_func = o => o.strAnimalCode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strAnimalCode != newval) o.strAnimalCode = newval; },
              _compare_func = (o, c, m) => {
                if (o.strAnimalCode != c.strAnimalCode || o.IsRIRPropChanged(_str_strAnimalCode, c)) 
                  m.Add(_str_strAnimalCode, o.ObjectIdent + _str_strAnimalCode, o.ObjectIdent2 + _str_strAnimalCode, o.ObjectIdent3 + _str_strAnimalCode, "String", 
                    o.strAnimalCode == null ? "" : o.strAnimalCode.ToString(),                  
                  o.IsReadOnly(_str_strAnimalCode), o.IsInvisible(_str_strAnimalCode), o.IsRequired(_str_strAnimalCode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_HumanName, _formname = _str_HumanName, _type = "String",
              _get_func = o => o.HumanName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.HumanName != newval) o.HumanName = newval; },
              _compare_func = (o, c, m) => {
                if (o.HumanName != c.HumanName || o.IsRIRPropChanged(_str_HumanName, c)) 
                  m.Add(_str_HumanName, o.ObjectIdent + _str_HumanName, o.ObjectIdent2 + _str_HumanName, o.ObjectIdent3 + _str_HumanName, "String", 
                    o.HumanName == null ? "" : o.HumanName.ToString(),                  
                  o.IsReadOnly(_str_HumanName), o.IsInvisible(_str_HumanName), o.IsRequired(_str_HumanName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DiagnosisName, _formname = _str_DiagnosisName, _type = "String",
              _get_func = o => o.DiagnosisName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DiagnosisName != newval) o.DiagnosisName = newval; },
              _compare_func = (o, c, m) => {
                if (o.DiagnosisName != c.DiagnosisName || o.IsRIRPropChanged(_str_DiagnosisName, c)) 
                  m.Add(_str_DiagnosisName, o.ObjectIdent + _str_DiagnosisName, o.ObjectIdent2 + _str_DiagnosisName, o.ObjectIdent3 + _str_DiagnosisName, "String", 
                    o.DiagnosisName == null ? "" : o.DiagnosisName.ToString(),                  
                  o.IsReadOnly(_str_DiagnosisName), o.IsInvisible(_str_DiagnosisName), o.IsRequired(_str_DiagnosisName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_SessionDiagnosisName, _formname = _str_SessionDiagnosisName, _type = "String",
              _get_func = o => o.SessionDiagnosisName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.SessionDiagnosisName != newval) o.SessionDiagnosisName = newval; },
              _compare_func = (o, c, m) => {
                if (o.SessionDiagnosisName != c.SessionDiagnosisName || o.IsRIRPropChanged(_str_SessionDiagnosisName, c)) 
                  m.Add(_str_SessionDiagnosisName, o.ObjectIdent + _str_SessionDiagnosisName, o.ObjectIdent2 + _str_SessionDiagnosisName, o.ObjectIdent3 + _str_SessionDiagnosisName, "String", 
                    o.SessionDiagnosisName == null ? "" : o.SessionDiagnosisName.ToString(),                  
                  o.IsReadOnly(_str_SessionDiagnosisName), o.IsInvisible(_str_SessionDiagnosisName), o.IsRequired(_str_SessionDiagnosisName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsShowDiagnosis, _formname = _str_idfsShowDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsShowDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsShowDiagnosis != newval) o.idfsShowDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsShowDiagnosis != c.idfsShowDiagnosis || o.IsRIRPropChanged(_str_idfsShowDiagnosis, c)) 
                  m.Add(_str_idfsShowDiagnosis, o.ObjectIdent + _str_idfsShowDiagnosis, o.ObjectIdent2 + _str_idfsShowDiagnosis, o.ObjectIdent3 + _str_idfsShowDiagnosis, "Int64?", 
                    o.idfsShowDiagnosis == null ? "" : o.idfsShowDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsShowDiagnosis), o.IsInvisible(_str_idfsShowDiagnosis), o.IsRequired(_str_idfsShowDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfInDepartment, _formname = _str_idfInDepartment, _type = "Int64?",
              _get_func = o => o.idfInDepartment,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfInDepartment != newval) 
                  o.Department = o.DepartmentLookup.FirstOrDefault(c => c.idfDepartment == newval);
                if (o.idfInDepartment != newval) o.idfInDepartment = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfInDepartment != c.idfInDepartment || o.IsRIRPropChanged(_str_idfInDepartment, c)) 
                  m.Add(_str_idfInDepartment, o.ObjectIdent + _str_idfInDepartment, o.ObjectIdent2 + _str_idfInDepartment, o.ObjectIdent3 + _str_idfInDepartment, "Int64?", 
                    o.idfInDepartment == null ? "" : o.idfInDepartment.ToString(),                  
                  o.IsReadOnly(_str_idfInDepartment), o.IsInvisible(_str_idfInDepartment), o.IsRequired(_str_idfInDepartment)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSubdivision, _formname = _str_idfSubdivision, _type = "Int64?",
              _get_func = o => o.idfSubdivision,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfSubdivision != newval) 
                  o.Freezer = o.FreezerLookup.FirstOrDefault(c => c.ID == newval);
                if (o.idfSubdivision != newval) o.idfSubdivision = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfSubdivision != c.idfSubdivision || o.IsRIRPropChanged(_str_idfSubdivision, c)) 
                  m.Add(_str_idfSubdivision, o.ObjectIdent + _str_idfSubdivision, o.ObjectIdent2 + _str_idfSubdivision, o.ObjectIdent3 + _str_idfSubdivision, "Int64?", 
                    o.idfSubdivision == null ? "" : o.idfSubdivision.ToString(),                  
                  o.IsReadOnly(_str_idfSubdivision), o.IsInvisible(_str_idfSubdivision), o.IsRequired(_str_idfSubdivision)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfFieldCollectedByOffice, _formname = _str_idfFieldCollectedByOffice, _type = "Int64?",
              _get_func = o => o.idfFieldCollectedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfFieldCollectedByOffice != newval) o.idfFieldCollectedByOffice = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfFieldCollectedByOffice != c.idfFieldCollectedByOffice || o.IsRIRPropChanged(_str_idfFieldCollectedByOffice, c)) 
                  m.Add(_str_idfFieldCollectedByOffice, o.ObjectIdent + _str_idfFieldCollectedByOffice, o.ObjectIdent2 + _str_idfFieldCollectedByOffice, o.ObjectIdent3 + _str_idfFieldCollectedByOffice, "Int64?", 
                    o.idfFieldCollectedByOffice == null ? "" : o.idfFieldCollectedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfFieldCollectedByOffice), o.IsInvisible(_str_idfFieldCollectedByOffice), o.IsRequired(_str_idfFieldCollectedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFieldCollectedByOffice, _formname = _str_strFieldCollectedByOffice, _type = "String",
              _get_func = o => o.strFieldCollectedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFieldCollectedByOffice != newval) o.strFieldCollectedByOffice = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFieldCollectedByOffice != c.strFieldCollectedByOffice || o.IsRIRPropChanged(_str_strFieldCollectedByOffice, c)) 
                  m.Add(_str_strFieldCollectedByOffice, o.ObjectIdent + _str_strFieldCollectedByOffice, o.ObjectIdent2 + _str_strFieldCollectedByOffice, o.ObjectIdent3 + _str_strFieldCollectedByOffice, "String", 
                    o.strFieldCollectedByOffice == null ? "" : o.strFieldCollectedByOffice.ToString(),                  
                  o.IsReadOnly(_str_strFieldCollectedByOffice), o.IsInvisible(_str_strFieldCollectedByOffice), o.IsRequired(_str_strFieldCollectedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfFieldCollectedByPerson, _formname = _str_idfFieldCollectedByPerson, _type = "Int64?",
              _get_func = o => o.idfFieldCollectedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfFieldCollectedByPerson != newval) o.idfFieldCollectedByPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfFieldCollectedByPerson != c.idfFieldCollectedByPerson || o.IsRIRPropChanged(_str_idfFieldCollectedByPerson, c)) 
                  m.Add(_str_idfFieldCollectedByPerson, o.ObjectIdent + _str_idfFieldCollectedByPerson, o.ObjectIdent2 + _str_idfFieldCollectedByPerson, o.ObjectIdent3 + _str_idfFieldCollectedByPerson, "Int64?", 
                    o.idfFieldCollectedByPerson == null ? "" : o.idfFieldCollectedByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfFieldCollectedByPerson), o.IsInvisible(_str_idfFieldCollectedByPerson), o.IsRequired(_str_idfFieldCollectedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFieldCollectedByPerson, _formname = _str_strFieldCollectedByPerson, _type = "String",
              _get_func = o => o.strFieldCollectedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFieldCollectedByPerson != newval) o.strFieldCollectedByPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFieldCollectedByPerson != c.strFieldCollectedByPerson || o.IsRIRPropChanged(_str_strFieldCollectedByPerson, c)) 
                  m.Add(_str_strFieldCollectedByPerson, o.ObjectIdent + _str_strFieldCollectedByPerson, o.ObjectIdent2 + _str_strFieldCollectedByPerson, o.ObjectIdent3 + _str_strFieldCollectedByPerson, "String", 
                    o.strFieldCollectedByPerson == null ? "" : o.strFieldCollectedByPerson.ToString(),                  
                  o.IsReadOnly(_str_strFieldCollectedByPerson), o.IsInvisible(_str_strFieldCollectedByPerson), o.IsRequired(_str_strFieldCollectedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strNote, _formname = _str_strNote, _type = "String",
              _get_func = o => o.strNote,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strNote != newval) o.strNote = newval; },
              _compare_func = (o, c, m) => {
                if (o.strNote != c.strNote || o.IsRIRPropChanged(_str_strNote, c)) 
                  m.Add(_str_strNote, o.ObjectIdent + _str_strNote, o.ObjectIdent2 + _str_strNote, o.ObjectIdent3 + _str_strNote, "String", 
                    o.strNote == null ? "" : o.strNote.ToString(),                  
                  o.IsReadOnly(_str_strNote), o.IsInvisible(_str_strNote), o.IsRequired(_str_strNote)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfParentMaterial, _formname = _str_idfParentMaterial, _type = "Int64?",
              _get_func = o => o.idfParentMaterial,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfParentMaterial != newval) o.idfParentMaterial = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfParentMaterial != c.idfParentMaterial || o.IsRIRPropChanged(_str_idfParentMaterial, c)) 
                  m.Add(_str_idfParentMaterial, o.ObjectIdent + _str_idfParentMaterial, o.ObjectIdent2 + _str_idfParentMaterial, o.ObjectIdent3 + _str_idfParentMaterial, "Int64?", 
                    o.idfParentMaterial == null ? "" : o.idfParentMaterial.ToString(),                  
                  o.IsReadOnly(_str_idfParentMaterial), o.IsInvisible(_str_idfParentMaterial), o.IsRequired(_str_idfParentMaterial)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strParentBarcode, _formname = _str_strParentBarcode, _type = "String",
              _get_func = o => o.strParentBarcode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strParentBarcode != newval) o.strParentBarcode = newval; },
              _compare_func = (o, c, m) => {
                if (o.strParentBarcode != c.strParentBarcode || o.IsRIRPropChanged(_str_strParentBarcode, c)) 
                  m.Add(_str_strParentBarcode, o.ObjectIdent + _str_strParentBarcode, o.ObjectIdent2 + _str_strParentBarcode, o.ObjectIdent3 + _str_strParentBarcode, "String", 
                    o.strParentBarcode == null ? "" : o.strParentBarcode.ToString(),                  
                  o.IsReadOnly(_str_strParentBarcode), o.IsInvisible(_str_strParentBarcode), o.IsRequired(_str_strParentBarcode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_CaseType, _formname = _str_CaseType, _type = "String",
              _get_func = o => o.CaseType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.CaseType != newval) o.CaseType = newval; },
              _compare_func = (o, c, m) => {
                if (o.CaseType != c.CaseType || o.IsRIRPropChanged(_str_CaseType, c)) 
                  m.Add(_str_CaseType, o.ObjectIdent + _str_CaseType, o.ObjectIdent2 + _str_CaseType, o.ObjectIdent3 + _str_CaseType, "String", 
                    o.CaseType == null ? "" : o.CaseType.ToString(),                  
                  o.IsReadOnly(_str_CaseType), o.IsInvisible(_str_CaseType), o.IsRequired(_str_CaseType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datFieldCollectionDate, _formname = _str_datFieldCollectionDate, _type = "DateTime?",
              _get_func = o => o.datFieldCollectionDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datFieldCollectionDate != newval) o.datFieldCollectionDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datFieldCollectionDate != c.datFieldCollectionDate || o.IsRIRPropChanged(_str_datFieldCollectionDate, c)) 
                  m.Add(_str_datFieldCollectionDate, o.ObjectIdent + _str_datFieldCollectionDate, o.ObjectIdent2 + _str_datFieldCollectionDate, o.ObjectIdent3 + _str_datFieldCollectionDate, "DateTime?", 
                    o.datFieldCollectionDate == null ? "" : o.datFieldCollectionDate.ToString(),                  
                  o.IsReadOnly(_str_datFieldCollectionDate), o.IsInvisible(_str_datFieldCollectionDate), o.IsRequired(_str_datFieldCollectionDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsBirdStatus, _formname = _str_idfsBirdStatus, _type = "Int64?",
              _get_func = o => o.idfsBirdStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsBirdStatus != newval) o.idfsBirdStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsBirdStatus != c.idfsBirdStatus || o.IsRIRPropChanged(_str_idfsBirdStatus, c)) 
                  m.Add(_str_idfsBirdStatus, o.ObjectIdent + _str_idfsBirdStatus, o.ObjectIdent2 + _str_idfsBirdStatus, o.ObjectIdent3 + _str_idfsBirdStatus, "Int64?", 
                    o.idfsBirdStatus == null ? "" : o.idfsBirdStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsBirdStatus), o.IsInvisible(_str_idfsBirdStatus), o.IsRequired(_str_idfsBirdStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intHACode, _formname = _str_intHACode, _type = "Int32",
              _get_func = o => o.intHACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intHACode != newval) o.intHACode = newval; },
              _compare_func = (o, c, m) => {
                if (o.intHACode != c.intHACode || o.IsRIRPropChanged(_str_intHACode, c)) 
                  m.Add(_str_intHACode, o.ObjectIdent + _str_intHACode, o.ObjectIdent2 + _str_intHACode, o.ObjectIdent3 + _str_intHACode, "Int32", 
                    o.intHACode == null ? "" : o.intHACode.ToString(),                  
                  o.IsReadOnly(_str_intHACode), o.IsInvisible(_str_intHACode), o.IsRequired(_str_intHACode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDestructionMethod, _formname = _str_idfsDestructionMethod, _type = "Int64?",
              _get_func = o => o.idfsDestructionMethod,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsDestructionMethod != newval) o.idfsDestructionMethod = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDestructionMethod != c.idfsDestructionMethod || o.IsRIRPropChanged(_str_idfsDestructionMethod, c)) 
                  m.Add(_str_idfsDestructionMethod, o.ObjectIdent + _str_idfsDestructionMethod, o.ObjectIdent2 + _str_idfsDestructionMethod, o.ObjectIdent3 + _str_idfsDestructionMethod, "Int64?", 
                    o.idfsDestructionMethod == null ? "" : o.idfsDestructionMethod.ToString(),                  
                  o.IsReadOnly(_str_idfsDestructionMethod), o.IsInvisible(_str_idfsDestructionMethod), o.IsRequired(_str_idfsDestructionMethod)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSite, _formname = _str_idfsSite, _type = "Int64",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsSite != newval) o.idfsSite = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_idfsSite, c)) 
                  m.Add(_str_idfsSite, o.ObjectIdent + _str_idfsSite, o.ObjectIdent2 + _str_idfsSite, o.ObjectIdent3 + _str_idfsSite, "Int64", 
                    o.idfsSite == null ? "" : o.idfsSite.ToString(),                  
                  o.IsReadOnly(_str_idfsSite), o.IsInvisible(_str_idfsSite), o.IsRequired(_str_idfsSite)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCurrentSite, _formname = _str_idfsCurrentSite, _type = "Int64?",
              _get_func = o => o.idfsCurrentSite,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsCurrentSite != newval) o.idfsCurrentSite = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsCurrentSite != c.idfsCurrentSite || o.IsRIRPropChanged(_str_idfsCurrentSite, c)) 
                  m.Add(_str_idfsCurrentSite, o.ObjectIdent + _str_idfsCurrentSite, o.ObjectIdent2 + _str_idfsCurrentSite, o.ObjectIdent3 + _str_idfsCurrentSite, "Int64?", 
                    o.idfsCurrentSite == null ? "" : o.idfsCurrentSite.ToString(),                  
                  o.IsReadOnly(_str_idfsCurrentSite), o.IsInvisible(_str_idfsCurrentSite), o.IsRequired(_str_idfsCurrentSite)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnSampleTransferred, _formname = _str_blnSampleTransferred, _type = "Boolean?",
              _get_func = o => o.blnSampleTransferred,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnSampleTransferred != newval) o.blnSampleTransferred = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnSampleTransferred != c.blnSampleTransferred || o.IsRIRPropChanged(_str_blnSampleTransferred, c)) 
                  m.Add(_str_blnSampleTransferred, o.ObjectIdent + _str_blnSampleTransferred, o.ObjectIdent2 + _str_blnSampleTransferred, o.ObjectIdent3 + _str_blnSampleTransferred, "Boolean?", 
                    o.blnSampleTransferred == null ? "" : o.blnSampleTransferred.ToString(),                  
                  o.IsReadOnly(_str_blnSampleTransferred), o.IsInvisible(_str_blnSampleTransferred), o.IsRequired(_str_blnSampleTransferred)); 
                  }
              }, 
        
            new field_info {
              _name = _str_strFreezer, _formname = _str_strFreezer, _type = "string",
              _get_func = o => o.strFreezer,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strFreezer != c.strFreezer || o.IsRIRPropChanged(_str_strFreezer, c)) {
                  m.Add(_str_strFreezer, o.ObjectIdent + _str_strFreezer, o.ObjectIdent2 + _str_strFreezer, o.ObjectIdent3 + _str_strFreezer, "string", o.strFreezer == null ? "" : o.strFreezer.ToString(), o.IsReadOnly(_str_strFreezer), o.IsInvisible(_str_strFreezer), o.IsRequired(_str_strFreezer));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strCaseInfo, _formname = _str_strCaseInfo, _type = "string",
              _get_func = o => o.strCaseInfo,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strCaseInfo != c.strCaseInfo || o.IsRIRPropChanged(_str_strCaseInfo, c)) {
                  m.Add(_str_strCaseInfo, o.ObjectIdent + _str_strCaseInfo, o.ObjectIdent2 + _str_strCaseInfo, o.ObjectIdent3 + _str_strCaseInfo, "string", o.strCaseInfo == null ? "" : o.strCaseInfo.ToString(), o.IsReadOnly(_str_strCaseInfo), o.IsInvisible(_str_strCaseInfo), o.IsRequired(_str_strCaseInfo));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strMonitoringSessionInfo, _formname = _str_strMonitoringSessionInfo, _type = "string",
              _get_func = o => o.strMonitoringSessionInfo,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strMonitoringSessionInfo != c.strMonitoringSessionInfo || o.IsRIRPropChanged(_str_strMonitoringSessionInfo, c)) {
                  m.Add(_str_strMonitoringSessionInfo, o.ObjectIdent + _str_strMonitoringSessionInfo, o.ObjectIdent2 + _str_strMonitoringSessionInfo, o.ObjectIdent3 + _str_strMonitoringSessionInfo, "string", o.strMonitoringSessionInfo == null ? "" : o.strMonitoringSessionInfo.ToString(), o.IsReadOnly(_str_strMonitoringSessionInfo), o.IsInvisible(_str_strMonitoringSessionInfo), o.IsRequired(_str_strMonitoringSessionInfo));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Department, _formname = _str_Department, _type = "Lookup",
              _get_func = o => { if (o.Department == null) return null; return o.Department.idfDepartment; },
              _set_func = (o, val) => { o.Department = o.DepartmentLookup.Where(c => c.idfDepartment.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfInDepartment != c.idfInDepartment || o.IsRIRPropChanged(_str_Department, c)) {
                  m.Add(_str_Department, o.ObjectIdent + _str_Department, o.ObjectIdent2 + _str_Department, o.ObjectIdent3 + _str_Department, "Lookup", o.idfInDepartment == null ? "" : o.idfInDepartment.ToString(), o.IsReadOnly(_str_Department), o.IsInvisible(_str_Department), o.IsRequired(_str_Department)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Department + "Lookup", _formname = _str_Department + "Lookup", _type = "LookupContent",
              _get_func = o => o.DepartmentLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Freezer, _formname = _str_Freezer, _type = "Lookup",
              _get_func = o => { if (o.Freezer == null) return null; return o.Freezer.ID; },
              _set_func = (o, val) => { o.Freezer = o.FreezerLookup.Where(c => c.ID.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfSubdivision != c.idfSubdivision || o.IsRIRPropChanged(_str_Freezer, c)) {
                  m.Add(_str_Freezer, o.ObjectIdent + _str_Freezer, o.ObjectIdent2 + _str_Freezer, o.ObjectIdent3 + _str_Freezer, "Lookup", o.idfSubdivision == null ? "" : o.idfSubdivision.ToString(), o.IsReadOnly(_str_Freezer), o.IsInvisible(_str_Freezer), o.IsRequired(_str_Freezer)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Freezer + "Lookup", _formname = _str_Freezer + "Lookup", _type = "LookupContent",
              _get_func = o => o.FreezerLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
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
    
        [LocalizedDisplayName(_str_Department)]
        [Relation(typeof(DepartmentLookup), eidss.model.Schema.DepartmentLookup._str_idfDepartment, _str_idfInDepartment)]
        public DepartmentLookup Department
        {
            get { return _Department == null ? null : ((long)_Department.Key == 0 ? null : _Department); }
            set 
            { 
                var oldVal = _Department;
                _Department = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Department != oldVal)
                {
                    if (idfInDepartment != (_Department == null
                            ? new Int64?()
                            : (Int64?)_Department.idfDepartment))
                        idfInDepartment = _Department == null 
                            ? new Int64?()
                            : (Int64?)_Department.idfDepartment; 
                    OnPropertyChanged(_str_Department); 
                }
            }
        }
        private DepartmentLookup _Department;

        
        public List<DepartmentLookup> DepartmentLookup
        {
            get { return _DepartmentLookup; }
        }
        private List<DepartmentLookup> _DepartmentLookup = new List<DepartmentLookup>();
            
        [LocalizedDisplayName(_str_Freezer)]
        [Relation(typeof(FreezerTreeLookup), eidss.model.Schema.FreezerTreeLookup._str_ID, _str_idfSubdivision)]
        public FreezerTreeLookup Freezer
        {
            get { return _Freezer == null ? null : ((long)_Freezer.Key == 0 ? null : _Freezer); }
            set 
            { 
                var oldVal = _Freezer;
                _Freezer = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Freezer != oldVal)
                {
                    if (idfSubdivision != (_Freezer == null
                            ? new Int64?()
                            : (Int64?)_Freezer.ID))
                        idfSubdivision = _Freezer == null 
                            ? new Int64?()
                            : (Int64?)_Freezer.ID; 
                    OnPropertyChanged(_str_Freezer); 
                }
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
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strMonitoringSessionInfo)]
        public string strMonitoringSessionInfo
        {
            get { return new Func<LabSample, string>(c => c.strMonitoringSessionID + ", " + c.SessionDiagnosisName)(this); }
            
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
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as LabSample;
            ret.Cloned();
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = base.Clone() as LabSample;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
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
        public object Key { get { return idfMaterial; } }
        public string KeyName { get { return "idfMaterial"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        [XmlIgnore]
        [LocalizedDisplayName("HasChanges")]
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
        [XmlIgnore]
        [LocalizedDisplayName("IsDirty")]
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
        
        public string ObjectIdent2 { get { return ObjectIdent; } }
          
        public string ObjectIdent3 { get { return ObjectIdent; } }
          
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public IObjectPermissions GetPermissions() { return _permissions; }
        private IObjectEnvironment _environment;
        public IObjectEnvironment Environment { get { return _environment; } set { _environment = value; } }
        public bool ReadOnly { get { return _readOnly; } set { _readOnly = value; } }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsInvisible(string name) { return _isInvisible(name); }
        public bool IsRequired(string name) { return _isRequired(m_isRequired, name); }
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
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public LabSample()
        {
            
            m_permissions = new Permissions(this);
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
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
                  
            if (e.PropertyName == _str_strMonitoringSessionID)
                OnPropertyChanged(_str_strMonitoringSessionInfo);
                  
            if (e.PropertyName == _str_SessionDiagnosisName)
                OnPropertyChanged(_str_strMonitoringSessionInfo);
                  
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
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ShouldAsk);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ShouldAsk);
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


        internal Dictionary<string, Func<LabSample, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<LabSample, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabSample, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabSample, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<LabSample, bool>> m_isHiddenPersonalData;
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
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<LabSample>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<LabSample>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<LabSample>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfMaterial"; } }
            #endregion
        
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
            public virtual LabSample SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
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
                , Int64? idfMaterial
                )
            {
                return _SelectByKey(manager
                    , idfMaterial
                    , null, null
                    );
            }
            
      
            private LabSample _SelectByKey(DbManagerProxy manager
                , Int64? idfMaterial
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
                            , manager.Parameter("@idfMaterial", idfMaterial)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabSample obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                }
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

    

            private LabSample _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
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
            public LabSample CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
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
                        .SingleOrDefault(c => c.idfDepartment == obj.idfInDepartment);
                    
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
                        .SingleOrDefault(c => c.ID == obj.idfSubdivision);
                    
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
                    
                    long mainObject = bo.idfMaterial;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        
                    }

                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
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
                            obj.DeepAcceptChanges();
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
                bool bHasChanges = obj.HasChanges;
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
            
                    if (!obj.IsMarkedToDelete && bHasChanges)
                        _postPredicate(manager, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
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
        
      
            protected ValidationModelException ChainsValidate(LabSample obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(LabSample obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as LabSample, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabSample obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
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
            
            
    private static Dictionary<string, List<Func<bool>>> m_isHiddenPersonalData = new Dictionary<string, List<Func<bool>>>();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func<bool> func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List<Func<bool>>());
      m_isHiddenPersonalData[name].Add(func);
    }
  
            
            static Meta()
            {
                
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strCaseID, 200);
                Sizes.Add(_str_strMonitoringSessionID, 50);
                Sizes.Add(_str_strSampleName, 2000);
                Sizes.Add(_str_SpeciesName, 4000);
                Sizes.Add(_str_strAnimalCode, 200);
                Sizes.Add(_str_HumanName, 602);
                Sizes.Add(_str_DiagnosisName, 2000);
                Sizes.Add(_str_SessionDiagnosisName, 500);
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
                    
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    
        AddHiddenPersonalData("HumanName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName));
      

    }
  
        }
        #endregion
    

        #endregion
        }
    
}
	