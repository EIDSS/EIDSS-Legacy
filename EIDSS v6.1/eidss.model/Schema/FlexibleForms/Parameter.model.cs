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
    public abstract partial class Parameter : 
        EditableObject<Parameter>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsParameter), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsParameter { get; set; }
                
        [LocalizedDisplayName(_str_idfsSection)]
        [MapField(_str_idfsSection)]
        public abstract Int64? idfsSection { get; set; }
        protected Int64? idfsSection_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSection).OriginalValue; } }
        protected Int64? idfsSection_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSection).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFormType)]
        [MapField(_str_idfsFormType)]
        public abstract Int64 idfsFormType { get; set; }
        protected Int64 idfsFormType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormType).OriginalValue; } }
        protected Int64 idfsFormType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intScheme)]
        [MapField(_str_intScheme)]
        public abstract Int32 intScheme { get; set; }
        protected Int32 intScheme_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intScheme).OriginalValue; } }
        protected Int32 intScheme_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intScheme).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsParameterType)]
        [MapField(_str_idfsParameterType)]
        public abstract Int64? idfsParameterType { get; set; }
        protected Int64? idfsParameterType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParameterType).OriginalValue; } }
        protected Int64? idfsParameterType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParameterType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_ParameterTypeName)]
        [MapField(_str_ParameterTypeName)]
        public abstract String ParameterTypeName { get; set; }
        protected String ParameterTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._parameterTypeName).OriginalValue; } }
        protected String ParameterTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._parameterTypeName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsEditor)]
        [MapField(_str_idfsEditor)]
        public abstract Int64? idfsEditor { get; set; }
        protected Int64? idfsEditor_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEditor).OriginalValue; } }
        protected Int64? idfsEditor_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEditor).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsParameterCaption)]
        [MapField(_str_idfsParameterCaption)]
        public abstract Int64? idfsParameterCaption { get; set; }
        protected Int64? idfsParameterCaption_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParameterCaption).OriginalValue; } }
        protected Int64? idfsParameterCaption_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParameterCaption).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32 intOrder { get; set; }
        protected Int32 intOrder_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32 intOrder_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strNote)]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int32 intHACode { get; set; }
        protected Int32 intHACode_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32 intHACode_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intHACode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intLabelSize)]
        [MapField(_str_intLabelSize)]
        public abstract Int32 intLabelSize { get; set; }
        protected Int32 intLabelSize_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intLabelSize).OriginalValue; } }
        protected Int32 intLabelSize_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intLabelSize).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intTop)]
        [MapField(_str_intTop)]
        public abstract Int32 intTop { get; set; }
        protected Int32 intTop_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intTop).OriginalValue; } }
        protected Int32 intTop_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intTop).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intLeft)]
        [MapField(_str_intLeft)]
        public abstract Int32 intLeft { get; set; }
        protected Int32 intLeft_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intLeft).OriginalValue; } }
        protected Int32 intLeft_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intLeft).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intWidth)]
        [MapField(_str_intWidth)]
        public abstract Int32 intWidth { get; set; }
        protected Int32 intWidth_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intWidth).OriginalValue; } }
        protected Int32 intWidth_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intWidth).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHeight)]
        [MapField(_str_intHeight)]
        public abstract Int32 intHeight { get; set; }
        protected Int32 intHeight_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intHeight).OriginalValue; } }
        protected Int32 intHeight_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intHeight).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64? idfsFormTemplate { get; set; }
        protected Int64? idfsFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64? idfsFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intRowStatus)]
        [MapField(_str_intRowStatus)]
        public abstract Int32 intRowStatus { get; set; }
        protected Int32 intRowStatus_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).OriginalValue; } }
        protected Int32 intRowStatus_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DefaultName)]
        [MapField(_str_DefaultName)]
        public abstract String DefaultName { get; set; }
        protected String DefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._defaultName).OriginalValue; } }
        protected String DefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._defaultName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DefaultLongName)]
        [MapField(_str_DefaultLongName)]
        public abstract String DefaultLongName { get; set; }
        protected String DefaultLongName_Original { get { return ((EditableValue<String>)((dynamic)this)._defaultLongName).OriginalValue; } }
        protected String DefaultLongName_Previous { get { return ((EditableValue<String>)((dynamic)this)._defaultLongName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_NationalName)]
        [MapField(_str_NationalName)]
        public abstract String NationalName { get; set; }
        protected String NationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._nationalName).OriginalValue; } }
        protected String NationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._nationalName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_NationalLongName)]
        [MapField(_str_NationalLongName)]
        public abstract String NationalLongName { get; set; }
        protected String NationalLongName_Original { get { return ((EditableValue<String>)((dynamic)this)._nationalLongName).OriginalValue; } }
        protected String NationalLongName_Previous { get { return ((EditableValue<String>)((dynamic)this)._nationalLongName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_langid)]
        [MapField(_str_langid)]
        public abstract String langid { get; set; }
        protected String langid_Original { get { return ((EditableValue<String>)((dynamic)this)._langid).OriginalValue; } }
        protected String langid_Previous { get { return ((EditableValue<String>)((dynamic)this)._langid).PreviousValue; } }
                
        [LocalizedDisplayName(_str_IsRealParameter)]
        [MapField(_str_IsRealParameter)]
        public abstract Int32 IsRealParameter { get; set; }
        protected Int32 IsRealParameter_Original { get { return ((EditableValue<Int32>)((dynamic)this)._isRealParameter).OriginalValue; } }
        protected Int32 IsRealParameter_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._isRealParameter).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<Parameter, object> _get_func;
            internal Action<Parameter, string> _set_func;
            internal Action<Parameter, Parameter, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsParameter = "idfsParameter";
        internal const string _str_idfsSection = "idfsSection";
        internal const string _str_idfsFormType = "idfsFormType";
        internal const string _str_intScheme = "intScheme";
        internal const string _str_idfsParameterType = "idfsParameterType";
        internal const string _str_ParameterTypeName = "ParameterTypeName";
        internal const string _str_idfsEditor = "idfsEditor";
        internal const string _str_idfsParameterCaption = "idfsParameterCaption";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_strNote = "strNote";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_intLabelSize = "intLabelSize";
        internal const string _str_intTop = "intTop";
        internal const string _str_intLeft = "intLeft";
        internal const string _str_intWidth = "intWidth";
        internal const string _str_intHeight = "intHeight";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_intRowStatus = "intRowStatus";
        internal const string _str_DefaultName = "DefaultName";
        internal const string _str_DefaultLongName = "DefaultLongName";
        internal const string _str_NationalName = "NationalName";
        internal const string _str_NationalLongName = "NationalLongName";
        internal const string _str_langid = "langid";
        internal const string _str_IsRealParameter = "IsRealParameter";
        internal const string _str_idfsValueDummy = "idfsValueDummy";
        internal const string _str_idfsParameterTypeNotNull = "idfsParameterTypeNotNull";
        internal const string _str_SelectList = "SelectList";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsParameter, _formname = _str_idfsParameter, _type = "Int64",
              _get_func = o => o.idfsParameter,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsParameter != newval) o.idfsParameter = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsParameter != c.idfsParameter || o.IsRIRPropChanged(_str_idfsParameter, c)) 
                  m.Add(_str_idfsParameter, o.ObjectIdent + _str_idfsParameter, o.ObjectIdent2 + _str_idfsParameter, o.ObjectIdent3 + _str_idfsParameter, "Int64", 
                    o.idfsParameter == null ? "" : o.idfsParameter.ToString(),                  
                  o.IsReadOnly(_str_idfsParameter), o.IsInvisible(_str_idfsParameter), o.IsRequired(_str_idfsParameter)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSection, _formname = _str_idfsSection, _type = "Int64?",
              _get_func = o => o.idfsSection,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSection != newval) o.idfsSection = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSection != c.idfsSection || o.IsRIRPropChanged(_str_idfsSection, c)) 
                  m.Add(_str_idfsSection, o.ObjectIdent + _str_idfsSection, o.ObjectIdent2 + _str_idfsSection, o.ObjectIdent3 + _str_idfsSection, "Int64?", 
                    o.idfsSection == null ? "" : o.idfsSection.ToString(),                  
                  o.IsReadOnly(_str_idfsSection), o.IsInvisible(_str_idfsSection), o.IsRequired(_str_idfsSection)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsFormType, _formname = _str_idfsFormType, _type = "Int64",
              _get_func = o => o.idfsFormType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsFormType != newval) o.idfsFormType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsFormType != c.idfsFormType || o.IsRIRPropChanged(_str_idfsFormType, c)) 
                  m.Add(_str_idfsFormType, o.ObjectIdent + _str_idfsFormType, o.ObjectIdent2 + _str_idfsFormType, o.ObjectIdent3 + _str_idfsFormType, "Int64", 
                    o.idfsFormType == null ? "" : o.idfsFormType.ToString(),                  
                  o.IsReadOnly(_str_idfsFormType), o.IsInvisible(_str_idfsFormType), o.IsRequired(_str_idfsFormType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intScheme, _formname = _str_intScheme, _type = "Int32",
              _get_func = o => o.intScheme,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intScheme != newval) o.intScheme = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intScheme != c.intScheme || o.IsRIRPropChanged(_str_intScheme, c)) 
                  m.Add(_str_intScheme, o.ObjectIdent + _str_intScheme, o.ObjectIdent2 + _str_intScheme, o.ObjectIdent3 + _str_intScheme, "Int32", 
                    o.intScheme == null ? "" : o.intScheme.ToString(),                  
                  o.IsReadOnly(_str_intScheme), o.IsInvisible(_str_intScheme), o.IsRequired(_str_intScheme)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsParameterType, _formname = _str_idfsParameterType, _type = "Int64?",
              _get_func = o => o.idfsParameterType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsParameterType != newval) o.idfsParameterType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsParameterType != c.idfsParameterType || o.IsRIRPropChanged(_str_idfsParameterType, c)) 
                  m.Add(_str_idfsParameterType, o.ObjectIdent + _str_idfsParameterType, o.ObjectIdent2 + _str_idfsParameterType, o.ObjectIdent3 + _str_idfsParameterType, "Int64?", 
                    o.idfsParameterType == null ? "" : o.idfsParameterType.ToString(),                  
                  o.IsReadOnly(_str_idfsParameterType), o.IsInvisible(_str_idfsParameterType), o.IsRequired(_str_idfsParameterType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_ParameterTypeName, _formname = _str_ParameterTypeName, _type = "String",
              _get_func = o => o.ParameterTypeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.ParameterTypeName != newval) o.ParameterTypeName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.ParameterTypeName != c.ParameterTypeName || o.IsRIRPropChanged(_str_ParameterTypeName, c)) 
                  m.Add(_str_ParameterTypeName, o.ObjectIdent + _str_ParameterTypeName, o.ObjectIdent2 + _str_ParameterTypeName, o.ObjectIdent3 + _str_ParameterTypeName, "String", 
                    o.ParameterTypeName == null ? "" : o.ParameterTypeName.ToString(),                  
                  o.IsReadOnly(_str_ParameterTypeName), o.IsInvisible(_str_ParameterTypeName), o.IsRequired(_str_ParameterTypeName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsEditor, _formname = _str_idfsEditor, _type = "Int64?",
              _get_func = o => o.idfsEditor,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsEditor != newval) o.idfsEditor = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsEditor != c.idfsEditor || o.IsRIRPropChanged(_str_idfsEditor, c)) 
                  m.Add(_str_idfsEditor, o.ObjectIdent + _str_idfsEditor, o.ObjectIdent2 + _str_idfsEditor, o.ObjectIdent3 + _str_idfsEditor, "Int64?", 
                    o.idfsEditor == null ? "" : o.idfsEditor.ToString(),                  
                  o.IsReadOnly(_str_idfsEditor), o.IsInvisible(_str_idfsEditor), o.IsRequired(_str_idfsEditor)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsParameterCaption, _formname = _str_idfsParameterCaption, _type = "Int64?",
              _get_func = o => o.idfsParameterCaption,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsParameterCaption != newval) o.idfsParameterCaption = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsParameterCaption != c.idfsParameterCaption || o.IsRIRPropChanged(_str_idfsParameterCaption, c)) 
                  m.Add(_str_idfsParameterCaption, o.ObjectIdent + _str_idfsParameterCaption, o.ObjectIdent2 + _str_idfsParameterCaption, o.ObjectIdent3 + _str_idfsParameterCaption, "Int64?", 
                    o.idfsParameterCaption == null ? "" : o.idfsParameterCaption.ToString(),                  
                  o.IsReadOnly(_str_idfsParameterCaption), o.IsInvisible(_str_idfsParameterCaption), o.IsRequired(_str_idfsParameterCaption)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intOrder, _formname = _str_intOrder, _type = "Int32",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intOrder != newval) o.intOrder = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, o.ObjectIdent2 + _str_intOrder, o.ObjectIdent3 + _str_intOrder, "Int32", 
                    o.intOrder == null ? "" : o.intOrder.ToString(),                  
                  o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strNote, _formname = _str_strNote, _type = "String",
              _get_func = o => o.strNote,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strNote != newval) o.strNote = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strNote != c.strNote || o.IsRIRPropChanged(_str_strNote, c)) 
                  m.Add(_str_strNote, o.ObjectIdent + _str_strNote, o.ObjectIdent2 + _str_strNote, o.ObjectIdent3 + _str_strNote, "String", 
                    o.strNote == null ? "" : o.strNote.ToString(),                  
                  o.IsReadOnly(_str_strNote), o.IsInvisible(_str_strNote), o.IsRequired(_str_strNote)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intHACode, _formname = _str_intHACode, _type = "Int32",
              _get_func = o => o.intHACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intHACode != newval) o.intHACode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intHACode != c.intHACode || o.IsRIRPropChanged(_str_intHACode, c)) 
                  m.Add(_str_intHACode, o.ObjectIdent + _str_intHACode, o.ObjectIdent2 + _str_intHACode, o.ObjectIdent3 + _str_intHACode, "Int32", 
                    o.intHACode == null ? "" : o.intHACode.ToString(),                  
                  o.IsReadOnly(_str_intHACode), o.IsInvisible(_str_intHACode), o.IsRequired(_str_intHACode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intLabelSize, _formname = _str_intLabelSize, _type = "Int32",
              _get_func = o => o.intLabelSize,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intLabelSize != newval) o.intLabelSize = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intLabelSize != c.intLabelSize || o.IsRIRPropChanged(_str_intLabelSize, c)) 
                  m.Add(_str_intLabelSize, o.ObjectIdent + _str_intLabelSize, o.ObjectIdent2 + _str_intLabelSize, o.ObjectIdent3 + _str_intLabelSize, "Int32", 
                    o.intLabelSize == null ? "" : o.intLabelSize.ToString(),                  
                  o.IsReadOnly(_str_intLabelSize), o.IsInvisible(_str_intLabelSize), o.IsRequired(_str_intLabelSize)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intTop, _formname = _str_intTop, _type = "Int32",
              _get_func = o => o.intTop,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intTop != newval) o.intTop = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intTop != c.intTop || o.IsRIRPropChanged(_str_intTop, c)) 
                  m.Add(_str_intTop, o.ObjectIdent + _str_intTop, o.ObjectIdent2 + _str_intTop, o.ObjectIdent3 + _str_intTop, "Int32", 
                    o.intTop == null ? "" : o.intTop.ToString(),                  
                  o.IsReadOnly(_str_intTop), o.IsInvisible(_str_intTop), o.IsRequired(_str_intTop)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intLeft, _formname = _str_intLeft, _type = "Int32",
              _get_func = o => o.intLeft,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intLeft != newval) o.intLeft = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intLeft != c.intLeft || o.IsRIRPropChanged(_str_intLeft, c)) 
                  m.Add(_str_intLeft, o.ObjectIdent + _str_intLeft, o.ObjectIdent2 + _str_intLeft, o.ObjectIdent3 + _str_intLeft, "Int32", 
                    o.intLeft == null ? "" : o.intLeft.ToString(),                  
                  o.IsReadOnly(_str_intLeft), o.IsInvisible(_str_intLeft), o.IsRequired(_str_intLeft)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intWidth, _formname = _str_intWidth, _type = "Int32",
              _get_func = o => o.intWidth,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intWidth != newval) o.intWidth = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intWidth != c.intWidth || o.IsRIRPropChanged(_str_intWidth, c)) 
                  m.Add(_str_intWidth, o.ObjectIdent + _str_intWidth, o.ObjectIdent2 + _str_intWidth, o.ObjectIdent3 + _str_intWidth, "Int32", 
                    o.intWidth == null ? "" : o.intWidth.ToString(),                  
                  o.IsReadOnly(_str_intWidth), o.IsInvisible(_str_intWidth), o.IsRequired(_str_intWidth)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intHeight, _formname = _str_intHeight, _type = "Int32",
              _get_func = o => o.intHeight,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intHeight != newval) o.intHeight = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intHeight != c.intHeight || o.IsRIRPropChanged(_str_intHeight, c)) 
                  m.Add(_str_intHeight, o.ObjectIdent + _str_intHeight, o.ObjectIdent2 + _str_intHeight, o.ObjectIdent3 + _str_intHeight, "Int32", 
                    o.intHeight == null ? "" : o.intHeight.ToString(),                  
                  o.IsReadOnly(_str_intHeight), o.IsInvisible(_str_intHeight), o.IsRequired(_str_intHeight)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsFormTemplate, _formname = _str_idfsFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsFormTemplate != newval) o.idfsFormTemplate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, o.ObjectIdent2 + _str_idfsFormTemplate, o.ObjectIdent3 + _str_idfsFormTemplate, "Int64?", 
                    o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(),                  
                  o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intRowStatus, _formname = _str_intRowStatus, _type = "Int32",
              _get_func = o => o.intRowStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intRowStatus != newval) o.intRowStatus = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intRowStatus != c.intRowStatus || o.IsRIRPropChanged(_str_intRowStatus, c)) 
                  m.Add(_str_intRowStatus, o.ObjectIdent + _str_intRowStatus, o.ObjectIdent2 + _str_intRowStatus, o.ObjectIdent3 + _str_intRowStatus, "Int32", 
                    o.intRowStatus == null ? "" : o.intRowStatus.ToString(),                  
                  o.IsReadOnly(_str_intRowStatus), o.IsInvisible(_str_intRowStatus), o.IsRequired(_str_intRowStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DefaultName, _formname = _str_DefaultName, _type = "String",
              _get_func = o => o.DefaultName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DefaultName != newval) o.DefaultName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DefaultName != c.DefaultName || o.IsRIRPropChanged(_str_DefaultName, c)) 
                  m.Add(_str_DefaultName, o.ObjectIdent + _str_DefaultName, o.ObjectIdent2 + _str_DefaultName, o.ObjectIdent3 + _str_DefaultName, "String", 
                    o.DefaultName == null ? "" : o.DefaultName.ToString(),                  
                  o.IsReadOnly(_str_DefaultName), o.IsInvisible(_str_DefaultName), o.IsRequired(_str_DefaultName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DefaultLongName, _formname = _str_DefaultLongName, _type = "String",
              _get_func = o => o.DefaultLongName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DefaultLongName != newval) o.DefaultLongName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DefaultLongName != c.DefaultLongName || o.IsRIRPropChanged(_str_DefaultLongName, c)) 
                  m.Add(_str_DefaultLongName, o.ObjectIdent + _str_DefaultLongName, o.ObjectIdent2 + _str_DefaultLongName, o.ObjectIdent3 + _str_DefaultLongName, "String", 
                    o.DefaultLongName == null ? "" : o.DefaultLongName.ToString(),                  
                  o.IsReadOnly(_str_DefaultLongName), o.IsInvisible(_str_DefaultLongName), o.IsRequired(_str_DefaultLongName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_NationalName, _formname = _str_NationalName, _type = "String",
              _get_func = o => o.NationalName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.NationalName != newval) o.NationalName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.NationalName != c.NationalName || o.IsRIRPropChanged(_str_NationalName, c)) 
                  m.Add(_str_NationalName, o.ObjectIdent + _str_NationalName, o.ObjectIdent2 + _str_NationalName, o.ObjectIdent3 + _str_NationalName, "String", 
                    o.NationalName == null ? "" : o.NationalName.ToString(),                  
                  o.IsReadOnly(_str_NationalName), o.IsInvisible(_str_NationalName), o.IsRequired(_str_NationalName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_NationalLongName, _formname = _str_NationalLongName, _type = "String",
              _get_func = o => o.NationalLongName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.NationalLongName != newval) o.NationalLongName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.NationalLongName != c.NationalLongName || o.IsRIRPropChanged(_str_NationalLongName, c)) 
                  m.Add(_str_NationalLongName, o.ObjectIdent + _str_NationalLongName, o.ObjectIdent2 + _str_NationalLongName, o.ObjectIdent3 + _str_NationalLongName, "String", 
                    o.NationalLongName == null ? "" : o.NationalLongName.ToString(),                  
                  o.IsReadOnly(_str_NationalLongName), o.IsInvisible(_str_NationalLongName), o.IsRequired(_str_NationalLongName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_langid, _formname = _str_langid, _type = "String",
              _get_func = o => o.langid,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.langid != newval) o.langid = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.langid != c.langid || o.IsRIRPropChanged(_str_langid, c)) 
                  m.Add(_str_langid, o.ObjectIdent + _str_langid, o.ObjectIdent2 + _str_langid, o.ObjectIdent3 + _str_langid, "String", 
                    o.langid == null ? "" : o.langid.ToString(),                  
                  o.IsReadOnly(_str_langid), o.IsInvisible(_str_langid), o.IsRequired(_str_langid)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_IsRealParameter, _formname = _str_IsRealParameter, _type = "Int32",
              _get_func = o => o.IsRealParameter,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.IsRealParameter != newval) o.IsRealParameter = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.IsRealParameter != c.IsRealParameter || o.IsRIRPropChanged(_str_IsRealParameter, c)) 
                  m.Add(_str_IsRealParameter, o.ObjectIdent + _str_IsRealParameter, o.ObjectIdent2 + _str_IsRealParameter, o.ObjectIdent3 + _str_IsRealParameter, "Int32", 
                    o.IsRealParameter == null ? "" : o.IsRealParameter.ToString(),                  
                  o.IsReadOnly(_str_IsRealParameter), o.IsInvisible(_str_IsRealParameter), o.IsRequired(_str_IsRealParameter)); 
                  }
              }, 
        
            new field_info {
              _name = _str_idfsValueDummy, _formname = _str_idfsValueDummy, _type = "long?",
              _get_func = o => o.idfsValueDummy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsValueDummy != newval) o.idfsValueDummy = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsValueDummy != c.idfsValueDummy || o.IsRIRPropChanged(_str_idfsValueDummy, c)) {
                  m.Add(_str_idfsValueDummy, o.ObjectIdent + _str_idfsValueDummy, o.ObjectIdent2 + _str_idfsValueDummy, o.ObjectIdent3 + _str_idfsValueDummy,  "long?", 
                    o.idfsValueDummy == null ? "" : o.idfsValueDummy.ToString(),                  
                    o.IsReadOnly(_str_idfsValueDummy), o.IsInvisible(_str_idfsValueDummy), o.IsRequired(_str_idfsValueDummy));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsParameterTypeNotNull, _formname = _str_idfsParameterTypeNotNull, _type = "long",
              _get_func = o => o.idfsParameterTypeNotNull,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.idfsParameterTypeNotNull != c.idfsParameterTypeNotNull || o.IsRIRPropChanged(_str_idfsParameterTypeNotNull, c)) {
                  m.Add(_str_idfsParameterTypeNotNull, o.ObjectIdent + _str_idfsParameterTypeNotNull, o.ObjectIdent2 + _str_idfsParameterTypeNotNull, o.ObjectIdent3 + _str_idfsParameterTypeNotNull, "long", o.idfsParameterTypeNotNull == null ? "" : o.idfsParameterTypeNotNull.ToString(), o.IsReadOnly(_str_idfsParameterTypeNotNull), o.IsInvisible(_str_idfsParameterTypeNotNull), o.IsRequired(_str_idfsParameterTypeNotNull));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_SelectList, _formname = _str_SelectList, _type = "Lookup",
              _get_func = o => { if (o.SelectList == null) return null; return o.SelectList.idfsValue; },
              _set_func = (o, val) => { o.SelectList = o.SelectListLookup.Where(c => c.idfsValue.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_SelectList, c);
                if (o.idfsValueDummy != c.idfsValueDummy || o.IsRIRPropChanged(_str_SelectList, c) || bChangeLookupContent) {
                  m.Add(_str_SelectList, o.ObjectIdent + _str_SelectList, o.ObjectIdent2 + _str_SelectList, o.ObjectIdent3 + _str_SelectList, "Lookup", o.idfsValueDummy == null ? "" : o.idfsValueDummy.ToString(), o.IsReadOnly(_str_SelectList), o.IsInvisible(_str_SelectList), o.IsRequired(_str_SelectList),
                  bChangeLookupContent ? o.SelectListLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_SelectList + "Lookup", _formname = _str_SelectList + "Lookup", _type = "LookupContent",
              _get_func = o => o.SelectListLookup,
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
            Parameter obj = (Parameter)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_SelectList)]
        [Relation(typeof(ParameterSelect), eidss.model.Schema.ParameterSelect._str_idfsValue, _str_idfsValueDummy)]
        public ParameterSelect SelectList
        {
            get { return _SelectList; }
            set 
            { 
                var oldVal = _SelectList;
                _SelectList = value;
                if (_SelectList != oldVal)
                {
                    if (idfsValueDummy != (_SelectList == null
                            ? new long?()
                            : _SelectList.idfsValue))
                        idfsValueDummy = _SelectList == null 
                            ? new long?()
                            : _SelectList.idfsValue; 
                    OnPropertyChanged(_str_SelectList); 
                }
            }
        }
        private ParameterSelect _SelectList;

        
        public List<ParameterSelect> SelectListLookup
        {
            get { return _SelectListLookup; }
        }
        private List<ParameterSelect> _SelectListLookup = new List<ParameterSelect>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_SelectList:
                    return new BvSelectList(SelectListLookup, eidss.model.Schema.ParameterSelect._str_idfsValue, null, SelectList, _str_idfsValueDummy);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsParameterTypeNotNull)]
        public long idfsParameterTypeNotNull
        {
            get { return new Func<Parameter, long>(c => c.idfsParameterType.HasValue ? c.idfsParameterType.Value : 0)(this); }
            
        }
        
          [LocalizedDisplayName(_str_idfsValueDummy)]
        public long? idfsValueDummy
        {
            get { return m_idfsValueDummy; }
            set { if (m_idfsValueDummy != value) { m_idfsValueDummy = value; OnPropertyChanged(_str_idfsValueDummy); } }
        }
        private long? m_idfsValueDummy;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "Parameter";

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
            var ret = base.Clone() as Parameter;
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
            var ret = base.Clone() as Parameter;
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
        public Parameter CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Parameter;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsParameter; } }
        public string KeyName { get { return "idfsParameter"; } }
        public object KeyLookup { get { return idfsParameter; } }
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
        
            var _prev_idfsValueDummy_SelectList = idfsValueDummy;
            base.RejectChanges();
        
            if (_prev_idfsValueDummy_SelectList != idfsValueDummy)
            {
                _SelectList = _SelectListLookup.FirstOrDefault(c => c.idfsValue == idfsValueDummy);
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

        private bool IsRIRPropChanged(string fld, Parameter c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, Parameter c)
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
        

      

        public Parameter()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Parameter_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Parameter_PropertyChanged);
        }
        private void Parameter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Parameter).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfsParameterType)
                OnPropertyChanged(_str_idfsParameterTypeNotNull);
                  
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
            Parameter obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Parameter obj = this;
            
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

    
        private bool _isReadOnly(string name)
        {
            
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


        internal Dictionary<string, Func<Parameter, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<Parameter, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Parameter, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Parameter, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<Parameter, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<Parameter, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<Parameter, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~Parameter()
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
                
                LookupManager.RemoveObject("ParameterSelect", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "ParameterSelect")
                _getAccessor().LoadLookup_SelectList(manager, this);
            
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
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<Parameter>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<Parameter>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsParameter"; } }
            #endregion
        
            public delegate void on_action(Parameter obj);
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
            private ParameterSelect.Accessor SelectListAccessor { get { return eidss.model.Schema.ParameterSelect.Accessor.Instance(m_CS); } }
            
            public virtual List<Parameter> SelectLookupList(DbManagerProxy manager
                , Int64? idfsSection
                , Int64? idfsFormType
                )
            {
                return _SelectList(manager
                    , idfsSection
                    , idfsFormType
                    , null, null
                    );
            }
            
            public virtual List<Parameter> SelectList(DbManagerProxy manager
                , Int64? idfsSection
                , Int64? idfsFormType
                )
            {
                return _SelectList(manager
                    , idfsSection
                    , idfsFormType
                    , delegate(Parameter obj)
                        {
                        }
                    , delegate(Parameter obj)
                        {
                        }
                    );
            }

            

            public List<Parameter> _SelectList(DbManagerProxy manager
                , Int64? idfsSection
                , Int64? idfsFormType
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfsSection
                    , idfsFormType
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            [InstanceCache(typeof(BvCacheAspect))]
            public virtual List<Parameter> _SelectListInternal(DbManagerProxy manager
                , Int64? idfsSection
                , Int64? idfsFormType
                , on_action loading, on_action loaded
                )
            {
                Parameter _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<Parameter> objs = new List<Parameter>();
                    sets[0] = new MapResultSet(typeof(Parameter), objs);
                    
                    manager
                        .SetSpCommand("spFFGetParameters"
                            , manager.Parameter("@idfsSection", idfsSection)
                            , manager.Parameter("@idfsFormType", idfsFormType)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, Parameter obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, Parameter obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private Parameter _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                Parameter obj = null;
                try
                {
                    obj = Parameter.CreateInstance();
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
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public Parameter CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public Parameter CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public Parameter CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(Parameter obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Parameter obj)
            {
                
            }
    
            public void LoadLookup_SelectList(DbManagerProxy manager, Parameter obj)
            {
                
                obj.SelectListLookup.Clear();
                
                obj.SelectListLookup.AddRange(SelectListAccessor.SelectLookupList(manager
                    
                    , new Func<Parameter, Int64>(c => c.idfsParameterTypeNotNull)(obj)
                            
                    , new Func<Parameter, Int64>(c => c.idfsFormType)(obj)
                            
                    , new Func<Parameter, Int64?>(c => c.intHACode)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsValue == obj.idfsValueDummy))
                    
                    .ToList());
                
                if (obj.idfsValueDummy != null && obj.idfsValueDummy != 0)
                {
                    obj.SelectList = obj.SelectListLookup
                        .SingleOrDefault(c => c.idfsValue == obj.idfsValueDummy);
                    
                }
              
                LookupManager.AddObject("ParameterSelect", obj, SelectListAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, Parameter obj)
            {
                
                LoadLookup_SelectList(manager, obj);
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(Parameter obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(Parameter obj, bool bRethrowException)
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
                return Validate(manager, obj as Parameter, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Parameter obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(Parameter obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(Parameter obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Parameter) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Parameter) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "ParameterDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFFGetParameters";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Parameter, bool>> RequiredByField = new Dictionary<string, Func<Parameter, bool>>();
            public static Dictionary<string, Func<Parameter, bool>> RequiredByProperty = new Dictionary<string, Func<Parameter, bool>>();
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
                
                Sizes.Add(_str_ParameterTypeName, 2000);
                Sizes.Add(_str_strNote, 1000);
                Sizes.Add(_str_DefaultName, 2000);
                Sizes.Add(_str_DefaultLongName, 2000);
                Sizes.Add(_str_NationalName, 2000);
                Sizes.Add(_str_NationalLongName, 2000);
                Sizes.Add(_str_langid, 50);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Parameter>().Post(manager, (Parameter)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Parameter>().Post(manager, (Parameter)c), c),
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
                    (manager, c, pars) => new ActResult(((Parameter)c).MarkToDelete() && ObjectAccessor.PostInterface<Parameter>().Post(manager, (Parameter)c), c),
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
	