#pragma warning disable 0472,0414
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
    public abstract partial class StatisticTypeLookup : 
        EditableObject<StatisticTypeLookup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsBaseReference), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsBaseReference { get; set; }
                
        [LocalizedDisplayName(_str_strDefault)]
        [MapField(_str_strDefault)]
        public abstract String strDefault { get; set; }
        protected String strDefault_Original { get { return ((EditableValue<String>)((dynamic)this)._strDefault).OriginalValue; } }
        protected String strDefault_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDefault).PreviousValue; } }
                
        [LocalizedDisplayName(_str_name)]
        [MapField(_str_name)]
        public abstract String name { get; set; }
        protected String name_Original { get { return ((EditableValue<String>)((dynamic)this)._name).OriginalValue; } }
        protected String name_Previous { get { return ((EditableValue<String>)((dynamic)this)._name).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnSystem)]
        [MapField(_str_blnSystem)]
        public abstract Boolean? blnSystem { get; set; }
        protected Boolean? blnSystem_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnSystem).OriginalValue; } }
        protected Boolean? blnSystem_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnSystem).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intRowStatus)]
        [MapField(_str_intRowStatus)]
        public abstract Int32? intRowStatus { get; set; }
        protected Int32? intRowStatus_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intRowStatus).OriginalValue; } }
        protected Int32? intRowStatus_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intRowStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsReferenceType)]
        [MapField(_str_idfsReferenceType)]
        public abstract Int64? idfsReferenceType { get; set; }
        protected Int64? idfsReferenceType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsReferenceType).OriginalValue; } }
        protected Int64? idfsReferenceType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsReferenceType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsStatisticAreaType)]
        [MapField(_str_idfsStatisticAreaType)]
        public abstract Int64 idfsStatisticAreaType { get; set; }
        protected Int64 idfsStatisticAreaType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsStatisticAreaType).OriginalValue; } }
        protected Int64 idfsStatisticAreaType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsStatisticAreaType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsStatisticPeriodType)]
        [MapField(_str_idfsStatisticPeriodType)]
        public abstract Int64 idfsStatisticPeriodType { get; set; }
        protected Int64 idfsStatisticPeriodType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsStatisticPeriodType).OriginalValue; } }
        protected Int64 idfsStatisticPeriodType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsStatisticPeriodType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnRelatedWithAgeGroup)]
        [MapField(_str_blnRelatedWithAgeGroup)]
        public abstract Boolean? blnRelatedWithAgeGroup { get; set; }
        protected Boolean? blnRelatedWithAgeGroup_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnRelatedWithAgeGroup).OriginalValue; } }
        protected Boolean? blnRelatedWithAgeGroup_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnRelatedWithAgeGroup).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<StatisticTypeLookup, object> _get_func;
            internal Action<StatisticTypeLookup, string> _set_func;
            internal Action<StatisticTypeLookup, StatisticTypeLookup, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsBaseReference = "idfsBaseReference";
        internal const string _str_strDefault = "strDefault";
        internal const string _str_name = "name";
        internal const string _str_blnSystem = "blnSystem";
        internal const string _str_intRowStatus = "intRowStatus";
        internal const string _str_idfsReferenceType = "idfsReferenceType";
        internal const string _str_idfsStatisticAreaType = "idfsStatisticAreaType";
        internal const string _str_idfsStatisticPeriodType = "idfsStatisticPeriodType";
        internal const string _str_blnRelatedWithAgeGroup = "blnRelatedWithAgeGroup";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsBaseReference, _formname = _str_idfsBaseReference, _type = "Int64",
              _get_func = o => o.idfsBaseReference,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsBaseReference != newval) o.idfsBaseReference = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsBaseReference != c.idfsBaseReference || o.IsRIRPropChanged(_str_idfsBaseReference, c)) 
                  m.Add(_str_idfsBaseReference, o.ObjectIdent + _str_idfsBaseReference, o.ObjectIdent2 + _str_idfsBaseReference, o.ObjectIdent3 + _str_idfsBaseReference, "Int64", 
                    o.idfsBaseReference == null ? "" : o.idfsBaseReference.ToString(),                  
                  o.IsReadOnly(_str_idfsBaseReference), o.IsInvisible(_str_idfsBaseReference), o.IsRequired(_str_idfsBaseReference)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDefault, _formname = _str_strDefault, _type = "String",
              _get_func = o => o.strDefault,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDefault != newval) o.strDefault = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strDefault != c.strDefault || o.IsRIRPropChanged(_str_strDefault, c)) 
                  m.Add(_str_strDefault, o.ObjectIdent + _str_strDefault, o.ObjectIdent2 + _str_strDefault, o.ObjectIdent3 + _str_strDefault, "String", 
                    o.strDefault == null ? "" : o.strDefault.ToString(),                  
                  o.IsReadOnly(_str_strDefault), o.IsInvisible(_str_strDefault), o.IsRequired(_str_strDefault)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_name, _formname = _str_name, _type = "String",
              _get_func = o => o.name,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.name != newval) o.name = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.name != c.name || o.IsRIRPropChanged(_str_name, c)) 
                  m.Add(_str_name, o.ObjectIdent + _str_name, o.ObjectIdent2 + _str_name, o.ObjectIdent3 + _str_name, "String", 
                    o.name == null ? "" : o.name.ToString(),                  
                  o.IsReadOnly(_str_name), o.IsInvisible(_str_name), o.IsRequired(_str_name)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnSystem, _formname = _str_blnSystem, _type = "Boolean?",
              _get_func = o => o.blnSystem,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnSystem != newval) o.blnSystem = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnSystem != c.blnSystem || o.IsRIRPropChanged(_str_blnSystem, c)) 
                  m.Add(_str_blnSystem, o.ObjectIdent + _str_blnSystem, o.ObjectIdent2 + _str_blnSystem, o.ObjectIdent3 + _str_blnSystem, "Boolean?", 
                    o.blnSystem == null ? "" : o.blnSystem.ToString(),                  
                  o.IsReadOnly(_str_blnSystem), o.IsInvisible(_str_blnSystem), o.IsRequired(_str_blnSystem)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intRowStatus, _formname = _str_intRowStatus, _type = "Int32?",
              _get_func = o => o.intRowStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intRowStatus != newval) o.intRowStatus = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intRowStatus != c.intRowStatus || o.IsRIRPropChanged(_str_intRowStatus, c)) 
                  m.Add(_str_intRowStatus, o.ObjectIdent + _str_intRowStatus, o.ObjectIdent2 + _str_intRowStatus, o.ObjectIdent3 + _str_intRowStatus, "Int32?", 
                    o.intRowStatus == null ? "" : o.intRowStatus.ToString(),                  
                  o.IsReadOnly(_str_intRowStatus), o.IsInvisible(_str_intRowStatus), o.IsRequired(_str_intRowStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsReferenceType, _formname = _str_idfsReferenceType, _type = "Int64?",
              _get_func = o => o.idfsReferenceType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsReferenceType != newval) o.idfsReferenceType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsReferenceType != c.idfsReferenceType || o.IsRIRPropChanged(_str_idfsReferenceType, c)) 
                  m.Add(_str_idfsReferenceType, o.ObjectIdent + _str_idfsReferenceType, o.ObjectIdent2 + _str_idfsReferenceType, o.ObjectIdent3 + _str_idfsReferenceType, "Int64?", 
                    o.idfsReferenceType == null ? "" : o.idfsReferenceType.ToString(),                  
                  o.IsReadOnly(_str_idfsReferenceType), o.IsInvisible(_str_idfsReferenceType), o.IsRequired(_str_idfsReferenceType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsStatisticAreaType, _formname = _str_idfsStatisticAreaType, _type = "Int64",
              _get_func = o => o.idfsStatisticAreaType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsStatisticAreaType != newval) o.idfsStatisticAreaType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsStatisticAreaType != c.idfsStatisticAreaType || o.IsRIRPropChanged(_str_idfsStatisticAreaType, c)) 
                  m.Add(_str_idfsStatisticAreaType, o.ObjectIdent + _str_idfsStatisticAreaType, o.ObjectIdent2 + _str_idfsStatisticAreaType, o.ObjectIdent3 + _str_idfsStatisticAreaType, "Int64", 
                    o.idfsStatisticAreaType == null ? "" : o.idfsStatisticAreaType.ToString(),                  
                  o.IsReadOnly(_str_idfsStatisticAreaType), o.IsInvisible(_str_idfsStatisticAreaType), o.IsRequired(_str_idfsStatisticAreaType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsStatisticPeriodType, _formname = _str_idfsStatisticPeriodType, _type = "Int64",
              _get_func = o => o.idfsStatisticPeriodType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsStatisticPeriodType != newval) o.idfsStatisticPeriodType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsStatisticPeriodType != c.idfsStatisticPeriodType || o.IsRIRPropChanged(_str_idfsStatisticPeriodType, c)) 
                  m.Add(_str_idfsStatisticPeriodType, o.ObjectIdent + _str_idfsStatisticPeriodType, o.ObjectIdent2 + _str_idfsStatisticPeriodType, o.ObjectIdent3 + _str_idfsStatisticPeriodType, "Int64", 
                    o.idfsStatisticPeriodType == null ? "" : o.idfsStatisticPeriodType.ToString(),                  
                  o.IsReadOnly(_str_idfsStatisticPeriodType), o.IsInvisible(_str_idfsStatisticPeriodType), o.IsRequired(_str_idfsStatisticPeriodType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnRelatedWithAgeGroup, _formname = _str_blnRelatedWithAgeGroup, _type = "Boolean?",
              _get_func = o => o.blnRelatedWithAgeGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnRelatedWithAgeGroup != newval) o.blnRelatedWithAgeGroup = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnRelatedWithAgeGroup != c.blnRelatedWithAgeGroup || o.IsRIRPropChanged(_str_blnRelatedWithAgeGroup, c)) 
                  m.Add(_str_blnRelatedWithAgeGroup, o.ObjectIdent + _str_blnRelatedWithAgeGroup, o.ObjectIdent2 + _str_blnRelatedWithAgeGroup, o.ObjectIdent3 + _str_blnRelatedWithAgeGroup, "Boolean?", 
                    o.blnRelatedWithAgeGroup == null ? "" : o.blnRelatedWithAgeGroup.ToString(),                  
                  o.IsReadOnly(_str_blnRelatedWithAgeGroup), o.IsInvisible(_str_blnRelatedWithAgeGroup), o.IsRequired(_str_blnRelatedWithAgeGroup)); 
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
            StatisticTypeLookup obj = (StatisticTypeLookup)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
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
        internal string m_ObjectName = "StatisticTypeLookup";

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
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as StatisticTypeLookup;
            ret.bIsClone = true;
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
            var ret = base.Clone() as StatisticTypeLookup;
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
        public StatisticTypeLookup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as StatisticTypeLookup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsBaseReference; } }
        public string KeyName { get { return "idfsBaseReference"; } }
        public object KeyLookup { get { return idfsBaseReference; } }
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
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
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

        private bool IsRIRPropChanged(string fld, StatisticTypeLookup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, StatisticTypeLookup c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      
        public override string ToString()
        {
            return new Func<StatisticTypeLookup, string>(c => c.name)(this);
        }
        

        public StatisticTypeLookup()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(StatisticTypeLookup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(StatisticTypeLookup_PropertyChanged);
        }
        private void StatisticTypeLookup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as StatisticTypeLookup).Changed(e.PropertyName);
            
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
            StatisticTypeLookup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            StatisticTypeLookup obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
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

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
            }
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


        internal Dictionary<string, Func<StatisticTypeLookup, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<StatisticTypeLookup, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<StatisticTypeLookup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<StatisticTypeLookup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<StatisticTypeLookup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<StatisticTypeLookup, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<StatisticTypeLookup, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~StatisticTypeLookup()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
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
        : DataAccessor<StatisticTypeLookup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<StatisticTypeLookup>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsBaseReference"; } }
            #endregion
        
            public delegate void on_action(StatisticTypeLookup obj);
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
            
            public virtual List<StatisticTypeLookup> SelectLookupList(DbManagerProxy manager
                )
            {
                return _SelectList(manager
                    , null, null
                    );
            }
            
            public virtual List<StatisticTypeLookup> SelectList(DbManagerProxy manager
                )
            {
                return _SelectList(manager
                    , delegate(StatisticTypeLookup obj)
                        {
                        }
                    , delegate(StatisticTypeLookup obj)
                        {
                        }
                    );
            }

            

            public List<StatisticTypeLookup> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<StatisticTypeLookup> _SelectListInternal(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
                StatisticTypeLookup _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<StatisticTypeLookup> objs = new List<StatisticTypeLookup>();
                    sets[0] = new MapResultSet(typeof(StatisticTypeLookup), objs);
                    
                    manager
                        .SetSpCommand("spStatisticType_SelectDetail"
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);
                    foreach(var obj in objs) 
                    {
                        _obj = obj;
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
                    throw DbModelException.Create(_obj, e);
                }
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, StatisticTypeLookup obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, StatisticTypeLookup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private StatisticTypeLookup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                StatisticTypeLookup obj = null;
                try
                {
                    obj = StatisticTypeLookup.CreateInstance();
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
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public StatisticTypeLookup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public StatisticTypeLookup CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public StatisticTypeLookup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(StatisticTypeLookup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(StatisticTypeLookup obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, StatisticTypeLookup obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(StatisticTypeLookup obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(StatisticTypeLookup obj, bool bRethrowException)
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
                return Validate(manager, obj as StatisticTypeLookup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, StatisticTypeLookup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(StatisticTypeLookup obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(StatisticTypeLookup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as StatisticTypeLookup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as StatisticTypeLookup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "StatisticTypeLookupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spStatisticType_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<StatisticTypeLookup, bool>> RequiredByField = new Dictionary<string, Func<StatisticTypeLookup, bool>>();
            public static Dictionary<string, Func<StatisticTypeLookup, bool>> RequiredByProperty = new Dictionary<string, Func<StatisticTypeLookup, bool>>();
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
                
                Sizes.Add(_str_strDefault, 2000);
                Sizes.Add(_str_name, 2000);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<StatisticTypeLookup>().Post(manager, (StatisticTypeLookup)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<StatisticTypeLookup>().Post(manager, (StatisticTypeLookup)c), c),
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
                    (manager, c, pars) => new ActResult(((StatisticTypeLookup)c).MarkToDelete() && ObjectAccessor.PostInterface<StatisticTypeLookup>().Post(manager, (StatisticTypeLookup)c), c),
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
	