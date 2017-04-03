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
    public abstract partial class AnimalListItem : 
        EditableObject<AnimalListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfAnimal), NonUpdatable, PrimaryKey]
        public abstract Int64 idfAnimal { get; set; }
                
        [LocalizedDisplayName(_str_idfHerd)]
        [MapField(_str_idfHerd)]
        public abstract Int64 idfHerd { get; set; }
        protected Int64 idfHerd_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfHerd).OriginalValue; } }
        protected Int64 idfHerd_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfHerd).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHerdCode)]
        [MapField(_str_strHerdCode)]
        public abstract String strHerdCode { get; set; }
        protected String strHerdCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strHerdCode).OriginalValue; } }
        protected String strHerdCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHerdCode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64 idfCase { get; set; }
        protected Int64 idfCase_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64 idfCase_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfCase).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsAnimalAge)]
        [MapField(_str_idfsAnimalAge)]
        public abstract Int64? idfsAnimalAge { get; set; }
        protected Int64? idfsAnimalAge_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalAge).OriginalValue; } }
        protected Int64? idfsAnimalAge_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalAge).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsAnimalGender)]
        [MapField(_str_idfsAnimalGender)]
        public abstract Int64? idfsAnimalGender { get; set; }
        protected Int64? idfsAnimalGender_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalGender).OriginalValue; } }
        protected Int64? idfsAnimalGender_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalGender).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strAnimalCode)]
        [MapField(_str_strAnimalCode)]
        public abstract String strAnimalCode { get; set; }
        protected String strAnimalCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strAnimalCode).OriginalValue; } }
        protected String strAnimalCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAnimalCode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDescription)]
        [MapField(_str_strDescription)]
        public abstract String strDescription { get; set; }
        protected String strDescription_Original { get { return ((EditableValue<String>)((dynamic)this)._strDescription).OriginalValue; } }
        protected String strDescription_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDescription).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsAnimalCondition)]
        [MapField(_str_idfsAnimalCondition)]
        public abstract Int64? idfsAnimalCondition { get; set; }
        protected Int64? idfsAnimalCondition_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalCondition).OriginalValue; } }
        protected Int64? idfsAnimalCondition_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalCondition).PreviousValue; } }
                
        [LocalizedDisplayName("strHerdSpecies")]
        [MapField(_str_idfSpecies)]
        public abstract Int64? idfSpecies { get; set; }
        protected Int64? idfSpecies_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).OriginalValue; } }
        protected Int64? idfSpecies_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSpeciesType)]
        [MapField(_str_idfsSpeciesType)]
        public abstract Int64 idfsSpeciesType { get; set; }
        protected Int64 idfsSpeciesType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSpeciesType).OriginalValue; } }
        protected Int64 idfsSpeciesType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSpeciesType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfObservation)]
        [MapField(_str_idfObservation)]
        public abstract Int64? idfObservation { get; set; }
        protected Int64? idfObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObservation).OriginalValue; } }
        protected Int64? idfObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObservation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64? idfsFormTemplate { get; set; }
        protected Int64? idfsFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64? idfsFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strGender)]
        [MapField(_str_strGender)]
        public abstract String strGender { get; set; }
        protected String strGender_Original { get { return ((EditableValue<String>)((dynamic)this)._strGender).OriginalValue; } }
        protected String strGender_Previous { get { return ((EditableValue<String>)((dynamic)this)._strGender).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSpecies)]
        [MapField(_str_strSpecies)]
        public abstract String strSpecies { get; set; }
        protected String strSpecies_Original { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).OriginalValue; } }
        protected String strSpecies_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<AnimalListItem, object> _get_func;
            internal Action<AnimalListItem, string> _set_func;
            internal Action<AnimalListItem, AnimalListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfAnimal = "idfAnimal";
        internal const string _str_idfHerd = "idfHerd";
        internal const string _str_strHerdCode = "strHerdCode";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfsAnimalAge = "idfsAnimalAge";
        internal const string _str_idfsAnimalGender = "idfsAnimalGender";
        internal const string _str_strAnimalCode = "strAnimalCode";
        internal const string _str_strDescription = "strDescription";
        internal const string _str_idfsAnimalCondition = "idfsAnimalCondition";
        internal const string _str_idfSpecies = "idfSpecies";
        internal const string _str_idfsSpeciesType = "idfsSpeciesType";
        internal const string _str_idfObservation = "idfObservation";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_strGender = "strGender";
        internal const string _str_strSpecies = "strSpecies";
        internal const string _str_idfsDiagnosisForCs = "idfsDiagnosisForCs";
        internal const string _str_strClinicalSigns = "strClinicalSigns";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_strHerdSpecies = "strHerdSpecies";
        internal const string _str_strAnimalGender = "strAnimalGender";
        internal const string _str_strAnimalAge = "strAnimalAge";
        internal const string _str_strAnimalCondition = "strAnimalCondition";
        internal const string _str_AnimalGender = "AnimalGender";
        internal const string _str_AnimalAge = "AnimalAge";
        internal const string _str_AnimalCondition = "AnimalCondition";
        internal const string _str_FFPresenterCs = "FFPresenterCs";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfAnimal, _formname = _str_idfAnimal, _type = "Int64",
              _get_func = o => o.idfAnimal,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfAnimal != newval) o.idfAnimal = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfAnimal != c.idfAnimal || o.IsRIRPropChanged(_str_idfAnimal, c)) 
                  m.Add(_str_idfAnimal, o.ObjectIdent + _str_idfAnimal, o.ObjectIdent2 + _str_idfAnimal, o.ObjectIdent3 + _str_idfAnimal, "Int64", 
                    o.idfAnimal == null ? "" : o.idfAnimal.ToString(),                  
                  o.IsReadOnly(_str_idfAnimal), o.IsInvisible(_str_idfAnimal), o.IsRequired(_str_idfAnimal)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfHerd, _formname = _str_idfHerd, _type = "Int64",
              _get_func = o => o.idfHerd,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfHerd != newval) o.idfHerd = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfHerd != c.idfHerd || o.IsRIRPropChanged(_str_idfHerd, c)) 
                  m.Add(_str_idfHerd, o.ObjectIdent + _str_idfHerd, o.ObjectIdent2 + _str_idfHerd, o.ObjectIdent3 + _str_idfHerd, "Int64", 
                    o.idfHerd == null ? "" : o.idfHerd.ToString(),                  
                  o.IsReadOnly(_str_idfHerd), o.IsInvisible(_str_idfHerd), o.IsRequired(_str_idfHerd)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHerdCode, _formname = _str_strHerdCode, _type = "String",
              _get_func = o => o.strHerdCode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHerdCode != newval) o.strHerdCode = newval; },
              _compare_func = (o, c, m) => {
                if (o.strHerdCode != c.strHerdCode || o.IsRIRPropChanged(_str_strHerdCode, c)) 
                  m.Add(_str_strHerdCode, o.ObjectIdent + _str_strHerdCode, o.ObjectIdent2 + _str_strHerdCode, o.ObjectIdent3 + _str_strHerdCode, "String", 
                    o.strHerdCode == null ? "" : o.strHerdCode.ToString(),                  
                  o.IsReadOnly(_str_strHerdCode), o.IsInvisible(_str_strHerdCode), o.IsRequired(_str_strHerdCode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfCase, _formname = _str_idfCase, _type = "Int64",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfCase != newval) o.idfCase = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, o.ObjectIdent2 + _str_idfCase, o.ObjectIdent3 + _str_idfCase, "Int64", 
                    o.idfCase == null ? "" : o.idfCase.ToString(),                  
                  o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAnimalAge, _formname = _str_idfsAnimalAge, _type = "Int64?",
              _get_func = o => o.idfsAnimalAge,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsAnimalAge != newval) 
                  o.AnimalAge = o.AnimalAgeLookup.FirstOrDefault(c => c.idfsReference == newval);
                if (o.idfsAnimalAge != newval) o.idfsAnimalAge = newval; },
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalGender != c.idfsAnimalGender || o.IsRIRPropChanged(_str_idfsAnimalGender, c)) 
                  m.Add(_str_idfsAnimalGender, o.ObjectIdent + _str_idfsAnimalGender, o.ObjectIdent2 + _str_idfsAnimalGender, o.ObjectIdent3 + _str_idfsAnimalGender, "Int64?", 
                    o.idfsAnimalGender == null ? "" : o.idfsAnimalGender.ToString(),                  
                  o.IsReadOnly(_str_idfsAnimalGender), o.IsInvisible(_str_idfsAnimalGender), o.IsRequired(_str_idfsAnimalGender)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strAnimalCode, _formname = _str_strAnimalCode, _type = "String",
              _get_func = o => o.strAnimalCode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strAnimalCode != newval) o.strAnimalCode = newval; },
              _compare_func = (o, c, m) => {
                if (o.strAnimalCode != c.strAnimalCode || o.IsRIRPropChanged(_str_strAnimalCode, c)) 
                  m.Add(_str_strAnimalCode, o.ObjectIdent + _str_strAnimalCode, o.ObjectIdent2 + _str_strAnimalCode, o.ObjectIdent3 + _str_strAnimalCode, "String", 
                    o.strAnimalCode == null ? "" : o.strAnimalCode.ToString(),                  
                  o.IsReadOnly(_str_strAnimalCode), o.IsInvisible(_str_strAnimalCode), o.IsRequired(_str_strAnimalCode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDescription, _formname = _str_strDescription, _type = "String",
              _get_func = o => o.strDescription,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDescription != newval) o.strDescription = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDescription != c.strDescription || o.IsRIRPropChanged(_str_strDescription, c)) 
                  m.Add(_str_strDescription, o.ObjectIdent + _str_strDescription, o.ObjectIdent2 + _str_strDescription, o.ObjectIdent3 + _str_strDescription, "String", 
                    o.strDescription == null ? "" : o.strDescription.ToString(),                  
                  o.IsReadOnly(_str_strDescription), o.IsInvisible(_str_strDescription), o.IsRequired(_str_strDescription)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAnimalCondition, _formname = _str_idfsAnimalCondition, _type = "Int64?",
              _get_func = o => o.idfsAnimalCondition,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsAnimalCondition != newval) 
                  o.AnimalCondition = o.AnimalConditionLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsAnimalCondition != newval) o.idfsAnimalCondition = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalCondition != c.idfsAnimalCondition || o.IsRIRPropChanged(_str_idfsAnimalCondition, c)) 
                  m.Add(_str_idfsAnimalCondition, o.ObjectIdent + _str_idfsAnimalCondition, o.ObjectIdent2 + _str_idfsAnimalCondition, o.ObjectIdent3 + _str_idfsAnimalCondition, "Int64?", 
                    o.idfsAnimalCondition == null ? "" : o.idfsAnimalCondition.ToString(),                  
                  o.IsReadOnly(_str_idfsAnimalCondition), o.IsInvisible(_str_idfsAnimalCondition), o.IsRequired(_str_idfsAnimalCondition)); 
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
              _name = _str_idfsSpeciesType, _formname = _str_idfsSpeciesType, _type = "Int64",
              _get_func = o => o.idfsSpeciesType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsSpeciesType != newval) o.idfsSpeciesType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_idfsSpeciesType, c)) 
                  m.Add(_str_idfsSpeciesType, o.ObjectIdent + _str_idfsSpeciesType, o.ObjectIdent2 + _str_idfsSpeciesType, o.ObjectIdent3 + _str_idfsSpeciesType, "Int64", 
                    o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(),                  
                  o.IsReadOnly(_str_idfsSpeciesType), o.IsInvisible(_str_idfsSpeciesType), o.IsRequired(_str_idfsSpeciesType)); 
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
              _name = _str_strGender, _formname = _str_strGender, _type = "String",
              _get_func = o => o.strGender,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strGender != newval) o.strGender = newval; },
              _compare_func = (o, c, m) => {
                if (o.strGender != c.strGender || o.IsRIRPropChanged(_str_strGender, c)) 
                  m.Add(_str_strGender, o.ObjectIdent + _str_strGender, o.ObjectIdent2 + _str_strGender, o.ObjectIdent3 + _str_strGender, "String", 
                    o.strGender == null ? "" : o.strGender.ToString(),                  
                  o.IsReadOnly(_str_strGender), o.IsInvisible(_str_strGender), o.IsRequired(_str_strGender)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSpecies, _formname = _str_strSpecies, _type = "String",
              _get_func = o => o.strSpecies,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSpecies != newval) o.strSpecies = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSpecies != c.strSpecies || o.IsRIRPropChanged(_str_strSpecies, c)) 
                  m.Add(_str_strSpecies, o.ObjectIdent + _str_strSpecies, o.ObjectIdent2 + _str_strSpecies, o.ObjectIdent3 + _str_strSpecies, "String", 
                    o.strSpecies == null ? "" : o.strSpecies.ToString(),                  
                  o.IsReadOnly(_str_strSpecies), o.IsInvisible(_str_strSpecies), o.IsRequired(_str_strSpecies)); 
                  }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosisForCs, _formname = _str_idfsDiagnosisForCs, _type = "long?",
              _get_func = o => o.idfsDiagnosisForCs,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsDiagnosisForCs != newval) o.idfsDiagnosisForCs = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsDiagnosisForCs != c.idfsDiagnosisForCs || o.IsRIRPropChanged(_str_idfsDiagnosisForCs, c)) {
                  m.Add(_str_idfsDiagnosisForCs, o.ObjectIdent + _str_idfsDiagnosisForCs, o.ObjectIdent2 + _str_idfsDiagnosisForCs, o.ObjectIdent3 + _str_idfsDiagnosisForCs,  "long?", 
                    o.idfsDiagnosisForCs == null ? "" : o.idfsDiagnosisForCs.ToString(),                  
                    o.IsReadOnly(_str_idfsDiagnosisForCs), o.IsInvisible(_str_idfsDiagnosisForCs), o.IsRequired(_str_idfsDiagnosisForCs));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_strClinicalSigns, _formname = _str_strClinicalSigns, _type = "string",
              _get_func = o => o.strClinicalSigns,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strClinicalSigns != newval) o.strClinicalSigns = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.strClinicalSigns != c.strClinicalSigns || o.IsRIRPropChanged(_str_strClinicalSigns, c)) {
                  m.Add(_str_strClinicalSigns, o.ObjectIdent + _str_strClinicalSigns, o.ObjectIdent2 + _str_strClinicalSigns, o.ObjectIdent3 + _str_strClinicalSigns,  "string", 
                    o.strClinicalSigns == null ? "" : o.strClinicalSigns.ToString(),                  
                    o.IsReadOnly(_str_strClinicalSigns), o.IsInvisible(_str_strClinicalSigns), o.IsRequired(_str_strClinicalSigns));
                  }
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
              _name = _str_strHerdSpecies, _formname = _str_strHerdSpecies, _type = "string",
              _get_func = o => o.strHerdSpecies,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strHerdSpecies != c.strHerdSpecies || o.IsRIRPropChanged(_str_strHerdSpecies, c)) {
                  m.Add(_str_strHerdSpecies, o.ObjectIdent + _str_strHerdSpecies, o.ObjectIdent2 + _str_strHerdSpecies, o.ObjectIdent3 + _str_strHerdSpecies, "string", o.strHerdSpecies == null ? "" : o.strHerdSpecies.ToString(), o.IsReadOnly(_str_strHerdSpecies), o.IsInvisible(_str_strHerdSpecies), o.IsRequired(_str_strHerdSpecies));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strAnimalGender, _formname = _str_strAnimalGender, _type = "string",
              _get_func = o => o.strAnimalGender,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strAnimalGender != c.strAnimalGender || o.IsRIRPropChanged(_str_strAnimalGender, c)) {
                  m.Add(_str_strAnimalGender, o.ObjectIdent + _str_strAnimalGender, o.ObjectIdent2 + _str_strAnimalGender, o.ObjectIdent3 + _str_strAnimalGender, "string", o.strAnimalGender == null ? "" : o.strAnimalGender.ToString(), o.IsReadOnly(_str_strAnimalGender), o.IsInvisible(_str_strAnimalGender), o.IsRequired(_str_strAnimalGender));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strAnimalAge, _formname = _str_strAnimalAge, _type = "string",
              _get_func = o => o.strAnimalAge,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strAnimalAge != c.strAnimalAge || o.IsRIRPropChanged(_str_strAnimalAge, c)) {
                  m.Add(_str_strAnimalAge, o.ObjectIdent + _str_strAnimalAge, o.ObjectIdent2 + _str_strAnimalAge, o.ObjectIdent3 + _str_strAnimalAge, "string", o.strAnimalAge == null ? "" : o.strAnimalAge.ToString(), o.IsReadOnly(_str_strAnimalAge), o.IsInvisible(_str_strAnimalAge), o.IsRequired(_str_strAnimalAge));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strAnimalCondition, _formname = _str_strAnimalCondition, _type = "string",
              _get_func = o => o.strAnimalCondition,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strAnimalCondition != c.strAnimalCondition || o.IsRIRPropChanged(_str_strAnimalCondition, c)) {
                  m.Add(_str_strAnimalCondition, o.ObjectIdent + _str_strAnimalCondition, o.ObjectIdent2 + _str_strAnimalCondition, o.ObjectIdent3 + _str_strAnimalCondition, "string", o.strAnimalCondition == null ? "" : o.strAnimalCondition.ToString(), o.IsReadOnly(_str_strAnimalCondition), o.IsInvisible(_str_strAnimalCondition), o.IsRequired(_str_strAnimalCondition));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_AnimalGender, _formname = _str_AnimalGender, _type = "Lookup",
              _get_func = o => { if (o.AnimalGender == null) return null; return o.AnimalGender.idfsBaseReference; },
              _set_func = (o, val) => { o.AnimalGender = o.AnimalGenderLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalGender != c.idfsAnimalGender || o.IsRIRPropChanged(_str_AnimalGender, c)) {
                  m.Add(_str_AnimalGender, o.ObjectIdent + _str_AnimalGender, o.ObjectIdent2 + _str_AnimalGender, o.ObjectIdent3 + _str_AnimalGender, "Lookup", o.idfsAnimalGender == null ? "" : o.idfsAnimalGender.ToString(), o.IsReadOnly(_str_AnimalGender), o.IsInvisible(_str_AnimalGender), o.IsRequired(_str_AnimalGender)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_AnimalGender + "Lookup", _formname = _str_AnimalGender + "Lookup", _type = "LookupContent",
              _get_func = o => o.AnimalGenderLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_AnimalAge, _formname = _str_AnimalAge, _type = "Lookup",
              _get_func = o => { if (o.AnimalAge == null) return null; return o.AnimalAge.idfsReference; },
              _set_func = (o, val) => { o.AnimalAge = o.AnimalAgeLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalAge != c.idfsAnimalAge || o.IsRIRPropChanged(_str_AnimalAge, c)) {
                  m.Add(_str_AnimalAge, o.ObjectIdent + _str_AnimalAge, o.ObjectIdent2 + _str_AnimalAge, o.ObjectIdent3 + _str_AnimalAge, "Lookup", o.idfsAnimalAge == null ? "" : o.idfsAnimalAge.ToString(), o.IsReadOnly(_str_AnimalAge), o.IsInvisible(_str_AnimalAge), o.IsRequired(_str_AnimalAge)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_AnimalAge + "Lookup", _formname = _str_AnimalAge + "Lookup", _type = "LookupContent",
              _get_func = o => o.AnimalAgeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_AnimalCondition, _formname = _str_AnimalCondition, _type = "Lookup",
              _get_func = o => { if (o.AnimalCondition == null) return null; return o.AnimalCondition.idfsBaseReference; },
              _set_func = (o, val) => { o.AnimalCondition = o.AnimalConditionLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalCondition != c.idfsAnimalCondition || o.IsRIRPropChanged(_str_AnimalCondition, c)) {
                  m.Add(_str_AnimalCondition, o.ObjectIdent + _str_AnimalCondition, o.ObjectIdent2 + _str_AnimalCondition, o.ObjectIdent3 + _str_AnimalCondition, "Lookup", o.idfsAnimalCondition == null ? "" : o.idfsAnimalCondition.ToString(), o.IsReadOnly(_str_AnimalCondition), o.IsInvisible(_str_AnimalCondition), o.IsRequired(_str_AnimalCondition)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_AnimalCondition + "Lookup", _formname = _str_AnimalCondition + "Lookup", _type = "LookupContent",
              _get_func = o => o.AnimalConditionLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_FFPresenterCs, _formname = _str_FFPresenterCs, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.FFPresenterCs != null) o.FFPresenterCs._compare(c.FFPresenterCs, m); }
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
            AnimalListItem obj = (AnimalListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_FFPresenterCs)]
        [Relation(typeof(FFPresenterModel), eidss.model.Schema.FFPresenterModel._str_CurrentObservation, _str_idfObservation)]
        public FFPresenterModel FFPresenterCs
        {
            get 
            {   
                return _FFPresenterCs; 
            }
            set 
            {   
                _FFPresenterCs = value;
                if (_FFPresenterCs != null) 
                { 
                    _FFPresenterCs.m_ObjectName = _str_FFPresenterCs;
                    _FFPresenterCs.Parent = this;
                }
                idfObservation = _FFPresenterCs == null 
                        ? new Int64?()
                        : _FFPresenterCs.CurrentObservation;
                
            }
        }
        protected FFPresenterModel _FFPresenterCs;
                    
        [LocalizedDisplayName(_str_AnimalGender)]
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
            
        [LocalizedDisplayName(_str_AnimalAge)]
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
            
        [LocalizedDisplayName(_str_AnimalCondition)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAnimalCondition)]
        public BaseReference AnimalCondition
        {
            get { return _AnimalCondition == null ? null : ((long)_AnimalCondition.Key == 0 ? null : _AnimalCondition); }
            set 
            { 
                var oldVal = _AnimalCondition;
                _AnimalCondition = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_AnimalCondition != oldVal)
                {
                    if (idfsAnimalCondition != (_AnimalCondition == null
                            ? new Int64?()
                            : (Int64?)_AnimalCondition.idfsBaseReference))
                        idfsAnimalCondition = _AnimalCondition == null 
                            ? new Int64?()
                            : (Int64?)_AnimalCondition.idfsBaseReference; 
                    OnPropertyChanged(_str_AnimalCondition); 
                }
            }
        }
        private BaseReference _AnimalCondition;

        
        public BaseReferenceList AnimalConditionLookup
        {
            get { return _AnimalConditionLookup; }
        }
        private BaseReferenceList _AnimalConditionLookup = new BaseReferenceList("rftAnimalCondition");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_AnimalGender:
                    return new BvSelectList(AnimalGenderLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AnimalGender, _str_idfsAnimalGender);
            
                case _str_AnimalAge:
                    return new BvSelectList(AnimalAgeLookup, eidss.model.Schema.AnimalAgeLookup._str_idfsReference, null, AnimalAge, _str_idfsAnimalAge);
            
                case _str_AnimalCondition:
                    return new BvSelectList(AnimalConditionLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AnimalCondition, _str_idfsAnimalCondition);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<AnimalListItem, string>(c => "VetCase_" + c.idfCase + "_")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strHerdSpecies)]
        public string strHerdSpecies
        {
            get { return new Func<AnimalListItem, string>(c=>String.Format("{0}/{1}", c.strHerdCode, c.strSpecies))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strAnimalGender)]
        public string strAnimalGender
        {
            get { return new Func<AnimalListItem, string>(c => c.AnimalGender == null ? "" : c.AnimalGender.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strAnimalAge)]
        public string strAnimalAge
        {
            get { return new Func<AnimalListItem, string>(c => c.AnimalAge == null ? "" : c.AnimalAge.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strAnimalCondition)]
        public string strAnimalCondition
        {
            get { return new Func<AnimalListItem, string>(c => c.AnimalCondition == null ? "" : c.AnimalCondition.name)(this); }
            
        }
        
          [LocalizedDisplayName(_str_idfsDiagnosisForCs)]
        public long? idfsDiagnosisForCs
        {
            get { return m_idfsDiagnosisForCs; }
            set { if (m_idfsDiagnosisForCs != value) { m_idfsDiagnosisForCs = value; OnPropertyChanged(_str_idfsDiagnosisForCs); } }
        }
        private long? m_idfsDiagnosisForCs;
        
          [LocalizedDisplayName(_str_strClinicalSigns)]
        public string strClinicalSigns
        {
            get { return m_strClinicalSigns; }
            set { if (m_strClinicalSigns != value) { m_strClinicalSigns = value; OnPropertyChanged(_str_strClinicalSigns); } }
        }
        private string m_strClinicalSigns;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AnimalListItem";

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
        
            if (_FFPresenterCs != null) { _FFPresenterCs.Parent = this; }
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as AnimalListItem;
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
            var ret = base.Clone() as AnimalListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_FFPresenterCs != null)
              ret.FFPresenterCs = _FFPresenterCs.CloneWithSetup(manager, bRestricted) as FFPresenterModel;
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public AnimalListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AnimalListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfAnimal; } }
        public string KeyName { get { return "idfAnimal"; } }
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
        
                    || (_FFPresenterCs != null && _FFPresenterCs.HasChanges)
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsAnimalGender_AnimalGender = idfsAnimalGender;
            var _prev_idfsAnimalAge_AnimalAge = idfsAnimalAge;
            var _prev_idfsAnimalCondition_AnimalCondition = idfsAnimalCondition;
            base.RejectChanges();
        
            if (_prev_idfsAnimalGender_AnimalGender != idfsAnimalGender)
            {
                _AnimalGender = _AnimalGenderLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAnimalGender);
            }
            if (_prev_idfsAnimalAge_AnimalAge != idfsAnimalAge)
            {
                _AnimalAge = _AnimalAgeLookup.FirstOrDefault(c => c.idfsReference == idfsAnimalAge);
            }
            if (_prev_idfsAnimalCondition_AnimalCondition != idfsAnimalCondition)
            {
                _AnimalCondition = _AnimalConditionLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAnimalCondition);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (FFPresenterCs != null) FFPresenterCs.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_FFPresenterCs != null) _FFPresenterCs.DeepAcceptChanges();
                
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
        
            if (_FFPresenterCs != null) _FFPresenterCs.SetChange();
                
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

        private bool IsRIRPropChanged(string fld, AnimalListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      
        public override string ToString()
        {
            return new Func<AnimalListItem, string>(c => (string.IsNullOrEmpty(c.strAnimalCode) || string.IsNullOrEmpty(c.strSpecies)) ? "" : c.strAnimalCode + " / " + c.strSpecies + " / " + c.strAnimalGender)(this);
        }
        

        public AnimalListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AnimalListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AnimalListItem_PropertyChanged);
        }
        private void AnimalListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AnimalListItem).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfCase)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
            if (e.PropertyName == _str_idfSpecies)
                OnPropertyChanged(_str_strHerdSpecies);
                  
            if (e.PropertyName == _str_idfsAnimalGender)
                OnPropertyChanged(_str_strAnimalGender);
                  
            if (e.PropertyName == _str_idfsAnimalAge)
                OnPropertyChanged(_str_strAnimalAge);
                  
            if (e.PropertyName == _str_idfsAnimalCondition)
                OnPropertyChanged(_str_strAnimalCondition);
                  
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
            AnimalListItem obj = this;
            try
            {
            
                (new PredicateValidator("msgCantDeleteAnimal", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => (c.Parent as VetCase).Samples.Count(s => s.idfParty == c.idfAnimal && !s.IsMarkedToDelete) == 0
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
            AnimalListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AnimalListItem obj = this;
            
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
        
                if (_FFPresenterCs != null)
                    _FFPresenterCs.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<AnimalListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<AnimalListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AnimalListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AnimalListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<AnimalListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<AnimalListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<AnimalListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AnimalListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                if (_FFPresenterCs != null)
                    FFPresenterCs.Dispose();
                
                LookupManager.RemoveObject("rftAnimalSex", this);
                
                LookupManager.RemoveObject("AnimalAgeLookup", this);
                
                LookupManager.RemoveObject("rftAnimalCondition", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftAnimalSex")
                _getAccessor().LoadLookup_AnimalGender(manager, this);
            
            if (lookup_object == "AnimalAgeLookup")
                _getAccessor().LoadLookup_AnimalAge(manager, this);
            
            if (lookup_object == "rftAnimalCondition")
                _getAccessor().LoadLookup_AnimalCondition(manager, this);
            
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
        
            if (_FFPresenterCs != null) _FFPresenterCs.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
            ParsedFormCollection(form);
        }
    
        #region Class for web grid
        public class AnimalListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfAnimal { get; set; }
        
            public string strHerdSpecies { get; set; }
        
            public String strAnimalCode { get; set; }
        
            public string strAnimalAge { get; set; }
        
            public string strAnimalGender { get; set; }
        
            public string strClinicalSigns { get; set; }
        
            public string strAnimalCondition { get; set; }
        
        }
        public partial class AnimalListItemGridModelList : List<AnimalListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public AnimalListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AnimalListItem>, errMes);
            }
            public AnimalListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AnimalListItem>, errMes);
            }
            public AnimalListItemGridModelList(long key, IEnumerable<AnimalListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public AnimalListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<AnimalListItem>(), null);
            }
            partial void filter(List<AnimalListItem> items);
            private void LoadGridModelList(long key, IEnumerable<AnimalListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strHerdSpecies,_str_strAnimalCode,_str_strAnimalAge,_str_strAnimalGender,_str_strClinicalSigns,_str_strAnimalCondition};
                    
                Hiddens = new List<string> {_str_idfAnimal};
                Keys = new List<string> {_str_idfAnimal};
                Labels = new Dictionary<string, string> {{_str_strHerdSpecies, _str_strHerdSpecies},{_str_strAnimalCode, _str_strAnimalCode},{_str_strAnimalAge, _str_strAnimalAge},{_str_strAnimalGender, _str_strAnimalGender},{_str_strClinicalSigns, _str_strClinicalSigns},{_str_strAnimalCondition, _str_strAnimalCondition}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                AnimalListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<AnimalListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new AnimalListItemGridModel()
                {
                    ItemKey=c.idfAnimal,strHerdSpecies=c.strHerdSpecies,strAnimalCode=c.strAnimalCode,strAnimalAge=c.strAnimalAge,strAnimalGender=c.strAnimalGender,strClinicalSigns=c.strClinicalSigns,strAnimalCondition=c.strAnimalCondition
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
        : DataAccessor<AnimalListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<AnimalListItem>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfAnimal"; } }
            #endregion
        
            private delegate void on_action(AnimalListItem obj);
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
            private FFPresenterModel.Accessor FFPresenterCsAccessor { get { return eidss.model.Schema.FFPresenterModel.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AnimalGenderAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private AnimalAgeLookup.Accessor AnimalAgeAccessor { get { return eidss.model.Schema.AnimalAgeLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AnimalConditionAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<AnimalListItem> SelectList(DbManagerProxy manager
                , Int64? idfCase
                )
            {
                return _SelectList(manager
                    , idfCase
                    , delegate(AnimalListItem obj)
                        {
                        }
                    , delegate(AnimalListItem obj)
                        {
                        }
                    );
            }

            
            private List<AnimalListItem> _SelectList(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<AnimalListItem> objs = new List<AnimalListItem>();
                    sets[0] = new MapResultSet(typeof(AnimalListItem), objs);
                    
                    manager
                        .SetSpCommand("spVetCaseAnimals_SelectDetail"
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
    
            internal void _LoadFFPresenterCs(AnimalListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFFPresenterCs(manager, obj);
                }
            }
            internal void _LoadFFPresenterCs(DbManagerProxy manager, AnimalListItem obj)
            {
                
                if (obj.FFPresenterCs == null && obj.idfObservation != null && obj.idfObservation != 0)
                {
                    obj.FFPresenterCs = FFPresenterCsAccessor.SelectByKey(manager
                        
                        , obj.idfObservation.Value
                        );
                    if (obj.FFPresenterCs != null)
                    {
                        obj.FFPresenterCs.m_ObjectName = _str_FFPresenterCs;
                    }
                }
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, AnimalListItem obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadFFPresenterCs(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
              if (obj.idfsFormTemplate.HasValue)
              {
                obj.FFPresenterCs.SetProperties(obj.idfsFormTemplate.Value, obj.idfAnimal);
                obj.strClinicalSigns = AnimalListItem.GetClinicalSigns(obj.FFPresenterCs);
              }
              else
              {
                if (obj.idfObservation == null)
                obj.idfObservation = (new GetNewIDExtender<AnimalListItem>()).GetScalar(manager, obj);
                obj.FFPresenterCs = FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, obj.idfObservation);
                obj.FFPresenterCs.SetProperties(EidssSiteContext.Instance.CountryID, obj.idfsDiagnosisForCs, FFTypeEnum.LivestockAnimalCS, obj.idfObservation.Value, obj.idfAnimal);
                if (obj.FFPresenterCs.CurrentTemplate != null) obj.idfsFormTemplate = obj.FFPresenterCs.CurrentTemplate.idfsFormTemplate;
              }
            
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, AnimalListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    FFPresenterCsAccessor._SetPermitions(obj._permissions, obj.FFPresenterCs);
                    
                    }
                }
            }

    

            private AnimalListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    AnimalListItem obj = AnimalListItem.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfAnimal = (new GetNewIDExtender<AnimalListItem>()).GetScalar(manager, obj, isFake);
                obj.strAnimalCode = new Func<AnimalListItem, string>(c => c.Parent as VetCase == null ? "" : String.Format("(new {0})", (c.Parent as VetCase).AnimalList.Count(a=>!a.IsMarkedToDelete)+1))(obj);
                obj.idfObservation = (new GetNewIDExtender<AnimalListItem>()).GetScalar(manager, obj, isFake);
                obj.FFPresenterCs = new Func<AnimalListItem, FFPresenterModel>(c => FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, obj.idfObservation))(obj);
              obj.FFPresenterCs = FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, obj.idfObservation);
              obj.FFPresenterCs.SetProperties(EidssSiteContext.Instance.CountryID, obj.idfsDiagnosisForCs, FFTypeEnum.LivestockAnimalCS, obj.idfObservation.Value, obj.idfAnimal);
              if (obj.FFPresenterCs.CurrentTemplate != null) obj.idfsFormTemplate = obj.FFPresenterCs.CurrentTemplate.idfsFormTemplate;
            
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

            
            public AnimalListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public AnimalListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public AnimalListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public AnimalListItem CreateAnimalT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long?)) 
                    throw new TypeMismatchException("diagnosis", typeof(long?));
                
                return CreateAnimal(manager, Parent
                    , (long?)pars[0]
                    );
            }
            public IObject CreateAnimal(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateAnimalT(manager, Parent, pars);
            }
            public AnimalListItem CreateAnimal(DbManagerProxy manager, IObject Parent
                , long? diagnosis
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfsDiagnosisForCs = new Func<AnimalListItem, long?>(c => diagnosis)(obj);
                obj.idfCase = new Func<AnimalListItem, long>(c => (Parent as VetCase).idfCase)(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(AnimalListItem obj, object newobj)
            {
                
                    if (newobj == null || newobj == obj.FFPresenterCs)
                    {
                        var o = obj.FFPresenterCs;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "ActivityParameters")
                                {
                                
                obj.strClinicalSigns = new Func<AnimalListItem, string>(c=>AnimalListItem.GetClinicalSigns(c.FFPresenterCs))(obj);
                                }
                            };
                        }    
                        
                    }
                            
            }
            
            private void _SetupHandlers(AnimalListItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsSpeciesType)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_AnimalAge(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfSpecies)
                        {
                    
                obj.idfsSpeciesType = new Func<AnimalListItem, long>(c=>c.idfSpecies.HasValue && (c.Parent as VetCase != null) && (c.Parent as VetCase).Farm.FarmTree.Single(i=>i.idfParty == c.idfSpecies).idfsSpeciesTypeReference.HasValue ? (c.Parent as VetCase).Farm.FarmTree.Single(i=>i.idfParty == c.idfSpecies).idfsSpeciesTypeReference.Value : default(long))(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosisForCs)
                        {
                    
              UpdateTemplate(obj);
            
                        }
                    
                    };
                
            }
    
            public void LoadLookup_AnimalGender(DbManagerProxy manager, AnimalListItem obj)
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
              
                
                LookupManager.AddObject("rftAnimalSex", obj, AnimalGenderAccessor.GetType(), "rftAnimalSex_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_AnimalAge(DbManagerProxy manager, AnimalListItem obj)
            {
                
                obj.AnimalAgeLookup.Clear();
                
                obj.AnimalAgeLookup.Add(AnimalAgeAccessor.CreateNewT(manager, null));
                
                obj.AnimalAgeLookup.AddRange(AnimalAgeAccessor.SelectLookupList(manager
                    
                    , new Func<AnimalListItem, string>(c => c.idfsSpeciesType.ToString())(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsAnimalAge))
                    
                    .ToList());
                
                if (obj.idfsAnimalAge != null && obj.idfsAnimalAge != 0)
                {
                    obj.AnimalAge = obj.AnimalAgeLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsAnimalAge);
                    
                }
              
                
                LookupManager.AddObject("AnimalAgeLookup", obj, AnimalAgeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_AnimalCondition(DbManagerProxy manager, AnimalListItem obj)
            {
                
                obj.AnimalConditionLookup.Clear();
                
                obj.AnimalConditionLookup.Add(AnimalConditionAccessor.CreateNewT(manager, null));
                
                obj.AnimalConditionLookup.AddRange(AnimalConditionAccessor.rftAnimalCondition_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAnimalCondition))
                    
                    .ToList());
                
                if (obj.idfsAnimalCondition != null && obj.idfsAnimalCondition != 0)
                {
                    obj.AnimalCondition = obj.AnimalConditionLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsAnimalCondition);
                    
                }
              
                
                LookupManager.AddObject("rftAnimalCondition", obj, AnimalConditionAccessor.GetType(), "rftAnimalCondition_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, AnimalListItem obj)
            {
                
                LoadLookup_AnimalGender(manager, obj);
                
                LoadLookup_AnimalAge(manager, obj);
                
                LoadLookup_AnimalCondition(manager, obj);
                
            }
    
            [SprocName("spVetCaseAnimals_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strAnimalCode")] AnimalListItem obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strAnimalCode")] AnimalListItem obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    AnimalListItem bo = obj as AnimalListItem;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as AnimalListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AnimalListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.FFPresenterCs != null)
                    {
                        obj.FFPresenterCs.MarkToDelete();
                        if (!FFPresenterCsAccessor.Post(manager, obj.FFPresenterCs, true))
                            return false;
                    }
                                    
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
                                    
                    if (obj.IsNew)
                    {
                        if (obj.FFPresenterCs != null) // forced load potential lazy subobject for new object
                            if (!FFPresenterCsAccessor.Post(manager, obj.FFPresenterCs, true))
                                return false;
                    }
                    else
                    {
                        if (obj._FFPresenterCs != null) // do not load lazy subobject for existing object
                            if (!FFPresenterCsAccessor.Post(manager, obj.FFPresenterCs, true))
                                return false;
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(AnimalListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AnimalListItem obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(AnimalListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(AnimalListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as AnimalListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AnimalListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfSpecies", "idfSpecies","",
                false
              )).Validate(c => true, obj, obj.idfSpecies);
            
                CustomValidations(obj);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.FFPresenterCs != null)
                            FFPresenterCsAccessor.Validate(manager, obj.FFPresenterCs, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
           
    
            private void _SetupRequired(AnimalListItem obj)
            {
            
                obj
                    .AddRequired("idfSpecies", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(AnimalListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AnimalListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AnimalListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AnimalListItemDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spVetCaseAnimals_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spVetCaseAnimals_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AnimalListItem, bool>> RequiredByField = new Dictionary<string, Func<AnimalListItem, bool>>();
            public static Dictionary<string, Func<AnimalListItem, bool>> RequiredByProperty = new Dictionary<string, Func<AnimalListItem, bool>>();
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
                
                Sizes.Add(_str_strHerdCode, 200);
                Sizes.Add(_str_strAnimalCode, 200);
                Sizes.Add(_str_strDescription, 200);
                Sizes.Add(_str_strGender, 2000);
                Sizes.Add(_str_strSpecies, 2000);
                if (!RequiredByField.ContainsKey("idfSpecies")) RequiredByField.Add("idfSpecies", c => true);
                if (!RequiredByProperty.ContainsKey("idfSpecies")) RequiredByProperty.Add("idfSpecies", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfAnimal,
                    _str_idfAnimal, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strHerdSpecies,
                    _str_strHerdSpecies, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAnimalCode,
                    _str_strAnimalCode, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAnimalAge,
                    _str_strAnimalAge, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAnimalGender,
                    _str_strAnimalGender, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strClinicalSigns,
                    _str_strClinicalSigns, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAnimalCondition,
                    _str_strAnimalCondition, null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "CreateAnimal",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateAnimal(manager, c, pars)),
                        
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
                    (manager, c, pars) => ((AnimalListItem)c).MarkToDelete(),
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
	