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
    public abstract partial class AsSessionTableViewItem : 
        EditableObject<AsSessionTableViewItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_id), NonUpdatable, PrimaryKey]
        public abstract Int64 id { get; set; }
                
        [LocalizedDisplayName(_str_idfMonitoringSession)]
        [MapField(_str_idfMonitoringSession)]
        public abstract Int64 idfMonitoringSession { get; set; }
        #if MONO
        protected Int64 idfMonitoringSession_Original { get { return idfMonitoringSession; } }
        protected Int64 idfMonitoringSession_Previous { get { return idfMonitoringSession; } }
        #else
        protected Int64 idfMonitoringSession_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfMonitoringSession).OriginalValue; } }
        protected Int64 idfMonitoringSession_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfMonitoringSession).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfFarm)]
        [MapField(_str_idfFarm)]
        public abstract Int64 idfFarm { get; set; }
        #if MONO
        protected Int64 idfFarm_Original { get { return idfFarm; } }
        protected Int64 idfFarm_Previous { get { return idfFarm; } }
        #else
        protected Int64 idfFarm_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfFarm).OriginalValue; } }
        protected Int64 idfFarm_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfFarm).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfFarmActual)]
        [MapField(_str_idfFarmActual)]
        public abstract Int64? idfFarmActual { get; set; }
        #if MONO
        protected Int64? idfFarmActual_Original { get { return idfFarmActual; } }
        protected Int64? idfFarmActual_Previous { get { return idfFarmActual; } }
        #else
        protected Int64? idfFarmActual_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFarmActual).OriginalValue; } }
        protected Int64? idfFarmActual_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFarmActual).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfHerd)]
        [MapField(_str_idfHerd)]
        public abstract Int64? idfHerd { get; set; }
        #if MONO
        protected Int64? idfHerd_Original { get { return idfHerd; } }
        protected Int64? idfHerd_Previous { get { return idfHerd; } }
        #else
        protected Int64? idfHerd_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHerd).OriginalValue; } }
        protected Int64? idfHerd_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHerd).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strHerdCode)]
        [MapField(_str_strHerdCode)]
        public abstract String strHerdCode { get; set; }
        #if MONO
        protected String strHerdCode_Original { get { return strHerdCode; } }
        protected String strHerdCode_Previous { get { return strHerdCode; } }
        #else
        protected String strHerdCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strHerdCode).OriginalValue; } }
        protected String strHerdCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHerdCode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfAnimal)]
        [MapField(_str_idfAnimal)]
        public abstract Int64? idfAnimal { get; set; }
        #if MONO
        protected Int64? idfAnimal_Original { get { return idfAnimal; } }
        protected Int64? idfAnimal_Previous { get { return idfAnimal; } }
        #else
        protected Int64? idfAnimal_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAnimal).OriginalValue; } }
        protected Int64? idfAnimal_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAnimal).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("AsSessionTableViewItem.AnimalAge")]
        [MapField(_str_idfsAnimalAge)]
        public abstract Int64? idfsAnimalAge { get; set; }
        #if MONO
        protected Int64? idfsAnimalAge_Original { get { return idfsAnimalAge; } }
        protected Int64? idfsAnimalAge_Previous { get { return idfsAnimalAge; } }
        #else
        protected Int64? idfsAnimalAge_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalAge).OriginalValue; } }
        protected Int64? idfsAnimalAge_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalAge).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsAnimalGender)]
        [MapField(_str_idfsAnimalGender)]
        public abstract Int64? idfsAnimalGender { get; set; }
        #if MONO
        protected Int64? idfsAnimalGender_Original { get { return idfsAnimalGender; } }
        protected Int64? idfsAnimalGender_Previous { get { return idfsAnimalGender; } }
        #else
        protected Int64? idfsAnimalGender_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalGender).OriginalValue; } }
        protected Int64? idfsAnimalGender_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalGender).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfSpecies)]
        [MapField(_str_idfSpecies)]
        public abstract Int64? idfSpecies { get; set; }
        #if MONO
        protected Int64? idfSpecies_Original { get { return idfSpecies; } }
        protected Int64? idfSpecies_Previous { get { return idfSpecies; } }
        #else
        protected Int64? idfSpecies_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).OriginalValue; } }
        protected Int64? idfSpecies_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strName)]
        [MapField(_str_strName)]
        public abstract String strName { get; set; }
        #if MONO
        protected String strName_Original { get { return strName; } }
        protected String strName_Previous { get { return strName; } }
        #else
        protected String strName_Original { get { return ((EditableValue<String>)((dynamic)this)._strName).OriginalValue; } }
        protected String strName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strColor)]
        [MapField(_str_strColor)]
        public abstract String strColor { get; set; }
        #if MONO
        protected String strColor_Original { get { return strColor; } }
        protected String strColor_Previous { get { return strColor; } }
        #else
        protected String strColor_Original { get { return ((EditableValue<String>)((dynamic)this)._strColor).OriginalValue; } }
        protected String strColor_Previous { get { return ((EditableValue<String>)((dynamic)this)._strColor).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfMaterial)]
        [MapField(_str_idfMaterial)]
        public abstract Int64? idfMaterial { get; set; }
        #if MONO
        protected Int64? idfMaterial_Original { get { return idfMaterial; } }
        protected Int64? idfMaterial_Previous { get { return idfMaterial; } }
        #else
        protected Int64? idfMaterial_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMaterial).OriginalValue; } }
        protected Int64? idfMaterial_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMaterial).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("AsSessionTableViewItem.SampleType")]
        [MapField(_str_idfsSpecimenType)]
        public abstract Int64? idfsSpecimenType { get; set; }
        #if MONO
        protected Int64? idfsSpecimenType_Original { get { return idfsSpecimenType; } }
        protected Int64? idfsSpecimenType_Previous { get { return idfsSpecimenType; } }
        #else
        protected Int64? idfsSpecimenType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpecimenType).OriginalValue; } }
        protected Int64? idfsSpecimenType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpecimenType).PreviousValue; } }
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
                
        [LocalizedDisplayName("AsSessionTableViewItem.strFieldBarcode")]
        [MapField(_str_strFieldBarcode)]
        public abstract String strFieldBarcode { get; set; }
        #if MONO
        protected String strFieldBarcode_Original { get { return strFieldBarcode; } }
        protected String strFieldBarcode_Previous { get { return strFieldBarcode; } }
        #else
        protected String strFieldBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).OriginalValue; } }
        protected String strFieldBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("AsSessionTableViewItem.strSpecimenName")]
        [MapField(_str_strSpecimenName)]
        public abstract String strSpecimenName { get; set; }
        #if MONO
        protected String strSpecimenName_Original { get { return strSpecimenName; } }
        protected String strSpecimenName_Previous { get { return strSpecimenName; } }
        #else
        protected String strSpecimenName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSpecimenName).OriginalValue; } }
        protected String strSpecimenName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSpecimenName).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_blnNewFarm)]
        [MapField(_str_blnNewFarm)]
        public abstract Boolean? blnNewFarm { get; set; }
        #if MONO
        protected Boolean? blnNewFarm_Original { get { return blnNewFarm; } }
        protected Boolean? blnNewFarm_Previous { get { return blnNewFarm; } }
        #else
        protected Boolean? blnNewFarm_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnNewFarm).OriginalValue; } }
        protected Boolean? blnNewFarm_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnNewFarm).PreviousValue; } }
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
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<AsSessionTableViewItem, object> _get_func;
            internal Action<AsSessionTableViewItem, string> _set_func;
            internal Action<AsSessionTableViewItem, AsSessionTableViewItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_id = "id";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_idfFarm = "idfFarm";
        internal const string _str_strFarmCode = "strFarmCode";
        internal const string _str_idfFarmActual = "idfFarmActual";
        internal const string _str_idfsSpeciesType = "idfsSpeciesType";
        internal const string _str_idfHerd = "idfHerd";
        internal const string _str_strHerdCode = "strHerdCode";
        internal const string _str_idfAnimal = "idfAnimal";
        internal const string _str_idfsAnimalAge = "idfsAnimalAge";
        internal const string _str_idfsAnimalGender = "idfsAnimalGender";
        internal const string _str_strAnimalCode = "strAnimalCode";
        internal const string _str_idfSpecies = "idfSpecies";
        internal const string _str_strName = "strName";
        internal const string _str_strColor = "strColor";
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_idfsSpecimenType = "idfsSpecimenType";
        internal const string _str_idfParty = "idfParty";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_strSpecimenName = "strSpecimenName";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_blnNewFarm = "blnNewFarm";
        internal const string _str_SpeciesName = "SpeciesName";
        internal const string _str_Used = "Used";
        internal const string _str_AnimalName = "AnimalName";
        internal const string _str_strAnimalAge = "strAnimalAge";
        internal const string _str_strAnimalGender = "strAnimalGender";
        internal const string _str_strSpeciesType = "strSpeciesType";
        internal const string _str_ASAnimals = "ASAnimals";
        internal const string _str_ASFarms = "ASFarms";
        internal const string _str_ASSpecies = "ASSpecies";
        internal const string _str_ASSamples = "ASSamples";
        internal const string _str_CaseTests = "CaseTests";
        internal const string _str_Animal = "Animal";
        internal const string _str_Farm = "Farm";
        internal const string _str_Sample = "Sample";
        internal const string _str_AnimalGender = "AnimalGender";
        internal const string _str_AnimalAge = "AnimalAge";
        internal const string _str_SampleType = "SampleType";
        internal const string _str_SpeciesType = "SpeciesType";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_id, _type = "Int64",
              _get_func = o => o.id,
              _set_func = (o, val) => { o.id = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.id != c.id || o.IsRIRPropChanged(_str_id, c)) 
                  m.Add(_str_id, o.ObjectIdent + _str_id, "Int64", o.id == null ? "" : o.id.ToString(), o.IsReadOnly(_str_id), o.IsInvisible(_str_id), o.IsRequired(_str_id)); }
              }, 
        
            new field_info {
              _name = _str_idfMonitoringSession, _type = "Int64",
              _get_func = o => o.idfMonitoringSession,
              _set_func = (o, val) => { o.idfMonitoringSession = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfMonitoringSession != c.idfMonitoringSession || o.IsRIRPropChanged(_str_idfMonitoringSession, c)) 
                  m.Add(_str_idfMonitoringSession, o.ObjectIdent + _str_idfMonitoringSession, "Int64", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_idfMonitoringSession), o.IsInvisible(_str_idfMonitoringSession), o.IsRequired(_str_idfMonitoringSession)); }
              }, 
        
            new field_info {
              _name = _str_idfFarm, _type = "Int64",
              _get_func = o => o.idfFarm,
              _set_func = (o, val) => { o.idfFarm = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfFarm != c.idfFarm || o.IsRIRPropChanged(_str_idfFarm, c)) 
                  m.Add(_str_idfFarm, o.ObjectIdent + _str_idfFarm, "Int64", o.idfFarm == null ? "" : o.idfFarm.ToString(), o.IsReadOnly(_str_idfFarm), o.IsInvisible(_str_idfFarm), o.IsRequired(_str_idfFarm)); }
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
              _name = _str_idfFarmActual, _type = "Int64?",
              _get_func = o => o.idfFarmActual,
              _set_func = (o, val) => { o.idfFarmActual = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfFarmActual != c.idfFarmActual || o.IsRIRPropChanged(_str_idfFarmActual, c)) 
                  m.Add(_str_idfFarmActual, o.ObjectIdent + _str_idfFarmActual, "Int64?", o.idfFarmActual == null ? "" : o.idfFarmActual.ToString(), o.IsReadOnly(_str_idfFarmActual), o.IsInvisible(_str_idfFarmActual), o.IsRequired(_str_idfFarmActual)); }
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
              _name = _str_idfHerd, _type = "Int64?",
              _get_func = o => o.idfHerd,
              _set_func = (o, val) => { o.idfHerd = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfHerd != c.idfHerd || o.IsRIRPropChanged(_str_idfHerd, c)) 
                  m.Add(_str_idfHerd, o.ObjectIdent + _str_idfHerd, "Int64?", o.idfHerd == null ? "" : o.idfHerd.ToString(), o.IsReadOnly(_str_idfHerd), o.IsInvisible(_str_idfHerd), o.IsRequired(_str_idfHerd)); }
              }, 
        
            new field_info {
              _name = _str_strHerdCode, _type = "String",
              _get_func = o => o.strHerdCode,
              _set_func = (o, val) => { o.strHerdCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strHerdCode != c.strHerdCode || o.IsRIRPropChanged(_str_strHerdCode, c)) 
                  m.Add(_str_strHerdCode, o.ObjectIdent + _str_strHerdCode, "String", o.strHerdCode == null ? "" : o.strHerdCode.ToString(), o.IsReadOnly(_str_strHerdCode), o.IsInvisible(_str_strHerdCode), o.IsRequired(_str_strHerdCode)); }
              }, 
        
            new field_info {
              _name = _str_idfAnimal, _type = "Int64?",
              _get_func = o => o.idfAnimal,
              _set_func = (o, val) => { o.idfAnimal = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfAnimal != c.idfAnimal || o.IsRIRPropChanged(_str_idfAnimal, c)) 
                  m.Add(_str_idfAnimal, o.ObjectIdent + _str_idfAnimal, "Int64?", o.idfAnimal == null ? "" : o.idfAnimal.ToString(), o.IsReadOnly(_str_idfAnimal), o.IsInvisible(_str_idfAnimal), o.IsRequired(_str_idfAnimal)); }
              }, 
        
            new field_info {
              _name = _str_idfsAnimalAge, _type = "Int64?",
              _get_func = o => o.idfsAnimalAge,
              _set_func = (o, val) => { o.idfsAnimalAge = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalAge != c.idfsAnimalAge || o.IsRIRPropChanged(_str_idfsAnimalAge, c)) 
                  m.Add(_str_idfsAnimalAge, o.ObjectIdent + _str_idfsAnimalAge, "Int64?", o.idfsAnimalAge == null ? "" : o.idfsAnimalAge.ToString(), o.IsReadOnly(_str_idfsAnimalAge), o.IsInvisible(_str_idfsAnimalAge), o.IsRequired(_str_idfsAnimalAge)); }
              }, 
        
            new field_info {
              _name = _str_idfsAnimalGender, _type = "Int64?",
              _get_func = o => o.idfsAnimalGender,
              _set_func = (o, val) => { o.idfsAnimalGender = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalGender != c.idfsAnimalGender || o.IsRIRPropChanged(_str_idfsAnimalGender, c)) 
                  m.Add(_str_idfsAnimalGender, o.ObjectIdent + _str_idfsAnimalGender, "Int64?", o.idfsAnimalGender == null ? "" : o.idfsAnimalGender.ToString(), o.IsReadOnly(_str_idfsAnimalGender), o.IsInvisible(_str_idfsAnimalGender), o.IsRequired(_str_idfsAnimalGender)); }
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
              _name = _str_idfSpecies, _type = "Int64?",
              _get_func = o => o.idfSpecies,
              _set_func = (o, val) => { o.idfSpecies = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSpecies != c.idfSpecies || o.IsRIRPropChanged(_str_idfSpecies, c)) 
                  m.Add(_str_idfSpecies, o.ObjectIdent + _str_idfSpecies, "Int64?", o.idfSpecies == null ? "" : o.idfSpecies.ToString(), o.IsReadOnly(_str_idfSpecies), o.IsInvisible(_str_idfSpecies), o.IsRequired(_str_idfSpecies)); }
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
              _name = _str_strColor, _type = "String",
              _get_func = o => o.strColor,
              _set_func = (o, val) => { o.strColor = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strColor != c.strColor || o.IsRIRPropChanged(_str_strColor, c)) 
                  m.Add(_str_strColor, o.ObjectIdent + _str_strColor, "String", o.strColor == null ? "" : o.strColor.ToString(), o.IsReadOnly(_str_strColor), o.IsInvisible(_str_strColor), o.IsRequired(_str_strColor)); }
              }, 
        
            new field_info {
              _name = _str_idfMaterial, _type = "Int64?",
              _get_func = o => o.idfMaterial,
              _set_func = (o, val) => { o.idfMaterial = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfMaterial != c.idfMaterial || o.IsRIRPropChanged(_str_idfMaterial, c)) 
                  m.Add(_str_idfMaterial, o.ObjectIdent + _str_idfMaterial, "Int64?", o.idfMaterial == null ? "" : o.idfMaterial.ToString(), o.IsReadOnly(_str_idfMaterial), o.IsInvisible(_str_idfMaterial), o.IsRequired(_str_idfMaterial)); }
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
              _name = _str_idfParty, _type = "Int64?",
              _get_func = o => o.idfParty,
              _set_func = (o, val) => { o.idfParty = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_idfParty, c)) 
                  m.Add(_str_idfParty, o.ObjectIdent + _str_idfParty, "Int64?", o.idfParty == null ? "" : o.idfParty.ToString(), o.IsReadOnly(_str_idfParty), o.IsInvisible(_str_idfParty), o.IsRequired(_str_idfParty)); }
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
              _name = _str_strFieldBarcode, _type = "String",
              _get_func = o => o.strFieldBarcode,
              _set_func = (o, val) => { o.strFieldBarcode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFieldBarcode != c.strFieldBarcode || o.IsRIRPropChanged(_str_strFieldBarcode, c)) 
                  m.Add(_str_strFieldBarcode, o.ObjectIdent + _str_strFieldBarcode, "String", o.strFieldBarcode == null ? "" : o.strFieldBarcode.ToString(), o.IsReadOnly(_str_strFieldBarcode), o.IsInvisible(_str_strFieldBarcode), o.IsRequired(_str_strFieldBarcode)); }
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
              _name = _str_strBarcode, _type = "String",
              _get_func = o => o.strBarcode,
              _set_func = (o, val) => { o.strBarcode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strBarcode != c.strBarcode || o.IsRIRPropChanged(_str_strBarcode, c)) 
                  m.Add(_str_strBarcode, o.ObjectIdent + _str_strBarcode, "String", o.strBarcode == null ? "" : o.strBarcode.ToString(), o.IsReadOnly(_str_strBarcode), o.IsInvisible(_str_strBarcode), o.IsRequired(_str_strBarcode)); }
              }, 
        
            new field_info {
              _name = _str_blnNewFarm, _type = "Boolean?",
              _get_func = o => o.blnNewFarm,
              _set_func = (o, val) => { o.blnNewFarm = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnNewFarm != c.blnNewFarm || o.IsRIRPropChanged(_str_blnNewFarm, c)) 
                  m.Add(_str_blnNewFarm, o.ObjectIdent + _str_blnNewFarm, "Boolean?", o.blnNewFarm == null ? "" : o.blnNewFarm.ToString(), o.IsReadOnly(_str_blnNewFarm), o.IsInvisible(_str_blnNewFarm), o.IsRequired(_str_blnNewFarm)); }
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
              _name = _str_Used, _type = "Int32",
              _get_func = o => o.Used,
              _set_func = (o, val) => { o.Used = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.Used != c.Used || o.IsRIRPropChanged(_str_Used, c)) 
                  m.Add(_str_Used, o.ObjectIdent + _str_Used, "Int32", o.Used == null ? "" : o.Used.ToString(), o.IsReadOnly(_str_Used), o.IsInvisible(_str_Used), o.IsRequired(_str_Used)); }
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
              _name = _str_ASAnimals, _type = "EditableList<AsSessionAnimal>",
              _get_func = o => o.ASAnimals,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_ASFarms, _type = "EditableList<AsSessionFarm>",
              _get_func = o => o.ASFarms,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_ASSpecies, _type = "EditableList<AsSessionFarmSpeciesListItem>",
              _get_func = o => o.ASSpecies,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_ASSamples, _type = "EditableList<AsSessionSample>",
              _get_func = o => o.ASSamples,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_CaseTests, _type = "EditableList<CaseTest>",
              _get_func = o => o.CaseTests,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_strAnimalAge, _type = "string",
              _get_func = o => o.strAnimalAge,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strAnimalAge != c.strAnimalAge || o.IsRIRPropChanged(_str_strAnimalAge, c)) 
                  m.Add(_str_strAnimalAge, o.ObjectIdent + _str_strAnimalAge, "string", o.strAnimalAge == null ? "" : o.strAnimalAge.ToString(), o.IsReadOnly(_str_strAnimalAge), o.IsInvisible(_str_strAnimalAge), o.IsRequired(_str_strAnimalAge));
                 }
              }, 
        
            new field_info {
              _name = _str_strAnimalGender, _type = "string",
              _get_func = o => o.strAnimalGender,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strAnimalGender != c.strAnimalGender || o.IsRIRPropChanged(_str_strAnimalGender, c)) 
                  m.Add(_str_strAnimalGender, o.ObjectIdent + _str_strAnimalGender, "string", o.strAnimalGender == null ? "" : o.strAnimalGender.ToString(), o.IsReadOnly(_str_strAnimalGender), o.IsInvisible(_str_strAnimalGender), o.IsRequired(_str_strAnimalGender));
                 }
              }, 
        
            new field_info {
              _name = _str_strSpeciesType, _type = "string",
              _get_func = o => o.strSpeciesType,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strSpeciesType != c.strSpeciesType || o.IsRIRPropChanged(_str_strSpeciesType, c)) 
                  m.Add(_str_strSpeciesType, o.ObjectIdent + _str_strSpeciesType, "string", o.strSpeciesType == null ? "" : o.strSpeciesType.ToString(), o.IsReadOnly(_str_strSpeciesType), o.IsInvisible(_str_strSpeciesType), o.IsRequired(_str_strSpeciesType));
                 }
              }, 
        
            new field_info {
              _name = _str_Animal, _type = "AsSessionAnimal",
              _get_func = o => o.Animal,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_Farm, _type = "FarmPanel",
              _get_func = o => o.Farm,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_Sample, _type = "AsSessionSample",
              _get_func = o => o.Sample,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_AnimalGender, _type = "Lookup",
              _get_func = o => { if (o.AnimalGender == null) return null; return o.AnimalGender.idfsBaseReference; },
              _set_func = (o, val) => { o.AnimalGender = o.AnimalGenderLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalGender != c.idfsAnimalGender || o.IsRIRPropChanged(_str_AnimalGender, c)) 
                  m.Add(_str_AnimalGender, o.ObjectIdent + _str_AnimalGender, "Lookup", o.idfsAnimalGender == null ? "" : o.idfsAnimalGender.ToString(), o.IsReadOnly(_str_AnimalGender), o.IsInvisible(_str_AnimalGender), o.IsRequired(_str_AnimalGender)); }
              }, 
        
            new field_info {
              _name = _str_AnimalAge, _type = "Lookup",
              _get_func = o => { if (o.AnimalAge == null) return null; return o.AnimalAge.idfsReference; },
              _set_func = (o, val) => { o.AnimalAge = o.AnimalAgeLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalAge != c.idfsAnimalAge || o.IsRIRPropChanged(_str_AnimalAge, c)) 
                  m.Add(_str_AnimalAge, o.ObjectIdent + _str_AnimalAge, "Lookup", o.idfsAnimalAge == null ? "" : o.idfsAnimalAge.ToString(), o.IsReadOnly(_str_AnimalAge), o.IsInvisible(_str_AnimalAge), o.IsRequired(_str_AnimalAge)); }
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
              _name = _str_SpeciesType, _type = "Lookup",
              _get_func = o => { if (o.SpeciesType == null) return null; return o.SpeciesType.idfsBaseReference; },
              _set_func = (o, val) => { o.SpeciesType = o.SpeciesTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_SpeciesType, c)) 
                  m.Add(_str_SpeciesType, o.ObjectIdent + _str_SpeciesType, "Lookup", o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(), o.IsReadOnly(_str_SpeciesType), o.IsInvisible(_str_SpeciesType), o.IsRequired(_str_SpeciesType)); }
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
            AsSessionTableViewItem obj = (AsSessionTableViewItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAnimalGender)]
        public BaseReference AnimalGender
        {
            get { return _AnimalGender == null ? null : ((long)_AnimalGender.Key == 0 ? null : _AnimalGender); }
            set 
            { 
                _AnimalGender = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAnimalGender = _AnimalGender == null 
                    ? new Int64?()
                    : _AnimalGender.idfsBaseReference; 
                OnPropertyChanged(_str_AnimalGender); 
            }
        }
        private BaseReference _AnimalGender;

        
        public BaseReferenceList AnimalGenderLookup
        {
            get { return _AnimalGenderLookup; }
        }
        private BaseReferenceList _AnimalGenderLookup = new BaseReferenceList("rftAnimalGenderList");
            
        [Relation(typeof(AnimalAgeLookup), eidss.model.Schema.AnimalAgeLookup._str_idfsReference, _str_idfsAnimalAge)]
        public AnimalAgeLookup AnimalAge
        {
            get { return _AnimalAge == null ? null : ((long)_AnimalAge.Key == 0 ? null : _AnimalAge); }
            set 
            { 
                _AnimalAge = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAnimalAge = _AnimalAge == null 
                    ? new Int64?()
                    : _AnimalAge.idfsReference; 
                OnPropertyChanged(_str_AnimalAge); 
            }
        }
        private AnimalAgeLookup _AnimalAge;

        
        public List<AnimalAgeLookup> AnimalAgeLookup
        {
            get { return _AnimalAgeLookup; }
        }
        private List<AnimalAgeLookup> _AnimalAgeLookup = new List<AnimalAgeLookup>();
            
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
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSpeciesType)]
        public BaseReference SpeciesType
        {
            get { return _SpeciesType == null ? null : ((long)_SpeciesType.Key == 0 ? null : _SpeciesType); }
            set 
            { 
                _SpeciesType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsSpeciesType = _SpeciesType == null 
                    ? new Int64?()
                    : _SpeciesType.idfsBaseReference; 
                OnPropertyChanged(_str_SpeciesType); 
            }
        }
        private BaseReference _SpeciesType;

        
        public BaseReferenceList SpeciesTypeLookup
        {
            get { return _SpeciesTypeLookup; }
        }
        private BaseReferenceList _SpeciesTypeLookup = new BaseReferenceList("rftSpeciesList");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_AnimalGender:
                    return new BvSelectList(AnimalGenderLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AnimalGender, _str_idfsAnimalGender);
            
                case _str_AnimalAge:
                    return new BvSelectList(AnimalAgeLookup, eidss.model.Schema.AnimalAgeLookup._str_idfsReference, null, AnimalAge, _str_idfsAnimalAge);
            
                case _str_SampleType:
                    return new BvSelectList(SampleTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SampleType, _str_idfsSpecimenType);
            
                case _str_SpeciesType:
                    return new BvSelectList(SpeciesTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SpeciesType, _str_idfsSpeciesType);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strAnimalAge)]
        public string strAnimalAge
        {
            get { return new Func<AsSessionTableViewItem, string>(c=>c.AnimalAge == null? "" : AnimalAge.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strAnimalGender)]
        public string strAnimalGender
        {
            get { return new Func<AsSessionTableViewItem, string>(c=>c.AnimalGender == null? "" : AnimalGender.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strSpeciesType)]
        public string strSpeciesType
        {
            get { return new Func<AsSessionTableViewItem, string>(c=>c.SpeciesType == null? "" : SpeciesType.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Animal)]
        public AsSessionAnimal Animal
        {
            get { return new Func<AsSessionTableViewItem, AsSessionAnimal>(c=>(c.ASAnimals == null || c.ASAnimals.Count == 0  || !c.idfAnimal.HasValue) ? null : c.ASAnimals.Single(x=>x.idfAnimal == c.idfAnimal))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Farm)]
        public FarmPanel Farm
        {
            get { return new Func<AsSessionTableViewItem, FarmPanel>(c=>(c.ASFarms == null || c.ASFarms.Count == 0 || c.idfFarm == 0) ? null : c.ASFarms.Single(x=>x.idfFarm == c.idfFarm).Farm)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Sample)]
        public AsSessionSample Sample
        {
            get { return new Func<AsSessionTableViewItem, AsSessionSample>(c=>(c.ASSamples == null || c.ASSamples.Count == 0 || !c.idfMaterial.HasValue) ? null : c.ASSamples.Single(x=>x.idfMaterial == c.idfMaterial))(this); }
            
        }
        
          [LocalizedDisplayName(_str_ASAnimals)]
        public EditableList<AsSessionAnimal> ASAnimals
        {
            get { return m_ASAnimals; }
            set { if (m_ASAnimals != value) { m_ASAnimals = value; OnPropertyChanged(_str_ASAnimals); } }
        }
        private EditableList<AsSessionAnimal> m_ASAnimals;
        
          [LocalizedDisplayName(_str_ASFarms)]
        public EditableList<AsSessionFarm> ASFarms
        {
            get { return m_ASFarms; }
            set { if (m_ASFarms != value) { m_ASFarms = value; OnPropertyChanged(_str_ASFarms); } }
        }
        private EditableList<AsSessionFarm> m_ASFarms;
        
          [LocalizedDisplayName(_str_ASSpecies)]
        public EditableList<AsSessionFarmSpeciesListItem> ASSpecies
        {
            get { return m_ASSpecies; }
            set { if (m_ASSpecies != value) { m_ASSpecies = value; OnPropertyChanged(_str_ASSpecies); } }
        }
        private EditableList<AsSessionFarmSpeciesListItem> m_ASSpecies;
        
          [LocalizedDisplayName(_str_ASSamples)]
        public EditableList<AsSessionSample> ASSamples
        {
            get { return m_ASSamples; }
            set { if (m_ASSamples != value) { m_ASSamples = value; OnPropertyChanged(_str_ASSamples); } }
        }
        private EditableList<AsSessionSample> m_ASSamples;
        
          [LocalizedDisplayName(_str_CaseTests)]
        public EditableList<CaseTest> CaseTests
        {
            get { return m_CaseTests; }
            set { if (m_CaseTests != value) { m_CaseTests = value; OnPropertyChanged(_str_CaseTests); } }
        }
        private EditableList<CaseTest> m_CaseTests;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AsSessionTableViewItem";

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
            var ret = base.Clone() as AsSessionTableViewItem;
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
            var ret = base.Clone() as AsSessionTableViewItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public AsSessionTableViewItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AsSessionTableViewItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return id; } }
        public string KeyName { get { return "id"; } }
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
        
            var _prev_idfsAnimalGender_AnimalGender = idfsAnimalGender;
            var _prev_idfsAnimalAge_AnimalAge = idfsAnimalAge;
            var _prev_idfsSpecimenType_SampleType = idfsSpecimenType;
            var _prev_idfsSpeciesType_SpeciesType = idfsSpeciesType;
            base.RejectChanges();
        
            if (_prev_idfsAnimalGender_AnimalGender != idfsAnimalGender)
            {
                _AnimalGender = _AnimalGenderLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAnimalGender);
            }
            if (_prev_idfsAnimalAge_AnimalAge != idfsAnimalAge)
            {
                _AnimalAge = _AnimalAgeLookup.FirstOrDefault(c => c.idfsReference == idfsAnimalAge);
            }
            if (_prev_idfsSpecimenType_SampleType != idfsSpecimenType)
            {
                _SampleType = _SampleTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSpecimenType);
            }
            if (_prev_idfsSpeciesType_SpeciesType != idfsSpeciesType)
            {
                _SpeciesType = _SpeciesTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSpeciesType);
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

      private bool IsRIRPropChanged(string fld, AsSessionTableViewItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public AsSessionTableViewItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AsSessionTableViewItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AsSessionTableViewItem_PropertyChanged);
        }
        private void AsSessionTableViewItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AsSessionTableViewItem).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfsAnimalAge)
                OnPropertyChanged(_str_strAnimalAge);
                  
            if (e.PropertyName == _str_idfsAnimalGender)
                OnPropertyChanged(_str_strAnimalGender);
                  
            if (e.PropertyName == _str_idfsSpeciesType)
                OnPropertyChanged(_str_strSpeciesType);
                  
            if (e.PropertyName == _str_idfAnimal)
                OnPropertyChanged(_str_Animal);
                  
            if (e.PropertyName == _str_idfFarm)
                OnPropertyChanged(_str_Farm);
                  
            if (e.PropertyName == _str_idfMaterial)
                OnPropertyChanged(_str_Sample);
                  
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
            AsSessionTableViewItem obj = this;
            try
            {
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.CaseTests.Where(i => !i.IsMarkedToDelete && i.idfContainerAsSession == c.idfMaterial).Count() == 0
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
            AsSessionTableViewItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AsSessionTableViewItem obj = this;
            
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

    
        private static string[] readonly_names1 = "idfSpecies".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "idfAnimal,AnimalAge,strColor,AnimalGender,strName,SampleType".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "strFieldBarcode,datFieldCollectionDate".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionTableViewItem, bool>(c=>c.Farm == null)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionTableViewItem, bool>(c=>c.idfSpecies == null)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionTableViewItem, bool>(c=>c.SampleType==null)(this);
            
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


        public Dictionary<string, Func<AsSessionTableViewItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsSessionTableViewItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsSessionTableViewItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<AsSessionTableViewItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<AsSessionTableViewItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<AsSessionTableViewItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AsSessionTableViewItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftAnimalGenderList", this);
                
                LookupManager.RemoveObject("AnimalAgeLookup", this);
                
                LookupManager.RemoveObject("rftSpecimenType", this);
                
                LookupManager.RemoveObject("rftSpeciesList", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftAnimalGenderList")
                _getAccessor().LoadLookup_AnimalGender(manager, this);
            
            if (lookup_object == "AnimalAgeLookup")
                _getAccessor().LoadLookup_AnimalAge(manager, this);
            
            if (lookup_object == "rftSpecimenType")
                _getAccessor().LoadLookup_SampleType(manager, this);
            
            if (lookup_object == "rftSpeciesList")
                _getAccessor().LoadLookup_SpeciesType(manager, this);
            
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
        public class AsSessionTableViewItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 id { get; set; }
        
            public String strFarmCode { get; set; }
        
            public string strSpeciesType { get; set; }
        
            public String strAnimalCode { get; set; }
        
            public string strAnimalAge { get; set; }
        
            public String strColor { get; set; }
        
            public string strAnimalGender { get; set; }
        
            public String strName { get; set; }
        
            public String strSpecimenName { get; set; }
        
            public String strFieldBarcode { get; set; }
        
            public DateTime? datFieldCollectionDate { get; set; }
        
            public Int64 idfFarm { get; set; }
        
        }
        public partial class AsSessionTableViewItemGridModelList : List<AsSessionTableViewItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public AsSessionTableViewItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsSessionTableViewItem>, errMes);
            }
            public AsSessionTableViewItemGridModelList(long key, IEnumerable<AsSessionTableViewItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<AsSessionTableViewItem> items);
            private void LoadGridModelList(long key, IEnumerable<AsSessionTableViewItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strFarmCode,_str_strSpeciesType,_str_strAnimalCode,_str_strAnimalAge,_str_strColor,_str_strAnimalGender,_str_strName,_str_strSpecimenName,_str_strFieldBarcode,_str_datFieldCollectionDate};
                    
                Hiddens = new List<string> {_str_id,_str_idfFarm};
                Keys = new List<string> {_str_id};
                Labels = new Dictionary<string, string> {{_str_strFarmCode, _str_strFarmCode},{_str_strSpeciesType, _str_strSpeciesType},{_str_strAnimalCode, _str_strAnimalCode},{_str_strAnimalAge, _str_strAnimalAge},{_str_strColor, _str_strColor},{_str_strAnimalGender, _str_strAnimalGender},{_str_strName, _str_strName},{_str_strSpecimenName, "AsSessionTableViewItem.strSpecimenName"},{_str_strFieldBarcode, "AsSessionTableViewItem.strFieldBarcode"},{_str_datFieldCollectionDate, _str_datFieldCollectionDate}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<AsSessionTableViewItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new AsSessionTableViewItemGridModel()
                {
                    ItemKey=c.id,strFarmCode=c.strFarmCode,strSpeciesType=c.strSpeciesType,strAnimalCode=c.strAnimalCode,strAnimalAge=c.strAnimalAge,strColor=c.strColor,strAnimalGender=c.strAnimalGender,strName=c.strName,strSpecimenName=c.strSpecimenName,strFieldBarcode=c.strFieldBarcode,datFieldCollectionDate=c.datFieldCollectionDate,idfFarm=c.idfFarm
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
        : DataAccessor<AsSessionTableViewItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(AsSessionTableViewItem obj);
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
            private BaseReference.Accessor AnimalGenderAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private AnimalAgeLookup.Accessor AnimalAgeAccessor { get { return eidss.model.Schema.AnimalAgeLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SampleTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SpeciesTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<AsSessionTableViewItem> SelectList(DbManagerProxy manager
                , Int64? idfMonitoringSession
                )
            {
                return _SelectList(manager
                    , idfMonitoringSession
                    , delegate(AsSessionTableViewItem obj)
                        {
                        }
                    , delegate(AsSessionTableViewItem obj)
                        {
                        }
                    );
            }

            
            private List<AsSessionTableViewItem> _SelectList(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<AsSessionTableViewItem> objs = new List<AsSessionTableViewItem>();
                    sets[0] = new MapResultSet(typeof(AsSessionTableViewItem), objs);
                    
                    manager
                        .SetSpCommand("spASSessionTableView_SelectDetail"
                            , manager.Parameter("@idfMonitoringSession", idfMonitoringSession)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsSessionTableViewItem obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AsSessionTableViewItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AsSessionTableViewItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    AsSessionTableViewItem obj = AsSessionTableViewItem.CreateInstance();
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

            
            public AsSessionTableViewItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public AsSessionTableViewItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public AsSessionTableViewItem CreateFromSessionT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is AsSession)) 
                    throw new TypeMismatchException("session", typeof(AsSession));
                
                return CreateFromSession(manager, Parent
                    , (AsSession)pars[0]
                    );
            }
            public IObject CreateFromSession(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateFromSessionT(manager, Parent, pars);
            }
            public AsSessionTableViewItem CreateFromSession(DbManagerProxy manager, IObject Parent
                , AsSession session
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfMonitoringSession = session.idfMonitoringSession;
                obj.ASFarms = session.ASFarms;
                obj.ASSpecies = session.ASSpecies;
                obj.ASAnimals = session.ASAnimals;
                obj.ASSamples = session.ASSamples;
                obj.CaseTests = session.CaseTests;
                }
                    , obj =>
                {
                }
                );
            }
            
            public AsSessionTableViewItem CreateCopyT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is AsSessionTableViewItem)) 
                    throw new TypeMismatchException("original", typeof(AsSessionTableViewItem));
                if (pars[1] != null && !(pars[1] is long?)) 
                    throw new TypeMismatchException("idfAnimal", typeof(long?));
                if (pars[2] != null && !(pars[2] is long?)) 
                    throw new TypeMismatchException("idfMaterial", typeof(long?));
                
                return CreateCopy(manager, Parent
                    , (AsSessionTableViewItem)pars[0]
                    , (long?)pars[1]
                    , (long?)pars[2]
                    );
            }
            public IObject CreateCopy(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateCopyT(manager, Parent, pars);
            }
            public AsSessionTableViewItem CreateCopy(DbManagerProxy manager, IObject Parent
                , AsSessionTableViewItem original
                , long? idfAnimal
                , long? idfMaterial
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfMonitoringSession = original.idfMonitoringSession;
                obj.ASFarms = original.ASFarms;
                obj.ASSpecies = original.ASSpecies;
                obj.ASAnimals = original.ASAnimals;
                obj.ASSamples = original.ASSamples;
                obj.CaseTests = original.CaseTests;
                obj.idfFarm = original.idfFarm;
                obj.idfSpecies = original.idfSpecies;
                obj.SpeciesType = original.SpeciesType;
                obj.idfAnimal = idfAnimal;
                obj.idfMaterial = idfMaterial;
                obj.id = idfMaterial.HasValue ? idfMaterial.Value : idfAnimal.Value;
                obj.UpdateLineFarm();
                if (obj.idfAnimal.HasValue)
                  obj.UpdateLineAnimal();
                if (obj.idfMaterial.HasValue)
                  obj.UpdateLineSample();
              
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(AsSessionTableViewItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AsSessionTableViewItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsSpeciesType)
                        {
                    
                obj.AnimalAge = (new SetScalarHandler()).Handler(obj,
                    obj.idfsSpeciesType, obj.idfsSpeciesType_Previous, obj.AnimalAge,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsSpeciesType)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_AnimalAge(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfAnimal)
                        {
                    
              if (obj.Animal != null)
              {
                obj.UpdateLineAnimal();       
              }
            
                        }
                    
                        if (e.PropertyName == _str_idfMaterial)
                        {
                    
              if (obj.Sample != null)
              {
              obj.UpdateLineSample();
              }
            
                        }
                    
                        if (e.PropertyName == _str_idfFarm)
                        {
                    
              if (obj.Farm != null)
              {
              obj.UpdateLineFarm();
              }
            
                        }
                    
                        if (e.PropertyName == _str_SampleType)
                        {
                    
                obj.strSpecimenName = new Func<AsSessionTableViewItem, string>(c=>c.SampleType == null ? "" : c.SampleType.name)(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_AnimalGender(DbManagerProxy manager, AsSessionTableViewItem obj)
            {
                
                obj.AnimalGenderLookup.Clear();
                
                obj.AnimalGenderLookup.Add(AnimalGenderAccessor.CreateNewT(manager, null));
                
                obj.AnimalGenderLookup.AddRange(AnimalGenderAccessor.rftAnimalGenderList_SelectList(manager
                    
                    )
                    .Where(c => ((c.intHACode.GetValueOrDefault() & (int)HACode.Livestock) != 0) || !c.intHACode.HasValue)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAnimalGender))
                    
                    .ToList());
                
                if (obj.idfsAnimalGender != null && obj.idfsAnimalGender != 0)
                {
                    obj.AnimalGender = obj.AnimalGenderLookup
                        .Where(c => c.idfsBaseReference == obj.idfsAnimalGender)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftAnimalGenderList", obj, AnimalGenderAccessor.GetType(), "rftAnimalGenderList_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_AnimalAge(DbManagerProxy manager, AsSessionTableViewItem obj)
            {
                
                obj.AnimalAgeLookup.Clear();
                
                obj.AnimalAgeLookup.Add(AnimalAgeAccessor.CreateNewT(manager, null));
                
                obj.AnimalAgeLookup.AddRange(AnimalAgeAccessor.SelectLookupList(manager
                    
                    , new Func<AsSessionTableViewItem, string>(c => c.idfsSpeciesType.ToString())(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsAnimalAge))
                    
                    .ToList());
                
                if (obj.idfsAnimalAge != null && obj.idfsAnimalAge != 0)
                {
                    obj.AnimalAge = obj.AnimalAgeLookup
                        .Where(c => c.idfsReference == obj.idfsAnimalAge)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("AnimalAgeLookup", obj, AnimalAgeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_SampleType(DbManagerProxy manager, AsSessionTableViewItem obj)
            {
                
                obj.SampleTypeLookup.Clear();
                
                obj.SampleTypeLookup.Add(SampleTypeAccessor.CreateNewT(manager, null));
                
                obj.SampleTypeLookup.AddRange(SampleTypeAccessor.rftSpecimenType_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode & (int)HACode.Livestock) != 0)
                        
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
            
            public void LoadLookup_SpeciesType(DbManagerProxy manager, AsSessionTableViewItem obj)
            {
                
                obj.SpeciesTypeLookup.Clear();
                
                obj.SpeciesTypeLookup.Add(SpeciesTypeAccessor.CreateNewT(manager, null));
                
                obj.SpeciesTypeLookup.AddRange(SpeciesTypeAccessor.rftSpeciesList_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode.GetValueOrDefault() & ((int?)HACode.Livestock).GetValueOrDefault()) != 0 || c.idfsBaseReference == obj.idfsSpeciesType)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSpeciesType))
                    
                    .ToList());
                
                if (obj.idfsSpeciesType != null && obj.idfsSpeciesType != 0)
                {
                    obj.SpeciesType = obj.SpeciesTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsSpeciesType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftSpeciesList", obj, SpeciesTypeAccessor.GetType(), "rftSpeciesList_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, AsSessionTableViewItem obj)
            {
                
                LoadLookup_AnimalGender(manager, obj);
                
                LoadLookup_AnimalAge(manager, obj);
                
                LoadLookup_SampleType(manager, obj);
                
                LoadLookup_SpeciesType(manager, obj);
                
            }
    
            [SprocName("spASSessionTableView_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfAnimal", "strAnimalCode", "strName", "strColor", "idfMaterial", "strFieldBarcode")] AsSessionTableViewItem obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfAnimal", "strAnimalCode", "strName", "strColor", "idfMaterial", "strFieldBarcode")] AsSessionTableViewItem obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    AsSessionTableViewItem bo = obj as AsSessionTableViewItem;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as AsSessionTableViewItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AsSessionTableViewItem obj, bool bChildObject) 
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
            //  if (obj.blnNewFarm.Value)
              //  FarmAccessor.Post(manager, obj.Farm);
            
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(AsSessionTableViewItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AsSessionTableViewItem obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as AsSessionTableViewItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsSessionTableViewItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfFarm", "idfFarm","idfFarm",
                false
              )).Validate(c => true, obj, obj.idfFarm);
            
                (new PredicateValidator("ErrMandatoryFieldRequired", "idfFarm", "idfFarm", "idfFarm",
              new object[] {
              },
                        false
                    )).Validate(obj, c=>c.idfFarm > 0
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
           
    
            private void _SetupRequired(AsSessionTableViewItem obj)
            {
            
                obj
                    .AddRequired("idfFarm", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(AsSessionTableViewItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AsSessionTableViewItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AsSessionTableViewItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AsSessionTableViewItemDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spASSessionTableView_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spASSessionTableView_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsSessionTableViewItem, bool>> RequiredByField = new Dictionary<string, Func<AsSessionTableViewItem, bool>>();
            public static Dictionary<string, Func<AsSessionTableViewItem, bool>> RequiredByProperty = new Dictionary<string, Func<AsSessionTableViewItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strFarmCode, 200);
                Sizes.Add(_str_strHerdCode, 200);
                Sizes.Add(_str_strAnimalCode, 200);
                Sizes.Add(_str_strName, 200);
                Sizes.Add(_str_strColor, 200);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strSpecimenName, 2000);
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_SpeciesName, 2000);
                Sizes.Add(_str_AnimalName, 200);
                if (!RequiredByField.ContainsKey("idfFarm")) RequiredByField.Add("idfFarm", c => true);
                if (!RequiredByProperty.ContainsKey("idfFarm")) RequiredByProperty.Add("idfFarm", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_id,
                    _str_id, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFarmCode,
                    _str_strFarmCode, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpeciesType,
                    _str_strSpeciesType, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAnimalCode,
                    _str_strAnimalCode, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAnimalAge,
                    _str_strAnimalAge, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strColor,
                    _str_strColor, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAnimalGender,
                    _str_strAnimalGender, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strName,
                    _str_strName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpecimenName,
                    "AsSessionTableViewItem.strSpecimenName", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode,
                    "AsSessionTableViewItem.strFieldBarcode", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldCollectionDate,
                    _str_datFieldCollectionDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfFarm,
                    _str_idfFarm, null, false, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "CreateFromSession",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateFromSession(manager, c, pars)),
                        
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
                    (manager, c, pars) => ((AsSessionTableViewItem)c).MarkToDelete(),
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
	