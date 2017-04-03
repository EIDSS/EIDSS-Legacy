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
    public abstract partial class UsersAndGroupsListItem : 
        EditableObject<UsersAndGroupsListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfEmployee), NonUpdatable, PrimaryKey]
        public abstract Int64 idfEmployee { get; set; }
                
        [LocalizedDisplayName(_str_idfsEmployeeType)]
        [MapField(_str_idfsEmployeeType)]
        public abstract Int64 idfsEmployeeType { get; set; }
        protected Int64 idfsEmployeeType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsEmployeeType).OriginalValue; } }
        protected Int64 idfsEmployeeType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsEmployeeType).PreviousValue; } }
                
        [LocalizedDisplayName("UserGroupMember.EmployeeTypeName")]
        [MapField(_str_EmployeeTypeName)]
        public abstract String EmployeeTypeName { get; set; }
        protected String EmployeeTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._employeeTypeName).OriginalValue; } }
        protected String EmployeeTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._employeeTypeName).PreviousValue; } }
                
        [LocalizedDisplayName("UserGroupMember.strName")]
        [MapField(_str_strName)]
        public abstract String strName { get; set; }
        protected String strName_Original { get { return ((EditableValue<String>)((dynamic)this)._strName).OriginalValue; } }
        protected String strName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsOfficeAbbreviation)]
        [MapField(_str_idfsOfficeAbbreviation)]
        public abstract Int64? idfsOfficeAbbreviation { get; set; }
        protected Int64? idfsOfficeAbbreviation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOfficeAbbreviation).OriginalValue; } }
        protected Int64? idfsOfficeAbbreviation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOfficeAbbreviation).PreviousValue; } }
                
        [LocalizedDisplayName("UserGroupMember.OrganizationName")]
        [MapField(_str_OrganizationName)]
        public abstract String OrganizationName { get; set; }
        protected String OrganizationName_Original { get { return ((EditableValue<String>)((dynamic)this)._organizationName).OriginalValue; } }
        protected String OrganizationName_Previous { get { return ((EditableValue<String>)((dynamic)this)._organizationName).PreviousValue; } }
                
        [LocalizedDisplayName("UserGroupMember.strDescription")]
        [MapField(_str_strDescription)]
        public abstract String strDescription { get; set; }
        protected String strDescription_Original { get { return ((EditableValue<String>)((dynamic)this)._strDescription).OriginalValue; } }
        protected String strDescription_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDescription).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfEmployeeGroup)]
        [MapField(_str_idfEmployeeGroup)]
        public abstract Int64? idfEmployeeGroup { get; set; }
        protected Int64? idfEmployeeGroup_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfEmployeeGroup).OriginalValue; } }
        protected Int64? idfEmployeeGroup_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfEmployeeGroup).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<UsersAndGroupsListItem, object> _get_func;
            internal Action<UsersAndGroupsListItem, string> _set_func;
            internal Action<UsersAndGroupsListItem, UsersAndGroupsListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfEmployee = "idfEmployee";
        internal const string _str_idfsEmployeeType = "idfsEmployeeType";
        internal const string _str_EmployeeTypeName = "EmployeeTypeName";
        internal const string _str_strName = "strName";
        internal const string _str_idfsOfficeAbbreviation = "idfsOfficeAbbreviation";
        internal const string _str_OrganizationName = "OrganizationName";
        internal const string _str_strDescription = "strDescription";
        internal const string _str_idfEmployeeGroup = "idfEmployeeGroup";
        internal const string _str_EmployeeType = "EmployeeType";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfEmployee, _formname = _str_idfEmployee, _type = "Int64",
              _get_func = o => o.idfEmployee,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfEmployee != newval) o.idfEmployee = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfEmployee != c.idfEmployee || o.IsRIRPropChanged(_str_idfEmployee, c)) 
                  m.Add(_str_idfEmployee, o.ObjectIdent + _str_idfEmployee, o.ObjectIdent2 + _str_idfEmployee, o.ObjectIdent3 + _str_idfEmployee, "Int64", 
                    o.idfEmployee == null ? "" : o.idfEmployee.ToString(),                  
                  o.IsReadOnly(_str_idfEmployee), o.IsInvisible(_str_idfEmployee), o.IsRequired(_str_idfEmployee)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsEmployeeType, _formname = _str_idfsEmployeeType, _type = "Int64",
              _get_func = o => o.idfsEmployeeType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsEmployeeType != newval) 
                  o.EmployeeType = o.EmployeeTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsEmployeeType != newval) o.idfsEmployeeType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsEmployeeType != c.idfsEmployeeType || o.IsRIRPropChanged(_str_idfsEmployeeType, c)) 
                  m.Add(_str_idfsEmployeeType, o.ObjectIdent + _str_idfsEmployeeType, o.ObjectIdent2 + _str_idfsEmployeeType, o.ObjectIdent3 + _str_idfsEmployeeType, "Int64", 
                    o.idfsEmployeeType == null ? "" : o.idfsEmployeeType.ToString(),                  
                  o.IsReadOnly(_str_idfsEmployeeType), o.IsInvisible(_str_idfsEmployeeType), o.IsRequired(_str_idfsEmployeeType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_EmployeeTypeName, _formname = _str_EmployeeTypeName, _type = "String",
              _get_func = o => o.EmployeeTypeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.EmployeeTypeName != newval) o.EmployeeTypeName = newval; },
              _compare_func = (o, c, m) => {
                if (o.EmployeeTypeName != c.EmployeeTypeName || o.IsRIRPropChanged(_str_EmployeeTypeName, c)) 
                  m.Add(_str_EmployeeTypeName, o.ObjectIdent + _str_EmployeeTypeName, o.ObjectIdent2 + _str_EmployeeTypeName, o.ObjectIdent3 + _str_EmployeeTypeName, "String", 
                    o.EmployeeTypeName == null ? "" : o.EmployeeTypeName.ToString(),                  
                  o.IsReadOnly(_str_EmployeeTypeName), o.IsInvisible(_str_EmployeeTypeName), o.IsRequired(_str_EmployeeTypeName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strName, _formname = _str_strName, _type = "String",
              _get_func = o => o.strName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strName != newval) o.strName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strName != c.strName || o.IsRIRPropChanged(_str_strName, c)) 
                  m.Add(_str_strName, o.ObjectIdent + _str_strName, o.ObjectIdent2 + _str_strName, o.ObjectIdent3 + _str_strName, "String", 
                    o.strName == null ? "" : o.strName.ToString(),                  
                  o.IsReadOnly(_str_strName), o.IsInvisible(_str_strName), o.IsRequired(_str_strName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsOfficeAbbreviation, _formname = _str_idfsOfficeAbbreviation, _type = "Int64?",
              _get_func = o => o.idfsOfficeAbbreviation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsOfficeAbbreviation != newval) o.idfsOfficeAbbreviation = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsOfficeAbbreviation != c.idfsOfficeAbbreviation || o.IsRIRPropChanged(_str_idfsOfficeAbbreviation, c)) 
                  m.Add(_str_idfsOfficeAbbreviation, o.ObjectIdent + _str_idfsOfficeAbbreviation, o.ObjectIdent2 + _str_idfsOfficeAbbreviation, o.ObjectIdent3 + _str_idfsOfficeAbbreviation, "Int64?", 
                    o.idfsOfficeAbbreviation == null ? "" : o.idfsOfficeAbbreviation.ToString(),                  
                  o.IsReadOnly(_str_idfsOfficeAbbreviation), o.IsInvisible(_str_idfsOfficeAbbreviation), o.IsRequired(_str_idfsOfficeAbbreviation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_OrganizationName, _formname = _str_OrganizationName, _type = "String",
              _get_func = o => o.OrganizationName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.OrganizationName != newval) o.OrganizationName = newval; },
              _compare_func = (o, c, m) => {
                if (o.OrganizationName != c.OrganizationName || o.IsRIRPropChanged(_str_OrganizationName, c)) 
                  m.Add(_str_OrganizationName, o.ObjectIdent + _str_OrganizationName, o.ObjectIdent2 + _str_OrganizationName, o.ObjectIdent3 + _str_OrganizationName, "String", 
                    o.OrganizationName == null ? "" : o.OrganizationName.ToString(),                  
                  o.IsReadOnly(_str_OrganizationName), o.IsInvisible(_str_OrganizationName), o.IsRequired(_str_OrganizationName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDescription, _formname = _str_strDescription, _type = "String",
              _get_func = o => o.strDescription,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDescription != newval) o.strDescription = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDescription != c.strDescription || o.IsRIRPropChanged(_str_strDescription, c)) 
                  m.Add(_str_strDescription, o.ObjectIdent + _str_strDescription, o.ObjectIdent2 + _str_strDescription, o.ObjectIdent3 + _str_strDescription, "String", 
                    o.strDescription == null ? "" : o.strDescription.ToString(),                  
                  o.IsReadOnly(_str_strDescription), o.IsInvisible(_str_strDescription), o.IsRequired(_str_strDescription)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfEmployeeGroup, _formname = _str_idfEmployeeGroup, _type = "Int64?",
              _get_func = o => o.idfEmployeeGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfEmployeeGroup != newval) o.idfEmployeeGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfEmployeeGroup != c.idfEmployeeGroup || o.IsRIRPropChanged(_str_idfEmployeeGroup, c)) 
                  m.Add(_str_idfEmployeeGroup, o.ObjectIdent + _str_idfEmployeeGroup, o.ObjectIdent2 + _str_idfEmployeeGroup, o.ObjectIdent3 + _str_idfEmployeeGroup, "Int64?", 
                    o.idfEmployeeGroup == null ? "" : o.idfEmployeeGroup.ToString(),                  
                  o.IsReadOnly(_str_idfEmployeeGroup), o.IsInvisible(_str_idfEmployeeGroup), o.IsRequired(_str_idfEmployeeGroup)); 
                  }
              }, 
        
            new field_info {
              _name = _str_EmployeeType, _formname = _str_EmployeeType, _type = "Lookup",
              _get_func = o => { if (o.EmployeeType == null) return null; return o.EmployeeType.idfsBaseReference; },
              _set_func = (o, val) => { o.EmployeeType = o.EmployeeTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsEmployeeType != c.idfsEmployeeType || o.IsRIRPropChanged(_str_EmployeeType, c)) {
                  m.Add(_str_EmployeeType, o.ObjectIdent + _str_EmployeeType, o.ObjectIdent2 + _str_EmployeeType, o.ObjectIdent3 + _str_EmployeeType, "Lookup", o.idfsEmployeeType == null ? "" : o.idfsEmployeeType.ToString(), o.IsReadOnly(_str_EmployeeType), o.IsInvisible(_str_EmployeeType), o.IsRequired(_str_EmployeeType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_EmployeeType + "Lookup", _formname = _str_EmployeeType + "Lookup", _type = "LookupContent",
              _get_func = o => o.EmployeeTypeLookup,
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
            UsersAndGroupsListItem obj = (UsersAndGroupsListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_EmployeeType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsEmployeeType)]
        public BaseReference EmployeeType
        {
            get { return _EmployeeType == null ? null : ((long)_EmployeeType.Key == 0 ? null : _EmployeeType); }
            set 
            { 
                var oldVal = _EmployeeType;
                _EmployeeType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_EmployeeType != oldVal)
                {
                    if (idfsEmployeeType != (_EmployeeType == null
                            ? new Int64()
                            : (Int64)_EmployeeType.idfsBaseReference))
                        idfsEmployeeType = _EmployeeType == null 
                            ? new Int64()
                            : (Int64)_EmployeeType.idfsBaseReference; 
                    OnPropertyChanged(_str_EmployeeType); 
                }
            }
        }
        private BaseReference _EmployeeType;

        
        public BaseReferenceList EmployeeTypeLookup
        {
            get { return _EmployeeTypeLookup; }
        }
        private BaseReferenceList _EmployeeTypeLookup = new BaseReferenceList("rftEmployeeType");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_EmployeeType:
                    return new BvSelectList(EmployeeTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, EmployeeType, _str_idfsEmployeeType);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "UsersAndGroupsListItem";

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
            var ret = base.Clone() as UsersAndGroupsListItem;
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
            var ret = base.Clone() as UsersAndGroupsListItem;
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
        public UsersAndGroupsListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as UsersAndGroupsListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfEmployee; } }
        public string KeyName { get { return "idfEmployee"; } }
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
        
            var _prev_idfsEmployeeType_EmployeeType = idfsEmployeeType;
            base.RejectChanges();
        
            if (_prev_idfsEmployeeType_EmployeeType != idfsEmployeeType)
            {
                _EmployeeType = _EmployeeTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsEmployeeType);
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

        private bool IsRIRPropChanged(string fld, UsersAndGroupsListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public UsersAndGroupsListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(UsersAndGroupsListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(UsersAndGroupsListItem_PropertyChanged);
        }
        private void UsersAndGroupsListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as UsersAndGroupsListItem).Changed(e.PropertyName);
            
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
            UsersAndGroupsListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            UsersAndGroupsListItem obj = this;
            
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


        internal Dictionary<string, Func<UsersAndGroupsListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<UsersAndGroupsListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<UsersAndGroupsListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<UsersAndGroupsListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<UsersAndGroupsListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<UsersAndGroupsListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<UsersAndGroupsListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~UsersAndGroupsListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftEmployeeType", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftEmployeeType")
                _getAccessor().LoadLookup_EmployeeType(manager, this);
            
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
        public class UsersAndGroupsListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfEmployee { get; set; }
        
            public String EmployeeTypeName { get; set; }
        
            public String strName { get; set; }
        
            public String OrganizationName { get; set; }
        
            public String strDescription { get; set; }
        
        }
        public partial class UsersAndGroupsListItemGridModelList : List<UsersAndGroupsListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public UsersAndGroupsListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<UsersAndGroupsListItem>, errMes);
            }
            public UsersAndGroupsListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<UsersAndGroupsListItem>, errMes);
            }
            public UsersAndGroupsListItemGridModelList(long key, IEnumerable<UsersAndGroupsListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public UsersAndGroupsListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<UsersAndGroupsListItem>(), null);
            }
            partial void filter(List<UsersAndGroupsListItem> items);
            private void LoadGridModelList(long key, IEnumerable<UsersAndGroupsListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_EmployeeTypeName,_str_strName,_str_OrganizationName,_str_strDescription};
                    
                Hiddens = new List<string> {_str_idfEmployee};
                Keys = new List<string> {_str_idfEmployee};
                Labels = new Dictionary<string, string> {{_str_EmployeeTypeName, "UserGroupMember.EmployeeTypeName"},{_str_strName, "UserGroupMember.strName"},{_str_OrganizationName, "UserGroupMember.OrganizationName"},{_str_strDescription, "UserGroupMember.strDescription"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                UsersAndGroupsListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<UsersAndGroupsListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new UsersAndGroupsListItemGridModel()
                {
                    ItemKey=c.idfEmployee,EmployeeTypeName=c.EmployeeTypeName,strName=c.strName,OrganizationName=c.OrganizationName,strDescription=c.strDescription
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
        : DataAccessor<UsersAndGroupsListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<UsersAndGroupsListItem>
            
            , IObjectSelectList
            , IObjectSelectList<UsersAndGroupsListItem>
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfEmployee"; } }
            #endregion
        
            private delegate void on_action(UsersAndGroupsListItem obj);
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
            private BaseReference.Accessor EmployeeTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<UsersAndGroupsListItem> SelectListT(DbManagerProxy manager
                , FilterParams filters = null
                , KeyValuePair<string, ListSortDirection>[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager
                , null, null
                , filters
                , sorts
                , serverSort
                );
            }
            public virtual List<IObject> SelectList(DbManagerProxy manager
                , FilterParams filters = null
                , KeyValuePair<string, ListSortDirection>[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager
                , null, null
                , filters
                , sorts
                , serverSort
                ).Cast<IObject>().ToList();
            }
            
            private List<UsersAndGroupsListItem> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                , FilterParams filters
                , KeyValuePair<string, ListSortDirection>[] sorts
                , bool serverSort = false
                )
            {
                if (filters == null) filters = new FilterParams();
                
                var sql = new StringBuilder();
                string maxtop = BaseSettings.SelectTopMaxCount.ToString();
                sql.Append(@"select ");
                
                sql.Append(@"top ");
                sql.Append(maxtop);
                sql.Append(@" dbo.fn_UsersAndGroups_SelectList.* from dbo.fn_UsersAndGroups_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfEmployee"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfEmployee"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfEmployee") ? " or " : " and ");
                        
                        if (filters.Operation("idfEmployee", i) == "&")
                          sql.AppendFormat("(isnull(fn_UsersAndGroups_SelectList.idfEmployee,0) {0} @idfEmployee_{1} = @idfEmployee_{1})", filters.Operation("idfEmployee", i), i);
                        else
                          sql.AppendFormat("isnull(fn_UsersAndGroups_SelectList.idfEmployee,0) {0} @idfEmployee_{1}", filters.Operation("idfEmployee", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsEmployeeType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsEmployeeType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsEmployeeType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsEmployeeType", i) == "&")
                          sql.AppendFormat("(isnull(fn_UsersAndGroups_SelectList.idfsEmployeeType,0) {0} @idfsEmployeeType_{1} = @idfsEmployeeType_{1})", filters.Operation("idfsEmployeeType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_UsersAndGroups_SelectList.idfsEmployeeType,0) {0} @idfsEmployeeType_{1}", filters.Operation("idfsEmployeeType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("EmployeeTypeName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("EmployeeTypeName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("EmployeeTypeName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_UsersAndGroups_SelectList.EmployeeTypeName {0} @EmployeeTypeName_{1}", filters.Operation("EmployeeTypeName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_UsersAndGroups_SelectList.strName {0} @strName_{1}", filters.Operation("strName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsOfficeAbbreviation"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsOfficeAbbreviation"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsOfficeAbbreviation") ? " or " : " and ");
                        
                        if (filters.Operation("idfsOfficeAbbreviation", i) == "&")
                          sql.AppendFormat("(isnull(fn_UsersAndGroups_SelectList.idfsOfficeAbbreviation,0) {0} @idfsOfficeAbbreviation_{1} = @idfsOfficeAbbreviation_{1})", filters.Operation("idfsOfficeAbbreviation", i), i);
                        else
                          sql.AppendFormat("isnull(fn_UsersAndGroups_SelectList.idfsOfficeAbbreviation,0) {0} @idfsOfficeAbbreviation_{1}", filters.Operation("idfsOfficeAbbreviation", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("OrganizationName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("OrganizationName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("OrganizationName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_UsersAndGroups_SelectList.OrganizationName {0} @OrganizationName_{1}", filters.Operation("OrganizationName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strDescription"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strDescription"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strDescription") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_UsersAndGroups_SelectList.strDescription {0} @strDescription_{1}", filters.Operation("strDescription", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfEmployeeGroup"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfEmployeeGroup"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfEmployeeGroup") ? " or " : " and ");
                        
                        if (filters.Operation("idfEmployeeGroup", i) == "&")
                          sql.AppendFormat("(isnull(fn_UsersAndGroups_SelectList.idfEmployeeGroup,0) {0} @idfEmployeeGroup_{1} = @idfEmployeeGroup_{1})", filters.Operation("idfEmployeeGroup", i), i);
                        else
                          sql.AppendFormat("isnull(fn_UsersAndGroups_SelectList.idfEmployeeGroup,0) {0} @idfEmployeeGroup_{1}", filters.Operation("idfEmployeeGroup", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (serverSort && sorts != null && sorts.Length > 0)
                {
                    sql.Append(" order by");
                    bool bFirst = true;
                    foreach(var sort in sorts)
                    {
                        sql.Append((bFirst ? " " : ", ") + sort.Key + " " + (sort.Value == ListSortDirection.Ascending ? "ASC" : "DESC"));
                        bFirst = false;
                    }
                }

                bool bTransactionStarted = false;
                try
                {
                    if (!manager.IsTransactionStarted)
                    {
                        bTransactionStarted = true;
                        manager.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                    }
                    
                    sql.Append(" option (OPTIMIZE FOR UNKNOWN)");
                    manager
                        .SetCommand(sql.ToString()
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                        );
                    
                    if (filters.Contains("idfEmployee"))
                        for (int i = 0; i < filters.Count("idfEmployee"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfEmployee_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfEmployee", i), filters.Value("idfEmployee", i))));
                      
                    if (filters.Contains("idfsEmployeeType"))
                        for (int i = 0; i < filters.Count("idfsEmployeeType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsEmployeeType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsEmployeeType", i), filters.Value("idfsEmployeeType", i))));
                      
                    if (filters.Contains("EmployeeTypeName"))
                        for (int i = 0; i < filters.Count("EmployeeTypeName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@EmployeeTypeName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("EmployeeTypeName", i), filters.Value("EmployeeTypeName", i))));
                      
                    if (filters.Contains("strName"))
                        for (int i = 0; i < filters.Count("strName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strName", i), filters.Value("strName", i))));
                      
                    if (filters.Contains("idfsOfficeAbbreviation"))
                        for (int i = 0; i < filters.Count("idfsOfficeAbbreviation"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsOfficeAbbreviation_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsOfficeAbbreviation", i), filters.Value("idfsOfficeAbbreviation", i))));
                      
                    if (filters.Contains("OrganizationName"))
                        for (int i = 0; i < filters.Count("OrganizationName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@OrganizationName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("OrganizationName", i), filters.Value("OrganizationName", i))));
                      
                    if (filters.Contains("strDescription"))
                        for (int i = 0; i < filters.Count("strDescription"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strDescription_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strDescription", i), filters.Value("strDescription", i))));
                      
                    if (filters.Contains("idfEmployeeGroup"))
                        for (int i = 0; i < filters.Count("idfEmployeeGroup"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfEmployeeGroup_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfEmployeeGroup", i), filters.Value("idfEmployeeGroup", i))));
                      
                    List<UsersAndGroupsListItem> objs = manager.ExecuteList<UsersAndGroupsListItem>();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                    }
                    ListSelected(manager, objs);
                    return objs;
                }
                catch(DataException e)
                {
                    if (bTransactionStarted)
                    {
                        manager.RollbackTransaction();
                    }
                    throw DbModelException.Create(e);
                }
            }
            partial void ListSelected(DbManagerProxy manager, List<UsersAndGroupsListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spUsersAndGroups_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, UsersAndGroupsListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, UsersAndGroupsListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private UsersAndGroupsListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    UsersAndGroupsListItem obj = UsersAndGroupsListItem.CreateInstance();
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

            
            public UsersAndGroupsListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public UsersAndGroupsListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public UsersAndGroupsListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(UsersAndGroupsListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(UsersAndGroupsListItem obj)
            {
                
            }
    
            public void LoadLookup_EmployeeType(DbManagerProxy manager, UsersAndGroupsListItem obj)
            {
                
                obj.EmployeeTypeLookup.Clear();
                
                obj.EmployeeTypeLookup.Add(EmployeeTypeAccessor.CreateNewT(manager, null));
                
                obj.EmployeeTypeLookup.AddRange(EmployeeTypeAccessor.rftEmployeeType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsEmployeeType))
                    
                    .ToList());
                
                if (obj.idfsEmployeeType != 0)
                {
                    obj.EmployeeType = obj.EmployeeTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsEmployeeType);
                    
                }
              
                
                LookupManager.AddObject("rftEmployeeType", obj, EmployeeTypeAccessor.GetType(), "rftEmployeeType_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, UsersAndGroupsListItem obj)
            {
                
                LoadLookup_EmployeeType(manager, obj);
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(UsersAndGroupsListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(UsersAndGroupsListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as UsersAndGroupsListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, UsersAndGroupsListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("UserGroup.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("UserGroup.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("UserGroup.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("UserGroup.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(UsersAndGroupsListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(UsersAndGroupsListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as UsersAndGroupsListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as UsersAndGroupsListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "UsersAndGroupsListItemDetail"; } }
            public string HelpIdWin { get { return "Access_Rights_Management"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private UsersAndGroupsListItem m_obj;
            internal Permissions(UsersAndGroupsListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("UserGroup.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("UserGroup.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("UserGroup.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("UserGroup.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_UsersAndGroups_SelectList";
            public static string spCount = "spUsersAndGroups_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<UsersAndGroupsListItem, bool>> RequiredByField = new Dictionary<string, Func<UsersAndGroupsListItem, bool>>();
            public static Dictionary<string, Func<UsersAndGroupsListItem, bool>> RequiredByProperty = new Dictionary<string, Func<UsersAndGroupsListItem, bool>>();
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
                
                Sizes.Add(_str_EmployeeTypeName, 2000);
                Sizes.Add(_str_strName, 2000);
                Sizes.Add(_str_OrganizationName, 2000);
                Sizes.Add(_str_strDescription, 200);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsEmployeeType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "Type",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "EmployeeTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "OrganizationName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "UserGroupMember.OrganizationName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strDescription",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strDescription",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfEmployee,
                    _str_idfEmployee, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_EmployeeTypeName,
                    "UserGroupMember.EmployeeTypeName", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strName,
                    "UserGroupMember.strName", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_OrganizationName,
                    "UserGroupMember.OrganizationName", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDescription,
                    "UserGroupMember.strDescription", null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "SelectAll",
                    ActionTypes.SelectAll,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelectAll_Id",
                        "selectall",
                        /*from BvMessages*/"tooltipSelectAll_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSelectAll_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
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
                    "Select",
                    ActionTypes.Select,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelect_Id",
                        "select",
                        /*from BvMessages*/"tooltipSelect_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSelect_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
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
                    "Refresh",
                    ActionTypes.Refresh,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strRefresh_Id",
                        "iconRefresh_Id",
                        /*from BvMessages*/"tooltipRefresh_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipRefresh_Id",
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
                    "Close",
                    ActionTypes.Close,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strClose_Id",
                        "Close",
                        /*from BvMessages*/"tooltipClose_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipClose_Id",
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
	