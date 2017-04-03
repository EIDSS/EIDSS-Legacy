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
    public abstract partial class FormType : 
        EditableObject<FormType>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsFormType), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsFormType { get; set; }
                
        [LocalizedDisplayName(_str_name)]
        [MapField(_str_name)]
        public abstract String name { get; set; }
        #if MONO
        protected String name_Original { get { return name; } }
        protected String name_Previous { get { return name; } }
        #else
        protected String name_Original { get { return ((EditableValue<String>)((dynamic)this)._name).OriginalValue; } }
        protected String name_Previous { get { return ((EditableValue<String>)((dynamic)this)._name).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_LongName)]
        [MapField(_str_LongName)]
        public abstract String LongName { get; set; }
        #if MONO
        protected String LongName_Original { get { return LongName; } }
        protected String LongName_Previous { get { return LongName; } }
        #else
        protected String LongName_Original { get { return ((EditableValue<String>)((dynamic)this)._longName).OriginalValue; } }
        protected String LongName_Previous { get { return ((EditableValue<String>)((dynamic)this)._longName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_HasParameters)]
        [MapField(_str_HasParameters)]
        public abstract Int32 HasParameters { get; set; }
        #if MONO
        protected Int32 HasParameters_Original { get { return HasParameters; } }
        protected Int32 HasParameters_Previous { get { return HasParameters; } }
        #else
        protected Int32 HasParameters_Original { get { return ((EditableValue<Int32>)((dynamic)this)._hasParameters).OriginalValue; } }
        protected Int32 HasParameters_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._hasParameters).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_HasNestedSections)]
        [MapField(_str_HasNestedSections)]
        public abstract Int32 HasNestedSections { get; set; }
        #if MONO
        protected Int32 HasNestedSections_Original { get { return HasNestedSections; } }
        protected Int32 HasNestedSections_Previous { get { return HasNestedSections; } }
        #else
        protected Int32 HasNestedSections_Original { get { return ((EditableValue<Int32>)((dynamic)this)._hasNestedSections).OriginalValue; } }
        protected Int32 HasNestedSections_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._hasNestedSections).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_HasTemplates)]
        [MapField(_str_HasTemplates)]
        public abstract Int32 HasTemplates { get; set; }
        #if MONO
        protected Int32 HasTemplates_Original { get { return HasTemplates; } }
        protected Int32 HasTemplates_Previous { get { return HasTemplates; } }
        #else
        protected Int32 HasTemplates_Original { get { return ((EditableValue<Int32>)((dynamic)this)._hasTemplates).OriginalValue; } }
        protected Int32 HasTemplates_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._hasTemplates).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<FormType, object> _get_func;
            internal Action<FormType, string> _set_func;
            internal Action<FormType, FormType, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsFormType = "idfsFormType";
        internal const string _str_name = "name";
        internal const string _str_LongName = "LongName";
        internal const string _str_HasParameters = "HasParameters";
        internal const string _str_HasNestedSections = "HasNestedSections";
        internal const string _str_HasTemplates = "HasTemplates";
        internal const string _str_Sections = "Sections";
        internal const string _str_Parameters = "Parameters";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfsFormType, _type = "Int64",
              _get_func = o => o.idfsFormType,
              _set_func = (o, val) => { o.idfsFormType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsFormType != c.idfsFormType || o.IsRIRPropChanged(_str_idfsFormType, c)) 
                  m.Add(_str_idfsFormType, o.ObjectIdent + _str_idfsFormType, "Int64", o.idfsFormType == null ? "" : o.idfsFormType.ToString(), o.IsReadOnly(_str_idfsFormType), o.IsInvisible(_str_idfsFormType), o.IsRequired(_str_idfsFormType)); }
              }, 
        
            new field_info {
              _name = _str_name, _type = "String",
              _get_func = o => o.name,
              _set_func = (o, val) => { o.name = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.name != c.name || o.IsRIRPropChanged(_str_name, c)) 
                  m.Add(_str_name, o.ObjectIdent + _str_name, "String", o.name == null ? "" : o.name.ToString(), o.IsReadOnly(_str_name), o.IsInvisible(_str_name), o.IsRequired(_str_name)); }
              }, 
        
            new field_info {
              _name = _str_LongName, _type = "String",
              _get_func = o => o.LongName,
              _set_func = (o, val) => { o.LongName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.LongName != c.LongName || o.IsRIRPropChanged(_str_LongName, c)) 
                  m.Add(_str_LongName, o.ObjectIdent + _str_LongName, "String", o.LongName == null ? "" : o.LongName.ToString(), o.IsReadOnly(_str_LongName), o.IsInvisible(_str_LongName), o.IsRequired(_str_LongName)); }
              }, 
        
            new field_info {
              _name = _str_HasParameters, _type = "Int32",
              _get_func = o => o.HasParameters,
              _set_func = (o, val) => { o.HasParameters = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.HasParameters != c.HasParameters || o.IsRIRPropChanged(_str_HasParameters, c)) 
                  m.Add(_str_HasParameters, o.ObjectIdent + _str_HasParameters, "Int32", o.HasParameters == null ? "" : o.HasParameters.ToString(), o.IsReadOnly(_str_HasParameters), o.IsInvisible(_str_HasParameters), o.IsRequired(_str_HasParameters)); }
              }, 
        
            new field_info {
              _name = _str_HasNestedSections, _type = "Int32",
              _get_func = o => o.HasNestedSections,
              _set_func = (o, val) => { o.HasNestedSections = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.HasNestedSections != c.HasNestedSections || o.IsRIRPropChanged(_str_HasNestedSections, c)) 
                  m.Add(_str_HasNestedSections, o.ObjectIdent + _str_HasNestedSections, "Int32", o.HasNestedSections == null ? "" : o.HasNestedSections.ToString(), o.IsReadOnly(_str_HasNestedSections), o.IsInvisible(_str_HasNestedSections), o.IsRequired(_str_HasNestedSections)); }
              }, 
        
            new field_info {
              _name = _str_HasTemplates, _type = "Int32",
              _get_func = o => o.HasTemplates,
              _set_func = (o, val) => { o.HasTemplates = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.HasTemplates != c.HasTemplates || o.IsRIRPropChanged(_str_HasTemplates, c)) 
                  m.Add(_str_HasTemplates, o.ObjectIdent + _str_HasTemplates, "Int32", o.HasTemplates == null ? "" : o.HasTemplates.ToString(), o.IsReadOnly(_str_HasTemplates), o.IsInvisible(_str_HasTemplates), o.IsRequired(_str_HasTemplates)); }
              }, 
        
            new field_info {
              _name = _str_Sections, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Sections.Count != c.Sections.Count || o.IsReadOnly(_str_Sections) != c.IsReadOnly(_str_Sections) || o.IsInvisible(_str_Sections) != c.IsInvisible(_str_Sections) || o.IsRequired(_str_Sections) != c.IsRequired(_str_Sections)) 
                  m.Add(_str_Sections, o.ObjectIdent + _str_Sections, "Child", o.idfsFormType == null ? "" : o.idfsFormType.ToString(), o.IsReadOnly(_str_Sections), o.IsInvisible(_str_Sections), o.IsRequired(_str_Sections)); }
              }, 
        
            new field_info {
              _name = _str_Parameters, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Parameters.Count != c.Parameters.Count || o.IsReadOnly(_str_Parameters) != c.IsReadOnly(_str_Parameters) || o.IsInvisible(_str_Parameters) != c.IsInvisible(_str_Parameters) || o.IsRequired(_str_Parameters) != c.IsRequired(_str_Parameters)) 
                  m.Add(_str_Parameters, o.ObjectIdent + _str_Parameters, "Child", o.idfsFormType == null ? "" : o.idfsFormType.ToString(), o.IsReadOnly(_str_Parameters), o.IsInvisible(_str_Parameters), o.IsRequired(_str_Parameters)); }
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
            FormType obj = (FormType)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(Section), eidss.model.Schema.Section._str_idfsFormType, _str_idfsFormType)]
        public EditableList<Section> Sections
        {
            get 
            {   
                return _Sections; 
            }
            set 
            {
                _Sections = value;
            }
        }
        protected EditableList<Section> _Sections = new EditableList<Section>();
                    
        [Relation(typeof(Parameter), eidss.model.Schema.Parameter._str_idfsFormType, _str_idfsFormType)]
        public EditableList<Parameter> Parameters
        {
            get 
            {   
                if (!_ParametersLoaded)
                {
                    _ParametersLoaded = true;
                    _getAccessor()._LoadParameters(this);
                    _Parameters.ForEach(c => { c.Parent = this; });
                }
                return _Parameters; 
            }
            set 
            {
                _Parameters = value;
            }
        }
        protected EditableList<Parameter> _Parameters = new EditableList<Parameter>();
                    
        private bool _ParametersLoaded = false;
                    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "FormType";

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
        Sections.ForEach(c => { c.Parent = this; });
                Parameters.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as FormType;
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
            var ret = base.Clone() as FormType;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public FormType CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as FormType;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsFormType; } }
        public string KeyName { get { return "idfsFormType"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || Sections.IsDirty
                    || Sections.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Parameters.IsDirty
                    || Parameters.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
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
        Sections.RejectChanges();
                Parameters.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        Sections.AcceptChanges();
                Parameters.AcceptChanges();
                
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
        Sections.ForEach(c => c.SetChange());
                Parameters.ForEach(c => c.SetChange());
                
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
          return null;
        }
      #endregion

      private bool IsRIRPropChanged(string fld, FormType c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public FormType()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(FormType_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(FormType_PropertyChanged);
        }
        private void FormType_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as FormType).Changed(e.PropertyName);
            
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
            FormType obj = this;
            
        }
        private void _DeletedExtenders()
        {
            FormType obj = this;
            
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
        
                foreach(var o in _Sections)
                    o.ReadOnly = value;
                
                foreach(var o in _Parameters)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<FormType, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<FormType, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<FormType, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<FormType, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<FormType, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<FormType, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~FormType()
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
        
            if (_Sections != null) _Sections.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Parameters != null) _Parameters.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<FormType>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(FormType obj);
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
            private Section.Accessor SectionsAccessor { get { return eidss.model.Schema.Section.Accessor.Instance(m_CS); } }
            private Parameter.Accessor ParametersAccessor { get { return eidss.model.Schema.Parameter.Accessor.Instance(m_CS); } }
            [InstanceCache(typeof(BvCacheAspect))]

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

            [InstanceCache(typeof(BvCacheAspect))]
            public virtual FormType SelectByKey(DbManagerProxy manager
                , Int64? idfsFormType
                )
            {
                return _SelectByKey(manager
                    , idfsFormType
                    , null, null
                    );
            }
            
      
            private FormType _SelectByKey(DbManagerProxy manager
                , Int64? idfsFormType
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<FormType> objs = new List<FormType>();
                sets[0] = new MapResultSet(typeof(FormType), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spFFGetFormTypes"
                            , manager.Parameter("@idfsFormType", idfsFormType)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    FormType obj = objs[0];
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
    
            private void _SetupAddChildHandlerSections(FormType obj)
            {
                obj.Sections.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerParameters(FormType obj)
            {
                obj.Parameters.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadSections(FormType obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSections(manager, obj);
                }
            }
            internal void _LoadSections(DbManagerProxy manager, FormType obj)
            {
                
                obj.Sections.Clear();
                obj.Sections.AddRange(SectionsAccessor.SelectDetailList(manager
                    
                    , new Func<FormType, Int64?>(c => c.idfsFormType)(obj)
                    
                    , new Func<FormType, Int64?>(c => null)(obj)
                    
                    , new Func<FormType, Int64?>(c => null)(obj)
                    
                    ));
                obj.Sections.ForEach(c => c.m_ObjectName = _str_Sections);
                obj.Sections.AcceptChanges();
                    
            }
            
            internal void _LoadParameters(FormType obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadParameters(manager, obj);
                }
            }
            internal void _LoadParameters(DbManagerProxy manager, FormType obj)
            {
                
                obj.Parameters.Clear();
                obj.Parameters.AddRange(ParametersAccessor.SelectDetailList(manager
                    
                    , new Func<FormType, Int64?>(c => null)(obj)
                    
                    , new Func<FormType, Int64?>(c => c.idfsFormType)(obj)
                    
                    ));
                obj.Parameters.ForEach(c => c.m_ObjectName = _str_Parameters);
                obj.Parameters.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, FormType obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadSections(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerSections(obj);
                
                _SetupAddChildHandlerParameters(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, FormType obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.Sections.ForEach(c => SectionsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Parameters.ForEach(c => ParametersAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private FormType _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    FormType obj = FormType.CreateInstance();
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
                    
                    _SetupAddChildHandlerSections(obj);
                    
                    _SetupAddChildHandlerParameters(obj);
                    
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

            
            public FormType CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public FormType CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(FormType obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(FormType obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, FormType obj)
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
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as FormType, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, FormType obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(FormType obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(FormType obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as FormType) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as FormType) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "FormTypeDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFFGetFormTypes";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<FormType, bool>> RequiredByField = new Dictionary<string, Func<FormType, bool>>();
            public static Dictionary<string, Func<FormType, bool>> RequiredByProperty = new Dictionary<string, Func<FormType, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_name, 2000);
                Sizes.Add(_str_LongName, 2000);
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
                    (manager, c, pars) => new ActResult(((FormType)c).MarkToDelete() && ObjectAccessor.PostInterface<FormType>().Post(manager, (FormType)c), c),
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
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<FormType>().Post(manager, (FormType)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<FormType>().Post(manager, (FormType)c), c),
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
	