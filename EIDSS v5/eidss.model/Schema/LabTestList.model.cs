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
    public abstract partial class LabTestListItem : 
        EditableObject<LabTestListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfTesting), NonUpdatable, PrimaryKey]
        public abstract Int64 idfTesting { get; set; }
                
        [LocalizedDisplayName(_str_idfsTestType)]
        [MapField(_str_idfsTestType)]
        public abstract Int64? idfsTestType { get; set; }
        #if MONO
        protected Int64? idfsTestType_Original { get { return idfsTestType; } }
        protected Int64? idfsTestType_Previous { get { return idfsTestType; } }
        #else
        protected Int64? idfsTestType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestType).OriginalValue; } }
        protected Int64? idfsTestType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsTestStatus)]
        [MapField(_str_idfsTestStatus)]
        public abstract Int64 idfsTestStatus { get; set; }
        #if MONO
        protected Int64 idfsTestStatus_Original { get { return idfsTestStatus; } }
        protected Int64 idfsTestStatus_Previous { get { return idfsTestStatus; } }
        #else
        protected Int64 idfsTestStatus_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsTestStatus).OriginalValue; } }
        protected Int64 idfsTestStatus_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsTestStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfObservation)]
        [MapField(_str_idfObservation)]
        public abstract Int64 idfObservation { get; set; }
        #if MONO
        protected Int64 idfObservation_Original { get { return idfObservation; } }
        protected Int64 idfObservation_Previous { get { return idfObservation; } }
        #else
        protected Int64 idfObservation_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfObservation).OriginalValue; } }
        protected Int64 idfObservation_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfObservation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_TestType)]
        [MapField(_str_TestType)]
        public abstract String TestType { get; set; }
        #if MONO
        protected String TestType_Original { get { return TestType; } }
        protected String TestType_Previous { get { return TestType; } }
        #else
        protected String TestType_Original { get { return ((EditableValue<String>)((dynamic)this)._testType).OriginalValue; } }
        protected String TestType_Previous { get { return ((EditableValue<String>)((dynamic)this)._testType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_TestResult)]
        [MapField(_str_TestResult)]
        public abstract String TestResult { get; set; }
        #if MONO
        protected String TestResult_Original { get { return TestResult; } }
        protected String TestResult_Previous { get { return TestResult; } }
        #else
        protected String TestResult_Original { get { return ((EditableValue<String>)((dynamic)this)._testResult).OriginalValue; } }
        protected String TestResult_Previous { get { return ((EditableValue<String>)((dynamic)this)._testResult).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_TestCategory)]
        [MapField(_str_TestCategory)]
        public abstract String TestCategory { get; set; }
        #if MONO
        protected String TestCategory_Original { get { return TestCategory; } }
        protected String TestCategory_Previous { get { return TestCategory; } }
        #else
        protected String TestCategory_Original { get { return ((EditableValue<String>)((dynamic)this)._testCategory).OriginalValue; } }
        protected String TestCategory_Previous { get { return ((EditableValue<String>)((dynamic)this)._testCategory).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsTestForDiseaseType)]
        [MapField(_str_idfsTestForDiseaseType)]
        public abstract Int64? idfsTestForDiseaseType { get; set; }
        #if MONO
        protected Int64? idfsTestForDiseaseType_Original { get { return idfsTestForDiseaseType; } }
        protected Int64? idfsTestForDiseaseType_Previous { get { return idfsTestForDiseaseType; } }
        #else
        protected Int64? idfsTestForDiseaseType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestForDiseaseType).OriginalValue; } }
        protected Int64? idfsTestForDiseaseType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestForDiseaseType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfBatchTest)]
        [MapField(_str_idfBatchTest)]
        public abstract Int64? idfBatchTest { get; set; }
        #if MONO
        protected Int64? idfBatchTest_Original { get { return idfBatchTest; } }
        protected Int64? idfBatchTest_Previous { get { return idfBatchTest; } }
        #else
        protected Int64? idfBatchTest_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfBatchTest).OriginalValue; } }
        protected Int64? idfBatchTest_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfBatchTest).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_BatchTestCode)]
        [MapField(_str_BatchTestCode)]
        public abstract String BatchTestCode { get; set; }
        #if MONO
        protected String BatchTestCode_Original { get { return BatchTestCode; } }
        protected String BatchTestCode_Previous { get { return BatchTestCode; } }
        #else
        protected String BatchTestCode_Original { get { return ((EditableValue<String>)((dynamic)this)._batchTestCode).OriginalValue; } }
        protected String BatchTestCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._batchTestCode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datConcludedDate)]
        [MapField(_str_datConcludedDate)]
        public abstract DateTime? datConcludedDate { get; set; }
        #if MONO
        protected DateTime? datConcludedDate_Original { get { return datConcludedDate; } }
        protected DateTime? datConcludedDate_Previous { get { return datConcludedDate; } }
        #else
        protected DateTime? datConcludedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datConcludedDate).OriginalValue; } }
        protected DateTime? datConcludedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datConcludedDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datPerformedDate)]
        [MapField(_str_datPerformedDate)]
        public abstract DateTime? datPerformedDate { get; set; }
        #if MONO
        protected DateTime? datPerformedDate_Original { get { return datPerformedDate; } }
        protected DateTime? datPerformedDate_Previous { get { return datPerformedDate; } }
        #else
        protected DateTime? datPerformedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPerformedDate).OriginalValue; } }
        protected DateTime? datPerformedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPerformedDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_Status)]
        [MapField(_str_Status)]
        public abstract String Status { get; set; }
        #if MONO
        protected String Status_Original { get { return Status; } }
        protected String Status_Previous { get { return Status; } }
        #else
        protected String Status_Original { get { return ((EditableValue<String>)((dynamic)this)._status).OriginalValue; } }
        protected String Status_Previous { get { return ((EditableValue<String>)((dynamic)this)._status).PreviousValue; } }
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
                
        [LocalizedDisplayName("TestDiagnosisName")]
        [MapField(_str_DiagnosisName)]
        public abstract String DiagnosisName { get; set; }
        #if MONO
        protected String DiagnosisName_Original { get { return DiagnosisName; } }
        protected String DiagnosisName_Previous { get { return DiagnosisName; } }
        #else
        protected String DiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).OriginalValue; } }
        protected String DiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsDiagnosis)]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64 idfsDiagnosis { get; set; }
        #if MONO
        protected Int64 idfsDiagnosis_Original { get { return idfsDiagnosis; } }
        protected Int64 idfsDiagnosis_Previous { get { return idfsDiagnosis; } }
        #else
        protected Int64 idfsDiagnosis_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64 idfsDiagnosis_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
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
                
        [LocalizedDisplayName("datAccession")]
        [MapField(_str_datCreationDate)]
        public abstract DateTime? datCreationDate { get; set; }
        #if MONO
        protected DateTime? datCreationDate_Original { get { return datCreationDate; } }
        protected DateTime? datCreationDate_Previous { get { return datCreationDate; } }
        #else
        protected DateTime? datCreationDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCreationDate).OriginalValue; } }
        protected DateTime? datCreationDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCreationDate).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsBatchStatus)]
        [MapField(_str_idfsBatchStatus)]
        public abstract Int64? idfsBatchStatus { get; set; }
        #if MONO
        protected Int64? idfsBatchStatus_Original { get { return idfsBatchStatus; } }
        protected Int64? idfsBatchStatus_Previous { get { return idfsBatchStatus; } }
        #else
        protected Int64? idfsBatchStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBatchStatus).OriginalValue; } }
        protected Int64? idfsBatchStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBatchStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsTestResult)]
        [MapField(_str_idfsTestResult)]
        public abstract Int64? idfsTestResult { get; set; }
        #if MONO
        protected Int64? idfsTestResult_Original { get { return idfsTestResult; } }
        protected Int64? idfsTestResult_Previous { get { return idfsTestResult; } }
        #else
        protected Int64? idfsTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).OriginalValue; } }
        protected Int64? idfsTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).PreviousValue; } }
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
            internal Func<LabTestListItem, object> _get_func;
            internal Action<LabTestListItem, string> _set_func;
            internal Action<LabTestListItem, LabTestListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfTesting = "idfTesting";
        internal const string _str_idfsTestType = "idfsTestType";
        internal const string _str_idfsTestStatus = "idfsTestStatus";
        internal const string _str_idfObservation = "idfObservation";
        internal const string _str_TestType = "TestType";
        internal const string _str_TestResult = "TestResult";
        internal const string _str_TestCategory = "TestCategory";
        internal const string _str_idfsTestForDiseaseType = "idfsTestForDiseaseType";
        internal const string _str_idfBatchTest = "idfBatchTest";
        internal const string _str_BatchTestCode = "BatchTestCode";
        internal const string _str_datConcludedDate = "datConcludedDate";
        internal const string _str_datPerformedDate = "datPerformedDate";
        internal const string _str_Status = "Status";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_SpecimenType = "SpecimenType";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_CaseID = "CaseID";
        internal const string _str_DiagnosisName = "DiagnosisName";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_idfsSpecimenType = "idfsSpecimenType";
        internal const string _str_DepartmentName = "DepartmentName";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_datCreationDate = "datCreationDate";
        internal const string _str_datAccession = "datAccession";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_HumanName = "HumanName";
        internal const string _str_AnimalName = "AnimalName";
        internal const string _str_idfsBatchStatus = "idfsBatchStatus";
        internal const string _str_idfsTestResult = "idfsTestResult";
        internal const string _str_strPatientName = "strPatientName";
        internal const string _str_strFarmOwner = "strFarmOwner";
        internal const string _str_TestTypeName = "TestTypeName";
        internal const string _str_BatchStatusName = "BatchStatusName";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_SampleType = "SampleType";
        internal const string _str_TestStatus = "TestStatus";
        internal const string _str_TestForDiseaseType = "TestForDiseaseType";
        internal const string _str_TestResultRef = "TestResultRef";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfTesting, _type = "Int64",
              _get_func = o => o.idfTesting,
              _set_func = (o, val) => { o.idfTesting = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTesting != c.idfTesting || o.IsRIRPropChanged(_str_idfTesting, c)) 
                  m.Add(_str_idfTesting, o.ObjectIdent + _str_idfTesting, "Int64", o.idfTesting == null ? "" : o.idfTesting.ToString(), o.IsReadOnly(_str_idfTesting), o.IsInvisible(_str_idfTesting), o.IsRequired(_str_idfTesting)); }
              }, 
        
            new field_info {
              _name = _str_idfsTestType, _type = "Int64?",
              _get_func = o => o.idfsTestType,
              _set_func = (o, val) => { o.idfsTestType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestType != c.idfsTestType || o.IsRIRPropChanged(_str_idfsTestType, c)) 
                  m.Add(_str_idfsTestType, o.ObjectIdent + _str_idfsTestType, "Int64?", o.idfsTestType == null ? "" : o.idfsTestType.ToString(), o.IsReadOnly(_str_idfsTestType), o.IsInvisible(_str_idfsTestType), o.IsRequired(_str_idfsTestType)); }
              }, 
        
            new field_info {
              _name = _str_idfsTestStatus, _type = "Int64",
              _get_func = o => o.idfsTestStatus,
              _set_func = (o, val) => { o.idfsTestStatus = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestStatus != c.idfsTestStatus || o.IsRIRPropChanged(_str_idfsTestStatus, c)) 
                  m.Add(_str_idfsTestStatus, o.ObjectIdent + _str_idfsTestStatus, "Int64", o.idfsTestStatus == null ? "" : o.idfsTestStatus.ToString(), o.IsReadOnly(_str_idfsTestStatus), o.IsInvisible(_str_idfsTestStatus), o.IsRequired(_str_idfsTestStatus)); }
              }, 
        
            new field_info {
              _name = _str_idfObservation, _type = "Int64",
              _get_func = o => o.idfObservation,
              _set_func = (o, val) => { o.idfObservation = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfObservation != c.idfObservation || o.IsRIRPropChanged(_str_idfObservation, c)) 
                  m.Add(_str_idfObservation, o.ObjectIdent + _str_idfObservation, "Int64", o.idfObservation == null ? "" : o.idfObservation.ToString(), o.IsReadOnly(_str_idfObservation), o.IsInvisible(_str_idfObservation), o.IsRequired(_str_idfObservation)); }
              }, 
        
            new field_info {
              _name = _str_TestType, _type = "String",
              _get_func = o => o.TestType,
              _set_func = (o, val) => { o.TestType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.TestType != c.TestType || o.IsRIRPropChanged(_str_TestType, c)) 
                  m.Add(_str_TestType, o.ObjectIdent + _str_TestType, "String", o.TestType == null ? "" : o.TestType.ToString(), o.IsReadOnly(_str_TestType), o.IsInvisible(_str_TestType), o.IsRequired(_str_TestType)); }
              }, 
        
            new field_info {
              _name = _str_TestResult, _type = "String",
              _get_func = o => o.TestResult,
              _set_func = (o, val) => { o.TestResult = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.TestResult != c.TestResult || o.IsRIRPropChanged(_str_TestResult, c)) 
                  m.Add(_str_TestResult, o.ObjectIdent + _str_TestResult, "String", o.TestResult == null ? "" : o.TestResult.ToString(), o.IsReadOnly(_str_TestResult), o.IsInvisible(_str_TestResult), o.IsRequired(_str_TestResult)); }
              }, 
        
            new field_info {
              _name = _str_TestCategory, _type = "String",
              _get_func = o => o.TestCategory,
              _set_func = (o, val) => { o.TestCategory = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.TestCategory != c.TestCategory || o.IsRIRPropChanged(_str_TestCategory, c)) 
                  m.Add(_str_TestCategory, o.ObjectIdent + _str_TestCategory, "String", o.TestCategory == null ? "" : o.TestCategory.ToString(), o.IsReadOnly(_str_TestCategory), o.IsInvisible(_str_TestCategory), o.IsRequired(_str_TestCategory)); }
              }, 
        
            new field_info {
              _name = _str_idfsTestForDiseaseType, _type = "Int64?",
              _get_func = o => o.idfsTestForDiseaseType,
              _set_func = (o, val) => { o.idfsTestForDiseaseType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestForDiseaseType != c.idfsTestForDiseaseType || o.IsRIRPropChanged(_str_idfsTestForDiseaseType, c)) 
                  m.Add(_str_idfsTestForDiseaseType, o.ObjectIdent + _str_idfsTestForDiseaseType, "Int64?", o.idfsTestForDiseaseType == null ? "" : o.idfsTestForDiseaseType.ToString(), o.IsReadOnly(_str_idfsTestForDiseaseType), o.IsInvisible(_str_idfsTestForDiseaseType), o.IsRequired(_str_idfsTestForDiseaseType)); }
              }, 
        
            new field_info {
              _name = _str_idfBatchTest, _type = "Int64?",
              _get_func = o => o.idfBatchTest,
              _set_func = (o, val) => { o.idfBatchTest = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfBatchTest != c.idfBatchTest || o.IsRIRPropChanged(_str_idfBatchTest, c)) 
                  m.Add(_str_idfBatchTest, o.ObjectIdent + _str_idfBatchTest, "Int64?", o.idfBatchTest == null ? "" : o.idfBatchTest.ToString(), o.IsReadOnly(_str_idfBatchTest), o.IsInvisible(_str_idfBatchTest), o.IsRequired(_str_idfBatchTest)); }
              }, 
        
            new field_info {
              _name = _str_BatchTestCode, _type = "String",
              _get_func = o => o.BatchTestCode,
              _set_func = (o, val) => { o.BatchTestCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.BatchTestCode != c.BatchTestCode || o.IsRIRPropChanged(_str_BatchTestCode, c)) 
                  m.Add(_str_BatchTestCode, o.ObjectIdent + _str_BatchTestCode, "String", o.BatchTestCode == null ? "" : o.BatchTestCode.ToString(), o.IsReadOnly(_str_BatchTestCode), o.IsInvisible(_str_BatchTestCode), o.IsRequired(_str_BatchTestCode)); }
              }, 
        
            new field_info {
              _name = _str_datConcludedDate, _type = "DateTime?",
              _get_func = o => o.datConcludedDate,
              _set_func = (o, val) => { o.datConcludedDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datConcludedDate != c.datConcludedDate || o.IsRIRPropChanged(_str_datConcludedDate, c)) 
                  m.Add(_str_datConcludedDate, o.ObjectIdent + _str_datConcludedDate, "DateTime?", o.datConcludedDate == null ? "" : o.datConcludedDate.ToString(), o.IsReadOnly(_str_datConcludedDate), o.IsInvisible(_str_datConcludedDate), o.IsRequired(_str_datConcludedDate)); }
              }, 
        
            new field_info {
              _name = _str_datPerformedDate, _type = "DateTime?",
              _get_func = o => o.datPerformedDate,
              _set_func = (o, val) => { o.datPerformedDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datPerformedDate != c.datPerformedDate || o.IsRIRPropChanged(_str_datPerformedDate, c)) 
                  m.Add(_str_datPerformedDate, o.ObjectIdent + _str_datPerformedDate, "DateTime?", o.datPerformedDate == null ? "" : o.datPerformedDate.ToString(), o.IsReadOnly(_str_datPerformedDate), o.IsInvisible(_str_datPerformedDate), o.IsRequired(_str_datPerformedDate)); }
              }, 
        
            new field_info {
              _name = _str_Status, _type = "String",
              _get_func = o => o.Status,
              _set_func = (o, val) => { o.Status = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.Status != c.Status || o.IsRIRPropChanged(_str_Status, c)) 
                  m.Add(_str_Status, o.ObjectIdent + _str_Status, "String", o.Status == null ? "" : o.Status.ToString(), o.IsReadOnly(_str_Status), o.IsInvisible(_str_Status), o.IsRequired(_str_Status)); }
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
              _name = _str_idfsCaseType, _type = "Int64?",
              _get_func = o => o.idfsCaseType,
              _set_func = (o, val) => { o.idfsCaseType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_idfsCaseType, c)) 
                  m.Add(_str_idfsCaseType, o.ObjectIdent + _str_idfsCaseType, "Int64?", o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(), o.IsReadOnly(_str_idfsCaseType), o.IsInvisible(_str_idfsCaseType), o.IsRequired(_str_idfsCaseType)); }
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
              _name = _str_DiagnosisName, _type = "String",
              _get_func = o => o.DiagnosisName,
              _set_func = (o, val) => { o.DiagnosisName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.DiagnosisName != c.DiagnosisName || o.IsRIRPropChanged(_str_DiagnosisName, c)) 
                  m.Add(_str_DiagnosisName, o.ObjectIdent + _str_DiagnosisName, "String", o.DiagnosisName == null ? "" : o.DiagnosisName.ToString(), o.IsReadOnly(_str_DiagnosisName), o.IsInvisible(_str_DiagnosisName), o.IsRequired(_str_DiagnosisName)); }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosis, _type = "Int64",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { o.idfsDiagnosis = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, "Int64", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); }
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
              _name = _str_DepartmentName, _type = "String",
              _get_func = o => o.DepartmentName,
              _set_func = (o, val) => { o.DepartmentName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.DepartmentName != c.DepartmentName || o.IsRIRPropChanged(_str_DepartmentName, c)) 
                  m.Add(_str_DepartmentName, o.ObjectIdent + _str_DepartmentName, "String", o.DepartmentName == null ? "" : o.DepartmentName.ToString(), o.IsReadOnly(_str_DepartmentName), o.IsInvisible(_str_DepartmentName), o.IsRequired(_str_DepartmentName)); }
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
              _name = _str_datCreationDate, _type = "DateTime?",
              _get_func = o => o.datCreationDate,
              _set_func = (o, val) => { o.datCreationDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datCreationDate != c.datCreationDate || o.IsRIRPropChanged(_str_datCreationDate, c)) 
                  m.Add(_str_datCreationDate, o.ObjectIdent + _str_datCreationDate, "DateTime?", o.datCreationDate == null ? "" : o.datCreationDate.ToString(), o.IsReadOnly(_str_datCreationDate), o.IsInvisible(_str_datCreationDate), o.IsRequired(_str_datCreationDate)); }
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
              _name = _str_strFieldBarcode, _type = "String",
              _get_func = o => o.strFieldBarcode,
              _set_func = (o, val) => { o.strFieldBarcode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFieldBarcode != c.strFieldBarcode || o.IsRIRPropChanged(_str_strFieldBarcode, c)) 
                  m.Add(_str_strFieldBarcode, o.ObjectIdent + _str_strFieldBarcode, "String", o.strFieldBarcode == null ? "" : o.strFieldBarcode.ToString(), o.IsReadOnly(_str_strFieldBarcode), o.IsInvisible(_str_strFieldBarcode), o.IsRequired(_str_strFieldBarcode)); }
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
              _name = _str_idfsBatchStatus, _type = "Int64?",
              _get_func = o => o.idfsBatchStatus,
              _set_func = (o, val) => { o.idfsBatchStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsBatchStatus != c.idfsBatchStatus || o.IsRIRPropChanged(_str_idfsBatchStatus, c)) 
                  m.Add(_str_idfsBatchStatus, o.ObjectIdent + _str_idfsBatchStatus, "Int64?", o.idfsBatchStatus == null ? "" : o.idfsBatchStatus.ToString(), o.IsReadOnly(_str_idfsBatchStatus), o.IsInvisible(_str_idfsBatchStatus), o.IsRequired(_str_idfsBatchStatus)); }
              }, 
        
            new field_info {
              _name = _str_idfsTestResult, _type = "Int64?",
              _get_func = o => o.idfsTestResult,
              _set_func = (o, val) => { o.idfsTestResult = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestResult != c.idfsTestResult || o.IsRIRPropChanged(_str_idfsTestResult, c)) 
                  m.Add(_str_idfsTestResult, o.ObjectIdent + _str_idfsTestResult, "Int64?", o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(), o.IsReadOnly(_str_idfsTestResult), o.IsInvisible(_str_idfsTestResult), o.IsRequired(_str_idfsTestResult)); }
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
              _name = _str_TestTypeName, _type = "Lookup",
              _get_func = o => { if (o.TestTypeName == null) return null; return o.TestTypeName.idfsBaseReference; },
              _set_func = (o, val) => { o.TestTypeName = o.TestTypeNameLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestType != c.idfsTestType || o.IsRIRPropChanged(_str_TestTypeName, c)) 
                  m.Add(_str_TestTypeName, o.ObjectIdent + _str_TestTypeName, "Lookup", o.idfsTestType == null ? "" : o.idfsTestType.ToString(), o.IsReadOnly(_str_TestTypeName), o.IsInvisible(_str_TestTypeName), o.IsRequired(_str_TestTypeName)); }
              }, 
        
            new field_info {
              _name = _str_BatchStatusName, _type = "Lookup",
              _get_func = o => { if (o.BatchStatusName == null) return null; return o.BatchStatusName.idfsBaseReference; },
              _set_func = (o, val) => { o.BatchStatusName = o.BatchStatusNameLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsBatchStatus != c.idfsBatchStatus || o.IsRIRPropChanged(_str_BatchStatusName, c)) 
                  m.Add(_str_BatchStatusName, o.ObjectIdent + _str_BatchStatusName, "Lookup", o.idfsBatchStatus == null ? "" : o.idfsBatchStatus.ToString(), o.IsReadOnly(_str_BatchStatusName), o.IsInvisible(_str_BatchStatusName), o.IsRequired(_str_BatchStatusName)); }
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
              _name = _str_SampleType, _type = "Lookup",
              _get_func = o => { if (o.SampleType == null) return null; return o.SampleType.idfsBaseReference; },
              _set_func = (o, val) => { o.SampleType = o.SampleTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpecimenType != c.idfsSpecimenType || o.IsRIRPropChanged(_str_SampleType, c)) 
                  m.Add(_str_SampleType, o.ObjectIdent + _str_SampleType, "Lookup", o.idfsSpecimenType == null ? "" : o.idfsSpecimenType.ToString(), o.IsReadOnly(_str_SampleType), o.IsInvisible(_str_SampleType), o.IsRequired(_str_SampleType)); }
              }, 
        
            new field_info {
              _name = _str_TestStatus, _type = "Lookup",
              _get_func = o => { if (o.TestStatus == null) return null; return o.TestStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.TestStatus = o.TestStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestStatus != c.idfsTestStatus || o.IsRIRPropChanged(_str_TestStatus, c)) 
                  m.Add(_str_TestStatus, o.ObjectIdent + _str_TestStatus, "Lookup", o.idfsTestStatus == null ? "" : o.idfsTestStatus.ToString(), o.IsReadOnly(_str_TestStatus), o.IsInvisible(_str_TestStatus), o.IsRequired(_str_TestStatus)); }
              }, 
        
            new field_info {
              _name = _str_TestForDiseaseType, _type = "Lookup",
              _get_func = o => { if (o.TestForDiseaseType == null) return null; return o.TestForDiseaseType.idfsBaseReference; },
              _set_func = (o, val) => { o.TestForDiseaseType = o.TestForDiseaseTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestForDiseaseType != c.idfsTestForDiseaseType || o.IsRIRPropChanged(_str_TestForDiseaseType, c)) 
                  m.Add(_str_TestForDiseaseType, o.ObjectIdent + _str_TestForDiseaseType, "Lookup", o.idfsTestForDiseaseType == null ? "" : o.idfsTestForDiseaseType.ToString(), o.IsReadOnly(_str_TestForDiseaseType), o.IsInvisible(_str_TestForDiseaseType), o.IsRequired(_str_TestForDiseaseType)); }
              }, 
        
            new field_info {
              _name = _str_TestResultRef, _type = "Lookup",
              _get_func = o => { if (o.TestResultRef == null) return null; return o.TestResultRef.idfsBaseReference; },
              _set_func = (o, val) => { o.TestResultRef = o.TestResultRefLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestResult != c.idfsTestResult || o.IsRIRPropChanged(_str_TestResultRef, c)) 
                  m.Add(_str_TestResultRef, o.ObjectIdent + _str_TestResultRef, "Lookup", o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(), o.IsReadOnly(_str_TestResultRef), o.IsInvisible(_str_TestResultRef), o.IsRequired(_str_TestResultRef)); }
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
            LabTestListItem obj = (LabTestListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestType)]
        public BaseReference TestTypeName
        {
            get { return _TestTypeName == null ? null : ((long)_TestTypeName.Key == 0 ? null : _TestTypeName); }
            set 
            { 
                _TestTypeName = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsTestType = _TestTypeName == null 
                    ? new Int64?()
                    : _TestTypeName.idfsBaseReference; 
                OnPropertyChanged(_str_TestTypeName); 
            }
        }
        private BaseReference _TestTypeName;

        
        public BaseReferenceList TestTypeNameLookup
        {
            get { return _TestTypeNameLookup; }
        }
        private BaseReferenceList _TestTypeNameLookup = new BaseReferenceList("rftTestType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsBatchStatus)]
        public BaseReference BatchStatusName
        {
            get { return _BatchStatusName == null ? null : ((long)_BatchStatusName.Key == 0 ? null : _BatchStatusName); }
            set 
            { 
                _BatchStatusName = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsBatchStatus = _BatchStatusName == null 
                    ? new Int64?()
                    : _BatchStatusName.idfsBaseReference; 
                OnPropertyChanged(_str_BatchStatusName); 
            }
        }
        private BaseReference _BatchStatusName;

        
        public BaseReferenceList BatchStatusNameLookup
        {
            get { return _BatchStatusNameLookup; }
        }
        private BaseReferenceList _BatchStatusNameLookup = new BaseReferenceList("rftActivityStatus");
            
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsDiagnosis = _Diagnosis == null 
                    ? new Int64()
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
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestStatus)]
        public BaseReference TestStatus
        {
            get { return _TestStatus == null ? null : ((long)_TestStatus.Key == 0 ? null : _TestStatus); }
            set 
            { 
                _TestStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsTestStatus = _TestStatus == null 
                    ? new Int64()
                    : _TestStatus.idfsBaseReference; 
                OnPropertyChanged(_str_TestStatus); 
            }
        }
        private BaseReference _TestStatus;

        
        public BaseReferenceList TestStatusLookup
        {
            get { return _TestStatusLookup; }
        }
        private BaseReferenceList _TestStatusLookup = new BaseReferenceList("rftActivityStatus");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestForDiseaseType)]
        public BaseReference TestForDiseaseType
        {
            get { return _TestForDiseaseType == null ? null : ((long)_TestForDiseaseType.Key == 0 ? null : _TestForDiseaseType); }
            set 
            { 
                _TestForDiseaseType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsTestForDiseaseType = _TestForDiseaseType == null 
                    ? new Int64?()
                    : _TestForDiseaseType.idfsBaseReference; 
                OnPropertyChanged(_str_TestForDiseaseType); 
            }
        }
        private BaseReference _TestForDiseaseType;

        
        public BaseReferenceList TestForDiseaseTypeLookup
        {
            get { return _TestForDiseaseTypeLookup; }
        }
        private BaseReferenceList _TestForDiseaseTypeLookup = new BaseReferenceList("rftTestForDiseaseType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestResult)]
        public BaseReference TestResultRef
        {
            get { return _TestResultRef == null ? null : ((long)_TestResultRef.Key == 0 ? null : _TestResultRef); }
            set 
            { 
                _TestResultRef = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsTestResult = _TestResultRef == null 
                    ? new Int64?()
                    : _TestResultRef.idfsBaseReference; 
                OnPropertyChanged(_str_TestResultRef); 
            }
        }
        private BaseReference _TestResultRef;

        
        public BaseReferenceList TestResultRefLookup
        {
            get { return _TestResultRefLookup; }
        }
        private BaseReferenceList _TestResultRefLookup = new BaseReferenceList("rftTestResult");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_TestTypeName:
                    return new BvSelectList(TestTypeNameLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestTypeName, _str_idfsTestType);
            
                case _str_BatchStatusName:
                    return new BvSelectList(BatchStatusNameLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, BatchStatusName, _str_idfsBatchStatus);
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_SampleType:
                    return new BvSelectList(SampleTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SampleType, _str_idfsSpecimenType);
            
                case _str_TestStatus:
                    return new BvSelectList(TestStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestStatus, _str_idfsTestStatus);
            
                case _str_TestForDiseaseType:
                    return new BvSelectList(TestForDiseaseTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestForDiseaseType, _str_idfsTestForDiseaseType);
            
                case _str_TestResultRef:
                    return new BvSelectList(TestResultRefLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestResultRef, _str_idfsTestResult);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LabTestListItem";

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
            var ret = base.Clone() as LabTestListItem;
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
            var ret = base.Clone() as LabTestListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public LabTestListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabTestListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfTesting; } }
        public string KeyName { get { return "idfTesting"; } }
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
        
            var _prev_idfsTestType_TestTypeName = idfsTestType;
            var _prev_idfsBatchStatus_BatchStatusName = idfsBatchStatus;
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfsSpecimenType_SampleType = idfsSpecimenType;
            var _prev_idfsTestStatus_TestStatus = idfsTestStatus;
            var _prev_idfsTestForDiseaseType_TestForDiseaseType = idfsTestForDiseaseType;
            var _prev_idfsTestResult_TestResultRef = idfsTestResult;
            base.RejectChanges();
        
            if (_prev_idfsTestType_TestTypeName != idfsTestType)
            {
                _TestTypeName = _TestTypeNameLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestType);
            }
            if (_prev_idfsBatchStatus_BatchStatusName != idfsBatchStatus)
            {
                _BatchStatusName = _BatchStatusNameLookup.FirstOrDefault(c => c.idfsBaseReference == idfsBatchStatus);
            }
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsSpecimenType_SampleType != idfsSpecimenType)
            {
                _SampleType = _SampleTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSpecimenType);
            }
            if (_prev_idfsTestStatus_TestStatus != idfsTestStatus)
            {
                _TestStatus = _TestStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestStatus);
            }
            if (_prev_idfsTestForDiseaseType_TestForDiseaseType != idfsTestForDiseaseType)
            {
                _TestForDiseaseType = _TestForDiseaseTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestForDiseaseType);
            }
            if (_prev_idfsTestResult_TestResultRef != idfsTestResult)
            {
                _TestResultRef = _TestResultRefLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestResult);
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

      private bool IsRIRPropChanged(string fld, LabTestListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabTestListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabTestListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabTestListItem_PropertyChanged);
        }
        private void LabTestListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabTestListItem).Changed(e.PropertyName);
            
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
            LabTestListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabTestListItem obj = this;
            
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


        public Dictionary<string, Func<LabTestListItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabTestListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabTestListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabTestListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabTestListItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<LabTestListItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LabTestListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftTestType", this);
                
                LookupManager.RemoveObject("rftActivityStatus", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftSpecimenType", this);
                
                LookupManager.RemoveObject("rftActivityStatus", this);
                
                LookupManager.RemoveObject("rftTestForDiseaseType", this);
                
                LookupManager.RemoveObject("rftTestResult", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftTestType")
                _getAccessor().LoadLookup_TestTypeName(manager, this);
            
            if (lookup_object == "rftActivityStatus")
                _getAccessor().LoadLookup_BatchStatusName(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftSpecimenType")
                _getAccessor().LoadLookup_SampleType(manager, this);
            
            if (lookup_object == "rftActivityStatus")
                _getAccessor().LoadLookup_TestStatus(manager, this);
            
            if (lookup_object == "rftTestForDiseaseType")
                _getAccessor().LoadLookup_TestForDiseaseType(manager, this);
            
            if (lookup_object == "rftTestResult")
                _getAccessor().LoadLookup_TestResultRef(manager, this);
            
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
        public class LabTestListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfTesting { get; set; }
        
            public String BatchTestCode { get; set; }
        
            public String TestType { get; set; }
        
            public String TestCategory { get; set; }
        
            public String Status { get; set; }
        
            public String TestResult { get; set; }
        
            public DateTime? datConcludedDate { get; set; }
        
            public String strBarcode { get; set; }
        
            public String SpecimenType { get; set; }
        
            public String strFieldBarcode { get; set; }
        
            public DateTime? datCreationDate { get; set; }
        
            public String DepartmentName { get; set; }
        
            public String CaseID { get; set; }
        
            public String DiagnosisName { get; set; }
        
            public String HumanName { get; set; }
        
            public String AnimalName { get; set; }
        
        }
        public partial class LabTestListItemGridModelList : List<LabTestListItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public LabTestListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabTestListItem>, errMes);
            }
            public LabTestListItemGridModelList(long key, IEnumerable<LabTestListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<LabTestListItem> items);
            private void LoadGridModelList(long key, IEnumerable<LabTestListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_BatchTestCode,_str_TestType,_str_TestCategory,_str_Status,_str_TestResult,_str_datConcludedDate,_str_strBarcode,_str_SpecimenType,_str_strFieldBarcode,_str_datCreationDate,_str_DepartmentName,_str_CaseID,_str_DiagnosisName,_str_HumanName,_str_AnimalName};
                    
                Hiddens = new List<string> {_str_idfTesting};
                Keys = new List<string> {_str_idfTesting};
                Labels = new Dictionary<string, string> {{_str_BatchTestCode, _str_BatchTestCode},{_str_TestType, _str_TestType},{_str_TestCategory, _str_TestCategory},{_str_Status, _str_Status},{_str_TestResult, _str_TestResult},{_str_datConcludedDate, _str_datConcludedDate},{_str_strBarcode, "strLabBarcode"},{_str_SpecimenType, _str_SpecimenType},{_str_strFieldBarcode, _str_strFieldBarcode},{_str_datCreationDate, "datAccession"},{_str_DepartmentName, _str_DepartmentName},{_str_CaseID, _str_CaseID},{_str_DiagnosisName, "TestDiagnosisName"},{_str_HumanName, _str_HumanName},{_str_AnimalName, _str_AnimalName}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<LabTestListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new LabTestListItemGridModel()
                {
                    ItemKey=c.idfTesting,BatchTestCode=c.BatchTestCode,TestType=c.TestType,TestCategory=c.TestCategory,Status=c.Status,TestResult=c.TestResult,datConcludedDate=c.datConcludedDate,strBarcode=c.strBarcode,SpecimenType=c.SpecimenType,strFieldBarcode=c.strFieldBarcode,datCreationDate=c.datCreationDate,DepartmentName=c.DepartmentName,CaseID=c.CaseID,DiagnosisName=c.DiagnosisName,HumanName=c.HumanName,AnimalName=c.AnimalName
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
        : DataAccessor<LabTestListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectList
                    
            , IObjectPost
                    
        {
            private delegate void on_action(LabTestListItem obj);
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
            private BaseReference.Accessor TestTypeNameAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor BatchStatusNameAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SampleTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestForDiseaseTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestResultRefAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<LabTestListItem> SelectListT(DbManagerProxy manager
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
            
            private List<LabTestListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_LabTest_SelectList.* from dbo.fn_LabTest_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("BatchTestIsNull"))
                {
                    
                    sql.Append(" " + @"");
                      
                }
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("BatchTestIsNull"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("BatchTestIsNull") == 1)
                    {
                        sql.AppendFormat("idfBatchTest is null", filters.Operation("BatchTestIsNull"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("BatchTestIsNull"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("BatchTestIsNull") ? " or " : " and ");
                            sql.AppendFormat("@BatchTestIsNull_{1}", filters.Operation("BatchTestIsNull", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfTesting"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfTesting"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfTesting") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_LabTest_SelectList.idfTesting,0) {0} @idfTesting_{1}", filters.Operation("idfTesting", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsTestType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsTestType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsTestType") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_LabTest_SelectList.idfsTestType,0) {0} @idfsTestType_{1}", filters.Operation("idfsTestType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsTestStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsTestStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsTestStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_LabTest_SelectList.idfsTestStatus,0) {0} @idfsTestStatus_{1}", filters.Operation("idfsTestStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfObservation"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfObservation"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfObservation") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_LabTest_SelectList.idfObservation,0) {0} @idfObservation_{1}", filters.Operation("idfObservation", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("TestType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("TestType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("TestType") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LabTest_SelectList.TestType {0} @TestType_{1}", filters.Operation("TestType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("TestResult"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("TestResult"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("TestResult") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LabTest_SelectList.TestResult {0} @TestResult_{1}", filters.Operation("TestResult", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("TestCategory"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("TestCategory"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("TestCategory") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LabTest_SelectList.TestCategory {0} @TestCategory_{1}", filters.Operation("TestCategory", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsTestForDiseaseType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsTestForDiseaseType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsTestForDiseaseType") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_LabTest_SelectList.idfsTestForDiseaseType,0) {0} @idfsTestForDiseaseType_{1}", filters.Operation("idfsTestForDiseaseType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfBatchTest"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfBatchTest"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfBatchTest") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_LabTest_SelectList.idfBatchTest,0) {0} @idfBatchTest_{1}", filters.Operation("idfBatchTest", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("BatchTestCode"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("BatchTestCode"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("BatchTestCode") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LabTest_SelectList.BatchTestCode {0} @BatchTestCode_{1}", filters.Operation("BatchTestCode", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datConcludedDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datConcludedDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datConcludedDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LabTest_SelectList.datConcludedDate, 112) {0} CONVERT(NVARCHAR(8), @datConcludedDate_{1}, 112)", filters.Operation("datConcludedDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datPerformedDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datPerformedDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datPerformedDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LabTest_SelectList.datPerformedDate, 112) {0} CONVERT(NVARCHAR(8), @datPerformedDate_{1}, 112)", filters.Operation("datPerformedDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("Status"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("Status"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("Status") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LabTest_SelectList.Status {0} @Status_{1}", filters.Operation("Status", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LabTest_SelectList.strBarcode {0} @strBarcode_{1}", filters.Operation("strBarcode", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LabTest_SelectList.SpecimenType {0} @SpecimenType_{1}", filters.Operation("SpecimenType", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_LabTest_SelectList.idfCase,0) {0} @idfCase_{1}", filters.Operation("idfCase", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_LabTest_SelectList.idfsCaseType,0) {0} @idfsCaseType_{1}", filters.Operation("idfsCaseType", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LabTest_SelectList.CaseID {0} @CaseID_{1}", filters.Operation("CaseID", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LabTest_SelectList.DiagnosisName {0} @DiagnosisName_{1}", filters.Operation("DiagnosisName", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_LabTest_SelectList.idfsDiagnosis,0) {0} @idfsDiagnosis_{1}", filters.Operation("idfsDiagnosis", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_LabTest_SelectList.idfsSpecimenType,0) {0} @idfsSpecimenType_{1}", filters.Operation("idfsSpecimenType", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LabTest_SelectList.DepartmentName {0} @DepartmentName_{1}", filters.Operation("DepartmentName", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LabTest_SelectList.datFieldCollectionDate, 112) {0} CONVERT(NVARCHAR(8), @datFieldCollectionDate_{1}, 112)", filters.Operation("datFieldCollectionDate", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LabTest_SelectList.datCreationDate, 112) {0} CONVERT(NVARCHAR(8), @datCreationDate_{1}, 112)", filters.Operation("datCreationDate", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LabTest_SelectList.datAccession, 112) {0} CONVERT(NVARCHAR(8), @datAccession_{1}, 112)", filters.Operation("datAccession", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LabTest_SelectList.strFieldBarcode {0} @strFieldBarcode_{1}", filters.Operation("strFieldBarcode", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LabTest_SelectList.HumanName {0} @HumanName_{1}", filters.Operation("HumanName", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LabTest_SelectList.AnimalName {0} @AnimalName_{1}", filters.Operation("AnimalName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsBatchStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsBatchStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsBatchStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_LabTest_SelectList.idfsBatchStatus,0) {0} @idfsBatchStatus_{1}", filters.Operation("idfsBatchStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsTestResult"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsTestResult"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsTestResult") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_LabTest_SelectList.idfsTestResult,0) {0} @idfsTestResult_{1}", filters.Operation("idfsTestResult", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LabTest_SelectList.strPatientName {0} @strPatientName_{1}", filters.Operation("strPatientName", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LabTest_SelectList.strFarmOwner {0} @strFarmOwner_{1}", filters.Operation("strFarmOwner", i), i);
                            
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
                    
                    if (filters.Contains("idfTesting"))
                        for (int i = 0; i < filters.Count("idfTesting"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfTesting_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfTesting", i), filters.Value("idfTesting", i))));
                      
                    if (filters.Contains("idfsTestType"))
                        for (int i = 0; i < filters.Count("idfsTestType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestType", i), filters.Value("idfsTestType", i))));
                      
                    if (filters.Contains("idfsTestStatus"))
                        for (int i = 0; i < filters.Count("idfsTestStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestStatus", i), filters.Value("idfsTestStatus", i))));
                      
                    if (filters.Contains("idfObservation"))
                        for (int i = 0; i < filters.Count("idfObservation"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfObservation_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfObservation", i), filters.Value("idfObservation", i))));
                      
                    if (filters.Contains("TestType"))
                        for (int i = 0; i < filters.Count("TestType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@TestType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("TestType", i), filters.Value("TestType", i))));
                      
                    if (filters.Contains("TestResult"))
                        for (int i = 0; i < filters.Count("TestResult"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@TestResult_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("TestResult", i), filters.Value("TestResult", i))));
                      
                    if (filters.Contains("TestCategory"))
                        for (int i = 0; i < filters.Count("TestCategory"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@TestCategory_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("TestCategory", i), filters.Value("TestCategory", i))));
                      
                    if (filters.Contains("idfsTestForDiseaseType"))
                        for (int i = 0; i < filters.Count("idfsTestForDiseaseType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestForDiseaseType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestForDiseaseType", i), filters.Value("idfsTestForDiseaseType", i))));
                      
                    if (filters.Contains("idfBatchTest"))
                        for (int i = 0; i < filters.Count("idfBatchTest"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfBatchTest_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfBatchTest", i), filters.Value("idfBatchTest", i))));
                      
                    if (filters.Contains("BatchTestCode"))
                        for (int i = 0; i < filters.Count("BatchTestCode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@BatchTestCode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("BatchTestCode", i), filters.Value("BatchTestCode", i))));
                      
                    if (filters.Contains("datConcludedDate"))
                        for (int i = 0; i < filters.Count("datConcludedDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datConcludedDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datConcludedDate", i), filters.Value("datConcludedDate", i))));
                      
                    if (filters.Contains("datPerformedDate"))
                        for (int i = 0; i < filters.Count("datPerformedDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datPerformedDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datPerformedDate", i), filters.Value("datPerformedDate", i))));
                      
                    if (filters.Contains("Status"))
                        for (int i = 0; i < filters.Count("Status"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@Status_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("Status", i), filters.Value("Status", i))));
                      
                    if (filters.Contains("strBarcode"))
                        for (int i = 0; i < filters.Count("strBarcode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strBarcode", i), filters.Value("strBarcode", i))));
                      
                    if (filters.Contains("SpecimenType"))
                        for (int i = 0; i < filters.Count("SpecimenType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@SpecimenType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("SpecimenType", i), filters.Value("SpecimenType", i))));
                      
                    if (filters.Contains("idfCase"))
                        for (int i = 0; i < filters.Count("idfCase"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfCase_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfCase", i), filters.Value("idfCase", i))));
                      
                    if (filters.Contains("idfsCaseType"))
                        for (int i = 0; i < filters.Count("idfsCaseType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseType", i), filters.Value("idfsCaseType", i))));
                      
                    if (filters.Contains("CaseID"))
                        for (int i = 0; i < filters.Count("CaseID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@CaseID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("CaseID", i), filters.Value("CaseID", i))));
                      
                    if (filters.Contains("DiagnosisName"))
                        for (int i = 0; i < filters.Count("DiagnosisName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@DiagnosisName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("DiagnosisName", i), filters.Value("DiagnosisName", i))));
                      
                    if (filters.Contains("idfsDiagnosis"))
                        for (int i = 0; i < filters.Count("idfsDiagnosis"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosis", i), filters.Value("idfsDiagnosis", i))));
                      
                    if (filters.Contains("idfsSpecimenType"))
                        for (int i = 0; i < filters.Count("idfsSpecimenType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSpecimenType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSpecimenType", i), filters.Value("idfsSpecimenType", i))));
                      
                    if (filters.Contains("DepartmentName"))
                        for (int i = 0; i < filters.Count("DepartmentName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@DepartmentName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("DepartmentName", i), filters.Value("DepartmentName", i))));
                      
                    if (filters.Contains("datFieldCollectionDate"))
                        for (int i = 0; i < filters.Count("datFieldCollectionDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datFieldCollectionDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datFieldCollectionDate", i), filters.Value("datFieldCollectionDate", i))));
                      
                    if (filters.Contains("datCreationDate"))
                        for (int i = 0; i < filters.Count("datCreationDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datCreationDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datCreationDate", i), filters.Value("datCreationDate", i))));
                      
                    if (filters.Contains("datAccession"))
                        for (int i = 0; i < filters.Count("datAccession"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datAccession_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datAccession", i), filters.Value("datAccession", i))));
                      
                    if (filters.Contains("strFieldBarcode"))
                        for (int i = 0; i < filters.Count("strFieldBarcode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFieldBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFieldBarcode", i), filters.Value("strFieldBarcode", i))));
                      
                    if (filters.Contains("HumanName"))
                        for (int i = 0; i < filters.Count("HumanName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@HumanName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("HumanName", i), filters.Value("HumanName", i))));
                      
                    if (filters.Contains("AnimalName"))
                        for (int i = 0; i < filters.Count("AnimalName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@AnimalName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("AnimalName", i), filters.Value("AnimalName", i))));
                      
                    if (filters.Contains("idfsBatchStatus"))
                        for (int i = 0; i < filters.Count("idfsBatchStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsBatchStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsBatchStatus", i), filters.Value("idfsBatchStatus", i))));
                      
                    if (filters.Contains("idfsTestResult"))
                        for (int i = 0; i < filters.Count("idfsTestResult"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestResult_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestResult", i), filters.Value("idfsTestResult", i))));
                      
                    if (filters.Contains("strPatientName"))
                        for (int i = 0; i < filters.Count("strPatientName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strPatientName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strPatientName", i), filters.Value("strPatientName", i))));
                      
                    if (filters.Contains("strFarmOwner"))
                        for (int i = 0; i < filters.Count("strFarmOwner"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFarmOwner_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFarmOwner", i), filters.Value("strFarmOwner", i))));
                      
                    List<LabTestListItem> objs = manager.ExecuteList<LabTestListItem>();
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
        
            [SprocName("spLabTest_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabTestListItem obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LabTestListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabTestListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabTestListItem obj = LabTestListItem.CreateInstance();
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

            
            public LabTestListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public LabTestListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult MakeBatch(DbManagerProxy manager, LabTestListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is object)) 
                    throw new TypeMismatchException("key", typeof(object));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return MakeBatch(manager, obj
                    , (object)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult MakeBatch(DbManagerProxy manager, LabTestListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MakeBatch"))
                    throw new PermissionException("Test", "MakeBatch");
                
                return true;
                
            }
            
            private void _SetupChildHandlers(LabTestListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabTestListItem obj)
            {
                
            }
    
            public void LoadLookup_TestTypeName(DbManagerProxy manager, LabTestListItem obj)
            {
                
                obj.TestTypeNameLookup.Clear();
                
                obj.TestTypeNameLookup.Add(TestTypeNameAccessor.CreateNewT(manager, null));
                
                obj.TestTypeNameLookup.AddRange(TestTypeNameAccessor.rftTestType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestType))
                    
                    .ToList());
                
                if (obj.idfsTestType != null && obj.idfsTestType != 0)
                {
                    obj.TestTypeName = obj.TestTypeNameLookup
                        .Where(c => c.idfsBaseReference == obj.idfsTestType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftTestType", obj, TestTypeNameAccessor.GetType(), "rftTestType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_BatchStatusName(DbManagerProxy manager, LabTestListItem obj)
            {
                
                obj.BatchStatusNameLookup.Clear();
                
                obj.BatchStatusNameLookup.Add(BatchStatusNameAccessor.CreateNewT(manager, null));
                
                obj.BatchStatusNameLookup.AddRange(BatchStatusNameAccessor.rftActivityStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsBatchStatus))
                    
                    .ToList());
                
                if (obj.idfsBatchStatus != null && obj.idfsBatchStatus != 0)
                {
                    obj.BatchStatusName = obj.BatchStatusNameLookup
                        .Where(c => c.idfsBaseReference == obj.idfsBatchStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftActivityStatus", obj, BatchStatusNameAccessor.GetType(), "rftActivityStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Diagnosis(DbManagerProxy manager, LabTestListItem obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.All) != 0) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .Where(c => c.idfsDiagnosis == obj.idfsDiagnosis)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_SampleType(DbManagerProxy manager, LabTestListItem obj)
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
            
            public void LoadLookup_TestStatus(DbManagerProxy manager, LabTestListItem obj)
            {
                
                obj.TestStatusLookup.Clear();
                
                obj.TestStatusLookup.Add(TestStatusAccessor.CreateNewT(manager, null));
                
                obj.TestStatusLookup.AddRange(TestStatusAccessor.rftActivityStatus_SelectList(manager
                    
                    )
                    .Where(c => c.idfsBaseReference == (long)BatchStatusEnum.Completed || c.idfsBaseReference == (long)BatchStatusEnum.InProcess || c.idfsBaseReference == (long)BatchStatusEnum.Undefined || c.idfsBaseReference == (long)BatchStatusEnum.Amended)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestStatus))
                    
                    .ToList());
                
                if (obj.idfsTestStatus != 0)
                {
                    obj.TestStatus = obj.TestStatusLookup
                        .Where(c => c.idfsBaseReference == obj.idfsTestStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftActivityStatus", obj, TestStatusAccessor.GetType(), "rftActivityStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_TestForDiseaseType(DbManagerProxy manager, LabTestListItem obj)
            {
                
                obj.TestForDiseaseTypeLookup.Clear();
                
                obj.TestForDiseaseTypeLookup.Add(TestForDiseaseTypeAccessor.CreateNewT(manager, null));
                
                obj.TestForDiseaseTypeLookup.AddRange(TestForDiseaseTypeAccessor.rftTestForDiseaseType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestForDiseaseType))
                    
                    .ToList());
                
                if (obj.idfsTestForDiseaseType != null && obj.idfsTestForDiseaseType != 0)
                {
                    obj.TestForDiseaseType = obj.TestForDiseaseTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsTestForDiseaseType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftTestForDiseaseType", obj, TestForDiseaseTypeAccessor.GetType(), "rftTestForDiseaseType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_TestResultRef(DbManagerProxy manager, LabTestListItem obj)
            {
                
                obj.TestResultRefLookup.Clear();
                
                obj.TestResultRefLookup.Add(TestResultRefAccessor.CreateNewT(manager, null));
                
                obj.TestResultRefLookup.AddRange(TestResultRefAccessor.rftTestResult_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestResult))
                    
                    .ToList());
                
                if (obj.idfsTestResult != null && obj.idfsTestResult != 0)
                {
                    obj.TestResultRef = obj.TestResultRefLookup
                        .Where(c => c.idfsBaseReference == obj.idfsTestResult)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftTestResult", obj, TestResultRefAccessor.GetType(), "rftTestResult_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, LabTestListItem obj)
            {
                
                LoadLookup_TestTypeName(manager, obj);
                
                LoadLookup_BatchStatusName(manager, obj);
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_SampleType(manager, obj);
                
                LoadLookup_TestStatus(manager, obj);
                
                LoadLookup_TestForDiseaseType(manager, obj);
                
                LoadLookup_TestResultRef(manager, obj);
                
            }
    
            [SprocName("spLabTest_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spLabTest_Delete")]
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
                    LabTestListItem bo = obj as LabTestListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("Test", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("Test", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("Test", "Update");
                    }
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        long mainObject = bo.idfTesting;
                        
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
                            
                            if (bo.idfsTestStatus != bo.idfsTestStatus_Original && bo.idfsTestStatus == (long)BatchStatusEnum.Completed)
                            {
                                eidss.model.Enums.EventType eventType = eidss.model.Enums.EventType.NewTestResult;
                                manager.SetEventParams("NewTestResult", new object[] { eventType, mainObject, "" });
                            }
                            
                        }
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoTest;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbTesting;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as LabTestListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, LabTestListItem obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfTesting
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
            
            public bool ValidateCanDelete(LabTestListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, LabTestListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfTesting
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
                return Validate(manager, obj as LabTestListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabTestListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(LabTestListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LabTestListItem obj)
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
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabTestListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabTestListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabTestListItemDetail"; } }
            public string HelpIdWin { get { return "lab_tests_list"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private LabTestListItem m_obj;
            internal Permissions(LabTestListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_LabTest_SelectList";
            public static string spCount = "spLabTest_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spLabTest_Delete";
            public static string spCanDelete = "spLabTest_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabTestListItem, bool>> RequiredByField = new Dictionary<string, Func<LabTestListItem, bool>>();
            public static Dictionary<string, Func<LabTestListItem, bool>> RequiredByProperty = new Dictionary<string, Func<LabTestListItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_TestType, 2000);
                Sizes.Add(_str_TestResult, 2000);
                Sizes.Add(_str_TestCategory, 2000);
                Sizes.Add(_str_BatchTestCode, 200);
                Sizes.Add(_str_Status, 2000);
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_SpecimenType, 2000);
                Sizes.Add(_str_CaseID, 200);
                Sizes.Add(_str_DiagnosisName, 2000);
                Sizes.Add(_str_DepartmentName, 2000);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_HumanName, 200);
                Sizes.Add(_str_AnimalName, 2000);
                Sizes.Add(_str_strPatientName, 200);
                Sizes.Add(_str_strFarmOwner, 200);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestType",
                    EditorType.Lookup,
                    false, false, 
                    "TestType",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "TestTypeNameLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "BatchTestCode",
                    EditorType.Text,
                    false, false, 
                    "BatchTestCode",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestStatus",
                    EditorType.Lookup,
                    false, false, 
                    "Status",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "TestStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datConcludedDate",
                    EditorType.Date,
                    true, true, 
                    "datConcludedDate",
                    () => DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter), null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "CaseID",
                    EditorType.Text,
                    false, false, 
                    "CaseID",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsDiagnosis",
                    EditorType.Lookup,
                    false, false, 
                    "TestDiagnosisName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "DiagnosisLookup", typeof(DiagnosisLookup), (o) => { var c = (DiagnosisLookup)o; return c.idfsDiagnosis; }, (o) => { var c = (DiagnosisLookup)o; return c.name; }
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
                    "AnimalName",
                    EditorType.Text,
                    false, false, 
                    "AnimalName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strBarcode",
                    EditorType.Text,
                    false, false, 
                    "strLabBarcode",
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
                    "datCreationDate",
                    EditorType.Date,
                    true, false, 
                    "datAccession",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSpecimenType",
                    EditorType.Lookup,
                    false, false, 
                    "SpecimenType",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "SampleTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfTesting,
                    _str_idfTesting, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_BatchTestCode,
                    _str_BatchTestCode, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestType,
                    _str_TestType, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestCategory,
                    _str_TestCategory, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Status,
                    _str_Status, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestResult,
                    _str_TestResult, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datConcludedDate,
                    _str_datConcludedDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBarcode,
                    "strLabBarcode", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_SpecimenType,
                    _str_SpecimenType, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode,
                    _str_strFieldBarcode, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datCreationDate,
                    "datAccession", null, true, true, null
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
                    "TestDiagnosisName", null, true, true, ListSortDirection.Descending
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_HumanName,
                    _str_HumanName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalName,
                    _str_AnimalName, null, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "MakeBatch",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MakeBatch(manager, (LabTestListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strMakeBatch_Id",
                        "edit",
                        /*from BvMessages*/"strMakeBatch_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    "Test.Update",
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<LabTest>().SelectDetail(manager, pars[0])),
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
                                c = ObjectAccessor.CreatorInterface<LabTestListItem>().CreateWithParams(manager, null, pars);
                                ((LabTestListItem)c).idfTesting = (long)pars[0];
                                ((LabTestListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((LabTestListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<LabTestListItem>().Post(manager, (LabTestListItem)c), c);
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
	