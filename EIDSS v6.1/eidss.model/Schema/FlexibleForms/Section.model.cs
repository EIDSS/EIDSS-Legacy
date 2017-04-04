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
        protected Int64? idfsParentSection_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParentSection).OriginalValue; } }
        protected Int64? idfsParentSection_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsParentSection).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFormType)]
        [MapField(_str_idfsFormType)]
        public abstract Int64 idfsFormType { get; set; }
        protected Int64 idfsFormType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormType).OriginalValue; } }
        protected Int64 idfsFormType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormType).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_HasParameters)]
        [MapField(_str_HasParameters)]
        public abstract Int32 HasParameters { get; set; }
        protected Int32 HasParameters_Original { get { return ((EditableValue<Int32>)((dynamic)this)._hasParameters).OriginalValue; } }
        protected Int32 HasParameters_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._hasParameters).PreviousValue; } }
                
        [LocalizedDisplayName(_str_HasNestedSections)]
        [MapField(_str_HasNestedSections)]
        public abstract Int32 HasNestedSections { get; set; }
        protected Int32 HasNestedSections_Original { get { return ((EditableValue<Int32>)((dynamic)this)._hasNestedSections).OriginalValue; } }
        protected Int32 HasNestedSections_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._hasNestedSections).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnGrid)]
        [MapField(_str_blnGrid)]
        public abstract Boolean blnGrid { get; set; }
        protected Boolean blnGrid_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnGrid).OriginalValue; } }
        protected Boolean blnGrid_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnGrid).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnFixedRowSet)]
        [MapField(_str_blnFixedRowSet)]
        public abstract Boolean blnFixedRowSet { get; set; }
        protected Boolean blnFixedRowSet_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnFixedRowSet).OriginalValue; } }
        protected Boolean blnFixedRowSet_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnFixedRowSet).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32 intOrder { get; set; }
        protected Int32 intOrder_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32 intOrder_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).PreviousValue; } }
                
        [LocalizedDisplayName(_str_langid)]
        [MapField(_str_langid)]
        public abstract String langid { get; set; }
        protected String langid_Original { get { return ((EditableValue<String>)((dynamic)this)._langid).OriginalValue; } }
        protected String langid_Previous { get { return ((EditableValue<String>)((dynamic)this)._langid).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsMatrixType)]
        [MapField(_str_idfsMatrixType)]
        public abstract Int64? idfsMatrixType { get; set; }
        protected Int64? idfsMatrixType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMatrixType).OriginalValue; } }
        protected Int64? idfsMatrixType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMatrixType).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<Section, object> _get_func;
            internal Action<Section, string> _set_func;
            internal Action<Section, Section, CompareModel, DbManagerProxy> _compare_func;
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
        internal const string _str_idfsMatrixType = "idfsMatrixType";
        internal const string _str_idfsParameterDummy = "idfsParameterDummy";
        internal const string _str_Parameters = "Parameters";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsSection, _formname = _str_idfsSection, _type = "Int64",
              _get_func = o => o.idfsSection,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsSection != newval) o.idfsSection = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsParentSection != newval) o.idfsParentSection = newval; },
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
              _name = _str_HasParameters, _formname = _str_HasParameters, _type = "Int32",
              _get_func = o => o.HasParameters,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.HasParameters != newval) o.HasParameters = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.HasParameters != c.HasParameters || o.IsRIRPropChanged(_str_HasParameters, c)) 
                  m.Add(_str_HasParameters, o.ObjectIdent + _str_HasParameters, o.ObjectIdent2 + _str_HasParameters, o.ObjectIdent3 + _str_HasParameters, "Int32", 
                    o.HasParameters == null ? "" : o.HasParameters.ToString(),                  
                  o.IsReadOnly(_str_HasParameters), o.IsInvisible(_str_HasParameters), o.IsRequired(_str_HasParameters)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_HasNestedSections, _formname = _str_HasNestedSections, _type = "Int32",
              _get_func = o => o.HasNestedSections,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.HasNestedSections != newval) o.HasNestedSections = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.HasNestedSections != c.HasNestedSections || o.IsRIRPropChanged(_str_HasNestedSections, c)) 
                  m.Add(_str_HasNestedSections, o.ObjectIdent + _str_HasNestedSections, o.ObjectIdent2 + _str_HasNestedSections, o.ObjectIdent3 + _str_HasNestedSections, "Int32", 
                    o.HasNestedSections == null ? "" : o.HasNestedSections.ToString(),                  
                  o.IsReadOnly(_str_HasNestedSections), o.IsInvisible(_str_HasNestedSections), o.IsRequired(_str_HasNestedSections)); 
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
              _name = _str_idfsMatrixType, _formname = _str_idfsMatrixType, _type = "Int64?",
              _get_func = o => o.idfsMatrixType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsMatrixType != newval) o.idfsMatrixType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsMatrixType != c.idfsMatrixType || o.IsRIRPropChanged(_str_idfsMatrixType, c)) 
                  m.Add(_str_idfsMatrixType, o.ObjectIdent + _str_idfsMatrixType, o.ObjectIdent2 + _str_idfsMatrixType, o.ObjectIdent3 + _str_idfsMatrixType, "Int64?", 
                    o.idfsMatrixType == null ? "" : o.idfsMatrixType.ToString(),                  
                  o.IsReadOnly(_str_idfsMatrixType), o.IsInvisible(_str_idfsMatrixType), o.IsRequired(_str_idfsMatrixType)); 
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
              _name = _str_Parameters, _formname = _str_Parameters, _type = "Lookup",
              _get_func = o => { if (o.Parameters == null) return null; return o.Parameters.idfsParameter; },
              _set_func = (o, val) => { o.Parameters = o.ParametersLookup.Where(c => c.idfsParameter.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Parameters, c);
                if (o.idfsParameterDummy != c.idfsParameterDummy || o.IsRIRPropChanged(_str_Parameters, c) || bChangeLookupContent) {
                  m.Add(_str_Parameters, o.ObjectIdent + _str_Parameters, o.ObjectIdent2 + _str_Parameters, o.ObjectIdent3 + _str_Parameters, "Lookup", o.idfsParameterDummy == null ? "" : o.idfsParameterDummy.ToString(), o.IsReadOnly(_str_Parameters), o.IsInvisible(_str_Parameters), o.IsRequired(_str_Parameters),
                  bChangeLookupContent ? o.ParametersLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Parameters + "Lookup", _formname = _str_Parameters + "Lookup", _type = "LookupContent",
              _get_func = o => o.ParametersLookup,
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
            Section obj = (Section)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Parameters)]
        [Relation(typeof(Parameter), eidss.model.Schema.Parameter._str_idfsParameter, _str_idfsParameterDummy)]
        public Parameter Parameters
        {
            get { return _Parameters; }
            set 
            { 
                var oldVal = _Parameters;
                _Parameters = value;
                if (_Parameters != oldVal)
                {
                    if (idfsParameterDummy != (_Parameters == null
                            ? new long?()
                            : _Parameters.idfsParameter))
                        idfsParameterDummy = _Parameters == null 
                            ? new long?()
                            : _Parameters.idfsParameter; 
                    OnPropertyChanged(_str_Parameters); 
                }
            }
        }
        private Parameter _Parameters;

        
        public List<Parameter> ParametersLookup
        {
            get { return _ParametersLookup; }
        }
        private List<Parameter> _ParametersLookup = new List<Parameter>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Parameters:
                    return new BvSelectList(ParametersLookup, eidss.model.Schema.Parameter._str_idfsParameter, null, Parameters, _str_idfsParameterDummy);
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str_idfsParameterDummy)]
        public long? idfsParameterDummy
        {
            get { return m_idfsParameterDummy; }
            set { if (m_idfsParameterDummy != value) { m_idfsParameterDummy = value; OnPropertyChanged(_str_idfsParameterDummy); } }
        }
        private long? m_idfsParameterDummy;
        
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
        
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as Section;
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
            var ret = base.Clone() as Section;
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
        
            var _prev_idfsParameterDummy_Parameters = idfsParameterDummy;
            base.RejectChanges();
        
            if (_prev_idfsParameterDummy_Parameters != idfsParameterDummy)
            {
                _Parameters = _ParametersLookup.FirstOrDefault(c => c.idfsParameter == idfsParameterDummy);
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

        private bool IsRIRPropChanged(string fld, Section c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, Section c)
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
        

      

        public Section()
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


        internal Dictionary<string, Func<Section, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<Section, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Section, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Section, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<Section, bool>> m_isHiddenPersonalData;
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
        protected bool bNeedLookupRemove;
        ~Section()
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
                
                LookupManager.RemoveObject("Parameter", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "Parameter")
                _getAccessor().LoadLookup_Parameters(manager, this);
            
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
        : DataAccessor<Section>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<Section>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsSection"; } }
            #endregion
        
            public delegate void on_action(Section obj);
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
            private Parameter.Accessor ParametersAccessor { get { return eidss.model.Schema.Parameter.Accessor.Instance(m_CS); } }
            
            public virtual List<Section> SelectLookupList(DbManagerProxy manager
                , Int64? idfsFormType
                , Int64? idfsSection
                , Int64? idfsParentSection
                )
            {
                return _SelectList(manager
                    , idfsFormType
                    , idfsSection
                    , idfsParentSection
                    , null, null
                    );
            }
            
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

            

            public List<Section> _SelectList(DbManagerProxy manager
                , Int64? idfsFormType
                , Int64? idfsSection
                , Int64? idfsParentSection
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfsFormType
                    , idfsSection
                    , idfsParentSection
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            [InstanceCache(typeof(BvCacheAspect))]
            public virtual List<Section> _SelectListInternal(DbManagerProxy manager
                , Int64? idfsFormType
                , Int64? idfsSection
                , Int64? idfsParentSection
                , on_action loading, on_action loaded
                )
            {
                Section _obj = null;
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, Section obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, Section obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private Section _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                Section obj = null;
                try
                {
                    obj = Section.CreateInstance();
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

            
            public Section CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public Section CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
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
    
            public void LoadLookup_Parameters(DbManagerProxy manager, Section obj)
            {
                
                obj.ParametersLookup.Clear();
                
                obj.ParametersLookup.AddRange(ParametersAccessor.SelectLookupList(manager
                    
                    , new Func<Section, Int64?>(c => c.idfsSection)(obj)
                            
                    , new Func<Section, Int64?>(c => null)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsParameter == obj.idfsParameterDummy))
                    
                    .ToList());
                
                if (obj.idfsParameterDummy != null && obj.idfsParameterDummy != 0)
                {
                    obj.Parameters = obj.ParametersLookup
                        .SingleOrDefault(c => c.idfsParameter == obj.idfsParameterDummy);
                    
                }
              
                LookupManager.AddObject("Parameter", obj, ParametersAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, Section obj)
            {
                
                LoadLookup_Parameters(manager, obj);
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(Section obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(Section obj, bool bRethrowException)
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
                return Validate(manager, obj as Section, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Section obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
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
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
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
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Section, bool>> RequiredByField = new Dictionary<string, Func<Section, bool>>();
            public static Dictionary<string, Func<Section, bool>> RequiredByProperty = new Dictionary<string, Func<Section, bool>>();
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
	