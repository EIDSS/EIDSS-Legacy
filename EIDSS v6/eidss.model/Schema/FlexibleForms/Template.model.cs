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
            internal Action<Template, Template, CompareModel> _compare_func;
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
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
                if (o.langid != c.langid || o.IsRIRPropChanged(_str_langid, c)) 
                  m.Add(_str_langid, o.ObjectIdent + _str_langid, o.ObjectIdent2 + _str_langid, o.ObjectIdent3 + _str_langid, "String", 
                    o.langid == null ? "" : o.langid.ToString(),                  
                  o.IsReadOnly(_str_langid), o.IsInvisible(_str_langid), o.IsRequired(_str_langid)); 
                  }
              }, 
        
            new field_info {
              _name = _str_SectionTemplates, _formname = _str_SectionTemplates, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.SectionTemplates.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.SectionTemplates.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.SectionTemplates.Count != c.SectionTemplates.Count || o.IsReadOnly(_str_SectionTemplates) != c.IsReadOnly(_str_SectionTemplates) || o.IsInvisible(_str_SectionTemplates) != c.IsInvisible(_str_SectionTemplates) || o.IsRequired(_str_SectionTemplates) != c._isRequired(o.m_isRequired, _str_SectionTemplates)) {
                  m.Add(_str_SectionTemplates, o.ObjectIdent + _str_SectionTemplates, o.ObjectIdent2 + _str_SectionTemplates, o.ObjectIdent3 + _str_SectionTemplates, "Child", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_SectionTemplates), o.IsInvisible(_str_SectionTemplates), o.IsRequired(_str_SectionTemplates)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_ParameterTemplates, _formname = _str_ParameterTemplates, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.ParameterTemplates.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.ParameterTemplates.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.ParameterTemplates.Count != c.ParameterTemplates.Count || o.IsReadOnly(_str_ParameterTemplates) != c.IsReadOnly(_str_ParameterTemplates) || o.IsInvisible(_str_ParameterTemplates) != c.IsInvisible(_str_ParameterTemplates) || o.IsRequired(_str_ParameterTemplates) != c._isRequired(o.m_isRequired, _str_ParameterTemplates)) {
                  m.Add(_str_ParameterTemplates, o.ObjectIdent + _str_ParameterTemplates, o.ObjectIdent2 + _str_ParameterTemplates, o.ObjectIdent3 + _str_ParameterTemplates, "Child", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_ParameterTemplates), o.IsInvisible(_str_ParameterTemplates), o.IsRequired(_str_ParameterTemplates)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Labels, _formname = _str_Labels, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Labels.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Labels.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.Labels.Count != c.Labels.Count || o.IsReadOnly(_str_Labels) != c.IsReadOnly(_str_Labels) || o.IsInvisible(_str_Labels) != c.IsInvisible(_str_Labels) || o.IsRequired(_str_Labels) != c._isRequired(o.m_isRequired, _str_Labels)) {
                  m.Add(_str_Labels, o.ObjectIdent + _str_Labels, o.ObjectIdent2 + _str_Labels, o.ObjectIdent3 + _str_Labels, "Child", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_Labels), o.IsInvisible(_str_Labels), o.IsRequired(_str_Labels)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Lines, _formname = _str_Lines, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Lines.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Lines.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.Lines.Count != c.Lines.Count || o.IsReadOnly(_str_Lines) != c.IsReadOnly(_str_Lines) || o.IsInvisible(_str_Lines) != c.IsInvisible(_str_Lines) || o.IsRequired(_str_Lines) != c._isRequired(o.m_isRequired, _str_Lines)) {
                  m.Add(_str_Lines, o.ObjectIdent + _str_Lines, o.ObjectIdent2 + _str_Lines, o.ObjectIdent3 + _str_Lines, "Child", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_Lines), o.IsInvisible(_str_Lines), o.IsRequired(_str_Lines)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Rules, _formname = _str_Rules, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Rules.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Rules.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.Rules.Count != c.Rules.Count || o.IsReadOnly(_str_Rules) != c.IsReadOnly(_str_Rules) || o.IsInvisible(_str_Rules) != c.IsInvisible(_str_Rules) || o.IsRequired(_str_Rules) != c._isRequired(o.m_isRequired, _str_Rules)) {
                  m.Add(_str_Rules, o.ObjectIdent + _str_Rules, o.ObjectIdent2 + _str_Rules, o.ObjectIdent3 + _str_Rules, "Child", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_Rules), o.IsInvisible(_str_Rules), o.IsRequired(_str_Rules)); 
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
            Template obj = (Template)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_SectionTemplates)]
        [Relation(typeof(SectionTemplate), eidss.model.Schema.SectionTemplate._str_idfsFormTemplate, _str_idfsFormTemplate)]
        public EditableList<SectionTemplate> SectionTemplates
        {
            get 
            {   
                if (!_SectionTemplatesLoaded)
                {
                    _SectionTemplatesLoaded = true;
                    _getAccessor()._LoadSectionTemplates(this);
                    _SectionTemplates.ForEach(c => { c.Parent = this; });
                }
                return _SectionTemplates; 
            }
            set 
            {
                _SectionTemplates = value;
            }
        }
        protected EditableList<SectionTemplate> _SectionTemplates = new EditableList<SectionTemplate>();
                    
        private bool _SectionTemplatesLoaded = false;
                    
        [LocalizedDisplayName(_str_ParameterTemplates)]
        [Relation(typeof(ParameterTemplate), eidss.model.Schema.ParameterTemplate._str_idfsFormTemplate, _str_idfsFormTemplate)]
        public EditableList<ParameterTemplate> ParameterTemplates
        {
            get 
            {   
                if (!_ParameterTemplatesLoaded)
                {
                    _ParameterTemplatesLoaded = true;
                    _getAccessor()._LoadParameterTemplates(this);
                    _ParameterTemplates.ForEach(c => { c.Parent = this; });
                }
                return _ParameterTemplates; 
            }
            set 
            {
                _ParameterTemplates = value;
            }
        }
        protected EditableList<ParameterTemplate> _ParameterTemplates = new EditableList<ParameterTemplate>();
                    
        private bool _ParameterTemplatesLoaded = false;
                    
        [LocalizedDisplayName(_str_Labels)]
        [Relation(typeof(Label), eidss.model.Schema.Label._str_idfsFormTemplate, _str_idfsFormTemplate)]
        public EditableList<Label> Labels
        {
            get 
            {   
                if (!_LabelsLoaded)
                {
                    _LabelsLoaded = true;
                    _getAccessor()._LoadLabels(this);
                    _Labels.ForEach(c => { c.Parent = this; });
                }
                return _Labels; 
            }
            set 
            {
                _Labels = value;
            }
        }
        protected EditableList<Label> _Labels = new EditableList<Label>();
                    
        private bool _LabelsLoaded = false;
                    
        [LocalizedDisplayName(_str_Lines)]
        [Relation(typeof(Line), eidss.model.Schema.Line._str_idfsFormTemplate, _str_idfsFormTemplate)]
        public EditableList<Line> Lines
        {
            get 
            {   
                if (!_LinesLoaded)
                {
                    _LinesLoaded = true;
                    _getAccessor()._LoadLines(this);
                    _Lines.ForEach(c => { c.Parent = this; });
                }
                return _Lines; 
            }
            set 
            {
                _Lines = value;
            }
        }
        protected EditableList<Line> _Lines = new EditableList<Line>();
                    
        private bool _LinesLoaded = false;
                    
        [LocalizedDisplayName(_str_Rules)]
        [Relation(typeof(Rule), eidss.model.Schema.Rule._str_idfsFormTemplate, _str_idfsFormTemplate)]
        public EditableList<Rule> Rules
        {
            get 
            {   
                if (!_RulesLoaded)
                {
                    _RulesLoaded = true;
                    _getAccessor()._LoadRules(this);
                    _Rules.ForEach(c => { c.Parent = this; });
                }
                return _Rules; 
            }
            set 
            {
                _Rules = value;
            }
        }
        protected EditableList<Rule> _Rules = new EditableList<Rule>();
                    
        private bool _RulesLoaded = false;
                    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
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
        SectionTemplates.ForEach(c => { c.Parent = this; });
                ParameterTemplates.ForEach(c => { c.Parent = this; });
                Labels.ForEach(c => { c.Parent = this; });
                Lines.ForEach(c => { c.Parent = this; });
                Rules.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as Template;
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
        
            if (_SectionTemplates != null && _SectionTemplates.Count > 0)
            {
              ret.SectionTemplates.Clear();
              _SectionTemplates.ForEach(c => ret.SectionTemplates.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_ParameterTemplates != null && _ParameterTemplates.Count > 0)
            {
              ret.ParameterTemplates.Clear();
              _ParameterTemplates.ForEach(c => ret.ParameterTemplates.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_Labels != null && _Labels.Count > 0)
            {
              ret.Labels.Clear();
              _Labels.ForEach(c => ret.Labels.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_Lines != null && _Lines.Count > 0)
            {
              ret.Lines.Clear();
              _Lines.ForEach(c => ret.Lines.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_Rules != null && _Rules.Count > 0)
            {
              ret.Rules.Clear();
              _Rules.ForEach(c => ret.Rules.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
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
        
                    || SectionTemplates.IsDirty
                    || SectionTemplates.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || ParameterTemplates.IsDirty
                    || ParameterTemplates.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Labels.IsDirty
                    || Labels.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Lines.IsDirty
                    || Lines.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Rules.IsDirty
                    || Rules.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
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
        SectionTemplates.DeepRejectChanges();
                ParameterTemplates.DeepRejectChanges();
                Labels.DeepRejectChanges();
                Lines.DeepRejectChanges();
                Rules.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        SectionTemplates.DeepAcceptChanges();
                ParameterTemplates.DeepAcceptChanges();
                Labels.DeepAcceptChanges();
                Lines.DeepAcceptChanges();
                Rules.DeepAcceptChanges();
                
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
        SectionTemplates.ForEach(c => c.SetChange());
                ParameterTemplates.ForEach(c => c.SetChange());
                Labels.ForEach(c => c.SetChange());
                Lines.ForEach(c => c.SetChange());
                Rules.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, Template c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public Template()
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
        
                foreach(var o in _SectionTemplates)
                    o.ReadOnly |= value;
                
                foreach(var o in _ParameterTemplates)
                    o.ReadOnly |= value;
                
                foreach(var o in _Labels)
                    o.ReadOnly |= value;
                
                foreach(var o in _Lines)
                    o.ReadOnly |= value;
                
                foreach(var o in _Rules)
                    o.ReadOnly |= value;
                
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
        ~Template()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                SectionTemplates.ForEach(c => c.Dispose());
                ParameterTemplates.ForEach(c => c.Dispose());
                Labels.ForEach(c => c.Dispose());
                Lines.ForEach(c => c.Dispose());
                Rules.ForEach(c => c.Dispose());
                
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
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            if (_SectionTemplates != null) _SectionTemplates.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_ParameterTemplates != null) _ParameterTemplates.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Labels != null) _Labels.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Lines != null) _Lines.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Rules != null) _Rules.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
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
            
            , IObjectSelectDetail
            , IObjectSelectDetail<Template>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsFormTemplate"; } }
            #endregion
        
            private delegate void on_action(Template obj);
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
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null
                            
                        , null, null
                        );
                }
            }
            public virtual Template SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null
                            
                        , null, null
                        );
                }
            }

            
            public virtual Template SelectByKey(DbManagerProxy manager
                , Int64? idfsFormTemplate
                , Int64? idfsFormType
                )
            {
                return _SelectByKey(manager
                    , idfsFormTemplate
                    , idfsFormType
                    , null, null
                    );
            }
            
      
            private Template _SelectByKey(DbManagerProxy manager
                , Int64? idfsFormTemplate
                , Int64? idfsFormType
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<Template> objs = new List<Template>();
                sets[0] = new MapResultSet(typeof(Template), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spFFGetTemplates"
                            , manager.Parameter("@idfsFormTemplate", idfsFormTemplate)
                            , manager.Parameter("@idfsFormType", idfsFormType)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    Template obj = objs[0];
                    obj.m_CS = m_CS;
                    
                    if (loading != null)
                        loading(obj);
                    _SetupLoad(manager, obj);
                    
                    //obj._setParent();
                    if (loaded != null)
                        loaded(obj);
                    obj.Loaded(manager);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(e);
                }
                
            }
    
            private void _SetupAddChildHandlerSectionTemplates(Template obj)
            {
                obj.SectionTemplates.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerParameterTemplates(Template obj)
            {
                obj.ParameterTemplates.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerLabels(Template obj)
            {
                obj.Labels.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerLines(Template obj)
            {
                obj.Lines.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerRules(Template obj)
            {
                obj.Rules.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadSectionTemplates(Template obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSectionTemplates(manager, obj);
                }
            }
            internal void _LoadSectionTemplates(DbManagerProxy manager, Template obj)
            {
                
                obj.SectionTemplates.Clear();
                obj.SectionTemplates.AddRange(SectionTemplatesAccessor.SelectDetailList(manager
                    
                    , new Func<Template, Int64?>(c => null)(obj)
                    
                    , new Func<Template, Int64?>(c => c.idfsFormTemplate)(obj)
                    
                    ));
                obj.SectionTemplates.ForEach(c => c.m_ObjectName = _str_SectionTemplates);
                obj.SectionTemplates.AcceptChanges();
                    
            }
            
            internal void _LoadParameterTemplates(Template obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadParameterTemplates(manager, obj);
                }
            }
            internal void _LoadParameterTemplates(DbManagerProxy manager, Template obj)
            {
                
                obj.ParameterTemplates.Clear();
                obj.ParameterTemplates.AddRange(ParameterTemplatesAccessor.SelectDetailList(manager
                    
                    , new Func<Template, Int64?>(c => null)(obj)
                    
                    , new Func<Template, Int64?>(c => c.idfsFormTemplate)(obj)
                    
                    ));
                obj.ParameterTemplates.ForEach(c => c.m_ObjectName = _str_ParameterTemplates);
                obj.ParameterTemplates.AcceptChanges();
                    
            }
            
            internal void _LoadLabels(Template obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadLabels(manager, obj);
                }
            }
            internal void _LoadLabels(DbManagerProxy manager, Template obj)
            {
                
                obj.Labels.Clear();
                obj.Labels.AddRange(LabelsAccessor.SelectDetailList(manager
                    
                    , new Func<Template, Int64?>(c => c.idfsFormTemplate)(obj)
                    
                    ));
                obj.Labels.ForEach(c => c.m_ObjectName = _str_Labels);
                obj.Labels.AcceptChanges();
                    
            }
            
            internal void _LoadLines(Template obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadLines(manager, obj);
                }
            }
            internal void _LoadLines(DbManagerProxy manager, Template obj)
            {
                
                obj.Lines.Clear();
                obj.Lines.AddRange(LinesAccessor.SelectDetailList(manager
                    
                    , new Func<Template, Int64?>(c => c.idfsFormTemplate)(obj)
                    
                    ));
                obj.Lines.ForEach(c => c.m_ObjectName = _str_Lines);
                obj.Lines.AcceptChanges();
                    
            }
            
            internal void _LoadRules(Template obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadRules(manager, obj);
                }
            }
            internal void _LoadRules(DbManagerProxy manager, Template obj)
            {
                
                obj.Rules.Clear();
                obj.Rules.AddRange(RulesAccessor.SelectDetailList(manager
                    
                    , new Func<Template, Int64?>(c => c.idfsFormTemplate)(obj)
                    
                    ));
                obj.Rules.ForEach(c => c.m_ObjectName = _str_Rules);
                obj.Rules.AcceptChanges();
                    
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
                
                _SetupAddChildHandlerSectionTemplates(obj);
                
                _SetupAddChildHandlerParameterTemplates(obj);
                
                _SetupAddChildHandlerLabels(obj);
                
                _SetupAddChildHandlerLines(obj);
                
                _SetupAddChildHandlerRules(obj);
                
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
                    
                        obj.SectionTemplates.ForEach(c => SectionTemplatesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.ParameterTemplates.ForEach(c => ParameterTemplatesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Labels.ForEach(c => LabelsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Lines.ForEach(c => LinesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Rules.ForEach(c => RulesAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private Template _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    Template obj = Template.CreateInstance();
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
                    
                    _SetupAddChildHandlerSectionTemplates(obj);
                    
                    _SetupAddChildHandlerParameterTemplates(obj);
                    
                    _SetupAddChildHandlerLabels(obj);
                    
                    _SetupAddChildHandlerLines(obj);
                    
                    _SetupAddChildHandlerRules(obj);
                    
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
    

            private void _LoadLookups(DbManagerProxy manager, Template obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
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
            internal Action<AddParameterWindowItem, AddParameterWindowItem, CompareModel> _compare_func;
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
              _compare_func = (o, c, m) => {
              
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
              _compare_func = (o, c, m) => {
              
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
              _compare_func = (o, c, m) => {
              
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
              _compare_func = (o, c, m) => {
              
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
              _compare_func = (o, c, m) => {
              
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
              _compare_func = (o, c, m) => {
              
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
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
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
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
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
        public override object Clone()
        {
            var ret = base.Clone() as AddParameterWindowItem;
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

        private bool IsRIRPropChanged(string fld, AddParameterWindowItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public AddParameterWindowItem()
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

    
        private static string[] readonly_names1 = "blnNeedCopyGeneralData".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AddParameterWindowItem, bool>(c => true)(this);
            
            return ReadOnly || new Func<AddParameterWindowItem, bool>(c => c.ReadOnly)(this);
                
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
        ~AddParameterWindowItem()
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
            
            , IObjectSelectDetail
            , IObjectSelectDetail<AddParameterWindowItem>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "ID"; } }
            #endregion
        
            private delegate void on_action(AddParameterWindowItem obj);
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
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null
                            
                        , null, null
                        );
                }
            }
            public virtual AddParameterWindowItem SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null
                            
                        , null, null
                        );
                }
            }

            
            public virtual AddParameterWindowItem SelectByKey(DbManagerProxy manager
                , Int64? idfsFormTemplate
                , Int64? idfsFormType
                )
            {
                return _SelectByKey(manager
                    , idfsFormTemplate
                    , idfsFormType
                    , null, null
                    );
            }
            
      
            private AddParameterWindowItem _SelectByKey(DbManagerProxy manager
                , Int64? idfsFormTemplate
                , Int64? idfsFormType
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
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
                try
                {
                    AddParameterWindowItem obj = AddParameterWindowItem.CreateInstance();
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
                    throw DbModelException.Create(e);
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
    

            private void _LoadLookups(DbManagerProxy manager, AddParameterWindowItem obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
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
	