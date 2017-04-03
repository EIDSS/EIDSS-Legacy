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
    public abstract partial class PredefinedStub : 
        EditableObject<PredefinedStub>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfVersion), NonUpdatable, PrimaryKey]
        public abstract Int64? idfVersion { get; set; }
                
        [LocalizedDisplayName(_str_idfRow)]
        [MapField(_str_idfRow)]
        public abstract Int64? idfRow { get; set; }
        #if MONO
        protected Int64? idfRow_Original { get { return idfRow; } }
        protected Int64? idfRow_Previous { get { return idfRow; } }
        #else
        protected Int64? idfRow_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRow).OriginalValue; } }
        protected Int64? idfRow_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRow).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsParameter)]
        [MapField(_str_idfsParameter)]
        public abstract Int64? idfsParameter { get; set; }
        #if MONO
        protected Int64? idfsParameter_Original { get { return idfsParameter; } }
        protected Int64? idfsParameter_Previous { get { return idfsParameter; } }
        #else
        protected Int64? idfsParameter_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParameter).OriginalValue; } }
        protected Int64? idfsParameter_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParameter).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strDefaultParameterName)]
        [MapField(_str_strDefaultParameterName)]
        public abstract String strDefaultParameterName { get; set; }
        #if MONO
        protected String strDefaultParameterName_Original { get { return strDefaultParameterName; } }
        protected String strDefaultParameterName_Previous { get { return strDefaultParameterName; } }
        #else
        protected String strDefaultParameterName_Original { get { return ((EditableValue<String>)((dynamic)this)._strDefaultParameterName).OriginalValue; } }
        protected String strDefaultParameterName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDefaultParameterName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsParameterValue)]
        [MapField(_str_idfsParameterValue)]
        public abstract Object idfsParameterValue { get; set; }
        #if MONO
        protected Object idfsParameterValue_Original { get { return idfsParameterValue; } }
        protected Object idfsParameterValue_Previous { get { return idfsParameterValue; } }
        #else
        protected Object idfsParameterValue_Original { get { return ((EditableValue<Object>)((dynamic)this)._idfsParameterValue).OriginalValue; } }
        protected Object idfsParameterValue_Previous { get { return ((EditableValue<Object>)((dynamic)this)._idfsParameterValue).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_NumRow)]
        [MapField(_str_NumRow)]
        public abstract Int32? NumRow { get; set; }
        #if MONO
        protected Int32? NumRow_Original { get { return NumRow; } }
        protected Int32? NumRow_Previous { get { return NumRow; } }
        #else
        protected Int32? NumRow_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._numRow).OriginalValue; } }
        protected Int32? NumRow_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._numRow).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_langid)]
        [MapField(_str_langid)]
        public abstract String langid { get; set; }
        #if MONO
        protected String langid_Original { get { return langid; } }
        protected String langid_Previous { get { return langid; } }
        #else
        protected String langid_Original { get { return ((EditableValue<String>)((dynamic)this)._langid).OriginalValue; } }
        protected String langid_Previous { get { return ((EditableValue<String>)((dynamic)this)._langid).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<PredefinedStub, object> _get_func;
            internal Action<PredefinedStub, string> _set_func;
            internal Action<PredefinedStub, PredefinedStub, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfVersion = "idfVersion";
        internal const string _str_idfRow = "idfRow";
        internal const string _str_idfsParameter = "idfsParameter";
        internal const string _str_strDefaultParameterName = "strDefaultParameterName";
        internal const string _str_idfsParameterValue = "idfsParameterValue";
        internal const string _str_NumRow = "NumRow";
        internal const string _str_strNameValue = "strNameValue";
        internal const string _str_idfsSection = "idfsSection";
        internal const string _str_langid = "langid";
        internal const string _str_intOrder = "intOrder";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfVersion, _type = "Int64?",
              _get_func = o => o.idfVersion,
              _set_func = (o, val) => { o.idfVersion = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVersion != c.idfVersion || o.IsRIRPropChanged(_str_idfVersion, c)) 
                  m.Add(_str_idfVersion, o.ObjectIdent + _str_idfVersion, "Int64?", o.idfVersion == null ? "" : o.idfVersion.ToString(), o.IsReadOnly(_str_idfVersion), o.IsInvisible(_str_idfVersion), o.IsRequired(_str_idfVersion)); }
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
              _name = _str_idfsParameter, _type = "Int64?",
              _get_func = o => o.idfsParameter,
              _set_func = (o, val) => { o.idfsParameter = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsParameter != c.idfsParameter || o.IsRIRPropChanged(_str_idfsParameter, c)) 
                  m.Add(_str_idfsParameter, o.ObjectIdent + _str_idfsParameter, "Int64?", o.idfsParameter == null ? "" : o.idfsParameter.ToString(), o.IsReadOnly(_str_idfsParameter), o.IsInvisible(_str_idfsParameter), o.IsRequired(_str_idfsParameter)); }
              }, 
        
            new field_info {
              _name = _str_strDefaultParameterName, _type = "String",
              _get_func = o => o.strDefaultParameterName,
              _set_func = (o, val) => { o.strDefaultParameterName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strDefaultParameterName != c.strDefaultParameterName || o.IsRIRPropChanged(_str_strDefaultParameterName, c)) 
                  m.Add(_str_strDefaultParameterName, o.ObjectIdent + _str_strDefaultParameterName, "String", o.strDefaultParameterName == null ? "" : o.strDefaultParameterName.ToString(), o.IsReadOnly(_str_strDefaultParameterName), o.IsInvisible(_str_strDefaultParameterName), o.IsRequired(_str_strDefaultParameterName)); }
              }, 
        
            new field_info {
              _name = _str_idfsParameterValue, _type = "Object",
              _get_func = o => o.idfsParameterValue,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
                if (o.idfsParameterValue != c.idfsParameterValue || o.IsRIRPropChanged(_str_idfsParameterValue, c)) 
                  m.Add(_str_idfsParameterValue, o.ObjectIdent + _str_idfsParameterValue, "Object", o.idfsParameterValue == null ? "" : o.idfsParameterValue.ToString(), o.IsReadOnly(_str_idfsParameterValue), o.IsInvisible(_str_idfsParameterValue), o.IsRequired(_str_idfsParameterValue)); }
              }, 
        
            new field_info {
              _name = _str_NumRow, _type = "Int32?",
              _get_func = o => o.NumRow,
              _set_func = (o, val) => { o.NumRow = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.NumRow != c.NumRow || o.IsRIRPropChanged(_str_NumRow, c)) 
                  m.Add(_str_NumRow, o.ObjectIdent + _str_NumRow, "Int32?", o.NumRow == null ? "" : o.NumRow.ToString(), o.IsReadOnly(_str_NumRow), o.IsInvisible(_str_NumRow), o.IsRequired(_str_NumRow)); }
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
              _name = _str_idfsSection, _type = "Int64?",
              _get_func = o => o.idfsSection,
              _set_func = (o, val) => { o.idfsSection = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSection != c.idfsSection || o.IsRIRPropChanged(_str_idfsSection, c)) 
                  m.Add(_str_idfsSection, o.ObjectIdent + _str_idfsSection, "Int64?", o.idfsSection == null ? "" : o.idfsSection.ToString(), o.IsReadOnly(_str_idfsSection), o.IsInvisible(_str_idfsSection), o.IsRequired(_str_idfsSection)); }
              }, 
        
            new field_info {
              _name = _str_langid, _type = "String",
              _get_func = o => o.langid,
              _set_func = (o, val) => { o.langid = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.langid != c.langid || o.IsRIRPropChanged(_str_langid, c)) 
                  m.Add(_str_langid, o.ObjectIdent + _str_langid, "String", o.langid == null ? "" : o.langid.ToString(), o.IsReadOnly(_str_langid), o.IsInvisible(_str_langid), o.IsRequired(_str_langid)); }
              }, 
        
            new field_info {
              _name = _str_intOrder, _type = "int",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { o.intOrder = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
              
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, "int", o.intOrder == null ? "" : o.intOrder.ToString(), o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder));
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
            PredefinedStub obj = (PredefinedStub)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
          [LocalizedDisplayName(_str_intOrder)]
        public int intOrder
        {
            get { return m_intOrder; }
            set { if (m_intOrder != value) { m_intOrder = value; OnPropertyChanged(_str_intOrder); } }
        }
        private int m_intOrder;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "PredefinedStub";

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
            var ret = base.Clone() as PredefinedStub;
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
            var ret = base.Clone() as PredefinedStub;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public PredefinedStub CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as PredefinedStub;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfVersion; } }
        public string KeyName { get { return "idfVersion"; } }
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

      private bool IsRIRPropChanged(string fld, PredefinedStub c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public PredefinedStub()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(PredefinedStub_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(PredefinedStub_PropertyChanged);
        }
        private void PredefinedStub_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as PredefinedStub).Changed(e.PropertyName);
            
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
            PredefinedStub obj = this;
            
        }
        private void _DeletedExtenders()
        {
            PredefinedStub obj = this;
            
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


        public Dictionary<string, Func<PredefinedStub, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<PredefinedStub, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<PredefinedStub, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<PredefinedStub, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<PredefinedStub, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<PredefinedStub, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~PredefinedStub()
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
        : DataAccessor<PredefinedStub>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectPost
                    
        {
            private delegate void on_action(PredefinedStub obj);
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
            
            public virtual List<PredefinedStub> SelectList(DbManagerProxy manager
                , Int64? MatrixID
                , String VersionList
                )
            {
                return _SelectList(manager
                    , MatrixID
                    , VersionList
                    , delegate(PredefinedStub obj)
                        {
                        }
                    , delegate(PredefinedStub obj)
                        {
                        }
                    );
            }

            
            public List<PredefinedStub> SelectDetailListT(DbManagerProxy manager, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 2) 
                    throw new ParamsCountException();
                
                if (!(pars[0] is Int64?)) 
                    throw new TypeMismatchException("MatrixID", typeof(Int64?));
                
                if (!(pars[1] is String)) 
                    throw new TypeMismatchException("VersionList", typeof(String));
                
                return SelectDetailList(manager
                    
                    , (Int64?)pars[0]
                    
                    , (String)pars[1]
                    
                    );
            }
            public List<PredefinedStub> SelectDetailList(DbManagerProxy manager, List<object> pars)
            {
                return SelectDetailListT(manager, pars);
            }
            public virtual List<PredefinedStub> SelectDetailList(DbManagerProxy manager
                , Int64? MatrixID
                , String VersionList
                )
            {
                return _SelectList(manager
                    , MatrixID
                    , VersionList
                    , delegate(PredefinedStub obj)
                        {
                
                        }
                    , delegate(PredefinedStub obj)
                        {
                
                        }
                    );
            }
            
            private List<PredefinedStub> _SelectList(DbManagerProxy manager
                , Int64? MatrixID
                , String VersionList
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<PredefinedStub> objs = new List<PredefinedStub>();
                    sets[0] = new MapResultSet(typeof(PredefinedStub), objs);
                    
                    manager
                        .SetSpCommand("spFFGetPredefinedStub"
                            , manager.Parameter("@MatrixID", MatrixID)
                            , manager.Parameter("@VersionList", VersionList)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, PredefinedStub obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, PredefinedStub obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private PredefinedStub _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    PredefinedStub obj = PredefinedStub.CreateInstance();
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

            
            public PredefinedStub CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public PredefinedStub CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public PredefinedStub CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 2) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("MatrixID", typeof(long));
                if (pars[1] != null && !(pars[1] is string)) 
                    throw new TypeMismatchException("VersionList", typeof(string));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    , (string)pars[1]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public PredefinedStub Create(DbManagerProxy manager, IObject Parent
                , long MatrixID
                , string VersionList
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(PredefinedStub obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(PredefinedStub obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, PredefinedStub obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as PredefinedStub, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, PredefinedStub obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(PredefinedStub obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(PredefinedStub obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as PredefinedStub) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as PredefinedStub) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "PredefinedStubDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFFGetPredefinedStub";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<PredefinedStub, bool>> RequiredByField = new Dictionary<string, Func<PredefinedStub, bool>>();
            public static Dictionary<string, Func<PredefinedStub, bool>> RequiredByProperty = new Dictionary<string, Func<PredefinedStub, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strDefaultParameterName, 400);
                Sizes.Add(_str_strNameValue, 200);
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
                    false
                    ));
                
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
                    (manager, c, pars) => new ActResult(((PredefinedStub)c).MarkToDelete() && ObjectAccessor.PostInterface<PredefinedStub>().Post(manager, (PredefinedStub)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<PredefinedStub>().Post(manager, (PredefinedStub)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<PredefinedStub>().Post(manager, (PredefinedStub)c), c),
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
	