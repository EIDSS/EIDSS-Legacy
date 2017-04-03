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
    public abstract partial class StatisticListItem : 
        EditableObject<StatisticListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfStatistic), NonUpdatable, PrimaryKey]
        public abstract Int64 idfStatistic { get; set; }
                
        [LocalizedDisplayName(_str_idfsStatisticDataType)]
        [MapField(_str_idfsStatisticDataType)]
        public abstract Int64 idfsStatisticDataType { get; set; }
        protected Int64 idfsStatisticDataType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsStatisticDataType).OriginalValue; } }
        protected Int64 idfsStatisticDataType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsStatisticDataType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsStatisticAreaType)]
        [MapField(_str_idfsStatisticAreaType)]
        public abstract Int64? idfsStatisticAreaType { get; set; }
        protected Int64? idfsStatisticAreaType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStatisticAreaType).OriginalValue; } }
        protected Int64? idfsStatisticAreaType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStatisticAreaType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsStatisticalAgeGroup)]
        [MapField(_str_idfsStatisticalAgeGroup)]
        public abstract Int64? idfsStatisticalAgeGroup { get; set; }
        protected Int64? idfsStatisticalAgeGroup_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStatisticalAgeGroup).OriginalValue; } }
        protected Int64? idfsStatisticalAgeGroup_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStatisticalAgeGroup).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strStatisticalAgeGroup)]
        [MapField(_str_strStatisticalAgeGroup)]
        public abstract String strStatisticalAgeGroup { get; set; }
        protected String strStatisticalAgeGroup_Original { get { return ((EditableValue<String>)((dynamic)this)._strStatisticalAgeGroup).OriginalValue; } }
        protected String strStatisticalAgeGroup_Previous { get { return ((EditableValue<String>)((dynamic)this)._strStatisticalAgeGroup).PreviousValue; } }
                
        [LocalizedDisplayName(_str_defDataTypeName)]
        [MapField(_str_defDataTypeName)]
        public abstract String defDataTypeName { get; set; }
        protected String defDataTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._defDataTypeName).OriginalValue; } }
        protected String defDataTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._defDataTypeName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_varValue)]
        [MapField(_str_varValue)]
        public abstract Double? varValue { get; set; }
        protected Double? varValue_Original { get { return ((EditableValue<Double?>)((dynamic)this)._varValue).OriginalValue; } }
        protected Double? varValue_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._varValue).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsMainBaseReference)]
        [MapField(_str_idfsMainBaseReference)]
        public abstract Int64? idfsMainBaseReference { get; set; }
        protected Int64? idfsMainBaseReference_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMainBaseReference).OriginalValue; } }
        protected Int64? idfsMainBaseReference_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMainBaseReference).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsStatisticPeriodType)]
        [MapField(_str_idfsStatisticPeriodType)]
        public abstract Int64? idfsStatisticPeriodType { get; set; }
        protected Int64? idfsStatisticPeriodType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStatisticPeriodType).OriginalValue; } }
        protected Int64? idfsStatisticPeriodType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStatisticPeriodType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsArea)]
        [MapField(_str_idfsArea)]
        public abstract Int64 idfsArea { get; set; }
        protected Int64 idfsArea_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsArea).OriginalValue; } }
        protected Int64 idfsArea_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsArea).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datStatisticStartDate)]
        [MapField(_str_datStatisticStartDate)]
        public abstract DateTime? datStatisticStartDate { get; set; }
        protected DateTime? datStatisticStartDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStatisticStartDate).OriginalValue; } }
        protected DateTime? datStatisticStartDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStatisticStartDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_setnDataTypeName)]
        [MapField(_str_setnDataTypeName)]
        public abstract String setnDataTypeName { get; set; }
        protected String setnDataTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._setnDataTypeName).OriginalValue; } }
        protected String setnDataTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._setnDataTypeName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_ParameterType)]
        [MapField(_str_ParameterType)]
        public abstract String ParameterType { get; set; }
        protected String ParameterType_Original { get { return ((EditableValue<String>)((dynamic)this)._parameterType).OriginalValue; } }
        protected String ParameterType_Previous { get { return ((EditableValue<String>)((dynamic)this)._parameterType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsParameterType)]
        [MapField(_str_idfsParameterType)]
        public abstract Int64? idfsParameterType { get; set; }
        protected Int64? idfsParameterType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParameterType).OriginalValue; } }
        protected Int64? idfsParameterType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParameterType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_defParameterName)]
        [MapField(_str_defParameterName)]
        public abstract String defParameterName { get; set; }
        protected String defParameterName_Original { get { return ((EditableValue<String>)((dynamic)this)._defParameterName).OriginalValue; } }
        protected String defParameterName_Previous { get { return ((EditableValue<String>)((dynamic)this)._defParameterName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_setnParameterName)]
        [MapField(_str_setnParameterName)]
        public abstract String setnParameterName { get; set; }
        protected String setnParameterName_Original { get { return ((EditableValue<String>)((dynamic)this)._setnParameterName).OriginalValue; } }
        protected String setnParameterName_Previous { get { return ((EditableValue<String>)((dynamic)this)._setnParameterName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsParameterName)]
        [MapField(_str_idfsParameterName)]
        public abstract Int64? idfsParameterName { get; set; }
        protected Int64? idfsParameterName_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParameterName).OriginalValue; } }
        protected Int64? idfsParameterName_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParameterName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_defAreaTypeName)]
        [MapField(_str_defAreaTypeName)]
        public abstract String defAreaTypeName { get; set; }
        protected String defAreaTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._defAreaTypeName).OriginalValue; } }
        protected String defAreaTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._defAreaTypeName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_setnAreaTypeName)]
        [MapField(_str_setnAreaTypeName)]
        public abstract String setnAreaTypeName { get; set; }
        protected String setnAreaTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._setnAreaTypeName).OriginalValue; } }
        protected String setnAreaTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._setnAreaTypeName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_defPeriodTypeName)]
        [MapField(_str_defPeriodTypeName)]
        public abstract String defPeriodTypeName { get; set; }
        protected String defPeriodTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._defPeriodTypeName).OriginalValue; } }
        protected String defPeriodTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._defPeriodTypeName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_setnPeriodTypeName)]
        [MapField(_str_setnPeriodTypeName)]
        public abstract String setnPeriodTypeName { get; set; }
        protected String setnPeriodTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._setnPeriodTypeName).OriginalValue; } }
        protected String setnPeriodTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._setnPeriodTypeName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_setnArea)]
        [MapField(_str_setnArea)]
        public abstract String setnArea { get; set; }
        protected String setnArea_Original { get { return ((EditableValue<String>)((dynamic)this)._setnArea).OriginalValue; } }
        protected String setnArea_Previous { get { return ((EditableValue<String>)((dynamic)this)._setnArea).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<StatisticListItem, object> _get_func;
            internal Action<StatisticListItem, string> _set_func;
            internal Action<StatisticListItem, StatisticListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfStatistic = "idfStatistic";
        internal const string _str_idfsStatisticDataType = "idfsStatisticDataType";
        internal const string _str_idfsStatisticAreaType = "idfsStatisticAreaType";
        internal const string _str_idfsStatisticalAgeGroup = "idfsStatisticalAgeGroup";
        internal const string _str_strStatisticalAgeGroup = "strStatisticalAgeGroup";
        internal const string _str_defDataTypeName = "defDataTypeName";
        internal const string _str_varValue = "varValue";
        internal const string _str_idfsMainBaseReference = "idfsMainBaseReference";
        internal const string _str_idfsStatisticPeriodType = "idfsStatisticPeriodType";
        internal const string _str_idfsArea = "idfsArea";
        internal const string _str_datStatisticStartDate = "datStatisticStartDate";
        internal const string _str_setnDataTypeName = "setnDataTypeName";
        internal const string _str_ParameterType = "ParameterType";
        internal const string _str_idfsParameterType = "idfsParameterType";
        internal const string _str_defParameterName = "defParameterName";
        internal const string _str_setnParameterName = "setnParameterName";
        internal const string _str_idfsParameterName = "idfsParameterName";
        internal const string _str_defAreaTypeName = "defAreaTypeName";
        internal const string _str_setnAreaTypeName = "setnAreaTypeName";
        internal const string _str_defPeriodTypeName = "defPeriodTypeName";
        internal const string _str_setnPeriodTypeName = "setnPeriodTypeName";
        internal const string _str_setnArea = "setnArea";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_idfsHumanGender = "idfsHumanGender";
        internal const string _str_StatisticDataType = "StatisticDataType";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Settlement = "Settlement";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfStatistic, _formname = _str_idfStatistic, _type = "Int64",
              _get_func = o => o.idfStatistic,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfStatistic != newval) o.idfStatistic = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfStatistic != c.idfStatistic || o.IsRIRPropChanged(_str_idfStatistic, c)) 
                  m.Add(_str_idfStatistic, o.ObjectIdent + _str_idfStatistic, o.ObjectIdent2 + _str_idfStatistic, o.ObjectIdent3 + _str_idfStatistic, "Int64", 
                    o.idfStatistic == null ? "" : o.idfStatistic.ToString(),                  
                  o.IsReadOnly(_str_idfStatistic), o.IsInvisible(_str_idfStatistic), o.IsRequired(_str_idfStatistic)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsStatisticDataType, _formname = _str_idfsStatisticDataType, _type = "Int64",
              _get_func = o => o.idfsStatisticDataType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsStatisticDataType != newval) 
                  o.StatisticDataType = o.StatisticDataTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsStatisticDataType != newval) o.idfsStatisticDataType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsStatisticDataType != c.idfsStatisticDataType || o.IsRIRPropChanged(_str_idfsStatisticDataType, c)) 
                  m.Add(_str_idfsStatisticDataType, o.ObjectIdent + _str_idfsStatisticDataType, o.ObjectIdent2 + _str_idfsStatisticDataType, o.ObjectIdent3 + _str_idfsStatisticDataType, "Int64", 
                    o.idfsStatisticDataType == null ? "" : o.idfsStatisticDataType.ToString(),                  
                  o.IsReadOnly(_str_idfsStatisticDataType), o.IsInvisible(_str_idfsStatisticDataType), o.IsRequired(_str_idfsStatisticDataType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsStatisticAreaType, _formname = _str_idfsStatisticAreaType, _type = "Int64?",
              _get_func = o => o.idfsStatisticAreaType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsStatisticAreaType != newval) o.idfsStatisticAreaType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsStatisticAreaType != c.idfsStatisticAreaType || o.IsRIRPropChanged(_str_idfsStatisticAreaType, c)) 
                  m.Add(_str_idfsStatisticAreaType, o.ObjectIdent + _str_idfsStatisticAreaType, o.ObjectIdent2 + _str_idfsStatisticAreaType, o.ObjectIdent3 + _str_idfsStatisticAreaType, "Int64?", 
                    o.idfsStatisticAreaType == null ? "" : o.idfsStatisticAreaType.ToString(),                  
                  o.IsReadOnly(_str_idfsStatisticAreaType), o.IsInvisible(_str_idfsStatisticAreaType), o.IsRequired(_str_idfsStatisticAreaType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsStatisticalAgeGroup, _formname = _str_idfsStatisticalAgeGroup, _type = "Int64?",
              _get_func = o => o.idfsStatisticalAgeGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsStatisticalAgeGroup != newval) o.idfsStatisticalAgeGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsStatisticalAgeGroup != c.idfsStatisticalAgeGroup || o.IsRIRPropChanged(_str_idfsStatisticalAgeGroup, c)) 
                  m.Add(_str_idfsStatisticalAgeGroup, o.ObjectIdent + _str_idfsStatisticalAgeGroup, o.ObjectIdent2 + _str_idfsStatisticalAgeGroup, o.ObjectIdent3 + _str_idfsStatisticalAgeGroup, "Int64?", 
                    o.idfsStatisticalAgeGroup == null ? "" : o.idfsStatisticalAgeGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsStatisticalAgeGroup), o.IsInvisible(_str_idfsStatisticalAgeGroup), o.IsRequired(_str_idfsStatisticalAgeGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strStatisticalAgeGroup, _formname = _str_strStatisticalAgeGroup, _type = "String",
              _get_func = o => o.strStatisticalAgeGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strStatisticalAgeGroup != newval) o.strStatisticalAgeGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.strStatisticalAgeGroup != c.strStatisticalAgeGroup || o.IsRIRPropChanged(_str_strStatisticalAgeGroup, c)) 
                  m.Add(_str_strStatisticalAgeGroup, o.ObjectIdent + _str_strStatisticalAgeGroup, o.ObjectIdent2 + _str_strStatisticalAgeGroup, o.ObjectIdent3 + _str_strStatisticalAgeGroup, "String", 
                    o.strStatisticalAgeGroup == null ? "" : o.strStatisticalAgeGroup.ToString(),                  
                  o.IsReadOnly(_str_strStatisticalAgeGroup), o.IsInvisible(_str_strStatisticalAgeGroup), o.IsRequired(_str_strStatisticalAgeGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_defDataTypeName, _formname = _str_defDataTypeName, _type = "String",
              _get_func = o => o.defDataTypeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.defDataTypeName != newval) o.defDataTypeName = newval; },
              _compare_func = (o, c, m) => {
                if (o.defDataTypeName != c.defDataTypeName || o.IsRIRPropChanged(_str_defDataTypeName, c)) 
                  m.Add(_str_defDataTypeName, o.ObjectIdent + _str_defDataTypeName, o.ObjectIdent2 + _str_defDataTypeName, o.ObjectIdent3 + _str_defDataTypeName, "String", 
                    o.defDataTypeName == null ? "" : o.defDataTypeName.ToString(),                  
                  o.IsReadOnly(_str_defDataTypeName), o.IsInvisible(_str_defDataTypeName), o.IsRequired(_str_defDataTypeName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_varValue, _formname = _str_varValue, _type = "Double?",
              _get_func = o => o.varValue,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDoubleNullable(val); if (o.varValue != newval) o.varValue = newval; },
              _compare_func = (o, c, m) => {
                if (o.varValue != c.varValue || o.IsRIRPropChanged(_str_varValue, c)) 
                  m.Add(_str_varValue, o.ObjectIdent + _str_varValue, o.ObjectIdent2 + _str_varValue, o.ObjectIdent3 + _str_varValue, "Double?", 
                    o.varValue == null ? "" : o.varValue.Value.ToString(new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = ".", NumberGroupSeparator = "" }),                  
                  o.IsReadOnly(_str_varValue), o.IsInvisible(_str_varValue), o.IsRequired(_str_varValue)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsMainBaseReference, _formname = _str_idfsMainBaseReference, _type = "Int64?",
              _get_func = o => o.idfsMainBaseReference,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsMainBaseReference != newval) o.idfsMainBaseReference = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsMainBaseReference != c.idfsMainBaseReference || o.IsRIRPropChanged(_str_idfsMainBaseReference, c)) 
                  m.Add(_str_idfsMainBaseReference, o.ObjectIdent + _str_idfsMainBaseReference, o.ObjectIdent2 + _str_idfsMainBaseReference, o.ObjectIdent3 + _str_idfsMainBaseReference, "Int64?", 
                    o.idfsMainBaseReference == null ? "" : o.idfsMainBaseReference.ToString(),                  
                  o.IsReadOnly(_str_idfsMainBaseReference), o.IsInvisible(_str_idfsMainBaseReference), o.IsRequired(_str_idfsMainBaseReference)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsStatisticPeriodType, _formname = _str_idfsStatisticPeriodType, _type = "Int64?",
              _get_func = o => o.idfsStatisticPeriodType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsStatisticPeriodType != newval) o.idfsStatisticPeriodType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsStatisticPeriodType != c.idfsStatisticPeriodType || o.IsRIRPropChanged(_str_idfsStatisticPeriodType, c)) 
                  m.Add(_str_idfsStatisticPeriodType, o.ObjectIdent + _str_idfsStatisticPeriodType, o.ObjectIdent2 + _str_idfsStatisticPeriodType, o.ObjectIdent3 + _str_idfsStatisticPeriodType, "Int64?", 
                    o.idfsStatisticPeriodType == null ? "" : o.idfsStatisticPeriodType.ToString(),                  
                  o.IsReadOnly(_str_idfsStatisticPeriodType), o.IsInvisible(_str_idfsStatisticPeriodType), o.IsRequired(_str_idfsStatisticPeriodType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsArea, _formname = _str_idfsArea, _type = "Int64",
              _get_func = o => o.idfsArea,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsArea != newval) o.idfsArea = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsArea != c.idfsArea || o.IsRIRPropChanged(_str_idfsArea, c)) 
                  m.Add(_str_idfsArea, o.ObjectIdent + _str_idfsArea, o.ObjectIdent2 + _str_idfsArea, o.ObjectIdent3 + _str_idfsArea, "Int64", 
                    o.idfsArea == null ? "" : o.idfsArea.ToString(),                  
                  o.IsReadOnly(_str_idfsArea), o.IsInvisible(_str_idfsArea), o.IsRequired(_str_idfsArea)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datStatisticStartDate, _formname = _str_datStatisticStartDate, _type = "DateTime?",
              _get_func = o => o.datStatisticStartDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datStatisticStartDate != newval) o.datStatisticStartDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datStatisticStartDate != c.datStatisticStartDate || o.IsRIRPropChanged(_str_datStatisticStartDate, c)) 
                  m.Add(_str_datStatisticStartDate, o.ObjectIdent + _str_datStatisticStartDate, o.ObjectIdent2 + _str_datStatisticStartDate, o.ObjectIdent3 + _str_datStatisticStartDate, "DateTime?", 
                    o.datStatisticStartDate == null ? "" : o.datStatisticStartDate.ToString(),                  
                  o.IsReadOnly(_str_datStatisticStartDate), o.IsInvisible(_str_datStatisticStartDate), o.IsRequired(_str_datStatisticStartDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_setnDataTypeName, _formname = _str_setnDataTypeName, _type = "String",
              _get_func = o => o.setnDataTypeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.setnDataTypeName != newval) o.setnDataTypeName = newval; },
              _compare_func = (o, c, m) => {
                if (o.setnDataTypeName != c.setnDataTypeName || o.IsRIRPropChanged(_str_setnDataTypeName, c)) 
                  m.Add(_str_setnDataTypeName, o.ObjectIdent + _str_setnDataTypeName, o.ObjectIdent2 + _str_setnDataTypeName, o.ObjectIdent3 + _str_setnDataTypeName, "String", 
                    o.setnDataTypeName == null ? "" : o.setnDataTypeName.ToString(),                  
                  o.IsReadOnly(_str_setnDataTypeName), o.IsInvisible(_str_setnDataTypeName), o.IsRequired(_str_setnDataTypeName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_ParameterType, _formname = _str_ParameterType, _type = "String",
              _get_func = o => o.ParameterType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.ParameterType != newval) o.ParameterType = newval; },
              _compare_func = (o, c, m) => {
                if (o.ParameterType != c.ParameterType || o.IsRIRPropChanged(_str_ParameterType, c)) 
                  m.Add(_str_ParameterType, o.ObjectIdent + _str_ParameterType, o.ObjectIdent2 + _str_ParameterType, o.ObjectIdent3 + _str_ParameterType, "String", 
                    o.ParameterType == null ? "" : o.ParameterType.ToString(),                  
                  o.IsReadOnly(_str_ParameterType), o.IsInvisible(_str_ParameterType), o.IsRequired(_str_ParameterType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsParameterType, _formname = _str_idfsParameterType, _type = "Int64?",
              _get_func = o => o.idfsParameterType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsParameterType != newval) o.idfsParameterType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsParameterType != c.idfsParameterType || o.IsRIRPropChanged(_str_idfsParameterType, c)) 
                  m.Add(_str_idfsParameterType, o.ObjectIdent + _str_idfsParameterType, o.ObjectIdent2 + _str_idfsParameterType, o.ObjectIdent3 + _str_idfsParameterType, "Int64?", 
                    o.idfsParameterType == null ? "" : o.idfsParameterType.ToString(),                  
                  o.IsReadOnly(_str_idfsParameterType), o.IsInvisible(_str_idfsParameterType), o.IsRequired(_str_idfsParameterType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_defParameterName, _formname = _str_defParameterName, _type = "String",
              _get_func = o => o.defParameterName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.defParameterName != newval) o.defParameterName = newval; },
              _compare_func = (o, c, m) => {
                if (o.defParameterName != c.defParameterName || o.IsRIRPropChanged(_str_defParameterName, c)) 
                  m.Add(_str_defParameterName, o.ObjectIdent + _str_defParameterName, o.ObjectIdent2 + _str_defParameterName, o.ObjectIdent3 + _str_defParameterName, "String", 
                    o.defParameterName == null ? "" : o.defParameterName.ToString(),                  
                  o.IsReadOnly(_str_defParameterName), o.IsInvisible(_str_defParameterName), o.IsRequired(_str_defParameterName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_setnParameterName, _formname = _str_setnParameterName, _type = "String",
              _get_func = o => o.setnParameterName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.setnParameterName != newval) o.setnParameterName = newval; },
              _compare_func = (o, c, m) => {
                if (o.setnParameterName != c.setnParameterName || o.IsRIRPropChanged(_str_setnParameterName, c)) 
                  m.Add(_str_setnParameterName, o.ObjectIdent + _str_setnParameterName, o.ObjectIdent2 + _str_setnParameterName, o.ObjectIdent3 + _str_setnParameterName, "String", 
                    o.setnParameterName == null ? "" : o.setnParameterName.ToString(),                  
                  o.IsReadOnly(_str_setnParameterName), o.IsInvisible(_str_setnParameterName), o.IsRequired(_str_setnParameterName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsParameterName, _formname = _str_idfsParameterName, _type = "Int64?",
              _get_func = o => o.idfsParameterName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsParameterName != newval) o.idfsParameterName = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsParameterName != c.idfsParameterName || o.IsRIRPropChanged(_str_idfsParameterName, c)) 
                  m.Add(_str_idfsParameterName, o.ObjectIdent + _str_idfsParameterName, o.ObjectIdent2 + _str_idfsParameterName, o.ObjectIdent3 + _str_idfsParameterName, "Int64?", 
                    o.idfsParameterName == null ? "" : o.idfsParameterName.ToString(),                  
                  o.IsReadOnly(_str_idfsParameterName), o.IsInvisible(_str_idfsParameterName), o.IsRequired(_str_idfsParameterName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_defAreaTypeName, _formname = _str_defAreaTypeName, _type = "String",
              _get_func = o => o.defAreaTypeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.defAreaTypeName != newval) o.defAreaTypeName = newval; },
              _compare_func = (o, c, m) => {
                if (o.defAreaTypeName != c.defAreaTypeName || o.IsRIRPropChanged(_str_defAreaTypeName, c)) 
                  m.Add(_str_defAreaTypeName, o.ObjectIdent + _str_defAreaTypeName, o.ObjectIdent2 + _str_defAreaTypeName, o.ObjectIdent3 + _str_defAreaTypeName, "String", 
                    o.defAreaTypeName == null ? "" : o.defAreaTypeName.ToString(),                  
                  o.IsReadOnly(_str_defAreaTypeName), o.IsInvisible(_str_defAreaTypeName), o.IsRequired(_str_defAreaTypeName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_setnAreaTypeName, _formname = _str_setnAreaTypeName, _type = "String",
              _get_func = o => o.setnAreaTypeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.setnAreaTypeName != newval) o.setnAreaTypeName = newval; },
              _compare_func = (o, c, m) => {
                if (o.setnAreaTypeName != c.setnAreaTypeName || o.IsRIRPropChanged(_str_setnAreaTypeName, c)) 
                  m.Add(_str_setnAreaTypeName, o.ObjectIdent + _str_setnAreaTypeName, o.ObjectIdent2 + _str_setnAreaTypeName, o.ObjectIdent3 + _str_setnAreaTypeName, "String", 
                    o.setnAreaTypeName == null ? "" : o.setnAreaTypeName.ToString(),                  
                  o.IsReadOnly(_str_setnAreaTypeName), o.IsInvisible(_str_setnAreaTypeName), o.IsRequired(_str_setnAreaTypeName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_defPeriodTypeName, _formname = _str_defPeriodTypeName, _type = "String",
              _get_func = o => o.defPeriodTypeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.defPeriodTypeName != newval) o.defPeriodTypeName = newval; },
              _compare_func = (o, c, m) => {
                if (o.defPeriodTypeName != c.defPeriodTypeName || o.IsRIRPropChanged(_str_defPeriodTypeName, c)) 
                  m.Add(_str_defPeriodTypeName, o.ObjectIdent + _str_defPeriodTypeName, o.ObjectIdent2 + _str_defPeriodTypeName, o.ObjectIdent3 + _str_defPeriodTypeName, "String", 
                    o.defPeriodTypeName == null ? "" : o.defPeriodTypeName.ToString(),                  
                  o.IsReadOnly(_str_defPeriodTypeName), o.IsInvisible(_str_defPeriodTypeName), o.IsRequired(_str_defPeriodTypeName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_setnPeriodTypeName, _formname = _str_setnPeriodTypeName, _type = "String",
              _get_func = o => o.setnPeriodTypeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.setnPeriodTypeName != newval) o.setnPeriodTypeName = newval; },
              _compare_func = (o, c, m) => {
                if (o.setnPeriodTypeName != c.setnPeriodTypeName || o.IsRIRPropChanged(_str_setnPeriodTypeName, c)) 
                  m.Add(_str_setnPeriodTypeName, o.ObjectIdent + _str_setnPeriodTypeName, o.ObjectIdent2 + _str_setnPeriodTypeName, o.ObjectIdent3 + _str_setnPeriodTypeName, "String", 
                    o.setnPeriodTypeName == null ? "" : o.setnPeriodTypeName.ToString(),                  
                  o.IsReadOnly(_str_setnPeriodTypeName), o.IsInvisible(_str_setnPeriodTypeName), o.IsRequired(_str_setnPeriodTypeName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_setnArea, _formname = _str_setnArea, _type = "String",
              _get_func = o => o.setnArea,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.setnArea != newval) o.setnArea = newval; },
              _compare_func = (o, c, m) => {
                if (o.setnArea != c.setnArea || o.IsRIRPropChanged(_str_setnArea, c)) 
                  m.Add(_str_setnArea, o.ObjectIdent + _str_setnArea, o.ObjectIdent2 + _str_setnArea, o.ObjectIdent3 + _str_setnArea, "String", 
                    o.setnArea == null ? "" : o.setnArea.ToString(),                  
                  o.IsReadOnly(_str_setnArea), o.IsInvisible(_str_setnArea), o.IsRequired(_str_setnArea)); 
                  }
              }, 
        
            new field_info {
              _name = _str_idfsCountry, _formname = _str_idfsCountry, _type = "long?",
              _get_func = o => o.idfsCountry,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsCountry != newval) o.idfsCountry = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_idfsCountry, c)) {
                  m.Add(_str_idfsCountry, o.ObjectIdent + _str_idfsCountry, o.ObjectIdent2 + _str_idfsCountry, o.ObjectIdent3 + _str_idfsCountry,  "long?", 
                    o.idfsCountry == null ? "" : o.idfsCountry.ToString(),                  
                    o.IsReadOnly(_str_idfsCountry), o.IsInvisible(_str_idfsCountry), o.IsRequired(_str_idfsCountry));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsRegion, _formname = _str_idfsRegion, _type = "long?",
              _get_func = o => o.idfsRegion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsRegion != newval) o.idfsRegion = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_idfsRegion, c)) {
                  m.Add(_str_idfsRegion, o.ObjectIdent + _str_idfsRegion, o.ObjectIdent2 + _str_idfsRegion, o.ObjectIdent3 + _str_idfsRegion,  "long?", 
                    o.idfsRegion == null ? "" : o.idfsRegion.ToString(),                  
                    o.IsReadOnly(_str_idfsRegion), o.IsInvisible(_str_idfsRegion), o.IsRequired(_str_idfsRegion));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsRayon, _formname = _str_idfsRayon, _type = "long?",
              _get_func = o => o.idfsRayon,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsRayon != newval) o.idfsRayon = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_idfsRayon, c)) {
                  m.Add(_str_idfsRayon, o.ObjectIdent + _str_idfsRayon, o.ObjectIdent2 + _str_idfsRayon, o.ObjectIdent3 + _str_idfsRayon,  "long?", 
                    o.idfsRayon == null ? "" : o.idfsRayon.ToString(),                  
                    o.IsReadOnly(_str_idfsRayon), o.IsInvisible(_str_idfsRayon), o.IsRequired(_str_idfsRayon));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsSettlement, _formname = _str_idfsSettlement, _type = "long?",
              _get_func = o => o.idfsSettlement,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSettlement != newval) o.idfsSettlement = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_idfsSettlement, c)) {
                  m.Add(_str_idfsSettlement, o.ObjectIdent + _str_idfsSettlement, o.ObjectIdent2 + _str_idfsSettlement, o.ObjectIdent3 + _str_idfsSettlement,  "long?", 
                    o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(),                  
                    o.IsReadOnly(_str_idfsSettlement), o.IsInvisible(_str_idfsSettlement), o.IsRequired(_str_idfsSettlement));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsHumanGender, _formname = _str_idfsHumanGender, _type = "long?",
              _get_func = o => o.idfsHumanGender,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsHumanGender != newval) o.idfsHumanGender = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsHumanGender != c.idfsHumanGender || o.IsRIRPropChanged(_str_idfsHumanGender, c)) {
                  m.Add(_str_idfsHumanGender, o.ObjectIdent + _str_idfsHumanGender, o.ObjectIdent2 + _str_idfsHumanGender, o.ObjectIdent3 + _str_idfsHumanGender,  "long?", 
                    o.idfsHumanGender == null ? "" : o.idfsHumanGender.ToString(),                  
                    o.IsReadOnly(_str_idfsHumanGender), o.IsInvisible(_str_idfsHumanGender), o.IsRequired(_str_idfsHumanGender));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_StatisticDataType, _formname = _str_StatisticDataType, _type = "Lookup",
              _get_func = o => { if (o.StatisticDataType == null) return null; return o.StatisticDataType.idfsBaseReference; },
              _set_func = (o, val) => { o.StatisticDataType = o.StatisticDataTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsStatisticDataType != c.idfsStatisticDataType || o.IsRIRPropChanged(_str_StatisticDataType, c)) {
                  m.Add(_str_StatisticDataType, o.ObjectIdent + _str_StatisticDataType, o.ObjectIdent2 + _str_StatisticDataType, o.ObjectIdent3 + _str_StatisticDataType, "Lookup", o.idfsStatisticDataType == null ? "" : o.idfsStatisticDataType.ToString(), o.IsReadOnly(_str_StatisticDataType), o.IsInvisible(_str_StatisticDataType), o.IsRequired(_str_StatisticDataType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_StatisticDataType + "Lookup", _formname = _str_StatisticDataType + "Lookup", _type = "LookupContent",
              _get_func = o => o.StatisticDataTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Country, _formname = _str_Country, _type = "Lookup",
              _get_func = o => { if (o.Country == null) return null; return o.Country.idfsCountry; },
              _set_func = (o, val) => { o.Country = o.CountryLookup.Where(c => c.idfsCountry.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_Country, c)) {
                  m.Add(_str_Country, o.ObjectIdent + _str_Country, o.ObjectIdent2 + _str_Country, o.ObjectIdent3 + _str_Country, "Lookup", o.idfsCountry == null ? "" : o.idfsCountry.ToString(), o.IsReadOnly(_str_Country), o.IsInvisible(_str_Country), o.IsRequired(_str_Country)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Country + "Lookup", _formname = _str_Country + "Lookup", _type = "LookupContent",
              _get_func = o => o.CountryLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Region, _formname = _str_Region, _type = "Lookup",
              _get_func = o => { if (o.Region == null) return null; return o.Region.idfsRegion; },
              _set_func = (o, val) => { o.Region = o.RegionLookup.Where(c => c.idfsRegion.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_Region, c)) {
                  m.Add(_str_Region, o.ObjectIdent + _str_Region, o.ObjectIdent2 + _str_Region, o.ObjectIdent3 + _str_Region, "Lookup", o.idfsRegion == null ? "" : o.idfsRegion.ToString(), o.IsReadOnly(_str_Region), o.IsInvisible(_str_Region), o.IsRequired(_str_Region)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Region + "Lookup", _formname = _str_Region + "Lookup", _type = "LookupContent",
              _get_func = o => o.RegionLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Rayon, _formname = _str_Rayon, _type = "Lookup",
              _get_func = o => { if (o.Rayon == null) return null; return o.Rayon.idfsRayon; },
              _set_func = (o, val) => { o.Rayon = o.RayonLookup.Where(c => c.idfsRayon.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_Rayon, c)) {
                  m.Add(_str_Rayon, o.ObjectIdent + _str_Rayon, o.ObjectIdent2 + _str_Rayon, o.ObjectIdent3 + _str_Rayon, "Lookup", o.idfsRayon == null ? "" : o.idfsRayon.ToString(), o.IsReadOnly(_str_Rayon), o.IsInvisible(_str_Rayon), o.IsRequired(_str_Rayon)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Rayon + "Lookup", _formname = _str_Rayon + "Lookup", _type = "LookupContent",
              _get_func = o => o.RayonLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Settlement, _formname = _str_Settlement, _type = "Lookup",
              _get_func = o => { if (o.Settlement == null) return null; return o.Settlement.idfsSettlement; },
              _set_func = (o, val) => { o.Settlement = o.SettlementLookup.Where(c => c.idfsSettlement.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_Settlement, c)) {
                  m.Add(_str_Settlement, o.ObjectIdent + _str_Settlement, o.ObjectIdent2 + _str_Settlement, o.ObjectIdent3 + _str_Settlement, "Lookup", o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(), o.IsReadOnly(_str_Settlement), o.IsInvisible(_str_Settlement), o.IsRequired(_str_Settlement)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Settlement + "Lookup", _formname = _str_Settlement + "Lookup", _type = "LookupContent",
              _get_func = o => o.SettlementLookup,
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
            StatisticListItem obj = (StatisticListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_StatisticDataType)]
        [Relation(typeof(StatisticTypeLookup), eidss.model.Schema.StatisticTypeLookup._str_idfsBaseReference, _str_idfsStatisticDataType)]
        public StatisticTypeLookup StatisticDataType
        {
            get { return _StatisticDataType == null ? null : ((long)_StatisticDataType.Key == 0 ? null : _StatisticDataType); }
            set 
            { 
                var oldVal = _StatisticDataType;
                _StatisticDataType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_StatisticDataType != oldVal)
                {
                    if (idfsStatisticDataType != (_StatisticDataType == null
                            ? new Int64()
                            : (Int64)_StatisticDataType.idfsBaseReference))
                        idfsStatisticDataType = _StatisticDataType == null 
                            ? new Int64()
                            : (Int64)_StatisticDataType.idfsBaseReference; 
                    OnPropertyChanged(_str_StatisticDataType); 
                }
            }
        }
        private StatisticTypeLookup _StatisticDataType;

        
        public List<StatisticTypeLookup> StatisticDataTypeLookup
        {
            get { return _StatisticDataTypeLookup; }
        }
        private List<StatisticTypeLookup> _StatisticDataTypeLookup = new List<StatisticTypeLookup>();
            
        [LocalizedDisplayName(_str_Country)]
        [Relation(typeof(CountryLookup), eidss.model.Schema.CountryLookup._str_idfsCountry, _str_idfsCountry)]
        public CountryLookup Country
        {
            get { return _Country == null ? null : ((long)_Country.Key == 0 ? null : _Country); }
            set 
            { 
                var oldVal = _Country;
                _Country = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Country != oldVal)
                {
                    if (idfsCountry != (_Country == null
                            ? new long?()
                            : _Country.idfsCountry))
                        idfsCountry = _Country == null 
                            ? new long?()
                            : _Country.idfsCountry; 
                    OnPropertyChanged(_str_Country); 
                }
            }
        }
        private CountryLookup _Country;

        
        public List<CountryLookup> CountryLookup
        {
            get { return _CountryLookup; }
        }
        private List<CountryLookup> _CountryLookup = new List<CountryLookup>();
            
        [LocalizedDisplayName(_str_Region)]
        [Relation(typeof(RegionLookup), eidss.model.Schema.RegionLookup._str_idfsRegion, _str_idfsRegion)]
        public RegionLookup Region
        {
            get { return _Region == null ? null : ((long)_Region.Key == 0 ? null : _Region); }
            set 
            { 
                var oldVal = _Region;
                _Region = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Region != oldVal)
                {
                    if (idfsRegion != (_Region == null
                            ? new long?()
                            : _Region.idfsRegion))
                        idfsRegion = _Region == null 
                            ? new long?()
                            : _Region.idfsRegion; 
                    OnPropertyChanged(_str_Region); 
                }
            }
        }
        private RegionLookup _Region;

        
        public List<RegionLookup> RegionLookup
        {
            get { return _RegionLookup; }
        }
        private List<RegionLookup> _RegionLookup = new List<RegionLookup>();
            
        [LocalizedDisplayName(_str_Rayon)]
        [Relation(typeof(RayonLookup), eidss.model.Schema.RayonLookup._str_idfsRayon, _str_idfsRayon)]
        public RayonLookup Rayon
        {
            get { return _Rayon == null ? null : ((long)_Rayon.Key == 0 ? null : _Rayon); }
            set 
            { 
                var oldVal = _Rayon;
                _Rayon = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Rayon != oldVal)
                {
                    if (idfsRayon != (_Rayon == null
                            ? new long?()
                            : _Rayon.idfsRayon))
                        idfsRayon = _Rayon == null 
                            ? new long?()
                            : _Rayon.idfsRayon; 
                    OnPropertyChanged(_str_Rayon); 
                }
            }
        }
        private RayonLookup _Rayon;

        
        public List<RayonLookup> RayonLookup
        {
            get { return _RayonLookup; }
        }
        private List<RayonLookup> _RayonLookup = new List<RayonLookup>();
            
        [LocalizedDisplayName(_str_Settlement)]
        [Relation(typeof(SettlementLookup), eidss.model.Schema.SettlementLookup._str_idfsSettlement, _str_idfsSettlement)]
        public SettlementLookup Settlement
        {
            get { return _Settlement == null ? null : ((long)_Settlement.Key == 0 ? null : _Settlement); }
            set 
            { 
                var oldVal = _Settlement;
                _Settlement = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Settlement != oldVal)
                {
                    if (idfsSettlement != (_Settlement == null
                            ? new long?()
                            : _Settlement.idfsSettlement))
                        idfsSettlement = _Settlement == null 
                            ? new long?()
                            : _Settlement.idfsSettlement; 
                    OnPropertyChanged(_str_Settlement); 
                }
            }
        }
        private SettlementLookup _Settlement;

        
        public List<SettlementLookup> SettlementLookup
        {
            get { return _SettlementLookup; }
        }
        private List<SettlementLookup> _SettlementLookup = new List<SettlementLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_StatisticDataType:
                    return new BvSelectList(StatisticDataTypeLookup, eidss.model.Schema.StatisticTypeLookup._str_idfsBaseReference, null, StatisticDataType, _str_idfsStatisticDataType);
            
                case _str_Country:
                    return new BvSelectList(CountryLookup, eidss.model.Schema.CountryLookup._str_idfsCountry, null, Country, _str_idfsCountry);
            
                case _str_Region:
                    return new BvSelectList(RegionLookup, eidss.model.Schema.RegionLookup._str_idfsRegion, null, Region, _str_idfsRegion);
            
                case _str_Rayon:
                    return new BvSelectList(RayonLookup, eidss.model.Schema.RayonLookup._str_idfsRayon, null, Rayon, _str_idfsRayon);
            
                case _str_Settlement:
                    return new BvSelectList(SettlementLookup, eidss.model.Schema.SettlementLookup._str_idfsSettlement, null, Settlement, _str_idfsSettlement);
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str_idfsCountry)]
        public long? idfsCountry
        {
            get { return m_idfsCountry; }
            set { if (m_idfsCountry != value) { m_idfsCountry = value; OnPropertyChanged(_str_idfsCountry); } }
        }
        private long? m_idfsCountry;
        
          [LocalizedDisplayName(_str_idfsRegion)]
        public long? idfsRegion
        {
            get { return m_idfsRegion; }
            set { if (m_idfsRegion != value) { m_idfsRegion = value; OnPropertyChanged(_str_idfsRegion); } }
        }
        private long? m_idfsRegion;
        
          [LocalizedDisplayName(_str_idfsRayon)]
        public long? idfsRayon
        {
            get { return m_idfsRayon; }
            set { if (m_idfsRayon != value) { m_idfsRayon = value; OnPropertyChanged(_str_idfsRayon); } }
        }
        private long? m_idfsRayon;
        
          [LocalizedDisplayName(_str_idfsSettlement)]
        public long? idfsSettlement
        {
            get { return m_idfsSettlement; }
            set { if (m_idfsSettlement != value) { m_idfsSettlement = value; OnPropertyChanged(_str_idfsSettlement); } }
        }
        private long? m_idfsSettlement;
        
          [LocalizedDisplayName(_str_idfsHumanGender)]
        public long? idfsHumanGender
        {
            get { return m_idfsHumanGender; }
            set { if (m_idfsHumanGender != value) { m_idfsHumanGender = value; OnPropertyChanged(_str_idfsHumanGender); } }
        }
        private long? m_idfsHumanGender;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "StatisticListItem";

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
            var ret = base.Clone() as StatisticListItem;
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
            var ret = base.Clone() as StatisticListItem;
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
        public StatisticListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as StatisticListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfStatistic; } }
        public string KeyName { get { return "idfStatistic"; } }
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
        
            var _prev_idfsStatisticDataType_StatisticDataType = idfsStatisticDataType;
            var _prev_idfsCountry_Country = idfsCountry;
            var _prev_idfsRegion_Region = idfsRegion;
            var _prev_idfsRayon_Rayon = idfsRayon;
            var _prev_idfsSettlement_Settlement = idfsSettlement;
            base.RejectChanges();
        
            if (_prev_idfsStatisticDataType_StatisticDataType != idfsStatisticDataType)
            {
                _StatisticDataType = _StatisticDataTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsStatisticDataType);
            }
            if (_prev_idfsCountry_Country != idfsCountry)
            {
                _Country = _CountryLookup.FirstOrDefault(c => c.idfsCountry == idfsCountry);
            }
            if (_prev_idfsRegion_Region != idfsRegion)
            {
                _Region = _RegionLookup.FirstOrDefault(c => c.idfsRegion == idfsRegion);
            }
            if (_prev_idfsRayon_Rayon != idfsRayon)
            {
                _Rayon = _RayonLookup.FirstOrDefault(c => c.idfsRayon == idfsRayon);
            }
            if (_prev_idfsSettlement_Settlement != idfsSettlement)
            {
                _Settlement = _SettlementLookup.FirstOrDefault(c => c.idfsSettlement == idfsSettlement);
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

        private bool IsRIRPropChanged(string fld, StatisticListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public StatisticListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(StatisticListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(StatisticListItem_PropertyChanged);
        }
        private void StatisticListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as StatisticListItem).Changed(e.PropertyName);
            
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
            StatisticListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            StatisticListItem obj = this;
            
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
    
        private static string[] invisible_names1 = "idfsStatisticAreaType".Split(new char[] { ',' });
        
        private bool _isInvisible(string name)
        {
            
            if (invisible_names1.Where(c => c == name).Count() > 0)
                return new Func<StatisticListItem, bool>(c => true)(this);
            
            return false;
                
        }

    
        private static string[] readonly_names1 = "Region,idfsRegion".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "Rayon,idfsRayon".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "Settlement,idfsSettlement".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<StatisticListItem, bool>(c => c.idfsCountry == null /*|| c.StatisticDataType == null 
                        || (c.StatisticDataType != null && c.StatisticDataType.idfsStatisticAreaType == (long)eidss.model.Enums.StatisticAreaType.Country)*/
                        )(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<StatisticListItem, bool>(c => c.idfsRegion == null /*|| c.StatisticDataType == null 
                        || (c.StatisticDataType != null && c.StatisticDataType.idfsStatisticAreaType == (long)eidss.model.Enums.StatisticAreaType.Country)
                        || (c.StatisticDataType != null && c.StatisticDataType.idfsStatisticAreaType == (long)eidss.model.Enums.StatisticAreaType.Region)*/
                        )(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<StatisticListItem, bool>(c => c.idfsRayon == null /*|| c.StatisticDataType == null 
                        || (c.StatisticDataType != null && c.StatisticDataType.idfsStatisticAreaType == (long)eidss.model.Enums.StatisticAreaType.Country)
                        || (c.StatisticDataType != null && c.StatisticDataType.idfsStatisticAreaType == (long)eidss.model.Enums.StatisticAreaType.Region)
                        || (c.StatisticDataType != null && c.StatisticDataType.idfsStatisticAreaType == (long)eidss.model.Enums.StatisticAreaType.Rayon)*/
                        )(this);
            
            return ReadOnly || new Func<StatisticListItem, bool>(c => false)(this);
                
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


        internal Dictionary<string, Func<StatisticListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<StatisticListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<StatisticListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<StatisticListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<StatisticListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<StatisticListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<StatisticListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~StatisticListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("StatisticTypeLookup", this);
                
                LookupManager.RemoveObject("CountryLookup", this);
                
                LookupManager.RemoveObject("RegionLookup", this);
                
                LookupManager.RemoveObject("RayonLookup", this);
                
                LookupManager.RemoveObject("SettlementLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "StatisticTypeLookup")
                _getAccessor().LoadLookup_StatisticDataType(manager, this);
            
            if (lookup_object == "CountryLookup")
                _getAccessor().LoadLookup_Country(manager, this);
            
            if (lookup_object == "RegionLookup")
                _getAccessor().LoadLookup_Region(manager, this);
            
            if (lookup_object == "RayonLookup")
                _getAccessor().LoadLookup_Rayon(manager, this);
            
            if (lookup_object == "SettlementLookup")
                _getAccessor().LoadLookup_Settlement(manager, this);
            
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
        public class StatisticListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfStatistic { get; set; }
        
            public Double? varValue { get; set; }
        
            public String strStatisticalAgeGroup { get; set; }
        
            public String ParameterType { get; set; }
        
            public String setnParameterName { get; set; }
        
            public String setnPeriodTypeName { get; set; }
        
            public DateTime? datStatisticStartDate { get; set; }
        
            public String setnAreaTypeName { get; set; }
        
            public String setnArea { get; set; }
        
        }
        public partial class StatisticListItemGridModelList : List<StatisticListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public StatisticListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<StatisticListItem>, errMes);
            }
            public StatisticListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<StatisticListItem>, errMes);
            }
            public StatisticListItemGridModelList(long key, IEnumerable<StatisticListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public StatisticListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<StatisticListItem>(), null);
            }
            partial void filter(List<StatisticListItem> items);
            private void LoadGridModelList(long key, IEnumerable<StatisticListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_varValue,_str_strStatisticalAgeGroup,_str_ParameterType,_str_setnParameterName,_str_setnPeriodTypeName,_str_datStatisticStartDate,_str_setnAreaTypeName,_str_setnArea};
                    
                Hiddens = new List<string> {_str_idfStatistic};
                Keys = new List<string> {_str_idfStatistic};
                Labels = new Dictionary<string, string> {{_str_varValue, _str_varValue},{_str_strStatisticalAgeGroup, _str_strStatisticalAgeGroup},{_str_ParameterType, _str_ParameterType},{_str_setnParameterName, _str_setnParameterName},{_str_setnPeriodTypeName, _str_setnPeriodTypeName},{_str_datStatisticStartDate, _str_datStatisticStartDate},{_str_setnAreaTypeName, _str_setnAreaTypeName},{_str_setnArea, _str_setnArea}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                StatisticListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<StatisticListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new StatisticListItemGridModel()
                {
                    ItemKey=c.idfStatistic,varValue=c.varValue,strStatisticalAgeGroup=c.strStatisticalAgeGroup,ParameterType=c.ParameterType,setnParameterName=c.setnParameterName,setnPeriodTypeName=c.setnPeriodTypeName,datStatisticStartDate=c.datStatisticStartDate,setnAreaTypeName=c.setnAreaTypeName,setnArea=c.setnArea
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
        : DataAccessor<StatisticListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<StatisticListItem>
            
            , IObjectSelectList
            , IObjectSelectList<StatisticListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfStatistic"; } }
            #endregion
        
            private delegate void on_action(StatisticListItem obj);
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
            private StatisticTypeLookup.Accessor StatisticDataTypeAccessor { get { return eidss.model.Schema.StatisticTypeLookup.Accessor.Instance(m_CS); } }
            private CountryLookup.Accessor CountryAccessor { get { return eidss.model.Schema.CountryLookup.Accessor.Instance(m_CS); } }
            private RegionLookup.Accessor RegionAccessor { get { return eidss.model.Schema.RegionLookup.Accessor.Instance(m_CS); } }
            private RayonLookup.Accessor RayonAccessor { get { return eidss.model.Schema.RayonLookup.Accessor.Instance(m_CS); } }
            private SettlementLookup.Accessor SettlementAccessor { get { return eidss.model.Schema.SettlementLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<StatisticListItem> SelectListT(DbManagerProxy manager
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
            
            private List<StatisticListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_Statistic_SelectList.* from dbo.fn_Statistic_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("idfsRegion") || filters.Contains("idfsRayon") || filters.Contains("idfsSettlement"))
                {
                    
                    sql.Append(" " + @"
                        inner join (
                        select 
	                        idfsSettlement as idfsArea,
	                        idfsSettlement,
	                        idfsRayon,
	                        idfsRegion,
	                        idfsCountry
                        from dbo.gisSettlement
                        union all
                        select 
	                        idfsRayon,
	                        null,
	                        idfsRayon,
	                        idfsRegion,
	                        idfsCountry
                        from dbo.gisRayon
                        union all
                        select 
	                        idfsRegion,
	                        null,
	                        null,
	                        idfsRegion,
	                        idfsCountry
                        from dbo.gisRegion
                        union all
                        select 
	                        idfsCountry,
	                        null,
	                        null,
	                        null,
	                        idfsCountry
                        from dbo.gisCountry
                        ) Area on fn_Statistic_SelectList.idfsArea = Area.idfsArea
                    ");
                      
                }
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfsRegion"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsRegion") == 1)
                    {
                        sql.AppendFormat("Area.idfsRegion {0} @idfsRegion", filters.Operation("idfsRegion"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsRegion"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsRegion") ? " or " : " and ");
                            sql.AppendFormat("Area.idfsRegion {0} @idfsRegion_{1}", filters.Operation("idfsRegion", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsRayon"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsRayon") == 1)
                    {
                        sql.AppendFormat("Area.idfsRayon {0} @idfsRayon", filters.Operation("idfsRayon"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsRayon"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsRayon") ? " or " : " and ");
                            sql.AppendFormat("Area.idfsRayon {0} @idfsRayon_{1}", filters.Operation("idfsRayon", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsSettlement"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsSettlement") == 1)
                    {
                        sql.AppendFormat("Area.idfsSettlement {0} @idfsSettlement", filters.Operation("idfsSettlement"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsSettlement"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsSettlement") ? " or " : " and ");
                            sql.AppendFormat("Area.idfsSettlement {0} @idfsSettlement_{1}", filters.Operation("idfsSettlement", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfStatistic"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfStatistic"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfStatistic") ? " or " : " and ");
                        
                        if (filters.Operation("idfStatistic", i) == "&")
                          sql.AppendFormat("(isnull(fn_Statistic_SelectList.idfStatistic,0) {0} @idfStatistic_{1} = @idfStatistic_{1})", filters.Operation("idfStatistic", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Statistic_SelectList.idfStatistic,0) {0} @idfStatistic_{1}", filters.Operation("idfStatistic", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsStatisticDataType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsStatisticDataType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsStatisticDataType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsStatisticDataType", i) == "&")
                          sql.AppendFormat("(isnull(fn_Statistic_SelectList.idfsStatisticDataType,0) {0} @idfsStatisticDataType_{1} = @idfsStatisticDataType_{1})", filters.Operation("idfsStatisticDataType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Statistic_SelectList.idfsStatisticDataType,0) {0} @idfsStatisticDataType_{1}", filters.Operation("idfsStatisticDataType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsStatisticAreaType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsStatisticAreaType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsStatisticAreaType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsStatisticAreaType", i) == "&")
                          sql.AppendFormat("(isnull(fn_Statistic_SelectList.idfsStatisticAreaType,0) {0} @idfsStatisticAreaType_{1} = @idfsStatisticAreaType_{1})", filters.Operation("idfsStatisticAreaType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Statistic_SelectList.idfsStatisticAreaType,0) {0} @idfsStatisticAreaType_{1}", filters.Operation("idfsStatisticAreaType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsStatisticalAgeGroup"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsStatisticalAgeGroup"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsStatisticalAgeGroup") ? " or " : " and ");
                        
                        if (filters.Operation("idfsStatisticalAgeGroup", i) == "&")
                          sql.AppendFormat("(isnull(fn_Statistic_SelectList.idfsStatisticalAgeGroup,0) {0} @idfsStatisticalAgeGroup_{1} = @idfsStatisticalAgeGroup_{1})", filters.Operation("idfsStatisticalAgeGroup", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Statistic_SelectList.idfsStatisticalAgeGroup,0) {0} @idfsStatisticalAgeGroup_{1}", filters.Operation("idfsStatisticalAgeGroup", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strStatisticalAgeGroup"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strStatisticalAgeGroup"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strStatisticalAgeGroup") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Statistic_SelectList.strStatisticalAgeGroup {0} @strStatisticalAgeGroup_{1}", filters.Operation("strStatisticalAgeGroup", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("defDataTypeName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("defDataTypeName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("defDataTypeName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Statistic_SelectList.defDataTypeName {0} @defDataTypeName_{1}", filters.Operation("defDataTypeName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("varValue"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("varValue"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("varValue") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Statistic_SelectList.varValue {0} @varValue_{1}", filters.Operation("varValue", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsMainBaseReference"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsMainBaseReference"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsMainBaseReference") ? " or " : " and ");
                        
                        if (filters.Operation("idfsMainBaseReference", i) == "&")
                          sql.AppendFormat("(isnull(fn_Statistic_SelectList.idfsMainBaseReference,0) {0} @idfsMainBaseReference_{1} = @idfsMainBaseReference_{1})", filters.Operation("idfsMainBaseReference", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Statistic_SelectList.idfsMainBaseReference,0) {0} @idfsMainBaseReference_{1}", filters.Operation("idfsMainBaseReference", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsStatisticPeriodType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsStatisticPeriodType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsStatisticPeriodType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsStatisticPeriodType", i) == "&")
                          sql.AppendFormat("(isnull(fn_Statistic_SelectList.idfsStatisticPeriodType,0) {0} @idfsStatisticPeriodType_{1} = @idfsStatisticPeriodType_{1})", filters.Operation("idfsStatisticPeriodType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Statistic_SelectList.idfsStatisticPeriodType,0) {0} @idfsStatisticPeriodType_{1}", filters.Operation("idfsStatisticPeriodType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsArea"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsArea"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsArea") ? " or " : " and ");
                        
                        if (filters.Operation("idfsArea", i) == "&")
                          sql.AppendFormat("(isnull(fn_Statistic_SelectList.idfsArea,0) {0} @idfsArea_{1} = @idfsArea_{1})", filters.Operation("idfsArea", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Statistic_SelectList.idfsArea,0) {0} @idfsArea_{1}", filters.Operation("idfsArea", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datStatisticStartDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datStatisticStartDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datStatisticStartDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_Statistic_SelectList.datStatisticStartDate, 112) {0} CONVERT(NVARCHAR(8), @datStatisticStartDate_{1}, 112)", filters.Operation("datStatisticStartDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("setnDataTypeName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("setnDataTypeName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("setnDataTypeName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Statistic_SelectList.setnDataTypeName {0} @setnDataTypeName_{1}", filters.Operation("setnDataTypeName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("ParameterType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("ParameterType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("ParameterType") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Statistic_SelectList.ParameterType {0} @ParameterType_{1}", filters.Operation("ParameterType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsParameterType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsParameterType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsParameterType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsParameterType", i) == "&")
                          sql.AppendFormat("(isnull(fn_Statistic_SelectList.idfsParameterType,0) {0} @idfsParameterType_{1} = @idfsParameterType_{1})", filters.Operation("idfsParameterType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Statistic_SelectList.idfsParameterType,0) {0} @idfsParameterType_{1}", filters.Operation("idfsParameterType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("defParameterName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("defParameterName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("defParameterName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Statistic_SelectList.defParameterName {0} @defParameterName_{1}", filters.Operation("defParameterName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("setnParameterName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("setnParameterName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("setnParameterName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Statistic_SelectList.setnParameterName {0} @setnParameterName_{1}", filters.Operation("setnParameterName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsParameterName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsParameterName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsParameterName") ? " or " : " and ");
                        
                        if (filters.Operation("idfsParameterName", i) == "&")
                          sql.AppendFormat("(isnull(fn_Statistic_SelectList.idfsParameterName,0) {0} @idfsParameterName_{1} = @idfsParameterName_{1})", filters.Operation("idfsParameterName", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Statistic_SelectList.idfsParameterName,0) {0} @idfsParameterName_{1}", filters.Operation("idfsParameterName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("defAreaTypeName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("defAreaTypeName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("defAreaTypeName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Statistic_SelectList.defAreaTypeName {0} @defAreaTypeName_{1}", filters.Operation("defAreaTypeName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("setnAreaTypeName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("setnAreaTypeName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("setnAreaTypeName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Statistic_SelectList.setnAreaTypeName {0} @setnAreaTypeName_{1}", filters.Operation("setnAreaTypeName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("defPeriodTypeName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("defPeriodTypeName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("defPeriodTypeName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Statistic_SelectList.defPeriodTypeName {0} @defPeriodTypeName_{1}", filters.Operation("defPeriodTypeName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("setnPeriodTypeName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("setnPeriodTypeName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("setnPeriodTypeName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Statistic_SelectList.setnPeriodTypeName {0} @setnPeriodTypeName_{1}", filters.Operation("setnPeriodTypeName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("setnArea"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("setnArea"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("setnArea") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Statistic_SelectList.setnArea {0} @setnArea_{1}", filters.Operation("setnArea", i), i);
                            
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
                    
                    if (filters.Contains("idfsRegion"))
                        
                        if (filters.Count("idfsRegion") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion", ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion"), filters.Value("idfsRegion"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsRegion"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion", i), filters.Value("idfsRegion", i))));
                        }
                            
                    if (filters.Contains("idfsRayon"))
                        
                        if (filters.Count("idfsRayon") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon", ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon"), filters.Value("idfsRayon"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsRayon"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon", i), filters.Value("idfsRayon", i))));
                        }
                            
                    if (filters.Contains("idfsSettlement"))
                        
                        if (filters.Count("idfsSettlement") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSettlement", ParsingHelper.CorrectLikeValue(filters.Operation("idfsSettlement"), filters.Value("idfsSettlement"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsSettlement"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSettlement_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSettlement", i), filters.Value("idfsSettlement", i))));
                        }
                            
                    if (filters.Contains("idfStatistic"))
                        for (int i = 0; i < filters.Count("idfStatistic"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfStatistic_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfStatistic", i), filters.Value("idfStatistic", i))));
                      
                    if (filters.Contains("idfsStatisticDataType"))
                        for (int i = 0; i < filters.Count("idfsStatisticDataType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsStatisticDataType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsStatisticDataType", i), filters.Value("idfsStatisticDataType", i))));
                      
                    if (filters.Contains("idfsStatisticAreaType"))
                        for (int i = 0; i < filters.Count("idfsStatisticAreaType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsStatisticAreaType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsStatisticAreaType", i), filters.Value("idfsStatisticAreaType", i))));
                      
                    if (filters.Contains("idfsStatisticalAgeGroup"))
                        for (int i = 0; i < filters.Count("idfsStatisticalAgeGroup"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsStatisticalAgeGroup_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsStatisticalAgeGroup", i), filters.Value("idfsStatisticalAgeGroup", i))));
                      
                    if (filters.Contains("strStatisticalAgeGroup"))
                        for (int i = 0; i < filters.Count("strStatisticalAgeGroup"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strStatisticalAgeGroup_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strStatisticalAgeGroup", i), filters.Value("strStatisticalAgeGroup", i))));
                      
                    if (filters.Contains("defDataTypeName"))
                        for (int i = 0; i < filters.Count("defDataTypeName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@defDataTypeName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("defDataTypeName", i), filters.Value("defDataTypeName", i))));
                      
                    if (filters.Contains("varValue"))
                        for (int i = 0; i < filters.Count("varValue"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@varValue_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("varValue", i), filters.Value("varValue", i))));
                      
                    if (filters.Contains("idfsMainBaseReference"))
                        for (int i = 0; i < filters.Count("idfsMainBaseReference"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsMainBaseReference_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsMainBaseReference", i), filters.Value("idfsMainBaseReference", i))));
                      
                    if (filters.Contains("idfsStatisticPeriodType"))
                        for (int i = 0; i < filters.Count("idfsStatisticPeriodType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsStatisticPeriodType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsStatisticPeriodType", i), filters.Value("idfsStatisticPeriodType", i))));
                      
                    if (filters.Contains("idfsArea"))
                        for (int i = 0; i < filters.Count("idfsArea"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsArea_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsArea", i), filters.Value("idfsArea", i))));
                      
                    if (filters.Contains("datStatisticStartDate"))
                        for (int i = 0; i < filters.Count("datStatisticStartDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datStatisticStartDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datStatisticStartDate", i), filters.Value("datStatisticStartDate", i))));
                      
                    if (filters.Contains("setnDataTypeName"))
                        for (int i = 0; i < filters.Count("setnDataTypeName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@setnDataTypeName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("setnDataTypeName", i), filters.Value("setnDataTypeName", i))));
                      
                    if (filters.Contains("ParameterType"))
                        for (int i = 0; i < filters.Count("ParameterType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@ParameterType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("ParameterType", i), filters.Value("ParameterType", i))));
                      
                    if (filters.Contains("idfsParameterType"))
                        for (int i = 0; i < filters.Count("idfsParameterType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsParameterType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsParameterType", i), filters.Value("idfsParameterType", i))));
                      
                    if (filters.Contains("defParameterName"))
                        for (int i = 0; i < filters.Count("defParameterName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@defParameterName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("defParameterName", i), filters.Value("defParameterName", i))));
                      
                    if (filters.Contains("setnParameterName"))
                        for (int i = 0; i < filters.Count("setnParameterName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@setnParameterName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("setnParameterName", i), filters.Value("setnParameterName", i))));
                      
                    if (filters.Contains("idfsParameterName"))
                        for (int i = 0; i < filters.Count("idfsParameterName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsParameterName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsParameterName", i), filters.Value("idfsParameterName", i))));
                      
                    if (filters.Contains("defAreaTypeName"))
                        for (int i = 0; i < filters.Count("defAreaTypeName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@defAreaTypeName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("defAreaTypeName", i), filters.Value("defAreaTypeName", i))));
                      
                    if (filters.Contains("setnAreaTypeName"))
                        for (int i = 0; i < filters.Count("setnAreaTypeName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@setnAreaTypeName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("setnAreaTypeName", i), filters.Value("setnAreaTypeName", i))));
                      
                    if (filters.Contains("defPeriodTypeName"))
                        for (int i = 0; i < filters.Count("defPeriodTypeName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@defPeriodTypeName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("defPeriodTypeName", i), filters.Value("defPeriodTypeName", i))));
                      
                    if (filters.Contains("setnPeriodTypeName"))
                        for (int i = 0; i < filters.Count("setnPeriodTypeName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@setnPeriodTypeName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("setnPeriodTypeName", i), filters.Value("setnPeriodTypeName", i))));
                      
                    if (filters.Contains("setnArea"))
                        for (int i = 0; i < filters.Count("setnArea"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@setnArea_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("setnArea", i), filters.Value("setnArea", i))));
                      
                    List<StatisticListItem> objs = manager.ExecuteList<StatisticListItem>();
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
            partial void ListSelected(DbManagerProxy manager, List<StatisticListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spStatistic_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, StatisticListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, StatisticListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private StatisticListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    StatisticListItem obj = StatisticListItem.CreateInstance();
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
                obj.Country = new Func<StatisticListItem, CountryLookup>(c => 
                                     c.CountryLookup.Where(a => a.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID)
                                     .SingleOrDefault())(obj);
                obj.Region = new Func<StatisticListItem, RegionLookup>(c => 
                                     BaseSettings.DefaultRegionInSearch == true?
                                     c.RegionLookup.Where(a => a.idfsRegion == eidss.model.Core.EidssSiteContext.Instance.RegionID)
                                     .SingleOrDefault(): null)(obj);
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

            
            public StatisticListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public StatisticListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public StatisticListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult ImportData(DbManagerProxy manager, StatisticListItem obj, List<object> pars)
            {
                
                return ImportData(manager, obj
                    );
            }
            public ActResult ImportData(DbManagerProxy manager, StatisticListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ImportData"))
                    throw new PermissionException("Statistic", "ImportData");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(StatisticListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(StatisticListItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsStatisticDataType)
                        {
                    
                obj.idfsStatisticAreaType = new Func<StatisticListItem, long?>(c => c.StatisticDataType == null ? (long?)null : c.StatisticDataType.idfsStatisticAreaType)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.Region = new Func<StatisticListItem, RegionLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.Rayon = new Func<StatisticListItem, RayonLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                obj.Settlement = new Func<StatisticListItem, SettlementLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Region(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Rayon(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Settlement(manager, obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_StatisticDataType(DbManagerProxy manager, StatisticListItem obj)
            {
                
                obj.StatisticDataTypeLookup.Clear();
                
                obj.StatisticDataTypeLookup.Add(StatisticDataTypeAccessor.CreateNewT(manager, null));
                
                obj.StatisticDataTypeLookup.AddRange(StatisticDataTypeAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsStatisticDataType))
                    
                    .ToList());
                
                if (obj.idfsStatisticDataType != 0)
                {
                    obj.StatisticDataType = obj.StatisticDataTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsStatisticDataType);
                    
                }
              
                
                LookupManager.AddObject("StatisticTypeLookup", obj, StatisticDataTypeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Country(DbManagerProxy manager, StatisticListItem obj)
            {
                
                obj.CountryLookup.Clear();
                
                obj.CountryLookup.Add(CountryAccessor.CreateNewT(manager, null));
                
                obj.CountryLookup.AddRange(CountryAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsCountry == obj.idfsCountry))
                    
                    .ToList());
                
                if (obj.idfsCountry != null && obj.idfsCountry != 0)
                {
                    obj.Country = obj.CountryLookup
                        .SingleOrDefault(c => c.idfsCountry == obj.idfsCountry);
                    
                }
              
                
                LookupManager.AddObject("CountryLookup", obj, CountryAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Region(DbManagerProxy manager, StatisticListItem obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<StatisticListItem, long>(c => c.idfsCountry ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRegion == obj.idfsRegion))
                    
                    .ToList());
                
                if (obj.idfsRegion != null && obj.idfsRegion != 0)
                {
                    obj.Region = obj.RegionLookup
                        .SingleOrDefault(c => c.idfsRegion == obj.idfsRegion);
                    
                }
              
                
                LookupManager.AddObject("RegionLookup", obj, RegionAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Rayon(DbManagerProxy manager, StatisticListItem obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<StatisticListItem, long>(c => c.idfsRegion ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRayon == obj.idfsRayon))
                    
                    .ToList());
                
                if (obj.idfsRayon != null && obj.idfsRayon != 0)
                {
                    obj.Rayon = obj.RayonLookup
                        .SingleOrDefault(c => c.idfsRayon == obj.idfsRayon);
                    
                }
              
                
                LookupManager.AddObject("RayonLookup", obj, RayonAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Settlement(DbManagerProxy manager, StatisticListItem obj)
            {
                
                obj.SettlementLookup.Clear();
                
                obj.SettlementLookup.Add(SettlementAccessor.CreateNewT(manager, null));
                
                obj.SettlementLookup.AddRange(SettlementAccessor.SelectLookupList(manager
                    
                    , new Func<StatisticListItem, long>(c => c.idfsRayon ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSettlement == obj.idfsSettlement))
                    
                    .ToList());
                
                if (obj.idfsSettlement != null && obj.idfsSettlement != 0)
                {
                    obj.Settlement = obj.SettlementLookup
                        .SingleOrDefault(c => c.idfsSettlement == obj.idfsSettlement);
                    
                }
              
                
                LookupManager.AddObject("SettlementLookup", obj, SettlementAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, StatisticListItem obj)
            {
                
                LoadLookup_StatisticDataType(manager, obj);
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Settlement(manager, obj);
                
            }
    
            [SprocName("spStatistic_Delete")]
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
                    StatisticListItem bo = obj as StatisticListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("Statistic", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("Statistic", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("Statistic", "Update");
                    }
                    
                    long mainObject = bo.idfStatistic;
                    
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
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeDelete;
                            
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeCreate;
                            
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeEdit;
                            
                        }
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoStatistic;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbStatistic;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as StatisticListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, StatisticListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfStatistic
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
            
            public bool ValidateCanDelete(StatisticListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, StatisticListItem obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(StatisticListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(StatisticListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as StatisticListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, StatisticListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Statistic.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Statistic.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Statistic.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Statistic.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(StatisticListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(StatisticListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as StatisticListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as StatisticListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "StatisticListItemDetail"; } }
            public string HelpIdWin { get { return "Statistics"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private StatisticListItem m_obj;
            internal Permissions(StatisticListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Statistic.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Statistic.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Statistic.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Statistic.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_Statistic_SelectList";
            public static string spCount = "spStatistic_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spStatistic_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<StatisticListItem, bool>> RequiredByField = new Dictionary<string, Func<StatisticListItem, bool>>();
            public static Dictionary<string, Func<StatisticListItem, bool>> RequiredByProperty = new Dictionary<string, Func<StatisticListItem, bool>>();
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
                
                Sizes.Add(_str_strStatisticalAgeGroup, 2000);
                Sizes.Add(_str_defDataTypeName, 2000);
                Sizes.Add(_str_setnDataTypeName, 2000);
                Sizes.Add(_str_ParameterType, 2000);
                Sizes.Add(_str_defParameterName, 2000);
                Sizes.Add(_str_setnParameterName, 2000);
                Sizes.Add(_str_defAreaTypeName, 2000);
                Sizes.Add(_str_setnAreaTypeName, 2000);
                Sizes.Add(_str_defPeriodTypeName, 2000);
                Sizes.Add(_str_setnPeriodTypeName, 2000);
                Sizes.Add(_str_setnArea, 904);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsStatisticDataType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsStatisticDataType",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "StatisticDataTypeLookup", typeof(StatisticTypeLookup), (o) => { var c = (StatisticTypeLookup)o; return c.idfsBaseReference; }, (o) => { var c = (StatisticTypeLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datStatisticStartDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datStatisticStartDate",
                    c => new DateTime(DateTime.Now.Year - 1, 01, 01), null, c => true, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRegion",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsRegion",
                    null, null, c => false, false, SearchPanelLocation.Main, true, "idfsRayon", "RegionLookup", typeof(RegionLookup), (o) => { var c = (RegionLookup)o; return c.idfsRegion; }, (o) => { var c = (RegionLookup)o; return c.strRegionName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRayon",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsRayon",
                    null, null, c => false, false, SearchPanelLocation.Main, true, "idfsSettlement", "RayonLookup", typeof(RayonLookup), (o) => { var c = (RayonLookup)o; return c.idfsRayon; }, (o) => { var c = (RayonLookup)o; return c.strRayonName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSettlement",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strSettlement",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, "SettlementLookup", typeof(SettlementLookup), (o) => { var c = (SettlementLookup)o; return c.idfsSettlement; }, (o) => { var c = (SettlementLookup)o; return c.strSettlementName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsStatisticAreaType",
                    EditorType.Numeric,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfStatistic,
                    _str_idfStatistic, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_varValue,
                    _str_varValue, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strStatisticalAgeGroup,
                    _str_strStatisticalAgeGroup, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_ParameterType,
                    _str_ParameterType, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_setnParameterName,
                    _str_setnParameterName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_setnPeriodTypeName,
                    _str_setnPeriodTypeName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datStatisticStartDate,
                    _str_datStatisticStartDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_setnAreaTypeName,
                    _str_setnAreaTypeName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_setnArea,
                    _str_setnArea, null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "ImportData",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ImportData(manager, (StatisticListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strLoadData_Id",
                        "",
                        /*from BvMessages*/"strLoadData_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    () => EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.Statistic)),
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
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<Statistic>().CreateNew(manager, c, pars == null ? null : (int?)pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
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
                    "Edit",
                    ActionTypes.Edit,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<Statistic>().SelectDetail(manager, pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strEdit_Id",
                        "edit",
                        /*from BvMessages*/"tooltipEdit_Id",
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"tooltipEdit_Id",
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
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => 
                        {
                            if (c == null)
                            {
                                c = ObjectAccessor.CreatorInterface<StatisticListItem>().CreateWithParams(manager, null, pars);
                                ((StatisticListItem)c).idfStatistic = (long)pars[0];
                                ((StatisticListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((StatisticListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<StatisticListItem>().Post(manager, (StatisticListItem)c), c);
                        }
                                            ,
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
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
	