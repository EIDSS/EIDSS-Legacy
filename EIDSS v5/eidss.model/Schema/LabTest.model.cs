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
        #if MONO
        protected Int64 idfsTestStatus_Original { get { return idfsTestStatus; } }
        protected Int64 idfsTestStatus_Previous { get { return idfsTestStatus; } }
        #else
        protected Int64 idfsTestStatus_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsTestStatus).OriginalValue; } }
        protected Int64 idfsTestStatus_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsTestStatus).PreviousValue; } }
        #endif
                
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
                
        [LocalizedDisplayName("TestDiagnosis2")]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64 idfsDiagnosis { get; set; }
        #if MONO
        protected Int64 idfsDiagnosis_Original { get { return idfsDiagnosis; } }
        protected Int64 idfsDiagnosis_Previous { get { return idfsDiagnosis; } }
        #else
        protected Int64 idfsDiagnosis_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64 idfsDiagnosis_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
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
                
        [LocalizedDisplayName("strComments")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        #if MONO
        protected String strNote_Original { get { return strNote; } }
        protected String strNote_Previous { get { return strNote; } }
        #else
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_datStartedDate)]
        [MapField(_str_datStartedDate)]
        public abstract DateTime? datStartedDate { get; set; }
        #if MONO
        protected DateTime? datStartedDate_Original { get { return datStartedDate; } }
        protected DateTime? datStartedDate_Previous { get { return datStartedDate; } }
        #else
        protected DateTime? datStartedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartedDate).OriginalValue; } }
        protected DateTime? datStartedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartedDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfPerformedByOffice)]
        [MapField(_str_idfPerformedByOffice)]
        public abstract Int64? idfPerformedByOffice { get; set; }
        #if MONO
        protected Int64? idfPerformedByOffice_Original { get { return idfPerformedByOffice; } }
        protected Int64? idfPerformedByOffice_Previous { get { return idfPerformedByOffice; } }
        #else
        protected Int64? idfPerformedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerformedByOffice).OriginalValue; } }
        protected Int64? idfPerformedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerformedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datReceivedDate)]
        [MapField(_str_datReceivedDate)]
        public abstract DateTime? datReceivedDate { get; set; }
        #if MONO
        protected DateTime? datReceivedDate_Original { get { return datReceivedDate; } }
        protected DateTime? datReceivedDate_Previous { get { return datReceivedDate; } }
        #else
        protected DateTime? datReceivedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReceivedDate).OriginalValue; } }
        protected DateTime? datReceivedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReceivedDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strContactPerson)]
        [MapField(_str_strContactPerson)]
        public abstract String strContactPerson { get; set; }
        #if MONO
        protected String strContactPerson_Original { get { return strContactPerson; } }
        protected String strContactPerson_Previous { get { return strContactPerson; } }
        #else
        protected String strContactPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strContactPerson).OriginalValue; } }
        protected String strContactPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strContactPerson).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfTestedByOffice)]
        [MapField(_str_idfTestedByOffice)]
        public abstract Int64? idfTestedByOffice { get; set; }
        #if MONO
        protected Int64? idfTestedByOffice_Original { get { return idfTestedByOffice; } }
        protected Int64? idfTestedByOffice_Previous { get { return idfTestedByOffice; } }
        #else
        protected Int64? idfTestedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByOffice).OriginalValue; } }
        protected Int64? idfTestedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfTestedByPerson)]
        [MapField(_str_idfTestedByPerson)]
        public abstract Int64? idfTestedByPerson { get; set; }
        #if MONO
        protected Int64? idfTestedByPerson_Original { get { return idfTestedByPerson; } }
        protected Int64? idfTestedByPerson_Previous { get { return idfTestedByPerson; } }
        #else
        protected Int64? idfTestedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByPerson).OriginalValue; } }
        protected Int64? idfTestedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfResultEnteredByOffice)]
        [MapField(_str_idfResultEnteredByOffice)]
        public abstract Int64? idfResultEnteredByOffice { get; set; }
        #if MONO
        protected Int64? idfResultEnteredByOffice_Original { get { return idfResultEnteredByOffice; } }
        protected Int64? idfResultEnteredByOffice_Previous { get { return idfResultEnteredByOffice; } }
        #else
        protected Int64? idfResultEnteredByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfResultEnteredByOffice).OriginalValue; } }
        protected Int64? idfResultEnteredByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfResultEnteredByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfResultEnteredByPerson)]
        [MapField(_str_idfResultEnteredByPerson)]
        public abstract Int64? idfResultEnteredByPerson { get; set; }
        #if MONO
        protected Int64? idfResultEnteredByPerson_Original { get { return idfResultEnteredByPerson; } }
        protected Int64? idfResultEnteredByPerson_Previous { get { return idfResultEnteredByPerson; } }
        #else
        protected Int64? idfResultEnteredByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfResultEnteredByPerson).OriginalValue; } }
        protected Int64? idfResultEnteredByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfResultEnteredByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfValidatedByOffice)]
        [MapField(_str_idfValidatedByOffice)]
        public abstract Int64? idfValidatedByOffice { get; set; }
        #if MONO
        protected Int64? idfValidatedByOffice_Original { get { return idfValidatedByOffice; } }
        protected Int64? idfValidatedByOffice_Previous { get { return idfValidatedByOffice; } }
        #else
        protected Int64? idfValidatedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfValidatedByOffice).OriginalValue; } }
        protected Int64? idfValidatedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfValidatedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfValidatedByPerson)]
        [MapField(_str_idfValidatedByPerson)]
        public abstract Int64? idfValidatedByPerson { get; set; }
        #if MONO
        protected Int64? idfValidatedByPerson_Original { get { return idfValidatedByPerson; } }
        protected Int64? idfValidatedByPerson_Previous { get { return idfValidatedByPerson; } }
        #else
        protected Int64? idfValidatedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfValidatedByPerson).OriginalValue; } }
        protected Int64? idfValidatedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfValidatedByPerson).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_SessionID)]
        [MapField(_str_SessionID)]
        public abstract String SessionID { get; set; }
        #if MONO
        protected String SessionID_Original { get { return SessionID; } }
        protected String SessionID_Previous { get { return SessionID; } }
        #else
        protected String SessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._sessionID).OriginalValue; } }
        protected String SessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._sessionID).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strBarcode)]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        #if MONO
        protected String strBarcode_Original { get { return strBarcode; } }
        protected String strBarcode_Previous { get { return strBarcode; } }
        #else
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strLaboratory")]
        [MapField(_str_DepartmentName)]
        public abstract String DepartmentName { get; set; }
        #if MONO
        protected String DepartmentName_Original { get { return DepartmentName; } }
        protected String DepartmentName_Previous { get { return DepartmentName; } }
        #else
        protected String DepartmentName_Original { get { return ((EditableValue<String>)((dynamic)this)._departmentName).OriginalValue; } }
        protected String DepartmentName_Previous { get { return ((EditableValue<String>)((dynamic)this)._departmentName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_ResultEnteredByPerson)]
        [MapField(_str_ResultEnteredByPerson)]
        public abstract String ResultEnteredByPerson { get; set; }
        #if MONO
        protected String ResultEnteredByPerson_Original { get { return ResultEnteredByPerson; } }
        protected String ResultEnteredByPerson_Previous { get { return ResultEnteredByPerson; } }
        #else
        protected String ResultEnteredByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._resultEnteredByPerson).OriginalValue; } }
        protected String ResultEnteredByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._resultEnteredByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64? idfsFormTemplate { get; set; }
        #if MONO
        protected Int64? idfsFormTemplate_Original { get { return idfsFormTemplate; } }
        protected Int64? idfsFormTemplate_Previous { get { return idfsFormTemplate; } }
        #else
        protected Int64? idfsFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64? idfsFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnNonLaboratoryTest)]
        [MapField(_str_blnNonLaboratoryTest)]
        public abstract Boolean blnNonLaboratoryTest { get; set; }
        #if MONO
        protected Boolean blnNonLaboratoryTest_Original { get { return blnNonLaboratoryTest; } }
        protected Boolean blnNonLaboratoryTest_Previous { get { return blnNonLaboratoryTest; } }
        #else
        protected Boolean blnNonLaboratoryTest_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnNonLaboratoryTest).OriginalValue; } }
        protected Boolean blnNonLaboratoryTest_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnNonLaboratoryTest).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfExtBatchTest)]
        [MapField(_str_idfExtBatchTest)]
        public abstract Int64? idfExtBatchTest { get; set; }
        #if MONO
        protected Int64? idfExtBatchTest_Original { get { return idfExtBatchTest; } }
        protected Int64? idfExtBatchTest_Previous { get { return idfExtBatchTest; } }
        #else
        protected Int64? idfExtBatchTest_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfExtBatchTest).OriginalValue; } }
        protected Int64? idfExtBatchTest_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfExtBatchTest).PreviousValue; } }
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
            internal Func<LabTest, object> _get_func;
            internal Action<LabTest, string> _set_func;
            internal Action<LabTest, LabTest, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfTesting = "idfTesting";
        internal const string _str_idfsTestStatus = "idfsTestStatus";
        internal const string _str_idfsTestType = "idfsTestType";
        internal const string _str_idfsTestResult = "idfsTestResult";
        internal const string _str_idfsTestForDiseaseType = "idfsTestForDiseaseType";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_idfContainer = "idfContainer";
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
        internal const string _str_datCreationDate = "datCreationDate";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_DepartmentName = "DepartmentName";
        internal const string _str_ResultEnteredByPerson = "ResultEnteredByPerson";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_blnNonLaboratoryTest = "blnNonLaboratoryTest";
        internal const string _str_idfExtBatchTest = "idfExtBatchTest";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_idfsTestStatusOriginal = "idfsTestStatusOriginal";
        internal const string _str_strOriginalTestResult = "strOriginalTestResult";
        internal const string _str_TestStatus = "TestStatus";
        internal const string _str_TestTypeRef = "TestTypeRef";
        internal const string _str_TestResultRef = "TestResultRef";
        internal const string _str_TestForDiseaseType = "TestForDiseaseType";
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
              _name = _str_idfTesting, _type = "Int64",
              _get_func = o => o.idfTesting,
              _set_func = (o, val) => { o.idfTesting = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTesting != c.idfTesting || o.IsRIRPropChanged(_str_idfTesting, c)) 
                  m.Add(_str_idfTesting, o.ObjectIdent + _str_idfTesting, "Int64", o.idfTesting == null ? "" : o.idfTesting.ToString(), o.IsReadOnly(_str_idfTesting), o.IsInvisible(_str_idfTesting), o.IsRequired(_str_idfTesting)); }
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
              _name = _str_idfsTestType, _type = "Int64?",
              _get_func = o => o.idfsTestType,
              _set_func = (o, val) => { o.idfsTestType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestType != c.idfsTestType || o.IsRIRPropChanged(_str_idfsTestType, c)) 
                  m.Add(_str_idfsTestType, o.ObjectIdent + _str_idfsTestType, "Int64?", o.idfsTestType == null ? "" : o.idfsTestType.ToString(), o.IsReadOnly(_str_idfsTestType), o.IsInvisible(_str_idfsTestType), o.IsRequired(_str_idfsTestType)); }
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
              _name = _str_idfsTestForDiseaseType, _type = "Int64?",
              _get_func = o => o.idfsTestForDiseaseType,
              _set_func = (o, val) => { o.idfsTestForDiseaseType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestForDiseaseType != c.idfsTestForDiseaseType || o.IsRIRPropChanged(_str_idfsTestForDiseaseType, c)) 
                  m.Add(_str_idfsTestForDiseaseType, o.ObjectIdent + _str_idfsTestForDiseaseType, "Int64?", o.idfsTestForDiseaseType == null ? "" : o.idfsTestForDiseaseType.ToString(), o.IsReadOnly(_str_idfsTestForDiseaseType), o.IsInvisible(_str_idfsTestForDiseaseType), o.IsRequired(_str_idfsTestForDiseaseType)); }
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
              _name = _str_idfContainer, _type = "Int64?",
              _get_func = o => o.idfContainer,
              _set_func = (o, val) => { o.idfContainer = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfContainer != c.idfContainer || o.IsRIRPropChanged(_str_idfContainer, c)) 
                  m.Add(_str_idfContainer, o.ObjectIdent + _str_idfContainer, "Int64?", o.idfContainer == null ? "" : o.idfContainer.ToString(), o.IsReadOnly(_str_idfContainer), o.IsInvisible(_str_idfContainer), o.IsRequired(_str_idfContainer)); }
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
              _name = _str_strNote, _type = "String",
              _get_func = o => o.strNote,
              _set_func = (o, val) => { o.strNote = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNote != c.strNote || o.IsRIRPropChanged(_str_strNote, c)) 
                  m.Add(_str_strNote, o.ObjectIdent + _str_strNote, "String", o.strNote == null ? "" : o.strNote.ToString(), o.IsReadOnly(_str_strNote), o.IsInvisible(_str_strNote), o.IsRequired(_str_strNote)); }
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
              _name = _str_datStartedDate, _type = "DateTime?",
              _get_func = o => o.datStartedDate,
              _set_func = (o, val) => { o.datStartedDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datStartedDate != c.datStartedDate || o.IsRIRPropChanged(_str_datStartedDate, c)) 
                  m.Add(_str_datStartedDate, o.ObjectIdent + _str_datStartedDate, "DateTime?", o.datStartedDate == null ? "" : o.datStartedDate.ToString(), o.IsReadOnly(_str_datStartedDate), o.IsInvisible(_str_datStartedDate), o.IsRequired(_str_datStartedDate)); }
              }, 
        
            new field_info {
              _name = _str_idfPerformedByOffice, _type = "Int64?",
              _get_func = o => o.idfPerformedByOffice,
              _set_func = (o, val) => { o.idfPerformedByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfPerformedByOffice != c.idfPerformedByOffice || o.IsRIRPropChanged(_str_idfPerformedByOffice, c)) 
                  m.Add(_str_idfPerformedByOffice, o.ObjectIdent + _str_idfPerformedByOffice, "Int64?", o.idfPerformedByOffice == null ? "" : o.idfPerformedByOffice.ToString(), o.IsReadOnly(_str_idfPerformedByOffice), o.IsInvisible(_str_idfPerformedByOffice), o.IsRequired(_str_idfPerformedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_datReceivedDate, _type = "DateTime?",
              _get_func = o => o.datReceivedDate,
              _set_func = (o, val) => { o.datReceivedDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datReceivedDate != c.datReceivedDate || o.IsRIRPropChanged(_str_datReceivedDate, c)) 
                  m.Add(_str_datReceivedDate, o.ObjectIdent + _str_datReceivedDate, "DateTime?", o.datReceivedDate == null ? "" : o.datReceivedDate.ToString(), o.IsReadOnly(_str_datReceivedDate), o.IsInvisible(_str_datReceivedDate), o.IsRequired(_str_datReceivedDate)); }
              }, 
        
            new field_info {
              _name = _str_strContactPerson, _type = "String",
              _get_func = o => o.strContactPerson,
              _set_func = (o, val) => { o.strContactPerson = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strContactPerson != c.strContactPerson || o.IsRIRPropChanged(_str_strContactPerson, c)) 
                  m.Add(_str_strContactPerson, o.ObjectIdent + _str_strContactPerson, "String", o.strContactPerson == null ? "" : o.strContactPerson.ToString(), o.IsReadOnly(_str_strContactPerson), o.IsInvisible(_str_strContactPerson), o.IsRequired(_str_strContactPerson)); }
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
              _name = _str_idfTestedByOffice, _type = "Int64?",
              _get_func = o => o.idfTestedByOffice,
              _set_func = (o, val) => { o.idfTestedByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTestedByOffice != c.idfTestedByOffice || o.IsRIRPropChanged(_str_idfTestedByOffice, c)) 
                  m.Add(_str_idfTestedByOffice, o.ObjectIdent + _str_idfTestedByOffice, "Int64?", o.idfTestedByOffice == null ? "" : o.idfTestedByOffice.ToString(), o.IsReadOnly(_str_idfTestedByOffice), o.IsInvisible(_str_idfTestedByOffice), o.IsRequired(_str_idfTestedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfTestedByPerson, _type = "Int64?",
              _get_func = o => o.idfTestedByPerson,
              _set_func = (o, val) => { o.idfTestedByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTestedByPerson != c.idfTestedByPerson || o.IsRIRPropChanged(_str_idfTestedByPerson, c)) 
                  m.Add(_str_idfTestedByPerson, o.ObjectIdent + _str_idfTestedByPerson, "Int64?", o.idfTestedByPerson == null ? "" : o.idfTestedByPerson.ToString(), o.IsReadOnly(_str_idfTestedByPerson), o.IsInvisible(_str_idfTestedByPerson), o.IsRequired(_str_idfTestedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_idfResultEnteredByOffice, _type = "Int64?",
              _get_func = o => o.idfResultEnteredByOffice,
              _set_func = (o, val) => { o.idfResultEnteredByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfResultEnteredByOffice != c.idfResultEnteredByOffice || o.IsRIRPropChanged(_str_idfResultEnteredByOffice, c)) 
                  m.Add(_str_idfResultEnteredByOffice, o.ObjectIdent + _str_idfResultEnteredByOffice, "Int64?", o.idfResultEnteredByOffice == null ? "" : o.idfResultEnteredByOffice.ToString(), o.IsReadOnly(_str_idfResultEnteredByOffice), o.IsInvisible(_str_idfResultEnteredByOffice), o.IsRequired(_str_idfResultEnteredByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfResultEnteredByPerson, _type = "Int64?",
              _get_func = o => o.idfResultEnteredByPerson,
              _set_func = (o, val) => { o.idfResultEnteredByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfResultEnteredByPerson != c.idfResultEnteredByPerson || o.IsRIRPropChanged(_str_idfResultEnteredByPerson, c)) 
                  m.Add(_str_idfResultEnteredByPerson, o.ObjectIdent + _str_idfResultEnteredByPerson, "Int64?", o.idfResultEnteredByPerson == null ? "" : o.idfResultEnteredByPerson.ToString(), o.IsReadOnly(_str_idfResultEnteredByPerson), o.IsInvisible(_str_idfResultEnteredByPerson), o.IsRequired(_str_idfResultEnteredByPerson)); }
              }, 
        
            new field_info {
              _name = _str_idfValidatedByOffice, _type = "Int64?",
              _get_func = o => o.idfValidatedByOffice,
              _set_func = (o, val) => { o.idfValidatedByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfValidatedByOffice != c.idfValidatedByOffice || o.IsRIRPropChanged(_str_idfValidatedByOffice, c)) 
                  m.Add(_str_idfValidatedByOffice, o.ObjectIdent + _str_idfValidatedByOffice, "Int64?", o.idfValidatedByOffice == null ? "" : o.idfValidatedByOffice.ToString(), o.IsReadOnly(_str_idfValidatedByOffice), o.IsInvisible(_str_idfValidatedByOffice), o.IsRequired(_str_idfValidatedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfValidatedByPerson, _type = "Int64?",
              _get_func = o => o.idfValidatedByPerson,
              _set_func = (o, val) => { o.idfValidatedByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfValidatedByPerson != c.idfValidatedByPerson || o.IsRIRPropChanged(_str_idfValidatedByPerson, c)) 
                  m.Add(_str_idfValidatedByPerson, o.ObjectIdent + _str_idfValidatedByPerson, "Int64?", o.idfValidatedByPerson == null ? "" : o.idfValidatedByPerson.ToString(), o.IsReadOnly(_str_idfValidatedByPerson), o.IsInvisible(_str_idfValidatedByPerson), o.IsRequired(_str_idfValidatedByPerson)); }
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
              _name = _str_strCaseID, _type = "String",
              _get_func = o => o.strCaseID,
              _set_func = (o, val) => { o.strCaseID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCaseID != c.strCaseID || o.IsRIRPropChanged(_str_strCaseID, c)) 
                  m.Add(_str_strCaseID, o.ObjectIdent + _str_strCaseID, "String", o.strCaseID == null ? "" : o.strCaseID.ToString(), o.IsReadOnly(_str_strCaseID), o.IsInvisible(_str_strCaseID), o.IsRequired(_str_strCaseID)); }
              }, 
        
            new field_info {
              _name = _str_SessionID, _type = "String",
              _get_func = o => o.SessionID,
              _set_func = (o, val) => { o.SessionID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.SessionID != c.SessionID || o.IsRIRPropChanged(_str_SessionID, c)) 
                  m.Add(_str_SessionID, o.ObjectIdent + _str_SessionID, "String", o.SessionID == null ? "" : o.SessionID.ToString(), o.IsReadOnly(_str_SessionID), o.IsInvisible(_str_SessionID), o.IsRequired(_str_SessionID)); }
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
              _name = _str_idfVectorSurveillanceSession, _type = "Int64?",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { o.idfVectorSurveillanceSession = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, "Int64?", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); }
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
              _name = _str_DepartmentName, _type = "String",
              _get_func = o => o.DepartmentName,
              _set_func = (o, val) => { o.DepartmentName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.DepartmentName != c.DepartmentName || o.IsRIRPropChanged(_str_DepartmentName, c)) 
                  m.Add(_str_DepartmentName, o.ObjectIdent + _str_DepartmentName, "String", o.DepartmentName == null ? "" : o.DepartmentName.ToString(), o.IsReadOnly(_str_DepartmentName), o.IsInvisible(_str_DepartmentName), o.IsRequired(_str_DepartmentName)); }
              }, 
        
            new field_info {
              _name = _str_ResultEnteredByPerson, _type = "String",
              _get_func = o => o.ResultEnteredByPerson,
              _set_func = (o, val) => { o.ResultEnteredByPerson = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.ResultEnteredByPerson != c.ResultEnteredByPerson || o.IsRIRPropChanged(_str_ResultEnteredByPerson, c)) 
                  m.Add(_str_ResultEnteredByPerson, o.ObjectIdent + _str_ResultEnteredByPerson, "String", o.ResultEnteredByPerson == null ? "" : o.ResultEnteredByPerson.ToString(), o.IsReadOnly(_str_ResultEnteredByPerson), o.IsInvisible(_str_ResultEnteredByPerson), o.IsRequired(_str_ResultEnteredByPerson)); }
              }, 
        
            new field_info {
              _name = _str_idfsFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { o.idfsFormTemplate = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, "Int64?", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); }
              }, 
        
            new field_info {
              _name = _str_blnNonLaboratoryTest, _type = "Boolean",
              _get_func = o => o.blnNonLaboratoryTest,
              _set_func = (o, val) => { o.blnNonLaboratoryTest = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
                if (o.blnNonLaboratoryTest != c.blnNonLaboratoryTest || o.IsRIRPropChanged(_str_blnNonLaboratoryTest, c)) 
                  m.Add(_str_blnNonLaboratoryTest, o.ObjectIdent + _str_blnNonLaboratoryTest, "Boolean", o.blnNonLaboratoryTest == null ? "" : o.blnNonLaboratoryTest.ToString(), o.IsReadOnly(_str_blnNonLaboratoryTest), o.IsInvisible(_str_blnNonLaboratoryTest), o.IsRequired(_str_blnNonLaboratoryTest)); }
              }, 
        
            new field_info {
              _name = _str_idfExtBatchTest, _type = "Int64?",
              _get_func = o => o.idfExtBatchTest,
              _set_func = (o, val) => { o.idfExtBatchTest = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfExtBatchTest != c.idfExtBatchTest || o.IsRIRPropChanged(_str_idfExtBatchTest, c)) 
                  m.Add(_str_idfExtBatchTest, o.ObjectIdent + _str_idfExtBatchTest, "Int64?", o.idfExtBatchTest == null ? "" : o.idfExtBatchTest.ToString(), o.IsReadOnly(_str_idfExtBatchTest), o.IsInvisible(_str_idfExtBatchTest), o.IsRequired(_str_idfExtBatchTest)); }
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
              _name = _str_idfsTestStatusOriginal, _type = "long?",
              _get_func = o => o.idfsTestStatusOriginal,
              _set_func = (o, val) => { o.idfsTestStatusOriginal = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfsTestStatusOriginal != c.idfsTestStatusOriginal || o.IsRIRPropChanged(_str_idfsTestStatusOriginal, c)) 
                  m.Add(_str_idfsTestStatusOriginal, o.ObjectIdent + _str_idfsTestStatusOriginal, "long?", o.idfsTestStatusOriginal == null ? "" : o.idfsTestStatusOriginal.ToString(), o.IsReadOnly(_str_idfsTestStatusOriginal), o.IsInvisible(_str_idfsTestStatusOriginal), o.IsRequired(_str_idfsTestStatusOriginal));
                 }
              }, 
        
            new field_info {
              _name = _str_strOriginalTestResult, _type = "string",
              _get_func = o => o.strOriginalTestResult,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strOriginalTestResult != c.strOriginalTestResult || o.IsRIRPropChanged(_str_strOriginalTestResult, c)) 
                  m.Add(_str_strOriginalTestResult, o.ObjectIdent + _str_strOriginalTestResult, "string", o.strOriginalTestResult == null ? "" : o.strOriginalTestResult.ToString(), o.IsReadOnly(_str_strOriginalTestResult), o.IsInvisible(_str_strOriginalTestResult), o.IsRequired(_str_strOriginalTestResult));
                 }
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
              _name = _str_TestTypeRef, _type = "Lookup",
              _get_func = o => { if (o.TestTypeRef == null) return null; return o.TestTypeRef.idfsBaseReference; },
              _set_func = (o, val) => { o.TestTypeRef = o.TestTypeRefLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestType != c.idfsTestType || o.IsRIRPropChanged(_str_TestTypeRef, c)) 
                  m.Add(_str_TestTypeRef, o.ObjectIdent + _str_TestTypeRef, "Lookup", o.idfsTestType == null ? "" : o.idfsTestType.ToString(), o.IsReadOnly(_str_TestTypeRef), o.IsInvisible(_str_TestTypeRef), o.IsRequired(_str_TestTypeRef)); }
              }, 
        
            new field_info {
              _name = _str_TestResultRef, _type = "Lookup",
              _get_func = o => { if (o.TestResultRef == null) return null; return o.TestResultRef.idfsReference; },
              _set_func = (o, val) => { o.TestResultRef = o.TestResultRefLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestResult != c.idfsTestResult || o.IsRIRPropChanged(_str_TestResultRef, c)) 
                  m.Add(_str_TestResultRef, o.ObjectIdent + _str_TestResultRef, "Lookup", o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(), o.IsReadOnly(_str_TestResultRef), o.IsInvisible(_str_TestResultRef), o.IsRequired(_str_TestResultRef)); }
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
              _name = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnosis, c)) 
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis)); }
              }, 
        
            new field_info {
              _name = _str_ValidatedByPerson, _type = "Lookup",
              _get_func = o => { if (o.ValidatedByPerson == null) return null; return o.ValidatedByPerson.idfPerson; },
              _set_func = (o, val) => { o.ValidatedByPerson = o.ValidatedByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfValidatedByPerson != c.idfValidatedByPerson || o.IsRIRPropChanged(_str_ValidatedByPerson, c)) 
                  m.Add(_str_ValidatedByPerson, o.ObjectIdent + _str_ValidatedByPerson, "Lookup", o.idfValidatedByPerson == null ? "" : o.idfValidatedByPerson.ToString(), o.IsReadOnly(_str_ValidatedByPerson), o.IsInvisible(_str_ValidatedByPerson), o.IsRequired(_str_ValidatedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_TestedByPerson, _type = "Lookup",
              _get_func = o => { if (o.TestedByPerson == null) return null; return o.TestedByPerson.idfPerson; },
              _set_func = (o, val) => { o.TestedByPerson = o.TestedByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfTestedByPerson != c.idfTestedByPerson || o.IsRIRPropChanged(_str_TestedByPerson, c)) 
                  m.Add(_str_TestedByPerson, o.ObjectIdent + _str_TestedByPerson, "Lookup", o.idfTestedByPerson == null ? "" : o.idfTestedByPerson.ToString(), o.IsReadOnly(_str_TestedByPerson), o.IsInvisible(_str_TestedByPerson), o.IsRequired(_str_TestedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_AmendmentHistory, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.AmendmentHistory.Count != c.AmendmentHistory.Count || o.IsReadOnly(_str_AmendmentHistory) != c.IsReadOnly(_str_AmendmentHistory) || o.IsInvisible(_str_AmendmentHistory) != c.IsInvisible(_str_AmendmentHistory) || o.IsRequired(_str_AmendmentHistory) != c.IsRequired(_str_AmendmentHistory)) 
                  m.Add(_str_AmendmentHistory, o.ObjectIdent + _str_AmendmentHistory, "Child", o.idfTesting == null ? "" : o.idfTesting.ToString(), o.IsReadOnly(_str_AmendmentHistory), o.IsInvisible(_str_AmendmentHistory), o.IsRequired(_str_AmendmentHistory)); }
              }, 
        
            new field_info {
              _name = _str_Sample, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Sample != null) o.Sample._compare(c.Sample, m); }
              }, 
        
            new field_info {
              _name = _str_SampleInfo, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.SampleInfo != null) o.SampleInfo._compare(c.SampleInfo, m); }
              }, 
        
            new field_info {
              _name = _str_FFPresenter, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
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
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(LabSample), eidss.model.Schema.LabSample._str_idfContainer, _str_idfContainer)]
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
                idfContainer = _Sample == null 
                        ? new Int64?()
                        : _Sample.idfContainer;
                
            }
        }
        protected LabSample _Sample;
                    
        private bool _SampleLoaded = false;
                    
        [Relation(typeof(LabTestSample), eidss.model.Schema.LabTestSample._str_idfContainer, _str_idfContainer)]
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
                idfContainer = _SampleInfo == null 
                        ? new Int64?()
                        : _SampleInfo.idfContainer;
                
            }
        }
        protected LabTestSample _SampleInfo;
                    
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
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestType)]
        public BaseReference TestTypeRef
        {
            get { return _TestTypeRef == null ? null : ((long)_TestTypeRef.Key == 0 ? null : _TestTypeRef); }
            set 
            { 
                _TestTypeRef = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsTestType = _TestTypeRef == null 
                    ? new Int64?()
                    : _TestTypeRef.idfsBaseReference; 
                OnPropertyChanged(_str_TestTypeRef); 
            }
        }
        private BaseReference _TestTypeRef;

        
        public BaseReferenceList TestTypeRefLookup
        {
            get { return _TestTypeRefLookup; }
        }
        private BaseReferenceList _TestTypeRefLookup = new BaseReferenceList("rftTestType");
            
        [Relation(typeof(TestResultLookup), eidss.model.Schema.TestResultLookup._str_idfsReference, _str_idfsTestResult)]
        public TestResultLookup TestResultRef
        {
            get { return _TestResultRef == null ? null : ((long)_TestResultRef.Key == 0 ? null : _TestResultRef); }
            set 
            { 
                _TestResultRef = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsTestResult = _TestResultRef == null 
                    ? new Int64?()
                    : _TestResultRef.idfsReference; 
                OnPropertyChanged(_str_TestResultRef); 
            }
        }
        private TestResultLookup _TestResultRef;

        
        public List<TestResultLookup> TestResultRefLookup
        {
            get { return _TestResultRefLookup; }
        }
        private List<TestResultLookup> _TestResultRefLookup = new List<TestResultLookup>();
            
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
            
        [Relation(typeof(TestDiagnosisLookup), eidss.model.Schema.TestDiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public TestDiagnosisLookup Diagnosis
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
        private TestDiagnosisLookup _Diagnosis;

        
        public List<TestDiagnosisLookup> DiagnosisLookup
        {
            get { return _DiagnosisLookup; }
        }
        private List<TestDiagnosisLookup> _DiagnosisLookup = new List<TestDiagnosisLookup>();
            
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfValidatedByPerson)]
        public PersonLookup ValidatedByPerson
        {
            get { return _ValidatedByPerson == null ? null : ((long)_ValidatedByPerson.Key == 0 ? null : _ValidatedByPerson); }
            set 
            { 
                _ValidatedByPerson = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfValidatedByPerson = _ValidatedByPerson == null 
                    ? new Int64?()
                    : _ValidatedByPerson.idfPerson; 
                OnPropertyChanged(_str_ValidatedByPerson); 
            }
        }
        private PersonLookup _ValidatedByPerson;

        
        public List<PersonLookup> ValidatedByPersonLookup
        {
            get { return _ValidatedByPersonLookup; }
        }
        private List<PersonLookup> _ValidatedByPersonLookup = new List<PersonLookup>();
            
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfTestedByPerson)]
        public PersonLookup TestedByPerson
        {
            get { return _TestedByPerson == null ? null : ((long)_TestedByPerson.Key == 0 ? null : _TestedByPerson); }
            set 
            { 
                _TestedByPerson = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfTestedByPerson = _TestedByPerson == null 
                    ? new Int64?()
                    : _TestedByPerson.idfPerson; 
                OnPropertyChanged(_str_TestedByPerson); 
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
            
                case _str_TestTypeRef:
                    return new BvSelectList(TestTypeRefLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestTypeRef, _str_idfsTestType);
            
                case _str_TestResultRef:
                    return new BvSelectList(TestResultRefLookup, eidss.model.Schema.TestResultLookup._str_idfsReference, null, TestResultRef, _str_idfsTestResult);
            
                case _str_TestForDiseaseType:
                    return new BvSelectList(TestForDiseaseTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestForDiseaseType, _str_idfsTestForDiseaseType);
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.TestDiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_ValidatedByPerson:
                    return new BvSelectList(ValidatedByPersonLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, ValidatedByPerson, _str_idfValidatedByPerson);
            
                case _str_TestedByPerson:
                    return new BvSelectList(TestedByPersonLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, TestedByPerson, _str_idfTestedByPerson);
            
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
        public override object Clone()
        {
            var ret = base.Clone() as LabTest;
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
            var ret = base.Clone() as LabTest;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Sample != null)
              ret.Sample = _Sample.CloneWithSetup(manager) as LabSample;
                
            if (_SampleInfo != null)
              ret.SampleInfo = _SampleInfo.CloneWithSetup(manager) as LabTestSample;
                
            if (_FFPresenter != null)
              ret.FFPresenter = _FFPresenter.CloneWithSetup(manager) as FFPresenterModel;
                
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
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
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
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
            var _prev_idfsTestType_TestTypeRef = idfsTestType;
            var _prev_idfsTestResult_TestResultRef = idfsTestResult;
            var _prev_idfsTestForDiseaseType_TestForDiseaseType = idfsTestForDiseaseType;
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfValidatedByPerson_ValidatedByPerson = idfValidatedByPerson;
            var _prev_idfTestedByPerson_TestedByPerson = idfTestedByPerson;
            base.RejectChanges();
        
            if (_prev_idfsTestStatus_TestStatus != idfsTestStatus)
            {
                _TestStatus = _TestStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestStatus);
            }
            if (_prev_idfsTestType_TestTypeRef != idfsTestType)
            {
                _TestTypeRef = _TestTypeRefLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestType);
            }
            if (_prev_idfsTestResult_TestResultRef != idfsTestResult)
            {
                _TestResultRef = _TestResultRefLookup.FirstOrDefault(c => c.idfsReference == idfsTestResult);
            }
            if (_prev_idfsTestForDiseaseType_TestForDiseaseType != idfsTestForDiseaseType)
            {
                _TestForDiseaseType = _TestForDiseaseTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestForDiseaseType);
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
        
            if (Sample != null) Sample.RejectChanges();
                
            if (SampleInfo != null) SampleInfo.RejectChanges();
                AmendmentHistory.RejectChanges();
                
            if (FFPresenter != null) FFPresenter.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Sample != null) _Sample.AcceptChanges();
                
            if (_SampleInfo != null) _SampleInfo.AcceptChanges();
                AmendmentHistory.AcceptChanges();
                
            if (_FFPresenter != null) _FFPresenter.AcceptChanges();
                
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
        
            if (_Sample != null) _Sample.SetChange();
                
            if (_SampleInfo != null) _SampleInfo.SetChange();
                AmendmentHistory.ForEach(c => c.SetChange());
                
            if (_FFPresenter != null) _FFPresenter.SetChange();
                
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

      private bool IsRIRPropChanged(string fld, LabTest c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabTest()
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
                return ReadOnly || new Func<LabTest, bool>(c => c.idfsTestStatus == (long)BatchStatusEnum.Undefined || c.idfsTestStatus == (long)BatchStatusEnum.Amended || c.idfsTestStatusOriginal == (long)BatchStatusEnum.Completed)(this);
            
            return ReadOnly || new Func<LabTest, bool>(c => c.idfsTestStatusOriginal == (long)BatchStatusEnum.Completed || c.idfsTestStatusOriginal == (long)BatchStatusEnum.Amended)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                if (_Sample != null)
                    _Sample.ReadOnly = value;
                
                if (_SampleInfo != null)
                    _SampleInfo.ReadOnly = value;
                
                foreach(var o in _AmendmentHistory)
                    o.ReadOnly = value;
                
                if (_FFPresenter != null)
                    _FFPresenter.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<LabTest, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabTest, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabTest, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabTest, bool>> m_isHiddenPersonalData;
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
        ~LabTest()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftActivityStatus", this);
                
                LookupManager.RemoveObject("rftTestType", this);
                
                LookupManager.RemoveObject("TestResultLookup", this);
                
                LookupManager.RemoveObject("rftTestForDiseaseType", this);
                
                LookupManager.RemoveObject("TestDiagnosisLookup", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftActivityStatus")
                _getAccessor().LoadLookup_TestStatus(manager, this);
            
            if (lookup_object == "rftTestType")
                _getAccessor().LoadLookup_TestTypeRef(manager, this);
            
            if (lookup_object == "TestResultLookup")
                _getAccessor().LoadLookup_TestResultRef(manager, this);
            
            if (lookup_object == "rftTestForDiseaseType")
                _getAccessor().LoadLookup_TestForDiseaseType(manager, this);
            
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
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._name] != null) a._set_func(this, form[ObjectIdent + a._name]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._name)) a._set_func(this, form[ObjectIdent + a._name]);} );
      
            if (bParseRelations)
            {
        
            if (_Sample != null) _Sample.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_SampleInfo != null) _SampleInfo.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_AmendmentHistory != null) _AmendmentHistory.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_FFPresenter != null) _FFPresenter.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<LabTest>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(LabTest obj);
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
            private BaseReference.Accessor TestTypeRefAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private TestResultLookup.Accessor TestResultRefAccessor { get { return eidss.model.Schema.TestResultLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestForDiseaseTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
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
            
                MapResultSet[] sets = new MapResultSet[3];
                List<LabTest> objs = new List<LabTest>();
                sets[0] = new MapResultSet(typeof(LabTest), objs);
                
                List<LabTestSample> objs_LabTestSample = new List<LabTestSample>();
                sets[1] = new MapResultSet(typeof(LabTestSample), objs_LabTestSample);
                
                List<LabTestAmendmentHistory> objs_LabTestAmendmentHistory = new List<LabTestAmendmentHistory>();
                sets[2] = new MapResultSet(typeof(LabTestAmendmentHistory), objs_LabTestAmendmentHistory);
                
        
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

                    LabTest obj = objs[0];
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
                    throw DbModelException.Create(e);
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
                
                if (obj.Sample == null && obj.idfContainer != null && obj.idfContainer != 0)
                {
                    obj.Sample = SampleAccessor.SelectByKey(manager
                        
                        , obj.idfContainer.Value
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
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabTest obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj.idfsTestStatusOriginal = new Func<LabTest, long?>(c => c.idfsTestStatus)(obj);
                obj.idfValidatedByOffice = new Func<LabTest, long?>(c => c.idfValidatedByOffice ?? eidss.model.Core.EidssSiteContext.Instance.OrganizationID)(obj);
                // loading extenters - end
                
                _LoadFFPresenter(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                            if (obj.idfsFormTemplate.HasValue) obj.FFPresenter.SetProperties(obj.idfsFormTemplate.Value);
                        
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

    

            private LabTest _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabTest obj = LabTest.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfTesting = (new GetNewIDExtender<LabTest>()).GetScalar(manager, obj);
                obj.idfObservation = (new GetNewIDExtender<LabTest>()).GetScalar(manager, obj);
                obj.idfValidatedByOffice = new Func<LabTest, long?>(c => eidss.model.Core.EidssSiteContext.Instance.OrganizationID)(obj);
                obj.idfTestedByOffice = new Func<LabTest, long?>(c => eidss.model.Core.EidssSiteContext.Instance.OrganizationID)(obj);
                obj.blnNonLaboratoryTest = new Func<LabTest, bool>(c => false)(obj);
                            obj.FFPresenter = FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, obj.idfObservation);
                            obj.FFPresenter.SetProperties(EidssSiteContext.Instance.CountryID, null, FFTypeEnum.TestDetails, obj.idfObservation);
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
                    throw DbModelException.Create(e);
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
                    throw new TypeMismatchException("idfContainer", typeof(long));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public LabTest Create(DbManagerProxy manager, IObject Parent
                , long idfContainer
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.SampleInfo = new Func<LabTest, LabTestSample>(c => SampleInfoAccessor.CreateNewT(manager, c))(obj);
                obj.idfContainer = new Func<LabTest, long>(c => idfContainer)(obj);
                obj.idfsTestStatusOriginal = new Func<LabTest, long?>(c => (long)BatchStatusEnum.Undefined)(obj);
                }
                    , obj =>
                {
                obj.TestStatus = new Func<LabTest, BaseReference>(c => c.TestStatusLookup.Where(l => l.idfsBaseReference == (long)BatchStatusEnum.Undefined).SingleOrDefault())(obj);
                obj.TestForDiseaseType = new Func<LabTest, BaseReference>(c => c.TestForDiseaseTypeLookup.Where(l => l.idfsBaseReference == (long)TestForDiseaseTypeEnum.Presumptive).SingleOrDefault())(obj);
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
                obj.datCreationDate = new Func<LabTest, DateTime?>(c => c.Sample.datCreationDate)(obj);
                obj.SampleInfo.idfContainer = new Func<LabTest, long>(c => idfContainer)(obj);
                obj.SampleInfo.strBarcode = new Func<LabTest, string>(c => c.Sample.strBarcode)(obj);
                obj.SampleInfo.SpecimenType = new Func<LabTest, string>(c => c.Sample.SpecimenType)(obj);
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
                        obj.TestStatus = obj.TestStatusLookup.Where(l => l.idfsBaseReference == (long)BatchStatusEnum.Amended).SingleOrDefault();
                        if (obj.AmendmentHistory.Where(c => c.IsNew).SingleOrDefault() == null)
                        {
                            obj.AmendmentHistory.Add(item);
                        }
                        return true;
                    
            }
            
            private void _SetupChildHandlers(LabTest obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabTest obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                            try
                            {
                            
                (new PredicateValidator("mbSureToUndefinedStatus", "idfsTestStatus", "idfsTestStatus", "idfsTestStatus",
              new object[] {
              },
                        true
                    )).Validate(obj, c => !(c.idfsTestStatusOriginal == (long)BatchStatusEnum.InProcess && c.idfsTestStatus == (long)BatchStatusEnum.Undefined)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_idfsTestStatus);
                                    obj._TestStatus = obj.TestStatusLookup.Where(a => a.idfsBaseReference == obj.idfsTestStatus).SingleOrDefault();
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datStartedDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("datBatchStartDate_ConcludedDate_msgId", "datStartedDate", "datStartedDate", "datStartedDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datStartedDate, c.datConcludedDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datStartedDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datConcludedDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("datBatchStartDate_ConcludedDate_msgId", "datConcludedDate", "datConcludedDate", "datConcludedDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datStartedDate, c.datConcludedDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datConcludedDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datStartedDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("datAccessionDate_BatchStartDate_msgId", "datStartedDate", "datStartedDate", "datStartedDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datCreationDate, c.datStartedDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datStartedDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_idfsCaseType)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestTypeRef(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_intHACode)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestTypeRef(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestType)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestResultRef(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.TestResultRef = new Func<LabTest, TestResultLookup>(c => (c.idfsTestStatusOriginal == (long)BatchStatusEnum.InProcess && c.idfsTestStatus == (long)BatchStatusEnum.Undefined) ? null : c.TestResultRef)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.strNote = new Func<LabTest, string>(c => (c.idfsTestStatusOriginal == (long)BatchStatusEnum.InProcess && c.idfsTestStatus == (long)BatchStatusEnum.Undefined) ? null : c.strNote)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.TestedByPerson = new Func<LabTest, PersonLookup>(c => (c.idfsTestStatusOriginal == (long)BatchStatusEnum.InProcess && c.idfsTestStatus == (long)BatchStatusEnum.Undefined) ? null : c.TestedByPerson)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.ValidatedByPerson = new Func<LabTest, PersonLookup>(c => (c.idfsTestStatusOriginal == (long)BatchStatusEnum.InProcess && c.idfsTestStatus == (long)BatchStatusEnum.Undefined) ? null : c.ValidatedByPerson)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.datStartedDate = new Func<LabTest, DateTime?>(c => (c.idfsTestStatusOriginal == (long)BatchStatusEnum.InProcess && c.idfsTestStatus == (long)BatchStatusEnum.Undefined) ? null : c.datStartedDate)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.datConcludedDate = new Func<LabTest, DateTime?>(c => (c.idfsTestStatusOriginal == (long)BatchStatusEnum.InProcess && c.idfsTestStatus == (long)BatchStatusEnum.Undefined) ? null : c.datConcludedDate)(obj);
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
                    
                obj.idfResultEnteredByOffice = new Func<LabTest, long?>(c => (c.idfsTestStatus == null || c.idfsTestStatus == (long)BatchStatusEnum.Undefined) ? null : (c.idfsTestResult == null ? (long?)null : eidss.model.Core.EidssSiteContext.Instance.OrganizationID))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.idfResultEnteredByPerson = new Func<LabTest, long?>(c => (c.idfsTestStatus == null || c.idfsTestStatus == (long)BatchStatusEnum.Undefined) ? null : (c.idfsTestResult == null ? (long?)null : (long)ModelUserContext.Instance.CurrentUser.EmployeeID))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.ResultEnteredByPerson = new Func<LabTest, string>(c => (c.idfsTestStatus == null || c.idfsTestStatus == (long)BatchStatusEnum.Undefined) ? "" : (c.idfsTestResult == null ? null : ModelUserContext.Instance.CurrentUser.FullName))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                            if (obj.idfsDiagnosis != 0 && obj.idfsTestType.HasValue)
                            {
                                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                                {
                                    long? idfsTestForDiseaseType = manager.SetSpCommand("dbo.spLabTest_GetDefaultCategory"
                                        , manager.Parameter("idfsDiagnosis", obj.idfsDiagnosis)
                                        , manager.Parameter("idfsTestType", obj.idfsTestType)
                                        ).ExecuteScalar<long?>();
                                    if (idfsTestForDiseaseType.HasValue)
                                        obj.TestForDiseaseType = obj.TestForDiseaseTypeLookup.Where(a => a.idfsBaseReference == idfsTestForDiseaseType.Value).SingleOrDefault();
                                }
                            }
                        
                        }
                    
                        if (e.PropertyName == _str_idfsTestType)
                        {
                    
                            if (obj.idfsDiagnosis != 0 && obj.idfsTestType.HasValue)
                            {
                                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                                {
                                    long? idfsTestForDiseaseType = manager.SetSpCommand("dbo.spLabTest_GetDefaultCategory"
                                        , manager.Parameter("idfsDiagnosis", obj.idfsDiagnosis)
                                        , manager.Parameter("idfsTestType", obj.idfsTestType)
                                        ).ExecuteScalar<long?>();
                                    if (idfsTestForDiseaseType.HasValue)
                                        obj.TestForDiseaseType = obj.TestForDiseaseTypeLookup.Where(a => a.idfsBaseReference == idfsTestForDiseaseType.Value).SingleOrDefault();
                                }
                            }
                        
                        }
                    
                    };
                
            }
    
            public void LoadLookup_TestStatus(DbManagerProxy manager, LabTest obj)
            {
                
                obj.TestStatusLookup.Clear();
                
                obj.TestStatusLookup.Add(TestStatusAccessor.CreateNewT(manager, null));
                
                obj.TestStatusLookup.AddRange(TestStatusAccessor.rftActivityStatus_SelectList(manager
                    
                    )
                    .Where(c => 
                                (obj.idfsTestStatusOriginal == (long)BatchStatusEnum.Undefined && (c.idfsBaseReference == (long)BatchStatusEnum.Completed || c.idfsBaseReference == (long)BatchStatusEnum.InProcess || c.idfsBaseReference == (long)BatchStatusEnum.Undefined)) ||
                                (obj.idfsTestStatusOriginal == (long)BatchStatusEnum.InProcess && (c.idfsBaseReference == (long)BatchStatusEnum.Completed || c.idfsBaseReference == (long)BatchStatusEnum.InProcess || c.idfsBaseReference == (long)BatchStatusEnum.Undefined)) ||
                                (obj.idfsTestStatusOriginal == (long)BatchStatusEnum.Completed && (c.idfsBaseReference == (long)BatchStatusEnum.Completed || c.idfsBaseReference == (long)BatchStatusEnum.Amended)) ||
                                (obj.idfsTestStatusOriginal == (long)BatchStatusEnum.Amended && (c.idfsBaseReference == (long)BatchStatusEnum.Amended))
                                )
                        
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
            
            public void LoadLookup_TestTypeRef(DbManagerProxy manager, LabTest obj)
            {
                
                obj.TestTypeRefLookup.Clear();
                
                obj.TestTypeRefLookup.Add(TestTypeRefAccessor.CreateNewT(manager, null));
                
                obj.TestTypeRefLookup.AddRange(TestTypeRefAccessor.rftTestType_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode & obj.intHACode) != 0 || c.idfsBaseReference == obj.idfsTestType)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestType))
                    
                    .ToList());
                
                if (obj.idfsTestType != null && obj.idfsTestType != 0)
                {
                    obj.TestTypeRef = obj.TestTypeRefLookup
                        .Where(c => c.idfsBaseReference == obj.idfsTestType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftTestType", obj, TestTypeRefAccessor.GetType(), "rftTestType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_TestResultRef(DbManagerProxy manager, LabTest obj)
            {
                
                obj.TestResultRefLookup.Clear();
                
                obj.TestResultRefLookup.Add(TestResultRefAccessor.CreateNewT(manager, null));
                
                obj.TestResultRefLookup.AddRange(TestResultRefAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => c.idfsTestType == obj.idfsTestType)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsTestResult))
                    
                    .ToList());
                
                if (obj.idfsTestResult != null && obj.idfsTestResult != 0)
                {
                    obj.TestResultRef = obj.TestResultRefLookup
                        .Where(c => c.idfsReference == obj.idfsTestResult)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("TestResultLookup", obj, TestResultRefAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_TestForDiseaseType(DbManagerProxy manager, LabTest obj)
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
            
            public void LoadLookup_Diagnosis(DbManagerProxy manager, LabTest obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    , new Func<LabTest, long?>(c => c.idfContainer)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .Where(c => c.idfsDiagnosis == obj.idfsDiagnosis)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("TestDiagnosisLookup", obj, DiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_ValidatedByPerson(DbManagerProxy manager, LabTest obj)
            {
                
                obj.ValidatedByPersonLookup.Clear();
                
                obj.ValidatedByPersonLookup.Add(ValidatedByPersonAccessor.CreateNewT(manager, null));
                
                obj.ValidatedByPersonLookup.AddRange(ValidatedByPersonAccessor.SelectLookupList(manager
                    
                    , new Func<LabTest, long?>(c => c.idfValidatedByOffice)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfValidatedByPerson))
                    
                    .ToList());
                
                if (obj.idfValidatedByPerson != null && obj.idfValidatedByPerson != 0)
                {
                    obj.ValidatedByPerson = obj.ValidatedByPersonLookup
                        .Where(c => c.idfPerson == obj.idfValidatedByPerson)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("PersonLookup", obj, ValidatedByPersonAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_TestedByPerson(DbManagerProxy manager, LabTest obj)
            {
                
                obj.TestedByPersonLookup.Clear();
                
                obj.TestedByPersonLookup.Add(TestedByPersonAccessor.CreateNewT(manager, null));
                
                obj.TestedByPersonLookup.AddRange(TestedByPersonAccessor.SelectLookupList(manager
                    
                    , new Func<LabTest, long?>(c => c.idfTestedByOffice)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfTestedByPerson))
                    
                    .ToList());
                
                if (obj.idfTestedByPerson != null && obj.idfTestedByPerson != 0)
                {
                    obj.TestedByPerson = obj.TestedByPersonLookup
                        .Where(c => c.idfPerson == obj.idfTestedByPerson)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("PersonLookup", obj, TestedByPersonAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, LabTest obj)
            {
                
                LoadLookup_TestStatus(manager, obj);
                
                LoadLookup_TestTypeRef(manager, obj);
                
                LoadLookup_TestResultRef(manager, obj);
                
                LoadLookup_TestForDiseaseType(manager, obj);
                
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
                [Direction.InputOutput("idfExtBatchTest")] LabTest obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfExtBatchTest")] LabTest obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    LabTest bo = obj as LabTest;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as LabTest, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, LabTest obj, bool bChildObject) 
            { 
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
                obj.AcceptChanges();
                
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
                return Validate(manager, obj as LabTest, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabTest obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsTestType", "TestTypeRef","",
                false
              )).Validate(c => true, obj, obj.idfsTestType);
            
                (new RequiredValidator( "idfsTestForDiseaseType", "TestForDiseaseType","",
                false
              )).Validate(c => true, obj, obj.idfsTestForDiseaseType);
            
                (new RequiredValidator( "idfsDiagnosis", "Diagnosis","",
                false
              )).Validate(c => true, obj, obj.idfsDiagnosis);
            
                (new RequiredValidator( "idfsTestStatus", "TestStatus","",
                false
              )).Validate(c => true, obj, obj.idfsTestStatus);
            
                (new RequiredValidator( "idfsTestResult", "TestResultRef","",
                false
              )).Validate(c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed || c.idfsTestStatus == (long)BatchStatusEnum.Amended), obj, obj.idfsTestResult);
            
                (new RequiredValidator( "idfTestedByPerson", "TestedByPerson","",
                false
              )).Validate(c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed), obj, obj.idfTestedByPerson);
            
                (new RequiredValidator( "datStartedDate", "datStartedDate","",
                false
              )).Validate(c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed), obj, obj.datStartedDate);
            
                (new RequiredValidator( "datConcludedDate", "datConcludedDate","",
                false
              )).Validate(c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed), obj, obj.datConcludedDate);
            
                (new RequiredValidator( "idfValidatedByPerson", "ValidatedByPerson","",
                false
              )).Validate(c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed), obj, obj.idfValidatedByPerson);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                (new PredicateValidator("datBatchStartDate_ConcludedDate_msgId", "datStartedDate", "datStartedDate", "datStartedDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datStartedDate, c.datConcludedDate)
                    );
            
                (new PredicateValidator("datBatchStartDate_ConcludedDate_msgId", "datConcludedDate", "datConcludedDate", "datConcludedDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datStartedDate, c.datConcludedDate)
                    );
            
                (new PredicateValidator("datAccessionDate_BatchStartDate_msgId", "datStartedDate", "datStartedDate", "datStartedDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datCreationDate, c.datStartedDate)
                    );
            
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.AmendmentHistory != null)
                            foreach (var i in obj.AmendmentHistory.Where(c => !c.IsMarkedToDelete))
                                AmendmentHistoryAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FFPresenter != null)
                            FFPresenterAccessor.Validate(manager, obj.FFPresenter, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
                    .AddRequired("TestTypeRef", c => true);
                    
                obj
                    .AddRequired("TestForDiseaseType", c => true);
                    
                obj
                    .AddRequired("Diagnosis", c => true);
                    
                obj
                    .AddRequired("TestStatus", c => true);
                    
                obj
                    .AddRequired("TestResultRef", c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed || c.idfsTestStatus == (long)BatchStatusEnum.Amended));
                    
                obj
                    .AddRequired("TestedByPerson", c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed));
                    
                obj
                    .AddRequired("datStartedDate", c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed));
                    
                obj
                    .AddRequired("datConcludedDate", c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed));
                    
                obj
                    .AddRequired("ValidatedByPerson", c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed));
                    
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
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabTest, bool>> RequiredByField = new Dictionary<string, Func<LabTest, bool>>();
            public static Dictionary<string, Func<LabTest, bool>> RequiredByProperty = new Dictionary<string, Func<LabTest, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
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
                if (!RequiredByField.ContainsKey("idfsTestType")) RequiredByField.Add("idfsTestType", c => true);
                if (!RequiredByProperty.ContainsKey("TestTypeRef")) RequiredByProperty.Add("TestTypeRef", c => true);
                
                if (!RequiredByField.ContainsKey("idfsTestForDiseaseType")) RequiredByField.Add("idfsTestForDiseaseType", c => true);
                if (!RequiredByProperty.ContainsKey("TestForDiseaseType")) RequiredByProperty.Add("TestForDiseaseType", c => true);
                
                if (!RequiredByField.ContainsKey("idfsDiagnosis")) RequiredByField.Add("idfsDiagnosis", c => true);
                if (!RequiredByProperty.ContainsKey("Diagnosis")) RequiredByProperty.Add("Diagnosis", c => true);
                
                if (!RequiredByField.ContainsKey("idfsTestStatus")) RequiredByField.Add("idfsTestStatus", c => true);
                if (!RequiredByProperty.ContainsKey("TestStatus")) RequiredByProperty.Add("TestStatus", c => true);
                
                if (!RequiredByField.ContainsKey("idfsTestResult")) RequiredByField.Add("idfsTestResult", c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed || c.idfsTestStatus == (long)BatchStatusEnum.Amended));
                if (!RequiredByProperty.ContainsKey("TestResultRef")) RequiredByProperty.Add("TestResultRef", c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed || c.idfsTestStatus == (long)BatchStatusEnum.Amended));
                
                if (!RequiredByField.ContainsKey("idfTestedByPerson")) RequiredByField.Add("idfTestedByPerson", c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed));
                if (!RequiredByProperty.ContainsKey("TestedByPerson")) RequiredByProperty.Add("TestedByPerson", c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed));
                
                if (!RequiredByField.ContainsKey("datStartedDate")) RequiredByField.Add("datStartedDate", c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed));
                if (!RequiredByProperty.ContainsKey("datStartedDate")) RequiredByProperty.Add("datStartedDate", c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed));
                
                if (!RequiredByField.ContainsKey("datConcludedDate")) RequiredByField.Add("datConcludedDate", c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed));
                if (!RequiredByProperty.ContainsKey("datConcludedDate")) RequiredByProperty.Add("datConcludedDate", c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed));
                
                if (!RequiredByField.ContainsKey("idfValidatedByPerson")) RequiredByField.Add("idfValidatedByPerson", c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed));
                if (!RequiredByProperty.ContainsKey("ValidatedByPerson")) RequiredByProperty.Add("ValidatedByPerson", c => (c.idfsTestStatus == (long)BatchStatusEnum.Completed));
                
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
                    null,
                    false
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
                    (c, p, b) => (c as LabTest).idfsTestStatusOriginal == (long)BatchStatusEnum.Completed || (c as LabTest).idfsTestStatusOriginal == (long)BatchStatusEnum.Amended,
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
        
        [MapField(_str_idfContainer), NonUpdatable, PrimaryKey]
        public abstract Int64 idfContainer { get; set; }
                
        [LocalizedDisplayName("SampleID")]
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
                
        [LocalizedDisplayName("DateCollected")]
        [MapField(_str_datFieldCollectionDate)]
        public abstract DateTime? datFieldCollectionDate { get; set; }
        #if MONO
        protected DateTime? datFieldCollectionDate_Original { get { return datFieldCollectionDate; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return datFieldCollectionDate; } }
        #else
        protected DateTime? datFieldCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).OriginalValue; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("HumanSpeciesName")]
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
                
        [LocalizedDisplayName(_str_strVectorCode)]
        [MapField(_str_strVectorCode)]
        public abstract String strVectorCode { get; set; }
        #if MONO
        protected String strVectorCode_Original { get { return strVectorCode; } }
        protected String strVectorCode_Previous { get { return strVectorCode; } }
        #else
        protected String strVectorCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorCode).OriginalValue; } }
        protected String strVectorCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorCode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strPartyName)]
        [MapField(_str_strPartyName)]
        public abstract String strPartyName { get; set; }
        #if MONO
        protected String strPartyName_Original { get { return strPartyName; } }
        protected String strPartyName_Previous { get { return strPartyName; } }
        #else
        protected String strPartyName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPartyName).OriginalValue; } }
        protected String strPartyName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPartyName).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<LabTestSample, object> _get_func;
            internal Action<LabTestSample, string> _set_func;
            internal Action<LabTestSample, LabTestSample, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfContainer = "idfContainer";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_SpecimenType = "SpecimenType";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_HumanName = "HumanName";
        internal const string _str_AnimalName = "AnimalName";
        internal const string _str_strAnimalCode = "strAnimalCode";
        internal const string _str_strVectorCode = "strVectorCode";
        internal const string _str_strPartyName = "strPartyName";
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
              _name = _str_datFieldCollectionDate, _type = "DateTime?",
              _get_func = o => o.datFieldCollectionDate,
              _set_func = (o, val) => { o.datFieldCollectionDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datFieldCollectionDate != c.datFieldCollectionDate || o.IsRIRPropChanged(_str_datFieldCollectionDate, c)) 
                  m.Add(_str_datFieldCollectionDate, o.ObjectIdent + _str_datFieldCollectionDate, "DateTime?", o.datFieldCollectionDate == null ? "" : o.datFieldCollectionDate.ToString(), o.IsReadOnly(_str_datFieldCollectionDate), o.IsInvisible(_str_datFieldCollectionDate), o.IsRequired(_str_datFieldCollectionDate)); }
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
              _name = _str_strAnimalCode, _type = "String",
              _get_func = o => o.strAnimalCode,
              _set_func = (o, val) => { o.strAnimalCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strAnimalCode != c.strAnimalCode || o.IsRIRPropChanged(_str_strAnimalCode, c)) 
                  m.Add(_str_strAnimalCode, o.ObjectIdent + _str_strAnimalCode, "String", o.strAnimalCode == null ? "" : o.strAnimalCode.ToString(), o.IsReadOnly(_str_strAnimalCode), o.IsInvisible(_str_strAnimalCode), o.IsRequired(_str_strAnimalCode)); }
              }, 
        
            new field_info {
              _name = _str_strVectorCode, _type = "String",
              _get_func = o => o.strVectorCode,
              _set_func = (o, val) => { o.strVectorCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorCode != c.strVectorCode || o.IsRIRPropChanged(_str_strVectorCode, c)) 
                  m.Add(_str_strVectorCode, o.ObjectIdent + _str_strVectorCode, "String", o.strVectorCode == null ? "" : o.strVectorCode.ToString(), o.IsReadOnly(_str_strVectorCode), o.IsInvisible(_str_strVectorCode), o.IsRequired(_str_strVectorCode)); }
              }, 
        
            new field_info {
              _name = _str_strPartyName, _type = "String",
              _get_func = o => o.strPartyName,
              _set_func = (o, val) => { o.strPartyName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strPartyName != c.strPartyName || o.IsRIRPropChanged(_str_strPartyName, c)) 
                  m.Add(_str_strPartyName, o.ObjectIdent + _str_strPartyName, "String", o.strPartyName == null ? "" : o.strPartyName.ToString(), o.IsReadOnly(_str_strPartyName), o.IsInvisible(_str_strPartyName), o.IsRequired(_str_strPartyName)); }
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
        public override object Clone()
        {
            var ret = base.Clone() as LabTestSample;
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
            var ret = base.Clone() as LabTestSample;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
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

      private bool IsRIRPropChanged(string fld, LabTestSample c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabTestSample()
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
            
            return ReadOnly || new Func<LabTestSample, bool>(c => true)(this);
                
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


        public Dictionary<string, Func<LabTestSample, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabTestSample, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabTestSample, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabTestSample, bool>> m_isHiddenPersonalData;
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
        ~LabTestSample()
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
        : DataAccessor<LabTestSample>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(LabTestSample obj);
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
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabTestSample obj)
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

    

            private LabTestSample _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabTestSample obj = LabTestSample.CreateInstance();
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

            
            public LabTestSample CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
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
    

            private void _LoadLookups(DbManagerProxy manager, LabTestSample obj)
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
                return Validate(manager, obj as LabTestSample, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabTestSample obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
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
              .AddHiddenPersonalData("HumanName", c=>true);
            
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
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabTestSample, bool>> RequiredByField = new Dictionary<string, Func<LabTestSample, bool>>();
            public static Dictionary<string, Func<LabTestSample, bool>> RequiredByProperty = new Dictionary<string, Func<LabTestSample, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_SpecimenType, 2000);
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
        #if MONO
        protected DateTime datAmendmentDate_Original { get { return datAmendmentDate; } }
        protected DateTime datAmendmentDate_Previous { get { return datAmendmentDate; } }
        #else
        protected DateTime datAmendmentDate_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datAmendmentDate).OriginalValue; } }
        protected DateTime datAmendmentDate_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datAmendmentDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strAmendByPerson")]
        [MapField(_str_strName)]
        public abstract String strName { get; set; }
        #if MONO
        protected String strName_Original { get { return strName; } }
        protected String strName_Previous { get { return strName; } }
        #else
        protected String strName_Original { get { return ((EditableValue<String>)((dynamic)this)._strName).OriginalValue; } }
        protected String strName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strOfficeAmendedBy")]
        [MapField(_str_strOffice)]
        public abstract String strOffice { get; set; }
        #if MONO
        protected String strOffice_Original { get { return strOffice; } }
        protected String strOffice_Previous { get { return strOffice; } }
        #else
        protected String strOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strOffice).OriginalValue; } }
        protected String strOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strOldTestResult)]
        [MapField(_str_strOldTestResult)]
        public abstract String strOldTestResult { get; set; }
        #if MONO
        protected String strOldTestResult_Original { get { return strOldTestResult; } }
        protected String strOldTestResult_Previous { get { return strOldTestResult; } }
        #else
        protected String strOldTestResult_Original { get { return ((EditableValue<String>)((dynamic)this)._strOldTestResult).OriginalValue; } }
        protected String strOldTestResult_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOldTestResult).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strNewTestResult)]
        [MapField(_str_strNewTestResult)]
        public abstract String strNewTestResult { get; set; }
        #if MONO
        protected String strNewTestResult_Original { get { return strNewTestResult; } }
        protected String strNewTestResult_Previous { get { return strNewTestResult; } }
        #else
        protected String strNewTestResult_Original { get { return ((EditableValue<String>)((dynamic)this)._strNewTestResult).OriginalValue; } }
        protected String strNewTestResult_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNewTestResult).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsOldTestResult)]
        [MapField(_str_idfsOldTestResult)]
        public abstract Int64? idfsOldTestResult { get; set; }
        #if MONO
        protected Int64? idfsOldTestResult_Original { get { return idfsOldTestResult; } }
        protected Int64? idfsOldTestResult_Previous { get { return idfsOldTestResult; } }
        #else
        protected Int64? idfsOldTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOldTestResult).OriginalValue; } }
        protected Int64? idfsOldTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOldTestResult).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsNewTestResult)]
        [MapField(_str_idfsNewTestResult)]
        public abstract Int64? idfsNewTestResult { get; set; }
        #if MONO
        protected Int64? idfsNewTestResult_Original { get { return idfsNewTestResult; } }
        protected Int64? idfsNewTestResult_Previous { get { return idfsNewTestResult; } }
        #else
        protected Int64? idfsNewTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsNewTestResult).OriginalValue; } }
        protected Int64? idfsNewTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsNewTestResult).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strOldNote)]
        [MapField(_str_strOldNote)]
        public abstract String strOldNote { get; set; }
        #if MONO
        protected String strOldNote_Original { get { return strOldNote; } }
        protected String strOldNote_Previous { get { return strOldNote; } }
        #else
        protected String strOldNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strOldNote).OriginalValue; } }
        protected String strOldNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOldNote).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strNewNote)]
        [MapField(_str_strNewNote)]
        public abstract String strNewNote { get; set; }
        #if MONO
        protected String strNewNote_Original { get { return strNewNote; } }
        protected String strNewNote_Previous { get { return strNewNote; } }
        #else
        protected String strNewNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNewNote).OriginalValue; } }
        protected String strNewNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNewNote).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strReason)]
        [MapField(_str_strReason)]
        public abstract String strReason { get; set; }
        #if MONO
        protected String strReason_Original { get { return strReason; } }
        protected String strReason_Previous { get { return strReason; } }
        #else
        protected String strReason_Original { get { return ((EditableValue<String>)((dynamic)this)._strReason).OriginalValue; } }
        protected String strReason_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReason).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfTesting)]
        [MapField(_str_idfTesting)]
        public abstract Int64 idfTesting { get; set; }
        #if MONO
        protected Int64 idfTesting_Original { get { return idfTesting; } }
        protected Int64 idfTesting_Previous { get { return idfTesting; } }
        #else
        protected Int64 idfTesting_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfTesting).OriginalValue; } }
        protected Int64 idfTesting_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfTesting).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfAmendByOffice)]
        [MapField(_str_idfAmendByOffice)]
        public abstract Int64? idfAmendByOffice { get; set; }
        #if MONO
        protected Int64? idfAmendByOffice_Original { get { return idfAmendByOffice; } }
        protected Int64? idfAmendByOffice_Previous { get { return idfAmendByOffice; } }
        #else
        protected Int64? idfAmendByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAmendByOffice).OriginalValue; } }
        protected Int64? idfAmendByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAmendByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfAmendByPerson)]
        [MapField(_str_idfAmendByPerson)]
        public abstract Int64? idfAmendByPerson { get; set; }
        #if MONO
        protected Int64? idfAmendByPerson_Original { get { return idfAmendByPerson; } }
        protected Int64? idfAmendByPerson_Previous { get { return idfAmendByPerson; } }
        #else
        protected Int64? idfAmendByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAmendByPerson).OriginalValue; } }
        protected Int64? idfAmendByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAmendByPerson).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<LabTestAmendmentHistory, object> _get_func;
            internal Action<LabTestAmendmentHistory, string> _set_func;
            internal Action<LabTestAmendmentHistory, LabTestAmendmentHistory, CompareModel> _compare_func;
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
              _name = _str_idfTestAmendmentHistory, _type = "Int64",
              _get_func = o => o.idfTestAmendmentHistory,
              _set_func = (o, val) => { o.idfTestAmendmentHistory = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTestAmendmentHistory != c.idfTestAmendmentHistory || o.IsRIRPropChanged(_str_idfTestAmendmentHistory, c)) 
                  m.Add(_str_idfTestAmendmentHistory, o.ObjectIdent + _str_idfTestAmendmentHistory, "Int64", o.idfTestAmendmentHistory == null ? "" : o.idfTestAmendmentHistory.ToString(), o.IsReadOnly(_str_idfTestAmendmentHistory), o.IsInvisible(_str_idfTestAmendmentHistory), o.IsRequired(_str_idfTestAmendmentHistory)); }
              }, 
        
            new field_info {
              _name = _str_datAmendmentDate, _type = "DateTime",
              _get_func = o => o.datAmendmentDate,
              _set_func = (o, val) => { o.datAmendmentDate = ParsingHelper.ParseDateTime(val); },
              _compare_func = (o, c, m) => {
                if (o.datAmendmentDate != c.datAmendmentDate || o.IsRIRPropChanged(_str_datAmendmentDate, c)) 
                  m.Add(_str_datAmendmentDate, o.ObjectIdent + _str_datAmendmentDate, "DateTime", o.datAmendmentDate == null ? "" : o.datAmendmentDate.ToString(), o.IsReadOnly(_str_datAmendmentDate), o.IsInvisible(_str_datAmendmentDate), o.IsRequired(_str_datAmendmentDate)); }
              }, 
        
            new field_info {
              _name = _str_strName, _type = "String",
              _get_func = o => o.strName,
              _set_func = (o, val) => { o.strName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strName != c.strName || o.IsRIRPropChanged(_str_strName, c)) 
                  m.Add(_str_strName, o.ObjectIdent + _str_strName, "String", o.strName == null ? "" : o.strName.ToString(), o.IsReadOnly(_str_strName), o.IsInvisible(_str_strName), o.IsRequired(_str_strName)); }
              }, 
        
            new field_info {
              _name = _str_strOffice, _type = "String",
              _get_func = o => o.strOffice,
              _set_func = (o, val) => { o.strOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strOffice != c.strOffice || o.IsRIRPropChanged(_str_strOffice, c)) 
                  m.Add(_str_strOffice, o.ObjectIdent + _str_strOffice, "String", o.strOffice == null ? "" : o.strOffice.ToString(), o.IsReadOnly(_str_strOffice), o.IsInvisible(_str_strOffice), o.IsRequired(_str_strOffice)); }
              }, 
        
            new field_info {
              _name = _str_strOldTestResult, _type = "String",
              _get_func = o => o.strOldTestResult,
              _set_func = (o, val) => { o.strOldTestResult = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strOldTestResult != c.strOldTestResult || o.IsRIRPropChanged(_str_strOldTestResult, c)) 
                  m.Add(_str_strOldTestResult, o.ObjectIdent + _str_strOldTestResult, "String", o.strOldTestResult == null ? "" : o.strOldTestResult.ToString(), o.IsReadOnly(_str_strOldTestResult), o.IsInvisible(_str_strOldTestResult), o.IsRequired(_str_strOldTestResult)); }
              }, 
        
            new field_info {
              _name = _str_strNewTestResult, _type = "String",
              _get_func = o => o.strNewTestResult,
              _set_func = (o, val) => { o.strNewTestResult = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNewTestResult != c.strNewTestResult || o.IsRIRPropChanged(_str_strNewTestResult, c)) 
                  m.Add(_str_strNewTestResult, o.ObjectIdent + _str_strNewTestResult, "String", o.strNewTestResult == null ? "" : o.strNewTestResult.ToString(), o.IsReadOnly(_str_strNewTestResult), o.IsInvisible(_str_strNewTestResult), o.IsRequired(_str_strNewTestResult)); }
              }, 
        
            new field_info {
              _name = _str_idfsOldTestResult, _type = "Int64?",
              _get_func = o => o.idfsOldTestResult,
              _set_func = (o, val) => { o.idfsOldTestResult = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsOldTestResult != c.idfsOldTestResult || o.IsRIRPropChanged(_str_idfsOldTestResult, c)) 
                  m.Add(_str_idfsOldTestResult, o.ObjectIdent + _str_idfsOldTestResult, "Int64?", o.idfsOldTestResult == null ? "" : o.idfsOldTestResult.ToString(), o.IsReadOnly(_str_idfsOldTestResult), o.IsInvisible(_str_idfsOldTestResult), o.IsRequired(_str_idfsOldTestResult)); }
              }, 
        
            new field_info {
              _name = _str_idfsNewTestResult, _type = "Int64?",
              _get_func = o => o.idfsNewTestResult,
              _set_func = (o, val) => { o.idfsNewTestResult = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsNewTestResult != c.idfsNewTestResult || o.IsRIRPropChanged(_str_idfsNewTestResult, c)) 
                  m.Add(_str_idfsNewTestResult, o.ObjectIdent + _str_idfsNewTestResult, "Int64?", o.idfsNewTestResult == null ? "" : o.idfsNewTestResult.ToString(), o.IsReadOnly(_str_idfsNewTestResult), o.IsInvisible(_str_idfsNewTestResult), o.IsRequired(_str_idfsNewTestResult)); }
              }, 
        
            new field_info {
              _name = _str_strOldNote, _type = "String",
              _get_func = o => o.strOldNote,
              _set_func = (o, val) => { o.strOldNote = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strOldNote != c.strOldNote || o.IsRIRPropChanged(_str_strOldNote, c)) 
                  m.Add(_str_strOldNote, o.ObjectIdent + _str_strOldNote, "String", o.strOldNote == null ? "" : o.strOldNote.ToString(), o.IsReadOnly(_str_strOldNote), o.IsInvisible(_str_strOldNote), o.IsRequired(_str_strOldNote)); }
              }, 
        
            new field_info {
              _name = _str_strNewNote, _type = "String",
              _get_func = o => o.strNewNote,
              _set_func = (o, val) => { o.strNewNote = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNewNote != c.strNewNote || o.IsRIRPropChanged(_str_strNewNote, c)) 
                  m.Add(_str_strNewNote, o.ObjectIdent + _str_strNewNote, "String", o.strNewNote == null ? "" : o.strNewNote.ToString(), o.IsReadOnly(_str_strNewNote), o.IsInvisible(_str_strNewNote), o.IsRequired(_str_strNewNote)); }
              }, 
        
            new field_info {
              _name = _str_strReason, _type = "String",
              _get_func = o => o.strReason,
              _set_func = (o, val) => { o.strReason = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strReason != c.strReason || o.IsRIRPropChanged(_str_strReason, c)) 
                  m.Add(_str_strReason, o.ObjectIdent + _str_strReason, "String", o.strReason == null ? "" : o.strReason.ToString(), o.IsReadOnly(_str_strReason), o.IsInvisible(_str_strReason), o.IsRequired(_str_strReason)); }
              }, 
        
            new field_info {
              _name = _str_idfTesting, _type = "Int64",
              _get_func = o => o.idfTesting,
              _set_func = (o, val) => { o.idfTesting = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTesting != c.idfTesting || o.IsRIRPropChanged(_str_idfTesting, c)) 
                  m.Add(_str_idfTesting, o.ObjectIdent + _str_idfTesting, "Int64", o.idfTesting == null ? "" : o.idfTesting.ToString(), o.IsReadOnly(_str_idfTesting), o.IsInvisible(_str_idfTesting), o.IsRequired(_str_idfTesting)); }
              }, 
        
            new field_info {
              _name = _str_idfAmendByOffice, _type = "Int64?",
              _get_func = o => o.idfAmendByOffice,
              _set_func = (o, val) => { o.idfAmendByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfAmendByOffice != c.idfAmendByOffice || o.IsRIRPropChanged(_str_idfAmendByOffice, c)) 
                  m.Add(_str_idfAmendByOffice, o.ObjectIdent + _str_idfAmendByOffice, "Int64?", o.idfAmendByOffice == null ? "" : o.idfAmendByOffice.ToString(), o.IsReadOnly(_str_idfAmendByOffice), o.IsInvisible(_str_idfAmendByOffice), o.IsRequired(_str_idfAmendByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfAmendByPerson, _type = "Int64?",
              _get_func = o => o.idfAmendByPerson,
              _set_func = (o, val) => { o.idfAmendByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfAmendByPerson != c.idfAmendByPerson || o.IsRIRPropChanged(_str_idfAmendByPerson, c)) 
                  m.Add(_str_idfAmendByPerson, o.ObjectIdent + _str_idfAmendByPerson, "Int64?", o.idfAmendByPerson == null ? "" : o.idfAmendByPerson.ToString(), o.IsReadOnly(_str_idfAmendByPerson), o.IsInvisible(_str_idfAmendByPerson), o.IsRequired(_str_idfAmendByPerson)); }
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
              _name = _str_OldTestResult, _type = "Lookup",
              _get_func = o => { if (o.OldTestResult == null) return null; return o.OldTestResult.idfsReference; },
              _set_func = (o, val) => { o.OldTestResult = o.OldTestResultLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsOldTestResult != c.idfsOldTestResult || o.IsRIRPropChanged(_str_OldTestResult, c)) 
                  m.Add(_str_OldTestResult, o.ObjectIdent + _str_OldTestResult, "Lookup", o.idfsOldTestResult == null ? "" : o.idfsOldTestResult.ToString(), o.IsReadOnly(_str_OldTestResult), o.IsInvisible(_str_OldTestResult), o.IsRequired(_str_OldTestResult)); }
              }, 
        
            new field_info {
              _name = _str_NewTestResult, _type = "Lookup",
              _get_func = o => { if (o.NewTestResult == null) return null; return o.NewTestResult.idfsReference; },
              _set_func = (o, val) => { o.NewTestResult = o.NewTestResultLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsNewTestResult != c.idfsNewTestResult || o.IsRIRPropChanged(_str_NewTestResult, c)) 
                  m.Add(_str_NewTestResult, o.ObjectIdent + _str_NewTestResult, "Lookup", o.idfsNewTestResult == null ? "" : o.idfsNewTestResult.ToString(), o.IsReadOnly(_str_NewTestResult), o.IsInvisible(_str_NewTestResult), o.IsRequired(_str_NewTestResult)); }
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
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(TestResultLookup), eidss.model.Schema.TestResultLookup._str_idfsReference, _str_idfsOldTestResult)]
        public TestResultLookup OldTestResult
        {
            get { return _OldTestResult == null ? null : ((long)_OldTestResult.Key == 0 ? null : _OldTestResult); }
            set 
            { 
                _OldTestResult = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsOldTestResult = _OldTestResult == null 
                    ? new Int64?()
                    : _OldTestResult.idfsReference; 
                OnPropertyChanged(_str_OldTestResult); 
            }
        }
        private TestResultLookup _OldTestResult;

        
        public List<TestResultLookup> OldTestResultLookup
        {
            get { return _OldTestResultLookup; }
        }
        private List<TestResultLookup> _OldTestResultLookup = new List<TestResultLookup>();
            
        [Relation(typeof(TestResultLookup), eidss.model.Schema.TestResultLookup._str_idfsReference, _str_idfsNewTestResult)]
        public TestResultLookup NewTestResult
        {
            get { return _NewTestResult == null ? null : ((long)_NewTestResult.Key == 0 ? null : _NewTestResult); }
            set 
            { 
                _NewTestResult = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsNewTestResult = _NewTestResult == null 
                    ? new Int64?()
                    : _NewTestResult.idfsReference; 
                OnPropertyChanged(_str_NewTestResult); 
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
        public override object Clone()
        {
            var ret = base.Clone() as LabTestAmendmentHistory;
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
            var ret = base.Clone() as LabTestAmendmentHistory;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
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

      private bool IsRIRPropChanged(string fld, LabTestAmendmentHistory c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabTestAmendmentHistory()
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


        public Dictionary<string, Func<LabTestAmendmentHistory, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabTestAmendmentHistory, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabTestAmendmentHistory, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabTestAmendmentHistory, bool>> m_isHiddenPersonalData;
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
        ~LabTestAmendmentHistory()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("TestResultLookup", this);
                
                LookupManager.RemoveObject("TestResultLookup", this);
                
            }
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
        public class LabTestAmendmentHistoryGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfTestAmendmentHistory { get; set; }
        
            public DateTime datAmendmentDate { get; set; }
        
            public string strName { get; set; }
        
            public string strOffice { get; set; }
        
            public string strNewTestResult { get; set; }
        
            public string strReason { get; set; }
        
        }
        public partial class LabTestAmendmentHistoryGridModelList : List<LabTestAmendmentHistoryGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public LabTestAmendmentHistoryGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabTestAmendmentHistory>, errMes);
            }
            public LabTestAmendmentHistoryGridModelList(long key, IEnumerable<LabTestAmendmentHistory> items)
            {
                LoadGridModelList(key, items, null);
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
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(LabTestAmendmentHistory obj);
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
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabTestAmendmentHistory obj)
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

    

            private LabTestAmendmentHistory _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabTestAmendmentHistory obj = LabTestAmendmentHistory.CreateInstance();
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

            
            public LabTestAmendmentHistory CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
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
                    .Where(c => c.idfsTestType == (obj.Parent as LabTest).idfsTestType)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsOldTestResult))
                    
                    .ToList());
                
                if (obj.idfsOldTestResult != null && obj.idfsOldTestResult != 0)
                {
                    obj.OldTestResult = obj.OldTestResultLookup
                        .Where(c => c.idfsReference == obj.idfsOldTestResult)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("TestResultLookup", obj, OldTestResultAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_NewTestResult(DbManagerProxy manager, LabTestAmendmentHistory obj)
            {
                
                obj.NewTestResultLookup.Clear();
                
                obj.NewTestResultLookup.Add(NewTestResultAccessor.CreateNewT(manager, null));
                
                obj.NewTestResultLookup.AddRange(NewTestResultAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => c.idfsTestType == (obj.Parent as LabTest).idfsTestType)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsNewTestResult))
                    
                    .ToList());
                
                if (obj.idfsNewTestResult != null && obj.idfsNewTestResult != 0)
                {
                    obj.NewTestResult = obj.NewTestResultLookup
                        .Where(c => c.idfsReference == obj.idfsNewTestResult)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("TestResultLookup", obj, NewTestResultAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, LabTestAmendmentHistory obj)
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
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    LabTestAmendmentHistory bo = obj as LabTestAmendmentHistory;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        long mainObject = bo.idfTestAmendmentHistory;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            
                            eidss.model.Enums.EventType eventType = eidss.model.Enums.EventType.NewTestAmendment;
                            manager.SetEventParams("NewTestAmendment", new object[] { eventType, bo.idfTesting, "" });
                            
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
            private bool _PostNonTransaction(DbManagerProxy manager, LabTestAmendmentHistory obj, bool bChildObject) 
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
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as LabTestAmendmentHistory, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabTestAmendmentHistory obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "strReason", "strReason","",
                false
              )).Validate(c => true, obj, obj.strReason);
            
                (new RequiredValidator( "idfsNewTestResult", "NewTestResult","",
                false
              )).Validate(c => true, obj, obj.idfsNewTestResult);
            
                (new PredicateValidator("errReasonForChangeIsTooShort", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => !c.IsNew || c.strReason.Length >= 6
                    );
            
                (new PredicateValidator("New_test_result_as_old_one", "", "", "",
              new object[] {
              },
                        false
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
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
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
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabTestAmendmentHistory, bool>> RequiredByField = new Dictionary<string, Func<LabTestAmendmentHistory, bool>>();
            public static Dictionary<string, Func<LabTestAmendmentHistory, bool>> RequiredByProperty = new Dictionary<string, Func<LabTestAmendmentHistory, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strName, 602);
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
                    _str_idfTestAmendmentHistory, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datAmendmentDate,
                    _str_datAmendmentDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strName,
                    "strAmendByPerson", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strOffice,
                    "strOfficeAmendedBy", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNewTestResult,
                    _str_strNewTestResult, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strReason,
                    _str_strReason, null, true, true, null
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	