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
    public abstract partial class CaseClassification : 
        EditableObject<CaseClassification>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsCaseClassification), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsCaseClassification { get; set; }
                
        [LocalizedDisplayName("strCaseClassificationDefaultName")]
        [MapField(_str_CaseClassificationName)]
        public abstract String CaseClassificationName { get; set; }
        protected String CaseClassificationName_Original { get { return ((EditableValue<String>)((dynamic)this)._caseClassificationName).OriginalValue; } }
        protected String CaseClassificationName_Previous { get { return ((EditableValue<String>)((dynamic)this)._caseClassificationName).PreviousValue; } }
                
        [LocalizedDisplayName("strCaseClassificationTranslatedName")]
        [MapField(_str_CaseClassificationNameTranslated)]
        public abstract String CaseClassificationNameTranslated { get; set; }
        protected String CaseClassificationNameTranslated_Original { get { return ((EditableValue<String>)((dynamic)this)._caseClassificationNameTranslated).OriginalValue; } }
        protected String CaseClassificationNameTranslated_Previous { get { return ((EditableValue<String>)((dynamic)this)._caseClassificationNameTranslated).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32 intOrder { get; set; }
        protected Int32 intOrder_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32 intOrder_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnInitialHumanCaseClassification)]
        [MapField(_str_blnInitialHumanCaseClassification)]
        public abstract Boolean blnInitialHumanCaseClassification { get; set; }
        protected Boolean blnInitialHumanCaseClassification_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnInitialHumanCaseClassification).OriginalValue; } }
        protected Boolean blnInitialHumanCaseClassification_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnInitialHumanCaseClassification).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnFinalHumanCaseClassification)]
        [MapField(_str_blnFinalHumanCaseClassification)]
        public abstract Boolean blnFinalHumanCaseClassification { get; set; }
        protected Boolean blnFinalHumanCaseClassification_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnFinalHumanCaseClassification).OriginalValue; } }
        protected Boolean blnFinalHumanCaseClassification_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnFinalHumanCaseClassification).PreviousValue; } }
                
        [LocalizedDisplayName("strHACode")]
        [MapField(_str_intHACode)]
        public abstract Int32? intHACode { get; set; }
        protected Int32? intHACode_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32? intHACode_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHACode)]
        [MapField(_str_strHACode)]
        public abstract String strHACode { get; set; }
        protected String strHACode_Original { get { return ((EditableValue<String>)((dynamic)this)._strHACode).OriginalValue; } }
        protected String strHACode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHACode).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<CaseClassification, object> _get_func;
            internal Action<CaseClassification, string> _set_func;
            internal Action<CaseClassification, CaseClassification, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsCaseClassification = "idfsCaseClassification";
        internal const string _str_CaseClassificationName = "CaseClassificationName";
        internal const string _str_CaseClassificationNameTranslated = "CaseClassificationNameTranslated";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_blnInitialHumanCaseClassification = "blnInitialHumanCaseClassification";
        internal const string _str_blnFinalHumanCaseClassification = "blnFinalHumanCaseClassification";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_strHACode = "strHACode";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsCaseClassification, _formname = _str_idfsCaseClassification, _type = "Int64",
              _get_func = o => o.idfsCaseClassification,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsCaseClassification != newval) o.idfsCaseClassification = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseClassification != c.idfsCaseClassification || o.IsRIRPropChanged(_str_idfsCaseClassification, c)) 
                  m.Add(_str_idfsCaseClassification, o.ObjectIdent + _str_idfsCaseClassification, o.ObjectIdent2 + _str_idfsCaseClassification, o.ObjectIdent3 + _str_idfsCaseClassification, "Int64", 
                    o.idfsCaseClassification == null ? "" : o.idfsCaseClassification.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseClassification), o.IsInvisible(_str_idfsCaseClassification), o.IsRequired(_str_idfsCaseClassification)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_CaseClassificationName, _formname = _str_CaseClassificationName, _type = "String",
              _get_func = o => o.CaseClassificationName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.CaseClassificationName != newval) o.CaseClassificationName = newval; },
              _compare_func = (o, c, m) => {
                if (o.CaseClassificationName != c.CaseClassificationName || o.IsRIRPropChanged(_str_CaseClassificationName, c)) 
                  m.Add(_str_CaseClassificationName, o.ObjectIdent + _str_CaseClassificationName, o.ObjectIdent2 + _str_CaseClassificationName, o.ObjectIdent3 + _str_CaseClassificationName, "String", 
                    o.CaseClassificationName == null ? "" : o.CaseClassificationName.ToString(),                  
                  o.IsReadOnly(_str_CaseClassificationName), o.IsInvisible(_str_CaseClassificationName), o.IsRequired(_str_CaseClassificationName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_CaseClassificationNameTranslated, _formname = _str_CaseClassificationNameTranslated, _type = "String",
              _get_func = o => o.CaseClassificationNameTranslated,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.CaseClassificationNameTranslated != newval) o.CaseClassificationNameTranslated = newval; },
              _compare_func = (o, c, m) => {
                if (o.CaseClassificationNameTranslated != c.CaseClassificationNameTranslated || o.IsRIRPropChanged(_str_CaseClassificationNameTranslated, c)) 
                  m.Add(_str_CaseClassificationNameTranslated, o.ObjectIdent + _str_CaseClassificationNameTranslated, o.ObjectIdent2 + _str_CaseClassificationNameTranslated, o.ObjectIdent3 + _str_CaseClassificationNameTranslated, "String", 
                    o.CaseClassificationNameTranslated == null ? "" : o.CaseClassificationNameTranslated.ToString(),                  
                  o.IsReadOnly(_str_CaseClassificationNameTranslated), o.IsInvisible(_str_CaseClassificationNameTranslated), o.IsRequired(_str_CaseClassificationNameTranslated)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intOrder, _formname = _str_intOrder, _type = "Int32",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intOrder != newval) o.intOrder = newval; },
              _compare_func = (o, c, m) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, o.ObjectIdent2 + _str_intOrder, o.ObjectIdent3 + _str_intOrder, "Int32", 
                    o.intOrder == null ? "" : o.intOrder.ToString(),                  
                  o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnInitialHumanCaseClassification, _formname = _str_blnInitialHumanCaseClassification, _type = "Boolean",
              _get_func = o => o.blnInitialHumanCaseClassification,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnInitialHumanCaseClassification != newval) o.blnInitialHumanCaseClassification = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnInitialHumanCaseClassification != c.blnInitialHumanCaseClassification || o.IsRIRPropChanged(_str_blnInitialHumanCaseClassification, c)) 
                  m.Add(_str_blnInitialHumanCaseClassification, o.ObjectIdent + _str_blnInitialHumanCaseClassification, o.ObjectIdent2 + _str_blnInitialHumanCaseClassification, o.ObjectIdent3 + _str_blnInitialHumanCaseClassification, "Boolean", 
                    o.blnInitialHumanCaseClassification == null ? "" : o.blnInitialHumanCaseClassification.ToString(),                  
                  o.IsReadOnly(_str_blnInitialHumanCaseClassification), o.IsInvisible(_str_blnInitialHumanCaseClassification), o.IsRequired(_str_blnInitialHumanCaseClassification)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnFinalHumanCaseClassification, _formname = _str_blnFinalHumanCaseClassification, _type = "Boolean",
              _get_func = o => o.blnFinalHumanCaseClassification,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnFinalHumanCaseClassification != newval) o.blnFinalHumanCaseClassification = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnFinalHumanCaseClassification != c.blnFinalHumanCaseClassification || o.IsRIRPropChanged(_str_blnFinalHumanCaseClassification, c)) 
                  m.Add(_str_blnFinalHumanCaseClassification, o.ObjectIdent + _str_blnFinalHumanCaseClassification, o.ObjectIdent2 + _str_blnFinalHumanCaseClassification, o.ObjectIdent3 + _str_blnFinalHumanCaseClassification, "Boolean", 
                    o.blnFinalHumanCaseClassification == null ? "" : o.blnFinalHumanCaseClassification.ToString(),                  
                  o.IsReadOnly(_str_blnFinalHumanCaseClassification), o.IsInvisible(_str_blnFinalHumanCaseClassification), o.IsRequired(_str_blnFinalHumanCaseClassification)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intHACode, _formname = _str_intHACode, _type = "Int32?",
              _get_func = o => o.intHACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intHACode != newval) o.intHACode = newval; },
              _compare_func = (o, c, m) => {
                if (o.intHACode != c.intHACode || o.IsRIRPropChanged(_str_intHACode, c)) 
                  m.Add(_str_intHACode, o.ObjectIdent + _str_intHACode, o.ObjectIdent2 + _str_intHACode, o.ObjectIdent3 + _str_intHACode, "Int32?", 
                    o.intHACode == null ? "" : o.intHACode.ToString(),                  
                  o.IsReadOnly(_str_intHACode), o.IsInvisible(_str_intHACode), o.IsRequired(_str_intHACode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHACode, _formname = _str_strHACode, _type = "String",
              _get_func = o => o.strHACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHACode != newval) o.strHACode = newval; },
              _compare_func = (o, c, m) => {
                if (o.strHACode != c.strHACode || o.IsRIRPropChanged(_str_strHACode, c)) 
                  m.Add(_str_strHACode, o.ObjectIdent + _str_strHACode, o.ObjectIdent2 + _str_strHACode, o.ObjectIdent3 + _str_strHACode, "String", 
                    o.strHACode == null ? "" : o.strHACode.ToString(),                  
                  o.IsReadOnly(_str_strHACode), o.IsInvisible(_str_strHACode), o.IsRequired(_str_strHACode)); 
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
            CaseClassification obj = (CaseClassification)o;
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
        internal string m_ObjectName = "CaseClassification";

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
            var ret = base.Clone() as CaseClassification;
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
            var ret = base.Clone() as CaseClassification;
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
        public CaseClassification CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as CaseClassification;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsCaseClassification; } }
        public string KeyName { get { return "idfsCaseClassification"; } }
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
          
              switch(name)
              {
              
                case "CaseClassificationName":
                  return new Dictionary<string, string> {
                
                    { "en", "" },
                
                    } ;
              
                case "CaseClassificationNameTranslated":
                  return new Dictionary<string, string> {
                
                    { "def", "" },
                
                    } ;
              
                default:
                  return null;
              }
            
        }
      #endregion

        private bool IsRIRPropChanged(string fld, CaseClassification c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public CaseClassification()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(CaseClassification_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(CaseClassification_PropertyChanged);
        }
        private void CaseClassification_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as CaseClassification).Changed(e.PropertyName);
            
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
            CaseClassification obj = this;
            
        }
        private void _DeletedExtenders()
        {
            CaseClassification obj = this;
            
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

    
        private static string[] readonly_names1 = "blnInitialHumanCaseClassification".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "blnFinalHumanCaseClassification".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<CaseClassification, bool>(c => c.ReadOnly || ((c.intHACode & (int)HACode.Human) == 0))(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<CaseClassification, bool>(c => c.ReadOnly || ((c.intHACode & (int)HACode.Human) == 0))(this);
            
            return ReadOnly || new Func<CaseClassification, bool>(c => c.ReadOnly)(this);
                
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


        internal Dictionary<string, Func<CaseClassification, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<CaseClassification, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<CaseClassification, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<CaseClassification, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<CaseClassification, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<CaseClassification, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<CaseClassification, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~CaseClassification()
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
        public class CaseClassificationGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfsCaseClassification { get; set; }
        
            public String CaseClassificationName { get; set; }
        
            public String CaseClassificationNameTranslated { get; set; }
        
            public Int32? intHACode { get; set; }
        
            public Int32 intOrder { get; set; }
        
            public Boolean blnInitialHumanCaseClassification { get; set; }
        
            public Boolean blnFinalHumanCaseClassification { get; set; }
        
        }
        public partial class CaseClassificationGridModelList : List<CaseClassificationGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public CaseClassificationGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<CaseClassification>, errMes);
            }
            public CaseClassificationGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<CaseClassification>, errMes);
            }
            public CaseClassificationGridModelList(long key, IEnumerable<CaseClassification> items)
            {
                LoadGridModelList(key, items, null);
            }
            public CaseClassificationGridModelList(long key)
            {
                LoadGridModelList(key, new List<CaseClassification>(), null);
            }
            partial void filter(List<CaseClassification> items);
            private void LoadGridModelList(long key, IEnumerable<CaseClassification> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_CaseClassificationName,_str_CaseClassificationNameTranslated,_str_intHACode,_str_intOrder,_str_blnInitialHumanCaseClassification,_str_blnFinalHumanCaseClassification};
                    
                Hiddens = new List<string> {_str_idfsCaseClassification};
                Keys = new List<string> {};
                Labels = new Dictionary<string, string> {{_str_CaseClassificationName, "strCaseClassificationDefaultName"},{_str_CaseClassificationNameTranslated, "strCaseClassificationTranslatedName"},{_str_intHACode, "strHACode"},{_str_intOrder, _str_intOrder},{_str_blnInitialHumanCaseClassification, _str_blnInitialHumanCaseClassification},{_str_blnFinalHumanCaseClassification, _str_blnFinalHumanCaseClassification}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                CaseClassification.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<CaseClassification>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new CaseClassificationGridModel()
                {
                    idfsCaseClassification=c.idfsCaseClassification,CaseClassificationName=c.CaseClassificationName,CaseClassificationNameTranslated=c.CaseClassificationNameTranslated,intHACode=c.intHACode,intOrder=c.intOrder,blnInitialHumanCaseClassification=c.blnInitialHumanCaseClassification,blnFinalHumanCaseClassification=c.blnFinalHumanCaseClassification
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
        : DataAccessor<CaseClassification>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<CaseClassification>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsCaseClassification"; } }
            #endregion
        
            private delegate void on_action(CaseClassification obj);
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
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<CaseClassification> SelectList(DbManagerProxy manager
                , Int64? idfsCaseClassification
                )
            {
                return _SelectList(manager
                    , idfsCaseClassification
                    , delegate(CaseClassification obj)
                        {
                        }
                    , delegate(CaseClassification obj)
                        {
                        }
                    );
            }

            
            private List<CaseClassification> _SelectList(DbManagerProxy manager
                , Int64? idfsCaseClassification
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<CaseClassification> objs = new List<CaseClassification>();
                    sets[0] = new MapResultSet(typeof(CaseClassification), objs);
                    
                    manager
                        .SetSpCommand("spCaseClassification_SelectDetail"
                            , manager.Parameter("@idfsCaseClassification", idfsCaseClassification)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, CaseClassification obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, CaseClassification obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private CaseClassification _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    CaseClassification obj = CaseClassification.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfsCaseClassification = (new GetNewIDExtender<CaseClassification>()).GetScalar(manager, obj, isFake);
                obj.intOrder = new Func<CaseClassification, int>(c => 0)(obj);
                obj.blnInitialHumanCaseClassification = new Func<CaseClassification, bool>(c => false)(obj);
                obj.blnFinalHumanCaseClassification = new Func<CaseClassification, bool>(c => false)(obj);
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

            
            public CaseClassification CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public CaseClassification CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public CaseClassification CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(CaseClassification obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(CaseClassification obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_intHACode)
                        {
                    
                obj.blnInitialHumanCaseClassification = new Func<CaseClassification, bool>(c => ((c.intHACode & (int)HACode.Human) == 0) ? false : c.blnInitialHumanCaseClassification)(obj);
                        }
                    
                        if (e.PropertyName == _str_intHACode)
                        {
                    
                obj.blnFinalHumanCaseClassification = new Func<CaseClassification, bool>(c => ((c.intHACode & (int)HACode.Human) == 0) ? false : c.blnFinalHumanCaseClassification)(obj);
                        }
                    
                    };
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, CaseClassification obj)
            {
                
            }
    
            [SprocName("spCaseClassification_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, string LangID, 
                [Direction.InputOutput()] CaseClassification obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, string LangID, 
                [Direction.InputOutput()] CaseClassification obj)
            {
                
                _post(manager, Action, LangID, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    CaseClassification bo = obj as CaseClassification;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as CaseClassification, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, CaseClassification obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postPredicate(manager, 8, ModelUserContext.CurrentLanguage, obj);
                                
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, ModelUserContext.CurrentLanguage, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, ModelUserContext.CurrentLanguage, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(CaseClassification obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, CaseClassification obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(CaseClassification obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(CaseClassification obj, bool bRethrowException)
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
                return Validate(manager, obj as CaseClassification, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, CaseClassification obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "CaseClassificationName", "CaseClassificationName","",
                false
              )).Validate(c => true, obj, obj.CaseClassificationName);
            
                (new RequiredValidator( "CaseClassificationNameTranslated", "CaseClassificationNameTranslated","",
                false
              )).Validate(c => ModelUserContext.CurrentLanguage != Localizer.lngEn, obj, obj.CaseClassificationNameTranslated);
            
                (new RequiredValidator( "idfsCaseClassification", "idfsCaseClassification","",
                false
              )).Validate(c => true, obj, obj.idfsCaseClassification);
            
                  
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
           
    
            private void _SetupRequired(CaseClassification obj)
            {
            
                obj
                    .AddRequired("CaseClassificationName", c => true);
                    
                obj
                    .AddRequired("CaseClassificationNameTranslated", c => ModelUserContext.CurrentLanguage != Localizer.lngEn);
                    
                obj
                    .AddRequired("idfsCaseClassification", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(CaseClassification obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as CaseClassification) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as CaseClassification) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "CaseClassificationDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spCaseClassification_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spCaseClassification_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<CaseClassification, bool>> RequiredByField = new Dictionary<string, Func<CaseClassification, bool>>();
            public static Dictionary<string, Func<CaseClassification, bool>> RequiredByProperty = new Dictionary<string, Func<CaseClassification, bool>>();
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
                
                Sizes.Add(_str_CaseClassificationName, 2000);
                Sizes.Add(_str_CaseClassificationNameTranslated, 2000);
                Sizes.Add(_str_strHACode, 2000);
                if (!RequiredByField.ContainsKey("CaseClassificationName")) RequiredByField.Add("CaseClassificationName", c => true);
                if (!RequiredByProperty.ContainsKey("CaseClassificationName")) RequiredByProperty.Add("CaseClassificationName", c => true);
                
                if (!RequiredByField.ContainsKey("CaseClassificationNameTranslated")) RequiredByField.Add("CaseClassificationNameTranslated", c => ModelUserContext.CurrentLanguage != Localizer.lngEn);
                if (!RequiredByProperty.ContainsKey("CaseClassificationNameTranslated")) RequiredByProperty.Add("CaseClassificationNameTranslated", c => ModelUserContext.CurrentLanguage != Localizer.lngEn);
                
                if (!RequiredByField.ContainsKey("idfsCaseClassification")) RequiredByField.Add("idfsCaseClassification", c => true);
                if (!RequiredByProperty.ContainsKey("idfsCaseClassification")) RequiredByProperty.Add("idfsCaseClassification", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfsCaseClassification,
                    _str_idfsCaseClassification, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_CaseClassificationName,
                    "strCaseClassificationDefaultName", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_CaseClassificationNameTranslated,
                    "strCaseClassificationTranslatedName", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intHACode,
                    "strHACode", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intOrder,
                    _str_intOrder, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_blnInitialHumanCaseClassification,
                    _str_blnInitialHumanCaseClassification, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_blnFinalHumanCaseClassification,
                    _str_blnFinalHumanCaseClassification, null, true, true, true, true, null
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
                    (manager, c, pars) => ((CaseClassification)c).MarkToDelete(),
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
	