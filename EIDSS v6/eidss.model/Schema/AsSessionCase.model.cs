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
    public abstract partial class AsSessionCase : 
        EditableObject<AsSessionCase>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfCase { get; set; }
                
        [LocalizedDisplayName(_str_idfOutbreak)]
        [MapField(_str_idfOutbreak)]
        public abstract Int64? idfOutbreak { get; set; }
        protected Int64? idfOutbreak_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOutbreak).OriginalValue; } }
        protected Int64? idfOutbreak_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOutbreak).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCaseID)]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCaseType)]
        [MapField(_str_idfsCaseType)]
        public abstract Int64 idfsCaseType { get; set; }
        protected Int64 idfsCaseType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseType).OriginalValue; } }
        protected Int64 idfsCaseType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseType).PreviousValue; } }
                
        [LocalizedDisplayName("AsSessionCase.strCaseStatus")]
        [MapField(_str_strCaseStatus)]
        public abstract String strCaseStatus { get; set; }
        protected String strCaseStatus_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseStatus).OriginalValue; } }
        protected String strCaseStatus_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_Confirmed)]
        [MapField(_str_Confirmed)]
        public abstract Int32? Confirmed { get; set; }
        protected Int32? Confirmed_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._confirmed).OriginalValue; } }
        protected Int32? Confirmed_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._confirmed).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDiagnosis)]
        [MapField(_str_strDiagnosis)]
        public abstract String strDiagnosis { get; set; }
        protected String strDiagnosis_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosis).OriginalValue; } }
        protected String strDiagnosis_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName("AsSessionCase.datEnteredDate")]
        [MapField(_str_datEnteredDate)]
        public abstract DateTime? datEnteredDate { get; set; }
        protected DateTime? datEnteredDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).OriginalValue; } }
        protected DateTime? datEnteredDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).PreviousValue; } }
                
        [LocalizedDisplayName("AsSessionCase.strGeoLocation")]
        [MapField(_str_strGeoLocation)]
        public abstract String strGeoLocation { get; set; }
        protected String strGeoLocation_Original { get { return ((EditableValue<String>)((dynamic)this)._strGeoLocation).OriginalValue; } }
        protected String strGeoLocation_Previous { get { return ((EditableValue<String>)((dynamic)this)._strGeoLocation).PreviousValue; } }
                
        [LocalizedDisplayName("AsSessionCase.strAddress")]
        [MapField(_str_strAddress)]
        public abstract String strAddress { get; set; }
        protected String strAddress_Original { get { return ((EditableValue<String>)((dynamic)this)._strAddress).OriginalValue; } }
        protected String strAddress_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAddress).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPatientName)]
        [MapField(_str_strPatientName)]
        public abstract String strPatientName { get; set; }
        protected String strPatientName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPatientName).OriginalValue; } }
        protected String strPatientName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPatientName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfRootFarm)]
        [MapField(_str_idfRootFarm)]
        public abstract Int64? idfRootFarm { get; set; }
        protected Int64? idfRootFarm_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootFarm).OriginalValue; } }
        protected Int64? idfRootFarm_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootFarm).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<AsSessionCase, object> _get_func;
            internal Action<AsSessionCase, string> _set_func;
            internal Action<AsSessionCase, AsSessionCase, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfOutbreak = "idfOutbreak";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_strCaseStatus = "strCaseStatus";
        internal const string _str_Confirmed = "Confirmed";
        internal const string _str_strDiagnosis = "strDiagnosis";
        internal const string _str_datEnteredDate = "datEnteredDate";
        internal const string _str_strGeoLocation = "strGeoLocation";
        internal const string _str_strAddress = "strAddress";
        internal const string _str_strPatientName = "strPatientName";
        internal const string _str_idfRootFarm = "idfRootFarm";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfCase, _formname = _str_idfCase, _type = "Int64",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfCase != newval) o.idfCase = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, o.ObjectIdent2 + _str_idfCase, o.ObjectIdent3 + _str_idfCase, "Int64", 
                    o.idfCase == null ? "" : o.idfCase.ToString(),                  
                  o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfOutbreak, _formname = _str_idfOutbreak, _type = "Int64?",
              _get_func = o => o.idfOutbreak,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfOutbreak != newval) o.idfOutbreak = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfOutbreak != c.idfOutbreak || o.IsRIRPropChanged(_str_idfOutbreak, c)) 
                  m.Add(_str_idfOutbreak, o.ObjectIdent + _str_idfOutbreak, o.ObjectIdent2 + _str_idfOutbreak, o.ObjectIdent3 + _str_idfOutbreak, "Int64?", 
                    o.idfOutbreak == null ? "" : o.idfOutbreak.ToString(),                  
                  o.IsReadOnly(_str_idfOutbreak), o.IsInvisible(_str_idfOutbreak), o.IsRequired(_str_idfOutbreak)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCaseID, _formname = _str_strCaseID, _type = "String",
              _get_func = o => o.strCaseID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCaseID != newval) o.strCaseID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strCaseID != c.strCaseID || o.IsRIRPropChanged(_str_strCaseID, c)) 
                  m.Add(_str_strCaseID, o.ObjectIdent + _str_strCaseID, o.ObjectIdent2 + _str_strCaseID, o.ObjectIdent3 + _str_strCaseID, "String", 
                    o.strCaseID == null ? "" : o.strCaseID.ToString(),                  
                  o.IsReadOnly(_str_strCaseID), o.IsInvisible(_str_strCaseID), o.IsRequired(_str_strCaseID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCaseType, _formname = _str_idfsCaseType, _type = "Int64",
              _get_func = o => o.idfsCaseType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsCaseType != newval) o.idfsCaseType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_idfsCaseType, c)) 
                  m.Add(_str_idfsCaseType, o.ObjectIdent + _str_idfsCaseType, o.ObjectIdent2 + _str_idfsCaseType, o.ObjectIdent3 + _str_idfsCaseType, "Int64", 
                    o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseType), o.IsInvisible(_str_idfsCaseType), o.IsRequired(_str_idfsCaseType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCaseStatus, _formname = _str_strCaseStatus, _type = "String",
              _get_func = o => o.strCaseStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCaseStatus != newval) o.strCaseStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.strCaseStatus != c.strCaseStatus || o.IsRIRPropChanged(_str_strCaseStatus, c)) 
                  m.Add(_str_strCaseStatus, o.ObjectIdent + _str_strCaseStatus, o.ObjectIdent2 + _str_strCaseStatus, o.ObjectIdent3 + _str_strCaseStatus, "String", 
                    o.strCaseStatus == null ? "" : o.strCaseStatus.ToString(),                  
                  o.IsReadOnly(_str_strCaseStatus), o.IsInvisible(_str_strCaseStatus), o.IsRequired(_str_strCaseStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Confirmed, _formname = _str_Confirmed, _type = "Int32?",
              _get_func = o => o.Confirmed,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.Confirmed != newval) o.Confirmed = newval; },
              _compare_func = (o, c, m) => {
                if (o.Confirmed != c.Confirmed || o.IsRIRPropChanged(_str_Confirmed, c)) 
                  m.Add(_str_Confirmed, o.ObjectIdent + _str_Confirmed, o.ObjectIdent2 + _str_Confirmed, o.ObjectIdent3 + _str_Confirmed, "Int32?", 
                    o.Confirmed == null ? "" : o.Confirmed.ToString(),                  
                  o.IsReadOnly(_str_Confirmed), o.IsInvisible(_str_Confirmed), o.IsRequired(_str_Confirmed)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDiagnosis, _formname = _str_strDiagnosis, _type = "String",
              _get_func = o => o.strDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDiagnosis != newval) o.strDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDiagnosis != c.strDiagnosis || o.IsRIRPropChanged(_str_strDiagnosis, c)) 
                  m.Add(_str_strDiagnosis, o.ObjectIdent + _str_strDiagnosis, o.ObjectIdent2 + _str_strDiagnosis, o.ObjectIdent3 + _str_strDiagnosis, "String", 
                    o.strDiagnosis == null ? "" : o.strDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_strDiagnosis), o.IsInvisible(_str_strDiagnosis), o.IsRequired(_str_strDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datEnteredDate, _formname = _str_datEnteredDate, _type = "DateTime?",
              _get_func = o => o.datEnteredDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datEnteredDate != newval) o.datEnteredDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datEnteredDate != c.datEnteredDate || o.IsRIRPropChanged(_str_datEnteredDate, c)) 
                  m.Add(_str_datEnteredDate, o.ObjectIdent + _str_datEnteredDate, o.ObjectIdent2 + _str_datEnteredDate, o.ObjectIdent3 + _str_datEnteredDate, "DateTime?", 
                    o.datEnteredDate == null ? "" : o.datEnteredDate.ToString(),                  
                  o.IsReadOnly(_str_datEnteredDate), o.IsInvisible(_str_datEnteredDate), o.IsRequired(_str_datEnteredDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strGeoLocation, _formname = _str_strGeoLocation, _type = "String",
              _get_func = o => o.strGeoLocation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strGeoLocation != newval) o.strGeoLocation = newval; },
              _compare_func = (o, c, m) => {
                if (o.strGeoLocation != c.strGeoLocation || o.IsRIRPropChanged(_str_strGeoLocation, c)) 
                  m.Add(_str_strGeoLocation, o.ObjectIdent + _str_strGeoLocation, o.ObjectIdent2 + _str_strGeoLocation, o.ObjectIdent3 + _str_strGeoLocation, "String", 
                    o.strGeoLocation == null ? "" : o.strGeoLocation.ToString(),                  
                  o.IsReadOnly(_str_strGeoLocation), o.IsInvisible(_str_strGeoLocation), o.IsRequired(_str_strGeoLocation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strAddress, _formname = _str_strAddress, _type = "String",
              _get_func = o => o.strAddress,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strAddress != newval) o.strAddress = newval; },
              _compare_func = (o, c, m) => {
                if (o.strAddress != c.strAddress || o.IsRIRPropChanged(_str_strAddress, c)) 
                  m.Add(_str_strAddress, o.ObjectIdent + _str_strAddress, o.ObjectIdent2 + _str_strAddress, o.ObjectIdent3 + _str_strAddress, "String", 
                    o.strAddress == null ? "" : o.strAddress.ToString(),                  
                  o.IsReadOnly(_str_strAddress), o.IsInvisible(_str_strAddress), o.IsRequired(_str_strAddress)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPatientName, _formname = _str_strPatientName, _type = "String",
              _get_func = o => o.strPatientName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPatientName != newval) o.strPatientName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPatientName != c.strPatientName || o.IsRIRPropChanged(_str_strPatientName, c)) 
                  m.Add(_str_strPatientName, o.ObjectIdent + _str_strPatientName, o.ObjectIdent2 + _str_strPatientName, o.ObjectIdent3 + _str_strPatientName, "String", 
                    o.strPatientName == null ? "" : o.strPatientName.ToString(),                  
                  o.IsReadOnly(_str_strPatientName), o.IsInvisible(_str_strPatientName), o.IsRequired(_str_strPatientName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfRootFarm, _formname = _str_idfRootFarm, _type = "Int64?",
              _get_func = o => o.idfRootFarm,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfRootFarm != newval) o.idfRootFarm = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfRootFarm != c.idfRootFarm || o.IsRIRPropChanged(_str_idfRootFarm, c)) 
                  m.Add(_str_idfRootFarm, o.ObjectIdent + _str_idfRootFarm, o.ObjectIdent2 + _str_idfRootFarm, o.ObjectIdent3 + _str_idfRootFarm, "Int64?", 
                    o.idfRootFarm == null ? "" : o.idfRootFarm.ToString(),                  
                  o.IsReadOnly(_str_idfRootFarm), o.IsInvisible(_str_idfRootFarm), o.IsRequired(_str_idfRootFarm)); 
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
            AsSessionCase obj = (AsSessionCase)o;
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
        internal string m_ObjectName = "AsSessionCase";

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
            var ret = base.Clone() as AsSessionCase;
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
            var ret = base.Clone() as AsSessionCase;
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
        public AsSessionCase CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AsSessionCase;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfCase; } }
        public string KeyName { get { return "idfCase"; } }
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

        private bool IsRIRPropChanged(string fld, AsSessionCase c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public AsSessionCase()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);

        
        private int? m_HACode;
        public int? _HACode { get { return m_HACode; } set { m_HACode = value; } }
        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AsSessionCase_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AsSessionCase_PropertyChanged);
        }
        private void AsSessionCase_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AsSessionCase).Changed(e.PropertyName);
            
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
            AsSessionCase obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AsSessionCase obj = this;
            
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


        internal Dictionary<string, Func<AsSessionCase, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<AsSessionCase, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsSessionCase, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsSessionCase, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<AsSessionCase, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<AsSessionCase, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<AsSessionCase, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AsSessionCase()
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
    
        #region Class for web grid
        public class AsSessionCaseGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfCase { get; set; }
        
            public String strCaseID { get; set; }
        
            public DateTime? datEnteredDate { get; set; }
        
            public String strCaseStatus { get; set; }
        
            public String strDiagnosis { get; set; }
        
            public String strGeoLocation { get; set; }
        
            public String strAddress { get; set; }
        
        }
        public partial class AsSessionCaseGridModelList : List<AsSessionCaseGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public AsSessionCaseGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsSessionCase>, errMes);
            }
            public AsSessionCaseGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsSessionCase>, errMes);
            }
            public AsSessionCaseGridModelList(long key, IEnumerable<AsSessionCase> items)
            {
                LoadGridModelList(key, items, null);
            }
            public AsSessionCaseGridModelList(long key)
            {
                LoadGridModelList(key, new List<AsSessionCase>(), null);
            }
            partial void filter(List<AsSessionCase> items);
            private void LoadGridModelList(long key, IEnumerable<AsSessionCase> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strCaseID,_str_datEnteredDate,_str_strCaseStatus,_str_strDiagnosis,_str_strGeoLocation,_str_strAddress};
                    
                Hiddens = new List<string> {_str_idfCase};
                Keys = new List<string> {_str_idfCase};
                Labels = new Dictionary<string, string> {{_str_strCaseID, _str_strCaseID},{_str_datEnteredDate, "AsSessionCase.datEnteredDate"},{_str_strCaseStatus, "AsSessionCase.strCaseStatus"},{_str_strDiagnosis, _str_strDiagnosis},{_str_strGeoLocation, "AsSessionCase.strGeoLocation"},{_str_strAddress, "AsSessionCase.strAddress"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                AsSessionCase.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<AsSessionCase>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new AsSessionCaseGridModel()
                {
                    ItemKey=c.idfCase,strCaseID=c.strCaseID,datEnteredDate=c.datEnteredDate,strCaseStatus=c.strCaseStatus,strDiagnosis=c.strDiagnosis,strGeoLocation=c.strGeoLocation,strAddress=c.strAddress
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
        : DataAccessor<AsSessionCase>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<AsSessionCase>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfCase"; } }
            #endregion
        
            private delegate void on_action(AsSessionCase obj);
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
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , HACode
                    
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<AsSessionCase> SelectList(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , int? HACode
                
                )
            {
                return _SelectList(manager
                    , idfMonitoringSession
                    , HACode
                    
                    , delegate(AsSessionCase obj)
                        {
                        }
                    , delegate(AsSessionCase obj)
                        {
                        }
                    );
            }

            
            private List<AsSessionCase> _SelectList(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , int? HACode
                
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<AsSessionCase> objs = new List<AsSessionCase>();
                    sets[0] = new MapResultSet(typeof(AsSessionCase), objs);
                    
                    manager
                        .SetSpCommand("spASSessionCases_SelectDetail"
                            , manager.Parameter("@idfMonitoringSession", idfMonitoringSession)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);
                    foreach(var obj in objs) 
                    {
                        obj.m_CS = m_CS;
                        
                        obj._HACode = HACode;
                        
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsSessionCase obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AsSessionCase obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AsSessionCase _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    AsSessionCase obj = AsSessionCase.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    obj._HACode = HACode;
                    
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

            
            public AsSessionCase CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public AsSessionCase CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public AsSessionCase CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(AsSessionCase obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AsSessionCase obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, AsSessionCase obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(AsSessionCase obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(AsSessionCase obj, bool bRethrowException)
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
                return Validate(manager, obj as AsSessionCase, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsSessionCase obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(AsSessionCase obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(AsSessionCase obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AsSessionCase) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AsSessionCase) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AsSessionCaseDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spASSessionCases_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsSessionCase, bool>> RequiredByField = new Dictionary<string, Func<AsSessionCase, bool>>();
            public static Dictionary<string, Func<AsSessionCase, bool>> RequiredByProperty = new Dictionary<string, Func<AsSessionCase, bool>>();
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
                
                Sizes.Add(_str_strCaseID, 200);
                Sizes.Add(_str_strCaseStatus, 2000);
                Sizes.Add(_str_strDiagnosis, 500);
                Sizes.Add(_str_strGeoLocation, 1000);
                Sizes.Add(_str_strAddress, 1000);
                Sizes.Add(_str_strPatientName, 400);
                GridMeta.Add(new GridMetaItem(
                    _str_idfCase,
                    _str_idfCase, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCaseID,
                    _str_strCaseID, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datEnteredDate,
                    "AsSessionCase.datEnteredDate", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCaseStatus,
                    "AsSessionCase.strCaseStatus", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnosis,
                    _str_strDiagnosis, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strGeoLocation,
                    "AsSessionCase.strGeoLocation", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAddress,
                    "AsSessionCase.strAddress", null, true, true, true, true, null
                    ));
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
                    (manager, c, pars) => ((AsSessionCase)c).MarkToDelete(),
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
	