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
    public abstract partial class ActivityParameter : 
        EditableObject<ActivityParameter>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfObservation), NonUpdatable, PrimaryKey]
        public abstract Int64? idfObservation { get; set; }
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64? idfsFormTemplate { get; set; }
        #if MONO
        protected Int64? idfsFormTemplate_Original { get { return idfsFormTemplate; } }
        protected Int64? idfsFormTemplate_Previous { get { return idfsFormTemplate; } }
        #else
        protected Int64? idfsFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64? idfsFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
        #endif
                
        [MapField(_str_idfsParameter), NonUpdatable, PrimaryKey]
        public abstract Int64? idfsParameter { get; set; }
                
        [LocalizedDisplayName(_str_idfsSection)]
        [MapField(_str_idfsSection)]
        public abstract Int64? idfsSection { get; set; }
        #if MONO
        protected Int64? idfsSection_Original { get { return idfsSection; } }
        protected Int64? idfsSection_Previous { get { return idfsSection; } }
        #else
        protected Int64? idfsSection_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSection).OriginalValue; } }
        protected Int64? idfsSection_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSection).PreviousValue; } }
        #endif
                
        [MapField(_str_idfRow), NonUpdatable, PrimaryKey]
        public abstract Int64? idfRow { get; set; }
                
        [LocalizedDisplayName(_str_intNumRow)]
        [MapField(_str_intNumRow)]
        public abstract Int32? intNumRow { get; set; }
        #if MONO
        protected Int32? intNumRow_Original { get { return intNumRow; } }
        protected Int32? intNumRow_Previous { get { return intNumRow; } }
        #else
        protected Int32? intNumRow_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intNumRow).OriginalValue; } }
        protected Int32? intNumRow_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intNumRow).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_Type)]
        [MapField(_str_Type)]
        public abstract Int64? Type { get; set; }
        #if MONO
        protected Int64? Type_Original { get { return Type; } }
        protected Int64? Type_Previous { get { return Type; } }
        #else
        protected Int64? Type_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._type).OriginalValue; } }
        protected Int64? Type_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._type).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_varValue)]
        [MapField(_str_varValue)]
        public abstract Object varValue { get; set; }
        #if MONO
        protected Object varValue_Original { get { return varValue; } }
        protected Object varValue_Previous { get { return varValue; } }
        #else
        protected Object varValue_Original { get { return ((EditableValue<Object>)((dynamic)this)._varValue).OriginalValue; } }
        protected Object varValue_Previous { get { return ((EditableValue<Object>)((dynamic)this)._varValue).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strNameValue)]
        [MapField(_str_strNameValue)]
        public abstract String strNameValue { get; set; }
        #if MONO
        protected String strNameValue_Original { get { return strNameValue; } }
        protected String strNameValue_Previous { get { return strNameValue; } }
        #else
        protected String strNameValue_Original { get { return ((EditableValue<String>)((dynamic)this)._strNameValue).OriginalValue; } }
        protected String strNameValue_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNameValue).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_numRow)]
        [MapField(_str_numRow)]
        public abstract Int32? numRow { get; set; }
        #if MONO
        protected Int32? numRow_Original { get { return numRow; } }
        protected Int32? numRow_Previous { get { return numRow; } }
        #else
        protected Int32? numRow_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._numRow).OriginalValue; } }
        protected Int32? numRow_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._numRow).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_FakeField)]
        [MapField(_str_FakeField)]
        public abstract Int32 FakeField { get; set; }
        #if MONO
        protected Int32 FakeField_Original { get { return FakeField; } }
        protected Int32 FakeField_Previous { get { return FakeField; } }
        #else
        protected Int32 FakeField_Original { get { return ((EditableValue<Int32>)((dynamic)this)._fakeField).OriginalValue; } }
        protected Int32 FakeField_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._fakeField).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<ActivityParameter, object> _get_func;
            internal Action<ActivityParameter, string> _set_func;
            internal Action<ActivityParameter, ActivityParameter, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfObservation = "idfObservation";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_idfsParameter = "idfsParameter";
        internal const string _str_idfsSection = "idfsSection";
        internal const string _str_idfRow = "idfRow";
        internal const string _str_intNumRow = "intNumRow";
        internal const string _str_Type = "Type";
        internal const string _str_varValue = "varValue";
        internal const string _str_strNameValue = "strNameValue";
        internal const string _str_numRow = "numRow";
        internal const string _str_FakeField = "FakeField";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfObservation, _type = "Int64?",
              _get_func = o => o.idfObservation,
              _set_func = (o, val) => { o.idfObservation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfObservation != c.idfObservation || o.IsRIRPropChanged(_str_idfObservation, c)) 
                  m.Add(_str_idfObservation, o.ObjectIdent + _str_idfObservation, "Int64?", o.idfObservation == null ? "" : o.idfObservation.ToString(), o.IsReadOnly(_str_idfObservation), o.IsInvisible(_str_idfObservation), o.IsRequired(_str_idfObservation)); }
              }, 
        
            new field_info {
              _name = _str_idfsFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { o.idfsFormTemplate = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, "Int64?", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); }
              }, 
        
            new field_info {
              _name = _str_idfsParameter, _type = "Int64?",
              _get_func = o => o.idfsParameter,
              _set_func = (o, val) => { o.idfsParameter = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsParameter != c.idfsParameter || o.IsRIRPropChanged(_str_idfsParameter, c)) 
                  m.Add(_str_idfsParameter, o.ObjectIdent + _str_idfsParameter, "Int64?", o.idfsParameter == null ? "" : o.idfsParameter.ToString(), o.IsReadOnly(_str_idfsParameter), o.IsInvisible(_str_idfsParameter), o.IsRequired(_str_idfsParameter)); }
              }, 
        
            new field_info {
              _name = _str_idfsSection, _type = "Int64?",
              _get_func = o => o.idfsSection,
              _set_func = (o, val) => { o.idfsSection = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSection != c.idfsSection || o.IsRIRPropChanged(_str_idfsSection, c)) 
                  m.Add(_str_idfsSection, o.ObjectIdent + _str_idfsSection, "Int64?", o.idfsSection == null ? "" : o.idfsSection.ToString(), o.IsReadOnly(_str_idfsSection), o.IsInvisible(_str_idfsSection), o.IsRequired(_str_idfsSection)); }
              }, 
        
            new field_info {
              _name = _str_idfRow, _type = "Int64?",
              _get_func = o => o.idfRow,
              _set_func = (o, val) => { o.idfRow = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfRow != c.idfRow || o.IsRIRPropChanged(_str_idfRow, c)) 
                  m.Add(_str_idfRow, o.ObjectIdent + _str_idfRow, "Int64?", o.idfRow == null ? "" : o.idfRow.ToString(), o.IsReadOnly(_str_idfRow), o.IsInvisible(_str_idfRow), o.IsRequired(_str_idfRow)); }
              }, 
        
            new field_info {
              _name = _str_intNumRow, _type = "Int32?",
              _get_func = o => o.intNumRow,
              _set_func = (o, val) => { o.intNumRow = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intNumRow != c.intNumRow || o.IsRIRPropChanged(_str_intNumRow, c)) 
                  m.Add(_str_intNumRow, o.ObjectIdent + _str_intNumRow, "Int32?", o.intNumRow == null ? "" : o.intNumRow.ToString(), o.IsReadOnly(_str_intNumRow), o.IsInvisible(_str_intNumRow), o.IsRequired(_str_intNumRow)); }
              }, 
        
            new field_info {
              _name = _str_Type, _type = "Int64?",
              _get_func = o => o.Type,
              _set_func = (o, val) => { o.Type = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.Type != c.Type || o.IsRIRPropChanged(_str_Type, c)) 
                  m.Add(_str_Type, o.ObjectIdent + _str_Type, "Int64?", o.Type == null ? "" : o.Type.ToString(), o.IsReadOnly(_str_Type), o.IsInvisible(_str_Type), o.IsRequired(_str_Type)); }
              }, 
        
            new field_info {
              _name = _str_varValue, _type = "Object",
              _get_func = o => o.varValue,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
                if (o.varValue != c.varValue || o.IsRIRPropChanged(_str_varValue, c)) 
                  m.Add(_str_varValue, o.ObjectIdent + _str_varValue, "Object", o.varValue == null ? "" : o.varValue.ToString(), o.IsReadOnly(_str_varValue), o.IsInvisible(_str_varValue), o.IsRequired(_str_varValue)); }
              }, 
        
            new field_info {
              _name = _str_strNameValue, _type = "String",
              _get_func = o => o.strNameValue,
              _set_func = (o, val) => { o.strNameValue = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNameValue != c.strNameValue || o.IsRIRPropChanged(_str_strNameValue, c)) 
                  m.Add(_str_strNameValue, o.ObjectIdent + _str_strNameValue, "String", o.strNameValue == null ? "" : o.strNameValue.ToString(), o.IsReadOnly(_str_strNameValue), o.IsInvisible(_str_strNameValue), o.IsRequired(_str_strNameValue)); }
              }, 
        
            new field_info {
              _name = _str_numRow, _type = "Int32?",
              _get_func = o => o.numRow,
              _set_func = (o, val) => { o.numRow = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.numRow != c.numRow || o.IsRIRPropChanged(_str_numRow, c)) 
                  m.Add(_str_numRow, o.ObjectIdent + _str_numRow, "Int32?", o.numRow == null ? "" : o.numRow.ToString(), o.IsReadOnly(_str_numRow), o.IsInvisible(_str_numRow), o.IsRequired(_str_numRow)); }
              }, 
        
            new field_info {
              _name = _str_FakeField, _type = "Int32",
              _get_func = o => o.FakeField,
              _set_func = (o, val) => { o.FakeField = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.FakeField != c.FakeField || o.IsRIRPropChanged(_str_FakeField, c)) 
                  m.Add(_str_FakeField, o.ObjectIdent + _str_FakeField, "Int32", o.FakeField == null ? "" : o.FakeField.ToString(), o.IsReadOnly(_str_FakeField), o.IsInvisible(_str_FakeField), o.IsRequired(_str_FakeField)); }
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
            ActivityParameter obj = (ActivityParameter)o;
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
        internal string m_ObjectName = "ActivityParameter";

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
            var ret = base.Clone() as ActivityParameter;
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
            var ret = base.Clone() as ActivityParameter;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public ActivityParameter CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as ActivityParameter;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsParameter; } }
        public string KeyName { get { return "idfsParameter"; } }
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
          return null;
        }
      #endregion

      private bool IsRIRPropChanged(string fld, ActivityParameter c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public ActivityParameter()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ActivityParameter_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(ActivityParameter_PropertyChanged);
        }
        private void ActivityParameter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as ActivityParameter).Changed(e.PropertyName);
            
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
            ActivityParameter obj = this;
            
        }
        private void _DeletedExtenders()
        {
            ActivityParameter obj = this;
            
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


        public Dictionary<string, Func<ActivityParameter, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<ActivityParameter, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<ActivityParameter, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<ActivityParameter, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<ActivityParameter, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<ActivityParameter, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~ActivityParameter()
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
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<ActivityParameter>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(ActivityParameter obj);
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
                    , (String)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<ActivityParameter> SelectList(DbManagerProxy manager
                , String observationList
                )
            {
                return _SelectList(manager
                    , observationList
                    , delegate(ActivityParameter obj)
                        {
                        }
                    , delegate(ActivityParameter obj)
                        {
                        }
                    );
            }

            
            private List<ActivityParameter> _SelectList(DbManagerProxy manager
                , String observationList
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<ActivityParameter> objs = new List<ActivityParameter>();
                    sets[0] = new MapResultSet(typeof(ActivityParameter), objs);
                    
                    manager
                        .SetSpCommand("spFFGetActivityParameters"
                            , manager.Parameter("@observationList", observationList)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, ActivityParameter obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, ActivityParameter obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private ActivityParameter _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    ActivityParameter obj = ActivityParameter.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfRow = new Func<ActivityParameter, long>(c => -1)(obj);
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

            
            public ActivityParameter CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public ActivityParameter CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActivityParameter CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfsParameter", typeof(long));
                if (pars[1] != null && !(pars[1] is long)) 
                    throw new TypeMismatchException("idfObservation", typeof(long));
                if (pars[2] != null && !(pars[2] is long)) 
                    throw new TypeMismatchException("idfsFormTemplate", typeof(long));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    , (long)pars[1]
                    , (long)pars[2]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public ActivityParameter Create(DbManagerProxy manager, IObject Parent
                , long idfsParameter
                , long idfObservation
                , long idfsFormTemplate
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfsParameter = new Func<ActivityParameter, long>(c => idfsParameter)(obj);
                obj.idfObservation = new Func<ActivityParameter, long>(c => idfObservation)(obj);
                obj.idfsFormTemplate = new Func<ActivityParameter, long>(c => idfsFormTemplate)(obj);
                obj.intNumRow = new Func<ActivityParameter, int?>(c => 0)(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(ActivityParameter obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(ActivityParameter obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, ActivityParameter obj)
            {
                
            }
    
            [SprocName("spFFRemoveActivityParameters")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? idfsParameter
                , Int64? idfObservation
                , Int64? idfRow
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? idfsParameter
                , Int64? idfObservation
                , Int64? idfRow
                )
            {
                
                _postDelete(manager, idfsParameter, idfObservation, idfRow);
                
            }
        
            [SprocName("spFFSaveActivityParameters")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput("idfRow", "idfActivityParameters")] ActivityParameter obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput("idfRow", "idfActivityParameters")] ActivityParameter obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    ActivityParameter bo = obj as ActivityParameter;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as ActivityParameter, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, ActivityParameter obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfsParameter
                        , obj.idfObservation
                        , obj.idfRow
                        );
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (!obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(ActivityParameter obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, ActivityParameter obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as ActivityParameter, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, ActivityParameter obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(ActivityParameter obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(ActivityParameter obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as ActivityParameter) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as ActivityParameter) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "ActivityParameterDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFFGetActivityParameters";
            public static string spCount = "";
            public static string spPost = "spFFSaveActivityParameters";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spFFRemoveActivityParameters";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<ActivityParameter, bool>> RequiredByField = new Dictionary<string, Func<ActivityParameter, bool>>();
            public static Dictionary<string, Func<ActivityParameter, bool>> RequiredByProperty = new Dictionary<string, Func<ActivityParameter, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strNameValue, 200);
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).Create(manager, c, pars)),
                        
                    null,
                    
                    null,
                      false,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false
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
                    (manager, c, pars) => ((ActivityParameter)c).MarkToDelete(),
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
	