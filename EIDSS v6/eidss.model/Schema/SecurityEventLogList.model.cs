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
                
        [LocalizedDisplayName("idfObjectID")]
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
        internal const string _str_SecurityAction = "SecurityAction";
        internal const string _str_SecurityProcessType = "SecurityProcessType";
        internal const string _str_SecurityResult = "SecurityResult";
        internal const string _str_PersonEnteredBy = "PersonEnteredBy";
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsAction != newval) 
                  o.SecurityAction = o.SecurityActionLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsAction != newval) o.idfsAction = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsResult != newval) 
                  o.SecurityResult = o.SecurityResultLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsResult != newval) o.idfsResult = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsProcessType != newval) 
                  o.SecurityProcessType = o.SecurityProcessTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsProcessType != newval) o.idfsProcessType = newval; },
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
        
            new field_info {
              _name = _str_SecurityAction, _formname = _str_SecurityAction, _type = "Lookup",
              _get_func = o => { if (o.SecurityAction == null) return null; return o.SecurityAction.idfsBaseReference; },
              _set_func = (o, val) => { o.SecurityAction = o.SecurityActionLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAction != c.idfsAction || o.IsRIRPropChanged(_str_SecurityAction, c)) {
                  m.Add(_str_SecurityAction, o.ObjectIdent + _str_SecurityAction, o.ObjectIdent2 + _str_SecurityAction, o.ObjectIdent3 + _str_SecurityAction, "Lookup", o.idfsAction == null ? "" : o.idfsAction.ToString(), o.IsReadOnly(_str_SecurityAction), o.IsInvisible(_str_SecurityAction), o.IsRequired(_str_SecurityAction)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SecurityAction + "Lookup", _formname = _str_SecurityAction + "Lookup", _type = "LookupContent",
              _get_func = o => o.SecurityActionLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_SecurityProcessType, _formname = _str_SecurityProcessType, _type = "Lookup",
              _get_func = o => { if (o.SecurityProcessType == null) return null; return o.SecurityProcessType.idfsBaseReference; },
              _set_func = (o, val) => { o.SecurityProcessType = o.SecurityProcessTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsProcessType != c.idfsProcessType || o.IsRIRPropChanged(_str_SecurityProcessType, c)) {
                  m.Add(_str_SecurityProcessType, o.ObjectIdent + _str_SecurityProcessType, o.ObjectIdent2 + _str_SecurityProcessType, o.ObjectIdent3 + _str_SecurityProcessType, "Lookup", o.idfsProcessType == null ? "" : o.idfsProcessType.ToString(), o.IsReadOnly(_str_SecurityProcessType), o.IsInvisible(_str_SecurityProcessType), o.IsRequired(_str_SecurityProcessType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SecurityProcessType + "Lookup", _formname = _str_SecurityProcessType + "Lookup", _type = "LookupContent",
              _get_func = o => o.SecurityProcessTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_SecurityResult, _formname = _str_SecurityResult, _type = "Lookup",
              _get_func = o => { if (o.SecurityResult == null) return null; return o.SecurityResult.idfsBaseReference; },
              _set_func = (o, val) => { o.SecurityResult = o.SecurityResultLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsResult != c.idfsResult || o.IsRIRPropChanged(_str_SecurityResult, c)) {
                  m.Add(_str_SecurityResult, o.ObjectIdent + _str_SecurityResult, o.ObjectIdent2 + _str_SecurityResult, o.ObjectIdent3 + _str_SecurityResult, "Lookup", o.idfsResult == null ? "" : o.idfsResult.ToString(), o.IsReadOnly(_str_SecurityResult), o.IsInvisible(_str_SecurityResult), o.IsRequired(_str_SecurityResult)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SecurityResult + "Lookup", _formname = _str_SecurityResult + "Lookup", _type = "LookupContent",
              _get_func = o => o.SecurityResultLookup,
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
            SecurityEventLogListItem obj = (SecurityEventLogListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_SecurityAction)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAction)]
        public BaseReference SecurityAction
        {
            get { return _SecurityAction == null ? null : ((long)_SecurityAction.Key == 0 ? null : _SecurityAction); }
            set 
            { 
                var oldVal = _SecurityAction;
                _SecurityAction = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SecurityAction != oldVal)
                {
                    if (idfsAction != (_SecurityAction == null
                            ? new Int64()
                            : (Int64)_SecurityAction.idfsBaseReference))
                        idfsAction = _SecurityAction == null 
                            ? new Int64()
                            : (Int64)_SecurityAction.idfsBaseReference; 
                    OnPropertyChanged(_str_SecurityAction); 
                }
            }
        }
        private BaseReference _SecurityAction;

        
        public BaseReferenceList SecurityActionLookup
        {
            get { return _SecurityActionLookup; }
        }
        private BaseReferenceList _SecurityActionLookup = new BaseReferenceList("rftSecurityAuditAction");
            
        [LocalizedDisplayName(_str_SecurityProcessType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsProcessType)]
        public BaseReference SecurityProcessType
        {
            get { return _SecurityProcessType == null ? null : ((long)_SecurityProcessType.Key == 0 ? null : _SecurityProcessType); }
            set 
            { 
                var oldVal = _SecurityProcessType;
                _SecurityProcessType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SecurityProcessType != oldVal)
                {
                    if (idfsProcessType != (_SecurityProcessType == null
                            ? new Int64()
                            : (Int64)_SecurityProcessType.idfsBaseReference))
                        idfsProcessType = _SecurityProcessType == null 
                            ? new Int64()
                            : (Int64)_SecurityProcessType.idfsBaseReference; 
                    OnPropertyChanged(_str_SecurityProcessType); 
                }
            }
        }
        private BaseReference _SecurityProcessType;

        
        public BaseReferenceList SecurityProcessTypeLookup
        {
            get { return _SecurityProcessTypeLookup; }
        }
        private BaseReferenceList _SecurityProcessTypeLookup = new BaseReferenceList("rftSecurityAuditProcessType");
            
        [LocalizedDisplayName(_str_SecurityResult)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsResult)]
        public BaseReference SecurityResult
        {
            get { return _SecurityResult == null ? null : ((long)_SecurityResult.Key == 0 ? null : _SecurityResult); }
            set 
            { 
                var oldVal = _SecurityResult;
                _SecurityResult = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SecurityResult != oldVal)
                {
                    if (idfsResult != (_SecurityResult == null
                            ? new Int64()
                            : (Int64)_SecurityResult.idfsBaseReference))
                        idfsResult = _SecurityResult == null 
                            ? new Int64()
                            : (Int64)_SecurityResult.idfsBaseReference; 
                    OnPropertyChanged(_str_SecurityResult); 
                }
            }
        }
        private BaseReference _SecurityResult;

        
        public BaseReferenceList SecurityResultLookup
        {
            get { return _SecurityResultLookup; }
        }
        private BaseReferenceList _SecurityResultLookup = new BaseReferenceList("rftSecurityAuditResult");
            
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
            
                case _str_SecurityAction:
                    return new BvSelectList(SecurityActionLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SecurityAction, _str_idfsAction);
            
                case _str_SecurityProcessType:
                    return new BvSelectList(SecurityProcessTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SecurityProcessType, _str_idfsProcessType);
            
                case _str_SecurityResult:
                    return new BvSelectList(SecurityResultLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SecurityResult, _str_idfsResult);
            
                case _str_PersonEnteredBy:
                    return new BvSelectList(PersonEnteredByLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, PersonEnteredBy, _str_idfPerson);
            
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
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as SecurityEventLogListItem;
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
            var ret = base.Clone() as SecurityEventLogListItem;
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
        
            var _prev_idfsAction_SecurityAction = idfsAction;
            var _prev_idfsProcessType_SecurityProcessType = idfsProcessType;
            var _prev_idfsResult_SecurityResult = idfsResult;
            var _prev_idfPerson_PersonEnteredBy = idfPerson;
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

        private bool IsRIRPropChanged(string fld, SecurityEventLogListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public SecurityEventLogListItem()
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


        internal Dictionary<string, Func<SecurityEventLogListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<SecurityEventLogListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<SecurityEventLogListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<SecurityEventLogListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<SecurityEventLogListItem, bool>> m_isHiddenPersonalData;
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
                
                LookupManager.RemoveObject("PersonLookup", this);
                
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
        public class SecurityEventLogListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfSecurityAudit { get; set; }
        
            public DateTime? datActionDate { get; set; }
        
            public String strActionNationalName { get; set; }
        
            public String strResultNationalName { get; set; }
        
            public String strProcessTypeNationalName { get; set; }
        
            public String strObjectID { get; set; }
        
            public String strPersonName { get; set; }
        
            public String strErrorText { get; set; }
        
            public String strProcessID { get; set; }
        
            public String strDescription { get; set; }
        
        }
        public partial class SecurityEventLogListItemGridModelList : List<SecurityEventLogListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public SecurityEventLogListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<SecurityEventLogListItem>, errMes);
            }
            public SecurityEventLogListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<SecurityEventLogListItem>, errMes);
            }
            public SecurityEventLogListItemGridModelList(long key, IEnumerable<SecurityEventLogListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public SecurityEventLogListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<SecurityEventLogListItem>(), null);
            }
            partial void filter(List<SecurityEventLogListItem> items);
            private void LoadGridModelList(long key, IEnumerable<SecurityEventLogListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_datActionDate,_str_strActionNationalName,_str_strResultNationalName,_str_strProcessTypeNationalName,_str_strObjectID,_str_strPersonName,_str_strErrorText,_str_strProcessID,_str_strDescription};
                    
                Hiddens = new List<string> {_str_idfSecurityAudit};
                Keys = new List<string> {_str_idfSecurityAudit};
                Labels = new Dictionary<string, string> {{_str_datActionDate, _str_datActionDate},{_str_strActionNationalName, _str_strActionNationalName},{_str_strResultNationalName, _str_strResultNationalName},{_str_strProcessTypeNationalName, _str_strProcessTypeNationalName},{_str_strObjectID, "idfObjectID"},{_str_strPersonName, _str_strPersonName},{_str_strErrorText, _str_strErrorText},{_str_strProcessID, _str_strProcessID},{_str_strDescription, _str_strDescription}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                SecurityEventLogListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<SecurityEventLogListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new SecurityEventLogListItemGridModel()
                {
                    ItemKey=c.idfSecurityAudit,datActionDate=c.datActionDate,strActionNationalName=c.strActionNationalName,strResultNationalName=c.strResultNationalName,strProcessTypeNationalName=c.strProcessTypeNationalName,strObjectID=c.strObjectID,strPersonName=c.strPersonName,strErrorText=c.strErrorText,strProcessID=c.strProcessID,strDescription=c.strDescription
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
            , IObjectCreator<SecurityEventLogListItem>
            
            , IObjectSelectList
            , IObjectSelectList<SecurityEventLogListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfSecurityAudit"; } }
            #endregion
        
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
            private PersonLookup.Accessor PersonEnteredByAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            
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
                        
                        if (filters.Operation("idfSecurityAudit", i) == "&")
                          sql.AppendFormat("(isnull(fn_SecurityEventLog_SelectList.idfSecurityAudit,0) {0} @idfSecurityAudit_{1} = @idfSecurityAudit_{1})", filters.Operation("idfSecurityAudit", i), i);
                        else
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
                        
                        if (filters.Operation("idfsAction", i) == "&")
                          sql.AppendFormat("(isnull(fn_SecurityEventLog_SelectList.idfsAction,0) {0} @idfsAction_{1} = @idfsAction_{1})", filters.Operation("idfsAction", i), i);
                        else
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
                        
                        if (filters.Operation("idfsResult", i) == "&")
                          sql.AppendFormat("(isnull(fn_SecurityEventLog_SelectList.idfsResult,0) {0} @idfsResult_{1} = @idfsResult_{1})", filters.Operation("idfsResult", i), i);
                        else
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
                        
                        if (filters.Operation("idfsProcessType", i) == "&")
                          sql.AppendFormat("(isnull(fn_SecurityEventLog_SelectList.idfsProcessType,0) {0} @idfsProcessType_{1} = @idfsProcessType_{1})", filters.Operation("idfsProcessType", i), i);
                        else
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
                        
                        if (filters.Operation("idfAffectedObjectType", i) == "&")
                          sql.AppendFormat("(isnull(fn_SecurityEventLog_SelectList.idfAffectedObjectType,0) {0} @idfAffectedObjectType_{1} = @idfAffectedObjectType_{1})", filters.Operation("idfAffectedObjectType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_SecurityEventLog_SelectList.idfAffectedObjectType,0) {0} @idfAffectedObjectType_{1}", filters.Operation("idfAffectedObjectType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strObjectID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strObjectID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strObjectID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SecurityEventLog_SelectList.strObjectID {0} @strObjectID_{1}", filters.Operation("strObjectID", i), i);
                            
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
                        
                        if (filters.Operation("idfUserID", i) == "&")
                          sql.AppendFormat("(isnull(fn_SecurityEventLog_SelectList.idfUserID,0) {0} @idfUserID_{1} = @idfUserID_{1})", filters.Operation("idfUserID", i), i);
                        else
                          sql.AppendFormat("isnull(fn_SecurityEventLog_SelectList.idfUserID,0) {0} @idfUserID_{1}", filters.Operation("idfUserID", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_SecurityEventLog_SelectList.idfPerson,0) {0} @idfPerson_{1} = @idfPerson_{1})", filters.Operation("idfPerson", i), i);
                        else
                          sql.AppendFormat("isnull(fn_SecurityEventLog_SelectList.idfPerson,0) {0} @idfPerson_{1}", filters.Operation("idfPerson", i), i);
                            
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
                  
                if (filters.Contains("strPersonName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strPersonName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strPersonName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SecurityEventLog_SelectList.strPersonName {0} @strPersonName_{1}", filters.Operation("strPersonName", i), i);
                            
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
                        
                        if (filters.Operation("idfDataAuditEvent", i) == "&")
                          sql.AppendFormat("(isnull(fn_SecurityEventLog_SelectList.idfDataAuditEvent,0) {0} @idfDataAuditEvent_{1} = @idfDataAuditEvent_{1})", filters.Operation("idfDataAuditEvent", i), i);
                        else
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
                    
                    sql.Append(" option (OPTIMIZE FOR UNKNOWN)");
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
                      
                    if (filters.Contains("strObjectID"))
                        for (int i = 0; i < filters.Count("strObjectID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strObjectID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strObjectID", i), filters.Value("strObjectID", i))));
                      
                    if (filters.Contains("idfUserID"))
                        for (int i = 0; i < filters.Count("idfUserID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfUserID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfUserID", i), filters.Value("idfUserID", i))));
                      
                    if (filters.Contains("idfPerson"))
                        for (int i = 0; i < filters.Count("idfPerson"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfPerson", i), filters.Value("idfPerson", i))));
                      
                    if (filters.Contains("strAccountName"))
                        for (int i = 0; i < filters.Count("strAccountName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strAccountName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strAccountName", i), filters.Value("strAccountName", i))));
                      
                    if (filters.Contains("strPersonName"))
                        for (int i = 0; i < filters.Count("strPersonName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strPersonName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strPersonName", i), filters.Value("strPersonName", i))));
                      
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
            partial void ListSelected(DbManagerProxy manager, List<SecurityEventLogListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spSecurityEventLog_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, SecurityEventLogListItem obj, bool bCloning = false)
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

    

            private SecurityEventLogListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
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
            public SecurityEventLogListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
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
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsAction);
                    
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
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsProcessType);
                    
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
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsResult);
                    
                }
              
                
                LookupManager.AddObject("rftSecurityAuditResult", obj, SecurityResultAccessor.GetType(), "rftSecurityAuditResult_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_PersonEnteredBy(DbManagerProxy manager, SecurityEventLogListItem obj)
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
            

            private void _LoadLookups(DbManagerProxy manager, SecurityEventLogListItem obj)
            {
                
                LoadLookup_SecurityAction(manager, obj);
                
                LoadLookup_SecurityProcessType(manager, obj);
                
                LoadLookup_SecurityResult(manager, obj);
                
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
                    bSuccess = _PostNonTransaction(manager, obj as SecurityEventLogListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, SecurityEventLogListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
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
                //obj.AcceptChanges();
                
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
        
      
            protected ValidationModelException ChainsValidate(SecurityEventLogListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(SecurityEventLogListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as SecurityEventLogListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, SecurityEventLogListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
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
            public string HelpIdWin { get { return "Security_Log"; } }
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
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datActionDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datActionDate",
                    c => DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter), null, c => true, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsAction",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strActionNationalName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "SecurityActionLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsProcessType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strProcessTypeNationalName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "SecurityProcessTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsResult",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strResultNationalName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "SecurityResultLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strObjectID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfObjectID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfPerson",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strPersonName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "PersonEnteredByLookup", typeof(PersonLookup), (o) => { var c = (PersonLookup)o; return c.idfPerson; }, (o) => { var c = (PersonLookup)o; return c.FullName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strErrorText",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strErrorText",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strProcessID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strProcessID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strDescription",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strDescription",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfSecurityAudit,
                    _str_idfSecurityAudit, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datActionDate,
                    _str_datActionDate, "G", true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strActionNationalName,
                    _str_strActionNationalName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strResultNationalName,
                    _str_strResultNationalName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strProcessTypeNationalName,
                    _str_strProcessTypeNationalName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strObjectID,
                    "idfObjectID", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPersonName,
                    _str_strPersonName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strErrorText,
                    _str_strErrorText, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strProcessID,
                    _str_strProcessID, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDescription,
                    _str_strDescription, null, true, true, true, true, null
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
	