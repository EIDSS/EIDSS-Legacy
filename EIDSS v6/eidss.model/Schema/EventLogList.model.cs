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
        protected String strEventTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._strEventTypeName).OriginalValue; } }
        protected String strEventTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strEventTypeName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfObjectID)]
        [MapField(_str_idfObjectID)]
        public abstract Int64? idfObjectID { get; set; }
        protected Int64? idfObjectID_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObjectID).OriginalValue; } }
        protected Int64? idfObjectID_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObjectID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strInformationString)]
        [MapField(_str_strInformationString)]
        public abstract String strInformationString { get; set; }
        protected String strInformationString_Original { get { return ((EditableValue<String>)((dynamic)this)._strInformationString).OriginalValue; } }
        protected String strInformationString_Previous { get { return ((EditableValue<String>)((dynamic)this)._strInformationString).PreviousValue; } }
                
        [LocalizedDisplayName("EventLog.strNote")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsEventTypeID)]
        [MapField(_str_idfsEventTypeID)]
        public abstract Int64? idfsEventTypeID { get; set; }
        protected Int64? idfsEventTypeID_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEventTypeID).OriginalValue; } }
        protected Int64? idfsEventTypeID_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEventTypeID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datEventDatatime)]
        [MapField(_str_datEventDatatime)]
        public abstract DateTime? datEventDatatime { get; set; }
        protected DateTime? datEventDatatime_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEventDatatime).OriginalValue; } }
        protected DateTime? datEventDatatime_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEventDatatime).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPerson)]
        [MapField(_str_idfPerson)]
        public abstract Int64? idfPerson { get; set; }
        protected Int64? idfPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerson).OriginalValue; } }
        protected Int64? idfPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPersonName)]
        [MapField(_str_strPersonName)]
        public abstract String strPersonName { get; set; }
        protected String strPersonName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPersonName).OriginalValue; } }
        protected String strPersonName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPersonName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCaseType)]
        [MapField(_str_idfsCaseType)]
        public abstract Int64? idfsCaseType { get; set; }
        protected Int64? idfsCaseType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).OriginalValue; } }
        protected Int64? idfsCaseType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseType).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
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
        internal const string _str_idfPerson = "idfPerson";
        internal const string _str_strPersonName = "strPersonName";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_EventType = "EventType";
        internal const string _str_PersonEnteredBy = "PersonEnteredBy";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfEventID, _formname = _str_idfEventID, _type = "Int64",
              _get_func = o => o.idfEventID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfEventID != newval) o.idfEventID = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfEventID != c.idfEventID || o.IsRIRPropChanged(_str_idfEventID, c)) 
                  m.Add(_str_idfEventID, o.ObjectIdent + _str_idfEventID, o.ObjectIdent2 + _str_idfEventID, o.ObjectIdent3 + _str_idfEventID, "Int64", 
                    o.idfEventID == null ? "" : o.idfEventID.ToString(),                  
                  o.IsReadOnly(_str_idfEventID), o.IsInvisible(_str_idfEventID), o.IsRequired(_str_idfEventID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strEventTypeName, _formname = _str_strEventTypeName, _type = "String",
              _get_func = o => o.strEventTypeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strEventTypeName != newval) o.strEventTypeName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strEventTypeName != c.strEventTypeName || o.IsRIRPropChanged(_str_strEventTypeName, c)) 
                  m.Add(_str_strEventTypeName, o.ObjectIdent + _str_strEventTypeName, o.ObjectIdent2 + _str_strEventTypeName, o.ObjectIdent3 + _str_strEventTypeName, "String", 
                    o.strEventTypeName == null ? "" : o.strEventTypeName.ToString(),                  
                  o.IsReadOnly(_str_strEventTypeName), o.IsInvisible(_str_strEventTypeName), o.IsRequired(_str_strEventTypeName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfObjectID, _formname = _str_idfObjectID, _type = "Int64?",
              _get_func = o => o.idfObjectID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfObjectID != newval) o.idfObjectID = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfObjectID != c.idfObjectID || o.IsRIRPropChanged(_str_idfObjectID, c)) 
                  m.Add(_str_idfObjectID, o.ObjectIdent + _str_idfObjectID, o.ObjectIdent2 + _str_idfObjectID, o.ObjectIdent3 + _str_idfObjectID, "Int64?", 
                    o.idfObjectID == null ? "" : o.idfObjectID.ToString(),                  
                  o.IsReadOnly(_str_idfObjectID), o.IsInvisible(_str_idfObjectID), o.IsRequired(_str_idfObjectID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strInformationString, _formname = _str_strInformationString, _type = "String",
              _get_func = o => o.strInformationString,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strInformationString != newval) o.strInformationString = newval; },
              _compare_func = (o, c, m) => {
                if (o.strInformationString != c.strInformationString || o.IsRIRPropChanged(_str_strInformationString, c)) 
                  m.Add(_str_strInformationString, o.ObjectIdent + _str_strInformationString, o.ObjectIdent2 + _str_strInformationString, o.ObjectIdent3 + _str_strInformationString, "String", 
                    o.strInformationString == null ? "" : o.strInformationString.ToString(),                  
                  o.IsReadOnly(_str_strInformationString), o.IsInvisible(_str_strInformationString), o.IsRequired(_str_strInformationString)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strNote, _formname = _str_strNote, _type = "String",
              _get_func = o => o.strNote,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strNote != newval) o.strNote = newval; },
              _compare_func = (o, c, m) => {
                if (o.strNote != c.strNote || o.IsRIRPropChanged(_str_strNote, c)) 
                  m.Add(_str_strNote, o.ObjectIdent + _str_strNote, o.ObjectIdent2 + _str_strNote, o.ObjectIdent3 + _str_strNote, "String", 
                    o.strNote == null ? "" : o.strNote.ToString(),                  
                  o.IsReadOnly(_str_strNote), o.IsInvisible(_str_strNote), o.IsRequired(_str_strNote)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsEventTypeID, _formname = _str_idfsEventTypeID, _type = "Int64?",
              _get_func = o => o.idfsEventTypeID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsEventTypeID != newval) 
                  o.EventType = o.EventTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsEventTypeID != newval) o.idfsEventTypeID = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsEventTypeID != c.idfsEventTypeID || o.IsRIRPropChanged(_str_idfsEventTypeID, c)) 
                  m.Add(_str_idfsEventTypeID, o.ObjectIdent + _str_idfsEventTypeID, o.ObjectIdent2 + _str_idfsEventTypeID, o.ObjectIdent3 + _str_idfsEventTypeID, "Int64?", 
                    o.idfsEventTypeID == null ? "" : o.idfsEventTypeID.ToString(),                  
                  o.IsReadOnly(_str_idfsEventTypeID), o.IsInvisible(_str_idfsEventTypeID), o.IsRequired(_str_idfsEventTypeID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datEventDatatime, _formname = _str_datEventDatatime, _type = "DateTime?",
              _get_func = o => o.datEventDatatime,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datEventDatatime != newval) o.datEventDatatime = newval; },
              _compare_func = (o, c, m) => {
                if (o.datEventDatatime != c.datEventDatatime || o.IsRIRPropChanged(_str_datEventDatatime, c)) 
                  m.Add(_str_datEventDatatime, o.ObjectIdent + _str_datEventDatatime, o.ObjectIdent2 + _str_datEventDatatime, o.ObjectIdent3 + _str_datEventDatatime, "DateTime?", 
                    o.datEventDatatime == null ? "" : o.datEventDatatime.ToString(),                  
                  o.IsReadOnly(_str_datEventDatatime), o.IsInvisible(_str_datEventDatatime), o.IsRequired(_str_datEventDatatime)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfPerson, _formname = _str_idfPerson, _type = "Int64?",
              _get_func = o => o.idfPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfPerson != newval) 
                  o.PersonEnteredBy = o.PersonEnteredByLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfPerson != newval) o.idfPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfPerson != c.idfPerson || o.IsRIRPropChanged(_str_idfPerson, c)) 
                  m.Add(_str_idfPerson, o.ObjectIdent + _str_idfPerson, o.ObjectIdent2 + _str_idfPerson, o.ObjectIdent3 + _str_idfPerson, "Int64?", 
                    o.idfPerson == null ? "" : o.idfPerson.ToString(),                  
                  o.IsReadOnly(_str_idfPerson), o.IsInvisible(_str_idfPerson), o.IsRequired(_str_idfPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPersonName, _formname = _str_strPersonName, _type = "String",
              _get_func = o => o.strPersonName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPersonName != newval) o.strPersonName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPersonName != c.strPersonName || o.IsRIRPropChanged(_str_strPersonName, c)) 
                  m.Add(_str_strPersonName, o.ObjectIdent + _str_strPersonName, o.ObjectIdent2 + _str_strPersonName, o.ObjectIdent3 + _str_strPersonName, "String", 
                    o.strPersonName == null ? "" : o.strPersonName.ToString(),                  
                  o.IsReadOnly(_str_strPersonName), o.IsInvisible(_str_strPersonName), o.IsRequired(_str_strPersonName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCaseType, _formname = _str_idfsCaseType, _type = "Int64?",
              _get_func = o => o.idfsCaseType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsCaseType != newval) o.idfsCaseType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_idfsCaseType, c)) 
                  m.Add(_str_idfsCaseType, o.ObjectIdent + _str_idfsCaseType, o.ObjectIdent2 + _str_idfsCaseType, o.ObjectIdent3 + _str_idfsCaseType, "Int64?", 
                    o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseType), o.IsInvisible(_str_idfsCaseType), o.IsRequired(_str_idfsCaseType)); 
                  }
              }, 
        
            new field_info {
              _name = _str_EventType, _formname = _str_EventType, _type = "Lookup",
              _get_func = o => { if (o.EventType == null) return null; return o.EventType.idfsBaseReference; },
              _set_func = (o, val) => { o.EventType = o.EventTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsEventTypeID != c.idfsEventTypeID || o.IsRIRPropChanged(_str_EventType, c)) {
                  m.Add(_str_EventType, o.ObjectIdent + _str_EventType, o.ObjectIdent2 + _str_EventType, o.ObjectIdent3 + _str_EventType, "Lookup", o.idfsEventTypeID == null ? "" : o.idfsEventTypeID.ToString(), o.IsReadOnly(_str_EventType), o.IsInvisible(_str_EventType), o.IsRequired(_str_EventType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_EventType + "Lookup", _formname = _str_EventType + "Lookup", _type = "LookupContent",
              _get_func = o => o.EventTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_PersonEnteredBy, _formname = _str_PersonEnteredBy, _type = "Lookup",
              _get_func = o => { if (o.PersonEnteredBy == null) return null; return o.PersonEnteredBy.idfPerson; },
              _set_func = (o, val) => { o.PersonEnteredBy = o.PersonEnteredByLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfPerson != c.idfPerson || o.IsRIRPropChanged(_str_PersonEnteredBy, c)) {
                  m.Add(_str_PersonEnteredBy, o.ObjectIdent + _str_PersonEnteredBy, o.ObjectIdent2 + _str_PersonEnteredBy, o.ObjectIdent3 + _str_PersonEnteredBy, "Lookup", o.idfPerson == null ? "" : o.idfPerson.ToString(), o.IsReadOnly(_str_PersonEnteredBy), o.IsInvisible(_str_PersonEnteredBy), o.IsRequired(_str_PersonEnteredBy)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_PersonEnteredBy + "Lookup", _formname = _str_PersonEnteredBy + "Lookup", _type = "LookupContent",
              _get_func = o => o.PersonEnteredByLookup,
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
            EventLogListItem obj = (EventLogListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_EventType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsEventTypeID)]
        public BaseReference EventType
        {
            get { return _EventType == null ? null : ((long)_EventType.Key == 0 ? null : _EventType); }
            set 
            { 
                var oldVal = _EventType;
                _EventType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_EventType != oldVal)
                {
                    if (idfsEventTypeID != (_EventType == null
                            ? new Int64?()
                            : (Int64?)_EventType.idfsBaseReference))
                        idfsEventTypeID = _EventType == null 
                            ? new Int64?()
                            : (Int64?)_EventType.idfsBaseReference; 
                    OnPropertyChanged(_str_EventType); 
                }
            }
        }
        private BaseReference _EventType;

        
        public BaseReferenceList EventTypeLookup
        {
            get { return _EventTypeLookup; }
        }
        private BaseReferenceList _EventTypeLookup = new BaseReferenceList("rftEventType");
            
        [LocalizedDisplayName(_str_PersonEnteredBy)]
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfPerson)]
        public PersonLookup PersonEnteredBy
        {
            get { return _PersonEnteredBy == null ? null : ((long)_PersonEnteredBy.Key == 0 ? null : _PersonEnteredBy); }
            set 
            { 
                var oldVal = _PersonEnteredBy;
                _PersonEnteredBy = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_PersonEnteredBy != oldVal)
                {
                    if (idfPerson != (_PersonEnteredBy == null
                            ? new Int64?()
                            : (Int64?)_PersonEnteredBy.idfPerson))
                        idfPerson = _PersonEnteredBy == null 
                            ? new Int64?()
                            : (Int64?)_PersonEnteredBy.idfPerson; 
                    OnPropertyChanged(_str_PersonEnteredBy); 
                }
            }
        }
        private PersonLookup _PersonEnteredBy;

        
        public List<PersonLookup> PersonEnteredByLookup
        {
            get { return _PersonEnteredByLookup; }
        }
        private List<PersonLookup> _PersonEnteredByLookup = new List<PersonLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_EventType:
                    return new BvSelectList(EventTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, EventType, _str_idfsEventTypeID);
            
                case _str_PersonEnteredBy:
                    return new BvSelectList(PersonEnteredByLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, PersonEnteredBy, _str_idfPerson);
            
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
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as EventLogListItem;
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
            var ret = base.Clone() as EventLogListItem;
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
        
            var _prev_idfsEventTypeID_EventType = idfsEventTypeID;
            var _prev_idfPerson_PersonEnteredBy = idfPerson;
            base.RejectChanges();
        
            if (_prev_idfsEventTypeID_EventType != idfsEventTypeID)
            {
                _EventType = _EventTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsEventTypeID);
            }
            if (_prev_idfPerson_PersonEnteredBy != idfPerson)
            {
                _PersonEnteredBy = _PersonEnteredByLookup.FirstOrDefault(c => c.idfPerson == idfPerson);
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

        private bool IsRIRPropChanged(string fld, EventLogListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public EventLogListItem()
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


        internal Dictionary<string, Func<EventLogListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<EventLogListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<EventLogListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<EventLogListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<EventLogListItem, bool>> m_isHiddenPersonalData;
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
                
                LookupManager.RemoveObject("PersonLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftEventType")
                _getAccessor().LoadLookup_EventType(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_PersonEnteredBy(manager, this);
            
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
        public class EventLogListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfEventID { get; set; }
        
            public DateTime? datEventDatatime { get; set; }
        
            public String strPersonName { get; set; }
        
            public String strEventTypeName { get; set; }
        
        }
        public partial class EventLogListItemGridModelList : List<EventLogListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public EventLogListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<EventLogListItem>, errMes);
            }
            public EventLogListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<EventLogListItem>, errMes);
            }
            public EventLogListItemGridModelList(long key, IEnumerable<EventLogListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public EventLogListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<EventLogListItem>(), null);
            }
            partial void filter(List<EventLogListItem> items);
            private void LoadGridModelList(long key, IEnumerable<EventLogListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_datEventDatatime,_str_strPersonName,_str_strEventTypeName};
                    
                Hiddens = new List<string> {_str_idfEventID};
                Keys = new List<string> {_str_idfEventID};
                Labels = new Dictionary<string, string> {{_str_datEventDatatime, _str_datEventDatatime},{_str_strPersonName, _str_strPersonName},{_str_strEventTypeName, _str_strEventTypeName}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                EventLogListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<EventLogListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new EventLogListItemGridModel()
                {
                    ItemKey=c.idfEventID,datEventDatatime=c.datEventDatatime,strPersonName=c.strPersonName,strEventTypeName=c.strEventTypeName
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
            , IObjectCreator<EventLogListItem>
            
            , IObjectSelectList
            , IObjectSelectList<EventLogListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfEventID"; } }
            #endregion
        
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
            private PersonLookup.Accessor PersonEnteredByAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            
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
                        
                        if (filters.Operation("idfEventID", i) == "&")
                          sql.AppendFormat("(isnull(fn_Event_SelectList.idfEventID,0) {0} @idfEventID_{1} = @idfEventID_{1})", filters.Operation("idfEventID", i), i);
                        else
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
                        
                        if (filters.Operation("idfObjectID", i) == "&")
                          sql.AppendFormat("(isnull(fn_Event_SelectList.idfObjectID,0) {0} @idfObjectID_{1} = @idfObjectID_{1})", filters.Operation("idfObjectID", i), i);
                        else
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
                        
                        if (filters.Operation("idfsEventTypeID", i) == "&")
                          sql.AppendFormat("(isnull(fn_Event_SelectList.idfsEventTypeID,0) {0} @idfsEventTypeID_{1} = @idfsEventTypeID_{1})", filters.Operation("idfsEventTypeID", i), i);
                        else
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
                  
                if (filters.Contains("idfPerson"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfPerson"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfPerson") ? " or " : " and ");
                        
                        if (filters.Operation("idfPerson", i) == "&")
                          sql.AppendFormat("(isnull(fn_Event_SelectList.idfPerson,0) {0} @idfPerson_{1} = @idfPerson_{1})", filters.Operation("idfPerson", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Event_SelectList.idfPerson,0) {0} @idfPerson_{1}", filters.Operation("idfPerson", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strPersonName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strPersonName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strPersonName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Event_SelectList.strPersonName {0} @strPersonName_{1}", filters.Operation("strPersonName", i), i);
                            
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
                        
                        if (filters.Operation("idfsCaseType", i) == "&")
                          sql.AppendFormat("(isnull(fn_Event_SelectList.idfsCaseType,0) {0} @idfsCaseType_{1} = @idfsCaseType_{1})", filters.Operation("idfsCaseType", i), i);
                        else
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
                    
                    sql.Append(" option (OPTIMIZE FOR UNKNOWN)");
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
                      
                    if (filters.Contains("idfPerson"))
                        for (int i = 0; i < filters.Count("idfPerson"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfPerson", i), filters.Value("idfPerson", i))));
                      
                    if (filters.Contains("strPersonName"))
                        for (int i = 0; i < filters.Count("strPersonName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strPersonName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strPersonName", i), filters.Value("strPersonName", i))));
                      
                    if (filters.Contains("idfsCaseType"))
                        for (int i = 0; i < filters.Count("idfsCaseType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseType", i), filters.Value("idfsCaseType", i))));
                      
                    List<EventLogListItem> objs = manager.ExecuteList<EventLogListItem>();
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
            partial void ListSelected(DbManagerProxy manager, List<EventLogListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spEvent_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, EventLogListItem obj, bool bCloning = false)
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

    

            private EventLogListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
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
            public EventLogListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
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
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsEventTypeID);
                    
                }
              
                
                LookupManager.AddObject("rftEventType", obj, EventTypeAccessor.GetType(), "rftEventType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_PersonEnteredBy(DbManagerProxy manager, EventLogListItem obj)
            {
                
                obj.PersonEnteredByLookup.Clear();
                
                obj.PersonEnteredByLookup.Add(PersonEnteredByAccessor.CreateNewT(manager, null));
                
                obj.PersonEnteredByLookup.AddRange(PersonEnteredByAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    , true
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfPerson))
                    
                    .ToList());
                
                if (obj.idfPerson != null && obj.idfPerson != 0)
                {
                    obj.PersonEnteredBy = obj.PersonEnteredByLookup
                        .SingleOrDefault(c => c.idfPerson == obj.idfPerson);
                    
                }
              
                
                LookupManager.AddObject("PersonLookup", obj, PersonEnteredByAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, EventLogListItem obj)
            {
                
                LoadLookup_EventType(manager, obj);
                
                LoadLookup_PersonEnteredBy(manager, obj);
                
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
                    bSuccess = _PostNonTransaction(manager, obj as EventLogListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, EventLogListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
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
                //obj.AcceptChanges();
                
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
        
      
            protected ValidationModelException ChainsValidate(EventLogListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(EventLogListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as EventLogListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, EventLogListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
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
            public string HelpIdWin { get { return "System_Event_Log"; } }
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
                
                Sizes.Add(_str_strEventTypeName, 2000);
                Sizes.Add(_str_strInformationString, 200);
                Sizes.Add(_str_strNote, 200);
                Sizes.Add(_str_strPersonName, 602);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datEventDatatime",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datEventDatatime",
                    c => DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter), null, c => true, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfPerson",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strPersonName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "PersonEnteredByLookup", typeof(PersonLookup), (o) => { var c = (PersonLookup)o; return c.idfPerson; }, (o) => { var c = (PersonLookup)o; return c.FullName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsEventTypeID",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strEventTypeName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "EventTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfEventID,
                    _str_idfEventID, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datEventDatatime,
                    _str_datEventDatatime, "G", true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPersonName,
                    _str_strPersonName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strEventTypeName,
                    _str_strEventTypeName, null, true, true, true, true, null
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
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
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
	