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
    public abstract partial class Statistic : 
        EditableObject<Statistic>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfStatistic), NonUpdatable, PrimaryKey]
        public abstract Int64 idfStatistic { get; set; }
                
        [LocalizedDisplayName(_str_idfsStatisticDataType)]
        [MapField(_str_idfsStatisticDataType)]
        public abstract Int64 idfsStatisticDataType { get; set; }
        #if MONO
        protected Int64 idfsStatisticDataType_Original { get { return idfsStatisticDataType; } }
        protected Int64 idfsStatisticDataType_Previous { get { return idfsStatisticDataType; } }
        #else
        protected Int64 idfsStatisticDataType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsStatisticDataType).OriginalValue; } }
        protected Int64 idfsStatisticDataType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsStatisticDataType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsMainBaseReference)]
        [MapField(_str_idfsMainBaseReference)]
        public abstract Int64? idfsMainBaseReference { get; set; }
        #if MONO
        protected Int64? idfsMainBaseReference_Original { get { return idfsMainBaseReference; } }
        protected Int64? idfsMainBaseReference_Previous { get { return idfsMainBaseReference; } }
        #else
        protected Int64? idfsMainBaseReference_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMainBaseReference).OriginalValue; } }
        protected Int64? idfsMainBaseReference_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMainBaseReference).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsStatisticAreaType)]
        [MapField(_str_idfsStatisticAreaType)]
        public abstract Int64? idfsStatisticAreaType { get; set; }
        #if MONO
        protected Int64? idfsStatisticAreaType_Original { get { return idfsStatisticAreaType; } }
        protected Int64? idfsStatisticAreaType_Previous { get { return idfsStatisticAreaType; } }
        #else
        protected Int64? idfsStatisticAreaType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStatisticAreaType).OriginalValue; } }
        protected Int64? idfsStatisticAreaType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStatisticAreaType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsStatisticPeriodType)]
        [MapField(_str_idfsStatisticPeriodType)]
        public abstract Int64? idfsStatisticPeriodType { get; set; }
        #if MONO
        protected Int64? idfsStatisticPeriodType_Original { get { return idfsStatisticPeriodType; } }
        protected Int64? idfsStatisticPeriodType_Previous { get { return idfsStatisticPeriodType; } }
        #else
        protected Int64? idfsStatisticPeriodType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStatisticPeriodType).OriginalValue; } }
        protected Int64? idfsStatisticPeriodType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStatisticPeriodType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsArea)]
        [MapField(_str_idfsArea)]
        public abstract Int64 idfsArea { get; set; }
        #if MONO
        protected Int64 idfsArea_Original { get { return idfsArea; } }
        protected Int64 idfsArea_Previous { get { return idfsArea; } }
        #else
        protected Int64 idfsArea_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsArea).OriginalValue; } }
        protected Int64 idfsArea_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsArea).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datStatisticStartDate)]
        [MapField(_str_datStatisticStartDate)]
        public abstract DateTime? datStatisticStartDate { get; set; }
        #if MONO
        protected DateTime? datStatisticStartDate_Original { get { return datStatisticStartDate; } }
        protected DateTime? datStatisticStartDate_Previous { get { return datStatisticStartDate; } }
        #else
        protected DateTime? datStatisticStartDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStatisticStartDate).OriginalValue; } }
        protected DateTime? datStatisticStartDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStatisticStartDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datStatisticFinishDate)]
        [MapField(_str_datStatisticFinishDate)]
        public abstract DateTime? datStatisticFinishDate { get; set; }
        #if MONO
        protected DateTime? datStatisticFinishDate_Original { get { return datStatisticFinishDate; } }
        protected DateTime? datStatisticFinishDate_Previous { get { return datStatisticFinishDate; } }
        #else
        protected DateTime? datStatisticFinishDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStatisticFinishDate).OriginalValue; } }
        protected DateTime? datStatisticFinishDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStatisticFinishDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_varValue)]
        [MapField(_str_varValue)]
        public abstract Int64? varValue { get; set; }
        #if MONO
        protected Int64? varValue_Original { get { return varValue; } }
        protected Int64? varValue_Previous { get { return varValue; } }
        #else
        protected Int64? varValue_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._varValue).OriginalValue; } }
        protected Int64? varValue_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._varValue).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strParameterType)]
        [MapField(_str_strParameterType)]
        public abstract String strParameterType { get; set; }
        #if MONO
        protected String strParameterType_Original { get { return strParameterType; } }
        protected String strParameterType_Previous { get { return strParameterType; } }
        #else
        protected String strParameterType_Original { get { return ((EditableValue<String>)((dynamic)this)._strParameterType).OriginalValue; } }
        protected String strParameterType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strParameterType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsReferenceType)]
        [MapField(_str_idfsReferenceType)]
        public abstract Int64? idfsReferenceType { get; set; }
        #if MONO
        protected Int64? idfsReferenceType_Original { get { return idfsReferenceType; } }
        protected Int64? idfsReferenceType_Previous { get { return idfsReferenceType; } }
        #else
        protected Int64? idfsReferenceType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsReferenceType).OriginalValue; } }
        protected Int64? idfsReferenceType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsReferenceType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsStatisticalAgeGroup)]
        [MapField(_str_idfsStatisticalAgeGroup)]
        public abstract Int64? idfsStatisticalAgeGroup { get; set; }
        #if MONO
        protected Int64? idfsStatisticalAgeGroup_Original { get { return idfsStatisticalAgeGroup; } }
        protected Int64? idfsStatisticalAgeGroup_Previous { get { return idfsStatisticalAgeGroup; } }
        #else
        protected Int64? idfsStatisticalAgeGroup_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStatisticalAgeGroup).OriginalValue; } }
        protected Int64? idfsStatisticalAgeGroup_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStatisticalAgeGroup).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnRelatedWithAgeGroup)]
        [MapField(_str_blnRelatedWithAgeGroup)]
        public abstract Boolean? blnRelatedWithAgeGroup { get; set; }
        #if MONO
        protected Boolean? blnRelatedWithAgeGroup_Original { get { return blnRelatedWithAgeGroup; } }
        protected Boolean? blnRelatedWithAgeGroup_Previous { get { return blnRelatedWithAgeGroup; } }
        #else
        protected Boolean? blnRelatedWithAgeGroup_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnRelatedWithAgeGroup).OriginalValue; } }
        protected Boolean? blnRelatedWithAgeGroup_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnRelatedWithAgeGroup).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<Statistic, object> _get_func;
            internal Action<Statistic, string> _set_func;
            internal Action<Statistic, Statistic, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfStatistic = "idfStatistic";
        internal const string _str_idfsStatisticDataType = "idfsStatisticDataType";
        internal const string _str_idfsMainBaseReference = "idfsMainBaseReference";
        internal const string _str_idfsStatisticAreaType = "idfsStatisticAreaType";
        internal const string _str_idfsStatisticPeriodType = "idfsStatisticPeriodType";
        internal const string _str_idfsArea = "idfsArea";
        internal const string _str_datStatisticStartDate = "datStatisticStartDate";
        internal const string _str_datStatisticFinishDate = "datStatisticFinishDate";
        internal const string _str_varValue = "varValue";
        internal const string _str_strParameterType = "strParameterType";
        internal const string _str_idfsReferenceType = "idfsReferenceType";
        internal const string _str_idfsStatisticalAgeGroup = "idfsStatisticalAgeGroup";
        internal const string _str_blnRelatedWithAgeGroup = "blnRelatedWithAgeGroup";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfStatistic, _type = "Int64",
              _get_func = o => o.idfStatistic,
              _set_func = (o, val) => { o.idfStatistic = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfStatistic != c.idfStatistic || o.IsRIRPropChanged(_str_idfStatistic, c)) 
                  m.Add(_str_idfStatistic, o.ObjectIdent + _str_idfStatistic, "Int64", o.idfStatistic == null ? "" : o.idfStatistic.ToString(), o.IsReadOnly(_str_idfStatistic), o.IsInvisible(_str_idfStatistic), o.IsRequired(_str_idfStatistic)); }
              }, 
        
            new field_info {
              _name = _str_idfsStatisticDataType, _type = "Int64",
              _get_func = o => o.idfsStatisticDataType,
              _set_func = (o, val) => { o.idfsStatisticDataType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsStatisticDataType != c.idfsStatisticDataType || o.IsRIRPropChanged(_str_idfsStatisticDataType, c)) 
                  m.Add(_str_idfsStatisticDataType, o.ObjectIdent + _str_idfsStatisticDataType, "Int64", o.idfsStatisticDataType == null ? "" : o.idfsStatisticDataType.ToString(), o.IsReadOnly(_str_idfsStatisticDataType), o.IsInvisible(_str_idfsStatisticDataType), o.IsRequired(_str_idfsStatisticDataType)); }
              }, 
        
            new field_info {
              _name = _str_idfsMainBaseReference, _type = "Int64?",
              _get_func = o => o.idfsMainBaseReference,
              _set_func = (o, val) => { o.idfsMainBaseReference = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsMainBaseReference != c.idfsMainBaseReference || o.IsRIRPropChanged(_str_idfsMainBaseReference, c)) 
                  m.Add(_str_idfsMainBaseReference, o.ObjectIdent + _str_idfsMainBaseReference, "Int64?", o.idfsMainBaseReference == null ? "" : o.idfsMainBaseReference.ToString(), o.IsReadOnly(_str_idfsMainBaseReference), o.IsInvisible(_str_idfsMainBaseReference), o.IsRequired(_str_idfsMainBaseReference)); }
              }, 
        
            new field_info {
              _name = _str_idfsStatisticAreaType, _type = "Int64?",
              _get_func = o => o.idfsStatisticAreaType,
              _set_func = (o, val) => { o.idfsStatisticAreaType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsStatisticAreaType != c.idfsStatisticAreaType || o.IsRIRPropChanged(_str_idfsStatisticAreaType, c)) 
                  m.Add(_str_idfsStatisticAreaType, o.ObjectIdent + _str_idfsStatisticAreaType, "Int64?", o.idfsStatisticAreaType == null ? "" : o.idfsStatisticAreaType.ToString(), o.IsReadOnly(_str_idfsStatisticAreaType), o.IsInvisible(_str_idfsStatisticAreaType), o.IsRequired(_str_idfsStatisticAreaType)); }
              }, 
        
            new field_info {
              _name = _str_idfsStatisticPeriodType, _type = "Int64?",
              _get_func = o => o.idfsStatisticPeriodType,
              _set_func = (o, val) => { o.idfsStatisticPeriodType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsStatisticPeriodType != c.idfsStatisticPeriodType || o.IsRIRPropChanged(_str_idfsStatisticPeriodType, c)) 
                  m.Add(_str_idfsStatisticPeriodType, o.ObjectIdent + _str_idfsStatisticPeriodType, "Int64?", o.idfsStatisticPeriodType == null ? "" : o.idfsStatisticPeriodType.ToString(), o.IsReadOnly(_str_idfsStatisticPeriodType), o.IsInvisible(_str_idfsStatisticPeriodType), o.IsRequired(_str_idfsStatisticPeriodType)); }
              }, 
        
            new field_info {
              _name = _str_idfsArea, _type = "Int64",
              _get_func = o => o.idfsArea,
              _set_func = (o, val) => { o.idfsArea = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsArea != c.idfsArea || o.IsRIRPropChanged(_str_idfsArea, c)) 
                  m.Add(_str_idfsArea, o.ObjectIdent + _str_idfsArea, "Int64", o.idfsArea == null ? "" : o.idfsArea.ToString(), o.IsReadOnly(_str_idfsArea), o.IsInvisible(_str_idfsArea), o.IsRequired(_str_idfsArea)); }
              }, 
        
            new field_info {
              _name = _str_datStatisticStartDate, _type = "DateTime?",
              _get_func = o => o.datStatisticStartDate,
              _set_func = (o, val) => { o.datStatisticStartDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datStatisticStartDate != c.datStatisticStartDate || o.IsRIRPropChanged(_str_datStatisticStartDate, c)) 
                  m.Add(_str_datStatisticStartDate, o.ObjectIdent + _str_datStatisticStartDate, "DateTime?", o.datStatisticStartDate == null ? "" : o.datStatisticStartDate.ToString(), o.IsReadOnly(_str_datStatisticStartDate), o.IsInvisible(_str_datStatisticStartDate), o.IsRequired(_str_datStatisticStartDate)); }
              }, 
        
            new field_info {
              _name = _str_datStatisticFinishDate, _type = "DateTime?",
              _get_func = o => o.datStatisticFinishDate,
              _set_func = (o, val) => { o.datStatisticFinishDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datStatisticFinishDate != c.datStatisticFinishDate || o.IsRIRPropChanged(_str_datStatisticFinishDate, c)) 
                  m.Add(_str_datStatisticFinishDate, o.ObjectIdent + _str_datStatisticFinishDate, "DateTime?", o.datStatisticFinishDate == null ? "" : o.datStatisticFinishDate.ToString(), o.IsReadOnly(_str_datStatisticFinishDate), o.IsInvisible(_str_datStatisticFinishDate), o.IsRequired(_str_datStatisticFinishDate)); }
              }, 
        
            new field_info {
              _name = _str_varValue, _type = "Int64?",
              _get_func = o => o.varValue,
              _set_func = (o, val) => { o.varValue = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.varValue != c.varValue || o.IsRIRPropChanged(_str_varValue, c)) 
                  m.Add(_str_varValue, o.ObjectIdent + _str_varValue, "Int64?", o.varValue == null ? "" : o.varValue.ToString(), o.IsReadOnly(_str_varValue), o.IsInvisible(_str_varValue), o.IsRequired(_str_varValue)); }
              }, 
        
            new field_info {
              _name = _str_strParameterType, _type = "String",
              _get_func = o => o.strParameterType,
              _set_func = (o, val) => { o.strParameterType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strParameterType != c.strParameterType || o.IsRIRPropChanged(_str_strParameterType, c)) 
                  m.Add(_str_strParameterType, o.ObjectIdent + _str_strParameterType, "String", o.strParameterType == null ? "" : o.strParameterType.ToString(), o.IsReadOnly(_str_strParameterType), o.IsInvisible(_str_strParameterType), o.IsRequired(_str_strParameterType)); }
              }, 
        
            new field_info {
              _name = _str_idfsReferenceType, _type = "Int64?",
              _get_func = o => o.idfsReferenceType,
              _set_func = (o, val) => { o.idfsReferenceType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsReferenceType != c.idfsReferenceType || o.IsRIRPropChanged(_str_idfsReferenceType, c)) 
                  m.Add(_str_idfsReferenceType, o.ObjectIdent + _str_idfsReferenceType, "Int64?", o.idfsReferenceType == null ? "" : o.idfsReferenceType.ToString(), o.IsReadOnly(_str_idfsReferenceType), o.IsInvisible(_str_idfsReferenceType), o.IsRequired(_str_idfsReferenceType)); }
              }, 
        
            new field_info {
              _name = _str_idfsStatisticalAgeGroup, _type = "Int64?",
              _get_func = o => o.idfsStatisticalAgeGroup,
              _set_func = (o, val) => { o.idfsStatisticalAgeGroup = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsStatisticalAgeGroup != c.idfsStatisticalAgeGroup || o.IsRIRPropChanged(_str_idfsStatisticalAgeGroup, c)) 
                  m.Add(_str_idfsStatisticalAgeGroup, o.ObjectIdent + _str_idfsStatisticalAgeGroup, "Int64?", o.idfsStatisticalAgeGroup == null ? "" : o.idfsStatisticalAgeGroup.ToString(), o.IsReadOnly(_str_idfsStatisticalAgeGroup), o.IsInvisible(_str_idfsStatisticalAgeGroup), o.IsRequired(_str_idfsStatisticalAgeGroup)); }
              }, 
        
            new field_info {
              _name = _str_blnRelatedWithAgeGroup, _type = "Boolean?",
              _get_func = o => o.blnRelatedWithAgeGroup,
              _set_func = (o, val) => { o.blnRelatedWithAgeGroup = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnRelatedWithAgeGroup != c.blnRelatedWithAgeGroup || o.IsRIRPropChanged(_str_blnRelatedWithAgeGroup, c)) 
                  m.Add(_str_blnRelatedWithAgeGroup, o.ObjectIdent + _str_blnRelatedWithAgeGroup, "Boolean?", o.blnRelatedWithAgeGroup == null ? "" : o.blnRelatedWithAgeGroup.ToString(), o.IsReadOnly(_str_blnRelatedWithAgeGroup), o.IsInvisible(_str_blnRelatedWithAgeGroup), o.IsRequired(_str_blnRelatedWithAgeGroup)); }
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
            Statistic obj = (Statistic)o;
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
        internal string m_ObjectName = "Statistic";

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
        public override object Clone()
        {
            var ret = base.Clone() as Statistic;
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
            var ret = base.Clone() as Statistic;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public Statistic CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Statistic;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfStatistic; } }
        public string KeyName { get { return "idfStatistic"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
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

      private bool IsRIRPropChanged(string fld, Statistic c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public Statistic()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Statistic_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Statistic_PropertyChanged);
        }
        private void Statistic_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Statistic).Changed(e.PropertyName);
            
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
            Statistic obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Statistic obj = this;
            
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
        
            }
        }


        public Dictionary<string, Func<Statistic, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Statistic, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Statistic, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<Statistic, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<Statistic, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<Statistic, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~Statistic()
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
        
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<Statistic>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(Statistic obj);
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
                            
                        , null, null
                        );
                }
            }

            
            public virtual Statistic SelectByKey(DbManagerProxy manager
                , Int64? idfStatistic
                )
            {
                return _SelectByKey(manager
                    , idfStatistic
                    , null, null
                    );
            }
            
      
            private Statistic _SelectByKey(DbManagerProxy manager
                , Int64? idfStatistic
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<Statistic> objs = new List<Statistic>();
                sets[0] = new MapResultSet(typeof(Statistic), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spStatistic_SelectDetail"
                            , manager.Parameter("@idfStatistic", idfStatistic)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    Statistic obj = objs[0];
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, Statistic obj)
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
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, Statistic obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private Statistic _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    Statistic obj = Statistic.CreateInstance();
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

            
            public Statistic CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public Statistic CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(Statistic obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Statistic obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, Statistic obj)
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
                return Validate(manager, obj as Statistic, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Statistic obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(Statistic obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(Statistic obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Statistic) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Statistic) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "StatisticDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spStatistic_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Statistic, bool>> RequiredByField = new Dictionary<string, Func<Statistic, bool>>();
            public static Dictionary<string, Func<Statistic, bool>> RequiredByProperty = new Dictionary<string, Func<Statistic, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strParameterType, 2000);
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
                    (manager, c, pars) => new ActResult(((Statistic)c).MarkToDelete() && ObjectAccessor.PostInterface<Statistic>().Post(manager, (Statistic)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Statistic>().Post(manager, (Statistic)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Statistic>().Post(manager, (Statistic)c), c),
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
	