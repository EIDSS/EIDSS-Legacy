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
    public abstract partial class VetFarmTree : 
        EditableObject<VetFarmTree>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [LocalizedDisplayName(_str_idfFarm)]
        [MapField(_str_idfFarm)]
        public abstract Int64 idfFarm { get; set; }
        protected Int64 idfFarm_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfFarm).OriginalValue; } }
        protected Int64 idfFarm_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfFarm).PreviousValue; } }
                
        [MapField(_str_idfParty), NonUpdatable, PrimaryKey]
        public abstract Int64 idfParty { get; set; }
                
        [LocalizedDisplayName(_str_idfMonitoringSession)]
        [MapField(_str_idfMonitoringSession)]
        public abstract Int64? idfMonitoringSession { get; set; }
        protected Int64? idfMonitoringSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).OriginalValue; } }
        protected Int64? idfMonitoringSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64? idfCase { get; set; }
        protected Int64? idfCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64? idfCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsPartyType)]
        [MapField(_str_idfsPartyType)]
        public abstract Int64? idfsPartyType { get; set; }
        protected Int64? idfsPartyType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPartyType).OriginalValue; } }
        protected Int64? idfsPartyType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPartyType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strName)]
        [MapField(_str_strName)]
        public abstract String strName { get; set; }
        protected String strName_Original { get { return ((EditableValue<String>)((dynamic)this)._strName).OriginalValue; } }
        protected String strName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfParentParty)]
        [MapField(_str_idfParentParty)]
        public abstract Int64? idfParentParty { get; set; }
        protected Int64? idfParentParty_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParentParty).OriginalValue; } }
        protected Int64? idfParentParty_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParentParty).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_intTotalAnimalQty)]
        [MapField(_str_intTotalAnimalQty)]
        public abstract Int32? intTotalAnimalQty { get; set; }
        protected Int32? intTotalAnimalQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intTotalAnimalQty).OriginalValue; } }
        protected Int32? intTotalAnimalQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intTotalAnimalQty).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intSickAnimalQty)]
        [MapField(_str_intSickAnimalQty)]
        public abstract Int32? intSickAnimalQty { get; set; }
        protected Int32? intSickAnimalQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intSickAnimalQty).OriginalValue; } }
        protected Int32? intSickAnimalQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intSickAnimalQty).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intDeadAnimalQty)]
        [MapField(_str_intDeadAnimalQty)]
        public abstract Int32? intDeadAnimalQty { get; set; }
        protected Int32? intDeadAnimalQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intDeadAnimalQty).OriginalValue; } }
        protected Int32? intDeadAnimalQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intDeadAnimalQty).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strAverageAge)]
        [MapField(_str_strAverageAge)]
        public abstract Int32? strAverageAge { get; set; }
        protected Int32? strAverageAge_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._strAverageAge).OriginalValue; } }
        protected Int32? strAverageAge_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._strAverageAge).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datStartOfSignsDate)]
        [MapField(_str_datStartOfSignsDate)]
        public abstract DateTime? datStartOfSignsDate { get; set; }
        protected DateTime? datStartOfSignsDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartOfSignsDate).OriginalValue; } }
        protected DateTime? datStartOfSignsDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartOfSignsDate).PreviousValue; } }
                
        [LocalizedDisplayName("VetFarmTree.strNote")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<VetFarmTree, object> _get_func;
            internal Action<VetFarmTree, string> _set_func;
            internal Action<VetFarmTree, VetFarmTree, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfFarm = "idfFarm";
        internal const string _str_idfParty = "idfParty";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfsPartyType = "idfsPartyType";
        internal const string _str_strName = "strName";
        internal const string _str_idfParentParty = "idfParentParty";
        internal const string _str_idfObservation = "idfObservation";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_intTotalAnimalQty = "intTotalAnimalQty";
        internal const string _str_intSickAnimalQty = "intSickAnimalQty";
        internal const string _str_intDeadAnimalQty = "intDeadAnimalQty";
        internal const string _str_strAverageAge = "strAverageAge";
        internal const string _str_datStartOfSignsDate = "datStartOfSignsDate";
        internal const string _str_strNote = "strNote";
        internal const string _str_Case = "Case";
        internal const string _str_VetFarmPanel = "VetFarmPanel";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_VetFarmTreeList = "VetFarmTreeList";
        internal const string _str_idfsDiagnosisForCs = "idfsDiagnosisForCs";
        internal const string _str_idfsSpeciesTypeReference = "idfsSpeciesTypeReference";
        internal const string _str_lOrderingSequence = "lOrderingSequence";
        internal const string _str_strSpeciesName = "strSpeciesName";
        internal const string _str_strHerdName = "strHerdName";
        internal const string _str_strFlockName = "strFlockName";
        internal const string _str_bInMonitoringSession = "bInMonitoringSession";
        internal const string _str_SpeciesType = "SpeciesType";
        internal const string _str_FFPresenterCs = "FFPresenterCs";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfFarm, _formname = _str_idfFarm, _type = "Int64",
              _get_func = o => o.idfFarm,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfFarm != newval) o.idfFarm = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfFarm != c.idfFarm || o.IsRIRPropChanged(_str_idfFarm, c)) 
                  m.Add(_str_idfFarm, o.ObjectIdent + _str_idfFarm, o.ObjectIdent2 + _str_idfFarm, o.ObjectIdent3 + _str_idfFarm, "Int64", 
                    o.idfFarm == null ? "" : o.idfFarm.ToString(),                  
                  o.IsReadOnly(_str_idfFarm), o.IsInvisible(_str_idfFarm), o.IsRequired(_str_idfFarm)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfParty, _formname = _str_idfParty, _type = "Int64",
              _get_func = o => o.idfParty,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfParty != newval) o.idfParty = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_idfParty, c)) 
                  m.Add(_str_idfParty, o.ObjectIdent + _str_idfParty, o.ObjectIdent2 + _str_idfParty, o.ObjectIdent3 + _str_idfParty, "Int64", 
                    o.idfParty == null ? "" : o.idfParty.ToString(),                  
                  o.IsReadOnly(_str_idfParty), o.IsInvisible(_str_idfParty), o.IsRequired(_str_idfParty)); 
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
              _name = _str_idfCase, _formname = _str_idfCase, _type = "Int64?",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfCase != newval) o.idfCase = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, o.ObjectIdent2 + _str_idfCase, o.ObjectIdent3 + _str_idfCase, "Int64?", 
                    o.idfCase == null ? "" : o.idfCase.ToString(),                  
                  o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsPartyType, _formname = _str_idfsPartyType, _type = "Int64?",
              _get_func = o => o.idfsPartyType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsPartyType != newval) o.idfsPartyType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsPartyType != c.idfsPartyType || o.IsRIRPropChanged(_str_idfsPartyType, c)) 
                  m.Add(_str_idfsPartyType, o.ObjectIdent + _str_idfsPartyType, o.ObjectIdent2 + _str_idfsPartyType, o.ObjectIdent3 + _str_idfsPartyType, "Int64?", 
                    o.idfsPartyType == null ? "" : o.idfsPartyType.ToString(),                  
                  o.IsReadOnly(_str_idfsPartyType), o.IsInvisible(_str_idfsPartyType), o.IsRequired(_str_idfsPartyType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strName, _formname = _str_strName, _type = "String",
              _get_func = o => o.strName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strName != newval) o.strName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strName != c.strName || o.IsRIRPropChanged(_str_strName, c)) 
                  m.Add(_str_strName, o.ObjectIdent + _str_strName, o.ObjectIdent2 + _str_strName, o.ObjectIdent3 + _str_strName, "String", 
                    o.strName == null ? "" : o.strName.ToString(),                  
                  o.IsReadOnly(_str_strName), o.IsInvisible(_str_strName), o.IsRequired(_str_strName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfParentParty, _formname = _str_idfParentParty, _type = "Int64?",
              _get_func = o => o.idfParentParty,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfParentParty != newval) o.idfParentParty = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfParentParty != c.idfParentParty || o.IsRIRPropChanged(_str_idfParentParty, c)) 
                  m.Add(_str_idfParentParty, o.ObjectIdent + _str_idfParentParty, o.ObjectIdent2 + _str_idfParentParty, o.ObjectIdent3 + _str_idfParentParty, "Int64?", 
                    o.idfParentParty == null ? "" : o.idfParentParty.ToString(),                  
                  o.IsReadOnly(_str_idfParentParty), o.IsInvisible(_str_idfParentParty), o.IsRequired(_str_idfParentParty)); 
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
              _name = _str_intTotalAnimalQty, _formname = _str_intTotalAnimalQty, _type = "Int32?",
              _get_func = o => o.intTotalAnimalQty,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intTotalAnimalQty != newval) o.intTotalAnimalQty = newval; },
              _compare_func = (o, c, m) => {
                if (o.intTotalAnimalQty != c.intTotalAnimalQty || o.IsRIRPropChanged(_str_intTotalAnimalQty, c)) 
                  m.Add(_str_intTotalAnimalQty, o.ObjectIdent + _str_intTotalAnimalQty, o.ObjectIdent2 + _str_intTotalAnimalQty, o.ObjectIdent3 + _str_intTotalAnimalQty, "Int32?", 
                    o.intTotalAnimalQty == null ? "" : o.intTotalAnimalQty.ToString(),                  
                  o.IsReadOnly(_str_intTotalAnimalQty), o.IsInvisible(_str_intTotalAnimalQty), o.IsRequired(_str_intTotalAnimalQty)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intSickAnimalQty, _formname = _str_intSickAnimalQty, _type = "Int32?",
              _get_func = o => o.intSickAnimalQty,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intSickAnimalQty != newval) o.intSickAnimalQty = newval; },
              _compare_func = (o, c, m) => {
                if (o.intSickAnimalQty != c.intSickAnimalQty || o.IsRIRPropChanged(_str_intSickAnimalQty, c)) 
                  m.Add(_str_intSickAnimalQty, o.ObjectIdent + _str_intSickAnimalQty, o.ObjectIdent2 + _str_intSickAnimalQty, o.ObjectIdent3 + _str_intSickAnimalQty, "Int32?", 
                    o.intSickAnimalQty == null ? "" : o.intSickAnimalQty.ToString(),                  
                  o.IsReadOnly(_str_intSickAnimalQty), o.IsInvisible(_str_intSickAnimalQty), o.IsRequired(_str_intSickAnimalQty)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intDeadAnimalQty, _formname = _str_intDeadAnimalQty, _type = "Int32?",
              _get_func = o => o.intDeadAnimalQty,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intDeadAnimalQty != newval) o.intDeadAnimalQty = newval; },
              _compare_func = (o, c, m) => {
                if (o.intDeadAnimalQty != c.intDeadAnimalQty || o.IsRIRPropChanged(_str_intDeadAnimalQty, c)) 
                  m.Add(_str_intDeadAnimalQty, o.ObjectIdent + _str_intDeadAnimalQty, o.ObjectIdent2 + _str_intDeadAnimalQty, o.ObjectIdent3 + _str_intDeadAnimalQty, "Int32?", 
                    o.intDeadAnimalQty == null ? "" : o.intDeadAnimalQty.ToString(),                  
                  o.IsReadOnly(_str_intDeadAnimalQty), o.IsInvisible(_str_intDeadAnimalQty), o.IsRequired(_str_intDeadAnimalQty)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strAverageAge, _formname = _str_strAverageAge, _type = "Int32?",
              _get_func = o => o.strAverageAge,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.strAverageAge != newval) o.strAverageAge = newval; },
              _compare_func = (o, c, m) => {
                if (o.strAverageAge != c.strAverageAge || o.IsRIRPropChanged(_str_strAverageAge, c)) 
                  m.Add(_str_strAverageAge, o.ObjectIdent + _str_strAverageAge, o.ObjectIdent2 + _str_strAverageAge, o.ObjectIdent3 + _str_strAverageAge, "Int32?", 
                    o.strAverageAge == null ? "" : o.strAverageAge.ToString(),                  
                  o.IsReadOnly(_str_strAverageAge), o.IsInvisible(_str_strAverageAge), o.IsRequired(_str_strAverageAge)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datStartOfSignsDate, _formname = _str_datStartOfSignsDate, _type = "DateTime?",
              _get_func = o => o.datStartOfSignsDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datStartOfSignsDate != newval) o.datStartOfSignsDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datStartOfSignsDate != c.datStartOfSignsDate || o.IsRIRPropChanged(_str_datStartOfSignsDate, c)) 
                  m.Add(_str_datStartOfSignsDate, o.ObjectIdent + _str_datStartOfSignsDate, o.ObjectIdent2 + _str_datStartOfSignsDate, o.ObjectIdent3 + _str_datStartOfSignsDate, "DateTime?", 
                    o.datStartOfSignsDate == null ? "" : o.datStartOfSignsDate.ToString(),                  
                  o.IsReadOnly(_str_datStartOfSignsDate), o.IsInvisible(_str_datStartOfSignsDate), o.IsRequired(_str_datStartOfSignsDate)); 
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
              _name = _str_Case, _formname = _str_Case, _type = "WeakReference",
              _get_func = o => o.Case,
              _set_func = (o, val) => { var newval = o.Case; if (o.Case != newval) o.Case = newval; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_VetFarmTreeList, _formname = _str_VetFarmTreeList, _type = "WeakReference",
              _get_func = o => o.VetFarmTreeList,
              _set_func = (o, val) => { var newval = o.VetFarmTreeList; if (o.VetFarmTreeList != newval) o.VetFarmTreeList = newval; },
              _compare_func = (o, c, m) => {
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
              _name = _str_strHerdName, _formname = _str_strHerdName, _type = "string",
              _get_func = o => o.strHerdName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHerdName != newval) o.strHerdName = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.strHerdName != c.strHerdName || o.IsRIRPropChanged(_str_strHerdName, c)) {
                  m.Add(_str_strHerdName, o.ObjectIdent + _str_strHerdName, o.ObjectIdent2 + _str_strHerdName, o.ObjectIdent3 + _str_strHerdName,  "string", 
                    o.strHerdName == null ? "" : o.strHerdName.ToString(),                  
                    o.IsReadOnly(_str_strHerdName), o.IsInvisible(_str_strHerdName), o.IsRequired(_str_strHerdName));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_VetFarmPanel, _formname = _str_VetFarmPanel, _type = "FarmPanel",
              _get_func = o => o.VetFarmPanel,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_idfsCaseType, _formname = _str_idfsCaseType, _type = "long?",
              _get_func = o => o.idfsCaseType,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_idfsCaseType, c)) {
                  m.Add(_str_idfsCaseType, o.ObjectIdent + _str_idfsCaseType, o.ObjectIdent2 + _str_idfsCaseType, o.ObjectIdent3 + _str_idfsCaseType, "long?", o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(), o.IsReadOnly(_str_idfsCaseType), o.IsInvisible(_str_idfsCaseType), o.IsRequired(_str_idfsCaseType));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_idfsSpeciesTypeReference, _formname = _str_idfsSpeciesTypeReference, _type = "long?",
              _get_func = o => o.idfsSpeciesTypeReference,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsSpeciesTypeReference != c.idfsSpeciesTypeReference || o.IsRIRPropChanged(_str_idfsSpeciesTypeReference, c)) {
                  m.Add(_str_idfsSpeciesTypeReference, o.ObjectIdent + _str_idfsSpeciesTypeReference, o.ObjectIdent2 + _str_idfsSpeciesTypeReference, o.ObjectIdent3 + _str_idfsSpeciesTypeReference, "long?", o.idfsSpeciesTypeReference == null ? "" : o.idfsSpeciesTypeReference.ToString(), o.IsReadOnly(_str_idfsSpeciesTypeReference), o.IsInvisible(_str_idfsSpeciesTypeReference), o.IsRequired(_str_idfsSpeciesTypeReference));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_lOrderingSequence, _formname = _str_lOrderingSequence, _type = "long?",
              _get_func = o => o.lOrderingSequence,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.lOrderingSequence != c.lOrderingSequence || o.IsRIRPropChanged(_str_lOrderingSequence, c)) {
                  m.Add(_str_lOrderingSequence, o.ObjectIdent + _str_lOrderingSequence, o.ObjectIdent2 + _str_lOrderingSequence, o.ObjectIdent3 + _str_lOrderingSequence, "long?", o.lOrderingSequence == null ? "" : o.lOrderingSequence.ToString(), o.IsReadOnly(_str_lOrderingSequence), o.IsInvisible(_str_lOrderingSequence), o.IsRequired(_str_lOrderingSequence));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strSpeciesName, _formname = _str_strSpeciesName, _type = "string",
              _get_func = o => o.strSpeciesName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strSpeciesName != c.strSpeciesName || o.IsRIRPropChanged(_str_strSpeciesName, c)) {
                  m.Add(_str_strSpeciesName, o.ObjectIdent + _str_strSpeciesName, o.ObjectIdent2 + _str_strSpeciesName, o.ObjectIdent3 + _str_strSpeciesName, "string", o.strSpeciesName == null ? "" : o.strSpeciesName.ToString(), o.IsReadOnly(_str_strSpeciesName), o.IsInvisible(_str_strSpeciesName), o.IsRequired(_str_strSpeciesName));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strFlockName, _formname = _str_strFlockName, _type = "string",
              _get_func = o => o.strFlockName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strFlockName != c.strFlockName || o.IsRIRPropChanged(_str_strFlockName, c)) {
                  m.Add(_str_strFlockName, o.ObjectIdent + _str_strFlockName, o.ObjectIdent2 + _str_strFlockName, o.ObjectIdent3 + _str_strFlockName, "string", o.strFlockName == null ? "" : o.strFlockName.ToString(), o.IsReadOnly(_str_strFlockName), o.IsInvisible(_str_strFlockName), o.IsRequired(_str_strFlockName));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_bInMonitoringSession, _formname = _str_bInMonitoringSession, _type = "bool",
              _get_func = o => o.bInMonitoringSession,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.bInMonitoringSession != c.bInMonitoringSession || o.IsRIRPropChanged(_str_bInMonitoringSession, c)) {
                  m.Add(_str_bInMonitoringSession, o.ObjectIdent + _str_bInMonitoringSession, o.ObjectIdent2 + _str_bInMonitoringSession, o.ObjectIdent3 + _str_bInMonitoringSession, "bool", o.bInMonitoringSession == null ? "" : o.bInMonitoringSession.ToString(), o.IsReadOnly(_str_bInMonitoringSession), o.IsInvisible(_str_bInMonitoringSession), o.IsRequired(_str_bInMonitoringSession));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_SpeciesType, _formname = _str_SpeciesType, _type = "Lookup",
              _get_func = o => { if (o.SpeciesType == null) return null; return o.SpeciesType.idfsBaseReference; },
              _set_func = (o, val) => { o.SpeciesType = o.SpeciesTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesTypeReference != c.idfsSpeciesTypeReference || o.IsRIRPropChanged(_str_SpeciesType, c)) {
                  m.Add(_str_SpeciesType, o.ObjectIdent + _str_SpeciesType, o.ObjectIdent2 + _str_SpeciesType, o.ObjectIdent3 + _str_SpeciesType, "Lookup", o.idfsSpeciesTypeReference == null ? "" : o.idfsSpeciesTypeReference.ToString(), o.IsReadOnly(_str_SpeciesType), o.IsInvisible(_str_SpeciesType), o.IsRequired(_str_SpeciesType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SpeciesType + "Lookup", _formname = _str_SpeciesType + "Lookup", _type = "LookupContent",
              _get_func = o => o.SpeciesTypeLookup,
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
            VetFarmTree obj = (VetFarmTree)o;
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
                    
        [LocalizedDisplayName(_str_SpeciesType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSpeciesTypeReference)]
        public BaseReference SpeciesType
        {
            get { return _SpeciesType == null ? null : ((long)_SpeciesType.Key == 0 ? null : _SpeciesType); }
            set 
            { 
                var oldVal = _SpeciesType;
                _SpeciesType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SpeciesType != oldVal)
                {
                    if (idfsSpeciesTypeReference != (_SpeciesType == null
                            ? new long?()
                            : _SpeciesType.idfsBaseReference))
                        idfsSpeciesTypeReference = _SpeciesType == null 
                            ? new long?()
                            : _SpeciesType.idfsBaseReference; 
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
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_SpeciesType:
                    return new BvSelectList(SpeciesTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SpeciesType, _str_idfsSpeciesTypeReference);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_VetFarmPanel)]
        public FarmPanel VetFarmPanel
        {
            get { return new Func<VetFarmTree, FarmPanel>(c => c.Parent as FarmPanel)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsCaseType)]
        public long? idfsCaseType
        {
            get { return new Func<VetFarmTree, long?>(c => c.VetFarmPanel == null || c.VetFarmPanel.VCase == null ? 0 : c.VetFarmPanel.VCase.idfsCaseType)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsSpeciesTypeReference)]
        public long? idfsSpeciesTypeReference
        {
            get { return new Func<VetFarmTree, long?>(c => ExprUtils.LongFromString(c.strName))(this); }
            
            set { strName = ExprUtils.StringFromObject(value); OnPropertyChanged(_str_idfsSpeciesTypeReference); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_lOrderingSequence)]
        public long? lOrderingSequence
        {
            get { return new Func<VetFarmTree, long?>(c=>c.idfsPartyType == (long)PartyTypeEnum.Species ? c.idfParentParty : c.idfParty)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strSpeciesName)]
        public string strSpeciesName
        {
            get { return new Func<VetFarmTree, string>(c=>c.idfsPartyType == (long)PartyTypeEnum.Species && c.idfsSpeciesTypeReference.HasValue ? SpeciesType.name : "")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("Flock")]
        public string strFlockName
        {
            get { return new Func<VetFarmTree, string>(c=>c.strHerdName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_bInMonitoringSession)]
        public bool bInMonitoringSession
        {
            get { return new Func<VetFarmTree, bool>(c => c.idfMonitoringSession.HasValue && c.idfMonitoringSession.Value != 0)(this); }
            
        }
        
          [LocalizedDisplayName(_str_Case)]
        public WeakReference Case
        {
            get { return m_Case; }
            set { if (m_Case != value) { m_Case = value; OnPropertyChanged(_str_Case); } }
        }
        private WeakReference m_Case;
        
          [LocalizedDisplayName(_str_VetFarmTreeList)]
        public WeakReference VetFarmTreeList
        {
            get { return m_VetFarmTreeList; }
            set { if (m_VetFarmTreeList != value) { m_VetFarmTreeList = value; OnPropertyChanged(_str_VetFarmTreeList); } }
        }
        private WeakReference m_VetFarmTreeList;
        
          [LocalizedDisplayName(_str_idfsDiagnosisForCs)]
        public long? idfsDiagnosisForCs
        {
            get { return m_idfsDiagnosisForCs; }
            set { if (m_idfsDiagnosisForCs != value) { m_idfsDiagnosisForCs = value; OnPropertyChanged(_str_idfsDiagnosisForCs); } }
        }
        private long? m_idfsDiagnosisForCs;
        
          [LocalizedDisplayName(_str_strHerdName)]
        public string strHerdName
        {
            get { return m_strHerdName; }
            set { if (m_strHerdName != value) { m_strHerdName = value; OnPropertyChanged(_str_strHerdName); } }
        }
        private string m_strHerdName;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "VetFarmTree";

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
            var ret = base.Clone() as VetFarmTree;
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
            var ret = base.Clone() as VetFarmTree;
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
        public VetFarmTree CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VetFarmTree;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfParty; } }
        public string KeyName { get { return "idfParty"; } }
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
        
            var _prev_idfsSpeciesTypeReference_SpeciesType = idfsSpeciesTypeReference;
            base.RejectChanges();
        
            if (_prev_idfsSpeciesTypeReference_SpeciesType != idfsSpeciesTypeReference)
            {
                _SpeciesType = _SpeciesTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSpeciesTypeReference);
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

        private bool IsRIRPropChanged(string fld, VetFarmTree c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      
        public override string ToString()
        {
            return new Func<VetFarmTree, string>(c => c.idfsPartyType == (long)PartyTypeEnum.Species ? (string.IsNullOrEmpty(c.strFlockName) ? c.strHerdName : c.strFlockName) + " / " + c.strSpeciesName : (string.IsNullOrEmpty(c.strFlockName) ? c.strHerdName : c.strFlockName))(this);
        }
        

        public VetFarmTree()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);

        
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VetFarmTree_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VetFarmTree_PropertyChanged);
        }
        private void VetFarmTree_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VetFarmTree).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_VetFarmPanel);
                  
            if (e.PropertyName == _str_VetFarmPanel)
                OnPropertyChanged(_str_idfsCaseType);
                  
            if (e.PropertyName == _str_strName)
                OnPropertyChanged(_str_idfsSpeciesTypeReference);
                  
            if (e.PropertyName == _str_idfParentParty)
                OnPropertyChanged(_str_lOrderingSequence);
                  
            if (e.PropertyName == _str_idfsPartyType)
                OnPropertyChanged(_str_strSpeciesName);
                  
            if (e.PropertyName == _str_strHerdName)
                OnPropertyChanged(_str_strFlockName);
                  
            if (e.PropertyName == _str_idfMonitoringSession)
                OnPropertyChanged(_str_bInMonitoringSession);
                  
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
            VetFarmTree obj = this;
            try
            {
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.idfsPartyType != (long)PartyTypeEnum.Farm &&
                                        (c.VetFarmTreeList.Target as EditableList<VetFarmTree>)
                                        .Where(i => !i.IsMarkedToDelete && i.idfParentParty == c.idfParty).Count() == 0
                    );
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.idfsPartyType != (long)PartyTypeEnum.Species 
                                        || (c.idfsPartyType == (long)PartyTypeEnum.Species && ((c.Case != null && 
                                        (c.Case.Target as VetCase).AnimalList.Where(i => !i.IsMarkedToDelete && i.idfSpecies == c.idfParty).Count() == 0)
                                            || c.Case == null))
                    );
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.idfsPartyType != (long)PartyTypeEnum.Species 
                                        || (c.idfsPartyType == (long)PartyTypeEnum.Species && ((c.Case != null && 
                                        (c.Case.Target as VetCase).Samples.Where(i => !i.IsMarkedToDelete && i.idfParty == c.idfParty).Count() == 0)
                                            || c.Case == null))
                    );
            
                (new PredicateValidator("msgCantDeleteASLivestockSpecies", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.idfsPartyType != (long)PartyTypeEnum.Species || (c.Parent as FarmPanel).ASSession == null ||
                                        (c.idfsPartyType == (long)PartyTypeEnum.Species && (c.Parent as FarmPanel).ASSession != null && !(c.Parent as FarmPanel).ASSession.ASAnimalsSamples.Any(i => !i.IsMarkedToDelete && i.idfSpecies == c.idfParty))
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
            VetFarmTree obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VetFarmTree obj = this;
            
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


        internal Dictionary<string, Func<VetFarmTree, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VetFarmTree, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VetFarmTree, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VetFarmTree, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VetFarmTree, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<VetFarmTree, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<VetFarmTree, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~VetFarmTree()
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
                
                LookupManager.RemoveObject("rftSpeciesList", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftSpeciesList")
                _getAccessor().LoadLookup_SpeciesType(manager, this);
            
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
        public class VetFarmTreeGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfParty { get; set; }
        
            public string strHerdName { get; set; }
        
            public string strFlockName { get; set; }
        
            public string strSpeciesName { get; set; }
        
            public int? intTotalAnimalQty { get; set; }
        
            public int? intSickAnimalQty { get; set; }
        
            public int? intDeadAnimalQty { get; set; }
        
            public string strNote { get; set; }
        
            public Int32? strAverageAge { get; set; }
        
            public DateTime? datStartOfSignsDate { get; set; }
        
            public long? idfsPartyType { get; set; }
        
            public long? idfParentParty { get; set; }
        
        }
        public partial class VetFarmTreeGridModelList : List<VetFarmTreeGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public VetFarmTreeGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VetFarmTree>, errMes);
            }
            public VetFarmTreeGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VetFarmTree>, errMes);
            }
            public VetFarmTreeGridModelList(long key, IEnumerable<VetFarmTree> items)
            {
                LoadGridModelList(key, items, null);
            }
            public VetFarmTreeGridModelList(long key)
            {
                LoadGridModelList(key, new List<VetFarmTree>(), null);
            }
            partial void filter(List<VetFarmTree> items);
            private void LoadGridModelList(long key, IEnumerable<VetFarmTree> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strHerdName,_str_strFlockName,_str_strSpeciesName,_str_intTotalAnimalQty,_str_intSickAnimalQty,_str_intDeadAnimalQty,_str_strNote,_str_strAverageAge,_str_datStartOfSignsDate};
                    
                Hiddens = new List<string> {_str_idfParty,_str_idfsPartyType,_str_idfParentParty};
                Keys = new List<string> {_str_idfParty};
                Labels = new Dictionary<string, string> {{_str_strHerdName, _str_strHerdName},{_str_strFlockName, "Flock"},{_str_strSpeciesName, _str_strSpeciesName},{_str_intTotalAnimalQty, _str_intTotalAnimalQty},{_str_intSickAnimalQty, _str_intSickAnimalQty},{_str_intDeadAnimalQty, _str_intDeadAnimalQty},{_str_strNote, "VetFarmTree.strNote"},{_str_strAverageAge, _str_strAverageAge},{_str_datStartOfSignsDate, _str_datStartOfSignsDate}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                VetFarmTree.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<VetFarmTree>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VetFarmTreeGridModel()
                {
                    ItemKey=c.idfParty,strHerdName=c.strHerdName,strFlockName=c.strFlockName,strSpeciesName=c.strSpeciesName,intTotalAnimalQty=c.intTotalAnimalQty,intSickAnimalQty=c.intSickAnimalQty,intDeadAnimalQty=c.intDeadAnimalQty,strNote=c.strNote,strAverageAge=c.strAverageAge,datStartOfSignsDate=c.datStartOfSignsDate,idfsPartyType=c.idfsPartyType,idfParentParty=c.idfParentParty
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
        : DataAccessor<VetFarmTree>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<VetFarmTree>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfParty"; } }
            #endregion
        
            private delegate void on_action(VetFarmTree obj);
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
            private BaseReference.Accessor SpeciesTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , HACode
                    
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<VetFarmTree> SelectList(DbManagerProxy manager
                , Int64? idfFarm
                , int? HACode
                
                )
            {
                return _SelectList(manager
                    , idfFarm
                    , HACode
                    
                    , delegate(VetFarmTree obj)
                        {
                        }
                    , delegate(VetFarmTree obj)
                        {
                        }
                    );
            }

            
            private List<VetFarmTree> _SelectList(DbManagerProxy manager
                , Int64? idfFarm
                , int? HACode
                
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VetFarmTree> objs = new List<VetFarmTree>();
                    sets[0] = new MapResultSet(typeof(VetFarmTree), objs);
                    
                    manager
                        .SetSpCommand("spFarmTree_SelectDetail"
                            , manager.Parameter("@idfFarm", idfFarm)
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
    
            internal void _LoadFFPresenterCs(VetFarmTree obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFFPresenterCs(manager, obj);
                }
            }
            internal void _LoadFFPresenterCs(DbManagerProxy manager, VetFarmTree obj)
            {
              
                if (new Func<VetFarmTree, bool>(c => !c.bInMonitoringSession)(obj))
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
              
              }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, VetFarmTree obj, bool bCloning = false)
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
                obj.strHerdName = new Func<VetFarmTree, string>(c => c.GetHerdName())(obj);
                    if (!bCloning && !obj.bInMonitoringSession)
                    {
                      if (obj.idfsFormTemplate.HasValue)
                      {
                        obj.FFPresenterCs.SetProperties(obj.idfsFormTemplate.Value, obj.idfParty);
                      }
                      else
                      {
                        if (obj.idfObservation == null)
                          obj.idfObservation = (new GetNewIDExtender<VetFarmTree>()).GetScalar(manager, obj);
                    
                        obj.FFPresenterCs = FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, obj.idfObservation);
                        obj.FFPresenterCs.SetProperties(EidssSiteContext.Instance.CountryID, obj.idfsDiagnosisForCs, obj._HACode == (int)eidss.model.Enums.HACode.Livestock ? FFTypeEnum.LivestockSpeciesCS : FFTypeEnum.AvianSpeciesCS, obj.idfObservation.Value, obj.idfParty);
                        if (obj.FFPresenterCs.CurrentTemplate != null) obj.idfsFormTemplate = obj.FFPresenterCs.CurrentTemplate.idfsFormTemplate;
                      }
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
            
            internal void _SetPermitions(IObjectPermissions permissions, VetFarmTree obj)
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

    

            private VetFarmTree _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    VetFarmTree obj = VetFarmTree.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    obj._HACode = HACode;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.strHerdName = new Func<VetFarmTree, string>(c => c.GetHerdName())(obj);
                obj.idfObservation = (new GetNewIDExtender<VetFarmTree>()).GetScalar(manager, obj, isFake);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                  if (!obj.bInMonitoringSession)
                  {
                    obj.FFPresenterCs = FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, obj.idfObservation);
                    obj.FFPresenterCs.SetProperties(EidssSiteContext.Instance.CountryID, obj.idfsDiagnosisForCs, (obj._HACode.HasValue ? obj._HACode.Value : 0) == (int)eidss.model.Enums.HACode.Livestock ? FFTypeEnum.LivestockSpeciesCS : FFTypeEnum.AvianSpeciesCS, obj.idfObservation.Value, obj.idfParty);
                    if (obj.FFPresenterCs.CurrentTemplate != null) obj.idfsFormTemplate = obj.FFPresenterCs.CurrentTemplate.idfsFormTemplate;
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

            
            public VetFarmTree CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public VetFarmTree CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public VetFarmTree CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public VetFarmTree CreateFarmT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is FarmPanel)) 
                    throw new TypeMismatchException("farm", typeof(FarmPanel));
                
                return CreateFarm(manager, Parent
                    , (FarmPanel)pars[0]
                    );
            }
            public IObject CreateFarm(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateFarmT(manager, Parent, pars);
            }
            public VetFarmTree CreateFarm(DbManagerProxy manager, IObject Parent
                , FarmPanel farm
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.VetFarmTreeList = new Func<VetFarmTree, WeakReference>(c => new WeakReference(farm.FarmTree))(obj);
                obj.Case = new Func<VetFarmTree, WeakReference>(c => farm.Case)(obj);
                obj._HACode = new Func<VetFarmTree, int?>(c => farm._HACode)(obj);
                obj.idfCase = new Func<VetFarmTree, long?>(c => farm.idfCase ?? 0)(obj);
                obj.idfMonitoringSession = new Func<VetFarmTree, long?>(c => farm.idfMonitoringSession ?? 0)(obj);
                obj.idfParty = new Func<VetFarmTree, long>(c => farm.idfFarm)(obj);
                obj.strName = new Func<VetFarmTree, string>(c => farm.strFarmCode)(obj);
                obj.strHerdName = new Func<VetFarmTree, string>(c => farm.strFarmCode)(obj);
                obj.idfsPartyType = new Func<VetFarmTree, long>(c => (long)PartyTypeEnum.Farm)(obj);
                obj.idfObservation = (new GetNewIDExtender<VetFarmTree>()).GetScalar(manager, obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            public VetFarmTree CreateHerdT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is VetFarmTree)) 
                    throw new TypeMismatchException("parent", typeof(VetFarmTree));
                
                return CreateHerd(manager, Parent
                    , (VetFarmTree)pars[0]
                    );
            }
            public IObject CreateHerd(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateHerdT(manager, Parent, pars);
            }
            public VetFarmTree CreateHerd(DbManagerProxy manager, IObject Parent
                , VetFarmTree parent
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.VetFarmTreeList = new Func<VetFarmTree, WeakReference>(c => parent.VetFarmTreeList)(obj);
                obj.Case = new Func<VetFarmTree, WeakReference>(c => parent.Case)(obj);
                obj._HACode = new Func<VetFarmTree, int?>(c => parent._HACode)(obj);
                obj.idfCase = new Func<VetFarmTree, long?>(c => parent.idfCase)(obj);
                obj.idfMonitoringSession = new Func<VetFarmTree, long?>(c => parent.idfMonitoringSession ?? 0)(obj);
                obj.idfParty = (new GetNewIDExtender<VetFarmTree>()).GetScalar(manager, obj);
                obj.idfParentParty = new Func<VetFarmTree, long?>(c => parent.idfParty)(obj);
                obj.idfsPartyType = new Func<VetFarmTree, long>(c => (long)PartyTypeEnum.Herd)(obj);
                obj.strName = new Func<VetFarmTree, string>(c => String.Format("(new {0})", 1 + parent.VetFarmPanel.FarmTree.Count(x => x.idfsPartyType == (long)PartyTypeEnum.Herd && x.IsNew)))(obj);
                obj.strHerdName = obj.strName;
                }
                    , obj =>
                {
                }
                );
            }
            
            public VetFarmTree CreateSpeciesWithDiagnosisT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 2) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is VetFarmTree)) 
                    throw new TypeMismatchException("parent", typeof(VetFarmTree));
                if (pars[1] != null && !(pars[1] is long?)) 
                    throw new TypeMismatchException("diagnosis", typeof(long?));
                
                return CreateSpeciesWithDiagnosis(manager, Parent
                    , (VetFarmTree)pars[0]
                    , (long?)pars[1]
                    );
            }
            public IObject CreateSpeciesWithDiagnosis(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateSpeciesWithDiagnosisT(manager, Parent, pars);
            }
            public VetFarmTree CreateSpeciesWithDiagnosis(DbManagerProxy manager, IObject Parent
                , VetFarmTree parent
                , long? diagnosis
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.VetFarmTreeList = new Func<VetFarmTree, WeakReference>(c => parent.VetFarmTreeList)(obj);
                obj.Case = new Func<VetFarmTree, WeakReference>(c => parent.Case)(obj);
                obj._HACode = new Func<VetFarmTree, int?>(c => parent._HACode)(obj);
                obj.idfCase = new Func<VetFarmTree, long?>(c => parent.idfCase)(obj);
                obj.idfMonitoringSession = new Func<VetFarmTree, long?>(c => parent.idfMonitoringSession ?? 0)(obj);
                obj.idfParty = (new GetNewIDExtender<VetFarmTree>()).GetScalar(manager, obj);
                obj.idfParentParty = new Func<VetFarmTree, long?>(c => parent.idfParty)(obj);
                obj.idfsPartyType = new Func<VetFarmTree, long>(c => (long)PartyTypeEnum.Species)(obj);
                obj.idfObservation = (new GetNewIDExtender<VetFarmTree>()).GetScalar(manager, obj);
                obj.idfsDiagnosisForCs = new Func<VetFarmTree, long?>(c => diagnosis)(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            public VetFarmTree CreateSpeciesT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is VetFarmTree)) 
                    throw new TypeMismatchException("parent", typeof(VetFarmTree));
                
                return CreateSpecies(manager, Parent
                    , (VetFarmTree)pars[0]
                    );
            }
            public IObject CreateSpecies(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateSpeciesT(manager, Parent, pars);
            }
            public VetFarmTree CreateSpecies(DbManagerProxy manager, IObject Parent
                , VetFarmTree parent
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.VetFarmTreeList = new Func<VetFarmTree, WeakReference>(c => parent.VetFarmTreeList)(obj);
                obj.Case = new Func<VetFarmTree, WeakReference>(c => parent.Case)(obj);
                obj._HACode = new Func<VetFarmTree, int?>(c => parent._HACode)(obj);
                obj.idfCase = new Func<VetFarmTree, long?>(c => parent.idfCase)(obj);
                obj.idfMonitoringSession = new Func<VetFarmTree, long?>(c => parent.idfMonitoringSession ?? 0)(obj);
                obj.idfParty = (new GetNewIDExtender<VetFarmTree>()).GetScalar(manager, obj);
                obj.idfParentParty = new Func<VetFarmTree, long?>(c => parent.idfParty)(obj);
                obj.idfsPartyType = new Func<VetFarmTree, long>(c => (long)PartyTypeEnum.Species)(obj);
                obj.idfObservation = (new GetNewIDExtender<VetFarmTree>()).GetScalar(manager, obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(VetFarmTree obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VetFarmTree obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datStartOfSignsDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datStartOfSignsDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_intDeadAnimalQty)
                        {
                            try
                            {
                            
                TotalQuantityRule(obj);
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intDeadAnimalQty);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                                
                            }
                        }
                    
                        if (e.PropertyName == _str_intSickAnimalQty)
                        {
                            try
                            {
                            
                TotalQuantityRule(obj);
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intSickAnimalQty);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                                
                            }
                        }
                    
                        if (e.PropertyName == _str_intTotalAnimalQty)
                        {
                            try
                            {
                            
                TotalQuantityRule(obj);
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intTotalAnimalQty);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                                
                            }
                        }
                    
                        if (e.PropertyName == _str_strName)
                        {
                    
                obj.strHerdName = new Func<VetFarmTree, string>(c => c.GetHerdName())(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosisForCs)
                        {
                    
                    UpdateTemplate(obj);
                  
                        }
                    
                    };
                
            }
    
            public void LoadLookup_SpeciesType(DbManagerProxy manager, VetFarmTree obj)
            {
                
                obj.SpeciesTypeLookup.Clear();
                
                obj.SpeciesTypeLookup.Add(SpeciesTypeAccessor.CreateNewT(manager, null));
                
                obj.SpeciesTypeLookup.AddRange(SpeciesTypeAccessor.rftSpeciesList_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode.GetValueOrDefault() & obj._HACode.GetValueOrDefault()) != 0 || c.idfsBaseReference == obj.idfsSpeciesTypeReference)
                        
                    .Where(c => obj.idfsPartyType == (long)PartyTypeEnum.Species)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSpeciesTypeReference))
                    
                    .ToList());
                
                if (obj.idfsSpeciesTypeReference != null && obj.idfsSpeciesTypeReference != 0)
                {
                    obj.SpeciesType = obj.SpeciesTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsSpeciesTypeReference);
                    
                }
              
                
                LookupManager.AddObject("rftSpeciesList", obj, SpeciesTypeAccessor.GetType(), "rftSpeciesList_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, VetFarmTree obj)
            {
                
                LoadLookup_SpeciesType(manager, obj);
                
            }
    
            [SprocName("spVetFarmTree_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strName")] VetFarmTree obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strName")] VetFarmTree obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    VetFarmTree bo = obj as VetFarmTree;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as VetFarmTree, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VetFarmTree obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(VetFarmTree obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, VetFarmTree obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(VetFarmTree obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<VetFarmTree>(obj, "datStartOfSignsDate", c => true, 
      obj.datStartOfSignsDate,
      obj.GetType(),
      false, listdatStartOfSignsDate => {
    listdatStartOfSignsDate.Add(
    new ChainsValidatorDateTime<VetFarmTree>(obj, "CurrentDate", c => true, 
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
            protected bool ChainsValidate(VetFarmTree obj, bool bRethrowException)
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
                return Validate(manager, obj as VetFarmTree, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VetFarmTree obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "SpeciesType", "SpeciesType","strSpeciesName",
                false
              )).Validate(c => c.idfsPartyType == (long)PartyTypeEnum.Species, obj, obj.SpeciesType);
            
                CustomValidations(obj);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                TotalQuantityRule(obj);
            
                TotalQuantityRule(obj);
            
                TotalQuantityRule(obj);
            
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
           
    
            private void _SetupRequired(VetFarmTree obj)
            {
            
                obj
                    .AddRequired("SpeciesType", c => c.idfsPartyType == (long)PartyTypeEnum.Species);
                    
            }
    
    private void _SetupPersonalDataRestrictions(VetFarmTree obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VetFarmTree) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VetFarmTree) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VetFarmTreeDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFarmTree_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spVetFarmTree_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VetFarmTree, bool>> RequiredByField = new Dictionary<string, Func<VetFarmTree, bool>>();
            public static Dictionary<string, Func<VetFarmTree, bool>> RequiredByProperty = new Dictionary<string, Func<VetFarmTree, bool>>();
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
                Sizes.Add(_str_strNote, 2000);
                if (!RequiredByField.ContainsKey("SpeciesType")) RequiredByField.Add("SpeciesType", c => c.idfsPartyType == (long)PartyTypeEnum.Species);
                if (!RequiredByProperty.ContainsKey("SpeciesType")) RequiredByProperty.Add("SpeciesType", c => c.idfsPartyType == (long)PartyTypeEnum.Species);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfParty,
                    _str_idfParty, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strHerdName,
                    _str_strHerdName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFlockName,
                    "Flock", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpeciesName,
                    _str_strSpeciesName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intTotalAnimalQty,
                    _str_intTotalAnimalQty, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intSickAnimalQty,
                    _str_intSickAnimalQty, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intDeadAnimalQty,
                    _str_intDeadAnimalQty, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNote,
                    "VetFarmTree.strNote", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAverageAge,
                    _str_strAverageAge, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datStartOfSignsDate,
                    _str_datStartOfSignsDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsPartyType,
                    _str_idfsPartyType, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfParentParty,
                    _str_idfParentParty, null, false, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "CreateFarm",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateFarm(manager, c, pars)),
                        
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
                    "CreateHerd",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateHerd(manager, c, pars)),
                        
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
                    "CreateSpeciesWithDiagnosis",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateSpeciesWithDiagnosis(manager, c, pars)),
                        
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
                    "CreateSpecies",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateSpecies(manager, c, pars)),
                        
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
                    (manager, c, pars) => ((VetFarmTree)c).MarkToDelete(),
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
	