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
    public abstract partial class SiteActivationServerListItem : 
        EditableObject<SiteActivationServerListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsSite), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsSite { get; set; }
                
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
                
        [LocalizedDisplayName(_str_idfsCountry)]
        [MapField(_str_idfsCountry)]
        public abstract Int64 idfsCountry { get; set; }
        protected Int64 idfsCountry_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCountry).OriginalValue; } }
        protected Int64 idfsCountry_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCountry).PreviousValue; } }
                
        [LocalizedDisplayName("idfsCountry")]
        [MapField(_str_Country)]
        public abstract String Country { get; set; }
        protected String Country_Original { get { return ((EditableValue<String>)((dynamic)this)._country).OriginalValue; } }
        protected String Country_Previous { get { return ((EditableValue<String>)((dynamic)this)._country).PreviousValue; } }
                
        [LocalizedDisplayName("Abbreviation")]
        [MapField(_str_name)]
        public abstract String name { get; set; }
        protected String name_Original { get { return ((EditableValue<String>)((dynamic)this)._name).OriginalValue; } }
        protected String name_Previous { get { return ((EditableValue<String>)((dynamic)this)._name).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strServerName)]
        [MapField(_str_strServerName)]
        public abstract String strServerName { get; set; }
        protected String strServerName_Original { get { return ((EditableValue<String>)((dynamic)this)._strServerName).OriginalValue; } }
        protected String strServerName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strServerName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHASCsiteID)]
        [MapField(_str_strHASCsiteID)]
        public abstract String strHASCsiteID { get; set; }
        protected String strHASCsiteID_Original { get { return ((EditableValue<String>)((dynamic)this)._strHASCsiteID).OriginalValue; } }
        protected String strHASCsiteID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHASCsiteID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSiteID)]
        [MapField(_str_strSiteID)]
        public abstract String strSiteID { get; set; }
        protected String strSiteID_Original { get { return ((EditableValue<String>)((dynamic)this)._strSiteID).OriginalValue; } }
        protected String strSiteID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSiteID).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<SiteActivationServerListItem, object> _get_func;
            internal Action<SiteActivationServerListItem, string> _set_func;
            internal Action<SiteActivationServerListItem, SiteActivationServerListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_strSiteName = "strSiteName";
        internal const string _str_idfsSiteType = "idfsSiteType";
        internal const string _str_strSiteType = "strSiteType";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_Country = "Country";
        internal const string _str_name = "name";
        internal const string _str_strServerName = "strServerName";
        internal const string _str_strHASCsiteID = "strHASCsiteID";
        internal const string _str_strSiteID = "strSiteID";
        internal const string _str_CountryName = "CountryName";
        internal const string _str_SiteType = "SiteType";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsSite, _formname = _str_idfsSite, _type = "Int64",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsSite != newval) o.idfsSite = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_idfsSite, c)) 
                  m.Add(_str_idfsSite, o.ObjectIdent + _str_idfsSite, o.ObjectIdent2 + _str_idfsSite, o.ObjectIdent3 + _str_idfsSite, "Int64", 
                    o.idfsSite == null ? "" : o.idfsSite.ToString(),                  
                  o.IsReadOnly(_str_idfsSite), o.IsInvisible(_str_idfsSite), o.IsRequired(_str_idfsSite)); 
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsSiteType != newval) 
                  o.SiteType = o.SiteTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsSiteType != newval) o.idfsSiteType = newval; },
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
              _name = _str_idfsCountry, _formname = _str_idfsCountry, _type = "Int64",
              _get_func = o => o.idfsCountry,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsCountry != newval) 
                  o.CountryName = o.CountryNameLookup.FirstOrDefault(c => c.idfsCountry == newval);
                if (o.idfsCountry != newval) o.idfsCountry = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_idfsCountry, c)) 
                  m.Add(_str_idfsCountry, o.ObjectIdent + _str_idfsCountry, o.ObjectIdent2 + _str_idfsCountry, o.ObjectIdent3 + _str_idfsCountry, "Int64", 
                    o.idfsCountry == null ? "" : o.idfsCountry.ToString(),                  
                  o.IsReadOnly(_str_idfsCountry), o.IsInvisible(_str_idfsCountry), o.IsRequired(_str_idfsCountry)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Country, _formname = _str_Country, _type = "String",
              _get_func = o => o.Country,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.Country != newval) o.Country = newval; },
              _compare_func = (o, c, m) => {
                if (o.Country != c.Country || o.IsRIRPropChanged(_str_Country, c)) 
                  m.Add(_str_Country, o.ObjectIdent + _str_Country, o.ObjectIdent2 + _str_Country, o.ObjectIdent3 + _str_Country, "String", 
                    o.Country == null ? "" : o.Country.ToString(),                  
                  o.IsReadOnly(_str_Country), o.IsInvisible(_str_Country), o.IsRequired(_str_Country)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_name, _formname = _str_name, _type = "String",
              _get_func = o => o.name,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.name != newval) o.name = newval; },
              _compare_func = (o, c, m) => {
                if (o.name != c.name || o.IsRIRPropChanged(_str_name, c)) 
                  m.Add(_str_name, o.ObjectIdent + _str_name, o.ObjectIdent2 + _str_name, o.ObjectIdent3 + _str_name, "String", 
                    o.name == null ? "" : o.name.ToString(),                  
                  o.IsReadOnly(_str_name), o.IsInvisible(_str_name), o.IsRequired(_str_name)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strServerName, _formname = _str_strServerName, _type = "String",
              _get_func = o => o.strServerName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strServerName != newval) o.strServerName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strServerName != c.strServerName || o.IsRIRPropChanged(_str_strServerName, c)) 
                  m.Add(_str_strServerName, o.ObjectIdent + _str_strServerName, o.ObjectIdent2 + _str_strServerName, o.ObjectIdent3 + _str_strServerName, "String", 
                    o.strServerName == null ? "" : o.strServerName.ToString(),                  
                  o.IsReadOnly(_str_strServerName), o.IsInvisible(_str_strServerName), o.IsRequired(_str_strServerName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHASCsiteID, _formname = _str_strHASCsiteID, _type = "String",
              _get_func = o => o.strHASCsiteID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHASCsiteID != newval) o.strHASCsiteID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strHASCsiteID != c.strHASCsiteID || o.IsRIRPropChanged(_str_strHASCsiteID, c)) 
                  m.Add(_str_strHASCsiteID, o.ObjectIdent + _str_strHASCsiteID, o.ObjectIdent2 + _str_strHASCsiteID, o.ObjectIdent3 + _str_strHASCsiteID, "String", 
                    o.strHASCsiteID == null ? "" : o.strHASCsiteID.ToString(),                  
                  o.IsReadOnly(_str_strHASCsiteID), o.IsInvisible(_str_strHASCsiteID), o.IsRequired(_str_strHASCsiteID)); 
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
              _name = _str_CountryName, _formname = _str_CountryName, _type = "Lookup",
              _get_func = o => { if (o.CountryName == null) return null; return o.CountryName.idfsCountry; },
              _set_func = (o, val) => { o.CountryName = o.CountryNameLookup.Where(c => c.idfsCountry.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_CountryName, c)) {
                  m.Add(_str_CountryName, o.ObjectIdent + _str_CountryName, o.ObjectIdent2 + _str_CountryName, o.ObjectIdent3 + _str_CountryName, "Lookup", o.idfsCountry == null ? "" : o.idfsCountry.ToString(), o.IsReadOnly(_str_CountryName), o.IsInvisible(_str_CountryName), o.IsRequired(_str_CountryName)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_CountryName + "Lookup", _formname = _str_CountryName + "Lookup", _type = "LookupContent",
              _get_func = o => o.CountryNameLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_SiteType, _formname = _str_SiteType, _type = "Lookup",
              _get_func = o => { if (o.SiteType == null) return null; return o.SiteType.idfsBaseReference; },
              _set_func = (o, val) => { o.SiteType = o.SiteTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSiteType != c.idfsSiteType || o.IsRIRPropChanged(_str_SiteType, c)) {
                  m.Add(_str_SiteType, o.ObjectIdent + _str_SiteType, o.ObjectIdent2 + _str_SiteType, o.ObjectIdent3 + _str_SiteType, "Lookup", o.idfsSiteType == null ? "" : o.idfsSiteType.ToString(), o.IsReadOnly(_str_SiteType), o.IsInvisible(_str_SiteType), o.IsRequired(_str_SiteType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SiteType + "Lookup", _formname = _str_SiteType + "Lookup", _type = "LookupContent",
              _get_func = o => o.SiteTypeLookup,
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
            SiteActivationServerListItem obj = (SiteActivationServerListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_CountryName)]
        [Relation(typeof(CountryLookup), eidss.model.Schema.CountryLookup._str_idfsCountry, _str_idfsCountry)]
        public CountryLookup CountryName
        {
            get { return _CountryName == null ? null : ((long)_CountryName.Key == 0 ? null : _CountryName); }
            set 
            { 
                var oldVal = _CountryName;
                _CountryName = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_CountryName != oldVal)
                {
                    if (idfsCountry != (_CountryName == null
                            ? new Int64()
                            : (Int64)_CountryName.idfsCountry))
                        idfsCountry = _CountryName == null 
                            ? new Int64()
                            : (Int64)_CountryName.idfsCountry; 
                    OnPropertyChanged(_str_CountryName); 
                }
            }
        }
        private CountryLookup _CountryName;

        
        public List<CountryLookup> CountryNameLookup
        {
            get { return _CountryNameLookup; }
        }
        private List<CountryLookup> _CountryNameLookup = new List<CountryLookup>();
            
        [LocalizedDisplayName(_str_SiteType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSiteType)]
        public BaseReference SiteType
        {
            get { return _SiteType == null ? null : ((long)_SiteType.Key == 0 ? null : _SiteType); }
            set 
            { 
                var oldVal = _SiteType;
                _SiteType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SiteType != oldVal)
                {
                    if (idfsSiteType != (_SiteType == null
                            ? new Int64?()
                            : (Int64?)_SiteType.idfsBaseReference))
                        idfsSiteType = _SiteType == null 
                            ? new Int64?()
                            : (Int64?)_SiteType.idfsBaseReference; 
                    OnPropertyChanged(_str_SiteType); 
                }
            }
        }
        private BaseReference _SiteType;

        
        public BaseReferenceList SiteTypeLookup
        {
            get { return _SiteTypeLookup; }
        }
        private BaseReferenceList _SiteTypeLookup = new BaseReferenceList("rftSiteType");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_CountryName:
                    return new BvSelectList(CountryNameLookup, eidss.model.Schema.CountryLookup._str_idfsCountry, null, CountryName, _str_idfsCountry);
            
                case _str_SiteType:
                    return new BvSelectList(SiteTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SiteType, _str_idfsSiteType);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "SiteActivationServerListItem";

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
            var ret = base.Clone() as SiteActivationServerListItem;
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
            var ret = base.Clone() as SiteActivationServerListItem;
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
        public SiteActivationServerListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as SiteActivationServerListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsSite; } }
        public string KeyName { get { return "idfsSite"; } }
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
        
            var _prev_idfsCountry_CountryName = idfsCountry;
            var _prev_idfsSiteType_SiteType = idfsSiteType;
            base.RejectChanges();
        
            if (_prev_idfsCountry_CountryName != idfsCountry)
            {
                _CountryName = _CountryNameLookup.FirstOrDefault(c => c.idfsCountry == idfsCountry);
            }
            if (_prev_idfsSiteType_SiteType != idfsSiteType)
            {
                _SiteType = _SiteTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSiteType);
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

        private bool IsRIRPropChanged(string fld, SiteActivationServerListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public SiteActivationServerListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SiteActivationServerListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(SiteActivationServerListItem_PropertyChanged);
        }
        private void SiteActivationServerListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as SiteActivationServerListItem).Changed(e.PropertyName);
            
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
            SiteActivationServerListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            SiteActivationServerListItem obj = this;
            
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


        internal Dictionary<string, Func<SiteActivationServerListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<SiteActivationServerListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<SiteActivationServerListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<SiteActivationServerListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<SiteActivationServerListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<SiteActivationServerListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<SiteActivationServerListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~SiteActivationServerListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("CountryLookup", this);
                
                LookupManager.RemoveObject("rftSiteType", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "CountryLookup")
                _getAccessor().LoadLookup_CountryName(manager, this);
            
            if (lookup_object == "rftSiteType")
                _getAccessor().LoadLookup_SiteType(manager, this);
            
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
        public class SiteActivationServerListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfsSite { get; set; }
        
            public String strSiteID { get; set; }
        
            public String strSiteName { get; set; }
        
            public String strSiteType { get; set; }
        
            public String Country { get; set; }
        
            public String name { get; set; }
        
            public String strServerName { get; set; }
        
            public String strHASCsiteID { get; set; }
        
        }
        public partial class SiteActivationServerListItemGridModelList : List<SiteActivationServerListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public SiteActivationServerListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<SiteActivationServerListItem>, errMes);
            }
            public SiteActivationServerListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<SiteActivationServerListItem>, errMes);
            }
            public SiteActivationServerListItemGridModelList(long key, IEnumerable<SiteActivationServerListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public SiteActivationServerListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<SiteActivationServerListItem>(), null);
            }
            partial void filter(List<SiteActivationServerListItem> items);
            private void LoadGridModelList(long key, IEnumerable<SiteActivationServerListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strSiteID,_str_strSiteName,_str_strSiteType,_str_Country,_str_name,_str_strServerName,_str_strHASCsiteID};
                    
                Hiddens = new List<string> {_str_idfsSite};
                Keys = new List<string> {_str_idfsSite};
                Labels = new Dictionary<string, string> {{_str_strSiteID, _str_strSiteID},{_str_strSiteName, _str_strSiteName},{_str_strSiteType, _str_strSiteType},{_str_Country, "idfsCountry"},{_str_name, "Abbreviation"},{_str_strServerName, _str_strServerName},{_str_strHASCsiteID, _str_strHASCsiteID}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                SiteActivationServerListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<SiteActivationServerListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new SiteActivationServerListItemGridModel()
                {
                    ItemKey=c.idfsSite,strSiteID=c.strSiteID,strSiteName=c.strSiteName,strSiteType=c.strSiteType,Country=c.Country,name=c.name,strServerName=c.strServerName,strHASCsiteID=c.strHASCsiteID
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
        : DataAccessor<SiteActivationServerListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<SiteActivationServerListItem>
            
            , IObjectSelectList
            , IObjectSelectList<SiteActivationServerListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsSite"; } }
            #endregion
        
            private delegate void on_action(SiteActivationServerListItem obj);
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
            private CountryLookup.Accessor CountryNameAccessor { get { return eidss.model.Schema.CountryLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SiteTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<SiteActivationServerListItem> SelectListT(DbManagerProxy manager
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
            
            private List<SiteActivationServerListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_SiteActivationServer_SelectList.* from dbo.fn_SiteActivationServer_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfsSite"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSite"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSite") ? " or " : " and ");
                        
                        if (filters.Operation("idfsSite", i) == "&")
                          sql.AppendFormat("(isnull(fn_SiteActivationServer_SelectList.idfsSite,0) {0} @idfsSite_{1} = @idfsSite_{1})", filters.Operation("idfsSite", i), i);
                        else
                          sql.AppendFormat("isnull(fn_SiteActivationServer_SelectList.idfsSite,0) {0} @idfsSite_{1}", filters.Operation("idfsSite", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSiteName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSiteName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSiteName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SiteActivationServer_SelectList.strSiteName {0} @strSiteName_{1}", filters.Operation("strSiteName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSiteType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSiteType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSiteType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsSiteType", i) == "&")
                          sql.AppendFormat("(isnull(fn_SiteActivationServer_SelectList.idfsSiteType,0) {0} @idfsSiteType_{1} = @idfsSiteType_{1})", filters.Operation("idfsSiteType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_SiteActivationServer_SelectList.idfsSiteType,0) {0} @idfsSiteType_{1}", filters.Operation("idfsSiteType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSiteType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSiteType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSiteType") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SiteActivationServer_SelectList.strSiteType {0} @strSiteType_{1}", filters.Operation("strSiteType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCountry"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCountry"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCountry") ? " or " : " and ");
                        
                        if (filters.Operation("idfsCountry", i) == "&")
                          sql.AppendFormat("(isnull(fn_SiteActivationServer_SelectList.idfsCountry,0) {0} @idfsCountry_{1} = @idfsCountry_{1})", filters.Operation("idfsCountry", i), i);
                        else
                          sql.AppendFormat("isnull(fn_SiteActivationServer_SelectList.idfsCountry,0) {0} @idfsCountry_{1}", filters.Operation("idfsCountry", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("Country"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("Country"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("Country") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SiteActivationServer_SelectList.Country {0} @Country_{1}", filters.Operation("Country", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("name"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("name"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("name") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SiteActivationServer_SelectList.name {0} @name_{1}", filters.Operation("name", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strServerName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strServerName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strServerName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SiteActivationServer_SelectList.strServerName {0} @strServerName_{1}", filters.Operation("strServerName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strHASCsiteID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strHASCsiteID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strHASCsiteID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SiteActivationServer_SelectList.strHASCsiteID {0} @strHASCsiteID_{1}", filters.Operation("strHASCsiteID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSiteID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSiteID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSiteID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SiteActivationServer_SelectList.strSiteID {0} @strSiteID_{1}", filters.Operation("strSiteID", i), i);
                            
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
                    
                    if (filters.Contains("idfsSite"))
                        for (int i = 0; i < filters.Count("idfsSite"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSite_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSite", i), filters.Value("idfsSite", i))));
                      
                    if (filters.Contains("strSiteName"))
                        for (int i = 0; i < filters.Count("strSiteName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSiteName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSiteName", i), filters.Value("strSiteName", i))));
                      
                    if (filters.Contains("idfsSiteType"))
                        for (int i = 0; i < filters.Count("idfsSiteType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSiteType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSiteType", i), filters.Value("idfsSiteType", i))));
                      
                    if (filters.Contains("strSiteType"))
                        for (int i = 0; i < filters.Count("strSiteType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSiteType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSiteType", i), filters.Value("strSiteType", i))));
                      
                    if (filters.Contains("idfsCountry"))
                        for (int i = 0; i < filters.Count("idfsCountry"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCountry_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCountry", i), filters.Value("idfsCountry", i))));
                      
                    if (filters.Contains("Country"))
                        for (int i = 0; i < filters.Count("Country"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@Country_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("Country", i), filters.Value("Country", i))));
                      
                    if (filters.Contains("name"))
                        for (int i = 0; i < filters.Count("name"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@name_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("name", i), filters.Value("name", i))));
                      
                    if (filters.Contains("strServerName"))
                        for (int i = 0; i < filters.Count("strServerName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strServerName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strServerName", i), filters.Value("strServerName", i))));
                      
                    if (filters.Contains("strHASCsiteID"))
                        for (int i = 0; i < filters.Count("strHASCsiteID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strHASCsiteID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strHASCsiteID", i), filters.Value("strHASCsiteID", i))));
                      
                    if (filters.Contains("strSiteID"))
                        for (int i = 0; i < filters.Count("strSiteID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSiteID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSiteID", i), filters.Value("strSiteID", i))));
                      
                    List<SiteActivationServerListItem> objs = manager.ExecuteList<SiteActivationServerListItem>();
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
            partial void ListSelected(DbManagerProxy manager, List<SiteActivationServerListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spSiteActivationServer_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, SiteActivationServerListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, SiteActivationServerListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private SiteActivationServerListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    SiteActivationServerListItem obj = SiteActivationServerListItem.CreateInstance();
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

            
            public SiteActivationServerListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public SiteActivationServerListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public SiteActivationServerListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(SiteActivationServerListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(SiteActivationServerListItem obj)
            {
                
            }
    
            public void LoadLookup_CountryName(DbManagerProxy manager, SiteActivationServerListItem obj)
            {
                
                obj.CountryNameLookup.Clear();
                
                obj.CountryNameLookup.Add(CountryNameAccessor.CreateNewT(manager, null));
                
                obj.CountryNameLookup.AddRange(CountryNameAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsCountry == obj.idfsCountry))
                    
                    .ToList());
                
                if (obj.idfsCountry != 0)
                {
                    obj.CountryName = obj.CountryNameLookup
                        .SingleOrDefault(c => c.idfsCountry == obj.idfsCountry);
                    
                }
              
                
                LookupManager.AddObject("CountryLookup", obj, CountryNameAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_SiteType(DbManagerProxy manager, SiteActivationServerListItem obj)
            {
                
                obj.SiteTypeLookup.Clear();
                
                obj.SiteTypeLookup.Add(SiteTypeAccessor.CreateNewT(manager, null));
                
                obj.SiteTypeLookup.AddRange(SiteTypeAccessor.rftSiteType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSiteType))
                    
                    .ToList());
                
                if (obj.idfsSiteType != null && obj.idfsSiteType != 0)
                {
                    obj.SiteType = obj.SiteTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsSiteType);
                    
                }
              
                
                LookupManager.AddObject("rftSiteType", obj, SiteTypeAccessor.GetType(), "rftSiteType_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, SiteActivationServerListItem obj)
            {
                
                LoadLookup_CountryName(manager, obj);
                
                LoadLookup_SiteType(manager, obj);
                
            }
    
            [SprocName("spReadOnlyObject_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spReadOnlyObject_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    SiteActivationServerListItem bo = obj as SiteActivationServerListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("EIDSSSite", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("EIDSSSite", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("EIDSSSite", "Update");
                    }
                    
                    long mainObject = bo.idfsSite;
                    
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
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            
                        }
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as SiteActivationServerListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, SiteActivationServerListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfsSite
                        );
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(SiteActivationServerListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, SiteActivationServerListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfsSite
                            , out result
                            );
                        if (!result) 
                        {
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, false, obj);
                        }
                     }
                }
                catch(ValidationModelException ex)
                {
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                    else
                        obj.m_IsForcedToDelete = true;
                }
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(SiteActivationServerListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(SiteActivationServerListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as SiteActivationServerListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, SiteActivationServerListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EIDSSSite.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EIDSSSite.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EIDSSSite.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EIDSSSite.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(SiteActivationServerListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(SiteActivationServerListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as SiteActivationServerListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as SiteActivationServerListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "SiteActivationServerListItemDetail"; } }
            public string HelpIdWin { get { return "EIDSS_sites"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private SiteActivationServerListItem m_obj;
            internal Permissions(SiteActivationServerListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EIDSSSite.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EIDSSSite.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EIDSSSite.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EIDSSSite.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_SiteActivationServer_SelectList";
            public static string spCount = "spSiteActivationServer_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spReadOnlyObject_Delete";
            public static string spCanDelete = "spReadOnlyObject_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<SiteActivationServerListItem, bool>> RequiredByField = new Dictionary<string, Func<SiteActivationServerListItem, bool>>();
            public static Dictionary<string, Func<SiteActivationServerListItem, bool>> RequiredByProperty = new Dictionary<string, Func<SiteActivationServerListItem, bool>>();
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
                
                Sizes.Add(_str_strSiteName, 200);
                Sizes.Add(_str_strSiteType, 2000);
                Sizes.Add(_str_Country, 300);
                Sizes.Add(_str_name, 2000);
                Sizes.Add(_str_strServerName, 200);
                Sizes.Add(_str_strHASCsiteID, 50);
                Sizes.Add(_str_strSiteID, 36);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strSiteID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strSiteID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strSiteName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strSiteName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSiteType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strSiteType",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "SiteTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsCountry",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsCountry",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "CountryNameLookup", typeof(CountryLookup), (o) => { var c = (CountryLookup)o; return c.idfsCountry; }, (o) => { var c = (CountryLookup)o; return c.strCountryName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "name",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "Abbreviation",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strServerName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strServerName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strHASCsiteID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strHASCsiteID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsSite,
                    _str_idfsSite, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSiteID,
                    _str_strSiteID, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSiteName,
                    _str_strSiteName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSiteType,
                    _str_strSiteType, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Country,
                    "idfsCountry", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_name,
                    "Abbreviation", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strServerName,
                    _str_strServerName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strHASCsiteID,
                    _str_strHASCsiteID, null, true, true, true, true, null
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
                    "Edit",
                    ActionTypes.Edit,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<SiteActivationServer>().SelectDetail(manager, pars[0])),
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
	