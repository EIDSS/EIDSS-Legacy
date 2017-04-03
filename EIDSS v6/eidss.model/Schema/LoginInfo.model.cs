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
    public abstract partial class LoginInfo : 
        EditableObject<LoginInfo>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfUserID), NonUpdatable, PrimaryKey]
        public abstract Int64 idfUserID { get; set; }
                
        [LocalizedDisplayName(_str_idfPerson)]
        [MapField(_str_idfPerson)]
        public abstract Int64? idfPerson { get; set; }
        protected Int64? idfPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerson).OriginalValue; } }
        protected Int64? idfPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64 idfsSite { get; set; }
        protected Int64 idfsSite_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64 idfsSite_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datTryDate)]
        [MapField(_str_datTryDate)]
        public abstract DateTime? datTryDate { get; set; }
        protected DateTime? datTryDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTryDate).OriginalValue; } }
        protected DateTime? datTryDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTryDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datPasswordSet)]
        [MapField(_str_datPasswordSet)]
        public abstract DateTime? datPasswordSet { get; set; }
        protected DateTime? datPasswordSet_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPasswordSet).OriginalValue; } }
        protected DateTime? datPasswordSet_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPasswordSet).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strAccountName)]
        [MapField(_str_strAccountName)]
        public abstract String strAccountName { get; set; }
        protected String strAccountName_Original { get { return ((EditableValue<String>)((dynamic)this)._strAccountName).OriginalValue; } }
        protected String strAccountName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAccountName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_binPassword)]
        [MapField(_str_binPassword)]
        public abstract Byte[] binPassword { get; set; }
        protected Byte[] binPassword_Original { get { return ((EditableValue<Byte[]>)((dynamic)this)._binPassword).OriginalValue; } }
        protected Byte[] binPassword_Previous { get { return ((EditableValue<Byte[]>)((dynamic)this)._binPassword).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intTry)]
        [MapField(_str_intTry)]
        public abstract Int32? intTry { get; set; }
        protected Int32? intTry_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intTry).OriginalValue; } }
        protected Int32? intTry_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intTry).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSiteID)]
        [MapField(_str_strSiteID)]
        public abstract String strSiteID { get; set; }
        protected String strSiteID_Original { get { return ((EditableValue<String>)((dynamic)this)._strSiteID).OriginalValue; } }
        protected String strSiteID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSiteID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSiteName)]
        [MapField(_str_strSiteName)]
        public abstract String strSiteName { get; set; }
        protected String strSiteName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSiteName).OriginalValue; } }
        protected String strSiteName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSiteName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSiteType)]
        [MapField(_str_idfsSiteType)]
        public abstract Int64? idfsSiteType { get; set; }
        protected Int64? idfsSiteType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSiteType).OriginalValue; } }
        protected Int64? idfsSiteType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSiteType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSiteType)]
        [MapField(_str_strSiteType)]
        public abstract String strSiteType { get; set; }
        protected String strSiteType_Original { get { return ((EditableValue<String>)((dynamic)this)._strSiteType).OriginalValue; } }
        protected String strSiteType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSiteType).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<LoginInfo, object> _get_func;
            internal Action<LoginInfo, string> _set_func;
            internal Action<LoginInfo, LoginInfo, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfUserID = "idfUserID";
        internal const string _str_idfPerson = "idfPerson";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_datTryDate = "datTryDate";
        internal const string _str_datPasswordSet = "datPasswordSet";
        internal const string _str_strAccountName = "strAccountName";
        internal const string _str_binPassword = "binPassword";
        internal const string _str_intTry = "intTry";
        internal const string _str_strSiteID = "strSiteID";
        internal const string _str_strSiteName = "strSiteName";
        internal const string _str_idfsSiteType = "idfsSiteType";
        internal const string _str_strSiteType = "strSiteType";
        internal const string _str_strPasswordDecrypted = "strPasswordDecrypted";
        internal const string _str_strConfirmPassword = "strConfirmPassword";
        internal const string _str_Site = "Site";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfUserID, _formname = _str_idfUserID, _type = "Int64",
              _get_func = o => o.idfUserID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfUserID != newval) o.idfUserID = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfUserID != c.idfUserID || o.IsRIRPropChanged(_str_idfUserID, c)) 
                  m.Add(_str_idfUserID, o.ObjectIdent + _str_idfUserID, o.ObjectIdent2 + _str_idfUserID, o.ObjectIdent3 + _str_idfUserID, "Int64", 
                    o.idfUserID == null ? "" : o.idfUserID.ToString(),                  
                  o.IsReadOnly(_str_idfUserID), o.IsInvisible(_str_idfUserID), o.IsRequired(_str_idfUserID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfPerson, _formname = _str_idfPerson, _type = "Int64?",
              _get_func = o => o.idfPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfPerson != newval) o.idfPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfPerson != c.idfPerson || o.IsRIRPropChanged(_str_idfPerson, c)) 
                  m.Add(_str_idfPerson, o.ObjectIdent + _str_idfPerson, o.ObjectIdent2 + _str_idfPerson, o.ObjectIdent3 + _str_idfPerson, "Int64?", 
                    o.idfPerson == null ? "" : o.idfPerson.ToString(),                  
                  o.IsReadOnly(_str_idfPerson), o.IsInvisible(_str_idfPerson), o.IsRequired(_str_idfPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSite, _formname = _str_idfsSite, _type = "Int64",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsSite != newval) 
                  o.Site = o.SiteLookup.FirstOrDefault(c => c.idfsSite == newval);
                if (o.idfsSite != newval) o.idfsSite = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_idfsSite, c)) 
                  m.Add(_str_idfsSite, o.ObjectIdent + _str_idfsSite, o.ObjectIdent2 + _str_idfsSite, o.ObjectIdent3 + _str_idfsSite, "Int64", 
                    o.idfsSite == null ? "" : o.idfsSite.ToString(),                  
                  o.IsReadOnly(_str_idfsSite), o.IsInvisible(_str_idfsSite), o.IsRequired(_str_idfsSite)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datTryDate, _formname = _str_datTryDate, _type = "DateTime?",
              _get_func = o => o.datTryDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datTryDate != newval) o.datTryDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datTryDate != c.datTryDate || o.IsRIRPropChanged(_str_datTryDate, c)) 
                  m.Add(_str_datTryDate, o.ObjectIdent + _str_datTryDate, o.ObjectIdent2 + _str_datTryDate, o.ObjectIdent3 + _str_datTryDate, "DateTime?", 
                    o.datTryDate == null ? "" : o.datTryDate.ToString(),                  
                  o.IsReadOnly(_str_datTryDate), o.IsInvisible(_str_datTryDate), o.IsRequired(_str_datTryDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datPasswordSet, _formname = _str_datPasswordSet, _type = "DateTime?",
              _get_func = o => o.datPasswordSet,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datPasswordSet != newval) o.datPasswordSet = newval; },
              _compare_func = (o, c, m) => {
                if (o.datPasswordSet != c.datPasswordSet || o.IsRIRPropChanged(_str_datPasswordSet, c)) 
                  m.Add(_str_datPasswordSet, o.ObjectIdent + _str_datPasswordSet, o.ObjectIdent2 + _str_datPasswordSet, o.ObjectIdent3 + _str_datPasswordSet, "DateTime?", 
                    o.datPasswordSet == null ? "" : o.datPasswordSet.ToString(),                  
                  o.IsReadOnly(_str_datPasswordSet), o.IsInvisible(_str_datPasswordSet), o.IsRequired(_str_datPasswordSet)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strAccountName, _formname = _str_strAccountName, _type = "String",
              _get_func = o => o.strAccountName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strAccountName != newval) o.strAccountName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strAccountName != c.strAccountName || o.IsRIRPropChanged(_str_strAccountName, c)) 
                  m.Add(_str_strAccountName, o.ObjectIdent + _str_strAccountName, o.ObjectIdent2 + _str_strAccountName, o.ObjectIdent3 + _str_strAccountName, "String", 
                    o.strAccountName == null ? "" : o.strAccountName.ToString(),                  
                  o.IsReadOnly(_str_strAccountName), o.IsInvisible(_str_strAccountName), o.IsRequired(_str_strAccountName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_binPassword, _formname = _str_binPassword, _type = "Byte[]",
              _get_func = o => o.binPassword,
              _set_func = (o, val) => { var newval = o.binPassword; if (o.binPassword != newval) o.binPassword = newval; },
              _compare_func = (o, c, m) => {
                if (o.binPassword != c.binPassword || o.IsRIRPropChanged(_str_binPassword, c)) 
                  m.Add(_str_binPassword, o.ObjectIdent + _str_binPassword, o.ObjectIdent2 + _str_binPassword, o.ObjectIdent3 + _str_binPassword, "Byte[]", 
                    o.binPassword == null ? "" : o.binPassword.ToString(),                  
                  o.IsReadOnly(_str_binPassword), o.IsInvisible(_str_binPassword), o.IsRequired(_str_binPassword)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intTry, _formname = _str_intTry, _type = "Int32?",
              _get_func = o => o.intTry,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intTry != newval) o.intTry = newval; },
              _compare_func = (o, c, m) => {
                if (o.intTry != c.intTry || o.IsRIRPropChanged(_str_intTry, c)) 
                  m.Add(_str_intTry, o.ObjectIdent + _str_intTry, o.ObjectIdent2 + _str_intTry, o.ObjectIdent3 + _str_intTry, "Int32?", 
                    o.intTry == null ? "" : o.intTry.ToString(),                  
                  o.IsReadOnly(_str_intTry), o.IsInvisible(_str_intTry), o.IsRequired(_str_intTry)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSiteID, _formname = _str_strSiteID, _type = "String",
              _get_func = o => o.strSiteID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSiteID != newval) o.strSiteID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSiteID != c.strSiteID || o.IsRIRPropChanged(_str_strSiteID, c)) 
                  m.Add(_str_strSiteID, o.ObjectIdent + _str_strSiteID, o.ObjectIdent2 + _str_strSiteID, o.ObjectIdent3 + _str_strSiteID, "String", 
                    o.strSiteID == null ? "" : o.strSiteID.ToString(),                  
                  o.IsReadOnly(_str_strSiteID), o.IsInvisible(_str_strSiteID), o.IsRequired(_str_strSiteID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSiteName, _formname = _str_strSiteName, _type = "String",
              _get_func = o => o.strSiteName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSiteName != newval) o.strSiteName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSiteName != c.strSiteName || o.IsRIRPropChanged(_str_strSiteName, c)) 
                  m.Add(_str_strSiteName, o.ObjectIdent + _str_strSiteName, o.ObjectIdent2 + _str_strSiteName, o.ObjectIdent3 + _str_strSiteName, "String", 
                    o.strSiteName == null ? "" : o.strSiteName.ToString(),                  
                  o.IsReadOnly(_str_strSiteName), o.IsInvisible(_str_strSiteName), o.IsRequired(_str_strSiteName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSiteType, _formname = _str_idfsSiteType, _type = "Int64?",
              _get_func = o => o.idfsSiteType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSiteType != newval) o.idfsSiteType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSiteType != c.idfsSiteType || o.IsRIRPropChanged(_str_idfsSiteType, c)) 
                  m.Add(_str_idfsSiteType, o.ObjectIdent + _str_idfsSiteType, o.ObjectIdent2 + _str_idfsSiteType, o.ObjectIdent3 + _str_idfsSiteType, "Int64?", 
                    o.idfsSiteType == null ? "" : o.idfsSiteType.ToString(),                  
                  o.IsReadOnly(_str_idfsSiteType), o.IsInvisible(_str_idfsSiteType), o.IsRequired(_str_idfsSiteType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSiteType, _formname = _str_strSiteType, _type = "String",
              _get_func = o => o.strSiteType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSiteType != newval) o.strSiteType = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSiteType != c.strSiteType || o.IsRIRPropChanged(_str_strSiteType, c)) 
                  m.Add(_str_strSiteType, o.ObjectIdent + _str_strSiteType, o.ObjectIdent2 + _str_strSiteType, o.ObjectIdent3 + _str_strSiteType, "String", 
                    o.strSiteType == null ? "" : o.strSiteType.ToString(),                  
                  o.IsReadOnly(_str_strSiteType), o.IsInvisible(_str_strSiteType), o.IsRequired(_str_strSiteType)); 
                  }
              }, 
        
            new field_info {
              _name = _str_strPasswordDecrypted, _formname = _str_strPasswordDecrypted, _type = "string",
              _get_func = o => o.strPasswordDecrypted,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPasswordDecrypted != newval) o.strPasswordDecrypted = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.strPasswordDecrypted != c.strPasswordDecrypted || o.IsRIRPropChanged(_str_strPasswordDecrypted, c)) {
                  m.Add(_str_strPasswordDecrypted, o.ObjectIdent + _str_strPasswordDecrypted, o.ObjectIdent2 + _str_strPasswordDecrypted, o.ObjectIdent3 + _str_strPasswordDecrypted,  "string", 
                    o.strPasswordDecrypted == null ? "" : o.strPasswordDecrypted.ToString(),                  
                    o.IsReadOnly(_str_strPasswordDecrypted), o.IsInvisible(_str_strPasswordDecrypted), o.IsRequired(_str_strPasswordDecrypted));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_strConfirmPassword, _formname = _str_strConfirmPassword, _type = "string",
              _get_func = o => o.strConfirmPassword,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strConfirmPassword != newval) o.strConfirmPassword = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.strConfirmPassword != c.strConfirmPassword || o.IsRIRPropChanged(_str_strConfirmPassword, c)) {
                  m.Add(_str_strConfirmPassword, o.ObjectIdent + _str_strConfirmPassword, o.ObjectIdent2 + _str_strConfirmPassword, o.ObjectIdent3 + _str_strConfirmPassword,  "string", 
                    o.strConfirmPassword == null ? "" : o.strConfirmPassword.ToString(),                  
                    o.IsReadOnly(_str_strConfirmPassword), o.IsInvisible(_str_strConfirmPassword), o.IsRequired(_str_strConfirmPassword));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_Site, _formname = _str_Site, _type = "Lookup",
              _get_func = o => { if (o.Site == null) return null; return o.Site.idfsSite; },
              _set_func = (o, val) => { o.Site = o.SiteLookup.Where(c => c.idfsSite.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_Site, c)) {
                  m.Add(_str_Site, o.ObjectIdent + _str_Site, o.ObjectIdent2 + _str_Site, o.ObjectIdent3 + _str_Site, "Lookup", o.idfsSite == null ? "" : o.idfsSite.ToString(), o.IsReadOnly(_str_Site), o.IsInvisible(_str_Site), o.IsRequired(_str_Site)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Site + "Lookup", _formname = _str_Site + "Lookup", _type = "LookupContent",
              _get_func = o => o.SiteLookup,
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
            LoginInfo obj = (LoginInfo)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Site)]
        [Relation(typeof(SiteLookup), eidss.model.Schema.SiteLookup._str_idfsSite, _str_idfsSite)]
        public SiteLookup Site
        {
            get { return _Site == null ? null : ((long)_Site.Key == 0 ? null : _Site); }
            set 
            { 
                var oldVal = _Site;
                _Site = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Site != oldVal)
                {
                    if (idfsSite != (_Site == null
                            ? new Int64()
                            : (Int64)_Site.idfsSite))
                        idfsSite = _Site == null 
                            ? new Int64()
                            : (Int64)_Site.idfsSite; 
                    OnPropertyChanged(_str_Site); 
                }
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
                    return new BvSelectList(SiteLookup, eidss.model.Schema.SiteLookup._str_idfsSite, null, Site, _str_idfsSite);
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str_strPasswordDecrypted)]
        public string strPasswordDecrypted
        {
            get { return m_strPasswordDecrypted; }
            set { if (m_strPasswordDecrypted != value) { m_strPasswordDecrypted = value; OnPropertyChanged(_str_strPasswordDecrypted); } }
        }
        private string m_strPasswordDecrypted;
        
          [LocalizedDisplayName(_str_strConfirmPassword)]
        public string strConfirmPassword
        {
            get { return m_strConfirmPassword; }
            set { if (m_strConfirmPassword != value) { m_strConfirmPassword = value; OnPropertyChanged(_str_strConfirmPassword); } }
        }
        private string m_strConfirmPassword;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LoginInfo";

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
            var ret = base.Clone() as LoginInfo;
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
            var ret = base.Clone() as LoginInfo;
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
        public LoginInfo CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LoginInfo;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfUserID; } }
        public string KeyName { get { return "idfUserID"; } }
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
        
            var _prev_idfsSite_Site = idfsSite;
            base.RejectChanges();
        
            if (_prev_idfsSite_Site != idfsSite)
            {
                _Site = _SiteLookup.FirstOrDefault(c => c.idfsSite == idfsSite);
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

        private bool IsRIRPropChanged(string fld, LoginInfo c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public LoginInfo()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LoginInfo_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LoginInfo_PropertyChanged);
        }
        private void LoginInfo_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LoginInfo).Changed(e.PropertyName);
            
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
            LoginInfo obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LoginInfo obj = this;
            
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


        internal Dictionary<string, Func<LoginInfo, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<LoginInfo, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LoginInfo, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LoginInfo, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<LoginInfo, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<LoginInfo, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<LoginInfo, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LoginInfo()
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
        public class LoginInfoGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfUserID { get; set; }
        
            public String strSiteID { get; set; }
        
            public String strSiteType { get; set; }
        
            public String strSiteName { get; set; }
        
            public String strAccountName { get; set; }
        
        }
        public partial class LoginInfoGridModelList : List<LoginInfoGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public LoginInfoGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LoginInfo>, errMes);
            }
            public LoginInfoGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LoginInfo>, errMes);
            }
            public LoginInfoGridModelList(long key, IEnumerable<LoginInfo> items)
            {
                LoadGridModelList(key, items, null);
            }
            public LoginInfoGridModelList(long key)
            {
                LoadGridModelList(key, new List<LoginInfo>(), null);
            }
            partial void filter(List<LoginInfo> items);
            private void LoadGridModelList(long key, IEnumerable<LoginInfo> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strSiteID,_str_strSiteType,_str_strSiteName,_str_strAccountName};
                    
                Hiddens = new List<string> {_str_idfUserID};
                Keys = new List<string> {_str_idfUserID};
                Labels = new Dictionary<string, string> {{_str_strSiteID, _str_strSiteID},{_str_strSiteType, _str_strSiteType},{_str_strSiteName, _str_strSiteName},{_str_strAccountName, _str_strAccountName}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                LoginInfo.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<LoginInfo>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new LoginInfoGridModel()
                {
                    ItemKey=c.idfUserID,strSiteID=c.strSiteID,strSiteType=c.strSiteType,strSiteName=c.strSiteName,strAccountName=c.strAccountName
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
        : DataAccessor<LoginInfo>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<LoginInfo>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfUserID"; } }
            #endregion
        
            private delegate void on_action(LoginInfo obj);
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
            private SiteLookup.Accessor SiteAccessor { get { return eidss.model.Schema.SiteLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<LoginInfo> SelectList(DbManagerProxy manager
                , Int64? idfPerson
                )
            {
                return _SelectList(manager
                    , idfPerson
                    , delegate(LoginInfo obj)
                        {
                        }
                    , delegate(LoginInfo obj)
                        {
                        }
                    );
            }

            
            private List<LoginInfo> _SelectList(DbManagerProxy manager
                , Int64? idfPerson
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<LoginInfo> objs = new List<LoginInfo>();
                    sets[0] = new MapResultSet(typeof(LoginInfo), objs);
                    
                    manager
                        .SetSpCommand("spLoginInfo_SelectDetail"
                            , manager.Parameter("@idfPerson", idfPerson)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, LoginInfo obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj.strPasswordDecrypted = null;
                obj.strConfirmPassword = null;
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LoginInfo obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LoginInfo _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    LoginInfo obj = LoginInfo.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfUserID = (new GetNewIDExtender<LoginInfo>()).GetScalar(manager, obj, isFake);
                obj.idfsSite = (new GetSiteIDExtender<LoginInfo>()).GetScalar(manager, obj, isFake);
                obj.strPasswordDecrypted = null;
                obj.strConfirmPassword = null;
                obj.datPasswordSet = new Func<LoginInfo, DateTime>(c => DateTime.Now)(obj);
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

            
            public LoginInfo CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public LoginInfo CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public LoginInfo CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public LoginInfo CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 2) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfPerson", typeof(long));
                if (pars[1] != null && !(pars[1] is SiteLookup)) 
                    throw new TypeMismatchException("Site", typeof(SiteLookup));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    , (SiteLookup)pars[1]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public LoginInfo Create(DbManagerProxy manager, IObject Parent
                , long idfPerson
                , SiteLookup Site
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfPerson = new Func<LoginInfo, long>(c => idfPerson)(obj);
                obj.strSiteID = new Func<LoginInfo, string>(c => Site.strSiteID)(obj);
                obj.strSiteName = new Func<LoginInfo, string>(c => Site.strSiteName)(obj);
                obj.strSiteType = new Func<LoginInfo, string>(c => Site.strSiteType)(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(LoginInfo obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LoginInfo obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsSite)
                        {
                    
                obj.strSiteID = new Func<LoginInfo, string>(c => c.Site.strSiteID)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSite)
                        {
                    
                obj.strSiteName = new Func<LoginInfo, string>(c => c.Site.strSiteName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSite)
                        {
                    
                obj.strSiteType = new Func<LoginInfo, string>(c => c.Site.strSiteType)(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Site(DbManagerProxy manager, LoginInfo obj)
            {
                
                obj.SiteLookup.Clear();
                
                obj.SiteLookup.Add(SiteAccessor.CreateNewT(manager, null));
                
                obj.SiteLookup.AddRange(SiteAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSite == obj.idfsSite))
                    
                    .ToList());
                
                if (obj.idfsSite != 0)
                {
                    obj.Site = obj.SiteLookup
                        .SingleOrDefault(c => c.idfsSite == obj.idfsSite);
                    
                }
              
                
                LookupManager.AddObject("SiteLookup", obj, SiteAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, LoginInfo obj)
            {
                
                LoadLookup_Site(manager, obj);
                
            }
    
            [SprocName("spLoginInfo_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? idfUserID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? idfUserID
                )
            {
                
                _postDelete(manager, idfUserID);
                
            }
        
            [SprocName("spLoginInfo_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] LoginInfo obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] LoginInfo obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    LoginInfo bo = obj as LoginInfo;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("User", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("User", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("User", "Update");
                    }
                    
                    long mainObject = bo.idfUserID;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as LoginInfo, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, LoginInfo obj, bool bChildObject) 
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
              //если меняли пароль
              if (obj.strPasswordDecrypted != null) obj.binPassword = SecurityHelper.GetPasswordHash(obj.strPasswordDecrypted);
            
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
            
            public bool ValidateCanDelete(LoginInfo obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, LoginInfo obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(LoginInfo obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(LoginInfo obj, bool bRethrowException)
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
                return Validate(manager, obj as LoginInfo, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LoginInfo obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                CheckPasswords(obj);
            
                CheckPasswords(obj);
            
                (new RequiredValidator( "strAccountName", "strAccountName","strAccountName",
                false
              )).Validate(c => true, obj, obj.strAccountName);
            
                (new RequiredValidator( "idfsSite", "idfsSite","idfsSite",
                false
              )).Validate(c => true, obj, obj.idfsSite);
            
                ValidateLogin(manager, obj);
            
                  
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
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("User.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("User.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("User.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("User.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(LoginInfo obj)
            {
            
                obj
                    .AddRequired("strAccountName", c => true);
                    
                obj
                    .AddRequired("idfsSite", c => true);
                    
                  obj
                    .AddRequired("Site", c => true);
                
            }
    
    private void _SetupPersonalDataRestrictions(LoginInfo obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LoginInfo) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LoginInfo) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LoginInfoDetail"; } }
            public string HelpIdWin { get { return "UserGroupForm"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private LoginInfo m_obj;
            internal Permissions(LoginInfo obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("User.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("User.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("User.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("User.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spLoginInfo_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spLoginInfo_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spLoginInfo_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LoginInfo, bool>> RequiredByField = new Dictionary<string, Func<LoginInfo, bool>>();
            public static Dictionary<string, Func<LoginInfo, bool>> RequiredByProperty = new Dictionary<string, Func<LoginInfo, bool>>();
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
                
                Sizes.Add(_str_strAccountName, 200);
                Sizes.Add(_str_strSiteID, 36);
                Sizes.Add(_str_strSiteName, 200);
                Sizes.Add(_str_strSiteType, 2000);
                if (!RequiredByField.ContainsKey("strAccountName")) RequiredByField.Add("strAccountName", c => true);
                if (!RequiredByProperty.ContainsKey("strAccountName")) RequiredByProperty.Add("strAccountName", c => true);
                
                if (!RequiredByField.ContainsKey("idfsSite")) RequiredByField.Add("idfsSite", c => true);
                if (!RequiredByProperty.ContainsKey("idfsSite")) RequiredByProperty.Add("idfsSite", c => true);
                
                if (!RequiredByField.ContainsKey("strConfirmPassword")) RequiredByField.Add("strConfirmPassword", c => true);
                if (!RequiredByProperty.ContainsKey("strConfirmPassword")) RequiredByProperty.Add("strConfirmPassword", c => true);
                
                if (!RequiredByField.ContainsKey("strPasswordDecrypted")) RequiredByField.Add("strPasswordDecrypted", c => true);
                if (!RequiredByProperty.ContainsKey("strPasswordDecrypted")) RequiredByProperty.Add("strPasswordDecrypted", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfUserID,
                    _str_idfUserID, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSiteID,
                    _str_strSiteID, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSiteType,
                    _str_strSiteType, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSiteName,
                    _str_strSiteName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAccountName,
                    _str_strAccountName, null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "LoginInfoOk",
                    ActionTypes.Close,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
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
                    (c, a, p, b) => c!=null && !c.ReadOnly,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).Create(manager, c, pars)),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
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
                    (c, p, b) => eidss.model.Core.EidssUserContext.User.HasPermission(bv.common.Core.PermissionHelper.InsertPermission(eidss.model.Enums.EIDSSPermissionObject.User)),
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
                    (manager, c, pars) => ((LoginInfo)c).MarkToDelete(),
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
	