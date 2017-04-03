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
    public abstract partial class SecurityEventLog : 
        EditableObject<SecurityEventLog>
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
            internal Func<SecurityEventLog, object> _get_func;
            internal Action<SecurityEventLog, string> _set_func;
            internal Action<SecurityEventLog, SecurityEventLog, CompareModel> _compare_func;
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
            SecurityEventLog obj = (SecurityEventLog)o;
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
        internal string m_ObjectName = "SecurityEventLog";

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
            var ret = base.Clone() as SecurityEventLog;
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
            var ret = base.Clone() as SecurityEventLog;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public SecurityEventLog CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as SecurityEventLog;
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

      private bool IsRIRPropChanged(string fld, SecurityEventLog c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public SecurityEventLog()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SecurityEventLog_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(SecurityEventLog_PropertyChanged);
        }
        private void SecurityEventLog_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as SecurityEventLog).Changed(e.PropertyName);
            
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
            SecurityEventLog obj = this;
            
        }
        private void _DeletedExtenders()
        {
            SecurityEventLog obj = this;
            
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


        public Dictionary<string, Func<SecurityEventLog, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<SecurityEventLog, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<SecurityEventLog, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<SecurityEventLog, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<SecurityEventLog, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<SecurityEventLog, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~SecurityEventLog()
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
        : DataAccessor<SecurityEventLog>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(SecurityEventLog obj);
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
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual SecurityEventLog SelectByKey(DbManagerProxy manager
                , Int64? idfSecurityAudit
                )
            {
                return _SelectByKey(manager
                    , idfSecurityAudit
                    , null, null
                    );
            }
            
      
            private SecurityEventLog _SelectByKey(DbManagerProxy manager
                , Int64? idfSecurityAudit
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<SecurityEventLog> objs = new List<SecurityEventLog>();
                sets[0] = new MapResultSet(typeof(SecurityEventLog), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spSecurityEventLog_SelectDetail"
                            , manager.Parameter("@idfSecurityAudit", idfSecurityAudit)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    SecurityEventLog obj = objs[0];
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
                    throw DbModelException.Create(e);
                }
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, SecurityEventLog obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, SecurityEventLog obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private SecurityEventLog _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    SecurityEventLog obj = SecurityEventLog.CreateInstance();
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

            
            public SecurityEventLog CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public SecurityEventLog CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(SecurityEventLog obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(SecurityEventLog obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, SecurityEventLog obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as SecurityEventLog, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, SecurityEventLog obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(SecurityEventLog obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(SecurityEventLog obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as SecurityEventLog) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as SecurityEventLog) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "SecurityEventLogDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spSecurityEventLog_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<SecurityEventLog, bool>> RequiredByField = new Dictionary<string, Func<SecurityEventLog, bool>>();
            public static Dictionary<string, Func<SecurityEventLog, bool>> RequiredByProperty = new Dictionary<string, Func<SecurityEventLog, bool>>();
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
                    (manager, c, pars) => new ActResult(((SecurityEventLog)c).MarkToDelete() && ObjectAccessor.PostInterface<SecurityEventLog>().Post(manager, (SecurityEventLog)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<SecurityEventLog>().Post(manager, (SecurityEventLog)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<SecurityEventLog>().Post(manager, (SecurityEventLog)c), c),
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
	