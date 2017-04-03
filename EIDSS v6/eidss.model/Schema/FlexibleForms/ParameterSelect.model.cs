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
    public abstract partial class ParameterSelect : 
        EditableObject<ParameterSelect>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsParameter), NonUpdatable, PrimaryKey]
        public abstract Int64? idfsParameter { get; set; }
                
        [LocalizedDisplayName(_str_idfsParameterType)]
        [MapField(_str_idfsParameterType)]
        public abstract Int64? idfsParameterType { get; set; }
        protected Int64? idfsParameterType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParameterType).OriginalValue; } }
        protected Int64? idfsParameterType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParameterType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsReferenceType)]
        [MapField(_str_idfsReferenceType)]
        public abstract Int64? idfsReferenceType { get; set; }
        protected Int64? idfsReferenceType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsReferenceType).OriginalValue; } }
        protected Int64? idfsReferenceType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsReferenceType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsValue)]
        [MapField(_str_idfsValue)]
        public abstract Int64? idfsValue { get; set; }
        protected Int64? idfsValue_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsValue).OriginalValue; } }
        protected Int64? idfsValue_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsValue).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strValueCaption)]
        [MapField(_str_strValueCaption)]
        public abstract String strValueCaption { get; set; }
        protected String strValueCaption_Original { get { return ((EditableValue<String>)((dynamic)this)._strValueCaption).OriginalValue; } }
        protected String strValueCaption_Previous { get { return ((EditableValue<String>)((dynamic)this)._strValueCaption).PreviousValue; } }
                
        [LocalizedDisplayName(_str_langid)]
        [MapField(_str_langid)]
        public abstract String langid { get; set; }
        protected String langid_Original { get { return ((EditableValue<String>)((dynamic)this)._langid).OriginalValue; } }
        protected String langid_Previous { get { return ((EditableValue<String>)((dynamic)this)._langid).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32? intOrder { get; set; }
        protected Int32? intOrder_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32? intOrder_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int32? intHACode { get; set; }
        protected Int32? intHACode_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32? intHACode_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intRowStatus)]
        [MapField(_str_intRowStatus)]
        public abstract Int32? intRowStatus { get; set; }
        protected Int32? intRowStatus_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intRowStatus).OriginalValue; } }
        protected Int32? intRowStatus_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intRowStatus).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<ParameterSelect, object> _get_func;
            internal Action<ParameterSelect, string> _set_func;
            internal Action<ParameterSelect, ParameterSelect, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsParameter = "idfsParameter";
        internal const string _str_idfsParameterType = "idfsParameterType";
        internal const string _str_idfsReferenceType = "idfsReferenceType";
        internal const string _str_idfsValue = "idfsValue";
        internal const string _str_strValueCaption = "strValueCaption";
        internal const string _str_langid = "langid";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_intRowStatus = "intRowStatus";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsParameter, _formname = _str_idfsParameter, _type = "Int64?",
              _get_func = o => o.idfsParameter,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsParameter != newval) o.idfsParameter = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsParameter != c.idfsParameter || o.IsRIRPropChanged(_str_idfsParameter, c)) 
                  m.Add(_str_idfsParameter, o.ObjectIdent + _str_idfsParameter, o.ObjectIdent2 + _str_idfsParameter, o.ObjectIdent3 + _str_idfsParameter, "Int64?", 
                    o.idfsParameter == null ? "" : o.idfsParameter.ToString(),                  
                  o.IsReadOnly(_str_idfsParameter), o.IsInvisible(_str_idfsParameter), o.IsRequired(_str_idfsParameter)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsParameterType, _formname = _str_idfsParameterType, _type = "Int64?",
              _get_func = o => o.idfsParameterType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsParameterType != newval) o.idfsParameterType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsParameterType != c.idfsParameterType || o.IsRIRPropChanged(_str_idfsParameterType, c)) 
                  m.Add(_str_idfsParameterType, o.ObjectIdent + _str_idfsParameterType, o.ObjectIdent2 + _str_idfsParameterType, o.ObjectIdent3 + _str_idfsParameterType, "Int64?", 
                    o.idfsParameterType == null ? "" : o.idfsParameterType.ToString(),                  
                  o.IsReadOnly(_str_idfsParameterType), o.IsInvisible(_str_idfsParameterType), o.IsRequired(_str_idfsParameterType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsReferenceType, _formname = _str_idfsReferenceType, _type = "Int64?",
              _get_func = o => o.idfsReferenceType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsReferenceType != newval) o.idfsReferenceType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsReferenceType != c.idfsReferenceType || o.IsRIRPropChanged(_str_idfsReferenceType, c)) 
                  m.Add(_str_idfsReferenceType, o.ObjectIdent + _str_idfsReferenceType, o.ObjectIdent2 + _str_idfsReferenceType, o.ObjectIdent3 + _str_idfsReferenceType, "Int64?", 
                    o.idfsReferenceType == null ? "" : o.idfsReferenceType.ToString(),                  
                  o.IsReadOnly(_str_idfsReferenceType), o.IsInvisible(_str_idfsReferenceType), o.IsRequired(_str_idfsReferenceType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsValue, _formname = _str_idfsValue, _type = "Int64?",
              _get_func = o => o.idfsValue,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsValue != newval) o.idfsValue = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsValue != c.idfsValue || o.IsRIRPropChanged(_str_idfsValue, c)) 
                  m.Add(_str_idfsValue, o.ObjectIdent + _str_idfsValue, o.ObjectIdent2 + _str_idfsValue, o.ObjectIdent3 + _str_idfsValue, "Int64?", 
                    o.idfsValue == null ? "" : o.idfsValue.ToString(),                  
                  o.IsReadOnly(_str_idfsValue), o.IsInvisible(_str_idfsValue), o.IsRequired(_str_idfsValue)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strValueCaption, _formname = _str_strValueCaption, _type = "String",
              _get_func = o => o.strValueCaption,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strValueCaption != newval) o.strValueCaption = newval; },
              _compare_func = (o, c, m) => {
                if (o.strValueCaption != c.strValueCaption || o.IsRIRPropChanged(_str_strValueCaption, c)) 
                  m.Add(_str_strValueCaption, o.ObjectIdent + _str_strValueCaption, o.ObjectIdent2 + _str_strValueCaption, o.ObjectIdent3 + _str_strValueCaption, "String", 
                    o.strValueCaption == null ? "" : o.strValueCaption.ToString(),                  
                  o.IsReadOnly(_str_strValueCaption), o.IsInvisible(_str_strValueCaption), o.IsRequired(_str_strValueCaption)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_langid, _formname = _str_langid, _type = "String",
              _get_func = o => o.langid,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.langid != newval) o.langid = newval; },
              _compare_func = (o, c, m) => {
                if (o.langid != c.langid || o.IsRIRPropChanged(_str_langid, c)) 
                  m.Add(_str_langid, o.ObjectIdent + _str_langid, o.ObjectIdent2 + _str_langid, o.ObjectIdent3 + _str_langid, "String", 
                    o.langid == null ? "" : o.langid.ToString(),                  
                  o.IsReadOnly(_str_langid), o.IsInvisible(_str_langid), o.IsRequired(_str_langid)); 
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
                  
            new field_info {
              _name = _str_intRowStatus, _formname = _str_intRowStatus, _type = "Int32?",
              _get_func = o => o.intRowStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intRowStatus != newval) o.intRowStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.intRowStatus != c.intRowStatus || o.IsRIRPropChanged(_str_intRowStatus, c)) 
                  m.Add(_str_intRowStatus, o.ObjectIdent + _str_intRowStatus, o.ObjectIdent2 + _str_intRowStatus, o.ObjectIdent3 + _str_intRowStatus, "Int32?", 
                    o.intRowStatus == null ? "" : o.intRowStatus.ToString(),                  
                  o.IsReadOnly(_str_intRowStatus), o.IsInvisible(_str_intRowStatus), o.IsRequired(_str_intRowStatus)); 
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
            ParameterSelect obj = (ParameterSelect)o;
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
        internal string m_ObjectName = "ParameterSelect";

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
            var ret = base.Clone() as ParameterSelect;
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
            var ret = base.Clone() as ParameterSelect;
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
        public ParameterSelect CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as ParameterSelect;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsParameter; } }
        public string KeyName { get { return "idfsParameter"; } }
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

        private bool IsRIRPropChanged(string fld, ParameterSelect c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public ParameterSelect()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ParameterSelect_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(ParameterSelect_PropertyChanged);
        }
        private void ParameterSelect_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as ParameterSelect).Changed(e.PropertyName);
            
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
            ParameterSelect obj = this;
            
        }
        private void _DeletedExtenders()
        {
            ParameterSelect obj = this;
            
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


        internal Dictionary<string, Func<ParameterSelect, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<ParameterSelect, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<ParameterSelect, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<ParameterSelect, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<ParameterSelect, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<ParameterSelect, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<ParameterSelect, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~ParameterSelect()
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
        : DataAccessor<ParameterSelect>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<ParameterSelect>
            
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsParameter"; } }
            #endregion
        
            private delegate void on_action(ParameterSelect obj);
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
            
            public virtual List<ParameterSelect> SelectList(DbManagerProxy manager
                , Int64? idfsParameter
                , Int64? idfsParameterType
                , Int64? intHACode
                )
            {
                return _SelectList(manager
                    , idfsParameter
                    , idfsParameterType
                    , intHACode
                    , delegate(ParameterSelect obj)
                        {
                        }
                    , delegate(ParameterSelect obj)
                        {
                        }
                    );
            }

            
            public List<ParameterSelect> SelectDetailListT(DbManagerProxy manager, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                
                if (!(pars[0] is Int64?)) 
                    throw new TypeMismatchException("idfsParameter", typeof(Int64?));
                
                if (!(pars[1] is Int64?)) 
                    throw new TypeMismatchException("idfsParameterType", typeof(Int64?));
                
                if (!(pars[2] is Int64?)) 
                    throw new TypeMismatchException("intHACode", typeof(Int64?));
                
                return SelectDetailList(manager
                    
                    , (Int64?)pars[0]
                    
                    , (Int64?)pars[1]
                    
                    , (Int64?)pars[2]
                    
                    );
            }
            public List<ParameterSelect> SelectDetailList(DbManagerProxy manager, List<object> pars)
            {
                return SelectDetailListT(manager, pars);
            }
            
            public virtual List<ParameterSelect> SelectDetailList(DbManagerProxy manager
                , Int64? idfsParameter
                , Int64? idfsParameterType
                , Int64? intHACode
                )
            {
                return _SelectList(manager
                    , idfsParameter
                    , idfsParameterType
                    , intHACode
                    , delegate(ParameterSelect obj)
                        {
                
                        }
                    , delegate(ParameterSelect obj)
                        {
                
                        }
                    );
            }
            
            private List<ParameterSelect> _SelectList(DbManagerProxy manager
                , Int64? idfsParameter
                , Int64? idfsParameterType
                , Int64? intHACode
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<ParameterSelect> objs = new List<ParameterSelect>();
                    sets[0] = new MapResultSet(typeof(ParameterSelect), objs);
                    
                    manager
                        .SetSpCommand("spFFGetParameterSelectList"
                            , manager.Parameter("@idfsParameter", idfsParameter)
                            , manager.Parameter("@idfsParameterType", idfsParameterType)
                            , manager.Parameter("@intHACode", intHACode)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, ParameterSelect obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, ParameterSelect obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private ParameterSelect _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    ParameterSelect obj = ParameterSelect.CreateInstance();
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

            
            public ParameterSelect CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public ParameterSelect CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public ParameterSelect CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ParameterSelect CreateDefaultT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfsParameter", typeof(long));
                if (pars[1] != null && !(pars[1] is long?)) 
                    throw new TypeMismatchException("idfsParameterType", typeof(long?));
                if (pars[2] != null && !(pars[2] is int?)) 
                    throw new TypeMismatchException("intHACode", typeof(int?));
                
                return CreateDefault(manager, Parent
                    , (long)pars[0]
                    , (long?)pars[1]
                    , (int?)pars[2]
                    );
            }
            public IObject CreateDefault(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateDefaultT(manager, Parent, pars);
            }
            public ParameterSelect CreateDefault(DbManagerProxy manager, IObject Parent
                , long idfsParameter
                , long? idfsParameterType
                , int? intHACode
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                }
                    , obj =>
                {
                obj.idfsParameter = new Func<ParameterSelect, long>(c => idfsParameter)(obj);
                obj.idfsParameterType = new Func<ParameterSelect, long?>(c => idfsParameterType)(obj);
                obj.idfsValue = new Func<ParameterSelect, long>(c => -1000)(obj);
                obj.intOrder = new Func<ParameterSelect, int>(c => -1)(obj);
                obj.intHACode = new Func<ParameterSelect, int?>(c => intHACode)(obj);
                obj.langid = new Func<ParameterSelect, string>(c => ModelUserContext.CurrentLanguage)(obj);
                obj.strValueCaption = new Func<ParameterSelect, string>(c => String.Empty)(obj);
                }
                );
            }
            
            private void _SetupChildHandlers(ParameterSelect obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(ParameterSelect obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, ParameterSelect obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(ParameterSelect obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(ParameterSelect obj, bool bRethrowException)
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
                return Validate(manager, obj as ParameterSelect, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, ParameterSelect obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(ParameterSelect obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(ParameterSelect obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as ParameterSelect) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as ParameterSelect) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "ParameterSelectDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFFGetParameterSelectList";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<ParameterSelect, bool>> RequiredByField = new Dictionary<string, Func<ParameterSelect, bool>>();
            public static Dictionary<string, Func<ParameterSelect, bool>> RequiredByProperty = new Dictionary<string, Func<ParameterSelect, bool>>();
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
                
                Sizes.Add(_str_strValueCaption, 300);
                Sizes.Add(_str_langid, 50);
                Actions.Add(new ActionMetaItem(
                    "SelectDetailList",
                    ActionTypes.Loadlist,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
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
                    "CreateDefault",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateDefault(manager, c, pars)),
                        
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<ParameterSelect>().Post(manager, (ParameterSelect)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<ParameterSelect>().Post(manager, (ParameterSelect)c), c),
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
                    (manager, c, pars) => new ActResult(((ParameterSelect)c).MarkToDelete() && ObjectAccessor.PostInterface<ParameterSelect>().Post(manager, (ParameterSelect)c), c),
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
	