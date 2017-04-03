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
    public abstract partial class VectorSubType : 
        EditableObject<VectorSubType>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsVectorSubType), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsVectorSubType { get; set; }
                
        [LocalizedDisplayName(_str_idfsVectorType)]
        [MapField(_str_idfsVectorType)]
        public abstract Int64 idfsVectorType { get; set; }
        #if MONO
        protected Int64 idfsVectorType_Original { get { return idfsVectorType; } }
        protected Int64 idfsVectorType_Previous { get { return idfsVectorType; } }
        #else
        protected Int64 idfsVectorType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).OriginalValue; } }
        protected Int64 idfsVectorType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strTranslatedName)]
        [MapField(_str_strTranslatedName)]
        public abstract String strTranslatedName { get; set; }
        #if MONO
        protected String strTranslatedName_Original { get { return strTranslatedName; } }
        protected String strTranslatedName_Previous { get { return strTranslatedName; } }
        #else
        protected String strTranslatedName_Original { get { return ((EditableValue<String>)((dynamic)this)._strTranslatedName).OriginalValue; } }
        protected String strTranslatedName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTranslatedName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strDefaultName)]
        [MapField(_str_strDefaultName)]
        public abstract String strDefaultName { get; set; }
        #if MONO
        protected String strDefaultName_Original { get { return strDefaultName; } }
        protected String strDefaultName_Previous { get { return strDefaultName; } }
        #else
        protected String strDefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._strDefaultName).OriginalValue; } }
        protected String strDefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDefaultName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCode)]
        [MapField(_str_strCode)]
        public abstract String strCode { get; set; }
        #if MONO
        protected String strCode_Original { get { return strCode; } }
        protected String strCode_Previous { get { return strCode; } }
        #else
        protected String strCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strCode).OriginalValue; } }
        protected String strCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32? intOrder { get; set; }
        #if MONO
        protected Int32? intOrder_Original { get { return intOrder; } }
        protected Int32? intOrder_Previous { get { return intOrder; } }
        #else
        protected Int32? intOrder_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32? intOrder_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsReferenceType)]
        [MapField(_str_idfsReferenceType)]
        public abstract Int64 idfsReferenceType { get; set; }
        #if MONO
        protected Int64 idfsReferenceType_Original { get { return idfsReferenceType; } }
        protected Int64 idfsReferenceType_Previous { get { return idfsReferenceType; } }
        #else
        protected Int64 idfsReferenceType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsReferenceType).OriginalValue; } }
        protected Int64 idfsReferenceType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsReferenceType).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<VectorSubType, object> _get_func;
            internal Action<VectorSubType, string> _set_func;
            internal Action<VectorSubType, VectorSubType, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsVectorSubType = "idfsVectorSubType";
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_strTranslatedName = "strTranslatedName";
        internal const string _str_strDefaultName = "strDefaultName";
        internal const string _str_strCode = "strCode";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_idfsReferenceType = "idfsReferenceType";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfsVectorSubType, _type = "Int64",
              _get_func = o => o.idfsVectorSubType,
              _set_func = (o, val) => { o.idfsVectorSubType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorSubType != c.idfsVectorSubType || o.IsRIRPropChanged(_str_idfsVectorSubType, c)) 
                  m.Add(_str_idfsVectorSubType, o.ObjectIdent + _str_idfsVectorSubType, "Int64", o.idfsVectorSubType == null ? "" : o.idfsVectorSubType.ToString(), o.IsReadOnly(_str_idfsVectorSubType), o.IsInvisible(_str_idfsVectorSubType), o.IsRequired(_str_idfsVectorSubType)); }
              }, 
        
            new field_info {
              _name = _str_idfsVectorType, _type = "Int64",
              _get_func = o => o.idfsVectorType,
              _set_func = (o, val) => { o.idfsVectorType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_idfsVectorType, c)) 
                  m.Add(_str_idfsVectorType, o.ObjectIdent + _str_idfsVectorType, "Int64", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_idfsVectorType), o.IsInvisible(_str_idfsVectorType), o.IsRequired(_str_idfsVectorType)); }
              }, 
        
            new field_info {
              _name = _str_strTranslatedName, _type = "String",
              _get_func = o => o.strTranslatedName,
              _set_func = (o, val) => { o.strTranslatedName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strTranslatedName != c.strTranslatedName || o.IsRIRPropChanged(_str_strTranslatedName, c)) 
                  m.Add(_str_strTranslatedName, o.ObjectIdent + _str_strTranslatedName, "String", o.strTranslatedName == null ? "" : o.strTranslatedName.ToString(), o.IsReadOnly(_str_strTranslatedName), o.IsInvisible(_str_strTranslatedName), o.IsRequired(_str_strTranslatedName)); }
              }, 
        
            new field_info {
              _name = _str_strDefaultName, _type = "String",
              _get_func = o => o.strDefaultName,
              _set_func = (o, val) => { o.strDefaultName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strDefaultName != c.strDefaultName || o.IsRIRPropChanged(_str_strDefaultName, c)) 
                  m.Add(_str_strDefaultName, o.ObjectIdent + _str_strDefaultName, "String", o.strDefaultName == null ? "" : o.strDefaultName.ToString(), o.IsReadOnly(_str_strDefaultName), o.IsInvisible(_str_strDefaultName), o.IsRequired(_str_strDefaultName)); }
              }, 
        
            new field_info {
              _name = _str_strCode, _type = "String",
              _get_func = o => o.strCode,
              _set_func = (o, val) => { o.strCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCode != c.strCode || o.IsRIRPropChanged(_str_strCode, c)) 
                  m.Add(_str_strCode, o.ObjectIdent + _str_strCode, "String", o.strCode == null ? "" : o.strCode.ToString(), o.IsReadOnly(_str_strCode), o.IsInvisible(_str_strCode), o.IsRequired(_str_strCode)); }
              }, 
        
            new field_info {
              _name = _str_intOrder, _type = "Int32?",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { o.intOrder = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, "Int32?", o.intOrder == null ? "" : o.intOrder.ToString(), o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); }
              }, 
        
            new field_info {
              _name = _str_idfsReferenceType, _type = "Int64",
              _get_func = o => o.idfsReferenceType,
              _set_func = (o, val) => { o.idfsReferenceType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsReferenceType != c.idfsReferenceType || o.IsRIRPropChanged(_str_idfsReferenceType, c)) 
                  m.Add(_str_idfsReferenceType, o.ObjectIdent + _str_idfsReferenceType, "Int64", o.idfsReferenceType == null ? "" : o.idfsReferenceType.ToString(), o.IsReadOnly(_str_idfsReferenceType), o.IsInvisible(_str_idfsReferenceType), o.IsRequired(_str_idfsReferenceType)); }
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
            VectorSubType obj = (VectorSubType)o;
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
        internal string m_ObjectName = "VectorSubType";

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
        public override object Clone()
        {
            var ret = base.Clone() as VectorSubType;
            ret.m_Parent = this.Parent;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager)
        {
            var ret = base.Clone() as VectorSubType;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public VectorSubType CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VectorSubType;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsVectorSubType; } }
        public string KeyName { get { return "idfsVectorSubType"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
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
      public IObjectAccessor GetAccessor() { return _getAccessor(); }
      public IObjectPermissions GetPermissions() { return _permissions; }
      public bool ReadOnly { get { return _readOnly; } set { _readOnly = value; } }
      public bool IsReadOnly(string name) { return _isReadOnly(name); }
      public bool IsInvisible(string name) { return _isInvisible(name); }
      public bool IsRequired(string name) { return _isRequired(name); }
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
          
              switch(name)
              {
              
                case "strDefaultName":
                  return new Dictionary<string, string> {
                
                    { "en", "" },
                
                    } ;
              
                case "strTranslatedName":
                  return new Dictionary<string, string> {
                
                    { "def", "" },
                
                    } ;
              
                default:
                  return null;
              }
            
        }
      #endregion

      private bool IsRIRPropChanged(string fld, VectorSubType c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public VectorSubType()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();

        

        private bool m_IsForcedToDelete;
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VectorSubType_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VectorSubType_PropertyChanged);
        }
        private void VectorSubType_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VectorSubType).Changed(e.PropertyName);
            
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
            VectorSubType obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VectorSubType obj = this;
            
        }
        
        public bool OnValidation(string msgId, string fldName, string prpName, object[] pars, Type type, bool shouldAsk)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(msgId, fldName, prpName, pars, type, this, shouldAsk);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(string msgId, string fldName, string prpName, object[] pars, Type type, bool shouldAsk)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(msgId, fldName, prpName, pars, type, this, shouldAsk);
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


        public Dictionary<string, Func<VectorSubType, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VectorSubType, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VectorSubType, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<VectorSubType, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<VectorSubType, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<VectorSubType, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~VectorSubType()
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
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._name] != null) a._set_func(this, form[ObjectIdent + a._name]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._name)) a._set_func(this, form[ObjectIdent + a._name]);} );
      
            if (bParseRelations)
            {
        
            }
        }
    
        #region Class for web grid
        public class VectorSubTypeGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public long idfsVectorSubType { get; set; }
        
            public string strDefaultName { get; set; }
        
            public string strTranslatedName { get; set; }
        
            public string strCode { get; set; }
        
            public int? intOrder { get; set; }
        
        }
        public partial class VectorSubTypeGridModelList : List<VectorSubTypeGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public VectorSubTypeGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VectorSubType>, errMes);
            }
            public VectorSubTypeGridModelList(long key, IEnumerable<VectorSubType> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<VectorSubType> items);
            private void LoadGridModelList(long key, IEnumerable<VectorSubType> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strDefaultName,_str_strTranslatedName,_str_strCode,_str_intOrder};
                    
                Hiddens = new List<string> {_str_idfsVectorSubType};
                Keys = new List<string> {};
                Labels = new Dictionary<string, string> {{_str_strDefaultName, _str_strDefaultName},{_str_strTranslatedName, _str_strTranslatedName},{_str_strCode, _str_strCode},{_str_intOrder, _str_intOrder}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<VectorSubType>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VectorSubTypeGridModel()
                {
                    idfsVectorSubType=c.idfsVectorSubType,strDefaultName=c.strDefaultName,strTranslatedName=c.strTranslatedName,strCode=c.strCode,intOrder=c.intOrder
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
        : DataAccessor<VectorSubType>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(VectorSubType obj);
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
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<VectorSubType> SelectList(DbManagerProxy manager
                )
            {
                return _SelectList(manager
                    , delegate(VectorSubType obj)
                        {
                        }
                    , delegate(VectorSubType obj)
                        {
                        }
                    );
            }

            
            private List<VectorSubType> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VectorSubType> objs = new List<VectorSubType>();
                    sets[0] = new MapResultSet(typeof(VectorSubType), objs);
                    
                    manager
                        .SetSpCommand("spVectorSubType_SelectDetail"
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, VectorSubType obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
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
            
            internal void _SetPermitions(IObjectPermissions permissions, VectorSubType obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private VectorSubType _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    VectorSubType obj = VectorSubType.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfsVectorSubType = (new AutoIncrementExtender<VectorSubType>()).GetScalar(manager, obj);
                obj.intOrder = new Func<VectorSubType, int>(c => 0)(obj);
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

            
            public VectorSubType CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public VectorSubType CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(VectorSubType obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VectorSubType obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, VectorSubType obj)
            {
                
            }
    
            [SprocName("spVectorSubType_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, string LangID, 
                [Direction.InputOutput("idfsVectorSubType")] VectorSubType obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, string LangID, 
                [Direction.InputOutput("idfsVectorSubType")] VectorSubType obj)
            {
                
                _post(manager, Action, LangID, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    VectorSubType bo = obj as VectorSubType;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as VectorSubType, bChildObject);
                    if (bTransactionStarted)
                    {
                        if (bSuccess)
                        {
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
            private bool _PostNonTransaction(DbManagerProxy manager, VectorSubType obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postPredicate(manager, 8, ModelUserContext.CurrentLanguage, obj);
                                
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, ModelUserContext.CurrentLanguage, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, ModelUserContext.CurrentLanguage, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(VectorSubType obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, VectorSubType obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as VectorSubType, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VectorSubType obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsVectorSubType", "idfsVectorSubType","",
                false
              )).Validate(c => true, obj, obj.idfsVectorSubType);
            
                (new RequiredValidator( "strDefaultName", "strDefaultName","",
                false
              )).Validate(c => true, obj, obj.strDefaultName);
            
                (new RequiredValidator( "strTranslatedName", "strTranslatedName","",
                false
              )).Validate(c => ModelUserContext.CurrentLanguage != Localizer.lngEn, obj, obj.strTranslatedName);
            
                  
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
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                        return false;
                    }
                }
                
                return true;
            }
           
    
            private void _SetupRequired(VectorSubType obj)
            {
            
                obj
                    .AddRequired("idfsVectorSubType", c => true);
                    
                obj
                    .AddRequired("strDefaultName", c => true);
                    
                obj
                    .AddRequired("strTranslatedName", c => ModelUserContext.CurrentLanguage != Localizer.lngEn);
                    
            }
    
    private void _SetupPersonalDataRestrictions(VectorSubType obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VectorSubType) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VectorSubType) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VectorSubTypeDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spVectorSubType_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spVectorSubType_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VectorSubType, bool>> RequiredByField = new Dictionary<string, Func<VectorSubType, bool>>();
            public static Dictionary<string, Func<VectorSubType, bool>> RequiredByProperty = new Dictionary<string, Func<VectorSubType, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strTranslatedName, 2000);
                Sizes.Add(_str_strDefaultName, 2000);
                Sizes.Add(_str_strCode, 50);
                if (!RequiredByField.ContainsKey("idfsVectorSubType")) RequiredByField.Add("idfsVectorSubType", c => true);
                if (!RequiredByProperty.ContainsKey("idfsVectorSubType")) RequiredByProperty.Add("idfsVectorSubType", c => true);
                
                if (!RequiredByField.ContainsKey("strDefaultName")) RequiredByField.Add("strDefaultName", c => true);
                if (!RequiredByProperty.ContainsKey("strDefaultName")) RequiredByProperty.Add("strDefaultName", c => true);
                
                if (!RequiredByField.ContainsKey("strTranslatedName")) RequiredByField.Add("strTranslatedName", c => ModelUserContext.CurrentLanguage != Localizer.lngEn);
                if (!RequiredByProperty.ContainsKey("strTranslatedName")) RequiredByProperty.Add("strTranslatedName", c => ModelUserContext.CurrentLanguage != Localizer.lngEn);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfsVectorSubType,
                    _str_idfsVectorSubType, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDefaultName,
                    _str_strDefaultName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTranslatedName,
                    _str_strTranslatedName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCode,
                    _str_strCode, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intOrder,
                    _str_intOrder, null, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, null, pars)),
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
                    (manager, c, pars) => ((VectorSubType)c).MarkToDelete(),
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	