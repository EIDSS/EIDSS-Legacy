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
    public abstract partial class VectorType2PensideTestMaster : 
        EditableObject<VectorType2PensideTestMaster>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsVectorType), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsVectorType { get; set; }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<VectorType2PensideTestMaster, object> _get_func;
            internal Action<VectorType2PensideTestMaster, string> _set_func;
            internal Action<VectorType2PensideTestMaster, VectorType2PensideTestMaster, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_VectorType = "VectorType";
        internal const string _str_VectorType2PensideTest = "VectorType2PensideTest";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsVectorType, _formname = _str_idfsVectorType, _type = "Int64",
              _get_func = o => o.idfsVectorType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsVectorType != newval) 
                  o.VectorType = o.VectorTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsVectorType != newval) o.idfsVectorType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_idfsVectorType, c)) 
                  m.Add(_str_idfsVectorType, o.ObjectIdent + _str_idfsVectorType, o.ObjectIdent2 + _str_idfsVectorType, o.ObjectIdent3 + _str_idfsVectorType, "Int64", 
                    o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(),                  
                  o.IsReadOnly(_str_idfsVectorType), o.IsInvisible(_str_idfsVectorType), o.IsRequired(_str_idfsVectorType)); 
                  }
              }, 
        
            new field_info {
              _name = _str_VectorType, _formname = _str_VectorType, _type = "Lookup",
              _get_func = o => { if (o.VectorType == null) return null; return o.VectorType.idfsBaseReference; },
              _set_func = (o, val) => { o.VectorType = o.VectorTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_VectorType, c)) {
                  m.Add(_str_VectorType, o.ObjectIdent + _str_VectorType, o.ObjectIdent2 + _str_VectorType, o.ObjectIdent3 + _str_VectorType, "Lookup", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_VectorType), o.IsInvisible(_str_VectorType), o.IsRequired(_str_VectorType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_VectorType + "Lookup", _formname = _str_VectorType + "Lookup", _type = "LookupContent",
              _get_func = o => o.VectorTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_VectorType2PensideTest, _formname = _str_VectorType2PensideTest, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.VectorType2PensideTest.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.VectorType2PensideTest.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.VectorType2PensideTest.Count != c.VectorType2PensideTest.Count || o.IsReadOnly(_str_VectorType2PensideTest) != c.IsReadOnly(_str_VectorType2PensideTest) || o.IsInvisible(_str_VectorType2PensideTest) != c.IsInvisible(_str_VectorType2PensideTest) || o.IsRequired(_str_VectorType2PensideTest) != c._isRequired(o.m_isRequired, _str_VectorType2PensideTest)) {
                  m.Add(_str_VectorType2PensideTest, o.ObjectIdent + _str_VectorType2PensideTest, o.ObjectIdent2 + _str_VectorType2PensideTest, o.ObjectIdent3 + _str_VectorType2PensideTest, "Child", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_VectorType2PensideTest), o.IsInvisible(_str_VectorType2PensideTest), o.IsRequired(_str_VectorType2PensideTest)); 
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
            VectorType2PensideTestMaster obj = (VectorType2PensideTestMaster)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_VectorType2PensideTest)]
        [Relation(typeof(VectorType2PensideTest), eidss.model.Schema.VectorType2PensideTest._str_idfsVectorType, _str_idfsVectorType)]
        public EditableList<VectorType2PensideTest> VectorType2PensideTest
        {
            get 
            {   
                return _VectorType2PensideTest; 
            }
            set 
            {
                _VectorType2PensideTest = value;
            }
        }
        protected EditableList<VectorType2PensideTest> _VectorType2PensideTest = new EditableList<VectorType2PensideTest>();
                    
        [LocalizedDisplayName(_str_VectorType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsVectorType)]
        public BaseReference VectorType
        {
            get { return _VectorType == null ? null : ((long)_VectorType.Key == 0 ? null : _VectorType); }
            set 
            { 
                var oldVal = _VectorType;
                _VectorType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_VectorType != oldVal)
                {
                    if (idfsVectorType != (_VectorType == null
                            ? new Int64()
                            : (Int64)_VectorType.idfsBaseReference))
                        idfsVectorType = _VectorType == null 
                            ? new Int64()
                            : (Int64)_VectorType.idfsBaseReference; 
                    OnPropertyChanged(_str_VectorType); 
                }
            }
        }
        private BaseReference _VectorType;

        
        public BaseReferenceList VectorTypeLookup
        {
            get { return _VectorTypeLookup; }
        }
        private BaseReferenceList _VectorTypeLookup = new BaseReferenceList("rftVectorType");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_VectorType:
                    return new BvSelectList(VectorTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, VectorType, _str_idfsVectorType);
            
                case _str_VectorType2PensideTest:
                    return new BvSelectList(VectorType2PensideTest, "", "", null, "");
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "VectorType2PensideTestMaster";

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
        VectorType2PensideTest.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as VectorType2PensideTestMaster;
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
            var ret = base.Clone() as VectorType2PensideTestMaster;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_VectorType2PensideTest != null && _VectorType2PensideTest.Count > 0)
            {
              ret.VectorType2PensideTest.Clear();
              _VectorType2PensideTest.ForEach(c => ret.VectorType2PensideTest.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public VectorType2PensideTestMaster CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VectorType2PensideTestMaster;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsVectorType; } }
        public string KeyName { get { return "idfsVectorType"; } }
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
        
                    || VectorType2PensideTest.IsDirty
                    || VectorType2PensideTest.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsVectorType_VectorType = idfsVectorType;
            base.RejectChanges();
        
            if (_prev_idfsVectorType_VectorType != idfsVectorType)
            {
                _VectorType = _VectorTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorType);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        VectorType2PensideTest.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        VectorType2PensideTest.DeepAcceptChanges();
                
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
        VectorType2PensideTest.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, VectorType2PensideTestMaster c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public VectorType2PensideTestMaster()
        {
            
            m_permissions = new Permissions(this);
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VectorType2PensideTestMaster_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VectorType2PensideTestMaster_PropertyChanged);
        }
        private void VectorType2PensideTestMaster_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VectorType2PensideTestMaster).Changed(e.PropertyName);
            
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
            
            return Accessor.Instance(null).ValidateCanDelete(this);
              
        }
        private void _DeletingExtenders()
        {
            VectorType2PensideTestMaster obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VectorType2PensideTestMaster obj = this;
            
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

    
        private static string[] readonly_names1 = "VectorType".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return  new Func<VectorType2PensideTestMaster, bool>(c => false)(this);
            
            return ReadOnly;
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _VectorType2PensideTest)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<VectorType2PensideTestMaster, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VectorType2PensideTestMaster, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VectorType2PensideTestMaster, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VectorType2PensideTestMaster, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VectorType2PensideTestMaster, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<VectorType2PensideTestMaster, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<VectorType2PensideTestMaster, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~VectorType2PensideTestMaster()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                VectorType2PensideTest.ForEach(c => c.Dispose());
                
                LookupManager.RemoveObject("rftVectorType", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftVectorType")
                _getAccessor().LoadLookup_VectorType(manager, this);
            
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
        
            if (_VectorType2PensideTest != null) _VectorType2PensideTest.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<VectorType2PensideTestMaster>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<VectorType2PensideTestMaster>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<VectorType2PensideTestMaster>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsVectorType"; } }
            #endregion
        
            private delegate void on_action(VectorType2PensideTestMaster obj);
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
            private VectorType2PensideTest.Accessor VectorType2PensideTestAccessor { get { return eidss.model.Schema.VectorType2PensideTest.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor VectorTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            

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
            public virtual VectorType2PensideTestMaster SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
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

            
            public virtual VectorType2PensideTestMaster SelectByKey(DbManagerProxy manager
                )
            {
                return _SelectByKey(manager
                    , null, null
                    );
            }
            
      
            private VectorType2PensideTestMaster _SelectByKey(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<VectorType2PensideTestMaster> objs = new List<VectorType2PensideTestMaster>();
                sets[0] = new MapResultSet(typeof(VectorType2PensideTestMaster), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spVectorTypeMaster_SelectDetail"
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    VectorType2PensideTestMaster obj = objs[0];
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
    
            private void _SetupAddChildHandlerVectorType2PensideTest(VectorType2PensideTestMaster obj)
            {
                obj.VectorType2PensideTest.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadVectorType2PensideTest(VectorType2PensideTestMaster obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadVectorType2PensideTest(manager, obj);
                }
            }
            internal void _LoadVectorType2PensideTest(DbManagerProxy manager, VectorType2PensideTestMaster obj)
            {
                
                obj.VectorType2PensideTest.Clear();
                obj.VectorType2PensideTest.AddRange(VectorType2PensideTestAccessor.SelectDetailList(manager
                    
                    , obj.idfsVectorType
                    ));
                obj.VectorType2PensideTest.ForEach(c => c.m_ObjectName = _str_VectorType2PensideTest);
                obj.VectorType2PensideTest.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, VectorType2PensideTestMaster obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadVectorType2PensideTest(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerVectorType2PensideTest(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, VectorType2PensideTestMaster obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.VectorType2PensideTest.ForEach(c => VectorType2PensideTestAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private VectorType2PensideTestMaster _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    VectorType2PensideTestMaster obj = VectorType2PensideTestMaster.CreateInstance();
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
                    
                    _SetupAddChildHandlerVectorType2PensideTest(obj);
                    
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

            
            public VectorType2PensideTestMaster CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public VectorType2PensideTestMaster CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public VectorType2PensideTestMaster CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult DeletePensideTest(DbManagerProxy manager, VectorType2PensideTestMaster obj, List<object> pars)
            {
                
                return DeletePensideTest(manager, obj
                    );
            }
            public ActResult DeletePensideTest(DbManagerProxy manager, VectorType2PensideTestMaster obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("DeletePensideTest"))
                    throw new PermissionException("Reference", "DeletePensideTest");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(VectorType2PensideTestMaster obj, object newobj)
            {
                
                foreach(var o in obj.VectorType2PensideTest.Where(c => true))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "idfsPensideTestName")
                                {
                                
                (new RequiredValidator( "idfsPensideTestName", "idfsPensideTestName","",
                false
              )).Validate(c => true, item, item.idfsPensideTestName);
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("idfsPensideTestName");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        
                    }
                }
                            
            }
            
            private void _SetupHandlers(VectorType2PensideTestMaster obj)
            {
                
            }
    
            public void LoadLookup_VectorType(DbManagerProxy manager, VectorType2PensideTestMaster obj)
            {
                
                obj.VectorTypeLookup.Clear();
                
                obj.VectorTypeLookup.Add(VectorTypeAccessor.CreateNewT(manager, null));
                
                obj.VectorTypeLookup.AddRange(VectorTypeAccessor.rftVectorType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorType))
                    
                    .ToList());
                
                if (obj.idfsVectorType != 0)
                {
                    obj.VectorType = obj.VectorTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsVectorType);
                    
                }
              
                
                LookupManager.AddObject("rftVectorType", obj, VectorTypeAccessor.GetType(), "rftVectorType_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, VectorType2PensideTestMaster obj)
            {
                
                LoadLookup_VectorType(manager, obj);
                
            }
    
            [SprocName("spVectorType2PensideTestMaster_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                )
            {
                
                _postDelete(manager);
                
            }
        
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spDummy_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] VectorType2PensideTestMaster obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] VectorType2PensideTestMaster obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    VectorType2PensideTestMaster bo = obj as VectorType2PensideTestMaster;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("Reference", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("Reference", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("Reference", "Update");
                    }
                    
                    long mainObject = bo.idfsVectorType;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        
                        if (new Func<VectorType2PensideTestMaster, bool>(c => c.HasChanges)(bo))
                          
                            manager.SetEventParams(false, new object[] { EventType.MatrixChanged, mainObject, "VectorType2PensideTestMasterDetail" });
                        
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        
                        if (new Func<VectorType2PensideTestMaster, bool>(c => c.HasChanges)(bo))
                          
                            manager.SetEventParams(false, new object[] { EventType.MatrixChanged, mainObject, "VectorType2PensideTestMasterDetail" });
                        
                    }

                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeDelete;
                            
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeCreate;
                            
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeEdit;
                            
                        }
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoReference;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.trtBaseReference;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as VectorType2PensideTestMaster, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VectorType2PensideTestMaster obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.VectorType2PensideTest != null)
                    {
                        foreach (var i in obj.VectorType2PensideTest)
                        {
                            i.MarkToDelete();
                            if (!VectorType2PensideTestAccessor.Post(manager, i, true))
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
            
                    if (obj.IsNew)
                    {
                        if (obj.VectorType2PensideTest != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.VectorType2PensideTest)
                                if (!VectorType2PensideTestAccessor.Post(manager, i, true))
                                    return false;
                            obj.VectorType2PensideTest.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.VectorType2PensideTest.Remove(c));
                            obj.VectorType2PensideTest.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._VectorType2PensideTest != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._VectorType2PensideTest)
                                if (!VectorType2PensideTestAccessor.Post(manager, i, true))
                                    return false;
                            obj._VectorType2PensideTest.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._VectorType2PensideTest.Remove(c));
                            obj._VectorType2PensideTest.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(VectorType2PensideTestMaster obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, VectorType2PensideTestMaster obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(VectorType2PensideTestMaster obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(VectorType2PensideTestMaster obj, bool bRethrowException)
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
                return Validate(manager, obj as VectorType2PensideTestMaster, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VectorType2PensideTestMaster obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
              new DuplicateListValidator("").Validate(obj, 
              o => o.VectorType2PensideTest.Where(c => !c.IsMarkedToDelete)
                .Aggregate(new List<Tuple<VectorType2PensideTest, int>>(), (list, test) => 
                { 
                    var item = list.Find(c => true
                      
                        && c.Item1.idfsPensideTestName == test.idfsPensideTestName
                        && c.Item1.idfsVectorType == test.idfsVectorType
                      );
                      if (item == null)
                      list.Add(new Tuple<VectorType2PensideTest, int>(test, 1));
                    else
                    {
                        list.Remove(item);
                        list.Add(new Tuple<VectorType2PensideTest, int>(test, item.Item2 + 1));
                    }
                    return list;
                })
                .Where(c => c.Item2 > 1).Select(c => c.Item1).FirstOrDefault(),
                    (o, i) => new Tuple<
                      string, object
                      
                      >(
                      "idfsPensideTestName", 
                        
                        i.PensideTestLookup.First(c => c.Key.Equals(i.idfsPensideTestName)).ToStringProp
                          
                      )
                );
            
          
                  
                    }

                    if (bChangeValidation)
                    {
                
                        foreach(var item in obj.VectorType2PensideTest.Where(c => true))
                        {
                        
                (new RequiredValidator( "idfsPensideTestName", "idfsPensideTestName","",
                false
              )).Validate(c => true, item, item.idfsPensideTestName);
            
                        }
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.VectorType2PensideTest != null)
                            foreach (var i in obj.VectorType2PensideTest.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                VectorType2PensideTestAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(VectorType2PensideTestMaster obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(VectorType2PensideTestMaster obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VectorType2PensideTestMaster) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VectorType2PensideTestMaster) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VectorType2PensideTestMasterDetail"; } }
            public string HelpIdWin { get { return "Vector_Type-Field_test_matrix"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private VectorType2PensideTestMaster m_obj;
            internal Permissions(VectorType2PensideTestMaster obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spVectorTypeMaster_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spDummy_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spVectorType2PensideTestMaster_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VectorType2PensideTestMaster, bool>> RequiredByField = new Dictionary<string, Func<VectorType2PensideTestMaster, bool>>();
            public static Dictionary<string, Func<VectorType2PensideTestMaster, bool>> RequiredByProperty = new Dictionary<string, Func<VectorType2PensideTestMaster, bool>>();
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
                    "DeletePensideTest",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).DeletePensideTest(manager, (VectorType2PensideTestMaster)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    ActionMetaItem.DefaultDeleteGroupItemVisiblePredicate,
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<VectorType2PensideTestMaster>().Post(manager, (VectorType2PensideTestMaster)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<VectorType2PensideTestMaster>().Post(manager, (VectorType2PensideTestMaster)c), c),
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
	