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
    public abstract partial class SiteLookup : 
        EditableObject<SiteLookup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsSite), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsSite { get; set; }
                
        [LocalizedDisplayName(_str_idfsSiteType)]
        [MapField(_str_idfsSiteType)]
        public abstract Int64? idfsSiteType { get; set; }
        #if MONO
        protected Int64? idfsSiteType_Original { get { return idfsSiteType; } }
        protected Int64? idfsSiteType_Previous { get { return idfsSiteType; } }
        #else
        protected Int64? idfsSiteType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSiteType).OriginalValue; } }
        protected Int64? idfsSiteType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSiteType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSiteName)]
        [MapField(_str_strSiteName)]
        public abstract String strSiteName { get; set; }
        #if MONO
        protected String strSiteName_Original { get { return strSiteName; } }
        protected String strSiteName_Previous { get { return strSiteName; } }
        #else
        protected String strSiteName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSiteName).OriginalValue; } }
        protected String strSiteName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSiteName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strServerName)]
        [MapField(_str_strServerName)]
        public abstract String strServerName { get; set; }
        #if MONO
        protected String strServerName_Original { get { return strServerName; } }
        protected String strServerName_Previous { get { return strServerName; } }
        #else
        protected String strServerName_Original { get { return ((EditableValue<String>)((dynamic)this)._strServerName).OriginalValue; } }
        protected String strServerName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strServerName).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strSiteType)]
        [MapField(_str_strSiteType)]
        public abstract String strSiteType { get; set; }
        #if MONO
        protected String strSiteType_Original { get { return strSiteType; } }
        protected String strSiteType_Previous { get { return strSiteType; } }
        #else
        protected String strSiteType_Original { get { return ((EditableValue<String>)((dynamic)this)._strSiteType).OriginalValue; } }
        protected String strSiteType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSiteType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfOffice)]
        [MapField(_str_idfOffice)]
        public abstract Int64? idfOffice { get; set; }
        #if MONO
        protected Int64? idfOffice_Original { get { return idfOffice; } }
        protected Int64? idfOffice_Previous { get { return idfOffice; } }
        #else
        protected Int64? idfOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOffice).OriginalValue; } }
        protected Int64? idfOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_OfficeName)]
        [MapField(_str_OfficeName)]
        public abstract String OfficeName { get; set; }
        #if MONO
        protected String OfficeName_Original { get { return OfficeName; } }
        protected String OfficeName_Previous { get { return OfficeName; } }
        #else
        protected String OfficeName_Original { get { return ((EditableValue<String>)((dynamic)this)._officeName).OriginalValue; } }
        protected String OfficeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._officeName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_OfficeAbbreviation)]
        [MapField(_str_OfficeAbbreviation)]
        public abstract String OfficeAbbreviation { get; set; }
        #if MONO
        protected String OfficeAbbreviation_Original { get { return OfficeAbbreviation; } }
        protected String OfficeAbbreviation_Previous { get { return OfficeAbbreviation; } }
        #else
        protected String OfficeAbbreviation_Original { get { return ((EditableValue<String>)((dynamic)this)._officeAbbreviation).OriginalValue; } }
        protected String OfficeAbbreviation_Previous { get { return ((EditableValue<String>)((dynamic)this)._officeAbbreviation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intRowStatus)]
        [MapField(_str_intRowStatus)]
        public abstract Int32 intRowStatus { get; set; }
        #if MONO
        protected Int32 intRowStatus_Original { get { return intRowStatus; } }
        protected Int32 intRowStatus_Previous { get { return intRowStatus; } }
        #else
        protected Int32 intRowStatus_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).OriginalValue; } }
        protected Int32 intRowStatus_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsOfficeAbbreviation)]
        [MapField(_str_idfsOfficeAbbreviation)]
        public abstract Int64? idfsOfficeAbbreviation { get; set; }
        #if MONO
        protected Int64? idfsOfficeAbbreviation_Original { get { return idfsOfficeAbbreviation; } }
        protected Int64? idfsOfficeAbbreviation_Previous { get { return idfsOfficeAbbreviation; } }
        #else
        protected Int64? idfsOfficeAbbreviation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOfficeAbbreviation).OriginalValue; } }
        protected Int64? idfsOfficeAbbreviation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOfficeAbbreviation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsOfficeName)]
        [MapField(_str_idfsOfficeName)]
        public abstract Int64? idfsOfficeName { get; set; }
        #if MONO
        protected Int64? idfsOfficeName_Original { get { return idfsOfficeName; } }
        protected Int64? idfsOfficeName_Previous { get { return idfsOfficeName; } }
        #else
        protected Int64? idfsOfficeName_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOfficeName).OriginalValue; } }
        protected Int64? idfsOfficeName_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOfficeName).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<SiteLookup, object> _get_func;
            internal Action<SiteLookup, string> _set_func;
            internal Action<SiteLookup, SiteLookup, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_idfsSiteType = "idfsSiteType";
        internal const string _str_strSiteName = "strSiteName";
        internal const string _str_strServerName = "strServerName";
        internal const string _str_strSiteID = "strSiteID";
        internal const string _str_strSiteType = "strSiteType";
        internal const string _str_idfOffice = "idfOffice";
        internal const string _str_OfficeName = "OfficeName";
        internal const string _str_OfficeAbbreviation = "OfficeAbbreviation";
        internal const string _str_intRowStatus = "intRowStatus";
        internal const string _str_idfsOfficeAbbreviation = "idfsOfficeAbbreviation";
        internal const string _str_idfsOfficeName = "idfsOfficeName";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfsSite, _type = "Int64",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { o.idfsSite = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_idfsSite, c)) 
                  m.Add(_str_idfsSite, o.ObjectIdent + _str_idfsSite, "Int64", o.idfsSite == null ? "" : o.idfsSite.ToString(), o.IsReadOnly(_str_idfsSite), o.IsInvisible(_str_idfsSite), o.IsRequired(_str_idfsSite)); }
              }, 
        
            new field_info {
              _name = _str_idfsSiteType, _type = "Int64?",
              _get_func = o => o.idfsSiteType,
              _set_func = (o, val) => { o.idfsSiteType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSiteType != c.idfsSiteType || o.IsRIRPropChanged(_str_idfsSiteType, c)) 
                  m.Add(_str_idfsSiteType, o.ObjectIdent + _str_idfsSiteType, "Int64?", o.idfsSiteType == null ? "" : o.idfsSiteType.ToString(), o.IsReadOnly(_str_idfsSiteType), o.IsInvisible(_str_idfsSiteType), o.IsRequired(_str_idfsSiteType)); }
              }, 
        
            new field_info {
              _name = _str_strSiteName, _type = "String",
              _get_func = o => o.strSiteName,
              _set_func = (o, val) => { o.strSiteName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSiteName != c.strSiteName || o.IsRIRPropChanged(_str_strSiteName, c)) 
                  m.Add(_str_strSiteName, o.ObjectIdent + _str_strSiteName, "String", o.strSiteName == null ? "" : o.strSiteName.ToString(), o.IsReadOnly(_str_strSiteName), o.IsInvisible(_str_strSiteName), o.IsRequired(_str_strSiteName)); }
              }, 
        
            new field_info {
              _name = _str_strServerName, _type = "String",
              _get_func = o => o.strServerName,
              _set_func = (o, val) => { o.strServerName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strServerName != c.strServerName || o.IsRIRPropChanged(_str_strServerName, c)) 
                  m.Add(_str_strServerName, o.ObjectIdent + _str_strServerName, "String", o.strServerName == null ? "" : o.strServerName.ToString(), o.IsReadOnly(_str_strServerName), o.IsInvisible(_str_strServerName), o.IsRequired(_str_strServerName)); }
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
              _name = _str_strSiteType, _type = "String",
              _get_func = o => o.strSiteType,
              _set_func = (o, val) => { o.strSiteType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSiteType != c.strSiteType || o.IsRIRPropChanged(_str_strSiteType, c)) 
                  m.Add(_str_strSiteType, o.ObjectIdent + _str_strSiteType, "String", o.strSiteType == null ? "" : o.strSiteType.ToString(), o.IsReadOnly(_str_strSiteType), o.IsInvisible(_str_strSiteType), o.IsRequired(_str_strSiteType)); }
              }, 
        
            new field_info {
              _name = _str_idfOffice, _type = "Int64?",
              _get_func = o => o.idfOffice,
              _set_func = (o, val) => { o.idfOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfOffice != c.idfOffice || o.IsRIRPropChanged(_str_idfOffice, c)) 
                  m.Add(_str_idfOffice, o.ObjectIdent + _str_idfOffice, "Int64?", o.idfOffice == null ? "" : o.idfOffice.ToString(), o.IsReadOnly(_str_idfOffice), o.IsInvisible(_str_idfOffice), o.IsRequired(_str_idfOffice)); }
              }, 
        
            new field_info {
              _name = _str_OfficeName, _type = "String",
              _get_func = o => o.OfficeName,
              _set_func = (o, val) => { o.OfficeName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.OfficeName != c.OfficeName || o.IsRIRPropChanged(_str_OfficeName, c)) 
                  m.Add(_str_OfficeName, o.ObjectIdent + _str_OfficeName, "String", o.OfficeName == null ? "" : o.OfficeName.ToString(), o.IsReadOnly(_str_OfficeName), o.IsInvisible(_str_OfficeName), o.IsRequired(_str_OfficeName)); }
              }, 
        
            new field_info {
              _name = _str_OfficeAbbreviation, _type = "String",
              _get_func = o => o.OfficeAbbreviation,
              _set_func = (o, val) => { o.OfficeAbbreviation = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.OfficeAbbreviation != c.OfficeAbbreviation || o.IsRIRPropChanged(_str_OfficeAbbreviation, c)) 
                  m.Add(_str_OfficeAbbreviation, o.ObjectIdent + _str_OfficeAbbreviation, "String", o.OfficeAbbreviation == null ? "" : o.OfficeAbbreviation.ToString(), o.IsReadOnly(_str_OfficeAbbreviation), o.IsInvisible(_str_OfficeAbbreviation), o.IsRequired(_str_OfficeAbbreviation)); }
              }, 
        
            new field_info {
              _name = _str_intRowStatus, _type = "Int32",
              _get_func = o => o.intRowStatus,
              _set_func = (o, val) => { o.intRowStatus = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intRowStatus != c.intRowStatus || o.IsRIRPropChanged(_str_intRowStatus, c)) 
                  m.Add(_str_intRowStatus, o.ObjectIdent + _str_intRowStatus, "Int32", o.intRowStatus == null ? "" : o.intRowStatus.ToString(), o.IsReadOnly(_str_intRowStatus), o.IsInvisible(_str_intRowStatus), o.IsRequired(_str_intRowStatus)); }
              }, 
        
            new field_info {
              _name = _str_idfsOfficeAbbreviation, _type = "Int64?",
              _get_func = o => o.idfsOfficeAbbreviation,
              _set_func = (o, val) => { o.idfsOfficeAbbreviation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsOfficeAbbreviation != c.idfsOfficeAbbreviation || o.IsRIRPropChanged(_str_idfsOfficeAbbreviation, c)) 
                  m.Add(_str_idfsOfficeAbbreviation, o.ObjectIdent + _str_idfsOfficeAbbreviation, "Int64?", o.idfsOfficeAbbreviation == null ? "" : o.idfsOfficeAbbreviation.ToString(), o.IsReadOnly(_str_idfsOfficeAbbreviation), o.IsInvisible(_str_idfsOfficeAbbreviation), o.IsRequired(_str_idfsOfficeAbbreviation)); }
              }, 
        
            new field_info {
              _name = _str_idfsOfficeName, _type = "Int64?",
              _get_func = o => o.idfsOfficeName,
              _set_func = (o, val) => { o.idfsOfficeName = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsOfficeName != c.idfsOfficeName || o.IsRIRPropChanged(_str_idfsOfficeName, c)) 
                  m.Add(_str_idfsOfficeName, o.ObjectIdent + _str_idfsOfficeName, "Int64?", o.idfsOfficeName == null ? "" : o.idfsOfficeName.ToString(), o.IsReadOnly(_str_idfsOfficeName), o.IsInvisible(_str_idfsOfficeName), o.IsRequired(_str_idfsOfficeName)); }
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
            SiteLookup obj = (SiteLookup)o;
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
        internal string m_ObjectName = "SiteLookup";

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
            var ret = base.Clone() as SiteLookup;
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
            var ret = base.Clone() as SiteLookup;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public SiteLookup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as SiteLookup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsSite; } }
        public string KeyName { get { return "idfsSite"; } }
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

      private bool IsRIRPropChanged(string fld, SiteLookup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      
        public override string ToString()
        {
            return new Func<SiteLookup, string>(c => c.strSiteID)(this);
        }
        

        public SiteLookup()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SiteLookup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(SiteLookup_PropertyChanged);
        }
        private void SiteLookup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as SiteLookup).Changed(e.PropertyName);
            
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
            SiteLookup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            SiteLookup obj = this;
            
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


        public Dictionary<string, Func<SiteLookup, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<SiteLookup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<SiteLookup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<SiteLookup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<SiteLookup, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<SiteLookup, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~SiteLookup()
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
        : DataAccessor<SiteLookup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
        {
            private delegate void on_action(SiteLookup obj);
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
            [InstanceCache(typeof(BvCacheAspect))]
            public virtual List<SiteLookup> SelectLookupList(DbManagerProxy manager
                )
            {
                return _SelectList(manager
                    , null, null
                    );
            }
            
            public static string GetLookupTableName(string method)
            {
                return "Site";
            }
            
            public virtual List<SiteLookup> SelectList(DbManagerProxy manager
                )
            {
                return _SelectList(manager
                    , delegate(SiteLookup obj)
                        {
                        }
                    , delegate(SiteLookup obj)
                        {
                        }
                    );
            }

            
            private List<SiteLookup> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<SiteLookup> objs = new List<SiteLookup>();
                    sets[0] = new MapResultSet(typeof(SiteLookup), objs);
                    
                    manager
                        .SetSpCommand("spSite_SelectLookup"
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, SiteLookup obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, SiteLookup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private SiteLookup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    SiteLookup obj = SiteLookup.CreateInstance();
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

            
            public SiteLookup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public SiteLookup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(SiteLookup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(SiteLookup obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, SiteLookup obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as SiteLookup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, SiteLookup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(SiteLookup obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(SiteLookup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as SiteLookup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as SiteLookup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "SiteLookupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spSite_SelectLookup";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<SiteLookup, bool>> RequiredByField = new Dictionary<string, Func<SiteLookup, bool>>();
            public static Dictionary<string, Func<SiteLookup, bool>> RequiredByProperty = new Dictionary<string, Func<SiteLookup, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strSiteName, 2000);
                Sizes.Add(_str_strServerName, 200);
                Sizes.Add(_str_strSiteID, 36);
                Sizes.Add(_str_strSiteType, 2000);
                Sizes.Add(_str_OfficeName, 2000);
                Sizes.Add(_str_OfficeAbbreviation, 2000);
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
                    (manager, c, pars) => new ActResult(((SiteLookup)c).MarkToDelete() && ObjectAccessor.PostInterface<SiteLookup>().Post(manager, (SiteLookup)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<SiteLookup>().Post(manager, (SiteLookup)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<SiteLookup>().Post(manager, (SiteLookup)c), c),
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
	