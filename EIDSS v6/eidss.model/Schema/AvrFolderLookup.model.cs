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
    public abstract partial class AvrFolderLookup : 
        EditableObject<AvrFolderLookup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idflFolder), NonUpdatable, PrimaryKey]
        public abstract Int64 idflFolder { get; set; }
                
        [LocalizedDisplayName(_str_idflParentFolder)]
        [MapField(_str_idflParentFolder)]
        public abstract Int64? idflParentFolder { get; set; }
        protected Int64? idflParentFolder_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idflParentFolder).OriginalValue; } }
        protected Int64? idflParentFolder_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idflParentFolder).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsGlobalFolder)]
        [MapField(_str_idfsGlobalFolder)]
        public abstract Int64? idfsGlobalFolder { get; set; }
        protected Int64? idfsGlobalFolder_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGlobalFolder).OriginalValue; } }
        protected Int64? idfsGlobalFolder_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGlobalFolder).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDefaultFolderName)]
        [MapField(_str_strDefaultFolderName)]
        public abstract String strDefaultFolderName { get; set; }
        protected String strDefaultFolderName_Original { get { return ((EditableValue<String>)((dynamic)this)._strDefaultFolderName).OriginalValue; } }
        protected String strDefaultFolderName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDefaultFolderName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFolderName)]
        [MapField(_str_strFolderName)]
        public abstract String strFolderName { get; set; }
        protected String strFolderName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFolderName).OriginalValue; } }
        protected String strFolderName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFolderName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idflQuery)]
        [MapField(_str_idflQuery)]
        public abstract Int64 idflQuery { get; set; }
        protected Int64 idflQuery_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idflQuery).OriginalValue; } }
        protected Int64 idflQuery_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idflQuery).PreviousValue; } }
                
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
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<AvrFolderLookup, object> _get_func;
            internal Action<AvrFolderLookup, string> _set_func;
            internal Action<AvrFolderLookup, AvrFolderLookup, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idflFolder = "idflFolder";
        internal const string _str_idflParentFolder = "idflParentFolder";
        internal const string _str_idfsGlobalFolder = "idfsGlobalFolder";
        internal const string _str_strDefaultFolderName = "strDefaultFolderName";
        internal const string _str_strFolderName = "strFolderName";
        internal const string _str_idflQuery = "idflQuery";
        internal const string _str_blnReadOnly = "blnReadOnly";
        internal const string _str_intOrder = "intOrder";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idflFolder, _formname = _str_idflFolder, _type = "Int64",
              _get_func = o => o.idflFolder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idflFolder != newval) o.idflFolder = newval; },
              _compare_func = (o, c, m) => {
                if (o.idflFolder != c.idflFolder || o.IsRIRPropChanged(_str_idflFolder, c)) 
                  m.Add(_str_idflFolder, o.ObjectIdent + _str_idflFolder, o.ObjectIdent2 + _str_idflFolder, o.ObjectIdent3 + _str_idflFolder, "Int64", 
                    o.idflFolder == null ? "" : o.idflFolder.ToString(),                  
                  o.IsReadOnly(_str_idflFolder), o.IsInvisible(_str_idflFolder), o.IsRequired(_str_idflFolder)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idflParentFolder, _formname = _str_idflParentFolder, _type = "Int64?",
              _get_func = o => o.idflParentFolder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idflParentFolder != newval) o.idflParentFolder = newval; },
              _compare_func = (o, c, m) => {
                if (o.idflParentFolder != c.idflParentFolder || o.IsRIRPropChanged(_str_idflParentFolder, c)) 
                  m.Add(_str_idflParentFolder, o.ObjectIdent + _str_idflParentFolder, o.ObjectIdent2 + _str_idflParentFolder, o.ObjectIdent3 + _str_idflParentFolder, "Int64?", 
                    o.idflParentFolder == null ? "" : o.idflParentFolder.ToString(),                  
                  o.IsReadOnly(_str_idflParentFolder), o.IsInvisible(_str_idflParentFolder), o.IsRequired(_str_idflParentFolder)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsGlobalFolder, _formname = _str_idfsGlobalFolder, _type = "Int64?",
              _get_func = o => o.idfsGlobalFolder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsGlobalFolder != newval) o.idfsGlobalFolder = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsGlobalFolder != c.idfsGlobalFolder || o.IsRIRPropChanged(_str_idfsGlobalFolder, c)) 
                  m.Add(_str_idfsGlobalFolder, o.ObjectIdent + _str_idfsGlobalFolder, o.ObjectIdent2 + _str_idfsGlobalFolder, o.ObjectIdent3 + _str_idfsGlobalFolder, "Int64?", 
                    o.idfsGlobalFolder == null ? "" : o.idfsGlobalFolder.ToString(),                  
                  o.IsReadOnly(_str_idfsGlobalFolder), o.IsInvisible(_str_idfsGlobalFolder), o.IsRequired(_str_idfsGlobalFolder)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDefaultFolderName, _formname = _str_strDefaultFolderName, _type = "String",
              _get_func = o => o.strDefaultFolderName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDefaultFolderName != newval) o.strDefaultFolderName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDefaultFolderName != c.strDefaultFolderName || o.IsRIRPropChanged(_str_strDefaultFolderName, c)) 
                  m.Add(_str_strDefaultFolderName, o.ObjectIdent + _str_strDefaultFolderName, o.ObjectIdent2 + _str_strDefaultFolderName, o.ObjectIdent3 + _str_strDefaultFolderName, "String", 
                    o.strDefaultFolderName == null ? "" : o.strDefaultFolderName.ToString(),                  
                  o.IsReadOnly(_str_strDefaultFolderName), o.IsInvisible(_str_strDefaultFolderName), o.IsRequired(_str_strDefaultFolderName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFolderName, _formname = _str_strFolderName, _type = "String",
              _get_func = o => o.strFolderName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFolderName != newval) o.strFolderName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFolderName != c.strFolderName || o.IsRIRPropChanged(_str_strFolderName, c)) 
                  m.Add(_str_strFolderName, o.ObjectIdent + _str_strFolderName, o.ObjectIdent2 + _str_strFolderName, o.ObjectIdent3 + _str_strFolderName, "String", 
                    o.strFolderName == null ? "" : o.strFolderName.ToString(),                  
                  o.IsReadOnly(_str_strFolderName), o.IsInvisible(_str_strFolderName), o.IsRequired(_str_strFolderName)); 
                  }
              }, 
                  
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
            AvrFolderLookup obj = (AvrFolderLookup)o;
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
        internal string m_ObjectName = "AvrFolderLookup";

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
            var ret = base.Clone() as AvrFolderLookup;
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
            var ret = base.Clone() as AvrFolderLookup;
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
        public AvrFolderLookup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AvrFolderLookup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idflFolder; } }
        public string KeyName { get { return "idflFolder"; } }
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

        private bool IsRIRPropChanged(string fld, AvrFolderLookup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      
        public override string ToString()
        {
            return new Func<AvrFolderLookup, string>(c => c.strDefaultFolderName)(this);
        }
        

        public AvrFolderLookup()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AvrFolderLookup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AvrFolderLookup_PropertyChanged);
        }
        private void AvrFolderLookup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AvrFolderLookup).Changed(e.PropertyName);
            
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
            AvrFolderLookup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AvrFolderLookup obj = this;
            
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


        internal Dictionary<string, Func<AvrFolderLookup, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<AvrFolderLookup, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AvrFolderLookup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AvrFolderLookup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<AvrFolderLookup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<AvrFolderLookup, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<AvrFolderLookup, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AvrFolderLookup()
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
        : DataAccessor<AvrFolderLookup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<AvrFolderLookup>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idflFolder"; } }
            #endregion
        
            private delegate void on_action(AvrFolderLookup obj);
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
            public virtual List<AvrFolderLookup> SelectLookupList(DbManagerProxy manager
                , Int64? FolderID
                , Int64? QueryID
                )
            {
                return _SelectList(manager
                    , FolderID
                    , QueryID
                    , null, null
                    );
            }
            
            public static string GetLookupTableName(string method)
            {
                return "LayoutFolder";
            }
            
            public virtual List<AvrFolderLookup> SelectList(DbManagerProxy manager
                , Int64? FolderID
                , Int64? QueryID
                )
            {
                return _SelectList(manager
                    , FolderID
                    , QueryID
                    , delegate(AvrFolderLookup obj)
                        {
                        }
                    , delegate(AvrFolderLookup obj)
                        {
                        }
                    );
            }

            
            private List<AvrFolderLookup> _SelectList(DbManagerProxy manager
                , Int64? FolderID
                , Int64? QueryID
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<AvrFolderLookup> objs = new List<AvrFolderLookup>();
                    sets[0] = new MapResultSet(typeof(AvrFolderLookup), objs);
                    
                    manager
                        .SetSpCommand("spAsFolderSelectLookup"
                            , manager.Parameter("@FolderID", FolderID)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, AvrFolderLookup obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AvrFolderLookup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AvrFolderLookup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    AvrFolderLookup obj = AvrFolderLookup.CreateInstance();
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

            
            public AvrFolderLookup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public AvrFolderLookup CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public AvrFolderLookup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(AvrFolderLookup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AvrFolderLookup obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, AvrFolderLookup obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(AvrFolderLookup obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(AvrFolderLookup obj, bool bRethrowException)
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
                return Validate(manager, obj as AvrFolderLookup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AvrFolderLookup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(AvrFolderLookup obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(AvrFolderLookup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AvrFolderLookup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AvrFolderLookup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AvrFolderLookupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spAsFolderSelectLookup";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AvrFolderLookup, bool>> RequiredByField = new Dictionary<string, Func<AvrFolderLookup, bool>>();
            public static Dictionary<string, Func<AvrFolderLookup, bool>> RequiredByProperty = new Dictionary<string, Func<AvrFolderLookup, bool>>();
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
                
                Sizes.Add(_str_strDefaultFolderName, 2000);
                Sizes.Add(_str_strFolderName, 2000);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AvrFolderLookup>().Post(manager, (AvrFolderLookup)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AvrFolderLookup>().Post(manager, (AvrFolderLookup)c), c),
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
                    (manager, c, pars) => new ActResult(((AvrFolderLookup)c).MarkToDelete() && ObjectAccessor.PostInterface<AvrFolderLookup>().Post(manager, (AvrFolderLookup)c), c),
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
	