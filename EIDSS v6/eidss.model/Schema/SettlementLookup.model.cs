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
    public abstract partial class SettlementLookup : 
        EditableObject<SettlementLookup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsSettlement), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsSettlement { get; set; }
                
        [LocalizedDisplayName(_str_strSettlementName)]
        [MapField(_str_strSettlementName)]
        public abstract String strSettlementName { get; set; }
        protected String strSettlementName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSettlementName).OriginalValue; } }
        protected String strSettlementName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSettlementName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSettlementExtendedName)]
        [MapField(_str_strSettlementExtendedName)]
        public abstract String strSettlementExtendedName { get; set; }
        protected String strSettlementExtendedName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSettlementExtendedName).OriginalValue; } }
        protected String strSettlementExtendedName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSettlementExtendedName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRayon)]
        [MapField(_str_idfsRayon)]
        public abstract Int64 idfsRayon { get; set; }
        protected Int64 idfsRayon_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsRayon).OriginalValue; } }
        protected Int64 idfsRayon_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsRayon).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRegion)]
        [MapField(_str_idfsRegion)]
        public abstract Int64 idfsRegion { get; set; }
        protected Int64 idfsRegion_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsRegion).OriginalValue; } }
        protected Int64 idfsRegion_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsRegion).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCountry)]
        [MapField(_str_idfsCountry)]
        public abstract Int64 idfsCountry { get; set; }
        protected Int64 idfsCountry_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCountry).OriginalValue; } }
        protected Int64 idfsCountry_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCountry).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSettlementType)]
        [MapField(_str_strSettlementType)]
        public abstract String strSettlementType { get; set; }
        protected String strSettlementType_Original { get { return ((EditableValue<String>)((dynamic)this)._strSettlementType).OriginalValue; } }
        protected String strSettlementType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSettlementType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intRowStatus)]
        [MapField(_str_intRowStatus)]
        public abstract Int32 intRowStatus { get; set; }
        protected Int32 intRowStatus_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).OriginalValue; } }
        protected Int32 intRowStatus_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCountryName)]
        [MapField(_str_strCountryName)]
        public abstract String strCountryName { get; set; }
        protected String strCountryName_Original { get { return ((EditableValue<String>)((dynamic)this)._strCountryName).OriginalValue; } }
        protected String strCountryName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCountryName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRegionExtendedName)]
        [MapField(_str_strRegionExtendedName)]
        public abstract String strRegionExtendedName { get; set; }
        protected String strRegionExtendedName_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegionExtendedName).OriginalValue; } }
        protected String strRegionExtendedName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegionExtendedName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRayonExtendedName)]
        [MapField(_str_strRayonExtendedName)]
        public abstract String strRayonExtendedName { get; set; }
        protected String strRayonExtendedName_Original { get { return ((EditableValue<String>)((dynamic)this)._strRayonExtendedName).OriginalValue; } }
        protected String strRayonExtendedName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRayonExtendedName).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<SettlementLookup, object> _get_func;
            internal Action<SettlementLookup, string> _set_func;
            internal Action<SettlementLookup, SettlementLookup, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_strSettlementName = "strSettlementName";
        internal const string _str_strSettlementExtendedName = "strSettlementExtendedName";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_strSettlementType = "strSettlementType";
        internal const string _str_intRowStatus = "intRowStatus";
        internal const string _str_strCountryName = "strCountryName";
        internal const string _str_strRegionExtendedName = "strRegionExtendedName";
        internal const string _str_strRayonExtendedName = "strRayonExtendedName";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsSettlement, _formname = _str_idfsSettlement, _type = "Int64",
              _get_func = o => o.idfsSettlement,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsSettlement != newval) o.idfsSettlement = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_idfsSettlement, c)) 
                  m.Add(_str_idfsSettlement, o.ObjectIdent + _str_idfsSettlement, o.ObjectIdent2 + _str_idfsSettlement, o.ObjectIdent3 + _str_idfsSettlement, "Int64", 
                    o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(),                  
                  o.IsReadOnly(_str_idfsSettlement), o.IsInvisible(_str_idfsSettlement), o.IsRequired(_str_idfsSettlement)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSettlementName, _formname = _str_strSettlementName, _type = "String",
              _get_func = o => o.strSettlementName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSettlementName != newval) o.strSettlementName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSettlementName != c.strSettlementName || o.IsRIRPropChanged(_str_strSettlementName, c)) 
                  m.Add(_str_strSettlementName, o.ObjectIdent + _str_strSettlementName, o.ObjectIdent2 + _str_strSettlementName, o.ObjectIdent3 + _str_strSettlementName, "String", 
                    o.strSettlementName == null ? "" : o.strSettlementName.ToString(),                  
                  o.IsReadOnly(_str_strSettlementName), o.IsInvisible(_str_strSettlementName), o.IsRequired(_str_strSettlementName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSettlementExtendedName, _formname = _str_strSettlementExtendedName, _type = "String",
              _get_func = o => o.strSettlementExtendedName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSettlementExtendedName != newval) o.strSettlementExtendedName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSettlementExtendedName != c.strSettlementExtendedName || o.IsRIRPropChanged(_str_strSettlementExtendedName, c)) 
                  m.Add(_str_strSettlementExtendedName, o.ObjectIdent + _str_strSettlementExtendedName, o.ObjectIdent2 + _str_strSettlementExtendedName, o.ObjectIdent3 + _str_strSettlementExtendedName, "String", 
                    o.strSettlementExtendedName == null ? "" : o.strSettlementExtendedName.ToString(),                  
                  o.IsReadOnly(_str_strSettlementExtendedName), o.IsInvisible(_str_strSettlementExtendedName), o.IsRequired(_str_strSettlementExtendedName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsRayon, _formname = _str_idfsRayon, _type = "Int64",
              _get_func = o => o.idfsRayon,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsRayon != newval) o.idfsRayon = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_idfsRayon, c)) 
                  m.Add(_str_idfsRayon, o.ObjectIdent + _str_idfsRayon, o.ObjectIdent2 + _str_idfsRayon, o.ObjectIdent3 + _str_idfsRayon, "Int64", 
                    o.idfsRayon == null ? "" : o.idfsRayon.ToString(),                  
                  o.IsReadOnly(_str_idfsRayon), o.IsInvisible(_str_idfsRayon), o.IsRequired(_str_idfsRayon)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsRegion, _formname = _str_idfsRegion, _type = "Int64",
              _get_func = o => o.idfsRegion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsRegion != newval) o.idfsRegion = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_idfsRegion, c)) 
                  m.Add(_str_idfsRegion, o.ObjectIdent + _str_idfsRegion, o.ObjectIdent2 + _str_idfsRegion, o.ObjectIdent3 + _str_idfsRegion, "Int64", 
                    o.idfsRegion == null ? "" : o.idfsRegion.ToString(),                  
                  o.IsReadOnly(_str_idfsRegion), o.IsInvisible(_str_idfsRegion), o.IsRequired(_str_idfsRegion)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCountry, _formname = _str_idfsCountry, _type = "Int64",
              _get_func = o => o.idfsCountry,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsCountry != newval) o.idfsCountry = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_idfsCountry, c)) 
                  m.Add(_str_idfsCountry, o.ObjectIdent + _str_idfsCountry, o.ObjectIdent2 + _str_idfsCountry, o.ObjectIdent3 + _str_idfsCountry, "Int64", 
                    o.idfsCountry == null ? "" : o.idfsCountry.ToString(),                  
                  o.IsReadOnly(_str_idfsCountry), o.IsInvisible(_str_idfsCountry), o.IsRequired(_str_idfsCountry)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSettlementType, _formname = _str_strSettlementType, _type = "String",
              _get_func = o => o.strSettlementType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSettlementType != newval) o.strSettlementType = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSettlementType != c.strSettlementType || o.IsRIRPropChanged(_str_strSettlementType, c)) 
                  m.Add(_str_strSettlementType, o.ObjectIdent + _str_strSettlementType, o.ObjectIdent2 + _str_strSettlementType, o.ObjectIdent3 + _str_strSettlementType, "String", 
                    o.strSettlementType == null ? "" : o.strSettlementType.ToString(),                  
                  o.IsReadOnly(_str_strSettlementType), o.IsInvisible(_str_strSettlementType), o.IsRequired(_str_strSettlementType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intRowStatus, _formname = _str_intRowStatus, _type = "Int32",
              _get_func = o => o.intRowStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intRowStatus != newval) o.intRowStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.intRowStatus != c.intRowStatus || o.IsRIRPropChanged(_str_intRowStatus, c)) 
                  m.Add(_str_intRowStatus, o.ObjectIdent + _str_intRowStatus, o.ObjectIdent2 + _str_intRowStatus, o.ObjectIdent3 + _str_intRowStatus, "Int32", 
                    o.intRowStatus == null ? "" : o.intRowStatus.ToString(),                  
                  o.IsReadOnly(_str_intRowStatus), o.IsInvisible(_str_intRowStatus), o.IsRequired(_str_intRowStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCountryName, _formname = _str_strCountryName, _type = "String",
              _get_func = o => o.strCountryName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCountryName != newval) o.strCountryName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strCountryName != c.strCountryName || o.IsRIRPropChanged(_str_strCountryName, c)) 
                  m.Add(_str_strCountryName, o.ObjectIdent + _str_strCountryName, o.ObjectIdent2 + _str_strCountryName, o.ObjectIdent3 + _str_strCountryName, "String", 
                    o.strCountryName == null ? "" : o.strCountryName.ToString(),                  
                  o.IsReadOnly(_str_strCountryName), o.IsInvisible(_str_strCountryName), o.IsRequired(_str_strCountryName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRegionExtendedName, _formname = _str_strRegionExtendedName, _type = "String",
              _get_func = o => o.strRegionExtendedName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRegionExtendedName != newval) o.strRegionExtendedName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strRegionExtendedName != c.strRegionExtendedName || o.IsRIRPropChanged(_str_strRegionExtendedName, c)) 
                  m.Add(_str_strRegionExtendedName, o.ObjectIdent + _str_strRegionExtendedName, o.ObjectIdent2 + _str_strRegionExtendedName, o.ObjectIdent3 + _str_strRegionExtendedName, "String", 
                    o.strRegionExtendedName == null ? "" : o.strRegionExtendedName.ToString(),                  
                  o.IsReadOnly(_str_strRegionExtendedName), o.IsInvisible(_str_strRegionExtendedName), o.IsRequired(_str_strRegionExtendedName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRayonExtendedName, _formname = _str_strRayonExtendedName, _type = "String",
              _get_func = o => o.strRayonExtendedName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRayonExtendedName != newval) o.strRayonExtendedName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strRayonExtendedName != c.strRayonExtendedName || o.IsRIRPropChanged(_str_strRayonExtendedName, c)) 
                  m.Add(_str_strRayonExtendedName, o.ObjectIdent + _str_strRayonExtendedName, o.ObjectIdent2 + _str_strRayonExtendedName, o.ObjectIdent3 + _str_strRayonExtendedName, "String", 
                    o.strRayonExtendedName == null ? "" : o.strRayonExtendedName.ToString(),                  
                  o.IsReadOnly(_str_strRayonExtendedName), o.IsInvisible(_str_strRayonExtendedName), o.IsRequired(_str_strRayonExtendedName)); 
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
            SettlementLookup obj = (SettlementLookup)o;
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
        internal string m_ObjectName = "SettlementLookup";

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
            var ret = base.Clone() as SettlementLookup;
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
            var ret = base.Clone() as SettlementLookup;
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
        public SettlementLookup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as SettlementLookup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsSettlement; } }
        public string KeyName { get { return "idfsSettlement"; } }
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

        private bool IsRIRPropChanged(string fld, SettlementLookup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      
        public override string ToString()
        {
            return new Func<SettlementLookup, string>(c => c.strSettlementName)(this);
        }
        

        public SettlementLookup()
        {
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SettlementLookup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(SettlementLookup_PropertyChanged);
        }
        private void SettlementLookup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as SettlementLookup).Changed(e.PropertyName);
            
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
            SettlementLookup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            SettlementLookup obj = this;
            
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


        internal Dictionary<string, Func<SettlementLookup, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<SettlementLookup, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<SettlementLookup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<SettlementLookup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<SettlementLookup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<SettlementLookup, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<SettlementLookup, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~SettlementLookup()
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
        : DataAccessor<SettlementLookup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<SettlementLookup>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsSettlement"; } }
            #endregion
        
            private delegate void on_action(SettlementLookup obj);
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
            public virtual List<SettlementLookup> SelectLookupList(DbManagerProxy manager
                , Int64? RayonID
                , Int64? ID
                )
            {
                return _SelectList(manager
                    , RayonID
                    , ID
                    , null, null
                    );
            }
            
            public static string GetLookupTableName(string method)
            {
                return "Settlement";
            }
            
            public virtual List<SettlementLookup> SelectList(DbManagerProxy manager
                , Int64? RayonID
                , Int64? ID
                )
            {
                return _SelectList(manager
                    , RayonID
                    , ID
                    , delegate(SettlementLookup obj)
                        {
                        }
                    , delegate(SettlementLookup obj)
                        {
                        }
                    );
            }

            
            private List<SettlementLookup> _SelectList(DbManagerProxy manager
                , Int64? RayonID
                , Int64? ID
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<SettlementLookup> objs = new List<SettlementLookup>();
                    sets[0] = new MapResultSet(typeof(SettlementLookup), objs);
                    
                    manager
                        .SetSpCommand("spSettlement_SelectLookup"
                            , manager.Parameter("@RayonID", RayonID)
                            , manager.Parameter("@ID", ID)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, SettlementLookup obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, SettlementLookup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private SettlementLookup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    SettlementLookup obj = SettlementLookup.CreateInstance();
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

            
            public SettlementLookup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public SettlementLookup CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public SettlementLookup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(SettlementLookup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(SettlementLookup obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, SettlementLookup obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(SettlementLookup obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(SettlementLookup obj, bool bRethrowException)
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
                return Validate(manager, obj as SettlementLookup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, SettlementLookup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(SettlementLookup obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(SettlementLookup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as SettlementLookup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as SettlementLookup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "SettlementLookupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spSettlement_SelectLookup";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<SettlementLookup, bool>> RequiredByField = new Dictionary<string, Func<SettlementLookup, bool>>();
            public static Dictionary<string, Func<SettlementLookup, bool>> RequiredByProperty = new Dictionary<string, Func<SettlementLookup, bool>>();
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
                
                Sizes.Add(_str_strSettlementName, 300);
                Sizes.Add(_str_strSettlementExtendedName, 365);
                Sizes.Add(_str_strSettlementType, 300);
                Sizes.Add(_str_strCountryName, 300);
                Sizes.Add(_str_strRegionExtendedName, 365);
                Sizes.Add(_str_strRayonExtendedName, 365);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<SettlementLookup>().Post(manager, (SettlementLookup)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<SettlementLookup>().Post(manager, (SettlementLookup)c), c),
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
                    (manager, c, pars) => new ActResult(((SettlementLookup)c).MarkToDelete() && ObjectAccessor.PostInterface<SettlementLookup>().Post(manager, (SettlementLookup)c), c),
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
	