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
    public abstract partial class SectionTemplate : 
        EditableObject<SectionTemplate>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsSection), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsSection { get; set; }
                
        [LocalizedDisplayName(_str_idfsParentSection)]
        [MapField(_str_idfsParentSection)]
        public abstract Int64? idfsParentSection { get; set; }
        protected Int64? idfsParentSection_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParentSection).OriginalValue; } }
        protected Int64? idfsParentSection_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParentSection).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFormType)]
        [MapField(_str_idfsFormType)]
        public abstract Int64 idfsFormType { get; set; }
        protected Int64 idfsFormType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormType).OriginalValue; } }
        protected Int64 idfsFormType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64 idfsFormTemplate { get; set; }
        protected Int64 idfsFormTemplate_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64 idfsFormTemplate_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnFreeze)]
        [MapField(_str_blnFreeze)]
        public abstract Boolean blnFreeze { get; set; }
        protected Boolean blnFreeze_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnFreeze).OriginalValue; } }
        protected Boolean blnFreeze_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnFreeze).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnFixedRowSet)]
        [MapField(_str_blnFixedRowSet)]
        public abstract Boolean blnFixedRowSet { get; set; }
        protected Boolean blnFixedRowSet_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnFixedRowSet).OriginalValue; } }
        protected Boolean blnFixedRowSet_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnFixedRowSet).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intLeft)]
        [MapField(_str_intLeft)]
        public abstract Int32? intLeft { get; set; }
        protected Int32? intLeft_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intLeft).OriginalValue; } }
        protected Int32? intLeft_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intLeft).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intTop)]
        [MapField(_str_intTop)]
        public abstract Int32? intTop { get; set; }
        protected Int32? intTop_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intTop).OriginalValue; } }
        protected Int32? intTop_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intTop).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intWidth)]
        [MapField(_str_intWidth)]
        public abstract Int32? intWidth { get; set; }
        protected Int32? intWidth_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intWidth).OriginalValue; } }
        protected Int32? intWidth_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intWidth).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHeight)]
        [MapField(_str_intHeight)]
        public abstract Int32? intHeight { get; set; }
        protected Int32? intHeight_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intHeight).OriginalValue; } }
        protected Int32? intHeight_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intHeight).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intCaptionHeight)]
        [MapField(_str_intCaptionHeight)]
        public abstract Int32? intCaptionHeight { get; set; }
        protected Int32? intCaptionHeight_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intCaptionHeight).OriginalValue; } }
        protected Int32? intCaptionHeight_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intCaptionHeight).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DefaultName)]
        [MapField(_str_DefaultName)]
        public abstract String DefaultName { get; set; }
        protected String DefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._defaultName).OriginalValue; } }
        protected String DefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._defaultName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_NationalName)]
        [MapField(_str_NationalName)]
        public abstract String NationalName { get; set; }
        protected String NationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._nationalName).OriginalValue; } }
        protected String NationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._nationalName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_langid)]
        [MapField(_str_langid)]
        public abstract String langid { get; set; }
        protected String langid_Original { get { return ((EditableValue<String>)((dynamic)this)._langid).OriginalValue; } }
        protected String langid_Previous { get { return ((EditableValue<String>)((dynamic)this)._langid).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnGrid)]
        [MapField(_str_blnGrid)]
        public abstract Boolean blnGrid { get; set; }
        protected Boolean blnGrid_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnGrid).OriginalValue; } }
        protected Boolean blnGrid_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnGrid).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32? intOrder { get; set; }
        protected Int32? intOrder_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32? intOrder_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnIsRealStruct)]
        [MapField(_str_blnIsRealStruct)]
        public abstract Boolean? blnIsRealStruct { get; set; }
        protected Boolean? blnIsRealStruct_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnIsRealStruct).OriginalValue; } }
        protected Boolean? blnIsRealStruct_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnIsRealStruct).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<SectionTemplate, object> _get_func;
            internal Action<SectionTemplate, string> _set_func;
            internal Action<SectionTemplate, SectionTemplate, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsSection = "idfsSection";
        internal const string _str_idfsParentSection = "idfsParentSection";
        internal const string _str_idfsFormType = "idfsFormType";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_blnFreeze = "blnFreeze";
        internal const string _str_blnFixedRowSet = "blnFixedRowSet";
        internal const string _str_intLeft = "intLeft";
        internal const string _str_intTop = "intTop";
        internal const string _str_intWidth = "intWidth";
        internal const string _str_intHeight = "intHeight";
        internal const string _str_intCaptionHeight = "intCaptionHeight";
        internal const string _str_DefaultName = "DefaultName";
        internal const string _str_NationalName = "NationalName";
        internal const string _str_langid = "langid";
        internal const string _str_blnGrid = "blnGrid";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_blnIsRealStruct = "blnIsRealStruct";
        internal const string _str_IsFixedStubSection = "IsFixedStubSection";
        internal const string _str_Section = "Section";
        internal const string _str_ParentSection = "ParentSection";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsSection, _formname = _str_idfsSection, _type = "Int64",
              _get_func = o => o.idfsSection,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsSection != newval) 
                  o.Section = o.SectionLookup.FirstOrDefault(c => c.idfsSection == newval);
                if (o.idfsSection != newval) o.idfsSection = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSection != c.idfsSection || o.IsRIRPropChanged(_str_idfsSection, c)) 
                  m.Add(_str_idfsSection, o.ObjectIdent + _str_idfsSection, o.ObjectIdent2 + _str_idfsSection, o.ObjectIdent3 + _str_idfsSection, "Int64", 
                    o.idfsSection == null ? "" : o.idfsSection.ToString(),                  
                  o.IsReadOnly(_str_idfsSection), o.IsInvisible(_str_idfsSection), o.IsRequired(_str_idfsSection)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsParentSection, _formname = _str_idfsParentSection, _type = "Int64?",
              _get_func = o => o.idfsParentSection,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsParentSection != newval) 
                  o.ParentSection = o.ParentSectionLookup.FirstOrDefault(c => c.idfsSection == newval);
                if (o.idfsParentSection != newval) o.idfsParentSection = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsParentSection != c.idfsParentSection || o.IsRIRPropChanged(_str_idfsParentSection, c)) 
                  m.Add(_str_idfsParentSection, o.ObjectIdent + _str_idfsParentSection, o.ObjectIdent2 + _str_idfsParentSection, o.ObjectIdent3 + _str_idfsParentSection, "Int64?", 
                    o.idfsParentSection == null ? "" : o.idfsParentSection.ToString(),                  
                  o.IsReadOnly(_str_idfsParentSection), o.IsInvisible(_str_idfsParentSection), o.IsRequired(_str_idfsParentSection)); 
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
              _name = _str_idfsFormTemplate, _formname = _str_idfsFormTemplate, _type = "Int64",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsFormTemplate != newval) o.idfsFormTemplate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, o.ObjectIdent2 + _str_idfsFormTemplate, o.ObjectIdent3 + _str_idfsFormTemplate, "Int64", 
                    o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(),                  
                  o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnFreeze, _formname = _str_blnFreeze, _type = "Boolean",
              _get_func = o => o.blnFreeze,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnFreeze != newval) o.blnFreeze = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnFreeze != c.blnFreeze || o.IsRIRPropChanged(_str_blnFreeze, c)) 
                  m.Add(_str_blnFreeze, o.ObjectIdent + _str_blnFreeze, o.ObjectIdent2 + _str_blnFreeze, o.ObjectIdent3 + _str_blnFreeze, "Boolean", 
                    o.blnFreeze == null ? "" : o.blnFreeze.ToString(),                  
                  o.IsReadOnly(_str_blnFreeze), o.IsInvisible(_str_blnFreeze), o.IsRequired(_str_blnFreeze)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnFixedRowSet, _formname = _str_blnFixedRowSet, _type = "Boolean",
              _get_func = o => o.blnFixedRowSet,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnFixedRowSet != newval) o.blnFixedRowSet = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnFixedRowSet != c.blnFixedRowSet || o.IsRIRPropChanged(_str_blnFixedRowSet, c)) 
                  m.Add(_str_blnFixedRowSet, o.ObjectIdent + _str_blnFixedRowSet, o.ObjectIdent2 + _str_blnFixedRowSet, o.ObjectIdent3 + _str_blnFixedRowSet, "Boolean", 
                    o.blnFixedRowSet == null ? "" : o.blnFixedRowSet.ToString(),                  
                  o.IsReadOnly(_str_blnFixedRowSet), o.IsInvisible(_str_blnFixedRowSet), o.IsRequired(_str_blnFixedRowSet)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intLeft, _formname = _str_intLeft, _type = "Int32?",
              _get_func = o => o.intLeft,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intLeft != newval) o.intLeft = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intLeft != c.intLeft || o.IsRIRPropChanged(_str_intLeft, c)) 
                  m.Add(_str_intLeft, o.ObjectIdent + _str_intLeft, o.ObjectIdent2 + _str_intLeft, o.ObjectIdent3 + _str_intLeft, "Int32?", 
                    o.intLeft == null ? "" : o.intLeft.ToString(),                  
                  o.IsReadOnly(_str_intLeft), o.IsInvisible(_str_intLeft), o.IsRequired(_str_intLeft)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intTop, _formname = _str_intTop, _type = "Int32?",
              _get_func = o => o.intTop,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intTop != newval) o.intTop = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intTop != c.intTop || o.IsRIRPropChanged(_str_intTop, c)) 
                  m.Add(_str_intTop, o.ObjectIdent + _str_intTop, o.ObjectIdent2 + _str_intTop, o.ObjectIdent3 + _str_intTop, "Int32?", 
                    o.intTop == null ? "" : o.intTop.ToString(),                  
                  o.IsReadOnly(_str_intTop), o.IsInvisible(_str_intTop), o.IsRequired(_str_intTop)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intWidth, _formname = _str_intWidth, _type = "Int32?",
              _get_func = o => o.intWidth,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intWidth != newval) o.intWidth = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intWidth != c.intWidth || o.IsRIRPropChanged(_str_intWidth, c)) 
                  m.Add(_str_intWidth, o.ObjectIdent + _str_intWidth, o.ObjectIdent2 + _str_intWidth, o.ObjectIdent3 + _str_intWidth, "Int32?", 
                    o.intWidth == null ? "" : o.intWidth.ToString(),                  
                  o.IsReadOnly(_str_intWidth), o.IsInvisible(_str_intWidth), o.IsRequired(_str_intWidth)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intHeight, _formname = _str_intHeight, _type = "Int32?",
              _get_func = o => o.intHeight,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intHeight != newval) o.intHeight = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intHeight != c.intHeight || o.IsRIRPropChanged(_str_intHeight, c)) 
                  m.Add(_str_intHeight, o.ObjectIdent + _str_intHeight, o.ObjectIdent2 + _str_intHeight, o.ObjectIdent3 + _str_intHeight, "Int32?", 
                    o.intHeight == null ? "" : o.intHeight.ToString(),                  
                  o.IsReadOnly(_str_intHeight), o.IsInvisible(_str_intHeight), o.IsRequired(_str_intHeight)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intCaptionHeight, _formname = _str_intCaptionHeight, _type = "Int32?",
              _get_func = o => o.intCaptionHeight,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intCaptionHeight != newval) o.intCaptionHeight = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intCaptionHeight != c.intCaptionHeight || o.IsRIRPropChanged(_str_intCaptionHeight, c)) 
                  m.Add(_str_intCaptionHeight, o.ObjectIdent + _str_intCaptionHeight, o.ObjectIdent2 + _str_intCaptionHeight, o.ObjectIdent3 + _str_intCaptionHeight, "Int32?", 
                    o.intCaptionHeight == null ? "" : o.intCaptionHeight.ToString(),                  
                  o.IsReadOnly(_str_intCaptionHeight), o.IsInvisible(_str_intCaptionHeight), o.IsRequired(_str_intCaptionHeight)); 
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
              _name = _str_blnGrid, _formname = _str_blnGrid, _type = "Boolean",
              _get_func = o => o.blnGrid,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnGrid != newval) o.blnGrid = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnGrid != c.blnGrid || o.IsRIRPropChanged(_str_blnGrid, c)) 
                  m.Add(_str_blnGrid, o.ObjectIdent + _str_blnGrid, o.ObjectIdent2 + _str_blnGrid, o.ObjectIdent3 + _str_blnGrid, "Boolean", 
                    o.blnGrid == null ? "" : o.blnGrid.ToString(),                  
                  o.IsReadOnly(_str_blnGrid), o.IsInvisible(_str_blnGrid), o.IsRequired(_str_blnGrid)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intOrder, _formname = _str_intOrder, _type = "Int32?",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intOrder != newval) o.intOrder = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, o.ObjectIdent2 + _str_intOrder, o.ObjectIdent3 + _str_intOrder, "Int32?", 
                    o.intOrder == null ? "" : o.intOrder.ToString(),                  
                  o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnIsRealStruct, _formname = _str_blnIsRealStruct, _type = "Boolean?",
              _get_func = o => o.blnIsRealStruct,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnIsRealStruct != newval) o.blnIsRealStruct = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnIsRealStruct != c.blnIsRealStruct || o.IsRIRPropChanged(_str_blnIsRealStruct, c)) 
                  m.Add(_str_blnIsRealStruct, o.ObjectIdent + _str_blnIsRealStruct, o.ObjectIdent2 + _str_blnIsRealStruct, o.ObjectIdent3 + _str_blnIsRealStruct, "Boolean?", 
                    o.blnIsRealStruct == null ? "" : o.blnIsRealStruct.ToString(),                  
                  o.IsReadOnly(_str_blnIsRealStruct), o.IsInvisible(_str_blnIsRealStruct), o.IsRequired(_str_blnIsRealStruct)); 
                  }
              }, 
        
            new field_info {
              _name = _str_IsFixedStubSection, _formname = _str_IsFixedStubSection, _type = "bool",
              _get_func = o => o.IsFixedStubSection,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.IsFixedStubSection != c.IsFixedStubSection || o.IsRIRPropChanged(_str_IsFixedStubSection, c)) {
                  m.Add(_str_IsFixedStubSection, o.ObjectIdent + _str_IsFixedStubSection, o.ObjectIdent2 + _str_IsFixedStubSection, o.ObjectIdent3 + _str_IsFixedStubSection, "bool", o.IsFixedStubSection == null ? "" : o.IsFixedStubSection.ToString(), o.IsReadOnly(_str_IsFixedStubSection), o.IsInvisible(_str_IsFixedStubSection), o.IsRequired(_str_IsFixedStubSection));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Section, _formname = _str_Section, _type = "Lookup",
              _get_func = o => { if (o.Section == null) return null; return o.Section.idfsSection; },
              _set_func = (o, val) => { o.Section = o.SectionLookup.Where(c => c.idfsSection.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Section, c);
                if (o.idfsSection != c.idfsSection || o.IsRIRPropChanged(_str_Section, c) || bChangeLookupContent) {
                  m.Add(_str_Section, o.ObjectIdent + _str_Section, o.ObjectIdent2 + _str_Section, o.ObjectIdent3 + _str_Section, "Lookup", o.idfsSection == null ? "" : o.idfsSection.ToString(), o.IsReadOnly(_str_Section), o.IsInvisible(_str_Section), o.IsRequired(_str_Section),
                  bChangeLookupContent ? o.SectionLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Section + "Lookup", _formname = _str_Section + "Lookup", _type = "LookupContent",
              _get_func = o => o.SectionLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_ParentSection, _formname = _str_ParentSection, _type = "Lookup",
              _get_func = o => { if (o.ParentSection == null) return null; return o.ParentSection.idfsSection; },
              _set_func = (o, val) => { o.ParentSection = o.ParentSectionLookup.Where(c => c.idfsSection.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_ParentSection, c);
                if (o.idfsParentSection != c.idfsParentSection || o.IsRIRPropChanged(_str_ParentSection, c) || bChangeLookupContent) {
                  m.Add(_str_ParentSection, o.ObjectIdent + _str_ParentSection, o.ObjectIdent2 + _str_ParentSection, o.ObjectIdent3 + _str_ParentSection, "Lookup", o.idfsParentSection == null ? "" : o.idfsParentSection.ToString(), o.IsReadOnly(_str_ParentSection), o.IsInvisible(_str_ParentSection), o.IsRequired(_str_ParentSection),
                  bChangeLookupContent ? o.ParentSectionLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_ParentSection + "Lookup", _formname = _str_ParentSection + "Lookup", _type = "LookupContent",
              _get_func = o => o.ParentSectionLookup,
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
            SectionTemplate obj = (SectionTemplate)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Section)]
        [Relation(typeof(Section), eidss.model.Schema.Section._str_idfsSection, _str_idfsSection)]
        public Section Section
        {
            get { return _Section; }
            set 
            { 
                var oldVal = _Section;
                _Section = value;
                if (_Section != oldVal)
                {
                    if (idfsSection != (_Section == null
                            ? new Int64()
                            : (Int64)_Section.idfsSection))
                        idfsSection = _Section == null 
                            ? new Int64()
                            : (Int64)_Section.idfsSection; 
                    OnPropertyChanged(_str_Section); 
                }
            }
        }
        private Section _Section;

        
        public List<Section> SectionLookup
        {
            get { return _SectionLookup; }
        }
        private List<Section> _SectionLookup = new List<Section>();
            
        [LocalizedDisplayName(_str_ParentSection)]
        [Relation(typeof(Section), eidss.model.Schema.Section._str_idfsSection, _str_idfsParentSection)]
        public Section ParentSection
        {
            get { return _ParentSection; }
            set 
            { 
                var oldVal = _ParentSection;
                _ParentSection = value;
                if (_ParentSection != oldVal)
                {
                    if (idfsParentSection != (_ParentSection == null
                            ? new Int64?()
                            : (Int64?)_ParentSection.idfsSection))
                        idfsParentSection = _ParentSection == null 
                            ? new Int64?()
                            : (Int64?)_ParentSection.idfsSection; 
                    OnPropertyChanged(_str_ParentSection); 
                }
            }
        }
        private Section _ParentSection;

        
        public List<Section> ParentSectionLookup
        {
            get { return _ParentSectionLookup; }
        }
        private List<Section> _ParentSectionLookup = new List<Section>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Section:
                    return new BvSelectList(SectionLookup, eidss.model.Schema.Section._str_idfsSection, null, Section, _str_idfsSection);
            
                case _str_ParentSection:
                    return new BvSelectList(ParentSectionLookup, eidss.model.Schema.Section._str_idfsSection, null, ParentSection, _str_idfsParentSection);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsFixedStubSection)]
        public bool IsFixedStubSection
        {
            get { return new Func<SectionTemplate, bool>(c => true)(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "SectionTemplate";

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
            var ret = base.Clone() as SectionTemplate;
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
            var ret = base.Clone() as SectionTemplate;
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
        public SectionTemplate CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as SectionTemplate;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsSection; } }
        public string KeyName { get { return "idfsSection"; } }
        public object KeyLookup { get { return idfsSection; } }
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
        
            var _prev_idfsSection_Section = idfsSection;
            var _prev_idfsParentSection_ParentSection = idfsParentSection;
            base.RejectChanges();
        
            if (_prev_idfsSection_Section != idfsSection)
            {
                _Section = _SectionLookup.FirstOrDefault(c => c.idfsSection == idfsSection);
            }
            if (_prev_idfsParentSection_ParentSection != idfsParentSection)
            {
                _ParentSection = _ParentSectionLookup.FirstOrDefault(c => c.idfsSection == idfsParentSection);
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

        private bool IsRIRPropChanged(string fld, SectionTemplate c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, SectionTemplate c)
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
        

      

        public SectionTemplate()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SectionTemplate_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(SectionTemplate_PropertyChanged);
        }
        private void SectionTemplate_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as SectionTemplate).Changed(e.PropertyName);
            
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
            SectionTemplate obj = this;
            
        }
        private void _DeletedExtenders()
        {
            SectionTemplate obj = this;
            
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


        internal Dictionary<string, Func<SectionTemplate, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<SectionTemplate, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<SectionTemplate, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<SectionTemplate, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<SectionTemplate, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<SectionTemplate, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<SectionTemplate, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~SectionTemplate()
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
                
                LookupManager.RemoveObject("Section", this);
                
                LookupManager.RemoveObject("Section", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "Section")
                _getAccessor().LoadLookup_Section(manager, this);
            
            if (lookup_object == "Section")
                _getAccessor().LoadLookup_ParentSection(manager, this);
            
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
        : DataAccessor<SectionTemplate>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<SectionTemplate>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsSection"; } }
            #endregion
        
            public delegate void on_action(SectionTemplate obj);
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
            private Section.Accessor SectionAccessor { get { return eidss.model.Schema.Section.Accessor.Instance(m_CS); } }
            private Section.Accessor ParentSectionAccessor { get { return eidss.model.Schema.Section.Accessor.Instance(m_CS); } }
            
            public virtual List<SectionTemplate> SelectLookupList(DbManagerProxy manager
                , Int64? idfsSection
                , Int64? idfsFormTemplate
                )
            {
                return _SelectList(manager
                    , idfsSection
                    , idfsFormTemplate
                    , null, null
                    );
            }
            
            public virtual List<SectionTemplate> SelectList(DbManagerProxy manager
                , Int64? idfsSection
                , Int64? idfsFormTemplate
                )
            {
                return _SelectList(manager
                    , idfsSection
                    , idfsFormTemplate
                    , delegate(SectionTemplate obj)
                        {
                        }
                    , delegate(SectionTemplate obj)
                        {
                        }
                    );
            }

            

            public List<SectionTemplate> _SelectList(DbManagerProxy manager
                , Int64? idfsSection
                , Int64? idfsFormTemplate
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfsSection
                    , idfsFormTemplate
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            [InstanceCache(typeof(BvCacheAspect))]
            public virtual List<SectionTemplate> _SelectListInternal(DbManagerProxy manager
                , Int64? idfsSection
                , Int64? idfsFormTemplate
                , on_action loading, on_action loaded
                )
            {
                SectionTemplate _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<SectionTemplate> objs = new List<SectionTemplate>();
                    sets[0] = new MapResultSet(typeof(SectionTemplate), objs);
                    
                    manager
                        .SetSpCommand("spFFGetSectionTemplate"
                            , manager.Parameter("@idfsSection", idfsSection)
                            , manager.Parameter("@idfsFormTemplate", idfsFormTemplate)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, SectionTemplate obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, SectionTemplate obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private SectionTemplate _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                SectionTemplate obj = null;
                try
                {
                    obj = SectionTemplate.CreateInstance();
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

            
            public SectionTemplate CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public SectionTemplate CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public SectionTemplate CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(SectionTemplate obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(SectionTemplate obj)
            {
                
            }
    
            public void LoadLookup_Section(DbManagerProxy manager, SectionTemplate obj)
            {
                
                obj.SectionLookup.Clear();
                
                obj.SectionLookup.AddRange(SectionAccessor.SelectLookupList(manager
                    
                    , new Func<SectionTemplate, Int64?>(c => null)(obj)
                            
                    , new Func<SectionTemplate, Int64?>(c => c.idfsSection)(obj)
                            
                    , new Func<SectionTemplate, Int64?>(c => null)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSection == obj.idfsSection))
                    
                    .ToList());
                
                if (obj.idfsSection != 0)
                {
                    obj.Section = obj.SectionLookup
                        .SingleOrDefault(c => c.idfsSection == obj.idfsSection);
                    
                }
              
                LookupManager.AddObject("Section", obj, SectionAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_ParentSection(DbManagerProxy manager, SectionTemplate obj)
            {
                
                obj.ParentSectionLookup.Clear();
                
                obj.ParentSectionLookup.AddRange(ParentSectionAccessor.SelectLookupList(manager
                    
                    , new Func<SectionTemplate, Int64?>(c => null)(obj)
                            
                    , new Func<SectionTemplate, Int64?>(c => c.idfsParentSection)(obj)
                            
                    , new Func<SectionTemplate, Int64?>(c => null)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSection == obj.idfsParentSection))
                    
                    .ToList());
                
                if (obj.idfsParentSection != null && obj.idfsParentSection != 0)
                {
                    obj.ParentSection = obj.ParentSectionLookup
                        .SingleOrDefault(c => c.idfsSection == obj.idfsParentSection);
                    
                }
              
                LookupManager.AddObject("Section", obj, ParentSectionAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, SectionTemplate obj)
            {
                
                LoadLookup_Section(manager, obj);
                
                LoadLookup_ParentSection(manager, obj);
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(SectionTemplate obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(SectionTemplate obj, bool bRethrowException)
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
                return Validate(manager, obj as SectionTemplate, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, SectionTemplate obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(SectionTemplate obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(SectionTemplate obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as SectionTemplate) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as SectionTemplate) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "SectionTemplateDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFFGetSectionTemplate";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<SectionTemplate, bool>> RequiredByField = new Dictionary<string, Func<SectionTemplate, bool>>();
            public static Dictionary<string, Func<SectionTemplate, bool>> RequiredByProperty = new Dictionary<string, Func<SectionTemplate, bool>>();
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
                
                Sizes.Add(_str_DefaultName, 2000);
                Sizes.Add(_str_NationalName, 2000);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<SectionTemplate>().Post(manager, (SectionTemplate)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<SectionTemplate>().Post(manager, (SectionTemplate)c), c),
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
                    (manager, c, pars) => new ActResult(((SectionTemplate)c).MarkToDelete() && ObjectAccessor.PostInterface<SectionTemplate>().Post(manager, (SectionTemplate)c), c),
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
	