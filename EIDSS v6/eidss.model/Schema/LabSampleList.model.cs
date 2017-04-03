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
    public abstract partial class LabSampleListItem : 
        EditableObject<LabSampleListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfMaterial), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMaterial { get; set; }
                
        [LocalizedDisplayName(_str_strFieldBarcode)]
        [MapField(_str_strFieldBarcode)]
        public abstract String strFieldBarcode { get; set; }
        protected String strFieldBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).OriginalValue; } }
        protected String strFieldBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).PreviousValue; } }
                
        [LocalizedDisplayName("strLabBarcode")]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSampleStatus)]
        [MapField(_str_idfsSampleStatus)]
        public abstract Int64? idfsSampleStatus { get; set; }
        protected Int64? idfsSampleStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleStatus).OriginalValue; } }
        protected Int64? idfsSampleStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfInDepartment)]
        [MapField(_str_idfInDepartment)]
        public abstract Int64? idfInDepartment { get; set; }
        protected Int64? idfInDepartment_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInDepartment).OriginalValue; } }
        protected Int64? idfInDepartment_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInDepartment).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSampleType)]
        [MapField(_str_idfsSampleType)]
        public abstract Int64 idfsSampleType { get; set; }
        protected Int64 idfsSampleType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSampleType).OriginalValue; } }
        protected Int64 idfsSampleType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSampleType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSampleName)]
        [MapField(_str_strSampleName)]
        public abstract String strSampleName { get; set; }
        protected String strSampleName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).OriginalValue; } }
        protected String strSampleName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_idfVectorSurveillanceSession)]
        [MapField(_str_idfVectorSurveillanceSession)]
        public abstract Int64? idfVectorSurveillanceSession { get; set; }
        protected Int64? idfVectorSurveillanceSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).OriginalValue; } }
        protected Int64? idfVectorSurveillanceSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSpeciesType)]
        [MapField(_str_idfsSpeciesType)]
        public abstract Int64? idfsSpeciesType { get; set; }
        protected Int64? idfsSpeciesType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).OriginalValue; } }
        protected Int64? idfsSpeciesType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_CaseID)]
        [MapField(_str_CaseID)]
        public abstract String CaseID { get; set; }
        protected String CaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._caseID).OriginalValue; } }
        protected String CaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._caseID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCaseType)]
        [MapField(_str_idfsCaseType)]
        public abstract Int64? idfsCaseType { get; set; }
        protected Int64? idfsCaseType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).OriginalValue; } }
        protected Int64? idfsCaseType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFieldCollectionDate)]
        [MapField(_str_datFieldCollectionDate)]
        public abstract DateTime? datFieldCollectionDate { get; set; }
        protected DateTime? datFieldCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).OriginalValue; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsShowDiagnosis)]
        [MapField(_str_idfsShowDiagnosis)]
        public abstract Int64? idfsShowDiagnosis { get; set; }
        protected Int64? idfsShowDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsShowDiagnosis).OriginalValue; } }
        protected Int64? idfsShowDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsShowDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTentativeDiagnosis)]
        [MapField(_str_idfsTentativeDiagnosis)]
        public abstract Int64? idfsTentativeDiagnosis { get; set; }
        protected Int64? idfsTentativeDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis).OriginalValue; } }
        protected Int64? idfsTentativeDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTentativeDiagnosis1)]
        [MapField(_str_idfsTentativeDiagnosis1)]
        public abstract Int64? idfsTentativeDiagnosis1 { get; set; }
        protected Int64? idfsTentativeDiagnosis1_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis1).OriginalValue; } }
        protected Int64? idfsTentativeDiagnosis1_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis1).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTentativeDiagnosis2)]
        [MapField(_str_idfsTentativeDiagnosis2)]
        public abstract Int64? idfsTentativeDiagnosis2 { get; set; }
        protected Int64? idfsTentativeDiagnosis2_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis2).OriginalValue; } }
        protected Int64? idfsTentativeDiagnosis2_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis2).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFinalDiagnosis)]
        [MapField(_str_idfsFinalDiagnosis)]
        public abstract Int64? idfsFinalDiagnosis { get; set; }
        protected Int64? idfsFinalDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFinalDiagnosis).OriginalValue; } }
        protected Int64? idfsFinalDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFinalDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName("idfsDiagnosis")]
        [MapField(_str_DiagnosisName)]
        public abstract String DiagnosisName { get; set; }
        protected String DiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).OriginalValue; } }
        protected String DiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strNationalName)]
        [MapField(_str_strNationalName)]
        public abstract String strNationalName { get; set; }
        protected String strNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._strNationalName).OriginalValue; } }
        protected String strNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNationalName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DepartmentName)]
        [MapField(_str_DepartmentName)]
        public abstract String DepartmentName { get; set; }
        protected String DepartmentName_Original { get { return ((EditableValue<String>)((dynamic)this)._departmentName).OriginalValue; } }
        protected String DepartmentName_Previous { get { return ((EditableValue<String>)((dynamic)this)._departmentName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_HumanName)]
        [MapField(_str_HumanName)]
        public abstract String HumanName { get; set; }
        protected String HumanName_Original { get { return ((EditableValue<String>)((dynamic)this)._humanName).OriginalValue; } }
        protected String HumanName_Previous { get { return ((EditableValue<String>)((dynamic)this)._humanName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_AnimalName)]
        [MapField(_str_AnimalName)]
        public abstract String AnimalName { get; set; }
        protected String AnimalName_Original { get { return ((EditableValue<String>)((dynamic)this)._animalName).OriginalValue; } }
        protected String AnimalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._animalName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_Path)]
        [MapField(_str_Path)]
        public abstract Int32? Path { get; set; }
        protected Int32? Path_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._path).OriginalValue; } }
        protected Int32? Path_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._path).PreviousValue; } }
                
        [LocalizedDisplayName(_str_TestsCount)]
        [MapField(_str_TestsCount)]
        public abstract Int32 TestsCount { get; set; }
        protected Int32 TestsCount_Original { get { return ((EditableValue<Int32>)((dynamic)this)._testsCount).OriginalValue; } }
        protected Int32 TestsCount_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._testsCount).PreviousValue; } }
                
        [LocalizedDisplayName(_str_HACode)]
        [MapField(_str_HACode)]
        public abstract Int32? HACode { get; set; }
        protected Int32? HACode_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._hACode).OriginalValue; } }
        protected Int32? HACode_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._hACode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datAccession)]
        [MapField(_str_datAccession)]
        public abstract DateTime? datAccession { get; set; }
        protected DateTime? datAccession_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).OriginalValue; } }
        protected DateTime? datAccession_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPatientName)]
        [MapField(_str_strPatientName)]
        public abstract String strPatientName { get; set; }
        protected String strPatientName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPatientName).OriginalValue; } }
        protected String strPatientName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPatientName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFarmOwner)]
        [MapField(_str_strFarmOwner)]
        public abstract String strFarmOwner { get; set; }
        protected String strFarmOwner_Original { get { return ((EditableValue<String>)((dynamic)this)._strFarmOwner).OriginalValue; } }
        protected String strFarmOwner_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFarmOwner).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<LabSampleListItem, object> _get_func;
            internal Action<LabSampleListItem, string> _set_func;
            internal Action<LabSampleListItem, LabSampleListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_idfsSampleStatus = "idfsSampleStatus";
        internal const string _str_idfInDepartment = "idfInDepartment";
        internal const string _str_idfsSampleType = "idfsSampleType";
        internal const string _str_strSampleName = "strSampleName";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfsSpeciesType = "idfsSpeciesType";
        internal const string _str_CaseID = "CaseID";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_idfsShowDiagnosis = "idfsShowDiagnosis";
        internal const string _str_idfsTentativeDiagnosis = "idfsTentativeDiagnosis";
        internal const string _str_idfsTentativeDiagnosis1 = "idfsTentativeDiagnosis1";
        internal const string _str_idfsTentativeDiagnosis2 = "idfsTentativeDiagnosis2";
        internal const string _str_idfsFinalDiagnosis = "idfsFinalDiagnosis";
        internal const string _str_DiagnosisName = "DiagnosisName";
        internal const string _str_strNationalName = "strNationalName";
        internal const string _str_DepartmentName = "DepartmentName";
        internal const string _str_HumanName = "HumanName";
        internal const string _str_AnimalName = "AnimalName";
        internal const string _str_Path = "Path";
        internal const string _str_TestsCount = "TestsCount";
        internal const string _str_HACode = "HACode";
        internal const string _str_datAccession = "datAccession";
        internal const string _str_strPatientName = "strPatientName";
        internal const string _str_strFarmOwner = "strFarmOwner";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_idfsCaseStatus = "idfsCaseStatus";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_SampleType = "SampleType";
        internal const string _str_SampleStatus = "SampleStatus";
        internal const string _str_CaseStatus = "CaseStatus";
        internal const string _str_Department = "Department";
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
              _name = _str_strFieldBarcode, _formname = _str_strFieldBarcode, _type = "String",
              _get_func = o => o.strFieldBarcode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFieldBarcode != newval) o.strFieldBarcode = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFieldBarcode != c.strFieldBarcode || o.IsRIRPropChanged(_str_strFieldBarcode, c)) 
                  m.Add(_str_strFieldBarcode, o.ObjectIdent + _str_strFieldBarcode, o.ObjectIdent2 + _str_strFieldBarcode, o.ObjectIdent3 + _str_strFieldBarcode, "String", 
                    o.strFieldBarcode == null ? "" : o.strFieldBarcode.ToString(),                  
                  o.IsReadOnly(_str_strFieldBarcode), o.IsInvisible(_str_strFieldBarcode), o.IsRequired(_str_strFieldBarcode)); 
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
              _name = _str_idfsSampleStatus, _formname = _str_idfsSampleStatus, _type = "Int64?",
              _get_func = o => o.idfsSampleStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsSampleStatus != newval) 
                  o.SampleStatus = o.SampleStatusLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsSampleStatus != newval) o.idfsSampleStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSampleStatus != c.idfsSampleStatus || o.IsRIRPropChanged(_str_idfsSampleStatus, c)) 
                  m.Add(_str_idfsSampleStatus, o.ObjectIdent + _str_idfsSampleStatus, o.ObjectIdent2 + _str_idfsSampleStatus, o.ObjectIdent3 + _str_idfsSampleStatus, "Int64?", 
                    o.idfsSampleStatus == null ? "" : o.idfsSampleStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsSampleStatus), o.IsInvisible(_str_idfsSampleStatus), o.IsRequired(_str_idfsSampleStatus)); 
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
              _name = _str_idfsSampleType, _formname = _str_idfsSampleType, _type = "Int64",
              _get_func = o => o.idfsSampleType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsSampleType != newval) 
                  o.SampleType = o.SampleTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsSampleType != newval) o.idfsSampleType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSampleType != c.idfsSampleType || o.IsRIRPropChanged(_str_idfsSampleType, c)) 
                  m.Add(_str_idfsSampleType, o.ObjectIdent + _str_idfsSampleType, o.ObjectIdent2 + _str_idfsSampleType, o.ObjectIdent3 + _str_idfsSampleType, "Int64", 
                    o.idfsSampleType == null ? "" : o.idfsSampleType.ToString(),                  
                  o.IsReadOnly(_str_idfsSampleType), o.IsInvisible(_str_idfsSampleType), o.IsRequired(_str_idfsSampleType)); 
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
              _name = _str_idfsSpeciesType, _formname = _str_idfsSpeciesType, _type = "Int64?",
              _get_func = o => o.idfsSpeciesType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSpeciesType != newval) o.idfsSpeciesType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_idfsSpeciesType, c)) 
                  m.Add(_str_idfsSpeciesType, o.ObjectIdent + _str_idfsSpeciesType, o.ObjectIdent2 + _str_idfsSpeciesType, o.ObjectIdent3 + _str_idfsSpeciesType, "Int64?", 
                    o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(),                  
                  o.IsReadOnly(_str_idfsSpeciesType), o.IsInvisible(_str_idfsSpeciesType), o.IsRequired(_str_idfsSpeciesType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_CaseID, _formname = _str_CaseID, _type = "String",
              _get_func = o => o.CaseID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.CaseID != newval) o.CaseID = newval; },
              _compare_func = (o, c, m) => {
                if (o.CaseID != c.CaseID || o.IsRIRPropChanged(_str_CaseID, c)) 
                  m.Add(_str_CaseID, o.ObjectIdent + _str_CaseID, o.ObjectIdent2 + _str_CaseID, o.ObjectIdent3 + _str_CaseID, "String", 
                    o.CaseID == null ? "" : o.CaseID.ToString(),                  
                  o.IsReadOnly(_str_CaseID), o.IsInvisible(_str_CaseID), o.IsRequired(_str_CaseID)); 
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
              _name = _str_idfsTentativeDiagnosis, _formname = _str_idfsTentativeDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsTentativeDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTentativeDiagnosis != newval) o.idfsTentativeDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsTentativeDiagnosis != c.idfsTentativeDiagnosis || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis, c)) 
                  m.Add(_str_idfsTentativeDiagnosis, o.ObjectIdent + _str_idfsTentativeDiagnosis, o.ObjectIdent2 + _str_idfsTentativeDiagnosis, o.ObjectIdent3 + _str_idfsTentativeDiagnosis, "Int64?", 
                    o.idfsTentativeDiagnosis == null ? "" : o.idfsTentativeDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsTentativeDiagnosis), o.IsInvisible(_str_idfsTentativeDiagnosis), o.IsRequired(_str_idfsTentativeDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTentativeDiagnosis1, _formname = _str_idfsTentativeDiagnosis1, _type = "Int64?",
              _get_func = o => o.idfsTentativeDiagnosis1,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTentativeDiagnosis1 != newval) o.idfsTentativeDiagnosis1 = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsTentativeDiagnosis1 != c.idfsTentativeDiagnosis1 || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis1, c)) 
                  m.Add(_str_idfsTentativeDiagnosis1, o.ObjectIdent + _str_idfsTentativeDiagnosis1, o.ObjectIdent2 + _str_idfsTentativeDiagnosis1, o.ObjectIdent3 + _str_idfsTentativeDiagnosis1, "Int64?", 
                    o.idfsTentativeDiagnosis1 == null ? "" : o.idfsTentativeDiagnosis1.ToString(),                  
                  o.IsReadOnly(_str_idfsTentativeDiagnosis1), o.IsInvisible(_str_idfsTentativeDiagnosis1), o.IsRequired(_str_idfsTentativeDiagnosis1)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTentativeDiagnosis2, _formname = _str_idfsTentativeDiagnosis2, _type = "Int64?",
              _get_func = o => o.idfsTentativeDiagnosis2,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTentativeDiagnosis2 != newval) o.idfsTentativeDiagnosis2 = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsTentativeDiagnosis2 != c.idfsTentativeDiagnosis2 || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis2, c)) 
                  m.Add(_str_idfsTentativeDiagnosis2, o.ObjectIdent + _str_idfsTentativeDiagnosis2, o.ObjectIdent2 + _str_idfsTentativeDiagnosis2, o.ObjectIdent3 + _str_idfsTentativeDiagnosis2, "Int64?", 
                    o.idfsTentativeDiagnosis2 == null ? "" : o.idfsTentativeDiagnosis2.ToString(),                  
                  o.IsReadOnly(_str_idfsTentativeDiagnosis2), o.IsInvisible(_str_idfsTentativeDiagnosis2), o.IsRequired(_str_idfsTentativeDiagnosis2)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsFinalDiagnosis, _formname = _str_idfsFinalDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsFinalDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsFinalDiagnosis != newval) o.idfsFinalDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsFinalDiagnosis != c.idfsFinalDiagnosis || o.IsRIRPropChanged(_str_idfsFinalDiagnosis, c)) 
                  m.Add(_str_idfsFinalDiagnosis, o.ObjectIdent + _str_idfsFinalDiagnosis, o.ObjectIdent2 + _str_idfsFinalDiagnosis, o.ObjectIdent3 + _str_idfsFinalDiagnosis, "Int64?", 
                    o.idfsFinalDiagnosis == null ? "" : o.idfsFinalDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsFinalDiagnosis), o.IsInvisible(_str_idfsFinalDiagnosis), o.IsRequired(_str_idfsFinalDiagnosis)); 
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
              _name = _str_strNationalName, _formname = _str_strNationalName, _type = "String",
              _get_func = o => o.strNationalName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strNationalName != newval) o.strNationalName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strNationalName != c.strNationalName || o.IsRIRPropChanged(_str_strNationalName, c)) 
                  m.Add(_str_strNationalName, o.ObjectIdent + _str_strNationalName, o.ObjectIdent2 + _str_strNationalName, o.ObjectIdent3 + _str_strNationalName, "String", 
                    o.strNationalName == null ? "" : o.strNationalName.ToString(),                  
                  o.IsReadOnly(_str_strNationalName), o.IsInvisible(_str_strNationalName), o.IsRequired(_str_strNationalName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DepartmentName, _formname = _str_DepartmentName, _type = "String",
              _get_func = o => o.DepartmentName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DepartmentName != newval) o.DepartmentName = newval; },
              _compare_func = (o, c, m) => {
                if (o.DepartmentName != c.DepartmentName || o.IsRIRPropChanged(_str_DepartmentName, c)) 
                  m.Add(_str_DepartmentName, o.ObjectIdent + _str_DepartmentName, o.ObjectIdent2 + _str_DepartmentName, o.ObjectIdent3 + _str_DepartmentName, "String", 
                    o.DepartmentName == null ? "" : o.DepartmentName.ToString(),                  
                  o.IsReadOnly(_str_DepartmentName), o.IsInvisible(_str_DepartmentName), o.IsRequired(_str_DepartmentName)); 
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
              _name = _str_AnimalName, _formname = _str_AnimalName, _type = "String",
              _get_func = o => o.AnimalName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.AnimalName != newval) o.AnimalName = newval; },
              _compare_func = (o, c, m) => {
                if (o.AnimalName != c.AnimalName || o.IsRIRPropChanged(_str_AnimalName, c)) 
                  m.Add(_str_AnimalName, o.ObjectIdent + _str_AnimalName, o.ObjectIdent2 + _str_AnimalName, o.ObjectIdent3 + _str_AnimalName, "String", 
                    o.AnimalName == null ? "" : o.AnimalName.ToString(),                  
                  o.IsReadOnly(_str_AnimalName), o.IsInvisible(_str_AnimalName), o.IsRequired(_str_AnimalName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Path, _formname = _str_Path, _type = "Int32?",
              _get_func = o => o.Path,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.Path != newval) o.Path = newval; },
              _compare_func = (o, c, m) => {
                if (o.Path != c.Path || o.IsRIRPropChanged(_str_Path, c)) 
                  m.Add(_str_Path, o.ObjectIdent + _str_Path, o.ObjectIdent2 + _str_Path, o.ObjectIdent3 + _str_Path, "Int32?", 
                    o.Path == null ? "" : o.Path.ToString(),                  
                  o.IsReadOnly(_str_Path), o.IsInvisible(_str_Path), o.IsRequired(_str_Path)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_TestsCount, _formname = _str_TestsCount, _type = "Int32",
              _get_func = o => o.TestsCount,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.TestsCount != newval) o.TestsCount = newval; },
              _compare_func = (o, c, m) => {
                if (o.TestsCount != c.TestsCount || o.IsRIRPropChanged(_str_TestsCount, c)) 
                  m.Add(_str_TestsCount, o.ObjectIdent + _str_TestsCount, o.ObjectIdent2 + _str_TestsCount, o.ObjectIdent3 + _str_TestsCount, "Int32", 
                    o.TestsCount == null ? "" : o.TestsCount.ToString(),                  
                  o.IsReadOnly(_str_TestsCount), o.IsInvisible(_str_TestsCount), o.IsRequired(_str_TestsCount)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_HACode, _formname = _str_HACode, _type = "Int32?",
              _get_func = o => o.HACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.HACode != newval) o.HACode = newval; },
              _compare_func = (o, c, m) => {
                if (o.HACode != c.HACode || o.IsRIRPropChanged(_str_HACode, c)) 
                  m.Add(_str_HACode, o.ObjectIdent + _str_HACode, o.ObjectIdent2 + _str_HACode, o.ObjectIdent3 + _str_HACode, "Int32?", 
                    o.HACode == null ? "" : o.HACode.ToString(),                  
                  o.IsReadOnly(_str_HACode), o.IsInvisible(_str_HACode), o.IsRequired(_str_HACode)); 
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
              _name = _str_strPatientName, _formname = _str_strPatientName, _type = "String",
              _get_func = o => o.strPatientName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPatientName != newval) o.strPatientName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPatientName != c.strPatientName || o.IsRIRPropChanged(_str_strPatientName, c)) 
                  m.Add(_str_strPatientName, o.ObjectIdent + _str_strPatientName, o.ObjectIdent2 + _str_strPatientName, o.ObjectIdent3 + _str_strPatientName, "String", 
                    o.strPatientName == null ? "" : o.strPatientName.ToString(),                  
                  o.IsReadOnly(_str_strPatientName), o.IsInvisible(_str_strPatientName), o.IsRequired(_str_strPatientName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFarmOwner, _formname = _str_strFarmOwner, _type = "String",
              _get_func = o => o.strFarmOwner,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFarmOwner != newval) o.strFarmOwner = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFarmOwner != c.strFarmOwner || o.IsRIRPropChanged(_str_strFarmOwner, c)) 
                  m.Add(_str_strFarmOwner, o.ObjectIdent + _str_strFarmOwner, o.ObjectIdent2 + _str_strFarmOwner, o.ObjectIdent3 + _str_strFarmOwner, "String", 
                    o.strFarmOwner == null ? "" : o.strFarmOwner.ToString(),                  
                  o.IsReadOnly(_str_strFarmOwner), o.IsInvisible(_str_strFarmOwner), o.IsRequired(_str_strFarmOwner)); 
                  }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "long?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) {
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis,  "long?", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                    o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsCaseStatus, _formname = _str_idfsCaseStatus, _type = "long?",
              _get_func = o => o.idfsCaseStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsCaseStatus != newval) o.idfsCaseStatus = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsCaseStatus != c.idfsCaseStatus || o.IsRIRPropChanged(_str_idfsCaseStatus, c)) {
                  m.Add(_str_idfsCaseStatus, o.ObjectIdent + _str_idfsCaseStatus, o.ObjectIdent2 + _str_idfsCaseStatus, o.ObjectIdent3 + _str_idfsCaseStatus,  "long?", 
                    o.idfsCaseStatus == null ? "" : o.idfsCaseStatus.ToString(),                  
                    o.IsReadOnly(_str_idfsCaseStatus), o.IsInvisible(_str_idfsCaseStatus), o.IsRequired(_str_idfsCaseStatus));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _formname = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnosis, c)) {
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, o.ObjectIdent2 + _str_Diagnosis, o.ObjectIdent3 + _str_Diagnosis, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Diagnosis + "Lookup", _formname = _str_Diagnosis + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_SampleType, _formname = _str_SampleType, _type = "Lookup",
              _get_func = o => { if (o.SampleType == null) return null; return o.SampleType.idfsBaseReference; },
              _set_func = (o, val) => { o.SampleType = o.SampleTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSampleType != c.idfsSampleType || o.IsRIRPropChanged(_str_SampleType, c)) {
                  m.Add(_str_SampleType, o.ObjectIdent + _str_SampleType, o.ObjectIdent2 + _str_SampleType, o.ObjectIdent3 + _str_SampleType, "Lookup", o.idfsSampleType == null ? "" : o.idfsSampleType.ToString(), o.IsReadOnly(_str_SampleType), o.IsInvisible(_str_SampleType), o.IsRequired(_str_SampleType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SampleType + "Lookup", _formname = _str_SampleType + "Lookup", _type = "LookupContent",
              _get_func = o => o.SampleTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_SampleStatus, _formname = _str_SampleStatus, _type = "Lookup",
              _get_func = o => { if (o.SampleStatus == null) return null; return o.SampleStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.SampleStatus = o.SampleStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSampleStatus != c.idfsSampleStatus || o.IsRIRPropChanged(_str_SampleStatus, c)) {
                  m.Add(_str_SampleStatus, o.ObjectIdent + _str_SampleStatus, o.ObjectIdent2 + _str_SampleStatus, o.ObjectIdent3 + _str_SampleStatus, "Lookup", o.idfsSampleStatus == null ? "" : o.idfsSampleStatus.ToString(), o.IsReadOnly(_str_SampleStatus), o.IsInvisible(_str_SampleStatus), o.IsRequired(_str_SampleStatus)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SampleStatus + "Lookup", _formname = _str_SampleStatus + "Lookup", _type = "LookupContent",
              _get_func = o => o.SampleStatusLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_CaseStatus, _formname = _str_CaseStatus, _type = "Lookup",
              _get_func = o => { if (o.CaseStatus == null) return null; return o.CaseStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.CaseStatus = o.CaseStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseStatus != c.idfsCaseStatus || o.IsRIRPropChanged(_str_CaseStatus, c)) {
                  m.Add(_str_CaseStatus, o.ObjectIdent + _str_CaseStatus, o.ObjectIdent2 + _str_CaseStatus, o.ObjectIdent3 + _str_CaseStatus, "Lookup", o.idfsCaseStatus == null ? "" : o.idfsCaseStatus.ToString(), o.IsReadOnly(_str_CaseStatus), o.IsInvisible(_str_CaseStatus), o.IsRequired(_str_CaseStatus)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_CaseStatus + "Lookup", _formname = _str_CaseStatus + "Lookup", _type = "LookupContent",
              _get_func = o => o.CaseStatusLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
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
            LabSampleListItem obj = (LabSampleListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Diagnosis)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                var oldVal = _Diagnosis;
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Diagnosis != oldVal)
                {
                    if (idfsDiagnosis != (_Diagnosis == null
                            ? new long?()
                            : _Diagnosis.idfsDiagnosis))
                        idfsDiagnosis = _Diagnosis == null 
                            ? new long?()
                            : _Diagnosis.idfsDiagnosis; 
                    OnPropertyChanged(_str_Diagnosis); 
                }
            }
        }
        private DiagnosisLookup _Diagnosis;

        
        public List<DiagnosisLookup> DiagnosisLookup
        {
            get { return _DiagnosisLookup; }
        }
        private List<DiagnosisLookup> _DiagnosisLookup = new List<DiagnosisLookup>();
            
        [LocalizedDisplayName(_str_SampleType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSampleType)]
        public BaseReference SampleType
        {
            get { return _SampleType == null ? null : ((long)_SampleType.Key == 0 ? null : _SampleType); }
            set 
            { 
                var oldVal = _SampleType;
                _SampleType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SampleType != oldVal)
                {
                    if (idfsSampleType != (_SampleType == null
                            ? new Int64()
                            : (Int64)_SampleType.idfsBaseReference))
                        idfsSampleType = _SampleType == null 
                            ? new Int64()
                            : (Int64)_SampleType.idfsBaseReference; 
                    OnPropertyChanged(_str_SampleType); 
                }
            }
        }
        private BaseReference _SampleType;

        
        public BaseReferenceList SampleTypeLookup
        {
            get { return _SampleTypeLookup; }
        }
        private BaseReferenceList _SampleTypeLookup = new BaseReferenceList("rftSampleType");
            
        [LocalizedDisplayName(_str_SampleStatus)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSampleStatus)]
        public BaseReference SampleStatus
        {
            get { return _SampleStatus == null ? null : ((long)_SampleStatus.Key == 0 ? null : _SampleStatus); }
            set 
            { 
                var oldVal = _SampleStatus;
                _SampleStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SampleStatus != oldVal)
                {
                    if (idfsSampleStatus != (_SampleStatus == null
                            ? new Int64?()
                            : (Int64?)_SampleStatus.idfsBaseReference))
                        idfsSampleStatus = _SampleStatus == null 
                            ? new Int64?()
                            : (Int64?)_SampleStatus.idfsBaseReference; 
                    OnPropertyChanged(_str_SampleStatus); 
                }
            }
        }
        private BaseReference _SampleStatus;

        
        public BaseReferenceList SampleStatusLookup
        {
            get { return _SampleStatusLookup; }
        }
        private BaseReferenceList _SampleStatusLookup = new BaseReferenceList("rftSampleStatus");
            
        [LocalizedDisplayName(_str_CaseStatus)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCaseStatus)]
        public BaseReference CaseStatus
        {
            get { return _CaseStatus == null ? null : ((long)_CaseStatus.Key == 0 ? null : _CaseStatus); }
            set 
            { 
                var oldVal = _CaseStatus;
                _CaseStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_CaseStatus != oldVal)
                {
                    if (idfsCaseStatus != (_CaseStatus == null
                            ? new long?()
                            : _CaseStatus.idfsBaseReference))
                        idfsCaseStatus = _CaseStatus == null 
                            ? new long?()
                            : _CaseStatus.idfsBaseReference; 
                    OnPropertyChanged(_str_CaseStatus); 
                }
            }
        }
        private BaseReference _CaseStatus;

        
        public BaseReferenceList CaseStatusLookup
        {
            get { return _CaseStatusLookup; }
        }
        private BaseReferenceList _CaseStatusLookup = new BaseReferenceList("rftSampleStatus");
            
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
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_SampleType:
                    return new BvSelectList(SampleTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SampleType, _str_idfsSampleType);
            
                case _str_SampleStatus:
                    return new BvSelectList(SampleStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SampleStatus, _str_idfsSampleStatus);
            
                case _str_CaseStatus:
                    return new BvSelectList(CaseStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CaseStatus, _str_idfsCaseStatus);
            
                case _str_Department:
                    return new BvSelectList(DepartmentLookup, eidss.model.Schema.DepartmentLookup._str_idfDepartment, null, Department, _str_idfInDepartment);
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str_idfsDiagnosis)]
        public long? idfsDiagnosis
        {
            get { return m_idfsDiagnosis; }
            set { if (m_idfsDiagnosis != value) { m_idfsDiagnosis = value; OnPropertyChanged(_str_idfsDiagnosis); } }
        }
        private long? m_idfsDiagnosis;
        
          [LocalizedDisplayName(_str_idfsCaseStatus)]
        public long? idfsCaseStatus
        {
            get { return m_idfsCaseStatus; }
            set { if (m_idfsCaseStatus != value) { m_idfsCaseStatus = value; OnPropertyChanged(_str_idfsCaseStatus); } }
        }
        private long? m_idfsCaseStatus;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LabSampleListItem";

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
            var ret = base.Clone() as LabSampleListItem;
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
            var ret = base.Clone() as LabSampleListItem;
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
        public LabSampleListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabSampleListItem;
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
        
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfsSampleType_SampleType = idfsSampleType;
            var _prev_idfsSampleStatus_SampleStatus = idfsSampleStatus;
            var _prev_idfsCaseStatus_CaseStatus = idfsCaseStatus;
            var _prev_idfInDepartment_Department = idfInDepartment;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsSampleType_SampleType != idfsSampleType)
            {
                _SampleType = _SampleTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSampleType);
            }
            if (_prev_idfsSampleStatus_SampleStatus != idfsSampleStatus)
            {
                _SampleStatus = _SampleStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSampleStatus);
            }
            if (_prev_idfsCaseStatus_CaseStatus != idfsCaseStatus)
            {
                _CaseStatus = _CaseStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCaseStatus);
            }
            if (_prev_idfInDepartment_Department != idfInDepartment)
            {
                _Department = _DepartmentLookup.FirstOrDefault(c => c.idfDepartment == idfInDepartment);
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

        private bool IsRIRPropChanged(string fld, LabSampleListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public LabSampleListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabSampleListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabSampleListItem_PropertyChanged);
        }
        private void LabSampleListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabSampleListItem).Changed(e.PropertyName);
            
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
            LabSampleListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabSampleListItem obj = this;
            
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


        internal Dictionary<string, Func<LabSampleListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<LabSampleListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabSampleListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabSampleListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<LabSampleListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabSampleListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<LabSampleListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LabSampleListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftSampleType", this);
                
                LookupManager.RemoveObject("rftSampleStatus", this);
                
                LookupManager.RemoveObject("rftSampleStatus", this);
                
                LookupManager.RemoveObject("DepartmentLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftSampleType")
                _getAccessor().LoadLookup_SampleType(manager, this);
            
            if (lookup_object == "rftSampleStatus")
                _getAccessor().LoadLookup_SampleStatus(manager, this);
            
            if (lookup_object == "rftSampleStatus")
                _getAccessor().LoadLookup_CaseStatus(manager, this);
            
            if (lookup_object == "DepartmentLookup")
                _getAccessor().LoadLookup_Department(manager, this);
            
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
    
        #region Class for web grid
        public class LabSampleListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfMaterial { get; set; }
        
            public String strBarcode { get; set; }
        
            public String strFieldBarcode { get; set; }
        
            public DateTime? datAccession { get; set; }
        
            public String strSampleName { get; set; }
        
            public DateTime? datFieldCollectionDate { get; set; }
        
            public String DepartmentName { get; set; }
        
            public String CaseID { get; set; }
        
            public String DiagnosisName { get; set; }
        
            public String HumanName { get; set; }
        
            public String AnimalName { get; set; }
        
            public Int32 TestsCount { get; set; }
        
        }
        public partial class LabSampleListItemGridModelList : List<LabSampleListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public LabSampleListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabSampleListItem>, errMes);
            }
            public LabSampleListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabSampleListItem>, errMes);
            }
            public LabSampleListItemGridModelList(long key, IEnumerable<LabSampleListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public LabSampleListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<LabSampleListItem>(), null);
            }
            partial void filter(List<LabSampleListItem> items);
            private void LoadGridModelList(long key, IEnumerable<LabSampleListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strBarcode,_str_strFieldBarcode,_str_datAccession,_str_strSampleName,_str_datFieldCollectionDate,_str_DepartmentName,_str_CaseID,_str_DiagnosisName,_str_HumanName,_str_AnimalName,_str_TestsCount};
                    
                Hiddens = new List<string> {_str_idfMaterial};
                Keys = new List<string> {_str_idfMaterial};
                Labels = new Dictionary<string, string> {{_str_strBarcode, "strLabBarcode"},{_str_strFieldBarcode, _str_strFieldBarcode},{_str_datAccession, _str_datAccession},{_str_strSampleName, _str_strSampleName},{_str_datFieldCollectionDate, _str_datFieldCollectionDate},{_str_DepartmentName, _str_DepartmentName},{_str_CaseID, _str_CaseID},{_str_DiagnosisName, "idfsDiagnosis"},{_str_HumanName, _str_HumanName},{_str_AnimalName, _str_AnimalName},{_str_TestsCount, _str_TestsCount}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                LabSampleListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<LabSampleListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new LabSampleListItemGridModel()
                {
                    ItemKey=c.idfMaterial,strBarcode=c.strBarcode,strFieldBarcode=c.strFieldBarcode,datAccession=c.datAccession,strSampleName=c.strSampleName,datFieldCollectionDate=c.datFieldCollectionDate,DepartmentName=c.DepartmentName,CaseID=c.CaseID,DiagnosisName=c.DiagnosisName,HumanName=c.HumanName,AnimalName=c.AnimalName,TestsCount=c.TestsCount
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
        : DataAccessor<LabSampleListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<LabSampleListItem>
            
            , IObjectSelectList
            , IObjectSelectList<LabSampleListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfMaterial"; } }
            #endregion
        
            private delegate void on_action(LabSampleListItem obj);
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
            private BaseReference.Accessor SampleTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SampleStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CaseStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private DepartmentLookup.Accessor DepartmentAccessor { get { return eidss.model.Schema.DepartmentLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<LabSampleListItem> SelectListT(DbManagerProxy manager
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
            
            private List<LabSampleListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_Sample_SelectList.* from dbo.fn_Sample_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("idfsDiagnosis"))
                {
                    
                    sql.Append(" " + @"");
                      
                }
                
                if (filters.Contains("idfsCaseStatus"))
                {
                    
                    sql.Append(" " + @"");
                      
                }
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfsDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsDiagnosis") == 1)
                    {
                        sql.AppendFormat("(idfsShowDiagnosis = @idfsDiagnosis OR idfsTentativeDiagnosis = @idfsDiagnosis OR idfsTentativeDiagnosis1 = @idfsDiagnosis OR idfsTentativeDiagnosis2 = @idfsDiagnosis OR idfsFinalDiagnosis = @idfsDiagnosis OR (exists(select * from tlbMonitoringSessionToDiagnosis msd where msd.idfMonitoringSession = fn_Sample_SelectList.idfMonitoringSession and msd.idfsDiagnosis = @idfsDiagnosis and msd.intRowStatus = 0)))", filters.Operation("idfsDiagnosis"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsDiagnosis"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsDiagnosis") ? " or " : " and ");
                            sql.AppendFormat("(idfsShowDiagnosis = @idfsDiagnosis_{1} OR idfsTentativeDiagnosis = @idfsDiagnosis OR idfsTentativeDiagnosis1 = @idfsDiagnosis OR idfsTentativeDiagnosis2 = @idfsDiagnosis OR idfsFinalDiagnosis = @idfsDiagnosis OR (exists(select * from tlbMonitoringSessionToDiagnosis msd where msd.idfMonitoringSession = fn_Sample_SelectList.idfMonitoringSession and msd.idfsDiagnosis = @idfsDiagnosis and msd.intRowStatus = 0)))", filters.Operation("idfsDiagnosis", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsCaseStatus"))
                    sql.AppendFormat(" and " + new Func<string>(() => "((@idfsCaseStatus = 1 and idfMonitoringSession is not null) or (@idfsCaseStatus = 2 and idfCase is not null) or (@idfsCaseStatus = 3 and idfCase is null and idfMonitoringSession is null))")());
                            
                if (filters.Contains("idfMaterial"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfMaterial"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfMaterial") ? " or " : " and ");
                        
                        if (filters.Operation("idfMaterial", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.idfMaterial,0) {0} @idfMaterial_{1} = @idfMaterial_{1})", filters.Operation("idfMaterial", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.idfMaterial,0) {0} @idfMaterial_{1}", filters.Operation("idfMaterial", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFieldBarcode"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFieldBarcode"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFieldBarcode") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Sample_SelectList.strFieldBarcode {0} @strFieldBarcode_{1}", filters.Operation("strFieldBarcode", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strBarcode"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strBarcode"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strBarcode") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Sample_SelectList.strBarcode {0} @strBarcode_{1}", filters.Operation("strBarcode", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSampleStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSampleStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSampleStatus") ? " or " : " and ");
                        
                        if (filters.Operation("idfsSampleStatus", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.idfsSampleStatus,0) {0} @idfsSampleStatus_{1} = @idfsSampleStatus_{1})", filters.Operation("idfsSampleStatus", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.idfsSampleStatus,0) {0} @idfsSampleStatus_{1}", filters.Operation("idfsSampleStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfInDepartment"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfInDepartment"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfInDepartment") ? " or " : " and ");
                        
                        if (filters.Operation("idfInDepartment", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.idfInDepartment,0) {0} @idfInDepartment_{1} = @idfInDepartment_{1})", filters.Operation("idfInDepartment", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.idfInDepartment,0) {0} @idfInDepartment_{1}", filters.Operation("idfInDepartment", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSampleType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSampleType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSampleType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsSampleType", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.idfsSampleType,0) {0} @idfsSampleType_{1} = @idfsSampleType_{1})", filters.Operation("idfsSampleType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.idfsSampleType,0) {0} @idfsSampleType_{1}", filters.Operation("idfsSampleType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSampleName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSampleName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSampleName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Sample_SelectList.strSampleName {0} @strSampleName_{1}", filters.Operation("strSampleName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfCase"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfCase"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfCase") ? " or " : " and ");
                        
                        if (filters.Operation("idfCase", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.idfCase,0) {0} @idfCase_{1} = @idfCase_{1})", filters.Operation("idfCase", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.idfCase,0) {0} @idfCase_{1}", filters.Operation("idfCase", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfMonitoringSession"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfMonitoringSession"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfMonitoringSession") ? " or " : " and ");
                        
                        if (filters.Operation("idfMonitoringSession", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.idfMonitoringSession,0) {0} @idfMonitoringSession_{1} = @idfMonitoringSession_{1})", filters.Operation("idfMonitoringSession", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.idfMonitoringSession,0) {0} @idfMonitoringSession_{1}", filters.Operation("idfMonitoringSession", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfVectorSurveillanceSession"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfVectorSurveillanceSession"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfVectorSurveillanceSession") ? " or " : " and ");
                        
                        if (filters.Operation("idfVectorSurveillanceSession", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.idfVectorSurveillanceSession,0) {0} @idfVectorSurveillanceSession_{1} = @idfVectorSurveillanceSession_{1})", filters.Operation("idfVectorSurveillanceSession", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.idfVectorSurveillanceSession,0) {0} @idfVectorSurveillanceSession_{1}", filters.Operation("idfVectorSurveillanceSession", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSpeciesType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSpeciesType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSpeciesType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsSpeciesType", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.idfsSpeciesType,0) {0} @idfsSpeciesType_{1} = @idfsSpeciesType_{1})", filters.Operation("idfsSpeciesType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.idfsSpeciesType,0) {0} @idfsSpeciesType_{1}", filters.Operation("idfsSpeciesType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("CaseID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("CaseID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("CaseID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Sample_SelectList.CaseID {0} @CaseID_{1}", filters.Operation("CaseID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCaseType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCaseType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCaseType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsCaseType", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.idfsCaseType,0) {0} @idfsCaseType_{1} = @idfsCaseType_{1})", filters.Operation("idfsCaseType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.idfsCaseType,0) {0} @idfsCaseType_{1}", filters.Operation("idfsCaseType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datFieldCollectionDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datFieldCollectionDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datFieldCollectionDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_Sample_SelectList.datFieldCollectionDate, 112) {0} CONVERT(NVARCHAR(8), @datFieldCollectionDate_{1}, 112)", filters.Operation("datFieldCollectionDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsShowDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsShowDiagnosis"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsShowDiagnosis") ? " or " : " and ");
                        
                        if (filters.Operation("idfsShowDiagnosis", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.idfsShowDiagnosis,0) {0} @idfsShowDiagnosis_{1} = @idfsShowDiagnosis_{1})", filters.Operation("idfsShowDiagnosis", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.idfsShowDiagnosis,0) {0} @idfsShowDiagnosis_{1}", filters.Operation("idfsShowDiagnosis", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsTentativeDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsTentativeDiagnosis"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsTentativeDiagnosis") ? " or " : " and ");
                        
                        if (filters.Operation("idfsTentativeDiagnosis", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.idfsTentativeDiagnosis,0) {0} @idfsTentativeDiagnosis_{1} = @idfsTentativeDiagnosis_{1})", filters.Operation("idfsTentativeDiagnosis", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.idfsTentativeDiagnosis,0) {0} @idfsTentativeDiagnosis_{1}", filters.Operation("idfsTentativeDiagnosis", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsTentativeDiagnosis1"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsTentativeDiagnosis1"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsTentativeDiagnosis1") ? " or " : " and ");
                        
                        if (filters.Operation("idfsTentativeDiagnosis1", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.idfsTentativeDiagnosis1,0) {0} @idfsTentativeDiagnosis1_{1} = @idfsTentativeDiagnosis1_{1})", filters.Operation("idfsTentativeDiagnosis1", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.idfsTentativeDiagnosis1,0) {0} @idfsTentativeDiagnosis1_{1}", filters.Operation("idfsTentativeDiagnosis1", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsTentativeDiagnosis2"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsTentativeDiagnosis2"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsTentativeDiagnosis2") ? " or " : " and ");
                        
                        if (filters.Operation("idfsTentativeDiagnosis2", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.idfsTentativeDiagnosis2,0) {0} @idfsTentativeDiagnosis2_{1} = @idfsTentativeDiagnosis2_{1})", filters.Operation("idfsTentativeDiagnosis2", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.idfsTentativeDiagnosis2,0) {0} @idfsTentativeDiagnosis2_{1}", filters.Operation("idfsTentativeDiagnosis2", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsFinalDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsFinalDiagnosis"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsFinalDiagnosis") ? " or " : " and ");
                        
                        if (filters.Operation("idfsFinalDiagnosis", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.idfsFinalDiagnosis,0) {0} @idfsFinalDiagnosis_{1} = @idfsFinalDiagnosis_{1})", filters.Operation("idfsFinalDiagnosis", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.idfsFinalDiagnosis,0) {0} @idfsFinalDiagnosis_{1}", filters.Operation("idfsFinalDiagnosis", i), i);
                            
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
                        
                        sql.AppendFormat("fn_Sample_SelectList.DiagnosisName {0} @DiagnosisName_{1}", filters.Operation("DiagnosisName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strNationalName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strNationalName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strNationalName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Sample_SelectList.strNationalName {0} @strNationalName_{1}", filters.Operation("strNationalName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("DepartmentName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("DepartmentName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("DepartmentName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Sample_SelectList.DepartmentName {0} @DepartmentName_{1}", filters.Operation("DepartmentName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("HumanName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("HumanName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("HumanName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Sample_SelectList.HumanName {0} @HumanName_{1}", filters.Operation("HumanName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("AnimalName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("AnimalName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("AnimalName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Sample_SelectList.AnimalName {0} @AnimalName_{1}", filters.Operation("AnimalName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("Path"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("Path"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("Path") ? " or " : " and ");
                        
                        if (filters.Operation("Path", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.Path,0) {0} @Path_{1} = @Path_{1})", filters.Operation("Path", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.Path,0) {0} @Path_{1}", filters.Operation("Path", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("TestsCount"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("TestsCount"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("TestsCount") ? " or " : " and ");
                        
                        if (filters.Operation("TestsCount", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.TestsCount,0) {0} @TestsCount_{1} = @TestsCount_{1})", filters.Operation("TestsCount", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.TestsCount,0) {0} @TestsCount_{1}", filters.Operation("TestsCount", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("HACode"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("HACode"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("HACode") ? " or " : " and ");
                        
                        if (filters.Operation("HACode", i) == "&")
                          sql.AppendFormat("(isnull(fn_Sample_SelectList.HACode,0) {0} @HACode_{1} = @HACode_{1})", filters.Operation("HACode", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Sample_SelectList.HACode,0) {0} @HACode_{1}", filters.Operation("HACode", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datAccession"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datAccession"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datAccession") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_Sample_SelectList.datAccession, 112) {0} CONVERT(NVARCHAR(8), @datAccession_{1}, 112)", filters.Operation("datAccession", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strPatientName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strPatientName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strPatientName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Sample_SelectList.strPatientName {0} @strPatientName_{1}", filters.Operation("strPatientName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFarmOwner"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFarmOwner"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFarmOwner") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Sample_SelectList.strFarmOwner {0} @strFarmOwner_{1}", filters.Operation("strFarmOwner", i), i);
                            
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
                    
                    sql.Append(" option (OPTIMIZE FOR UNKNOWN)");
                    manager
                        .SetCommand(sql.ToString()
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                        );
                    
                    if (filters.Contains("idfsDiagnosis"))
                        
                        if (filters.Count("idfsDiagnosis") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosis", ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosis"), filters.Value("idfsDiagnosis"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsDiagnosis"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosis", i), filters.Value("idfsDiagnosis", i))));
                        }
                            
                    if (filters.Contains("idfsCaseStatus"))
                        
                        if (filters.Count("idfsCaseStatus") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseStatus", ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseStatus"), filters.Value("idfsCaseStatus"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsCaseStatus"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseStatus", i), filters.Value("idfsCaseStatus", i))));
                        }
                            
                    if (filters.Contains("idfMaterial"))
                        for (int i = 0; i < filters.Count("idfMaterial"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfMaterial_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfMaterial", i), filters.Value("idfMaterial", i))));
                      
                    if (filters.Contains("strFieldBarcode"))
                        for (int i = 0; i < filters.Count("strFieldBarcode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFieldBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFieldBarcode", i), filters.Value("strFieldBarcode", i))));
                      
                    if (filters.Contains("strBarcode"))
                        for (int i = 0; i < filters.Count("strBarcode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strBarcode", i), filters.Value("strBarcode", i))));
                      
                    if (filters.Contains("idfsSampleStatus"))
                        for (int i = 0; i < filters.Count("idfsSampleStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSampleStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSampleStatus", i), filters.Value("idfsSampleStatus", i))));
                      
                    if (filters.Contains("idfInDepartment"))
                        for (int i = 0; i < filters.Count("idfInDepartment"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfInDepartment_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfInDepartment", i), filters.Value("idfInDepartment", i))));
                      
                    if (filters.Contains("idfsSampleType"))
                        for (int i = 0; i < filters.Count("idfsSampleType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSampleType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSampleType", i), filters.Value("idfsSampleType", i))));
                      
                    if (filters.Contains("strSampleName"))
                        for (int i = 0; i < filters.Count("strSampleName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSampleName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSampleName", i), filters.Value("strSampleName", i))));
                      
                    if (filters.Contains("idfCase"))
                        for (int i = 0; i < filters.Count("idfCase"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfCase_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfCase", i), filters.Value("idfCase", i))));
                      
                    if (filters.Contains("idfMonitoringSession"))
                        for (int i = 0; i < filters.Count("idfMonitoringSession"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfMonitoringSession_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfMonitoringSession", i), filters.Value("idfMonitoringSession", i))));
                      
                    if (filters.Contains("idfVectorSurveillanceSession"))
                        for (int i = 0; i < filters.Count("idfVectorSurveillanceSession"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfVectorSurveillanceSession_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfVectorSurveillanceSession", i), filters.Value("idfVectorSurveillanceSession", i))));
                      
                    if (filters.Contains("idfsSpeciesType"))
                        for (int i = 0; i < filters.Count("idfsSpeciesType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSpeciesType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSpeciesType", i), filters.Value("idfsSpeciesType", i))));
                      
                    if (filters.Contains("CaseID"))
                        for (int i = 0; i < filters.Count("CaseID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@CaseID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("CaseID", i), filters.Value("CaseID", i))));
                      
                    if (filters.Contains("idfsCaseType"))
                        for (int i = 0; i < filters.Count("idfsCaseType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseType", i), filters.Value("idfsCaseType", i))));
                      
                    if (filters.Contains("datFieldCollectionDate"))
                        for (int i = 0; i < filters.Count("datFieldCollectionDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datFieldCollectionDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datFieldCollectionDate", i), filters.Value("datFieldCollectionDate", i))));
                      
                    if (filters.Contains("idfsShowDiagnosis"))
                        for (int i = 0; i < filters.Count("idfsShowDiagnosis"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsShowDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsShowDiagnosis", i), filters.Value("idfsShowDiagnosis", i))));
                      
                    if (filters.Contains("idfsTentativeDiagnosis"))
                        for (int i = 0; i < filters.Count("idfsTentativeDiagnosis"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTentativeDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTentativeDiagnosis", i), filters.Value("idfsTentativeDiagnosis", i))));
                      
                    if (filters.Contains("idfsTentativeDiagnosis1"))
                        for (int i = 0; i < filters.Count("idfsTentativeDiagnosis1"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTentativeDiagnosis1_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTentativeDiagnosis1", i), filters.Value("idfsTentativeDiagnosis1", i))));
                      
                    if (filters.Contains("idfsTentativeDiagnosis2"))
                        for (int i = 0; i < filters.Count("idfsTentativeDiagnosis2"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTentativeDiagnosis2_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTentativeDiagnosis2", i), filters.Value("idfsTentativeDiagnosis2", i))));
                      
                    if (filters.Contains("idfsFinalDiagnosis"))
                        for (int i = 0; i < filters.Count("idfsFinalDiagnosis"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsFinalDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsFinalDiagnosis", i), filters.Value("idfsFinalDiagnosis", i))));
                      
                    if (filters.Contains("DiagnosisName"))
                        for (int i = 0; i < filters.Count("DiagnosisName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@DiagnosisName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("DiagnosisName", i), filters.Value("DiagnosisName", i))));
                      
                    if (filters.Contains("strNationalName"))
                        for (int i = 0; i < filters.Count("strNationalName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strNationalName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strNationalName", i), filters.Value("strNationalName", i))));
                      
                    if (filters.Contains("DepartmentName"))
                        for (int i = 0; i < filters.Count("DepartmentName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@DepartmentName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("DepartmentName", i), filters.Value("DepartmentName", i))));
                      
                    if (filters.Contains("HumanName"))
                        for (int i = 0; i < filters.Count("HumanName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@HumanName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("HumanName", i), filters.Value("HumanName", i))));
                      
                    if (filters.Contains("AnimalName"))
                        for (int i = 0; i < filters.Count("AnimalName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@AnimalName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("AnimalName", i), filters.Value("AnimalName", i))));
                      
                    if (filters.Contains("Path"))
                        for (int i = 0; i < filters.Count("Path"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@Path_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("Path", i), filters.Value("Path", i))));
                      
                    if (filters.Contains("TestsCount"))
                        for (int i = 0; i < filters.Count("TestsCount"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@TestsCount_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("TestsCount", i), filters.Value("TestsCount", i))));
                      
                    if (filters.Contains("HACode"))
                        for (int i = 0; i < filters.Count("HACode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@HACode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("HACode", i), filters.Value("HACode", i))));
                      
                    if (filters.Contains("datAccession"))
                        for (int i = 0; i < filters.Count("datAccession"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datAccession_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datAccession", i), filters.Value("datAccession", i))));
                      
                    if (filters.Contains("strPatientName"))
                        for (int i = 0; i < filters.Count("strPatientName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strPatientName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strPatientName", i), filters.Value("strPatientName", i))));
                      
                    if (filters.Contains("strFarmOwner"))
                        for (int i = 0; i < filters.Count("strFarmOwner"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFarmOwner_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFarmOwner", i), filters.Value("strFarmOwner", i))));
                      
                    List<LabSampleListItem> objs = manager.ExecuteList<LabSampleListItem>();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                    }
                    ListSelected(manager, objs);
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
            partial void ListSelected(DbManagerProxy manager, List<LabSampleListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spLabSample_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabSampleListItem obj, bool bCloning = false)
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
              obj.CaseStatusLookup.AddRange(CaseStatusLookupTemplate);
            
                obj.CaseStatus = new Func<LabSampleListItem, BaseReference>(c => c.CaseStatusLookup.FirstOrDefault(i => i.idfsBaseReference == 2))(obj);
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, LabSampleListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabSampleListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    LabSampleListItem obj = LabSampleListItem.CreateInstance();
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
                obj.SampleStatus = new Func<LabSampleListItem, BaseReference>(c => 
                                     c.SampleStatusLookup.FirstOrDefault(a => a.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.Accessioned))(obj);
              obj.CaseStatusLookup.AddRange(CaseStatusLookupTemplate);
            
                obj.CaseStatus = new Func<LabSampleListItem, BaseReference>(c => c.CaseStatusLookup.FirstOrDefault(i => i.idfsBaseReference == 2))(obj);
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

            
            public LabSampleListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public LabSampleListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public LabSampleListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult SelectTest(DbManagerProxy manager, LabSampleListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is object)) 
                    throw new TypeMismatchException("key", typeof(object));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return SelectTest(manager, obj
                    , (object)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult SelectTest(DbManagerProxy manager, LabSampleListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("SelectTest"))
                    throw new PermissionException("Sample", "SelectTest");
                
                return true;
                
            }
            
      
            public ActResult MarkForDisposition(DbManagerProxy manager, LabSampleListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is object)) 
                    throw new TypeMismatchException("key", typeof(object));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return MarkForDisposition(manager, obj
                    , (object)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult MarkForDisposition(DbManagerProxy manager, LabSampleListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MarkForDisposition"))
                    throw new PermissionException("Sample", "MarkForDisposition");
                
                return true;
                
            }
            
      
            public ActResult DeleteSample(DbManagerProxy manager, LabSampleListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is object)) 
                    throw new TypeMismatchException("key", typeof(object));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return DeleteSample(manager, obj
                    , (object)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult DeleteSample(DbManagerProxy manager, LabSampleListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("DeleteSample"))
                    throw new PermissionException("Sample", "DeleteSample");
                
              manager.SetSpCommand("dbo.spLabSample_SetDeletedStatus"
              , manager.Parameter("idfMaterial", key)
              ).ExecuteNonQuery();
              return true;
            
            }
            
      
            public ActResult TransferOut(DbManagerProxy manager, LabSampleListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is object)) 
                    throw new TypeMismatchException("key", typeof(object));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return TransferOut(manager, obj
                    , (object)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult TransferOut(DbManagerProxy manager, LabSampleListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("TransferOut"))
                    throw new PermissionException("Sample", "TransferOut");
                
                return true;
                
            }
            
      
            public ActResult AliquotsDerivatives(DbManagerProxy manager, LabSampleListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is object)) 
                    throw new TypeMismatchException("key", typeof(object));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return AliquotsDerivatives(manager, obj
                    , (object)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult AliquotsDerivatives(DbManagerProxy manager, LabSampleListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("AliquotsDerivatives"))
                    throw new PermissionException("Sample", "AliquotsDerivatives");
                
                return true;
                
            }
            
      
            public ActResult HumanAccessionIn(DbManagerProxy manager, LabSampleListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is object)) 
                    throw new TypeMismatchException("key", typeof(object));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return HumanAccessionIn(manager, obj
                    , (object)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult HumanAccessionIn(DbManagerProxy manager, LabSampleListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("HumanAccessionIn"))
                    throw new PermissionException("Sample", "HumanAccessionIn");
                
                return true;
                
            }
            
      
            public ActResult VetAccessionIn(DbManagerProxy manager, LabSampleListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is object)) 
                    throw new TypeMismatchException("key", typeof(object));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return VetAccessionIn(manager, obj
                    , (object)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult VetAccessionIn(DbManagerProxy manager, LabSampleListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("VetAccessionIn"))
                    throw new PermissionException("Sample", "VetAccessionIn");
                
                return true;
                
            }
            
      
            public ActResult AsAccessionIn(DbManagerProxy manager, LabSampleListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is object)) 
                    throw new TypeMismatchException("key", typeof(object));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return AsAccessionIn(manager, obj
                    , (object)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult AsAccessionIn(DbManagerProxy manager, LabSampleListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("AsAccessionIn"))
                    throw new PermissionException("Sample", "AsAccessionIn");
                
                return true;
                
            }
            
      
            public ActResult VsAccessionIn(DbManagerProxy manager, LabSampleListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is object)) 
                    throw new TypeMismatchException("key", typeof(object));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return VsAccessionIn(manager, obj
                    , (object)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult VsAccessionIn(DbManagerProxy manager, LabSampleListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("VsAccessionIn"))
                    throw new PermissionException("Sample", "VsAccessionIn");
                
                return true;
                
            }
            
      
            public ActResult GroupAccessionIn(DbManagerProxy manager, LabSampleListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is object)) 
                    throw new TypeMismatchException("key", typeof(object));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return GroupAccessionIn(manager, obj
                    , (object)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult GroupAccessionIn(DbManagerProxy manager, LabSampleListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("GroupAccessionIn"))
                    throw new PermissionException("Sample", "GroupAccessionIn");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(LabSampleListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabSampleListItem obj)
            {
                
            }
    
            public void LoadLookup_Diagnosis(DbManagerProxy manager, LabSampleListItem obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)eidss.model.Enums.HACode.All) != 0))
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase))
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != null && obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosis);
                    
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_SampleType(DbManagerProxy manager, LabSampleListItem obj)
            {
                
                obj.SampleTypeLookup.Clear();
                
                obj.SampleTypeLookup.Add(SampleTypeAccessor.CreateNewT(manager, null));
                
                obj.SampleTypeLookup.AddRange(SampleTypeAccessor.rftSampleType_SelectList(manager
                    
                    )
                    .Where(c => c.idfsBaseReference != (long)SampleTypeEnum.Unknown)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSampleType))
                    
                    .ToList());
                
                if (obj.idfsSampleType != 0)
                {
                    obj.SampleType = obj.SampleTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsSampleType);
                    
                }
              
                
                LookupManager.AddObject("rftSampleType", obj, SampleTypeAccessor.GetType(), "rftSampleType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_SampleStatus(DbManagerProxy manager, LabSampleListItem obj)
            {
                
                obj.SampleStatusLookup.Clear();
                
                obj.SampleStatusLookup.Add(SampleStatusAccessor.CreateNewT(manager, null));
                
                obj.SampleStatusLookup.AddRange(SampleStatusAccessor.rftSampleStatus_SelectList(manager
                    
                    )
                    .Where(c=>c.idfsBaseReference != (long)eidss.model.Enums.SampleStatus.IsDeleted && c.idfsBaseReference != (long)eidss.model.Enums.SampleStatus.Delete)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSampleStatus))
                    
                    .ToList());
                
                if (obj.idfsSampleStatus != null && obj.idfsSampleStatus != 0)
                {
                    obj.SampleStatus = obj.SampleStatusLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsSampleStatus);
                    
                }
              
                
                LookupManager.AddObject("rftSampleStatus", obj, SampleStatusAccessor.GetType(), "rftSampleStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_CaseStatus(DbManagerProxy manager, LabSampleListItem obj)
            {
                
                obj.CaseStatusLookup.Clear();
                
                obj.CaseStatusLookup.Add(CaseStatusAccessor.CreateNewT(manager, null));
                
                obj.CaseStatusLookup.AddRange(CaseStatusAccessor.rftSampleStatus_SelectList(manager
                    
                    )
                    .Where(c=>c.idfsBaseReference == 0)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCaseStatus))
                    
                    .ToList());
                
                if (obj.idfsCaseStatus != null && obj.idfsCaseStatus != 0)
                {
                    obj.CaseStatus = obj.CaseStatusLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsCaseStatus);
                    
                }
              
                
                LookupManager.AddObject("rftSampleStatus", obj, CaseStatusAccessor.GetType(), "rftSampleStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Department(DbManagerProxy manager, LabSampleListItem obj)
            {
                
                obj.DepartmentLookup.Clear();
                
                obj.DepartmentLookup.Add(DepartmentAccessor.CreateNewT(manager, null));
                
                obj.DepartmentLookup.AddRange(DepartmentAccessor.SelectLookupList(manager
                    
                    , new Func<LabSampleListItem, long>(c => eidss.model.Core.EidssSiteContext.Instance.OrganizationID)(obj)
                            
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
            

            private void _LoadLookups(DbManagerProxy manager, LabSampleListItem obj)
            {
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_SampleType(manager, obj);
                
                LoadLookup_SampleStatus(manager, obj);
                
                LoadLookup_CaseStatus(manager, obj);
                
                LoadLookup_Department(manager, obj);
                
            }
    
            [SprocName("spLabSample_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? idfMaterial
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? idfMaterial
                )
            {
                
                _postDelete(manager, idfMaterial);
                
            }
        
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    LabSampleListItem bo = obj as LabSampleListItem;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as LabSampleListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, LabSampleListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfMaterial
                        );
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(LabSampleListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, LabSampleListItem obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(LabSampleListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(LabSampleListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as LabSampleListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabSampleListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
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
            
            private void _SetupRequired(LabSampleListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LabSampleListItem obj)
    {
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName))
      {
      
            obj
              .AddHiddenPersonalData("strPatientName", c=>true);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement))
      {
      
            obj
              .AddHiddenPersonalData("strFarmOwner", c=>true);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details))
      {
      
            obj
              .AddHiddenPersonalData("strFarmOwner", c=>true);
            
      }
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabSampleListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabSampleListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabSampleListItemDetail"; } }
            public string HelpIdWin { get { return "lab_l01"; } }
            public string HelpIdWeb { get { return "lab_l01"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private LabSampleListItem m_obj;
            internal Permissions(LabSampleListItem obj)
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
            public static string spSelect = "fn_Sample_SelectList";
            public static string spCount = "spLabSample_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spLabSample_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabSampleListItem, bool>> RequiredByField = new Dictionary<string, Func<LabSampleListItem, bool>>();
            public static Dictionary<string, Func<LabSampleListItem, bool>> RequiredByProperty = new Dictionary<string, Func<LabSampleListItem, bool>>();
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
                
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strSampleName, 2000);
                Sizes.Add(_str_CaseID, 200);
                Sizes.Add(_str_DiagnosisName, 2000);
                Sizes.Add(_str_strNationalName, 200);
                Sizes.Add(_str_DepartmentName, 2000);
                Sizes.Add(_str_HumanName, 700);
                Sizes.Add(_str_AnimalName, 2000);
                Sizes.Add(_str_strPatientName, 700);
                Sizes.Add(_str_strFarmOwner, 700);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "CaseID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "CaseID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFieldBarcode",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strFieldBarcode",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsDiagnosis",
                    EditorType.Lookup,
                    EditorControlWidth.Large, true, true, false, false, 
                    "idfsDiagnosis",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, "DiagnosisLookup", typeof(DiagnosisLookup), (o) => { var c = (DiagnosisLookup)o; return c.idfsDiagnosis; }, (o) => { var c = (DiagnosisLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSampleType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "SampleType",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "SampleTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strBarcode",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strLabBarcode",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strPatientName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strHumanPatientName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFarmOwner",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strFarmOwnerName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datFieldCollectionDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datFieldCollectionDate",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datAccession",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datAccession",
                    c => DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter), null, c => true, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfInDepartment",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "DepartmentName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "DepartmentLookup", typeof(DepartmentLookup), (o) => { var c = (DepartmentLookup)o; return c.idfDepartment; }, (o) => { var c = (DepartmentLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSampleStatus",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsSampleStatus",
                    null, null, c => true, false, SearchPanelLocation.Main, false, null, "SampleStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsCaseStatus",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "LabCaseStatus",
                    null, null, c => true, false, SearchPanelLocation.Main, true, null, "CaseStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "TestsCount",
                    EditorType.Numeric,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "TestsCount",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfMaterial,
                    _str_idfMaterial, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBarcode,
                    "strLabBarcode", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode,
                    _str_strFieldBarcode, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datAccession,
                    _str_datAccession, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSampleName,
                    _str_strSampleName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldCollectionDate,
                    _str_datFieldCollectionDate, null, true, true, true, true, ListSortDirection.Descending
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DepartmentName,
                    _str_DepartmentName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_CaseID,
                    _str_CaseID, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DiagnosisName,
                    "idfsDiagnosis", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_HumanName,
                    _str_HumanName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalName,
                    _str_AnimalName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestsCount,
                    _str_TestsCount, null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "SelectTest",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).SelectTest(manager, (LabSampleListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelectTest_Id",
                        "Select_Tests__small_",
                        /*from BvMessages*/"strSelectTest_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    "Test.Insert",
                    null,
                    (c, p, b) => c != null && ((long)(eidss.model.Enums.SampleStatus.Accessioned)).Equals(c.GetValue("idfsSampleStatus")),
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Destroy",
                    ActionTypes.Container,
                    true,
                    "",
                    "",
                    
                    null,
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDestroySample_Id",
                        "Sample_Disposition__small_",
                        /*from BvMessages*/"strDestroySample_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    "Sample.Delete",
                    null,
                    (c, p, b) => c != null,
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MarkForDisposition",
                    ActionTypes.Action,
                    true,
                    "LabSampleDispositionListItem,LabSampleListItem",
                    "Destroy",
                    
                    (manager, c, pars) => Accessor.Instance(null).MarkForDisposition(manager, (LabSampleListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strMarkForDisposition_Id",
                        "Sample_Disposition__small_",
                        /*from BvMessages*/"strMarkForDisposition_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    "Sample.Delete",
                    null,
                    (c, p, b) => c != null && ((long)(eidss.model.Enums.SampleStatus.Accessioned)).Equals(c.GetValue("idfsSampleStatus")),
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "DeleteSample",
                    ActionTypes.Action,
                    true,
                    "LabSampleListItem",
                    "Destroy",
                    
                    (manager, c, pars) => Accessor.Instance(null).DeleteSample(manager, (LabSampleListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDeleteSample_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"strDeleteSample_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    "Sample.Delete",
                    null,
                    (c, p, b) => c != null && ((long)(eidss.model.Enums.SampleStatus.Accessioned)).Equals(c.GetValue("idfsSampleStatus")),
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "TransferOut",
                    ActionTypes.Action,
                    true,
                    "LabSampleTransferListItem,LabSampleListItem",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).TransferOut(manager, (LabSampleListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strTransferOut_Id",
                        "Sample_Transfer_Out__small_",
                        /*from BvMessages*/"strTransferOut_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    "SampleTransfer.Execute",
                    null,
                    (c, p, b) => c != null && ((long)(eidss.model.Enums.SampleStatus.Accessioned)).Equals(c.GetValue("idfsSampleStatus")),
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "AliquotsDerivatives",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).AliquotsDerivatives(manager, (LabSampleListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strAliquotsDerivatives_Id",
                        "Aliquots_Derivatives__small_",
                        /*from BvMessages*/"strAliquotsDerivatives_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    "Sample.Insert",
                    null,
                    (c, p, b) => c != null && ((long)(eidss.model.Enums.SampleStatus.Accessioned)).Equals(c.GetValue("idfsSampleStatus")),
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "AccessionIn",
                    ActionTypes.Container,
                    true,
                    "",
                    "",
                    
                    null,
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleAccessionIn",
                        "Sample_Accession__small_",
                        /*from BvMessages*/"titleAccessionIn",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    () => 
                        EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.AccessionIn1)) &&
                        (EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase))
                        || EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase))
                        || EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.MonitoringSession))
                        || EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VsSession)))
                        ,
                    null,
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "HumanAccessionIn",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem",
                    "AccessionIn",
                    
                    (manager, c, pars) => Accessor.Instance(null).HumanAccessionIn(manager, (LabSampleListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleHumanAccessionIn",
                        "Search_Human_Case_in_Browse_Mode__small_1",
                        /*from BvMessages*/"titleHumanAccessionIn",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    () => 
                        EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.AccessionIn1)) &&
                        EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase)),
                    null,
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "VetAccessionIn",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem",
                    "AccessionIn",
                    
                    (manager, c, pars) => Accessor.Instance(null).VetAccessionIn(manager, (LabSampleListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleVetAccessionIn",
                        "Search_Vet_Case__small_2",
                        /*from BvMessages*/"titleVetAccessionIn",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    () => 
                        EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.AccessionIn1)) &&
                        EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase)),
                    null,
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "AsAccessionIn",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem",
                    "AccessionIn",
                    
                    (manager, c, pars) => Accessor.Instance(null).AsAccessionIn(manager, (LabSampleListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleASAccessionIn",
                        "Active_Surveillance_Session_small",
                        /*from BvMessages*/"titleASAccessionIn",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    () => 
                        EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.AccessionIn1)) &&
                        EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.MonitoringSession)),
                    null,
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "VsAccessionIn",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem",
                    "AccessionIn",
                    
                    (manager, c, pars) => Accessor.Instance(null).VsAccessionIn(manager, (LabSampleListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleVsAccessionIn",
                        "Vector_Surveillance_Sessions_List__small__04_",
                        /*from BvMessages*/"titleVsAccessionIn",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    () => 
                        EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.AccessionIn1)) &&
                        EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VsSession)),
                    null,
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "GroupAccessionIn",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem",
                    "AccessionIn",
                    
                    (manager, c, pars) => Accessor.Instance(null).GroupAccessionIn(manager, (LabSampleListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleGroupAccessionIn",
                        "Sample_Accession__small_",
                        /*from BvMessages*/"titleGroupAccessionIn",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    "AccessionIn1.Execute",
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
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
                    "Edit",
                    ActionTypes.Edit,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<LabSample>().SelectDetail(manager, pars[0])),
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
                    
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    
        AddHiddenPersonalData("strPatientName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName));
      
        AddHiddenPersonalData("strFarmOwner", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("strFarmOwner", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      

    }
  
        }
        #endregion
    

        #endregion
        }
    
}
	