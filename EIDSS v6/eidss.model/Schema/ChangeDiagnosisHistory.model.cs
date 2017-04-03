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
    public abstract partial class ChangeDiagnosisHistory : 
        EditableObject<ChangeDiagnosisHistory>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfChangeDiagnosisHistory), NonUpdatable, PrimaryKey]
        public abstract Int64 idfChangeDiagnosisHistory { get; set; }
                
        [LocalizedDisplayName(_str_idfHumanCase)]
        [MapField(_str_idfHumanCase)]
        public abstract Int64 idfHumanCase { get; set; }
        protected Int64 idfHumanCase_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfHumanCase).OriginalValue; } }
        protected Int64 idfHumanCase_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfHumanCase).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsPreviousDiagnosis)]
        [MapField(_str_idfsPreviousDiagnosis)]
        public abstract Int64? idfsPreviousDiagnosis { get; set; }
        protected Int64? idfsPreviousDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPreviousDiagnosis).OriginalValue; } }
        protected Int64? idfsPreviousDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPreviousDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCurrentDiagnosis)]
        [MapField(_str_idfsCurrentDiagnosis)]
        public abstract Int64? idfsCurrentDiagnosis { get; set; }
        protected Int64? idfsCurrentDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCurrentDiagnosis).OriginalValue; } }
        protected Int64? idfsCurrentDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCurrentDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datChangedDate)]
        [MapField(_str_datChangedDate)]
        public abstract DateTime datChangedDate { get; set; }
        protected DateTime datChangedDate_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datChangedDate).OriginalValue; } }
        protected DateTime datChangedDate_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datChangedDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsChangeDiagnosisReason)]
        [MapField(_str_idfsChangeDiagnosisReason)]
        public abstract Int64? idfsChangeDiagnosisReason { get; set; }
        protected Int64? idfsChangeDiagnosisReason_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsChangeDiagnosisReason).OriginalValue; } }
        protected Int64? idfsChangeDiagnosisReason_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsChangeDiagnosisReason).PreviousValue; } }
                
        [LocalizedDisplayName("idfsChangeDiagnosisReason")]
        [MapField(_str_strReason)]
        public abstract String strReason { get; set; }
        protected String strReason_Original { get { return ((EditableValue<String>)((dynamic)this)._strReason).OriginalValue; } }
        protected String strReason_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReason).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPerson)]
        [MapField(_str_idfPerson)]
        public abstract Int64 idfPerson { get; set; }
        protected Int64 idfPerson_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfPerson).OriginalValue; } }
        protected Int64 idfPerson_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfPerson).PreviousValue; } }
                
        [LocalizedDisplayName("strChangedByPerson")]
        [MapField(_str_strPersonName)]
        public abstract String strPersonName { get; set; }
        protected String strPersonName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPersonName).OriginalValue; } }
        protected String strPersonName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPersonName).PreviousValue; } }
                
        [LocalizedDisplayName("strChangedByOrganization")]
        [MapField(_str_Organization)]
        public abstract String Organization { get; set; }
        protected String Organization_Original { get { return ((EditableValue<String>)((dynamic)this)._organization).OriginalValue; } }
        protected String Organization_Previous { get { return ((EditableValue<String>)((dynamic)this)._organization).PreviousValue; } }
                
        [LocalizedDisplayName(_str_PreviousDiagnosisName)]
        [MapField(_str_PreviousDiagnosisName)]
        public abstract String PreviousDiagnosisName { get; set; }
        protected String PreviousDiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._previousDiagnosisName).OriginalValue; } }
        protected String PreviousDiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._previousDiagnosisName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_CurrentDiagnosisName)]
        [MapField(_str_CurrentDiagnosisName)]
        public abstract String CurrentDiagnosisName { get; set; }
        protected String CurrentDiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._currentDiagnosisName).OriginalValue; } }
        protected String CurrentDiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._currentDiagnosisName).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<ChangeDiagnosisHistory, object> _get_func;
            internal Action<ChangeDiagnosisHistory, string> _set_func;
            internal Action<ChangeDiagnosisHistory, ChangeDiagnosisHistory, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfChangeDiagnosisHistory = "idfChangeDiagnosisHistory";
        internal const string _str_idfHumanCase = "idfHumanCase";
        internal const string _str_idfsPreviousDiagnosis = "idfsPreviousDiagnosis";
        internal const string _str_idfsCurrentDiagnosis = "idfsCurrentDiagnosis";
        internal const string _str_datChangedDate = "datChangedDate";
        internal const string _str_idfsChangeDiagnosisReason = "idfsChangeDiagnosisReason";
        internal const string _str_strReason = "strReason";
        internal const string _str_idfPerson = "idfPerson";
        internal const string _str_strPersonName = "strPersonName";
        internal const string _str_Organization = "Organization";
        internal const string _str_PreviousDiagnosisName = "PreviousDiagnosisName";
        internal const string _str_CurrentDiagnosisName = "CurrentDiagnosisName";
        internal const string _str_PreviousDiagnosis = "PreviousDiagnosis";
        internal const string _str_CurrentDiagnosis = "CurrentDiagnosis";
        internal const string _str_ChangeDiagnosisReason = "ChangeDiagnosisReason";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfChangeDiagnosisHistory, _formname = _str_idfChangeDiagnosisHistory, _type = "Int64",
              _get_func = o => o.idfChangeDiagnosisHistory,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfChangeDiagnosisHistory != newval) o.idfChangeDiagnosisHistory = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfChangeDiagnosisHistory != c.idfChangeDiagnosisHistory || o.IsRIRPropChanged(_str_idfChangeDiagnosisHistory, c)) 
                  m.Add(_str_idfChangeDiagnosisHistory, o.ObjectIdent + _str_idfChangeDiagnosisHistory, o.ObjectIdent2 + _str_idfChangeDiagnosisHistory, o.ObjectIdent3 + _str_idfChangeDiagnosisHistory, "Int64", 
                    o.idfChangeDiagnosisHistory == null ? "" : o.idfChangeDiagnosisHistory.ToString(),                  
                  o.IsReadOnly(_str_idfChangeDiagnosisHistory), o.IsInvisible(_str_idfChangeDiagnosisHistory), o.IsRequired(_str_idfChangeDiagnosisHistory)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfHumanCase, _formname = _str_idfHumanCase, _type = "Int64",
              _get_func = o => o.idfHumanCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfHumanCase != newval) o.idfHumanCase = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfHumanCase != c.idfHumanCase || o.IsRIRPropChanged(_str_idfHumanCase, c)) 
                  m.Add(_str_idfHumanCase, o.ObjectIdent + _str_idfHumanCase, o.ObjectIdent2 + _str_idfHumanCase, o.ObjectIdent3 + _str_idfHumanCase, "Int64", 
                    o.idfHumanCase == null ? "" : o.idfHumanCase.ToString(),                  
                  o.IsReadOnly(_str_idfHumanCase), o.IsInvisible(_str_idfHumanCase), o.IsRequired(_str_idfHumanCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsPreviousDiagnosis, _formname = _str_idfsPreviousDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsPreviousDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsPreviousDiagnosis != newval) 
                  o.PreviousDiagnosis = o.PreviousDiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsPreviousDiagnosis != newval) o.idfsPreviousDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsPreviousDiagnosis != c.idfsPreviousDiagnosis || o.IsRIRPropChanged(_str_idfsPreviousDiagnosis, c)) 
                  m.Add(_str_idfsPreviousDiagnosis, o.ObjectIdent + _str_idfsPreviousDiagnosis, o.ObjectIdent2 + _str_idfsPreviousDiagnosis, o.ObjectIdent3 + _str_idfsPreviousDiagnosis, "Int64?", 
                    o.idfsPreviousDiagnosis == null ? "" : o.idfsPreviousDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsPreviousDiagnosis), o.IsInvisible(_str_idfsPreviousDiagnosis), o.IsRequired(_str_idfsPreviousDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCurrentDiagnosis, _formname = _str_idfsCurrentDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsCurrentDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsCurrentDiagnosis != newval) 
                  o.CurrentDiagnosis = o.CurrentDiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsCurrentDiagnosis != newval) o.idfsCurrentDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsCurrentDiagnosis != c.idfsCurrentDiagnosis || o.IsRIRPropChanged(_str_idfsCurrentDiagnosis, c)) 
                  m.Add(_str_idfsCurrentDiagnosis, o.ObjectIdent + _str_idfsCurrentDiagnosis, o.ObjectIdent2 + _str_idfsCurrentDiagnosis, o.ObjectIdent3 + _str_idfsCurrentDiagnosis, "Int64?", 
                    o.idfsCurrentDiagnosis == null ? "" : o.idfsCurrentDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsCurrentDiagnosis), o.IsInvisible(_str_idfsCurrentDiagnosis), o.IsRequired(_str_idfsCurrentDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datChangedDate, _formname = _str_datChangedDate, _type = "DateTime",
              _get_func = o => o.datChangedDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTime(val); if (o.datChangedDate != newval) o.datChangedDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datChangedDate != c.datChangedDate || o.IsRIRPropChanged(_str_datChangedDate, c)) 
                  m.Add(_str_datChangedDate, o.ObjectIdent + _str_datChangedDate, o.ObjectIdent2 + _str_datChangedDate, o.ObjectIdent3 + _str_datChangedDate, "DateTime", 
                    o.datChangedDate == null ? "" : o.datChangedDate.ToString(),                  
                  o.IsReadOnly(_str_datChangedDate), o.IsInvisible(_str_datChangedDate), o.IsRequired(_str_datChangedDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsChangeDiagnosisReason, _formname = _str_idfsChangeDiagnosisReason, _type = "Int64?",
              _get_func = o => o.idfsChangeDiagnosisReason,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsChangeDiagnosisReason != newval) 
                  o.ChangeDiagnosisReason = o.ChangeDiagnosisReasonLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsChangeDiagnosisReason != newval) o.idfsChangeDiagnosisReason = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsChangeDiagnosisReason != c.idfsChangeDiagnosisReason || o.IsRIRPropChanged(_str_idfsChangeDiagnosisReason, c)) 
                  m.Add(_str_idfsChangeDiagnosisReason, o.ObjectIdent + _str_idfsChangeDiagnosisReason, o.ObjectIdent2 + _str_idfsChangeDiagnosisReason, o.ObjectIdent3 + _str_idfsChangeDiagnosisReason, "Int64?", 
                    o.idfsChangeDiagnosisReason == null ? "" : o.idfsChangeDiagnosisReason.ToString(),                  
                  o.IsReadOnly(_str_idfsChangeDiagnosisReason), o.IsInvisible(_str_idfsChangeDiagnosisReason), o.IsRequired(_str_idfsChangeDiagnosisReason)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strReason, _formname = _str_strReason, _type = "String",
              _get_func = o => o.strReason,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strReason != newval) o.strReason = newval; },
              _compare_func = (o, c, m) => {
                if (o.strReason != c.strReason || o.IsRIRPropChanged(_str_strReason, c)) 
                  m.Add(_str_strReason, o.ObjectIdent + _str_strReason, o.ObjectIdent2 + _str_strReason, o.ObjectIdent3 + _str_strReason, "String", 
                    o.strReason == null ? "" : o.strReason.ToString(),                  
                  o.IsReadOnly(_str_strReason), o.IsInvisible(_str_strReason), o.IsRequired(_str_strReason)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfPerson, _formname = _str_idfPerson, _type = "Int64",
              _get_func = o => o.idfPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfPerson != newval) o.idfPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfPerson != c.idfPerson || o.IsRIRPropChanged(_str_idfPerson, c)) 
                  m.Add(_str_idfPerson, o.ObjectIdent + _str_idfPerson, o.ObjectIdent2 + _str_idfPerson, o.ObjectIdent3 + _str_idfPerson, "Int64", 
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
              _name = _str_Organization, _formname = _str_Organization, _type = "String",
              _get_func = o => o.Organization,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.Organization != newval) o.Organization = newval; },
              _compare_func = (o, c, m) => {
                if (o.Organization != c.Organization || o.IsRIRPropChanged(_str_Organization, c)) 
                  m.Add(_str_Organization, o.ObjectIdent + _str_Organization, o.ObjectIdent2 + _str_Organization, o.ObjectIdent3 + _str_Organization, "String", 
                    o.Organization == null ? "" : o.Organization.ToString(),                  
                  o.IsReadOnly(_str_Organization), o.IsInvisible(_str_Organization), o.IsRequired(_str_Organization)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_PreviousDiagnosisName, _formname = _str_PreviousDiagnosisName, _type = "String",
              _get_func = o => o.PreviousDiagnosisName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.PreviousDiagnosisName != newval) o.PreviousDiagnosisName = newval; },
              _compare_func = (o, c, m) => {
                if (o.PreviousDiagnosisName != c.PreviousDiagnosisName || o.IsRIRPropChanged(_str_PreviousDiagnosisName, c)) 
                  m.Add(_str_PreviousDiagnosisName, o.ObjectIdent + _str_PreviousDiagnosisName, o.ObjectIdent2 + _str_PreviousDiagnosisName, o.ObjectIdent3 + _str_PreviousDiagnosisName, "String", 
                    o.PreviousDiagnosisName == null ? "" : o.PreviousDiagnosisName.ToString(),                  
                  o.IsReadOnly(_str_PreviousDiagnosisName), o.IsInvisible(_str_PreviousDiagnosisName), o.IsRequired(_str_PreviousDiagnosisName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_CurrentDiagnosisName, _formname = _str_CurrentDiagnosisName, _type = "String",
              _get_func = o => o.CurrentDiagnosisName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.CurrentDiagnosisName != newval) o.CurrentDiagnosisName = newval; },
              _compare_func = (o, c, m) => {
                if (o.CurrentDiagnosisName != c.CurrentDiagnosisName || o.IsRIRPropChanged(_str_CurrentDiagnosisName, c)) 
                  m.Add(_str_CurrentDiagnosisName, o.ObjectIdent + _str_CurrentDiagnosisName, o.ObjectIdent2 + _str_CurrentDiagnosisName, o.ObjectIdent3 + _str_CurrentDiagnosisName, "String", 
                    o.CurrentDiagnosisName == null ? "" : o.CurrentDiagnosisName.ToString(),                  
                  o.IsReadOnly(_str_CurrentDiagnosisName), o.IsInvisible(_str_CurrentDiagnosisName), o.IsRequired(_str_CurrentDiagnosisName)); 
                  }
              }, 
        
            new field_info {
              _name = _str_PreviousDiagnosis, _formname = _str_PreviousDiagnosis, _type = "Lookup",
              _get_func = o => { if (o.PreviousDiagnosis == null) return null; return o.PreviousDiagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.PreviousDiagnosis = o.PreviousDiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsPreviousDiagnosis != c.idfsPreviousDiagnosis || o.IsRIRPropChanged(_str_PreviousDiagnosis, c)) {
                  m.Add(_str_PreviousDiagnosis, o.ObjectIdent + _str_PreviousDiagnosis, o.ObjectIdent2 + _str_PreviousDiagnosis, o.ObjectIdent3 + _str_PreviousDiagnosis, "Lookup", o.idfsPreviousDiagnosis == null ? "" : o.idfsPreviousDiagnosis.ToString(), o.IsReadOnly(_str_PreviousDiagnosis), o.IsInvisible(_str_PreviousDiagnosis), o.IsRequired(_str_PreviousDiagnosis)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_PreviousDiagnosis + "Lookup", _formname = _str_PreviousDiagnosis + "Lookup", _type = "LookupContent",
              _get_func = o => o.PreviousDiagnosisLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_CurrentDiagnosis, _formname = _str_CurrentDiagnosis, _type = "Lookup",
              _get_func = o => { if (o.CurrentDiagnosis == null) return null; return o.CurrentDiagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.CurrentDiagnosis = o.CurrentDiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCurrentDiagnosis != c.idfsCurrentDiagnosis || o.IsRIRPropChanged(_str_CurrentDiagnosis, c)) {
                  m.Add(_str_CurrentDiagnosis, o.ObjectIdent + _str_CurrentDiagnosis, o.ObjectIdent2 + _str_CurrentDiagnosis, o.ObjectIdent3 + _str_CurrentDiagnosis, "Lookup", o.idfsCurrentDiagnosis == null ? "" : o.idfsCurrentDiagnosis.ToString(), o.IsReadOnly(_str_CurrentDiagnosis), o.IsInvisible(_str_CurrentDiagnosis), o.IsRequired(_str_CurrentDiagnosis)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_CurrentDiagnosis + "Lookup", _formname = _str_CurrentDiagnosis + "Lookup", _type = "LookupContent",
              _get_func = o => o.CurrentDiagnosisLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_ChangeDiagnosisReason, _formname = _str_ChangeDiagnosisReason, _type = "Lookup",
              _get_func = o => { if (o.ChangeDiagnosisReason == null) return null; return o.ChangeDiagnosisReason.idfsBaseReference; },
              _set_func = (o, val) => { o.ChangeDiagnosisReason = o.ChangeDiagnosisReasonLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsChangeDiagnosisReason != c.idfsChangeDiagnosisReason || o.IsRIRPropChanged(_str_ChangeDiagnosisReason, c)) {
                  m.Add(_str_ChangeDiagnosisReason, o.ObjectIdent + _str_ChangeDiagnosisReason, o.ObjectIdent2 + _str_ChangeDiagnosisReason, o.ObjectIdent3 + _str_ChangeDiagnosisReason, "Lookup", o.idfsChangeDiagnosisReason == null ? "" : o.idfsChangeDiagnosisReason.ToString(), o.IsReadOnly(_str_ChangeDiagnosisReason), o.IsInvisible(_str_ChangeDiagnosisReason), o.IsRequired(_str_ChangeDiagnosisReason)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_ChangeDiagnosisReason + "Lookup", _formname = _str_ChangeDiagnosisReason + "Lookup", _type = "LookupContent",
              _get_func = o => o.ChangeDiagnosisReasonLookup,
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
            ChangeDiagnosisHistory obj = (ChangeDiagnosisHistory)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_PreviousDiagnosis)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsPreviousDiagnosis)]
        public DiagnosisLookup PreviousDiagnosis
        {
            get { return _PreviousDiagnosis == null ? null : ((long)_PreviousDiagnosis.Key == 0 ? null : _PreviousDiagnosis); }
            set 
            { 
                var oldVal = _PreviousDiagnosis;
                _PreviousDiagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_PreviousDiagnosis != oldVal)
                {
                    if (idfsPreviousDiagnosis != (_PreviousDiagnosis == null
                            ? new Int64?()
                            : (Int64?)_PreviousDiagnosis.idfsDiagnosis))
                        idfsPreviousDiagnosis = _PreviousDiagnosis == null 
                            ? new Int64?()
                            : (Int64?)_PreviousDiagnosis.idfsDiagnosis; 
                    OnPropertyChanged(_str_PreviousDiagnosis); 
                }
            }
        }
        private DiagnosisLookup _PreviousDiagnosis;

        
        public List<DiagnosisLookup> PreviousDiagnosisLookup
        {
            get { return _PreviousDiagnosisLookup; }
        }
        private List<DiagnosisLookup> _PreviousDiagnosisLookup = new List<DiagnosisLookup>();
            
        [LocalizedDisplayName(_str_CurrentDiagnosis)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsCurrentDiagnosis)]
        public DiagnosisLookup CurrentDiagnosis
        {
            get { return _CurrentDiagnosis == null ? null : ((long)_CurrentDiagnosis.Key == 0 ? null : _CurrentDiagnosis); }
            set 
            { 
                var oldVal = _CurrentDiagnosis;
                _CurrentDiagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_CurrentDiagnosis != oldVal)
                {
                    if (idfsCurrentDiagnosis != (_CurrentDiagnosis == null
                            ? new Int64?()
                            : (Int64?)_CurrentDiagnosis.idfsDiagnosis))
                        idfsCurrentDiagnosis = _CurrentDiagnosis == null 
                            ? new Int64?()
                            : (Int64?)_CurrentDiagnosis.idfsDiagnosis; 
                    OnPropertyChanged(_str_CurrentDiagnosis); 
                }
            }
        }
        private DiagnosisLookup _CurrentDiagnosis;

        
        public List<DiagnosisLookup> CurrentDiagnosisLookup
        {
            get { return _CurrentDiagnosisLookup; }
        }
        private List<DiagnosisLookup> _CurrentDiagnosisLookup = new List<DiagnosisLookup>();
            
        [LocalizedDisplayName(_str_ChangeDiagnosisReason)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsChangeDiagnosisReason)]
        public BaseReference ChangeDiagnosisReason
        {
            get { return _ChangeDiagnosisReason == null ? null : ((long)_ChangeDiagnosisReason.Key == 0 ? null : _ChangeDiagnosisReason); }
            set 
            { 
                var oldVal = _ChangeDiagnosisReason;
                _ChangeDiagnosisReason = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_ChangeDiagnosisReason != oldVal)
                {
                    if (idfsChangeDiagnosisReason != (_ChangeDiagnosisReason == null
                            ? new Int64?()
                            : (Int64?)_ChangeDiagnosisReason.idfsBaseReference))
                        idfsChangeDiagnosisReason = _ChangeDiagnosisReason == null 
                            ? new Int64?()
                            : (Int64?)_ChangeDiagnosisReason.idfsBaseReference; 
                    OnPropertyChanged(_str_ChangeDiagnosisReason); 
                }
            }
        }
        private BaseReference _ChangeDiagnosisReason;

        
        public BaseReferenceList ChangeDiagnosisReasonLookup
        {
            get { return _ChangeDiagnosisReasonLookup; }
        }
        private BaseReferenceList _ChangeDiagnosisReasonLookup = new BaseReferenceList("rftChangeDiagnosisReason");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_PreviousDiagnosis:
                    return new BvSelectList(PreviousDiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, PreviousDiagnosis, _str_idfsPreviousDiagnosis);
            
                case _str_CurrentDiagnosis:
                    return new BvSelectList(CurrentDiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, CurrentDiagnosis, _str_idfsCurrentDiagnosis);
            
                case _str_ChangeDiagnosisReason:
                    return new BvSelectList(ChangeDiagnosisReasonLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, ChangeDiagnosisReason, _str_idfsChangeDiagnosisReason);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "ChangeDiagnosisHistory";

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
            var ret = base.Clone() as ChangeDiagnosisHistory;
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
            var ret = base.Clone() as ChangeDiagnosisHistory;
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
        public ChangeDiagnosisHistory CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as ChangeDiagnosisHistory;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfChangeDiagnosisHistory; } }
        public string KeyName { get { return "idfChangeDiagnosisHistory"; } }
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
        
            var _prev_idfsPreviousDiagnosis_PreviousDiagnosis = idfsPreviousDiagnosis;
            var _prev_idfsCurrentDiagnosis_CurrentDiagnosis = idfsCurrentDiagnosis;
            var _prev_idfsChangeDiagnosisReason_ChangeDiagnosisReason = idfsChangeDiagnosisReason;
            base.RejectChanges();
        
            if (_prev_idfsPreviousDiagnosis_PreviousDiagnosis != idfsPreviousDiagnosis)
            {
                _PreviousDiagnosis = _PreviousDiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsPreviousDiagnosis);
            }
            if (_prev_idfsCurrentDiagnosis_CurrentDiagnosis != idfsCurrentDiagnosis)
            {
                _CurrentDiagnosis = _CurrentDiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsCurrentDiagnosis);
            }
            if (_prev_idfsChangeDiagnosisReason_ChangeDiagnosisReason != idfsChangeDiagnosisReason)
            {
                _ChangeDiagnosisReason = _ChangeDiagnosisReasonLookup.FirstOrDefault(c => c.idfsBaseReference == idfsChangeDiagnosisReason);
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

        private bool IsRIRPropChanged(string fld, ChangeDiagnosisHistory c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public ChangeDiagnosisHistory()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ChangeDiagnosisHistory_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(ChangeDiagnosisHistory_PropertyChanged);
        }
        private void ChangeDiagnosisHistory_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as ChangeDiagnosisHistory).Changed(e.PropertyName);
            
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
            ChangeDiagnosisHistory obj = this;
            
        }
        private void _DeletedExtenders()
        {
            ChangeDiagnosisHistory obj = this;
            
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


        internal Dictionary<string, Func<ChangeDiagnosisHistory, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<ChangeDiagnosisHistory, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<ChangeDiagnosisHistory, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<ChangeDiagnosisHistory, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<ChangeDiagnosisHistory, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<ChangeDiagnosisHistory, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<ChangeDiagnosisHistory, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~ChangeDiagnosisHistory()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftChangeDiagnosisReason", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_PreviousDiagnosis(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_CurrentDiagnosis(manager, this);
            
            if (lookup_object == "rftChangeDiagnosisReason")
                _getAccessor().LoadLookup_ChangeDiagnosisReason(manager, this);
            
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
        public class ChangeDiagnosisHistoryGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfChangeDiagnosisHistory { get; set; }
        
            public DateTime datChangedDate { get; set; }
        
            public String strPersonName { get; set; }
        
            public String Organization { get; set; }
        
            public String PreviousDiagnosisName { get; set; }
        
            public String CurrentDiagnosisName { get; set; }
        
            public String strReason { get; set; }
        
        }
        public partial class ChangeDiagnosisHistoryGridModelList : List<ChangeDiagnosisHistoryGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public ChangeDiagnosisHistoryGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<ChangeDiagnosisHistory>, errMes);
            }
            public ChangeDiagnosisHistoryGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<ChangeDiagnosisHistory>, errMes);
            }
            public ChangeDiagnosisHistoryGridModelList(long key, IEnumerable<ChangeDiagnosisHistory> items)
            {
                LoadGridModelList(key, items, null);
            }
            public ChangeDiagnosisHistoryGridModelList(long key)
            {
                LoadGridModelList(key, new List<ChangeDiagnosisHistory>(), null);
            }
            partial void filter(List<ChangeDiagnosisHistory> items);
            private void LoadGridModelList(long key, IEnumerable<ChangeDiagnosisHistory> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_datChangedDate,_str_strPersonName,_str_Organization,_str_PreviousDiagnosisName,_str_CurrentDiagnosisName,_str_strReason};
                    
                Hiddens = new List<string> {_str_idfChangeDiagnosisHistory};
                Keys = new List<string> {_str_idfChangeDiagnosisHistory};
                Labels = new Dictionary<string, string> {{_str_datChangedDate, _str_datChangedDate},{_str_strPersonName, "strChangedByPerson"},{_str_Organization, "strChangedByOrganization"},{_str_PreviousDiagnosisName, _str_PreviousDiagnosisName},{_str_CurrentDiagnosisName, _str_CurrentDiagnosisName},{_str_strReason, "idfsChangeDiagnosisReason"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                ChangeDiagnosisHistory.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<ChangeDiagnosisHistory>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new ChangeDiagnosisHistoryGridModel()
                {
                    ItemKey=c.idfChangeDiagnosisHistory,datChangedDate=c.datChangedDate,strPersonName=c.strPersonName,Organization=c.Organization,PreviousDiagnosisName=c.PreviousDiagnosisName,CurrentDiagnosisName=c.CurrentDiagnosisName,strReason=c.strReason
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
        : DataAccessor<ChangeDiagnosisHistory>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<ChangeDiagnosisHistory>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfChangeDiagnosisHistory"; } }
            #endregion
        
            private delegate void on_action(ChangeDiagnosisHistory obj);
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
            private DiagnosisLookup.Accessor PreviousDiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor CurrentDiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor ChangeDiagnosisReasonAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<ChangeDiagnosisHistory> SelectList(DbManagerProxy manager
                , Int64? idfCase
                )
            {
                return _SelectList(manager
                    , idfCase
                    , delegate(ChangeDiagnosisHistory obj)
                        {
                        }
                    , delegate(ChangeDiagnosisHistory obj)
                        {
                        }
                    );
            }

            
            private List<ChangeDiagnosisHistory> _SelectList(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<ChangeDiagnosisHistory> objs = new List<ChangeDiagnosisHistory>();
                    sets[0] = new MapResultSet(typeof(ChangeDiagnosisHistory), objs);
                    
                    manager
                        .SetSpCommand("spChangeDiagnosisHistory_SelectDetail"
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, ChangeDiagnosisHistory obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, ChangeDiagnosisHistory obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private ChangeDiagnosisHistory _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    ChangeDiagnosisHistory obj = ChangeDiagnosisHistory.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfChangeDiagnosisHistory = (new GetNewIDExtender<ChangeDiagnosisHistory>()).GetScalar(manager, obj, isFake);
                obj.datChangedDate = DateTime.Now;
                obj.idfPerson = ModelUserContext.Instance == null ? 0 : (long)ModelUserContext.Instance.CurrentUser.EmployeeID;
                obj.strPersonName = ModelUserContext.Instance == null ? null : ModelUserContext.Instance.CurrentUser.FullName;
                obj.Organization = ModelUserContext.Instance == null ? null : ModelUserContext.Instance.CurrentUser.Organization;
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

            
            public ChangeDiagnosisHistory CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public ChangeDiagnosisHistory CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public ChangeDiagnosisHistory CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ChangeDiagnosisHistory CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfHumanCase", typeof(long));
                if (pars[1] != null && !(pars[1] is long?)) 
                    throw new TypeMismatchException("idfsPreviousDiagnosis", typeof(long?));
                if (pars[2] != null && !(pars[2] is long?)) 
                    throw new TypeMismatchException("idfsCurrentDiagnosis", typeof(long?));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    , (long?)pars[1]
                    , (long?)pars[2]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public ChangeDiagnosisHistory Create(DbManagerProxy manager, IObject Parent
                , long idfHumanCase
                , long? idfsPreviousDiagnosis
                , long? idfsCurrentDiagnosis
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfHumanCase = idfHumanCase;
                }
                    , obj =>
                {
                obj.PreviousDiagnosis = obj.PreviousDiagnosisLookup.Where(a => a.idfsDiagnosis == idfsPreviousDiagnosis).SingleOrDefault();
                obj.CurrentDiagnosis = obj.CurrentDiagnosisLookup.Where(a => a.idfsDiagnosis == idfsCurrentDiagnosis).SingleOrDefault();
                }
                );
            }
            
            private void _SetupChildHandlers(ChangeDiagnosisHistory obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(ChangeDiagnosisHistory obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsPreviousDiagnosis)
                        {
                    
                obj.PreviousDiagnosisName = new Func<ChangeDiagnosisHistory, string>(c => c.PreviousDiagnosis == null ? string.Empty : c.PreviousDiagnosis.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsCurrentDiagnosis)
                        {
                    
                obj.CurrentDiagnosisName = new Func<ChangeDiagnosisHistory, string>(c => c.CurrentDiagnosis == null ? string.Empty : c.CurrentDiagnosis.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsChangeDiagnosisReason)
                        {
                    
                obj.strReason = new Func<ChangeDiagnosisHistory, string>(c => c.ChangeDiagnosisReason == null ? string.Empty : c.ChangeDiagnosisReason.name)(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_PreviousDiagnosis(DbManagerProxy manager, ChangeDiagnosisHistory obj)
            {
                
                obj.PreviousDiagnosisLookup.Clear();
                
                obj.PreviousDiagnosisLookup.Add(PreviousDiagnosisAccessor.CreateNewT(manager, null));
                
                obj.PreviousDiagnosisLookup.AddRange(PreviousDiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.Human) != 0) || c.idfsDiagnosis == obj.idfsPreviousDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsPreviousDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsPreviousDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsPreviousDiagnosis != null && obj.idfsPreviousDiagnosis != 0)
                {
                    obj.PreviousDiagnosis = obj.PreviousDiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsPreviousDiagnosis);
                    
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, PreviousDiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_CurrentDiagnosis(DbManagerProxy manager, ChangeDiagnosisHistory obj)
            {
                
                obj.CurrentDiagnosisLookup.Clear();
                
                obj.CurrentDiagnosisLookup.Add(CurrentDiagnosisAccessor.CreateNewT(manager, null));
                
                obj.CurrentDiagnosisLookup.AddRange(CurrentDiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.Human) != 0) || c.idfsDiagnosis == obj.idfsCurrentDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsCurrentDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsCurrentDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsCurrentDiagnosis != null && obj.idfsCurrentDiagnosis != 0)
                {
                    obj.CurrentDiagnosis = obj.CurrentDiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsCurrentDiagnosis);
                    
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, CurrentDiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_ChangeDiagnosisReason(DbManagerProxy manager, ChangeDiagnosisHistory obj)
            {
                
                obj.ChangeDiagnosisReasonLookup.Clear();
                
                obj.ChangeDiagnosisReasonLookup.Add(ChangeDiagnosisReasonAccessor.CreateNewT(manager, null));
                
                obj.ChangeDiagnosisReasonLookup.AddRange(ChangeDiagnosisReasonAccessor.rftChangeDiagnosisReason_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsChangeDiagnosisReason))
                    
                    .ToList());
                
                if (obj.idfsChangeDiagnosisReason != null && obj.idfsChangeDiagnosisReason != 0)
                {
                    obj.ChangeDiagnosisReason = obj.ChangeDiagnosisReasonLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsChangeDiagnosisReason);
                    
                }
              
                
                LookupManager.AddObject("rftChangeDiagnosisReason", obj, ChangeDiagnosisReasonAccessor.GetType(), "rftChangeDiagnosisReason_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, ChangeDiagnosisHistory obj)
            {
                
                LoadLookup_PreviousDiagnosis(manager, obj);
                
                LoadLookup_CurrentDiagnosis(manager, obj);
                
                LoadLookup_ChangeDiagnosisReason(manager, obj);
                
            }
    
            [SprocName("spChangeDiagnosisHistory_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] ChangeDiagnosisHistory obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] ChangeDiagnosisHistory obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    ChangeDiagnosisHistory bo = obj as ChangeDiagnosisHistory;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as ChangeDiagnosisHistory, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, ChangeDiagnosisHistory obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
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
            
                    if (!obj.IsMarkedToDelete && bHasChanges)
                        _postPredicate(manager, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(ChangeDiagnosisHistory obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, ChangeDiagnosisHistory obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(ChangeDiagnosisHistory obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(ChangeDiagnosisHistory obj, bool bRethrowException)
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
                return Validate(manager, obj as ChangeDiagnosisHistory, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, ChangeDiagnosisHistory obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(ChangeDiagnosisHistory obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(ChangeDiagnosisHistory obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as ChangeDiagnosisHistory) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as ChangeDiagnosisHistory) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "ChangeDiagnosisHistoryDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spChangeDiagnosisHistory_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spChangeDiagnosisHistory_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<ChangeDiagnosisHistory, bool>> RequiredByField = new Dictionary<string, Func<ChangeDiagnosisHistory, bool>>();
            public static Dictionary<string, Func<ChangeDiagnosisHistory, bool>> RequiredByProperty = new Dictionary<string, Func<ChangeDiagnosisHistory, bool>>();
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
                
                Sizes.Add(_str_strReason, 2000);
                Sizes.Add(_str_strPersonName, 602);
                Sizes.Add(_str_Organization, 2000);
                Sizes.Add(_str_PreviousDiagnosisName, 2000);
                Sizes.Add(_str_CurrentDiagnosisName, 2000);
                GridMeta.Add(new GridMetaItem(
                    _str_idfChangeDiagnosisHistory,
                    _str_idfChangeDiagnosisHistory, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datChangedDate,
                    _str_datChangedDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPersonName,
                    "strChangedByPerson", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Organization,
                    "strChangedByOrganization", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_PreviousDiagnosisName,
                    _str_PreviousDiagnosisName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_CurrentDiagnosisName,
                    _str_CurrentDiagnosisName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strReason,
                    "idfsChangeDiagnosisReason", null, true, true, true, true, null
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
                    (manager, c, pars) => ((ChangeDiagnosisHistory)c).MarkToDelete(),
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
	