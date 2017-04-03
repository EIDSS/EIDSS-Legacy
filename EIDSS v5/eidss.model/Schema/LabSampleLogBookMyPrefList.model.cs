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
    public abstract partial class LabSampleLogBookMyPrefListItem : 
        EditableObject<LabSampleLogBookMyPrefListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_ID), NonUpdatable, PrimaryKey]
        public abstract Int64 ID { get; set; }
                
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
                
        [LocalizedDisplayName(_str_idfContainer)]
        [MapField(_str_idfContainer)]
        public abstract Int64 idfContainer { get; set; }
        #if MONO
        protected Int64 idfContainer_Original { get { return idfContainer; } }
        protected Int64 idfContainer_Previous { get { return idfContainer; } }
        #else
        protected Int64 idfContainer_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfContainer).OriginalValue; } }
        protected Int64 idfContainer_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfContainer).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsSpecimenType)]
        [MapField(_str_idfsSpecimenType)]
        public abstract Int64? idfsSpecimenType { get; set; }
        #if MONO
        protected Int64? idfsSpecimenType_Original { get { return idfsSpecimenType; } }
        protected Int64? idfsSpecimenType_Previous { get { return idfsSpecimenType; } }
        #else
        protected Int64? idfsSpecimenType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpecimenType).OriginalValue; } }
        protected Int64? idfsSpecimenType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpecimenType).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsTestStatus)]
        [MapField(_str_idfsTestStatus)]
        public abstract Int64? idfsTestStatus { get; set; }
        #if MONO
        protected Int64? idfsTestStatus_Original { get { return idfsTestStatus; } }
        protected Int64? idfsTestStatus_Previous { get { return idfsTestStatus; } }
        #else
        protected Int64? idfsTestStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestStatus).OriginalValue; } }
        protected Int64? idfsTestStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestStatus).PreviousValue; } }
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
                
        [LocalizedDisplayName("strCaseIDSessionID")]
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
                
        [LocalizedDisplayName("TestName")]
        [MapField(_str_TestType)]
        public abstract String TestType { get; set; }
        #if MONO
        protected String TestType_Original { get { return TestType; } }
        protected String TestType_Previous { get { return TestType; } }
        #else
        protected String TestType_Original { get { return ((EditableValue<String>)((dynamic)this)._testType).OriginalValue; } }
        protected String TestType_Previous { get { return ((EditableValue<String>)((dynamic)this)._testType).PreviousValue; } }
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
                
        [LocalizedDisplayName("TestStatus")]
        [MapField(_str_Status)]
        public abstract String Status { get; set; }
        #if MONO
        protected String Status_Original { get { return Status; } }
        protected String Status_Previous { get { return Status; } }
        #else
        protected String Status_Original { get { return ((EditableValue<String>)((dynamic)this)._status).OriginalValue; } }
        protected String Status_Previous { get { return ((EditableValue<String>)((dynamic)this)._status).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strSampleConditionReceivedStatus)]
        [MapField(_str_strSampleConditionReceivedStatus)]
        public abstract String strSampleConditionReceivedStatus { get; set; }
        #if MONO
        protected String strSampleConditionReceivedStatus_Original { get { return strSampleConditionReceivedStatus; } }
        protected String strSampleConditionReceivedStatus_Previous { get { return strSampleConditionReceivedStatus; } }
        #else
        protected String strSampleConditionReceivedStatus_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleConditionReceivedStatus).OriginalValue; } }
        protected String strSampleConditionReceivedStatus_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleConditionReceivedStatus).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<LabSampleLogBookMyPrefListItem, object> _get_func;
            internal Action<LabSampleLogBookMyPrefListItem, string> _set_func;
            internal Action<LabSampleLogBookMyPrefListItem, LabSampleLogBookMyPrefListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_ID = "ID";
        internal const string _str_idfTesting = "idfTesting";
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_idfContainer = "idfContainer";
        internal const string _str_idfsContainerStatus = "idfsContainerStatus";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_idfsSpecimenType = "idfsSpecimenType";
        internal const string _str_idfsTestType = "idfsTestType";
        internal const string _str_idfsTestForDiseaseType = "idfsTestForDiseaseType";
        internal const string _str_idfsTestStatus = "idfsTestStatus";
        internal const string _str_idfsTestResult = "idfsTestResult";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_SpecimenType = "SpecimenType";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_datCreationDate = "datCreationDate";
        internal const string _str_CaseID = "CaseID";
        internal const string _str_DiagnosisName = "DiagnosisName";
        internal const string _str_TestType = "TestType";
        internal const string _str_TestCategory = "TestCategory";
        internal const string _str_Status = "Status";
        internal const string _str_TestResult = "TestResult";
        internal const string _str_datStartedDate = "datStartedDate";
        internal const string _str_datConcludedDate = "datConcludedDate";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfsAccessionCondition = "idfsAccessionCondition";
        internal const string _str_idfsSpeciesType = "idfsSpeciesType";
        internal const string _str_strSampleConditionReceivedStatus = "strSampleConditionReceivedStatus";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_SampleType = "SampleType";
        internal const string _str_TestTypeRef = "TestTypeRef";
        internal const string _str_TestResultRef = "TestResultRef";
        internal const string _str_TestForDiseaseType = "TestForDiseaseType";
        internal const string _str_TestStatus = "TestStatus";
        internal const string _str_ContainerStatus = "ContainerStatus";
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
              _name = _str_idfTesting, _type = "Int64?",
              _get_func = o => o.idfTesting,
              _set_func = (o, val) => { o.idfTesting = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTesting != c.idfTesting || o.IsRIRPropChanged(_str_idfTesting, c)) 
                  m.Add(_str_idfTesting, o.ObjectIdent + _str_idfTesting, "Int64?", o.idfTesting == null ? "" : o.idfTesting.ToString(), o.IsReadOnly(_str_idfTesting), o.IsInvisible(_str_idfTesting), o.IsRequired(_str_idfTesting)); }
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
              _name = _str_idfsDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { o.idfsDiagnosis = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, "Int64?", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_idfsSpecimenType, _type = "Int64?",
              _get_func = o => o.idfsSpecimenType,
              _set_func = (o, val) => { o.idfsSpecimenType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpecimenType != c.idfsSpecimenType || o.IsRIRPropChanged(_str_idfsSpecimenType, c)) 
                  m.Add(_str_idfsSpecimenType, o.ObjectIdent + _str_idfsSpecimenType, "Int64?", o.idfsSpecimenType == null ? "" : o.idfsSpecimenType.ToString(), o.IsReadOnly(_str_idfsSpecimenType), o.IsInvisible(_str_idfsSpecimenType), o.IsRequired(_str_idfsSpecimenType)); }
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
              _name = _str_idfsTestForDiseaseType, _type = "Int64?",
              _get_func = o => o.idfsTestForDiseaseType,
              _set_func = (o, val) => { o.idfsTestForDiseaseType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestForDiseaseType != c.idfsTestForDiseaseType || o.IsRIRPropChanged(_str_idfsTestForDiseaseType, c)) 
                  m.Add(_str_idfsTestForDiseaseType, o.ObjectIdent + _str_idfsTestForDiseaseType, "Int64?", o.idfsTestForDiseaseType == null ? "" : o.idfsTestForDiseaseType.ToString(), o.IsReadOnly(_str_idfsTestForDiseaseType), o.IsInvisible(_str_idfsTestForDiseaseType), o.IsRequired(_str_idfsTestForDiseaseType)); }
              }, 
        
            new field_info {
              _name = _str_idfsTestStatus, _type = "Int64?",
              _get_func = o => o.idfsTestStatus,
              _set_func = (o, val) => { o.idfsTestStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestStatus != c.idfsTestStatus || o.IsRIRPropChanged(_str_idfsTestStatus, c)) 
                  m.Add(_str_idfsTestStatus, o.ObjectIdent + _str_idfsTestStatus, "Int64?", o.idfsTestStatus == null ? "" : o.idfsTestStatus.ToString(), o.IsReadOnly(_str_idfsTestStatus), o.IsInvisible(_str_idfsTestStatus), o.IsRequired(_str_idfsTestStatus)); }
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
              _name = _str_strBarcode, _type = "String",
              _get_func = o => o.strBarcode,
              _set_func = (o, val) => { o.strBarcode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strBarcode != c.strBarcode || o.IsRIRPropChanged(_str_strBarcode, c)) 
                  m.Add(_str_strBarcode, o.ObjectIdent + _str_strBarcode, "String", o.strBarcode == null ? "" : o.strBarcode.ToString(), o.IsReadOnly(_str_strBarcode), o.IsInvisible(_str_strBarcode), o.IsRequired(_str_strBarcode)); }
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
              _name = _str_datCreationDate, _type = "DateTime?",
              _get_func = o => o.datCreationDate,
              _set_func = (o, val) => { o.datCreationDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datCreationDate != c.datCreationDate || o.IsRIRPropChanged(_str_datCreationDate, c)) 
                  m.Add(_str_datCreationDate, o.ObjectIdent + _str_datCreationDate, "DateTime?", o.datCreationDate == null ? "" : o.datCreationDate.ToString(), o.IsReadOnly(_str_datCreationDate), o.IsInvisible(_str_datCreationDate), o.IsRequired(_str_datCreationDate)); }
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
              _name = _str_TestType, _type = "String",
              _get_func = o => o.TestType,
              _set_func = (o, val) => { o.TestType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.TestType != c.TestType || o.IsRIRPropChanged(_str_TestType, c)) 
                  m.Add(_str_TestType, o.ObjectIdent + _str_TestType, "String", o.TestType == null ? "" : o.TestType.ToString(), o.IsReadOnly(_str_TestType), o.IsInvisible(_str_TestType), o.IsRequired(_str_TestType)); }
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
              _name = _str_Status, _type = "String",
              _get_func = o => o.Status,
              _set_func = (o, val) => { o.Status = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.Status != c.Status || o.IsRIRPropChanged(_str_Status, c)) 
                  m.Add(_str_Status, o.ObjectIdent + _str_Status, "String", o.Status == null ? "" : o.Status.ToString(), o.IsReadOnly(_str_Status), o.IsInvisible(_str_Status), o.IsRequired(_str_Status)); }
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
              _name = _str_datStartedDate, _type = "DateTime?",
              _get_func = o => o.datStartedDate,
              _set_func = (o, val) => { o.datStartedDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datStartedDate != c.datStartedDate || o.IsRIRPropChanged(_str_datStartedDate, c)) 
                  m.Add(_str_datStartedDate, o.ObjectIdent + _str_datStartedDate, "DateTime?", o.datStartedDate == null ? "" : o.datStartedDate.ToString(), o.IsReadOnly(_str_datStartedDate), o.IsInvisible(_str_datStartedDate), o.IsRequired(_str_datStartedDate)); }
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
              _name = _str_idfsAccessionCondition, _type = "Int64?",
              _get_func = o => o.idfsAccessionCondition,
              _set_func = (o, val) => { o.idfsAccessionCondition = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsAccessionCondition != c.idfsAccessionCondition || o.IsRIRPropChanged(_str_idfsAccessionCondition, c)) 
                  m.Add(_str_idfsAccessionCondition, o.ObjectIdent + _str_idfsAccessionCondition, "Int64?", o.idfsAccessionCondition == null ? "" : o.idfsAccessionCondition.ToString(), o.IsReadOnly(_str_idfsAccessionCondition), o.IsInvisible(_str_idfsAccessionCondition), o.IsRequired(_str_idfsAccessionCondition)); }
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
              _name = _str_strSampleConditionReceivedStatus, _type = "String",
              _get_func = o => o.strSampleConditionReceivedStatus,
              _set_func = (o, val) => { o.strSampleConditionReceivedStatus = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSampleConditionReceivedStatus != c.strSampleConditionReceivedStatus || o.IsRIRPropChanged(_str_strSampleConditionReceivedStatus, c)) 
                  m.Add(_str_strSampleConditionReceivedStatus, o.ObjectIdent + _str_strSampleConditionReceivedStatus, "String", o.strSampleConditionReceivedStatus == null ? "" : o.strSampleConditionReceivedStatus.ToString(), o.IsReadOnly(_str_strSampleConditionReceivedStatus), o.IsInvisible(_str_strSampleConditionReceivedStatus), o.IsRequired(_str_strSampleConditionReceivedStatus)); }
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
              _name = _str_TestTypeRef, _type = "Lookup",
              _get_func = o => { if (o.TestTypeRef == null) return null; return o.TestTypeRef.idfsBaseReference; },
              _set_func = (o, val) => { o.TestTypeRef = o.TestTypeRefLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestType != c.idfsTestType || o.IsRIRPropChanged(_str_TestTypeRef, c)) 
                  m.Add(_str_TestTypeRef, o.ObjectIdent + _str_TestTypeRef, "Lookup", o.idfsTestType == null ? "" : o.idfsTestType.ToString(), o.IsReadOnly(_str_TestTypeRef), o.IsInvisible(_str_TestTypeRef), o.IsRequired(_str_TestTypeRef)); }
              }, 
        
            new field_info {
              _name = _str_TestResultRef, _type = "Lookup",
              _get_func = o => { if (o.TestResultRef == null) return null; return o.TestResultRef.idfsBaseReference; },
              _set_func = (o, val) => { o.TestResultRef = o.TestResultRefLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
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
              _name = _str_TestStatus, _type = "Lookup",
              _get_func = o => { if (o.TestStatus == null) return null; return o.TestStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.TestStatus = o.TestStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestStatus != c.idfsTestStatus || o.IsRIRPropChanged(_str_TestStatus, c)) 
                  m.Add(_str_TestStatus, o.ObjectIdent + _str_TestStatus, "Lookup", o.idfsTestStatus == null ? "" : o.idfsTestStatus.ToString(), o.IsReadOnly(_str_TestStatus), o.IsInvisible(_str_TestStatus), o.IsRequired(_str_TestStatus)); }
              }, 
        
            new field_info {
              _name = _str_ContainerStatus, _type = "Lookup",
              _get_func = o => { if (o.ContainerStatus == null) return null; return o.ContainerStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.ContainerStatus = o.ContainerStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsContainerStatus != c.idfsContainerStatus || o.IsRIRPropChanged(_str_ContainerStatus, c)) 
                  m.Add(_str_ContainerStatus, o.ObjectIdent + _str_ContainerStatus, "Lookup", o.idfsContainerStatus == null ? "" : o.idfsContainerStatus.ToString(), o.IsReadOnly(_str_ContainerStatus), o.IsInvisible(_str_ContainerStatus), o.IsRequired(_str_ContainerStatus)); }
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
            LabSampleLogBookMyPrefListItem obj = (LabSampleLogBookMyPrefListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
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
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSpecimenType)]
        public BaseReference SampleType
        {
            get { return _SampleType == null ? null : ((long)_SampleType.Key == 0 ? null : _SampleType); }
            set 
            { 
                _SampleType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsSpecimenType = _SampleType == null 
                    ? new Int64?()
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
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestStatus)]
        public BaseReference TestStatus
        {
            get { return _TestStatus == null ? null : ((long)_TestStatus.Key == 0 ? null : _TestStatus); }
            set 
            { 
                _TestStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsTestStatus = _TestStatus == null 
                    ? new Int64?()
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
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_SampleType:
                    return new BvSelectList(SampleTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SampleType, _str_idfsSpecimenType);
            
                case _str_TestTypeRef:
                    return new BvSelectList(TestTypeRefLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestTypeRef, _str_idfsTestType);
            
                case _str_TestResultRef:
                    return new BvSelectList(TestResultRefLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestResultRef, _str_idfsTestResult);
            
                case _str_TestForDiseaseType:
                    return new BvSelectList(TestForDiseaseTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestForDiseaseType, _str_idfsTestForDiseaseType);
            
                case _str_TestStatus:
                    return new BvSelectList(TestStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestStatus, _str_idfsTestStatus);
            
                case _str_ContainerStatus:
                    return new BvSelectList(ContainerStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, ContainerStatus, _str_idfsContainerStatus);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LabSampleLogBookMyPrefListItem";

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
            var ret = base.Clone() as LabSampleLogBookMyPrefListItem;
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
            var ret = base.Clone() as LabSampleLogBookMyPrefListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public LabSampleLogBookMyPrefListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabSampleLogBookMyPrefListItem;
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
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfsSpecimenType_SampleType = idfsSpecimenType;
            var _prev_idfsTestType_TestTypeRef = idfsTestType;
            var _prev_idfsTestResult_TestResultRef = idfsTestResult;
            var _prev_idfsTestForDiseaseType_TestForDiseaseType = idfsTestForDiseaseType;
            var _prev_idfsTestStatus_TestStatus = idfsTestStatus;
            var _prev_idfsContainerStatus_ContainerStatus = idfsContainerStatus;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsSpecimenType_SampleType != idfsSpecimenType)
            {
                _SampleType = _SampleTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSpecimenType);
            }
            if (_prev_idfsTestType_TestTypeRef != idfsTestType)
            {
                _TestTypeRef = _TestTypeRefLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestType);
            }
            if (_prev_idfsTestResult_TestResultRef != idfsTestResult)
            {
                _TestResultRef = _TestResultRefLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestResult);
            }
            if (_prev_idfsTestForDiseaseType_TestForDiseaseType != idfsTestForDiseaseType)
            {
                _TestForDiseaseType = _TestForDiseaseTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestForDiseaseType);
            }
            if (_prev_idfsTestStatus_TestStatus != idfsTestStatus)
            {
                _TestStatus = _TestStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestStatus);
            }
            if (_prev_idfsContainerStatus_ContainerStatus != idfsContainerStatus)
            {
                _ContainerStatus = _ContainerStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsContainerStatus);
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

      private bool IsRIRPropChanged(string fld, LabSampleLogBookMyPrefListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabSampleLogBookMyPrefListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabSampleLogBookMyPrefListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabSampleLogBookMyPrefListItem_PropertyChanged);
        }
        private void LabSampleLogBookMyPrefListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabSampleLogBookMyPrefListItem).Changed(e.PropertyName);
            
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
            LabSampleLogBookMyPrefListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabSampleLogBookMyPrefListItem obj = this;
            
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


        public Dictionary<string, Func<LabSampleLogBookMyPrefListItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabSampleLogBookMyPrefListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabSampleLogBookMyPrefListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabSampleLogBookMyPrefListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabSampleLogBookMyPrefListItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<LabSampleLogBookMyPrefListItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LabSampleLogBookMyPrefListItem()
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
                
                LookupManager.RemoveObject("rftTestType", this);
                
                LookupManager.RemoveObject("rftTestResult", this);
                
                LookupManager.RemoveObject("rftTestForDiseaseType", this);
                
                LookupManager.RemoveObject("rftActivityStatus", this);
                
                LookupManager.RemoveObject("rftContainerStatus", this);
                
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
            
            if (lookup_object == "rftTestType")
                _getAccessor().LoadLookup_TestTypeRef(manager, this);
            
            if (lookup_object == "rftTestResult")
                _getAccessor().LoadLookup_TestResultRef(manager, this);
            
            if (lookup_object == "rftTestForDiseaseType")
                _getAccessor().LoadLookup_TestForDiseaseType(manager, this);
            
            if (lookup_object == "rftActivityStatus")
                _getAccessor().LoadLookup_TestStatus(manager, this);
            
            if (lookup_object == "rftContainerStatus")
                _getAccessor().LoadLookup_ContainerStatus(manager, this);
            
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
        public class LabSampleLogBookMyPrefListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 ID { get; set; }
        
            public Int64? idfTesting { get; set; }
        
            public Int64 idfMaterial { get; set; }
        
            public String strBarcode { get; set; }
        
            public String SpecimenType { get; set; }
        
            public DateTime? datCreationDate { get; set; }
        
            public String strSampleConditionReceivedStatus { get; set; }
        
            public String CaseID { get; set; }
        
            public String DiagnosisName { get; set; }
        
            public String TestType { get; set; }
        
            public String TestCategory { get; set; }
        
            public String Status { get; set; }
        
            public String TestResult { get; set; }
        
            public DateTime? datStartedDate { get; set; }
        
            public DateTime? datConcludedDate { get; set; }
        
        }
        public partial class LabSampleLogBookMyPrefListItemGridModelList : List<LabSampleLogBookMyPrefListItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public LabSampleLogBookMyPrefListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabSampleLogBookMyPrefListItem>, errMes);
            }
            public LabSampleLogBookMyPrefListItemGridModelList(long key, IEnumerable<LabSampleLogBookMyPrefListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<LabSampleLogBookMyPrefListItem> items);
            private void LoadGridModelList(long key, IEnumerable<LabSampleLogBookMyPrefListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strBarcode,_str_SpecimenType,_str_datCreationDate,_str_strSampleConditionReceivedStatus,_str_CaseID,_str_DiagnosisName,_str_TestType,_str_TestCategory,_str_Status,_str_TestResult,_str_datStartedDate,_str_datConcludedDate};
                    
                Hiddens = new List<string> {_str_ID,_str_idfTesting,_str_idfMaterial};
                Keys = new List<string> {_str_ID};
                Labels = new Dictionary<string, string> {{_str_strBarcode, "strLabBarcode"},{_str_SpecimenType, _str_SpecimenType},{_str_datCreationDate, "datAccession"},{_str_strSampleConditionReceivedStatus, _str_strSampleConditionReceivedStatus},{_str_CaseID, "strCaseIDSessionID"},{_str_DiagnosisName, "TestDiagnosisName"},{_str_TestType, "TestName"},{_str_TestCategory, _str_TestCategory},{_str_Status, "TestStatus"},{_str_TestResult, _str_TestResult},{_str_datStartedDate, _str_datStartedDate},{_str_datConcludedDate, _str_datConcludedDate}};
                Actions = new Dictionary<string, ActionMetaItem> {{_str_strBarcode, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "EditSample")},{_str_TestType, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "EditTest")}};
                var list = new List<LabSampleLogBookMyPrefListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new LabSampleLogBookMyPrefListItemGridModel()
                {
                    ItemKey=c.ID,idfTesting=c.idfTesting,idfMaterial=c.idfMaterial,strBarcode=c.strBarcode,SpecimenType=c.SpecimenType,datCreationDate=c.datCreationDate,strSampleConditionReceivedStatus=c.strSampleConditionReceivedStatus,CaseID=c.CaseID,DiagnosisName=c.DiagnosisName,TestType=c.TestType,TestCategory=c.TestCategory,Status=c.Status,TestResult=c.TestResult,datStartedDate=c.datStartedDate,datConcludedDate=c.datConcludedDate
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
        : DataAccessor<LabSampleLogBookMyPrefListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectList
                    
            , IObjectPost
                    
        {
            private delegate void on_action(LabSampleLogBookMyPrefListItem obj);
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
            private BaseReference.Accessor TestTypeRefAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestResultRefAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestForDiseaseTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor ContainerStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<LabSampleLogBookMyPrefListItem> SelectListT(DbManagerProxy manager
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
            
            private List<LabSampleLogBookMyPrefListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_SampleLogBook_SelectList.* from dbo.fn_SampleLogBook_SelectList(@LangID
                    ) ");
                
                if (filters.Contains(".true."))
                {
                    
                    sql.Append(" " + @"
            inner join tstLocalSamplesTestsPreferences as pref
                on pref.idfMaterial = fn_SampleLogBook_SelectList.idfMaterial
                and isnull(pref.idfTesting, 0) = isnull(fn_SampleLogBook_SelectList.idfTesting, 0)
          ");
                      
                }
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains(".true."))
                    sql.AppendFormat(" and " + new Func<string>(() => "(pref.idfUserID = " + ModelUserContext.Instance.CurrentUser.ID.ToString() + ")")());
                            
                if (filters.Contains("ID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("ID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("ID") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.ID,0) {0} @ID_{1}", filters.Operation("ID", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.idfTesting,0) {0} @idfTesting_{1}", filters.Operation("idfTesting", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.idfMaterial,0) {0} @idfMaterial_{1}", filters.Operation("idfMaterial", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfContainer"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfContainer"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfContainer") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.idfContainer,0) {0} @idfContainer_{1}", filters.Operation("idfContainer", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.idfsContainerStatus,0) {0} @idfsContainerStatus_{1}", filters.Operation("idfsContainerStatus", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.idfsDiagnosis,0) {0} @idfsDiagnosis_{1}", filters.Operation("idfsDiagnosis", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.idfsSpecimenType,0) {0} @idfsSpecimenType_{1}", filters.Operation("idfsSpecimenType", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.idfsTestType,0) {0} @idfsTestType_{1}", filters.Operation("idfsTestType", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.idfsTestForDiseaseType,0) {0} @idfsTestForDiseaseType_{1}", filters.Operation("idfsTestForDiseaseType", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.idfsTestStatus,0) {0} @idfsTestStatus_{1}", filters.Operation("idfsTestStatus", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.idfsTestResult,0) {0} @idfsTestResult_{1}", filters.Operation("idfsTestResult", i), i);
                            
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
                        
                        sql.AppendFormat("fn_SampleLogBook_SelectList.strBarcode {0} @strBarcode_{1}", filters.Operation("strBarcode", i), i);
                            
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
                        
                        sql.AppendFormat("fn_SampleLogBook_SelectList.strFieldBarcode {0} @strFieldBarcode_{1}", filters.Operation("strFieldBarcode", i), i);
                            
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
                        
                        sql.AppendFormat("fn_SampleLogBook_SelectList.SpecimenType {0} @SpecimenType_{1}", filters.Operation("SpecimenType", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_SampleLogBook_SelectList.datFieldCollectionDate, 112) {0} CONVERT(NVARCHAR(8), @datFieldCollectionDate_{1}, 112)", filters.Operation("datFieldCollectionDate", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_SampleLogBook_SelectList.datCreationDate, 112) {0} CONVERT(NVARCHAR(8), @datCreationDate_{1}, 112)", filters.Operation("datCreationDate", i), i);
                            
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
                        
                        sql.AppendFormat("fn_SampleLogBook_SelectList.CaseID {0} @CaseID_{1}", filters.Operation("CaseID", i), i);
                            
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
                        
                        sql.AppendFormat("fn_SampleLogBook_SelectList.DiagnosisName {0} @DiagnosisName_{1}", filters.Operation("DiagnosisName", i), i);
                            
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
                        
                        sql.AppendFormat("fn_SampleLogBook_SelectList.TestType {0} @TestType_{1}", filters.Operation("TestType", i), i);
                            
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
                        
                        sql.AppendFormat("fn_SampleLogBook_SelectList.TestCategory {0} @TestCategory_{1}", filters.Operation("TestCategory", i), i);
                            
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
                        
                        sql.AppendFormat("fn_SampleLogBook_SelectList.Status {0} @Status_{1}", filters.Operation("Status", i), i);
                            
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
                        
                        sql.AppendFormat("fn_SampleLogBook_SelectList.TestResult {0} @TestResult_{1}", filters.Operation("TestResult", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datStartedDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datStartedDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datStartedDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_SampleLogBook_SelectList.datStartedDate, 112) {0} CONVERT(NVARCHAR(8), @datStartedDate_{1}, 112)", filters.Operation("datStartedDate", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_SampleLogBook_SelectList.datConcludedDate, 112) {0} CONVERT(NVARCHAR(8), @datConcludedDate_{1}, 112)", filters.Operation("datConcludedDate", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.idfCase,0) {0} @idfCase_{1}", filters.Operation("idfCase", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.idfMonitoringSession,0) {0} @idfMonitoringSession_{1}", filters.Operation("idfMonitoringSession", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.idfVectorSurveillanceSession,0) {0} @idfVectorSurveillanceSession_{1}", filters.Operation("idfVectorSurveillanceSession", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsAccessionCondition"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsAccessionCondition"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsAccessionCondition") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.idfsAccessionCondition,0) {0} @idfsAccessionCondition_{1}", filters.Operation("idfsAccessionCondition", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_SampleLogBook_SelectList.idfsSpeciesType,0) {0} @idfsSpeciesType_{1}", filters.Operation("idfsSpeciesType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSampleConditionReceivedStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSampleConditionReceivedStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSampleConditionReceivedStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SampleLogBook_SelectList.strSampleConditionReceivedStatus {0} @strSampleConditionReceivedStatus_{1}", filters.Operation("strSampleConditionReceivedStatus", i), i);
                            
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
                    
                    if (filters.Contains("ID"))
                        for (int i = 0; i < filters.Count("ID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@ID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("ID", i), filters.Value("ID", i))));
                      
                    if (filters.Contains("idfTesting"))
                        for (int i = 0; i < filters.Count("idfTesting"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfTesting_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfTesting", i), filters.Value("idfTesting", i))));
                      
                    if (filters.Contains("idfMaterial"))
                        for (int i = 0; i < filters.Count("idfMaterial"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfMaterial_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfMaterial", i), filters.Value("idfMaterial", i))));
                      
                    if (filters.Contains("idfContainer"))
                        for (int i = 0; i < filters.Count("idfContainer"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfContainer_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfContainer", i), filters.Value("idfContainer", i))));
                      
                    if (filters.Contains("idfsContainerStatus"))
                        for (int i = 0; i < filters.Count("idfsContainerStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsContainerStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsContainerStatus", i), filters.Value("idfsContainerStatus", i))));
                      
                    if (filters.Contains("idfsDiagnosis"))
                        for (int i = 0; i < filters.Count("idfsDiagnosis"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosis", i), filters.Value("idfsDiagnosis", i))));
                      
                    if (filters.Contains("idfsSpecimenType"))
                        for (int i = 0; i < filters.Count("idfsSpecimenType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSpecimenType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSpecimenType", i), filters.Value("idfsSpecimenType", i))));
                      
                    if (filters.Contains("idfsTestType"))
                        for (int i = 0; i < filters.Count("idfsTestType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestType", i), filters.Value("idfsTestType", i))));
                      
                    if (filters.Contains("idfsTestForDiseaseType"))
                        for (int i = 0; i < filters.Count("idfsTestForDiseaseType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestForDiseaseType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestForDiseaseType", i), filters.Value("idfsTestForDiseaseType", i))));
                      
                    if (filters.Contains("idfsTestStatus"))
                        for (int i = 0; i < filters.Count("idfsTestStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestStatus", i), filters.Value("idfsTestStatus", i))));
                      
                    if (filters.Contains("idfsTestResult"))
                        for (int i = 0; i < filters.Count("idfsTestResult"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestResult_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestResult", i), filters.Value("idfsTestResult", i))));
                      
                    if (filters.Contains("strBarcode"))
                        for (int i = 0; i < filters.Count("strBarcode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strBarcode", i), filters.Value("strBarcode", i))));
                      
                    if (filters.Contains("strFieldBarcode"))
                        for (int i = 0; i < filters.Count("strFieldBarcode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFieldBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFieldBarcode", i), filters.Value("strFieldBarcode", i))));
                      
                    if (filters.Contains("SpecimenType"))
                        for (int i = 0; i < filters.Count("SpecimenType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@SpecimenType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("SpecimenType", i), filters.Value("SpecimenType", i))));
                      
                    if (filters.Contains("datFieldCollectionDate"))
                        for (int i = 0; i < filters.Count("datFieldCollectionDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datFieldCollectionDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datFieldCollectionDate", i), filters.Value("datFieldCollectionDate", i))));
                      
                    if (filters.Contains("datCreationDate"))
                        for (int i = 0; i < filters.Count("datCreationDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datCreationDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datCreationDate", i), filters.Value("datCreationDate", i))));
                      
                    if (filters.Contains("CaseID"))
                        for (int i = 0; i < filters.Count("CaseID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@CaseID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("CaseID", i), filters.Value("CaseID", i))));
                      
                    if (filters.Contains("DiagnosisName"))
                        for (int i = 0; i < filters.Count("DiagnosisName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@DiagnosisName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("DiagnosisName", i), filters.Value("DiagnosisName", i))));
                      
                    if (filters.Contains("TestType"))
                        for (int i = 0; i < filters.Count("TestType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@TestType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("TestType", i), filters.Value("TestType", i))));
                      
                    if (filters.Contains("TestCategory"))
                        for (int i = 0; i < filters.Count("TestCategory"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@TestCategory_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("TestCategory", i), filters.Value("TestCategory", i))));
                      
                    if (filters.Contains("Status"))
                        for (int i = 0; i < filters.Count("Status"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@Status_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("Status", i), filters.Value("Status", i))));
                      
                    if (filters.Contains("TestResult"))
                        for (int i = 0; i < filters.Count("TestResult"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@TestResult_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("TestResult", i), filters.Value("TestResult", i))));
                      
                    if (filters.Contains("datStartedDate"))
                        for (int i = 0; i < filters.Count("datStartedDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datStartedDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datStartedDate", i), filters.Value("datStartedDate", i))));
                      
                    if (filters.Contains("datConcludedDate"))
                        for (int i = 0; i < filters.Count("datConcludedDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datConcludedDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datConcludedDate", i), filters.Value("datConcludedDate", i))));
                      
                    if (filters.Contains("idfCase"))
                        for (int i = 0; i < filters.Count("idfCase"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfCase_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfCase", i), filters.Value("idfCase", i))));
                      
                    if (filters.Contains("idfMonitoringSession"))
                        for (int i = 0; i < filters.Count("idfMonitoringSession"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfMonitoringSession_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfMonitoringSession", i), filters.Value("idfMonitoringSession", i))));
                      
                    if (filters.Contains("idfVectorSurveillanceSession"))
                        for (int i = 0; i < filters.Count("idfVectorSurveillanceSession"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfVectorSurveillanceSession_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfVectorSurveillanceSession", i), filters.Value("idfVectorSurveillanceSession", i))));
                      
                    if (filters.Contains("idfsAccessionCondition"))
                        for (int i = 0; i < filters.Count("idfsAccessionCondition"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsAccessionCondition_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsAccessionCondition", i), filters.Value("idfsAccessionCondition", i))));
                      
                    if (filters.Contains("idfsSpeciesType"))
                        for (int i = 0; i < filters.Count("idfsSpeciesType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSpeciesType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSpeciesType", i), filters.Value("idfsSpeciesType", i))));
                      
                    if (filters.Contains("strSampleConditionReceivedStatus"))
                        for (int i = 0; i < filters.Count("strSampleConditionReceivedStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSampleConditionReceivedStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSampleConditionReceivedStatus", i), filters.Value("strSampleConditionReceivedStatus", i))));
                      
                    List<LabSampleLogBookMyPrefListItem> objs = manager.ExecuteList<LabSampleLogBookMyPrefListItem>();
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
        
            [SprocName("spSampleLogBook_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LabSampleLogBookMyPrefListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabSampleLogBookMyPrefListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabSampleLogBookMyPrefListItem obj = LabSampleLogBookMyPrefListItem.CreateInstance();
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
                obj.ContainerStatus = new Func<LabSampleLogBookMyPrefListItem, BaseReference>(c => 
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

            
            public LabSampleLogBookMyPrefListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public LabSampleLogBookMyPrefListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult SelectTest(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj, List<object> pars)
            {
                
                return SelectTest(manager, obj
                    );
            }
            public ActResult SelectTest(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("SelectTest"))
                    throw new PermissionException("Sample", "SelectTest");
                
                return true;
                
            }
            
            public ActResult DeleteTest(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj, List<object> pars)
            {
                
                return DeleteTest(manager, obj
                    );
            }
            public ActResult DeleteTest(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("DeleteTest"))
                    throw new PermissionException("Sample", "DeleteTest");
                
                bool ret = obj.MarkToDelete();
                if (ret)
                    ret = Accessor.Instance(m_CS).Post(manager, obj);
                return ret;
            
            }
            
            public ActResult EditSample(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj, List<object> pars)
            {
                
                return EditSample(manager, obj
                    );
            }
            public ActResult EditSample(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("EditSample"))
                    throw new PermissionException("Sample", "EditSample");
                
                return true;
                
            }
            
            public ActResult EditTest(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj, List<object> pars)
            {
                
                return EditTest(manager, obj
                    );
            }
            public ActResult EditTest(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("EditTest"))
                    throw new PermissionException("Sample", "EditTest");
                
                return true;
                
            }
            
            public ActResult MarkForDisposition(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj, List<object> pars)
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
            public ActResult MarkForDisposition(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MarkForDisposition"))
                    throw new PermissionException("Sample", "MarkForDisposition");
                
                return true;
                
            }
            
            public ActResult TransferOut(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj, List<object> pars)
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
            public ActResult TransferOut(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("TransferOut"))
                    throw new PermissionException("Sample", "TransferOut");
                
                return true;
                
            }
            
            public ActResult AliquotsDerivatives(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj, List<object> pars)
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
            public ActResult AliquotsDerivatives(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("AliquotsDerivatives"))
                    throw new PermissionException("Sample", "AliquotsDerivatives");
                
                return true;
                
            }
            
            public ActResult HumanAccessionIn(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj, List<object> pars)
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
            public ActResult HumanAccessionIn(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("HumanAccessionIn"))
                    throw new PermissionException("Sample", "HumanAccessionIn");
                
                return true;
                
            }
            
            public ActResult VetAccessionIn(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj, List<object> pars)
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
            public ActResult VetAccessionIn(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("VetAccessionIn"))
                    throw new PermissionException("Sample", "VetAccessionIn");
                
                return true;
                
            }
            
            public ActResult AsAccessionIn(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj, List<object> pars)
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
            public ActResult AsAccessionIn(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("AsAccessionIn"))
                    throw new PermissionException("Sample", "AsAccessionIn");
                
                return true;
                
            }
            
            public ActResult VsAccessionIn(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj, List<object> pars)
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
            public ActResult VsAccessionIn(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("VsAccessionIn"))
                    throw new PermissionException("Sample", "VsAccessionIn");
                
                return true;
                
            }
            
            public ActResult GroupAccessionIn(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj, List<object> pars)
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
            public ActResult GroupAccessionIn(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("GroupAccessionIn"))
                    throw new PermissionException("Sample", "GroupAccessionIn");
                
                return true;
                
            }
            
            public ActResult RemoveFromPreferences(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("id", typeof(long));
                
                return RemoveFromPreferences(manager, obj
                    , (long)pars[0]
                    );
            }
            public ActResult RemoveFromPreferences(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj
                , long id
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("RemoveFromPreferences"))
                    throw new PermissionException("Sample", "RemoveFromPreferences");
                
              manager.SetSpCommand("dbo.spLocalSamplesTestsPreference_Remove"
                , manager.Parameter("idfTestingOrMaterial", id)
                , manager.Parameter("idfUserID", (long)ModelUserContext.Instance.CurrentUser.ID)
                ).ExecuteNonQuery();
              return true;
            
            }
            
            private void _SetupChildHandlers(LabSampleLogBookMyPrefListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabSampleLogBookMyPrefListItem obj)
            {
                
            }
    
            public void LoadLookup_Diagnosis(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.All) != 0) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
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
            
            public void LoadLookup_SampleType(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj)
            {
                
                obj.SampleTypeLookup.Clear();
                
                obj.SampleTypeLookup.Add(SampleTypeAccessor.CreateNewT(manager, null));
                
                obj.SampleTypeLookup.AddRange(SampleTypeAccessor.rftSpecimenType_SelectList(manager
                    
                    )
                    .Where(c => c.idfsBaseReference != (long)SampleTypeEnum.Unknown)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSpecimenType))
                    
                    .ToList());
                
                if (obj.idfsSpecimenType != null && obj.idfsSpecimenType != 0)
                {
                    obj.SampleType = obj.SampleTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsSpecimenType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftSpecimenType", obj, SampleTypeAccessor.GetType(), "rftSpecimenType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_TestTypeRef(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj)
            {
                
                obj.TestTypeRefLookup.Clear();
                
                obj.TestTypeRefLookup.Add(TestTypeRefAccessor.CreateNewT(manager, null));
                
                obj.TestTypeRefLookup.AddRange(TestTypeRefAccessor.rftTestType_SelectList(manager
                    
                    )
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
            
            public void LoadLookup_TestResultRef(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj)
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
            
            public void LoadLookup_TestForDiseaseType(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj)
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
            
            public void LoadLookup_TestStatus(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj)
            {
                
                obj.TestStatusLookup.Clear();
                
                obj.TestStatusLookup.Add(TestStatusAccessor.CreateNewT(manager, null));
                
                obj.TestStatusLookup.AddRange(TestStatusAccessor.rftActivityStatus_SelectList(manager
                    
                    )
                    .Where(c => c.idfsBaseReference == (long)BatchStatusEnum.Completed || c.idfsBaseReference == (long)BatchStatusEnum.InProcess || c.idfsBaseReference == (long)BatchStatusEnum.Undefined || c.idfsBaseReference == (long)BatchStatusEnum.Amended)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestStatus))
                    
                    .ToList());
                
                if (obj.idfsTestStatus != null && obj.idfsTestStatus != 0)
                {
                    obj.TestStatus = obj.TestStatusLookup
                        .Where(c => c.idfsBaseReference == obj.idfsTestStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftActivityStatus", obj, TestStatusAccessor.GetType(), "rftActivityStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_ContainerStatus(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj)
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
            

            private void _LoadLookups(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj)
            {
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_SampleType(manager, obj);
                
                LoadLookup_TestTypeRef(manager, obj);
                
                LoadLookup_TestResultRef(manager, obj);
                
                LoadLookup_TestForDiseaseType(manager, obj);
                
                LoadLookup_TestStatus(manager, obj);
                
                LoadLookup_ContainerStatus(manager, obj);
                
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
                    LabSampleLogBookMyPrefListItem bo = obj as LabSampleLogBookMyPrefListItem;
                    
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoTest;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbTesting;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as LabSampleLogBookMyPrefListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.ID
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
            
            public bool ValidateCanDelete(LabSampleLogBookMyPrefListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.ID
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
                return Validate(manager, obj as LabSampleLogBookMyPrefListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabSampleLogBookMyPrefListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
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
            
            private void _SetupRequired(LabSampleLogBookMyPrefListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LabSampleLogBookMyPrefListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabSampleLogBookMyPrefListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabSampleLogBookMyPrefListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabSampleLogBookMyPrefListItemDetail"; } }
            public string HelpIdWin { get { return "lab_sample_log_book"; } }
            public string HelpIdWeb { get { return "web_lab_sample_log_book"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private LabSampleLogBookMyPrefListItem m_obj;
            internal Permissions(LabSampleLogBookMyPrefListItem obj)
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
            public static string spSelect = "fn_SampleLogBook_SelectList";
            public static string spCount = "spSampleLogBook_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spLabTest_Delete";
            public static string spCanDelete = "spLabTest_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabSampleLogBookMyPrefListItem, bool>> RequiredByField = new Dictionary<string, Func<LabSampleLogBookMyPrefListItem, bool>>();
            public static Dictionary<string, Func<LabSampleLogBookMyPrefListItem, bool>> RequiredByProperty = new Dictionary<string, Func<LabSampleLogBookMyPrefListItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_SpecimenType, 2000);
                Sizes.Add(_str_CaseID, 200);
                Sizes.Add(_str_DiagnosisName, 2000);
                Sizes.Add(_str_TestType, 2000);
                Sizes.Add(_str_TestCategory, 2000);
                Sizes.Add(_str_Status, 2000);
                Sizes.Add(_str_TestResult, 2000);
                Sizes.Add(_str_strSampleConditionReceivedStatus, 2000);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestType",
                    EditorType.Lookup,
                    false, false, 
                    "TestName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "TestTypeRefLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestResult",
                    EditorType.Lookup,
                    false, false, 
                    "TestResult",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "TestResultRefLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestStatus",
                    EditorType.Lookup,
                    false, false, 
                    "TestStatus",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "TestStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestForDiseaseType",
                    EditorType.Lookup,
                    false, false, 
                    "TestCategory",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "TestForDiseaseTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datStartedDate",
                    EditorType.Date,
                    true, false, 
                    "datStartedDate",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datConcludedDate",
                    EditorType.Date,
                    true, false, 
                    "datConcludedDate",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "CaseID",
                    EditorType.Text,
                    false, false, 
                    "strCaseIDSessionID",
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
                    "strBarcode",
                    EditorType.Text,
                    false, false, 
                    "strLabBarcode",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSpecimenType",
                    EditorType.Lookup,
                    false, false, 
                    "SpecimenType",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "SampleTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datCreationDate",
                    EditorType.Date,
                    true, true, 
                    "datAccession",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsContainerStatus",
                    EditorType.Lookup,
                    false, false, 
                    "idfsContainerStatus",
                    null, null, true, false, SearchPanelLocation.Main, false, null, "ContainerStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_ID,
                    _str_ID, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfTesting,
                    _str_idfTesting, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfMaterial,
                    _str_idfMaterial, null, false, true, null
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
                    _str_datCreationDate,
                    "datAccession", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSampleConditionReceivedStatus,
                    _str_strSampleConditionReceivedStatus, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_CaseID,
                    "strCaseIDSessionID", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DiagnosisName,
                    "TestDiagnosisName", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestType,
                    "TestName", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestCategory,
                    _str_TestCategory, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Status,
                    "TestStatus", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestResult,
                    _str_TestResult, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datStartedDate,
                    _str_datStartedDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datConcludedDate,
                    _str_datConcludedDate, null, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "SelectTest",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem,LabSampleLogBookListItem,LabSampleLogBookMyPrefListItem",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).SelectTest(manager, (LabSampleLogBookMyPrefListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleSelectTest",
                        "Select_Tests__small_",
                        /*from BvMessages*/"titleSelectTest",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      true,
                    "Test.Insert",
                    null,
                    (c, p, b) => c != null && ((long)(eidss.model.Enums.ContainerStatus.Accessioned)).Equals(c.GetValue("idfsContainerStatus")),
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "DeleteTest",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem,LabSampleLogBookListItem,LabSampleLogBookMyPrefListItem",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).DeleteTest(manager, (LabSampleLogBookMyPrefListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleDeleteTest",
                        "Delete_Remove",
                        /*from BvMessages*/"titleDeleteTest",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      true,
                    "Test.Delete",
                    null,
                    (c, p, b) => c != null && c.GetValue("idfTesting")!=null,
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "EditSample",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem,LabSampleLogBookListItem,LabSampleLogBookMyPrefListItem",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).EditSample(manager, (LabSampleLogBookMyPrefListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleEditSample",
                        "edit",
                        /*from BvMessages*/"titleEditSample",
                        /*from BvMessages*/"strViewSample_Id",
                        "View1",
                        /*from BvMessages*/"strViewSample_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      true,
                    "Sample.Select",
                    null,
                    (c, p, b) => c != null,
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "EditTest",
                    ActionTypes.Action,
                    true,
                    "LabTestListItem,LabSampleListItem,LabSampleLogBookListItem,LabSampleLogBookMyPrefListItem",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).EditTest(manager, (LabSampleLogBookMyPrefListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleEditTest",
                        "edit",
                        /*from BvMessages*/"titleEditTest",
                        /*from BvMessages*/"strViewTest_Id",
                        "View1",
                        /*from BvMessages*/"strViewTest_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      true,
                    "Test.Select",
                    null,
                    (c, p, b) => c != null && c.GetValue("idfTesting")!=null,
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
                    
                    (manager, c, pars) => Accessor.Instance(null).MarkForDisposition(manager, (LabSampleLogBookMyPrefListItem)c, pars),
                        
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
                        ActionsAppType.Win
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
                    
                    (manager, c, pars) => Accessor.Instance(null).TransferOut(manager, (LabSampleLogBookMyPrefListItem)c, pars),
                        
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
                        ActionsAppType.Win
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
                    
                    (manager, c, pars) => Accessor.Instance(null).AliquotsDerivatives(manager, (LabSampleLogBookMyPrefListItem)c, pars),
                        
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
                        ActionsAppType.Win
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
                        ActionsAlignment.Left,
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
                    
                    (manager, c, pars) => Accessor.Instance(null).HumanAccessionIn(manager, (LabSampleLogBookMyPrefListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleHumanAccessionIn",
                        "Search_Human_Case_in_Browse_Mode__small_1",
                        /*from BvMessages*/"titleHumanAccessionIn",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      true,
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
                    
                    (manager, c, pars) => Accessor.Instance(null).VetAccessionIn(manager, (LabSampleLogBookMyPrefListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleVetAccessionIn",
                        "Search_Vet_Case__small_2",
                        /*from BvMessages*/"titleVetAccessionIn",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      true,
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
                    
                    (manager, c, pars) => Accessor.Instance(null).AsAccessionIn(manager, (LabSampleLogBookMyPrefListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleASAccessionIn",
                        "Active_Surveillance_Session_small",
                        /*from BvMessages*/"titleASAccessionIn",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      true,
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
                    
                    (manager, c, pars) => Accessor.Instance(null).VsAccessionIn(manager, (LabSampleLogBookMyPrefListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleVsAccessionIn",
                        "Vector_Surveillance_Sessions_List__small__04_",
                        /*from BvMessages*/"titleVsAccessionIn",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Top,
                        ActionsAppType.Win
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
                    
                    (manager, c, pars) => Accessor.Instance(null).GroupAccessionIn(manager, (LabSampleLogBookMyPrefListItem)c, pars),
                        
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
                        ActionsAppType.Win
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
                    "RemoveFromPreferences",
                    ActionTypes.Action,
                    true,
                    "LabSampleLogBookListItem",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).RemoveFromPreferences(manager, (LabSampleLogBookMyPrefListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleRemoveFromPreferences",
                        "Delete_Remove",
                        /*from BvMessages*/"titleRemoveFromPreferences",
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
                    (c, p, b) => c != null,
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	