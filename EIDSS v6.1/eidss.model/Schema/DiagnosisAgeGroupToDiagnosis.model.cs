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
    public abstract partial class DiagnosisAgeGroupToDiagnosis : 
        EditableObject<DiagnosisAgeGroupToDiagnosis>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfDiagnosisAgeGroupToDiagnosis), NonUpdatable, PrimaryKey]
        public abstract Int64 idfDiagnosisAgeGroupToDiagnosis { get; set; }
                
        [LocalizedDisplayName(_str_idfsDiagnosis)]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64 idfsDiagnosis { get; set; }
        protected Int64 idfsDiagnosis_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64 idfsDiagnosis_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName("strAgeGroups")]
        [MapField(_str_idfsDiagnosisAgeGroup)]
        public abstract Int64? idfsDiagnosisAgeGroup { get; set; }
        protected Int64? idfsDiagnosisAgeGroup_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosisAgeGroup).OriginalValue; } }
        protected Int64? idfsDiagnosisAgeGroup_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosisAgeGroup).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<DiagnosisAgeGroupToDiagnosis, object> _get_func;
            internal Action<DiagnosisAgeGroupToDiagnosis, string> _set_func;
            internal Action<DiagnosisAgeGroupToDiagnosis, DiagnosisAgeGroupToDiagnosis, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfDiagnosisAgeGroupToDiagnosis = "idfDiagnosisAgeGroupToDiagnosis";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_idfsDiagnosisAgeGroup = "idfsDiagnosisAgeGroup";
        internal const string _str_DiagnosisAgeGroup = "DiagnosisAgeGroup";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfDiagnosisAgeGroupToDiagnosis, _formname = _str_idfDiagnosisAgeGroupToDiagnosis, _type = "Int64",
              _get_func = o => o.idfDiagnosisAgeGroupToDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfDiagnosisAgeGroupToDiagnosis != newval) o.idfDiagnosisAgeGroupToDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfDiagnosisAgeGroupToDiagnosis != c.idfDiagnosisAgeGroupToDiagnosis || o.IsRIRPropChanged(_str_idfDiagnosisAgeGroupToDiagnosis, c)) 
                  m.Add(_str_idfDiagnosisAgeGroupToDiagnosis, o.ObjectIdent + _str_idfDiagnosisAgeGroupToDiagnosis, o.ObjectIdent2 + _str_idfDiagnosisAgeGroupToDiagnosis, o.ObjectIdent3 + _str_idfDiagnosisAgeGroupToDiagnosis, "Int64", 
                    o.idfDiagnosisAgeGroupToDiagnosis == null ? "" : o.idfDiagnosisAgeGroupToDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfDiagnosisAgeGroupToDiagnosis), o.IsInvisible(_str_idfDiagnosisAgeGroupToDiagnosis), o.IsRequired(_str_idfDiagnosisAgeGroupToDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "Int64",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis, "Int64", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosisAgeGroup, _formname = _str_idfsDiagnosisAgeGroup, _type = "Int64?",
              _get_func = o => o.idfsDiagnosisAgeGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsDiagnosisAgeGroup != newval) 
                  o.DiagnosisAgeGroup = o.DiagnosisAgeGroupLookup.FirstOrDefault(c => c.idfsReference == newval);
                if (o.idfsDiagnosisAgeGroup != newval) o.idfsDiagnosisAgeGroup = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsDiagnosisAgeGroup != c.idfsDiagnosisAgeGroup || o.IsRIRPropChanged(_str_idfsDiagnosisAgeGroup, c)) 
                  m.Add(_str_idfsDiagnosisAgeGroup, o.ObjectIdent + _str_idfsDiagnosisAgeGroup, o.ObjectIdent2 + _str_idfsDiagnosisAgeGroup, o.ObjectIdent3 + _str_idfsDiagnosisAgeGroup, "Int64?", 
                    o.idfsDiagnosisAgeGroup == null ? "" : o.idfsDiagnosisAgeGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosisAgeGroup), o.IsInvisible(_str_idfsDiagnosisAgeGroup), o.IsRequired(_str_idfsDiagnosisAgeGroup)); 
                  }
              }, 
        
            new field_info {
              _name = _str_DiagnosisAgeGroup, _formname = _str_DiagnosisAgeGroup, _type = "Lookup",
              _get_func = o => { if (o.DiagnosisAgeGroup == null) return null; return o.DiagnosisAgeGroup.idfsReference; },
              _set_func = (o, val) => { o.DiagnosisAgeGroup = o.DiagnosisAgeGroupLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_DiagnosisAgeGroup, c);
                if (o.idfsDiagnosisAgeGroup != c.idfsDiagnosisAgeGroup || o.IsRIRPropChanged(_str_DiagnosisAgeGroup, c) || bChangeLookupContent) {
                  m.Add(_str_DiagnosisAgeGroup, o.ObjectIdent + _str_DiagnosisAgeGroup, o.ObjectIdent2 + _str_DiagnosisAgeGroup, o.ObjectIdent3 + _str_DiagnosisAgeGroup, "Lookup", o.idfsDiagnosisAgeGroup == null ? "" : o.idfsDiagnosisAgeGroup.ToString(), o.IsReadOnly(_str_DiagnosisAgeGroup), o.IsInvisible(_str_DiagnosisAgeGroup), o.IsRequired(_str_DiagnosisAgeGroup),
                  bChangeLookupContent ? o.DiagnosisAgeGroupLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_DiagnosisAgeGroup + "Lookup", _formname = _str_DiagnosisAgeGroup + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisAgeGroupLookup,
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
            DiagnosisAgeGroupToDiagnosis obj = (DiagnosisAgeGroupToDiagnosis)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_DiagnosisAgeGroup)]
        [Relation(typeof(DiagnosisAgeGroupLookup), eidss.model.Schema.DiagnosisAgeGroupLookup._str_idfsReference, _str_idfsDiagnosisAgeGroup)]
        public DiagnosisAgeGroupLookup DiagnosisAgeGroup
        {
            get { return _DiagnosisAgeGroup == null ? null : ((long)_DiagnosisAgeGroup.Key == 0 ? null : _DiagnosisAgeGroup); }
            set 
            { 
                var oldVal = _DiagnosisAgeGroup;
                _DiagnosisAgeGroup = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_DiagnosisAgeGroup != oldVal)
                {
                    if (idfsDiagnosisAgeGroup != (_DiagnosisAgeGroup == null
                            ? new Int64?()
                            : (Int64?)_DiagnosisAgeGroup.idfsReference))
                        idfsDiagnosisAgeGroup = _DiagnosisAgeGroup == null 
                            ? new Int64?()
                            : (Int64?)_DiagnosisAgeGroup.idfsReference; 
                    OnPropertyChanged(_str_DiagnosisAgeGroup); 
                }
            }
        }
        private DiagnosisAgeGroupLookup _DiagnosisAgeGroup;

        
        public List<DiagnosisAgeGroupLookup> DiagnosisAgeGroupLookup
        {
            get { return _DiagnosisAgeGroupLookup; }
        }
        private List<DiagnosisAgeGroupLookup> _DiagnosisAgeGroupLookup = new List<DiagnosisAgeGroupLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_DiagnosisAgeGroup:
                    return new BvSelectList(DiagnosisAgeGroupLookup, eidss.model.Schema.DiagnosisAgeGroupLookup._str_idfsReference, null, DiagnosisAgeGroup, _str_idfsDiagnosisAgeGroup);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "DiagnosisAgeGroupToDiagnosis";

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
            var ret = base.Clone() as DiagnosisAgeGroupToDiagnosis;
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
            var ret = base.Clone() as DiagnosisAgeGroupToDiagnosis;
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
        public DiagnosisAgeGroupToDiagnosis CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as DiagnosisAgeGroupToDiagnosis;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfDiagnosisAgeGroupToDiagnosis; } }
        public string KeyName { get { return "idfDiagnosisAgeGroupToDiagnosis"; } }
        public object KeyLookup { get { return idfDiagnosisAgeGroupToDiagnosis; } }
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
        
            var _prev_idfsDiagnosisAgeGroup_DiagnosisAgeGroup = idfsDiagnosisAgeGroup;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosisAgeGroup_DiagnosisAgeGroup != idfsDiagnosisAgeGroup)
            {
                _DiagnosisAgeGroup = _DiagnosisAgeGroupLookup.FirstOrDefault(c => c.idfsReference == idfsDiagnosisAgeGroup);
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

        private bool IsRIRPropChanged(string fld, DiagnosisAgeGroupToDiagnosis c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, DiagnosisAgeGroupToDiagnosis c)
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
        

      

        public DiagnosisAgeGroupToDiagnosis()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(DiagnosisAgeGroupToDiagnosis_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(DiagnosisAgeGroupToDiagnosis_PropertyChanged);
        }
        private void DiagnosisAgeGroupToDiagnosis_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as DiagnosisAgeGroupToDiagnosis).Changed(e.PropertyName);
            
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
            DiagnosisAgeGroupToDiagnosis obj = this;
            
        }
        private void _DeletedExtenders()
        {
            DiagnosisAgeGroupToDiagnosis obj = this;
            
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


        internal Dictionary<string, Func<DiagnosisAgeGroupToDiagnosis, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<DiagnosisAgeGroupToDiagnosis, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<DiagnosisAgeGroupToDiagnosis, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<DiagnosisAgeGroupToDiagnosis, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<DiagnosisAgeGroupToDiagnosis, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<DiagnosisAgeGroupToDiagnosis, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<DiagnosisAgeGroupToDiagnosis, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~DiagnosisAgeGroupToDiagnosis()
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
                
                LookupManager.RemoveObject("DiagnosisAgeGroupLookup", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisAgeGroupLookup")
                _getAccessor().LoadLookup_DiagnosisAgeGroup(manager, this);
            
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
        public class DiagnosisAgeGroupToDiagnosisGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfDiagnosisAgeGroupToDiagnosis { get; set; }
        
            public Int64? idfsDiagnosisAgeGroup { get; set; }
        
        }
        public partial class DiagnosisAgeGroupToDiagnosisGridModelList : List<DiagnosisAgeGroupToDiagnosisGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public DiagnosisAgeGroupToDiagnosisGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<DiagnosisAgeGroupToDiagnosis>, errMes);
            }
            public DiagnosisAgeGroupToDiagnosisGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<DiagnosisAgeGroupToDiagnosis>, errMes);
            }
            public DiagnosisAgeGroupToDiagnosisGridModelList(long key, IEnumerable<DiagnosisAgeGroupToDiagnosis> items)
            {
                LoadGridModelList(key, items, null);
            }
            public DiagnosisAgeGroupToDiagnosisGridModelList(long key)
            {
                LoadGridModelList(key, new List<DiagnosisAgeGroupToDiagnosis>(), null);
            }
            partial void filter(List<DiagnosisAgeGroupToDiagnosis> items);
            private void LoadGridModelList(long key, IEnumerable<DiagnosisAgeGroupToDiagnosis> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_idfsDiagnosisAgeGroup};
                    
                Hiddens = new List<string> {_str_idfDiagnosisAgeGroupToDiagnosis};
                Keys = new List<string> {_str_idfDiagnosisAgeGroupToDiagnosis};
                Labels = new Dictionary<string, string> {{_str_idfsDiagnosisAgeGroup, "strAgeGroups"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                DiagnosisAgeGroupToDiagnosis.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<DiagnosisAgeGroupToDiagnosis>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new DiagnosisAgeGroupToDiagnosisGridModel()
                {
                    ItemKey=c.idfDiagnosisAgeGroupToDiagnosis,idfsDiagnosisAgeGroup=c.idfsDiagnosisAgeGroup
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
        : DataAccessor<DiagnosisAgeGroupToDiagnosis>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<DiagnosisAgeGroupToDiagnosis>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfDiagnosisAgeGroupToDiagnosis"; } }
            #endregion
        
            public delegate void on_action(DiagnosisAgeGroupToDiagnosis obj);
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
            private DiagnosisAgeGroupLookup.Accessor DiagnosisAgeGroupAccessor { get { return eidss.model.Schema.DiagnosisAgeGroupLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<DiagnosisAgeGroupToDiagnosis> SelectList(DbManagerProxy manager
                )
            {
                return _SelectList(manager
                    , delegate(DiagnosisAgeGroupToDiagnosis obj)
                        {
                        }
                    , delegate(DiagnosisAgeGroupToDiagnosis obj)
                        {
                        }
                    );
            }

            

            public List<DiagnosisAgeGroupToDiagnosis> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<DiagnosisAgeGroupToDiagnosis> _SelectListInternal(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
                DiagnosisAgeGroupToDiagnosis _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<DiagnosisAgeGroupToDiagnosis> objs = new List<DiagnosisAgeGroupToDiagnosis>();
                    sets[0] = new MapResultSet(typeof(DiagnosisAgeGroupToDiagnosis), objs);
                    
                    manager
                        .SetSpCommand("spDiagnosisAgeGroupToDiagnosis_SelectDetail"
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, DiagnosisAgeGroupToDiagnosis obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, DiagnosisAgeGroupToDiagnosis obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private DiagnosisAgeGroupToDiagnosis _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                DiagnosisAgeGroupToDiagnosis obj = null;
                try
                {
                    obj = DiagnosisAgeGroupToDiagnosis.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfDiagnosisAgeGroupToDiagnosis = (new GetNewIDExtender<DiagnosisAgeGroupToDiagnosis>()).GetScalar(manager, obj, isFake);
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

            
            public DiagnosisAgeGroupToDiagnosis CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public DiagnosisAgeGroupToDiagnosis CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public DiagnosisAgeGroupToDiagnosis CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(DiagnosisAgeGroupToDiagnosis obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(DiagnosisAgeGroupToDiagnosis obj)
            {
                
            }
    
            public void LoadLookup_DiagnosisAgeGroup(DbManagerProxy manager, DiagnosisAgeGroupToDiagnosis obj)
            {
                
                obj.DiagnosisAgeGroupLookup.Clear();
                
                obj.DiagnosisAgeGroupLookup.Add(DiagnosisAgeGroupAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisAgeGroupLookup.AddRange(DiagnosisAgeGroupAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsDiagnosisAgeGroup))
                    
                    .ToList());
                
                if (obj.idfsDiagnosisAgeGroup != null && obj.idfsDiagnosisAgeGroup != 0)
                {
                    obj.DiagnosisAgeGroup = obj.DiagnosisAgeGroupLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsDiagnosisAgeGroup);
                    
                }
              
                LookupManager.AddObject("DiagnosisAgeGroupLookup", obj, DiagnosisAgeGroupAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, DiagnosisAgeGroupToDiagnosis obj)
            {
                
                LoadLookup_DiagnosisAgeGroup(manager, obj);
                
            }
    
            [SprocName("spDiagnosisAgeGroupToDiagnosis_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] DiagnosisAgeGroupToDiagnosis obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] DiagnosisAgeGroupToDiagnosis obj)
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
                        DiagnosisAgeGroupToDiagnosis bo = obj as DiagnosisAgeGroupToDiagnosis;
                        
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
                        bSuccess = _PostNonTransaction(manager, obj as DiagnosisAgeGroupToDiagnosis, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, DiagnosisAgeGroupToDiagnosis obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(DiagnosisAgeGroupToDiagnosis obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, DiagnosisAgeGroupToDiagnosis obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(DiagnosisAgeGroupToDiagnosis obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(DiagnosisAgeGroupToDiagnosis obj, bool bRethrowException)
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
                return Validate(manager, obj as DiagnosisAgeGroupToDiagnosis, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, DiagnosisAgeGroupToDiagnosis obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsDiagnosisAgeGroup", "idfsDiagnosisAgeGroup","strAgeGroups",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsDiagnosisAgeGroup);
            
                  
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
           
    
            private void _SetupRequired(DiagnosisAgeGroupToDiagnosis obj)
            {
            
                obj
                    .AddRequired("idfsDiagnosisAgeGroup", c => true);
                    
                  obj
                    .AddRequired("DiagnosisAgeGroup", c => true);
                
            }
    
    private void _SetupPersonalDataRestrictions(DiagnosisAgeGroupToDiagnosis obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as DiagnosisAgeGroupToDiagnosis) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as DiagnosisAgeGroupToDiagnosis) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "DiagnosisAgeGroupToDiagnosisDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spDiagnosisAgeGroupToDiagnosis_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spDiagnosisAgeGroupToDiagnosis_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<DiagnosisAgeGroupToDiagnosis, bool>> RequiredByField = new Dictionary<string, Func<DiagnosisAgeGroupToDiagnosis, bool>>();
            public static Dictionary<string, Func<DiagnosisAgeGroupToDiagnosis, bool>> RequiredByProperty = new Dictionary<string, Func<DiagnosisAgeGroupToDiagnosis, bool>>();
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
                
                if (!RequiredByField.ContainsKey("idfsDiagnosisAgeGroup")) RequiredByField.Add("idfsDiagnosisAgeGroup", c => true);
                if (!RequiredByProperty.ContainsKey("idfsDiagnosisAgeGroup")) RequiredByProperty.Add("idfsDiagnosisAgeGroup", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfDiagnosisAgeGroupToDiagnosis,
                    _str_idfDiagnosisAgeGroupToDiagnosis, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsDiagnosisAgeGroup,
                    "strAgeGroups", null, true, true, true, true, true, null
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
                    (manager, c, pars) => ((DiagnosisAgeGroupToDiagnosis)c).MarkToDelete(),
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
	