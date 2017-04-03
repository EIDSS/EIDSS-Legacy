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
    public abstract partial class UserGroupDetail : 
        EditableObject<UserGroupDetail>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfEmployeeGroup), NonUpdatable, PrimaryKey]
        public abstract Int64 idfEmployeeGroup { get; set; }
                
        [LocalizedDisplayName(_str_idfsEmployeeGroupName)]
        [MapField(_str_idfsEmployeeGroupName)]
        public abstract Int64? idfsEmployeeGroupName { get; set; }
        #if MONO
        protected Int64? idfsEmployeeGroupName_Original { get { return idfsEmployeeGroupName; } }
        protected Int64? idfsEmployeeGroupName_Previous { get { return idfsEmployeeGroupName; } }
        #else
        protected Int64? idfsEmployeeGroupName_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEmployeeGroupName).OriginalValue; } }
        protected Int64? idfsEmployeeGroupName_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEmployeeGroupName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strGroupName)]
        [MapField(_str_strGroupName)]
        public abstract String strGroupName { get; set; }
        #if MONO
        protected String strGroupName_Original { get { return strGroupName; } }
        protected String strGroupName_Previous { get { return strGroupName; } }
        #else
        protected String strGroupName_Original { get { return ((EditableValue<String>)((dynamic)this)._strGroupName).OriginalValue; } }
        protected String strGroupName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strGroupName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strNationalGroupName)]
        [MapField(_str_strNationalGroupName)]
        public abstract String strNationalGroupName { get; set; }
        #if MONO
        protected String strNationalGroupName_Original { get { return strNationalGroupName; } }
        protected String strNationalGroupName_Previous { get { return strNationalGroupName; } }
        #else
        protected String strNationalGroupName_Original { get { return ((EditableValue<String>)((dynamic)this)._strNationalGroupName).OriginalValue; } }
        protected String strNationalGroupName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNationalGroupName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64 idfsSite { get; set; }
        #if MONO
        protected Int64 idfsSite_Original { get { return idfsSite; } }
        protected Int64 idfsSite_Previous { get { return idfsSite; } }
        #else
        protected Int64 idfsSite_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64 idfsSite_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSiteID)]
        [MapField(_str_strSiteID)]
        public abstract String strSiteID { get; set; }
        #if MONO
        protected String strSiteID_Original { get { return strSiteID; } }
        protected String strSiteID_Previous { get { return strSiteID; } }
        #else
        protected String strSiteID_Original { get { return ((EditableValue<String>)((dynamic)this)._strSiteID).OriginalValue; } }
        protected String strSiteID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSiteID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strDescription)]
        [MapField(_str_strDescription)]
        public abstract String strDescription { get; set; }
        #if MONO
        protected String strDescription_Original { get { return strDescription; } }
        protected String strDescription_Previous { get { return strDescription; } }
        #else
        protected String strDescription_Original { get { return ((EditableValue<String>)((dynamic)this)._strDescription).OriginalValue; } }
        protected String strDescription_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDescription).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<UserGroupDetail, object> _get_func;
            internal Action<UserGroupDetail, string> _set_func;
            internal Action<UserGroupDetail, UserGroupDetail, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfEmployeeGroup = "idfEmployeeGroup";
        internal const string _str_idfsEmployeeGroupName = "idfsEmployeeGroupName";
        internal const string _str_strGroupName = "strGroupName";
        internal const string _str_strNationalGroupName = "strNationalGroupName";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_strSiteID = "strSiteID";
        internal const string _str_strDescription = "strDescription";
        internal const string _str_ObjectAccessListFiltered = "ObjectAccessListFiltered";
        internal const string _str_idfsOASite = "idfsOASite";
        internal const string _str_Site = "Site";
        internal const string _str_UserGroupMemberList = "UserGroupMemberList";
        internal const string _str_ObjectAccessList = "ObjectAccessList";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfEmployeeGroup, _type = "Int64",
              _get_func = o => o.idfEmployeeGroup,
              _set_func = (o, val) => { o.idfEmployeeGroup = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfEmployeeGroup != c.idfEmployeeGroup || o.IsRIRPropChanged(_str_idfEmployeeGroup, c)) 
                  m.Add(_str_idfEmployeeGroup, o.ObjectIdent + _str_idfEmployeeGroup, "Int64", o.idfEmployeeGroup == null ? "" : o.idfEmployeeGroup.ToString(), o.IsReadOnly(_str_idfEmployeeGroup), o.IsInvisible(_str_idfEmployeeGroup), o.IsRequired(_str_idfEmployeeGroup)); }
              }, 
        
            new field_info {
              _name = _str_idfsEmployeeGroupName, _type = "Int64?",
              _get_func = o => o.idfsEmployeeGroupName,
              _set_func = (o, val) => { o.idfsEmployeeGroupName = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsEmployeeGroupName != c.idfsEmployeeGroupName || o.IsRIRPropChanged(_str_idfsEmployeeGroupName, c)) 
                  m.Add(_str_idfsEmployeeGroupName, o.ObjectIdent + _str_idfsEmployeeGroupName, "Int64?", o.idfsEmployeeGroupName == null ? "" : o.idfsEmployeeGroupName.ToString(), o.IsReadOnly(_str_idfsEmployeeGroupName), o.IsInvisible(_str_idfsEmployeeGroupName), o.IsRequired(_str_idfsEmployeeGroupName)); }
              }, 
        
            new field_info {
              _name = _str_strGroupName, _type = "String",
              _get_func = o => o.strGroupName,
              _set_func = (o, val) => { o.strGroupName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strGroupName != c.strGroupName || o.IsRIRPropChanged(_str_strGroupName, c)) 
                  m.Add(_str_strGroupName, o.ObjectIdent + _str_strGroupName, "String", o.strGroupName == null ? "" : o.strGroupName.ToString(), o.IsReadOnly(_str_strGroupName), o.IsInvisible(_str_strGroupName), o.IsRequired(_str_strGroupName)); }
              }, 
        
            new field_info {
              _name = _str_strNationalGroupName, _type = "String",
              _get_func = o => o.strNationalGroupName,
              _set_func = (o, val) => { o.strNationalGroupName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNationalGroupName != c.strNationalGroupName || o.IsRIRPropChanged(_str_strNationalGroupName, c)) 
                  m.Add(_str_strNationalGroupName, o.ObjectIdent + _str_strNationalGroupName, "String", o.strNationalGroupName == null ? "" : o.strNationalGroupName.ToString(), o.IsReadOnly(_str_strNationalGroupName), o.IsInvisible(_str_strNationalGroupName), o.IsRequired(_str_strNationalGroupName)); }
              }, 
        
            new field_info {
              _name = _str_idfsSite, _type = "Int64",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { o.idfsSite = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_idfsSite, c)) 
                  m.Add(_str_idfsSite, o.ObjectIdent + _str_idfsSite, "Int64", o.idfsSite == null ? "" : o.idfsSite.ToString(), o.IsReadOnly(_str_idfsSite), o.IsInvisible(_str_idfsSite), o.IsRequired(_str_idfsSite)); }
              }, 
        
            new field_info {
              _name = _str_strSiteID, _type = "String",
              _get_func = o => o.strSiteID,
              _set_func = (o, val) => { o.strSiteID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSiteID != c.strSiteID || o.IsRIRPropChanged(_str_strSiteID, c)) 
                  m.Add(_str_strSiteID, o.ObjectIdent + _str_strSiteID, "String", o.strSiteID == null ? "" : o.strSiteID.ToString(), o.IsReadOnly(_str_strSiteID), o.IsInvisible(_str_strSiteID), o.IsRequired(_str_strSiteID)); }
              }, 
        
            new field_info {
              _name = _str_strDescription, _type = "String",
              _get_func = o => o.strDescription,
              _set_func = (o, val) => { o.strDescription = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strDescription != c.strDescription || o.IsRIRPropChanged(_str_strDescription, c)) 
                  m.Add(_str_strDescription, o.ObjectIdent + _str_strDescription, "String", o.strDescription == null ? "" : o.strDescription.ToString(), o.IsReadOnly(_str_strDescription), o.IsInvisible(_str_strDescription), o.IsRequired(_str_strDescription)); }
              }, 
        
            new field_info {
              _name = _str_idfsOASite, _type = "long?",
              _get_func = o => o.idfsOASite,
              _set_func = (o, val) => { o.idfsOASite = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfsOASite != c.idfsOASite || o.IsRIRPropChanged(_str_idfsOASite, c)) 
                  m.Add(_str_idfsOASite, o.ObjectIdent + _str_idfsOASite, "long?", o.idfsOASite == null ? "" : o.idfsOASite.ToString(), o.IsReadOnly(_str_idfsOASite), o.IsInvisible(_str_idfsOASite), o.IsRequired(_str_idfsOASite));
                 }
              }, 
        
            new field_info {
              _name = _str_ObjectAccessListFiltered, _type = "EditableList<ObjectAccess>",
              _get_func = o => o.ObjectAccessListFiltered,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_Site, _type = "Lookup",
              _get_func = o => { if (o.Site == null) return null; return o.Site.idfsSite; },
              _set_func = (o, val) => { o.Site = o.SiteLookup.Where(c => c.idfsSite.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsOASite != c.idfsOASite || o.IsRIRPropChanged(_str_Site, c)) 
                  m.Add(_str_Site, o.ObjectIdent + _str_Site, "Lookup", o.idfsOASite == null ? "" : o.idfsOASite.ToString(), o.IsReadOnly(_str_Site), o.IsInvisible(_str_Site), o.IsRequired(_str_Site)); }
              }, 
        
            new field_info {
              _name = _str_UserGroupMemberList, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.UserGroupMemberList.Count != c.UserGroupMemberList.Count || o.IsReadOnly(_str_UserGroupMemberList) != c.IsReadOnly(_str_UserGroupMemberList) || o.IsInvisible(_str_UserGroupMemberList) != c.IsInvisible(_str_UserGroupMemberList) || o.IsRequired(_str_UserGroupMemberList) != c.IsRequired(_str_UserGroupMemberList)) 
                  m.Add(_str_UserGroupMemberList, o.ObjectIdent + _str_UserGroupMemberList, "Child", o.idfEmployeeGroup == null ? "" : o.idfEmployeeGroup.ToString(), o.IsReadOnly(_str_UserGroupMemberList), o.IsInvisible(_str_UserGroupMemberList), o.IsRequired(_str_UserGroupMemberList)); }
              }, 
        
            new field_info {
              _name = _str_ObjectAccessList, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.ObjectAccessList.Count != c.ObjectAccessList.Count || o.IsReadOnly(_str_ObjectAccessList) != c.IsReadOnly(_str_ObjectAccessList) || o.IsInvisible(_str_ObjectAccessList) != c.IsInvisible(_str_ObjectAccessList) || o.IsRequired(_str_ObjectAccessList) != c.IsRequired(_str_ObjectAccessList)) 
                  m.Add(_str_ObjectAccessList, o.ObjectIdent + _str_ObjectAccessList, "Child", o.idfEmployeeGroup == null ? "" : o.idfEmployeeGroup.ToString(), o.IsReadOnly(_str_ObjectAccessList), o.IsInvisible(_str_ObjectAccessList), o.IsRequired(_str_ObjectAccessList)); }
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
            UserGroupDetail obj = (UserGroupDetail)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(UserGroupMember), eidss.model.Schema.UserGroupMember._str_idfEmployeeGroup, _str_idfEmployeeGroup)]
        public EditableList<UserGroupMember> UserGroupMemberList
        {
            get 
            {   
                return _UserGroupMemberList; 
            }
            set 
            {
                _UserGroupMemberList = value;
            }
        }
        protected EditableList<UserGroupMember> _UserGroupMemberList = new EditableList<UserGroupMember>();
                    
        [Relation(typeof(ObjectAccess), eidss.model.Schema.ObjectAccess._str_idfEmployee, _str_idfEmployeeGroup)]
        public EditableList<ObjectAccess> ObjectAccessList
        {
            get 
            {   
                return _ObjectAccessList; 
            }
            set 
            {
                _ObjectAccessList = value;
            }
        }
        protected EditableList<ObjectAccess> _ObjectAccessList = new EditableList<ObjectAccess>();
                    
        [Relation(typeof(SiteLookup), eidss.model.Schema.SiteLookup._str_idfsSite, _str_idfsOASite)]
        public SiteLookup Site
        {
            get { return _Site == null ? null : ((long)_Site.Key == 0 ? null : _Site); }
            set 
            { 
                _Site = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsOASite = _Site == null 
                    ? new long?()
                    : _Site.idfsSite; 
                OnPropertyChanged(_str_Site); 
            }
        }
        private SiteLookup _Site;

        
        public List<SiteLookup> SiteLookup
        {
            get { return _SiteLookup; }
        }
        private List<SiteLookup> _SiteLookup = new List<SiteLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Site:
                    return new BvSelectList(SiteLookup, eidss.model.Schema.SiteLookup._str_idfsSite, null, Site, _str_idfsOASite);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_ObjectAccessListFiltered)]
        public EditableList<ObjectAccess> ObjectAccessListFiltered
        {
            get { return new Func<UserGroupDetail, EditableList<ObjectAccess>>(c => new EditableList<ObjectAccess>(c.ObjectAccessList.Where(m => m.idfsSite == idfsOASite).ToList()))(this); }
            
        }
        
          [LocalizedDisplayName(_str_idfsOASite)]
        public long? idfsOASite
        {
            get { return m_idfsOASite; }
            set { if (m_idfsOASite != value) { m_idfsOASite = value; OnPropertyChanged(_str_idfsOASite); } }
        }
        private long? m_idfsOASite;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "UserGroupDetail";

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
        UserGroupMemberList.ForEach(c => { c.Parent = this; });
                ObjectAccessList.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as UserGroupDetail;
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
            var ret = base.Clone() as UserGroupDetail;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public UserGroupDetail CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as UserGroupDetail;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfEmployeeGroup; } }
        public string KeyName { get { return "idfEmployeeGroup"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || UserGroupMemberList.IsDirty
                    || UserGroupMemberList.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || ObjectAccessList.IsDirty
                    || ObjectAccessList.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsOASite_Site = idfsOASite;
            base.RejectChanges();
        
            if (_prev_idfsOASite_Site != idfsOASite)
            {
                _Site = _SiteLookup.FirstOrDefault(c => c.idfsSite == idfsOASite);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        UserGroupMemberList.RejectChanges();
                ObjectAccessList.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        UserGroupMemberList.AcceptChanges();
                ObjectAccessList.AcceptChanges();
                
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
        UserGroupMemberList.ForEach(c => c.SetChange());
                ObjectAccessList.ForEach(c => c.SetChange());
                
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

      private bool IsRIRPropChanged(string fld, UserGroupDetail c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public UserGroupDetail()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(UserGroupDetail_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(UserGroupDetail_PropertyChanged);
        }
        private void UserGroupDetail_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as UserGroupDetail).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfsOASite)
                OnPropertyChanged(_str_ObjectAccessListFiltered);
                  
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
            UserGroupDetail obj = this;
            
        }
        private void _DeletedExtenders()
        {
            UserGroupDetail obj = this;
            
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

    
        private static string[] readonly_names1 = "Site".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<UserGroupDetail, bool>(c => !EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.ManageRightsRemotely)))(this);
            
            return ReadOnly;
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _UserGroupMemberList)
                    o.ReadOnly = value;
                
                foreach(var o in _ObjectAccessList)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<UserGroupDetail, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<UserGroupDetail, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<UserGroupDetail, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<UserGroupDetail, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<UserGroupDetail, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<UserGroupDetail, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~UserGroupDetail()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("SiteLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "SiteLookup")
                _getAccessor().LoadLookup_Site(manager, this);
            
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
        
            if (_UserGroupMemberList != null) _UserGroupMemberList.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_ObjectAccessList != null) _ObjectAccessList.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<UserGroupDetail>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(UserGroupDetail obj);
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
            private UserGroupMember.Accessor UserGroupMemberListAccessor { get { return eidss.model.Schema.UserGroupMember.Accessor.Instance(m_CS); } }
            private ObjectAccess.Accessor ObjectAccessListAccessor { get { return eidss.model.Schema.ObjectAccess.Accessor.Instance(m_CS); } }
            private SiteLookup.Accessor SiteAccessor { get { return eidss.model.Schema.SiteLookup.Accessor.Instance(m_CS); } }
            

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

            
            public virtual UserGroupDetail SelectByKey(DbManagerProxy manager
                , Int64? idfEmployeeGroup
                )
            {
                return _SelectByKey(manager
                    , idfEmployeeGroup
                    , null, null
                    );
            }
            
      
            private UserGroupDetail _SelectByKey(DbManagerProxy manager
                , Int64? idfEmployeeGroup
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<UserGroupDetail> objs = new List<UserGroupDetail>();
                sets[0] = new MapResultSet(typeof(UserGroupDetail), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spUserGroupDetail_SelectDetail"
                            , manager.Parameter("@idfEmployeeGroup", idfEmployeeGroup)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    UserGroupDetail obj = objs[0];
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
    
            private void _SetupAddChildHandlerUserGroupMemberList(UserGroupDetail obj)
            {
                obj.UserGroupMemberList.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerObjectAccessList(UserGroupDetail obj)
            {
                obj.ObjectAccessList.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadUserGroupMemberList(UserGroupDetail obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadUserGroupMemberList(manager, obj);
                }
            }
            internal void _LoadUserGroupMemberList(DbManagerProxy manager, UserGroupDetail obj)
            {
                
                obj.UserGroupMemberList.Clear();
                obj.UserGroupMemberList.AddRange(UserGroupMemberListAccessor.SelectDetailList(manager
                    
                    , obj.idfEmployeeGroup
                    ));
                obj.UserGroupMemberList.ForEach(c => c.m_ObjectName = _str_UserGroupMemberList);
                obj.UserGroupMemberList.AcceptChanges();
                    
            }
            
            internal void _LoadObjectAccessList(UserGroupDetail obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadObjectAccessList(manager, obj);
                }
            }
            internal void _LoadObjectAccessList(DbManagerProxy manager, UserGroupDetail obj)
            {
                
                obj.ObjectAccessList.Clear();
                obj.ObjectAccessList.AddRange(ObjectAccessListAccessor.SelectDetailList(manager
                    
                    , obj.idfEmployeeGroup
                    ));
                obj.ObjectAccessList.ForEach(c => c.m_ObjectName = _str_ObjectAccessList);
                obj.ObjectAccessList.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, UserGroupDetail obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadUserGroupMemberList(manager, obj);
                _LoadObjectAccessList(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.Site = obj.SiteLookup.FirstOrDefault(s => s.idfsSite == EidssSiteContext.Instance.SiteID);;
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerUserGroupMemberList(obj);
                
                _SetupAddChildHandlerObjectAccessList(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, UserGroupDetail obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.UserGroupMemberList.ForEach(c => UserGroupMemberListAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.ObjectAccessList.ForEach(c => ObjectAccessListAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private UserGroupDetail _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    UserGroupDetail obj = UserGroupDetail.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfEmployeeGroup = (new GetNewIDExtender<UserGroupDetail>()).GetScalar(manager, obj);
                obj.idfsEmployeeGroupName = (new GetNewIDExtender<UserGroupDetail>()).GetScalar(manager, obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerUserGroupMemberList(obj);
                    
                    _SetupAddChildHandlerObjectAccessList(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.Site = obj.SiteLookup.FirstOrDefault(s => s.idfsSite == EidssSiteContext.Instance.SiteID);;
              _LoadObjectAccessList(manager, obj);
            
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

            
            public UserGroupDetail CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public UserGroupDetail CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(UserGroupDetail obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(UserGroupDetail obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_Site)
                        {
                    
                obj.idfsSite = obj.Site.idfsSite;
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Site(DbManagerProxy manager, UserGroupDetail obj)
            {
                
                obj.SiteLookup.Clear();
                
                obj.SiteLookup.Add(SiteAccessor.CreateNewT(manager, null));
                
                obj.SiteLookup.AddRange(SiteAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSite == obj.idfsOASite))
                    
                    .ToList());
                
                if (obj.idfsOASite != null && obj.idfsOASite != 0)
                {
                    obj.Site = obj.SiteLookup
                        .Where(c => c.idfsSite == obj.idfsOASite)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("SiteLookup", obj, SiteAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, UserGroupDetail obj)
            {
                
                LoadLookup_Site(manager, obj);
                
            }
    
            [SprocName("spUserGroupDetail_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spUserGroupDetail_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, string LangID, 
                [Direction.InputOutput()] UserGroupDetail obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, string LangID, 
                [Direction.InputOutput()] UserGroupDetail obj)
            {
                
                _post(manager, Action, LangID, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    UserGroupDetail bo = obj as UserGroupDetail;
                    
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
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        long mainObject = bo.idfEmployeeGroup;
                        
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoUserGroup;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbEmployeeGroup;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as UserGroupDetail, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, UserGroupDetail obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.ObjectAccessList != null)
                    {
                        foreach (var i in obj.ObjectAccessList)
                        {
                            i.MarkToDelete();
                            if (!ObjectAccessListAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                    
                    if (obj.UserGroupMemberList != null)
                    {
                        foreach (var i in obj.UserGroupMemberList)
                        {
                            i.MarkToDelete();
                            if (!UserGroupMemberListAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                    
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
                                    
                    if (obj.IsNew)
                    {
                        if (obj.UserGroupMemberList != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.UserGroupMemberList)
                                if (!UserGroupMemberListAccessor.Post(manager, i, true))
                                    return false;
                            obj.UserGroupMemberList.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.UserGroupMemberList.Remove(c));
                            obj.UserGroupMemberList.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._UserGroupMemberList != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._UserGroupMemberList)
                                if (!UserGroupMemberListAccessor.Post(manager, i, true))
                                    return false;
                            obj._UserGroupMemberList.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._UserGroupMemberList.Remove(c));
                            obj._UserGroupMemberList.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.ObjectAccessList != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.ObjectAccessList)
                                if (!ObjectAccessListAccessor.Post(manager, i, true))
                                    return false;
                            obj.ObjectAccessList.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.ObjectAccessList.Remove(c));
                            obj.ObjectAccessList.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._ObjectAccessList != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._ObjectAccessList)
                                if (!ObjectAccessListAccessor.Post(manager, i, true))
                                    return false;
                            obj._ObjectAccessList.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._ObjectAccessList.Remove(c));
                            obj._ObjectAccessList.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(UserGroupDetail obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, UserGroupDetail obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as UserGroupDetail, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, UserGroupDetail obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "strGroupName", "strGroupName","GroupName",
                false
              )).Validate(c => true, obj, obj.strGroupName);
            
                (new RequiredValidator( "idfsSite", "idfsSite","Site",
                false
              )).Validate(c => true, obj, obj.idfsSite);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.UserGroupMemberList != null)
                            foreach (var i in obj.UserGroupMemberList.Where(c => !c.IsMarkedToDelete))
                                UserGroupMemberListAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.ObjectAccessList != null)
                            foreach (var i in obj.ObjectAccessList.Where(c => !c.IsMarkedToDelete))
                                ObjectAccessListAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("UserGroup.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("UserGroup.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("UserGroup.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("UserGroup.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(UserGroupDetail obj)
            {
            
                obj
                    .AddRequired("strGroupName", c => true);
                    
                obj
                    .AddRequired("idfsSite", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(UserGroupDetail obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as UserGroupDetail) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as UserGroupDetail) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "UserGroupDetailDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private UserGroupDetail m_obj;
            internal Permissions(UserGroupDetail obj)
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
            public static string spSelect = "spUserGroupDetail_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spUserGroupDetail_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spUserGroupDetail_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<UserGroupDetail, bool>> RequiredByField = new Dictionary<string, Func<UserGroupDetail, bool>>();
            public static Dictionary<string, Func<UserGroupDetail, bool>> RequiredByProperty = new Dictionary<string, Func<UserGroupDetail, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strGroupName, 200);
                Sizes.Add(_str_strNationalGroupName, 2000);
                Sizes.Add(_str_strSiteID, 36);
                Sizes.Add(_str_strDescription, 200);
                if (!RequiredByField.ContainsKey("strGroupName")) RequiredByField.Add("strGroupName", c => true);
                if (!RequiredByProperty.ContainsKey("strGroupName")) RequiredByProperty.Add("strGroupName", c => true);
                
                if (!RequiredByField.ContainsKey("idfsSite")) RequiredByField.Add("idfsSite", c => true);
                if (!RequiredByProperty.ContainsKey("idfsSite")) RequiredByProperty.Add("idfsSite", c => true);
                
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<UserGroupDetail>().Post(manager, (UserGroupDetail)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<UserGroupDetail>().Post(manager, (UserGroupDetail)c), c),
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
	