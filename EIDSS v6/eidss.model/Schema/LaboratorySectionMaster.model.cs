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
    public abstract partial class LaboratorySectionMaster : 
        EditableObject<LaboratorySectionMaster>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsLaboratorySection), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsLaboratorySection { get; set; }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<LaboratorySectionMaster, object> _get_func;
            internal Action<LaboratorySectionMaster, string> _set_func;
            internal Action<LaboratorySectionMaster, LaboratorySectionMaster, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsLaboratorySection = "idfsLaboratorySection";
        internal const string _str_bIsMyPref = "bIsMyPref";
        internal const string _str_newCounter = "newCounter";
        internal const string _str_LaboratorySectionItems = "LaboratorySectionItems";
        internal const string _str_LaboratorySectionMyPrefItems = "LaboratorySectionMyPrefItems";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsLaboratorySection, _formname = _str_idfsLaboratorySection, _type = "Int64",
              _get_func = o => o.idfsLaboratorySection,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsLaboratorySection != newval) o.idfsLaboratorySection = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsLaboratorySection != c.idfsLaboratorySection || o.IsRIRPropChanged(_str_idfsLaboratorySection, c)) 
                  m.Add(_str_idfsLaboratorySection, o.ObjectIdent + _str_idfsLaboratorySection, o.ObjectIdent2 + _str_idfsLaboratorySection, o.ObjectIdent3 + _str_idfsLaboratorySection, "Int64", 
                    o.idfsLaboratorySection == null ? "" : o.idfsLaboratorySection.ToString(),                  
                  o.IsReadOnly(_str_idfsLaboratorySection), o.IsInvisible(_str_idfsLaboratorySection), o.IsRequired(_str_idfsLaboratorySection)); 
                  }
              }, 
        
            new field_info {
              _name = _str_bIsMyPref, _formname = _str_bIsMyPref, _type = "bool",
              _get_func = o => o.bIsMyPref,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.bIsMyPref != newval) o.bIsMyPref = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.bIsMyPref != c.bIsMyPref || o.IsRIRPropChanged(_str_bIsMyPref, c)) {
                  m.Add(_str_bIsMyPref, o.ObjectIdent + _str_bIsMyPref, o.ObjectIdent2 + _str_bIsMyPref, o.ObjectIdent3 + _str_bIsMyPref,  "bool", 
                    o.bIsMyPref == null ? "" : o.bIsMyPref.ToString(),                  
                    o.IsReadOnly(_str_bIsMyPref), o.IsInvisible(_str_bIsMyPref), o.IsRequired(_str_bIsMyPref));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_newCounter, _formname = _str_newCounter, _type = "int",
              _get_func = o => o.newCounter,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.newCounter != newval) o.newCounter = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.newCounter != c.newCounter || o.IsRIRPropChanged(_str_newCounter, c)) {
                  m.Add(_str_newCounter, o.ObjectIdent + _str_newCounter, o.ObjectIdent2 + _str_newCounter, o.ObjectIdent3 + _str_newCounter,  "int", 
                    o.newCounter == null ? "" : o.newCounter.ToString(),                  
                    o.IsReadOnly(_str_newCounter), o.IsInvisible(_str_newCounter), o.IsRequired(_str_newCounter));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_LaboratorySectionItems, _formname = _str_LaboratorySectionItems, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.LaboratorySectionItems.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.LaboratorySectionItems.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.LaboratorySectionItems.Count != c.LaboratorySectionItems.Count || o.IsReadOnly(_str_LaboratorySectionItems) != c.IsReadOnly(_str_LaboratorySectionItems) || o.IsInvisible(_str_LaboratorySectionItems) != c.IsInvisible(_str_LaboratorySectionItems) || o.IsRequired(_str_LaboratorySectionItems) != c._isRequired(o.m_isRequired, _str_LaboratorySectionItems)) {
                  m.Add(_str_LaboratorySectionItems, o.ObjectIdent + _str_LaboratorySectionItems, o.ObjectIdent2 + _str_LaboratorySectionItems, o.ObjectIdent3 + _str_LaboratorySectionItems, "Child", o.idfsLaboratorySection == null ? "" : o.idfsLaboratorySection.ToString(), o.IsReadOnly(_str_LaboratorySectionItems), o.IsInvisible(_str_LaboratorySectionItems), o.IsRequired(_str_LaboratorySectionItems)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_LaboratorySectionMyPrefItems, _formname = _str_LaboratorySectionMyPrefItems, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.LaboratorySectionMyPrefItems.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.LaboratorySectionMyPrefItems.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.LaboratorySectionMyPrefItems.Count != c.LaboratorySectionMyPrefItems.Count || o.IsReadOnly(_str_LaboratorySectionMyPrefItems) != c.IsReadOnly(_str_LaboratorySectionMyPrefItems) || o.IsInvisible(_str_LaboratorySectionMyPrefItems) != c.IsInvisible(_str_LaboratorySectionMyPrefItems) || o.IsRequired(_str_LaboratorySectionMyPrefItems) != c._isRequired(o.m_isRequired, _str_LaboratorySectionMyPrefItems)) {
                  m.Add(_str_LaboratorySectionMyPrefItems, o.ObjectIdent + _str_LaboratorySectionMyPrefItems, o.ObjectIdent2 + _str_LaboratorySectionMyPrefItems, o.ObjectIdent3 + _str_LaboratorySectionMyPrefItems, "Child", o.idfsLaboratorySection == null ? "" : o.idfsLaboratorySection.ToString(), o.IsReadOnly(_str_LaboratorySectionMyPrefItems), o.IsInvisible(_str_LaboratorySectionMyPrefItems), o.IsRequired(_str_LaboratorySectionMyPrefItems)); 
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
            LaboratorySectionMaster obj = (LaboratorySectionMaster)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_LaboratorySectionItems)]
        [Relation(typeof(LaboratorySectionItem), eidss.model.Schema.LaboratorySectionItem._str_idfsLaboratorySection, _str_idfsLaboratorySection)]
        public EditableList<LaboratorySectionItem> LaboratorySectionItems
        {
            get 
            {   
                return _LaboratorySectionItems; 
            }
            set 
            {
                _LaboratorySectionItems = value;
            }
        }
        protected EditableList<LaboratorySectionItem> _LaboratorySectionItems = new EditableList<LaboratorySectionItem>();
                    
        [LocalizedDisplayName(_str_LaboratorySectionMyPrefItems)]
        [Relation(typeof(LaboratorySectionItem), eidss.model.Schema.LaboratorySectionItem._str_idfsLaboratorySection, _str_idfsLaboratorySection)]
        public EditableList<LaboratorySectionItem> LaboratorySectionMyPrefItems
        {
            get 
            {   
                return _LaboratorySectionMyPrefItems; 
            }
            set 
            {
                _LaboratorySectionMyPrefItems = value;
            }
        }
        protected EditableList<LaboratorySectionItem> _LaboratorySectionMyPrefItems = new EditableList<LaboratorySectionItem>();
                    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
          [LocalizedDisplayName(_str_bIsMyPref)]
        public bool bIsMyPref
        {
            get { return m_bIsMyPref; }
            set { if (m_bIsMyPref != value) { m_bIsMyPref = value; OnPropertyChanged(_str_bIsMyPref); } }
        }
        private bool m_bIsMyPref;
        
          [LocalizedDisplayName(_str_newCounter)]
        public int newCounter
        {
            get { return m_newCounter; }
            set { if (m_newCounter != value) { m_newCounter = value; OnPropertyChanged(_str_newCounter); } }
        }
        private int m_newCounter;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LaboratorySectionMaster";

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
        LaboratorySectionItems.ForEach(c => { c.Parent = this; });
                LaboratorySectionMyPrefItems.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as LaboratorySectionMaster;
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
            var ret = base.Clone() as LaboratorySectionMaster;
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
        public LaboratorySectionMaster CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LaboratorySectionMaster;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsLaboratorySection; } }
        public string KeyName { get { return "idfsLaboratorySection"; } }
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
        
                    || LaboratorySectionItems.IsDirty
                    || LaboratorySectionItems.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || LaboratorySectionMyPrefItems.IsDirty
                    || LaboratorySectionMyPrefItems.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
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
        LaboratorySectionItems.DeepRejectChanges();
                LaboratorySectionMyPrefItems.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        LaboratorySectionItems.DeepAcceptChanges();
                LaboratorySectionMyPrefItems.DeepAcceptChanges();
                
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
        LaboratorySectionItems.ForEach(c => c.SetChange());
                LaboratorySectionMyPrefItems.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, LaboratorySectionMaster c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public LaboratorySectionMaster()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LaboratorySectionMaster_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LaboratorySectionMaster_PropertyChanged);
        }
        private void LaboratorySectionMaster_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LaboratorySectionMaster).Changed(e.PropertyName);
            
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
            LaboratorySectionMaster obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LaboratorySectionMaster obj = this;
            
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
        
                foreach(var o in _LaboratorySectionItems)
                    o.ReadOnly |= value;
                
                foreach(var o in _LaboratorySectionMyPrefItems)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<LaboratorySectionMaster, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<LaboratorySectionMaster, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LaboratorySectionMaster, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LaboratorySectionMaster, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<LaboratorySectionMaster, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<LaboratorySectionMaster, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<LaboratorySectionMaster, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LaboratorySectionMaster()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                LaboratorySectionItems.ForEach(c => c.Dispose());
                LaboratorySectionMyPrefItems.ForEach(c => c.Dispose());
                
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
        
            if (_LaboratorySectionItems != null) _LaboratorySectionItems.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_LaboratorySectionMyPrefItems != null) _LaboratorySectionMyPrefItems.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<LaboratorySectionMaster>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<LaboratorySectionMaster>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<LaboratorySectionMaster>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsLaboratorySection"; } }
            #endregion
        
            private delegate void on_action(LaboratorySectionMaster obj);
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
            private LaboratorySectionItem.Accessor LaboratorySectionItemsAccessor { get { return eidss.model.Schema.LaboratorySectionItem.Accessor.Instance(m_CS); } }
            private LaboratorySectionItem.Accessor LaboratorySectionMyPrefItemsAccessor { get { return eidss.model.Schema.LaboratorySectionItem.Accessor.Instance(m_CS); } }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , null, null
                        );
                }
            }
            public virtual LaboratorySectionMaster SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , null, null
                        );
                }
            }

            
            public virtual LaboratorySectionMaster SelectByKey(DbManagerProxy manager
                )
            {
                return _SelectByKey(manager
                    , null, null
                    );
            }
            
      
            private LaboratorySectionMaster _SelectByKey(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<LaboratorySectionMaster> objs = new List<LaboratorySectionMaster>();
                sets[0] = new MapResultSet(typeof(LaboratorySectionMaster), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spLaboratorySectionMaster_SelectDetail"
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    LaboratorySectionMaster obj = objs[0];
                    obj.m_CS = m_CS;
                    
                    if (loading != null)
                        loading(obj);
                    _SetupLoad(manager, obj);
                    
                    //obj._setParent();
                    if (loaded != null)
                        loaded(obj);
                    obj.Loaded(manager);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(e);
                }
                
            }
    
            private void _SetupAddChildHandlerLaboratorySectionItems(LaboratorySectionMaster obj)
            {
                obj.LaboratorySectionItems.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerLaboratorySectionMyPrefItems(LaboratorySectionMaster obj)
            {
                obj.LaboratorySectionMyPrefItems.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadLaboratorySectionItems(LaboratorySectionMaster obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadLaboratorySectionItems(manager, obj);
                }
            }
            internal void _LoadLaboratorySectionItems(DbManagerProxy manager, LaboratorySectionMaster obj)
            {
                
            }
            
            internal void _LoadLaboratorySectionMyPrefItems(LaboratorySectionMaster obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadLaboratorySectionMyPrefItems(manager, obj);
                }
            }
            internal void _LoadLaboratorySectionMyPrefItems(DbManagerProxy manager, LaboratorySectionMaster obj)
            {
                
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, LaboratorySectionMaster obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadLaboratorySectionItems(manager, obj);
                _LoadLaboratorySectionMyPrefItems(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerLaboratorySectionItems(obj);
                
                _SetupAddChildHandlerLaboratorySectionMyPrefItems(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, LaboratorySectionMaster obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.LaboratorySectionItems.ForEach(c => LaboratorySectionItemsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.LaboratorySectionMyPrefItems.ForEach(c => LaboratorySectionMyPrefItemsAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private LaboratorySectionMaster _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    LaboratorySectionMaster obj = LaboratorySectionMaster.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfsLaboratorySection = (new GetNewIDExtender<LaboratorySectionMaster>()).GetScalar(manager, obj, isFake);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerLaboratorySectionItems(obj);
                    
                    _SetupAddChildHandlerLaboratorySectionMyPrefItems(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
              obj.ClearIsNew();
            
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

            
            public LaboratorySectionMaster CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public LaboratorySectionMaster CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public LaboratorySectionMaster CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult SelectAll(DbManagerProxy manager, LaboratorySectionMaster obj, List<object> pars)
            {
                
                return SelectAll(manager, obj
                    );
            }
            public ActResult SelectAll(DbManagerProxy manager, LaboratorySectionMaster obj
                )
            {
                
                return true;
                
            }
            
      
            public ActResult CreateSample(DbManagerProxy manager, LaboratorySectionMaster obj, List<object> pars)
            {
                
                return CreateSample(manager, obj
                    );
            }
            public ActResult CreateSample(DbManagerProxy manager, LaboratorySectionMaster obj
                )
            {
                
                return true;
                
            }
            
      
            public ActResult GroupAccessionIn(DbManagerProxy manager, LaboratorySectionMaster obj, List<object> pars)
            {
                
                return GroupAccessionIn(manager, obj
                    );
            }
            public ActResult GroupAccessionIn(DbManagerProxy manager, LaboratorySectionMaster obj
                )
            {
                
                return true;
                
            }
            
      
            public ActResult ActionLaboratoryDetails(DbManagerProxy manager, LaboratorySectionMaster obj, List<object> pars)
            {
                
                return ActionLaboratoryDetails(manager, obj
                    );
            }
            public ActResult ActionLaboratoryDetails(DbManagerProxy manager, LaboratorySectionMaster obj
                )
            {
                
                return true;
                
            }
            
      
            public ActResult ActionLaboratoryDetailsMyPref(DbManagerProxy manager, LaboratorySectionMaster obj, List<object> pars)
            {
                
                return ActionLaboratoryDetailsMyPref(manager, obj
                    );
            }
            public ActResult ActionLaboratoryDetailsMyPref(DbManagerProxy manager, LaboratorySectionMaster obj
                )
            {
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(LaboratorySectionMaster obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LaboratorySectionMaster obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, LaboratorySectionMaster obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spDummy_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] LaboratorySectionMaster obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] LaboratorySectionMaster obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    LaboratorySectionMaster bo = obj as LaboratorySectionMaster;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as LaboratorySectionMaster, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, LaboratorySectionMaster obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.LaboratorySectionItems != null)
                    {
                        foreach (var i in obj.LaboratorySectionItems)
                        {
                            i.MarkToDelete();
                            if (!LaboratorySectionItemsAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                    
                    if (obj.LaboratorySectionMyPrefItems != null)
                    {
                        foreach (var i in obj.LaboratorySectionMyPrefItems)
                        {
                            i.MarkToDelete();
                            if (!LaboratorySectionMyPrefItemsAccessor.Post(manager, i, true))
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
              obj.LaboratorySectionItems.Union(obj.LaboratorySectionMyPrefItems)
                .Where(c => c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.OutOfRepository && c.OriginalSampleStatus != (long)eidss.model.Enums.SampleStatus.OutOfRepository)
                .GroupBy(c => c.idfSendToOfficeOut).ToList().ForEach(g => 
                    {
                        g.GroupBy(c => c.datSendDate).ToList().ForEach(i =>
                            {
                                var sample = i.First();
                                var strBarcode = manager.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.SampleTransfer, DBNull.Value, DBNull.Value)
                                    .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue");
                                var idfTransferOut = manager.SetSpCommand("dbo.spsysGetNewID", DBNull.Value)
                                    .ExecuteScalar<long>(ScalarSourceType.OutputParameter);
                                manager.SetSpCommand("dbo.spLabSampleTransfer_Post",
	                                  4, //@Action INT,  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
                                    idfTransferOut, //@idfTransferOut bigint,
                                    strBarcode, //@strBarcode nvarchar(200),
	                                  "", //@strNote nvarchar(2000),
	                                  EidssUserContext.User.OrganizationID, //@idfSendFromOffice bigint,--target site
	                                  sample.idfSendToOfficeOut, //@idfSendToOffice bigint,--target site
	                                  sample.idfSendByPerson, //@idfSendByPerson bigint,--who sent
	                                  sample.datSendDate, //@datSendDate datetime,--time sent
	                                  (long)eidss.model.Enums.TestStatus.InProcess //@idfsTransferStatus bigint--transfer status
                                    ).ExecuteNonQuery();

                                i.ToList().ForEach(j =>
                                    {
                                        manager.SetSpCommand("dbo.spLabSampleTransfer_Send",
	                                          j.idfMaterial, //@idfMaterial bigint,
	                                          sample.idfSendToOfficeOut, //@idfSentToOffice bigint,
                                            sample.datSendDate //@datSendDate datetime 
                                            ).ExecuteNonQuery();
                                    
                                        manager.SetSpCommand("dbo.spLabSampleTransfer_Manage",
	                                          idfTransferOut, //@idfTransferOut bigint,
	                                          j.idfMaterial, //@idfMaterial bigint,
	                                          1 //@add integer
                                            ).ExecuteNonQuery();

                                        manager.SetEventParams(false, new object[] { EventType.NewSampleTransferInLocal, idfTransferOut, "" });

                                    });
                            });
                    });
            
                    // posting extenters - end
            
                    if (obj.IsNew)
                    {
                        if (obj.LaboratorySectionItems != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.LaboratorySectionItems)
                                if (!LaboratorySectionItemsAccessor.Post(manager, i, true))
                                    return false;
                            obj.LaboratorySectionItems.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.LaboratorySectionItems.Remove(c));
                            obj.LaboratorySectionItems.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._LaboratorySectionItems != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._LaboratorySectionItems)
                                if (!LaboratorySectionItemsAccessor.Post(manager, i, true))
                                    return false;
                            obj._LaboratorySectionItems.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._LaboratorySectionItems.Remove(c));
                            obj._LaboratorySectionItems.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.LaboratorySectionMyPrefItems != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.LaboratorySectionMyPrefItems)
                                if (!LaboratorySectionMyPrefItemsAccessor.Post(manager, i, true))
                                    return false;
                            obj.LaboratorySectionMyPrefItems.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.LaboratorySectionMyPrefItems.Remove(c));
                            obj.LaboratorySectionMyPrefItems.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._LaboratorySectionMyPrefItems != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._LaboratorySectionMyPrefItems)
                                if (!LaboratorySectionMyPrefItemsAccessor.Post(manager, i, true))
                                    return false;
                            obj._LaboratorySectionMyPrefItems.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._LaboratorySectionMyPrefItems.Remove(c));
                            obj._LaboratorySectionMyPrefItems.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(LaboratorySectionMaster obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, LaboratorySectionMaster obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(LaboratorySectionMaster obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(LaboratorySectionMaster obj, bool bRethrowException)
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
                return Validate(manager, obj as LaboratorySectionMaster, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LaboratorySectionMaster obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                        foreach(var item in obj.LaboratorySectionItems.Where(c => true))
                        {
                        
                (new RequiredValidator( "strBarcode", "strBarcode","strLabBarcode",
                false
              )).Validate(c => c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned, item, item.strBarcode);
            
                (new RequiredValidator( "idfsSampleType", "idfsSampleType","",
                false
              )).Validate(c => true, item, item.idfsSampleType);
            
                (new RequiredValidator( "datAccession", "datAccession","",
                false
              )).Validate(c => c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned, item, item.datAccession);
            
                (new RequiredValidator( "idfsAccessionCondition", "idfsAccessionCondition","",
                false
              )).Validate(c => c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned && c.idfsSampleKind != (long)eidss.model.Enums.SampleKind.Aliquote && c.idfsSampleKind != (long)eidss.model.Enums.SampleKind.Derivative, item, item.idfsAccessionCondition);
            
                (new RequiredValidator( "idfSpeciesVectorInfo", "idfSpeciesVectorInfo","strPatientSessionVectorInfo",
                false
              )).Validate(c => c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.Accessioned, item, item.idfSpeciesVectorInfo);
            
                (new RequiredValidator( "idfSendToOfficeOut", "idfSendToOfficeOut","strOrganizationSendTo",
                false
              )).Validate(c => c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.OutOfRepository, item, item.idfSendToOfficeOut);
            
                (new RequiredValidator( "idfsDiagnosis", "idfsDiagnosis","TestDiagnosisName",
                false
              )).Validate(c => c.idfTesting.HasValue && !c.bTestDeleted, item, item.idfsDiagnosis);
            
                (new RequiredValidator( "idfsTestName", "idfsTestName","TestName",
                false
              )).Validate(c => c.idfTesting.HasValue && !c.bTestDeleted, item, item.idfsTestName);
            
                (new RequiredValidator( "idfsTestStatus", "idfsTestStatus","TestStatus",
                false
              )).Validate(c => c.idfTesting.HasValue && !c.bTestDeleted, item, item.idfsTestStatus);
            
                (new RequiredValidator( "idfsTestResult", "idfsTestResult","TestResult",
                false
              )).Validate(c => c.idfTesting.HasValue && !c.bTestDeleted && (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary || c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized || (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/)), item, item.idfsTestResult);
            
                (new RequiredValidator( "datStartedDate", "datStartedDate","",
                false
              )).Validate(c => c.idfTesting.HasValue && !c.bTestDeleted && (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Preliminary || (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/)), item, item.datStartedDate);
            
                (new RequiredValidator( "idfTestedByPerson", "idfTestedByPerson","",
                false
              )).Validate(c => c.idfTesting.HasValue && !c.bTestDeleted && (c.idfsTestStatus == (long)eidss.model.Enums.TestStatus.Finalized && !(/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/)), item, item.idfTestedByPerson);
            
                (new RequiredValidator( "datConcludedDate", "datConcludedDate","datTestResultDate",
                false
              )).Validate(c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/), item, item.datConcludedDate);
            
                (new RequiredValidator( "idfPerformedByOffice", "idfPerformedByOffice","strResultsReceivedFrom",
                false
              )).Validate(c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/), item, item.idfPerformedByOffice);
            
                (new RequiredValidator( "datReceivedDate", "datReceivedDate","",
                false
              )).Validate(c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/), item, item.datReceivedDate);
            
                (new RequiredValidator( "strContactPerson", "strContactPerson","strContact",
                false
              )).Validate(c => c.idfTesting.HasValue && !c.bTestDeleted && (/*c.blnExternalTest.HasValue && */c.blnExternalTest/*.Value*/), item, item.strContactPerson);
            
                        }
                
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.LaboratorySectionItems != null)
                            foreach (var i in obj.LaboratorySectionItems.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                LaboratorySectionItemsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.LaboratorySectionMyPrefItems != null)
                            foreach (var i in obj.LaboratorySectionMyPrefItems.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                LaboratorySectionMyPrefItemsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
           
    
            private void _SetupRequired(LaboratorySectionMaster obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LaboratorySectionMaster obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LaboratorySectionMaster) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LaboratorySectionMaster) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LaboratorySectionMasterDetail"; } }
            public string HelpIdWin { get { return "lab_l25"; } }
            public string HelpIdWeb { get { return "lab_l25"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spLaboratorySectionMaster_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spDummy_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LaboratorySectionMaster, bool>> RequiredByField = new Dictionary<string, Func<LaboratorySectionMaster, bool>>();
            public static Dictionary<string, Func<LaboratorySectionMaster, bool>> RequiredByProperty = new Dictionary<string, Func<LaboratorySectionMaster, bool>>();
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
                
                Actions.Add(new ActionMetaItem(
                    "SelectAll",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).SelectAll(manager, (LaboratorySectionMaster)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelectAll_Id",
                        "selectall",
                        /*from BvMessages*/"tooltipSelectAll_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.Win
                        ),
                      true,
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
                    "Report",
                    ActionTypes.Report,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strReport_Id",
                        "Report",
                        /*from BvMessages*/"tooltipReport_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Main,
                        ActionsAppType.Win
                        ),
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
                    "CreateSample",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).CreateSample(manager, (LaboratorySectionMaster)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleBtnCreateSample",
                        "add",
                        /*from BvMessages*/"titleBtnCreateSample",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Main,
                        ActionsAppType.Web
                        ),
                      true,
                    "Sample.Insert",
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    "laboratory.CreateSample",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "GroupAccessionIn",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).GroupAccessionIn(manager, (LaboratorySectionMaster)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleGroupAccessionIn",
                        "Sample_Accession__small_",
                        /*from BvMessages*/"titleGroupAccessionIn",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Main,
                        ActionsAppType.Web
                        ),
                      true,
                    "AccessionIn1.Execute",
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    "laboratory.GroupAccessionIn",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "ActionLaboratoryDetails",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ActionLaboratoryDetails(manager, (LaboratorySectionMaster)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"LaboratorySection",
                        "",
                        /*from BvMessages*/"LaboratorySection",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Main,
                        ActionsAppType.Web
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && (c as LaboratorySectionMaster).bIsMyPref,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "ActionLaboratoryDetailsMyPref",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ActionLaboratoryDetailsMyPref(manager, (LaboratorySectionMaster)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"MyPreferences",
                        "",
                        /*from BvMessages*/"MyPreferences",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Main,
                        ActionsAppType.Web
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    (c,a,p,r) => r && !(c as LaboratorySectionMaster).bIsMyPref,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LaboratorySectionMaster>().Post(manager, (LaboratorySectionMaster)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LaboratorySectionMaster>().Post(manager, (LaboratorySectionMaster)c), c),
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
	