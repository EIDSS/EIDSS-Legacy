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
    public abstract partial class NextNumbers : 
        EditableObject<NextNumbers>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsNumberName), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsNumberName { get; set; }
                
        [LocalizedDisplayName(_str_strPrefix)]
        [MapField(_str_strPrefix)]
        public abstract String strPrefix { get; set; }
        #if MONO
        protected String strPrefix_Original { get { return strPrefix; } }
        protected String strPrefix_Previous { get { return strPrefix; } }
        #else
        protected String strPrefix_Original { get { return ((EditableValue<String>)((dynamic)this)._strPrefix).OriginalValue; } }
        protected String strPrefix_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPrefix).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSuffix)]
        [MapField(_str_strSuffix)]
        public abstract String strSuffix { get; set; }
        #if MONO
        protected String strSuffix_Original { get { return strSuffix; } }
        protected String strSuffix_Previous { get { return strSuffix; } }
        #else
        protected String strSuffix_Original { get { return ((EditableValue<String>)((dynamic)this)._strSuffix).OriginalValue; } }
        protected String strSuffix_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSuffix).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intNumberValue)]
        [MapField(_str_intNumberValue)]
        public abstract Int64? intNumberValue { get; set; }
        #if MONO
        protected Int64? intNumberValue_Original { get { return intNumberValue; } }
        protected Int64? intNumberValue_Previous { get { return intNumberValue; } }
        #else
        protected Int64? intNumberValue_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._intNumberValue).OriginalValue; } }
        protected Int64? intNumberValue_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._intNumberValue).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intMinNumberLength)]
        [MapField(_str_intMinNumberLength)]
        public abstract Int32? intMinNumberLength { get; set; }
        #if MONO
        protected Int32? intMinNumberLength_Original { get { return intMinNumberLength; } }
        protected Int32? intMinNumberLength_Previous { get { return intMinNumberLength; } }
        #else
        protected Int32? intMinNumberLength_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intMinNumberLength).OriginalValue; } }
        protected Int32? intMinNumberLength_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intMinNumberLength).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strObjectName)]
        [MapField(_str_strObjectName)]
        public abstract String strObjectName { get; set; }
        #if MONO
        protected String strObjectName_Original { get { return strObjectName; } }
        protected String strObjectName_Previous { get { return strObjectName; } }
        #else
        protected String strObjectName_Original { get { return ((EditableValue<String>)((dynamic)this)._strObjectName).OriginalValue; } }
        protected String strObjectName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strObjectName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strEnglishName)]
        [MapField(_str_strEnglishName)]
        public abstract String strEnglishName { get; set; }
        #if MONO
        protected String strEnglishName_Original { get { return strEnglishName; } }
        protected String strEnglishName_Previous { get { return strEnglishName; } }
        #else
        protected String strEnglishName_Original { get { return ((EditableValue<String>)((dynamic)this)._strEnglishName).OriginalValue; } }
        protected String strEnglishName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strEnglishName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnUsePrefix)]
        [MapField(_str_blnUsePrefix)]
        public abstract Boolean? blnUsePrefix { get; set; }
        #if MONO
        protected Boolean? blnUsePrefix_Original { get { return blnUsePrefix; } }
        protected Boolean? blnUsePrefix_Previous { get { return blnUsePrefix; } }
        #else
        protected Boolean? blnUsePrefix_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnUsePrefix).OriginalValue; } }
        protected Boolean? blnUsePrefix_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnUsePrefix).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnUseSiteID)]
        [MapField(_str_blnUseSiteID)]
        public abstract Boolean? blnUseSiteID { get; set; }
        #if MONO
        protected Boolean? blnUseSiteID_Original { get { return blnUseSiteID; } }
        protected Boolean? blnUseSiteID_Previous { get { return blnUseSiteID; } }
        #else
        protected Boolean? blnUseSiteID_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnUseSiteID).OriginalValue; } }
        protected Boolean? blnUseSiteID_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnUseSiteID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnUseYear)]
        [MapField(_str_blnUseYear)]
        public abstract Boolean? blnUseYear { get; set; }
        #if MONO
        protected Boolean? blnUseYear_Original { get { return blnUseYear; } }
        protected Boolean? blnUseYear_Previous { get { return blnUseYear; } }
        #else
        protected Boolean? blnUseYear_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnUseYear).OriginalValue; } }
        protected Boolean? blnUseYear_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnUseYear).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnUseHACSCodeSite)]
        [MapField(_str_blnUseHACSCodeSite)]
        public abstract Boolean? blnUseHACSCodeSite { get; set; }
        #if MONO
        protected Boolean? blnUseHACSCodeSite_Original { get { return blnUseHACSCodeSite; } }
        protected Boolean? blnUseHACSCodeSite_Previous { get { return blnUseHACSCodeSite; } }
        #else
        protected Boolean? blnUseHACSCodeSite_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnUseHACSCodeSite).OriginalValue; } }
        protected Boolean? blnUseHACSCodeSite_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnUseHACSCodeSite).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnUseAlphaNumericValue)]
        [MapField(_str_blnUseAlphaNumericValue)]
        public abstract Boolean? blnUseAlphaNumericValue { get; set; }
        #if MONO
        protected Boolean? blnUseAlphaNumericValue_Original { get { return blnUseAlphaNumericValue; } }
        protected Boolean? blnUseAlphaNumericValue_Previous { get { return blnUseAlphaNumericValue; } }
        #else
        protected Boolean? blnUseAlphaNumericValue_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnUseAlphaNumericValue).OriginalValue; } }
        protected Boolean? blnUseAlphaNumericValue_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnUseAlphaNumericValue).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intYear)]
        [MapField(_str_intYear)]
        public abstract Int32? intYear { get; set; }
        #if MONO
        protected Int32? intYear_Original { get { return intYear; } }
        protected Int32? intYear_Previous { get { return intYear; } }
        #else
        protected Int32? intYear_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intYear).OriginalValue; } }
        protected Int32? intYear_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intYear).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<NextNumbers, object> _get_func;
            internal Action<NextNumbers, string> _set_func;
            internal Action<NextNumbers, NextNumbers, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsNumberName = "idfsNumberName";
        internal const string _str_strPrefix = "strPrefix";
        internal const string _str_strSuffix = "strSuffix";
        internal const string _str_intNumberValue = "intNumberValue";
        internal const string _str_intMinNumberLength = "intMinNumberLength";
        internal const string _str_strObjectName = "strObjectName";
        internal const string _str_strEnglishName = "strEnglishName";
        internal const string _str_blnUsePrefix = "blnUsePrefix";
        internal const string _str_blnUseSiteID = "blnUseSiteID";
        internal const string _str_blnUseYear = "blnUseYear";
        internal const string _str_blnUseHACSCodeSite = "blnUseHACSCodeSite";
        internal const string _str_blnUseAlphaNumericValue = "blnUseAlphaNumericValue";
        internal const string _str_intYear = "intYear";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfsNumberName, _type = "Int64",
              _get_func = o => o.idfsNumberName,
              _set_func = (o, val) => { o.idfsNumberName = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsNumberName != c.idfsNumberName || o.IsRIRPropChanged(_str_idfsNumberName, c)) 
                  m.Add(_str_idfsNumberName, o.ObjectIdent + _str_idfsNumberName, "Int64", o.idfsNumberName == null ? "" : o.idfsNumberName.ToString(), o.IsReadOnly(_str_idfsNumberName), o.IsInvisible(_str_idfsNumberName), o.IsRequired(_str_idfsNumberName)); }
              }, 
        
            new field_info {
              _name = _str_strPrefix, _type = "String",
              _get_func = o => o.strPrefix,
              _set_func = (o, val) => { o.strPrefix = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strPrefix != c.strPrefix || o.IsRIRPropChanged(_str_strPrefix, c)) 
                  m.Add(_str_strPrefix, o.ObjectIdent + _str_strPrefix, "String", o.strPrefix == null ? "" : o.strPrefix.ToString(), o.IsReadOnly(_str_strPrefix), o.IsInvisible(_str_strPrefix), o.IsRequired(_str_strPrefix)); }
              }, 
        
            new field_info {
              _name = _str_strSuffix, _type = "String",
              _get_func = o => o.strSuffix,
              _set_func = (o, val) => { o.strSuffix = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSuffix != c.strSuffix || o.IsRIRPropChanged(_str_strSuffix, c)) 
                  m.Add(_str_strSuffix, o.ObjectIdent + _str_strSuffix, "String", o.strSuffix == null ? "" : o.strSuffix.ToString(), o.IsReadOnly(_str_strSuffix), o.IsInvisible(_str_strSuffix), o.IsRequired(_str_strSuffix)); }
              }, 
        
            new field_info {
              _name = _str_intNumberValue, _type = "Int64?",
              _get_func = o => o.intNumberValue,
              _set_func = (o, val) => { o.intNumberValue = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intNumberValue != c.intNumberValue || o.IsRIRPropChanged(_str_intNumberValue, c)) 
                  m.Add(_str_intNumberValue, o.ObjectIdent + _str_intNumberValue, "Int64?", o.intNumberValue == null ? "" : o.intNumberValue.ToString(), o.IsReadOnly(_str_intNumberValue), o.IsInvisible(_str_intNumberValue), o.IsRequired(_str_intNumberValue)); }
              }, 
        
            new field_info {
              _name = _str_intMinNumberLength, _type = "Int32?",
              _get_func = o => o.intMinNumberLength,
              _set_func = (o, val) => { o.intMinNumberLength = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intMinNumberLength != c.intMinNumberLength || o.IsRIRPropChanged(_str_intMinNumberLength, c)) 
                  m.Add(_str_intMinNumberLength, o.ObjectIdent + _str_intMinNumberLength, "Int32?", o.intMinNumberLength == null ? "" : o.intMinNumberLength.ToString(), o.IsReadOnly(_str_intMinNumberLength), o.IsInvisible(_str_intMinNumberLength), o.IsRequired(_str_intMinNumberLength)); }
              }, 
        
            new field_info {
              _name = _str_strObjectName, _type = "String",
              _get_func = o => o.strObjectName,
              _set_func = (o, val) => { o.strObjectName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strObjectName != c.strObjectName || o.IsRIRPropChanged(_str_strObjectName, c)) 
                  m.Add(_str_strObjectName, o.ObjectIdent + _str_strObjectName, "String", o.strObjectName == null ? "" : o.strObjectName.ToString(), o.IsReadOnly(_str_strObjectName), o.IsInvisible(_str_strObjectName), o.IsRequired(_str_strObjectName)); }
              }, 
        
            new field_info {
              _name = _str_strEnglishName, _type = "String",
              _get_func = o => o.strEnglishName,
              _set_func = (o, val) => { o.strEnglishName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strEnglishName != c.strEnglishName || o.IsRIRPropChanged(_str_strEnglishName, c)) 
                  m.Add(_str_strEnglishName, o.ObjectIdent + _str_strEnglishName, "String", o.strEnglishName == null ? "" : o.strEnglishName.ToString(), o.IsReadOnly(_str_strEnglishName), o.IsInvisible(_str_strEnglishName), o.IsRequired(_str_strEnglishName)); }
              }, 
        
            new field_info {
              _name = _str_blnUsePrefix, _type = "Boolean?",
              _get_func = o => o.blnUsePrefix,
              _set_func = (o, val) => { o.blnUsePrefix = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnUsePrefix != c.blnUsePrefix || o.IsRIRPropChanged(_str_blnUsePrefix, c)) 
                  m.Add(_str_blnUsePrefix, o.ObjectIdent + _str_blnUsePrefix, "Boolean?", o.blnUsePrefix == null ? "" : o.blnUsePrefix.ToString(), o.IsReadOnly(_str_blnUsePrefix), o.IsInvisible(_str_blnUsePrefix), o.IsRequired(_str_blnUsePrefix)); }
              }, 
        
            new field_info {
              _name = _str_blnUseSiteID, _type = "Boolean?",
              _get_func = o => o.blnUseSiteID,
              _set_func = (o, val) => { o.blnUseSiteID = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnUseSiteID != c.blnUseSiteID || o.IsRIRPropChanged(_str_blnUseSiteID, c)) 
                  m.Add(_str_blnUseSiteID, o.ObjectIdent + _str_blnUseSiteID, "Boolean?", o.blnUseSiteID == null ? "" : o.blnUseSiteID.ToString(), o.IsReadOnly(_str_blnUseSiteID), o.IsInvisible(_str_blnUseSiteID), o.IsRequired(_str_blnUseSiteID)); }
              }, 
        
            new field_info {
              _name = _str_blnUseYear, _type = "Boolean?",
              _get_func = o => o.blnUseYear,
              _set_func = (o, val) => { o.blnUseYear = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnUseYear != c.blnUseYear || o.IsRIRPropChanged(_str_blnUseYear, c)) 
                  m.Add(_str_blnUseYear, o.ObjectIdent + _str_blnUseYear, "Boolean?", o.blnUseYear == null ? "" : o.blnUseYear.ToString(), o.IsReadOnly(_str_blnUseYear), o.IsInvisible(_str_blnUseYear), o.IsRequired(_str_blnUseYear)); }
              }, 
        
            new field_info {
              _name = _str_blnUseHACSCodeSite, _type = "Boolean?",
              _get_func = o => o.blnUseHACSCodeSite,
              _set_func = (o, val) => { o.blnUseHACSCodeSite = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnUseHACSCodeSite != c.blnUseHACSCodeSite || o.IsRIRPropChanged(_str_blnUseHACSCodeSite, c)) 
                  m.Add(_str_blnUseHACSCodeSite, o.ObjectIdent + _str_blnUseHACSCodeSite, "Boolean?", o.blnUseHACSCodeSite == null ? "" : o.blnUseHACSCodeSite.ToString(), o.IsReadOnly(_str_blnUseHACSCodeSite), o.IsInvisible(_str_blnUseHACSCodeSite), o.IsRequired(_str_blnUseHACSCodeSite)); }
              }, 
        
            new field_info {
              _name = _str_blnUseAlphaNumericValue, _type = "Boolean?",
              _get_func = o => o.blnUseAlphaNumericValue,
              _set_func = (o, val) => { o.blnUseAlphaNumericValue = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnUseAlphaNumericValue != c.blnUseAlphaNumericValue || o.IsRIRPropChanged(_str_blnUseAlphaNumericValue, c)) 
                  m.Add(_str_blnUseAlphaNumericValue, o.ObjectIdent + _str_blnUseAlphaNumericValue, "Boolean?", o.blnUseAlphaNumericValue == null ? "" : o.blnUseAlphaNumericValue.ToString(), o.IsReadOnly(_str_blnUseAlphaNumericValue), o.IsInvisible(_str_blnUseAlphaNumericValue), o.IsRequired(_str_blnUseAlphaNumericValue)); }
              }, 
        
            new field_info {
              _name = _str_intYear, _type = "Int32?",
              _get_func = o => o.intYear,
              _set_func = (o, val) => { o.intYear = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intYear != c.intYear || o.IsRIRPropChanged(_str_intYear, c)) 
                  m.Add(_str_intYear, o.ObjectIdent + _str_intYear, "Int32?", o.intYear == null ? "" : o.intYear.ToString(), o.IsReadOnly(_str_intYear), o.IsInvisible(_str_intYear), o.IsRequired(_str_intYear)); }
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
            NextNumbers obj = (NextNumbers)o;
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
        internal string m_ObjectName = "NextNumbers";

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
            var ret = base.Clone() as NextNumbers;
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
            var ret = base.Clone() as NextNumbers;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public NextNumbers CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as NextNumbers;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsNumberName; } }
        public string KeyName { get { return "idfsNumberName"; } }
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

      private bool IsRIRPropChanged(string fld, NextNumbers c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public NextNumbers()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(NextNumbers_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(NextNumbers_PropertyChanged);
        }
        private void NextNumbers_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as NextNumbers).Changed(e.PropertyName);
            
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
            NextNumbers obj = this;
            
        }
        private void _DeletedExtenders()
        {
            NextNumbers obj = this;
            
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


        public Dictionary<string, Func<NextNumbers, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<NextNumbers, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<NextNumbers, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<NextNumbers, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<NextNumbers, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<NextNumbers, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~NextNumbers()
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
        : DataAccessor<NextNumbers>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(NextNumbers obj);
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

            
            public virtual NextNumbers SelectByKey(DbManagerProxy manager
                , Int64? idfsNumberName
                )
            {
                return _SelectByKey(manager
                    , idfsNumberName
                    , null, null
                    );
            }
            
      
            private NextNumbers _SelectByKey(DbManagerProxy manager
                , Int64? idfsNumberName
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<NextNumbers> objs = new List<NextNumbers>();
                sets[0] = new MapResultSet(typeof(NextNumbers), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spNextNumbers_SelectDetail"
                            , manager.Parameter("@idfsNumberName", idfsNumberName)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    NextNumbers obj = objs[0];
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, NextNumbers obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, NextNumbers obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private NextNumbers _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    NextNumbers obj = NextNumbers.CreateInstance();
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

            
            public NextNumbers CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public NextNumbers CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(NextNumbers obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(NextNumbers obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, NextNumbers obj)
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
                return Validate(manager, obj as NextNumbers, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, NextNumbers obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(NextNumbers obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(NextNumbers obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as NextNumbers) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as NextNumbers) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "NextNumbersDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spNextNumbers_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<NextNumbers, bool>> RequiredByField = new Dictionary<string, Func<NextNumbers, bool>>();
            public static Dictionary<string, Func<NextNumbers, bool>> RequiredByProperty = new Dictionary<string, Func<NextNumbers, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strPrefix, 50);
                Sizes.Add(_str_strSuffix, 50);
                Sizes.Add(_str_strObjectName, 200);
                Sizes.Add(_str_strEnglishName, 200);
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
                    (manager, c, pars) => new ActResult(((NextNumbers)c).MarkToDelete() && ObjectAccessor.PostInterface<NextNumbers>().Post(manager, (NextNumbers)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<NextNumbers>().Post(manager, (NextNumbers)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<NextNumbers>().Post(manager, (NextNumbers)c), c),
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
	