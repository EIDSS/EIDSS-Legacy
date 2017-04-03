﻿#pragma warning disable 0472
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
    public abstract partial class Section : 
        EditableObject<Section>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsSection), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsSection { get; set; }
                
        [LocalizedDisplayName(_str_idfsParentSection)]
        [MapField(_str_idfsParentSection)]
        public abstract Int64? idfsParentSection { get; set; }
        #if MONO
        protected Int64? idfsParentSection_Original { get { return idfsParentSection; } }
        protected Int64? idfsParentSection_Previous { get { return idfsParentSection; } }
        #else
        protected Int64? idfsParentSection_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParentSection).OriginalValue; } }
        protected Int64? idfsParentSection_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParentSection).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_HasParameters)]
        [MapField(_str_HasParameters)]
        public abstract Int32 HasParameters { get; set; }
        #if MONO
        protected Int32 HasParameters_Original { get { return HasParameters; } }
        protected Int32 HasParameters_Previous { get { return HasParameters; } }
        #else
        protected Int32 HasParameters_Original { get { return ((EditableValue<Int32>)((dynamic)this)._hasParameters).OriginalValue; } }
        protected Int32 HasParameters_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._hasParameters).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_HasNestedSections)]
        [MapField(_str_HasNestedSections)]
        public abstract Int32 HasNestedSections { get; set; }
        #if MONO
        protected Int32 HasNestedSections_Original { get { return HasNestedSections; } }
        protected Int32 HasNestedSections_Previous { get { return HasNestedSections; } }
        #else
        protected Int32 HasNestedSections_Original { get { return ((EditableValue<Int32>)((dynamic)this)._hasNestedSections).OriginalValue; } }
        protected Int32 HasNestedSections_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._hasNestedSections).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnGrid)]
        [MapField(_str_blnGrid)]
        public abstract Boolean blnGrid { get; set; }
        #if MONO
        protected Boolean blnGrid_Original { get { return blnGrid; } }
        protected Boolean blnGrid_Previous { get { return blnGrid; } }
        #else
        protected Boolean blnGrid_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnGrid).OriginalValue; } }
        protected Boolean blnGrid_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnGrid).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnFixedRowSet)]
        [MapField(_str_blnFixedRowSet)]
        public abstract Boolean blnFixedRowSet { get; set; }
        #if MONO
        protected Boolean blnFixedRowSet_Original { get { return blnFixedRowSet; } }
        protected Boolean blnFixedRowSet_Previous { get { return blnFixedRowSet; } }
        #else
        protected Boolean blnFixedRowSet_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnFixedRowSet).OriginalValue; } }
        protected Boolean blnFixedRowSet_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnFixedRowSet).PreviousValue; } }
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
            internal Func<Section, object> _get_func;
            internal Action<Section, string> _set_func;
            internal Action<Section, Section, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsSection = "idfsSection";
        internal const string _str_idfsParentSection = "idfsParentSection";
        internal const string _str_idfsFormType = "idfsFormType";
        internal const string _str_rowguid = "rowguid";
        internal const string _str_intRowStatus = "intRowStatus";
        internal const string _str_DefaultName = "DefaultName";
        internal const string _str_NationalName = "NationalName";
        internal const string _str_HasParameters = "HasParameters";
        internal const string _str_HasNestedSections = "HasNestedSections";
        internal const string _str_blnGrid = "blnGrid";
        internal const string _str_blnFixedRowSet = "blnFixedRowSet";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_langid = "langid";
        internal const string _str_ParentSection = "ParentSection";
        internal const string _str_Parameters = "Parameters";
        internal const string _str_FormType = "FormType";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfsSection, _type = "Int64",
              _get_func = o => o.idfsSection,
              _set_func = (o, val) => { o.idfsSection = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSection != c.idfsSection || o.IsRIRPropChanged(_str_idfsSection, c)) 
                  m.Add(_str_idfsSection, o.ObjectIdent + _str_idfsSection, "Int64", o.idfsSection == null ? "" : o.idfsSection.ToString(), o.IsReadOnly(_str_idfsSection), o.IsInvisible(_str_idfsSection), o.IsRequired(_str_idfsSection)); }
              }, 
        
            new field_info {
              _name = _str_idfsParentSection, _type = "Int64?",
              _get_func = o => o.idfsParentSection,
              _set_func = (o, val) => { o.idfsParentSection = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsParentSection != c.idfsParentSection || o.IsRIRPropChanged(_str_idfsParentSection, c)) 
                  m.Add(_str_idfsParentSection, o.ObjectIdent + _str_idfsParentSection, "Int64?", o.idfsParentSection == null ? "" : o.idfsParentSection.ToString(), o.IsReadOnly(_str_idfsParentSection), o.IsInvisible(_str_idfsParentSection), o.IsRequired(_str_idfsParentSection)); }
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
              _name = _str_HasParameters, _type = "Int32",
              _get_func = o => o.HasParameters,
              _set_func = (o, val) => { o.HasParameters = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.HasParameters != c.HasParameters || o.IsRIRPropChanged(_str_HasParameters, c)) 
                  m.Add(_str_HasParameters, o.ObjectIdent + _str_HasParameters, "Int32", o.HasParameters == null ? "" : o.HasParameters.ToString(), o.IsReadOnly(_str_HasParameters), o.IsInvisible(_str_HasParameters), o.IsRequired(_str_HasParameters)); }
              }, 
        
            new field_info {
              _name = _str_HasNestedSections, _type = "Int32",
              _get_func = o => o.HasNestedSections,
              _set_func = (o, val) => { o.HasNestedSections = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.HasNestedSections != c.HasNestedSections || o.IsRIRPropChanged(_str_HasNestedSections, c)) 
                  m.Add(_str_HasNestedSections, o.ObjectIdent + _str_HasNestedSections, "Int32", o.HasNestedSections == null ? "" : o.HasNestedSections.ToString(), o.IsReadOnly(_str_HasNestedSections), o.IsInvisible(_str_HasNestedSections), o.IsRequired(_str_HasNestedSections)); }
              }, 
        
            new field_info {
              _name = _str_blnGrid, _type = "Boolean",
              _get_func = o => o.blnGrid,
              _set_func = (o, val) => { o.blnGrid = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
                if (o.blnGrid != c.blnGrid || o.IsRIRPropChanged(_str_blnGrid, c)) 
                  m.Add(_str_blnGrid, o.ObjectIdent + _str_blnGrid, "Boolean", o.blnGrid == null ? "" : o.blnGrid.ToString(), o.IsReadOnly(_str_blnGrid), o.IsInvisible(_str_blnGrid), o.IsRequired(_str_blnGrid)); }
              }, 
        
            new field_info {
              _name = _str_blnFixedRowSet, _type = "Boolean",
              _get_func = o => o.blnFixedRowSet,
              _set_func = (o, val) => { o.blnFixedRowSet = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
                if (o.blnFixedRowSet != c.blnFixedRowSet || o.IsRIRPropChanged(_str_blnFixedRowSet, c)) 
                  m.Add(_str_blnFixedRowSet, o.ObjectIdent + _str_blnFixedRowSet, "Boolean", o.blnFixedRowSet == null ? "" : o.blnFixedRowSet.ToString(), o.IsReadOnly(_str_blnFixedRowSet), o.IsInvisible(_str_blnFixedRowSet), o.IsRequired(_str_blnFixedRowSet)); }
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
              _name = _str_langid, _type = "String",
              _get_func = o => o.langid,
              _set_func = (o, val) => { o.langid = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.langid != c.langid || o.IsRIRPropChanged(_str_langid, c)) 
                  m.Add(_str_langid, o.ObjectIdent + _str_langid, "String", o.langid == null ? "" : o.langid.ToString(), o.IsReadOnly(_str_langid), o.IsInvisible(_str_langid), o.IsRequired(_str_langid)); }
              }, 
        
            new field_info {
              _name = _str_Parameters, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Parameters.Count != c.Parameters.Count || o.IsReadOnly(_str_Parameters) != c.IsReadOnly(_str_Parameters) || o.IsInvisible(_str_Parameters) != c.IsInvisible(_str_Parameters) || o.IsRequired(_str_Parameters) != c.IsRequired(_str_Parameters)) 
                  m.Add(_str_Parameters, o.ObjectIdent + _str_Parameters, "Child", o.idfsSection == null ? "" : o.idfsSection.ToString(), o.IsReadOnly(_str_Parameters), o.IsInvisible(_str_Parameters), o.IsRequired(_str_Parameters)); }
              }, 
        
            new field_info {
              _name = _str_ParentSection, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.ParentSection != null) o.ParentSection._compare(c.ParentSection, m); }
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
            Section obj = (Section)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(Section), eidss.model.Schema.Section._str_idfsSection, _str_idfsParentSection)]
        public Section ParentSection
        {
            get 
            {   
                return _ParentSection; 
            }
            set 
            {   
                _ParentSection = value; 
                if (_ParentSection != null) 
                { 
                    _ParentSection.m_ObjectName = _str_ParentSection;
                    _ParentSection.Parent = this;
                }
            }
        }
        protected Section _ParentSection;
                    
        [Relation(typeof(Parameter), eidss.model.Schema.Parameter._str_idfsSection, _str_idfsSection)]
        public EditableList<Parameter> Parameters
        {
            get 
            {   
                if (!_ParametersLoaded)
                {
                    _ParametersLoaded = true;
                    _getAccessor()._LoadParameters(this);
                    _Parameters.ForEach(c => { c.Parent = this; });
                }
                return _Parameters; 
            }
            set 
            {
                _Parameters = value;
            }
        }
        protected EditableList<Parameter> _Parameters = new EditableList<Parameter>();
                    
        private bool _ParametersLoaded = false;
                    
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
                    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "Section";

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
        
            if (_ParentSection != null) { _ParentSection.Parent = this; }
                Parameters.ForEach(c => { c.Parent = this; });
                
            if (_FormType != null) { _FormType.Parent = this; }
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as Section;
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
            var ret = base.Clone() as Section;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_ParentSection != null)
              ret.ParentSection = _ParentSection.CloneWithSetup(manager) as Section;
                
            if (_FormType != null)
              ret.FormType = _FormType.CloneWithSetup(manager) as FormType;
                
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public Section CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Section;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsSection; } }
        public string KeyName { get { return "idfsSection"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || (_ParentSection != null && _ParentSection.HasChanges)
                
                    || Parameters.IsDirty
                    || Parameters.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || (_FormType != null && _FormType.HasChanges)
                
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
        
            if (ParentSection != null) ParentSection.RejectChanges();
                Parameters.RejectChanges();
                
            if (FormType != null) FormType.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_ParentSection != null) _ParentSection.AcceptChanges();
                Parameters.AcceptChanges();
                
            if (_FormType != null) _FormType.AcceptChanges();
                
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
        
            if (_ParentSection != null) _ParentSection.SetChange();
                Parameters.ForEach(c => c.SetChange());
                
            if (_FormType != null) _FormType.SetChange();
                
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

      private bool IsRIRPropChanged(string fld, Section c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public Section()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Section_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Section_PropertyChanged);
        }
        private void Section_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Section).Changed(e.PropertyName);
            
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
            Section obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Section obj = this;
            
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
        
                if (_ParentSection != null)
                    _ParentSection.ReadOnly = value;
                
                foreach(var o in _Parameters)
                    o.ReadOnly = value;
                
                if (_FormType != null)
                    _FormType.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<Section, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Section, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Section, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<Section, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<Section, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<Section, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~Section()
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
        
            if (_ParentSection != null) _ParentSection.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_Parameters != null) _Parameters.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_FormType != null) _FormType.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<Section>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectPost
                    
            , IObjectSelectDetail
                    
        {
            private delegate void on_action(Section obj);
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
            private Section.Accessor ParentSectionAccessor { get { return eidss.model.Schema.Section.Accessor.Instance(m_CS); } }
            private Parameter.Accessor ParametersAccessor { get { return eidss.model.Schema.Parameter.Accessor.Instance(m_CS); } }
            private FormType.Accessor FormTypeAccessor { get { return eidss.model.Schema.FormType.Accessor.Instance(m_CS); } }
            [InstanceCache(typeof(BvCacheAspect))][InstanceCache(typeof(BvCacheAspect))]
            public virtual List<Section> SelectList(DbManagerProxy manager
                , Int64? idfsFormType
                , Int64? idfsSection
                , Int64? idfsParentSection
                )
            {
                return _SelectList(manager
                    , idfsFormType
                    , idfsSection
                    , idfsParentSection
                    , delegate(Section obj)
                        {
                        }
                    , delegate(Section obj)
                        {
                        }
                    );
            }

            
            public List<Section> SelectDetailListT(DbManagerProxy manager, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                
                if (!(pars[0] is Int64?)) 
                    throw new TypeMismatchException("idfsFormType", typeof(Int64?));
                
                if (!(pars[1] is Int64?)) 
                    throw new TypeMismatchException("idfsSection", typeof(Int64?));
                
                if (!(pars[2] is Int64?)) 
                    throw new TypeMismatchException("idfsParentSection", typeof(Int64?));
                
                return SelectDetailList(manager
                    
                    , (Int64?)pars[0]
                    
                    , (Int64?)pars[1]
                    
                    , (Int64?)pars[2]
                    
                    );
            }
            public List<Section> SelectDetailList(DbManagerProxy manager, List<object> pars)
            {
                return SelectDetailListT(manager, pars);
            }
            public virtual List<Section> SelectDetailList(DbManagerProxy manager
                , Int64? idfsFormType
                , Int64? idfsSection
                , Int64? idfsParentSection
                )
            {
                return _SelectList(manager
                    , idfsFormType
                    , idfsSection
                    , idfsParentSection
                    , delegate(Section obj)
                        {
                
                        }
                    , delegate(Section obj)
                        {
                
                        }
                    );
            }
            
            private List<Section> _SelectList(DbManagerProxy manager
                , Int64? idfsFormType
                , Int64? idfsSection
                , Int64? idfsParentSection
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<Section> objs = new List<Section>();
                    sets[0] = new MapResultSet(typeof(Section), objs);
                    
                    manager
                        .SetSpCommand("spFFGetSections"
                            , manager.Parameter("@idfsFormType", idfsFormType)
                            , manager.Parameter("@idfsSection", idfsSection)
                            , manager.Parameter("@idfsParentSection", idfsParentSection)
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
                            
                        , null
                            
                        , null, null
                        );
                }
            }

            [InstanceCache(typeof(BvCacheAspect))]
            public virtual Section SelectByKey(DbManagerProxy manager
                , Int64? idfsFormType
                , Int64? idfsSection
                , Int64? idfsParentSection
                )
            {
                return _SelectByKey(manager
                    , idfsFormType
                    , idfsSection
                    , idfsParentSection
                    , null, null
                    );
            }
            
      
            private Section _SelectByKey(DbManagerProxy manager
                , Int64? idfsFormType
                , Int64? idfsSection
                , Int64? idfsParentSection
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<Section> objs = new List<Section>();
                sets[0] = new MapResultSet(typeof(Section), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spFFGetSections"
                            , manager.Parameter("@idfsFormType", idfsFormType)
                            , manager.Parameter("@idfsSection", idfsSection)
                            , manager.Parameter("@idfsParentSection", idfsParentSection)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    Section obj = objs[0];
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
    
            private void _SetupAddChildHandlerParameters(Section obj)
            {
                obj.Parameters.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadParentSection(Section obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadParentSection(manager, obj);
                }
            }
            internal void _LoadParentSection(DbManagerProxy manager, Section obj)
            {
                
                if (obj.ParentSection == null && obj.idfsParentSection != null && obj.idfsParentSection != 0)
                {
                    obj.ParentSection = ParentSectionAccessor.SelectByKey(manager
                        
                        , new Func<Section, Int64?>(c => null)(obj)
                        
                        , new Func<Section, Int64?>(c => c.idfsParentSection)(obj)
                        
                        , new Func<Section, Int64?>(c => null)(obj)
                        
                        );
                    if (obj.ParentSection != null)
                    {
                        obj.ParentSection.m_ObjectName = _str_ParentSection;
                    }
                }
                    
            }
            
            internal void _LoadParameters(Section obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadParameters(manager, obj);
                }
            }
            internal void _LoadParameters(DbManagerProxy manager, Section obj)
            {
                
                obj.Parameters.Clear();
                obj.Parameters.AddRange(ParametersAccessor.SelectDetailList(manager
                    
                    , new Func<Section, Int64?>(c => c.idfsSection)(obj)
                    
                    , new Func<Section, Int64?>(c => null)(obj)
                    
                    ));
                obj.Parameters.ForEach(c => c.m_ObjectName = _str_Parameters);
                obj.Parameters.AcceptChanges();
                    
            }
            
            internal void _LoadFormType(Section obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFormType(manager, obj);
                }
            }
            internal void _LoadFormType(DbManagerProxy manager, Section obj)
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
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, Section obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadParentSection(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerParameters(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, Section obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    ParentSectionAccessor._SetPermitions(obj._permissions, obj.ParentSection);
                    FormTypeAccessor._SetPermitions(obj._permissions, obj.FormType);
                    
                        obj.Parameters.ForEach(c => ParametersAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private Section _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    Section obj = Section.CreateInstance();
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
                    
                    _SetupAddChildHandlerParameters(obj);
                    
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

            
            public Section CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public Section CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(Section obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Section obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, Section obj)
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
                return Validate(manager, obj as Section, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Section obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(Section obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(Section obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Section) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Section) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "SectionDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFFGetSections";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Section, bool>> RequiredByField = new Dictionary<string, Func<Section, bool>>();
            public static Dictionary<string, Func<Section, bool>> RequiredByProperty = new Dictionary<string, Func<Section, bool>>();
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
                    (manager, c, pars) => new ActResult(((Section)c).MarkToDelete() && ObjectAccessor.PostInterface<Section>().Post(manager, (Section)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Section>().Post(manager, (Section)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Section>().Post(manager, (Section)c), c),
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
	