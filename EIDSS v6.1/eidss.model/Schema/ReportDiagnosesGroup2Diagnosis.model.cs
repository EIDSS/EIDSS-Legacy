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
		

namespace eidss.model.Schema
{
        
        
    [XmlType(AnonymousType = true)]
    public abstract partial class ReportDiagnosesGroup2Diagnosis : 
        EditableObject<ReportDiagnosesGroup2Diagnosis>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfDiagnosisToGroupForReportType), NonUpdatable, PrimaryKey]
        public abstract Int64 idfDiagnosisToGroupForReportType { get; set; }
                
        [LocalizedDisplayName(_str_idfsCustomReportType)]
        [MapField(_str_idfsCustomReportType)]
        public abstract Int64 idfsCustomReportType { get; set; }
        protected Int64 idfsCustomReportType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCustomReportType).OriginalValue; } }
        protected Int64 idfsCustomReportType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCustomReportType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSummaryReportType)]
        [MapField(_str_strSummaryReportType)]
        public abstract String strSummaryReportType { get; set; }
        protected String strSummaryReportType_Original { get { return ((EditableValue<String>)((dynamic)this)._strSummaryReportType).OriginalValue; } }
        protected String strSummaryReportType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSummaryReportType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsReportDiagnosisGroup)]
        [MapField(_str_idfsReportDiagnosisGroup)]
        public abstract Int64 idfsReportDiagnosisGroup { get; set; }
        protected Int64 idfsReportDiagnosisGroup_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsReportDiagnosisGroup).OriginalValue; } }
        protected Int64 idfsReportDiagnosisGroup_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsReportDiagnosisGroup).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strReportDiagnosisGroup)]
        [MapField(_str_strReportDiagnosisGroup)]
        public abstract String strReportDiagnosisGroup { get; set; }
        protected String strReportDiagnosisGroup_Original { get { return ((EditableValue<String>)((dynamic)this)._strReportDiagnosisGroup).OriginalValue; } }
        protected String strReportDiagnosisGroup_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReportDiagnosisGroup).PreviousValue; } }
                
        [LocalizedDisplayName("strDiagnosisName")]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64 idfsDiagnosis { get; set; }
        protected Int64 idfsDiagnosis_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64 idfsDiagnosis_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDiagnosis)]
        [MapField(_str_strDiagnosis)]
        public abstract String strDiagnosis { get; set; }
        protected String strDiagnosis_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosis).OriginalValue; } }
        protected String strDiagnosis_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int32? intHACode { get; set; }
        protected Int32? intHACode_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32? intHACode_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsUsingType)]
        [MapField(_str_idfsUsingType)]
        public abstract Int64 idfsUsingType { get; set; }
        protected Int64 idfsUsingType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUsingType).OriginalValue; } }
        protected Int64 idfsUsingType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUsingType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strUsingType)]
        [MapField(_str_strUsingType)]
        public abstract String strUsingType { get; set; }
        protected String strUsingType_Original { get { return ((EditableValue<String>)((dynamic)this)._strUsingType).OriginalValue; } }
        protected String strUsingType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strUsingType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHACode)]
        [MapField(_str_strHACode)]
        public abstract String strHACode { get; set; }
        protected String strHACode_Original { get { return ((EditableValue<String>)((dynamic)this)._strHACode).OriginalValue; } }
        protected String strHACode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHACode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intIsDeleted)]
        [MapField(_str_intIsDeleted)]
        public abstract Int64 intIsDeleted { get; set; }
        protected Int64 intIsDeleted_Original { get { return ((EditableValue<Int64>)((dynamic)this)._intIsDeleted).OriginalValue; } }
        protected Int64 intIsDeleted_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._intIsDeleted).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strIsDeleted)]
        [MapField(_str_strIsDeleted)]
        public abstract String strIsDeleted { get; set; }
        protected String strIsDeleted_Original { get { return ((EditableValue<String>)((dynamic)this)._strIsDeleted).OriginalValue; } }
        protected String strIsDeleted_Previous { get { return ((EditableValue<String>)((dynamic)this)._strIsDeleted).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<ReportDiagnosesGroup2Diagnosis, object> _get_func;
            internal Action<ReportDiagnosesGroup2Diagnosis, string> _set_func;
            internal Action<ReportDiagnosesGroup2Diagnosis, ReportDiagnosesGroup2Diagnosis, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfDiagnosisToGroupForReportType = "idfDiagnosisToGroupForReportType";
        internal const string _str_idfsCustomReportType = "idfsCustomReportType";
        internal const string _str_strSummaryReportType = "strSummaryReportType";
        internal const string _str_idfsReportDiagnosisGroup = "idfsReportDiagnosisGroup";
        internal const string _str_strReportDiagnosisGroup = "strReportDiagnosisGroup";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_strDiagnosis = "strDiagnosis";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_idfsUsingType = "idfsUsingType";
        internal const string _str_strUsingType = "strUsingType";
        internal const string _str_strHACode = "strHACode";
        internal const string _str_intIsDeleted = "intIsDeleted";
        internal const string _str_strIsDeleted = "strIsDeleted";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_YNU = "YNU";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfDiagnosisToGroupForReportType, _formname = _str_idfDiagnosisToGroupForReportType, _type = "Int64",
              _get_func = o => o.idfDiagnosisToGroupForReportType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfDiagnosisToGroupForReportType != newval) o.idfDiagnosisToGroupForReportType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfDiagnosisToGroupForReportType != c.idfDiagnosisToGroupForReportType || o.IsRIRPropChanged(_str_idfDiagnosisToGroupForReportType, c)) 
                  m.Add(_str_idfDiagnosisToGroupForReportType, o.ObjectIdent + _str_idfDiagnosisToGroupForReportType, o.ObjectIdent2 + _str_idfDiagnosisToGroupForReportType, o.ObjectIdent3 + _str_idfDiagnosisToGroupForReportType, "Int64", 
                    o.idfDiagnosisToGroupForReportType == null ? "" : o.idfDiagnosisToGroupForReportType.ToString(),                  
                  o.IsReadOnly(_str_idfDiagnosisToGroupForReportType), o.IsInvisible(_str_idfDiagnosisToGroupForReportType), o.IsRequired(_str_idfDiagnosisToGroupForReportType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCustomReportType, _formname = _str_idfsCustomReportType, _type = "Int64",
              _get_func = o => o.idfsCustomReportType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsCustomReportType != newval) o.idfsCustomReportType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCustomReportType != c.idfsCustomReportType || o.IsRIRPropChanged(_str_idfsCustomReportType, c)) 
                  m.Add(_str_idfsCustomReportType, o.ObjectIdent + _str_idfsCustomReportType, o.ObjectIdent2 + _str_idfsCustomReportType, o.ObjectIdent3 + _str_idfsCustomReportType, "Int64", 
                    o.idfsCustomReportType == null ? "" : o.idfsCustomReportType.ToString(),                  
                  o.IsReadOnly(_str_idfsCustomReportType), o.IsInvisible(_str_idfsCustomReportType), o.IsRequired(_str_idfsCustomReportType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSummaryReportType, _formname = _str_strSummaryReportType, _type = "String",
              _get_func = o => o.strSummaryReportType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSummaryReportType != newval) o.strSummaryReportType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSummaryReportType != c.strSummaryReportType || o.IsRIRPropChanged(_str_strSummaryReportType, c)) 
                  m.Add(_str_strSummaryReportType, o.ObjectIdent + _str_strSummaryReportType, o.ObjectIdent2 + _str_strSummaryReportType, o.ObjectIdent3 + _str_strSummaryReportType, "String", 
                    o.strSummaryReportType == null ? "" : o.strSummaryReportType.ToString(),                  
                  o.IsReadOnly(_str_strSummaryReportType), o.IsInvisible(_str_strSummaryReportType), o.IsRequired(_str_strSummaryReportType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsReportDiagnosisGroup, _formname = _str_idfsReportDiagnosisGroup, _type = "Int64",
              _get_func = o => o.idfsReportDiagnosisGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsReportDiagnosisGroup != newval) o.idfsReportDiagnosisGroup = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsReportDiagnosisGroup != c.idfsReportDiagnosisGroup || o.IsRIRPropChanged(_str_idfsReportDiagnosisGroup, c)) 
                  m.Add(_str_idfsReportDiagnosisGroup, o.ObjectIdent + _str_idfsReportDiagnosisGroup, o.ObjectIdent2 + _str_idfsReportDiagnosisGroup, o.ObjectIdent3 + _str_idfsReportDiagnosisGroup, "Int64", 
                    o.idfsReportDiagnosisGroup == null ? "" : o.idfsReportDiagnosisGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsReportDiagnosisGroup), o.IsInvisible(_str_idfsReportDiagnosisGroup), o.IsRequired(_str_idfsReportDiagnosisGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strReportDiagnosisGroup, _formname = _str_strReportDiagnosisGroup, _type = "String",
              _get_func = o => o.strReportDiagnosisGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strReportDiagnosisGroup != newval) o.strReportDiagnosisGroup = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strReportDiagnosisGroup != c.strReportDiagnosisGroup || o.IsRIRPropChanged(_str_strReportDiagnosisGroup, c)) 
                  m.Add(_str_strReportDiagnosisGroup, o.ObjectIdent + _str_strReportDiagnosisGroup, o.ObjectIdent2 + _str_strReportDiagnosisGroup, o.ObjectIdent3 + _str_strReportDiagnosisGroup, "String", 
                    o.strReportDiagnosisGroup == null ? "" : o.strReportDiagnosisGroup.ToString(),                  
                  o.IsReadOnly(_str_strReportDiagnosisGroup), o.IsInvisible(_str_strReportDiagnosisGroup), o.IsRequired(_str_strReportDiagnosisGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "Int64",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsDiagnosis != newval) 
                  o.Diagnosis = o.DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis, "Int64", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDiagnosis, _formname = _str_strDiagnosis, _type = "String",
              _get_func = o => o.strDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDiagnosis != newval) o.strDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strDiagnosis != c.strDiagnosis || o.IsRIRPropChanged(_str_strDiagnosis, c)) 
                  m.Add(_str_strDiagnosis, o.ObjectIdent + _str_strDiagnosis, o.ObjectIdent2 + _str_strDiagnosis, o.ObjectIdent3 + _str_strDiagnosis, "String", 
                    o.strDiagnosis == null ? "" : o.strDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_strDiagnosis), o.IsInvisible(_str_strDiagnosis), o.IsRequired(_str_strDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intHACode, _formname = _str_intHACode, _type = "Int32?",
              _get_func = o => o.intHACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intHACode != newval) o.intHACode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intHACode != c.intHACode || o.IsRIRPropChanged(_str_intHACode, c)) 
                  m.Add(_str_intHACode, o.ObjectIdent + _str_intHACode, o.ObjectIdent2 + _str_intHACode, o.ObjectIdent3 + _str_intHACode, "Int32?", 
                    o.intHACode == null ? "" : o.intHACode.ToString(),                  
                  o.IsReadOnly(_str_intHACode), o.IsInvisible(_str_intHACode), o.IsRequired(_str_intHACode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsUsingType, _formname = _str_idfsUsingType, _type = "Int64",
              _get_func = o => o.idfsUsingType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsUsingType != newval) o.idfsUsingType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUsingType != c.idfsUsingType || o.IsRIRPropChanged(_str_idfsUsingType, c)) 
                  m.Add(_str_idfsUsingType, o.ObjectIdent + _str_idfsUsingType, o.ObjectIdent2 + _str_idfsUsingType, o.ObjectIdent3 + _str_idfsUsingType, "Int64", 
                    o.idfsUsingType == null ? "" : o.idfsUsingType.ToString(),                  
                  o.IsReadOnly(_str_idfsUsingType), o.IsInvisible(_str_idfsUsingType), o.IsRequired(_str_idfsUsingType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strUsingType, _formname = _str_strUsingType, _type = "String",
              _get_func = o => o.strUsingType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strUsingType != newval) o.strUsingType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strUsingType != c.strUsingType || o.IsRIRPropChanged(_str_strUsingType, c)) 
                  m.Add(_str_strUsingType, o.ObjectIdent + _str_strUsingType, o.ObjectIdent2 + _str_strUsingType, o.ObjectIdent3 + _str_strUsingType, "String", 
                    o.strUsingType == null ? "" : o.strUsingType.ToString(),                  
                  o.IsReadOnly(_str_strUsingType), o.IsInvisible(_str_strUsingType), o.IsRequired(_str_strUsingType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHACode, _formname = _str_strHACode, _type = "String",
              _get_func = o => o.strHACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHACode != newval) o.strHACode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strHACode != c.strHACode || o.IsRIRPropChanged(_str_strHACode, c)) 
                  m.Add(_str_strHACode, o.ObjectIdent + _str_strHACode, o.ObjectIdent2 + _str_strHACode, o.ObjectIdent3 + _str_strHACode, "String", 
                    o.strHACode == null ? "" : o.strHACode.ToString(),                  
                  o.IsReadOnly(_str_strHACode), o.IsInvisible(_str_strHACode), o.IsRequired(_str_strHACode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intIsDeleted, _formname = _str_intIsDeleted, _type = "Int64",
              _get_func = o => o.intIsDeleted,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.intIsDeleted != newval) 
                  o.YNU = o.YNULookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.intIsDeleted != newval) o.intIsDeleted = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intIsDeleted != c.intIsDeleted || o.IsRIRPropChanged(_str_intIsDeleted, c)) 
                  m.Add(_str_intIsDeleted, o.ObjectIdent + _str_intIsDeleted, o.ObjectIdent2 + _str_intIsDeleted, o.ObjectIdent3 + _str_intIsDeleted, "Int64", 
                    o.intIsDeleted == null ? "" : o.intIsDeleted.ToString(),                  
                  o.IsReadOnly(_str_intIsDeleted), o.IsInvisible(_str_intIsDeleted), o.IsRequired(_str_intIsDeleted)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strIsDeleted, _formname = _str_strIsDeleted, _type = "String",
              _get_func = o => o.strIsDeleted,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strIsDeleted != newval) o.strIsDeleted = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strIsDeleted != c.strIsDeleted || o.IsRIRPropChanged(_str_strIsDeleted, c)) 
                  m.Add(_str_strIsDeleted, o.ObjectIdent + _str_strIsDeleted, o.ObjectIdent2 + _str_strIsDeleted, o.ObjectIdent3 + _str_strIsDeleted, "String", 
                    o.strIsDeleted == null ? "" : o.strIsDeleted.ToString(),                  
                  o.IsReadOnly(_str_strIsDeleted), o.IsInvisible(_str_strIsDeleted), o.IsRequired(_str_strIsDeleted)); 
                  }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _formname = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Diagnosis, c);
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnosis, c) || bChangeLookupContent) {
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, o.ObjectIdent2 + _str_Diagnosis, o.ObjectIdent3 + _str_Diagnosis, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis),
                  bChangeLookupContent ? o.DiagnosisLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Diagnosis + "Lookup", _formname = _str_Diagnosis + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_YNU, _formname = _str_YNU, _type = "Lookup",
              _get_func = o => { if (o.YNU == null) return null; return o.YNU.idfsBaseReference; },
              _set_func = (o, val) => { o.YNU = o.YNULookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_YNU, c);
                if (o.intIsDeleted != c.intIsDeleted || o.IsRIRPropChanged(_str_YNU, c) || bChangeLookupContent) {
                  m.Add(_str_YNU, o.ObjectIdent + _str_YNU, o.ObjectIdent2 + _str_YNU, o.ObjectIdent3 + _str_YNU, "Lookup", o.intIsDeleted == null ? "" : o.intIsDeleted.ToString(), o.IsReadOnly(_str_YNU), o.IsInvisible(_str_YNU), o.IsRequired(_str_YNU),
                  bChangeLookupContent ? o.YNULookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_YNU + "Lookup", _formname = _str_YNU + "Lookup", _type = "LookupContent",
              _get_func = o => o.YNULookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
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
            ReportDiagnosesGroup2Diagnosis obj = (ReportDiagnosesGroup2Diagnosis)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Diagnosis)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                var oldVal = _Diagnosis;
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Diagnosis != oldVal)
                {
                    if (idfsDiagnosis != (_Diagnosis == null
                            ? new Int64()
                            : (Int64)_Diagnosis.idfsDiagnosis))
                        idfsDiagnosis = _Diagnosis == null 
                            ? new Int64()
                            : (Int64)_Diagnosis.idfsDiagnosis; 
                    OnPropertyChanged(_str_Diagnosis); 
                }
            }
        }
        private DiagnosisLookup _Diagnosis;

        
        public List<DiagnosisLookup> DiagnosisLookup
        {
            get { return _DiagnosisLookup; }
        }
        private List<DiagnosisLookup> _DiagnosisLookup = new List<DiagnosisLookup>();
            
        [LocalizedDisplayName(_str_YNU)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_intIsDeleted)]
        public BaseReference YNU
        {
            get { return _YNU == null ? null : ((long)_YNU.Key == 0 ? null : _YNU); }
            set 
            { 
                var oldVal = _YNU;
                _YNU = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_YNU != oldVal)
                {
                    if (intIsDeleted != (_YNU == null
                            ? new Int64()
                            : (Int64)_YNU.idfsBaseReference))
                        intIsDeleted = _YNU == null 
                            ? new Int64()
                            : (Int64)_YNU.idfsBaseReference; 
                    OnPropertyChanged(_str_YNU); 
                }
            }
        }
        private BaseReference _YNU;

        
        public BaseReferenceList YNULookup
        {
            get { return _YNULookup; }
        }
        private BaseReferenceList _YNULookup = new BaseReferenceList("rftYesNoValue");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_YNU:
                    return new BvSelectList(YNULookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, YNU, _str_intIsDeleted);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "ReportDiagnosesGroup2Diagnosis";

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
            var ret = base.Clone() as ReportDiagnosesGroup2Diagnosis;
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
            var ret = base.Clone() as ReportDiagnosesGroup2Diagnosis;
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
        public ReportDiagnosesGroup2Diagnosis CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as ReportDiagnosesGroup2Diagnosis;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfDiagnosisToGroupForReportType; } }
        public string KeyName { get { return "idfDiagnosisToGroupForReportType"; } }
        public object KeyLookup { get { return idfDiagnosisToGroupForReportType; } }
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
        
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_intIsDeleted_YNU = intIsDeleted;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_intIsDeleted_YNU != intIsDeleted)
            {
                _YNU = _YNULookup.FirstOrDefault(c => c.idfsBaseReference == intIsDeleted);
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

        private bool IsRIRPropChanged(string fld, ReportDiagnosesGroup2Diagnosis c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, ReportDiagnosesGroup2Diagnosis c)
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
        

      

        public ReportDiagnosesGroup2Diagnosis()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ReportDiagnosesGroup2Diagnosis_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(ReportDiagnosesGroup2Diagnosis_PropertyChanged);
        }
        private void ReportDiagnosesGroup2Diagnosis_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as ReportDiagnosesGroup2Diagnosis).Changed(e.PropertyName);
            
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
            ReportDiagnosesGroup2Diagnosis obj = this;
            
        }
        private void _DeletedExtenders()
        {
            ReportDiagnosesGroup2Diagnosis obj = this;
            
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

    
        private static string[] readonly_names1 = "strUsingType,strHACode".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<ReportDiagnosesGroup2Diagnosis, bool>(c => true)(this);
            
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


        internal Dictionary<string, Func<ReportDiagnosesGroup2Diagnosis, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<ReportDiagnosesGroup2Diagnosis, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<ReportDiagnosesGroup2Diagnosis, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<ReportDiagnosesGroup2Diagnosis, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<ReportDiagnosesGroup2Diagnosis, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<ReportDiagnosesGroup2Diagnosis, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<ReportDiagnosesGroup2Diagnosis, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~ReportDiagnosesGroup2Diagnosis()
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
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_YNU(manager, this);
            
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
    
        #region Class for web grid
        public class ReportDiagnosesGroup2DiagnosisGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfDiagnosisToGroupForReportType { get; set; }
        
            public Int64 idfsCustomReportType { get; set; }
        
            public Int64 idfsReportDiagnosisGroup { get; set; }
        
            public Int64 idfsDiagnosis { get; set; }
        
            public String strUsingType { get; set; }
        
            public String strHACode { get; set; }
        
            public String strIsDeleted { get; set; }
        
        }
        public partial class ReportDiagnosesGroup2DiagnosisGridModelList : List<ReportDiagnosesGroup2DiagnosisGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public ReportDiagnosesGroup2DiagnosisGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<ReportDiagnosesGroup2Diagnosis>, errMes);
            }
            public ReportDiagnosesGroup2DiagnosisGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<ReportDiagnosesGroup2Diagnosis>, errMes);
            }
            public ReportDiagnosesGroup2DiagnosisGridModelList(long key, IEnumerable<ReportDiagnosesGroup2Diagnosis> items)
            {
                LoadGridModelList(key, items, null);
            }
            public ReportDiagnosesGroup2DiagnosisGridModelList(long key)
            {
                LoadGridModelList(key, new List<ReportDiagnosesGroup2Diagnosis>(), null);
            }
            partial void filter(List<ReportDiagnosesGroup2Diagnosis> items);
            private void LoadGridModelList(long key, IEnumerable<ReportDiagnosesGroup2Diagnosis> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_idfsDiagnosis,_str_strUsingType,_str_strHACode,_str_strIsDeleted};
                    
                Hiddens = new List<string> {_str_idfDiagnosisToGroupForReportType,_str_idfsCustomReportType,_str_idfsReportDiagnosisGroup};
                Keys = new List<string> {_str_idfDiagnosisToGroupForReportType};
                Labels = new Dictionary<string, string> {{_str_idfsDiagnosis, "strDiagnosisName"},{_str_strUsingType, _str_strUsingType},{_str_strHACode, _str_strHACode},{_str_strIsDeleted, _str_strIsDeleted}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                ReportDiagnosesGroup2Diagnosis.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<ReportDiagnosesGroup2Diagnosis>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new ReportDiagnosesGroup2DiagnosisGridModel()
                {
                    ItemKey=c.idfDiagnosisToGroupForReportType,idfsCustomReportType=c.idfsCustomReportType,idfsReportDiagnosisGroup=c.idfsReportDiagnosisGroup,idfsDiagnosis=c.idfsDiagnosis,strUsingType=c.strUsingType,strHACode=c.strHACode,strIsDeleted=c.strIsDeleted
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
        : DataAccessor<ReportDiagnosesGroup2Diagnosis>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<ReportDiagnosesGroup2Diagnosis>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfDiagnosisToGroupForReportType"; } }
            #endregion
        
            public delegate void on_action(ReportDiagnosesGroup2Diagnosis obj);
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
            private BaseReference.Accessor YNUAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<ReportDiagnosesGroup2Diagnosis> SelectList(DbManagerProxy manager
                , Int64? idfDiagnosisToGroupForReportType
                )
            {
                return _SelectList(manager
                    , idfDiagnosisToGroupForReportType
                    , delegate(ReportDiagnosesGroup2Diagnosis obj)
                        {
                        }
                    , delegate(ReportDiagnosesGroup2Diagnosis obj)
                        {
                        }
                    );
            }

            

            public List<ReportDiagnosesGroup2Diagnosis> _SelectList(DbManagerProxy manager
                , Int64? idfDiagnosisToGroupForReportType
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfDiagnosisToGroupForReportType
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<ReportDiagnosesGroup2Diagnosis> _SelectListInternal(DbManagerProxy manager
                , Int64? idfDiagnosisToGroupForReportType
                , on_action loading, on_action loaded
                )
            {
                ReportDiagnosesGroup2Diagnosis _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<ReportDiagnosesGroup2Diagnosis> objs = new List<ReportDiagnosesGroup2Diagnosis>();
                    sets[0] = new MapResultSet(typeof(ReportDiagnosesGroup2Diagnosis), objs);
                    
                    manager
                        .SetSpCommand("spReportDiagnosesGroup2Diagnosis_SelectDetail"
                            , manager.Parameter("@idfDiagnosisToGroupForReportType", idfDiagnosisToGroupForReportType)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);
                    foreach(var obj in objs) 
                    {
                        _obj = obj;
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
                    throw DbModelException.Create(_obj, e);
                }
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, ReportDiagnosesGroup2Diagnosis obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, ReportDiagnosesGroup2Diagnosis obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private ReportDiagnosesGroup2Diagnosis _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                ReportDiagnosesGroup2Diagnosis obj = null;
                try
                {
                    obj = ReportDiagnosesGroup2Diagnosis.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfDiagnosisToGroupForReportType = (new GetNewIDExtender<ReportDiagnosesGroup2Diagnosis>()).GetScalar(manager, obj, isFake);
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
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public ReportDiagnosesGroup2Diagnosis CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public ReportDiagnosesGroup2Diagnosis CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public ReportDiagnosesGroup2Diagnosis CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(ReportDiagnosesGroup2Diagnosis obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(ReportDiagnosesGroup2Diagnosis obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                obj.strUsingType = new Func<ReportDiagnosesGroup2Diagnosis, string>(c => c.DiagnosisLookup != null ? c.DiagnosisLookup.FirstOrDefault(w => w.idfsDiagnosis == c.idfsDiagnosis).UsingTypeName : c.strUsingType)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                obj.strHACode = new Func<ReportDiagnosesGroup2Diagnosis, string>(c => c.DiagnosisLookup != null ? c.DiagnosisLookup.FirstOrDefault(w => w.idfsDiagnosis == c.idfsDiagnosis).HACode : c.strHACode)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                obj.intIsDeleted = new Func<ReportDiagnosesGroup2Diagnosis, long>(c => (c.DiagnosisLookup.FirstOrDefault(w => w.idfsDiagnosis == c.idfsDiagnosis).intRowStatus) == 0 ? 10100002 : 10100001)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                obj.strIsDeleted = new Func<ReportDiagnosesGroup2Diagnosis, string>(c => c.YNULookup.FirstOrDefault(w => w.idfsBaseReference == c.intIsDeleted).name)(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Diagnosis(DbManagerProxy manager, ReportDiagnosesGroup2Diagnosis obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosis);
                    
                }
              
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_YNU(DbManagerProxy manager, ReportDiagnosesGroup2Diagnosis obj)
            {
                
                obj.YNULookup.Clear();
                
                obj.YNULookup.Add(YNUAccessor.CreateNewT(manager, null));
                
                obj.YNULookup.AddRange(YNUAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.intIsDeleted))
                    
                    .ToList());
                
                if (obj.intIsDeleted != 0)
                {
                    obj.YNU = obj.YNULookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.intIsDeleted);
                    
                }
              
                LookupManager.AddObject("rftYesNoValue", obj, YNUAccessor.GetType(), "rftYesNoValue_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, ReportDiagnosesGroup2Diagnosis obj)
            {
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_YNU(manager, obj);
                
            }
    
            [SprocName("spReportDiagnosesGroup2Diagnosis_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] ReportDiagnosesGroup2Diagnosis obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] ReportDiagnosesGroup2Diagnosis obj)
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
                        ReportDiagnosesGroup2Diagnosis bo = obj as ReportDiagnosesGroup2Diagnosis;
                        
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
                        bSuccess = _PostNonTransaction(manager, obj as ReportDiagnosesGroup2Diagnosis, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, ReportDiagnosesGroup2Diagnosis obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(ReportDiagnosesGroup2Diagnosis obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, ReportDiagnosesGroup2Diagnosis obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(ReportDiagnosesGroup2Diagnosis obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(ReportDiagnosesGroup2Diagnosis obj, bool bRethrowException)
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
                return Validate(manager, obj as ReportDiagnosesGroup2Diagnosis, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, ReportDiagnosesGroup2Diagnosis obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsCustomReportType", "idfsCustomReportType","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsCustomReportType);
            
                (new RequiredValidator( "idfsReportDiagnosisGroup", "idfsReportDiagnosisGroup","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsReportDiagnosisGroup);
            
                (new RequiredValidator( "idfsDiagnosis", "idfsDiagnosis","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsDiagnosis);
            
                  
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
           
    
            private void _SetupRequired(ReportDiagnosesGroup2Diagnosis obj)
            {
            
                obj
                    .AddRequired("idfsCustomReportType", c => true);
                    
                obj
                    .AddRequired("idfsReportDiagnosisGroup", c => true);
                    
                obj
                    .AddRequired("idfsDiagnosis", c => true);
                    
                  obj
                    .AddRequired("Diagnosis", c => true);
                
            }
    
    private void _SetupPersonalDataRestrictions(ReportDiagnosesGroup2Diagnosis obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as ReportDiagnosesGroup2Diagnosis) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as ReportDiagnosesGroup2Diagnosis) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "ReportDiagnosesGroup2DiagnosisDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spReportDiagnosesGroup2Diagnosis_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spReportDiagnosesGroup2Diagnosis_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<ReportDiagnosesGroup2Diagnosis, bool>> RequiredByField = new Dictionary<string, Func<ReportDiagnosesGroup2Diagnosis, bool>>();
            public static Dictionary<string, Func<ReportDiagnosesGroup2Diagnosis, bool>> RequiredByProperty = new Dictionary<string, Func<ReportDiagnosesGroup2Diagnosis, bool>>();
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
                
                Sizes.Add(_str_strSummaryReportType, 2000);
                Sizes.Add(_str_strReportDiagnosisGroup, 2000);
                Sizes.Add(_str_strDiagnosis, 2000);
                Sizes.Add(_str_strUsingType, 2000);
                Sizes.Add(_str_strHACode, 2147483647);
                Sizes.Add(_str_strIsDeleted, 2000);
                if (!RequiredByField.ContainsKey("idfsCustomReportType")) RequiredByField.Add("idfsCustomReportType", c => true);
                if (!RequiredByProperty.ContainsKey("idfsCustomReportType")) RequiredByProperty.Add("idfsCustomReportType", c => true);
                
                if (!RequiredByField.ContainsKey("idfsReportDiagnosisGroup")) RequiredByField.Add("idfsReportDiagnosisGroup", c => true);
                if (!RequiredByProperty.ContainsKey("idfsReportDiagnosisGroup")) RequiredByProperty.Add("idfsReportDiagnosisGroup", c => true);
                
                if (!RequiredByField.ContainsKey("idfsDiagnosis")) RequiredByField.Add("idfsDiagnosis", c => true);
                if (!RequiredByProperty.ContainsKey("idfsDiagnosis")) RequiredByProperty.Add("idfsDiagnosis", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfDiagnosisToGroupForReportType,
                    _str_idfDiagnosisToGroupForReportType, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsCustomReportType,
                    _str_idfsCustomReportType, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsReportDiagnosisGroup,
                    _str_idfsReportDiagnosisGroup, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsDiagnosis,
                    "strDiagnosisName", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strUsingType,
                    _str_strUsingType, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strHACode,
                    _str_strHACode, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strIsDeleted,
                    _str_strIsDeleted, null, false, true, true, true, true, null
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
                    (manager, c, pars) => ((ReportDiagnosesGroup2Diagnosis)c).MarkToDelete(),
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
	