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
    public abstract partial class AvrQueryLookup : 
        EditableObject<AvrQueryLookup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idflQuery), NonUpdatable, PrimaryKey]
        public abstract Int64 idflQuery { get; set; }
                
        [LocalizedDisplayName(_str_idfsGlobalQuery)]
        [MapField(_str_idfsGlobalQuery)]
        public abstract Int64? idfsGlobalQuery { get; set; }
        protected Int64? idfsGlobalQuery_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGlobalQuery).OriginalValue; } }
        protected Int64? idfsGlobalQuery_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGlobalQuery).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DefQueryName)]
        [MapField(_str_DefQueryName)]
        public abstract String DefQueryName { get; set; }
        protected String DefQueryName_Original { get { return ((EditableValue<String>)((dynamic)this)._defQueryName).OriginalValue; } }
        protected String DefQueryName_Previous { get { return ((EditableValue<String>)((dynamic)this)._defQueryName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_QueryName)]
        [MapField(_str_QueryName)]
        public abstract String QueryName { get; set; }
        protected String QueryName_Original { get { return ((EditableValue<String>)((dynamic)this)._queryName).OriginalValue; } }
        protected String QueryName_Previous { get { return ((EditableValue<String>)((dynamic)this)._queryName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFunctionName)]
        [MapField(_str_strFunctionName)]
        public abstract String strFunctionName { get; set; }
        protected String strFunctionName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFunctionName).OriginalValue; } }
        protected String strFunctionName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFunctionName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDescription)]
        [MapField(_str_strDescription)]
        public abstract String strDescription { get; set; }
        protected String strDescription_Original { get { return ((EditableValue<String>)((dynamic)this)._strDescription).OriginalValue; } }
        protected String strDescription_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDescription).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnReadOnly)]
        [MapField(_str_blnReadOnly)]
        public abstract Boolean blnReadOnly { get; set; }
        protected Boolean blnReadOnly_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnReadOnly).OriginalValue; } }
        protected Boolean blnReadOnly_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnReadOnly).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32 intOrder { get; set; }
        protected Int32 intOrder_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32 intOrder_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnIsOutbreak)]
        [MapField(_str_blnIsOutbreak)]
        public abstract Int32 blnIsOutbreak { get; set; }
        protected Int32 blnIsOutbreak_Original { get { return ((EditableValue<Int32>)((dynamic)this)._blnIsOutbreak).OriginalValue; } }
        protected Int32 blnIsOutbreak_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._blnIsOutbreak).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnIsHumanCase)]
        [MapField(_str_blnIsHumanCase)]
        public abstract Int32 blnIsHumanCase { get; set; }
        protected Int32 blnIsHumanCase_Original { get { return ((EditableValue<Int32>)((dynamic)this)._blnIsHumanCase).OriginalValue; } }
        protected Int32 blnIsHumanCase_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._blnIsHumanCase).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnIsVetCase)]
        [MapField(_str_blnIsVetCase)]
        public abstract Int32 blnIsVetCase { get; set; }
        protected Int32 blnIsVetCase_Original { get { return ((EditableValue<Int32>)((dynamic)this)._blnIsVetCase).OriginalValue; } }
        protected Int32 blnIsVetCase_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._blnIsVetCase).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnIsASCampaign)]
        [MapField(_str_blnIsASCampaign)]
        public abstract Int32 blnIsASCampaign { get; set; }
        protected Int32 blnIsASCampaign_Original { get { return ((EditableValue<Int32>)((dynamic)this)._blnIsASCampaign).OriginalValue; } }
        protected Int32 blnIsASCampaign_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._blnIsASCampaign).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnIsASSession)]
        [MapField(_str_blnIsASSession)]
        public abstract Int32 blnIsASSession { get; set; }
        protected Int32 blnIsASSession_Original { get { return ((EditableValue<Int32>)((dynamic)this)._blnIsASSession).OriginalValue; } }
        protected Int32 blnIsASSession_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._blnIsASSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnIsSample)]
        [MapField(_str_blnIsSample)]
        public abstract Int32 blnIsSample { get; set; }
        protected Int32 blnIsSample_Original { get { return ((EditableValue<Int32>)((dynamic)this)._blnIsSample).OriginalValue; } }
        protected Int32 blnIsSample_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._blnIsSample).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnIsTest)]
        [MapField(_str_blnIsTest)]
        public abstract Int32 blnIsTest { get; set; }
        protected Int32 blnIsTest_Original { get { return ((EditableValue<Int32>)((dynamic)this)._blnIsTest).OriginalValue; } }
        protected Int32 blnIsTest_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._blnIsTest).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int32? intHACode { get; set; }
        protected Int32? intHACode_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32? intHACode_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<AvrQueryLookup, object> _get_func;
            internal Action<AvrQueryLookup, string> _set_func;
            internal Action<AvrQueryLookup, AvrQueryLookup, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idflQuery = "idflQuery";
        internal const string _str_idfsGlobalQuery = "idfsGlobalQuery";
        internal const string _str_DefQueryName = "DefQueryName";
        internal const string _str_QueryName = "QueryName";
        internal const string _str_strFunctionName = "strFunctionName";
        internal const string _str_strDescription = "strDescription";
        internal const string _str_blnReadOnly = "blnReadOnly";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_blnIsOutbreak = "blnIsOutbreak";
        internal const string _str_blnIsHumanCase = "blnIsHumanCase";
        internal const string _str_blnIsVetCase = "blnIsVetCase";
        internal const string _str_blnIsASCampaign = "blnIsASCampaign";
        internal const string _str_blnIsASSession = "blnIsASSession";
        internal const string _str_blnIsSample = "blnIsSample";
        internal const string _str_blnIsTest = "blnIsTest";
        internal const string _str_intHACode = "intHACode";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idflQuery, _formname = _str_idflQuery, _type = "Int64",
              _get_func = o => o.idflQuery,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idflQuery != newval) o.idflQuery = newval; },
              _compare_func = (o, c, m) => {
                if (o.idflQuery != c.idflQuery || o.IsRIRPropChanged(_str_idflQuery, c)) 
                  m.Add(_str_idflQuery, o.ObjectIdent + _str_idflQuery, o.ObjectIdent2 + _str_idflQuery, o.ObjectIdent3 + _str_idflQuery, "Int64", 
                    o.idflQuery == null ? "" : o.idflQuery.ToString(),                  
                  o.IsReadOnly(_str_idflQuery), o.IsInvisible(_str_idflQuery), o.IsRequired(_str_idflQuery)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsGlobalQuery, _formname = _str_idfsGlobalQuery, _type = "Int64?",
              _get_func = o => o.idfsGlobalQuery,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsGlobalQuery != newval) o.idfsGlobalQuery = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsGlobalQuery != c.idfsGlobalQuery || o.IsRIRPropChanged(_str_idfsGlobalQuery, c)) 
                  m.Add(_str_idfsGlobalQuery, o.ObjectIdent + _str_idfsGlobalQuery, o.ObjectIdent2 + _str_idfsGlobalQuery, o.ObjectIdent3 + _str_idfsGlobalQuery, "Int64?", 
                    o.idfsGlobalQuery == null ? "" : o.idfsGlobalQuery.ToString(),                  
                  o.IsReadOnly(_str_idfsGlobalQuery), o.IsInvisible(_str_idfsGlobalQuery), o.IsRequired(_str_idfsGlobalQuery)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DefQueryName, _formname = _str_DefQueryName, _type = "String",
              _get_func = o => o.DefQueryName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DefQueryName != newval) o.DefQueryName = newval; },
              _compare_func = (o, c, m) => {
                if (o.DefQueryName != c.DefQueryName || o.IsRIRPropChanged(_str_DefQueryName, c)) 
                  m.Add(_str_DefQueryName, o.ObjectIdent + _str_DefQueryName, o.ObjectIdent2 + _str_DefQueryName, o.ObjectIdent3 + _str_DefQueryName, "String", 
                    o.DefQueryName == null ? "" : o.DefQueryName.ToString(),                  
                  o.IsReadOnly(_str_DefQueryName), o.IsInvisible(_str_DefQueryName), o.IsRequired(_str_DefQueryName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_QueryName, _formname = _str_QueryName, _type = "String",
              _get_func = o => o.QueryName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.QueryName != newval) o.QueryName = newval; },
              _compare_func = (o, c, m) => {
                if (o.QueryName != c.QueryName || o.IsRIRPropChanged(_str_QueryName, c)) 
                  m.Add(_str_QueryName, o.ObjectIdent + _str_QueryName, o.ObjectIdent2 + _str_QueryName, o.ObjectIdent3 + _str_QueryName, "String", 
                    o.QueryName == null ? "" : o.QueryName.ToString(),                  
                  o.IsReadOnly(_str_QueryName), o.IsInvisible(_str_QueryName), o.IsRequired(_str_QueryName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFunctionName, _formname = _str_strFunctionName, _type = "String",
              _get_func = o => o.strFunctionName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFunctionName != newval) o.strFunctionName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFunctionName != c.strFunctionName || o.IsRIRPropChanged(_str_strFunctionName, c)) 
                  m.Add(_str_strFunctionName, o.ObjectIdent + _str_strFunctionName, o.ObjectIdent2 + _str_strFunctionName, o.ObjectIdent3 + _str_strFunctionName, "String", 
                    o.strFunctionName == null ? "" : o.strFunctionName.ToString(),                  
                  o.IsReadOnly(_str_strFunctionName), o.IsInvisible(_str_strFunctionName), o.IsRequired(_str_strFunctionName)); 
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
              _name = _str_blnReadOnly, _formname = _str_blnReadOnly, _type = "Boolean",
              _get_func = o => o.blnReadOnly,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnReadOnly != newval) o.blnReadOnly = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnReadOnly != c.blnReadOnly || o.IsRIRPropChanged(_str_blnReadOnly, c)) 
                  m.Add(_str_blnReadOnly, o.ObjectIdent + _str_blnReadOnly, o.ObjectIdent2 + _str_blnReadOnly, o.ObjectIdent3 + _str_blnReadOnly, "Boolean", 
                    o.blnReadOnly == null ? "" : o.blnReadOnly.ToString(),                  
                  o.IsReadOnly(_str_blnReadOnly), o.IsInvisible(_str_blnReadOnly), o.IsRequired(_str_blnReadOnly)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intOrder, _formname = _str_intOrder, _type = "Int32",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intOrder != newval) o.intOrder = newval; },
              _compare_func = (o, c, m) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, o.ObjectIdent2 + _str_intOrder, o.ObjectIdent3 + _str_intOrder, "Int32", 
                    o.intOrder == null ? "" : o.intOrder.ToString(),                  
                  o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnIsOutbreak, _formname = _str_blnIsOutbreak, _type = "Int32",
              _get_func = o => o.blnIsOutbreak,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.blnIsOutbreak != newval) o.blnIsOutbreak = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnIsOutbreak != c.blnIsOutbreak || o.IsRIRPropChanged(_str_blnIsOutbreak, c)) 
                  m.Add(_str_blnIsOutbreak, o.ObjectIdent + _str_blnIsOutbreak, o.ObjectIdent2 + _str_blnIsOutbreak, o.ObjectIdent3 + _str_blnIsOutbreak, "Int32", 
                    o.blnIsOutbreak == null ? "" : o.blnIsOutbreak.ToString(),                  
                  o.IsReadOnly(_str_blnIsOutbreak), o.IsInvisible(_str_blnIsOutbreak), o.IsRequired(_str_blnIsOutbreak)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnIsHumanCase, _formname = _str_blnIsHumanCase, _type = "Int32",
              _get_func = o => o.blnIsHumanCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.blnIsHumanCase != newval) o.blnIsHumanCase = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnIsHumanCase != c.blnIsHumanCase || o.IsRIRPropChanged(_str_blnIsHumanCase, c)) 
                  m.Add(_str_blnIsHumanCase, o.ObjectIdent + _str_blnIsHumanCase, o.ObjectIdent2 + _str_blnIsHumanCase, o.ObjectIdent3 + _str_blnIsHumanCase, "Int32", 
                    o.blnIsHumanCase == null ? "" : o.blnIsHumanCase.ToString(),                  
                  o.IsReadOnly(_str_blnIsHumanCase), o.IsInvisible(_str_blnIsHumanCase), o.IsRequired(_str_blnIsHumanCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnIsVetCase, _formname = _str_blnIsVetCase, _type = "Int32",
              _get_func = o => o.blnIsVetCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.blnIsVetCase != newval) o.blnIsVetCase = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnIsVetCase != c.blnIsVetCase || o.IsRIRPropChanged(_str_blnIsVetCase, c)) 
                  m.Add(_str_blnIsVetCase, o.ObjectIdent + _str_blnIsVetCase, o.ObjectIdent2 + _str_blnIsVetCase, o.ObjectIdent3 + _str_blnIsVetCase, "Int32", 
                    o.blnIsVetCase == null ? "" : o.blnIsVetCase.ToString(),                  
                  o.IsReadOnly(_str_blnIsVetCase), o.IsInvisible(_str_blnIsVetCase), o.IsRequired(_str_blnIsVetCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnIsASCampaign, _formname = _str_blnIsASCampaign, _type = "Int32",
              _get_func = o => o.blnIsASCampaign,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.blnIsASCampaign != newval) o.blnIsASCampaign = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnIsASCampaign != c.blnIsASCampaign || o.IsRIRPropChanged(_str_blnIsASCampaign, c)) 
                  m.Add(_str_blnIsASCampaign, o.ObjectIdent + _str_blnIsASCampaign, o.ObjectIdent2 + _str_blnIsASCampaign, o.ObjectIdent3 + _str_blnIsASCampaign, "Int32", 
                    o.blnIsASCampaign == null ? "" : o.blnIsASCampaign.ToString(),                  
                  o.IsReadOnly(_str_blnIsASCampaign), o.IsInvisible(_str_blnIsASCampaign), o.IsRequired(_str_blnIsASCampaign)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnIsASSession, _formname = _str_blnIsASSession, _type = "Int32",
              _get_func = o => o.blnIsASSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.blnIsASSession != newval) o.blnIsASSession = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnIsASSession != c.blnIsASSession || o.IsRIRPropChanged(_str_blnIsASSession, c)) 
                  m.Add(_str_blnIsASSession, o.ObjectIdent + _str_blnIsASSession, o.ObjectIdent2 + _str_blnIsASSession, o.ObjectIdent3 + _str_blnIsASSession, "Int32", 
                    o.blnIsASSession == null ? "" : o.blnIsASSession.ToString(),                  
                  o.IsReadOnly(_str_blnIsASSession), o.IsInvisible(_str_blnIsASSession), o.IsRequired(_str_blnIsASSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnIsSample, _formname = _str_blnIsSample, _type = "Int32",
              _get_func = o => o.blnIsSample,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.blnIsSample != newval) o.blnIsSample = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnIsSample != c.blnIsSample || o.IsRIRPropChanged(_str_blnIsSample, c)) 
                  m.Add(_str_blnIsSample, o.ObjectIdent + _str_blnIsSample, o.ObjectIdent2 + _str_blnIsSample, o.ObjectIdent3 + _str_blnIsSample, "Int32", 
                    o.blnIsSample == null ? "" : o.blnIsSample.ToString(),                  
                  o.IsReadOnly(_str_blnIsSample), o.IsInvisible(_str_blnIsSample), o.IsRequired(_str_blnIsSample)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnIsTest, _formname = _str_blnIsTest, _type = "Int32",
              _get_func = o => o.blnIsTest,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.blnIsTest != newval) o.blnIsTest = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnIsTest != c.blnIsTest || o.IsRIRPropChanged(_str_blnIsTest, c)) 
                  m.Add(_str_blnIsTest, o.ObjectIdent + _str_blnIsTest, o.ObjectIdent2 + _str_blnIsTest, o.ObjectIdent3 + _str_blnIsTest, "Int32", 
                    o.blnIsTest == null ? "" : o.blnIsTest.ToString(),                  
                  o.IsReadOnly(_str_blnIsTest), o.IsInvisible(_str_blnIsTest), o.IsRequired(_str_blnIsTest)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intHACode, _formname = _str_intHACode, _type = "Int32?",
              _get_func = o => o.intHACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intHACode != newval) o.intHACode = newval; },
              _compare_func = (o, c, m) => {
                if (o.intHACode != c.intHACode || o.IsRIRPropChanged(_str_intHACode, c)) 
                  m.Add(_str_intHACode, o.ObjectIdent + _str_intHACode, o.ObjectIdent2 + _str_intHACode, o.ObjectIdent3 + _str_intHACode, "Int32?", 
                    o.intHACode == null ? "" : o.intHACode.ToString(),                  
                  o.IsReadOnly(_str_intHACode), o.IsInvisible(_str_intHACode), o.IsRequired(_str_intHACode)); 
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
            AvrQueryLookup obj = (AvrQueryLookup)o;
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
        internal string m_ObjectName = "AvrQueryLookup";

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
        public override object Clone()
        {
            var ret = base.Clone() as AvrQueryLookup;
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
            var ret = base.Clone() as AvrQueryLookup;
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
        public AvrQueryLookup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AvrQueryLookup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idflQuery; } }
        public string KeyName { get { return "idflQuery"; } }
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

        private bool IsRIRPropChanged(string fld, AvrQueryLookup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      
        public override string ToString()
        {
            return new Func<AvrQueryLookup, string>(c => c.DefQueryName)(this);
        }
        

        public AvrQueryLookup()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AvrQueryLookup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AvrQueryLookup_PropertyChanged);
        }
        private void AvrQueryLookup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AvrQueryLookup).Changed(e.PropertyName);
            
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
            AvrQueryLookup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AvrQueryLookup obj = this;
            
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
        
            }
        }


        internal Dictionary<string, Func<AvrQueryLookup, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<AvrQueryLookup, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AvrQueryLookup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AvrQueryLookup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<AvrQueryLookup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<AvrQueryLookup, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<AvrQueryLookup, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AvrQueryLookup()
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
        : DataAccessor<AvrQueryLookup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<AvrQueryLookup>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idflQuery"; } }
            #endregion
        
            private delegate void on_action(AvrQueryLookup obj);
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
            [InstanceCache(typeof(BvCacheAspect))]
            public virtual List<AvrQueryLookup> SelectLookupList(DbManagerProxy manager
                , Int64? QueryID
                )
            {
                return _SelectList(manager
                    , QueryID
                    , null, null
                    );
            }
            
            public static string GetLookupTableName(string method)
            {
                return "Query";
            }
            
            public virtual List<AvrQueryLookup> SelectList(DbManagerProxy manager
                , Int64? QueryID
                )
            {
                return _SelectList(manager
                    , QueryID
                    , delegate(AvrQueryLookup obj)
                        {
                        }
                    , delegate(AvrQueryLookup obj)
                        {
                        }
                    );
            }

            
            private List<AvrQueryLookup> _SelectList(DbManagerProxy manager
                , Int64? QueryID
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<AvrQueryLookup> objs = new List<AvrQueryLookup>();
                    sets[0] = new MapResultSet(typeof(AvrQueryLookup), objs);
                    
                    manager
                        .SetSpCommand("spAsQuerySelectLookup"
                            , manager.Parameter("@QueryID", QueryID)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, AvrQueryLookup obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AvrQueryLookup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AvrQueryLookup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    AvrQueryLookup obj = AvrQueryLookup.CreateInstance();
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

            
            public AvrQueryLookup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public AvrQueryLookup CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public AvrQueryLookup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(AvrQueryLookup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AvrQueryLookup obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, AvrQueryLookup obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(AvrQueryLookup obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(AvrQueryLookup obj, bool bRethrowException)
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
                return Validate(manager, obj as AvrQueryLookup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AvrQueryLookup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(AvrQueryLookup obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(AvrQueryLookup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AvrQueryLookup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AvrQueryLookup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AvrQueryLookupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spAsQuerySelectLookup";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AvrQueryLookup, bool>> RequiredByField = new Dictionary<string, Func<AvrQueryLookup, bool>>();
            public static Dictionary<string, Func<AvrQueryLookup, bool>> RequiredByProperty = new Dictionary<string, Func<AvrQueryLookup, bool>>();
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
                
                Sizes.Add(_str_DefQueryName, 2000);
                Sizes.Add(_str_QueryName, 2000);
                Sizes.Add(_str_strFunctionName, 200);
                Sizes.Add(_str_strDescription, 2000);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AvrQueryLookup>().Post(manager, (AvrQueryLookup)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AvrQueryLookup>().Post(manager, (AvrQueryLookup)c), c),
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
                    (manager, c, pars) => new ActResult(((AvrQueryLookup)c).MarkToDelete() && ObjectAccessor.PostInterface<AvrQueryLookup>().Post(manager, (AvrQueryLookup)c), c),
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
	