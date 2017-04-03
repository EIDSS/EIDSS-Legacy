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
    public abstract partial class CaseTest : 
        EditableObject<CaseTest>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfTesting), NonUpdatable, PrimaryKey]
        public abstract Int64 idfTesting { get; set; }
                
        [LocalizedDisplayName(_str_idfObservation)]
        [MapField(_str_idfObservation)]
        public abstract Int64 idfObservation { get; set; }
        protected Int64 idfObservation_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfObservation).OriginalValue; } }
        protected Int64 idfObservation_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfObservation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64? idfsFormTemplate { get; set; }
        protected Int64? idfsFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64? idfsFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTestStatus)]
        [MapField(_str_idfsTestStatus)]
        public abstract Int64 idfsTestStatus { get; set; }
        protected Int64 idfsTestStatus_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsTestStatus).OriginalValue; } }
        protected Int64 idfsTestStatus_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsTestStatus).PreviousValue; } }
                
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
                
        [LocalizedDisplayName("strLabBarcode")]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
                
        [LocalizedDisplayName("strFieldBarcodeField")]
        [MapField(_str_strFieldBarcode)]
        public abstract String strFieldBarcode { get; set; }
        protected String strFieldBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).OriginalValue; } }
        protected String strFieldBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).PreviousValue; } }
                
        [LocalizedDisplayName("strFieldBarcodeLocal")]
        [MapField(_str_strFieldBarcode2)]
        public abstract String strFieldBarcode2 { get; set; }
        protected String strFieldBarcode2_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode2).OriginalValue; } }
        protected String strFieldBarcode2_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode2).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFieldCollectionDate)]
        [MapField(_str_datFieldCollectionDate)]
        public abstract DateTime? datFieldCollectionDate { get; set; }
        protected DateTime? datFieldCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).OriginalValue; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSampleName)]
        [MapField(_str_strSampleName)]
        public abstract String strSampleName { get; set; }
        protected String strSampleName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).OriginalValue; } }
        protected String strSampleName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTestName)]
        [MapField(_str_idfsTestName)]
        public abstract Int64? idfsTestName { get; set; }
        protected Int64? idfsTestName_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestName).OriginalValue; } }
        protected Int64? idfsTestName_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_TestName)]
        [MapField(_str_TestName)]
        public abstract String TestName { get; set; }
        protected String TestName_Original { get { return ((EditableValue<String>)((dynamic)this)._testName).OriginalValue; } }
        protected String TestName_Previous { get { return ((EditableValue<String>)((dynamic)this)._testName).PreviousValue; } }
                
        [LocalizedDisplayName("TestCategory")]
        [MapField(_str_TestCategoryName)]
        public abstract String TestCategoryName { get; set; }
        protected String TestCategoryName_Original { get { return ((EditableValue<String>)((dynamic)this)._testCategoryName).OriginalValue; } }
        protected String TestCategoryName_Previous { get { return ((EditableValue<String>)((dynamic)this)._testCategoryName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strBatchCode)]
        [MapField(_str_strBatchCode)]
        public abstract String strBatchCode { get; set; }
        protected String strBatchCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBatchCode).OriginalValue; } }
        protected String strBatchCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBatchCode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datPerformedDate)]
        [MapField(_str_datPerformedDate)]
        public abstract DateTime? datPerformedDate { get; set; }
        protected DateTime? datPerformedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPerformedDate).OriginalValue; } }
        protected DateTime? datPerformedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPerformedDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datValidatedDate)]
        [MapField(_str_datValidatedDate)]
        public abstract DateTime? datValidatedDate { get; set; }
        protected DateTime? datValidatedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datValidatedDate).OriginalValue; } }
        protected DateTime? datValidatedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datValidatedDate).PreviousValue; } }
                
        [LocalizedDisplayName("TestResultObservation")]
        [MapField(_str_TestResult)]
        public abstract String TestResult { get; set; }
        protected String TestResult_Original { get { return ((EditableValue<String>)((dynamic)this)._testResult).OriginalValue; } }
        protected String TestResult_Previous { get { return ((EditableValue<String>)((dynamic)this)._testResult).PreviousValue; } }
                
        [LocalizedDisplayName(_str_TestStatus)]
        [MapField(_str_TestStatus)]
        public abstract String TestStatus { get; set; }
        protected String TestStatus_Original { get { return ((EditableValue<String>)((dynamic)this)._testStatus).OriginalValue; } }
        protected String TestStatus_Previous { get { return ((EditableValue<String>)((dynamic)this)._testStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DepartmentName)]
        [MapField(_str_DepartmentName)]
        public abstract String DepartmentName { get; set; }
        protected String DepartmentName_Original { get { return ((EditableValue<String>)((dynamic)this)._departmentName).OriginalValue; } }
        protected String DepartmentName_Previous { get { return ((EditableValue<String>)((dynamic)this)._departmentName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_AnimalName)]
        [MapField(_str_AnimalName)]
        public abstract String AnimalName { get; set; }
        protected String AnimalName_Original { get { return ((EditableValue<String>)((dynamic)this)._animalName).OriginalValue; } }
        protected String AnimalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._animalName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFarmCode)]
        [MapField(_str_strFarmCode)]
        public abstract String strFarmCode { get; set; }
        protected String strFarmCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).OriginalValue; } }
        protected String strFarmCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfFarm)]
        [MapField(_str_idfFarm)]
        public abstract Int64? idfFarm { get; set; }
        protected Int64? idfFarm_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFarm).OriginalValue; } }
        protected Int64? idfFarm_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFarm).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsDiagnosis)]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64 idfsDiagnosis { get; set; }
        protected Int64 idfsDiagnosis_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64 idfsDiagnosis_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datStartedDate)]
        [MapField(_str_datStartedDate)]
        public abstract DateTime? datStartedDate { get; set; }
        protected DateTime? datStartedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartedDate).OriginalValue; } }
        protected DateTime? datStartedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartedDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datConcludedDate)]
        [MapField(_str_datConcludedDate)]
        public abstract DateTime? datConcludedDate { get; set; }
        protected DateTime? datConcludedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datConcludedDate).OriginalValue; } }
        protected DateTime? datConcludedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datConcludedDate).PreviousValue; } }
                
        [LocalizedDisplayName("TestDiagnosis2")]
        [MapField(_str_DiagnosisName)]
        public abstract String DiagnosisName { get; set; }
        protected String DiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).OriginalValue; } }
        protected String DiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64? idfCase { get; set; }
        protected Int64? idfCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64? idfCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMaterial)]
        [MapField(_str_idfMaterial)]
        public abstract Int64 idfMaterial { get; set; }
        protected Int64 idfMaterial_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfMaterial).OriginalValue; } }
        protected Int64 idfMaterial_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfMaterial).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datAccession)]
        [MapField(_str_datAccession)]
        public abstract DateTime? datAccession { get; set; }
        protected DateTime? datAccession_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).OriginalValue; } }
        protected DateTime? datAccession_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnNonLaboratoryTest)]
        [MapField(_str_blnNonLaboratoryTest)]
        public abstract Boolean blnNonLaboratoryTest { get; set; }
        protected Boolean blnNonLaboratoryTest_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnNonLaboratoryTest).OriginalValue; } }
        protected Boolean blnNonLaboratoryTest_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnNonLaboratoryTest).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnReadOnly)]
        [MapField(_str_blnReadOnly)]
        public abstract Boolean blnReadOnly { get; set; }
        protected Boolean blnReadOnly_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnReadOnly).OriginalValue; } }
        protected Boolean blnReadOnly_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnReadOnly).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strNote)]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_idfMaterialHuman)]
        [MapField(_str_idfMaterialHuman)]
        public abstract Int64? idfMaterialHuman { get; set; }
        protected Int64? idfMaterialHuman_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMaterialHuman).OriginalValue; } }
        protected Int64? idfMaterialHuman_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMaterialHuman).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMaterialVet)]
        [MapField(_str_idfMaterialVet)]
        public abstract Int64? idfMaterialVet { get; set; }
        protected Int64? idfMaterialVet_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMaterialVet).OriginalValue; } }
        protected Int64? idfMaterialVet_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMaterialVet).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMaterialAsSession)]
        [MapField(_str_idfMaterialAsSession)]
        public abstract Int64? idfMaterialAsSession { get; set; }
        protected Int64? idfMaterialAsSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMaterialAsSession).OriginalValue; } }
        protected Int64? idfMaterialAsSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMaterialAsSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHasAmendment)]
        [MapField(_str_intHasAmendment)]
        public abstract Int32? intHasAmendment { get; set; }
        protected Int32? intHasAmendment_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intHasAmendment).OriginalValue; } }
        protected Int32? intHasAmendment_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intHasAmendment).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnExternalTest)]
        [MapField(_str_blnExternalTest)]
        public abstract Boolean? blnExternalTest { get; set; }
        protected Boolean? blnExternalTest_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnExternalTest).OriginalValue; } }
        protected Boolean? blnExternalTest_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnExternalTest).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datReceivedDate)]
        [MapField(_str_datReceivedDate)]
        public abstract DateTime? datReceivedDate { get; set; }
        protected DateTime? datReceivedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReceivedDate).OriginalValue; } }
        protected DateTime? datReceivedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReceivedDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPerformedByOffice)]
        [MapField(_str_idfPerformedByOffice)]
        public abstract Int64? idfPerformedByOffice { get; set; }
        protected Int64? idfPerformedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerformedByOffice).OriginalValue; } }
        protected Int64? idfPerformedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerformedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strContactPerson)]
        [MapField(_str_strContactPerson)]
        public abstract String strContactPerson { get; set; }
        protected String strContactPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strContactPerson).OriginalValue; } }
        protected String strContactPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strContactPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnIsMainSampleTest)]
        [MapField(_str_blnIsMainSampleTest)]
        public abstract Boolean? blnIsMainSampleTest { get; set; }
        protected Boolean? blnIsMainSampleTest_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnIsMainSampleTest).OriginalValue; } }
        protected Boolean? blnIsMainSampleTest_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnIsMainSampleTest).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<CaseTest, object> _get_func;
            internal Action<CaseTest, string> _set_func;
            internal Action<CaseTest, CaseTest, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfTesting = "idfTesting";
        internal const string _str_idfObservation = "idfObservation";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_idfsTestStatus = "idfsTestStatus";
        internal const string _str_idfsTestResult = "idfsTestResult";
        internal const string _str_idfsTestCategory = "idfsTestCategory";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_strFieldBarcode2 = "strFieldBarcode2";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_strSampleName = "strSampleName";
        internal const string _str_idfsTestName = "idfsTestName";
        internal const string _str_TestName = "TestName";
        internal const string _str_TestCategoryName = "TestCategoryName";
        internal const string _str_strBatchCode = "strBatchCode";
        internal const string _str_datPerformedDate = "datPerformedDate";
        internal const string _str_datValidatedDate = "datValidatedDate";
        internal const string _str_TestResult = "TestResult";
        internal const string _str_TestStatus = "TestStatus";
        internal const string _str_DepartmentName = "DepartmentName";
        internal const string _str_AnimalName = "AnimalName";
        internal const string _str_strFarmCode = "strFarmCode";
        internal const string _str_idfFarm = "idfFarm";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_datStartedDate = "datStartedDate";
        internal const string _str_datConcludedDate = "datConcludedDate";
        internal const string _str_DiagnosisName = "DiagnosisName";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_datAccession = "datAccession";
        internal const string _str_blnNonLaboratoryTest = "blnNonLaboratoryTest";
        internal const string _str_blnReadOnly = "blnReadOnly";
        internal const string _str_strNote = "strNote";
        internal const string _str_idfTestedByOffice = "idfTestedByOffice";
        internal const string _str_idfTestedByPerson = "idfTestedByPerson";
        internal const string _str_idfResultEnteredByOffice = "idfResultEnteredByOffice";
        internal const string _str_idfResultEnteredByPerson = "idfResultEnteredByPerson";
        internal const string _str_idfValidatedByOffice = "idfValidatedByOffice";
        internal const string _str_idfValidatedByPerson = "idfValidatedByPerson";
        internal const string _str_idfMaterialHuman = "idfMaterialHuman";
        internal const string _str_idfMaterialVet = "idfMaterialVet";
        internal const string _str_idfMaterialAsSession = "idfMaterialAsSession";
        internal const string _str_intHasAmendment = "intHasAmendment";
        internal const string _str_blnExternalTest = "blnExternalTest";
        internal const string _str_datReceivedDate = "datReceivedDate";
        internal const string _str_idfPerformedByOffice = "idfPerformedByOffice";
        internal const string _str_strContactPerson = "strContactPerson";
        internal const string _str_blnIsMainSampleTest = "blnIsMainSampleTest";
        internal const string _str_strPerformedByOffice = "strPerformedByOffice";
        internal const string _str_AsSessionSamples = "AsSessionSamples";
        internal const string _str_HumanCaseSamples = "HumanCaseSamples";
        internal const string _str_VetCaseSamples = "VetCaseSamples";
        internal const string _str_CaseTestValidations = "CaseTestValidations";
        internal const string _str_CaseDiagnosis = "CaseDiagnosis";
        internal const string _str_AsSessionDiseases = "AsSessionDiseases";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_CaseHACode = "CaseHACode";
        internal const string _str_AnimalID = "AnimalID";
        internal const string _str_AnimalIDSpecies = "AnimalIDSpecies";
        internal const string _str_Species = "Species";
        internal const string _str_TestNameRef = "TestNameRef";
        internal const string _str_TestResultRef = "TestResultRef";
        internal const string _str_TestCategory = "TestCategory";
        internal const string _str_TestStatusRef = "TestStatusRef";
        internal const string _str_HumanCaseSample = "HumanCaseSample";
        internal const string _str_VetCaseSample = "VetCaseSample";
        internal const string _str_AsSessionSample = "AsSessionSample";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_PerformedByOffice = "PerformedByOffice";
        internal const string _str_FFPresenter = "FFPresenter";
        internal const string _str_AmendmentHistory = "AmendmentHistory";
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
              _name = _str_idfsFormTemplate, _formname = _str_idfsFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsFormTemplate != newval) o.idfsFormTemplate = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, o.ObjectIdent2 + _str_idfsFormTemplate, o.ObjectIdent3 + _str_idfsFormTemplate, "Int64?", 
                    o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(),                  
                  o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTestStatus, _formname = _str_idfsTestStatus, _type = "Int64",
              _get_func = o => o.idfsTestStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsTestStatus != newval) 
                  o.TestStatusRef = o.TestStatusRefLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsTestStatus != newval) o.idfsTestStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsTestStatus != c.idfsTestStatus || o.IsRIRPropChanged(_str_idfsTestStatus, c)) 
                  m.Add(_str_idfsTestStatus, o.ObjectIdent + _str_idfsTestStatus, o.ObjectIdent2 + _str_idfsTestStatus, o.ObjectIdent3 + _str_idfsTestStatus, "Int64", 
                    o.idfsTestStatus == null ? "" : o.idfsTestStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsTestStatus), o.IsInvisible(_str_idfsTestStatus), o.IsRequired(_str_idfsTestStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTestResult, _formname = _str_idfsTestResult, _type = "Int64?",
              _get_func = o => o.idfsTestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsTestResult != newval) 
                  o.TestResultRef = o.TestResultRefLookup.FirstOrDefault(c => c.idfsReference == newval);
                if (o.idfsTestResult != newval) o.idfsTestResult = newval; },
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
                if (o.idfsTestCategory != c.idfsTestCategory || o.IsRIRPropChanged(_str_idfsTestCategory, c)) 
                  m.Add(_str_idfsTestCategory, o.ObjectIdent + _str_idfsTestCategory, o.ObjectIdent2 + _str_idfsTestCategory, o.ObjectIdent3 + _str_idfsTestCategory, "Int64?", 
                    o.idfsTestCategory == null ? "" : o.idfsTestCategory.ToString(),                  
                  o.IsReadOnly(_str_idfsTestCategory), o.IsInvisible(_str_idfsTestCategory), o.IsRequired(_str_idfsTestCategory)); 
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
              _name = _str_strFieldBarcode2, _formname = _str_strFieldBarcode2, _type = "String",
              _get_func = o => o.strFieldBarcode2,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFieldBarcode2 != newval) o.strFieldBarcode2 = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFieldBarcode2 != c.strFieldBarcode2 || o.IsRIRPropChanged(_str_strFieldBarcode2, c)) 
                  m.Add(_str_strFieldBarcode2, o.ObjectIdent + _str_strFieldBarcode2, o.ObjectIdent2 + _str_strFieldBarcode2, o.ObjectIdent3 + _str_strFieldBarcode2, "String", 
                    o.strFieldBarcode2 == null ? "" : o.strFieldBarcode2.ToString(),                  
                  o.IsReadOnly(_str_strFieldBarcode2), o.IsInvisible(_str_strFieldBarcode2), o.IsRequired(_str_strFieldBarcode2)); 
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
              _name = _str_TestCategoryName, _formname = _str_TestCategoryName, _type = "String",
              _get_func = o => o.TestCategoryName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.TestCategoryName != newval) o.TestCategoryName = newval; },
              _compare_func = (o, c, m) => {
                if (o.TestCategoryName != c.TestCategoryName || o.IsRIRPropChanged(_str_TestCategoryName, c)) 
                  m.Add(_str_TestCategoryName, o.ObjectIdent + _str_TestCategoryName, o.ObjectIdent2 + _str_TestCategoryName, o.ObjectIdent3 + _str_TestCategoryName, "String", 
                    o.TestCategoryName == null ? "" : o.TestCategoryName.ToString(),                  
                  o.IsReadOnly(_str_TestCategoryName), o.IsInvisible(_str_TestCategoryName), o.IsRequired(_str_TestCategoryName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strBatchCode, _formname = _str_strBatchCode, _type = "String",
              _get_func = o => o.strBatchCode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strBatchCode != newval) o.strBatchCode = newval; },
              _compare_func = (o, c, m) => {
                if (o.strBatchCode != c.strBatchCode || o.IsRIRPropChanged(_str_strBatchCode, c)) 
                  m.Add(_str_strBatchCode, o.ObjectIdent + _str_strBatchCode, o.ObjectIdent2 + _str_strBatchCode, o.ObjectIdent3 + _str_strBatchCode, "String", 
                    o.strBatchCode == null ? "" : o.strBatchCode.ToString(),                  
                  o.IsReadOnly(_str_strBatchCode), o.IsInvisible(_str_strBatchCode), o.IsRequired(_str_strBatchCode)); 
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
              _name = _str_datValidatedDate, _formname = _str_datValidatedDate, _type = "DateTime?",
              _get_func = o => o.datValidatedDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datValidatedDate != newval) o.datValidatedDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datValidatedDate != c.datValidatedDate || o.IsRIRPropChanged(_str_datValidatedDate, c)) 
                  m.Add(_str_datValidatedDate, o.ObjectIdent + _str_datValidatedDate, o.ObjectIdent2 + _str_datValidatedDate, o.ObjectIdent3 + _str_datValidatedDate, "DateTime?", 
                    o.datValidatedDate == null ? "" : o.datValidatedDate.ToString(),                  
                  o.IsReadOnly(_str_datValidatedDate), o.IsInvisible(_str_datValidatedDate), o.IsRequired(_str_datValidatedDate)); 
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
              _name = _str_TestStatus, _formname = _str_TestStatus, _type = "String",
              _get_func = o => o.TestStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.TestStatus != newval) o.TestStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.TestStatus != c.TestStatus || o.IsRIRPropChanged(_str_TestStatus, c)) 
                  m.Add(_str_TestStatus, o.ObjectIdent + _str_TestStatus, o.ObjectIdent2 + _str_TestStatus, o.ObjectIdent3 + _str_TestStatus, "String", 
                    o.TestStatus == null ? "" : o.TestStatus.ToString(),                  
                  o.IsReadOnly(_str_TestStatus), o.IsInvisible(_str_TestStatus), o.IsRequired(_str_TestStatus)); 
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
              _name = _str_strFarmCode, _formname = _str_strFarmCode, _type = "String",
              _get_func = o => o.strFarmCode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFarmCode != newval) o.strFarmCode = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFarmCode != c.strFarmCode || o.IsRIRPropChanged(_str_strFarmCode, c)) 
                  m.Add(_str_strFarmCode, o.ObjectIdent + _str_strFarmCode, o.ObjectIdent2 + _str_strFarmCode, o.ObjectIdent3 + _str_strFarmCode, "String", 
                    o.strFarmCode == null ? "" : o.strFarmCode.ToString(),                  
                  o.IsReadOnly(_str_strFarmCode), o.IsInvisible(_str_strFarmCode), o.IsRequired(_str_strFarmCode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfFarm, _formname = _str_idfFarm, _type = "Int64?",
              _get_func = o => o.idfFarm,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfFarm != newval) o.idfFarm = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfFarm != c.idfFarm || o.IsRIRPropChanged(_str_idfFarm, c)) 
                  m.Add(_str_idfFarm, o.ObjectIdent + _str_idfFarm, o.ObjectIdent2 + _str_idfFarm, o.ObjectIdent3 + _str_idfFarm, "Int64?", 
                    o.idfFarm == null ? "" : o.idfFarm.ToString(),                  
                  o.IsReadOnly(_str_idfFarm), o.IsInvisible(_str_idfFarm), o.IsRequired(_str_idfFarm)); 
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
              _name = _str_datStartedDate, _formname = _str_datStartedDate, _type = "DateTime?",
              _get_func = o => o.datStartedDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datStartedDate != newval) o.datStartedDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datStartedDate != c.datStartedDate || o.IsRIRPropChanged(_str_datStartedDate, c)) 
                  m.Add(_str_datStartedDate, o.ObjectIdent + _str_datStartedDate, o.ObjectIdent2 + _str_datStartedDate, o.ObjectIdent3 + _str_datStartedDate, "DateTime?", 
                    o.datStartedDate == null ? "" : o.datStartedDate.ToString(),                  
                  o.IsReadOnly(_str_datStartedDate), o.IsInvisible(_str_datStartedDate), o.IsRequired(_str_datStartedDate)); 
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
              _name = _str_blnNonLaboratoryTest, _formname = _str_blnNonLaboratoryTest, _type = "Boolean",
              _get_func = o => o.blnNonLaboratoryTest,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnNonLaboratoryTest != newval) o.blnNonLaboratoryTest = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnNonLaboratoryTest != c.blnNonLaboratoryTest || o.IsRIRPropChanged(_str_blnNonLaboratoryTest, c)) 
                  m.Add(_str_blnNonLaboratoryTest, o.ObjectIdent + _str_blnNonLaboratoryTest, o.ObjectIdent2 + _str_blnNonLaboratoryTest, o.ObjectIdent3 + _str_blnNonLaboratoryTest, "Boolean", 
                    o.blnNonLaboratoryTest == null ? "" : o.blnNonLaboratoryTest.ToString(),                  
                  o.IsReadOnly(_str_blnNonLaboratoryTest), o.IsInvisible(_str_blnNonLaboratoryTest), o.IsRequired(_str_blnNonLaboratoryTest)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnReadOnly, _formname = _str_blnReadOnly, _type = "Boolean",
              _get_func = o => o.blnReadOnly,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnReadOnly != newval) o.blnReadOnly = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnReadOnly != c.blnReadOnly || o.IsRIRPropChanged(_str_blnReadOnly, c)) 
                  m.Add(_str_blnReadOnly, o.ObjectIdent + _str_blnReadOnly, o.ObjectIdent2 + _str_blnReadOnly, o.ObjectIdent3 + _str_blnReadOnly, "Boolean", 
                    o.blnReadOnly == null ? "" : o.blnReadOnly.ToString(),                  
                  o.IsReadOnly(_str_blnReadOnly), o.IsInvisible(_str_blnReadOnly), o.IsRequired(_str_blnReadOnly)); 
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
              _name = _str_idfTestedByOffice, _formname = _str_idfTestedByOffice, _type = "Int64?",
              _get_func = o => o.idfTestedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfTestedByOffice != newval) o.idfTestedByOffice = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfTestedByOffice != c.idfTestedByOffice || o.IsRIRPropChanged(_str_idfTestedByOffice, c)) 
                  m.Add(_str_idfTestedByOffice, o.ObjectIdent + _str_idfTestedByOffice, o.ObjectIdent2 + _str_idfTestedByOffice, o.ObjectIdent3 + _str_idfTestedByOffice, "Int64?", 
                    o.idfTestedByOffice == null ? "" : o.idfTestedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfTestedByOffice), o.IsInvisible(_str_idfTestedByOffice), o.IsRequired(_str_idfTestedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfTestedByPerson, _formname = _str_idfTestedByPerson, _type = "Int64?",
              _get_func = o => o.idfTestedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfTestedByPerson != newval) o.idfTestedByPerson = newval; },
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
                if (o.idfValidatedByOffice != c.idfValidatedByOffice || o.IsRIRPropChanged(_str_idfValidatedByOffice, c)) 
                  m.Add(_str_idfValidatedByOffice, o.ObjectIdent + _str_idfValidatedByOffice, o.ObjectIdent2 + _str_idfValidatedByOffice, o.ObjectIdent3 + _str_idfValidatedByOffice, "Int64?", 
                    o.idfValidatedByOffice == null ? "" : o.idfValidatedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfValidatedByOffice), o.IsInvisible(_str_idfValidatedByOffice), o.IsRequired(_str_idfValidatedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfValidatedByPerson, _formname = _str_idfValidatedByPerson, _type = "Int64?",
              _get_func = o => o.idfValidatedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfValidatedByPerson != newval) o.idfValidatedByPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfValidatedByPerson != c.idfValidatedByPerson || o.IsRIRPropChanged(_str_idfValidatedByPerson, c)) 
                  m.Add(_str_idfValidatedByPerson, o.ObjectIdent + _str_idfValidatedByPerson, o.ObjectIdent2 + _str_idfValidatedByPerson, o.ObjectIdent3 + _str_idfValidatedByPerson, "Int64?", 
                    o.idfValidatedByPerson == null ? "" : o.idfValidatedByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfValidatedByPerson), o.IsInvisible(_str_idfValidatedByPerson), o.IsRequired(_str_idfValidatedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfMaterialHuman, _formname = _str_idfMaterialHuman, _type = "Int64?",
              _get_func = o => o.idfMaterialHuman,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfMaterialHuman != newval) 
                  o.HumanCaseSample = o.HumanCaseSampleLookup.FirstOrDefault(c => c.idfMaterial == newval);
                if (o.idfMaterialHuman != newval) o.idfMaterialHuman = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfMaterialHuman != c.idfMaterialHuman || o.IsRIRPropChanged(_str_idfMaterialHuman, c)) 
                  m.Add(_str_idfMaterialHuman, o.ObjectIdent + _str_idfMaterialHuman, o.ObjectIdent2 + _str_idfMaterialHuman, o.ObjectIdent3 + _str_idfMaterialHuman, "Int64?", 
                    o.idfMaterialHuman == null ? "" : o.idfMaterialHuman.ToString(),                  
                  o.IsReadOnly(_str_idfMaterialHuman), o.IsInvisible(_str_idfMaterialHuman), o.IsRequired(_str_idfMaterialHuman)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfMaterialVet, _formname = _str_idfMaterialVet, _type = "Int64?",
              _get_func = o => o.idfMaterialVet,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfMaterialVet != newval) 
                  o.VetCaseSample = o.VetCaseSampleLookup.FirstOrDefault(c => c.idfMaterial == newval);
                if (o.idfMaterialVet != newval) o.idfMaterialVet = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfMaterialVet != c.idfMaterialVet || o.IsRIRPropChanged(_str_idfMaterialVet, c)) 
                  m.Add(_str_idfMaterialVet, o.ObjectIdent + _str_idfMaterialVet, o.ObjectIdent2 + _str_idfMaterialVet, o.ObjectIdent3 + _str_idfMaterialVet, "Int64?", 
                    o.idfMaterialVet == null ? "" : o.idfMaterialVet.ToString(),                  
                  o.IsReadOnly(_str_idfMaterialVet), o.IsInvisible(_str_idfMaterialVet), o.IsRequired(_str_idfMaterialVet)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfMaterialAsSession, _formname = _str_idfMaterialAsSession, _type = "Int64?",
              _get_func = o => o.idfMaterialAsSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfMaterialAsSession != newval) 
                  o.AsSessionSample = o.AsSessionSampleLookup.FirstOrDefault(c => c.idfMaterial == newval);
                if (o.idfMaterialAsSession != newval) o.idfMaterialAsSession = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfMaterialAsSession != c.idfMaterialAsSession || o.IsRIRPropChanged(_str_idfMaterialAsSession, c)) 
                  m.Add(_str_idfMaterialAsSession, o.ObjectIdent + _str_idfMaterialAsSession, o.ObjectIdent2 + _str_idfMaterialAsSession, o.ObjectIdent3 + _str_idfMaterialAsSession, "Int64?", 
                    o.idfMaterialAsSession == null ? "" : o.idfMaterialAsSession.ToString(),                  
                  o.IsReadOnly(_str_idfMaterialAsSession), o.IsInvisible(_str_idfMaterialAsSession), o.IsRequired(_str_idfMaterialAsSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intHasAmendment, _formname = _str_intHasAmendment, _type = "Int32?",
              _get_func = o => o.intHasAmendment,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intHasAmendment != newval) o.intHasAmendment = newval; },
              _compare_func = (o, c, m) => {
                if (o.intHasAmendment != c.intHasAmendment || o.IsRIRPropChanged(_str_intHasAmendment, c)) 
                  m.Add(_str_intHasAmendment, o.ObjectIdent + _str_intHasAmendment, o.ObjectIdent2 + _str_intHasAmendment, o.ObjectIdent3 + _str_intHasAmendment, "Int32?", 
                    o.intHasAmendment == null ? "" : o.intHasAmendment.ToString(),                  
                  o.IsReadOnly(_str_intHasAmendment), o.IsInvisible(_str_intHasAmendment), o.IsRequired(_str_intHasAmendment)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnExternalTest, _formname = _str_blnExternalTest, _type = "Boolean?",
              _get_func = o => o.blnExternalTest,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnExternalTest != newval) o.blnExternalTest = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnExternalTest != c.blnExternalTest || o.IsRIRPropChanged(_str_blnExternalTest, c)) 
                  m.Add(_str_blnExternalTest, o.ObjectIdent + _str_blnExternalTest, o.ObjectIdent2 + _str_blnExternalTest, o.ObjectIdent3 + _str_blnExternalTest, "Boolean?", 
                    o.blnExternalTest == null ? "" : o.blnExternalTest.ToString(),                  
                  o.IsReadOnly(_str_blnExternalTest), o.IsInvisible(_str_blnExternalTest), o.IsRequired(_str_blnExternalTest)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datReceivedDate, _formname = _str_datReceivedDate, _type = "DateTime?",
              _get_func = o => o.datReceivedDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datReceivedDate != newval) o.datReceivedDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datReceivedDate != c.datReceivedDate || o.IsRIRPropChanged(_str_datReceivedDate, c)) 
                  m.Add(_str_datReceivedDate, o.ObjectIdent + _str_datReceivedDate, o.ObjectIdent2 + _str_datReceivedDate, o.ObjectIdent3 + _str_datReceivedDate, "DateTime?", 
                    o.datReceivedDate == null ? "" : o.datReceivedDate.ToString(),                  
                  o.IsReadOnly(_str_datReceivedDate), o.IsInvisible(_str_datReceivedDate), o.IsRequired(_str_datReceivedDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfPerformedByOffice, _formname = _str_idfPerformedByOffice, _type = "Int64?",
              _get_func = o => o.idfPerformedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfPerformedByOffice != newval) 
                  o.PerformedByOffice = o.PerformedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfPerformedByOffice != newval) o.idfPerformedByOffice = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfPerformedByOffice != c.idfPerformedByOffice || o.IsRIRPropChanged(_str_idfPerformedByOffice, c)) 
                  m.Add(_str_idfPerformedByOffice, o.ObjectIdent + _str_idfPerformedByOffice, o.ObjectIdent2 + _str_idfPerformedByOffice, o.ObjectIdent3 + _str_idfPerformedByOffice, "Int64?", 
                    o.idfPerformedByOffice == null ? "" : o.idfPerformedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfPerformedByOffice), o.IsInvisible(_str_idfPerformedByOffice), o.IsRequired(_str_idfPerformedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strContactPerson, _formname = _str_strContactPerson, _type = "String",
              _get_func = o => o.strContactPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strContactPerson != newval) o.strContactPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.strContactPerson != c.strContactPerson || o.IsRIRPropChanged(_str_strContactPerson, c)) 
                  m.Add(_str_strContactPerson, o.ObjectIdent + _str_strContactPerson, o.ObjectIdent2 + _str_strContactPerson, o.ObjectIdent3 + _str_strContactPerson, "String", 
                    o.strContactPerson == null ? "" : o.strContactPerson.ToString(),                  
                  o.IsReadOnly(_str_strContactPerson), o.IsInvisible(_str_strContactPerson), o.IsRequired(_str_strContactPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnIsMainSampleTest, _formname = _str_blnIsMainSampleTest, _type = "Boolean?",
              _get_func = o => o.blnIsMainSampleTest,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnIsMainSampleTest != newval) o.blnIsMainSampleTest = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnIsMainSampleTest != c.blnIsMainSampleTest || o.IsRIRPropChanged(_str_blnIsMainSampleTest, c)) 
                  m.Add(_str_blnIsMainSampleTest, o.ObjectIdent + _str_blnIsMainSampleTest, o.ObjectIdent2 + _str_blnIsMainSampleTest, o.ObjectIdent3 + _str_blnIsMainSampleTest, "Boolean?", 
                    o.blnIsMainSampleTest == null ? "" : o.blnIsMainSampleTest.ToString(),                  
                  o.IsReadOnly(_str_blnIsMainSampleTest), o.IsInvisible(_str_blnIsMainSampleTest), o.IsRequired(_str_blnIsMainSampleTest)); 
                  }
              }, 
        
            new field_info {
              _name = _str_strPerformedByOffice, _formname = _str_strPerformedByOffice, _type = "string",
              _get_func = o => o.strPerformedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPerformedByOffice != newval) o.strPerformedByOffice = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.strPerformedByOffice != c.strPerformedByOffice || o.IsRIRPropChanged(_str_strPerformedByOffice, c)) {
                  m.Add(_str_strPerformedByOffice, o.ObjectIdent + _str_strPerformedByOffice, o.ObjectIdent2 + _str_strPerformedByOffice, o.ObjectIdent3 + _str_strPerformedByOffice,  "string", 
                    o.strPerformedByOffice == null ? "" : o.strPerformedByOffice.ToString(),                  
                    o.IsReadOnly(_str_strPerformedByOffice), o.IsInvisible(_str_strPerformedByOffice), o.IsRequired(_str_strPerformedByOffice));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_AsSessionSamples, _formname = _str_AsSessionSamples, _type = "List<AsSessionAnimalSample>",
              _get_func = o => o.AsSessionSamples,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_HumanCaseSamples, _formname = _str_HumanCaseSamples, _type = "EditableList<HumanCaseSample>",
              _get_func = o => o.HumanCaseSamples,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_VetCaseSamples, _formname = _str_VetCaseSamples, _type = "EditableList<VetCaseSample>",
              _get_func = o => o.VetCaseSamples,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_CaseTestValidations, _formname = _str_CaseTestValidations, _type = "EditableList<CaseTestValidation>",
              _get_func = o => o.CaseTestValidations,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_CaseDiagnosis, _formname = _str_CaseDiagnosis, _type = "List<DiagnosisLookup>",
              _get_func = o => o.CaseDiagnosis,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_AsSessionDiseases, _formname = _str_AsSessionDiseases, _type = "EditableList<AsSessionDisease>",
              _get_func = o => o.AsSessionDiseases,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_CaseObjectIdent, _formname = _str_CaseObjectIdent, _type = "string",
              _get_func = o => o.CaseObjectIdent,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.CaseObjectIdent != c.CaseObjectIdent || o.IsRIRPropChanged(_str_CaseObjectIdent, c)) {
                  m.Add(_str_CaseObjectIdent, o.ObjectIdent + _str_CaseObjectIdent, o.ObjectIdent2 + _str_CaseObjectIdent, o.ObjectIdent3 + _str_CaseObjectIdent, "string", o.CaseObjectIdent == null ? "" : o.CaseObjectIdent.ToString(), o.IsReadOnly(_str_CaseObjectIdent), o.IsInvisible(_str_CaseObjectIdent), o.IsRequired(_str_CaseObjectIdent));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_CaseHACode, _formname = _str_CaseHACode, _type = "int?",
              _get_func = o => o.CaseHACode,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.CaseHACode != c.CaseHACode || o.IsRIRPropChanged(_str_CaseHACode, c)) {
                  m.Add(_str_CaseHACode, o.ObjectIdent + _str_CaseHACode, o.ObjectIdent2 + _str_CaseHACode, o.ObjectIdent3 + _str_CaseHACode, "int?", o.CaseHACode == null ? "" : o.CaseHACode.ToString(), o.IsReadOnly(_str_CaseHACode), o.IsInvisible(_str_CaseHACode), o.IsRequired(_str_CaseHACode));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_AnimalID, _formname = _str_AnimalID, _type = "string",
              _get_func = o => o.AnimalID,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.AnimalID != c.AnimalID || o.IsRIRPropChanged(_str_AnimalID, c)) {
                  m.Add(_str_AnimalID, o.ObjectIdent + _str_AnimalID, o.ObjectIdent2 + _str_AnimalID, o.ObjectIdent3 + _str_AnimalID, "string", o.AnimalID == null ? "" : o.AnimalID.ToString(), o.IsReadOnly(_str_AnimalID), o.IsInvisible(_str_AnimalID), o.IsRequired(_str_AnimalID));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_AnimalIDSpecies, _formname = _str_AnimalIDSpecies, _type = "string",
              _get_func = o => o.AnimalIDSpecies,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.AnimalIDSpecies != c.AnimalIDSpecies || o.IsRIRPropChanged(_str_AnimalIDSpecies, c)) {
                  m.Add(_str_AnimalIDSpecies, o.ObjectIdent + _str_AnimalIDSpecies, o.ObjectIdent2 + _str_AnimalIDSpecies, o.ObjectIdent3 + _str_AnimalIDSpecies, "string", o.AnimalIDSpecies == null ? "" : o.AnimalIDSpecies.ToString(), o.IsReadOnly(_str_AnimalIDSpecies), o.IsInvisible(_str_AnimalIDSpecies), o.IsRequired(_str_AnimalIDSpecies));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Species, _formname = _str_Species, _type = "string",
              _get_func = o => o.Species,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.Species != c.Species || o.IsRIRPropChanged(_str_Species, c)) {
                  m.Add(_str_Species, o.ObjectIdent + _str_Species, o.ObjectIdent2 + _str_Species, o.ObjectIdent3 + _str_Species, "string", o.Species == null ? "" : o.Species.ToString(), o.IsReadOnly(_str_Species), o.IsInvisible(_str_Species), o.IsRequired(_str_Species));
                  }
                
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
              _name = _str_TestResultRef, _formname = _str_TestResultRef, _type = "Lookup",
              _get_func = o => { if (o.TestResultRef == null) return null; return o.TestResultRef.idfsReference; },
              _set_func = (o, val) => { o.TestResultRef = o.TestResultRefLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
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
        
            new field_info {
              _name = _str_TestCategory, _formname = _str_TestCategory, _type = "Lookup",
              _get_func = o => { if (o.TestCategory == null) return null; return o.TestCategory.idfsBaseReference; },
              _set_func = (o, val) => { o.TestCategory = o.TestCategoryLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestCategory != c.idfsTestCategory || o.IsRIRPropChanged(_str_TestCategory, c)) {
                  m.Add(_str_TestCategory, o.ObjectIdent + _str_TestCategory, o.ObjectIdent2 + _str_TestCategory, o.ObjectIdent3 + _str_TestCategory, "Lookup", o.idfsTestCategory == null ? "" : o.idfsTestCategory.ToString(), o.IsReadOnly(_str_TestCategory), o.IsInvisible(_str_TestCategory), o.IsRequired(_str_TestCategory)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestCategory + "Lookup", _formname = _str_TestCategory + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestCategoryLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestStatusRef, _formname = _str_TestStatusRef, _type = "Lookup",
              _get_func = o => { if (o.TestStatusRef == null) return null; return o.TestStatusRef.idfsBaseReference; },
              _set_func = (o, val) => { o.TestStatusRef = o.TestStatusRefLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestStatus != c.idfsTestStatus || o.IsRIRPropChanged(_str_TestStatusRef, c)) {
                  m.Add(_str_TestStatusRef, o.ObjectIdent + _str_TestStatusRef, o.ObjectIdent2 + _str_TestStatusRef, o.ObjectIdent3 + _str_TestStatusRef, "Lookup", o.idfsTestStatus == null ? "" : o.idfsTestStatus.ToString(), o.IsReadOnly(_str_TestStatusRef), o.IsInvisible(_str_TestStatusRef), o.IsRequired(_str_TestStatusRef)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestStatusRef + "Lookup", _formname = _str_TestStatusRef + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestStatusRefLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_HumanCaseSample, _formname = _str_HumanCaseSample, _type = "Lookup",
              _get_func = o => { if (o.HumanCaseSample == null) return null; return o.HumanCaseSample.idfMaterial; },
              _set_func = (o, val) => { o.HumanCaseSample = o.HumanCaseSampleLookup.Where(c => c.idfMaterial.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfMaterialHuman != c.idfMaterialHuman || o.IsRIRPropChanged(_str_HumanCaseSample, c)) {
                  m.Add(_str_HumanCaseSample, o.ObjectIdent + _str_HumanCaseSample, o.ObjectIdent2 + _str_HumanCaseSample, o.ObjectIdent3 + _str_HumanCaseSample, "Lookup", o.idfMaterialHuman == null ? "" : o.idfMaterialHuman.ToString(), o.IsReadOnly(_str_HumanCaseSample), o.IsInvisible(_str_HumanCaseSample), o.IsRequired(_str_HumanCaseSample)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_HumanCaseSample + "Lookup", _formname = _str_HumanCaseSample + "Lookup", _type = "LookupContent",
              _get_func = o => o.HumanCaseSampleLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_VetCaseSample, _formname = _str_VetCaseSample, _type = "Lookup",
              _get_func = o => { if (o.VetCaseSample == null) return null; return o.VetCaseSample.idfMaterial; },
              _set_func = (o, val) => { o.VetCaseSample = o.VetCaseSampleLookup.Where(c => c.idfMaterial.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfMaterialVet != c.idfMaterialVet || o.IsRIRPropChanged(_str_VetCaseSample, c)) {
                  m.Add(_str_VetCaseSample, o.ObjectIdent + _str_VetCaseSample, o.ObjectIdent2 + _str_VetCaseSample, o.ObjectIdent3 + _str_VetCaseSample, "Lookup", o.idfMaterialVet == null ? "" : o.idfMaterialVet.ToString(), o.IsReadOnly(_str_VetCaseSample), o.IsInvisible(_str_VetCaseSample), o.IsRequired(_str_VetCaseSample)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_VetCaseSample + "Lookup", _formname = _str_VetCaseSample + "Lookup", _type = "LookupContent",
              _get_func = o => o.VetCaseSampleLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_AsSessionSample, _formname = _str_AsSessionSample, _type = "Lookup",
              _get_func = o => { if (o.AsSessionSample == null) return null; return o.AsSessionSample.idfMaterial; },
              _set_func = (o, val) => { o.AsSessionSample = o.AsSessionSampleLookup.Where(c => c.idfMaterial.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfMaterialAsSession != c.idfMaterialAsSession || o.IsRIRPropChanged(_str_AsSessionSample, c)) {
                  m.Add(_str_AsSessionSample, o.ObjectIdent + _str_AsSessionSample, o.ObjectIdent2 + _str_AsSessionSample, o.ObjectIdent3 + _str_AsSessionSample, "Lookup", o.idfMaterialAsSession == null ? "" : o.idfMaterialAsSession.ToString(), o.IsReadOnly(_str_AsSessionSample), o.IsInvisible(_str_AsSessionSample), o.IsRequired(_str_AsSessionSample)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_AsSessionSample + "Lookup", _formname = _str_AsSessionSample + "Lookup", _type = "LookupContent",
              _get_func = o => o.AsSessionSampleLookup,
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
              _name = _str_PerformedByOffice, _formname = _str_PerformedByOffice, _type = "Lookup",
              _get_func = o => { if (o.PerformedByOffice == null) return null; return o.PerformedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.PerformedByOffice = o.PerformedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfPerformedByOffice != c.idfPerformedByOffice || o.IsRIRPropChanged(_str_PerformedByOffice, c)) {
                  m.Add(_str_PerformedByOffice, o.ObjectIdent + _str_PerformedByOffice, o.ObjectIdent2 + _str_PerformedByOffice, o.ObjectIdent3 + _str_PerformedByOffice, "Lookup", o.idfPerformedByOffice == null ? "" : o.idfPerformedByOffice.ToString(), o.IsReadOnly(_str_PerformedByOffice), o.IsInvisible(_str_PerformedByOffice), o.IsRequired(_str_PerformedByOffice)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_PerformedByOffice + "Lookup", _formname = _str_PerformedByOffice + "Lookup", _type = "LookupContent",
              _get_func = o => o.PerformedByOfficeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_AmendmentHistory, _formname = _str_AmendmentHistory, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.AmendmentHistory.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.AmendmentHistory.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.AmendmentHistory.Count != c.AmendmentHistory.Count || o.IsReadOnly(_str_AmendmentHistory) != c.IsReadOnly(_str_AmendmentHistory) || o.IsInvisible(_str_AmendmentHistory) != c.IsInvisible(_str_AmendmentHistory) || o.IsRequired(_str_AmendmentHistory) != c._isRequired(o.m_isRequired, _str_AmendmentHistory)) {
                  m.Add(_str_AmendmentHistory, o.ObjectIdent + _str_AmendmentHistory, o.ObjectIdent2 + _str_AmendmentHistory, o.ObjectIdent3 + _str_AmendmentHistory, "Child", o.idfTesting == null ? "" : o.idfTesting.ToString(), o.IsReadOnly(_str_AmendmentHistory), o.IsInvisible(_str_AmendmentHistory), o.IsRequired(_str_AmendmentHistory)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_FFPresenter, _formname = _str_FFPresenter, _type = "Relation",
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
            CaseTest obj = (CaseTest)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
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
                    
        [LocalizedDisplayName(_str_AmendmentHistory)]
        [Relation(typeof(LabTestAmendment), eidss.model.Schema.LabTestAmendment._str_idfTesting, _str_idfTesting)]
        public EditableList<LabTestAmendment> AmendmentHistory
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
        protected EditableList<LabTestAmendment> _AmendmentHistory = new EditableList<LabTestAmendment>();
                    
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
            
        [LocalizedDisplayName(_str_TestStatusRef)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestStatus)]
        public BaseReference TestStatusRef
        {
            get { return _TestStatusRef == null ? null : ((long)_TestStatusRef.Key == 0 ? null : _TestStatusRef); }
            set 
            { 
                var oldVal = _TestStatusRef;
                _TestStatusRef = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestStatusRef != oldVal)
                {
                    if (idfsTestStatus != (_TestStatusRef == null
                            ? new Int64()
                            : (Int64)_TestStatusRef.idfsBaseReference))
                        idfsTestStatus = _TestStatusRef == null 
                            ? new Int64()
                            : (Int64)_TestStatusRef.idfsBaseReference; 
                    OnPropertyChanged(_str_TestStatusRef); 
                }
            }
        }
        private BaseReference _TestStatusRef;

        
        public BaseReferenceList TestStatusRefLookup
        {
            get { return _TestStatusRefLookup; }
        }
        private BaseReferenceList _TestStatusRefLookup = new BaseReferenceList("rftTestStatus");
            
        [LocalizedDisplayName(_str_HumanCaseSample)]
        [Relation(typeof(HumanCaseSample), eidss.model.Schema.HumanCaseSample._str_idfMaterial, _str_idfMaterialHuman)]
        public HumanCaseSample HumanCaseSample
        {
            get { return _HumanCaseSample == null ? null : ((long)_HumanCaseSample.Key == 0 ? null : _HumanCaseSample); }
            set 
            { 
                var oldVal = _HumanCaseSample;
                _HumanCaseSample = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_HumanCaseSample != oldVal)
                {
                    if (idfMaterialHuman != (_HumanCaseSample == null
                            ? new Int64?()
                            : (Int64?)_HumanCaseSample.idfMaterial))
                        idfMaterialHuman = _HumanCaseSample == null 
                            ? new Int64?()
                            : (Int64?)_HumanCaseSample.idfMaterial; 
                    OnPropertyChanged(_str_HumanCaseSample); 
                }
            }
        }
        private HumanCaseSample _HumanCaseSample;

        
        private HumanCaseSample _emptyHumanCaseSample;
        
        public List<HumanCaseSample> HumanCaseSampleLookup
        {
            get 
            { 
                
                if (_emptyHumanCaseSample == null)
                    using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                        _emptyHumanCaseSample = eidss.model.Schema.HumanCaseSample.Accessor.Instance(null).CreateNewT(manager, this.Parent ?? this);
                
                var ret = new List<HumanCaseSample>();
                
                ret.Add(_emptyHumanCaseSample);
                
              
                if (HumanCaseSamples != null)
                {
                    
                    ret.AddRange(HumanCaseSamples
                        .Where(c => !c.IsMarkedToDelete)
                            
                    );
                }
                return ret;
            }
        }
            
        [LocalizedDisplayName(_str_VetCaseSample)]
        [Relation(typeof(VetCaseSample), eidss.model.Schema.VetCaseSample._str_idfMaterial, _str_idfMaterialVet)]
        public VetCaseSample VetCaseSample
        {
            get { return _VetCaseSample == null ? null : ((long)_VetCaseSample.Key == 0 ? null : _VetCaseSample); }
            set 
            { 
                var oldVal = _VetCaseSample;
                _VetCaseSample = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_VetCaseSample != oldVal)
                {
                    if (idfMaterialVet != (_VetCaseSample == null
                            ? new Int64?()
                            : (Int64?)_VetCaseSample.idfMaterial))
                        idfMaterialVet = _VetCaseSample == null 
                            ? new Int64?()
                            : (Int64?)_VetCaseSample.idfMaterial; 
                    OnPropertyChanged(_str_VetCaseSample); 
                }
            }
        }
        private VetCaseSample _VetCaseSample;

        
        private VetCaseSample _emptyVetCaseSample;
        
        public List<VetCaseSample> VetCaseSampleLookup
        {
            get 
            { 
                
                if (_emptyVetCaseSample == null)
                    using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                        _emptyVetCaseSample = eidss.model.Schema.VetCaseSample.Accessor.Instance(null).CreateNewT(manager, this.Parent ?? this);
                
                var ret = new List<VetCaseSample>();
                
                ret.Add(_emptyVetCaseSample);
                
              
                if (VetCaseSamples != null)
                {
                    
                    ret.AddRange(VetCaseSamples
                        .Where(c => !c.IsMarkedToDelete)
                            
                    );
                }
                return ret;
            }
        }
            
        [LocalizedDisplayName(_str_AsSessionSample)]
        [Relation(typeof(AsSessionAnimalSample), eidss.model.Schema.AsSessionAnimalSample._str_idfMaterial, _str_idfMaterialAsSession)]
        public AsSessionAnimalSample AsSessionSample
        {
            get { return _AsSessionSample; }
            set 
            { 
                var oldVal = _AsSessionSample;
                _AsSessionSample = value;
                if (_AsSessionSample != oldVal)
                {
                    if (idfMaterialAsSession != (_AsSessionSample == null
                            ? new Int64?()
                            : (Int64?)_AsSessionSample.idfMaterial))
                        idfMaterialAsSession = _AsSessionSample == null 
                            ? new Int64?()
                            : (Int64?)_AsSessionSample.idfMaterial; 
                    OnPropertyChanged(_str_AsSessionSample); 
                }
            }
        }
        private AsSessionAnimalSample _AsSessionSample;

        
        public List<AsSessionAnimalSample> AsSessionSampleLookup
        {
            get 
            { 
                
                var ret = new List<AsSessionAnimalSample>();
                
              
                if (AsSessionSamples != null)
                {
                    
                    ret.AddRange(AsSessionSamples
                    );
                }
                return ret;
            }
        }
            
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

        
        private DiagnosisLookup _emptyDiagnosis;
        
        public List<DiagnosisLookup> DiagnosisLookup
        {
            get 
            { 
                
                if (_emptyDiagnosis == null)
                    using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                        _emptyDiagnosis = eidss.model.Schema.DiagnosisLookup.Accessor.Instance(null).CreateNewT(manager, this.Parent ?? this);
                
                var ret = new List<DiagnosisLookup>();
                
                ret.Add(_emptyDiagnosis);
                
              
                if (CaseDiagnosis != null)
                {
                    
                    ret.AddRange(CaseDiagnosis
                        .Where(c => this.AsSessionSample == null ? true : 
                            this.AsSessionDiseases.Any(i => i.idfsDiagnosis == c.idfsDiagnosis && (i.idfsSpeciesType == null || i.idfsSpeciesType == 0 || i.idfsSpeciesType == this.AsSessionSample.idfsSpeciesType)))
                            
                    );
                }
                return ret;
            }
        }
            
        [LocalizedDisplayName(_str_PerformedByOffice)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfPerformedByOffice)]
        public OrganizationLookup PerformedByOffice
        {
            get { return _PerformedByOffice == null ? null : ((long)_PerformedByOffice.Key == 0 ? null : _PerformedByOffice); }
            set 
            { 
                var oldVal = _PerformedByOffice;
                _PerformedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_PerformedByOffice != oldVal)
                {
                    if (idfPerformedByOffice != (_PerformedByOffice == null
                            ? new Int64?()
                            : (Int64?)_PerformedByOffice.idfInstitution))
                        idfPerformedByOffice = _PerformedByOffice == null 
                            ? new Int64?()
                            : (Int64?)_PerformedByOffice.idfInstitution; 
                    OnPropertyChanged(_str_PerformedByOffice); 
                }
            }
        }
        private OrganizationLookup _PerformedByOffice;

        
        public List<OrganizationLookup> PerformedByOfficeLookup
        {
            get { return _PerformedByOfficeLookup; }
        }
        private List<OrganizationLookup> _PerformedByOfficeLookup = new List<OrganizationLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_TestNameRef:
                    return new BvSelectList(TestNameRefLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestNameRef, _str_idfsTestName);
            
                case _str_TestResultRef:
                    return new BvSelectList(TestResultRefLookup, eidss.model.Schema.TestResultLookup._str_idfsReference, null, TestResultRef, _str_idfsTestResult);
            
                case _str_TestCategory:
                    return new BvSelectList(TestCategoryLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestCategory, _str_idfsTestCategory);
            
                case _str_TestStatusRef:
                    return new BvSelectList(TestStatusRefLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestStatusRef, _str_idfsTestStatus);
            
                case _str_HumanCaseSample:
                    return new BvSelectList(HumanCaseSampleLookup, eidss.model.Schema.HumanCaseSample._str_idfMaterial, null, HumanCaseSample, _str_idfMaterialHuman);
            
                case _str_VetCaseSample:
                    return new BvSelectList(VetCaseSampleLookup, eidss.model.Schema.VetCaseSample._str_idfMaterial, null, VetCaseSample, _str_idfMaterialVet);
            
                case _str_AsSessionSample:
                    return new BvSelectList(AsSessionSampleLookup, eidss.model.Schema.AsSessionAnimalSample._str_idfMaterial, null, AsSessionSample, _str_idfMaterialAsSession);
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_PerformedByOffice:
                    return new BvSelectList(PerformedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, PerformedByOffice, _str_idfPerformedByOffice);
            
                case _str_AmendmentHistory:
                    return new BvSelectList(AmendmentHistory, "", "", null, "");
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_AsSessionSamples)]
        public List<AsSessionAnimalSample> AsSessionSamples
        {
            get { return new Func<CaseTest, List<AsSessionAnimalSample>>(c => c.Parent is AsSession ? (c.Parent as AsSession).ASAnimalsSamples.Where(i => !i.IsMarkedToDelete && i.idfMaterial.HasValue).ToList() : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_HumanCaseSamples)]
        public EditableList<HumanCaseSample> HumanCaseSamples
        {
            get { return new Func<CaseTest, EditableList<HumanCaseSample>>(c => 
                          {
                              if (c.Parent is HumanCase)
                              {
                                  (c.Parent as HumanCase).Samples.Sort(
                                      ((a,b) =>
                                          {
                                              if (a.idfsSampleType == (long)SampleTypeEnum.Unknown) return 1;
                                              if (b.idfsSampleType == (long)SampleTypeEnum.Unknown) return -1;
                                              return 0; //a.ToString().CompareTo(b.ToString());
                                          })
                                      );
                                  return (c.Parent as HumanCase).Samples;
                              }
                              return null;
                          }
                          )(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_VetCaseSamples)]
        public EditableList<VetCaseSample> VetCaseSamples
        {
            get { return new Func<CaseTest, EditableList<VetCaseSample>>(c => c.Parent is VetCase ? (c.Parent as VetCase).Samples : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseTestValidations)]
        public EditableList<CaseTestValidation> CaseTestValidations
        {
            get { return new Func<CaseTest, EditableList<CaseTestValidation>>(c => c.Parent is AsSession ? (c.Parent as AsSession).CaseTestValidations : (
                                       c.Parent is HumanCase ? (c.Parent as HumanCase).CaseTestValidations : (
                                       c.Parent is VetCase ? (c.Parent as VetCase).CaseTestValidations : (null))))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseDiagnosis)]
        public List<DiagnosisLookup> CaseDiagnosis
        {
            get { return new Func<CaseTest, List<DiagnosisLookup>>(c => c.Parent is AsSession ? new List<DiagnosisLookup>(c.AsSessionDiseases.Where(d => !d.IsMarkedToDelete).Select(d => d.Diagnosis).Where(d => d != null).Distinct()) : (
                                       c.Parent is HumanCase ? (c.Parent as HumanCase).DiagnosisAll : (
                                       c.Parent is VetCase ? (c.Parent as VetCase).DiagnosisAll : (null))))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_AsSessionDiseases)]
        public EditableList<AsSessionDisease> AsSessionDiseases
        {
            get { return new Func<CaseTest, EditableList<AsSessionDisease>>(c => c.Parent is AsSession ? (c.Parent as AsSession).Diseases : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<CaseTest, string>(c => (c.HumanCaseSamples != null ? "HumanCase_" : (c.VetCaseSamples != null ? "VetCase_" : "AsSession_")) + c.idfCase + "_")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseHACode)]
        public int? CaseHACode
        {
            get { return new Func<CaseTest, int?>(c => c.Parent is AsSession ? (int)eidss.model.Enums.HACode.Livestock : (
                                       c.Parent is HumanCase ? (int)eidss.model.Enums.HACode.Human : (
                                       c.Parent is VetCase ? (c.Parent as VetCase)._HACode : 0x7FFF)))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("strAnimalCode")]
        public string AnimalID
        {
            get { return new Func<CaseTest, string>(c => c.AnimalName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("AnimalID")]
        public string AnimalIDSpecies
        {
            get { return new Func<CaseTest, string>(c => c.AnimalName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Species)]
        public string Species
        {
            get { return new Func<CaseTest, string>(c => c.AnimalName)(this); }
            
        }
        
          [LocalizedDisplayName(_str_strPerformedByOffice)]
        public string strPerformedByOffice
        {
            get { return m_strPerformedByOffice; }
            set { if (m_strPerformedByOffice != value) { m_strPerformedByOffice = value; OnPropertyChanged(_str_strPerformedByOffice); } }
        }
        private string m_strPerformedByOffice;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "CaseTest";

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
        
            if (_FFPresenter != null) { _FFPresenter.Parent = this; }
                AmendmentHistory.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as CaseTest;
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
            var ret = base.Clone() as CaseTest;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_FFPresenter != null)
              ret.FFPresenter = _FFPresenter.CloneWithSetup(manager, bRestricted) as FFPresenterModel;
                
            if (_AmendmentHistory != null && _AmendmentHistory.Count > 0)
            {
              ret.AmendmentHistory.Clear();
              _AmendmentHistory.ForEach(c => ret.AmendmentHistory.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public CaseTest CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as CaseTest;
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
        
                    || (_FFPresenter != null && _FFPresenter.HasChanges)
                
                    || AmendmentHistory.IsDirty
                    || AmendmentHistory.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsTestName_TestNameRef = idfsTestName;
            var _prev_idfsTestResult_TestResultRef = idfsTestResult;
            var _prev_idfsTestCategory_TestCategory = idfsTestCategory;
            var _prev_idfsTestStatus_TestStatusRef = idfsTestStatus;
            var _prev_idfPerformedByOffice_PerformedByOffice = idfPerformedByOffice;
            base.RejectChanges();
        
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
            if (_prev_idfsTestStatus_TestStatusRef != idfsTestStatus)
            {
                _TestStatusRef = _TestStatusRefLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestStatus);
            }
            if (_prev_idfPerformedByOffice_PerformedByOffice != idfPerformedByOffice)
            {
                _PerformedByOffice = _PerformedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfPerformedByOffice);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (FFPresenter != null) FFPresenter.DeepRejectChanges();
                AmendmentHistory.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_FFPresenter != null) _FFPresenter.DeepAcceptChanges();
                AmendmentHistory.DeepAcceptChanges();
                
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
        
            if (_FFPresenter != null) _FFPresenter.SetChange();
                AmendmentHistory.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, CaseTest c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      
        public override string ToString()
        {
            return new Func<CaseTest, string>(c => c.TestName)(this);
        }
        

        public CaseTest()
        {
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(CaseTest_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(CaseTest_PropertyChanged);
        }
        private void CaseTest_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as CaseTest).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_AsSessionSamples);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_HumanCaseSamples);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_VetCaseSamples);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_CaseTestValidations);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_CaseDiagnosis);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_AsSessionDiseases);
                  
            if (e.PropertyName == _str_idfCase)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_CaseHACode);
                  
            if (e.PropertyName == _str_AnimalName)
                OnPropertyChanged(_str_AnimalID);
                  
            if (e.PropertyName == _str_AnimalName)
                OnPropertyChanged(_str_AnimalIDSpecies);
                  
            if (e.PropertyName == _str_AnimalName)
                OnPropertyChanged(_str_Species);
                  
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
            CaseTest obj = this;
            try
            {
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.blnNonLaboratoryTest && c.CaseTestValidations.Where(i => !i.IsMarkedToDelete && i.idfTesting == c.idfTesting).Count() == 0
                    );
            
            }
            catch(ValidationModelException ex)
            {
                if (bReport && !OnValidation(ex))
                {
                    OnValidationEnd(ex);
                }
                
                return false;
            }
            
            return Accessor.Instance(null).ValidateCanDelete(this);
              
        }
        private void _DeletingExtenders()
        {
            CaseTest obj = this;
            
        }
        private void _DeletedExtenders()
        {
            CaseTest obj = this;
            
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

    
        private static string[] readonly_names1 = "strSampleName,TestStatus,strFarmCode,strPerformedByOffice".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "idfPerformedByOffice,PerformedByOffice,datReceivedDate,strContactPerson".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<CaseTest, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<CaseTest, bool>(c => !c.blnNonLaboratoryTest || (!(c.HumanCaseSample != null && c.HumanCaseSample.idfsSampleType == (long)SampleTypeEnum.Unknown)))(this);
            
            return ReadOnly || new Func<CaseTest, bool>(c => !c.blnNonLaboratoryTest || c.CaseTestValidations.Where(i => !i.IsMarkedToDelete && i.idfTesting == c.idfTesting).Count() != 0)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                if (_FFPresenter != null)
                    _FFPresenter.ReadOnly |= value;
                
                foreach(var o in _AmendmentHistory)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<CaseTest, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<CaseTest, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<CaseTest, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<CaseTest, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<CaseTest, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<CaseTest, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<CaseTest, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~CaseTest()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                if (_FFPresenter != null)
                    FFPresenter.Dispose();
                AmendmentHistory.ForEach(c => c.Dispose());
                
                LookupManager.RemoveObject("rftTestName", this);
                
                LookupManager.RemoveObject("TestResultLookup", this);
                
                LookupManager.RemoveObject("rftTestCategory", this);
                
                LookupManager.RemoveObject("rftTestStatus", this);
                
                LookupManager.RemoveObject("HumanCaseSample", this);
                
                LookupManager.RemoveObject("VetCaseSample", this);
                
                LookupManager.RemoveObject("AsSessionAnimalSample", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftTestName")
                _getAccessor().LoadLookup_TestNameRef(manager, this);
            
            if (lookup_object == "TestResultLookup")
                _getAccessor().LoadLookup_TestResultRef(manager, this);
            
            if (lookup_object == "rftTestCategory")
                _getAccessor().LoadLookup_TestCategory(manager, this);
            
            if (lookup_object == "rftTestStatus")
                _getAccessor().LoadLookup_TestStatusRef(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_PerformedByOffice(manager, this);
            
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
        
            if (_FFPresenter != null) _FFPresenter.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_AmendmentHistory != null) _AmendmentHistory.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
        }
    
        #region Class for web grid
        public class CaseTestGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfTesting { get; set; }
        
            public Int64 idfsTestStatus { get; set; }
        
            public Boolean blnNonLaboratoryTest { get; set; }
        
            public string strBarcode { get; set; }
        
            public string strSampleName { get; set; }
        
            public string strFieldBarcode { get; set; }
        
            public string strFieldBarcode2 { get; set; }
        
            public string strFarmCode { get; set; }
        
            public string AnimalName { get; set; }
        
            public string AnimalIDSpecies { get; set; }
        
            public string AnimalID { get; set; }
        
            public string Species { get; set; }
        
            public string TestName { get; set; }
        
            public string DiagnosisName { get; set; }
        
            public DateTime? datConcludedDate { get; set; }
        
            public DateTime? datReceivedDate { get; set; }
        
            public string DepartmentName { get; set; }
        
            public string TestCategoryName { get; set; }
        
            public string TestStatus { get; set; }
        
            public string TestResult { get; set; }
        
        }
        public partial class CaseTestGridModelList : List<CaseTestGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public CaseTestGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<CaseTest>, errMes);
            }
            public CaseTestGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<CaseTest>, errMes);
            }
            public CaseTestGridModelList(long key, IEnumerable<CaseTest> items)
            {
                LoadGridModelList(key, items, null);
            }
            public CaseTestGridModelList(long key)
            {
                LoadGridModelList(key, new List<CaseTest>(), null);
            }
            partial void filter(List<CaseTest> items);
            private void LoadGridModelList(long key, IEnumerable<CaseTest> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strBarcode,_str_strSampleName,_str_strFieldBarcode,_str_strFieldBarcode2,_str_strFarmCode,_str_AnimalName,_str_AnimalIDSpecies,_str_AnimalID,_str_Species,_str_TestName,_str_DiagnosisName,_str_datConcludedDate,_str_datReceivedDate,_str_DepartmentName,_str_TestCategoryName,_str_TestStatus,_str_TestResult};
                    
                Hiddens = new List<string> {_str_idfTesting,_str_idfsTestStatus,_str_blnNonLaboratoryTest};
                Keys = new List<string> {_str_idfTesting};
                Labels = new Dictionary<string, string> {{_str_strBarcode, "strLabBarcode"},{_str_strSampleName, _str_strSampleName},{_str_strFieldBarcode, "strFieldBarcodeField"},{_str_strFieldBarcode2, "strFieldBarcodeLocal"},{_str_strFarmCode, _str_strFarmCode},{_str_AnimalName, _str_AnimalName},{_str_AnimalIDSpecies, "AnimalID"},{_str_AnimalID, "strAnimalCode"},{_str_Species, _str_Species},{_str_TestName, _str_TestName},{_str_DiagnosisName, "TestDiagnosis2"},{_str_datConcludedDate, _str_datConcludedDate},{_str_datReceivedDate, _str_datReceivedDate},{_str_DepartmentName, _str_DepartmentName},{_str_TestCategoryName, "TestCategory"},{_str_TestStatus, _str_TestStatus},{_str_TestResult, "TestResultObservation"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                CaseTest.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<CaseTest>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new CaseTestGridModel()
                {
                    ItemKey=c.idfTesting,idfsTestStatus=c.idfsTestStatus,blnNonLaboratoryTest=c.blnNonLaboratoryTest,strBarcode=c.strBarcode,strSampleName=c.strSampleName,strFieldBarcode=c.strFieldBarcode,strFieldBarcode2=c.strFieldBarcode2,strFarmCode=c.strFarmCode,AnimalName=c.AnimalName,AnimalIDSpecies=c.AnimalIDSpecies,AnimalID=c.AnimalID,Species=c.Species,TestName=c.TestName,DiagnosisName=c.DiagnosisName,datConcludedDate=c.datConcludedDate,datReceivedDate=c.datReceivedDate,DepartmentName=c.DepartmentName,TestCategoryName=c.TestCategoryName,TestStatus=c.TestStatus,TestResult=c.TestResult
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
        : DataAccessor<CaseTest>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<CaseTest>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfTesting"; } }
            #endregion
        
            private delegate void on_action(CaseTest obj);
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
            private FFPresenterModel.Accessor FFPresenterAccessor { get { return eidss.model.Schema.FFPresenterModel.Accessor.Instance(m_CS); } }
            private LabTestAmendment.Accessor AmendmentHistoryAccessor { get { return eidss.model.Schema.LabTestAmendment.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestNameRefAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private TestResultLookup.Accessor TestResultRefAccessor { get { return eidss.model.Schema.TestResultLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestCategoryAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestStatusRefAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private HumanCaseSample.Accessor HumanCaseSampleAccessor { get { return eidss.model.Schema.HumanCaseSample.Accessor.Instance(m_CS); } }
            private VetCaseSample.Accessor VetCaseSampleAccessor { get { return eidss.model.Schema.VetCaseSample.Accessor.Instance(m_CS); } }
            private AsSessionAnimalSample.Accessor AsSessionSampleAccessor { get { return eidss.model.Schema.AsSessionAnimalSample.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor PerformedByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<CaseTest> SelectList(DbManagerProxy manager
                , Int64? idfCase
                )
            {
                return _SelectList(manager
                    , idfCase
                    , delegate(CaseTest obj)
                        {
                        }
                    , delegate(CaseTest obj)
                        {
                        }
                    );
            }

            
            private List<CaseTest> _SelectList(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<CaseTest> objs = new List<CaseTest>();
                    sets[0] = new MapResultSet(typeof(CaseTest), objs);
                    
                    manager
                        .SetSpCommand("spCaseTests_SelectDetail"
                            , manager.Parameter("@idfCase", idfCase)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);
                    foreach(var obj in objs) 
                    {
                        obj.m_CS = m_CS;
                        
                        if (loading != null)
                            loading(obj);
                        _SetupLoad(manager, obj);
                        
                        if (loaded != null)
                            loaded(obj);
                    }
                    
                    return objs;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(e);
                }
            }
    
            private void _SetupAddChildHandlerAmendmentHistory(CaseTest obj)
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
            
            internal void _LoadFFPresenter(CaseTest obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFFPresenter(manager, obj);
                }
            }
            internal void _LoadFFPresenter(DbManagerProxy manager, CaseTest obj)
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
            
            internal void _LoadAmendmentHistory(CaseTest obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadAmendmentHistory(manager, obj);
                }
            }
            internal void _LoadAmendmentHistory(DbManagerProxy manager, CaseTest obj)
            {
                
                obj.AmendmentHistory.Clear();
                obj.AmendmentHistory.AddRange(AmendmentHistoryAccessor.SelectDetailList(manager
                    
                    , obj.idfTesting
                    ));
                obj.AmendmentHistory.ForEach(c => c.m_ObjectName = _str_AmendmentHistory);
                obj.AmendmentHistory.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, CaseTest obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadFFPresenter(manager, obj);
                _LoadAmendmentHistory(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                  if (obj.idfsFormTemplate.HasValue) obj.FFPresenter.SetProperties(obj.idfsFormTemplate.Value, obj.idfTesting);
                
                obj.idfMaterialHuman = new Func<CaseTest, long>(c => c.idfMaterial)(obj);
                obj.idfMaterialVet = new Func<CaseTest, long>(c => c.idfMaterial)(obj);
                obj.idfMaterialAsSession = new Func<CaseTest, long>(c => c.idfMaterial)(obj);
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
            
            internal void _SetPermitions(IObjectPermissions permissions, CaseTest obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    FFPresenterAccessor._SetPermitions(obj._permissions, obj.FFPresenter);
                    
                        obj.AmendmentHistory.ForEach(c => AmendmentHistoryAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private CaseTest _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    CaseTest obj = CaseTest.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfTesting = (new GetNewIDExtender<CaseTest>()).GetScalar(manager, obj, isFake);
                obj.idfObservation = (new GetNewIDExtender<CaseTest>()).GetScalar(manager, obj, isFake);
                obj.datConcludedDate = new Func<CaseTest, DateTime?>(c => DateTime.Today)(obj);
                obj.blnNonLaboratoryTest = new Func<CaseTest, bool>(c => true)(obj);
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
                obj.TestStatusRef = new Func<CaseTest, BaseReference>(c => c.TestStatusRefLookup.Where(a => a.idfsBaseReference == (long)Enums.TestStatus.Finalized).SingleOrDefault())(obj);
                obj.TestStatus = new Func<CaseTest, string>(c => c.TestStatusRef == null ? "" : c.TestStatusRef.name)(obj);
                  if (obj.HumanCaseSamples != null && obj.HumanCaseSamples.Count(c => c.idfsSampleType == (long)SampleTypeEnum.Unknown) == 0)
                  {
                      var s = HumanCaseSample.Accessor.Instance(m_CS).Create(manager, obj.Parent, null, null, null, null, null, null);
                      s.SampleTypeWithUnknown = s.SampleTypeWithUnknownLookup.FirstOrDefault(c => c.idfsReference == (long)SampleTypeEnum.Unknown);
                      obj.HumanCaseSamples.Add(s);
                  }
                
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

            
            public CaseTest CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public CaseTest CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public CaseTest CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public CaseTest CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfCase", typeof(long));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public CaseTest Create(DbManagerProxy manager, IObject Parent
                , long idfCase
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfCase = new Func<CaseTest, long>(c => idfCase)(obj);
                }
                    , obj =>
                {
                obj.Diagnosis = new Func<CaseTest, DiagnosisLookup>(c => c.CaseHACode == (long)eidss.model.Enums.HACode.Human ? c.DiagnosisLookup.FirstOrDefault(i => i.idfsDiagnosis > 0) : null)(obj);
                obj.DiagnosisName = new Func<CaseTest, string>(c => c.Diagnosis == null ? "" : c.Diagnosis.name)(obj);
                }
                );
            }
            
            public ActResult addTestDetails(DbManagerProxy manager, CaseTest obj, List<object> pars)
            {
                
                return addTestDetails(manager, obj
                    );
            }
            public ActResult addTestDetails(DbManagerProxy manager, CaseTest obj
                )
            {
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(CaseTest obj, object newobj)
            {
                
                    if (obj.HumanCaseSample != null && (newobj == null || newobj == obj.HumanCaseSample))
                    {
                        var o = obj.HumanCaseSample;
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "datFieldCollectionDate")
                            {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datFieldCollectionDate");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                    }
                  
                    if (obj.VetCaseSample != null && (newobj == null || newobj == obj.VetCaseSample))
                    {
                        var o = obj.VetCaseSample;
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "datFieldCollectionDate")
                            {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datFieldCollectionDate");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                    }
                  
                    if (obj.AsSessionSample != null && (newobj == null || newobj == obj.AsSessionSample))
                    {
                        var o = obj.AsSessionSample;
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "datFieldCollectionDate")
                            {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datFieldCollectionDate");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                    }
                  
            }
            
            private void _SetupHandlers(CaseTest obj)
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
                    
                        if (e.PropertyName == _str_idfsTestName)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestResultRef(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfPerformedByOffice)
                        {
                    
                obj.strPerformedByOffice = new Func<CaseTest, string>(c => c.PerformedByOffice != null ? c.PerformedByOffice.name : "")(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterialHuman)
                        {
                    
                obj.strSampleName = new Func<CaseTest, string>(c => c.HumanCaseSample == null ? "" : c.HumanCaseSample.strSampleName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterialVet)
                        {
                    
                obj.strSampleName = new Func<CaseTest, string>(c => c.VetCaseSample == null ? "" : c.VetCaseSample.strSampleName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterialAsSession)
                        {
                    
                obj.strSampleName = new Func<CaseTest, string>(c => c.AsSessionSample == null ? "" : c.AsSessionSample.strSampleName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterialHuman)
                        {
                    
                obj.strFieldBarcode = new Func<CaseTest, string>(c => c.HumanCaseSample == null ? "" : c.HumanCaseSample.strFieldBarcode)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterialVet)
                        {
                    
                obj.strFieldBarcode = new Func<CaseTest, string>(c => c.VetCaseSample == null ? "" : c.VetCaseSample.strFieldBarcode)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterialAsSession)
                        {
                    
                obj.strFieldBarcode = new Func<CaseTest, string>(c => c.AsSessionSample == null ? "" : c.AsSessionSample.strFieldBarcode)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterialAsSession)
                        {
                    
                obj.strFarmCode = new Func<CaseTest, string>(c => c.AsSessionSample == null ? "" : c.AsSessionSample.strFarmCode)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterialVet)
                        {
                    
                obj.AnimalName = new Func<CaseTest, string>(c => c.VetCaseSample == null ? "" : c.CaseHACode == (long)HACode.Livestock ? c.VetCaseSample.AnimalID : c.VetCaseSample.SpeciesName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterialAsSession)
                        {
                    
                obj.AnimalName = new Func<CaseTest, string>(
                                  c => {
                                      if (c.AsSessionSample != null)
                                      {
                                          /*if (string.IsNullOrEmpty(c.AsSessionSample.strAnimalCode))
                                          {
                                              if (c.AsSessionSample.Parent is AsSession)
                                              {
                                                  var sp = (c.AsSessionSample.Parent as AsSession).ASSpecies.
                                                      FirstOrDefault(s => s.idfsReference == c.AsSessionSample.idfsSpeciesType);
                                                  if (sp != null)
                                                  {
                                                      var an = (c.AsSessionSample.Parent as AsSession).ASAnimals.
                                                              FirstOrDefault(a => a.idfSpecies == sp.idfSpecies);
                                                      if (an != null)
                                                          return an.strAnimalCode;
                                                  }
                                              }
                                          }*/
                                          return c.AsSessionSample.strAnimalCode;
                                      }
                                      return "";
                                  })(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterialAsSession)
                        {
                    
                obj.Diagnosis = new Func<CaseTest, DiagnosisLookup>(c => c.DiagnosisLookup == null ? null : c.DiagnosisLookup.Where(i => i.idfsDiagnosis == obj.idfsDiagnosis).SingleOrDefault())(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterialAsSession)
                        {
                    
                obj.idfFarm = new Func<CaseTest, long?>(c => c.AsSessionSample == null ? new long?() : c.AsSessionSample.idfFarm)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestName)
                        {
                    
                obj.TestName = new Func<CaseTest, string>(c => c.TestNameRef == null ? "" : c.TestNameRef.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestCategory)
                        {
                    
                obj.TestCategoryName = new Func<CaseTest, string>(c => c.TestCategory == null ? "" : c.TestCategory.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestResult)
                        {
                    
                obj.TestResult = new Func<CaseTest, string>(c => c.TestResultRef == null ? "" : c.TestResultRef.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                obj.DiagnosisName = new Func<CaseTest, string>(c => c.Diagnosis == null ? "" : c.Diagnosis.name)(obj);
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
    
            public void LoadLookup_TestNameRef(DbManagerProxy manager, CaseTest obj)
            {
                
                obj.TestNameRefLookup.Clear();
                
                obj.TestNameRefLookup.Add(TestNameRefAccessor.CreateNewT(manager, null));
                
                obj.TestNameRefLookup.AddRange(TestNameRefAccessor.rftTestName_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode & obj.CaseHACode) != 0 || c.idfsBaseReference == obj.idfsTestName)
                        
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
            
            public void LoadLookup_TestResultRef(DbManagerProxy manager, CaseTest obj)
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
              
                
                LookupManager.AddObject("TestResultLookup", obj, TestResultRefAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_TestCategory(DbManagerProxy manager, CaseTest obj)
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
              
                
                LookupManager.AddObject("rftTestCategory", obj, TestCategoryAccessor.GetType(), "rftTestCategory_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_TestStatusRef(DbManagerProxy manager, CaseTest obj)
            {
                
                obj.TestStatusRefLookup.Clear();
                
                obj.TestStatusRefLookup.Add(TestStatusRefAccessor.CreateNewT(manager, null));
                
                obj.TestStatusRefLookup.AddRange(TestStatusRefAccessor.rftTestStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestStatus))
                    
                    .ToList());
                
                if (obj.idfsTestStatus != 0)
                {
                    obj.TestStatusRef = obj.TestStatusRefLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsTestStatus);
                    
                }
              
                
                LookupManager.AddObject("rftTestStatus", obj, TestStatusRefAccessor.GetType(), "rftTestStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_PerformedByOffice(DbManagerProxy manager, CaseTest obj)
            {
                
                obj.PerformedByOfficeLookup.Clear();
                
                obj.PerformedByOfficeLookup.Add(PerformedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.PerformedByOfficeLookup.AddRange(PerformedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (((c.intHACode??0) & obj.CaseHACode) != 0) || c.idfInstitution == obj.idfPerformedByOffice)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfPerformedByOffice))
                    
                    .ToList());
                
                if (obj.idfPerformedByOffice != null && obj.idfPerformedByOffice != 0)
                {
                    obj.PerformedByOffice = obj.PerformedByOfficeLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfPerformedByOffice);
                    
                }
              
                
                LookupManager.AddObject("OrganizationLookup", obj, PerformedByOfficeAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, CaseTest obj)
            {
                
                LoadLookup_TestNameRef(manager, obj);
                
                LoadLookup_TestResultRef(manager, obj);
                
                LoadLookup_TestCategory(manager, obj);
                
                LoadLookup_TestStatusRef(manager, obj);
                
                LoadLookup_PerformedByOffice(manager, obj);
                
            }
    
            [SprocName("spLabTest_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spLabTestEditable_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] CaseTest obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] CaseTest obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    CaseTest bo = obj as CaseTest;
                    
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
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as CaseTest, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, CaseTest obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                                
                    _postPredicate(manager, 8, obj);
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                obj.idfMaterial = new Func<CaseTest, long>(c => c.idfMaterialHuman.HasValue ? c.idfMaterialHuman.Value : (c.idfMaterialVet.HasValue ? c.idfMaterialVet.Value : (c.idfMaterialAsSession.HasValue ? c.idfMaterialAsSession.Value : c.idfMaterial)))(obj);
                obj.blnIsMainSampleTest = new Func<CaseTest, bool>(c => (c.HumanCaseSamples != null && c.HumanCaseSamples.Any(i => i.idfMaterial == c.idfMaterialHuman && i.idfMainTest == c.idfTesting)) ? true : false)(obj);
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                                    
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
            
            public bool ValidateCanDelete(CaseTest obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, CaseTest obj)
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
        
      
            protected ValidationModelException ChainsValidate(CaseTest obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<CaseTest>(obj, "datFieldCollectionDate", c => c.HumanCaseSample != null && c.HumanCaseSample.idfsSampleType != (long)SampleTypeEnum.Unknown, 
      obj.HumanCaseSample == null ? null : obj.HumanCaseSample.datFieldCollectionDate,
      obj.HumanCaseSample == null ? null : obj.HumanCaseSample.GetType(),
      false, listdatFieldCollectionDate => {
    listdatFieldCollectionDate.Add(
    new ChainsValidatorDateTime<CaseTest>(obj, "datStartedDate", c => true, 
      obj.datStartedDate,
      obj.GetType(),
      false, listdatStartedDate => {
    listdatStartedDate.Add(
    new ChainsValidatorDateTime<CaseTest>(obj, "datConcludedDate", c => true, 
      obj.datConcludedDate,
      obj.GetType(),
      false, listdatConcludedDate => {
    listdatConcludedDate.Add(
    new ChainsValidatorDateTime<CaseTest>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }));
  
    }));
  
    }).Process();
  
    new ChainsValidatorDateTime<CaseTest>(obj, "datFieldCollectionDate", c => c.VetCaseSample != null && c.VetCaseSample.idfsSampleType != (long)SampleTypeEnum.Unknown, 
      obj.VetCaseSample == null ? null : obj.VetCaseSample.datFieldCollectionDate,
      obj.VetCaseSample == null ? null : obj.VetCaseSample.GetType(),
      false, listdatFieldCollectionDate => {
    listdatFieldCollectionDate.Add(
    new ChainsValidatorDateTime<CaseTest>(obj, "datStartedDate", c => true, 
      obj.datStartedDate,
      obj.GetType(),
      false, listdatStartedDate => {
    listdatStartedDate.Add(
    new ChainsValidatorDateTime<CaseTest>(obj, "datConcludedDate", c => true, 
      obj.datConcludedDate,
      obj.GetType(),
      false, listdatConcludedDate => {
    listdatConcludedDate.Add(
    new ChainsValidatorDateTime<CaseTest>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }));
  
    }));
  
    }).Process();
  
    new ChainsValidatorDateTime<CaseTest>(obj, "datFieldCollectionDate", c => c.AsSessionSample != null && c.AsSessionSample.idfsSampleType != (long)SampleTypeEnum.Unknown, 
      obj.AsSessionSample == null ? null : obj.AsSessionSample.datFieldCollectionDate,
      obj.AsSessionSample == null ? null : obj.AsSessionSample.GetType(),
      false, listdatFieldCollectionDate => {
    listdatFieldCollectionDate.Add(
    new ChainsValidatorDateTime<CaseTest>(obj, "datStartedDate", c => true, 
      obj.datStartedDate,
      obj.GetType(),
      false, listdatStartedDate => {
    listdatStartedDate.Add(
    new ChainsValidatorDateTime<CaseTest>(obj, "datConcludedDate", c => true, 
      obj.datConcludedDate,
      obj.GetType(),
      false, listdatConcludedDate => {
    listdatConcludedDate.Add(
    new ChainsValidatorDateTime<CaseTest>(obj, "CurrentDate", c => true, 
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
            protected bool ChainsValidate(CaseTest obj, bool bRethrowException)
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
                return Validate(manager, obj as CaseTest, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, CaseTest obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfMaterialHuman", "HumanCaseSample","",
                false
              )).Validate(c => c.blnNonLaboratoryTest && c.HumanCaseSamples != null, obj, obj.idfMaterialHuman);
            
                (new RequiredValidator( "idfMaterialVet", "VetCaseSample","",
                false
              )).Validate(c => c.blnNonLaboratoryTest && c.VetCaseSamples != null, obj, obj.idfMaterialVet);
            
                (new RequiredValidator( "idfMaterialAsSession", "AsSessionSample","",
                false
              )).Validate(c => c.blnNonLaboratoryTest && c.AsSessionSamples != null, obj, obj.idfMaterialAsSession);
            
                (new RequiredValidator( "idfsTestName", "TestNameRef","",
                false
              )).Validate(c => c.blnNonLaboratoryTest, obj, obj.idfsTestName);
            
                (new RequiredValidator( "idfsDiagnosis", "Diagnosis","",
                false
              )).Validate(c => c.blnNonLaboratoryTest, obj, obj.idfsDiagnosis);
            
                (new RequiredValidator( "idfsTestResult", "TestResultRef","TestResultObservation",
                false
              )).Validate(c => c.blnNonLaboratoryTest, obj, obj.idfsTestResult);
            
                CustomValidations(obj);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
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
           
    
            private void _SetupRequired(CaseTest obj)
            {
            
                obj
                    .AddRequired("HumanCaseSample", c => c.blnNonLaboratoryTest && c.HumanCaseSamples != null);
                    
                  obj
                    .AddRequired("HumanCaseSample", c => c.blnNonLaboratoryTest && c.HumanCaseSamples != null);
                
                obj
                    .AddRequired("VetCaseSample", c => c.blnNonLaboratoryTest && c.VetCaseSamples != null);
                    
                  obj
                    .AddRequired("VetCaseSample", c => c.blnNonLaboratoryTest && c.VetCaseSamples != null);
                
                obj
                    .AddRequired("AsSessionSample", c => c.blnNonLaboratoryTest && c.AsSessionSamples != null);
                    
                  obj
                    .AddRequired("AsSessionSample", c => c.blnNonLaboratoryTest && c.AsSessionSamples != null);
                
                obj
                    .AddRequired("TestNameRef", c => c.blnNonLaboratoryTest);
                    
                  obj
                    .AddRequired("TestNameRef", c => c.blnNonLaboratoryTest);
                
                obj
                    .AddRequired("Diagnosis", c => c.blnNonLaboratoryTest);
                    
                  obj
                    .AddRequired("Diagnosis", c => c.blnNonLaboratoryTest);
                
                obj
                    .AddRequired("TestResultRef", c => c.blnNonLaboratoryTest);
                    
                  obj
                    .AddRequired("TestResultRef", c => c.blnNonLaboratoryTest);
                
            }
    
    private void _SetupPersonalDataRestrictions(CaseTest obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as CaseTest) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as CaseTest) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "CaseTestDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spCaseTests_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spLabTestEditable_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "spLabTest_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<CaseTest, bool>> RequiredByField = new Dictionary<string, Func<CaseTest, bool>>();
            public static Dictionary<string, Func<CaseTest, bool>> RequiredByProperty = new Dictionary<string, Func<CaseTest, bool>>();
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
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strFieldBarcode2, 200);
                Sizes.Add(_str_strSampleName, 2000);
                Sizes.Add(_str_TestName, 2000);
                Sizes.Add(_str_TestCategoryName, 2000);
                Sizes.Add(_str_strBatchCode, 200);
                Sizes.Add(_str_TestResult, 2000);
                Sizes.Add(_str_TestStatus, 2000);
                Sizes.Add(_str_DepartmentName, 2000);
                Sizes.Add(_str_AnimalName, 2000);
                Sizes.Add(_str_strFarmCode, 200);
                Sizes.Add(_str_DiagnosisName, 2000);
                Sizes.Add(_str_strNote, 500);
                Sizes.Add(_str_strContactPerson, 200);
                if (!RequiredByField.ContainsKey("idfMaterialHuman")) RequiredByField.Add("idfMaterialHuman", c => c.blnNonLaboratoryTest && c.HumanCaseSamples != null);
                if (!RequiredByProperty.ContainsKey("HumanCaseSample")) RequiredByProperty.Add("HumanCaseSample", c => c.blnNonLaboratoryTest && c.HumanCaseSamples != null);
                
                if (!RequiredByField.ContainsKey("idfMaterialVet")) RequiredByField.Add("idfMaterialVet", c => c.blnNonLaboratoryTest && c.VetCaseSamples != null);
                if (!RequiredByProperty.ContainsKey("VetCaseSample")) RequiredByProperty.Add("VetCaseSample", c => c.blnNonLaboratoryTest && c.VetCaseSamples != null);
                
                if (!RequiredByField.ContainsKey("idfMaterialAsSession")) RequiredByField.Add("idfMaterialAsSession", c => c.blnNonLaboratoryTest && c.AsSessionSamples != null);
                if (!RequiredByProperty.ContainsKey("AsSessionSample")) RequiredByProperty.Add("AsSessionSample", c => c.blnNonLaboratoryTest && c.AsSessionSamples != null);
                
                if (!RequiredByField.ContainsKey("idfsTestName")) RequiredByField.Add("idfsTestName", c => c.blnNonLaboratoryTest);
                if (!RequiredByProperty.ContainsKey("TestNameRef")) RequiredByProperty.Add("TestNameRef", c => c.blnNonLaboratoryTest);
                
                if (!RequiredByField.ContainsKey("idfsDiagnosis")) RequiredByField.Add("idfsDiagnosis", c => c.blnNonLaboratoryTest);
                if (!RequiredByProperty.ContainsKey("Diagnosis")) RequiredByProperty.Add("Diagnosis", c => c.blnNonLaboratoryTest);
                
                if (!RequiredByField.ContainsKey("idfsTestResult")) RequiredByField.Add("idfsTestResult", c => c.blnNonLaboratoryTest);
                if (!RequiredByProperty.ContainsKey("TestResultRef")) RequiredByProperty.Add("TestResultRef", c => c.blnNonLaboratoryTest);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfTesting,
                    _str_idfTesting, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsTestStatus,
                    _str_idfsTestStatus, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_blnNonLaboratoryTest,
                    _str_blnNonLaboratoryTest, null, false, true, true, true, null
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
                    "strFieldBarcodeField", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode2,
                    "strFieldBarcodeLocal", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFarmCode,
                    _str_strFarmCode, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalName,
                    _str_AnimalName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalIDSpecies,
                    "AnimalID", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalID,
                    "strAnimalCode", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Species,
                    _str_Species, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestName,
                    _str_TestName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DiagnosisName,
                    "TestDiagnosis2", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datConcludedDate,
                    _str_datConcludedDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datReceivedDate,
                    _str_datReceivedDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DepartmentName,
                    _str_DepartmentName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestCategoryName,
                    "TestCategory", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestStatus,
                    _str_TestStatus, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestResult,
                    "TestResultObservation", null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).Create(manager, c, pars)),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"btAddResult",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
                        ActionsAppType.Web
                        ),
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
                    "addTestDetails",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).addTestDetails(manager, (CaseTest)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"btTestDetails",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
                        ActionsAppType.Web
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    true,
                    "sample.showCaseTestGridRowTestDetails",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Edit",
                    ActionTypes.Edit,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strEdit_Id",
                        "edit",
                        /*from BvMessages*/"tooltipEdit_Id",
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"tooltipEdit_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
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
                    (manager, c, pars) => ((CaseTest)c).MarkToDelete(),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
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
                    (manager, c, pars) => new ActResult(true, c),
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
    
}
	