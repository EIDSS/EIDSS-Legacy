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
    public abstract partial class DiagnosisAgeGroup : 
        EditableObject<DiagnosisAgeGroup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsDiagnosisAgeGroup), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsDiagnosisAgeGroup { get; set; }
                
        [LocalizedDisplayName(_str_DiagnosisAgeGroupName)]
        [MapField(_str_DiagnosisAgeGroupName)]
        public abstract String DiagnosisAgeGroupName { get; set; }
        #if MONO
        protected String DiagnosisAgeGroupName_Original { get { return DiagnosisAgeGroupName; } }
        protected String DiagnosisAgeGroupName_Previous { get { return DiagnosisAgeGroupName; } }
        #else
        protected String DiagnosisAgeGroupName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisAgeGroupName).OriginalValue; } }
        protected String DiagnosisAgeGroupName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisAgeGroupName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_DiagnosisAgeGroupNameTranslated)]
        [MapField(_str_DiagnosisAgeGroupNameTranslated)]
        public abstract String DiagnosisAgeGroupNameTranslated { get; set; }
        #if MONO
        protected String DiagnosisAgeGroupNameTranslated_Original { get { return DiagnosisAgeGroupNameTranslated; } }
        protected String DiagnosisAgeGroupNameTranslated_Previous { get { return DiagnosisAgeGroupNameTranslated; } }
        #else
        protected String DiagnosisAgeGroupNameTranslated_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisAgeGroupNameTranslated).OriginalValue; } }
        protected String DiagnosisAgeGroupNameTranslated_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisAgeGroupNameTranslated).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32 intOrder { get; set; }
        #if MONO
        protected Int32 intOrder_Original { get { return intOrder; } }
        protected Int32 intOrder_Previous { get { return intOrder; } }
        #else
        protected Int32 intOrder_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32 intOrder_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intLowerBoundary)]
        [MapField(_str_intLowerBoundary)]
        public abstract Int32 intLowerBoundary { get; set; }
        #if MONO
        protected Int32 intLowerBoundary_Original { get { return intLowerBoundary; } }
        protected Int32 intLowerBoundary_Previous { get { return intLowerBoundary; } }
        #else
        protected Int32 intLowerBoundary_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intLowerBoundary).OriginalValue; } }
        protected Int32 intLowerBoundary_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intLowerBoundary).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intUpperBoundary)]
        [MapField(_str_intUpperBoundary)]
        public abstract Int32? intUpperBoundary { get; set; }
        #if MONO
        protected Int32? intUpperBoundary_Original { get { return intUpperBoundary; } }
        protected Int32? intUpperBoundary_Previous { get { return intUpperBoundary; } }
        #else
        protected Int32? intUpperBoundary_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intUpperBoundary).OriginalValue; } }
        protected Int32? intUpperBoundary_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intUpperBoundary).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsAgeType)]
        [MapField(_str_idfsAgeType)]
        public abstract Int64 idfsAgeType { get; set; }
        #if MONO
        protected Int64 idfsAgeType_Original { get { return idfsAgeType; } }
        protected Int64 idfsAgeType_Previous { get { return idfsAgeType; } }
        #else
        protected Int64 idfsAgeType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAgeType).OriginalValue; } }
        protected Int64 idfsAgeType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAgeType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_AgeTypeName)]
        [MapField(_str_AgeTypeName)]
        public abstract String AgeTypeName { get; set; }
        #if MONO
        protected String AgeTypeName_Original { get { return AgeTypeName; } }
        protected String AgeTypeName_Previous { get { return AgeTypeName; } }
        #else
        protected String AgeTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._ageTypeName).OriginalValue; } }
        protected String AgeTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._ageTypeName).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<DiagnosisAgeGroup, object> _get_func;
            internal Action<DiagnosisAgeGroup, string> _set_func;
            internal Action<DiagnosisAgeGroup, DiagnosisAgeGroup, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsDiagnosisAgeGroup = "idfsDiagnosisAgeGroup";
        internal const string _str_DiagnosisAgeGroupName = "DiagnosisAgeGroupName";
        internal const string _str_DiagnosisAgeGroupNameTranslated = "DiagnosisAgeGroupNameTranslated";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_intLowerBoundary = "intLowerBoundary";
        internal const string _str_intUpperBoundary = "intUpperBoundary";
        internal const string _str_idfsAgeType = "idfsAgeType";
        internal const string _str_AgeTypeName = "AgeTypeName";
        internal const string _str_AgeType = "AgeType";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfsDiagnosisAgeGroup, _type = "Int64",
              _get_func = o => o.idfsDiagnosisAgeGroup,
              _set_func = (o, val) => { o.idfsDiagnosisAgeGroup = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosisAgeGroup != c.idfsDiagnosisAgeGroup || o.IsRIRPropChanged(_str_idfsDiagnosisAgeGroup, c)) 
                  m.Add(_str_idfsDiagnosisAgeGroup, o.ObjectIdent + _str_idfsDiagnosisAgeGroup, "Int64", o.idfsDiagnosisAgeGroup == null ? "" : o.idfsDiagnosisAgeGroup.ToString(), o.IsReadOnly(_str_idfsDiagnosisAgeGroup), o.IsInvisible(_str_idfsDiagnosisAgeGroup), o.IsRequired(_str_idfsDiagnosisAgeGroup)); }
              }, 
        
            new field_info {
              _name = _str_DiagnosisAgeGroupName, _type = "String",
              _get_func = o => o.DiagnosisAgeGroupName,
              _set_func = (o, val) => { o.DiagnosisAgeGroupName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.DiagnosisAgeGroupName != c.DiagnosisAgeGroupName || o.IsRIRPropChanged(_str_DiagnosisAgeGroupName, c)) 
                  m.Add(_str_DiagnosisAgeGroupName, o.ObjectIdent + _str_DiagnosisAgeGroupName, "String", o.DiagnosisAgeGroupName == null ? "" : o.DiagnosisAgeGroupName.ToString(), o.IsReadOnly(_str_DiagnosisAgeGroupName), o.IsInvisible(_str_DiagnosisAgeGroupName), o.IsRequired(_str_DiagnosisAgeGroupName)); }
              }, 
        
            new field_info {
              _name = _str_DiagnosisAgeGroupNameTranslated, _type = "String",
              _get_func = o => o.DiagnosisAgeGroupNameTranslated,
              _set_func = (o, val) => { o.DiagnosisAgeGroupNameTranslated = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.DiagnosisAgeGroupNameTranslated != c.DiagnosisAgeGroupNameTranslated || o.IsRIRPropChanged(_str_DiagnosisAgeGroupNameTranslated, c)) 
                  m.Add(_str_DiagnosisAgeGroupNameTranslated, o.ObjectIdent + _str_DiagnosisAgeGroupNameTranslated, "String", o.DiagnosisAgeGroupNameTranslated == null ? "" : o.DiagnosisAgeGroupNameTranslated.ToString(), o.IsReadOnly(_str_DiagnosisAgeGroupNameTranslated), o.IsInvisible(_str_DiagnosisAgeGroupNameTranslated), o.IsRequired(_str_DiagnosisAgeGroupNameTranslated)); }
              }, 
        
            new field_info {
              _name = _str_intOrder, _type = "Int32",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { o.intOrder = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, "Int32", o.intOrder == null ? "" : o.intOrder.ToString(), o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); }
              }, 
        
            new field_info {
              _name = _str_intLowerBoundary, _type = "Int32",
              _get_func = o => o.intLowerBoundary,
              _set_func = (o, val) => { o.intLowerBoundary = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intLowerBoundary != c.intLowerBoundary || o.IsRIRPropChanged(_str_intLowerBoundary, c)) 
                  m.Add(_str_intLowerBoundary, o.ObjectIdent + _str_intLowerBoundary, "Int32", o.intLowerBoundary == null ? "" : o.intLowerBoundary.ToString(), o.IsReadOnly(_str_intLowerBoundary), o.IsInvisible(_str_intLowerBoundary), o.IsRequired(_str_intLowerBoundary)); }
              }, 
        
            new field_info {
              _name = _str_intUpperBoundary, _type = "Int32?",
              _get_func = o => o.intUpperBoundary,
              _set_func = (o, val) => { o.intUpperBoundary = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intUpperBoundary != c.intUpperBoundary || o.IsRIRPropChanged(_str_intUpperBoundary, c)) 
                  m.Add(_str_intUpperBoundary, o.ObjectIdent + _str_intUpperBoundary, "Int32?", o.intUpperBoundary == null ? "" : o.intUpperBoundary.ToString(), o.IsReadOnly(_str_intUpperBoundary), o.IsInvisible(_str_intUpperBoundary), o.IsRequired(_str_intUpperBoundary)); }
              }, 
        
            new field_info {
              _name = _str_idfsAgeType, _type = "Int64",
              _get_func = o => o.idfsAgeType,
              _set_func = (o, val) => { o.idfsAgeType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsAgeType != c.idfsAgeType || o.IsRIRPropChanged(_str_idfsAgeType, c)) 
                  m.Add(_str_idfsAgeType, o.ObjectIdent + _str_idfsAgeType, "Int64", o.idfsAgeType == null ? "" : o.idfsAgeType.ToString(), o.IsReadOnly(_str_idfsAgeType), o.IsInvisible(_str_idfsAgeType), o.IsRequired(_str_idfsAgeType)); }
              }, 
        
            new field_info {
              _name = _str_AgeTypeName, _type = "String",
              _get_func = o => o.AgeTypeName,
              _set_func = (o, val) => { o.AgeTypeName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.AgeTypeName != c.AgeTypeName || o.IsRIRPropChanged(_str_AgeTypeName, c)) 
                  m.Add(_str_AgeTypeName, o.ObjectIdent + _str_AgeTypeName, "String", o.AgeTypeName == null ? "" : o.AgeTypeName.ToString(), o.IsReadOnly(_str_AgeTypeName), o.IsInvisible(_str_AgeTypeName), o.IsRequired(_str_AgeTypeName)); }
              }, 
        
            new field_info {
              _name = _str_AgeType, _type = "Lookup",
              _get_func = o => { if (o.AgeType == null) return null; return o.AgeType.idfsBaseReference; },
              _set_func = (o, val) => { o.AgeType = o.AgeTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAgeType != c.idfsAgeType || o.IsRIRPropChanged(_str_AgeType, c)) 
                  m.Add(_str_AgeType, o.ObjectIdent + _str_AgeType, "Lookup", o.idfsAgeType == null ? "" : o.idfsAgeType.ToString(), o.IsReadOnly(_str_AgeType), o.IsInvisible(_str_AgeType), o.IsRequired(_str_AgeType)); }
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
            DiagnosisAgeGroup obj = (DiagnosisAgeGroup)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAgeType)]
        public BaseReference AgeType
        {
            get { return _AgeType == null ? null : ((long)_AgeType.Key == 0 ? null : _AgeType); }
            set 
            { 
                _AgeType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAgeType = _AgeType == null 
                    ? new Int64()
                    : _AgeType.idfsBaseReference; 
                OnPropertyChanged(_str_AgeType); 
            }
        }
        private BaseReference _AgeType;

        
        public BaseReferenceList AgeTypeLookup
        {
            get { return _AgeTypeLookup; }
        }
        private BaseReferenceList _AgeTypeLookup = new BaseReferenceList("rftHumanAgeType");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_AgeType:
                    return new BvSelectList(AgeTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AgeType, _str_idfsAgeType);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "DiagnosisAgeGroup";

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
            var ret = base.Clone() as DiagnosisAgeGroup;
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
            var ret = base.Clone() as DiagnosisAgeGroup;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public DiagnosisAgeGroup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as DiagnosisAgeGroup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsDiagnosisAgeGroup; } }
        public string KeyName { get { return "idfsDiagnosisAgeGroup"; } }
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
        
            var _prev_idfsAgeType_AgeType = idfsAgeType;
            base.RejectChanges();
        
            if (_prev_idfsAgeType_AgeType != idfsAgeType)
            {
                _AgeType = _AgeTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAgeType);
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
              
                case "DiagnosisAgeGroupName":
                  return new Dictionary<string, string> {
                
                    { "en", "" },
                
                    } ;
              
                case "DiagnosisAgeGroupNameTranslated":
                  return new Dictionary<string, string> {
                
                    { "def", "" },
                
                    } ;
              
                default:
                  return null;
              }
            
        }
      #endregion

      private bool IsRIRPropChanged(string fld, DiagnosisAgeGroup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public DiagnosisAgeGroup()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(DiagnosisAgeGroup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(DiagnosisAgeGroup_PropertyChanged);
        }
        private void DiagnosisAgeGroup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as DiagnosisAgeGroup).Changed(e.PropertyName);
            
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
            DiagnosisAgeGroup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            DiagnosisAgeGroup obj = this;
            
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


        public Dictionary<string, Func<DiagnosisAgeGroup, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<DiagnosisAgeGroup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<DiagnosisAgeGroup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<DiagnosisAgeGroup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<DiagnosisAgeGroup, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<DiagnosisAgeGroup, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~DiagnosisAgeGroup()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftHumanAgeType", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftHumanAgeType")
                _getAccessor().LoadLookup_AgeType(manager, this);
            
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
        public class DiagnosisAgeGroupGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfsDiagnosisAgeGroup { get; set; }
        
            public String DiagnosisAgeGroupName { get; set; }
        
            public String DiagnosisAgeGroupNameTranslated { get; set; }
        
            public Int32 intOrder { get; set; }
        
            public Int32 intLowerBoundary { get; set; }
        
            public Int32? intUpperBoundary { get; set; }
        
            public Int64 idfsAgeType { get; set; }
        
        }
        public partial class DiagnosisAgeGroupGridModelList : List<DiagnosisAgeGroupGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public DiagnosisAgeGroupGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<DiagnosisAgeGroup>, errMes);
            }
            public DiagnosisAgeGroupGridModelList(long key, IEnumerable<DiagnosisAgeGroup> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<DiagnosisAgeGroup> items);
            private void LoadGridModelList(long key, IEnumerable<DiagnosisAgeGroup> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_DiagnosisAgeGroupName,_str_DiagnosisAgeGroupNameTranslated,_str_intOrder,_str_intLowerBoundary,_str_intUpperBoundary,_str_idfsAgeType};
                    
                Hiddens = new List<string> {_str_idfsDiagnosisAgeGroup};
                Keys = new List<string> {};
                Labels = new Dictionary<string, string> {{_str_DiagnosisAgeGroupName, _str_DiagnosisAgeGroupName},{_str_DiagnosisAgeGroupNameTranslated, _str_DiagnosisAgeGroupNameTranslated},{_str_intOrder, _str_intOrder},{_str_intLowerBoundary, _str_intLowerBoundary},{_str_intUpperBoundary, _str_intUpperBoundary},{_str_idfsAgeType, _str_idfsAgeType}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<DiagnosisAgeGroup>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new DiagnosisAgeGroupGridModel()
                {
                    idfsDiagnosisAgeGroup=c.idfsDiagnosisAgeGroup,DiagnosisAgeGroupName=c.DiagnosisAgeGroupName,DiagnosisAgeGroupNameTranslated=c.DiagnosisAgeGroupNameTranslated,intOrder=c.intOrder,intLowerBoundary=c.intLowerBoundary,intUpperBoundary=c.intUpperBoundary,idfsAgeType=c.idfsAgeType
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
        : DataAccessor<DiagnosisAgeGroup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(DiagnosisAgeGroup obj);
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
            private BaseReference.Accessor AgeTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<DiagnosisAgeGroup> SelectList(DbManagerProxy manager
                , Int64? idfsDiagnosisAgeGroup
                )
            {
                return _SelectList(manager
                    , idfsDiagnosisAgeGroup
                    , delegate(DiagnosisAgeGroup obj)
                        {
                        }
                    , delegate(DiagnosisAgeGroup obj)
                        {
                        }
                    );
            }

            
            private List<DiagnosisAgeGroup> _SelectList(DbManagerProxy manager
                , Int64? idfsDiagnosisAgeGroup
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<DiagnosisAgeGroup> objs = new List<DiagnosisAgeGroup>();
                    sets[0] = new MapResultSet(typeof(DiagnosisAgeGroup), objs);
                    
                    manager
                        .SetSpCommand("spDiagnosisAgeGroup_SelectDetail"
                            , manager.Parameter("@idfsDiagnosisAgeGroup", idfsDiagnosisAgeGroup)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, DiagnosisAgeGroup obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, DiagnosisAgeGroup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private DiagnosisAgeGroup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    DiagnosisAgeGroup obj = DiagnosisAgeGroup.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfsDiagnosisAgeGroup = (new GetNewIDExtender<DiagnosisAgeGroup>()).GetScalar(manager, obj);
                obj.intOrder = new Func<DiagnosisAgeGroup, int>(c => 0)(obj);
                obj.intUpperBoundary = new Func<DiagnosisAgeGroup, int>(c => 0)(obj);
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

            
            public DiagnosisAgeGroup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public DiagnosisAgeGroup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(DiagnosisAgeGroup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(DiagnosisAgeGroup obj)
            {
                
            }
    
            public void LoadLookup_AgeType(DbManagerProxy manager, DiagnosisAgeGroup obj)
            {
                
                obj.AgeTypeLookup.Clear();
                
                obj.AgeTypeLookup.Add(AgeTypeAccessor.CreateNewT(manager, null));
                
                obj.AgeTypeLookup.AddRange(AgeTypeAccessor.rftHumanAgeType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAgeType))
                    
                    .ToList());
                
                if (obj.idfsAgeType != 0)
                {
                    obj.AgeType = obj.AgeTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsAgeType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftHumanAgeType", obj, AgeTypeAccessor.GetType(), "rftHumanAgeType_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, DiagnosisAgeGroup obj)
            {
                
                LoadLookup_AgeType(manager, obj);
                
            }
    
            [SprocName("spDiagnosisAgeGroup_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, string LangID, 
                [Direction.InputOutput()] DiagnosisAgeGroup obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, string LangID, 
                [Direction.InputOutput()] DiagnosisAgeGroup obj)
            {
                
                _post(manager, Action, LangID, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    DiagnosisAgeGroup bo = obj as DiagnosisAgeGroup;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as DiagnosisAgeGroup, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, DiagnosisAgeGroup obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(DiagnosisAgeGroup obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, DiagnosisAgeGroup obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as DiagnosisAgeGroup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, DiagnosisAgeGroup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "DiagnosisAgeGroupName", "DiagnosisAgeGroupName","",
                false
              )).Validate(c => true, obj, obj.DiagnosisAgeGroupName);
            
                (new RequiredValidator( "DiagnosisAgeGroupNameTranslated", "DiagnosisAgeGroupNameTranslated","",
                false
              )).Validate(c => ModelUserContext.CurrentLanguage != Localizer.lngEn, obj, obj.DiagnosisAgeGroupNameTranslated);
            
                (new RequiredValidator( "idfsDiagnosisAgeGroup", "idfsDiagnosisAgeGroup","",
                false
              )).Validate(c => true, obj, obj.idfsDiagnosisAgeGroup);
            
                (new PredicateValidator("intLowerBoundary and intUpperBoundary", "intLowerBoundary", "intLowerBoundary", "intLowerBoundary",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.intLowerBoundary < c.intUpperBoundary
                    );
            
                (new PredicateValidator("intLowerBoundary and intUpperBoundary", "intUpperBoundary", "intUpperBoundary", "intUpperBoundary",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.intLowerBoundary < c.intUpperBoundary
                    );
            
                (new PredicateValidator("intLowerBoundary", "intLowerBoundary", "intLowerBoundary", "intLowerBoundary",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.intLowerBoundary >= 0
                    );
            
                (new PredicateValidator("intUpperBoundary", "intUpperBoundary", "intUpperBoundary", "intUpperBoundary",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.intUpperBoundary > 0
                    );
            
                (new RequiredValidator( "idfsAgeType", "idfsAgeType","",
                false
              )).Validate(c => true, obj, obj.idfsAgeType);
            
                  
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
           
    
            private void _SetupRequired(DiagnosisAgeGroup obj)
            {
            
                obj
                    .AddRequired("DiagnosisAgeGroupName", c => true);
                    
                obj
                    .AddRequired("DiagnosisAgeGroupNameTranslated", c => ModelUserContext.CurrentLanguage != Localizer.lngEn);
                    
                obj
                    .AddRequired("idfsDiagnosisAgeGroup", c => true);
                    
                obj
                    .AddRequired("idfsAgeType", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(DiagnosisAgeGroup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as DiagnosisAgeGroup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as DiagnosisAgeGroup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "DiagnosisAgeGroupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spDiagnosisAgeGroup_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spDiagnosisAgeGroup_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<DiagnosisAgeGroup, bool>> RequiredByField = new Dictionary<string, Func<DiagnosisAgeGroup, bool>>();
            public static Dictionary<string, Func<DiagnosisAgeGroup, bool>> RequiredByProperty = new Dictionary<string, Func<DiagnosisAgeGroup, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_DiagnosisAgeGroupName, 2000);
                Sizes.Add(_str_DiagnosisAgeGroupNameTranslated, 2000);
                Sizes.Add(_str_AgeTypeName, 2000);
                if (!RequiredByField.ContainsKey("DiagnosisAgeGroupName")) RequiredByField.Add("DiagnosisAgeGroupName", c => true);
                if (!RequiredByProperty.ContainsKey("DiagnosisAgeGroupName")) RequiredByProperty.Add("DiagnosisAgeGroupName", c => true);
                
                if (!RequiredByField.ContainsKey("DiagnosisAgeGroupNameTranslated")) RequiredByField.Add("DiagnosisAgeGroupNameTranslated", c => ModelUserContext.CurrentLanguage != Localizer.lngEn);
                if (!RequiredByProperty.ContainsKey("DiagnosisAgeGroupNameTranslated")) RequiredByProperty.Add("DiagnosisAgeGroupNameTranslated", c => ModelUserContext.CurrentLanguage != Localizer.lngEn);
                
                if (!RequiredByField.ContainsKey("idfsDiagnosisAgeGroup")) RequiredByField.Add("idfsDiagnosisAgeGroup", c => true);
                if (!RequiredByProperty.ContainsKey("idfsDiagnosisAgeGroup")) RequiredByProperty.Add("idfsDiagnosisAgeGroup", c => true);
                
                if (!RequiredByField.ContainsKey("idfsAgeType")) RequiredByField.Add("idfsAgeType", c => true);
                if (!RequiredByProperty.ContainsKey("idfsAgeType")) RequiredByProperty.Add("idfsAgeType", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfsDiagnosisAgeGroup,
                    _str_idfsDiagnosisAgeGroup, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DiagnosisAgeGroupName,
                    _str_DiagnosisAgeGroupName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DiagnosisAgeGroupNameTranslated,
                    _str_DiagnosisAgeGroupNameTranslated, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intOrder,
                    _str_intOrder, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intLowerBoundary,
                    _str_intLowerBoundary, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intUpperBoundary,
                    _str_intUpperBoundary, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsAgeType,
                    _str_idfsAgeType, null, true, true, null
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
                    (manager, c, pars) => ((DiagnosisAgeGroup)c).MarkToDelete(),
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
	