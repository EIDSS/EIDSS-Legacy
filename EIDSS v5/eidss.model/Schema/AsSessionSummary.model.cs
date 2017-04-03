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
    public abstract partial class AsSessionSummary : 
        EditableObject<AsSessionSummary>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfMonitoringSessionSummary), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMonitoringSessionSummary { get; set; }
                
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
                
        [LocalizedDisplayName(_str_strSpecies)]
        [MapField(_str_strSpecies)]
        public abstract String strSpecies { get; set; }
        #if MONO
        protected String strSpecies_Original { get { return strSpecies; } }
        protected String strSpecies_Previous { get { return strSpecies; } }
        #else
        protected String strSpecies_Original { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).OriginalValue; } }
        protected String strSpecies_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsAnimalSex)]
        [MapField(_str_idfsAnimalSex)]
        public abstract Int64? idfsAnimalSex { get; set; }
        #if MONO
        protected Int64? idfsAnimalSex_Original { get { return idfsAnimalSex; } }
        protected Int64? idfsAnimalSex_Previous { get { return idfsAnimalSex; } }
        #else
        protected Int64? idfsAnimalSex_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalSex).OriginalValue; } }
        protected Int64? idfsAnimalSex_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalSex).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intSampledAnimalsQty)]
        [MapField(_str_intSampledAnimalsQty)]
        public abstract Int32? intSampledAnimalsQty { get; set; }
        #if MONO
        protected Int32? intSampledAnimalsQty_Original { get { return intSampledAnimalsQty; } }
        protected Int32? intSampledAnimalsQty_Previous { get { return intSampledAnimalsQty; } }
        #else
        protected Int32? intSampledAnimalsQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intSampledAnimalsQty).OriginalValue; } }
        protected Int32? intSampledAnimalsQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intSampledAnimalsQty).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intSamplesQty)]
        [MapField(_str_intSamplesQty)]
        public abstract Int32? intSamplesQty { get; set; }
        #if MONO
        protected Int32? intSamplesQty_Original { get { return intSamplesQty; } }
        protected Int32? intSamplesQty_Previous { get { return intSamplesQty; } }
        #else
        protected Int32? intSamplesQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intSamplesQty).OriginalValue; } }
        protected Int32? intSamplesQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intSamplesQty).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datCollectionDate)]
        [MapField(_str_datCollectionDate)]
        public abstract DateTime? datCollectionDate { get; set; }
        #if MONO
        protected DateTime? datCollectionDate_Original { get { return datCollectionDate; } }
        protected DateTime? datCollectionDate_Previous { get { return datCollectionDate; } }
        #else
        protected DateTime? datCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCollectionDate).OriginalValue; } }
        protected DateTime? datCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCollectionDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intPositiveAnimalsQty)]
        [MapField(_str_intPositiveAnimalsQty)]
        public abstract Int32? intPositiveAnimalsQty { get; set; }
        #if MONO
        protected Int32? intPositiveAnimalsQty_Original { get { return intPositiveAnimalsQty; } }
        protected Int32? intPositiveAnimalsQty_Previous { get { return intPositiveAnimalsQty; } }
        #else
        protected Int32? intPositiveAnimalsQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intPositiveAnimalsQty).OriginalValue; } }
        protected Int32? intPositiveAnimalsQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intPositiveAnimalsQty).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strDiagnosis)]
        [MapField(_str_strDiagnosis)]
        public abstract String strDiagnosis { get; set; }
        #if MONO
        protected String strDiagnosis_Original { get { return strDiagnosis; } }
        protected String strDiagnosis_Previous { get { return strDiagnosis; } }
        #else
        protected String strDiagnosis_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosis).OriginalValue; } }
        protected String strDiagnosis_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("AsSessionSummary.strSamples")]
        [MapField(_str_strSamples)]
        public abstract String strSamples { get; set; }
        #if MONO
        protected String strSamples_Original { get { return strSamples; } }
        protected String strSamples_Previous { get { return strSamples; } }
        #else
        protected String strSamples_Original { get { return ((EditableValue<String>)((dynamic)this)._strSamples).OriginalValue; } }
        protected String strSamples_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSamples).PreviousValue; } }
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
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<AsSessionSummary, object> _get_func;
            internal Action<AsSessionSummary, string> _set_func;
            internal Action<AsSessionSummary, AsSessionSummary, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfMonitoringSessionSummary = "idfMonitoringSessionSummary";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_idfFarm = "idfFarm";
        internal const string _str_strFarmCode = "strFarmCode";
        internal const string _str_idfFarmActual = "idfFarmActual";
        internal const string _str_idfSpecies = "idfSpecies";
        internal const string _str_idfHerd = "idfHerd";
        internal const string _str_strHerdCode = "strHerdCode";
        internal const string _str_idfsSpeciesType = "idfsSpeciesType";
        internal const string _str_strSpecies = "strSpecies";
        internal const string _str_idfsAnimalSex = "idfsAnimalSex";
        internal const string _str_intSampledAnimalsQty = "intSampledAnimalsQty";
        internal const string _str_intSamplesQty = "intSamplesQty";
        internal const string _str_datCollectionDate = "datCollectionDate";
        internal const string _str_intPositiveAnimalsQty = "intPositiveAnimalsQty";
        internal const string _str_strDiagnosis = "strDiagnosis";
        internal const string _str_strSamples = "strSamples";
        internal const string _str_blnNewFarm = "blnNewFarm";
        internal const string _str_strGender = "strGender";
        internal const string _str_ASFarms = "ASFarms";
        internal const string _str_Farm = "Farm";
        internal const string _str_AnimalSex = "AnimalSex";
        internal const string _str_Samples = "Samples";
        internal const string _str_Diagnosis = "Diagnosis";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfMonitoringSessionSummary, _type = "Int64",
              _get_func = o => o.idfMonitoringSessionSummary,
              _set_func = (o, val) => { o.idfMonitoringSessionSummary = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfMonitoringSessionSummary != c.idfMonitoringSessionSummary || o.IsRIRPropChanged(_str_idfMonitoringSessionSummary, c)) 
                  m.Add(_str_idfMonitoringSessionSummary, o.ObjectIdent + _str_idfMonitoringSessionSummary, "Int64", o.idfMonitoringSessionSummary == null ? "" : o.idfMonitoringSessionSummary.ToString(), o.IsReadOnly(_str_idfMonitoringSessionSummary), o.IsInvisible(_str_idfMonitoringSessionSummary), o.IsRequired(_str_idfMonitoringSessionSummary)); }
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
              _name = _str_idfSpecies, _type = "Int64?",
              _get_func = o => o.idfSpecies,
              _set_func = (o, val) => { o.idfSpecies = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSpecies != c.idfSpecies || o.IsRIRPropChanged(_str_idfSpecies, c)) 
                  m.Add(_str_idfSpecies, o.ObjectIdent + _str_idfSpecies, "Int64?", o.idfSpecies == null ? "" : o.idfSpecies.ToString(), o.IsReadOnly(_str_idfSpecies), o.IsInvisible(_str_idfSpecies), o.IsRequired(_str_idfSpecies)); }
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
              _name = _str_idfsSpeciesType, _type = "Int64?",
              _get_func = o => o.idfsSpeciesType,
              _set_func = (o, val) => { o.idfsSpeciesType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_idfsSpeciesType, c)) 
                  m.Add(_str_idfsSpeciesType, o.ObjectIdent + _str_idfsSpeciesType, "Int64?", o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(), o.IsReadOnly(_str_idfsSpeciesType), o.IsInvisible(_str_idfsSpeciesType), o.IsRequired(_str_idfsSpeciesType)); }
              }, 
        
            new field_info {
              _name = _str_strSpecies, _type = "String",
              _get_func = o => o.strSpecies,
              _set_func = (o, val) => { o.strSpecies = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSpecies != c.strSpecies || o.IsRIRPropChanged(_str_strSpecies, c)) 
                  m.Add(_str_strSpecies, o.ObjectIdent + _str_strSpecies, "String", o.strSpecies == null ? "" : o.strSpecies.ToString(), o.IsReadOnly(_str_strSpecies), o.IsInvisible(_str_strSpecies), o.IsRequired(_str_strSpecies)); }
              }, 
        
            new field_info {
              _name = _str_idfsAnimalSex, _type = "Int64?",
              _get_func = o => o.idfsAnimalSex,
              _set_func = (o, val) => { o.idfsAnimalSex = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalSex != c.idfsAnimalSex || o.IsRIRPropChanged(_str_idfsAnimalSex, c)) 
                  m.Add(_str_idfsAnimalSex, o.ObjectIdent + _str_idfsAnimalSex, "Int64?", o.idfsAnimalSex == null ? "" : o.idfsAnimalSex.ToString(), o.IsReadOnly(_str_idfsAnimalSex), o.IsInvisible(_str_idfsAnimalSex), o.IsRequired(_str_idfsAnimalSex)); }
              }, 
        
            new field_info {
              _name = _str_intSampledAnimalsQty, _type = "Int32?",
              _get_func = o => o.intSampledAnimalsQty,
              _set_func = (o, val) => { o.intSampledAnimalsQty = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intSampledAnimalsQty != c.intSampledAnimalsQty || o.IsRIRPropChanged(_str_intSampledAnimalsQty, c)) 
                  m.Add(_str_intSampledAnimalsQty, o.ObjectIdent + _str_intSampledAnimalsQty, "Int32?", o.intSampledAnimalsQty == null ? "" : o.intSampledAnimalsQty.ToString(), o.IsReadOnly(_str_intSampledAnimalsQty), o.IsInvisible(_str_intSampledAnimalsQty), o.IsRequired(_str_intSampledAnimalsQty)); }
              }, 
        
            new field_info {
              _name = _str_intSamplesQty, _type = "Int32?",
              _get_func = o => o.intSamplesQty,
              _set_func = (o, val) => { o.intSamplesQty = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intSamplesQty != c.intSamplesQty || o.IsRIRPropChanged(_str_intSamplesQty, c)) 
                  m.Add(_str_intSamplesQty, o.ObjectIdent + _str_intSamplesQty, "Int32?", o.intSamplesQty == null ? "" : o.intSamplesQty.ToString(), o.IsReadOnly(_str_intSamplesQty), o.IsInvisible(_str_intSamplesQty), o.IsRequired(_str_intSamplesQty)); }
              }, 
        
            new field_info {
              _name = _str_datCollectionDate, _type = "DateTime?",
              _get_func = o => o.datCollectionDate,
              _set_func = (o, val) => { o.datCollectionDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datCollectionDate != c.datCollectionDate || o.IsRIRPropChanged(_str_datCollectionDate, c)) 
                  m.Add(_str_datCollectionDate, o.ObjectIdent + _str_datCollectionDate, "DateTime?", o.datCollectionDate == null ? "" : o.datCollectionDate.ToString(), o.IsReadOnly(_str_datCollectionDate), o.IsInvisible(_str_datCollectionDate), o.IsRequired(_str_datCollectionDate)); }
              }, 
        
            new field_info {
              _name = _str_intPositiveAnimalsQty, _type = "Int32?",
              _get_func = o => o.intPositiveAnimalsQty,
              _set_func = (o, val) => { o.intPositiveAnimalsQty = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intPositiveAnimalsQty != c.intPositiveAnimalsQty || o.IsRIRPropChanged(_str_intPositiveAnimalsQty, c)) 
                  m.Add(_str_intPositiveAnimalsQty, o.ObjectIdent + _str_intPositiveAnimalsQty, "Int32?", o.intPositiveAnimalsQty == null ? "" : o.intPositiveAnimalsQty.ToString(), o.IsReadOnly(_str_intPositiveAnimalsQty), o.IsInvisible(_str_intPositiveAnimalsQty), o.IsRequired(_str_intPositiveAnimalsQty)); }
              }, 
        
            new field_info {
              _name = _str_strDiagnosis, _type = "String",
              _get_func = o => o.strDiagnosis,
              _set_func = (o, val) => { o.strDiagnosis = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strDiagnosis != c.strDiagnosis || o.IsRIRPropChanged(_str_strDiagnosis, c)) 
                  m.Add(_str_strDiagnosis, o.ObjectIdent + _str_strDiagnosis, "String", o.strDiagnosis == null ? "" : o.strDiagnosis.ToString(), o.IsReadOnly(_str_strDiagnosis), o.IsInvisible(_str_strDiagnosis), o.IsRequired(_str_strDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_strSamples, _type = "String",
              _get_func = o => o.strSamples,
              _set_func = (o, val) => { o.strSamples = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSamples != c.strSamples || o.IsRIRPropChanged(_str_strSamples, c)) 
                  m.Add(_str_strSamples, o.ObjectIdent + _str_strSamples, "String", o.strSamples == null ? "" : o.strSamples.ToString(), o.IsReadOnly(_str_strSamples), o.IsInvisible(_str_strSamples), o.IsRequired(_str_strSamples)); }
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
              _name = _str_ASFarms, _type = "EditableList<AsSessionFarm>",
              _get_func = o => o.ASFarms,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_strGender, _type = "string",
              _get_func = o => o.strGender,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strGender != c.strGender || o.IsRIRPropChanged(_str_strGender, c)) 
                  m.Add(_str_strGender, o.ObjectIdent + _str_strGender, "string", o.strGender == null ? "" : o.strGender.ToString(), o.IsReadOnly(_str_strGender), o.IsInvisible(_str_strGender), o.IsRequired(_str_strGender));
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
              _name = _str_AnimalSex, _type = "Lookup",
              _get_func = o => { if (o.AnimalSex == null) return null; return o.AnimalSex.idfsBaseReference; },
              _set_func = (o, val) => { o.AnimalSex = o.AnimalSexLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalSex != c.idfsAnimalSex || o.IsRIRPropChanged(_str_AnimalSex, c)) 
                  m.Add(_str_AnimalSex, o.ObjectIdent + _str_AnimalSex, "Lookup", o.idfsAnimalSex == null ? "" : o.idfsAnimalSex.ToString(), o.IsReadOnly(_str_AnimalSex), o.IsInvisible(_str_AnimalSex), o.IsRequired(_str_AnimalSex)); }
              }, 
        
            new field_info {
              _name = _str_Samples, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Samples.Count != c.Samples.Count || o.IsReadOnly(_str_Samples) != c.IsReadOnly(_str_Samples) || o.IsInvisible(_str_Samples) != c.IsInvisible(_str_Samples) || o.IsRequired(_str_Samples) != c.IsRequired(_str_Samples)) 
                  m.Add(_str_Samples, o.ObjectIdent + _str_Samples, "Child", o.idfMonitoringSessionSummary == null ? "" : o.idfMonitoringSessionSummary.ToString(), o.IsReadOnly(_str_Samples), o.IsInvisible(_str_Samples), o.IsRequired(_str_Samples)); }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Diagnosis.Count != c.Diagnosis.Count || o.IsReadOnly(_str_Diagnosis) != c.IsReadOnly(_str_Diagnosis) || o.IsInvisible(_str_Diagnosis) != c.IsInvisible(_str_Diagnosis) || o.IsRequired(_str_Diagnosis) != c.IsRequired(_str_Diagnosis)) 
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, "Child", o.idfMonitoringSessionSummary == null ? "" : o.idfMonitoringSessionSummary.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis)); }
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
            AsSessionSummary obj = (AsSessionSummary)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(AsSessionSummarySample), eidss.model.Schema.AsSessionSummarySample._str_idfMonitoringSessionSummary, _str_idfMonitoringSessionSummary)]
        public EditableList<AsSessionSummarySample> Samples
        {
            get 
            {   
                if (!_SamplesLoaded)
                {
                    _SamplesLoaded = true;
                    _getAccessor()._LoadSamples(this);
                    _Samples.ForEach(c => { c.Parent = this; });
                }
                return _Samples; 
            }
            set 
            {
                _Samples = value;
            }
        }
        protected EditableList<AsSessionSummarySample> _Samples = new EditableList<AsSessionSummarySample>();
                    
        private bool _SamplesLoaded = false;
                    
        [Relation(typeof(AsSessionSummaryDiagnosis), eidss.model.Schema.AsSessionSummaryDiagnosis._str_idfMonitoringSessionSummary, _str_idfMonitoringSessionSummary)]
        public EditableList<AsSessionSummaryDiagnosis> Diagnosis
        {
            get 
            {   
                if (!_DiagnosisLoaded)
                {
                    _DiagnosisLoaded = true;
                    _getAccessor()._LoadDiagnosis(this);
                    _Diagnosis.ForEach(c => { c.Parent = this; });
                }
                return _Diagnosis; 
            }
            set 
            {
                _Diagnosis = value;
            }
        }
        protected EditableList<AsSessionSummaryDiagnosis> _Diagnosis = new EditableList<AsSessionSummaryDiagnosis>();
                    
        private bool _DiagnosisLoaded = false;
                    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAnimalSex)]
        public BaseReference AnimalSex
        {
            get { return _AnimalSex == null ? null : ((long)_AnimalSex.Key == 0 ? null : _AnimalSex); }
            set 
            { 
                _AnimalSex = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAnimalSex = _AnimalSex == null 
                    ? new Int64?()
                    : _AnimalSex.idfsBaseReference; 
                OnPropertyChanged(_str_AnimalSex); 
            }
        }
        private BaseReference _AnimalSex;

        
        public BaseReferenceList AnimalSexLookup
        {
            get { return _AnimalSexLookup; }
        }
        private BaseReferenceList _AnimalSexLookup = new BaseReferenceList("rftAnimalGenderList");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_AnimalSex:
                    return new BvSelectList(AnimalSexLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AnimalSex, _str_idfsAnimalSex);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strGender)]
        public string strGender
        {
            get { return new Func<AsSessionSummary, string>(c=>c.AnimalSex == null ? "" : c.AnimalSex.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Farm)]
        public FarmPanel Farm
        {
            get { return new Func<AsSessionSummary, FarmPanel>(c=>c.ASFarms.Count == 0 || c.idfFarm == 0 ? null : c.ASFarms.Single(x=>x.idfFarm == c.idfFarm).Farm)(this); }
            
        }
        
          [LocalizedDisplayName(_str_ASFarms)]
        public EditableList<AsSessionFarm> ASFarms
        {
            get { return m_ASFarms; }
            set { if (m_ASFarms != value) { m_ASFarms = value; OnPropertyChanged(_str_ASFarms); } }
        }
        private EditableList<AsSessionFarm> m_ASFarms;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AsSessionSummary";

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
        Samples.ForEach(c => { c.Parent = this; });
                Diagnosis.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as AsSessionSummary;
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
            var ret = base.Clone() as AsSessionSummary;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public AsSessionSummary CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AsSessionSummary;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfMonitoringSessionSummary; } }
        public string KeyName { get { return "idfMonitoringSessionSummary"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || Samples.IsDirty
                    || Samples.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Diagnosis.IsDirty
                    || Diagnosis.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsAnimalSex_AnimalSex = idfsAnimalSex;
            base.RejectChanges();
        
            if (_prev_idfsAnimalSex_AnimalSex != idfsAnimalSex)
            {
                _AnimalSex = _AnimalSexLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAnimalSex);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        Samples.RejectChanges();
                Diagnosis.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        Samples.AcceptChanges();
                Diagnosis.AcceptChanges();
                
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
        Samples.ForEach(c => c.SetChange());
                Diagnosis.ForEach(c => c.SetChange());
                
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

      private bool IsRIRPropChanged(string fld, AsSessionSummary c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public AsSessionSummary()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AsSessionSummary_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AsSessionSummary_PropertyChanged);
        }
        private void AsSessionSummary_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AsSessionSummary).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfsAnimalSex)
                OnPropertyChanged(_str_strGender);
                  
            if (e.PropertyName == _str_idfFarm)
                OnPropertyChanged(_str_Farm);
                  
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
            AsSessionSummary obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AsSessionSummary obj = this;
            
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
        
        private static string[] readonly_names2 = "AnimalSex,intSampledAnimalsQty,intSamplesQty,datCollectionDate,intPositiveAnimalsQty".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "Samples".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "Diagnosis".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionSummary, bool>(c=>c.Farm == null)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionSummary, bool>(c=>!c.idfSpecies.HasValue)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionSummary, bool>(c=>c.intSampledAnimalsQty.HasValue && c.intSampledAnimalsQty.Value > 0)(this);
            
            if (readonly_names4.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionSummary, bool>(c=>c.Samples.Count > 0 && c.intPositiveAnimalsQty.HasValue && c.intPositiveAnimalsQty.Value > 0)(this);
            
            return ReadOnly;
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _Samples)
                    o.ReadOnly = value;
                
                foreach(var o in _Diagnosis)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<AsSessionSummary, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsSessionSummary, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsSessionSummary, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<AsSessionSummary, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<AsSessionSummary, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<AsSessionSummary, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AsSessionSummary()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftAnimalGenderList", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftAnimalGenderList")
                _getAccessor().LoadLookup_AnimalSex(manager, this);
            
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
        
            if (_Samples != null) _Samples.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Diagnosis != null) _Diagnosis.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    
        #region Class for web grid
        public class AsSessionSummaryGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfMonitoringSessionSummary { get; set; }
        
            public string strFarmCode { get; set; }
        
            public string strSpecies { get; set; }
        
            public string strGender { get; set; }
        
            public Int32? intSampledAnimalsQty { get; set; }
        
            public string strSamples { get; set; }
        
            public Int32? intSamplesQty { get; set; }
        
            public DateTime? datCollectionDate { get; set; }
        
            public Int32? intPositiveAnimalsQty { get; set; }
        
            public string strDiagnosis { get; set; }
        
        }
        public partial class AsSessionSummaryGridModelList : List<AsSessionSummaryGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public AsSessionSummaryGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsSessionSummary>, errMes);
            }
            public AsSessionSummaryGridModelList(long key, IEnumerable<AsSessionSummary> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<AsSessionSummary> items);
            private void LoadGridModelList(long key, IEnumerable<AsSessionSummary> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strFarmCode,_str_strSpecies,_str_strGender,_str_intSampledAnimalsQty,_str_strSamples,_str_intSamplesQty,_str_datCollectionDate,_str_intPositiveAnimalsQty,_str_strDiagnosis};
                    
                Hiddens = new List<string> {_str_idfMonitoringSessionSummary};
                Keys = new List<string> {_str_idfMonitoringSessionSummary};
                Labels = new Dictionary<string, string> {{_str_strFarmCode, _str_strFarmCode},{_str_strSpecies, _str_strSpecies},{_str_strGender, _str_strGender},{_str_intSampledAnimalsQty, _str_intSampledAnimalsQty},{_str_strSamples, "AsSessionSummary.strSamples"},{_str_intSamplesQty, _str_intSamplesQty},{_str_datCollectionDate, _str_datCollectionDate},{_str_intPositiveAnimalsQty, _str_intPositiveAnimalsQty},{_str_strDiagnosis, _str_strDiagnosis}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<AsSessionSummary>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new AsSessionSummaryGridModel()
                {
                    ItemKey=c.idfMonitoringSessionSummary,strFarmCode=c.strFarmCode,strSpecies=c.strSpecies,strGender=c.strGender,intSampledAnimalsQty=c.intSampledAnimalsQty,strSamples=c.strSamples,intSamplesQty=c.intSamplesQty,datCollectionDate=c.datCollectionDate,intPositiveAnimalsQty=c.intPositiveAnimalsQty,strDiagnosis=c.strDiagnosis
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
        : DataAccessor<AsSessionSummary>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(AsSessionSummary obj);
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
            private AsSessionSummarySample.Accessor SamplesAccessor { get { return eidss.model.Schema.AsSessionSummarySample.Accessor.Instance(m_CS); } }
            private AsSessionSummaryDiagnosis.Accessor DiagnosisAccessor { get { return eidss.model.Schema.AsSessionSummaryDiagnosis.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AnimalSexAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<AsSessionSummary> SelectList(DbManagerProxy manager
                , Int64? idfMonitoringSession
                )
            {
                return _SelectList(manager
                    , idfMonitoringSession
                    , delegate(AsSessionSummary obj)
                        {
                        }
                    , delegate(AsSessionSummary obj)
                        {
                        }
                    );
            }

            
            private List<AsSessionSummary> _SelectList(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<AsSessionSummary> objs = new List<AsSessionSummary>();
                    sets[0] = new MapResultSet(typeof(AsSessionSummary), objs);
                    
                    manager
                        .SetSpCommand("spASSessionSummary_SelectDetail"
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
    
            private void _SetupAddChildHandlerSamples(AsSessionSummary obj)
            {
                obj.Samples.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerDiagnosis(AsSessionSummary obj)
            {
                obj.Diagnosis.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadSamples(AsSessionSummary obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSamples(manager, obj);
                }
            }
            internal void _LoadSamples(DbManagerProxy manager, AsSessionSummary obj)
            {
                
                obj.Samples.Clear();
                obj.Samples.AddRange(SamplesAccessor.SelectDetailList(manager
                    
                    , obj.idfMonitoringSessionSummary
                    ));
                obj.Samples.ForEach(c => c.m_ObjectName = _str_Samples);
                obj.Samples.AcceptChanges();
                    
            }
            
            internal void _LoadDiagnosis(AsSessionSummary obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadDiagnosis(manager, obj);
                }
            }
            internal void _LoadDiagnosis(DbManagerProxy manager, AsSessionSummary obj)
            {
                
                obj.Diagnosis.Clear();
                obj.Diagnosis.AddRange(DiagnosisAccessor.SelectDetailList(manager
                    
                    , obj.idfMonitoringSessionSummary
                    ));
                obj.Diagnosis.ForEach(c => c.m_ObjectName = _str_Diagnosis);
                obj.Diagnosis.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsSessionSummary obj)
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
                
                _SetupAddChildHandlerSamples(obj);
                
                _SetupAddChildHandlerDiagnosis(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, AsSessionSummary obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.Samples.ForEach(c => SamplesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Diagnosis.ForEach(c => DiagnosisAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private AsSessionSummary _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    AsSessionSummary obj = AsSessionSummary.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfMonitoringSessionSummary = (new GetNewIDExtender<AsSessionSummary>()).GetScalar(manager, obj);
                obj.blnNewFarm = true;
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerSamples(obj);
                    
                    _SetupAddChildHandlerDiagnosis(obj);
                    
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

            
            public AsSessionSummary CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public AsSessionSummary CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public AsSessionSummary CreateFromSessionT(DbManagerProxy manager, IObject Parent, List<object> pars)
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
            public AsSessionSummary CreateFromSession(DbManagerProxy manager, IObject Parent
                , AsSession session
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfMonitoringSession = session.idfMonitoringSession;
                obj.ASFarms = session.ASFarms;
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(AsSessionSummary obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AsSessionSummary obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfFarm)
                        {
                    
              if (obj.Farm != null)
              {
              obj.idfFarmActual = obj.Farm.idfRootFarm;
              obj.strFarmCode = obj.Farm.strFarmCode;
              }
            
                        }
                    
                        if (e.PropertyName == _str_Farm)
                        {
                    
                obj.strFarmCode = new Func<AsSessionSummary, string>(c=>c.Farm == null ? "" : c.Farm.strFarmCode)(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_AnimalSex(DbManagerProxy manager, AsSessionSummary obj)
            {
                
                obj.AnimalSexLookup.Clear();
                
                obj.AnimalSexLookup.Add(AnimalSexAccessor.CreateNewT(manager, null));
                
                obj.AnimalSexLookup.AddRange(AnimalSexAccessor.rftAnimalGenderList_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAnimalSex))
                    
                    .ToList());
                
                if (obj.idfsAnimalSex != null && obj.idfsAnimalSex != 0)
                {
                    obj.AnimalSex = obj.AnimalSexLookup
                        .Where(c => c.idfsBaseReference == obj.idfsAnimalSex)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftAnimalGenderList", obj, AnimalSexAccessor.GetType(), "rftAnimalGenderList_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, AsSessionSummary obj)
            {
                
                LoadLookup_AnimalSex(manager, obj);
                
            }
    
            [SprocName("spASSessionSummary_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfFarm", "strFarmCode", "idfFarmActual")] AsSessionSummary obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfFarm", "strFarmCode", "idfFarmActual")] AsSessionSummary obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    AsSessionSummary bo = obj as AsSessionSummary;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as AsSessionSummary, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AsSessionSummary obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                                        
                    _postPredicate(manager, 8, obj);
                                            
                    if (obj.Samples != null)
                    {
                        foreach (var i in obj.Samples)
                        {
                            i.MarkToDelete();
                            if (!SamplesAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                            
                    if (obj.Diagnosis != null)
                    {
                        foreach (var i in obj.Diagnosis)
                        {
                            i.MarkToDelete();
                            if (!DiagnosisAccessor.Post(manager, i, true))
                                return false;
                        }
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
                        if (obj.Samples != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.Samples)
                                if (!SamplesAccessor.Post(manager, i, true))
                                    return false;
                            obj.Samples.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.Samples.Remove(c));
                            obj.Samples.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._Samples != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._Samples)
                                if (!SamplesAccessor.Post(manager, i, true))
                                    return false;
                            obj._Samples.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._Samples.Remove(c));
                            obj._Samples.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.Diagnosis != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.Diagnosis)
                                if (!DiagnosisAccessor.Post(manager, i, true))
                                    return false;
                            obj.Diagnosis.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.Diagnosis.Remove(c));
                            obj.Diagnosis.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._Diagnosis != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._Diagnosis)
                                if (!DiagnosisAccessor.Post(manager, i, true))
                                    return false;
                            obj._Diagnosis.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._Diagnosis.Remove(c));
                            obj._Diagnosis.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(AsSessionSummary obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AsSessionSummary obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as AsSessionSummary, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsSessionSummary obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfFarm", "idfFarm","idfFarm",
                false
              )).Validate(c => true, obj, obj.idfFarm);
            
                (new PredicateValidator("AsSessionSummary_PositiveGreaterThanSampled", "intPositiveAnimalsQty", "intPositiveAnimalsQty", "intPositiveAnimalsQty",
              new object[] {
              },
                        false
                    )).Validate(obj, c=>c.intPositiveAnimalsQty == null || c.intPositiveAnimalsQty <= c.intSamplesQty
                    );
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Samples != null)
                            foreach (var i in obj.Samples.Where(c => !c.IsMarkedToDelete))
                                SamplesAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Diagnosis != null)
                            foreach (var i in obj.Diagnosis.Where(c => !c.IsMarkedToDelete))
                                DiagnosisAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
           
    
            private void _SetupRequired(AsSessionSummary obj)
            {
            
                obj
                    .AddRequired("idfFarm", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(AsSessionSummary obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AsSessionSummary) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AsSessionSummary) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AsSessionSummaryDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spASSessionSummary_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spASSessionSummary_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsSessionSummary, bool>> RequiredByField = new Dictionary<string, Func<AsSessionSummary, bool>>();
            public static Dictionary<string, Func<AsSessionSummary, bool>> RequiredByProperty = new Dictionary<string, Func<AsSessionSummary, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strFarmCode, 200);
                Sizes.Add(_str_strHerdCode, 200);
                Sizes.Add(_str_strSpecies, 2000);
                Sizes.Add(_str_strDiagnosis, 2147483647);
                Sizes.Add(_str_strSamples, 2147483647);
                if (!RequiredByField.ContainsKey("idfFarm")) RequiredByField.Add("idfFarm", c => true);
                if (!RequiredByProperty.ContainsKey("idfFarm")) RequiredByProperty.Add("idfFarm", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfMonitoringSessionSummary,
                    _str_idfMonitoringSessionSummary, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFarmCode,
                    _str_strFarmCode, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpecies,
                    _str_strSpecies, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strGender,
                    _str_strGender, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intSampledAnimalsQty,
                    _str_intSampledAnimalsQty, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSamples,
                    "AsSessionSummary.strSamples", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intSamplesQty,
                    _str_intSamplesQty, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datCollectionDate,
                    _str_datCollectionDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intPositiveAnimalsQty,
                    _str_intPositiveAnimalsQty, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnosis,
                    _str_strDiagnosis, null, true, true, null
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
                    (manager, c, pars) => ((AsSessionSummary)c).MarkToDelete(),
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
	