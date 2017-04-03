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
    public abstract partial class VetCaseSample : 
        EditableObject<VetCaseSample>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfMaterial), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMaterial { get; set; }
                
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
                
        [LocalizedDisplayName(_str_idfRootParentMaterial)]
        [MapField(_str_idfRootParentMaterial)]
        public abstract Int64? idfRootParentMaterial { get; set; }
        #if MONO
        protected Int64? idfRootParentMaterial_Original { get { return idfRootParentMaterial; } }
        protected Int64? idfRootParentMaterial_Previous { get { return idfRootParentMaterial; } }
        #else
        protected Int64? idfRootParentMaterial_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootParentMaterial).OriginalValue; } }
        protected Int64? idfRootParentMaterial_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootParentMaterial).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfParty)]
        [MapField(_str_idfParty)]
        public abstract Int64? idfParty { get; set; }
        #if MONO
        protected Int64? idfParty_Original { get { return idfParty; } }
        protected Int64? idfParty_Previous { get { return idfParty; } }
        #else
        protected Int64? idfParty_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParty).OriginalValue; } }
        protected Int64? idfParty_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParty).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_SpeciesName)]
        [MapField(_str_SpeciesName)]
        public abstract String SpeciesName { get; set; }
        #if MONO
        protected String SpeciesName_Original { get { return SpeciesName; } }
        protected String SpeciesName_Previous { get { return SpeciesName; } }
        #else
        protected String SpeciesName_Original { get { return ((EditableValue<String>)((dynamic)this)._speciesName).OriginalValue; } }
        protected String SpeciesName_Previous { get { return ((EditableValue<String>)((dynamic)this)._speciesName).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfFieldCollectedByPerson)]
        [MapField(_str_idfFieldCollectedByPerson)]
        public abstract Int64? idfFieldCollectedByPerson { get; set; }
        #if MONO
        protected Int64? idfFieldCollectedByPerson_Original { get { return idfFieldCollectedByPerson; } }
        protected Int64? idfFieldCollectedByPerson_Previous { get { return idfFieldCollectedByPerson; } }
        #else
        protected Int64? idfFieldCollectedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByPerson).OriginalValue; } }
        protected Int64? idfFieldCollectedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("CollectedbyOfficer")]
        [MapField(_str_strFieldCollectedByPerson)]
        public abstract String strFieldCollectedByPerson { get; set; }
        #if MONO
        protected String strFieldCollectedByPerson_Original { get { return strFieldCollectedByPerson; } }
        protected String strFieldCollectedByPerson_Previous { get { return strFieldCollectedByPerson; } }
        #else
        protected String strFieldCollectedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByPerson).OriginalValue; } }
        protected String strFieldCollectedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfFieldCollectedByOffice)]
        [MapField(_str_idfFieldCollectedByOffice)]
        public abstract Int64? idfFieldCollectedByOffice { get; set; }
        #if MONO
        protected Int64? idfFieldCollectedByOffice_Original { get { return idfFieldCollectedByOffice; } }
        protected Int64? idfFieldCollectedByOffice_Previous { get { return idfFieldCollectedByOffice; } }
        #else
        protected Int64? idfFieldCollectedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).OriginalValue; } }
        protected Int64? idfFieldCollectedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("CollectedbyInstitution")]
        [MapField(_str_strFieldCollectedByOffice)]
        public abstract String strFieldCollectedByOffice { get; set; }
        #if MONO
        protected String strFieldCollectedByOffice_Original { get { return strFieldCollectedByOffice; } }
        protected String strFieldCollectedByOffice_Previous { get { return strFieldCollectedByOffice; } }
        #else
        protected String strFieldCollectedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByOffice).OriginalValue; } }
        protected String strFieldCollectedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strSendToOrganization")]
        [MapField(_str_idfSendToOffice)]
        public abstract Int64? idfSendToOffice { get; set; }
        #if MONO
        protected Int64? idfSendToOffice_Original { get { return idfSendToOffice; } }
        protected Int64? idfSendToOffice_Previous { get { return idfSendToOffice; } }
        #else
        protected Int64? idfSendToOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).OriginalValue; } }
        protected Int64? idfSendToOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSendToOffice)]
        [MapField(_str_strSendToOffice)]
        public abstract String strSendToOffice { get; set; }
        #if MONO
        protected String strSendToOffice_Original { get { return strSendToOffice; } }
        protected String strSendToOffice_Previous { get { return strSendToOffice; } }
        #else
        protected String strSendToOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strSendToOffice).OriginalValue; } }
        protected String strSendToOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSendToOffice).PreviousValue; } }
        #endif
                
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
                
        [LocalizedDisplayName(_str_datFieldSentDate)]
        [MapField(_str_datFieldSentDate)]
        public abstract DateTime? datFieldSentDate { get; set; }
        #if MONO
        protected DateTime? datFieldSentDate_Original { get { return datFieldSentDate; } }
        protected DateTime? datFieldSentDate_Previous { get { return datFieldSentDate; } }
        #else
        protected DateTime? datFieldSentDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldSentDate).OriginalValue; } }
        protected DateTime? datFieldSentDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldSentDate).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsBirdStatus)]
        [MapField(_str_idfsBirdStatus)]
        public abstract Int64? idfsBirdStatus { get; set; }
        #if MONO
        protected Int64? idfsBirdStatus_Original { get { return idfsBirdStatus; } }
        protected Int64? idfsBirdStatus_Previous { get { return idfsBirdStatus; } }
        #else
        protected Int64? idfsBirdStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBirdStatus).OriginalValue; } }
        protected Int64? idfsBirdStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBirdStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsSpecimenType")]
        [MapField(_str_strSpecimenName)]
        public abstract String strSpecimenName { get; set; }
        #if MONO
        protected String strSpecimenName_Original { get { return strSpecimenName; } }
        protected String strSpecimenName_Previous { get { return strSpecimenName; } }
        #else
        protected String strSpecimenName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSpecimenName).OriginalValue; } }
        protected String strSpecimenName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSpecimenName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64? idfsSite { get; set; }
        #if MONO
        protected Int64? idfsSite_Original { get { return idfsSite; } }
        protected Int64? idfsSite_Previous { get { return idfsSite; } }
        #else
        protected Int64? idfsSite_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64? idfsSite_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSite).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strCondition)]
        [MapField(_str_strCondition)]
        public abstract String strCondition { get; set; }
        #if MONO
        protected String strCondition_Original { get { return strCondition; } }
        protected String strCondition_Previous { get { return strCondition; } }
        #else
        protected String strCondition_Original { get { return ((EditableValue<String>)((dynamic)this)._strCondition).OriginalValue; } }
        protected String strCondition_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCondition).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfAccesionByPerson)]
        [MapField(_str_idfAccesionByPerson)]
        public abstract Int64? idfAccesionByPerson { get; set; }
        #if MONO
        protected Int64? idfAccesionByPerson_Original { get { return idfAccesionByPerson; } }
        protected Int64? idfAccesionByPerson_Previous { get { return idfAccesionByPerson; } }
        #else
        protected Int64? idfAccesionByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAccesionByPerson).OriginalValue; } }
        protected Int64? idfAccesionByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAccesionByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_Used)]
        [MapField(_str_Used)]
        public abstract Int32 Used { get; set; }
        #if MONO
        protected Int32 Used_Original { get { return Used; } }
        protected Int32 Used_Previous { get { return Used; } }
        #else
        protected Int32 Used_Original { get { return ((EditableValue<Int32>)((dynamic)this)._used).OriginalValue; } }
        protected Int32 Used_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._used).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfVector)]
        [MapField(_str_idfVector)]
        public abstract Int64? idfVector { get; set; }
        #if MONO
        protected Int64? idfVector_Original { get { return idfVector; } }
        protected Int64? idfVector_Previous { get { return idfVector; } }
        #else
        protected Int64? idfVector_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVector).OriginalValue; } }
        protected Int64? idfVector_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVector).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strComment")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        #if MONO
        protected String strNote_Original { get { return strNote; } }
        protected String strNote_Previous { get { return strNote; } }
        #else
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsVectorType)]
        [MapField(_str_idfsVectorType)]
        public abstract Int64? idfsVectorType { get; set; }
        #if MONO
        protected Int64? idfsVectorType_Original { get { return idfsVectorType; } }
        protected Int64? idfsVectorType_Previous { get { return idfsVectorType; } }
        #else
        protected Int64? idfsVectorType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVectorType).OriginalValue; } }
        protected Int64? idfsVectorType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVectorType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsVectorSubType)]
        [MapField(_str_idfsVectorSubType)]
        public abstract Int64? idfsVectorSubType { get; set; }
        #if MONO
        protected Int64? idfsVectorSubType_Original { get { return idfsVectorSubType; } }
        protected Int64? idfsVectorSubType_Previous { get { return idfsVectorSubType; } }
        #else
        protected Int64? idfsVectorSubType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVectorSubType).OriginalValue; } }
        protected Int64? idfsVectorSubType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVectorSubType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intQuantity)]
        [MapField(_str_intQuantity)]
        public abstract Int32? intQuantity { get; set; }
        #if MONO
        protected Int32? intQuantity_Original { get { return intQuantity; } }
        protected Int32? intQuantity_Previous { get { return intQuantity; } }
        #else
        protected Int32? intQuantity_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intQuantity).OriginalValue; } }
        protected Int32? intQuantity_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intQuantity).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datCollectionDateTime)]
        [MapField(_str_datCollectionDateTime)]
        public abstract DateTime? datCollectionDateTime { get; set; }
        #if MONO
        protected DateTime? datCollectionDateTime_Original { get { return datCollectionDateTime; } }
        protected DateTime? datCollectionDateTime_Previous { get { return datCollectionDateTime; } }
        #else
        protected DateTime? datCollectionDateTime_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCollectionDateTime).OriginalValue; } }
        protected DateTime? datCollectionDateTime_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCollectionDateTime).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfLocation)]
        [MapField(_str_idfLocation)]
        public abstract Int64? idfLocation { get; set; }
        #if MONO
        protected Int64? idfLocation_Original { get { return idfLocation; } }
        protected Int64? idfLocation_Previous { get { return idfLocation; } }
        #else
        protected Int64? idfLocation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfLocation).OriginalValue; } }
        protected Int64? idfLocation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfLocation).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strVectorID)]
        [MapField(_str_strVectorID)]
        public abstract String strVectorID { get; set; }
        #if MONO
        protected String strVectorID_Original { get { return strVectorID; } }
        protected String strVectorID_Previous { get { return strVectorID; } }
        #else
        protected String strVectorID_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).OriginalValue; } }
        protected String strVectorID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strVectorType)]
        [MapField(_str_strVectorType)]
        public abstract String strVectorType { get; set; }
        #if MONO
        protected String strVectorType_Original { get { return strVectorType; } }
        protected String strVectorType_Previous { get { return strVectorType; } }
        #else
        protected String strVectorType_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).OriginalValue; } }
        protected String strVectorType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strVectorSpecies)]
        [MapField(_str_strVectorSpecies)]
        public abstract String strVectorSpecies { get; set; }
        #if MONO
        protected String strVectorSpecies_Original { get { return strVectorSpecies; } }
        protected String strVectorSpecies_Previous { get { return strVectorSpecies; } }
        #else
        protected String strVectorSpecies_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorSpecies).OriginalValue; } }
        protected String strVectorSpecies_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorSpecies).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<VetCaseSample, object> _get_func;
            internal Action<VetCaseSample, string> _set_func;
            internal Action<VetCaseSample, VetCaseSample, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_idfsSpecimenType = "idfsSpecimenType";
        internal const string _str_idfRootParentMaterial = "idfRootParentMaterial";
        internal const string _str_idfParty = "idfParty";
        internal const string _str_AnimalName = "AnimalName";
        internal const string _str_strAnimalCode = "strAnimalCode";
        internal const string _str_SpeciesName = "SpeciesName";
        internal const string _str_strFarmCode = "strFarmCode";
        internal const string _str_idfsSpeciesType = "idfsSpeciesType";
        internal const string _str_idfFieldCollectedByPerson = "idfFieldCollectedByPerson";
        internal const string _str_strFieldCollectedByPerson = "strFieldCollectedByPerson";
        internal const string _str_idfFieldCollectedByOffice = "idfFieldCollectedByOffice";
        internal const string _str_strFieldCollectedByOffice = "strFieldCollectedByOffice";
        internal const string _str_idfSendToOffice = "idfSendToOffice";
        internal const string _str_strSendToOffice = "strSendToOffice";
        internal const string _str_idfTesting = "idfTesting";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_datFieldSentDate = "datFieldSentDate";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_idfsBirdStatus = "idfsBirdStatus";
        internal const string _str_strSpecimenName = "strSpecimenName";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_datAccession = "datAccession";
        internal const string _str_idfContainer = "idfContainer";
        internal const string _str_strCondition = "strCondition";
        internal const string _str_idfsAccessionCondition = "idfsAccessionCondition";
        internal const string _str_idfAccesionByPerson = "idfAccesionByPerson";
        internal const string _str_Used = "Used";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfVector = "idfVector";
        internal const string _str_strNote = "strNote";
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_idfsVectorSubType = "idfsVectorSubType";
        internal const string _str_intQuantity = "intQuantity";
        internal const string _str_datCollectionDateTime = "datCollectionDateTime";
        internal const string _str_idfLocation = "idfLocation";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_strVectorID = "strVectorID";
        internal const string _str_strVectorType = "strVectorType";
        internal const string _str_strVectorSpecies = "strVectorSpecies";
        internal const string _str_FilterByDiagnosis = "FilterByDiagnosis";
        internal const string _str_NewObject = "NewObject";
        internal const string _str_idfsFinalDiagnosisFromCase = "idfsFinalDiagnosisFromCase";
        internal const string _str_idfsTentativeDiagnosis2FromCase = "idfsTentativeDiagnosis2FromCase";
        internal const string _str_idfsTentativeDiagnosis1FromCase = "idfsTentativeDiagnosis1FromCase";
        internal const string _str_idfsTentativeDiagnosisFromCase = "idfsTentativeDiagnosisFromCase";
        internal const string _str_AnimalListFromCase = "AnimalListFromCase";
        internal const string _str_VetFarmTreeFromCase = "VetFarmTreeFromCase";
        internal const string _str_CaseTests = "CaseTests";
        internal const string _str_PensideTests = "PensideTests";
        internal const string _str_strAccessionCondition = "strAccessionCondition";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_AnimalID = "AnimalID";
        internal const string _str_Species = "Species";
        internal const string _str_strBirdStatus = "strBirdStatus";
        internal const string _str_SampleType = "SampleType";
        internal const string _str_AccessionCondition = "AccessionCondition";
        internal const string _str_BirdStatus = "BirdStatus";
        internal const string _str_Animal = "Animal";
        internal const string _str_FarmTree = "FarmTree";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfMaterial, _type = "Int64",
              _get_func = o => o.idfMaterial,
              _set_func = (o, val) => { o.idfMaterial = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfMaterial != c.idfMaterial || o.IsRIRPropChanged(_str_idfMaterial, c)) 
                  m.Add(_str_idfMaterial, o.ObjectIdent + _str_idfMaterial, "Int64", o.idfMaterial == null ? "" : o.idfMaterial.ToString(), o.IsReadOnly(_str_idfMaterial), o.IsInvisible(_str_idfMaterial), o.IsRequired(_str_idfMaterial)); }
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
              _name = _str_idfRootParentMaterial, _type = "Int64?",
              _get_func = o => o.idfRootParentMaterial,
              _set_func = (o, val) => { o.idfRootParentMaterial = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfRootParentMaterial != c.idfRootParentMaterial || o.IsRIRPropChanged(_str_idfRootParentMaterial, c)) 
                  m.Add(_str_idfRootParentMaterial, o.ObjectIdent + _str_idfRootParentMaterial, "Int64?", o.idfRootParentMaterial == null ? "" : o.idfRootParentMaterial.ToString(), o.IsReadOnly(_str_idfRootParentMaterial), o.IsInvisible(_str_idfRootParentMaterial), o.IsRequired(_str_idfRootParentMaterial)); }
              }, 
        
            new field_info {
              _name = _str_idfParty, _type = "Int64?",
              _get_func = o => o.idfParty,
              _set_func = (o, val) => { o.idfParty = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_idfParty, c)) 
                  m.Add(_str_idfParty, o.ObjectIdent + _str_idfParty, "Int64?", o.idfParty == null ? "" : o.idfParty.ToString(), o.IsReadOnly(_str_idfParty), o.IsInvisible(_str_idfParty), o.IsRequired(_str_idfParty)); }
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
              _name = _str_SpeciesName, _type = "String",
              _get_func = o => o.SpeciesName,
              _set_func = (o, val) => { o.SpeciesName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.SpeciesName != c.SpeciesName || o.IsRIRPropChanged(_str_SpeciesName, c)) 
                  m.Add(_str_SpeciesName, o.ObjectIdent + _str_SpeciesName, "String", o.SpeciesName == null ? "" : o.SpeciesName.ToString(), o.IsReadOnly(_str_SpeciesName), o.IsInvisible(_str_SpeciesName), o.IsRequired(_str_SpeciesName)); }
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
              _name = _str_idfsSpeciesType, _type = "Int64?",
              _get_func = o => o.idfsSpeciesType,
              _set_func = (o, val) => { o.idfsSpeciesType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_idfsSpeciesType, c)) 
                  m.Add(_str_idfsSpeciesType, o.ObjectIdent + _str_idfsSpeciesType, "Int64?", o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(), o.IsReadOnly(_str_idfsSpeciesType), o.IsInvisible(_str_idfsSpeciesType), o.IsRequired(_str_idfsSpeciesType)); }
              }, 
        
            new field_info {
              _name = _str_idfFieldCollectedByPerson, _type = "Int64?",
              _get_func = o => o.idfFieldCollectedByPerson,
              _set_func = (o, val) => { o.idfFieldCollectedByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfFieldCollectedByPerson != c.idfFieldCollectedByPerson || o.IsRIRPropChanged(_str_idfFieldCollectedByPerson, c)) 
                  m.Add(_str_idfFieldCollectedByPerson, o.ObjectIdent + _str_idfFieldCollectedByPerson, "Int64?", o.idfFieldCollectedByPerson == null ? "" : o.idfFieldCollectedByPerson.ToString(), o.IsReadOnly(_str_idfFieldCollectedByPerson), o.IsInvisible(_str_idfFieldCollectedByPerson), o.IsRequired(_str_idfFieldCollectedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_strFieldCollectedByPerson, _type = "String",
              _get_func = o => o.strFieldCollectedByPerson,
              _set_func = (o, val) => { o.strFieldCollectedByPerson = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFieldCollectedByPerson != c.strFieldCollectedByPerson || o.IsRIRPropChanged(_str_strFieldCollectedByPerson, c)) 
                  m.Add(_str_strFieldCollectedByPerson, o.ObjectIdent + _str_strFieldCollectedByPerson, "String", o.strFieldCollectedByPerson == null ? "" : o.strFieldCollectedByPerson.ToString(), o.IsReadOnly(_str_strFieldCollectedByPerson), o.IsInvisible(_str_strFieldCollectedByPerson), o.IsRequired(_str_strFieldCollectedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_idfFieldCollectedByOffice, _type = "Int64?",
              _get_func = o => o.idfFieldCollectedByOffice,
              _set_func = (o, val) => { o.idfFieldCollectedByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfFieldCollectedByOffice != c.idfFieldCollectedByOffice || o.IsRIRPropChanged(_str_idfFieldCollectedByOffice, c)) 
                  m.Add(_str_idfFieldCollectedByOffice, o.ObjectIdent + _str_idfFieldCollectedByOffice, "Int64?", o.idfFieldCollectedByOffice == null ? "" : o.idfFieldCollectedByOffice.ToString(), o.IsReadOnly(_str_idfFieldCollectedByOffice), o.IsInvisible(_str_idfFieldCollectedByOffice), o.IsRequired(_str_idfFieldCollectedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_strFieldCollectedByOffice, _type = "String",
              _get_func = o => o.strFieldCollectedByOffice,
              _set_func = (o, val) => { o.strFieldCollectedByOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFieldCollectedByOffice != c.strFieldCollectedByOffice || o.IsRIRPropChanged(_str_strFieldCollectedByOffice, c)) 
                  m.Add(_str_strFieldCollectedByOffice, o.ObjectIdent + _str_strFieldCollectedByOffice, "String", o.strFieldCollectedByOffice == null ? "" : o.strFieldCollectedByOffice.ToString(), o.IsReadOnly(_str_strFieldCollectedByOffice), o.IsInvisible(_str_strFieldCollectedByOffice), o.IsRequired(_str_strFieldCollectedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfSendToOffice, _type = "Int64?",
              _get_func = o => o.idfSendToOffice,
              _set_func = (o, val) => { o.idfSendToOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSendToOffice != c.idfSendToOffice || o.IsRIRPropChanged(_str_idfSendToOffice, c)) 
                  m.Add(_str_idfSendToOffice, o.ObjectIdent + _str_idfSendToOffice, "Int64?", o.idfSendToOffice == null ? "" : o.idfSendToOffice.ToString(), o.IsReadOnly(_str_idfSendToOffice), o.IsInvisible(_str_idfSendToOffice), o.IsRequired(_str_idfSendToOffice)); }
              }, 
        
            new field_info {
              _name = _str_strSendToOffice, _type = "String",
              _get_func = o => o.strSendToOffice,
              _set_func = (o, val) => { o.strSendToOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSendToOffice != c.strSendToOffice || o.IsRIRPropChanged(_str_strSendToOffice, c)) 
                  m.Add(_str_strSendToOffice, o.ObjectIdent + _str_strSendToOffice, "String", o.strSendToOffice == null ? "" : o.strSendToOffice.ToString(), o.IsReadOnly(_str_strSendToOffice), o.IsInvisible(_str_strSendToOffice), o.IsRequired(_str_strSendToOffice)); }
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
              _name = _str_datFieldCollectionDate, _type = "DateTime?",
              _get_func = o => o.datFieldCollectionDate,
              _set_func = (o, val) => { o.datFieldCollectionDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datFieldCollectionDate != c.datFieldCollectionDate || o.IsRIRPropChanged(_str_datFieldCollectionDate, c)) 
                  m.Add(_str_datFieldCollectionDate, o.ObjectIdent + _str_datFieldCollectionDate, "DateTime?", o.datFieldCollectionDate == null ? "" : o.datFieldCollectionDate.ToString(), o.IsReadOnly(_str_datFieldCollectionDate), o.IsInvisible(_str_datFieldCollectionDate), o.IsRequired(_str_datFieldCollectionDate)); }
              }, 
        
            new field_info {
              _name = _str_datFieldSentDate, _type = "DateTime?",
              _get_func = o => o.datFieldSentDate,
              _set_func = (o, val) => { o.datFieldSentDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datFieldSentDate != c.datFieldSentDate || o.IsRIRPropChanged(_str_datFieldSentDate, c)) 
                  m.Add(_str_datFieldSentDate, o.ObjectIdent + _str_datFieldSentDate, "DateTime?", o.datFieldSentDate == null ? "" : o.datFieldSentDate.ToString(), o.IsReadOnly(_str_datFieldSentDate), o.IsInvisible(_str_datFieldSentDate), o.IsRequired(_str_datFieldSentDate)); }
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
              _name = _str_idfsBirdStatus, _type = "Int64?",
              _get_func = o => o.idfsBirdStatus,
              _set_func = (o, val) => { o.idfsBirdStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsBirdStatus != c.idfsBirdStatus || o.IsRIRPropChanged(_str_idfsBirdStatus, c)) 
                  m.Add(_str_idfsBirdStatus, o.ObjectIdent + _str_idfsBirdStatus, "Int64?", o.idfsBirdStatus == null ? "" : o.idfsBirdStatus.ToString(), o.IsReadOnly(_str_idfsBirdStatus), o.IsInvisible(_str_idfsBirdStatus), o.IsRequired(_str_idfsBirdStatus)); }
              }, 
        
            new field_info {
              _name = _str_strSpecimenName, _type = "String",
              _get_func = o => o.strSpecimenName,
              _set_func = (o, val) => { o.strSpecimenName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSpecimenName != c.strSpecimenName || o.IsRIRPropChanged(_str_strSpecimenName, c)) 
                  m.Add(_str_strSpecimenName, o.ObjectIdent + _str_strSpecimenName, "String", o.strSpecimenName == null ? "" : o.strSpecimenName.ToString(), o.IsReadOnly(_str_strSpecimenName), o.IsInvisible(_str_strSpecimenName), o.IsRequired(_str_strSpecimenName)); }
              }, 
        
            new field_info {
              _name = _str_idfsSite, _type = "Int64?",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { o.idfsSite = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_idfsSite, c)) 
                  m.Add(_str_idfsSite, o.ObjectIdent + _str_idfsSite, "Int64?", o.idfsSite == null ? "" : o.idfsSite.ToString(), o.IsReadOnly(_str_idfsSite), o.IsInvisible(_str_idfsSite), o.IsRequired(_str_idfsSite)); }
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
              _name = _str_idfContainer, _type = "Int64?",
              _get_func = o => o.idfContainer,
              _set_func = (o, val) => { o.idfContainer = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfContainer != c.idfContainer || o.IsRIRPropChanged(_str_idfContainer, c)) 
                  m.Add(_str_idfContainer, o.ObjectIdent + _str_idfContainer, "Int64?", o.idfContainer == null ? "" : o.idfContainer.ToString(), o.IsReadOnly(_str_idfContainer), o.IsInvisible(_str_idfContainer), o.IsRequired(_str_idfContainer)); }
              }, 
        
            new field_info {
              _name = _str_strCondition, _type = "String",
              _get_func = o => o.strCondition,
              _set_func = (o, val) => { o.strCondition = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCondition != c.strCondition || o.IsRIRPropChanged(_str_strCondition, c)) 
                  m.Add(_str_strCondition, o.ObjectIdent + _str_strCondition, "String", o.strCondition == null ? "" : o.strCondition.ToString(), o.IsReadOnly(_str_strCondition), o.IsInvisible(_str_strCondition), o.IsRequired(_str_strCondition)); }
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
              _name = _str_idfAccesionByPerson, _type = "Int64?",
              _get_func = o => o.idfAccesionByPerson,
              _set_func = (o, val) => { o.idfAccesionByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfAccesionByPerson != c.idfAccesionByPerson || o.IsRIRPropChanged(_str_idfAccesionByPerson, c)) 
                  m.Add(_str_idfAccesionByPerson, o.ObjectIdent + _str_idfAccesionByPerson, "Int64?", o.idfAccesionByPerson == null ? "" : o.idfAccesionByPerson.ToString(), o.IsReadOnly(_str_idfAccesionByPerson), o.IsInvisible(_str_idfAccesionByPerson), o.IsRequired(_str_idfAccesionByPerson)); }
              }, 
        
            new field_info {
              _name = _str_Used, _type = "Int32",
              _get_func = o => o.Used,
              _set_func = (o, val) => { o.Used = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.Used != c.Used || o.IsRIRPropChanged(_str_Used, c)) 
                  m.Add(_str_Used, o.ObjectIdent + _str_Used, "Int32", o.Used == null ? "" : o.Used.ToString(), o.IsReadOnly(_str_Used), o.IsInvisible(_str_Used), o.IsRequired(_str_Used)); }
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
              _name = _str_idfVector, _type = "Int64?",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { o.idfVector = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) 
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, "Int64?", o.idfVector == null ? "" : o.idfVector.ToString(), o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector)); }
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
              _name = _str_idfsVectorType, _type = "Int64?",
              _get_func = o => o.idfsVectorType,
              _set_func = (o, val) => { o.idfsVectorType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_idfsVectorType, c)) 
                  m.Add(_str_idfsVectorType, o.ObjectIdent + _str_idfsVectorType, "Int64?", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_idfsVectorType), o.IsInvisible(_str_idfsVectorType), o.IsRequired(_str_idfsVectorType)); }
              }, 
        
            new field_info {
              _name = _str_idfsVectorSubType, _type = "Int64?",
              _get_func = o => o.idfsVectorSubType,
              _set_func = (o, val) => { o.idfsVectorSubType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorSubType != c.idfsVectorSubType || o.IsRIRPropChanged(_str_idfsVectorSubType, c)) 
                  m.Add(_str_idfsVectorSubType, o.ObjectIdent + _str_idfsVectorSubType, "Int64?", o.idfsVectorSubType == null ? "" : o.idfsVectorSubType.ToString(), o.IsReadOnly(_str_idfsVectorSubType), o.IsInvisible(_str_idfsVectorSubType), o.IsRequired(_str_idfsVectorSubType)); }
              }, 
        
            new field_info {
              _name = _str_intQuantity, _type = "Int32?",
              _get_func = o => o.intQuantity,
              _set_func = (o, val) => { o.intQuantity = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intQuantity != c.intQuantity || o.IsRIRPropChanged(_str_intQuantity, c)) 
                  m.Add(_str_intQuantity, o.ObjectIdent + _str_intQuantity, "Int32?", o.intQuantity == null ? "" : o.intQuantity.ToString(), o.IsReadOnly(_str_intQuantity), o.IsInvisible(_str_intQuantity), o.IsRequired(_str_intQuantity)); }
              }, 
        
            new field_info {
              _name = _str_datCollectionDateTime, _type = "DateTime?",
              _get_func = o => o.datCollectionDateTime,
              _set_func = (o, val) => { o.datCollectionDateTime = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datCollectionDateTime != c.datCollectionDateTime || o.IsRIRPropChanged(_str_datCollectionDateTime, c)) 
                  m.Add(_str_datCollectionDateTime, o.ObjectIdent + _str_datCollectionDateTime, "DateTime?", o.datCollectionDateTime == null ? "" : o.datCollectionDateTime.ToString(), o.IsReadOnly(_str_datCollectionDateTime), o.IsInvisible(_str_datCollectionDateTime), o.IsRequired(_str_datCollectionDateTime)); }
              }, 
        
            new field_info {
              _name = _str_idfLocation, _type = "Int64?",
              _get_func = o => o.idfLocation,
              _set_func = (o, val) => { o.idfLocation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfLocation != c.idfLocation || o.IsRIRPropChanged(_str_idfLocation, c)) 
                  m.Add(_str_idfLocation, o.ObjectIdent + _str_idfLocation, "Int64?", o.idfLocation == null ? "" : o.idfLocation.ToString(), o.IsReadOnly(_str_idfLocation), o.IsInvisible(_str_idfLocation), o.IsRequired(_str_idfLocation)); }
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
              _name = _str_strVectorID, _type = "String",
              _get_func = o => o.strVectorID,
              _set_func = (o, val) => { o.strVectorID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorID != c.strVectorID || o.IsRIRPropChanged(_str_strVectorID, c)) 
                  m.Add(_str_strVectorID, o.ObjectIdent + _str_strVectorID, "String", o.strVectorID == null ? "" : o.strVectorID.ToString(), o.IsReadOnly(_str_strVectorID), o.IsInvisible(_str_strVectorID), o.IsRequired(_str_strVectorID)); }
              }, 
        
            new field_info {
              _name = _str_strVectorType, _type = "String",
              _get_func = o => o.strVectorType,
              _set_func = (o, val) => { o.strVectorType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorType != c.strVectorType || o.IsRIRPropChanged(_str_strVectorType, c)) 
                  m.Add(_str_strVectorType, o.ObjectIdent + _str_strVectorType, "String", o.strVectorType == null ? "" : o.strVectorType.ToString(), o.IsReadOnly(_str_strVectorType), o.IsInvisible(_str_strVectorType), o.IsRequired(_str_strVectorType)); }
              }, 
        
            new field_info {
              _name = _str_strVectorSpecies, _type = "String",
              _get_func = o => o.strVectorSpecies,
              _set_func = (o, val) => { o.strVectorSpecies = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorSpecies != c.strVectorSpecies || o.IsRIRPropChanged(_str_strVectorSpecies, c)) 
                  m.Add(_str_strVectorSpecies, o.ObjectIdent + _str_strVectorSpecies, "String", o.strVectorSpecies == null ? "" : o.strVectorSpecies.ToString(), o.IsReadOnly(_str_strVectorSpecies), o.IsInvisible(_str_strVectorSpecies), o.IsRequired(_str_strVectorSpecies)); }
              }, 
        
            new field_info {
              _name = _str_FilterByDiagnosis, _type = "bool",
              _get_func = o => o.FilterByDiagnosis,
              _set_func = (o, val) => { o.FilterByDiagnosis = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.FilterByDiagnosis != c.FilterByDiagnosis || o.IsRIRPropChanged(_str_FilterByDiagnosis, c)) 
                  m.Add(_str_FilterByDiagnosis, o.ObjectIdent + _str_FilterByDiagnosis, "bool", o.FilterByDiagnosis == null ? "" : o.FilterByDiagnosis.ToString(), o.IsReadOnly(_str_FilterByDiagnosis), o.IsInvisible(_str_FilterByDiagnosis), o.IsRequired(_str_FilterByDiagnosis));
                 }
              }, 
        
            new field_info {
              _name = _str_NewObject, _type = "bool",
              _get_func = o => o.NewObject,
              _set_func = (o, val) => { o.NewObject = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.NewObject != c.NewObject || o.IsRIRPropChanged(_str_NewObject, c)) 
                  m.Add(_str_NewObject, o.ObjectIdent + _str_NewObject, "bool", o.NewObject == null ? "" : o.NewObject.ToString(), o.IsReadOnly(_str_NewObject), o.IsInvisible(_str_NewObject), o.IsRequired(_str_NewObject));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsFinalDiagnosisFromCase, _type = "long?",
              _get_func = o => o.idfsFinalDiagnosisFromCase,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsFinalDiagnosisFromCase != c.idfsFinalDiagnosisFromCase || o.IsRIRPropChanged(_str_idfsFinalDiagnosisFromCase, c)) 
                  m.Add(_str_idfsFinalDiagnosisFromCase, o.ObjectIdent + _str_idfsFinalDiagnosisFromCase, "long?", o.idfsFinalDiagnosisFromCase == null ? "" : o.idfsFinalDiagnosisFromCase.ToString(), o.IsReadOnly(_str_idfsFinalDiagnosisFromCase), o.IsInvisible(_str_idfsFinalDiagnosisFromCase), o.IsRequired(_str_idfsFinalDiagnosisFromCase));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsTentativeDiagnosis2FromCase, _type = "long?",
              _get_func = o => o.idfsTentativeDiagnosis2FromCase,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsTentativeDiagnosis2FromCase != c.idfsTentativeDiagnosis2FromCase || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis2FromCase, c)) 
                  m.Add(_str_idfsTentativeDiagnosis2FromCase, o.ObjectIdent + _str_idfsTentativeDiagnosis2FromCase, "long?", o.idfsTentativeDiagnosis2FromCase == null ? "" : o.idfsTentativeDiagnosis2FromCase.ToString(), o.IsReadOnly(_str_idfsTentativeDiagnosis2FromCase), o.IsInvisible(_str_idfsTentativeDiagnosis2FromCase), o.IsRequired(_str_idfsTentativeDiagnosis2FromCase));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsTentativeDiagnosis1FromCase, _type = "long?",
              _get_func = o => o.idfsTentativeDiagnosis1FromCase,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsTentativeDiagnosis1FromCase != c.idfsTentativeDiagnosis1FromCase || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis1FromCase, c)) 
                  m.Add(_str_idfsTentativeDiagnosis1FromCase, o.ObjectIdent + _str_idfsTentativeDiagnosis1FromCase, "long?", o.idfsTentativeDiagnosis1FromCase == null ? "" : o.idfsTentativeDiagnosis1FromCase.ToString(), o.IsReadOnly(_str_idfsTentativeDiagnosis1FromCase), o.IsInvisible(_str_idfsTentativeDiagnosis1FromCase), o.IsRequired(_str_idfsTentativeDiagnosis1FromCase));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsTentativeDiagnosisFromCase, _type = "long?",
              _get_func = o => o.idfsTentativeDiagnosisFromCase,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsTentativeDiagnosisFromCase != c.idfsTentativeDiagnosisFromCase || o.IsRIRPropChanged(_str_idfsTentativeDiagnosisFromCase, c)) 
                  m.Add(_str_idfsTentativeDiagnosisFromCase, o.ObjectIdent + _str_idfsTentativeDiagnosisFromCase, "long?", o.idfsTentativeDiagnosisFromCase == null ? "" : o.idfsTentativeDiagnosisFromCase.ToString(), o.IsReadOnly(_str_idfsTentativeDiagnosisFromCase), o.IsInvisible(_str_idfsTentativeDiagnosisFromCase), o.IsRequired(_str_idfsTentativeDiagnosisFromCase));
                 }
              }, 
        
            new field_info {
              _name = _str_AnimalListFromCase, _type = "EditableList<AnimalListItem>",
              _get_func = o => o.AnimalListFromCase,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_VetFarmTreeFromCase, _type = "List<VetFarmTree>",
              _get_func = o => o.VetFarmTreeFromCase,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_CaseTests, _type = "EditableList<CaseTest>",
              _get_func = o => o.CaseTests,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_PensideTests, _type = "EditableList<PensideTest>",
              _get_func = o => o.PensideTests,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_strAccessionCondition, _type = "string",
              _get_func = o => o.strAccessionCondition,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strAccessionCondition != c.strAccessionCondition || o.IsRIRPropChanged(_str_strAccessionCondition, c)) 
                  m.Add(_str_strAccessionCondition, o.ObjectIdent + _str_strAccessionCondition, "string", o.strAccessionCondition == null ? "" : o.strAccessionCondition.ToString(), o.IsReadOnly(_str_strAccessionCondition), o.IsInvisible(_str_strAccessionCondition), o.IsRequired(_str_strAccessionCondition));
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
              _name = _str_AnimalID, _type = "string",
              _get_func = o => o.AnimalID,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.AnimalID != c.AnimalID || o.IsRIRPropChanged(_str_AnimalID, c)) 
                  m.Add(_str_AnimalID, o.ObjectIdent + _str_AnimalID, "string", o.AnimalID == null ? "" : o.AnimalID.ToString(), o.IsReadOnly(_str_AnimalID), o.IsInvisible(_str_AnimalID), o.IsRequired(_str_AnimalID));
                 }
              }, 
        
            new field_info {
              _name = _str_Species, _type = "string",
              _get_func = o => o.Species,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.Species != c.Species || o.IsRIRPropChanged(_str_Species, c)) 
                  m.Add(_str_Species, o.ObjectIdent + _str_Species, "string", o.Species == null ? "" : o.Species.ToString(), o.IsReadOnly(_str_Species), o.IsInvisible(_str_Species), o.IsRequired(_str_Species));
                 }
              }, 
        
            new field_info {
              _name = _str_strBirdStatus, _type = "string",
              _get_func = o => o.strBirdStatus,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strBirdStatus != c.strBirdStatus || o.IsRIRPropChanged(_str_strBirdStatus, c)) 
                  m.Add(_str_strBirdStatus, o.ObjectIdent + _str_strBirdStatus, "string", o.strBirdStatus == null ? "" : o.strBirdStatus.ToString(), o.IsReadOnly(_str_strBirdStatus), o.IsInvisible(_str_strBirdStatus), o.IsRequired(_str_strBirdStatus));
                 }
              }, 
        
            new field_info {
              _name = _str_SampleType, _type = "Lookup",
              _get_func = o => { if (o.SampleType == null) return null; return o.SampleType.idfsReference; },
              _set_func = (o, val) => { o.SampleType = o.SampleTypeLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpecimenType != c.idfsSpecimenType || o.IsRIRPropChanged(_str_SampleType, c)) 
                  m.Add(_str_SampleType, o.ObjectIdent + _str_SampleType, "Lookup", o.idfsSpecimenType == null ? "" : o.idfsSpecimenType.ToString(), o.IsReadOnly(_str_SampleType), o.IsInvisible(_str_SampleType), o.IsRequired(_str_SampleType)); }
              }, 
        
            new field_info {
              _name = _str_AccessionCondition, _type = "Lookup",
              _get_func = o => { if (o.AccessionCondition == null) return null; return o.AccessionCondition.idfsBaseReference; },
              _set_func = (o, val) => { o.AccessionCondition = o.AccessionConditionLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAccessionCondition != c.idfsAccessionCondition || o.IsRIRPropChanged(_str_AccessionCondition, c)) 
                  m.Add(_str_AccessionCondition, o.ObjectIdent + _str_AccessionCondition, "Lookup", o.idfsAccessionCondition == null ? "" : o.idfsAccessionCondition.ToString(), o.IsReadOnly(_str_AccessionCondition), o.IsInvisible(_str_AccessionCondition), o.IsRequired(_str_AccessionCondition)); }
              }, 
        
            new field_info {
              _name = _str_BirdStatus, _type = "Lookup",
              _get_func = o => { if (o.BirdStatus == null) return null; return o.BirdStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.BirdStatus = o.BirdStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsBirdStatus != c.idfsBirdStatus || o.IsRIRPropChanged(_str_BirdStatus, c)) 
                  m.Add(_str_BirdStatus, o.ObjectIdent + _str_BirdStatus, "Lookup", o.idfsBirdStatus == null ? "" : o.idfsBirdStatus.ToString(), o.IsReadOnly(_str_BirdStatus), o.IsInvisible(_str_BirdStatus), o.IsRequired(_str_BirdStatus)); }
              }, 
        
            new field_info {
              _name = _str_Animal, _type = "Lookup",
              _get_func = o => { if (o.Animal == null) return null; return o.Animal.idfAnimal; },
              _set_func = (o, val) => { o.Animal = o.AnimalLookup.Where(c => c.idfAnimal.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_Animal, c)) 
                  m.Add(_str_Animal, o.ObjectIdent + _str_Animal, "Lookup", o.idfParty == null ? "" : o.idfParty.ToString(), o.IsReadOnly(_str_Animal), o.IsInvisible(_str_Animal), o.IsRequired(_str_Animal)); }
              }, 
        
            new field_info {
              _name = _str_FarmTree, _type = "Lookup",
              _get_func = o => { if (o.FarmTree == null) return null; return o.FarmTree.idfParty; },
              _set_func = (o, val) => { o.FarmTree = o.FarmTreeLookup.Where(c => c.idfParty.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_FarmTree, c)) 
                  m.Add(_str_FarmTree, o.ObjectIdent + _str_FarmTree, "Lookup", o.idfParty == null ? "" : o.idfParty.ToString(), o.IsReadOnly(_str_FarmTree), o.IsInvisible(_str_FarmTree), o.IsRequired(_str_FarmTree)); }
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
            VetCaseSample obj = (VetCaseSample)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(SampleTypeForDiagnosisLookup), eidss.model.Schema.SampleTypeForDiagnosisLookup._str_idfsReference, _str_idfsSpecimenType)]
        public SampleTypeForDiagnosisLookup SampleType
        {
            get { return _SampleType == null ? null : ((long)_SampleType.Key == 0 ? null : _SampleType); }
            set 
            { 
                _SampleType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsSpecimenType = _SampleType == null 
                    ? new Int64()
                    : _SampleType.idfsReference; 
                OnPropertyChanged(_str_SampleType); 
            }
        }
        private SampleTypeForDiagnosisLookup _SampleType;

        
        public List<SampleTypeForDiagnosisLookup> SampleTypeLookup
        {
            get { return _SampleTypeLookup; }
        }
        private List<SampleTypeForDiagnosisLookup> _SampleTypeLookup = new List<SampleTypeForDiagnosisLookup>();
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAccessionCondition)]
        public BaseReference AccessionCondition
        {
            get { return _AccessionCondition == null ? null : ((long)_AccessionCondition.Key == 0 ? null : _AccessionCondition); }
            set 
            { 
                _AccessionCondition = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAccessionCondition = _AccessionCondition == null 
                    ? new Int64?()
                    : _AccessionCondition.idfsBaseReference; 
                OnPropertyChanged(_str_AccessionCondition); 
            }
        }
        private BaseReference _AccessionCondition;

        
        public BaseReferenceList AccessionConditionLookup
        {
            get { return _AccessionConditionLookup; }
        }
        private BaseReferenceList _AccessionConditionLookup = new BaseReferenceList("rftAccessionCondition");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsBirdStatus)]
        public BaseReference BirdStatus
        {
            get { return _BirdStatus == null ? null : ((long)_BirdStatus.Key == 0 ? null : _BirdStatus); }
            set 
            { 
                _BirdStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsBirdStatus = _BirdStatus == null 
                    ? new Int64?()
                    : _BirdStatus.idfsBaseReference; 
                OnPropertyChanged(_str_BirdStatus); 
            }
        }
        private BaseReference _BirdStatus;

        
        public BaseReferenceList BirdStatusLookup
        {
            get { return _BirdStatusLookup; }
        }
        private BaseReferenceList _BirdStatusLookup = new BaseReferenceList("rftAnimalCondition");
            
        [Relation(typeof(AnimalListItem), eidss.model.Schema.AnimalListItem._str_idfAnimal, _str_idfParty)]
        public AnimalListItem Animal
        {
            get { return _Animal == null ? null : ((long)_Animal.Key == 0 ? null : _Animal); }
            set 
            { 
                _Animal = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfParty = _Animal == null 
                    ? new Int64?()
                    : _Animal.idfAnimal; 
                OnPropertyChanged(_str_Animal); 
            }
        }
        private AnimalListItem _Animal;

        
        public List<AnimalListItem> AnimalLookup
        {
            get 
            { 
                var ret = new List<AnimalListItem>();
                using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    ret.Add(eidss.model.Schema.AnimalListItem.Accessor.Instance(null).CreateNewT(manager, null));
                if (AnimalListFromCase != null)
                    ret.AddRange(AnimalListFromCase
                        .Where(c => !c.IsMarkedToDelete)
                            
                    );
                return ret;
            }
        }
            
        [Relation(typeof(VetFarmTree), eidss.model.Schema.VetFarmTree._str_idfParty, _str_idfParty)]
        public VetFarmTree FarmTree
        {
            get { return _FarmTree == null ? null : ((long)_FarmTree.Key == 0 ? null : _FarmTree); }
            set 
            { 
                _FarmTree = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfParty = _FarmTree == null 
                    ? new Int64?()
                    : _FarmTree.idfParty; 
                OnPropertyChanged(_str_FarmTree); 
            }
        }
        private VetFarmTree _FarmTree;

        
        public List<VetFarmTree> FarmTreeLookup
        {
            get 
            { 
                var ret = new List<VetFarmTree>();
                using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    ret.Add(eidss.model.Schema.VetFarmTree.Accessor.Instance(null).CreateNewT(manager, null));
                if (VetFarmTreeFromCase != null)
                    ret.AddRange(VetFarmTreeFromCase
                        .Where(c => !c.IsMarkedToDelete)
                            
                    );
                return ret;
            }
        }
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_SampleType:
                    return new BvSelectList(SampleTypeLookup, eidss.model.Schema.SampleTypeForDiagnosisLookup._str_idfsReference, null, SampleType, _str_idfsSpecimenType);
            
                case _str_AccessionCondition:
                    return new BvSelectList(AccessionConditionLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AccessionCondition, _str_idfsAccessionCondition);
            
                case _str_BirdStatus:
                    return new BvSelectList(BirdStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, BirdStatus, _str_idfsBirdStatus);
            
                case _str_Animal:
                    return new BvSelectList(AnimalLookup, eidss.model.Schema.AnimalListItem._str_idfAnimal, null, Animal, _str_idfParty);
            
                case _str_FarmTree:
                    return new BvSelectList(FarmTreeLookup, eidss.model.Schema.VetFarmTree._str_idfParty, null, FarmTree, _str_idfParty);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsFinalDiagnosisFromCase)]
        public long? idfsFinalDiagnosisFromCase
        {
            get { return new Func<VetCaseSample, long?>(c => (c.Parent as VetCase).idfsFinalDiagnosis)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsTentativeDiagnosis2FromCase)]
        public long? idfsTentativeDiagnosis2FromCase
        {
            get { return new Func<VetCaseSample, long?>(c => (c.Parent as VetCase).idfsTentativeDiagnosis2)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsTentativeDiagnosis1FromCase)]
        public long? idfsTentativeDiagnosis1FromCase
        {
            get { return new Func<VetCaseSample, long?>(c => (c.Parent as VetCase).idfsTentativeDiagnosis1)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsTentativeDiagnosisFromCase)]
        public long? idfsTentativeDiagnosisFromCase
        {
            get { return new Func<VetCaseSample, long?>(c => (c.Parent as VetCase).idfsTentativeDiagnosis)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_AnimalListFromCase)]
        public EditableList<AnimalListItem> AnimalListFromCase
        {
            get { return new Func<VetCaseSample, EditableList<AnimalListItem>>(c => (c.Parent as VetCase).AnimalList)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_VetFarmTreeFromCase)]
        public List<VetFarmTree> VetFarmTreeFromCase
        {
            get { return new Func<VetCaseSample, List<VetFarmTree>>(c => (c.Parent as VetCase).Farm.FarmTree.Where(a => a.idfsPartyType == (long)PartyTypeEnum.Species).ToList())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseTests)]
        public EditableList<CaseTest> CaseTests
        {
            get { return new Func<VetCaseSample, EditableList<CaseTest>>(c => (c.Parent as VetCase).CaseTests)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_PensideTests)]
        public EditableList<PensideTest> PensideTests
        {
            get { return new Func<VetCaseSample, EditableList<PensideTest>>(c => (c.Parent as VetCase).PensideTests)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("idfsAccessionCondition")]
        public string strAccessionCondition
        {
            get { return new Func<VetCaseSample, string>(c => c.AccessionCondition == null ? "" : c.AccessionCondition.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<VetCaseSample, string>(c => "VetCase_" + c.idfCase + "_")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_AnimalID)]
        public string AnimalID
        {
            get { return new Func<VetCaseSample, string>(c => c.AnimalListFromCase == null || c.AnimalListFromCase.Count == 0 || c.idfParty == null ? "" : c.AnimalListFromCase.Where(a => a.idfAnimal == c.idfParty).Single().strAnimalCode)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Species)]
        public string Species
        {
            get { return new Func<VetCaseSample, string>(c => c.idfParty == null ? "" :
                              (c.AnimalListFromCase == null || c.AnimalListFromCase.Count(a => a.idfAnimal == c.idfParty) == 0 ? 
                                  (c.VetFarmTreeFromCase == null || c.VetFarmTreeFromCase.Count(a => a.idfParty == c.idfParty) == 0 ? "" : c.VetFarmTreeFromCase.Single(a => a.idfParty == c.idfParty).strSpeciesName) 
                              : c.AnimalListFromCase.Single(a => a.idfAnimal == c.idfParty).strSpecies)
                              )(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strBirdStatus)]
        public string strBirdStatus
        {
            get { return new Func<VetCaseSample, string>(c => c.BirdStatus == null ? "" : c.BirdStatus.name)(this); }
            
        }
        
          [LocalizedDisplayName(_str_FilterByDiagnosis)]
        public bool FilterByDiagnosis
        {
            get { return m_FilterByDiagnosis; }
            set { if (m_FilterByDiagnosis != value) { m_FilterByDiagnosis = value; OnPropertyChanged(_str_FilterByDiagnosis); } }
        }
        private bool m_FilterByDiagnosis;
        
          [LocalizedDisplayName(_str_NewObject)]
        public bool NewObject
        {
            get { return m_NewObject; }
            set { if (m_NewObject != value) { m_NewObject = value; OnPropertyChanged(_str_NewObject); } }
        }
        private bool m_NewObject;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "VetCaseSample";

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
            var ret = base.Clone() as VetCaseSample;
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
            var ret = base.Clone() as VetCaseSample;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public VetCaseSample CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VetCaseSample;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfMaterial; } }
        public string KeyName { get { return "idfMaterial"; } }
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
        
            var _prev_idfsSpecimenType_SampleType = idfsSpecimenType;
            var _prev_idfsAccessionCondition_AccessionCondition = idfsAccessionCondition;
            var _prev_idfsBirdStatus_BirdStatus = idfsBirdStatus;
            base.RejectChanges();
        
            if (_prev_idfsSpecimenType_SampleType != idfsSpecimenType)
            {
                _SampleType = _SampleTypeLookup.FirstOrDefault(c => c.idfsReference == idfsSpecimenType);
            }
            if (_prev_idfsAccessionCondition_AccessionCondition != idfsAccessionCondition)
            {
                _AccessionCondition = _AccessionConditionLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAccessionCondition);
            }
            if (_prev_idfsBirdStatus_BirdStatus != idfsBirdStatus)
            {
                _BirdStatus = _BirdStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsBirdStatus);
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

      private bool IsRIRPropChanged(string fld, VetCaseSample c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      
        public override string ToString()
        {
            return new Func<VetCaseSample, string>(c => c.strSpecimenName + " / " + c.strFieldBarcode)(this);
        }
        

        public VetCaseSample()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();

        
        private int? m_HACode;
        public int? _HACode { get { return m_HACode; } set { m_HACode = value; } }
        

        private bool m_IsForcedToDelete;
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VetCaseSample_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VetCaseSample_PropertyChanged);
        }
        private void VetCaseSample_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VetCaseSample).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_idfsFinalDiagnosisFromCase);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_idfsTentativeDiagnosis2FromCase);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_idfsTentativeDiagnosis1FromCase);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_idfsTentativeDiagnosisFromCase);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_AnimalListFromCase);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_VetFarmTreeFromCase);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_CaseTests);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_PensideTests);
                  
            if (e.PropertyName == _str_idfsAccessionCondition)
                OnPropertyChanged(_str_strAccessionCondition);
                  
            if (e.PropertyName == _str_idfCase)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
            if (e.PropertyName == _str_idfParty)
                OnPropertyChanged(_str_AnimalID);
                  
            if (e.PropertyName == _str_AnimalListFromCase)
                OnPropertyChanged(_str_AnimalID);
                  
            if (e.PropertyName == _str_idfParty)
                OnPropertyChanged(_str_Species);
                  
            if (e.PropertyName == _str_AnimalListFromCase)
                OnPropertyChanged(_str_Species);
                  
            if (e.PropertyName == _str_idfsBirdStatus)
                OnPropertyChanged(_str_strBirdStatus);
                  
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
            VetCaseSample obj = this;
            try
            {
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.idfsAccessionCondition == null
                    );
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.CaseTests.Where(i => !i.IsMarkedToDelete && i.idfContainerVet == c.idfMaterial).Count() == 0
                    );
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.PensideTests.Where(i => !i.IsMarkedToDelete && i.idfMaterial == c.idfMaterial).Count() == 0
                    );
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => {
                                     using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                                     {
                                        return manager.SetSpCommand("spLabSample_CheckAccession", manager.Parameter("@idfMaterial", c.idfMaterial)).ExecuteScalar<long>(ScalarSourceType.DataReader, "idfMaterial") == 0;
                                     }}
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
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            VetCaseSample obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VetCaseSample obj = this;
            
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

    
        private static string[] readonly_names1 = "strCondition,strAccessionCondition,datAccession,Species".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strFieldCollectedByOffice,strFieldCollectedByPerson,strSendToOffice".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCaseSample, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCaseSample, bool>(c => true)(this);
            
            return ReadOnly || new Func<VetCaseSample, bool>(c => c.idfsAccessionCondition != null)(this);
                
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


        public Dictionary<string, Func<VetCaseSample, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VetCaseSample, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VetCaseSample, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<VetCaseSample, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<VetCaseSample, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<VetCaseSample, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~VetCaseSample()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("SampleTypeForDiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftAccessionCondition", this);
                
                LookupManager.RemoveObject("rftAnimalCondition", this);
                
                LookupManager.RemoveObject("AnimalListItem", this);
                
                LookupManager.RemoveObject("VetFarmTree", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "SampleTypeForDiagnosisLookup")
                _getAccessor().LoadLookup_SampleType(manager, this);
            
            if (lookup_object == "rftAccessionCondition")
                _getAccessor().LoadLookup_AccessionCondition(manager, this);
            
            if (lookup_object == "rftAnimalCondition")
                _getAccessor().LoadLookup_BirdStatus(manager, this);
            
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
        public class VetCaseSampleGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfMaterial { get; set; }
        
            public string strSpecimenName { get; set; }
        
            public string strFieldBarcode { get; set; }
        
            public string AnimalID { get; set; }
        
            public string Species { get; set; }
        
            public string strBirdStatus { get; set; }
        
            public DateTime? datFieldCollectionDate { get; set; }
        
            public string strSendToOffice { get; set; }
        
            public DateTime? datAccession { get; set; }
        
            public string strAccessionCondition { get; set; }
        
            public string strNote { get; set; }
        
            public string strFieldCollectedByOffice { get; set; }
        
            public string strFieldCollectedByPerson { get; set; }
        
        }
        public partial class VetCaseSampleGridModelList : List<VetCaseSampleGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public VetCaseSampleGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VetCaseSample>, errMes);
            }
            public VetCaseSampleGridModelList(long key, IEnumerable<VetCaseSample> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<VetCaseSample> items);
            private void LoadGridModelList(long key, IEnumerable<VetCaseSample> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strSpecimenName,_str_strFieldBarcode,_str_AnimalID,_str_Species,_str_strBirdStatus,_str_datFieldCollectionDate,_str_strSendToOffice,_str_datAccession,_str_strAccessionCondition,_str_strNote,_str_strFieldCollectedByOffice,_str_strFieldCollectedByPerson};
                    
                Hiddens = new List<string> {_str_idfMaterial};
                Keys = new List<string> {_str_idfMaterial};
                Labels = new Dictionary<string, string> {{_str_strSpecimenName, "idfsSpecimenType"},{_str_strFieldBarcode, "strFieldBarcodeField"},{_str_AnimalID, _str_AnimalID},{_str_Species, _str_Species},{_str_strBirdStatus, _str_strBirdStatus},{_str_datFieldCollectionDate, _str_datFieldCollectionDate},{_str_strSendToOffice, _str_strSendToOffice},{_str_datAccession, _str_datAccession},{_str_strAccessionCondition, "idfsAccessionCondition"},{_str_strNote, "strComment"},{_str_strFieldCollectedByOffice, "CollectedbyInstitution"},{_str_strFieldCollectedByPerson, "CollectedbyOfficer"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<VetCaseSample>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VetCaseSampleGridModel()
                {
                    ItemKey=c.idfMaterial,strSpecimenName=c.strSpecimenName,strFieldBarcode=c.strFieldBarcode,AnimalID=c.AnimalID,Species=c.Species,strBirdStatus=c.strBirdStatus,datFieldCollectionDate=c.datFieldCollectionDate,strSendToOffice=c.strSendToOffice,datAccession=c.datAccession,strAccessionCondition=c.strAccessionCondition,strNote=c.strNote,strFieldCollectedByOffice=c.strFieldCollectedByOffice,strFieldCollectedByPerson=c.strFieldCollectedByPerson
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
        : DataAccessor<VetCaseSample>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(VetCaseSample obj);
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
            private SampleTypeForDiagnosisLookup.Accessor SampleTypeAccessor { get { return eidss.model.Schema.SampleTypeForDiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AccessionConditionAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor BirdStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private AnimalListItem.Accessor AnimalAccessor { get { return eidss.model.Schema.AnimalListItem.Accessor.Instance(m_CS); } }
            private VetFarmTree.Accessor FarmTreeAccessor { get { return eidss.model.Schema.VetFarmTree.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , HACode
                    
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<VetCaseSample> SelectList(DbManagerProxy manager
                , Int64? idfCase
                , int? HACode
                
                )
            {
                return _SelectList(manager
                    , idfCase
                    , HACode
                    
                    , delegate(VetCaseSample obj)
                        {
                        }
                    , delegate(VetCaseSample obj)
                        {
                        }
                    );
            }

            
            private List<VetCaseSample> _SelectList(DbManagerProxy manager
                , Int64? idfCase
                , int? HACode
                
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VetCaseSample> objs = new List<VetCaseSample>();
                    sets[0] = new MapResultSet(typeof(VetCaseSample), objs);
                    
                    manager
                        .SetSpCommand("spCaseSamples_SelectDetail"
                            , manager.Parameter("@idfCase", idfCase)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);
                    foreach(var obj in objs) 
                    {
                        obj.m_CS = m_CS;
                        
                        obj._HACode = HACode;
                        
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, VetCaseSample obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj.FilterByDiagnosis = new Func<VetCaseSample, bool>(c => false)(obj);
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
            
            internal void _SetPermitions(IObjectPermissions permissions, VetCaseSample obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private VetCaseSample _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    VetCaseSample obj = VetCaseSample.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    obj._HACode = HACode;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.FilterByDiagnosis = new Func<VetCaseSample, bool>(c => false)(obj);
                obj.idfMaterial = (new GetNewIDExtender<VetCaseSample>()).GetScalar(manager, obj);
                obj.datFieldCollectionDate = new Func<VetCaseSample, DateTime?>(c => DateTime.Now.Date)(obj);
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

            
            public VetCaseSample CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public VetCaseSample CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public VetCaseSample CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 6) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long?)) 
                    throw new TypeMismatchException("idfSendToOffice", typeof(long?));
                if (pars[1] != null && !(pars[1] is long?)) 
                    throw new TypeMismatchException("idfFieldCollectedByOffice", typeof(long?));
                if (pars[2] != null && !(pars[2] is long?)) 
                    throw new TypeMismatchException("idfFieldCollectedByPerson", typeof(long?));
                if (pars[3] != null && !(pars[3] is string)) 
                    throw new TypeMismatchException("strSendToOffice", typeof(string));
                if (pars[4] != null && !(pars[4] is string)) 
                    throw new TypeMismatchException("strFieldCollectedByOffice", typeof(string));
                if (pars[5] != null && !(pars[5] is string)) 
                    throw new TypeMismatchException("strFieldCollectedByPerson", typeof(string));
                
                return Create(manager, Parent
                    , (long?)pars[0]
                    , (long?)pars[1]
                    , (long?)pars[2]
                    , (string)pars[3]
                    , (string)pars[4]
                    , (string)pars[5]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public VetCaseSample Create(DbManagerProxy manager, IObject Parent
                , long? idfSendToOffice
                , long? idfFieldCollectedByOffice
                , long? idfFieldCollectedByPerson
                , string strSendToOffice
                , string strFieldCollectedByOffice
                , string strFieldCollectedByPerson
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfCase = new Func<VetCaseSample, long>(c => (Parent as VetCase).idfCase)(obj);
                obj._HACode = new Func<VetCaseSample, int?>(c => (Parent as VetCase)._HACode)(obj);
                obj.idfSendToOffice = new Func<VetCaseSample, long?>(c => idfSendToOffice)(obj);
                obj.idfFieldCollectedByOffice = new Func<VetCaseSample, long?>(c => idfFieldCollectedByOffice)(obj);
                obj.idfFieldCollectedByPerson = new Func<VetCaseSample, long?>(c => idfFieldCollectedByPerson)(obj);
                obj.strSendToOffice = new Func<VetCaseSample, string>(c => strSendToOffice)(obj);
                obj.strFieldCollectedByOffice = new Func<VetCaseSample, string>(c => strFieldCollectedByOffice)(obj);
                obj.strFieldCollectedByPerson = new Func<VetCaseSample, string>(c => strFieldCollectedByPerson)(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(VetCaseSample obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VetCaseSample obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datFieldCollectionDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Collection Date_Current date", "datFieldCollectionDate", "datFieldCollectionDate", "datFieldCollectionDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datFieldCollectionDate, DateTime.Now)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFieldCollectionDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_idfsSpecimenType)
                        {
                    
                obj.strSpecimenName = new Func<VetCaseSample, string>(c => c.SampleType == null ? "" : c.SampleType.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_FilterByDiagnosis)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_SampleType(manager, obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_SampleType(DbManagerProxy manager, VetCaseSample obj)
            {
                
                obj.SampleTypeLookup.Clear();
                
                obj.SampleTypeLookup.Add(SampleTypeAccessor.CreateNewT(manager, null));
                
                obj.SampleTypeLookup.AddRange(SampleTypeAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intHACode & obj._HACode) != 0 || c.idfsReference == obj.idfsSpecimenType)
                        
                    .Where(c => !obj.FilterByDiagnosis ? 
                              (
                                  c.idfsDiagnosis == 0
                              )
                              :
                              (
                                  c.idfsDiagnosis == obj.idfsFinalDiagnosisFromCase ||
                                  c.idfsDiagnosis == obj.idfsTentativeDiagnosis2FromCase ||
                                  c.idfsDiagnosis == obj.idfsTentativeDiagnosis1FromCase ||
                                  c.idfsDiagnosis == obj.idfsTentativeDiagnosisFromCase
                              ))
                        
                    .Where(c => c.idfsReference != (long)SampleTypeEnum.Unknown)
                        
                    .Distinct(new SampleTypeForDiagnosisLookupComparator())
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsSpecimenType))
                    
                    .ToList());
                
                if (obj.idfsSpecimenType != 0)
                {
                    obj.SampleType = obj.SampleTypeLookup
                        .Where(c => c.idfsReference == obj.idfsSpecimenType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("SampleTypeForDiagnosisLookup", obj, SampleTypeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_AccessionCondition(DbManagerProxy manager, VetCaseSample obj)
            {
                
                obj.AccessionConditionLookup.Clear();
                
                obj.AccessionConditionLookup.Add(AccessionConditionAccessor.CreateNewT(manager, null));
                
                obj.AccessionConditionLookup.AddRange(AccessionConditionAccessor.rftAccessionCondition_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAccessionCondition))
                    
                    .ToList());
                
                if (obj.idfsAccessionCondition != null && obj.idfsAccessionCondition != 0)
                {
                    obj.AccessionCondition = obj.AccessionConditionLookup
                        .Where(c => c.idfsBaseReference == obj.idfsAccessionCondition)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftAccessionCondition", obj, AccessionConditionAccessor.GetType(), "rftAccessionCondition_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_BirdStatus(DbManagerProxy manager, VetCaseSample obj)
            {
                
                obj.BirdStatusLookup.Clear();
                
                obj.BirdStatusLookup.Add(BirdStatusAccessor.CreateNewT(manager, null));
                
                obj.BirdStatusLookup.AddRange(BirdStatusAccessor.rftAnimalCondition_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode & obj._HACode) != 0)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsBirdStatus))
                    
                    .ToList());
                
                if (obj.idfsBirdStatus != null && obj.idfsBirdStatus != 0)
                {
                    obj.BirdStatus = obj.BirdStatusLookup
                        .Where(c => c.idfsBaseReference == obj.idfsBirdStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftAnimalCondition", obj, BirdStatusAccessor.GetType(), "rftAnimalCondition_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, VetCaseSample obj)
            {
                
                LoadLookup_SampleType(manager, obj);
                
                LoadLookup_AccessionCondition(manager, obj);
                
                LoadLookup_BirdStatus(manager, obj);
                
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
        
            [SprocName("spLabSample_Create")]
            protected abstract void _postInsert(DbManagerProxy manager, 
                [Direction.InputOutput("idfMaterial")] VetCaseSample obj);
            protected void _postInsertPredicate(DbManagerProxy manager, 
                [Direction.InputOutput("idfMaterial")] VetCaseSample obj)
            {
                
                _postInsert(manager, obj);
                
            }
        
            [SprocName("spLabSample_Update")]
            protected abstract void _postUpdate(DbManagerProxy manager, 
                [Direction.InputOutput()] VetCaseSample obj);
            protected void _postUpdatePredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] VetCaseSample obj)
            {
                
                _postUpdate(manager, obj);
                
            }
        
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    VetCaseSample bo = obj as VetCaseSample;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as VetCaseSample, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VetCaseSample obj, bool bChildObject) 
            { 
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
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postInsertPredicate(manager, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postUpdatePredicate(manager, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(VetCaseSample obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, VetCaseSample obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as VetCaseSample, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VetCaseSample obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "SampleType", "SampleType","",
                false
              )).Validate(c => true, obj, obj.SampleType);
            
                (new RequiredValidator( "idfParty", "Animal","AnimalID",
                false
              )).Validate(c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Livestock, obj, obj.idfParty);
            
                (new RequiredValidator( "idfParty", "FarmTree","Species",
                false
              )).Validate(c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Avian, obj, obj.idfParty);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                (new PredicateValidator("Collection Date_Current date", "datFieldCollectionDate", "datFieldCollectionDate", "datFieldCollectionDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datFieldCollectionDate, DateTime.Now)
                    );
            
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
           
    
            private void _SetupRequired(VetCaseSample obj)
            {
            
                obj
                    .AddRequired("SampleType", c => true);
                    
                obj
                    .AddRequired("Animal", c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Livestock);
                    
                obj
                    .AddRequired("FarmTree", c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Avian);
                    
            }
    
    private void _SetupPersonalDataRestrictions(VetCaseSample obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VetCaseSample) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VetCaseSample) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VetCaseSampleDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spCaseSamples_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "spLabSample_Create";
            public static string spUpdate = "spLabSample_Update";
            public static string spDelete = "spLabSample_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VetCaseSample, bool>> RequiredByField = new Dictionary<string, Func<VetCaseSample, bool>>();
            public static Dictionary<string, Func<VetCaseSample, bool>> RequiredByProperty = new Dictionary<string, Func<VetCaseSample, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_AnimalName, 2000);
                Sizes.Add(_str_strAnimalCode, 200);
                Sizes.Add(_str_SpeciesName, 2000);
                Sizes.Add(_str_strFarmCode, 200);
                Sizes.Add(_str_strFieldCollectedByPerson, 602);
                Sizes.Add(_str_strFieldCollectedByOffice, 2000);
                Sizes.Add(_str_strSendToOffice, 2000);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strSpecimenName, 2000);
                Sizes.Add(_str_strCondition, 200);
                Sizes.Add(_str_strNote, 500);
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strVectorID, 50);
                Sizes.Add(_str_strVectorType, 2000);
                Sizes.Add(_str_strVectorSpecies, 2000);
                if (!RequiredByField.ContainsKey("SampleType")) RequiredByField.Add("SampleType", c => true);
                if (!RequiredByProperty.ContainsKey("SampleType")) RequiredByProperty.Add("SampleType", c => true);
                
                if (!RequiredByField.ContainsKey("idfParty")) RequiredByField.Add("idfParty", c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Livestock);
                if (!RequiredByProperty.ContainsKey("Animal")) RequiredByProperty.Add("Animal", c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Livestock);
                
                if (!RequiredByField.ContainsKey("idfParty")) RequiredByField.Add("idfParty", c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Avian);
                if (!RequiredByProperty.ContainsKey("FarmTree")) RequiredByProperty.Add("FarmTree", c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Avian);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfMaterial,
                    _str_idfMaterial, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpecimenName,
                    "idfsSpecimenType", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode,
                    "strFieldBarcodeField", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalID,
                    _str_AnimalID, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Species,
                    _str_Species, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBirdStatus,
                    _str_strBirdStatus, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldCollectionDate,
                    _str_datFieldCollectionDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSendToOffice,
                    _str_strSendToOffice, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datAccession,
                    _str_datAccession, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAccessionCondition,
                    "idfsAccessionCondition", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNote,
                    "strComment", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldCollectedByOffice,
                    "CollectedbyInstitution", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldCollectedByPerson,
                    "CollectedbyOfficer", null, true, true, null
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
                    (manager, c, pars) => ((VetCaseSample)c).MarkToDelete(),
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
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class VetCaseSampleTest : 
        EditableObject<VetCaseSampleTest>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfVetCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfVetCase { get; set; }
                
        [LocalizedDisplayName(_str_strSampleNotes)]
        [MapField(_str_strSampleNotes)]
        public abstract String strSampleNotes { get; set; }
        #if MONO
        protected String strSampleNotes_Original { get { return strSampleNotes; } }
        protected String strSampleNotes_Previous { get { return strSampleNotes; } }
        #else
        protected String strSampleNotes_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleNotes).OriginalValue; } }
        protected String strSampleNotes_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleNotes).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<VetCaseSampleTest, object> _get_func;
            internal Action<VetCaseSampleTest, string> _set_func;
            internal Action<VetCaseSampleTest, VetCaseSampleTest, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfVetCase = "idfVetCase";
        internal const string _str_strSampleNotes = "strSampleNotes";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfVetCase, _type = "Int64",
              _get_func = o => o.idfVetCase,
              _set_func = (o, val) => { o.idfVetCase = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVetCase != c.idfVetCase || o.IsRIRPropChanged(_str_idfVetCase, c)) 
                  m.Add(_str_idfVetCase, o.ObjectIdent + _str_idfVetCase, "Int64", o.idfVetCase == null ? "" : o.idfVetCase.ToString(), o.IsReadOnly(_str_idfVetCase), o.IsInvisible(_str_idfVetCase), o.IsRequired(_str_idfVetCase)); }
              }, 
        
            new field_info {
              _name = _str_strSampleNotes, _type = "String",
              _get_func = o => o.strSampleNotes,
              _set_func = (o, val) => { o.strSampleNotes = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSampleNotes != c.strSampleNotes || o.IsRIRPropChanged(_str_strSampleNotes, c)) 
                  m.Add(_str_strSampleNotes, o.ObjectIdent + _str_strSampleNotes, "String", o.strSampleNotes == null ? "" : o.strSampleNotes.ToString(), o.IsReadOnly(_str_strSampleNotes), o.IsInvisible(_str_strSampleNotes), o.IsRequired(_str_strSampleNotes)); }
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
            VetCaseSampleTest obj = (VetCaseSampleTest)o;
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
        internal string m_ObjectName = "VetCaseSampleTest";

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
            var ret = base.Clone() as VetCaseSampleTest;
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
            var ret = base.Clone() as VetCaseSampleTest;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public VetCaseSampleTest CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VetCaseSampleTest;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfVetCase; } }
        public string KeyName { get { return "idfVetCase"; } }
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

      private bool IsRIRPropChanged(string fld, VetCaseSampleTest c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public VetCaseSampleTest()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VetCaseSampleTest_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VetCaseSampleTest_PropertyChanged);
        }
        private void VetCaseSampleTest_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VetCaseSampleTest).Changed(e.PropertyName);
            
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
            VetCaseSampleTest obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VetCaseSampleTest obj = this;
            
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


        public Dictionary<string, Func<VetCaseSampleTest, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VetCaseSampleTest, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VetCaseSampleTest, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<VetCaseSampleTest, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<VetCaseSampleTest, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<VetCaseSampleTest, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~VetCaseSampleTest()
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
        : DataAccessor<VetCaseSampleTest>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(VetCaseSampleTest obj);
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
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<VetCaseSampleTest> SelectList(DbManagerProxy manager
                , Int64? idfCase
                )
            {
                return _SelectList(manager
                    , idfCase
                    , delegate(VetCaseSampleTest obj)
                        {
                        }
                    , delegate(VetCaseSampleTest obj)
                        {
                        }
                    );
            }

            
            private List<VetCaseSampleTest> _SelectList(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VetCaseSampleTest> objs = new List<VetCaseSampleTest>();
                    sets[0] = new MapResultSet(typeof(VetCaseSampleTest), objs);
                    
                    manager
                        .SetSpCommand("spCaseSamples_SelectDetail"
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, VetCaseSampleTest obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, VetCaseSampleTest obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private VetCaseSampleTest _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    VetCaseSampleTest obj = VetCaseSampleTest.CreateInstance();
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

            
            public VetCaseSampleTest CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public VetCaseSampleTest CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(VetCaseSampleTest obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VetCaseSampleTest obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, VetCaseSampleTest obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as VetCaseSampleTest, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VetCaseSampleTest obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(VetCaseSampleTest obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(VetCaseSampleTest obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VetCaseSampleTest) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VetCaseSampleTest) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VetCaseSampleTestDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spCaseSamples_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VetCaseSampleTest, bool>> RequiredByField = new Dictionary<string, Func<VetCaseSampleTest, bool>>();
            public static Dictionary<string, Func<VetCaseSampleTest, bool>> RequiredByProperty = new Dictionary<string, Func<VetCaseSampleTest, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strSampleNotes, 1000);
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
                    (manager, c, pars) => ((VetCaseSampleTest)c).MarkToDelete(),
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
	