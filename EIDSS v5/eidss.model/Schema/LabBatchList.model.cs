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
    public abstract partial class LabBatchListItem : 
        EditableObject<LabBatchListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfBatchTest), NonUpdatable, PrimaryKey]
        public abstract Int64 idfBatchTest { get; set; }
                
        [LocalizedDisplayName(_str_strBarcode)]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        #if MONO
        protected String strBarcode_Original { get { return strBarcode; } }
        protected String strBarcode_Previous { get { return strBarcode; } }
        #else
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsTestType)]
        [MapField(_str_idfsTestType)]
        public abstract Int64? idfsTestType { get; set; }
        #if MONO
        protected Int64? idfsTestType_Original { get { return idfsTestType; } }
        protected Int64? idfsTestType_Previous { get { return idfsTestType; } }
        #else
        protected Int64? idfsTestType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestType).OriginalValue; } }
        protected Int64? idfsTestType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsBatchStatus)]
        [MapField(_str_idfsBatchStatus)]
        public abstract Int64? idfsBatchStatus { get; set; }
        #if MONO
        protected Int64? idfsBatchStatus_Original { get { return idfsBatchStatus; } }
        protected Int64? idfsBatchStatus_Previous { get { return idfsBatchStatus; } }
        #else
        protected Int64? idfsBatchStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBatchStatus).OriginalValue; } }
        protected Int64? idfsBatchStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBatchStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_TestName)]
        [MapField(_str_TestName)]
        public abstract String TestName { get; set; }
        #if MONO
        protected String TestName_Original { get { return TestName; } }
        protected String TestName_Previous { get { return TestName; } }
        #else
        protected String TestName_Original { get { return ((EditableValue<String>)((dynamic)this)._testName).OriginalValue; } }
        protected String TestName_Previous { get { return ((EditableValue<String>)((dynamic)this)._testName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datPerformedDate)]
        [MapField(_str_datPerformedDate)]
        public abstract DateTime? datPerformedDate { get; set; }
        #if MONO
        protected DateTime? datPerformedDate_Original { get { return datPerformedDate; } }
        protected DateTime? datPerformedDate_Previous { get { return datPerformedDate; } }
        #else
        protected DateTime? datPerformedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPerformedDate).OriginalValue; } }
        protected DateTime? datPerformedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPerformedDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datValidatedDate)]
        [MapField(_str_datValidatedDate)]
        public abstract DateTime? datValidatedDate { get; set; }
        #if MONO
        protected DateTime? datValidatedDate_Original { get { return datValidatedDate; } }
        protected DateTime? datValidatedDate_Previous { get { return datValidatedDate; } }
        #else
        protected DateTime? datValidatedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datValidatedDate).OriginalValue; } }
        protected DateTime? datValidatedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datValidatedDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("TestsCount")]
        [MapField(_str_TestsInBatchCount)]
        public abstract Int32? TestsInBatchCount { get; set; }
        #if MONO
        protected Int32? TestsInBatchCount_Original { get { return TestsInBatchCount; } }
        protected Int32? TestsInBatchCount_Previous { get { return TestsInBatchCount; } }
        #else
        protected Int32? TestsInBatchCount_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._testsInBatchCount).OriginalValue; } }
        protected Int32? TestsInBatchCount_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._testsInBatchCount).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_StatusName)]
        [MapField(_str_StatusName)]
        public abstract String StatusName { get; set; }
        #if MONO
        protected String StatusName_Original { get { return StatusName; } }
        protected String StatusName_Previous { get { return StatusName; } }
        #else
        protected String StatusName_Original { get { return ((EditableValue<String>)((dynamic)this)._statusName).OriginalValue; } }
        protected String StatusName_Previous { get { return ((EditableValue<String>)((dynamic)this)._statusName).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<LabBatchListItem, object> _get_func;
            internal Action<LabBatchListItem, string> _set_func;
            internal Action<LabBatchListItem, LabBatchListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfBatchTest = "idfBatchTest";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_idfsTestType = "idfsTestType";
        internal const string _str_idfsBatchStatus = "idfsBatchStatus";
        internal const string _str_TestName = "TestName";
        internal const string _str_datPerformedDate = "datPerformedDate";
        internal const string _str_datValidatedDate = "datValidatedDate";
        internal const string _str_TestsInBatchCount = "TestsInBatchCount";
        internal const string _str_StatusName = "StatusName";
        internal const string _str_BatchStatusName = "BatchStatusName";
        internal const string _str_TestType = "TestType";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfBatchTest, _type = "Int64",
              _get_func = o => o.idfBatchTest,
              _set_func = (o, val) => { o.idfBatchTest = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfBatchTest != c.idfBatchTest || o.IsRIRPropChanged(_str_idfBatchTest, c)) 
                  m.Add(_str_idfBatchTest, o.ObjectIdent + _str_idfBatchTest, "Int64", o.idfBatchTest == null ? "" : o.idfBatchTest.ToString(), o.IsReadOnly(_str_idfBatchTest), o.IsInvisible(_str_idfBatchTest), o.IsRequired(_str_idfBatchTest)); }
              }, 
        
            new field_info {
              _name = _str_strBarcode, _type = "String",
              _get_func = o => o.strBarcode,
              _set_func = (o, val) => { o.strBarcode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strBarcode != c.strBarcode || o.IsRIRPropChanged(_str_strBarcode, c)) 
                  m.Add(_str_strBarcode, o.ObjectIdent + _str_strBarcode, "String", o.strBarcode == null ? "" : o.strBarcode.ToString(), o.IsReadOnly(_str_strBarcode), o.IsInvisible(_str_strBarcode), o.IsRequired(_str_strBarcode)); }
              }, 
        
            new field_info {
              _name = _str_idfsTestType, _type = "Int64?",
              _get_func = o => o.idfsTestType,
              _set_func = (o, val) => { o.idfsTestType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestType != c.idfsTestType || o.IsRIRPropChanged(_str_idfsTestType, c)) 
                  m.Add(_str_idfsTestType, o.ObjectIdent + _str_idfsTestType, "Int64?", o.idfsTestType == null ? "" : o.idfsTestType.ToString(), o.IsReadOnly(_str_idfsTestType), o.IsInvisible(_str_idfsTestType), o.IsRequired(_str_idfsTestType)); }
              }, 
        
            new field_info {
              _name = _str_idfsBatchStatus, _type = "Int64?",
              _get_func = o => o.idfsBatchStatus,
              _set_func = (o, val) => { o.idfsBatchStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsBatchStatus != c.idfsBatchStatus || o.IsRIRPropChanged(_str_idfsBatchStatus, c)) 
                  m.Add(_str_idfsBatchStatus, o.ObjectIdent + _str_idfsBatchStatus, "Int64?", o.idfsBatchStatus == null ? "" : o.idfsBatchStatus.ToString(), o.IsReadOnly(_str_idfsBatchStatus), o.IsInvisible(_str_idfsBatchStatus), o.IsRequired(_str_idfsBatchStatus)); }
              }, 
        
            new field_info {
              _name = _str_TestName, _type = "String",
              _get_func = o => o.TestName,
              _set_func = (o, val) => { o.TestName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.TestName != c.TestName || o.IsRIRPropChanged(_str_TestName, c)) 
                  m.Add(_str_TestName, o.ObjectIdent + _str_TestName, "String", o.TestName == null ? "" : o.TestName.ToString(), o.IsReadOnly(_str_TestName), o.IsInvisible(_str_TestName), o.IsRequired(_str_TestName)); }
              }, 
        
            new field_info {
              _name = _str_datPerformedDate, _type = "DateTime?",
              _get_func = o => o.datPerformedDate,
              _set_func = (o, val) => { o.datPerformedDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datPerformedDate != c.datPerformedDate || o.IsRIRPropChanged(_str_datPerformedDate, c)) 
                  m.Add(_str_datPerformedDate, o.ObjectIdent + _str_datPerformedDate, "DateTime?", o.datPerformedDate == null ? "" : o.datPerformedDate.ToString(), o.IsReadOnly(_str_datPerformedDate), o.IsInvisible(_str_datPerformedDate), o.IsRequired(_str_datPerformedDate)); }
              }, 
        
            new field_info {
              _name = _str_datValidatedDate, _type = "DateTime?",
              _get_func = o => o.datValidatedDate,
              _set_func = (o, val) => { o.datValidatedDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datValidatedDate != c.datValidatedDate || o.IsRIRPropChanged(_str_datValidatedDate, c)) 
                  m.Add(_str_datValidatedDate, o.ObjectIdent + _str_datValidatedDate, "DateTime?", o.datValidatedDate == null ? "" : o.datValidatedDate.ToString(), o.IsReadOnly(_str_datValidatedDate), o.IsInvisible(_str_datValidatedDate), o.IsRequired(_str_datValidatedDate)); }
              }, 
        
            new field_info {
              _name = _str_TestsInBatchCount, _type = "Int32?",
              _get_func = o => o.TestsInBatchCount,
              _set_func = (o, val) => { o.TestsInBatchCount = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.TestsInBatchCount != c.TestsInBatchCount || o.IsRIRPropChanged(_str_TestsInBatchCount, c)) 
                  m.Add(_str_TestsInBatchCount, o.ObjectIdent + _str_TestsInBatchCount, "Int32?", o.TestsInBatchCount == null ? "" : o.TestsInBatchCount.ToString(), o.IsReadOnly(_str_TestsInBatchCount), o.IsInvisible(_str_TestsInBatchCount), o.IsRequired(_str_TestsInBatchCount)); }
              }, 
        
            new field_info {
              _name = _str_StatusName, _type = "String",
              _get_func = o => o.StatusName,
              _set_func = (o, val) => { o.StatusName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.StatusName != c.StatusName || o.IsRIRPropChanged(_str_StatusName, c)) 
                  m.Add(_str_StatusName, o.ObjectIdent + _str_StatusName, "String", o.StatusName == null ? "" : o.StatusName.ToString(), o.IsReadOnly(_str_StatusName), o.IsInvisible(_str_StatusName), o.IsRequired(_str_StatusName)); }
              }, 
        
            new field_info {
              _name = _str_BatchStatusName, _type = "Lookup",
              _get_func = o => { if (o.BatchStatusName == null) return null; return o.BatchStatusName.idfsBaseReference; },
              _set_func = (o, val) => { o.BatchStatusName = o.BatchStatusNameLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsBatchStatus != c.idfsBatchStatus || o.IsRIRPropChanged(_str_BatchStatusName, c)) 
                  m.Add(_str_BatchStatusName, o.ObjectIdent + _str_BatchStatusName, "Lookup", o.idfsBatchStatus == null ? "" : o.idfsBatchStatus.ToString(), o.IsReadOnly(_str_BatchStatusName), o.IsInvisible(_str_BatchStatusName), o.IsRequired(_str_BatchStatusName)); }
              }, 
        
            new field_info {
              _name = _str_TestType, _type = "Lookup",
              _get_func = o => { if (o.TestType == null) return null; return o.TestType.idfsBaseReference; },
              _set_func = (o, val) => { o.TestType = o.TestTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestType != c.idfsTestType || o.IsRIRPropChanged(_str_TestType, c)) 
                  m.Add(_str_TestType, o.ObjectIdent + _str_TestType, "Lookup", o.idfsTestType == null ? "" : o.idfsTestType.ToString(), o.IsReadOnly(_str_TestType), o.IsInvisible(_str_TestType), o.IsRequired(_str_TestType)); }
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
            LabBatchListItem obj = (LabBatchListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsBatchStatus)]
        public BaseReference BatchStatusName
        {
            get { return _BatchStatusName == null ? null : ((long)_BatchStatusName.Key == 0 ? null : _BatchStatusName); }
            set 
            { 
                _BatchStatusName = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsBatchStatus = _BatchStatusName == null 
                    ? new Int64?()
                    : _BatchStatusName.idfsBaseReference; 
                OnPropertyChanged(_str_BatchStatusName); 
            }
        }
        private BaseReference _BatchStatusName;

        
        public BaseReferenceList BatchStatusNameLookup
        {
            get { return _BatchStatusNameLookup; }
        }
        private BaseReferenceList _BatchStatusNameLookup = new BaseReferenceList("rftActivityStatus");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestType)]
        public BaseReference TestType
        {
            get { return _TestType == null ? null : ((long)_TestType.Key == 0 ? null : _TestType); }
            set 
            { 
                _TestType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsTestType = _TestType == null 
                    ? new Int64?()
                    : _TestType.idfsBaseReference; 
                OnPropertyChanged(_str_TestType); 
            }
        }
        private BaseReference _TestType;

        
        public BaseReferenceList TestTypeLookup
        {
            get { return _TestTypeLookup; }
        }
        private BaseReferenceList _TestTypeLookup = new BaseReferenceList("rftTestType");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_BatchStatusName:
                    return new BvSelectList(BatchStatusNameLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, BatchStatusName, _str_idfsBatchStatus);
            
                case _str_TestType:
                    return new BvSelectList(TestTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestType, _str_idfsTestType);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LabBatchListItem";

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
            var ret = base.Clone() as LabBatchListItem;
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
            var ret = base.Clone() as LabBatchListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public LabBatchListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabBatchListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfBatchTest; } }
        public string KeyName { get { return "idfBatchTest"; } }
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
        
            var _prev_idfsBatchStatus_BatchStatusName = idfsBatchStatus;
            var _prev_idfsTestType_TestType = idfsTestType;
            base.RejectChanges();
        
            if (_prev_idfsBatchStatus_BatchStatusName != idfsBatchStatus)
            {
                _BatchStatusName = _BatchStatusNameLookup.FirstOrDefault(c => c.idfsBaseReference == idfsBatchStatus);
            }
            if (_prev_idfsTestType_TestType != idfsTestType)
            {
                _TestType = _TestTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestType);
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

      private bool IsRIRPropChanged(string fld, LabBatchListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabBatchListItem()
        {
            
            m_permissions = new Permissions(this);
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabBatchListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabBatchListItem_PropertyChanged);
        }
        private void LabBatchListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabBatchListItem).Changed(e.PropertyName);
            
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
            
            return Accessor.Instance(null).ValidateCanDelete(this);
              
        }
        private void _DeletingExtenders()
        {
            LabBatchListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabBatchListItem obj = this;
            
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


        public Dictionary<string, Func<LabBatchListItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabBatchListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabBatchListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabBatchListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabBatchListItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<LabBatchListItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LabBatchListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftActivityStatus", this);
                
                LookupManager.RemoveObject("rftTestType", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftActivityStatus")
                _getAccessor().LoadLookup_BatchStatusName(manager, this);
            
            if (lookup_object == "rftTestType")
                _getAccessor().LoadLookup_TestType(manager, this);
            
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
    
        #region Class for web grid
        public class LabBatchListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfBatchTest { get; set; }
        
            public String strBarcode { get; set; }
        
            public String TestName { get; set; }
        
            public DateTime? datPerformedDate { get; set; }
        
            public DateTime? datValidatedDate { get; set; }
        
            public Int32? TestsInBatchCount { get; set; }
        
            public String StatusName { get; set; }
        
        }
        public partial class LabBatchListItemGridModelList : List<LabBatchListItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public LabBatchListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabBatchListItem>, errMes);
            }
            public LabBatchListItemGridModelList(long key, IEnumerable<LabBatchListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<LabBatchListItem> items);
            private void LoadGridModelList(long key, IEnumerable<LabBatchListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strBarcode,_str_TestName,_str_datPerformedDate,_str_datValidatedDate,_str_TestsInBatchCount,_str_StatusName};
                    
                Hiddens = new List<string> {_str_idfBatchTest};
                Keys = new List<string> {_str_idfBatchTest};
                Labels = new Dictionary<string, string> {{_str_strBarcode, _str_strBarcode},{_str_TestName, _str_TestName},{_str_datPerformedDate, _str_datPerformedDate},{_str_datValidatedDate, _str_datValidatedDate},{_str_TestsInBatchCount, "TestsCount"},{_str_StatusName, _str_StatusName}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<LabBatchListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new LabBatchListItemGridModel()
                {
                    ItemKey=c.idfBatchTest,strBarcode=c.strBarcode,TestName=c.TestName,datPerformedDate=c.datPerformedDate,datValidatedDate=c.datValidatedDate,TestsInBatchCount=c.TestsInBatchCount,StatusName=c.StatusName
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
        : DataAccessor<LabBatchListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectList
                    
            , IObjectPost
                    
        {
            private delegate void on_action(LabBatchListItem obj);
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
            private BaseReference.Accessor BatchStatusNameAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<LabBatchListItem> SelectListT(DbManagerProxy manager
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
            
            private List<LabBatchListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_BatchTest_SelectList.* from dbo.fn_BatchTest_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("strCaseID"))
                {
                    
                    sql.Append(" " + @"
						INNER JOIN 
						(
								select distinct idfBatchTest
								from			fn_LabTest_SelectList(null) InnerTests
								where			(ISNULL(InnerTests.CaseID,N'') LIKE '%' + @strCaseID + '%')
						)		as TestsForCase
						ON  	TestsForCase.idfBatchTest=fn_BatchTest_SelectList.idfBatchTest
					");
                      
                }
                
                if (filters.Contains("strLabSampleID"))
                {
                    
                    sql.Append(" " + @"
						INNER JOIN
						(
								select distinct idfBatchTest
								from			fn_LabTest_SelectList(null) InnerTests
								where			(ISNULL(InnerTests.strBarcode,N'') LIKE '%' + @strLabSampleID + '%')
						)		as TestsForSample
						ON  	TestsForSample.idfBatchTest=fn_BatchTest_SelectList.idfBatchTest
					");
                      
                }
                
                if (ModelUserContext.IsWebContext && EidssSiteContext.Instance.SiteType == SiteType.SS)
                {
                    sql.Append(" " + @"inner join tflAllBatchTestFiltered f on f.idfAllBatchTest = fn_BatchTest_SelectList.idfBatchTest and f.idfsSite = " + EidssSiteContext.Instance.SiteID.ToString());
                }
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("strCaseID"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strCaseID") == 1)
                    {
                        sql.AppendFormat("1=1", filters.Operation("strCaseID"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strCaseID"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strCaseID") ? " or " : " and ");
                            sql.AppendFormat("@strCaseID_{1}", filters.Operation("strCaseID", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("strLabSampleID"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strLabSampleID") == 1)
                    {
                        sql.AppendFormat("1=1", filters.Operation("strLabSampleID"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strLabSampleID"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strLabSampleID") ? " or " : " and ");
                            sql.AppendFormat("@strLabSampleID_{1}", filters.Operation("strLabSampleID", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfBatchTest"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfBatchTest"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfBatchTest") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_BatchTest_SelectList.idfBatchTest,0) {0} @idfBatchTest_{1}", filters.Operation("idfBatchTest", i), i);
                            
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
                        
                        sql.AppendFormat("fn_BatchTest_SelectList.strBarcode {0} @strBarcode_{1}", filters.Operation("strBarcode", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsTestType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsTestType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsTestType") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_BatchTest_SelectList.idfsTestType,0) {0} @idfsTestType_{1}", filters.Operation("idfsTestType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsBatchStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsBatchStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsBatchStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_BatchTest_SelectList.idfsBatchStatus,0) {0} @idfsBatchStatus_{1}", filters.Operation("idfsBatchStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("TestName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("TestName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("TestName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BatchTest_SelectList.TestName {0} @TestName_{1}", filters.Operation("TestName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datPerformedDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datPerformedDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datPerformedDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_BatchTest_SelectList.datPerformedDate, 112) {0} CONVERT(NVARCHAR(8), @datPerformedDate_{1}, 112)", filters.Operation("datPerformedDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datValidatedDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datValidatedDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datValidatedDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_BatchTest_SelectList.datValidatedDate, 112) {0} CONVERT(NVARCHAR(8), @datValidatedDate_{1}, 112)", filters.Operation("datValidatedDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("TestsInBatchCount"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("TestsInBatchCount"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("TestsInBatchCount") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_BatchTest_SelectList.TestsInBatchCount,0) {0} @TestsInBatchCount_{1}", filters.Operation("TestsInBatchCount", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("StatusName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("StatusName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("StatusName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BatchTest_SelectList.StatusName {0} @StatusName_{1}", filters.Operation("StatusName", i), i);
                            
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
                    manager
                        .SetCommand(sql.ToString()
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                        );
                    
                    if (filters.Contains("strCaseID"))
                        
                        if (filters.Count("strCaseID") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCaseID", ParsingHelper.CorrectLikeValue(filters.Operation("strCaseID"), filters.Value("strCaseID"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strCaseID"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCaseID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCaseID", i), filters.Value("strCaseID", i))));
                        }
                            
                    if (filters.Contains("strLabSampleID"))
                        
                        if (filters.Count("strLabSampleID") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strLabSampleID", ParsingHelper.CorrectLikeValue(filters.Operation("strLabSampleID"), filters.Value("strLabSampleID"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strLabSampleID"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strLabSampleID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strLabSampleID", i), filters.Value("strLabSampleID", i))));
                        }
                            
                    if (filters.Contains("idfBatchTest"))
                        for (int i = 0; i < filters.Count("idfBatchTest"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfBatchTest_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfBatchTest", i), filters.Value("idfBatchTest", i))));
                      
                    if (filters.Contains("strBarcode"))
                        for (int i = 0; i < filters.Count("strBarcode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strBarcode", i), filters.Value("strBarcode", i))));
                      
                    if (filters.Contains("idfsTestType"))
                        for (int i = 0; i < filters.Count("idfsTestType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestType", i), filters.Value("idfsTestType", i))));
                      
                    if (filters.Contains("idfsBatchStatus"))
                        for (int i = 0; i < filters.Count("idfsBatchStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsBatchStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsBatchStatus", i), filters.Value("idfsBatchStatus", i))));
                      
                    if (filters.Contains("TestName"))
                        for (int i = 0; i < filters.Count("TestName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@TestName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("TestName", i), filters.Value("TestName", i))));
                      
                    if (filters.Contains("datPerformedDate"))
                        for (int i = 0; i < filters.Count("datPerformedDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datPerformedDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datPerformedDate", i), filters.Value("datPerformedDate", i))));
                      
                    if (filters.Contains("datValidatedDate"))
                        for (int i = 0; i < filters.Count("datValidatedDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datValidatedDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datValidatedDate", i), filters.Value("datValidatedDate", i))));
                      
                    if (filters.Contains("TestsInBatchCount"))
                        for (int i = 0; i < filters.Count("TestsInBatchCount"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@TestsInBatchCount_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("TestsInBatchCount", i), filters.Value("TestsInBatchCount", i))));
                      
                    if (filters.Contains("StatusName"))
                        for (int i = 0; i < filters.Count("StatusName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@StatusName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("StatusName", i), filters.Value("StatusName", i))));
                      
                    List<LabBatchListItem> objs = manager.ExecuteList<LabBatchListItem>();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                    }
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
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spLabBatch_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabBatchListItem obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LabBatchListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabBatchListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabBatchListItem obj = LabBatchListItem.CreateInstance();
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

            
            public LabBatchListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public LabBatchListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(LabBatchListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabBatchListItem obj)
            {
                
            }
    
            public void LoadLookup_BatchStatusName(DbManagerProxy manager, LabBatchListItem obj)
            {
                
                obj.BatchStatusNameLookup.Clear();
                
                obj.BatchStatusNameLookup.Add(BatchStatusNameAccessor.CreateNewT(manager, null));
                
                obj.BatchStatusNameLookup.AddRange(BatchStatusNameAccessor.rftActivityStatus_SelectList(manager
                    
                    )
                    .Where(c => c.idfsBaseReference == (long)BatchStatusEnum.Completed || c.idfsBaseReference == (long)BatchStatusEnum.InProcess)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsBatchStatus))
                    
                    .ToList());
                
                if (obj.idfsBatchStatus != null && obj.idfsBatchStatus != 0)
                {
                    obj.BatchStatusName = obj.BatchStatusNameLookup
                        .Where(c => c.idfsBaseReference == obj.idfsBatchStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftActivityStatus", obj, BatchStatusNameAccessor.GetType(), "rftActivityStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_TestType(DbManagerProxy manager, LabBatchListItem obj)
            {
                
                obj.TestTypeLookup.Clear();
                
                obj.TestTypeLookup.Add(TestTypeAccessor.CreateNewT(manager, null));
                
                obj.TestTypeLookup.AddRange(TestTypeAccessor.rftTestType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestType))
                    
                    .ToList());
                
                if (obj.idfsTestType != null && obj.idfsTestType != 0)
                {
                    obj.TestType = obj.TestTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsTestType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftTestType", obj, TestTypeAccessor.GetType(), "rftTestType_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, LabBatchListItem obj)
            {
                
                LoadLookup_BatchStatusName(manager, obj);
                
                LoadLookup_TestType(manager, obj);
                
            }
    
            [SprocName("spReadOnlyObject_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spReadOnlyObject_Delete")]
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
                    LabBatchListItem bo = obj as LabBatchListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("Test", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("Test", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("Test", "Update");
                    }
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        long mainObject = bo.idfBatchTest;
                        
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoBatchTest;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbBatchTest;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as LabBatchListItem, bChildObject);
                    if (bTransactionStarted)
                    {
                        if (bSuccess)
                        {
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
            private bool _PostNonTransaction(DbManagerProxy manager, LabBatchListItem obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfBatchTest
                        );
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(LabBatchListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, LabBatchListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfBatchTest
                            , out result
                            );
                        if (!result) 
                        {
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, false);
                        }
                     }
                }
                catch(ValidationModelException ex)
                {
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                        return false;
                    }
                    else
                        obj.m_IsForcedToDelete = true;
                }
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as LabBatchListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabBatchListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(LabBatchListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LabBatchListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabBatchListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabBatchListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabBatchListItemDetail"; } }
            public string HelpIdWin { get { return "TestBatchesForm"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private LabBatchListItem m_obj;
            internal Permissions(LabBatchListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_BatchTest_SelectList";
            public static string spCount = "spLabBatch_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spReadOnlyObject_Delete";
            public static string spCanDelete = "spReadOnlyObject_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabBatchListItem, bool>> RequiredByField = new Dictionary<string, Func<LabBatchListItem, bool>>();
            public static Dictionary<string, Func<LabBatchListItem, bool>> RequiredByProperty = new Dictionary<string, Func<LabBatchListItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_TestName, 2000);
                Sizes.Add(_str_StatusName, 2000);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strBarcode",
                    EditorType.Text,
                    false, false, 
                    "strBarcode",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strCaseID",
                    EditorType.Text,
                    false, false, 
                    "strCaseIDSessionID",
                    null, null, false, false, SearchPanelLocation.Main, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestType",
                    EditorType.Lookup,
                    false, false, 
                    "TestName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "TestTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strLabSampleID",
                    EditorType.Text,
                    false, false, 
                    "strLabBarcode",
                    null, null, false, false, SearchPanelLocation.Main, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsBatchStatus",
                    EditorType.Lookup,
                    false, false, 
                    "StatusName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "BatchStatusNameLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datPerformedDate",
                    EditorType.Date,
                    true, false, 
                    "datPerformedDate",
                    () => DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter), null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datValidatedDate",
                    EditorType.Date,
                    true, false, 
                    "datValidatedDate",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfBatchTest,
                    _str_idfBatchTest, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBarcode,
                    _str_strBarcode, null, true, true, ListSortDirection.Descending
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestName,
                    _str_TestName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datPerformedDate,
                    _str_datPerformedDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datValidatedDate,
                    _str_datValidatedDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TestsInBatchCount,
                    "TestsCount", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_StatusName,
                    _str_StatusName, null, true, true, null
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
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<LabBatch>().CreateNew(manager, null, pars == null ? null : (int?)pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
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
                    "Edit",
                    ActionTypes.Edit,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<LabBatch>().SelectDetail(manager, pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strEdit_Id",
                        "edit",
                        /*from BvMessages*/"tooltipEdit_Id",
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"tooltipEdit_Id",
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	