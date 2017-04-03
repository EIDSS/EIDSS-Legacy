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
        
        [MapField(_str_idfContainer), NonUpdatable, PrimaryKey]
        public abstract Int64 idfContainer { get; set; }
                
        [LocalizedDisplayName(_str_strFieldBarcode)]
        [MapField(_str_strFieldBarcode)]
        public abstract String strFieldBarcode { get; set; }
        #if MONO
        protected String strFieldBarcode_Original { get { return strFieldBarcode; } }
        protected String strFieldBarcode_Previous { get { return strFieldBarcode; } }
        #else
        protected String strFieldBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).OriginalValue; } }
        protected String strFieldBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfMaterial)]
        [MapField(_str_idfMaterial)]
        public abstract Int64 idfMaterial { get; set; }
        #if MONO
        protected Int64 idfMaterial_Original { get { return idfMaterial; } }
        protected Int64 idfMaterial_Previous { get { return idfMaterial; } }
        #else
        protected Int64 idfMaterial_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfMaterial).OriginalValue; } }
        protected Int64 idfMaterial_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfMaterial).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfInDepartment)]
        [MapField(_str_idfInDepartment)]
        public abstract Int64? idfInDepartment { get; set; }
        #if MONO
        protected Int64? idfInDepartment_Original { get { return idfInDepartment; } }
        protected Int64? idfInDepartment_Previous { get { return idfInDepartment; } }
        #else
        protected Int64? idfInDepartment_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInDepartment).OriginalValue; } }
        protected Int64? idfInDepartment_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInDepartment).PreviousValue; } }
        #endif
                
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
                
        [LocalizedDisplayName(_str_CaseID)]
        [MapField(_str_CaseID)]
        public abstract String CaseID { get; set; }
        #if MONO
        protected String CaseID_Original { get { return CaseID; } }
        protected String CaseID_Previous { get { return CaseID; } }
        #else
        protected String CaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._caseID).OriginalValue; } }
        protected String CaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._caseID).PreviousValue; } }
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
                
        [LocalizedDisplayName("idfsDiagnosis")]
        [MapField(_str_DiagnosisName)]
        public abstract String DiagnosisName { get; set; }
        #if MONO
        protected String DiagnosisName_Original { get { return DiagnosisName; } }
        protected String DiagnosisName_Previous { get { return DiagnosisName; } }
        #else
        protected String DiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).OriginalValue; } }
        protected String DiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_DepartmentName)]
        [MapField(_str_DepartmentName)]
        public abstract String DepartmentName { get; set; }
        #if MONO
        protected String DepartmentName_Original { get { return DepartmentName; } }
        protected String DepartmentName_Previous { get { return DepartmentName; } }
        #else
        protected String DepartmentName_Original { get { return ((EditableValue<String>)((dynamic)this)._departmentName).OriginalValue; } }
        protected String DepartmentName_Previous { get { return ((EditableValue<String>)((dynamic)this)._departmentName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_HumanName)]
        [MapField(_str_HumanName)]
        public abstract String HumanName { get; set; }
        #if MONO
        protected String HumanName_Original { get { return HumanName; } }
        protected String HumanName_Previous { get { return HumanName; } }
        #else
        protected String HumanName_Original { get { return ((EditableValue<String>)((dynamic)this)._humanName).OriginalValue; } }
        protected String HumanName_Previous { get { return ((EditableValue<String>)((dynamic)this)._humanName).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_Path)]
        [MapField(_str_Path)]
        public abstract Int32? Path { get; set; }
        #if MONO
        protected Int32? Path_Original { get { return Path; } }
        protected Int32? Path_Previous { get { return Path; } }
        #else
        protected Int32? Path_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._path).OriginalValue; } }
        protected Int32? Path_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._path).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_TestsCount)]
        [MapField(_str_TestsCount)]
        public abstract Int32 TestsCount { get; set; }
        #if MONO
        protected Int32 TestsCount_Original { get { return TestsCount; } }
        protected Int32 TestsCount_Previous { get { return TestsCount; } }
        #else
        protected Int32 TestsCount_Original { get { return ((EditableValue<Int32>)((dynamic)this)._testsCount).OriginalValue; } }
        protected Int32 TestsCount_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._testsCount).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_HACode)]
        [MapField(_str_HACode)]
        public abstract Int32? HACode { get; set; }
        #if MONO
        protected Int32? HACode_Original { get { return HACode; } }
        protected Int32? HACode_Previous { get { return HACode; } }
        #else
        protected Int32? HACode_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._hACode).OriginalValue; } }
        protected Int32? HACode_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._hACode).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strPatientName)]
        [MapField(_str_strPatientName)]
        public abstract String strPatientName { get; set; }
        #if MONO
        protected String strPatientName_Original { get { return strPatientName; } }
        protected String strPatientName_Previous { get { return strPatientName; } }
        #else
        protected String strPatientName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPatientName).OriginalValue; } }
        protected String strPatientName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPatientName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strFarmOwner)]
        [MapField(_str_strFarmOwner)]
        public abstract String strFarmOwner { get; set; }
        #if MONO
        protected String strFarmOwner_Original { get { return strFarmOwner; } }
        protected String strFarmOwner_Previous { get { return strFarmOwner; } }
        #else
        protected String strFarmOwner_Original { get { return ((EditableValue<String>)((dynamic)this)._strFarmOwner).OriginalValue; } }
        protected String strFarmOwner_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFarmOwner).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<LabSampleListItem, object> _get_func;
            internal Action<LabSampleListItem, string> _set_func;
            internal Action<LabSampleListItem, LabSampleListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfContainer = "idfContainer";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_idfsContainerStatus = "idfsContainerStatus";
        internal const string _str_idfInDepartment = "idfInDepartment";
        internal const string _str_idfsSpecimenType = "idfsSpecimenType";
        internal const string _str_SpecimenType = "SpecimenType";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfsSpeciesType = "idfsSpeciesType";
        internal const string _str_CaseID = "CaseID";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_idfsShowDiagnosis = "idfsShowDiagnosis";
        internal const string _str_DiagnosisName = "DiagnosisName";
        internal const string _str_strNationalName = "strNationalName";
        internal const string _str_datCreationDate = "datCreationDate";
        internal const string _str_DepartmentName = "DepartmentName";
        internal const string _str_HumanName = "HumanName";
        internal const string _str_AnimalName = "AnimalName";
        internal const string _str_Path = "Path";
        internal const string _str_TestsCount = "TestsCount";
        internal const string _str_HACode = "HACode";
        internal const string _str_datAccession = "datAccession";
        internal const string _str_strPatientName = "strPatientName";
        internal const string _str_strFarmOwner = "strFarmOwner";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_SampleType = "SampleType";
        internal const string _str_ContainerStatus = "ContainerStatus";
        internal const string _str_Department = "Department";
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
              _name = _str_strFieldBarcode, _type = "String",
              _get_func = o => o.strFieldBarcode,
              _set_func = (o, val) => { o.strFieldBarcode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFieldBarcode != c.strFieldBarcode || o.IsRIRPropChanged(_str_strFieldBarcode, c)) 
                  m.Add(_str_strFieldBarcode, o.ObjectIdent + _str_strFieldBarcode, "String", o.strFieldBarcode == null ? "" : o.strFieldBarcode.ToString(), o.IsReadOnly(_str_strFieldBarcode), o.IsInvisible(_str_strFieldBarcode), o.IsRequired(_str_strFieldBarcode)); }
              }, 
        
            new field_info {
              _name = _str_idfMaterial, _type = "Int64",
              _get_func = o => o.idfMaterial,
              _set_func = (o, val) => { o.idfMaterial = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfMaterial != c.idfMaterial || o.IsRIRPropChanged(_str_idfMaterial, c)) 
                  m.Add(_str_idfMaterial, o.ObjectIdent + _str_idfMaterial, "Int64", o.idfMaterial == null ? "" : o.idfMaterial.ToString(), o.IsReadOnly(_str_idfMaterial), o.IsInvisible(_str_idfMaterial), o.IsRequired(_str_idfMaterial)); }
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
              _name = _str_idfsContainerStatus, _type = "Int64?",
              _get_func = o => o.idfsContainerStatus,
              _set_func = (o, val) => { o.idfsContainerStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsContainerStatus != c.idfsContainerStatus || o.IsRIRPropChanged(_str_idfsContainerStatus, c)) 
                  m.Add(_str_idfsContainerStatus, o.ObjectIdent + _str_idfsContainerStatus, "Int64?", o.idfsContainerStatus == null ? "" : o.idfsContainerStatus.ToString(), o.IsReadOnly(_str_idfsContainerStatus), o.IsInvisible(_str_idfsContainerStatus), o.IsRequired(_str_idfsContainerStatus)); }
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
              _name = _str_idfsSpecimenType, _type = "Int64",
              _get_func = o => o.idfsSpecimenType,
              _set_func = (o, val) => { o.idfsSpecimenType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpecimenType != c.idfsSpecimenType || o.IsRIRPropChanged(_str_idfsSpecimenType, c)) 
                  m.Add(_str_idfsSpecimenType, o.ObjectIdent + _str_idfsSpecimenType, "Int64", o.idfsSpecimenType == null ? "" : o.idfsSpecimenType.ToString(), o.IsReadOnly(_str_idfsSpecimenType), o.IsInvisible(_str_idfsSpecimenType), o.IsRequired(_str_idfsSpecimenType)); }
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
              _name = _str_idfVectorSurveillanceSession, _type = "Int64?",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { o.idfVectorSurveillanceSession = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, "Int64?", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); }
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
              _name = _str_CaseID, _type = "String",
              _get_func = o => o.CaseID,
              _set_func = (o, val) => { o.CaseID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.CaseID != c.CaseID || o.IsRIRPropChanged(_str_CaseID, c)) 
                  m.Add(_str_CaseID, o.ObjectIdent + _str_CaseID, "String", o.CaseID == null ? "" : o.CaseID.ToString(), o.IsReadOnly(_str_CaseID), o.IsInvisible(_str_CaseID), o.IsRequired(_str_CaseID)); }
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
              _name = _str_datFieldCollectionDate, _type = "DateTime?",
              _get_func = o => o.datFieldCollectionDate,
              _set_func = (o, val) => { o.datFieldCollectionDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datFieldCollectionDate != c.datFieldCollectionDate || o.IsRIRPropChanged(_str_datFieldCollectionDate, c)) 
                  m.Add(_str_datFieldCollectionDate, o.ObjectIdent + _str_datFieldCollectionDate, "DateTime?", o.datFieldCollectionDate == null ? "" : o.datFieldCollectionDate.ToString(), o.IsReadOnly(_str_datFieldCollectionDate), o.IsInvisible(_str_datFieldCollectionDate), o.IsRequired(_str_datFieldCollectionDate)); }
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
              _name = _str_DiagnosisName, _type = "String",
              _get_func = o => o.DiagnosisName,
              _set_func = (o, val) => { o.DiagnosisName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.DiagnosisName != c.DiagnosisName || o.IsRIRPropChanged(_str_DiagnosisName, c)) 
                  m.Add(_str_DiagnosisName, o.ObjectIdent + _str_DiagnosisName, "String", o.DiagnosisName == null ? "" : o.DiagnosisName.ToString(), o.IsReadOnly(_str_DiagnosisName), o.IsInvisible(_str_DiagnosisName), o.IsRequired(_str_DiagnosisName)); }
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
              _name = _str_datCreationDate, _type = "DateTime?",
              _get_func = o => o.datCreationDate,
              _set_func = (o, val) => { o.datCreationDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datCreationDate != c.datCreationDate || o.IsRIRPropChanged(_str_datCreationDate, c)) 
                  m.Add(_str_datCreationDate, o.ObjectIdent + _str_datCreationDate, "DateTime?", o.datCreationDate == null ? "" : o.datCreationDate.ToString(), o.IsReadOnly(_str_datCreationDate), o.IsInvisible(_str_datCreationDate), o.IsRequired(_str_datCreationDate)); }
              }, 
        
            new field_info {
              _name = _str_DepartmentName, _type = "String",
              _get_func = o => o.DepartmentName,
              _set_func = (o, val) => { o.DepartmentName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.DepartmentName != c.DepartmentName || o.IsRIRPropChanged(_str_DepartmentName, c)) 
                  m.Add(_str_DepartmentName, o.ObjectIdent + _str_DepartmentName, "String", o.DepartmentName == null ? "" : o.DepartmentName.ToString(), o.IsReadOnly(_str_DepartmentName), o.IsInvisible(_str_DepartmentName), o.IsRequired(_str_DepartmentName)); }
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
              _name = _str_AnimalName, _type = "String",
              _get_func = o => o.AnimalName,
              _set_func = (o, val) => { o.AnimalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.AnimalName != c.AnimalName || o.IsRIRPropChanged(_str_AnimalName, c)) 
                  m.Add(_str_AnimalName, o.ObjectIdent + _str_AnimalName, "String", o.AnimalName == null ? "" : o.AnimalName.ToString(), o.IsReadOnly(_str_AnimalName), o.IsInvisible(_str_AnimalName), o.IsRequired(_str_AnimalName)); }
              }, 
        
            new field_info {
              _name = _str_Path, _type = "Int32?",
              _get_func = o => o.Path,
              _set_func = (o, val) => { o.Path = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.Path != c.Path || o.IsRIRPropChanged(_str_Path, c)) 
                  m.Add(_str_Path, o.ObjectIdent + _str_Path, "Int32?", o.Path == null ? "" : o.Path.ToString(), o.IsReadOnly(_str_Path), o.IsInvisible(_str_Path), o.IsRequired(_str_Path)); }
              }, 
        
            new field_info {
              _name = _str_TestsCount, _type = "Int32",
              _get_func = o => o.TestsCount,
              _set_func = (o, val) => { o.TestsCount = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.TestsCount != c.TestsCount || o.IsRIRPropChanged(_str_TestsCount, c)) 
                  m.Add(_str_TestsCount, o.ObjectIdent + _str_TestsCount, "Int32", o.TestsCount == null ? "" : o.TestsCount.ToString(), o.IsReadOnly(_str_TestsCount), o.IsInvisible(_str_TestsCount), o.IsRequired(_str_TestsCount)); }
              }, 
        
            new field_info {
              _name = _str_HACode, _type = "Int32?",
              _get_func = o => o.HACode,
              _set_func = (o, val) => { o.HACode = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.HACode != c.HACode || o.IsRIRPropChanged(_str_HACode, c)) 
                  m.Add(_str_HACode, o.ObjectIdent + _str_HACode, "Int32?", o.HACode == null ? "" : o.HACode.ToString(), o.IsReadOnly(_str_HACode), o.IsInvisible(_str_HACode), o.IsRequired(_str_HACode)); }
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
              _name = _str_strPatientName, _type = "String",
              _get_func = o => o.strPatientName,
              _set_func = (o, val) => { o.strPatientName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strPatientName != c.strPatientName || o.IsRIRPropChanged(_str_strPatientName, c)) 
                  m.Add(_str_strPatientName, o.ObjectIdent + _str_strPatientName, "String", o.strPatientName == null ? "" : o.strPatientName.ToString(), o.IsReadOnly(_str_strPatientName), o.IsInvisible(_str_strPatientName), o.IsRequired(_str_strPatientName)); }
              }, 
        
            new field_info {
              _name = _str_strFarmOwner, _type = "String",
              _get_func = o => o.strFarmOwner,
              _set_func = (o, val) => { o.strFarmOwner = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFarmOwner != c.strFarmOwner || o.IsRIRPropChanged(_str_strFarmOwner, c)) 
                  m.Add(_str_strFarmOwner, o.ObjectIdent + _str_strFarmOwner, "String", o.strFarmOwner == null ? "" : o.strFarmOwner.ToString(), o.IsReadOnly(_str_strFarmOwner), o.IsInvisible(_str_strFarmOwner), o.IsRequired(_str_strFarmOwner)); }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsShowDiagnosis != c.idfsShowDiagnosis || o.IsRIRPropChanged(_str_Diagnosis, c)) 
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, "Lookup", o.idfsShowDiagnosis == null ? "" : o.idfsShowDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis)); }
              }, 
        
            new field_info {
              _name = _str_SampleType, _type = "Lookup",
              _get_func = o => { if (o.SampleType == null) return null; return o.SampleType.idfsBaseReference; },
              _set_func = (o, val) => { o.SampleType = o.SampleTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpecimenType != c.idfsSpecimenType || o.IsRIRPropChanged(_str_SampleType, c)) 
                  m.Add(_str_SampleType, o.ObjectIdent + _str_SampleType, "Lookup", o.idfsSpecimenType == null ? "" : o.idfsSpecimenType.ToString(), o.IsReadOnly(_str_SampleType), o.IsInvisible(_str_SampleType), o.IsRequired(_str_SampleType)); }
              }, 
        
            new field_info {
              _name = _str_ContainerStatus, _type = "Lookup",
              _get_func = o => { if (o.ContainerStatus == null) return null; return o.ContainerStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.ContainerStatus = o.ContainerStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsContainerStatus != c.idfsContainerStatus || o.IsRIRPropChanged(_str_ContainerStatus, c)) 
                  m.Add(_str_ContainerStatus, o.ObjectIdent + _str_ContainerStatus, "Lookup", o.idfsContainerStatus == null ? "" : o.idfsContainerStatus.ToString(), o.IsReadOnly(_str_ContainerStatus), o.IsInvisible(_str_ContainerStatus), o.IsRequired(_str_ContainerStatus)); }
              }, 
        
            new field_info {
              _name = _str_Department, _type = "Lookup",
              _get_func = o => { if (o.Department == null) return null; return o.Department.idfDepartment; },
              _set_func = (o, val) => { o.Department = o.DepartmentLookup.Where(c => c.idfDepartment.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfInDepartment != c.idfInDepartment || o.IsRIRPropChanged(_str_Department, c)) 
                  m.Add(_str_Department, o.ObjectIdent + _str_Department, "Lookup", o.idfInDepartment == null ? "" : o.idfInDepartment.ToString(), o.IsReadOnly(_str_Department), o.IsInvisible(_str_Department), o.IsRequired(_str_Department)); }
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
    
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsShowDiagnosis)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsShowDiagnosis = _Diagnosis == null 
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
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSpecimenType)]
        public BaseReference SampleType
        {
            get { return _SampleType == null ? null : ((long)_SampleType.Key == 0 ? null : _SampleType); }
            set 
            { 
                _SampleType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsSpecimenType = _SampleType == null 
                    ? new Int64()
                    : _SampleType.idfsBaseReference; 
                OnPropertyChanged(_str_SampleType); 
            }
        }
        private BaseReference _SampleType;

        
        public BaseReferenceList SampleTypeLookup
        {
            get { return _SampleTypeLookup; }
        }
        private BaseReferenceList _SampleTypeLookup = new BaseReferenceList("rftSpecimenType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsContainerStatus)]
        public BaseReference ContainerStatus
        {
            get { return _ContainerStatus == null ? null : ((long)_ContainerStatus.Key == 0 ? null : _ContainerStatus); }
            set 
            { 
                _ContainerStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsContainerStatus = _ContainerStatus == null 
                    ? new Int64?()
                    : _ContainerStatus.idfsBaseReference; 
                OnPropertyChanged(_str_ContainerStatus); 
            }
        }
        private BaseReference _ContainerStatus;

        
        public BaseReferenceList ContainerStatusLookup
        {
            get { return _ContainerStatusLookup; }
        }
        private BaseReferenceList _ContainerStatusLookup = new BaseReferenceList("rftContainerStatus");
            
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
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsShowDiagnosis);
            
                case _str_SampleType:
                    return new BvSelectList(SampleTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SampleType, _str_idfsSpecimenType);
            
                case _str_ContainerStatus:
                    return new BvSelectList(ContainerStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, ContainerStatus, _str_idfsContainerStatus);
            
                case _str_Department:
                    return new BvSelectList(DepartmentLookup, eidss.model.Schema.DepartmentLookup._str_idfDepartment, null, Department, _str_idfInDepartment);
            
            }
        
            return null;
        }
    
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
        public override object Clone()
        {
            var ret = base.Clone() as LabSampleListItem;
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
            var ret = base.Clone() as LabSampleListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
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
        
            var _prev_idfsShowDiagnosis_Diagnosis = idfsShowDiagnosis;
            var _prev_idfsSpecimenType_SampleType = idfsSpecimenType;
            var _prev_idfsContainerStatus_ContainerStatus = idfsContainerStatus;
            var _prev_idfInDepartment_Department = idfInDepartment;
            base.RejectChanges();
        
            if (_prev_idfsShowDiagnosis_Diagnosis != idfsShowDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsShowDiagnosis);
            }
            if (_prev_idfsSpecimenType_SampleType != idfsSpecimenType)
            {
                _SampleType = _SampleTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSpecimenType);
            }
            if (_prev_idfsContainerStatus_ContainerStatus != idfsContainerStatus)
            {
                _ContainerStatus = _ContainerStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsContainerStatus);
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

      private bool IsRIRPropChanged(string fld, LabSampleListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabSampleListItem()
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


        public Dictionary<string, Func<LabSampleListItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabSampleListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabSampleListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabSampleListItem, bool>> m_isHiddenPersonalData;
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
                
                LookupManager.RemoveObject("rftSpecimenType", this);
                
                LookupManager.RemoveObject("rftContainerStatus", this);
                
                LookupManager.RemoveObject("DepartmentLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftSpecimenType")
                _getAccessor().LoadLookup_SampleType(manager, this);
            
            if (lookup_object == "rftContainerStatus")
                _getAccessor().LoadLookup_ContainerStatus(manager, this);
            
            if (lookup_object == "DepartmentLookup")
                _getAccessor().LoadLookup_Department(manager, this);
            
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
        public class LabSampleListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfContainer { get; set; }
        
            public String strBarcode { get; set; }
        
            public String strFieldBarcode { get; set; }
        
            public DateTime? datCreationDate { get; set; }
        
            public String SpecimenType { get; set; }
        
            public DateTime? datFieldCollectionDate { get; set; }
        
            public String DepartmentName { get; set; }
        
            public String CaseID { get; set; }
        
            public String DiagnosisName { get; set; }
        
            public String HumanName { get; set; }
        
            public String AnimalName { get; set; }
        
            public Int32 TestsCount { get; set; }
        
        }
        public partial class LabSampleListItemGridModelList : List<LabSampleListItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public LabSampleListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabSampleListItem>, errMes);
            }
            public LabSampleListItemGridModelList(long key, IEnumerable<LabSampleListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<LabSampleListItem> items);
            private void LoadGridModelList(long key, IEnumerable<LabSampleListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strBarcode,_str_strFieldBarcode,_str_datCreationDate,_str_SpecimenType,_str_datFieldCollectionDate,_str_DepartmentName,_str_CaseID,_str_DiagnosisName,_str_HumanName,_str_AnimalName,_str_TestsCount};
                    
                Hiddens = new List<string> {_str_idfContainer};
                Keys = new List<string> {_str_idfContainer};
                Labels = new Dictionary<string, string> {{_str_strBarcode, "strLabBarcode"},{_str_strFieldBarcode, _str_strFieldBarcode},{_str_datCreationDate, _str_datCreationDate},{_str_SpecimenType, _str_SpecimenType},{_str_datFieldCollectionDate, _str_datFieldCollectionDate},{_str_DepartmentName, _str_DepartmentName},{_str_CaseID, _str_CaseID},{_str_DiagnosisName, "idfsDiagnosis"},{_str_HumanName, _str_HumanName},{_str_AnimalName, _str_AnimalName},{_str_TestsCount, _str_TestsCount}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<LabSampleListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new LabSampleListItemGridModel()
                {
                    ItemKey=c.idfContainer,strBarcode=c.strBarcode,strFieldBarcode=c.strFieldBarcode,datCreationDate=c.datCreationDate,SpecimenType=c.SpecimenType,datFieldCollectionDate=c.datFieldCollectionDate,DepartmentName=c.DepartmentName,CaseID=c.CaseID,DiagnosisName=c.DiagnosisName,HumanName=c.HumanName,AnimalName=c.AnimalName,TestsCount=c.TestsCount
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
            
            , IObjectSelectList
                    
            , IObjectPost
                    
        {
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
            private BaseReference.Accessor ContainerStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
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
                
                if (filters.Contains("Custom_CaseStatus"))
                {
                    
                    sql.Append(" " + @"");
                      
                }
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("Custom_CaseStatus"))
                    sql.AppendFormat(" and " + new Func<string>(() => "((@Custom_CaseStatus = 1 and idfMonitoringSession is not null) or (@Custom_CaseStatus = 2 and idfCase is not null) or (@Custom_CaseStatus = 3 and idfCase is null and idfMonitoringSession is null))")());
                            
                if (filters.Contains("idfContainer"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfContainer"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfContainer") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Sample_SelectList.idfContainer,0) {0} @idfContainer_{1}", filters.Operation("idfContainer", i), i);
                            
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
                  
                if (filters.Contains("idfMaterial"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfMaterial"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfMaterial") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Sample_SelectList.idfMaterial,0) {0} @idfMaterial_{1}", filters.Operation("idfMaterial", i), i);
                            
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
                  
                if (filters.Contains("idfsContainerStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsContainerStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsContainerStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Sample_SelectList.idfsContainerStatus,0) {0} @idfsContainerStatus_{1}", filters.Operation("idfsContainerStatus", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_Sample_SelectList.idfInDepartment,0) {0} @idfInDepartment_{1}", filters.Operation("idfInDepartment", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSpecimenType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSpecimenType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSpecimenType") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Sample_SelectList.idfsSpecimenType,0) {0} @idfsSpecimenType_{1}", filters.Operation("idfsSpecimenType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("SpecimenType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("SpecimenType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("SpecimenType") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Sample_SelectList.SpecimenType {0} @SpecimenType_{1}", filters.Operation("SpecimenType", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_Sample_SelectList.idfsShowDiagnosis,0) {0} @idfsShowDiagnosis_{1}", filters.Operation("idfsShowDiagnosis", i), i);
                            
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
                  
                if (filters.Contains("datCreationDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datCreationDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datCreationDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_Sample_SelectList.datCreationDate, 112) {0} CONVERT(NVARCHAR(8), @datCreationDate_{1}, 112)", filters.Operation("datCreationDate", i), i);
                            
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
                    manager
                        .SetCommand(sql.ToString()
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                        );
                    
                    if (filters.Contains("Custom_CaseStatus"))
                        
                        if (filters.Count("Custom_CaseStatus") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@Custom_CaseStatus", ParsingHelper.CorrectLikeValue(filters.Operation("Custom_CaseStatus"), filters.Value("Custom_CaseStatus"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("Custom_CaseStatus"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@Custom_CaseStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("Custom_CaseStatus", i), filters.Value("Custom_CaseStatus", i))));
                        }
                            
                    if (filters.Contains("idfContainer"))
                        for (int i = 0; i < filters.Count("idfContainer"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfContainer_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfContainer", i), filters.Value("idfContainer", i))));
                      
                    if (filters.Contains("strFieldBarcode"))
                        for (int i = 0; i < filters.Count("strFieldBarcode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFieldBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFieldBarcode", i), filters.Value("strFieldBarcode", i))));
                      
                    if (filters.Contains("idfMaterial"))
                        for (int i = 0; i < filters.Count("idfMaterial"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfMaterial_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfMaterial", i), filters.Value("idfMaterial", i))));
                      
                    if (filters.Contains("strBarcode"))
                        for (int i = 0; i < filters.Count("strBarcode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strBarcode", i), filters.Value("strBarcode", i))));
                      
                    if (filters.Contains("idfsContainerStatus"))
                        for (int i = 0; i < filters.Count("idfsContainerStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsContainerStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsContainerStatus", i), filters.Value("idfsContainerStatus", i))));
                      
                    if (filters.Contains("idfInDepartment"))
                        for (int i = 0; i < filters.Count("idfInDepartment"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfInDepartment_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfInDepartment", i), filters.Value("idfInDepartment", i))));
                      
                    if (filters.Contains("idfsSpecimenType"))
                        for (int i = 0; i < filters.Count("idfsSpecimenType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSpecimenType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSpecimenType", i), filters.Value("idfsSpecimenType", i))));
                      
                    if (filters.Contains("SpecimenType"))
                        for (int i = 0; i < filters.Count("SpecimenType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@SpecimenType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("SpecimenType", i), filters.Value("SpecimenType", i))));
                      
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
                      
                    if (filters.Contains("DiagnosisName"))
                        for (int i = 0; i < filters.Count("DiagnosisName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@DiagnosisName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("DiagnosisName", i), filters.Value("DiagnosisName", i))));
                      
                    if (filters.Contains("strNationalName"))
                        for (int i = 0; i < filters.Count("strNationalName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strNationalName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strNationalName", i), filters.Value("strNationalName", i))));
                      
                    if (filters.Contains("datCreationDate"))
                        for (int i = 0; i < filters.Count("datCreationDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datCreationDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datCreationDate", i), filters.Value("datCreationDate", i))));
                      
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
        
            [SprocName("spLabSample_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabSampleListItem obj)
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

    

            private LabSampleListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
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
                obj.ContainerStatus = new Func<LabSampleListItem, BaseReference>(c => 
                                     c.ContainerStatusLookup.Where(a => a.idfsBaseReference == (long)eidss.model.Enums.ContainerStatus.Accessioned)
                                     .SingleOrDefault())(obj);
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
                    .Where(c => ((c.intHACode & (int)eidss.model.Enums.HACode.All) != 0) || c.idfsDiagnosis == obj.idfsShowDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsShowDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsShowDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsShowDiagnosis != null && obj.idfsShowDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .Where(c => c.idfsDiagnosis == obj.idfsShowDiagnosis)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_SampleType(DbManagerProxy manager, LabSampleListItem obj)
            {
                
                obj.SampleTypeLookup.Clear();
                
                obj.SampleTypeLookup.Add(SampleTypeAccessor.CreateNewT(manager, null));
                
                obj.SampleTypeLookup.AddRange(SampleTypeAccessor.rftSpecimenType_SelectList(manager
                    
                    )
                    .Where(c => c.idfsBaseReference != (long)SampleTypeEnum.Unknown)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSpecimenType))
                    
                    .ToList());
                
                if (obj.idfsSpecimenType != 0)
                {
                    obj.SampleType = obj.SampleTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsSpecimenType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftSpecimenType", obj, SampleTypeAccessor.GetType(), "rftSpecimenType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_ContainerStatus(DbManagerProxy manager, LabSampleListItem obj)
            {
                
                obj.ContainerStatusLookup.Clear();
                
                obj.ContainerStatusLookup.Add(ContainerStatusAccessor.CreateNewT(manager, null));
                
                obj.ContainerStatusLookup.AddRange(ContainerStatusAccessor.rftContainerStatus_SelectList(manager
                    
                    )
                    .Where(c=>c.idfsBaseReference != (long)eidss.model.Enums.ContainerStatus.IsDeleted)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsContainerStatus))
                    
                    .ToList());
                
                if (obj.idfsContainerStatus != null && obj.idfsContainerStatus != 0)
                {
                    obj.ContainerStatus = obj.ContainerStatusLookup
                        .Where(c => c.idfsBaseReference == obj.idfsContainerStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftContainerStatus", obj, ContainerStatusAccessor.GetType(), "rftContainerStatus_SelectList"
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
                        .Where(c => c.idfDepartment == obj.idfInDepartment)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("DepartmentLookup", obj, DepartmentAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, LabSampleListItem obj)
            {
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_SampleType(manager, obj);
                
                LoadLookup_ContainerStatus(manager, obj);
                
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
                    bSuccess = _PostNonTransaction(manager, obj as LabSampleListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, LabSampleListItem obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfContainer
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
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as LabSampleListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabSampleListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
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
            public string HelpIdWin { get { return "samples_list"; } }
            public string HelpIdWeb { get { return ""; } }
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
            static Meta()
            {
                
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_SpecimenType, 2000);
                Sizes.Add(_str_CaseID, 200);
                Sizes.Add(_str_DiagnosisName, 2000);
                Sizes.Add(_str_strNationalName, 200);
                Sizes.Add(_str_DepartmentName, 2000);
                Sizes.Add(_str_HumanName, 200);
                Sizes.Add(_str_AnimalName, 2000);
                Sizes.Add(_str_strPatientName, 200);
                Sizes.Add(_str_strFarmOwner, 200);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "CaseID",
                    EditorType.Text,
                    false, false, 
                    "CaseID",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFieldBarcode",
                    EditorType.Text,
                    false, false, 
                    "strFieldBarcode",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsShowDiagnosis",
                    EditorType.Lookup,
                    false, false, 
                    "idfsDiagnosis",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "DiagnosisLookup", typeof(DiagnosisLookup), (o) => { var c = (DiagnosisLookup)o; return c.idfsDiagnosis; }, (o) => { var c = (DiagnosisLookup)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSpecimenType",
                    EditorType.Lookup,
                    false, false, 
                    "SpecimenType",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "SampleTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strBarcode",
                    EditorType.Text,
                    false, false, 
                    "strLabBarcode",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strPatientName",
                    EditorType.Text,
                    false, false, 
                    "strHumanPatientName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFarmOwner",
                    EditorType.Text,
                    false, false, 
                    "strFarmOwnerName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datFieldCollectionDate",
                    EditorType.Date,
                    true, false, 
                    "datFieldCollectionDate",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datCreationDate",
                    EditorType.Date,
                    true, false, 
                    "datCreationDate",
                    () => DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter), null, true, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfInDepartment",
                    EditorType.Lookup,
                    false, false, 
                    "DepartmentName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "DepartmentLookup", typeof(DepartmentLookup), (o) => { var c = (DepartmentLookup)o; return c.idfDepartment; }, (o) => { var c = (DepartmentLookup)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "TestsCount",
                    EditorType.Numeric,
                    false, false, 
                    "TestsCount",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsContainerStatus",
                    EditorType.Lookup,
                    false, false, 
                    "idfsContainerStatus",
                    null, null, true, false, SearchPanelLocation.Main, false, null, "ContainerStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "Custom_CaseStatus",
                    EditorType.Lookup,
                    false, false, 
                    "LabCaseStatus",
                    () => 2, null, true, false, SearchPanelLocation.Main, true, null, "CaseStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfContainer,
                    _str_idfContainer, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBarcode,
                    "strLabBarcode", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode,
                    _str_strFieldBarcode, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datCreationDate,
                    _str_datCreationDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_SpecimenType,
                    _str_SpecimenType, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldCollectionDate,
                    _str_datFieldCollectionDate, null, true, true, ListSortDirection.Descending
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DepartmentName,
                    _str_DepartmentName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_CaseID,
                    _str_CaseID, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DiagnosisName,
                    "idfsDiagnosis", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_HumanName,
                    _str_HumanName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalName,
                    _str_AnimalName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestsCount,
                    _str_TestsCount, null, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "SelectTest",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem,LabSampleLogBookListItem,LabSampleLogBookMyPrefListItem",
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
                    (c, p, b) => c != null && ((long)(eidss.model.Enums.ContainerStatus.Accessioned)).Equals(c.GetValue("idfsContainerStatus")),
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "MarkForDisposition",
                    ActionTypes.Action,
                    true,
                    "LabSampleDispositionListItem,LabSampleListItem,LabSampleLogBookListItem,LabSampleLogBookMyPrefListItem",
                    "",
                    
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
                    (c, p, b) => c != null && ((long)(eidss.model.Enums.ContainerStatus.Accessioned)).Equals(c.GetValue("idfsContainerStatus")),
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "TransferOut",
                    ActionTypes.Action,
                    true,
                    "LabSampleTransferListItem,LabSampleListItem,LabSampleLogBookListItem,LabSampleLogBookMyPrefListItem",
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
                    (c, p, b) => c != null && ((long)(eidss.model.Enums.ContainerStatus.Accessioned)).Equals(c.GetValue("idfsContainerStatus")),
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "AliquotsDerivatives",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem,LabSampleLogBookListItem,LabSampleLogBookMyPrefListItem",
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
                    (c, p, b) => c != null && ((long)(eidss.model.Enums.ContainerStatus.Accessioned)).Equals(c.GetValue("idfsContainerStatus")),
                    null,
                    null,
                    false
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
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "HumanAccessionIn",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem,LabSampleLogBookListItem,LabSampleLogBookMyPrefListItem",
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
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "VetAccessionIn",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem,LabSampleLogBookListItem,LabSampleLogBookMyPrefListItem",
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
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "AsAccessionIn",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem,LabSampleLogBookListItem,LabSampleLogBookMyPrefListItem",
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
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "VsAccessionIn",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem,LabSampleLogBookListItem,LabSampleLogBookMyPrefListItem",
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
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "GroupAccessionIn",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem,LabSampleLogBookListItem,LabSampleLogBookMyPrefListItem",
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	