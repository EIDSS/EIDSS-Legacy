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
    public abstract partial class AggregateMatrixVersionLookup : 
        EditableObject<AggregateMatrixVersionLookup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfVersion), NonUpdatable, PrimaryKey]
        public abstract Int64 idfVersion { get; set; }
                
        [LocalizedDisplayName(_str_idfsAggrCaseSection)]
        [MapField(_str_idfsAggrCaseSection)]
        public abstract Int64 idfsAggrCaseSection { get; set; }
        protected Int64 idfsAggrCaseSection_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAggrCaseSection).OriginalValue; } }
        protected Int64 idfsAggrCaseSection_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAggrCaseSection).PreviousValue; } }
                
        [LocalizedDisplayName(_str_MatrixName)]
        [MapField(_str_MatrixName)]
        public abstract String MatrixName { get; set; }
        protected String MatrixName_Original { get { return ((EditableValue<String>)((dynamic)this)._matrixName).OriginalValue; } }
        protected String MatrixName_Previous { get { return ((EditableValue<String>)((dynamic)this)._matrixName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datStartDate)]
        [MapField(_str_datStartDate)]
        public abstract DateTime? datStartDate { get; set; }
        protected DateTime? datStartDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).OriginalValue; } }
        protected DateTime? datStartDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnIsActive)]
        [MapField(_str_blnIsActive)]
        public abstract Boolean blnIsActive { get; set; }
        protected Boolean blnIsActive_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnIsActive).OriginalValue; } }
        protected Boolean blnIsActive_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnIsActive).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnIsDefault)]
        [MapField(_str_blnIsDefault)]
        public abstract Boolean? blnIsDefault { get; set; }
        protected Boolean? blnIsDefault_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnIsDefault).OriginalValue; } }
        protected Boolean? blnIsDefault_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnIsDefault).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intState)]
        [MapField(_str_intState)]
        public abstract Int32? intState { get; set; }
        protected Int32? intState_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intState).OriginalValue; } }
        protected Int32? intState_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intState).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intRowStatus)]
        [MapField(_str_intRowStatus)]
        public abstract Int32 intRowStatus { get; set; }
        protected Int32 intRowStatus_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).OriginalValue; } }
        protected Int32 intRowStatus_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<AggregateMatrixVersionLookup, object> _get_func;
            internal Action<AggregateMatrixVersionLookup, string> _set_func;
            internal Action<AggregateMatrixVersionLookup, AggregateMatrixVersionLookup, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfVersion = "idfVersion";
        internal const string _str_idfsAggrCaseSection = "idfsAggrCaseSection";
        internal const string _str_MatrixName = "MatrixName";
        internal const string _str_datStartDate = "datStartDate";
        internal const string _str_blnIsActive = "blnIsActive";
        internal const string _str_blnIsDefault = "blnIsDefault";
        internal const string _str_intState = "intState";
        internal const string _str_intRowStatus = "intRowStatus";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfVersion, _formname = _str_idfVersion, _type = "Int64",
              _get_func = o => o.idfVersion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVersion != newval) o.idfVersion = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfVersion != c.idfVersion || o.IsRIRPropChanged(_str_idfVersion, c)) 
                  m.Add(_str_idfVersion, o.ObjectIdent + _str_idfVersion, o.ObjectIdent2 + _str_idfVersion, o.ObjectIdent3 + _str_idfVersion, "Int64", 
                    o.idfVersion == null ? "" : o.idfVersion.ToString(),                  
                  o.IsReadOnly(_str_idfVersion), o.IsInvisible(_str_idfVersion), o.IsRequired(_str_idfVersion)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAggrCaseSection, _formname = _str_idfsAggrCaseSection, _type = "Int64",
              _get_func = o => o.idfsAggrCaseSection,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsAggrCaseSection != newval) o.idfsAggrCaseSection = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsAggrCaseSection != c.idfsAggrCaseSection || o.IsRIRPropChanged(_str_idfsAggrCaseSection, c)) 
                  m.Add(_str_idfsAggrCaseSection, o.ObjectIdent + _str_idfsAggrCaseSection, o.ObjectIdent2 + _str_idfsAggrCaseSection, o.ObjectIdent3 + _str_idfsAggrCaseSection, "Int64", 
                    o.idfsAggrCaseSection == null ? "" : o.idfsAggrCaseSection.ToString(),                  
                  o.IsReadOnly(_str_idfsAggrCaseSection), o.IsInvisible(_str_idfsAggrCaseSection), o.IsRequired(_str_idfsAggrCaseSection)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_MatrixName, _formname = _str_MatrixName, _type = "String",
              _get_func = o => o.MatrixName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.MatrixName != newval) o.MatrixName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.MatrixName != c.MatrixName || o.IsRIRPropChanged(_str_MatrixName, c)) 
                  m.Add(_str_MatrixName, o.ObjectIdent + _str_MatrixName, o.ObjectIdent2 + _str_MatrixName, o.ObjectIdent3 + _str_MatrixName, "String", 
                    o.MatrixName == null ? "" : o.MatrixName.ToString(),                  
                  o.IsReadOnly(_str_MatrixName), o.IsInvisible(_str_MatrixName), o.IsRequired(_str_MatrixName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datStartDate, _formname = _str_datStartDate, _type = "DateTime?",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datStartDate != newval) o.datStartDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) 
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, o.ObjectIdent2 + _str_datStartDate, o.ObjectIdent3 + _str_datStartDate, "DateTime?", 
                    o.datStartDate == null ? "" : o.datStartDate.ToString(),                  
                  o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnIsActive, _formname = _str_blnIsActive, _type = "Boolean",
              _get_func = o => o.blnIsActive,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnIsActive != newval) o.blnIsActive = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnIsActive != c.blnIsActive || o.IsRIRPropChanged(_str_blnIsActive, c)) 
                  m.Add(_str_blnIsActive, o.ObjectIdent + _str_blnIsActive, o.ObjectIdent2 + _str_blnIsActive, o.ObjectIdent3 + _str_blnIsActive, "Boolean", 
                    o.blnIsActive == null ? "" : o.blnIsActive.ToString(),                  
                  o.IsReadOnly(_str_blnIsActive), o.IsInvisible(_str_blnIsActive), o.IsRequired(_str_blnIsActive)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnIsDefault, _formname = _str_blnIsDefault, _type = "Boolean?",
              _get_func = o => o.blnIsDefault,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnIsDefault != newval) o.blnIsDefault = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnIsDefault != c.blnIsDefault || o.IsRIRPropChanged(_str_blnIsDefault, c)) 
                  m.Add(_str_blnIsDefault, o.ObjectIdent + _str_blnIsDefault, o.ObjectIdent2 + _str_blnIsDefault, o.ObjectIdent3 + _str_blnIsDefault, "Boolean?", 
                    o.blnIsDefault == null ? "" : o.blnIsDefault.ToString(),                  
                  o.IsReadOnly(_str_blnIsDefault), o.IsInvisible(_str_blnIsDefault), o.IsRequired(_str_blnIsDefault)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intState, _formname = _str_intState, _type = "Int32?",
              _get_func = o => o.intState,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intState != newval) o.intState = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intState != c.intState || o.IsRIRPropChanged(_str_intState, c)) 
                  m.Add(_str_intState, o.ObjectIdent + _str_intState, o.ObjectIdent2 + _str_intState, o.ObjectIdent3 + _str_intState, "Int32?", 
                    o.intState == null ? "" : o.intState.ToString(),                  
                  o.IsReadOnly(_str_intState), o.IsInvisible(_str_intState), o.IsRequired(_str_intState)); 
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
            AggregateMatrixVersionLookup obj = (AggregateMatrixVersionLookup)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
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
        internal string m_ObjectName = "AggregateMatrixVersionLookup";

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
            var ret = base.Clone() as AggregateMatrixVersionLookup;
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
            var ret = base.Clone() as AggregateMatrixVersionLookup;
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
        public AggregateMatrixVersionLookup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AggregateMatrixVersionLookup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfVersion; } }
        public string KeyName { get { return "idfVersion"; } }
        public object KeyLookup { get { return idfVersion; } }
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

        private bool IsRIRPropChanged(string fld, AggregateMatrixVersionLookup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, AggregateMatrixVersionLookup c)
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
        

      
        public override string ToString()
        {
            return new Func<AggregateMatrixVersionLookup, string>(c => c.MatrixName)(this);
        }
        

        public AggregateMatrixVersionLookup()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AggregateMatrixVersionLookup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AggregateMatrixVersionLookup_PropertyChanged);
        }
        private void AggregateMatrixVersionLookup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AggregateMatrixVersionLookup).Changed(e.PropertyName);
            
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
            AggregateMatrixVersionLookup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AggregateMatrixVersionLookup obj = this;
            
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


        internal Dictionary<string, Func<AggregateMatrixVersionLookup, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<AggregateMatrixVersionLookup, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AggregateMatrixVersionLookup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AggregateMatrixVersionLookup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<AggregateMatrixVersionLookup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<AggregateMatrixVersionLookup, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<AggregateMatrixVersionLookup, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~AggregateMatrixVersionLookup()
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
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
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
        : DataAccessor<AggregateMatrixVersionLookup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<AggregateMatrixVersionLookup>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfVersion"; } }
            #endregion
        
            public delegate void on_action(AggregateMatrixVersionLookup obj);
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
            
            public virtual List<AggregateMatrixVersionLookup> SelectLookupList(DbManagerProxy manager
                , Int64? idfMatrix
                )
            {
                return _SelectList(manager
                    , idfMatrix
                    , null, null
                    );
            }
            
            public virtual List<AggregateMatrixVersionLookup> SelectList(DbManagerProxy manager
                , Int64? idfMatrix
                )
            {
                return _SelectList(manager
                    , idfMatrix
                    , delegate(AggregateMatrixVersionLookup obj)
                        {
                        }
                    , delegate(AggregateMatrixVersionLookup obj)
                        {
                        }
                    );
            }

            

            public List<AggregateMatrixVersionLookup> _SelectList(DbManagerProxy manager
                , Int64? idfMatrix
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfMatrix
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            [InstanceCache(typeof(BvCacheAspect))]
            public virtual List<AggregateMatrixVersionLookup> _SelectListInternal(DbManagerProxy manager
                , Int64? idfMatrix
                , on_action loading, on_action loaded
                )
            {
                AggregateMatrixVersionLookup _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<AggregateMatrixVersionLookup> objs = new List<AggregateMatrixVersionLookup>();
                    sets[0] = new MapResultSet(typeof(AggregateMatrixVersionLookup), objs);
                    
                    manager
                        .SetSpCommand("spAggregateMatrixVersion_SelectLookup"
                            , manager.Parameter("@idfMatrix", idfMatrix)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, AggregateMatrixVersionLookup obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AggregateMatrixVersionLookup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AggregateMatrixVersionLookup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                AggregateMatrixVersionLookup obj = null;
                try
                {
                    obj = AggregateMatrixVersionLookup.CreateInstance();
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

            
            public AggregateMatrixVersionLookup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public AggregateMatrixVersionLookup CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public AggregateMatrixVersionLookup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(AggregateMatrixVersionLookup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AggregateMatrixVersionLookup obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, AggregateMatrixVersionLookup obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(AggregateMatrixVersionLookup obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(AggregateMatrixVersionLookup obj, bool bRethrowException)
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
                return Validate(manager, obj as AggregateMatrixVersionLookup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AggregateMatrixVersionLookup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(AggregateMatrixVersionLookup obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(AggregateMatrixVersionLookup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AggregateMatrixVersionLookup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AggregateMatrixVersionLookup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AggregateMatrixVersionLookupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spAggregateMatrixVersion_SelectLookup";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AggregateMatrixVersionLookup, bool>> RequiredByField = new Dictionary<string, Func<AggregateMatrixVersionLookup, bool>>();
            public static Dictionary<string, Func<AggregateMatrixVersionLookup, bool>> RequiredByProperty = new Dictionary<string, Func<AggregateMatrixVersionLookup, bool>>();
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
                
                Sizes.Add(_str_MatrixName, 200);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AggregateMatrixVersionLookup>().Post(manager, (AggregateMatrixVersionLookup)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AggregateMatrixVersionLookup>().Post(manager, (AggregateMatrixVersionLookup)c), c),
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
                    (manager, c, pars) => new ActResult(((AggregateMatrixVersionLookup)c).MarkToDelete() && ObjectAccessor.PostInterface<AggregateMatrixVersionLookup>().Post(manager, (AggregateMatrixVersionLookup)c), c),
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
	