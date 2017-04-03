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
    public abstract partial class DiagnosisAgeGroup2StatisticalAgeGroup : 
        EditableObject<DiagnosisAgeGroup2StatisticalAgeGroup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfDiagnosisAgeGroupToStatisticalAgeGroup), NonUpdatable, PrimaryKey]
        public abstract Int64 idfDiagnosisAgeGroupToStatisticalAgeGroup { get; set; }
                
        [LocalizedDisplayName(_str_idfsDiagnosisAgeGroup)]
        [MapField(_str_idfsDiagnosisAgeGroup)]
        public abstract Int64 idfsDiagnosisAgeGroup { get; set; }
        protected Int64 idfsDiagnosisAgeGroup_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosisAgeGroup).OriginalValue; } }
        protected Int64 idfsDiagnosisAgeGroup_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosisAgeGroup).PreviousValue; } }
                
        [LocalizedDisplayName("strStatisticalAgeGroup")]
        [MapField(_str_idfsStatisticalAgeGroup)]
        public abstract Int64? idfsStatisticalAgeGroup { get; set; }
        protected Int64? idfsStatisticalAgeGroup_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStatisticalAgeGroup).OriginalValue; } }
        protected Int64? idfsStatisticalAgeGroup_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStatisticalAgeGroup).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<DiagnosisAgeGroup2StatisticalAgeGroup, object> _get_func;
            internal Action<DiagnosisAgeGroup2StatisticalAgeGroup, string> _set_func;
            internal Action<DiagnosisAgeGroup2StatisticalAgeGroup, DiagnosisAgeGroup2StatisticalAgeGroup, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfDiagnosisAgeGroupToStatisticalAgeGroup = "idfDiagnosisAgeGroupToStatisticalAgeGroup";
        internal const string _str_idfsDiagnosisAgeGroup = "idfsDiagnosisAgeGroup";
        internal const string _str_idfsStatisticalAgeGroup = "idfsStatisticalAgeGroup";
        internal const string _str_StatisticalAgeGroup = "StatisticalAgeGroup";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfDiagnosisAgeGroupToStatisticalAgeGroup, _formname = _str_idfDiagnosisAgeGroupToStatisticalAgeGroup, _type = "Int64",
              _get_func = o => o.idfDiagnosisAgeGroupToStatisticalAgeGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfDiagnosisAgeGroupToStatisticalAgeGroup != newval) o.idfDiagnosisAgeGroupToStatisticalAgeGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfDiagnosisAgeGroupToStatisticalAgeGroup != c.idfDiagnosisAgeGroupToStatisticalAgeGroup || o.IsRIRPropChanged(_str_idfDiagnosisAgeGroupToStatisticalAgeGroup, c)) 
                  m.Add(_str_idfDiagnosisAgeGroupToStatisticalAgeGroup, o.ObjectIdent + _str_idfDiagnosisAgeGroupToStatisticalAgeGroup, o.ObjectIdent2 + _str_idfDiagnosisAgeGroupToStatisticalAgeGroup, o.ObjectIdent3 + _str_idfDiagnosisAgeGroupToStatisticalAgeGroup, "Int64", 
                    o.idfDiagnosisAgeGroupToStatisticalAgeGroup == null ? "" : o.idfDiagnosisAgeGroupToStatisticalAgeGroup.ToString(),                  
                  o.IsReadOnly(_str_idfDiagnosisAgeGroupToStatisticalAgeGroup), o.IsInvisible(_str_idfDiagnosisAgeGroupToStatisticalAgeGroup), o.IsRequired(_str_idfDiagnosisAgeGroupToStatisticalAgeGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosisAgeGroup, _formname = _str_idfsDiagnosisAgeGroup, _type = "Int64",
              _get_func = o => o.idfsDiagnosisAgeGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsDiagnosisAgeGroup != newval) o.idfsDiagnosisAgeGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosisAgeGroup != c.idfsDiagnosisAgeGroup || o.IsRIRPropChanged(_str_idfsDiagnosisAgeGroup, c)) 
                  m.Add(_str_idfsDiagnosisAgeGroup, o.ObjectIdent + _str_idfsDiagnosisAgeGroup, o.ObjectIdent2 + _str_idfsDiagnosisAgeGroup, o.ObjectIdent3 + _str_idfsDiagnosisAgeGroup, "Int64", 
                    o.idfsDiagnosisAgeGroup == null ? "" : o.idfsDiagnosisAgeGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosisAgeGroup), o.IsInvisible(_str_idfsDiagnosisAgeGroup), o.IsRequired(_str_idfsDiagnosisAgeGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsStatisticalAgeGroup, _formname = _str_idfsStatisticalAgeGroup, _type = "Int64?",
              _get_func = o => o.idfsStatisticalAgeGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsStatisticalAgeGroup != newval) 
                  o.StatisticalAgeGroup = o.StatisticalAgeGroupLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsStatisticalAgeGroup != newval) o.idfsStatisticalAgeGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsStatisticalAgeGroup != c.idfsStatisticalAgeGroup || o.IsRIRPropChanged(_str_idfsStatisticalAgeGroup, c)) 
                  m.Add(_str_idfsStatisticalAgeGroup, o.ObjectIdent + _str_idfsStatisticalAgeGroup, o.ObjectIdent2 + _str_idfsStatisticalAgeGroup, o.ObjectIdent3 + _str_idfsStatisticalAgeGroup, "Int64?", 
                    o.idfsStatisticalAgeGroup == null ? "" : o.idfsStatisticalAgeGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsStatisticalAgeGroup), o.IsInvisible(_str_idfsStatisticalAgeGroup), o.IsRequired(_str_idfsStatisticalAgeGroup)); 
                  }
              }, 
        
            new field_info {
              _name = _str_StatisticalAgeGroup, _formname = _str_StatisticalAgeGroup, _type = "Lookup",
              _get_func = o => { if (o.StatisticalAgeGroup == null) return null; return o.StatisticalAgeGroup.idfsBaseReference; },
              _set_func = (o, val) => { o.StatisticalAgeGroup = o.StatisticalAgeGroupLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsStatisticalAgeGroup != c.idfsStatisticalAgeGroup || o.IsRIRPropChanged(_str_StatisticalAgeGroup, c)) {
                  m.Add(_str_StatisticalAgeGroup, o.ObjectIdent + _str_StatisticalAgeGroup, o.ObjectIdent2 + _str_StatisticalAgeGroup, o.ObjectIdent3 + _str_StatisticalAgeGroup, "Lookup", o.idfsStatisticalAgeGroup == null ? "" : o.idfsStatisticalAgeGroup.ToString(), o.IsReadOnly(_str_StatisticalAgeGroup), o.IsInvisible(_str_StatisticalAgeGroup), o.IsRequired(_str_StatisticalAgeGroup)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_StatisticalAgeGroup + "Lookup", _formname = _str_StatisticalAgeGroup + "Lookup", _type = "LookupContent",
              _get_func = o => o.StatisticalAgeGroupLookup,
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
            DiagnosisAgeGroup2StatisticalAgeGroup obj = (DiagnosisAgeGroup2StatisticalAgeGroup)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_StatisticalAgeGroup)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsStatisticalAgeGroup)]
        public BaseReference StatisticalAgeGroup
        {
            get { return _StatisticalAgeGroup == null ? null : ((long)_StatisticalAgeGroup.Key == 0 ? null : _StatisticalAgeGroup); }
            set 
            { 
                var oldVal = _StatisticalAgeGroup;
                _StatisticalAgeGroup = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_StatisticalAgeGroup != oldVal)
                {
                    if (idfsStatisticalAgeGroup != (_StatisticalAgeGroup == null
                            ? new Int64?()
                            : (Int64?)_StatisticalAgeGroup.idfsBaseReference))
                        idfsStatisticalAgeGroup = _StatisticalAgeGroup == null 
                            ? new Int64?()
                            : (Int64?)_StatisticalAgeGroup.idfsBaseReference; 
                    OnPropertyChanged(_str_StatisticalAgeGroup); 
                }
            }
        }
        private BaseReference _StatisticalAgeGroup;

        
        public BaseReferenceList StatisticalAgeGroupLookup
        {
            get { return _StatisticalAgeGroupLookup; }
        }
        private BaseReferenceList _StatisticalAgeGroupLookup = new BaseReferenceList("rftStatisticalAgeGroup");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_StatisticalAgeGroup:
                    return new BvSelectList(StatisticalAgeGroupLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, StatisticalAgeGroup, _str_idfsStatisticalAgeGroup);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "DiagnosisAgeGroup2StatisticalAgeGroup";

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
            var ret = base.Clone() as DiagnosisAgeGroup2StatisticalAgeGroup;
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
            var ret = base.Clone() as DiagnosisAgeGroup2StatisticalAgeGroup;
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
        public DiagnosisAgeGroup2StatisticalAgeGroup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as DiagnosisAgeGroup2StatisticalAgeGroup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfDiagnosisAgeGroupToStatisticalAgeGroup; } }
        public string KeyName { get { return "idfDiagnosisAgeGroupToStatisticalAgeGroup"; } }
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
        
            var _prev_idfsStatisticalAgeGroup_StatisticalAgeGroup = idfsStatisticalAgeGroup;
            base.RejectChanges();
        
            if (_prev_idfsStatisticalAgeGroup_StatisticalAgeGroup != idfsStatisticalAgeGroup)
            {
                _StatisticalAgeGroup = _StatisticalAgeGroupLookup.FirstOrDefault(c => c.idfsBaseReference == idfsStatisticalAgeGroup);
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

        private bool IsRIRPropChanged(string fld, DiagnosisAgeGroup2StatisticalAgeGroup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public DiagnosisAgeGroup2StatisticalAgeGroup()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(DiagnosisAgeGroup2StatisticalAgeGroup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(DiagnosisAgeGroup2StatisticalAgeGroup_PropertyChanged);
        }
        private void DiagnosisAgeGroup2StatisticalAgeGroup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as DiagnosisAgeGroup2StatisticalAgeGroup).Changed(e.PropertyName);
            
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
            DiagnosisAgeGroup2StatisticalAgeGroup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            DiagnosisAgeGroup2StatisticalAgeGroup obj = this;
            
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


        internal Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroup, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroup, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<DiagnosisAgeGroup2StatisticalAgeGroup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<DiagnosisAgeGroup2StatisticalAgeGroup, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroup, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~DiagnosisAgeGroup2StatisticalAgeGroup()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftStatisticalAgeGroup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftStatisticalAgeGroup")
                _getAccessor().LoadLookup_StatisticalAgeGroup(manager, this);
            
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
        public class DiagnosisAgeGroup2StatisticalAgeGroupGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfDiagnosisAgeGroupToStatisticalAgeGroup { get; set; }
        
            public Int64? idfsStatisticalAgeGroup { get; set; }
        
        }
        public partial class DiagnosisAgeGroup2StatisticalAgeGroupGridModelList : List<DiagnosisAgeGroup2StatisticalAgeGroupGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public DiagnosisAgeGroup2StatisticalAgeGroupGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<DiagnosisAgeGroup2StatisticalAgeGroup>, errMes);
            }
            public DiagnosisAgeGroup2StatisticalAgeGroupGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<DiagnosisAgeGroup2StatisticalAgeGroup>, errMes);
            }
            public DiagnosisAgeGroup2StatisticalAgeGroupGridModelList(long key, IEnumerable<DiagnosisAgeGroup2StatisticalAgeGroup> items)
            {
                LoadGridModelList(key, items, null);
            }
            public DiagnosisAgeGroup2StatisticalAgeGroupGridModelList(long key)
            {
                LoadGridModelList(key, new List<DiagnosisAgeGroup2StatisticalAgeGroup>(), null);
            }
            partial void filter(List<DiagnosisAgeGroup2StatisticalAgeGroup> items);
            private void LoadGridModelList(long key, IEnumerable<DiagnosisAgeGroup2StatisticalAgeGroup> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_idfsStatisticalAgeGroup};
                    
                Hiddens = new List<string> {_str_idfDiagnosisAgeGroupToStatisticalAgeGroup};
                Keys = new List<string> {_str_idfDiagnosisAgeGroupToStatisticalAgeGroup};
                Labels = new Dictionary<string, string> {{_str_idfsStatisticalAgeGroup, "strStatisticalAgeGroup"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                DiagnosisAgeGroup2StatisticalAgeGroup.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<DiagnosisAgeGroup2StatisticalAgeGroup>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new DiagnosisAgeGroup2StatisticalAgeGroupGridModel()
                {
                    ItemKey=c.idfDiagnosisAgeGroupToStatisticalAgeGroup,idfsStatisticalAgeGroup=c.idfsStatisticalAgeGroup
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
        : DataAccessor<DiagnosisAgeGroup2StatisticalAgeGroup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<DiagnosisAgeGroup2StatisticalAgeGroup>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfDiagnosisAgeGroupToStatisticalAgeGroup"; } }
            #endregion
        
            private delegate void on_action(DiagnosisAgeGroup2StatisticalAgeGroup obj);
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
            private BaseReference.Accessor StatisticalAgeGroupAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<DiagnosisAgeGroup2StatisticalAgeGroup> SelectList(DbManagerProxy manager
                )
            {
                return _SelectList(manager
                    , delegate(DiagnosisAgeGroup2StatisticalAgeGroup obj)
                        {
                        }
                    , delegate(DiagnosisAgeGroup2StatisticalAgeGroup obj)
                        {
                        }
                    );
            }

            
            private List<DiagnosisAgeGroup2StatisticalAgeGroup> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<DiagnosisAgeGroup2StatisticalAgeGroup> objs = new List<DiagnosisAgeGroup2StatisticalAgeGroup>();
                    sets[0] = new MapResultSet(typeof(DiagnosisAgeGroup2StatisticalAgeGroup), objs);
                    
                    manager
                        .SetSpCommand("spDiagnosisAgeGroupToStatisticalAgeGroup_SelectDetail"
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, DiagnosisAgeGroup2StatisticalAgeGroup obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, DiagnosisAgeGroup2StatisticalAgeGroup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private DiagnosisAgeGroup2StatisticalAgeGroup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    DiagnosisAgeGroup2StatisticalAgeGroup obj = DiagnosisAgeGroup2StatisticalAgeGroup.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfDiagnosisAgeGroupToStatisticalAgeGroup = (new GetNewIDExtender<DiagnosisAgeGroup2StatisticalAgeGroup>()).GetScalar(manager, obj, isFake);
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

            
            public DiagnosisAgeGroup2StatisticalAgeGroup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public DiagnosisAgeGroup2StatisticalAgeGroup CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public DiagnosisAgeGroup2StatisticalAgeGroup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(DiagnosisAgeGroup2StatisticalAgeGroup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(DiagnosisAgeGroup2StatisticalAgeGroup obj)
            {
                
            }
    
            public void LoadLookup_StatisticalAgeGroup(DbManagerProxy manager, DiagnosisAgeGroup2StatisticalAgeGroup obj)
            {
                
                obj.StatisticalAgeGroupLookup.Clear();
                
                obj.StatisticalAgeGroupLookup.Add(StatisticalAgeGroupAccessor.CreateNewT(manager, null));
                
                obj.StatisticalAgeGroupLookup.AddRange(StatisticalAgeGroupAccessor.rftStatisticalAgeGroup_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsStatisticalAgeGroup))
                    
                    .ToList());
                
                if (obj.idfsStatisticalAgeGroup != null && obj.idfsStatisticalAgeGroup != 0)
                {
                    obj.StatisticalAgeGroup = obj.StatisticalAgeGroupLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsStatisticalAgeGroup);
                    
                }
              
                
                LookupManager.AddObject("rftStatisticalAgeGroup", obj, StatisticalAgeGroupAccessor.GetType(), "rftStatisticalAgeGroup_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, DiagnosisAgeGroup2StatisticalAgeGroup obj)
            {
                
                LoadLookup_StatisticalAgeGroup(manager, obj);
                
            }
    
            [SprocName("spDiagnosisAgeGroupToStatisticalAgeGroup_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] DiagnosisAgeGroup2StatisticalAgeGroup obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] DiagnosisAgeGroup2StatisticalAgeGroup obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    DiagnosisAgeGroup2StatisticalAgeGroup bo = obj as DiagnosisAgeGroup2StatisticalAgeGroup;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as DiagnosisAgeGroup2StatisticalAgeGroup, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, DiagnosisAgeGroup2StatisticalAgeGroup obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(DiagnosisAgeGroup2StatisticalAgeGroup obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, DiagnosisAgeGroup2StatisticalAgeGroup obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(DiagnosisAgeGroup2StatisticalAgeGroup obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(DiagnosisAgeGroup2StatisticalAgeGroup obj, bool bRethrowException)
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
                return Validate(manager, obj as DiagnosisAgeGroup2StatisticalAgeGroup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, DiagnosisAgeGroup2StatisticalAgeGroup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsStatisticalAgeGroup", "idfsStatisticalAgeGroup","strStatisticalAgeGroup",
                false
              )).Validate(c => true, obj, obj.idfsStatisticalAgeGroup);
            
                  
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
           
    
            private void _SetupRequired(DiagnosisAgeGroup2StatisticalAgeGroup obj)
            {
            
                obj
                    .AddRequired("idfsStatisticalAgeGroup", c => true);
                    
                  obj
                    .AddRequired("StatisticalAgeGroup", c => true);
                
            }
    
    private void _SetupPersonalDataRestrictions(DiagnosisAgeGroup2StatisticalAgeGroup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as DiagnosisAgeGroup2StatisticalAgeGroup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as DiagnosisAgeGroup2StatisticalAgeGroup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "DiagnosisAgeGroup2StatisticalAgeGroupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spDiagnosisAgeGroupToStatisticalAgeGroup_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spDiagnosisAgeGroupToStatisticalAgeGroup_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroup, bool>> RequiredByField = new Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroup, bool>>();
            public static Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroup, bool>> RequiredByProperty = new Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroup, bool>>();
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
                
                if (!RequiredByField.ContainsKey("idfsStatisticalAgeGroup")) RequiredByField.Add("idfsStatisticalAgeGroup", c => true);
                if (!RequiredByProperty.ContainsKey("idfsStatisticalAgeGroup")) RequiredByProperty.Add("idfsStatisticalAgeGroup", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfDiagnosisAgeGroupToStatisticalAgeGroup,
                    _str_idfDiagnosisAgeGroupToStatisticalAgeGroup, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsStatisticalAgeGroup,
                    "strStatisticalAgeGroup", null, true, true, true, true, null
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
                    (manager, c, pars) => ((DiagnosisAgeGroup2StatisticalAgeGroup)c).MarkToDelete(),
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
	