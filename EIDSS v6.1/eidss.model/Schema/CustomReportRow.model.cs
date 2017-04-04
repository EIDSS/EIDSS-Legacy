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
    public abstract partial class CustomReportRow : 
        EditableObject<CustomReportRow>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfReportRows), NonUpdatable, PrimaryKey]
        public abstract Int64 idfReportRows { get; set; }
                
        [LocalizedDisplayName(_str_idfsCustomReportType)]
        [MapField(_str_idfsCustomReportType)]
        public abstract Int64 idfsCustomReportType { get; set; }
        protected Int64 idfsCustomReportType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCustomReportType).OriginalValue; } }
        protected Int64 idfsCustomReportType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCustomReportType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsDiagnosisOrGroup)]
        [MapField(_str_idfsDiagnosisOrGroup)]
        public abstract Int64 idfsDiagnosisOrGroup { get; set; }
        protected Int64 idfsDiagnosisOrGroup_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosisOrGroup).OriginalValue; } }
        protected Int64 idfsDiagnosisOrGroup_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosisOrGroup).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDiagnosisOrGroup)]
        [MapField(_str_strDiagnosisOrGroup)]
        public abstract String strDiagnosisOrGroup { get; set; }
        protected String strDiagnosisOrGroup_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisOrGroup).OriginalValue; } }
        protected String strDiagnosisOrGroup_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisOrGroup).PreviousValue; } }
                
        [LocalizedDisplayName("strDiagnosisOrReportDiagnosisGroup")]
        [MapField(_str_idfsDiagnosisOrReportDiagnosisGroup)]
        public abstract Int64 idfsDiagnosisOrReportDiagnosisGroup { get; set; }
        protected Int64 idfsDiagnosisOrReportDiagnosisGroup_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosisOrReportDiagnosisGroup).OriginalValue; } }
        protected Int64 idfsDiagnosisOrReportDiagnosisGroup_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosisOrReportDiagnosisGroup).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDiagnosisOrReportDiagnosisGroup)]
        [MapField(_str_strDiagnosisOrReportDiagnosisGroup)]
        public abstract String strDiagnosisOrReportDiagnosisGroup { get; set; }
        protected String strDiagnosisOrReportDiagnosisGroup_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisOrReportDiagnosisGroup).OriginalValue; } }
        protected String strDiagnosisOrReportDiagnosisGroup_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisOrReportDiagnosisGroup).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intRowOrder)]
        [MapField(_str_intRowOrder)]
        public abstract Int32 intRowOrder { get; set; }
        protected Int32 intRowOrder_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intRowOrder).OriginalValue; } }
        protected Int32 intRowOrder_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intRowOrder).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsReportAdditionalText)]
        [MapField(_str_idfsReportAdditionalText)]
        public abstract Int64? idfsReportAdditionalText { get; set; }
        protected Int64? idfsReportAdditionalText_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsReportAdditionalText).OriginalValue; } }
        protected Int64? idfsReportAdditionalText_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsReportAdditionalText).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsICDReportAdditionalText)]
        [MapField(_str_idfsICDReportAdditionalText)]
        public abstract Int64? idfsICDReportAdditionalText { get; set; }
        protected Int64? idfsICDReportAdditionalText_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsICDReportAdditionalText).OriginalValue; } }
        protected Int64? idfsICDReportAdditionalText_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsICDReportAdditionalText).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int32? intHACode { get; set; }
        protected Int32? intHACode_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32? intHACode_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsUsingType)]
        [MapField(_str_idfsUsingType)]
        public abstract Int64? idfsUsingType { get; set; }
        protected Int64? idfsUsingType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsUsingType).OriginalValue; } }
        protected Int64? idfsUsingType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsUsingType).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_strReportAdditionalText)]
        [MapField(_str_strReportAdditionalText)]
        public abstract String strReportAdditionalText { get; set; }
        protected String strReportAdditionalText_Original { get { return ((EditableValue<String>)((dynamic)this)._strReportAdditionalText).OriginalValue; } }
        protected String strReportAdditionalText_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReportAdditionalText).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strICDReportAdditionalText)]
        [MapField(_str_strICDReportAdditionalText)]
        public abstract String strICDReportAdditionalText { get; set; }
        protected String strICDReportAdditionalText_Original { get { return ((EditableValue<String>)((dynamic)this)._strICDReportAdditionalText).OriginalValue; } }
        protected String strICDReportAdditionalText_Previous { get { return ((EditableValue<String>)((dynamic)this)._strICDReportAdditionalText).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<CustomReportRow, object> _get_func;
            internal Action<CustomReportRow, string> _set_func;
            internal Action<CustomReportRow, CustomReportRow, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfReportRows = "idfReportRows";
        internal const string _str_idfsCustomReportType = "idfsCustomReportType";
        internal const string _str_idfsDiagnosisOrGroup = "idfsDiagnosisOrGroup";
        internal const string _str_strDiagnosisOrGroup = "strDiagnosisOrGroup";
        internal const string _str_idfsDiagnosisOrReportDiagnosisGroup = "idfsDiagnosisOrReportDiagnosisGroup";
        internal const string _str_strDiagnosisOrReportDiagnosisGroup = "strDiagnosisOrReportDiagnosisGroup";
        internal const string _str_intRowOrder = "intRowOrder";
        internal const string _str_idfsReportAdditionalText = "idfsReportAdditionalText";
        internal const string _str_idfsICDReportAdditionalText = "idfsICDReportAdditionalText";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_idfsUsingType = "idfsUsingType";
        internal const string _str_strUsingType = "strUsingType";
        internal const string _str_strHACode = "strHACode";
        internal const string _str_strReportAdditionalText = "strReportAdditionalText";
        internal const string _str_strICDReportAdditionalText = "strICDReportAdditionalText";
        internal const string _str_Master = "Master";
        internal const string _str_DiagnosisOrReportGroup = "DiagnosisOrReportGroup";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_ReportAdditionalText = "ReportAdditionalText";
        internal const string _str_ICDReportAdditionalText = "ICDReportAdditionalText";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfReportRows, _formname = _str_idfReportRows, _type = "Int64",
              _get_func = o => o.idfReportRows,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfReportRows != newval) o.idfReportRows = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfReportRows != c.idfReportRows || o.IsRIRPropChanged(_str_idfReportRows, c)) 
                  m.Add(_str_idfReportRows, o.ObjectIdent + _str_idfReportRows, o.ObjectIdent2 + _str_idfReportRows, o.ObjectIdent3 + _str_idfReportRows, "Int64", 
                    o.idfReportRows == null ? "" : o.idfReportRows.ToString(),                  
                  o.IsReadOnly(_str_idfReportRows), o.IsInvisible(_str_idfReportRows), o.IsRequired(_str_idfReportRows)); 
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
              _name = _str_idfsDiagnosisOrGroup, _formname = _str_idfsDiagnosisOrGroup, _type = "Int64",
              _get_func = o => o.idfsDiagnosisOrGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsDiagnosisOrGroup != newval) 
                  o.DiagnosisOrReportGroup = o.DiagnosisOrReportGroupLookup.FirstOrDefault(c => c.idfsReference == newval);
                if (o.idfsDiagnosisOrGroup != newval) o.idfsDiagnosisOrGroup = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsDiagnosisOrGroup != c.idfsDiagnosisOrGroup || o.IsRIRPropChanged(_str_idfsDiagnosisOrGroup, c)) 
                  m.Add(_str_idfsDiagnosisOrGroup, o.ObjectIdent + _str_idfsDiagnosisOrGroup, o.ObjectIdent2 + _str_idfsDiagnosisOrGroup, o.ObjectIdent3 + _str_idfsDiagnosisOrGroup, "Int64", 
                    o.idfsDiagnosisOrGroup == null ? "" : o.idfsDiagnosisOrGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosisOrGroup), o.IsInvisible(_str_idfsDiagnosisOrGroup), o.IsRequired(_str_idfsDiagnosisOrGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDiagnosisOrGroup, _formname = _str_strDiagnosisOrGroup, _type = "String",
              _get_func = o => o.strDiagnosisOrGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDiagnosisOrGroup != newval) o.strDiagnosisOrGroup = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strDiagnosisOrGroup != c.strDiagnosisOrGroup || o.IsRIRPropChanged(_str_strDiagnosisOrGroup, c)) 
                  m.Add(_str_strDiagnosisOrGroup, o.ObjectIdent + _str_strDiagnosisOrGroup, o.ObjectIdent2 + _str_strDiagnosisOrGroup, o.ObjectIdent3 + _str_strDiagnosisOrGroup, "String", 
                    o.strDiagnosisOrGroup == null ? "" : o.strDiagnosisOrGroup.ToString(),                  
                  o.IsReadOnly(_str_strDiagnosisOrGroup), o.IsInvisible(_str_strDiagnosisOrGroup), o.IsRequired(_str_strDiagnosisOrGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosisOrReportDiagnosisGroup, _formname = _str_idfsDiagnosisOrReportDiagnosisGroup, _type = "Int64",
              _get_func = o => o.idfsDiagnosisOrReportDiagnosisGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsDiagnosisOrReportDiagnosisGroup != newval) 
                  o.Diagnosis = o.DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosisOrDiagnosisGroup == newval);
                if (o.idfsDiagnosisOrReportDiagnosisGroup != newval) o.idfsDiagnosisOrReportDiagnosisGroup = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsDiagnosisOrReportDiagnosisGroup != c.idfsDiagnosisOrReportDiagnosisGroup || o.IsRIRPropChanged(_str_idfsDiagnosisOrReportDiagnosisGroup, c)) 
                  m.Add(_str_idfsDiagnosisOrReportDiagnosisGroup, o.ObjectIdent + _str_idfsDiagnosisOrReportDiagnosisGroup, o.ObjectIdent2 + _str_idfsDiagnosisOrReportDiagnosisGroup, o.ObjectIdent3 + _str_idfsDiagnosisOrReportDiagnosisGroup, "Int64", 
                    o.idfsDiagnosisOrReportDiagnosisGroup == null ? "" : o.idfsDiagnosisOrReportDiagnosisGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosisOrReportDiagnosisGroup), o.IsInvisible(_str_idfsDiagnosisOrReportDiagnosisGroup), o.IsRequired(_str_idfsDiagnosisOrReportDiagnosisGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDiagnosisOrReportDiagnosisGroup, _formname = _str_strDiagnosisOrReportDiagnosisGroup, _type = "String",
              _get_func = o => o.strDiagnosisOrReportDiagnosisGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDiagnosisOrReportDiagnosisGroup != newval) o.strDiagnosisOrReportDiagnosisGroup = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strDiagnosisOrReportDiagnosisGroup != c.strDiagnosisOrReportDiagnosisGroup || o.IsRIRPropChanged(_str_strDiagnosisOrReportDiagnosisGroup, c)) 
                  m.Add(_str_strDiagnosisOrReportDiagnosisGroup, o.ObjectIdent + _str_strDiagnosisOrReportDiagnosisGroup, o.ObjectIdent2 + _str_strDiagnosisOrReportDiagnosisGroup, o.ObjectIdent3 + _str_strDiagnosisOrReportDiagnosisGroup, "String", 
                    o.strDiagnosisOrReportDiagnosisGroup == null ? "" : o.strDiagnosisOrReportDiagnosisGroup.ToString(),                  
                  o.IsReadOnly(_str_strDiagnosisOrReportDiagnosisGroup), o.IsInvisible(_str_strDiagnosisOrReportDiagnosisGroup), o.IsRequired(_str_strDiagnosisOrReportDiagnosisGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intRowOrder, _formname = _str_intRowOrder, _type = "Int32",
              _get_func = o => o.intRowOrder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intRowOrder != newval) o.intRowOrder = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intRowOrder != c.intRowOrder || o.IsRIRPropChanged(_str_intRowOrder, c)) 
                  m.Add(_str_intRowOrder, o.ObjectIdent + _str_intRowOrder, o.ObjectIdent2 + _str_intRowOrder, o.ObjectIdent3 + _str_intRowOrder, "Int32", 
                    o.intRowOrder == null ? "" : o.intRowOrder.ToString(),                  
                  o.IsReadOnly(_str_intRowOrder), o.IsInvisible(_str_intRowOrder), o.IsRequired(_str_intRowOrder)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsReportAdditionalText, _formname = _str_idfsReportAdditionalText, _type = "Int64?",
              _get_func = o => o.idfsReportAdditionalText,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsReportAdditionalText != newval) 
                  o.ReportAdditionalText = o.ReportAdditionalTextLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsReportAdditionalText != newval) o.idfsReportAdditionalText = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsReportAdditionalText != c.idfsReportAdditionalText || o.IsRIRPropChanged(_str_idfsReportAdditionalText, c)) 
                  m.Add(_str_idfsReportAdditionalText, o.ObjectIdent + _str_idfsReportAdditionalText, o.ObjectIdent2 + _str_idfsReportAdditionalText, o.ObjectIdent3 + _str_idfsReportAdditionalText, "Int64?", 
                    o.idfsReportAdditionalText == null ? "" : o.idfsReportAdditionalText.ToString(),                  
                  o.IsReadOnly(_str_idfsReportAdditionalText), o.IsInvisible(_str_idfsReportAdditionalText), o.IsRequired(_str_idfsReportAdditionalText)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsICDReportAdditionalText, _formname = _str_idfsICDReportAdditionalText, _type = "Int64?",
              _get_func = o => o.idfsICDReportAdditionalText,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsICDReportAdditionalText != newval) 
                  o.ICDReportAdditionalText = o.ICDReportAdditionalTextLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsICDReportAdditionalText != newval) o.idfsICDReportAdditionalText = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsICDReportAdditionalText != c.idfsICDReportAdditionalText || o.IsRIRPropChanged(_str_idfsICDReportAdditionalText, c)) 
                  m.Add(_str_idfsICDReportAdditionalText, o.ObjectIdent + _str_idfsICDReportAdditionalText, o.ObjectIdent2 + _str_idfsICDReportAdditionalText, o.ObjectIdent3 + _str_idfsICDReportAdditionalText, "Int64?", 
                    o.idfsICDReportAdditionalText == null ? "" : o.idfsICDReportAdditionalText.ToString(),                  
                  o.IsReadOnly(_str_idfsICDReportAdditionalText), o.IsInvisible(_str_idfsICDReportAdditionalText), o.IsRequired(_str_idfsICDReportAdditionalText)); 
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
              _name = _str_idfsUsingType, _formname = _str_idfsUsingType, _type = "Int64?",
              _get_func = o => o.idfsUsingType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsUsingType != newval) o.idfsUsingType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUsingType != c.idfsUsingType || o.IsRIRPropChanged(_str_idfsUsingType, c)) 
                  m.Add(_str_idfsUsingType, o.ObjectIdent + _str_idfsUsingType, o.ObjectIdent2 + _str_idfsUsingType, o.ObjectIdent3 + _str_idfsUsingType, "Int64?", 
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
              _name = _str_strReportAdditionalText, _formname = _str_strReportAdditionalText, _type = "String",
              _get_func = o => o.strReportAdditionalText,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strReportAdditionalText != newval) o.strReportAdditionalText = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strReportAdditionalText != c.strReportAdditionalText || o.IsRIRPropChanged(_str_strReportAdditionalText, c)) 
                  m.Add(_str_strReportAdditionalText, o.ObjectIdent + _str_strReportAdditionalText, o.ObjectIdent2 + _str_strReportAdditionalText, o.ObjectIdent3 + _str_strReportAdditionalText, "String", 
                    o.strReportAdditionalText == null ? "" : o.strReportAdditionalText.ToString(),                  
                  o.IsReadOnly(_str_strReportAdditionalText), o.IsInvisible(_str_strReportAdditionalText), o.IsRequired(_str_strReportAdditionalText)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strICDReportAdditionalText, _formname = _str_strICDReportAdditionalText, _type = "String",
              _get_func = o => o.strICDReportAdditionalText,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strICDReportAdditionalText != newval) o.strICDReportAdditionalText = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strICDReportAdditionalText != c.strICDReportAdditionalText || o.IsRIRPropChanged(_str_strICDReportAdditionalText, c)) 
                  m.Add(_str_strICDReportAdditionalText, o.ObjectIdent + _str_strICDReportAdditionalText, o.ObjectIdent2 + _str_strICDReportAdditionalText, o.ObjectIdent3 + _str_strICDReportAdditionalText, "String", 
                    o.strICDReportAdditionalText == null ? "" : o.strICDReportAdditionalText.ToString(),                  
                  o.IsReadOnly(_str_strICDReportAdditionalText), o.IsInvisible(_str_strICDReportAdditionalText), o.IsRequired(_str_strICDReportAdditionalText)); 
                  }
              }, 
        
            new field_info {
              _name = _str_Master, _formname = _str_Master, _type = "CustomReportRowsMaster",
              _get_func = o => o.Master,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_DiagnosisOrReportGroup, _formname = _str_DiagnosisOrReportGroup, _type = "Lookup",
              _get_func = o => { if (o.DiagnosisOrReportGroup == null) return null; return o.DiagnosisOrReportGroup.idfsReference; },
              _set_func = (o, val) => { o.DiagnosisOrReportGroup = o.DiagnosisOrReportGroupLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_DiagnosisOrReportGroup, c);
                if (o.idfsDiagnosisOrGroup != c.idfsDiagnosisOrGroup || o.IsRIRPropChanged(_str_DiagnosisOrReportGroup, c) || bChangeLookupContent) {
                  m.Add(_str_DiagnosisOrReportGroup, o.ObjectIdent + _str_DiagnosisOrReportGroup, o.ObjectIdent2 + _str_DiagnosisOrReportGroup, o.ObjectIdent3 + _str_DiagnosisOrReportGroup, "Lookup", o.idfsDiagnosisOrGroup == null ? "" : o.idfsDiagnosisOrGroup.ToString(), o.IsReadOnly(_str_DiagnosisOrReportGroup), o.IsInvisible(_str_DiagnosisOrReportGroup), o.IsRequired(_str_DiagnosisOrReportGroup),
                  bChangeLookupContent ? o.DiagnosisOrReportGroupLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_DiagnosisOrReportGroup + "Lookup", _formname = _str_DiagnosisOrReportGroup + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisOrReportGroupLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _formname = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosisOrDiagnosisGroup; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosisOrDiagnosisGroup.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Diagnosis, c);
                if (o.idfsDiagnosisOrReportDiagnosisGroup != c.idfsDiagnosisOrReportDiagnosisGroup || o.IsRIRPropChanged(_str_Diagnosis, c) || bChangeLookupContent) {
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, o.ObjectIdent2 + _str_Diagnosis, o.ObjectIdent3 + _str_Diagnosis, "Lookup", o.idfsDiagnosisOrReportDiagnosisGroup == null ? "" : o.idfsDiagnosisOrReportDiagnosisGroup.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis),
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
              _name = _str_ReportAdditionalText, _formname = _str_ReportAdditionalText, _type = "Lookup",
              _get_func = o => { if (o.ReportAdditionalText == null) return null; return o.ReportAdditionalText.idfsBaseReference; },
              _set_func = (o, val) => { o.ReportAdditionalText = o.ReportAdditionalTextLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_ReportAdditionalText, c);
                if (o.idfsReportAdditionalText != c.idfsReportAdditionalText || o.IsRIRPropChanged(_str_ReportAdditionalText, c) || bChangeLookupContent) {
                  m.Add(_str_ReportAdditionalText, o.ObjectIdent + _str_ReportAdditionalText, o.ObjectIdent2 + _str_ReportAdditionalText, o.ObjectIdent3 + _str_ReportAdditionalText, "Lookup", o.idfsReportAdditionalText == null ? "" : o.idfsReportAdditionalText.ToString(), o.IsReadOnly(_str_ReportAdditionalText), o.IsInvisible(_str_ReportAdditionalText), o.IsRequired(_str_ReportAdditionalText),
                  bChangeLookupContent ? o.ReportAdditionalTextLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_ReportAdditionalText + "Lookup", _formname = _str_ReportAdditionalText + "Lookup", _type = "LookupContent",
              _get_func = o => o.ReportAdditionalTextLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_ICDReportAdditionalText, _formname = _str_ICDReportAdditionalText, _type = "Lookup",
              _get_func = o => { if (o.ICDReportAdditionalText == null) return null; return o.ICDReportAdditionalText.idfsBaseReference; },
              _set_func = (o, val) => { o.ICDReportAdditionalText = o.ICDReportAdditionalTextLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_ICDReportAdditionalText, c);
                if (o.idfsICDReportAdditionalText != c.idfsICDReportAdditionalText || o.IsRIRPropChanged(_str_ICDReportAdditionalText, c) || bChangeLookupContent) {
                  m.Add(_str_ICDReportAdditionalText, o.ObjectIdent + _str_ICDReportAdditionalText, o.ObjectIdent2 + _str_ICDReportAdditionalText, o.ObjectIdent3 + _str_ICDReportAdditionalText, "Lookup", o.idfsICDReportAdditionalText == null ? "" : o.idfsICDReportAdditionalText.ToString(), o.IsReadOnly(_str_ICDReportAdditionalText), o.IsInvisible(_str_ICDReportAdditionalText), o.IsRequired(_str_ICDReportAdditionalText),
                  bChangeLookupContent ? o.ICDReportAdditionalTextLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_ICDReportAdditionalText + "Lookup", _formname = _str_ICDReportAdditionalText + "Lookup", _type = "LookupContent",
              _get_func = o => o.ICDReportAdditionalTextLookup,
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
            CustomReportRow obj = (CustomReportRow)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_DiagnosisOrReportGroup)]
        [Relation(typeof(DiagnosisOrReportGroupLookup), eidss.model.Schema.DiagnosisOrReportGroupLookup._str_idfsReference, _str_idfsDiagnosisOrGroup)]
        public DiagnosisOrReportGroupLookup DiagnosisOrReportGroup
        {
            get { return _DiagnosisOrReportGroup == null ? null : ((long)_DiagnosisOrReportGroup.Key == 0 ? null : _DiagnosisOrReportGroup); }
            set 
            { 
                var oldVal = _DiagnosisOrReportGroup;
                _DiagnosisOrReportGroup = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_DiagnosisOrReportGroup != oldVal)
                {
                    if (idfsDiagnosisOrGroup != (_DiagnosisOrReportGroup == null
                            ? new Int64()
                            : (Int64)_DiagnosisOrReportGroup.idfsReference))
                        idfsDiagnosisOrGroup = _DiagnosisOrReportGroup == null 
                            ? new Int64()
                            : (Int64)_DiagnosisOrReportGroup.idfsReference; 
                    OnPropertyChanged(_str_DiagnosisOrReportGroup); 
                }
            }
        }
        private DiagnosisOrReportGroupLookup _DiagnosisOrReportGroup;

        
        public List<DiagnosisOrReportGroupLookup> DiagnosisOrReportGroupLookup
        {
            get { return _DiagnosisOrReportGroupLookup; }
        }
        private List<DiagnosisOrReportGroupLookup> _DiagnosisOrReportGroupLookup = new List<DiagnosisOrReportGroupLookup>();
            
        [LocalizedDisplayName(_str_Diagnosis)]
        [Relation(typeof(CustomReportGroupsAndDiagnoses), eidss.model.Schema.CustomReportGroupsAndDiagnoses._str_idfsDiagnosisOrDiagnosisGroup, _str_idfsDiagnosisOrReportDiagnosisGroup)]
        public CustomReportGroupsAndDiagnoses Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                var oldVal = _Diagnosis;
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Diagnosis != oldVal)
                {
                    if (idfsDiagnosisOrReportDiagnosisGroup != (_Diagnosis == null
                            ? new Int64()
                            : (Int64)_Diagnosis.idfsDiagnosisOrDiagnosisGroup))
                        idfsDiagnosisOrReportDiagnosisGroup = _Diagnosis == null 
                            ? new Int64()
                            : (Int64)_Diagnosis.idfsDiagnosisOrDiagnosisGroup; 
                    OnPropertyChanged(_str_Diagnosis); 
                }
            }
        }
        private CustomReportGroupsAndDiagnoses _Diagnosis;

        
        public List<CustomReportGroupsAndDiagnoses> DiagnosisLookup
        {
            get { return _DiagnosisLookup; }
        }
        private List<CustomReportGroupsAndDiagnoses> _DiagnosisLookup = new List<CustomReportGroupsAndDiagnoses>();
            
        [LocalizedDisplayName(_str_ReportAdditionalText)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsReportAdditionalText)]
        public BaseReference ReportAdditionalText
        {
            get { return _ReportAdditionalText == null ? null : ((long)_ReportAdditionalText.Key == 0 ? null : _ReportAdditionalText); }
            set 
            { 
                var oldVal = _ReportAdditionalText;
                _ReportAdditionalText = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_ReportAdditionalText != oldVal)
                {
                    if (idfsReportAdditionalText != (_ReportAdditionalText == null
                            ? new Int64?()
                            : (Int64?)_ReportAdditionalText.idfsBaseReference))
                        idfsReportAdditionalText = _ReportAdditionalText == null 
                            ? new Int64?()
                            : (Int64?)_ReportAdditionalText.idfsBaseReference; 
                    OnPropertyChanged(_str_ReportAdditionalText); 
                }
            }
        }
        private BaseReference _ReportAdditionalText;

        
        public BaseReferenceList ReportAdditionalTextLookup
        {
            get { return _ReportAdditionalTextLookup; }
        }
        private BaseReferenceList _ReportAdditionalTextLookup = new BaseReferenceList("rftReportAdditionalText");
            
        [LocalizedDisplayName(_str_ICDReportAdditionalText)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsICDReportAdditionalText)]
        public BaseReference ICDReportAdditionalText
        {
            get { return _ICDReportAdditionalText == null ? null : ((long)_ICDReportAdditionalText.Key == 0 ? null : _ICDReportAdditionalText); }
            set 
            { 
                var oldVal = _ICDReportAdditionalText;
                _ICDReportAdditionalText = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_ICDReportAdditionalText != oldVal)
                {
                    if (idfsICDReportAdditionalText != (_ICDReportAdditionalText == null
                            ? new Int64?()
                            : (Int64?)_ICDReportAdditionalText.idfsBaseReference))
                        idfsICDReportAdditionalText = _ICDReportAdditionalText == null 
                            ? new Int64?()
                            : (Int64?)_ICDReportAdditionalText.idfsBaseReference; 
                    OnPropertyChanged(_str_ICDReportAdditionalText); 
                }
            }
        }
        private BaseReference _ICDReportAdditionalText;

        
        public BaseReferenceList ICDReportAdditionalTextLookup
        {
            get { return _ICDReportAdditionalTextLookup; }
        }
        private BaseReferenceList _ICDReportAdditionalTextLookup = new BaseReferenceList("rftReportAdditionalText");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_DiagnosisOrReportGroup:
                    return new BvSelectList(DiagnosisOrReportGroupLookup, eidss.model.Schema.DiagnosisOrReportGroupLookup._str_idfsReference, null, DiagnosisOrReportGroup, _str_idfsDiagnosisOrGroup);
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.CustomReportGroupsAndDiagnoses._str_idfsDiagnosisOrDiagnosisGroup, null, Diagnosis, _str_idfsDiagnosisOrReportDiagnosisGroup);
            
                case _str_ReportAdditionalText:
                    return new BvSelectList(ReportAdditionalTextLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, ReportAdditionalText, _str_idfsReportAdditionalText);
            
                case _str_ICDReportAdditionalText:
                    return new BvSelectList(ICDReportAdditionalTextLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, ICDReportAdditionalText, _str_idfsICDReportAdditionalText);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_Master)]
        public CustomReportRowsMaster Master
        {
            get { return new Func<CustomReportRow, CustomReportRowsMaster>(c=>c.Parent as CustomReportRowsMaster)(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "CustomReportRow";

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
            var ret = base.Clone() as CustomReportRow;
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
            var ret = base.Clone() as CustomReportRow;
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
        public CustomReportRow CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as CustomReportRow;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfReportRows; } }
        public string KeyName { get { return "idfReportRows"; } }
        public object KeyLookup { get { return idfReportRows; } }
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
        
            var _prev_idfsDiagnosisOrGroup_DiagnosisOrReportGroup = idfsDiagnosisOrGroup;
            var _prev_idfsDiagnosisOrReportDiagnosisGroup_Diagnosis = idfsDiagnosisOrReportDiagnosisGroup;
            var _prev_idfsReportAdditionalText_ReportAdditionalText = idfsReportAdditionalText;
            var _prev_idfsICDReportAdditionalText_ICDReportAdditionalText = idfsICDReportAdditionalText;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosisOrGroup_DiagnosisOrReportGroup != idfsDiagnosisOrGroup)
            {
                _DiagnosisOrReportGroup = _DiagnosisOrReportGroupLookup.FirstOrDefault(c => c.idfsReference == idfsDiagnosisOrGroup);
            }
            if (_prev_idfsDiagnosisOrReportDiagnosisGroup_Diagnosis != idfsDiagnosisOrReportDiagnosisGroup)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosisOrDiagnosisGroup == idfsDiagnosisOrReportDiagnosisGroup);
            }
            if (_prev_idfsReportAdditionalText_ReportAdditionalText != idfsReportAdditionalText)
            {
                _ReportAdditionalText = _ReportAdditionalTextLookup.FirstOrDefault(c => c.idfsBaseReference == idfsReportAdditionalText);
            }
            if (_prev_idfsICDReportAdditionalText_ICDReportAdditionalText != idfsICDReportAdditionalText)
            {
                _ICDReportAdditionalText = _ICDReportAdditionalTextLookup.FirstOrDefault(c => c.idfsBaseReference == idfsICDReportAdditionalText);
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

        private bool IsRIRPropChanged(string fld, CustomReportRow c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, CustomReportRow c)
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
        

      

        public CustomReportRow()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(CustomReportRow_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(CustomReportRow_PropertyChanged);
        }
        private void CustomReportRow_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as CustomReportRow).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_Master);
                  
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
            CustomReportRow obj = this;
            
        }
        private void _DeletedExtenders()
        {
            CustomReportRow obj = this;
            
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

    
        private static string[] readonly_names1 = "strUsingType".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<CustomReportRow, bool>(c => true)(this);
            
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


        internal Dictionary<string, Func<CustomReportRow, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<CustomReportRow, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<CustomReportRow, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<CustomReportRow, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<CustomReportRow, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<CustomReportRow, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<CustomReportRow, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~CustomReportRow()
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
                
                LookupManager.RemoveObject("DiagnosisOrReportGroupLookup", this);
                
                LookupManager.RemoveObject("CustomReportGroupsAndDiagnoses", this);
                
                LookupManager.RemoveObject("rftReportAdditionalText", this);
                
                LookupManager.RemoveObject("rftReportAdditionalText", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisOrReportGroupLookup")
                _getAccessor().LoadLookup_DiagnosisOrReportGroup(manager, this);
            
            if (lookup_object == "CustomReportGroupsAndDiagnoses")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftReportAdditionalText")
                _getAccessor().LoadLookup_ReportAdditionalText(manager, this);
            
            if (lookup_object == "rftReportAdditionalText")
                _getAccessor().LoadLookup_ICDReportAdditionalText(manager, this);
            
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
        public class CustomReportRowGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfReportRows { get; set; }
        
            public Int64 idfsCustomReportType { get; set; }
        
            public Int32 intRowOrder { get; set; }
        
            public Int64 idfsDiagnosisOrGroup { get; set; }
        
            public Int64 idfsDiagnosisOrReportDiagnosisGroup { get; set; }
        
            public String strUsingType { get; set; }
        
            public Int64? idfsReportAdditionalText { get; set; }
        
            public Int64? idfsICDReportAdditionalText { get; set; }
        
        }
        public partial class CustomReportRowGridModelList : List<CustomReportRowGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public CustomReportRowGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<CustomReportRow>, errMes);
            }
            public CustomReportRowGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<CustomReportRow>, errMes);
            }
            public CustomReportRowGridModelList(long key, IEnumerable<CustomReportRow> items)
            {
                LoadGridModelList(key, items, null);
            }
            public CustomReportRowGridModelList(long key)
            {
                LoadGridModelList(key, new List<CustomReportRow>(), null);
            }
            partial void filter(List<CustomReportRow> items);
            private void LoadGridModelList(long key, IEnumerable<CustomReportRow> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_intRowOrder,_str_idfsDiagnosisOrGroup,_str_idfsDiagnosisOrReportDiagnosisGroup,_str_strUsingType,_str_idfsReportAdditionalText,_str_idfsICDReportAdditionalText};
                    
                Hiddens = new List<string> {_str_idfReportRows,_str_idfsCustomReportType};
                Keys = new List<string> {_str_idfReportRows};
                Labels = new Dictionary<string, string> {{_str_intRowOrder, _str_intRowOrder},{_str_idfsDiagnosisOrGroup, _str_idfsDiagnosisOrGroup},{_str_idfsDiagnosisOrReportDiagnosisGroup, "strDiagnosisOrReportDiagnosisGroup"},{_str_strUsingType, _str_strUsingType},{_str_idfsReportAdditionalText, _str_idfsReportAdditionalText},{_str_idfsICDReportAdditionalText, _str_idfsICDReportAdditionalText}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                CustomReportRow.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<CustomReportRow>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new CustomReportRowGridModel()
                {
                    ItemKey=c.idfReportRows,idfsCustomReportType=c.idfsCustomReportType,intRowOrder=c.intRowOrder,idfsDiagnosisOrGroup=c.idfsDiagnosisOrGroup,idfsDiagnosisOrReportDiagnosisGroup=c.idfsDiagnosisOrReportDiagnosisGroup,strUsingType=c.strUsingType,idfsReportAdditionalText=c.idfsReportAdditionalText,idfsICDReportAdditionalText=c.idfsICDReportAdditionalText
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
        : DataAccessor<CustomReportRow>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<CustomReportRow>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfReportRows"; } }
            #endregion
        
            public delegate void on_action(CustomReportRow obj);
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
            private DiagnosisOrReportGroupLookup.Accessor DiagnosisOrReportGroupAccessor { get { return eidss.model.Schema.DiagnosisOrReportGroupLookup.Accessor.Instance(m_CS); } }
            private CustomReportGroupsAndDiagnoses.Accessor DiagnosisAccessor { get { return eidss.model.Schema.CustomReportGroupsAndDiagnoses.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor ReportAdditionalTextAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor ICDReportAdditionalTextAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<CustomReportRow> SelectList(DbManagerProxy manager
                , Int64? idfReportRows
                )
            {
                return _SelectList(manager
                    , idfReportRows
                    , delegate(CustomReportRow obj)
                        {
                        }
                    , delegate(CustomReportRow obj)
                        {
                        }
                    );
            }

            

            public List<CustomReportRow> _SelectList(DbManagerProxy manager
                , Int64? idfReportRows
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfReportRows
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<CustomReportRow> _SelectListInternal(DbManagerProxy manager
                , Int64? idfReportRows
                , on_action loading, on_action loaded
                )
            {
                CustomReportRow _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<CustomReportRow> objs = new List<CustomReportRow>();
                    sets[0] = new MapResultSet(typeof(CustomReportRow), objs);
                    
                    manager
                        .SetSpCommand("spCustomReportRows_SelectDetail"
                            , manager.Parameter("@idfReportRows", idfReportRows)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, CustomReportRow obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, CustomReportRow obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private CustomReportRow _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                CustomReportRow obj = null;
                try
                {
                    obj = CustomReportRow.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfReportRows = (new GetNewIDExtender<CustomReportRow>()).GetScalar(manager, obj, isFake);
                obj.intRowOrder = new Func<CustomReportRow, int>(c => c.Parent == null ? 0 : ((CustomReportRowsMaster)c.Parent).GetNewRowNumber())(obj);
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

            
            public CustomReportRow CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public CustomReportRow CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public CustomReportRow CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(CustomReportRow obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(CustomReportRow obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsDiagnosisOrReportDiagnosisGroup)
                        {
                    
                obj.strUsingType = new Func<CustomReportRow, string>(c => {var d = c.DiagnosisLookup.FirstOrDefault(w => w.idfsDiagnosisOrDiagnosisGroup == c.idfsDiagnosisOrReportDiagnosisGroup); if (d != null) return d.strUsingTypeName; else return c.strUsingType;})(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosisOrGroup)
                        {
                    
                obj.idfsDiagnosisOrReportDiagnosisGroup = new Func<CustomReportRow, long>(c => 0)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosisOrGroup)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Diagnosis(manager, obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_DiagnosisOrReportGroup(DbManagerProxy manager, CustomReportRow obj)
            {
                
                obj.DiagnosisOrReportGroupLookup.Clear();
                
                obj.DiagnosisOrReportGroupLookup.Add(DiagnosisOrReportGroupAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisOrReportGroupLookup.AddRange(DiagnosisOrReportGroupAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsDiagnosisOrGroup))
                    
                    .ToList());
                
                if (obj.idfsDiagnosisOrGroup != 0)
                {
                    obj.DiagnosisOrReportGroup = obj.DiagnosisOrReportGroupLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsDiagnosisOrGroup);
                    
                }
              
                LookupManager.AddObject("DiagnosisOrReportGroupLookup", obj, DiagnosisOrReportGroupAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Diagnosis(DbManagerProxy manager, CustomReportRow obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    , new Func<CustomReportRow, int>(c => (int)HACode.HumanLivestockAvianVector)(obj)
                            
                    , new Func<CustomReportRow, long>(c => 0)(obj)
                            
                    )
                    .Where(c => Utils.IsEmpty(obj.idfsDiagnosisOrGroup) ? true :  (obj.idfsDiagnosisOrGroup == 19000019 && !(bool)c.blnGroup) || (obj.idfsDiagnosisOrGroup == 19000130 && (bool)c.blnGroup))
                        
                    .ToList());
                
                if (obj.idfsDiagnosisOrReportDiagnosisGroup != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosisOrDiagnosisGroup == obj.idfsDiagnosisOrReportDiagnosisGroup);
                    
                }
              
                LookupManager.AddObject("CustomReportGroupsAndDiagnoses", obj, DiagnosisAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_ReportAdditionalText(DbManagerProxy manager, CustomReportRow obj)
            {
                
                obj.ReportAdditionalTextLookup.Clear();
                
                obj.ReportAdditionalTextLookup.Add(ReportAdditionalTextAccessor.CreateNewT(manager, null));
                
                obj.ReportAdditionalTextLookup.AddRange(ReportAdditionalTextAccessor.rftReportAdditionalText_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsReportAdditionalText))
                    
                    .ToList());
                
                if (obj.idfsReportAdditionalText != null && obj.idfsReportAdditionalText != 0)
                {
                    obj.ReportAdditionalText = obj.ReportAdditionalTextLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsReportAdditionalText);
                    
                }
              
                LookupManager.AddObject("rftReportAdditionalText", obj, ReportAdditionalTextAccessor.GetType(), "rftReportAdditionalText_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_ICDReportAdditionalText(DbManagerProxy manager, CustomReportRow obj)
            {
                
                obj.ICDReportAdditionalTextLookup.Clear();
                
                obj.ICDReportAdditionalTextLookup.Add(ICDReportAdditionalTextAccessor.CreateNewT(manager, null));
                
                obj.ICDReportAdditionalTextLookup.AddRange(ICDReportAdditionalTextAccessor.rftReportAdditionalText_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsICDReportAdditionalText))
                    
                    .ToList());
                
                if (obj.idfsICDReportAdditionalText != null && obj.idfsICDReportAdditionalText != 0)
                {
                    obj.ICDReportAdditionalText = obj.ICDReportAdditionalTextLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsICDReportAdditionalText);
                    
                }
              
                LookupManager.AddObject("rftReportAdditionalText", obj, ICDReportAdditionalTextAccessor.GetType(), "rftReportAdditionalText_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, CustomReportRow obj)
            {
                
                LoadLookup_DiagnosisOrReportGroup(manager, obj);
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_ReportAdditionalText(manager, obj);
                
                LoadLookup_ICDReportAdditionalText(manager, obj);
                
            }
    
            [SprocName("spCustomReportRows_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] CustomReportRow obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] CustomReportRow obj)
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
                        CustomReportRow bo = obj as CustomReportRow;
                        
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
                        bSuccess = _PostNonTransaction(manager, obj as CustomReportRow, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, CustomReportRow obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(CustomReportRow obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, CustomReportRow obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(CustomReportRow obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(CustomReportRow obj, bool bRethrowException)
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
                return Validate(manager, obj as CustomReportRow, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, CustomReportRow obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
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
            
                (new RequiredValidator( "intRowOrder", "intRowOrder","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.intRowOrder);
            
                (new RequiredValidator( "idfsDiagnosisOrReportDiagnosisGroup", "idfsDiagnosisOrReportDiagnosisGroup","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsDiagnosisOrReportDiagnosisGroup);
            
                CustomValidations(obj);
            
                  
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
           
    
            private void _SetupRequired(CustomReportRow obj)
            {
            
                obj
                    .AddRequired("idfsCustomReportType", c => true);
                    
                obj
                    .AddRequired("intRowOrder", c => true);
                    
                obj
                    .AddRequired("idfsDiagnosisOrReportDiagnosisGroup", c => true);
                    
                  obj
                    .AddRequired("Diagnosis", c => true);
                
            }
    
    private void _SetupPersonalDataRestrictions(CustomReportRow obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as CustomReportRow) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as CustomReportRow) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "CustomReportRowDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spCustomReportRows_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spCustomReportRows_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<CustomReportRow, bool>> RequiredByField = new Dictionary<string, Func<CustomReportRow, bool>>();
            public static Dictionary<string, Func<CustomReportRow, bool>> RequiredByProperty = new Dictionary<string, Func<CustomReportRow, bool>>();
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
                
                Sizes.Add(_str_strDiagnosisOrGroup, 2000);
                Sizes.Add(_str_strDiagnosisOrReportDiagnosisGroup, 2000);
                Sizes.Add(_str_strUsingType, 2000);
                Sizes.Add(_str_strHACode, 4000);
                Sizes.Add(_str_strReportAdditionalText, 2000);
                Sizes.Add(_str_strICDReportAdditionalText, 2000);
                if (!RequiredByField.ContainsKey("idfsCustomReportType")) RequiredByField.Add("idfsCustomReportType", c => true);
                if (!RequiredByProperty.ContainsKey("idfsCustomReportType")) RequiredByProperty.Add("idfsCustomReportType", c => true);
                
                if (!RequiredByField.ContainsKey("intRowOrder")) RequiredByField.Add("intRowOrder", c => true);
                if (!RequiredByProperty.ContainsKey("intRowOrder")) RequiredByProperty.Add("intRowOrder", c => true);
                
                if (!RequiredByField.ContainsKey("idfsDiagnosisOrReportDiagnosisGroup")) RequiredByField.Add("idfsDiagnosisOrReportDiagnosisGroup", c => true);
                if (!RequiredByProperty.ContainsKey("idfsDiagnosisOrReportDiagnosisGroup")) RequiredByProperty.Add("idfsDiagnosisOrReportDiagnosisGroup", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfReportRows,
                    _str_idfReportRows, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsCustomReportType,
                    _str_idfsCustomReportType, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intRowOrder,
                    _str_intRowOrder, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsDiagnosisOrGroup,
                    _str_idfsDiagnosisOrGroup, null, false, true, true, true, false, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsDiagnosisOrReportDiagnosisGroup,
                    "strDiagnosisOrReportDiagnosisGroup", null, false, true, true, true, false, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strUsingType,
                    _str_strUsingType, null, false, true, true, true, false, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsReportAdditionalText,
                    _str_idfsReportAdditionalText, null, false, true, true, true, false, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsICDReportAdditionalText,
                    _str_idfsICDReportAdditionalText, null, false, true, true, true, false, null
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
                    (manager, c, pars) => ((CustomReportRow)c).MarkToDelete(),
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
	