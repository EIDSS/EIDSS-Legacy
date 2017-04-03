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
    public abstract partial class LabSampleDispositionListItem : 
        EditableObject<LabSampleDispositionListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfMaterial), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMaterial { get; set; }
                
        [LocalizedDisplayName("strLabBarcode")]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSampleStatus)]
        [MapField(_str_idfsSampleStatus)]
        public abstract Int64? idfsSampleStatus { get; set; }
        protected Int64? idfsSampleStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleStatus).OriginalValue; } }
        protected Int64? idfsSampleStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSampleStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSampleName)]
        [MapField(_str_strSampleName)]
        public abstract String strSampleName { get; set; }
        protected String strSampleName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).OriginalValue; } }
        protected String strSampleName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSampleType)]
        [MapField(_str_idfsSampleType)]
        public abstract Int64 idfsSampleType { get; set; }
        protected Int64 idfsSampleType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSampleType).OriginalValue; } }
        protected Int64 idfsSampleType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSampleType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsDestructionMethod)]
        [MapField(_str_idfsDestructionMethod)]
        public abstract Int64? idfsDestructionMethod { get; set; }
        protected Int64? idfsDestructionMethod_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDestructionMethod).OriginalValue; } }
        protected Int64? idfsDestructionMethod_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDestructionMethod).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DestructionMethod)]
        [MapField(_str_DestructionMethod)]
        public abstract String DestructionMethod { get; set; }
        protected String DestructionMethod_Original { get { return ((EditableValue<String>)((dynamic)this)._destructionMethod).OriginalValue; } }
        protected String DestructionMethod_Previous { get { return ((EditableValue<String>)((dynamic)this)._destructionMethod).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<LabSampleDispositionListItem, object> _get_func;
            internal Action<LabSampleDispositionListItem, string> _set_func;
            internal Action<LabSampleDispositionListItem, LabSampleDispositionListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_idfsSampleStatus = "idfsSampleStatus";
        internal const string _str_strSampleName = "strSampleName";
        internal const string _str_idfsSampleType = "idfsSampleType";
        internal const string _str_idfsDestructionMethod = "idfsDestructionMethod";
        internal const string _str_DestructionMethod = "DestructionMethod";
        internal const string _str_SampleType = "SampleType";
        internal const string _str_Destruction = "Destruction";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfMaterial, _formname = _str_idfMaterial, _type = "Int64",
              _get_func = o => o.idfMaterial,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfMaterial != newval) o.idfMaterial = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfMaterial != c.idfMaterial || o.IsRIRPropChanged(_str_idfMaterial, c)) 
                  m.Add(_str_idfMaterial, o.ObjectIdent + _str_idfMaterial, o.ObjectIdent2 + _str_idfMaterial, o.ObjectIdent3 + _str_idfMaterial, "Int64", 
                    o.idfMaterial == null ? "" : o.idfMaterial.ToString(),                  
                  o.IsReadOnly(_str_idfMaterial), o.IsInvisible(_str_idfMaterial), o.IsRequired(_str_idfMaterial)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strBarcode, _formname = _str_strBarcode, _type = "String",
              _get_func = o => o.strBarcode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strBarcode != newval) o.strBarcode = newval; },
              _compare_func = (o, c, m) => {
                if (o.strBarcode != c.strBarcode || o.IsRIRPropChanged(_str_strBarcode, c)) 
                  m.Add(_str_strBarcode, o.ObjectIdent + _str_strBarcode, o.ObjectIdent2 + _str_strBarcode, o.ObjectIdent3 + _str_strBarcode, "String", 
                    o.strBarcode == null ? "" : o.strBarcode.ToString(),                  
                  o.IsReadOnly(_str_strBarcode), o.IsInvisible(_str_strBarcode), o.IsRequired(_str_strBarcode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSampleStatus, _formname = _str_idfsSampleStatus, _type = "Int64?",
              _get_func = o => o.idfsSampleStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSampleStatus != newval) o.idfsSampleStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSampleStatus != c.idfsSampleStatus || o.IsRIRPropChanged(_str_idfsSampleStatus, c)) 
                  m.Add(_str_idfsSampleStatus, o.ObjectIdent + _str_idfsSampleStatus, o.ObjectIdent2 + _str_idfsSampleStatus, o.ObjectIdent3 + _str_idfsSampleStatus, "Int64?", 
                    o.idfsSampleStatus == null ? "" : o.idfsSampleStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsSampleStatus), o.IsInvisible(_str_idfsSampleStatus), o.IsRequired(_str_idfsSampleStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSampleName, _formname = _str_strSampleName, _type = "String",
              _get_func = o => o.strSampleName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSampleName != newval) o.strSampleName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSampleName != c.strSampleName || o.IsRIRPropChanged(_str_strSampleName, c)) 
                  m.Add(_str_strSampleName, o.ObjectIdent + _str_strSampleName, o.ObjectIdent2 + _str_strSampleName, o.ObjectIdent3 + _str_strSampleName, "String", 
                    o.strSampleName == null ? "" : o.strSampleName.ToString(),                  
                  o.IsReadOnly(_str_strSampleName), o.IsInvisible(_str_strSampleName), o.IsRequired(_str_strSampleName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSampleType, _formname = _str_idfsSampleType, _type = "Int64",
              _get_func = o => o.idfsSampleType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsSampleType != newval) 
                  o.SampleType = o.SampleTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsSampleType != newval) o.idfsSampleType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSampleType != c.idfsSampleType || o.IsRIRPropChanged(_str_idfsSampleType, c)) 
                  m.Add(_str_idfsSampleType, o.ObjectIdent + _str_idfsSampleType, o.ObjectIdent2 + _str_idfsSampleType, o.ObjectIdent3 + _str_idfsSampleType, "Int64", 
                    o.idfsSampleType == null ? "" : o.idfsSampleType.ToString(),                  
                  o.IsReadOnly(_str_idfsSampleType), o.IsInvisible(_str_idfsSampleType), o.IsRequired(_str_idfsSampleType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDestructionMethod, _formname = _str_idfsDestructionMethod, _type = "Int64?",
              _get_func = o => o.idfsDestructionMethod,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsDestructionMethod != newval) 
                  o.Destruction = o.DestructionLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsDestructionMethod != newval) o.idfsDestructionMethod = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDestructionMethod != c.idfsDestructionMethod || o.IsRIRPropChanged(_str_idfsDestructionMethod, c)) 
                  m.Add(_str_idfsDestructionMethod, o.ObjectIdent + _str_idfsDestructionMethod, o.ObjectIdent2 + _str_idfsDestructionMethod, o.ObjectIdent3 + _str_idfsDestructionMethod, "Int64?", 
                    o.idfsDestructionMethod == null ? "" : o.idfsDestructionMethod.ToString(),                  
                  o.IsReadOnly(_str_idfsDestructionMethod), o.IsInvisible(_str_idfsDestructionMethod), o.IsRequired(_str_idfsDestructionMethod)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DestructionMethod, _formname = _str_DestructionMethod, _type = "String",
              _get_func = o => o.DestructionMethod,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DestructionMethod != newval) o.DestructionMethod = newval; },
              _compare_func = (o, c, m) => {
                if (o.DestructionMethod != c.DestructionMethod || o.IsRIRPropChanged(_str_DestructionMethod, c)) 
                  m.Add(_str_DestructionMethod, o.ObjectIdent + _str_DestructionMethod, o.ObjectIdent2 + _str_DestructionMethod, o.ObjectIdent3 + _str_DestructionMethod, "String", 
                    o.DestructionMethod == null ? "" : o.DestructionMethod.ToString(),                  
                  o.IsReadOnly(_str_DestructionMethod), o.IsInvisible(_str_DestructionMethod), o.IsRequired(_str_DestructionMethod)); 
                  }
              }, 
        
            new field_info {
              _name = _str_SampleType, _formname = _str_SampleType, _type = "Lookup",
              _get_func = o => { if (o.SampleType == null) return null; return o.SampleType.idfsBaseReference; },
              _set_func = (o, val) => { o.SampleType = o.SampleTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSampleType != c.idfsSampleType || o.IsRIRPropChanged(_str_SampleType, c)) {
                  m.Add(_str_SampleType, o.ObjectIdent + _str_SampleType, o.ObjectIdent2 + _str_SampleType, o.ObjectIdent3 + _str_SampleType, "Lookup", o.idfsSampleType == null ? "" : o.idfsSampleType.ToString(), o.IsReadOnly(_str_SampleType), o.IsInvisible(_str_SampleType), o.IsRequired(_str_SampleType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SampleType + "Lookup", _formname = _str_SampleType + "Lookup", _type = "LookupContent",
              _get_func = o => o.SampleTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Destruction, _formname = _str_Destruction, _type = "Lookup",
              _get_func = o => { if (o.Destruction == null) return null; return o.Destruction.idfsBaseReference; },
              _set_func = (o, val) => { o.Destruction = o.DestructionLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDestructionMethod != c.idfsDestructionMethod || o.IsRIRPropChanged(_str_Destruction, c)) {
                  m.Add(_str_Destruction, o.ObjectIdent + _str_Destruction, o.ObjectIdent2 + _str_Destruction, o.ObjectIdent3 + _str_Destruction, "Lookup", o.idfsDestructionMethod == null ? "" : o.idfsDestructionMethod.ToString(), o.IsReadOnly(_str_Destruction), o.IsInvisible(_str_Destruction), o.IsRequired(_str_Destruction)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Destruction + "Lookup", _formname = _str_Destruction + "Lookup", _type = "LookupContent",
              _get_func = o => o.DestructionLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
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
            LabSampleDispositionListItem obj = (LabSampleDispositionListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_SampleType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSampleType)]
        public BaseReference SampleType
        {
            get { return _SampleType == null ? null : ((long)_SampleType.Key == 0 ? null : _SampleType); }
            set 
            { 
                var oldVal = _SampleType;
                _SampleType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SampleType != oldVal)
                {
                    if (idfsSampleType != (_SampleType == null
                            ? new Int64()
                            : (Int64)_SampleType.idfsBaseReference))
                        idfsSampleType = _SampleType == null 
                            ? new Int64()
                            : (Int64)_SampleType.idfsBaseReference; 
                    OnPropertyChanged(_str_SampleType); 
                }
            }
        }
        private BaseReference _SampleType;

        
        public BaseReferenceList SampleTypeLookup
        {
            get { return _SampleTypeLookup; }
        }
        private BaseReferenceList _SampleTypeLookup = new BaseReferenceList("rftSampleType");
            
        [LocalizedDisplayName(_str_Destruction)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsDestructionMethod)]
        public BaseReference Destruction
        {
            get { return _Destruction == null ? null : ((long)_Destruction.Key == 0 ? null : _Destruction); }
            set 
            { 
                var oldVal = _Destruction;
                _Destruction = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Destruction != oldVal)
                {
                    if (idfsDestructionMethod != (_Destruction == null
                            ? new Int64?()
                            : (Int64?)_Destruction.idfsBaseReference))
                        idfsDestructionMethod = _Destruction == null 
                            ? new Int64?()
                            : (Int64?)_Destruction.idfsBaseReference; 
                    OnPropertyChanged(_str_Destruction); 
                }
            }
        }
        private BaseReference _Destruction;

        
        public BaseReferenceList DestructionLookup
        {
            get { return _DestructionLookup; }
        }
        private BaseReferenceList _DestructionLookup = new BaseReferenceList("rftDestructionMethod");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_SampleType:
                    return new BvSelectList(SampleTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SampleType, _str_idfsSampleType);
            
                case _str_Destruction:
                    return new BvSelectList(DestructionLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Destruction, _str_idfsDestructionMethod);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LabSampleDispositionListItem";

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
            var ret = base.Clone() as LabSampleDispositionListItem;
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
            var ret = base.Clone() as LabSampleDispositionListItem;
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
        public LabSampleDispositionListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabSampleDispositionListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfMaterial; } }
        public string KeyName { get { return "idfMaterial"; } }
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
        
            var _prev_idfsSampleType_SampleType = idfsSampleType;
            var _prev_idfsDestructionMethod_Destruction = idfsDestructionMethod;
            base.RejectChanges();
        
            if (_prev_idfsSampleType_SampleType != idfsSampleType)
            {
                _SampleType = _SampleTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSampleType);
            }
            if (_prev_idfsDestructionMethod_Destruction != idfsDestructionMethod)
            {
                _Destruction = _DestructionLookup.FirstOrDefault(c => c.idfsBaseReference == idfsDestructionMethod);
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

        private bool IsRIRPropChanged(string fld, LabSampleDispositionListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public LabSampleDispositionListItem()
        {
            
            m_permissions = new Permissions(this);
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabSampleDispositionListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabSampleDispositionListItem_PropertyChanged);
        }
        private void LabSampleDispositionListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabSampleDispositionListItem).Changed(e.PropertyName);
            
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
            LabSampleDispositionListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabSampleDispositionListItem obj = this;
            
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


        internal Dictionary<string, Func<LabSampleDispositionListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<LabSampleDispositionListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabSampleDispositionListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabSampleDispositionListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<LabSampleDispositionListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabSampleDispositionListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<LabSampleDispositionListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LabSampleDispositionListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftSampleType", this);
                
                LookupManager.RemoveObject("rftDestructionMethod", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftSampleType")
                _getAccessor().LoadLookup_SampleType(manager, this);
            
            if (lookup_object == "rftDestructionMethod")
                _getAccessor().LoadLookup_Destruction(manager, this);
            
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
    
        #region Class for web grid
        public class LabSampleDispositionListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfMaterial { get; set; }
        
            public String strBarcode { get; set; }
        
            public String strSampleName { get; set; }
        
            public String DestructionMethod { get; set; }
        
        }
        public partial class LabSampleDispositionListItemGridModelList : List<LabSampleDispositionListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public LabSampleDispositionListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabSampleDispositionListItem>, errMes);
            }
            public LabSampleDispositionListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabSampleDispositionListItem>, errMes);
            }
            public LabSampleDispositionListItemGridModelList(long key, IEnumerable<LabSampleDispositionListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public LabSampleDispositionListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<LabSampleDispositionListItem>(), null);
            }
            partial void filter(List<LabSampleDispositionListItem> items);
            private void LoadGridModelList(long key, IEnumerable<LabSampleDispositionListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strBarcode,_str_strSampleName,_str_DestructionMethod};
                    
                Hiddens = new List<string> {_str_idfMaterial};
                Keys = new List<string> {_str_idfMaterial};
                Labels = new Dictionary<string, string> {{_str_strBarcode, "strLabBarcode"},{_str_strSampleName, _str_strSampleName},{_str_DestructionMethod, _str_DestructionMethod}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                LabSampleDispositionListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<LabSampleDispositionListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new LabSampleDispositionListItemGridModel()
                {
                    ItemKey=c.idfMaterial,strBarcode=c.strBarcode,strSampleName=c.strSampleName,DestructionMethod=c.DestructionMethod
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
        : DataAccessor<LabSampleDispositionListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<LabSampleDispositionListItem>
            
            , IObjectSelectList
            , IObjectSelectList<LabSampleDispositionListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfMaterial"; } }
            #endregion
        
            private delegate void on_action(LabSampleDispositionListItem obj);
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
            private BaseReference.Accessor SampleTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor DestructionAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<LabSampleDispositionListItem> SelectListT(DbManagerProxy manager
                , FilterParams filters = null
                , KeyValuePair<string, ListSortDirection>[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager
                , null, null
                , filters
                , sorts
                , serverSort
                );
            }
            public virtual List<IObject> SelectList(DbManagerProxy manager
                , FilterParams filters = null
                , KeyValuePair<string, ListSortDirection>[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager
                , null, null
                , filters
                , sorts
                , serverSort
                ).Cast<IObject>().ToList();
            }
            
            private List<LabSampleDispositionListItem> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                , FilterParams filters
                , KeyValuePair<string, ListSortDirection>[] sorts
                , bool serverSort = false
                )
            {
                if (filters == null) filters = new FilterParams();
                
                var sql = new StringBuilder();
                string maxtop = BaseSettings.SelectTopMaxCount.ToString();
                sql.Append(@"select ");
                
                sql.Append(@"top ");
                sql.Append(maxtop);
                sql.Append(@" dbo.fn_SampleDestruction_SelectList.* from dbo.fn_SampleDestruction_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfMaterial"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfMaterial"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfMaterial") ? " or " : " and ");
                        
                        if (filters.Operation("idfMaterial", i) == "&")
                          sql.AppendFormat("(isnull(fn_SampleDestruction_SelectList.idfMaterial,0) {0} @idfMaterial_{1} = @idfMaterial_{1})", filters.Operation("idfMaterial", i), i);
                        else
                          sql.AppendFormat("isnull(fn_SampleDestruction_SelectList.idfMaterial,0) {0} @idfMaterial_{1}", filters.Operation("idfMaterial", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strBarcode"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strBarcode"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strBarcode") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SampleDestruction_SelectList.strBarcode {0} @strBarcode_{1}", filters.Operation("strBarcode", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSampleStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSampleStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSampleStatus") ? " or " : " and ");
                        
                        if (filters.Operation("idfsSampleStatus", i) == "&")
                          sql.AppendFormat("(isnull(fn_SampleDestruction_SelectList.idfsSampleStatus,0) {0} @idfsSampleStatus_{1} = @idfsSampleStatus_{1})", filters.Operation("idfsSampleStatus", i), i);
                        else
                          sql.AppendFormat("isnull(fn_SampleDestruction_SelectList.idfsSampleStatus,0) {0} @idfsSampleStatus_{1}", filters.Operation("idfsSampleStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSampleName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSampleName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSampleName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SampleDestruction_SelectList.strSampleName {0} @strSampleName_{1}", filters.Operation("strSampleName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSampleType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSampleType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSampleType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsSampleType", i) == "&")
                          sql.AppendFormat("(isnull(fn_SampleDestruction_SelectList.idfsSampleType,0) {0} @idfsSampleType_{1} = @idfsSampleType_{1})", filters.Operation("idfsSampleType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_SampleDestruction_SelectList.idfsSampleType,0) {0} @idfsSampleType_{1}", filters.Operation("idfsSampleType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsDestructionMethod"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsDestructionMethod"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsDestructionMethod") ? " or " : " and ");
                        
                        if (filters.Operation("idfsDestructionMethod", i) == "&")
                          sql.AppendFormat("(isnull(fn_SampleDestruction_SelectList.idfsDestructionMethod,0) {0} @idfsDestructionMethod_{1} = @idfsDestructionMethod_{1})", filters.Operation("idfsDestructionMethod", i), i);
                        else
                          sql.AppendFormat("isnull(fn_SampleDestruction_SelectList.idfsDestructionMethod,0) {0} @idfsDestructionMethod_{1}", filters.Operation("idfsDestructionMethod", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("DestructionMethod"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("DestructionMethod"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("DestructionMethod") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SampleDestruction_SelectList.DestructionMethod {0} @DestructionMethod_{1}", filters.Operation("DestructionMethod", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (serverSort && sorts != null && sorts.Length > 0)
                {
                    sql.Append(" order by");
                    bool bFirst = true;
                    foreach(var sort in sorts)
                    {
                        sql.Append((bFirst ? " " : ", ") + sort.Key + " " + (sort.Value == ListSortDirection.Ascending ? "ASC" : "DESC"));
                        bFirst = false;
                    }
                }

                bool bTransactionStarted = false;
                try
                {
                    if (!manager.IsTransactionStarted)
                    {
                        bTransactionStarted = true;
                        manager.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                    }
                    
                    sql.Append(" option (OPTIMIZE FOR UNKNOWN)");
                    manager
                        .SetCommand(sql.ToString()
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                        );
                    
                    if (filters.Contains("idfMaterial"))
                        for (int i = 0; i < filters.Count("idfMaterial"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfMaterial_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfMaterial", i), filters.Value("idfMaterial", i))));
                      
                    if (filters.Contains("strBarcode"))
                        for (int i = 0; i < filters.Count("strBarcode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strBarcode", i), filters.Value("strBarcode", i))));
                      
                    if (filters.Contains("idfsSampleStatus"))
                        for (int i = 0; i < filters.Count("idfsSampleStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSampleStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSampleStatus", i), filters.Value("idfsSampleStatus", i))));
                      
                    if (filters.Contains("strSampleName"))
                        for (int i = 0; i < filters.Count("strSampleName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSampleName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSampleName", i), filters.Value("strSampleName", i))));
                      
                    if (filters.Contains("idfsSampleType"))
                        for (int i = 0; i < filters.Count("idfsSampleType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSampleType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSampleType", i), filters.Value("idfsSampleType", i))));
                      
                    if (filters.Contains("idfsDestructionMethod"))
                        for (int i = 0; i < filters.Count("idfsDestructionMethod"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDestructionMethod_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsDestructionMethod", i), filters.Value("idfsDestructionMethod", i))));
                      
                    if (filters.Contains("DestructionMethod"))
                        for (int i = 0; i < filters.Count("DestructionMethod"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@DestructionMethod_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("DestructionMethod", i), filters.Value("DestructionMethod", i))));
                      
                    List<LabSampleDispositionListItem> objs = manager.ExecuteList<LabSampleDispositionListItem>();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                    }
                    ListSelected(manager, objs);
                    return objs;
                }
                catch(DataException e)
                {
                    if (bTransactionStarted)
                    {
                        manager.RollbackTransaction();
                    }
                    throw DbModelException.Create(e);
                }
            }
            partial void ListSelected(DbManagerProxy manager, List<LabSampleDispositionListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spLabSampleDestruction_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabSampleDispositionListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LabSampleDispositionListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabSampleDispositionListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    LabSampleDispositionListItem obj = LabSampleDispositionListItem.CreateInstance();
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

            
            public LabSampleDispositionListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public LabSampleDispositionListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public LabSampleDispositionListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult Accept(DbManagerProxy manager, LabSampleDispositionListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is object)) 
                    throw new TypeMismatchException("key", typeof(object));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return Accept(manager, obj
                    , (object)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult Accept(DbManagerProxy manager, LabSampleDispositionListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("Accept"))
                    throw new PermissionException("Sample", "Accept");
                
                return true;
                
            }
            
      
            public ActResult Reject(DbManagerProxy manager, LabSampleDispositionListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("id", typeof(long));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return Reject(manager, obj
                    , (long)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult Reject(DbManagerProxy manager, LabSampleDispositionListItem obj
                , long id
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("Reject"))
                    throw new PermissionException("Sample", "Reject");
                
              manager.SetSpCommand("dbo.spLabSampleDestruction_Delete"
                , manager.Parameter("ID", id)
                ).ExecuteNonQuery();
              return true;
            
            }
            
      
            private void _SetupChildHandlers(LabSampleDispositionListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabSampleDispositionListItem obj)
            {
                
            }
    
            public void LoadLookup_SampleType(DbManagerProxy manager, LabSampleDispositionListItem obj)
            {
                
                obj.SampleTypeLookup.Clear();
                
                obj.SampleTypeLookup.Add(SampleTypeAccessor.CreateNewT(manager, null));
                
                obj.SampleTypeLookup.AddRange(SampleTypeAccessor.rftSampleType_SelectList(manager
                    
                    )
                    .Where(c => c.idfsBaseReference != (long)SampleTypeEnum.Unknown)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSampleType))
                    
                    .ToList());
                
                if (obj.idfsSampleType != 0)
                {
                    obj.SampleType = obj.SampleTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsSampleType);
                    
                }
              
                
                LookupManager.AddObject("rftSampleType", obj, SampleTypeAccessor.GetType(), "rftSampleType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Destruction(DbManagerProxy manager, LabSampleDispositionListItem obj)
            {
                
                obj.DestructionLookup.Clear();
                
                obj.DestructionLookup.Add(DestructionAccessor.CreateNewT(manager, null));
                
                obj.DestructionLookup.AddRange(DestructionAccessor.rftDestructionMethod_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsDestructionMethod))
                    
                    .ToList());
                
                if (obj.idfsDestructionMethod != null && obj.idfsDestructionMethod != 0)
                {
                    obj.Destruction = obj.DestructionLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsDestructionMethod);
                    
                }
              
                
                LookupManager.AddObject("rftDestructionMethod", obj, DestructionAccessor.GetType(), "rftDestructionMethod_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, LabSampleDispositionListItem obj)
            {
                
                LoadLookup_SampleType(manager, obj);
                
                LoadLookup_Destruction(manager, obj);
                
            }
    
            [SprocName("spLabSampleDestruction_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    LabSampleDispositionListItem bo = obj as LabSampleDispositionListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("Sample", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("Sample", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("Sample", "Update");
                    }
                    
                    long mainObject = bo.idfMaterial;
                    
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
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeDelete;
                            
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeCreate;
                            
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeEdit;
                            
                        }
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoSample;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbMaterial;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as LabSampleDispositionListItem, bChildObject);
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
                }
                catch(Exception e)
                {
                    if (bTransactionStarted)
                    {
                        manager.RollbackTransaction();
                        
                    }
                    
                    if (e is DataException)
                    {
                        throw DbModelException.Create(e as DataException);
                    }
                    else 
                        throw;
                }
                return bSuccess;
            }
            private bool _PostNonTransaction(DbManagerProxy manager, LabSampleDispositionListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfMaterial
                        );
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(LabSampleDispositionListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, LabSampleDispositionListItem obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(LabSampleDispositionListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(LabSampleDispositionListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as LabSampleDispositionListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabSampleDispositionListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(LabSampleDispositionListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LabSampleDispositionListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabSampleDispositionListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabSampleDispositionListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabSampleDispositionListItemDetail"; } }
            public string HelpIdWin { get { return "lab_l07"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private LabSampleDispositionListItem m_obj;
            internal Permissions(LabSampleDispositionListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Sample.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_SampleDestruction_SelectList";
            public static string spCount = "spLabSampleDestruction_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spLabSampleDestruction_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabSampleDispositionListItem, bool>> RequiredByField = new Dictionary<string, Func<LabSampleDispositionListItem, bool>>();
            public static Dictionary<string, Func<LabSampleDispositionListItem, bool>> RequiredByProperty = new Dictionary<string, Func<LabSampleDispositionListItem, bool>>();
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
                
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strSampleName, 2000);
                Sizes.Add(_str_DestructionMethod, 2000);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strBarcode",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strLabBarcode",
                    null, "=", c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSampleType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "SampleType",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "SampleTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsDestructionMethod",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "DestructionMethod",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "DestructionLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfMaterial,
                    _str_idfMaterial, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBarcode,
                    "strLabBarcode", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSampleName,
                    _str_strSampleName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DestructionMethod,
                    _str_DestructionMethod, null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "Accept",
                    ActionTypes.Action,
                    true,
                    "LabSampleDispositionListItem,LabSampleListItem",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).Accept(manager, (LabSampleDispositionListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strAccept_Id",
                        "",
                        /*from BvMessages*/"strAccept_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
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
                    "Reject",
                    ActionTypes.Action,
                    true,
                    "LabSampleDispositionListItem,LabSampleListItem",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).Reject(manager, (LabSampleDispositionListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strReject_Id",
                        "",
                        /*from BvMessages*/"strReject_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
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
                    "SelectAll",
                    ActionTypes.SelectAll,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelectAll_Id",
                        "selectall",
                        /*from BvMessages*/"tooltipSelectAll_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSelectAll_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
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
                    "Select",
                    ActionTypes.Select,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelect_Id",
                        "select",
                        /*from BvMessages*/"tooltipSelect_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSelect_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
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
                    "Refresh",
                    ActionTypes.Refresh,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strRefresh_Id",
                        "iconRefresh_Id",
                        /*from BvMessages*/"tooltipRefresh_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipRefresh_Id",
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
                    "Close",
                    ActionTypes.Close,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strClose_Id",
                        "Close",
                        /*from BvMessages*/"tooltipClose_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipClose_Id",
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
                    "Report",
                    ActionTypes.Report,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strReport_Id",
                        "Report",
                        /*from BvMessages*/"tooltipReport_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipReport_Id",
                        ActionsAlignment.Left,
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
	