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
    public abstract partial class AsSessionAnimalSample : 
        EditableObject<AsSessionAnimalSample>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_id), NonUpdatable, PrimaryKey]
        public abstract Int64 id { get; set; }
                
        [LocalizedDisplayName(_str_idfAnimal)]
        [MapField(_str_idfAnimal)]
        public abstract Int64 idfAnimal { get; set; }
        protected Int64 idfAnimal_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfAnimal).OriginalValue; } }
        protected Int64 idfAnimal_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfAnimal).PreviousValue; } }
                
        [LocalizedDisplayName("AsSessionTableViewItem.AnimalAge")]
        [MapField(_str_idfsAnimalAge)]
        public abstract Int64? idfsAnimalAge { get; set; }
        protected Int64? idfsAnimalAge_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalAge).OriginalValue; } }
        protected Int64? idfsAnimalAge_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalAge).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsAnimalGender)]
        [MapField(_str_idfsAnimalGender)]
        public abstract Int64? idfsAnimalGender { get; set; }
        protected Int64? idfsAnimalGender_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalGender).OriginalValue; } }
        protected Int64? idfsAnimalGender_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalGender).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfSpecies)]
        [MapField(_str_idfSpecies)]
        public abstract Int64? idfSpecies { get; set; }
        protected Int64? idfSpecies_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).OriginalValue; } }
        protected Int64? idfSpecies_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).PreviousValue; } }
                
        [LocalizedDisplayName("strAnimalName")]
        [MapField(_str_strName)]
        public abstract String strName { get; set; }
        protected String strName_Original { get { return ((EditableValue<String>)((dynamic)this)._strName).OriginalValue; } }
        protected String strName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strColor)]
        [MapField(_str_strColor)]
        public abstract String strColor { get; set; }
        protected String strColor_Original { get { return ((EditableValue<String>)((dynamic)this)._strColor).OriginalValue; } }
        protected String strColor_Previous { get { return ((EditableValue<String>)((dynamic)this)._strColor).PreviousValue; } }
                
        [LocalizedDisplayName("strComments")]
        [MapField(_str_strDescription)]
        public abstract String strDescription { get; set; }
        protected String strDescription_Original { get { return ((EditableValue<String>)((dynamic)this)._strDescription).OriginalValue; } }
        protected String strDescription_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDescription).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSpeciesType)]
        [MapField(_str_idfsSpeciesType)]
        public abstract Int64 idfsSpeciesType { get; set; }
        protected Int64 idfsSpeciesType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSpeciesType).OriginalValue; } }
        protected Int64 idfsSpeciesType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSpeciesType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMonitoringSession)]
        [MapField(_str_idfMonitoringSession)]
        public abstract Int64? idfMonitoringSession { get; set; }
        protected Int64? idfMonitoringSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).OriginalValue; } }
        protected Int64? idfMonitoringSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFarmCode)]
        [MapField(_str_strFarmCode)]
        public abstract String strFarmCode { get; set; }
        protected String strFarmCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).OriginalValue; } }
        protected String strFarmCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfFarm)]
        [MapField(_str_idfFarm)]
        public abstract Int64 idfFarm { get; set; }
        protected Int64 idfFarm_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfFarm).OriginalValue; } }
        protected Int64 idfFarm_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfFarm).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMaterial)]
        [MapField(_str_idfMaterial)]
        public abstract Int64? idfMaterial { get; set; }
        protected Int64? idfMaterial_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMaterial).OriginalValue; } }
        protected Int64? idfMaterial_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMaterial).PreviousValue; } }
                
        [LocalizedDisplayName("AsSessionTableViewItem.SampleType")]
        [MapField(_str_idfsSampleType)]
        public abstract Int64? idfsSampleType { get; set; }
        protected Int64? idfsSampleType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleType).OriginalValue; } }
        protected Int64? idfsSampleType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleType).PreviousValue; } }
                
        [LocalizedDisplayName("AsSessionTableViewItem.strFieldBarcode")]
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
                
        [LocalizedDisplayName(_str_datAccession)]
        [MapField(_str_datAccession)]
        public abstract DateTime? datAccession { get; set; }
        protected DateTime? datAccession_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).OriginalValue; } }
        protected DateTime? datAccession_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_bSampleAccessioned)]
        [MapField(_str_bSampleAccessioned)]
        public abstract Boolean bSampleAccessioned { get; set; }
        protected Boolean bSampleAccessioned_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._bSampleAccessioned).OriginalValue; } }
        protected Boolean bSampleAccessioned_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._bSampleAccessioned).PreviousValue; } }
                
        [LocalizedDisplayName(_str_Used)]
        [MapField(_str_Used)]
        public abstract Boolean Used { get; set; }
        protected Boolean Used_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._used).OriginalValue; } }
        protected Boolean Used_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._used).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfSendToOffice)]
        [MapField(_str_idfSendToOffice)]
        public abstract Int64? idfSendToOffice { get; set; }
        protected Int64? idfSendToOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).OriginalValue; } }
        protected Int64? idfSendToOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).PreviousValue; } }
                
        [LocalizedDisplayName("strSendToOrganization")]
        [MapField(_str_strSendToOffice)]
        public abstract String strSendToOffice { get; set; }
        protected String strSendToOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strSendToOffice).OriginalValue; } }
        protected String strSendToOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSendToOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strAnimalCode)]
        [MapField(_str_strAnimalCode)]
        public abstract String strAnimalCode { get; set; }
        protected String strAnimalCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strAnimalCode).OriginalValue; } }
        protected String strAnimalCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAnimalCode).PreviousValue; } }
                
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
            internal Func<AsSessionAnimalSample, object> _get_func;
            internal Action<AsSessionAnimalSample, string> _set_func;
            internal Action<AsSessionAnimalSample, AsSessionAnimalSample, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_id = "id";
        internal const string _str_idfAnimal = "idfAnimal";
        internal const string _str_idfsAnimalAge = "idfsAnimalAge";
        internal const string _str_idfsAnimalGender = "idfsAnimalGender";
        internal const string _str_idfSpecies = "idfSpecies";
        internal const string _str_strName = "strName";
        internal const string _str_strColor = "strColor";
        internal const string _str_strDescription = "strDescription";
        internal const string _str_idfsSpeciesType = "idfsSpeciesType";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_strFarmCode = "strFarmCode";
        internal const string _str_idfFarm = "idfFarm";
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_idfsSampleType = "idfsSampleType";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_datFieldSentDate = "datFieldSentDate";
        internal const string _str_datAccession = "datAccession";
        internal const string _str_bSampleAccessioned = "bSampleAccessioned";
        internal const string _str_Used = "Used";
        internal const string _str_idfSendToOffice = "idfSendToOffice";
        internal const string _str_strSendToOffice = "strSendToOffice";
        internal const string _str_strAnimalCode = "strAnimalCode";
        internal const string _str_uidOfflineCaseID = "uidOfflineCaseID";
        internal const string _str_NumOfCopies = "NumOfCopies";
        internal const string _str_SequenceNumber = "SequenceNumber";
        internal const string _str_FilterByDiagnosis = "FilterByDiagnosis";
        internal const string _str_strAnimalCodeReadonly = "strAnimalCodeReadonly";
        internal const string _str_AnimalAgeReadonly = "AnimalAgeReadonly";
        internal const string _str_strColorReadonly = "strColorReadonly";
        internal const string _str_AnimalGenderReadonly = "AnimalGenderReadonly";
        internal const string _str_strNameReadonly = "strNameReadonly";
        internal const string _str_strDescriptionReadonly = "strDescriptionReadonly";
        internal const string _str_SampleTypeReadonly = "SampleTypeReadonly";
        internal const string _str_strFieldBarcodeReadonly = "strFieldBarcodeReadonly";
        internal const string _str_datFieldCollectionDateReadonly = "datFieldCollectionDateReadonly";
        internal const string _str_newAnimalName = "newAnimalName";
        internal const string _str_bIsLinkToNewAnimal = "bIsLinkToNewAnimal";
        internal const string _str_strAnimalAge = "strAnimalAge";
        internal const string _str_strAnimalGender = "strAnimalGender";
        internal const string _str_strSpeciesType = "strSpeciesType";
        internal const string _str_strSampleName = "strSampleName";
        internal const string _str_strSampleNameAndFieldBarcode = "strSampleNameAndFieldBarcode";
        internal const string _str_ParentFarms = "ParentFarms";
        internal const string _str_ParentSpecies = "ParentSpecies";
        internal const string _str_ParentAnimals = "ParentAnimals";
        internal const string _str_ParentAnimalsAll = "ParentAnimalsAll";
        internal const string _str_ParentAnimalsSamples = "ParentAnimalsSamples";
        internal const string _str_Farms = "Farms";
        internal const string _str_Species = "Species";
        internal const string _str_Animals = "Animals";
        internal const string _str_AnimalGender = "AnimalGender";
        internal const string _str_AnimalAge = "AnimalAge";
        internal const string _str_SpeciesType = "SpeciesType";
        internal const string _str_SampleType = "SampleType";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_id, _formname = _str_id, _type = "Int64",
              _get_func = o => o.id,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.id != newval) o.id = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.id != c.id || o.IsRIRPropChanged(_str_id, c)) 
                  m.Add(_str_id, o.ObjectIdent + _str_id, o.ObjectIdent2 + _str_id, o.ObjectIdent3 + _str_id, "Int64", 
                    o.id == null ? "" : o.id.ToString(),                  
                  o.IsReadOnly(_str_id), o.IsInvisible(_str_id), o.IsRequired(_str_id)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfAnimal, _formname = _str_idfAnimal, _type = "Int64",
              _get_func = o => o.idfAnimal,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfAnimal != newval) o.idfAnimal = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfAnimal != c.idfAnimal || o.IsRIRPropChanged(_str_idfAnimal, c)) 
                  m.Add(_str_idfAnimal, o.ObjectIdent + _str_idfAnimal, o.ObjectIdent2 + _str_idfAnimal, o.ObjectIdent3 + _str_idfAnimal, "Int64", 
                    o.idfAnimal == null ? "" : o.idfAnimal.ToString(),                  
                  o.IsReadOnly(_str_idfAnimal), o.IsInvisible(_str_idfAnimal), o.IsRequired(_str_idfAnimal)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAnimalAge, _formname = _str_idfsAnimalAge, _type = "Int64?",
              _get_func = o => o.idfsAnimalAge,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsAnimalAge != newval) 
                  o.AnimalAge = o.AnimalAgeLookup.FirstOrDefault(c => c.idfsReference == newval);
                if (o.idfsAnimalAge != newval) o.idfsAnimalAge = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsAnimalAge != c.idfsAnimalAge || o.IsRIRPropChanged(_str_idfsAnimalAge, c)) 
                  m.Add(_str_idfsAnimalAge, o.ObjectIdent + _str_idfsAnimalAge, o.ObjectIdent2 + _str_idfsAnimalAge, o.ObjectIdent3 + _str_idfsAnimalAge, "Int64?", 
                    o.idfsAnimalAge == null ? "" : o.idfsAnimalAge.ToString(),                  
                  o.IsReadOnly(_str_idfsAnimalAge), o.IsInvisible(_str_idfsAnimalAge), o.IsRequired(_str_idfsAnimalAge)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAnimalGender, _formname = _str_idfsAnimalGender, _type = "Int64?",
              _get_func = o => o.idfsAnimalGender,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsAnimalGender != newval) 
                  o.AnimalGender = o.AnimalGenderLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsAnimalGender != newval) o.idfsAnimalGender = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsAnimalGender != c.idfsAnimalGender || o.IsRIRPropChanged(_str_idfsAnimalGender, c)) 
                  m.Add(_str_idfsAnimalGender, o.ObjectIdent + _str_idfsAnimalGender, o.ObjectIdent2 + _str_idfsAnimalGender, o.ObjectIdent3 + _str_idfsAnimalGender, "Int64?", 
                    o.idfsAnimalGender == null ? "" : o.idfsAnimalGender.ToString(),                  
                  o.IsReadOnly(_str_idfsAnimalGender), o.IsInvisible(_str_idfsAnimalGender), o.IsRequired(_str_idfsAnimalGender)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSpecies, _formname = _str_idfSpecies, _type = "Int64?",
              _get_func = o => o.idfSpecies,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfSpecies != newval) 
                  o.Species = o.SpeciesLookup.FirstOrDefault(c => c.idfParty == newval);
                if (o.idfSpecies != newval) o.idfSpecies = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfSpecies != c.idfSpecies || o.IsRIRPropChanged(_str_idfSpecies, c)) 
                  m.Add(_str_idfSpecies, o.ObjectIdent + _str_idfSpecies, o.ObjectIdent2 + _str_idfSpecies, o.ObjectIdent3 + _str_idfSpecies, "Int64?", 
                    o.idfSpecies == null ? "" : o.idfSpecies.ToString(),                  
                  o.IsReadOnly(_str_idfSpecies), o.IsInvisible(_str_idfSpecies), o.IsRequired(_str_idfSpecies)); 
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
              _name = _str_strColor, _formname = _str_strColor, _type = "String",
              _get_func = o => o.strColor,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strColor != newval) o.strColor = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strColor != c.strColor || o.IsRIRPropChanged(_str_strColor, c)) 
                  m.Add(_str_strColor, o.ObjectIdent + _str_strColor, o.ObjectIdent2 + _str_strColor, o.ObjectIdent3 + _str_strColor, "String", 
                    o.strColor == null ? "" : o.strColor.ToString(),                  
                  o.IsReadOnly(_str_strColor), o.IsInvisible(_str_strColor), o.IsRequired(_str_strColor)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDescription, _formname = _str_strDescription, _type = "String",
              _get_func = o => o.strDescription,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDescription != newval) o.strDescription = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strDescription != c.strDescription || o.IsRIRPropChanged(_str_strDescription, c)) 
                  m.Add(_str_strDescription, o.ObjectIdent + _str_strDescription, o.ObjectIdent2 + _str_strDescription, o.ObjectIdent3 + _str_strDescription, "String", 
                    o.strDescription == null ? "" : o.strDescription.ToString(),                  
                  o.IsReadOnly(_str_strDescription), o.IsInvisible(_str_strDescription), o.IsRequired(_str_strDescription)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSpeciesType, _formname = _str_idfsSpeciesType, _type = "Int64",
              _get_func = o => o.idfsSpeciesType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsSpeciesType != newval) 
                  o.SpeciesType = o.SpeciesTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsSpeciesType != newval) o.idfsSpeciesType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_idfsSpeciesType, c)) 
                  m.Add(_str_idfsSpeciesType, o.ObjectIdent + _str_idfsSpeciesType, o.ObjectIdent2 + _str_idfsSpeciesType, o.ObjectIdent3 + _str_idfsSpeciesType, "Int64", 
                    o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(),                  
                  o.IsReadOnly(_str_idfsSpeciesType), o.IsInvisible(_str_idfsSpeciesType), o.IsRequired(_str_idfsSpeciesType)); 
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
              _name = _str_idfFarm, _formname = _str_idfFarm, _type = "Int64",
              _get_func = o => o.idfFarm,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfFarm != newval) 
                  o.Farms = o.FarmsLookup.FirstOrDefault(c => c.idfFarm == newval);
                if (o.idfFarm != newval) o.idfFarm = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfFarm != c.idfFarm || o.IsRIRPropChanged(_str_idfFarm, c)) 
                  m.Add(_str_idfFarm, o.ObjectIdent + _str_idfFarm, o.ObjectIdent2 + _str_idfFarm, o.ObjectIdent3 + _str_idfFarm, "Int64", 
                    o.idfFarm == null ? "" : o.idfFarm.ToString(),                  
                  o.IsReadOnly(_str_idfFarm), o.IsInvisible(_str_idfFarm), o.IsRequired(_str_idfFarm)); 
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
              _name = _str_idfsSampleType, _formname = _str_idfsSampleType, _type = "Int64?",
              _get_func = o => o.idfsSampleType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsSampleType != newval) 
                  o.SampleType = o.SampleTypeLookup.FirstOrDefault(c => c.idfsReference == newval);
                if (o.idfsSampleType != newval) o.idfsSampleType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSampleType != c.idfsSampleType || o.IsRIRPropChanged(_str_idfsSampleType, c)) 
                  m.Add(_str_idfsSampleType, o.ObjectIdent + _str_idfsSampleType, o.ObjectIdent2 + _str_idfsSampleType, o.ObjectIdent3 + _str_idfsSampleType, "Int64?", 
                    o.idfsSampleType == null ? "" : o.idfsSampleType.ToString(),                  
                  o.IsReadOnly(_str_idfsSampleType), o.IsInvisible(_str_idfsSampleType), o.IsRequired(_str_idfsSampleType)); 
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
              _name = _str_bSampleAccessioned, _formname = _str_bSampleAccessioned, _type = "Boolean",
              _get_func = o => o.bSampleAccessioned,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.bSampleAccessioned != newval) o.bSampleAccessioned = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.bSampleAccessioned != c.bSampleAccessioned || o.IsRIRPropChanged(_str_bSampleAccessioned, c)) 
                  m.Add(_str_bSampleAccessioned, o.ObjectIdent + _str_bSampleAccessioned, o.ObjectIdent2 + _str_bSampleAccessioned, o.ObjectIdent3 + _str_bSampleAccessioned, "Boolean", 
                    o.bSampleAccessioned == null ? "" : o.bSampleAccessioned.ToString(),                  
                  o.IsReadOnly(_str_bSampleAccessioned), o.IsInvisible(_str_bSampleAccessioned), o.IsRequired(_str_bSampleAccessioned)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Used, _formname = _str_Used, _type = "Boolean",
              _get_func = o => o.Used,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.Used != newval) o.Used = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.Used != c.Used || o.IsRIRPropChanged(_str_Used, c)) 
                  m.Add(_str_Used, o.ObjectIdent + _str_Used, o.ObjectIdent2 + _str_Used, o.ObjectIdent3 + _str_Used, "Boolean", 
                    o.Used == null ? "" : o.Used.ToString(),                  
                  o.IsReadOnly(_str_Used), o.IsInvisible(_str_Used), o.IsRequired(_str_Used)); 
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
              _name = _str_strAnimalCode, _formname = _str_strAnimalCode, _type = "String",
              _get_func = o => o.strAnimalCode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); 
                if (o.strAnimalCode != newval) 
                  o.Animals = o.AnimalsLookup.FirstOrDefault(c => c.strAnimalCode == newval);
                if (o.strAnimalCode != newval) o.strAnimalCode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strAnimalCode != c.strAnimalCode || o.IsRIRPropChanged(_str_strAnimalCode, c)) 
                  m.Add(_str_strAnimalCode, o.ObjectIdent + _str_strAnimalCode, o.ObjectIdent2 + _str_strAnimalCode, o.ObjectIdent3 + _str_strAnimalCode, "String", 
                    o.strAnimalCode == null ? "" : o.strAnimalCode.ToString(),                  
                  o.IsReadOnly(_str_strAnimalCode), o.IsInvisible(_str_strAnimalCode), o.IsRequired(_str_strAnimalCode)); 
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
              _name = _str_NumOfCopies, _formname = _str_NumOfCopies, _type = "int",
              _get_func = o => o.NumOfCopies,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.NumOfCopies != newval) o.NumOfCopies = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.NumOfCopies != c.NumOfCopies || o.IsRIRPropChanged(_str_NumOfCopies, c)) {
                  m.Add(_str_NumOfCopies, o.ObjectIdent + _str_NumOfCopies, o.ObjectIdent2 + _str_NumOfCopies, o.ObjectIdent3 + _str_NumOfCopies,  "int", 
                    o.NumOfCopies == null ? "" : o.NumOfCopies.ToString(),                  
                    o.IsReadOnly(_str_NumOfCopies), o.IsInvisible(_str_NumOfCopies), o.IsRequired(_str_NumOfCopies));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_SequenceNumber, _formname = _str_SequenceNumber, _type = "int",
              _get_func = o => o.SequenceNumber,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.SequenceNumber != newval) o.SequenceNumber = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.SequenceNumber != c.SequenceNumber || o.IsRIRPropChanged(_str_SequenceNumber, c)) {
                  m.Add(_str_SequenceNumber, o.ObjectIdent + _str_SequenceNumber, o.ObjectIdent2 + _str_SequenceNumber, o.ObjectIdent3 + _str_SequenceNumber,  "int", 
                    o.SequenceNumber == null ? "" : o.SequenceNumber.ToString(),                  
                    o.IsReadOnly(_str_SequenceNumber), o.IsInvisible(_str_SequenceNumber), o.IsRequired(_str_SequenceNumber));
                  }
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
              _name = _str_bIsLinkToNewAnimal, _formname = _str_bIsLinkToNewAnimal, _type = "bool",
              _get_func = o => o.bIsLinkToNewAnimal,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.bIsLinkToNewAnimal != newval) o.bIsLinkToNewAnimal = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.bIsLinkToNewAnimal != c.bIsLinkToNewAnimal || o.IsRIRPropChanged(_str_bIsLinkToNewAnimal, c)) {
                  m.Add(_str_bIsLinkToNewAnimal, o.ObjectIdent + _str_bIsLinkToNewAnimal, o.ObjectIdent2 + _str_bIsLinkToNewAnimal, o.ObjectIdent3 + _str_bIsLinkToNewAnimal,  "bool", 
                    o.bIsLinkToNewAnimal == null ? "" : o.bIsLinkToNewAnimal.ToString(),                  
                    o.IsReadOnly(_str_bIsLinkToNewAnimal), o.IsInvisible(_str_bIsLinkToNewAnimal), o.IsRequired(_str_bIsLinkToNewAnimal));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_strAnimalCodeReadonly, _formname = _str_strAnimalCodeReadonly, _type = "bool",
              _get_func = o => o.strAnimalCodeReadonly,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strAnimalCodeReadonly != c.strAnimalCodeReadonly || o.IsRIRPropChanged(_str_strAnimalCodeReadonly, c)) {
                  m.Add(_str_strAnimalCodeReadonly, o.ObjectIdent + _str_strAnimalCodeReadonly, o.ObjectIdent2 + _str_strAnimalCodeReadonly, o.ObjectIdent3 + _str_strAnimalCodeReadonly, "bool", o.strAnimalCodeReadonly == null ? "" : o.strAnimalCodeReadonly.ToString(), o.IsReadOnly(_str_strAnimalCodeReadonly), o.IsInvisible(_str_strAnimalCodeReadonly), o.IsRequired(_str_strAnimalCodeReadonly));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_AnimalAgeReadonly, _formname = _str_AnimalAgeReadonly, _type = "bool",
              _get_func = o => o.AnimalAgeReadonly,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.AnimalAgeReadonly != c.AnimalAgeReadonly || o.IsRIRPropChanged(_str_AnimalAgeReadonly, c)) {
                  m.Add(_str_AnimalAgeReadonly, o.ObjectIdent + _str_AnimalAgeReadonly, o.ObjectIdent2 + _str_AnimalAgeReadonly, o.ObjectIdent3 + _str_AnimalAgeReadonly, "bool", o.AnimalAgeReadonly == null ? "" : o.AnimalAgeReadonly.ToString(), o.IsReadOnly(_str_AnimalAgeReadonly), o.IsInvisible(_str_AnimalAgeReadonly), o.IsRequired(_str_AnimalAgeReadonly));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strColorReadonly, _formname = _str_strColorReadonly, _type = "bool",
              _get_func = o => o.strColorReadonly,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strColorReadonly != c.strColorReadonly || o.IsRIRPropChanged(_str_strColorReadonly, c)) {
                  m.Add(_str_strColorReadonly, o.ObjectIdent + _str_strColorReadonly, o.ObjectIdent2 + _str_strColorReadonly, o.ObjectIdent3 + _str_strColorReadonly, "bool", o.strColorReadonly == null ? "" : o.strColorReadonly.ToString(), o.IsReadOnly(_str_strColorReadonly), o.IsInvisible(_str_strColorReadonly), o.IsRequired(_str_strColorReadonly));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_AnimalGenderReadonly, _formname = _str_AnimalGenderReadonly, _type = "bool",
              _get_func = o => o.AnimalGenderReadonly,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.AnimalGenderReadonly != c.AnimalGenderReadonly || o.IsRIRPropChanged(_str_AnimalGenderReadonly, c)) {
                  m.Add(_str_AnimalGenderReadonly, o.ObjectIdent + _str_AnimalGenderReadonly, o.ObjectIdent2 + _str_AnimalGenderReadonly, o.ObjectIdent3 + _str_AnimalGenderReadonly, "bool", o.AnimalGenderReadonly == null ? "" : o.AnimalGenderReadonly.ToString(), o.IsReadOnly(_str_AnimalGenderReadonly), o.IsInvisible(_str_AnimalGenderReadonly), o.IsRequired(_str_AnimalGenderReadonly));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strNameReadonly, _formname = _str_strNameReadonly, _type = "bool",
              _get_func = o => o.strNameReadonly,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strNameReadonly != c.strNameReadonly || o.IsRIRPropChanged(_str_strNameReadonly, c)) {
                  m.Add(_str_strNameReadonly, o.ObjectIdent + _str_strNameReadonly, o.ObjectIdent2 + _str_strNameReadonly, o.ObjectIdent3 + _str_strNameReadonly, "bool", o.strNameReadonly == null ? "" : o.strNameReadonly.ToString(), o.IsReadOnly(_str_strNameReadonly), o.IsInvisible(_str_strNameReadonly), o.IsRequired(_str_strNameReadonly));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strDescriptionReadonly, _formname = _str_strDescriptionReadonly, _type = "bool",
              _get_func = o => o.strDescriptionReadonly,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strDescriptionReadonly != c.strDescriptionReadonly || o.IsRIRPropChanged(_str_strDescriptionReadonly, c)) {
                  m.Add(_str_strDescriptionReadonly, o.ObjectIdent + _str_strDescriptionReadonly, o.ObjectIdent2 + _str_strDescriptionReadonly, o.ObjectIdent3 + _str_strDescriptionReadonly, "bool", o.strDescriptionReadonly == null ? "" : o.strDescriptionReadonly.ToString(), o.IsReadOnly(_str_strDescriptionReadonly), o.IsInvisible(_str_strDescriptionReadonly), o.IsRequired(_str_strDescriptionReadonly));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_SampleTypeReadonly, _formname = _str_SampleTypeReadonly, _type = "bool",
              _get_func = o => o.SampleTypeReadonly,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.SampleTypeReadonly != c.SampleTypeReadonly || o.IsRIRPropChanged(_str_SampleTypeReadonly, c)) {
                  m.Add(_str_SampleTypeReadonly, o.ObjectIdent + _str_SampleTypeReadonly, o.ObjectIdent2 + _str_SampleTypeReadonly, o.ObjectIdent3 + _str_SampleTypeReadonly, "bool", o.SampleTypeReadonly == null ? "" : o.SampleTypeReadonly.ToString(), o.IsReadOnly(_str_SampleTypeReadonly), o.IsInvisible(_str_SampleTypeReadonly), o.IsRequired(_str_SampleTypeReadonly));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strFieldBarcodeReadonly, _formname = _str_strFieldBarcodeReadonly, _type = "bool",
              _get_func = o => o.strFieldBarcodeReadonly,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strFieldBarcodeReadonly != c.strFieldBarcodeReadonly || o.IsRIRPropChanged(_str_strFieldBarcodeReadonly, c)) {
                  m.Add(_str_strFieldBarcodeReadonly, o.ObjectIdent + _str_strFieldBarcodeReadonly, o.ObjectIdent2 + _str_strFieldBarcodeReadonly, o.ObjectIdent3 + _str_strFieldBarcodeReadonly, "bool", o.strFieldBarcodeReadonly == null ? "" : o.strFieldBarcodeReadonly.ToString(), o.IsReadOnly(_str_strFieldBarcodeReadonly), o.IsInvisible(_str_strFieldBarcodeReadonly), o.IsRequired(_str_strFieldBarcodeReadonly));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_datFieldCollectionDateReadonly, _formname = _str_datFieldCollectionDateReadonly, _type = "bool",
              _get_func = o => o.datFieldCollectionDateReadonly,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.datFieldCollectionDateReadonly != c.datFieldCollectionDateReadonly || o.IsRIRPropChanged(_str_datFieldCollectionDateReadonly, c)) {
                  m.Add(_str_datFieldCollectionDateReadonly, o.ObjectIdent + _str_datFieldCollectionDateReadonly, o.ObjectIdent2 + _str_datFieldCollectionDateReadonly, o.ObjectIdent3 + _str_datFieldCollectionDateReadonly, "bool", o.datFieldCollectionDateReadonly == null ? "" : o.datFieldCollectionDateReadonly.ToString(), o.IsReadOnly(_str_datFieldCollectionDateReadonly), o.IsInvisible(_str_datFieldCollectionDateReadonly), o.IsRequired(_str_datFieldCollectionDateReadonly));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_newAnimalName, _formname = _str_newAnimalName, _type = "string",
              _get_func = o => o.newAnimalName,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.newAnimalName != c.newAnimalName || o.IsRIRPropChanged(_str_newAnimalName, c)) {
                  m.Add(_str_newAnimalName, o.ObjectIdent + _str_newAnimalName, o.ObjectIdent2 + _str_newAnimalName, o.ObjectIdent3 + _str_newAnimalName, "string", o.newAnimalName == null ? "" : o.newAnimalName.ToString(), o.IsReadOnly(_str_newAnimalName), o.IsInvisible(_str_newAnimalName), o.IsRequired(_str_newAnimalName));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strAnimalAge, _formname = _str_strAnimalAge, _type = "string",
              _get_func = o => o.strAnimalAge,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strAnimalAge != c.strAnimalAge || o.IsRIRPropChanged(_str_strAnimalAge, c)) {
                  m.Add(_str_strAnimalAge, o.ObjectIdent + _str_strAnimalAge, o.ObjectIdent2 + _str_strAnimalAge, o.ObjectIdent3 + _str_strAnimalAge, "string", o.strAnimalAge == null ? "" : o.strAnimalAge.ToString(), o.IsReadOnly(_str_strAnimalAge), o.IsInvisible(_str_strAnimalAge), o.IsRequired(_str_strAnimalAge));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strAnimalGender, _formname = _str_strAnimalGender, _type = "string",
              _get_func = o => o.strAnimalGender,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strAnimalGender != c.strAnimalGender || o.IsRIRPropChanged(_str_strAnimalGender, c)) {
                  m.Add(_str_strAnimalGender, o.ObjectIdent + _str_strAnimalGender, o.ObjectIdent2 + _str_strAnimalGender, o.ObjectIdent3 + _str_strAnimalGender, "string", o.strAnimalGender == null ? "" : o.strAnimalGender.ToString(), o.IsReadOnly(_str_strAnimalGender), o.IsInvisible(_str_strAnimalGender), o.IsRequired(_str_strAnimalGender));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strSpeciesType, _formname = _str_strSpeciesType, _type = "string",
              _get_func = o => o.strSpeciesType,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strSpeciesType != c.strSpeciesType || o.IsRIRPropChanged(_str_strSpeciesType, c)) {
                  m.Add(_str_strSpeciesType, o.ObjectIdent + _str_strSpeciesType, o.ObjectIdent2 + _str_strSpeciesType, o.ObjectIdent3 + _str_strSpeciesType, "string", o.strSpeciesType == null ? "" : o.strSpeciesType.ToString(), o.IsReadOnly(_str_strSpeciesType), o.IsInvisible(_str_strSpeciesType), o.IsRequired(_str_strSpeciesType));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strSampleName, _formname = _str_strSampleName, _type = "string",
              _get_func = o => o.strSampleName,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strSampleName != c.strSampleName || o.IsRIRPropChanged(_str_strSampleName, c)) {
                  m.Add(_str_strSampleName, o.ObjectIdent + _str_strSampleName, o.ObjectIdent2 + _str_strSampleName, o.ObjectIdent3 + _str_strSampleName, "string", o.strSampleName == null ? "" : o.strSampleName.ToString(), o.IsReadOnly(_str_strSampleName), o.IsInvisible(_str_strSampleName), o.IsRequired(_str_strSampleName));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strSampleNameAndFieldBarcode, _formname = _str_strSampleNameAndFieldBarcode, _type = "string",
              _get_func = o => o.strSampleNameAndFieldBarcode,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strSampleNameAndFieldBarcode != c.strSampleNameAndFieldBarcode || o.IsRIRPropChanged(_str_strSampleNameAndFieldBarcode, c)) {
                  m.Add(_str_strSampleNameAndFieldBarcode, o.ObjectIdent + _str_strSampleNameAndFieldBarcode, o.ObjectIdent2 + _str_strSampleNameAndFieldBarcode, o.ObjectIdent3 + _str_strSampleNameAndFieldBarcode, "string", o.strSampleNameAndFieldBarcode == null ? "" : o.strSampleNameAndFieldBarcode.ToString(), o.IsReadOnly(_str_strSampleNameAndFieldBarcode), o.IsInvisible(_str_strSampleNameAndFieldBarcode), o.IsRequired(_str_strSampleNameAndFieldBarcode));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_ParentFarms, _formname = _str_ParentFarms, _type = "List<FarmPanel>",
              _get_func = o => o.ParentFarms,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_ParentSpecies, _formname = _str_ParentSpecies, _type = "List<VetFarmTree>",
              _get_func = o => o.ParentSpecies,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_ParentAnimals, _formname = _str_ParentAnimals, _type = "List<AsSessionAnimalSample>",
              _get_func = o => o.ParentAnimals,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_ParentAnimalsAll, _formname = _str_ParentAnimalsAll, _type = "List<AsSessionAnimalSample>",
              _get_func = o => o.ParentAnimalsAll,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_ParentAnimalsSamples, _formname = _str_ParentAnimalsSamples, _type = "List<AsSessionAnimalSample>",
              _get_func = o => o.ParentAnimalsSamples,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_Farms, _formname = _str_Farms, _type = "Lookup",
              _get_func = o => { if (o.Farms == null) return null; return o.Farms.idfFarm; },
              _set_func = (o, val) => { o.Farms = o.FarmsLookup.Where(c => c.idfFarm.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Farms, c);
                if (o.idfFarm != c.idfFarm || o.IsRIRPropChanged(_str_Farms, c) || bChangeLookupContent) {
                  m.Add(_str_Farms, o.ObjectIdent + _str_Farms, o.ObjectIdent2 + _str_Farms, o.ObjectIdent3 + _str_Farms, "Lookup", o.idfFarm == null ? "" : o.idfFarm.ToString(), o.IsReadOnly(_str_Farms), o.IsInvisible(_str_Farms), o.IsRequired(_str_Farms),
                  bChangeLookupContent ? o.FarmsLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Farms + "Lookup", _formname = _str_Farms + "Lookup", _type = "LookupContent",
              _get_func = o => o.FarmsLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Species, _formname = _str_Species, _type = "Lookup",
              _get_func = o => { if (o.Species == null) return null; return o.Species.idfParty; },
              _set_func = (o, val) => { o.Species = o.SpeciesLookup.Where(c => c.idfParty.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Species, c);
                if (o.idfSpecies != c.idfSpecies || o.IsRIRPropChanged(_str_Species, c) || bChangeLookupContent) {
                  m.Add(_str_Species, o.ObjectIdent + _str_Species, o.ObjectIdent2 + _str_Species, o.ObjectIdent3 + _str_Species, "Lookup", o.idfSpecies == null ? "" : o.idfSpecies.ToString(), o.IsReadOnly(_str_Species), o.IsInvisible(_str_Species), o.IsRequired(_str_Species),
                  bChangeLookupContent ? o.SpeciesLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Species + "Lookup", _formname = _str_Species + "Lookup", _type = "LookupContent",
              _get_func = o => o.SpeciesLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_AnimalGender, _formname = _str_AnimalGender, _type = "Lookup",
              _get_func = o => { if (o.AnimalGender == null) return null; return o.AnimalGender.idfsBaseReference; },
              _set_func = (o, val) => { o.AnimalGender = o.AnimalGenderLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_AnimalGender, c);
                if (o.idfsAnimalGender != c.idfsAnimalGender || o.IsRIRPropChanged(_str_AnimalGender, c) || bChangeLookupContent) {
                  m.Add(_str_AnimalGender, o.ObjectIdent + _str_AnimalGender, o.ObjectIdent2 + _str_AnimalGender, o.ObjectIdent3 + _str_AnimalGender, "Lookup", o.idfsAnimalGender == null ? "" : o.idfsAnimalGender.ToString(), o.IsReadOnly(_str_AnimalGender), o.IsInvisible(_str_AnimalGender), o.IsRequired(_str_AnimalGender),
                  bChangeLookupContent ? o.AnimalGenderLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_AnimalGender + "Lookup", _formname = _str_AnimalGender + "Lookup", _type = "LookupContent",
              _get_func = o => o.AnimalGenderLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_AnimalAge, _formname = _str_AnimalAge, _type = "Lookup",
              _get_func = o => { if (o.AnimalAge == null) return null; return o.AnimalAge.idfsReference; },
              _set_func = (o, val) => { o.AnimalAge = o.AnimalAgeLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_AnimalAge, c);
                if (o.idfsAnimalAge != c.idfsAnimalAge || o.IsRIRPropChanged(_str_AnimalAge, c) || bChangeLookupContent) {
                  m.Add(_str_AnimalAge, o.ObjectIdent + _str_AnimalAge, o.ObjectIdent2 + _str_AnimalAge, o.ObjectIdent3 + _str_AnimalAge, "Lookup", o.idfsAnimalAge == null ? "" : o.idfsAnimalAge.ToString(), o.IsReadOnly(_str_AnimalAge), o.IsInvisible(_str_AnimalAge), o.IsRequired(_str_AnimalAge),
                  bChangeLookupContent ? o.AnimalAgeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_AnimalAge + "Lookup", _formname = _str_AnimalAge + "Lookup", _type = "LookupContent",
              _get_func = o => o.AnimalAgeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_SpeciesType, _formname = _str_SpeciesType, _type = "Lookup",
              _get_func = o => { if (o.SpeciesType == null) return null; return o.SpeciesType.idfsBaseReference; },
              _set_func = (o, val) => { o.SpeciesType = o.SpeciesTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_SpeciesType, c);
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_SpeciesType, c) || bChangeLookupContent) {
                  m.Add(_str_SpeciesType, o.ObjectIdent + _str_SpeciesType, o.ObjectIdent2 + _str_SpeciesType, o.ObjectIdent3 + _str_SpeciesType, "Lookup", o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(), o.IsReadOnly(_str_SpeciesType), o.IsInvisible(_str_SpeciesType), o.IsRequired(_str_SpeciesType),
                  bChangeLookupContent ? o.SpeciesTypeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_SpeciesType + "Lookup", _formname = _str_SpeciesType + "Lookup", _type = "LookupContent",
              _get_func = o => o.SpeciesTypeLookup,
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
              _name = _str_Animals, _formname = _str_Animals + "_input", _type = "Lookup",
              _get_func = o => o.strAnimalCode,
              _set_func = (o, val) => { o.strAnimalCode = val; },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Animals, c);
                if (o.strAnimalCode != c.strAnimalCode || o.IsRIRPropChanged(_str_Animals, c) || bChangeLookupContent) {
                  m.Add(_str_Animals, o.ObjectIdent + _str_Animals, o.ObjectIdent2 + _str_Animals, o.ObjectIdent3 + _str_Animals, "Lookup", o.strAnimalCode == null ? "" : o.strAnimalCode.ToString(), o.IsReadOnly(_str_Animals), o.IsInvisible(_str_Animals), o.IsRequired(_str_Animals),
                  bChangeLookupContent ? o.AnimalsLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              },
            new field_info {
              _name = _str_Animals + "Lookup", _formname = _str_Animals + "Lookup", _type = "LookupContent",
              _get_func = o => o.AnimalsLookup,
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
            AsSessionAnimalSample obj = (AsSessionAnimalSample)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName("Farm")]
        [Relation(typeof(FarmPanel), eidss.model.Schema.FarmPanel._str_idfFarm, _str_idfFarm)]
        public FarmPanel Farms
        {
            get { return _Farms; }
            set 
            { 
                var oldVal = _Farms;
                _Farms = value;
                if (_Farms != oldVal)
                {
                    if (idfFarm != (_Farms == null
                            ? new Int64()
                            : (Int64)_Farms.idfFarm))
                        idfFarm = _Farms == null 
                            ? new Int64()
                            : (Int64)_Farms.idfFarm; 
                    OnPropertyChanged(_str_Farms); 
                }
            }
        }
        private FarmPanel _Farms;

        
        public List<FarmPanel> FarmsLookup
        {
            get 
            { 
                
                var ret = new List<FarmPanel>();
                
              
                if (ParentFarms != null)
                {
                    
                    ret.AddRange(ParentFarms
                    );
                }
                return ret;
            }
        }
            
        [LocalizedDisplayName("strHerdSpecies")]
        [Relation(typeof(VetFarmTree), eidss.model.Schema.VetFarmTree._str_idfParty, _str_idfSpecies)]
        public VetFarmTree Species
        {
            get { return _Species; }
            set 
            { 
                var oldVal = _Species;
                _Species = value;
                if (_Species != oldVal)
                {
                    if (idfSpecies != (_Species == null
                            ? new Int64?()
                            : (Int64?)_Species.idfParty))
                        idfSpecies = _Species == null 
                            ? new Int64?()
                            : (Int64?)_Species.idfParty; 
                    OnPropertyChanged(_str_Species); 
                }
            }
        }
        private VetFarmTree _Species;

        
        public List<VetFarmTree> SpeciesLookup
        {
            get 
            { 
                
                var ret = new List<VetFarmTree>();
                
              
                if (ParentSpecies != null)
                {
                    
                    ret.AddRange(ParentSpecies
                    );
                }
                return ret;
            }
        }
            [XmlIgnore]
        [LocalizedDisplayName(_str_Animals)]
        [Relation(typeof(AsSessionAnimalSample), eidss.model.Schema.AsSessionAnimalSample._str_strAnimalCode, _str_strAnimalCode)]
        public AsSessionAnimalSample Animals
        {
            get { return _Animals; }
            set 
            { 
                var oldVal = _Animals;
                _Animals = value;
                if (_Animals != oldVal)
                {
                    if (strAnimalCode != (_Animals == null
                            ? strAnimalCode
                            : (String)_Animals.strAnimalCode))
                        strAnimalCode = _Animals == null 
                            ? strAnimalCode
                            : (String)_Animals.strAnimalCode; 
                    OnPropertyChanged(_str_Animals); 
                }
            }
        }
        private AsSessionAnimalSample _Animals;

        
        private AsSessionAnimalSample _emptyAnimals;
        
        public List<AsSessionAnimalSample> AnimalsLookup
        {
            get 
            { 
                
                var ret = new List<AsSessionAnimalSample>();
                
              
                if (ParentAnimals != null)
                {
                    
                    if (IsNew && !ParentAnimals.Any(c => c.idfAnimal == this.idfAnimal))
                    {
                        ret.Add(this);
                    }
                    else
                    {
                        if (_emptyAnimals == null)
                        {
                            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                            {
                                _emptyAnimals = eidss.model.Schema.AsSessionAnimalSample.Accessor.Instance(null).CreateNewT(manager, this.Parent/* ?? this*/);
                                
                                new Action<AsSessionAnimalSample>(c => { c.LockNotifyChanges(); c.strAnimalCode = Resources.EidssMessages.Get("newAnimalRecord"); c.bIsLinkToNewAnimal = true; c.UnlockNotifyChanges(); })(_emptyAnimals);
                                
                            }
                        }
                        ret.Add(_emptyAnimals);
                    }
                    
                    ret.AddRange(ParentAnimals
                    );
                }
                return ret;
            }
        }
            
        [LocalizedDisplayName("strAnimalGender")]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAnimalGender)]
        public BaseReference AnimalGender
        {
            get { return _AnimalGender == null ? null : ((long)_AnimalGender.Key == 0 ? null : _AnimalGender); }
            set 
            { 
                var oldVal = _AnimalGender;
                _AnimalGender = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_AnimalGender != oldVal)
                {
                    if (idfsAnimalGender != (_AnimalGender == null
                            ? new Int64?()
                            : (Int64?)_AnimalGender.idfsBaseReference))
                        idfsAnimalGender = _AnimalGender == null 
                            ? new Int64?()
                            : (Int64?)_AnimalGender.idfsBaseReference; 
                    OnPropertyChanged(_str_AnimalGender); 
                }
            }
        }
        private BaseReference _AnimalGender;

        
        public BaseReferenceList AnimalGenderLookup
        {
            get { return _AnimalGenderLookup; }
        }
        private BaseReferenceList _AnimalGenderLookup = new BaseReferenceList("rftAnimalSex");
            
        [LocalizedDisplayName("strAnimalAge")]
        [Relation(typeof(AnimalAgeLookup), eidss.model.Schema.AnimalAgeLookup._str_idfsReference, _str_idfsAnimalAge)]
        public AnimalAgeLookup AnimalAge
        {
            get { return _AnimalAge == null ? null : ((long)_AnimalAge.Key == 0 ? null : _AnimalAge); }
            set 
            { 
                var oldVal = _AnimalAge;
                _AnimalAge = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_AnimalAge != oldVal)
                {
                    if (idfsAnimalAge != (_AnimalAge == null
                            ? new Int64?()
                            : (Int64?)_AnimalAge.idfsReference))
                        idfsAnimalAge = _AnimalAge == null 
                            ? new Int64?()
                            : (Int64?)_AnimalAge.idfsReference; 
                    OnPropertyChanged(_str_AnimalAge); 
                }
            }
        }
        private AnimalAgeLookup _AnimalAge;

        
        public List<AnimalAgeLookup> AnimalAgeLookup
        {
            get { return _AnimalAgeLookup; }
        }
        private List<AnimalAgeLookup> _AnimalAgeLookup = new List<AnimalAgeLookup>();
            
        [LocalizedDisplayName(_str_SpeciesType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSpeciesType)]
        public BaseReference SpeciesType
        {
            get { return _SpeciesType == null ? null : ((long)_SpeciesType.Key == 0 ? null : _SpeciesType); }
            set 
            { 
                var oldVal = _SpeciesType;
                _SpeciesType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SpeciesType != oldVal)
                {
                    if (idfsSpeciesType != (_SpeciesType == null
                            ? new Int64()
                            : (Int64)_SpeciesType.idfsBaseReference))
                        idfsSpeciesType = _SpeciesType == null 
                            ? new Int64()
                            : (Int64)_SpeciesType.idfsBaseReference; 
                    OnPropertyChanged(_str_SpeciesType); 
                }
            }
        }
        private BaseReference _SpeciesType;

        
        public BaseReferenceList SpeciesTypeLookup
        {
            get { return _SpeciesTypeLookup; }
        }
        private BaseReferenceList _SpeciesTypeLookup = new BaseReferenceList("rftSpeciesList");
            
        [LocalizedDisplayName("AsSessionTableViewItem.strSampleName")]
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
                            ? new Int64?()
                            : (Int64?)_SampleType.idfsReference))
                        idfsSampleType = _SampleType == null 
                            ? new Int64?()
                            : (Int64?)_SampleType.idfsReference; 
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
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Farms:
                    return new BvSelectList(FarmsLookup, eidss.model.Schema.FarmPanel._str_idfFarm, null, Farms, _str_idfFarm);
            
                case _str_Species:
                    return new BvSelectList(SpeciesLookup, eidss.model.Schema.VetFarmTree._str_idfParty, null, Species, _str_idfSpecies);
            
                case _str_Animals:
                    return new BvSelectList(AnimalsLookup, eidss.model.Schema.AsSessionAnimalSample._str_strAnimalCode, null, Animals, _str_strAnimalCode);
            
                case _str_AnimalGender:
                    return new BvSelectList(AnimalGenderLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AnimalGender, _str_idfsAnimalGender);
            
                case _str_AnimalAge:
                    return new BvSelectList(AnimalAgeLookup, eidss.model.Schema.AnimalAgeLookup._str_idfsReference, null, AnimalAge, _str_idfsAnimalAge);
            
                case _str_SpeciesType:
                    return new BvSelectList(SpeciesTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SpeciesType, _str_idfsSpeciesType);
            
                case _str_SampleType:
                    return new BvSelectList(SampleTypeLookup, eidss.model.Schema.SampleTypeForDiagnosisLookup._str_idfsReference, null, SampleType, _str_idfsSampleType);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strAnimalCodeReadonly)]
        public bool strAnimalCodeReadonly
        {
            get { return new Func<AsSessionAnimalSample, bool>(c => c.bSampleAccessioned)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_AnimalAgeReadonly)]
        public bool AnimalAgeReadonly
        {
            get { return new Func<AsSessionAnimalSample, bool>(c => false)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strColorReadonly)]
        public bool strColorReadonly
        {
            get { return new Func<AsSessionAnimalSample, bool>(c => false)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_AnimalGenderReadonly)]
        public bool AnimalGenderReadonly
        {
            get { return new Func<AsSessionAnimalSample, bool>(c => false)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strNameReadonly)]
        public bool strNameReadonly
        {
            get { return new Func<AsSessionAnimalSample, bool>(c => false)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strDescriptionReadonly)]
        public bool strDescriptionReadonly
        {
            get { return new Func<AsSessionAnimalSample, bool>(c => false)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_SampleTypeReadonly)]
        public bool SampleTypeReadonly
        {
            get { return new Func<AsSessionAnimalSample, bool>(c => c.bSampleAccessioned)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strFieldBarcodeReadonly)]
        public bool strFieldBarcodeReadonly
        {
            get { return new Func<AsSessionAnimalSample, bool>(c => c.bSampleAccessioned)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_datFieldCollectionDateReadonly)]
        public bool datFieldCollectionDateReadonly
        {
            get { return new Func<AsSessionAnimalSample, bool>(c => c.bSampleAccessioned)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_newAnimalName)]
        public string newAnimalName
        {
            get { return new Func<AsSessionAnimalSample, string>(c => "(new animal " + (c.ParentAnimalsAll.Count(i => i.strAnimalCode.StartsWith("(new")) + 1) + ")")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strAnimalAge)]
        public string strAnimalAge
        {
            get { return new Func<AsSessionAnimalSample, string>(c => c.AnimalAge == null ? "" : AnimalAge.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strAnimalGender)]
        public string strAnimalGender
        {
            get { return new Func<AsSessionAnimalSample, string>(c => c.AnimalGender == null ? "" : AnimalGender.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strSpeciesType)]
        public string strSpeciesType
        {
            get { return new Func<AsSessionAnimalSample, string>(c => c.SpeciesType == null ? "" : SpeciesType.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("AsSessionTableViewItem.strSampleName")]
        public string strSampleName
        {
            get { return new Func<AsSessionAnimalSample, string>(c => c.SampleType == null ? "" : SampleType.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strSampleNameAndFieldBarcode)]
        public string strSampleNameAndFieldBarcode
        {
            get { return new Func<AsSessionAnimalSample, string>(a => string.IsNullOrEmpty(a.strSampleName) ? "" : a.strSampleName + " / " + a.strFieldBarcode)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_ParentFarms)]
        public List<FarmPanel> ParentFarms
        {
            get { return new Func<AsSessionAnimalSample, List<FarmPanel>>(c => c.Parent == null ? new List<FarmPanel>() : (c.Parent as AsSession).ASFarmsDetails.Where(i => !i.IsMarkedToDelete).Select(i => i.Farm).ToList())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_ParentSpecies)]
        public List<VetFarmTree> ParentSpecies
        {
            get { return new Func<AsSessionAnimalSample, List<VetFarmTree>>(c => c.Parent == null ? new List<VetFarmTree>() : (c.Parent as AsSession).ASFarmsDetails.SingleOrDefault(i => i.idfFarm == c.idfFarm, farm => farm.Farm.FarmTree.Where(i => i.idfsPartyType == (long)PartyTypeEnum.Species && !i.IsMarkedToDelete && ( (c.Parent as AsSession).Diseases.Any(j => !j.IsMarkedToDelete && (!j.idfsSpeciesType.HasValue || j.idfsSpeciesType.Value == 0)) || (c.Parent as AsSession).Diseases.Any(j => !j.IsMarkedToDelete && j.idfsSpeciesType == i.idfsSpeciesTypeReference) || (c.Parent as AsSession).Diseases.Count(j => !j.IsMarkedToDelete) == 0 )).ToList()))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_ParentAnimals)]
        public List<AsSessionAnimalSample> ParentAnimals
        {
            get { return new Func<AsSessionAnimalSample, List<AsSessionAnimalSample>>(c => c.Parent == null ? new List<AsSessionAnimalSample>() : (c.Parent as AsSession).ASAnimalsSamples.Where(i => !i.IsMarkedToDelete && i.idfSpecies == c.idfSpecies).Distinct(new AnimalComparator()).ToList())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_ParentAnimalsAll)]
        public List<AsSessionAnimalSample> ParentAnimalsAll
        {
            get { return new Func<AsSessionAnimalSample, List<AsSessionAnimalSample>>(c => c.Parent == null ? new List<AsSessionAnimalSample>() : (c.Parent as AsSession).ASAnimalsSamples.Where(i => !i.IsMarkedToDelete).Distinct(new AnimalComparator()).ToList())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_ParentAnimalsSamples)]
        public List<AsSessionAnimalSample> ParentAnimalsSamples
        {
            get { return new Func<AsSessionAnimalSample, List<AsSessionAnimalSample>>(c => c.Parent == null ? new List<AsSessionAnimalSample>() : (c.Parent as AsSession).ASAnimalsSamples.Where(i => !i.IsMarkedToDelete).ToList())(this); }
            
        }
        
          [LocalizedDisplayName(_str_NumOfCopies)]
        public int NumOfCopies
        {
            get { return m_NumOfCopies; }
            set { if (m_NumOfCopies != value) { m_NumOfCopies = value; OnPropertyChanged(_str_NumOfCopies); } }
        }
        private int m_NumOfCopies;
        
          [LocalizedDisplayName(_str_SequenceNumber)]
        public int SequenceNumber
        {
            get { return m_SequenceNumber; }
            set { if (m_SequenceNumber != value) { m_SequenceNumber = value; OnPropertyChanged(_str_SequenceNumber); } }
        }
        private int m_SequenceNumber;
        
          [LocalizedDisplayName(_str_FilterByDiagnosis)]
        public bool FilterByDiagnosis
        {
            get { return m_FilterByDiagnosis; }
            set { if (m_FilterByDiagnosis != value) { m_FilterByDiagnosis = value; OnPropertyChanged(_str_FilterByDiagnosis); } }
        }
        private bool m_FilterByDiagnosis;
        
          [LocalizedDisplayName(_str_bIsLinkToNewAnimal)]
        public bool bIsLinkToNewAnimal
        {
            get { return m_bIsLinkToNewAnimal; }
            set { if (m_bIsLinkToNewAnimal != value) { m_bIsLinkToNewAnimal = value; OnPropertyChanged(_str_bIsLinkToNewAnimal); } }
        }
        private bool m_bIsLinkToNewAnimal;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AsSessionAnimalSample";

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
            var ret = base.Clone() as AsSessionAnimalSample;
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
            var ret = base.Clone() as AsSessionAnimalSample;
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
        public AsSessionAnimalSample CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AsSessionAnimalSample;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return id; } }
        public string KeyName { get { return "id"; } }
        public object KeyLookup { get { return id; } }
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
        
            var _prev_idfsAnimalGender_AnimalGender = idfsAnimalGender;
            var _prev_idfsAnimalAge_AnimalAge = idfsAnimalAge;
            var _prev_idfsSpeciesType_SpeciesType = idfsSpeciesType;
            var _prev_idfsSampleType_SampleType = idfsSampleType;
            base.RejectChanges();
        
            if (_prev_idfsAnimalGender_AnimalGender != idfsAnimalGender)
            {
                _AnimalGender = _AnimalGenderLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAnimalGender);
            }
            if (_prev_idfsAnimalAge_AnimalAge != idfsAnimalAge)
            {
                _AnimalAge = _AnimalAgeLookup.FirstOrDefault(c => c.idfsReference == idfsAnimalAge);
            }
            if (_prev_idfsSpeciesType_SpeciesType != idfsSpeciesType)
            {
                _SpeciesType = _SpeciesTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSpeciesType);
            }
            if (_prev_idfsSampleType_SampleType != idfsSampleType)
            {
                _SampleType = _SampleTypeLookup.FirstOrDefault(c => c.idfsReference == idfsSampleType);
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

        private bool IsRIRPropChanged(string fld, AsSessionAnimalSample c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, AsSessionAnimalSample c)
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
            return new Func<AsSessionAnimalSample, string>(a => a.strAnimalCode)(this);
        }
        

        public AsSessionAnimalSample()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AsSessionAnimalSample_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AsSessionAnimalSample_PropertyChanged);
        }
        private void AsSessionAnimalSample_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AsSessionAnimalSample).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_bSampleAccessioned)
                OnPropertyChanged(_str_strAnimalCodeReadonly);
                  
            if (e.PropertyName == _str_bSampleAccessioned)
                OnPropertyChanged(_str_AnimalAgeReadonly);
                  
            if (e.PropertyName == _str_bSampleAccessioned)
                OnPropertyChanged(_str_strColorReadonly);
                  
            if (e.PropertyName == _str_bSampleAccessioned)
                OnPropertyChanged(_str_AnimalGenderReadonly);
                  
            if (e.PropertyName == _str_bSampleAccessioned)
                OnPropertyChanged(_str_strNameReadonly);
                  
            if (e.PropertyName == _str_bSampleAccessioned)
                OnPropertyChanged(_str_strDescriptionReadonly);
                  
            if (e.PropertyName == _str_bSampleAccessioned)
                OnPropertyChanged(_str_SampleTypeReadonly);
                  
            if (e.PropertyName == _str_bSampleAccessioned)
                OnPropertyChanged(_str_strFieldBarcodeReadonly);
                  
            if (e.PropertyName == _str_bSampleAccessioned)
                OnPropertyChanged(_str_datFieldCollectionDateReadonly);
                  
            if (e.PropertyName == _str_idfsAnimalAge)
                OnPropertyChanged(_str_strAnimalAge);
                  
            if (e.PropertyName == _str_idfsAnimalGender)
                OnPropertyChanged(_str_strAnimalGender);
                  
            if (e.PropertyName == _str_idfsSpeciesType)
                OnPropertyChanged(_str_strSpeciesType);
                  
            if (e.PropertyName == _str_idfsSampleType)
                OnPropertyChanged(_str_strSampleName);
                  
            if (e.PropertyName == _str_idfsSampleType)
                OnPropertyChanged(_str_strSampleNameAndFieldBarcode);
                  
            if (e.PropertyName == _str_strFieldBarcode)
                OnPropertyChanged(_str_strSampleNameAndFieldBarcode);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_ParentFarms);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_ParentSpecies);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_ParentAnimals);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_ParentAnimalsAll);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_ParentAnimalsSamples);
                  
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
            AsSessionAnimalSample obj = this;
            try
            {
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, c => !c.bSampleAccessioned
                    );
            
                (new PredicateValidator("msgCantDeleteASSample", "", "", "",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, c => !(c.Parent as AsSession).CaseTests.Any(i => !i.IsMarkedToDelete && (i.idfMaterial == c.idfMaterial || i.idfMaterialAsSession == c.idfMaterial))
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
            AsSessionAnimalSample obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AsSessionAnimalSample obj = this;
            
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

    
        private static string[] readonly_names1 = "strSendToOffice".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "Farms,idfFarm,Species,idfSpecies,Animals,strAnimalCode,FilterByDiagnosis,SampleType,idfsSampleType".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "strFieldBarcode,datFieldCollectionDate,idfSendToOffice".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionAnimalSample, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionAnimalSample, bool>(c => c.bSampleAccessioned)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionAnimalSample, bool>(c => c.bSampleAccessioned || c.SampleType == null)(this);
            
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


        internal Dictionary<string, Func<AsSessionAnimalSample, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<AsSessionAnimalSample, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsSessionAnimalSample, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsSessionAnimalSample, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<AsSessionAnimalSample, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<AsSessionAnimalSample, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<AsSessionAnimalSample, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~AsSessionAnimalSample()
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
                
                if (_emptyAnimals != null)
                {
                    _emptyAnimals.Dispose();
                    _emptyAnimals = null;
                }
                  
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("FarmPanel", this);
                
                LookupManager.RemoveObject("VetFarmTree", this);
                
                LookupManager.RemoveObject("AsSessionAnimalSample", this);
                
                LookupManager.RemoveObject("rftAnimalSex", this);
                
                LookupManager.RemoveObject("AnimalAgeLookup", this);
                
                LookupManager.RemoveObject("rftSpeciesList", this);
                
                LookupManager.RemoveObject("SampleTypeForDiagnosisLookup", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftAnimalSex")
                _getAccessor().LoadLookup_AnimalGender(manager, this);
            
            if (lookup_object == "AnimalAgeLookup")
                _getAccessor().LoadLookup_AnimalAge(manager, this);
            
            if (lookup_object == "rftSpeciesList")
                _getAccessor().LoadLookup_SpeciesType(manager, this);
            
            if (lookup_object == "SampleTypeForDiagnosisLookup")
                _getAccessor().LoadLookup_SampleType(manager, this);
            
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
        public class AsSessionAnimalSampleGridModel : IGridModelItem, IGridModelItemSequence
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 id { get; set; }
        
            public Int64 idfsSpeciesType { get; set; }
        
            public int SequenceNumber { get; set; }
        
            public bool strAnimalCodeReadonly { get; set; }
        
            public bool AnimalAgeReadonly { get; set; }
        
            public bool strColorReadonly { get; set; }
        
            public bool AnimalGenderReadonly { get; set; }
        
            public bool strNameReadonly { get; set; }
        
            public bool strDescriptionReadonly { get; set; }
        
            public bool SampleTypeReadonly { get; set; }
        
            public bool strFieldBarcodeReadonly { get; set; }
        
            public bool datFieldCollectionDateReadonly { get; set; }
        
            public String strFarmCode { get; set; }
        
            public string strSpeciesType { get; set; }
        
            public String strAnimalCode { get; set; }
        [System.ComponentModel.DataAnnotations.UIHint("AnimalAgeEditor")]
            public AsSessionAnimalAge AnimalAge { get; set; }
        
            public String strColor { get; set; }
        [System.ComponentModel.DataAnnotations.UIHint("AnimalGenderEditor")]
            public AsSessionBaseReference AnimalGender { get; set; }
        
            public String strName { get; set; }
        
            public String strDescription { get; set; }
        [System.ComponentModel.DataAnnotations.UIHint("SampleTypeEditor")]
            public AsSessionSampleTypeForDiagnosis SampleType { get; set; }
        
            public String strFieldBarcode { get; set; }
        [System.ComponentModel.DataAnnotations.UIHint("FieldCollectionDateEditor")]
            public DateTime? datFieldCollectionDate { get; set; }
        
            public String strSendToOffice { get; set; }
        
        }
        public partial class AsSessionAnimalSampleGridModelList : List<AsSessionAnimalSampleGridModel>, IGridModelList, IGridModelListLoad, IGridModelListSequence
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public AsSessionAnimalSampleGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsSessionAnimalSample>, errMes);
            }
            public AsSessionAnimalSampleGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsSessionAnimalSample>, errMes);
            }
            public AsSessionAnimalSampleGridModelList(long key, IEnumerable<AsSessionAnimalSample> items)
            {
                LoadGridModelList(key, items, null);
            }
            public AsSessionAnimalSampleGridModelList(long key)
            {
                LoadGridModelList(key, new List<AsSessionAnimalSample>(), null);
            }
            partial void filter(List<AsSessionAnimalSample> items);
            private void LoadGridModelList(long key, IEnumerable<AsSessionAnimalSample> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_SequenceNumber,_str_strFarmCode,_str_strSpeciesType,_str_strAnimalCode,_str_AnimalAge,_str_strColor,_str_AnimalGender,_str_strName,_str_strDescription,_str_SampleType,_str_strFieldBarcode,_str_datFieldCollectionDate,_str_strSendToOffice};
                    
                Hiddens = new List<string> {_str_id,_str_idfsSpeciesType,_str_strAnimalCodeReadonly,_str_AnimalAgeReadonly,_str_strColorReadonly,_str_AnimalGenderReadonly,_str_strNameReadonly,_str_strDescriptionReadonly,_str_SampleTypeReadonly,_str_strFieldBarcodeReadonly,_str_datFieldCollectionDateReadonly};
                Keys = new List<string> {_str_id};
                Labels = new Dictionary<string, string> {{_str_SequenceNumber, _str_SequenceNumber},{_str_strFarmCode, _str_strFarmCode},{_str_strSpeciesType, _str_strSpeciesType},{_str_strAnimalCode, _str_strAnimalCode},{_str_AnimalAge, "strAnimalAge"},{_str_strColor, _str_strColor},{_str_AnimalGender, "strAnimalGender"},{_str_strName, "strAnimalName"},{_str_strDescription, "strComments"},{_str_SampleType, "AsSessionTableViewItem.strSampleName"},{_str_strFieldBarcode, "AsSessionTableViewItem.strFieldBarcode"},{_str_datFieldCollectionDate, _str_datFieldCollectionDate},{_str_strSendToOffice, "strSendToOrganization"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                AsSessionAnimalSample.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<AsSessionAnimalSample>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new AsSessionAnimalSampleGridModel()
                {
                    ItemKey=c.id,idfsSpeciesType=c.idfsSpeciesType,SequenceNumber=c.SequenceNumber,strAnimalCodeReadonly=c.strAnimalCodeReadonly,AnimalAgeReadonly=c.AnimalAgeReadonly,strColorReadonly=c.strColorReadonly,AnimalGenderReadonly=c.AnimalGenderReadonly,strNameReadonly=c.strNameReadonly,strDescriptionReadonly=c.strDescriptionReadonly,SampleTypeReadonly=c.SampleTypeReadonly,strFieldBarcodeReadonly=c.strFieldBarcodeReadonly,datFieldCollectionDateReadonly=c.datFieldCollectionDateReadonly,strFarmCode=c.strFarmCode,strSpeciesType=c.strSpeciesType,strAnimalCode=c.strAnimalCode,AnimalAge=c.AnimalAge,strColor=c.strColor,AnimalGender=c.AnimalGender,strName=c.strName,strDescription=c.strDescription,SampleType=c.SampleType,strFieldBarcode=c.strFieldBarcode,datFieldCollectionDate=c.datFieldCollectionDate,strSendToOffice=c.strSendToOffice
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
        : DataAccessor<AsSessionAnimalSample>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<AsSessionAnimalSample>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "id"; } }
            #endregion
        
            public delegate void on_action(AsSessionAnimalSample obj);
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
            private FarmPanel.Accessor FarmsAccessor { get { return eidss.model.Schema.FarmPanel.Accessor.Instance(m_CS); } }
            private VetFarmTree.Accessor SpeciesAccessor { get { return eidss.model.Schema.VetFarmTree.Accessor.Instance(m_CS); } }
            private AsSessionAnimalSample.Accessor AnimalsAccessor { get { return eidss.model.Schema.AsSessionAnimalSample.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AnimalGenderAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private AnimalAgeLookup.Accessor AnimalAgeAccessor { get { return eidss.model.Schema.AnimalAgeLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SpeciesTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private SampleTypeForDiagnosisLookup.Accessor SampleTypeAccessor { get { return eidss.model.Schema.SampleTypeForDiagnosisLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<AsSessionAnimalSample> SelectList(DbManagerProxy manager
                , Int64? idfMonitoringSession
                )
            {
                return _SelectList(manager
                    , idfMonitoringSession
                    , delegate(AsSessionAnimalSample obj)
                        {
                        }
                    , delegate(AsSessionAnimalSample obj)
                        {
                        }
                    );
            }

            

            public List<AsSessionAnimalSample> _SelectList(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfMonitoringSession
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<AsSessionAnimalSample> _SelectListInternal(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , on_action loading, on_action loaded
                )
            {
                AsSessionAnimalSample _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<AsSessionAnimalSample> objs = new List<AsSessionAnimalSample>();
                    sets[0] = new MapResultSet(typeof(AsSessionAnimalSample), objs);
                    
                    manager
                        .SetSpCommand("spASSessionAnimalsSamples_SelectDetail"
                            , manager.Parameter("@idfMonitoringSession", idfMonitoringSession)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsSessionAnimalSample obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj.FilterByDiagnosis = new Func<AsSessionAnimalSample, bool>(c => EidssUserContext.User.Options.Prefs.FilterByDiagnosis)(obj);
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AsSessionAnimalSample obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AsSessionAnimalSample _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                AsSessionAnimalSample obj = null;
                try
                {
                    obj = AsSessionAnimalSample.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.id = (new GetNewIDExtender<AsSessionAnimalSample>()).GetScalar(manager, obj, isFake);
                obj.idfAnimal = new Func<AsSessionAnimalSample, long>(c => c.id)(obj);
                obj.strAnimalCode = new Func<AsSessionAnimalSample, string>(c => c.newAnimalName)(obj);
                obj.idfMonitoringSession = new Func<AsSessionAnimalSample, long?>(c => Parent == null ? new long?() : (Parent as AsSession).idfMonitoringSession)(obj);
                obj.FilterByDiagnosis = new Func<AsSessionAnimalSample, bool>(c => EidssUserContext.User.Options.Prefs.FilterByDiagnosis)(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.Farms = new Func<AsSessionAnimalSample, FarmPanel>(c => c.FarmsLookup.Count() == 1 ? c.FarmsLookup.FirstOrDefault() : null)(obj);
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

            
            public AsSessionAnimalSample CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public AsSessionAnimalSample CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public AsSessionAnimalSample CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public AsSessionAnimalSample CreateCopyT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 2) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is AsSessionAnimalSample)) 
                    throw new TypeMismatchException("original", typeof(AsSessionAnimalSample));
                if (pars[1] != null && !(pars[1] is long?)) 
                    throw new TypeMismatchException("sampleType", typeof(long?));
                
                return CreateCopy(manager, Parent
                    , (AsSessionAnimalSample)pars[0]
                    , (long?)pars[1]
                    );
            }
            public IObject CreateCopy(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateCopyT(manager, Parent, pars);
            }
            public AsSessionAnimalSample CreateCopy(DbManagerProxy manager, IObject Parent
                , AsSessionAnimalSample original
                , long? sampleType
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                }
                    , obj =>
                {
                obj.Farms = new Func<AsSessionAnimalSample, FarmPanel>(c => original.Farms == null ? null : c.FarmsLookup.SingleOrDefault(i => i.idfFarm == original.Farms.idfFarm))(obj);
                obj.Species = new Func<AsSessionAnimalSample, VetFarmTree>(c => original.Species == null ? null : c.SpeciesLookup.SingleOrDefault(i => i.idfParty == original.Species.idfParty))(obj);
                obj.Animals = new Func<AsSessionAnimalSample, AsSessionAnimalSample>(c => c.AnimalsLookup.SingleOrDefault(i => i.idfAnimal == c.idfAnimal))(obj);
                obj.AnimalGender = new Func<AsSessionAnimalSample, BaseReference>(c => original.AnimalGender == null ? null : c.AnimalGenderLookup.SingleOrDefault(i => i.idfsBaseReference == original.AnimalGender.idfsBaseReference))(obj);
                obj.SpeciesType = new Func<AsSessionAnimalSample, BaseReference>(c => original.SpeciesType == null ? null : c.SpeciesTypeLookup.SingleOrDefault(i => i.idfsBaseReference == original.SpeciesType.idfsBaseReference))(obj);
                obj.AnimalAge = new Func<AsSessionAnimalSample, AnimalAgeLookup>(c => original.AnimalAge == null ? null : c.AnimalAgeLookup.SingleOrDefault(i => i.idfsReference == original.AnimalAge.idfsReference))(obj);
                obj.SampleType = new Func<AsSessionAnimalSample, SampleTypeForDiagnosisLookup>(c => c.SampleTypeLookup.SingleOrDefault(i => i.idfsReference == sampleType))(obj);
                obj.datFieldCollectionDate = original.datFieldCollectionDate;
                obj.idfSendToOffice = original.idfSendToOffice;
                obj.strSendToOffice = original.strSendToOffice;
                obj.id = new Func<AsSessionAnimalSample, long>(c => c.idfMaterial.HasValue ? c.idfMaterial.Value : c.idfAnimal)(obj);
                }
                );
            }
            
            private void _SetupChildHandlers(AsSessionAnimalSample obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AsSessionAnimalSample obj)
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
                    
                    };
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfFarm)
                        {
                    
                obj.Species = new Func<AsSessionAnimalSample, VetFarmTree>(c => c.SpeciesLookup.Count() == 1 ? c.SpeciesLookup.FirstOrDefault() : null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfFarm)
                        {
                    
                obj.strFarmCode = new Func<AsSessionAnimalSample, string>(c => c.Farms == null ? "" : c.Farms.strFarmCode)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfSpecies)
                        {
                    
                obj.Animals = (new SetScalarHandler()).Handler(obj,
                    obj.idfSpecies, obj.idfSpecies_Previous, obj.Animals,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfSpecies)
                        {
                    
                obj.SpeciesType = new Func<AsSessionAnimalSample, BaseReference>(c => c.SpeciesLookup.SingleOrDefault(i => i.idfParty == c.idfSpecies, i => i.SpeciesTypeLookup.FirstOrDefault(o => o.idfsBaseReference == i.idfsSpeciesTypeReference)))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSpeciesType)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_AnimalAge(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_FilterByDiagnosis)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_SampleType(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSpeciesType)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_SampleType(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSpeciesType)
                        {
                    
                obj.SampleType = new Func<AsSessionAnimalSample, SampleTypeForDiagnosisLookup>(c => 
                                (obj.Parent as AsSession).Diseases.Where(i => !i.IsMarkedToDelete && i.idfsSpeciesType == obj.idfsSpeciesType).Select(i => i.idfsSampleType).Distinct().Count() == 1
                                    ? c.SampleTypeLookup.FirstOrDefault(k => k.idfsReference == (obj.Parent as AsSession).Diseases.FirstOrDefault(i => !i.IsMarkedToDelete && i.idfsSpeciesType == obj.idfsSpeciesType, i => i.idfsSampleType))
                                    : null
                          )(obj);
                        }
                    
                        if (e.PropertyName == _str_strAnimalCode)
                        {
                    
              // check existing animal
              var animalExist = obj.AnimalsLookup.FirstOrDefault(i => i.strAnimalCode == obj.strAnimalCode && i.idfAnimal != obj.idfAnimal);
              if (animalExist == null && obj.bIsLinkToNewAnimal)
              {
                  animalExist = obj.AnimalsLookup.FirstOrDefault(i => i.bIsLinkToNewAnimal);
              }
              if (animalExist != null)
              {
                  if (obj.idfAnimal == animalExist.idfAnimal)
                  {
                      obj.LockNotifyChanges();
                      obj.Animals = obj;
                      obj.UnlockNotifyChanges();
                  }
                  else
                  {
                      obj.LockNotifyChanges();
                      var saveAnimalCode = obj.strAnimalCode;
                      var bChangedAnimalCode = (saveAnimalCode != Resources.EidssMessages.Get("newAnimalRecord"));
                      obj.Animals = animalExist;
                      if (animalExist.bIsLinkToNewAnimal)
                      {
                          animalExist.LockNotifyChanges();
                          animalExist.strAnimalCode = bChangedAnimalCode ? saveAnimalCode : obj.newAnimalName;
                          animalExist.UnlockNotifyChanges();
                          obj.strAnimalCode = animalExist.strAnimalCode;
                          obj.bIsLinkToNewAnimal = true;
                      }
                      obj.UnlockNotifyChanges();
                      obj.idfAnimal = animalExist.idfAnimal;
                  }
              }
              else
              {
                  obj.LockNotifyChanges();
                  obj.Animals = obj;
                  obj.UnlockNotifyChanges();
              }
              if (!obj.bIsLinkToNewAnimal)
              {
                  obj.ParentAnimalsSamples.ForEach(c => 
                    { 
                        if (c.idfAnimal == obj.idfAnimal && c.idfSpecies == obj.idfSpecies && c.strAnimalCode != obj.strAnimalCode) 
                            {
                                c.LockNotifyChanges();
                                c.strAnimalCode = obj.strAnimalCode; 
                                c.UnlockNotifyChanges();
                            }
                    });
              }

              /*
              var a = obj.AnimalsLookup.FirstOrDefault(i => i.strAnimalCode == obj.strAnimalCode_Previous);
              if (a == null)
                  a = obj;
                  //a = obj.AnimalsLookup.FirstOrDefault();
              if (a != null)
              {
                  a.LockNotifyChanges();
                  a.strAnimalCode = obj.strAnimalCode;
                  a.UnlockNotifyChanges();
              }
              obj.Animals = obj.AnimalsLookup.FirstOrDefault(i => i.strAnimalCode == obj.strAnimalCode);
              var idfAnimal = obj.AnimalsLookup.FirstOrDefault(i => i.strAnimalCode == obj.strAnimalCode, i => i.idfAnimal);
              if (obj.idfAnimal != idfAnimal)
                  obj.idfAnimal = idfAnimal;
              */
            
                        }
                    
                        if (e.PropertyName == _str_idfAnimal)
                        {
                    
                obj.AnimalAge = new Func<AsSessionAnimalSample, AnimalAgeLookup>(c => c.AnimalsLookup.FirstOrDefault(i => i.idfAnimal == c.idfAnimal, i => i.AnimalAge))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfAnimal)
                        {
                    
                obj.strColor = new Func<AsSessionAnimalSample, string>(c => c.AnimalsLookup.FirstOrDefault(i => i.idfAnimal == c.idfAnimal, i => i.strColor))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfAnimal)
                        {
                    
                obj.AnimalGender = new Func<AsSessionAnimalSample, BaseReference>(c => c.AnimalsLookup.FirstOrDefault(i => i.idfAnimal == c.idfAnimal, i => i.AnimalGender))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfAnimal)
                        {
                    
                obj.strName = new Func<AsSessionAnimalSample, string>(c => c.AnimalsLookup.FirstOrDefault(i => i.idfAnimal == c.idfAnimal, i => i.strName))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfAnimal)
                        {
                    
                obj.strDescription = new Func<AsSessionAnimalSample, string>(c => c.AnimalsLookup.FirstOrDefault(i => i.idfAnimal == c.idfAnimal, i => i.strDescription))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSampleType)
                        {
                    
                obj.idfMaterial = (new SetScalarHandler()).Handler(obj,
                    obj.idfsSampleType, obj.idfsSampleType_Previous, obj.idfMaterial,
                    (o, fld, prev_fld) => fld.HasValue ? (prev_fld.HasValue ? o.idfMaterial : ((new GetNewIDExtender<AsSessionAnimalSample>()).GetScalar(o))) : null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsSampleType)
                        {
                    
                obj.strFieldBarcode = new Func<AsSessionAnimalSample, string>(c => c.idfsSampleType.HasValue ? c.strFieldBarcode : "")(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSampleType)
                        {
                    
                obj.datFieldCollectionDate = new Func<AsSessionAnimalSample, DateTime?>(c => c.idfsSampleType.HasValue ? c.datFieldCollectionDate : null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSampleType)
                        {
                    
              if (!obj.idfsSampleType_Previous.HasValue || obj.idfsSampleType_Previous.Value == 0)
              {
                  if (obj.idfsSampleType.HasValue && obj.idfsSampleType.Value != 0)
                  {
                      if (!obj.idfSendToOffice.HasValue || obj.idfSendToOffice.Value == 0)
                      {
                          var lastSample = obj.ParentAnimalsSamples.OrderBy(c => c.id).LastOrDefault(c => c.idfSendToOffice.HasValue && c.idfSendToOffice.Value != 0);
                          if (lastSample != null)
                          {
                              obj.idfSendToOffice = lastSample.idfSendToOffice;
                              obj.strSendToOffice = lastSample.strSendToOffice;
                          }
                      }
                  }
              }
            
                        }
                    
                        if (e.PropertyName == _str_idfsAnimalAge)
                        {
                    
              obj.ParentAnimalsSamples.ForEach(c => { if (c.idfAnimal == obj.idfAnimal && c.idfsAnimalAge != obj.idfsAnimalAge) c.AnimalAge = c.AnimalAgeLookup.FirstOrDefault(i => i.idfsReference == obj.idfsAnimalAge); });
            
                        }
                    
                        if (e.PropertyName == _str_strColor)
                        {
                    
              obj.ParentAnimalsSamples.ForEach(c => { if (c.idfAnimal == obj.idfAnimal && c.strColor != obj.strColor) c.strColor = obj.strColor; });
            
                        }
                    
                        if (e.PropertyName == _str_idfsAnimalGender)
                        {
                    
              obj.ParentAnimalsSamples.ForEach(c => { if (c.idfAnimal == obj.idfAnimal && c.idfsAnimalGender != obj.idfsAnimalGender) c.AnimalGender = c.AnimalGenderLookup.FirstOrDefault(i => i.idfsBaseReference == obj.idfsAnimalGender); });
            
                        }
                    
                        if (e.PropertyName == _str_strName)
                        {
                    
              obj.ParentAnimalsSamples.ForEach(c => { if (c.idfAnimal == obj.idfAnimal && c.strName != obj.strName) c.strName = obj.strName; });
            
                        }
                    
                        if (e.PropertyName == _str_strDescription)
                        {
                    
              obj.ParentAnimalsSamples.ForEach(c => { if (c.idfAnimal == obj.idfAnimal && c.strDescription != obj.strDescription) c.strDescription = obj.strDescription; });
            
                        }
                    
                    };
                
            }
    
            public void LoadLookup_AnimalGender(DbManagerProxy manager, AsSessionAnimalSample obj)
            {
                
                obj.AnimalGenderLookup.Clear();
                
                obj.AnimalGenderLookup.Add(AnimalGenderAccessor.CreateNewT(manager, null));
                
                obj.AnimalGenderLookup.AddRange(AnimalGenderAccessor.rftAnimalSex_SelectList(manager
                    
                    )
                    .Where(c => ((c.intHACode.GetValueOrDefault() & (int)HACode.Livestock) != 0) || !c.intHACode.HasValue || c.idfsBaseReference == obj.idfsAnimalGender)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAnimalGender))
                    
                    .ToList());
                
                if (obj.idfsAnimalGender != null && obj.idfsAnimalGender != 0)
                {
                    obj.AnimalGender = obj.AnimalGenderLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsAnimalGender);
                    
                }
              
            }
            
            public void LoadLookup_AnimalAge(DbManagerProxy manager, AsSessionAnimalSample obj)
            {
                
                obj.AnimalAgeLookup.Clear();
                
                obj.AnimalAgeLookup.Add(AnimalAgeAccessor.CreateNewT(manager, null));
                
                obj.AnimalAgeLookup.AddRange(AnimalAgeAccessor.SelectLookupList(manager
                    
                    , new Func<AsSessionAnimalSample, string>(c => c.idfsSpeciesType.ToString())(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsAnimalAge))
                    
                    .ToList());
                
                if (obj.idfsAnimalAge != null && obj.idfsAnimalAge != 0)
                {
                    obj.AnimalAge = obj.AnimalAgeLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsAnimalAge);
                    
                }
              
            }
            
            public void LoadLookup_SpeciesType(DbManagerProxy manager, AsSessionAnimalSample obj)
            {
                
                obj.SpeciesTypeLookup.Clear();
                
                obj.SpeciesTypeLookup.Add(SpeciesTypeAccessor.CreateNewT(manager, null));
                
                obj.SpeciesTypeLookup.AddRange(SpeciesTypeAccessor.rftSpeciesList_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode.GetValueOrDefault() & ((int?)HACode.Livestock).GetValueOrDefault()) != 0 || c.idfsBaseReference == obj.idfsSpeciesType)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSpeciesType))
                    
                    .ToList());
                
                if (obj.idfsSpeciesType != 0)
                {
                    obj.SpeciesType = obj.SpeciesTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsSpeciesType);
                    
                }
              
            }
            
            public void LoadLookup_SampleType(DbManagerProxy manager, AsSessionAnimalSample obj)
            {
                
                obj.SampleTypeLookup.Clear();
                
                obj.SampleTypeLookup.Add(SampleTypeAccessor.CreateNewT(manager, null));
                
                obj.SampleTypeLookup.AddRange(SampleTypeAccessor.SelectLookupList(manager
                    
                    , null
                    )
                    .Where(c => (c.intHACode & (int)HACode.Livestock) != 0 || c.idfsReference == obj.idfsSampleType)
                        
                    .Where(c => (
                                (obj.Parent is AsSession) && (obj.Parent as AsSession).Diseases.Count(i => !i.IsMarkedToDelete && i.idfsSpeciesType == obj.idfsSpeciesType) > 0 && (obj.Parent as AsSession).Diseases.Count(i => !i.IsMarkedToDelete && i.idfsSpeciesType == obj.idfsSpeciesType && i.idfsSampleType.HasValue && i.idfsSampleType.Value != 0) == (obj.Parent as AsSession).Diseases.Count(i => !i.IsMarkedToDelete && i.idfsSpeciesType == obj.idfsSpeciesType)
                                ? (
                                      c.idfsDiagnosis == 0 && (obj.Parent as AsSession).Diseases.Any(i => !i.IsMarkedToDelete && (i.idfsSpeciesType == obj.idfsSpeciesType /*|| !i.idfsSpeciesType.HasValue || i.idfsSpeciesType.Value == 0*/) && i.idfsSampleType == c.idfsReference)
                                  )
                                : (
                                    !obj.FilterByDiagnosis ? 
                                    (
                                        c.idfsDiagnosis == 0
                                    )
                                    :
                                    (
                                        (obj.Parent is AsSession) && (obj.Parent as AsSession).Diseases
                                            .Where(i => !i.IsMarkedToDelete && (i.idfsSpeciesType == 0 || i.idfsSpeciesType == null || i.idfsSpeciesType == obj.idfsSpeciesType))
                                            .Any(i => i.idfsDiagnosis == c.idfsDiagnosis) 
                                    )
                                  )
                                ) || (c.idfsReference == obj.idfsSampleType)
                                )
                        
                    .Where(c => c.idfsReference != (long)SampleTypeEnum.Unknown)
                        
                    .Where(c => c.idfsReference != 0)
                        
                    .Distinct(new SampleTypeForDiagnosisLookupComparator())
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsSampleType))
                    
                    .ToList());
                
                if (obj.idfsSampleType != null && obj.idfsSampleType != 0)
                {
                    obj.SampleType = obj.SampleTypeLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsSampleType);
                    
                }
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, AsSessionAnimalSample obj)
            {
                
                LoadLookup_AnimalGender(manager, obj);
                
                LoadLookup_AnimalAge(manager, obj);
                
                LoadLookup_SpeciesType(manager, obj);
                
                LoadLookup_SampleType(manager, obj);
                
            }
    
            [SprocName("spASSessionTableView_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfAnimal", "strAnimalCode", "idfMaterial", "strFieldBarcode")] AsSessionAnimalSample obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfAnimal", "strAnimalCode", "idfMaterial", "strFieldBarcode")] AsSessionAnimalSample obj)
            {
                
                obj.LockNotifyChanges();
                try {
                
                _post(manager, Action, obj);
                
                } finally {
                  obj.UnlockNotifyChanges();
                }
                
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
                        AsSessionAnimalSample bo = obj as AsSessionAnimalSample;
                        
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
                        bSuccess = _PostNonTransaction(manager, obj as AsSessionAnimalSample, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AsSessionAnimalSample obj, bool bChildObject) 
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
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                                    
                    // posted extenters - begin
                obj.strFarmCode = new Func<AsSessionAnimalSample, string>(c => c.Farms == null ? "" : c.Farms.strFarmCode)(obj);
              obj.ParentAnimalsSamples.Where(c => c.idfAnimal == obj.idfAnimal && c.strAnimalCode.StartsWith("(new")).ToList().ForEach(t => { t.LockNotifyChanges(); t.strAnimalCode = obj.strAnimalCode; t.UnlockNotifyChanges(); });
            
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(AsSessionAnimalSample obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AsSessionAnimalSample obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(AsSessionAnimalSample obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<AsSessionAnimalSample>(obj, "datFieldCollectionDate", c => true, 
      obj.datFieldCollectionDate,
      obj.GetType(),
      false, listdatFieldCollectionDate => {
    listdatFieldCollectionDate.Add(
    new ChainsValidatorDateTime<AsSessionAnimalSample>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }).Process();
  
                }
                catch(ValidationModelException ex)
                {
                    return ex;
                }
                
                return null;
            }
            protected bool ChainsValidate(AsSessionAnimalSample obj, bool bRethrowException)
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
                return Validate(manager, obj as AsSessionAnimalSample, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsSessionAnimalSample obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "Farms", "Farms","Farm",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.Farms);
            
                (new RequiredValidator( "Species", "Species","strHerdSpecies",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.Species);
            
                (new RequiredValidator( "Animals", "Animals","strAnimalCode",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.Animals);
            
                (new RequiredValidator( "strAnimalCode", "strAnimalCode","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.strAnimalCode);
            
            (new CustomMandatoryFieldValidator("idfSendToOffice", "idfSendToOffice", "VetCaseSample.idfSendToOffice",
            ValidationEventType.Error
            )).Validate(obj, obj.idfSendToOffice, CustomMandatoryField.AsSessionSample_SentTo,
            c => c.idfsSampleType.HasValue && c.idfsSampleType.Value > 0);

          
            (new CustomMandatoryFieldValidator("strSendToOffice", "strSendToOffice", "VetCaseSample.idfSendToOffice",
            ValidationEventType.Error
            )).Validate(obj, obj.strSendToOffice, CustomMandatoryField.AsSessionSample_SentTo,
            c => c.idfsSampleType.HasValue && c.idfsSampleType.Value > 0);

          
                  
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
           
    
            private void _SetupRequired(AsSessionAnimalSample obj)
            {
            
                obj
                    .AddRequired("Farms", c => true);
                    
                obj
                    .AddRequired("Species", c => true);
                    
                obj
                    .AddRequired("Animals", c => true);
                    
                obj
                    .AddRequired("strAnimalCode", c => true);
                    
                  obj
                    .AddRequired("Animals", c => true);
                
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.AsSessionSample_SentTo) )
              {
                obj
                  .AddRequired("idfSendToOffice", c => c.idfsSampleType.HasValue && c.idfsSampleType.Value > 0);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.AsSessionSample_SentTo) )
              {
                obj
                  .AddRequired("strSendToOffice", c => c.idfsSampleType.HasValue && c.idfsSampleType.Value > 0);
                
                }
            
            }
    
    private void _SetupPersonalDataRestrictions(AsSessionAnimalSample obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AsSessionAnimalSample) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AsSessionAnimalSample) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AsSessionAnimalSampleDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spASSessionAnimalsSamples_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spASSessionTableView_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsSessionAnimalSample, bool>> RequiredByField = new Dictionary<string, Func<AsSessionAnimalSample, bool>>();
            public static Dictionary<string, Func<AsSessionAnimalSample, bool>> RequiredByProperty = new Dictionary<string, Func<AsSessionAnimalSample, bool>>();
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
                
                Sizes.Add(_str_strName, 200);
                Sizes.Add(_str_strColor, 200);
                Sizes.Add(_str_strDescription, 200);
                Sizes.Add(_str_strFarmCode, 200);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strSendToOffice, 2000);
                Sizes.Add(_str_strAnimalCode, 200);
                if (!RequiredByField.ContainsKey("Farms")) RequiredByField.Add("Farms", c => true);
                if (!RequiredByProperty.ContainsKey("Farms")) RequiredByProperty.Add("Farms", c => true);
                
                if (!RequiredByField.ContainsKey("Species")) RequiredByField.Add("Species", c => true);
                if (!RequiredByProperty.ContainsKey("Species")) RequiredByProperty.Add("Species", c => true);
                
                if (!RequiredByField.ContainsKey("Animals")) RequiredByField.Add("Animals", c => true);
                if (!RequiredByProperty.ContainsKey("Animals")) RequiredByProperty.Add("Animals", c => true);
                
                if (!RequiredByField.ContainsKey("strAnimalCode")) RequiredByField.Add("strAnimalCode", c => true);
                if (!RequiredByProperty.ContainsKey("strAnimalCode")) RequiredByProperty.Add("strAnimalCode", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_id,
                    _str_id, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsSpeciesType,
                    _str_idfsSpeciesType, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_SequenceNumber,
                    _str_SequenceNumber, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAnimalCodeReadonly,
                    _str_strAnimalCodeReadonly, null, false, false, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalAgeReadonly,
                    _str_AnimalAgeReadonly, null, false, false, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strColorReadonly,
                    _str_strColorReadonly, null, false, false, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalGenderReadonly,
                    _str_AnimalGenderReadonly, null, false, false, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNameReadonly,
                    _str_strNameReadonly, null, false, false, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDescriptionReadonly,
                    _str_strDescriptionReadonly, null, false, false, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_SampleTypeReadonly,
                    _str_SampleTypeReadonly, null, false, false, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcodeReadonly,
                    _str_strFieldBarcodeReadonly, null, false, false, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldCollectionDateReadonly,
                    _str_datFieldCollectionDateReadonly, null, false, false, true, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFarmCode,
                    _str_strFarmCode, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpeciesType,
                    _str_strSpeciesType, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAnimalCode,
                    _str_strAnimalCode, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalAge,
                    "strAnimalAge", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strColor,
                    _str_strColor, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalGender,
                    "strAnimalGender", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strName,
                    "strAnimalName", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDescription,
                    "strComments", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_SampleType,
                    "AsSessionTableViewItem.strSampleName", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode,
                    "AsSessionTableViewItem.strFieldBarcode", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldCollectionDate,
                    _str_datFieldCollectionDate, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSendToOffice,
                    "strSendToOrganization", null, true, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "CreateCopy",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateCopy(manager, c, pars)),
                        
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
                    (manager, c, pars) => ((AsSessionAnimalSample)c).MarkToDelete(),
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
	