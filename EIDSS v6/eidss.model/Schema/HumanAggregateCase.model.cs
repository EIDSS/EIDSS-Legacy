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
    public abstract partial class HumanAggregateCase : 
        EditableObject<HumanAggregateCase>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfAggrCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfAggrCase { get; set; }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<HumanAggregateCase, object> _get_func;
            internal Action<HumanAggregateCase, string> _set_func;
            internal Action<HumanAggregateCase, HumanAggregateCase, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfAggrCase = "idfAggrCase";
        internal const string _str_Header = "Header";
        internal const string _str_Detailed = "Detailed";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfAggrCase, _formname = _str_idfAggrCase, _type = "Int64",
              _get_func = o => o.idfAggrCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfAggrCase != newval) o.idfAggrCase = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfAggrCase != c.idfAggrCase || o.IsRIRPropChanged(_str_idfAggrCase, c)) 
                  m.Add(_str_idfAggrCase, o.ObjectIdent + _str_idfAggrCase, o.ObjectIdent2 + _str_idfAggrCase, o.ObjectIdent3 + _str_idfAggrCase, "Int64", 
                    o.idfAggrCase == null ? "" : o.idfAggrCase.ToString(),                  
                  o.IsReadOnly(_str_idfAggrCase), o.IsInvisible(_str_idfAggrCase), o.IsRequired(_str_idfAggrCase)); 
                  }
              }, 
        
            new field_info {
              _name = _str_Header, _formname = _str_Header, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Header != null) o.Header._compare(c.Header, m); }
              }, 
        
            new field_info {
              _name = _str_Detailed, _formname = _str_Detailed, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Detailed != null) o.Detailed._compare(c.Detailed, m); }
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
            HumanAggregateCase obj = (HumanAggregateCase)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Header)]
        [Relation(typeof(AggregateCaseHeader), eidss.model.Schema.AggregateCaseHeader._str_idfAggrCase, _str_idfAggrCase)]
        public AggregateCaseHeader Header
        {
            get 
            {   
                return _Header; 
            }
            set 
            {   
                _Header = value;
                if (_Header != null) 
                { 
                    _Header.m_ObjectName = _str_Header;
                    _Header.Parent = this;
                }
                idfAggrCase = _Header == null 
                        ? new Int64()
                        : _Header.idfAggrCase;
                
            }
        }
        protected AggregateCaseHeader _Header;
                    
        [LocalizedDisplayName(_str_Detailed)]
        [Relation(typeof(HumanAggregateCaseDetailed), "", _str_idfAggrCase)]
        public HumanAggregateCaseDetailed Detailed
        {
            get 
            {   
                return _Detailed; 
            }
            set 
            {   
                _Detailed = value; 
                if (_Detailed != null) 
                { 
                    _Detailed.m_ObjectName = _str_Detailed;
                    _Detailed.Parent = this;
                }
            }
        }
        protected HumanAggregateCaseDetailed _Detailed;
                    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "HumanAggregateCase";

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
        
            if (_Header != null) { _Header.Parent = this; }
                
            if (_Detailed != null) { _Detailed.Parent = this; }
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as HumanAggregateCase;
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
            var ret = base.Clone() as HumanAggregateCase;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Header != null)
              ret.Header = _Header.CloneWithSetup(manager, bRestricted) as AggregateCaseHeader;
                
            if (_Detailed != null)
              ret.Detailed = _Detailed.CloneWithSetup(manager, bRestricted) as HumanAggregateCaseDetailed;
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public HumanAggregateCase CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as HumanAggregateCase;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfAggrCase; } }
        public string KeyName { get { return "idfAggrCase"; } }
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
        
                    || (_Header != null && _Header.HasChanges)
                
                    || (_Detailed != null && _Detailed.HasChanges)
                
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
        
            if (Header != null) Header.DeepRejectChanges();
                
            if (Detailed != null) Detailed.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Header != null) _Header.DeepAcceptChanges();
                
            if (_Detailed != null) _Detailed.DeepAcceptChanges();
                
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
        
            if (_Header != null) _Header.SetChange();
                
            if (_Detailed != null) _Detailed.SetChange();
                
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

        private bool IsRIRPropChanged(string fld, HumanAggregateCase c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public HumanAggregateCase()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(HumanAggregateCase_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(HumanAggregateCase_PropertyChanged);
        }
        private void HumanAggregateCase_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as HumanAggregateCase).Changed(e.PropertyName);
            
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
            HumanAggregateCase obj = this;
            
        }
        private void _DeletedExtenders()
        {
            HumanAggregateCase obj = this;
            
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
        
                if (_Header != null)
                    _Header.ReadOnly |= value;
                
                if (_Detailed != null)
                    _Detailed.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<HumanAggregateCase, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<HumanAggregateCase, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<HumanAggregateCase, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<HumanAggregateCase, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<HumanAggregateCase, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<HumanAggregateCase, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<HumanAggregateCase, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~HumanAggregateCase()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                if (_Header != null)
                    Header.Dispose();
                
                if (_Detailed != null)
                    Detailed.Dispose();
                
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
        
            if (_Header != null) _Header.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_Detailed != null) _Detailed.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<HumanAggregateCase>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<HumanAggregateCase>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<HumanAggregateCase>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfAggrCase"; } }
            #endregion
        
            private delegate void on_action(HumanAggregateCase obj);
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
            private AggregateCaseHeader.Accessor HeaderAccessor { get { return eidss.model.Schema.AggregateCaseHeader.Accessor.Instance(m_CS); } }
            private HumanAggregateCaseDetailed.Accessor DetailedAccessor { get { return eidss.model.Schema.HumanAggregateCaseDetailed.Accessor.Instance(m_CS); } }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual HumanAggregateCase SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual HumanAggregateCase SelectByKey(DbManagerProxy manager
                , Int64? idfAggrCase
                )
            {
                return _SelectByKey(manager
                    , idfAggrCase
                    , null, null
                    );
            }
            
      
            private HumanAggregateCase _SelectByKey(DbManagerProxy manager
                , Int64? idfAggrCase
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<HumanAggregateCase> objs = new List<HumanAggregateCase>();
                sets[0] = new MapResultSet(typeof(HumanAggregateCase), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spAggregateCaseDummy_SelectDetail"
                            , manager.Parameter("@idfAggrCase", idfAggrCase)
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    HumanAggregateCase obj = objs[0];
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
    
            internal void _LoadHeader(HumanAggregateCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadHeader(manager, obj);
                }
            }
            internal void _LoadHeader(DbManagerProxy manager, HumanAggregateCase obj)
            {
                
                if (obj.Header == null && obj.idfAggrCase != 0)
                {
                    obj.Header = HeaderAccessor.SelectByKey(manager
                        
                        , obj.idfAggrCase
                        , new Func<HumanAggregateCase, long>(c => (long)AggregateCaseType.HumanAggregateCase)(obj)
                        
                        );
                    if (obj.Header != null)
                    {
                        obj.Header.m_ObjectName = _str_Header;
                    }
                }
                    
            }
            
            internal void _LoadDetailed(HumanAggregateCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadDetailed(manager, obj);
                }
            }
            internal void _LoadDetailed(DbManagerProxy manager, HumanAggregateCase obj)
            {
                
                if (obj.Detailed == null && obj.idfAggrCase != 0)
                {
                    obj.Detailed = DetailedAccessor.SelectByKey(manager
                        
                        , obj.idfAggrCase
                        );
                    if (obj.Detailed != null)
                    {
                        obj.Detailed.m_ObjectName = _str_Detailed;
                    }
                }
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, HumanAggregateCase obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadHeader(manager, obj);
                _LoadDetailed(manager, obj);
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
            
            internal void _SetPermitions(IObjectPermissions permissions, HumanAggregateCase obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    HeaderAccessor._SetPermitions(obj._permissions, obj.Header);
                    DetailedAccessor._SetPermitions(obj._permissions, obj.Detailed);
                    
                    }
                }
            }

    

            private HumanAggregateCase _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    HumanAggregateCase obj = HumanAggregateCase.CreateInstance();
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
                obj.Detailed = new Func<HumanAggregateCase, HumanAggregateCaseDetailed>(c => DetailedAccessor.SelectByKey(manager, c.idfAggrCase))(obj);
                obj.Header = new Func<HumanAggregateCase, AggregateCaseHeader>(c => HeaderAccessor.Create(manager, c, (long)AggregateCaseType.HumanAggregateCase, obj.Detailed != null ? obj.Detailed.idfVersion : new long?()))(obj);
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

            
            public HumanAggregateCase CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public HumanAggregateCase CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public HumanAggregateCase CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult HumanAggregateCaseReport(DbManagerProxy manager, HumanAggregateCase obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("id", typeof(long));
                
                return HumanAggregateCaseReport(manager, obj
                    , (long)pars[0]
                    );
            }
            public ActResult HumanAggregateCaseReport(DbManagerProxy manager, HumanAggregateCase obj
                , long id
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("HumanAggregateCaseReport"))
                    throw new PermissionException("AccessToHumanAggregateCase", "HumanAggregateCaseReport");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(HumanAggregateCase obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(HumanAggregateCase obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, HumanAggregateCase obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(HumanAggregateCase obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(HumanAggregateCase obj, bool bRethrowException)
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
                return Validate(manager, obj as HumanAggregateCase, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, HumanAggregateCase obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToHumanAggregateCase.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToHumanAggregateCase.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToHumanAggregateCase.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToHumanAggregateCase.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(HumanAggregateCase obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(HumanAggregateCase obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as HumanAggregateCase) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as HumanAggregateCase) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "HumanAggregateCaseDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return "HC_H06"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private HumanAggregateCase m_obj;
            internal Permissions(HumanAggregateCase obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToHumanAggregateCase.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToHumanAggregateCase.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToHumanAggregateCase.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToHumanAggregateCase.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spAggregateCaseDummy_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<HumanAggregateCase, bool>> RequiredByField = new Dictionary<string, Func<HumanAggregateCase, bool>>();
            public static Dictionary<string, Func<HumanAggregateCase, bool>> RequiredByProperty = new Dictionary<string, Func<HumanAggregateCase, bool>>();
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
                    "HumanAggregateCaseReport",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).HumanAggregateCaseReport(manager, (HumanAggregateCase)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titlePaperForms",
                        "Report",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Main,
                        ActionsAppType.All
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
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<HumanAggregateCase>().Post(manager, (HumanAggregateCase)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<HumanAggregateCase>().Post(manager, (HumanAggregateCase)c), c),
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
	