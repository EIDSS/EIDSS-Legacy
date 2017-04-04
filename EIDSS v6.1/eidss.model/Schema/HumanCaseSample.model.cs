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
    public abstract partial class HumanCaseSample : 
        EditableObject<HumanCaseSample>
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
                
        [LocalizedDisplayName("strFieldCollectedByPerson")]
        [MapField(_str_idfFieldCollectedByPerson)]
        public abstract Int64? idfFieldCollectedByPerson { get; set; }
        protected Int64? idfFieldCollectedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByPerson).OriginalValue; } }
        protected Int64? idfFieldCollectedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName("CollectedbyOfficer")]
        [MapField(_str_strFieldCollectedByPerson)]
        public abstract String strFieldCollectedByPerson { get; set; }
        protected String strFieldCollectedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByPerson).OriginalValue; } }
        protected String strFieldCollectedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName("strFieldCollectedByOffice")]
        [MapField(_str_idfFieldCollectedByOffice)]
        public abstract Int64? idfFieldCollectedByOffice { get; set; }
        protected Int64? idfFieldCollectedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).OriginalValue; } }
        protected Int64? idfFieldCollectedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName("CollectedbyInstitution")]
        [MapField(_str_strFieldCollectedByOffice)]
        public abstract String strFieldCollectedByOffice { get; set; }
        protected String strFieldCollectedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByOffice).OriginalValue; } }
        protected String strFieldCollectedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldCollectedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName("strSendToOffice")]
        [MapField(_str_idfSendToOffice)]
        public abstract Int64? idfSendToOffice { get; set; }
        protected Int64? idfSendToOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).OriginalValue; } }
        protected Int64? idfSendToOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).PreviousValue; } }
                
        [LocalizedDisplayName("strSendToOrganization")]
        [MapField(_str_strSendToOffice)]
        public abstract String strSendToOffice { get; set; }
        protected String strSendToOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strSendToOffice).OriginalValue; } }
        protected String strSendToOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSendToOffice).PreviousValue; } }
                
        [LocalizedDisplayName("TestName")]
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
                
        [LocalizedDisplayName("strFieldBarcodeLocal")]
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
                
        [LocalizedDisplayName(_str_strCondition)]
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
                
        [LocalizedDisplayName("strComment")]
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
                
        [LocalizedDisplayName("strLabBarcode")]
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
                
        [LocalizedDisplayName(_str_datPerformedDate)]
        [MapField(_str_datPerformedDate)]
        public abstract DateTime? datPerformedDate { get; set; }
        protected DateTime? datPerformedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPerformedDate).OriginalValue; } }
        protected DateTime? datPerformedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPerformedDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32 intOrder { get; set; }
        protected Int32 intOrder_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32 intOrder_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSampleStatus)]
        [MapField(_str_idfsSampleStatus)]
        public abstract Int64? idfsSampleStatus { get; set; }
        protected Int64? idfsSampleStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleStatus).OriginalValue; } }
        protected Int64? idfsSampleStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleStatus).PreviousValue; } }
                
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
            internal Func<HumanCaseSample, object> _get_func;
            internal Action<HumanCaseSample, string> _set_func;
            internal Action<HumanCaseSample, HumanCaseSample, CompareModel, DbManagerProxy> _compare_func;
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
        internal const string _str_idfsTestName = "idfsTestName";
        internal const string _str_idfsTestResult = "idfsTestResult";
        internal const string _str_datPerformedDate = "datPerformedDate";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_idfsSampleStatus = "idfsSampleStatus";
        internal const string _str_uidOfflineCaseID = "uidOfflineCaseID";
        internal const string _str_FilterByDiagnosis = "FilterByDiagnosis";
        internal const string _str_idfsSampleTypeSaved = "idfsSampleTypeSaved";
        internal const string _str_idfsDiagnosisFromCase = "idfsDiagnosisFromCase";
        internal const string _str_CaseTests = "CaseTests";
        internal const string _str_strAccessionCondition = "strAccessionCondition";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_strTestName = "strTestName";
        internal const string _str_strTestResult = "strTestResult";
        internal const string _str_datTestPerformedDate = "datTestPerformedDate";
        internal const string _str_SampleTypeWithUnknown = "SampleTypeWithUnknown";
        internal const string _str_SampleType = "SampleType";
        internal const string _str_AccessionCondition = "AccessionCondition";
        internal const string _str_Testing = "Testing";
        internal const string _str_Tests = "Tests";
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
                  o.SampleTypeWithUnknown = o.SampleTypeWithUnknownLookup.FirstOrDefault(c => c.idfsReference == newval);
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfParty != newval) o.idfParty = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfMainTest != newval) 
                  o.Testing = o.TestingLookup.FirstOrDefault(c => c.idfTesting == newval);
                if (o.idfMainTest != newval) o.idfMainTest = newval; },
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
              _name = _str_idfsTestName, _formname = _str_idfsTestName, _type = "Int64?",
              _get_func = o => o.idfsTestName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTestName != newval) o.idfsTestName = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTestResult != newval) o.idfsTestResult = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsTestResult != c.idfsTestResult || o.IsRIRPropChanged(_str_idfsTestResult, c)) 
                  m.Add(_str_idfsTestResult, o.ObjectIdent + _str_idfsTestResult, o.ObjectIdent2 + _str_idfsTestResult, o.ObjectIdent3 + _str_idfsTestResult, "Int64?", 
                    o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(),                  
                  o.IsReadOnly(_str_idfsTestResult), o.IsInvisible(_str_idfsTestResult), o.IsRequired(_str_idfsTestResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datPerformedDate, _formname = _str_datPerformedDate, _type = "DateTime?",
              _get_func = o => o.datPerformedDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datPerformedDate != newval) o.datPerformedDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datPerformedDate != c.datPerformedDate || o.IsRIRPropChanged(_str_datPerformedDate, c)) 
                  m.Add(_str_datPerformedDate, o.ObjectIdent + _str_datPerformedDate, o.ObjectIdent2 + _str_datPerformedDate, o.ObjectIdent3 + _str_datPerformedDate, "DateTime?", 
                    o.datPerformedDate == null ? "" : o.datPerformedDate.ToString(),                  
                  o.IsReadOnly(_str_datPerformedDate), o.IsInvisible(_str_datPerformedDate), o.IsRequired(_str_datPerformedDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intOrder, _formname = _str_intOrder, _type = "Int32",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intOrder != newval) o.intOrder = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, o.ObjectIdent2 + _str_intOrder, o.ObjectIdent3 + _str_intOrder, "Int32", 
                    o.intOrder == null ? "" : o.intOrder.ToString(),                  
                  o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); 
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
              _name = _str_idfsSampleTypeSaved, _formname = _str_idfsSampleTypeSaved, _type = "long?",
              _get_func = o => o.idfsSampleTypeSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSampleTypeSaved != newval) o.idfsSampleTypeSaved = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsSampleTypeSaved != c.idfsSampleTypeSaved || o.IsRIRPropChanged(_str_idfsSampleTypeSaved, c)) {
                  m.Add(_str_idfsSampleTypeSaved, o.ObjectIdent + _str_idfsSampleTypeSaved, o.ObjectIdent2 + _str_idfsSampleTypeSaved, o.ObjectIdent3 + _str_idfsSampleTypeSaved,  "long?", 
                    o.idfsSampleTypeSaved == null ? "" : o.idfsSampleTypeSaved.ToString(),                  
                    o.IsReadOnly(_str_idfsSampleTypeSaved), o.IsInvisible(_str_idfsSampleTypeSaved), o.IsRequired(_str_idfsSampleTypeSaved));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosisFromCase, _formname = _str_idfsDiagnosisFromCase, _type = "long?",
              _get_func = o => o.idfsDiagnosisFromCase,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.idfsDiagnosisFromCase != c.idfsDiagnosisFromCase || o.IsRIRPropChanged(_str_idfsDiagnosisFromCase, c)) {
                  m.Add(_str_idfsDiagnosisFromCase, o.ObjectIdent + _str_idfsDiagnosisFromCase, o.ObjectIdent2 + _str_idfsDiagnosisFromCase, o.ObjectIdent3 + _str_idfsDiagnosisFromCase, "long?", o.idfsDiagnosisFromCase == null ? "" : o.idfsDiagnosisFromCase.ToString(), o.IsReadOnly(_str_idfsDiagnosisFromCase), o.IsInvisible(_str_idfsDiagnosisFromCase), o.IsRequired(_str_idfsDiagnosisFromCase));
                  }
                
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
              _name = _str_strTestName, _formname = _str_strTestName, _type = "string",
              _get_func = o => o.strTestName,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strTestName != c.strTestName || o.IsRIRPropChanged(_str_strTestName, c)) {
                  m.Add(_str_strTestName, o.ObjectIdent + _str_strTestName, o.ObjectIdent2 + _str_strTestName, o.ObjectIdent3 + _str_strTestName, "string", o.strTestName == null ? "" : o.strTestName.ToString(), o.IsReadOnly(_str_strTestName), o.IsInvisible(_str_strTestName), o.IsRequired(_str_strTestName));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strTestResult, _formname = _str_strTestResult, _type = "string",
              _get_func = o => o.strTestResult,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strTestResult != c.strTestResult || o.IsRIRPropChanged(_str_strTestResult, c)) {
                  m.Add(_str_strTestResult, o.ObjectIdent + _str_strTestResult, o.ObjectIdent2 + _str_strTestResult, o.ObjectIdent3 + _str_strTestResult, "string", o.strTestResult == null ? "" : o.strTestResult.ToString(), o.IsReadOnly(_str_strTestResult), o.IsInvisible(_str_strTestResult), o.IsRequired(_str_strTestResult));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_datTestPerformedDate, _formname = _str_datTestPerformedDate, _type = "DateTime?",
              _get_func = o => o.datTestPerformedDate,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.datTestPerformedDate != c.datTestPerformedDate || o.IsRIRPropChanged(_str_datTestPerformedDate, c)) {
                  m.Add(_str_datTestPerformedDate, o.ObjectIdent + _str_datTestPerformedDate, o.ObjectIdent2 + _str_datTestPerformedDate, o.ObjectIdent3 + _str_datTestPerformedDate, "DateTime?", o.datTestPerformedDate == null ? "" : o.datTestPerformedDate.ToString(), o.IsReadOnly(_str_datTestPerformedDate), o.IsInvisible(_str_datTestPerformedDate), o.IsRequired(_str_datTestPerformedDate));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_SampleTypeWithUnknown, _formname = _str_SampleTypeWithUnknown, _type = "Lookup",
              _get_func = o => { if (o.SampleTypeWithUnknown == null) return null; return o.SampleTypeWithUnknown.idfsReference; },
              _set_func = (o, val) => { o.SampleTypeWithUnknown = o.SampleTypeWithUnknownLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_SampleTypeWithUnknown, c);
                if (o.idfsSampleType != c.idfsSampleType || o.IsRIRPropChanged(_str_SampleTypeWithUnknown, c) || bChangeLookupContent) {
                  m.Add(_str_SampleTypeWithUnknown, o.ObjectIdent + _str_SampleTypeWithUnknown, o.ObjectIdent2 + _str_SampleTypeWithUnknown, o.ObjectIdent3 + _str_SampleTypeWithUnknown, "Lookup", o.idfsSampleType == null ? "" : o.idfsSampleType.ToString(), o.IsReadOnly(_str_SampleTypeWithUnknown), o.IsInvisible(_str_SampleTypeWithUnknown), o.IsRequired(_str_SampleTypeWithUnknown),
                  bChangeLookupContent ? o.SampleTypeWithUnknownLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_SampleTypeWithUnknown + "Lookup", _formname = _str_SampleTypeWithUnknown + "Lookup", _type = "LookupContent",
              _get_func = o => o.SampleTypeWithUnknownLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_SampleType, _formname = _str_SampleType, _type = "Lookup",
              _get_func = o => { if (o.SampleType == null) return null; return o.SampleType.idfsReference; },
              _set_func = (o, val) => { o.SampleType = o.SampleTypeLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_SampleType, c);
                if (o.idfsSampleType != c.idfsSampleType || o.IsRIRPropChanged(_str_SampleType, c) || bChangeLookupContent) {
                  m.Add(_str_SampleType, o.ObjectIdent + _str_SampleType, o.ObjectIdent2 + _str_SampleType, o.ObjectIdent3 + _str_SampleType, "Lookup", o.idfsSampleType == null ? "" : o.idfsSampleType.ToString(), o.IsReadOnly(_str_SampleType), o.IsInvisible(_str_SampleType), o.IsRequired(_str_SampleType),
                  bChangeLookupContent ? o.SampleTypeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_SampleType + "Lookup", _formname = _str_SampleType + "Lookup", _type = "LookupContent",
              _get_func = o => o.SampleTypeLookup,
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
              _name = _str_Testing, _formname = _str_Testing, _type = "Lookup",
              _get_func = o => { if (o.Testing == null) return null; return o.Testing.idfTesting; },
              _set_func = (o, val) => { o.Testing = o.TestingLookup.Where(c => c.idfTesting.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Testing, c);
                if (o.idfMainTest != c.idfMainTest || o.IsRIRPropChanged(_str_Testing, c) || bChangeLookupContent) {
                  m.Add(_str_Testing, o.ObjectIdent + _str_Testing, o.ObjectIdent2 + _str_Testing, o.ObjectIdent3 + _str_Testing, "Lookup", o.idfMainTest == null ? "" : o.idfMainTest.ToString(), o.IsReadOnly(_str_Testing), o.IsInvisible(_str_Testing), o.IsRequired(_str_Testing),
                  bChangeLookupContent ? o.TestingLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Testing + "Lookup", _formname = _str_Testing + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestingLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Tests, _formname = _str_Tests, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Tests.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Tests.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.Tests.Count != c.Tests.Count || o.IsReadOnly(_str_Tests) != c.IsReadOnly(_str_Tests) || o.IsInvisible(_str_Tests) != c.IsInvisible(_str_Tests) || o.IsRequired(_str_Tests) != c._isRequired(o.m_isRequired, _str_Tests)) {
                  m.Add(_str_Tests, o.ObjectIdent + _str_Tests, o.ObjectIdent2 + _str_Tests, o.ObjectIdent3 + _str_Tests, "Child", o.idfMaterial == null ? "" : o.idfMaterial.ToString(), o.IsReadOnly(_str_Tests), o.IsInvisible(_str_Tests), o.IsRequired(_str_Tests)); 
                  }
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
            HumanCaseSample obj = (HumanCaseSample)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Tests)]
        [Relation(typeof(HumanCaseSampleTest), eidss.model.Schema.HumanCaseSampleTest._str_idfMaterial, _str_idfMaterial)]
        public EditableList<HumanCaseSampleTest> Tests
        {
            get 
            {   
                return _Tests; 
            }
            set 
            {
                _Tests = value;
            }
        }
        protected EditableList<HumanCaseSampleTest> _Tests = new EditableList<HumanCaseSampleTest>();
                    
        [LocalizedDisplayName(_str_SampleTypeWithUnknown)]
        [Relation(typeof(SampleTypeForDiagnosisLookup), eidss.model.Schema.SampleTypeForDiagnosisLookup._str_idfsReference, _str_idfsSampleType)]
        public SampleTypeForDiagnosisLookup SampleTypeWithUnknown
        {
            get { return _SampleTypeWithUnknown == null ? null : ((long)_SampleTypeWithUnknown.Key == 0 ? null : _SampleTypeWithUnknown); }
            set 
            { 
                var oldVal = _SampleTypeWithUnknown;
                _SampleTypeWithUnknown = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SampleTypeWithUnknown != oldVal)
                {
                    if (idfsSampleType != (_SampleTypeWithUnknown == null
                            ? new Int64()
                            : (Int64)_SampleTypeWithUnknown.idfsReference))
                        idfsSampleType = _SampleTypeWithUnknown == null 
                            ? new Int64()
                            : (Int64)_SampleTypeWithUnknown.idfsReference; 
                    OnPropertyChanged(_str_SampleTypeWithUnknown); 
                }
            }
        }
        private SampleTypeForDiagnosisLookup _SampleTypeWithUnknown;

        
        public List<SampleTypeForDiagnosisLookup> SampleTypeWithUnknownLookup
        {
            get { return _SampleTypeWithUnknownLookup; }
        }
        private List<SampleTypeForDiagnosisLookup> _SampleTypeWithUnknownLookup = new List<SampleTypeForDiagnosisLookup>();
            
        [LocalizedDisplayName(_str_SampleType)]
        [Relation(typeof(SampleTypeForDiagnosisLookup), eidss.model.Schema.SampleTypeForDiagnosisLookup._str_idfsReference, _str_idfsSampleType)]
        public SampleTypeForDiagnosisLookup SampleType
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
                            : (Int64)_SampleType.idfsReference))
                        idfsSampleType = _SampleType == null 
                            ? new Int64()
                            : (Int64)_SampleType.idfsReference; 
                    OnPropertyChanged(_str_SampleType); 
                }
            }
        }
        private SampleTypeForDiagnosisLookup _SampleType;

        
        public List<SampleTypeForDiagnosisLookup> SampleTypeLookup
        {
            get { return _SampleTypeLookup; }
        }
        private List<SampleTypeForDiagnosisLookup> _SampleTypeLookup = new List<SampleTypeForDiagnosisLookup>();
            
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
            
        [LocalizedDisplayName(_str_Testing)]
        [Relation(typeof(HumanCaseSampleTest), eidss.model.Schema.HumanCaseSampleTest._str_idfTesting, _str_idfMainTest)]
        public HumanCaseSampleTest Testing
        {
            get { return _Testing == null ? null : ((long)_Testing.Key == 0 ? null : _Testing); }
            set 
            { 
                var oldVal = _Testing;
                _Testing = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Testing != oldVal)
                {
                    if (idfMainTest != (_Testing == null
                            ? new Int64?()
                            : (Int64?)_Testing.idfTesting))
                        idfMainTest = _Testing == null 
                            ? new Int64?()
                            : (Int64?)_Testing.idfTesting; 
                    OnPropertyChanged(_str_Testing); 
                }
            }
        }
        private HumanCaseSampleTest _Testing;

        
        private HumanCaseSampleTest _emptyTesting;
        
        public List<HumanCaseSampleTest> TestingLookup
        {
            get 
            { 
                
                if (_emptyTesting == null)
                {
                    using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        _emptyTesting = eidss.model.Schema.HumanCaseSampleTest.Accessor.Instance(null).CreateNewT(manager, this.Parent/* ?? this*/);
                        
                    }
                }
                
                var ret = new List<HumanCaseSampleTest>();
                
                ret.Add(_emptyTesting);
                
              
                if (Tests != null)
                {
                    
                    ret.AddRange(Tests
                        .Where(c => !c.IsMarkedToDelete && ((c.idfRootMaterial ?? c.idfMaterial) == (idfRootMaterial ?? idfMaterial)))
                            
                    );
                }
                return ret;
            }
        }
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_SampleTypeWithUnknown:
                    return new BvSelectList(SampleTypeWithUnknownLookup, eidss.model.Schema.SampleTypeForDiagnosisLookup._str_idfsReference, null, SampleTypeWithUnknown, _str_idfsSampleType);
            
                case _str_SampleType:
                    return new BvSelectList(SampleTypeLookup, eidss.model.Schema.SampleTypeForDiagnosisLookup._str_idfsReference, null, SampleType, _str_idfsSampleType);
            
                case _str_AccessionCondition:
                    return new BvSelectList(AccessionConditionLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AccessionCondition, _str_idfsAccessionCondition);
            
                case _str_Testing:
                    return new BvSelectList(TestingLookup, eidss.model.Schema.HumanCaseSampleTest._str_idfTesting, null, Testing, _str_idfMainTest);
            
                case _str_Tests:
                    return new BvSelectList(Tests, "", "", null, "");
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsDiagnosisFromCase)]
        public long? idfsDiagnosisFromCase
        {
            get { return new Func<HumanCaseSample, long?>(c => (c.Parent is HumanCase) ? (c.Parent as HumanCase).idfsDiagnosis : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseTests)]
        public EditableList<CaseTest> CaseTests
        {
            get { return new Func<HumanCaseSample, EditableList<CaseTest>>(c => (c.Parent is HumanCase) ? (c.Parent as HumanCase).CaseTests : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("idfsAccessionCondition")]
        public string strAccessionCondition
        {
            get { return new Func<HumanCaseSample, string>(c => c.AccessionCondition == null ? "" : c.AccessionCondition.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<HumanCaseSample, string>(c => "HumanCase_" + c.idfCase + "_")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("TestName")]
        public string strTestName
        {
            get { return new Func<HumanCaseSample, string>(c => c.Testing == null ? "" : c.Testing.TestName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("TestResult")]
        public string strTestResult
        {
            get { return new Func<HumanCaseSample, string>(c => c.Testing == null ? "" : c.Testing.TestResult)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("datConcludedDate")]
        public DateTime? datTestPerformedDate
        {
            get { return new Func<HumanCaseSample, DateTime?>(c => c.Testing == null ? default(DateTime?) : c.Testing.datPerformedDate)(this); }
            
        }
        
          [LocalizedDisplayName(_str_FilterByDiagnosis)]
        public bool FilterByDiagnosis
        {
            get { return m_FilterByDiagnosis; }
            set { if (m_FilterByDiagnosis != value) { m_FilterByDiagnosis = value; OnPropertyChanged(_str_FilterByDiagnosis); } }
        }
        private bool m_FilterByDiagnosis;
        
          [LocalizedDisplayName(_str_idfsSampleTypeSaved)]
        public long? idfsSampleTypeSaved
        {
            get { return m_idfsSampleTypeSaved; }
            set { if (m_idfsSampleTypeSaved != value) { m_idfsSampleTypeSaved = value; OnPropertyChanged(_str_idfsSampleTypeSaved); } }
        }
        private long? m_idfsSampleTypeSaved;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "HumanCaseSample";

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
        Tests.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as HumanCaseSample;
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
            var ret = base.Clone() as HumanCaseSample;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Tests != null && _Tests.Count > 0)
            {
              ret.Tests.Clear();
              _Tests.ForEach(c => ret.Tests.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public HumanCaseSample CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as HumanCaseSample;
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
        
                    || Tests.IsDirty
                    || Tests.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsSampleType_SampleTypeWithUnknown = idfsSampleType;
            var _prev_idfsSampleType_SampleType = idfsSampleType;
            var _prev_idfsAccessionCondition_AccessionCondition = idfsAccessionCondition;
            base.RejectChanges();
        
            if (_prev_idfsSampleType_SampleTypeWithUnknown != idfsSampleType)
            {
                _SampleTypeWithUnknown = _SampleTypeWithUnknownLookup.FirstOrDefault(c => c.idfsReference == idfsSampleType);
            }
            if (_prev_idfsSampleType_SampleType != idfsSampleType)
            {
                _SampleType = _SampleTypeLookup.FirstOrDefault(c => c.idfsReference == idfsSampleType);
            }
            if (_prev_idfsAccessionCondition_AccessionCondition != idfsAccessionCondition)
            {
                _AccessionCondition = _AccessionConditionLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAccessionCondition);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        Tests.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        Tests.DeepAcceptChanges();
                
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
        Tests.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, HumanCaseSample c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, HumanCaseSample c)
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
            return new Func<HumanCaseSample, string>(c => string.IsNullOrEmpty(c.strSampleName) ? "" : c.strSampleName + " / " + c.strFieldBarcode)(this);
        }
        

        public HumanCaseSample()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(HumanCaseSample_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(HumanCaseSample_PropertyChanged);
        }
        private void HumanCaseSample_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as HumanCaseSample).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_idfsDiagnosisFromCase);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_CaseTests);
                  
            if (e.PropertyName == _str_idfsAccessionCondition)
                OnPropertyChanged(_str_strAccessionCondition);
                  
            if (e.PropertyName == _str_idfCase)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
            if (e.PropertyName == _str_idfMainTest)
                OnPropertyChanged(_str_strTestName);
                  
            if (e.PropertyName == _str_idfMainTest)
                OnPropertyChanged(_str_strTestResult);
                  
            if (e.PropertyName == _str_idfMainTest)
                OnPropertyChanged(_str_datTestPerformedDate);
                  
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
            HumanCaseSample obj = this;
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
                    )).Validate(obj, c => c.CaseTests.Where(i => !i.IsMarkedToDelete && i.idfMaterialHuman == c.idfMaterial).Count() == 0
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
            HumanCaseSample obj = this;
            
        }
        private void _DeletedExtenders()
        {
            HumanCaseSample obj = this;
            
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

    
        private static string[] readonly_names1 = "Testing,idfMainTest".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "SampleType,SampleTypeWithUnknown,idfsSampleType,strFieldBarcode,datFieldCollectionDate,datFieldSentDate,idfFieldCollectedByOffice,idfFieldCollectedByPerson,idfSendToOffice,FilterByDiagnosis".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "strFieldCollectedByOffice,strFieldCollectedByPerson,strSendToOffice".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCaseSample, bool>(c => false)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCaseSample, bool>(c => c.idfsAccessionCondition != null)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCaseSample, bool>(c => true)(this);
            
            return ReadOnly || new Func<HumanCaseSample, bool>(c => true)(this);
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
                foreach(var o in _Tests)
                    o._isValid &= value;
                
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _Tests)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<HumanCaseSample, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<HumanCaseSample, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<HumanCaseSample, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<HumanCaseSample, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<HumanCaseSample, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<HumanCaseSample, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<HumanCaseSample, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~HumanCaseSample()
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
                
                if (_emptyTesting != null)
                {
                    _emptyTesting.Dispose();
                    _emptyTesting = null;
                }
                  
                this.ClearModelObjEventInvocations();
                
                if (!bIsClone)
                {
                    Tests.ForEach(c => c.Dispose());
                }
                Tests.ClearModelListEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("SampleTypeForDiagnosisLookup", this);
                
                LookupManager.RemoveObject("SampleTypeForDiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftAccessionCondition", this);
                
                LookupManager.RemoveObject("HumanCaseSampleTest", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "SampleTypeForDiagnosisLookup")
                _getAccessor().LoadLookup_SampleTypeWithUnknown(manager, this);
            
            if (lookup_object == "SampleTypeForDiagnosisLookup")
                _getAccessor().LoadLookup_SampleType(manager, this);
            
            if (lookup_object == "rftAccessionCondition")
                _getAccessor().LoadLookup_AccessionCondition(manager, this);
            
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
        
            if (_Tests != null) _Tests.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
        }
    
        #region Class for web grid
        public class HumanCaseSampleGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfMaterial { get; set; }
        
            public string strSampleName { get; set; }
        
            public string strFieldBarcode { get; set; }
        
            public DateTimeWrap datFieldCollectionDate { get; set; }
        
            public DateTimeWrap datFieldSentDate { get; set; }
        
            public DateTimeWrap datAccession { get; set; }
        
            public string strAccessionCondition { get; set; }
        
            public string strNote { get; set; }
        
            public string strTestName { get; set; }
        
            public string strTestResult { get; set; }
        
            public DateTimeWrap datTestPerformedDate { get; set; }
        
            public string strFieldCollectedByOffice { get; set; }
        
            public string strFieldCollectedByPerson { get; set; }
        
            public string strSendToOffice { get; set; }
        
        }
        public partial class HumanCaseSampleGridModelList : List<HumanCaseSampleGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public HumanCaseSampleGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<HumanCaseSample>, errMes);
            }
            public HumanCaseSampleGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<HumanCaseSample>, errMes);
            }
            public HumanCaseSampleGridModelList(long key, IEnumerable<HumanCaseSample> items)
            {
                LoadGridModelList(key, items, null);
            }
            public HumanCaseSampleGridModelList(long key)
            {
                LoadGridModelList(key, new List<HumanCaseSample>(), null);
            }
            partial void filter(List<HumanCaseSample> items);
            private void LoadGridModelList(long key, IEnumerable<HumanCaseSample> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strSampleName,_str_strFieldBarcode,_str_datFieldCollectionDate,_str_datFieldSentDate,_str_datAccession,_str_strAccessionCondition,_str_strNote,_str_strTestName,_str_strTestResult,_str_datTestPerformedDate,_str_strFieldCollectedByOffice,_str_strFieldCollectedByPerson,_str_strSendToOffice};
                    
                Hiddens = new List<string> {_str_idfMaterial};
                Keys = new List<string> {_str_idfMaterial};
                Labels = new Dictionary<string, string> {{_str_strSampleName, "idfsSampleType"},{_str_strFieldBarcode, "strFieldBarcodeLocal"},{_str_datFieldCollectionDate, _str_datFieldCollectionDate},{_str_datFieldSentDate, _str_datFieldSentDate},{_str_datAccession, _str_datAccession},{_str_strAccessionCondition, "idfsAccessionCondition"},{_str_strNote, "strComment"},{_str_strTestName, "TestName"},{_str_strTestResult, "TestResult"},{_str_datTestPerformedDate, "datConcludedDate"},{_str_strFieldCollectedByOffice, "CollectedbyInstitution"},{_str_strFieldCollectedByPerson, "CollectedbyOfficer"},{_str_strSendToOffice, "strSendToOrganization"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                HumanCaseSample.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<HumanCaseSample>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new HumanCaseSampleGridModel()
                {
                    ItemKey=c.idfMaterial,strSampleName=c.strSampleName,strFieldBarcode=c.strFieldBarcode,datFieldCollectionDate=c.datFieldCollectionDate,datFieldSentDate=c.datFieldSentDate,datAccession=c.datAccession,strAccessionCondition=c.strAccessionCondition,strNote=c.strNote,strTestName=c.strTestName,strTestResult=c.strTestResult,datTestPerformedDate=c.datTestPerformedDate,strFieldCollectedByOffice=c.strFieldCollectedByOffice,strFieldCollectedByPerson=c.strFieldCollectedByPerson,strSendToOffice=c.strSendToOffice
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
        : DataAccessor<HumanCaseSample>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<HumanCaseSample>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfMaterial"; } }
            #endregion
        
            public delegate void on_action(HumanCaseSample obj);
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
            private HumanCaseSampleTest.Accessor TestsAccessor { get { return eidss.model.Schema.HumanCaseSampleTest.Accessor.Instance(m_CS); } }
            private SampleTypeForDiagnosisLookup.Accessor SampleTypeWithUnknownAccessor { get { return eidss.model.Schema.SampleTypeForDiagnosisLookup.Accessor.Instance(m_CS); } }
            private SampleTypeForDiagnosisLookup.Accessor SampleTypeAccessor { get { return eidss.model.Schema.SampleTypeForDiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AccessionConditionAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private HumanCaseSampleTest.Accessor TestingAccessor { get { return eidss.model.Schema.HumanCaseSampleTest.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<HumanCaseSample> SelectList(DbManagerProxy manager
                , Int64? idfCase
                )
            {
                return _SelectList(manager
                    , idfCase
                    , delegate(HumanCaseSample obj)
                        {
                        }
                    , delegate(HumanCaseSample obj)
                        {
                        }
                    );
            }

            

            public List<HumanCaseSample> _SelectList(DbManagerProxy manager
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
      
            
            public virtual List<HumanCaseSample> _SelectListInternal(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
                HumanCaseSample _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[2];
                    List<HumanCaseSample> objs = new List<HumanCaseSample>();
                    sets[0] = new MapResultSet(typeof(HumanCaseSample), objs);
                    List<HumanCaseSampleTest> objs_HumanCaseSampleTest = new List<HumanCaseSampleTest>();
                    sets[1] = new MapResultSet(typeof(HumanCaseSampleTest), objs_HumanCaseSampleTest);
                    
                    manager
                        .SetSpCommand("spHumanCaseSamples_SelectDetail"
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
                        
                        obj.Tests.Clear();
                        obj.Tests.AddRange(objs_HumanCaseSampleTest.Where(c => c.idfMaterial == obj.idfMaterial).ToList(), false);
                        
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
    
            private void _SetupAddChildHandlerTests(HumanCaseSample obj)
            {
                obj.Tests.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, HumanCaseSample obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj.idfsSampleTypeSaved = new Func<HumanCaseSample, long?>(c => c.idfsSampleType)(obj);
                obj.FilterByDiagnosis = new Func<HumanCaseSample, bool>(c => EidssUserContext.User.Options.Prefs.FilterByDiagnosis)(obj);
                // loading extenters - end
                if (!bCloning)
                {
                
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.SampleType = new Func<HumanCaseSample, SampleTypeForDiagnosisLookup>(c => c.SampleTypeLookup.FirstOrDefault(a => a.idfsReference == c.idfsSampleTypeSaved))(obj);
                obj.SampleTypeWithUnknown = new Func<HumanCaseSample, SampleTypeForDiagnosisLookup>(c => c.SampleTypeWithUnknownLookup.FirstOrDefault(a => a.idfsReference == c.idfsSampleTypeSaved))(obj);
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerTests(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, HumanCaseSample obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.Tests.ForEach(c => TestsAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private HumanCaseSample _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                HumanCaseSample obj = null;
                try
                {
                    obj = HumanCaseSample.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfMaterial = (new GetNewIDExtender<HumanCaseSample>()).GetScalar(manager, obj, isFake);
                obj.datFieldCollectionDate = new Func<HumanCaseSample, DateTime?>(c => DateTime.Now.Date)(obj);
                obj.datFieldSentDate = new Func<HumanCaseSample, DateTime?>(c => DateTime.Now.Date)(obj);
                obj.FilterByDiagnosis = new Func<HumanCaseSample, bool>(c => EidssUserContext.User.Options.Prefs.FilterByDiagnosis)(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerTests(obj);
                    
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

            
            public HumanCaseSample CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public HumanCaseSample CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public HumanCaseSample CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public HumanCaseSample CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
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
            public HumanCaseSample Create(DbManagerProxy manager, IObject Parent
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
                obj.idfCase = new Func<HumanCaseSample, long>(c => (Parent as HumanCase).idfCase)(obj);
                obj.idfSendToOffice = new Func<HumanCaseSample, long?>(c => idfSendToOffice)(obj);
                obj.idfFieldCollectedByOffice = new Func<HumanCaseSample, long?>(c => idfFieldCollectedByOffice)(obj);
                obj.idfFieldCollectedByPerson = new Func<HumanCaseSample, long?>(c => idfFieldCollectedByPerson)(obj);
                obj.strSendToOffice = new Func<HumanCaseSample, string>(c => strSendToOffice)(obj);
                obj.strFieldCollectedByOffice = new Func<HumanCaseSample, string>(c => strFieldCollectedByOffice)(obj);
                obj.strFieldCollectedByPerson = new Func<HumanCaseSample, string>(c => strFieldCollectedByPerson)(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(HumanCaseSample obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(HumanCaseSample obj)
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
                    
                obj.strSampleName = new Func<HumanCaseSample, string>(c => c.SampleType == null ? (c.idfsSampleType == (long) SampleTypeEnum.Unknown ? c.SampleTypeWithUnknownLookup.FirstOrDefault(a => a.idfsReference == (long) SampleTypeEnum.Unknown).name : "") : c.SampleType.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_FilterByDiagnosis)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_SampleType(manager, obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_SampleTypeWithUnknown(DbManagerProxy manager, HumanCaseSample obj)
            {
                
                obj.SampleTypeWithUnknownLookup.Clear();
                
                obj.SampleTypeWithUnknownLookup.Add(SampleTypeWithUnknownAccessor.CreateNewT(manager, null));
                
                obj.SampleTypeWithUnknownLookup.AddRange(SampleTypeWithUnknownAccessor.SelectLookupList(manager
                    
                    , null
                    )
                    .Where(c => (c.intHACode & (int)HACode.Human) != 0 || c.idfsReference == obj.idfsSampleType)
                        
                    .Where(c => (c.idfsDiagnosis == 0) || (c.idfsReference == obj.idfsSampleType))
                        
                    .Where(c => c.idfsReference != 0)
                        
                    .Distinct(new SampleTypeForDiagnosisLookupComparator())
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsSampleType))
                    
                    .ToList());
                
                if (obj.idfsSampleType != 0)
                {
                    obj.SampleTypeWithUnknown = obj.SampleTypeWithUnknownLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsSampleType);
                    
                }
              
                LookupManager.AddObject("SampleTypeForDiagnosisLookup", obj, SampleTypeWithUnknownAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_SampleType(DbManagerProxy manager, HumanCaseSample obj)
            {
                
                obj.SampleTypeLookup.Clear();
                
                obj.SampleTypeLookup.Add(SampleTypeAccessor.CreateNewT(manager, null));
                
                obj.SampleTypeLookup.AddRange(SampleTypeAccessor.SelectLookupList(manager
                    
                    , null
                    )
                    .Where(c => (c.intHACode & (int)HACode.Human) != 0 || c.idfsReference == obj.idfsSampleType)
                        
                    .Where(c => (c.idfsDiagnosis == ((obj.FilterByDiagnosis && obj.idfsDiagnosisFromCase != null) ? obj.idfsDiagnosisFromCase.Value : 0)) || (c.idfsReference == obj.idfsSampleType))
                        
                    .Where(c => c.idfsReference != (long)SampleTypeEnum.Unknown)
                        
                    .Where(c => c.idfsReference != 0)
                        
                    .Distinct(new SampleTypeForDiagnosisLookupComparator())
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsSampleType))
                    
                    .ToList());
                
                if (obj.idfsSampleType != 0)
                {
                    obj.SampleType = obj.SampleTypeLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsSampleType);
                    
                }
              
                LookupManager.AddObject("SampleTypeForDiagnosisLookup", obj, SampleTypeAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_AccessionCondition(DbManagerProxy manager, HumanCaseSample obj)
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
            

            internal void _LoadLookups(DbManagerProxy manager, HumanCaseSample obj)
            {
                
                LoadLookup_SampleTypeWithUnknown(manager, obj);
                
                LoadLookup_SampleType(manager, obj);
                
                LoadLookup_AccessionCondition(manager, obj);
                
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
                [Direction.InputOutput("idfMaterial")] HumanCaseSample obj);
            protected void _postInsertPredicate(DbManagerProxy manager, 
                [Direction.InputOutput("idfMaterial")] HumanCaseSample obj)
            {
                
                _postInsert(manager, obj);
                
            }
        
            [SprocName("spLabSample_Update")]
            protected abstract void _postUpdate(DbManagerProxy manager, 
                [Direction.InputOutput()] HumanCaseSample obj);
            protected void _postUpdatePredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] HumanCaseSample obj)
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
                        HumanCaseSample bo = obj as HumanCaseSample;
                        
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
                        bSuccess = _PostNonTransaction(manager, obj as HumanCaseSample, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, HumanCaseSample obj, bool bChildObject) 
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
                obj.idfParty = new Func<HumanCaseSample, long?>(c => (c.Parent is HumanCase) ? (c.Parent as HumanCase).idfHuman : null)(obj);
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
            
            public bool ValidateCanDelete(HumanCaseSample obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, HumanCaseSample obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(HumanCaseSample obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<HumanCaseSample>(obj, "datFieldCollectionDate", c => true, 
      obj.datFieldCollectionDate,
      obj.GetType(),
      false, listdatFieldCollectionDate => {
    listdatFieldCollectionDate.Add(
    new ChainsValidatorDateTime<HumanCaseSample>(obj, "datFieldSentDate", c => true, 
      obj.datFieldSentDate,
      obj.GetType(),
      false, listdatFieldSentDate => {
    listdatFieldSentDate.Add(
    new ChainsValidatorDateTime<HumanCaseSample>(obj, "datAccession", c => true, 
      obj.datAccession,
      obj.GetType(),
      false, listdatAccession => {
    listdatAccession.Add(
    new ChainsValidatorDateTime<HumanCaseSample>(obj, "CurrentDate", c => true, 
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
            protected bool ChainsValidate(HumanCaseSample obj, bool bRethrowException)
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
                return Validate(manager, obj as HumanCaseSample, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, HumanCaseSample obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsSampleType", "SampleType","SampleType",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsSampleType);
            
            (new CustomMandatoryFieldValidator("idfSendToOffice", "idfSendToOffice", "",
            ValidationEventType.Error
            )).Validate(obj, obj.idfSendToOffice, CustomMandatoryField.HumanCaseSample_SentTo,
            c => c.idfsSampleType != (long)SampleTypeEnum.Unknown);

          
            (new CustomMandatoryFieldValidator("strSendToOffice", "strSendToOffice", "",
            ValidationEventType.Error
            )).Validate(obj, obj.strSendToOffice, CustomMandatoryField.HumanCaseSample_SentTo,
            c => c.idfsSampleType != (long)SampleTypeEnum.Unknown);

          
                  
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
           
    
            private void _SetupRequired(HumanCaseSample obj)
            {
            
                obj
                    .AddRequired("SampleType", c => true);
                    
                  obj
                    .AddRequired("SampleTypeWithUnknown", c => true);
                
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCaseSample_SentTo)  && new Func<HumanCaseSample, bool>(c => c.idfsSampleType != (long)SampleTypeEnum.Unknown)(obj))
              {
                obj
                  .AddRequired("idfSendToOffice", c => c.idfsSampleType != (long)SampleTypeEnum.Unknown);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCaseSample_SentTo)  && new Func<HumanCaseSample, bool>(c => c.idfsSampleType != (long)SampleTypeEnum.Unknown)(obj))
              {
                obj
                  .AddRequired("strSendToOffice", c => c.idfsSampleType != (long)SampleTypeEnum.Unknown);
                
                }
            
            }
    
    private void _SetupPersonalDataRestrictions(HumanCaseSample obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as HumanCaseSample) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as HumanCaseSample) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "HumanCaseSampleDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spHumanCaseSamples_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "spLabSample_Create";
            public static string spUpdate = "spLabSample_Update";
            public static string spDelete = "spLabSample_Delete";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<HumanCaseSample, bool>> RequiredByField = new Dictionary<string, Func<HumanCaseSample, bool>>();
            public static Dictionary<string, Func<HumanCaseSample, bool>> RequiredByProperty = new Dictionary<string, Func<HumanCaseSample, bool>>();
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
                if (!RequiredByField.ContainsKey("idfsSampleType")) RequiredByField.Add("idfsSampleType", c => true);
                if (!RequiredByProperty.ContainsKey("SampleType")) RequiredByProperty.Add("SampleType", c => true);
                
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
                    "strFieldBarcodeLocal", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldCollectionDate,
                    _str_datFieldCollectionDate, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldSentDate,
                    _str_datFieldSentDate, null, true, true, true, true, true, null
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
                    _str_strNote,
                    "strComment", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestName,
                    "TestName", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestResult,
                    "TestResult", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datTestPerformedDate,
                    "datConcludedDate", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldCollectedByOffice,
                    "CollectedbyInstitution", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldCollectedByPerson,
                    "CollectedbyOfficer", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSendToOffice,
                    "strSendToOrganization", null, true, true, true, true, true, null
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
                        /*from BvMessages*/"Add",
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
                    (manager, c, pars) => ((HumanCaseSample)c).MarkToDelete(),
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
    public abstract partial class HumanCaseSampleTest : 
        EditableObject<HumanCaseSampleTest>
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
                
        [LocalizedDisplayName(_str_TestName)]
        [MapField(_str_TestName)]
        public abstract String TestName { get; set; }
        protected String TestName_Original { get { return ((EditableValue<String>)((dynamic)this)._testName).OriginalValue; } }
        protected String TestName_Previous { get { return ((EditableValue<String>)((dynamic)this)._testName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMaterial)]
        [MapField(_str_idfMaterial)]
        public abstract Int64 idfMaterial { get; set; }
        protected Int64 idfMaterial_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfMaterial).OriginalValue; } }
        protected Int64 idfMaterial_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfMaterial).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfRootMaterial)]
        [MapField(_str_idfRootMaterial)]
        public abstract Int64? idfRootMaterial { get; set; }
        protected Int64? idfRootMaterial_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootMaterial).OriginalValue; } }
        protected Int64? idfRootMaterial_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootMaterial).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTestResult)]
        [MapField(_str_idfsTestResult)]
        public abstract Int64? idfsTestResult { get; set; }
        protected Int64? idfsTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).OriginalValue; } }
        protected Int64? idfsTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).PreviousValue; } }
                
        [LocalizedDisplayName(_str_TestResult)]
        [MapField(_str_TestResult)]
        public abstract String TestResult { get; set; }
        protected String TestResult_Original { get { return ((EditableValue<String>)((dynamic)this)._testResult).OriginalValue; } }
        protected String TestResult_Previous { get { return ((EditableValue<String>)((dynamic)this)._testResult).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datPerformedDate)]
        [MapField(_str_datPerformedDate)]
        public abstract DateTime? datPerformedDate { get; set; }
        protected DateTime? datPerformedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPerformedDate).OriginalValue; } }
        protected DateTime? datPerformedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPerformedDate).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<HumanCaseSampleTest, object> _get_func;
            internal Action<HumanCaseSampleTest, string> _set_func;
            internal Action<HumanCaseSampleTest, HumanCaseSampleTest, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfTesting = "idfTesting";
        internal const string _str_idfsTestName = "idfsTestName";
        internal const string _str_TestName = "TestName";
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_idfRootMaterial = "idfRootMaterial";
        internal const string _str_idfsTestResult = "idfsTestResult";
        internal const string _str_TestResult = "TestResult";
        internal const string _str_datPerformedDate = "datPerformedDate";
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
              _name = _str_idfsTestName, _formname = _str_idfsTestName, _type = "Int64?",
              _get_func = o => o.idfsTestName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTestName != newval) o.idfsTestName = newval; },
              _compare_func = (o, c, m, g) => {
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
              _compare_func = (o, c, m, g) => {
                if (o.TestName != c.TestName || o.IsRIRPropChanged(_str_TestName, c)) 
                  m.Add(_str_TestName, o.ObjectIdent + _str_TestName, o.ObjectIdent2 + _str_TestName, o.ObjectIdent3 + _str_TestName, "String", 
                    o.TestName == null ? "" : o.TestName.ToString(),                  
                  o.IsReadOnly(_str_TestName), o.IsInvisible(_str_TestName), o.IsRequired(_str_TestName)); 
                  }
              }, 
                  
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
              _name = _str_idfsTestResult, _formname = _str_idfsTestResult, _type = "Int64?",
              _get_func = o => o.idfsTestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTestResult != newval) o.idfsTestResult = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsTestResult != c.idfsTestResult || o.IsRIRPropChanged(_str_idfsTestResult, c)) 
                  m.Add(_str_idfsTestResult, o.ObjectIdent + _str_idfsTestResult, o.ObjectIdent2 + _str_idfsTestResult, o.ObjectIdent3 + _str_idfsTestResult, "Int64?", 
                    o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(),                  
                  o.IsReadOnly(_str_idfsTestResult), o.IsInvisible(_str_idfsTestResult), o.IsRequired(_str_idfsTestResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_TestResult, _formname = _str_TestResult, _type = "String",
              _get_func = o => o.TestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.TestResult != newval) o.TestResult = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.TestResult != c.TestResult || o.IsRIRPropChanged(_str_TestResult, c)) 
                  m.Add(_str_TestResult, o.ObjectIdent + _str_TestResult, o.ObjectIdent2 + _str_TestResult, o.ObjectIdent3 + _str_TestResult, "String", 
                    o.TestResult == null ? "" : o.TestResult.ToString(),                  
                  o.IsReadOnly(_str_TestResult), o.IsInvisible(_str_TestResult), o.IsRequired(_str_TestResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datPerformedDate, _formname = _str_datPerformedDate, _type = "DateTime?",
              _get_func = o => o.datPerformedDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datPerformedDate != newval) o.datPerformedDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datPerformedDate != c.datPerformedDate || o.IsRIRPropChanged(_str_datPerformedDate, c)) 
                  m.Add(_str_datPerformedDate, o.ObjectIdent + _str_datPerformedDate, o.ObjectIdent2 + _str_datPerformedDate, o.ObjectIdent3 + _str_datPerformedDate, "DateTime?", 
                    o.datPerformedDate == null ? "" : o.datPerformedDate.ToString(),                  
                  o.IsReadOnly(_str_datPerformedDate), o.IsInvisible(_str_datPerformedDate), o.IsRequired(_str_datPerformedDate)); 
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
            HumanCaseSampleTest obj = (HumanCaseSampleTest)o;
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
        internal string m_ObjectName = "HumanCaseSampleTest";

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
            var ret = base.Clone() as HumanCaseSampleTest;
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
            var ret = base.Clone() as HumanCaseSampleTest;
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
        public HumanCaseSampleTest CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as HumanCaseSampleTest;
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

        private bool IsRIRPropChanged(string fld, HumanCaseSampleTest c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, HumanCaseSampleTest c)
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
            return new Func<HumanCaseSampleTest, string>(c => c.TestName)(this);
        }
        

        public HumanCaseSampleTest()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(HumanCaseSampleTest_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(HumanCaseSampleTest_PropertyChanged);
        }
        private void HumanCaseSampleTest_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as HumanCaseSampleTest).Changed(e.PropertyName);
            
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
            HumanCaseSampleTest obj = this;
            
        }
        private void _DeletedExtenders()
        {
            HumanCaseSampleTest obj = this;
            
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


        internal Dictionary<string, Func<HumanCaseSampleTest, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<HumanCaseSampleTest, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<HumanCaseSampleTest, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<HumanCaseSampleTest, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<HumanCaseSampleTest, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<HumanCaseSampleTest, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<HumanCaseSampleTest, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~HumanCaseSampleTest()
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
        : DataAccessor<HumanCaseSampleTest>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<HumanCaseSampleTest>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfTesting"; } }
            #endregion
        
            public delegate void on_action(HumanCaseSampleTest obj);
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
            
        
            public virtual List<HumanCaseSampleTest> SelectList(DbManagerProxy manager
                , Int64? idfCase
                )
            {
                return _SelectList(manager
                    , idfCase
                    , delegate(HumanCaseSampleTest obj)
                        {
                        }
                    , delegate(HumanCaseSampleTest obj)
                        {
                        }
                    );
            }

            

            public List<HumanCaseSampleTest> _SelectList(DbManagerProxy manager
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
      
            
            public virtual List<HumanCaseSampleTest> _SelectListInternal(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
                HumanCaseSampleTest _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<HumanCaseSampleTest> objs = new List<HumanCaseSampleTest>();
                    sets[0] = new MapResultSet(typeof(HumanCaseSampleTest), objs);
                    
                    manager
                        .SetSpCommand("spHumanCaseSamples_SelectDetail"
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, HumanCaseSampleTest obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, HumanCaseSampleTest obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private HumanCaseSampleTest _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                HumanCaseSampleTest obj = null;
                try
                {
                    obj = HumanCaseSampleTest.CreateInstance();
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

            
            public HumanCaseSampleTest CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public HumanCaseSampleTest CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public HumanCaseSampleTest CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public HumanCaseSampleTest CreateFromCaseTestT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is CaseTest)) 
                    throw new TypeMismatchException("test", typeof(CaseTest));
                
                return CreateFromCaseTest(manager, Parent
                    , (CaseTest)pars[0]
                    );
            }
            public IObject CreateFromCaseTest(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateFromCaseTestT(manager, Parent, pars);
            }
            public HumanCaseSampleTest CreateFromCaseTest(DbManagerProxy manager, IObject Parent
                , CaseTest test
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfTesting = new Func<HumanCaseSampleTest, long>(c => test.idfTesting)(obj);
                obj.idfMaterial = new Func<HumanCaseSampleTest, long>(c => test.idfMaterialHuman.Value)(obj);
                obj.TestName = new Func<HumanCaseSampleTest, string>(c => test.TestName)(obj);
                obj.TestResult = new Func<HumanCaseSampleTest, string>(c => test.TestResult)(obj);
                obj.datPerformedDate = new Func<HumanCaseSampleTest, DateTime?>(c => test.datConcludedDate)(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            public ActResult UpdateFromCaseTest(DbManagerProxy manager, HumanCaseSampleTest obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is CaseTest)) 
                    throw new TypeMismatchException("test", typeof(CaseTest));
                
                return UpdateFromCaseTest(manager, obj
                    , (CaseTest)pars[0]
                    );
            }
            public ActResult UpdateFromCaseTest(DbManagerProxy manager, HumanCaseSampleTest obj
                , CaseTest test
                )
            {
                
              obj.idfTesting = test.idfTesting;
              obj.idfMaterial = test.idfMaterialHuman.Value;
              obj.TestName = test.TestName;
              obj.TestResult = test.TestResult;
              obj.datPerformedDate = test.datConcludedDate;
              return true;
            
            }
            
      
            private void _SetupChildHandlers(HumanCaseSampleTest obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(HumanCaseSampleTest obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, HumanCaseSampleTest obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(HumanCaseSampleTest obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(HumanCaseSampleTest obj, bool bRethrowException)
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
                return Validate(manager, obj as HumanCaseSampleTest, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, HumanCaseSampleTest obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(HumanCaseSampleTest obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(HumanCaseSampleTest obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as HumanCaseSampleTest) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as HumanCaseSampleTest) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "HumanCaseSampleTestDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spHumanCaseSamples_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<HumanCaseSampleTest, bool>> RequiredByField = new Dictionary<string, Func<HumanCaseSampleTest, bool>>();
            public static Dictionary<string, Func<HumanCaseSampleTest, bool>> RequiredByProperty = new Dictionary<string, Func<HumanCaseSampleTest, bool>>();
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
                Actions.Add(new ActionMetaItem(
                    "CreateFromCaseTest",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateFromCaseTest(manager, c, pars)),
                        
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
                    "UpdateFromCaseTest",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).UpdateFromCaseTest(manager, (HumanCaseSampleTest)c, pars),
                        
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
                    (manager, c, pars) => ((HumanCaseSampleTest)c).MarkToDelete(),
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
	