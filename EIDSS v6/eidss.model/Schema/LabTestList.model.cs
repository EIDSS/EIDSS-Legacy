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
                
        [LocalizedDisplayName(_str_idfsTestName)]
        [MapField(_str_idfsTestName)]
        public abstract Int64? idfsTestName { get; set; }
        protected Int64? idfsTestName_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestName).OriginalValue; } }
        protected Int64? idfsTestName_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTestStatus)]
        [MapField(_str_idfsTestStatus)]
        public abstract Int64 idfsTestStatus { get; set; }
        protected Int64 idfsTestStatus_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsTestStatus).OriginalValue; } }
        protected Int64 idfsTestStatus_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsTestStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfObservation)]
        [MapField(_str_idfObservation)]
        public abstract Int64 idfObservation { get; set; }
        protected Int64 idfObservation_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfObservation).OriginalValue; } }
        protected Int64 idfObservation_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfObservation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_TestName)]
        [MapField(_str_TestName)]
        public abstract String TestName { get; set; }
        protected String TestName_Original { get { return ((EditableValue<String>)((dynamic)this)._testName).OriginalValue; } }
        protected String TestName_Previous { get { return ((EditableValue<String>)((dynamic)this)._testName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_TestResult)]
        [MapField(_str_TestResult)]
        public abstract String TestResult { get; set; }
        protected String TestResult_Original { get { return ((EditableValue<String>)((dynamic)this)._testResult).OriginalValue; } }
        protected String TestResult_Previous { get { return ((EditableValue<String>)((dynamic)this)._testResult).PreviousValue; } }
                
        [LocalizedDisplayName(_str_TestCategory)]
        [MapField(_str_TestCategory)]
        public abstract String TestCategory { get; set; }
        protected String TestCategory_Original { get { return ((EditableValue<String>)((dynamic)this)._testCategory).OriginalValue; } }
        protected String TestCategory_Previous { get { return ((EditableValue<String>)((dynamic)this)._testCategory).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTestCategory)]
        [MapField(_str_idfsTestCategory)]
        public abstract Int64? idfsTestCategory { get; set; }
        protected Int64? idfsTestCategory_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestCategory).OriginalValue; } }
        protected Int64? idfsTestCategory_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestCategory).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfBatchTest)]
        [MapField(_str_idfBatchTest)]
        public abstract Int64? idfBatchTest { get; set; }
        protected Int64? idfBatchTest_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfBatchTest).OriginalValue; } }
        protected Int64? idfBatchTest_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfBatchTest).PreviousValue; } }
                
        [LocalizedDisplayName(_str_BatchTestCode)]
        [MapField(_str_BatchTestCode)]
        public abstract String BatchTestCode { get; set; }
        protected String BatchTestCode_Original { get { return ((EditableValue<String>)((dynamic)this)._batchTestCode).OriginalValue; } }
        protected String BatchTestCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._batchTestCode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datConcludedDate)]
        [MapField(_str_datConcludedDate)]
        public abstract DateTime? datConcludedDate { get; set; }
        protected DateTime? datConcludedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datConcludedDate).OriginalValue; } }
        protected DateTime? datConcludedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datConcludedDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datPerformedDate)]
        [MapField(_str_datPerformedDate)]
        public abstract DateTime? datPerformedDate { get; set; }
        protected DateTime? datPerformedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPerformedDate).OriginalValue; } }
        protected DateTime? datPerformedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPerformedDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_Status)]
        [MapField(_str_Status)]
        public abstract String Status { get; set; }
        protected String Status_Original { get { return ((EditableValue<String>)((dynamic)this)._status).OriginalValue; } }
        protected String Status_Previous { get { return ((EditableValue<String>)((dynamic)this)._status).PreviousValue; } }
                
        [LocalizedDisplayName("strLabBarcode")]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_idfHumanCase)]
        [MapField(_str_idfHumanCase)]
        public abstract Int64? idfHumanCase { get; set; }
        protected Int64? idfHumanCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHumanCase).OriginalValue; } }
        protected Int64? idfHumanCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHumanCase).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfVetCase)]
        [MapField(_str_idfVetCase)]
        public abstract Int64? idfVetCase { get; set; }
        protected Int64? idfVetCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVetCase).OriginalValue; } }
        protected Int64? idfVetCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVetCase).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_idfsCaseType)]
        [MapField(_str_idfsCaseType)]
        public abstract Int64? idfsCaseType { get; set; }
        protected Int64? idfsCaseType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).OriginalValue; } }
        protected Int64? idfsCaseType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_CaseID)]
        [MapField(_str_CaseID)]
        public abstract String CaseID { get; set; }
        protected String CaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._caseID).OriginalValue; } }
        protected String CaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._caseID).PreviousValue; } }
                
        [LocalizedDisplayName("TestDiagnosisName")]
        [MapField(_str_DiagnosisName)]
        public abstract String DiagnosisName { get; set; }
        protected String DiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).OriginalValue; } }
        protected String DiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsDiagnosis)]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64 idfsDiagnosis { get; set; }
        protected Int64 idfsDiagnosis_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64 idfsDiagnosis_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSampleType)]
        [MapField(_str_idfsSampleType)]
        public abstract Int64 idfsSampleType { get; set; }
        protected Int64 idfsSampleType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSampleType).OriginalValue; } }
        protected Int64 idfsSampleType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSampleType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DepartmentName)]
        [MapField(_str_DepartmentName)]
        public abstract String DepartmentName { get; set; }
        protected String DepartmentName_Original { get { return ((EditableValue<String>)((dynamic)this)._departmentName).OriginalValue; } }
        protected String DepartmentName_Previous { get { return ((EditableValue<String>)((dynamic)this)._departmentName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFieldCollectionDate)]
        [MapField(_str_datFieldCollectionDate)]
        public abstract DateTime? datFieldCollectionDate { get; set; }
        protected DateTime? datFieldCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).OriginalValue; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datAccession)]
        [MapField(_str_datAccession)]
        public abstract DateTime? datAccession { get; set; }
        protected DateTime? datAccession_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).OriginalValue; } }
        protected DateTime? datAccession_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFieldBarcode)]
        [MapField(_str_strFieldBarcode)]
        public abstract String strFieldBarcode { get; set; }
        protected String strFieldBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).OriginalValue; } }
        protected String strFieldBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_idfsBatchStatus)]
        [MapField(_str_idfsBatchStatus)]
        public abstract Int64? idfsBatchStatus { get; set; }
        protected Int64? idfsBatchStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBatchStatus).OriginalValue; } }
        protected Int64? idfsBatchStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBatchStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTestResult)]
        [MapField(_str_idfsTestResult)]
        public abstract Int64? idfsTestResult { get; set; }
        protected Int64? idfsTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).OriginalValue; } }
        protected Int64? idfsTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).PreviousValue; } }
                
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
            internal Func<LabTestListItem, object> _get_func;
            internal Action<LabTestListItem, string> _set_func;
            internal Action<LabTestListItem, LabTestListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfTesting = "idfTesting";
        internal const string _str_idfsTestName = "idfsTestName";
        internal const string _str_idfsTestStatus = "idfsTestStatus";
        internal const string _str_idfObservation = "idfObservation";
        internal const string _str_TestName = "TestName";
        internal const string _str_TestResult = "TestResult";
        internal const string _str_TestCategory = "TestCategory";
        internal const string _str_idfsTestCategory = "idfsTestCategory";
        internal const string _str_idfBatchTest = "idfBatchTest";
        internal const string _str_BatchTestCode = "BatchTestCode";
        internal const string _str_datConcludedDate = "datConcludedDate";
        internal const string _str_datPerformedDate = "datPerformedDate";
        internal const string _str_Status = "Status";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_strSampleName = "strSampleName";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfHumanCase = "idfHumanCase";
        internal const string _str_idfVetCase = "idfVetCase";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_CaseID = "CaseID";
        internal const string _str_DiagnosisName = "DiagnosisName";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_idfsSampleType = "idfsSampleType";
        internal const string _str_DepartmentName = "DepartmentName";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_datAccession = "datAccession";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_HumanName = "HumanName";
        internal const string _str_AnimalName = "AnimalName";
        internal const string _str_idfsBatchStatus = "idfsBatchStatus";
        internal const string _str_idfsTestResult = "idfsTestResult";
        internal const string _str_strPatientName = "strPatientName";
        internal const string _str_strFarmOwner = "strFarmOwner";
        internal const string _str_TestNameRef = "TestNameRef";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_SampleType = "SampleType";
        internal const string _str_TestStatus = "TestStatus";
        internal const string _str_TestCategoryRef = "TestCategoryRef";
        internal const string _str_TestResultRef = "TestResultRef";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfTesting, _formname = _str_idfTesting, _type = "Int64",
              _get_func = o => o.idfTesting,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfTesting != newval) o.idfTesting = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfTesting != c.idfTesting || o.IsRIRPropChanged(_str_idfTesting, c)) 
                  m.Add(_str_idfTesting, o.ObjectIdent + _str_idfTesting, o.ObjectIdent2 + _str_idfTesting, o.ObjectIdent3 + _str_idfTesting, "Int64", 
                    o.idfTesting == null ? "" : o.idfTesting.ToString(),                  
                  o.IsReadOnly(_str_idfTesting), o.IsInvisible(_str_idfTesting), o.IsRequired(_str_idfTesting)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTestName, _formname = _str_idfsTestName, _type = "Int64?",
              _get_func = o => o.idfsTestName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsTestName != newval) 
                  o.TestNameRef = o.TestNameRefLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsTestName != newval) o.idfsTestName = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsTestName != c.idfsTestName || o.IsRIRPropChanged(_str_idfsTestName, c)) 
                  m.Add(_str_idfsTestName, o.ObjectIdent + _str_idfsTestName, o.ObjectIdent2 + _str_idfsTestName, o.ObjectIdent3 + _str_idfsTestName, "Int64?", 
                    o.idfsTestName == null ? "" : o.idfsTestName.ToString(),                  
                  o.IsReadOnly(_str_idfsTestName), o.IsInvisible(_str_idfsTestName), o.IsRequired(_str_idfsTestName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTestStatus, _formname = _str_idfsTestStatus, _type = "Int64",
              _get_func = o => o.idfsTestStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsTestStatus != newval) 
                  o.TestStatus = o.TestStatusLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsTestStatus != newval) o.idfsTestStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsTestStatus != c.idfsTestStatus || o.IsRIRPropChanged(_str_idfsTestStatus, c)) 
                  m.Add(_str_idfsTestStatus, o.ObjectIdent + _str_idfsTestStatus, o.ObjectIdent2 + _str_idfsTestStatus, o.ObjectIdent3 + _str_idfsTestStatus, "Int64", 
                    o.idfsTestStatus == null ? "" : o.idfsTestStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsTestStatus), o.IsInvisible(_str_idfsTestStatus), o.IsRequired(_str_idfsTestStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfObservation, _formname = _str_idfObservation, _type = "Int64",
              _get_func = o => o.idfObservation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfObservation != newval) o.idfObservation = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfObservation != c.idfObservation || o.IsRIRPropChanged(_str_idfObservation, c)) 
                  m.Add(_str_idfObservation, o.ObjectIdent + _str_idfObservation, o.ObjectIdent2 + _str_idfObservation, o.ObjectIdent3 + _str_idfObservation, "Int64", 
                    o.idfObservation == null ? "" : o.idfObservation.ToString(),                  
                  o.IsReadOnly(_str_idfObservation), o.IsInvisible(_str_idfObservation), o.IsRequired(_str_idfObservation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_TestName, _formname = _str_TestName, _type = "String",
              _get_func = o => o.TestName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.TestName != newval) o.TestName = newval; },
              _compare_func = (o, c, m) => {
                if (o.TestName != c.TestName || o.IsRIRPropChanged(_str_TestName, c)) 
                  m.Add(_str_TestName, o.ObjectIdent + _str_TestName, o.ObjectIdent2 + _str_TestName, o.ObjectIdent3 + _str_TestName, "String", 
                    o.TestName == null ? "" : o.TestName.ToString(),                  
                  o.IsReadOnly(_str_TestName), o.IsInvisible(_str_TestName), o.IsRequired(_str_TestName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_TestResult, _formname = _str_TestResult, _type = "String",
              _get_func = o => o.TestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.TestResult != newval) o.TestResult = newval; },
              _compare_func = (o, c, m) => {
                if (o.TestResult != c.TestResult || o.IsRIRPropChanged(_str_TestResult, c)) 
                  m.Add(_str_TestResult, o.ObjectIdent + _str_TestResult, o.ObjectIdent2 + _str_TestResult, o.ObjectIdent3 + _str_TestResult, "String", 
                    o.TestResult == null ? "" : o.TestResult.ToString(),                  
                  o.IsReadOnly(_str_TestResult), o.IsInvisible(_str_TestResult), o.IsRequired(_str_TestResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_TestCategory, _formname = _str_TestCategory, _type = "String",
              _get_func = o => o.TestCategory,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.TestCategory != newval) o.TestCategory = newval; },
              _compare_func = (o, c, m) => {
                if (o.TestCategory != c.TestCategory || o.IsRIRPropChanged(_str_TestCategory, c)) 
                  m.Add(_str_TestCategory, o.ObjectIdent + _str_TestCategory, o.ObjectIdent2 + _str_TestCategory, o.ObjectIdent3 + _str_TestCategory, "String", 
                    o.TestCategory == null ? "" : o.TestCategory.ToString(),                  
                  o.IsReadOnly(_str_TestCategory), o.IsInvisible(_str_TestCategory), o.IsRequired(_str_TestCategory)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTestCategory, _formname = _str_idfsTestCategory, _type = "Int64?",
              _get_func = o => o.idfsTestCategory,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsTestCategory != newval) 
                  o.TestCategoryRef = o.TestCategoryRefLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsTestCategory != newval) o.idfsTestCategory = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsTestCategory != c.idfsTestCategory || o.IsRIRPropChanged(_str_idfsTestCategory, c)) 
                  m.Add(_str_idfsTestCategory, o.ObjectIdent + _str_idfsTestCategory, o.ObjectIdent2 + _str_idfsTestCategory, o.ObjectIdent3 + _str_idfsTestCategory, "Int64?", 
                    o.idfsTestCategory == null ? "" : o.idfsTestCategory.ToString(),                  
                  o.IsReadOnly(_str_idfsTestCategory), o.IsInvisible(_str_idfsTestCategory), o.IsRequired(_str_idfsTestCategory)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfBatchTest, _formname = _str_idfBatchTest, _type = "Int64?",
              _get_func = o => o.idfBatchTest,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfBatchTest != newval) o.idfBatchTest = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfBatchTest != c.idfBatchTest || o.IsRIRPropChanged(_str_idfBatchTest, c)) 
                  m.Add(_str_idfBatchTest, o.ObjectIdent + _str_idfBatchTest, o.ObjectIdent2 + _str_idfBatchTest, o.ObjectIdent3 + _str_idfBatchTest, "Int64?", 
                    o.idfBatchTest == null ? "" : o.idfBatchTest.ToString(),                  
                  o.IsReadOnly(_str_idfBatchTest), o.IsInvisible(_str_idfBatchTest), o.IsRequired(_str_idfBatchTest)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_BatchTestCode, _formname = _str_BatchTestCode, _type = "String",
              _get_func = o => o.BatchTestCode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.BatchTestCode != newval) o.BatchTestCode = newval; },
              _compare_func = (o, c, m) => {
                if (o.BatchTestCode != c.BatchTestCode || o.IsRIRPropChanged(_str_BatchTestCode, c)) 
                  m.Add(_str_BatchTestCode, o.ObjectIdent + _str_BatchTestCode, o.ObjectIdent2 + _str_BatchTestCode, o.ObjectIdent3 + _str_BatchTestCode, "String", 
                    o.BatchTestCode == null ? "" : o.BatchTestCode.ToString(),                  
                  o.IsReadOnly(_str_BatchTestCode), o.IsInvisible(_str_BatchTestCode), o.IsRequired(_str_BatchTestCode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datConcludedDate, _formname = _str_datConcludedDate, _type = "DateTime?",
              _get_func = o => o.datConcludedDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datConcludedDate != newval) o.datConcludedDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datConcludedDate != c.datConcludedDate || o.IsRIRPropChanged(_str_datConcludedDate, c)) 
                  m.Add(_str_datConcludedDate, o.ObjectIdent + _str_datConcludedDate, o.ObjectIdent2 + _str_datConcludedDate, o.ObjectIdent3 + _str_datConcludedDate, "DateTime?", 
                    o.datConcludedDate == null ? "" : o.datConcludedDate.ToString(),                  
                  o.IsReadOnly(_str_datConcludedDate), o.IsInvisible(_str_datConcludedDate), o.IsRequired(_str_datConcludedDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datPerformedDate, _formname = _str_datPerformedDate, _type = "DateTime?",
              _get_func = o => o.datPerformedDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datPerformedDate != newval) o.datPerformedDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datPerformedDate != c.datPerformedDate || o.IsRIRPropChanged(_str_datPerformedDate, c)) 
                  m.Add(_str_datPerformedDate, o.ObjectIdent + _str_datPerformedDate, o.ObjectIdent2 + _str_datPerformedDate, o.ObjectIdent3 + _str_datPerformedDate, "DateTime?", 
                    o.datPerformedDate == null ? "" : o.datPerformedDate.ToString(),                  
                  o.IsReadOnly(_str_datPerformedDate), o.IsInvisible(_str_datPerformedDate), o.IsRequired(_str_datPerformedDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Status, _formname = _str_Status, _type = "String",
              _get_func = o => o.Status,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.Status != newval) o.Status = newval; },
              _compare_func = (o, c, m) => {
                if (o.Status != c.Status || o.IsRIRPropChanged(_str_Status, c)) 
                  m.Add(_str_Status, o.ObjectIdent + _str_Status, o.ObjectIdent2 + _str_Status, o.ObjectIdent3 + _str_Status, "String", 
                    o.Status == null ? "" : o.Status.ToString(),                  
                  o.IsReadOnly(_str_Status), o.IsInvisible(_str_Status), o.IsRequired(_str_Status)); 
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
              _name = _str_idfHumanCase, _formname = _str_idfHumanCase, _type = "Int64?",
              _get_func = o => o.idfHumanCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfHumanCase != newval) o.idfHumanCase = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfHumanCase != c.idfHumanCase || o.IsRIRPropChanged(_str_idfHumanCase, c)) 
                  m.Add(_str_idfHumanCase, o.ObjectIdent + _str_idfHumanCase, o.ObjectIdent2 + _str_idfHumanCase, o.ObjectIdent3 + _str_idfHumanCase, "Int64?", 
                    o.idfHumanCase == null ? "" : o.idfHumanCase.ToString(),                  
                  o.IsReadOnly(_str_idfHumanCase), o.IsInvisible(_str_idfHumanCase), o.IsRequired(_str_idfHumanCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfVetCase, _formname = _str_idfVetCase, _type = "Int64?",
              _get_func = o => o.idfVetCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfVetCase != newval) o.idfVetCase = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfVetCase != c.idfVetCase || o.IsRIRPropChanged(_str_idfVetCase, c)) 
                  m.Add(_str_idfVetCase, o.ObjectIdent + _str_idfVetCase, o.ObjectIdent2 + _str_idfVetCase, o.ObjectIdent3 + _str_idfVetCase, "Int64?", 
                    o.idfVetCase == null ? "" : o.idfVetCase.ToString(),                  
                  o.IsReadOnly(_str_idfVetCase), o.IsInvisible(_str_idfVetCase), o.IsRequired(_str_idfVetCase)); 
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
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "Int64",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsDiagnosis != newval) 
                  o.Diagnosis = o.DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis, "Int64", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); 
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
              _name = _str_idfsBatchStatus, _formname = _str_idfsBatchStatus, _type = "Int64?",
              _get_func = o => o.idfsBatchStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsBatchStatus != newval) o.idfsBatchStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsBatchStatus != c.idfsBatchStatus || o.IsRIRPropChanged(_str_idfsBatchStatus, c)) 
                  m.Add(_str_idfsBatchStatus, o.ObjectIdent + _str_idfsBatchStatus, o.ObjectIdent2 + _str_idfsBatchStatus, o.ObjectIdent3 + _str_idfsBatchStatus, "Int64?", 
                    o.idfsBatchStatus == null ? "" : o.idfsBatchStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsBatchStatus), o.IsInvisible(_str_idfsBatchStatus), o.IsRequired(_str_idfsBatchStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTestResult, _formname = _str_idfsTestResult, _type = "Int64?",
              _get_func = o => o.idfsTestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsTestResult != newval) 
                  o.TestResultRef = o.TestResultRefLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsTestResult != newval) o.idfsTestResult = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsTestResult != c.idfsTestResult || o.IsRIRPropChanged(_str_idfsTestResult, c)) 
                  m.Add(_str_idfsTestResult, o.ObjectIdent + _str_idfsTestResult, o.ObjectIdent2 + _str_idfsTestResult, o.ObjectIdent3 + _str_idfsTestResult, "Int64?", 
                    o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(),                  
                  o.IsReadOnly(_str_idfsTestResult), o.IsInvisible(_str_idfsTestResult), o.IsRequired(_str_idfsTestResult)); 
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
              _name = _str_TestNameRef, _formname = _str_TestNameRef, _type = "Lookup",
              _get_func = o => { if (o.TestNameRef == null) return null; return o.TestNameRef.idfsBaseReference; },
              _set_func = (o, val) => { o.TestNameRef = o.TestNameRefLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestName != c.idfsTestName || o.IsRIRPropChanged(_str_TestNameRef, c)) {
                  m.Add(_str_TestNameRef, o.ObjectIdent + _str_TestNameRef, o.ObjectIdent2 + _str_TestNameRef, o.ObjectIdent3 + _str_TestNameRef, "Lookup", o.idfsTestName == null ? "" : o.idfsTestName.ToString(), o.IsReadOnly(_str_TestNameRef), o.IsInvisible(_str_TestNameRef), o.IsRequired(_str_TestNameRef)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestNameRef + "Lookup", _formname = _str_TestNameRef + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestNameRefLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
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
              _name = _str_TestStatus, _formname = _str_TestStatus, _type = "Lookup",
              _get_func = o => { if (o.TestStatus == null) return null; return o.TestStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.TestStatus = o.TestStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestStatus != c.idfsTestStatus || o.IsRIRPropChanged(_str_TestStatus, c)) {
                  m.Add(_str_TestStatus, o.ObjectIdent + _str_TestStatus, o.ObjectIdent2 + _str_TestStatus, o.ObjectIdent3 + _str_TestStatus, "Lookup", o.idfsTestStatus == null ? "" : o.idfsTestStatus.ToString(), o.IsReadOnly(_str_TestStatus), o.IsInvisible(_str_TestStatus), o.IsRequired(_str_TestStatus)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestStatus + "Lookup", _formname = _str_TestStatus + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestStatusLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestCategoryRef, _formname = _str_TestCategoryRef, _type = "Lookup",
              _get_func = o => { if (o.TestCategoryRef == null) return null; return o.TestCategoryRef.idfsBaseReference; },
              _set_func = (o, val) => { o.TestCategoryRef = o.TestCategoryRefLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestCategory != c.idfsTestCategory || o.IsRIRPropChanged(_str_TestCategoryRef, c)) {
                  m.Add(_str_TestCategoryRef, o.ObjectIdent + _str_TestCategoryRef, o.ObjectIdent2 + _str_TestCategoryRef, o.ObjectIdent3 + _str_TestCategoryRef, "Lookup", o.idfsTestCategory == null ? "" : o.idfsTestCategory.ToString(), o.IsReadOnly(_str_TestCategoryRef), o.IsInvisible(_str_TestCategoryRef), o.IsRequired(_str_TestCategoryRef)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestCategoryRef + "Lookup", _formname = _str_TestCategoryRef + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestCategoryRefLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestResultRef, _formname = _str_TestResultRef, _type = "Lookup",
              _get_func = o => { if (o.TestResultRef == null) return null; return o.TestResultRef.idfsBaseReference; },
              _set_func = (o, val) => { o.TestResultRef = o.TestResultRefLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestResult != c.idfsTestResult || o.IsRIRPropChanged(_str_TestResultRef, c)) {
                  m.Add(_str_TestResultRef, o.ObjectIdent + _str_TestResultRef, o.ObjectIdent2 + _str_TestResultRef, o.ObjectIdent3 + _str_TestResultRef, "Lookup", o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(), o.IsReadOnly(_str_TestResultRef), o.IsInvisible(_str_TestResultRef), o.IsRequired(_str_TestResultRef)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestResultRef + "Lookup", _formname = _str_TestResultRef + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestResultRefLookup,
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
            LabTestListItem obj = (LabTestListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_TestNameRef)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestName)]
        public BaseReference TestNameRef
        {
            get { return _TestNameRef == null ? null : ((long)_TestNameRef.Key == 0 ? null : _TestNameRef); }
            set 
            { 
                var oldVal = _TestNameRef;
                _TestNameRef = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestNameRef != oldVal)
                {
                    if (idfsTestName != (_TestNameRef == null
                            ? new Int64?()
                            : (Int64?)_TestNameRef.idfsBaseReference))
                        idfsTestName = _TestNameRef == null 
                            ? new Int64?()
                            : (Int64?)_TestNameRef.idfsBaseReference; 
                    OnPropertyChanged(_str_TestNameRef); 
                }
            }
        }
        private BaseReference _TestNameRef;

        
        public BaseReferenceList TestNameRefLookup
        {
            get { return _TestNameRefLookup; }
        }
        private BaseReferenceList _TestNameRefLookup = new BaseReferenceList("rftTestName");
            
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
                            ? new Int64()
                            : (Int64)_Diagnosis.idfsDiagnosis))
                        idfsDiagnosis = _Diagnosis == null 
                            ? new Int64()
                            : (Int64)_Diagnosis.idfsDiagnosis; 
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
            
        [LocalizedDisplayName(_str_TestStatus)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestStatus)]
        public BaseReference TestStatus
        {
            get { return _TestStatus == null ? null : ((long)_TestStatus.Key == 0 ? null : _TestStatus); }
            set 
            { 
                var oldVal = _TestStatus;
                _TestStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestStatus != oldVal)
                {
                    if (idfsTestStatus != (_TestStatus == null
                            ? new Int64()
                            : (Int64)_TestStatus.idfsBaseReference))
                        idfsTestStatus = _TestStatus == null 
                            ? new Int64()
                            : (Int64)_TestStatus.idfsBaseReference; 
                    OnPropertyChanged(_str_TestStatus); 
                }
            }
        }
        private BaseReference _TestStatus;

        
        public BaseReferenceList TestStatusLookup
        {
            get { return _TestStatusLookup; }
        }
        private BaseReferenceList _TestStatusLookup = new BaseReferenceList("rftTestStatus");
            
        [LocalizedDisplayName(_str_TestCategoryRef)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestCategory)]
        public BaseReference TestCategoryRef
        {
            get { return _TestCategoryRef == null ? null : ((long)_TestCategoryRef.Key == 0 ? null : _TestCategoryRef); }
            set 
            { 
                var oldVal = _TestCategoryRef;
                _TestCategoryRef = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestCategoryRef != oldVal)
                {
                    if (idfsTestCategory != (_TestCategoryRef == null
                            ? new Int64?()
                            : (Int64?)_TestCategoryRef.idfsBaseReference))
                        idfsTestCategory = _TestCategoryRef == null 
                            ? new Int64?()
                            : (Int64?)_TestCategoryRef.idfsBaseReference; 
                    OnPropertyChanged(_str_TestCategoryRef); 
                }
            }
        }
        private BaseReference _TestCategoryRef;

        
        public BaseReferenceList TestCategoryRefLookup
        {
            get { return _TestCategoryRefLookup; }
        }
        private BaseReferenceList _TestCategoryRefLookup = new BaseReferenceList("rftTestCategory");
            
        [LocalizedDisplayName(_str_TestResultRef)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestResult)]
        public BaseReference TestResultRef
        {
            get { return _TestResultRef == null ? null : ((long)_TestResultRef.Key == 0 ? null : _TestResultRef); }
            set 
            { 
                var oldVal = _TestResultRef;
                _TestResultRef = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestResultRef != oldVal)
                {
                    if (idfsTestResult != (_TestResultRef == null
                            ? new Int64?()
                            : (Int64?)_TestResultRef.idfsBaseReference))
                        idfsTestResult = _TestResultRef == null 
                            ? new Int64?()
                            : (Int64?)_TestResultRef.idfsBaseReference; 
                    OnPropertyChanged(_str_TestResultRef); 
                }
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
            
                case _str_TestNameRef:
                    return new BvSelectList(TestNameRefLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestNameRef, _str_idfsTestName);
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_SampleType:
                    return new BvSelectList(SampleTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SampleType, _str_idfsSampleType);
            
                case _str_TestStatus:
                    return new BvSelectList(TestStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestStatus, _str_idfsTestStatus);
            
                case _str_TestCategoryRef:
                    return new BvSelectList(TestCategoryRefLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestCategoryRef, _str_idfsTestCategory);
            
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
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as LabTestListItem;
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
            var ret = base.Clone() as LabTestListItem;
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
        
            var _prev_idfsTestName_TestNameRef = idfsTestName;
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfsSampleType_SampleType = idfsSampleType;
            var _prev_idfsTestStatus_TestStatus = idfsTestStatus;
            var _prev_idfsTestCategory_TestCategoryRef = idfsTestCategory;
            var _prev_idfsTestResult_TestResultRef = idfsTestResult;
            base.RejectChanges();
        
            if (_prev_idfsTestName_TestNameRef != idfsTestName)
            {
                _TestNameRef = _TestNameRefLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestName);
            }
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsSampleType_SampleType != idfsSampleType)
            {
                _SampleType = _SampleTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSampleType);
            }
            if (_prev_idfsTestStatus_TestStatus != idfsTestStatus)
            {
                _TestStatus = _TestStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestStatus);
            }
            if (_prev_idfsTestCategory_TestCategoryRef != idfsTestCategory)
            {
                _TestCategoryRef = _TestCategoryRefLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestCategory);
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

        private bool IsRIRPropChanged(string fld, LabTestListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public LabTestListItem()
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


        internal Dictionary<string, Func<LabTestListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<LabTestListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabTestListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabTestListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<LabTestListItem, bool>> m_isHiddenPersonalData;
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
                
                LookupManager.RemoveObject("rftTestName", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftSampleType", this);
                
                LookupManager.RemoveObject("rftTestStatus", this);
                
                LookupManager.RemoveObject("rftTestCategory", this);
                
                LookupManager.RemoveObject("rftTestResult", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftTestName")
                _getAccessor().LoadLookup_TestNameRef(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftSampleType")
                _getAccessor().LoadLookup_SampleType(manager, this);
            
            if (lookup_object == "rftTestStatus")
                _getAccessor().LoadLookup_TestStatus(manager, this);
            
            if (lookup_object == "rftTestCategory")
                _getAccessor().LoadLookup_TestCategoryRef(manager, this);
            
            if (lookup_object == "rftTestResult")
                _getAccessor().LoadLookup_TestResultRef(manager, this);
            
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
        public class LabTestListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfTesting { get; set; }
        
            public String BatchTestCode { get; set; }
        
            public String TestName { get; set; }
        
            public String TestCategory { get; set; }
        
            public String Status { get; set; }
        
            public String TestResult { get; set; }
        
            public DateTime? datConcludedDate { get; set; }
        
            public String strBarcode { get; set; }
        
            public String strSampleName { get; set; }
        
            public String strFieldBarcode { get; set; }
        
            public DateTime? datAccession { get; set; }
        
            public String DepartmentName { get; set; }
        
            public String CaseID { get; set; }
        
            public String DiagnosisName { get; set; }
        
            public String HumanName { get; set; }
        
            public String AnimalName { get; set; }
        
        }
        public partial class LabTestListItemGridModelList : List<LabTestListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public LabTestListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabTestListItem>, errMes);
            }
            public LabTestListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabTestListItem>, errMes);
            }
            public LabTestListItemGridModelList(long key, IEnumerable<LabTestListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public LabTestListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<LabTestListItem>(), null);
            }
            partial void filter(List<LabTestListItem> items);
            private void LoadGridModelList(long key, IEnumerable<LabTestListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_BatchTestCode,_str_TestName,_str_TestCategory,_str_Status,_str_TestResult,_str_datConcludedDate,_str_strBarcode,_str_strSampleName,_str_strFieldBarcode,_str_datAccession,_str_DepartmentName,_str_CaseID,_str_DiagnosisName,_str_HumanName,_str_AnimalName};
                    
                Hiddens = new List<string> {_str_idfTesting};
                Keys = new List<string> {_str_idfTesting};
                Labels = new Dictionary<string, string> {{_str_BatchTestCode, _str_BatchTestCode},{_str_TestName, _str_TestName},{_str_TestCategory, _str_TestCategory},{_str_Status, _str_Status},{_str_TestResult, _str_TestResult},{_str_datConcludedDate, _str_datConcludedDate},{_str_strBarcode, "strLabBarcode"},{_str_strSampleName, _str_strSampleName},{_str_strFieldBarcode, _str_strFieldBarcode},{_str_datAccession, _str_datAccession},{_str_DepartmentName, _str_DepartmentName},{_str_CaseID, _str_CaseID},{_str_DiagnosisName, "TestDiagnosisName"},{_str_HumanName, _str_HumanName},{_str_AnimalName, _str_AnimalName}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                LabTestListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<LabTestListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new LabTestListItemGridModel()
                {
                    ItemKey=c.idfTesting,BatchTestCode=c.BatchTestCode,TestName=c.TestName,TestCategory=c.TestCategory,Status=c.Status,TestResult=c.TestResult,datConcludedDate=c.datConcludedDate,strBarcode=c.strBarcode,strSampleName=c.strSampleName,strFieldBarcode=c.strFieldBarcode,datAccession=c.datAccession,DepartmentName=c.DepartmentName,CaseID=c.CaseID,DiagnosisName=c.DiagnosisName,HumanName=c.HumanName,AnimalName=c.AnimalName
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
            , IObjectCreator<LabTestListItem>
            
            , IObjectSelectList
            , IObjectSelectList<LabTestListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfTesting"; } }
            #endregion
        
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
            private BaseReference.Accessor TestNameRefAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SampleTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestCategoryRefAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
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
                        
                        if (filters.Operation("idfTesting", i) == "&")
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfTesting,0) {0} @idfTesting_{1} = @idfTesting_{1})", filters.Operation("idfTesting", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LabTest_SelectList.idfTesting,0) {0} @idfTesting_{1}", filters.Operation("idfTesting", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsTestName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsTestName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsTestName") ? " or " : " and ");
                        
                        if (filters.Operation("idfsTestName", i) == "&")
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfsTestName,0) {0} @idfsTestName_{1} = @idfsTestName_{1})", filters.Operation("idfsTestName", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LabTest_SelectList.idfsTestName,0) {0} @idfsTestName_{1}", filters.Operation("idfsTestName", i), i);
                            
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
                        
                        if (filters.Operation("idfsTestStatus", i) == "&")
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfsTestStatus,0) {0} @idfsTestStatus_{1} = @idfsTestStatus_{1})", filters.Operation("idfsTestStatus", i), i);
                        else
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
                        
                        if (filters.Operation("idfObservation", i) == "&")
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfObservation,0) {0} @idfObservation_{1} = @idfObservation_{1})", filters.Operation("idfObservation", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LabTest_SelectList.idfObservation,0) {0} @idfObservation_{1}", filters.Operation("idfObservation", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("TestName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("TestName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("TestName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LabTest_SelectList.TestName {0} @TestName_{1}", filters.Operation("TestName", i), i);
                            
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
                  
                if (filters.Contains("idfsTestCategory"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsTestCategory"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsTestCategory") ? " or " : " and ");
                        
                        if (filters.Operation("idfsTestCategory", i) == "&")
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfsTestCategory,0) {0} @idfsTestCategory_{1} = @idfsTestCategory_{1})", filters.Operation("idfsTestCategory", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LabTest_SelectList.idfsTestCategory,0) {0} @idfsTestCategory_{1}", filters.Operation("idfsTestCategory", i), i);
                            
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
                        
                        if (filters.Operation("idfBatchTest", i) == "&")
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfBatchTest,0) {0} @idfBatchTest_{1} = @idfBatchTest_{1})", filters.Operation("idfBatchTest", i), i);
                        else
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
                  
                if (filters.Contains("strSampleName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSampleName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSampleName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LabTest_SelectList.strSampleName {0} @strSampleName_{1}", filters.Operation("strSampleName", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfCase,0) {0} @idfCase_{1} = @idfCase_{1})", filters.Operation("idfCase", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LabTest_SelectList.idfCase,0) {0} @idfCase_{1}", filters.Operation("idfCase", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfHumanCase"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfHumanCase"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfHumanCase") ? " or " : " and ");
                        
                        if (filters.Operation("idfHumanCase", i) == "&")
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfHumanCase,0) {0} @idfHumanCase_{1} = @idfHumanCase_{1})", filters.Operation("idfHumanCase", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LabTest_SelectList.idfHumanCase,0) {0} @idfHumanCase_{1}", filters.Operation("idfHumanCase", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfVetCase"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfVetCase"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfVetCase") ? " or " : " and ");
                        
                        if (filters.Operation("idfVetCase", i) == "&")
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfVetCase,0) {0} @idfVetCase_{1} = @idfVetCase_{1})", filters.Operation("idfVetCase", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LabTest_SelectList.idfVetCase,0) {0} @idfVetCase_{1}", filters.Operation("idfVetCase", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfMonitoringSession,0) {0} @idfMonitoringSession_{1} = @idfMonitoringSession_{1})", filters.Operation("idfMonitoringSession", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LabTest_SelectList.idfMonitoringSession,0) {0} @idfMonitoringSession_{1}", filters.Operation("idfMonitoringSession", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfVectorSurveillanceSession,0) {0} @idfVectorSurveillanceSession_{1} = @idfVectorSurveillanceSession_{1})", filters.Operation("idfVectorSurveillanceSession", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LabTest_SelectList.idfVectorSurveillanceSession,0) {0} @idfVectorSurveillanceSession_{1}", filters.Operation("idfVectorSurveillanceSession", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfsCaseType,0) {0} @idfsCaseType_{1} = @idfsCaseType_{1})", filters.Operation("idfsCaseType", i), i);
                        else
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
                        
                        if (filters.Operation("idfsDiagnosis", i) == "&")
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfsDiagnosis,0) {0} @idfsDiagnosis_{1} = @idfsDiagnosis_{1})", filters.Operation("idfsDiagnosis", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LabTest_SelectList.idfsDiagnosis,0) {0} @idfsDiagnosis_{1}", filters.Operation("idfsDiagnosis", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfsSampleType,0) {0} @idfsSampleType_{1} = @idfsSampleType_{1})", filters.Operation("idfsSampleType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LabTest_SelectList.idfsSampleType,0) {0} @idfsSampleType_{1}", filters.Operation("idfsSampleType", i), i);
                            
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
                        
                        if (filters.Operation("idfsBatchStatus", i) == "&")
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfsBatchStatus,0) {0} @idfsBatchStatus_{1} = @idfsBatchStatus_{1})", filters.Operation("idfsBatchStatus", i), i);
                        else
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
                        
                        if (filters.Operation("idfsTestResult", i) == "&")
                          sql.AppendFormat("(isnull(fn_LabTest_SelectList.idfsTestResult,0) {0} @idfsTestResult_{1} = @idfsTestResult_{1})", filters.Operation("idfsTestResult", i), i);
                        else
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
                    
                    sql.Append(" option (OPTIMIZE FOR UNKNOWN)");
                    manager
                        .SetCommand(sql.ToString()
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                        );
                    
                    if (filters.Contains("idfTesting"))
                        for (int i = 0; i < filters.Count("idfTesting"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfTesting_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfTesting", i), filters.Value("idfTesting", i))));
                      
                    if (filters.Contains("idfsTestName"))
                        for (int i = 0; i < filters.Count("idfsTestName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestName", i), filters.Value("idfsTestName", i))));
                      
                    if (filters.Contains("idfsTestStatus"))
                        for (int i = 0; i < filters.Count("idfsTestStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestStatus", i), filters.Value("idfsTestStatus", i))));
                      
                    if (filters.Contains("idfObservation"))
                        for (int i = 0; i < filters.Count("idfObservation"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfObservation_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfObservation", i), filters.Value("idfObservation", i))));
                      
                    if (filters.Contains("TestName"))
                        for (int i = 0; i < filters.Count("TestName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@TestName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("TestName", i), filters.Value("TestName", i))));
                      
                    if (filters.Contains("TestResult"))
                        for (int i = 0; i < filters.Count("TestResult"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@TestResult_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("TestResult", i), filters.Value("TestResult", i))));
                      
                    if (filters.Contains("TestCategory"))
                        for (int i = 0; i < filters.Count("TestCategory"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@TestCategory_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("TestCategory", i), filters.Value("TestCategory", i))));
                      
                    if (filters.Contains("idfsTestCategory"))
                        for (int i = 0; i < filters.Count("idfsTestCategory"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestCategory_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestCategory", i), filters.Value("idfsTestCategory", i))));
                      
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
                      
                    if (filters.Contains("strSampleName"))
                        for (int i = 0; i < filters.Count("strSampleName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSampleName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSampleName", i), filters.Value("strSampleName", i))));
                      
                    if (filters.Contains("idfCase"))
                        for (int i = 0; i < filters.Count("idfCase"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfCase_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfCase", i), filters.Value("idfCase", i))));
                      
                    if (filters.Contains("idfHumanCase"))
                        for (int i = 0; i < filters.Count("idfHumanCase"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfHumanCase_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfHumanCase", i), filters.Value("idfHumanCase", i))));
                      
                    if (filters.Contains("idfVetCase"))
                        for (int i = 0; i < filters.Count("idfVetCase"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfVetCase_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfVetCase", i), filters.Value("idfVetCase", i))));
                      
                    if (filters.Contains("idfMonitoringSession"))
                        for (int i = 0; i < filters.Count("idfMonitoringSession"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfMonitoringSession_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfMonitoringSession", i), filters.Value("idfMonitoringSession", i))));
                      
                    if (filters.Contains("idfVectorSurveillanceSession"))
                        for (int i = 0; i < filters.Count("idfVectorSurveillanceSession"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfVectorSurveillanceSession_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfVectorSurveillanceSession", i), filters.Value("idfVectorSurveillanceSession", i))));
                      
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
                      
                    if (filters.Contains("idfsSampleType"))
                        for (int i = 0; i < filters.Count("idfsSampleType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSampleType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSampleType", i), filters.Value("idfsSampleType", i))));
                      
                    if (filters.Contains("DepartmentName"))
                        for (int i = 0; i < filters.Count("DepartmentName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@DepartmentName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("DepartmentName", i), filters.Value("DepartmentName", i))));
                      
                    if (filters.Contains("datFieldCollectionDate"))
                        for (int i = 0; i < filters.Count("datFieldCollectionDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datFieldCollectionDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datFieldCollectionDate", i), filters.Value("datFieldCollectionDate", i))));
                      
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
            partial void ListSelected(DbManagerProxy manager, List<LabTestListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spLabTest_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabTestListItem obj, bool bCloning = false)
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

    

            private LabTestListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
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
            public LabTestListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
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
    
            public void LoadLookup_TestNameRef(DbManagerProxy manager, LabTestListItem obj)
            {
                
                obj.TestNameRefLookup.Clear();
                
                obj.TestNameRefLookup.Add(TestNameRefAccessor.CreateNewT(manager, null));
                
                obj.TestNameRefLookup.AddRange(TestNameRefAccessor.rftTestName_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestName))
                    
                    .ToList());
                
                if (obj.idfsTestName != null && obj.idfsTestName != 0)
                {
                    obj.TestNameRef = obj.TestNameRefLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsTestName);
                    
                }
              
                
                LookupManager.AddObject("rftTestName", obj, TestNameRefAccessor.GetType(), "rftTestName_SelectList"
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
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosis);
                    
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_SampleType(DbManagerProxy manager, LabTestListItem obj)
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
            
            public void LoadLookup_TestStatus(DbManagerProxy manager, LabTestListItem obj)
            {
                
                obj.TestStatusLookup.Clear();
                
                obj.TestStatusLookup.Add(TestStatusAccessor.CreateNewT(manager, null));
                
                obj.TestStatusLookup.AddRange(TestStatusAccessor.rftTestStatus_SelectList(manager
                    
                    )
                    .Where(c => c.idfsBaseReference != (long)eidss.model.Enums.TestStatus.Declined)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestStatus))
                    
                    .ToList());
                
                if (obj.idfsTestStatus != 0)
                {
                    obj.TestStatus = obj.TestStatusLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsTestStatus);
                    
                }
              
                
                LookupManager.AddObject("rftTestStatus", obj, TestStatusAccessor.GetType(), "rftTestStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_TestCategoryRef(DbManagerProxy manager, LabTestListItem obj)
            {
                
                obj.TestCategoryRefLookup.Clear();
                
                obj.TestCategoryRefLookup.Add(TestCategoryRefAccessor.CreateNewT(manager, null));
                
                obj.TestCategoryRefLookup.AddRange(TestCategoryRefAccessor.rftTestCategory_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestCategory))
                    
                    .ToList());
                
                if (obj.idfsTestCategory != null && obj.idfsTestCategory != 0)
                {
                    obj.TestCategoryRef = obj.TestCategoryRefLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsTestCategory);
                    
                }
              
                
                LookupManager.AddObject("rftTestCategory", obj, TestCategoryRefAccessor.GetType(), "rftTestCategory_SelectList"
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
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsTestResult);
                    
                }
              
                
                LookupManager.AddObject("rftTestResult", obj, TestResultRefAccessor.GetType(), "rftTestResult_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, LabTestListItem obj)
            {
                
                LoadLookup_TestNameRef(manager, obj);
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_SampleType(manager, obj);
                
                LoadLookup_TestStatus(manager, obj);
                
                LoadLookup_TestCategoryRef(manager, obj);
                
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
                    
                    long mainObject = bo.idfTesting;
                    
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
            private bool _PostNonTransaction(DbManagerProxy manager, LabTestListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
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
                //obj.AcceptChanges();
                
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
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, false, obj);
                        }
                     }
                }
                catch(ValidationModelException ex)
                {
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                    else
                        obj.m_IsForcedToDelete = true;
                }
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(LabTestListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(LabTestListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as LabTestListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabTestListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
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
            public string HelpIdWin { get { return "lab_l03"; } }
            public string HelpIdWeb { get { return "lab_l03"; } }
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
                
                Sizes.Add(_str_TestName, 2000);
                Sizes.Add(_str_TestResult, 2000);
                Sizes.Add(_str_TestCategory, 2000);
                Sizes.Add(_str_BatchTestCode, 200);
                Sizes.Add(_str_Status, 2000);
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strSampleName, 2000);
                Sizes.Add(_str_CaseID, 200);
                Sizes.Add(_str_DiagnosisName, 2000);
                Sizes.Add(_str_DepartmentName, 2000);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_HumanName, 700);
                Sizes.Add(_str_AnimalName, 2000);
                Sizes.Add(_str_strPatientName, 700);
                Sizes.Add(_str_strFarmOwner, 700);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestName",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "TestName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "TestNameRefLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "BatchTestCode",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "BatchTestCode",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestStatus",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "Status",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "TestStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datConcludedDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datConcludedDate",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "CaseID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "CaseID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsDiagnosis",
                    EditorType.Lookup,
                    EditorControlWidth.Large, true, true, false, false, 
                    "TestDiagnosis2",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "DiagnosisLookup", typeof(DiagnosisLookup), (o) => { var c = (DiagnosisLookup)o; return c.idfsDiagnosis; }, (o) => { var c = (DiagnosisLookup)o; return c.name; }, null,false
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
                    "AnimalName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "AnimalName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strBarcode",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strLabBarcode",
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
                    "datAccession",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, true, 
                    "datAccession",
                    c => DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter), null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSampleType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "SampleType",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "SampleTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfTesting,
                    _str_idfTesting, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_BatchTestCode,
                    _str_BatchTestCode, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestName,
                    _str_TestName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestCategory,
                    _str_TestCategory, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Status,
                    _str_Status, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestResult,
                    _str_TestResult, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datConcludedDate,
                    _str_datConcludedDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBarcode,
                    "strLabBarcode", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSampleName,
                    _str_strSampleName, null, true, true, true, true, null
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
                    _str_DepartmentName,
                    _str_DepartmentName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_CaseID,
                    _str_CaseID, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DiagnosisName,
                    "TestDiagnosisName", null, true, true, true, true, ListSortDirection.Descending
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_HumanName,
                    _str_HumanName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalName,
                    _str_AnimalName, null, true, true, true, true, null
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
	