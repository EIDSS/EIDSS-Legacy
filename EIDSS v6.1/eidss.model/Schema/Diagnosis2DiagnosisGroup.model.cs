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
    public abstract partial class Diagnosis2DiagnosisGroup : 
        EditableObject<Diagnosis2DiagnosisGroup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfDiagnosisToDiagnosisGroup), NonUpdatable, PrimaryKey]
        public abstract Int64 idfDiagnosisToDiagnosisGroup { get; set; }
                
        [LocalizedDisplayName("strDiagnosisGroup")]
        [MapField(_str_idfsDiagnosisGroup)]
        public abstract Int64 idfsDiagnosisGroup { get; set; }
        protected Int64 idfsDiagnosisGroup_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosisGroup).OriginalValue; } }
        protected Int64 idfsDiagnosisGroup_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosisGroup).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DiagnosisGroupName)]
        [MapField(_str_DiagnosisGroupName)]
        public abstract String DiagnosisGroupName { get; set; }
        protected String DiagnosisGroupName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisGroupName).OriginalValue; } }
        protected String DiagnosisGroupName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisGroupName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DiagnosisGroupNameTranslated)]
        [MapField(_str_DiagnosisGroupNameTranslated)]
        public abstract String DiagnosisGroupNameTranslated { get; set; }
        protected String DiagnosisGroupNameTranslated_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisGroupNameTranslated).OriginalValue; } }
        protected String DiagnosisGroupNameTranslated_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisGroupNameTranslated).PreviousValue; } }
                
        [LocalizedDisplayName("strDiagnosisName")]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64 idfsDiagnosis { get; set; }
        protected Int64 idfsDiagnosis_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64 idfsDiagnosis_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DiagnosisName)]
        [MapField(_str_DiagnosisName)]
        public abstract String DiagnosisName { get; set; }
        protected String DiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).OriginalValue; } }
        protected String DiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DiagnosisNameTranslated)]
        [MapField(_str_DiagnosisNameTranslated)]
        public abstract String DiagnosisNameTranslated { get; set; }
        protected String DiagnosisNameTranslated_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisNameTranslated).OriginalValue; } }
        protected String DiagnosisNameTranslated_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisNameTranslated).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsUsingType)]
        [MapField(_str_idfsUsingType)]
        public abstract Int64 idfsUsingType { get; set; }
        protected Int64 idfsUsingType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUsingType).OriginalValue; } }
        protected Int64 idfsUsingType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUsingType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int32? intHACode { get; set; }
        protected Int32? intHACode_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32? intHACode_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32? intOrder { get; set; }
        protected Int32? intOrder_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32? intOrder_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).PreviousValue; } }
                
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
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<Diagnosis2DiagnosisGroup, object> _get_func;
            internal Action<Diagnosis2DiagnosisGroup, string> _set_func;
            internal Action<Diagnosis2DiagnosisGroup, Diagnosis2DiagnosisGroup, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfDiagnosisToDiagnosisGroup = "idfDiagnosisToDiagnosisGroup";
        internal const string _str_idfsDiagnosisGroup = "idfsDiagnosisGroup";
        internal const string _str_DiagnosisGroupName = "DiagnosisGroupName";
        internal const string _str_DiagnosisGroupNameTranslated = "DiagnosisGroupNameTranslated";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_DiagnosisName = "DiagnosisName";
        internal const string _str_DiagnosisNameTranslated = "DiagnosisNameTranslated";
        internal const string _str_idfsUsingType = "idfsUsingType";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_strUsingType = "strUsingType";
        internal const string _str_strHACode = "strHACode";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_DiagnosisGroup = "DiagnosisGroup";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfDiagnosisToDiagnosisGroup, _formname = _str_idfDiagnosisToDiagnosisGroup, _type = "Int64",
              _get_func = o => o.idfDiagnosisToDiagnosisGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfDiagnosisToDiagnosisGroup != newval) o.idfDiagnosisToDiagnosisGroup = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfDiagnosisToDiagnosisGroup != c.idfDiagnosisToDiagnosisGroup || o.IsRIRPropChanged(_str_idfDiagnosisToDiagnosisGroup, c)) 
                  m.Add(_str_idfDiagnosisToDiagnosisGroup, o.ObjectIdent + _str_idfDiagnosisToDiagnosisGroup, o.ObjectIdent2 + _str_idfDiagnosisToDiagnosisGroup, o.ObjectIdent3 + _str_idfDiagnosisToDiagnosisGroup, "Int64", 
                    o.idfDiagnosisToDiagnosisGroup == null ? "" : o.idfDiagnosisToDiagnosisGroup.ToString(),                  
                  o.IsReadOnly(_str_idfDiagnosisToDiagnosisGroup), o.IsInvisible(_str_idfDiagnosisToDiagnosisGroup), o.IsRequired(_str_idfDiagnosisToDiagnosisGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosisGroup, _formname = _str_idfsDiagnosisGroup, _type = "Int64",
              _get_func = o => o.idfsDiagnosisGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsDiagnosisGroup != newval) 
                  o.DiagnosisGroup = o.DiagnosisGroupLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsDiagnosisGroup != newval) o.idfsDiagnosisGroup = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsDiagnosisGroup != c.idfsDiagnosisGroup || o.IsRIRPropChanged(_str_idfsDiagnosisGroup, c)) 
                  m.Add(_str_idfsDiagnosisGroup, o.ObjectIdent + _str_idfsDiagnosisGroup, o.ObjectIdent2 + _str_idfsDiagnosisGroup, o.ObjectIdent3 + _str_idfsDiagnosisGroup, "Int64", 
                    o.idfsDiagnosisGroup == null ? "" : o.idfsDiagnosisGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosisGroup), o.IsInvisible(_str_idfsDiagnosisGroup), o.IsRequired(_str_idfsDiagnosisGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DiagnosisGroupName, _formname = _str_DiagnosisGroupName, _type = "String",
              _get_func = o => o.DiagnosisGroupName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DiagnosisGroupName != newval) o.DiagnosisGroupName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DiagnosisGroupName != c.DiagnosisGroupName || o.IsRIRPropChanged(_str_DiagnosisGroupName, c)) 
                  m.Add(_str_DiagnosisGroupName, o.ObjectIdent + _str_DiagnosisGroupName, o.ObjectIdent2 + _str_DiagnosisGroupName, o.ObjectIdent3 + _str_DiagnosisGroupName, "String", 
                    o.DiagnosisGroupName == null ? "" : o.DiagnosisGroupName.ToString(),                  
                  o.IsReadOnly(_str_DiagnosisGroupName), o.IsInvisible(_str_DiagnosisGroupName), o.IsRequired(_str_DiagnosisGroupName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DiagnosisGroupNameTranslated, _formname = _str_DiagnosisGroupNameTranslated, _type = "String",
              _get_func = o => o.DiagnosisGroupNameTranslated,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DiagnosisGroupNameTranslated != newval) o.DiagnosisGroupNameTranslated = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DiagnosisGroupNameTranslated != c.DiagnosisGroupNameTranslated || o.IsRIRPropChanged(_str_DiagnosisGroupNameTranslated, c)) 
                  m.Add(_str_DiagnosisGroupNameTranslated, o.ObjectIdent + _str_DiagnosisGroupNameTranslated, o.ObjectIdent2 + _str_DiagnosisGroupNameTranslated, o.ObjectIdent3 + _str_DiagnosisGroupNameTranslated, "String", 
                    o.DiagnosisGroupNameTranslated == null ? "" : o.DiagnosisGroupNameTranslated.ToString(),                  
                  o.IsReadOnly(_str_DiagnosisGroupNameTranslated), o.IsInvisible(_str_DiagnosisGroupNameTranslated), o.IsRequired(_str_DiagnosisGroupNameTranslated)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "Int64",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsDiagnosis != newval) 
                  o.Diagnosis = o.DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis, "Int64", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DiagnosisName, _formname = _str_DiagnosisName, _type = "String",
              _get_func = o => o.DiagnosisName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DiagnosisName != newval) o.DiagnosisName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DiagnosisName != c.DiagnosisName || o.IsRIRPropChanged(_str_DiagnosisName, c)) 
                  m.Add(_str_DiagnosisName, o.ObjectIdent + _str_DiagnosisName, o.ObjectIdent2 + _str_DiagnosisName, o.ObjectIdent3 + _str_DiagnosisName, "String", 
                    o.DiagnosisName == null ? "" : o.DiagnosisName.ToString(),                  
                  o.IsReadOnly(_str_DiagnosisName), o.IsInvisible(_str_DiagnosisName), o.IsRequired(_str_DiagnosisName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DiagnosisNameTranslated, _formname = _str_DiagnosisNameTranslated, _type = "String",
              _get_func = o => o.DiagnosisNameTranslated,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DiagnosisNameTranslated != newval) o.DiagnosisNameTranslated = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DiagnosisNameTranslated != c.DiagnosisNameTranslated || o.IsRIRPropChanged(_str_DiagnosisNameTranslated, c)) 
                  m.Add(_str_DiagnosisNameTranslated, o.ObjectIdent + _str_DiagnosisNameTranslated, o.ObjectIdent2 + _str_DiagnosisNameTranslated, o.ObjectIdent3 + _str_DiagnosisNameTranslated, "String", 
                    o.DiagnosisNameTranslated == null ? "" : o.DiagnosisNameTranslated.ToString(),                  
                  o.IsReadOnly(_str_DiagnosisNameTranslated), o.IsInvisible(_str_DiagnosisNameTranslated), o.IsRequired(_str_DiagnosisNameTranslated)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsUsingType, _formname = _str_idfsUsingType, _type = "Int64",
              _get_func = o => o.idfsUsingType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsUsingType != newval) o.idfsUsingType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUsingType != c.idfsUsingType || o.IsRIRPropChanged(_str_idfsUsingType, c)) 
                  m.Add(_str_idfsUsingType, o.ObjectIdent + _str_idfsUsingType, o.ObjectIdent2 + _str_idfsUsingType, o.ObjectIdent3 + _str_idfsUsingType, "Int64", 
                    o.idfsUsingType == null ? "" : o.idfsUsingType.ToString(),                  
                  o.IsReadOnly(_str_idfsUsingType), o.IsInvisible(_str_idfsUsingType), o.IsRequired(_str_idfsUsingType)); 
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
              _name = _str_Diagnosis, _formname = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Diagnosis, c);
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnosis, c) || bChangeLookupContent) {
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, o.ObjectIdent2 + _str_Diagnosis, o.ObjectIdent3 + _str_Diagnosis, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis),
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
              _name = _str_DiagnosisGroup, _formname = _str_DiagnosisGroup, _type = "Lookup",
              _get_func = o => { if (o.DiagnosisGroup == null) return null; return o.DiagnosisGroup.idfsBaseReference; },
              _set_func = (o, val) => { o.DiagnosisGroup = o.DiagnosisGroupLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_DiagnosisGroup, c);
                if (o.idfsDiagnosisGroup != c.idfsDiagnosisGroup || o.IsRIRPropChanged(_str_DiagnosisGroup, c) || bChangeLookupContent) {
                  m.Add(_str_DiagnosisGroup, o.ObjectIdent + _str_DiagnosisGroup, o.ObjectIdent2 + _str_DiagnosisGroup, o.ObjectIdent3 + _str_DiagnosisGroup, "Lookup", o.idfsDiagnosisGroup == null ? "" : o.idfsDiagnosisGroup.ToString(), o.IsReadOnly(_str_DiagnosisGroup), o.IsInvisible(_str_DiagnosisGroup), o.IsRequired(_str_DiagnosisGroup),
                  bChangeLookupContent ? o.DiagnosisGroupLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_DiagnosisGroup + "Lookup", _formname = _str_DiagnosisGroup + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisGroupLookup,
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
            Diagnosis2DiagnosisGroup obj = (Diagnosis2DiagnosisGroup)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Diagnosis)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                var oldVal = _Diagnosis;
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Diagnosis != oldVal)
                {
                    if (idfsDiagnosis != (_Diagnosis == null
                            ? new Int64()
                            : (Int64)_Diagnosis.idfsDiagnosis))
                        idfsDiagnosis = _Diagnosis == null 
                            ? new Int64()
                            : (Int64)_Diagnosis.idfsDiagnosis; 
                    OnPropertyChanged(_str_Diagnosis); 
                }
            }
        }
        private DiagnosisLookup _Diagnosis;

        
        public List<DiagnosisLookup> DiagnosisLookup
        {
            get { return _DiagnosisLookup; }
        }
        private List<DiagnosisLookup> _DiagnosisLookup = new List<DiagnosisLookup>();
            
        [LocalizedDisplayName(_str_DiagnosisGroup)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsDiagnosisGroup)]
        public BaseReference DiagnosisGroup
        {
            get { return _DiagnosisGroup == null ? null : ((long)_DiagnosisGroup.Key == 0 ? null : _DiagnosisGroup); }
            set 
            { 
                var oldVal = _DiagnosisGroup;
                _DiagnosisGroup = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_DiagnosisGroup != oldVal)
                {
                    if (idfsDiagnosisGroup != (_DiagnosisGroup == null
                            ? new Int64()
                            : (Int64)_DiagnosisGroup.idfsBaseReference))
                        idfsDiagnosisGroup = _DiagnosisGroup == null 
                            ? new Int64()
                            : (Int64)_DiagnosisGroup.idfsBaseReference; 
                    OnPropertyChanged(_str_DiagnosisGroup); 
                }
            }
        }
        private BaseReference _DiagnosisGroup;

        
        public BaseReferenceList DiagnosisGroupLookup
        {
            get { return _DiagnosisGroupLookup; }
        }
        private BaseReferenceList _DiagnosisGroupLookup = new BaseReferenceList("rftDiagnosisGroup");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_DiagnosisGroup:
                    return new BvSelectList(DiagnosisGroupLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, DiagnosisGroup, _str_idfsDiagnosisGroup);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "Diagnosis2DiagnosisGroup";

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
            var ret = base.Clone() as Diagnosis2DiagnosisGroup;
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
            var ret = base.Clone() as Diagnosis2DiagnosisGroup;
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
        public Diagnosis2DiagnosisGroup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Diagnosis2DiagnosisGroup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfDiagnosisToDiagnosisGroup; } }
        public string KeyName { get { return "idfDiagnosisToDiagnosisGroup"; } }
        public object KeyLookup { get { return idfDiagnosisToDiagnosisGroup; } }
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
        
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfsDiagnosisGroup_DiagnosisGroup = idfsDiagnosisGroup;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsDiagnosisGroup_DiagnosisGroup != idfsDiagnosisGroup)
            {
                _DiagnosisGroup = _DiagnosisGroupLookup.FirstOrDefault(c => c.idfsBaseReference == idfsDiagnosisGroup);
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
          
              switch(name)
              {
              
                case "DiagnosisGroupName":
                  return new Dictionary<string, string> {
                
                    { "en", "" },
                
                    } ;
              
                case "DiagnosisGroupNameTranslated":
                  return new Dictionary<string, string> {
                
                    { "def", "" },
                
                    } ;
              
                default:
                  return null;
              }
            
        }
      #endregion

        private bool IsRIRPropChanged(string fld, Diagnosis2DiagnosisGroup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, Diagnosis2DiagnosisGroup c)
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
        

      

        public Diagnosis2DiagnosisGroup()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Diagnosis2DiagnosisGroup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Diagnosis2DiagnosisGroup_PropertyChanged);
        }
        private void Diagnosis2DiagnosisGroup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Diagnosis2DiagnosisGroup).Changed(e.PropertyName);
            
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
            Diagnosis2DiagnosisGroup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Diagnosis2DiagnosisGroup obj = this;
            
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

    
        private static string[] readonly_names1 = "strUsingType,strHACode,intOrder".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Diagnosis2DiagnosisGroup, bool>(c => true)(this);
            
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


        internal Dictionary<string, Func<Diagnosis2DiagnosisGroup, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<Diagnosis2DiagnosisGroup, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Diagnosis2DiagnosisGroup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Diagnosis2DiagnosisGroup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<Diagnosis2DiagnosisGroup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<Diagnosis2DiagnosisGroup, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<Diagnosis2DiagnosisGroup, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~Diagnosis2DiagnosisGroup()
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
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftDiagnosisGroup", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftDiagnosisGroup")
                _getAccessor().LoadLookup_DiagnosisGroup(manager, this);
            
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
        public class Diagnosis2DiagnosisGroupGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfDiagnosisToDiagnosisGroup { get; set; }
        
            public Int64 idfsDiagnosis { get; set; }
        
            public String strUsingType { get; set; }
        
            public String strHACode { get; set; }
        
            public Int32? intOrder { get; set; }
        
        }
        public partial class Diagnosis2DiagnosisGroupGridModelList : List<Diagnosis2DiagnosisGroupGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public Diagnosis2DiagnosisGroupGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<Diagnosis2DiagnosisGroup>, errMes);
            }
            public Diagnosis2DiagnosisGroupGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<Diagnosis2DiagnosisGroup>, errMes);
            }
            public Diagnosis2DiagnosisGroupGridModelList(long key, IEnumerable<Diagnosis2DiagnosisGroup> items)
            {
                LoadGridModelList(key, items, null);
            }
            public Diagnosis2DiagnosisGroupGridModelList(long key)
            {
                LoadGridModelList(key, new List<Diagnosis2DiagnosisGroup>(), null);
            }
            partial void filter(List<Diagnosis2DiagnosisGroup> items);
            private void LoadGridModelList(long key, IEnumerable<Diagnosis2DiagnosisGroup> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_idfsDiagnosis,_str_strUsingType,_str_strHACode,_str_intOrder};
                    
                Hiddens = new List<string> {_str_idfDiagnosisToDiagnosisGroup};
                Keys = new List<string> {};
                Labels = new Dictionary<string, string> {{_str_idfsDiagnosis, "strDiagnosisName"},{_str_strUsingType, _str_strUsingType},{_str_strHACode, _str_strHACode},{_str_intOrder, _str_intOrder}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                Diagnosis2DiagnosisGroup.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<Diagnosis2DiagnosisGroup>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new Diagnosis2DiagnosisGroupGridModel()
                {
                    idfDiagnosisToDiagnosisGroup=c.idfDiagnosisToDiagnosisGroup,idfsDiagnosis=c.idfsDiagnosis,strUsingType=c.strUsingType,strHACode=c.strHACode,intOrder=c.intOrder
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
        : DataAccessor<Diagnosis2DiagnosisGroup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<Diagnosis2DiagnosisGroup>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfDiagnosisToDiagnosisGroup"; } }
            #endregion
        
            public delegate void on_action(Diagnosis2DiagnosisGroup obj);
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
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor DiagnosisGroupAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<Diagnosis2DiagnosisGroup> SelectList(DbManagerProxy manager
                , Int64? idfDiagnosisToDiagnosisGroup
                )
            {
                return _SelectList(manager
                    , idfDiagnosisToDiagnosisGroup
                    , delegate(Diagnosis2DiagnosisGroup obj)
                        {
                        }
                    , delegate(Diagnosis2DiagnosisGroup obj)
                        {
                        }
                    );
            }

            

            public List<Diagnosis2DiagnosisGroup> _SelectList(DbManagerProxy manager
                , Int64? idfDiagnosisToDiagnosisGroup
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfDiagnosisToDiagnosisGroup
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<Diagnosis2DiagnosisGroup> _SelectListInternal(DbManagerProxy manager
                , Int64? idfDiagnosisToDiagnosisGroup
                , on_action loading, on_action loaded
                )
            {
                Diagnosis2DiagnosisGroup _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<Diagnosis2DiagnosisGroup> objs = new List<Diagnosis2DiagnosisGroup>();
                    sets[0] = new MapResultSet(typeof(Diagnosis2DiagnosisGroup), objs);
                    
                    manager
                        .SetSpCommand("spDiagnosis2DiagnosisGroup_SelectDetail"
                            , manager.Parameter("@idfDiagnosisToDiagnosisGroup", idfDiagnosisToDiagnosisGroup)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, Diagnosis2DiagnosisGroup obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, Diagnosis2DiagnosisGroup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private Diagnosis2DiagnosisGroup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                Diagnosis2DiagnosisGroup obj = null;
                try
                {
                    obj = Diagnosis2DiagnosisGroup.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfDiagnosisToDiagnosisGroup = (new GetNewIDExtender<Diagnosis2DiagnosisGroup>()).GetScalar(manager, obj, isFake);
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

            
            public Diagnosis2DiagnosisGroup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public Diagnosis2DiagnosisGroup CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public Diagnosis2DiagnosisGroup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(Diagnosis2DiagnosisGroup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Diagnosis2DiagnosisGroup obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                obj.intOrder = new Func<Diagnosis2DiagnosisGroup, int?>(c => c.DiagnosisLookup != null ? c.DiagnosisLookup.FirstOrDefault(w => w.idfsDiagnosis == c.idfsDiagnosis).intOrder : c.intOrder)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                obj.strUsingType = new Func<Diagnosis2DiagnosisGroup, string>(c => c.DiagnosisLookup != null ? c.DiagnosisLookup.FirstOrDefault(w => w.idfsDiagnosis == c.idfsDiagnosis).UsingTypeName : c.strUsingType)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                obj.strHACode = new Func<Diagnosis2DiagnosisGroup, string>(c => c.DiagnosisLookup != null ? c.DiagnosisLookup.FirstOrDefault(w => w.idfsDiagnosis == c.idfsDiagnosis).HACode : c.strHACode)(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Diagnosis(DbManagerProxy manager, Diagnosis2DiagnosisGroup obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosis);
                    
                }
              
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_DiagnosisGroup(DbManagerProxy manager, Diagnosis2DiagnosisGroup obj)
            {
                
                obj.DiagnosisGroupLookup.Clear();
                
                obj.DiagnosisGroupLookup.Add(DiagnosisGroupAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisGroupLookup.AddRange(DiagnosisGroupAccessor.rftDiagnosisGroup_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsDiagnosisGroup))
                    
                    .ToList());
                
                if (obj.idfsDiagnosisGroup != 0)
                {
                    obj.DiagnosisGroup = obj.DiagnosisGroupLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsDiagnosisGroup);
                    
                }
              
                LookupManager.AddObject("rftDiagnosisGroup", obj, DiagnosisGroupAccessor.GetType(), "rftDiagnosisGroup_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, Diagnosis2DiagnosisGroup obj)
            {
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_DiagnosisGroup(manager, obj);
                
            }
    
            [SprocName("spDiagnosis2DiagnosisGroup_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] Diagnosis2DiagnosisGroup obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] Diagnosis2DiagnosisGroup obj)
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
                        Diagnosis2DiagnosisGroup bo = obj as Diagnosis2DiagnosisGroup;
                        
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
                        bSuccess = _PostNonTransaction(manager, obj as Diagnosis2DiagnosisGroup, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, Diagnosis2DiagnosisGroup obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(Diagnosis2DiagnosisGroup obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, Diagnosis2DiagnosisGroup obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(Diagnosis2DiagnosisGroup obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(Diagnosis2DiagnosisGroup obj, bool bRethrowException)
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
                return Validate(manager, obj as Diagnosis2DiagnosisGroup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Diagnosis2DiagnosisGroup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfDiagnosisToDiagnosisGroup", "idfDiagnosisToDiagnosisGroup","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfDiagnosisToDiagnosisGroup);
            
                (new RequiredValidator( "idfsDiagnosisGroup", "idfsDiagnosisGroup","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsDiagnosisGroup);
            
                (new RequiredValidator( "idfsDiagnosis", "idfsDiagnosis","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsDiagnosis);
            
                  
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
           
    
            private void _SetupRequired(Diagnosis2DiagnosisGroup obj)
            {
            
                obj
                    .AddRequired("idfDiagnosisToDiagnosisGroup", c => true);
                    
                obj
                    .AddRequired("idfsDiagnosisGroup", c => true);
                    
                  obj
                    .AddRequired("DiagnosisGroup", c => true);
                
                obj
                    .AddRequired("idfsDiagnosis", c => true);
                    
                  obj
                    .AddRequired("Diagnosis", c => true);
                
            }
    
    private void _SetupPersonalDataRestrictions(Diagnosis2DiagnosisGroup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Diagnosis2DiagnosisGroup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Diagnosis2DiagnosisGroup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "Diagnosis2DiagnosisGroupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spDiagnosis2DiagnosisGroup_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spDiagnosis2DiagnosisGroup_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Diagnosis2DiagnosisGroup, bool>> RequiredByField = new Dictionary<string, Func<Diagnosis2DiagnosisGroup, bool>>();
            public static Dictionary<string, Func<Diagnosis2DiagnosisGroup, bool>> RequiredByProperty = new Dictionary<string, Func<Diagnosis2DiagnosisGroup, bool>>();
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
                
                Sizes.Add(_str_DiagnosisGroupName, 2000);
                Sizes.Add(_str_DiagnosisGroupNameTranslated, 2000);
                Sizes.Add(_str_DiagnosisName, 2000);
                Sizes.Add(_str_DiagnosisNameTranslated, 2000);
                Sizes.Add(_str_strUsingType, 2000);
                Sizes.Add(_str_strHACode, 4000);
                if (!RequiredByField.ContainsKey("idfDiagnosisToDiagnosisGroup")) RequiredByField.Add("idfDiagnosisToDiagnosisGroup", c => true);
                if (!RequiredByProperty.ContainsKey("idfDiagnosisToDiagnosisGroup")) RequiredByProperty.Add("idfDiagnosisToDiagnosisGroup", c => true);
                
                if (!RequiredByField.ContainsKey("idfsDiagnosisGroup")) RequiredByField.Add("idfsDiagnosisGroup", c => true);
                if (!RequiredByProperty.ContainsKey("idfsDiagnosisGroup")) RequiredByProperty.Add("idfsDiagnosisGroup", c => true);
                
                if (!RequiredByField.ContainsKey("idfsDiagnosis")) RequiredByField.Add("idfsDiagnosis", c => true);
                if (!RequiredByProperty.ContainsKey("idfsDiagnosis")) RequiredByProperty.Add("idfsDiagnosis", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfDiagnosisToDiagnosisGroup,
                    _str_idfDiagnosisToDiagnosisGroup, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsDiagnosis,
                    "strDiagnosisName", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strUsingType,
                    _str_strUsingType, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strHACode,
                    _str_strHACode, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intOrder,
                    _str_intOrder, null, false, true, true, true, true, null
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
                    (manager, c, pars) => ((Diagnosis2DiagnosisGroup)c).MarkToDelete(),
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
	