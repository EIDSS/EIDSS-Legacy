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
    public abstract partial class AsSessionAction : 
        EditableObject<AsSessionAction>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfMonitoringSessionAction), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMonitoringSessionAction { get; set; }
                
        [LocalizedDisplayName(_str_idfMonitoringSession)]
        [MapField(_str_idfMonitoringSession)]
        public abstract Int64 idfMonitoringSession { get; set; }
        protected Int64 idfMonitoringSession_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfMonitoringSession).OriginalValue; } }
        protected Int64 idfMonitoringSession_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfMonitoringSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPersonEnteredBy)]
        [MapField(_str_idfPersonEnteredBy)]
        public abstract Int64 idfPersonEnteredBy { get; set; }
        protected Int64 idfPersonEnteredBy_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfPersonEnteredBy).OriginalValue; } }
        protected Int64 idfPersonEnteredBy_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfPersonEnteredBy).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsMonitoringSessionActionType)]
        [MapField(_str_idfsMonitoringSessionActionType)]
        public abstract Int64 idfsMonitoringSessionActionType { get; set; }
        protected Int64 idfsMonitoringSessionActionType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsMonitoringSessionActionType).OriginalValue; } }
        protected Int64 idfsMonitoringSessionActionType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsMonitoringSessionActionType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsMonitoringSessionActionStatus)]
        [MapField(_str_idfsMonitoringSessionActionStatus)]
        public abstract Int64 idfsMonitoringSessionActionStatus { get; set; }
        protected Int64 idfsMonitoringSessionActionStatus_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsMonitoringSessionActionStatus).OriginalValue; } }
        protected Int64 idfsMonitoringSessionActionStatus_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsMonitoringSessionActionStatus).PreviousValue; } }
                
        [LocalizedDisplayName("AsSessionAction.datActionDate")]
        [MapField(_str_datActionDate)]
        public abstract DateTime? datActionDate { get; set; }
        protected DateTime? datActionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datActionDate).OriginalValue; } }
        protected DateTime? datActionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datActionDate).PreviousValue; } }
                
        [LocalizedDisplayName("strComment")]
        [MapField(_str_strComments)]
        public abstract String strComments { get; set; }
        protected String strComments_Original { get { return ((EditableValue<String>)((dynamic)this)._strComments).OriginalValue; } }
        protected String strComments_Previous { get { return ((EditableValue<String>)((dynamic)this)._strComments).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPersonEnteredBy)]
        [MapField(_str_strPersonEnteredBy)]
        public abstract String strPersonEnteredBy { get; set; }
        protected String strPersonEnteredBy_Original { get { return ((EditableValue<String>)((dynamic)this)._strPersonEnteredBy).OriginalValue; } }
        protected String strPersonEnteredBy_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPersonEnteredBy).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<AsSessionAction, object> _get_func;
            internal Action<AsSessionAction, string> _set_func;
            internal Action<AsSessionAction, AsSessionAction, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfMonitoringSessionAction = "idfMonitoringSessionAction";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_idfPersonEnteredBy = "idfPersonEnteredBy";
        internal const string _str_idfsMonitoringSessionActionType = "idfsMonitoringSessionActionType";
        internal const string _str_idfsMonitoringSessionActionStatus = "idfsMonitoringSessionActionStatus";
        internal const string _str_datActionDate = "datActionDate";
        internal const string _str_strComments = "strComments";
        internal const string _str_strPersonEnteredBy = "strPersonEnteredBy";
        internal const string _str_strMonitoringSessionActionType = "strMonitoringSessionActionType";
        internal const string _str_strMonitoringSessionActionStatus = "strMonitoringSessionActionStatus";
        internal const string _str_datStartDate = "datStartDate";
        internal const string _str_Action = "Action";
        internal const string _str_MonitoringSessionActionStatus = "MonitoringSessionActionStatus";
        internal const string _str_MonitoringSessionActionType = "MonitoringSessionActionType";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfMonitoringSessionAction, _formname = _str_idfMonitoringSessionAction, _type = "Int64",
              _get_func = o => o.idfMonitoringSessionAction,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfMonitoringSessionAction != newval) o.idfMonitoringSessionAction = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfMonitoringSessionAction != c.idfMonitoringSessionAction || o.IsRIRPropChanged(_str_idfMonitoringSessionAction, c)) 
                  m.Add(_str_idfMonitoringSessionAction, o.ObjectIdent + _str_idfMonitoringSessionAction, o.ObjectIdent2 + _str_idfMonitoringSessionAction, o.ObjectIdent3 + _str_idfMonitoringSessionAction, "Int64", 
                    o.idfMonitoringSessionAction == null ? "" : o.idfMonitoringSessionAction.ToString(),                  
                  o.IsReadOnly(_str_idfMonitoringSessionAction), o.IsInvisible(_str_idfMonitoringSessionAction), o.IsRequired(_str_idfMonitoringSessionAction)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfMonitoringSession, _formname = _str_idfMonitoringSession, _type = "Int64",
              _get_func = o => o.idfMonitoringSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfMonitoringSession != newval) o.idfMonitoringSession = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfMonitoringSession != c.idfMonitoringSession || o.IsRIRPropChanged(_str_idfMonitoringSession, c)) 
                  m.Add(_str_idfMonitoringSession, o.ObjectIdent + _str_idfMonitoringSession, o.ObjectIdent2 + _str_idfMonitoringSession, o.ObjectIdent3 + _str_idfMonitoringSession, "Int64", 
                    o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(),                  
                  o.IsReadOnly(_str_idfMonitoringSession), o.IsInvisible(_str_idfMonitoringSession), o.IsRequired(_str_idfMonitoringSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfPersonEnteredBy, _formname = _str_idfPersonEnteredBy, _type = "Int64",
              _get_func = o => o.idfPersonEnteredBy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfPersonEnteredBy != newval) o.idfPersonEnteredBy = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfPersonEnteredBy != c.idfPersonEnteredBy || o.IsRIRPropChanged(_str_idfPersonEnteredBy, c)) 
                  m.Add(_str_idfPersonEnteredBy, o.ObjectIdent + _str_idfPersonEnteredBy, o.ObjectIdent2 + _str_idfPersonEnteredBy, o.ObjectIdent3 + _str_idfPersonEnteredBy, "Int64", 
                    o.idfPersonEnteredBy == null ? "" : o.idfPersonEnteredBy.ToString(),                  
                  o.IsReadOnly(_str_idfPersonEnteredBy), o.IsInvisible(_str_idfPersonEnteredBy), o.IsRequired(_str_idfPersonEnteredBy)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsMonitoringSessionActionType, _formname = _str_idfsMonitoringSessionActionType, _type = "Int64",
              _get_func = o => o.idfsMonitoringSessionActionType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsMonitoringSessionActionType != newval) 
                  o.MonitoringSessionActionType = o.MonitoringSessionActionTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsMonitoringSessionActionType != newval) o.idfsMonitoringSessionActionType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsMonitoringSessionActionType != c.idfsMonitoringSessionActionType || o.IsRIRPropChanged(_str_idfsMonitoringSessionActionType, c)) 
                  m.Add(_str_idfsMonitoringSessionActionType, o.ObjectIdent + _str_idfsMonitoringSessionActionType, o.ObjectIdent2 + _str_idfsMonitoringSessionActionType, o.ObjectIdent3 + _str_idfsMonitoringSessionActionType, "Int64", 
                    o.idfsMonitoringSessionActionType == null ? "" : o.idfsMonitoringSessionActionType.ToString(),                  
                  o.IsReadOnly(_str_idfsMonitoringSessionActionType), o.IsInvisible(_str_idfsMonitoringSessionActionType), o.IsRequired(_str_idfsMonitoringSessionActionType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsMonitoringSessionActionStatus, _formname = _str_idfsMonitoringSessionActionStatus, _type = "Int64",
              _get_func = o => o.idfsMonitoringSessionActionStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsMonitoringSessionActionStatus != newval) 
                  o.MonitoringSessionActionStatus = o.MonitoringSessionActionStatusLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsMonitoringSessionActionStatus != newval) o.idfsMonitoringSessionActionStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsMonitoringSessionActionStatus != c.idfsMonitoringSessionActionStatus || o.IsRIRPropChanged(_str_idfsMonitoringSessionActionStatus, c)) 
                  m.Add(_str_idfsMonitoringSessionActionStatus, o.ObjectIdent + _str_idfsMonitoringSessionActionStatus, o.ObjectIdent2 + _str_idfsMonitoringSessionActionStatus, o.ObjectIdent3 + _str_idfsMonitoringSessionActionStatus, "Int64", 
                    o.idfsMonitoringSessionActionStatus == null ? "" : o.idfsMonitoringSessionActionStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsMonitoringSessionActionStatus), o.IsInvisible(_str_idfsMonitoringSessionActionStatus), o.IsRequired(_str_idfsMonitoringSessionActionStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datActionDate, _formname = _str_datActionDate, _type = "DateTime?",
              _get_func = o => o.datActionDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datActionDate != newval) o.datActionDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datActionDate != c.datActionDate || o.IsRIRPropChanged(_str_datActionDate, c)) 
                  m.Add(_str_datActionDate, o.ObjectIdent + _str_datActionDate, o.ObjectIdent2 + _str_datActionDate, o.ObjectIdent3 + _str_datActionDate, "DateTime?", 
                    o.datActionDate == null ? "" : o.datActionDate.ToString(),                  
                  o.IsReadOnly(_str_datActionDate), o.IsInvisible(_str_datActionDate), o.IsRequired(_str_datActionDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strComments, _formname = _str_strComments, _type = "String",
              _get_func = o => o.strComments,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strComments != newval) o.strComments = newval; },
              _compare_func = (o, c, m) => {
                if (o.strComments != c.strComments || o.IsRIRPropChanged(_str_strComments, c)) 
                  m.Add(_str_strComments, o.ObjectIdent + _str_strComments, o.ObjectIdent2 + _str_strComments, o.ObjectIdent3 + _str_strComments, "String", 
                    o.strComments == null ? "" : o.strComments.ToString(),                  
                  o.IsReadOnly(_str_strComments), o.IsInvisible(_str_strComments), o.IsRequired(_str_strComments)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPersonEnteredBy, _formname = _str_strPersonEnteredBy, _type = "String",
              _get_func = o => o.strPersonEnteredBy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPersonEnteredBy != newval) o.strPersonEnteredBy = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPersonEnteredBy != c.strPersonEnteredBy || o.IsRIRPropChanged(_str_strPersonEnteredBy, c)) 
                  m.Add(_str_strPersonEnteredBy, o.ObjectIdent + _str_strPersonEnteredBy, o.ObjectIdent2 + _str_strPersonEnteredBy, o.ObjectIdent3 + _str_strPersonEnteredBy, "String", 
                    o.strPersonEnteredBy == null ? "" : o.strPersonEnteredBy.ToString(),                  
                  o.IsReadOnly(_str_strPersonEnteredBy), o.IsInvisible(_str_strPersonEnteredBy), o.IsRequired(_str_strPersonEnteredBy)); 
                  }
              }, 
        
            new field_info {
              _name = _str_Action, _formname = _str_Action, _type = "int",
              _get_func = o => o.Action,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.Action != newval) o.Action = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.Action != c.Action || o.IsRIRPropChanged(_str_Action, c)) {
                  m.Add(_str_Action, o.ObjectIdent + _str_Action, o.ObjectIdent2 + _str_Action, o.ObjectIdent3 + _str_Action,  "int", 
                    o.Action == null ? "" : o.Action.ToString(),                  
                    o.IsReadOnly(_str_Action), o.IsInvisible(_str_Action), o.IsRequired(_str_Action));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_strMonitoringSessionActionType, _formname = _str_strMonitoringSessionActionType, _type = "string",
              _get_func = o => o.strMonitoringSessionActionType,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strMonitoringSessionActionType != c.strMonitoringSessionActionType || o.IsRIRPropChanged(_str_strMonitoringSessionActionType, c)) {
                  m.Add(_str_strMonitoringSessionActionType, o.ObjectIdent + _str_strMonitoringSessionActionType, o.ObjectIdent2 + _str_strMonitoringSessionActionType, o.ObjectIdent3 + _str_strMonitoringSessionActionType, "string", o.strMonitoringSessionActionType == null ? "" : o.strMonitoringSessionActionType.ToString(), o.IsReadOnly(_str_strMonitoringSessionActionType), o.IsInvisible(_str_strMonitoringSessionActionType), o.IsRequired(_str_strMonitoringSessionActionType));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strMonitoringSessionActionStatus, _formname = _str_strMonitoringSessionActionStatus, _type = "string",
              _get_func = o => o.strMonitoringSessionActionStatus,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strMonitoringSessionActionStatus != c.strMonitoringSessionActionStatus || o.IsRIRPropChanged(_str_strMonitoringSessionActionStatus, c)) {
                  m.Add(_str_strMonitoringSessionActionStatus, o.ObjectIdent + _str_strMonitoringSessionActionStatus, o.ObjectIdent2 + _str_strMonitoringSessionActionStatus, o.ObjectIdent3 + _str_strMonitoringSessionActionStatus, "string", o.strMonitoringSessionActionStatus == null ? "" : o.strMonitoringSessionActionStatus.ToString(), o.IsReadOnly(_str_strMonitoringSessionActionStatus), o.IsInvisible(_str_strMonitoringSessionActionStatus), o.IsRequired(_str_strMonitoringSessionActionStatus));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_datStartDate, _formname = _str_datStartDate, _type = "DateTime?",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) {
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, o.ObjectIdent2 + _str_datStartDate, o.ObjectIdent3 + _str_datStartDate, "DateTime?", o.datStartDate == null ? "" : o.datStartDate.ToString(), o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_MonitoringSessionActionStatus, _formname = _str_MonitoringSessionActionStatus, _type = "Lookup",
              _get_func = o => { if (o.MonitoringSessionActionStatus == null) return null; return o.MonitoringSessionActionStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.MonitoringSessionActionStatus = o.MonitoringSessionActionStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsMonitoringSessionActionStatus != c.idfsMonitoringSessionActionStatus || o.IsRIRPropChanged(_str_MonitoringSessionActionStatus, c)) {
                  m.Add(_str_MonitoringSessionActionStatus, o.ObjectIdent + _str_MonitoringSessionActionStatus, o.ObjectIdent2 + _str_MonitoringSessionActionStatus, o.ObjectIdent3 + _str_MonitoringSessionActionStatus, "Lookup", o.idfsMonitoringSessionActionStatus == null ? "" : o.idfsMonitoringSessionActionStatus.ToString(), o.IsReadOnly(_str_MonitoringSessionActionStatus), o.IsInvisible(_str_MonitoringSessionActionStatus), o.IsRequired(_str_MonitoringSessionActionStatus)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_MonitoringSessionActionStatus + "Lookup", _formname = _str_MonitoringSessionActionStatus + "Lookup", _type = "LookupContent",
              _get_func = o => o.MonitoringSessionActionStatusLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_MonitoringSessionActionType, _formname = _str_MonitoringSessionActionType, _type = "Lookup",
              _get_func = o => { if (o.MonitoringSessionActionType == null) return null; return o.MonitoringSessionActionType.idfsBaseReference; },
              _set_func = (o, val) => { o.MonitoringSessionActionType = o.MonitoringSessionActionTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsMonitoringSessionActionType != c.idfsMonitoringSessionActionType || o.IsRIRPropChanged(_str_MonitoringSessionActionType, c)) {
                  m.Add(_str_MonitoringSessionActionType, o.ObjectIdent + _str_MonitoringSessionActionType, o.ObjectIdent2 + _str_MonitoringSessionActionType, o.ObjectIdent3 + _str_MonitoringSessionActionType, "Lookup", o.idfsMonitoringSessionActionType == null ? "" : o.idfsMonitoringSessionActionType.ToString(), o.IsReadOnly(_str_MonitoringSessionActionType), o.IsInvisible(_str_MonitoringSessionActionType), o.IsRequired(_str_MonitoringSessionActionType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_MonitoringSessionActionType + "Lookup", _formname = _str_MonitoringSessionActionType + "Lookup", _type = "LookupContent",
              _get_func = o => o.MonitoringSessionActionTypeLookup,
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
            AsSessionAction obj = (AsSessionAction)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_MonitoringSessionActionStatus)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsMonitoringSessionActionStatus)]
        public BaseReference MonitoringSessionActionStatus
        {
            get { return _MonitoringSessionActionStatus == null ? null : ((long)_MonitoringSessionActionStatus.Key == 0 ? null : _MonitoringSessionActionStatus); }
            set 
            { 
                var oldVal = _MonitoringSessionActionStatus;
                _MonitoringSessionActionStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_MonitoringSessionActionStatus != oldVal)
                {
                    if (idfsMonitoringSessionActionStatus != (_MonitoringSessionActionStatus == null
                            ? new Int64()
                            : (Int64)_MonitoringSessionActionStatus.idfsBaseReference))
                        idfsMonitoringSessionActionStatus = _MonitoringSessionActionStatus == null 
                            ? new Int64()
                            : (Int64)_MonitoringSessionActionStatus.idfsBaseReference; 
                    OnPropertyChanged(_str_MonitoringSessionActionStatus); 
                }
            }
        }
        private BaseReference _MonitoringSessionActionStatus;

        
        public BaseReferenceList MonitoringSessionActionStatusLookup
        {
            get { return _MonitoringSessionActionStatusLookup; }
        }
        private BaseReferenceList _MonitoringSessionActionStatusLookup = new BaseReferenceList("rftMonitoringSessionActionStatus");
            
        [LocalizedDisplayName(_str_MonitoringSessionActionType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsMonitoringSessionActionType)]
        public BaseReference MonitoringSessionActionType
        {
            get { return _MonitoringSessionActionType == null ? null : ((long)_MonitoringSessionActionType.Key == 0 ? null : _MonitoringSessionActionType); }
            set 
            { 
                var oldVal = _MonitoringSessionActionType;
                _MonitoringSessionActionType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_MonitoringSessionActionType != oldVal)
                {
                    if (idfsMonitoringSessionActionType != (_MonitoringSessionActionType == null
                            ? new Int64()
                            : (Int64)_MonitoringSessionActionType.idfsBaseReference))
                        idfsMonitoringSessionActionType = _MonitoringSessionActionType == null 
                            ? new Int64()
                            : (Int64)_MonitoringSessionActionType.idfsBaseReference; 
                    OnPropertyChanged(_str_MonitoringSessionActionType); 
                }
            }
        }
        private BaseReference _MonitoringSessionActionType;

        
        public BaseReferenceList MonitoringSessionActionTypeLookup
        {
            get { return _MonitoringSessionActionTypeLookup; }
        }
        private BaseReferenceList _MonitoringSessionActionTypeLookup = new BaseReferenceList("rftMonitoringSessionActionType");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_MonitoringSessionActionStatus:
                    return new BvSelectList(MonitoringSessionActionStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, MonitoringSessionActionStatus, _str_idfsMonitoringSessionActionStatus);
            
                case _str_MonitoringSessionActionType:
                    return new BvSelectList(MonitoringSessionActionTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, MonitoringSessionActionType, _str_idfsMonitoringSessionActionType);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName("idfsMonitoringSessionActionType")]
        public string strMonitoringSessionActionType
        {
            get { return new Func<AsSessionAction, string>(c=>c.MonitoringSessionActionType == null ? "" : c.MonitoringSessionActionType.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("idfsMonitoringSessionActionStatus")]
        public string strMonitoringSessionActionStatus
        {
            get { return new Func<AsSessionAction, string>(c=>c.MonitoringSessionActionStatus == null ? "" : c.MonitoringSessionActionStatus.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("AsSession.DetailsStartDate")]
        public DateTime? datStartDate
        {
            get { return new Func<AsSessionAction, DateTime?>(c => (c.Parent as AsSession).datStartDate)(this); }
            
        }
        
          [LocalizedDisplayName(_str_Action)]
        public int Action
        {
            get { return m_Action; }
            set { if (m_Action != value) { m_Action = value; OnPropertyChanged(_str_Action); } }
        }
        private int m_Action;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AsSessionAction";

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
            var ret = base.Clone() as AsSessionAction;
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
            var ret = base.Clone() as AsSessionAction;
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
        public AsSessionAction CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AsSessionAction;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfMonitoringSessionAction; } }
        public string KeyName { get { return "idfMonitoringSessionAction"; } }
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
        
            var _prev_idfsMonitoringSessionActionStatus_MonitoringSessionActionStatus = idfsMonitoringSessionActionStatus;
            var _prev_idfsMonitoringSessionActionType_MonitoringSessionActionType = idfsMonitoringSessionActionType;
            base.RejectChanges();
        
            if (_prev_idfsMonitoringSessionActionStatus_MonitoringSessionActionStatus != idfsMonitoringSessionActionStatus)
            {
                _MonitoringSessionActionStatus = _MonitoringSessionActionStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsMonitoringSessionActionStatus);
            }
            if (_prev_idfsMonitoringSessionActionType_MonitoringSessionActionType != idfsMonitoringSessionActionType)
            {
                _MonitoringSessionActionType = _MonitoringSessionActionTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsMonitoringSessionActionType);
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

        private bool IsRIRPropChanged(string fld, AsSessionAction c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public AsSessionAction()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AsSessionAction_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AsSessionAction_PropertyChanged);
        }
        private void AsSessionAction_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AsSessionAction).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfsMonitoringSessionActionType)
                OnPropertyChanged(_str_strMonitoringSessionActionType);
                  
            if (e.PropertyName == _str_idfsMonitoringSessionActionStatus)
                OnPropertyChanged(_str_strMonitoringSessionActionStatus);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_datStartDate);
                  
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
            AsSessionAction obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AsSessionAction obj = this;
            
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

    
        private static string[] readonly_names1 = "strPersonEnteredBy,Action".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionAction, bool>(c=>true)(this);
            
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


        internal Dictionary<string, Func<AsSessionAction, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<AsSessionAction, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsSessionAction, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsSessionAction, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<AsSessionAction, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<AsSessionAction, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<AsSessionAction, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AsSessionAction()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftMonitoringSessionActionStatus", this);
                
                LookupManager.RemoveObject("rftMonitoringSessionActionType", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftMonitoringSessionActionStatus")
                _getAccessor().LoadLookup_MonitoringSessionActionStatus(manager, this);
            
            if (lookup_object == "rftMonitoringSessionActionType")
                _getAccessor().LoadLookup_MonitoringSessionActionType(manager, this);
            
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
        public class AsSessionActionGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfMonitoringSessionAction { get; set; }
        
            public string strMonitoringSessionActionType { get; set; }
        
            public DateTime? datActionDate { get; set; }
        
            public string strPersonEnteredBy { get; set; }
        
            public string strComments { get; set; }
        
            public string strMonitoringSessionActionStatus { get; set; }
        
        }
        public partial class AsSessionActionGridModelList : List<AsSessionActionGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public AsSessionActionGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsSessionAction>, errMes);
            }
            public AsSessionActionGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsSessionAction>, errMes);
            }
            public AsSessionActionGridModelList(long key, IEnumerable<AsSessionAction> items)
            {
                LoadGridModelList(key, items, null);
            }
            public AsSessionActionGridModelList(long key)
            {
                LoadGridModelList(key, new List<AsSessionAction>(), null);
            }
            partial void filter(List<AsSessionAction> items);
            private void LoadGridModelList(long key, IEnumerable<AsSessionAction> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strMonitoringSessionActionType,_str_datActionDate,_str_strPersonEnteredBy,_str_strComments,_str_strMonitoringSessionActionStatus};
                    
                Hiddens = new List<string> {_str_idfMonitoringSessionAction};
                Keys = new List<string> {_str_idfMonitoringSessionAction};
                Labels = new Dictionary<string, string> {{_str_strMonitoringSessionActionType, "idfsMonitoringSessionActionType"},{_str_datActionDate, "AsSessionAction.datActionDate"},{_str_strPersonEnteredBy, _str_strPersonEnteredBy},{_str_strComments, "strComment"},{_str_strMonitoringSessionActionStatus, "idfsMonitoringSessionActionStatus"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                AsSessionAction.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<AsSessionAction>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new AsSessionActionGridModel()
                {
                    ItemKey=c.idfMonitoringSessionAction,strMonitoringSessionActionType=c.strMonitoringSessionActionType,datActionDate=c.datActionDate,strPersonEnteredBy=c.strPersonEnteredBy,strComments=c.strComments,strMonitoringSessionActionStatus=c.strMonitoringSessionActionStatus
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
        : DataAccessor<AsSessionAction>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<AsSessionAction>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfMonitoringSessionAction"; } }
            #endregion
        
            private delegate void on_action(AsSessionAction obj);
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
            private BaseReference.Accessor MonitoringSessionActionStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor MonitoringSessionActionTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<AsSessionAction> SelectList(DbManagerProxy manager
                , Int64? idfMonitoringSession
                )
            {
                return _SelectList(manager
                    , idfMonitoringSession
                    , delegate(AsSessionAction obj)
                        {
                        }
                    , delegate(AsSessionAction obj)
                        {
                        }
                    );
            }

            
            private List<AsSessionAction> _SelectList(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<AsSessionAction> objs = new List<AsSessionAction>();
                    sets[0] = new MapResultSet(typeof(AsSessionAction), objs);
                    
                    manager
                        .SetSpCommand("spAsSessionAction_SelectDetail"
                            , manager.Parameter("@idfMonitoringSession", idfMonitoringSession)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsSessionAction obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AsSessionAction obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AsSessionAction _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    AsSessionAction obj = AsSessionAction.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfMonitoringSessionAction = (new GetNewIDExtender<AsSessionAction>()).GetScalar(manager, obj, isFake);
                obj.Action = 4;
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.idfMonitoringSession = new Func<AsSessionAction, long>(c => c.Parent != null ? ((AsSession)c.Parent).idfMonitoringSession : c.idfMonitoringSession)(obj);
                obj.strPersonEnteredBy = new Func<AsSessionAction, string>(c => EidssUserContext.User.FullName)(obj);
                obj.datActionDate = new Func<AsSessionAction, DateTime?>(c => DateTime.Today)(obj);
              if (EidssUserContext.Instance != null)
                if (EidssUserContext.User != null)
                {
                  if (EidssUserContext.User.EmployeeID != null)
                  {
                    long em;
                    if (long.TryParse(EidssUserContext.User.EmployeeID.ToString(), out em))
                      obj.idfPersonEnteredBy = em;
                  }
                }
            
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

            
            public AsSessionAction CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public AsSessionAction CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public AsSessionAction CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public AsSessionAction CreateActionT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("sessionId", typeof(long));
                
                return CreateAction(manager, Parent
                    , (long)pars[0]
                    );
            }
            public IObject CreateAction(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateActionT(manager, Parent, pars);
            }
            public AsSessionAction CreateAction(DbManagerProxy manager, IObject Parent
                , long sessionId
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfMonitoringSession = sessionId;
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(AsSessionAction obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AsSessionAction obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datStartDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datStartDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datActionDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datActionDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
            }
    
            public void LoadLookup_MonitoringSessionActionStatus(DbManagerProxy manager, AsSessionAction obj)
            {
                
                obj.MonitoringSessionActionStatusLookup.Clear();
                
                obj.MonitoringSessionActionStatusLookup.Add(MonitoringSessionActionStatusAccessor.CreateNewT(manager, null));
                
                obj.MonitoringSessionActionStatusLookup.AddRange(MonitoringSessionActionStatusAccessor.rftMonitoringSessionActionStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsMonitoringSessionActionStatus))
                    
                    .ToList());
                
                if (obj.idfsMonitoringSessionActionStatus != 0)
                {
                    obj.MonitoringSessionActionStatus = obj.MonitoringSessionActionStatusLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsMonitoringSessionActionStatus);
                    
                }
              
                
                LookupManager.AddObject("rftMonitoringSessionActionStatus", obj, MonitoringSessionActionStatusAccessor.GetType(), "rftMonitoringSessionActionStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_MonitoringSessionActionType(DbManagerProxy manager, AsSessionAction obj)
            {
                
                obj.MonitoringSessionActionTypeLookup.Clear();
                
                obj.MonitoringSessionActionTypeLookup.Add(MonitoringSessionActionTypeAccessor.CreateNewT(manager, null));
                
                obj.MonitoringSessionActionTypeLookup.AddRange(MonitoringSessionActionTypeAccessor.rftMonitoringSessionActionType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsMonitoringSessionActionType))
                    
                    .ToList());
                
                if (obj.idfsMonitoringSessionActionType != 0)
                {
                    obj.MonitoringSessionActionType = obj.MonitoringSessionActionTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsMonitoringSessionActionType);
                    
                }
              
                
                LookupManager.AddObject("rftMonitoringSessionActionType", obj, MonitoringSessionActionTypeAccessor.GetType(), "rftMonitoringSessionActionType_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, AsSessionAction obj)
            {
                
                LoadLookup_MonitoringSessionActionStatus(manager, obj);
                
                LoadLookup_MonitoringSessionActionType(manager, obj);
                
            }
    
            [SprocName("spAsSessionAction_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfMonitoringSessionAction")] AsSessionAction obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfMonitoringSessionAction")] AsSessionAction obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    AsSessionAction bo = obj as AsSessionAction;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as AsSessionAction, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AsSessionAction obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(AsSessionAction obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AsSessionAction obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(AsSessionAction obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<AsSessionAction>(obj, "datStartDate", c => true, 
      obj.datStartDate,
      obj.GetType(),
      false, listdatStartDate => {
    listdatStartDate.Add(
    new ChainsValidatorDateTime<AsSessionAction>(obj, "datActionDate", c => true, 
      obj.datActionDate,
      obj.GetType(),
      false, listdatActionDate => {
    
    }));
  
    }).Process();
  
                }
                catch(ValidationModelException ex)
                {
                    return ex;
                }
                
                return null;
            }
            protected bool ChainsValidate(AsSessionAction obj, bool bRethrowException)
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
                return Validate(manager, obj as AsSessionAction, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsSessionAction obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "MonitoringSessionActionType", "MonitoringSessionActionType","idfsMonitoringSessionActionType",
                false
              )).Validate(c => true, obj, obj.MonitoringSessionActionType);
            
                (new RequiredValidator( "datActionDate", "datActionDate","",
                false
              )).Validate(c => true, obj, obj.datActionDate);
            
                (new RequiredValidator( "MonitoringSessionActionStatus", "MonitoringSessionActionStatus","idfsMonitoringSessionActionStatus",
                false
              )).Validate(c => true, obj, obj.MonitoringSessionActionStatus);
            
                  
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
           
    
            private void _SetupRequired(AsSessionAction obj)
            {
            
                obj
                    .AddRequired("MonitoringSessionActionType", c => true);
                    
                obj
                    .AddRequired("datActionDate", c => true);
                    
                obj
                    .AddRequired("MonitoringSessionActionStatus", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(AsSessionAction obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AsSessionAction) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AsSessionAction) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AsSessionActionDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spAsSessionAction_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spAsSessionAction_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsSessionAction, bool>> RequiredByField = new Dictionary<string, Func<AsSessionAction, bool>>();
            public static Dictionary<string, Func<AsSessionAction, bool>> RequiredByProperty = new Dictionary<string, Func<AsSessionAction, bool>>();
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
                
                Sizes.Add(_str_strComments, 500);
                Sizes.Add(_str_strPersonEnteredBy, 400);
                if (!RequiredByField.ContainsKey("MonitoringSessionActionType")) RequiredByField.Add("MonitoringSessionActionType", c => true);
                if (!RequiredByProperty.ContainsKey("MonitoringSessionActionType")) RequiredByProperty.Add("MonitoringSessionActionType", c => true);
                
                if (!RequiredByField.ContainsKey("datActionDate")) RequiredByField.Add("datActionDate", c => true);
                if (!RequiredByProperty.ContainsKey("datActionDate")) RequiredByProperty.Add("datActionDate", c => true);
                
                if (!RequiredByField.ContainsKey("MonitoringSessionActionStatus")) RequiredByField.Add("MonitoringSessionActionStatus", c => true);
                if (!RequiredByProperty.ContainsKey("MonitoringSessionActionStatus")) RequiredByProperty.Add("MonitoringSessionActionStatus", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfMonitoringSessionAction,
                    _str_idfMonitoringSessionAction, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strMonitoringSessionActionType,
                    "idfsMonitoringSessionActionType", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datActionDate,
                    "AsSessionAction.datActionDate", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPersonEnteredBy,
                    _str_strPersonEnteredBy, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strComments,
                    "strComment", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strMonitoringSessionActionStatus,
                    "idfsMonitoringSessionActionStatus", null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "CreateAction",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateAction(manager, c, pars)),
                        
                    null,
                    
                    null,
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
                    (manager, c, pars) => ((AsSessionAction)c).MarkToDelete(),
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
	