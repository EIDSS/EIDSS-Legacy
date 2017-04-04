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
    public abstract partial class Rule : 
        EditableObject<Rule>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsRule), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsRule { get; set; }
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64 idfsFormTemplate { get; set; }
        protected Int64 idfsFormTemplate_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64 idfsFormTemplate_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRuleMessage)]
        [MapField(_str_idfsRuleMessage)]
        public abstract Int64? idfsRuleMessage { get; set; }
        protected Int64? idfsRuleMessage_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRuleMessage).OriginalValue; } }
        protected Int64? idfsRuleMessage_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRuleMessage).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRuleFunction)]
        [MapField(_str_idfsRuleFunction)]
        public abstract Int64 idfsRuleFunction { get; set; }
        protected Int64 idfsRuleFunction_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsRuleFunction).OriginalValue; } }
        protected Int64 idfsRuleFunction_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsRuleFunction).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intNumberOfParameters)]
        [MapField(_str_intNumberOfParameters)]
        public abstract Int32? intNumberOfParameters { get; set; }
        protected Int32? intNumberOfParameters_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intNumberOfParameters).OriginalValue; } }
        protected Int32? intNumberOfParameters_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intNumberOfParameters).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCheckPoint)]
        [MapField(_str_idfsCheckPoint)]
        public abstract Int64? idfsCheckPoint { get; set; }
        protected Int64? idfsCheckPoint_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCheckPoint).OriginalValue; } }
        protected Int64? idfsCheckPoint_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCheckPoint).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCheckPointDescr)]
        [MapField(_str_idfsCheckPointDescr)]
        public abstract String idfsCheckPointDescr { get; set; }
        protected String idfsCheckPointDescr_Original { get { return ((EditableValue<String>)((dynamic)this)._idfsCheckPointDescr).OriginalValue; } }
        protected String idfsCheckPointDescr_Previous { get { return ((EditableValue<String>)((dynamic)this)._idfsCheckPointDescr).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intRowStatus)]
        [MapField(_str_intRowStatus)]
        public abstract Int32? intRowStatus { get; set; }
        protected Int32? intRowStatus_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intRowStatus).OriginalValue; } }
        protected Int32? intRowStatus_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intRowStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_rowguid)]
        [MapField(_str_rowguid)]
        public abstract Guid rowguid { get; set; }
        protected Guid rowguid_Original { get { return ((EditableValue<Guid>)((dynamic)this)._rowguid).OriginalValue; } }
        protected Guid rowguid_Previous { get { return ((EditableValue<Guid>)((dynamic)this)._rowguid).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DefaultName)]
        [MapField(_str_DefaultName)]
        public abstract String DefaultName { get; set; }
        protected String DefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._defaultName).OriginalValue; } }
        protected String DefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._defaultName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_NationalName)]
        [MapField(_str_NationalName)]
        public abstract String NationalName { get; set; }
        protected String NationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._nationalName).OriginalValue; } }
        protected String NationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._nationalName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_MessageText)]
        [MapField(_str_MessageText)]
        public abstract String MessageText { get; set; }
        protected String MessageText_Original { get { return ((EditableValue<String>)((dynamic)this)._messageText).OriginalValue; } }
        protected String MessageText_Previous { get { return ((EditableValue<String>)((dynamic)this)._messageText).PreviousValue; } }
                
        [LocalizedDisplayName(_str_MessageNationalText)]
        [MapField(_str_MessageNationalText)]
        public abstract String MessageNationalText { get; set; }
        protected String MessageNationalText_Original { get { return ((EditableValue<String>)((dynamic)this)._messageNationalText).OriginalValue; } }
        protected String MessageNationalText_Previous { get { return ((EditableValue<String>)((dynamic)this)._messageNationalText).PreviousValue; } }
                
        [LocalizedDisplayName(_str_langid)]
        [MapField(_str_langid)]
        public abstract String langid { get; set; }
        protected String langid_Original { get { return ((EditableValue<String>)((dynamic)this)._langid).OriginalValue; } }
        protected String langid_Previous { get { return ((EditableValue<String>)((dynamic)this)._langid).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnNot)]
        [MapField(_str_blnNot)]
        public abstract Boolean blnNot { get; set; }
        protected Boolean blnNot_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnNot).OriginalValue; } }
        protected Boolean blnNot_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnNot).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<Rule, object> _get_func;
            internal Action<Rule, string> _set_func;
            internal Action<Rule, Rule, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsRule = "idfsRule";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_idfsRuleMessage = "idfsRuleMessage";
        internal const string _str_idfsRuleFunction = "idfsRuleFunction";
        internal const string _str_intNumberOfParameters = "intNumberOfParameters";
        internal const string _str_idfsCheckPoint = "idfsCheckPoint";
        internal const string _str_idfsCheckPointDescr = "idfsCheckPointDescr";
        internal const string _str_intRowStatus = "intRowStatus";
        internal const string _str_rowguid = "rowguid";
        internal const string _str_DefaultName = "DefaultName";
        internal const string _str_NationalName = "NationalName";
        internal const string _str_MessageText = "MessageText";
        internal const string _str_MessageNationalText = "MessageNationalText";
        internal const string _str_langid = "langid";
        internal const string _str_blnNot = "blnNot";
        internal const string _str_idfsRuleActionDummy = "idfsRuleActionDummy";
        internal const string _str_idfRuleConstantDummy = "idfRuleConstantDummy";
        internal const string _str_idfsParameterDummy = "idfsParameterDummy";
        internal const string _str_Actions = "Actions";
        internal const string _str_Constants = "Constants";
        internal const string _str_Parameters = "Parameters";
        internal const string _str_Functions = "Functions";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsRule, _formname = _str_idfsRule, _type = "Int64",
              _get_func = o => o.idfsRule,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsRule != newval) o.idfsRule = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsRule != c.idfsRule || o.IsRIRPropChanged(_str_idfsRule, c)) 
                  m.Add(_str_idfsRule, o.ObjectIdent + _str_idfsRule, o.ObjectIdent2 + _str_idfsRule, o.ObjectIdent3 + _str_idfsRule, "Int64", 
                    o.idfsRule == null ? "" : o.idfsRule.ToString(),                  
                  o.IsReadOnly(_str_idfsRule), o.IsInvisible(_str_idfsRule), o.IsRequired(_str_idfsRule)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsFormTemplate, _formname = _str_idfsFormTemplate, _type = "Int64",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsFormTemplate != newval) o.idfsFormTemplate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, o.ObjectIdent2 + _str_idfsFormTemplate, o.ObjectIdent3 + _str_idfsFormTemplate, "Int64", 
                    o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(),                  
                  o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsRuleMessage, _formname = _str_idfsRuleMessage, _type = "Int64?",
              _get_func = o => o.idfsRuleMessage,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsRuleMessage != newval) o.idfsRuleMessage = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsRuleMessage != c.idfsRuleMessage || o.IsRIRPropChanged(_str_idfsRuleMessage, c)) 
                  m.Add(_str_idfsRuleMessage, o.ObjectIdent + _str_idfsRuleMessage, o.ObjectIdent2 + _str_idfsRuleMessage, o.ObjectIdent3 + _str_idfsRuleMessage, "Int64?", 
                    o.idfsRuleMessage == null ? "" : o.idfsRuleMessage.ToString(),                  
                  o.IsReadOnly(_str_idfsRuleMessage), o.IsInvisible(_str_idfsRuleMessage), o.IsRequired(_str_idfsRuleMessage)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsRuleFunction, _formname = _str_idfsRuleFunction, _type = "Int64",
              _get_func = o => o.idfsRuleFunction,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsRuleFunction != newval) 
                  o.Functions = o.FunctionsLookup.FirstOrDefault(c => c.idfsRuleFunction == newval);
                if (o.idfsRuleFunction != newval) o.idfsRuleFunction = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsRuleFunction != c.idfsRuleFunction || o.IsRIRPropChanged(_str_idfsRuleFunction, c)) 
                  m.Add(_str_idfsRuleFunction, o.ObjectIdent + _str_idfsRuleFunction, o.ObjectIdent2 + _str_idfsRuleFunction, o.ObjectIdent3 + _str_idfsRuleFunction, "Int64", 
                    o.idfsRuleFunction == null ? "" : o.idfsRuleFunction.ToString(),                  
                  o.IsReadOnly(_str_idfsRuleFunction), o.IsInvisible(_str_idfsRuleFunction), o.IsRequired(_str_idfsRuleFunction)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intNumberOfParameters, _formname = _str_intNumberOfParameters, _type = "Int32?",
              _get_func = o => o.intNumberOfParameters,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intNumberOfParameters != newval) o.intNumberOfParameters = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intNumberOfParameters != c.intNumberOfParameters || o.IsRIRPropChanged(_str_intNumberOfParameters, c)) 
                  m.Add(_str_intNumberOfParameters, o.ObjectIdent + _str_intNumberOfParameters, o.ObjectIdent2 + _str_intNumberOfParameters, o.ObjectIdent3 + _str_intNumberOfParameters, "Int32?", 
                    o.intNumberOfParameters == null ? "" : o.intNumberOfParameters.ToString(),                  
                  o.IsReadOnly(_str_intNumberOfParameters), o.IsInvisible(_str_intNumberOfParameters), o.IsRequired(_str_intNumberOfParameters)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCheckPoint, _formname = _str_idfsCheckPoint, _type = "Int64?",
              _get_func = o => o.idfsCheckPoint,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsCheckPoint != newval) o.idfsCheckPoint = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCheckPoint != c.idfsCheckPoint || o.IsRIRPropChanged(_str_idfsCheckPoint, c)) 
                  m.Add(_str_idfsCheckPoint, o.ObjectIdent + _str_idfsCheckPoint, o.ObjectIdent2 + _str_idfsCheckPoint, o.ObjectIdent3 + _str_idfsCheckPoint, "Int64?", 
                    o.idfsCheckPoint == null ? "" : o.idfsCheckPoint.ToString(),                  
                  o.IsReadOnly(_str_idfsCheckPoint), o.IsInvisible(_str_idfsCheckPoint), o.IsRequired(_str_idfsCheckPoint)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCheckPointDescr, _formname = _str_idfsCheckPointDescr, _type = "String",
              _get_func = o => o.idfsCheckPointDescr,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.idfsCheckPointDescr != newval) o.idfsCheckPointDescr = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCheckPointDescr != c.idfsCheckPointDescr || o.IsRIRPropChanged(_str_idfsCheckPointDescr, c)) 
                  m.Add(_str_idfsCheckPointDescr, o.ObjectIdent + _str_idfsCheckPointDescr, o.ObjectIdent2 + _str_idfsCheckPointDescr, o.ObjectIdent3 + _str_idfsCheckPointDescr, "String", 
                    o.idfsCheckPointDescr == null ? "" : o.idfsCheckPointDescr.ToString(),                  
                  o.IsReadOnly(_str_idfsCheckPointDescr), o.IsInvisible(_str_idfsCheckPointDescr), o.IsRequired(_str_idfsCheckPointDescr)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intRowStatus, _formname = _str_intRowStatus, _type = "Int32?",
              _get_func = o => o.intRowStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intRowStatus != newval) o.intRowStatus = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intRowStatus != c.intRowStatus || o.IsRIRPropChanged(_str_intRowStatus, c)) 
                  m.Add(_str_intRowStatus, o.ObjectIdent + _str_intRowStatus, o.ObjectIdent2 + _str_intRowStatus, o.ObjectIdent3 + _str_intRowStatus, "Int32?", 
                    o.intRowStatus == null ? "" : o.intRowStatus.ToString(),                  
                  o.IsReadOnly(_str_intRowStatus), o.IsInvisible(_str_intRowStatus), o.IsRequired(_str_intRowStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_rowguid, _formname = _str_rowguid, _type = "Guid",
              _get_func = o => o.rowguid,
              _set_func = (o, val) => { var newval = o.rowguid; if (o.rowguid != newval) o.rowguid = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.rowguid != c.rowguid || o.IsRIRPropChanged(_str_rowguid, c)) 
                  m.Add(_str_rowguid, o.ObjectIdent + _str_rowguid, o.ObjectIdent2 + _str_rowguid, o.ObjectIdent3 + _str_rowguid, "Guid", 
                    o.rowguid == null ? "" : o.rowguid.ToString(),                  
                  o.IsReadOnly(_str_rowguid), o.IsInvisible(_str_rowguid), o.IsRequired(_str_rowguid)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DefaultName, _formname = _str_DefaultName, _type = "String",
              _get_func = o => o.DefaultName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DefaultName != newval) o.DefaultName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DefaultName != c.DefaultName || o.IsRIRPropChanged(_str_DefaultName, c)) 
                  m.Add(_str_DefaultName, o.ObjectIdent + _str_DefaultName, o.ObjectIdent2 + _str_DefaultName, o.ObjectIdent3 + _str_DefaultName, "String", 
                    o.DefaultName == null ? "" : o.DefaultName.ToString(),                  
                  o.IsReadOnly(_str_DefaultName), o.IsInvisible(_str_DefaultName), o.IsRequired(_str_DefaultName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_NationalName, _formname = _str_NationalName, _type = "String",
              _get_func = o => o.NationalName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.NationalName != newval) o.NationalName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.NationalName != c.NationalName || o.IsRIRPropChanged(_str_NationalName, c)) 
                  m.Add(_str_NationalName, o.ObjectIdent + _str_NationalName, o.ObjectIdent2 + _str_NationalName, o.ObjectIdent3 + _str_NationalName, "String", 
                    o.NationalName == null ? "" : o.NationalName.ToString(),                  
                  o.IsReadOnly(_str_NationalName), o.IsInvisible(_str_NationalName), o.IsRequired(_str_NationalName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_MessageText, _formname = _str_MessageText, _type = "String",
              _get_func = o => o.MessageText,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.MessageText != newval) o.MessageText = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.MessageText != c.MessageText || o.IsRIRPropChanged(_str_MessageText, c)) 
                  m.Add(_str_MessageText, o.ObjectIdent + _str_MessageText, o.ObjectIdent2 + _str_MessageText, o.ObjectIdent3 + _str_MessageText, "String", 
                    o.MessageText == null ? "" : o.MessageText.ToString(),                  
                  o.IsReadOnly(_str_MessageText), o.IsInvisible(_str_MessageText), o.IsRequired(_str_MessageText)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_MessageNationalText, _formname = _str_MessageNationalText, _type = "String",
              _get_func = o => o.MessageNationalText,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.MessageNationalText != newval) o.MessageNationalText = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.MessageNationalText != c.MessageNationalText || o.IsRIRPropChanged(_str_MessageNationalText, c)) 
                  m.Add(_str_MessageNationalText, o.ObjectIdent + _str_MessageNationalText, o.ObjectIdent2 + _str_MessageNationalText, o.ObjectIdent3 + _str_MessageNationalText, "String", 
                    o.MessageNationalText == null ? "" : o.MessageNationalText.ToString(),                  
                  o.IsReadOnly(_str_MessageNationalText), o.IsInvisible(_str_MessageNationalText), o.IsRequired(_str_MessageNationalText)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_langid, _formname = _str_langid, _type = "String",
              _get_func = o => o.langid,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.langid != newval) o.langid = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.langid != c.langid || o.IsRIRPropChanged(_str_langid, c)) 
                  m.Add(_str_langid, o.ObjectIdent + _str_langid, o.ObjectIdent2 + _str_langid, o.ObjectIdent3 + _str_langid, "String", 
                    o.langid == null ? "" : o.langid.ToString(),                  
                  o.IsReadOnly(_str_langid), o.IsInvisible(_str_langid), o.IsRequired(_str_langid)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnNot, _formname = _str_blnNot, _type = "Boolean",
              _get_func = o => o.blnNot,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnNot != newval) o.blnNot = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnNot != c.blnNot || o.IsRIRPropChanged(_str_blnNot, c)) 
                  m.Add(_str_blnNot, o.ObjectIdent + _str_blnNot, o.ObjectIdent2 + _str_blnNot, o.ObjectIdent3 + _str_blnNot, "Boolean", 
                    o.blnNot == null ? "" : o.blnNot.ToString(),                  
                  o.IsReadOnly(_str_blnNot), o.IsInvisible(_str_blnNot), o.IsRequired(_str_blnNot)); 
                  }
              }, 
        
            new field_info {
              _name = _str_idfsRuleActionDummy, _formname = _str_idfsRuleActionDummy, _type = "long?",
              _get_func = o => o.idfsRuleActionDummy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsRuleActionDummy != newval) o.idfsRuleActionDummy = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsRuleActionDummy != c.idfsRuleActionDummy || o.IsRIRPropChanged(_str_idfsRuleActionDummy, c)) {
                  m.Add(_str_idfsRuleActionDummy, o.ObjectIdent + _str_idfsRuleActionDummy, o.ObjectIdent2 + _str_idfsRuleActionDummy, o.ObjectIdent3 + _str_idfsRuleActionDummy,  "long?", 
                    o.idfsRuleActionDummy == null ? "" : o.idfsRuleActionDummy.ToString(),                  
                    o.IsReadOnly(_str_idfsRuleActionDummy), o.IsInvisible(_str_idfsRuleActionDummy), o.IsRequired(_str_idfsRuleActionDummy));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfRuleConstantDummy, _formname = _str_idfRuleConstantDummy, _type = "long?",
              _get_func = o => o.idfRuleConstantDummy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfRuleConstantDummy != newval) o.idfRuleConstantDummy = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfRuleConstantDummy != c.idfRuleConstantDummy || o.IsRIRPropChanged(_str_idfRuleConstantDummy, c)) {
                  m.Add(_str_idfRuleConstantDummy, o.ObjectIdent + _str_idfRuleConstantDummy, o.ObjectIdent2 + _str_idfRuleConstantDummy, o.ObjectIdent3 + _str_idfRuleConstantDummy,  "long?", 
                    o.idfRuleConstantDummy == null ? "" : o.idfRuleConstantDummy.ToString(),                  
                    o.IsReadOnly(_str_idfRuleConstantDummy), o.IsInvisible(_str_idfRuleConstantDummy), o.IsRequired(_str_idfRuleConstantDummy));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsParameterDummy, _formname = _str_idfsParameterDummy, _type = "long?",
              _get_func = o => o.idfsParameterDummy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsParameterDummy != newval) o.idfsParameterDummy = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsParameterDummy != c.idfsParameterDummy || o.IsRIRPropChanged(_str_idfsParameterDummy, c)) {
                  m.Add(_str_idfsParameterDummy, o.ObjectIdent + _str_idfsParameterDummy, o.ObjectIdent2 + _str_idfsParameterDummy, o.ObjectIdent3 + _str_idfsParameterDummy,  "long?", 
                    o.idfsParameterDummy == null ? "" : o.idfsParameterDummy.ToString(),                  
                    o.IsReadOnly(_str_idfsParameterDummy), o.IsInvisible(_str_idfsParameterDummy), o.IsRequired(_str_idfsParameterDummy));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_Actions, _formname = _str_Actions, _type = "Lookup",
              _get_func = o => { if (o.Actions == null) return null; return o.Actions.idfsRuleAction; },
              _set_func = (o, val) => { o.Actions = o.ActionsLookup.Where(c => c.idfsRuleAction.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Actions, c);
                if (o.idfsRuleActionDummy != c.idfsRuleActionDummy || o.IsRIRPropChanged(_str_Actions, c) || bChangeLookupContent) {
                  m.Add(_str_Actions, o.ObjectIdent + _str_Actions, o.ObjectIdent2 + _str_Actions, o.ObjectIdent3 + _str_Actions, "Lookup", o.idfsRuleActionDummy == null ? "" : o.idfsRuleActionDummy.ToString(), o.IsReadOnly(_str_Actions), o.IsInvisible(_str_Actions), o.IsRequired(_str_Actions),
                  bChangeLookupContent ? o.ActionsLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Actions + "Lookup", _formname = _str_Actions + "Lookup", _type = "LookupContent",
              _get_func = o => o.ActionsLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Constants, _formname = _str_Constants, _type = "Lookup",
              _get_func = o => { if (o.Constants == null) return null; return o.Constants.idfRuleConstant; },
              _set_func = (o, val) => { o.Constants = o.ConstantsLookup.Where(c => c.idfRuleConstant.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Constants, c);
                if (o.idfRuleConstantDummy != c.idfRuleConstantDummy || o.IsRIRPropChanged(_str_Constants, c) || bChangeLookupContent) {
                  m.Add(_str_Constants, o.ObjectIdent + _str_Constants, o.ObjectIdent2 + _str_Constants, o.ObjectIdent3 + _str_Constants, "Lookup", o.idfRuleConstantDummy == null ? "" : o.idfRuleConstantDummy.ToString(), o.IsReadOnly(_str_Constants), o.IsInvisible(_str_Constants), o.IsRequired(_str_Constants),
                  bChangeLookupContent ? o.ConstantsLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Constants + "Lookup", _formname = _str_Constants + "Lookup", _type = "LookupContent",
              _get_func = o => o.ConstantsLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Parameters, _formname = _str_Parameters, _type = "Lookup",
              _get_func = o => { if (o.Parameters == null) return null; return o.Parameters.idfsParameter; },
              _set_func = (o, val) => { o.Parameters = o.ParametersLookup.Where(c => c.idfsParameter.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Parameters, c);
                if (o.idfsParameterDummy != c.idfsParameterDummy || o.IsRIRPropChanged(_str_Parameters, c) || bChangeLookupContent) {
                  m.Add(_str_Parameters, o.ObjectIdent + _str_Parameters, o.ObjectIdent2 + _str_Parameters, o.ObjectIdent3 + _str_Parameters, "Lookup", o.idfsParameterDummy == null ? "" : o.idfsParameterDummy.ToString(), o.IsReadOnly(_str_Parameters), o.IsInvisible(_str_Parameters), o.IsRequired(_str_Parameters),
                  bChangeLookupContent ? o.ParametersLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Parameters + "Lookup", _formname = _str_Parameters + "Lookup", _type = "LookupContent",
              _get_func = o => o.ParametersLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Functions, _formname = _str_Functions, _type = "Lookup",
              _get_func = o => { if (o.Functions == null) return null; return o.Functions.idfsRuleFunction; },
              _set_func = (o, val) => { o.Functions = o.FunctionsLookup.Where(c => c.idfsRuleFunction.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Functions, c);
                if (o.idfsRuleFunction != c.idfsRuleFunction || o.IsRIRPropChanged(_str_Functions, c) || bChangeLookupContent) {
                  m.Add(_str_Functions, o.ObjectIdent + _str_Functions, o.ObjectIdent2 + _str_Functions, o.ObjectIdent3 + _str_Functions, "Lookup", o.idfsRuleFunction == null ? "" : o.idfsRuleFunction.ToString(), o.IsReadOnly(_str_Functions), o.IsInvisible(_str_Functions), o.IsRequired(_str_Functions),
                  bChangeLookupContent ? o.FunctionsLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Functions + "Lookup", _formname = _str_Functions + "Lookup", _type = "LookupContent",
              _get_func = o => o.FunctionsLookup,
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
            Rule obj = (Rule)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Actions)]
        [Relation(typeof(RuleAction), eidss.model.Schema.RuleAction._str_idfsRuleAction, _str_idfsRuleActionDummy)]
        public RuleAction Actions
        {
            get { return _Actions; }
            set 
            { 
                var oldVal = _Actions;
                _Actions = value;
                if (_Actions != oldVal)
                {
                    if (idfsRuleActionDummy != (_Actions == null
                            ? new long?()
                            : _Actions.idfsRuleAction))
                        idfsRuleActionDummy = _Actions == null 
                            ? new long?()
                            : _Actions.idfsRuleAction; 
                    OnPropertyChanged(_str_Actions); 
                }
            }
        }
        private RuleAction _Actions;

        
        public List<RuleAction> ActionsLookup
        {
            get { return _ActionsLookup; }
        }
        private List<RuleAction> _ActionsLookup = new List<RuleAction>();
            
        [LocalizedDisplayName(_str_Constants)]
        [Relation(typeof(RuleConstant), eidss.model.Schema.RuleConstant._str_idfRuleConstant, _str_idfRuleConstantDummy)]
        public RuleConstant Constants
        {
            get { return _Constants; }
            set 
            { 
                var oldVal = _Constants;
                _Constants = value;
                if (_Constants != oldVal)
                {
                    if (idfRuleConstantDummy != (_Constants == null
                            ? new long?()
                            : _Constants.idfRuleConstant))
                        idfRuleConstantDummy = _Constants == null 
                            ? new long?()
                            : _Constants.idfRuleConstant; 
                    OnPropertyChanged(_str_Constants); 
                }
            }
        }
        private RuleConstant _Constants;

        
        public List<RuleConstant> ConstantsLookup
        {
            get { return _ConstantsLookup; }
        }
        private List<RuleConstant> _ConstantsLookup = new List<RuleConstant>();
            
        [LocalizedDisplayName(_str_Parameters)]
        [Relation(typeof(RuleParameter), eidss.model.Schema.RuleParameter._str_idfsParameter, _str_idfsParameterDummy)]
        public RuleParameter Parameters
        {
            get { return _Parameters; }
            set 
            { 
                var oldVal = _Parameters;
                _Parameters = value;
                if (_Parameters != oldVal)
                {
                    if (idfsParameterDummy != (_Parameters == null
                            ? new long?()
                            : _Parameters.idfsParameter))
                        idfsParameterDummy = _Parameters == null 
                            ? new long?()
                            : _Parameters.idfsParameter; 
                    OnPropertyChanged(_str_Parameters); 
                }
            }
        }
        private RuleParameter _Parameters;

        
        public List<RuleParameter> ParametersLookup
        {
            get { return _ParametersLookup; }
        }
        private List<RuleParameter> _ParametersLookup = new List<RuleParameter>();
            
        [LocalizedDisplayName(_str_Functions)]
        [Relation(typeof(RuleFunctionLookup), eidss.model.Schema.RuleFunctionLookup._str_idfsRuleFunction, _str_idfsRuleFunction)]
        public RuleFunctionLookup Functions
        {
            get { return _Functions; }
            set 
            { 
                var oldVal = _Functions;
                _Functions = value;
                if (_Functions != oldVal)
                {
                    if (idfsRuleFunction != (_Functions == null
                            ? new Int64()
                            : (Int64)_Functions.idfsRuleFunction))
                        idfsRuleFunction = _Functions == null 
                            ? new Int64()
                            : (Int64)_Functions.idfsRuleFunction; 
                    OnPropertyChanged(_str_Functions); 
                }
            }
        }
        private RuleFunctionLookup _Functions;

        
        public List<RuleFunctionLookup> FunctionsLookup
        {
            get { return _FunctionsLookup; }
        }
        private List<RuleFunctionLookup> _FunctionsLookup = new List<RuleFunctionLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Actions:
                    return new BvSelectList(ActionsLookup, eidss.model.Schema.RuleAction._str_idfsRuleAction, null, Actions, _str_idfsRuleActionDummy);
            
                case _str_Constants:
                    return new BvSelectList(ConstantsLookup, eidss.model.Schema.RuleConstant._str_idfRuleConstant, null, Constants, _str_idfRuleConstantDummy);
            
                case _str_Parameters:
                    return new BvSelectList(ParametersLookup, eidss.model.Schema.RuleParameter._str_idfsParameter, null, Parameters, _str_idfsParameterDummy);
            
                case _str_Functions:
                    return new BvSelectList(FunctionsLookup, eidss.model.Schema.RuleFunctionLookup._str_idfsRuleFunction, null, Functions, _str_idfsRuleFunction);
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str_idfsRuleActionDummy)]
        public long? idfsRuleActionDummy
        {
            get { return m_idfsRuleActionDummy; }
            set { if (m_idfsRuleActionDummy != value) { m_idfsRuleActionDummy = value; OnPropertyChanged(_str_idfsRuleActionDummy); } }
        }
        private long? m_idfsRuleActionDummy;
        
          [LocalizedDisplayName(_str_idfRuleConstantDummy)]
        public long? idfRuleConstantDummy
        {
            get { return m_idfRuleConstantDummy; }
            set { if (m_idfRuleConstantDummy != value) { m_idfRuleConstantDummy = value; OnPropertyChanged(_str_idfRuleConstantDummy); } }
        }
        private long? m_idfRuleConstantDummy;
        
          [LocalizedDisplayName(_str_idfsParameterDummy)]
        public long? idfsParameterDummy
        {
            get { return m_idfsParameterDummy; }
            set { if (m_idfsParameterDummy != value) { m_idfsParameterDummy = value; OnPropertyChanged(_str_idfsParameterDummy); } }
        }
        private long? m_idfsParameterDummy;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "Rule";

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
            var ret = base.Clone() as Rule;
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
            var ret = base.Clone() as Rule;
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
        public Rule CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Rule;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsRule; } }
        public string KeyName { get { return "idfsRule"; } }
        public object KeyLookup { get { return idfsRule; } }
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
        
            var _prev_idfsRuleActionDummy_Actions = idfsRuleActionDummy;
            var _prev_idfRuleConstantDummy_Constants = idfRuleConstantDummy;
            var _prev_idfsParameterDummy_Parameters = idfsParameterDummy;
            var _prev_idfsRuleFunction_Functions = idfsRuleFunction;
            base.RejectChanges();
        
            if (_prev_idfsRuleActionDummy_Actions != idfsRuleActionDummy)
            {
                _Actions = _ActionsLookup.FirstOrDefault(c => c.idfsRuleAction == idfsRuleActionDummy);
            }
            if (_prev_idfRuleConstantDummy_Constants != idfRuleConstantDummy)
            {
                _Constants = _ConstantsLookup.FirstOrDefault(c => c.idfRuleConstant == idfRuleConstantDummy);
            }
            if (_prev_idfsParameterDummy_Parameters != idfsParameterDummy)
            {
                _Parameters = _ParametersLookup.FirstOrDefault(c => c.idfsParameter == idfsParameterDummy);
            }
            if (_prev_idfsRuleFunction_Functions != idfsRuleFunction)
            {
                _Functions = _FunctionsLookup.FirstOrDefault(c => c.idfsRuleFunction == idfsRuleFunction);
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

        private bool IsRIRPropChanged(string fld, Rule c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, Rule c)
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
        

      

        public Rule()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Rule_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Rule_PropertyChanged);
        }
        private void Rule_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Rule).Changed(e.PropertyName);
            
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
            Rule obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Rule obj = this;
            
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


        internal Dictionary<string, Func<Rule, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<Rule, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Rule, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Rule, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<Rule, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<Rule, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<Rule, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~Rule()
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
                
                LookupManager.RemoveObject("RuleAction", this);
                
                LookupManager.RemoveObject("RuleConstant", this);
                
                LookupManager.RemoveObject("RuleParameter", this);
                
                LookupManager.RemoveObject("RuleFunctionLookup", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "RuleAction")
                _getAccessor().LoadLookup_Actions(manager, this);
            
            if (lookup_object == "RuleConstant")
                _getAccessor().LoadLookup_Constants(manager, this);
            
            if (lookup_object == "RuleParameter")
                _getAccessor().LoadLookup_Parameters(manager, this);
            
            if (lookup_object == "RuleFunctionLookup")
                _getAccessor().LoadLookup_Functions(manager, this);
            
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
        : DataAccessor<Rule>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<Rule>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsRule"; } }
            #endregion
        
            public delegate void on_action(Rule obj);
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
            private RuleAction.Accessor ActionsAccessor { get { return eidss.model.Schema.RuleAction.Accessor.Instance(m_CS); } }
            private RuleConstant.Accessor ConstantsAccessor { get { return eidss.model.Schema.RuleConstant.Accessor.Instance(m_CS); } }
            private RuleParameter.Accessor ParametersAccessor { get { return eidss.model.Schema.RuleParameter.Accessor.Instance(m_CS); } }
            private RuleFunctionLookup.Accessor FunctionsAccessor { get { return eidss.model.Schema.RuleFunctionLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<Rule> SelectLookupList(DbManagerProxy manager
                , Int64? idfsFormTemplate
                )
            {
                return _SelectList(manager
                    , idfsFormTemplate
                    , null, null
                    );
            }
            
            public virtual List<Rule> SelectList(DbManagerProxy manager
                , Int64? idfsFormTemplate
                )
            {
                return _SelectList(manager
                    , idfsFormTemplate
                    , delegate(Rule obj)
                        {
                        }
                    , delegate(Rule obj)
                        {
                        }
                    );
            }

            

            public List<Rule> _SelectList(DbManagerProxy manager
                , Int64? idfsFormTemplate
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfsFormTemplate
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            [InstanceCache(typeof(BvCacheAspect))]
            public virtual List<Rule> _SelectListInternal(DbManagerProxy manager
                , Int64? idfsFormTemplate
                , on_action loading, on_action loaded
                )
            {
                Rule _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<Rule> objs = new List<Rule>();
                    sets[0] = new MapResultSet(typeof(Rule), objs);
                    
                    manager
                        .SetSpCommand("spFFGetRules"
                            , manager.Parameter("@idfsFormTemplate", idfsFormTemplate)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, Rule obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, Rule obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private Rule _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                Rule obj = null;
                try
                {
                    obj = Rule.CreateInstance();
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

            
            public Rule CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public Rule CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public Rule CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(Rule obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Rule obj)
            {
                
            }
    
            public void LoadLookup_Actions(DbManagerProxy manager, Rule obj)
            {
                
                obj.ActionsLookup.Clear();
                
                obj.ActionsLookup.AddRange(ActionsAccessor.SelectLookupList(manager
                    
                    , new Func<Rule, Int64>(c => c.idfsRule)(obj)
                            
                    )
                    .ToList());
                
                if (obj.idfsRuleActionDummy != null && obj.idfsRuleActionDummy != 0)
                {
                    obj.Actions = obj.ActionsLookup
                        .SingleOrDefault(c => c.idfsRuleAction == obj.idfsRuleActionDummy);
                    
                }
              
                LookupManager.AddObject("RuleAction", obj, ActionsAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Constants(DbManagerProxy manager, Rule obj)
            {
                
                obj.ConstantsLookup.Clear();
                
                obj.ConstantsLookup.AddRange(ConstantsAccessor.SelectLookupList(manager
                    
                    , new Func<Rule, Int64>(c => c.idfsRule)(obj)
                            
                    )
                    .ToList());
                
                if (obj.idfRuleConstantDummy != null && obj.idfRuleConstantDummy != 0)
                {
                    obj.Constants = obj.ConstantsLookup
                        .SingleOrDefault(c => c.idfRuleConstant == obj.idfRuleConstantDummy);
                    
                }
              
                LookupManager.AddObject("RuleConstant", obj, ConstantsAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Parameters(DbManagerProxy manager, Rule obj)
            {
                
                obj.ParametersLookup.Clear();
                
                obj.ParametersLookup.AddRange(ParametersAccessor.SelectLookupList(manager
                    
                    , new Func<Rule, Int64>(c => c.idfsRule)(obj)
                            
                    )
                    .ToList());
                
                if (obj.idfsParameterDummy != null && obj.idfsParameterDummy != 0)
                {
                    obj.Parameters = obj.ParametersLookup
                        .SingleOrDefault(c => c.idfsParameter == obj.idfsParameterDummy);
                    
                }
              
                LookupManager.AddObject("RuleParameter", obj, ParametersAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Functions(DbManagerProxy manager, Rule obj)
            {
                
                obj.FunctionsLookup.Clear();
                
                obj.FunctionsLookup.AddRange(FunctionsAccessor.SelectLookupList(manager
                    
                    , -1
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRuleFunction == obj.idfsRuleFunction))
                    
                    .ToList());
                
                if (obj.idfsRuleFunction != 0)
                {
                    obj.Functions = obj.FunctionsLookup
                        .SingleOrDefault(c => c.idfsRuleFunction == obj.idfsRuleFunction);
                    
                }
              
                LookupManager.AddObject("RuleFunctionLookup", obj, FunctionsAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, Rule obj)
            {
                
                LoadLookup_Actions(manager, obj);
                
                LoadLookup_Constants(manager, obj);
                
                LoadLookup_Parameters(manager, obj);
                
                LoadLookup_Functions(manager, obj);
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(Rule obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(Rule obj, bool bRethrowException)
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
                return Validate(manager, obj as Rule, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Rule obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(Rule obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(Rule obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Rule) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Rule) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "RuleDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFFGetRules";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Rule, bool>> RequiredByField = new Dictionary<string, Func<Rule, bool>>();
            public static Dictionary<string, Func<Rule, bool>> RequiredByProperty = new Dictionary<string, Func<Rule, bool>>();
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
                
                Sizes.Add(_str_idfsCheckPointDescr, 14);
                Sizes.Add(_str_DefaultName, 2000);
                Sizes.Add(_str_NationalName, 2000);
                Sizes.Add(_str_MessageText, 2000);
                Sizes.Add(_str_MessageNationalText, 2000);
                Sizes.Add(_str_langid, 50);
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
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Rule>().Post(manager, (Rule)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
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
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Rule>().Post(manager, (Rule)c), c),
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
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((Rule)c).MarkToDelete() && ObjectAccessor.PostInterface<Rule>().Post(manager, (Rule)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
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
	