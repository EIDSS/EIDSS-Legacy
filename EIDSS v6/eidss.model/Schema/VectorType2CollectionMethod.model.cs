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
    public abstract partial class VectorType2CollectionMethod : 
        EditableObject<VectorType2CollectionMethod>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfCollectionMethodForVectorType), NonUpdatable, PrimaryKey]
        public abstract Int64 idfCollectionMethodForVectorType { get; set; }
                
        [LocalizedDisplayName("strCollectionMethod")]
        [MapField(_str_idfsCollectionMethod)]
        public abstract Int64 idfsCollectionMethod { get; set; }
        protected Int64 idfsCollectionMethod_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCollectionMethod).OriginalValue; } }
        protected Int64 idfsCollectionMethod_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCollectionMethod).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsVectorType)]
        [MapField(_str_idfsVectorType)]
        public abstract Int64 idfsVectorType { get; set; }
        protected Int64 idfsVectorType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).OriginalValue; } }
        protected Int64 idfsVectorType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<VectorType2CollectionMethod, object> _get_func;
            internal Action<VectorType2CollectionMethod, string> _set_func;
            internal Action<VectorType2CollectionMethod, VectorType2CollectionMethod, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfCollectionMethodForVectorType = "idfCollectionMethodForVectorType";
        internal const string _str_idfsCollectionMethod = "idfsCollectionMethod";
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_CollectionMethod = "CollectionMethod";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfCollectionMethodForVectorType, _formname = _str_idfCollectionMethodForVectorType, _type = "Int64",
              _get_func = o => o.idfCollectionMethodForVectorType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfCollectionMethodForVectorType != newval) o.idfCollectionMethodForVectorType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfCollectionMethodForVectorType != c.idfCollectionMethodForVectorType || o.IsRIRPropChanged(_str_idfCollectionMethodForVectorType, c)) 
                  m.Add(_str_idfCollectionMethodForVectorType, o.ObjectIdent + _str_idfCollectionMethodForVectorType, o.ObjectIdent2 + _str_idfCollectionMethodForVectorType, o.ObjectIdent3 + _str_idfCollectionMethodForVectorType, "Int64", 
                    o.idfCollectionMethodForVectorType == null ? "" : o.idfCollectionMethodForVectorType.ToString(),                  
                  o.IsReadOnly(_str_idfCollectionMethodForVectorType), o.IsInvisible(_str_idfCollectionMethodForVectorType), o.IsRequired(_str_idfCollectionMethodForVectorType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCollectionMethod, _formname = _str_idfsCollectionMethod, _type = "Int64",
              _get_func = o => o.idfsCollectionMethod,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsCollectionMethod != newval) 
                  o.CollectionMethod = o.CollectionMethodLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsCollectionMethod != newval) o.idfsCollectionMethod = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsCollectionMethod != c.idfsCollectionMethod || o.IsRIRPropChanged(_str_idfsCollectionMethod, c)) 
                  m.Add(_str_idfsCollectionMethod, o.ObjectIdent + _str_idfsCollectionMethod, o.ObjectIdent2 + _str_idfsCollectionMethod, o.ObjectIdent3 + _str_idfsCollectionMethod, "Int64", 
                    o.idfsCollectionMethod == null ? "" : o.idfsCollectionMethod.ToString(),                  
                  o.IsReadOnly(_str_idfsCollectionMethod), o.IsInvisible(_str_idfsCollectionMethod), o.IsRequired(_str_idfsCollectionMethod)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsVectorType, _formname = _str_idfsVectorType, _type = "Int64",
              _get_func = o => o.idfsVectorType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsVectorType != newval) o.idfsVectorType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_idfsVectorType, c)) 
                  m.Add(_str_idfsVectorType, o.ObjectIdent + _str_idfsVectorType, o.ObjectIdent2 + _str_idfsVectorType, o.ObjectIdent3 + _str_idfsVectorType, "Int64", 
                    o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(),                  
                  o.IsReadOnly(_str_idfsVectorType), o.IsInvisible(_str_idfsVectorType), o.IsRequired(_str_idfsVectorType)); 
                  }
              }, 
        
            new field_info {
              _name = _str_CollectionMethod, _formname = _str_CollectionMethod, _type = "Lookup",
              _get_func = o => { if (o.CollectionMethod == null) return null; return o.CollectionMethod.idfsBaseReference; },
              _set_func = (o, val) => { o.CollectionMethod = o.CollectionMethodLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCollectionMethod != c.idfsCollectionMethod || o.IsRIRPropChanged(_str_CollectionMethod, c)) {
                  m.Add(_str_CollectionMethod, o.ObjectIdent + _str_CollectionMethod, o.ObjectIdent2 + _str_CollectionMethod, o.ObjectIdent3 + _str_CollectionMethod, "Lookup", o.idfsCollectionMethod == null ? "" : o.idfsCollectionMethod.ToString(), o.IsReadOnly(_str_CollectionMethod), o.IsInvisible(_str_CollectionMethod), o.IsRequired(_str_CollectionMethod)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_CollectionMethod + "Lookup", _formname = _str_CollectionMethod + "Lookup", _type = "LookupContent",
              _get_func = o => o.CollectionMethodLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
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
            VectorType2CollectionMethod obj = (VectorType2CollectionMethod)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_CollectionMethod)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCollectionMethod)]
        public BaseReference CollectionMethod
        {
            get { return _CollectionMethod == null ? null : ((long)_CollectionMethod.Key == 0 ? null : _CollectionMethod); }
            set 
            { 
                var oldVal = _CollectionMethod;
                _CollectionMethod = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_CollectionMethod != oldVal)
                {
                    if (idfsCollectionMethod != (_CollectionMethod == null
                            ? new Int64()
                            : (Int64)_CollectionMethod.idfsBaseReference))
                        idfsCollectionMethod = _CollectionMethod == null 
                            ? new Int64()
                            : (Int64)_CollectionMethod.idfsBaseReference; 
                    OnPropertyChanged(_str_CollectionMethod); 
                }
            }
        }
        private BaseReference _CollectionMethod;

        
        public BaseReferenceList CollectionMethodLookup
        {
            get { return _CollectionMethodLookup; }
        }
        private BaseReferenceList _CollectionMethodLookup = new BaseReferenceList("rftCollectionMethod");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_CollectionMethod:
                    return new BvSelectList(CollectionMethodLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CollectionMethod, _str_idfsCollectionMethod);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "VectorType2CollectionMethod";

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
            var ret = base.Clone() as VectorType2CollectionMethod;
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
            var ret = base.Clone() as VectorType2CollectionMethod;
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
        public VectorType2CollectionMethod CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VectorType2CollectionMethod;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfCollectionMethodForVectorType; } }
        public string KeyName { get { return "idfCollectionMethodForVectorType"; } }
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
        
            var _prev_idfsCollectionMethod_CollectionMethod = idfsCollectionMethod;
            base.RejectChanges();
        
            if (_prev_idfsCollectionMethod_CollectionMethod != idfsCollectionMethod)
            {
                _CollectionMethod = _CollectionMethodLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCollectionMethod);
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

        private bool IsRIRPropChanged(string fld, VectorType2CollectionMethod c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public VectorType2CollectionMethod()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VectorType2CollectionMethod_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VectorType2CollectionMethod_PropertyChanged);
        }
        private void VectorType2CollectionMethod_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VectorType2CollectionMethod).Changed(e.PropertyName);
            
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
            VectorType2CollectionMethod obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VectorType2CollectionMethod obj = this;
            
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


        internal Dictionary<string, Func<VectorType2CollectionMethod, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VectorType2CollectionMethod, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VectorType2CollectionMethod, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VectorType2CollectionMethod, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VectorType2CollectionMethod, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<VectorType2CollectionMethod, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<VectorType2CollectionMethod, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~VectorType2CollectionMethod()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftCollectionMethod", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftCollectionMethod")
                _getAccessor().LoadLookup_CollectionMethod(manager, this);
            
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
    
        #region Class for web grid
        public class VectorType2CollectionMethodGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public long idfCollectionMethodForVectorType { get; set; }
        
            public long idfsCollectionMethod { get; set; }
        
        }
        public partial class VectorType2CollectionMethodGridModelList : List<VectorType2CollectionMethodGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public VectorType2CollectionMethodGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VectorType2CollectionMethod>, errMes);
            }
            public VectorType2CollectionMethodGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VectorType2CollectionMethod>, errMes);
            }
            public VectorType2CollectionMethodGridModelList(long key, IEnumerable<VectorType2CollectionMethod> items)
            {
                LoadGridModelList(key, items, null);
            }
            public VectorType2CollectionMethodGridModelList(long key)
            {
                LoadGridModelList(key, new List<VectorType2CollectionMethod>(), null);
            }
            partial void filter(List<VectorType2CollectionMethod> items);
            private void LoadGridModelList(long key, IEnumerable<VectorType2CollectionMethod> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_idfsCollectionMethod};
                    
                Hiddens = new List<string> {_str_idfCollectionMethodForVectorType};
                Keys = new List<string> {};
                Labels = new Dictionary<string, string> {{_str_idfsCollectionMethod, "strCollectionMethod"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                VectorType2CollectionMethod.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<VectorType2CollectionMethod>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VectorType2CollectionMethodGridModel()
                {
                    idfCollectionMethodForVectorType=c.idfCollectionMethodForVectorType,idfsCollectionMethod=c.idfsCollectionMethod
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
        : DataAccessor<VectorType2CollectionMethod>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<VectorType2CollectionMethod>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfCollectionMethodForVectorType"; } }
            #endregion
        
            private delegate void on_action(VectorType2CollectionMethod obj);
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
            private BaseReference.Accessor CollectionMethodAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<VectorType2CollectionMethod> SelectList(DbManagerProxy manager
                )
            {
                return _SelectList(manager
                    , delegate(VectorType2CollectionMethod obj)
                        {
                        }
                    , delegate(VectorType2CollectionMethod obj)
                        {
                        }
                    );
            }

            
            private List<VectorType2CollectionMethod> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VectorType2CollectionMethod> objs = new List<VectorType2CollectionMethod>();
                    sets[0] = new MapResultSet(typeof(VectorType2CollectionMethod), objs);
                    
                    manager
                        .SetSpCommand("spCollectionMethodForVectorType_SelectDetail"
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, VectorType2CollectionMethod obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, VectorType2CollectionMethod obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private VectorType2CollectionMethod _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    VectorType2CollectionMethod obj = VectorType2CollectionMethod.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfCollectionMethodForVectorType = (new AutoIncrementExtender<VectorType2CollectionMethod>()).GetScalar(manager, obj, isFake);
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

            
            public VectorType2CollectionMethod CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public VectorType2CollectionMethod CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public VectorType2CollectionMethod CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(VectorType2CollectionMethod obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VectorType2CollectionMethod obj)
            {
                
            }
    
            public void LoadLookup_CollectionMethod(DbManagerProxy manager, VectorType2CollectionMethod obj)
            {
                
                obj.CollectionMethodLookup.Clear();
                
                obj.CollectionMethodLookup.Add(CollectionMethodAccessor.CreateNewT(manager, null));
                
                obj.CollectionMethodLookup.AddRange(CollectionMethodAccessor.rftCollectionMethod_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCollectionMethod))
                    
                    .ToList());
                
                if (obj.idfsCollectionMethod != 0)
                {
                    obj.CollectionMethod = obj.CollectionMethodLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsCollectionMethod);
                    
                }
              
                
                LookupManager.AddObject("rftCollectionMethod", obj, CollectionMethodAccessor.GetType(), "rftCollectionMethod_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, VectorType2CollectionMethod obj)
            {
                
                LoadLookup_CollectionMethod(manager, obj);
                
            }
    
            [SprocName("spCollectionMethodForVectorType_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfCollectionMethodForVectorType")] VectorType2CollectionMethod obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfCollectionMethodForVectorType")] VectorType2CollectionMethod obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    VectorType2CollectionMethod bo = obj as VectorType2CollectionMethod;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as VectorType2CollectionMethod, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VectorType2CollectionMethod obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
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
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(VectorType2CollectionMethod obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, VectorType2CollectionMethod obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(VectorType2CollectionMethod obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(VectorType2CollectionMethod obj, bool bRethrowException)
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
                return Validate(manager, obj as VectorType2CollectionMethod, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VectorType2CollectionMethod obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsCollectionMethod", "idfsCollectionMethod","strCollectionMethod",
                false
              )).Validate(c => true, obj, obj.idfsCollectionMethod);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
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
           
    
            private void _SetupRequired(VectorType2CollectionMethod obj)
            {
            
                obj
                    .AddRequired("idfsCollectionMethod", c => true);
                    
                  obj
                    .AddRequired("CollectionMethod", c => true);
                
            }
    
    private void _SetupPersonalDataRestrictions(VectorType2CollectionMethod obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VectorType2CollectionMethod) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VectorType2CollectionMethod) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VectorType2CollectionMethodDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spCollectionMethodForVectorType_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spCollectionMethodForVectorType_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VectorType2CollectionMethod, bool>> RequiredByField = new Dictionary<string, Func<VectorType2CollectionMethod, bool>>();
            public static Dictionary<string, Func<VectorType2CollectionMethod, bool>> RequiredByProperty = new Dictionary<string, Func<VectorType2CollectionMethod, bool>>();
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
                
                if (!RequiredByField.ContainsKey("idfsCollectionMethod")) RequiredByField.Add("idfsCollectionMethod", c => true);
                if (!RequiredByProperty.ContainsKey("idfsCollectionMethod")) RequiredByProperty.Add("idfsCollectionMethod", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfCollectionMethodForVectorType,
                    _str_idfCollectionMethodForVectorType, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsCollectionMethod,
                    "strCollectionMethod", null, true, true, true, true, null
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
                    (manager, c, pars) => ((VectorType2CollectionMethod)c).MarkToDelete(),
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
	