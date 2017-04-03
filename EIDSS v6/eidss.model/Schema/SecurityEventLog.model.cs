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
        protected Int64 idfsAction_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAction).OriginalValue; } }
        protected Int64 idfsAction_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAction).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strActionDefaultName)]
        [MapField(_str_strActionDefaultName)]
        public abstract String strActionDefaultName { get; set; }
        protected String strActionDefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._strActionDefaultName).OriginalValue; } }
        protected String strActionDefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strActionDefaultName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strActionNationalName)]
        [MapField(_str_strActionNationalName)]
        public abstract String strActionNationalName { get; set; }
        protected String strActionNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._strActionNationalName).OriginalValue; } }
        protected String strActionNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strActionNationalName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsResult)]
        [MapField(_str_idfsResult)]
        public abstract Int64 idfsResult { get; set; }
        protected Int64 idfsResult_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsResult).OriginalValue; } }
        protected Int64 idfsResult_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsResult).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strResultDefaultName)]
        [MapField(_str_strResultDefaultName)]
        public abstract String strResultDefaultName { get; set; }
        protected String strResultDefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._strResultDefaultName).OriginalValue; } }
        protected String strResultDefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strResultDefaultName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strResultNationalName)]
        [MapField(_str_strResultNationalName)]
        public abstract String strResultNationalName { get; set; }
        protected String strResultNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._strResultNationalName).OriginalValue; } }
        protected String strResultNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strResultNationalName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsProcessType)]
        [MapField(_str_idfsProcessType)]
        public abstract Int64 idfsProcessType { get; set; }
        protected Int64 idfsProcessType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsProcessType).OriginalValue; } }
        protected Int64 idfsProcessType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsProcessType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strProcessTypeDefaultName)]
        [MapField(_str_strProcessTypeDefaultName)]
        public abstract String strProcessTypeDefaultName { get; set; }
        protected String strProcessTypeDefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._strProcessTypeDefaultName).OriginalValue; } }
        protected String strProcessTypeDefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strProcessTypeDefaultName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strProcessTypeNationalName)]
        [MapField(_str_strProcessTypeNationalName)]
        public abstract String strProcessTypeNationalName { get; set; }
        protected String strProcessTypeNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._strProcessTypeNationalName).OriginalValue; } }
        protected String strProcessTypeNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strProcessTypeNationalName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfAffectedObjectType)]
        [MapField(_str_idfAffectedObjectType)]
        public abstract Int64 idfAffectedObjectType { get; set; }
        protected Int64 idfAffectedObjectType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfAffectedObjectType).OriginalValue; } }
        protected Int64 idfAffectedObjectType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfAffectedObjectType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strObjectID)]
        [MapField(_str_strObjectID)]
        public abstract String strObjectID { get; set; }
        protected String strObjectID_Original { get { return ((EditableValue<String>)((dynamic)this)._strObjectID).OriginalValue; } }
        protected String strObjectID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strObjectID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfUserID)]
        [MapField(_str_idfUserID)]
        public abstract Int64? idfUserID { get; set; }
        protected Int64? idfUserID_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfUserID).OriginalValue; } }
        protected Int64? idfUserID_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfUserID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPerson)]
        [MapField(_str_idfPerson)]
        public abstract Int64? idfPerson { get; set; }
        protected Int64? idfPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerson).OriginalValue; } }
        protected Int64? idfPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strAccountName)]
        [MapField(_str_strAccountName)]
        public abstract String strAccountName { get; set; }
        protected String strAccountName_Original { get { return ((EditableValue<String>)((dynamic)this)._strAccountName).OriginalValue; } }
        protected String strAccountName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAccountName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPersonName)]
        [MapField(_str_strPersonName)]
        public abstract String strPersonName { get; set; }
        protected String strPersonName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPersonName).OriginalValue; } }
        protected String strPersonName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPersonName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfDataAuditEvent)]
        [MapField(_str_idfDataAuditEvent)]
        public abstract Int64? idfDataAuditEvent { get; set; }
        protected Int64? idfDataAuditEvent_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDataAuditEvent).OriginalValue; } }
        protected Int64? idfDataAuditEvent_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDataAuditEvent).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datActionDate)]
        [MapField(_str_datActionDate)]
        public abstract DateTime? datActionDate { get; set; }
        protected DateTime? datActionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datActionDate).OriginalValue; } }
        protected DateTime? datActionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datActionDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strErrorText)]
        [MapField(_str_strErrorText)]
        public abstract String strErrorText { get; set; }
        protected String strErrorText_Original { get { return ((EditableValue<String>)((dynamic)this)._strErrorText).OriginalValue; } }
        protected String strErrorText_Previous { get { return ((EditableValue<String>)((dynamic)this)._strErrorText).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strProcessID)]
        [MapField(_str_strProcessID)]
        public abstract String strProcessID { get; set; }
        protected String strProcessID_Original { get { return ((EditableValue<String>)((dynamic)this)._strProcessID).OriginalValue; } }
        protected String strProcessID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strProcessID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDescription)]
        [MapField(_str_strDescription)]
        public abstract String strDescription { get; set; }
        protected String strDescription_Original { get { return ((EditableValue<String>)((dynamic)this)._strDescription).OriginalValue; } }
        protected String strDescription_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDescription).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
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
        internal const string _str_strObjectID = "strObjectID";
        internal const string _str_idfUserID = "idfUserID";
        internal const string _str_idfPerson = "idfPerson";
        internal const string _str_strAccountName = "strAccountName";
        internal const string _str_strPersonName = "strPersonName";
        internal const string _str_idfDataAuditEvent = "idfDataAuditEvent";
        internal const string _str_datActionDate = "datActionDate";
        internal const string _str_strErrorText = "strErrorText";
        internal const string _str_strProcessID = "strProcessID";
        internal const string _str_strDescription = "strDescription";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfSecurityAudit, _formname = _str_idfSecurityAudit, _type = "Int64",
              _get_func = o => o.idfSecurityAudit,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfSecurityAudit != newval) o.idfSecurityAudit = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfSecurityAudit != c.idfSecurityAudit || o.IsRIRPropChanged(_str_idfSecurityAudit, c)) 
                  m.Add(_str_idfSecurityAudit, o.ObjectIdent + _str_idfSecurityAudit, o.ObjectIdent2 + _str_idfSecurityAudit, o.ObjectIdent3 + _str_idfSecurityAudit, "Int64", 
                    o.idfSecurityAudit == null ? "" : o.idfSecurityAudit.ToString(),                  
                  o.IsReadOnly(_str_idfSecurityAudit), o.IsInvisible(_str_idfSecurityAudit), o.IsRequired(_str_idfSecurityAudit)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAction, _formname = _str_idfsAction, _type = "Int64",
              _get_func = o => o.idfsAction,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsAction != newval) o.idfsAction = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsAction != c.idfsAction || o.IsRIRPropChanged(_str_idfsAction, c)) 
                  m.Add(_str_idfsAction, o.ObjectIdent + _str_idfsAction, o.ObjectIdent2 + _str_idfsAction, o.ObjectIdent3 + _str_idfsAction, "Int64", 
                    o.idfsAction == null ? "" : o.idfsAction.ToString(),                  
                  o.IsReadOnly(_str_idfsAction), o.IsInvisible(_str_idfsAction), o.IsRequired(_str_idfsAction)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strActionDefaultName, _formname = _str_strActionDefaultName, _type = "String",
              _get_func = o => o.strActionDefaultName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strActionDefaultName != newval) o.strActionDefaultName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strActionDefaultName != c.strActionDefaultName || o.IsRIRPropChanged(_str_strActionDefaultName, c)) 
                  m.Add(_str_strActionDefaultName, o.ObjectIdent + _str_strActionDefaultName, o.ObjectIdent2 + _str_strActionDefaultName, o.ObjectIdent3 + _str_strActionDefaultName, "String", 
                    o.strActionDefaultName == null ? "" : o.strActionDefaultName.ToString(),                  
                  o.IsReadOnly(_str_strActionDefaultName), o.IsInvisible(_str_strActionDefaultName), o.IsRequired(_str_strActionDefaultName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strActionNationalName, _formname = _str_strActionNationalName, _type = "String",
              _get_func = o => o.strActionNationalName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strActionNationalName != newval) o.strActionNationalName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strActionNationalName != c.strActionNationalName || o.IsRIRPropChanged(_str_strActionNationalName, c)) 
                  m.Add(_str_strActionNationalName, o.ObjectIdent + _str_strActionNationalName, o.ObjectIdent2 + _str_strActionNationalName, o.ObjectIdent3 + _str_strActionNationalName, "String", 
                    o.strActionNationalName == null ? "" : o.strActionNationalName.ToString(),                  
                  o.IsReadOnly(_str_strActionNationalName), o.IsInvisible(_str_strActionNationalName), o.IsRequired(_str_strActionNationalName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsResult, _formname = _str_idfsResult, _type = "Int64",
              _get_func = o => o.idfsResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsResult != newval) o.idfsResult = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsResult != c.idfsResult || o.IsRIRPropChanged(_str_idfsResult, c)) 
                  m.Add(_str_idfsResult, o.ObjectIdent + _str_idfsResult, o.ObjectIdent2 + _str_idfsResult, o.ObjectIdent3 + _str_idfsResult, "Int64", 
                    o.idfsResult == null ? "" : o.idfsResult.ToString(),                  
                  o.IsReadOnly(_str_idfsResult), o.IsInvisible(_str_idfsResult), o.IsRequired(_str_idfsResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strResultDefaultName, _formname = _str_strResultDefaultName, _type = "String",
              _get_func = o => o.strResultDefaultName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strResultDefaultName != newval) o.strResultDefaultName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strResultDefaultName != c.strResultDefaultName || o.IsRIRPropChanged(_str_strResultDefaultName, c)) 
                  m.Add(_str_strResultDefaultName, o.ObjectIdent + _str_strResultDefaultName, o.ObjectIdent2 + _str_strResultDefaultName, o.ObjectIdent3 + _str_strResultDefaultName, "String", 
                    o.strResultDefaultName == null ? "" : o.strResultDefaultName.ToString(),                  
                  o.IsReadOnly(_str_strResultDefaultName), o.IsInvisible(_str_strResultDefaultName), o.IsRequired(_str_strResultDefaultName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strResultNationalName, _formname = _str_strResultNationalName, _type = "String",
              _get_func = o => o.strResultNationalName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strResultNationalName != newval) o.strResultNationalName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strResultNationalName != c.strResultNationalName || o.IsRIRPropChanged(_str_strResultNationalName, c)) 
                  m.Add(_str_strResultNationalName, o.ObjectIdent + _str_strResultNationalName, o.ObjectIdent2 + _str_strResultNationalName, o.ObjectIdent3 + _str_strResultNationalName, "String", 
                    o.strResultNationalName == null ? "" : o.strResultNationalName.ToString(),                  
                  o.IsReadOnly(_str_strResultNationalName), o.IsInvisible(_str_strResultNationalName), o.IsRequired(_str_strResultNationalName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsProcessType, _formname = _str_idfsProcessType, _type = "Int64",
              _get_func = o => o.idfsProcessType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsProcessType != newval) o.idfsProcessType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsProcessType != c.idfsProcessType || o.IsRIRPropChanged(_str_idfsProcessType, c)) 
                  m.Add(_str_idfsProcessType, o.ObjectIdent + _str_idfsProcessType, o.ObjectIdent2 + _str_idfsProcessType, o.ObjectIdent3 + _str_idfsProcessType, "Int64", 
                    o.idfsProcessType == null ? "" : o.idfsProcessType.ToString(),                  
                  o.IsReadOnly(_str_idfsProcessType), o.IsInvisible(_str_idfsProcessType), o.IsRequired(_str_idfsProcessType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strProcessTypeDefaultName, _formname = _str_strProcessTypeDefaultName, _type = "String",
              _get_func = o => o.strProcessTypeDefaultName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strProcessTypeDefaultName != newval) o.strProcessTypeDefaultName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strProcessTypeDefaultName != c.strProcessTypeDefaultName || o.IsRIRPropChanged(_str_strProcessTypeDefaultName, c)) 
                  m.Add(_str_strProcessTypeDefaultName, o.ObjectIdent + _str_strProcessTypeDefaultName, o.ObjectIdent2 + _str_strProcessTypeDefaultName, o.ObjectIdent3 + _str_strProcessTypeDefaultName, "String", 
                    o.strProcessTypeDefaultName == null ? "" : o.strProcessTypeDefaultName.ToString(),                  
                  o.IsReadOnly(_str_strProcessTypeDefaultName), o.IsInvisible(_str_strProcessTypeDefaultName), o.IsRequired(_str_strProcessTypeDefaultName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strProcessTypeNationalName, _formname = _str_strProcessTypeNationalName, _type = "String",
              _get_func = o => o.strProcessTypeNationalName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strProcessTypeNationalName != newval) o.strProcessTypeNationalName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strProcessTypeNationalName != c.strProcessTypeNationalName || o.IsRIRPropChanged(_str_strProcessTypeNationalName, c)) 
                  m.Add(_str_strProcessTypeNationalName, o.ObjectIdent + _str_strProcessTypeNationalName, o.ObjectIdent2 + _str_strProcessTypeNationalName, o.ObjectIdent3 + _str_strProcessTypeNationalName, "String", 
                    o.strProcessTypeNationalName == null ? "" : o.strProcessTypeNationalName.ToString(),                  
                  o.IsReadOnly(_str_strProcessTypeNationalName), o.IsInvisible(_str_strProcessTypeNationalName), o.IsRequired(_str_strProcessTypeNationalName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfAffectedObjectType, _formname = _str_idfAffectedObjectType, _type = "Int64",
              _get_func = o => o.idfAffectedObjectType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfAffectedObjectType != newval) o.idfAffectedObjectType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfAffectedObjectType != c.idfAffectedObjectType || o.IsRIRPropChanged(_str_idfAffectedObjectType, c)) 
                  m.Add(_str_idfAffectedObjectType, o.ObjectIdent + _str_idfAffectedObjectType, o.ObjectIdent2 + _str_idfAffectedObjectType, o.ObjectIdent3 + _str_idfAffectedObjectType, "Int64", 
                    o.idfAffectedObjectType == null ? "" : o.idfAffectedObjectType.ToString(),                  
                  o.IsReadOnly(_str_idfAffectedObjectType), o.IsInvisible(_str_idfAffectedObjectType), o.IsRequired(_str_idfAffectedObjectType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strObjectID, _formname = _str_strObjectID, _type = "String",
              _get_func = o => o.strObjectID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strObjectID != newval) o.strObjectID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strObjectID != c.strObjectID || o.IsRIRPropChanged(_str_strObjectID, c)) 
                  m.Add(_str_strObjectID, o.ObjectIdent + _str_strObjectID, o.ObjectIdent2 + _str_strObjectID, o.ObjectIdent3 + _str_strObjectID, "String", 
                    o.strObjectID == null ? "" : o.strObjectID.ToString(),                  
                  o.IsReadOnly(_str_strObjectID), o.IsInvisible(_str_strObjectID), o.IsRequired(_str_strObjectID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfUserID, _formname = _str_idfUserID, _type = "Int64?",
              _get_func = o => o.idfUserID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfUserID != newval) o.idfUserID = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfUserID != c.idfUserID || o.IsRIRPropChanged(_str_idfUserID, c)) 
                  m.Add(_str_idfUserID, o.ObjectIdent + _str_idfUserID, o.ObjectIdent2 + _str_idfUserID, o.ObjectIdent3 + _str_idfUserID, "Int64?", 
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
              _name = _str_idfDataAuditEvent, _formname = _str_idfDataAuditEvent, _type = "Int64?",
              _get_func = o => o.idfDataAuditEvent,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfDataAuditEvent != newval) o.idfDataAuditEvent = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfDataAuditEvent != c.idfDataAuditEvent || o.IsRIRPropChanged(_str_idfDataAuditEvent, c)) 
                  m.Add(_str_idfDataAuditEvent, o.ObjectIdent + _str_idfDataAuditEvent, o.ObjectIdent2 + _str_idfDataAuditEvent, o.ObjectIdent3 + _str_idfDataAuditEvent, "Int64?", 
                    o.idfDataAuditEvent == null ? "" : o.idfDataAuditEvent.ToString(),                  
                  o.IsReadOnly(_str_idfDataAuditEvent), o.IsInvisible(_str_idfDataAuditEvent), o.IsRequired(_str_idfDataAuditEvent)); 
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
              _name = _str_strErrorText, _formname = _str_strErrorText, _type = "String",
              _get_func = o => o.strErrorText,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strErrorText != newval) o.strErrorText = newval; },
              _compare_func = (o, c, m) => {
                if (o.strErrorText != c.strErrorText || o.IsRIRPropChanged(_str_strErrorText, c)) 
                  m.Add(_str_strErrorText, o.ObjectIdent + _str_strErrorText, o.ObjectIdent2 + _str_strErrorText, o.ObjectIdent3 + _str_strErrorText, "String", 
                    o.strErrorText == null ? "" : o.strErrorText.ToString(),                  
                  o.IsReadOnly(_str_strErrorText), o.IsInvisible(_str_strErrorText), o.IsRequired(_str_strErrorText)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strProcessID, _formname = _str_strProcessID, _type = "String",
              _get_func = o => o.strProcessID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strProcessID != newval) o.strProcessID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strProcessID != c.strProcessID || o.IsRIRPropChanged(_str_strProcessID, c)) 
                  m.Add(_str_strProcessID, o.ObjectIdent + _str_strProcessID, o.ObjectIdent2 + _str_strProcessID, o.ObjectIdent3 + _str_strProcessID, "String", 
                    o.strProcessID == null ? "" : o.strProcessID.ToString(),                  
                  o.IsReadOnly(_str_strProcessID), o.IsInvisible(_str_strProcessID), o.IsRequired(_str_strProcessID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDescription, _formname = _str_strDescription, _type = "String",
              _get_func = o => o.strDescription,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDescription != newval) o.strDescription = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDescription != c.strDescription || o.IsRIRPropChanged(_str_strDescription, c)) 
                  m.Add(_str_strDescription, o.ObjectIdent + _str_strDescription, o.ObjectIdent2 + _str_strDescription, o.ObjectIdent3 + _str_strDescription, "String", 
                    o.strDescription == null ? "" : o.strDescription.ToString(),                  
                  o.IsReadOnly(_str_strDescription), o.IsInvisible(_str_strDescription), o.IsRequired(_str_strDescription)); 
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
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as SecurityEventLog;
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
            var ret = base.Clone() as SecurityEventLog;
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

        private bool IsRIRPropChanged(string fld, SecurityEventLog c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public SecurityEventLog()
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


        internal Dictionary<string, Func<SecurityEventLog, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<SecurityEventLog, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<SecurityEventLog, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<SecurityEventLog, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<SecurityEventLog, bool>> m_isHiddenPersonalData;
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
        : DataAccessor<SecurityEventLog>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<SecurityEventLog>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<SecurityEventLog>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfSecurityAudit"; } }
            #endregion
        
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
            public virtual SecurityEventLog SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, SecurityEventLog obj, bool bCloning = false)
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

    

            private SecurityEventLog _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
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
            public SecurityEventLog CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
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
            
      
            protected ValidationModelException ChainsValidate(SecurityEventLog obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(SecurityEventLog obj, bool bRethrowException)
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
                return Validate(manager, obj as SecurityEventLog, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, SecurityEventLog obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
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
                
                Sizes.Add(_str_strActionDefaultName, 2000);
                Sizes.Add(_str_strActionNationalName, 2000);
                Sizes.Add(_str_strResultDefaultName, 2000);
                Sizes.Add(_str_strResultNationalName, 2000);
                Sizes.Add(_str_strProcessTypeDefaultName, 2000);
                Sizes.Add(_str_strProcessTypeNationalName, 2000);
                Sizes.Add(_str_strObjectID, 30);
                Sizes.Add(_str_strAccountName, 200);
                Sizes.Add(_str_strPersonName, 602);
                Sizes.Add(_str_strErrorText, 200);
                Sizes.Add(_str_strProcessID, 200);
                Sizes.Add(_str_strDescription, 200);
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
	