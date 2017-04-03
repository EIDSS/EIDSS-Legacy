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
    public abstract partial class PersonListItem : 
        EditableObject<PersonListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfEmployee), NonUpdatable, PrimaryKey]
        public abstract Int64 idfEmployee { get; set; }
                
        [LocalizedDisplayName(_str_strFirstName)]
        [MapField(_str_strFirstName)]
        public abstract String strFirstName { get; set; }
        #if MONO
        protected String strFirstName_Original { get { return strFirstName; } }
        protected String strFirstName_Previous { get { return strFirstName; } }
        #else
        protected String strFirstName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).OriginalValue; } }
        protected String strFirstName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSecondName)]
        [MapField(_str_strSecondName)]
        public abstract String strSecondName { get; set; }
        #if MONO
        protected String strSecondName_Original { get { return strSecondName; } }
        protected String strSecondName_Previous { get { return strSecondName; } }
        #else
        protected String strSecondName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSecondName).OriginalValue; } }
        protected String strSecondName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSecondName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strLastName")]
        [MapField(_str_strFamilyName)]
        public abstract String strFamilyName { get; set; }
        #if MONO
        protected String strFamilyName_Original { get { return strFamilyName; } }
        protected String strFamilyName_Previous { get { return strFamilyName; } }
        #else
        protected String strFamilyName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFamilyName).OriginalValue; } }
        protected String strFamilyName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFamilyName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("Abbreviation")]
        [MapField(_str_Organization)]
        public abstract String Organization { get; set; }
        #if MONO
        protected String Organization_Original { get { return Organization; } }
        protected String Organization_Previous { get { return Organization; } }
        #else
        protected String Organization_Original { get { return ((EditableValue<String>)((dynamic)this)._organization).OriginalValue; } }
        protected String Organization_Previous { get { return ((EditableValue<String>)((dynamic)this)._organization).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("Organization.Name")]
        [MapField(_str_OrganizationFullName)]
        public abstract String OrganizationFullName { get; set; }
        #if MONO
        protected String OrganizationFullName_Original { get { return OrganizationFullName; } }
        protected String OrganizationFullName_Previous { get { return OrganizationFullName; } }
        #else
        protected String OrganizationFullName_Original { get { return ((EditableValue<String>)((dynamic)this)._organizationFullName).OriginalValue; } }
        protected String OrganizationFullName_Previous { get { return ((EditableValue<String>)((dynamic)this)._organizationFullName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfInstitution)]
        [MapField(_str_idfInstitution)]
        public abstract Int64? idfInstitution { get; set; }
        #if MONO
        protected Int64? idfInstitution_Original { get { return idfInstitution; } }
        protected Int64? idfInstitution_Previous { get { return idfInstitution; } }
        #else
        protected Int64? idfInstitution_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInstitution).OriginalValue; } }
        protected Int64? idfInstitution_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInstitution).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strRankName)]
        [MapField(_str_strRankName)]
        public abstract String strRankName { get; set; }
        #if MONO
        protected String strRankName_Original { get { return strRankName; } }
        protected String strRankName_Previous { get { return strRankName; } }
        #else
        protected String strRankName_Original { get { return ((EditableValue<String>)((dynamic)this)._strRankName).OriginalValue; } }
        protected String strRankName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRankName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfRankName)]
        [MapField(_str_idfRankName)]
        public abstract Int64? idfRankName { get; set; }
        #if MONO
        protected Int64? idfRankName_Original { get { return idfRankName; } }
        protected Int64? idfRankName_Previous { get { return idfRankName; } }
        #else
        protected Int64? idfRankName_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRankName).OriginalValue; } }
        protected Int64? idfRankName_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRankName).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<PersonListItem, object> _get_func;
            internal Action<PersonListItem, string> _set_func;
            internal Action<PersonListItem, PersonListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfEmployee = "idfEmployee";
        internal const string _str_strFirstName = "strFirstName";
        internal const string _str_strSecondName = "strSecondName";
        internal const string _str_strFamilyName = "strFamilyName";
        internal const string _str_Organization = "Organization";
        internal const string _str_OrganizationFullName = "OrganizationFullName";
        internal const string _str_idfInstitution = "idfInstitution";
        internal const string _str_strRankName = "strRankName";
        internal const string _str_idfRankName = "idfRankName";
        internal const string _str_Position = "Position";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfEmployee, _type = "Int64",
              _get_func = o => o.idfEmployee,
              _set_func = (o, val) => { o.idfEmployee = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfEmployee != c.idfEmployee || o.IsRIRPropChanged(_str_idfEmployee, c)) 
                  m.Add(_str_idfEmployee, o.ObjectIdent + _str_idfEmployee, "Int64", o.idfEmployee == null ? "" : o.idfEmployee.ToString(), o.IsReadOnly(_str_idfEmployee), o.IsInvisible(_str_idfEmployee), o.IsRequired(_str_idfEmployee)); }
              }, 
        
            new field_info {
              _name = _str_strFirstName, _type = "String",
              _get_func = o => o.strFirstName,
              _set_func = (o, val) => { o.strFirstName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFirstName != c.strFirstName || o.IsRIRPropChanged(_str_strFirstName, c)) 
                  m.Add(_str_strFirstName, o.ObjectIdent + _str_strFirstName, "String", o.strFirstName == null ? "" : o.strFirstName.ToString(), o.IsReadOnly(_str_strFirstName), o.IsInvisible(_str_strFirstName), o.IsRequired(_str_strFirstName)); }
              }, 
        
            new field_info {
              _name = _str_strSecondName, _type = "String",
              _get_func = o => o.strSecondName,
              _set_func = (o, val) => { o.strSecondName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSecondName != c.strSecondName || o.IsRIRPropChanged(_str_strSecondName, c)) 
                  m.Add(_str_strSecondName, o.ObjectIdent + _str_strSecondName, "String", o.strSecondName == null ? "" : o.strSecondName.ToString(), o.IsReadOnly(_str_strSecondName), o.IsInvisible(_str_strSecondName), o.IsRequired(_str_strSecondName)); }
              }, 
        
            new field_info {
              _name = _str_strFamilyName, _type = "String",
              _get_func = o => o.strFamilyName,
              _set_func = (o, val) => { o.strFamilyName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFamilyName != c.strFamilyName || o.IsRIRPropChanged(_str_strFamilyName, c)) 
                  m.Add(_str_strFamilyName, o.ObjectIdent + _str_strFamilyName, "String", o.strFamilyName == null ? "" : o.strFamilyName.ToString(), o.IsReadOnly(_str_strFamilyName), o.IsInvisible(_str_strFamilyName), o.IsRequired(_str_strFamilyName)); }
              }, 
        
            new field_info {
              _name = _str_Organization, _type = "String",
              _get_func = o => o.Organization,
              _set_func = (o, val) => { o.Organization = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.Organization != c.Organization || o.IsRIRPropChanged(_str_Organization, c)) 
                  m.Add(_str_Organization, o.ObjectIdent + _str_Organization, "String", o.Organization == null ? "" : o.Organization.ToString(), o.IsReadOnly(_str_Organization), o.IsInvisible(_str_Organization), o.IsRequired(_str_Organization)); }
              }, 
        
            new field_info {
              _name = _str_OrganizationFullName, _type = "String",
              _get_func = o => o.OrganizationFullName,
              _set_func = (o, val) => { o.OrganizationFullName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.OrganizationFullName != c.OrganizationFullName || o.IsRIRPropChanged(_str_OrganizationFullName, c)) 
                  m.Add(_str_OrganizationFullName, o.ObjectIdent + _str_OrganizationFullName, "String", o.OrganizationFullName == null ? "" : o.OrganizationFullName.ToString(), o.IsReadOnly(_str_OrganizationFullName), o.IsInvisible(_str_OrganizationFullName), o.IsRequired(_str_OrganizationFullName)); }
              }, 
        
            new field_info {
              _name = _str_idfInstitution, _type = "Int64?",
              _get_func = o => o.idfInstitution,
              _set_func = (o, val) => { o.idfInstitution = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfInstitution != c.idfInstitution || o.IsRIRPropChanged(_str_idfInstitution, c)) 
                  m.Add(_str_idfInstitution, o.ObjectIdent + _str_idfInstitution, "Int64?", o.idfInstitution == null ? "" : o.idfInstitution.ToString(), o.IsReadOnly(_str_idfInstitution), o.IsInvisible(_str_idfInstitution), o.IsRequired(_str_idfInstitution)); }
              }, 
        
            new field_info {
              _name = _str_strRankName, _type = "String",
              _get_func = o => o.strRankName,
              _set_func = (o, val) => { o.strRankName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strRankName != c.strRankName || o.IsRIRPropChanged(_str_strRankName, c)) 
                  m.Add(_str_strRankName, o.ObjectIdent + _str_strRankName, "String", o.strRankName == null ? "" : o.strRankName.ToString(), o.IsReadOnly(_str_strRankName), o.IsInvisible(_str_strRankName), o.IsRequired(_str_strRankName)); }
              }, 
        
            new field_info {
              _name = _str_idfRankName, _type = "Int64?",
              _get_func = o => o.idfRankName,
              _set_func = (o, val) => { o.idfRankName = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfRankName != c.idfRankName || o.IsRIRPropChanged(_str_idfRankName, c)) 
                  m.Add(_str_idfRankName, o.ObjectIdent + _str_idfRankName, "Int64?", o.idfRankName == null ? "" : o.idfRankName.ToString(), o.IsReadOnly(_str_idfRankName), o.IsInvisible(_str_idfRankName), o.IsRequired(_str_idfRankName)); }
              }, 
        
            new field_info {
              _name = _str_Position, _type = "Lookup",
              _get_func = o => { if (o.Position == null) return null; return o.Position.idfsBaseReference; },
              _set_func = (o, val) => { o.Position = o.PositionLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfRankName != c.idfRankName || o.IsRIRPropChanged(_str_Position, c)) 
                  m.Add(_str_Position, o.ObjectIdent + _str_Position, "Lookup", o.idfRankName == null ? "" : o.idfRankName.ToString(), o.IsReadOnly(_str_Position), o.IsInvisible(_str_Position), o.IsRequired(_str_Position)); }
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
            PersonListItem obj = (PersonListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfRankName)]
        public BaseReference Position
        {
            get { return _Position == null ? null : ((long)_Position.Key == 0 ? null : _Position); }
            set 
            { 
                _Position = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfRankName = _Position == null 
                    ? new Int64?()
                    : _Position.idfsBaseReference; 
                OnPropertyChanged(_str_Position); 
            }
        }
        private BaseReference _Position;

        
        public BaseReferenceList PositionLookup
        {
            get { return _PositionLookup; }
        }
        private BaseReferenceList _PositionLookup = new BaseReferenceList("rftPosition");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Position:
                    return new BvSelectList(PositionLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Position, _str_idfRankName);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "PersonListItem";

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
            var ret = base.Clone() as PersonListItem;
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
            var ret = base.Clone() as PersonListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public PersonListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as PersonListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfEmployee; } }
        public string KeyName { get { return "idfEmployee"; } }
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
        
            var _prev_idfRankName_Position = idfRankName;
            base.RejectChanges();
        
            if (_prev_idfRankName_Position != idfRankName)
            {
                _Position = _PositionLookup.FirstOrDefault(c => c.idfsBaseReference == idfRankName);
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
          return null;
        }
      #endregion

      private bool IsRIRPropChanged(string fld, PersonListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public PersonListItem()
        {
            
            m_permissions = new Permissions(this);
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(PersonListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(PersonListItem_PropertyChanged);
        }
        private void PersonListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as PersonListItem).Changed(e.PropertyName);
            
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
            PersonListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            PersonListItem obj = this;
            
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


        public Dictionary<string, Func<PersonListItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<PersonListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<PersonListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<PersonListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<PersonListItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<PersonListItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~PersonListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftPosition", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftPosition")
                _getAccessor().LoadLookup_Position(manager, this);
            
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
        public class PersonListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfEmployee { get; set; }
        
            public String Organization { get; set; }
        
            public String OrganizationFullName { get; set; }
        
            public String strRankName { get; set; }
        
            public String strFamilyName { get; set; }
        
            public String strFirstName { get; set; }
        
            public String strSecondName { get; set; }
        
        }
        public partial class PersonListItemGridModelList : List<PersonListItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public PersonListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<PersonListItem>, errMes);
            }
            public PersonListItemGridModelList(long key, IEnumerable<PersonListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<PersonListItem> items);
            private void LoadGridModelList(long key, IEnumerable<PersonListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_Organization,_str_OrganizationFullName,_str_strRankName,_str_strFamilyName,_str_strFirstName,_str_strSecondName};
                    
                Hiddens = new List<string> {_str_idfEmployee};
                Keys = new List<string> {_str_idfEmployee};
                Labels = new Dictionary<string, string> {{_str_Organization, "Abbreviation"},{_str_OrganizationFullName, "Organization.Name"},{_str_strRankName, _str_strRankName},{_str_strFamilyName, "strLastName"},{_str_strFirstName, _str_strFirstName},{_str_strSecondName, _str_strSecondName}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<PersonListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new PersonListItemGridModel()
                {
                    ItemKey=c.idfEmployee,Organization=c.Organization,OrganizationFullName=c.OrganizationFullName,strRankName=c.strRankName,strFamilyName=c.strFamilyName,strFirstName=c.strFirstName,strSecondName=c.strSecondName
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
        : DataAccessor<PersonListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectList
                    
            , IObjectPost
                    
        {
            private delegate void on_action(PersonListItem obj);
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
            private BaseReference.Accessor PositionAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<PersonListItem> SelectListT(DbManagerProxy manager
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
            
            private List<PersonListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_Person_SelectList.* from dbo.fn_Person_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfEmployee"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfEmployee"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfEmployee") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Person_SelectList.idfEmployee,0) {0} @idfEmployee_{1}", filters.Operation("idfEmployee", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFirstName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFirstName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFirstName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Person_SelectList.strFirstName {0} @strFirstName_{1}", filters.Operation("strFirstName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSecondName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSecondName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSecondName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Person_SelectList.strSecondName {0} @strSecondName_{1}", filters.Operation("strSecondName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFamilyName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFamilyName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFamilyName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Person_SelectList.strFamilyName {0} @strFamilyName_{1}", filters.Operation("strFamilyName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("Organization"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("Organization"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("Organization") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Person_SelectList.Organization {0} @Organization_{1}", filters.Operation("Organization", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("OrganizationFullName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("OrganizationFullName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("OrganizationFullName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Person_SelectList.OrganizationFullName {0} @OrganizationFullName_{1}", filters.Operation("OrganizationFullName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfInstitution"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfInstitution"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfInstitution") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Person_SelectList.idfInstitution,0) {0} @idfInstitution_{1}", filters.Operation("idfInstitution", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strRankName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strRankName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strRankName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Person_SelectList.strRankName {0} @strRankName_{1}", filters.Operation("strRankName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfRankName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfRankName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfRankName") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Person_SelectList.idfRankName,0) {0} @idfRankName_{1}", filters.Operation("idfRankName", i), i);
                            
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
                    manager
                        .SetCommand(sql.ToString()
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                        );
                    
                    if (filters.Contains("idfEmployee"))
                        for (int i = 0; i < filters.Count("idfEmployee"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfEmployee_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfEmployee", i), filters.Value("idfEmployee", i))));
                      
                    if (filters.Contains("strFirstName"))
                        for (int i = 0; i < filters.Count("strFirstName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFirstName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFirstName", i), filters.Value("strFirstName", i))));
                      
                    if (filters.Contains("strSecondName"))
                        for (int i = 0; i < filters.Count("strSecondName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSecondName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSecondName", i), filters.Value("strSecondName", i))));
                      
                    if (filters.Contains("strFamilyName"))
                        for (int i = 0; i < filters.Count("strFamilyName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFamilyName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFamilyName", i), filters.Value("strFamilyName", i))));
                      
                    if (filters.Contains("Organization"))
                        for (int i = 0; i < filters.Count("Organization"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@Organization_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("Organization", i), filters.Value("Organization", i))));
                      
                    if (filters.Contains("OrganizationFullName"))
                        for (int i = 0; i < filters.Count("OrganizationFullName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@OrganizationFullName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("OrganizationFullName", i), filters.Value("OrganizationFullName", i))));
                      
                    if (filters.Contains("idfInstitution"))
                        for (int i = 0; i < filters.Count("idfInstitution"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfInstitution_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfInstitution", i), filters.Value("idfInstitution", i))));
                      
                    if (filters.Contains("strRankName"))
                        for (int i = 0; i < filters.Count("strRankName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strRankName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strRankName", i), filters.Value("strRankName", i))));
                      
                    if (filters.Contains("idfRankName"))
                        for (int i = 0; i < filters.Count("idfRankName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfRankName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfRankName", i), filters.Value("idfRankName", i))));
                      
                    List<PersonListItem> objs = manager.ExecuteList<PersonListItem>();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                    }
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
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spPerson_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, PersonListItem obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, PersonListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private PersonListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    PersonListItem obj = PersonListItem.CreateInstance();
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

            
            public PersonListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public PersonListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(PersonListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(PersonListItem obj)
            {
                
            }
    
            public void LoadLookup_Position(DbManagerProxy manager, PersonListItem obj)
            {
                
                obj.PositionLookup.Clear();
                
                obj.PositionLookup.Add(PositionAccessor.CreateNewT(manager, null));
                
                obj.PositionLookup.AddRange(PositionAccessor.rftPosition_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfRankName))
                    
                    .ToList());
                
                if (obj.idfRankName != null && obj.idfRankName != 0)
                {
                    obj.Position = obj.PositionLookup
                        .Where(c => c.idfsBaseReference == obj.idfRankName)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftPosition", obj, PositionAccessor.GetType(), "rftPosition_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, PersonListItem obj)
            {
                
                LoadLookup_Position(manager, obj);
                
            }
    
            [SprocName("spPerson_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spPerson_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? idfPerson
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? idfPerson
                )
            {
                
                _postDelete(manager, idfPerson);
                
            }
        
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    PersonListItem bo = obj as PersonListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("Person", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("Person", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("Person", "Update");
                    }
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        long mainObject = bo.idfEmployee;
                        
                        eidss.model.Enums.EventType eventType = eidss.model.Enums.EventType.ReferenceTableChanged;
                        manager.SetEventParams("ReferenceTableChanged", new object[] { eventType, null, "Person" });
                        
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoPerson;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbPerson;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as PersonListItem, bChildObject);
                    if (bTransactionStarted)
                    {
                        if (bSuccess)
                        {
                            manager.CommitTransaction();
                            
                            LookupManager.ClearByTable("Person");
                            
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
            private bool _PostNonTransaction(DbManagerProxy manager, PersonListItem obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfEmployee
                        );
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(PersonListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, PersonListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfEmployee
                            , out result
                            );
                        if (!result) 
                        {
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, false);
                        }
                     }
                }
                catch(ValidationModelException ex)
                {
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                        return false;
                    }
                    else
                        obj.m_IsForcedToDelete = true;
                }
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as PersonListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, PersonListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(PersonListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(PersonListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as PersonListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as PersonListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "PersonListItemDetail"; } }
            public string HelpIdWin { get { return "EmployeeDetailForm"; } }
            public string HelpIdWeb { get { return "web_persons"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private PersonListItem m_obj;
            internal Permissions(PersonListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_Person_SelectList";
            public static string spCount = "spPerson_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spPerson_Delete";
            public static string spCanDelete = "spPerson_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<PersonListItem, bool>> RequiredByField = new Dictionary<string, Func<PersonListItem, bool>>();
            public static Dictionary<string, Func<PersonListItem, bool>> RequiredByProperty = new Dictionary<string, Func<PersonListItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strFirstName, 200);
                Sizes.Add(_str_strSecondName, 200);
                Sizes.Add(_str_strFamilyName, 200);
                Sizes.Add(_str_Organization, 2000);
                Sizes.Add(_str_OrganizationFullName, 2000);
                Sizes.Add(_str_strRankName, 2000);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfRankName",
                    EditorType.Lookup,
                    false, false, 
                    "strRankName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "PositionLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFamilyName",
                    EditorType.Text,
                    false, false, 
                    "strLastName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFirstName",
                    EditorType.Text,
                    false, false, 
                    "strFirstName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strSecondName",
                    EditorType.Text,
                    false, false, 
                    "strSecondName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfEmployee,
                    _str_idfEmployee, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Organization,
                    "Abbreviation", null, true, true, ListSortDirection.Ascending
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_OrganizationFullName,
                    "Organization.Name", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRankName,
                    _str_strRankName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFamilyName,
                    "strLastName", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFirstName,
                    _str_strFirstName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSecondName,
                    _str_strSecondName, null, true, true, null
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
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<Person>().CreateNew(manager, null, pars == null ? null : (int?)pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
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
                    "Edit",
                    ActionTypes.Edit,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<Person>().SelectDetail(manager, pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strEdit_Id",
                        "edit",
                        /*from BvMessages*/"tooltipEdit_Id",
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"tooltipEdit_Id",
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
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => 
                        {
                            if (c == null)
                            {
                                c = ObjectAccessor.CreatorInterface<PersonListItem>().CreateWithParams(manager, null, pars);
                                ((PersonListItem)c).idfEmployee = (long)pars[0];
                                ((PersonListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((PersonListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<PersonListItem>().Post(manager, (PersonListItem)c), c);
                        }
                                            ,
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	