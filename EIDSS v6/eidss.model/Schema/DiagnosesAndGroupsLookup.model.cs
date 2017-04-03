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
    public abstract partial class DiagnosesAndGroupsLookup : 
        EditableObject<DiagnosesAndGroupsLookup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsDiagnosisOrDiagnosisGroup), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsDiagnosisOrDiagnosisGroup { get; set; }
                
        [LocalizedDisplayName(_str_idfsDiagnosisGroup)]
        [MapField(_str_idfsDiagnosisGroup)]
        public abstract Int64? idfsDiagnosisGroup { get; set; }
        protected Int64? idfsDiagnosisGroup_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosisGroup).OriginalValue; } }
        protected Int64? idfsDiagnosisGroup_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosisGroup).PreviousValue; } }
                
        [LocalizedDisplayName(_str_name)]
        [MapField(_str_name)]
        public abstract String name { get; set; }
        protected String name_Original { get { return ((EditableValue<String>)((dynamic)this)._name).OriginalValue; } }
        protected String name_Previous { get { return ((EditableValue<String>)((dynamic)this)._name).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strIDC10)]
        [MapField(_str_strIDC10)]
        public abstract String strIDC10 { get; set; }
        protected String strIDC10_Original { get { return ((EditableValue<String>)((dynamic)this)._strIDC10).OriginalValue; } }
        protected String strIDC10_Previous { get { return ((EditableValue<String>)((dynamic)this)._strIDC10).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strOIECode)]
        [MapField(_str_strOIECode)]
        public abstract String strOIECode { get; set; }
        protected String strOIECode_Original { get { return ((EditableValue<String>)((dynamic)this)._strOIECode).OriginalValue; } }
        protected String strOIECode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOIECode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int32? intHACode { get; set; }
        protected Int32? intHACode_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32? intHACode_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intRowStatus)]
        [MapField(_str_intRowStatus)]
        public abstract Int32? intRowStatus { get; set; }
        protected Int32? intRowStatus_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intRowStatus).OriginalValue; } }
        protected Int32? intRowStatus_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intRowStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnGroup)]
        [MapField(_str_blnGroup)]
        public abstract Boolean? blnGroup { get; set; }
        protected Boolean? blnGroup_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnGroup).OriginalValue; } }
        protected Boolean? blnGroup_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnGroup).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHACode)]
        [MapField(_str_strHACode)]
        public abstract String strHACode { get; set; }
        protected String strHACode_Original { get { return ((EditableValue<String>)((dynamic)this)._strHACode).OriginalValue; } }
        protected String strHACode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHACode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strUsingTypeName)]
        [MapField(_str_strUsingTypeName)]
        public abstract String strUsingTypeName { get; set; }
        protected String strUsingTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._strUsingTypeName).OriginalValue; } }
        protected String strUsingTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strUsingTypeName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intIsDeleted)]
        [MapField(_str_intIsDeleted)]
        public abstract Int32? intIsDeleted { get; set; }
        protected Int32? intIsDeleted_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intIsDeleted).OriginalValue; } }
        protected Int32? intIsDeleted_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intIsDeleted).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strIsDeleted)]
        [MapField(_str_strIsDeleted)]
        public abstract String strIsDeleted { get; set; }
        protected String strIsDeleted_Original { get { return ((EditableValue<String>)((dynamic)this)._strIsDeleted).OriginalValue; } }
        protected String strIsDeleted_Previous { get { return ((EditableValue<String>)((dynamic)this)._strIsDeleted).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int64? intOrder { get; set; }
        protected Int64? intOrder_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int64? intOrder_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._intOrder).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<DiagnosesAndGroupsLookup, object> _get_func;
            internal Action<DiagnosesAndGroupsLookup, string> _set_func;
            internal Action<DiagnosesAndGroupsLookup, DiagnosesAndGroupsLookup, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsDiagnosisOrDiagnosisGroup = "idfsDiagnosisOrDiagnosisGroup";
        internal const string _str_idfsDiagnosisGroup = "idfsDiagnosisGroup";
        internal const string _str_name = "name";
        internal const string _str_strIDC10 = "strIDC10";
        internal const string _str_strOIECode = "strOIECode";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_intRowStatus = "intRowStatus";
        internal const string _str_blnGroup = "blnGroup";
        internal const string _str_strHACode = "strHACode";
        internal const string _str_strUsingTypeName = "strUsingTypeName";
        internal const string _str_intIsDeleted = "intIsDeleted";
        internal const string _str_strIsDeleted = "strIsDeleted";
        internal const string _str_intOrder = "intOrder";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsDiagnosisOrDiagnosisGroup, _formname = _str_idfsDiagnosisOrDiagnosisGroup, _type = "Int64",
              _get_func = o => o.idfsDiagnosisOrDiagnosisGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsDiagnosisOrDiagnosisGroup != newval) o.idfsDiagnosisOrDiagnosisGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosisOrDiagnosisGroup != c.idfsDiagnosisOrDiagnosisGroup || o.IsRIRPropChanged(_str_idfsDiagnosisOrDiagnosisGroup, c)) 
                  m.Add(_str_idfsDiagnosisOrDiagnosisGroup, o.ObjectIdent + _str_idfsDiagnosisOrDiagnosisGroup, o.ObjectIdent2 + _str_idfsDiagnosisOrDiagnosisGroup, o.ObjectIdent3 + _str_idfsDiagnosisOrDiagnosisGroup, "Int64", 
                    o.idfsDiagnosisOrDiagnosisGroup == null ? "" : o.idfsDiagnosisOrDiagnosisGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosisOrDiagnosisGroup), o.IsInvisible(_str_idfsDiagnosisOrDiagnosisGroup), o.IsRequired(_str_idfsDiagnosisOrDiagnosisGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosisGroup, _formname = _str_idfsDiagnosisGroup, _type = "Int64?",
              _get_func = o => o.idfsDiagnosisGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsDiagnosisGroup != newval) o.idfsDiagnosisGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosisGroup != c.idfsDiagnosisGroup || o.IsRIRPropChanged(_str_idfsDiagnosisGroup, c)) 
                  m.Add(_str_idfsDiagnosisGroup, o.ObjectIdent + _str_idfsDiagnosisGroup, o.ObjectIdent2 + _str_idfsDiagnosisGroup, o.ObjectIdent3 + _str_idfsDiagnosisGroup, "Int64?", 
                    o.idfsDiagnosisGroup == null ? "" : o.idfsDiagnosisGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosisGroup), o.IsInvisible(_str_idfsDiagnosisGroup), o.IsRequired(_str_idfsDiagnosisGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_name, _formname = _str_name, _type = "String",
              _get_func = o => o.name,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.name != newval) o.name = newval; },
              _compare_func = (o, c, m) => {
                if (o.name != c.name || o.IsRIRPropChanged(_str_name, c)) 
                  m.Add(_str_name, o.ObjectIdent + _str_name, o.ObjectIdent2 + _str_name, o.ObjectIdent3 + _str_name, "String", 
                    o.name == null ? "" : o.name.ToString(),                  
                  o.IsReadOnly(_str_name), o.IsInvisible(_str_name), o.IsRequired(_str_name)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strIDC10, _formname = _str_strIDC10, _type = "String",
              _get_func = o => o.strIDC10,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strIDC10 != newval) o.strIDC10 = newval; },
              _compare_func = (o, c, m) => {
                if (o.strIDC10 != c.strIDC10 || o.IsRIRPropChanged(_str_strIDC10, c)) 
                  m.Add(_str_strIDC10, o.ObjectIdent + _str_strIDC10, o.ObjectIdent2 + _str_strIDC10, o.ObjectIdent3 + _str_strIDC10, "String", 
                    o.strIDC10 == null ? "" : o.strIDC10.ToString(),                  
                  o.IsReadOnly(_str_strIDC10), o.IsInvisible(_str_strIDC10), o.IsRequired(_str_strIDC10)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strOIECode, _formname = _str_strOIECode, _type = "String",
              _get_func = o => o.strOIECode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOIECode != newval) o.strOIECode = newval; },
              _compare_func = (o, c, m) => {
                if (o.strOIECode != c.strOIECode || o.IsRIRPropChanged(_str_strOIECode, c)) 
                  m.Add(_str_strOIECode, o.ObjectIdent + _str_strOIECode, o.ObjectIdent2 + _str_strOIECode, o.ObjectIdent3 + _str_strOIECode, "String", 
                    o.strOIECode == null ? "" : o.strOIECode.ToString(),                  
                  o.IsReadOnly(_str_strOIECode), o.IsInvisible(_str_strOIECode), o.IsRequired(_str_strOIECode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intHACode, _formname = _str_intHACode, _type = "Int32?",
              _get_func = o => o.intHACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intHACode != newval) o.intHACode = newval; },
              _compare_func = (o, c, m) => {
                if (o.intHACode != c.intHACode || o.IsRIRPropChanged(_str_intHACode, c)) 
                  m.Add(_str_intHACode, o.ObjectIdent + _str_intHACode, o.ObjectIdent2 + _str_intHACode, o.ObjectIdent3 + _str_intHACode, "Int32?", 
                    o.intHACode == null ? "" : o.intHACode.ToString(),                  
                  o.IsReadOnly(_str_intHACode), o.IsInvisible(_str_intHACode), o.IsRequired(_str_intHACode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intRowStatus, _formname = _str_intRowStatus, _type = "Int32?",
              _get_func = o => o.intRowStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intRowStatus != newval) o.intRowStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.intRowStatus != c.intRowStatus || o.IsRIRPropChanged(_str_intRowStatus, c)) 
                  m.Add(_str_intRowStatus, o.ObjectIdent + _str_intRowStatus, o.ObjectIdent2 + _str_intRowStatus, o.ObjectIdent3 + _str_intRowStatus, "Int32?", 
                    o.intRowStatus == null ? "" : o.intRowStatus.ToString(),                  
                  o.IsReadOnly(_str_intRowStatus), o.IsInvisible(_str_intRowStatus), o.IsRequired(_str_intRowStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnGroup, _formname = _str_blnGroup, _type = "Boolean?",
              _get_func = o => o.blnGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnGroup != newval) o.blnGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnGroup != c.blnGroup || o.IsRIRPropChanged(_str_blnGroup, c)) 
                  m.Add(_str_blnGroup, o.ObjectIdent + _str_blnGroup, o.ObjectIdent2 + _str_blnGroup, o.ObjectIdent3 + _str_blnGroup, "Boolean?", 
                    o.blnGroup == null ? "" : o.blnGroup.ToString(),                  
                  o.IsReadOnly(_str_blnGroup), o.IsInvisible(_str_blnGroup), o.IsRequired(_str_blnGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHACode, _formname = _str_strHACode, _type = "String",
              _get_func = o => o.strHACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHACode != newval) o.strHACode = newval; },
              _compare_func = (o, c, m) => {
                if (o.strHACode != c.strHACode || o.IsRIRPropChanged(_str_strHACode, c)) 
                  m.Add(_str_strHACode, o.ObjectIdent + _str_strHACode, o.ObjectIdent2 + _str_strHACode, o.ObjectIdent3 + _str_strHACode, "String", 
                    o.strHACode == null ? "" : o.strHACode.ToString(),                  
                  o.IsReadOnly(_str_strHACode), o.IsInvisible(_str_strHACode), o.IsRequired(_str_strHACode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strUsingTypeName, _formname = _str_strUsingTypeName, _type = "String",
              _get_func = o => o.strUsingTypeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strUsingTypeName != newval) o.strUsingTypeName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strUsingTypeName != c.strUsingTypeName || o.IsRIRPropChanged(_str_strUsingTypeName, c)) 
                  m.Add(_str_strUsingTypeName, o.ObjectIdent + _str_strUsingTypeName, o.ObjectIdent2 + _str_strUsingTypeName, o.ObjectIdent3 + _str_strUsingTypeName, "String", 
                    o.strUsingTypeName == null ? "" : o.strUsingTypeName.ToString(),                  
                  o.IsReadOnly(_str_strUsingTypeName), o.IsInvisible(_str_strUsingTypeName), o.IsRequired(_str_strUsingTypeName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intIsDeleted, _formname = _str_intIsDeleted, _type = "Int32?",
              _get_func = o => o.intIsDeleted,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intIsDeleted != newval) o.intIsDeleted = newval; },
              _compare_func = (o, c, m) => {
                if (o.intIsDeleted != c.intIsDeleted || o.IsRIRPropChanged(_str_intIsDeleted, c)) 
                  m.Add(_str_intIsDeleted, o.ObjectIdent + _str_intIsDeleted, o.ObjectIdent2 + _str_intIsDeleted, o.ObjectIdent3 + _str_intIsDeleted, "Int32?", 
                    o.intIsDeleted == null ? "" : o.intIsDeleted.ToString(),                  
                  o.IsReadOnly(_str_intIsDeleted), o.IsInvisible(_str_intIsDeleted), o.IsRequired(_str_intIsDeleted)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strIsDeleted, _formname = _str_strIsDeleted, _type = "String",
              _get_func = o => o.strIsDeleted,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strIsDeleted != newval) o.strIsDeleted = newval; },
              _compare_func = (o, c, m) => {
                if (o.strIsDeleted != c.strIsDeleted || o.IsRIRPropChanged(_str_strIsDeleted, c)) 
                  m.Add(_str_strIsDeleted, o.ObjectIdent + _str_strIsDeleted, o.ObjectIdent2 + _str_strIsDeleted, o.ObjectIdent3 + _str_strIsDeleted, "String", 
                    o.strIsDeleted == null ? "" : o.strIsDeleted.ToString(),                  
                  o.IsReadOnly(_str_strIsDeleted), o.IsInvisible(_str_strIsDeleted), o.IsRequired(_str_strIsDeleted)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intOrder, _formname = _str_intOrder, _type = "Int64?",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.intOrder != newval) o.intOrder = newval; },
              _compare_func = (o, c, m) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, o.ObjectIdent2 + _str_intOrder, o.ObjectIdent3 + _str_intOrder, "Int64?", 
                    o.intOrder == null ? "" : o.intOrder.ToString(),                  
                  o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); 
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
            DiagnosesAndGroupsLookup obj = (DiagnosesAndGroupsLookup)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "DiagnosesAndGroupsLookup";

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
            var ret = base.Clone() as DiagnosesAndGroupsLookup;
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
            var ret = base.Clone() as DiagnosesAndGroupsLookup;
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
        public DiagnosesAndGroupsLookup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as DiagnosesAndGroupsLookup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsDiagnosisOrDiagnosisGroup; } }
        public string KeyName { get { return "idfsDiagnosisOrDiagnosisGroup"; } }
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

        private bool IsRIRPropChanged(string fld, DiagnosesAndGroupsLookup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      
        public override string ToString()
        {
            return new Func<DiagnosesAndGroupsLookup, string>(c => c.name)(this);
        }
        

        public DiagnosesAndGroupsLookup()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(DiagnosesAndGroupsLookup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(DiagnosesAndGroupsLookup_PropertyChanged);
        }
        private void DiagnosesAndGroupsLookup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as DiagnosesAndGroupsLookup).Changed(e.PropertyName);
            
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
            DiagnosesAndGroupsLookup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            DiagnosesAndGroupsLookup obj = this;
            
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
        
            }
        }


        internal Dictionary<string, Func<DiagnosesAndGroupsLookup, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<DiagnosesAndGroupsLookup, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<DiagnosesAndGroupsLookup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<DiagnosesAndGroupsLookup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<DiagnosesAndGroupsLookup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<DiagnosesAndGroupsLookup, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<DiagnosesAndGroupsLookup, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~DiagnosesAndGroupsLookup()
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
        : DataAccessor<DiagnosesAndGroupsLookup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<DiagnosesAndGroupsLookup>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsDiagnosisOrDiagnosisGroup"; } }
            #endregion
        
            private delegate void on_action(DiagnosesAndGroupsLookup obj);
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
            [InstanceCache(typeof(BvCacheAspect))]
            public virtual List<DiagnosesAndGroupsLookup> SelectLookupList(DbManagerProxy manager
                , Int32? HACode
                , Int64? DiagnosisUsingType
                , Int64? idfsGroupReference
                )
            {
                return _SelectList(manager
                    , HACode
                    , DiagnosisUsingType
                    , idfsGroupReference
                    , null, null
                    );
            }
            
            public static string GetLookupTableName(string method)
            {
                return "DiagnosesAndGroups";
            }
            
            public virtual List<DiagnosesAndGroupsLookup> SelectList(DbManagerProxy manager
                , Int32? HACode
                , Int64? DiagnosisUsingType
                , Int64? idfsGroupReference
                )
            {
                return _SelectList(manager
                    , HACode
                    , DiagnosisUsingType
                    , idfsGroupReference
                    , delegate(DiagnosesAndGroupsLookup obj)
                        {
                        }
                    , delegate(DiagnosesAndGroupsLookup obj)
                        {
                        }
                    );
            }

            
            private List<DiagnosesAndGroupsLookup> _SelectList(DbManagerProxy manager
                , Int32? HACode
                , Int64? DiagnosisUsingType
                , Int64? idfsGroupReference
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<DiagnosesAndGroupsLookup> objs = new List<DiagnosesAndGroupsLookup>();
                    sets[0] = new MapResultSet(typeof(DiagnosesAndGroupsLookup), objs);
                    
                    manager
                        .SetSpCommand("spDiagnosesAndGroups_SelectLookup"
                            , manager.Parameter("@HACode", HACode)
                            , manager.Parameter("@DiagnosisUsingType", DiagnosisUsingType)
                            , manager.Parameter("@idfsGroupReference", idfsGroupReference)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, DiagnosesAndGroupsLookup obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, DiagnosesAndGroupsLookup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private DiagnosesAndGroupsLookup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    DiagnosesAndGroupsLookup obj = DiagnosesAndGroupsLookup.CreateInstance();
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
                    throw DbModelException.Create(e);
                }
            }

            
            public DiagnosesAndGroupsLookup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public DiagnosesAndGroupsLookup CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public DiagnosesAndGroupsLookup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(DiagnosesAndGroupsLookup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(DiagnosesAndGroupsLookup obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, DiagnosesAndGroupsLookup obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(DiagnosesAndGroupsLookup obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(DiagnosesAndGroupsLookup obj, bool bRethrowException)
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
                return Validate(manager, obj as DiagnosesAndGroupsLookup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, DiagnosesAndGroupsLookup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(DiagnosesAndGroupsLookup obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(DiagnosesAndGroupsLookup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as DiagnosesAndGroupsLookup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as DiagnosesAndGroupsLookup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "DiagnosesAndGroupsLookupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spDiagnosesAndGroups_SelectLookup";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<DiagnosesAndGroupsLookup, bool>> RequiredByField = new Dictionary<string, Func<DiagnosesAndGroupsLookup, bool>>();
            public static Dictionary<string, Func<DiagnosesAndGroupsLookup, bool>> RequiredByProperty = new Dictionary<string, Func<DiagnosesAndGroupsLookup, bool>>();
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
                
                Sizes.Add(_str_name, 2000);
                Sizes.Add(_str_strIDC10, 200);
                Sizes.Add(_str_strOIECode, 200);
                Sizes.Add(_str_strHACode, 200);
                Sizes.Add(_str_strUsingTypeName, 200);
                Sizes.Add(_str_strIsDeleted, 200);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<DiagnosesAndGroupsLookup>().Post(manager, (DiagnosesAndGroupsLookup)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<DiagnosesAndGroupsLookup>().Post(manager, (DiagnosesAndGroupsLookup)c), c),
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
                    (manager, c, pars) => new ActResult(((DiagnosesAndGroupsLookup)c).MarkToDelete() && ObjectAccessor.PostInterface<DiagnosesAndGroupsLookup>().Post(manager, (DiagnosesAndGroupsLookup)c), c),
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
	