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
    public abstract partial class Template : 
        EditableObject<Template>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsFormTemplate), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsFormTemplate { get; set; }
                
        [LocalizedDisplayName(_str_idfsFormType)]
        [MapField(_str_idfsFormType)]
        public abstract Int64? idfsFormType { get; set; }
        protected Int64? idfsFormType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormType).OriginalValue; } }
        protected Int64? idfsFormType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnUNI)]
        [MapField(_str_blnUNI)]
        public abstract Boolean blnUNI { get; set; }
        protected Boolean blnUNI_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnUNI).OriginalValue; } }
        protected Boolean blnUNI_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnUNI).PreviousValue; } }
                
        [LocalizedDisplayName(_str_rowguid)]
        [MapField(_str_rowguid)]
        public abstract Guid rowguid { get; set; }
        protected Guid rowguid_Original { get { return ((EditableValue<Guid>)((dynamic)this)._rowguid).OriginalValue; } }
        protected Guid rowguid_Previous { get { return ((EditableValue<Guid>)((dynamic)this)._rowguid).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intRowStatus)]
        [MapField(_str_intRowStatus)]
        public abstract Int32 intRowStatus { get; set; }
        protected Int32 intRowStatus_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).OriginalValue; } }
        protected Int32 intRowStatus_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strNote)]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
                
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
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<Template, object> _get_func;
            internal Action<Template, string> _set_func;
            internal Action<Template, Template, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_idfsFormType = "idfsFormType";
        internal const string _str_blnUNI = "blnUNI";
        internal const string _str_rowguid = "rowguid";
        internal const string _str_intRowStatus = "intRowStatus";
        internal const string _str_strNote = "strNote";
        internal const string _str_DefaultName = "DefaultName";
        internal const string _str_NationalName = "NationalName";
        internal const string _str_NationalLongName = "NationalLongName";
        internal const string _str_langid = "langid";
        internal const string _str_idfsSectionDummy = "idfsSectionDummy";
        internal const string _str_idfsParameterDummy = "idfsParameterDummy";
        internal const string _str_idfsLabelDummy = "idfsLabelDummy";
        internal const string _str_idfsLineDummy = "idfsLineDummy";
        internal const string _str_idfsRuleDummy = "idfsRuleDummy";
        internal const string _str_SectionTemplates = "SectionTemplates";
        internal const string _str_ParameterTemplates = "ParameterTemplates";
        internal const string _str_Labels = "Labels";
        internal const string _str_Lines = "Lines";
        internal const string _str_Rules = "Rules";
        private static readonly field_info[] _field_infos =
        {
                  
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
              _name = _str_idfsFormType, _formname = _str_idfsFormType, _type = "Int64?",
              _get_func = o => o.idfsFormType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsFormType != newval) o.idfsFormType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsFormType != c.idfsFormType || o.IsRIRPropChanged(_str_idfsFormType, c)) 
                  m.Add(_str_idfsFormType, o.ObjectIdent + _str_idfsFormType, o.ObjectIdent2 + _str_idfsFormType, o.ObjectIdent3 + _str_idfsFormType, "Int64?", 
                    o.idfsFormType == null ? "" : o.idfsFormType.ToString(),                  
                  o.IsReadOnly(_str_idfsFormType), o.IsInvisible(_str_idfsFormType), o.IsRequired(_str_idfsFormType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnUNI, _formname = _str_blnUNI, _type = "Boolean",
              _get_func = o => o.blnUNI,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnUNI != newval) o.blnUNI = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnUNI != c.blnUNI || o.IsRIRPropChanged(_str_blnUNI, c)) 
                  m.Add(_str_blnUNI, o.ObjectIdent + _str_blnUNI, o.ObjectIdent2 + _str_blnUNI, o.ObjectIdent3 + _str_blnUNI, "Boolean", 
                    o.blnUNI == null ? "" : o.blnUNI.ToString(),                  
                  o.IsReadOnly(_str_blnUNI), o.IsInvisible(_str_blnUNI), o.IsRequired(_str_blnUNI)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_rowguid, _formname = _str_rowguid, _type = "Guid",
              _get_func = o => o.rowguid,
              _set_func = (o, val) => { var newval = o.rowguid; if (o.rowguid != newval) o.rowguid = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.rowguid != c.rowguid || o.IsRIRPropChanged(_str_rowguid, c)) 
                  m.Add(_str_rowguid, o.ObjectIdent + _str_rowguid, o.ObjectIdent2 + _str_rowguid, o.ObjectIdent3 + _str_rowguid, "Guid", 
                    o.rowguid == null ? "" : o.rowguid.ToString(),                  
                  o.IsReadOnly(_str_rowguid), o.IsInvisible(_str_rowguid), o.IsRequired(_str_rowguid)); 
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
              _name = _str_idfsSectionDummy, _formname = _str_idfsSectionDummy, _type = "long?",
              _get_func = o => o.idfsSectionDummy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSectionDummy != newval) o.idfsSectionDummy = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsSectionDummy != c.idfsSectionDummy || o.IsRIRPropChanged(_str_idfsSectionDummy, c)) {
                  m.Add(_str_idfsSectionDummy, o.ObjectIdent + _str_idfsSectionDummy, o.ObjectIdent2 + _str_idfsSectionDummy, o.ObjectIdent3 + _str_idfsSectionDummy,  "long?", 
                    o.idfsSectionDummy == null ? "" : o.idfsSectionDummy.ToString(),                  
                    o.IsReadOnly(_str_idfsSectionDummy), o.IsInvisible(_str_idfsSectionDummy), o.IsRequired(_str_idfsSectionDummy));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsParameterDummy, _formname = _str_idfsParameterDummy, _type = "long?",
              _get_func = o => o.idfsParameterDummy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsParameterDummy != newval) o.idfsParameterDummy = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsParameterDummy != c.idfsParameterDummy || o.IsRIRPropChanged(_str_idfsParameterDummy, c)) {
                  m.Add(_str_idfsParameterDummy, o.ObjectIdent + _str_idfsParameterDummy, o.ObjectIdent2 + _str_idfsParameterDummy, o.ObjectIdent3 + _str_idfsParameterDummy,  "long?", 
                    o.idfsParameterDummy == null ? "" : o.idfsParameterDummy.ToString(),                  
                    o.IsReadOnly(_str_idfsParameterDummy), o.IsInvisible(_str_idfsParameterDummy), o.IsRequired(_str_idfsParameterDummy));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsLabelDummy, _formname = _str_idfsLabelDummy, _type = "long?",
              _get_func = o => o.idfsLabelDummy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsLabelDummy != newval) o.idfsLabelDummy = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsLabelDummy != c.idfsLabelDummy || o.IsRIRPropChanged(_str_idfsLabelDummy, c)) {
                  m.Add(_str_idfsLabelDummy, o.ObjectIdent + _str_idfsLabelDummy, o.ObjectIdent2 + _str_idfsLabelDummy, o.ObjectIdent3 + _str_idfsLabelDummy,  "long?", 
                    o.idfsLabelDummy == null ? "" : o.idfsLabelDummy.ToString(),                  
                    o.IsReadOnly(_str_idfsLabelDummy), o.IsInvisible(_str_idfsLabelDummy), o.IsRequired(_str_idfsLabelDummy));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsLineDummy, _formname = _str_idfsLineDummy, _type = "long?",
              _get_func = o => o.idfsLineDummy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsLineDummy != newval) o.idfsLineDummy = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsLineDummy != c.idfsLineDummy || o.IsRIRPropChanged(_str_idfsLineDummy, c)) {
                  m.Add(_str_idfsLineDummy, o.ObjectIdent + _str_idfsLineDummy, o.ObjectIdent2 + _str_idfsLineDummy, o.ObjectIdent3 + _str_idfsLineDummy,  "long?", 
                    o.idfsLineDummy == null ? "" : o.idfsLineDummy.ToString(),                  
                    o.IsReadOnly(_str_idfsLineDummy), o.IsInvisible(_str_idfsLineDummy), o.IsRequired(_str_idfsLineDummy));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsRuleDummy, _formname = _str_idfsRuleDummy, _type = "long?",
              _get_func = o => o.idfsRuleDummy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsRuleDummy != newval) o.idfsRuleDummy = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsRuleDummy != c.idfsRuleDummy || o.IsRIRPropChanged(_str_idfsRuleDummy, c)) {
                  m.Add(_str_idfsRuleDummy, o.ObjectIdent + _str_idfsRuleDummy, o.ObjectIdent2 + _str_idfsRuleDummy, o.ObjectIdent3 + _str_idfsRuleDummy,  "long?", 
                    o.idfsRuleDummy == null ? "" : o.idfsRuleDummy.ToString(),                  
                    o.IsReadOnly(_str_idfsRuleDummy), o.IsInvisible(_str_idfsRuleDummy), o.IsRequired(_str_idfsRuleDummy));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_SectionTemplates, _formname = _str_SectionTemplates, _type = "Lookup",
              _get_func = o => { if (o.SectionTemplates == null) return null; return o.SectionTemplates.idfsSection; },
              _set_func = (o, val) => { o.SectionTemplates = o.SectionTemplatesLookup.Where(c => c.idfsSection.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_SectionTemplates, c);
                if (o.idfsSectionDummy != c.idfsSectionDummy || o.IsRIRPropChanged(_str_SectionTemplates, c) || bChangeLookupContent) {
                  m.Add(_str_SectionTemplates, o.ObjectIdent + _str_SectionTemplates, o.ObjectIdent2 + _str_SectionTemplates, o.ObjectIdent3 + _str_SectionTemplates, "Lookup", o.idfsSectionDummy == null ? "" : o.idfsSectionDummy.ToString(), o.IsReadOnly(_str_SectionTemplates), o.IsInvisible(_str_SectionTemplates), o.IsRequired(_str_SectionTemplates),
                  bChangeLookupContent ? o.SectionTemplatesLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_SectionTemplates + "Lookup", _formname = _str_SectionTemplates + "Lookup", _type = "LookupContent",
              _get_func = o => o.SectionTemplatesLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_ParameterTemplates, _formname = _str_ParameterTemplates, _type = "Lookup",
              _get_func = o => { if (o.ParameterTemplates == null) return null; return o.ParameterTemplates.idfsParameter; },
              _set_func = (o, val) => { o.ParameterTemplates = o.ParameterTemplatesLookup.Where(c => c.idfsParameter.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_ParameterTemplates, c);
                if (o.idfsParameterDummy != c.idfsParameterDummy || o.IsRIRPropChanged(_str_ParameterTemplates, c) || bChangeLookupContent) {
                  m.Add(_str_ParameterTemplates, o.ObjectIdent + _str_ParameterTemplates, o.ObjectIdent2 + _str_ParameterTemplates, o.ObjectIdent3 + _str_ParameterTemplates, "Lookup", o.idfsParameterDummy == null ? "" : o.idfsParameterDummy.ToString(), o.IsReadOnly(_str_ParameterTemplates), o.IsInvisible(_str_ParameterTemplates), o.IsRequired(_str_ParameterTemplates),
                  bChangeLookupContent ? o.ParameterTemplatesLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_ParameterTemplates + "Lookup", _formname = _str_ParameterTemplates + "Lookup", _type = "LookupContent",
              _get_func = o => o.ParameterTemplatesLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Labels, _formname = _str_Labels, _type = "Lookup",
              _get_func = o => { if (o.Labels == null) return null; return o.Labels.idfDecorElement; },
              _set_func = (o, val) => { o.Labels = o.LabelsLookup.Where(c => c.idfDecorElement.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Labels, c);
                if (o.idfsLabelDummy != c.idfsLabelDummy || o.IsRIRPropChanged(_str_Labels, c) || bChangeLookupContent) {
                  m.Add(_str_Labels, o.ObjectIdent + _str_Labels, o.ObjectIdent2 + _str_Labels, o.ObjectIdent3 + _str_Labels, "Lookup", o.idfsLabelDummy == null ? "" : o.idfsLabelDummy.ToString(), o.IsReadOnly(_str_Labels), o.IsInvisible(_str_Labels), o.IsRequired(_str_Labels),
                  bChangeLookupContent ? o.LabelsLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Labels + "Lookup", _formname = _str_Labels + "Lookup", _type = "LookupContent",
              _get_func = o => o.LabelsLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Lines, _formname = _str_Lines, _type = "Lookup",
              _get_func = o => { if (o.Lines == null) return null; return o.Lines.idfDecorElement; },
              _set_func = (o, val) => { o.Lines = o.LinesLookup.Where(c => c.idfDecorElement.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Lines, c);
                if (o.idfsLineDummy != c.idfsLineDummy || o.IsRIRPropChanged(_str_Lines, c) || bChangeLookupContent) {
                  m.Add(_str_Lines, o.ObjectIdent + _str_Lines, o.ObjectIdent2 + _str_Lines, o.ObjectIdent3 + _str_Lines, "Lookup", o.idfsLineDummy == null ? "" : o.idfsLineDummy.ToString(), o.IsReadOnly(_str_Lines), o.IsInvisible(_str_Lines), o.IsRequired(_str_Lines),
                  bChangeLookupContent ? o.LinesLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Lines + "Lookup", _formname = _str_Lines + "Lookup", _type = "LookupContent",
              _get_func = o => o.LinesLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Rules, _formname = _str_Rules, _type = "Lookup",
              _get_func = o => { if (o.Rules == null) return null; return o.Rules.idfsRule; },
              _set_func = (o, val) => { o.Rules = o.RulesLookup.Where(c => c.idfsRule.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Rules, c);
                if (o.idfsRuleDummy != c.idfsRuleDummy || o.IsRIRPropChanged(_str_Rules, c) || bChangeLookupContent) {
                  m.Add(_str_Rules, o.ObjectIdent + _str_Rules, o.ObjectIdent2 + _str_Rules, o.ObjectIdent3 + _str_Rules, "Lookup", o.idfsRuleDummy == null ? "" : o.idfsRuleDummy.ToString(), o.IsReadOnly(_str_Rules), o.IsInvisible(_str_Rules), o.IsRequired(_str_Rules),
                  bChangeLookupContent ? o.RulesLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Rules + "Lookup", _formname = _str_Rules + "Lookup", _type = "LookupContent",
              _get_func = o => o.RulesLookup,
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
            Template obj = (Template)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_SectionTemplates)]
        [Relation(typeof(SectionTemplate), eidss.model.Schema.SectionTemplate._str_idfsSection, _str_idfsSectionDummy)]
        public SectionTemplate SectionTemplates
        {
            get { return _SectionTemplates; }
            set 
            { 
                var oldVal = _SectionTemplates;
                _SectionTemplates = value;
                if (_SectionTemplates != oldVal)
                {
                    if (idfsSectionDummy != (_SectionTemplates == null
                            ? new long?()
                            : _SectionTemplates.idfsSection))
                        idfsSectionDummy = _SectionTemplates == null 
                            ? new long?()
                            : _SectionTemplates.idfsSection; 
                    OnPropertyChanged(_str_SectionTemplates); 
                }
            }
        }
        private SectionTemplate _SectionTemplates;

        
        public List<SectionTemplate> SectionTemplatesLookup
        {
            get { return _SectionTemplatesLookup; }
        }
        private List<SectionTemplate> _SectionTemplatesLookup = new List<SectionTemplate>();
            
        [LocalizedDisplayName(_str_ParameterTemplates)]
        [Relation(typeof(ParameterTemplate), eidss.model.Schema.ParameterTemplate._str_idfsParameter, _str_idfsParameterDummy)]
        public ParameterTemplate ParameterTemplates
        {
            get { return _ParameterTemplates; }
            set 
            { 
                var oldVal = _ParameterTemplates;
                _ParameterTemplates = value;
                if (_ParameterTemplates != oldVal)
                {
                    if (idfsParameterDummy != (_ParameterTemplates == null
                            ? new long?()
                            : _ParameterTemplates.idfsParameter))
                        idfsParameterDummy = _ParameterTemplates == null 
                            ? new long?()
                            : _ParameterTemplates.idfsParameter; 
                    OnPropertyChanged(_str_ParameterTemplates); 
                }
            }
        }
        private ParameterTemplate _ParameterTemplates;

        
        public List<ParameterTemplate> ParameterTemplatesLookup
        {
            get { return _ParameterTemplatesLookup; }
        }
        private List<ParameterTemplate> _ParameterTemplatesLookup = new List<ParameterTemplate>();
            
        [LocalizedDisplayName(_str_Labels)]
        [Relation(typeof(Label), eidss.model.Schema.Label._str_idfDecorElement, _str_idfsLabelDummy)]
        public Label Labels
        {
            get { return _Labels; }
            set 
            { 
                var oldVal = _Labels;
                _Labels = value;
                if (_Labels != oldVal)
                {
                    if (idfsLabelDummy != (_Labels == null
                            ? new long?()
                            : _Labels.idfDecorElement))
                        idfsLabelDummy = _Labels == null 
                            ? new long?()
                            : _Labels.idfDecorElement; 
                    OnPropertyChanged(_str_Labels); 
                }
            }
        }
        private Label _Labels;

        
        public List<Label> LabelsLookup
        {
            get { return _LabelsLookup; }
        }
        private List<Label> _LabelsLookup = new List<Label>();
            
        [LocalizedDisplayName(_str_Lines)]
        [Relation(typeof(Line), eidss.model.Schema.Line._str_idfDecorElement, _str_idfsLineDummy)]
        public Line Lines
        {
            get { return _Lines; }
            set 
            { 
                var oldVal = _Lines;
                _Lines = value;
                if (_Lines != oldVal)
                {
                    if (idfsLineDummy != (_Lines == null
                            ? new long?()
                            : _Lines.idfDecorElement))
                        idfsLineDummy = _Lines == null 
                            ? new long?()
                            : _Lines.idfDecorElement; 
                    OnPropertyChanged(_str_Lines); 
                }
            }
        }
        private Line _Lines;

        
        public List<Line> LinesLookup
        {
            get { return _LinesLookup; }
        }
        private List<Line> _LinesLookup = new List<Line>();
            
        [LocalizedDisplayName(_str_Rules)]
        [Relation(typeof(Rule), eidss.model.Schema.Rule._str_idfsRule, _str_idfsRuleDummy)]
        public Rule Rules
        {
            get { return _Rules; }
            set 
            { 
                var oldVal = _Rules;
                _Rules = value;
                if (_Rules != oldVal)
                {
                    if (idfsRuleDummy != (_Rules == null
                            ? new long?()
                            : _Rules.idfsRule))
                        idfsRuleDummy = _Rules == null 
                            ? new long?()
                            : _Rules.idfsRule; 
                    OnPropertyChanged(_str_Rules); 
                }
            }
        }
        private Rule _Rules;

        
        public List<Rule> RulesLookup
        {
            get { return _RulesLookup; }
        }
        private List<Rule> _RulesLookup = new List<Rule>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_SectionTemplates:
                    return new BvSelectList(SectionTemplatesLookup, eidss.model.Schema.SectionTemplate._str_idfsSection, null, SectionTemplates, _str_idfsSectionDummy);
            
                case _str_ParameterTemplates:
                    return new BvSelectList(ParameterTemplatesLookup, eidss.model.Schema.ParameterTemplate._str_idfsParameter, null, ParameterTemplates, _str_idfsParameterDummy);
            
                case _str_Labels:
                    return new BvSelectList(LabelsLookup, eidss.model.Schema.Label._str_idfDecorElement, null, Labels, _str_idfsLabelDummy);
            
                case _str_Lines:
                    return new BvSelectList(LinesLookup, eidss.model.Schema.Line._str_idfDecorElement, null, Lines, _str_idfsLineDummy);
            
                case _str_Rules:
                    return new BvSelectList(RulesLookup, eidss.model.Schema.Rule._str_idfsRule, null, Rules, _str_idfsRuleDummy);
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str_idfsSectionDummy)]
        public long? idfsSectionDummy
        {
            get { return m_idfsSectionDummy; }
            set { if (m_idfsSectionDummy != value) { m_idfsSectionDummy = value; OnPropertyChanged(_str_idfsSectionDummy); } }
        }
        private long? m_idfsSectionDummy;
        
          [LocalizedDisplayName(_str_idfsParameterDummy)]
        public long? idfsParameterDummy
        {
            get { return m_idfsParameterDummy; }
            set { if (m_idfsParameterDummy != value) { m_idfsParameterDummy = value; OnPropertyChanged(_str_idfsParameterDummy); } }
        }
        private long? m_idfsParameterDummy;
        
          [LocalizedDisplayName(_str_idfsLabelDummy)]
        public long? idfsLabelDummy
        {
            get { return m_idfsLabelDummy; }
            set { if (m_idfsLabelDummy != value) { m_idfsLabelDummy = value; OnPropertyChanged(_str_idfsLabelDummy); } }
        }
        private long? m_idfsLabelDummy;
        
          [LocalizedDisplayName(_str_idfsLineDummy)]
        public long? idfsLineDummy
        {
            get { return m_idfsLineDummy; }
            set { if (m_idfsLineDummy != value) { m_idfsLineDummy = value; OnPropertyChanged(_str_idfsLineDummy); } }
        }
        private long? m_idfsLineDummy;
        
          [LocalizedDisplayName(_str_idfsRuleDummy)]
        public long? idfsRuleDummy
        {
            get { return m_idfsRuleDummy; }
            set { if (m_idfsRuleDummy != value) { m_idfsRuleDummy = value; OnPropertyChanged(_str_idfsRuleDummy); } }
        }
        private long? m_idfsRuleDummy;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "Template";

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
            var ret = base.Clone() as Template;
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
            var ret = base.Clone() as Template;
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
        public Template CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Template;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsFormTemplate; } }
        public string KeyName { get { return "idfsFormTemplate"; } }
        public object KeyLookup { get { return idfsFormTemplate; } }
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
        
            var _prev_idfsSectionDummy_SectionTemplates = idfsSectionDummy;
            var _prev_idfsParameterDummy_ParameterTemplates = idfsParameterDummy;
            var _prev_idfsLabelDummy_Labels = idfsLabelDummy;
            var _prev_idfsLineDummy_Lines = idfsLineDummy;
            var _prev_idfsRuleDummy_Rules = idfsRuleDummy;
            base.RejectChanges();
        
            if (_prev_idfsSectionDummy_SectionTemplates != idfsSectionDummy)
            {
                _SectionTemplates = _SectionTemplatesLookup.FirstOrDefault(c => c.idfsSection == idfsSectionDummy);
            }
            if (_prev_idfsParameterDummy_ParameterTemplates != idfsParameterDummy)
            {
                _ParameterTemplates = _ParameterTemplatesLookup.FirstOrDefault(c => c.idfsParameter == idfsParameterDummy);
            }
            if (_prev_idfsLabelDummy_Labels != idfsLabelDummy)
            {
                _Labels = _LabelsLookup.FirstOrDefault(c => c.idfDecorElement == idfsLabelDummy);
            }
            if (_prev_idfsLineDummy_Lines != idfsLineDummy)
            {
                _Lines = _LinesLookup.FirstOrDefault(c => c.idfDecorElement == idfsLineDummy);
            }
            if (_prev_idfsRuleDummy_Rules != idfsRuleDummy)
            {
                _Rules = _RulesLookup.FirstOrDefault(c => c.idfsRule == idfsRuleDummy);
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

        private bool IsRIRPropChanged(string fld, Template c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, Template c)
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
        

      

        public Template()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Template_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Template_PropertyChanged);
        }
        private void Template_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Template).Changed(e.PropertyName);
            
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
            Template obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Template obj = this;
            
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


        internal Dictionary<string, Func<Template, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<Template, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Template, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Template, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<Template, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<Template, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<Template, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~Template()
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
                
                LookupManager.RemoveObject("SectionTemplate", this);
                
                LookupManager.RemoveObject("ParameterTemplate", this);
                
                LookupManager.RemoveObject("Label", this);
                
                LookupManager.RemoveObject("Line", this);
                
                LookupManager.RemoveObject("Rule", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "SectionTemplate")
                _getAccessor().LoadLookup_SectionTemplates(manager, this);
            
            if (lookup_object == "ParameterTemplate")
                _getAccessor().LoadLookup_ParameterTemplates(manager, this);
            
            if (lookup_object == "Label")
                _getAccessor().LoadLookup_Labels(manager, this);
            
            if (lookup_object == "Line")
                _getAccessor().LoadLookup_Lines(manager, this);
            
            if (lookup_object == "Rule")
                _getAccessor().LoadLookup_Rules(manager, this);
            
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
        : DataAccessor<Template>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<Template>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsFormTemplate"; } }
            #endregion
        
            public delegate void on_action(Template obj);
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
            private SectionTemplate.Accessor SectionTemplatesAccessor { get { return eidss.model.Schema.SectionTemplate.Accessor.Instance(m_CS); } }
            private ParameterTemplate.Accessor ParameterTemplatesAccessor { get { return eidss.model.Schema.ParameterTemplate.Accessor.Instance(m_CS); } }
            private Label.Accessor LabelsAccessor { get { return eidss.model.Schema.Label.Accessor.Instance(m_CS); } }
            private Line.Accessor LinesAccessor { get { return eidss.model.Schema.Line.Accessor.Instance(m_CS); } }
            private Rule.Accessor RulesAccessor { get { return eidss.model.Schema.Rule.Accessor.Instance(m_CS); } }
            
            public virtual List<Template> SelectLookupList(DbManagerProxy manager
                , Int64? idfsFormTemplate
                , Int64? idfsFormType
                )
            {
                return _SelectList(manager
                    , idfsFormTemplate
                    , idfsFormType
                    , null, null
                    );
            }
            
            public virtual List<Template> SelectList(DbManagerProxy manager
                , Int64? idfsFormTemplate
                , Int64? idfsFormType
                )
            {
                return _SelectList(manager
                    , idfsFormTemplate
                    , idfsFormType
                    , delegate(Template obj)
                        {
                        }
                    , delegate(Template obj)
                        {
                        }
                    );
            }

            

            public List<Template> _SelectList(DbManagerProxy manager
                , Int64? idfsFormTemplate
                , Int64? idfsFormType
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfsFormTemplate
                    , idfsFormType
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            [InstanceCache(typeof(BvCacheAspect))]
            public virtual List<Template> _SelectListInternal(DbManagerProxy manager
                , Int64? idfsFormTemplate
                , Int64? idfsFormType
                , on_action loading, on_action loaded
                )
            {
                Template _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<Template> objs = new List<Template>();
                    sets[0] = new MapResultSet(typeof(Template), objs);
                    
                    manager
                        .SetSpCommand("spFFGetTemplates"
                            , manager.Parameter("@idfsFormTemplate", idfsFormTemplate)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, Template obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, Template obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private Template _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                Template obj = null;
                try
                {
                    obj = Template.CreateInstance();
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

            
            public Template CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public Template CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public Template CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(Template obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Template obj)
            {
                
            }
    
            public void LoadLookup_SectionTemplates(DbManagerProxy manager, Template obj)
            {
                
                obj.SectionTemplatesLookup.Clear();
                
                obj.SectionTemplatesLookup.AddRange(SectionTemplatesAccessor.SelectLookupList(manager
                    
                    , new Func<Template, Int64?>(c => null)(obj)
                            
                    , new Func<Template, Int64?>(c => c.idfsFormTemplate)(obj)
                            
                    )
                    .ToList());
                
                if (obj.idfsSectionDummy != null && obj.idfsSectionDummy != 0)
                {
                    obj.SectionTemplates = obj.SectionTemplatesLookup
                        .SingleOrDefault(c => c.idfsSection == obj.idfsSectionDummy);
                    
                }
              
                LookupManager.AddObject("SectionTemplate", obj, SectionTemplatesAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_ParameterTemplates(DbManagerProxy manager, Template obj)
            {
                
                obj.ParameterTemplatesLookup.Clear();
                
                obj.ParameterTemplatesLookup.AddRange(ParameterTemplatesAccessor.SelectLookupList(manager
                    
                    , new Func<Template, Int64?>(c => null)(obj)
                            
                    , new Func<Template, Int64?>(c => c.idfsFormTemplate)(obj)
                            
                    )
                    .ToList());
                
                if (obj.idfsParameterDummy != null && obj.idfsParameterDummy != 0)
                {
                    obj.ParameterTemplates = obj.ParameterTemplatesLookup
                        .SingleOrDefault(c => c.idfsParameter == obj.idfsParameterDummy);
                    
                }
              
                LookupManager.AddObject("ParameterTemplate", obj, ParameterTemplatesAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Labels(DbManagerProxy manager, Template obj)
            {
                
                obj.LabelsLookup.Clear();
                
                obj.LabelsLookup.AddRange(LabelsAccessor.SelectLookupList(manager
                    
                    , new Func<Template, Int64>(c => c.idfsFormTemplate)(obj)
                            
                    )
                    .ToList());
                
                if (obj.idfsLabelDummy != null && obj.idfsLabelDummy != 0)
                {
                    obj.Labels = obj.LabelsLookup
                        .SingleOrDefault(c => c.idfDecorElement == obj.idfsLabelDummy);
                    
                }
              
                LookupManager.AddObject("Label", obj, LabelsAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Lines(DbManagerProxy manager, Template obj)
            {
                
                obj.LinesLookup.Clear();
                
                obj.LinesLookup.AddRange(LinesAccessor.SelectLookupList(manager
                    
                    , new Func<Template, Int64>(c => c.idfsFormTemplate)(obj)
                            
                    )
                    .ToList());
                
                if (obj.idfsLineDummy != null && obj.idfsLineDummy != 0)
                {
                    obj.Lines = obj.LinesLookup
                        .SingleOrDefault(c => c.idfDecorElement == obj.idfsLineDummy);
                    
                }
              
                LookupManager.AddObject("Line", obj, LinesAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Rules(DbManagerProxy manager, Template obj)
            {
                
                obj.RulesLookup.Clear();
                
                obj.RulesLookup.AddRange(RulesAccessor.SelectLookupList(manager
                    
                    , new Func<Template, Int64>(c => c.idfsFormTemplate)(obj)
                            
                    )
                    .ToList());
                
                if (obj.idfsRuleDummy != null && obj.idfsRuleDummy != 0)
                {
                    obj.Rules = obj.RulesLookup
                        .SingleOrDefault(c => c.idfsRule == obj.idfsRuleDummy);
                    
                }
              
                LookupManager.AddObject("Rule", obj, RulesAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, Template obj)
            {
                
                LoadLookup_SectionTemplates(manager, obj);
                
                LoadLookup_ParameterTemplates(manager, obj);
                
                LoadLookup_Labels(manager, obj);
                
                LoadLookup_Lines(manager, obj);
                
                LoadLookup_Rules(manager, obj);
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(Template obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(Template obj, bool bRethrowException)
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
                return Validate(manager, obj as Template, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Template obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(Template obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(Template obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Template) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Template) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "TemplateDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFFGetTemplates";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Template, bool>> RequiredByField = new Dictionary<string, Func<Template, bool>>();
            public static Dictionary<string, Func<Template, bool>> RequiredByProperty = new Dictionary<string, Func<Template, bool>>();
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
                
                Sizes.Add(_str_strNote, 200);
                Sizes.Add(_str_DefaultName, 2000);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Template>().Post(manager, (Template)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Template>().Post(manager, (Template)c), c),
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
                    (manager, c, pars) => new ActResult(((Template)c).MarkToDelete() && ObjectAccessor.PostInterface<Template>().Post(manager, (Template)c), c),
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
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class AddParameterWindowItem : 
        EditableObject<AddParameterWindowItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<AddParameterWindowItem, object> _get_func;
            internal Action<AddParameterWindowItem, string> _set_func;
            internal Action<AddParameterWindowItem, AddParameterWindowItem, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_blnNeedCopyGeneralData = "blnNeedCopyGeneralData";
        internal const string _str_blnNeedCopyFF = "blnNeedCopyFF";
        internal const string _str_blnNeedCopySamples = "blnNeedCopySamples";
        internal const string _str_blnNeedCopyFT = "blnNeedCopyFT";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfVector = "idfVector";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_blnNeedCopyGeneralData, _formname = _str_blnNeedCopyGeneralData, _type = "bool",
              _get_func = o => o.blnNeedCopyGeneralData,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnNeedCopyGeneralData != newval) o.blnNeedCopyGeneralData = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.blnNeedCopyGeneralData != c.blnNeedCopyGeneralData || o.IsRIRPropChanged(_str_blnNeedCopyGeneralData, c)) {
                  m.Add(_str_blnNeedCopyGeneralData, o.ObjectIdent + _str_blnNeedCopyGeneralData, o.ObjectIdent2 + _str_blnNeedCopyGeneralData, o.ObjectIdent3 + _str_blnNeedCopyGeneralData,  "bool", 
                    o.blnNeedCopyGeneralData == null ? "" : o.blnNeedCopyGeneralData.ToString(),                  
                    o.IsReadOnly(_str_blnNeedCopyGeneralData), o.IsInvisible(_str_blnNeedCopyGeneralData), o.IsRequired(_str_blnNeedCopyGeneralData));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_blnNeedCopyFF, _formname = _str_blnNeedCopyFF, _type = "bool",
              _get_func = o => o.blnNeedCopyFF,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnNeedCopyFF != newval) o.blnNeedCopyFF = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.blnNeedCopyFF != c.blnNeedCopyFF || o.IsRIRPropChanged(_str_blnNeedCopyFF, c)) {
                  m.Add(_str_blnNeedCopyFF, o.ObjectIdent + _str_blnNeedCopyFF, o.ObjectIdent2 + _str_blnNeedCopyFF, o.ObjectIdent3 + _str_blnNeedCopyFF,  "bool", 
                    o.blnNeedCopyFF == null ? "" : o.blnNeedCopyFF.ToString(),                  
                    o.IsReadOnly(_str_blnNeedCopyFF), o.IsInvisible(_str_blnNeedCopyFF), o.IsRequired(_str_blnNeedCopyFF));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_blnNeedCopySamples, _formname = _str_blnNeedCopySamples, _type = "bool",
              _get_func = o => o.blnNeedCopySamples,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnNeedCopySamples != newval) o.blnNeedCopySamples = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.blnNeedCopySamples != c.blnNeedCopySamples || o.IsRIRPropChanged(_str_blnNeedCopySamples, c)) {
                  m.Add(_str_blnNeedCopySamples, o.ObjectIdent + _str_blnNeedCopySamples, o.ObjectIdent2 + _str_blnNeedCopySamples, o.ObjectIdent3 + _str_blnNeedCopySamples,  "bool", 
                    o.blnNeedCopySamples == null ? "" : o.blnNeedCopySamples.ToString(),                  
                    o.IsReadOnly(_str_blnNeedCopySamples), o.IsInvisible(_str_blnNeedCopySamples), o.IsRequired(_str_blnNeedCopySamples));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_blnNeedCopyFT, _formname = _str_blnNeedCopyFT, _type = "bool",
              _get_func = o => o.blnNeedCopyFT,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnNeedCopyFT != newval) o.blnNeedCopyFT = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.blnNeedCopyFT != c.blnNeedCopyFT || o.IsRIRPropChanged(_str_blnNeedCopyFT, c)) {
                  m.Add(_str_blnNeedCopyFT, o.ObjectIdent + _str_blnNeedCopyFT, o.ObjectIdent2 + _str_blnNeedCopyFT, o.ObjectIdent3 + _str_blnNeedCopyFT,  "bool", 
                    o.blnNeedCopyFT == null ? "" : o.blnNeedCopyFT.ToString(),                  
                    o.IsReadOnly(_str_blnNeedCopyFT), o.IsInvisible(_str_blnNeedCopyFT), o.IsRequired(_str_blnNeedCopyFT));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _formname = _str_idfVectorSurveillanceSession, _type = "long",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVectorSurveillanceSession != newval) o.idfVectorSurveillanceSession = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) {
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, o.ObjectIdent2 + _str_idfVectorSurveillanceSession, o.ObjectIdent3 + _str_idfVectorSurveillanceSession,  "long", 
                    o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(),                  
                    o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfVector, _formname = _str_idfVector, _type = "long",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVector != newval) o.idfVector = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) {
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, o.ObjectIdent2 + _str_idfVector, o.ObjectIdent3 + _str_idfVector,  "long", 
                    o.idfVector == null ? "" : o.idfVector.ToString(),                  
                    o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_CaseObjectIdent, _formname = _str_CaseObjectIdent, _type = "string",
              _get_func = o => o.CaseObjectIdent,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.CaseObjectIdent != c.CaseObjectIdent || o.IsRIRPropChanged(_str_CaseObjectIdent, c)) {
                  m.Add(_str_CaseObjectIdent, o.ObjectIdent + _str_CaseObjectIdent, o.ObjectIdent2 + _str_CaseObjectIdent, o.ObjectIdent3 + _str_CaseObjectIdent, "string", o.CaseObjectIdent == null ? "" : o.CaseObjectIdent.ToString(), o.IsReadOnly(_str_CaseObjectIdent), o.IsInvisible(_str_CaseObjectIdent), o.IsRequired(_str_CaseObjectIdent));
                  }
                
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
            AddParameterWindowItem obj = (AddParameterWindowItem)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<AddParameterWindowItem, string>(c => "VsSession_" + c.idfVectorSurveillanceSession + "_")(this); }
            
        }
        
          [LocalizedDisplayName(_str_blnNeedCopyGeneralData)]
        public bool blnNeedCopyGeneralData
        {
            get { return m_blnNeedCopyGeneralData; }
            set { if (m_blnNeedCopyGeneralData != value) { m_blnNeedCopyGeneralData = value; OnPropertyChanged(_str_blnNeedCopyGeneralData); } }
        }
        private bool m_blnNeedCopyGeneralData;
        
          [LocalizedDisplayName(_str_blnNeedCopyFF)]
        public bool blnNeedCopyFF
        {
            get { return m_blnNeedCopyFF; }
            set { if (m_blnNeedCopyFF != value) { m_blnNeedCopyFF = value; OnPropertyChanged(_str_blnNeedCopyFF); } }
        }
        private bool m_blnNeedCopyFF;
        
          [LocalizedDisplayName(_str_blnNeedCopySamples)]
        public bool blnNeedCopySamples
        {
            get { return m_blnNeedCopySamples; }
            set { if (m_blnNeedCopySamples != value) { m_blnNeedCopySamples = value; OnPropertyChanged(_str_blnNeedCopySamples); } }
        }
        private bool m_blnNeedCopySamples;
        
          [LocalizedDisplayName(_str_blnNeedCopyFT)]
        public bool blnNeedCopyFT
        {
            get { return m_blnNeedCopyFT; }
            set { if (m_blnNeedCopyFT != value) { m_blnNeedCopyFT = value; OnPropertyChanged(_str_blnNeedCopyFT); } }
        }
        private bool m_blnNeedCopyFT;
        
          [LocalizedDisplayName(_str_idfVectorSurveillanceSession)]
        public long idfVectorSurveillanceSession
        {
            get { return m_idfVectorSurveillanceSession; }
            set { if (m_idfVectorSurveillanceSession != value) { m_idfVectorSurveillanceSession = value; OnPropertyChanged(_str_idfVectorSurveillanceSession); } }
        }
        private long m_idfVectorSurveillanceSession;
        
          [LocalizedDisplayName(_str_idfVector)]
        public long idfVector
        {
            get { return m_idfVector; }
            set { if (m_idfVector != value) { m_idfVector = value; OnPropertyChanged(_str_idfVector); } }
        }
        private long m_idfVector;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AddParameterWindowItem";

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
            var ret = base.Clone() as AddParameterWindowItem;
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
            var ret = base.Clone() as AddParameterWindowItem;
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
        public AddParameterWindowItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AddParameterWindowItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return ID; } }
        public string KeyName { get { return "ID"; } }
        public object KeyLookup { get { return ID; } }
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

        private bool IsRIRPropChanged(string fld, AddParameterWindowItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, AddParameterWindowItem c)
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
        

      

        public AddParameterWindowItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AddParameterWindowItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AddParameterWindowItem_PropertyChanged);
        }
        private void AddParameterWindowItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AddParameterWindowItem).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfVectorSurveillanceSession)
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
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            AddParameterWindowItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AddParameterWindowItem obj = this;
            
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

    
        private static string[] readonly_names1 = "blnNeedCopyGeneralData".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AddParameterWindowItem, bool>(c => true)(this);
            
            return ReadOnly || new Func<AddParameterWindowItem, bool>(c => c.ReadOnly)(this);
                
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


        internal Dictionary<string, Func<AddParameterWindowItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<AddParameterWindowItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AddParameterWindowItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AddParameterWindowItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<AddParameterWindowItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<AddParameterWindowItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<AddParameterWindowItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~AddParameterWindowItem()
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
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
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
        : DataAccessor<AddParameterWindowItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<AddParameterWindowItem>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "ID"; } }
            #endregion
        
            public delegate void on_action(AddParameterWindowItem obj);
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
            
            public virtual List<AddParameterWindowItem> SelectLookupList(DbManagerProxy manager
                , Int64? idfsFormTemplate
                , Int64? idfsFormType
                )
            {
                return _SelectList(manager
                    , idfsFormTemplate
                    , idfsFormType
                    , null, null
                    );
            }
            
            public virtual List<AddParameterWindowItem> SelectList(DbManagerProxy manager
                , Int64? idfsFormTemplate
                , Int64? idfsFormType
                )
            {
                return _SelectList(manager
                    , idfsFormTemplate
                    , idfsFormType
                    , delegate(AddParameterWindowItem obj)
                        {
                        }
                    , delegate(AddParameterWindowItem obj)
                        {
                        }
                    );
            }

            

            public List<AddParameterWindowItem> _SelectList(DbManagerProxy manager
                , Int64? idfsFormTemplate
                , Int64? idfsFormType
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfsFormTemplate
                    , idfsFormType
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            [InstanceCache(typeof(BvCacheAspect))]
            public virtual List<AddParameterWindowItem> _SelectListInternal(DbManagerProxy manager
                , Int64? idfsFormTemplate
                , Int64? idfsFormType
                , on_action loading, on_action loaded
                )
            {
                AddParameterWindowItem _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<AddParameterWindowItem> objs = new List<AddParameterWindowItem>();
                    sets[0] = new MapResultSet(typeof(AddParameterWindowItem), objs);
                    
                    manager
                        .SetSpCommand("spFFGetTemplates"
                            , manager.Parameter("@idfsFormTemplate", idfsFormTemplate)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, AddParameterWindowItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AddParameterWindowItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AddParameterWindowItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                AddParameterWindowItem obj = null;
                try
                {
                    obj = AddParameterWindowItem.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.blnNeedCopyGeneralData = new Func<AddParameterWindowItem, bool>(c => true)(obj);
                obj.blnNeedCopyFF = new Func<AddParameterWindowItem, bool>(c => false)(obj);
                obj.blnNeedCopySamples = new Func<AddParameterWindowItem, bool>(c => false)(obj);
                obj.blnNeedCopyFT = new Func<AddParameterWindowItem, bool>(c => false)(obj);
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

            
            public AddParameterWindowItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public AddParameterWindowItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public AddParameterWindowItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(AddParameterWindowItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AddParameterWindowItem obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, AddParameterWindowItem obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(AddParameterWindowItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(AddParameterWindowItem obj, bool bRethrowException)
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
                return Validate(manager, obj as AddParameterWindowItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AddParameterWindowItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(AddParameterWindowItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(AddParameterWindowItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AddParameterWindowItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AddParameterWindowItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AddParameterWindowItemDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFFGetTemplates";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AddParameterWindowItem, bool>> RequiredByField = new Dictionary<string, Func<AddParameterWindowItem, bool>>();
            public static Dictionary<string, Func<AddParameterWindowItem, bool>> RequiredByProperty = new Dictionary<string, Func<AddParameterWindowItem, bool>>();
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
                
                Actions.Add(new ActionMetaItem(
                    "Ok",
                    ActionTypes.Close,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelect_Id",
                        "",
                        /*from BvMessages*/"tooltipSelect_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      true,
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
                    "Cancel",
                    ActionTypes.Close,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    "vector.vectorDetailCancel",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
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
	