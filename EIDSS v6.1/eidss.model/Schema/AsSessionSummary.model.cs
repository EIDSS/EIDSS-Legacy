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
        protected Int64 idfMonitoringSession_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfMonitoringSession).OriginalValue; } }
        protected Int64 idfMonitoringSession_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfMonitoringSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfFarm)]
        [MapField(_str_idfFarm)]
        public abstract Int64 idfFarm { get; set; }
        protected Int64 idfFarm_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfFarm).OriginalValue; } }
        protected Int64 idfFarm_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfFarm).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFarmCode)]
        [MapField(_str_strFarmCode)]
        public abstract String strFarmCode { get; set; }
        protected String strFarmCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).OriginalValue; } }
        protected String strFarmCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfFarmActual)]
        [MapField(_str_idfFarmActual)]
        public abstract Int64? idfFarmActual { get; set; }
        protected Int64? idfFarmActual_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFarmActual).OriginalValue; } }
        protected Int64? idfFarmActual_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFarmActual).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfSpecies)]
        [MapField(_str_idfSpecies)]
        public abstract Int64? idfSpecies { get; set; }
        protected Int64? idfSpecies_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).OriginalValue; } }
        protected Int64? idfSpecies_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfHerd)]
        [MapField(_str_idfHerd)]
        public abstract Int64? idfHerd { get; set; }
        protected Int64? idfHerd_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHerd).OriginalValue; } }
        protected Int64? idfHerd_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHerd).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHerdCode)]
        [MapField(_str_strHerdCode)]
        public abstract String strHerdCode { get; set; }
        protected String strHerdCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strHerdCode).OriginalValue; } }
        protected String strHerdCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHerdCode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSpeciesType)]
        [MapField(_str_idfsSpeciesType)]
        public abstract Int64? idfsSpeciesType { get; set; }
        protected Int64? idfsSpeciesType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).OriginalValue; } }
        protected Int64? idfsSpeciesType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSpecies)]
        [MapField(_str_strSpecies)]
        public abstract String strSpecies { get; set; }
        protected String strSpecies_Original { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).OriginalValue; } }
        protected String strSpecies_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsAnimalSex)]
        [MapField(_str_idfsAnimalSex)]
        public abstract Int64? idfsAnimalSex { get; set; }
        protected Int64? idfsAnimalSex_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalSex).OriginalValue; } }
        protected Int64? idfsAnimalSex_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalSex).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intSampledAnimalsQty)]
        [MapField(_str_intSampledAnimalsQty)]
        public abstract Int32? intSampledAnimalsQty { get; set; }
        protected Int32? intSampledAnimalsQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intSampledAnimalsQty).OriginalValue; } }
        protected Int32? intSampledAnimalsQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intSampledAnimalsQty).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intSamplesQty)]
        [MapField(_str_intSamplesQty)]
        public abstract Int32? intSamplesQty { get; set; }
        protected Int32? intSamplesQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intSamplesQty).OriginalValue; } }
        protected Int32? intSamplesQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intSamplesQty).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datCollectionDate)]
        [MapField(_str_datCollectionDate)]
        public abstract DateTime? datCollectionDate { get; set; }
        protected DateTime? datCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCollectionDate).OriginalValue; } }
        protected DateTime? datCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCollectionDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intPositiveAnimalsQty)]
        [MapField(_str_intPositiveAnimalsQty)]
        public abstract Int32? intPositiveAnimalsQty { get; set; }
        protected Int32? intPositiveAnimalsQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intPositiveAnimalsQty).OriginalValue; } }
        protected Int32? intPositiveAnimalsQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intPositiveAnimalsQty).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDiagnosis)]
        [MapField(_str_strDiagnosis)]
        public abstract String strDiagnosis { get; set; }
        protected String strDiagnosis_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosis).OriginalValue; } }
        protected String strDiagnosis_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSamples)]
        [MapField(_str_strSamples)]
        public abstract String strSamples { get; set; }
        protected String strSamples_Original { get { return ((EditableValue<String>)((dynamic)this)._strSamples).OriginalValue; } }
        protected String strSamples_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSamples).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnNewFarm)]
        [MapField(_str_blnNewFarm)]
        public abstract Boolean? blnNewFarm { get; set; }
        protected Boolean? blnNewFarm_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnNewFarm).OriginalValue; } }
        protected Boolean? blnNewFarm_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnNewFarm).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<AsSessionSummary, object> _get_func;
            internal Action<AsSessionSummary, string> _set_func;
            internal Action<AsSessionSummary, AsSessionSummary, CompareModel, DbManagerProxy> _compare_func;
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
        internal const string _str_ParentFarms = "ParentFarms";
        internal const string _str_ParentSpecies = "ParentSpecies";
        internal const string _str_DiseasesList = "DiseasesList";
        internal const string _str_DiagnosisList = "DiagnosisList";
        internal const string _str_strSamplesCalc = "strSamplesCalc";
        internal const string _str_strDiagnosisCalc = "strDiagnosisCalc";
        internal const string _str_SamplesFiltered = "SamplesFiltered";
        internal const string _str_Farms = "Farms";
        internal const string _str_Species = "Species";
        internal const string _str_AnimalSex = "AnimalSex";
        internal const string _str_Samples = "Samples";
        internal const string _str_Diagnosis = "Diagnosis";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfMonitoringSessionSummary, _formname = _str_idfMonitoringSessionSummary, _type = "Int64",
              _get_func = o => o.idfMonitoringSessionSummary,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfMonitoringSessionSummary != newval) o.idfMonitoringSessionSummary = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfMonitoringSessionSummary != c.idfMonitoringSessionSummary || o.IsRIRPropChanged(_str_idfMonitoringSessionSummary, c)) 
                  m.Add(_str_idfMonitoringSessionSummary, o.ObjectIdent + _str_idfMonitoringSessionSummary, o.ObjectIdent2 + _str_idfMonitoringSessionSummary, o.ObjectIdent3 + _str_idfMonitoringSessionSummary, "Int64", 
                    o.idfMonitoringSessionSummary == null ? "" : o.idfMonitoringSessionSummary.ToString(),                  
                  o.IsReadOnly(_str_idfMonitoringSessionSummary), o.IsInvisible(_str_idfMonitoringSessionSummary), o.IsRequired(_str_idfMonitoringSessionSummary)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfMonitoringSession, _formname = _str_idfMonitoringSession, _type = "Int64",
              _get_func = o => o.idfMonitoringSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfMonitoringSession != newval) o.idfMonitoringSession = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfMonitoringSession != c.idfMonitoringSession || o.IsRIRPropChanged(_str_idfMonitoringSession, c)) 
                  m.Add(_str_idfMonitoringSession, o.ObjectIdent + _str_idfMonitoringSession, o.ObjectIdent2 + _str_idfMonitoringSession, o.ObjectIdent3 + _str_idfMonitoringSession, "Int64", 
                    o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(),                  
                  o.IsReadOnly(_str_idfMonitoringSession), o.IsInvisible(_str_idfMonitoringSession), o.IsRequired(_str_idfMonitoringSession)); 
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
              _name = _str_idfFarmActual, _formname = _str_idfFarmActual, _type = "Int64?",
              _get_func = o => o.idfFarmActual,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfFarmActual != newval) o.idfFarmActual = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfFarmActual != c.idfFarmActual || o.IsRIRPropChanged(_str_idfFarmActual, c)) 
                  m.Add(_str_idfFarmActual, o.ObjectIdent + _str_idfFarmActual, o.ObjectIdent2 + _str_idfFarmActual, o.ObjectIdent3 + _str_idfFarmActual, "Int64?", 
                    o.idfFarmActual == null ? "" : o.idfFarmActual.ToString(),                  
                  o.IsReadOnly(_str_idfFarmActual), o.IsInvisible(_str_idfFarmActual), o.IsRequired(_str_idfFarmActual)); 
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
              _name = _str_idfHerd, _formname = _str_idfHerd, _type = "Int64?",
              _get_func = o => o.idfHerd,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfHerd != newval) o.idfHerd = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfHerd != c.idfHerd || o.IsRIRPropChanged(_str_idfHerd, c)) 
                  m.Add(_str_idfHerd, o.ObjectIdent + _str_idfHerd, o.ObjectIdent2 + _str_idfHerd, o.ObjectIdent3 + _str_idfHerd, "Int64?", 
                    o.idfHerd == null ? "" : o.idfHerd.ToString(),                  
                  o.IsReadOnly(_str_idfHerd), o.IsInvisible(_str_idfHerd), o.IsRequired(_str_idfHerd)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHerdCode, _formname = _str_strHerdCode, _type = "String",
              _get_func = o => o.strHerdCode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHerdCode != newval) o.strHerdCode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strHerdCode != c.strHerdCode || o.IsRIRPropChanged(_str_strHerdCode, c)) 
                  m.Add(_str_strHerdCode, o.ObjectIdent + _str_strHerdCode, o.ObjectIdent2 + _str_strHerdCode, o.ObjectIdent3 + _str_strHerdCode, "String", 
                    o.strHerdCode == null ? "" : o.strHerdCode.ToString(),                  
                  o.IsReadOnly(_str_strHerdCode), o.IsInvisible(_str_strHerdCode), o.IsRequired(_str_strHerdCode)); 
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
              _name = _str_strSpecies, _formname = _str_strSpecies, _type = "String",
              _get_func = o => o.strSpecies,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSpecies != newval) o.strSpecies = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSpecies != c.strSpecies || o.IsRIRPropChanged(_str_strSpecies, c)) 
                  m.Add(_str_strSpecies, o.ObjectIdent + _str_strSpecies, o.ObjectIdent2 + _str_strSpecies, o.ObjectIdent3 + _str_strSpecies, "String", 
                    o.strSpecies == null ? "" : o.strSpecies.ToString(),                  
                  o.IsReadOnly(_str_strSpecies), o.IsInvisible(_str_strSpecies), o.IsRequired(_str_strSpecies)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAnimalSex, _formname = _str_idfsAnimalSex, _type = "Int64?",
              _get_func = o => o.idfsAnimalSex,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsAnimalSex != newval) 
                  o.AnimalSex = o.AnimalSexLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsAnimalSex != newval) o.idfsAnimalSex = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsAnimalSex != c.idfsAnimalSex || o.IsRIRPropChanged(_str_idfsAnimalSex, c)) 
                  m.Add(_str_idfsAnimalSex, o.ObjectIdent + _str_idfsAnimalSex, o.ObjectIdent2 + _str_idfsAnimalSex, o.ObjectIdent3 + _str_idfsAnimalSex, "Int64?", 
                    o.idfsAnimalSex == null ? "" : o.idfsAnimalSex.ToString(),                  
                  o.IsReadOnly(_str_idfsAnimalSex), o.IsInvisible(_str_idfsAnimalSex), o.IsRequired(_str_idfsAnimalSex)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intSampledAnimalsQty, _formname = _str_intSampledAnimalsQty, _type = "Int32?",
              _get_func = o => o.intSampledAnimalsQty,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intSampledAnimalsQty != newval) o.intSampledAnimalsQty = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intSampledAnimalsQty != c.intSampledAnimalsQty || o.IsRIRPropChanged(_str_intSampledAnimalsQty, c)) 
                  m.Add(_str_intSampledAnimalsQty, o.ObjectIdent + _str_intSampledAnimalsQty, o.ObjectIdent2 + _str_intSampledAnimalsQty, o.ObjectIdent3 + _str_intSampledAnimalsQty, "Int32?", 
                    o.intSampledAnimalsQty == null ? "" : o.intSampledAnimalsQty.ToString(),                  
                  o.IsReadOnly(_str_intSampledAnimalsQty), o.IsInvisible(_str_intSampledAnimalsQty), o.IsRequired(_str_intSampledAnimalsQty)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intSamplesQty, _formname = _str_intSamplesQty, _type = "Int32?",
              _get_func = o => o.intSamplesQty,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intSamplesQty != newval) o.intSamplesQty = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intSamplesQty != c.intSamplesQty || o.IsRIRPropChanged(_str_intSamplesQty, c)) 
                  m.Add(_str_intSamplesQty, o.ObjectIdent + _str_intSamplesQty, o.ObjectIdent2 + _str_intSamplesQty, o.ObjectIdent3 + _str_intSamplesQty, "Int32?", 
                    o.intSamplesQty == null ? "" : o.intSamplesQty.ToString(),                  
                  o.IsReadOnly(_str_intSamplesQty), o.IsInvisible(_str_intSamplesQty), o.IsRequired(_str_intSamplesQty)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datCollectionDate, _formname = _str_datCollectionDate, _type = "DateTime?",
              _get_func = o => o.datCollectionDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datCollectionDate != newval) o.datCollectionDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datCollectionDate != c.datCollectionDate || o.IsRIRPropChanged(_str_datCollectionDate, c)) 
                  m.Add(_str_datCollectionDate, o.ObjectIdent + _str_datCollectionDate, o.ObjectIdent2 + _str_datCollectionDate, o.ObjectIdent3 + _str_datCollectionDate, "DateTime?", 
                    o.datCollectionDate == null ? "" : o.datCollectionDate.ToString(),                  
                  o.IsReadOnly(_str_datCollectionDate), o.IsInvisible(_str_datCollectionDate), o.IsRequired(_str_datCollectionDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intPositiveAnimalsQty, _formname = _str_intPositiveAnimalsQty, _type = "Int32?",
              _get_func = o => o.intPositiveAnimalsQty,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intPositiveAnimalsQty != newval) o.intPositiveAnimalsQty = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intPositiveAnimalsQty != c.intPositiveAnimalsQty || o.IsRIRPropChanged(_str_intPositiveAnimalsQty, c)) 
                  m.Add(_str_intPositiveAnimalsQty, o.ObjectIdent + _str_intPositiveAnimalsQty, o.ObjectIdent2 + _str_intPositiveAnimalsQty, o.ObjectIdent3 + _str_intPositiveAnimalsQty, "Int32?", 
                    o.intPositiveAnimalsQty == null ? "" : o.intPositiveAnimalsQty.ToString(),                  
                  o.IsReadOnly(_str_intPositiveAnimalsQty), o.IsInvisible(_str_intPositiveAnimalsQty), o.IsRequired(_str_intPositiveAnimalsQty)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDiagnosis, _formname = _str_strDiagnosis, _type = "String",
              _get_func = o => o.strDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDiagnosis != newval) o.strDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strDiagnosis != c.strDiagnosis || o.IsRIRPropChanged(_str_strDiagnosis, c)) 
                  m.Add(_str_strDiagnosis, o.ObjectIdent + _str_strDiagnosis, o.ObjectIdent2 + _str_strDiagnosis, o.ObjectIdent3 + _str_strDiagnosis, "String", 
                    o.strDiagnosis == null ? "" : o.strDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_strDiagnosis), o.IsInvisible(_str_strDiagnosis), o.IsRequired(_str_strDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSamples, _formname = _str_strSamples, _type = "String",
              _get_func = o => o.strSamples,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSamples != newval) o.strSamples = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSamples != c.strSamples || o.IsRIRPropChanged(_str_strSamples, c)) 
                  m.Add(_str_strSamples, o.ObjectIdent + _str_strSamples, o.ObjectIdent2 + _str_strSamples, o.ObjectIdent3 + _str_strSamples, "String", 
                    o.strSamples == null ? "" : o.strSamples.ToString(),                  
                  o.IsReadOnly(_str_strSamples), o.IsInvisible(_str_strSamples), o.IsRequired(_str_strSamples)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnNewFarm, _formname = _str_blnNewFarm, _type = "Boolean?",
              _get_func = o => o.blnNewFarm,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnNewFarm != newval) o.blnNewFarm = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnNewFarm != c.blnNewFarm || o.IsRIRPropChanged(_str_blnNewFarm, c)) 
                  m.Add(_str_blnNewFarm, o.ObjectIdent + _str_blnNewFarm, o.ObjectIdent2 + _str_blnNewFarm, o.ObjectIdent3 + _str_blnNewFarm, "Boolean?", 
                    o.blnNewFarm == null ? "" : o.blnNewFarm.ToString(),                  
                  o.IsReadOnly(_str_blnNewFarm), o.IsInvisible(_str_blnNewFarm), o.IsRequired(_str_blnNewFarm)); 
                  }
              }, 
        
            new field_info {
              _name = _str_strGender, _formname = _str_strGender, _type = "string",
              _get_func = o => o.strGender,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strGender != c.strGender || o.IsRIRPropChanged(_str_strGender, c)) {
                  m.Add(_str_strGender, o.ObjectIdent + _str_strGender, o.ObjectIdent2 + _str_strGender, o.ObjectIdent3 + _str_strGender, "string", o.strGender == null ? "" : o.strGender.ToString(), o.IsReadOnly(_str_strGender), o.IsInvisible(_str_strGender), o.IsRequired(_str_strGender));
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
              _name = _str_DiseasesList, _formname = _str_DiseasesList, _type = "List<AsSessionDisease>",
              _get_func = o => o.DiseasesList,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_DiagnosisList, _formname = _str_DiagnosisList, _type = "List<AsSessionSummaryDiagnosis>",
              _get_func = o => o.DiagnosisList,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.DiagnosisList.Count != c.DiagnosisList.Count || o.IsReadOnly(_str_DiagnosisList) != c.IsReadOnly(_str_DiagnosisList) || o.IsInvisible(_str_DiagnosisList) != c.IsInvisible(_str_DiagnosisList) || o.IsRequired(_str_DiagnosisList) != c._isRequired(o.m_isRequired, _str_DiagnosisList)) {
                  m.Add(_str_DiagnosisList, o.ObjectIdent + _str_DiagnosisList, o.ObjectIdent2 + _str_DiagnosisList, o.ObjectIdent3 + _str_DiagnosisList, "Child", "", o.IsReadOnly(_str_DiagnosisList), o.IsInvisible(_str_DiagnosisList), o.IsRequired(_str_DiagnosisList)); 
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strSamplesCalc, _formname = _str_strSamplesCalc, _type = "string",
              _get_func = o => o.strSamplesCalc,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strSamplesCalc != c.strSamplesCalc || o.IsRIRPropChanged(_str_strSamplesCalc, c)) {
                  m.Add(_str_strSamplesCalc, o.ObjectIdent + _str_strSamplesCalc, o.ObjectIdent2 + _str_strSamplesCalc, o.ObjectIdent3 + _str_strSamplesCalc, "string", o.strSamplesCalc == null ? "" : o.strSamplesCalc.ToString(), o.IsReadOnly(_str_strSamplesCalc), o.IsInvisible(_str_strSamplesCalc), o.IsRequired(_str_strSamplesCalc));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strDiagnosisCalc, _formname = _str_strDiagnosisCalc, _type = "string",
              _get_func = o => o.strDiagnosisCalc,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strDiagnosisCalc != c.strDiagnosisCalc || o.IsRIRPropChanged(_str_strDiagnosisCalc, c)) {
                  m.Add(_str_strDiagnosisCalc, o.ObjectIdent + _str_strDiagnosisCalc, o.ObjectIdent2 + _str_strDiagnosisCalc, o.ObjectIdent3 + _str_strDiagnosisCalc, "string", o.strDiagnosisCalc == null ? "" : o.strDiagnosisCalc.ToString(), o.IsReadOnly(_str_strDiagnosisCalc), o.IsInvisible(_str_strDiagnosisCalc), o.IsRequired(_str_strDiagnosisCalc));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_SamplesFiltered, _formname = _str_SamplesFiltered, _type = "List<AsSessionSummarySample>",
              _get_func = o => o.SamplesFiltered,
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
              _name = _str_AnimalSex, _formname = _str_AnimalSex, _type = "Lookup",
              _get_func = o => { if (o.AnimalSex == null) return null; return o.AnimalSex.idfsBaseReference; },
              _set_func = (o, val) => { o.AnimalSex = o.AnimalSexLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_AnimalSex, c);
                if (o.idfsAnimalSex != c.idfsAnimalSex || o.IsRIRPropChanged(_str_AnimalSex, c) || bChangeLookupContent) {
                  m.Add(_str_AnimalSex, o.ObjectIdent + _str_AnimalSex, o.ObjectIdent2 + _str_AnimalSex, o.ObjectIdent3 + _str_AnimalSex, "Lookup", o.idfsAnimalSex == null ? "" : o.idfsAnimalSex.ToString(), o.IsReadOnly(_str_AnimalSex), o.IsInvisible(_str_AnimalSex), o.IsRequired(_str_AnimalSex),
                  bChangeLookupContent ? o.AnimalSexLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_AnimalSex + "Lookup", _formname = _str_AnimalSex + "Lookup", _type = "LookupContent",
              _get_func = o => o.AnimalSexLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Samples, _formname = _str_Samples, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Samples.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Samples.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.Samples.Count != c.Samples.Count || o.IsReadOnly(_str_Samples) != c.IsReadOnly(_str_Samples) || o.IsInvisible(_str_Samples) != c.IsInvisible(_str_Samples) || o.IsRequired(_str_Samples) != c._isRequired(o.m_isRequired, _str_Samples)) {
                  m.Add(_str_Samples, o.ObjectIdent + _str_Samples, o.ObjectIdent2 + _str_Samples, o.ObjectIdent3 + _str_Samples, "Child", o.idfMonitoringSessionSummary == null ? "" : o.idfMonitoringSessionSummary.ToString(), o.IsReadOnly(_str_Samples), o.IsInvisible(_str_Samples), o.IsRequired(_str_Samples)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _formname = _str_Diagnosis, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Diagnosis.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Diagnosis.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.Diagnosis.Count != c.Diagnosis.Count || o.IsReadOnly(_str_Diagnosis) != c.IsReadOnly(_str_Diagnosis) || o.IsInvisible(_str_Diagnosis) != c.IsInvisible(_str_Diagnosis) || o.IsRequired(_str_Diagnosis) != c._isRequired(o.m_isRequired, _str_Diagnosis)) {
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, o.ObjectIdent2 + _str_Diagnosis, o.ObjectIdent3 + _str_Diagnosis, "Child", o.idfMonitoringSessionSummary == null ? "" : o.idfMonitoringSessionSummary.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis)); 
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
            AsSessionSummary obj = (AsSessionSummary)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Samples)]
        [Relation(typeof(AsSessionSummarySample), eidss.model.Schema.AsSessionSummarySample._str_idfMonitoringSessionSummary, _str_idfMonitoringSessionSummary)]
        public EditableList<AsSessionSummarySample> Samples
        {
            get 
            {   
                return _Samples; 
            }
            set 
            {
                _Samples = value;
            }
        }
        protected EditableList<AsSessionSummarySample> _Samples = new EditableList<AsSessionSummarySample>();
                    
        [LocalizedDisplayName(_str_Diagnosis)]
        [Relation(typeof(AsSessionSummaryDiagnosis), eidss.model.Schema.AsSessionSummaryDiagnosis._str_idfMonitoringSessionSummary, _str_idfMonitoringSessionSummary)]
        public EditableList<AsSessionSummaryDiagnosis> Diagnosis
        {
            get 
            {   
                return _Diagnosis; 
            }
            set 
            {
                _Diagnosis = value;
            }
        }
        protected EditableList<AsSessionSummaryDiagnosis> _Diagnosis = new EditableList<AsSessionSummaryDiagnosis>();
                    
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
            
        [LocalizedDisplayName(_str_AnimalSex)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAnimalSex)]
        public BaseReference AnimalSex
        {
            get { return _AnimalSex == null ? null : ((long)_AnimalSex.Key == 0 ? null : _AnimalSex); }
            set 
            { 
                var oldVal = _AnimalSex;
                _AnimalSex = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_AnimalSex != oldVal)
                {
                    if (idfsAnimalSex != (_AnimalSex == null
                            ? new Int64?()
                            : (Int64?)_AnimalSex.idfsBaseReference))
                        idfsAnimalSex = _AnimalSex == null 
                            ? new Int64?()
                            : (Int64?)_AnimalSex.idfsBaseReference; 
                    OnPropertyChanged(_str_AnimalSex); 
                }
            }
        }
        private BaseReference _AnimalSex;

        
        public BaseReferenceList AnimalSexLookup
        {
            get { return _AnimalSexLookup; }
        }
        private BaseReferenceList _AnimalSexLookup = new BaseReferenceList("rftAnimalSex");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Farms:
                    return new BvSelectList(FarmsLookup, eidss.model.Schema.FarmPanel._str_idfFarm, null, Farms, _str_idfFarm);
            
                case _str_Species:
                    return new BvSelectList(SpeciesLookup, eidss.model.Schema.VetFarmTree._str_idfParty, null, Species, _str_idfSpecies);
            
                case _str_AnimalSex:
                    return new BvSelectList(AnimalSexLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AnimalSex, _str_idfsAnimalSex);
            
                case _str_Samples:
                    return new BvSelectList(Samples, "", "", null, "");
            
                case _str_Diagnosis:
                    return new BvSelectList(Diagnosis, "", "", null, "");
            
                case _str_DiagnosisList:
                    return new BvSelectList(DiagnosisList, "", "", null, "");
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strGender)]
        public string strGender
        {
            get { return new Func<AsSessionSummary, string>(c => c.AnimalSex == null ? "" : c.AnimalSex.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_ParentFarms)]
        public List<FarmPanel> ParentFarms
        {
            get { return new Func<AsSessionSummary, List<FarmPanel>>(c => c.Parent == null ? new List<FarmPanel>() : (c.Parent as AsSession).ASFarmsSummary.Where(i => !i.IsMarkedToDelete).Select(i => i.Farm).ToList())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_ParentSpecies)]
        public List<VetFarmTree> ParentSpecies
        {
            get { return new Func<AsSessionSummary, List<VetFarmTree>>(c => c.Parent == null ? new List<VetFarmTree>() : (c.Parent as AsSession).ASFarmsSummary.SingleOrDefault(i => i.idfFarm == c.idfFarm, farm => farm.Farm.FarmTree.Where(i => i.idfsPartyType == (long)PartyTypeEnum.Species && !i.IsMarkedToDelete && ( !(c.Parent as AsSession).Diseases.Any(j => !j.IsMarkedToDelete && j.idfsSpeciesType.HasValue) || (c.Parent as AsSession).Diseases.Any(j => !j.IsMarkedToDelete && j.idfsSpeciesType == i.idfsSpeciesTypeReference) ) ).ToList()))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_DiseasesList)]
        public List<AsSessionDisease> DiseasesList
        {
            get { return new Func<AsSessionSummary, List<AsSessionDisease>>(c => new List<AsSessionDisease>((c.Parent as AsSession).Diseases.Where(d => !d.IsMarkedToDelete).Distinct()))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_DiagnosisList)]
        public List<AsSessionSummaryDiagnosis> DiagnosisList
        {
            get { return new Func<AsSessionSummary, List<AsSessionSummaryDiagnosis>>(c => new List<AsSessionSummaryDiagnosis>(c.Diagnosis.Where(d => c.DiseasesList.Any(i => i.idfsDiagnosis == d.idfsDiagnosis))
                      .Distinct()))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("AsSessionSummary.strSamples")]
        public string strSamplesCalc
        {
            get { return new Func<AsSessionSummary, string>(s => s.Samples.ToList().Aggregate("", (r, c) => c.blnChecked.HasValue && c.blnChecked.Value ? (r == "" ? c.name.ToString() : r + "," + c.name.ToString()) : r))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("strDiagnosis")]
        public string strDiagnosisCalc
        {
            get { return new Func<AsSessionSummary, string>(s => s.Diagnosis.ToList().Aggregate("", (r, c) => c.blnChecked.HasValue && c.blnChecked.Value ? (r == "" ? c.name.ToString() : r + "," + c.name.ToString()) : r))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_SamplesFiltered)]
        public List<AsSessionSummarySample> SamplesFiltered
        {
            get { return new Func<AsSessionSummary, List<AsSessionSummarySample>>(c => !(c.Parent as AsSession).Diseases.Any(j => !j.IsMarkedToDelete)
                      ? (c.Samples.ToList())
                      : (c.Samples.Where(i => !i.IsMarkedToDelete && (c.Parent as AsSession).Diseases.Any(j => !j.IsMarkedToDelete && (j.idfsSampleType == i.idfsSampleType || !j.idfsSampleType.HasValue || j.idfsSampleType.Value == 0) && (j.idfsSpeciesType == c.idfsSpeciesType/* || !j.idfsSpeciesType.HasValue || j.idfsSpeciesType.Value == 0*/))).ToList()))(this); }
            
        }
        
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
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as AsSessionSummary;
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
            var ret = base.Clone() as AsSessionSummary;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Samples != null && _Samples.Count > 0)
            {
              ret.Samples.Clear();
              _Samples.ForEach(c => ret.Samples.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_Diagnosis != null && _Diagnosis.Count > 0)
            {
              ret.Diagnosis.Clear();
              _Diagnosis.ForEach(c => ret.Diagnosis.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
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
        public object KeyLookup { get { return idfMonitoringSessionSummary; } }
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
        Samples.DeepRejectChanges();
                Diagnosis.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        Samples.DeepAcceptChanges();
                Diagnosis.DeepAcceptChanges();
                
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
        Samples.ForEach(c => c.SetChange());
                Diagnosis.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, AsSessionSummary c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, AsSessionSummary c)
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
        

      

        public AsSessionSummary()
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
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_ParentFarms);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_ParentSpecies);
                  
            if (e.PropertyName == _str_idfsSpeciesType)
                OnPropertyChanged(_str_DiseasesList);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_DiseasesList);
                  
            if (e.PropertyName == _str_idfsSpeciesType)
                OnPropertyChanged(_str_DiagnosisList);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_DiagnosisList);
                  
            if (e.PropertyName == _str_Samples)
                OnPropertyChanged(_str_strSamplesCalc);
                  
            if (e.PropertyName == _str_Diagnosis)
                OnPropertyChanged(_str_strDiagnosisCalc);
                  
            if (e.PropertyName == _str_Samples)
                OnPropertyChanged(_str_SamplesFiltered);
                  
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

    
        private static string[] readonly_names1 = "strGender,strSpecies,strSamples,strDiagnosis".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "idfSpecies".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "AnimalSex,Samples,intSampledAnimalsQty,intSamplesQty,datCollectionDate,intPositiveAnimalsQty".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "Diagnosis,DiagnosisList".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionSummary, bool>(c=>true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionSummary, bool>(c => c.Farms == null)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionSummary, bool>(c => !c.idfSpecies.HasValue || c.idfSpecies == 0)(this);
            
            if (readonly_names4.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionSummary, bool>(c => !c.idfSpecies.HasValue || c.idfSpecies == 0 || /*c.strSamplesCalc.Length == 0 ||*/ !c.intPositiveAnimalsQty.HasValue || c.intPositiveAnimalsQty.Value == 0)(this);
            
            return ReadOnly;
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
                foreach(var o in _Samples)
                    o._isValid &= value;
                
                foreach(var o in _Diagnosis)
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
        
                foreach(var o in _Samples)
                    o.ReadOnly |= value;
                
                foreach(var o in _Diagnosis)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<AsSessionSummary, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<AsSessionSummary, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsSessionSummary, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsSessionSummary, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<AsSessionSummary, bool>> m_isHiddenPersonalData;
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
        protected bool bNeedLookupRemove;
        ~AsSessionSummary()
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
                
                if (!bIsClone)
                {
                    Samples.ForEach(c => c.Dispose());
                }
                Samples.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    Diagnosis.ForEach(c => c.Dispose());
                }
                Diagnosis.ClearModelListEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("FarmPanel", this);
                
                LookupManager.RemoveObject("VetFarmTree", this);
                
                LookupManager.RemoveObject("rftAnimalSex", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftAnimalSex")
                _getAccessor().LoadLookup_AnimalSex(manager, this);
            
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
        
            if (_Samples != null) _Samples.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Diagnosis != null) _Diagnosis.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
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
        
            public string strSamplesCalc { get; set; }
        
            public Int32? intSamplesQty { get; set; }
        
            public DateTimeWrap datCollectionDate { get; set; }
        
            public Int32? intPositiveAnimalsQty { get; set; }
        
            public string strDiagnosisCalc { get; set; }
        
        }
        public partial class AsSessionSummaryGridModelList : List<AsSessionSummaryGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public AsSessionSummaryGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsSessionSummary>, errMes);
            }
            public AsSessionSummaryGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsSessionSummary>, errMes);
            }
            public AsSessionSummaryGridModelList(long key, IEnumerable<AsSessionSummary> items)
            {
                LoadGridModelList(key, items, null);
            }
            public AsSessionSummaryGridModelList(long key)
            {
                LoadGridModelList(key, new List<AsSessionSummary>(), null);
            }
            partial void filter(List<AsSessionSummary> items);
            private void LoadGridModelList(long key, IEnumerable<AsSessionSummary> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strFarmCode,_str_strSpecies,_str_strGender,_str_intSampledAnimalsQty,_str_strSamplesCalc,_str_intSamplesQty,_str_datCollectionDate,_str_intPositiveAnimalsQty,_str_strDiagnosisCalc};
                    
                Hiddens = new List<string> {_str_idfMonitoringSessionSummary};
                Keys = new List<string> {_str_idfMonitoringSessionSummary};
                Labels = new Dictionary<string, string> {{_str_strFarmCode, _str_strFarmCode},{_str_strSpecies, _str_strSpecies},{_str_strGender, _str_strGender},{_str_intSampledAnimalsQty, _str_intSampledAnimalsQty},{_str_strSamplesCalc, "AsSessionSummary.strSamples"},{_str_intSamplesQty, _str_intSamplesQty},{_str_datCollectionDate, _str_datCollectionDate},{_str_intPositiveAnimalsQty, _str_intPositiveAnimalsQty},{_str_strDiagnosisCalc, "strDiagnosis"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                AsSessionSummary.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<AsSessionSummary>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new AsSessionSummaryGridModel()
                {
                    ItemKey=c.idfMonitoringSessionSummary,strFarmCode=c.strFarmCode,strSpecies=c.strSpecies,strGender=c.strGender,intSampledAnimalsQty=c.intSampledAnimalsQty,strSamplesCalc=c.strSamplesCalc,intSamplesQty=c.intSamplesQty,datCollectionDate=c.datCollectionDate,intPositiveAnimalsQty=c.intPositiveAnimalsQty,strDiagnosisCalc=c.strDiagnosisCalc
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
            , IObjectCreator<AsSessionSummary>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfMonitoringSessionSummary"; } }
            #endregion
        
            public delegate void on_action(AsSessionSummary obj);
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
            private FarmPanel.Accessor FarmsAccessor { get { return eidss.model.Schema.FarmPanel.Accessor.Instance(m_CS); } }
            private VetFarmTree.Accessor SpeciesAccessor { get { return eidss.model.Schema.VetFarmTree.Accessor.Instance(m_CS); } }
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

            

            public List<AsSessionSummary> _SelectList(DbManagerProxy manager
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
      
            
            public virtual List<AsSessionSummary> _SelectListInternal(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , on_action loading, on_action loaded
                )
            {
                AsSessionSummary _obj = null;
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
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsSessionSummary obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadSamples(manager, obj);
                _LoadDiagnosis(manager, obj);
                }
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

    

            private AsSessionSummary _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                AsSessionSummary obj = null;
                try
                {
                    obj = AsSessionSummary.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfMonitoringSessionSummary = (new GetNewIDExtender<AsSessionSummary>()).GetScalar(manager, obj, isFake);
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
                obj.idfMonitoringSession = new Func<AsSessionSummary, long>(c => c.Parent != null ? ((AsSession)c.Parent).idfMonitoringSession : c.idfMonitoringSession)(obj);
              _LoadSamples(obj);
              _LoadDiagnosis(obj);
            
                obj.Farms = new Func<AsSessionSummary, FarmPanel>(c => c.FarmsLookup.Count() == 1 ? c.FarmsLookup.FirstOrDefault() : null)(obj);
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

            
            public AsSessionSummary CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public AsSessionSummary CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public AsSessionSummary CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(AsSessionSummary obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AsSessionSummary obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datCollectionDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datCollectionDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datCollectionDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("AsSession.SummaryItem.datCollectionDate_msgId", "datCollectionDate", "datCollectionDate", "datCollectionDate",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, c=>AsSessionSummary.ValidateDateInRange(c)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datCollectionDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                                
                            }
                        }
                    
                        if (e.PropertyName == _str_idfFarm)
                        {
                    
                obj.Species = new Func<AsSessionSummary, VetFarmTree>(c => c.SpeciesLookup.Count() == 1 ? c.SpeciesLookup.FirstOrDefault() : null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfFarm)
                        {
                    
                obj.strFarmCode = new Func<AsSessionSummary, string>(c => c.Farms == null ? "" : c.Farms.strFarmCode)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfFarm)
                        {
                    
                obj.idfFarmActual = new Func<AsSessionSummary, long?>(c => c.Farms == null ? null : c.Farms.idfRootFarm)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfSpecies)
                        {
                    
                obj.strSpecies = new Func<AsSessionSummary, string>(c => c.Species == null ? "" : c.Species.strSpeciesName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfSpecies)
                        {
                    
                obj.idfsSpeciesType = new Func<AsSessionSummary, long?>(c => c.Species == null ? null : c.Species.idfsSpeciesTypeReference)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfSpecies)
                        {
                    
              if (obj.SamplesFiltered.Count == 1)
              {
                  obj.SamplesFiltered.ForEach(c => c.blnChecked = true);
              }
            
                        }
                    
                        if (e.PropertyName == _str_intPositiveAnimalsQty)
                        {
                    
              if (obj.intPositiveAnimalsQty > 0)
              {
                  if (obj.DiagnosisList.Count == 1)
                  {
                      obj.DiagnosisList.ForEach(c => c.blnChecked = true);
                  }
              }
              else
              {
                  obj.Diagnosis.ForEach(c => c.blnChecked = false);
              }
            
                        }
                    
                    };
                
            }
    
            public void LoadLookup_AnimalSex(DbManagerProxy manager, AsSessionSummary obj)
            {
                
                obj.AnimalSexLookup.Clear();
                
                obj.AnimalSexLookup.Add(AnimalSexAccessor.CreateNewT(manager, null));
                
                obj.AnimalSexLookup.AddRange(AnimalSexAccessor.rftAnimalSex_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode & (int)HACode.Livestock) != 0)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAnimalSex))
                    
                    .ToList());
                
                if (obj.idfsAnimalSex != null && obj.idfsAnimalSex != 0)
                {
                    obj.AnimalSex = obj.AnimalSexLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsAnimalSex);
                    
                }
              
                LookupManager.AddObject("rftAnimalSex", obj, AnimalSexAccessor.GetType(), "rftAnimalSex_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, AsSessionSummary obj)
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
                bool bSuccess = false;
                int iDeadlockAttemptsCount = BaseSettings.DeadlockAttemptsCount;
                for (int iAttemptNumber = 0; iAttemptNumber < iDeadlockAttemptsCount; iAttemptNumber++)
                {
                    bool bTransactionStarted = false;
                    try
                    {
                        AsSessionSummary bo = obj as AsSessionSummary;
                        
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
                        bSuccess = _PostNonTransaction(manager, obj as AsSessionSummary, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AsSessionSummary obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
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
                obj.strFarmCode = new Func<AsSessionSummary, string>(c => c.Farms == null ? "" : c.Farms.strFarmCode)(obj);
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
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
        
      
            protected ValidationModelException ChainsValidate(AsSessionSummary obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<AsSessionSummary>(obj, "datCollectionDate", c => true, 
      obj.datCollectionDate,
      obj.GetType(),
      false, listdatCollectionDate => {
    listdatCollectionDate.Add(
    new ChainsValidatorDateTime<AsSessionSummary>(obj, "CurrentDate", c => true, 
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
            protected bool ChainsValidate(AsSessionSummary obj, bool bRethrowException)
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
                return Validate(manager, obj as AsSessionSummary, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsSessionSummary obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
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
            
                (new PredicateValidator("AsSessionSummary_PositiveGreaterThanSampled", "intPositiveAnimalsQty", "intPositiveAnimalsQty", "intPositiveAnimalsQty",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, c=>c.intPositiveAnimalsQty == null || c.intPositiveAnimalsQty <= c.intSamplesQty
                    );
            
                ValidateDateInRange(obj);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                (new PredicateValidator("AsSession.SummaryItem.datCollectionDate_msgId", "datCollectionDate", "datCollectionDate", "datCollectionDate",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, c=>AsSessionSummary.ValidateDateInRange(c)
                    );
            
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Samples != null)
                            foreach (var i in obj.Samples.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                SamplesAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Diagnosis != null)
                            foreach (var i in obj.Diagnosis.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                DiagnosisAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
           
    
            private void _SetupRequired(AsSessionSummary obj)
            {
            
                obj
                    .AddRequired("Farms", c => true);
                    
                obj
                    .AddRequired("Species", c => true);
                    
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
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
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
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsSessionSummary, bool>> RequiredByField = new Dictionary<string, Func<AsSessionSummary, bool>>();
            public static Dictionary<string, Func<AsSessionSummary, bool>> RequiredByProperty = new Dictionary<string, Func<AsSessionSummary, bool>>();
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
                
                Sizes.Add(_str_strFarmCode, 200);
                Sizes.Add(_str_strHerdCode, 200);
                Sizes.Add(_str_strSpecies, 2000);
                Sizes.Add(_str_strDiagnosis, 2147483647);
                Sizes.Add(_str_strSamples, 2147483647);
                if (!RequiredByField.ContainsKey("Farms")) RequiredByField.Add("Farms", c => true);
                if (!RequiredByProperty.ContainsKey("Farms")) RequiredByProperty.Add("Farms", c => true);
                
                if (!RequiredByField.ContainsKey("Species")) RequiredByField.Add("Species", c => true);
                if (!RequiredByProperty.ContainsKey("Species")) RequiredByProperty.Add("Species", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfMonitoringSessionSummary,
                    _str_idfMonitoringSessionSummary, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFarmCode,
                    _str_strFarmCode, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpecies,
                    _str_strSpecies, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strGender,
                    _str_strGender, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intSampledAnimalsQty,
                    _str_intSampledAnimalsQty, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSamplesCalc,
                    "AsSessionSummary.strSamples", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intSamplesQty,
                    _str_intSamplesQty, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datCollectionDate,
                    _str_datCollectionDate, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intPositiveAnimalsQty,
                    _str_intPositiveAnimalsQty, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnosisCalc,
                    "strDiagnosis", null, true, true, true, true, true, null
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
	