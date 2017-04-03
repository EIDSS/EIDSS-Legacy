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
    public abstract partial class LaboratorySectionItem : 
        EditableObject<LaboratorySectionItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_ID), NonUpdatable, PrimaryKey]
        public abstract Int64 ID { get; set; }
                
        [LocalizedDisplayName(_str_idfTesting)]
        [MapField(_str_idfTesting)]
        public abstract Int64? idfTesting { get; set; }
        protected Int64? idfTesting_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTesting).OriginalValue; } }
        protected Int64? idfTesting_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTesting).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMaterial)]
        [MapField(_str_idfMaterial)]
        public abstract Int64 idfMaterial { get; set; }
        protected Int64 idfMaterial_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfMaterial).OriginalValue; } }
        protected Int64 idfMaterial_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfMaterial).PreviousValue; } }
                
        [LocalizedDisplayName("strPatientSessionVectorInfo")]
        [MapField(_str_idfSpeciesVectorInfo)]
        public abstract Int64? idfSpeciesVectorInfo { get; set; }
        protected Int64? idfSpeciesVectorInfo_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpeciesVectorInfo).OriginalValue; } }
        protected Int64? idfSpeciesVectorInfo_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpeciesVectorInfo).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfCaseOrSession)]
        [MapField(_str_idfCaseOrSession)]
        public abstract Int64? idfCaseOrSession { get; set; }
        protected Int64? idfCaseOrSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCaseOrSession).OriginalValue; } }
        protected Int64? idfCaseOrSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCaseOrSession).PreviousValue; } }
                
        [LocalizedDisplayName("SampleStatus")]
        [MapField(_str_idfsSampleStatus)]
        public abstract Int64 idfsSampleStatus { get; set; }
        protected Int64 idfsSampleStatus_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSampleStatus).OriginalValue; } }
        protected Int64 idfsSampleStatus_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSampleStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datSampleStatusDate)]
        [MapField(_str_datSampleStatusDate)]
        public abstract DateTime? datSampleStatusDate { get; set; }
        protected DateTime? datSampleStatusDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datSampleStatusDate).OriginalValue; } }
        protected DateTime? datSampleStatusDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datSampleStatusDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSampleType)]
        [MapField(_str_idfsSampleType)]
        public abstract Int64 idfsSampleType { get; set; }
        protected Int64 idfsSampleType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSampleType).OriginalValue; } }
        protected Int64 idfsSampleType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSampleType).PreviousValue; } }
                
        [LocalizedDisplayName("TestDiagnosisName")]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64? idfsDiagnosis { get; set; }
        protected Int64? idfsDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64? idfsDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsShowDiagnosis)]
        [MapField(_str_idfsShowDiagnosis)]
        public abstract Int64? idfsShowDiagnosis { get; set; }
        protected Int64? idfsShowDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsShowDiagnosis).OriginalValue; } }
        protected Int64? idfsShowDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsShowDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName("TestDiagnosisName")]
        [MapField(_str_strDiagnosisName)]
        public abstract String strDiagnosisName { get; set; }
        protected String strDiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisName).OriginalValue; } }
        protected String strDiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfRootMaterial)]
        [MapField(_str_idfRootMaterial)]
        public abstract Int64? idfRootMaterial { get; set; }
        protected Int64? idfRootMaterial_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootMaterial).OriginalValue; } }
        protected Int64? idfRootMaterial_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootMaterial).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfParentMaterial)]
        [MapField(_str_idfParentMaterial)]
        public abstract Int64? idfParentMaterial { get; set; }
        protected Int64? idfParentMaterial_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParentMaterial).OriginalValue; } }
        protected Int64? idfParentMaterial_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParentMaterial).PreviousValue; } }
                
        [LocalizedDisplayName("strParentBarcode")]
        [MapField(_str_strParentMaterial)]
        public abstract String strParentMaterial { get; set; }
        protected String strParentMaterial_Original { get { return ((EditableValue<String>)((dynamic)this)._strParentMaterial).OriginalValue; } }
        protected String strParentMaterial_Previous { get { return ((EditableValue<String>)((dynamic)this)._strParentMaterial).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfHuman)]
        [MapField(_str_idfHuman)]
        public abstract Int64? idfHuman { get; set; }
        protected Int64? idfHuman_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHuman).OriginalValue; } }
        protected Int64? idfHuman_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHuman).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfSpecies)]
        [MapField(_str_idfSpecies)]
        public abstract Int64? idfSpecies { get; set; }
        protected Int64? idfSpecies_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).OriginalValue; } }
        protected Int64? idfSpecies_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfAnimal)]
        [MapField(_str_idfAnimal)]
        public abstract Int64? idfAnimal { get; set; }
        protected Int64? idfAnimal_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAnimal).OriginalValue; } }
        protected Int64? idfAnimal_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAnimal).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_idfMainTest)]
        [MapField(_str_idfMainTest)]
        public abstract Int64? idfMainTest { get; set; }
        protected Int64? idfMainTest_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMainTest).OriginalValue; } }
        protected Int64? idfMainTest_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMainTest).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfVectorSurveillanceSession)]
        [MapField(_str_idfVectorSurveillanceSession)]
        public abstract Int64? idfVectorSurveillanceSession { get; set; }
        protected Int64? idfVectorSurveillanceSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).OriginalValue; } }
        protected Int64? idfVectorSurveillanceSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfVector)]
        [MapField(_str_idfVector)]
        public abstract Int64? idfVector { get; set; }
        protected Int64? idfVector_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVector).OriginalValue; } }
        protected Int64? idfVector_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVector).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfDestroyedByPerson)]
        [MapField(_str_idfDestroyedByPerson)]
        public abstract Int64? idfDestroyedByPerson { get; set; }
        protected Int64? idfDestroyedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDestroyedByPerson).OriginalValue; } }
        protected Int64? idfDestroyedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDestroyedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName("strLabBarcode")]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFieldBarcode)]
        [MapField(_str_strFieldBarcode)]
        public abstract String strFieldBarcode { get; set; }
        protected String strFieldBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).OriginalValue; } }
        protected String strFieldBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFieldCollectionDate)]
        [MapField(_str_datFieldCollectionDate)]
        public abstract DateTime? datFieldCollectionDate { get; set; }
        protected DateTime? datFieldCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).OriginalValue; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFieldSentDate)]
        [MapField(_str_datFieldSentDate)]
        public abstract DateTime? datFieldSentDate { get; set; }
        protected DateTime? datFieldSentDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldSentDate).OriginalValue; } }
        protected DateTime? datFieldSentDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldSentDate).PreviousValue; } }
                
        [LocalizedDisplayName("strCaseIDSessionID")]
        [MapField(_str_strCalculatedCaseID)]
        public abstract String strCalculatedCaseID { get; set; }
        protected String strCalculatedCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCalculatedCaseID).OriginalValue; } }
        protected String strCalculatedCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCalculatedCaseID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCalculatedHumanName)]
        [MapField(_str_strCalculatedHumanName)]
        public abstract String strCalculatedHumanName { get; set; }
        protected String strCalculatedHumanName_Original { get { return ((EditableValue<String>)((dynamic)this)._strCalculatedHumanName).OriginalValue; } }
        protected String strCalculatedHumanName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCalculatedHumanName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfAccesionByPerson)]
        [MapField(_str_idfAccesionByPerson)]
        public abstract Int64? idfAccesionByPerson { get; set; }
        protected Int64? idfAccesionByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAccesionByPerson).OriginalValue; } }
        protected Int64? idfAccesionByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAccesionByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsAccessionCondition)]
        [MapField(_str_idfsAccessionCondition)]
        public abstract Int64? idfsAccessionCondition { get; set; }
        protected Int64? idfsAccessionCondition_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAccessionCondition).OriginalValue; } }
        protected Int64? idfsAccessionCondition_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAccessionCondition).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datAccession)]
        [MapField(_str_datAccession)]
        public abstract DateTime? datAccession { get; set; }
        protected DateTime? datAccession_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).OriginalValue; } }
        protected DateTime? datAccession_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datEnteringDate)]
        [MapField(_str_datEnteringDate)]
        public abstract DateTime? datEnteringDate { get; set; }
        protected DateTime? datEnteringDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteringDate).OriginalValue; } }
        protected DateTime? datEnteringDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteringDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datDestructionDate)]
        [MapField(_str_datDestructionDate)]
        public abstract DateTime? datDestructionDate { get; set; }
        protected DateTime? datDestructionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDestructionDate).OriginalValue; } }
        protected DateTime? datDestructionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDestructionDate).PreviousValue; } }
                
        [LocalizedDisplayName("strOrganizationSendTo")]
        [MapField(_str_idfSendToOffice)]
        public abstract Int64? idfSendToOffice { get; set; }
        protected Int64? idfSendToOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).OriginalValue; } }
        protected Int64? idfSendToOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfSubdivision)]
        [MapField(_str_idfSubdivision)]
        public abstract Int64? idfSubdivision { get; set; }
        protected Int64? idfSubdivision_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSubdivision).OriginalValue; } }
        protected Int64? idfSubdivision_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSubdivision).PreviousValue; } }
                
        [LocalizedDisplayName("strFreezerName")]
        [MapField(_str_idfInDepartment)]
        public abstract Int64? idfInDepartment { get; set; }
        protected Int64? idfInDepartment_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInDepartment).OriginalValue; } }
        protected Int64? idfInDepartment_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInDepartment).PreviousValue; } }
                
        [LocalizedDisplayName("idfsCaseSessionType")]
        [MapField(_str_idfsCaseType)]
        public abstract Int64? idfsCaseType { get; set; }
        protected Int64? idfsCaseType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).OriginalValue; } }
        protected Int64? idfsCaseType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intCaseHACode)]
        [MapField(_str_intCaseHACode)]
        public abstract Int32? intCaseHACode { get; set; }
        protected Int32? intCaseHACode_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intCaseHACode).OriginalValue; } }
        protected Int32? intCaseHACode_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intCaseHACode).PreviousValue; } }
                
        [LocalizedDisplayName("CollectedbyInstitution")]
        [MapField(_str_idfFieldCollectedByOffice)]
        public abstract Int64? idfFieldCollectedByOffice { get; set; }
        protected Int64? idfFieldCollectedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).OriginalValue; } }
        protected Int64? idfFieldCollectedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName("CollectedbyOfficer")]
        [MapField(_str_idfFieldCollectedByPerson)]
        public abstract Int64? idfFieldCollectedByPerson { get; set; }
        protected Int64? idfFieldCollectedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByPerson).OriginalValue; } }
        protected Int64? idfFieldCollectedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName("DestructionMethod")]
        [MapField(_str_idfsDestructionMethod)]
        public abstract Int64? idfsDestructionMethod { get; set; }
        protected Int64? idfsDestructionMethod_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDestructionMethod).OriginalValue; } }
        protected Int64? idfsDestructionMethod_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDestructionMethod).PreviousValue; } }
                
        [LocalizedDisplayName("strNotes")]
        [MapField(_str_strSampleNote)]
        public abstract String strSampleNote { get; set; }
        protected String strSampleNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleNote).OriginalValue; } }
        protected String strSampleNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleNote).PreviousValue; } }
                
        [LocalizedDisplayName("strAccessionInComment")]
        [MapField(_str_strCondition)]
        public abstract String strCondition { get; set; }
        protected String strCondition_Original { get { return ((EditableValue<String>)((dynamic)this)._strCondition).OriginalValue; } }
        protected String strCondition_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCondition).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSampleKind)]
        [MapField(_str_idfsSampleKind)]
        public abstract Int64? idfsSampleKind { get; set; }
        protected Int64? idfsSampleKind_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleKind).OriginalValue; } }
        protected Int64? idfsSampleKind_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleKind).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMarkedForDispositionByPerson)]
        [MapField(_str_idfMarkedForDispositionByPerson)]
        public abstract Int64? idfMarkedForDispositionByPerson { get; set; }
        protected Int64? idfMarkedForDispositionByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMarkedForDispositionByPerson).OriginalValue; } }
        protected Int64? idfMarkedForDispositionByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMarkedForDispositionByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intTestCount)]
        [MapField(_str_intTestCount)]
        public abstract Int32? intTestCount { get; set; }
        protected Int32? intTestCount_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intTestCount).OriginalValue; } }
        protected Int32? intTestCount_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intTestCount).PreviousValue; } }
                
        [LocalizedDisplayName("TransferTo")]
        [MapField(_str_idfSendToOfficeOut)]
        public abstract Int64? idfSendToOfficeOut { get; set; }
        protected Int64? idfSendToOfficeOut_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOfficeOut).OriginalValue; } }
        protected Int64? idfSendToOfficeOut_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOfficeOut).PreviousValue; } }
                
        [LocalizedDisplayName(_str_bExternalOffice)]
        [MapField(_str_bExternalOffice)]
        public abstract Boolean? bExternalOffice { get; set; }
        protected Boolean? bExternalOffice_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._bExternalOffice).OriginalValue; } }
        protected Boolean? bExternalOffice_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._bExternalOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfSendByPerson)]
        [MapField(_str_idfSendByPerson)]
        public abstract Int64? idfSendByPerson { get; set; }
        protected Int64? idfSendByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendByPerson).OriginalValue; } }
        protected Int64? idfSendByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datSendDate)]
        [MapField(_str_datSendDate)]
        public abstract DateTime? datSendDate { get; set; }
        protected DateTime? datSendDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datSendDate).OriginalValue; } }
        protected DateTime? datSendDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datSendDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_HumanName)]
        [MapField(_str_HumanName)]
        public abstract String HumanName { get; set; }
        protected String HumanName_Original { get { return ((EditableValue<String>)((dynamic)this)._humanName).OriginalValue; } }
        protected String HumanName_Previous { get { return ((EditableValue<String>)((dynamic)this)._humanName).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_idfsCountry)]
        [MapField(_str_idfsCountry)]
        public abstract Int64? idfsCountry { get; set; }
        protected Int64? idfsCountry_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).OriginalValue; } }
        protected Int64? idfsCountry_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRegion)]
        [MapField(_str_idfsRegion)]
        public abstract Int64? idfsRegion { get; set; }
        protected Int64? idfsRegion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).OriginalValue; } }
        protected Int64? idfsRegion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRegion)]
        [MapField(_str_strRegion)]
        public abstract String strRegion { get; set; }
        protected String strRegion_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegion).OriginalValue; } }
        protected String strRegion_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegion).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRayon)]
        [MapField(_str_idfsRayon)]
        public abstract Int64? idfsRayon { get; set; }
        protected Int64? idfsRayon_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).OriginalValue; } }
        protected Int64? idfsRayon_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRayon)]
        [MapField(_str_strRayon)]
        public abstract String strRayon { get; set; }
        protected String strRayon_Original { get { return ((EditableValue<String>)((dynamic)this)._strRayon).OriginalValue; } }
        protected String strRayon_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRayon).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSettlement)]
        [MapField(_str_idfsSettlement)]
        public abstract Int64? idfsSettlement { get; set; }
        protected Int64? idfsSettlement_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).OriginalValue; } }
        protected Int64? idfsSettlement_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).PreviousValue; } }
                
        [LocalizedDisplayName("TestName")]
        [MapField(_str_idfsTestName)]
        public abstract Int64? idfsTestName { get; set; }
        protected Int64? idfsTestName_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestName).OriginalValue; } }
        protected Int64? idfsTestName_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestName).PreviousValue; } }
                
        [LocalizedDisplayName("TestCategory")]
        [MapField(_str_idfsTestCategory)]
        public abstract Int64? idfsTestCategory { get; set; }
        protected Int64? idfsTestCategory_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestCategory).OriginalValue; } }
        protected Int64? idfsTestCategory_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestCategory).PreviousValue; } }
                
        [LocalizedDisplayName("TestStatus")]
        [MapField(_str_idfsTestStatus)]
        public abstract Int64? idfsTestStatus { get; set; }
        protected Int64? idfsTestStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestStatus).OriginalValue; } }
        protected Int64? idfsTestStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestStatus).PreviousValue; } }
                
        [LocalizedDisplayName("TestResult")]
        [MapField(_str_idfsTestResult)]
        public abstract Int64? idfsTestResult { get; set; }
        protected Int64? idfsTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).OriginalValue; } }
        protected Int64? idfsTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datStartedDate)]
        [MapField(_str_datStartedDate)]
        public abstract DateTime? datStartedDate { get; set; }
        protected DateTime? datStartedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartedDate).OriginalValue; } }
        protected DateTime? datStartedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartedDate).PreviousValue; } }
                
        [LocalizedDisplayName("datTestResultDate")]
        [MapField(_str_datConcludedDate)]
        public abstract DateTime? datConcludedDate { get; set; }
        protected DateTime? datConcludedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datConcludedDate).OriginalValue; } }
        protected DateTime? datConcludedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datConcludedDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfObservation)]
        [MapField(_str_idfObservation)]
        public abstract Int64? idfObservation { get; set; }
        protected Int64? idfObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObservation).OriginalValue; } }
        protected Int64? idfObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObservation).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_blnNonLaboratoryTest)]
        [MapField(_str_blnNonLaboratoryTest)]
        public abstract Boolean? blnNonLaboratoryTest { get; set; }
        protected Boolean? blnNonLaboratoryTest_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnNonLaboratoryTest).OriginalValue; } }
        protected Boolean? blnNonLaboratoryTest_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnNonLaboratoryTest).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnExternalTest)]
        [MapField(_str_blnExternalTest)]
        public abstract Boolean blnExternalTest { get; set; }
        protected Boolean blnExternalTest_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnExternalTest).OriginalValue; } }
        protected Boolean blnExternalTest_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnExternalTest).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datReceivedDate)]
        [MapField(_str_datReceivedDate)]
        public abstract DateTime? datReceivedDate { get; set; }
        protected DateTime? datReceivedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReceivedDate).OriginalValue; } }
        protected DateTime? datReceivedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReceivedDate).PreviousValue; } }
                
        [LocalizedDisplayName("strResultsReceivedFrom")]
        [MapField(_str_idfPerformedByOffice)]
        public abstract Int64? idfPerformedByOffice { get; set; }
        protected Int64? idfPerformedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerformedByOffice).OriginalValue; } }
        protected Int64? idfPerformedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerformedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName("strContact")]
        [MapField(_str_strContactPerson)]
        public abstract String strContactPerson { get; set; }
        protected String strContactPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strContactPerson).OriginalValue; } }
        protected String strContactPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strContactPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64? idfsFormTemplate { get; set; }
        protected Int64? idfsFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64? idfsFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strBatchID)]
        [MapField(_str_strBatchID)]
        public abstract String strBatchID { get; set; }
        protected String strBatchID_Original { get { return ((EditableValue<String>)((dynamic)this)._strBatchID).OriginalValue; } }
        protected String strBatchID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBatchID).PreviousValue; } }
                
        [LocalizedDisplayName("SampleStatus")]
        [MapField(_str_strSampleStatus)]
        public abstract String strSampleStatus { get; set; }
        protected String strSampleStatus_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleStatus).OriginalValue; } }
        protected String strSampleStatus_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleStatus).PreviousValue; } }
                
        [LocalizedDisplayName("idfsSampleType")]
        [MapField(_str_strSampleName)]
        public abstract String strSampleName { get; set; }
        protected String strSampleName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).OriginalValue; } }
        protected String strSampleName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).PreviousValue; } }
                
        [LocalizedDisplayName("idfsAccessionCondition")]
        [MapField(_str_strSampleConditionReceivedStatus)]
        public abstract String strSampleConditionReceivedStatus { get; set; }
        protected String strSampleConditionReceivedStatus_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleConditionReceivedStatus).OriginalValue; } }
        protected String strSampleConditionReceivedStatus_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleConditionReceivedStatus).PreviousValue; } }
                
        [LocalizedDisplayName("TestName")]
        [MapField(_str_strTestName)]
        public abstract String strTestName { get; set; }
        protected String strTestName_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestName).OriginalValue; } }
        protected String strTestName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestName).PreviousValue; } }
                
        [LocalizedDisplayName("TestStatus")]
        [MapField(_str_strTestStatus)]
        public abstract String strTestStatus { get; set; }
        protected String strTestStatus_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestStatus).OriginalValue; } }
        protected String strTestStatus_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestStatus).PreviousValue; } }
                
        [LocalizedDisplayName("TestResult")]
        [MapField(_str_strTestResult)]
        public abstract String strTestResult { get; set; }
        protected String strTestResult_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestResult).OriginalValue; } }
        protected String strTestResult_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestResult).PreviousValue; } }
                
        [LocalizedDisplayName("TestCategory")]
        [MapField(_str_strTestCategory)]
        public abstract String strTestCategory { get; set; }
        protected String strTestCategory_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestCategory).OriginalValue; } }
        protected String strTestCategory_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestCategory).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsLaboratorySection)]
        [MapField(_str_idfsLaboratorySection)]
        public abstract Int64 idfsLaboratorySection { get; set; }
        protected Int64 idfsLaboratorySection_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsLaboratorySection).OriginalValue; } }
        protected Int64 idfsLaboratorySection_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsLaboratorySection).PreviousValue; } }
                
        [LocalizedDisplayName(_str_bTestDeleted)]
        [MapField(_str_bTestDeleted)]
        public abstract Boolean bTestDeleted { get; set; }
        protected Boolean bTestDeleted_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._bTestDeleted).OriginalValue; } }
        protected Boolean bTestDeleted_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._bTestDeleted).PreviousValue; } }
                
        [LocalizedDisplayName(_str_bTestInserted)]
        [MapField(_str_bTestInserted)]
        public abstract Boolean bTestInserted { get; set; }
        protected Boolean bTestInserted_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._bTestInserted).OriginalValue; } }
        protected Boolean bTestInserted_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._bTestInserted).PreviousValue; } }
                
        [LocalizedDisplayName(_str_bTestInsertedFirst)]
        [MapField(_str_bTestInsertedFirst)]
        public abstract Boolean bTestInsertedFirst { get; set; }
        protected Boolean bTestInsertedFirst_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._bTestInsertedFirst).OriginalValue; } }
        protected Boolean bTestInsertedFirst_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._bTestInsertedFirst).PreviousValue; } }
                
        [LocalizedDisplayName(_str_bFilterTestByDiagnosis)]
        [MapField(_str_bFilterTestByDiagnosis)]
        public abstract Boolean bFilterTestByDiagnosis { get; set; }
        protected Boolean bFilterTestByDiagnosis_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._bFilterTestByDiagnosis).OriginalValue; } }
        protected Boolean bFilterTestByDiagnosis_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._bFilterTestByDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intNewSample)]
        [MapField(_str_intNewSample)]
        public abstract Int32? intNewSample { get; set; }
        protected Int32? intNewSample_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intNewSample).OriginalValue; } }
        protected Int32? intNewSample_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intNewSample).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSampleTypeFiltered)]
        [MapField(_str_idfsSampleTypeFiltered)]
        public abstract Int64? idfsSampleTypeFiltered { get; set; }
        protected Int64? idfsSampleTypeFiltered_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleTypeFiltered).OriginalValue; } }
        protected Int64? idfsSampleTypeFiltered_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleTypeFiltered).PreviousValue; } }
                
        [LocalizedDisplayName("strComment")]
        [MapField(_str_strComments)]
        public abstract String strComments { get; set; }
        protected String strComments_Original { get { return ((EditableValue<String>)((dynamic)this)._strComments).OriginalValue; } }
        protected String strComments_Previous { get { return ((EditableValue<String>)((dynamic)this)._strComments).PreviousValue; } }
                
        [LocalizedDisplayName("strReasonChangeTestResult")]
        [MapField(_str_strReason)]
        public abstract String strReason { get; set; }
        protected String strReason_Original { get { return ((EditableValue<String>)((dynamic)this)._strReason).OriginalValue; } }
        protected String strReason_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReason).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<LaboratorySectionItem, object> _get_func;
            internal Action<LaboratorySectionItem, string> _set_func;
            internal Action<LaboratorySectionItem, LaboratorySectionItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_ID = "ID";
        internal const string _str_idfTesting = "idfTesting";
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_idfSpeciesVectorInfo = "idfSpeciesVectorInfo";
        internal const string _str_idfCaseOrSession = "idfCaseOrSession";
        internal const string _str_idfsSampleStatus = "idfsSampleStatus";
        internal const string _str_datSampleStatusDate = "datSampleStatusDate";
        internal const string _str_idfsSampleType = "idfsSampleType";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_idfsShowDiagnosis = "idfsShowDiagnosis";
        internal const string _str_strDiagnosisName = "strDiagnosisName";
        internal const string _str_idfRootMaterial = "idfRootMaterial";
        internal const string _str_idfParentMaterial = "idfParentMaterial";
        internal const string _str_strParentMaterial = "strParentMaterial";
        internal const string _str_idfHuman = "idfHuman";
        internal const string _str_idfSpecies = "idfSpecies";
        internal const string _str_idfAnimal = "idfAnimal";
        internal const string _str_idfHumanCase = "idfHumanCase";
        internal const string _str_idfVetCase = "idfVetCase";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_idfMainTest = "idfMainTest";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfVector = "idfVector";
        internal const string _str_idfDestroyedByPerson = "idfDestroyedByPerson";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_datFieldSentDate = "datFieldSentDate";
        internal const string _str_strCalculatedCaseID = "strCalculatedCaseID";
        internal const string _str_strCalculatedHumanName = "strCalculatedHumanName";
        internal const string _str_idfAccesionByPerson = "idfAccesionByPerson";
        internal const string _str_idfsAccessionCondition = "idfsAccessionCondition";
        internal const string _str_datAccession = "datAccession";
        internal const string _str_datEnteringDate = "datEnteringDate";
        internal const string _str_datDestructionDate = "datDestructionDate";
        internal const string _str_idfSendToOffice = "idfSendToOffice";
        internal const string _str_idfSubdivision = "idfSubdivision";
        internal const string _str_idfInDepartment = "idfInDepartment";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_intCaseHACode = "intCaseHACode";
        internal const string _str_idfFieldCollectedByOffice = "idfFieldCollectedByOffice";
        internal const string _str_idfFieldCollectedByPerson = "idfFieldCollectedByPerson";
        internal const string _str_idfsDestructionMethod = "idfsDestructionMethod";
        internal const string _str_strSampleNote = "strSampleNote";
        internal const string _str_strCondition = "strCondition";
        internal const string _str_idfsSampleKind = "idfsSampleKind";
        internal const string _str_idfMarkedForDispositionByPerson = "idfMarkedForDispositionByPerson";
        internal const string _str_intTestCount = "intTestCount";
        internal const string _str_idfSendToOfficeOut = "idfSendToOfficeOut";
        internal const string _str_bExternalOffice = "bExternalOffice";
        internal const string _str_idfSendByPerson = "idfSendByPerson";
        internal const string _str_datSendDate = "datSendDate";
        internal const string _str_HumanName = "HumanName";
        internal const string _str_strPatientName = "strPatientName";
        internal const string _str_strFarmOwner = "strFarmOwner";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_strRegion = "strRegion";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_strRayon = "strRayon";
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_idfsTestName = "idfsTestName";
        internal const string _str_idfsTestCategory = "idfsTestCategory";
        internal const string _str_idfsTestStatus = "idfsTestStatus";
        internal const string _str_idfsTestResult = "idfsTestResult";
        internal const string _str_datStartedDate = "datStartedDate";
        internal const string _str_datConcludedDate = "datConcludedDate";
        internal const string _str_idfObservation = "idfObservation";
        internal const string _str_strNote = "strNote";
        internal const string _str_idfTestedByOffice = "idfTestedByOffice";
        internal const string _str_idfTestedByPerson = "idfTestedByPerson";
        internal const string _str_idfResultEnteredByOffice = "idfResultEnteredByOffice";
        internal const string _str_idfResultEnteredByPerson = "idfResultEnteredByPerson";
        internal const string _str_idfValidatedByOffice = "idfValidatedByOffice";
        internal const string _str_idfValidatedByPerson = "idfValidatedByPerson";
        internal const string _str_blnNonLaboratoryTest = "blnNonLaboratoryTest";
        internal const string _str_blnExternalTest = "blnExternalTest";
        internal const string _str_datReceivedDate = "datReceivedDate";
        internal const string _str_idfPerformedByOffice = "idfPerformedByOffice";
        internal const string _str_strContactPerson = "strContactPerson";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_strBatchID = "strBatchID";
        internal const string _str_strSampleStatus = "strSampleStatus";
        internal const string _str_strSampleName = "strSampleName";
        internal const string _str_strSampleConditionReceivedStatus = "strSampleConditionReceivedStatus";
        internal const string _str_strTestName = "strTestName";
        internal const string _str_strTestStatus = "strTestStatus";
        internal const string _str_strTestResult = "strTestResult";
        internal const string _str_strTestCategory = "strTestCategory";
        internal const string _str_idfsLaboratorySection = "idfsLaboratorySection";
        internal const string _str_bTestDeleted = "bTestDeleted";
        internal const string _str_bTestInserted = "bTestInserted";
        internal const string _str_bTestInsertedFirst = "bTestInsertedFirst";
        internal const string _str_bFilterTestByDiagnosis = "bFilterTestByDiagnosis";
        internal const string _str_intNewSample = "intNewSample";
        internal const string _str_idfsSampleTypeFiltered = "idfsSampleTypeFiltered";
        internal const string _str_strComments = "strComments";
        internal const string _str_strReason = "strReason";
        internal const string _str_bIsMyPref = "bIsMyPref";
        internal const string _str_intNewMode = "intNewMode";
        internal const string _str_bIsCreateNewSample = "bIsCreateNewSample";
        internal const string _str_idfsTestResultDummy = "idfsTestResultDummy";
        internal const string _str_idfsTestStatusDummy = "idfsTestStatusDummy";
        internal const string _str_idfDerivativeForSampleType = "idfDerivativeForSampleType";
        internal const string _str_idfsOldTestResult = "idfsOldTestResult";
        internal const string _str_idfsSampleStatusOriginalIsSaved = "idfsSampleStatusOriginalIsSaved";
        internal const string _str_idfsSampleStatusOriginalSaved = "idfsSampleStatusOriginalSaved";
        internal const string _str_idfsTestStatusOriginalIsSaved = "idfsTestStatusOriginalIsSaved";
        internal const string _str_idfsTestStatusOriginalSaved = "idfsTestStatusOriginalSaved";
        internal const string _str_idfsTestResultOriginalIsSaved = "idfsTestResultOriginalIsSaved";
        internal const string _str_idfsTestResultOriginalSaved = "idfsTestResultOriginalSaved";
        internal const string _str_idfsAccessionConditionOriginalIsSaved = "idfsAccessionConditionOriginalIsSaved";
        internal const string _str_idfsAccessionConditionOriginalSaved = "idfsAccessionConditionOriginalSaved";
        internal const string _str_idfSendToOfficeOutOriginalIsSaved = "idfSendToOfficeOutOriginalIsSaved";
        internal const string _str_idfSendToOfficeOutOriginalSaved = "idfSendToOfficeOutOriginalSaved";
        internal const string _str_strBarcodeOriginalIsSaved = "strBarcodeOriginalIsSaved";
        internal const string _str_strBarcodeOriginalSaved = "strBarcodeOriginalSaved";
        internal const string _str_idfsTestNamePreviousIsSaved = "idfsTestNamePreviousIsSaved";
        internal const string _str_idfsTestNamePreviousSaved = "idfsTestNamePreviousSaved";
        internal const string _str_idfsTestResultPreviousIsSaved = "idfsTestResultPreviousIsSaved";
        internal const string _str_idfsTestResultPreviousSaved = "idfsTestResultPreviousSaved";
        internal const string _str_blnExternalTestPreviousIsSaved = "blnExternalTestPreviousIsSaved";
        internal const string _str_blnExternalTestPreviousSaved = "blnExternalTestPreviousSaved";
        internal const string _str_idfsSampleStatusOriginal = "idfsSampleStatusOriginal";
        internal const string _str_idfsTestStatusOriginal = "idfsTestStatusOriginal";
        internal const string _str_idfsTestResultOriginal = "idfsTestResultOriginal";
        internal const string _str_idfsAccessionConditionOriginal = "idfsAccessionConditionOriginal";
        internal const string _str_idfSendToOfficeOutOriginal = "idfSendToOfficeOutOriginal";
        internal const string _str_strBarcodeOriginal = "strBarcodeOriginal";
        internal const string _str_idfsTestNamePrevious = "idfsTestNamePrevious";
        internal const string _str_idfsTestResultPrevious = "idfsTestResultPrevious";
        internal const string _str_blnExternalTestPrevious = "blnExternalTestPrevious";
        internal const string _str_isChanges = "isChanges";
        internal const string _str_strSendToOffice = "strSendToOffice";
        internal const string _str_strSendToOfficeOut = "strSendToOfficeOut";
        internal const string _str_strTestCount = "strTestCount";
        internal const string _str_strObservation = "strObservation";
        internal const string _str_isTestExists = "isTestExists";
        internal const string _str_isNotTestExistsWithAccessioned = "isNotTestExistsWithAccessioned";
        internal const string _str_isTestNotStartedBefore = "isTestNotStartedBefore";
        internal const string _str_isTestNotStartedAfter = "isTestNotStartedAfter";
        internal const string _str_isTestInProcessBefore = "isTestInProcessBefore";
        internal const string _str_isTestInProcessAfter = "isTestInProcessAfter";
        internal const string _str_isTestPreliminary = "isTestPreliminary";
        internal const string _str_isTestFinalInternalBefore = "isTestFinalInternalBefore";
        internal const string _str_isTestFinalInternalAfter = "isTestFinalInternalAfter";
        internal const string _str_isTestFinalExternalBefore = "isTestFinalExternalBefore";
        internal const string _str_isTestFinalOrAmend = "isTestFinalOrAmend";
        internal const string _str_isTestFinalOrAmendSaved = "isTestFinalOrAmendSaved";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_DiagnosisForTest = "DiagnosisForTest";
        internal const string _str_SampleType = "SampleType";
        internal const string _str_SampleTypeFiltered = "SampleTypeFiltered";
        internal const string _str_DerivativeType = "DerivativeType";
        internal const string _str_AccessionCondition = "AccessionCondition";
        internal const string _str_TestNameForSearch = "TestNameForSearch";
        internal const string _str_TestNameRef = "TestNameRef";
        internal const string _str_TestResultRef = "TestResultRef";
        internal const string _str_TestResultForAmend = "TestResultForAmend";
        internal const string _str_TestResultDummy = "TestResultDummy";
        internal const string _str_TestCategoryRef = "TestCategoryRef";
        internal const string _str_TestStatusShort = "TestStatusShort";
        internal const string _str_TestStatusForSearch = "TestStatusForSearch";
        internal const string _str_TestStatusFull = "TestStatusFull";
        internal const string _str_SampleStatus = "SampleStatus";
        internal const string _str_SampleStatusFull = "SampleStatusFull";
        internal const string _str_AccessionByPerson = "AccessionByPerson";
        internal const string _str_SendToOffice = "SendToOffice";
        internal const string _str_SendToOfficeOut = "SendToOfficeOut";
        internal const string _str_PerformedByOffice = "PerformedByOffice";
        internal const string _str_CollectedByOffice = "CollectedByOffice";
        internal const string _str_CollectedByPerson = "CollectedByPerson";
        internal const string _str_CaseType = "CaseType";
        internal const string _str_DestructionMethod = "DestructionMethod";
        internal const string _str_SampleKind = "SampleKind";
        internal const string _str_SpeciesVectorInfo = "SpeciesVectorInfo";
        internal const string _str_Department = "Department";
        internal const string _str_Freezer = "Freezer";
        internal const string _str_TestedByOffice = "TestedByOffice";
        internal const string _str_TestedByPerson = "TestedByPerson";
        internal const string _str_ResultEnteredByOffice = "ResultEnteredByOffice";
        internal const string _str_ResultEnteredByPerson = "ResultEnteredByPerson";
        internal const string _str_ValidatedByOffice = "ValidatedByOffice";
        internal const string _str_ValidatedByPerson = "ValidatedByPerson";
        internal const string _str_Sample = "Sample";
        internal const string _str_Test = "Test";
        internal const string _str_AmendmentHistory = "AmendmentHistory";
        internal const string _str_FFPresenter = "FFPresenter";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_ID, _formname = _str_ID, _type = "Int64",
              _get_func = o => o.ID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.ID != newval) o.ID = newval; },
              _compare_func = (o, c, m) => {
                if (o.ID != c.ID || o.IsRIRPropChanged(_str_ID, c)) 
                  m.Add(_str_ID, o.ObjectIdent + _str_ID, o.ObjectIdent2 + _str_ID, o.ObjectIdent3 + _str_ID, "Int64", 
                    o.ID == null ? "" : o.ID.ToString(),                  
                  o.IsReadOnly(_str_ID), o.IsInvisible(_str_ID), o.IsRequired(_str_ID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfTesting, _formname = _str_idfTesting, _type = "Int64?",
              _get_func = o => o.idfTesting,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfTesting != newval) o.idfTesting = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfTesting != c.idfTesting || o.IsRIRPropChanged(_str_idfTesting, c)) 
                  m.Add(_str_idfTesting, o.ObjectIdent + _str_idfTesting, o.ObjectIdent2 + _str_idfTesting, o.ObjectIdent3 + _str_idfTesting, "Int64?", 
                    o.idfTesting == null ? "" : o.idfTesting.ToString(),                  
                  o.IsReadOnly(_str_idfTesting), o.IsInvisible(_str_idfTesting), o.IsRequired(_str_idfTesting)); 
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
              _name = _str_idfSpeciesVectorInfo, _formname = _str_idfSpeciesVectorInfo, _type = "Int64?",
              _get_func = o => o.idfSpeciesVectorInfo,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfSpeciesVectorInfo != newval) 
                  o.SpeciesVectorInfo = o.SpeciesVectorInfoLookup.FirstOrDefault(c => c.idfSpeciesVectorInfo == newval);
                if (o.idfSpeciesVectorInfo != newval) o.idfSpeciesVectorInfo = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfSpeciesVectorInfo != c.idfSpeciesVectorInfo || o.IsRIRPropChanged(_str_idfSpeciesVectorInfo, c)) 
                  m.Add(_str_idfSpeciesVectorInfo, o.ObjectIdent + _str_idfSpeciesVectorInfo, o.ObjectIdent2 + _str_idfSpeciesVectorInfo, o.ObjectIdent3 + _str_idfSpeciesVectorInfo, "Int64?", 
                    o.idfSpeciesVectorInfo == null ? "" : o.idfSpeciesVectorInfo.ToString(),                  
                  o.IsReadOnly(_str_idfSpeciesVectorInfo), o.IsInvisible(_str_idfSpeciesVectorInfo), o.IsRequired(_str_idfSpeciesVectorInfo)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfCaseOrSession, _formname = _str_idfCaseOrSession, _type = "Int64?",
              _get_func = o => o.idfCaseOrSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfCaseOrSession != newval) o.idfCaseOrSession = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfCaseOrSession != c.idfCaseOrSession || o.IsRIRPropChanged(_str_idfCaseOrSession, c)) 
                  m.Add(_str_idfCaseOrSession, o.ObjectIdent + _str_idfCaseOrSession, o.ObjectIdent2 + _str_idfCaseOrSession, o.ObjectIdent3 + _str_idfCaseOrSession, "Int64?", 
                    o.idfCaseOrSession == null ? "" : o.idfCaseOrSession.ToString(),                  
                  o.IsReadOnly(_str_idfCaseOrSession), o.IsInvisible(_str_idfCaseOrSession), o.IsRequired(_str_idfCaseOrSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSampleStatus, _formname = _str_idfsSampleStatus, _type = "Int64",
              _get_func = o => o.idfsSampleStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsSampleStatus != newval) 
                  o.SampleStatus = o.SampleStatusLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsSampleStatus != newval) o.idfsSampleStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSampleStatus != c.idfsSampleStatus || o.IsRIRPropChanged(_str_idfsSampleStatus, c)) 
                  m.Add(_str_idfsSampleStatus, o.ObjectIdent + _str_idfsSampleStatus, o.ObjectIdent2 + _str_idfsSampleStatus, o.ObjectIdent3 + _str_idfsSampleStatus, "Int64", 
                    o.idfsSampleStatus == null ? "" : o.idfsSampleStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsSampleStatus), o.IsInvisible(_str_idfsSampleStatus), o.IsRequired(_str_idfsSampleStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datSampleStatusDate, _formname = _str_datSampleStatusDate, _type = "DateTime?",
              _get_func = o => o.datSampleStatusDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datSampleStatusDate != newval) o.datSampleStatusDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datSampleStatusDate != c.datSampleStatusDate || o.IsRIRPropChanged(_str_datSampleStatusDate, c)) 
                  m.Add(_str_datSampleStatusDate, o.ObjectIdent + _str_datSampleStatusDate, o.ObjectIdent2 + _str_datSampleStatusDate, o.ObjectIdent3 + _str_datSampleStatusDate, "DateTime?", 
                    o.datSampleStatusDate == null ? "" : o.datSampleStatusDate.ToString(),                  
                  o.IsReadOnly(_str_datSampleStatusDate), o.IsInvisible(_str_datSampleStatusDate), o.IsRequired(_str_datSampleStatusDate)); 
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
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsDiagnosis != newval) 
                  o.Diagnosis = o.DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis, "Int64?", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); 
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
              _name = _str_strDiagnosisName, _formname = _str_strDiagnosisName, _type = "String",
              _get_func = o => o.strDiagnosisName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDiagnosisName != newval) o.strDiagnosisName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDiagnosisName != c.strDiagnosisName || o.IsRIRPropChanged(_str_strDiagnosisName, c)) 
                  m.Add(_str_strDiagnosisName, o.ObjectIdent + _str_strDiagnosisName, o.ObjectIdent2 + _str_strDiagnosisName, o.ObjectIdent3 + _str_strDiagnosisName, "String", 
                    o.strDiagnosisName == null ? "" : o.strDiagnosisName.ToString(),                  
                  o.IsReadOnly(_str_strDiagnosisName), o.IsInvisible(_str_strDiagnosisName), o.IsRequired(_str_strDiagnosisName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfRootMaterial, _formname = _str_idfRootMaterial, _type = "Int64?",
              _get_func = o => o.idfRootMaterial,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfRootMaterial != newval) o.idfRootMaterial = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfRootMaterial != c.idfRootMaterial || o.IsRIRPropChanged(_str_idfRootMaterial, c)) 
                  m.Add(_str_idfRootMaterial, o.ObjectIdent + _str_idfRootMaterial, o.ObjectIdent2 + _str_idfRootMaterial, o.ObjectIdent3 + _str_idfRootMaterial, "Int64?", 
                    o.idfRootMaterial == null ? "" : o.idfRootMaterial.ToString(),                  
                  o.IsReadOnly(_str_idfRootMaterial), o.IsInvisible(_str_idfRootMaterial), o.IsRequired(_str_idfRootMaterial)); 
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
              _name = _str_strParentMaterial, _formname = _str_strParentMaterial, _type = "String",
              _get_func = o => o.strParentMaterial,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strParentMaterial != newval) o.strParentMaterial = newval; },
              _compare_func = (o, c, m) => {
                if (o.strParentMaterial != c.strParentMaterial || o.IsRIRPropChanged(_str_strParentMaterial, c)) 
                  m.Add(_str_strParentMaterial, o.ObjectIdent + _str_strParentMaterial, o.ObjectIdent2 + _str_strParentMaterial, o.ObjectIdent3 + _str_strParentMaterial, "String", 
                    o.strParentMaterial == null ? "" : o.strParentMaterial.ToString(),                  
                  o.IsReadOnly(_str_strParentMaterial), o.IsInvisible(_str_strParentMaterial), o.IsRequired(_str_strParentMaterial)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfHuman, _formname = _str_idfHuman, _type = "Int64?",
              _get_func = o => o.idfHuman,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfHuman != newval) o.idfHuman = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfHuman != c.idfHuman || o.IsRIRPropChanged(_str_idfHuman, c)) 
                  m.Add(_str_idfHuman, o.ObjectIdent + _str_idfHuman, o.ObjectIdent2 + _str_idfHuman, o.ObjectIdent3 + _str_idfHuman, "Int64?", 
                    o.idfHuman == null ? "" : o.idfHuman.ToString(),                  
                  o.IsReadOnly(_str_idfHuman), o.IsInvisible(_str_idfHuman), o.IsRequired(_str_idfHuman)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSpecies, _formname = _str_idfSpecies, _type = "Int64?",
              _get_func = o => o.idfSpecies,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfSpecies != newval) o.idfSpecies = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfSpecies != c.idfSpecies || o.IsRIRPropChanged(_str_idfSpecies, c)) 
                  m.Add(_str_idfSpecies, o.ObjectIdent + _str_idfSpecies, o.ObjectIdent2 + _str_idfSpecies, o.ObjectIdent3 + _str_idfSpecies, "Int64?", 
                    o.idfSpecies == null ? "" : o.idfSpecies.ToString(),                  
                  o.IsReadOnly(_str_idfSpecies), o.IsInvisible(_str_idfSpecies), o.IsRequired(_str_idfSpecies)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfAnimal, _formname = _str_idfAnimal, _type = "Int64?",
              _get_func = o => o.idfAnimal,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfAnimal != newval) o.idfAnimal = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfAnimal != c.idfAnimal || o.IsRIRPropChanged(_str_idfAnimal, c)) 
                  m.Add(_str_idfAnimal, o.ObjectIdent + _str_idfAnimal, o.ObjectIdent2 + _str_idfAnimal, o.ObjectIdent3 + _str_idfAnimal, "Int64?", 
                    o.idfAnimal == null ? "" : o.idfAnimal.ToString(),                  
                  o.IsReadOnly(_str_idfAnimal), o.IsInvisible(_str_idfAnimal), o.IsRequired(_str_idfAnimal)); 
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
              _name = _str_idfMainTest, _formname = _str_idfMainTest, _type = "Int64?",
              _get_func = o => o.idfMainTest,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfMainTest != newval) o.idfMainTest = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfMainTest != c.idfMainTest || o.IsRIRPropChanged(_str_idfMainTest, c)) 
                  m.Add(_str_idfMainTest, o.ObjectIdent + _str_idfMainTest, o.ObjectIdent2 + _str_idfMainTest, o.ObjectIdent3 + _str_idfMainTest, "Int64?", 
                    o.idfMainTest == null ? "" : o.idfMainTest.ToString(),                  
                  o.IsReadOnly(_str_idfMainTest), o.IsInvisible(_str_idfMainTest), o.IsRequired(_str_idfMainTest)); 
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
              _name = _str_idfVector, _formname = _str_idfVector, _type = "Int64?",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfVector != newval) o.idfVector = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) 
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, o.ObjectIdent2 + _str_idfVector, o.ObjectIdent3 + _str_idfVector, "Int64?", 
                    o.idfVector == null ? "" : o.idfVector.ToString(),                  
                  o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfDestroyedByPerson, _formname = _str_idfDestroyedByPerson, _type = "Int64?",
              _get_func = o => o.idfDestroyedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfDestroyedByPerson != newval) o.idfDestroyedByPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfDestroyedByPerson != c.idfDestroyedByPerson || o.IsRIRPropChanged(_str_idfDestroyedByPerson, c)) 
                  m.Add(_str_idfDestroyedByPerson, o.ObjectIdent + _str_idfDestroyedByPerson, o.ObjectIdent2 + _str_idfDestroyedByPerson, o.ObjectIdent3 + _str_idfDestroyedByPerson, "Int64?", 
                    o.idfDestroyedByPerson == null ? "" : o.idfDestroyedByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfDestroyedByPerson), o.IsInvisible(_str_idfDestroyedByPerson), o.IsRequired(_str_idfDestroyedByPerson)); 
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
              _name = _str_datFieldSentDate, _formname = _str_datFieldSentDate, _type = "DateTime?",
              _get_func = o => o.datFieldSentDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datFieldSentDate != newval) o.datFieldSentDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datFieldSentDate != c.datFieldSentDate || o.IsRIRPropChanged(_str_datFieldSentDate, c)) 
                  m.Add(_str_datFieldSentDate, o.ObjectIdent + _str_datFieldSentDate, o.ObjectIdent2 + _str_datFieldSentDate, o.ObjectIdent3 + _str_datFieldSentDate, "DateTime?", 
                    o.datFieldSentDate == null ? "" : o.datFieldSentDate.ToString(),                  
                  o.IsReadOnly(_str_datFieldSentDate), o.IsInvisible(_str_datFieldSentDate), o.IsRequired(_str_datFieldSentDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCalculatedCaseID, _formname = _str_strCalculatedCaseID, _type = "String",
              _get_func = o => o.strCalculatedCaseID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCalculatedCaseID != newval) o.strCalculatedCaseID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strCalculatedCaseID != c.strCalculatedCaseID || o.IsRIRPropChanged(_str_strCalculatedCaseID, c)) 
                  m.Add(_str_strCalculatedCaseID, o.ObjectIdent + _str_strCalculatedCaseID, o.ObjectIdent2 + _str_strCalculatedCaseID, o.ObjectIdent3 + _str_strCalculatedCaseID, "String", 
                    o.strCalculatedCaseID == null ? "" : o.strCalculatedCaseID.ToString(),                  
                  o.IsReadOnly(_str_strCalculatedCaseID), o.IsInvisible(_str_strCalculatedCaseID), o.IsRequired(_str_strCalculatedCaseID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCalculatedHumanName, _formname = _str_strCalculatedHumanName, _type = "String",
              _get_func = o => o.strCalculatedHumanName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCalculatedHumanName != newval) o.strCalculatedHumanName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strCalculatedHumanName != c.strCalculatedHumanName || o.IsRIRPropChanged(_str_strCalculatedHumanName, c)) 
                  m.Add(_str_strCalculatedHumanName, o.ObjectIdent + _str_strCalculatedHumanName, o.ObjectIdent2 + _str_strCalculatedHumanName, o.ObjectIdent3 + _str_strCalculatedHumanName, "String", 
                    o.strCalculatedHumanName == null ? "" : o.strCalculatedHumanName.ToString(),                  
                  o.IsReadOnly(_str_strCalculatedHumanName), o.IsInvisible(_str_strCalculatedHumanName), o.IsRequired(_str_strCalculatedHumanName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfAccesionByPerson, _formname = _str_idfAccesionByPerson, _type = "Int64?",
              _get_func = o => o.idfAccesionByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfAccesionByPerson != newval) 
                  o.AccessionByPerson = o.AccessionByPersonLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfAccesionByPerson != newval) o.idfAccesionByPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfAccesionByPerson != c.idfAccesionByPerson || o.IsRIRPropChanged(_str_idfAccesionByPerson, c)) 
                  m.Add(_str_idfAccesionByPerson, o.ObjectIdent + _str_idfAccesionByPerson, o.ObjectIdent2 + _str_idfAccesionByPerson, o.ObjectIdent3 + _str_idfAccesionByPerson, "Int64?", 
                    o.idfAccesionByPerson == null ? "" : o.idfAccesionByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfAccesionByPerson), o.IsInvisible(_str_idfAccesionByPerson), o.IsRequired(_str_idfAccesionByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAccessionCondition, _formname = _str_idfsAccessionCondition, _type = "Int64?",
              _get_func = o => o.idfsAccessionCondition,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsAccessionCondition != newval) 
                  o.AccessionCondition = o.AccessionConditionLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsAccessionCondition != newval) o.idfsAccessionCondition = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsAccessionCondition != c.idfsAccessionCondition || o.IsRIRPropChanged(_str_idfsAccessionCondition, c)) 
                  m.Add(_str_idfsAccessionCondition, o.ObjectIdent + _str_idfsAccessionCondition, o.ObjectIdent2 + _str_idfsAccessionCondition, o.ObjectIdent3 + _str_idfsAccessionCondition, "Int64?", 
                    o.idfsAccessionCondition == null ? "" : o.idfsAccessionCondition.ToString(),                  
                  o.IsReadOnly(_str_idfsAccessionCondition), o.IsInvisible(_str_idfsAccessionCondition), o.IsRequired(_str_idfsAccessionCondition)); 
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
              _name = _str_datEnteringDate, _formname = _str_datEnteringDate, _type = "DateTime?",
              _get_func = o => o.datEnteringDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datEnteringDate != newval) o.datEnteringDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datEnteringDate != c.datEnteringDate || o.IsRIRPropChanged(_str_datEnteringDate, c)) 
                  m.Add(_str_datEnteringDate, o.ObjectIdent + _str_datEnteringDate, o.ObjectIdent2 + _str_datEnteringDate, o.ObjectIdent3 + _str_datEnteringDate, "DateTime?", 
                    o.datEnteringDate == null ? "" : o.datEnteringDate.ToString(),                  
                  o.IsReadOnly(_str_datEnteringDate), o.IsInvisible(_str_datEnteringDate), o.IsRequired(_str_datEnteringDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDestructionDate, _formname = _str_datDestructionDate, _type = "DateTime?",
              _get_func = o => o.datDestructionDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDestructionDate != newval) o.datDestructionDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datDestructionDate != c.datDestructionDate || o.IsRIRPropChanged(_str_datDestructionDate, c)) 
                  m.Add(_str_datDestructionDate, o.ObjectIdent + _str_datDestructionDate, o.ObjectIdent2 + _str_datDestructionDate, o.ObjectIdent3 + _str_datDestructionDate, "DateTime?", 
                    o.datDestructionDate == null ? "" : o.datDestructionDate.ToString(),                  
                  o.IsReadOnly(_str_datDestructionDate), o.IsInvisible(_str_datDestructionDate), o.IsRequired(_str_datDestructionDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSendToOffice, _formname = _str_idfSendToOffice, _type = "Int64?",
              _get_func = o => o.idfSendToOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfSendToOffice != newval) 
                  o.SendToOffice = o.SendToOfficeLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfSendToOffice != newval) o.idfSendToOffice = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfSendToOffice != c.idfSendToOffice || o.IsRIRPropChanged(_str_idfSendToOffice, c)) 
                  m.Add(_str_idfSendToOffice, o.ObjectIdent + _str_idfSendToOffice, o.ObjectIdent2 + _str_idfSendToOffice, o.ObjectIdent3 + _str_idfSendToOffice, "Int64?", 
                    o.idfSendToOffice == null ? "" : o.idfSendToOffice.ToString(),                  
                  o.IsReadOnly(_str_idfSendToOffice), o.IsInvisible(_str_idfSendToOffice), o.IsRequired(_str_idfSendToOffice)); 
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
              _name = _str_idfsCaseType, _formname = _str_idfsCaseType, _type = "Int64?",
              _get_func = o => o.idfsCaseType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsCaseType != newval) 
                  o.CaseType = o.CaseTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsCaseType != newval) o.idfsCaseType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_idfsCaseType, c)) 
                  m.Add(_str_idfsCaseType, o.ObjectIdent + _str_idfsCaseType, o.ObjectIdent2 + _str_idfsCaseType, o.ObjectIdent3 + _str_idfsCaseType, "Int64?", 
                    o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseType), o.IsInvisible(_str_idfsCaseType), o.IsRequired(_str_idfsCaseType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intCaseHACode, _formname = _str_intCaseHACode, _type = "Int32?",
              _get_func = o => o.intCaseHACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intCaseHACode != newval) o.intCaseHACode = newval; },
              _compare_func = (o, c, m) => {
                if (o.intCaseHACode != c.intCaseHACode || o.IsRIRPropChanged(_str_intCaseHACode, c)) 
                  m.Add(_str_intCaseHACode, o.ObjectIdent + _str_intCaseHACode, o.ObjectIdent2 + _str_intCaseHACode, o.ObjectIdent3 + _str_intCaseHACode, "Int32?", 
                    o.intCaseHACode == null ? "" : o.intCaseHACode.ToString(),                  
                  o.IsReadOnly(_str_intCaseHACode), o.IsInvisible(_str_intCaseHACode), o.IsRequired(_str_intCaseHACode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfFieldCollectedByOffice, _formname = _str_idfFieldCollectedByOffice, _type = "Int64?",
              _get_func = o => o.idfFieldCollectedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfFieldCollectedByOffice != newval) 
                  o.CollectedByOffice = o.CollectedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfFieldCollectedByOffice != newval) o.idfFieldCollectedByOffice = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfFieldCollectedByOffice != c.idfFieldCollectedByOffice || o.IsRIRPropChanged(_str_idfFieldCollectedByOffice, c)) 
                  m.Add(_str_idfFieldCollectedByOffice, o.ObjectIdent + _str_idfFieldCollectedByOffice, o.ObjectIdent2 + _str_idfFieldCollectedByOffice, o.ObjectIdent3 + _str_idfFieldCollectedByOffice, "Int64?", 
                    o.idfFieldCollectedByOffice == null ? "" : o.idfFieldCollectedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfFieldCollectedByOffice), o.IsInvisible(_str_idfFieldCollectedByOffice), o.IsRequired(_str_idfFieldCollectedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfFieldCollectedByPerson, _formname = _str_idfFieldCollectedByPerson, _type = "Int64?",
              _get_func = o => o.idfFieldCollectedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfFieldCollectedByPerson != newval) 
                  o.CollectedByPerson = o.CollectedByPersonLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfFieldCollectedByPerson != newval) o.idfFieldCollectedByPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfFieldCollectedByPerson != c.idfFieldCollectedByPerson || o.IsRIRPropChanged(_str_idfFieldCollectedByPerson, c)) 
                  m.Add(_str_idfFieldCollectedByPerson, o.ObjectIdent + _str_idfFieldCollectedByPerson, o.ObjectIdent2 + _str_idfFieldCollectedByPerson, o.ObjectIdent3 + _str_idfFieldCollectedByPerson, "Int64?", 
                    o.idfFieldCollectedByPerson == null ? "" : o.idfFieldCollectedByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfFieldCollectedByPerson), o.IsInvisible(_str_idfFieldCollectedByPerson), o.IsRequired(_str_idfFieldCollectedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDestructionMethod, _formname = _str_idfsDestructionMethod, _type = "Int64?",
              _get_func = o => o.idfsDestructionMethod,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsDestructionMethod != newval) 
                  o.DestructionMethod = o.DestructionMethodLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsDestructionMethod != newval) o.idfsDestructionMethod = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDestructionMethod != c.idfsDestructionMethod || o.IsRIRPropChanged(_str_idfsDestructionMethod, c)) 
                  m.Add(_str_idfsDestructionMethod, o.ObjectIdent + _str_idfsDestructionMethod, o.ObjectIdent2 + _str_idfsDestructionMethod, o.ObjectIdent3 + _str_idfsDestructionMethod, "Int64?", 
                    o.idfsDestructionMethod == null ? "" : o.idfsDestructionMethod.ToString(),                  
                  o.IsReadOnly(_str_idfsDestructionMethod), o.IsInvisible(_str_idfsDestructionMethod), o.IsRequired(_str_idfsDestructionMethod)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSampleNote, _formname = _str_strSampleNote, _type = "String",
              _get_func = o => o.strSampleNote,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSampleNote != newval) o.strSampleNote = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSampleNote != c.strSampleNote || o.IsRIRPropChanged(_str_strSampleNote, c)) 
                  m.Add(_str_strSampleNote, o.ObjectIdent + _str_strSampleNote, o.ObjectIdent2 + _str_strSampleNote, o.ObjectIdent3 + _str_strSampleNote, "String", 
                    o.strSampleNote == null ? "" : o.strSampleNote.ToString(),                  
                  o.IsReadOnly(_str_strSampleNote), o.IsInvisible(_str_strSampleNote), o.IsRequired(_str_strSampleNote)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCondition, _formname = _str_strCondition, _type = "String",
              _get_func = o => o.strCondition,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCondition != newval) o.strCondition = newval; },
              _compare_func = (o, c, m) => {
                if (o.strCondition != c.strCondition || o.IsRIRPropChanged(_str_strCondition, c)) 
                  m.Add(_str_strCondition, o.ObjectIdent + _str_strCondition, o.ObjectIdent2 + _str_strCondition, o.ObjectIdent3 + _str_strCondition, "String", 
                    o.strCondition == null ? "" : o.strCondition.ToString(),                  
                  o.IsReadOnly(_str_strCondition), o.IsInvisible(_str_strCondition), o.IsRequired(_str_strCondition)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSampleKind, _formname = _str_idfsSampleKind, _type = "Int64?",
              _get_func = o => o.idfsSampleKind,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsSampleKind != newval) 
                  o.SampleKind = o.SampleKindLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsSampleKind != newval) o.idfsSampleKind = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSampleKind != c.idfsSampleKind || o.IsRIRPropChanged(_str_idfsSampleKind, c)) 
                  m.Add(_str_idfsSampleKind, o.ObjectIdent + _str_idfsSampleKind, o.ObjectIdent2 + _str_idfsSampleKind, o.ObjectIdent3 + _str_idfsSampleKind, "Int64?", 
                    o.idfsSampleKind == null ? "" : o.idfsSampleKind.ToString(),                  
                  o.IsReadOnly(_str_idfsSampleKind), o.IsInvisible(_str_idfsSampleKind), o.IsRequired(_str_idfsSampleKind)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfMarkedForDispositionByPerson, _formname = _str_idfMarkedForDispositionByPerson, _type = "Int64?",
              _get_func = o => o.idfMarkedForDispositionByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfMarkedForDispositionByPerson != newval) o.idfMarkedForDispositionByPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfMarkedForDispositionByPerson != c.idfMarkedForDispositionByPerson || o.IsRIRPropChanged(_str_idfMarkedForDispositionByPerson, c)) 
                  m.Add(_str_idfMarkedForDispositionByPerson, o.ObjectIdent + _str_idfMarkedForDispositionByPerson, o.ObjectIdent2 + _str_idfMarkedForDispositionByPerson, o.ObjectIdent3 + _str_idfMarkedForDispositionByPerson, "Int64?", 
                    o.idfMarkedForDispositionByPerson == null ? "" : o.idfMarkedForDispositionByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfMarkedForDispositionByPerson), o.IsInvisible(_str_idfMarkedForDispositionByPerson), o.IsRequired(_str_idfMarkedForDispositionByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intTestCount, _formname = _str_intTestCount, _type = "Int32?",
              _get_func = o => o.intTestCount,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intTestCount != newval) o.intTestCount = newval; },
              _compare_func = (o, c, m) => {
                if (o.intTestCount != c.intTestCount || o.IsRIRPropChanged(_str_intTestCount, c)) 
                  m.Add(_str_intTestCount, o.ObjectIdent + _str_intTestCount, o.ObjectIdent2 + _str_intTestCount, o.ObjectIdent3 + _str_intTestCount, "Int32?", 
                    o.intTestCount == null ? "" : o.intTestCount.ToString(),                  
                  o.IsReadOnly(_str_intTestCount), o.IsInvisible(_str_intTestCount), o.IsRequired(_str_intTestCount)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSendToOfficeOut, _formname = _str_idfSendToOfficeOut, _type = "Int64?",
              _get_func = o => o.idfSendToOfficeOut,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfSendToOfficeOut != newval) 
                  o.SendToOfficeOut = o.SendToOfficeOutLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfSendToOfficeOut != newval) o.idfSendToOfficeOut = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfSendToOfficeOut != c.idfSendToOfficeOut || o.IsRIRPropChanged(_str_idfSendToOfficeOut, c)) 
                  m.Add(_str_idfSendToOfficeOut, o.ObjectIdent + _str_idfSendToOfficeOut, o.ObjectIdent2 + _str_idfSendToOfficeOut, o.ObjectIdent3 + _str_idfSendToOfficeOut, "Int64?", 
                    o.idfSendToOfficeOut == null ? "" : o.idfSendToOfficeOut.ToString(),                  
                  o.IsReadOnly(_str_idfSendToOfficeOut), o.IsInvisible(_str_idfSendToOfficeOut), o.IsRequired(_str_idfSendToOfficeOut)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_bExternalOffice, _formname = _str_bExternalOffice, _type = "Boolean?",
              _get_func = o => o.bExternalOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.bExternalOffice != newval) o.bExternalOffice = newval; },
              _compare_func = (o, c, m) => {
                if (o.bExternalOffice != c.bExternalOffice || o.IsRIRPropChanged(_str_bExternalOffice, c)) 
                  m.Add(_str_bExternalOffice, o.ObjectIdent + _str_bExternalOffice, o.ObjectIdent2 + _str_bExternalOffice, o.ObjectIdent3 + _str_bExternalOffice, "Boolean?", 
                    o.bExternalOffice == null ? "" : o.bExternalOffice.ToString(),                  
                  o.IsReadOnly(_str_bExternalOffice), o.IsInvisible(_str_bExternalOffice), o.IsRequired(_str_bExternalOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSendByPerson, _formname = _str_idfSendByPerson, _type = "Int64?",
              _get_func = o => o.idfSendByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfSendByPerson != newval) o.idfSendByPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfSendByPerson != c.idfSendByPerson || o.IsRIRPropChanged(_str_idfSendByPerson, c)) 
                  m.Add(_str_idfSendByPerson, o.ObjectIdent + _str_idfSendByPerson, o.ObjectIdent2 + _str_idfSendByPerson, o.ObjectIdent3 + _str_idfSendByPerson, "Int64?", 
                    o.idfSendByPerson == null ? "" : o.idfSendByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfSendByPerson), o.IsInvisible(_str_idfSendByPerson), o.IsRequired(_str_idfSendByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datSendDate, _formname = _str_datSendDate, _type = "DateTime?",
              _get_func = o => o.datSendDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datSendDate != newval) o.datSendDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datSendDate != c.datSendDate || o.IsRIRPropChanged(_str_datSendDate, c)) 
                  m.Add(_str_datSendDate, o.ObjectIdent + _str_datSendDate, o.ObjectIdent2 + _str_datSendDate, o.ObjectIdent3 + _str_datSendDate, "DateTime?", 
                    o.datSendDate == null ? "" : o.datSendDate.ToString(),                  
                  o.IsReadOnly(_str_datSendDate), o.IsInvisible(_str_datSendDate), o.IsRequired(_str_datSendDate)); 
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
              _name = _str_idfsCountry, _formname = _str_idfsCountry, _type = "Int64?",
              _get_func = o => o.idfsCountry,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsCountry != newval) o.idfsCountry = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_idfsCountry, c)) 
                  m.Add(_str_idfsCountry, o.ObjectIdent + _str_idfsCountry, o.ObjectIdent2 + _str_idfsCountry, o.ObjectIdent3 + _str_idfsCountry, "Int64?", 
                    o.idfsCountry == null ? "" : o.idfsCountry.ToString(),                  
                  o.IsReadOnly(_str_idfsCountry), o.IsInvisible(_str_idfsCountry), o.IsRequired(_str_idfsCountry)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsRegion, _formname = _str_idfsRegion, _type = "Int64?",
              _get_func = o => o.idfsRegion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsRegion != newval) 
                  o.Region = o.RegionLookup.FirstOrDefault(c => c.idfsRegion == newval);
                if (o.idfsRegion != newval) o.idfsRegion = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_idfsRegion, c)) 
                  m.Add(_str_idfsRegion, o.ObjectIdent + _str_idfsRegion, o.ObjectIdent2 + _str_idfsRegion, o.ObjectIdent3 + _str_idfsRegion, "Int64?", 
                    o.idfsRegion == null ? "" : o.idfsRegion.ToString(),                  
                  o.IsReadOnly(_str_idfsRegion), o.IsInvisible(_str_idfsRegion), o.IsRequired(_str_idfsRegion)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRegion, _formname = _str_strRegion, _type = "String",
              _get_func = o => o.strRegion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRegion != newval) o.strRegion = newval; },
              _compare_func = (o, c, m) => {
                if (o.strRegion != c.strRegion || o.IsRIRPropChanged(_str_strRegion, c)) 
                  m.Add(_str_strRegion, o.ObjectIdent + _str_strRegion, o.ObjectIdent2 + _str_strRegion, o.ObjectIdent3 + _str_strRegion, "String", 
                    o.strRegion == null ? "" : o.strRegion.ToString(),                  
                  o.IsReadOnly(_str_strRegion), o.IsInvisible(_str_strRegion), o.IsRequired(_str_strRegion)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsRayon, _formname = _str_idfsRayon, _type = "Int64?",
              _get_func = o => o.idfsRayon,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsRayon != newval) 
                  o.Rayon = o.RayonLookup.FirstOrDefault(c => c.idfsRayon == newval);
                if (o.idfsRayon != newval) o.idfsRayon = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_idfsRayon, c)) 
                  m.Add(_str_idfsRayon, o.ObjectIdent + _str_idfsRayon, o.ObjectIdent2 + _str_idfsRayon, o.ObjectIdent3 + _str_idfsRayon, "Int64?", 
                    o.idfsRayon == null ? "" : o.idfsRayon.ToString(),                  
                  o.IsReadOnly(_str_idfsRayon), o.IsInvisible(_str_idfsRayon), o.IsRequired(_str_idfsRayon)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRayon, _formname = _str_strRayon, _type = "String",
              _get_func = o => o.strRayon,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRayon != newval) o.strRayon = newval; },
              _compare_func = (o, c, m) => {
                if (o.strRayon != c.strRayon || o.IsRIRPropChanged(_str_strRayon, c)) 
                  m.Add(_str_strRayon, o.ObjectIdent + _str_strRayon, o.ObjectIdent2 + _str_strRayon, o.ObjectIdent3 + _str_strRayon, "String", 
                    o.strRayon == null ? "" : o.strRayon.ToString(),                  
                  o.IsReadOnly(_str_strRayon), o.IsInvisible(_str_strRayon), o.IsRequired(_str_strRayon)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSettlement, _formname = _str_idfsSettlement, _type = "Int64?",
              _get_func = o => o.idfsSettlement,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSettlement != newval) o.idfsSettlement = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_idfsSettlement, c)) 
                  m.Add(_str_idfsSettlement, o.ObjectIdent + _str_idfsSettlement, o.ObjectIdent2 + _str_idfsSettlement, o.ObjectIdent3 + _str_idfsSettlement, "Int64?", 
                    o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(),                  
                  o.IsReadOnly(_str_idfsSettlement), o.IsInvisible(_str_idfsSettlement), o.IsRequired(_str_idfsSettlement)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTestName, _formname = _str_idfsTestName, _type = "Int64?",
              _get_func = o => o.idfsTestName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsTestName != newval) 
                  o.TestNameForSearch = o.TestNameForSearchLookup.FirstOrDefault(c => c.idfsReference == newval);
                if (o.idfsTestName != newval) o.idfsTestName = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsTestName != c.idfsTestName || o.IsRIRPropChanged(_str_idfsTestName, c)) 
                  m.Add(_str_idfsTestName, o.ObjectIdent + _str_idfsTestName, o.ObjectIdent2 + _str_idfsTestName, o.ObjectIdent3 + _str_idfsTestName, "Int64?", 
                    o.idfsTestName == null ? "" : o.idfsTestName.ToString(),                  
                  o.IsReadOnly(_str_idfsTestName), o.IsInvisible(_str_idfsTestName), o.IsRequired(_str_idfsTestName)); 
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
              _name = _str_idfsTestStatus, _formname = _str_idfsTestStatus, _type = "Int64?",
              _get_func = o => o.idfsTestStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsTestStatus != newval) 
                  o.TestStatusFull = o.TestStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsTestStatus != newval) o.idfsTestStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsTestStatus != c.idfsTestStatus || o.IsRIRPropChanged(_str_idfsTestStatus, c)) 
                  m.Add(_str_idfsTestStatus, o.ObjectIdent + _str_idfsTestStatus, o.ObjectIdent2 + _str_idfsTestStatus, o.ObjectIdent3 + _str_idfsTestStatus, "Int64?", 
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
              _name = _str_idfObservation, _formname = _str_idfObservation, _type = "Int64?",
              _get_func = o => o.idfObservation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfObservation != newval) o.idfObservation = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfObservation != c.idfObservation || o.IsRIRPropChanged(_str_idfObservation, c)) 
                  m.Add(_str_idfObservation, o.ObjectIdent + _str_idfObservation, o.ObjectIdent2 + _str_idfObservation, o.ObjectIdent3 + _str_idfObservation, "Int64?", 
                    o.idfObservation == null ? "" : o.idfObservation.ToString(),                  
                  o.IsReadOnly(_str_idfObservation), o.IsInvisible(_str_idfObservation), o.IsRequired(_str_idfObservation)); 
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfTestedByOffice != newval) 
                  o.TestedByOffice = o.TestedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfTestedByOffice != newval) o.idfTestedByOffice = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfTestedByPerson != newval) 
                  o.TestedByPerson = o.TestedByPersonLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfTestedByPerson != newval) o.idfTestedByPerson = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfResultEnteredByOffice != newval) 
                  o.ResultEnteredByOffice = o.ResultEnteredByOfficeLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfResultEnteredByOffice != newval) o.idfResultEnteredByOffice = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfResultEnteredByPerson != newval) 
                  o.ResultEnteredByPerson = o.ResultEnteredByPersonLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfResultEnteredByPerson != newval) o.idfResultEnteredByPerson = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfValidatedByOffice != newval) 
                  o.ValidatedByOffice = o.ValidatedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfValidatedByOffice != newval) o.idfValidatedByOffice = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfValidatedByPerson != newval) 
                  o.ValidatedByPerson = o.ValidatedByPersonLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfValidatedByPerson != newval) o.idfValidatedByPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfValidatedByPerson != c.idfValidatedByPerson || o.IsRIRPropChanged(_str_idfValidatedByPerson, c)) 
                  m.Add(_str_idfValidatedByPerson, o.ObjectIdent + _str_idfValidatedByPerson, o.ObjectIdent2 + _str_idfValidatedByPerson, o.ObjectIdent3 + _str_idfValidatedByPerson, "Int64?", 
                    o.idfValidatedByPerson == null ? "" : o.idfValidatedByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfValidatedByPerson), o.IsInvisible(_str_idfValidatedByPerson), o.IsRequired(_str_idfValidatedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnNonLaboratoryTest, _formname = _str_blnNonLaboratoryTest, _type = "Boolean?",
              _get_func = o => o.blnNonLaboratoryTest,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnNonLaboratoryTest != newval) o.blnNonLaboratoryTest = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnNonLaboratoryTest != c.blnNonLaboratoryTest || o.IsRIRPropChanged(_str_blnNonLaboratoryTest, c)) 
                  m.Add(_str_blnNonLaboratoryTest, o.ObjectIdent + _str_blnNonLaboratoryTest, o.ObjectIdent2 + _str_blnNonLaboratoryTest, o.ObjectIdent3 + _str_blnNonLaboratoryTest, "Boolean?", 
                    o.blnNonLaboratoryTest == null ? "" : o.blnNonLaboratoryTest.ToString(),                  
                  o.IsReadOnly(_str_blnNonLaboratoryTest), o.IsInvisible(_str_blnNonLaboratoryTest), o.IsRequired(_str_blnNonLaboratoryTest)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnExternalTest, _formname = _str_blnExternalTest, _type = "Boolean",
              _get_func = o => o.blnExternalTest,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnExternalTest != newval) o.blnExternalTest = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnExternalTest != c.blnExternalTest || o.IsRIRPropChanged(_str_blnExternalTest, c)) 
                  m.Add(_str_blnExternalTest, o.ObjectIdent + _str_blnExternalTest, o.ObjectIdent2 + _str_blnExternalTest, o.ObjectIdent3 + _str_blnExternalTest, "Boolean", 
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
              _name = _str_strBatchID, _formname = _str_strBatchID, _type = "String",
              _get_func = o => o.strBatchID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strBatchID != newval) o.strBatchID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strBatchID != c.strBatchID || o.IsRIRPropChanged(_str_strBatchID, c)) 
                  m.Add(_str_strBatchID, o.ObjectIdent + _str_strBatchID, o.ObjectIdent2 + _str_strBatchID, o.ObjectIdent3 + _str_strBatchID, "String", 
                    o.strBatchID == null ? "" : o.strBatchID.ToString(),                  
                  o.IsReadOnly(_str_strBatchID), o.IsInvisible(_str_strBatchID), o.IsRequired(_str_strBatchID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSampleStatus, _formname = _str_strSampleStatus, _type = "String",
              _get_func = o => o.strSampleStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSampleStatus != newval) o.strSampleStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSampleStatus != c.strSampleStatus || o.IsRIRPropChanged(_str_strSampleStatus, c)) 
                  m.Add(_str_strSampleStatus, o.ObjectIdent + _str_strSampleStatus, o.ObjectIdent2 + _str_strSampleStatus, o.ObjectIdent3 + _str_strSampleStatus, "String", 
                    o.strSampleStatus == null ? "" : o.strSampleStatus.ToString(),                  
                  o.IsReadOnly(_str_strSampleStatus), o.IsInvisible(_str_strSampleStatus), o.IsRequired(_str_strSampleStatus)); 
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
              _name = _str_strSampleConditionReceivedStatus, _formname = _str_strSampleConditionReceivedStatus, _type = "String",
              _get_func = o => o.strSampleConditionReceivedStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSampleConditionReceivedStatus != newval) o.strSampleConditionReceivedStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSampleConditionReceivedStatus != c.strSampleConditionReceivedStatus || o.IsRIRPropChanged(_str_strSampleConditionReceivedStatus, c)) 
                  m.Add(_str_strSampleConditionReceivedStatus, o.ObjectIdent + _str_strSampleConditionReceivedStatus, o.ObjectIdent2 + _str_strSampleConditionReceivedStatus, o.ObjectIdent3 + _str_strSampleConditionReceivedStatus, "String", 
                    o.strSampleConditionReceivedStatus == null ? "" : o.strSampleConditionReceivedStatus.ToString(),                  
                  o.IsReadOnly(_str_strSampleConditionReceivedStatus), o.IsInvisible(_str_strSampleConditionReceivedStatus), o.IsRequired(_str_strSampleConditionReceivedStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTestName, _formname = _str_strTestName, _type = "String",
              _get_func = o => o.strTestName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTestName != newval) o.strTestName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strTestName != c.strTestName || o.IsRIRPropChanged(_str_strTestName, c)) 
                  m.Add(_str_strTestName, o.ObjectIdent + _str_strTestName, o.ObjectIdent2 + _str_strTestName, o.ObjectIdent3 + _str_strTestName, "String", 
                    o.strTestName == null ? "" : o.strTestName.ToString(),                  
                  o.IsReadOnly(_str_strTestName), o.IsInvisible(_str_strTestName), o.IsRequired(_str_strTestName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTestStatus, _formname = _str_strTestStatus, _type = "String",
              _get_func = o => o.strTestStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTestStatus != newval) o.strTestStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.strTestStatus != c.strTestStatus || o.IsRIRPropChanged(_str_strTestStatus, c)) 
                  m.Add(_str_strTestStatus, o.ObjectIdent + _str_strTestStatus, o.ObjectIdent2 + _str_strTestStatus, o.ObjectIdent3 + _str_strTestStatus, "String", 
                    o.strTestStatus == null ? "" : o.strTestStatus.ToString(),                  
                  o.IsReadOnly(_str_strTestStatus), o.IsInvisible(_str_strTestStatus), o.IsRequired(_str_strTestStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTestResult, _formname = _str_strTestResult, _type = "String",
              _get_func = o => o.strTestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTestResult != newval) o.strTestResult = newval; },
              _compare_func = (o, c, m) => {
                if (o.strTestResult != c.strTestResult || o.IsRIRPropChanged(_str_strTestResult, c)) 
                  m.Add(_str_strTestResult, o.ObjectIdent + _str_strTestResult, o.ObjectIdent2 + _str_strTestResult, o.ObjectIdent3 + _str_strTestResult, "String", 
                    o.strTestResult == null ? "" : o.strTestResult.ToString(),                  
                  o.IsReadOnly(_str_strTestResult), o.IsInvisible(_str_strTestResult), o.IsRequired(_str_strTestResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTestCategory, _formname = _str_strTestCategory, _type = "String",
              _get_func = o => o.strTestCategory,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTestCategory != newval) o.strTestCategory = newval; },
              _compare_func = (o, c, m) => {
                if (o.strTestCategory != c.strTestCategory || o.IsRIRPropChanged(_str_strTestCategory, c)) 
                  m.Add(_str_strTestCategory, o.ObjectIdent + _str_strTestCategory, o.ObjectIdent2 + _str_strTestCategory, o.ObjectIdent3 + _str_strTestCategory, "String", 
                    o.strTestCategory == null ? "" : o.strTestCategory.ToString(),                  
                  o.IsReadOnly(_str_strTestCategory), o.IsInvisible(_str_strTestCategory), o.IsRequired(_str_strTestCategory)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsLaboratorySection, _formname = _str_idfsLaboratorySection, _type = "Int64",
              _get_func = o => o.idfsLaboratorySection,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsLaboratorySection != newval) o.idfsLaboratorySection = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsLaboratorySection != c.idfsLaboratorySection || o.IsRIRPropChanged(_str_idfsLaboratorySection, c)) 
                  m.Add(_str_idfsLaboratorySection, o.ObjectIdent + _str_idfsLaboratorySection, o.ObjectIdent2 + _str_idfsLaboratorySection, o.ObjectIdent3 + _str_idfsLaboratorySection, "Int64", 
                    o.idfsLaboratorySection == null ? "" : o.idfsLaboratorySection.ToString(),                  
                  o.IsReadOnly(_str_idfsLaboratorySection), o.IsInvisible(_str_idfsLaboratorySection), o.IsRequired(_str_idfsLaboratorySection)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_bTestDeleted, _formname = _str_bTestDeleted, _type = "Boolean",
              _get_func = o => o.bTestDeleted,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.bTestDeleted != newval) o.bTestDeleted = newval; },
              _compare_func = (o, c, m) => {
                if (o.bTestDeleted != c.bTestDeleted || o.IsRIRPropChanged(_str_bTestDeleted, c)) 
                  m.Add(_str_bTestDeleted, o.ObjectIdent + _str_bTestDeleted, o.ObjectIdent2 + _str_bTestDeleted, o.ObjectIdent3 + _str_bTestDeleted, "Boolean", 
                    o.bTestDeleted == null ? "" : o.bTestDeleted.ToString(),                  
                  o.IsReadOnly(_str_bTestDeleted), o.IsInvisible(_str_bTestDeleted), o.IsRequired(_str_bTestDeleted)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_bTestInserted, _formname = _str_bTestInserted, _type = "Boolean",
              _get_func = o => o.bTestInserted,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.bTestInserted != newval) o.bTestInserted = newval; },
              _compare_func = (o, c, m) => {
                if (o.bTestInserted != c.bTestInserted || o.IsRIRPropChanged(_str_bTestInserted, c)) 
                  m.Add(_str_bTestInserted, o.ObjectIdent + _str_bTestInserted, o.ObjectIdent2 + _str_bTestInserted, o.ObjectIdent3 + _str_bTestInserted, "Boolean", 
                    o.bTestInserted == null ? "" : o.bTestInserted.ToString(),                  
                  o.IsReadOnly(_str_bTestInserted), o.IsInvisible(_str_bTestInserted), o.IsRequired(_str_bTestInserted)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_bTestInsertedFirst, _formname = _str_bTestInsertedFirst, _type = "Boolean",
              _get_func = o => o.bTestInsertedFirst,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.bTestInsertedFirst != newval) o.bTestInsertedFirst = newval; },
              _compare_func = (o, c, m) => {
                if (o.bTestInsertedFirst != c.bTestInsertedFirst || o.IsRIRPropChanged(_str_bTestInsertedFirst, c)) 
                  m.Add(_str_bTestInsertedFirst, o.ObjectIdent + _str_bTestInsertedFirst, o.ObjectIdent2 + _str_bTestInsertedFirst, o.ObjectIdent3 + _str_bTestInsertedFirst, "Boolean", 
                    o.bTestInsertedFirst == null ? "" : o.bTestInsertedFirst.ToString(),                  
                  o.IsReadOnly(_str_bTestInsertedFirst), o.IsInvisible(_str_bTestInsertedFirst), o.IsRequired(_str_bTestInsertedFirst)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_bFilterTestByDiagnosis, _formname = _str_bFilterTestByDiagnosis, _type = "Boolean",
              _get_func = o => o.bFilterTestByDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.bFilterTestByDiagnosis != newval) o.bFilterTestByDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.bFilterTestByDiagnosis != c.bFilterTestByDiagnosis || o.IsRIRPropChanged(_str_bFilterTestByDiagnosis, c)) 
                  m.Add(_str_bFilterTestByDiagnosis, o.ObjectIdent + _str_bFilterTestByDiagnosis, o.ObjectIdent2 + _str_bFilterTestByDiagnosis, o.ObjectIdent3 + _str_bFilterTestByDiagnosis, "Boolean", 
                    o.bFilterTestByDiagnosis == null ? "" : o.bFilterTestByDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_bFilterTestByDiagnosis), o.IsInvisible(_str_bFilterTestByDiagnosis), o.IsRequired(_str_bFilterTestByDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intNewSample, _formname = _str_intNewSample, _type = "Int32?",
              _get_func = o => o.intNewSample,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intNewSample != newval) o.intNewSample = newval; },
              _compare_func = (o, c, m) => {
                if (o.intNewSample != c.intNewSample || o.IsRIRPropChanged(_str_intNewSample, c)) 
                  m.Add(_str_intNewSample, o.ObjectIdent + _str_intNewSample, o.ObjectIdent2 + _str_intNewSample, o.ObjectIdent3 + _str_intNewSample, "Int32?", 
                    o.intNewSample == null ? "" : o.intNewSample.ToString(),                  
                  o.IsReadOnly(_str_intNewSample), o.IsInvisible(_str_intNewSample), o.IsRequired(_str_intNewSample)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSampleTypeFiltered, _formname = _str_idfsSampleTypeFiltered, _type = "Int64?",
              _get_func = o => o.idfsSampleTypeFiltered,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsSampleTypeFiltered != newval) 
                  o.SampleTypeFiltered = o.SampleTypeFilteredLookup.FirstOrDefault(c => c.idfsReference == newval);
                if (o.idfsSampleTypeFiltered != newval) o.idfsSampleTypeFiltered = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSampleTypeFiltered != c.idfsSampleTypeFiltered || o.IsRIRPropChanged(_str_idfsSampleTypeFiltered, c)) 
                  m.Add(_str_idfsSampleTypeFiltered, o.ObjectIdent + _str_idfsSampleTypeFiltered, o.ObjectIdent2 + _str_idfsSampleTypeFiltered, o.ObjectIdent3 + _str_idfsSampleTypeFiltered, "Int64?", 
                    o.idfsSampleTypeFiltered == null ? "" : o.idfsSampleTypeFiltered.ToString(),                  
                  o.IsReadOnly(_str_idfsSampleTypeFiltered), o.IsInvisible(_str_idfsSampleTypeFiltered), o.IsRequired(_str_idfsSampleTypeFiltered)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strComments, _formname = _str_strComments, _type = "String",
              _get_func = o => o.strComments,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strComments != newval) o.strComments = newval; },
              _compare_func = (o, c, m) => {
                if (o.strComments != c.strComments || o.IsRIRPropChanged(_str_strComments, c)) 
                  m.Add(_str_strComments, o.ObjectIdent + _str_strComments, o.ObjectIdent2 + _str_strComments, o.ObjectIdent3 + _str_strComments, "String", 
                    o.strComments == null ? "" : o.strComments.ToString(),                  
                  o.IsReadOnly(_str_strComments), o.IsInvisible(_str_strComments), o.IsRequired(_str_strComments)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strReason, _formname = _str_strReason, _type = "String",
              _get_func = o => o.strReason,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strReason != newval) o.strReason = newval; },
              _compare_func = (o, c, m) => {
                if (o.strReason != c.strReason || o.IsRIRPropChanged(_str_strReason, c)) 
                  m.Add(_str_strReason, o.ObjectIdent + _str_strReason, o.ObjectIdent2 + _str_strReason, o.ObjectIdent3 + _str_strReason, "String", 
                    o.strReason == null ? "" : o.strReason.ToString(),                  
                  o.IsReadOnly(_str_strReason), o.IsInvisible(_str_strReason), o.IsRequired(_str_strReason)); 
                  }
              }, 
        
            new field_info {
              _name = _str_bIsMyPref, _formname = _str_bIsMyPref, _type = "bool",
              _get_func = o => o.bIsMyPref,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.bIsMyPref != newval) o.bIsMyPref = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.bIsMyPref != c.bIsMyPref || o.IsRIRPropChanged(_str_bIsMyPref, c)) {
                  m.Add(_str_bIsMyPref, o.ObjectIdent + _str_bIsMyPref, o.ObjectIdent2 + _str_bIsMyPref, o.ObjectIdent3 + _str_bIsMyPref,  "bool", 
                    o.bIsMyPref == null ? "" : o.bIsMyPref.ToString(),                  
                    o.IsReadOnly(_str_bIsMyPref), o.IsInvisible(_str_bIsMyPref), o.IsRequired(_str_bIsMyPref));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_intNewMode, _formname = _str_intNewMode, _type = "LabNewModeEnum",
              _get_func = o => o.intNewMode,
              _set_func = (o, val) => { var newval = o.intNewMode; if (o.intNewMode != newval) o.intNewMode = newval; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_bIsCreateNewSample, _formname = _str_bIsCreateNewSample, _type = "bool",
              _get_func = o => o.bIsCreateNewSample,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.bIsCreateNewSample != newval) o.bIsCreateNewSample = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.bIsCreateNewSample != c.bIsCreateNewSample || o.IsRIRPropChanged(_str_bIsCreateNewSample, c)) {
                  m.Add(_str_bIsCreateNewSample, o.ObjectIdent + _str_bIsCreateNewSample, o.ObjectIdent2 + _str_bIsCreateNewSample, o.ObjectIdent3 + _str_bIsCreateNewSample,  "bool", 
                    o.bIsCreateNewSample == null ? "" : o.bIsCreateNewSample.ToString(),                  
                    o.IsReadOnly(_str_bIsCreateNewSample), o.IsInvisible(_str_bIsCreateNewSample), o.IsRequired(_str_bIsCreateNewSample));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsTestResultDummy, _formname = _str_idfsTestResultDummy, _type = "long?",
              _get_func = o => o.idfsTestResultDummy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTestResultDummy != newval) o.idfsTestResultDummy = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsTestResultDummy != c.idfsTestResultDummy || o.IsRIRPropChanged(_str_idfsTestResultDummy, c)) {
                  m.Add(_str_idfsTestResultDummy, o.ObjectIdent + _str_idfsTestResultDummy, o.ObjectIdent2 + _str_idfsTestResultDummy, o.ObjectIdent3 + _str_idfsTestResultDummy,  "long?", 
                    o.idfsTestResultDummy == null ? "" : o.idfsTestResultDummy.ToString(),                  
                    o.IsReadOnly(_str_idfsTestResultDummy), o.IsInvisible(_str_idfsTestResultDummy), o.IsRequired(_str_idfsTestResultDummy));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsTestStatusDummy, _formname = _str_idfsTestStatusDummy, _type = "long?",
              _get_func = o => o.idfsTestStatusDummy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTestStatusDummy != newval) o.idfsTestStatusDummy = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsTestStatusDummy != c.idfsTestStatusDummy || o.IsRIRPropChanged(_str_idfsTestStatusDummy, c)) {
                  m.Add(_str_idfsTestStatusDummy, o.ObjectIdent + _str_idfsTestStatusDummy, o.ObjectIdent2 + _str_idfsTestStatusDummy, o.ObjectIdent3 + _str_idfsTestStatusDummy,  "long?", 
                    o.idfsTestStatusDummy == null ? "" : o.idfsTestStatusDummy.ToString(),                  
                    o.IsReadOnly(_str_idfsTestStatusDummy), o.IsInvisible(_str_idfsTestStatusDummy), o.IsRequired(_str_idfsTestStatusDummy));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfDerivativeForSampleType, _formname = _str_idfDerivativeForSampleType, _type = "long?",
              _get_func = o => o.idfDerivativeForSampleType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfDerivativeForSampleType != newval) o.idfDerivativeForSampleType = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfDerivativeForSampleType != c.idfDerivativeForSampleType || o.IsRIRPropChanged(_str_idfDerivativeForSampleType, c)) {
                  m.Add(_str_idfDerivativeForSampleType, o.ObjectIdent + _str_idfDerivativeForSampleType, o.ObjectIdent2 + _str_idfDerivativeForSampleType, o.ObjectIdent3 + _str_idfDerivativeForSampleType,  "long?", 
                    o.idfDerivativeForSampleType == null ? "" : o.idfDerivativeForSampleType.ToString(),                  
                    o.IsReadOnly(_str_idfDerivativeForSampleType), o.IsInvisible(_str_idfDerivativeForSampleType), o.IsRequired(_str_idfDerivativeForSampleType));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsOldTestResult, _formname = _str_idfsOldTestResult, _type = "long?",
              _get_func = o => o.idfsOldTestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsOldTestResult != newval) o.idfsOldTestResult = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsOldTestResult != c.idfsOldTestResult || o.IsRIRPropChanged(_str_idfsOldTestResult, c)) {
                  m.Add(_str_idfsOldTestResult, o.ObjectIdent + _str_idfsOldTestResult, o.ObjectIdent2 + _str_idfsOldTestResult, o.ObjectIdent3 + _str_idfsOldTestResult,  "long?", 
                    o.idfsOldTestResult == null ? "" : o.idfsOldTestResult.ToString(),                  
                    o.IsReadOnly(_str_idfsOldTestResult), o.IsInvisible(_str_idfsOldTestResult), o.IsRequired(_str_idfsOldTestResult));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsSampleStatusOriginalIsSaved, _formname = _str_idfsSampleStatusOriginalIsSaved, _type = "bool",
              _get_func = o => o.idfsSampleStatusOriginalIsSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.idfsSampleStatusOriginalIsSaved != newval) o.idfsSampleStatusOriginalIsSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsSampleStatusOriginalIsSaved != c.idfsSampleStatusOriginalIsSaved || o.IsRIRPropChanged(_str_idfsSampleStatusOriginalIsSaved, c)) {
                  m.Add(_str_idfsSampleStatusOriginalIsSaved, o.ObjectIdent + _str_idfsSampleStatusOriginalIsSaved, o.ObjectIdent2 + _str_idfsSampleStatusOriginalIsSaved, o.ObjectIdent3 + _str_idfsSampleStatusOriginalIsSaved,  "bool", 
                    o.idfsSampleStatusOriginalIsSaved == null ? "" : o.idfsSampleStatusOriginalIsSaved.ToString(),                  
                    o.IsReadOnly(_str_idfsSampleStatusOriginalIsSaved), o.IsInvisible(_str_idfsSampleStatusOriginalIsSaved), o.IsRequired(_str_idfsSampleStatusOriginalIsSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsSampleStatusOriginalSaved, _formname = _str_idfsSampleStatusOriginalSaved, _type = "long",
              _get_func = o => o.idfsSampleStatusOriginalSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsSampleStatusOriginalSaved != newval) o.idfsSampleStatusOriginalSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsSampleStatusOriginalSaved != c.idfsSampleStatusOriginalSaved || o.IsRIRPropChanged(_str_idfsSampleStatusOriginalSaved, c)) {
                  m.Add(_str_idfsSampleStatusOriginalSaved, o.ObjectIdent + _str_idfsSampleStatusOriginalSaved, o.ObjectIdent2 + _str_idfsSampleStatusOriginalSaved, o.ObjectIdent3 + _str_idfsSampleStatusOriginalSaved,  "long", 
                    o.idfsSampleStatusOriginalSaved == null ? "" : o.idfsSampleStatusOriginalSaved.ToString(),                  
                    o.IsReadOnly(_str_idfsSampleStatusOriginalSaved), o.IsInvisible(_str_idfsSampleStatusOriginalSaved), o.IsRequired(_str_idfsSampleStatusOriginalSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsTestStatusOriginalIsSaved, _formname = _str_idfsTestStatusOriginalIsSaved, _type = "bool",
              _get_func = o => o.idfsTestStatusOriginalIsSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.idfsTestStatusOriginalIsSaved != newval) o.idfsTestStatusOriginalIsSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsTestStatusOriginalIsSaved != c.idfsTestStatusOriginalIsSaved || o.IsRIRPropChanged(_str_idfsTestStatusOriginalIsSaved, c)) {
                  m.Add(_str_idfsTestStatusOriginalIsSaved, o.ObjectIdent + _str_idfsTestStatusOriginalIsSaved, o.ObjectIdent2 + _str_idfsTestStatusOriginalIsSaved, o.ObjectIdent3 + _str_idfsTestStatusOriginalIsSaved,  "bool", 
                    o.idfsTestStatusOriginalIsSaved == null ? "" : o.idfsTestStatusOriginalIsSaved.ToString(),                  
                    o.IsReadOnly(_str_idfsTestStatusOriginalIsSaved), o.IsInvisible(_str_idfsTestStatusOriginalIsSaved), o.IsRequired(_str_idfsTestStatusOriginalIsSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsTestStatusOriginalSaved, _formname = _str_idfsTestStatusOriginalSaved, _type = "long?",
              _get_func = o => o.idfsTestStatusOriginalSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTestStatusOriginalSaved != newval) o.idfsTestStatusOriginalSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsTestStatusOriginalSaved != c.idfsTestStatusOriginalSaved || o.IsRIRPropChanged(_str_idfsTestStatusOriginalSaved, c)) {
                  m.Add(_str_idfsTestStatusOriginalSaved, o.ObjectIdent + _str_idfsTestStatusOriginalSaved, o.ObjectIdent2 + _str_idfsTestStatusOriginalSaved, o.ObjectIdent3 + _str_idfsTestStatusOriginalSaved,  "long?", 
                    o.idfsTestStatusOriginalSaved == null ? "" : o.idfsTestStatusOriginalSaved.ToString(),                  
                    o.IsReadOnly(_str_idfsTestStatusOriginalSaved), o.IsInvisible(_str_idfsTestStatusOriginalSaved), o.IsRequired(_str_idfsTestStatusOriginalSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsTestResultOriginalIsSaved, _formname = _str_idfsTestResultOriginalIsSaved, _type = "bool",
              _get_func = o => o.idfsTestResultOriginalIsSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.idfsTestResultOriginalIsSaved != newval) o.idfsTestResultOriginalIsSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsTestResultOriginalIsSaved != c.idfsTestResultOriginalIsSaved || o.IsRIRPropChanged(_str_idfsTestResultOriginalIsSaved, c)) {
                  m.Add(_str_idfsTestResultOriginalIsSaved, o.ObjectIdent + _str_idfsTestResultOriginalIsSaved, o.ObjectIdent2 + _str_idfsTestResultOriginalIsSaved, o.ObjectIdent3 + _str_idfsTestResultOriginalIsSaved,  "bool", 
                    o.idfsTestResultOriginalIsSaved == null ? "" : o.idfsTestResultOriginalIsSaved.ToString(),                  
                    o.IsReadOnly(_str_idfsTestResultOriginalIsSaved), o.IsInvisible(_str_idfsTestResultOriginalIsSaved), o.IsRequired(_str_idfsTestResultOriginalIsSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsTestResultOriginalSaved, _formname = _str_idfsTestResultOriginalSaved, _type = "long?",
              _get_func = o => o.idfsTestResultOriginalSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTestResultOriginalSaved != newval) o.idfsTestResultOriginalSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsTestResultOriginalSaved != c.idfsTestResultOriginalSaved || o.IsRIRPropChanged(_str_idfsTestResultOriginalSaved, c)) {
                  m.Add(_str_idfsTestResultOriginalSaved, o.ObjectIdent + _str_idfsTestResultOriginalSaved, o.ObjectIdent2 + _str_idfsTestResultOriginalSaved, o.ObjectIdent3 + _str_idfsTestResultOriginalSaved,  "long?", 
                    o.idfsTestResultOriginalSaved == null ? "" : o.idfsTestResultOriginalSaved.ToString(),                  
                    o.IsReadOnly(_str_idfsTestResultOriginalSaved), o.IsInvisible(_str_idfsTestResultOriginalSaved), o.IsRequired(_str_idfsTestResultOriginalSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsAccessionConditionOriginalIsSaved, _formname = _str_idfsAccessionConditionOriginalIsSaved, _type = "bool",
              _get_func = o => o.idfsAccessionConditionOriginalIsSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.idfsAccessionConditionOriginalIsSaved != newval) o.idfsAccessionConditionOriginalIsSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsAccessionConditionOriginalIsSaved != c.idfsAccessionConditionOriginalIsSaved || o.IsRIRPropChanged(_str_idfsAccessionConditionOriginalIsSaved, c)) {
                  m.Add(_str_idfsAccessionConditionOriginalIsSaved, o.ObjectIdent + _str_idfsAccessionConditionOriginalIsSaved, o.ObjectIdent2 + _str_idfsAccessionConditionOriginalIsSaved, o.ObjectIdent3 + _str_idfsAccessionConditionOriginalIsSaved,  "bool", 
                    o.idfsAccessionConditionOriginalIsSaved == null ? "" : o.idfsAccessionConditionOriginalIsSaved.ToString(),                  
                    o.IsReadOnly(_str_idfsAccessionConditionOriginalIsSaved), o.IsInvisible(_str_idfsAccessionConditionOriginalIsSaved), o.IsRequired(_str_idfsAccessionConditionOriginalIsSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsAccessionConditionOriginalSaved, _formname = _str_idfsAccessionConditionOriginalSaved, _type = "long?",
              _get_func = o => o.idfsAccessionConditionOriginalSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsAccessionConditionOriginalSaved != newval) o.idfsAccessionConditionOriginalSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsAccessionConditionOriginalSaved != c.idfsAccessionConditionOriginalSaved || o.IsRIRPropChanged(_str_idfsAccessionConditionOriginalSaved, c)) {
                  m.Add(_str_idfsAccessionConditionOriginalSaved, o.ObjectIdent + _str_idfsAccessionConditionOriginalSaved, o.ObjectIdent2 + _str_idfsAccessionConditionOriginalSaved, o.ObjectIdent3 + _str_idfsAccessionConditionOriginalSaved,  "long?", 
                    o.idfsAccessionConditionOriginalSaved == null ? "" : o.idfsAccessionConditionOriginalSaved.ToString(),                  
                    o.IsReadOnly(_str_idfsAccessionConditionOriginalSaved), o.IsInvisible(_str_idfsAccessionConditionOriginalSaved), o.IsRequired(_str_idfsAccessionConditionOriginalSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfSendToOfficeOutOriginalIsSaved, _formname = _str_idfSendToOfficeOutOriginalIsSaved, _type = "bool",
              _get_func = o => o.idfSendToOfficeOutOriginalIsSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.idfSendToOfficeOutOriginalIsSaved != newval) o.idfSendToOfficeOutOriginalIsSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfSendToOfficeOutOriginalIsSaved != c.idfSendToOfficeOutOriginalIsSaved || o.IsRIRPropChanged(_str_idfSendToOfficeOutOriginalIsSaved, c)) {
                  m.Add(_str_idfSendToOfficeOutOriginalIsSaved, o.ObjectIdent + _str_idfSendToOfficeOutOriginalIsSaved, o.ObjectIdent2 + _str_idfSendToOfficeOutOriginalIsSaved, o.ObjectIdent3 + _str_idfSendToOfficeOutOriginalIsSaved,  "bool", 
                    o.idfSendToOfficeOutOriginalIsSaved == null ? "" : o.idfSendToOfficeOutOriginalIsSaved.ToString(),                  
                    o.IsReadOnly(_str_idfSendToOfficeOutOriginalIsSaved), o.IsInvisible(_str_idfSendToOfficeOutOriginalIsSaved), o.IsRequired(_str_idfSendToOfficeOutOriginalIsSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfSendToOfficeOutOriginalSaved, _formname = _str_idfSendToOfficeOutOriginalSaved, _type = "long?",
              _get_func = o => o.idfSendToOfficeOutOriginalSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfSendToOfficeOutOriginalSaved != newval) o.idfSendToOfficeOutOriginalSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfSendToOfficeOutOriginalSaved != c.idfSendToOfficeOutOriginalSaved || o.IsRIRPropChanged(_str_idfSendToOfficeOutOriginalSaved, c)) {
                  m.Add(_str_idfSendToOfficeOutOriginalSaved, o.ObjectIdent + _str_idfSendToOfficeOutOriginalSaved, o.ObjectIdent2 + _str_idfSendToOfficeOutOriginalSaved, o.ObjectIdent3 + _str_idfSendToOfficeOutOriginalSaved,  "long?", 
                    o.idfSendToOfficeOutOriginalSaved == null ? "" : o.idfSendToOfficeOutOriginalSaved.ToString(),                  
                    o.IsReadOnly(_str_idfSendToOfficeOutOriginalSaved), o.IsInvisible(_str_idfSendToOfficeOutOriginalSaved), o.IsRequired(_str_idfSendToOfficeOutOriginalSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_strBarcodeOriginalIsSaved, _formname = _str_strBarcodeOriginalIsSaved, _type = "bool",
              _get_func = o => o.strBarcodeOriginalIsSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.strBarcodeOriginalIsSaved != newval) o.strBarcodeOriginalIsSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.strBarcodeOriginalIsSaved != c.strBarcodeOriginalIsSaved || o.IsRIRPropChanged(_str_strBarcodeOriginalIsSaved, c)) {
                  m.Add(_str_strBarcodeOriginalIsSaved, o.ObjectIdent + _str_strBarcodeOriginalIsSaved, o.ObjectIdent2 + _str_strBarcodeOriginalIsSaved, o.ObjectIdent3 + _str_strBarcodeOriginalIsSaved,  "bool", 
                    o.strBarcodeOriginalIsSaved == null ? "" : o.strBarcodeOriginalIsSaved.ToString(),                  
                    o.IsReadOnly(_str_strBarcodeOriginalIsSaved), o.IsInvisible(_str_strBarcodeOriginalIsSaved), o.IsRequired(_str_strBarcodeOriginalIsSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_strBarcodeOriginalSaved, _formname = _str_strBarcodeOriginalSaved, _type = "string",
              _get_func = o => o.strBarcodeOriginalSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strBarcodeOriginalSaved != newval) o.strBarcodeOriginalSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.strBarcodeOriginalSaved != c.strBarcodeOriginalSaved || o.IsRIRPropChanged(_str_strBarcodeOriginalSaved, c)) {
                  m.Add(_str_strBarcodeOriginalSaved, o.ObjectIdent + _str_strBarcodeOriginalSaved, o.ObjectIdent2 + _str_strBarcodeOriginalSaved, o.ObjectIdent3 + _str_strBarcodeOriginalSaved,  "string", 
                    o.strBarcodeOriginalSaved == null ? "" : o.strBarcodeOriginalSaved.ToString(),                  
                    o.IsReadOnly(_str_strBarcodeOriginalSaved), o.IsInvisible(_str_strBarcodeOriginalSaved), o.IsRequired(_str_strBarcodeOriginalSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsTestNamePreviousIsSaved, _formname = _str_idfsTestNamePreviousIsSaved, _type = "bool",
              _get_func = o => o.idfsTestNamePreviousIsSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.idfsTestNamePreviousIsSaved != newval) o.idfsTestNamePreviousIsSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsTestNamePreviousIsSaved != c.idfsTestNamePreviousIsSaved || o.IsRIRPropChanged(_str_idfsTestNamePreviousIsSaved, c)) {
                  m.Add(_str_idfsTestNamePreviousIsSaved, o.ObjectIdent + _str_idfsTestNamePreviousIsSaved, o.ObjectIdent2 + _str_idfsTestNamePreviousIsSaved, o.ObjectIdent3 + _str_idfsTestNamePreviousIsSaved,  "bool", 
                    o.idfsTestNamePreviousIsSaved == null ? "" : o.idfsTestNamePreviousIsSaved.ToString(),                  
                    o.IsReadOnly(_str_idfsTestNamePreviousIsSaved), o.IsInvisible(_str_idfsTestNamePreviousIsSaved), o.IsRequired(_str_idfsTestNamePreviousIsSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsTestNamePreviousSaved, _formname = _str_idfsTestNamePreviousSaved, _type = "long?",
              _get_func = o => o.idfsTestNamePreviousSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTestNamePreviousSaved != newval) o.idfsTestNamePreviousSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsTestNamePreviousSaved != c.idfsTestNamePreviousSaved || o.IsRIRPropChanged(_str_idfsTestNamePreviousSaved, c)) {
                  m.Add(_str_idfsTestNamePreviousSaved, o.ObjectIdent + _str_idfsTestNamePreviousSaved, o.ObjectIdent2 + _str_idfsTestNamePreviousSaved, o.ObjectIdent3 + _str_idfsTestNamePreviousSaved,  "long?", 
                    o.idfsTestNamePreviousSaved == null ? "" : o.idfsTestNamePreviousSaved.ToString(),                  
                    o.IsReadOnly(_str_idfsTestNamePreviousSaved), o.IsInvisible(_str_idfsTestNamePreviousSaved), o.IsRequired(_str_idfsTestNamePreviousSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsTestResultPreviousIsSaved, _formname = _str_idfsTestResultPreviousIsSaved, _type = "bool",
              _get_func = o => o.idfsTestResultPreviousIsSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.idfsTestResultPreviousIsSaved != newval) o.idfsTestResultPreviousIsSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsTestResultPreviousIsSaved != c.idfsTestResultPreviousIsSaved || o.IsRIRPropChanged(_str_idfsTestResultPreviousIsSaved, c)) {
                  m.Add(_str_idfsTestResultPreviousIsSaved, o.ObjectIdent + _str_idfsTestResultPreviousIsSaved, o.ObjectIdent2 + _str_idfsTestResultPreviousIsSaved, o.ObjectIdent3 + _str_idfsTestResultPreviousIsSaved,  "bool", 
                    o.idfsTestResultPreviousIsSaved == null ? "" : o.idfsTestResultPreviousIsSaved.ToString(),                  
                    o.IsReadOnly(_str_idfsTestResultPreviousIsSaved), o.IsInvisible(_str_idfsTestResultPreviousIsSaved), o.IsRequired(_str_idfsTestResultPreviousIsSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsTestResultPreviousSaved, _formname = _str_idfsTestResultPreviousSaved, _type = "long?",
              _get_func = o => o.idfsTestResultPreviousSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTestResultPreviousSaved != newval) o.idfsTestResultPreviousSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsTestResultPreviousSaved != c.idfsTestResultPreviousSaved || o.IsRIRPropChanged(_str_idfsTestResultPreviousSaved, c)) {
                  m.Add(_str_idfsTestResultPreviousSaved, o.ObjectIdent + _str_idfsTestResultPreviousSaved, o.ObjectIdent2 + _str_idfsTestResultPreviousSaved, o.ObjectIdent3 + _str_idfsTestResultPreviousSaved,  "long?", 
                    o.idfsTestResultPreviousSaved == null ? "" : o.idfsTestResultPreviousSaved.ToString(),                  
                    o.IsReadOnly(_str_idfsTestResultPreviousSaved), o.IsInvisible(_str_idfsTestResultPreviousSaved), o.IsRequired(_str_idfsTestResultPreviousSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_blnExternalTestPreviousIsSaved, _formname = _str_blnExternalTestPreviousIsSaved, _type = "bool",
              _get_func = o => o.blnExternalTestPreviousIsSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnExternalTestPreviousIsSaved != newval) o.blnExternalTestPreviousIsSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.blnExternalTestPreviousIsSaved != c.blnExternalTestPreviousIsSaved || o.IsRIRPropChanged(_str_blnExternalTestPreviousIsSaved, c)) {
                  m.Add(_str_blnExternalTestPreviousIsSaved, o.ObjectIdent + _str_blnExternalTestPreviousIsSaved, o.ObjectIdent2 + _str_blnExternalTestPreviousIsSaved, o.ObjectIdent3 + _str_blnExternalTestPreviousIsSaved,  "bool", 
                    o.blnExternalTestPreviousIsSaved == null ? "" : o.blnExternalTestPreviousIsSaved.ToString(),                  
                    o.IsReadOnly(_str_blnExternalTestPreviousIsSaved), o.IsInvisible(_str_blnExternalTestPreviousIsSaved), o.IsRequired(_str_blnExternalTestPreviousIsSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_blnExternalTestPreviousSaved, _formname = _str_blnExternalTestPreviousSaved, _type = "bool",
              _get_func = o => o.blnExternalTestPreviousSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnExternalTestPreviousSaved != newval) o.blnExternalTestPreviousSaved = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.blnExternalTestPreviousSaved != c.blnExternalTestPreviousSaved || o.IsRIRPropChanged(_str_blnExternalTestPreviousSaved, c)) {
                  m.Add(_str_blnExternalTestPreviousSaved, o.ObjectIdent + _str_blnExternalTestPreviousSaved, o.ObjectIdent2 + _str_blnExternalTestPreviousSaved, o.ObjectIdent3 + _str_blnExternalTestPreviousSaved,  "bool", 
                    o.blnExternalTestPreviousSaved == null ? "" : o.blnExternalTestPreviousSaved.ToString(),                  
                    o.IsReadOnly(_str_blnExternalTestPreviousSaved), o.IsInvisible(_str_blnExternalTestPreviousSaved), o.IsRequired(_str_blnExternalTestPreviousSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsSampleStatusOriginal, _formname = _str_idfsSampleStatusOriginal, _type = "long",
              _get_func = o => o.idfsSampleStatusOriginal,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsSampleStatusOriginal != c.idfsSampleStatusOriginal || o.IsRIRPropChanged(_str_idfsSampleStatusOriginal, c)) {
                  m.Add(_str_idfsSampleStatusOriginal, o.ObjectIdent + _str_idfsSampleStatusOriginal, o.ObjectIdent2 + _str_idfsSampleStatusOriginal, o.ObjectIdent3 + _str_idfsSampleStatusOriginal, "long", o.idfsSampleStatusOriginal == null ? "" : o.idfsSampleStatusOriginal.ToString(), o.IsReadOnly(_str_idfsSampleStatusOriginal), o.IsInvisible(_str_idfsSampleStatusOriginal), o.IsRequired(_str_idfsSampleStatusOriginal));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_idfsTestStatusOriginal, _formname = _str_idfsTestStatusOriginal, _type = "long?",
              _get_func = o => o.idfsTestStatusOriginal,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsTestStatusOriginal != c.idfsTestStatusOriginal || o.IsRIRPropChanged(_str_idfsTestStatusOriginal, c)) {
                  m.Add(_str_idfsTestStatusOriginal, o.ObjectIdent + _str_idfsTestStatusOriginal, o.ObjectIdent2 + _str_idfsTestStatusOriginal, o.ObjectIdent3 + _str_idfsTestStatusOriginal, "long?", o.idfsTestStatusOriginal == null ? "" : o.idfsTestStatusOriginal.ToString(), o.IsReadOnly(_str_idfsTestStatusOriginal), o.IsInvisible(_str_idfsTestStatusOriginal), o.IsRequired(_str_idfsTestStatusOriginal));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_idfsTestResultOriginal, _formname = _str_idfsTestResultOriginal, _type = "long?",
              _get_func = o => o.idfsTestResultOriginal,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsTestResultOriginal != c.idfsTestResultOriginal || o.IsRIRPropChanged(_str_idfsTestResultOriginal, c)) {
                  m.Add(_str_idfsTestResultOriginal, o.ObjectIdent + _str_idfsTestResultOriginal, o.ObjectIdent2 + _str_idfsTestResultOriginal, o.ObjectIdent3 + _str_idfsTestResultOriginal, "long?", o.idfsTestResultOriginal == null ? "" : o.idfsTestResultOriginal.ToString(), o.IsReadOnly(_str_idfsTestResultOriginal), o.IsInvisible(_str_idfsTestResultOriginal), o.IsRequired(_str_idfsTestResultOriginal));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_idfsAccessionConditionOriginal, _formname = _str_idfsAccessionConditionOriginal, _type = "long?",
              _get_func = o => o.idfsAccessionConditionOriginal,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsAccessionConditionOriginal != c.idfsAccessionConditionOriginal || o.IsRIRPropChanged(_str_idfsAccessionConditionOriginal, c)) {
                  m.Add(_str_idfsAccessionConditionOriginal, o.ObjectIdent + _str_idfsAccessionConditionOriginal, o.ObjectIdent2 + _str_idfsAccessionConditionOriginal, o.ObjectIdent3 + _str_idfsAccessionConditionOriginal, "long?", o.idfsAccessionConditionOriginal == null ? "" : o.idfsAccessionConditionOriginal.ToString(), o.IsReadOnly(_str_idfsAccessionConditionOriginal), o.IsInvisible(_str_idfsAccessionConditionOriginal), o.IsRequired(_str_idfsAccessionConditionOriginal));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_idfSendToOfficeOutOriginal, _formname = _str_idfSendToOfficeOutOriginal, _type = "long?",
              _get_func = o => o.idfSendToOfficeOutOriginal,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfSendToOfficeOutOriginal != c.idfSendToOfficeOutOriginal || o.IsRIRPropChanged(_str_idfSendToOfficeOutOriginal, c)) {
                  m.Add(_str_idfSendToOfficeOutOriginal, o.ObjectIdent + _str_idfSendToOfficeOutOriginal, o.ObjectIdent2 + _str_idfSendToOfficeOutOriginal, o.ObjectIdent3 + _str_idfSendToOfficeOutOriginal, "long?", o.idfSendToOfficeOutOriginal == null ? "" : o.idfSendToOfficeOutOriginal.ToString(), o.IsReadOnly(_str_idfSendToOfficeOutOriginal), o.IsInvisible(_str_idfSendToOfficeOutOriginal), o.IsRequired(_str_idfSendToOfficeOutOriginal));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strBarcodeOriginal, _formname = _str_strBarcodeOriginal, _type = "string",
              _get_func = o => o.strBarcodeOriginal,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strBarcodeOriginal != c.strBarcodeOriginal || o.IsRIRPropChanged(_str_strBarcodeOriginal, c)) {
                  m.Add(_str_strBarcodeOriginal, o.ObjectIdent + _str_strBarcodeOriginal, o.ObjectIdent2 + _str_strBarcodeOriginal, o.ObjectIdent3 + _str_strBarcodeOriginal, "string", o.strBarcodeOriginal == null ? "" : o.strBarcodeOriginal.ToString(), o.IsReadOnly(_str_strBarcodeOriginal), o.IsInvisible(_str_strBarcodeOriginal), o.IsRequired(_str_strBarcodeOriginal));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_idfsTestNamePrevious, _formname = _str_idfsTestNamePrevious, _type = "long?",
              _get_func = o => o.idfsTestNamePrevious,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsTestNamePrevious != c.idfsTestNamePrevious || o.IsRIRPropChanged(_str_idfsTestNamePrevious, c)) {
                  m.Add(_str_idfsTestNamePrevious, o.ObjectIdent + _str_idfsTestNamePrevious, o.ObjectIdent2 + _str_idfsTestNamePrevious, o.ObjectIdent3 + _str_idfsTestNamePrevious, "long?", o.idfsTestNamePrevious == null ? "" : o.idfsTestNamePrevious.ToString(), o.IsReadOnly(_str_idfsTestNamePrevious), o.IsInvisible(_str_idfsTestNamePrevious), o.IsRequired(_str_idfsTestNamePrevious));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_idfsTestResultPrevious, _formname = _str_idfsTestResultPrevious, _type = "long?",
              _get_func = o => o.idfsTestResultPrevious,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsTestResultPrevious != c.idfsTestResultPrevious || o.IsRIRPropChanged(_str_idfsTestResultPrevious, c)) {
                  m.Add(_str_idfsTestResultPrevious, o.ObjectIdent + _str_idfsTestResultPrevious, o.ObjectIdent2 + _str_idfsTestResultPrevious, o.ObjectIdent3 + _str_idfsTestResultPrevious, "long?", o.idfsTestResultPrevious == null ? "" : o.idfsTestResultPrevious.ToString(), o.IsReadOnly(_str_idfsTestResultPrevious), o.IsInvisible(_str_idfsTestResultPrevious), o.IsRequired(_str_idfsTestResultPrevious));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_blnExternalTestPrevious, _formname = _str_blnExternalTestPrevious, _type = "bool",
              _get_func = o => o.blnExternalTestPrevious,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.blnExternalTestPrevious != c.blnExternalTestPrevious || o.IsRIRPropChanged(_str_blnExternalTestPrevious, c)) {
                  m.Add(_str_blnExternalTestPrevious, o.ObjectIdent + _str_blnExternalTestPrevious, o.ObjectIdent2 + _str_blnExternalTestPrevious, o.ObjectIdent3 + _str_blnExternalTestPrevious, "bool", o.blnExternalTestPrevious == null ? "" : o.blnExternalTestPrevious.ToString(), o.IsReadOnly(_str_blnExternalTestPrevious), o.IsInvisible(_str_blnExternalTestPrevious), o.IsRequired(_str_blnExternalTestPrevious));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_isChanges, _formname = _str_isChanges, _type = "bool",
              _get_func = o => o.isChanges,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.isChanges != c.isChanges || o.IsRIRPropChanged(_str_isChanges, c)) {
                  m.Add(_str_isChanges, o.ObjectIdent + _str_isChanges, o.ObjectIdent2 + _str_isChanges, o.ObjectIdent3 + _str_isChanges, "bool", o.isChanges == null ? "" : o.isChanges.ToString(), o.IsReadOnly(_str_isChanges), o.IsInvisible(_str_isChanges), o.IsRequired(_str_isChanges));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strSendToOffice, _formname = _str_strSendToOffice, _type = "string",
              _get_func = o => o.strSendToOffice,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strSendToOffice != c.strSendToOffice || o.IsRIRPropChanged(_str_strSendToOffice, c)) {
                  m.Add(_str_strSendToOffice, o.ObjectIdent + _str_strSendToOffice, o.ObjectIdent2 + _str_strSendToOffice, o.ObjectIdent3 + _str_strSendToOffice, "string", o.strSendToOffice == null ? "" : o.strSendToOffice.ToString(), o.IsReadOnly(_str_strSendToOffice), o.IsInvisible(_str_strSendToOffice), o.IsRequired(_str_strSendToOffice));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strSendToOfficeOut, _formname = _str_strSendToOfficeOut, _type = "string",
              _get_func = o => o.strSendToOfficeOut,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strSendToOfficeOut != c.strSendToOfficeOut || o.IsRIRPropChanged(_str_strSendToOfficeOut, c)) {
                  m.Add(_str_strSendToOfficeOut, o.ObjectIdent + _str_strSendToOfficeOut, o.ObjectIdent2 + _str_strSendToOfficeOut, o.ObjectIdent3 + _str_strSendToOfficeOut, "string", o.strSendToOfficeOut == null ? "" : o.strSendToOfficeOut.ToString(), o.IsReadOnly(_str_strSendToOfficeOut), o.IsInvisible(_str_strSendToOfficeOut), o.IsRequired(_str_strSendToOfficeOut));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strTestCount, _formname = _str_strTestCount, _type = "string",
              _get_func = o => o.strTestCount,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strTestCount != c.strTestCount || o.IsRIRPropChanged(_str_strTestCount, c)) {
                  m.Add(_str_strTestCount, o.ObjectIdent + _str_strTestCount, o.ObjectIdent2 + _str_strTestCount, o.ObjectIdent3 + _str_strTestCount, "string", o.strTestCount == null ? "" : o.strTestCount.ToString(), o.IsReadOnly(_str_strTestCount), o.IsInvisible(_str_strTestCount), o.IsRequired(_str_strTestCount));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strObservation, _formname = _str_strObservation, _type = "string",
              _get_func = o => o.strObservation,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strObservation != c.strObservation || o.IsRIRPropChanged(_str_strObservation, c)) {
                  m.Add(_str_strObservation, o.ObjectIdent + _str_strObservation, o.ObjectIdent2 + _str_strObservation, o.ObjectIdent3 + _str_strObservation, "string", o.strObservation == null ? "" : o.strObservation.ToString(), o.IsReadOnly(_str_strObservation), o.IsInvisible(_str_strObservation), o.IsRequired(_str_strObservation));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_isTestExists, _formname = _str_isTestExists, _type = "bool",
              _get_func = o => o.isTestExists,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.isTestExists != c.isTestExists || o.IsRIRPropChanged(_str_isTestExists, c)) {
                  m.Add(_str_isTestExists, o.ObjectIdent + _str_isTestExists, o.ObjectIdent2 + _str_isTestExists, o.ObjectIdent3 + _str_isTestExists, "bool", o.isTestExists == null ? "" : o.isTestExists.ToString(), o.IsReadOnly(_str_isTestExists), o.IsInvisible(_str_isTestExists), o.IsRequired(_str_isTestExists));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_isNotTestExistsWithAccessioned, _formname = _str_isNotTestExistsWithAccessioned, _type = "bool",
              _get_func = o => o.isNotTestExistsWithAccessioned,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.isNotTestExistsWithAccessioned != c.isNotTestExistsWithAccessioned || o.IsRIRPropChanged(_str_isNotTestExistsWithAccessioned, c)) {
                  m.Add(_str_isNotTestExistsWithAccessioned, o.ObjectIdent + _str_isNotTestExistsWithAccessioned, o.ObjectIdent2 + _str_isNotTestExistsWithAccessioned, o.ObjectIdent3 + _str_isNotTestExistsWithAccessioned, "bool", o.isNotTestExistsWithAccessioned == null ? "" : o.isNotTestExistsWithAccessioned.ToString(), o.IsReadOnly(_str_isNotTestExistsWithAccessioned), o.IsInvisible(_str_isNotTestExistsWithAccessioned), o.IsRequired(_str_isNotTestExistsWithAccessioned));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_isTestNotStartedBefore, _formname = _str_isTestNotStartedBefore, _type = "bool",
              _get_func = o => o.isTestNotStartedBefore,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.isTestNotStartedBefore != c.isTestNotStartedBefore || o.IsRIRPropChanged(_str_isTestNotStartedBefore, c)) {
                  m.Add(_str_isTestNotStartedBefore, o.ObjectIdent + _str_isTestNotStartedBefore, o.ObjectIdent2 + _str_isTestNotStartedBefore, o.ObjectIdent3 + _str_isTestNotStartedBefore, "bool", o.isTestNotStartedBefore == null ? "" : o.isTestNotStartedBefore.ToString(), o.IsReadOnly(_str_isTestNotStartedBefore), o.IsInvisible(_str_isTestNotStartedBefore), o.IsRequired(_str_isTestNotStartedBefore));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_isTestNotStartedAfter, _formname = _str_isTestNotStartedAfter, _type = "bool",
              _get_func = o => o.isTestNotStartedAfter,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.isTestNotStartedAfter != c.isTestNotStartedAfter || o.IsRIRPropChanged(_str_isTestNotStartedAfter, c)) {
                  m.Add(_str_isTestNotStartedAfter, o.ObjectIdent + _str_isTestNotStartedAfter, o.ObjectIdent2 + _str_isTestNotStartedAfter, o.ObjectIdent3 + _str_isTestNotStartedAfter, "bool", o.isTestNotStartedAfter == null ? "" : o.isTestNotStartedAfter.ToString(), o.IsReadOnly(_str_isTestNotStartedAfter), o.IsInvisible(_str_isTestNotStartedAfter), o.IsRequired(_str_isTestNotStartedAfter));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_isTestInProcessBefore, _formname = _str_isTestInProcessBefore, _type = "bool",
              _get_func = o => o.isTestInProcessBefore,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.isTestInProcessBefore != c.isTestInProcessBefore || o.IsRIRPropChanged(_str_isTestInProcessBefore, c)) {
                  m.Add(_str_isTestInProcessBefore, o.ObjectIdent + _str_isTestInProcessBefore, o.ObjectIdent2 + _str_isTestInProcessBefore, o.ObjectIdent3 + _str_isTestInProcessBefore, "bool", o.isTestInProcessBefore == null ? "" : o.isTestInProcessBefore.ToString(), o.IsReadOnly(_str_isTestInProcessBefore), o.IsInvisible(_str_isTestInProcessBefore), o.IsRequired(_str_isTestInProcessBefore));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_isTestInProcessAfter, _formname = _str_isTestInProcessAfter, _type = "bool",
              _get_func = o => o.isTestInProcessAfter,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.isTestInProcessAfter != c.isTestInProcessAfter || o.IsRIRPropChanged(_str_isTestInProcessAfter, c)) {
                  m.Add(_str_isTestInProcessAfter, o.ObjectIdent + _str_isTestInProcessAfter, o.ObjectIdent2 + _str_isTestInProcessAfter, o.ObjectIdent3 + _str_isTestInProcessAfter, "bool", o.isTestInProcessAfter == null ? "" : o.isTestInProcessAfter.ToString(), o.IsReadOnly(_str_isTestInProcessAfter), o.IsInvisible(_str_isTestInProcessAfter), o.IsRequired(_str_isTestInProcessAfter));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_isTestPreliminary, _formname = _str_isTestPreliminary, _type = "bool",
              _get_func = o => o.isTestPreliminary,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.isTestPreliminary != c.isTestPreliminary || o.IsRIRPropChanged(_str_isTestPreliminary, c)) {
                  m.Add(_str_isTestPreliminary, o.ObjectIdent + _str_isTestPreliminary, o.ObjectIdent2 + _str_isTestPreliminary, o.ObjectIdent3 + _str_isTestPreliminary, "bool", o.isTestPreliminary == null ? "" : o.isTestPreliminary.ToString(), o.IsReadOnly(_str_isTestPreliminary), o.IsInvisible(_str_isTestPreliminary), o.IsRequired(_str_isTestPreliminary));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_isTestFinalInternalBefore, _formname = _str_isTestFinalInternalBefore, _type = "bool",
              _get_func = o => o.isTestFinalInternalBefore,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.isTestFinalInternalBefore != c.isTestFinalInternalBefore || o.IsRIRPropChanged(_str_isTestFinalInternalBefore, c)) {
                  m.Add(_str_isTestFinalInternalBefore, o.ObjectIdent + _str_isTestFinalInternalBefore, o.ObjectIdent2 + _str_isTestFinalInternalBefore, o.ObjectIdent3 + _str_isTestFinalInternalBefore, "bool", o.isTestFinalInternalBefore == null ? "" : o.isTestFinalInternalBefore.ToString(), o.IsReadOnly(_str_isTestFinalInternalBefore), o.IsInvisible(_str_isTestFinalInternalBefore), o.IsRequired(_str_isTestFinalInternalBefore));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_isTestFinalInternalAfter, _formname = _str_isTestFinalInternalAfter, _type = "bool",
              _get_func = o => o.isTestFinalInternalAfter,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.isTestFinalInternalAfter != c.isTestFinalInternalAfter || o.IsRIRPropChanged(_str_isTestFinalInternalAfter, c)) {
                  m.Add(_str_isTestFinalInternalAfter, o.ObjectIdent + _str_isTestFinalInternalAfter, o.ObjectIdent2 + _str_isTestFinalInternalAfter, o.ObjectIdent3 + _str_isTestFinalInternalAfter, "bool", o.isTestFinalInternalAfter == null ? "" : o.isTestFinalInternalAfter.ToString(), o.IsReadOnly(_str_isTestFinalInternalAfter), o.IsInvisible(_str_isTestFinalInternalAfter), o.IsRequired(_str_isTestFinalInternalAfter));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_isTestFinalExternalBefore, _formname = _str_isTestFinalExternalBefore, _type = "bool",
              _get_func = o => o.isTestFinalExternalBefore,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.isTestFinalExternalBefore != c.isTestFinalExternalBefore || o.IsRIRPropChanged(_str_isTestFinalExternalBefore, c)) {
                  m.Add(_str_isTestFinalExternalBefore, o.ObjectIdent + _str_isTestFinalExternalBefore, o.ObjectIdent2 + _str_isTestFinalExternalBefore, o.ObjectIdent3 + _str_isTestFinalExternalBefore, "bool", o.isTestFinalExternalBefore == null ? "" : o.isTestFinalExternalBefore.ToString(), o.IsReadOnly(_str_isTestFinalExternalBefore), o.IsInvisible(_str_isTestFinalExternalBefore), o.IsRequired(_str_isTestFinalExternalBefore));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_isTestFinalOrAmend, _formname = _str_isTestFinalOrAmend, _type = "bool",
              _get_func = o => o.isTestFinalOrAmend,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.isTestFinalOrAmend != c.isTestFinalOrAmend || o.IsRIRPropChanged(_str_isTestFinalOrAmend, c)) {
                  m.Add(_str_isTestFinalOrAmend, o.ObjectIdent + _str_isTestFinalOrAmend, o.ObjectIdent2 + _str_isTestFinalOrAmend, o.ObjectIdent3 + _str_isTestFinalOrAmend, "bool", o.isTestFinalOrAmend == null ? "" : o.isTestFinalOrAmend.ToString(), o.IsReadOnly(_str_isTestFinalOrAmend), o.IsInvisible(_str_isTestFinalOrAmend), o.IsRequired(_str_isTestFinalOrAmend));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_isTestFinalOrAmendSaved, _formname = _str_isTestFinalOrAmendSaved, _type = "bool",
              _get_func = o => o.isTestFinalOrAmendSaved,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.isTestFinalOrAmendSaved != c.isTestFinalOrAmendSaved || o.IsRIRPropChanged(_str_isTestFinalOrAmendSaved, c)) {
                  m.Add(_str_isTestFinalOrAmendSaved, o.ObjectIdent + _str_isTestFinalOrAmendSaved, o.ObjectIdent2 + _str_isTestFinalOrAmendSaved, o.ObjectIdent3 + _str_isTestFinalOrAmendSaved, "bool", o.isTestFinalOrAmendSaved == null ? "" : o.isTestFinalOrAmendSaved.ToString(), o.IsReadOnly(_str_isTestFinalOrAmendSaved), o.IsInvisible(_str_isTestFinalOrAmendSaved), o.IsRequired(_str_isTestFinalOrAmendSaved));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Region, _formname = _str_Region, _type = "Lookup",
              _get_func = o => { if (o.Region == null) return null; return o.Region.idfsRegion; },
              _set_func = (o, val) => { o.Region = o.RegionLookup.Where(c => c.idfsRegion.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_Region, c)) {
                  m.Add(_str_Region, o.ObjectIdent + _str_Region, o.ObjectIdent2 + _str_Region, o.ObjectIdent3 + _str_Region, "Lookup", o.idfsRegion == null ? "" : o.idfsRegion.ToString(), o.IsReadOnly(_str_Region), o.IsInvisible(_str_Region), o.IsRequired(_str_Region)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Region + "Lookup", _formname = _str_Region + "Lookup", _type = "LookupContent",
              _get_func = o => o.RegionLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Rayon, _formname = _str_Rayon, _type = "Lookup",
              _get_func = o => { if (o.Rayon == null) return null; return o.Rayon.idfsRayon; },
              _set_func = (o, val) => { o.Rayon = o.RayonLookup.Where(c => c.idfsRayon.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_Rayon, c)) {
                  m.Add(_str_Rayon, o.ObjectIdent + _str_Rayon, o.ObjectIdent2 + _str_Rayon, o.ObjectIdent3 + _str_Rayon, "Lookup", o.idfsRayon == null ? "" : o.idfsRayon.ToString(), o.IsReadOnly(_str_Rayon), o.IsInvisible(_str_Rayon), o.IsRequired(_str_Rayon)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Rayon + "Lookup", _formname = _str_Rayon + "Lookup", _type = "LookupContent",
              _get_func = o => o.RayonLookup,
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
              _name = _str_DiagnosisForTest, _formname = _str_DiagnosisForTest, _type = "Lookup",
              _get_func = o => { if (o.DiagnosisForTest == null) return null; return o.DiagnosisForTest.idfsDiagnosis; },
              _set_func = (o, val) => { o.DiagnosisForTest = o.DiagnosisForTestLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_DiagnosisForTest, c)) {
                  m.Add(_str_DiagnosisForTest, o.ObjectIdent + _str_DiagnosisForTest, o.ObjectIdent2 + _str_DiagnosisForTest, o.ObjectIdent3 + _str_DiagnosisForTest, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_DiagnosisForTest), o.IsInvisible(_str_DiagnosisForTest), o.IsRequired(_str_DiagnosisForTest)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_DiagnosisForTest + "Lookup", _formname = _str_DiagnosisForTest + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisForTestLookup,
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
              _name = _str_SampleTypeFiltered, _formname = _str_SampleTypeFiltered, _type = "Lookup",
              _get_func = o => { if (o.SampleTypeFiltered == null) return null; return o.SampleTypeFiltered.idfsReference; },
              _set_func = (o, val) => { o.SampleTypeFiltered = o.SampleTypeFilteredLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSampleTypeFiltered != c.idfsSampleTypeFiltered || o.IsRIRPropChanged(_str_SampleTypeFiltered, c)) {
                  m.Add(_str_SampleTypeFiltered, o.ObjectIdent + _str_SampleTypeFiltered, o.ObjectIdent2 + _str_SampleTypeFiltered, o.ObjectIdent3 + _str_SampleTypeFiltered, "Lookup", o.idfsSampleTypeFiltered == null ? "" : o.idfsSampleTypeFiltered.ToString(), o.IsReadOnly(_str_SampleTypeFiltered), o.IsInvisible(_str_SampleTypeFiltered), o.IsRequired(_str_SampleTypeFiltered)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SampleTypeFiltered + "Lookup", _formname = _str_SampleTypeFiltered + "Lookup", _type = "LookupContent",
              _get_func = o => o.SampleTypeFilteredLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_DerivativeType, _formname = _str_DerivativeType, _type = "Lookup",
              _get_func = o => { if (o.DerivativeType == null) return null; return o.DerivativeType.idfDerivativeForSampleType; },
              _set_func = (o, val) => { o.DerivativeType = o.DerivativeTypeLookup.Where(c => c.idfDerivativeForSampleType.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfDerivativeForSampleType != c.idfDerivativeForSampleType || o.IsRIRPropChanged(_str_DerivativeType, c)) {
                  m.Add(_str_DerivativeType, o.ObjectIdent + _str_DerivativeType, o.ObjectIdent2 + _str_DerivativeType, o.ObjectIdent3 + _str_DerivativeType, "Lookup", o.idfDerivativeForSampleType == null ? "" : o.idfDerivativeForSampleType.ToString(), o.IsReadOnly(_str_DerivativeType), o.IsInvisible(_str_DerivativeType), o.IsRequired(_str_DerivativeType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_DerivativeType + "Lookup", _formname = _str_DerivativeType + "Lookup", _type = "LookupContent",
              _get_func = o => o.DerivativeTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_AccessionCondition, _formname = _str_AccessionCondition, _type = "Lookup",
              _get_func = o => { if (o.AccessionCondition == null) return null; return o.AccessionCondition.idfsBaseReference; },
              _set_func = (o, val) => { o.AccessionCondition = o.AccessionConditionLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAccessionCondition != c.idfsAccessionCondition || o.IsRIRPropChanged(_str_AccessionCondition, c)) {
                  m.Add(_str_AccessionCondition, o.ObjectIdent + _str_AccessionCondition, o.ObjectIdent2 + _str_AccessionCondition, o.ObjectIdent3 + _str_AccessionCondition, "Lookup", o.idfsAccessionCondition == null ? "" : o.idfsAccessionCondition.ToString(), o.IsReadOnly(_str_AccessionCondition), o.IsInvisible(_str_AccessionCondition), o.IsRequired(_str_AccessionCondition)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_AccessionCondition + "Lookup", _formname = _str_AccessionCondition + "Lookup", _type = "LookupContent",
              _get_func = o => o.AccessionConditionLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestNameForSearch, _formname = _str_TestNameForSearch, _type = "Lookup",
              _get_func = o => { if (o.TestNameForSearch == null) return null; return o.TestNameForSearch.idfsReference; },
              _set_func = (o, val) => { o.TestNameForSearch = o.TestNameForSearchLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestName != c.idfsTestName || o.IsRIRPropChanged(_str_TestNameForSearch, c)) {
                  m.Add(_str_TestNameForSearch, o.ObjectIdent + _str_TestNameForSearch, o.ObjectIdent2 + _str_TestNameForSearch, o.ObjectIdent3 + _str_TestNameForSearch, "Lookup", o.idfsTestName == null ? "" : o.idfsTestName.ToString(), o.IsReadOnly(_str_TestNameForSearch), o.IsInvisible(_str_TestNameForSearch), o.IsRequired(_str_TestNameForSearch)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestNameForSearch + "Lookup", _formname = _str_TestNameForSearch + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestNameForSearchLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestNameRef, _formname = _str_TestNameRef, _type = "Lookup",
              _get_func = o => { if (o.TestNameRef == null) return null; return o.TestNameRef.idfsReference; },
              _set_func = (o, val) => { o.TestNameRef = o.TestNameRefLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
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
              _name = _str_TestResultForAmend, _formname = _str_TestResultForAmend, _type = "Lookup",
              _get_func = o => { if (o.TestResultForAmend == null) return null; return o.TestResultForAmend.idfsReference; },
              _set_func = (o, val) => { o.TestResultForAmend = o.TestResultForAmendLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestResult != c.idfsTestResult || o.IsRIRPropChanged(_str_TestResultForAmend, c)) {
                  m.Add(_str_TestResultForAmend, o.ObjectIdent + _str_TestResultForAmend, o.ObjectIdent2 + _str_TestResultForAmend, o.ObjectIdent3 + _str_TestResultForAmend, "Lookup", o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(), o.IsReadOnly(_str_TestResultForAmend), o.IsInvisible(_str_TestResultForAmend), o.IsRequired(_str_TestResultForAmend)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestResultForAmend + "Lookup", _formname = _str_TestResultForAmend + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestResultForAmendLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestResultDummy, _formname = _str_TestResultDummy, _type = "Lookup",
              _get_func = o => { if (o.TestResultDummy == null) return null; return o.TestResultDummy.idfsBaseReference; },
              _set_func = (o, val) => { o.TestResultDummy = o.TestResultDummyLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestResultDummy != c.idfsTestResultDummy || o.IsRIRPropChanged(_str_TestResultDummy, c)) {
                  m.Add(_str_TestResultDummy, o.ObjectIdent + _str_TestResultDummy, o.ObjectIdent2 + _str_TestResultDummy, o.ObjectIdent3 + _str_TestResultDummy, "Lookup", o.idfsTestResultDummy == null ? "" : o.idfsTestResultDummy.ToString(), o.IsReadOnly(_str_TestResultDummy), o.IsInvisible(_str_TestResultDummy), o.IsRequired(_str_TestResultDummy)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestResultDummy + "Lookup", _formname = _str_TestResultDummy + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestResultDummyLookup,
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
              _name = _str_TestStatusShort, _formname = _str_TestStatusShort, _type = "Lookup",
              _get_func = o => { if (o.TestStatusShort == null) return null; return o.TestStatusShort.idfsBaseReference; },
              _set_func = (o, val) => { o.TestStatusShort = o.TestStatusShortLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestStatusDummy != c.idfsTestStatusDummy || o.IsRIRPropChanged(_str_TestStatusShort, c)) {
                  m.Add(_str_TestStatusShort, o.ObjectIdent + _str_TestStatusShort, o.ObjectIdent2 + _str_TestStatusShort, o.ObjectIdent3 + _str_TestStatusShort, "Lookup", o.idfsTestStatusDummy == null ? "" : o.idfsTestStatusDummy.ToString(), o.IsReadOnly(_str_TestStatusShort), o.IsInvisible(_str_TestStatusShort), o.IsRequired(_str_TestStatusShort)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestStatusShort + "Lookup", _formname = _str_TestStatusShort + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestStatusShortLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestStatusForSearch, _formname = _str_TestStatusForSearch, _type = "Lookup",
              _get_func = o => { if (o.TestStatusForSearch == null) return null; return o.TestStatusForSearch.idfsBaseReference; },
              _set_func = (o, val) => { o.TestStatusForSearch = o.TestStatusForSearchLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestStatusDummy != c.idfsTestStatusDummy || o.IsRIRPropChanged(_str_TestStatusForSearch, c)) {
                  m.Add(_str_TestStatusForSearch, o.ObjectIdent + _str_TestStatusForSearch, o.ObjectIdent2 + _str_TestStatusForSearch, o.ObjectIdent3 + _str_TestStatusForSearch, "Lookup", o.idfsTestStatusDummy == null ? "" : o.idfsTestStatusDummy.ToString(), o.IsReadOnly(_str_TestStatusForSearch), o.IsInvisible(_str_TestStatusForSearch), o.IsRequired(_str_TestStatusForSearch)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestStatusForSearch + "Lookup", _formname = _str_TestStatusForSearch + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestStatusForSearchLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestStatusFull, _formname = _str_TestStatusFull, _type = "Lookup",
              _get_func = o => { if (o.TestStatusFull == null) return null; return o.TestStatusFull.idfsBaseReference; },
              _set_func = (o, val) => { o.TestStatusFull = o.TestStatusFullLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestStatus != c.idfsTestStatus || o.IsRIRPropChanged(_str_TestStatusFull, c)) {
                  m.Add(_str_TestStatusFull, o.ObjectIdent + _str_TestStatusFull, o.ObjectIdent2 + _str_TestStatusFull, o.ObjectIdent3 + _str_TestStatusFull, "Lookup", o.idfsTestStatus == null ? "" : o.idfsTestStatus.ToString(), o.IsReadOnly(_str_TestStatusFull), o.IsInvisible(_str_TestStatusFull), o.IsRequired(_str_TestStatusFull)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestStatusFull + "Lookup", _formname = _str_TestStatusFull + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestStatusFullLookup,
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
              _name = _str_SampleStatusFull, _formname = _str_SampleStatusFull, _type = "Lookup",
              _get_func = o => { if (o.SampleStatusFull == null) return null; return o.SampleStatusFull.idfsBaseReference; },
              _set_func = (o, val) => { o.SampleStatusFull = o.SampleStatusFullLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSampleStatus != c.idfsSampleStatus || o.IsRIRPropChanged(_str_SampleStatusFull, c)) {
                  m.Add(_str_SampleStatusFull, o.ObjectIdent + _str_SampleStatusFull, o.ObjectIdent2 + _str_SampleStatusFull, o.ObjectIdent3 + _str_SampleStatusFull, "Lookup", o.idfsSampleStatus == null ? "" : o.idfsSampleStatus.ToString(), o.IsReadOnly(_str_SampleStatusFull), o.IsInvisible(_str_SampleStatusFull), o.IsRequired(_str_SampleStatusFull)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SampleStatusFull + "Lookup", _formname = _str_SampleStatusFull + "Lookup", _type = "LookupContent",
              _get_func = o => o.SampleStatusFullLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_AccessionByPerson, _formname = _str_AccessionByPerson, _type = "Lookup",
              _get_func = o => { if (o.AccessionByPerson == null) return null; return o.AccessionByPerson.idfPerson; },
              _set_func = (o, val) => { o.AccessionByPerson = o.AccessionByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfAccesionByPerson != c.idfAccesionByPerson || o.IsRIRPropChanged(_str_AccessionByPerson, c)) {
                  m.Add(_str_AccessionByPerson, o.ObjectIdent + _str_AccessionByPerson, o.ObjectIdent2 + _str_AccessionByPerson, o.ObjectIdent3 + _str_AccessionByPerson, "Lookup", o.idfAccesionByPerson == null ? "" : o.idfAccesionByPerson.ToString(), o.IsReadOnly(_str_AccessionByPerson), o.IsInvisible(_str_AccessionByPerson), o.IsRequired(_str_AccessionByPerson)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_AccessionByPerson + "Lookup", _formname = _str_AccessionByPerson + "Lookup", _type = "LookupContent",
              _get_func = o => o.AccessionByPersonLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_SendToOffice, _formname = _str_SendToOffice, _type = "Lookup",
              _get_func = o => { if (o.SendToOffice == null) return null; return o.SendToOffice.idfInstitution; },
              _set_func = (o, val) => { o.SendToOffice = o.SendToOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfSendToOffice != c.idfSendToOffice || o.IsRIRPropChanged(_str_SendToOffice, c)) {
                  m.Add(_str_SendToOffice, o.ObjectIdent + _str_SendToOffice, o.ObjectIdent2 + _str_SendToOffice, o.ObjectIdent3 + _str_SendToOffice, "Lookup", o.idfSendToOffice == null ? "" : o.idfSendToOffice.ToString(), o.IsReadOnly(_str_SendToOffice), o.IsInvisible(_str_SendToOffice), o.IsRequired(_str_SendToOffice)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SendToOffice + "Lookup", _formname = _str_SendToOffice + "Lookup", _type = "LookupContent",
              _get_func = o => o.SendToOfficeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_SendToOfficeOut, _formname = _str_SendToOfficeOut, _type = "Lookup",
              _get_func = o => { if (o.SendToOfficeOut == null) return null; return o.SendToOfficeOut.idfInstitution; },
              _set_func = (o, val) => { o.SendToOfficeOut = o.SendToOfficeOutLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfSendToOfficeOut != c.idfSendToOfficeOut || o.IsRIRPropChanged(_str_SendToOfficeOut, c)) {
                  m.Add(_str_SendToOfficeOut, o.ObjectIdent + _str_SendToOfficeOut, o.ObjectIdent2 + _str_SendToOfficeOut, o.ObjectIdent3 + _str_SendToOfficeOut, "Lookup", o.idfSendToOfficeOut == null ? "" : o.idfSendToOfficeOut.ToString(), o.IsReadOnly(_str_SendToOfficeOut), o.IsInvisible(_str_SendToOfficeOut), o.IsRequired(_str_SendToOfficeOut)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SendToOfficeOut + "Lookup", _formname = _str_SendToOfficeOut + "Lookup", _type = "LookupContent",
              _get_func = o => o.SendToOfficeOutLookup,
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
              _name = _str_CollectedByOffice, _formname = _str_CollectedByOffice, _type = "Lookup",
              _get_func = o => { if (o.CollectedByOffice == null) return null; return o.CollectedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.CollectedByOffice = o.CollectedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfFieldCollectedByOffice != c.idfFieldCollectedByOffice || o.IsRIRPropChanged(_str_CollectedByOffice, c)) {
                  m.Add(_str_CollectedByOffice, o.ObjectIdent + _str_CollectedByOffice, o.ObjectIdent2 + _str_CollectedByOffice, o.ObjectIdent3 + _str_CollectedByOffice, "Lookup", o.idfFieldCollectedByOffice == null ? "" : o.idfFieldCollectedByOffice.ToString(), o.IsReadOnly(_str_CollectedByOffice), o.IsInvisible(_str_CollectedByOffice), o.IsRequired(_str_CollectedByOffice)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_CollectedByOffice + "Lookup", _formname = _str_CollectedByOffice + "Lookup", _type = "LookupContent",
              _get_func = o => o.CollectedByOfficeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_CollectedByPerson, _formname = _str_CollectedByPerson, _type = "Lookup",
              _get_func = o => { if (o.CollectedByPerson == null) return null; return o.CollectedByPerson.idfPerson; },
              _set_func = (o, val) => { o.CollectedByPerson = o.CollectedByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfFieldCollectedByPerson != c.idfFieldCollectedByPerson || o.IsRIRPropChanged(_str_CollectedByPerson, c)) {
                  m.Add(_str_CollectedByPerson, o.ObjectIdent + _str_CollectedByPerson, o.ObjectIdent2 + _str_CollectedByPerson, o.ObjectIdent3 + _str_CollectedByPerson, "Lookup", o.idfFieldCollectedByPerson == null ? "" : o.idfFieldCollectedByPerson.ToString(), o.IsReadOnly(_str_CollectedByPerson), o.IsInvisible(_str_CollectedByPerson), o.IsRequired(_str_CollectedByPerson)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_CollectedByPerson + "Lookup", _formname = _str_CollectedByPerson + "Lookup", _type = "LookupContent",
              _get_func = o => o.CollectedByPersonLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_CaseType, _formname = _str_CaseType, _type = "Lookup",
              _get_func = o => { if (o.CaseType == null) return null; return o.CaseType.idfsBaseReference; },
              _set_func = (o, val) => { o.CaseType = o.CaseTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_CaseType, c)) {
                  m.Add(_str_CaseType, o.ObjectIdent + _str_CaseType, o.ObjectIdent2 + _str_CaseType, o.ObjectIdent3 + _str_CaseType, "Lookup", o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(), o.IsReadOnly(_str_CaseType), o.IsInvisible(_str_CaseType), o.IsRequired(_str_CaseType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_CaseType + "Lookup", _formname = _str_CaseType + "Lookup", _type = "LookupContent",
              _get_func = o => o.CaseTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_DestructionMethod, _formname = _str_DestructionMethod, _type = "Lookup",
              _get_func = o => { if (o.DestructionMethod == null) return null; return o.DestructionMethod.idfsBaseReference; },
              _set_func = (o, val) => { o.DestructionMethod = o.DestructionMethodLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDestructionMethod != c.idfsDestructionMethod || o.IsRIRPropChanged(_str_DestructionMethod, c)) {
                  m.Add(_str_DestructionMethod, o.ObjectIdent + _str_DestructionMethod, o.ObjectIdent2 + _str_DestructionMethod, o.ObjectIdent3 + _str_DestructionMethod, "Lookup", o.idfsDestructionMethod == null ? "" : o.idfsDestructionMethod.ToString(), o.IsReadOnly(_str_DestructionMethod), o.IsInvisible(_str_DestructionMethod), o.IsRequired(_str_DestructionMethod)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_DestructionMethod + "Lookup", _formname = _str_DestructionMethod + "Lookup", _type = "LookupContent",
              _get_func = o => o.DestructionMethodLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_SampleKind, _formname = _str_SampleKind, _type = "Lookup",
              _get_func = o => { if (o.SampleKind == null) return null; return o.SampleKind.idfsBaseReference; },
              _set_func = (o, val) => { o.SampleKind = o.SampleKindLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSampleKind != c.idfsSampleKind || o.IsRIRPropChanged(_str_SampleKind, c)) {
                  m.Add(_str_SampleKind, o.ObjectIdent + _str_SampleKind, o.ObjectIdent2 + _str_SampleKind, o.ObjectIdent3 + _str_SampleKind, "Lookup", o.idfsSampleKind == null ? "" : o.idfsSampleKind.ToString(), o.IsReadOnly(_str_SampleKind), o.IsInvisible(_str_SampleKind), o.IsRequired(_str_SampleKind)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SampleKind + "Lookup", _formname = _str_SampleKind + "Lookup", _type = "LookupContent",
              _get_func = o => o.SampleKindLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_SpeciesVectorInfo, _formname = _str_SpeciesVectorInfo, _type = "Lookup",
              _get_func = o => { if (o.SpeciesVectorInfo == null) return null; return o.SpeciesVectorInfo.idfSpeciesVectorInfo; },
              _set_func = (o, val) => { o.SpeciesVectorInfo = o.SpeciesVectorInfoLookup.Where(c => c.idfSpeciesVectorInfo.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfSpeciesVectorInfo != c.idfSpeciesVectorInfo || o.IsRIRPropChanged(_str_SpeciesVectorInfo, c)) {
                  m.Add(_str_SpeciesVectorInfo, o.ObjectIdent + _str_SpeciesVectorInfo, o.ObjectIdent2 + _str_SpeciesVectorInfo, o.ObjectIdent3 + _str_SpeciesVectorInfo, "Lookup", o.idfSpeciesVectorInfo == null ? "" : o.idfSpeciesVectorInfo.ToString(), o.IsReadOnly(_str_SpeciesVectorInfo), o.IsInvisible(_str_SpeciesVectorInfo), o.IsRequired(_str_SpeciesVectorInfo)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SpeciesVectorInfo + "Lookup", _formname = _str_SpeciesVectorInfo + "Lookup", _type = "LookupContent",
              _get_func = o => o.SpeciesVectorInfoLookup,
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
        
            new field_info {
              _name = _str_TestedByOffice, _formname = _str_TestedByOffice, _type = "Lookup",
              _get_func = o => { if (o.TestedByOffice == null) return null; return o.TestedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.TestedByOffice = o.TestedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfTestedByOffice != c.idfTestedByOffice || o.IsRIRPropChanged(_str_TestedByOffice, c)) {
                  m.Add(_str_TestedByOffice, o.ObjectIdent + _str_TestedByOffice, o.ObjectIdent2 + _str_TestedByOffice, o.ObjectIdent3 + _str_TestedByOffice, "Lookup", o.idfTestedByOffice == null ? "" : o.idfTestedByOffice.ToString(), o.IsReadOnly(_str_TestedByOffice), o.IsInvisible(_str_TestedByOffice), o.IsRequired(_str_TestedByOffice)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestedByOffice + "Lookup", _formname = _str_TestedByOffice + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestedByOfficeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestedByPerson, _formname = _str_TestedByPerson, _type = "Lookup",
              _get_func = o => { if (o.TestedByPerson == null) return null; return o.TestedByPerson.idfPerson; },
              _set_func = (o, val) => { o.TestedByPerson = o.TestedByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfTestedByPerson != c.idfTestedByPerson || o.IsRIRPropChanged(_str_TestedByPerson, c)) {
                  m.Add(_str_TestedByPerson, o.ObjectIdent + _str_TestedByPerson, o.ObjectIdent2 + _str_TestedByPerson, o.ObjectIdent3 + _str_TestedByPerson, "Lookup", o.idfTestedByPerson == null ? "" : o.idfTestedByPerson.ToString(), o.IsReadOnly(_str_TestedByPerson), o.IsInvisible(_str_TestedByPerson), o.IsRequired(_str_TestedByPerson)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestedByPerson + "Lookup", _formname = _str_TestedByPerson + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestedByPersonLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_ResultEnteredByOffice, _formname = _str_ResultEnteredByOffice, _type = "Lookup",
              _get_func = o => { if (o.ResultEnteredByOffice == null) return null; return o.ResultEnteredByOffice.idfInstitution; },
              _set_func = (o, val) => { o.ResultEnteredByOffice = o.ResultEnteredByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfResultEnteredByOffice != c.idfResultEnteredByOffice || o.IsRIRPropChanged(_str_ResultEnteredByOffice, c)) {
                  m.Add(_str_ResultEnteredByOffice, o.ObjectIdent + _str_ResultEnteredByOffice, o.ObjectIdent2 + _str_ResultEnteredByOffice, o.ObjectIdent3 + _str_ResultEnteredByOffice, "Lookup", o.idfResultEnteredByOffice == null ? "" : o.idfResultEnteredByOffice.ToString(), o.IsReadOnly(_str_ResultEnteredByOffice), o.IsInvisible(_str_ResultEnteredByOffice), o.IsRequired(_str_ResultEnteredByOffice)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_ResultEnteredByOffice + "Lookup", _formname = _str_ResultEnteredByOffice + "Lookup", _type = "LookupContent",
              _get_func = o => o.ResultEnteredByOfficeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_ResultEnteredByPerson, _formname = _str_ResultEnteredByPerson, _type = "Lookup",
              _get_func = o => { if (o.ResultEnteredByPerson == null) return null; return o.ResultEnteredByPerson.idfPerson; },
              _set_func = (o, val) => { o.ResultEnteredByPerson = o.ResultEnteredByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfResultEnteredByPerson != c.idfResultEnteredByPerson || o.IsRIRPropChanged(_str_ResultEnteredByPerson, c)) {
                  m.Add(_str_ResultEnteredByPerson, o.ObjectIdent + _str_ResultEnteredByPerson, o.ObjectIdent2 + _str_ResultEnteredByPerson, o.ObjectIdent3 + _str_ResultEnteredByPerson, "Lookup", o.idfResultEnteredByPerson == null ? "" : o.idfResultEnteredByPerson.ToString(), o.IsReadOnly(_str_ResultEnteredByPerson), o.IsInvisible(_str_ResultEnteredByPerson), o.IsRequired(_str_ResultEnteredByPerson)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_ResultEnteredByPerson + "Lookup", _formname = _str_ResultEnteredByPerson + "Lookup", _type = "LookupContent",
              _get_func = o => o.ResultEnteredByPersonLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_ValidatedByOffice, _formname = _str_ValidatedByOffice, _type = "Lookup",
              _get_func = o => { if (o.ValidatedByOffice == null) return null; return o.ValidatedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.ValidatedByOffice = o.ValidatedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfValidatedByOffice != c.idfValidatedByOffice || o.IsRIRPropChanged(_str_ValidatedByOffice, c)) {
                  m.Add(_str_ValidatedByOffice, o.ObjectIdent + _str_ValidatedByOffice, o.ObjectIdent2 + _str_ValidatedByOffice, o.ObjectIdent3 + _str_ValidatedByOffice, "Lookup", o.idfValidatedByOffice == null ? "" : o.idfValidatedByOffice.ToString(), o.IsReadOnly(_str_ValidatedByOffice), o.IsInvisible(_str_ValidatedByOffice), o.IsRequired(_str_ValidatedByOffice)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_ValidatedByOffice + "Lookup", _formname = _str_ValidatedByOffice + "Lookup", _type = "LookupContent",
              _get_func = o => o.ValidatedByOfficeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_ValidatedByPerson, _formname = _str_ValidatedByPerson, _type = "Lookup",
              _get_func = o => { if (o.ValidatedByPerson == null) return null; return o.ValidatedByPerson.idfPerson; },
              _set_func = (o, val) => { o.ValidatedByPerson = o.ValidatedByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfValidatedByPerson != c.idfValidatedByPerson || o.IsRIRPropChanged(_str_ValidatedByPerson, c)) {
                  m.Add(_str_ValidatedByPerson, o.ObjectIdent + _str_ValidatedByPerson, o.ObjectIdent2 + _str_ValidatedByPerson, o.ObjectIdent3 + _str_ValidatedByPerson, "Lookup", o.idfValidatedByPerson == null ? "" : o.idfValidatedByPerson.ToString(), o.IsReadOnly(_str_ValidatedByPerson), o.IsInvisible(_str_ValidatedByPerson), o.IsRequired(_str_ValidatedByPerson)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_ValidatedByPerson + "Lookup", _formname = _str_ValidatedByPerson + "Lookup", _type = "LookupContent",
              _get_func = o => o.ValidatedByPersonLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Sample, _formname = _str_Sample, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Sample.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Sample.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.Sample.Count != c.Sample.Count || o.IsReadOnly(_str_Sample) != c.IsReadOnly(_str_Sample) || o.IsInvisible(_str_Sample) != c.IsInvisible(_str_Sample) || o.IsRequired(_str_Sample) != c._isRequired(o.m_isRequired, _str_Sample)) {
                  m.Add(_str_Sample, o.ObjectIdent + _str_Sample, o.ObjectIdent2 + _str_Sample, o.ObjectIdent3 + _str_Sample, "Child", o.ID == null ? "" : o.ID.ToString(), o.IsReadOnly(_str_Sample), o.IsInvisible(_str_Sample), o.IsRequired(_str_Sample)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Test, _formname = _str_Test, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Test.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Test.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.Test.Count != c.Test.Count || o.IsReadOnly(_str_Test) != c.IsReadOnly(_str_Test) || o.IsInvisible(_str_Test) != c.IsInvisible(_str_Test) || o.IsRequired(_str_Test) != c._isRequired(o.m_isRequired, _str_Test)) {
                  m.Add(_str_Test, o.ObjectIdent + _str_Test, o.ObjectIdent2 + _str_Test, o.ObjectIdent3 + _str_Test, "Child", o.ID == null ? "" : o.ID.ToString(), o.IsReadOnly(_str_Test), o.IsInvisible(_str_Test), o.IsRequired(_str_Test)); 
                  }
                }
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
            LaboratorySectionItem obj = (LaboratorySectionItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Sample)]
        [Relation(typeof(LaboratorySectionItem), eidss.model.Schema.LaboratorySectionItem._str_ID, _str_ID)]
        public EditableList<LaboratorySectionItem> Sample
        {
            get 
            {   
                return _Sample; 
            }
            set 
            {
                _Sample = value;
            }
        }
        protected EditableList<LaboratorySectionItem> _Sample = new EditableList<LaboratorySectionItem>();
                    
        [LocalizedDisplayName(_str_Test)]
        [Relation(typeof(LaboratorySectionItem), eidss.model.Schema.LaboratorySectionItem._str_ID, _str_ID)]
        public EditableList<LaboratorySectionItem> Test
        {
            get 
            {   
                return _Test; 
            }
            set 
            {
                _Test = value;
            }
        }
        protected EditableList<LaboratorySectionItem> _Test = new EditableList<LaboratorySectionItem>();
                    
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
                    
        [LocalizedDisplayName(_str_FFPresenter)]
        [Relation(typeof(FFPresenterModel), eidss.model.Schema.FFPresenterModel._str_CurrentObservation, _str_idfObservation)]
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
                        ? new Int64?()
                        : _FFPresenter.CurrentObservation;
                
            }
        }
        protected FFPresenterModel _FFPresenter;
                    
        [LocalizedDisplayName(_str_Region)]
        [Relation(typeof(RegionLookup), eidss.model.Schema.RegionLookup._str_idfsRegion, _str_idfsRegion)]
        public RegionLookup Region
        {
            get { return _Region == null ? null : ((long)_Region.Key == 0 ? null : _Region); }
            set 
            { 
                var oldVal = _Region;
                _Region = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Region != oldVal)
                {
                    if (idfsRegion != (_Region == null
                            ? new Int64?()
                            : (Int64?)_Region.idfsRegion))
                        idfsRegion = _Region == null 
                            ? new Int64?()
                            : (Int64?)_Region.idfsRegion; 
                    OnPropertyChanged(_str_Region); 
                }
            }
        }
        private RegionLookup _Region;

        
        public List<RegionLookup> RegionLookup
        {
            get { return _RegionLookup; }
        }
        private List<RegionLookup> _RegionLookup = new List<RegionLookup>();
            
        [LocalizedDisplayName(_str_Rayon)]
        [Relation(typeof(RayonLookup), eidss.model.Schema.RayonLookup._str_idfsRayon, _str_idfsRayon)]
        public RayonLookup Rayon
        {
            get { return _Rayon == null ? null : ((long)_Rayon.Key == 0 ? null : _Rayon); }
            set 
            { 
                var oldVal = _Rayon;
                _Rayon = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Rayon != oldVal)
                {
                    if (idfsRayon != (_Rayon == null
                            ? new Int64?()
                            : (Int64?)_Rayon.idfsRayon))
                        idfsRayon = _Rayon == null 
                            ? new Int64?()
                            : (Int64?)_Rayon.idfsRayon; 
                    OnPropertyChanged(_str_Rayon); 
                }
            }
        }
        private RayonLookup _Rayon;

        
        public List<RayonLookup> RayonLookup
        {
            get { return _RayonLookup; }
        }
        private List<RayonLookup> _RayonLookup = new List<RayonLookup>();
            
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
                            ? new Int64?()
                            : (Int64?)_Diagnosis.idfsDiagnosis))
                        idfsDiagnosis = _Diagnosis == null 
                            ? new Int64?()
                            : (Int64?)_Diagnosis.idfsDiagnosis; 
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
            
        [LocalizedDisplayName("TestDiagnosisName")]
        [Relation(typeof(TestDiagnosisLookup), eidss.model.Schema.TestDiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public TestDiagnosisLookup DiagnosisForTest
        {
            get { return _DiagnosisForTest == null ? null : ((long)_DiagnosisForTest.Key == 0 ? null : _DiagnosisForTest); }
            set 
            { 
                var oldVal = _DiagnosisForTest;
                _DiagnosisForTest = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_DiagnosisForTest != oldVal)
                {
                    if (idfsDiagnosis != (_DiagnosisForTest == null
                            ? new Int64?()
                            : (Int64?)_DiagnosisForTest.idfsDiagnosis))
                        idfsDiagnosis = _DiagnosisForTest == null 
                            ? new Int64?()
                            : (Int64?)_DiagnosisForTest.idfsDiagnosis; 
                    OnPropertyChanged(_str_DiagnosisForTest); 
                }
            }
        }
        private TestDiagnosisLookup _DiagnosisForTest;

        
        public List<TestDiagnosisLookup> DiagnosisForTestLookup
        {
            get { return _DiagnosisForTestLookup; }
        }
        private List<TestDiagnosisLookup> _DiagnosisForTestLookup = new List<TestDiagnosisLookup>();
            
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
            
        [LocalizedDisplayName(_str_SampleTypeFiltered)]
        [Relation(typeof(SampleTypeForDiagnosisLookup), eidss.model.Schema.SampleTypeForDiagnosisLookup._str_idfsReference, _str_idfsSampleTypeFiltered)]
        public SampleTypeForDiagnosisLookup SampleTypeFiltered
        {
            get { return _SampleTypeFiltered == null ? null : ((long)_SampleTypeFiltered.Key == 0 ? null : _SampleTypeFiltered); }
            set 
            { 
                var oldVal = _SampleTypeFiltered;
                _SampleTypeFiltered = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SampleTypeFiltered != oldVal)
                {
                    if (idfsSampleTypeFiltered != (_SampleTypeFiltered == null
                            ? new Int64?()
                            : (Int64?)_SampleTypeFiltered.idfsReference))
                        idfsSampleTypeFiltered = _SampleTypeFiltered == null 
                            ? new Int64?()
                            : (Int64?)_SampleTypeFiltered.idfsReference; 
                    OnPropertyChanged(_str_SampleTypeFiltered); 
                }
            }
        }
        private SampleTypeForDiagnosisLookup _SampleTypeFiltered;

        
        public List<SampleTypeForDiagnosisLookup> SampleTypeFilteredLookup
        {
            get { return _SampleTypeFilteredLookup; }
        }
        private List<SampleTypeForDiagnosisLookup> _SampleTypeFilteredLookup = new List<SampleTypeForDiagnosisLookup>();
            
        [LocalizedDisplayName(_str_DerivativeType)]
        [Relation(typeof(LabDerivativeTypesLookup), eidss.model.Schema.LabDerivativeTypesLookup._str_idfDerivativeForSampleType, _str_idfDerivativeForSampleType)]
        public LabDerivativeTypesLookup DerivativeType
        {
            get { return _DerivativeType == null ? null : ((long)_DerivativeType.Key == 0 ? null : _DerivativeType); }
            set 
            { 
                var oldVal = _DerivativeType;
                _DerivativeType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_DerivativeType != oldVal)
                {
                    if (idfDerivativeForSampleType != (_DerivativeType == null
                            ? new long?()
                            : _DerivativeType.idfDerivativeForSampleType))
                        idfDerivativeForSampleType = _DerivativeType == null 
                            ? new long?()
                            : _DerivativeType.idfDerivativeForSampleType; 
                    OnPropertyChanged(_str_DerivativeType); 
                }
            }
        }
        private LabDerivativeTypesLookup _DerivativeType;

        
        public List<LabDerivativeTypesLookup> DerivativeTypeLookup
        {
            get { return _DerivativeTypeLookup; }
        }
        private List<LabDerivativeTypesLookup> _DerivativeTypeLookup = new List<LabDerivativeTypesLookup>();
            
        [LocalizedDisplayName(_str_AccessionCondition)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAccessionCondition)]
        public BaseReference AccessionCondition
        {
            get { return _AccessionCondition; }
            set 
            { 
                var oldVal = _AccessionCondition;
                _AccessionCondition = value;
                if (_AccessionCondition != oldVal)
                {
                    if (idfsAccessionCondition != (_AccessionCondition == null
                            ? new Int64?()
                            : (Int64?)_AccessionCondition.idfsBaseReference))
                        idfsAccessionCondition = _AccessionCondition == null 
                            ? new Int64?()
                            : (Int64?)_AccessionCondition.idfsBaseReference; 
                    OnPropertyChanged(_str_AccessionCondition); 
                }
            }
        }
        private BaseReference _AccessionCondition;

        
        public BaseReferenceList AccessionConditionLookup
        {
            get { return _AccessionConditionLookup; }
        }
        private BaseReferenceList _AccessionConditionLookup = new BaseReferenceList("rftAccessionCondition");
            
        [LocalizedDisplayName("TestName")]
        [Relation(typeof(TestForDiseaseLookup), eidss.model.Schema.TestForDiseaseLookup._str_idfsReference, _str_idfsTestName)]
        public TestForDiseaseLookup TestNameForSearch
        {
            get { return _TestNameForSearch == null ? null : ((long)_TestNameForSearch.Key == 0 ? null : _TestNameForSearch); }
            set 
            { 
                var oldVal = _TestNameForSearch;
                _TestNameForSearch = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestNameForSearch != oldVal)
                {
                    if (idfsTestName != (_TestNameForSearch == null
                            ? new Int64?()
                            : (Int64?)_TestNameForSearch.idfsReference))
                        idfsTestName = _TestNameForSearch == null 
                            ? new Int64?()
                            : (Int64?)_TestNameForSearch.idfsReference; 
                    OnPropertyChanged(_str_TestNameForSearch); 
                }
            }
        }
        private TestForDiseaseLookup _TestNameForSearch;

        
        public List<TestForDiseaseLookup> TestNameForSearchLookup
        {
            get { return _TestNameForSearchLookup; }
        }
        private List<TestForDiseaseLookup> _TestNameForSearchLookup = new List<TestForDiseaseLookup>();
            
        [LocalizedDisplayName("TestName")]
        [Relation(typeof(TestForDiseaseLookup), eidss.model.Schema.TestForDiseaseLookup._str_idfsReference, _str_idfsTestName)]
        public TestForDiseaseLookup TestNameRef
        {
            get { return _TestNameRef; }
            set 
            { 
                var oldVal = _TestNameRef;
                _TestNameRef = value;
                if (_TestNameRef != oldVal)
                {
                    if (idfsTestName != (_TestNameRef == null
                            ? new Int64?()
                            : (Int64?)_TestNameRef.idfsReference))
                        idfsTestName = _TestNameRef == null 
                            ? new Int64?()
                            : (Int64?)_TestNameRef.idfsReference; 
                    OnPropertyChanged(_str_TestNameRef); 
                }
            }
        }
        private TestForDiseaseLookup _TestNameRef;

        
        public List<TestForDiseaseLookup> TestNameRefLookup
        {
            get { return _TestNameRefLookup; }
        }
        private List<TestForDiseaseLookup> _TestNameRefLookup = new List<TestForDiseaseLookup>();
            
        [LocalizedDisplayName("TestResult")]
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
            
        [LocalizedDisplayName("strNewTestResult")]
        [Relation(typeof(TestResultLookup), eidss.model.Schema.TestResultLookup._str_idfsReference, _str_idfsTestResult)]
        public TestResultLookup TestResultForAmend
        {
            get { return _TestResultForAmend == null ? null : ((long)_TestResultForAmend.Key == 0 ? null : _TestResultForAmend); }
            set 
            { 
                var oldVal = _TestResultForAmend;
                _TestResultForAmend = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestResultForAmend != oldVal)
                {
                    if (idfsTestResult != (_TestResultForAmend == null
                            ? new Int64?()
                            : (Int64?)_TestResultForAmend.idfsReference))
                        idfsTestResult = _TestResultForAmend == null 
                            ? new Int64?()
                            : (Int64?)_TestResultForAmend.idfsReference; 
                    OnPropertyChanged(_str_TestResultForAmend); 
                }
            }
        }
        private TestResultLookup _TestResultForAmend;

        
        public List<TestResultLookup> TestResultForAmendLookup
        {
            get { return _TestResultForAmendLookup; }
        }
        private List<TestResultLookup> _TestResultForAmendLookup = new List<TestResultLookup>();
            
        [LocalizedDisplayName(_str_TestResultDummy)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestResultDummy)]
        public BaseReference TestResultDummy
        {
            get { return _TestResultDummy == null ? null : ((long)_TestResultDummy.Key == 0 ? null : _TestResultDummy); }
            set 
            { 
                var oldVal = _TestResultDummy;
                _TestResultDummy = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestResultDummy != oldVal)
                {
                    if (idfsTestResultDummy != (_TestResultDummy == null
                            ? new long?()
                            : _TestResultDummy.idfsBaseReference))
                        idfsTestResultDummy = _TestResultDummy == null 
                            ? new long?()
                            : _TestResultDummy.idfsBaseReference; 
                    OnPropertyChanged(_str_TestResultDummy); 
                }
            }
        }
        private BaseReference _TestResultDummy;

        
        public BaseReferenceList TestResultDummyLookup
        {
            get { return _TestResultDummyLookup; }
        }
        private BaseReferenceList _TestResultDummyLookup = new BaseReferenceList("rftTestResult");
            
        [LocalizedDisplayName("TestCategory")]
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
            
        [LocalizedDisplayName("TestStatus")]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestStatusDummy)]
        public BaseReference TestStatusShort
        {
            get { return _TestStatusShort; }
            set 
            { 
                var oldVal = _TestStatusShort;
                _TestStatusShort = value;
                if (_TestStatusShort != oldVal)
                {
                    if (idfsTestStatusDummy != (_TestStatusShort == null
                            ? new long?()
                            : _TestStatusShort.idfsBaseReference))
                        idfsTestStatusDummy = _TestStatusShort == null 
                            ? new long?()
                            : _TestStatusShort.idfsBaseReference; 
                    OnPropertyChanged(_str_TestStatusShort); 
                }
            }
        }
        private BaseReference _TestStatusShort;

        
        public BaseReferenceList TestStatusShortLookup
        {
            get { return _TestStatusShortLookup; }
        }
        private BaseReferenceList _TestStatusShortLookup = new BaseReferenceList("rftTestStatus");
            
        [LocalizedDisplayName(_str_TestStatusForSearch)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestStatusDummy)]
        public BaseReference TestStatusForSearch
        {
            get { return _TestStatusForSearch == null ? null : ((long)_TestStatusForSearch.Key == 0 ? null : _TestStatusForSearch); }
            set 
            { 
                var oldVal = _TestStatusForSearch;
                _TestStatusForSearch = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestStatusForSearch != oldVal)
                {
                    if (idfsTestStatusDummy != (_TestStatusForSearch == null
                            ? new long?()
                            : _TestStatusForSearch.idfsBaseReference))
                        idfsTestStatusDummy = _TestStatusForSearch == null 
                            ? new long?()
                            : _TestStatusForSearch.idfsBaseReference; 
                    OnPropertyChanged(_str_TestStatusForSearch); 
                }
            }
        }
        private BaseReference _TestStatusForSearch;

        
        public BaseReferenceList TestStatusForSearchLookup
        {
            get { return _TestStatusForSearchLookup; }
        }
        private BaseReferenceList _TestStatusForSearchLookup = new BaseReferenceList("rftTestStatus");
            
        [LocalizedDisplayName(_str_TestStatusFull)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestStatus)]
        public BaseReference TestStatusFull
        {
            get { return _TestStatusFull == null ? null : ((long)_TestStatusFull.Key == 0 ? null : _TestStatusFull); }
            set 
            { 
                var oldVal = _TestStatusFull;
                _TestStatusFull = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestStatusFull != oldVal)
                {
                    if (idfsTestStatus != (_TestStatusFull == null
                            ? new Int64?()
                            : (Int64?)_TestStatusFull.idfsBaseReference))
                        idfsTestStatus = _TestStatusFull == null 
                            ? new Int64?()
                            : (Int64?)_TestStatusFull.idfsBaseReference; 
                    OnPropertyChanged(_str_TestStatusFull); 
                }
            }
        }
        private BaseReference _TestStatusFull;

        
        public BaseReferenceList TestStatusFullLookup
        {
            get { return _TestStatusFullLookup; }
        }
        private BaseReferenceList _TestStatusFullLookup = new BaseReferenceList("rftTestStatus");
            
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
                            ? new Int64()
                            : (Int64)_SampleStatus.idfsBaseReference))
                        idfsSampleStatus = _SampleStatus == null 
                            ? new Int64()
                            : (Int64)_SampleStatus.idfsBaseReference; 
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
            
        [LocalizedDisplayName(_str_SampleStatusFull)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSampleStatus)]
        public BaseReference SampleStatusFull
        {
            get { return _SampleStatusFull == null ? null : ((long)_SampleStatusFull.Key == 0 ? null : _SampleStatusFull); }
            set 
            { 
                var oldVal = _SampleStatusFull;
                _SampleStatusFull = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SampleStatusFull != oldVal)
                {
                    if (idfsSampleStatus != (_SampleStatusFull == null
                            ? new Int64()
                            : (Int64)_SampleStatusFull.idfsBaseReference))
                        idfsSampleStatus = _SampleStatusFull == null 
                            ? new Int64()
                            : (Int64)_SampleStatusFull.idfsBaseReference; 
                    OnPropertyChanged(_str_SampleStatusFull); 
                }
            }
        }
        private BaseReference _SampleStatusFull;

        
        public BaseReferenceList SampleStatusFullLookup
        {
            get { return _SampleStatusFullLookup; }
        }
        private BaseReferenceList _SampleStatusFullLookup = new BaseReferenceList("rftSampleStatus");
            
        [LocalizedDisplayName(_str_AccessionByPerson)]
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfAccesionByPerson)]
        public PersonLookup AccessionByPerson
        {
            get { return _AccessionByPerson == null ? null : ((long)_AccessionByPerson.Key == 0 ? null : _AccessionByPerson); }
            set 
            { 
                var oldVal = _AccessionByPerson;
                _AccessionByPerson = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_AccessionByPerson != oldVal)
                {
                    if (idfAccesionByPerson != (_AccessionByPerson == null
                            ? new Int64?()
                            : (Int64?)_AccessionByPerson.idfPerson))
                        idfAccesionByPerson = _AccessionByPerson == null 
                            ? new Int64?()
                            : (Int64?)_AccessionByPerson.idfPerson; 
                    OnPropertyChanged(_str_AccessionByPerson); 
                }
            }
        }
        private PersonLookup _AccessionByPerson;

        
        public List<PersonLookup> AccessionByPersonLookup
        {
            get { return _AccessionByPersonLookup; }
        }
        private List<PersonLookup> _AccessionByPersonLookup = new List<PersonLookup>();
            
        [LocalizedDisplayName(_str_SendToOffice)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfSendToOffice)]
        public OrganizationLookup SendToOffice
        {
            get { return _SendToOffice == null ? null : ((long)_SendToOffice.Key == 0 ? null : _SendToOffice); }
            set 
            { 
                var oldVal = _SendToOffice;
                _SendToOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SendToOffice != oldVal)
                {
                    if (idfSendToOffice != (_SendToOffice == null
                            ? new Int64?()
                            : (Int64?)_SendToOffice.idfInstitution))
                        idfSendToOffice = _SendToOffice == null 
                            ? new Int64?()
                            : (Int64?)_SendToOffice.idfInstitution; 
                    OnPropertyChanged(_str_SendToOffice); 
                }
            }
        }
        private OrganizationLookup _SendToOffice;

        
        public List<OrganizationLookup> SendToOfficeLookup
        {
            get { return _SendToOfficeLookup; }
        }
        private List<OrganizationLookup> _SendToOfficeLookup = new List<OrganizationLookup>();
            
        [LocalizedDisplayName("TransferTo")]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfSendToOfficeOut)]
        public OrganizationLookup SendToOfficeOut
        {
            get { return _SendToOfficeOut == null ? null : ((long)_SendToOfficeOut.Key == 0 ? null : _SendToOfficeOut); }
            set 
            { 
                var oldVal = _SendToOfficeOut;
                _SendToOfficeOut = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SendToOfficeOut != oldVal)
                {
                    if (idfSendToOfficeOut != (_SendToOfficeOut == null
                            ? new Int64?()
                            : (Int64?)_SendToOfficeOut.idfInstitution))
                        idfSendToOfficeOut = _SendToOfficeOut == null 
                            ? new Int64?()
                            : (Int64?)_SendToOfficeOut.idfInstitution; 
                    OnPropertyChanged(_str_SendToOfficeOut); 
                }
            }
        }
        private OrganizationLookup _SendToOfficeOut;

        
        public List<OrganizationLookup> SendToOfficeOutLookup
        {
            get { return _SendToOfficeOutLookup; }
        }
        private List<OrganizationLookup> _SendToOfficeOutLookup = new List<OrganizationLookup>();
            
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
            
        [LocalizedDisplayName(_str_CollectedByOffice)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfFieldCollectedByOffice)]
        public OrganizationLookup CollectedByOffice
        {
            get { return _CollectedByOffice == null ? null : ((long)_CollectedByOffice.Key == 0 ? null : _CollectedByOffice); }
            set 
            { 
                var oldVal = _CollectedByOffice;
                _CollectedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_CollectedByOffice != oldVal)
                {
                    if (idfFieldCollectedByOffice != (_CollectedByOffice == null
                            ? new Int64?()
                            : (Int64?)_CollectedByOffice.idfInstitution))
                        idfFieldCollectedByOffice = _CollectedByOffice == null 
                            ? new Int64?()
                            : (Int64?)_CollectedByOffice.idfInstitution; 
                    OnPropertyChanged(_str_CollectedByOffice); 
                }
            }
        }
        private OrganizationLookup _CollectedByOffice;

        
        public List<OrganizationLookup> CollectedByOfficeLookup
        {
            get { return _CollectedByOfficeLookup; }
        }
        private List<OrganizationLookup> _CollectedByOfficeLookup = new List<OrganizationLookup>();
            
        [LocalizedDisplayName(_str_CollectedByPerson)]
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfFieldCollectedByPerson)]
        public PersonLookup CollectedByPerson
        {
            get { return _CollectedByPerson == null ? null : ((long)_CollectedByPerson.Key == 0 ? null : _CollectedByPerson); }
            set 
            { 
                var oldVal = _CollectedByPerson;
                _CollectedByPerson = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_CollectedByPerson != oldVal)
                {
                    if (idfFieldCollectedByPerson != (_CollectedByPerson == null
                            ? new Int64?()
                            : (Int64?)_CollectedByPerson.idfPerson))
                        idfFieldCollectedByPerson = _CollectedByPerson == null 
                            ? new Int64?()
                            : (Int64?)_CollectedByPerson.idfPerson; 
                    OnPropertyChanged(_str_CollectedByPerson); 
                }
            }
        }
        private PersonLookup _CollectedByPerson;

        
        public List<PersonLookup> CollectedByPersonLookup
        {
            get { return _CollectedByPersonLookup; }
        }
        private List<PersonLookup> _CollectedByPersonLookup = new List<PersonLookup>();
            
        [LocalizedDisplayName(_str_CaseType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCaseType)]
        public BaseReference CaseType
        {
            get { return _CaseType == null ? null : ((long)_CaseType.Key == 0 ? null : _CaseType); }
            set 
            { 
                var oldVal = _CaseType;
                _CaseType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_CaseType != oldVal)
                {
                    if (idfsCaseType != (_CaseType == null
                            ? new Int64?()
                            : (Int64?)_CaseType.idfsBaseReference))
                        idfsCaseType = _CaseType == null 
                            ? new Int64?()
                            : (Int64?)_CaseType.idfsBaseReference; 
                    OnPropertyChanged(_str_CaseType); 
                }
            }
        }
        private BaseReference _CaseType;

        
        public BaseReferenceList CaseTypeLookup
        {
            get { return _CaseTypeLookup; }
        }
        private BaseReferenceList _CaseTypeLookup = new BaseReferenceList("rftCaseType");
            
        [LocalizedDisplayName(_str_DestructionMethod)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsDestructionMethod)]
        public BaseReference DestructionMethod
        {
            get { return _DestructionMethod == null ? null : ((long)_DestructionMethod.Key == 0 ? null : _DestructionMethod); }
            set 
            { 
                var oldVal = _DestructionMethod;
                _DestructionMethod = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_DestructionMethod != oldVal)
                {
                    if (idfsDestructionMethod != (_DestructionMethod == null
                            ? new Int64?()
                            : (Int64?)_DestructionMethod.idfsBaseReference))
                        idfsDestructionMethod = _DestructionMethod == null 
                            ? new Int64?()
                            : (Int64?)_DestructionMethod.idfsBaseReference; 
                    OnPropertyChanged(_str_DestructionMethod); 
                }
            }
        }
        private BaseReference _DestructionMethod;

        
        public BaseReferenceList DestructionMethodLookup
        {
            get { return _DestructionMethodLookup; }
        }
        private BaseReferenceList _DestructionMethodLookup = new BaseReferenceList("rftDestructionMethod");
            
        [LocalizedDisplayName(_str_SampleKind)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSampleKind)]
        public BaseReference SampleKind
        {
            get { return _SampleKind == null ? null : ((long)_SampleKind.Key == 0 ? null : _SampleKind); }
            set 
            { 
                var oldVal = _SampleKind;
                _SampleKind = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SampleKind != oldVal)
                {
                    if (idfsSampleKind != (_SampleKind == null
                            ? new Int64?()
                            : (Int64?)_SampleKind.idfsBaseReference))
                        idfsSampleKind = _SampleKind == null 
                            ? new Int64?()
                            : (Int64?)_SampleKind.idfsBaseReference; 
                    OnPropertyChanged(_str_SampleKind); 
                }
            }
        }
        private BaseReference _SampleKind;

        
        public BaseReferenceList SampleKindLookup
        {
            get { return _SampleKindLookup; }
        }
        private BaseReferenceList _SampleKindLookup = new BaseReferenceList("rftSampleKind");
            
        [LocalizedDisplayName("strPatientSessionVectorInfo")]
        [Relation(typeof(SpeciesVectorInfoLookup), eidss.model.Schema.SpeciesVectorInfoLookup._str_idfSpeciesVectorInfo, _str_idfSpeciesVectorInfo)]
        public SpeciesVectorInfoLookup SpeciesVectorInfo
        {
            get { return _SpeciesVectorInfo == null ? null : ((long)_SpeciesVectorInfo.Key == 0 ? null : _SpeciesVectorInfo); }
            set 
            { 
                var oldVal = _SpeciesVectorInfo;
                _SpeciesVectorInfo = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SpeciesVectorInfo != oldVal)
                {
                    if (idfSpeciesVectorInfo != (_SpeciesVectorInfo == null
                            ? new Int64?()
                            : (Int64?)_SpeciesVectorInfo.idfSpeciesVectorInfo))
                        idfSpeciesVectorInfo = _SpeciesVectorInfo == null 
                            ? new Int64?()
                            : (Int64?)_SpeciesVectorInfo.idfSpeciesVectorInfo; 
                    OnPropertyChanged(_str_SpeciesVectorInfo); 
                }
            }
        }
        private SpeciesVectorInfoLookup _SpeciesVectorInfo;

        
        public List<SpeciesVectorInfoLookup> SpeciesVectorInfoLookup
        {
            get { return _SpeciesVectorInfoLookup; }
        }
        private List<SpeciesVectorInfoLookup> _SpeciesVectorInfoLookup = new List<SpeciesVectorInfoLookup>();
            
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
            
        [LocalizedDisplayName(_str_TestedByOffice)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfTestedByOffice)]
        public OrganizationLookup TestedByOffice
        {
            get { return _TestedByOffice == null ? null : ((long)_TestedByOffice.Key == 0 ? null : _TestedByOffice); }
            set 
            { 
                var oldVal = _TestedByOffice;
                _TestedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestedByOffice != oldVal)
                {
                    if (idfTestedByOffice != (_TestedByOffice == null
                            ? new Int64?()
                            : (Int64?)_TestedByOffice.idfInstitution))
                        idfTestedByOffice = _TestedByOffice == null 
                            ? new Int64?()
                            : (Int64?)_TestedByOffice.idfInstitution; 
                    OnPropertyChanged(_str_TestedByOffice); 
                }
            }
        }
        private OrganizationLookup _TestedByOffice;

        
        public List<OrganizationLookup> TestedByOfficeLookup
        {
            get { return _TestedByOfficeLookup; }
        }
        private List<OrganizationLookup> _TestedByOfficeLookup = new List<OrganizationLookup>();
            
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
            
        [LocalizedDisplayName(_str_ResultEnteredByOffice)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfResultEnteredByOffice)]
        public OrganizationLookup ResultEnteredByOffice
        {
            get { return _ResultEnteredByOffice == null ? null : ((long)_ResultEnteredByOffice.Key == 0 ? null : _ResultEnteredByOffice); }
            set 
            { 
                var oldVal = _ResultEnteredByOffice;
                _ResultEnteredByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_ResultEnteredByOffice != oldVal)
                {
                    if (idfResultEnteredByOffice != (_ResultEnteredByOffice == null
                            ? new Int64?()
                            : (Int64?)_ResultEnteredByOffice.idfInstitution))
                        idfResultEnteredByOffice = _ResultEnteredByOffice == null 
                            ? new Int64?()
                            : (Int64?)_ResultEnteredByOffice.idfInstitution; 
                    OnPropertyChanged(_str_ResultEnteredByOffice); 
                }
            }
        }
        private OrganizationLookup _ResultEnteredByOffice;

        
        public List<OrganizationLookup> ResultEnteredByOfficeLookup
        {
            get { return _ResultEnteredByOfficeLookup; }
        }
        private List<OrganizationLookup> _ResultEnteredByOfficeLookup = new List<OrganizationLookup>();
            
        [LocalizedDisplayName(_str_ResultEnteredByPerson)]
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfResultEnteredByPerson)]
        public PersonLookup ResultEnteredByPerson
        {
            get { return _ResultEnteredByPerson == null ? null : ((long)_ResultEnteredByPerson.Key == 0 ? null : _ResultEnteredByPerson); }
            set 
            { 
                var oldVal = _ResultEnteredByPerson;
                _ResultEnteredByPerson = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_ResultEnteredByPerson != oldVal)
                {
                    if (idfResultEnteredByPerson != (_ResultEnteredByPerson == null
                            ? new Int64?()
                            : (Int64?)_ResultEnteredByPerson.idfPerson))
                        idfResultEnteredByPerson = _ResultEnteredByPerson == null 
                            ? new Int64?()
                            : (Int64?)_ResultEnteredByPerson.idfPerson; 
                    OnPropertyChanged(_str_ResultEnteredByPerson); 
                }
            }
        }
        private PersonLookup _ResultEnteredByPerson;

        
        public List<PersonLookup> ResultEnteredByPersonLookup
        {
            get { return _ResultEnteredByPersonLookup; }
        }
        private List<PersonLookup> _ResultEnteredByPersonLookup = new List<PersonLookup>();
            
        [LocalizedDisplayName(_str_ValidatedByOffice)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfValidatedByOffice)]
        public OrganizationLookup ValidatedByOffice
        {
            get { return _ValidatedByOffice == null ? null : ((long)_ValidatedByOffice.Key == 0 ? null : _ValidatedByOffice); }
            set 
            { 
                var oldVal = _ValidatedByOffice;
                _ValidatedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_ValidatedByOffice != oldVal)
                {
                    if (idfValidatedByOffice != (_ValidatedByOffice == null
                            ? new Int64?()
                            : (Int64?)_ValidatedByOffice.idfInstitution))
                        idfValidatedByOffice = _ValidatedByOffice == null 
                            ? new Int64?()
                            : (Int64?)_ValidatedByOffice.idfInstitution; 
                    OnPropertyChanged(_str_ValidatedByOffice); 
                }
            }
        }
        private OrganizationLookup _ValidatedByOffice;

        
        public List<OrganizationLookup> ValidatedByOfficeLookup
        {
            get { return _ValidatedByOfficeLookup; }
        }
        private List<OrganizationLookup> _ValidatedByOfficeLookup = new List<OrganizationLookup>();
            
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
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Region:
                    return new BvSelectList(RegionLookup, eidss.model.Schema.RegionLookup._str_idfsRegion, null, Region, _str_idfsRegion);
            
                case _str_Rayon:
                    return new BvSelectList(RayonLookup, eidss.model.Schema.RayonLookup._str_idfsRayon, null, Rayon, _str_idfsRayon);
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_DiagnosisForTest:
                    return new BvSelectList(DiagnosisForTestLookup, eidss.model.Schema.TestDiagnosisLookup._str_idfsDiagnosis, null, DiagnosisForTest, _str_idfsDiagnosis);
            
                case _str_SampleType:
                    return new BvSelectList(SampleTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SampleType, _str_idfsSampleType);
            
                case _str_SampleTypeFiltered:
                    return new BvSelectList(SampleTypeFilteredLookup, eidss.model.Schema.SampleTypeForDiagnosisLookup._str_idfsReference, null, SampleTypeFiltered, _str_idfsSampleTypeFiltered);
            
                case _str_DerivativeType:
                    return new BvSelectList(DerivativeTypeLookup, eidss.model.Schema.LabDerivativeTypesLookup._str_idfDerivativeForSampleType, null, DerivativeType, _str_idfDerivativeForSampleType);
            
                case _str_AccessionCondition:
                    return new BvSelectList(AccessionConditionLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AccessionCondition, _str_idfsAccessionCondition);
            
                case _str_TestNameForSearch:
                    return new BvSelectList(TestNameForSearchLookup, eidss.model.Schema.TestForDiseaseLookup._str_idfsReference, null, TestNameForSearch, _str_idfsTestName);
            
                case _str_TestNameRef:
                    return new BvSelectList(TestNameRefLookup, eidss.model.Schema.TestForDiseaseLookup._str_idfsReference, null, TestNameRef, _str_idfsTestName);
            
                case _str_TestResultRef:
                    return new BvSelectList(TestResultRefLookup, eidss.model.Schema.TestResultLookup._str_idfsReference, null, TestResultRef, _str_idfsTestResult);
            
                case _str_TestResultForAmend:
                    return new BvSelectList(TestResultForAmendLookup, eidss.model.Schema.TestResultLookup._str_idfsReference, null, TestResultForAmend, _str_idfsTestResult);
            
                case _str_TestResultDummy:
                    return new BvSelectList(TestResultDummyLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestResultDummy, _str_idfsTestResultDummy);
            
                case _str_TestCategoryRef:
                    return new BvSelectList(TestCategoryRefLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestCategoryRef, _str_idfsTestCategory);
            
                case _str_TestStatusShort:
                    return new BvSelectList(TestStatusShortLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestStatusShort, _str_idfsTestStatusDummy);
            
                case _str_TestStatusForSearch:
                    return new BvSelectList(TestStatusForSearchLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestStatusForSearch, _str_idfsTestStatusDummy);
            
                case _str_TestStatusFull:
                    return new BvSelectList(TestStatusFullLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestStatusFull, _str_idfsTestStatus);
            
                case _str_SampleStatus:
                    return new BvSelectList(SampleStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SampleStatus, _str_idfsSampleStatus);
            
                case _str_SampleStatusFull:
                    return new BvSelectList(SampleStatusFullLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SampleStatusFull, _str_idfsSampleStatus);
            
                case _str_AccessionByPerson:
                    return new BvSelectList(AccessionByPersonLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, AccessionByPerson, _str_idfAccesionByPerson);
            
                case _str_SendToOffice:
                    return new BvSelectList(SendToOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, SendToOffice, _str_idfSendToOffice);
            
                case _str_SendToOfficeOut:
                    return new BvSelectList(SendToOfficeOutLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, SendToOfficeOut, _str_idfSendToOfficeOut);
            
                case _str_PerformedByOffice:
                    return new BvSelectList(PerformedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, PerformedByOffice, _str_idfPerformedByOffice);
            
                case _str_CollectedByOffice:
                    return new BvSelectList(CollectedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, CollectedByOffice, _str_idfFieldCollectedByOffice);
            
                case _str_CollectedByPerson:
                    return new BvSelectList(CollectedByPersonLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, CollectedByPerson, _str_idfFieldCollectedByPerson);
            
                case _str_CaseType:
                    return new BvSelectList(CaseTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CaseType, _str_idfsCaseType);
            
                case _str_DestructionMethod:
                    return new BvSelectList(DestructionMethodLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, DestructionMethod, _str_idfsDestructionMethod);
            
                case _str_SampleKind:
                    return new BvSelectList(SampleKindLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SampleKind, _str_idfsSampleKind);
            
                case _str_SpeciesVectorInfo:
                    return new BvSelectList(SpeciesVectorInfoLookup, eidss.model.Schema.SpeciesVectorInfoLookup._str_idfSpeciesVectorInfo, null, SpeciesVectorInfo, _str_idfSpeciesVectorInfo);
            
                case _str_Department:
                    return new BvSelectList(DepartmentLookup, eidss.model.Schema.DepartmentLookup._str_idfDepartment, null, Department, _str_idfInDepartment);
            
                case _str_Freezer:
                    return new BvSelectList(FreezerLookup, eidss.model.Schema.FreezerTreeLookup._str_ID, null, Freezer, _str_idfSubdivision);
            
                case _str_TestedByOffice:
                    return new BvSelectList(TestedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, TestedByOffice, _str_idfTestedByOffice);
            
                case _str_TestedByPerson:
                    return new BvSelectList(TestedByPersonLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, TestedByPerson, _str_idfTestedByPerson);
            
                case _str_ResultEnteredByOffice:
                    return new BvSelectList(ResultEnteredByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, ResultEnteredByOffice, _str_idfResultEnteredByOffice);
            
                case _str_ResultEnteredByPerson:
                    return new BvSelectList(ResultEnteredByPersonLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, ResultEnteredByPerson, _str_idfResultEnteredByPerson);
            
                case _str_ValidatedByOffice:
                    return new BvSelectList(ValidatedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, ValidatedByOffice, _str_idfValidatedByOffice);
            
                case _str_ValidatedByPerson:
                    return new BvSelectList(ValidatedByPersonLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, ValidatedByPerson, _str_idfValidatedByPerson);
            
                case _str_Sample:
                    return new BvSelectList(Sample, "", "", null, "");
            
                case _str_Test:
                    return new BvSelectList(Test, "", "", null, "");
            
                case _str_AmendmentHistory:
                    return new BvSelectList(AmendmentHistory, "", "", null, "");
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsSampleStatusOriginal)]
        public long idfsSampleStatusOriginal
        {
            get { return new Func<LaboratorySectionItem, long>(c => c.idfsSampleStatusOriginalIsSaved ? c.idfsSampleStatusOriginalSaved : c.idfsSampleStatus_Original)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsTestStatusOriginal)]
        public long? idfsTestStatusOriginal
        {
            get { return new Func<LaboratorySectionItem, long?>(c => c.idfsTestStatusOriginalIsSaved ? c.idfsTestStatusOriginalSaved : c.idfsTestStatus_Original)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsTestResultOriginal)]
        public long? idfsTestResultOriginal
        {
            get { return new Func<LaboratorySectionItem, long?>(c => c.idfsTestResultOriginalIsSaved ? c.idfsTestResultOriginalSaved : c.idfsTestResult_Original)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsAccessionConditionOriginal)]
        public long? idfsAccessionConditionOriginal
        {
            get { return new Func<LaboratorySectionItem, long?>(c => c.idfsAccessionConditionOriginalIsSaved ? c.idfsAccessionConditionOriginalSaved : c.idfsAccessionCondition_Original)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfSendToOfficeOutOriginal)]
        public long? idfSendToOfficeOutOriginal
        {
            get { return new Func<LaboratorySectionItem, long?>(c => c.idfSendToOfficeOutOriginalIsSaved ? c.idfSendToOfficeOutOriginalSaved : c.idfSendToOfficeOut_Original)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strBarcodeOriginal)]
        public string strBarcodeOriginal
        {
            get { return new Func<LaboratorySectionItem, string>(c => c.strBarcodeOriginalIsSaved ? c.strBarcodeOriginalSaved : c.strBarcode_Original)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsTestNamePrevious)]
        public long? idfsTestNamePrevious
        {
            get { return new Func<LaboratorySectionItem, long?>(c => c.idfsTestNamePreviousIsSaved ? c.idfsTestNamePreviousSaved : c.idfsTestName_Previous)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsTestResultPrevious)]
        public long? idfsTestResultPrevious
        {
            get { return new Func<LaboratorySectionItem, long?>(c => c.idfsTestResultPreviousIsSaved ? c.idfsTestResultPreviousSaved : c.idfsTestResult_Previous)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_blnExternalTestPrevious)]
        public bool blnExternalTestPrevious
        {
            get { return new Func<LaboratorySectionItem, bool>(c => c.blnExternalTestPreviousIsSaved ? c.blnExternalTestPreviousSaved : c.blnExternalTest_Previous)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isChanges)]
        public bool isChanges
        {
            get { return new Func<LaboratorySectionItem, bool>(c => c.HasChanges)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strSendToOffice)]
        public string strSendToOffice
        {
            get { return new Func<LaboratorySectionItem, string>(c => c.SendToOffice == null ? "" : c.SendToOffice.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strSendToOfficeOut)]
        public string strSendToOfficeOut
        {
            get { return new Func<LaboratorySectionItem, string>(c => c.SendToOfficeOut == null ? "" : c.SendToOfficeOut.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("intTestCount")]
        public string strTestCount
        {
            get { return new Func<LaboratorySectionItem, string>(c => c.intTestCount.ToString())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strObservation)]
        public string strObservation
        {
            get { return new Func<LaboratorySectionItem, string>(c => c.FFPresenter != null && c.FFPresenter.HasAnyValue ? "*" : "")(this); }
            
            set { ; OnPropertyChanged(_str_strObservation); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isTestExists)]
        public bool isTestExists
        {
            get { return new Func<LaboratorySectionItem, bool>(c => c.idfTesting.HasValue && c.idfTesting.Value != 0)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isNotTestExistsWithAccessioned)]
        public bool isNotTestExistsWithAccessioned
        {
            get { return new Func<LaboratorySectionItem, bool>(c => (!c.idfTesting.HasValue || c.idfTesting.Value == 0) && c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned && c.idfsAccessionCondition.Value != (long)eidss.model.Enums.AccessionConditionEnum.Rejected)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isTestNotStartedBefore)]
        public bool isTestNotStartedBefore
        {
            get { return new Func<LaboratorySectionItem, bool>(c => c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.NotStarted && (c.bTestInserted || c.bTestInsertedFirst))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isTestNotStartedAfter)]
        public bool isTestNotStartedAfter
        {
            get { return new Func<LaboratorySectionItem, bool>(c => c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.NotStarted && c.idfsTestStatusOriginal == (long)eidss.model.Enums.TestStatus.NotStarted)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isTestInProcessBefore)]
        public bool isTestInProcessBefore
        {
            get { return new Func<LaboratorySectionItem, bool>(c => c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.InProcess && c.idfsTestStatusOriginal != (long)eidss.model.Enums.TestStatus.InProcess)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isTestInProcessAfter)]
        public bool isTestInProcessAfter
        {
            get { return new Func<LaboratorySectionItem, bool>(c => c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.InProcess && c.idfsTestStatusOriginal == (long)eidss.model.Enums.TestStatus.InProcess)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isTestPreliminary)]
        public bool isTestPreliminary
        {
            get { return new Func<LaboratorySectionItem, bool>(c => c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isTestFinalInternalBefore)]
        public bool isTestFinalInternalBefore
        {
            get { return new Func<LaboratorySectionItem, bool>(c => c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized && c.idfsTestStatusOriginal != (long)eidss.model.Enums.TestStatus.Finalized && !(/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isTestFinalInternalAfter)]
        public bool isTestFinalInternalAfter
        {
            get { return new Func<LaboratorySectionItem, bool>(c => c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized && c.idfsTestStatusOriginal == (long)eidss.model.Enums.TestStatus.Finalized && !(/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isTestFinalExternalBefore)]
        public bool isTestFinalExternalBefore
        {
            get { return new Func<LaboratorySectionItem, bool>(c => c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized && (c.bTestInserted || c.bTestInsertedFirst) && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isTestFinalOrAmend)]
        public bool isTestFinalOrAmend
        {
            get { return new Func<LaboratorySectionItem, bool>(c => c.idfTesting.HasValue && c.idfTesting.Value != 0 && (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized || c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Amended))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isTestFinalOrAmendSaved)]
        public bool isTestFinalOrAmendSaved
        {
            get { return new Func<LaboratorySectionItem, bool>(c => c.idfTesting.HasValue && c.idfTesting.Value != 0 && (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized || c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Amended) && (c.idfsTestStatusOriginal == (long)eidss.model.Enums.TestStatus.Finalized || c.idfsTestStatusOriginal == (long)eidss.model.Enums.TestStatus.Amended))(this); }
            
        }
        
          [LocalizedDisplayName(_str_bIsMyPref)]
        public bool bIsMyPref
        {
            get { return m_bIsMyPref; }
            set { if (m_bIsMyPref != value) { m_bIsMyPref = value; OnPropertyChanged(_str_bIsMyPref); } }
        }
        private bool m_bIsMyPref;
        
          [LocalizedDisplayName(_str_intNewMode)]
        public LabNewModeEnum intNewMode
        {
            get { return m_intNewMode; }
            set { if (m_intNewMode != value) { m_intNewMode = value; OnPropertyChanged(_str_intNewMode); } }
        }
        private LabNewModeEnum m_intNewMode;
        
          [LocalizedDisplayName(_str_bIsCreateNewSample)]
        public bool bIsCreateNewSample
        {
            get { return m_bIsCreateNewSample; }
            set { if (m_bIsCreateNewSample != value) { m_bIsCreateNewSample = value; OnPropertyChanged(_str_bIsCreateNewSample); } }
        }
        private bool m_bIsCreateNewSample;
        
          [LocalizedDisplayName(_str_idfsTestResultDummy)]
        public long? idfsTestResultDummy
        {
            get { return m_idfsTestResultDummy; }
            set { if (m_idfsTestResultDummy != value) { m_idfsTestResultDummy = value; OnPropertyChanged(_str_idfsTestResultDummy); } }
        }
        private long? m_idfsTestResultDummy;
        
          [LocalizedDisplayName(_str_idfsTestStatusDummy)]
        public long? idfsTestStatusDummy
        {
            get { return m_idfsTestStatusDummy; }
            set { if (m_idfsTestStatusDummy != value) { m_idfsTestStatusDummy = value; OnPropertyChanged(_str_idfsTestStatusDummy); } }
        }
        private long? m_idfsTestStatusDummy;
        
          [LocalizedDisplayName(_str_idfDerivativeForSampleType)]
        public long? idfDerivativeForSampleType
        {
            get { return m_idfDerivativeForSampleType; }
            set { if (m_idfDerivativeForSampleType != value) { m_idfDerivativeForSampleType = value; OnPropertyChanged(_str_idfDerivativeForSampleType); } }
        }
        private long? m_idfDerivativeForSampleType;
        
          [LocalizedDisplayName(_str_idfsOldTestResult)]
        public long? idfsOldTestResult
        {
            get { return m_idfsOldTestResult; }
            set { if (m_idfsOldTestResult != value) { m_idfsOldTestResult = value; OnPropertyChanged(_str_idfsOldTestResult); } }
        }
        private long? m_idfsOldTestResult;
        
          [LocalizedDisplayName(_str_idfsSampleStatusOriginalIsSaved)]
        public bool idfsSampleStatusOriginalIsSaved
        {
            get { return m_idfsSampleStatusOriginalIsSaved; }
            set { if (m_idfsSampleStatusOriginalIsSaved != value) { m_idfsSampleStatusOriginalIsSaved = value; OnPropertyChanged(_str_idfsSampleStatusOriginalIsSaved); } }
        }
        private bool m_idfsSampleStatusOriginalIsSaved;
        
          [LocalizedDisplayName(_str_idfsSampleStatusOriginalSaved)]
        public long idfsSampleStatusOriginalSaved
        {
            get { return m_idfsSampleStatusOriginalSaved; }
            set { if (m_idfsSampleStatusOriginalSaved != value) { m_idfsSampleStatusOriginalSaved = value; OnPropertyChanged(_str_idfsSampleStatusOriginalSaved); } }
        }
        private long m_idfsSampleStatusOriginalSaved;
        
          [LocalizedDisplayName(_str_idfsTestStatusOriginalIsSaved)]
        public bool idfsTestStatusOriginalIsSaved
        {
            get { return m_idfsTestStatusOriginalIsSaved; }
            set { if (m_idfsTestStatusOriginalIsSaved != value) { m_idfsTestStatusOriginalIsSaved = value; OnPropertyChanged(_str_idfsTestStatusOriginalIsSaved); } }
        }
        private bool m_idfsTestStatusOriginalIsSaved;
        
          [LocalizedDisplayName(_str_idfsTestStatusOriginalSaved)]
        public long? idfsTestStatusOriginalSaved
        {
            get { return m_idfsTestStatusOriginalSaved; }
            set { if (m_idfsTestStatusOriginalSaved != value) { m_idfsTestStatusOriginalSaved = value; OnPropertyChanged(_str_idfsTestStatusOriginalSaved); } }
        }
        private long? m_idfsTestStatusOriginalSaved;
        
          [LocalizedDisplayName(_str_idfsTestResultOriginalIsSaved)]
        public bool idfsTestResultOriginalIsSaved
        {
            get { return m_idfsTestResultOriginalIsSaved; }
            set { if (m_idfsTestResultOriginalIsSaved != value) { m_idfsTestResultOriginalIsSaved = value; OnPropertyChanged(_str_idfsTestResultOriginalIsSaved); } }
        }
        private bool m_idfsTestResultOriginalIsSaved;
        
          [LocalizedDisplayName(_str_idfsTestResultOriginalSaved)]
        public long? idfsTestResultOriginalSaved
        {
            get { return m_idfsTestResultOriginalSaved; }
            set { if (m_idfsTestResultOriginalSaved != value) { m_idfsTestResultOriginalSaved = value; OnPropertyChanged(_str_idfsTestResultOriginalSaved); } }
        }
        private long? m_idfsTestResultOriginalSaved;
        
          [LocalizedDisplayName(_str_idfsAccessionConditionOriginalIsSaved)]
        public bool idfsAccessionConditionOriginalIsSaved
        {
            get { return m_idfsAccessionConditionOriginalIsSaved; }
            set { if (m_idfsAccessionConditionOriginalIsSaved != value) { m_idfsAccessionConditionOriginalIsSaved = value; OnPropertyChanged(_str_idfsAccessionConditionOriginalIsSaved); } }
        }
        private bool m_idfsAccessionConditionOriginalIsSaved;
        
          [LocalizedDisplayName(_str_idfsAccessionConditionOriginalSaved)]
        public long? idfsAccessionConditionOriginalSaved
        {
            get { return m_idfsAccessionConditionOriginalSaved; }
            set { if (m_idfsAccessionConditionOriginalSaved != value) { m_idfsAccessionConditionOriginalSaved = value; OnPropertyChanged(_str_idfsAccessionConditionOriginalSaved); } }
        }
        private long? m_idfsAccessionConditionOriginalSaved;
        
          [LocalizedDisplayName(_str_idfSendToOfficeOutOriginalIsSaved)]
        public bool idfSendToOfficeOutOriginalIsSaved
        {
            get { return m_idfSendToOfficeOutOriginalIsSaved; }
            set { if (m_idfSendToOfficeOutOriginalIsSaved != value) { m_idfSendToOfficeOutOriginalIsSaved = value; OnPropertyChanged(_str_idfSendToOfficeOutOriginalIsSaved); } }
        }
        private bool m_idfSendToOfficeOutOriginalIsSaved;
        
          [LocalizedDisplayName(_str_idfSendToOfficeOutOriginalSaved)]
        public long? idfSendToOfficeOutOriginalSaved
        {
            get { return m_idfSendToOfficeOutOriginalSaved; }
            set { if (m_idfSendToOfficeOutOriginalSaved != value) { m_idfSendToOfficeOutOriginalSaved = value; OnPropertyChanged(_str_idfSendToOfficeOutOriginalSaved); } }
        }
        private long? m_idfSendToOfficeOutOriginalSaved;
        
          [LocalizedDisplayName(_str_strBarcodeOriginalIsSaved)]
        public bool strBarcodeOriginalIsSaved
        {
            get { return m_strBarcodeOriginalIsSaved; }
            set { if (m_strBarcodeOriginalIsSaved != value) { m_strBarcodeOriginalIsSaved = value; OnPropertyChanged(_str_strBarcodeOriginalIsSaved); } }
        }
        private bool m_strBarcodeOriginalIsSaved;
        
          [LocalizedDisplayName(_str_strBarcodeOriginalSaved)]
        public string strBarcodeOriginalSaved
        {
            get { return m_strBarcodeOriginalSaved; }
            set { if (m_strBarcodeOriginalSaved != value) { m_strBarcodeOriginalSaved = value; OnPropertyChanged(_str_strBarcodeOriginalSaved); } }
        }
        private string m_strBarcodeOriginalSaved;
        
          [LocalizedDisplayName(_str_idfsTestNamePreviousIsSaved)]
        public bool idfsTestNamePreviousIsSaved
        {
            get { return m_idfsTestNamePreviousIsSaved; }
            set { if (m_idfsTestNamePreviousIsSaved != value) { m_idfsTestNamePreviousIsSaved = value; OnPropertyChanged(_str_idfsTestNamePreviousIsSaved); } }
        }
        private bool m_idfsTestNamePreviousIsSaved;
        
          [LocalizedDisplayName(_str_idfsTestNamePreviousSaved)]
        public long? idfsTestNamePreviousSaved
        {
            get { return m_idfsTestNamePreviousSaved; }
            set { if (m_idfsTestNamePreviousSaved != value) { m_idfsTestNamePreviousSaved = value; OnPropertyChanged(_str_idfsTestNamePreviousSaved); } }
        }
        private long? m_idfsTestNamePreviousSaved;
        
          [LocalizedDisplayName(_str_idfsTestResultPreviousIsSaved)]
        public bool idfsTestResultPreviousIsSaved
        {
            get { return m_idfsTestResultPreviousIsSaved; }
            set { if (m_idfsTestResultPreviousIsSaved != value) { m_idfsTestResultPreviousIsSaved = value; OnPropertyChanged(_str_idfsTestResultPreviousIsSaved); } }
        }
        private bool m_idfsTestResultPreviousIsSaved;
        
          [LocalizedDisplayName(_str_idfsTestResultPreviousSaved)]
        public long? idfsTestResultPreviousSaved
        {
            get { return m_idfsTestResultPreviousSaved; }
            set { if (m_idfsTestResultPreviousSaved != value) { m_idfsTestResultPreviousSaved = value; OnPropertyChanged(_str_idfsTestResultPreviousSaved); } }
        }
        private long? m_idfsTestResultPreviousSaved;
        
          [LocalizedDisplayName(_str_blnExternalTestPreviousIsSaved)]
        public bool blnExternalTestPreviousIsSaved
        {
            get { return m_blnExternalTestPreviousIsSaved; }
            set { if (m_blnExternalTestPreviousIsSaved != value) { m_blnExternalTestPreviousIsSaved = value; OnPropertyChanged(_str_blnExternalTestPreviousIsSaved); } }
        }
        private bool m_blnExternalTestPreviousIsSaved;
        
          [LocalizedDisplayName(_str_blnExternalTestPreviousSaved)]
        public bool blnExternalTestPreviousSaved
        {
            get { return m_blnExternalTestPreviousSaved; }
            set { if (m_blnExternalTestPreviousSaved != value) { m_blnExternalTestPreviousSaved = value; OnPropertyChanged(_str_blnExternalTestPreviousSaved); } }
        }
        private bool m_blnExternalTestPreviousSaved;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LaboratorySectionItem";

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
        AmendmentHistory.ForEach(c => { c.Parent = this; });
                
            if (_FFPresenter != null) { _FFPresenter.Parent = this; }
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as LaboratorySectionItem;
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
            var ret = base.Clone() as LaboratorySectionItem;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
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
        public LaboratorySectionItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LaboratorySectionItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return ID; } }
        public string KeyName { get { return "ID"; } }
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
        
                    || AmendmentHistory.IsDirty
                    || AmendmentHistory.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || (_FFPresenter != null && _FFPresenter.HasChanges)
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsRegion_Region = idfsRegion;
            var _prev_idfsRayon_Rayon = idfsRayon;
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfsDiagnosis_DiagnosisForTest = idfsDiagnosis;
            var _prev_idfsSampleType_SampleType = idfsSampleType;
            var _prev_idfsSampleTypeFiltered_SampleTypeFiltered = idfsSampleTypeFiltered;
            var _prev_idfDerivativeForSampleType_DerivativeType = idfDerivativeForSampleType;
            var _prev_idfsAccessionCondition_AccessionCondition = idfsAccessionCondition;
            var _prev_idfsTestName_TestNameForSearch = idfsTestName;
            var _prev_idfsTestName_TestNameRef = idfsTestName;
            var _prev_idfsTestResult_TestResultRef = idfsTestResult;
            var _prev_idfsTestResult_TestResultForAmend = idfsTestResult;
            var _prev_idfsTestResultDummy_TestResultDummy = idfsTestResultDummy;
            var _prev_idfsTestCategory_TestCategoryRef = idfsTestCategory;
            var _prev_idfsTestStatusDummy_TestStatusShort = idfsTestStatusDummy;
            var _prev_idfsTestStatusDummy_TestStatusForSearch = idfsTestStatusDummy;
            var _prev_idfsTestStatus_TestStatusFull = idfsTestStatus;
            var _prev_idfsSampleStatus_SampleStatus = idfsSampleStatus;
            var _prev_idfsSampleStatus_SampleStatusFull = idfsSampleStatus;
            var _prev_idfAccesionByPerson_AccessionByPerson = idfAccesionByPerson;
            var _prev_idfSendToOffice_SendToOffice = idfSendToOffice;
            var _prev_idfSendToOfficeOut_SendToOfficeOut = idfSendToOfficeOut;
            var _prev_idfPerformedByOffice_PerformedByOffice = idfPerformedByOffice;
            var _prev_idfFieldCollectedByOffice_CollectedByOffice = idfFieldCollectedByOffice;
            var _prev_idfFieldCollectedByPerson_CollectedByPerson = idfFieldCollectedByPerson;
            var _prev_idfsCaseType_CaseType = idfsCaseType;
            var _prev_idfsDestructionMethod_DestructionMethod = idfsDestructionMethod;
            var _prev_idfsSampleKind_SampleKind = idfsSampleKind;
            var _prev_idfSpeciesVectorInfo_SpeciesVectorInfo = idfSpeciesVectorInfo;
            var _prev_idfInDepartment_Department = idfInDepartment;
            var _prev_idfSubdivision_Freezer = idfSubdivision;
            var _prev_idfTestedByOffice_TestedByOffice = idfTestedByOffice;
            var _prev_idfTestedByPerson_TestedByPerson = idfTestedByPerson;
            var _prev_idfResultEnteredByOffice_ResultEnteredByOffice = idfResultEnteredByOffice;
            var _prev_idfResultEnteredByPerson_ResultEnteredByPerson = idfResultEnteredByPerson;
            var _prev_idfValidatedByOffice_ValidatedByOffice = idfValidatedByOffice;
            var _prev_idfValidatedByPerson_ValidatedByPerson = idfValidatedByPerson;
            base.RejectChanges();
        
            if (_prev_idfsRegion_Region != idfsRegion)
            {
                _Region = _RegionLookup.FirstOrDefault(c => c.idfsRegion == idfsRegion);
            }
            if (_prev_idfsRayon_Rayon != idfsRayon)
            {
                _Rayon = _RayonLookup.FirstOrDefault(c => c.idfsRayon == idfsRayon);
            }
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsDiagnosis_DiagnosisForTest != idfsDiagnosis)
            {
                _DiagnosisForTest = _DiagnosisForTestLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsSampleType_SampleType != idfsSampleType)
            {
                _SampleType = _SampleTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSampleType);
            }
            if (_prev_idfsSampleTypeFiltered_SampleTypeFiltered != idfsSampleTypeFiltered)
            {
                _SampleTypeFiltered = _SampleTypeFilteredLookup.FirstOrDefault(c => c.idfsReference == idfsSampleTypeFiltered);
            }
            if (_prev_idfDerivativeForSampleType_DerivativeType != idfDerivativeForSampleType)
            {
                _DerivativeType = _DerivativeTypeLookup.FirstOrDefault(c => c.idfDerivativeForSampleType == idfDerivativeForSampleType);
            }
            if (_prev_idfsAccessionCondition_AccessionCondition != idfsAccessionCondition)
            {
                _AccessionCondition = _AccessionConditionLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAccessionCondition);
            }
            if (_prev_idfsTestName_TestNameForSearch != idfsTestName)
            {
                _TestNameForSearch = _TestNameForSearchLookup.FirstOrDefault(c => c.idfsReference == idfsTestName);
            }
            if (_prev_idfsTestName_TestNameRef != idfsTestName)
            {
                _TestNameRef = _TestNameRefLookup.FirstOrDefault(c => c.idfsReference == idfsTestName);
            }
            if (_prev_idfsTestResult_TestResultRef != idfsTestResult)
            {
                _TestResultRef = _TestResultRefLookup.FirstOrDefault(c => c.idfsReference == idfsTestResult);
            }
            if (_prev_idfsTestResult_TestResultForAmend != idfsTestResult)
            {
                _TestResultForAmend = _TestResultForAmendLookup.FirstOrDefault(c => c.idfsReference == idfsTestResult);
            }
            if (_prev_idfsTestResultDummy_TestResultDummy != idfsTestResultDummy)
            {
                _TestResultDummy = _TestResultDummyLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestResultDummy);
            }
            if (_prev_idfsTestCategory_TestCategoryRef != idfsTestCategory)
            {
                _TestCategoryRef = _TestCategoryRefLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestCategory);
            }
            if (_prev_idfsTestStatusDummy_TestStatusShort != idfsTestStatusDummy)
            {
                _TestStatusShort = _TestStatusShortLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestStatusDummy);
            }
            if (_prev_idfsTestStatusDummy_TestStatusForSearch != idfsTestStatusDummy)
            {
                _TestStatusForSearch = _TestStatusForSearchLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestStatusDummy);
            }
            if (_prev_idfsTestStatus_TestStatusFull != idfsTestStatus)
            {
                _TestStatusFull = _TestStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestStatus);
            }
            if (_prev_idfsSampleStatus_SampleStatus != idfsSampleStatus)
            {
                _SampleStatus = _SampleStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSampleStatus);
            }
            if (_prev_idfsSampleStatus_SampleStatusFull != idfsSampleStatus)
            {
                _SampleStatusFull = _SampleStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSampleStatus);
            }
            if (_prev_idfAccesionByPerson_AccessionByPerson != idfAccesionByPerson)
            {
                _AccessionByPerson = _AccessionByPersonLookup.FirstOrDefault(c => c.idfPerson == idfAccesionByPerson);
            }
            if (_prev_idfSendToOffice_SendToOffice != idfSendToOffice)
            {
                _SendToOffice = _SendToOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfSendToOffice);
            }
            if (_prev_idfSendToOfficeOut_SendToOfficeOut != idfSendToOfficeOut)
            {
                _SendToOfficeOut = _SendToOfficeOutLookup.FirstOrDefault(c => c.idfInstitution == idfSendToOfficeOut);
            }
            if (_prev_idfPerformedByOffice_PerformedByOffice != idfPerformedByOffice)
            {
                _PerformedByOffice = _PerformedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfPerformedByOffice);
            }
            if (_prev_idfFieldCollectedByOffice_CollectedByOffice != idfFieldCollectedByOffice)
            {
                _CollectedByOffice = _CollectedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfFieldCollectedByOffice);
            }
            if (_prev_idfFieldCollectedByPerson_CollectedByPerson != idfFieldCollectedByPerson)
            {
                _CollectedByPerson = _CollectedByPersonLookup.FirstOrDefault(c => c.idfPerson == idfFieldCollectedByPerson);
            }
            if (_prev_idfsCaseType_CaseType != idfsCaseType)
            {
                _CaseType = _CaseTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCaseType);
            }
            if (_prev_idfsDestructionMethod_DestructionMethod != idfsDestructionMethod)
            {
                _DestructionMethod = _DestructionMethodLookup.FirstOrDefault(c => c.idfsBaseReference == idfsDestructionMethod);
            }
            if (_prev_idfsSampleKind_SampleKind != idfsSampleKind)
            {
                _SampleKind = _SampleKindLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSampleKind);
            }
            if (_prev_idfSpeciesVectorInfo_SpeciesVectorInfo != idfSpeciesVectorInfo)
            {
                _SpeciesVectorInfo = _SpeciesVectorInfoLookup.FirstOrDefault(c => c.idfSpeciesVectorInfo == idfSpeciesVectorInfo);
            }
            if (_prev_idfInDepartment_Department != idfInDepartment)
            {
                _Department = _DepartmentLookup.FirstOrDefault(c => c.idfDepartment == idfInDepartment);
            }
            if (_prev_idfSubdivision_Freezer != idfSubdivision)
            {
                _Freezer = _FreezerLookup.FirstOrDefault(c => c.ID == idfSubdivision);
            }
            if (_prev_idfTestedByOffice_TestedByOffice != idfTestedByOffice)
            {
                _TestedByOffice = _TestedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfTestedByOffice);
            }
            if (_prev_idfTestedByPerson_TestedByPerson != idfTestedByPerson)
            {
                _TestedByPerson = _TestedByPersonLookup.FirstOrDefault(c => c.idfPerson == idfTestedByPerson);
            }
            if (_prev_idfResultEnteredByOffice_ResultEnteredByOffice != idfResultEnteredByOffice)
            {
                _ResultEnteredByOffice = _ResultEnteredByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfResultEnteredByOffice);
            }
            if (_prev_idfResultEnteredByPerson_ResultEnteredByPerson != idfResultEnteredByPerson)
            {
                _ResultEnteredByPerson = _ResultEnteredByPersonLookup.FirstOrDefault(c => c.idfPerson == idfResultEnteredByPerson);
            }
            if (_prev_idfValidatedByOffice_ValidatedByOffice != idfValidatedByOffice)
            {
                _ValidatedByOffice = _ValidatedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfValidatedByOffice);
            }
            if (_prev_idfValidatedByPerson_ValidatedByPerson != idfValidatedByPerson)
            {
                _ValidatedByPerson = _ValidatedByPersonLookup.FirstOrDefault(c => c.idfPerson == idfValidatedByPerson);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        AmendmentHistory.DeepRejectChanges();
                
            if (FFPresenter != null) FFPresenter.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
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
        AmendmentHistory.ForEach(c => c.SetChange());
                
            if (_FFPresenter != null) _FFPresenter.SetChange();
                
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        
        public string ObjectIdent2 { get { return ObjectName + "_" + idfMaterial.ToString() + "_"; } }
          
        public string ObjectIdent3 { get { return ObjectName + "_" + idfTesting.ToString() + "_"; } }
          
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

        private bool IsRIRPropChanged(string fld, LaboratorySectionItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public LaboratorySectionItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LaboratorySectionItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LaboratorySectionItem_PropertyChanged);
        }
        private void LaboratorySectionItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LaboratorySectionItem).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfSendToOffice)
                OnPropertyChanged(_str_strSendToOffice);
                  
            if (e.PropertyName == _str_idfSendToOfficeOut)
                OnPropertyChanged(_str_strSendToOfficeOut);
                  
            if (e.PropertyName == _str_intTestCount)
                OnPropertyChanged(_str_strTestCount);
                  
            if (e.PropertyName == _str_FFPresenter)
                OnPropertyChanged(_str_strObservation);
                  
            if (e.PropertyName == _str_idfTesting)
                OnPropertyChanged(_str_isTestExists);
                  
            if (e.PropertyName == _str_idfTesting)
                OnPropertyChanged(_str_isNotTestExistsWithAccessioned);
                  
            if (e.PropertyName == _str_idfTesting)
                OnPropertyChanged(_str_isTestNotStartedBefore);
                  
            if (e.PropertyName == _str_idfsTestStatus)
                OnPropertyChanged(_str_isTestNotStartedBefore);
                  
            if (e.PropertyName == _str_bTestInserted)
                OnPropertyChanged(_str_isTestNotStartedBefore);
                  
            if (e.PropertyName == _str_bTestInsertedFirst)
                OnPropertyChanged(_str_isTestNotStartedBefore);
                  
            if (e.PropertyName == _str_idfTesting)
                OnPropertyChanged(_str_isTestNotStartedAfter);
                  
            if (e.PropertyName == _str_idfsTestStatus)
                OnPropertyChanged(_str_isTestNotStartedAfter);
                  
            if (e.PropertyName == _str_idfTesting)
                OnPropertyChanged(_str_isTestInProcessBefore);
                  
            if (e.PropertyName == _str_idfsTestStatus)
                OnPropertyChanged(_str_isTestInProcessBefore);
                  
            if (e.PropertyName == _str_idfTesting)
                OnPropertyChanged(_str_isTestInProcessAfter);
                  
            if (e.PropertyName == _str_idfsTestStatus)
                OnPropertyChanged(_str_isTestInProcessAfter);
                  
            if (e.PropertyName == _str_idfTesting)
                OnPropertyChanged(_str_isTestPreliminary);
                  
            if (e.PropertyName == _str_idfsTestStatus)
                OnPropertyChanged(_str_isTestPreliminary);
                  
            if (e.PropertyName == _str_idfTesting)
                OnPropertyChanged(_str_isTestFinalInternalBefore);
                  
            if (e.PropertyName == _str_idfsTestStatus)
                OnPropertyChanged(_str_isTestFinalInternalBefore);
                  
            if (e.PropertyName == _str_blnExternalTest)
                OnPropertyChanged(_str_isTestFinalInternalBefore);
                  
            if (e.PropertyName == _str_idfTesting)
                OnPropertyChanged(_str_isTestFinalInternalAfter);
                  
            if (e.PropertyName == _str_idfsTestStatus)
                OnPropertyChanged(_str_isTestFinalInternalAfter);
                  
            if (e.PropertyName == _str_blnExternalTest)
                OnPropertyChanged(_str_isTestFinalInternalAfter);
                  
            if (e.PropertyName == _str_idfTesting)
                OnPropertyChanged(_str_isTestFinalExternalBefore);
                  
            if (e.PropertyName == _str_idfsTestStatus)
                OnPropertyChanged(_str_isTestFinalExternalBefore);
                  
            if (e.PropertyName == _str_blnExternalTest)
                OnPropertyChanged(_str_isTestFinalExternalBefore);
                  
            if (e.PropertyName == _str_bTestInserted)
                OnPropertyChanged(_str_isTestFinalExternalBefore);
                  
            if (e.PropertyName == _str_bTestInsertedFirst)
                OnPropertyChanged(_str_isTestFinalExternalBefore);
                  
            if (e.PropertyName == _str_idfTesting)
                OnPropertyChanged(_str_isTestFinalOrAmend);
                  
            if (e.PropertyName == _str_idfsTestStatus)
                OnPropertyChanged(_str_isTestFinalOrAmend);
                  
            if (e.PropertyName == _str_idfTesting)
                OnPropertyChanged(_str_isTestFinalOrAmendSaved);
                  
            if (e.PropertyName == _str_idfsTestStatus)
                OnPropertyChanged(_str_isTestFinalOrAmendSaved);
                  
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
            LaboratorySectionItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LaboratorySectionItem obj = this;
            
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
    
        private static string[] invisible_names1 = "strTestStatus".Split(new char[] { ',' });
        
        private static string[] invisible_names2 = "TestStatusShort".Split(new char[] { ',' });
        
        private bool _isInvisible(string name)
        {
            
            if (invisible_names1.Where(c => c == name).Count() > 0)
                return new Func<LaboratorySectionItem, bool>(c => c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.InProcess || c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary || c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.NotStarted)(this);
            
            if (invisible_names2.Where(c => c == name).Count() > 0)
                return new Func<LaboratorySectionItem, bool>(c => !(c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.InProcess || c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary || c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.NotStarted))(this);
            
            return false;
                
        }

    
        private static string[] readonly_names1 = "strCalculatedCaseID".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strFieldBarcode".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "idfsSampleStatus,SampleStatusFull".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "strBarcode".Split(new char[] { ',' });
        
        private static string[] readonly_names5 = "idfsSampleType,SampleType".Split(new char[] { ',' });
        
        private static string[] readonly_names6 = "datFieldCollectionDate".Split(new char[] { ',' });
        
        private static string[] readonly_names7 = "datAccession".Split(new char[] { ',' });
        
        private static string[] readonly_names8 = "idfsAccessionCondition,AccessionCondition".Split(new char[] { ',' });
        
        private static string[] readonly_names9 = "strCondition".Split(new char[] { ',' });
        
        private static string[] readonly_names10 = "idfSubdivision,Freezer".Split(new char[] { ',' });
        
        private static string[] readonly_names11 = "idfInDepartment,Department".Split(new char[] { ',' });
        
        private static string[] readonly_names12 = "strParentMaterial,strParentMaterial".Split(new char[] { ',' });
        
        private static string[] readonly_names13 = "idfsCaseType,CaseType".Split(new char[] { ',' });
        
        private static string[] readonly_names14 = "idfSpeciesVectorInfo,SpeciesVectorInfo".Split(new char[] { ',' });
        
        private static string[] readonly_names15 = "intTestCount,strTestCount".Split(new char[] { ',' });
        
        private static string[] readonly_names16 = "idfFieldCollectedByOffice,CollectedByOffice".Split(new char[] { ',' });
        
        private static string[] readonly_names17 = "idfFieldCollectedByPerson,CollectedByPerson".Split(new char[] { ',' });
        
        private static string[] readonly_names18 = "idfSendToOffice,SendToOffice,strSendToOffice".Split(new char[] { ',' });
        
        private static string[] readonly_names19 = "idfSendToOfficeOut,SendToOfficeOut,strSendToOfficeOut".Split(new char[] { ',' });
        
        private static string[] readonly_names20 = "strSampleNote".Split(new char[] { ',' });
        
        private static string[] readonly_names21 = "idfsDestructionMethod,DestructionMethod".Split(new char[] { ',' });
        
        private static string[] readonly_names22 = "idfsDiagnosis,DiagnosisForTest".Split(new char[] { ',' });
        
        private static string[] readonly_names23 = "idfsTestName,TestNameRef,TestNameForSearch".Split(new char[] { ',' });
        
        private static string[] readonly_names24 = "strTestStatus".Split(new char[] { ',' });
        
        private static string[] readonly_names25 = "idfsTestStatus,TestStatusShort".Split(new char[] { ',' });
        
        private static string[] readonly_names26 = "idfsTestResult,TestResultRef".Split(new char[] { ',' });
        
        private static string[] readonly_names27 = "datStartedDate".Split(new char[] { ',' });
        
        private static string[] readonly_names28 = "datConcludedDate".Split(new char[] { ',' });
        
        private static string[] readonly_names29 = "idfsTestCategory,TestCategoryRef".Split(new char[] { ',' });
        
        private static string[] readonly_names30 = "strObservation".Split(new char[] { ',' });
        
        private static string[] readonly_names31 = "idfTestedByPerson,TestedByPerson".Split(new char[] { ',' });
        
        private static string[] readonly_names32 = "idfResultEnteredByPerson,ResultEnteredByPerson".Split(new char[] { ',' });
        
        private static string[] readonly_names33 = "idfValidatedByPerson,ValidatedByPerson".Split(new char[] { ',' });
        
        private static string[] readonly_names34 = "blnExternalTest".Split(new char[] { ',' });
        
        private static string[] readonly_names35 = "idfPerformedByOffice,PerformedByOffice".Split(new char[] { ',' });
        
        private static string[] readonly_names36 = "datReceivedDate".Split(new char[] { ',' });
        
        private static string[] readonly_names37 = "strContactPerson".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && c.intNewMode != LabNewModeEnum.CreateSample)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && c.intNewMode != LabNewModeEnum.GroupAccessionIn)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None)(this);
            
            if (readonly_names4.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned && c.idfsSampleStatusOriginal <= 0))(this);
            
            if (readonly_names5.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned && c.idfsSampleStatusOriginal <= 0 && c.bIsCreateNewSample))(this);
            
            if (readonly_names6.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned && c.idfsSampleStatusOriginal <= 0 && c.bIsCreateNewSample))(this);
            
            if (readonly_names7.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned && c.idfsSampleStatusOriginal <= 0))(this);
            
            if (readonly_names8.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !((c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned && c.idfsSampleStatusOriginal <= 0) || c.idfsSampleStatus <= 0))(this);
            
            if (readonly_names9.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned && c.idfsSampleStatusOriginal <= 0))(this);
            
            if (readonly_names10.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned || c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.OutOfRepository))(this);
            
            if (readonly_names11.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned || c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.OutOfRepository))(this);
            
            if (readonly_names12.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None)(this);
            
            if (readonly_names13.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None)(this);
            
            if (readonly_names14.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.intCaseHACode != (long)eidss.model.Enums.HACode.Human && c.bIsCreateNewSample))(this);
            
            if (readonly_names15.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None)(this);
            
            if (readonly_names16.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.bIsCreateNewSample))(this);
            
            if (readonly_names17.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.bIsCreateNewSample))(this);
            
            if (readonly_names18.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None)(this);
            
            if (readonly_names19.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(!c.IsNew && (c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned && c.idfsSampleStatusOriginal == (long)eidss.model.Enums.SampleStatus.Accessioned) || (c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.OutOfRepository && c.idfsSampleStatusOriginal == (long)eidss.model.Enums.SampleStatus.Accessioned)))(this);
            
            if (readonly_names20.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && c.idfsSampleStatus <= 0)(this);
            
            if (readonly_names21.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !((c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.RoutineDestruction) || (c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Destroyed && c.idfsSampleStatusOriginal != (long)eidss.model.Enums.SampleStatus.Destroyed)))(this);
            
            if (readonly_names22.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.isTestNotStartedBefore || c.isTestFinalExternalBefore))(this);
            
            if (readonly_names23.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.isNotTestExistsWithAccessioned || c.isTestNotStartedBefore || c.isTestFinalExternalBefore))(this);
            
            if (readonly_names24.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None)(this);
            
            if (readonly_names25.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned && (c.isTestNotStartedBefore || c.isTestNotStartedAfter || c.isTestInProcessBefore || c.isTestInProcessAfter || c.isTestPreliminary)))(this);
            
            if (readonly_names26.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !((c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned || c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.OutOfRepository) && (c.isTestInProcessBefore || c.isTestInProcessAfter || c.isTestPreliminary || c.isTestFinalInternalBefore || c.isTestFinalExternalBefore)))(this);
            
            if (readonly_names27.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.isTestInProcessBefore || c.isTestInProcessAfter || c.isTestPreliminary || c.isTestFinalExternalBefore))(this);
            
            if (readonly_names28.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.isTestPreliminary || c.isTestFinalInternalBefore || c.isTestFinalExternalBefore))(this);
            
            if (readonly_names29.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.isTestNotStartedBefore))(this);
            
            if (readonly_names30.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.isTestExists || c.isTestFinalExternalBefore))(this);
            
            if (readonly_names31.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.isTestInProcessBefore || c.isTestInProcessAfter || c.isTestPreliminary || c.isTestFinalInternalBefore || c.isTestFinalExternalBefore))(this);
            
            if (readonly_names32.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.isTestPreliminary || c.isTestFinalInternalBefore || c.isTestFinalInternalAfter))(this);
            
            if (readonly_names33.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None)(this);
            
            if (readonly_names34.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.OutOfRepository && !c.isTestExists && c.bExternalOffice.HasValue && c.bExternalOffice.Value))(this);
            
            if (readonly_names35.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.isTestFinalExternalBefore))(this);
            
            if (readonly_names36.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.isTestFinalExternalBefore))(this);
            
            if (readonly_names37.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<LaboratorySectionItem, bool>(c => c.Parent != null && c.intNewMode == LabNewModeEnum.None && !(c.isTestFinalExternalBefore))(this);
            
            return ReadOnly || new Func<LaboratorySectionItem, bool>(c => false)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _AmendmentHistory)
                    o.ReadOnly |= value;
                
                if (_FFPresenter != null)
                    _FFPresenter.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<LaboratorySectionItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<LaboratorySectionItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LaboratorySectionItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LaboratorySectionItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<LaboratorySectionItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<LaboratorySectionItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<LaboratorySectionItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LaboratorySectionItem()
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
                Sample.ForEach(c => c.Dispose());
                Test.ForEach(c => c.Dispose());
                AmendmentHistory.ForEach(c => c.Dispose());
                
                LookupManager.RemoveObject("RegionLookup", this);
                
                LookupManager.RemoveObject("RayonLookup", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("TestDiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftSampleType", this);
                
                LookupManager.RemoveObject("SampleTypeForDiagnosisLookup", this);
                
                LookupManager.RemoveObject("LabDerivativeTypesLookup", this);
                
                LookupManager.RemoveObject("rftAccessionCondition", this);
                
                LookupManager.RemoveObject("TestForDiseaseLookup", this);
                
                LookupManager.RemoveObject("TestForDiseaseLookup", this);
                
                LookupManager.RemoveObject("TestResultLookup", this);
                
                LookupManager.RemoveObject("TestResultLookup", this);
                
                LookupManager.RemoveObject("rftTestResult", this);
                
                LookupManager.RemoveObject("rftTestCategory", this);
                
                LookupManager.RemoveObject("rftTestStatus", this);
                
                LookupManager.RemoveObject("rftTestStatus", this);
                
                LookupManager.RemoveObject("rftTestStatus", this);
                
                LookupManager.RemoveObject("rftSampleStatus", this);
                
                LookupManager.RemoveObject("rftSampleStatus", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                LookupManager.RemoveObject("rftCaseType", this);
                
                LookupManager.RemoveObject("rftDestructionMethod", this);
                
                LookupManager.RemoveObject("rftSampleKind", this);
                
                LookupManager.RemoveObject("SpeciesVectorInfoLookup", this);
                
                LookupManager.RemoveObject("DepartmentLookup", this);
                
                LookupManager.RemoveObject("FreezerTreeLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "RegionLookup")
                _getAccessor().LoadLookup_Region(manager, this);
            
            if (lookup_object == "RayonLookup")
                _getAccessor().LoadLookup_Rayon(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "TestDiagnosisLookup")
                _getAccessor().LoadLookup_DiagnosisForTest(manager, this);
            
            if (lookup_object == "rftSampleType")
                _getAccessor().LoadLookup_SampleType(manager, this);
            
            if (lookup_object == "SampleTypeForDiagnosisLookup")
                _getAccessor().LoadLookup_SampleTypeFiltered(manager, this);
            
            if (lookup_object == "LabDerivativeTypesLookup")
                _getAccessor().LoadLookup_DerivativeType(manager, this);
            
            if (lookup_object == "rftAccessionCondition")
                _getAccessor().LoadLookup_AccessionCondition(manager, this);
            
            if (lookup_object == "TestForDiseaseLookup")
                _getAccessor().LoadLookup_TestNameForSearch(manager, this);
            
            if (lookup_object == "TestForDiseaseLookup")
                _getAccessor().LoadLookup_TestNameRef(manager, this);
            
            if (lookup_object == "TestResultLookup")
                _getAccessor().LoadLookup_TestResultRef(manager, this);
            
            if (lookup_object == "TestResultLookup")
                _getAccessor().LoadLookup_TestResultForAmend(manager, this);
            
            if (lookup_object == "rftTestResult")
                _getAccessor().LoadLookup_TestResultDummy(manager, this);
            
            if (lookup_object == "rftTestCategory")
                _getAccessor().LoadLookup_TestCategoryRef(manager, this);
            
            if (lookup_object == "rftTestStatus")
                _getAccessor().LoadLookup_TestStatusShort(manager, this);
            
            if (lookup_object == "rftTestStatus")
                _getAccessor().LoadLookup_TestStatusForSearch(manager, this);
            
            if (lookup_object == "rftTestStatus")
                _getAccessor().LoadLookup_TestStatusFull(manager, this);
            
            if (lookup_object == "rftSampleStatus")
                _getAccessor().LoadLookup_SampleStatus(manager, this);
            
            if (lookup_object == "rftSampleStatus")
                _getAccessor().LoadLookup_SampleStatusFull(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_AccessionByPerson(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_SendToOffice(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_SendToOfficeOut(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_PerformedByOffice(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_CollectedByOffice(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_CollectedByPerson(manager, this);
            
            if (lookup_object == "rftCaseType")
                _getAccessor().LoadLookup_CaseType(manager, this);
            
            if (lookup_object == "rftDestructionMethod")
                _getAccessor().LoadLookup_DestructionMethod(manager, this);
            
            if (lookup_object == "rftSampleKind")
                _getAccessor().LoadLookup_SampleKind(manager, this);
            
            if (lookup_object == "SpeciesVectorInfoLookup")
                _getAccessor().LoadLookup_SpeciesVectorInfo(manager, this);
            
            if (lookup_object == "DepartmentLookup")
                _getAccessor().LoadLookup_Department(manager, this);
            
            if (lookup_object == "FreezerTreeLookup")
                _getAccessor().LoadLookup_Freezer(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_TestedByOffice(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_TestedByPerson(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_ResultEnteredByOffice(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_ResultEnteredByPerson(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_ValidatedByOffice(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_ValidatedByPerson(manager, this);
            
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
        
            if (_AmendmentHistory != null) _AmendmentHistory.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_FFPresenter != null) _FFPresenter.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
            ParsedFormCollection(form);
        }
    
        #region Class for web grid
        public class LaboratorySectionItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 ID { get; set; }
        
            public Int64? idfTesting { get; set; }
        
            public Int64 idfMaterial { get; set; }
        
            public bool isChanges { get; set; }
        
            public String strCalculatedCaseID { get; set; }
        
            public String HumanName { get; set; }
        
            public String strRegion { get; set; }
        
            public String strRayon { get; set; }
        
            public String strFieldBarcode { get; set; }
        
            public Int64 idfsSampleStatus { get; set; }
        
            public String strSampleStatus { get; set; }
        
            public String strBarcode { get; set; }
        
            public Int64 idfsSampleType { get; set; }
        
            public String strSampleName { get; set; }
        
            public DateTime? datAccession { get; set; }
        
            public Int64? idfsAccessionCondition { get; set; }
        
            public String strSampleConditionReceivedStatus { get; set; }
        
            public Int64? idfsDiagnosis { get; set; }
        
            public String strDiagnosisName { get; set; }
        
            public Int64? idfsTestName { get; set; }
        
            public String strTestName { get; set; }
        
            public Int64? idfsTestStatus { get; set; }
        
            public String strTestStatus { get; set; }
        
            public Int64? idfsTestResult { get; set; }
        
            public String strTestResult { get; set; }
        
            public DateTime? datStartedDate { get; set; }
        
            public DateTime? datConcludedDate { get; set; }
        
            public Int64? idfsTestCategory { get; set; }
        
            public String strTestCategory { get; set; }
        
            public string strObservation { get; set; }
        
        }
        public partial class LaboratorySectionItemGridModelList : List<LaboratorySectionItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public LaboratorySectionItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LaboratorySectionItem>, errMes);
            }
            public LaboratorySectionItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LaboratorySectionItem>, errMes);
            }
            public LaboratorySectionItemGridModelList(long key, IEnumerable<LaboratorySectionItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public LaboratorySectionItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<LaboratorySectionItem>(), null);
            }
            partial void filter(List<LaboratorySectionItem> items);
            private void LoadGridModelList(long key, IEnumerable<LaboratorySectionItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strCalculatedCaseID,_str_HumanName,_str_strRegion,_str_strRayon,_str_strFieldBarcode,_str_strSampleStatus,_str_strBarcode,_str_strSampleName,_str_datAccession,_str_strSampleConditionReceivedStatus,_str_strDiagnosisName,_str_strTestName,_str_strTestStatus,_str_strTestResult,_str_datStartedDate,_str_datConcludedDate,_str_strTestCategory};
                    
                Hiddens = new List<string> {_str_ID,_str_idfTesting,_str_idfMaterial,_str_isChanges,_str_idfsSampleStatus,_str_idfsSampleType,_str_idfsAccessionCondition,_str_idfsDiagnosis,_str_idfsTestName,_str_idfsTestStatus,_str_idfsTestResult,_str_idfsTestCategory,_str_strObservation};
                Keys = new List<string> {_str_ID};
                Labels = new Dictionary<string, string> {{_str_strCalculatedCaseID, "strCaseIDSessionID"},{_str_HumanName, _str_HumanName},{_str_strRegion, _str_strRegion},{_str_strRayon, _str_strRayon},{_str_strFieldBarcode, _str_strFieldBarcode},{_str_strSampleStatus, "SampleStatus"},{_str_strBarcode, "strLabBarcode"},{_str_strSampleName, "idfsSampleType"},{_str_datAccession, _str_datAccession},{_str_strSampleConditionReceivedStatus, "idfsAccessionCondition"},{_str_strDiagnosisName, "TestDiagnosisName"},{_str_strTestName, "TestName"},{_str_strTestStatus, "TestStatus"},{_str_strTestResult, "TestResult"},{_str_datStartedDate, _str_datStartedDate},{_str_datConcludedDate, "datTestResultDate"},{_str_strTestCategory, "TestCategory"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                LaboratorySectionItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<LaboratorySectionItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new LaboratorySectionItemGridModel()
                {
                    ItemKey=c.ID,idfTesting=c.idfTesting,idfMaterial=c.idfMaterial,isChanges=c.isChanges,strCalculatedCaseID=c.strCalculatedCaseID,HumanName=c.HumanName,strRegion=c.strRegion,strRayon=c.strRayon,strFieldBarcode=c.strFieldBarcode,idfsSampleStatus=c.idfsSampleStatus,strSampleStatus=c.strSampleStatus,strBarcode=c.strBarcode,idfsSampleType=c.idfsSampleType,strSampleName=c.strSampleName,datAccession=c.datAccession,idfsAccessionCondition=c.idfsAccessionCondition,strSampleConditionReceivedStatus=c.strSampleConditionReceivedStatus,idfsDiagnosis=c.idfsDiagnosis,strDiagnosisName=c.strDiagnosisName,idfsTestName=c.idfsTestName,strTestName=c.strTestName,idfsTestStatus=c.idfsTestStatus,strTestStatus=c.strTestStatus,idfsTestResult=c.idfsTestResult,strTestResult=c.strTestResult,datStartedDate=c.datStartedDate,datConcludedDate=c.datConcludedDate,idfsTestCategory=c.idfsTestCategory,strTestCategory=c.strTestCategory,strObservation=c.strObservation
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
        : DataAccessor<LaboratorySectionItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<LaboratorySectionItem>
            
            , IObjectSelectList
            , IObjectSelectList<LaboratorySectionItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "ID"; } }
            #endregion
        
            private delegate void on_action(LaboratorySectionItem obj);
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
            private LaboratorySectionItem.Accessor SampleAccessor { get { return eidss.model.Schema.LaboratorySectionItem.Accessor.Instance(m_CS); } }
            private LaboratorySectionItem.Accessor TestAccessor { get { return eidss.model.Schema.LaboratorySectionItem.Accessor.Instance(m_CS); } }
            private LabTestAmendment.Accessor AmendmentHistoryAccessor { get { return eidss.model.Schema.LabTestAmendment.Accessor.Instance(m_CS); } }
            private FFPresenterModel.Accessor FFPresenterAccessor { get { return eidss.model.Schema.FFPresenterModel.Accessor.Instance(m_CS); } }
            private RegionLookup.Accessor RegionAccessor { get { return eidss.model.Schema.RegionLookup.Accessor.Instance(m_CS); } }
            private RayonLookup.Accessor RayonAccessor { get { return eidss.model.Schema.RayonLookup.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private TestDiagnosisLookup.Accessor DiagnosisForTestAccessor { get { return eidss.model.Schema.TestDiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SampleTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private SampleTypeForDiagnosisLookup.Accessor SampleTypeFilteredAccessor { get { return eidss.model.Schema.SampleTypeForDiagnosisLookup.Accessor.Instance(m_CS); } }
            private LabDerivativeTypesLookup.Accessor DerivativeTypeAccessor { get { return eidss.model.Schema.LabDerivativeTypesLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AccessionConditionAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private TestForDiseaseLookup.Accessor TestNameForSearchAccessor { get { return eidss.model.Schema.TestForDiseaseLookup.Accessor.Instance(m_CS); } }
            private TestForDiseaseLookup.Accessor TestNameRefAccessor { get { return eidss.model.Schema.TestForDiseaseLookup.Accessor.Instance(m_CS); } }
            private TestResultLookup.Accessor TestResultRefAccessor { get { return eidss.model.Schema.TestResultLookup.Accessor.Instance(m_CS); } }
            private TestResultLookup.Accessor TestResultForAmendAccessor { get { return eidss.model.Schema.TestResultLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestResultDummyAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestCategoryRefAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestStatusShortAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestStatusForSearchAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestStatusFullAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SampleStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SampleStatusFullAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor AccessionByPersonAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor SendToOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor SendToOfficeOutAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor PerformedByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor CollectedByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor CollectedByPersonAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CaseTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor DestructionMethodAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SampleKindAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private SpeciesVectorInfoLookup.Accessor SpeciesVectorInfoAccessor { get { return eidss.model.Schema.SpeciesVectorInfoLookup.Accessor.Instance(m_CS); } }
            private DepartmentLookup.Accessor DepartmentAccessor { get { return eidss.model.Schema.DepartmentLookup.Accessor.Instance(m_CS); } }
            private FreezerTreeLookup.Accessor FreezerAccessor { get { return eidss.model.Schema.FreezerTreeLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor TestedByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor TestedByPersonAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor ResultEnteredByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor ResultEnteredByPersonAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor ValidatedByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor ValidatedByPersonAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<LaboratorySectionItem> SelectListT(DbManagerProxy manager
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
            
            private List<LaboratorySectionItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_LaboratorySection_SelectList.* from dbo.fn_LaboratorySection_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("MyPref"))
                {
                    
                    sql.Append(" " + @"
            inner join tstLocalSamplesTestsPreferences as pref
                on pref.idfMaterial = fn_LaboratorySection_SelectList.idfMaterial
                and isnull(pref.idfTesting, 0) = isnull(fn_LaboratorySection_SelectList.idfTesting, 0)
          ");
                      
                }
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("MyPref"))
                    sql.AppendFormat(" and " + new Func<string>(() => "(pref.idfUserID = " + ModelUserContext.Instance.CurrentUser.ID.ToString() + ")")());
                            
                if (filters.Contains("ID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("ID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("ID") ? " or " : " and ");
                        
                        if (filters.Operation("ID", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.ID,0) {0} @ID_{1} = @ID_{1})", filters.Operation("ID", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.ID,0) {0} @ID_{1}", filters.Operation("ID", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfTesting,0) {0} @idfTesting_{1} = @idfTesting_{1})", filters.Operation("idfTesting", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfTesting,0) {0} @idfTesting_{1}", filters.Operation("idfTesting", i), i);
                            
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
                        
                        if (filters.Operation("idfMaterial", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfMaterial,0) {0} @idfMaterial_{1} = @idfMaterial_{1})", filters.Operation("idfMaterial", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfMaterial,0) {0} @idfMaterial_{1}", filters.Operation("idfMaterial", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfSpeciesVectorInfo"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfSpeciesVectorInfo"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfSpeciesVectorInfo") ? " or " : " and ");
                        
                        if (filters.Operation("idfSpeciesVectorInfo", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfSpeciesVectorInfo,0) {0} @idfSpeciesVectorInfo_{1} = @idfSpeciesVectorInfo_{1})", filters.Operation("idfSpeciesVectorInfo", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfSpeciesVectorInfo,0) {0} @idfSpeciesVectorInfo_{1}", filters.Operation("idfSpeciesVectorInfo", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfCaseOrSession"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfCaseOrSession"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfCaseOrSession") ? " or " : " and ");
                        
                        if (filters.Operation("idfCaseOrSession", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfCaseOrSession,0) {0} @idfCaseOrSession_{1} = @idfCaseOrSession_{1})", filters.Operation("idfCaseOrSession", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfCaseOrSession,0) {0} @idfCaseOrSession_{1}", filters.Operation("idfCaseOrSession", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsSampleStatus,0) {0} @idfsSampleStatus_{1} = @idfsSampleStatus_{1})", filters.Operation("idfsSampleStatus", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsSampleStatus,0) {0} @idfsSampleStatus_{1}", filters.Operation("idfsSampleStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datSampleStatusDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datSampleStatusDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datSampleStatusDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LaboratorySection_SelectList.datSampleStatusDate, 112) {0} CONVERT(NVARCHAR(8), @datSampleStatusDate_{1}, 112)", filters.Operation("datSampleStatusDate", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsSampleType,0) {0} @idfsSampleType_{1} = @idfsSampleType_{1})", filters.Operation("idfsSampleType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsSampleType,0) {0} @idfsSampleType_{1}", filters.Operation("idfsSampleType", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsDiagnosis,0) {0} @idfsDiagnosis_{1} = @idfsDiagnosis_{1})", filters.Operation("idfsDiagnosis", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsDiagnosis,0) {0} @idfsDiagnosis_{1}", filters.Operation("idfsDiagnosis", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsShowDiagnosis,0) {0} @idfsShowDiagnosis_{1} = @idfsShowDiagnosis_{1})", filters.Operation("idfsShowDiagnosis", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsShowDiagnosis,0) {0} @idfsShowDiagnosis_{1}", filters.Operation("idfsShowDiagnosis", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strDiagnosisName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strDiagnosisName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strDiagnosisName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strDiagnosisName {0} @strDiagnosisName_{1}", filters.Operation("strDiagnosisName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfRootMaterial"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfRootMaterial"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfRootMaterial") ? " or " : " and ");
                        
                        if (filters.Operation("idfRootMaterial", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfRootMaterial,0) {0} @idfRootMaterial_{1} = @idfRootMaterial_{1})", filters.Operation("idfRootMaterial", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfRootMaterial,0) {0} @idfRootMaterial_{1}", filters.Operation("idfRootMaterial", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfParentMaterial"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfParentMaterial"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfParentMaterial") ? " or " : " and ");
                        
                        if (filters.Operation("idfParentMaterial", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfParentMaterial,0) {0} @idfParentMaterial_{1} = @idfParentMaterial_{1})", filters.Operation("idfParentMaterial", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfParentMaterial,0) {0} @idfParentMaterial_{1}", filters.Operation("idfParentMaterial", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strParentMaterial"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strParentMaterial"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strParentMaterial") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strParentMaterial {0} @strParentMaterial_{1}", filters.Operation("strParentMaterial", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfHuman"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfHuman"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfHuman") ? " or " : " and ");
                        
                        if (filters.Operation("idfHuman", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfHuman,0) {0} @idfHuman_{1} = @idfHuman_{1})", filters.Operation("idfHuman", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfHuman,0) {0} @idfHuman_{1}", filters.Operation("idfHuman", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfSpecies"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfSpecies"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfSpecies") ? " or " : " and ");
                        
                        if (filters.Operation("idfSpecies", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfSpecies,0) {0} @idfSpecies_{1} = @idfSpecies_{1})", filters.Operation("idfSpecies", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfSpecies,0) {0} @idfSpecies_{1}", filters.Operation("idfSpecies", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfAnimal"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfAnimal"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfAnimal") ? " or " : " and ");
                        
                        if (filters.Operation("idfAnimal", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfAnimal,0) {0} @idfAnimal_{1} = @idfAnimal_{1})", filters.Operation("idfAnimal", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfAnimal,0) {0} @idfAnimal_{1}", filters.Operation("idfAnimal", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfHumanCase,0) {0} @idfHumanCase_{1} = @idfHumanCase_{1})", filters.Operation("idfHumanCase", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfHumanCase,0) {0} @idfHumanCase_{1}", filters.Operation("idfHumanCase", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfVetCase,0) {0} @idfVetCase_{1} = @idfVetCase_{1})", filters.Operation("idfVetCase", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfVetCase,0) {0} @idfVetCase_{1}", filters.Operation("idfVetCase", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfMonitoringSession,0) {0} @idfMonitoringSession_{1} = @idfMonitoringSession_{1})", filters.Operation("idfMonitoringSession", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfMonitoringSession,0) {0} @idfMonitoringSession_{1}", filters.Operation("idfMonitoringSession", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfMainTest"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfMainTest"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfMainTest") ? " or " : " and ");
                        
                        if (filters.Operation("idfMainTest", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfMainTest,0) {0} @idfMainTest_{1} = @idfMainTest_{1})", filters.Operation("idfMainTest", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfMainTest,0) {0} @idfMainTest_{1}", filters.Operation("idfMainTest", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfVectorSurveillanceSession,0) {0} @idfVectorSurveillanceSession_{1} = @idfVectorSurveillanceSession_{1})", filters.Operation("idfVectorSurveillanceSession", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfVectorSurveillanceSession,0) {0} @idfVectorSurveillanceSession_{1}", filters.Operation("idfVectorSurveillanceSession", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfVector"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfVector"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfVector") ? " or " : " and ");
                        
                        if (filters.Operation("idfVector", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfVector,0) {0} @idfVector_{1} = @idfVector_{1})", filters.Operation("idfVector", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfVector,0) {0} @idfVector_{1}", filters.Operation("idfVector", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfDestroyedByPerson"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfDestroyedByPerson"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfDestroyedByPerson") ? " or " : " and ");
                        
                        if (filters.Operation("idfDestroyedByPerson", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfDestroyedByPerson,0) {0} @idfDestroyedByPerson_{1} = @idfDestroyedByPerson_{1})", filters.Operation("idfDestroyedByPerson", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfDestroyedByPerson,0) {0} @idfDestroyedByPerson_{1}", filters.Operation("idfDestroyedByPerson", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strBarcode {0} @strBarcode_{1}", filters.Operation("strBarcode", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strFieldBarcode {0} @strFieldBarcode_{1}", filters.Operation("strFieldBarcode", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LaboratorySection_SelectList.datFieldCollectionDate, 112) {0} CONVERT(NVARCHAR(8), @datFieldCollectionDate_{1}, 112)", filters.Operation("datFieldCollectionDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datFieldSentDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datFieldSentDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datFieldSentDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LaboratorySection_SelectList.datFieldSentDate, 112) {0} CONVERT(NVARCHAR(8), @datFieldSentDate_{1}, 112)", filters.Operation("datFieldSentDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCalculatedCaseID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCalculatedCaseID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCalculatedCaseID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strCalculatedCaseID {0} @strCalculatedCaseID_{1}", filters.Operation("strCalculatedCaseID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCalculatedHumanName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCalculatedHumanName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCalculatedHumanName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strCalculatedHumanName {0} @strCalculatedHumanName_{1}", filters.Operation("strCalculatedHumanName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfAccesionByPerson"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfAccesionByPerson"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfAccesionByPerson") ? " or " : " and ");
                        
                        if (filters.Operation("idfAccesionByPerson", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfAccesionByPerson,0) {0} @idfAccesionByPerson_{1} = @idfAccesionByPerson_{1})", filters.Operation("idfAccesionByPerson", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfAccesionByPerson,0) {0} @idfAccesionByPerson_{1}", filters.Operation("idfAccesionByPerson", i), i);
                            
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
                        
                        if (filters.Operation("idfsAccessionCondition", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsAccessionCondition,0) {0} @idfsAccessionCondition_{1} = @idfsAccessionCondition_{1})", filters.Operation("idfsAccessionCondition", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsAccessionCondition,0) {0} @idfsAccessionCondition_{1}", filters.Operation("idfsAccessionCondition", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LaboratorySection_SelectList.datAccession, 112) {0} CONVERT(NVARCHAR(8), @datAccession_{1}, 112)", filters.Operation("datAccession", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datEnteringDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datEnteringDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datEnteringDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LaboratorySection_SelectList.datEnteringDate, 112) {0} CONVERT(NVARCHAR(8), @datEnteringDate_{1}, 112)", filters.Operation("datEnteringDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datDestructionDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datDestructionDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datDestructionDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LaboratorySection_SelectList.datDestructionDate, 112) {0} CONVERT(NVARCHAR(8), @datDestructionDate_{1}, 112)", filters.Operation("datDestructionDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfSendToOffice"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfSendToOffice"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfSendToOffice") ? " or " : " and ");
                        
                        if (filters.Operation("idfSendToOffice", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfSendToOffice,0) {0} @idfSendToOffice_{1} = @idfSendToOffice_{1})", filters.Operation("idfSendToOffice", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfSendToOffice,0) {0} @idfSendToOffice_{1}", filters.Operation("idfSendToOffice", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfSubdivision"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfSubdivision"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfSubdivision") ? " or " : " and ");
                        
                        if (filters.Operation("idfSubdivision", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfSubdivision,0) {0} @idfSubdivision_{1} = @idfSubdivision_{1})", filters.Operation("idfSubdivision", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfSubdivision,0) {0} @idfSubdivision_{1}", filters.Operation("idfSubdivision", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfInDepartment,0) {0} @idfInDepartment_{1} = @idfInDepartment_{1})", filters.Operation("idfInDepartment", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfInDepartment,0) {0} @idfInDepartment_{1}", filters.Operation("idfInDepartment", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsCaseType,0) {0} @idfsCaseType_{1} = @idfsCaseType_{1})", filters.Operation("idfsCaseType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsCaseType,0) {0} @idfsCaseType_{1}", filters.Operation("idfsCaseType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intCaseHACode"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intCaseHACode"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intCaseHACode") ? " or " : " and ");
                        
                        if (filters.Operation("intCaseHACode", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.intCaseHACode,0) {0} @intCaseHACode_{1} = @intCaseHACode_{1})", filters.Operation("intCaseHACode", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.intCaseHACode,0) {0} @intCaseHACode_{1}", filters.Operation("intCaseHACode", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfFieldCollectedByOffice"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfFieldCollectedByOffice"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfFieldCollectedByOffice") ? " or " : " and ");
                        
                        if (filters.Operation("idfFieldCollectedByOffice", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfFieldCollectedByOffice,0) {0} @idfFieldCollectedByOffice_{1} = @idfFieldCollectedByOffice_{1})", filters.Operation("idfFieldCollectedByOffice", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfFieldCollectedByOffice,0) {0} @idfFieldCollectedByOffice_{1}", filters.Operation("idfFieldCollectedByOffice", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfFieldCollectedByPerson"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfFieldCollectedByPerson"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfFieldCollectedByPerson") ? " or " : " and ");
                        
                        if (filters.Operation("idfFieldCollectedByPerson", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfFieldCollectedByPerson,0) {0} @idfFieldCollectedByPerson_{1} = @idfFieldCollectedByPerson_{1})", filters.Operation("idfFieldCollectedByPerson", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfFieldCollectedByPerson,0) {0} @idfFieldCollectedByPerson_{1}", filters.Operation("idfFieldCollectedByPerson", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsDestructionMethod"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsDestructionMethod"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsDestructionMethod") ? " or " : " and ");
                        
                        if (filters.Operation("idfsDestructionMethod", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsDestructionMethod,0) {0} @idfsDestructionMethod_{1} = @idfsDestructionMethod_{1})", filters.Operation("idfsDestructionMethod", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsDestructionMethod,0) {0} @idfsDestructionMethod_{1}", filters.Operation("idfsDestructionMethod", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSampleNote"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSampleNote"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSampleNote") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strSampleNote {0} @strSampleNote_{1}", filters.Operation("strSampleNote", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCondition"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCondition"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCondition") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strCondition {0} @strCondition_{1}", filters.Operation("strCondition", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSampleKind"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSampleKind"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSampleKind") ? " or " : " and ");
                        
                        if (filters.Operation("idfsSampleKind", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsSampleKind,0) {0} @idfsSampleKind_{1} = @idfsSampleKind_{1})", filters.Operation("idfsSampleKind", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsSampleKind,0) {0} @idfsSampleKind_{1}", filters.Operation("idfsSampleKind", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfMarkedForDispositionByPerson"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfMarkedForDispositionByPerson"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfMarkedForDispositionByPerson") ? " or " : " and ");
                        
                        if (filters.Operation("idfMarkedForDispositionByPerson", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfMarkedForDispositionByPerson,0) {0} @idfMarkedForDispositionByPerson_{1} = @idfMarkedForDispositionByPerson_{1})", filters.Operation("idfMarkedForDispositionByPerson", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfMarkedForDispositionByPerson,0) {0} @idfMarkedForDispositionByPerson_{1}", filters.Operation("idfMarkedForDispositionByPerson", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intTestCount"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intTestCount"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intTestCount") ? " or " : " and ");
                        
                        if (filters.Operation("intTestCount", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.intTestCount,0) {0} @intTestCount_{1} = @intTestCount_{1})", filters.Operation("intTestCount", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.intTestCount,0) {0} @intTestCount_{1}", filters.Operation("intTestCount", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfSendToOfficeOut"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfSendToOfficeOut"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfSendToOfficeOut") ? " or " : " and ");
                        
                        if (filters.Operation("idfSendToOfficeOut", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfSendToOfficeOut,0) {0} @idfSendToOfficeOut_{1} = @idfSendToOfficeOut_{1})", filters.Operation("idfSendToOfficeOut", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfSendToOfficeOut,0) {0} @idfSendToOfficeOut_{1}", filters.Operation("idfSendToOfficeOut", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("bExternalOffice"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("bExternalOffice"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("bExternalOffice") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.bExternalOffice {0} @bExternalOffice_{1}", filters.Operation("bExternalOffice", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfSendByPerson"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfSendByPerson"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfSendByPerson") ? " or " : " and ");
                        
                        if (filters.Operation("idfSendByPerson", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfSendByPerson,0) {0} @idfSendByPerson_{1} = @idfSendByPerson_{1})", filters.Operation("idfSendByPerson", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfSendByPerson,0) {0} @idfSendByPerson_{1}", filters.Operation("idfSendByPerson", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datSendDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datSendDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datSendDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LaboratorySection_SelectList.datSendDate, 112) {0} CONVERT(NVARCHAR(8), @datSendDate_{1}, 112)", filters.Operation("datSendDate", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.HumanName {0} @HumanName_{1}", filters.Operation("HumanName", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strPatientName {0} @strPatientName_{1}", filters.Operation("strPatientName", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strFarmOwner {0} @strFarmOwner_{1}", filters.Operation("strFarmOwner", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCountry"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCountry"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCountry") ? " or " : " and ");
                        
                        if (filters.Operation("idfsCountry", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsCountry,0) {0} @idfsCountry_{1} = @idfsCountry_{1})", filters.Operation("idfsCountry", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsCountry,0) {0} @idfsCountry_{1}", filters.Operation("idfsCountry", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsRegion"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsRegion"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsRegion") ? " or " : " and ");
                        
                        if (filters.Operation("idfsRegion", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsRegion,0) {0} @idfsRegion_{1} = @idfsRegion_{1})", filters.Operation("idfsRegion", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsRegion,0) {0} @idfsRegion_{1}", filters.Operation("idfsRegion", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strRegion"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strRegion"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strRegion") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strRegion {0} @strRegion_{1}", filters.Operation("strRegion", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsRayon"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsRayon"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsRayon") ? " or " : " and ");
                        
                        if (filters.Operation("idfsRayon", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsRayon,0) {0} @idfsRayon_{1} = @idfsRayon_{1})", filters.Operation("idfsRayon", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsRayon,0) {0} @idfsRayon_{1}", filters.Operation("idfsRayon", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strRayon"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strRayon"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strRayon") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strRayon {0} @strRayon_{1}", filters.Operation("strRayon", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSettlement"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSettlement"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSettlement") ? " or " : " and ");
                        
                        if (filters.Operation("idfsSettlement", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsSettlement,0) {0} @idfsSettlement_{1} = @idfsSettlement_{1})", filters.Operation("idfsSettlement", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsSettlement,0) {0} @idfsSettlement_{1}", filters.Operation("idfsSettlement", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsTestName,0) {0} @idfsTestName_{1} = @idfsTestName_{1})", filters.Operation("idfsTestName", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsTestName,0) {0} @idfsTestName_{1}", filters.Operation("idfsTestName", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsTestCategory,0) {0} @idfsTestCategory_{1} = @idfsTestCategory_{1})", filters.Operation("idfsTestCategory", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsTestCategory,0) {0} @idfsTestCategory_{1}", filters.Operation("idfsTestCategory", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsTestStatus,0) {0} @idfsTestStatus_{1} = @idfsTestStatus_{1})", filters.Operation("idfsTestStatus", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsTestStatus,0) {0} @idfsTestStatus_{1}", filters.Operation("idfsTestStatus", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsTestResult,0) {0} @idfsTestResult_{1} = @idfsTestResult_{1})", filters.Operation("idfsTestResult", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsTestResult,0) {0} @idfsTestResult_{1}", filters.Operation("idfsTestResult", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LaboratorySection_SelectList.datStartedDate, 112) {0} CONVERT(NVARCHAR(8), @datStartedDate_{1}, 112)", filters.Operation("datStartedDate", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LaboratorySection_SelectList.datConcludedDate, 112) {0} CONVERT(NVARCHAR(8), @datConcludedDate_{1}, 112)", filters.Operation("datConcludedDate", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfObservation,0) {0} @idfObservation_{1} = @idfObservation_{1})", filters.Operation("idfObservation", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfObservation,0) {0} @idfObservation_{1}", filters.Operation("idfObservation", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strNote"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strNote"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strNote") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strNote {0} @strNote_{1}", filters.Operation("strNote", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfTestedByOffice"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfTestedByOffice"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfTestedByOffice") ? " or " : " and ");
                        
                        if (filters.Operation("idfTestedByOffice", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfTestedByOffice,0) {0} @idfTestedByOffice_{1} = @idfTestedByOffice_{1})", filters.Operation("idfTestedByOffice", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfTestedByOffice,0) {0} @idfTestedByOffice_{1}", filters.Operation("idfTestedByOffice", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfTestedByPerson"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfTestedByPerson"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfTestedByPerson") ? " or " : " and ");
                        
                        if (filters.Operation("idfTestedByPerson", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfTestedByPerson,0) {0} @idfTestedByPerson_{1} = @idfTestedByPerson_{1})", filters.Operation("idfTestedByPerson", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfTestedByPerson,0) {0} @idfTestedByPerson_{1}", filters.Operation("idfTestedByPerson", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfResultEnteredByOffice"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfResultEnteredByOffice"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfResultEnteredByOffice") ? " or " : " and ");
                        
                        if (filters.Operation("idfResultEnteredByOffice", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfResultEnteredByOffice,0) {0} @idfResultEnteredByOffice_{1} = @idfResultEnteredByOffice_{1})", filters.Operation("idfResultEnteredByOffice", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfResultEnteredByOffice,0) {0} @idfResultEnteredByOffice_{1}", filters.Operation("idfResultEnteredByOffice", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfResultEnteredByPerson"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfResultEnteredByPerson"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfResultEnteredByPerson") ? " or " : " and ");
                        
                        if (filters.Operation("idfResultEnteredByPerson", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfResultEnteredByPerson,0) {0} @idfResultEnteredByPerson_{1} = @idfResultEnteredByPerson_{1})", filters.Operation("idfResultEnteredByPerson", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfResultEnteredByPerson,0) {0} @idfResultEnteredByPerson_{1}", filters.Operation("idfResultEnteredByPerson", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfValidatedByOffice"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfValidatedByOffice"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfValidatedByOffice") ? " or " : " and ");
                        
                        if (filters.Operation("idfValidatedByOffice", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfValidatedByOffice,0) {0} @idfValidatedByOffice_{1} = @idfValidatedByOffice_{1})", filters.Operation("idfValidatedByOffice", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfValidatedByOffice,0) {0} @idfValidatedByOffice_{1}", filters.Operation("idfValidatedByOffice", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfValidatedByPerson"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfValidatedByPerson"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfValidatedByPerson") ? " or " : " and ");
                        
                        if (filters.Operation("idfValidatedByPerson", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfValidatedByPerson,0) {0} @idfValidatedByPerson_{1} = @idfValidatedByPerson_{1})", filters.Operation("idfValidatedByPerson", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfValidatedByPerson,0) {0} @idfValidatedByPerson_{1}", filters.Operation("idfValidatedByPerson", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("blnNonLaboratoryTest"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("blnNonLaboratoryTest"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("blnNonLaboratoryTest") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.blnNonLaboratoryTest {0} @blnNonLaboratoryTest_{1}", filters.Operation("blnNonLaboratoryTest", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("blnExternalTest"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("blnExternalTest"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("blnExternalTest") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.blnExternalTest {0} @blnExternalTest_{1}", filters.Operation("blnExternalTest", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datReceivedDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datReceivedDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datReceivedDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LaboratorySection_SelectList.datReceivedDate, 112) {0} CONVERT(NVARCHAR(8), @datReceivedDate_{1}, 112)", filters.Operation("datReceivedDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfPerformedByOffice"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfPerformedByOffice"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfPerformedByOffice") ? " or " : " and ");
                        
                        if (filters.Operation("idfPerformedByOffice", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfPerformedByOffice,0) {0} @idfPerformedByOffice_{1} = @idfPerformedByOffice_{1})", filters.Operation("idfPerformedByOffice", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfPerformedByOffice,0) {0} @idfPerformedByOffice_{1}", filters.Operation("idfPerformedByOffice", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strContactPerson"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strContactPerson"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strContactPerson") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strContactPerson {0} @strContactPerson_{1}", filters.Operation("strContactPerson", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsFormTemplate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsFormTemplate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsFormTemplate") ? " or " : " and ");
                        
                        if (filters.Operation("idfsFormTemplate", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsFormTemplate,0) {0} @idfsFormTemplate_{1} = @idfsFormTemplate_{1})", filters.Operation("idfsFormTemplate", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsFormTemplate,0) {0} @idfsFormTemplate_{1}", filters.Operation("idfsFormTemplate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strBatchID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strBatchID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strBatchID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strBatchID {0} @strBatchID_{1}", filters.Operation("strBatchID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSampleStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSampleStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSampleStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strSampleStatus {0} @strSampleStatus_{1}", filters.Operation("strSampleStatus", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strSampleName {0} @strSampleName_{1}", filters.Operation("strSampleName", i), i);
                            
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
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strSampleConditionReceivedStatus {0} @strSampleConditionReceivedStatus_{1}", filters.Operation("strSampleConditionReceivedStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strTestName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strTestName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strTestName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strTestName {0} @strTestName_{1}", filters.Operation("strTestName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strTestStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strTestStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strTestStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strTestStatus {0} @strTestStatus_{1}", filters.Operation("strTestStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strTestResult"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strTestResult"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strTestResult") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strTestResult {0} @strTestResult_{1}", filters.Operation("strTestResult", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strTestCategory"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strTestCategory"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strTestCategory") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strTestCategory {0} @strTestCategory_{1}", filters.Operation("strTestCategory", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsLaboratorySection"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsLaboratorySection"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsLaboratorySection") ? " or " : " and ");
                        
                        if (filters.Operation("idfsLaboratorySection", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsLaboratorySection,0) {0} @idfsLaboratorySection_{1} = @idfsLaboratorySection_{1})", filters.Operation("idfsLaboratorySection", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsLaboratorySection,0) {0} @idfsLaboratorySection_{1}", filters.Operation("idfsLaboratorySection", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("bTestDeleted"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("bTestDeleted"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("bTestDeleted") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.bTestDeleted {0} @bTestDeleted_{1}", filters.Operation("bTestDeleted", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("bTestInserted"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("bTestInserted"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("bTestInserted") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.bTestInserted {0} @bTestInserted_{1}", filters.Operation("bTestInserted", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("bTestInsertedFirst"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("bTestInsertedFirst"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("bTestInsertedFirst") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.bTestInsertedFirst {0} @bTestInsertedFirst_{1}", filters.Operation("bTestInsertedFirst", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("bFilterTestByDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("bFilterTestByDiagnosis"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("bFilterTestByDiagnosis") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.bFilterTestByDiagnosis {0} @bFilterTestByDiagnosis_{1}", filters.Operation("bFilterTestByDiagnosis", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intNewSample"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intNewSample"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intNewSample") ? " or " : " and ");
                        
                        if (filters.Operation("intNewSample", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.intNewSample,0) {0} @intNewSample_{1} = @intNewSample_{1})", filters.Operation("intNewSample", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.intNewSample,0) {0} @intNewSample_{1}", filters.Operation("intNewSample", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSampleTypeFiltered"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSampleTypeFiltered"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSampleTypeFiltered") ? " or " : " and ");
                        
                        if (filters.Operation("idfsSampleTypeFiltered", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySection_SelectList.idfsSampleTypeFiltered,0) {0} @idfsSampleTypeFiltered_{1} = @idfsSampleTypeFiltered_{1})", filters.Operation("idfsSampleTypeFiltered", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySection_SelectList.idfsSampleTypeFiltered,0) {0} @idfsSampleTypeFiltered_{1}", filters.Operation("idfsSampleTypeFiltered", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strComments"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strComments"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strComments") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strComments {0} @strComments_{1}", filters.Operation("strComments", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strReason"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strReason"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strReason") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySection_SelectList.strReason {0} @strReason_{1}", filters.Operation("strReason", i), i);
                            
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
                    
                    if (filters.Contains("idfsRegion"))
                        
                        if (filters.Count("idfsRegion") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion", ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion"), filters.Value("idfsRegion"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsRegion"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion", i), filters.Value("idfsRegion", i))));
                        }
                            
                    if (filters.Contains("idfsRayon"))
                        
                        if (filters.Count("idfsRayon") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon", ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon"), filters.Value("idfsRayon"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsRayon"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon", i), filters.Value("idfsRayon", i))));
                        }
                            
                    if (filters.Contains("ID"))
                        for (int i = 0; i < filters.Count("ID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@ID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("ID", i), filters.Value("ID", i))));
                      
                    if (filters.Contains("idfTesting"))
                        for (int i = 0; i < filters.Count("idfTesting"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfTesting_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfTesting", i), filters.Value("idfTesting", i))));
                      
                    if (filters.Contains("idfMaterial"))
                        for (int i = 0; i < filters.Count("idfMaterial"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfMaterial_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfMaterial", i), filters.Value("idfMaterial", i))));
                      
                    if (filters.Contains("idfSpeciesVectorInfo"))
                        for (int i = 0; i < filters.Count("idfSpeciesVectorInfo"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfSpeciesVectorInfo_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfSpeciesVectorInfo", i), filters.Value("idfSpeciesVectorInfo", i))));
                      
                    if (filters.Contains("idfCaseOrSession"))
                        for (int i = 0; i < filters.Count("idfCaseOrSession"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfCaseOrSession_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfCaseOrSession", i), filters.Value("idfCaseOrSession", i))));
                      
                    if (filters.Contains("idfsSampleStatus"))
                        for (int i = 0; i < filters.Count("idfsSampleStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSampleStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSampleStatus", i), filters.Value("idfsSampleStatus", i))));
                      
                    if (filters.Contains("datSampleStatusDate"))
                        for (int i = 0; i < filters.Count("datSampleStatusDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datSampleStatusDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datSampleStatusDate", i), filters.Value("datSampleStatusDate", i))));
                      
                    if (filters.Contains("idfsSampleType"))
                        for (int i = 0; i < filters.Count("idfsSampleType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSampleType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSampleType", i), filters.Value("idfsSampleType", i))));
                      
                    if (filters.Contains("idfsDiagnosis"))
                        for (int i = 0; i < filters.Count("idfsDiagnosis"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosis", i), filters.Value("idfsDiagnosis", i))));
                      
                    if (filters.Contains("idfsShowDiagnosis"))
                        for (int i = 0; i < filters.Count("idfsShowDiagnosis"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsShowDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsShowDiagnosis", i), filters.Value("idfsShowDiagnosis", i))));
                      
                    if (filters.Contains("strDiagnosisName"))
                        for (int i = 0; i < filters.Count("strDiagnosisName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strDiagnosisName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strDiagnosisName", i), filters.Value("strDiagnosisName", i))));
                      
                    if (filters.Contains("idfRootMaterial"))
                        for (int i = 0; i < filters.Count("idfRootMaterial"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfRootMaterial_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfRootMaterial", i), filters.Value("idfRootMaterial", i))));
                      
                    if (filters.Contains("idfParentMaterial"))
                        for (int i = 0; i < filters.Count("idfParentMaterial"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfParentMaterial_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfParentMaterial", i), filters.Value("idfParentMaterial", i))));
                      
                    if (filters.Contains("strParentMaterial"))
                        for (int i = 0; i < filters.Count("strParentMaterial"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strParentMaterial_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strParentMaterial", i), filters.Value("strParentMaterial", i))));
                      
                    if (filters.Contains("idfHuman"))
                        for (int i = 0; i < filters.Count("idfHuman"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfHuman_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfHuman", i), filters.Value("idfHuman", i))));
                      
                    if (filters.Contains("idfSpecies"))
                        for (int i = 0; i < filters.Count("idfSpecies"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfSpecies_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfSpecies", i), filters.Value("idfSpecies", i))));
                      
                    if (filters.Contains("idfAnimal"))
                        for (int i = 0; i < filters.Count("idfAnimal"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfAnimal_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfAnimal", i), filters.Value("idfAnimal", i))));
                      
                    if (filters.Contains("idfHumanCase"))
                        for (int i = 0; i < filters.Count("idfHumanCase"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfHumanCase_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfHumanCase", i), filters.Value("idfHumanCase", i))));
                      
                    if (filters.Contains("idfVetCase"))
                        for (int i = 0; i < filters.Count("idfVetCase"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfVetCase_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfVetCase", i), filters.Value("idfVetCase", i))));
                      
                    if (filters.Contains("idfMonitoringSession"))
                        for (int i = 0; i < filters.Count("idfMonitoringSession"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfMonitoringSession_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfMonitoringSession", i), filters.Value("idfMonitoringSession", i))));
                      
                    if (filters.Contains("idfMainTest"))
                        for (int i = 0; i < filters.Count("idfMainTest"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfMainTest_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfMainTest", i), filters.Value("idfMainTest", i))));
                      
                    if (filters.Contains("idfVectorSurveillanceSession"))
                        for (int i = 0; i < filters.Count("idfVectorSurveillanceSession"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfVectorSurveillanceSession_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfVectorSurveillanceSession", i), filters.Value("idfVectorSurveillanceSession", i))));
                      
                    if (filters.Contains("idfVector"))
                        for (int i = 0; i < filters.Count("idfVector"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfVector_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfVector", i), filters.Value("idfVector", i))));
                      
                    if (filters.Contains("idfDestroyedByPerson"))
                        for (int i = 0; i < filters.Count("idfDestroyedByPerson"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfDestroyedByPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfDestroyedByPerson", i), filters.Value("idfDestroyedByPerson", i))));
                      
                    if (filters.Contains("strBarcode"))
                        for (int i = 0; i < filters.Count("strBarcode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strBarcode", i), filters.Value("strBarcode", i))));
                      
                    if (filters.Contains("strFieldBarcode"))
                        for (int i = 0; i < filters.Count("strFieldBarcode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFieldBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFieldBarcode", i), filters.Value("strFieldBarcode", i))));
                      
                    if (filters.Contains("datFieldCollectionDate"))
                        for (int i = 0; i < filters.Count("datFieldCollectionDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datFieldCollectionDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datFieldCollectionDate", i), filters.Value("datFieldCollectionDate", i))));
                      
                    if (filters.Contains("datFieldSentDate"))
                        for (int i = 0; i < filters.Count("datFieldSentDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datFieldSentDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datFieldSentDate", i), filters.Value("datFieldSentDate", i))));
                      
                    if (filters.Contains("strCalculatedCaseID"))
                        for (int i = 0; i < filters.Count("strCalculatedCaseID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCalculatedCaseID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCalculatedCaseID", i), filters.Value("strCalculatedCaseID", i))));
                      
                    if (filters.Contains("strCalculatedHumanName"))
                        for (int i = 0; i < filters.Count("strCalculatedHumanName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCalculatedHumanName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCalculatedHumanName", i), filters.Value("strCalculatedHumanName", i))));
                      
                    if (filters.Contains("idfAccesionByPerson"))
                        for (int i = 0; i < filters.Count("idfAccesionByPerson"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfAccesionByPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfAccesionByPerson", i), filters.Value("idfAccesionByPerson", i))));
                      
                    if (filters.Contains("idfsAccessionCondition"))
                        for (int i = 0; i < filters.Count("idfsAccessionCondition"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsAccessionCondition_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsAccessionCondition", i), filters.Value("idfsAccessionCondition", i))));
                      
                    if (filters.Contains("datAccession"))
                        for (int i = 0; i < filters.Count("datAccession"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datAccession_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datAccession", i), filters.Value("datAccession", i))));
                      
                    if (filters.Contains("datEnteringDate"))
                        for (int i = 0; i < filters.Count("datEnteringDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datEnteringDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datEnteringDate", i), filters.Value("datEnteringDate", i))));
                      
                    if (filters.Contains("datDestructionDate"))
                        for (int i = 0; i < filters.Count("datDestructionDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datDestructionDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datDestructionDate", i), filters.Value("datDestructionDate", i))));
                      
                    if (filters.Contains("idfSendToOffice"))
                        for (int i = 0; i < filters.Count("idfSendToOffice"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfSendToOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfSendToOffice", i), filters.Value("idfSendToOffice", i))));
                      
                    if (filters.Contains("idfSubdivision"))
                        for (int i = 0; i < filters.Count("idfSubdivision"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfSubdivision_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfSubdivision", i), filters.Value("idfSubdivision", i))));
                      
                    if (filters.Contains("idfInDepartment"))
                        for (int i = 0; i < filters.Count("idfInDepartment"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfInDepartment_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfInDepartment", i), filters.Value("idfInDepartment", i))));
                      
                    if (filters.Contains("idfsCaseType"))
                        for (int i = 0; i < filters.Count("idfsCaseType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseType", i), filters.Value("idfsCaseType", i))));
                      
                    if (filters.Contains("intCaseHACode"))
                        for (int i = 0; i < filters.Count("intCaseHACode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intCaseHACode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intCaseHACode", i), filters.Value("intCaseHACode", i))));
                      
                    if (filters.Contains("idfFieldCollectedByOffice"))
                        for (int i = 0; i < filters.Count("idfFieldCollectedByOffice"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfFieldCollectedByOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfFieldCollectedByOffice", i), filters.Value("idfFieldCollectedByOffice", i))));
                      
                    if (filters.Contains("idfFieldCollectedByPerson"))
                        for (int i = 0; i < filters.Count("idfFieldCollectedByPerson"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfFieldCollectedByPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfFieldCollectedByPerson", i), filters.Value("idfFieldCollectedByPerson", i))));
                      
                    if (filters.Contains("idfsDestructionMethod"))
                        for (int i = 0; i < filters.Count("idfsDestructionMethod"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDestructionMethod_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsDestructionMethod", i), filters.Value("idfsDestructionMethod", i))));
                      
                    if (filters.Contains("strSampleNote"))
                        for (int i = 0; i < filters.Count("strSampleNote"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSampleNote_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSampleNote", i), filters.Value("strSampleNote", i))));
                      
                    if (filters.Contains("strCondition"))
                        for (int i = 0; i < filters.Count("strCondition"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCondition_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCondition", i), filters.Value("strCondition", i))));
                      
                    if (filters.Contains("idfsSampleKind"))
                        for (int i = 0; i < filters.Count("idfsSampleKind"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSampleKind_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSampleKind", i), filters.Value("idfsSampleKind", i))));
                      
                    if (filters.Contains("idfMarkedForDispositionByPerson"))
                        for (int i = 0; i < filters.Count("idfMarkedForDispositionByPerson"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfMarkedForDispositionByPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfMarkedForDispositionByPerson", i), filters.Value("idfMarkedForDispositionByPerson", i))));
                      
                    if (filters.Contains("intTestCount"))
                        for (int i = 0; i < filters.Count("intTestCount"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intTestCount_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intTestCount", i), filters.Value("intTestCount", i))));
                      
                    if (filters.Contains("idfSendToOfficeOut"))
                        for (int i = 0; i < filters.Count("idfSendToOfficeOut"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfSendToOfficeOut_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfSendToOfficeOut", i), filters.Value("idfSendToOfficeOut", i))));
                      
                    if (filters.Contains("bExternalOffice"))
                        for (int i = 0; i < filters.Count("bExternalOffice"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@bExternalOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("bExternalOffice", i), filters.Value("bExternalOffice", i))));
                      
                    if (filters.Contains("idfSendByPerson"))
                        for (int i = 0; i < filters.Count("idfSendByPerson"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfSendByPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfSendByPerson", i), filters.Value("idfSendByPerson", i))));
                      
                    if (filters.Contains("datSendDate"))
                        for (int i = 0; i < filters.Count("datSendDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datSendDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datSendDate", i), filters.Value("datSendDate", i))));
                      
                    if (filters.Contains("HumanName"))
                        for (int i = 0; i < filters.Count("HumanName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@HumanName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("HumanName", i), filters.Value("HumanName", i))));
                      
                    if (filters.Contains("strPatientName"))
                        for (int i = 0; i < filters.Count("strPatientName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strPatientName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strPatientName", i), filters.Value("strPatientName", i))));
                      
                    if (filters.Contains("strFarmOwner"))
                        for (int i = 0; i < filters.Count("strFarmOwner"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFarmOwner_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFarmOwner", i), filters.Value("strFarmOwner", i))));
                      
                    if (filters.Contains("idfsCountry"))
                        for (int i = 0; i < filters.Count("idfsCountry"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCountry_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCountry", i), filters.Value("idfsCountry", i))));
                      
                    if (filters.Contains("idfsRegion"))
                        for (int i = 0; i < filters.Count("idfsRegion"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion", i), filters.Value("idfsRegion", i))));
                      
                    if (filters.Contains("strRegion"))
                        for (int i = 0; i < filters.Count("strRegion"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strRegion", i), filters.Value("strRegion", i))));
                      
                    if (filters.Contains("idfsRayon"))
                        for (int i = 0; i < filters.Count("idfsRayon"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon", i), filters.Value("idfsRayon", i))));
                      
                    if (filters.Contains("strRayon"))
                        for (int i = 0; i < filters.Count("strRayon"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strRayon", i), filters.Value("strRayon", i))));
                      
                    if (filters.Contains("idfsSettlement"))
                        for (int i = 0; i < filters.Count("idfsSettlement"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSettlement_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSettlement", i), filters.Value("idfsSettlement", i))));
                      
                    if (filters.Contains("idfsTestName"))
                        for (int i = 0; i < filters.Count("idfsTestName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestName", i), filters.Value("idfsTestName", i))));
                      
                    if (filters.Contains("idfsTestCategory"))
                        for (int i = 0; i < filters.Count("idfsTestCategory"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestCategory_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestCategory", i), filters.Value("idfsTestCategory", i))));
                      
                    if (filters.Contains("idfsTestStatus"))
                        for (int i = 0; i < filters.Count("idfsTestStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestStatus", i), filters.Value("idfsTestStatus", i))));
                      
                    if (filters.Contains("idfsTestResult"))
                        for (int i = 0; i < filters.Count("idfsTestResult"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestResult_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestResult", i), filters.Value("idfsTestResult", i))));
                      
                    if (filters.Contains("datStartedDate"))
                        for (int i = 0; i < filters.Count("datStartedDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datStartedDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datStartedDate", i), filters.Value("datStartedDate", i))));
                      
                    if (filters.Contains("datConcludedDate"))
                        for (int i = 0; i < filters.Count("datConcludedDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datConcludedDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datConcludedDate", i), filters.Value("datConcludedDate", i))));
                      
                    if (filters.Contains("idfObservation"))
                        for (int i = 0; i < filters.Count("idfObservation"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfObservation_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfObservation", i), filters.Value("idfObservation", i))));
                      
                    if (filters.Contains("strNote"))
                        for (int i = 0; i < filters.Count("strNote"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strNote_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strNote", i), filters.Value("strNote", i))));
                      
                    if (filters.Contains("idfTestedByOffice"))
                        for (int i = 0; i < filters.Count("idfTestedByOffice"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfTestedByOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfTestedByOffice", i), filters.Value("idfTestedByOffice", i))));
                      
                    if (filters.Contains("idfTestedByPerson"))
                        for (int i = 0; i < filters.Count("idfTestedByPerson"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfTestedByPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfTestedByPerson", i), filters.Value("idfTestedByPerson", i))));
                      
                    if (filters.Contains("idfResultEnteredByOffice"))
                        for (int i = 0; i < filters.Count("idfResultEnteredByOffice"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfResultEnteredByOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfResultEnteredByOffice", i), filters.Value("idfResultEnteredByOffice", i))));
                      
                    if (filters.Contains("idfResultEnteredByPerson"))
                        for (int i = 0; i < filters.Count("idfResultEnteredByPerson"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfResultEnteredByPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfResultEnteredByPerson", i), filters.Value("idfResultEnteredByPerson", i))));
                      
                    if (filters.Contains("idfValidatedByOffice"))
                        for (int i = 0; i < filters.Count("idfValidatedByOffice"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfValidatedByOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfValidatedByOffice", i), filters.Value("idfValidatedByOffice", i))));
                      
                    if (filters.Contains("idfValidatedByPerson"))
                        for (int i = 0; i < filters.Count("idfValidatedByPerson"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfValidatedByPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfValidatedByPerson", i), filters.Value("idfValidatedByPerson", i))));
                      
                    if (filters.Contains("blnNonLaboratoryTest"))
                        for (int i = 0; i < filters.Count("blnNonLaboratoryTest"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@blnNonLaboratoryTest_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("blnNonLaboratoryTest", i), filters.Value("blnNonLaboratoryTest", i))));
                      
                    if (filters.Contains("blnExternalTest"))
                        for (int i = 0; i < filters.Count("blnExternalTest"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@blnExternalTest_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("blnExternalTest", i), filters.Value("blnExternalTest", i))));
                      
                    if (filters.Contains("datReceivedDate"))
                        for (int i = 0; i < filters.Count("datReceivedDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datReceivedDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datReceivedDate", i), filters.Value("datReceivedDate", i))));
                      
                    if (filters.Contains("idfPerformedByOffice"))
                        for (int i = 0; i < filters.Count("idfPerformedByOffice"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfPerformedByOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfPerformedByOffice", i), filters.Value("idfPerformedByOffice", i))));
                      
                    if (filters.Contains("strContactPerson"))
                        for (int i = 0; i < filters.Count("strContactPerson"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strContactPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strContactPerson", i), filters.Value("strContactPerson", i))));
                      
                    if (filters.Contains("idfsFormTemplate"))
                        for (int i = 0; i < filters.Count("idfsFormTemplate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsFormTemplate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsFormTemplate", i), filters.Value("idfsFormTemplate", i))));
                      
                    if (filters.Contains("strBatchID"))
                        for (int i = 0; i < filters.Count("strBatchID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strBatchID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strBatchID", i), filters.Value("strBatchID", i))));
                      
                    if (filters.Contains("strSampleStatus"))
                        for (int i = 0; i < filters.Count("strSampleStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSampleStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSampleStatus", i), filters.Value("strSampleStatus", i))));
                      
                    if (filters.Contains("strSampleName"))
                        for (int i = 0; i < filters.Count("strSampleName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSampleName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSampleName", i), filters.Value("strSampleName", i))));
                      
                    if (filters.Contains("strSampleConditionReceivedStatus"))
                        for (int i = 0; i < filters.Count("strSampleConditionReceivedStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSampleConditionReceivedStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSampleConditionReceivedStatus", i), filters.Value("strSampleConditionReceivedStatus", i))));
                      
                    if (filters.Contains("strTestName"))
                        for (int i = 0; i < filters.Count("strTestName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strTestName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strTestName", i), filters.Value("strTestName", i))));
                      
                    if (filters.Contains("strTestStatus"))
                        for (int i = 0; i < filters.Count("strTestStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strTestStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strTestStatus", i), filters.Value("strTestStatus", i))));
                      
                    if (filters.Contains("strTestResult"))
                        for (int i = 0; i < filters.Count("strTestResult"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strTestResult_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strTestResult", i), filters.Value("strTestResult", i))));
                      
                    if (filters.Contains("strTestCategory"))
                        for (int i = 0; i < filters.Count("strTestCategory"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strTestCategory_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strTestCategory", i), filters.Value("strTestCategory", i))));
                      
                    if (filters.Contains("idfsLaboratorySection"))
                        for (int i = 0; i < filters.Count("idfsLaboratorySection"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsLaboratorySection_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsLaboratorySection", i), filters.Value("idfsLaboratorySection", i))));
                      
                    if (filters.Contains("bTestDeleted"))
                        for (int i = 0; i < filters.Count("bTestDeleted"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@bTestDeleted_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("bTestDeleted", i), filters.Value("bTestDeleted", i))));
                      
                    if (filters.Contains("bTestInserted"))
                        for (int i = 0; i < filters.Count("bTestInserted"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@bTestInserted_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("bTestInserted", i), filters.Value("bTestInserted", i))));
                      
                    if (filters.Contains("bTestInsertedFirst"))
                        for (int i = 0; i < filters.Count("bTestInsertedFirst"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@bTestInsertedFirst_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("bTestInsertedFirst", i), filters.Value("bTestInsertedFirst", i))));
                      
                    if (filters.Contains("bFilterTestByDiagnosis"))
                        for (int i = 0; i < filters.Count("bFilterTestByDiagnosis"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@bFilterTestByDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("bFilterTestByDiagnosis", i), filters.Value("bFilterTestByDiagnosis", i))));
                      
                    if (filters.Contains("intNewSample"))
                        for (int i = 0; i < filters.Count("intNewSample"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intNewSample_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intNewSample", i), filters.Value("intNewSample", i))));
                      
                    if (filters.Contains("idfsSampleTypeFiltered"))
                        for (int i = 0; i < filters.Count("idfsSampleTypeFiltered"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSampleTypeFiltered_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSampleTypeFiltered", i), filters.Value("idfsSampleTypeFiltered", i))));
                      
                    if (filters.Contains("strComments"))
                        for (int i = 0; i < filters.Count("strComments"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strComments_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strComments", i), filters.Value("strComments", i))));
                      
                    if (filters.Contains("strReason"))
                        for (int i = 0; i < filters.Count("strReason"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strReason_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strReason", i), filters.Value("strReason", i))));
                      
                    List<LaboratorySectionItem> objs = manager.ExecuteList<LaboratorySectionItem>();
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
            partial void ListSelected(DbManagerProxy manager, List<LaboratorySectionItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return null;
                    
            }
        
            private void _SetupAddChildHandlerSample(LaboratorySectionItem obj)
            {
                obj.Sample.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerTest(LaboratorySectionItem obj)
            {
                obj.Test.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerAmendmentHistory(LaboratorySectionItem obj)
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
            
            internal void _LoadSample(LaboratorySectionItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSample(manager, obj);
                }
            }
            internal void _LoadSample(DbManagerProxy manager, LaboratorySectionItem obj)
            {
              
              }
            
            internal void _LoadTest(LaboratorySectionItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadTest(manager, obj);
                }
            }
            internal void _LoadTest(DbManagerProxy manager, LaboratorySectionItem obj)
            {
              
              }
            
            internal void _LoadAmendmentHistory(LaboratorySectionItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadAmendmentHistory(manager, obj);
                }
            }
            internal void _LoadAmendmentHistory(DbManagerProxy manager, LaboratorySectionItem obj)
            {
              
                obj.AmendmentHistory.Clear();
                obj.AmendmentHistory.AddRange(AmendmentHistoryAccessor.SelectDetailList(manager
                    
                    , obj.idfTesting.HasValue ? obj.idfTesting.Value : 0
                    ));
                obj.AmendmentHistory.ForEach(c => c.m_ObjectName = _str_AmendmentHistory);
                obj.AmendmentHistory.AcceptChanges();
                    
              }
            
            internal void _LoadFFPresenter(LaboratorySectionItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFFPresenter(manager, obj);
                }
            }
            internal void _LoadFFPresenter(DbManagerProxy manager, LaboratorySectionItem obj)
            {
              
                if (obj.FFPresenter == null && obj.idfObservation != null && obj.idfObservation != 0)
                {
                    obj.FFPresenter = FFPresenterAccessor.SelectByKey(manager
                        
                        , obj.idfObservation.Value
                        );
                    if (obj.FFPresenter != null)
                    {
                        obj.FFPresenter.m_ObjectName = _str_FFPresenter;
                    }
                }
                    
              }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, LaboratorySectionItem obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadSample(manager, obj);
                _LoadTest(manager, obj);
                _LoadAmendmentHistory(manager, obj);
                _LoadFFPresenter(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.TestStatusShort = new Func<LaboratorySectionItem, BaseReference>(c => c.TestStatusShortLookup.FirstOrDefault(i => i.idfsBaseReference == c.idfsTestStatus))(obj);
              if (obj.idfsFormTemplate.HasValue) obj.FFPresenter.SetProperties(obj.idfsFormTemplate.Value, obj.ID);
            
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerSample(obj);
                
                _SetupAddChildHandlerTest(obj);
                
                _SetupAddChildHandlerAmendmentHistory(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, LaboratorySectionItem obj)
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

    

            private LaboratorySectionItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    LaboratorySectionItem obj = LaboratorySectionItem.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfsCountry = new Func<LaboratorySectionItem, long?>(c => eidss.model.Core.EidssSiteContext.Instance.CountryID)(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerSample(obj);
                    
                    _SetupAddChildHandlerTest(obj);
                    
                    _SetupAddChildHandlerAmendmentHistory(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.m_bSetupLoaded = new Func<LaboratorySectionItem, bool>(c => true)(obj);
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

            
            public LaboratorySectionItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public LaboratorySectionItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public LaboratorySectionItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public LaboratorySectionItem CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                return Create(manager, Parent
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public LaboratorySectionItem Create(DbManagerProxy manager, IObject Parent
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfMaterial = (new GetNewIDExtender<LaboratorySectionItem>()).GetScalar(manager, obj);
                obj.ID = new Func<LaboratorySectionItem, long>(c => c.idfMaterial)(obj);
                obj.idfRootMaterial = new Func<LaboratorySectionItem, long?>(c => c.idfMaterial)(obj);
                obj.idfObservation = (new GetNewIDExtender<LaboratorySectionItem>()).GetScalar(manager, obj);
                }
                    , obj =>
                {
                obj.AccessionCondition = new Func<LaboratorySectionItem, BaseReference>(c => c.AccessionConditionLookup.FirstOrDefault(i => i.idfsBaseReference == (long)AccessionConditionEnum.AcceptedInGoodCondition))(obj);
                obj.strBarcode = new Func<LaboratorySectionItem, DbManagerProxy, string>((c,m) => m.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.Sample, DBNull.Value, DBNull.Value).ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue"))(obj, manager);
                }
                );
            }
            
            public LaboratorySectionItem CreateWithNewModeT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 10) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is LabNewModeEnum)) 
                    throw new TypeMismatchException("intNewMode", typeof(LabNewModeEnum));
                if (pars[1] != null && !(pars[1] is long)) 
                    throw new TypeMismatchException("idfsSampleType", typeof(long));
                if (pars[2] != null && !(pars[2] is long?)) 
                    throw new TypeMismatchException("idfsTestName", typeof(long?));
                if (pars[3] != null && !(pars[3] is long?)) 
                    throw new TypeMismatchException("idfCaseOrSession", typeof(long?));
                if (pars[4] != null && !(pars[4] is long?)) 
                    throw new TypeMismatchException("idfsCaseType", typeof(long?));
                if (pars[5] != null && !(pars[5] is int?)) 
                    throw new TypeMismatchException("intCaseHACode", typeof(int?));
                if (pars[6] != null && !(pars[6] is long?)) 
                    throw new TypeMismatchException("idfsOldTestResult", typeof(long?));
                if (pars[7] != null && !(pars[7] is DateTime?)) 
                    throw new TypeMismatchException("datSendDate", typeof(DateTime?));
                if (pars[8] != null && !(pars[8] is long)) 
                    throw new TypeMismatchException("idfMaterial", typeof(long));
                if (pars[9] != null && !(pars[9] is long?)) 
                    throw new TypeMismatchException("idfsShowDiagnosis", typeof(long?));
                
                return CreateWithNewMode(manager, Parent
                    , (LabNewModeEnum)pars[0]
                    , (long)pars[1]
                    , (long?)pars[2]
                    , (long?)pars[3]
                    , (long?)pars[4]
                    , (int?)pars[5]
                    , (long?)pars[6]
                    , (DateTime?)pars[7]
                    , (long)pars[8]
                    , (long?)pars[9]
                    );
            }
            public IObject CreateWithNewMode(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateWithNewModeT(manager, Parent, pars);
            }
            public LaboratorySectionItem CreateWithNewMode(DbManagerProxy manager, IObject Parent
                , LabNewModeEnum intNewMode
                , long idfsSampleType
                , long? idfsTestName
                , long? idfCaseOrSession
                , long? idfsCaseType
                , int? intCaseHACode
                , long? idfsOldTestResult = null
                , DateTime? datSendDate = null
                , long idfMaterial = 0
                , long? idfsShowDiagnosis = null
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.ID = (new GetNewIDExtender<LaboratorySectionItem>()).GetScalar(manager, obj);
                obj.intCaseHACode = new Func<LaboratorySectionItem, int>(c => 0)(obj);
                obj.intNewMode = new Func<LaboratorySectionItem, LabNewModeEnum>(c => intNewMode)(obj);
                obj.intNewSample = new Func<LaboratorySectionItem, int>(c => 1)(obj);
                obj.idfsSampleType = new Func<LaboratorySectionItem, long>(c => idfsSampleType)(obj);
                obj.idfsTestName = new Func<LaboratorySectionItem, long?>(c => idfsTestName)(obj);
                obj.idfCaseOrSession = new Func<LaboratorySectionItem, long?>(c => idfCaseOrSession)(obj);
                obj.idfsCaseType = new Func<LaboratorySectionItem, long?>(c => idfsCaseType)(obj);
                obj.intCaseHACode = new Func<LaboratorySectionItem, int?>(c => intCaseHACode)(obj);
                obj.idfsOldTestResult = new Func<LaboratorySectionItem, long?>(c => idfsOldTestResult)(obj);
                obj.datSendDate = new Func<LaboratorySectionItem, DateTime?>(c => datSendDate)(obj);
                obj.idfMaterial = new Func<LaboratorySectionItem, long>(c => idfMaterial)(obj);
                obj.idfsDiagnosis = new Func<LaboratorySectionItem, long?>(c => idfsShowDiagnosis)(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            public LaboratorySectionItem CreateSampleFromT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 2) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is LaboratorySectionItem)) 
                    throw new TypeMismatchException("from", typeof(LaboratorySectionItem));
                if (pars[1] != null && !(pars[1] is string)) 
                    throw new TypeMismatchException("numberType", typeof(string));
                
                return CreateSampleFrom(manager, Parent
                    , (LaboratorySectionItem)pars[0]
                    , (string)pars[1]
                    );
            }
            public IObject CreateSampleFrom(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateSampleFromT(manager, Parent, pars);
            }
            public LaboratorySectionItem CreateSampleFrom(DbManagerProxy manager, IObject Parent
                , LaboratorySectionItem from
                , string numberType
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfMaterial = (new GetNewIDExtender<LaboratorySectionItem>()).GetScalar(manager, obj);
                obj.ID = new Func<LaboratorySectionItem, long>(c => c.idfMaterial)(obj);
                obj.idfsSampleType = new Func<LaboratorySectionItem, long>(c => from.idfsSampleType)(obj);
                obj.strSampleName = new Func<LaboratorySectionItem, string>(c => from.strSampleName)(obj);
                obj.idfRootMaterial = new Func<LaboratorySectionItem, long?>(c => from.idfRootMaterial)(obj);
                obj.idfParentMaterial = new Func<LaboratorySectionItem, long?>(c => from.idfMaterial)(obj);
                obj.strParentMaterial = new Func<LaboratorySectionItem, string>(c => from.strBarcode)(obj);
                obj.idfHuman = new Func<LaboratorySectionItem, long?>(c => from.idfHuman)(obj);
                obj.idfSpecies = new Func<LaboratorySectionItem, long?>(c => from.idfSpecies)(obj);
                obj.idfAnimal = new Func<LaboratorySectionItem, long?>(c => from.idfAnimal)(obj);
                obj.idfHumanCase = new Func<LaboratorySectionItem, long?>(c => from.idfHumanCase)(obj);
                obj.idfVetCase = new Func<LaboratorySectionItem, long?>(c => from.idfVetCase)(obj);
                obj.idfMonitoringSession = new Func<LaboratorySectionItem, long?>(c => from.idfMonitoringSession)(obj);
                obj.idfsDiagnosis = new Func<LaboratorySectionItem, long?>(c => from.idfsDiagnosis)(obj);
                obj.idfFieldCollectedByPerson = new Func<LaboratorySectionItem, long?>(c => from.idfFieldCollectedByPerson)(obj);
                obj.idfFieldCollectedByOffice = new Func<LaboratorySectionItem, long?>(c => from.idfFieldCollectedByOffice)(obj);
                obj.idfMainTest = new Func<LaboratorySectionItem, long?>(c => from.idfMainTest)(obj);
                obj.datFieldCollectionDate = new Func<LaboratorySectionItem, DateTime?>(c => from.datFieldCollectionDate)(obj);
                obj.datFieldSentDate = new Func<LaboratorySectionItem, DateTime?>(c => from.datFieldSentDate)(obj);
                obj.strFieldBarcode = new Func<LaboratorySectionItem, string>(c => from.strFieldBarcode)(obj);
                obj.strCalculatedCaseID = new Func<LaboratorySectionItem, string>(c => from.strCalculatedCaseID)(obj);
                obj.strCalculatedHumanName = new Func<LaboratorySectionItem, string>(c => from.strCalculatedHumanName)(obj);
                obj.HumanName = new Func<LaboratorySectionItem, string>(c => from.HumanName)(obj);
                obj.strRegion = new Func<LaboratorySectionItem, string>(c => from.strRegion)(obj);
                obj.strRayon = new Func<LaboratorySectionItem, string>(c => from.strRayon)(obj);
                obj.idfVectorSurveillanceSession = new Func<LaboratorySectionItem, long?>(c => from.idfVectorSurveillanceSession)(obj);
                obj.idfVector = new Func<LaboratorySectionItem, long?>(c => from.idfVector)(obj);
                obj.idfSubdivision = new Func<LaboratorySectionItem, long?>(c => from.idfSubdivision)(obj);
                obj.idfsSampleStatus = new Func<LaboratorySectionItem, long>(c => (long)eidss.model.Enums.SampleStatus.Accessioned)(obj);
                obj.strSampleStatus = new Func<LaboratorySectionItem, string>(c => from.strSampleStatus)(obj);
                obj.idfInDepartment = new Func<LaboratorySectionItem, long?>(c => from.idfInDepartment)(obj);
                obj.idfDestroyedByPerson = new Func<LaboratorySectionItem, long?>(c => from.idfDestroyedByPerson)(obj);
                obj.datAccession = new Func<LaboratorySectionItem, DateTime?>(c => DateTime.Today)(obj);
                obj.idfsAccessionCondition = new Func<LaboratorySectionItem, long?>(c => from.idfsAccessionCondition)(obj);
                obj.strSampleConditionReceivedStatus = new Func<LaboratorySectionItem, string>(c => from.strSampleConditionReceivedStatus)(obj);
                obj.idfAccesionByPerson = new Func<LaboratorySectionItem, long?>(c => from.idfAccesionByPerson)(obj);
                obj.datEnteringDate = new Func<LaboratorySectionItem, DateTime?>(c => from.datEnteringDate)(obj);
                obj.datDestructionDate = new Func<LaboratorySectionItem, DateTime?>(c => from.datDestructionDate)(obj);
                obj.idfsDestructionMethod = new Func<LaboratorySectionItem, long?>(c => from.idfsDestructionMethod)(obj);
                obj.strBarcode = new Func<LaboratorySectionItem, string>(c => "(new" + ++(from.Parent as LaboratorySectionMaster).newCounter + ")")(obj);
                obj.strSampleNote = new Func<LaboratorySectionItem, string>(c => from.strSampleNote)(obj);
                obj.strCondition = new Func<LaboratorySectionItem, string>(c => from.strCondition)(obj);
                obj.idfsCaseType = new Func<LaboratorySectionItem, long?>(c => from.idfsCaseType)(obj);
                obj.idfSpeciesVectorInfo = new Func<LaboratorySectionItem, long?>(c => from.idfSpeciesVectorInfo)(obj);
                obj.idfCaseOrSession = new Func<LaboratorySectionItem, long?>(c => from.idfCaseOrSession)(obj);
                obj.intTestCount = new Func<LaboratorySectionItem, int>(c => 0)(obj);
                obj.idfSendToOffice = new Func<LaboratorySectionItem, long?>(c => from.idfSendToOffice)(obj);
                obj.idfObservation = (new GetNewIDExtender<LaboratorySectionItem>()).GetScalar(manager, obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            public ActResult OK(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return OK(manager, obj
                    );
            }
            public ActResult OK(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("OK"))
                    throw new PermissionException("Sample", "OK");
                
              obj.SetupLoad(manager);
              return (obj.GetAccessor() as IObjectValidator).Validate(manager, obj, true, true, true);
            
            }
            
      
            public ActResult ItemCreate(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                if (pars.Count != 5) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is int)) 
                    throw new TypeMismatchException("count", typeof(int));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("parent", typeof(IObject));
                if (pars[2] != null && !(pars[2] is LaboratorySectionItem)) 
                    throw new TypeMismatchException("sample", typeof(LaboratorySectionItem));
                if (pars[3] != null && !(pars[3] is long?)) 
                    throw new TypeMismatchException("idfsSampleType", typeof(long?));
                if (pars[4] != null && !(pars[4] is bool)) 
                    throw new TypeMismatchException("bIsMyPref", typeof(bool));
                
                return ItemCreate(manager, obj
                    , (int)pars[0]
                    , (IObject)pars[1]
                    , (LaboratorySectionItem)pars[2]
                    , (long?)pars[3]
                    , (bool)pars[4]
                    );
            }
            public ActResult ItemCreate(DbManagerProxy manager, LaboratorySectionItem obj
                , int count
                , IObject parent
                , LaboratorySectionItem sample
                , long? idfsSampleType
                , bool bIsMyPref
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ItemCreate"))
                    throw new PermissionException("Sample", "ItemCreate");
                
                obj.SetupLoad(manager);
                var check = (obj.GetAccessor() as IObjectValidator).Validate(manager, obj, true, true, true);
                if (!check)
                    return new ActResult(false, obj);

                for (int i = 0; i < count; i++)
                  {
                      var o = Create(manager, parent);
                      o.ID = o.idfMaterial;
                      o.strCalculatedCaseID = sample.strCalculatedCaseID;
                      o.HumanName = sample.HumanName;
                      o.strRegion = sample.strRegion;
                      o.strRayon = sample.strRayon;
                      o.idfHumanCase = sample.idfHumanCase;
                      o.idfVetCase = sample.idfVetCase;
                      o.idfMonitoringSession = sample.idfMonitoringSession;
                      o.idfVectorSurveillanceSession = sample.idfVectorSurveillanceSession;
                      o.intCaseHACode = sample.intCaseHACode;
                      o.idfCaseOrSession = sample.idfCaseOrSession;
                      o.idfHuman = sample.idfHuman;
                      o.SpeciesVectorInfo = o.SpeciesVectorInfoLookup.SingleOrDefault(c => c.idfSpeciesVectorInfo == sample.idfSpeciesVectorInfo);
                      o.CaseType = o.CaseTypeLookup.SingleOrDefault(c => c.idfsBaseReference == sample.idfsCaseType);
                      o.DiagnosisForTest = o.DiagnosisForTestLookup.SingleOrDefault(c => c.idfsDiagnosis == sample.idfsDiagnosis);
                      o.SampleType = o.SampleTypeLookup.SingleOrDefault(c => c.idfsBaseReference == idfsSampleType);
                      o.intTestCount = 0;
                      o.AccessionCondition = o.AccessionConditionLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.AccessionConditionEnum.AcceptedInGoodCondition);
                      o.datFieldCollectionDate = DateTime.Today;
                      o.SendToOffice = obj.SendToOfficeLookup.FirstOrDefault(c => c.idfInstitution == (long)EidssUserContext.User.OrganizationID);
                      o.bIsCreateNewSample = true;
                      o.Sample.Add(o);
                      o.Test.Add(o);
                      o.bIsMyPref = bIsMyPref;
                      if (bIsMyPref)
                          (parent as LaboratorySectionMaster).LaboratorySectionMyPrefItems.Add(o);
                      else
                          (parent as LaboratorySectionMaster).LaboratorySectionItems.Add(o);
                  }
                sample.intNewSample = 1;
                sample.SampleTypeFiltered = null;
                return new ActResult(true, obj);
            
            }
            
      
            public ActResult ItemGroupAccessionIn(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                if (pars.Count != 2) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is IObject)) 
                    throw new TypeMismatchException("parent", typeof(IObject));
                if (pars[1] != null && !(pars[1] is bool)) 
                    throw new TypeMismatchException("bIsMyPref", typeof(bool));
                
                return ItemGroupAccessionIn(manager, obj
                    , (IObject)pars[0]
                    , (bool)pars[1]
                    );
            }
            public ActResult ItemGroupAccessionIn(DbManagerProxy manager, LaboratorySectionItem obj
                , IObject parent
                , bool bIsMyPref
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ItemGroupAccessionIn"))
                    throw new PermissionException("Sample", "ItemGroupAccessionIn");
                
                obj.SetupLoad(manager);
                var check = (obj.GetAccessor() as IObjectValidator).Validate(manager, obj, true, true, true);
                if (!check)
                    return new ActResult(false, obj);
                    
                var pop = manager.SetSpCommand("dbo.spLaboratorySection_GetByFieldBarcode", obj.strFieldBarcode, ModelUserContext.CurrentLanguage).ExecuteList<LaboratorySectionItem>();
                foreach (LaboratorySectionItem o in pop)
                {
                    EditableList<LaboratorySectionItem> list;
                    if (bIsMyPref)
                        list = (parent as LaboratorySectionMaster).LaboratorySectionMyPrefItems;
                    else
                        list = (parent as LaboratorySectionMaster).LaboratorySectionItems;
                    var oldObj = list.SingleOrDefault(c => c.ID == o.ID);
                    if (oldObj != null)
                    {
                        oldObj.AccessionCondition = oldObj.AccessionConditionLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.AccessionConditionEnum.AcceptedInGoodCondition);
                    }
                    else
                    {
                        _SetupLoad(manager, o);
                        o.Parent = parent;
                        o.AccessionCondition = o.AccessionConditionLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.AccessionConditionEnum.AcceptedInGoodCondition);
                        o.Sample.Add(o);
                        o.Test.Add(o);
                        o.bIsMyPref = bIsMyPref;
                        list.Add(o);
                    }
                }
                obj.strFieldBarcode = "";
                return new ActResult(true, obj);
            
            }
            
      
            public ActResult ItemAssignTest(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is List<IObject>)) 
                    throw new TypeMismatchException("selected", typeof(List<IObject>));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("parent", typeof(IObject));
                if (pars[2] != null && !(pars[2] is bool)) 
                    throw new TypeMismatchException("bIsMyPref", typeof(bool));
                
                return ItemAssignTest(manager, obj
                    , (List<IObject>)pars[0]
                    , (IObject)pars[1]
                    , (bool)pars[2]
                    );
            }
            public ActResult ItemAssignTest(DbManagerProxy manager, LaboratorySectionItem obj
                , List<IObject> selected
                , IObject parent
                , bool bIsMyPref
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ItemAssignTest"))
                    throw new PermissionException("Sample", "ItemAssignTest");
                
                obj.SetupLoad(manager);
                var check = (obj.GetAccessor() as IObjectValidator).Validate(manager, obj, true, true, true);
                if (!check)
                    return new ActResult(false, obj);

                foreach (var i in selected.Cast<LaboratorySectionItem>().Distinct(new LaboratorySectionItemSamplesComparator()).ToList())
                {
                    i.SetupLoad(manager);
                    i.intTestCount++;
                    LaboratorySectionItem o;
                    if (i.idfTesting.HasValue)
                    {
                        o = i.CloneWithSetup(manager) as LaboratorySectionItem;
                        o.Sample.Clear();
                        o.Test.Clear();
                        o.Sample.Add(o);
                        o.Test.Add(o);
                        o.bTestInserted = true;
                        o.bIsMyPref = bIsMyPref;
                        if (bIsMyPref)
                            (parent as LaboratorySectionMaster).LaboratorySectionMyPrefItems.Add(o);
                        else
                            (parent as LaboratorySectionMaster).LaboratorySectionItems.Add(o);
                    }
                    else
                    {
                        o = i;
                        o.bTestInsertedFirst = true;
                    }

                    o.idfTesting = (new GetNewIDExtender<LaboratorySectionItem>()).GetScalar(manager, obj);
                    o.ID = o.idfTesting.Value;
                    o.Diagnosis = o.DiagnosisLookup.FirstOrDefault(j => j.idfsDiagnosis == obj.idfsDiagnosis);
                    o.DiagnosisForTest = o.DiagnosisForTestLookup.FirstOrDefault(j => j.idfsDiagnosis == obj.idfsDiagnosis);
                    o.TestNameRef = o.TestNameRefLookup.FirstOrDefault(j => j.idfsReference == obj.idfsTestName);
                    o.TestResultRef = o.TestResultRefLookup.FirstOrDefault(j => j.idfsReference == obj.idfsTestResult);
                    o.TestCategoryRef = o.TestCategoryRefLookup.FirstOrDefault(j => j.idfsBaseReference == obj.idfsTestCategory);
                    o.TestStatusFull = o.TestStatusFullLookup.FirstOrDefault(j => j.idfsBaseReference == (obj.idfsTestResult.HasValue ? (long)eidss.model.Enums.TestStatus.Preliminary : (long)eidss.model.Enums.TestStatus.NotStarted));
                    //o.datStartedDate = obj.datStartedDate;
                    //o.datConcludedDate = obj.datConcludedDate;
                    o.idfObservation = (new GetNewIDExtender<LaboratorySectionItem>()).GetScalar(manager, obj);
                    o.FFPresenter = FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, o.idfObservation);
                    o.FFPresenter.SetProperties(EidssSiteContext.Instance.CountryID, o.idfsTestName, FFTypeEnum.TestDetails, o.idfObservation.Value, o.ID);
                    if (o.FFPresenter.CurrentTemplate != null) o.idfsFormTemplate = o.FFPresenter.CurrentTemplate.idfsFormTemplate;
                }
                if (obj.intNewMode == LabNewModeEnum.AssignTest)
                {
                    obj.TestNameRef = null;
                    obj.TestResultRef = null;
                    obj.TestCategoryRef = null;
                }
                return new ActResult(true, obj);
            
            }
            
      
            public ActResult ItemCancel(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return ItemCancel(manager, obj
                    );
            }
            public ActResult ItemCancel(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ItemCancel"))
                    throw new PermissionException("Sample", "ItemCancel");
                
                return true;
                
            }
            
      
            public ActResult ItemClose(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return ItemClose(manager, obj
                    );
            }
            public ActResult ItemClose(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ItemClose"))
                    throw new PermissionException("Sample", "ItemClose");
                
                return true;
                
            }
            
      
            public ActResult CreateSample(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return CreateSample(manager, obj
                    );
            }
            public ActResult CreateSample(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("CreateSample"))
                    throw new PermissionException("Sample", "CreateSample");
                
                return true;
                
            }
            
      
            public ActResult GroupAccessionIn(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return GroupAccessionIn(manager, obj
                    );
            }
            public ActResult GroupAccessionIn(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("GroupAccessionIn"))
                    throw new PermissionException("Sample", "GroupAccessionIn");
                
                return true;
                
            }
            
      
            public ActResult MenuAccessionIn(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuAccessionIn(manager, obj
                    );
            }
            public ActResult MenuAccessionIn(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuAccessionIn"))
                    throw new PermissionException("Sample", "MenuAccessionIn");
                
                return true;
                
            }
            
      
            public ActResult MenuAccessionInGoodCondition(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuAccessionInGoodCondition(manager, obj
                    );
            }
            public ActResult MenuAccessionInGoodCondition(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuAccessionInGoodCondition"))
                    throw new PermissionException("Sample", "MenuAccessionInGoodCondition");
                
                  obj.SetupLoad(manager);
                  obj.AccessionCondition = obj.AccessionConditionLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.AccessionConditionEnum.AcceptedInGoodCondition);
                  return true;
                
            }
            
      
            public ActResult MenuAccessionInPoorCondition(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is string)) 
                    throw new TypeMismatchException("strComments", typeof(string));
                
                return MenuAccessionInPoorCondition(manager, obj
                    , (string)pars[0]
                    );
            }
            public ActResult MenuAccessionInPoorCondition(DbManagerProxy manager, LaboratorySectionItem obj
                , string strComments
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuAccessionInPoorCondition"))
                    throw new PermissionException("Sample", "MenuAccessionInPoorCondition");
                
                  obj.SetupLoad(manager);
                  obj.AccessionCondition = obj.AccessionConditionLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.AccessionConditionEnum.AcceptedInPoorCondition);
                  obj.strCondition = strComments;
                  return true;
                
            }
            
      
            public ActResult MenuAccessionInRejected(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is string)) 
                    throw new TypeMismatchException("strComments", typeof(string));
                
                return MenuAccessionInRejected(manager, obj
                    , (string)pars[0]
                    );
            }
            public ActResult MenuAccessionInRejected(DbManagerProxy manager, LaboratorySectionItem obj
                , string strComments
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuAccessionInRejected"))
                    throw new PermissionException("Sample", "MenuAccessionInRejected");
                
                  obj.SetupLoad(manager);
                  obj.AccessionCondition = obj.AccessionConditionLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.AccessionConditionEnum.Rejected);
                  obj.strCondition = strComments;
                  return true;
                
            }
            
      
            public ActResult MenuAssignTest(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuAssignTest(manager, obj
                    );
            }
            public ActResult MenuAssignTest(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuAssignTest"))
                    throw new PermissionException("Sample", "MenuAssignTest");
                
              obj.SetupLoad(manager);
              return true;
            
            }
            
      
            public ActResult MenuExternalTestResult(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuExternalTestResult(manager, obj
                    );
            }
            public ActResult MenuExternalTestResult(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuExternalTestResult"))
                    throw new PermissionException("Sample", "MenuExternalTestResult");
                
              obj.SetupLoad(manager);
              obj.intTestCount++;
              LaboratorySectionItem o;
              if (obj.idfTesting.HasValue)
              {
                  o = obj.CloneWithSetup(manager) as LaboratorySectionItem;
                  o.Sample.Clear();
                  o.Test.Clear();
                  o.Sample.Add(o);
                  o.Test.Add(o);
                  o.SampleStatus = o.SampleStatusLookup.FirstOrDefault(c => c.idfsBaseReference == obj.idfsSampleStatus);
                  o.SampleStatusFull = o.SampleStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == obj.idfsSampleStatus);
                  o.bTestInserted = true;
                  
                  o.LockNotifyChanges();
                  o.blnExternalTest = true;
                  o.UnlockNotifyChanges();
                  
                  o.bIsMyPref = obj.bIsMyPref;
                  if (obj.bIsMyPref)
                      (obj.Parent as LaboratorySectionMaster).LaboratorySectionMyPrefItems.Add(o);
                  else
                      (obj.Parent as LaboratorySectionMaster).LaboratorySectionItems.Add(o);
              }
              else
              {
                  o = obj;
                  o.bTestInsertedFirst = true;
                  if (/*!o.blnExternalTest.HasValue || */!o.blnExternalTest/*.Value*/)
                  {
                      obj.intTestCount--;
                      o.blnExternalTest = true;
                      return true;
                  }
              }

              o.idfTesting = (new GetNewIDExtender<LaboratorySectionItem>()).GetScalar(manager, obj);
              o.ID = o.idfTesting.Value;
              o.idfPerformedByOffice = o.idfSendToOfficeOut;
              o.datStartedDate = DateTime.Today;
              o.datReceivedDate = DateTime.Today;
              o.datConcludedDate = DateTime.Today;
              o.TestStatusFull = o.TestStatusFullLookup.FirstOrDefault(j => j.idfsBaseReference == (long)eidss.model.Enums.TestStatus.Finalized);
              //o.Diagnosis = null;
              o.TestNameRef = null;
              o.TestResultRef = null;
              o.TestCategoryRef = null;
              o.TestedByOffice = o.TestedByOfficeLookup.FirstOrDefault(l => l.idfInstitution == (long)EidssUserContext.User.OrganizationID);
              o.TestedByPerson = null;
              o.ValidatedByOffice = null;
              o.ValidatedByPerson = null;
              o.strContactPerson = null;
              o.idfObservation = (new GetNewIDExtender<LaboratorySectionItem>()).GetScalar(manager, obj);
              o.FFPresenter = FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, o.idfObservation);
              o.FFPresenter.SetProperties(EidssSiteContext.Instance.CountryID, o.idfsTestName, FFTypeEnum.TestDetails, o.idfObservation.Value, o.ID);
              if (o.FFPresenter.CurrentTemplate != null) o.idfsFormTemplate = o.FFPresenter.CurrentTemplate.idfsFormTemplate;

              return true;
            
            }
            
      
            public ActResult MenuCreateAliquot(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is int)) 
                    throw new TypeMismatchException("count", typeof(int));
                
                return MenuCreateAliquot(manager, obj
                    , (int)pars[0]
                    );
            }
            public ActResult MenuCreateAliquot(DbManagerProxy manager, LaboratorySectionItem obj
                , int count
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuCreateAliquot"))
                    throw new PermissionException("Sample", "MenuCreateAliquot");
                
              obj.SetupLoad(manager);
              for (int i = 0; i < count; i++)
                {
                    var o = CreateSampleFrom(manager, obj.Parent, obj, "A");
                    o.SampleKind = o.SampleKindLookup.SingleOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleKind.Aliquote);
                    o.Sample.Add(o);
                    o.Test.Add(o);
                    o.bIsMyPref = obj.bIsMyPref;
                    if (obj.bIsMyPref)
                        (obj.Parent as LaboratorySectionMaster).LaboratorySectionMyPrefItems.Add(o);
                    else
                        (obj.Parent as LaboratorySectionMaster).LaboratorySectionItems.Add(o);
                }
              return new ActResult(true, obj);
            
            }
            
      
            public ActResult MenuCreateDerivative(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                if (pars.Count != 2) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is int)) 
                    throw new TypeMismatchException("count", typeof(int));
                if (pars[1] != null && !(pars[1] is long)) 
                    throw new TypeMismatchException("idfsSampleType", typeof(long));
                
                return MenuCreateDerivative(manager, obj
                    , (int)pars[0]
                    , (long)pars[1]
                    );
            }
            public ActResult MenuCreateDerivative(DbManagerProxy manager, LaboratorySectionItem obj
                , int count
                , long idfsSampleType
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuCreateDerivative"))
                    throw new PermissionException("Sample", "MenuCreateDerivative");
                
              obj.SetupLoad(manager);
              for (int i = 0; i < count; i++)
                {
                    var o = CreateSampleFrom(manager, obj.Parent, obj, "D");
                    o.SampleType = o.SampleTypeLookup.SingleOrDefault(c => c.idfsBaseReference == idfsSampleType);
                    o.SampleKind = o.SampleKindLookup.SingleOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleKind.Derivative);
                    o.Sample.Add(o);
                    o.Test.Add(o);
                    o.bIsMyPref = obj.bIsMyPref;
                    if (obj.bIsMyPref)
                        (obj.Parent as LaboratorySectionMaster).LaboratorySectionMyPrefItems.Add(o);
                    else
                        (obj.Parent as LaboratorySectionMaster).LaboratorySectionItems.Add(o);
                }
              return new ActResult(true, obj);
            
            }
            
      
            public ActResult MenuTransferOutSample(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                if (pars.Count != 2) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long?)) 
                    throw new TypeMismatchException("idfSendToOfficeOut", typeof(long?));
                if (pars[1] != null && !(pars[1] is DateTime?)) 
                    throw new TypeMismatchException("datSendDate", typeof(DateTime?));
                
                return MenuTransferOutSample(manager, obj
                    , (long?)pars[0]
                    , (DateTime?)pars[1]
                    );
            }
            public ActResult MenuTransferOutSample(DbManagerProxy manager, LaboratorySectionItem obj
                , long? idfSendToOfficeOut
                , DateTime? datSendDate
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuTransferOutSample"))
                    throw new PermissionException("Sample", "MenuTransferOutSample");
                
              obj.SetupLoad(manager);
              obj.SendToOfficeOut = obj.SendToOfficeOutLookup.FirstOrDefault(c => c.idfInstitution == idfSendToOfficeOut);
              obj.datSendDate = datSendDate;
              return new ActResult(true, obj);
            
            }
            
      
            public ActResult MenuSeparator1(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuSeparator1(manager, obj
                    );
            }
            public ActResult MenuSeparator1(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuSeparator1"))
                    throw new PermissionException("Sample", "MenuSeparator1");
                
                return true;
                
            }
            
      
            public ActResult MenuStartTest(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuStartTest(manager, obj
                    );
            }
            public ActResult MenuStartTest(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuStartTest"))
                    throw new PermissionException("Sample", "MenuStartTest");
                
              obj.SetupLoad(manager);
              obj.TestStatusFull = obj.TestStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.TestStatus.InProcess);
              return true;
            
            }
            
      
            public ActResult MenuSetTestResult(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfsTestResult", typeof(long));
                
                return MenuSetTestResult(manager, obj
                    , (long)pars[0]
                    );
            }
            public ActResult MenuSetTestResult(DbManagerProxy manager, LaboratorySectionItem obj
                , long idfsTestResult
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuSetTestResult"))
                    throw new PermissionException("Sample", "MenuSetTestResult");
                
              obj.SetupLoad(manager);
              obj.TestStatusFull = obj.TestStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.TestStatus.Preliminary);
              obj.TestResultRef = obj.TestResultRefLookup.FirstOrDefault(c => c.idfsReference == idfsTestResult);
              return true;
            
            }
            
      
            public ActResult MenuValidateTestResult(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuValidateTestResult(manager, obj
                    );
            }
            public ActResult MenuValidateTestResult(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuValidateTestResult"))
                    throw new PermissionException("Sample", "MenuValidateTestResult");
                
              obj.SetupLoad(manager);
              var check = (obj.GetAccessor() as IObjectValidator).Validate(manager, obj, true, true, true);
              if (!check)
                  return new ActResult(false, obj);
                  
              obj.TestStatusFull = obj.TestStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.TestStatus.Finalized);
              return true;
            
            }
            
      
            public ActResult MenuAmendTestResult(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                if (pars.Count != 2) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is string)) 
                    throw new TypeMismatchException("strReason", typeof(string));
                if (pars[1] != null && !(pars[1] is long)) 
                    throw new TypeMismatchException("idfsTestResult", typeof(long));
                
                return MenuAmendTestResult(manager, obj
                    , (string)pars[0]
                    , (long)pars[1]
                    );
            }
            public ActResult MenuAmendTestResult(DbManagerProxy manager, LaboratorySectionItem obj
                , string strReason
                , long idfsTestResult
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuAmendTestResult"))
                    throw new PermissionException("Sample", "MenuAmendTestResult");
                
                obj.SetupLoad(manager);
                if (obj.AmendmentHistory.SingleOrDefault(c => c.IsNew) == null)
                {
                    var item = LabTestAmendment.Accessor.Instance(null).Create(manager, obj, obj.idfTesting.Value, obj.idfsTestResult, idfsTestResult, strReason);
                    obj.AmendmentHistory.Add(item);
                    obj.datConcludedDate = DateTime.Today;
                }
                else
                {
                    var item = obj.AmendmentHistory.Single(c => c.IsNew);
                    item.strReason = strReason;
                    item.NewTestResult = item.NewTestResultLookup.SingleOrDefault(c => c.idfsBaseReference == idfsTestResult);
                }
                obj.TestResultRef = obj.TestResultRefLookup.FirstOrDefault(c => c.idfsReference == idfsTestResult);
                obj.TestStatusFull = obj.TestStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.TestStatus.Amended);
                return true;
            
            }
            
      
            public ActResult MenuSeparator2(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuSeparator2(manager, obj
                    );
            }
            public ActResult MenuSeparator2(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuSeparator2"))
                    throw new PermissionException("Sample", "MenuSeparator2");
                
                return true;
                
            }
            
      
            public ActResult MenuAddToPreferences(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuAddToPreferences(manager, obj
                    );
            }
            public ActResult MenuAddToPreferences(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuAddToPreferences"))
                    throw new PermissionException("Sample", "MenuAddToPreferences");
                
              obj.SetupLoad(manager);
              manager.SetSpCommand("dbo.spLocalSamplesTestsPreference_Add"
                , manager.Parameter("idfTestingOrMaterial", obj.bTestInsertedFirst ? obj.idfMaterial : obj.ID)
                , manager.Parameter("idfUserID", (long)ModelUserContext.Instance.CurrentUser.ID)
                ).ExecuteNonQuery();
              return true;
            
            }
            
      
            public ActResult MenuRemoveFromPreferences(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuRemoveFromPreferences(manager, obj
                    );
            }
            public ActResult MenuRemoveFromPreferences(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuRemoveFromPreferences"))
                    throw new PermissionException("Sample", "MenuRemoveFromPreferences");
                
              obj.SetupLoad(manager);
              manager.SetSpCommand("dbo.spLocalSamplesTestsPreference_Remove"
                , manager.Parameter("idfTestingOrMaterial", obj.ID)
                , manager.Parameter("idfUserID", (long)ModelUserContext.Instance.CurrentUser.ID)
                ).ExecuteNonQuery();
              (obj.Parent as LaboratorySectionMaster).LaboratorySectionMyPrefItems.Remove(obj);
              return true;
            
            }
            
      
            public ActResult MenuRemove(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuRemove(manager, obj
                    );
            }
            public ActResult MenuRemove(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuRemove"))
                    throw new PermissionException("Sample", "MenuRemove");
                
              if (obj.bIsMyPref)
                  (obj.Parent as LaboratorySectionMaster).LaboratorySectionMyPrefItems.Remove(obj);
              else
                  (obj.Parent as LaboratorySectionMaster).LaboratorySectionItems.Remove(obj);
              return true;
            
            }
            
      
            public ActResult MenuCancelChanges(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuCancelChanges(manager, obj
                    );
            }
            public ActResult MenuCancelChanges(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuCancelChanges"))
                    throw new PermissionException("Sample", "MenuCancelChanges");
                
              if (obj.IsNew || obj.bTestInserted)
              {
                if (obj.bIsMyPref)
                    (obj.Parent as LaboratorySectionMaster).LaboratorySectionMyPrefItems.Remove(obj);
                else
                    (obj.Parent as LaboratorySectionMaster).LaboratorySectionItems.Remove(obj);
              }
              else
              {
                obj.DeepRejectChanges();
                obj.DeepRejectChanges();
              }
              return true;
            
            }
            
      
            public ActResult MenuSeparator3(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuSeparator3(manager, obj
                    );
            }
            public ActResult MenuSeparator3(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuSeparator3"))
                    throw new PermissionException("Sample", "MenuSeparator3");
                
                return true;
                
            }
            
      
            public ActResult MenuSampleDestruction(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuSampleDestruction(manager, obj
                    );
            }
            public ActResult MenuSampleDestruction(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuSampleDestruction"))
                    throw new PermissionException("Sample", "MenuSampleDestruction");
                
                return true;
                
            }
            
      
            public ActResult MenuRoutineSampleDestruction(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfsDestructionMethod", typeof(long));
                
                return MenuRoutineSampleDestruction(manager, obj
                    , (long)pars[0]
                    );
            }
            public ActResult MenuRoutineSampleDestruction(DbManagerProxy manager, LaboratorySectionItem obj
                , long idfsDestructionMethod
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuRoutineSampleDestruction"))
                    throw new PermissionException("Sample", "MenuRoutineSampleDestruction");
                
                  obj.SetupLoad(manager);
                  obj.SampleStatus = obj.SampleStatusLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.RoutineDestruction);
                  obj.SampleStatusFull = obj.SampleStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.RoutineDestruction);
                  obj.DestructionMethod = obj.DestructionMethodLookup.FirstOrDefault(c => c.idfsBaseReference == idfsDestructionMethod);
                  obj.idfMarkedForDispositionByPerson = (long)EidssUserContext.User.EmployeeID;
                  obj.datDestructionDate = DateTime.Today;
                  obj.Freezer = null;
                  return true;
                
            }
            
      
            public ActResult MenuAcceptDestruction(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuAcceptDestruction(manager, obj
                    );
            }
            public ActResult MenuAcceptDestruction(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuAcceptDestruction"))
                    throw new PermissionException("Sample", "MenuAcceptDestruction");
                
                  obj.SetupLoad(manager);
                  obj.SampleStatus = obj.SampleStatusLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.Destroyed);
                  obj.SampleStatusFull = obj.SampleStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.Destroyed);
                  obj.idfDestroyedByPerson = (long)EidssUserContext.User.EmployeeID;
                  return true;
                
            }
            
      
            public ActResult MenuRejectDestruction(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuRejectDestruction(manager, obj
                    );
            }
            public ActResult MenuRejectDestruction(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuRejectDestruction"))
                    throw new PermissionException("Sample", "MenuRejectDestruction");
                
                  obj.SetupLoad(manager);
                  obj.SampleStatus = obj.SampleStatusLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.Accessioned);
                  obj.SampleStatusFull = obj.SampleStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.Accessioned);
                  obj.DestructionMethod = null;
                  obj.idfMarkedForDispositionByPerson = null;
                  obj.datDestructionDate = null;
                  return true;
                
            }
            
      
            public ActResult MenuDelete(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuDelete(manager, obj
                    );
            }
            public ActResult MenuDelete(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuDelete"))
                    throw new PermissionException("Sample", "MenuDelete");
                
                return true;
                
            }
            
      
            public ActResult MenuDeleteSample(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuDeleteSample(manager, obj
                    );
            }
            public ActResult MenuDeleteSample(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuDeleteSample"))
                    throw new PermissionException("Sample", "MenuDeleteSample");
                
                  obj.SetupLoad(manager);
                  obj.SampleStatusFull = obj.SampleStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.IsDeleted);
                  return true;
                
            }
            
      
            public ActResult MenuDeleteTest(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuDeleteTest(manager, obj
                    );
            }
            public ActResult MenuDeleteTest(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuDeleteTest"))
                    throw new PermissionException("Sample", "MenuDeleteTest");
                
                  obj.SetupLoad(manager);
                  obj.bTestDeleted = true;
                  obj.TestStatusFull = obj.TestStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == -1);
                  return true;
                
            }
            
      
            public ActResult MenuSeparator4(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuSeparator4(manager, obj
                    );
            }
            public ActResult MenuSeparator4(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuSeparator4"))
                    throw new PermissionException("Sample", "MenuSeparator4");
                
                return true;
                
            }
            
      
            public ActResult MenuPaperForms(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuPaperForms(manager, obj
                    );
            }
            public ActResult MenuPaperForms(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuPaperForms"))
                    throw new PermissionException("Sample", "MenuPaperForms");
                
                return true;
                
            }
            
      
            public ActResult MenuSampleReport(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuSampleReport(manager, obj
                    );
            }
            public ActResult MenuSampleReport(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuSampleReport"))
                    throw new PermissionException("Sample", "MenuSampleReport");
                
                return true;
                
            }
            
      
            public ActResult MenuTestResultReport(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuTestResultReport(manager, obj
                    );
            }
            public ActResult MenuTestResultReport(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuTestResultReport"))
                    throw new PermissionException("Sample", "MenuTestResultReport");
                
                return true;
                
            }
            
      
            public ActResult MenuSampleDestructionReport(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuSampleDestructionReport(manager, obj
                    );
            }
            public ActResult MenuSampleDestructionReport(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuSampleDestructionReport"))
                    throw new PermissionException("Sample", "MenuSampleDestructionReport");
                
                return true;
                
            }
            
      
            public ActResult MenuPrintBarcode(DbManagerProxy manager, LaboratorySectionItem obj, List<object> pars)
            {
                
                return MenuPrintBarcode(manager, obj
                    );
            }
            public ActResult MenuPrintBarcode(DbManagerProxy manager, LaboratorySectionItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("MenuPrintBarcode"))
                    throw new PermissionException("Sample", "MenuPrintBarcode");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(LaboratorySectionItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LaboratorySectionItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datSendDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datSendDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datFieldCollectionDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFieldCollectionDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datFieldCollectionDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFieldCollectionDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datFieldSentDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFieldSentDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datAccession)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datAccession);
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
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                            try
                            {
                            
                (new RequiredValidator( "idfsDiagnosis", "idfsDiagnosis","TestDiagnosisName",
                false
              )).Validate(c => !c.bTestDeleted && c.idfsTestStatus.HasValue && c.idfsTestStatus != (long)eidss.model.Enums.TestStatus.NotStarted && !(/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/), obj, obj.idfsDiagnosis);
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_idfsTestStatus);
                                    obj._TestStatusFull = obj.TestStatusFullLookup.Where(a => a.idfsBaseReference == obj.idfsTestStatus).SingleOrDefault();
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                                
                            }
                        }
                    
                        if (e.PropertyName == _str_idfsSampleStatus)
                        {
                    
                obj.strSampleStatus = new Func<LaboratorySectionItem, string>(c => c.SampleStatusFullLookup.SingleOrDefault(i => i.idfsBaseReference == c.idfsSampleStatus) == null ? "" : c.SampleStatusFullLookup.Single(i => i.idfsBaseReference == c.idfsSampleStatus).name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSampleType)
                        {
                    
                obj.strSampleName = new Func<LaboratorySectionItem, string>(c => c.SampleType == null ? "" : c.SampleType.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsAccessionCondition)
                        {
                    
                obj.strSampleConditionReceivedStatus = new Func<LaboratorySectionItem, string>(c => c.AccessionCondition == null ? "" : c.AccessionCondition.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                obj.strDiagnosisName = new Func<LaboratorySectionItem, string>(c => c.DiagnosisForTest == null ? (c.Diagnosis == null ? "" : c.Diagnosis.name) : c.DiagnosisForTest.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestName)
                        {
                    
                obj.strTestName = new Func<LaboratorySectionItem, string>(c => c.TestNameRef == null ? "" : c.TestNameRef.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.strTestStatus = new Func<LaboratorySectionItem, string>(c => c.TestStatusFull == null ? "" : c.TestStatusFull.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestResult)
                        {
                    
                obj.strTestResult = new Func<LaboratorySectionItem, string>(c => c.TestResultRef == null ? "" : c.TestResultRef.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestCategory)
                        {
                    
                obj.strTestCategory = new Func<LaboratorySectionItem, string>(c => c.TestCategoryRef == null ? "" : c.TestCategoryRef.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.Rayon = new Func<LaboratorySectionItem, RayonLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Rayon(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfSpeciesVectorInfo)
                        {
                    
                obj.idfAnimal = new Func<LaboratorySectionItem, long?>(c => c.SpeciesVectorInfo == null ? null : c.SpeciesVectorInfo.idfAnimal)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfSpeciesVectorInfo)
                        {
                    
                obj.idfSpecies = new Func<LaboratorySectionItem, long?>(c => c.SpeciesVectorInfo == null ? null : (c.SpeciesVectorInfo.idfAnimal.HasValue ? null : c.SpeciesVectorInfo.idfSpecies))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfSpeciesVectorInfo)
                        {
                    
                obj.idfVector = new Func<LaboratorySectionItem, long?>(c => c.SpeciesVectorInfo == null ? null : c.SpeciesVectorInfo.idfVector)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfSpeciesVectorInfo)
                        {
                    
                obj.HumanName = new Func<LaboratorySectionItem, string>(c => c.SpeciesVectorInfo == null ? "" : c.SpeciesVectorInfo.HumanName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfSpeciesVectorInfo)
                        {
                    
                obj.strRegion = new Func<LaboratorySectionItem, string>(c => c.SpeciesVectorInfo == null ? "" : c.SpeciesVectorInfo.strRegion)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfSpeciesVectorInfo)
                        {
                    
                obj.strRayon = new Func<LaboratorySectionItem, string>(c => c.SpeciesVectorInfo == null ? "" : c.SpeciesVectorInfo.strRayon)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.TestStatusShort = new Func<LaboratorySectionItem, BaseReference>(c => c.TestStatusShortLookup.FirstOrDefault(i => i.idfsBaseReference == c.idfsTestStatus))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatusDummy)
                        {
                    
                obj.TestStatusFull = new Func<LaboratorySectionItem, BaseReference>(c => !c.idfsTestStatusDummy.HasValue || c.idfsTestStatus == c.idfsTestStatusDummy ? c.TestStatusFull : c.TestStatusFullLookup.FirstOrDefault(i => i.idfsBaseReference == c.idfsTestStatusDummy))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.TestResultRef = new Func<LaboratorySectionItem, TestResultLookup>(c => (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.NotStarted || c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.InProcess) ? null : c.TestResultRef)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.datStartedDate = new Func<LaboratorySectionItem, DateTime?>(c => (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.InProcess || c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary) ? (c.datStartedDate == null ? DateTime.Today : c.datStartedDate) : (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.NotStarted ? null : c.datStartedDate))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.datConcludedDate = new Func<LaboratorySectionItem, DateTime?>(c => 
                          (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary)
                            ? (c.datConcludedDate.HasValue ? c.datConcludedDate : DateTime.Today)
                            : (
                              (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized) 
                                ? (DateTime.Today)
                                : (
                                  (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.NotStarted)
                                    ? (null)
                                    : (c.datConcludedDate)
                                  )
                              ))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.TestedByOffice = new Func<LaboratorySectionItem, OrganizationLookup>(c => (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.InProcess) ? (c.TestedByOfficeLookup.FirstOrDefault(l => l.idfInstitution == (long)EidssUserContext.User.OrganizationID)) : ((c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary && c.TestedByOffice == null) ? (c.TestedByOfficeLookup.FirstOrDefault(l => l.idfInstitution == (long)EidssUserContext.User.OrganizationID)) : (c.TestedByOffice)))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.TestedByPerson = new Func<LaboratorySectionItem, PersonLookup>(c => (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.InProcess) ? (c.TestedByPersonLookup.FirstOrDefault(l => l.idfPerson == (long)EidssUserContext.User.EmployeeID)) : ((c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary && c.TestedByPerson == null) ? (c.TestedByPersonLookup.FirstOrDefault(l => l.idfPerson == (long)EidssUserContext.User.EmployeeID)) : (c.TestedByPerson)))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.ResultEnteredByOffice = new Func<LaboratorySectionItem, OrganizationLookup>(c => c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary ? c.ResultEnteredByOfficeLookup.FirstOrDefault(l => l.idfInstitution == (long)EidssUserContext.User.OrganizationID) : c.ResultEnteredByOffice)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.ResultEnteredByPerson = new Func<LaboratorySectionItem, PersonLookup>(c => c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary ? c.ResultEnteredByPersonLookup.FirstOrDefault(l => l.idfPerson == (long)EidssUserContext.User.EmployeeID) : c.ResultEnteredByPerson)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.ValidatedByOffice = new Func<LaboratorySectionItem, OrganizationLookup>(c => c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized ? c.ValidatedByOfficeLookup.FirstOrDefault(l => l.idfInstitution == (long)EidssUserContext.User.OrganizationID) : c.ValidatedByOffice)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestStatus)
                        {
                    
                obj.ValidatedByPerson = new Func<LaboratorySectionItem, PersonLookup>(c => c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized ? c.ValidatedByPersonLookup.FirstOrDefault(l => l.idfPerson == (long)EidssUserContext.User.EmployeeID) : c.ValidatedByPerson)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestResult)
                        {
                    
                obj.TestStatusFull = new Func<LaboratorySectionItem, BaseReference>(c => c.idfsTestResult.HasValue && !c.idfsTestResultPrevious.HasValue && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.InProcess ? c.TestStatusFullLookup.FirstOrDefault(l => l.idfsBaseReference == (long)eidss.model.Enums.TestStatus.Preliminary) : c.TestStatusFull)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsAccessionCondition)
                        {
                    
              if (!obj.idfsAccessionCondition_Original.HasValue && obj.idfsAccessionCondition.HasValue && 
                  (obj.idfsAccessionCondition.Value == (long)eidss.model.Enums.AccessionConditionEnum.AcceptedInPoorCondition
                || obj.idfsAccessionCondition.Value == (long)eidss.model.Enums.AccessionConditionEnum.AcceptedInGoodCondition))
              {
                  obj.SampleStatus = obj.SampleStatusLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.Accessioned);
                  obj.SampleStatusFull = obj.SampleStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.Accessioned);
                  obj.AccessionByPerson = obj.AccessionByPersonLookup.SingleOrDefault(l => l.idfPerson == (long)EidssUserContext.User.EmployeeID);
                  obj.datAccession = DateTime.Today;
                  /*if (string.IsNullOrEmpty(obj.strBarcode))
                      obj.strBarcode = "(new" + ++(obj.Parent as LaboratorySectionMaster).newCounter + ")";*/
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                  {
                      obj.strBarcode = manager.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.Sample, DBNull.Value, DBNull.Value)
                          .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue");
                  }
              }
              else if (!obj.idfsAccessionCondition_Original.HasValue && obj.idfsAccessionCondition.HasValue && 
                  obj.idfsAccessionCondition.Value == (long)eidss.model.Enums.AccessionConditionEnum.Rejected)
              {
                  obj.SampleStatus = obj.SampleStatusLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.Accessioned);
                  obj.SampleStatusFull = obj.SampleStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.Accessioned);
                  obj.AccessionByPerson = obj.AccessionByPersonLookup.SingleOrDefault(l => l.idfPerson == (long)EidssUserContext.User.EmployeeID);
                  obj.datAccession = DateTime.Today;
                  /*if (string.IsNullOrEmpty(obj.strBarcode))
                      obj.strBarcode = "(new" + ++(obj.Parent as LaboratorySectionMaster).newCounter + ")";*/
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                  {
                      obj.strBarcode = manager.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.Sample, DBNull.Value, DBNull.Value)
                          .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue");
                  }
              }
              else if (!obj.idfsAccessionCondition_Original.HasValue && (!obj.idfsAccessionCondition.HasValue || obj.idfsAccessionCondition.Value == 0))
              {
                  obj.SampleStatus = null;
                  obj.SampleStatusFull = null;
                  obj.AccessionByPerson = null;
                  obj.strBarcode = obj.strBarcode_Original;
                  obj.datAccession = null;
              }
            
                        }
                    
                        if (e.PropertyName == _str_idfSendToOfficeOut)
                        {
                    
              if (!obj.idfSendToOfficeOut_Original.HasValue && obj.idfSendToOfficeOut.HasValue)
              {
                  obj.SendToOfficeOut = obj.SendToOfficeOutLookup.Single(c => c.idfInstitution == obj.idfSendToOfficeOut);
                  obj.bExternalOffice = !obj.SendToOfficeOut.idfsSite.HasValue;
                  obj.SampleStatus = obj.SampleStatusLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.OutOfRepository);
                  obj.SampleStatusFull = obj.SampleStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.OutOfRepository);
                  obj.idfSendByPerson = (long)EidssUserContext.User.EmployeeID;
                  obj.datSendDate = DateTime.Today;
              }
              else if (!obj.idfSendToOfficeOut_Original.HasValue && (!obj.idfSendToOfficeOut.HasValue || obj.idfSendToOfficeOut.Value == 0))
              {
                  obj.bExternalOffice = false;
                  obj.SampleStatus = obj.SampleStatusLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.Accessioned);
                  obj.SampleStatusFull = obj.SampleStatusFullLookup.FirstOrDefault(c => c.idfsBaseReference == (long)eidss.model.Enums.SampleStatus.Accessioned);
                  obj.idfSendByPerson = null;
                  obj.datSendDate = null;
              }
            
                        }
                    
                        if (e.PropertyName == _str_strCalculatedCaseID)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    var pop = manager.SetSpCommand("dbo.spLaboratorySection_PopulateCaseInfo", obj.strCalculatedCaseID, ModelUserContext.CurrentLanguage).ExecuteObject<LaboratorySectionItem>();
                    obj.idfHumanCase = pop.idfHumanCase;
                    obj.idfHuman = pop.idfHuman;
                    obj.idfVetCase = pop.idfVetCase;
                    obj.idfMonitoringSession = pop.idfMonitoringSession;
                    obj.idfVectorSurveillanceSession = pop.idfVectorSurveillanceSession;
                    obj.idfsCaseType = pop.idfsCaseType;
                    obj.intCaseHACode = pop.intCaseHACode;
                    //obj.idfsDiagnosis = pop.idfsDiagnosis;
                    //obj.DiagnosisName = pop.DiagnosisName;
                    obj.Diagnosis = obj.DiagnosisLookup.FirstOrDefault(j => j.idfsDiagnosis == pop.idfsDiagnosis);
                    obj.idfCaseOrSession = pop.idfCaseOrSession;
                    obj.SpeciesVectorInfo = obj.SpeciesVectorInfoLookup.SingleOrDefault(c => c.idfSpeciesVectorInfo == pop.idfSpeciesVectorInfo);
                    //obj.strPatientName = pop.strPatientName;
                    //obj.strFarmOwner = pop.strFarmOwner;
                    obj.HumanName = pop.HumanName;
                    obj.strRegion = pop.strRegion;
                    obj.strRayon= pop.strRayon;
                    //obj.Region = obj.RegionLookup.SingleOrDefault(c => c.idfsRegion == pop.idfsRegion);
                    //obj.Rayon = obj.RayonLookup.SingleOrDefault(c => c.idfsRayon == pop.idfsRayon);
                }
            
                        }
                    
                        if (e.PropertyName == _str_idfsTestName)
                        {
                    
              if (!obj.idfTesting.HasValue && !obj.idfsTestNamePrevious.HasValue && obj.idfsTestName.HasValue && obj.intNewMode != LabNewModeEnum.AssignTest)
              {
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                  {
                      if (!Accessor.Instance(null).ItemAssignTest(manager, obj, new List<IObject>() { obj }, obj.Parent, obj.bIsMyPref).result)
                      {
                          obj.idfsTestName = obj.idfsTestNamePrevious;
                      }
                  }
              }
            
                        }
                    
                        if (e.PropertyName == _str_idfsTestName)
                        {
                    
                if (obj.FFPresenter != null)
                {
                  obj.FFPresenter.SetProperties(FFPresenterModel.LoadActualTemplate(EidssSiteContext.Instance.CountryID, obj.idfsTestName, FFTypeEnum.TestDetails), obj.ID);
                  obj.idfsFormTemplate = obj.FFPresenter.CurrentTemplate.idfsFormTemplate;
                }
              
                        }
                    
                        if (e.PropertyName == _str_blnExternalTest)
                        {
                    
              //if (obj.blnExternalTest.HasValue/* && obj.blnExternalTest != obj.blnExternalTestPrevious*/)
              //{
                  if (obj.blnExternalTest/*.Value*/)
                  {
                      using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                      {
                          Accessor.Instance(null).MenuExternalTestResult(manager, obj);
                      }
                  }
                  /*else if (!obj.blnExternalTestPrevious.HasValue || !obj.blnExternalTestPrevious.Value)
                  {
                      obj.bTestInserted = false;
                      obj.idfTesting = null;
                      obj.ID = obj.idfMaterial;
                      obj.PerformedByOffice = null;
                      obj.datStartedDate = null;
                      obj.datReceivedDate = null;
                      obj.datConcludedDate = null;
                      obj.TestStatusFull = null;
                      //obj.Diagnosis = null;
                      obj.TestNameRef = null;
                      obj.TestResultRef = null;
                      obj.TestCategoryRef = null;
                      obj.TestedByOffice = null;
                      obj.TestedByPerson = null;
                      obj.strContactPerson = null;
                      //obj.idfObservation = null;
                      //obj.FFPresenter = null;
                  }*/
              //}
            
                        }
                    
                        if (e.PropertyName == _str_idfCaseOrSession)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_SpeciesVectorInfo(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfCaseOrSession)
                        {
                    
                obj.SpeciesVectorInfo = (new SetScalarHandler()).Handler(obj,
                    obj.idfCaseOrSession, obj.idfCaseOrSession_Previous, obj.SpeciesVectorInfo,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_intCaseHACode)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_SampleTypeFiltered(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_intCaseHACode)
                        {
                    
                obj.SampleTypeFiltered = (new SetScalarHandler()).Handler(obj,
                    obj.intCaseHACode, obj.intCaseHACode_Previous, obj.SampleTypeFiltered,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsSampleType)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_DerivativeType(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSampleType)
                        {
                    
                obj.DerivativeType = (new SetScalarHandler()).Handler(obj,
                    obj.idfsSampleType, obj.idfsSampleType_Previous, obj.DerivativeType,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfFieldCollectedByOffice)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_CollectedByPerson(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfFieldCollectedByOffice)
                        {
                    
                obj.CollectedByPerson = (new SetScalarHandler()).Handler(obj,
                    obj.idfFieldCollectedByOffice, obj.idfFieldCollectedByOffice_Previous, obj.CollectedByPerson,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                if (new Func<LaboratorySectionItem, bool>(c => c.bFilterTestByDiagnosis)(obj))
              
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestNameRef(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                obj.TestNameRef = (new SetScalarHandler()).Handler(obj,
                    obj.idfsDiagnosis, obj.idfsDiagnosis_Previous, obj.TestNameRef,
                    (o, fld, prev_fld) => o.bFilterTestByDiagnosis ? null : o.TestNameRef);
            
                        }
                    
                        if (e.PropertyName == _str_intCaseHACode)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestNameRef(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_bFilterTestByDiagnosis)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestNameRef(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_bFilterTestByDiagnosis)
                        {
                    
                obj.TestNameRef = (new SetScalarHandler()).Handler(obj,
                    obj.bFilterTestByDiagnosis, obj.bFilterTestByDiagnosis_Previous, obj.TestNameRef,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsTestName)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestResultRef(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTestName)
                        {
                    
                obj.TestResultRef = (new SetScalarHandler()).Handler(obj,
                    obj.idfsTestName, obj.idfsTestName_Previous, obj.TestResultRef,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsTestName)
                        {
                    
                obj.TestCategoryRef = new Func<LaboratorySectionItem, BaseReference>(c => c.bFilterTestByDiagnosis && c.TestNameRef != null ? c.TestCategoryRefLookup.SingleOrDefault(i => i.idfsBaseReference == c.TestNameRef.idfsTestCategory) : c.TestCategoryRef)(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Region(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<LaboratorySectionItem, long>(c => c.idfsCountry ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRegion == obj.idfsRegion))
                    
                    .ToList());
                
                if (obj.idfsRegion != null && obj.idfsRegion != 0)
                {
                    obj.Region = obj.RegionLookup
                        .SingleOrDefault(c => c.idfsRegion == obj.idfsRegion);
                    
                }
              
                LookupManager.AddObject("RegionLookup", obj, RegionAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_Rayon(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<LaboratorySectionItem, long>(c => c.idfsRegion ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRayon == obj.idfsRayon))
                    
                    .ToList());
                
                if (obj.idfsRayon != null && obj.idfsRayon != 0)
                {
                    obj.Rayon = obj.RayonLookup
                        .SingleOrDefault(c => c.idfsRayon == obj.idfsRayon);
                    
                }
              
                LookupManager.AddObject("RayonLookup", obj, RayonAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_Diagnosis(DbManagerProxy manager, LaboratorySectionItem obj)
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
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosis);
                    
                }
              
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_DiagnosisForTest(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.DiagnosisForTestLookup.Clear();
                
                obj.DiagnosisForTestLookup.Add(DiagnosisForTestAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisForTestLookup.AddRange(DiagnosisForTestAccessor.SelectLookupList(manager
                    
                    , new Func<LaboratorySectionItem, long?>(c => c.idfMaterial)(obj)
                            
                    , new Func<LaboratorySectionItem, long?>(c => c.idfCaseOrSession)(obj)
                            
                    , new Func<LaboratorySectionItem, long?>(c => c.idfsCaseType)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != null && obj.idfsDiagnosis != 0)
                {
                    obj.DiagnosisForTest = obj.DiagnosisForTestLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosis);
                    
                }
              
                LookupManager.AddObject("TestDiagnosisLookup", obj, DiagnosisForTestAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_SampleType(DbManagerProxy manager, LaboratorySectionItem obj)
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
            
            public void LoadLookup_SampleTypeFiltered(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.SampleTypeFilteredLookup.Clear();
                
                obj.SampleTypeFilteredLookup.Add(SampleTypeFilteredAccessor.CreateNewT(manager, null));
                
                obj.SampleTypeFilteredLookup.AddRange(SampleTypeFilteredAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (obj.intCaseHACode.HasValue && ((c.intHACode & obj.intCaseHACode) != 0)) || c.idfsReference == obj.idfsSampleType)
                        
                    .Where(c => c.idfsDiagnosis == 0)
                        
                    .Where(c => c.idfsReference != (long)SampleTypeEnum.Unknown)
                        
                    .Distinct(new SampleTypeForDiagnosisLookupComparator())
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsSampleTypeFiltered))
                    
                    .ToList());
                
                if (obj.idfsSampleTypeFiltered != null && obj.idfsSampleTypeFiltered != 0)
                {
                    obj.SampleTypeFiltered = obj.SampleTypeFilteredLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsSampleTypeFiltered);
                    
                }
              
                LookupManager.AddObject("SampleTypeForDiagnosisLookup", obj, SampleTypeFilteredAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_DerivativeType(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.DerivativeTypeLookup.Clear();
                
                obj.DerivativeTypeLookup.Add(DerivativeTypeAccessor.CreateNewT(manager, null));
                
                obj.DerivativeTypeLookup.AddRange(DerivativeTypeAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => c.idfsSampleType == obj.idfsSampleType)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfDerivativeForSampleType == obj.idfDerivativeForSampleType))
                    
                    .ToList());
                
                if (obj.idfDerivativeForSampleType != null && obj.idfDerivativeForSampleType != 0)
                {
                    obj.DerivativeType = obj.DerivativeTypeLookup
                        .SingleOrDefault(c => c.idfDerivativeForSampleType == obj.idfDerivativeForSampleType);
                    
                }
              
                LookupManager.AddObject("LabDerivativeTypesLookup", obj, DerivativeTypeAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_AccessionCondition(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.AccessionConditionLookup.Clear();
                
                obj.AccessionConditionLookup.AddRange(AccessionConditionAccessor.rftAccessionCondition_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAccessionCondition))
                    
                    .ToList());
                
                if (obj.idfsAccessionCondition != null && obj.idfsAccessionCondition != 0)
                {
                    obj.AccessionCondition = obj.AccessionConditionLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsAccessionCondition);
                    
                }
              
                LookupManager.AddObject("rftAccessionCondition", obj, AccessionConditionAccessor.GetType(), "rftAccessionCondition_SelectList"
                  , "SelectLookupList");
              
            }
            
            public void LoadLookup_TestNameForSearch(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.TestNameForSearchLookup.Clear();
                
                obj.TestNameForSearchLookup.Add(TestNameForSearchAccessor.CreateNewT(manager, null));
                
                obj.TestNameForSearchLookup.AddRange(TestNameForSearchAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => c.idfsDiagnosis == 0)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsTestName))
                    
                    .ToList());
                
                if (obj.idfsTestName != null && obj.idfsTestName != 0)
                {
                    obj.TestNameForSearch = obj.TestNameForSearchLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsTestName);
                    
                }
              
                LookupManager.AddObject("TestForDiseaseLookup", obj, TestNameForSearchAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_TestNameRef(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.TestNameRefLookup.Clear();
                
                obj.TestNameRefLookup.AddRange(TestNameRefAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intHACode & obj.intCaseHACode) != 0 || c.idfsReference == obj.idfsTestName)
                        
                    .Where(c => c.idfsDiagnosis == (obj.bFilterTestByDiagnosis ? obj.idfsDiagnosis : 0))
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsTestName))
                    
                    .ToList());
                
                if (obj.idfsTestName != null && obj.idfsTestName != 0)
                {
                    obj.TestNameRef = obj.TestNameRefLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsTestName);
                    
                }
              
                LookupManager.AddObject("TestForDiseaseLookup", obj, TestNameRefAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_TestResultRef(DbManagerProxy manager, LaboratorySectionItem obj)
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
            
            public void LoadLookup_TestResultForAmend(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.TestResultForAmendLookup.Clear();
                
                obj.TestResultForAmendLookup.Add(TestResultForAmendAccessor.CreateNewT(manager, null));
                
                obj.TestResultForAmendLookup.AddRange(TestResultForAmendAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => c.idfsTestName == obj.idfsTestName)
                        
                    .Where(c => c.idfsReference != obj.idfsOldTestResult)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsTestResult))
                    
                    .ToList());
                
                if (obj.idfsTestResult != null && obj.idfsTestResult != 0)
                {
                    obj.TestResultForAmend = obj.TestResultForAmendLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsTestResult);
                    
                }
              
                LookupManager.AddObject("TestResultLookup", obj, TestResultForAmendAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_TestResultDummy(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.TestResultDummyLookup.Clear();
                
                obj.TestResultDummyLookup.Add(TestResultDummyAccessor.CreateNewT(manager, null));
                
                obj.TestResultDummyLookup.AddRange(TestResultDummyAccessor.rftTestResult_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestResultDummy))
                    
                    .ToList());
                
                if (obj.idfsTestResultDummy != null && obj.idfsTestResultDummy != 0)
                {
                    obj.TestResultDummy = obj.TestResultDummyLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsTestResultDummy);
                    
                }
              
                LookupManager.AddObject("rftTestResult", obj, TestResultDummyAccessor.GetType(), "rftTestResult_SelectList"
                  , "SelectLookupList");
              
            }
            
            public void LoadLookup_TestCategoryRef(DbManagerProxy manager, LaboratorySectionItem obj)
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
            
            public void LoadLookup_TestStatusShort(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.TestStatusShortLookup.Clear();
                
                obj.TestStatusShortLookup.AddRange(TestStatusShortAccessor.rftTestStatus_SelectList(manager
                    
                    )
                    .Where(c => c.idfsBaseReference == (long)eidss.model.Enums.TestStatus.InProcess || c.idfsBaseReference == (long)eidss.model.Enums.TestStatus.Preliminary || c.idfsBaseReference == (long)eidss.model.Enums.TestStatus.NotStarted)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestStatusDummy))
                    
                    .ToList());
                
                if (obj.idfsTestStatusDummy != null && obj.idfsTestStatusDummy != 0)
                {
                    obj.TestStatusShort = obj.TestStatusShortLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsTestStatusDummy);
                    
                }
              
                LookupManager.AddObject("rftTestStatus", obj, TestStatusShortAccessor.GetType(), "rftTestStatus_SelectList"
                  , "SelectLookupList");
              
            }
            
            public void LoadLookup_TestStatusForSearch(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.TestStatusForSearchLookup.Clear();
                
                obj.TestStatusForSearchLookup.Add(TestStatusForSearchAccessor.CreateNewT(manager, null));
                
                obj.TestStatusForSearchLookup.AddRange(TestStatusForSearchAccessor.rftTestStatus_SelectList(manager
                    
                    )
                    .Where(c => c.idfsBaseReference == (long)eidss.model.Enums.TestStatus.Finalized || c.idfsBaseReference == (long)eidss.model.Enums.TestStatus.InProcess || c.idfsBaseReference == (long)eidss.model.Enums.TestStatus.Preliminary || c.idfsBaseReference == (long)eidss.model.Enums.TestStatus.NotStarted || c.idfsBaseReference == (long)eidss.model.Enums.TestStatus.Amended)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestStatusDummy))
                    
                    .ToList());
                
                if (obj.idfsTestStatusDummy != null && obj.idfsTestStatusDummy != 0)
                {
                    obj.TestStatusForSearch = obj.TestStatusForSearchLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsTestStatusDummy);
                    
                }
              
                LookupManager.AddObject("rftTestStatus", obj, TestStatusForSearchAccessor.GetType(), "rftTestStatus_SelectList"
                  , "SelectLookupList");
              
            }
            
            public void LoadLookup_TestStatusFull(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.TestStatusFullLookup.Clear();
                
                obj.TestStatusFullLookup.Add(TestStatusFullAccessor.CreateNewT(manager, null));
                
                obj.TestStatusFullLookup.Add(TestStatusFullAccessor.CreateNewT(manager, null));
                obj.TestStatusFullLookup[1].name = eidss.model.Resources.EidssFields.Get("Deleted");
                obj.TestStatusFullLookup[1].SetValue(obj.TestStatusFullLookup[1].KeyName, "-1");
                
                obj.TestStatusFullLookup.AddRange(TestStatusFullAccessor.rftTestStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestStatus))
                    
                    .ToList());
                
                if (obj.idfsTestStatus != null && obj.idfsTestStatus != 0)
                {
                    obj.TestStatusFull = obj.TestStatusFullLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsTestStatus);
                    
                }
              
                LookupManager.AddObject("rftTestStatus", obj, TestStatusFullAccessor.GetType(), "rftTestStatus_SelectList"
                  , "SelectLookupList");
              
            }
            
            public void LoadLookup_SampleStatus(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.SampleStatusLookup.Clear();
                
                obj.SampleStatusLookup.Add(SampleStatusAccessor.CreateNewT(manager, null));
                
                obj.SampleStatusLookup.Add(SampleStatusAccessor.CreateNewT(manager, null));
                obj.SampleStatusLookup[1].name = eidss.model.Resources.EidssFields.Get("Unaccessioned");
                obj.SampleStatusLookup[1].SetValue(obj.SampleStatusLookup[1].KeyName, "-1");
                
                obj.SampleStatusLookup.AddRange(SampleStatusAccessor.rftSampleStatus_SelectList(manager
                    
                    )
                    .Where(c => c.idfsBaseReference != (long)eidss.model.Enums.SampleStatus.IsDeleted && c.idfsBaseReference != (long)eidss.model.Enums.SampleStatus.Delete)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSampleStatus))
                    
                    .ToList());
                
                if (obj.idfsSampleStatus != 0)
                {
                    obj.SampleStatus = obj.SampleStatusLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsSampleStatus);
                    
                }
              
                LookupManager.AddObject("rftSampleStatus", obj, SampleStatusAccessor.GetType(), "rftSampleStatus_SelectList"
                  , "SelectLookupList");
              
            }
            
            public void LoadLookup_SampleStatusFull(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.SampleStatusFullLookup.Clear();
                
                obj.SampleStatusFullLookup.Add(SampleStatusFullAccessor.CreateNewT(manager, null));
                
                obj.SampleStatusFullLookup.Add(SampleStatusFullAccessor.CreateNewT(manager, null));
                obj.SampleStatusFullLookup[1].name = eidss.model.Resources.EidssFields.Get("Unaccessioned");
                obj.SampleStatusFullLookup[1].SetValue(obj.SampleStatusFullLookup[1].KeyName, "-1");
                
                obj.SampleStatusFullLookup.AddRange(SampleStatusFullAccessor.rftSampleStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSampleStatus))
                    
                    .ToList());
                
                if (obj.idfsSampleStatus != 0)
                {
                    obj.SampleStatusFull = obj.SampleStatusFullLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsSampleStatus);
                    
                }
              
                LookupManager.AddObject("rftSampleStatus", obj, SampleStatusFullAccessor.GetType(), "rftSampleStatus_SelectList"
                  , "SelectLookupList");
              
            }
            
            public void LoadLookup_AccessionByPerson(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.AccessionByPersonLookup.Clear();
                
                obj.AccessionByPersonLookup.Add(AccessionByPersonAccessor.CreateNewT(manager, null));
                
                obj.AccessionByPersonLookup.AddRange(AccessionByPersonAccessor.SelectLookupList(manager
                    
                    , new Func<LaboratorySectionItem, long>(c => eidss.model.Core.EidssSiteContext.Instance.OrganizationID)(obj)
                            
                    , null
                    , false
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfAccesionByPerson))
                    
                    .ToList());
                
                if (obj.idfAccesionByPerson != null && obj.idfAccesionByPerson != 0)
                {
                    obj.AccessionByPerson = obj.AccessionByPersonLookup
                        .SingleOrDefault(c => c.idfPerson == obj.idfAccesionByPerson);
                    
                }
              
                LookupManager.AddObject("PersonLookup", obj, AccessionByPersonAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_SendToOffice(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.SendToOfficeLookup.Clear();
                
                obj.SendToOfficeLookup.Add(SendToOfficeAccessor.CreateNewT(manager, null));
                
                obj.SendToOfficeLookup.AddRange(SendToOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfSendToOffice))
                    
                    .ToList());
                
                if (obj.idfSendToOffice != null && obj.idfSendToOffice != 0)
                {
                    obj.SendToOffice = obj.SendToOfficeLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfSendToOffice);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, SendToOfficeAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_SendToOfficeOut(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.SendToOfficeOutLookup.Clear();
                
                obj.SendToOfficeOutLookup.Add(SendToOfficeOutAccessor.CreateNewT(manager, null));
                
                obj.SendToOfficeOutLookup.AddRange(SendToOfficeOutAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfSendToOfficeOut))
                    
                    .ToList());
                
                if (obj.idfSendToOfficeOut != null && obj.idfSendToOfficeOut != 0)
                {
                    obj.SendToOfficeOut = obj.SendToOfficeOutLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfSendToOfficeOut);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, SendToOfficeOutAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_PerformedByOffice(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.PerformedByOfficeLookup.Clear();
                
                obj.PerformedByOfficeLookup.Add(PerformedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.PerformedByOfficeLookup.AddRange(PerformedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfPerformedByOffice))
                    
                    .ToList());
                
                if (obj.idfPerformedByOffice != null && obj.idfPerformedByOffice != 0)
                {
                    obj.PerformedByOffice = obj.PerformedByOfficeLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfPerformedByOffice);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, PerformedByOfficeAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_CollectedByOffice(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.CollectedByOfficeLookup.Clear();
                
                obj.CollectedByOfficeLookup.Add(CollectedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.CollectedByOfficeLookup.AddRange(CollectedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfFieldCollectedByOffice))
                    
                    .ToList());
                
                if (obj.idfFieldCollectedByOffice != null && obj.idfFieldCollectedByOffice != 0)
                {
                    obj.CollectedByOffice = obj.CollectedByOfficeLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfFieldCollectedByOffice);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, CollectedByOfficeAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_CollectedByPerson(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.CollectedByPersonLookup.Clear();
                
                obj.CollectedByPersonLookup.Add(CollectedByPersonAccessor.CreateNewT(manager, null));
                
                obj.CollectedByPersonLookup.AddRange(CollectedByPersonAccessor.SelectLookupList(manager
                    
                    , new Func<LaboratorySectionItem, long>(c => c.idfFieldCollectedByOffice ?? -1)(obj)
                            
                    , null
                    , false
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfFieldCollectedByPerson))
                    
                    .ToList());
                
                if (obj.idfFieldCollectedByPerson != null && obj.idfFieldCollectedByPerson != 0)
                {
                    obj.CollectedByPerson = obj.CollectedByPersonLookup
                        .SingleOrDefault(c => c.idfPerson == obj.idfFieldCollectedByPerson);
                    
                }
              
                LookupManager.AddObject("PersonLookup", obj, CollectedByPersonAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_CaseType(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.CaseTypeLookup.Clear();
                
                obj.CaseTypeLookup.Add(CaseTypeAccessor.CreateNewT(manager, null));
                
                obj.CaseTypeLookup.AddRange(CaseTypeAccessor.rftCaseType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCaseType))
                    
                    .ToList());
                
                if (obj.idfsCaseType != null && obj.idfsCaseType != 0)
                {
                    obj.CaseType = obj.CaseTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsCaseType);
                    
                }
              
                LookupManager.AddObject("rftCaseType", obj, CaseTypeAccessor.GetType(), "rftCaseType_SelectList"
                  , "SelectLookupList");
              
            }
            
            public void LoadLookup_DestructionMethod(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.DestructionMethodLookup.Clear();
                
                obj.DestructionMethodLookup.Add(DestructionMethodAccessor.CreateNewT(manager, null));
                
                obj.DestructionMethodLookup.AddRange(DestructionMethodAccessor.rftDestructionMethod_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsDestructionMethod))
                    
                    .ToList());
                
                if (obj.idfsDestructionMethod != null && obj.idfsDestructionMethod != 0)
                {
                    obj.DestructionMethod = obj.DestructionMethodLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsDestructionMethod);
                    
                }
              
                LookupManager.AddObject("rftDestructionMethod", obj, DestructionMethodAccessor.GetType(), "rftDestructionMethod_SelectList"
                  , "SelectLookupList");
              
            }
            
            public void LoadLookup_SampleKind(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.SampleKindLookup.Clear();
                
                obj.SampleKindLookup.Add(SampleKindAccessor.CreateNewT(manager, null));
                
                obj.SampleKindLookup.AddRange(SampleKindAccessor.rftSampleKind_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSampleKind))
                    
                    .ToList());
                
                if (obj.idfsSampleKind != null && obj.idfsSampleKind != 0)
                {
                    obj.SampleKind = obj.SampleKindLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsSampleKind);
                    
                }
              
                LookupManager.AddObject("rftSampleKind", obj, SampleKindAccessor.GetType(), "rftSampleKind_SelectList"
                  , "SelectLookupList");
              
            }
            
            public void LoadLookup_SpeciesVectorInfo(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.SpeciesVectorInfoLookup.Clear();
                
                obj.SpeciesVectorInfoLookup.Add(SpeciesVectorInfoAccessor.CreateNewT(manager, null));
                
                obj.SpeciesVectorInfoLookup.AddRange(SpeciesVectorInfoAccessor.SelectLookupList(manager
                    
                    , new Func<LaboratorySectionItem, long?>(c => c.idfCaseOrSession)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfSpeciesVectorInfo == obj.idfSpeciesVectorInfo))
                    
                    .ToList());
                
                if (obj.idfSpeciesVectorInfo != null && obj.idfSpeciesVectorInfo != 0)
                {
                    obj.SpeciesVectorInfo = obj.SpeciesVectorInfoLookup
                        .SingleOrDefault(c => c.idfSpeciesVectorInfo == obj.idfSpeciesVectorInfo);
                    
                }
              
                LookupManager.AddObject("SpeciesVectorInfoLookup", obj, SpeciesVectorInfoAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_Department(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.DepartmentLookup.Clear();
                
                obj.DepartmentLookup.Add(DepartmentAccessor.CreateNewT(manager, null));
                
                obj.DepartmentLookup.AddRange(DepartmentAccessor.SelectLookupList(manager
                    
                    , new Func<LaboratorySectionItem, long>(c => eidss.model.Core.EidssSiteContext.Instance.OrganizationID)(obj)
                            
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
            
            public void LoadLookup_Freezer(DbManagerProxy manager, LaboratorySectionItem obj)
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
            
            public void LoadLookup_TestedByOffice(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.TestedByOfficeLookup.Clear();
                
                obj.TestedByOfficeLookup.Add(TestedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.TestedByOfficeLookup.AddRange(TestedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfTestedByOffice))
                    
                    .ToList());
                
                if (obj.idfTestedByOffice != null && obj.idfTestedByOffice != 0)
                {
                    obj.TestedByOffice = obj.TestedByOfficeLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfTestedByOffice);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, TestedByOfficeAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_TestedByPerson(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.TestedByPersonLookup.Clear();
                
                obj.TestedByPersonLookup.Add(TestedByPersonAccessor.CreateNewT(manager, null));
                
                obj.TestedByPersonLookup.AddRange(TestedByPersonAccessor.SelectLookupList(manager
                    
                    , new Func<LaboratorySectionItem, long>(c => (long)EidssUserContext.User.OrganizationID /*c.idfTestedByOffice ?? -1*/)(obj)
                            
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
              
                LookupManager.AddObject("PersonLookup", obj, TestedByPersonAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_ResultEnteredByOffice(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.ResultEnteredByOfficeLookup.Clear();
                
                obj.ResultEnteredByOfficeLookup.Add(ResultEnteredByOfficeAccessor.CreateNewT(manager, null));
                
                obj.ResultEnteredByOfficeLookup.AddRange(ResultEnteredByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfResultEnteredByOffice))
                    
                    .ToList());
                
                if (obj.idfResultEnteredByOffice != null && obj.idfResultEnteredByOffice != 0)
                {
                    obj.ResultEnteredByOffice = obj.ResultEnteredByOfficeLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfResultEnteredByOffice);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, ResultEnteredByOfficeAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_ResultEnteredByPerson(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.ResultEnteredByPersonLookup.Clear();
                
                obj.ResultEnteredByPersonLookup.Add(ResultEnteredByPersonAccessor.CreateNewT(manager, null));
                
                obj.ResultEnteredByPersonLookup.AddRange(ResultEnteredByPersonAccessor.SelectLookupList(manager
                    
                    , new Func<LaboratorySectionItem, long>(c => (long)EidssUserContext.User.OrganizationID /*c.idfResultEnteredByOffice ?? -1*/)(obj)
                            
                    , null
                    , false
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfResultEnteredByPerson))
                    
                    .ToList());
                
                if (obj.idfResultEnteredByPerson != null && obj.idfResultEnteredByPerson != 0)
                {
                    obj.ResultEnteredByPerson = obj.ResultEnteredByPersonLookup
                        .SingleOrDefault(c => c.idfPerson == obj.idfResultEnteredByPerson);
                    
                }
              
                LookupManager.AddObject("PersonLookup", obj, ResultEnteredByPersonAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_ValidatedByOffice(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.ValidatedByOfficeLookup.Clear();
                
                obj.ValidatedByOfficeLookup.Add(ValidatedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.ValidatedByOfficeLookup.AddRange(ValidatedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfValidatedByOffice))
                    
                    .ToList());
                
                if (obj.idfValidatedByOffice != null && obj.idfValidatedByOffice != 0)
                {
                    obj.ValidatedByOffice = obj.ValidatedByOfficeLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfValidatedByOffice);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, ValidatedByOfficeAccessor.GetType(), "SelectLookupList");
              
            }
            
            public void LoadLookup_ValidatedByPerson(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                obj.ValidatedByPersonLookup.Clear();
                
                obj.ValidatedByPersonLookup.Add(ValidatedByPersonAccessor.CreateNewT(manager, null));
                
                obj.ValidatedByPersonLookup.AddRange(ValidatedByPersonAccessor.SelectLookupList(manager
                    
                    , new Func<LaboratorySectionItem, long>(c => (long)EidssUserContext.User.OrganizationID /*c.idfValidatedByOffice ?? -1*/)(obj)
                            
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
              
                LookupManager.AddObject("PersonLookup", obj, ValidatedByPersonAccessor.GetType(), "SelectLookupList");
              
            }
            

            private void _LoadLookups(DbManagerProxy manager, LaboratorySectionItem obj)
            {
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_DiagnosisForTest(manager, obj);
                
                LoadLookup_SampleType(manager, obj);
                
                LoadLookup_SampleTypeFiltered(manager, obj);
                
                LoadLookup_DerivativeType(manager, obj);
                
                LoadLookup_AccessionCondition(manager, obj);
                
                LoadLookup_TestNameForSearch(manager, obj);
                
                LoadLookup_TestNameRef(manager, obj);
                
                LoadLookup_TestResultRef(manager, obj);
                
                LoadLookup_TestResultForAmend(manager, obj);
                
                LoadLookup_TestResultDummy(manager, obj);
                
                LoadLookup_TestCategoryRef(manager, obj);
                
                LoadLookup_TestStatusShort(manager, obj);
                
                LoadLookup_TestStatusForSearch(manager, obj);
                
                LoadLookup_TestStatusFull(manager, obj);
                
                LoadLookup_SampleStatus(manager, obj);
                
                LoadLookup_SampleStatusFull(manager, obj);
                
                LoadLookup_AccessionByPerson(manager, obj);
                
                LoadLookup_SendToOffice(manager, obj);
                
                LoadLookup_SendToOfficeOut(manager, obj);
                
                LoadLookup_PerformedByOffice(manager, obj);
                
                LoadLookup_CollectedByOffice(manager, obj);
                
                LoadLookup_CollectedByPerson(manager, obj);
                
                LoadLookup_CaseType(manager, obj);
                
                LoadLookup_DestructionMethod(manager, obj);
                
                LoadLookup_SampleKind(manager, obj);
                
                LoadLookup_SpeciesVectorInfo(manager, obj);
                
                LoadLookup_Department(manager, obj);
                
                LoadLookup_Freezer(manager, obj);
                
                LoadLookup_TestedByOffice(manager, obj);
                
                LoadLookup_TestedByPerson(manager, obj);
                
                LoadLookup_ResultEnteredByOffice(manager, obj);
                
                LoadLookup_ResultEnteredByPerson(manager, obj);
                
                LoadLookup_ValidatedByOffice(manager, obj);
                
                LoadLookup_ValidatedByPerson(manager, obj);
                
            }
    
            [SprocName("spLaboratorySectionItem_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strBarcode", "bTestInserted", "bTestInsertedFirst")] LaboratorySectionItem obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strBarcode", "bTestInserted", "bTestInsertedFirst")] LaboratorySectionItem obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    LaboratorySectionItem bo = obj as LaboratorySectionItem;
                    
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
                    
                    long mainObject = bo.ID;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        
                        if (new Func<LaboratorySectionItem, bool>(c => c.idfHumanCase.HasValue && c.idfHumanCase.Value != 0 && c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized && (c.idfsTestStatus_Original != (long)eidss.model.Enums.TestStatus.Finalized || c.bTestInserted || c.bTestInsertedFirst))(bo))
                          
                            manager.SetEventParams(true, new object[] { EventType.HumanTestResultRegistrationLocal, bo.idfHumanCase, "" });
                        
                        if (new Func<LaboratorySectionItem, bool>(c => c.idfVetCase.HasValue && c.idfVetCase.Value != 0 && c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized && (c.idfsTestStatus_Original != (long)eidss.model.Enums.TestStatus.Finalized || c.bTestInserted || c.bTestInsertedFirst))(bo))
                          
                            manager.SetEventParams(true, new object[] { EventType.VetCaseTestResultRegistrationLocal, bo.idfVetCase, "" });
                        
                        if (new Func<LaboratorySectionItem, bool>(c => c.idfMonitoringSession.HasValue && c.idfMonitoringSession.Value != 0 && c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized && (c.idfsTestStatus_Original != (long)eidss.model.Enums.TestStatus.Finalized || c.bTestInserted || c.bTestInsertedFirst))(bo))
                          
                            manager.SetEventParams(true, new object[] { EventType.AsSessionTestResultRegistrationLocal, bo.idfMonitoringSession, "" });
                        
                        if (new Func<LaboratorySectionItem, bool>(c => c.idfVectorSurveillanceSession.HasValue && c.idfVectorSurveillanceSession.Value != 0 && c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized && (c.idfsTestStatus_Original != (long)eidss.model.Enums.TestStatus.Finalized || c.bTestInserted || c.bTestInsertedFirst))(bo))
                          
                            manager.SetEventParams(true, new object[] { EventType.VsSessionTestResultRegistrationLocal, bo.idfVectorSurveillanceSession, "" });
                        
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        
                        if (new Func<LaboratorySectionItem, bool>(c => c.idfHumanCase.HasValue && c.idfHumanCase.Value != 0 && c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized && (c.idfsTestStatus_Original != (long)eidss.model.Enums.TestStatus.Finalized || c.bTestInserted || c.bTestInsertedFirst))(bo))
                          
                            manager.SetEventParams(true, new object[] { EventType.HumanTestResultRegistrationLocal, bo.idfHumanCase, "" });
                        
                        if (new Func<LaboratorySectionItem, bool>(c => c.idfVetCase.HasValue && c.idfVetCase.Value != 0 && c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized && (c.idfsTestStatus_Original != (long)eidss.model.Enums.TestStatus.Finalized || c.bTestInserted || c.bTestInsertedFirst))(bo))
                          
                            manager.SetEventParams(true, new object[] { EventType.VetCaseTestResultRegistrationLocal, bo.idfVetCase, "" });
                        
                        if (new Func<LaboratorySectionItem, bool>(c => c.idfMonitoringSession.HasValue && c.idfMonitoringSession.Value != 0 && c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized && (c.idfsTestStatus_Original != (long)eidss.model.Enums.TestStatus.Finalized || c.bTestInserted || c.bTestInsertedFirst))(bo))
                          
                            manager.SetEventParams(true, new object[] { EventType.AsSessionTestResultRegistrationLocal, bo.idfMonitoringSession, "" });
                        
                        if (new Func<LaboratorySectionItem, bool>(c => c.idfVectorSurveillanceSession.HasValue && c.idfVectorSurveillanceSession.Value != 0 && c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized && (c.idfsTestStatus_Original != (long)eidss.model.Enums.TestStatus.Finalized || c.bTestInserted || c.bTestInsertedFirst))(bo))
                          
                            manager.SetEventParams(true, new object[] { EventType.VsSessionTestResultRegistrationLocal, bo.idfVectorSurveillanceSession, "" });
                        
                        if (new Func<LaboratorySectionItem, bool>(c => c.idfTesting.HasValue && c.idfTesting.Value != 0 && c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized && (c.idfsTestStatus_Original != (long)eidss.model.Enums.TestStatus.Finalized || c.bTestInserted) && c.idfsSampleKind == (long)eidss.model.Enums.SampleKind.TranferredIn)(bo))
                          
                            manager.SetEventParams(true, new object[] { EventType.TestResultForSampleTransferredIn, bo.idfTesting, "" });
                        
                        if (new Func<LaboratorySectionItem, bool>(c => c.idfHumanCase.HasValue && c.idfHumanCase.Value != 0 && c.AmendmentHistory.Count(i => i.IsNew && !i.IsMarkedToDelete) > 0)(bo))
                          
                            manager.SetEventParams(true, new object[] { EventType.HumanTestResultAmendmentLocal, bo.idfHumanCase, "" });
                        
                        if (new Func<LaboratorySectionItem, bool>(c => c.idfVetCase.HasValue && c.idfVetCase.Value != 0 && c.AmendmentHistory.Count(i => i.IsNew && !i.IsMarkedToDelete) > 0)(bo))
                          
                            manager.SetEventParams(true, new object[] { EventType.VetCaseTestResultAmendmentLocal, bo.idfVetCase, "" });
                        
                        if (new Func<LaboratorySectionItem, bool>(c => c.idfMonitoringSession.HasValue && c.idfMonitoringSession.Value != 0 && c.AmendmentHistory.Count(i => i.IsNew && !i.IsMarkedToDelete) > 0)(bo))
                          
                            manager.SetEventParams(true, new object[] { EventType.AsSessionTestResultAmendmentLocal, bo.idfMonitoringSession, "" });
                        
                        if (new Func<LaboratorySectionItem, bool>(c => c.idfVectorSurveillanceSession.HasValue && c.idfVectorSurveillanceSession.Value != 0 && c.AmendmentHistory.Count(i => i.IsNew && !i.IsMarkedToDelete) > 0)(bo))
                          
                            manager.SetEventParams(true, new object[] { EventType.VsSessionTestResultAmendmentLocal, bo.idfVectorSurveillanceSession, "" });
                        
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
                    bSuccess = _PostNonTransaction(manager, obj as LaboratorySectionItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, LaboratorySectionItem obj, bool bChildObject) 
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
              if (obj.IsNew && obj.bIsMyPref)
                Accessor.Instance(null).MenuAddToPreferences(manager, obj);
            
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(LaboratorySectionItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, LaboratorySectionItem obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(LaboratorySectionItem obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<LaboratorySectionItem>(obj, "datSendDate", c => true, 
      obj.datSendDate,
      obj.GetType(),
      false, listdatSendDate => {
    listdatSendDate.Add(
    new ChainsValidatorDateTime<LaboratorySectionItem>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }).Process();
  
    new ChainsValidatorDateTime<LaboratorySectionItem>(obj, "datFieldCollectionDate", c => true, 
      obj.datFieldCollectionDate,
      obj.GetType(),
      false, listdatFieldCollectionDate => {
    listdatFieldCollectionDate.Add(
    new ChainsValidatorDateTime<LaboratorySectionItem>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }).Process();
  
    new ChainsValidatorDateTime<LaboratorySectionItem>(obj, "datFieldCollectionDate", c => true, 
      obj.datFieldCollectionDate,
      obj.GetType(),
      false, listdatFieldCollectionDate => {
    listdatFieldCollectionDate.Add(
    new ChainsValidatorDateTime<LaboratorySectionItem>(obj, "datFieldSentDate", c => true, 
      obj.datFieldSentDate,
      obj.GetType(),
      false, listdatFieldSentDate => {
    listdatFieldSentDate.Add(
    new ChainsValidatorDateTime<LaboratorySectionItem>(obj, "datAccession", c => true, 
      obj.datAccession,
      obj.GetType(),
      false, listdatAccession => {
    listdatAccession.Add(
    new ChainsValidatorDateTime<LaboratorySectionItem>(obj, "datStartedDate", c => true, 
      obj.datStartedDate,
      obj.GetType(),
      false, listdatStartedDate => {
    listdatStartedDate.Add(
    new ChainsValidatorDateTime<LaboratorySectionItem>(obj, "datConcludedDate", c => true, 
      obj.datConcludedDate,
      obj.GetType(),
      false, listdatConcludedDate => {
    listdatConcludedDate.Add(
    new ChainsValidatorDateTime<LaboratorySectionItem>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }));
  
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
            protected bool ChainsValidate(LaboratorySectionItem obj, bool bRethrowException)
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
                return Validate(manager, obj as LaboratorySectionItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LaboratorySectionItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "intNewSample", "intNewSample","",
                false
              )).Validate(c => (int)c.intNewMode > 0, obj, obj.intNewSample);
            
                (new RequiredValidator( "DerivativeType", "DerivativeType","",
                false
              )).Validate(c => c.intNewMode == LabNewModeEnum.CreateDerivative, obj, obj.DerivativeType);
            
                (new RequiredValidator( "strCalculatedCaseID", "strCalculatedCaseID","strCaseIDSessionID",
                false
              )).Validate(c => c.intNewMode == LabNewModeEnum.CreateSample, obj, obj.strCalculatedCaseID);
            
                (new RequiredValidator( "SampleTypeFiltered", "SampleTypeFiltered","",
                false
              )).Validate(c => c.intNewMode == LabNewModeEnum.CreateSample, obj, obj.SampleTypeFiltered);
            
                (new RequiredValidator( "strComments", "strComments","strComment",
                false
              )).Validate(c => c.intNewMode == LabNewModeEnum.Accept, obj, obj.strComments);
            
                (new PredicateValidator("errCommentsIsTooShort", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.intNewMode != LabNewModeEnum.Accept || (c.intNewMode == LabNewModeEnum.Accept && c.strComments.Length >= 6)
                    );
            
                (new RequiredValidator( "strFieldBarcode", "strFieldBarcode","",
                false
              )).Validate(c => c.intNewMode == LabNewModeEnum.GroupAccessionIn, obj, obj.strFieldBarcode);
            
                (new RequiredValidator( "SendToOfficeOut", "SendToOfficeOut","TransferTo",
                false
              )).Validate(c => c.intNewMode == LabNewModeEnum.TransferOutSample, obj, obj.SendToOfficeOut);
            
                (new RequiredValidator( "DiagnosisForTest", "DiagnosisForTest","TestDiagnosisName",
                false
              )).Validate(c => (c.intNewMode == LabNewModeEnum.AssignTest) || (c.intNewMode == LabNewModeEnum.None && (c.isTestNotStartedBefore || c.isTestFinalExternalBefore) && !c.idfsDiagnosis.HasValue), obj, obj.DiagnosisForTest);
            
                (new RequiredValidator( "TestNameRef", "TestNameRef","TestName",
                false
              )).Validate(c =>  (c.intNewMode == LabNewModeEnum.AssignTest) || (c.intNewMode == LabNewModeEnum.None && c.isTestFinalExternalBefore), obj, obj.TestNameRef);
            
                (new RequiredValidator( "strReason", "strReason","strReasonChangeTestResult",
                false
              )).Validate(c => c.intNewMode == LabNewModeEnum.AmendTestResult, obj, obj.strReason);
            
                (new PredicateValidator("errReasonForChangeIsTooShort", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.intNewMode != LabNewModeEnum.AmendTestResult || (c.intNewMode == LabNewModeEnum.AmendTestResult && c.strReason.Length >= 6)
                    );
            
                (new RequiredValidator( "TestResultForAmend", "TestResultForAmend","strNewTestResult",
                false
              )).Validate(c => c.intNewMode == LabNewModeEnum.AmendTestResult, obj, obj.TestResultForAmend);
            
                (new PredicateValidator("New_test_result_as_old_one", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.intNewMode != LabNewModeEnum.AmendTestResult || (c.intNewMode == LabNewModeEnum.AmendTestResult && c.idfsOldTestResult != c.idfsTestResult)
                    );
            
                CheckSamplesForGroupAccesionInExists(manager, obj);
            
                (new RequiredValidator( "datStartedDate", "datStartedDate","",
                false
              )).Validate(c => c.idfTesting.HasValue && !c.bTestDeleted && (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary || (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/)), obj, obj.datStartedDate);
            
                (new RequiredValidator( "datConcludedDate", "datConcludedDate","",
                false
              )).Validate(c => c.idfTesting.HasValue && !c.bTestDeleted && (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary || (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/)), obj, obj.datConcludedDate);
            
                (new RequiredValidator( "idfsTestStatus", "idfsTestStatus","TestStatus",
                false
              )).Validate(c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/), obj, obj.idfsTestStatus);
            
                (new RequiredValidator( "idfsTestResult", "idfsTestResult","TestResult",
                false
              )).Validate(c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/), obj, obj.idfsTestResult);
            
                (new RequiredValidator( "strContactPerson", "strContactPerson","strContact",
                false
              )).Validate(c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/), obj, obj.strContactPerson);
            
                (new RequiredValidator( "strCondition", "strCondition","strAccessionInComment",
                false
              )).Validate(c => c.intNewMode == LabNewModeEnum.None && c.idfsAccessionCondition.HasValue && (c.idfsAccessionCondition.Value == (long)eidss.model.Enums.AccessionConditionEnum.AcceptedInPoorCondition || c.idfsAccessionCondition.Value == (long)eidss.model.Enums.AccessionConditionEnum.Rejected), obj, obj.strCondition);
            
                (new PredicateValidator("errAccessionInCommentIsTooShort", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => !(c.intNewMode == LabNewModeEnum.None && c.idfsAccessionCondition.HasValue && (c.idfsAccessionCondition.Value == (long)eidss.model.Enums.AccessionConditionEnum.AcceptedInPoorCondition || c.idfsAccessionCondition.Value == (long)eidss.model.Enums.AccessionConditionEnum.Rejected) && c.strCondition.Length < 6)
                    );
            
                (new RequiredValidator( "SpeciesVectorInfo", "SpeciesVectorInfo","strPatientSessionVectorInfo",
                false
              )).Validate(c => c.intNewMode == LabNewModeEnum.None && (c.intCaseHACode != (long)eidss.model.Enums.HACode.Human && c.bIsCreateNewSample), obj, obj.SpeciesVectorInfo);
            
                CustomValidations(obj);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                (new RequiredValidator( "idfsDiagnosis", "idfsDiagnosis","TestDiagnosisName",
                false
              )).Validate(c => !c.bTestDeleted && c.idfsTestStatus.HasValue && c.idfsTestStatus != (long)eidss.model.Enums.TestStatus.NotStarted && !(/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/), obj, obj.idfsDiagnosis);
            
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
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(LaboratorySectionItem obj)
            {
            
                obj
                    .AddRequired("intNewSample", c => (int)c.intNewMode > 0);
                    
                obj
                    .AddRequired("DerivativeType", c => c.intNewMode == LabNewModeEnum.CreateDerivative);
                    
                obj
                    .AddRequired("strCalculatedCaseID", c => c.intNewMode == LabNewModeEnum.CreateSample);
                    
                obj
                    .AddRequired("SampleTypeFiltered", c => c.intNewMode == LabNewModeEnum.CreateSample);
                    
                obj
                    .AddRequired("strComments", c => c.intNewMode == LabNewModeEnum.Accept);
                    
                obj
                    .AddRequired("strFieldBarcode", c => c.intNewMode == LabNewModeEnum.GroupAccessionIn);
                    
                obj
                    .AddRequired("SendToOfficeOut", c => c.intNewMode == LabNewModeEnum.TransferOutSample);
                    
                obj
                    .AddRequired("DiagnosisForTest", c => (c.intNewMode == LabNewModeEnum.AssignTest) || (c.intNewMode == LabNewModeEnum.None && (c.isTestNotStartedBefore || c.isTestFinalExternalBefore) && !c.idfsDiagnosis.HasValue));
                    
                obj
                    .AddRequired("TestNameRef", c =>  (c.intNewMode == LabNewModeEnum.AssignTest) || (c.intNewMode == LabNewModeEnum.None && c.isTestFinalExternalBefore));
                    
                obj
                    .AddRequired("strReason", c => c.intNewMode == LabNewModeEnum.AmendTestResult);
                    
                obj
                    .AddRequired("TestResultForAmend", c => c.intNewMode == LabNewModeEnum.AmendTestResult);
                    
                obj
                    .AddRequired("datStartedDate", c => c.idfTesting.HasValue && !c.bTestDeleted && (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary || (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/)));
                    
                obj
                    .AddRequired("datConcludedDate", c => c.idfTesting.HasValue && !c.bTestDeleted && (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary || (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/)));
                    
                obj
                    .AddRequired("idfsTestStatus", c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/));
                    
                  obj
                    .AddRequired("TestStatusFull", c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/));
                
                obj
                    .AddRequired("idfsTestResult", c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/));
                    
                  obj
                    .AddRequired("TestResultRef", c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/));
                
                obj
                    .AddRequired("strContactPerson", c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/));
                    
                obj
                    .AddRequired("strCondition", c => c.intNewMode == LabNewModeEnum.None && c.idfsAccessionCondition.HasValue && (c.idfsAccessionCondition.Value == (long)eidss.model.Enums.AccessionConditionEnum.AcceptedInPoorCondition || c.idfsAccessionCondition.Value == (long)eidss.model.Enums.AccessionConditionEnum.Rejected));
                    
                obj
                    .AddRequired("SpeciesVectorInfo", c => c.intNewMode == LabNewModeEnum.None && (c.intCaseHACode != (long)eidss.model.Enums.HACode.Human && c.bIsCreateNewSample));
                    
            }
    
    private void _SetupPersonalDataRestrictions(LaboratorySectionItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LaboratorySectionItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LaboratorySectionItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LaboratorySectionItemDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private LaboratorySectionItem m_obj;
            internal Permissions(LaboratorySectionItem obj)
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
            public static string spSelect = "fn_LaboratorySection_SelectList";
            public static string spCount = "";
            public static string spPost = "spLaboratorySectionItem_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LaboratorySectionItem, bool>> RequiredByField = new Dictionary<string, Func<LaboratorySectionItem, bool>>();
            public static Dictionary<string, Func<LaboratorySectionItem, bool>> RequiredByProperty = new Dictionary<string, Func<LaboratorySectionItem, bool>>();
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
                
                Sizes.Add(_str_strDiagnosisName, 64);
                Sizes.Add(_str_strParentMaterial, 200);
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strCalculatedCaseID, 200);
                Sizes.Add(_str_strCalculatedHumanName, 700);
                Sizes.Add(_str_strSampleNote, 500);
                Sizes.Add(_str_strCondition, 200);
                Sizes.Add(_str_HumanName, 700);
                Sizes.Add(_str_strPatientName, 700);
                Sizes.Add(_str_strFarmOwner, 700);
                Sizes.Add(_str_strRegion, 64);
                Sizes.Add(_str_strRayon, 64);
                Sizes.Add(_str_strNote, 500);
                Sizes.Add(_str_strContactPerson, 200);
                Sizes.Add(_str_strBatchID, 200);
                Sizes.Add(_str_strSampleStatus, 64);
                Sizes.Add(_str_strSampleName, 64);
                Sizes.Add(_str_strSampleConditionReceivedStatus, 64);
                Sizes.Add(_str_strTestName, 64);
                Sizes.Add(_str_strTestStatus, 64);
                Sizes.Add(_str_strTestResult, 64);
                Sizes.Add(_str_strTestCategory, 64);
                Sizes.Add(_str_strComments, 200);
                Sizes.Add(_str_strReason, 200);
                if (!RequiredByField.ContainsKey("intNewSample")) RequiredByField.Add("intNewSample", c => (int)c.intNewMode > 0);
                if (!RequiredByProperty.ContainsKey("intNewSample")) RequiredByProperty.Add("intNewSample", c => (int)c.intNewMode > 0);
                
                if (!RequiredByField.ContainsKey("DerivativeType")) RequiredByField.Add("DerivativeType", c => c.intNewMode == LabNewModeEnum.CreateDerivative);
                if (!RequiredByProperty.ContainsKey("DerivativeType")) RequiredByProperty.Add("DerivativeType", c => c.intNewMode == LabNewModeEnum.CreateDerivative);
                
                if (!RequiredByField.ContainsKey("strCalculatedCaseID")) RequiredByField.Add("strCalculatedCaseID", c => c.intNewMode == LabNewModeEnum.CreateSample);
                if (!RequiredByProperty.ContainsKey("strCalculatedCaseID")) RequiredByProperty.Add("strCalculatedCaseID", c => c.intNewMode == LabNewModeEnum.CreateSample);
                
                if (!RequiredByField.ContainsKey("SampleTypeFiltered")) RequiredByField.Add("SampleTypeFiltered", c => c.intNewMode == LabNewModeEnum.CreateSample);
                if (!RequiredByProperty.ContainsKey("SampleTypeFiltered")) RequiredByProperty.Add("SampleTypeFiltered", c => c.intNewMode == LabNewModeEnum.CreateSample);
                
                if (!RequiredByField.ContainsKey("strComments")) RequiredByField.Add("strComments", c => c.intNewMode == LabNewModeEnum.Accept);
                if (!RequiredByProperty.ContainsKey("strComments")) RequiredByProperty.Add("strComments", c => c.intNewMode == LabNewModeEnum.Accept);
                
                if (!RequiredByField.ContainsKey("strFieldBarcode")) RequiredByField.Add("strFieldBarcode", c => c.intNewMode == LabNewModeEnum.GroupAccessionIn);
                if (!RequiredByProperty.ContainsKey("strFieldBarcode")) RequiredByProperty.Add("strFieldBarcode", c => c.intNewMode == LabNewModeEnum.GroupAccessionIn);
                
                if (!RequiredByField.ContainsKey("SendToOfficeOut")) RequiredByField.Add("SendToOfficeOut", c => c.intNewMode == LabNewModeEnum.TransferOutSample);
                if (!RequiredByProperty.ContainsKey("SendToOfficeOut")) RequiredByProperty.Add("SendToOfficeOut", c => c.intNewMode == LabNewModeEnum.TransferOutSample);
                
                if (!RequiredByField.ContainsKey("DiagnosisForTest")) RequiredByField.Add("DiagnosisForTest", c => (c.intNewMode == LabNewModeEnum.AssignTest) || (c.intNewMode == LabNewModeEnum.None && (c.isTestNotStartedBefore || c.isTestFinalExternalBefore) && !c.idfsDiagnosis.HasValue));
                if (!RequiredByProperty.ContainsKey("DiagnosisForTest")) RequiredByProperty.Add("DiagnosisForTest", c => (c.intNewMode == LabNewModeEnum.AssignTest) || (c.intNewMode == LabNewModeEnum.None && (c.isTestNotStartedBefore || c.isTestFinalExternalBefore) && !c.idfsDiagnosis.HasValue));
                
                if (!RequiredByField.ContainsKey("TestNameRef")) RequiredByField.Add("TestNameRef", c =>  (c.intNewMode == LabNewModeEnum.AssignTest) || (c.intNewMode == LabNewModeEnum.None && c.isTestFinalExternalBefore));
                if (!RequiredByProperty.ContainsKey("TestNameRef")) RequiredByProperty.Add("TestNameRef", c =>  (c.intNewMode == LabNewModeEnum.AssignTest) || (c.intNewMode == LabNewModeEnum.None && c.isTestFinalExternalBefore));
                
                if (!RequiredByField.ContainsKey("strReason")) RequiredByField.Add("strReason", c => c.intNewMode == LabNewModeEnum.AmendTestResult);
                if (!RequiredByProperty.ContainsKey("strReason")) RequiredByProperty.Add("strReason", c => c.intNewMode == LabNewModeEnum.AmendTestResult);
                
                if (!RequiredByField.ContainsKey("TestResultForAmend")) RequiredByField.Add("TestResultForAmend", c => c.intNewMode == LabNewModeEnum.AmendTestResult);
                if (!RequiredByProperty.ContainsKey("TestResultForAmend")) RequiredByProperty.Add("TestResultForAmend", c => c.intNewMode == LabNewModeEnum.AmendTestResult);
                
                if (!RequiredByField.ContainsKey("datStartedDate")) RequiredByField.Add("datStartedDate", c => c.idfTesting.HasValue && !c.bTestDeleted && (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary || (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/)));
                if (!RequiredByProperty.ContainsKey("datStartedDate")) RequiredByProperty.Add("datStartedDate", c => c.idfTesting.HasValue && !c.bTestDeleted && (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary || (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/)));
                
                if (!RequiredByField.ContainsKey("datConcludedDate")) RequiredByField.Add("datConcludedDate", c => c.idfTesting.HasValue && !c.bTestDeleted && (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary || (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/)));
                if (!RequiredByProperty.ContainsKey("datConcludedDate")) RequiredByProperty.Add("datConcludedDate", c => c.idfTesting.HasValue && !c.bTestDeleted && (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary || (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/)));
                
                if (!RequiredByField.ContainsKey("idfsTestStatus")) RequiredByField.Add("idfsTestStatus", c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/));
                if (!RequiredByProperty.ContainsKey("idfsTestStatus")) RequiredByProperty.Add("idfsTestStatus", c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/));
                
                if (!RequiredByField.ContainsKey("idfsTestResult")) RequiredByField.Add("idfsTestResult", c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/));
                if (!RequiredByProperty.ContainsKey("idfsTestResult")) RequiredByProperty.Add("idfsTestResult", c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/));
                
                if (!RequiredByField.ContainsKey("strContactPerson")) RequiredByField.Add("strContactPerson", c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/));
                if (!RequiredByProperty.ContainsKey("strContactPerson")) RequiredByProperty.Add("strContactPerson", c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/));
                
                if (!RequiredByField.ContainsKey("strCondition")) RequiredByField.Add("strCondition", c => c.intNewMode == LabNewModeEnum.None && c.idfsAccessionCondition.HasValue && (c.idfsAccessionCondition.Value == (long)eidss.model.Enums.AccessionConditionEnum.AcceptedInPoorCondition || c.idfsAccessionCondition.Value == (long)eidss.model.Enums.AccessionConditionEnum.Rejected));
                if (!RequiredByProperty.ContainsKey("strCondition")) RequiredByProperty.Add("strCondition", c => c.intNewMode == LabNewModeEnum.None && c.idfsAccessionCondition.HasValue && (c.idfsAccessionCondition.Value == (long)eidss.model.Enums.AccessionConditionEnum.AcceptedInPoorCondition || c.idfsAccessionCondition.Value == (long)eidss.model.Enums.AccessionConditionEnum.Rejected));
                
                if (!RequiredByField.ContainsKey("SpeciesVectorInfo")) RequiredByField.Add("SpeciesVectorInfo", c => c.intNewMode == LabNewModeEnum.None && (c.intCaseHACode != (long)eidss.model.Enums.HACode.Human && c.bIsCreateNewSample));
                if (!RequiredByProperty.ContainsKey("SpeciesVectorInfo")) RequiredByProperty.Add("SpeciesVectorInfo", c => c.intNewMode == LabNewModeEnum.None && (c.intCaseHACode != (long)eidss.model.Enums.HACode.Human && c.bIsCreateNewSample));
                
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSampleStatus",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "SampleStatus",
                    null, null, c => false, true, SearchPanelLocation.Main, false, null, "SampleStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datSampleStatusDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, true, 
                    "datSampleStatusDate",
                    c => !(c as LaboratorySectionItem).bIsMyPref ? DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter) : default(DateTime?), null, c => !(c as LaboratorySectionItem).bIsMyPref, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFieldBarcode",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strFieldBarcode",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strCalculatedCaseID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strCaseIDSessionID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfSendToOffice",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strOrganizationSendTo",
                    c => !(c as LaboratorySectionItem).bIsMyPref ? (c as LaboratorySectionItem).SendToOfficeLookup.FirstOrDefault(i => i.idfInstitution == (long)EidssUserContext.User.OrganizationID) : null, null, c => false, false, SearchPanelLocation.Main, false, null, "SendToOfficeLookup", typeof(OrganizationLookup), (o) => { var c = (OrganizationLookup)o; return c.idfInstitution; }, (o) => { var c = (OrganizationLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfSendToOfficeOut",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strOrganizationTransferTo",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "SendToOfficeOutLookup", typeof(OrganizationLookup), (o) => { var c = (OrganizationLookup)o; return c.idfInstitution; }, (o) => { var c = (OrganizationLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfPerformedByOffice",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strResultsReceivedFrom",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "PerformedByOfficeLookup", typeof(OrganizationLookup), (o) => { var c = (OrganizationLookup)o; return c.idfInstitution; }, (o) => { var c = (OrganizationLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datAccession",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, true, 
                    "datAccession",
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
                    "idfsSampleType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "SampleType",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "SampleTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestName",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "TestName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "TestNameForSearchLookup", typeof(TestForDiseaseLookup), (o) => { var c = (TestForDiseaseLookup)o; return c.idfsReference; }, (o) => { var c = (TestForDiseaseLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsDiagnosis",
                    EditorType.Lookup,
                    EditorControlWidth.Large, true, true, false, false, 
                    "TestDiagnosisName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "DiagnosisLookup", typeof(DiagnosisLookup), (o) => { var c = (DiagnosisLookup)o; return c.idfsDiagnosis; }, (o) => { var c = (DiagnosisLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestStatus",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "TestStatus",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "TestStatusForSearchLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestResult",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "TestResult",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "TestResultDummyLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datStartedDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datStartedDate",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datConcludedDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datTestResultDate",
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
                    "idfsRegion",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strRegion",
                    null, "=", c => false, false, SearchPanelLocation.Main, true, "idfsRayon", "RegionLookup", typeof(RegionLookup), (o) => { var c = (RegionLookup)o; return c.idfsRegion; }, (o) => { var c = (RegionLookup)o; return c.strRegionName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRayon",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strRayon",
                    null, null, c => false, false, SearchPanelLocation.Main, true, "idfsSettlement", "RayonLookup", typeof(RayonLookup), (o) => { var c = (RayonLookup)o; return c.idfsRayon; }, (o) => { var c = (RayonLookup)o; return c.strRayonName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSampleStatus",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "SampleStatus",
                    null, "=", c => false, true, SearchPanelLocation.Toolbox, false, null, "SampleStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFieldBarcode",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strFieldBarcode",
                    null, "Like", c => false, false, SearchPanelLocation.Toolbox, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strCalculatedCaseID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strCaseIDSessionID",
                    null, "Like", c => false, false, SearchPanelLocation.Toolbox, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfSendToOffice",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strOrganizationSendTo",
                    null, "=", c => false, false, SearchPanelLocation.Toolbox, false, null, "SendToOfficeLookup", typeof(OrganizationLookup), (o) => { var c = (OrganizationLookup)o; return c.idfInstitution; }, (o) => { var c = (OrganizationLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfSendToOfficeOut",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strOrganizationTransferTo",
                    null, "=", c => false, false, SearchPanelLocation.Toolbox, false, null, "SendToOfficeOutLookup", typeof(OrganizationLookup), (o) => { var c = (OrganizationLookup)o; return c.idfInstitution; }, (o) => { var c = (OrganizationLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfPerformedByOffice",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strResultsReceivedFrom",
                    null, "=", c => false, false, SearchPanelLocation.Toolbox, false, null, "PerformedByOfficeLookup", typeof(OrganizationLookup), (o) => { var c = (OrganizationLookup)o; return c.idfInstitution; }, (o) => { var c = (OrganizationLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datAccession",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datAccession",
                    null, null, c => false, false, SearchPanelLocation.Toolbox, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strBarcode",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strLabBarcode",
                    null, "Like", c => false, false, SearchPanelLocation.Toolbox, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSampleType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "SampleType",
                    null, "=", c => false, false, SearchPanelLocation.Toolbox, false, null, "SampleTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestName",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "TestName",
                    null, "=", c => false, false, SearchPanelLocation.Toolbox, false, null, "TestNameForSearchLookup", typeof(TestForDiseaseLookup), (o) => { var c = (TestForDiseaseLookup)o; return c.idfsReference; }, (o) => { var c = (TestForDiseaseLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsDiagnosis",
                    EditorType.Lookup,
                    EditorControlWidth.Large, true, true, false, false, 
                    "TestDiagnosisName",
                    null, "=", c => false, false, SearchPanelLocation.Toolbox, false, null, "DiagnosisLookup", typeof(DiagnosisLookup), (o) => { var c = (DiagnosisLookup)o; return c.idfsDiagnosis; }, (o) => { var c = (DiagnosisLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestStatus",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "TestStatus",
                    null, "=", c => false, false, SearchPanelLocation.Toolbox, false, null, "TestStatusForSearchLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestResult",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "TestResult",
                    null, "=", c => false, false, SearchPanelLocation.Toolbox, false, null, "TestResultDummyLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datStartedDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datStartedDate",
                    null, null, c => false, false, SearchPanelLocation.Toolbox, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datConcludedDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datTestResultDate",
                    null, null, c => false, false, SearchPanelLocation.Toolbox, false, null, null, null, null, null, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_ID,
                    _str_ID, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfTesting,
                    _str_idfTesting, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfMaterial,
                    _str_idfMaterial, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_isChanges,
                    _str_isChanges, null, false, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCalculatedCaseID,
                    "strCaseIDSessionID", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_HumanName,
                    _str_HumanName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRegion,
                    _str_strRegion, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRayon,
                    _str_strRayon, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode,
                    _str_strFieldBarcode, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsSampleStatus,
                    "SampleStatus", null, true, false, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSampleStatus,
                    "SampleStatus", null, true, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBarcode,
                    "strLabBarcode", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsSampleType,
                    _str_idfsSampleType, null, true, false, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSampleName,
                    "idfsSampleType", null, true, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datAccession,
                    _str_datAccession, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsAccessionCondition,
                    _str_idfsAccessionCondition, null, true, false, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSampleConditionReceivedStatus,
                    "idfsAccessionCondition", null, true, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsDiagnosis,
                    "TestDiagnosisName", null, true, false, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnosisName,
                    "TestDiagnosisName", null, true, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsTestName,
                    "TestName", null, true, false, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestName,
                    "TestName", null, true, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsTestStatus,
                    "TestStatus", null, true, false, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestStatus,
                    "TestStatus", null, true, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsTestResult,
                    "TestResult", null, true, false, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestResult,
                    "TestResult", null, true, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datStartedDate,
                    _str_datStartedDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datConcludedDate,
                    "datTestResultDate", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsTestCategory,
                    "TestCategory", null, true, false, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestCategory,
                    "TestCategory", null, true, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strObservation,
                    _str_strObservation, null, true, false, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "OK",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).OK(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => (int)(c as LaboratorySectionItem).intNewMode > 0 && (c as LaboratorySectionItem).intNewMode != LabNewModeEnum.CreateSample && (c as LaboratorySectionItem).intNewMode != LabNewModeEnum.GroupAccessionIn && (c as LaboratorySectionItem).intNewMode != LabNewModeEnum.AssignTest,
                    true,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "ItemCreate",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ItemCreate(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strAdd_Id",
                        "",
                        /*from BvMessages*/"tooltipAdd_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => (c as LaboratorySectionItem).intNewMode == LabNewModeEnum.CreateSample,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "ItemGroupAccessionIn",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ItemGroupAccessionIn(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strAdd_Id",
                        "",
                        /*from BvMessages*/"tooltipAdd_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => (c as LaboratorySectionItem).intNewMode == LabNewModeEnum.GroupAccessionIn,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "ItemAssignTest",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ItemAssignTest(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strAdd_Id",
                        "",
                        /*from BvMessages*/"tooltipAdd_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => (c as LaboratorySectionItem).intNewMode == LabNewModeEnum.AssignTest,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "ItemCancel",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ItemCancel(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => (int)(c as LaboratorySectionItem).intNewMode > 0 && (c as LaboratorySectionItem).intNewMode != LabNewModeEnum.CreateSample && (c as LaboratorySectionItem).intNewMode != LabNewModeEnum.GroupAccessionIn && (c as LaboratorySectionItem).intNewMode != LabNewModeEnum.AssignTest,
                    true,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "ItemClose",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ItemClose(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strClose_Id",
                        "",
                        /*from BvMessages*/"tooltipClose_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => (c as LaboratorySectionItem).intNewMode == LabNewModeEnum.CreateSample || (c as LaboratorySectionItem).intNewMode == LabNewModeEnum.GroupAccessionIn || (c as LaboratorySectionItem).intNewMode == LabNewModeEnum.AssignTest,
                    true,
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
                    "CreateWithNewMode",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithNewMode(manager, c, pars)),
                        
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
                    "CreateSampleFrom",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateSampleFrom(manager, c, pars)),
                        
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
                    "CreateSample",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).CreateSample(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleBtnCreateSample",
                        "add",
                        /*from BvMessages*/"titleBtnCreateSample",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.Win
                        ),
                      true,
                    "Sample.Insert",
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    "laboratory.CreateSample",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "GroupAccessionIn",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).GroupAccessionIn(manager, (LaboratorySectionItem)c, pars),
                        
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
                      true,
                    "AccessionIn1.Execute",
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    "laboratory.GroupAccessionIn",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuAccessionIn",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuAccessionIn(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuAccessionIn",
                        "",
                        /*from BvMessages*/"menuAccessionIn",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && !(c as LaboratorySectionItem).idfTesting.HasValue && (c as LaboratorySectionItem).idfsSampleStatus <= 0 && !string.IsNullOrEmpty((c as LaboratorySectionItem).strCalculatedCaseID),
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                new ActionMetaItem(
                    "MenuAccessionInGoodCondition",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    (manager, c, pars) => Accessor.Instance(null).MenuAccessionInGoodCondition(manager, (LaboratorySectionItem)c, pars),
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuAccessionInGoodCondition",
                        "",
                        /*from BvMessages*/"menuAccessionInGoodCondition",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && true,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    )
    ,
                new ActionMetaItem(
                    "MenuAccessionInPoorCondition",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    (manager, c, pars) => Accessor.Instance(null).MenuAccessionInPoorCondition(manager, (LaboratorySectionItem)c, pars),
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuAccessionInPoorCondition",
                        "",
                        /*from BvMessages*/"menuAccessionInPoorCondition",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && true,
                    false,
                    true,
                    "laboratory.AccessionInPoorCondition",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    )
    ,
                new ActionMetaItem(
                    "MenuAccessionInRejected",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    (manager, c, pars) => Accessor.Instance(null).MenuAccessionInRejected(manager, (LaboratorySectionItem)c, pars),
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuAccessionInRejected",
                        "",
                        /*from BvMessages*/"menuAccessionInRejected",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && true,
                    false,
                    true,
                    "laboratory.AccessionInRejected",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    )
    
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuAssignTest",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuAssignTest(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuAssignTest",
                        "",
                        /*from BvMessages*/"menuAssignTest",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && !(c as LaboratorySectionItem).IsNew && (c as LaboratorySectionItem).idfsSampleStatusOriginal == (long)eidss.model.Enums.SampleStatus.Accessioned && (c as LaboratorySectionItem).idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned && (c as LaboratorySectionItem).idfsAccessionCondition.Value != (long)eidss.model.Enums.AccessionConditionEnum.Rejected && (a == null ? true : (a as LaboratorySectionItem).strCalculatedCaseID == (c as LaboratorySectionItem).strCalculatedCaseID),
                    false,
                    true,
                    "laboratory.AssignTest",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuExternalTestResult",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuExternalTestResult(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuExternalTestResult",
                        "",
                        /*from BvMessages*/"menuExternalTestResult",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && (c as LaboratorySectionItem).idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.OutOfRepository && (c as LaboratorySectionItem).bExternalOffice.HasValue && (c as LaboratorySectionItem).bExternalOffice.Value,
                    false,
                    true,
                    null,
                    true,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuCreateAliquot",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuCreateAliquot(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuCreateAliquot",
                        "",
                        /*from BvMessages*/"menuCreateAliquot",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      true,
                    "Sample.Insert",
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && !(c as LaboratorySectionItem).IsNew && (c as LaboratorySectionItem).idfsSampleStatusOriginal == (long)eidss.model.Enums.SampleStatus.Accessioned && (c as LaboratorySectionItem).idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned,
                    false,
                    true,
                    "laboratory.CreateAliquot",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuCreateDerivative",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuCreateDerivative(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuCreateDerivative",
                        "",
                        /*from BvMessages*/"menuCreateDerivative",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      true,
                    "Sample.Insert",
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && !(c as LaboratorySectionItem).IsNew && (c as LaboratorySectionItem).idfsSampleStatusOriginal == (long)eidss.model.Enums.SampleStatus.Accessioned && (c as LaboratorySectionItem).idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned && (a == null ? true : (a as LaboratorySectionItem).idfsSampleType == (c as LaboratorySectionItem).idfsSampleType),
                    false,
                    true,
                    "laboratory.CreateDerivative",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuTransferOutSample",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuTransferOutSample(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuTransferOutSample",
                        "",
                        /*from BvMessages*/"menuTransferOutSample",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r  /*&& !(c as LaboratorySectionItem).idfTesting.HasValue*/ && !(c as LaboratorySectionItem).IsNew && (c as LaboratorySectionItem).idfsSampleStatusOriginal == (long)eidss.model.Enums.SampleStatus.Accessioned && (c as LaboratorySectionItem).idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned,
                    false,
                    true,
                    "laboratory.TransferOutSample",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuSeparator1",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuSeparator1(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"-",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuStartTest",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuStartTest(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuStartTest",
                        "",
                        /*from BvMessages*/"menuStartTest",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && (c as LaboratorySectionItem).idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned && (c as LaboratorySectionItem).idfTesting.HasValue && (c as LaboratorySectionItem).idfsTestStatus == (long)eidss.model.Enums.TestStatus.NotStarted,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuSetTestResult",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuSetTestResult(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuSetTestResult",
                        "",
                        /*from BvMessages*/"menuSetTestResult",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && (c as LaboratorySectionItem).idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned && (c as LaboratorySectionItem).idfTesting.HasValue && ((c as LaboratorySectionItem).idfsTestStatus == (long)eidss.model.Enums.TestStatus.NotStarted || (c as LaboratorySectionItem).idfsTestStatus == (long)eidss.model.Enums.TestStatus.InProcess || (c as LaboratorySectionItem).idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary) && (a == null ? true : (a as LaboratorySectionItem).idfsTestStatus == (c as LaboratorySectionItem).idfsTestStatus),
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    , o => 
                    {
                        LaboratorySectionItem obj = (LaboratorySectionItem)o;
                        return obj.TestResultRefLookup
                            .Where(c => c.idfsReference != 0)
                            .Select(i => 
                                new ActionMetaItem(
                                    new Func<TestResultLookup, string>(c => c.idfsReference.ToString())(i),
                                    ActionTypes.Action,
                                    true,
                                    "",
                                    "",
                                    (manager, c, pars) => Accessor.Instance(null).MenuSetTestResult(manager, (LaboratorySectionItem)c, 
                                        new Func<TestResultLookup, List<object>>(j => new List<object> { j.idfsReference } )(i)
                                        ),
                                    null,
                                    
                                        new ActionMetaItem.VisualItem(
                                        new Func<TestResultLookup, string>(c => c.name)(i),
                                        "",
                                        new Func<TestResultLookup, string>(c => c.name)(i),
                                        /*from BvMessages*/"",
                                        "",
                                        /*from BvMessages*/"",
                                        ActionsAlignment.Left,
                                        ActionsPanelType.ContextMenu,
                                        ActionsAppType.All
                                        ),
                                      false,
                                    null,
                                    null,
                                    null,
                                    null,
                                    (c,a,p,r) => r && (c as LaboratorySectionItem).idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned && (c as LaboratorySectionItem).idfTesting.HasValue && ((c as LaboratorySectionItem).idfsTestStatus == (long)eidss.model.Enums.TestStatus.NotStarted || (c as LaboratorySectionItem).idfsTestStatus == (long)eidss.model.Enums.TestStatus.InProcess || (c as LaboratorySectionItem).idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary) && (a == null ? true : (a as LaboratorySectionItem).idfsTestStatus == (c as LaboratorySectionItem).idfsTestStatus),
                                    false,
                                    true,
                                    null,
                                    false,
                                    new ActionMetaItem[] {
                                      
                                      }
                                    )
                            );
                    }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuValidateTestResult",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuValidateTestResult(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuValidateTestResult",
                        "",
                        /*from BvMessages*/"menuValidateTestResult",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    "CanFinalizeLabTest",
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && (c as LaboratorySectionItem).idfTesting.HasValue && (c as LaboratorySectionItem).idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuAmendTestResult",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuAmendTestResult(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuAmendTestResult",
                        "",
                        /*from BvMessages*/"menuAmendTestResult",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      true,
                    "CanAmendTest",
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && (c as LaboratorySectionItem).idfTesting.HasValue && ((c as LaboratorySectionItem).isTestFinalOrAmendSaved),
                    false,
                    true,
                    "laboratory.AmendTestResult",
                    true,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuSeparator2",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuSeparator2(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"-",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuAddToPreferences",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuAddToPreferences(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuAddToPreferences",
                        "",
                        /*from BvMessages*/"menuAddToPreferences",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && !(c as LaboratorySectionItem).bIsMyPref && !(c as LaboratorySectionItem).IsNew && !(c as LaboratorySectionItem).bTestInserted,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuRemoveFromPreferences",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuRemoveFromPreferences(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuRemoveFromPreferences",
                        "",
                        /*from BvMessages*/"menuRemoveFromPreferences",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && (c as LaboratorySectionItem).bIsMyPref && !(c as LaboratorySectionItem).IsNew && !(c as LaboratorySectionItem).bTestInserted,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuRemove",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuRemove(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuRemove",
                        "",
                        /*from BvMessages*/"menuRemove",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && !c.HasChanges,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuCancelChanges",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuCancelChanges(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuCancelChanges",
                        "",
                        /*from BvMessages*/"menuCancelChanges",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && c.HasChanges,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuSeparator3",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuSeparator3(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"-",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuSampleDestruction",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuSampleDestruction(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuSampleDestruction",
                        "",
                        /*from BvMessages*/"menuSampleDestruction",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r /*&& !(c as LaboratorySectionItem).idfTesting.HasValue*/,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                new ActionMetaItem(
                    "MenuRoutineSampleDestruction",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    (manager, c, pars) => Accessor.Instance(null).MenuRoutineSampleDestruction(manager, (LaboratorySectionItem)c, pars),
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuRoutineSampleDestruction",
                        "",
                        /*from BvMessages*/"menuRoutineSampleDestruction",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r /*&& !(c as LaboratorySectionItem).idfTesting.HasValue*/ && (c as LaboratorySectionItem).idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    , o => 
                    {
                        LaboratorySectionItem obj = (LaboratorySectionItem)o;
                        return obj.DestructionMethodLookup
                            .Where(c => c.idfsBaseReference != 0)
                            .Select(i => 
                                new ActionMetaItem(
                                    new Func<BaseReference, string>(c => c.idfsBaseReference.ToString())(i),
                                    ActionTypes.Action,
                                    true,
                                    "",
                                    "",
                                    (manager, c, pars) => Accessor.Instance(null).MenuRoutineSampleDestruction(manager, (LaboratorySectionItem)c, 
                                        new Func<BaseReference, List<object>>(j => new List<object> { j.idfsBaseReference } )(i)
                                        ),
                                    null,
                                    
                                        new ActionMetaItem.VisualItem(
                                        new Func<BaseReference, string>(c => c.name)(i),
                                        "",
                                        new Func<BaseReference, string>(c => c.name)(i),
                                        /*from BvMessages*/"",
                                        "",
                                        /*from BvMessages*/"",
                                        ActionsAlignment.Left,
                                        ActionsPanelType.ContextMenu,
                                        ActionsAppType.All
                                        ),
                                      false,
                                    null,
                                    null,
                                    null,
                                    null,
                                    (c,a,p,r) => r /*&& !(c as LaboratorySectionItem).idfTesting.HasValue*/ && (c as LaboratorySectionItem).idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned,
                                    false,
                                    true,
                                    null,
                                    false,
                                    new ActionMetaItem[] {
                                      
                                      }
                                    )
                            );
                    }
                    
                    )
    ,
                new ActionMetaItem(
                    "MenuAcceptDestruction",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    (manager, c, pars) => Accessor.Instance(null).MenuAcceptDestruction(manager, (LaboratorySectionItem)c, pars),
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuAcceptDestruction",
                        "",
                        /*from BvMessages*/"menuAcceptDestruction",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r /*&& !(c as LaboratorySectionItem).idfTesting.HasValue*/ && (c as LaboratorySectionItem).idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.RoutineDestruction,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    )
    ,
                new ActionMetaItem(
                    "MenuRejectDestruction",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    (manager, c, pars) => Accessor.Instance(null).MenuRejectDestruction(manager, (LaboratorySectionItem)c, pars),
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuRejectDestruction",
                        "",
                        /*from BvMessages*/"menuRejectDestruction",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r /*&& !(c as LaboratorySectionItem).idfTesting.HasValue*/ && (c as LaboratorySectionItem).idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.RoutineDestruction,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    )
    
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuDelete",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuDelete(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuDelete",
                        "",
                        /*from BvMessages*/"menuDelete",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && true,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                new ActionMetaItem(
                    "MenuDeleteSample",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    (manager, c, pars) => Accessor.Instance(null).MenuDeleteSample(manager, (LaboratorySectionItem)c, pars),
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuDeleteSample",
                        "",
                        /*from BvMessages*/"menuDeleteSample",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r /*&& !(c as LaboratorySectionItem).idfTesting.HasValue*/ && (c as LaboratorySectionItem).idfsSampleStatus > 0  && (c as LaboratorySectionItem).idfsSampleStatus != (long)eidss.model.Enums.SampleStatus.IsDeleted,
                    false,
                    true,
                    "laboratory.DeleteSample",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    )
    ,
                new ActionMetaItem(
                    "MenuDeleteTest",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    (manager, c, pars) => Accessor.Instance(null).MenuDeleteTest(manager, (LaboratorySectionItem)c, pars),
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuDeleteTest",
                        "",
                        /*from BvMessages*/"menuDeleteTest",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r  && (c as LaboratorySectionItem).idfTesting.HasValue && ((c as LaboratorySectionItem).idfsTestStatus == (long)eidss.model.Enums.TestStatus.NotStarted || (c as LaboratorySectionItem).idfsTestStatus == (long)eidss.model.Enums.TestStatus.InProcess || (c as LaboratorySectionItem).idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary),
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    )
    
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuSeparator4",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuSeparator4(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"-",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuPaperForms",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuPaperForms(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titlePaperForms",
                        "",
                        /*from BvMessages*/"titlePaperForms",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.Web
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r,
                    false,
                    true,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                new ActionMetaItem(
                    "MenuSampleReport",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    (manager, c, pars) => Accessor.Instance(null).MenuSampleReport(manager, (LaboratorySectionItem)c, pars),
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"rptSampleReport",
                        "",
                        /*from BvMessages*/"rptSampleReport",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.Web
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r,
                    false,
                    true,
                    "laboratory.SampleReport",
                    true,
                    new ActionMetaItem[] {
                      
                      }
                    
                    )
    ,
                new ActionMetaItem(
                    "MenuTestResultReport",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    (manager, c, pars) => Accessor.Instance(null).MenuTestResultReport(manager, (LaboratorySectionItem)c, pars),
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"rptTestResultReport",
                        "",
                        /*from BvMessages*/"rptTestResultReport",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.Web
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && (c as LaboratorySectionItem).idfTesting.HasValue && !(c as LaboratorySectionItem).bTestInserted,
                    false,
                    true,
                    "laboratory.TestResultReport",
                    true,
                    new ActionMetaItem[] {
                      
                      }
                    
                    )
    ,
                new ActionMetaItem(
                    "MenuSampleDestructionReport",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    (manager, c, pars) => Accessor.Instance(null).MenuSampleDestructionReport(manager, (LaboratorySectionItem)c, pars),
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"rptSampleDestructionReport",
                        "",
                        /*from BvMessages*/"rptSampleDestructionReport",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.Web
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && ((c as LaboratorySectionItem).idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.RoutineDestruction || (c as LaboratorySectionItem).idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Destroyed),
                    false,
                    true,
                    "laboratory.SampleDestructionReport",
                    true,
                    new ActionMetaItem[] {
                      
                      }
                    
                    )
    
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "MenuPrintBarcode",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).MenuPrintBarcode(manager, (LaboratorySectionItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"menuPrintBarcode",
                        "",
                        /*from BvMessages*/"menuPrintBarcode",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && (c as LaboratorySectionItem).idfsSampleStatus > 0 && !(c as LaboratorySectionItem).strBarcode.StartsWith("(new"),
                    false,
                    true,
                    "laboratory.PrintBarcode",
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
	