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
        #if MONO
        protected Int64 idfObservation_Original { get { return idfObservation; } }
        protected Int64 idfObservation_Previous { get { return idfObservation; } }
        #else
        protected Int64 idfObservation_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfObservation).OriginalValue; } }
        protected Int64 idfObservation_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfObservation).PreviousValue; } }
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
                
        [LocalizedDisplayName("strFieldBarcodeField")]
        [MapField(_str_strFieldBarcode)]
        public abstract String strFieldBarcode { get; set; }
        #if MONO
        protected String strFieldBarcode_Original { get { return strFieldBarcode; } }
        protected String strFieldBarcode_Previous { get { return strFieldBarcode; } }
        #else
        protected String strFieldBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).OriginalValue; } }
        protected String strFieldBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strFieldBarcodeLocal")]
        [MapField(_str_strFieldBarcode2)]
        public abstract String strFieldBarcode2 { get; set; }
        #if MONO
        protected String strFieldBarcode2_Original { get { return strFieldBarcode2; } }
        protected String strFieldBarcode2_Previous { get { return strFieldBarcode2; } }
        #else
        protected String strFieldBarcode2_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode2).OriginalValue; } }
        protected String strFieldBarcode2_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode2).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_TestName)]
        [MapField(_str_TestName)]
        public abstract String TestName { get; set; }
        #if MONO
        protected String TestName_Original { get { return TestName; } }
        protected String TestName_Previous { get { return TestName; } }
        #else
        protected String TestName_Original { get { return ((EditableValue<String>)((dynamic)this)._testName).OriginalValue; } }
        protected String TestName_Previous { get { return ((EditableValue<String>)((dynamic)this)._testName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("TestCategory")]
        [MapField(_str_TestType)]
        public abstract String TestType { get; set; }
        #if MONO
        protected String TestType_Original { get { return TestType; } }
        protected String TestType_Previous { get { return TestType; } }
        #else
        protected String TestType_Original { get { return ((EditableValue<String>)((dynamic)this)._testType).OriginalValue; } }
        protected String TestType_Previous { get { return ((EditableValue<String>)((dynamic)this)._testType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strBatchCode)]
        [MapField(_str_strBatchCode)]
        public abstract String strBatchCode { get; set; }
        #if MONO
        protected String strBatchCode_Original { get { return strBatchCode; } }
        protected String strBatchCode_Previous { get { return strBatchCode; } }
        #else
        protected String strBatchCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBatchCode).OriginalValue; } }
        protected String strBatchCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBatchCode).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_datValidatedDate)]
        [MapField(_str_datValidatedDate)]
        public abstract DateTime? datValidatedDate { get; set; }
        #if MONO
        protected DateTime? datValidatedDate_Original { get { return datValidatedDate; } }
        protected DateTime? datValidatedDate_Previous { get { return datValidatedDate; } }
        #else
        protected DateTime? datValidatedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datValidatedDate).OriginalValue; } }
        protected DateTime? datValidatedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datValidatedDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("TestResultObservation")]
        [MapField(_str_TestResult)]
        public abstract String TestResult { get; set; }
        #if MONO
        protected String TestResult_Original { get { return TestResult; } }
        protected String TestResult_Previous { get { return TestResult; } }
        #else
        protected String TestResult_Original { get { return ((EditableValue<String>)((dynamic)this)._testResult).OriginalValue; } }
        protected String TestResult_Previous { get { return ((EditableValue<String>)((dynamic)this)._testResult).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_TestStatus)]
        [MapField(_str_TestStatus)]
        public abstract String TestStatus { get; set; }
        #if MONO
        protected String TestStatus_Original { get { return TestStatus; } }
        protected String TestStatus_Previous { get { return TestStatus; } }
        #else
        protected String TestStatus_Original { get { return ((EditableValue<String>)((dynamic)this)._testStatus).OriginalValue; } }
        protected String TestStatus_Previous { get { return ((EditableValue<String>)((dynamic)this)._testStatus).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strFarmCode)]
        [MapField(_str_strFarmCode)]
        public abstract String strFarmCode { get; set; }
        #if MONO
        protected String strFarmCode_Original { get { return strFarmCode; } }
        protected String strFarmCode_Previous { get { return strFarmCode; } }
        #else
        protected String strFarmCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).OriginalValue; } }
        protected String strFarmCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).PreviousValue; } }
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
                
        [LocalizedDisplayName("TestDiagnosis2")]
        [MapField(_str_DiagnosisName)]
        public abstract String DiagnosisName { get; set; }
        #if MONO
        protected String DiagnosisName_Original { get { return DiagnosisName; } }
        protected String DiagnosisName_Previous { get { return DiagnosisName; } }
        #else
        protected String DiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).OriginalValue; } }
        protected String DiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_blnReadOnly)]
        [MapField(_str_blnReadOnly)]
        public abstract Boolean blnReadOnly { get; set; }
        #if MONO
        protected Boolean blnReadOnly_Original { get { return blnReadOnly; } }
        protected Boolean blnReadOnly_Previous { get { return blnReadOnly; } }
        #else
        protected Boolean blnReadOnly_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnReadOnly).OriginalValue; } }
        protected Boolean blnReadOnly_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnReadOnly).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strNote)]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        #if MONO
        protected String strNote_Original { get { return strNote; } }
        protected String strNote_Previous { get { return strNote; } }
        #else
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfContainerHuman)]
        [MapField(_str_idfContainerHuman)]
        public abstract Int64? idfContainerHuman { get; set; }
        #if MONO
        protected Int64? idfContainerHuman_Original { get { return idfContainerHuman; } }
        protected Int64? idfContainerHuman_Previous { get { return idfContainerHuman; } }
        #else
        protected Int64? idfContainerHuman_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfContainerHuman).OriginalValue; } }
        protected Int64? idfContainerHuman_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfContainerHuman).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfContainerVet)]
        [MapField(_str_idfContainerVet)]
        public abstract Int64? idfContainerVet { get; set; }
        #if MONO
        protected Int64? idfContainerVet_Original { get { return idfContainerVet; } }
        protected Int64? idfContainerVet_Previous { get { return idfContainerVet; } }
        #else
        protected Int64? idfContainerVet_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfContainerVet).OriginalValue; } }
        protected Int64? idfContainerVet_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfContainerVet).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfContainerAsSession)]
        [MapField(_str_idfContainerAsSession)]
        public abstract Int64? idfContainerAsSession { get; set; }
        #if MONO
        protected Int64? idfContainerAsSession_Original { get { return idfContainerAsSession; } }
        protected Int64? idfContainerAsSession_Previous { get { return idfContainerAsSession; } }
        #else
        protected Int64? idfContainerAsSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfContainerAsSession).OriginalValue; } }
        protected Int64? idfContainerAsSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfContainerAsSession).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intHasAmendment)]
        [MapField(_str_intHasAmendment)]
        public abstract Int32? intHasAmendment { get; set; }
        #if MONO
        protected Int32? intHasAmendment_Original { get { return intHasAmendment; } }
        protected Int32? intHasAmendment_Previous { get { return intHasAmendment; } }
        #else
        protected Int32? intHasAmendment_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intHasAmendment).OriginalValue; } }
        protected Int32? intHasAmendment_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intHasAmendment).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_blnIsMainSampleTest)]
        [MapField(_str_blnIsMainSampleTest)]
        public abstract Boolean? blnIsMainSampleTest { get; set; }
        #if MONO
        protected Boolean? blnIsMainSampleTest_Original { get { return blnIsMainSampleTest; } }
        protected Boolean? blnIsMainSampleTest_Previous { get { return blnIsMainSampleTest; } }
        #else
        protected Boolean? blnIsMainSampleTest_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnIsMainSampleTest).OriginalValue; } }
        protected Boolean? blnIsMainSampleTest_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnIsMainSampleTest).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
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
        internal const string _str_idfsTestForDiseaseType = "idfsTestForDiseaseType";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_strFieldBarcode2 = "strFieldBarcode2";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_SpecimenType = "SpecimenType";
        internal const string _str_idfsTestType = "idfsTestType";
        internal const string _str_TestName = "TestName";
        internal const string _str_TestType = "TestType";
        internal const string _str_strBatchCode = "strBatchCode";
        internal const string _str_datPerformedDate = "datPerformedDate";
        internal const string _str_datValidatedDate = "datValidatedDate";
        internal const string _str_TestResult = "TestResult";
        internal const string _str_TestStatus = "TestStatus";
        internal const string _str_DepartmentName = "DepartmentName";
        internal const string _str_AnimalName = "AnimalName";
        internal const string _str_strFarmCode = "strFarmCode";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_datStartedDate = "datStartedDate";
        internal const string _str_datConcludedDate = "datConcludedDate";
        internal const string _str_DiagnosisName = "DiagnosisName";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfContainer = "idfContainer";
        internal const string _str_blnNonLaboratoryTest = "blnNonLaboratoryTest";
        internal const string _str_blnReadOnly = "blnReadOnly";
        internal const string _str_strNote = "strNote";
        internal const string _str_idfTestedByOffice = "idfTestedByOffice";
        internal const string _str_idfTestedByPerson = "idfTestedByPerson";
        internal const string _str_idfResultEnteredByOffice = "idfResultEnteredByOffice";
        internal const string _str_idfResultEnteredByPerson = "idfResultEnteredByPerson";
        internal const string _str_idfValidatedByOffice = "idfValidatedByOffice";
        internal const string _str_idfValidatedByPerson = "idfValidatedByPerson";
        internal const string _str_idfContainerHuman = "idfContainerHuman";
        internal const string _str_idfContainerVet = "idfContainerVet";
        internal const string _str_idfContainerAsSession = "idfContainerAsSession";
        internal const string _str_intHasAmendment = "intHasAmendment";
        internal const string _str_idfExtBatchTest = "idfExtBatchTest";
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
        internal const string _str_TestTypeRef = "TestTypeRef";
        internal const string _str_TestResultRef = "TestResultRef";
        internal const string _str_TestForDiseaseType = "TestForDiseaseType";
        internal const string _str_TestStatusRef = "TestStatusRef";
        internal const string _str_HumanCaseSample = "HumanCaseSample";
        internal const string _str_VetCaseSample = "VetCaseSample";
        internal const string _str_AsSessionSample = "AsSessionSample";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_PerformedByOffice = "PerformedByOffice";
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
              _name = _str_idfObservation, _type = "Int64",
              _get_func = o => o.idfObservation,
              _set_func = (o, val) => { o.idfObservation = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfObservation != c.idfObservation || o.IsRIRPropChanged(_str_idfObservation, c)) 
                  m.Add(_str_idfObservation, o.ObjectIdent + _str_idfObservation, "Int64", o.idfObservation == null ? "" : o.idfObservation.ToString(), o.IsReadOnly(_str_idfObservation), o.IsInvisible(_str_idfObservation), o.IsRequired(_str_idfObservation)); }
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
              _name = _str_idfsTestStatus, _type = "Int64",
              _get_func = o => o.idfsTestStatus,
              _set_func = (o, val) => { o.idfsTestStatus = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestStatus != c.idfsTestStatus || o.IsRIRPropChanged(_str_idfsTestStatus, c)) 
                  m.Add(_str_idfsTestStatus, o.ObjectIdent + _str_idfsTestStatus, "Int64", o.idfsTestStatus == null ? "" : o.idfsTestStatus.ToString(), o.IsReadOnly(_str_idfsTestStatus), o.IsInvisible(_str_idfsTestStatus), o.IsRequired(_str_idfsTestStatus)); }
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
              _name = _str_strFieldBarcode2, _type = "String",
              _get_func = o => o.strFieldBarcode2,
              _set_func = (o, val) => { o.strFieldBarcode2 = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFieldBarcode2 != c.strFieldBarcode2 || o.IsRIRPropChanged(_str_strFieldBarcode2, c)) 
                  m.Add(_str_strFieldBarcode2, o.ObjectIdent + _str_strFieldBarcode2, "String", o.strFieldBarcode2 == null ? "" : o.strFieldBarcode2.ToString(), o.IsReadOnly(_str_strFieldBarcode2), o.IsInvisible(_str_strFieldBarcode2), o.IsRequired(_str_strFieldBarcode2)); }
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
              _name = _str_SpecimenType, _type = "String",
              _get_func = o => o.SpecimenType,
              _set_func = (o, val) => { o.SpecimenType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.SpecimenType != c.SpecimenType || o.IsRIRPropChanged(_str_SpecimenType, c)) 
                  m.Add(_str_SpecimenType, o.ObjectIdent + _str_SpecimenType, "String", o.SpecimenType == null ? "" : o.SpecimenType.ToString(), o.IsReadOnly(_str_SpecimenType), o.IsInvisible(_str_SpecimenType), o.IsRequired(_str_SpecimenType)); }
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
              _name = _str_TestName, _type = "String",
              _get_func = o => o.TestName,
              _set_func = (o, val) => { o.TestName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.TestName != c.TestName || o.IsRIRPropChanged(_str_TestName, c)) 
                  m.Add(_str_TestName, o.ObjectIdent + _str_TestName, "String", o.TestName == null ? "" : o.TestName.ToString(), o.IsReadOnly(_str_TestName), o.IsInvisible(_str_TestName), o.IsRequired(_str_TestName)); }
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
              _name = _str_strBatchCode, _type = "String",
              _get_func = o => o.strBatchCode,
              _set_func = (o, val) => { o.strBatchCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strBatchCode != c.strBatchCode || o.IsRIRPropChanged(_str_strBatchCode, c)) 
                  m.Add(_str_strBatchCode, o.ObjectIdent + _str_strBatchCode, "String", o.strBatchCode == null ? "" : o.strBatchCode.ToString(), o.IsReadOnly(_str_strBatchCode), o.IsInvisible(_str_strBatchCode), o.IsRequired(_str_strBatchCode)); }
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
              _name = _str_datValidatedDate, _type = "DateTime?",
              _get_func = o => o.datValidatedDate,
              _set_func = (o, val) => { o.datValidatedDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datValidatedDate != c.datValidatedDate || o.IsRIRPropChanged(_str_datValidatedDate, c)) 
                  m.Add(_str_datValidatedDate, o.ObjectIdent + _str_datValidatedDate, "DateTime?", o.datValidatedDate == null ? "" : o.datValidatedDate.ToString(), o.IsReadOnly(_str_datValidatedDate), o.IsInvisible(_str_datValidatedDate), o.IsRequired(_str_datValidatedDate)); }
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
              _name = _str_TestStatus, _type = "String",
              _get_func = o => o.TestStatus,
              _set_func = (o, val) => { o.TestStatus = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.TestStatus != c.TestStatus || o.IsRIRPropChanged(_str_TestStatus, c)) 
                  m.Add(_str_TestStatus, o.ObjectIdent + _str_TestStatus, "String", o.TestStatus == null ? "" : o.TestStatus.ToString(), o.IsReadOnly(_str_TestStatus), o.IsInvisible(_str_TestStatus), o.IsRequired(_str_TestStatus)); }
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
              _name = _str_AnimalName, _type = "String",
              _get_func = o => o.AnimalName,
              _set_func = (o, val) => { o.AnimalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.AnimalName != c.AnimalName || o.IsRIRPropChanged(_str_AnimalName, c)) 
                  m.Add(_str_AnimalName, o.ObjectIdent + _str_AnimalName, "String", o.AnimalName == null ? "" : o.AnimalName.ToString(), o.IsReadOnly(_str_AnimalName), o.IsInvisible(_str_AnimalName), o.IsRequired(_str_AnimalName)); }
              }, 
        
            new field_info {
              _name = _str_strFarmCode, _type = "String",
              _get_func = o => o.strFarmCode,
              _set_func = (o, val) => { o.strFarmCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFarmCode != c.strFarmCode || o.IsRIRPropChanged(_str_strFarmCode, c)) 
                  m.Add(_str_strFarmCode, o.ObjectIdent + _str_strFarmCode, "String", o.strFarmCode == null ? "" : o.strFarmCode.ToString(), o.IsReadOnly(_str_strFarmCode), o.IsInvisible(_str_strFarmCode), o.IsRequired(_str_strFarmCode)); }
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
              _name = _str_DiagnosisName, _type = "String",
              _get_func = o => o.DiagnosisName,
              _set_func = (o, val) => { o.DiagnosisName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.DiagnosisName != c.DiagnosisName || o.IsRIRPropChanged(_str_DiagnosisName, c)) 
                  m.Add(_str_DiagnosisName, o.ObjectIdent + _str_DiagnosisName, "String", o.DiagnosisName == null ? "" : o.DiagnosisName.ToString(), o.IsReadOnly(_str_DiagnosisName), o.IsInvisible(_str_DiagnosisName), o.IsRequired(_str_DiagnosisName)); }
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
              _name = _str_idfContainer, _type = "Int64",
              _get_func = o => o.idfContainer,
              _set_func = (o, val) => { o.idfContainer = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfContainer != c.idfContainer || o.IsRIRPropChanged(_str_idfContainer, c)) 
                  m.Add(_str_idfContainer, o.ObjectIdent + _str_idfContainer, "Int64", o.idfContainer == null ? "" : o.idfContainer.ToString(), o.IsReadOnly(_str_idfContainer), o.IsInvisible(_str_idfContainer), o.IsRequired(_str_idfContainer)); }
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
              _name = _str_blnReadOnly, _type = "Boolean",
              _get_func = o => o.blnReadOnly,
              _set_func = (o, val) => { o.blnReadOnly = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
                if (o.blnReadOnly != c.blnReadOnly || o.IsRIRPropChanged(_str_blnReadOnly, c)) 
                  m.Add(_str_blnReadOnly, o.ObjectIdent + _str_blnReadOnly, "Boolean", o.blnReadOnly == null ? "" : o.blnReadOnly.ToString(), o.IsReadOnly(_str_blnReadOnly), o.IsInvisible(_str_blnReadOnly), o.IsRequired(_str_blnReadOnly)); }
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
              _name = _str_idfContainerHuman, _type = "Int64?",
              _get_func = o => o.idfContainerHuman,
              _set_func = (o, val) => { o.idfContainerHuman = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfContainerHuman != c.idfContainerHuman || o.IsRIRPropChanged(_str_idfContainerHuman, c)) 
                  m.Add(_str_idfContainerHuman, o.ObjectIdent + _str_idfContainerHuman, "Int64?", o.idfContainerHuman == null ? "" : o.idfContainerHuman.ToString(), o.IsReadOnly(_str_idfContainerHuman), o.IsInvisible(_str_idfContainerHuman), o.IsRequired(_str_idfContainerHuman)); }
              }, 
        
            new field_info {
              _name = _str_idfContainerVet, _type = "Int64?",
              _get_func = o => o.idfContainerVet,
              _set_func = (o, val) => { o.idfContainerVet = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfContainerVet != c.idfContainerVet || o.IsRIRPropChanged(_str_idfContainerVet, c)) 
                  m.Add(_str_idfContainerVet, o.ObjectIdent + _str_idfContainerVet, "Int64?", o.idfContainerVet == null ? "" : o.idfContainerVet.ToString(), o.IsReadOnly(_str_idfContainerVet), o.IsInvisible(_str_idfContainerVet), o.IsRequired(_str_idfContainerVet)); }
              }, 
        
            new field_info {
              _name = _str_idfContainerAsSession, _type = "Int64?",
              _get_func = o => o.idfContainerAsSession,
              _set_func = (o, val) => { o.idfContainerAsSession = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfContainerAsSession != c.idfContainerAsSession || o.IsRIRPropChanged(_str_idfContainerAsSession, c)) 
                  m.Add(_str_idfContainerAsSession, o.ObjectIdent + _str_idfContainerAsSession, "Int64?", o.idfContainerAsSession == null ? "" : o.idfContainerAsSession.ToString(), o.IsReadOnly(_str_idfContainerAsSession), o.IsInvisible(_str_idfContainerAsSession), o.IsRequired(_str_idfContainerAsSession)); }
              }, 
        
            new field_info {
              _name = _str_intHasAmendment, _type = "Int32?",
              _get_func = o => o.intHasAmendment,
              _set_func = (o, val) => { o.intHasAmendment = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intHasAmendment != c.intHasAmendment || o.IsRIRPropChanged(_str_intHasAmendment, c)) 
                  m.Add(_str_intHasAmendment, o.ObjectIdent + _str_intHasAmendment, "Int32?", o.intHasAmendment == null ? "" : o.intHasAmendment.ToString(), o.IsReadOnly(_str_intHasAmendment), o.IsInvisible(_str_intHasAmendment), o.IsRequired(_str_intHasAmendment)); }
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
              _name = _str_datReceivedDate, _type = "DateTime?",
              _get_func = o => o.datReceivedDate,
              _set_func = (o, val) => { o.datReceivedDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datReceivedDate != c.datReceivedDate || o.IsRIRPropChanged(_str_datReceivedDate, c)) 
                  m.Add(_str_datReceivedDate, o.ObjectIdent + _str_datReceivedDate, "DateTime?", o.datReceivedDate == null ? "" : o.datReceivedDate.ToString(), o.IsReadOnly(_str_datReceivedDate), o.IsInvisible(_str_datReceivedDate), o.IsRequired(_str_datReceivedDate)); }
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
              _name = _str_strContactPerson, _type = "String",
              _get_func = o => o.strContactPerson,
              _set_func = (o, val) => { o.strContactPerson = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strContactPerson != c.strContactPerson || o.IsRIRPropChanged(_str_strContactPerson, c)) 
                  m.Add(_str_strContactPerson, o.ObjectIdent + _str_strContactPerson, "String", o.strContactPerson == null ? "" : o.strContactPerson.ToString(), o.IsReadOnly(_str_strContactPerson), o.IsInvisible(_str_strContactPerson), o.IsRequired(_str_strContactPerson)); }
              }, 
        
            new field_info {
              _name = _str_blnIsMainSampleTest, _type = "Boolean?",
              _get_func = o => o.blnIsMainSampleTest,
              _set_func = (o, val) => { o.blnIsMainSampleTest = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnIsMainSampleTest != c.blnIsMainSampleTest || o.IsRIRPropChanged(_str_blnIsMainSampleTest, c)) 
                  m.Add(_str_blnIsMainSampleTest, o.ObjectIdent + _str_blnIsMainSampleTest, "Boolean?", o.blnIsMainSampleTest == null ? "" : o.blnIsMainSampleTest.ToString(), o.IsReadOnly(_str_blnIsMainSampleTest), o.IsInvisible(_str_blnIsMainSampleTest), o.IsRequired(_str_blnIsMainSampleTest)); }
              }, 
        
            new field_info {
              _name = _str_strPerformedByOffice, _type = "string",
              _get_func = o => o.strPerformedByOffice,
              _set_func = (o, val) => { o.strPerformedByOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
              
                if (o.strPerformedByOffice != c.strPerformedByOffice || o.IsRIRPropChanged(_str_strPerformedByOffice, c)) 
                  m.Add(_str_strPerformedByOffice, o.ObjectIdent + _str_strPerformedByOffice, "string", o.strPerformedByOffice == null ? "" : o.strPerformedByOffice.ToString(), o.IsReadOnly(_str_strPerformedByOffice), o.IsInvisible(_str_strPerformedByOffice), o.IsRequired(_str_strPerformedByOffice));
                 }
              }, 
        
            new field_info {
              _name = _str_AsSessionSamples, _type = "EditableList<AsSessionSample>",
              _get_func = o => o.AsSessionSamples,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_HumanCaseSamples, _type = "EditableList<HumanCaseSample>",
              _get_func = o => o.HumanCaseSamples,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_VetCaseSamples, _type = "EditableList<VetCaseSample>",
              _get_func = o => o.VetCaseSamples,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_CaseTestValidations, _type = "EditableList<CaseTestValidation>",
              _get_func = o => o.CaseTestValidations,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_CaseDiagnosis, _type = "List<DiagnosisLookup>",
              _get_func = o => o.CaseDiagnosis,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_AsSessionDiseases, _type = "EditableList<AsSessionDisease>",
              _get_func = o => o.AsSessionDiseases,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
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
              _name = _str_CaseHACode, _type = "int?",
              _get_func = o => o.CaseHACode,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.CaseHACode != c.CaseHACode || o.IsRIRPropChanged(_str_CaseHACode, c)) 
                  m.Add(_str_CaseHACode, o.ObjectIdent + _str_CaseHACode, "int?", o.CaseHACode == null ? "" : o.CaseHACode.ToString(), o.IsReadOnly(_str_CaseHACode), o.IsInvisible(_str_CaseHACode), o.IsRequired(_str_CaseHACode));
                 }
              }, 
        
            new field_info {
              _name = _str_AnimalID, _type = "string",
              _get_func = o => o.AnimalID,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.AnimalID != c.AnimalID || o.IsRIRPropChanged(_str_AnimalID, c)) 
                  m.Add(_str_AnimalID, o.ObjectIdent + _str_AnimalID, "string", o.AnimalID == null ? "" : o.AnimalID.ToString(), o.IsReadOnly(_str_AnimalID), o.IsInvisible(_str_AnimalID), o.IsRequired(_str_AnimalID));
                 }
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
              _name = _str_TestStatusRef, _type = "Lookup",
              _get_func = o => { if (o.TestStatusRef == null) return null; return o.TestStatusRef.idfsBaseReference; },
              _set_func = (o, val) => { o.TestStatusRef = o.TestStatusRefLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestStatus != c.idfsTestStatus || o.IsRIRPropChanged(_str_TestStatusRef, c)) 
                  m.Add(_str_TestStatusRef, o.ObjectIdent + _str_TestStatusRef, "Lookup", o.idfsTestStatus == null ? "" : o.idfsTestStatus.ToString(), o.IsReadOnly(_str_TestStatusRef), o.IsInvisible(_str_TestStatusRef), o.IsRequired(_str_TestStatusRef)); }
              }, 
        
            new field_info {
              _name = _str_HumanCaseSample, _type = "Lookup",
              _get_func = o => { if (o.HumanCaseSample == null) return null; return o.HumanCaseSample.idfMaterial; },
              _set_func = (o, val) => { o.HumanCaseSample = o.HumanCaseSampleLookup.Where(c => c.idfMaterial.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfContainerHuman != c.idfContainerHuman || o.IsRIRPropChanged(_str_HumanCaseSample, c)) 
                  m.Add(_str_HumanCaseSample, o.ObjectIdent + _str_HumanCaseSample, "Lookup", o.idfContainerHuman == null ? "" : o.idfContainerHuman.ToString(), o.IsReadOnly(_str_HumanCaseSample), o.IsInvisible(_str_HumanCaseSample), o.IsRequired(_str_HumanCaseSample)); }
              }, 
        
            new field_info {
              _name = _str_VetCaseSample, _type = "Lookup",
              _get_func = o => { if (o.VetCaseSample == null) return null; return o.VetCaseSample.idfMaterial; },
              _set_func = (o, val) => { o.VetCaseSample = o.VetCaseSampleLookup.Where(c => c.idfMaterial.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfContainerVet != c.idfContainerVet || o.IsRIRPropChanged(_str_VetCaseSample, c)) 
                  m.Add(_str_VetCaseSample, o.ObjectIdent + _str_VetCaseSample, "Lookup", o.idfContainerVet == null ? "" : o.idfContainerVet.ToString(), o.IsReadOnly(_str_VetCaseSample), o.IsInvisible(_str_VetCaseSample), o.IsRequired(_str_VetCaseSample)); }
              }, 
        
            new field_info {
              _name = _str_AsSessionSample, _type = "Lookup",
              _get_func = o => { if (o.AsSessionSample == null) return null; return o.AsSessionSample.idfMaterial; },
              _set_func = (o, val) => { o.AsSessionSample = o.AsSessionSampleLookup.Where(c => c.idfMaterial.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfContainerAsSession != c.idfContainerAsSession || o.IsRIRPropChanged(_str_AsSessionSample, c)) 
                  m.Add(_str_AsSessionSample, o.ObjectIdent + _str_AsSessionSample, "Lookup", o.idfContainerAsSession == null ? "" : o.idfContainerAsSession.ToString(), o.IsReadOnly(_str_AsSessionSample), o.IsInvisible(_str_AsSessionSample), o.IsRequired(_str_AsSessionSample)); }
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
              _name = _str_PerformedByOffice, _type = "Lookup",
              _get_func = o => { if (o.PerformedByOffice == null) return null; return o.PerformedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.PerformedByOffice = o.PerformedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfPerformedByOffice != c.idfPerformedByOffice || o.IsRIRPropChanged(_str_PerformedByOffice, c)) 
                  m.Add(_str_PerformedByOffice, o.ObjectIdent + _str_PerformedByOffice, "Lookup", o.idfPerformedByOffice == null ? "" : o.idfPerformedByOffice.ToString(), o.IsReadOnly(_str_PerformedByOffice), o.IsInvisible(_str_PerformedByOffice), o.IsRequired(_str_PerformedByOffice)); }
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
            CaseTest obj = (CaseTest)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
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
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestStatus)]
        public BaseReference TestStatusRef
        {
            get { return _TestStatusRef == null ? null : ((long)_TestStatusRef.Key == 0 ? null : _TestStatusRef); }
            set 
            { 
                _TestStatusRef = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsTestStatus = _TestStatusRef == null 
                    ? new Int64()
                    : _TestStatusRef.idfsBaseReference; 
                OnPropertyChanged(_str_TestStatusRef); 
            }
        }
        private BaseReference _TestStatusRef;

        
        public BaseReferenceList TestStatusRefLookup
        {
            get { return _TestStatusRefLookup; }
        }
        private BaseReferenceList _TestStatusRefLookup = new BaseReferenceList("rftActivityStatus");
            
        [Relation(typeof(HumanCaseSample), eidss.model.Schema.HumanCaseSample._str_idfMaterial, _str_idfContainerHuman)]
        public HumanCaseSample HumanCaseSample
        {
            get { return _HumanCaseSample == null ? null : ((long)_HumanCaseSample.Key == 0 ? null : _HumanCaseSample); }
            set 
            { 
                _HumanCaseSample = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfContainerHuman = _HumanCaseSample == null 
                    ? new Int64?()
                    : _HumanCaseSample.idfMaterial; 
                OnPropertyChanged(_str_HumanCaseSample); 
            }
        }
        private HumanCaseSample _HumanCaseSample;

        
        public List<HumanCaseSample> HumanCaseSampleLookup
        {
            get 
            { 
                var ret = new List<HumanCaseSample>();
                using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    ret.Add(eidss.model.Schema.HumanCaseSample.Accessor.Instance(null).CreateNewT(manager, null));
                if (HumanCaseSamples != null)
                    ret.AddRange(HumanCaseSamples
                        .Where(c => !c.IsMarkedToDelete)
                            
                    );
                return ret;
            }
        }
            
        [Relation(typeof(VetCaseSample), eidss.model.Schema.VetCaseSample._str_idfMaterial, _str_idfContainerVet)]
        public VetCaseSample VetCaseSample
        {
            get { return _VetCaseSample == null ? null : ((long)_VetCaseSample.Key == 0 ? null : _VetCaseSample); }
            set 
            { 
                _VetCaseSample = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfContainerVet = _VetCaseSample == null 
                    ? new Int64?()
                    : _VetCaseSample.idfMaterial; 
                OnPropertyChanged(_str_VetCaseSample); 
            }
        }
        private VetCaseSample _VetCaseSample;

        
        public List<VetCaseSample> VetCaseSampleLookup
        {
            get 
            { 
                var ret = new List<VetCaseSample>();
                using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    ret.Add(eidss.model.Schema.VetCaseSample.Accessor.Instance(null).CreateNewT(manager, null));
                if (VetCaseSamples != null)
                    ret.AddRange(VetCaseSamples
                        .Where(c => !c.IsMarkedToDelete)
                            
                    );
                return ret;
            }
        }
            
        [Relation(typeof(AsSessionSample), eidss.model.Schema.AsSessionSample._str_idfMaterial, _str_idfContainerAsSession)]
        public AsSessionSample AsSessionSample
        {
            get { return _AsSessionSample == null ? null : ((long)_AsSessionSample.Key == 0 ? null : _AsSessionSample); }
            set 
            { 
                _AsSessionSample = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfContainerAsSession = _AsSessionSample == null 
                    ? new Int64?()
                    : _AsSessionSample.idfMaterial; 
                OnPropertyChanged(_str_AsSessionSample); 
            }
        }
        private AsSessionSample _AsSessionSample;

        
        public List<AsSessionSample> AsSessionSampleLookup
        {
            get 
            { 
                var ret = new List<AsSessionSample>();
                using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    ret.Add(eidss.model.Schema.AsSessionSample.Accessor.Instance(null).CreateNewT(manager, null));
                if (AsSessionSamples != null)
                    ret.AddRange(AsSessionSamples
                        .Where(c => !c.IsMarkedToDelete)
                            
                    );
                return ret;
            }
        }
            
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
            get 
            { 
                var ret = new List<DiagnosisLookup>();
                using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    ret.Add(eidss.model.Schema.DiagnosisLookup.Accessor.Instance(null).CreateNewT(manager, null));
                if (CaseDiagnosis != null)
                    ret.AddRange(CaseDiagnosis
                        .Where(c => this.AsSessionSample == null ? true : 
                            this.AsSessionDiseases.Any(i => i.idfsDiagnosis == c.idfsDiagnosis && (i.idfsSpeciesType == null || i.idfsSpeciesType == 0 || i.idfsSpeciesType == this.AsSessionSample.idfsSpeciesType)))
                            
                    );
                return ret;
            }
        }
            
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfPerformedByOffice)]
        public OrganizationLookup PerformedByOffice
        {
            get { return _PerformedByOffice == null ? null : ((long)_PerformedByOffice.Key == 0 ? null : _PerformedByOffice); }
            set 
            { 
                _PerformedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfPerformedByOffice = _PerformedByOffice == null 
                    ? new Int64?()
                    : _PerformedByOffice.idfInstitution; 
                OnPropertyChanged(_str_PerformedByOffice); 
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
            
                case _str_TestTypeRef:
                    return new BvSelectList(TestTypeRefLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestTypeRef, _str_idfsTestType);
            
                case _str_TestResultRef:
                    return new BvSelectList(TestResultRefLookup, eidss.model.Schema.TestResultLookup._str_idfsReference, null, TestResultRef, _str_idfsTestResult);
            
                case _str_TestForDiseaseType:
                    return new BvSelectList(TestForDiseaseTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestForDiseaseType, _str_idfsTestForDiseaseType);
            
                case _str_TestStatusRef:
                    return new BvSelectList(TestStatusRefLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestStatusRef, _str_idfsTestStatus);
            
                case _str_HumanCaseSample:
                    return new BvSelectList(HumanCaseSampleLookup, eidss.model.Schema.HumanCaseSample._str_idfMaterial, null, HumanCaseSample, _str_idfContainerHuman);
            
                case _str_VetCaseSample:
                    return new BvSelectList(VetCaseSampleLookup, eidss.model.Schema.VetCaseSample._str_idfMaterial, null, VetCaseSample, _str_idfContainerVet);
            
                case _str_AsSessionSample:
                    return new BvSelectList(AsSessionSampleLookup, eidss.model.Schema.AsSessionSample._str_idfMaterial, null, AsSessionSample, _str_idfContainerAsSession);
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_PerformedByOffice:
                    return new BvSelectList(PerformedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, PerformedByOffice, _str_idfPerformedByOffice);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_AsSessionSamples)]
        public EditableList<AsSessionSample> AsSessionSamples
        {
            get { return new Func<CaseTest, EditableList<AsSessionSample>>(c => c.Parent is AsSession ? (c.Parent as AsSession).ASSamples : null)(this); }
            
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
                                              if (a.idfsSpecimenType == (long)SampleTypeEnum.Unknown) return 1;
                                              if (b.idfsSpecimenType == (long)SampleTypeEnum.Unknown) return -1;
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
          [LocalizedDisplayName(_str_AnimalID)]
        public string AnimalID
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
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as CaseTest;
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
            var ret = base.Clone() as CaseTest;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_FFPresenter != null)
              ret.FFPresenter = _FFPresenter.CloneWithSetup(manager) as FFPresenterModel;
                
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
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
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || (_FFPresenter != null && _FFPresenter.HasChanges)
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsTestType_TestTypeRef = idfsTestType;
            var _prev_idfsTestResult_TestResultRef = idfsTestResult;
            var _prev_idfsTestForDiseaseType_TestForDiseaseType = idfsTestForDiseaseType;
            var _prev_idfsTestStatus_TestStatusRef = idfsTestStatus;
            var _prev_idfPerformedByOffice_PerformedByOffice = idfPerformedByOffice;
            base.RejectChanges();
        
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
        
            if (FFPresenter != null) FFPresenter.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
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

      private bool IsRIRPropChanged(string fld, CaseTest c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public CaseTest()
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
                    )).Validate(obj, c => c.CaseTestValidations.Where(i => !i.IsMarkedToDelete && i.idfTesting == c.idfTesting).Count() == 0
                    );
            
            }
            catch(ValidationModelException ex)
            {
                if (bReport && !OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                {
                    OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
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

    
        private static string[] readonly_names1 = "SpecimenType,TestStatus,strFarmCode,strPerformedByOffice".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "idfPerformedByOffice,PerformedByOffice,datReceivedDate,strContactPerson".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<CaseTest, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<CaseTest, bool>(c => !(c.HumanCaseSample != null && c.HumanCaseSample.idfsSpecimenType == (long)SampleTypeEnum.Unknown))(this);
            
            return ReadOnly || new Func<CaseTest, bool>(c => c.CaseTestValidations.Where(i => !i.IsMarkedToDelete && i.idfTesting == c.idfTesting).Count() != 0)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                if (_FFPresenter != null)
                    _FFPresenter.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<CaseTest, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<CaseTest, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<CaseTest, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<CaseTest, bool>> m_isHiddenPersonalData;
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
                
                LookupManager.RemoveObject("rftTestType", this);
                
                LookupManager.RemoveObject("TestResultLookup", this);
                
                LookupManager.RemoveObject("rftTestForDiseaseType", this);
                
                LookupManager.RemoveObject("rftActivityStatus", this);
                
                LookupManager.RemoveObject("HumanCaseSample", this);
                
                LookupManager.RemoveObject("VetCaseSample", this);
                
                LookupManager.RemoveObject("AsSessionSample", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftTestType")
                _getAccessor().LoadLookup_TestTypeRef(manager, this);
            
            if (lookup_object == "TestResultLookup")
                _getAccessor().LoadLookup_TestResultRef(manager, this);
            
            if (lookup_object == "rftTestForDiseaseType")
                _getAccessor().LoadLookup_TestForDiseaseType(manager, this);
            
            if (lookup_object == "rftActivityStatus")
                _getAccessor().LoadLookup_TestStatusRef(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_PerformedByOffice(manager, this);
            
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
        
            if (_FFPresenter != null) _FFPresenter.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
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
        
            public string SpecimenType { get; set; }
        
            public string strFieldBarcode { get; set; }
        
            public string strFieldBarcode2 { get; set; }
        
            public string strFarmCode { get; set; }
        
            public string AnimalName { get; set; }
        
            public string AnimalID { get; set; }
        
            public string TestName { get; set; }
        
            public string DiagnosisName { get; set; }
        
            public DateTime? datConcludedDate { get; set; }
        
            public DateTime? datReceivedDate { get; set; }
        
            public string DepartmentName { get; set; }
        
            public string TestType { get; set; }
        
            public string TestStatus { get; set; }
        
            public string TestResult { get; set; }
        
        }
        public partial class CaseTestGridModelList : List<CaseTestGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public CaseTestGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<CaseTest>, errMes);
            }
            public CaseTestGridModelList(long key, IEnumerable<CaseTest> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<CaseTest> items);
            private void LoadGridModelList(long key, IEnumerable<CaseTest> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strBarcode,_str_SpecimenType,_str_strFieldBarcode,_str_strFieldBarcode2,_str_strFarmCode,_str_AnimalName,_str_AnimalID,_str_TestName,_str_DiagnosisName,_str_datConcludedDate,_str_datReceivedDate,_str_DepartmentName,_str_TestType,_str_TestStatus,_str_TestResult};
                    
                Hiddens = new List<string> {_str_idfTesting,_str_idfsTestStatus,_str_blnNonLaboratoryTest};
                Keys = new List<string> {_str_idfTesting};
                Labels = new Dictionary<string, string> {{_str_strBarcode, "strLabBarcode"},{_str_SpecimenType, _str_SpecimenType},{_str_strFieldBarcode, "strFieldBarcodeField"},{_str_strFieldBarcode2, "strFieldBarcodeLocal"},{_str_strFarmCode, _str_strFarmCode},{_str_AnimalName, _str_AnimalName},{_str_AnimalID, _str_AnimalID},{_str_TestName, _str_TestName},{_str_DiagnosisName, "TestDiagnosis2"},{_str_datConcludedDate, _str_datConcludedDate},{_str_datReceivedDate, _str_datReceivedDate},{_str_DepartmentName, _str_DepartmentName},{_str_TestType, "TestCategory"},{_str_TestStatus, _str_TestStatus},{_str_TestResult, "TestResultObservation"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<CaseTest>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new CaseTestGridModel()
                {
                    ItemKey=c.idfTesting,idfsTestStatus=c.idfsTestStatus,blnNonLaboratoryTest=c.blnNonLaboratoryTest,strBarcode=c.strBarcode,SpecimenType=c.SpecimenType,strFieldBarcode=c.strFieldBarcode,strFieldBarcode2=c.strFieldBarcode2,strFarmCode=c.strFarmCode,AnimalName=c.AnimalName,AnimalID=c.AnimalID,TestName=c.TestName,DiagnosisName=c.DiagnosisName,datConcludedDate=c.datConcludedDate,datReceivedDate=c.datReceivedDate,DepartmentName=c.DepartmentName,TestType=c.TestType,TestStatus=c.TestStatus,TestResult=c.TestResult
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
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
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
            private BaseReference.Accessor TestTypeRefAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private TestResultLookup.Accessor TestResultRefAccessor { get { return eidss.model.Schema.TestResultLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestForDiseaseTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestStatusRefAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private HumanCaseSample.Accessor HumanCaseSampleAccessor { get { return eidss.model.Schema.HumanCaseSample.Accessor.Instance(m_CS); } }
            private VetCaseSample.Accessor VetCaseSampleAccessor { get { return eidss.model.Schema.VetCaseSample.Accessor.Instance(m_CS); } }
            private AsSessionSample.Accessor AsSessionSampleAccessor { get { return eidss.model.Schema.AsSessionSample.Accessor.Instance(m_CS); } }
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
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, CaseTest obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadFFPresenter(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                  if (obj.idfsFormTemplate.HasValue) obj.FFPresenter.SetProperties(obj.idfsFormTemplate.Value);
                
                obj.idfContainerHuman = new Func<CaseTest, long>(c => c.idfContainer)(obj);
                obj.idfContainerVet = new Func<CaseTest, long>(c => c.idfContainer)(obj);
                obj.idfContainerAsSession = new Func<CaseTest, long>(c => c.idfContainer)(obj);
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
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
                    
                    }
                }
            }

    

            private CaseTest _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
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
                obj.idfTesting = (new GetNewIDExtender<CaseTest>()).GetScalar(manager, obj);
                obj.idfObservation = (new GetNewIDExtender<CaseTest>()).GetScalar(manager, obj);
                obj.blnNonLaboratoryTest = new Func<CaseTest, bool>(c => true)(obj);
                  obj.FFPresenter = FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, obj.idfObservation);
                  obj.FFPresenter.SetProperties(EidssSiteContext.Instance.CountryID, null, FFTypeEnum.TestDetails, obj.idfObservation);
                  if (obj.FFPresenter.CurrentTemplate != null) obj.idfsFormTemplate = obj.FFPresenter.CurrentTemplate.idfsFormTemplate;
                
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.TestStatusRef = new Func<CaseTest, BaseReference>(c => c.TestStatusRefLookup.Where(a => a.idfsBaseReference == (long)BatchStatusEnum.Completed).SingleOrDefault())(obj);
                obj.TestStatus = new Func<CaseTest, string>(c => c.TestStatusRef == null ? "" : c.TestStatusRef.name)(obj);
                  if (obj.HumanCaseSamples != null && obj.HumanCaseSamples.Count(c => c.idfsSpecimenType == (long)SampleTypeEnum.Unknown) == 0)
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
                obj.Diagnosis = new Func<CaseTest, DiagnosisLookup>(c => c.DiagnosisLookup.FirstOrDefault())(obj);
                obj.DiagnosisName = new Func<CaseTest, string>(c => c.Diagnosis == null ? "" : c.Diagnosis.name)(obj);
                }
                );
            }
            
            private void _SetupChildHandlers(CaseTest obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(CaseTest obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datConcludedDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("datFieldCollectionDate_datConcludedDate_msgId", "datConcludedDate", "datConcludedDate", "datConcludedDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.HumanCaseSample == null || c.HumanCaseSample.idfsSpecimenType == (long)SampleTypeEnum.Unknown ? c.datConcludedDate : c.HumanCaseSample.datFieldCollectionDate, c.datConcludedDate)
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
                    
                        if (e.PropertyName == _str_datConcludedDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("datFieldCollectionDate_datConcludedDate_msgId", "datConcludedDate", "datConcludedDate", "datConcludedDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.VetCaseSample == null || c.VetCaseSample.idfsSpecimenType == (long)SampleTypeEnum.Unknown ? c.datConcludedDate : c.VetCaseSample.datFieldCollectionDate, c.datConcludedDate)
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
                    
                        if (e.PropertyName == _str_datConcludedDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("datFieldCollectionDate_datConcludedDate_msgId", "datConcludedDate", "datConcludedDate", "datConcludedDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.AsSessionSample == null || c.AsSessionSample.idfsSpecimenType == (long)SampleTypeEnum.Unknown ? c.datConcludedDate : c.AsSessionSample.datFieldCollectionDate, c.datConcludedDate)
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
                    
                        if (e.PropertyName == _str_idfsTestType)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestResultRef(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfPerformedByOffice)
                        {
                    
                obj.strPerformedByOffice = new Func<CaseTest, string>(c => c.PerformedByOffice != null ? c.PerformedByOffice.name : "")(obj);
                        }
                    
                        if (e.PropertyName == _str_idfContainerHuman)
                        {
                    
                obj.SpecimenType = new Func<CaseTest, string>(c => c.HumanCaseSample == null ? "" : c.HumanCaseSample.strSpecimenName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfContainerVet)
                        {
                    
                obj.SpecimenType = new Func<CaseTest, string>(c => c.VetCaseSample == null ? "" : c.VetCaseSample.strSpecimenName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfContainerAsSession)
                        {
                    
                obj.SpecimenType = new Func<CaseTest, string>(c => c.AsSessionSample == null ? "" : c.AsSessionSample.strSpecimenName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfContainerHuman)
                        {
                    
                obj.strFieldBarcode = new Func<CaseTest, string>(c => c.HumanCaseSample == null ? "" : c.HumanCaseSample.strFieldBarcode)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfContainerVet)
                        {
                    
                obj.strFieldBarcode = new Func<CaseTest, string>(c => c.VetCaseSample == null ? "" : c.VetCaseSample.strFieldBarcode)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfContainerAsSession)
                        {
                    
                obj.strFieldBarcode = new Func<CaseTest, string>(c => c.AsSessionSample == null ? "" : c.AsSessionSample.strFieldBarcode)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfContainerAsSession)
                        {
                    
                obj.strFarmCode = new Func<CaseTest, string>(c => c.AsSessionSample == null ? "" : c.AsSessionSample.strFarmCode)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfContainerAsSession)
                        {
                    
                obj.AnimalName = new Func<CaseTest, string>(
                                  c => {
                                      if (c.AsSessionSample != null)
                                      {
                                          if (string.IsNullOrEmpty(c.AsSessionSample.strAnimalCode))
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
                                          }
                                          return c.AsSessionSample.strAnimalCode;
                                      }
                                      return "";
                                  })(obj);
                        }
                    
                        if (e.PropertyName == _str_idfContainerAsSession)
                        {
                    
                obj.Diagnosis = new Func<CaseTest, DiagnosisLookup>(c => c.DiagnosisLookup == null ? null : c.DiagnosisLookup.Where(i => i.idfsDiagnosis == obj.idfsDiagnosis).SingleOrDefault())(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestType)
                        {
                    
                obj.TestName = new Func<CaseTest, string>(c => c.TestTypeRef == null ? "" : c.TestTypeRef.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestForDiseaseType)
                        {
                    
                obj.TestType = new Func<CaseTest, string>(c => c.TestForDiseaseType == null ? "" : c.TestForDiseaseType.name)(obj);
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
    
            public void LoadLookup_TestTypeRef(DbManagerProxy manager, CaseTest obj)
            {
                
                obj.TestTypeRefLookup.Clear();
                
                obj.TestTypeRefLookup.Add(TestTypeRefAccessor.CreateNewT(manager, null));
                
                obj.TestTypeRefLookup.AddRange(TestTypeRefAccessor.rftTestType_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode & obj.CaseHACode) != 0 || c.idfsBaseReference == obj.idfsTestType)
                        
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
            
            public void LoadLookup_TestResultRef(DbManagerProxy manager, CaseTest obj)
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
            
            public void LoadLookup_TestForDiseaseType(DbManagerProxy manager, CaseTest obj)
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
            
            public void LoadLookup_TestStatusRef(DbManagerProxy manager, CaseTest obj)
            {
                
                obj.TestStatusRefLookup.Clear();
                
                obj.TestStatusRefLookup.Add(TestStatusRefAccessor.CreateNewT(manager, null));
                
                obj.TestStatusRefLookup.AddRange(TestStatusRefAccessor.rftActivityStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestStatus))
                    
                    .ToList());
                
                if (obj.idfsTestStatus != 0)
                {
                    obj.TestStatusRef = obj.TestStatusRefLookup
                        .Where(c => c.idfsBaseReference == obj.idfsTestStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftActivityStatus", obj, TestStatusRefAccessor.GetType(), "rftActivityStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_PerformedByOffice(DbManagerProxy manager, CaseTest obj)
            {
                
                obj.PerformedByOfficeLookup.Clear();
                
                obj.PerformedByOfficeLookup.Add(PerformedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.PerformedByOfficeLookup.AddRange(PerformedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfPerformedByOffice))
                    
                    .ToList());
                
                if (obj.idfPerformedByOffice != null && obj.idfPerformedByOffice != 0)
                {
                    obj.PerformedByOffice = obj.PerformedByOfficeLookup
                        .Where(c => c.idfInstitution == obj.idfPerformedByOffice)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("OrganizationLookup", obj, PerformedByOfficeAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, CaseTest obj)
            {
                
                LoadLookup_TestTypeRef(manager, obj);
                
                LoadLookup_TestResultRef(manager, obj);
                
                LoadLookup_TestForDiseaseType(manager, obj);
                
                LoadLookup_TestStatusRef(manager, obj);
                
                LoadLookup_PerformedByOffice(manager, obj);
                
            }
    
            [SprocName("spLabTest_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spLabTestEditable_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfExtBatchTest")] CaseTest obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfExtBatchTest")] CaseTest obj)
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
                obj.idfContainer = new Func<CaseTest, long>(c => c.idfContainerHuman.HasValue ? c.idfContainerHuman.Value : (c.idfContainerVet.HasValue ? c.idfContainerVet.Value : (c.idfContainerAsSession.HasValue ? c.idfContainerAsSession.Value : c.idfContainer)))(obj);
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
                obj.AcceptChanges();
                
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
                return Validate(manager, obj as CaseTest, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, CaseTest obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfContainerHuman", "HumanCaseSample","",
                false
              )).Validate(c => c.blnNonLaboratoryTest && c.HumanCaseSamples != null, obj, obj.idfContainerHuman);
            
                (new RequiredValidator( "idfContainerVet", "VetCaseSample","",
                false
              )).Validate(c => c.blnNonLaboratoryTest && c.VetCaseSamples != null, obj, obj.idfContainerVet);
            
                (new RequiredValidator( "idfContainerAsSession", "AsSessionSample","",
                false
              )).Validate(c => c.blnNonLaboratoryTest && c.AsSessionSamples != null, obj, obj.idfContainerAsSession);
            
                (new RequiredValidator( "idfsTestType", "TestTypeRef","",
                false
              )).Validate(c => c.blnNonLaboratoryTest, obj, obj.idfsTestType);
            
                (new RequiredValidator( "idfsDiagnosis", "Diagnosis","",
                false
              )).Validate(c => c.blnNonLaboratoryTest, obj, obj.idfsDiagnosis);
            
                (new RequiredValidator( "idfsTestResult", "TestResultRef","TestResultObservation",
                false
              )).Validate(c => c.blnNonLaboratoryTest, obj, obj.idfsTestResult);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                (new PredicateValidator("datFieldCollectionDate_datConcludedDate_msgId", "datConcludedDate", "datConcludedDate", "datConcludedDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.HumanCaseSample == null || c.HumanCaseSample.idfsSpecimenType == (long)SampleTypeEnum.Unknown ? c.datConcludedDate : c.HumanCaseSample.datFieldCollectionDate, c.datConcludedDate)
                    );
            
                (new PredicateValidator("datFieldCollectionDate_datConcludedDate_msgId", "datConcludedDate", "datConcludedDate", "datConcludedDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.VetCaseSample == null || c.VetCaseSample.idfsSpecimenType == (long)SampleTypeEnum.Unknown ? c.datConcludedDate : c.VetCaseSample.datFieldCollectionDate, c.datConcludedDate)
                    );
            
                (new PredicateValidator("datFieldCollectionDate_datConcludedDate_msgId", "datConcludedDate", "datConcludedDate", "datConcludedDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.AsSessionSample == null || c.AsSessionSample.idfsSpecimenType == (long)SampleTypeEnum.Unknown ? c.datConcludedDate : c.AsSessionSample.datFieldCollectionDate, c.datConcludedDate)
                    );
            
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
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
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
                    .AddRequired("VetCaseSample", c => c.blnNonLaboratoryTest && c.VetCaseSamples != null);
                    
                obj
                    .AddRequired("AsSessionSample", c => c.blnNonLaboratoryTest && c.AsSessionSamples != null);
                    
                obj
                    .AddRequired("TestTypeRef", c => c.blnNonLaboratoryTest);
                    
                obj
                    .AddRequired("Diagnosis", c => c.blnNonLaboratoryTest);
                    
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
            static Meta()
            {
                
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strFieldBarcode2, 200);
                Sizes.Add(_str_SpecimenType, 2000);
                Sizes.Add(_str_TestName, 2000);
                Sizes.Add(_str_TestType, 2000);
                Sizes.Add(_str_strBatchCode, 200);
                Sizes.Add(_str_TestResult, 2000);
                Sizes.Add(_str_TestStatus, 2000);
                Sizes.Add(_str_DepartmentName, 2000);
                Sizes.Add(_str_AnimalName, 2000);
                Sizes.Add(_str_strFarmCode, 200);
                Sizes.Add(_str_DiagnosisName, 2000);
                Sizes.Add(_str_strNote, 500);
                Sizes.Add(_str_strContactPerson, 200);
                if (!RequiredByField.ContainsKey("idfContainerHuman")) RequiredByField.Add("idfContainerHuman", c => c.blnNonLaboratoryTest && c.HumanCaseSamples != null);
                if (!RequiredByProperty.ContainsKey("HumanCaseSample")) RequiredByProperty.Add("HumanCaseSample", c => c.blnNonLaboratoryTest && c.HumanCaseSamples != null);
                
                if (!RequiredByField.ContainsKey("idfContainerVet")) RequiredByField.Add("idfContainerVet", c => c.blnNonLaboratoryTest && c.VetCaseSamples != null);
                if (!RequiredByProperty.ContainsKey("VetCaseSample")) RequiredByProperty.Add("VetCaseSample", c => c.blnNonLaboratoryTest && c.VetCaseSamples != null);
                
                if (!RequiredByField.ContainsKey("idfContainerAsSession")) RequiredByField.Add("idfContainerAsSession", c => c.blnNonLaboratoryTest && c.AsSessionSamples != null);
                if (!RequiredByProperty.ContainsKey("AsSessionSample")) RequiredByProperty.Add("AsSessionSample", c => c.blnNonLaboratoryTest && c.AsSessionSamples != null);
                
                if (!RequiredByField.ContainsKey("idfsTestType")) RequiredByField.Add("idfsTestType", c => c.blnNonLaboratoryTest);
                if (!RequiredByProperty.ContainsKey("TestTypeRef")) RequiredByProperty.Add("TestTypeRef", c => c.blnNonLaboratoryTest);
                
                if (!RequiredByField.ContainsKey("idfsDiagnosis")) RequiredByField.Add("idfsDiagnosis", c => c.blnNonLaboratoryTest);
                if (!RequiredByProperty.ContainsKey("Diagnosis")) RequiredByProperty.Add("Diagnosis", c => c.blnNonLaboratoryTest);
                
                if (!RequiredByField.ContainsKey("idfsTestResult")) RequiredByField.Add("idfsTestResult", c => c.blnNonLaboratoryTest);
                if (!RequiredByProperty.ContainsKey("TestResultRef")) RequiredByProperty.Add("TestResultRef", c => c.blnNonLaboratoryTest);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfTesting,
                    _str_idfTesting, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsTestStatus,
                    _str_idfsTestStatus, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_blnNonLaboratoryTest,
                    _str_blnNonLaboratoryTest, null, false, true, null
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
                    "strFieldBarcodeField", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode2,
                    "strFieldBarcodeLocal", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFarmCode,
                    _str_strFarmCode, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalName,
                    _str_AnimalName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalID,
                    _str_AnimalID, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestName,
                    _str_TestName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DiagnosisName,
                    "TestDiagnosis2", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datConcludedDate,
                    _str_datConcludedDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datReceivedDate,
                    _str_datReceivedDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DepartmentName,
                    _str_DepartmentName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestType,
                    "TestCategory", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestStatus,
                    _str_TestStatus, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestResult,
                    "TestResultObservation", null, true, true, null
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	