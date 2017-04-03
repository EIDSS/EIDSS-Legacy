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
    public abstract partial class DiagnosisAgeGroupMaster : 
        EditableObject<DiagnosisAgeGroupMaster>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsDiagnosisAgeGroup), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsDiagnosisAgeGroup { get; set; }
                
        [LocalizedDisplayName(_str_DiagnosisAgeGroupName)]
        [MapField(_str_DiagnosisAgeGroupName)]
        public abstract String DiagnosisAgeGroupName { get; set; }
        protected String DiagnosisAgeGroupName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisAgeGroupName).OriginalValue; } }
        protected String DiagnosisAgeGroupName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisAgeGroupName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DiagnosisAgeGroupNameTranslated)]
        [MapField(_str_DiagnosisAgeGroupNameTranslated)]
        public abstract String DiagnosisAgeGroupNameTranslated { get; set; }
        protected String DiagnosisAgeGroupNameTranslated_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisAgeGroupNameTranslated).OriginalValue; } }
        protected String DiagnosisAgeGroupNameTranslated_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisAgeGroupNameTranslated).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32 intOrder { get; set; }
        protected Int32 intOrder_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32 intOrder_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intLowerBoundary)]
        [MapField(_str_intLowerBoundary)]
        public abstract Int32 intLowerBoundary { get; set; }
        protected Int32 intLowerBoundary_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intLowerBoundary).OriginalValue; } }
        protected Int32 intLowerBoundary_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intLowerBoundary).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intUpperBoundary)]
        [MapField(_str_intUpperBoundary)]
        public abstract Int32? intUpperBoundary { get; set; }
        protected Int32? intUpperBoundary_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intUpperBoundary).OriginalValue; } }
        protected Int32? intUpperBoundary_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intUpperBoundary).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsAgeType)]
        [MapField(_str_idfsAgeType)]
        public abstract Int64 idfsAgeType { get; set; }
        protected Int64 idfsAgeType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAgeType).OriginalValue; } }
        protected Int64 idfsAgeType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAgeType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_AgeTypeName)]
        [MapField(_str_AgeTypeName)]
        public abstract String AgeTypeName { get; set; }
        protected String AgeTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._ageTypeName).OriginalValue; } }
        protected String AgeTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._ageTypeName).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<DiagnosisAgeGroupMaster, object> _get_func;
            internal Action<DiagnosisAgeGroupMaster, string> _set_func;
            internal Action<DiagnosisAgeGroupMaster, DiagnosisAgeGroupMaster, CompareModel> _compare_func;
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
        internal const string _str_DiagnosisAgeGroups = "DiagnosisAgeGroups";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsDiagnosisAgeGroup, _formname = _str_idfsDiagnosisAgeGroup, _type = "Int64",
              _get_func = o => o.idfsDiagnosisAgeGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsDiagnosisAgeGroup != newval) o.idfsDiagnosisAgeGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosisAgeGroup != c.idfsDiagnosisAgeGroup || o.IsRIRPropChanged(_str_idfsDiagnosisAgeGroup, c)) 
                  m.Add(_str_idfsDiagnosisAgeGroup, o.ObjectIdent + _str_idfsDiagnosisAgeGroup, o.ObjectIdent2 + _str_idfsDiagnosisAgeGroup, o.ObjectIdent3 + _str_idfsDiagnosisAgeGroup, "Int64", 
                    o.idfsDiagnosisAgeGroup == null ? "" : o.idfsDiagnosisAgeGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosisAgeGroup), o.IsInvisible(_str_idfsDiagnosisAgeGroup), o.IsRequired(_str_idfsDiagnosisAgeGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DiagnosisAgeGroupName, _formname = _str_DiagnosisAgeGroupName, _type = "String",
              _get_func = o => o.DiagnosisAgeGroupName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DiagnosisAgeGroupName != newval) o.DiagnosisAgeGroupName = newval; },
              _compare_func = (o, c, m) => {
                if (o.DiagnosisAgeGroupName != c.DiagnosisAgeGroupName || o.IsRIRPropChanged(_str_DiagnosisAgeGroupName, c)) 
                  m.Add(_str_DiagnosisAgeGroupName, o.ObjectIdent + _str_DiagnosisAgeGroupName, o.ObjectIdent2 + _str_DiagnosisAgeGroupName, o.ObjectIdent3 + _str_DiagnosisAgeGroupName, "String", 
                    o.DiagnosisAgeGroupName == null ? "" : o.DiagnosisAgeGroupName.ToString(),                  
                  o.IsReadOnly(_str_DiagnosisAgeGroupName), o.IsInvisible(_str_DiagnosisAgeGroupName), o.IsRequired(_str_DiagnosisAgeGroupName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DiagnosisAgeGroupNameTranslated, _formname = _str_DiagnosisAgeGroupNameTranslated, _type = "String",
              _get_func = o => o.DiagnosisAgeGroupNameTranslated,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DiagnosisAgeGroupNameTranslated != newval) o.DiagnosisAgeGroupNameTranslated = newval; },
              _compare_func = (o, c, m) => {
                if (o.DiagnosisAgeGroupNameTranslated != c.DiagnosisAgeGroupNameTranslated || o.IsRIRPropChanged(_str_DiagnosisAgeGroupNameTranslated, c)) 
                  m.Add(_str_DiagnosisAgeGroupNameTranslated, o.ObjectIdent + _str_DiagnosisAgeGroupNameTranslated, o.ObjectIdent2 + _str_DiagnosisAgeGroupNameTranslated, o.ObjectIdent3 + _str_DiagnosisAgeGroupNameTranslated, "String", 
                    o.DiagnosisAgeGroupNameTranslated == null ? "" : o.DiagnosisAgeGroupNameTranslated.ToString(),                  
                  o.IsReadOnly(_str_DiagnosisAgeGroupNameTranslated), o.IsInvisible(_str_DiagnosisAgeGroupNameTranslated), o.IsRequired(_str_DiagnosisAgeGroupNameTranslated)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intOrder, _formname = _str_intOrder, _type = "Int32",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intOrder != newval) o.intOrder = newval; },
              _compare_func = (o, c, m) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, o.ObjectIdent2 + _str_intOrder, o.ObjectIdent3 + _str_intOrder, "Int32", 
                    o.intOrder == null ? "" : o.intOrder.ToString(),                  
                  o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intLowerBoundary, _formname = _str_intLowerBoundary, _type = "Int32",
              _get_func = o => o.intLowerBoundary,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intLowerBoundary != newval) o.intLowerBoundary = newval; },
              _compare_func = (o, c, m) => {
                if (o.intLowerBoundary != c.intLowerBoundary || o.IsRIRPropChanged(_str_intLowerBoundary, c)) 
                  m.Add(_str_intLowerBoundary, o.ObjectIdent + _str_intLowerBoundary, o.ObjectIdent2 + _str_intLowerBoundary, o.ObjectIdent3 + _str_intLowerBoundary, "Int32", 
                    o.intLowerBoundary == null ? "" : o.intLowerBoundary.ToString(),                  
                  o.IsReadOnly(_str_intLowerBoundary), o.IsInvisible(_str_intLowerBoundary), o.IsRequired(_str_intLowerBoundary)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intUpperBoundary, _formname = _str_intUpperBoundary, _type = "Int32?",
              _get_func = o => o.intUpperBoundary,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intUpperBoundary != newval) o.intUpperBoundary = newval; },
              _compare_func = (o, c, m) => {
                if (o.intUpperBoundary != c.intUpperBoundary || o.IsRIRPropChanged(_str_intUpperBoundary, c)) 
                  m.Add(_str_intUpperBoundary, o.ObjectIdent + _str_intUpperBoundary, o.ObjectIdent2 + _str_intUpperBoundary, o.ObjectIdent3 + _str_intUpperBoundary, "Int32?", 
                    o.intUpperBoundary == null ? "" : o.intUpperBoundary.ToString(),                  
                  o.IsReadOnly(_str_intUpperBoundary), o.IsInvisible(_str_intUpperBoundary), o.IsRequired(_str_intUpperBoundary)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAgeType, _formname = _str_idfsAgeType, _type = "Int64",
              _get_func = o => o.idfsAgeType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsAgeType != newval) o.idfsAgeType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsAgeType != c.idfsAgeType || o.IsRIRPropChanged(_str_idfsAgeType, c)) 
                  m.Add(_str_idfsAgeType, o.ObjectIdent + _str_idfsAgeType, o.ObjectIdent2 + _str_idfsAgeType, o.ObjectIdent3 + _str_idfsAgeType, "Int64", 
                    o.idfsAgeType == null ? "" : o.idfsAgeType.ToString(),                  
                  o.IsReadOnly(_str_idfsAgeType), o.IsInvisible(_str_idfsAgeType), o.IsRequired(_str_idfsAgeType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_AgeTypeName, _formname = _str_AgeTypeName, _type = "String",
              _get_func = o => o.AgeTypeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.AgeTypeName != newval) o.AgeTypeName = newval; },
              _compare_func = (o, c, m) => {
                if (o.AgeTypeName != c.AgeTypeName || o.IsRIRPropChanged(_str_AgeTypeName, c)) 
                  m.Add(_str_AgeTypeName, o.ObjectIdent + _str_AgeTypeName, o.ObjectIdent2 + _str_AgeTypeName, o.ObjectIdent3 + _str_AgeTypeName, "String", 
                    o.AgeTypeName == null ? "" : o.AgeTypeName.ToString(),                  
                  o.IsReadOnly(_str_AgeTypeName), o.IsInvisible(_str_AgeTypeName), o.IsRequired(_str_AgeTypeName)); 
                  }
              }, 
        
            new field_info {
              _name = _str_DiagnosisAgeGroups, _formname = _str_DiagnosisAgeGroups, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.DiagnosisAgeGroups.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.DiagnosisAgeGroups.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.DiagnosisAgeGroups.Count != c.DiagnosisAgeGroups.Count || o.IsReadOnly(_str_DiagnosisAgeGroups) != c.IsReadOnly(_str_DiagnosisAgeGroups) || o.IsInvisible(_str_DiagnosisAgeGroups) != c.IsInvisible(_str_DiagnosisAgeGroups) || o.IsRequired(_str_DiagnosisAgeGroups) != c._isRequired(o.m_isRequired, _str_DiagnosisAgeGroups)) {
                  m.Add(_str_DiagnosisAgeGroups, o.ObjectIdent + _str_DiagnosisAgeGroups, o.ObjectIdent2 + _str_DiagnosisAgeGroups, o.ObjectIdent3 + _str_DiagnosisAgeGroups, "Child", o.idfsDiagnosisAgeGroup == null ? "" : o.idfsDiagnosisAgeGroup.ToString(), o.IsReadOnly(_str_DiagnosisAgeGroups), o.IsInvisible(_str_DiagnosisAgeGroups), o.IsRequired(_str_DiagnosisAgeGroups)); 
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
            DiagnosisAgeGroupMaster obj = (DiagnosisAgeGroupMaster)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_DiagnosisAgeGroups)]
        [Relation(typeof(DiagnosisAgeGroup), eidss.model.Schema.DiagnosisAgeGroup._str_idfsDiagnosisAgeGroup, _str_idfsDiagnosisAgeGroup)]
        public EditableList<DiagnosisAgeGroup> DiagnosisAgeGroups
        {
            get 
            {   
                return _DiagnosisAgeGroups; 
            }
            set 
            {
                _DiagnosisAgeGroups = value;
            }
        }
        protected EditableList<DiagnosisAgeGroup> _DiagnosisAgeGroups = new EditableList<DiagnosisAgeGroup>();
                    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "DiagnosisAgeGroupMaster";

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
        DiagnosisAgeGroups.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as DiagnosisAgeGroupMaster;
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
            var ret = base.Clone() as DiagnosisAgeGroupMaster;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_DiagnosisAgeGroups != null && _DiagnosisAgeGroups.Count > 0)
            {
              ret.DiagnosisAgeGroups.Clear();
              _DiagnosisAgeGroups.ForEach(c => ret.DiagnosisAgeGroups.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public DiagnosisAgeGroupMaster CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as DiagnosisAgeGroupMaster;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsDiagnosisAgeGroup; } }
        public string KeyName { get { return "idfsDiagnosisAgeGroup"; } }
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
        
                    || DiagnosisAgeGroups.IsDirty
                    || DiagnosisAgeGroups.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
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
        DiagnosisAgeGroups.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        DiagnosisAgeGroups.DeepAcceptChanges();
                
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
        DiagnosisAgeGroups.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, DiagnosisAgeGroupMaster c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public DiagnosisAgeGroupMaster()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(DiagnosisAgeGroupMaster_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(DiagnosisAgeGroupMaster_PropertyChanged);
        }
        private void DiagnosisAgeGroupMaster_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as DiagnosisAgeGroupMaster).Changed(e.PropertyName);
            
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
            DiagnosisAgeGroupMaster obj = this;
            
        }
        private void _DeletedExtenders()
        {
            DiagnosisAgeGroupMaster obj = this;
            
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
        
                foreach(var o in _DiagnosisAgeGroups)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<DiagnosisAgeGroupMaster, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<DiagnosisAgeGroupMaster, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<DiagnosisAgeGroupMaster, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<DiagnosisAgeGroupMaster, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<DiagnosisAgeGroupMaster, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<DiagnosisAgeGroupMaster, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<DiagnosisAgeGroupMaster, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~DiagnosisAgeGroupMaster()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                DiagnosisAgeGroups.ForEach(c => c.Dispose());
                
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
        
            if (_DiagnosisAgeGroups != null) _DiagnosisAgeGroups.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<DiagnosisAgeGroupMaster>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<DiagnosisAgeGroupMaster>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<DiagnosisAgeGroupMaster>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsDiagnosisAgeGroup"; } }
            #endregion
        
            private delegate void on_action(DiagnosisAgeGroupMaster obj);
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
            private DiagnosisAgeGroup.Accessor DiagnosisAgeGroupsAccessor { get { return eidss.model.Schema.DiagnosisAgeGroup.Accessor.Instance(m_CS); } }
            

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
            public virtual DiagnosisAgeGroupMaster SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
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

            
            public virtual DiagnosisAgeGroupMaster SelectByKey(DbManagerProxy manager
                , Int64? idfsDiagnosisAgeGroup
                )
            {
                return _SelectByKey(manager
                    , idfsDiagnosisAgeGroup
                    , null, null
                    );
            }
            
      
            private DiagnosisAgeGroupMaster _SelectByKey(DbManagerProxy manager
                , Int64? idfsDiagnosisAgeGroup
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<DiagnosisAgeGroupMaster> objs = new List<DiagnosisAgeGroupMaster>();
                sets[0] = new MapResultSet(typeof(DiagnosisAgeGroupMaster), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spDiagnosisAgeGroup_SelectDetail"
                            , manager.Parameter("@idfsDiagnosisAgeGroup", idfsDiagnosisAgeGroup)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    DiagnosisAgeGroupMaster obj = objs[0];
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
    
            private void _SetupAddChildHandlerDiagnosisAgeGroups(DiagnosisAgeGroupMaster obj)
            {
                obj.DiagnosisAgeGroups.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadDiagnosisAgeGroups(DiagnosisAgeGroupMaster obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadDiagnosisAgeGroups(manager, obj);
                }
            }
            internal void _LoadDiagnosisAgeGroups(DbManagerProxy manager, DiagnosisAgeGroupMaster obj)
            {
                
                obj.DiagnosisAgeGroups.Clear();
                obj.DiagnosisAgeGroups.AddRange(DiagnosisAgeGroupsAccessor.SelectDetailList(manager
                    
                    , obj.idfsDiagnosisAgeGroup
                    ));
                obj.DiagnosisAgeGroups.ForEach(c => c.m_ObjectName = _str_DiagnosisAgeGroups);
                obj.DiagnosisAgeGroups.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, DiagnosisAgeGroupMaster obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadDiagnosisAgeGroups(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerDiagnosisAgeGroups(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, DiagnosisAgeGroupMaster obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.DiagnosisAgeGroups.ForEach(c => DiagnosisAgeGroupsAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private DiagnosisAgeGroupMaster _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    DiagnosisAgeGroupMaster obj = DiagnosisAgeGroupMaster.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
              obj.m_IsNew = false;
              var accMaster = DiagnosisAgeGroupMaster.Accessor.Instance(null);
              accMaster._LoadDiagnosisAgeGroups(manager, obj);
            
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerDiagnosisAgeGroups(obj);
                    
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

            
            public DiagnosisAgeGroupMaster CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public DiagnosisAgeGroupMaster CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public DiagnosisAgeGroupMaster CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult DeleteGroup(DbManagerProxy manager, DiagnosisAgeGroupMaster obj, List<object> pars)
            {
                
                return DeleteGroup(manager, obj
                    );
            }
            public ActResult DeleteGroup(DbManagerProxy manager, DiagnosisAgeGroupMaster obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("DeleteGroup"))
                    throw new PermissionException("Reference", "DeleteGroup");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(DiagnosisAgeGroupMaster obj, object newobj)
            {
                
                foreach(var o in obj.DiagnosisAgeGroups.Where(c => true))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "DiagnosisAgeGroupName")
                                {
                                
                (new RequiredValidator( "DiagnosisAgeGroupName", "DiagnosisAgeGroupName","",
                false
              )).Validate(c => true, item, item.DiagnosisAgeGroupName);
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("DiagnosisAgeGroupName");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        
                    }
                }
                            
                foreach(var o in obj.DiagnosisAgeGroups.Where(c => ModelUserContext.CurrentLanguage != Localizer.lngEn))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "DiagnosisAgeGroupNameTranslated")
                                {
                                
                (new RequiredValidator( "DiagnosisAgeGroupNameTranslated", "DiagnosisAgeGroupNameTranslated","",
                false
              )).Validate(c => true, item, item.DiagnosisAgeGroupNameTranslated);
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("DiagnosisAgeGroupNameTranslated");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        
                    }
                }
                            
                foreach(var o in obj.DiagnosisAgeGroups.Where(c => true))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "")
                                {
                                
                (new RequiredValidator( "idfsDiagnosisAgeGroup", "idfsDiagnosisAgeGroup","",
                false
              )).Validate(c => true, item, item.idfsDiagnosisAgeGroup);
            
                (new RequiredValidator( "idfsAgeType", "idfsAgeType","",
                false
              )).Validate(c => true, item, item.idfsAgeType);
            
                (new PredicateValidator("intLowerBoundary", "intLowerBoundary", "intLowerBoundary", "intLowerBoundary",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => item.intLowerBoundary >= 0
                    );
            
                (new PredicateValidator("intUpperBoundary", "intUpperBoundary", "intUpperBoundary", "intUpperBoundary",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => item.intUpperBoundary > 0
                    );
            
                (new PredicateValidator("intLowerBoundary and intUpperBoundary", "intLowerBoundary", "intLowerBoundary", "intLowerBoundary",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => item.intLowerBoundary < item.intUpperBoundary
                    );
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        
                    }
                }
                            
            }
            
            private void _SetupHandlers(DiagnosisAgeGroupMaster obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, DiagnosisAgeGroupMaster obj)
            {
                
            }
    
            [SprocName("spDiagnosisAgeGroupMaster_Delete")]
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
                [Direction.InputOutput()] DiagnosisAgeGroupMaster obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] DiagnosisAgeGroupMaster obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    DiagnosisAgeGroupMaster bo = obj as DiagnosisAgeGroupMaster;
                    
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
                    
                    long mainObject = bo.idfsDiagnosisAgeGroup;
                    
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
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                          eidss.model.Enums.EventType eventType = eidss.model.Enums.EventType.RaiseReferenceCacheChange;
                          
                          manager.SetEventParams(false, "DiagnosisAgeGroup", new object[] { eventType, null, "DiagnosisAgeGroup" });
                          
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
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.trtDiagnosisAgeGroup;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as DiagnosisAgeGroupMaster, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, DiagnosisAgeGroupMaster obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.DiagnosisAgeGroups != null)
                    {
                        foreach (var i in obj.DiagnosisAgeGroups)
                        {
                            i.MarkToDelete();
                            if (!DiagnosisAgeGroupsAccessor.Post(manager, i, true))
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
                        if (obj.DiagnosisAgeGroups != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.DiagnosisAgeGroups)
                                if (!DiagnosisAgeGroupsAccessor.Post(manager, i, true))
                                    return false;
                            obj.DiagnosisAgeGroups.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.DiagnosisAgeGroups.Remove(c));
                            obj.DiagnosisAgeGroups.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._DiagnosisAgeGroups != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._DiagnosisAgeGroups)
                                if (!DiagnosisAgeGroupsAccessor.Post(manager, i, true))
                                    return false;
                            obj._DiagnosisAgeGroups.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._DiagnosisAgeGroups.Remove(c));
                            obj._DiagnosisAgeGroups.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(DiagnosisAgeGroupMaster obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, DiagnosisAgeGroupMaster obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(DiagnosisAgeGroupMaster obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(DiagnosisAgeGroupMaster obj, bool bRethrowException)
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
                return Validate(manager, obj as DiagnosisAgeGroupMaster, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, DiagnosisAgeGroupMaster obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
              new DuplicateListValidator("").Validate(obj, 
              o => o.DiagnosisAgeGroups.Where(c => !c.IsMarkedToDelete)
                .Aggregate(new List<Tuple<DiagnosisAgeGroup, int>>(), (list, test) => 
                { 
                    var item = list.Find(c => true
                      
                        && c.Item1.DiagnosisAgeGroupName == test.DiagnosisAgeGroupName
                      );
                      if (item == null)
                      list.Add(new Tuple<DiagnosisAgeGroup, int>(test, 1));
                    else
                    {
                        list.Remove(item);
                        list.Add(new Tuple<DiagnosisAgeGroup, int>(test, item.Item2 + 1));
                    }
                    return list;
                })
                .Where(c => c.Item2 > 1).Select(c => c.Item1).FirstOrDefault(),
                    (o, i) => new Tuple<
                      string, object
                      
                      >(
                      "DiagnosisAgeGroupName", 
                        
                        i.DiagnosisAgeGroupName
                      )
                );
            
          
              new DuplicateListValidator("").Validate(obj, 
              o => o.DiagnosisAgeGroups.Where(c => !c.IsMarkedToDelete && ModelUserContext.CurrentLanguage != Localizer.lngEn)
                .Aggregate(new List<Tuple<DiagnosisAgeGroup, int>>(), (list, test) => 
                { 
                    var item = list.Find(c => true
                      
                        && c.Item1.DiagnosisAgeGroupNameTranslated == test.DiagnosisAgeGroupNameTranslated
                      );
                      if (item == null)
                      list.Add(new Tuple<DiagnosisAgeGroup, int>(test, 1));
                    else
                    {
                        list.Remove(item);
                        list.Add(new Tuple<DiagnosisAgeGroup, int>(test, item.Item2 + 1));
                    }
                    return list;
                })
                .Where(c => c.Item2 > 1).Select(c => c.Item1).FirstOrDefault(),
                    (o, i) => new Tuple<
                      string, object
                      
                      >(
                      "DiagnosisAgeGroupNameTranslated", 
                        
                        i.DiagnosisAgeGroupNameTranslated
                      )
                );
            
          
                  
                    }

                    if (bChangeValidation)
                    {
                
                        foreach(var item in obj.DiagnosisAgeGroups.Where(c => true))
                        {
                        
                (new RequiredValidator( "DiagnosisAgeGroupName", "DiagnosisAgeGroupName","",
                false
              )).Validate(c => true, item, item.DiagnosisAgeGroupName);
            
                        }
                
                        foreach(var item in obj.DiagnosisAgeGroups.Where(c => ModelUserContext.CurrentLanguage != Localizer.lngEn))
                        {
                        
                (new RequiredValidator( "DiagnosisAgeGroupNameTranslated", "DiagnosisAgeGroupNameTranslated","",
                false
              )).Validate(c => true, item, item.DiagnosisAgeGroupNameTranslated);
            
                        }
                
                        foreach(var item in obj.DiagnosisAgeGroups.Where(c => true))
                        {
                        
                (new RequiredValidator( "idfsDiagnosisAgeGroup", "idfsDiagnosisAgeGroup","",
                false
              )).Validate(c => true, item, item.idfsDiagnosisAgeGroup);
            
                (new RequiredValidator( "idfsAgeType", "idfsAgeType","",
                false
              )).Validate(c => true, item, item.idfsAgeType);
            
                (new PredicateValidator("intLowerBoundary", "intLowerBoundary", "intLowerBoundary", "intLowerBoundary",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => item.intLowerBoundary >= 0
                    );
            
                (new PredicateValidator("intUpperBoundary", "intUpperBoundary", "intUpperBoundary", "intUpperBoundary",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => item.intUpperBoundary > 0
                    );
            
                (new PredicateValidator("intLowerBoundary and intUpperBoundary", "intLowerBoundary", "intLowerBoundary", "intLowerBoundary",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => item.intLowerBoundary < item.intUpperBoundary
                    );
            
                        }
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.DiagnosisAgeGroups != null)
                            foreach (var i in obj.DiagnosisAgeGroups.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                DiagnosisAgeGroupsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
            
            private void _SetupRequired(DiagnosisAgeGroupMaster obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(DiagnosisAgeGroupMaster obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as DiagnosisAgeGroupMaster) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as DiagnosisAgeGroupMaster) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "DiagnosisAgeGroupMasterDetail"; } }
            public string HelpIdWin { get { return "Age_Groups_Editor"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private DiagnosisAgeGroupMaster m_obj;
            internal Permissions(DiagnosisAgeGroupMaster obj)
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
            public static string spSelect = "spDiagnosisAgeGroup_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spDummy_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spDiagnosisAgeGroupMaster_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<DiagnosisAgeGroupMaster, bool>> RequiredByField = new Dictionary<string, Func<DiagnosisAgeGroupMaster, bool>>();
            public static Dictionary<string, Func<DiagnosisAgeGroupMaster, bool>> RequiredByProperty = new Dictionary<string, Func<DiagnosisAgeGroupMaster, bool>>();
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
                
                Sizes.Add(_str_DiagnosisAgeGroupName, 2000);
                Sizes.Add(_str_DiagnosisAgeGroupNameTranslated, 2000);
                Sizes.Add(_str_AgeTypeName, 2000);
                Actions.Add(new ActionMetaItem(
                    "DeleteGroup",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).DeleteGroup(manager, (DiagnosisAgeGroupMaster)c, pars),
                        
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<DiagnosisAgeGroupMaster>().Post(manager, (DiagnosisAgeGroupMaster)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<DiagnosisAgeGroupMaster>().Post(manager, (DiagnosisAgeGroupMaster)c), c),
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
	