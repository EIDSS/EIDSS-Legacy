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
        #if MONO
        protected Int64? idfsFormType_Original { get { return idfsFormType; } }
        protected Int64? idfsFormType_Previous { get { return idfsFormType; } }
        #else
        protected Int64? idfsFormType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormType).OriginalValue; } }
        protected Int64? idfsFormType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnUNI)]
        [MapField(_str_blnUNI)]
        public abstract Boolean blnUNI { get; set; }
        #if MONO
        protected Boolean blnUNI_Original { get { return blnUNI; } }
        protected Boolean blnUNI_Previous { get { return blnUNI; } }
        #else
        protected Boolean blnUNI_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnUNI).OriginalValue; } }
        protected Boolean blnUNI_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnUNI).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_rowguid)]
        [MapField(_str_rowguid)]
        public abstract Guid rowguid { get; set; }
        #if MONO
        protected Guid rowguid_Original { get { return rowguid; } }
        protected Guid rowguid_Previous { get { return rowguid; } }
        #else
        protected Guid rowguid_Original { get { return ((EditableValue<Guid>)((dynamic)this)._rowguid).OriginalValue; } }
        protected Guid rowguid_Previous { get { return ((EditableValue<Guid>)((dynamic)this)._rowguid).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intRowStatus)]
        [MapField(_str_intRowStatus)]
        public abstract Int32 intRowStatus { get; set; }
        #if MONO
        protected Int32 intRowStatus_Original { get { return intRowStatus; } }
        protected Int32 intRowStatus_Previous { get { return intRowStatus; } }
        #else
        protected Int32 intRowStatus_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).OriginalValue; } }
        protected Int32 intRowStatus_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strNote)]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        #if MONO
        protected String strNote_Original { get { return strNote; } }
        protected String strNote_Previous { get { return strNote; } }
        #else
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_NationalLongName)]
        [MapField(_str_NationalLongName)]
        public abstract String NationalLongName { get; set; }
        #if MONO
        protected String NationalLongName_Original { get { return NationalLongName; } }
        protected String NationalLongName_Previous { get { return NationalLongName; } }
        #else
        protected String NationalLongName_Original { get { return ((EditableValue<String>)((dynamic)this)._nationalLongName).OriginalValue; } }
        protected String NationalLongName_Previous { get { return ((EditableValue<String>)((dynamic)this)._nationalLongName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_langid)]
        [MapField(_str_langid)]
        public abstract String langid { get; set; }
        #if MONO
        protected String langid_Original { get { return langid; } }
        protected String langid_Previous { get { return langid; } }
        #else
        protected String langid_Original { get { return ((EditableValue<String>)((dynamic)this)._langid).OriginalValue; } }
        protected String langid_Previous { get { return ((EditableValue<String>)((dynamic)this)._langid).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
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
        internal const string _str_FormType = "FormType";
        internal const string _str_SectionTemplates = "SectionTemplates";
        internal const string _str_ParameterTemplates = "ParameterTemplates";
        internal const string _str_Labels = "Labels";
        internal const string _str_Lines = "Lines";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfsFormTemplate, _type = "Int64",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { o.idfsFormTemplate = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, "Int64", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); }
              }, 
        
            new field_info {
              _name = _str_idfsFormType, _type = "Int64?",
              _get_func = o => o.idfsFormType,
              _set_func = (o, val) => { o.idfsFormType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsFormType != c.idfsFormType || o.IsRIRPropChanged(_str_idfsFormType, c)) 
                  m.Add(_str_idfsFormType, o.ObjectIdent + _str_idfsFormType, "Int64?", o.idfsFormType == null ? "" : o.idfsFormType.ToString(), o.IsReadOnly(_str_idfsFormType), o.IsInvisible(_str_idfsFormType), o.IsRequired(_str_idfsFormType)); }
              }, 
        
            new field_info {
              _name = _str_blnUNI, _type = "Boolean",
              _get_func = o => o.blnUNI,
              _set_func = (o, val) => { o.blnUNI = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
                if (o.blnUNI != c.blnUNI || o.IsRIRPropChanged(_str_blnUNI, c)) 
                  m.Add(_str_blnUNI, o.ObjectIdent + _str_blnUNI, "Boolean", o.blnUNI == null ? "" : o.blnUNI.ToString(), o.IsReadOnly(_str_blnUNI), o.IsInvisible(_str_blnUNI), o.IsRequired(_str_blnUNI)); }
              }, 
        
            new field_info {
              _name = _str_rowguid, _type = "Guid",
              _get_func = o => o.rowguid,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
                if (o.rowguid != c.rowguid || o.IsRIRPropChanged(_str_rowguid, c)) 
                  m.Add(_str_rowguid, o.ObjectIdent + _str_rowguid, "Guid", o.rowguid == null ? "" : o.rowguid.ToString(), o.IsReadOnly(_str_rowguid), o.IsInvisible(_str_rowguid), o.IsRequired(_str_rowguid)); }
              }, 
        
            new field_info {
              _name = _str_intRowStatus, _type = "Int32",
              _get_func = o => o.intRowStatus,
              _set_func = (o, val) => { o.intRowStatus = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intRowStatus != c.intRowStatus || o.IsRIRPropChanged(_str_intRowStatus, c)) 
                  m.Add(_str_intRowStatus, o.ObjectIdent + _str_intRowStatus, "Int32", o.intRowStatus == null ? "" : o.intRowStatus.ToString(), o.IsReadOnly(_str_intRowStatus), o.IsInvisible(_str_intRowStatus), o.IsRequired(_str_intRowStatus)); }
              }, 
        
            new field_info {
              _name = _str_strNote, _type = "String",
              _get_func = o => o.strNote,
              _set_func = (o, val) => { o.strNote = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNote != c.strNote || o.IsRIRPropChanged(_str_strNote, c)) 
                  m.Add(_str_strNote, o.ObjectIdent + _str_strNote, "String", o.strNote == null ? "" : o.strNote.ToString(), o.IsReadOnly(_str_strNote), o.IsInvisible(_str_strNote), o.IsRequired(_str_strNote)); }
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
              _name = _str_NationalLongName, _type = "String",
              _get_func = o => o.NationalLongName,
              _set_func = (o, val) => { o.NationalLongName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.NationalLongName != c.NationalLongName || o.IsRIRPropChanged(_str_NationalLongName, c)) 
                  m.Add(_str_NationalLongName, o.ObjectIdent + _str_NationalLongName, "String", o.NationalLongName == null ? "" : o.NationalLongName.ToString(), o.IsReadOnly(_str_NationalLongName), o.IsInvisible(_str_NationalLongName), o.IsRequired(_str_NationalLongName)); }
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
              _name = _str_SectionTemplates, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.SectionTemplates.Count != c.SectionTemplates.Count || o.IsReadOnly(_str_SectionTemplates) != c.IsReadOnly(_str_SectionTemplates) || o.IsInvisible(_str_SectionTemplates) != c.IsInvisible(_str_SectionTemplates) || o.IsRequired(_str_SectionTemplates) != c.IsRequired(_str_SectionTemplates)) 
                  m.Add(_str_SectionTemplates, o.ObjectIdent + _str_SectionTemplates, "Child", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_SectionTemplates), o.IsInvisible(_str_SectionTemplates), o.IsRequired(_str_SectionTemplates)); }
              }, 
        
            new field_info {
              _name = _str_ParameterTemplates, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.ParameterTemplates.Count != c.ParameterTemplates.Count || o.IsReadOnly(_str_ParameterTemplates) != c.IsReadOnly(_str_ParameterTemplates) || o.IsInvisible(_str_ParameterTemplates) != c.IsInvisible(_str_ParameterTemplates) || o.IsRequired(_str_ParameterTemplates) != c.IsRequired(_str_ParameterTemplates)) 
                  m.Add(_str_ParameterTemplates, o.ObjectIdent + _str_ParameterTemplates, "Child", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_ParameterTemplates), o.IsInvisible(_str_ParameterTemplates), o.IsRequired(_str_ParameterTemplates)); }
              }, 
        
            new field_info {
              _name = _str_Labels, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Labels.Count != c.Labels.Count || o.IsReadOnly(_str_Labels) != c.IsReadOnly(_str_Labels) || o.IsInvisible(_str_Labels) != c.IsInvisible(_str_Labels) || o.IsRequired(_str_Labels) != c.IsRequired(_str_Labels)) 
                  m.Add(_str_Labels, o.ObjectIdent + _str_Labels, "Child", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_Labels), o.IsInvisible(_str_Labels), o.IsRequired(_str_Labels)); }
              }, 
        
            new field_info {
              _name = _str_Lines, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Lines.Count != c.Lines.Count || o.IsReadOnly(_str_Lines) != c.IsReadOnly(_str_Lines) || o.IsInvisible(_str_Lines) != c.IsInvisible(_str_Lines) || o.IsRequired(_str_Lines) != c.IsRequired(_str_Lines)) 
                  m.Add(_str_Lines, o.ObjectIdent + _str_Lines, "Child", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_Lines), o.IsInvisible(_str_Lines), o.IsRequired(_str_Lines)); }
              }, 
        
            new field_info {
              _name = _str_FormType, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.FormType != null) o.FormType._compare(c.FormType, m); }
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
                        ? new Int64?()
                        : _FormType.idfsFormType;
                
            }
        }
        protected FormType _FormType;
                    
        private bool _FormTypeLoaded = false;
                    
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
        
            if (_FormType != null) { _FormType.Parent = this; }
                SectionTemplates.ForEach(c => { c.Parent = this; });
                ParameterTemplates.ForEach(c => { c.Parent = this; });
                Labels.ForEach(c => { c.Parent = this; });
                Lines.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as Template;
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
            var ret = base.Clone() as Template;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_FormType != null)
              ret.FormType = _FormType.CloneWithSetup(manager) as FormType;
                
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
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
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || (_FormType != null && _FormType.HasChanges)
                
                    || SectionTemplates.IsDirty
                    || SectionTemplates.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || ParameterTemplates.IsDirty
                    || ParameterTemplates.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Labels.IsDirty
                    || Labels.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Lines.IsDirty
                    || Lines.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
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
                SectionTemplates.RejectChanges();
                ParameterTemplates.RejectChanges();
                Labels.RejectChanges();
                Lines.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_FormType != null) _FormType.AcceptChanges();
                SectionTemplates.AcceptChanges();
                ParameterTemplates.AcceptChanges();
                Labels.AcceptChanges();
                Lines.AcceptChanges();
                
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
                SectionTemplates.ForEach(c => c.SetChange());
                ParameterTemplates.ForEach(c => c.SetChange());
                Labels.ForEach(c => c.SetChange());
                Lines.ForEach(c => c.SetChange());
                
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

      private bool IsRIRPropChanged(string fld, Template c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public Template()
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
                
                foreach(var o in _SectionTemplates)
                    o.ReadOnly = value;
                
                foreach(var o in _ParameterTemplates)
                    o.ReadOnly = value;
                
                foreach(var o in _Labels)
                    o.ReadOnly = value;
                
                foreach(var o in _Lines)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<Template, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Template, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Template, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<Template, bool>> m_isHiddenPersonalData;
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
                
            if (_SectionTemplates != null) _SectionTemplates.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_ParameterTemplates != null) _ParameterTemplates.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Labels != null) _Labels.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Lines != null) _Lines.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<Template>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
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
            private FormType.Accessor FormTypeAccessor { get { return eidss.model.Schema.FormType.Accessor.Instance(m_CS); } }
            private SectionTemplate.Accessor SectionTemplatesAccessor { get { return eidss.model.Schema.SectionTemplate.Accessor.Instance(m_CS); } }
            private ParameterTemplate.Accessor ParameterTemplatesAccessor { get { return eidss.model.Schema.ParameterTemplate.Accessor.Instance(m_CS); } }
            private Label.Accessor LabelsAccessor { get { return eidss.model.Schema.Label.Accessor.Instance(m_CS); } }
            private Line.Accessor LinesAccessor { get { return eidss.model.Schema.Line.Accessor.Instance(m_CS); } }
            [InstanceCache(typeof(BvCacheAspect))]

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

            [InstanceCache(typeof(BvCacheAspect))]
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
            
            internal void _LoadFormType(Template obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFormType(manager, obj);
                }
            }
            internal void _LoadFormType(DbManagerProxy manager, Template obj)
            {
                
                if (obj.FormType == null && obj.idfsFormType != null && obj.idfsFormType != 0)
                {
                    obj.FormType = FormTypeAccessor.SelectByKey(manager
                        
                        , obj.idfsFormType.Value
                        );
                    if (obj.FormType != null)
                    {
                        obj.FormType.m_ObjectName = _str_FormType;
                    }
                }
                    
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
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, Template obj)
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
                
                _SetupAddChildHandlerSectionTemplates(obj);
                
                _SetupAddChildHandlerParameterTemplates(obj);
                
                _SetupAddChildHandlerLabels(obj);
                
                _SetupAddChildHandlerLines(obj);
                
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
                    FormTypeAccessor._SetPermitions(obj._permissions, obj.FormType);
                    
                        obj.SectionTemplates.ForEach(c => SectionTemplatesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.ParameterTemplates.ForEach(c => ParameterTemplatesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Labels.ForEach(c => LabelsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Lines.ForEach(c => LinesAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private Template _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
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
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as Template, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Template obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	