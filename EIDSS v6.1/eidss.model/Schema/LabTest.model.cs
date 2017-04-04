#pragma warning disable 0472,0414
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
    public abstract partial class LabTest : 
        EditableObject<LabTest>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfTesting), NonUpdatable, PrimaryKey]
        public abstract Int64 idfTesting { get; set; }
                
        [LocalizedDisplayName(_str_idfsTestStatus)]
        [MapField(_str_idfsTestStatus)]
        public abstract Int64 idfsTestStatus { get; set; }
        protected Int64 idfsTestStatus_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsTestStatus).OriginalValue; } }
        protected Int64 idfsTestStatus_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsTestStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTestName)]
        [MapField(_str_idfsTestName)]
        public abstract Int64? idfsTestName { get; set; }
        protected Int64? idfsTestName_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestName).OriginalValue; } }
        protected Int64? idfsTestName_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTestResult)]
        [MapField(_str_idfsTestResult)]
        public abstract Int64? idfsTestResult { get; set; }
        protected Int64? idfsTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).OriginalValue; } }
        protected Int64? idfsTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTestCategory)]
        [MapField(_str_idfsTestCategory)]
        public abstract Int64? idfsTestCategory { get; set; }
        protected Int64? idfsTestCategory_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestCategory).OriginalValue; } }
        protected Int64? idfsTestCategory_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestCategory).PreviousValue; } }
                
        [LocalizedDisplayName("TestDiagnosis2")]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64 idfsDiagnosis { get; set; }
        protected Int64 idfsDiagnosis_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64 idfsDiagnosis_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMaterial)]
        [MapField(_str_idfMaterial)]
        public abstract Int64? idfMaterial { get; set; }
        protected Int64? idfMaterial_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMaterial).OriginalValue; } }
        protected Int64? idfMaterial_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMaterial).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfObservation)]
        [MapField(_str_idfObservation)]
        public abstract Int64 idfObservation { get; set; }
        protected Int64 idfObservation_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfObservation).OriginalValue; } }
        protected Int64 idfObservation_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfObservation).PreviousValue; } }
                
        [LocalizedDisplayName("strComments")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_datStartedDate)]
        [MapField(_str_datStartedDate)]
        public abstract DateTime? datStartedDate { get; set; }
        protected DateTime? datStartedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartedDate).OriginalValue; } }
        protected DateTime? datStartedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartedDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPerformedByOffice)]
        [MapField(_str_idfPerformedByOffice)]
        public abstract Int64? idfPerformedByOffice { get; set; }
        protected Int64? idfPerformedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerformedByOffice).OriginalValue; } }
        protected Int64? idfPerformedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerformedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datReceivedDate)]
        [MapField(_str_datReceivedDate)]
        public abstract DateTime? datReceivedDate { get; set; }
        protected DateTime? datReceivedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReceivedDate).OriginalValue; } }
        protected DateTime? datReceivedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReceivedDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strContactPerson)]
        [MapField(_str_strContactPerson)]
        public abstract String strContactPerson { get; set; }
        protected String strContactPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strContactPerson).OriginalValue; } }
        protected String strContactPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strContactPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datConcludedDate)]
        [MapField(_str_datConcludedDate)]
        public abstract DateTime? datConcludedDate { get; set; }
        protected DateTime? datConcludedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datConcludedDate).OriginalValue; } }
        protected DateTime? datConcludedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datConcludedDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfTestedByOffice)]
        [MapField(_str_idfTestedByOffice)]
        public abstract Int64? idfTestedByOffice { get; set; }
        protected Int64? idfTestedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByOffice).OriginalValue; } }
        protected Int64? idfTestedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfTestedByPerson)]
        [MapField(_str_idfTestedByPerson)]
        public abstract Int64? idfTestedByPerson { get; set; }
        protected Int64? idfTestedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByPerson).OriginalValue; } }
        protected Int64? idfTestedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfResultEnteredByOffice)]
        [MapField(_str_idfResultEnteredByOffice)]
        public abstract Int64? idfResultEnteredByOffice { get; set; }
        protected Int64? idfResultEnteredByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfResultEnteredByOffice).OriginalValue; } }
        protected Int64? idfResultEnteredByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfResultEnteredByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfResultEnteredByPerson)]
        [MapField(_str_idfResultEnteredByPerson)]
        public abstract Int64? idfResultEnteredByPerson { get; set; }
        protected Int64? idfResultEnteredByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfResultEnteredByPerson).OriginalValue; } }
        protected Int64? idfResultEnteredByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfResultEnteredByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfValidatedByOffice)]
        [MapField(_str_idfValidatedByOffice)]
        public abstract Int64? idfValidatedByOffice { get; set; }
        protected Int64? idfValidatedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfValidatedByOffice).OriginalValue; } }
        protected Int64? idfValidatedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfValidatedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfValidatedByPerson)]
        [MapField(_str_idfValidatedByPerson)]
        public abstract Int64? idfValidatedByPerson { get; set; }
        protected Int64? idfValidatedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfValidatedByPerson).OriginalValue; } }
        protected Int64? idfValidatedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfValidatedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMonitoringSession)]
        [MapField(_str_idfMonitoringSession)]
        public abstract Int64? idfMonitoringSession { get; set; }
        protected Int64? idfMonitoringSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).OriginalValue; } }
        protected Int64? idfMonitoringSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strMonitoringSessionID)]
        [MapField(_str_strMonitoringSessionID)]
        public abstract String strMonitoringSessionID { get; set; }
        protected String strMonitoringSessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strMonitoringSessionID).OriginalValue; } }
        protected String strMonitoringSessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strMonitoringSessionID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64? idfCase { get; set; }
        protected Int64? idfCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64? idfCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCaseType)]
        [MapField(_str_idfsCaseType)]
        public abstract Int64? idfsCaseType { get; set; }
        protected Int64? idfsCaseType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).OriginalValue; } }
        protected Int64? idfsCaseType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCaseID)]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_SessionID)]
        [MapField(_str_SessionID)]
        public abstract String SessionID { get; set; }
        protected String SessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._sessionID).OriginalValue; } }
        protected String SessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._sessionID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datAccession)]
        [MapField(_str_datAccession)]
        public abstract DateTime? datAccession { get; set; }
        protected DateTime? datAccession_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).OriginalValue; } }
        protected DateTime? datAccession_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfVectorSurveillanceSession)]
        [MapField(_str_idfVectorSurveillanceSession)]
        public abstract Int64? idfVectorSurveillanceSession { get; set; }
        protected Int64? idfVectorSurveillanceSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).OriginalValue; } }
        protected Int64? idfVectorSurveillanceSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strBarcode)]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnSampleTransferred)]
        [MapField(_str_blnSampleTransferred)]
        public abstract Boolean? blnSampleTransferred { get; set; }
        protected Boolean? blnSampleTransferred_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnSampleTransferred).OriginalValue; } }
        protected Boolean? blnSampleTransferred_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnSampleTransferred).PreviousValue; } }
                
        [LocalizedDisplayName("strLaboratory")]
        [MapField(_str_DepartmentName)]
        public abstract String DepartmentName { get; set; }
        protected String DepartmentName_Original { get { return ((EditableValue<String>)((dynamic)this)._departmentName).OriginalValue; } }
        protected String DepartmentName_Previous { get { return ((EditableValue<String>)((dynamic)this)._departmentName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_ResultEnteredByPerson)]
        [MapField(_str_ResultEnteredByPerson)]
        public abstract String ResultEnteredByPerson { get; set; }
        protected String ResultEnteredByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._resultEnteredByPerson).OriginalValue; } }
        protected String ResultEnteredByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._resultEnteredByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64? idfsFormTemplate { get; set; }
        protected Int64? idfsFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64? idfsFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnNonLaboratoryTest)]
        [MapField(_str_blnNonLaboratoryTest)]
        public abstract Boolean blnNonLaboratoryTest { get; set; }
        protected Boolean blnNonLaboratoryTest_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnNonLaboratoryTest).OriginalValue; } }
        protected Boolean blnNonLaboratoryTest_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnNonLaboratoryTest).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnExternalTest)]
        [MapField(_str_blnExternalTest)]
        public abstract Boolean? blnExternalTest { get; set; }
        protected Boolean? blnExternalTest_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnExternalTest).OriginalValue; } }
        protected Boolean? blnExternalTest_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnExternalTest).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int32 intHACode { get; set; }
        protected Int32 intHACode_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32 intHACode_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intHACode).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<LabTest, object> _get_func;
            internal Action<LabTest, string> _set_func;
            internal Action<LabTest, LabTest, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfTesting = "idfTesting";
        internal const string _str_idfsTestStatus = "idfsTestStatus";
        internal const string _str_idfsTestName = "idfsTestName";
        internal const string _str_idfsTestResult = "idfsTestResult";
        internal const string _str_idfsTestCategory = "idfsTestCategory";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_idfObservation = "idfObservation";
        internal const string _str_strNote = "strNote";
        internal const string _str_idfBatchTest = "idfBatchTest";
        internal const string _str_BatchTestCode = "BatchTestCode";
        internal const string _str_datStartedDate = "datStartedDate";
        internal const string _str_idfPerformedByOffice = "idfPerformedByOffice";
        internal const string _str_datReceivedDate = "datReceivedDate";
        internal const string _str_strContactPerson = "strContactPerson";
        internal const string _str_datConcludedDate = "datConcludedDate";
        internal const string _str_idfTestedByOffice = "idfTestedByOffice";
        internal const string _str_idfTestedByPerson = "idfTestedByPerson";
        internal const string _str_idfResultEnteredByOffice = "idfResultEnteredByOffice";
        internal const string _str_idfResultEnteredByPerson = "idfResultEnteredByPerson";
        internal const string _str_idfValidatedByOffice = "idfValidatedByOffice";
        internal const string _str_idfValidatedByPerson = "idfValidatedByPerson";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_strMonitoringSessionID = "strMonitoringSessionID";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_SessionID = "SessionID";
        internal const string _str_datAccession = "datAccession";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_blnSampleTransferred = "blnSampleTransferred";
        internal const string _str_DepartmentName = "DepartmentName";
        internal const string _str_ResultEnteredByPerson = "ResultEnteredByPerson";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_blnNonLaboratoryTest = "blnNonLaboratoryTest";
        internal const string _str_blnExternalTest = "blnExternalTest";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_idfsTestStatusOriginal = "idfsTestStatusOriginal";
        internal const string _str_strOriginalTestResult = "strOriginalTestResult";
        internal const string _str_TestStatus = "TestStatus";
        internal const string _str_TestNameRef = "TestNameRef";
        internal const string _str_TestResultRef = "TestResultRef";
        internal const string _str_TestCategory = "TestCategory";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_ValidatedByPerson = "ValidatedByPerson";
        internal const string _str_TestedByPerson = "TestedByPerson";
        internal const string _str_Sample = "Sample";
        internal const string _str_SampleInfo = "SampleInfo";
        internal const string _str_AmendmentHistory = "AmendmentHistory";
        internal const string _str_FFPresenter = "FFPresenter";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfTesting, _formname = _str_idfTesting, _type = "Int64",
              _get_func = o => o.idfTesting,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfTesting != newval) o.idfTesting = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfTesting != c.idfTesting || o.IsRIRPropChanged(_str_idfTesting, c)) 
                  m.Add(_str_idfTesting, o.ObjectIdent + _str_idfTesting, o.ObjectIdent2 + _str_idfTesting, o.ObjectIdent3 + _str_idfTesting, "Int64", 
                    o.idfTesting == null ? "" : o.idfTesting.ToString(),                  
                  o.IsReadOnly(_str_idfTesting), o.IsInvisible(_str_idfTesting), o.IsRequired(_str_idfTesting)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTestStatus, _formname = _str_idfsTestStatus, _type = "Int64",
              _get_func = o => o.idfsTestStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsTestStatus != newval) 
                  o.TestStatus = o.TestStatusLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsTestStatus != newval) o.idfsTestStatus = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsTestStatus != c.idfsTestStatus || o.IsRIRPropChanged(_str_idfsTestStatus, c)) 
                  m.Add(_str_idfsTestStatus, o.ObjectIdent + _str_idfsTestStatus, o.ObjectIdent2 + _str_idfsTestStatus, o.ObjectIdent3 + _str_idfsTestStatus, "Int64", 
                    o.idfsTestStatus == null ? "" : o.idfsTestStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsTestStatus), o.IsInvisible(_str_idfsTestStatus), o.IsRequired(_str_idfsTestStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTestName, _formname = _str_idfsTestName, _type = "Int64?",
              _get_func = o => o.idfsTestName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsTestName != newval) 
                  o.TestNameRef = o.TestNameRefLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsTestName != newval) o.idfsTestName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsTestName != c.idfsTestName || o.IsRIRPropChanged(_str_idfsTestName, c)) 
                  m.Add(_str_idfsTestName, o.ObjectIdent + _str_idfsTestName, o.ObjectIdent2 + _str_idfsTestName, o.ObjectIdent3 + _str_idfsTestName, "Int64?", 
                    o.idfsTestName == null ? "" : o.idfsTestName.ToString(),                  
                  o.IsReadOnly(_str_idfsTestName), o.IsInvisible(_str_idfsTestName), o.IsRequired(_str_idfsTestName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTestResult, _formname = _str_idfsTestResult, _type = "Int64?",
              _get_func = o => o.idfsTestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsTestResult != newval) 
                  o.TestResultRef = o.TestResultRefLookup.FirstOrDefault(c => c.idfsReference == newval);
                if (o.idfsTestResult != newval) o.idfsTestResult = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsTestResult != c.idfsTestResult || o.IsRIRPropChanged(_str_idfsTestResult, c)) 
                  m.Add(_str_idfsTestResult, o.ObjectIdent + _str_idfsTestResult, o.ObjectIdent2 + _str_idfsTestResult, o.ObjectIdent3 + _str_idfsTestResult, "Int64?", 
                    o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(),                  
                  o.IsReadOnly(_str_idfsTestResult), o.IsInvisible(_str_idfsTestResult), o.IsRequired(_str_idfsTestResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTestCategory, _formname = _str_idfsTestCategory, _type = "Int64?",
              _get_func = o => o.idfsTestCategory,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsTestCategory != newval) 
                  o.TestCategory = o.TestCategoryLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsTestCategory != newval) o.idfsTestCategory = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsTestCategory != c.idfsTestCategory || o.IsRIRPropChanged(_str_idfsTestCategory, c)) 
                  m.Add(_str_idfsTestCategory, o.ObjectIdent + _str_idfsTestCategory, o.ObjectIdent2 + _str_idfsTestCategory, o.ObjectIdent3 + _str_idfsTestCategory, "Int64?", 
                    o.idfsTestCategory == null ? "" : o.idfsTestCategory.ToString(),                  
                  o.IsReadOnly(_str_idfsTestCategory), o.IsInvisible(_str_idfsTestCategory), o.IsRequired(_str_idfsTestCategory)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "Int64",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsDiagnosis != newval) 
                  o.Diagnosis = o.DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis, "Int64", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfMaterial, _formname = _str_idfMaterial, _type = "Int64?",
              _get_func = o => o.idfMaterial,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfMaterial != newval) o.idfMaterial = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfMaterial != c.idfMaterial || o.IsRIRPropChanged(_str_idfMaterial, c)) 
                  m.Add(_str_idfMaterial, o.ObjectIdent + _str_idfMaterial, o.ObjectIdent2 + _str_idfMaterial, o.ObjectIdent3 + _str_idfMaterial, "Int64?", 
                    o.idfMaterial == null ? "" : o.idfMaterial.ToString(),                  
                  o.IsReadOnly(_str_idfMaterial), o.IsInvisible(_str_idfMaterial), o.IsRequired(_str_idfMaterial)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfObservation, _formname = _str_idfObservation, _type = "Int64",
              _get_func = o => o.idfObservation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfObservation != newval) o.idfObservation = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfObservation != c.idfObservation || o.IsRIRPropChanged(_str_idfObservation, c)) 
                  m.Add(_str_idfObservation, o.ObjectIdent + _str_idfObservation, o.ObjectIdent2 + _str_idfObservation, o.ObjectIdent3 + _str_idfObservation, "Int64", 
                    o.idfObservation == null ? "" : o.idfObservation.ToString(),                  
                  o.IsReadOnly(_str_idfObservation), o.IsInvisible(_str_idfObservation), o.IsRequired(_str_idfObservation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strNote, _formname = _str_strNote, _type = "String",
              _get_func = o => o.strNote,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strNote != newval) o.strNote = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strNote != c.strNote || o.IsRIRPropChanged(_str_strNote, c)) 
                  m.Add(_str_strNote, o.ObjectIdent + _str_strNote, o.ObjectIdent2 + _str_strNote, o.ObjectIdent3 + _str_strNote, "String", 
                    o.strNote == null ? "" : o.strNote.ToString(),                  
                  o.IsReadOnly(_str_strNote), o.IsInvisible(_str_strNote), o.IsRequired(_str_strNote)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfBatchTest, _formname = _str_idfBatchTest, _type = "Int64?",
              _get_func = o => o.idfBatchTest,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfBatchTest != newval) o.idfBatchTest = newval; },
              _compare_func = (o, c, m, g) => {
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
              _compare_func = (o, c, m, g) => {
                if (o.BatchTestCode != c.BatchTestCode || o.IsRIRPropChanged(_str_BatchTestCode, c)) 
                  m.Add(_str_BatchTestCode, o.ObjectIdent + _str_BatchTestCode, o.ObjectIdent2 + _str_BatchTestCode, o.ObjectIdent3 + _str_BatchTestCode, "String", 
                    o.BatchTestCode == null ? "" : o.BatchTestCode.ToString(),                  
                  o.IsReadOnly(_str_BatchTestCode), o.IsInvisible(_str_BatchTestCode), o.IsRequired(_str_BatchTestCode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datStartedDate, _formname = _str_datStartedDate, _type = "DateTime?",
              _get_func = o => o.datStartedDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datStartedDate != newval) o.datStartedDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datStartedDate != c.datStartedDate || o.IsRIRPropChanged(_str_datStartedDate, c)) 
                  m.Add(_str_datStartedDate, o.ObjectIdent + _str_datStartedDate, o.ObjectIdent2 + _str_datStartedDate, o.ObjectIdent3 + _str_datStartedDate, "DateTime?", 
                    o.datStartedDate == null ? "" : o.datStartedDate.ToString(),                  
                  o.IsReadOnly(_str_datStartedDate), o.IsInvisible(_str_datStartedDate), o.IsRequired(_str_datStartedDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfPerformedByOffice, _formname = _str_idfPerformedByOffice, _type = "Int64?",
              _get_func = o => o.idfPerformedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfPerformedByOffice != newval) o.idfPerformedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfPerformedByOffice != c.idfPerformedByOffice || o.IsRIRPropChanged(_str_idfPerformedByOffice, c)) 
                  m.Add(_str_idfPerformedByOffice, o.ObjectIdent + _str_idfPerformedByOffice, o.ObjectIdent2 + _str_idfPerformedByOffice, o.ObjectIdent3 + _str_idfPerformedByOffice, "Int64?", 
                    o.idfPerformedByOffice == null ? "" : o.idfPerformedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfPerformedByOffice), o.IsInvisible(_str_idfPerformedByOffice), o.IsRequired(_str_idfPerformedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datReceivedDate, _formname = _str_datReceivedDate, _type = "DateTime?",
              _get_func = o => o.datReceivedDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datReceivedDate != newval) o.datReceivedDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datReceivedDate != c.datReceivedDate || o.IsRIRPropChanged(_str_datReceivedDate, c)) 
                  m.Add(_str_datReceivedDate, o.ObjectIdent + _str_datReceivedDate, o.ObjectIdent2 + _str_datReceivedDate, o.ObjectIdent3 + _str_datReceivedDate, "DateTime?", 
                    o.datReceivedDate == null ? "" : o.datReceivedDate.ToString(),                  
                  o.IsReadOnly(_str_datReceivedDate), o.IsInvisible(_str_datReceivedDate), o.IsRequired(_str_datReceivedDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strContactPerson, _formname = _str_strContactPerson, _type = "String",
              _get_func = o => o.strContactPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strContactPerson != newval) o.strContactPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strContactPerson != c.strContactPerson || o.IsRIRPropChanged(_str_strContactPerson, c)) 
                  m.Add(_str_strContactPerson, o.ObjectIdent + _str_strContactPerson, o.ObjectIdent2 + _str_strContactPerson, o.ObjectIdent3 + _str_strContactPerson, "String", 
                    o.strContactPerson == null ? "" : o.strContactPerson.ToString(),                  
                  o.IsReadOnly(_str_strContactPerson), o.IsInvisible(_str_strContactPerson), o.IsRequired(_str_strContactPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datConcludedDate, _formname = _str_datConcludedDate, _type = "DateTime?",
              _get_func = o => o.datConcludedDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datConcludedDate != newval) o.datConcludedDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datConcludedDate != c.datConcludedDate || o.IsRIRPropChanged(_str_datConcludedDate, c)) 
                  m.Add(_str_datConcludedDate, o.ObjectIdent + _str_datConcludedDate, o.ObjectIdent2 + _str_datConcludedDate, o.ObjectIdent3 + _str_datConcludedDate, "DateTime?", 
                    o.datConcludedDate == null ? "" : o.datConcludedDate.ToString(),                  
                  o.IsReadOnly(_str_datConcludedDate), o.IsInvisible(_str_datConcludedDate), o.IsRequired(_str_datConcludedDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfTestedByOffice, _formname = _str_idfTestedByOffice, _type = "Int64?",
              _get_func = o => o.idfTestedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfTestedByOffice != newval) o.idfTestedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfTestedByOffice != c.idfTestedByOffice || o.IsRIRPropChanged(_str_idfTestedByOffice, c)) 
                  m.Add(_str_idfTestedByOffice, o.ObjectIdent + _str_idfTestedByOffice, o.ObjectIdent2 + _str_idfTestedByOffice, o.ObjectIdent3 + _str_idfTestedByOffice, "Int64?", 
                    o.idfTestedByOffice == null ? "" : o.idfTestedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfTestedByOffice), o.IsInvisible(_str_idfTestedByOffice), o.IsRequired(_str_idfTestedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfTestedByPerson, _formname = _str_idfTestedByPerson, _type = "Int64?",
              _get_func = o => o.idfTestedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfTestedByPerson != newval) 
                  o.TestedByPerson = o.TestedByPersonLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfTestedByPerson != newval) o.idfTestedByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfTestedByPerson != c.idfTestedByPerson || o.IsRIRPropChanged(_str_idfTestedByPerson, c)) 
                  m.Add(_str_idfTestedByPerson, o.ObjectIdent + _str_idfTestedByPerson, o.ObjectIdent2 + _str_idfTestedByPerson, o.ObjectIdent3 + _str_idfTestedByPerson, "Int64?", 
                    o.idfTestedByPerson == null ? "" : o.idfTestedByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfTestedByPerson), o.IsInvisible(_str_idfTestedByPerson), o.IsRequired(_str_idfTestedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfResultEnteredByOffice, _formname = _str_idfResultEnteredByOffice, _type = "Int64?",
              _get_func = o => o.idfResultEnteredByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfResultEnteredByOffice != newval) o.idfResultEnteredByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfResultEnteredByOffice != c.idfResultEnteredByOffice || o.IsRIRPropChanged(_str_idfResultEnteredByOffice, c)) 
                  m.Add(_str_idfResultEnteredByOffice, o.ObjectIdent + _str_idfResultEnteredByOffice, o.ObjectIdent2 + _str_idfResultEnteredByOffice, o.ObjectIdent3 + _str_idfResultEnteredByOffice, "Int64?", 
                    o.idfResultEnteredByOffice == null ? "" : o.idfResultEnteredByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfResultEnteredByOffice), o.IsInvisible(_str_idfResultEnteredByOffice), o.IsRequired(_str_idfResultEnteredByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfResultEnteredByPerson, _formname = _str_idfResultEnteredByPerson, _type = "Int64?",
              _get_func = o => o.idfResultEnteredByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfResultEnteredByPerson != newval) o.idfResultEnteredByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfResultEnteredByPerson != c.idfResultEnteredByPerson || o.IsRIRPropChanged(_str_idfResultEnteredByPerson, c)) 
                  m.Add(_str_idfResultEnteredByPerson, o.ObjectIdent + _str_idfResultEnteredByPerson, o.ObjectIdent2 + _str_idfResultEnteredByPerson, o.ObjectIdent3 + _str_idfResultEnteredByPerson, "Int64?", 
                    o.idfResultEnteredByPerson == null ? "" : o.idfResultEnteredByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfResultEnteredByPerson), o.IsInvisible(_str_idfResultEnteredByPerson), o.IsRequired(_str_idfResultEnteredByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfValidatedByOffice, _formname = _str_idfValidatedByOffice, _type = "Int64?",
              _get_func = o => o.idfValidatedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfValidatedByOffice != newval) o.idfValidatedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfValidatedByOffice != c.idfValidatedByOffice || o.IsRIRPropChanged(_str_idfValidatedByOffice, c)) 
                  m.Add(_str_idfValidatedByOffice, o.ObjectIdent + _str_idfValidatedByOffice, o.ObjectIdent2 + _str_idfValidatedByOffice, o.ObjectIdent3 + _str_idfValidatedByOffice, "Int64?", 
                    o.idfValidatedByOffice == null ? "" : o.idfValidatedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfValidatedByOffice), o.IsInvisible(_str_idfValidatedByOffice), o.IsRequired(_str_idfValidatedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfValidatedByPerson, _formname = _str_idfValidatedByPerson, _type = "Int64?",
              _get_func = o => o.idfValidatedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfValidatedByPerson != newval) 
                  o.ValidatedByPerson = o.ValidatedByPersonLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfValidatedByPerson != newval) o.idfValidatedByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfValidatedByPerson != c.idfValidatedByPerson || o.IsRIRPropChanged(_str_idfValidatedByPerson, c)) 
                  m.Add(_str_idfValidatedByPerson, o.ObjectIdent + _str_idfValidatedByPerson, o.ObjectIdent2 + _str_idfValidatedByPerson, o.ObjectIdent3 + _str_idfValidatedByPerson, "Int64?", 
                    o.idfValidatedByPerson == null ? "" : o.idfValidatedByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfValidatedByPerson), o.IsInvisible(_str_idfValidatedByPerson), o.IsRequired(_str_idfValidatedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfMonitoringSession, _formname = _str_idfMonitoringSession, _type = "Int64?",
              _get_func = o => o.idfMonitoringSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfMonitoringSession != newval) o.idfMonitoringSession = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfMonitoringSession != c.idfMonitoringSession || o.IsRIRPropChanged(_str_idfMonitoringSession, c)) 
                  m.Add(_str_idfMonitoringSession, o.ObjectIdent + _str_idfMonitoringSession, o.ObjectIdent2 + _str_idfMonitoringSession, o.ObjectIdent3 + _str_idfMonitoringSession, "Int64?", 
                    o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(),                  
                  o.IsReadOnly(_str_idfMonitoringSession), o.IsInvisible(_str_idfMonitoringSession), o.IsRequired(_str_idfMonitoringSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strMonitoringSessionID, _formname = _str_strMonitoringSessionID, _type = "String",
              _get_func = o => o.strMonitoringSessionID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strMonitoringSessionID != newval) o.strMonitoringSessionID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strMonitoringSessionID != c.strMonitoringSessionID || o.IsRIRPropChanged(_str_strMonitoringSessionID, c)) 
                  m.Add(_str_strMonitoringSessionID, o.ObjectIdent + _str_strMonitoringSessionID, o.ObjectIdent2 + _str_strMonitoringSessionID, o.ObjectIdent3 + _str_strMonitoringSessionID, "String", 
                    o.strMonitoringSessionID == null ? "" : o.strMonitoringSessionID.ToString(),                  
                  o.IsReadOnly(_str_strMonitoringSessionID), o.IsInvisible(_str_strMonitoringSessionID), o.IsRequired(_str_strMonitoringSessionID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfCase, _formname = _str_idfCase, _type = "Int64?",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfCase != newval) o.idfCase = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, o.ObjectIdent2 + _str_idfCase, o.ObjectIdent3 + _str_idfCase, "Int64?", 
                    o.idfCase == null ? "" : o.idfCase.ToString(),                  
                  o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCaseType, _formname = _str_idfsCaseType, _type = "Int64?",
              _get_func = o => o.idfsCaseType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsCaseType != newval) o.idfsCaseType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_idfsCaseType, c)) 
                  m.Add(_str_idfsCaseType, o.ObjectIdent + _str_idfsCaseType, o.ObjectIdent2 + _str_idfsCaseType, o.ObjectIdent3 + _str_idfsCaseType, "Int64?", 
                    o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseType), o.IsInvisible(_str_idfsCaseType), o.IsRequired(_str_idfsCaseType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCaseID, _formname = _str_strCaseID, _type = "String",
              _get_func = o => o.strCaseID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCaseID != newval) o.strCaseID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strCaseID != c.strCaseID || o.IsRIRPropChanged(_str_strCaseID, c)) 
                  m.Add(_str_strCaseID, o.ObjectIdent + _str_strCaseID, o.ObjectIdent2 + _str_strCaseID, o.ObjectIdent3 + _str_strCaseID, "String", 
                    o.strCaseID == null ? "" : o.strCaseID.ToString(),                  
                  o.IsReadOnly(_str_strCaseID), o.IsInvisible(_str_strCaseID), o.IsRequired(_str_strCaseID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_SessionID, _formname = _str_SessionID, _type = "String",
              _get_func = o => o.SessionID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.SessionID != newval) o.SessionID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.SessionID != c.SessionID || o.IsRIRPropChanged(_str_SessionID, c)) 
                  m.Add(_str_SessionID, o.ObjectIdent + _str_SessionID, o.ObjectIdent2 + _str_SessionID, o.ObjectIdent3 + _str_SessionID, "String", 
                    o.SessionID == null ? "" : o.SessionID.ToString(),                  
                  o.IsReadOnly(_str_SessionID), o.IsInvisible(_str_SessionID), o.IsRequired(_str_SessionID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datAccession, _formname = _str_datAccession, _type = "DateTime?",
              _get_func = o => o.datAccession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datAccession != newval) o.datAccession = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datAccession != c.datAccession || o.IsRIRPropChanged(_str_datAccession, c)) 
                  m.Add(_str_datAccession, o.ObjectIdent + _str_datAccession, o.ObjectIdent2 + _str_datAccession, o.ObjectIdent3 + _str_datAccession, "DateTime?", 
                    o.datAccession == null ? "" : o.datAccession.ToString(),                  
                  o.IsReadOnly(_str_datAccession), o.IsInvisible(_str_datAccession), o.IsRequired(_str_datAccession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _formname = _str_idfVectorSurveillanceSession, _type = "Int64?",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfVectorSurveillanceSession != newval) o.idfVectorSurveillanceSession = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, o.ObjectIdent2 + _str_idfVectorSurveillanceSession, o.ObjectIdent3 + _str_idfVectorSurveillanceSession, "Int64?", 
                    o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(),                  
                  o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strBarcode, _formname = _str_strBarcode, _type = "String",
              _get_func = o => o.strBarcode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strBarcode != newval) o.strBarcode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strBarcode != c.strBarcode || o.IsRIRPropChanged(_str_strBarcode, c)) 
                  m.Add(_str_strBarcode, o.ObjectIdent + _str_strBarcode, o.ObjectIdent2 + _str_strBarcode, o.ObjectIdent3 + _str_strBarcode, "String", 
                    o.strBarcode == null ? "" : o.strBarcode.ToString(),                  
                  o.IsReadOnly(_str_strBarcode), o.IsInvisible(_str_strBarcode), o.IsRequired(_str_strBarcode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnSampleTransferred, _formname = _str_blnSampleTransferred, _type = "Boolean?",
              _get_func = o => o.blnSampleTransferred,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnSampleTransferred != newval) o.blnSampleTransferred = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnSampleTransferred != c.blnSampleTransferred || o.IsRIRPropChanged(_str_blnSampleTransferred, c)) 
                  m.Add(_str_blnSampleTransferred, o.ObjectIdent + _str_blnSampleTransferred, o.ObjectIdent2 + _str_blnSampleTransferred, o.ObjectIdent3 + _str_blnSampleTransferred, "Boolean?", 
                    o.blnSampleTransferred == null ? "" : o.blnSampleTransferred.ToString(),                  
                  o.IsReadOnly(_str_blnSampleTransferred), o.IsInvisible(_str_blnSampleTransferred), o.IsRequired(_str_blnSampleTransferred)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DepartmentName, _formname = _str_DepartmentName, _type = "String",
              _get_func = o => o.DepartmentName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DepartmentName != newval) o.DepartmentName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DepartmentName != c.DepartmentName || o.IsRIRPropChanged(_str_DepartmentName, c)) 
                  m.Add(_str_DepartmentName, o.ObjectIdent + _str_DepartmentName, o.ObjectIdent2 + _str_DepartmentName, o.ObjectIdent3 + _str_DepartmentName, "String", 
                    o.DepartmentName == null ? "" : o.DepartmentName.ToString(),                  
                  o.IsReadOnly(_str_DepartmentName), o.IsInvisible(_str_DepartmentName), o.IsRequired(_str_DepartmentName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_ResultEnteredByPerson, _formname = _str_ResultEnteredByPerson, _type = "String",
              _get_func = o => o.ResultEnteredByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.ResultEnteredByPerson != newval) o.ResultEnteredByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.ResultEnteredByPerson != c.ResultEnteredByPerson || o.IsRIRPropChanged(_str_ResultEnteredByPerson, c)) 
                  m.Add(_str_ResultEnteredByPerson, o.ObjectIdent + _str_ResultEnteredByPerson, o.ObjectIdent2 + _str_ResultEnteredByPerson, o.ObjectIdent3 + _str_ResultEnteredByPerson, "String", 
                    o.ResultEnteredByPerson == null ? "" : o.ResultEnteredByPerson.ToString(),                  
                  o.IsReadOnly(_str_ResultEnteredByPerson), o.IsInvisible(_str_ResultEnteredByPerson), o.IsRequired(_str_ResultEnteredByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsFormTemplate, _formname = _str_idfsFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsFormTemplate != newval) o.idfsFormTemplate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, o.ObjectIdent2 + _str_idfsFormTemplate, o.ObjectIdent3 + _str_idfsFormTemplate, "Int64?", 
                    o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(),                  
                  o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnNonLaboratoryTest, _formname = _str_blnNonLaboratoryTest, _type = "Boolean",
              _get_func = o => o.blnNonLaboratoryTest,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnNonLaboratoryTest != newval) o.blnNonLaboratoryTest = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnNonLaboratoryTest != c.blnNonLaboratoryTest || o.IsRIRPropChanged(_str_blnNonLaboratoryTest, c)) 
                  m.Add(_str_blnNonLaboratoryTest, o.ObjectIdent + _str_blnNonLaboratoryTest, o.ObjectIdent2 + _str_blnNonLaboratoryTest, o.ObjectIdent3 + _str_blnNonLaboratoryTest, "Boolean", 
                    o.blnNonLaboratoryTest == null ? "" : o.blnNonLaboratoryTest.ToString(),                  
                  o.IsReadOnly(_str_blnNonLaboratoryTest), o.IsInvisible(_str_blnNonLaboratoryTest), o.IsRequired(_str_blnNonLaboratoryTest)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnExternalTest, _formname = _str_blnExternalTest, _type = "Boolean?",
              _get_func = o => o.blnExternalTest,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnExternalTest != newval) o.blnExternalTest = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnExternalTest != c.blnExternalTest || o.IsRIRPropChanged(_str_blnExternalTest, c)) 
                  m.Add(_str_blnExternalTest, o.ObjectIdent + _str_blnExternalTest, o.ObjectIdent2 + _str_blnExternalTest, o.ObjectIdent3 + _str_blnExternalTest, "Boolean?", 
                    o.blnExternalTest == null ? "" : o.blnExternalTest.ToString(),                  
                  o.IsReadOnly(_str_blnExternalTest), o.IsInvisible(_str_blnExternalTest), o.IsRequired(_str_blnExternalTest)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intHACode, _formname = _str_intHACode, _type = "Int32",
              _get_func = o => o.intHACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intHACode != newval) o.intHACode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intHACode != c.intHACode || o.IsRIRPropChanged(_str_intHACode, c)) 
                  m.Add(_str_intHACode, o.ObjectIdent + _str_intHACode, o.ObjectIdent2 + _str_intHACode, o.ObjectIdent3 + _str_intHACode, "Int32", 
                    o.intHACode == null ? "" : o.intHACode.ToString(),                  
                  o.IsReadOnly(_str_intHACode), o.IsInvisible(_str_intHACode), o.IsRequired(_str_intHACode)); 
                  }
              }, 
        
            new field_info {
              _name = _str_idfsTestStatusOriginal, _formname = _str_idfsTestStatusOriginal, _type = "long?",
              _get_func = o => o.idfsTestStatusOriginal,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTestStatusOriginal != newval) o.idfsTestStatusOriginal = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsTestStatusOriginal != c.idfsTestStatusOriginal || o.IsRIRPropChanged(_str_idfsTestStatusOriginal, c)) {
                  m.Add(_str_idfsTestStatusOriginal, o.ObjectIdent + _str_idfsTestStatusOriginal, o.ObjectIdent2 + _str_idfsTestStatusOriginal, o.ObjectIdent3 + _str_idfsTestStatusOriginal,  "long?", 
                    o.idfsTestStatusOriginal == null ? "" : o.idfsTestStatusOriginal.ToString(),                  
                    o.IsReadOnly(_str_idfsTestStatusOriginal), o.IsInvisible(_str_idfsTestStatusOriginal), o.IsRequired(_str_idfsTestStatusOriginal));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_strOriginalTestResult, _formname = _str_strOriginalTestResult, _type = "string",
              _get_func = o => o.strOriginalTestResult,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strOriginalTestResult != c.strOriginalTestResult || o.IsRIRPropChanged(_str_strOriginalTestResult, c)) {
                  m.Add(_str_strOriginalTestResult, o.ObjectIdent + _str_strOriginalTestResult, o.ObjectIdent2 + _str_strOriginalTestResult, o.ObjectIdent3 + _str_strOriginalTestResult, "string", o.strOriginalTestResult == null ? "" : o.strOriginalTestResult.ToString(), o.IsReadOnly(_str_strOriginalTestResult), o.IsInvisible(_str_strOriginalTestResult), o.IsRequired(_str_strOriginalTestResult));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_TestStatus, _formname = _str_TestStatus, _type = "Lookup",
              _get_func = o => { if (o.TestStatus == null) return null; return o.TestStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.TestStatus = o.TestStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_TestStatus, c);
                if (o.idfsTestStatus != c.idfsTestStatus || o.IsRIRPropChanged(_str_TestStatus, c) || bChangeLookupContent) {
                  m.Add(_str_TestStatus, o.ObjectIdent + _str_TestStatus, o.ObjectIdent2 + _str_TestStatus, o.ObjectIdent3 + _str_TestStatus, "Lookup", o.idfsTestStatus == null ? "" : o.idfsTestStatus.ToString(), o.IsReadOnly(_str_TestStatus), o.IsInvisible(_str_TestStatus), o.IsRequired(_str_TestStatus),
                  bChangeLookupContent ? o.TestStatusLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_TestStatus + "Lookup", _formname = _str_TestStatus + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestStatusLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestNameRef, _formname = _str_TestNameRef, _type = "Lookup",
              _get_func = o => { if (o.TestNameRef == null) return null; return o.TestNameRef.idfsBaseReference; },
              _set_func = (o, val) => { o.TestNameRef = o.TestNameRefLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_TestNameRef, c);
                if (o.idfsTestName != c.idfsTestName || o.IsRIRPropChanged(_str_TestNameRef, c) || bChangeLookupContent) {
                  m.Add(_str_TestNameRef, o.ObjectIdent + _str_TestNameRef, o.ObjectIdent2 + _str_TestNameRef, o.ObjectIdent3 + _str_TestNameRef, "Lookup", o.idfsTestName == null ? "" : o.idfsTestName.ToString(), o.IsReadOnly(_str_TestNameRef), o.IsInvisible(_str_TestNameRef), o.IsRequired(_str_TestNameRef),
                  bChangeLookupContent ? o.TestNameRefLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_TestNameRef + "Lookup", _formname = _str_TestNameRef + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestNameRefLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestResultRef, _formname = _str_TestResultRef, _type = "Lookup",
              _get_func = o => { if (o.TestResultRef == null) return null; return o.TestResultRef.idfsReference; },
              _set_func = (o, val) => { o.TestResultRef = o.TestResultRefLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_TestResultRef, c);
                if (o.idfsTestResult != c.idfsTestResult || o.IsRIRPropChanged(_str_TestResultRef, c) || bChangeLookupContent) {
                  m.Add(_str_TestResultRef, o.ObjectIdent + _str_TestResultRef, o.ObjectIdent2 + _str_TestResultRef, o.ObjectIdent3 + _str_TestResultRef, "Lookup", o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(), o.IsReadOnly(_str_TestResultRef), o.IsInvisible(_str_TestResultRef), o.IsRequired(_str_TestResultRef),
                  bChangeLookupContent ? o.TestResultRefLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_TestResultRef + "Lookup", _formname = _str_TestResultRef + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestResultRefLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestCategory, _formname = _str_TestCategory, _type = "Lookup",
              _get_func = o => { if (o.TestCategory == null) return null; return o.TestCategory.idfsBaseReference; },
              _set_func = (o, val) => { o.TestCategory = o.TestCategoryLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_TestCategory, c);
                if (o.idfsTestCategory != c.idfsTestCategory || o.IsRIRPropChanged(_str_TestCategory, c) || bChangeLookupContent) {
                  m.Add(_str_TestCategory, o.ObjectIdent + _str_TestCategory, o.ObjectIdent2 + _str_TestCategory, o.ObjectIdent3 + _str_TestCategory, "Lookup", o.idfsTestCategory == null ? "" : o.idfsTestCategory.ToString(), o.IsReadOnly(_str_TestCategory), o.IsInvisible(_str_TestCategory), o.IsRequired(_str_TestCategory),
                  bChangeLookupContent ? o.TestCategoryLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_TestCategory + "Lookup", _formname = _str_TestCategory + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestCategoryLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _formname = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Diagnosis, c);
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnosis, c) || bChangeLookupContent) {
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, o.ObjectIdent2 + _str_Diagnosis, o.ObjectIdent3 + _str_Diagnosis, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis),
                  bChangeLookupContent ? o.DiagnosisLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Diagnosis + "Lookup", _formname = _str_Diagnosis + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_ValidatedByPerson, _formname = _str_ValidatedByPerson, _type = "Lookup",
              _get_func = o => { if (o.ValidatedByPerson == null) return null; return o.ValidatedByPerson.idfPerson; },
              _set_func = (o, val) => { o.ValidatedByPerson = o.ValidatedByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_ValidatedByPerson, c);
                if (o.idfValidatedByPerson != c.idfValidatedByPerson || o.IsRIRPropChanged(_str_ValidatedByPerson, c) || bChangeLookupContent) {
                  m.Add(_str_ValidatedByPerson, o.ObjectIdent + _str_ValidatedByPerson, o.ObjectIdent2 + _str_ValidatedByPerson, o.ObjectIdent3 + _str_ValidatedByPerson, "Lookup", o.idfValidatedByPerson == null ? "" : o.idfValidatedByPerson.ToString(), o.IsReadOnly(_str_ValidatedByPerson), o.IsInvisible(_str_ValidatedByPerson), o.IsRequired(_str_ValidatedByPerson),
                  bChangeLookupContent ? o.ValidatedByPersonLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_ValidatedByPerson + "Lookup", _formname = _str_ValidatedByPerson + "Lookup", _type = "LookupContent",
              _get_func = o => o.ValidatedByPersonLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestedByPerson, _formname = _str_TestedByPerson, _type = "Lookup",
              _get_func = o => { if (o.TestedByPerson == null) return null; return o.TestedByPerson.idfPerson; },
              _set_func = (o, val) => { o.TestedByPerson = o.TestedByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_TestedByPerson, c);
                if (o.idfTestedByPerson != c.idfTestedByPerson || o.IsRIRPropChanged(_str_TestedByPerson, c) || bChangeLookupContent) {
                  m.Add(_str_TestedByPerson, o.ObjectIdent + _str_TestedByPerson, o.ObjectIdent2 + _str_TestedByPerson, o.ObjectIdent3 + _str_TestedByPerson, "Lookup", o.idfTestedByPerson == null ? "" : o.idfTestedByPerson.ToString(), o.IsReadOnly(_str_TestedByPerson), o.IsInvisible(_str_TestedByPerson), o.IsRequired(_str_TestedByPerson),
                  bChangeLookupContent ? o.TestedByPersonLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_TestedByPerson + "Lookup", _formname = _str_TestedByPerson + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestedByPersonLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_AmendmentHistory, _formname = _str_AmendmentHistory, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.AmendmentHistory.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.AmendmentHistory.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.AmendmentHistory.Count != c.AmendmentHistory.Count || o.IsReadOnly(_str_AmendmentHistory) != c.IsReadOnly(_str_AmendmentHistory) || o.IsInvisible(_str_AmendmentHistory) != c.IsInvisible(_str_AmendmentHistory) || o.IsRequired(_str_AmendmentHistory) != c._isRequired(o.m_isRequired, _str_AmendmentHistory)) {
                  m.Add(_str_AmendmentHistory, o.ObjectIdent + _str_AmendmentHistory, o.ObjectIdent2 + _str_AmendmentHistory, o.ObjectIdent3 + _str_AmendmentHistory, "Child", o.idfTesting == null ? "" : o.idfTesting.ToString(), o.IsReadOnly(_str_AmendmentHistory), o.IsInvisible(_str_AmendmentHistory), o.IsRequired(_str_AmendmentHistory)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Sample, _formname = _str_Sample, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
                if (o.Sample != null) o.Sample._compare(c.Sample, m); }
              }, 
        
            new field_info {
              _name = _str_SampleInfo, _formname = _str_SampleInfo, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
                if (o.SampleInfo != null) o.SampleInfo._compare(c.SampleInfo, m); }
              }, 
        
            new field_info {
              _name = _str_FFPresenter, _formname = _str_FFPresenter, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
                if (o.FFPresenter != null) o.FFPresenter._compare(c.FFPresenter, m); }
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
            LabTest obj = (LabTest)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Sample)]
        [Relation(typeof(LabSample), eidss.model.Schema.LabSample._str_idfMaterial, _str_idfMaterial)]
        public LabSample Sample
        {
            get 
            {   
                if (!_SampleLoaded)
                {
                    _SampleLoaded = true;
                    _getAccessor()._LoadSample(this);
                    if (_Sample != null) 
                        _Sample.Parent = this;
                }
                return _Sample; 
            }
            set 
            {   
                if (!_SampleLoaded) { _SampleLoaded = true; }
                _Sample = value;
                if (_Sample != null) 
                { 
                    _Sample.m_ObjectName = _str_Sample;
                    _Sample.Parent = this;
                }
                idfMaterial = _Sample == null 
                        ? new Int64?()
                        : _Sample.idfMaterial;
                
            }
        }
        protected LabSample _Sample;
                    
        private bool _SampleLoaded = false;
                    
        [LocalizedDisplayName(_str_SampleInfo)]
        [Relation(typeof(LabTestSample), eidss.model.Schema.LabTestSample._str_idfMaterial, _str_idfMaterial)]
        public LabTestSample SampleInfo
        {
            get 
            {   
                return _SampleInfo; 
            }
            set 
            {   
                _SampleInfo = value;
                if (_SampleInfo != null) 
                { 
                    _SampleInfo.m_ObjectName = _str_SampleInfo;
                    _SampleInfo.Parent = this;
                }
                idfMaterial = _SampleInfo == null 
                        ? new Int64?()
                        : _SampleInfo.idfMaterial;
                
            }
        }
        protected LabTestSample _SampleInfo;
                    
        [LocalizedDisplayName(_str_AmendmentHistory)]
        [Relation(typeof(LabTestAmendmentHistory), eidss.model.Schema.LabTestAmendmentHistory._str_idfTesting, _str_idfTesting)]
        public EditableList<LabTestAmendmentHistory> AmendmentHistory
        {
            get 
            {   
                return _AmendmentHistory; 
            }
            set 
            {
                _AmendmentHistory = value;
            }
        }
        protected EditableList<LabTestAmendmentHistory> _AmendmentHistory = new EditableList<LabTestAmendmentHistory>();
                    
        [LocalizedDisplayName(_str_FFPresenter)]
        [Relation(typeof(FFPresenterModel), "", _str_idfObservation)]
        public FFPresenterModel FFPresenter
        {
            get 
            {   
                return _FFPresenter; 
            }
            set 
            {   
                _FFPresenter = value;
                if (_FFPresenter != null) 
                { 
                    _FFPresenter.m_ObjectName = _str_FFPresenter;
                    _FFPresenter.Parent = this;
                }
                idfObservation = _FFPresenter == null 
                        ? new Int64()
                        : _FFPresenter.CurrentObservation.HasValue?_FFPresenter.CurrentObservation.Value:0;
                
            }
        }
        protected FFPresenterModel _FFPresenter;
                    
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
            
        [LocalizedDisplayName(_str_TestResultRef)]
        [Relation(typeof(TestResultLookup), eidss.model.Schema.TestResultLookup._str_idfsReference, _str_idfsTestResult)]
        public TestResultLookup TestResultRef
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
                            : (Int64?)_TestResultRef.idfsReference))
                        idfsTestResult = _TestResultRef == null 
                            ? new Int64?()
                            : (Int64?)_TestResultRef.idfsReference; 
                    OnPropertyChanged(_str_TestResultRef); 
                }
            }
        }
        private TestResultLookup _TestResultRef;

        
        public List<TestResultLookup> TestResultRefLookup
        {
            get { return _TestResultRefLookup; }
        }
        private List<TestResultLookup> _TestResultRefLookup = new List<TestResultLookup>();
            
        [LocalizedDisplayName(_str_TestCategory)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestCategory)]
        public BaseReference TestCategory
        {
            get { return _TestCategory == null ? null : ((long)_TestCategory.Key == 0 ? null : _TestCategory); }
            set 
            { 
                var oldVal = _TestCategory;
                _TestCategory = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestCategory != oldVal)
                {
                    if (idfsTestCategory != (_TestCategory == null
                            ? new Int64?()
                            : (Int64?)_TestCategory.idfsBaseReference))
                        idfsTestCategory = _TestCategory == null 
                            ? new Int64?()
                            : (Int64?)_TestCategory.idfsBaseReference; 
                    OnPropertyChanged(_str_TestCategory); 
                }
            }
        }
        private BaseReference _TestCategory;

        
        public BaseReferenceList TestCategoryLookup
        {
            get { return _TestCategoryLookup; }
        }
        private BaseReferenceList _TestCategoryLookup = new BaseReferenceList("rftTestCategory");
            
        [LocalizedDisplayName(_str_Diagnosis)]
        [Relation(typeof(TestDiagnosisLookup), eidss.model.Schema.TestDiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public TestDiagnosisLookup Diagnosis
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
        private TestDiagnosisLookup _Diagnosis;

        
        public List<TestDiagnosisLookup> DiagnosisLookup
        {
            get { return _DiagnosisLookup; }
        }
        private List<TestDiagnosisLookup> _DiagnosisLookup = new List<TestDiagnosisLookup>();
            
        [LocalizedDisplayName(_str_ValidatedByPerson)]
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfValidatedByPerson)]
        public PersonLookup ValidatedByPerson
        {
            get { return _ValidatedByPerson == null ? null : ((long)_ValidatedByPerson.Key == 0 ? null : _ValidatedByPerson); }
            set 
            { 
                var oldVal = _ValidatedByPerson;
                _ValidatedByPerson = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_ValidatedByPerson != oldVal)
                {
                    if (idfValidatedByPerson != (_ValidatedByPerson == null
                            ? new Int64?()
                            : (Int64?)_ValidatedByPerson.idfPerson))
                        idfValidatedByPerson = _ValidatedByPerson == null 
                            ? new Int64?()
                            : (Int64?)_ValidatedByPerson.idfPerson; 
                    OnPropertyChanged(_str_ValidatedByPerson); 
                }
            }
        }
        private PersonLookup _ValidatedByPerson;

        
        public List<PersonLookup> ValidatedByPersonLookup
        {
            get { return _ValidatedByPersonLookup; }
        }
        private List<PersonLookup> _ValidatedByPersonLookup = new List<PersonLookup>();
            
        [LocalizedDisplayName(_str_TestedByPerson)]
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfTestedByPerson)]
        public PersonLookup TestedByPerson
        {
            get { return _TestedByPerson == null ? null : ((long)_TestedByPerson.Key == 0 ? null : _TestedByPerson); }
            set 
            { 
                var oldVal = _TestedByPerson;
                _TestedByPerson = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestedByPerson != oldVal)
                {
                    if (idfTestedByPerson != (_TestedByPerson == null
                            ? new Int64?()
                            : (Int64?)_TestedByPerson.idfPerson))
                        idfTestedByPerson = _TestedByPerson == null 
                            ? new Int64?()
                            : (Int64?)_TestedByPerson.idfPerson; 
                    OnPropertyChanged(_str_TestedByPerson); 
                }
            }
        }
        private PersonLookup _TestedByPerson;

        
        public List<PersonLookup> TestedByPersonLookup
        {
            get { return _TestedByPersonLookup; }
        }
        private List<PersonLookup> _TestedByPersonLookup = new List<PersonLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_TestStatus:
                    return new BvSelectList(TestStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestStatus, _str_idfsTestStatus);
            
                case _str_TestNameRef:
                    return new BvSelectList(TestNameRefLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestNameRef, _str_idfsTestName);
            
                case _str_TestResultRef:
                    return new BvSelectList(TestResultRefLookup, eidss.model.Schema.TestResultLookup._str_idfsReference, null, TestResultRef, _str_idfsTestResult);
            
                case _str_TestCategory:
                    return new BvSelectList(TestCategoryLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestCategory, _str_idfsTestCategory);
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.TestDiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_ValidatedByPerson:
                    return new BvSelectList(ValidatedByPersonLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, ValidatedByPerson, _str_idfValidatedByPerson);
            
                case _str_TestedByPerson:
                    return new BvSelectList(TestedByPersonLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, TestedByPerson, _str_idfTestedByPerson);
            
                case _str_AmendmentHistory:
                    return new BvSelectList(AmendmentHistory, "", "", null, "");
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strOriginalTestResult)]
        public string strOriginalTestResult
        {
            get { return new Func<LabTest, string>(c => c.AmendmentHistory.Count == 0 ? (c.TestResultRef == null ? "" : c.TestResultRef.name) : c.AmendmentHistory.OrderBy(a => a.datAmendmentDate).First().strOldTestResult)(this); }
            
        }
        
          [LocalizedDisplayName(_str_idfsTestStatusOriginal)]
        public long? idfsTestStatusOriginal
        {
            get { return m_idfsTestStatusOriginal; }
            set { if (m_idfsTestStatusOriginal != value) { m_idfsTestStatusOriginal = value; OnPropertyChanged(_str_idfsTestStatusOriginal); } }
        }
        private long? m_idfsTestStatusOriginal;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LabTest";

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
        
            if (_Sample != null) { _Sample.Parent = this; }
                
            if (_SampleInfo != null) { _SampleInfo.Parent = this; }
                AmendmentHistory.ForEach(c => { c.Parent = this; });
                
            if (_FFPresenter != null) { _FFPresenter.Parent = this; }
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as LabTest;
            ret.bIsClone = true;
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
            var ret = base.Clone() as LabTest;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Sample != null)
              ret.Sample = _Sample.CloneWithSetup(manager, bRestricted) as LabSample;
                
            if (_SampleInfo != null)
              ret.SampleInfo = _SampleInfo.CloneWithSetup(manager, bRestricted) as LabTestSample;
                
            if (_AmendmentHistory != null && _AmendmentHistory.Count > 0)
            {
              ret.AmendmentHistory.Clear();
              _AmendmentHistory.ForEach(c => ret.AmendmentHistory.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_FFPresenter != null)
              ret.FFPresenter = _FFPresenter.CloneWithSetup(manager, bRestricted) as FFPresenterModel;
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public LabTest CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabTest;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfTesting; } }
        public string KeyName { get { return "idfTesting"; } }
        public object KeyLookup { get { return idfTesting; } }
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
        
                    || (_Sample != null && _Sample.HasChanges)
                
                    || (_SampleInfo != null && _SampleInfo.HasChanges)
                
                    || AmendmentHistory.IsDirty
                    || AmendmentHistory.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || (_FFPresenter != null && _FFPresenter.HasChanges)
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsTestStatus_TestStatus = idfsTestStatus;
            var _prev_idfsTestName_TestNameRef = idfsTestName;
            var _prev_idfsTestResult_TestResultRef = idfsTestResult;
            var _prev_idfsTestCategory_TestCategory = idfsTestCategory;
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfValidatedByPerson_ValidatedByPerson = idfValidatedByPerson;
            var _prev_idfTestedByPerson_TestedByPerson = idfTestedByPerson;
            base.RejectChanges();
        
            if (_prev_idfsTestStatus_TestStatus != idfsTestStatus)
            {
                _TestStatus = _TestStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestStatus);
            }
            if (_prev_idfsTestName_TestNameRef != idfsTestName)
            {
                _TestNameRef = _TestNameRefLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestName);
            }
            if (_prev_idfsTestResult_TestResultRef != idfsTestResult)
            {
                _TestResultRef = _TestResultRefLookup.FirstOrDefault(c => c.idfsReference == idfsTestResult);
            }
            if (_prev_idfsTestCategory_TestCategory != idfsTestCategory)
            {
                _TestCategory = _TestCategoryLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestCategory);
            }
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfValidatedByPerson_ValidatedByPerson != idfValidatedByPerson)
            {
                _ValidatedByPerson = _ValidatedByPersonLookup.FirstOrDefault(c => c.idfPerson == idfValidatedByPerson);
            }
            if (_prev_idfTestedByPerson_TestedByPerson != idfTestedByPerson)
            {
                _TestedByPerson = _TestedByPersonLookup.FirstOrDefault(c => c.idfPerson == idfTestedByPerson);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (Sample != null) Sample.DeepRejectChanges();
                
            if (SampleInfo != null) SampleInfo.DeepRejectChanges();
                AmendmentHistory.DeepRejectChanges();
                
            if (FFPresenter != null) FFPresenter.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Sample != null) _Sample.DeepAcceptChanges();
                
            if (_SampleInfo != null) _SampleInfo.DeepAcceptChanges();
                AmendmentHistory.DeepAcceptChanges();
                
            if (_FFPresenter != null) _FFPresenter.DeepAcceptChanges();
                
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
        
            if (_Sample != null) _Sample.SetChange();
                
            if (_SampleInfo != null) _SampleInfo.SetChange();
                AmendmentHistory.ForEach(c => c.SetChange());
                
            if (_FFPresenter != null) _FFPresenter.SetChange();
                
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
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
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

        private bool IsRIRPropChanged(string fld, LabTest c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, LabTest c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public LabTest()
        {
            
            m_permissions = new Permissions(this);
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabTest_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabTest_PropertyChanged);
        }
        private void LabTest_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabTest).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_AmendmentHistory)
                OnPropertyChanged(_str_strOriginalTestResult);
                  
            if (e.PropertyName == _str_TestResultRef)
                OnPropertyChanged(_str_strOriginalTestResult);
                  
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
            LabTest obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabTest obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
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

    
        private static string[] readonly_names1 = "AmendmentHistory".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "ResultEnteredByPerson,strMonitoringSessionID,strCaseID,DepartmentName,strBarcode,strOriginalTestResult,BatchTestCode".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "TestResultRef,strNote,TestedByPerson,datStartedDate,datConcludedDate,ValidatedByPerson".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LabTest, bool>(c => false)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LabTest, bool>(c => true)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LabTest, bool>(c => c.idfsTestStatus == (long)Enums.TestStatus.NotStarted || c.idfsTestStatus == (long)Enums.TestStatus.Amended || c.idfsTestStatusOriginal == (long)Enums.TestStatus.Finalized)(this);
            
            return ReadOnly || new Func<LabTest, bool>(c => c.idfsTestStatusOriginal == (long)Enums.TestStatus.Finalized || c.idfsTestStatusOriginal == (long)Enums.TestStatus.Amended)(this);
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
                if (_Sample != null)
                    _Sample._isValid &= value;
                
                if (_SampleInfo != null)
                    _SampleInfo._isValid &= value;
                
                foreach(var o in _AmendmentHistory)
                    o._isValid &= value;
                
                if (_FFPresenter != null)
                    _FFPresenter._isValid &= value;
                
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                if (_Sample != null)
                    _Sample.ReadOnly |= value;
                
                if (_SampleInfo != null)
                    _SampleInfo.ReadOnly |= value;
                
                foreach(var o in _AmendmentHistory)
                    o.ReadOnly |= value;
                
                if (_FFPresenter != null)
                    _FFPresenter.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<LabTest, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<LabTest, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabTest, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabTest, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<LabTest, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabTest, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<LabTest, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~LabTest()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                if (_Sample != null)
                    Sample.Dispose();
                
                if (_SampleInfo != null)
                    SampleInfo.Dispose();
                
                if (_FFPresenter != null)
                    FFPresenter.Dispose();
                
                if (!bIsClone)
                {
                    AmendmentHistory.ForEach(c => c.Dispose());
                }
                AmendmentHistory.ClearModelListEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("rftTestStatus", this);
                
                LookupManager.RemoveObject("rftTestName", this);
                
                LookupManager.RemoveObject("TestResultLookup", this);
                
                LookupManager.RemoveObject("rftTestCategory", this);
                
                LookupManager.RemoveObject("TestDiagnosisLookup", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftTestStatus")
                _getAccessor().LoadLookup_TestStatus(manager, this);
            
            if (lookup_object == "rftTestName")
                _getAccessor().LoadLookup_TestNameRef(manager, this);
            
            if (lookup_object == "TestResultLookup")
                _getAccessor().LoadLookup_TestResultRef(manager, this);
            
            if (lookup_object == "rftTestCategory")
                _getAccessor().LoadLookup_TestCategory(manager, this);
            
            if (lookup_object == "TestDiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_ValidatedByPerson(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_TestedByPerson(manager, this);
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            if (_Sample != null) _Sample.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_SampleInfo != null) _SampleInfo.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_AmendmentHistory != null) _AmendmentHistory.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_FFPresenter != null) _FFPresenter.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<LabTest>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<LabTest>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<LabTest>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfTesting"; } }
            #endregion
        
            public delegate void on_action(LabTest obj);
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
            private LabSample.Accessor SampleAccessor { get { return eidss.model.Schema.LabSample.Accessor.Instance(m_CS); } }
            private LabTestSample.Accessor SampleInfoAccessor { get { return eidss.model.Schema.LabTestSample.Accessor.Instance(m_CS); } }
            private LabTestAmendmentHistory.Accessor AmendmentHistoryAccessor { get { return eidss.model.Schema.LabTestAmendmentHistory.Accessor.Instance(m_CS); } }
            private FFPresenterModel.Accessor FFPresenterAccessor { get { return eidss.model.Schema.FFPresenterModel.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestNameRefAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private TestResultLookup.Accessor TestResultRefAccessor { get { return eidss.model.Schema.TestResultLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestCategoryAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private TestDiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.TestDiagnosisLookup.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor ValidatedByPersonAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor TestedByPersonAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            

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
            public virtual LabTest SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
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

            
            public virtual LabTest SelectByKey(DbManagerProxy manager
                , Int64? idfTesting
                )
            {
                return _SelectByKey(manager
                    , idfTesting
                    , null, null
                    );
            }
            

            private LabTest _SelectByKey(DbManagerProxy manager
                , Int64? idfTesting
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfTesting
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual LabTest _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfTesting
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[3];
                List<LabTest> objs = new List<LabTest>();
                sets[0] = new MapResultSet(typeof(LabTest), objs);
                
                List<LabTestSample> objs_LabTestSample = new List<LabTestSample>();
                sets[1] = new MapResultSet(typeof(LabTestSample), objs_LabTestSample);
                
                List<LabTestAmendmentHistory> objs_LabTestAmendmentHistory = new List<LabTestAmendmentHistory>();
                sets[2] = new MapResultSet(typeof(LabTestAmendmentHistory), objs_LabTestAmendmentHistory);
                LabTest obj = null;
                try
                {
                    manager
                        .SetSpCommand("spLabTestEditable_SelectDetail"
                            , manager.Parameter("@idfTesting", idfTesting)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    obj = objs[0];
                    obj.m_CS = m_CS;
                    
                  
                    if (loading != null)
                        loading(obj);
                    _SetupLoad(manager, obj);
                    SampleInfoAccessor._SetupLoad(manager, obj.SampleInfo);
                            
                    obj.AmendmentHistory.ForEach(c => AmendmentHistoryAccessor._SetupLoad(manager, c));
                            

                    //obj._setParent();
                    if (loaded != null)
                    loaded(obj);
                    obj.Loaded(manager);
                    return obj;
                  }
                  catch(DataException e)
                  {
                    throw DbModelException.Create(obj, e);
                  }
                
            }
    
            private void _SetupAddChildHandlerAmendmentHistory(LabTest obj)
            {
                obj.AmendmentHistory.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadSample(LabTest obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSample(manager, obj);
                }
            }
            internal void _LoadSample(DbManagerProxy manager, LabTest obj)
            {
              
                if (obj.Sample == null && obj.idfMaterial != null && obj.idfMaterial != 0)
                {
                    obj.Sample = SampleAccessor.SelectByKey(manager
                        
                        , obj.idfMaterial.Value
                        );
                    if (obj.Sample != null)
                    {
                        obj.Sample.m_ObjectName = _str_Sample;
                    }
                }
                    
              }
            
            internal void _LoadFFPresenter(LabTest obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFFPresenter(manager, obj);
                }
            }
            internal void _LoadFFPresenter(DbManagerProxy manager, LabTest obj)
            {
              
                if (obj.FFPresenter == null && obj.idfObservation != 0)
                {
                    obj.FFPresenter = FFPresenterAccessor.SelectByKey(manager
                        
                        , obj.idfObservation
                        );
                    if (obj.FFPresenter != null)
                    {
                        obj.FFPresenter.m_ObjectName = _str_FFPresenter;
                    }
                }
                    
              }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabTest obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj.idfsTestStatusOriginal = new Func<LabTest, long?>(c => c.idfsTestStatus)(obj);
                obj.idfValidatedByOffice = new Func<LabTest, long?>(c => c.idfValidatedByOffice ?? eidss.model.Core.EidssSiteContext.Instance.OrganizationID)(obj);
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadFFPresenter(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                          if (obj.idfsFormTemplate.HasValue) obj.FFPresenter.SetProperties(obj.idfsFormTemplate.Value, obj.idfTesting);
                        
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerAmendmentHistory(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, LabTest obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    SampleAccessor._SetPermitions(obj._permissions, obj.Sample);
                    SampleInfoAccessor._SetPermitions(obj._permissions, obj.SampleInfo);
                    FFPresenterAccessor._SetPermitions(obj._permissions, obj.FFPresenter);
                    
                        obj.AmendmentHistory.ForEach(c => AmendmentHistoryAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private LabTest _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                LabTest obj = null;
                try
                {
                    obj = LabTest.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfTesting = (new GetNewIDExtender<LabTest>()).GetScalar(manager, obj, isFake);
                obj.idfObservation = (new GetNewIDExtender<LabTest>()).GetScalar(manager, obj, isFake);
                obj.idfValidatedByOffice = new Func<LabTest, long?>(c => eidss.model.Core.EidssSiteContext.Instance.OrganizationID)(obj);
                obj.idfTestedByOffice = new Func<LabTest, long?>(c => eidss.model.Core.EidssSiteContext.Instance.OrganizationID)(obj);
                obj.blnNonLaboratoryTest = new Func<LabTest, bool>(c => false)(obj);
                            obj.FFPresenter = FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, obj.idfObservation);
                            obj.FFPresenter.SetProperties(EidssSiteContext.Instance.CountryID, null, FFTypeEnum.TestDetails, obj.idfObservation, obj.idfTesting);
                            if (obj.FFPresenter.CurrentTemplate != null) obj.idfsFormTemplate = obj.FFPresenter.CurrentTemplate.idfsFormTemplate;
                        
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerAmendmentHistory(obj);
                    
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
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public LabTest CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public LabTest CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public LabTest CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public LabTest CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfMaterial", typeof(long));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public LabTest Create(DbManagerProxy manager, IObject Parent
                , long idfMaterial
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.SampleInfo = new Func<LabTest, LabTestSample>(c => SampleInfoAccessor.CreateNewT(manager, c))(obj);
                obj.idfMaterial = new Func<LabTest, long>(c => idfMaterial)(obj);
                obj.idfsTestStatusOriginal = new Func<LabTest, long?>(c => (long)Enums.TestStatus.NotStarted)(obj);
                }
                    , obj =>
                {
                obj.TestStatus = new Func<LabTest, BaseReference>(c => c.TestStatusLookup.Where(l => l.idfsBaseReference == (long)Enums.TestStatus.NotStarted).SingleOrDefault())(obj);
                obj.TestCategory = new Func<LabTest, BaseReference>(c => c.TestCategoryLookup.Where(l => l.idfsBaseReference == (long)TestCategoryEnum.Presumptive).SingleOrDefault())(obj);
                obj.Diagnosis = new Func<LabTest, TestDiagnosisLookup>(c => 
                                          c.Sample.idfMonitoringSession == null 
                                            ? c.DiagnosisLookup.Where(l => l.idfsDiagnosis == c.Sample.idfsShowDiagnosis).SingleOrDefault()
                                            : c.DiagnosisLookup.FirstOrDefault()
                                          )(obj);
                obj.strCaseID = new Func<LabTest, string>(c => c.Sample.strCaseID)(obj);
                obj.idfCase = new Func<LabTest, long?>(c => c.Sample.idfCase)(obj);
                obj.strMonitoringSessionID = new Func<LabTest, string>(c => c.Sample.strMonitoringSessionID)(obj);
                obj.idfMonitoringSession = new Func<LabTest, long?>(c => c.Sample.idfMonitoringSession)(obj);
                obj.idfsCaseType = new Func<LabTest, long?>(c => c.Sample.idfsCaseType)(obj);
                obj.intHACode = new Func<LabTest, int>(c => c.Sample.intHACode)(obj);
                obj.datAccession = new Func<LabTest, DateTime?>(c => c.Sample.datAccession)(obj);
                obj.SampleInfo.idfMaterial = new Func<LabTest, long>(c => idfMaterial)(obj);
                obj.SampleInfo.strBarcode = new Func<LabTest, string>(c => c.Sample.strBarcode)(obj);
                obj.SampleInfo.strSampleName = new Func<LabTest, string>(c => c.Sample.strSampleName)(obj);
                obj.SampleInfo.datFieldCollectionDate = new Func<LabTest, DateTime?>(c => c.Sample.datFieldCollectionDate)(obj);
                obj.SampleInfo.HumanName = new Func<LabTest, string>(c => string.IsNullOrEmpty(c.Sample.SpeciesName) ? c.Sample.HumanName : c.Sample.SpeciesName)(obj);
                }
                );
            }
            
            public ActResult TestResultReport(DbManagerProxy manager, LabTest obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("ObjID", typeof(long));
                if (pars[1] != null && !(pars[1] is long)) 
                    throw new TypeMismatchException("CSObjID", typeof(long));
                if (pars[2] != null && !(pars[2] is long)) 
                    throw new TypeMismatchException("TypeID", typeof(long));
                
                return TestResultReport(manager, obj
                    , (long)pars[0]
                    , (long)pars[1]
                    , (long)pars[2]
                    );
            }
            public ActResult TestResultReport(DbManagerProxy manager, LabTest obj
                , long ObjID
                , long CSObjID
                , long TypeID
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("TestResultReport"))
                    throw new PermissionException("Test", "TestResultReport");
                
                return true;
                
            }
            
      
            public ActResult AmendTest(DbManagerProxy manager, LabTest obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is LabTestAmendmentHistory)) 
                    throw new TypeMismatchException("item", typeof(LabTestAmendmentHistory));
                
                return AmendTest(manager, obj
                    , (LabTestAmendmentHistory)pars[0]
                    );
            }
            public ActResult AmendTest(DbManagerProxy manager, LabTest obj
                , LabTestAmendmentHistory item
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("AmendTest"))
                    throw new PermissionException("Test", "AmendTest");
                
                        obj.strNote = item.strNewNote;
                        obj.TestResultRef = obj.TestResultRefLookup.Where(l => l.idfsReference == item.idfsNewTestResult).SingleOrDefault();
                        obj.TestStatus = obj.TestStatusLookup.Where(l => l.idfsBaseReference == (long)Enums.TestStatus.Amended).SingleOrDefault();
                        if (obj.AmendmentHistory.Where(c => c.IsNew).SingleOrDefault() == null)
                        {
                            obj.AmendmentHistory.Add(item);
                        }
                        return true;
                    
            }
            
      
            private void _SetupChildHandlers(LabTest obj, object newobj)
            {
                
                    if (obj.SampleInfo != null && (newobj == null || newobj == obj.SampleInfo))
                    {
                        var o = obj.SampleInfo;
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "datAccession")
                            {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datAccession");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                    }
                  
            }
            
            private void _SetupHandlers(LabTest obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datStartedDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datStartedDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datConcludedDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datConcludedDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                            try
                            {
                            
                (new PredicateValidator("mbSureToUndefinedStatus", "idfsTestStatus", "idfsTestStatus", "idfsTestStatus",
              new object[] {
              },
                        ValidationEventType.Question
                    )).Validate(obj, c => !(c.idfsTestStatusOriginal == (long)Enums.TestStatus.InProcess && c.idfsTestStatus == (long)Enums.TestStatus.NotStarted)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_idfsTestStatus);
                                    obj._TestStatus = obj.TestStatusLookup.Where(a => a.idfsBaseReference == obj.idfsTestStatus).SingleOrDefault();
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                                
                            }
                        }
                    
                        if (e.PropertyName == _str_idfsCaseType)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestNameRef(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_intHACode)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestNameRef(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestName)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestResultRef(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.TestResultRef = new Func<LabTest, TestResultLookup>(c => (c.idfsTestStatusOriginal == (long)Enums.TestStatus.InProcess && c.idfsTestStatus == (long)Enums.TestStatus.NotStarted) ? null : c.TestResultRef)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.strNote = new Func<LabTest, string>(c => (c.idfsTestStatusOriginal == (long)Enums.TestStatus.InProcess && c.idfsTestStatus == (long)Enums.TestStatus.NotStarted) ? null : c.strNote)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.TestedByPerson = new Func<LabTest, PersonLookup>(c => (c.idfsTestStatusOriginal == (long)Enums.TestStatus.InProcess && c.idfsTestStatus == (long)Enums.TestStatus.NotStarted) ? null : c.TestedByPerson)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.ValidatedByPerson = new Func<LabTest, PersonLookup>(c => (c.idfsTestStatusOriginal == (long)Enums.TestStatus.InProcess && c.idfsTestStatus == (long)Enums.TestStatus.NotStarted) ? null : c.ValidatedByPerson)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.datStartedDate = new Func<LabTest, DateTime?>(c => (c.idfsTestStatusOriginal == (long)Enums.TestStatus.InProcess && c.idfsTestStatus == (long)Enums.TestStatus.NotStarted) ? null : c.datStartedDate)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.datConcludedDate = new Func<LabTest, DateTime?>(c => (c.idfsTestStatusOriginal == (long)Enums.TestStatus.InProcess && c.idfsTestStatus == (long)Enums.TestStatus.NotStarted) ? null : c.datConcludedDate)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestResult)
                        {
                    
                obj.idfResultEnteredByOffice = new Func<LabTest, long?>(c => c.idfsTestResult == null ? (long?)null : eidss.model.Core.EidssSiteContext.Instance.OrganizationID)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestResult)
                        {
                    
                obj.idfResultEnteredByPerson = new Func<LabTest, long?>(c => c.idfsTestResult == null ? (long?)null : (long)ModelUserContext.Instance.CurrentUser.EmployeeID)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestResult)
                        {
                    
                obj.ResultEnteredByPerson = new Func<LabTest, string>(c => c.idfsTestResult == null ? null : ModelUserContext.Instance.CurrentUser.FullName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.idfResultEnteredByOffice = new Func<LabTest, long?>(c => (c.idfsTestStatus == null || c.idfsTestStatus == (long)Enums.TestStatus.NotStarted) ? null : (c.idfsTestResult == null ? (long?)null : eidss.model.Core.EidssSiteContext.Instance.OrganizationID))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.idfResultEnteredByPerson = new Func<LabTest, long?>(c => (c.idfsTestStatus == null || c.idfsTestStatus == (long)Enums.TestStatus.NotStarted) ? null : (c.idfsTestResult == null ? (long?)null : (long)ModelUserContext.Instance.CurrentUser.EmployeeID))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.ResultEnteredByPerson = new Func<LabTest, string>(c => (c.idfsTestStatus == null || c.idfsTestStatus == (long)Enums.TestStatus.NotStarted) ? "" : (c.idfsTestResult == null ? null : ModelUserContext.Instance.CurrentUser.FullName))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                            if (obj.idfsDiagnosis != 0 && obj.idfsTestName.HasValue)
                            {
                                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                                {
                                    long? idfsTestCategory = manager.SetSpCommand("dbo.spLabTest_GetDefaultCategory"
                                        , manager.Parameter("idfsDiagnosis", obj.idfsDiagnosis)
                                        , manager.Parameter("idfsTestName", obj.idfsTestName)
                                        ).ExecuteScalar<long?>();
                                    if (idfsTestCategory.HasValue)
                                        obj.TestCategory = obj.TestCategoryLookup.Where(a => a.idfsBaseReference == idfsTestCategory.Value).SingleOrDefault();
                                }
                            }
                        
                        }
                    
                        if (e.PropertyName == _str_idfsTestName)
                        {
                    
                            if (obj.idfsDiagnosis != 0 && obj.idfsTestName.HasValue)
                            {
                                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                                {
                                    long? idfsTestCategory = manager.SetSpCommand("dbo.spLabTest_GetDefaultCategory"
                                        , manager.Parameter("idfsDiagnosis", obj.idfsDiagnosis)
                                        , manager.Parameter("idfsTestName", obj.idfsTestName)
                                        ).ExecuteScalar<long?>();
                                    if (idfsTestCategory.HasValue)
                                        obj.TestCategory = obj.TestCategoryLookup.Where(a => a.idfsBaseReference == idfsTestCategory.Value).SingleOrDefault();
                                }
                            }
                        
                        }
                    
                    };
                
            }
    
            public void LoadLookup_TestStatus(DbManagerProxy manager, LabTest obj)
            {
                
                obj.TestStatusLookup.Clear();
                
                obj.TestStatusLookup.Add(TestStatusAccessor.CreateNewT(manager, null));
                
                obj.TestStatusLookup.AddRange(TestStatusAccessor.rftTestStatus_SelectList(manager
                    
                    )
                    .Where(c => 
                                (obj.idfsTestStatusOriginal == (long)Enums.TestStatus.NotStarted && (c.idfsBaseReference == (long)Enums.TestStatus.Finalized || c.idfsBaseReference == (long)Enums.TestStatus.InProcess || c.idfsBaseReference == (long)Enums.TestStatus.NotStarted)) ||
                                (obj.idfsTestStatusOriginal == (long)Enums.TestStatus.InProcess && (c.idfsBaseReference == (long)Enums.TestStatus.Finalized || c.idfsBaseReference == (long)Enums.TestStatus.InProcess || c.idfsBaseReference == (long)Enums.TestStatus.NotStarted)) ||
                                (obj.idfsTestStatusOriginal == (long)Enums.TestStatus.Finalized && (c.idfsBaseReference == (long)Enums.TestStatus.Finalized || c.idfsBaseReference == (long)Enums.TestStatus.Amended)) ||
                                (obj.idfsTestStatusOriginal == (long)Enums.TestStatus.Amended && (c.idfsBaseReference == (long)Enums.TestStatus.Amended))
                                )
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestStatus))
                    
                    .ToList());
                
                if (obj.idfsTestStatus != 0)
                {
                    obj.TestStatus = obj.TestStatusLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsTestStatus);
                    
                }
              
                LookupManager.AddObject("rftTestStatus", obj, TestStatusAccessor.GetType(), "rftTestStatus_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_TestNameRef(DbManagerProxy manager, LabTest obj)
            {
                
                obj.TestNameRefLookup.Clear();
                
                obj.TestNameRefLookup.Add(TestNameRefAccessor.CreateNewT(manager, null));
                
                obj.TestNameRefLookup.AddRange(TestNameRefAccessor.rftTestName_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode & obj.intHACode) != 0 || c.idfsBaseReference == obj.idfsTestName)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestName))
                    
                    .ToList());
                
                if (obj.idfsTestName != null && obj.idfsTestName != 0)
                {
                    obj.TestNameRef = obj.TestNameRefLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsTestName);
                    
                }
              
                LookupManager.AddObject("rftTestName", obj, TestNameRefAccessor.GetType(), "rftTestName_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_TestResultRef(DbManagerProxy manager, LabTest obj)
            {
                
                obj.TestResultRefLookup.Clear();
                
                obj.TestResultRefLookup.Add(TestResultRefAccessor.CreateNewT(manager, null));
                
                obj.TestResultRefLookup.AddRange(TestResultRefAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => c.idfsTestName == obj.idfsTestName)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsTestResult))
                    
                    .ToList());
                
                if (obj.idfsTestResult != null && obj.idfsTestResult != 0)
                {
                    obj.TestResultRef = obj.TestResultRefLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsTestResult);
                    
                }
              
                LookupManager.AddObject("TestResultLookup", obj, TestResultRefAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_TestCategory(DbManagerProxy manager, LabTest obj)
            {
                
                obj.TestCategoryLookup.Clear();
                
                obj.TestCategoryLookup.Add(TestCategoryAccessor.CreateNewT(manager, null));
                
                obj.TestCategoryLookup.AddRange(TestCategoryAccessor.rftTestCategory_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestCategory))
                    
                    .ToList());
                
                if (obj.idfsTestCategory != null && obj.idfsTestCategory != 0)
                {
                    obj.TestCategory = obj.TestCategoryLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsTestCategory);
                    
                }
              
                LookupManager.AddObject("rftTestCategory", obj, TestCategoryAccessor.GetType(), "rftTestCategory_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Diagnosis(DbManagerProxy manager, LabTest obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    , new Func<LabTest, long?>(c => c.idfMaterial)(obj)
                            
                    , new Func<LabTest, long?>(c => null)(obj)
                            
                    , new Func<LabTest, long?>(c => null)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosis);
                    
                }
              
                LookupManager.AddObject("TestDiagnosisLookup", obj, DiagnosisAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_ValidatedByPerson(DbManagerProxy manager, LabTest obj)
            {
                
                obj.ValidatedByPersonLookup.Clear();
                
                obj.ValidatedByPersonLookup.Add(ValidatedByPersonAccessor.CreateNewT(manager, null));
                
                obj.ValidatedByPersonLookup.AddRange(ValidatedByPersonAccessor.SelectLookupList(manager
                    
                    , new Func<LabTest, long?>(c => c.idfValidatedByOffice)(obj)
                            
                    , null
                    , false
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfValidatedByPerson))
                    
                    .ToList());
                
                if (obj.idfValidatedByPerson != null && obj.idfValidatedByPerson != 0)
                {
                    obj.ValidatedByPerson = obj.ValidatedByPersonLookup
                        .SingleOrDefault(c => c.idfPerson == obj.idfValidatedByPerson);
                    
                }
              
                LookupManager.AddObject("PersonLookup", obj, ValidatedByPersonAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_TestedByPerson(DbManagerProxy manager, LabTest obj)
            {
                
                obj.TestedByPersonLookup.Clear();
                
                obj.TestedByPersonLookup.Add(TestedByPersonAccessor.CreateNewT(manager, null));
                
                obj.TestedByPersonLookup.AddRange(TestedByPersonAccessor.SelectLookupList(manager
                    
                    , new Func<LabTest, long?>(c => c.idfTestedByOffice)(obj)
                            
                    , null
                    , false
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfTestedByPerson))
                    
                    .ToList());
                
                if (obj.idfTestedByPerson != null && obj.idfTestedByPerson != 0)
                {
                    obj.TestedByPerson = obj.TestedByPersonLookup
                        .SingleOrDefault(c => c.idfPerson == obj.idfTestedByPerson);
                    
                }
              
                LookupManager.AddObject("PersonLookup", obj, TestedByPersonAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, LabTest obj)
            {
                
                LoadLookup_TestStatus(manager, obj);
                
                LoadLookup_TestNameRef(manager, obj);
                
                LoadLookup_TestResultRef(manager, obj);
                
                LoadLookup_TestCategory(manager, obj);
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_ValidatedByPerson(manager, obj);
                
                LoadLookup_TestedByPerson(manager, obj);
                
            }
    
            [SprocName("spLabTest_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spLabTestEditable_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] LabTest obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] LabTest obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bSuccess = false;
                int iDeadlockAttemptsCount = BaseSettings.DeadlockAttemptsCount;
                for (int iAttemptNumber = 0; iAttemptNumber < iDeadlockAttemptsCount; iAttemptNumber++)
                {
                    bool bTransactionStarted = false;
                    try
                    {
                        LabTest bo = obj as LabTest;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            if (!CanDelete)
                                throw new PermissionException("Test", "Delete");
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            if (!CanInsert)
                                throw new PermissionException("Test", "Insert");
                        }
                        else if (!bo.IsMarkedToDelete && bo.HasChanges) // update
                        {
                            if (!CanUpdate)
                                throw new PermissionException("Test", "Update");
                        }
                        
                        long mainObject = bo.idfTesting;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            
                            if (new Func<LabTest, bool>(c => c.idfCase.HasValue && c.idfCase.Value != 0 && c.idfsCaseType == (long)CaseTypeEnum.Human)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.HumanTestResultRegistrationLocal, bo.idfCase, "" });
                            
                            if (new Func<LabTest, bool>(c => c.idfCase.HasValue && c.idfCase.Value != 0 && (c.idfsCaseType == (long)CaseTypeEnum.Livestock || c.idfsCaseType == (long)CaseTypeEnum.Avian))(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.VetCaseTestResultRegistrationLocal, bo.idfCase, "" });
                            
                            if (new Func<LabTest, bool>(c => c.idfMonitoringSession.HasValue && c.idfMonitoringSession.Value != 0)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.AsSessionTestResultRegistrationLocal, bo.idfMonitoringSession, "" });
                            
                            if (new Func<LabTest, bool>(c => c.idfVectorSurveillanceSession.HasValue && c.idfVectorSurveillanceSession.Value != 0)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.VsSessionTestResultRegistrationLocal, bo.idfVectorSurveillanceSession, "" });
                            
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            
                            if (new Func<LabTest, bool>(c => c.idfCase.HasValue && c.idfCase.Value != 0 && c.idfsCaseType == (long)CaseTypeEnum.Human && c.AmendmentHistory.Count(i => i.IsNew && !i.IsMarkedToDelete) > 0)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.HumanTestResultAmendmentLocal, bo.idfCase, "" });
                            
                            if (new Func<LabTest, bool>(c => c.idfCase.HasValue && c.idfCase.Value != 0 && (c.idfsCaseType == (long)CaseTypeEnum.Livestock || c.idfsCaseType == (long)CaseTypeEnum.Avian) && c.AmendmentHistory.Count(i => i.IsNew && !i.IsMarkedToDelete) > 0)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.VetCaseTestResultAmendmentLocal, bo.idfCase, "" });
                            
                            if (new Func<LabTest, bool>(c => c.idfMonitoringSession.HasValue && c.idfMonitoringSession.Value != 0 && c.AmendmentHistory.Count(i => i.IsNew && !i.IsMarkedToDelete) > 0)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.AsSessionTestResultAmendmentLocal, bo.idfMonitoringSession, "" });
                            
                            if (new Func<LabTest, bool>(c => c.idfVectorSurveillanceSession.HasValue && c.idfVectorSurveillanceSession.Value != 0 && c.AmendmentHistory.Count(i => i.IsNew && !i.IsMarkedToDelete) > 0)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.VsSessionTestResultAmendmentLocal, bo.idfVectorSurveillanceSession, "" });
                            
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
                        bSuccess = _PostNonTransaction(manager, obj as LabTest, bChildObject);
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
                        
                        break;
                    }
                    catch(Exception e)
                    {
                        if (bTransactionStarted)
                        {
                            manager.RollbackTransaction();
                            
                            if (DbModelException.IsDeadlockException(e))
                            {
                                System.Threading.Thread.Sleep(BaseSettings.DeadlockDelay);
                                continue;
                            }
                        }
                    
                        if (e is DataException)
                        {
                            throw DbModelException.Create(obj, e as DataException);
                        }
                        if (e is System.Data.SqlClient.SqlException)
                        {
                            throw DbModelException.Create(obj, e as System.Data.SqlClient.SqlException);
                        }
                        else 
                            throw;
                    }
                }
                return bSuccess;
            }
            private bool _PostNonTransaction(DbManagerProxy manager, LabTest obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                                        
                    _postPredicate(manager, 8, obj);
                                            
                    if (obj.AmendmentHistory != null)
                    {
                        foreach (var i in obj.AmendmentHistory)
                        {
                            i.MarkToDelete();
                            if (!AmendmentHistoryAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                            
                    if (obj.FFPresenter != null)
                    {
                        obj.FFPresenter.MarkToDelete();
                        if (!FFPresenterAccessor.Post(manager, obj.FFPresenter, true))
                            return false;
                    }
                                            
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                                    
                    if (obj.IsNew)
                    {
                        if (obj.AmendmentHistory != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.AmendmentHistory)
                                if (!AmendmentHistoryAccessor.Post(manager, i, true))
                                    return false;
                            obj.AmendmentHistory.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.AmendmentHistory.Remove(c));
                            obj.AmendmentHistory.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._AmendmentHistory != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._AmendmentHistory)
                                if (!AmendmentHistoryAccessor.Post(manager, i, true))
                                    return false;
                            obj._AmendmentHistory.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._AmendmentHistory.Remove(c));
                            obj._AmendmentHistory.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.FFPresenter != null) // forced load potential lazy subobject for new object
                            if (!FFPresenterAccessor.Post(manager, obj.FFPresenter, true))
                                return false;
                    }
                    else
                    {
                        if (obj._FFPresenter != null) // do not load lazy subobject for existing object
                            if (!FFPresenterAccessor.Post(manager, obj.FFPresenter, true))
                                return false;
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(LabTest obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, LabTest obj)
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
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, ValidationEventType.Error, obj);
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
        
      
            protected ValidationModelException ChainsValidate(LabTest obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<LabTest>(obj, "datAccession", c => true, 
      obj.SampleInfo == null ? null : obj.SampleInfo.datAccession,
      obj.SampleInfo == null ? null : obj.SampleInfo.GetType(),
      false, listdatAccession => {
    listdatAccession.Add(
    new ChainsValidatorDateTime<LabTest>(obj, "datStartedDate", c => true, 
      obj.datStartedDate,
      obj.GetType(),
      false, listdatStartedDate => {
    listdatStartedDate.Add(
    new ChainsValidatorDateTime<LabTest>(obj, "datConcludedDate", c => true, 
      obj.datConcludedDate,
      obj.GetType(),
      false, listdatConcludedDate => {
    listdatConcludedDate.Add(
    new ChainsValidatorDateTime<LabTest>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }));
  
    }));
  
    }).Process();
  
                }
                catch(ValidationModelException ex)
                {
                    return ex;
                }
                
                return null;
            }
            protected bool ChainsValidate(LabTest obj, bool bRethrowException)
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
                return Validate(manager, obj as LabTest, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabTest obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsTestName", "TestNameRef","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsTestName);
            
                (new RequiredValidator( "idfsTestCategory", "TestCategory","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsTestCategory);
            
                (new RequiredValidator( "idfsDiagnosis", "Diagnosis","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsDiagnosis);
            
                (new RequiredValidator( "idfsTestStatus", "TestStatus","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsTestStatus);
            
                (new RequiredValidator( "idfsTestResult", "TestResultRef","",
                ValidationEventType.Error
              )).Validate(c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized || c.idfsTestStatus == (long)Enums.TestStatus.Amended), obj, obj.idfsTestResult);
            
                (new RequiredValidator( "idfTestedByPerson", "TestedByPerson","",
                ValidationEventType.Error
              )).Validate(c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized), obj, obj.idfTestedByPerson);
            
                (new RequiredValidator( "datStartedDate", "datStartedDate","",
                ValidationEventType.Error
              )).Validate(c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized), obj, obj.datStartedDate);
            
                (new RequiredValidator( "datConcludedDate", "datConcludedDate","",
                ValidationEventType.Error
              )).Validate(c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized), obj, obj.datConcludedDate);
            
                (new RequiredValidator( "idfValidatedByPerson", "ValidatedByPerson","",
                ValidationEventType.Error
              )).Validate(c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized), obj, obj.idfValidatedByPerson);
            
                CustomValidations(obj);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.AmendmentHistory != null)
                            foreach (var i in obj.AmendmentHistory.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                AmendmentHistoryAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FFPresenter != null)
                            FFPresenterAccessor.Validate(manager, obj.FFPresenter, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                    }
                }
                catch(ValidationModelException ex)
                {
                    if (bRethrowException)
                        throw;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                
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
            
            private void _SetupRequired(LabTest obj)
            {
            
                obj
                    .AddRequired("TestNameRef", c => true);
                    
                  obj
                    .AddRequired("TestNameRef", c => true);
                
                obj
                    .AddRequired("TestCategory", c => true);
                    
                  obj
                    .AddRequired("TestCategory", c => true);
                
                obj
                    .AddRequired("Diagnosis", c => true);
                    
                  obj
                    .AddRequired("Diagnosis", c => true);
                
                obj
                    .AddRequired("TestStatus", c => true);
                    
                  obj
                    .AddRequired("TestStatus", c => true);
                
                obj
                    .AddRequired("TestResultRef", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized || c.idfsTestStatus == (long)Enums.TestStatus.Amended));
                    
                  obj
                    .AddRequired("TestResultRef", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized || c.idfsTestStatus == (long)Enums.TestStatus.Amended));
                
                obj
                    .AddRequired("TestedByPerson", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized));
                    
                  obj
                    .AddRequired("TestedByPerson", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized));
                
                obj
                    .AddRequired("datStartedDate", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized));
                    
                obj
                    .AddRequired("datConcludedDate", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized));
                    
                obj
                    .AddRequired("ValidatedByPerson", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized));
                    
                  obj
                    .AddRequired("ValidatedByPerson", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized));
                
            }
    
    private void _SetupPersonalDataRestrictions(LabTest obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabTest) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabTest) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabTestDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private LabTest m_obj;
            internal Permissions(LabTest obj)
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
            public static string spSelect = "spLabTestEditable_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spLabTestEditable_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "spLabTest_CanDelete";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabTest, bool>> RequiredByField = new Dictionary<string, Func<LabTest, bool>>();
            public static Dictionary<string, Func<LabTest, bool>> RequiredByProperty = new Dictionary<string, Func<LabTest, bool>>();
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
                
                Sizes.Add(_str_strNote, 500);
                Sizes.Add(_str_BatchTestCode, 200);
                Sizes.Add(_str_strContactPerson, 200);
                Sizes.Add(_str_strMonitoringSessionID, 50);
                Sizes.Add(_str_strCaseID, 200);
                Sizes.Add(_str_SessionID, 50);
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_DepartmentName, 2000);
                Sizes.Add(_str_ResultEnteredByPerson, 400);
                if (!RequiredByField.ContainsKey("idfsTestName")) RequiredByField.Add("idfsTestName", c => true);
                if (!RequiredByProperty.ContainsKey("TestNameRef")) RequiredByProperty.Add("TestNameRef", c => true);
                
                if (!RequiredByField.ContainsKey("idfsTestCategory")) RequiredByField.Add("idfsTestCategory", c => true);
                if (!RequiredByProperty.ContainsKey("TestCategory")) RequiredByProperty.Add("TestCategory", c => true);
                
                if (!RequiredByField.ContainsKey("idfsDiagnosis")) RequiredByField.Add("idfsDiagnosis", c => true);
                if (!RequiredByProperty.ContainsKey("Diagnosis")) RequiredByProperty.Add("Diagnosis", c => true);
                
                if (!RequiredByField.ContainsKey("idfsTestStatus")) RequiredByField.Add("idfsTestStatus", c => true);
                if (!RequiredByProperty.ContainsKey("TestStatus")) RequiredByProperty.Add("TestStatus", c => true);
                
                if (!RequiredByField.ContainsKey("idfsTestResult")) RequiredByField.Add("idfsTestResult", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized || c.idfsTestStatus == (long)Enums.TestStatus.Amended));
                if (!RequiredByProperty.ContainsKey("TestResultRef")) RequiredByProperty.Add("TestResultRef", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized || c.idfsTestStatus == (long)Enums.TestStatus.Amended));
                
                if (!RequiredByField.ContainsKey("idfTestedByPerson")) RequiredByField.Add("idfTestedByPerson", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized));
                if (!RequiredByProperty.ContainsKey("TestedByPerson")) RequiredByProperty.Add("TestedByPerson", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized));
                
                if (!RequiredByField.ContainsKey("datStartedDate")) RequiredByField.Add("datStartedDate", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized));
                if (!RequiredByProperty.ContainsKey("datStartedDate")) RequiredByProperty.Add("datStartedDate", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized));
                
                if (!RequiredByField.ContainsKey("datConcludedDate")) RequiredByField.Add("datConcludedDate", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized));
                if (!RequiredByProperty.ContainsKey("datConcludedDate")) RequiredByProperty.Add("datConcludedDate", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized));
                
                if (!RequiredByField.ContainsKey("idfValidatedByPerson")) RequiredByField.Add("idfValidatedByPerson", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized));
                if (!RequiredByProperty.ContainsKey("ValidatedByPerson")) RequiredByProperty.Add("ValidatedByPerson", c => (c.idfsTestStatus == (long)Enums.TestStatus.Finalized));
                
                Actions.Add(new ActionMetaItem(
                    "TestResultReport",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).TestResultReport(manager, (LabTest)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titlePaperForms",
                        "Report",
                        /*from BvMessages*/"",
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
                    (o1, o2, p, r) => eidss.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("LimTest"),
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
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
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "AmendTest",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).AmendTest(manager, (LabTest)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"Amend",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      true,
                    "CanAmendTest",
                    null,
                    (c, p, b) => (c as LabTest).idfsTestStatusOriginal == (long)Enums.TestStatus.Finalized || (c as LabTest).idfsTestStatusOriginal == (long)Enums.TestStatus.Amended,
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
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabTest>().Post(manager, (LabTest)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabTest>().Post(manager, (LabTest)c), c),
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
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class LabTestSample : 
        EditableObject<LabTestSample>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfMaterial), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMaterial { get; set; }
                
        [LocalizedDisplayName("SampleID")]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSampleName)]
        [MapField(_str_strSampleName)]
        public abstract String strSampleName { get; set; }
        protected String strSampleName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).OriginalValue; } }
        protected String strSampleName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).PreviousValue; } }
                
        [LocalizedDisplayName("DateCollected")]
        [MapField(_str_datFieldCollectionDate)]
        public abstract DateTime? datFieldCollectionDate { get; set; }
        protected DateTime? datFieldCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).OriginalValue; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datAccession)]
        [MapField(_str_datAccession)]
        public abstract DateTime? datAccession { get; set; }
        protected DateTime? datAccession_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).OriginalValue; } }
        protected DateTime? datAccession_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).PreviousValue; } }
                
        [LocalizedDisplayName("HumanSpeciesName")]
        [MapField(_str_HumanName)]
        public abstract String HumanName { get; set; }
        protected String HumanName_Original { get { return ((EditableValue<String>)((dynamic)this)._humanName).OriginalValue; } }
        protected String HumanName_Previous { get { return ((EditableValue<String>)((dynamic)this)._humanName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_AnimalName)]
        [MapField(_str_AnimalName)]
        public abstract String AnimalName { get; set; }
        protected String AnimalName_Original { get { return ((EditableValue<String>)((dynamic)this)._animalName).OriginalValue; } }
        protected String AnimalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._animalName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strAnimalCode)]
        [MapField(_str_strAnimalCode)]
        public abstract String strAnimalCode { get; set; }
        protected String strAnimalCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strAnimalCode).OriginalValue; } }
        protected String strAnimalCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAnimalCode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strVectorCode)]
        [MapField(_str_strVectorCode)]
        public abstract String strVectorCode { get; set; }
        protected String strVectorCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorCode).OriginalValue; } }
        protected String strVectorCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorCode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPartyName)]
        [MapField(_str_strPartyName)]
        public abstract String strPartyName { get; set; }
        protected String strPartyName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPartyName).OriginalValue; } }
        protected String strPartyName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPartyName).PreviousValue; } }
                
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
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<LabTestSample, object> _get_func;
            internal Action<LabTestSample, string> _set_func;
            internal Action<LabTestSample, LabTestSample, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_strSampleName = "strSampleName";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_datAccession = "datAccession";
        internal const string _str_HumanName = "HumanName";
        internal const string _str_AnimalName = "AnimalName";
        internal const string _str_strAnimalCode = "strAnimalCode";
        internal const string _str_strVectorCode = "strVectorCode";
        internal const string _str_strPartyName = "strPartyName";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_idfsCurrentSite = "idfsCurrentSite";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfMaterial, _formname = _str_idfMaterial, _type = "Int64",
              _get_func = o => o.idfMaterial,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfMaterial != newval) o.idfMaterial = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfMaterial != c.idfMaterial || o.IsRIRPropChanged(_str_idfMaterial, c)) 
                  m.Add(_str_idfMaterial, o.ObjectIdent + _str_idfMaterial, o.ObjectIdent2 + _str_idfMaterial, o.ObjectIdent3 + _str_idfMaterial, "Int64", 
                    o.idfMaterial == null ? "" : o.idfMaterial.ToString(),                  
                  o.IsReadOnly(_str_idfMaterial), o.IsInvisible(_str_idfMaterial), o.IsRequired(_str_idfMaterial)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strBarcode, _formname = _str_strBarcode, _type = "String",
              _get_func = o => o.strBarcode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strBarcode != newval) o.strBarcode = newval; },
              _compare_func = (o, c, m, g) => {
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
              _compare_func = (o, c, m, g) => {
                if (o.strSampleName != c.strSampleName || o.IsRIRPropChanged(_str_strSampleName, c)) 
                  m.Add(_str_strSampleName, o.ObjectIdent + _str_strSampleName, o.ObjectIdent2 + _str_strSampleName, o.ObjectIdent3 + _str_strSampleName, "String", 
                    o.strSampleName == null ? "" : o.strSampleName.ToString(),                  
                  o.IsReadOnly(_str_strSampleName), o.IsInvisible(_str_strSampleName), o.IsRequired(_str_strSampleName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datFieldCollectionDate, _formname = _str_datFieldCollectionDate, _type = "DateTime?",
              _get_func = o => o.datFieldCollectionDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datFieldCollectionDate != newval) o.datFieldCollectionDate = newval; },
              _compare_func = (o, c, m, g) => {
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
              _compare_func = (o, c, m, g) => {
                if (o.datAccession != c.datAccession || o.IsRIRPropChanged(_str_datAccession, c)) 
                  m.Add(_str_datAccession, o.ObjectIdent + _str_datAccession, o.ObjectIdent2 + _str_datAccession, o.ObjectIdent3 + _str_datAccession, "DateTime?", 
                    o.datAccession == null ? "" : o.datAccession.ToString(),                  
                  o.IsReadOnly(_str_datAccession), o.IsInvisible(_str_datAccession), o.IsRequired(_str_datAccession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_HumanName, _formname = _str_HumanName, _type = "String",
              _get_func = o => o.HumanName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.HumanName != newval) o.HumanName = newval; },
              _compare_func = (o, c, m, g) => {
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
              _compare_func = (o, c, m, g) => {
                if (o.AnimalName != c.AnimalName || o.IsRIRPropChanged(_str_AnimalName, c)) 
                  m.Add(_str_AnimalName, o.ObjectIdent + _str_AnimalName, o.ObjectIdent2 + _str_AnimalName, o.ObjectIdent3 + _str_AnimalName, "String", 
                    o.AnimalName == null ? "" : o.AnimalName.ToString(),                  
                  o.IsReadOnly(_str_AnimalName), o.IsInvisible(_str_AnimalName), o.IsRequired(_str_AnimalName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strAnimalCode, _formname = _str_strAnimalCode, _type = "String",
              _get_func = o => o.strAnimalCode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strAnimalCode != newval) o.strAnimalCode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strAnimalCode != c.strAnimalCode || o.IsRIRPropChanged(_str_strAnimalCode, c)) 
                  m.Add(_str_strAnimalCode, o.ObjectIdent + _str_strAnimalCode, o.ObjectIdent2 + _str_strAnimalCode, o.ObjectIdent3 + _str_strAnimalCode, "String", 
                    o.strAnimalCode == null ? "" : o.strAnimalCode.ToString(),                  
                  o.IsReadOnly(_str_strAnimalCode), o.IsInvisible(_str_strAnimalCode), o.IsRequired(_str_strAnimalCode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strVectorCode, _formname = _str_strVectorCode, _type = "String",
              _get_func = o => o.strVectorCode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVectorCode != newval) o.strVectorCode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strVectorCode != c.strVectorCode || o.IsRIRPropChanged(_str_strVectorCode, c)) 
                  m.Add(_str_strVectorCode, o.ObjectIdent + _str_strVectorCode, o.ObjectIdent2 + _str_strVectorCode, o.ObjectIdent3 + _str_strVectorCode, "String", 
                    o.strVectorCode == null ? "" : o.strVectorCode.ToString(),                  
                  o.IsReadOnly(_str_strVectorCode), o.IsInvisible(_str_strVectorCode), o.IsRequired(_str_strVectorCode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPartyName, _formname = _str_strPartyName, _type = "String",
              _get_func = o => o.strPartyName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPartyName != newval) o.strPartyName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strPartyName != c.strPartyName || o.IsRIRPropChanged(_str_strPartyName, c)) 
                  m.Add(_str_strPartyName, o.ObjectIdent + _str_strPartyName, o.ObjectIdent2 + _str_strPartyName, o.ObjectIdent3 + _str_strPartyName, "String", 
                    o.strPartyName == null ? "" : o.strPartyName.ToString(),                  
                  o.IsReadOnly(_str_strPartyName), o.IsInvisible(_str_strPartyName), o.IsRequired(_str_strPartyName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSite, _formname = _str_idfsSite, _type = "Int64",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsSite != newval) o.idfsSite = newval; },
              _compare_func = (o, c, m, g) => {
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
              _compare_func = (o, c, m, g) => {
                if (o.idfsCurrentSite != c.idfsCurrentSite || o.IsRIRPropChanged(_str_idfsCurrentSite, c)) 
                  m.Add(_str_idfsCurrentSite, o.ObjectIdent + _str_idfsCurrentSite, o.ObjectIdent2 + _str_idfsCurrentSite, o.ObjectIdent3 + _str_idfsCurrentSite, "Int64?", 
                    o.idfsCurrentSite == null ? "" : o.idfsCurrentSite.ToString(),                  
                  o.IsReadOnly(_str_idfsCurrentSite), o.IsInvisible(_str_idfsCurrentSite), o.IsRequired(_str_idfsCurrentSite)); 
                  }
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
            LabTestSample obj = (LabTestSample)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
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
        internal string m_ObjectName = "LabTestSample";

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
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as LabTestSample;
            ret.bIsClone = true;
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
            var ret = base.Clone() as LabTestSample;
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
        public LabTestSample CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabTestSample;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfMaterial; } }
        public string KeyName { get { return "idfMaterial"; } }
        public object KeyLookup { get { return idfMaterial; } }
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
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
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

        private bool IsRIRPropChanged(string fld, LabTestSample c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, LabTestSample c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public LabTestSample()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabTestSample_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabTestSample_PropertyChanged);
        }
        private void LabTestSample_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabTestSample).Changed(e.PropertyName);
            
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
            LabTestSample obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabTestSample obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
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
            
            return ReadOnly || new Func<LabTestSample, bool>(c => true)(this);
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
            }
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


        internal Dictionary<string, Func<LabTestSample, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<LabTestSample, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabTestSample, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabTestSample, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<LabTestSample, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabTestSample, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<LabTestSample, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~LabTestSample()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
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
        : DataAccessor<LabTestSample>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<LabTestSample>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<LabTestSample>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfMaterial"; } }
            #endregion
        
            public delegate void on_action(LabTestSample obj);
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
            public virtual LabTestSample SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
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

            
            public virtual LabTestSample SelectByKey(DbManagerProxy manager
                , Int64? idfTesting
                )
            {
                return _SelectByKey(manager
                    , idfTesting
                    , null, null
                    );
            }
            

            private LabTestSample _SelectByKey(DbManagerProxy manager
                , Int64? idfTesting
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfTesting
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual LabTestSample _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfTesting
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabTestSample obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LabTestSample obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabTestSample _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                LabTestSample obj = null;
                try
                {
                    obj = LabTestSample.CreateInstance();
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
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public LabTestSample CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public LabTestSample CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public LabTestSample CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(LabTestSample obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabTestSample obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, LabTestSample obj)
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
            
      
            protected ValidationModelException ChainsValidate(LabTestSample obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(LabTestSample obj, bool bRethrowException)
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
                return Validate(manager, obj as LabTestSample, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabTestSample obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(LabTestSample obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LabTestSample obj)
    {
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName))
      {
      
            obj
              .AddHiddenPersonalData("HumanName", c => true);
            
      }
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabTestSample) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabTestSample) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabTestSampleDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spLabTestEditable_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabTestSample, bool>> RequiredByField = new Dictionary<string, Func<LabTestSample, bool>>();
            public static Dictionary<string, Func<LabTestSample, bool>> RequiredByProperty = new Dictionary<string, Func<LabTestSample, bool>>();
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
                Sizes.Add(_str_strSampleName, 2000);
                Sizes.Add(_str_HumanName, 2000);
                Sizes.Add(_str_AnimalName, 2000);
                Sizes.Add(_str_strAnimalCode, 200);
                Sizes.Add(_str_strVectorCode, 4000);
                Sizes.Add(_str_strPartyName, 4000);
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars)),
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
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabTestSample>().Post(manager, (LabTestSample)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabTestSample>().Post(manager, (LabTestSample)c), c),
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
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((LabTestSample)c).MarkToDelete() && ObjectAccessor.PostInterface<LabTestSample>().Post(manager, (LabTestSample)c), c),
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
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class LabTestAmendmentHistory : 
        EditableObject<LabTestAmendmentHistory>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfTestAmendmentHistory), NonUpdatable, PrimaryKey]
        public abstract Int64 idfTestAmendmentHistory { get; set; }
                
        [LocalizedDisplayName(_str_datAmendmentDate)]
        [MapField(_str_datAmendmentDate)]
        public abstract DateTime datAmendmentDate { get; set; }
        protected DateTime datAmendmentDate_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datAmendmentDate).OriginalValue; } }
        protected DateTime datAmendmentDate_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datAmendmentDate).PreviousValue; } }
                
        [LocalizedDisplayName("strAmendByPerson")]
        [MapField(_str_strName)]
        public abstract String strName { get; set; }
        protected String strName_Original { get { return ((EditableValue<String>)((dynamic)this)._strName).OriginalValue; } }
        protected String strName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strName).PreviousValue; } }
                
        [LocalizedDisplayName("strOfficeAmendedBy")]
        [MapField(_str_strOffice)]
        public abstract String strOffice { get; set; }
        protected String strOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strOffice).OriginalValue; } }
        protected String strOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strOldTestResult)]
        [MapField(_str_strOldTestResult)]
        public abstract String strOldTestResult { get; set; }
        protected String strOldTestResult_Original { get { return ((EditableValue<String>)((dynamic)this)._strOldTestResult).OriginalValue; } }
        protected String strOldTestResult_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOldTestResult).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strNewTestResult)]
        [MapField(_str_strNewTestResult)]
        public abstract String strNewTestResult { get; set; }
        protected String strNewTestResult_Original { get { return ((EditableValue<String>)((dynamic)this)._strNewTestResult).OriginalValue; } }
        protected String strNewTestResult_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNewTestResult).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsOldTestResult)]
        [MapField(_str_idfsOldTestResult)]
        public abstract Int64? idfsOldTestResult { get; set; }
        protected Int64? idfsOldTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOldTestResult).OriginalValue; } }
        protected Int64? idfsOldTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOldTestResult).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsNewTestResult)]
        [MapField(_str_idfsNewTestResult)]
        public abstract Int64? idfsNewTestResult { get; set; }
        protected Int64? idfsNewTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsNewTestResult).OriginalValue; } }
        protected Int64? idfsNewTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsNewTestResult).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strOldNote)]
        [MapField(_str_strOldNote)]
        public abstract String strOldNote { get; set; }
        protected String strOldNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strOldNote).OriginalValue; } }
        protected String strOldNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOldNote).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strNewNote)]
        [MapField(_str_strNewNote)]
        public abstract String strNewNote { get; set; }
        protected String strNewNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNewNote).OriginalValue; } }
        protected String strNewNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNewNote).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strReason)]
        [MapField(_str_strReason)]
        public abstract String strReason { get; set; }
        protected String strReason_Original { get { return ((EditableValue<String>)((dynamic)this)._strReason).OriginalValue; } }
        protected String strReason_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReason).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfTesting)]
        [MapField(_str_idfTesting)]
        public abstract Int64 idfTesting { get; set; }
        protected Int64 idfTesting_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfTesting).OriginalValue; } }
        protected Int64 idfTesting_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfTesting).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfAmendByOffice)]
        [MapField(_str_idfAmendByOffice)]
        public abstract Int64? idfAmendByOffice { get; set; }
        protected Int64? idfAmendByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAmendByOffice).OriginalValue; } }
        protected Int64? idfAmendByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAmendByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfAmendByPerson)]
        [MapField(_str_idfAmendByPerson)]
        public abstract Int64? idfAmendByPerson { get; set; }
        protected Int64? idfAmendByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAmendByPerson).OriginalValue; } }
        protected Int64? idfAmendByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAmendByPerson).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<LabTestAmendmentHistory, object> _get_func;
            internal Action<LabTestAmendmentHistory, string> _set_func;
            internal Action<LabTestAmendmentHistory, LabTestAmendmentHistory, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfTestAmendmentHistory = "idfTestAmendmentHistory";
        internal const string _str_datAmendmentDate = "datAmendmentDate";
        internal const string _str_strName = "strName";
        internal const string _str_strOffice = "strOffice";
        internal const string _str_strOldTestResult = "strOldTestResult";
        internal const string _str_strNewTestResult = "strNewTestResult";
        internal const string _str_idfsOldTestResult = "idfsOldTestResult";
        internal const string _str_idfsNewTestResult = "idfsNewTestResult";
        internal const string _str_strOldNote = "strOldNote";
        internal const string _str_strNewNote = "strNewNote";
        internal const string _str_strReason = "strReason";
        internal const string _str_idfTesting = "idfTesting";
        internal const string _str_idfAmendByOffice = "idfAmendByOffice";
        internal const string _str_idfAmendByPerson = "idfAmendByPerson";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_OldTestResult = "OldTestResult";
        internal const string _str_NewTestResult = "NewTestResult";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfTestAmendmentHistory, _formname = _str_idfTestAmendmentHistory, _type = "Int64",
              _get_func = o => o.idfTestAmendmentHistory,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfTestAmendmentHistory != newval) o.idfTestAmendmentHistory = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfTestAmendmentHistory != c.idfTestAmendmentHistory || o.IsRIRPropChanged(_str_idfTestAmendmentHistory, c)) 
                  m.Add(_str_idfTestAmendmentHistory, o.ObjectIdent + _str_idfTestAmendmentHistory, o.ObjectIdent2 + _str_idfTestAmendmentHistory, o.ObjectIdent3 + _str_idfTestAmendmentHistory, "Int64", 
                    o.idfTestAmendmentHistory == null ? "" : o.idfTestAmendmentHistory.ToString(),                  
                  o.IsReadOnly(_str_idfTestAmendmentHistory), o.IsInvisible(_str_idfTestAmendmentHistory), o.IsRequired(_str_idfTestAmendmentHistory)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datAmendmentDate, _formname = _str_datAmendmentDate, _type = "DateTime",
              _get_func = o => o.datAmendmentDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTime(val); if (o.datAmendmentDate != newval) o.datAmendmentDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datAmendmentDate != c.datAmendmentDate || o.IsRIRPropChanged(_str_datAmendmentDate, c)) 
                  m.Add(_str_datAmendmentDate, o.ObjectIdent + _str_datAmendmentDate, o.ObjectIdent2 + _str_datAmendmentDate, o.ObjectIdent3 + _str_datAmendmentDate, "DateTime", 
                    o.datAmendmentDate == null ? "" : o.datAmendmentDate.ToString(),                  
                  o.IsReadOnly(_str_datAmendmentDate), o.IsInvisible(_str_datAmendmentDate), o.IsRequired(_str_datAmendmentDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strName, _formname = _str_strName, _type = "String",
              _get_func = o => o.strName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strName != newval) o.strName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strName != c.strName || o.IsRIRPropChanged(_str_strName, c)) 
                  m.Add(_str_strName, o.ObjectIdent + _str_strName, o.ObjectIdent2 + _str_strName, o.ObjectIdent3 + _str_strName, "String", 
                    o.strName == null ? "" : o.strName.ToString(),                  
                  o.IsReadOnly(_str_strName), o.IsInvisible(_str_strName), o.IsRequired(_str_strName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strOffice, _formname = _str_strOffice, _type = "String",
              _get_func = o => o.strOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOffice != newval) o.strOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strOffice != c.strOffice || o.IsRIRPropChanged(_str_strOffice, c)) 
                  m.Add(_str_strOffice, o.ObjectIdent + _str_strOffice, o.ObjectIdent2 + _str_strOffice, o.ObjectIdent3 + _str_strOffice, "String", 
                    o.strOffice == null ? "" : o.strOffice.ToString(),                  
                  o.IsReadOnly(_str_strOffice), o.IsInvisible(_str_strOffice), o.IsRequired(_str_strOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strOldTestResult, _formname = _str_strOldTestResult, _type = "String",
              _get_func = o => o.strOldTestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOldTestResult != newval) o.strOldTestResult = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strOldTestResult != c.strOldTestResult || o.IsRIRPropChanged(_str_strOldTestResult, c)) 
                  m.Add(_str_strOldTestResult, o.ObjectIdent + _str_strOldTestResult, o.ObjectIdent2 + _str_strOldTestResult, o.ObjectIdent3 + _str_strOldTestResult, "String", 
                    o.strOldTestResult == null ? "" : o.strOldTestResult.ToString(),                  
                  o.IsReadOnly(_str_strOldTestResult), o.IsInvisible(_str_strOldTestResult), o.IsRequired(_str_strOldTestResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strNewTestResult, _formname = _str_strNewTestResult, _type = "String",
              _get_func = o => o.strNewTestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strNewTestResult != newval) o.strNewTestResult = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strNewTestResult != c.strNewTestResult || o.IsRIRPropChanged(_str_strNewTestResult, c)) 
                  m.Add(_str_strNewTestResult, o.ObjectIdent + _str_strNewTestResult, o.ObjectIdent2 + _str_strNewTestResult, o.ObjectIdent3 + _str_strNewTestResult, "String", 
                    o.strNewTestResult == null ? "" : o.strNewTestResult.ToString(),                  
                  o.IsReadOnly(_str_strNewTestResult), o.IsInvisible(_str_strNewTestResult), o.IsRequired(_str_strNewTestResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsOldTestResult, _formname = _str_idfsOldTestResult, _type = "Int64?",
              _get_func = o => o.idfsOldTestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsOldTestResult != newval) 
                  o.OldTestResult = o.OldTestResultLookup.FirstOrDefault(c => c.idfsReference == newval);
                if (o.idfsOldTestResult != newval) o.idfsOldTestResult = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsOldTestResult != c.idfsOldTestResult || o.IsRIRPropChanged(_str_idfsOldTestResult, c)) 
                  m.Add(_str_idfsOldTestResult, o.ObjectIdent + _str_idfsOldTestResult, o.ObjectIdent2 + _str_idfsOldTestResult, o.ObjectIdent3 + _str_idfsOldTestResult, "Int64?", 
                    o.idfsOldTestResult == null ? "" : o.idfsOldTestResult.ToString(),                  
                  o.IsReadOnly(_str_idfsOldTestResult), o.IsInvisible(_str_idfsOldTestResult), o.IsRequired(_str_idfsOldTestResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsNewTestResult, _formname = _str_idfsNewTestResult, _type = "Int64?",
              _get_func = o => o.idfsNewTestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsNewTestResult != newval) 
                  o.NewTestResult = o.NewTestResultLookup.FirstOrDefault(c => c.idfsReference == newval);
                if (o.idfsNewTestResult != newval) o.idfsNewTestResult = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsNewTestResult != c.idfsNewTestResult || o.IsRIRPropChanged(_str_idfsNewTestResult, c)) 
                  m.Add(_str_idfsNewTestResult, o.ObjectIdent + _str_idfsNewTestResult, o.ObjectIdent2 + _str_idfsNewTestResult, o.ObjectIdent3 + _str_idfsNewTestResult, "Int64?", 
                    o.idfsNewTestResult == null ? "" : o.idfsNewTestResult.ToString(),                  
                  o.IsReadOnly(_str_idfsNewTestResult), o.IsInvisible(_str_idfsNewTestResult), o.IsRequired(_str_idfsNewTestResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strOldNote, _formname = _str_strOldNote, _type = "String",
              _get_func = o => o.strOldNote,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOldNote != newval) o.strOldNote = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strOldNote != c.strOldNote || o.IsRIRPropChanged(_str_strOldNote, c)) 
                  m.Add(_str_strOldNote, o.ObjectIdent + _str_strOldNote, o.ObjectIdent2 + _str_strOldNote, o.ObjectIdent3 + _str_strOldNote, "String", 
                    o.strOldNote == null ? "" : o.strOldNote.ToString(),                  
                  o.IsReadOnly(_str_strOldNote), o.IsInvisible(_str_strOldNote), o.IsRequired(_str_strOldNote)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strNewNote, _formname = _str_strNewNote, _type = "String",
              _get_func = o => o.strNewNote,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strNewNote != newval) o.strNewNote = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strNewNote != c.strNewNote || o.IsRIRPropChanged(_str_strNewNote, c)) 
                  m.Add(_str_strNewNote, o.ObjectIdent + _str_strNewNote, o.ObjectIdent2 + _str_strNewNote, o.ObjectIdent3 + _str_strNewNote, "String", 
                    o.strNewNote == null ? "" : o.strNewNote.ToString(),                  
                  o.IsReadOnly(_str_strNewNote), o.IsInvisible(_str_strNewNote), o.IsRequired(_str_strNewNote)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strReason, _formname = _str_strReason, _type = "String",
              _get_func = o => o.strReason,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strReason != newval) o.strReason = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strReason != c.strReason || o.IsRIRPropChanged(_str_strReason, c)) 
                  m.Add(_str_strReason, o.ObjectIdent + _str_strReason, o.ObjectIdent2 + _str_strReason, o.ObjectIdent3 + _str_strReason, "String", 
                    o.strReason == null ? "" : o.strReason.ToString(),                  
                  o.IsReadOnly(_str_strReason), o.IsInvisible(_str_strReason), o.IsRequired(_str_strReason)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfTesting, _formname = _str_idfTesting, _type = "Int64",
              _get_func = o => o.idfTesting,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfTesting != newval) o.idfTesting = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfTesting != c.idfTesting || o.IsRIRPropChanged(_str_idfTesting, c)) 
                  m.Add(_str_idfTesting, o.ObjectIdent + _str_idfTesting, o.ObjectIdent2 + _str_idfTesting, o.ObjectIdent3 + _str_idfTesting, "Int64", 
                    o.idfTesting == null ? "" : o.idfTesting.ToString(),                  
                  o.IsReadOnly(_str_idfTesting), o.IsInvisible(_str_idfTesting), o.IsRequired(_str_idfTesting)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfAmendByOffice, _formname = _str_idfAmendByOffice, _type = "Int64?",
              _get_func = o => o.idfAmendByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfAmendByOffice != newval) o.idfAmendByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfAmendByOffice != c.idfAmendByOffice || o.IsRIRPropChanged(_str_idfAmendByOffice, c)) 
                  m.Add(_str_idfAmendByOffice, o.ObjectIdent + _str_idfAmendByOffice, o.ObjectIdent2 + _str_idfAmendByOffice, o.ObjectIdent3 + _str_idfAmendByOffice, "Int64?", 
                    o.idfAmendByOffice == null ? "" : o.idfAmendByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfAmendByOffice), o.IsInvisible(_str_idfAmendByOffice), o.IsRequired(_str_idfAmendByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfAmendByPerson, _formname = _str_idfAmendByPerson, _type = "Int64?",
              _get_func = o => o.idfAmendByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfAmendByPerson != newval) o.idfAmendByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfAmendByPerson != c.idfAmendByPerson || o.IsRIRPropChanged(_str_idfAmendByPerson, c)) 
                  m.Add(_str_idfAmendByPerson, o.ObjectIdent + _str_idfAmendByPerson, o.ObjectIdent2 + _str_idfAmendByPerson, o.ObjectIdent3 + _str_idfAmendByPerson, "Int64?", 
                    o.idfAmendByPerson == null ? "" : o.idfAmendByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfAmendByPerson), o.IsInvisible(_str_idfAmendByPerson), o.IsRequired(_str_idfAmendByPerson)); 
                  }
              }, 
        
            new field_info {
              _name = _str_CaseObjectIdent, _formname = _str_CaseObjectIdent, _type = "string",
              _get_func = o => o.CaseObjectIdent,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.CaseObjectIdent != c.CaseObjectIdent || o.IsRIRPropChanged(_str_CaseObjectIdent, c)) {
                  m.Add(_str_CaseObjectIdent, o.ObjectIdent + _str_CaseObjectIdent, o.ObjectIdent2 + _str_CaseObjectIdent, o.ObjectIdent3 + _str_CaseObjectIdent, "string", o.CaseObjectIdent == null ? "" : o.CaseObjectIdent.ToString(), o.IsReadOnly(_str_CaseObjectIdent), o.IsInvisible(_str_CaseObjectIdent), o.IsRequired(_str_CaseObjectIdent));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_OldTestResult, _formname = _str_OldTestResult, _type = "Lookup",
              _get_func = o => { if (o.OldTestResult == null) return null; return o.OldTestResult.idfsReference; },
              _set_func = (o, val) => { o.OldTestResult = o.OldTestResultLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_OldTestResult, c);
                if (o.idfsOldTestResult != c.idfsOldTestResult || o.IsRIRPropChanged(_str_OldTestResult, c) || bChangeLookupContent) {
                  m.Add(_str_OldTestResult, o.ObjectIdent + _str_OldTestResult, o.ObjectIdent2 + _str_OldTestResult, o.ObjectIdent3 + _str_OldTestResult, "Lookup", o.idfsOldTestResult == null ? "" : o.idfsOldTestResult.ToString(), o.IsReadOnly(_str_OldTestResult), o.IsInvisible(_str_OldTestResult), o.IsRequired(_str_OldTestResult),
                  bChangeLookupContent ? o.OldTestResultLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_OldTestResult + "Lookup", _formname = _str_OldTestResult + "Lookup", _type = "LookupContent",
              _get_func = o => o.OldTestResultLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_NewTestResult, _formname = _str_NewTestResult, _type = "Lookup",
              _get_func = o => { if (o.NewTestResult == null) return null; return o.NewTestResult.idfsReference; },
              _set_func = (o, val) => { o.NewTestResult = o.NewTestResultLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_NewTestResult, c);
                if (o.idfsNewTestResult != c.idfsNewTestResult || o.IsRIRPropChanged(_str_NewTestResult, c) || bChangeLookupContent) {
                  m.Add(_str_NewTestResult, o.ObjectIdent + _str_NewTestResult, o.ObjectIdent2 + _str_NewTestResult, o.ObjectIdent3 + _str_NewTestResult, "Lookup", o.idfsNewTestResult == null ? "" : o.idfsNewTestResult.ToString(), o.IsReadOnly(_str_NewTestResult), o.IsInvisible(_str_NewTestResult), o.IsRequired(_str_NewTestResult),
                  bChangeLookupContent ? o.NewTestResultLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_NewTestResult + "Lookup", _formname = _str_NewTestResult + "Lookup", _type = "LookupContent",
              _get_func = o => o.NewTestResultLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
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
            LabTestAmendmentHistory obj = (LabTestAmendmentHistory)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_OldTestResult)]
        [Relation(typeof(TestResultLookup), eidss.model.Schema.TestResultLookup._str_idfsReference, _str_idfsOldTestResult)]
        public TestResultLookup OldTestResult
        {
            get { return _OldTestResult == null ? null : ((long)_OldTestResult.Key == 0 ? null : _OldTestResult); }
            set 
            { 
                var oldVal = _OldTestResult;
                _OldTestResult = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_OldTestResult != oldVal)
                {
                    if (idfsOldTestResult != (_OldTestResult == null
                            ? new Int64?()
                            : (Int64?)_OldTestResult.idfsReference))
                        idfsOldTestResult = _OldTestResult == null 
                            ? new Int64?()
                            : (Int64?)_OldTestResult.idfsReference; 
                    OnPropertyChanged(_str_OldTestResult); 
                }
            }
        }
        private TestResultLookup _OldTestResult;

        
        public List<TestResultLookup> OldTestResultLookup
        {
            get { return _OldTestResultLookup; }
        }
        private List<TestResultLookup> _OldTestResultLookup = new List<TestResultLookup>();
            
        [LocalizedDisplayName(_str_NewTestResult)]
        [Relation(typeof(TestResultLookup), eidss.model.Schema.TestResultLookup._str_idfsReference, _str_idfsNewTestResult)]
        public TestResultLookup NewTestResult
        {
            get { return _NewTestResult == null ? null : ((long)_NewTestResult.Key == 0 ? null : _NewTestResult); }
            set 
            { 
                var oldVal = _NewTestResult;
                _NewTestResult = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_NewTestResult != oldVal)
                {
                    if (idfsNewTestResult != (_NewTestResult == null
                            ? new Int64?()
                            : (Int64?)_NewTestResult.idfsReference))
                        idfsNewTestResult = _NewTestResult == null 
                            ? new Int64?()
                            : (Int64?)_NewTestResult.idfsReference; 
                    OnPropertyChanged(_str_NewTestResult); 
                }
            }
        }
        private TestResultLookup _NewTestResult;

        
        public List<TestResultLookup> NewTestResultLookup
        {
            get { return _NewTestResultLookup; }
        }
        private List<TestResultLookup> _NewTestResultLookup = new List<TestResultLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_OldTestResult:
                    return new BvSelectList(OldTestResultLookup, eidss.model.Schema.TestResultLookup._str_idfsReference, null, OldTestResult, _str_idfsOldTestResult);
            
                case _str_NewTestResult:
                    return new BvSelectList(NewTestResultLookup, eidss.model.Schema.TestResultLookup._str_idfsReference, null, NewTestResult, _str_idfsNewTestResult);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<LabTestAmendmentHistory, string>(c => "LabTest_" + c.idfTesting + "_")(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LabTestAmendmentHistory";

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
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as LabTestAmendmentHistory;
            ret.bIsClone = true;
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
            var ret = base.Clone() as LabTestAmendmentHistory;
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
        public LabTestAmendmentHistory CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabTestAmendmentHistory;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfTestAmendmentHistory; } }
        public string KeyName { get { return "idfTestAmendmentHistory"; } }
        public object KeyLookup { get { return idfTestAmendmentHistory; } }
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
        
            var _prev_idfsOldTestResult_OldTestResult = idfsOldTestResult;
            var _prev_idfsNewTestResult_NewTestResult = idfsNewTestResult;
            base.RejectChanges();
        
            if (_prev_idfsOldTestResult_OldTestResult != idfsOldTestResult)
            {
                _OldTestResult = _OldTestResultLookup.FirstOrDefault(c => c.idfsReference == idfsOldTestResult);
            }
            if (_prev_idfsNewTestResult_NewTestResult != idfsNewTestResult)
            {
                _NewTestResult = _NewTestResultLookup.FirstOrDefault(c => c.idfsReference == idfsNewTestResult);
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
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
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

        private bool IsRIRPropChanged(string fld, LabTestAmendmentHistory c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, LabTestAmendmentHistory c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public LabTestAmendmentHistory()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabTestAmendmentHistory_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabTestAmendmentHistory_PropertyChanged);
        }
        private void LabTestAmendmentHistory_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabTestAmendmentHistory).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfTesting)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
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
            LabTestAmendmentHistory obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabTestAmendmentHistory obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
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

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
            }
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


        internal Dictionary<string, Func<LabTestAmendmentHistory, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<LabTestAmendmentHistory, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabTestAmendmentHistory, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabTestAmendmentHistory, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<LabTestAmendmentHistory, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabTestAmendmentHistory, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<LabTestAmendmentHistory, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~LabTestAmendmentHistory()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("TestResultLookup", this);
                
                LookupManager.RemoveObject("TestResultLookup", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "TestResultLookup")
                _getAccessor().LoadLookup_OldTestResult(manager, this);
            
            if (lookup_object == "TestResultLookup")
                _getAccessor().LoadLookup_NewTestResult(manager, this);
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
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
        public class LabTestAmendmentHistoryGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfTestAmendmentHistory { get; set; }
        
            public DateTimeWrap datAmendmentDate { get; set; }
        
            public string strName { get; set; }
        
            public string strOffice { get; set; }
        
            public string strNewTestResult { get; set; }
        
            public string strReason { get; set; }
        
        }
        public partial class LabTestAmendmentHistoryGridModelList : List<LabTestAmendmentHistoryGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public LabTestAmendmentHistoryGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabTestAmendmentHistory>, errMes);
            }
            public LabTestAmendmentHistoryGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabTestAmendmentHistory>, errMes);
            }
            public LabTestAmendmentHistoryGridModelList(long key, IEnumerable<LabTestAmendmentHistory> items)
            {
                LoadGridModelList(key, items, null);
            }
            public LabTestAmendmentHistoryGridModelList(long key)
            {
                LoadGridModelList(key, new List<LabTestAmendmentHistory>(), null);
            }
            partial void filter(List<LabTestAmendmentHistory> items);
            private void LoadGridModelList(long key, IEnumerable<LabTestAmendmentHistory> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_datAmendmentDate,_str_strName,_str_strOffice,_str_strNewTestResult,_str_strReason};
                    
                Hiddens = new List<string> {_str_idfTestAmendmentHistory};
                Keys = new List<string> {_str_idfTestAmendmentHistory};
                Labels = new Dictionary<string, string> {{_str_datAmendmentDate, _str_datAmendmentDate},{_str_strName, "strAmendByPerson"},{_str_strOffice, "strOfficeAmendedBy"},{_str_strNewTestResult, _str_strNewTestResult},{_str_strReason, _str_strReason}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                LabTestAmendmentHistory.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<LabTestAmendmentHistory>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new LabTestAmendmentHistoryGridModel()
                {
                    ItemKey=c.idfTestAmendmentHistory,datAmendmentDate=c.datAmendmentDate,strName=c.strName,strOffice=c.strOffice,strNewTestResult=c.strNewTestResult,strReason=c.strReason
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
        : DataAccessor<LabTestAmendmentHistory>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<LabTestAmendmentHistory>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<LabTestAmendmentHistory>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfTestAmendmentHistory"; } }
            #endregion
        
            public delegate void on_action(LabTestAmendmentHistory obj);
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
            private TestResultLookup.Accessor OldTestResultAccessor { get { return eidss.model.Schema.TestResultLookup.Accessor.Instance(m_CS); } }
            private TestResultLookup.Accessor NewTestResultAccessor { get { return eidss.model.Schema.TestResultLookup.Accessor.Instance(m_CS); } }
            

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
            public virtual LabTestAmendmentHistory SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
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

            
            public virtual LabTestAmendmentHistory SelectByKey(DbManagerProxy manager
                , Int64? idfTesting
                )
            {
                return _SelectByKey(manager
                    , idfTesting
                    , null, null
                    );
            }
            

            private LabTestAmendmentHistory _SelectByKey(DbManagerProxy manager
                , Int64? idfTesting
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfTesting
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual LabTestAmendmentHistory _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfTesting
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabTestAmendmentHistory obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LabTestAmendmentHistory obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabTestAmendmentHistory _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                LabTestAmendmentHistory obj = null;
                try
                {
                    obj = LabTestAmendmentHistory.CreateInstance();
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
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public LabTestAmendmentHistory CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public LabTestAmendmentHistory CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public LabTestAmendmentHistory CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public LabTestAmendmentHistory CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfTesting", typeof(long));
                if (pars[1] != null && !(pars[1] is long?)) 
                    throw new TypeMismatchException("idfsOldTestResult", typeof(long?));
                if (pars[2] != null && !(pars[2] is string)) 
                    throw new TypeMismatchException("strOldNote", typeof(string));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    , (long?)pars[1]
                    , (string)pars[2]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public LabTestAmendmentHistory Create(DbManagerProxy manager, IObject Parent
                , long idfTesting
                , long? idfsOldTestResult
                , string strOldNote
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfTestAmendmentHistory = (new GetNewIDExtender<LabTestAmendmentHistory>()).GetScalar(manager, obj);
                obj.datAmendmentDate = new Func<LabTestAmendmentHistory, DateTime>(c => DateTime.Now)(obj);
                obj.idfAmendByOffice = new Func<LabTestAmendmentHistory, long>(c => eidss.model.Core.EidssSiteContext.Instance.OrganizationID)(obj);
                obj.idfAmendByPerson = new Func<LabTestAmendmentHistory, long>(c => (long)ModelUserContext.Instance.CurrentUser.EmployeeID)(obj);
                obj.strOffice = new Func<LabTestAmendmentHistory, string>(c => eidss.model.Core.EidssSiteContext.Instance.OrganizationName)(obj);
                obj.strName = new Func<LabTestAmendmentHistory, string>(c => ModelUserContext.Instance.CurrentUser.FullName)(obj);
                obj.idfTesting = new Func<LabTestAmendmentHistory, long>(c => idfTesting)(obj);
                obj.strOldNote = new Func<LabTestAmendmentHistory, string>(c => strOldNote)(obj);
                }
                    , obj =>
                {
                obj.OldTestResult = new Func<LabTestAmendmentHistory, TestResultLookup>(c => c.OldTestResultLookup.Where(l => l.idfsReference == idfsOldTestResult).SingleOrDefault())(obj);
                obj.strOldTestResult = new Func<LabTestAmendmentHistory, string>(c => c.OldTestResult == null ? "" : c.OldTestResult.name)(obj);
                }
                );
            }
            
            private void _SetupChildHandlers(LabTestAmendmentHistory obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabTestAmendmentHistory obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_NewTestResult)
                        {
                    
                obj.strNewTestResult = new Func<LabTestAmendmentHistory, string>(c => c.NewTestResult == null ? "" : c.NewTestResult.name)(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_OldTestResult(DbManagerProxy manager, LabTestAmendmentHistory obj)
            {
                
                obj.OldTestResultLookup.Clear();
                
                obj.OldTestResultLookup.Add(OldTestResultAccessor.CreateNewT(manager, null));
                
                obj.OldTestResultLookup.AddRange(OldTestResultAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => c.idfsTestName == (obj.Parent as LabTest).idfsTestName)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsOldTestResult))
                    
                    .ToList());
                
                if (obj.idfsOldTestResult != null && obj.idfsOldTestResult != 0)
                {
                    obj.OldTestResult = obj.OldTestResultLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsOldTestResult);
                    
                }
              
                LookupManager.AddObject("TestResultLookup", obj, OldTestResultAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_NewTestResult(DbManagerProxy manager, LabTestAmendmentHistory obj)
            {
                
                obj.NewTestResultLookup.Clear();
                
                obj.NewTestResultLookup.Add(NewTestResultAccessor.CreateNewT(manager, null));
                
                obj.NewTestResultLookup.AddRange(NewTestResultAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => c.idfsTestName == (obj.Parent as LabTest).idfsTestName)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsNewTestResult))
                    
                    .ToList());
                
                if (obj.idfsNewTestResult != null && obj.idfsNewTestResult != 0)
                {
                    obj.NewTestResult = obj.NewTestResultLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsNewTestResult);
                    
                }
              
                LookupManager.AddObject("TestResultLookup", obj, NewTestResultAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, LabTestAmendmentHistory obj)
            {
                
                LoadLookup_OldTestResult(manager, obj);
                
                LoadLookup_NewTestResult(manager, obj);
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spLabTestAmendmentHistory_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] LabTestAmendmentHistory obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] LabTestAmendmentHistory obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bSuccess = false;
                int iDeadlockAttemptsCount = BaseSettings.DeadlockAttemptsCount;
                for (int iAttemptNumber = 0; iAttemptNumber < iDeadlockAttemptsCount; iAttemptNumber++)
                {
                    bool bTransactionStarted = false;
                    try
                    {
                        LabTestAmendmentHistory bo = obj as LabTestAmendmentHistory;
                        
                        long mainObject = bo.idfTestAmendmentHistory;
                        
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
                            
                            if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                            {
                                
                            }
                            else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                            {
                                
                            }
                            else if (!bo.IsMarkedToDelete) // update
                            {
                                
                            }
                            
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as LabTestAmendmentHistory, bChildObject);
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
                        
                        break;
                    }
                    catch(Exception e)
                    {
                        if (bTransactionStarted)
                        {
                            manager.RollbackTransaction();
                            
                            if (DbModelException.IsDeadlockException(e))
                            {
                                System.Threading.Thread.Sleep(BaseSettings.DeadlockDelay);
                                continue;
                            }
                        }
                    
                        if (e is DataException)
                        {
                            throw DbModelException.Create(obj, e as DataException);
                        }
                        if (e is System.Data.SqlClient.SqlException)
                        {
                            throw DbModelException.Create(obj, e as System.Data.SqlClient.SqlException);
                        }
                        else 
                            throw;
                    }
                }
                return bSuccess;
            }
            private bool _PostNonTransaction(DbManagerProxy manager, LabTestAmendmentHistory obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(LabTestAmendmentHistory obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, LabTestAmendmentHistory obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(LabTestAmendmentHistory obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(LabTestAmendmentHistory obj, bool bRethrowException)
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
                return Validate(manager, obj as LabTestAmendmentHistory, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabTestAmendmentHistory obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "strReason", "strReason","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.strReason);
            
                (new RequiredValidator( "idfsNewTestResult", "NewTestResult","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsNewTestResult);
            
                (new PredicateValidator("errReasonForChangeIsTooShort", "", "", "",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, c => !c.IsNew || c.strReason.Length >= 6
                    );
            
                (new PredicateValidator("New_test_result_as_old_one", "", "", "",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, c => !c.IsNew || c.idfsOldTestResult != c.idfsNewTestResult
                    );
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                    }
                }
                catch(ValidationModelException ex)
                {
                    if (bRethrowException)
                        throw;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                
                return true;
            }
           
    
            private void _SetupRequired(LabTestAmendmentHistory obj)
            {
            
                obj
                    .AddRequired("strReason", c => true);
                    
                obj
                    .AddRequired("NewTestResult", c => true);
                    
                  obj
                    .AddRequired("NewTestResult", c => true);
                
            }
    
    private void _SetupPersonalDataRestrictions(LabTestAmendmentHistory obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabTestAmendmentHistory) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabTestAmendmentHistory) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabTestAmendmentHistoryDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spLabTestEditable_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spLabTestAmendmentHistory_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabTestAmendmentHistory, bool>> RequiredByField = new Dictionary<string, Func<LabTestAmendmentHistory, bool>>();
            public static Dictionary<string, Func<LabTestAmendmentHistory, bool>> RequiredByProperty = new Dictionary<string, Func<LabTestAmendmentHistory, bool>>();
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
                
                Sizes.Add(_str_strName, 400);
                Sizes.Add(_str_strOffice, 2000);
                Sizes.Add(_str_strOldTestResult, 2000);
                Sizes.Add(_str_strNewTestResult, 2000);
                Sizes.Add(_str_strOldNote, 500);
                Sizes.Add(_str_strNewNote, 500);
                Sizes.Add(_str_strReason, 500);
                if (!RequiredByField.ContainsKey("strReason")) RequiredByField.Add("strReason", c => true);
                if (!RequiredByProperty.ContainsKey("strReason")) RequiredByProperty.Add("strReason", c => true);
                
                if (!RequiredByField.ContainsKey("idfsNewTestResult")) RequiredByField.Add("idfsNewTestResult", c => true);
                if (!RequiredByProperty.ContainsKey("NewTestResult")) RequiredByProperty.Add("NewTestResult", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfTestAmendmentHistory,
                    _str_idfTestAmendmentHistory, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datAmendmentDate,
                    _str_datAmendmentDate, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strName,
                    "strAmendByPerson", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strOffice,
                    "strOfficeAmendedBy", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNewTestResult,
                    _str_strNewTestResult, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strReason,
                    _str_strReason, null, false, true, true, true, true, null
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
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars)),
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
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabTestAmendmentHistory>().Post(manager, (LabTestAmendmentHistory)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabTestAmendmentHistory>().Post(manager, (LabTestAmendmentHistory)c), c),
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
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((LabTestAmendmentHistory)c).MarkToDelete() && ObjectAccessor.PostInterface<LabTestAmendmentHistory>().Post(manager, (LabTestAmendmentHistory)c), c),
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
                    
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
}
	