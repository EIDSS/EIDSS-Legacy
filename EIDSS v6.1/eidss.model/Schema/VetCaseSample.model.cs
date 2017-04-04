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
    public abstract partial class VetCaseSample : 
        EditableObject<VetCaseSample>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfMaterial), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMaterial { get; set; }
                
        [LocalizedDisplayName(_str_idfsSampleType)]
        [MapField(_str_idfsSampleType)]
        public abstract Int64 idfsSampleType { get; set; }
        protected Int64 idfsSampleType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSampleType).OriginalValue; } }
        protected Int64 idfsSampleType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSampleType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfRootMaterial)]
        [MapField(_str_idfRootMaterial)]
        public abstract Int64? idfRootMaterial { get; set; }
        protected Int64? idfRootMaterial_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootMaterial).OriginalValue; } }
        protected Int64? idfRootMaterial_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootMaterial).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfParty)]
        [MapField(_str_idfParty)]
        public abstract Int64? idfParty { get; set; }
        protected Int64? idfParty_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParty).OriginalValue; } }
        protected Int64? idfParty_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParty).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_SpeciesName)]
        [MapField(_str_SpeciesName)]
        public abstract String SpeciesName { get; set; }
        protected String SpeciesName_Original { get { return ((EditableValue<String>)((dynamic)this)._speciesName).OriginalValue; } }
        protected String SpeciesName_Previous { get { return ((EditableValue<String>)((dynamic)this)._speciesName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFarmCode)]
        [MapField(_str_strFarmCode)]
        public abstract String strFarmCode { get; set; }
        protected String strFarmCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).OriginalValue; } }
        protected String strFarmCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSpeciesType)]
        [MapField(_str_idfsSpeciesType)]
        public abstract Int64? idfsSpeciesType { get; set; }
        protected Int64? idfsSpeciesType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).OriginalValue; } }
        protected Int64? idfsSpeciesType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfFieldCollectedByPerson)]
        [MapField(_str_idfFieldCollectedByPerson)]
        public abstract Int64? idfFieldCollectedByPerson { get; set; }
        protected Int64? idfFieldCollectedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByPerson).OriginalValue; } }
        protected Int64? idfFieldCollectedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName("CollectedbyOfficer")]
        [MapField(_str_strFieldCollectedByPerson)]
        public abstract String strFieldCollectedByPerson { get; set; }
        protected String strFieldCollectedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByPerson).OriginalValue; } }
        protected String strFieldCollectedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfFieldCollectedByOffice)]
        [MapField(_str_idfFieldCollectedByOffice)]
        public abstract Int64? idfFieldCollectedByOffice { get; set; }
        protected Int64? idfFieldCollectedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).OriginalValue; } }
        protected Int64? idfFieldCollectedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName("CollectedbyInstitution")]
        [MapField(_str_strFieldCollectedByOffice)]
        public abstract String strFieldCollectedByOffice { get; set; }
        protected String strFieldCollectedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByOffice).OriginalValue; } }
        protected String strFieldCollectedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName("strSendToOrganization")]
        [MapField(_str_idfSendToOffice)]
        public abstract Int64? idfSendToOffice { get; set; }
        protected Int64? idfSendToOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).OriginalValue; } }
        protected Int64? idfSendToOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).PreviousValue; } }
                
        [LocalizedDisplayName("strSendToOrganization")]
        [MapField(_str_strSendToOffice)]
        public abstract String strSendToOffice { get; set; }
        protected String strSendToOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strSendToOffice).OriginalValue; } }
        protected String strSendToOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSendToOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMainTest)]
        [MapField(_str_idfMainTest)]
        public abstract Int64? idfMainTest { get; set; }
        protected Int64? idfMainTest_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMainTest).OriginalValue; } }
        protected Int64? idfMainTest_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMainTest).PreviousValue; } }
                
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
                
        [LocalizedDisplayName("strFieldBarcodeField")]
        [MapField(_str_strFieldBarcode)]
        public abstract String strFieldBarcode { get; set; }
        protected String strFieldBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).OriginalValue; } }
        protected String strFieldBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64? idfCase { get; set; }
        protected Int64? idfCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64? idfCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMonitoringSession)]
        [MapField(_str_idfMonitoringSession)]
        public abstract Int64? idfMonitoringSession { get; set; }
        protected Int64? idfMonitoringSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).OriginalValue; } }
        protected Int64? idfMonitoringSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsBirdStatus)]
        [MapField(_str_idfsBirdStatus)]
        public abstract Int64? idfsBirdStatus { get; set; }
        protected Int64? idfsBirdStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBirdStatus).OriginalValue; } }
        protected Int64? idfsBirdStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBirdStatus).PreviousValue; } }
                
        [LocalizedDisplayName("idfsSampleType")]
        [MapField(_str_strSampleName)]
        public abstract String strSampleName { get; set; }
        protected String strSampleName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).OriginalValue; } }
        protected String strSampleName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datAccession)]
        [MapField(_str_datAccession)]
        public abstract DateTime? datAccession { get; set; }
        protected DateTime? datAccession_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).OriginalValue; } }
        protected DateTime? datAccession_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).PreviousValue; } }
                
        [LocalizedDisplayName("strComment")]
        [MapField(_str_strCondition)]
        public abstract String strCondition { get; set; }
        protected String strCondition_Original { get { return ((EditableValue<String>)((dynamic)this)._strCondition).OriginalValue; } }
        protected String strCondition_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCondition).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsAccessionCondition)]
        [MapField(_str_idfsAccessionCondition)]
        public abstract Int64? idfsAccessionCondition { get; set; }
        protected Int64? idfsAccessionCondition_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAccessionCondition).OriginalValue; } }
        protected Int64? idfsAccessionCondition_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAccessionCondition).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfAccesionByPerson)]
        [MapField(_str_idfAccesionByPerson)]
        public abstract Int64? idfAccesionByPerson { get; set; }
        protected Int64? idfAccesionByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAccesionByPerson).OriginalValue; } }
        protected Int64? idfAccesionByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAccesionByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_Used)]
        [MapField(_str_Used)]
        public abstract Int32 Used { get; set; }
        protected Int32 Used_Original { get { return ((EditableValue<Int32>)((dynamic)this)._used).OriginalValue; } }
        protected Int32 Used_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._used).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_strNote)]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsVectorType)]
        [MapField(_str_idfsVectorType)]
        public abstract Int64? idfsVectorType { get; set; }
        protected Int64? idfsVectorType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVectorType).OriginalValue; } }
        protected Int64? idfsVectorType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVectorType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsVectorSubType)]
        [MapField(_str_idfsVectorSubType)]
        public abstract Int64? idfsVectorSubType { get; set; }
        protected Int64? idfsVectorSubType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVectorSubType).OriginalValue; } }
        protected Int64? idfsVectorSubType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVectorSubType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intQuantity)]
        [MapField(_str_intQuantity)]
        public abstract Int32? intQuantity { get; set; }
        protected Int32? intQuantity_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intQuantity).OriginalValue; } }
        protected Int32? intQuantity_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intQuantity).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datCollectionDateTime)]
        [MapField(_str_datCollectionDateTime)]
        public abstract DateTime? datCollectionDateTime { get; set; }
        protected DateTime? datCollectionDateTime_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCollectionDateTime).OriginalValue; } }
        protected DateTime? datCollectionDateTime_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCollectionDateTime).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfLocation)]
        [MapField(_str_idfLocation)]
        public abstract Int64? idfLocation { get; set; }
        protected Int64? idfLocation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfLocation).OriginalValue; } }
        protected Int64? idfLocation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfLocation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strBarcode)]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strVectorID)]
        [MapField(_str_strVectorID)]
        public abstract String strVectorID { get; set; }
        protected String strVectorID_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).OriginalValue; } }
        protected String strVectorID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strVectorType)]
        [MapField(_str_strVectorType)]
        public abstract String strVectorType { get; set; }
        protected String strVectorType_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).OriginalValue; } }
        protected String strVectorType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strVectorSpecies)]
        [MapField(_str_strVectorSpecies)]
        public abstract String strVectorSpecies { get; set; }
        protected String strVectorSpecies_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorSpecies).OriginalValue; } }
        protected String strVectorSpecies_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorSpecies).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSampleStatus)]
        [MapField(_str_idfsSampleStatus)]
        public abstract Int64? idfsSampleStatus { get; set; }
        protected Int64? idfsSampleStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleStatus).OriginalValue; } }
        protected Int64? idfsSampleStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleStatus).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_uidOfflineCaseID)]
        [MapField(_str_uidOfflineCaseID)]
        public abstract Guid? uidOfflineCaseID { get; set; }
        protected Guid? uidOfflineCaseID_Original { get { return ((EditableValue<Guid?>)((dynamic)this)._uidOfflineCaseID).OriginalValue; } }
        protected Guid? uidOfflineCaseID_Previous { get { return ((EditableValue<Guid?>)((dynamic)this)._uidOfflineCaseID).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<VetCaseSample, object> _get_func;
            internal Action<VetCaseSample, string> _set_func;
            internal Action<VetCaseSample, VetCaseSample, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_idfsSampleType = "idfsSampleType";
        internal const string _str_idfRootMaterial = "idfRootMaterial";
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
        internal const string _str_idfMainTest = "idfMainTest";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_datFieldSentDate = "datFieldSentDate";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_idfsBirdStatus = "idfsBirdStatus";
        internal const string _str_strSampleName = "strSampleName";
        internal const string _str_datAccession = "datAccession";
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
        internal const string _str_idfsSampleStatus = "idfsSampleStatus";
        internal const string _str_idfSpecies = "idfSpecies";
        internal const string _str_idfAnimal = "idfAnimal";
        internal const string _str_uidOfflineCaseID = "uidOfflineCaseID";
        internal const string _str_FilterByDiagnosis = "FilterByDiagnosis";
        internal const string _str_idfsFinalDiagnosisFromCase = "idfsFinalDiagnosisFromCase";
        internal const string _str_idfsTentativeDiagnosis2FromCase = "idfsTentativeDiagnosis2FromCase";
        internal const string _str_idfsTentativeDiagnosis1FromCase = "idfsTentativeDiagnosis1FromCase";
        internal const string _str_idfsTentativeDiagnosisFromCase = "idfsTentativeDiagnosisFromCase";
        internal const string _str_AnimalListFromCase = "AnimalListFromCase";
        internal const string _str_VetFarmTreeFromCase = "VetFarmTreeFromCase";
        internal const string _str_CaseSamples = "CaseSamples";
        internal const string _str_CaseTests = "CaseTests";
        internal const string _str_PensideTests = "PensideTests";
        internal const string _str_strAccessionCondition = "strAccessionCondition";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_AnimalID = "AnimalID";
        internal const string _str_Species = "Species";
        internal const string _str_strBirdStatus = "strBirdStatus";
        internal const string _str_SampleTypeForDiagnosis = "SampleTypeForDiagnosis";
        internal const string _str_AccessionCondition = "AccessionCondition";
        internal const string _str_BirdStatus = "BirdStatus";
        internal const string _str_Animal = "Animal";
        internal const string _str_FarmTree = "FarmTree";
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
              _name = _str_idfsSampleType, _formname = _str_idfsSampleType, _type = "Int64",
              _get_func = o => o.idfsSampleType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsSampleType != newval) 
                  o.SampleTypeForDiagnosis = o.SampleTypeForDiagnosisLookup.FirstOrDefault(c => c.idfsReference == newval);
                if (o.idfsSampleType != newval) o.idfsSampleType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSampleType != c.idfsSampleType || o.IsRIRPropChanged(_str_idfsSampleType, c)) 
                  m.Add(_str_idfsSampleType, o.ObjectIdent + _str_idfsSampleType, o.ObjectIdent2 + _str_idfsSampleType, o.ObjectIdent3 + _str_idfsSampleType, "Int64", 
                    o.idfsSampleType == null ? "" : o.idfsSampleType.ToString(),                  
                  o.IsReadOnly(_str_idfsSampleType), o.IsInvisible(_str_idfsSampleType), o.IsRequired(_str_idfsSampleType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfRootMaterial, _formname = _str_idfRootMaterial, _type = "Int64?",
              _get_func = o => o.idfRootMaterial,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfRootMaterial != newval) o.idfRootMaterial = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfRootMaterial != c.idfRootMaterial || o.IsRIRPropChanged(_str_idfRootMaterial, c)) 
                  m.Add(_str_idfRootMaterial, o.ObjectIdent + _str_idfRootMaterial, o.ObjectIdent2 + _str_idfRootMaterial, o.ObjectIdent3 + _str_idfRootMaterial, "Int64?", 
                    o.idfRootMaterial == null ? "" : o.idfRootMaterial.ToString(),                  
                  o.IsReadOnly(_str_idfRootMaterial), o.IsInvisible(_str_idfRootMaterial), o.IsRequired(_str_idfRootMaterial)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfParty, _formname = _str_idfParty, _type = "Int64?",
              _get_func = o => o.idfParty,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfParty != newval) 
                  o.Animal = o.AnimalLookup.FirstOrDefault(c => c.idfAnimal == newval);
                if (o.idfParty != newval) o.idfParty = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_idfParty, c)) 
                  m.Add(_str_idfParty, o.ObjectIdent + _str_idfParty, o.ObjectIdent2 + _str_idfParty, o.ObjectIdent3 + _str_idfParty, "Int64?", 
                    o.idfParty == null ? "" : o.idfParty.ToString(),                  
                  o.IsReadOnly(_str_idfParty), o.IsInvisible(_str_idfParty), o.IsRequired(_str_idfParty)); 
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
              _name = _str_SpeciesName, _formname = _str_SpeciesName, _type = "String",
              _get_func = o => o.SpeciesName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.SpeciesName != newval) o.SpeciesName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.SpeciesName != c.SpeciesName || o.IsRIRPropChanged(_str_SpeciesName, c)) 
                  m.Add(_str_SpeciesName, o.ObjectIdent + _str_SpeciesName, o.ObjectIdent2 + _str_SpeciesName, o.ObjectIdent3 + _str_SpeciesName, "String", 
                    o.SpeciesName == null ? "" : o.SpeciesName.ToString(),                  
                  o.IsReadOnly(_str_SpeciesName), o.IsInvisible(_str_SpeciesName), o.IsRequired(_str_SpeciesName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFarmCode, _formname = _str_strFarmCode, _type = "String",
              _get_func = o => o.strFarmCode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFarmCode != newval) o.strFarmCode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFarmCode != c.strFarmCode || o.IsRIRPropChanged(_str_strFarmCode, c)) 
                  m.Add(_str_strFarmCode, o.ObjectIdent + _str_strFarmCode, o.ObjectIdent2 + _str_strFarmCode, o.ObjectIdent3 + _str_strFarmCode, "String", 
                    o.strFarmCode == null ? "" : o.strFarmCode.ToString(),                  
                  o.IsReadOnly(_str_strFarmCode), o.IsInvisible(_str_strFarmCode), o.IsRequired(_str_strFarmCode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSpeciesType, _formname = _str_idfsSpeciesType, _type = "Int64?",
              _get_func = o => o.idfsSpeciesType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSpeciesType != newval) o.idfsSpeciesType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_idfsSpeciesType, c)) 
                  m.Add(_str_idfsSpeciesType, o.ObjectIdent + _str_idfsSpeciesType, o.ObjectIdent2 + _str_idfsSpeciesType, o.ObjectIdent3 + _str_idfsSpeciesType, "Int64?", 
                    o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(),                  
                  o.IsReadOnly(_str_idfsSpeciesType), o.IsInvisible(_str_idfsSpeciesType), o.IsRequired(_str_idfsSpeciesType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfFieldCollectedByPerson, _formname = _str_idfFieldCollectedByPerson, _type = "Int64?",
              _get_func = o => o.idfFieldCollectedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfFieldCollectedByPerson != newval) o.idfFieldCollectedByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfFieldCollectedByPerson != c.idfFieldCollectedByPerson || o.IsRIRPropChanged(_str_idfFieldCollectedByPerson, c)) 
                  m.Add(_str_idfFieldCollectedByPerson, o.ObjectIdent + _str_idfFieldCollectedByPerson, o.ObjectIdent2 + _str_idfFieldCollectedByPerson, o.ObjectIdent3 + _str_idfFieldCollectedByPerson, "Int64?", 
                    o.idfFieldCollectedByPerson == null ? "" : o.idfFieldCollectedByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfFieldCollectedByPerson), o.IsInvisible(_str_idfFieldCollectedByPerson), o.IsRequired(_str_idfFieldCollectedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFieldCollectedByPerson, _formname = _str_strFieldCollectedByPerson, _type = "String",
              _get_func = o => o.strFieldCollectedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFieldCollectedByPerson != newval) o.strFieldCollectedByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFieldCollectedByPerson != c.strFieldCollectedByPerson || o.IsRIRPropChanged(_str_strFieldCollectedByPerson, c)) 
                  m.Add(_str_strFieldCollectedByPerson, o.ObjectIdent + _str_strFieldCollectedByPerson, o.ObjectIdent2 + _str_strFieldCollectedByPerson, o.ObjectIdent3 + _str_strFieldCollectedByPerson, "String", 
                    o.strFieldCollectedByPerson == null ? "" : o.strFieldCollectedByPerson.ToString(),                  
                  o.IsReadOnly(_str_strFieldCollectedByPerson), o.IsInvisible(_str_strFieldCollectedByPerson), o.IsRequired(_str_strFieldCollectedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfFieldCollectedByOffice, _formname = _str_idfFieldCollectedByOffice, _type = "Int64?",
              _get_func = o => o.idfFieldCollectedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfFieldCollectedByOffice != newval) o.idfFieldCollectedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfFieldCollectedByOffice != c.idfFieldCollectedByOffice || o.IsRIRPropChanged(_str_idfFieldCollectedByOffice, c)) 
                  m.Add(_str_idfFieldCollectedByOffice, o.ObjectIdent + _str_idfFieldCollectedByOffice, o.ObjectIdent2 + _str_idfFieldCollectedByOffice, o.ObjectIdent3 + _str_idfFieldCollectedByOffice, "Int64?", 
                    o.idfFieldCollectedByOffice == null ? "" : o.idfFieldCollectedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfFieldCollectedByOffice), o.IsInvisible(_str_idfFieldCollectedByOffice), o.IsRequired(_str_idfFieldCollectedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFieldCollectedByOffice, _formname = _str_strFieldCollectedByOffice, _type = "String",
              _get_func = o => o.strFieldCollectedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFieldCollectedByOffice != newval) o.strFieldCollectedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFieldCollectedByOffice != c.strFieldCollectedByOffice || o.IsRIRPropChanged(_str_strFieldCollectedByOffice, c)) 
                  m.Add(_str_strFieldCollectedByOffice, o.ObjectIdent + _str_strFieldCollectedByOffice, o.ObjectIdent2 + _str_strFieldCollectedByOffice, o.ObjectIdent3 + _str_strFieldCollectedByOffice, "String", 
                    o.strFieldCollectedByOffice == null ? "" : o.strFieldCollectedByOffice.ToString(),                  
                  o.IsReadOnly(_str_strFieldCollectedByOffice), o.IsInvisible(_str_strFieldCollectedByOffice), o.IsRequired(_str_strFieldCollectedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSendToOffice, _formname = _str_idfSendToOffice, _type = "Int64?",
              _get_func = o => o.idfSendToOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfSendToOffice != newval) o.idfSendToOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfSendToOffice != c.idfSendToOffice || o.IsRIRPropChanged(_str_idfSendToOffice, c)) 
                  m.Add(_str_idfSendToOffice, o.ObjectIdent + _str_idfSendToOffice, o.ObjectIdent2 + _str_idfSendToOffice, o.ObjectIdent3 + _str_idfSendToOffice, "Int64?", 
                    o.idfSendToOffice == null ? "" : o.idfSendToOffice.ToString(),                  
                  o.IsReadOnly(_str_idfSendToOffice), o.IsInvisible(_str_idfSendToOffice), o.IsRequired(_str_idfSendToOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSendToOffice, _formname = _str_strSendToOffice, _type = "String",
              _get_func = o => o.strSendToOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSendToOffice != newval) o.strSendToOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSendToOffice != c.strSendToOffice || o.IsRIRPropChanged(_str_strSendToOffice, c)) 
                  m.Add(_str_strSendToOffice, o.ObjectIdent + _str_strSendToOffice, o.ObjectIdent2 + _str_strSendToOffice, o.ObjectIdent3 + _str_strSendToOffice, "String", 
                    o.strSendToOffice == null ? "" : o.strSendToOffice.ToString(),                  
                  o.IsReadOnly(_str_strSendToOffice), o.IsInvisible(_str_strSendToOffice), o.IsRequired(_str_strSendToOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfMainTest, _formname = _str_idfMainTest, _type = "Int64?",
              _get_func = o => o.idfMainTest,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfMainTest != newval) o.idfMainTest = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfMainTest != c.idfMainTest || o.IsRIRPropChanged(_str_idfMainTest, c)) 
                  m.Add(_str_idfMainTest, o.ObjectIdent + _str_idfMainTest, o.ObjectIdent2 + _str_idfMainTest, o.ObjectIdent3 + _str_idfMainTest, "Int64?", 
                    o.idfMainTest == null ? "" : o.idfMainTest.ToString(),                  
                  o.IsReadOnly(_str_idfMainTest), o.IsInvisible(_str_idfMainTest), o.IsRequired(_str_idfMainTest)); 
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
              _name = _str_datFieldSentDate, _formname = _str_datFieldSentDate, _type = "DateTime?",
              _get_func = o => o.datFieldSentDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datFieldSentDate != newval) o.datFieldSentDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datFieldSentDate != c.datFieldSentDate || o.IsRIRPropChanged(_str_datFieldSentDate, c)) 
                  m.Add(_str_datFieldSentDate, o.ObjectIdent + _str_datFieldSentDate, o.ObjectIdent2 + _str_datFieldSentDate, o.ObjectIdent3 + _str_datFieldSentDate, "DateTime?", 
                    o.datFieldSentDate == null ? "" : o.datFieldSentDate.ToString(),                  
                  o.IsReadOnly(_str_datFieldSentDate), o.IsInvisible(_str_datFieldSentDate), o.IsRequired(_str_datFieldSentDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFieldBarcode, _formname = _str_strFieldBarcode, _type = "String",
              _get_func = o => o.strFieldBarcode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFieldBarcode != newval) o.strFieldBarcode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFieldBarcode != c.strFieldBarcode || o.IsRIRPropChanged(_str_strFieldBarcode, c)) 
                  m.Add(_str_strFieldBarcode, o.ObjectIdent + _str_strFieldBarcode, o.ObjectIdent2 + _str_strFieldBarcode, o.ObjectIdent3 + _str_strFieldBarcode, "String", 
                    o.strFieldBarcode == null ? "" : o.strFieldBarcode.ToString(),                  
                  o.IsReadOnly(_str_strFieldBarcode), o.IsInvisible(_str_strFieldBarcode), o.IsRequired(_str_strFieldBarcode)); 
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
              _name = _str_idfsBirdStatus, _formname = _str_idfsBirdStatus, _type = "Int64?",
              _get_func = o => o.idfsBirdStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsBirdStatus != newval) 
                  o.BirdStatus = o.BirdStatusLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsBirdStatus != newval) o.idfsBirdStatus = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsBirdStatus != c.idfsBirdStatus || o.IsRIRPropChanged(_str_idfsBirdStatus, c)) 
                  m.Add(_str_idfsBirdStatus, o.ObjectIdent + _str_idfsBirdStatus, o.ObjectIdent2 + _str_idfsBirdStatus, o.ObjectIdent3 + _str_idfsBirdStatus, "Int64?", 
                    o.idfsBirdStatus == null ? "" : o.idfsBirdStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsBirdStatus), o.IsInvisible(_str_idfsBirdStatus), o.IsRequired(_str_idfsBirdStatus)); 
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
              _name = _str_strCondition, _formname = _str_strCondition, _type = "String",
              _get_func = o => o.strCondition,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCondition != newval) o.strCondition = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strCondition != c.strCondition || o.IsRIRPropChanged(_str_strCondition, c)) 
                  m.Add(_str_strCondition, o.ObjectIdent + _str_strCondition, o.ObjectIdent2 + _str_strCondition, o.ObjectIdent3 + _str_strCondition, "String", 
                    o.strCondition == null ? "" : o.strCondition.ToString(),                  
                  o.IsReadOnly(_str_strCondition), o.IsInvisible(_str_strCondition), o.IsRequired(_str_strCondition)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAccessionCondition, _formname = _str_idfsAccessionCondition, _type = "Int64?",
              _get_func = o => o.idfsAccessionCondition,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsAccessionCondition != newval) 
                  o.AccessionCondition = o.AccessionConditionLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsAccessionCondition != newval) o.idfsAccessionCondition = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsAccessionCondition != c.idfsAccessionCondition || o.IsRIRPropChanged(_str_idfsAccessionCondition, c)) 
                  m.Add(_str_idfsAccessionCondition, o.ObjectIdent + _str_idfsAccessionCondition, o.ObjectIdent2 + _str_idfsAccessionCondition, o.ObjectIdent3 + _str_idfsAccessionCondition, "Int64?", 
                    o.idfsAccessionCondition == null ? "" : o.idfsAccessionCondition.ToString(),                  
                  o.IsReadOnly(_str_idfsAccessionCondition), o.IsInvisible(_str_idfsAccessionCondition), o.IsRequired(_str_idfsAccessionCondition)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfAccesionByPerson, _formname = _str_idfAccesionByPerson, _type = "Int64?",
              _get_func = o => o.idfAccesionByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfAccesionByPerson != newval) o.idfAccesionByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfAccesionByPerson != c.idfAccesionByPerson || o.IsRIRPropChanged(_str_idfAccesionByPerson, c)) 
                  m.Add(_str_idfAccesionByPerson, o.ObjectIdent + _str_idfAccesionByPerson, o.ObjectIdent2 + _str_idfAccesionByPerson, o.ObjectIdent3 + _str_idfAccesionByPerson, "Int64?", 
                    o.idfAccesionByPerson == null ? "" : o.idfAccesionByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfAccesionByPerson), o.IsInvisible(_str_idfAccesionByPerson), o.IsRequired(_str_idfAccesionByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Used, _formname = _str_Used, _type = "Int32",
              _get_func = o => o.Used,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.Used != newval) o.Used = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.Used != c.Used || o.IsRIRPropChanged(_str_Used, c)) 
                  m.Add(_str_Used, o.ObjectIdent + _str_Used, o.ObjectIdent2 + _str_Used, o.ObjectIdent3 + _str_Used, "Int32", 
                    o.Used == null ? "" : o.Used.ToString(),                  
                  o.IsReadOnly(_str_Used), o.IsInvisible(_str_Used), o.IsRequired(_str_Used)); 
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
              _name = _str_idfVector, _formname = _str_idfVector, _type = "Int64?",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfVector != newval) o.idfVector = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) 
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, o.ObjectIdent2 + _str_idfVector, o.ObjectIdent3 + _str_idfVector, "Int64?", 
                    o.idfVector == null ? "" : o.idfVector.ToString(),                  
                  o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector)); 
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
              _name = _str_idfsVectorType, _formname = _str_idfsVectorType, _type = "Int64?",
              _get_func = o => o.idfsVectorType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsVectorType != newval) o.idfsVectorType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_idfsVectorType, c)) 
                  m.Add(_str_idfsVectorType, o.ObjectIdent + _str_idfsVectorType, o.ObjectIdent2 + _str_idfsVectorType, o.ObjectIdent3 + _str_idfsVectorType, "Int64?", 
                    o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(),                  
                  o.IsReadOnly(_str_idfsVectorType), o.IsInvisible(_str_idfsVectorType), o.IsRequired(_str_idfsVectorType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsVectorSubType, _formname = _str_idfsVectorSubType, _type = "Int64?",
              _get_func = o => o.idfsVectorSubType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsVectorSubType != newval) o.idfsVectorSubType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsVectorSubType != c.idfsVectorSubType || o.IsRIRPropChanged(_str_idfsVectorSubType, c)) 
                  m.Add(_str_idfsVectorSubType, o.ObjectIdent + _str_idfsVectorSubType, o.ObjectIdent2 + _str_idfsVectorSubType, o.ObjectIdent3 + _str_idfsVectorSubType, "Int64?", 
                    o.idfsVectorSubType == null ? "" : o.idfsVectorSubType.ToString(),                  
                  o.IsReadOnly(_str_idfsVectorSubType), o.IsInvisible(_str_idfsVectorSubType), o.IsRequired(_str_idfsVectorSubType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intQuantity, _formname = _str_intQuantity, _type = "Int32?",
              _get_func = o => o.intQuantity,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intQuantity != newval) o.intQuantity = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intQuantity != c.intQuantity || o.IsRIRPropChanged(_str_intQuantity, c)) 
                  m.Add(_str_intQuantity, o.ObjectIdent + _str_intQuantity, o.ObjectIdent2 + _str_intQuantity, o.ObjectIdent3 + _str_intQuantity, "Int32?", 
                    o.intQuantity == null ? "" : o.intQuantity.ToString(),                  
                  o.IsReadOnly(_str_intQuantity), o.IsInvisible(_str_intQuantity), o.IsRequired(_str_intQuantity)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datCollectionDateTime, _formname = _str_datCollectionDateTime, _type = "DateTime?",
              _get_func = o => o.datCollectionDateTime,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datCollectionDateTime != newval) o.datCollectionDateTime = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datCollectionDateTime != c.datCollectionDateTime || o.IsRIRPropChanged(_str_datCollectionDateTime, c)) 
                  m.Add(_str_datCollectionDateTime, o.ObjectIdent + _str_datCollectionDateTime, o.ObjectIdent2 + _str_datCollectionDateTime, o.ObjectIdent3 + _str_datCollectionDateTime, "DateTime?", 
                    o.datCollectionDateTime == null ? "" : o.datCollectionDateTime.ToString(),                  
                  o.IsReadOnly(_str_datCollectionDateTime), o.IsInvisible(_str_datCollectionDateTime), o.IsRequired(_str_datCollectionDateTime)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfLocation, _formname = _str_idfLocation, _type = "Int64?",
              _get_func = o => o.idfLocation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfLocation != newval) o.idfLocation = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfLocation != c.idfLocation || o.IsRIRPropChanged(_str_idfLocation, c)) 
                  m.Add(_str_idfLocation, o.ObjectIdent + _str_idfLocation, o.ObjectIdent2 + _str_idfLocation, o.ObjectIdent3 + _str_idfLocation, "Int64?", 
                    o.idfLocation == null ? "" : o.idfLocation.ToString(),                  
                  o.IsReadOnly(_str_idfLocation), o.IsInvisible(_str_idfLocation), o.IsRequired(_str_idfLocation)); 
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
              _name = _str_strVectorID, _formname = _str_strVectorID, _type = "String",
              _get_func = o => o.strVectorID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVectorID != newval) o.strVectorID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strVectorID != c.strVectorID || o.IsRIRPropChanged(_str_strVectorID, c)) 
                  m.Add(_str_strVectorID, o.ObjectIdent + _str_strVectorID, o.ObjectIdent2 + _str_strVectorID, o.ObjectIdent3 + _str_strVectorID, "String", 
                    o.strVectorID == null ? "" : o.strVectorID.ToString(),                  
                  o.IsReadOnly(_str_strVectorID), o.IsInvisible(_str_strVectorID), o.IsRequired(_str_strVectorID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strVectorType, _formname = _str_strVectorType, _type = "String",
              _get_func = o => o.strVectorType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVectorType != newval) o.strVectorType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strVectorType != c.strVectorType || o.IsRIRPropChanged(_str_strVectorType, c)) 
                  m.Add(_str_strVectorType, o.ObjectIdent + _str_strVectorType, o.ObjectIdent2 + _str_strVectorType, o.ObjectIdent3 + _str_strVectorType, "String", 
                    o.strVectorType == null ? "" : o.strVectorType.ToString(),                  
                  o.IsReadOnly(_str_strVectorType), o.IsInvisible(_str_strVectorType), o.IsRequired(_str_strVectorType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strVectorSpecies, _formname = _str_strVectorSpecies, _type = "String",
              _get_func = o => o.strVectorSpecies,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVectorSpecies != newval) o.strVectorSpecies = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strVectorSpecies != c.strVectorSpecies || o.IsRIRPropChanged(_str_strVectorSpecies, c)) 
                  m.Add(_str_strVectorSpecies, o.ObjectIdent + _str_strVectorSpecies, o.ObjectIdent2 + _str_strVectorSpecies, o.ObjectIdent3 + _str_strVectorSpecies, "String", 
                    o.strVectorSpecies == null ? "" : o.strVectorSpecies.ToString(),                  
                  o.IsReadOnly(_str_strVectorSpecies), o.IsInvisible(_str_strVectorSpecies), o.IsRequired(_str_strVectorSpecies)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSampleStatus, _formname = _str_idfsSampleStatus, _type = "Int64?",
              _get_func = o => o.idfsSampleStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSampleStatus != newval) o.idfsSampleStatus = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSampleStatus != c.idfsSampleStatus || o.IsRIRPropChanged(_str_idfsSampleStatus, c)) 
                  m.Add(_str_idfsSampleStatus, o.ObjectIdent + _str_idfsSampleStatus, o.ObjectIdent2 + _str_idfsSampleStatus, o.ObjectIdent3 + _str_idfsSampleStatus, "Int64?", 
                    o.idfsSampleStatus == null ? "" : o.idfsSampleStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsSampleStatus), o.IsInvisible(_str_idfsSampleStatus), o.IsRequired(_str_idfsSampleStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSpecies, _formname = _str_idfSpecies, _type = "Int64?",
              _get_func = o => o.idfSpecies,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfSpecies != newval) o.idfSpecies = newval; },
              _compare_func = (o, c, m, g) => {
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
              _compare_func = (o, c, m, g) => {
                if (o.idfAnimal != c.idfAnimal || o.IsRIRPropChanged(_str_idfAnimal, c)) 
                  m.Add(_str_idfAnimal, o.ObjectIdent + _str_idfAnimal, o.ObjectIdent2 + _str_idfAnimal, o.ObjectIdent3 + _str_idfAnimal, "Int64?", 
                    o.idfAnimal == null ? "" : o.idfAnimal.ToString(),                  
                  o.IsReadOnly(_str_idfAnimal), o.IsInvisible(_str_idfAnimal), o.IsRequired(_str_idfAnimal)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_uidOfflineCaseID, _formname = _str_uidOfflineCaseID, _type = "Guid?",
              _get_func = o => o.uidOfflineCaseID,
              _set_func = (o, val) => { var newval = o.uidOfflineCaseID; if (o.uidOfflineCaseID != newval) o.uidOfflineCaseID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.uidOfflineCaseID != c.uidOfflineCaseID || o.IsRIRPropChanged(_str_uidOfflineCaseID, c)) 
                  m.Add(_str_uidOfflineCaseID, o.ObjectIdent + _str_uidOfflineCaseID, o.ObjectIdent2 + _str_uidOfflineCaseID, o.ObjectIdent3 + _str_uidOfflineCaseID, "Guid?", 
                    o.uidOfflineCaseID == null ? "" : o.uidOfflineCaseID.ToString(),                  
                  o.IsReadOnly(_str_uidOfflineCaseID), o.IsInvisible(_str_uidOfflineCaseID), o.IsRequired(_str_uidOfflineCaseID)); 
                  }
              }, 
        
            new field_info {
              _name = _str_FilterByDiagnosis, _formname = _str_FilterByDiagnosis, _type = "bool",
              _get_func = o => o.FilterByDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.FilterByDiagnosis != newval) o.FilterByDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.FilterByDiagnosis != c.FilterByDiagnosis || o.IsRIRPropChanged(_str_FilterByDiagnosis, c)) {
                  m.Add(_str_FilterByDiagnosis, o.ObjectIdent + _str_FilterByDiagnosis, o.ObjectIdent2 + _str_FilterByDiagnosis, o.ObjectIdent3 + _str_FilterByDiagnosis,  "bool", 
                    o.FilterByDiagnosis == null ? "" : o.FilterByDiagnosis.ToString(),                  
                    o.IsReadOnly(_str_FilterByDiagnosis), o.IsInvisible(_str_FilterByDiagnosis), o.IsRequired(_str_FilterByDiagnosis));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsFinalDiagnosisFromCase, _formname = _str_idfsFinalDiagnosisFromCase, _type = "long?",
              _get_func = o => o.idfsFinalDiagnosisFromCase,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.idfsFinalDiagnosisFromCase != c.idfsFinalDiagnosisFromCase || o.IsRIRPropChanged(_str_idfsFinalDiagnosisFromCase, c)) {
                  m.Add(_str_idfsFinalDiagnosisFromCase, o.ObjectIdent + _str_idfsFinalDiagnosisFromCase, o.ObjectIdent2 + _str_idfsFinalDiagnosisFromCase, o.ObjectIdent3 + _str_idfsFinalDiagnosisFromCase, "long?", o.idfsFinalDiagnosisFromCase == null ? "" : o.idfsFinalDiagnosisFromCase.ToString(), o.IsReadOnly(_str_idfsFinalDiagnosisFromCase), o.IsInvisible(_str_idfsFinalDiagnosisFromCase), o.IsRequired(_str_idfsFinalDiagnosisFromCase));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_idfsTentativeDiagnosis2FromCase, _formname = _str_idfsTentativeDiagnosis2FromCase, _type = "long?",
              _get_func = o => o.idfsTentativeDiagnosis2FromCase,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.idfsTentativeDiagnosis2FromCase != c.idfsTentativeDiagnosis2FromCase || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis2FromCase, c)) {
                  m.Add(_str_idfsTentativeDiagnosis2FromCase, o.ObjectIdent + _str_idfsTentativeDiagnosis2FromCase, o.ObjectIdent2 + _str_idfsTentativeDiagnosis2FromCase, o.ObjectIdent3 + _str_idfsTentativeDiagnosis2FromCase, "long?", o.idfsTentativeDiagnosis2FromCase == null ? "" : o.idfsTentativeDiagnosis2FromCase.ToString(), o.IsReadOnly(_str_idfsTentativeDiagnosis2FromCase), o.IsInvisible(_str_idfsTentativeDiagnosis2FromCase), o.IsRequired(_str_idfsTentativeDiagnosis2FromCase));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_idfsTentativeDiagnosis1FromCase, _formname = _str_idfsTentativeDiagnosis1FromCase, _type = "long?",
              _get_func = o => o.idfsTentativeDiagnosis1FromCase,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.idfsTentativeDiagnosis1FromCase != c.idfsTentativeDiagnosis1FromCase || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis1FromCase, c)) {
                  m.Add(_str_idfsTentativeDiagnosis1FromCase, o.ObjectIdent + _str_idfsTentativeDiagnosis1FromCase, o.ObjectIdent2 + _str_idfsTentativeDiagnosis1FromCase, o.ObjectIdent3 + _str_idfsTentativeDiagnosis1FromCase, "long?", o.idfsTentativeDiagnosis1FromCase == null ? "" : o.idfsTentativeDiagnosis1FromCase.ToString(), o.IsReadOnly(_str_idfsTentativeDiagnosis1FromCase), o.IsInvisible(_str_idfsTentativeDiagnosis1FromCase), o.IsRequired(_str_idfsTentativeDiagnosis1FromCase));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_idfsTentativeDiagnosisFromCase, _formname = _str_idfsTentativeDiagnosisFromCase, _type = "long?",
              _get_func = o => o.idfsTentativeDiagnosisFromCase,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.idfsTentativeDiagnosisFromCase != c.idfsTentativeDiagnosisFromCase || o.IsRIRPropChanged(_str_idfsTentativeDiagnosisFromCase, c)) {
                  m.Add(_str_idfsTentativeDiagnosisFromCase, o.ObjectIdent + _str_idfsTentativeDiagnosisFromCase, o.ObjectIdent2 + _str_idfsTentativeDiagnosisFromCase, o.ObjectIdent3 + _str_idfsTentativeDiagnosisFromCase, "long?", o.idfsTentativeDiagnosisFromCase == null ? "" : o.idfsTentativeDiagnosisFromCase.ToString(), o.IsReadOnly(_str_idfsTentativeDiagnosisFromCase), o.IsInvisible(_str_idfsTentativeDiagnosisFromCase), o.IsRequired(_str_idfsTentativeDiagnosisFromCase));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_AnimalListFromCase, _formname = _str_AnimalListFromCase, _type = "EditableList<AnimalListItem>",
              _get_func = o => o.AnimalListFromCase,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_VetFarmTreeFromCase, _formname = _str_VetFarmTreeFromCase, _type = "List<VetFarmTree>",
              _get_func = o => o.VetFarmTreeFromCase,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_CaseSamples, _formname = _str_CaseSamples, _type = "List<VetCaseSample>",
              _get_func = o => o.CaseSamples,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_CaseTests, _formname = _str_CaseTests, _type = "EditableList<CaseTest>",
              _get_func = o => o.CaseTests,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_PensideTests, _formname = _str_PensideTests, _type = "EditableList<PensideTest>",
              _get_func = o => o.PensideTests,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_strAccessionCondition, _formname = _str_strAccessionCondition, _type = "string",
              _get_func = o => o.strAccessionCondition,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strAccessionCondition != c.strAccessionCondition || o.IsRIRPropChanged(_str_strAccessionCondition, c)) {
                  m.Add(_str_strAccessionCondition, o.ObjectIdent + _str_strAccessionCondition, o.ObjectIdent2 + _str_strAccessionCondition, o.ObjectIdent3 + _str_strAccessionCondition, "string", o.strAccessionCondition == null ? "" : o.strAccessionCondition.ToString(), o.IsReadOnly(_str_strAccessionCondition), o.IsInvisible(_str_strAccessionCondition), o.IsRequired(_str_strAccessionCondition));
                  }
                
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
              _name = _str_AnimalID, _formname = _str_AnimalID, _type = "string",
              _get_func = o => o.AnimalID,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.AnimalID != c.AnimalID || o.IsRIRPropChanged(_str_AnimalID, c)) {
                  m.Add(_str_AnimalID, o.ObjectIdent + _str_AnimalID, o.ObjectIdent2 + _str_AnimalID, o.ObjectIdent3 + _str_AnimalID, "string", o.AnimalID == null ? "" : o.AnimalID.ToString(), o.IsReadOnly(_str_AnimalID), o.IsInvisible(_str_AnimalID), o.IsRequired(_str_AnimalID));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Species, _formname = _str_Species, _type = "string",
              _get_func = o => o.Species,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.Species != c.Species || o.IsRIRPropChanged(_str_Species, c)) {
                  m.Add(_str_Species, o.ObjectIdent + _str_Species, o.ObjectIdent2 + _str_Species, o.ObjectIdent3 + _str_Species, "string", o.Species == null ? "" : o.Species.ToString(), o.IsReadOnly(_str_Species), o.IsInvisible(_str_Species), o.IsRequired(_str_Species));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strBirdStatus, _formname = _str_strBirdStatus, _type = "string",
              _get_func = o => o.strBirdStatus,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strBirdStatus != c.strBirdStatus || o.IsRIRPropChanged(_str_strBirdStatus, c)) {
                  m.Add(_str_strBirdStatus, o.ObjectIdent + _str_strBirdStatus, o.ObjectIdent2 + _str_strBirdStatus, o.ObjectIdent3 + _str_strBirdStatus, "string", o.strBirdStatus == null ? "" : o.strBirdStatus.ToString(), o.IsReadOnly(_str_strBirdStatus), o.IsInvisible(_str_strBirdStatus), o.IsRequired(_str_strBirdStatus));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_SampleTypeForDiagnosis, _formname = _str_SampleTypeForDiagnosis, _type = "Lookup",
              _get_func = o => { if (o.SampleTypeForDiagnosis == null) return null; return o.SampleTypeForDiagnosis.idfsReference; },
              _set_func = (o, val) => { o.SampleTypeForDiagnosis = o.SampleTypeForDiagnosisLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_SampleTypeForDiagnosis, c);
                if (o.idfsSampleType != c.idfsSampleType || o.IsRIRPropChanged(_str_SampleTypeForDiagnosis, c) || bChangeLookupContent) {
                  m.Add(_str_SampleTypeForDiagnosis, o.ObjectIdent + _str_SampleTypeForDiagnosis, o.ObjectIdent2 + _str_SampleTypeForDiagnosis, o.ObjectIdent3 + _str_SampleTypeForDiagnosis, "Lookup", o.idfsSampleType == null ? "" : o.idfsSampleType.ToString(), o.IsReadOnly(_str_SampleTypeForDiagnosis), o.IsInvisible(_str_SampleTypeForDiagnosis), o.IsRequired(_str_SampleTypeForDiagnosis),
                  bChangeLookupContent ? o.SampleTypeForDiagnosisLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_SampleTypeForDiagnosis + "Lookup", _formname = _str_SampleTypeForDiagnosis + "Lookup", _type = "LookupContent",
              _get_func = o => o.SampleTypeForDiagnosisLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_AccessionCondition, _formname = _str_AccessionCondition, _type = "Lookup",
              _get_func = o => { if (o.AccessionCondition == null) return null; return o.AccessionCondition.idfsBaseReference; },
              _set_func = (o, val) => { o.AccessionCondition = o.AccessionConditionLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_AccessionCondition, c);
                if (o.idfsAccessionCondition != c.idfsAccessionCondition || o.IsRIRPropChanged(_str_AccessionCondition, c) || bChangeLookupContent) {
                  m.Add(_str_AccessionCondition, o.ObjectIdent + _str_AccessionCondition, o.ObjectIdent2 + _str_AccessionCondition, o.ObjectIdent3 + _str_AccessionCondition, "Lookup", o.idfsAccessionCondition == null ? "" : o.idfsAccessionCondition.ToString(), o.IsReadOnly(_str_AccessionCondition), o.IsInvisible(_str_AccessionCondition), o.IsRequired(_str_AccessionCondition),
                  bChangeLookupContent ? o.AccessionConditionLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_AccessionCondition + "Lookup", _formname = _str_AccessionCondition + "Lookup", _type = "LookupContent",
              _get_func = o => o.AccessionConditionLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_BirdStatus, _formname = _str_BirdStatus, _type = "Lookup",
              _get_func = o => { if (o.BirdStatus == null) return null; return o.BirdStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.BirdStatus = o.BirdStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_BirdStatus, c);
                if (o.idfsBirdStatus != c.idfsBirdStatus || o.IsRIRPropChanged(_str_BirdStatus, c) || bChangeLookupContent) {
                  m.Add(_str_BirdStatus, o.ObjectIdent + _str_BirdStatus, o.ObjectIdent2 + _str_BirdStatus, o.ObjectIdent3 + _str_BirdStatus, "Lookup", o.idfsBirdStatus == null ? "" : o.idfsBirdStatus.ToString(), o.IsReadOnly(_str_BirdStatus), o.IsInvisible(_str_BirdStatus), o.IsRequired(_str_BirdStatus),
                  bChangeLookupContent ? o.BirdStatusLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_BirdStatus + "Lookup", _formname = _str_BirdStatus + "Lookup", _type = "LookupContent",
              _get_func = o => o.BirdStatusLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Animal, _formname = _str_Animal, _type = "Lookup",
              _get_func = o => { if (o.Animal == null) return null; return o.Animal.idfAnimal; },
              _set_func = (o, val) => { o.Animal = o.AnimalLookup.Where(c => c.idfAnimal.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Animal, c);
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_Animal, c) || bChangeLookupContent) {
                  m.Add(_str_Animal, o.ObjectIdent + _str_Animal, o.ObjectIdent2 + _str_Animal, o.ObjectIdent3 + _str_Animal, "Lookup", o.idfParty == null ? "" : o.idfParty.ToString(), o.IsReadOnly(_str_Animal), o.IsInvisible(_str_Animal), o.IsRequired(_str_Animal),
                  bChangeLookupContent ? o.AnimalLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Animal + "Lookup", _formname = _str_Animal + "Lookup", _type = "LookupContent",
              _get_func = o => o.AnimalLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_FarmTree, _formname = _str_FarmTree, _type = "Lookup",
              _get_func = o => { if (o.FarmTree == null) return null; return o.FarmTree.idfParty; },
              _set_func = (o, val) => { o.FarmTree = o.FarmTreeLookup.Where(c => c.idfParty.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_FarmTree, c);
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_FarmTree, c) || bChangeLookupContent) {
                  m.Add(_str_FarmTree, o.ObjectIdent + _str_FarmTree, o.ObjectIdent2 + _str_FarmTree, o.ObjectIdent3 + _str_FarmTree, "Lookup", o.idfParty == null ? "" : o.idfParty.ToString(), o.IsReadOnly(_str_FarmTree), o.IsInvisible(_str_FarmTree), o.IsRequired(_str_FarmTree),
                  bChangeLookupContent ? o.FarmTreeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_FarmTree + "Lookup", _formname = _str_FarmTree + "Lookup", _type = "LookupContent",
              _get_func = o => o.FarmTreeLookup,
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
            VetCaseSample obj = (VetCaseSample)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_SampleTypeForDiagnosis)]
        [Relation(typeof(SampleTypeForDiagnosisLookup), eidss.model.Schema.SampleTypeForDiagnosisLookup._str_idfsReference, _str_idfsSampleType)]
        public SampleTypeForDiagnosisLookup SampleTypeForDiagnosis
        {
            get { return _SampleTypeForDiagnosis == null ? null : ((long)_SampleTypeForDiagnosis.Key == 0 ? null : _SampleTypeForDiagnosis); }
            set 
            { 
                var oldVal = _SampleTypeForDiagnosis;
                _SampleTypeForDiagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SampleTypeForDiagnosis != oldVal)
                {
                    if (idfsSampleType != (_SampleTypeForDiagnosis == null
                            ? new Int64()
                            : (Int64)_SampleTypeForDiagnosis.idfsReference))
                        idfsSampleType = _SampleTypeForDiagnosis == null 
                            ? new Int64()
                            : (Int64)_SampleTypeForDiagnosis.idfsReference; 
                    OnPropertyChanged(_str_SampleTypeForDiagnosis); 
                }
            }
        }
        private SampleTypeForDiagnosisLookup _SampleTypeForDiagnosis;

        
        public List<SampleTypeForDiagnosisLookup> SampleTypeForDiagnosisLookup
        {
            get { return _SampleTypeForDiagnosisLookup; }
        }
        private List<SampleTypeForDiagnosisLookup> _SampleTypeForDiagnosisLookup = new List<SampleTypeForDiagnosisLookup>();
            
        [LocalizedDisplayName(_str_AccessionCondition)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAccessionCondition)]
        public BaseReference AccessionCondition
        {
            get { return _AccessionCondition == null ? null : ((long)_AccessionCondition.Key == 0 ? null : _AccessionCondition); }
            set 
            { 
                var oldVal = _AccessionCondition;
                _AccessionCondition = value == null ? null : ((long) value.Key == 0 ? null : value);
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
            
        [LocalizedDisplayName(_str_BirdStatus)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsBirdStatus)]
        public BaseReference BirdStatus
        {
            get { return _BirdStatus == null ? null : ((long)_BirdStatus.Key == 0 ? null : _BirdStatus); }
            set 
            { 
                var oldVal = _BirdStatus;
                _BirdStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_BirdStatus != oldVal)
                {
                    if (idfsBirdStatus != (_BirdStatus == null
                            ? new Int64?()
                            : (Int64?)_BirdStatus.idfsBaseReference))
                        idfsBirdStatus = _BirdStatus == null 
                            ? new Int64?()
                            : (Int64?)_BirdStatus.idfsBaseReference; 
                    OnPropertyChanged(_str_BirdStatus); 
                }
            }
        }
        private BaseReference _BirdStatus;

        
        public BaseReferenceList BirdStatusLookup
        {
            get { return _BirdStatusLookup; }
        }
        private BaseReferenceList _BirdStatusLookup = new BaseReferenceList("rftAnimalCondition");
            
        [LocalizedDisplayName(_str_Animal)]
        [Relation(typeof(AnimalListItem), eidss.model.Schema.AnimalListItem._str_idfAnimal, _str_idfParty)]
        public AnimalListItem Animal
        {
            get { return _Animal == null ? null : ((long)_Animal.Key == 0 ? null : _Animal); }
            set 
            { 
                var oldVal = _Animal;
                _Animal = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Animal != oldVal)
                {
                    if (idfParty != (_Animal == null
                            ? new Int64?()
                            : (Int64?)_Animal.idfAnimal))
                        idfParty = _Animal == null 
                            ? new Int64?()
                            : (Int64?)_Animal.idfAnimal; 
                    OnPropertyChanged(_str_Animal); 
                }
            }
        }
        private AnimalListItem _Animal;

        
        private AnimalListItem _emptyAnimal;
        
        public List<AnimalListItem> AnimalLookup
        {
            get 
            { 
                
                if (_emptyAnimal == null)
                {
                    using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        _emptyAnimal = eidss.model.Schema.AnimalListItem.Accessor.Instance(null).CreateNewT(manager, this.Parent/* ?? this*/);
                        
                        new Action<AnimalListItem>(c => c.idfAnimal = 0)(_emptyAnimal);
                        
                    }
                }
                
                var ret = new List<AnimalListItem>();
                
                ret.Add(_emptyAnimal);
                
              
                if (AnimalListFromCase != null)
                {
                    
                    ret.AddRange(AnimalListFromCase
                        .Where(c => !c.IsMarkedToDelete)
                            
                    );
                }
                return ret;
            }
        }
            
        [LocalizedDisplayName(_str_FarmTree)]
        [Relation(typeof(VetFarmTree), eidss.model.Schema.VetFarmTree._str_idfParty, _str_idfParty)]
        public VetFarmTree FarmTree
        {
            get { return _FarmTree == null ? null : ((long)_FarmTree.Key == 0 ? null : _FarmTree); }
            set 
            { 
                var oldVal = _FarmTree;
                _FarmTree = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_FarmTree != oldVal)
                {
                    if (idfParty != (_FarmTree == null
                            ? new Int64?()
                            : (Int64?)_FarmTree.idfParty))
                        idfParty = _FarmTree == null 
                            ? new Int64?()
                            : (Int64?)_FarmTree.idfParty; 
                    OnPropertyChanged(_str_FarmTree); 
                }
            }
        }
        private VetFarmTree _FarmTree;

        
        private VetFarmTree _emptyFarmTree;
        
        public List<VetFarmTree> FarmTreeLookup
        {
            get 
            { 
                
                if (_emptyFarmTree == null)
                {
                    using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        _emptyFarmTree = eidss.model.Schema.VetFarmTree.Accessor.Instance(null).CreateNewT(manager, this.Parent/* ?? this*/);
                        
                    }
                }
                
                var ret = new List<VetFarmTree>();
                
                ret.Add(_emptyFarmTree);
                
              
                if (VetFarmTreeFromCase != null)
                {
                    
                    ret.AddRange(VetFarmTreeFromCase
                        .Where(c => !c.IsMarkedToDelete)
                            
                    );
                }
                return ret;
            }
        }
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_SampleTypeForDiagnosis:
                    return new BvSelectList(SampleTypeForDiagnosisLookup, eidss.model.Schema.SampleTypeForDiagnosisLookup._str_idfsReference, null, SampleTypeForDiagnosis, _str_idfsSampleType);
            
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
            get { return new Func<VetCaseSample, long?>(c => (c.Parent is VetCase) ? (c.Parent as VetCase).idfsFinalDiagnosis : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsTentativeDiagnosis2FromCase)]
        public long? idfsTentativeDiagnosis2FromCase
        {
            get { return new Func<VetCaseSample, long?>(c => (c.Parent is VetCase) ? (c.Parent as VetCase).idfsTentativeDiagnosis2 : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsTentativeDiagnosis1FromCase)]
        public long? idfsTentativeDiagnosis1FromCase
        {
            get { return new Func<VetCaseSample, long?>(c => (c.Parent is VetCase) ? (c.Parent as VetCase).idfsTentativeDiagnosis1 : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsTentativeDiagnosisFromCase)]
        public long? idfsTentativeDiagnosisFromCase
        {
            get { return new Func<VetCaseSample, long?>(c => (c.Parent is VetCase) ? (c.Parent as VetCase).idfsTentativeDiagnosis : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_AnimalListFromCase)]
        public EditableList<AnimalListItem> AnimalListFromCase
        {
            get { return new Func<VetCaseSample, EditableList<AnimalListItem>>(c => (c.Parent is VetCase) ? (c.Parent as VetCase).AnimalList : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_VetFarmTreeFromCase)]
        public List<VetFarmTree> VetFarmTreeFromCase
        {
            get { return new Func<VetCaseSample, List<VetFarmTree>>(c => (c.Parent is VetCase) ? (c.Parent as VetCase).Farm.FarmTree.Where(a => a.idfsPartyType == (long)PartyTypeEnum.Species).ToList() : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseSamples)]
        public List<VetCaseSample> CaseSamples
        {
            get { return new Func<VetCaseSample, List<VetCaseSample>>(c => (c.Parent is VetCase) ? (c.Parent as VetCase).Samples.Where(i => !i.IsMarkedToDelete).ToList() : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseTests)]
        public EditableList<CaseTest> CaseTests
        {
            get { return new Func<VetCaseSample, EditableList<CaseTest>>(c => (c.Parent is VetCase) ? (c.Parent as VetCase).CaseTests : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_PensideTests)]
        public EditableList<PensideTest> PensideTests
        {
            get { return new Func<VetCaseSample, EditableList<PensideTest>>(c => (c.Parent is VetCase) ? (c.Parent as VetCase).PensideTests : null)(this); }
            
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
          [LocalizedDisplayName("strAnimalCode")]
        public string AnimalID
        {
            get { return new Func<VetCaseSample, string>(c => c.AnimalListFromCase == null || c.AnimalListFromCase.Count == 0 || c.idfParty == null ? "" : c.AnimalListFromCase.SingleOrDefault(a => a.idfAnimal == c.idfParty, a => a.strAnimalCode))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Species)]
        public string Species
        {
            get { return new Func<VetCaseSample, string>(c => c.idfParty == null ? "" :
                              (c.AnimalListFromCase == null || c.AnimalListFromCase.Count(a => a.idfAnimal == c.idfParty) == 0 ? 
                                  (c.VetFarmTreeFromCase == null || c.VetFarmTreeFromCase.Count(a => a.idfParty == c.idfParty) == 0 ? "" : c.VetFarmTreeFromCase.SingleOrDefault(a => a.idfParty == c.idfParty, a => a.strSpeciesName)) 
                              : c.AnimalListFromCase.SingleOrDefault(a => a.idfAnimal == c.idfParty, a => a.strSpecies))
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
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as VetCaseSample;
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
            var ret = base.Clone() as VetCaseSample;
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
        
            var _prev_idfsSampleType_SampleTypeForDiagnosis = idfsSampleType;
            var _prev_idfsAccessionCondition_AccessionCondition = idfsAccessionCondition;
            var _prev_idfsBirdStatus_BirdStatus = idfsBirdStatus;
            base.RejectChanges();
        
            if (_prev_idfsSampleType_SampleTypeForDiagnosis != idfsSampleType)
            {
                _SampleTypeForDiagnosis = _SampleTypeForDiagnosisLookup.FirstOrDefault(c => c.idfsReference == idfsSampleType);
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

        private bool IsRIRPropChanged(string fld, VetCaseSample c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, VetCaseSample c)
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
        

      
        public override string ToString()
        {
            return new Func<VetCaseSample, string>(c => string.IsNullOrEmpty(c.strSampleName) ? "" : c.strSampleName + " / " + c.strFieldBarcode)(this);
        }
        

        public VetCaseSample()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        
        private int? m_HACode;
        public int? _HACode { get { return m_HACode; } set { m_HACode = value; } }
        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
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
                OnPropertyChanged(_str_CaseSamples);
                  
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
                        ValidationEventType.Error
                    )).Validate(obj, c => c.idfsAccessionCondition == null
                    );
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, c => c.CaseTests.Where(i => !i.IsMarkedToDelete && i.idfMaterialVet == c.idfMaterial).Count() == 0
                    );
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, c => c.PensideTests.Where(i => !i.IsMarkedToDelete && i.idfMaterial == c.idfMaterial).Count() == 0
                    );
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, c => {
                                     using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                                     {
                                        return manager.SetSpCommand("spLabSample_CheckAccession", manager.Parameter("@idfMaterial", c.idfMaterial)).ExecuteScalar<long>(ScalarSourceType.DataReader, "idfMaterial") == 0;
                                     }}
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


        internal Dictionary<string, Func<VetCaseSample, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VetCaseSample, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VetCaseSample, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VetCaseSample, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VetCaseSample, bool>> m_isHiddenPersonalData;
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
        protected bool bNeedLookupRemove;
        ~VetCaseSample()
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
                
                if (_emptyAnimal != null)
                {
                    _emptyAnimal.Dispose();
                    _emptyAnimal = null;
                }
                  
                if (_emptyFarmTree != null)
                {
                    _emptyFarmTree.Dispose();
                    _emptyFarmTree = null;
                }
                  
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("SampleTypeForDiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftAccessionCondition", this);
                
                LookupManager.RemoveObject("rftAnimalCondition", this);
                
                LookupManager.RemoveObject("AnimalListItem", this);
                
                LookupManager.RemoveObject("VetFarmTree", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "SampleTypeForDiagnosisLookup")
                _getAccessor().LoadLookup_SampleTypeForDiagnosis(manager, this);
            
            if (lookup_object == "rftAccessionCondition")
                _getAccessor().LoadLookup_AccessionCondition(manager, this);
            
            if (lookup_object == "rftAnimalCondition")
                _getAccessor().LoadLookup_BirdStatus(manager, this);
            
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
        public class VetCaseSampleGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfMaterial { get; set; }
        
            public string strSampleName { get; set; }
        
            public string strFieldBarcode { get; set; }
        
            public string AnimalID { get; set; }
        
            public string Species { get; set; }
        
            public string strBirdStatus { get; set; }
        
            public DateTimeWrap datFieldCollectionDate { get; set; }
        
            public string strSendToOffice { get; set; }
        
            public DateTimeWrap datAccession { get; set; }
        
            public string strAccessionCondition { get; set; }
        
            public string strCondition { get; set; }
        
            public string strFieldCollectedByOffice { get; set; }
        
            public string strFieldCollectedByPerson { get; set; }
        
        }
        public partial class VetCaseSampleGridModelList : List<VetCaseSampleGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public VetCaseSampleGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VetCaseSample>, errMes);
            }
            public VetCaseSampleGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VetCaseSample>, errMes);
            }
            public VetCaseSampleGridModelList(long key, IEnumerable<VetCaseSample> items)
            {
                LoadGridModelList(key, items, null);
            }
            public VetCaseSampleGridModelList(long key)
            {
                LoadGridModelList(key, new List<VetCaseSample>(), null);
            }
            partial void filter(List<VetCaseSample> items);
            private void LoadGridModelList(long key, IEnumerable<VetCaseSample> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strSampleName,_str_strFieldBarcode,_str_AnimalID,_str_Species,_str_strBirdStatus,_str_datFieldCollectionDate,_str_strSendToOffice,_str_datAccession,_str_strAccessionCondition,_str_strCondition,_str_strFieldCollectedByOffice,_str_strFieldCollectedByPerson};
                    
                Hiddens = new List<string> {_str_idfMaterial};
                Keys = new List<string> {_str_idfMaterial};
                Labels = new Dictionary<string, string> {{_str_strSampleName, "idfsSampleType"},{_str_strFieldBarcode, "strFieldBarcodeField"},{_str_AnimalID, "strAnimalCode"},{_str_Species, _str_Species},{_str_strBirdStatus, _str_strBirdStatus},{_str_datFieldCollectionDate, _str_datFieldCollectionDate},{_str_strSendToOffice, "strSendToOrganization"},{_str_datAccession, _str_datAccession},{_str_strAccessionCondition, "idfsAccessionCondition"},{_str_strCondition, "strComment"},{_str_strFieldCollectedByOffice, "CollectedbyInstitution"},{_str_strFieldCollectedByPerson, "CollectedbyOfficer"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                VetCaseSample.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<VetCaseSample>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VetCaseSampleGridModel()
                {
                    ItemKey=c.idfMaterial,strSampleName=c.strSampleName,strFieldBarcode=c.strFieldBarcode,AnimalID=c.AnimalID,Species=c.Species,strBirdStatus=c.strBirdStatus,datFieldCollectionDate=c.datFieldCollectionDate,strSendToOffice=c.strSendToOffice,datAccession=c.datAccession,strAccessionCondition=c.strAccessionCondition,strCondition=c.strCondition,strFieldCollectedByOffice=c.strFieldCollectedByOffice,strFieldCollectedByPerson=c.strFieldCollectedByPerson
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
            , IObjectCreator<VetCaseSample>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfMaterial"; } }
            #endregion
        
            public delegate void on_action(VetCaseSample obj);
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
            private SampleTypeForDiagnosisLookup.Accessor SampleTypeForDiagnosisAccessor { get { return eidss.model.Schema.SampleTypeForDiagnosisLookup.Accessor.Instance(m_CS); } }
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

            

            public List<VetCaseSample> _SelectList(DbManagerProxy manager
                , Int64? idfCase
                , int? HACode
                
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfCase
                    , HACode
                    
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<VetCaseSample> _SelectListInternal(DbManagerProxy manager
                , Int64? idfCase
                , int? HACode
                
                , on_action loading, on_action loaded
                )
            {
                VetCaseSample _obj = null;
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
                        _obj = obj;
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
                    throw DbModelException.Create(_obj, e);
                }
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, VetCaseSample obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj.FilterByDiagnosis = new Func<VetCaseSample, bool>(c => EidssUserContext.User.Options.Prefs.FilterByDiagnosis)(obj);
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

    

            private VetCaseSample _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                VetCaseSample obj = null;
                try
                {
                    obj = VetCaseSample.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    obj._HACode = HACode;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfMaterial = (new GetNewIDExtender<VetCaseSample>()).GetScalar(manager, obj, isFake);
                obj.datFieldCollectionDate = new Func<VetCaseSample, DateTime?>(c => c.CaseSamples != null && c.CaseSamples.Any() ? c.CaseSamples[c.CaseSamples.Count - 1].datFieldCollectionDate : DateTime.Today)(obj);
                obj.FilterByDiagnosis = new Func<VetCaseSample, bool>(c => EidssUserContext.User.Options.Prefs.FilterByDiagnosis)(obj);
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

            
            public VetCaseSample CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public VetCaseSample CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
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
                    
                    };
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsSampleType)
                        {
                    
                obj.strSampleName = new Func<VetCaseSample, string>(c => c.SampleTypeForDiagnosis == null ? "" : c.SampleTypeForDiagnosis.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_FilterByDiagnosis)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_SampleTypeForDiagnosis(manager, obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_SampleTypeForDiagnosis(DbManagerProxy manager, VetCaseSample obj)
            {
                
                obj.SampleTypeForDiagnosisLookup.Clear();
                
                obj.SampleTypeForDiagnosisLookup.Add(SampleTypeForDiagnosisAccessor.CreateNewT(manager, null));
                
                obj.SampleTypeForDiagnosisLookup.AddRange(SampleTypeForDiagnosisAccessor.SelectLookupList(manager
                    
                    , null
                    )
                    .Where(c => (c.intHACode & obj._HACode) != 0 || c.idfsReference == obj.idfsSampleType)
                        
                    .Where(c => (!obj.FilterByDiagnosis ? 
                              (
                                  c.idfsDiagnosis == 0
                              )
                              :
                              (
                                  c.idfsDiagnosis == obj.idfsFinalDiagnosisFromCase ||
                                  c.idfsDiagnosis == obj.idfsTentativeDiagnosis2FromCase ||
                                  c.idfsDiagnosis == obj.idfsTentativeDiagnosis1FromCase ||
                                  c.idfsDiagnosis == obj.idfsTentativeDiagnosisFromCase
                              )) || (c.idfsReference == obj.idfsSampleType))
                        
                    .Where(c => c.idfsReference != (long)SampleTypeEnum.Unknown)
                        
                    .Where(c => c.idfsReference != 0)
                        
                    .Distinct(new SampleTypeForDiagnosisLookupComparator())
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsSampleType))
                    
                    .ToList());
                
                if (obj.idfsSampleType != 0)
                {
                    obj.SampleTypeForDiagnosis = obj.SampleTypeForDiagnosisLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsSampleType);
                    
                }
              
                LookupManager.AddObject("SampleTypeForDiagnosisLookup", obj, SampleTypeForDiagnosisAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
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
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsAccessionCondition);
                    
                }
              
                LookupManager.AddObject("rftAccessionCondition", obj, AccessionConditionAccessor.GetType(), "rftAccessionCondition_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
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
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsBirdStatus);
                    
                }
              
                LookupManager.AddObject("rftAnimalCondition", obj, BirdStatusAccessor.GetType(), "rftAnimalCondition_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, VetCaseSample obj)
            {
                
                LoadLookup_SampleTypeForDiagnosis(manager, obj);
                
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
                bool bSuccess = false;
                int iDeadlockAttemptsCount = BaseSettings.DeadlockAttemptsCount;
                for (int iAttemptNumber = 0; iAttemptNumber < iDeadlockAttemptsCount; iAttemptNumber++)
                {
                    bool bTransactionStarted = false;
                    try
                    {
                        VetCaseSample bo = obj as VetCaseSample;
                        
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
                        bSuccess = _PostNonTransaction(manager, obj as VetCaseSample, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VetCaseSample obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
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
                //obj.AcceptChanges();
                
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
        
      
            protected ValidationModelException ChainsValidate(VetCaseSample obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<VetCaseSample>(obj, "datFieldCollectionDate", c => true, 
      obj.datFieldCollectionDate,
      obj.GetType(),
      false, listdatFieldCollectionDate => {
    listdatFieldCollectionDate.Add(
    new ChainsValidatorDateTime<VetCaseSample>(obj, "datFieldSentDate", c => true, 
      obj.datFieldSentDate,
      obj.GetType(),
      false, listdatFieldSentDate => {
    listdatFieldSentDate.Add(
    new ChainsValidatorDateTime<VetCaseSample>(obj, "datAccession", c => true, 
      obj.datAccession,
      obj.GetType(),
      false, listdatAccession => {
    listdatAccession.Add(
    new ChainsValidatorDateTime<VetCaseSample>(obj, "CurrentDate", c => true, 
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
            protected bool ChainsValidate(VetCaseSample obj, bool bRethrowException)
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
                return Validate(manager, obj as VetCaseSample, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VetCaseSample obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "SampleTypeForDiagnosis", "SampleTypeForDiagnosis","strSampleName",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.SampleTypeForDiagnosis);
            
                (new RequiredValidator( "idfParty", "Animal","AnimalID",
                ValidationEventType.Error
              )).Validate(c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Livestock, obj, obj.idfParty);
            
                (new RequiredValidator( "idfParty", "FarmTree","Species",
                ValidationEventType.Error
              )).Validate(c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Avian, obj, obj.idfParty);
            
            (new CustomMandatoryFieldValidator("idfSendToOffice", "idfSendToOffice", "VetCaseSample.idfSendToOffice",
            ValidationEventType.Error
            )).Validate(obj, obj.idfSendToOffice, CustomMandatoryField.VetCaseSample_SentTo,
            c => true);

          
            (new CustomMandatoryFieldValidator("strSendToOffice", "strSendToOffice", "VetCaseSample.idfSendToOffice",
            ValidationEventType.Error
            )).Validate(obj, obj.strSendToOffice, CustomMandatoryField.VetCaseSample_SentTo,
            c => true);

          
                  
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
           
    
            private void _SetupRequired(VetCaseSample obj)
            {
            
                obj
                    .AddRequired("SampleTypeForDiagnosis", c => true);
                    
                obj
                    .AddRequired("Animal", c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Livestock);
                    
                  obj
                    .AddRequired("Animal", c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Livestock);
                
                obj
                    .AddRequired("FarmTree", c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Avian);
                    
                  obj
                    .AddRequired("Animal", c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Avian);
                
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCaseSample_SentTo)  && new Func<VetCaseSample, bool>(c => true)(obj))
              {
                obj
                  .AddRequired("idfSendToOffice", c => true);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCaseSample_SentTo)  && new Func<VetCaseSample, bool>(c => true)(obj))
              {
                obj
                  .AddRequired("strSendToOffice", c => true);
                
                }
            
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
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
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
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VetCaseSample, bool>> RequiredByField = new Dictionary<string, Func<VetCaseSample, bool>>();
            public static Dictionary<string, Func<VetCaseSample, bool>> RequiredByProperty = new Dictionary<string, Func<VetCaseSample, bool>>();
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
                
                Sizes.Add(_str_AnimalName, 2000);
                Sizes.Add(_str_strAnimalCode, 200);
                Sizes.Add(_str_SpeciesName, 2000);
                Sizes.Add(_str_strFarmCode, 200);
                Sizes.Add(_str_strFieldCollectedByPerson, 400);
                Sizes.Add(_str_strFieldCollectedByOffice, 2000);
                Sizes.Add(_str_strSendToOffice, 2000);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strSampleName, 2000);
                Sizes.Add(_str_strCondition, 200);
                Sizes.Add(_str_strNote, 500);
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strVectorID, 50);
                Sizes.Add(_str_strVectorType, 2000);
                Sizes.Add(_str_strVectorSpecies, 2000);
                if (!RequiredByField.ContainsKey("SampleTypeForDiagnosis")) RequiredByField.Add("SampleTypeForDiagnosis", c => true);
                if (!RequiredByProperty.ContainsKey("SampleTypeForDiagnosis")) RequiredByProperty.Add("SampleTypeForDiagnosis", c => true);
                
                if (!RequiredByField.ContainsKey("idfParty")) RequiredByField.Add("idfParty", c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Livestock);
                if (!RequiredByProperty.ContainsKey("Animal")) RequiredByProperty.Add("Animal", c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Livestock);
                
                if (!RequiredByField.ContainsKey("idfParty")) RequiredByField.Add("idfParty", c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Avian);
                if (!RequiredByProperty.ContainsKey("FarmTree")) RequiredByProperty.Add("FarmTree", c => c.idfsAccessionCondition == null && c._HACode == (int)eidss.model.Enums.HACode.Avian);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfMaterial,
                    _str_idfMaterial, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSampleName,
                    "idfsSampleType", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode,
                    "strFieldBarcodeField", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalID,
                    "strAnimalCode", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Species,
                    _str_Species, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBirdStatus,
                    _str_strBirdStatus, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldCollectionDate,
                    _str_datFieldCollectionDate, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSendToOffice,
                    "strSendToOrganization", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datAccession,
                    _str_datAccession, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAccessionCondition,
                    "idfsAccessionCondition", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCondition,
                    "strComment", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldCollectedByOffice,
                    "CollectedbyInstitution", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldCollectedByPerson,
                    "CollectedbyOfficer", null, false, true, true, true, true, null
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
        protected String strSampleNotes_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleNotes).OriginalValue; } }
        protected String strSampleNotes_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleNotes).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<VetCaseSampleTest, object> _get_func;
            internal Action<VetCaseSampleTest, string> _set_func;
            internal Action<VetCaseSampleTest, VetCaseSampleTest, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfVetCase = "idfVetCase";
        internal const string _str_strSampleNotes = "strSampleNotes";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfVetCase, _formname = _str_idfVetCase, _type = "Int64",
              _get_func = o => o.idfVetCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVetCase != newval) o.idfVetCase = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfVetCase != c.idfVetCase || o.IsRIRPropChanged(_str_idfVetCase, c)) 
                  m.Add(_str_idfVetCase, o.ObjectIdent + _str_idfVetCase, o.ObjectIdent2 + _str_idfVetCase, o.ObjectIdent3 + _str_idfVetCase, "Int64", 
                    o.idfVetCase == null ? "" : o.idfVetCase.ToString(),                  
                  o.IsReadOnly(_str_idfVetCase), o.IsInvisible(_str_idfVetCase), o.IsRequired(_str_idfVetCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSampleNotes, _formname = _str_strSampleNotes, _type = "String",
              _get_func = o => o.strSampleNotes,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSampleNotes != newval) o.strSampleNotes = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSampleNotes != c.strSampleNotes || o.IsRIRPropChanged(_str_strSampleNotes, c)) 
                  m.Add(_str_strSampleNotes, o.ObjectIdent + _str_strSampleNotes, o.ObjectIdent2 + _str_strSampleNotes, o.ObjectIdent3 + _str_strSampleNotes, "String", 
                    o.strSampleNotes == null ? "" : o.strSampleNotes.ToString(),                  
                  o.IsReadOnly(_str_strSampleNotes), o.IsInvisible(_str_strSampleNotes), o.IsRequired(_str_strSampleNotes)); 
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
            VetCaseSampleTest obj = (VetCaseSampleTest)o;
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
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as VetCaseSampleTest;
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
            var ret = base.Clone() as VetCaseSampleTest;
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
        public object KeyLookup { get { return idfVetCase; } }
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

        private bool IsRIRPropChanged(string fld, VetCaseSampleTest c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, VetCaseSampleTest c)
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
        

      

        public VetCaseSampleTest()
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


        internal Dictionary<string, Func<VetCaseSampleTest, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VetCaseSampleTest, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VetCaseSampleTest, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VetCaseSampleTest, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VetCaseSampleTest, bool>> m_isHiddenPersonalData;
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
        protected bool bNeedLookupRemove;
        ~VetCaseSampleTest()
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
        : DataAccessor<VetCaseSampleTest>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<VetCaseSampleTest>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfVetCase"; } }
            #endregion
        
            public delegate void on_action(VetCaseSampleTest obj);
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

            

            public List<VetCaseSampleTest> _SelectList(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfCase
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<VetCaseSampleTest> _SelectListInternal(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
                VetCaseSampleTest _obj = null;
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
                        _obj = obj;
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
                    throw DbModelException.Create(_obj, e);
                }
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, VetCaseSampleTest obj, bool bCloning = false)
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

    

            private VetCaseSampleTest _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                VetCaseSampleTest obj = null;
                try
                {
                    obj = VetCaseSampleTest.CreateInstance();
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

            
            public VetCaseSampleTest CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public VetCaseSampleTest CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
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
    

            internal void _LoadLookups(DbManagerProxy manager, VetCaseSampleTest obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(VetCaseSampleTest obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(VetCaseSampleTest obj, bool bRethrowException)
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
                return Validate(manager, obj as VetCaseSampleTest, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VetCaseSampleTest obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
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
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
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
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VetCaseSampleTest, bool>> RequiredByField = new Dictionary<string, Func<VetCaseSampleTest, bool>>();
            public static Dictionary<string, Func<VetCaseSampleTest, bool>> RequiredByProperty = new Dictionary<string, Func<VetCaseSampleTest, bool>>();
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
                
                Sizes.Add(_str_strSampleNotes, 1000);
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
	