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
    public abstract partial class RuleAction : 
        EditableObject<RuleAction>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfParameterForAction), NonUpdatable, PrimaryKey]
        public abstract Int64 idfParameterForAction { get; set; }
                
        [LocalizedDisplayName(_str_idfsRule)]
        [MapField(_str_idfsRule)]
        public abstract Int64 idfsRule { get; set; }
        protected Int64 idfsRule_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsRule).OriginalValue; } }
        protected Int64 idfsRule_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsRule).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRuleAction)]
        [MapField(_str_idfsRuleAction)]
        public abstract Int64? idfsRuleAction { get; set; }
        protected Int64? idfsRuleAction_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRuleAction).OriginalValue; } }
        protected Int64? idfsRuleAction_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRuleAction).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsParameter)]
        [MapField(_str_idfsParameter)]
        public abstract Int64 idfsParameter { get; set; }
        protected Int64 idfsParameter_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsParameter).OriginalValue; } }
        protected Int64 idfsParameter_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsParameter).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64 idfsFormTemplate { get; set; }
        protected Int64 idfsFormTemplate_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64 idfsFormTemplate_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<RuleAction, object> _get_func;
            internal Action<RuleAction, string> _set_func;
            internal Action<RuleAction, RuleAction, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfParameterForAction = "idfParameterForAction";
        internal const string _str_idfsRule = "idfsRule";
        internal const string _str_idfsRuleAction = "idfsRuleAction";
        internal const string _str_idfsParameter = "idfsParameter";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfParameterForAction, _formname = _str_idfParameterForAction, _type = "Int64",
              _get_func = o => o.idfParameterForAction,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfParameterForAction != newval) o.idfParameterForAction = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfParameterForAction != c.idfParameterForAction || o.IsRIRPropChanged(_str_idfParameterForAction, c)) 
                  m.Add(_str_idfParameterForAction, o.ObjectIdent + _str_idfParameterForAction, o.ObjectIdent2 + _str_idfParameterForAction, o.ObjectIdent3 + _str_idfParameterForAction, "Int64", 
                    o.idfParameterForAction == null ? "" : o.idfParameterForAction.ToString(),                  
                  o.IsReadOnly(_str_idfParameterForAction), o.IsInvisible(_str_idfParameterForAction), o.IsRequired(_str_idfParameterForAction)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsRule, _formname = _str_idfsRule, _type = "Int64",
              _get_func = o => o.idfsRule,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsRule != newval) o.idfsRule = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsRule != c.idfsRule || o.IsRIRPropChanged(_str_idfsRule, c)) 
                  m.Add(_str_idfsRule, o.ObjectIdent + _str_idfsRule, o.ObjectIdent2 + _str_idfsRule, o.ObjectIdent3 + _str_idfsRule, "Int64", 
                    o.idfsRule == null ? "" : o.idfsRule.ToString(),                  
                  o.IsReadOnly(_str_idfsRule), o.IsInvisible(_str_idfsRule), o.IsRequired(_str_idfsRule)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsRuleAction, _formname = _str_idfsRuleAction, _type = "Int64?",
              _get_func = o => o.idfsRuleAction,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsRuleAction != newval) o.idfsRuleAction = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsRuleAction != c.idfsRuleAction || o.IsRIRPropChanged(_str_idfsRuleAction, c)) 
                  m.Add(_str_idfsRuleAction, o.ObjectIdent + _str_idfsRuleAction, o.ObjectIdent2 + _str_idfsRuleAction, o.ObjectIdent3 + _str_idfsRuleAction, "Int64?", 
                    o.idfsRuleAction == null ? "" : o.idfsRuleAction.ToString(),                  
                  o.IsReadOnly(_str_idfsRuleAction), o.IsInvisible(_str_idfsRuleAction), o.IsRequired(_str_idfsRuleAction)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsParameter, _formname = _str_idfsParameter, _type = "Int64",
              _get_func = o => o.idfsParameter,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsParameter != newval) o.idfsParameter = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsParameter != c.idfsParameter || o.IsRIRPropChanged(_str_idfsParameter, c)) 
                  m.Add(_str_idfsParameter, o.ObjectIdent + _str_idfsParameter, o.ObjectIdent2 + _str_idfsParameter, o.ObjectIdent3 + _str_idfsParameter, "Int64", 
                    o.idfsParameter == null ? "" : o.idfsParameter.ToString(),                  
                  o.IsReadOnly(_str_idfsParameter), o.IsInvisible(_str_idfsParameter), o.IsRequired(_str_idfsParameter)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsFormTemplate, _formname = _str_idfsFormTemplate, _type = "Int64",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsFormTemplate != newval) o.idfsFormTemplate = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, o.ObjectIdent2 + _str_idfsFormTemplate, o.ObjectIdent3 + _str_idfsFormTemplate, "Int64", 
                    o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(),                  
                  o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); 
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
            RuleAction obj = (RuleAction)o;
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
        internal string m_ObjectName = "RuleAction";

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
            var ret = base.Clone() as RuleAction;
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
            var ret = base.Clone() as RuleAction;
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
        public RuleAction CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as RuleAction;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfParameterForAction; } }
        public string KeyName { get { return "idfParameterForAction"; } }
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

        private bool IsRIRPropChanged(string fld, RuleAction c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public RuleAction()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(RuleAction_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(RuleAction_PropertyChanged);
        }
        private void RuleAction_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as RuleAction).Changed(e.PropertyName);
            
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
            RuleAction obj = this;
            
        }
        private void _DeletedExtenders()
        {
            RuleAction obj = this;
            
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


        internal Dictionary<string, Func<RuleAction, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<RuleAction, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<RuleAction, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<RuleAction, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<RuleAction, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<RuleAction, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<RuleAction, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~RuleAction()
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
        : DataAccessor<RuleAction>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<RuleAction>
            
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfParameterForAction"; } }
            #endregion
        
            private delegate void on_action(RuleAction obj);
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
            
            public virtual List<RuleAction> SelectList(DbManagerProxy manager
                , Int64? idfsRule
                )
            {
                return _SelectList(manager
                    , idfsRule
                    , delegate(RuleAction obj)
                        {
                        }
                    , delegate(RuleAction obj)
                        {
                        }
                    );
            }

            
            public List<RuleAction> SelectDetailListT(DbManagerProxy manager, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                
                if (!(pars[0] is Int64?)) 
                    throw new TypeMismatchException("idfsRule", typeof(Int64?));
                
                return SelectDetailList(manager
                    
                    , (Int64?)pars[0]
                    
                    );
            }
            public List<RuleAction> SelectDetailList(DbManagerProxy manager, List<object> pars)
            {
                return SelectDetailListT(manager, pars);
            }
            
            public virtual List<RuleAction> SelectDetailList(DbManagerProxy manager
                , Int64? idfsRule
                )
            {
                return _SelectList(manager
                    , idfsRule
                    , delegate(RuleAction obj)
                        {
                
                        }
                    , delegate(RuleAction obj)
                        {
                
                        }
                    );
            }
            
            private List<RuleAction> _SelectList(DbManagerProxy manager
                , Int64? idfsRule
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<RuleAction> objs = new List<RuleAction>();
                    sets[0] = new MapResultSet(typeof(RuleAction), objs);
                    
                    manager
                        .SetSpCommand("spFFGetRuleParameterForAction"
                            , manager.Parameter("@idfsRule", idfsRule)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, RuleAction obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, RuleAction obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private RuleAction _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    RuleAction obj = RuleAction.CreateInstance();
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

            
            public RuleAction CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public RuleAction CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public RuleAction CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(RuleAction obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(RuleAction obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, RuleAction obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(RuleAction obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(RuleAction obj, bool bRethrowException)
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
                return Validate(manager, obj as RuleAction, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, RuleAction obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(RuleAction obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(RuleAction obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as RuleAction) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as RuleAction) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "RuleActionDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFFGetRuleParameterForAction";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<RuleAction, bool>> RequiredByField = new Dictionary<string, Func<RuleAction, bool>>();
            public static Dictionary<string, Func<RuleAction, bool>> RequiredByProperty = new Dictionary<string, Func<RuleAction, bool>>();
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<RuleAction>().Post(manager, (RuleAction)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<RuleAction>().Post(manager, (RuleAction)c), c),
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
                    (manager, c, pars) => new ActResult(((RuleAction)c).MarkToDelete() && ObjectAccessor.PostInterface<RuleAction>().Post(manager, (RuleAction)c), c),
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
	