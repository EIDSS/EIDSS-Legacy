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
    public abstract partial class SecurityEventLogListItem : 
        EditableObject<SecurityEventLogListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfSecurityAudit), NonUpdatable, PrimaryKey]
        public abstract Int64 idfSecurityAudit { get; set; }
                
        [LocalizedDisplayName(_str_idfsAction)]
        [MapField(_str_idfsAction)]
        public abstract Int64 idfsAction { get; set; }
        #if MONO
        protected Int64 idfsAction_Original { get { return idfsAction; } }
        protected Int64 idfsAction_Previous { get { return idfsAction; } }
        #else
        protected Int64 idfsAction_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAction).OriginalValue; } }
        protected Int64 idfsAction_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAction).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strActionDefaultName)]
        [MapField(_str_strActionDefaultName)]
        public abstract String strActionDefaultName { get; set; }
        #if MONO
        protected String strActionDefaultName_Original { get { return strActionDefaultName; } }
        protected String strActionDefaultName_Previous { get { return strActionDefaultName; } }
        #else
        protected String strActionDefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._strActionDefaultName).OriginalValue; } }
        protected String strActionDefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strActionDefaultName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strActionNationalName)]
        [MapField(_str_strActionNationalName)]
        public abstract String strActionNationalName { get; set; }
        #if MONO
        protected String strActionNationalName_Original { get { return strActionNationalName; } }
        protected String strActionNationalName_Previous { get { return strActionNationalName; } }
        #else
        protected String strActionNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._strActionNationalName).OriginalValue; } }
        protected String strActionNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strActionNationalName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsResult)]
        [MapField(_str_idfsResult)]
        public abstract Int64 idfsResult { get; set; }
        #if MONO
        protected Int64 idfsResult_Original { get { return idfsResult; } }
        protected Int64 idfsResult_Previous { get { return idfsResult; } }
        #else
        protected Int64 idfsResult_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsResult).OriginalValue; } }
        protected Int64 idfsResult_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsResult).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strResultDefaultName)]
        [MapField(_str_strResultDefaultName)]
        public abstract String strResultDefaultName { get; set; }
        #if MONO
        protected String strResultDefaultName_Original { get { return strResultDefaultName; } }
        protected String strResultDefaultName_Previous { get { return strResultDefaultName; } }
        #else
        protected String strResultDefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._strResultDefaultName).OriginalValue; } }
        protected String strResultDefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strResultDefaultName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strResultNationalName)]
        [MapField(_str_strResultNationalName)]
        public abstract String strResultNationalName { get; set; }
        #if MONO
        protected String strResultNationalName_Original { get { return strResultNationalName; } }
        protected String strResultNationalName_Previous { get { return strResultNationalName; } }
        #else
        protected String strResultNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._strResultNationalName).OriginalValue; } }
        protected String strResultNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strResultNationalName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsProcessType)]
        [MapField(_str_idfsProcessType)]
        public abstract Int64 idfsProcessType { get; set; }
        #if MONO
        protected Int64 idfsProcessType_Original { get { return idfsProcessType; } }
        protected Int64 idfsProcessType_Previous { get { return idfsProcessType; } }
        #else
        protected Int64 idfsProcessType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsProcessType).OriginalValue; } }
        protected Int64 idfsProcessType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsProcessType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strProcessTypeDefaultName)]
        [MapField(_str_strProcessTypeDefaultName)]
        public abstract String strProcessTypeDefaultName { get; set; }
        #if MONO
        protected String strProcessTypeDefaultName_Original { get { return strProcessTypeDefaultName; } }
        protected String strProcessTypeDefaultName_Previous { get { return strProcessTypeDefaultName; } }
        #else
        protected String strProcessTypeDefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._strProcessTypeDefaultName).OriginalValue; } }
        protected String strProcessTypeDefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strProcessTypeDefaultName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strProcessTypeNationalName)]
        [MapField(_str_strProcessTypeNationalName)]
        public abstract String strProcessTypeNationalName { get; set; }
        #if MONO
        protected String strProcessTypeNationalName_Original { get { return strProcessTypeNationalName; } }
        protected String strProcessTypeNationalName_Previous { get { return strProcessTypeNationalName; } }
        #else
        protected String strProcessTypeNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._strProcessTypeNationalName).OriginalValue; } }
        protected String strProcessTypeNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strProcessTypeNationalName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfAffectedObjectType)]
        [MapField(_str_idfAffectedObjectType)]
        public abstract Int64 idfAffectedObjectType { get; set; }
        #if MONO
        protected Int64 idfAffectedObjectType_Original { get { return idfAffectedObjectType; } }
        protected Int64 idfAffectedObjectType_Previous { get { return idfAffectedObjectType; } }
        #else
        protected Int64 idfAffectedObjectType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfAffectedObjectType).OriginalValue; } }
        protected Int64 idfAffectedObjectType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfAffectedObjectType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfObjectID)]
        [MapField(_str_idfObjectID)]
        public abstract Int64 idfObjectID { get; set; }
        #if MONO
        protected Int64 idfObjectID_Original { get { return idfObjectID; } }
        protected Int64 idfObjectID_Previous { get { return idfObjectID; } }
        #else
        protected Int64 idfObjectID_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfObjectID).OriginalValue; } }
        protected Int64 idfObjectID_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfObjectID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfUserID)]
        [MapField(_str_idfUserID)]
        public abstract Int64? idfUserID { get; set; }
        #if MONO
        protected Int64? idfUserID_Original { get { return idfUserID; } }
        protected Int64? idfUserID_Previous { get { return idfUserID; } }
        #else
        protected Int64? idfUserID_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfUserID).OriginalValue; } }
        protected Int64? idfUserID_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfUserID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strAccountName)]
        [MapField(_str_strAccountName)]
        public abstract String strAccountName { get; set; }
        #if MONO
        protected String strAccountName_Original { get { return strAccountName; } }
        protected String strAccountName_Previous { get { return strAccountName; } }
        #else
        protected String strAccountName_Original { get { return ((EditableValue<String>)((dynamic)this)._strAccountName).OriginalValue; } }
        protected String strAccountName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAccountName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfDataAuditEvent)]
        [MapField(_str_idfDataAuditEvent)]
        public abstract Int64? idfDataAuditEvent { get; set; }
        #if MONO
        protected Int64? idfDataAuditEvent_Original { get { return idfDataAuditEvent; } }
        protected Int64? idfDataAuditEvent_Previous { get { return idfDataAuditEvent; } }
        #else
        protected Int64? idfDataAuditEvent_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDataAuditEvent).OriginalValue; } }
        protected Int64? idfDataAuditEvent_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDataAuditEvent).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datActionDate)]
        [MapField(_str_datActionDate)]
        public abstract DateTime? datActionDate { get; set; }
        #if MONO
        protected DateTime? datActionDate_Original { get { return datActionDate; } }
        protected DateTime? datActionDate_Previous { get { return datActionDate; } }
        #else
        protected DateTime? datActionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datActionDate).OriginalValue; } }
        protected DateTime? datActionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datActionDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strErrorText)]
        [MapField(_str_strErrorText)]
        public abstract String strErrorText { get; set; }
        #if MONO
        protected String strErrorText_Original { get { return strErrorText; } }
        protected String strErrorText_Previous { get { return strErrorText; } }
        #else
        protected String strErrorText_Original { get { return ((EditableValue<String>)((dynamic)this)._strErrorText).OriginalValue; } }
        protected String strErrorText_Previous { get { return ((EditableValue<String>)((dynamic)this)._strErrorText).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strProcessID)]
        [MapField(_str_strProcessID)]
        public abstract String strProcessID { get; set; }
        #if MONO
        protected String strProcessID_Original { get { return strProcessID; } }
        protected String strProcessID_Previous { get { return strProcessID; } }
        #else
        protected String strProcessID_Original { get { return ((EditableValue<String>)((dynamic)this)._strProcessID).OriginalValue; } }
        protected String strProcessID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strProcessID).PreviousValue; } }
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
            internal Func<SecurityEventLogListItem, object> _get_func;
            internal Action<SecurityEventLogListItem, string> _set_func;
            internal Action<SecurityEventLogListItem, SecurityEventLogListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfSecurityAudit = "idfSecurityAudit";
        internal const string _str_idfsAction = "idfsAction";
        internal const string _str_strActionDefaultName = "strActionDefaultName";
        internal const string _str_strActionNationalName = "strActionNationalName";
        internal const string _str_idfsResult = "idfsResult";
        internal const string _str_strResultDefaultName = "strResultDefaultName";
        internal const string _str_strResultNationalName = "strResultNationalName";
        internal const string _str_idfsProcessType = "idfsProcessType";
        internal const string _str_strProcessTypeDefaultName = "strProcessTypeDefaultName";
        internal const string _str_strProcessTypeNationalName = "strProcessTypeNationalName";
        internal const string _str_idfAffectedObjectType = "idfAffectedObjectType";
        internal const string _str_idfObjectID = "idfObjectID";
        internal const string _str_idfUserID = "idfUserID";
        internal const string _str_strAccountName = "strAccountName";
        internal const string _str_idfDataAuditEvent = "idfDataAuditEvent";
        internal const string _str_datActionDate = "datActionDate";
        internal const string _str_strErrorText = "strErrorText";
        internal const string _str_strProcessID = "strProcessID";
        internal const string _str_strDescription = "strDescription";
        internal const string _str_SecurityAction = "SecurityAction";
        internal const string _str_SecurityProcessType = "SecurityProcessType";
        internal const string _str_SecurityResult = "SecurityResult";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfSecurityAudit, _type = "Int64",
              _get_func = o => o.idfSecurityAudit,
              _set_func = (o, val) => { o.idfSecurityAudit = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSecurityAudit != c.idfSecurityAudit || o.IsRIRPropChanged(_str_idfSecurityAudit, c)) 
                  m.Add(_str_idfSecurityAudit, o.ObjectIdent + _str_idfSecurityAudit, "Int64", o.idfSecurityAudit == null ? "" : o.idfSecurityAudit.ToString(), o.IsReadOnly(_str_idfSecurityAudit), o.IsInvisible(_str_idfSecurityAudit), o.IsRequired(_str_idfSecurityAudit)); }
              }, 
        
            new field_info {
              _name = _str_idfsAction, _type = "Int64",
              _get_func = o => o.idfsAction,
              _set_func = (o, val) => { o.idfsAction = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsAction != c.idfsAction || o.IsRIRPropChanged(_str_idfsAction, c)) 
                  m.Add(_str_idfsAction, o.ObjectIdent + _str_idfsAction, "Int64", o.idfsAction == null ? "" : o.idfsAction.ToString(), o.IsReadOnly(_str_idfsAction), o.IsInvisible(_str_idfsAction), o.IsRequired(_str_idfsAction)); }
              }, 
        
            new field_info {
              _name = _str_strActionDefaultName, _type = "String",
              _get_func = o => o.strActionDefaultName,
              _set_func = (o, val) => { o.strActionDefaultName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strActionDefaultName != c.strActionDefaultName || o.IsRIRPropChanged(_str_strActionDefaultName, c)) 
                  m.Add(_str_strActionDefaultName, o.ObjectIdent + _str_strActionDefaultName, "String", o.strActionDefaultName == null ? "" : o.strActionDefaultName.ToString(), o.IsReadOnly(_str_strActionDefaultName), o.IsInvisible(_str_strActionDefaultName), o.IsRequired(_str_strActionDefaultName)); }
              }, 
        
            new field_info {
              _name = _str_strActionNationalName, _type = "String",
              _get_func = o => o.strActionNationalName,
              _set_func = (o, val) => { o.strActionNationalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strActionNationalName != c.strActionNationalName || o.IsRIRPropChanged(_str_strActionNationalName, c)) 
                  m.Add(_str_strActionNationalName, o.ObjectIdent + _str_strActionNationalName, "String", o.strActionNationalName == null ? "" : o.strActionNationalName.ToString(), o.IsReadOnly(_str_strActionNationalName), o.IsInvisible(_str_strActionNationalName), o.IsRequired(_str_strActionNationalName)); }
              }, 
        
            new field_info {
              _name = _str_idfsResult, _type = "Int64",
              _get_func = o => o.idfsResult,
              _set_func = (o, val) => { o.idfsResult = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsResult != c.idfsResult || o.IsRIRPropChanged(_str_idfsResult, c)) 
                  m.Add(_str_idfsResult, o.ObjectIdent + _str_idfsResult, "Int64", o.idfsResult == null ? "" : o.idfsResult.ToString(), o.IsReadOnly(_str_idfsResult), o.IsInvisible(_str_idfsResult), o.IsRequired(_str_idfsResult)); }
              }, 
        
            new field_info {
              _name = _str_strResultDefaultName, _type = "String",
              _get_func = o => o.strResultDefaultName,
              _set_func = (o, val) => { o.strResultDefaultName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strResultDefaultName != c.strResultDefaultName || o.IsRIRPropChanged(_str_strResultDefaultName, c)) 
                  m.Add(_str_strResultDefaultName, o.ObjectIdent + _str_strResultDefaultName, "String", o.strResultDefaultName == null ? "" : o.strResultDefaultName.ToString(), o.IsReadOnly(_str_strResultDefaultName), o.IsInvisible(_str_strResultDefaultName), o.IsRequired(_str_strResultDefaultName)); }
              }, 
        
            new field_info {
              _name = _str_strResultNationalName, _type = "String",
              _get_func = o => o.strResultNationalName,
              _set_func = (o, val) => { o.strResultNationalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strResultNationalName != c.strResultNationalName || o.IsRIRPropChanged(_str_strResultNationalName, c)) 
                  m.Add(_str_strResultNationalName, o.ObjectIdent + _str_strResultNationalName, "String", o.strResultNationalName == null ? "" : o.strResultNationalName.ToString(), o.IsReadOnly(_str_strResultNationalName), o.IsInvisible(_str_strResultNationalName), o.IsRequired(_str_strResultNationalName)); }
              }, 
        
            new field_info {
              _name = _str_idfsProcessType, _type = "Int64",
              _get_func = o => o.idfsProcessType,
              _set_func = (o, val) => { o.idfsProcessType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsProcessType != c.idfsProcessType || o.IsRIRPropChanged(_str_idfsProcessType, c)) 
                  m.Add(_str_idfsProcessType, o.ObjectIdent + _str_idfsProcessType, "Int64", o.idfsProcessType == null ? "" : o.idfsProcessType.ToString(), o.IsReadOnly(_str_idfsProcessType), o.IsInvisible(_str_idfsProcessType), o.IsRequired(_str_idfsProcessType)); }
              }, 
        
            new field_info {
              _name = _str_strProcessTypeDefaultName, _type = "String",
              _get_func = o => o.strProcessTypeDefaultName,
              _set_func = (o, val) => { o.strProcessTypeDefaultName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strProcessTypeDefaultName != c.strProcessTypeDefaultName || o.IsRIRPropChanged(_str_strProcessTypeDefaultName, c)) 
                  m.Add(_str_strProcessTypeDefaultName, o.ObjectIdent + _str_strProcessTypeDefaultName, "String", o.strProcessTypeDefaultName == null ? "" : o.strProcessTypeDefaultName.ToString(), o.IsReadOnly(_str_strProcessTypeDefaultName), o.IsInvisible(_str_strProcessTypeDefaultName), o.IsRequired(_str_strProcessTypeDefaultName)); }
              }, 
        
            new field_info {
              _name = _str_strProcessTypeNationalName, _type = "String",
              _get_func = o => o.strProcessTypeNationalName,
              _set_func = (o, val) => { o.strProcessTypeNationalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strProcessTypeNationalName != c.strProcessTypeNationalName || o.IsRIRPropChanged(_str_strProcessTypeNationalName, c)) 
                  m.Add(_str_strProcessTypeNationalName, o.ObjectIdent + _str_strProcessTypeNationalName, "String", o.strProcessTypeNationalName == null ? "" : o.strProcessTypeNationalName.ToString(), o.IsReadOnly(_str_strProcessTypeNationalName), o.IsInvisible(_str_strProcessTypeNationalName), o.IsRequired(_str_strProcessTypeNationalName)); }
              }, 
        
            new field_info {
              _name = _str_idfAffectedObjectType, _type = "Int64",
              _get_func = o => o.idfAffectedObjectType,
              _set_func = (o, val) => { o.idfAffectedObjectType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfAffectedObjectType != c.idfAffectedObjectType || o.IsRIRPropChanged(_str_idfAffectedObjectType, c)) 
                  m.Add(_str_idfAffectedObjectType, o.ObjectIdent + _str_idfAffectedObjectType, "Int64", o.idfAffectedObjectType == null ? "" : o.idfAffectedObjectType.ToString(), o.IsReadOnly(_str_idfAffectedObjectType), o.IsInvisible(_str_idfAffectedObjectType), o.IsRequired(_str_idfAffectedObjectType)); }
              }, 
        
            new field_info {
              _name = _str_idfObjectID, _type = "Int64",
              _get_func = o => o.idfObjectID,
              _set_func = (o, val) => { o.idfObjectID = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfObjectID != c.idfObjectID || o.IsRIRPropChanged(_str_idfObjectID, c)) 
                  m.Add(_str_idfObjectID, o.ObjectIdent + _str_idfObjectID, "Int64", o.idfObjectID == null ? "" : o.idfObjectID.ToString(), o.IsReadOnly(_str_idfObjectID), o.IsInvisible(_str_idfObjectID), o.IsRequired(_str_idfObjectID)); }
              }, 
        
            new field_info {
              _name = _str_idfUserID, _type = "Int64?",
              _get_func = o => o.idfUserID,
              _set_func = (o, val) => { o.idfUserID = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfUserID != c.idfUserID || o.IsRIRPropChanged(_str_idfUserID, c)) 
                  m.Add(_str_idfUserID, o.ObjectIdent + _str_idfUserID, "Int64?", o.idfUserID == null ? "" : o.idfUserID.ToString(), o.IsReadOnly(_str_idfUserID), o.IsInvisible(_str_idfUserID), o.IsRequired(_str_idfUserID)); }
              }, 
        
            new field_info {
              _name = _str_strAccountName, _type = "String",
              _get_func = o => o.strAccountName,
              _set_func = (o, val) => { o.strAccountName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strAccountName != c.strAccountName || o.IsRIRPropChanged(_str_strAccountName, c)) 
                  m.Add(_str_strAccountName, o.ObjectIdent + _str_strAccountName, "String", o.strAccountName == null ? "" : o.strAccountName.ToString(), o.IsReadOnly(_str_strAccountName), o.IsInvisible(_str_strAccountName), o.IsRequired(_str_strAccountName)); }
              }, 
        
            new field_info {
              _name = _str_idfDataAuditEvent, _type = "Int64?",
              _get_func = o => o.idfDataAuditEvent,
              _set_func = (o, val) => { o.idfDataAuditEvent = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfDataAuditEvent != c.idfDataAuditEvent || o.IsRIRPropChanged(_str_idfDataAuditEvent, c)) 
                  m.Add(_str_idfDataAuditEvent, o.ObjectIdent + _str_idfDataAuditEvent, "Int64?", o.idfDataAuditEvent == null ? "" : o.idfDataAuditEvent.ToString(), o.IsReadOnly(_str_idfDataAuditEvent), o.IsInvisible(_str_idfDataAuditEvent), o.IsRequired(_str_idfDataAuditEvent)); }
              }, 
        
            new field_info {
              _name = _str_datActionDate, _type = "DateTime?",
              _get_func = o => o.datActionDate,
              _set_func = (o, val) => { o.datActionDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datActionDate != c.datActionDate || o.IsRIRPropChanged(_str_datActionDate, c)) 
                  m.Add(_str_datActionDate, o.ObjectIdent + _str_datActionDate, "DateTime?", o.datActionDate == null ? "" : o.datActionDate.ToString(), o.IsReadOnly(_str_datActionDate), o.IsInvisible(_str_datActionDate), o.IsRequired(_str_datActionDate)); }
              }, 
        
            new field_info {
              _name = _str_strErrorText, _type = "String",
              _get_func = o => o.strErrorText,
              _set_func = (o, val) => { o.strErrorText = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strErrorText != c.strErrorText || o.IsRIRPropChanged(_str_strErrorText, c)) 
                  m.Add(_str_strErrorText, o.ObjectIdent + _str_strErrorText, "String", o.strErrorText == null ? "" : o.strErrorText.ToString(), o.IsReadOnly(_str_strErrorText), o.IsInvisible(_str_strErrorText), o.IsRequired(_str_strErrorText)); }
              }, 
        
            new field_info {
              _name = _str_strProcessID, _type = "String",
              _get_func = o => o.strProcessID,
              _set_func = (o, val) => { o.strProcessID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strProcessID != c.strProcessID || o.IsRIRPropChanged(_str_strProcessID, c)) 
                  m.Add(_str_strProcessID, o.ObjectIdent + _str_strProcessID, "String", o.strProcessID == null ? "" : o.strProcessID.ToString(), o.IsReadOnly(_str_strProcessID), o.IsInvisible(_str_strProcessID), o.IsRequired(_str_strProcessID)); }
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
              _name = _str_SecurityAction, _type = "Lookup",
              _get_func = o => { if (o.SecurityAction == null) return null; return o.SecurityAction.idfsBaseReference; },
              _set_func = (o, val) => { o.SecurityAction = o.SecurityActionLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAction != c.idfsAction || o.IsRIRPropChanged(_str_SecurityAction, c)) 
                  m.Add(_str_SecurityAction, o.ObjectIdent + _str_SecurityAction, "Lookup", o.idfsAction == null ? "" : o.idfsAction.ToString(), o.IsReadOnly(_str_SecurityAction), o.IsInvisible(_str_SecurityAction), o.IsRequired(_str_SecurityAction)); }
              }, 
        
            new field_info {
              _name = _str_SecurityProcessType, _type = "Lookup",
              _get_func = o => { if (o.SecurityProcessType == null) return null; return o.SecurityProcessType.idfsBaseReference; },
              _set_func = (o, val) => { o.SecurityProcessType = o.SecurityProcessTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsProcessType != c.idfsProcessType || o.IsRIRPropChanged(_str_SecurityProcessType, c)) 
                  m.Add(_str_SecurityProcessType, o.ObjectIdent + _str_SecurityProcessType, "Lookup", o.idfsProcessType == null ? "" : o.idfsProcessType.ToString(), o.IsReadOnly(_str_SecurityProcessType), o.IsInvisible(_str_SecurityProcessType), o.IsRequired(_str_SecurityProcessType)); }
              }, 
        
            new field_info {
              _name = _str_SecurityResult, _type = "Lookup",
              _get_func = o => { if (o.SecurityResult == null) return null; return o.SecurityResult.idfsBaseReference; },
              _set_func = (o, val) => { o.SecurityResult = o.SecurityResultLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsResult != c.idfsResult || o.IsRIRPropChanged(_str_SecurityResult, c)) 
                  m.Add(_str_SecurityResult, o.ObjectIdent + _str_SecurityResult, "Lookup", o.idfsResult == null ? "" : o.idfsResult.ToString(), o.IsReadOnly(_str_SecurityResult), o.IsInvisible(_str_SecurityResult), o.IsRequired(_str_SecurityResult)); }
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
            SecurityEventLogListItem obj = (SecurityEventLogListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAction)]
        public BaseReference SecurityAction
        {
            get { return _SecurityAction == null ? null : ((long)_SecurityAction.Key == 0 ? null : _SecurityAction); }
            set 
            { 
                _SecurityAction = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAction = _SecurityAction == null 
                    ? new Int64()
                    : _SecurityAction.idfsBaseReference; 
                OnPropertyChanged(_str_SecurityAction); 
            }
        }
        private BaseReference _SecurityAction;

        
        public BaseReferenceList SecurityActionLookup
        {
            get { return _SecurityActionLookup; }
        }
        private BaseReferenceList _SecurityActionLookup = new BaseReferenceList("rftSecurityAuditAction");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsProcessType)]
        public BaseReference SecurityProcessType
        {
            get { return _SecurityProcessType == null ? null : ((long)_SecurityProcessType.Key == 0 ? null : _SecurityProcessType); }
            set 
            { 
                _SecurityProcessType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsProcessType = _SecurityProcessType == null 
                    ? new Int64()
                    : _SecurityProcessType.idfsBaseReference; 
                OnPropertyChanged(_str_SecurityProcessType); 
            }
        }
        private BaseReference _SecurityProcessType;

        
        public BaseReferenceList SecurityProcessTypeLookup
        {
            get { return _SecurityProcessTypeLookup; }
        }
        private BaseReferenceList _SecurityProcessTypeLookup = new BaseReferenceList("rftSecurityAuditProcessType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsResult)]
        public BaseReference SecurityResult
        {
            get { return _SecurityResult == null ? null : ((long)_SecurityResult.Key == 0 ? null : _SecurityResult); }
            set 
            { 
                _SecurityResult = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsResult = _SecurityResult == null 
                    ? new Int64()
                    : _SecurityResult.idfsBaseReference; 
                OnPropertyChanged(_str_SecurityResult); 
            }
        }
        private BaseReference _SecurityResult;

        
        public BaseReferenceList SecurityResultLookup
        {
            get { return _SecurityResultLookup; }
        }
        private BaseReferenceList _SecurityResultLookup = new BaseReferenceList("rftSecurityAuditResult");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_SecurityAction:
                    return new BvSelectList(SecurityActionLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SecurityAction, _str_idfsAction);
            
                case _str_SecurityProcessType:
                    return new BvSelectList(SecurityProcessTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SecurityProcessType, _str_idfsProcessType);
            
                case _str_SecurityResult:
                    return new BvSelectList(SecurityResultLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SecurityResult, _str_idfsResult);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "SecurityEventLogListItem";

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
            var ret = base.Clone() as SecurityEventLogListItem;
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
            var ret = base.Clone() as SecurityEventLogListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public SecurityEventLogListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as SecurityEventLogListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfSecurityAudit; } }
        public string KeyName { get { return "idfSecurityAudit"; } }
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
        
            var _prev_idfsAction_SecurityAction = idfsAction;
            var _prev_idfsProcessType_SecurityProcessType = idfsProcessType;
            var _prev_idfsResult_SecurityResult = idfsResult;
            base.RejectChanges();
        
            if (_prev_idfsAction_SecurityAction != idfsAction)
            {
                _SecurityAction = _SecurityActionLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAction);
            }
            if (_prev_idfsProcessType_SecurityProcessType != idfsProcessType)
            {
                _SecurityProcessType = _SecurityProcessTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsProcessType);
            }
            if (_prev_idfsResult_SecurityResult != idfsResult)
            {
                _SecurityResult = _SecurityResultLookup.FirstOrDefault(c => c.idfsBaseReference == idfsResult);
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

      private bool IsRIRPropChanged(string fld, SecurityEventLogListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public SecurityEventLogListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SecurityEventLogListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(SecurityEventLogListItem_PropertyChanged);
        }
        private void SecurityEventLogListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as SecurityEventLogListItem).Changed(e.PropertyName);
            
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
            SecurityEventLogListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            SecurityEventLogListItem obj = this;
            
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


        public Dictionary<string, Func<SecurityEventLogListItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<SecurityEventLogListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<SecurityEventLogListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<SecurityEventLogListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<SecurityEventLogListItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<SecurityEventLogListItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~SecurityEventLogListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftSecurityAuditAction", this);
                
                LookupManager.RemoveObject("rftSecurityAuditProcessType", this);
                
                LookupManager.RemoveObject("rftSecurityAuditResult", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftSecurityAuditAction")
                _getAccessor().LoadLookup_SecurityAction(manager, this);
            
            if (lookup_object == "rftSecurityAuditProcessType")
                _getAccessor().LoadLookup_SecurityProcessType(manager, this);
            
            if (lookup_object == "rftSecurityAuditResult")
                _getAccessor().LoadLookup_SecurityResult(manager, this);
            
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
        public class SecurityEventLogListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfSecurityAudit { get; set; }
        
            public DateTime? datActionDate { get; set; }
        
            public String strActionNationalName { get; set; }
        
            public String strResultNationalName { get; set; }
        
            public String strProcessTypeNationalName { get; set; }
        
            public Int64 idfObjectID { get; set; }
        
            public String strAccountName { get; set; }
        
            public String strErrorText { get; set; }
        
            public String strProcessID { get; set; }
        
            public String strDescription { get; set; }
        
        }
        public partial class SecurityEventLogListItemGridModelList : List<SecurityEventLogListItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public SecurityEventLogListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<SecurityEventLogListItem>, errMes);
            }
            public SecurityEventLogListItemGridModelList(long key, IEnumerable<SecurityEventLogListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<SecurityEventLogListItem> items);
            private void LoadGridModelList(long key, IEnumerable<SecurityEventLogListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_datActionDate,_str_strActionNationalName,_str_strResultNationalName,_str_strProcessTypeNationalName,_str_idfObjectID,_str_strAccountName,_str_strErrorText,_str_strProcessID,_str_strDescription};
                    
                Hiddens = new List<string> {_str_idfSecurityAudit};
                Keys = new List<string> {_str_idfSecurityAudit};
                Labels = new Dictionary<string, string> {{_str_datActionDate, _str_datActionDate},{_str_strActionNationalName, _str_strActionNationalName},{_str_strResultNationalName, _str_strResultNationalName},{_str_strProcessTypeNationalName, _str_strProcessTypeNationalName},{_str_idfObjectID, _str_idfObjectID},{_str_strAccountName, _str_strAccountName},{_str_strErrorText, _str_strErrorText},{_str_strProcessID, _str_strProcessID},{_str_strDescription, _str_strDescription}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<SecurityEventLogListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new SecurityEventLogListItemGridModel()
                {
                    ItemKey=c.idfSecurityAudit,datActionDate=c.datActionDate,strActionNationalName=c.strActionNationalName,strResultNationalName=c.strResultNationalName,strProcessTypeNationalName=c.strProcessTypeNationalName,idfObjectID=c.idfObjectID,strAccountName=c.strAccountName,strErrorText=c.strErrorText,strProcessID=c.strProcessID,strDescription=c.strDescription
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
        : DataAccessor<SecurityEventLogListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectList
                    
            , IObjectPost
                    
        {
            private delegate void on_action(SecurityEventLogListItem obj);
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
            private BaseReference.Accessor SecurityActionAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SecurityProcessTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SecurityResultAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<SecurityEventLogListItem> SelectListT(DbManagerProxy manager
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
            
            private List<SecurityEventLogListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_SecurityEventLog_SelectList.* from dbo.fn_SecurityEventLog_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfSecurityAudit"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfSecurityAudit"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfSecurityAudit") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_SecurityEventLog_SelectList.idfSecurityAudit,0) {0} @idfSecurityAudit_{1}", filters.Operation("idfSecurityAudit", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsAction"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsAction"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsAction") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_SecurityEventLog_SelectList.idfsAction,0) {0} @idfsAction_{1}", filters.Operation("idfsAction", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strActionDefaultName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strActionDefaultName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strActionDefaultName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SecurityEventLog_SelectList.strActionDefaultName {0} @strActionDefaultName_{1}", filters.Operation("strActionDefaultName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strActionNationalName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strActionNationalName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strActionNationalName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SecurityEventLog_SelectList.strActionNationalName {0} @strActionNationalName_{1}", filters.Operation("strActionNationalName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsResult"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsResult"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsResult") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_SecurityEventLog_SelectList.idfsResult,0) {0} @idfsResult_{1}", filters.Operation("idfsResult", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strResultDefaultName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strResultDefaultName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strResultDefaultName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SecurityEventLog_SelectList.strResultDefaultName {0} @strResultDefaultName_{1}", filters.Operation("strResultDefaultName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strResultNationalName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strResultNationalName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strResultNationalName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SecurityEventLog_SelectList.strResultNationalName {0} @strResultNationalName_{1}", filters.Operation("strResultNationalName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsProcessType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsProcessType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsProcessType") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_SecurityEventLog_SelectList.idfsProcessType,0) {0} @idfsProcessType_{1}", filters.Operation("idfsProcessType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strProcessTypeDefaultName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strProcessTypeDefaultName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strProcessTypeDefaultName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SecurityEventLog_SelectList.strProcessTypeDefaultName {0} @strProcessTypeDefaultName_{1}", filters.Operation("strProcessTypeDefaultName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strProcessTypeNationalName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strProcessTypeNationalName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strProcessTypeNationalName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SecurityEventLog_SelectList.strProcessTypeNationalName {0} @strProcessTypeNationalName_{1}", filters.Operation("strProcessTypeNationalName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfAffectedObjectType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfAffectedObjectType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfAffectedObjectType") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_SecurityEventLog_SelectList.idfAffectedObjectType,0) {0} @idfAffectedObjectType_{1}", filters.Operation("idfAffectedObjectType", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_SecurityEventLog_SelectList.idfObjectID,0) {0} @idfObjectID_{1}", filters.Operation("idfObjectID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfUserID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfUserID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfUserID") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_SecurityEventLog_SelectList.idfUserID,0) {0} @idfUserID_{1}", filters.Operation("idfUserID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strAccountName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strAccountName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strAccountName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SecurityEventLog_SelectList.strAccountName {0} @strAccountName_{1}", filters.Operation("strAccountName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfDataAuditEvent"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfDataAuditEvent"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfDataAuditEvent") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_SecurityEventLog_SelectList.idfDataAuditEvent,0) {0} @idfDataAuditEvent_{1}", filters.Operation("idfDataAuditEvent", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datActionDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datActionDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datActionDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_SecurityEventLog_SelectList.datActionDate, 112) {0} CONVERT(NVARCHAR(8), @datActionDate_{1}, 112)", filters.Operation("datActionDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strErrorText"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strErrorText"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strErrorText") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SecurityEventLog_SelectList.strErrorText {0} @strErrorText_{1}", filters.Operation("strErrorText", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strProcessID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strProcessID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strProcessID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SecurityEventLog_SelectList.strProcessID {0} @strProcessID_{1}", filters.Operation("strProcessID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strDescription"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strDescription"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strDescription") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SecurityEventLog_SelectList.strDescription {0} @strDescription_{1}", filters.Operation("strDescription", i), i);
                            
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
                    
                    if (filters.Contains("idfSecurityAudit"))
                        for (int i = 0; i < filters.Count("idfSecurityAudit"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfSecurityAudit_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfSecurityAudit", i), filters.Value("idfSecurityAudit", i))));
                      
                    if (filters.Contains("idfsAction"))
                        for (int i = 0; i < filters.Count("idfsAction"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsAction_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsAction", i), filters.Value("idfsAction", i))));
                      
                    if (filters.Contains("strActionDefaultName"))
                        for (int i = 0; i < filters.Count("strActionDefaultName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strActionDefaultName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strActionDefaultName", i), filters.Value("strActionDefaultName", i))));
                      
                    if (filters.Contains("strActionNationalName"))
                        for (int i = 0; i < filters.Count("strActionNationalName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strActionNationalName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strActionNationalName", i), filters.Value("strActionNationalName", i))));
                      
                    if (filters.Contains("idfsResult"))
                        for (int i = 0; i < filters.Count("idfsResult"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsResult_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsResult", i), filters.Value("idfsResult", i))));
                      
                    if (filters.Contains("strResultDefaultName"))
                        for (int i = 0; i < filters.Count("strResultDefaultName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strResultDefaultName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strResultDefaultName", i), filters.Value("strResultDefaultName", i))));
                      
                    if (filters.Contains("strResultNationalName"))
                        for (int i = 0; i < filters.Count("strResultNationalName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strResultNationalName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strResultNationalName", i), filters.Value("strResultNationalName", i))));
                      
                    if (filters.Contains("idfsProcessType"))
                        for (int i = 0; i < filters.Count("idfsProcessType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsProcessType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsProcessType", i), filters.Value("idfsProcessType", i))));
                      
                    if (filters.Contains("strProcessTypeDefaultName"))
                        for (int i = 0; i < filters.Count("strProcessTypeDefaultName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strProcessTypeDefaultName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strProcessTypeDefaultName", i), filters.Value("strProcessTypeDefaultName", i))));
                      
                    if (filters.Contains("strProcessTypeNationalName"))
                        for (int i = 0; i < filters.Count("strProcessTypeNationalName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strProcessTypeNationalName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strProcessTypeNationalName", i), filters.Value("strProcessTypeNationalName", i))));
                      
                    if (filters.Contains("idfAffectedObjectType"))
                        for (int i = 0; i < filters.Count("idfAffectedObjectType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfAffectedObjectType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfAffectedObjectType", i), filters.Value("idfAffectedObjectType", i))));
                      
                    if (filters.Contains("idfObjectID"))
                        for (int i = 0; i < filters.Count("idfObjectID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfObjectID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfObjectID", i), filters.Value("idfObjectID", i))));
                      
                    if (filters.Contains("idfUserID"))
                        for (int i = 0; i < filters.Count("idfUserID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfUserID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfUserID", i), filters.Value("idfUserID", i))));
                      
                    if (filters.Contains("strAccountName"))
                        for (int i = 0; i < filters.Count("strAccountName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strAccountName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strAccountName", i), filters.Value("strAccountName", i))));
                      
                    if (filters.Contains("idfDataAuditEvent"))
                        for (int i = 0; i < filters.Count("idfDataAuditEvent"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfDataAuditEvent_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfDataAuditEvent", i), filters.Value("idfDataAuditEvent", i))));
                      
                    if (filters.Contains("datActionDate"))
                        for (int i = 0; i < filters.Count("datActionDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datActionDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datActionDate", i), filters.Value("datActionDate", i))));
                      
                    if (filters.Contains("strErrorText"))
                        for (int i = 0; i < filters.Count("strErrorText"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strErrorText_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strErrorText", i), filters.Value("strErrorText", i))));
                      
                    if (filters.Contains("strProcessID"))
                        for (int i = 0; i < filters.Count("strProcessID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strProcessID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strProcessID", i), filters.Value("strProcessID", i))));
                      
                    if (filters.Contains("strDescription"))
                        for (int i = 0; i < filters.Count("strDescription"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strDescription_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strDescription", i), filters.Value("strDescription", i))));
                      
                    List<SecurityEventLogListItem> objs = manager.ExecuteList<SecurityEventLogListItem>();
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
        
            [SprocName("spSecurityEventLog_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, SecurityEventLogListItem obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, SecurityEventLogListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private SecurityEventLogListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    SecurityEventLogListItem obj = SecurityEventLogListItem.CreateInstance();
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

            
            public SecurityEventLogListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public SecurityEventLogListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(SecurityEventLogListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(SecurityEventLogListItem obj)
            {
                
            }
    
            public void LoadLookup_SecurityAction(DbManagerProxy manager, SecurityEventLogListItem obj)
            {
                
                obj.SecurityActionLookup.Clear();
                
                obj.SecurityActionLookup.Add(SecurityActionAccessor.CreateNewT(manager, null));
                
                obj.SecurityActionLookup.AddRange(SecurityActionAccessor.rftSecurityAuditAction_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAction))
                    
                    .ToList());
                
                if (obj.idfsAction != 0)
                {
                    obj.SecurityAction = obj.SecurityActionLookup
                        .Where(c => c.idfsBaseReference == obj.idfsAction)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftSecurityAuditAction", obj, SecurityActionAccessor.GetType(), "rftSecurityAuditAction_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_SecurityProcessType(DbManagerProxy manager, SecurityEventLogListItem obj)
            {
                
                obj.SecurityProcessTypeLookup.Clear();
                
                obj.SecurityProcessTypeLookup.Add(SecurityProcessTypeAccessor.CreateNewT(manager, null));
                
                obj.SecurityProcessTypeLookup.AddRange(SecurityProcessTypeAccessor.rftSecurityAuditProcessType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsProcessType))
                    
                    .ToList());
                
                if (obj.idfsProcessType != 0)
                {
                    obj.SecurityProcessType = obj.SecurityProcessTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsProcessType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftSecurityAuditProcessType", obj, SecurityProcessTypeAccessor.GetType(), "rftSecurityAuditProcessType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_SecurityResult(DbManagerProxy manager, SecurityEventLogListItem obj)
            {
                
                obj.SecurityResultLookup.Clear();
                
                obj.SecurityResultLookup.Add(SecurityResultAccessor.CreateNewT(manager, null));
                
                obj.SecurityResultLookup.AddRange(SecurityResultAccessor.rftSecurityAuditResult_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsResult))
                    
                    .ToList());
                
                if (obj.idfsResult != 0)
                {
                    obj.SecurityResult = obj.SecurityResultLookup
                        .Where(c => c.idfsBaseReference == obj.idfsResult)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftSecurityAuditResult", obj, SecurityResultAccessor.GetType(), "rftSecurityAuditResult_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, SecurityEventLogListItem obj)
            {
                
                LoadLookup_SecurityAction(manager, obj);
                
                LoadLookup_SecurityProcessType(manager, obj);
                
                LoadLookup_SecurityResult(manager, obj);
                
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
                    SecurityEventLogListItem bo = obj as SecurityEventLogListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("SecurityLog", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("SecurityLog", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("SecurityLog", "Update");
                    }
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        long mainObject = bo.idfSecurityAudit;
                        
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
                    bSuccess = _PostNonTransaction(manager, obj as SecurityEventLogListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, SecurityEventLogListItem obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfSecurityAudit
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
            
            public bool ValidateCanDelete(SecurityEventLogListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, SecurityEventLogListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfSecurityAudit
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
                return Validate(manager, obj as SecurityEventLogListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, SecurityEventLogListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SecurityLog.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SecurityLog.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SecurityLog.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SecurityLog.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(SecurityEventLogListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(SecurityEventLogListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as SecurityEventLogListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as SecurityEventLogListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "SecurityEventLogListItemDetail"; } }
            public string HelpIdWin { get { return "SecurityLog"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private SecurityEventLogListItem m_obj;
            internal Permissions(SecurityEventLogListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SecurityLog.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SecurityLog.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SecurityLog.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SecurityLog.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_SecurityEventLog_SelectList";
            public static string spCount = "spSecurityEventLog_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spReadOnlyObject_Delete";
            public static string spCanDelete = "spReadOnlyObject_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<SecurityEventLogListItem, bool>> RequiredByField = new Dictionary<string, Func<SecurityEventLogListItem, bool>>();
            public static Dictionary<string, Func<SecurityEventLogListItem, bool>> RequiredByProperty = new Dictionary<string, Func<SecurityEventLogListItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strActionDefaultName, 2000);
                Sizes.Add(_str_strActionNationalName, 2000);
                Sizes.Add(_str_strResultDefaultName, 2000);
                Sizes.Add(_str_strResultNationalName, 2000);
                Sizes.Add(_str_strProcessTypeDefaultName, 2000);
                Sizes.Add(_str_strProcessTypeNationalName, 2000);
                Sizes.Add(_str_strAccountName, 200);
                Sizes.Add(_str_strErrorText, 200);
                Sizes.Add(_str_strProcessID, 200);
                Sizes.Add(_str_strDescription, 200);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datActionDate",
                    EditorType.Date,
                    true, false, 
                    "datActionDate",
                    () => DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter), null, true, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsAction",
                    EditorType.Lookup,
                    false, false, 
                    "strActionNationalName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "SecurityActionLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsProcessType",
                    EditorType.Lookup,
                    false, false, 
                    "strProcessTypeNationalName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "SecurityProcessTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsResult",
                    EditorType.Lookup,
                    false, false, 
                    "strResultNationalName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "SecurityResultLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfObjectID",
                    EditorType.Text,
                    false, false, 
                    "idfObjectID",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strAccountName",
                    EditorType.Text,
                    false, false, 
                    "strAccountName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strErrorText",
                    EditorType.Text,
                    false, false, 
                    "strErrorText",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strProcessID",
                    EditorType.Text,
                    false, false, 
                    "strProcessID",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strDescription",
                    EditorType.Text,
                    false, false, 
                    "strDescription",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfSecurityAudit,
                    _str_idfSecurityAudit, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datActionDate,
                    _str_datActionDate, "G", true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strActionNationalName,
                    _str_strActionNationalName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strResultNationalName,
                    _str_strResultNationalName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strProcessTypeNationalName,
                    _str_strProcessTypeNationalName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfObjectID,
                    _str_idfObjectID, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAccountName,
                    _str_strAccountName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strErrorText,
                    _str_strErrorText, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strProcessID,
                    _str_strProcessID, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDescription,
                    _str_strDescription, null, true, true, null
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
	