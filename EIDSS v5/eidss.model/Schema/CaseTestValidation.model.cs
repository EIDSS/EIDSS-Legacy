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
    public abstract partial class CaseTestValidation : 
        EditableObject<CaseTestValidation>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfTestValidation), NonUpdatable, PrimaryKey]
        public abstract Int64 idfTestValidation { get; set; }
                
        [LocalizedDisplayName(_str_idfTesting)]
        [MapField(_str_idfTesting)]
        public abstract Int64 idfTesting { get; set; }
        #if MONO
        protected Int64 idfTesting_Original { get { return idfTesting; } }
        protected Int64 idfTesting_Previous { get { return idfTesting; } }
        #else
        protected Int64 idfTesting_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfTesting).OriginalValue; } }
        protected Int64 idfTesting_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfTesting).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("TestDiagnosis")]
        [MapField(_str_DiagnosisName)]
        public abstract String DiagnosisName { get; set; }
        #if MONO
        protected String DiagnosisName_Original { get { return DiagnosisName; } }
        protected String DiagnosisName_Previous { get { return DiagnosisName; } }
        #else
        protected String DiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).OriginalValue; } }
        protected String DiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_TestName)]
        [MapField(_str_TestName)]
        public abstract String TestName { get; set; }
        #if MONO
        protected String TestName_Original { get { return TestName; } }
        protected String TestName_Previous { get { return TestName; } }
        #else
        protected String TestName_Original { get { return ((EditableValue<String>)((dynamic)this)._testName).OriginalValue; } }
        protected String TestName_Previous { get { return ((EditableValue<String>)((dynamic)this)._testName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("TestCategory")]
        [MapField(_str_TestType)]
        public abstract String TestType { get; set; }
        #if MONO
        protected String TestType_Original { get { return TestType; } }
        protected String TestType_Previous { get { return TestType; } }
        #else
        protected String TestType_Original { get { return ((EditableValue<String>)((dynamic)this)._testType).OriginalValue; } }
        protected String TestType_Previous { get { return ((EditableValue<String>)((dynamic)this)._testType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_RuleInOutName)]
        [MapField(_str_RuleInOutName)]
        public abstract String RuleInOutName { get; set; }
        #if MONO
        protected String RuleInOutName_Original { get { return RuleInOutName; } }
        protected String RuleInOutName_Previous { get { return RuleInOutName; } }
        #else
        protected String RuleInOutName_Original { get { return ((EditableValue<String>)((dynamic)this)._ruleInOutName).OriginalValue; } }
        protected String RuleInOutName_Previous { get { return ((EditableValue<String>)((dynamic)this)._ruleInOutName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_ValidatedName)]
        [MapField(_str_ValidatedName)]
        public abstract String ValidatedName { get; set; }
        #if MONO
        protected String ValidatedName_Original { get { return ValidatedName; } }
        protected String ValidatedName_Previous { get { return ValidatedName; } }
        #else
        protected String ValidatedName_Original { get { return ((EditableValue<String>)((dynamic)this)._validatedName).OriginalValue; } }
        protected String ValidatedName_Previous { get { return ((EditableValue<String>)((dynamic)this)._validatedName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_InterpretedName)]
        [MapField(_str_InterpretedName)]
        public abstract String InterpretedName { get; set; }
        #if MONO
        protected String InterpretedName_Original { get { return InterpretedName; } }
        protected String InterpretedName_Previous { get { return InterpretedName; } }
        #else
        protected String InterpretedName_Original { get { return ((EditableValue<String>)((dynamic)this)._interpretedName).OriginalValue; } }
        protected String InterpretedName_Previous { get { return ((EditableValue<String>)((dynamic)this)._interpretedName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsDiagnosis)]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64? idfsDiagnosis { get; set; }
        #if MONO
        protected Int64? idfsDiagnosis_Original { get { return idfsDiagnosis; } }
        protected Int64? idfsDiagnosis_Previous { get { return idfsDiagnosis; } }
        #else
        protected Int64? idfsDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64? idfsDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnValidateStatus)]
        [MapField(_str_blnValidateStatus)]
        public abstract Boolean? blnValidateStatus { get; set; }
        #if MONO
        protected Boolean? blnValidateStatus_Original { get { return blnValidateStatus; } }
        protected Boolean? blnValidateStatus_Previous { get { return blnValidateStatus; } }
        #else
        protected Boolean? blnValidateStatus_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnValidateStatus).OriginalValue; } }
        protected Boolean? blnValidateStatus_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnValidateStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfValidatedByPerson)]
        [MapField(_str_idfValidatedByPerson)]
        public abstract Int64? idfValidatedByPerson { get; set; }
        #if MONO
        protected Int64? idfValidatedByPerson_Original { get { return idfValidatedByPerson; } }
        protected Int64? idfValidatedByPerson_Previous { get { return idfValidatedByPerson; } }
        #else
        protected Int64? idfValidatedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfValidatedByPerson).OriginalValue; } }
        protected Int64? idfValidatedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfValidatedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strValidateComment)]
        [MapField(_str_strValidateComment)]
        public abstract String strValidateComment { get; set; }
        #if MONO
        protected String strValidateComment_Original { get { return strValidateComment; } }
        protected String strValidateComment_Previous { get { return strValidateComment; } }
        #else
        protected String strValidateComment_Original { get { return ((EditableValue<String>)((dynamic)this)._strValidateComment).OriginalValue; } }
        protected String strValidateComment_Previous { get { return ((EditableValue<String>)((dynamic)this)._strValidateComment).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datValidationDate)]
        [MapField(_str_datValidationDate)]
        public abstract DateTime? datValidationDate { get; set; }
        #if MONO
        protected DateTime? datValidationDate_Original { get { return datValidationDate; } }
        protected DateTime? datValidationDate_Previous { get { return datValidationDate; } }
        #else
        protected DateTime? datValidationDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datValidationDate).OriginalValue; } }
        protected DateTime? datValidationDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datValidationDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("RuleInOut")]
        [MapField(_str_idfsInterpretedStatus)]
        public abstract Int64? idfsInterpretedStatus { get; set; }
        #if MONO
        protected Int64? idfsInterpretedStatus_Original { get { return idfsInterpretedStatus; } }
        protected Int64? idfsInterpretedStatus_Previous { get { return idfsInterpretedStatus; } }
        #else
        protected Int64? idfsInterpretedStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsInterpretedStatus).OriginalValue; } }
        protected Int64? idfsInterpretedStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsInterpretedStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfInterpretedByPerson)]
        [MapField(_str_idfInterpretedByPerson)]
        public abstract Int64? idfInterpretedByPerson { get; set; }
        #if MONO
        protected Int64? idfInterpretedByPerson_Original { get { return idfInterpretedByPerson; } }
        protected Int64? idfInterpretedByPerson_Previous { get { return idfInterpretedByPerson; } }
        #else
        protected Int64? idfInterpretedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInterpretedByPerson).OriginalValue; } }
        protected Int64? idfInterpretedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInterpretedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strInterpretedComment)]
        [MapField(_str_strInterpretedComment)]
        public abstract String strInterpretedComment { get; set; }
        #if MONO
        protected String strInterpretedComment_Original { get { return strInterpretedComment; } }
        protected String strInterpretedComment_Previous { get { return strInterpretedComment; } }
        #else
        protected String strInterpretedComment_Original { get { return ((EditableValue<String>)((dynamic)this)._strInterpretedComment).OriginalValue; } }
        protected String strInterpretedComment_Previous { get { return ((EditableValue<String>)((dynamic)this)._strInterpretedComment).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datInterpretationDate)]
        [MapField(_str_datInterpretationDate)]
        public abstract DateTime? datInterpretationDate { get; set; }
        #if MONO
        protected DateTime? datInterpretationDate_Original { get { return datInterpretationDate; } }
        protected DateTime? datInterpretationDate_Previous { get { return datInterpretationDate; } }
        #else
        protected DateTime? datInterpretationDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datInterpretationDate).OriginalValue; } }
        protected DateTime? datInterpretationDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datInterpretationDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64 idfCase { get; set; }
        #if MONO
        protected Int64 idfCase_Original { get { return idfCase; } }
        protected Int64 idfCase_Previous { get { return idfCase; } }
        #else
        protected Int64 idfCase_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64 idfCase_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfCase).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<CaseTestValidation, object> _get_func;
            internal Action<CaseTestValidation, string> _set_func;
            internal Action<CaseTestValidation, CaseTestValidation, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfTestValidation = "idfTestValidation";
        internal const string _str_idfTesting = "idfTesting";
        internal const string _str_DiagnosisName = "DiagnosisName";
        internal const string _str_TestName = "TestName";
        internal const string _str_TestType = "TestType";
        internal const string _str_RuleInOutName = "RuleInOutName";
        internal const string _str_ValidatedName = "ValidatedName";
        internal const string _str_InterpretedName = "InterpretedName";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_blnValidateStatus = "blnValidateStatus";
        internal const string _str_idfValidatedByPerson = "idfValidatedByPerson";
        internal const string _str_strValidateComment = "strValidateComment";
        internal const string _str_datValidationDate = "datValidationDate";
        internal const string _str_idfsInterpretedStatus = "idfsInterpretedStatus";
        internal const string _str_idfInterpretedByPerson = "idfInterpretedByPerson";
        internal const string _str_strInterpretedComment = "strInterpretedComment";
        internal const string _str_datInterpretationDate = "datInterpretationDate";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_NewObject = "NewObject";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_RuleInOut = "RuleInOut";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfTestValidation, _type = "Int64",
              _get_func = o => o.idfTestValidation,
              _set_func = (o, val) => { o.idfTestValidation = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTestValidation != c.idfTestValidation || o.IsRIRPropChanged(_str_idfTestValidation, c)) 
                  m.Add(_str_idfTestValidation, o.ObjectIdent + _str_idfTestValidation, "Int64", o.idfTestValidation == null ? "" : o.idfTestValidation.ToString(), o.IsReadOnly(_str_idfTestValidation), o.IsInvisible(_str_idfTestValidation), o.IsRequired(_str_idfTestValidation)); }
              }, 
        
            new field_info {
              _name = _str_idfTesting, _type = "Int64",
              _get_func = o => o.idfTesting,
              _set_func = (o, val) => { o.idfTesting = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTesting != c.idfTesting || o.IsRIRPropChanged(_str_idfTesting, c)) 
                  m.Add(_str_idfTesting, o.ObjectIdent + _str_idfTesting, "Int64", o.idfTesting == null ? "" : o.idfTesting.ToString(), o.IsReadOnly(_str_idfTesting), o.IsInvisible(_str_idfTesting), o.IsRequired(_str_idfTesting)); }
              }, 
        
            new field_info {
              _name = _str_DiagnosisName, _type = "String",
              _get_func = o => o.DiagnosisName,
              _set_func = (o, val) => { o.DiagnosisName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.DiagnosisName != c.DiagnosisName || o.IsRIRPropChanged(_str_DiagnosisName, c)) 
                  m.Add(_str_DiagnosisName, o.ObjectIdent + _str_DiagnosisName, "String", o.DiagnosisName == null ? "" : o.DiagnosisName.ToString(), o.IsReadOnly(_str_DiagnosisName), o.IsInvisible(_str_DiagnosisName), o.IsRequired(_str_DiagnosisName)); }
              }, 
        
            new field_info {
              _name = _str_TestName, _type = "String",
              _get_func = o => o.TestName,
              _set_func = (o, val) => { o.TestName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.TestName != c.TestName || o.IsRIRPropChanged(_str_TestName, c)) 
                  m.Add(_str_TestName, o.ObjectIdent + _str_TestName, "String", o.TestName == null ? "" : o.TestName.ToString(), o.IsReadOnly(_str_TestName), o.IsInvisible(_str_TestName), o.IsRequired(_str_TestName)); }
              }, 
        
            new field_info {
              _name = _str_TestType, _type = "String",
              _get_func = o => o.TestType,
              _set_func = (o, val) => { o.TestType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.TestType != c.TestType || o.IsRIRPropChanged(_str_TestType, c)) 
                  m.Add(_str_TestType, o.ObjectIdent + _str_TestType, "String", o.TestType == null ? "" : o.TestType.ToString(), o.IsReadOnly(_str_TestType), o.IsInvisible(_str_TestType), o.IsRequired(_str_TestType)); }
              }, 
        
            new field_info {
              _name = _str_RuleInOutName, _type = "String",
              _get_func = o => o.RuleInOutName,
              _set_func = (o, val) => { o.RuleInOutName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.RuleInOutName != c.RuleInOutName || o.IsRIRPropChanged(_str_RuleInOutName, c)) 
                  m.Add(_str_RuleInOutName, o.ObjectIdent + _str_RuleInOutName, "String", o.RuleInOutName == null ? "" : o.RuleInOutName.ToString(), o.IsReadOnly(_str_RuleInOutName), o.IsInvisible(_str_RuleInOutName), o.IsRequired(_str_RuleInOutName)); }
              }, 
        
            new field_info {
              _name = _str_ValidatedName, _type = "String",
              _get_func = o => o.ValidatedName,
              _set_func = (o, val) => { o.ValidatedName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.ValidatedName != c.ValidatedName || o.IsRIRPropChanged(_str_ValidatedName, c)) 
                  m.Add(_str_ValidatedName, o.ObjectIdent + _str_ValidatedName, "String", o.ValidatedName == null ? "" : o.ValidatedName.ToString(), o.IsReadOnly(_str_ValidatedName), o.IsInvisible(_str_ValidatedName), o.IsRequired(_str_ValidatedName)); }
              }, 
        
            new field_info {
              _name = _str_InterpretedName, _type = "String",
              _get_func = o => o.InterpretedName,
              _set_func = (o, val) => { o.InterpretedName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.InterpretedName != c.InterpretedName || o.IsRIRPropChanged(_str_InterpretedName, c)) 
                  m.Add(_str_InterpretedName, o.ObjectIdent + _str_InterpretedName, "String", o.InterpretedName == null ? "" : o.InterpretedName.ToString(), o.IsReadOnly(_str_InterpretedName), o.IsInvisible(_str_InterpretedName), o.IsRequired(_str_InterpretedName)); }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { o.idfsDiagnosis = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, "Int64?", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_blnValidateStatus, _type = "Boolean?",
              _get_func = o => o.blnValidateStatus,
              _set_func = (o, val) => { o.blnValidateStatus = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnValidateStatus != c.blnValidateStatus || o.IsRIRPropChanged(_str_blnValidateStatus, c)) 
                  m.Add(_str_blnValidateStatus, o.ObjectIdent + _str_blnValidateStatus, "Boolean?", o.blnValidateStatus == null ? "" : o.blnValidateStatus.ToString(), o.IsReadOnly(_str_blnValidateStatus), o.IsInvisible(_str_blnValidateStatus), o.IsRequired(_str_blnValidateStatus)); }
              }, 
        
            new field_info {
              _name = _str_idfValidatedByPerson, _type = "Int64?",
              _get_func = o => o.idfValidatedByPerson,
              _set_func = (o, val) => { o.idfValidatedByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfValidatedByPerson != c.idfValidatedByPerson || o.IsRIRPropChanged(_str_idfValidatedByPerson, c)) 
                  m.Add(_str_idfValidatedByPerson, o.ObjectIdent + _str_idfValidatedByPerson, "Int64?", o.idfValidatedByPerson == null ? "" : o.idfValidatedByPerson.ToString(), o.IsReadOnly(_str_idfValidatedByPerson), o.IsInvisible(_str_idfValidatedByPerson), o.IsRequired(_str_idfValidatedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_strValidateComment, _type = "String",
              _get_func = o => o.strValidateComment,
              _set_func = (o, val) => { o.strValidateComment = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strValidateComment != c.strValidateComment || o.IsRIRPropChanged(_str_strValidateComment, c)) 
                  m.Add(_str_strValidateComment, o.ObjectIdent + _str_strValidateComment, "String", o.strValidateComment == null ? "" : o.strValidateComment.ToString(), o.IsReadOnly(_str_strValidateComment), o.IsInvisible(_str_strValidateComment), o.IsRequired(_str_strValidateComment)); }
              }, 
        
            new field_info {
              _name = _str_datValidationDate, _type = "DateTime?",
              _get_func = o => o.datValidationDate,
              _set_func = (o, val) => { o.datValidationDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datValidationDate != c.datValidationDate || o.IsRIRPropChanged(_str_datValidationDate, c)) 
                  m.Add(_str_datValidationDate, o.ObjectIdent + _str_datValidationDate, "DateTime?", o.datValidationDate == null ? "" : o.datValidationDate.ToString(), o.IsReadOnly(_str_datValidationDate), o.IsInvisible(_str_datValidationDate), o.IsRequired(_str_datValidationDate)); }
              }, 
        
            new field_info {
              _name = _str_idfsInterpretedStatus, _type = "Int64?",
              _get_func = o => o.idfsInterpretedStatus,
              _set_func = (o, val) => { o.idfsInterpretedStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsInterpretedStatus != c.idfsInterpretedStatus || o.IsRIRPropChanged(_str_idfsInterpretedStatus, c)) 
                  m.Add(_str_idfsInterpretedStatus, o.ObjectIdent + _str_idfsInterpretedStatus, "Int64?", o.idfsInterpretedStatus == null ? "" : o.idfsInterpretedStatus.ToString(), o.IsReadOnly(_str_idfsInterpretedStatus), o.IsInvisible(_str_idfsInterpretedStatus), o.IsRequired(_str_idfsInterpretedStatus)); }
              }, 
        
            new field_info {
              _name = _str_idfInterpretedByPerson, _type = "Int64?",
              _get_func = o => o.idfInterpretedByPerson,
              _set_func = (o, val) => { o.idfInterpretedByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfInterpretedByPerson != c.idfInterpretedByPerson || o.IsRIRPropChanged(_str_idfInterpretedByPerson, c)) 
                  m.Add(_str_idfInterpretedByPerson, o.ObjectIdent + _str_idfInterpretedByPerson, "Int64?", o.idfInterpretedByPerson == null ? "" : o.idfInterpretedByPerson.ToString(), o.IsReadOnly(_str_idfInterpretedByPerson), o.IsInvisible(_str_idfInterpretedByPerson), o.IsRequired(_str_idfInterpretedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_strInterpretedComment, _type = "String",
              _get_func = o => o.strInterpretedComment,
              _set_func = (o, val) => { o.strInterpretedComment = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strInterpretedComment != c.strInterpretedComment || o.IsRIRPropChanged(_str_strInterpretedComment, c)) 
                  m.Add(_str_strInterpretedComment, o.ObjectIdent + _str_strInterpretedComment, "String", o.strInterpretedComment == null ? "" : o.strInterpretedComment.ToString(), o.IsReadOnly(_str_strInterpretedComment), o.IsInvisible(_str_strInterpretedComment), o.IsRequired(_str_strInterpretedComment)); }
              }, 
        
            new field_info {
              _name = _str_datInterpretationDate, _type = "DateTime?",
              _get_func = o => o.datInterpretationDate,
              _set_func = (o, val) => { o.datInterpretationDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datInterpretationDate != c.datInterpretationDate || o.IsRIRPropChanged(_str_datInterpretationDate, c)) 
                  m.Add(_str_datInterpretationDate, o.ObjectIdent + _str_datInterpretationDate, "DateTime?", o.datInterpretationDate == null ? "" : o.datInterpretationDate.ToString(), o.IsReadOnly(_str_datInterpretationDate), o.IsInvisible(_str_datInterpretationDate), o.IsRequired(_str_datInterpretationDate)); }
              }, 
        
            new field_info {
              _name = _str_idfCase, _type = "Int64",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { o.idfCase = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, "Int64", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); }
              }, 
        
            new field_info {
              _name = _str_NewObject, _type = "bool",
              _get_func = o => o.NewObject,
              _set_func = (o, val) => { o.NewObject = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.NewObject != c.NewObject || o.IsRIRPropChanged(_str_NewObject, c)) 
                  m.Add(_str_NewObject, o.ObjectIdent + _str_NewObject, "bool", o.NewObject == null ? "" : o.NewObject.ToString(), o.IsReadOnly(_str_NewObject), o.IsInvisible(_str_NewObject), o.IsRequired(_str_NewObject));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsCaseType, _type = "long?",
              _get_func = o => o.idfsCaseType,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_idfsCaseType, c)) 
                  m.Add(_str_idfsCaseType, o.ObjectIdent + _str_idfsCaseType, "long?", o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(), o.IsReadOnly(_str_idfsCaseType), o.IsInvisible(_str_idfsCaseType), o.IsRequired(_str_idfsCaseType));
                 }
              }, 
        
            new field_info {
              _name = _str_CaseObjectIdent, _type = "string",
              _get_func = o => o.CaseObjectIdent,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.CaseObjectIdent != c.CaseObjectIdent || o.IsRIRPropChanged(_str_CaseObjectIdent, c)) 
                  m.Add(_str_CaseObjectIdent, o.ObjectIdent + _str_CaseObjectIdent, "string", o.CaseObjectIdent == null ? "" : o.CaseObjectIdent.ToString(), o.IsReadOnly(_str_CaseObjectIdent), o.IsInvisible(_str_CaseObjectIdent), o.IsRequired(_str_CaseObjectIdent));
                 }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnosis, c)) 
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis)); }
              }, 
        
            new field_info {
              _name = _str_RuleInOut, _type = "Lookup",
              _get_func = o => { if (o.RuleInOut == null) return null; return o.RuleInOut.idfsBaseReference; },
              _set_func = (o, val) => { o.RuleInOut = o.RuleInOutLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsInterpretedStatus != c.idfsInterpretedStatus || o.IsRIRPropChanged(_str_RuleInOut, c)) 
                  m.Add(_str_RuleInOut, o.ObjectIdent + _str_RuleInOut, "Lookup", o.idfsInterpretedStatus == null ? "" : o.idfsInterpretedStatus.ToString(), o.IsReadOnly(_str_RuleInOut), o.IsInvisible(_str_RuleInOut), o.IsRequired(_str_RuleInOut)); }
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
            CaseTestValidation obj = (CaseTestValidation)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsDiagnosis = _Diagnosis == null 
                    ? new Int64?()
                    : _Diagnosis.idfsDiagnosis; 
                OnPropertyChanged(_str_Diagnosis); 
            }
        }
        private DiagnosisLookup _Diagnosis;

        
        public List<DiagnosisLookup> DiagnosisLookup
        {
            get { return _DiagnosisLookup; }
        }
        private List<DiagnosisLookup> _DiagnosisLookup = new List<DiagnosisLookup>();
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsInterpretedStatus)]
        public BaseReference RuleInOut
        {
            get { return _RuleInOut == null ? null : ((long)_RuleInOut.Key == 0 ? null : _RuleInOut); }
            set 
            { 
                _RuleInOut = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsInterpretedStatus = _RuleInOut == null 
                    ? new Int64?()
                    : _RuleInOut.idfsBaseReference; 
                OnPropertyChanged(_str_RuleInOut); 
            }
        }
        private BaseReference _RuleInOut;

        
        public BaseReferenceList RuleInOutLookup
        {
            get { return _RuleInOutLookup; }
        }
        private BaseReferenceList _RuleInOutLookup = new BaseReferenceList("rftRuleInValue");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_RuleInOut:
                    return new BvSelectList(RuleInOutLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, RuleInOut, _str_idfsInterpretedStatus);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsCaseType)]
        public long? idfsCaseType
        {
            get { return new Func<CaseTestValidation, long?>(c => c.Parent is AsSession ? 0 : (
                                       c.Parent is HumanCase ? (long)eidss.model.Enums.CaseTypeEnum.Human : (
                                       c.Parent is VetCase ? (c.Parent as VetCase).idfsCaseType : (long?)null)))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<CaseTestValidation, string>(c => (c.idfsCaseType == (long)eidss.model.Enums.CaseTypeEnum.Human ? "HumanCase_" : (c.idfsCaseType == 0 ? "AsSession_" : "VetCase_")) + c.idfCase + "_")(this); }
            
        }
        
          [LocalizedDisplayName(_str_NewObject)]
        public bool NewObject
        {
            get { return m_NewObject; }
            set { if (m_NewObject != value) { m_NewObject = value; OnPropertyChanged(_str_NewObject); } }
        }
        private bool m_NewObject;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "CaseTestValidation";

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
            var ret = base.Clone() as CaseTestValidation;
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
            var ret = base.Clone() as CaseTestValidation;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public CaseTestValidation CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as CaseTestValidation;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfTestValidation; } }
        public string KeyName { get { return "idfTestValidation"; } }
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
        
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfsInterpretedStatus_RuleInOut = idfsInterpretedStatus;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsInterpretedStatus_RuleInOut != idfsInterpretedStatus)
            {
                _RuleInOut = _RuleInOutLookup.FirstOrDefault(c => c.idfsBaseReference == idfsInterpretedStatus);
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

      private bool IsRIRPropChanged(string fld, CaseTestValidation c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public CaseTestValidation()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(CaseTestValidation_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(CaseTestValidation_PropertyChanged);
        }
        private void CaseTestValidation_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as CaseTestValidation).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_idfsCaseType);
                  
            if (e.PropertyName == _str_idfCase)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
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
            CaseTestValidation obj = this;
            try
            {
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.IsNew
                    );
            
            }
            catch(ValidationModelException ex)
            {
                if (bReport && !OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                {
                    OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                }
                
                return false;
            }
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            CaseTestValidation obj = this;
            
        }
        private void _DeletedExtenders()
        {
            CaseTestValidation obj = this;
            
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

    
        private static string[] readonly_names1 = "TestName,TestType,datInterpretationDate,InterpretedName,datValidationDate,ValidatedName".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "Diagnosis,idfsDiagnosis,RuleInOut,idfsInterpretedStatus,strInterpretedComment".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<CaseTestValidation, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<CaseTestValidation, bool>(c => !ModelUserContext.Instance.CurrentUser.HasPermission("CanValidateTestResult.Execute") || c.blnValidateStatus.HasValue && c.blnValidateStatus.Value)(this);
            
            return ReadOnly || new Func<CaseTestValidation, bool>(c => false)(this);
                
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


        public Dictionary<string, Func<CaseTestValidation, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<CaseTestValidation, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<CaseTestValidation, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<CaseTestValidation, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<CaseTestValidation, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<CaseTestValidation, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~CaseTestValidation()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftRuleInValue", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftRuleInValue")
                _getAccessor().LoadLookup_RuleInOut(manager, this);
            
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
        public class CaseTestValidationGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfTestValidation { get; set; }
        
            public bool IsNew { get; set; }
        
            public string DiagnosisName { get; set; }
        
            public string TestName { get; set; }
        
            public string TestType { get; set; }
        
            public string RuleInOutName { get; set; }
        
            public string strInterpretedComment { get; set; }
        
            public DateTime? datInterpretationDate { get; set; }
        
            public string InterpretedName { get; set; }
        
            public bool? blnValidateStatus { get; set; }
        
            public string strValidateComment { get; set; }
        
            public DateTime? datValidationDate { get; set; }
        
            public string ValidatedName { get; set; }
        
        }
        public partial class CaseTestValidationGridModelList : List<CaseTestValidationGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public CaseTestValidationGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<CaseTestValidation>, errMes);
            }
            public CaseTestValidationGridModelList(long key, IEnumerable<CaseTestValidation> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<CaseTestValidation> items);
            private void LoadGridModelList(long key, IEnumerable<CaseTestValidation> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_DiagnosisName,_str_TestName,_str_TestType,_str_RuleInOutName,_str_strInterpretedComment,_str_datInterpretationDate,_str_InterpretedName,_str_blnValidateStatus,_str_strValidateComment,_str_datValidationDate,_str_ValidatedName};
                    
                Hiddens = new List<string> {_str_idfTestValidation,_str_IsNew};
                Keys = new List<string> {_str_idfTestValidation};
                Labels = new Dictionary<string, string> {{_str_DiagnosisName, "TestDiagnosis"},{_str_TestName, _str_TestName},{_str_TestType, "TestCategory"},{_str_RuleInOutName, _str_RuleInOutName},{_str_strInterpretedComment, _str_strInterpretedComment},{_str_datInterpretationDate, _str_datInterpretationDate},{_str_InterpretedName, _str_InterpretedName},{_str_blnValidateStatus, _str_blnValidateStatus},{_str_strValidateComment, _str_strValidateComment},{_str_datValidationDate, _str_datValidationDate},{_str_ValidatedName, _str_ValidatedName}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<CaseTestValidation>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new CaseTestValidationGridModel()
                {
                    ItemKey=c.idfTestValidation,IsNew=c.IsNew,DiagnosisName=c.DiagnosisName,TestName=c.TestName,TestType=c.TestType,RuleInOutName=c.RuleInOutName,strInterpretedComment=c.strInterpretedComment,datInterpretationDate=c.datInterpretationDate,InterpretedName=c.InterpretedName,blnValidateStatus=c.blnValidateStatus,strValidateComment=c.strValidateComment,datValidationDate=c.datValidationDate,ValidatedName=c.ValidatedName
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
        : DataAccessor<CaseTestValidation>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(CaseTestValidation obj);
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
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor RuleInOutAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<CaseTestValidation> SelectList(DbManagerProxy manager
                , Int64? idfCase
                )
            {
                return _SelectList(manager
                    , idfCase
                    , delegate(CaseTestValidation obj)
                        {
                        }
                    , delegate(CaseTestValidation obj)
                        {
                        }
                    );
            }

            
            private List<CaseTestValidation> _SelectList(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<CaseTestValidation> objs = new List<CaseTestValidation>();
                    sets[0] = new MapResultSet(typeof(CaseTestValidation), objs);
                    
                    manager
                        .SetSpCommand("spCaseTestsValidation_SelectDetail"
                            , manager.Parameter("@idfCase", idfCase)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, CaseTestValidation obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, CaseTestValidation obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private CaseTestValidation _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    CaseTestValidation obj = CaseTestValidation.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfTestValidation = (new GetNewIDExtender<CaseTestValidation>()).GetScalar(manager, obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.datInterpretationDate = new Func<CaseTestValidation, DateTime>(c => DateTime.Now.Date)(obj);
                obj.idfInterpretedByPerson = new Func<CaseTestValidation, long>(c => (long)ModelUserContext.Instance.CurrentUser.EmployeeID)(obj);
                obj.InterpretedName = new Func<CaseTestValidation, string>(c => ModelUserContext.Instance.CurrentUser.FullName)(obj);
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

            
            public CaseTestValidation CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public CaseTestValidation CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public CaseTestValidation CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 5) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfCase", typeof(long));
                if (pars[1] != null && !(pars[1] is long)) 
                    throw new TypeMismatchException("idfTesting", typeof(long));
                if (pars[2] != null && !(pars[2] is string)) 
                    throw new TypeMismatchException("TestName", typeof(string));
                if (pars[3] != null && !(pars[3] is string)) 
                    throw new TypeMismatchException("TestType", typeof(string));
                if (pars[4] != null && !(pars[4] is long)) 
                    throw new TypeMismatchException("idfsDiagnosis", typeof(long));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    , (long)pars[1]
                    , (string)pars[2]
                    , (string)pars[3]
                    , (long)pars[4]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public CaseTestValidation Create(DbManagerProxy manager, IObject Parent
                , long idfCase
                , long idfTesting
                , string TestName
                , string TestType
                , long idfsDiagnosis
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfCase = new Func<CaseTestValidation, long>(c => idfCase)(obj);
                obj.idfTesting = new Func<CaseTestValidation, long>(c => idfTesting)(obj);
                obj.TestName = new Func<CaseTestValidation, string>(c => TestName)(obj);
                obj.TestType = new Func<CaseTestValidation, string>(c => TestType)(obj);
                }
                    , obj =>
                {
                obj.Diagnosis = new Func<CaseTestValidation, DiagnosisLookup>(c => c.DiagnosisLookup.FirstOrDefault(i => i.idfsDiagnosis == idfsDiagnosis))(obj);
                }
                );
            }
            
            private void _SetupChildHandlers(CaseTestValidation obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(CaseTestValidation obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_blnValidateStatus)
                        {
                    
                obj.datValidationDate = new Func<CaseTestValidation, DateTime>(c => DateTime.Now.Date)(obj);
                        }
                    
                        if (e.PropertyName == _str_blnValidateStatus)
                        {
                    
                obj.idfValidatedByPerson = new Func<CaseTestValidation, long>(c => (long)ModelUserContext.Instance.CurrentUser.EmployeeID)(obj);
                        }
                    
                        if (e.PropertyName == _str_blnValidateStatus)
                        {
                    
                obj.ValidatedName = new Func<CaseTestValidation, string>(c => ModelUserContext.Instance.CurrentUser.FullName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                obj.DiagnosisName = new Func<CaseTestValidation, string>(c => c.Diagnosis != null ? c.Diagnosis.name : "")(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsInterpretedStatus)
                        {
                    
                obj.RuleInOutName = new Func<CaseTestValidation, string>(c => c.RuleInOut != null ? c.RuleInOut.name : "")(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Diagnosis(DbManagerProxy manager, CaseTestValidation obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & 
                               (obj.idfsCaseType == (long)CaseTypeEnum.Human ? (int)HACode.Human :
                               (obj.idfsCaseType == (long)CaseTypeEnum.Livestock ? (int)HACode.Livestock : 
                               (obj.idfsCaseType == (long)CaseTypeEnum.Avian ? (int)HACode.Avian : 
                               (int)HACode.All)))) != 0) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != null && obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .Where(c => c.idfsDiagnosis == obj.idfsDiagnosis)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_RuleInOut(DbManagerProxy manager, CaseTestValidation obj)
            {
                
                obj.RuleInOutLookup.Clear();
                
                obj.RuleInOutLookup.Add(RuleInOutAccessor.CreateNewT(manager, null));
                
                obj.RuleInOutLookup.AddRange(RuleInOutAccessor.rftRuleInValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsInterpretedStatus))
                    
                    .ToList());
                
                if (obj.idfsInterpretedStatus != null && obj.idfsInterpretedStatus != 0)
                {
                    obj.RuleInOut = obj.RuleInOutLookup
                        .Where(c => c.idfsBaseReference == obj.idfsInterpretedStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftRuleInValue", obj, RuleInOutAccessor.GetType(), "rftRuleInValue_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, CaseTestValidation obj)
            {
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_RuleInOut(manager, obj);
                
            }
    
            [SprocName("spCaseTestsValidation_Update")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] CaseTestValidation obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] CaseTestValidation obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    CaseTestValidation bo = obj as CaseTestValidation;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as CaseTestValidation, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, CaseTestValidation obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (!obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(CaseTestValidation obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, CaseTestValidation obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as CaseTestValidation, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, CaseTestValidation obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsDiagnosis", "Diagnosis","",
                false
              )).Validate(c => true, obj, obj.idfsDiagnosis);
            
                (new RequiredValidator( "idfsInterpretedStatus", "RuleInOut","RuleInOut",
                false
              )).Validate(c => true, obj, obj.idfsInterpretedStatus);
            
                  
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
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                        return false;
                    }
                }
                
                return true;
            }
           
    
            private void _SetupRequired(CaseTestValidation obj)
            {
            
                obj
                    .AddRequired("Diagnosis", c => true);
                    
                obj
                    .AddRequired("RuleInOut", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(CaseTestValidation obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as CaseTestValidation) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as CaseTestValidation) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "CaseTestValidationDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spCaseTestsValidation_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spCaseTestsValidation_Update";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<CaseTestValidation, bool>> RequiredByField = new Dictionary<string, Func<CaseTestValidation, bool>>();
            public static Dictionary<string, Func<CaseTestValidation, bool>> RequiredByProperty = new Dictionary<string, Func<CaseTestValidation, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_DiagnosisName, 2000);
                Sizes.Add(_str_TestName, 2000);
                Sizes.Add(_str_TestType, 2000);
                Sizes.Add(_str_RuleInOutName, 2000);
                Sizes.Add(_str_ValidatedName, 401);
                Sizes.Add(_str_InterpretedName, 401);
                Sizes.Add(_str_strValidateComment, 200);
                Sizes.Add(_str_strInterpretedComment, 200);
                if (!RequiredByField.ContainsKey("idfsDiagnosis")) RequiredByField.Add("idfsDiagnosis", c => true);
                if (!RequiredByProperty.ContainsKey("Diagnosis")) RequiredByProperty.Add("Diagnosis", c => true);
                
                if (!RequiredByField.ContainsKey("idfsInterpretedStatus")) RequiredByField.Add("idfsInterpretedStatus", c => true);
                if (!RequiredByProperty.ContainsKey("RuleInOut")) RequiredByProperty.Add("RuleInOut", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfTestValidation,
                    _str_idfTestValidation, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_IsNew,
                    _str_IsNew, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DiagnosisName,
                    "TestDiagnosis", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestName,
                    _str_TestName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestType,
                    "TestCategory", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_RuleInOutName,
                    _str_RuleInOutName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strInterpretedComment,
                    _str_strInterpretedComment, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datInterpretationDate,
                    _str_datInterpretationDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_InterpretedName,
                    _str_InterpretedName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_blnValidateStatus,
                    _str_blnValidateStatus, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strValidateComment,
                    _str_strValidateComment, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datValidationDate,
                    _str_datValidationDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_ValidatedName,
                    _str_ValidatedName, null, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).Create(manager, c, pars)),
                        
                    null,
                    
                    null,
                      false,
                    "CanValidateTestInterpretation",
                    null,
                    null,
                    null,
                    null,
                    false
                    ));
                
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
                    (manager, c, pars) => ((CaseTestValidation)c).MarkToDelete(),
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	