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
    public abstract partial class VsSessionSummaryDiagnosis : 
        EditableObject<VsSessionSummaryDiagnosis>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsVSSessionSummaryDiagnosis), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsVSSessionSummaryDiagnosis { get; set; }
                
        [LocalizedDisplayName(_str_idfsVSSessionSummary)]
        [MapField(_str_idfsVSSessionSummary)]
        public abstract Int64 idfsVSSessionSummary { get; set; }
        protected Int64 idfsVSSessionSummary_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVSSessionSummary).OriginalValue; } }
        protected Int64 idfsVSSessionSummary_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVSSessionSummary).PreviousValue; } }
                
        [LocalizedDisplayName("FT.strDisease")]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64 idfsDiagnosis { get; set; }
        protected Int64 idfsDiagnosis_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64 idfsDiagnosis_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName("FT.strDisease")]
        [MapField(_str_strDiagnosis)]
        public abstract String strDiagnosis { get; set; }
        protected String strDiagnosis_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosis).OriginalValue; } }
        protected String strDiagnosis_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intPositiveQuantity)]
        [MapField(_str_intPositiveQuantity)]
        public abstract Int32? intPositiveQuantity { get; set; }
        protected Int32? intPositiveQuantity_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intPositiveQuantity).OriginalValue; } }
        protected Int32? intPositiveQuantity_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intPositiveQuantity).PreviousValue; } }
                
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
            internal Func<VsSessionSummaryDiagnosis, object> _get_func;
            internal Action<VsSessionSummaryDiagnosis, string> _set_func;
            internal Action<VsSessionSummaryDiagnosis, VsSessionSummaryDiagnosis, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsVSSessionSummaryDiagnosis = "idfsVSSessionSummaryDiagnosis";
        internal const string _str_idfsVSSessionSummary = "idfsVSSessionSummary";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_strDiagnosis = "strDiagnosis";
        internal const string _str_intPositiveQuantity = "intPositiveQuantity";
        internal const string _str_intRowStatus = "intRowStatus";
        internal const string _str_SessionSummary = "SessionSummary";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_Diagnoses = "Diagnoses";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsVSSessionSummaryDiagnosis, _formname = _str_idfsVSSessionSummaryDiagnosis, _type = "Int64",
              _get_func = o => o.idfsVSSessionSummaryDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsVSSessionSummaryDiagnosis != newval) o.idfsVSSessionSummaryDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsVSSessionSummaryDiagnosis != c.idfsVSSessionSummaryDiagnosis || o.IsRIRPropChanged(_str_idfsVSSessionSummaryDiagnosis, c)) 
                  m.Add(_str_idfsVSSessionSummaryDiagnosis, o.ObjectIdent + _str_idfsVSSessionSummaryDiagnosis, o.ObjectIdent2 + _str_idfsVSSessionSummaryDiagnosis, o.ObjectIdent3 + _str_idfsVSSessionSummaryDiagnosis, "Int64", 
                    o.idfsVSSessionSummaryDiagnosis == null ? "" : o.idfsVSSessionSummaryDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsVSSessionSummaryDiagnosis), o.IsInvisible(_str_idfsVSSessionSummaryDiagnosis), o.IsRequired(_str_idfsVSSessionSummaryDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsVSSessionSummary, _formname = _str_idfsVSSessionSummary, _type = "Int64",
              _get_func = o => o.idfsVSSessionSummary,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsVSSessionSummary != newval) o.idfsVSSessionSummary = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsVSSessionSummary != c.idfsVSSessionSummary || o.IsRIRPropChanged(_str_idfsVSSessionSummary, c)) 
                  m.Add(_str_idfsVSSessionSummary, o.ObjectIdent + _str_idfsVSSessionSummary, o.ObjectIdent2 + _str_idfsVSSessionSummary, o.ObjectIdent3 + _str_idfsVSSessionSummary, "Int64", 
                    o.idfsVSSessionSummary == null ? "" : o.idfsVSSessionSummary.ToString(),                  
                  o.IsReadOnly(_str_idfsVSSessionSummary), o.IsInvisible(_str_idfsVSSessionSummary), o.IsRequired(_str_idfsVSSessionSummary)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "Int64",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsDiagnosis != newval) 
                  o.Diagnoses = o.DiagnosesLookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis, "Int64", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDiagnosis, _formname = _str_strDiagnosis, _type = "String",
              _get_func = o => o.strDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDiagnosis != newval) o.strDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDiagnosis != c.strDiagnosis || o.IsRIRPropChanged(_str_strDiagnosis, c)) 
                  m.Add(_str_strDiagnosis, o.ObjectIdent + _str_strDiagnosis, o.ObjectIdent2 + _str_strDiagnosis, o.ObjectIdent3 + _str_strDiagnosis, "String", 
                    o.strDiagnosis == null ? "" : o.strDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_strDiagnosis), o.IsInvisible(_str_strDiagnosis), o.IsRequired(_str_strDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intPositiveQuantity, _formname = _str_intPositiveQuantity, _type = "Int32?",
              _get_func = o => o.intPositiveQuantity,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intPositiveQuantity != newval) o.intPositiveQuantity = newval; },
              _compare_func = (o, c, m) => {
                if (o.intPositiveQuantity != c.intPositiveQuantity || o.IsRIRPropChanged(_str_intPositiveQuantity, c)) 
                  m.Add(_str_intPositiveQuantity, o.ObjectIdent + _str_intPositiveQuantity, o.ObjectIdent2 + _str_intPositiveQuantity, o.ObjectIdent3 + _str_intPositiveQuantity, "Int32?", 
                    o.intPositiveQuantity == null ? "" : o.intPositiveQuantity.ToString(),                  
                  o.IsReadOnly(_str_intPositiveQuantity), o.IsInvisible(_str_intPositiveQuantity), o.IsRequired(_str_intPositiveQuantity)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intRowStatus, _formname = _str_intRowStatus, _type = "Int32",
              _get_func = o => o.intRowStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intRowStatus != newval) o.intRowStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.intRowStatus != c.intRowStatus || o.IsRIRPropChanged(_str_intRowStatus, c)) 
                  m.Add(_str_intRowStatus, o.ObjectIdent + _str_intRowStatus, o.ObjectIdent2 + _str_intRowStatus, o.ObjectIdent3 + _str_intRowStatus, "Int32", 
                    o.intRowStatus == null ? "" : o.intRowStatus.ToString(),                  
                  o.IsReadOnly(_str_intRowStatus), o.IsInvisible(_str_intRowStatus), o.IsRequired(_str_intRowStatus)); 
                  }
              }, 
        
            new field_info {
              _name = _str_SessionSummary, _formname = _str_SessionSummary, _type = "VsSessionSummary",
              _get_func = o => o.SessionSummary,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_CaseObjectIdent, _formname = _str_CaseObjectIdent, _type = "string",
              _get_func = o => o.CaseObjectIdent,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.CaseObjectIdent != c.CaseObjectIdent || o.IsRIRPropChanged(_str_CaseObjectIdent, c)) {
                  m.Add(_str_CaseObjectIdent, o.ObjectIdent + _str_CaseObjectIdent, o.ObjectIdent2 + _str_CaseObjectIdent, o.ObjectIdent3 + _str_CaseObjectIdent, "string", o.CaseObjectIdent == null ? "" : o.CaseObjectIdent.ToString(), o.IsReadOnly(_str_CaseObjectIdent), o.IsInvisible(_str_CaseObjectIdent), o.IsRequired(_str_CaseObjectIdent));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Diagnoses, _formname = _str_Diagnoses, _type = "Lookup",
              _get_func = o => { if (o.Diagnoses == null) return null; return o.Diagnoses.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnoses = o.DiagnosesLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnoses, c)) {
                  m.Add(_str_Diagnoses, o.ObjectIdent + _str_Diagnoses, o.ObjectIdent2 + _str_Diagnoses, o.ObjectIdent3 + _str_Diagnoses, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnoses), o.IsInvisible(_str_Diagnoses), o.IsRequired(_str_Diagnoses)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Diagnoses + "Lookup", _formname = _str_Diagnoses + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosesLookup,
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
            VsSessionSummaryDiagnosis obj = (VsSessionSummaryDiagnosis)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Diagnoses)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnoses
        {
            get { return _Diagnoses == null ? null : ((long)_Diagnoses.Key == 0 ? null : _Diagnoses); }
            set 
            { 
                var oldVal = _Diagnoses;
                _Diagnoses = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Diagnoses != oldVal)
                {
                    if (idfsDiagnosis != (_Diagnoses == null
                            ? new Int64()
                            : (Int64)_Diagnoses.idfsDiagnosis))
                        idfsDiagnosis = _Diagnoses == null 
                            ? new Int64()
                            : (Int64)_Diagnoses.idfsDiagnosis; 
                    OnPropertyChanged(_str_Diagnoses); 
                }
            }
        }
        private DiagnosisLookup _Diagnoses;

        
        public List<DiagnosisLookup> DiagnosesLookup
        {
            get { return _DiagnosesLookup; }
        }
        private List<DiagnosisLookup> _DiagnosesLookup = new List<DiagnosisLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnoses:
                    return new BvSelectList(DiagnosesLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnoses, _str_idfsDiagnosis);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_SessionSummary)]
        public VsSessionSummary SessionSummary
        {
            get { return new Func<VsSessionSummaryDiagnosis, VsSessionSummary>(c => Parent as VsSessionSummary)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<VsSessionSummaryDiagnosis, string>(c => "Summaries_" + c.idfsVSSessionSummary + "_")(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "VsSessionSummaryDiagnosis";

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
            var ret = base.Clone() as VsSessionSummaryDiagnosis;
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
            var ret = base.Clone() as VsSessionSummaryDiagnosis;
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
        public VsSessionSummaryDiagnosis CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VsSessionSummaryDiagnosis;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsVSSessionSummaryDiagnosis; } }
        public string KeyName { get { return "idfsVSSessionSummaryDiagnosis"; } }
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
        
            var _prev_idfsDiagnosis_Diagnoses = idfsDiagnosis;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosis_Diagnoses != idfsDiagnosis)
            {
                _Diagnoses = _DiagnosesLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
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

        private bool IsRIRPropChanged(string fld, VsSessionSummaryDiagnosis c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public VsSessionSummaryDiagnosis()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VsSessionSummaryDiagnosis_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VsSessionSummaryDiagnosis_PropertyChanged);
        }
        private void VsSessionSummaryDiagnosis_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VsSessionSummaryDiagnosis).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_SessionSummary);
                  
            if (e.PropertyName == _str_idfsVSSessionSummary)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
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
            VsSessionSummaryDiagnosis obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VsSessionSummaryDiagnosis obj = this;
            
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


        internal Dictionary<string, Func<VsSessionSummaryDiagnosis, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VsSessionSummaryDiagnosis, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VsSessionSummaryDiagnosis, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VsSessionSummaryDiagnosis, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VsSessionSummaryDiagnosis, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<VsSessionSummaryDiagnosis, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<VsSessionSummaryDiagnosis, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~VsSessionSummaryDiagnosis()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnoses(manager, this);
            
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
        public class VsSessionSummaryDiagnosisGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfsVSSessionSummaryDiagnosis { get; set; }
        
            public Int64 idfsDiagnosis { get; set; }
        
            public String strDiagnosis { get; set; }
        
            public Int32? intPositiveQuantity { get; set; }
        
        }
        public partial class VsSessionSummaryDiagnosisGridModelList : List<VsSessionSummaryDiagnosisGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public VsSessionSummaryDiagnosisGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VsSessionSummaryDiagnosis>, errMes);
            }
            public VsSessionSummaryDiagnosisGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VsSessionSummaryDiagnosis>, errMes);
            }
            public VsSessionSummaryDiagnosisGridModelList(long key, IEnumerable<VsSessionSummaryDiagnosis> items)
            {
                LoadGridModelList(key, items, null);
            }
            public VsSessionSummaryDiagnosisGridModelList(long key)
            {
                LoadGridModelList(key, new List<VsSessionSummaryDiagnosis>(), null);
            }
            partial void filter(List<VsSessionSummaryDiagnosis> items);
            private void LoadGridModelList(long key, IEnumerable<VsSessionSummaryDiagnosis> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_idfsDiagnosis,_str_strDiagnosis,_str_intPositiveQuantity};
                    
                Hiddens = new List<string> {_str_idfsVSSessionSummaryDiagnosis};
                Keys = new List<string> {_str_idfsVSSessionSummaryDiagnosis};
                Labels = new Dictionary<string, string> {{_str_idfsDiagnosis, "FT.strDisease"},{_str_strDiagnosis, "FT.strDisease"},{_str_intPositiveQuantity, _str_intPositiveQuantity}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                VsSessionSummaryDiagnosis.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<VsSessionSummaryDiagnosis>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VsSessionSummaryDiagnosisGridModel()
                {
                    ItemKey=c.idfsVSSessionSummaryDiagnosis,idfsDiagnosis=c.idfsDiagnosis,strDiagnosis=c.strDiagnosis,intPositiveQuantity=c.intPositiveQuantity
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
        : DataAccessor<VsSessionSummaryDiagnosis>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<VsSessionSummaryDiagnosis>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsVSSessionSummaryDiagnosis"; } }
            #endregion
        
            private delegate void on_action(VsSessionSummaryDiagnosis obj);
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
            private DiagnosisLookup.Accessor DiagnosesAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<VsSessionSummaryDiagnosis> SelectList(DbManagerProxy manager
                , Int64? idfsVSSessionSummary
                )
            {
                return _SelectList(manager
                    , idfsVSSessionSummary
                    , delegate(VsSessionSummaryDiagnosis obj)
                        {
                        }
                    , delegate(VsSessionSummaryDiagnosis obj)
                        {
                        }
                    );
            }

            
            private List<VsSessionSummaryDiagnosis> _SelectList(DbManagerProxy manager
                , Int64? idfsVSSessionSummary
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VsSessionSummaryDiagnosis> objs = new List<VsSessionSummaryDiagnosis>();
                    sets[0] = new MapResultSet(typeof(VsSessionSummaryDiagnosis), objs);
                    
                    manager
                        .SetSpCommand("spVsSessionSummaryDiagnosis_SelectDetail"
                            , manager.Parameter("@idfsVSSessionSummary", idfsVSSessionSummary)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, VsSessionSummaryDiagnosis obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, VsSessionSummaryDiagnosis obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private VsSessionSummaryDiagnosis _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    VsSessionSummaryDiagnosis obj = VsSessionSummaryDiagnosis.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfsVSSessionSummaryDiagnosis = (new GetNewIDExtender<VsSessionSummaryDiagnosis>()).GetScalar(manager, obj, isFake);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.idfsVSSessionSummary = new Func<VsSessionSummaryDiagnosis, long>(c => c.SessionSummary != null ? c.SessionSummary.idfsVSSessionSummary : c.idfsVSSessionSummary)(obj);
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

            
            public VsSessionSummaryDiagnosis CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public VsSessionSummaryDiagnosis CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public VsSessionSummaryDiagnosis CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public VsSessionSummaryDiagnosis CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                return Create(manager, Parent
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public VsSessionSummaryDiagnosis Create(DbManagerProxy manager, IObject Parent
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(VsSessionSummaryDiagnosis obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VsSessionSummaryDiagnosis obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_intPositiveQuantity)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intPositiveQuantity);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                obj.Diagnoses = new Func<VsSessionSummaryDiagnosis, DiagnosisLookup>(c => c.DiagnosesLookup.Where(x => x.idfsDiagnosis == c.idfsDiagnosis).FirstOrDefault())(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                obj.strDiagnosis = new Func<VsSessionSummaryDiagnosis, string>(c => c.DiagnosesLookup != null ? c.DiagnosesLookup.FirstOrDefault(d => d.idfsDiagnosis == c.idfsDiagnosis).name : String.Empty)(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Diagnoses(DbManagerProxy manager, VsSessionSummaryDiagnosis obj)
            {
                
                obj.DiagnosesLookup.Clear();
                
                obj.DiagnosesLookup.Add(DiagnosesAccessor.CreateNewT(manager, null));
                
                obj.DiagnosesLookup.AddRange(DiagnosesAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.Vector) != 0) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != 0)
                {
                    obj.Diagnoses = obj.DiagnosesLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosis);
                    
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosesAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, VsSessionSummaryDiagnosis obj)
            {
                
                LoadLookup_Diagnoses(manager, obj);
                
            }
    
            [SprocName("spVsSessionSummaryDiagnosis_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            [SprocName("spVsSessionSummaryDiagnosis_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfsVSSessionSummaryDiagnosis")] VsSessionSummaryDiagnosis obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfsVSSessionSummaryDiagnosis")] VsSessionSummaryDiagnosis obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    VsSessionSummaryDiagnosis bo = obj as VsSessionSummaryDiagnosis;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("VsSessionSummary", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("VsSessionSummary", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("VsSessionSummary", "Update");
                    }
                    
                    long mainObject = bo.idfsVSSessionSummaryDiagnosis;
                    
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoVectorSurveillanceSession;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbVectorSurveillanceSessionSummaryDiagnosis;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as VsSessionSummaryDiagnosis, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VsSessionSummaryDiagnosis obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(VsSessionSummaryDiagnosis obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, VsSessionSummaryDiagnosis obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(VsSessionSummaryDiagnosis obj)
            {
                
                try
                {
                  
    new ChainsValidatorNullableInt<VsSessionSummaryDiagnosis>(obj, "MinValue", c => true, 
      1,
      null,
      false, listMinValue => {
    listMinValue.Add(
    new ChainsValidatorNullableInt<VsSessionSummaryDiagnosis>(obj, "intPositiveQuantity", c => true, 
      obj.intPositiveQuantity,
      obj.GetType(),
      false, listintPositiveQuantity => {
    
    }));
  
    }).Process();
  
                }
                catch(ValidationModelException ex)
                {
                    return ex;
                }
                
                return null;
            }
            protected bool ChainsValidate(VsSessionSummaryDiagnosis obj, bool bRethrowException)
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
                return Validate(manager, obj as VsSessionSummaryDiagnosis, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VsSessionSummaryDiagnosis obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsVSSessionSummaryDiagnosis", "idfsVSSessionSummaryDiagnosis","",
                false
              )).Validate(c => true, obj, obj.idfsVSSessionSummaryDiagnosis);
            
                (new RequiredValidator( "idfsVSSessionSummary", "idfsVSSessionSummary","",
                false
              )).Validate(c => true, obj, obj.idfsVSSessionSummary);
            
                (new RequiredValidator( "idfsDiagnosis", "idfsDiagnosis","FT.strDisease",
                false
              )).Validate(c => true, obj, obj.idfsDiagnosis);
            
                (new PredicateValidator("intQuantity_intPositiveQuantity_msgId", "intPositiveQuantity", "intPositiveQuantity", "intPositiveQuantity",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.SessionSummary.intQuantity > 0 ? c.SessionSummary.intQuantity >= c.intPositiveQuantity : true
                    );
            
                CustomValidations(obj);
            
                  
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
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(VsSessionSummaryDiagnosis obj)
            {
            
                obj
                    .AddRequired("idfsVSSessionSummaryDiagnosis", c => true);
                    
                obj
                    .AddRequired("idfsVSSessionSummary", c => true);
                    
                obj
                    .AddRequired("idfsDiagnosis", c => true);
                    
                  obj
                    .AddRequired("Diagnoses", c => true);
                
            }
    
    private void _SetupPersonalDataRestrictions(VsSessionSummaryDiagnosis obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VsSessionSummaryDiagnosis) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VsSessionSummaryDiagnosis) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VsSessionSummaryDiagnosisDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private VsSessionSummaryDiagnosis m_obj;
            internal Permissions(VsSessionSummaryDiagnosis obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spVsSessionSummaryDiagnosis_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spVsSessionSummaryDiagnosis_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spVsSessionSummaryDiagnosis_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VsSessionSummaryDiagnosis, bool>> RequiredByField = new Dictionary<string, Func<VsSessionSummaryDiagnosis, bool>>();
            public static Dictionary<string, Func<VsSessionSummaryDiagnosis, bool>> RequiredByProperty = new Dictionary<string, Func<VsSessionSummaryDiagnosis, bool>>();
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
                
                Sizes.Add(_str_strDiagnosis, 2000);
                if (!RequiredByField.ContainsKey("idfsVSSessionSummaryDiagnosis")) RequiredByField.Add("idfsVSSessionSummaryDiagnosis", c => true);
                if (!RequiredByProperty.ContainsKey("idfsVSSessionSummaryDiagnosis")) RequiredByProperty.Add("idfsVSSessionSummaryDiagnosis", c => true);
                
                if (!RequiredByField.ContainsKey("idfsVSSessionSummary")) RequiredByField.Add("idfsVSSessionSummary", c => true);
                if (!RequiredByProperty.ContainsKey("idfsVSSessionSummary")) RequiredByProperty.Add("idfsVSSessionSummary", c => true);
                
                if (!RequiredByField.ContainsKey("idfsDiagnosis")) RequiredByField.Add("idfsDiagnosis", c => true);
                if (!RequiredByProperty.ContainsKey("idfsDiagnosis")) RequiredByProperty.Add("idfsDiagnosis", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfsVSSessionSummaryDiagnosis,
                    _str_idfsVSSessionSummaryDiagnosis, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsDiagnosis,
                    "FT.strDisease", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnosis,
                    "FT.strDisease", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intPositiveQuantity,
                    _str_intPositiveQuantity, null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).Create(manager, c, pars)),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Group,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c, a, b, p) => false,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Edit",
                    ActionTypes.Edit,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Group,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c, a, b, p) => false,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => ((VsSessionSummaryDiagnosis)c).MarkToDelete(),
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
	