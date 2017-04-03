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
    public abstract partial class AggregateFunctionLookup : 
        EditableObject<AggregateFunctionLookup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfAggregateFunction), NonUpdatable, PrimaryKey]
        public abstract Int64 idfAggregateFunction { get; set; }
                
        [LocalizedDisplayName(_str_idfsAggregateFunction)]
        [MapField(_str_idfsAggregateFunction)]
        public abstract String idfsAggregateFunction { get; set; }
        protected String idfsAggregateFunction_Original { get { return ((EditableValue<String>)((dynamic)this)._idfsAggregateFunction).OriginalValue; } }
        protected String idfsAggregateFunction_Previous { get { return ((EditableValue<String>)((dynamic)this)._idfsAggregateFunction).PreviousValue; } }
                
        [LocalizedDisplayName(_str_AggregateFunctionNameDef)]
        [MapField(_str_AggregateFunctionNameDef)]
        public abstract String AggregateFunctionNameDef { get; set; }
        protected String AggregateFunctionNameDef_Original { get { return ((EditableValue<String>)((dynamic)this)._aggregateFunctionNameDef).OriginalValue; } }
        protected String AggregateFunctionNameDef_Previous { get { return ((EditableValue<String>)((dynamic)this)._aggregateFunctionNameDef).PreviousValue; } }
                
        [LocalizedDisplayName(_str_AggregateFunctionName)]
        [MapField(_str_AggregateFunctionName)]
        public abstract String AggregateFunctionName { get; set; }
        protected String AggregateFunctionName_Original { get { return ((EditableValue<String>)((dynamic)this)._aggregateFunctionName).OriginalValue; } }
        protected String AggregateFunctionName_Previous { get { return ((EditableValue<String>)((dynamic)this)._aggregateFunctionName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnPivotGridFunction)]
        [MapField(_str_blnPivotGridFunction)]
        public abstract Boolean blnPivotGridFunction { get; set; }
        protected Boolean blnPivotGridFunction_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnPivotGridFunction).OriginalValue; } }
        protected Boolean blnPivotGridFunction_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnPivotGridFunction).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnViewFunction)]
        [MapField(_str_blnViewFunction)]
        public abstract Boolean blnViewFunction { get; set; }
        protected Boolean blnViewFunction_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnViewFunction).OriginalValue; } }
        protected Boolean blnViewFunction_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnViewFunction).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intDefaultPrecision)]
        [MapField(_str_intDefaultPrecision)]
        public abstract Int32 intDefaultPrecision { get; set; }
        protected Int32 intDefaultPrecision_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intDefaultPrecision).OriginalValue; } }
        protected Int32 intDefaultPrecision_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intDefaultPrecision).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32? intOrder { get; set; }
        protected Int32? intOrder_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32? intOrder_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<AggregateFunctionLookup, object> _get_func;
            internal Action<AggregateFunctionLookup, string> _set_func;
            internal Action<AggregateFunctionLookup, AggregateFunctionLookup, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfAggregateFunction = "idfAggregateFunction";
        internal const string _str_idfsAggregateFunction = "idfsAggregateFunction";
        internal const string _str_AggregateFunctionNameDef = "AggregateFunctionNameDef";
        internal const string _str_AggregateFunctionName = "AggregateFunctionName";
        internal const string _str_blnPivotGridFunction = "blnPivotGridFunction";
        internal const string _str_blnViewFunction = "blnViewFunction";
        internal const string _str_intDefaultPrecision = "intDefaultPrecision";
        internal const string _str_intOrder = "intOrder";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfAggregateFunction, _formname = _str_idfAggregateFunction, _type = "Int64",
              _get_func = o => o.idfAggregateFunction,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfAggregateFunction != newval) o.idfAggregateFunction = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfAggregateFunction != c.idfAggregateFunction || o.IsRIRPropChanged(_str_idfAggregateFunction, c)) 
                  m.Add(_str_idfAggregateFunction, o.ObjectIdent + _str_idfAggregateFunction, o.ObjectIdent2 + _str_idfAggregateFunction, o.ObjectIdent3 + _str_idfAggregateFunction, "Int64", 
                    o.idfAggregateFunction == null ? "" : o.idfAggregateFunction.ToString(),                  
                  o.IsReadOnly(_str_idfAggregateFunction), o.IsInvisible(_str_idfAggregateFunction), o.IsRequired(_str_idfAggregateFunction)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAggregateFunction, _formname = _str_idfsAggregateFunction, _type = "String",
              _get_func = o => o.idfsAggregateFunction,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.idfsAggregateFunction != newval) o.idfsAggregateFunction = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsAggregateFunction != c.idfsAggregateFunction || o.IsRIRPropChanged(_str_idfsAggregateFunction, c)) 
                  m.Add(_str_idfsAggregateFunction, o.ObjectIdent + _str_idfsAggregateFunction, o.ObjectIdent2 + _str_idfsAggregateFunction, o.ObjectIdent3 + _str_idfsAggregateFunction, "String", 
                    o.idfsAggregateFunction == null ? "" : o.idfsAggregateFunction.ToString(),                  
                  o.IsReadOnly(_str_idfsAggregateFunction), o.IsInvisible(_str_idfsAggregateFunction), o.IsRequired(_str_idfsAggregateFunction)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_AggregateFunctionNameDef, _formname = _str_AggregateFunctionNameDef, _type = "String",
              _get_func = o => o.AggregateFunctionNameDef,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.AggregateFunctionNameDef != newval) o.AggregateFunctionNameDef = newval; },
              _compare_func = (o, c, m) => {
                if (o.AggregateFunctionNameDef != c.AggregateFunctionNameDef || o.IsRIRPropChanged(_str_AggregateFunctionNameDef, c)) 
                  m.Add(_str_AggregateFunctionNameDef, o.ObjectIdent + _str_AggregateFunctionNameDef, o.ObjectIdent2 + _str_AggregateFunctionNameDef, o.ObjectIdent3 + _str_AggregateFunctionNameDef, "String", 
                    o.AggregateFunctionNameDef == null ? "" : o.AggregateFunctionNameDef.ToString(),                  
                  o.IsReadOnly(_str_AggregateFunctionNameDef), o.IsInvisible(_str_AggregateFunctionNameDef), o.IsRequired(_str_AggregateFunctionNameDef)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_AggregateFunctionName, _formname = _str_AggregateFunctionName, _type = "String",
              _get_func = o => o.AggregateFunctionName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.AggregateFunctionName != newval) o.AggregateFunctionName = newval; },
              _compare_func = (o, c, m) => {
                if (o.AggregateFunctionName != c.AggregateFunctionName || o.IsRIRPropChanged(_str_AggregateFunctionName, c)) 
                  m.Add(_str_AggregateFunctionName, o.ObjectIdent + _str_AggregateFunctionName, o.ObjectIdent2 + _str_AggregateFunctionName, o.ObjectIdent3 + _str_AggregateFunctionName, "String", 
                    o.AggregateFunctionName == null ? "" : o.AggregateFunctionName.ToString(),                  
                  o.IsReadOnly(_str_AggregateFunctionName), o.IsInvisible(_str_AggregateFunctionName), o.IsRequired(_str_AggregateFunctionName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnPivotGridFunction, _formname = _str_blnPivotGridFunction, _type = "Boolean",
              _get_func = o => o.blnPivotGridFunction,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnPivotGridFunction != newval) o.blnPivotGridFunction = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnPivotGridFunction != c.blnPivotGridFunction || o.IsRIRPropChanged(_str_blnPivotGridFunction, c)) 
                  m.Add(_str_blnPivotGridFunction, o.ObjectIdent + _str_blnPivotGridFunction, o.ObjectIdent2 + _str_blnPivotGridFunction, o.ObjectIdent3 + _str_blnPivotGridFunction, "Boolean", 
                    o.blnPivotGridFunction == null ? "" : o.blnPivotGridFunction.ToString(),                  
                  o.IsReadOnly(_str_blnPivotGridFunction), o.IsInvisible(_str_blnPivotGridFunction), o.IsRequired(_str_blnPivotGridFunction)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnViewFunction, _formname = _str_blnViewFunction, _type = "Boolean",
              _get_func = o => o.blnViewFunction,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnViewFunction != newval) o.blnViewFunction = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnViewFunction != c.blnViewFunction || o.IsRIRPropChanged(_str_blnViewFunction, c)) 
                  m.Add(_str_blnViewFunction, o.ObjectIdent + _str_blnViewFunction, o.ObjectIdent2 + _str_blnViewFunction, o.ObjectIdent3 + _str_blnViewFunction, "Boolean", 
                    o.blnViewFunction == null ? "" : o.blnViewFunction.ToString(),                  
                  o.IsReadOnly(_str_blnViewFunction), o.IsInvisible(_str_blnViewFunction), o.IsRequired(_str_blnViewFunction)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intDefaultPrecision, _formname = _str_intDefaultPrecision, _type = "Int32",
              _get_func = o => o.intDefaultPrecision,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intDefaultPrecision != newval) o.intDefaultPrecision = newval; },
              _compare_func = (o, c, m) => {
                if (o.intDefaultPrecision != c.intDefaultPrecision || o.IsRIRPropChanged(_str_intDefaultPrecision, c)) 
                  m.Add(_str_intDefaultPrecision, o.ObjectIdent + _str_intDefaultPrecision, o.ObjectIdent2 + _str_intDefaultPrecision, o.ObjectIdent3 + _str_intDefaultPrecision, "Int32", 
                    o.intDefaultPrecision == null ? "" : o.intDefaultPrecision.ToString(),                  
                  o.IsReadOnly(_str_intDefaultPrecision), o.IsInvisible(_str_intDefaultPrecision), o.IsRequired(_str_intDefaultPrecision)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intOrder, _formname = _str_intOrder, _type = "Int32?",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intOrder != newval) o.intOrder = newval; },
              _compare_func = (o, c, m) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, o.ObjectIdent2 + _str_intOrder, o.ObjectIdent3 + _str_intOrder, "Int32?", 
                    o.intOrder == null ? "" : o.intOrder.ToString(),                  
                  o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); 
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
            AggregateFunctionLookup obj = (AggregateFunctionLookup)o;
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
        internal string m_ObjectName = "AggregateFunctionLookup";

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
            var ret = base.Clone() as AggregateFunctionLookup;
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
            var ret = base.Clone() as AggregateFunctionLookup;
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
        public AggregateFunctionLookup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AggregateFunctionLookup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfAggregateFunction; } }
        public string KeyName { get { return "idfAggregateFunction"; } }
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

        private bool IsRIRPropChanged(string fld, AggregateFunctionLookup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      
        public override string ToString()
        {
            return new Func<AggregateFunctionLookup, string>(c => c.AggregateFunctionName)(this);
        }
        

        public AggregateFunctionLookup()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AggregateFunctionLookup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AggregateFunctionLookup_PropertyChanged);
        }
        private void AggregateFunctionLookup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AggregateFunctionLookup).Changed(e.PropertyName);
            
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
            AggregateFunctionLookup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AggregateFunctionLookup obj = this;
            
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


        internal Dictionary<string, Func<AggregateFunctionLookup, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<AggregateFunctionLookup, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AggregateFunctionLookup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AggregateFunctionLookup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<AggregateFunctionLookup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<AggregateFunctionLookup, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<AggregateFunctionLookup, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AggregateFunctionLookup()
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
        : DataAccessor<AggregateFunctionLookup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<AggregateFunctionLookup>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfAggregateFunction"; } }
            #endregion
        
            private delegate void on_action(AggregateFunctionLookup obj);
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
            public virtual List<AggregateFunctionLookup> SelectLookupList(DbManagerProxy manager
                )
            {
                return _SelectList(manager
                    , null, null
                    );
            }
            
            public static string GetLookupTableName(string method)
            {
                return "AggregateFunction";
            }
            
            public virtual List<AggregateFunctionLookup> SelectList(DbManagerProxy manager
                )
            {
                return _SelectList(manager
                    , delegate(AggregateFunctionLookup obj)
                        {
                        }
                    , delegate(AggregateFunctionLookup obj)
                        {
                        }
                    );
            }

            
            private List<AggregateFunctionLookup> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<AggregateFunctionLookup> objs = new List<AggregateFunctionLookup>();
                    sets[0] = new MapResultSet(typeof(AggregateFunctionLookup), objs);
                    
                    manager
                        .SetSpCommand("spAsAggregateFunctionSelectLookup"
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, AggregateFunctionLookup obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AggregateFunctionLookup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AggregateFunctionLookup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    AggregateFunctionLookup obj = AggregateFunctionLookup.CreateInstance();
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

            
            public AggregateFunctionLookup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public AggregateFunctionLookup CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public AggregateFunctionLookup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(AggregateFunctionLookup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AggregateFunctionLookup obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, AggregateFunctionLookup obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(AggregateFunctionLookup obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(AggregateFunctionLookup obj, bool bRethrowException)
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
                return Validate(manager, obj as AggregateFunctionLookup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AggregateFunctionLookup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(AggregateFunctionLookup obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(AggregateFunctionLookup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AggregateFunctionLookup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AggregateFunctionLookup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AggregateFunctionLookupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spAsAggregateFunctionSelectLookup";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AggregateFunctionLookup, bool>> RequiredByField = new Dictionary<string, Func<AggregateFunctionLookup, bool>>();
            public static Dictionary<string, Func<AggregateFunctionLookup, bool>> RequiredByProperty = new Dictionary<string, Func<AggregateFunctionLookup, bool>>();
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
                
                Sizes.Add(_str_idfsAggregateFunction, 36);
                Sizes.Add(_str_AggregateFunctionNameDef, 2000);
                Sizes.Add(_str_AggregateFunctionName, 2000);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AggregateFunctionLookup>().Post(manager, (AggregateFunctionLookup)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AggregateFunctionLookup>().Post(manager, (AggregateFunctionLookup)c), c),
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
                    (manager, c, pars) => new ActResult(((AggregateFunctionLookup)c).MarkToDelete() && ObjectAccessor.PostInterface<AggregateFunctionLookup>().Post(manager, (AggregateFunctionLookup)c), c),
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
	