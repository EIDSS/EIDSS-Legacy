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
    public abstract partial class DiagnosisAgeGroup2StatisticalAgeGroupMaster : 
        EditableObject<DiagnosisAgeGroup2StatisticalAgeGroupMaster>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsDiagnosisAgeGroup), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsDiagnosisAgeGroup { get; set; }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<DiagnosisAgeGroup2StatisticalAgeGroupMaster, object> _get_func;
            internal Action<DiagnosisAgeGroup2StatisticalAgeGroupMaster, string> _set_func;
            internal Action<DiagnosisAgeGroup2StatisticalAgeGroupMaster, DiagnosisAgeGroup2StatisticalAgeGroupMaster, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsDiagnosisAgeGroup = "idfsDiagnosisAgeGroup";
        internal const string _str_DiagnosisAgeGroup = "DiagnosisAgeGroup";
        internal const string _str_DAG2SAG = "DAG2SAG";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsDiagnosisAgeGroup, _formname = _str_idfsDiagnosisAgeGroup, _type = "Int64",
              _get_func = o => o.idfsDiagnosisAgeGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsDiagnosisAgeGroup != newval) 
                  o.DiagnosisAgeGroup = o.DiagnosisAgeGroupLookup.FirstOrDefault(c => c.idfsReference == newval);
                if (o.idfsDiagnosisAgeGroup != newval) o.idfsDiagnosisAgeGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosisAgeGroup != c.idfsDiagnosisAgeGroup || o.IsRIRPropChanged(_str_idfsDiagnosisAgeGroup, c)) 
                  m.Add(_str_idfsDiagnosisAgeGroup, o.ObjectIdent + _str_idfsDiagnosisAgeGroup, o.ObjectIdent2 + _str_idfsDiagnosisAgeGroup, o.ObjectIdent3 + _str_idfsDiagnosisAgeGroup, "Int64", 
                    o.idfsDiagnosisAgeGroup == null ? "" : o.idfsDiagnosisAgeGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosisAgeGroup), o.IsInvisible(_str_idfsDiagnosisAgeGroup), o.IsRequired(_str_idfsDiagnosisAgeGroup)); 
                  }
              }, 
        
            new field_info {
              _name = _str_DiagnosisAgeGroup, _formname = _str_DiagnosisAgeGroup, _type = "Lookup",
              _get_func = o => { if (o.DiagnosisAgeGroup == null) return null; return o.DiagnosisAgeGroup.idfsReference; },
              _set_func = (o, val) => { o.DiagnosisAgeGroup = o.DiagnosisAgeGroupLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosisAgeGroup != c.idfsDiagnosisAgeGroup || o.IsRIRPropChanged(_str_DiagnosisAgeGroup, c)) {
                  m.Add(_str_DiagnosisAgeGroup, o.ObjectIdent + _str_DiagnosisAgeGroup, o.ObjectIdent2 + _str_DiagnosisAgeGroup, o.ObjectIdent3 + _str_DiagnosisAgeGroup, "Lookup", o.idfsDiagnosisAgeGroup == null ? "" : o.idfsDiagnosisAgeGroup.ToString(), o.IsReadOnly(_str_DiagnosisAgeGroup), o.IsInvisible(_str_DiagnosisAgeGroup), o.IsRequired(_str_DiagnosisAgeGroup)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_DiagnosisAgeGroup + "Lookup", _formname = _str_DiagnosisAgeGroup + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisAgeGroupLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_DAG2SAG, _formname = _str_DAG2SAG, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.DAG2SAG.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.DAG2SAG.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.DAG2SAG.Count != c.DAG2SAG.Count || o.IsReadOnly(_str_DAG2SAG) != c.IsReadOnly(_str_DAG2SAG) || o.IsInvisible(_str_DAG2SAG) != c.IsInvisible(_str_DAG2SAG) || o.IsRequired(_str_DAG2SAG) != c._isRequired(o.m_isRequired, _str_DAG2SAG)) {
                  m.Add(_str_DAG2SAG, o.ObjectIdent + _str_DAG2SAG, o.ObjectIdent2 + _str_DAG2SAG, o.ObjectIdent3 + _str_DAG2SAG, "Child", o.idfsDiagnosisAgeGroup == null ? "" : o.idfsDiagnosisAgeGroup.ToString(), o.IsReadOnly(_str_DAG2SAG), o.IsInvisible(_str_DAG2SAG), o.IsRequired(_str_DAG2SAG)); 
                  }
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
            DiagnosisAgeGroup2StatisticalAgeGroupMaster obj = (DiagnosisAgeGroup2StatisticalAgeGroupMaster)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_DAG2SAG)]
        [Relation(typeof(DiagnosisAgeGroup2StatisticalAgeGroup), eidss.model.Schema.DiagnosisAgeGroup2StatisticalAgeGroup._str_idfsDiagnosisAgeGroup, _str_idfsDiagnosisAgeGroup)]
        public EditableList<DiagnosisAgeGroup2StatisticalAgeGroup> DAG2SAG
        {
            get 
            {   
                return _DAG2SAG; 
            }
            set 
            {
                _DAG2SAG = value;
            }
        }
        protected EditableList<DiagnosisAgeGroup2StatisticalAgeGroup> _DAG2SAG = new EditableList<DiagnosisAgeGroup2StatisticalAgeGroup>();
                    
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
                            ? new Int64()
                            : (Int64)_DiagnosisAgeGroup.idfsReference))
                        idfsDiagnosisAgeGroup = _DiagnosisAgeGroup == null 
                            ? new Int64()
                            : (Int64)_DiagnosisAgeGroup.idfsReference; 
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
            
                case _str_DAG2SAG:
                    return new BvSelectList(DAG2SAG, "", "", null, "");
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "DiagnosisAgeGroup2StatisticalAgeGroupMaster";

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
        DAG2SAG.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as DiagnosisAgeGroup2StatisticalAgeGroupMaster;
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
            var ret = base.Clone() as DiagnosisAgeGroup2StatisticalAgeGroupMaster;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_DAG2SAG != null && _DAG2SAG.Count > 0)
            {
              ret.DAG2SAG.Clear();
              _DAG2SAG.ForEach(c => ret.DAG2SAG.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public DiagnosisAgeGroup2StatisticalAgeGroupMaster CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as DiagnosisAgeGroup2StatisticalAgeGroupMaster;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsDiagnosisAgeGroup; } }
        public string KeyName { get { return "idfsDiagnosisAgeGroup"; } }
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
        
                    || DAG2SAG.IsDirty
                    || DAG2SAG.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
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
        DAG2SAG.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        DAG2SAG.DeepAcceptChanges();
                
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
        DAG2SAG.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, DiagnosisAgeGroup2StatisticalAgeGroupMaster c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public DiagnosisAgeGroup2StatisticalAgeGroupMaster()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(DiagnosisAgeGroup2StatisticalAgeGroupMaster_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(DiagnosisAgeGroup2StatisticalAgeGroupMaster_PropertyChanged);
        }
        private void DiagnosisAgeGroup2StatisticalAgeGroupMaster_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as DiagnosisAgeGroup2StatisticalAgeGroupMaster).Changed(e.PropertyName);
            
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
            DiagnosisAgeGroup2StatisticalAgeGroupMaster obj = this;
            
        }
        private void _DeletedExtenders()
        {
            DiagnosisAgeGroup2StatisticalAgeGroupMaster obj = this;
            
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

    
        private static string[] readonly_names1 = "DiagnosisAgeGroup".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return  new Func<DiagnosisAgeGroup2StatisticalAgeGroupMaster, bool>(c => false)(this);
            
            return ReadOnly;
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _DAG2SAG)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroupMaster, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroupMaster, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<DiagnosisAgeGroup2StatisticalAgeGroupMaster, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroupMaster, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroupMaster, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<DiagnosisAgeGroup2StatisticalAgeGroupMaster, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroupMaster, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~DiagnosisAgeGroup2StatisticalAgeGroupMaster()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                DAG2SAG.ForEach(c => c.Dispose());
                
                LookupManager.RemoveObject("DiagnosisAgeGroupLookup", this);
                
            }
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
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            if (_DAG2SAG != null) _DAG2SAG.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<DiagnosisAgeGroup2StatisticalAgeGroupMaster>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<DiagnosisAgeGroup2StatisticalAgeGroupMaster>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<DiagnosisAgeGroup2StatisticalAgeGroupMaster>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsDiagnosisAgeGroup"; } }
            #endregion
        
            private delegate void on_action(DiagnosisAgeGroup2StatisticalAgeGroupMaster obj);
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
            private DiagnosisAgeGroup2StatisticalAgeGroup.Accessor DAG2SAGAccessor { get { return eidss.model.Schema.DiagnosisAgeGroup2StatisticalAgeGroup.Accessor.Instance(m_CS); } }
            private DiagnosisAgeGroupLookup.Accessor DiagnosisAgeGroupAccessor { get { return eidss.model.Schema.DiagnosisAgeGroupLookup.Accessor.Instance(m_CS); } }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , null, null
                        );
                }
            }
            public virtual DiagnosisAgeGroup2StatisticalAgeGroupMaster SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , null, null
                        );
                }
            }

            
            public virtual DiagnosisAgeGroup2StatisticalAgeGroupMaster SelectByKey(DbManagerProxy manager
                )
            {
                return _SelectByKey(manager
                    , null, null
                    );
            }
            
      
            private DiagnosisAgeGroup2StatisticalAgeGroupMaster _SelectByKey(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<DiagnosisAgeGroup2StatisticalAgeGroupMaster> objs = new List<DiagnosisAgeGroup2StatisticalAgeGroupMaster>();
                sets[0] = new MapResultSet(typeof(DiagnosisAgeGroup2StatisticalAgeGroupMaster), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spDiagnosisAgeGroupMaster_SelectDetail"
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    DiagnosisAgeGroup2StatisticalAgeGroupMaster obj = objs[0];
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
    
            private void _SetupAddChildHandlerDAG2SAG(DiagnosisAgeGroup2StatisticalAgeGroupMaster obj)
            {
                obj.DAG2SAG.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            internal void _LoadDAG2SAG(DiagnosisAgeGroup2StatisticalAgeGroupMaster obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadDAG2SAG(manager, obj);
                }
            }
            internal void _LoadDAG2SAG(DbManagerProxy manager, DiagnosisAgeGroup2StatisticalAgeGroupMaster obj)
            {
                
                obj.DAG2SAG.Clear();
                obj.DAG2SAG.AddRange(DAG2SAGAccessor.SelectDetailList(manager
                    
                    , obj.idfsDiagnosisAgeGroup
                    ));
                obj.DAG2SAG.ForEach(c => c.m_ObjectName = _str_DAG2SAG);
                obj.DAG2SAG.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, DiagnosisAgeGroup2StatisticalAgeGroupMaster obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadDAG2SAG(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerDAG2SAG(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, DiagnosisAgeGroup2StatisticalAgeGroupMaster obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.DAG2SAG.ForEach(c => DAG2SAGAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private DiagnosisAgeGroup2StatisticalAgeGroupMaster _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    DiagnosisAgeGroup2StatisticalAgeGroupMaster obj = DiagnosisAgeGroup2StatisticalAgeGroupMaster.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
              obj.m_IsNew = false;
              var accMaster = DiagnosisAgeGroup2StatisticalAgeGroupMaster.Accessor.Instance(null);
              accMaster._LoadDAG2SAG(manager, obj);
            
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerDAG2SAG(obj);
                    
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

            
            public DiagnosisAgeGroup2StatisticalAgeGroupMaster CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public DiagnosisAgeGroup2StatisticalAgeGroupMaster CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public DiagnosisAgeGroup2StatisticalAgeGroupMaster CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult DeleteStatisticalAgeGroup(DbManagerProxy manager, DiagnosisAgeGroup2StatisticalAgeGroupMaster obj, List<object> pars)
            {
                
                return DeleteStatisticalAgeGroup(manager, obj
                    );
            }
            public ActResult DeleteStatisticalAgeGroup(DbManagerProxy manager, DiagnosisAgeGroup2StatisticalAgeGroupMaster obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("DeleteStatisticalAgeGroup"))
                    throw new PermissionException("Reference", "DeleteStatisticalAgeGroup");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(DiagnosisAgeGroup2StatisticalAgeGroupMaster obj, object newobj)
            {
                
                foreach(var o in obj.DAG2SAG.Where(c => true))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "idfsStatisticalAgeGroup")
                                {
                                
                (new RequiredValidator( "idfsStatisticalAgeGroup", "idfsStatisticalAgeGroup","strStatisticalAgeGroup",
                false
              )).Validate(c => true, item, item.idfsStatisticalAgeGroup);
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("idfsStatisticalAgeGroup");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        
                    }
                }
                            
            }
            
            private void _SetupHandlers(DiagnosisAgeGroup2StatisticalAgeGroupMaster obj)
            {
                
            }
    
            public void LoadLookup_DiagnosisAgeGroup(DbManagerProxy manager, DiagnosisAgeGroup2StatisticalAgeGroupMaster obj)
            {
                
                obj.DiagnosisAgeGroupLookup.Clear();
                
                obj.DiagnosisAgeGroupLookup.Add(DiagnosisAgeGroupAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisAgeGroupLookup.AddRange(DiagnosisAgeGroupAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsDiagnosisAgeGroup))
                    
                    .ToList());
                
                if (obj.idfsDiagnosisAgeGroup != 0)
                {
                    obj.DiagnosisAgeGroup = obj.DiagnosisAgeGroupLookup
                        .SingleOrDefault(c => c.idfsReference == obj.idfsDiagnosisAgeGroup);
                    
                }
              
                
                LookupManager.AddObject("DiagnosisAgeGroupLookup", obj, DiagnosisAgeGroupAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, DiagnosisAgeGroup2StatisticalAgeGroupMaster obj)
            {
                
                LoadLookup_DiagnosisAgeGroup(manager, obj);
                
            }
    
            [SprocName("spDiagnosisAgeGroup2StatisticalAgeGroupMaster_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                )
            {
                
                _postDelete(manager);
                
            }
        
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spDummy_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] DiagnosisAgeGroup2StatisticalAgeGroupMaster obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] DiagnosisAgeGroup2StatisticalAgeGroupMaster obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    DiagnosisAgeGroup2StatisticalAgeGroupMaster bo = obj as DiagnosisAgeGroup2StatisticalAgeGroupMaster;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("Reference", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("Reference", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("Reference", "Update");
                    }
                    
                    long mainObject = bo.idfsDiagnosisAgeGroup;
                    
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
                        
                          eidss.model.Enums.EventType eventType = eidss.model.Enums.EventType.RaiseReferenceCacheChange;
                          
                          manager.SetEventParams(false, "Statistic", new object[] { eventType, null, "Statistic" });
                          
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoReference;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.trtBaseReference;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as DiagnosisAgeGroup2StatisticalAgeGroupMaster, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, DiagnosisAgeGroup2StatisticalAgeGroupMaster obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.DAG2SAG != null)
                    {
                        foreach (var i in obj.DAG2SAG)
                        {
                            i.MarkToDelete();
                            if (!DAG2SAGAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (obj.IsNew)
                    {
                        if (obj.DAG2SAG != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.DAG2SAG)
                                if (!DAG2SAGAccessor.Post(manager, i, true))
                                    return false;
                            obj.DAG2SAG.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.DAG2SAG.Remove(c));
                            obj.DAG2SAG.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._DAG2SAG != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._DAG2SAG)
                                if (!DAG2SAGAccessor.Post(manager, i, true))
                                    return false;
                            obj._DAG2SAG.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._DAG2SAG.Remove(c));
                            obj._DAG2SAG.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(DiagnosisAgeGroup2StatisticalAgeGroupMaster obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, DiagnosisAgeGroup2StatisticalAgeGroupMaster obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(DiagnosisAgeGroup2StatisticalAgeGroupMaster obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(DiagnosisAgeGroup2StatisticalAgeGroupMaster obj, bool bRethrowException)
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
                return Validate(manager, obj as DiagnosisAgeGroup2StatisticalAgeGroupMaster, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, DiagnosisAgeGroup2StatisticalAgeGroupMaster obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
              new DuplicateListValidator("").Validate(obj, 
              o => o.DAG2SAG.Where(c => !c.IsMarkedToDelete)
                .Aggregate(new List<Tuple<DiagnosisAgeGroup2StatisticalAgeGroup, int>>(), (list, test) => 
                { 
                    var item = list.Find(c => true
                      
                        && c.Item1.idfsStatisticalAgeGroup == test.idfsStatisticalAgeGroup
                        && c.Item1.idfsDiagnosisAgeGroup == test.idfsDiagnosisAgeGroup
                      );
                      if (item == null)
                      list.Add(new Tuple<DiagnosisAgeGroup2StatisticalAgeGroup, int>(test, 1));
                    else
                    {
                        list.Remove(item);
                        list.Add(new Tuple<DiagnosisAgeGroup2StatisticalAgeGroup, int>(test, item.Item2 + 1));
                    }
                    return list;
                })
                .Where(c => c.Item2 > 1).Select(c => c.Item1).FirstOrDefault(),
                    (o, i) => new Tuple<
                      string, object
                      
                      >(
                      "idfsStatisticalAgeGroup", 
                        
                        i.StatisticalAgeGroupLookup.First(c => c.Key.Equals(i.idfsStatisticalAgeGroup)).ToStringProp
                          
                      )
                );
            
          
                  
                    }

                    if (bChangeValidation)
                    {
                
                        foreach(var item in obj.DAG2SAG.Where(c => true))
                        {
                        
                (new RequiredValidator( "idfsStatisticalAgeGroup", "idfsStatisticalAgeGroup","strStatisticalAgeGroup",
                false
              )).Validate(c => true, item, item.idfsStatisticalAgeGroup);
            
                        }
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.DAG2SAG != null)
                            foreach (var i in obj.DAG2SAG.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                DAG2SAGAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(DiagnosisAgeGroup2StatisticalAgeGroupMaster obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(DiagnosisAgeGroup2StatisticalAgeGroupMaster obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as DiagnosisAgeGroup2StatisticalAgeGroupMaster) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as DiagnosisAgeGroup2StatisticalAgeGroupMaster) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "DiagnosisAgeGroup2StatisticalAgeGroupMasterDetail"; } }
            public string HelpIdWin { get { return "Age_Groups-Statistical_Age_Groups_Matrix"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private DiagnosisAgeGroup2StatisticalAgeGroupMaster m_obj;
            internal Permissions(DiagnosisAgeGroup2StatisticalAgeGroupMaster obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spDiagnosisAgeGroupMaster_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spDummy_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spDiagnosisAgeGroup2StatisticalAgeGroupMaster_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroupMaster, bool>> RequiredByField = new Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroupMaster, bool>>();
            public static Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroupMaster, bool>> RequiredByProperty = new Dictionary<string, Func<DiagnosisAgeGroup2StatisticalAgeGroupMaster, bool>>();
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
                
                Actions.Add(new ActionMetaItem(
                    "DeleteStatisticalAgeGroup",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).DeleteStatisticalAgeGroup(manager, (DiagnosisAgeGroup2StatisticalAgeGroupMaster)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    ActionMetaItem.DefaultDeleteGroupItemVisiblePredicate,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<DiagnosisAgeGroup2StatisticalAgeGroupMaster>().Post(manager, (DiagnosisAgeGroup2StatisticalAgeGroupMaster)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<DiagnosisAgeGroup2StatisticalAgeGroupMaster>().Post(manager, (DiagnosisAgeGroup2StatisticalAgeGroupMaster)c), c),
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
	