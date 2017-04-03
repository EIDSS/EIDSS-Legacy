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
    public abstract partial class UserGroupMember : 
        EditableObject<UserGroupMember>
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
                
        [LocalizedDisplayName(_str_idfEmployeeGroup)]
        [MapField(_str_idfEmployeeGroup)]
        public abstract Int64 idfEmployeeGroup { get; set; }
        protected Int64 idfEmployeeGroup_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfEmployeeGroup).OriginalValue; } }
        protected Int64 idfEmployeeGroup_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfEmployeeGroup).PreviousValue; } }
                
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
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<UserGroupMember, object> _get_func;
            internal Action<UserGroupMember, string> _set_func;
            internal Action<UserGroupMember, UserGroupMember, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfEmployee = "idfEmployee";
        internal const string _str_idfsEmployeeType = "idfsEmployeeType";
        internal const string _str_idfEmployeeGroup = "idfEmployeeGroup";
        internal const string _str_EmployeeTypeName = "EmployeeTypeName";
        internal const string _str_strName = "strName";
        internal const string _str_idfsOfficeAbbreviation = "idfsOfficeAbbreviation";
        internal const string _str_OrganizationName = "OrganizationName";
        internal const string _str_strDescription = "strDescription";
        internal const string _str_ID = "ID";
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
              _name = _str_idfEmployeeGroup, _formname = _str_idfEmployeeGroup, _type = "Int64",
              _get_func = o => o.idfEmployeeGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfEmployeeGroup != newval) o.idfEmployeeGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfEmployeeGroup != c.idfEmployeeGroup || o.IsRIRPropChanged(_str_idfEmployeeGroup, c)) 
                  m.Add(_str_idfEmployeeGroup, o.ObjectIdent + _str_idfEmployeeGroup, o.ObjectIdent2 + _str_idfEmployeeGroup, o.ObjectIdent3 + _str_idfEmployeeGroup, "Int64", 
                    o.idfEmployeeGroup == null ? "" : o.idfEmployeeGroup.ToString(),                  
                  o.IsReadOnly(_str_idfEmployeeGroup), o.IsInvisible(_str_idfEmployeeGroup), o.IsRequired(_str_idfEmployeeGroup)); 
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
              _name = _str_ID, _formname = _str_ID, _type = "long",
              _get_func = o => o.ID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.ID != newval) o.ID = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.ID != c.ID || o.IsRIRPropChanged(_str_ID, c)) {
                  m.Add(_str_ID, o.ObjectIdent + _str_ID, o.ObjectIdent2 + _str_ID, o.ObjectIdent3 + _str_ID,  "long", 
                    o.ID == null ? "" : o.ID.ToString(),                  
                    o.IsReadOnly(_str_ID), o.IsInvisible(_str_ID), o.IsRequired(_str_ID));
                  }
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
            UserGroupMember obj = (UserGroupMember)o;
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
    
          [LocalizedDisplayName(_str_ID)]
        public long ID
        {
            get { return m_ID; }
            set { if (m_ID != value) { m_ID = value; OnPropertyChanged(_str_ID); } }
        }
        private long m_ID;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "UserGroupMember";

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
            var ret = base.Clone() as UserGroupMember;
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
            var ret = base.Clone() as UserGroupMember;
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
        public UserGroupMember CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as UserGroupMember;
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

        private bool IsRIRPropChanged(string fld, UserGroupMember c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public UserGroupMember()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(UserGroupMember_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(UserGroupMember_PropertyChanged);
        }
        private void UserGroupMember_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as UserGroupMember).Changed(e.PropertyName);
            
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
            UserGroupMember obj = this;
            
        }
        private void _DeletedExtenders()
        {
            UserGroupMember obj = this;
            
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


        internal Dictionary<string, Func<UserGroupMember, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<UserGroupMember, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<UserGroupMember, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<UserGroupMember, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<UserGroupMember, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<UserGroupMember, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<UserGroupMember, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~UserGroupMember()
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
        public class UserGroupMemberGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public long ID { get; set; }
        
            public String EmployeeTypeName { get; set; }
        
            public String strName { get; set; }
        
            public String OrganizationName { get; set; }
        
            public String strDescription { get; set; }
        
        }
        public partial class UserGroupMemberGridModelList : List<UserGroupMemberGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public UserGroupMemberGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<UserGroupMember>, errMes);
            }
            public UserGroupMemberGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<UserGroupMember>, errMes);
            }
            public UserGroupMemberGridModelList(long key, IEnumerable<UserGroupMember> items)
            {
                LoadGridModelList(key, items, null);
            }
            public UserGroupMemberGridModelList(long key)
            {
                LoadGridModelList(key, new List<UserGroupMember>(), null);
            }
            partial void filter(List<UserGroupMember> items);
            private void LoadGridModelList(long key, IEnumerable<UserGroupMember> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_EmployeeTypeName,_str_strName,_str_OrganizationName,_str_strDescription};
                    
                Hiddens = new List<string> {_str_ID};
                Keys = new List<string> {_str_ID};
                Labels = new Dictionary<string, string> {{_str_EmployeeTypeName, "UserGroupMember.EmployeeTypeName"},{_str_strName, "UserGroupMember.strName"},{_str_OrganizationName, "UserGroupMember.OrganizationName"},{_str_strDescription, "UserGroupMember.strDescription"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                UserGroupMember.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<UserGroupMember>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new UserGroupMemberGridModel()
                {
                    ItemKey=c.ID,EmployeeTypeName=c.EmployeeTypeName,strName=c.strName,OrganizationName=c.OrganizationName,strDescription=c.strDescription
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
        : DataAccessor<UserGroupMember>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<UserGroupMember>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfEmployee"; } }
            #endregion
        
            private delegate void on_action(UserGroupMember obj);
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
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<UserGroupMember> SelectList(DbManagerProxy manager
                , Int64? idfEmployeeGroup
                )
            {
                return _SelectList(manager
                    , idfEmployeeGroup
                    , delegate(UserGroupMember obj)
                        {
                        }
                    , delegate(UserGroupMember obj)
                        {
                        }
                    );
            }

            
            private List<UserGroupMember> _SelectList(DbManagerProxy manager
                , Int64? idfEmployeeGroup
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<UserGroupMember> objs = new List<UserGroupMember>();
                    sets[0] = new MapResultSet(typeof(UserGroupMember), objs);
                    
                    manager
                        .SetSpCommand("spUserGroupMember_SelectDetail"
                            , manager.Parameter("@idfEmployeeGroup", idfEmployeeGroup)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, UserGroupMember obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, UserGroupMember obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private UserGroupMember _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    UserGroupMember obj = UserGroupMember.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.ID = (new AutoIncrementExtender<UserGroupMember>()).GetScalar(manager, obj, isFake);
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

            
            public UserGroupMember CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public UserGroupMember CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public UserGroupMember CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult AddGroupMember(DbManagerProxy manager, UserGroupMember obj, List<object> pars)
            {
                
                return AddGroupMember(manager, obj
                    );
            }
            public ActResult AddGroupMember(DbManagerProxy manager, UserGroupMember obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("AddGroupMember"))
                    throw new PermissionException("UserGroup", "AddGroupMember");
                
                return true;
                
            }
            
      
            public ActResult DeleteGroupMember(DbManagerProxy manager, UserGroupMember obj, List<object> pars)
            {
                
                return DeleteGroupMember(manager, obj
                    );
            }
            public ActResult DeleteGroupMember(DbManagerProxy manager, UserGroupMember obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("DeleteGroupMember"))
                    throw new PermissionException("UserGroup", "DeleteGroupMember");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(UserGroupMember obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(UserGroupMember obj)
            {
                
            }
    
            public void LoadLookup_EmployeeType(DbManagerProxy manager, UserGroupMember obj)
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
            

            private void _LoadLookups(DbManagerProxy manager, UserGroupMember obj)
            {
                
                LoadLookup_EmployeeType(manager, obj);
                
            }
    
            [SprocName("spUserGroupMember_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? idfEmployeeGroup
                , Int64? idfEmployee
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? idfEmployeeGroup
                , Int64? idfEmployee
                )
            {
                
                _postDelete(manager, idfEmployeeGroup, idfEmployee);
                
            }
        
            [SprocName("spUserGroupMember_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] UserGroupMember obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] UserGroupMember obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    UserGroupMember bo = obj as UserGroupMember;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("UserGroup", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("UserGroup", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("UserGroup", "Update");
                    }
                    
                    long mainObject = bo.idfEmployee;
                    
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoUser;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbEmployee;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as UserGroupMember, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, UserGroupMember obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postPredicate(manager, 8, obj);
                                
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(UserGroupMember obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, UserGroupMember obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(UserGroupMember obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(UserGroupMember obj, bool bRethrowException)
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
                return Validate(manager, obj as UserGroupMember, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, UserGroupMember obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
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
            
            private void _SetupRequired(UserGroupMember obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(UserGroupMember obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as UserGroupMember) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as UserGroupMember) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "UserGroupMemberDetail"; } }
            public string HelpIdWin { get { return "UserGroupForm"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private UserGroupMember m_obj;
            internal Permissions(UserGroupMember obj)
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
            public static string spSelect = "spUserGroupMember_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spUserGroupMember_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spUserGroupMember_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<UserGroupMember, bool>> RequiredByField = new Dictionary<string, Func<UserGroupMember, bool>>();
            public static Dictionary<string, Func<UserGroupMember, bool>> RequiredByProperty = new Dictionary<string, Func<UserGroupMember, bool>>();
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
                    _str_ID,
                    _str_ID, null, false, true, true, true, null
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
                    "AddGroupMember",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).AddGroupMember(manager, (UserGroupMember)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strAdd_Id",
                        "add",
                        /*from BvMessages*/"tooltipAdd_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    (c, p, b) => c != null ? (c.Environment != null ? !c.Environment.ReadOnly : !c.ReadOnly) : true && eidss.model.Core.EidssUserContext.User.HasPermission(bv.common.Core.PermissionHelper.UpdatePermission(eidss.model.Enums.EIDSSPermissionObject.UserGroup)),
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
                    "DeleteGroupMember",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).DeleteGroupMember(manager, (UserGroupMember)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "delete",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    (c, p, b) => c != null && !c.Key.Equals(PredefinedObjectId.FakeListObject)  && eidss.model.Core.EidssUserContext.User.HasPermission(bv.common.Core.PermissionHelper.UpdatePermission(eidss.model.Enums.EIDSSPermissionObject.UserGroup)),
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
	