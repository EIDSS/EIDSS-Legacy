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
    public abstract partial class CustomReportRowsMaster : 
        EditableObject<CustomReportRowsMaster>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsSummaryReportType), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsSummaryReportType { get; set; }
                
        [LocalizedDisplayName(_str_idfsDiagnosisOrReportDiagnosisGroup)]
        [MapField(_str_idfsDiagnosisOrReportDiagnosisGroup)]
        public abstract Int64 idfsDiagnosisOrReportDiagnosisGroup { get; set; }
        protected Int64 idfsDiagnosisOrReportDiagnosisGroup_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosisOrReportDiagnosisGroup).OriginalValue; } }
        protected Int64 idfsDiagnosisOrReportDiagnosisGroup_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosisOrReportDiagnosisGroup).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<CustomReportRowsMaster, object> _get_func;
            internal Action<CustomReportRowsMaster, string> _set_func;
            internal Action<CustomReportRowsMaster, CustomReportRowsMaster, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsSummaryReportType = "idfsSummaryReportType";
        internal const string _str_idfsDiagnosisOrReportDiagnosisGroup = "idfsDiagnosisOrReportDiagnosisGroup";
        internal const string _str_ID = "ID";
        internal const string _str_SummaryReportType = "SummaryReportType";
        internal const string _str_CustomReportRows = "CustomReportRows";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsSummaryReportType, _formname = _str_idfsSummaryReportType, _type = "Int64",
              _get_func = o => o.idfsSummaryReportType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsSummaryReportType != newval) 
                  o.SummaryReportType = o.SummaryReportTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsSummaryReportType != newval) o.idfsSummaryReportType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSummaryReportType != c.idfsSummaryReportType || o.IsRIRPropChanged(_str_idfsSummaryReportType, c)) 
                  m.Add(_str_idfsSummaryReportType, o.ObjectIdent + _str_idfsSummaryReportType, o.ObjectIdent2 + _str_idfsSummaryReportType, o.ObjectIdent3 + _str_idfsSummaryReportType, "Int64", 
                    o.idfsSummaryReportType == null ? "" : o.idfsSummaryReportType.ToString(),                  
                  o.IsReadOnly(_str_idfsSummaryReportType), o.IsInvisible(_str_idfsSummaryReportType), o.IsRequired(_str_idfsSummaryReportType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosisOrReportDiagnosisGroup, _formname = _str_idfsDiagnosisOrReportDiagnosisGroup, _type = "Int64",
              _get_func = o => o.idfsDiagnosisOrReportDiagnosisGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsDiagnosisOrReportDiagnosisGroup != newval) o.idfsDiagnosisOrReportDiagnosisGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosisOrReportDiagnosisGroup != c.idfsDiagnosisOrReportDiagnosisGroup || o.IsRIRPropChanged(_str_idfsDiagnosisOrReportDiagnosisGroup, c)) 
                  m.Add(_str_idfsDiagnosisOrReportDiagnosisGroup, o.ObjectIdent + _str_idfsDiagnosisOrReportDiagnosisGroup, o.ObjectIdent2 + _str_idfsDiagnosisOrReportDiagnosisGroup, o.ObjectIdent3 + _str_idfsDiagnosisOrReportDiagnosisGroup, "Int64", 
                    o.idfsDiagnosisOrReportDiagnosisGroup == null ? "" : o.idfsDiagnosisOrReportDiagnosisGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosisOrReportDiagnosisGroup), o.IsInvisible(_str_idfsDiagnosisOrReportDiagnosisGroup), o.IsRequired(_str_idfsDiagnosisOrReportDiagnosisGroup)); 
                  }
              }, 
        
            new field_info {
              _name = _str_ID, _formname = _str_ID, _type = "long",
              _get_func = o => o.ID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.ID != newval) o.ID = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.ID != c.ID || o.IsRIRPropChanged(_str_ID, c)) {
                  m.Add(_str_ID, o.ObjectIdent + _str_ID, o.ObjectIdent2 + _str_ID, o.ObjectIdent3 + _str_ID,  "long", 
                    o.ID == null ? "" : o.ID.ToString(),                  
                    o.IsReadOnly(_str_ID), o.IsInvisible(_str_ID), o.IsRequired(_str_ID));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_SummaryReportType, _formname = _str_SummaryReportType, _type = "Lookup",
              _get_func = o => { if (o.SummaryReportType == null) return null; return o.SummaryReportType.idfsBaseReference; },
              _set_func = (o, val) => { o.SummaryReportType = o.SummaryReportTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSummaryReportType != c.idfsSummaryReportType || o.IsRIRPropChanged(_str_SummaryReportType, c)) {
                  m.Add(_str_SummaryReportType, o.ObjectIdent + _str_SummaryReportType, o.ObjectIdent2 + _str_SummaryReportType, o.ObjectIdent3 + _str_SummaryReportType, "Lookup", o.idfsSummaryReportType == null ? "" : o.idfsSummaryReportType.ToString(), o.IsReadOnly(_str_SummaryReportType), o.IsInvisible(_str_SummaryReportType), o.IsRequired(_str_SummaryReportType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SummaryReportType + "Lookup", _formname = _str_SummaryReportType + "Lookup", _type = "LookupContent",
              _get_func = o => o.SummaryReportTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_CustomReportRows, _formname = _str_CustomReportRows, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.CustomReportRows.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.CustomReportRows.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.CustomReportRows.Count != c.CustomReportRows.Count || o.IsReadOnly(_str_CustomReportRows) != c.IsReadOnly(_str_CustomReportRows) || o.IsInvisible(_str_CustomReportRows) != c.IsInvisible(_str_CustomReportRows) || o.IsRequired(_str_CustomReportRows) != c._isRequired(o.m_isRequired, _str_CustomReportRows)) {
                  m.Add(_str_CustomReportRows, o.ObjectIdent + _str_CustomReportRows, o.ObjectIdent2 + _str_CustomReportRows, o.ObjectIdent3 + _str_CustomReportRows, "Child", o.ID == null ? "" : o.ID.ToString(), o.IsReadOnly(_str_CustomReportRows), o.IsInvisible(_str_CustomReportRows), o.IsRequired(_str_CustomReportRows)); 
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
            CustomReportRowsMaster obj = (CustomReportRowsMaster)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_CustomReportRows)]
        [Relation(typeof(CustomReportRow), "", _str_ID)]
        public EditableList<CustomReportRow> CustomReportRows
        {
            get 
            {   
                return _CustomReportRows; 
            }
            set 
            {
                _CustomReportRows = value;
            }
        }
        protected EditableList<CustomReportRow> _CustomReportRows = new EditableList<CustomReportRow>();
                    
        [LocalizedDisplayName(_str_SummaryReportType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSummaryReportType)]
        public BaseReference SummaryReportType
        {
            get { return _SummaryReportType == null ? null : ((long)_SummaryReportType.Key == 0 ? null : _SummaryReportType); }
            set 
            { 
                var oldVal = _SummaryReportType;
                _SummaryReportType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SummaryReportType != oldVal)
                {
                    if (idfsSummaryReportType != (_SummaryReportType == null
                            ? new Int64()
                            : (Int64)_SummaryReportType.idfsBaseReference))
                        idfsSummaryReportType = _SummaryReportType == null 
                            ? new Int64()
                            : (Int64)_SummaryReportType.idfsBaseReference; 
                    OnPropertyChanged(_str_SummaryReportType); 
                }
            }
        }
        private BaseReference _SummaryReportType;

        
        public BaseReferenceList SummaryReportTypeLookup
        {
            get { return _SummaryReportTypeLookup; }
        }
        private BaseReferenceList _SummaryReportTypeLookup = new BaseReferenceList("rftSummaryReportType");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_SummaryReportType:
                    return new BvSelectList(SummaryReportTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SummaryReportType, _str_idfsSummaryReportType);
            
                case _str_CustomReportRows:
                    return new BvSelectList(CustomReportRows, "", "", null, "");
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str_ID)]
        public long ID
        {
            get { return m_ID; }
            set { if (m_ID != value) { m_ID = value; OnPropertyChanged(_str_ID); } }
        }
        private long m_ID;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "CustomReportRowsMaster";

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
        CustomReportRows.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as CustomReportRowsMaster;
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
            var ret = base.Clone() as CustomReportRowsMaster;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_CustomReportRows != null && _CustomReportRows.Count > 0)
            {
              ret.CustomReportRows.Clear();
              _CustomReportRows.ForEach(c => ret.CustomReportRows.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public CustomReportRowsMaster CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as CustomReportRowsMaster;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsSummaryReportType; } }
        public string KeyName { get { return "idfsSummaryReportType"; } }
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
        
                    || CustomReportRows.IsDirty
                    || CustomReportRows.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsSummaryReportType_SummaryReportType = idfsSummaryReportType;
            base.RejectChanges();
        
            if (_prev_idfsSummaryReportType_SummaryReportType != idfsSummaryReportType)
            {
                _SummaryReportType = _SummaryReportTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSummaryReportType);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        CustomReportRows.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        CustomReportRows.DeepAcceptChanges();
                
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
        CustomReportRows.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, CustomReportRowsMaster c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public CustomReportRowsMaster()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(CustomReportRowsMaster_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(CustomReportRowsMaster_PropertyChanged);
        }
        private void CustomReportRowsMaster_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as CustomReportRowsMaster).Changed(e.PropertyName);
            
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
            CustomReportRowsMaster obj = this;
            
        }
        private void _DeletedExtenders()
        {
            CustomReportRowsMaster obj = this;
            
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
        
                foreach(var o in _CustomReportRows)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<CustomReportRowsMaster, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<CustomReportRowsMaster, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<CustomReportRowsMaster, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<CustomReportRowsMaster, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<CustomReportRowsMaster, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<CustomReportRowsMaster, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<CustomReportRowsMaster, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~CustomReportRowsMaster()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                CustomReportRows.ForEach(c => c.Dispose());
                
                LookupManager.RemoveObject("rftSummaryReportType", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftSummaryReportType")
                _getAccessor().LoadLookup_SummaryReportType(manager, this);
            
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
        
            if (_CustomReportRows != null) _CustomReportRows.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<CustomReportRowsMaster>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<CustomReportRowsMaster>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<CustomReportRowsMaster>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsSummaryReportType"; } }
            #endregion
        
            private delegate void on_action(CustomReportRowsMaster obj);
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
            private CustomReportRow.Accessor CustomReportRowsAccessor { get { return eidss.model.Schema.CustomReportRow.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SummaryReportTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            

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
            public virtual CustomReportRowsMaster SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
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

            
            public virtual CustomReportRowsMaster SelectByKey(DbManagerProxy manager
                )
            {
                return _SelectByKey(manager
                    , null, null
                    );
            }
            
      
            private CustomReportRowsMaster _SelectByKey(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<CustomReportRowsMaster> objs = new List<CustomReportRowsMaster>();
                sets[0] = new MapResultSet(typeof(CustomReportRowsMaster), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spCustomReportRowsMaster_SelectDetail"
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    CustomReportRowsMaster obj = objs[0];
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
    
            private void _SetupAddChildHandlerCustomReportRows(CustomReportRowsMaster obj)
            {
                obj.CustomReportRows.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadCustomReportRows(CustomReportRowsMaster obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadCustomReportRows(manager, obj);
                }
            }
            internal void _LoadCustomReportRows(DbManagerProxy manager, CustomReportRowsMaster obj)
            {
                
                obj.CustomReportRows.Clear();
                obj.CustomReportRows.AddRange(CustomReportRowsAccessor.SelectDetailList(manager
                    
                    , obj.ID
                    ));
                obj.CustomReportRows.ForEach(c => c.m_ObjectName = _str_CustomReportRows);
                obj.CustomReportRows.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, CustomReportRowsMaster obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadCustomReportRows(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerCustomReportRows(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, CustomReportRowsMaster obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.CustomReportRows.ForEach(c => CustomReportRowsAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private CustomReportRowsMaster _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    CustomReportRowsMaster obj = CustomReportRowsMaster.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
              obj.m_IsNew = false;
              var accMaster = CustomReportRowsMaster.Accessor.Instance(null);
              accMaster._LoadCustomReportRows(manager, obj);
            
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerCustomReportRows(obj);
                    
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

            
            public CustomReportRowsMaster CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public CustomReportRowsMaster CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public CustomReportRowsMaster CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult DeleteItem(DbManagerProxy manager, CustomReportRowsMaster obj, List<object> pars)
            {
                
                return DeleteItem(manager, obj
                    );
            }
            public ActResult DeleteItem(DbManagerProxy manager, CustomReportRowsMaster obj
                )
            {
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(CustomReportRowsMaster obj, object newobj)
            {
                
                foreach(var o in obj.CustomReportRows.Where(c => true))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "intRowOrder")
                                {
                                obj.RecalculateRowNumber(item);
                                }
                            };
                        }    
                        
                    }
                }
                            
            }
            
            private void _SetupHandlers(CustomReportRowsMaster obj)
            {
                
            }
    
            public void LoadLookup_SummaryReportType(DbManagerProxy manager, CustomReportRowsMaster obj)
            {
                
                obj.SummaryReportTypeLookup.Clear();
                
                obj.SummaryReportTypeLookup.Add(SummaryReportTypeAccessor.CreateNewT(manager, null));
                
                obj.SummaryReportTypeLookup.AddRange(SummaryReportTypeAccessor.rftSummaryReportType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSummaryReportType))
                    
                    .ToList());
                
                if (obj.idfsSummaryReportType != 0)
                {
                    obj.SummaryReportType = obj.SummaryReportTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsSummaryReportType);
                    
                }
              
                
                LookupManager.AddObject("rftSummaryReportType", obj, SummaryReportTypeAccessor.GetType(), "rftSummaryReportType_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, CustomReportRowsMaster obj)
            {
                
                LoadLookup_SummaryReportType(manager, obj);
                
            }
    
            [SprocName("spCustomReportRowsMaster_Delete")]
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
                [Direction.InputOutput()] CustomReportRowsMaster obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] CustomReportRowsMaster obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    CustomReportRowsMaster bo = obj as CustomReportRowsMaster;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as CustomReportRowsMaster, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, CustomReportRowsMaster obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.CustomReportRows != null)
                    {
                        foreach (var i in obj.CustomReportRows)
                        {
                            i.MarkToDelete();
                            if (!CustomReportRowsAccessor.Post(manager, i, true))
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
                        if (obj.CustomReportRows != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.CustomReportRows)
                                if (!CustomReportRowsAccessor.Post(manager, i, true))
                                    return false;
                            obj.CustomReportRows.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.CustomReportRows.Remove(c));
                            obj.CustomReportRows.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._CustomReportRows != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._CustomReportRows)
                                if (!CustomReportRowsAccessor.Post(manager, i, true))
                                    return false;
                            obj._CustomReportRows.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._CustomReportRows.Remove(c));
                            obj._CustomReportRows.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(CustomReportRowsMaster obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, CustomReportRowsMaster obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(CustomReportRowsMaster obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(CustomReportRowsMaster obj, bool bRethrowException)
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
                return Validate(manager, obj as CustomReportRowsMaster, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, CustomReportRowsMaster obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(CustomReportRowsMaster obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(CustomReportRowsMaster obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as CustomReportRowsMaster) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as CustomReportRowsMaster) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "CustomReportRowsMasterDetail"; } }
            public string HelpIdWin { get { return "EIDSS_Configuration"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spCustomReportRowsMaster_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spDummy_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spCustomReportRowsMaster_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<CustomReportRowsMaster, bool>> RequiredByField = new Dictionary<string, Func<CustomReportRowsMaster, bool>>();
            public static Dictionary<string, Func<CustomReportRowsMaster, bool>> RequiredByProperty = new Dictionary<string, Func<CustomReportRowsMaster, bool>>();
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
                    "DeleteItem",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).DeleteItem(manager, (CustomReportRowsMaster)c, pars),
                        
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<CustomReportRowsMaster>().Post(manager, (CustomReportRowsMaster)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<CustomReportRowsMaster>().Post(manager, (CustomReportRowsMaster)c), c),
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
	