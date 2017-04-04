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
		

namespace hmis2eidss.service.Schema
{
        
        
    [XmlType(AnonymousType = true)]
    public abstract partial class HmisLog : 
        EditableObject<HmisLog>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_hmisLog), NonUpdatable, PrimaryKey]
        public abstract Int64 hmisLog { get; set; }
                
        [LocalizedDisplayName(_str_datImport)]
        [MapField(_str_datImport)]
        public abstract DateTime datImport { get; set; }
        protected DateTime datImport_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datImport).OriginalValue; } }
        protected DateTime datImport_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datImport).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHmisCaseId)]
        [MapField(_str_strHmisCaseId)]
        public abstract String strHmisCaseId { get; set; }
        protected String strHmisCaseId_Original { get { return ((EditableValue<String>)((dynamic)this)._strHmisCaseId).OriginalValue; } }
        protected String strHmisCaseId_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHmisCaseId).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHmisICD10Code)]
        [MapField(_str_strHmisICD10Code)]
        public abstract String strHmisICD10Code { get; set; }
        protected String strHmisICD10Code_Original { get { return ((EditableValue<String>)((dynamic)this)._strHmisICD10Code).OriginalValue; } }
        protected String strHmisICD10Code_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHmisICD10Code).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHmisPatientLastName)]
        [MapField(_str_strHmisPatientLastName)]
        public abstract String strHmisPatientLastName { get; set; }
        protected String strHmisPatientLastName_Original { get { return ((EditableValue<String>)((dynamic)this)._strHmisPatientLastName).OriginalValue; } }
        protected String strHmisPatientLastName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHmisPatientLastName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHmisRegionId)]
        [MapField(_str_strHmisRegionId)]
        public abstract String strHmisRegionId { get; set; }
        protected String strHmisRegionId_Original { get { return ((EditableValue<String>)((dynamic)this)._strHmisRegionId).OriginalValue; } }
        protected String strHmisRegionId_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHmisRegionId).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHmisRayonId)]
        [MapField(_str_strHmisRayonId)]
        public abstract String strHmisRayonId { get; set; }
        protected String strHmisRayonId_Original { get { return ((EditableValue<String>)((dynamic)this)._strHmisRayonId).OriginalValue; } }
        protected String strHmisRayonId_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHmisRayonId).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intStatus)]
        [MapField(_str_intStatus)]
        public abstract Int32 intStatus { get; set; }
        protected Int32 intStatus_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intStatus).OriginalValue; } }
        protected Int32 intStatus_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strComments)]
        [MapField(_str_strComments)]
        public abstract String strComments { get; set; }
        protected String strComments_Original { get { return ((EditableValue<String>)((dynamic)this)._strComments).OriginalValue; } }
        protected String strComments_Previous { get { return ((EditableValue<String>)((dynamic)this)._strComments).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsHumanCase)]
        [MapField(_str_idfsHumanCase)]
        public abstract Int64? idfsHumanCase { get; set; }
        protected Int64? idfsHumanCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanCase).OriginalValue; } }
        protected Int64? idfsHumanCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanCase).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<HmisLog, object> _get_func;
            internal Action<HmisLog, string> _set_func;
            internal Action<HmisLog, HmisLog, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_hmisLog = "hmisLog";
        internal const string _str_datImport = "datImport";
        internal const string _str_strHmisCaseId = "strHmisCaseId";
        internal const string _str_strHmisICD10Code = "strHmisICD10Code";
        internal const string _str_strHmisPatientLastName = "strHmisPatientLastName";
        internal const string _str_strHmisRegionId = "strHmisRegionId";
        internal const string _str_strHmisRayonId = "strHmisRayonId";
        internal const string _str_intStatus = "intStatus";
        internal const string _str_strComments = "strComments";
        internal const string _str_idfsHumanCase = "idfsHumanCase";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_hmisLog, _formname = _str_hmisLog, _type = "Int64",
              _get_func = o => o.hmisLog,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.hmisLog != newval) o.hmisLog = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.hmisLog != c.hmisLog || o.IsRIRPropChanged(_str_hmisLog, c)) 
                  m.Add(_str_hmisLog, o.ObjectIdent + _str_hmisLog, o.ObjectIdent2 + _str_hmisLog, o.ObjectIdent3 + _str_hmisLog, "Int64", 
                    o.hmisLog == null ? "" : o.hmisLog.ToString(),                  
                  o.IsReadOnly(_str_hmisLog), o.IsInvisible(_str_hmisLog), o.IsRequired(_str_hmisLog)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datImport, _formname = _str_datImport, _type = "DateTime",
              _get_func = o => o.datImport,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTime(val); if (o.datImport != newval) o.datImport = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datImport != c.datImport || o.IsRIRPropChanged(_str_datImport, c)) 
                  m.Add(_str_datImport, o.ObjectIdent + _str_datImport, o.ObjectIdent2 + _str_datImport, o.ObjectIdent3 + _str_datImport, "DateTime", 
                    o.datImport == null ? "" : o.datImport.ToString(),                  
                  o.IsReadOnly(_str_datImport), o.IsInvisible(_str_datImport), o.IsRequired(_str_datImport)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHmisCaseId, _formname = _str_strHmisCaseId, _type = "String",
              _get_func = o => o.strHmisCaseId,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHmisCaseId != newval) o.strHmisCaseId = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strHmisCaseId != c.strHmisCaseId || o.IsRIRPropChanged(_str_strHmisCaseId, c)) 
                  m.Add(_str_strHmisCaseId, o.ObjectIdent + _str_strHmisCaseId, o.ObjectIdent2 + _str_strHmisCaseId, o.ObjectIdent3 + _str_strHmisCaseId, "String", 
                    o.strHmisCaseId == null ? "" : o.strHmisCaseId.ToString(),                  
                  o.IsReadOnly(_str_strHmisCaseId), o.IsInvisible(_str_strHmisCaseId), o.IsRequired(_str_strHmisCaseId)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHmisICD10Code, _formname = _str_strHmisICD10Code, _type = "String",
              _get_func = o => o.strHmisICD10Code,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHmisICD10Code != newval) o.strHmisICD10Code = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strHmisICD10Code != c.strHmisICD10Code || o.IsRIRPropChanged(_str_strHmisICD10Code, c)) 
                  m.Add(_str_strHmisICD10Code, o.ObjectIdent + _str_strHmisICD10Code, o.ObjectIdent2 + _str_strHmisICD10Code, o.ObjectIdent3 + _str_strHmisICD10Code, "String", 
                    o.strHmisICD10Code == null ? "" : o.strHmisICD10Code.ToString(),                  
                  o.IsReadOnly(_str_strHmisICD10Code), o.IsInvisible(_str_strHmisICD10Code), o.IsRequired(_str_strHmisICD10Code)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHmisPatientLastName, _formname = _str_strHmisPatientLastName, _type = "String",
              _get_func = o => o.strHmisPatientLastName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHmisPatientLastName != newval) o.strHmisPatientLastName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strHmisPatientLastName != c.strHmisPatientLastName || o.IsRIRPropChanged(_str_strHmisPatientLastName, c)) 
                  m.Add(_str_strHmisPatientLastName, o.ObjectIdent + _str_strHmisPatientLastName, o.ObjectIdent2 + _str_strHmisPatientLastName, o.ObjectIdent3 + _str_strHmisPatientLastName, "String", 
                    o.strHmisPatientLastName == null ? "" : o.strHmisPatientLastName.ToString(),                  
                  o.IsReadOnly(_str_strHmisPatientLastName), o.IsInvisible(_str_strHmisPatientLastName), o.IsRequired(_str_strHmisPatientLastName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHmisRegionId, _formname = _str_strHmisRegionId, _type = "String",
              _get_func = o => o.strHmisRegionId,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHmisRegionId != newval) o.strHmisRegionId = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strHmisRegionId != c.strHmisRegionId || o.IsRIRPropChanged(_str_strHmisRegionId, c)) 
                  m.Add(_str_strHmisRegionId, o.ObjectIdent + _str_strHmisRegionId, o.ObjectIdent2 + _str_strHmisRegionId, o.ObjectIdent3 + _str_strHmisRegionId, "String", 
                    o.strHmisRegionId == null ? "" : o.strHmisRegionId.ToString(),                  
                  o.IsReadOnly(_str_strHmisRegionId), o.IsInvisible(_str_strHmisRegionId), o.IsRequired(_str_strHmisRegionId)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHmisRayonId, _formname = _str_strHmisRayonId, _type = "String",
              _get_func = o => o.strHmisRayonId,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHmisRayonId != newval) o.strHmisRayonId = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strHmisRayonId != c.strHmisRayonId || o.IsRIRPropChanged(_str_strHmisRayonId, c)) 
                  m.Add(_str_strHmisRayonId, o.ObjectIdent + _str_strHmisRayonId, o.ObjectIdent2 + _str_strHmisRayonId, o.ObjectIdent3 + _str_strHmisRayonId, "String", 
                    o.strHmisRayonId == null ? "" : o.strHmisRayonId.ToString(),                  
                  o.IsReadOnly(_str_strHmisRayonId), o.IsInvisible(_str_strHmisRayonId), o.IsRequired(_str_strHmisRayonId)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intStatus, _formname = _str_intStatus, _type = "Int32",
              _get_func = o => o.intStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intStatus != newval) o.intStatus = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intStatus != c.intStatus || o.IsRIRPropChanged(_str_intStatus, c)) 
                  m.Add(_str_intStatus, o.ObjectIdent + _str_intStatus, o.ObjectIdent2 + _str_intStatus, o.ObjectIdent3 + _str_intStatus, "Int32", 
                    o.intStatus == null ? "" : o.intStatus.ToString(),                  
                  o.IsReadOnly(_str_intStatus), o.IsInvisible(_str_intStatus), o.IsRequired(_str_intStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strComments, _formname = _str_strComments, _type = "String",
              _get_func = o => o.strComments,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strComments != newval) o.strComments = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strComments != c.strComments || o.IsRIRPropChanged(_str_strComments, c)) 
                  m.Add(_str_strComments, o.ObjectIdent + _str_strComments, o.ObjectIdent2 + _str_strComments, o.ObjectIdent3 + _str_strComments, "String", 
                    o.strComments == null ? "" : o.strComments.ToString(),                  
                  o.IsReadOnly(_str_strComments), o.IsInvisible(_str_strComments), o.IsRequired(_str_strComments)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsHumanCase, _formname = _str_idfsHumanCase, _type = "Int64?",
              _get_func = o => o.idfsHumanCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsHumanCase != newval) o.idfsHumanCase = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsHumanCase != c.idfsHumanCase || o.IsRIRPropChanged(_str_idfsHumanCase, c)) 
                  m.Add(_str_idfsHumanCase, o.ObjectIdent + _str_idfsHumanCase, o.ObjectIdent2 + _str_idfsHumanCase, o.ObjectIdent3 + _str_idfsHumanCase, "Int64?", 
                    o.idfsHumanCase == null ? "" : o.idfsHumanCase.ToString(),                  
                  o.IsReadOnly(_str_idfsHumanCase), o.IsInvisible(_str_idfsHumanCase), o.IsRequired(_str_idfsHumanCase)); 
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
            HmisLog obj = (HmisLog)o;
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
        internal string m_ObjectName = "HmisLog";

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
            var ret = base.Clone() as HmisLog;
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
            var ret = base.Clone() as HmisLog;
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
        public HmisLog CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as HmisLog;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return hmisLog; } }
        public string KeyName { get { return "hmisLog"; } }
        public object KeyLookup { get { return hmisLog; } }
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

        private bool IsRIRPropChanged(string fld, HmisLog c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, HmisLog c)
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
        

      

        public HmisLog()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(HmisLog_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(HmisLog_PropertyChanged);
        }
        private void HmisLog_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as HmisLog).Changed(e.PropertyName);
            
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
            HmisLog obj = this;
            
        }
        private void _DeletedExtenders()
        {
            HmisLog obj = this;
            
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


        internal Dictionary<string, Func<HmisLog, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<HmisLog, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<HmisLog, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<HmisLog, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<HmisLog, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<HmisLog, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<HmisLog, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~HmisLog()
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
        : DataAccessor<HmisLog>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<HmisLog>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<HmisLog>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "hmisLog"; } }
            #endregion
        
            public delegate void on_action(HmisLog obj);
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
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (String)ident
                            
                        , null
                            
                        , null, null
                        );
                }
            }
            public virtual HmisLog SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (String)ident
                            
                        , null
                            
                        , null, null
                        );
                }
            }

            
            public virtual HmisLog SelectByKey(DbManagerProxy manager
                , String strHmisCaseId
                , String strHmisICD10Code
                )
            {
                return _SelectByKey(manager
                    , strHmisCaseId
                    , strHmisICD10Code
                    , null, null
                    );
            }
            

            private HmisLog _SelectByKey(DbManagerProxy manager
                , String strHmisCaseId
                , String strHmisICD10Code
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , strHmisCaseId
                    , strHmisICD10Code
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual HmisLog _SelectByKeyInternal(DbManagerProxy manager
                , String strHmisCaseId
                , String strHmisICD10Code
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<HmisLog> objs = new List<HmisLog>();
                sets[0] = new MapResultSet(typeof(HmisLog), objs);
                HmisLog obj = null;
                try
                {
                    manager
                        .SetSpCommand("hmisLog_SelectDetail"
                            , manager.Parameter("@strHmisCaseId", strHmisCaseId)
                            , manager.Parameter("@strHmisICD10Code", strHmisICD10Code)
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    obj = objs[0];
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
                    throw DbModelException.Create(obj, e);
                  }
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, HmisLog obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, HmisLog obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private HmisLog _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                HmisLog obj = null;
                try
                {
                    obj = HmisLog.CreateInstance();
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
                obj.intStatus = new Func<HmisLog, int>(c => 0)(obj);
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

            
            public HmisLog CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public HmisLog CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public HmisLog CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(HmisLog obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(HmisLog obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, HmisLog obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("hmisLog_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] HmisLog obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] HmisLog obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bSuccess = false;
                int iDeadlockAttemptsCount = BaseSettings.DeadlockAttemptsCount;
                for (int iAttemptNumber = 0; iAttemptNumber < iDeadlockAttemptsCount; iAttemptNumber++)
                {
                    bool bTransactionStarted = false;
                    try
                    {
                        HmisLog bo = obj as HmisLog;
                        
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
                            
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as HmisLog, bChildObject);
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
                        
                        break;
                    }
                    catch(Exception e)
                    {
                        if (bTransactionStarted)
                        {
                            manager.RollbackTransaction();
                            
                            if (DbModelException.IsDeadlockException(e))
                            {
                                System.Threading.Thread.Sleep(BaseSettings.DeadlockDelay);
                                continue;
                            }
                        }
                    
                        if (e is DataException)
                        {
                            throw DbModelException.Create(obj, e as DataException);
                        }
                        if (e is System.Data.SqlClient.SqlException)
                        {
                            throw DbModelException.Create(obj, e as System.Data.SqlClient.SqlException);
                        }
                        else 
                            throw;
                    }
                }
                return bSuccess;
            }
            private bool _PostNonTransaction(DbManagerProxy manager, HmisLog obj, bool bChildObject) 
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
                obj.datImport = new Func<HmisLog, DateTime>(c => DateTime.Now)(obj);
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
            
            public bool ValidateCanDelete(HmisLog obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, HmisLog obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(HmisLog obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(HmisLog obj, bool bRethrowException)
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
                return Validate(manager, obj as HmisLog, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, HmisLog obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(HmisLog obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(HmisLog obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as HmisLog) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as HmisLog) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "HmisLogDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "hmisLog_SelectDetail";
            public static string spCount = "";
            public static string spPost = "hmisLog_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<HmisLog, bool>> RequiredByField = new Dictionary<string, Func<HmisLog, bool>>();
            public static Dictionary<string, Func<HmisLog, bool>> RequiredByProperty = new Dictionary<string, Func<HmisLog, bool>>();
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
                
                Sizes.Add(_str_strHmisCaseId, 36);
                Sizes.Add(_str_strHmisICD10Code, 36);
                Sizes.Add(_str_strHmisPatientLastName, 128);
                Sizes.Add(_str_strHmisRegionId, 36);
                Sizes.Add(_str_strHmisRayonId, 36);
                Sizes.Add(_str_strComments, 256);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<HmisLog>().Post(manager, (HmisLog)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<HmisLog>().Post(manager, (HmisLog)c), c),
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
                    (manager, c, pars) => new ActResult(((HmisLog)c).MarkToDelete() && ObjectAccessor.PostInterface<HmisLog>().Post(manager, (HmisLog)c), c),
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
	