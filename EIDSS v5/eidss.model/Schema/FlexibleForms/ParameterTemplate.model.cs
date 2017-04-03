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
    public abstract partial class ParameterTemplate : 
        EditableObject<ParameterTemplate>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsParameter), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsParameter { get; set; }
                
        [LocalizedDisplayName(_str_idfsSection)]
        [MapField(_str_idfsSection)]
        public abstract Int64? idfsSection { get; set; }
        #if MONO
        protected Int64? idfsSection_Original { get { return idfsSection; } }
        protected Int64? idfsSection_Previous { get { return idfsSection; } }
        #else
        protected Int64? idfsSection_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSection).OriginalValue; } }
        protected Int64? idfsSection_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSection).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsFormType)]
        [MapField(_str_idfsFormType)]
        public abstract Int64 idfsFormType { get; set; }
        #if MONO
        protected Int64 idfsFormType_Original { get { return idfsFormType; } }
        protected Int64 idfsFormType_Previous { get { return idfsFormType; } }
        #else
        protected Int64 idfsFormType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormType).OriginalValue; } }
        protected Int64 idfsFormType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int32? intHACode { get; set; }
        #if MONO
        protected Int32? intHACode_Original { get { return intHACode; } }
        protected Int32? intHACode_Previous { get { return intHACode; } }
        #else
        protected Int32? intHACode_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32? intHACode_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).PreviousValue; } }
        #endif
                
        [MapField(_str_idfsFormTemplate), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsFormTemplate { get; set; }
                
        [LocalizedDisplayName(_str_idfsEditMode)]
        [MapField(_str_idfsEditMode)]
        public abstract Int64? idfsEditMode { get; set; }
        #if MONO
        protected Int64? idfsEditMode_Original { get { return idfsEditMode; } }
        protected Int64? idfsEditMode_Previous { get { return idfsEditMode; } }
        #else
        protected Int64? idfsEditMode_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEditMode).OriginalValue; } }
        protected Int64? idfsEditMode_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEditMode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsEditor)]
        [MapField(_str_idfsEditor)]
        public abstract Int64? idfsEditor { get; set; }
        #if MONO
        protected Int64? idfsEditor_Original { get { return idfsEditor; } }
        protected Int64? idfsEditor_Previous { get { return idfsEditor; } }
        #else
        protected Int64? idfsEditor_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEditor).OriginalValue; } }
        protected Int64? idfsEditor_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEditor).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsParameterType)]
        [MapField(_str_idfsParameterType)]
        public abstract Int64? idfsParameterType { get; set; }
        #if MONO
        protected Int64? idfsParameterType_Original { get { return idfsParameterType; } }
        protected Int64? idfsParameterType_Previous { get { return idfsParameterType; } }
        #else
        protected Int64? idfsParameterType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParameterType).OriginalValue; } }
        protected Int64? idfsParameterType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParameterType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intLeft)]
        [MapField(_str_intLeft)]
        public abstract Int32 intLeft { get; set; }
        #if MONO
        protected Int32 intLeft_Original { get { return intLeft; } }
        protected Int32 intLeft_Previous { get { return intLeft; } }
        #else
        protected Int32 intLeft_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intLeft).OriginalValue; } }
        protected Int32 intLeft_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intLeft).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intTop)]
        [MapField(_str_intTop)]
        public abstract Int32 intTop { get; set; }
        #if MONO
        protected Int32 intTop_Original { get { return intTop; } }
        protected Int32 intTop_Previous { get { return intTop; } }
        #else
        protected Int32 intTop_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intTop).OriginalValue; } }
        protected Int32 intTop_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intTop).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intWidth)]
        [MapField(_str_intWidth)]
        public abstract Int32 intWidth { get; set; }
        #if MONO
        protected Int32 intWidth_Original { get { return intWidth; } }
        protected Int32 intWidth_Previous { get { return intWidth; } }
        #else
        protected Int32 intWidth_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intWidth).OriginalValue; } }
        protected Int32 intWidth_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intWidth).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intHeight)]
        [MapField(_str_intHeight)]
        public abstract Int32 intHeight { get; set; }
        #if MONO
        protected Int32 intHeight_Original { get { return intHeight; } }
        protected Int32 intHeight_Previous { get { return intHeight; } }
        #else
        protected Int32 intHeight_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intHeight).OriginalValue; } }
        protected Int32 intHeight_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intHeight).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intScheme)]
        [MapField(_str_intScheme)]
        public abstract Int32 intScheme { get; set; }
        #if MONO
        protected Int32 intScheme_Original { get { return intScheme; } }
        protected Int32 intScheme_Previous { get { return intScheme; } }
        #else
        protected Int32 intScheme_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intScheme).OriginalValue; } }
        protected Int32 intScheme_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intScheme).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intLabelSize)]
        [MapField(_str_intLabelSize)]
        public abstract Int32 intLabelSize { get; set; }
        #if MONO
        protected Int32 intLabelSize_Original { get { return intLabelSize; } }
        protected Int32 intLabelSize_Previous { get { return intLabelSize; } }
        #else
        protected Int32 intLabelSize_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intLabelSize).OriginalValue; } }
        protected Int32 intLabelSize_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intLabelSize).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32 intOrder { get; set; }
        #if MONO
        protected Int32 intOrder_Original { get { return intOrder; } }
        protected Int32 intOrder_Previous { get { return intOrder; } }
        #else
        protected Int32 intOrder_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32 intOrder_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_DefaultName)]
        [MapField(_str_DefaultName)]
        public abstract String DefaultName { get; set; }
        #if MONO
        protected String DefaultName_Original { get { return DefaultName; } }
        protected String DefaultName_Previous { get { return DefaultName; } }
        #else
        protected String DefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._defaultName).OriginalValue; } }
        protected String DefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._defaultName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_NationalName)]
        [MapField(_str_NationalName)]
        public abstract String NationalName { get; set; }
        #if MONO
        protected String NationalName_Original { get { return NationalName; } }
        protected String NationalName_Previous { get { return NationalName; } }
        #else
        protected String NationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._nationalName).OriginalValue; } }
        protected String NationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._nationalName).PreviousValue; } }
        #endif
                
        [MapField(_str_langid), NonUpdatable, PrimaryKey]
        public abstract String langid { get; set; }
                
        [LocalizedDisplayName(_str_blnFreeze)]
        [MapField(_str_blnFreeze)]
        public abstract Boolean blnFreeze { get; set; }
        #if MONO
        protected Boolean blnFreeze_Original { get { return blnFreeze; } }
        protected Boolean blnFreeze_Previous { get { return blnFreeze; } }
        #else
        protected Boolean blnFreeze_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnFreeze).OriginalValue; } }
        protected Boolean blnFreeze_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnFreeze).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnIsRealStruct)]
        [MapField(_str_blnIsRealStruct)]
        public abstract Boolean? blnIsRealStruct { get; set; }
        #if MONO
        protected Boolean? blnIsRealStruct_Original { get { return blnIsRealStruct; } }
        protected Boolean? blnIsRealStruct_Previous { get { return blnIsRealStruct; } }
        #else
        protected Boolean? blnIsRealStruct_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnIsRealStruct).OriginalValue; } }
        protected Boolean? blnIsRealStruct_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnIsRealStruct).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<ParameterTemplate, object> _get_func;
            internal Action<ParameterTemplate, string> _set_func;
            internal Action<ParameterTemplate, ParameterTemplate, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsParameter = "idfsParameter";
        internal const string _str_idfsSection = "idfsSection";
        internal const string _str_idfsFormType = "idfsFormType";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_idfsEditMode = "idfsEditMode";
        internal const string _str_idfsEditor = "idfsEditor";
        internal const string _str_idfsParameterType = "idfsParameterType";
        internal const string _str_intLeft = "intLeft";
        internal const string _str_intTop = "intTop";
        internal const string _str_intWidth = "intWidth";
        internal const string _str_intHeight = "intHeight";
        internal const string _str_intScheme = "intScheme";
        internal const string _str_intLabelSize = "intLabelSize";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_DefaultName = "DefaultName";
        internal const string _str_NationalName = "NationalName";
        internal const string _str_langid = "langid";
        internal const string _str_blnFreeze = "blnFreeze";
        internal const string _str_blnIsRealStruct = "blnIsRealStruct";
        internal const string _str_FormType = "FormType";
        internal const string _str_ParentSection = "ParentSection";
        internal const string _str_SelectList = "SelectList";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfsParameter, _type = "Int64",
              _get_func = o => o.idfsParameter,
              _set_func = (o, val) => { o.idfsParameter = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsParameter != c.idfsParameter || o.IsRIRPropChanged(_str_idfsParameter, c)) 
                  m.Add(_str_idfsParameter, o.ObjectIdent + _str_idfsParameter, "Int64", o.idfsParameter == null ? "" : o.idfsParameter.ToString(), o.IsReadOnly(_str_idfsParameter), o.IsInvisible(_str_idfsParameter), o.IsRequired(_str_idfsParameter)); }
              }, 
        
            new field_info {
              _name = _str_idfsSection, _type = "Int64?",
              _get_func = o => o.idfsSection,
              _set_func = (o, val) => { o.idfsSection = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSection != c.idfsSection || o.IsRIRPropChanged(_str_idfsSection, c)) 
                  m.Add(_str_idfsSection, o.ObjectIdent + _str_idfsSection, "Int64?", o.idfsSection == null ? "" : o.idfsSection.ToString(), o.IsReadOnly(_str_idfsSection), o.IsInvisible(_str_idfsSection), o.IsRequired(_str_idfsSection)); }
              }, 
        
            new field_info {
              _name = _str_idfsFormType, _type = "Int64",
              _get_func = o => o.idfsFormType,
              _set_func = (o, val) => { o.idfsFormType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsFormType != c.idfsFormType || o.IsRIRPropChanged(_str_idfsFormType, c)) 
                  m.Add(_str_idfsFormType, o.ObjectIdent + _str_idfsFormType, "Int64", o.idfsFormType == null ? "" : o.idfsFormType.ToString(), o.IsReadOnly(_str_idfsFormType), o.IsInvisible(_str_idfsFormType), o.IsRequired(_str_idfsFormType)); }
              }, 
        
            new field_info {
              _name = _str_intHACode, _type = "Int32?",
              _get_func = o => o.intHACode,
              _set_func = (o, val) => { o.intHACode = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intHACode != c.intHACode || o.IsRIRPropChanged(_str_intHACode, c)) 
                  m.Add(_str_intHACode, o.ObjectIdent + _str_intHACode, "Int32?", o.intHACode == null ? "" : o.intHACode.ToString(), o.IsReadOnly(_str_intHACode), o.IsInvisible(_str_intHACode), o.IsRequired(_str_intHACode)); }
              }, 
        
            new field_info {
              _name = _str_idfsFormTemplate, _type = "Int64",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { o.idfsFormTemplate = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, "Int64", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); }
              }, 
        
            new field_info {
              _name = _str_idfsEditMode, _type = "Int64?",
              _get_func = o => o.idfsEditMode,
              _set_func = (o, val) => { o.idfsEditMode = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsEditMode != c.idfsEditMode || o.IsRIRPropChanged(_str_idfsEditMode, c)) 
                  m.Add(_str_idfsEditMode, o.ObjectIdent + _str_idfsEditMode, "Int64?", o.idfsEditMode == null ? "" : o.idfsEditMode.ToString(), o.IsReadOnly(_str_idfsEditMode), o.IsInvisible(_str_idfsEditMode), o.IsRequired(_str_idfsEditMode)); }
              }, 
        
            new field_info {
              _name = _str_idfsEditor, _type = "Int64?",
              _get_func = o => o.idfsEditor,
              _set_func = (o, val) => { o.idfsEditor = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsEditor != c.idfsEditor || o.IsRIRPropChanged(_str_idfsEditor, c)) 
                  m.Add(_str_idfsEditor, o.ObjectIdent + _str_idfsEditor, "Int64?", o.idfsEditor == null ? "" : o.idfsEditor.ToString(), o.IsReadOnly(_str_idfsEditor), o.IsInvisible(_str_idfsEditor), o.IsRequired(_str_idfsEditor)); }
              }, 
        
            new field_info {
              _name = _str_idfsParameterType, _type = "Int64?",
              _get_func = o => o.idfsParameterType,
              _set_func = (o, val) => { o.idfsParameterType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsParameterType != c.idfsParameterType || o.IsRIRPropChanged(_str_idfsParameterType, c)) 
                  m.Add(_str_idfsParameterType, o.ObjectIdent + _str_idfsParameterType, "Int64?", o.idfsParameterType == null ? "" : o.idfsParameterType.ToString(), o.IsReadOnly(_str_idfsParameterType), o.IsInvisible(_str_idfsParameterType), o.IsRequired(_str_idfsParameterType)); }
              }, 
        
            new field_info {
              _name = _str_intLeft, _type = "Int32",
              _get_func = o => o.intLeft,
              _set_func = (o, val) => { o.intLeft = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intLeft != c.intLeft || o.IsRIRPropChanged(_str_intLeft, c)) 
                  m.Add(_str_intLeft, o.ObjectIdent + _str_intLeft, "Int32", o.intLeft == null ? "" : o.intLeft.ToString(), o.IsReadOnly(_str_intLeft), o.IsInvisible(_str_intLeft), o.IsRequired(_str_intLeft)); }
              }, 
        
            new field_info {
              _name = _str_intTop, _type = "Int32",
              _get_func = o => o.intTop,
              _set_func = (o, val) => { o.intTop = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intTop != c.intTop || o.IsRIRPropChanged(_str_intTop, c)) 
                  m.Add(_str_intTop, o.ObjectIdent + _str_intTop, "Int32", o.intTop == null ? "" : o.intTop.ToString(), o.IsReadOnly(_str_intTop), o.IsInvisible(_str_intTop), o.IsRequired(_str_intTop)); }
              }, 
        
            new field_info {
              _name = _str_intWidth, _type = "Int32",
              _get_func = o => o.intWidth,
              _set_func = (o, val) => { o.intWidth = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intWidth != c.intWidth || o.IsRIRPropChanged(_str_intWidth, c)) 
                  m.Add(_str_intWidth, o.ObjectIdent + _str_intWidth, "Int32", o.intWidth == null ? "" : o.intWidth.ToString(), o.IsReadOnly(_str_intWidth), o.IsInvisible(_str_intWidth), o.IsRequired(_str_intWidth)); }
              }, 
        
            new field_info {
              _name = _str_intHeight, _type = "Int32",
              _get_func = o => o.intHeight,
              _set_func = (o, val) => { o.intHeight = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intHeight != c.intHeight || o.IsRIRPropChanged(_str_intHeight, c)) 
                  m.Add(_str_intHeight, o.ObjectIdent + _str_intHeight, "Int32", o.intHeight == null ? "" : o.intHeight.ToString(), o.IsReadOnly(_str_intHeight), o.IsInvisible(_str_intHeight), o.IsRequired(_str_intHeight)); }
              }, 
        
            new field_info {
              _name = _str_intScheme, _type = "Int32",
              _get_func = o => o.intScheme,
              _set_func = (o, val) => { o.intScheme = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intScheme != c.intScheme || o.IsRIRPropChanged(_str_intScheme, c)) 
                  m.Add(_str_intScheme, o.ObjectIdent + _str_intScheme, "Int32", o.intScheme == null ? "" : o.intScheme.ToString(), o.IsReadOnly(_str_intScheme), o.IsInvisible(_str_intScheme), o.IsRequired(_str_intScheme)); }
              }, 
        
            new field_info {
              _name = _str_intLabelSize, _type = "Int32",
              _get_func = o => o.intLabelSize,
              _set_func = (o, val) => { o.intLabelSize = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intLabelSize != c.intLabelSize || o.IsRIRPropChanged(_str_intLabelSize, c)) 
                  m.Add(_str_intLabelSize, o.ObjectIdent + _str_intLabelSize, "Int32", o.intLabelSize == null ? "" : o.intLabelSize.ToString(), o.IsReadOnly(_str_intLabelSize), o.IsInvisible(_str_intLabelSize), o.IsRequired(_str_intLabelSize)); }
              }, 
        
            new field_info {
              _name = _str_intOrder, _type = "Int32",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { o.intOrder = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, "Int32", o.intOrder == null ? "" : o.intOrder.ToString(), o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); }
              }, 
        
            new field_info {
              _name = _str_DefaultName, _type = "String",
              _get_func = o => o.DefaultName,
              _set_func = (o, val) => { o.DefaultName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.DefaultName != c.DefaultName || o.IsRIRPropChanged(_str_DefaultName, c)) 
                  m.Add(_str_DefaultName, o.ObjectIdent + _str_DefaultName, "String", o.DefaultName == null ? "" : o.DefaultName.ToString(), o.IsReadOnly(_str_DefaultName), o.IsInvisible(_str_DefaultName), o.IsRequired(_str_DefaultName)); }
              }, 
        
            new field_info {
              _name = _str_NationalName, _type = "String",
              _get_func = o => o.NationalName,
              _set_func = (o, val) => { o.NationalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.NationalName != c.NationalName || o.IsRIRPropChanged(_str_NationalName, c)) 
                  m.Add(_str_NationalName, o.ObjectIdent + _str_NationalName, "String", o.NationalName == null ? "" : o.NationalName.ToString(), o.IsReadOnly(_str_NationalName), o.IsInvisible(_str_NationalName), o.IsRequired(_str_NationalName)); }
              }, 
        
            new field_info {
              _name = _str_langid, _type = "String",
              _get_func = o => o.langid,
              _set_func = (o, val) => { o.langid = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.langid != c.langid || o.IsRIRPropChanged(_str_langid, c)) 
                  m.Add(_str_langid, o.ObjectIdent + _str_langid, "String", o.langid == null ? "" : o.langid.ToString(), o.IsReadOnly(_str_langid), o.IsInvisible(_str_langid), o.IsRequired(_str_langid)); }
              }, 
        
            new field_info {
              _name = _str_blnFreeze, _type = "Boolean",
              _get_func = o => o.blnFreeze,
              _set_func = (o, val) => { o.blnFreeze = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
                if (o.blnFreeze != c.blnFreeze || o.IsRIRPropChanged(_str_blnFreeze, c)) 
                  m.Add(_str_blnFreeze, o.ObjectIdent + _str_blnFreeze, "Boolean", o.blnFreeze == null ? "" : o.blnFreeze.ToString(), o.IsReadOnly(_str_blnFreeze), o.IsInvisible(_str_blnFreeze), o.IsRequired(_str_blnFreeze)); }
              }, 
        
            new field_info {
              _name = _str_blnIsRealStruct, _type = "Boolean?",
              _get_func = o => o.blnIsRealStruct,
              _set_func = (o, val) => { o.blnIsRealStruct = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnIsRealStruct != c.blnIsRealStruct || o.IsRIRPropChanged(_str_blnIsRealStruct, c)) 
                  m.Add(_str_blnIsRealStruct, o.ObjectIdent + _str_blnIsRealStruct, "Boolean?", o.blnIsRealStruct == null ? "" : o.blnIsRealStruct.ToString(), o.IsReadOnly(_str_blnIsRealStruct), o.IsInvisible(_str_blnIsRealStruct), o.IsRequired(_str_blnIsRealStruct)); }
              }, 
        
            new field_info {
              _name = _str_SelectList, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.SelectList.Count != c.SelectList.Count || o.IsReadOnly(_str_SelectList) != c.IsReadOnly(_str_SelectList) || o.IsInvisible(_str_SelectList) != c.IsInvisible(_str_SelectList) || o.IsRequired(_str_SelectList) != c.IsRequired(_str_SelectList)) 
                  m.Add(_str_SelectList, o.ObjectIdent + _str_SelectList, "Child", o.idfsParameter == null ? "" : o.idfsParameter.ToString(), o.IsReadOnly(_str_SelectList), o.IsInvisible(_str_SelectList), o.IsRequired(_str_SelectList)); }
              }, 
        
            new field_info {
              _name = _str_FormType, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.FormType != null) o.FormType._compare(c.FormType, m); }
              }, 
        
            new field_info {
              _name = _str_ParentSection, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.ParentSection != null) o.ParentSection._compare(c.ParentSection, m); }
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
            ParameterTemplate obj = (ParameterTemplate)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(FormType), eidss.model.Schema.FormType._str_idfsFormType, _str_idfsFormType)]
        public FormType FormType
        {
            get 
            {   
                if (!_FormTypeLoaded)
                {
                    _FormTypeLoaded = true;
                    _getAccessor()._LoadFormType(this);
                    if (_FormType != null) 
                        _FormType.Parent = this;
                }
                return _FormType; 
            }
            set 
            {   
                if (!_FormTypeLoaded) { _FormTypeLoaded = true; }
                _FormType = value;
                if (_FormType != null) 
                { 
                    _FormType.m_ObjectName = _str_FormType;
                    _FormType.Parent = this;
                }
                idfsFormType = _FormType == null 
                        ? new Int64()
                        : _FormType.idfsFormType;
                
            }
        }
        protected FormType _FormType;
                    
        private bool _FormTypeLoaded = false;
                    
        [Relation(typeof(Section), eidss.model.Schema.Section._str_idfsSection, _str_idfsSection)]
        public Section ParentSection
        {
            get 
            {   
                if (!_ParentSectionLoaded)
                {
                    _ParentSectionLoaded = true;
                    _getAccessor()._LoadParentSection(this);
                    if (_ParentSection != null) 
                        _ParentSection.Parent = this;
                }
                return _ParentSection; 
            }
            set 
            {   
                if (!_ParentSectionLoaded) { _ParentSectionLoaded = true; }
                _ParentSection = value; 
                if (_ParentSection != null) 
                { 
                    _ParentSection.m_ObjectName = _str_ParentSection;
                    _ParentSection.Parent = this;
                }
            }
        }
        protected Section _ParentSection;
                    
        private bool _ParentSectionLoaded = false;
                    
        [Relation(typeof(ParameterSelect), eidss.model.Schema.ParameterSelect._str_idfsParameter, _str_idfsParameter)]
        public EditableList<ParameterSelect> SelectList
        {
            get 
            {   
                return _SelectList; 
            }
            set 
            {
                _SelectList = value;
            }
        }
        protected EditableList<ParameterSelect> _SelectList = new EditableList<ParameterSelect>();
                    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "ParameterTemplate";

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
        
            if (_FormType != null) { _FormType.Parent = this; }
                
            if (_ParentSection != null) { _ParentSection.Parent = this; }
                SelectList.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as ParameterTemplate;
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
            var ret = base.Clone() as ParameterTemplate;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_FormType != null)
              ret.FormType = _FormType.CloneWithSetup(manager) as FormType;
                
            if (_ParentSection != null)
              ret.ParentSection = _ParentSection.CloneWithSetup(manager) as Section;
                
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public ParameterTemplate CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as ParameterTemplate;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsParameter; } }
        public string KeyName { get { return "idfsParameter"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || (_FormType != null && _FormType.HasChanges)
                
                    || (_ParentSection != null && _ParentSection.HasChanges)
                
                    || SelectList.IsDirty
                    || SelectList.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
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
        
            if (FormType != null) FormType.RejectChanges();
                
            if (ParentSection != null) ParentSection.RejectChanges();
                SelectList.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_FormType != null) _FormType.AcceptChanges();
                
            if (_ParentSection != null) _ParentSection.AcceptChanges();
                SelectList.AcceptChanges();
                
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
        
            if (_FormType != null) _FormType.SetChange();
                
            if (_ParentSection != null) _ParentSection.SetChange();
                SelectList.ForEach(c => c.SetChange());
                
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

      private bool IsRIRPropChanged(string fld, ParameterTemplate c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public ParameterTemplate()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ParameterTemplate_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(ParameterTemplate_PropertyChanged);
        }
        private void ParameterTemplate_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as ParameterTemplate).Changed(e.PropertyName);
            
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
            ParameterTemplate obj = this;
            
        }
        private void _DeletedExtenders()
        {
            ParameterTemplate obj = this;
            
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
        
                if (_FormType != null)
                    _FormType.ReadOnly = value;
                
                if (_ParentSection != null)
                    _ParentSection.ReadOnly = value;
                
                foreach(var o in _SelectList)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<ParameterTemplate, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<ParameterTemplate, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<ParameterTemplate, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<ParameterTemplate, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<ParameterTemplate, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<ParameterTemplate, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~ParameterTemplate()
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
        
            if (_FormType != null) _FormType.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_ParentSection != null) _ParentSection.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_SelectList != null) _SelectList.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<ParameterTemplate>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectPost
                    
        {
            private delegate void on_action(ParameterTemplate obj);
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
            private FormType.Accessor FormTypeAccessor { get { return eidss.model.Schema.FormType.Accessor.Instance(m_CS); } }
            private Section.Accessor ParentSectionAccessor { get { return eidss.model.Schema.Section.Accessor.Instance(m_CS); } }
            private ParameterSelect.Accessor SelectListAccessor { get { return eidss.model.Schema.ParameterSelect.Accessor.Instance(m_CS); } }
            [InstanceCache(typeof(BvCacheAspect))][InstanceCache(typeof(BvCacheAspect))]
            public virtual List<ParameterTemplate> SelectList(DbManagerProxy manager
                , Int64? idfsParameter
                , Int64? idfsFormTemplate
                )
            {
                return _SelectList(manager
                    , idfsParameter
                    , idfsFormTemplate
                    , delegate(ParameterTemplate obj)
                        {
                        }
                    , delegate(ParameterTemplate obj)
                        {
                        }
                    );
            }

            
            public List<ParameterTemplate> SelectDetailListT(DbManagerProxy manager, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 2) 
                    throw new ParamsCountException();
                
                if (!(pars[0] is Int64?)) 
                    throw new TypeMismatchException("idfsParameter", typeof(Int64?));
                
                if (!(pars[1] is Int64?)) 
                    throw new TypeMismatchException("idfsFormTemplate", typeof(Int64?));
                
                return SelectDetailList(manager
                    
                    , (Int64?)pars[0]
                    
                    , (Int64?)pars[1]
                    
                    );
            }
            public List<ParameterTemplate> SelectDetailList(DbManagerProxy manager, List<object> pars)
            {
                return SelectDetailListT(manager, pars);
            }
            public virtual List<ParameterTemplate> SelectDetailList(DbManagerProxy manager
                , Int64? idfsParameter
                , Int64? idfsFormTemplate
                )
            {
                return _SelectList(manager
                    , idfsParameter
                    , idfsFormTemplate
                    , delegate(ParameterTemplate obj)
                        {
                
                        }
                    , delegate(ParameterTemplate obj)
                        {
                
                        }
                    );
            }
            
            private List<ParameterTemplate> _SelectList(DbManagerProxy manager
                , Int64? idfsParameter
                , Int64? idfsFormTemplate
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<ParameterTemplate> objs = new List<ParameterTemplate>();
                    sets[0] = new MapResultSet(typeof(ParameterTemplate), objs);
                    
                    manager
                        .SetSpCommand("spFFGetParameterTemplate"
                            , manager.Parameter("@idfsParameter", idfsParameter)
                            , manager.Parameter("@idfsFormTemplate", idfsFormTemplate)
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
    
            private void _SetupAddChildHandlerSelectList(ParameterTemplate obj)
            {
                obj.SelectList.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            internal void _LoadFormType(ParameterTemplate obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFormType(manager, obj);
                }
            }
            internal void _LoadFormType(DbManagerProxy manager, ParameterTemplate obj)
            {
                
                if (obj.FormType == null && obj.idfsFormType != 0)
                {
                    obj.FormType = FormTypeAccessor.SelectByKey(manager
                        
                        , obj.idfsFormType
                        );
                    if (obj.FormType != null)
                    {
                        obj.FormType.m_ObjectName = _str_FormType;
                    }
                }
                    
            }
            
            internal void _LoadParentSection(ParameterTemplate obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadParentSection(manager, obj);
                }
            }
            internal void _LoadParentSection(DbManagerProxy manager, ParameterTemplate obj)
            {
                
                if (obj.ParentSection == null && obj.idfsSection != null && obj.idfsSection != 0)
                {
                    obj.ParentSection = ParentSectionAccessor.SelectByKey(manager
                        
                        , new Func<ParameterTemplate, Int64?>(c => null)(obj)
                        
                        , new Func<ParameterTemplate, Int64?>(c => c.idfsSection)(obj)
                        
                        , new Func<ParameterTemplate, Int64?>(c => null)(obj)
                        
                        );
                    if (obj.ParentSection != null)
                    {
                        obj.ParentSection.m_ObjectName = _str_ParentSection;
                    }
                }
                    
            }
            
            internal void _LoadSelectList(ParameterTemplate obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSelectList(manager, obj);
                }
            }
            internal void _LoadSelectList(DbManagerProxy manager, ParameterTemplate obj)
            {
                
                obj.SelectList.Clear();
                obj.SelectList.AddRange(SelectListAccessor.SelectDetailList(manager
                    
                    , new Func<ParameterTemplate, Int64?>(c => c.idfsParameter)(obj)
                    
                    , new Func<ParameterTemplate, Int64?>(c => c.idfsParameterType)(obj)
                    
                    , new Func<ParameterTemplate, Int64?>(c => c.intHACode)(obj)
                    
                    ));
                obj.SelectList.ForEach(c => c.m_ObjectName = _str_SelectList);
                obj.SelectList.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, ParameterTemplate obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadSelectList(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.SelectList.Insert(0, new Func<ParameterTemplate, ParameterSelect>(c => SelectListAccessor.CreateDefault(manager, c, c.idfsParameter, c.idfsParameterType, c.intHACode))(obj));
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerSelectList(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, ParameterTemplate obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    FormTypeAccessor._SetPermitions(obj._permissions, obj.FormType);
                    ParentSectionAccessor._SetPermitions(obj._permissions, obj.ParentSection);
                    
                        obj.SelectList.ForEach(c => SelectListAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private ParameterTemplate _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    ParameterTemplate obj = ParameterTemplate.CreateInstance();
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
                    
                    _SetupAddChildHandlerSelectList(obj);
                    
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

            
            public ParameterTemplate CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public ParameterTemplate CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(ParameterTemplate obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(ParameterTemplate obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, ParameterTemplate obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as ParameterTemplate, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, ParameterTemplate obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(ParameterTemplate obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(ParameterTemplate obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as ParameterTemplate) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as ParameterTemplate) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "ParameterTemplateDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFFGetParameterTemplate";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<ParameterTemplate, bool>> RequiredByField = new Dictionary<string, Func<ParameterTemplate, bool>>();
            public static Dictionary<string, Func<ParameterTemplate, bool>> RequiredByProperty = new Dictionary<string, Func<ParameterTemplate, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_DefaultName, 2000);
                Sizes.Add(_str_NationalName, 2000);
                Sizes.Add(_str_langid, 50);
                Actions.Add(new ActionMetaItem(
                    "SelectDetailList",
                    ActionTypes.Loadlist,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
                    null,
                    
                    null,
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
                    (manager, c, pars) => new ActResult(((ParameterTemplate)c).MarkToDelete() && ObjectAccessor.PostInterface<ParameterTemplate>().Post(manager, (ParameterTemplate)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<ParameterTemplate>().Post(manager, (ParameterTemplate)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<ParameterTemplate>().Post(manager, (ParameterTemplate)c), c),
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
	