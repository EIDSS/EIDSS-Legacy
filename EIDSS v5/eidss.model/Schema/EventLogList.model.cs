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
    public abstract partial class EventLogListItem : 
        EditableObject<EventLogListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfEventID), NonUpdatable, PrimaryKey]
        public abstract Int64 idfEventID { get; set; }
                
        [LocalizedDisplayName(_str_strEventTypeName)]
        [MapField(_str_strEventTypeName)]
        public abstract String strEventTypeName { get; set; }
        #if MONO
        protected String strEventTypeName_Original { get { return strEventTypeName; } }
        protected String strEventTypeName_Previous { get { return strEventTypeName; } }
        #else
        protected String strEventTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._strEventTypeName).OriginalValue; } }
        protected String strEventTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strEventTypeName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfObjectID)]
        [MapField(_str_idfObjectID)]
        public abstract Int64? idfObjectID { get; set; }
        #if MONO
        protected Int64? idfObjectID_Original { get { return idfObjectID; } }
        protected Int64? idfObjectID_Previous { get { return idfObjectID; } }
        #else
        protected Int64? idfObjectID_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObjectID).OriginalValue; } }
        protected Int64? idfObjectID_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObjectID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strInformationString)]
        [MapField(_str_strInformationString)]
        public abstract String strInformationString { get; set; }
        #if MONO
        protected String strInformationString_Original { get { return strInformationString; } }
        protected String strInformationString_Previous { get { return strInformationString; } }
        #else
        protected String strInformationString_Original { get { return ((EditableValue<String>)((dynamic)this)._strInformationString).OriginalValue; } }
        protected String strInformationString_Previous { get { return ((EditableValue<String>)((dynamic)this)._strInformationString).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("EventLog.strNote")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        #if MONO
        protected String strNote_Original { get { return strNote; } }
        protected String strNote_Previous { get { return strNote; } }
        #else
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsEventTypeID)]
        [MapField(_str_idfsEventTypeID)]
        public abstract Int64? idfsEventTypeID { get; set; }
        #if MONO
        protected Int64? idfsEventTypeID_Original { get { return idfsEventTypeID; } }
        protected Int64? idfsEventTypeID_Previous { get { return idfsEventTypeID; } }
        #else
        protected Int64? idfsEventTypeID_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEventTypeID).OriginalValue; } }
        protected Int64? idfsEventTypeID_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEventTypeID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datEventDatatime)]
        [MapField(_str_datEventDatatime)]
        public abstract DateTime? datEventDatatime { get; set; }
        #if MONO
        protected DateTime? datEventDatatime_Original { get { return datEventDatatime; } }
        protected DateTime? datEventDatatime_Previous { get { return datEventDatatime; } }
        #else
        protected DateTime? datEventDatatime_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEventDatatime).OriginalValue; } }
        protected DateTime? datEventDatatime_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEventDatatime).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_PersonName)]
        [MapField(_str_PersonName)]
        public abstract String PersonName { get; set; }
        #if MONO
        protected String PersonName_Original { get { return PersonName; } }
        protected String PersonName_Previous { get { return PersonName; } }
        #else
        protected String PersonName_Original { get { return ((EditableValue<String>)((dynamic)this)._personName).OriginalValue; } }
        protected String PersonName_Previous { get { return ((EditableValue<String>)((dynamic)this)._personName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCaseType)]
        [MapField(_str_idfsCaseType)]
        public abstract Int64? idfsCaseType { get; set; }
        #if MONO
        protected Int64? idfsCaseType_Original { get { return idfsCaseType; } }
        protected Int64? idfsCaseType_Previous { get { return idfsCaseType; } }
        #else
        protected Int64? idfsCaseType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).OriginalValue; } }
        protected Int64? idfsCaseType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<EventLogListItem, object> _get_func;
            internal Action<EventLogListItem, string> _set_func;
            internal Action<EventLogListItem, EventLogListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfEventID = "idfEventID";
        internal const string _str_strEventTypeName = "strEventTypeName";
        internal const string _str_idfObjectID = "idfObjectID";
        internal const string _str_strInformationString = "strInformationString";
        internal const string _str_strNote = "strNote";
        internal const string _str_idfsEventTypeID = "idfsEventTypeID";
        internal const string _str_datEventDatatime = "datEventDatatime";
        internal const string _str_PersonName = "PersonName";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_EventType = "EventType";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfEventID, _type = "Int64",
              _get_func = o => o.idfEventID,
              _set_func = (o, val) => { o.idfEventID = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfEventID != c.idfEventID || o.IsRIRPropChanged(_str_idfEventID, c)) 
                  m.Add(_str_idfEventID, o.ObjectIdent + _str_idfEventID, "Int64", o.idfEventID == null ? "" : o.idfEventID.ToString(), o.IsReadOnly(_str_idfEventID), o.IsInvisible(_str_idfEventID), o.IsRequired(_str_idfEventID)); }
              }, 
        
            new field_info {
              _name = _str_strEventTypeName, _type = "String",
              _get_func = o => o.strEventTypeName,
              _set_func = (o, val) => { o.strEventTypeName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strEventTypeName != c.strEventTypeName || o.IsRIRPropChanged(_str_strEventTypeName, c)) 
                  m.Add(_str_strEventTypeName, o.ObjectIdent + _str_strEventTypeName, "String", o.strEventTypeName == null ? "" : o.strEventTypeName.ToString(), o.IsReadOnly(_str_strEventTypeName), o.IsInvisible(_str_strEventTypeName), o.IsRequired(_str_strEventTypeName)); }
              }, 
        
            new field_info {
              _name = _str_idfObjectID, _type = "Int64?",
              _get_func = o => o.idfObjectID,
              _set_func = (o, val) => { o.idfObjectID = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfObjectID != c.idfObjectID || o.IsRIRPropChanged(_str_idfObjectID, c)) 
                  m.Add(_str_idfObjectID, o.ObjectIdent + _str_idfObjectID, "Int64?", o.idfObjectID == null ? "" : o.idfObjectID.ToString(), o.IsReadOnly(_str_idfObjectID), o.IsInvisible(_str_idfObjectID), o.IsRequired(_str_idfObjectID)); }
              }, 
        
            new field_info {
              _name = _str_strInformationString, _type = "String",
              _get_func = o => o.strInformationString,
              _set_func = (o, val) => { o.strInformationString = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strInformationString != c.strInformationString || o.IsRIRPropChanged(_str_strInformationString, c)) 
                  m.Add(_str_strInformationString, o.ObjectIdent + _str_strInformationString, "String", o.strInformationString == null ? "" : o.strInformationString.ToString(), o.IsReadOnly(_str_strInformationString), o.IsInvisible(_str_strInformationString), o.IsRequired(_str_strInformationString)); }
              }, 
        
            new field_info {
              _name = _str_strNote, _type = "String",
              _get_func = o => o.strNote,
              _set_func = (o, val) => { o.strNote = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNote != c.strNote || o.IsRIRPropChanged(_str_strNote, c)) 
                  m.Add(_str_strNote, o.ObjectIdent + _str_strNote, "String", o.strNote == null ? "" : o.strNote.ToString(), o.IsReadOnly(_str_strNote), o.IsInvisible(_str_strNote), o.IsRequired(_str_strNote)); }
              }, 
        
            new field_info {
              _name = _str_idfsEventTypeID, _type = "Int64?",
              _get_func = o => o.idfsEventTypeID,
              _set_func = (o, val) => { o.idfsEventTypeID = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsEventTypeID != c.idfsEventTypeID || o.IsRIRPropChanged(_str_idfsEventTypeID, c)) 
                  m.Add(_str_idfsEventTypeID, o.ObjectIdent + _str_idfsEventTypeID, "Int64?", o.idfsEventTypeID == null ? "" : o.idfsEventTypeID.ToString(), o.IsReadOnly(_str_idfsEventTypeID), o.IsInvisible(_str_idfsEventTypeID), o.IsRequired(_str_idfsEventTypeID)); }
              }, 
        
            new field_info {
              _name = _str_datEventDatatime, _type = "DateTime?",
              _get_func = o => o.datEventDatatime,
              _set_func = (o, val) => { o.datEventDatatime = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datEventDatatime != c.datEventDatatime || o.IsRIRPropChanged(_str_datEventDatatime, c)) 
                  m.Add(_str_datEventDatatime, o.ObjectIdent + _str_datEventDatatime, "DateTime?", o.datEventDatatime == null ? "" : o.datEventDatatime.ToString(), o.IsReadOnly(_str_datEventDatatime), o.IsInvisible(_str_datEventDatatime), o.IsRequired(_str_datEventDatatime)); }
              }, 
        
            new field_info {
              _name = _str_PersonName, _type = "String",
              _get_func = o => o.PersonName,
              _set_func = (o, val) => { o.PersonName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.PersonName != c.PersonName || o.IsRIRPropChanged(_str_PersonName, c)) 
                  m.Add(_str_PersonName, o.ObjectIdent + _str_PersonName, "String", o.PersonName == null ? "" : o.PersonName.ToString(), o.IsReadOnly(_str_PersonName), o.IsInvisible(_str_PersonName), o.IsRequired(_str_PersonName)); }
              }, 
        
            new field_info {
              _name = _str_idfsCaseType, _type = "Int64?",
              _get_func = o => o.idfsCaseType,
              _set_func = (o, val) => { o.idfsCaseType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_idfsCaseType, c)) 
                  m.Add(_str_idfsCaseType, o.ObjectIdent + _str_idfsCaseType, "Int64?", o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(), o.IsReadOnly(_str_idfsCaseType), o.IsInvisible(_str_idfsCaseType), o.IsRequired(_str_idfsCaseType)); }
              }, 
        
            new field_info {
              _name = _str_EventType, _type = "Lookup",
              _get_func = o => { if (o.EventType == null) return null; return o.EventType.idfsBaseReference; },
              _set_func = (o, val) => { o.EventType = o.EventTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsEventTypeID != c.idfsEventTypeID || o.IsRIRPropChanged(_str_EventType, c)) 
                  m.Add(_str_EventType, o.ObjectIdent + _str_EventType, "Lookup", o.idfsEventTypeID == null ? "" : o.idfsEventTypeID.ToString(), o.IsReadOnly(_str_EventType), o.IsInvisible(_str_EventType), o.IsRequired(_str_EventType)); }
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
            EventLogListItem obj = (EventLogListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsEventTypeID)]
        public BaseReference EventType
        {
            get { return _EventType == null ? null : ((long)_EventType.Key == 0 ? null : _EventType); }
            set 
            { 
                _EventType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsEventTypeID = _EventType == null 
                    ? new Int64?()
                    : _EventType.idfsBaseReference; 
                OnPropertyChanged(_str_EventType); 
            }
        }
        private BaseReference _EventType;

        
        public BaseReferenceList EventTypeLookup
        {
            get { return _EventTypeLookup; }
        }
        private BaseReferenceList _EventTypeLookup = new BaseReferenceList("rftEventType");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_EventType:
                    return new BvSelectList(EventTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, EventType, _str_idfsEventTypeID);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "EventLogListItem";

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
            var ret = base.Clone() as EventLogListItem;
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
            var ret = base.Clone() as EventLogListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public EventLogListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as EventLogListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfEventID; } }
        public string KeyName { get { return "idfEventID"; } }
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
        
            var _prev_idfsEventTypeID_EventType = idfsEventTypeID;
            base.RejectChanges();
        
            if (_prev_idfsEventTypeID_EventType != idfsEventTypeID)
            {
                _EventType = _EventTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsEventTypeID);
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

      private bool IsRIRPropChanged(string fld, EventLogListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public EventLogListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(EventLogListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(EventLogListItem_PropertyChanged);
        }
        private void EventLogListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as EventLogListItem).Changed(e.PropertyName);
            
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
            EventLogListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            EventLogListItem obj = this;
            
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


        public Dictionary<string, Func<EventLogListItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<EventLogListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<EventLogListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<EventLogListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<EventLogListItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<EventLogListItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~EventLogListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftEventType", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftEventType")
                _getAccessor().LoadLookup_EventType(manager, this);
            
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
        public class EventLogListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfEventID { get; set; }
        
            public DateTime? datEventDatatime { get; set; }
        
            public String PersonName { get; set; }
        
            public String strInformationString { get; set; }
        
            public String strNote { get; set; }
        
            public String strEventTypeName { get; set; }
        
        }
        public partial class EventLogListItemGridModelList : List<EventLogListItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public EventLogListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<EventLogListItem>, errMes);
            }
            public EventLogListItemGridModelList(long key, IEnumerable<EventLogListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<EventLogListItem> items);
            private void LoadGridModelList(long key, IEnumerable<EventLogListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_datEventDatatime,_str_PersonName,_str_strInformationString,_str_strNote,_str_strEventTypeName};
                    
                Hiddens = new List<string> {_str_idfEventID};
                Keys = new List<string> {_str_idfEventID};
                Labels = new Dictionary<string, string> {{_str_datEventDatatime, _str_datEventDatatime},{_str_PersonName, _str_PersonName},{_str_strInformationString, _str_strInformationString},{_str_strNote, "EventLog.strNote"},{_str_strEventTypeName, _str_strEventTypeName}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<EventLogListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new EventLogListItemGridModel()
                {
                    ItemKey=c.idfEventID,datEventDatatime=c.datEventDatatime,PersonName=c.PersonName,strInformationString=c.strInformationString,strNote=c.strNote,strEventTypeName=c.strEventTypeName
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
        : DataAccessor<EventLogListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectList
                    
            , IObjectPost
                    
        {
            private delegate void on_action(EventLogListItem obj);
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
            private BaseReference.Accessor EventTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<EventLogListItem> SelectListT(DbManagerProxy manager
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
            
            private List<EventLogListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_Event_SelectList.* from dbo.fn_Event_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfEventID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfEventID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfEventID") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Event_SelectList.idfEventID,0) {0} @idfEventID_{1}", filters.Operation("idfEventID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strEventTypeName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strEventTypeName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strEventTypeName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Event_SelectList.strEventTypeName {0} @strEventTypeName_{1}", filters.Operation("strEventTypeName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfObjectID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfObjectID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfObjectID") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Event_SelectList.idfObjectID,0) {0} @idfObjectID_{1}", filters.Operation("idfObjectID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strInformationString"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strInformationString"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strInformationString") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Event_SelectList.strInformationString {0} @strInformationString_{1}", filters.Operation("strInformationString", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strNote"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strNote"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strNote") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Event_SelectList.strNote {0} @strNote_{1}", filters.Operation("strNote", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsEventTypeID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsEventTypeID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsEventTypeID") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Event_SelectList.idfsEventTypeID,0) {0} @idfsEventTypeID_{1}", filters.Operation("idfsEventTypeID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datEventDatatime"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datEventDatatime"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datEventDatatime") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_Event_SelectList.datEventDatatime, 112) {0} CONVERT(NVARCHAR(8), @datEventDatatime_{1}, 112)", filters.Operation("datEventDatatime", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("PersonName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("PersonName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("PersonName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Event_SelectList.PersonName {0} @PersonName_{1}", filters.Operation("PersonName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCaseType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCaseType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCaseType") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Event_SelectList.idfsCaseType,0) {0} @idfsCaseType_{1}", filters.Operation("idfsCaseType", i), i);
                            
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
                    
                    if (filters.Contains("idfEventID"))
                        for (int i = 0; i < filters.Count("idfEventID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfEventID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfEventID", i), filters.Value("idfEventID", i))));
                      
                    if (filters.Contains("strEventTypeName"))
                        for (int i = 0; i < filters.Count("strEventTypeName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strEventTypeName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strEventTypeName", i), filters.Value("strEventTypeName", i))));
                      
                    if (filters.Contains("idfObjectID"))
                        for (int i = 0; i < filters.Count("idfObjectID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfObjectID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfObjectID", i), filters.Value("idfObjectID", i))));
                      
                    if (filters.Contains("strInformationString"))
                        for (int i = 0; i < filters.Count("strInformationString"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strInformationString_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strInformationString", i), filters.Value("strInformationString", i))));
                      
                    if (filters.Contains("strNote"))
                        for (int i = 0; i < filters.Count("strNote"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strNote_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strNote", i), filters.Value("strNote", i))));
                      
                    if (filters.Contains("idfsEventTypeID"))
                        for (int i = 0; i < filters.Count("idfsEventTypeID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsEventTypeID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsEventTypeID", i), filters.Value("idfsEventTypeID", i))));
                      
                    if (filters.Contains("datEventDatatime"))
                        for (int i = 0; i < filters.Count("datEventDatatime"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datEventDatatime_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datEventDatatime", i), filters.Value("datEventDatatime", i))));
                      
                    if (filters.Contains("PersonName"))
                        for (int i = 0; i < filters.Count("PersonName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@PersonName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("PersonName", i), filters.Value("PersonName", i))));
                      
                    if (filters.Contains("idfsCaseType"))
                        for (int i = 0; i < filters.Count("idfsCaseType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseType", i), filters.Value("idfsCaseType", i))));
                      
                    List<EventLogListItem> objs = manager.ExecuteList<EventLogListItem>();
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
        
            [SprocName("spEvent_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, EventLogListItem obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, EventLogListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private EventLogListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    EventLogListItem obj = EventLogListItem.CreateInstance();
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

            
            public EventLogListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public EventLogListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(EventLogListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(EventLogListItem obj)
            {
                
            }
    
            public void LoadLookup_EventType(DbManagerProxy manager, EventLogListItem obj)
            {
                
                obj.EventTypeLookup.Clear();
                
                obj.EventTypeLookup.Add(EventTypeAccessor.CreateNewT(manager, null));
                
                obj.EventTypeLookup.AddRange(EventTypeAccessor.rftEventType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsEventTypeID))
                    
                    .ToList());
                
                if (obj.idfsEventTypeID != null && obj.idfsEventTypeID != 0)
                {
                    obj.EventType = obj.EventTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsEventTypeID)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftEventType", obj, EventTypeAccessor.GetType(), "rftEventType_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, EventLogListItem obj)
            {
                
                LoadLookup_EventType(manager, obj);
                
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
                    EventLogListItem bo = obj as EventLogListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("EventLog", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("EventLog", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("EventLog", "Update");
                    }
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        long mainObject = bo.idfEventID;
                        
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
                    bSuccess = _PostNonTransaction(manager, obj as EventLogListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, EventLogListItem obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfEventID
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
            
            public bool ValidateCanDelete(EventLogListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, EventLogListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfEventID
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
                return Validate(manager, obj as EventLogListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, EventLogListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EventLog.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EventLog.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EventLog.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EventLog.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(EventLogListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(EventLogListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as EventLogListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as EventLogListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "EventLogListItemDetail"; } }
            public string HelpIdWin { get { return "EventLogForm"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private EventLogListItem m_obj;
            internal Permissions(EventLogListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EventLog.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EventLog.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EventLog.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("EventLog.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_Event_SelectList";
            public static string spCount = "spEvent_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spReadOnlyObject_Delete";
            public static string spCanDelete = "spReadOnlyObject_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<EventLogListItem, bool>> RequiredByField = new Dictionary<string, Func<EventLogListItem, bool>>();
            public static Dictionary<string, Func<EventLogListItem, bool>> RequiredByProperty = new Dictionary<string, Func<EventLogListItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strEventTypeName, 2000);
                Sizes.Add(_str_strInformationString, 200);
                Sizes.Add(_str_strNote, 200);
                Sizes.Add(_str_PersonName, 602);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datEventDatatime",
                    EditorType.Date,
                    true, false, 
                    "datEventDatatime",
                    () => DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter), null, true, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "PersonName",
                    EditorType.Text,
                    false, false, 
                    "PersonName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strInformationString",
                    EditorType.Text,
                    false, false, 
                    "strInformationString",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strNote",
                    EditorType.Text,
                    false, false, 
                    "EventLog.strNote",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsEventTypeID",
                    EditorType.Lookup,
                    false, false, 
                    "strEventTypeName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "EventTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfEventID,
                    _str_idfEventID, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datEventDatatime,
                    _str_datEventDatatime, "G", true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_PersonName,
                    _str_PersonName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strInformationString,
                    _str_strInformationString, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNote,
                    "EventLog.strNote", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strEventTypeName,
                    _str_strEventTypeName, null, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "View",
                    ActionTypes.Edit,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"strView_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	