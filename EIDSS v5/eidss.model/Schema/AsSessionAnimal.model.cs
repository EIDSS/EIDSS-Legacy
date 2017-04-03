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
    public abstract partial class AsSessionAnimal : 
        EditableObject<AsSessionAnimal>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfAnimal), NonUpdatable, PrimaryKey]
        public abstract Int64 idfAnimal { get; set; }
                
        [LocalizedDisplayName(_str_idfsAnimalAge)]
        [MapField(_str_idfsAnimalAge)]
        public abstract Int64? idfsAnimalAge { get; set; }
        #if MONO
        protected Int64? idfsAnimalAge_Original { get { return idfsAnimalAge; } }
        protected Int64? idfsAnimalAge_Previous { get { return idfsAnimalAge; } }
        #else
        protected Int64? idfsAnimalAge_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalAge).OriginalValue; } }
        protected Int64? idfsAnimalAge_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalAge).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsAnimalGender)]
        [MapField(_str_idfsAnimalGender)]
        public abstract Int64? idfsAnimalGender { get; set; }
        #if MONO
        protected Int64? idfsAnimalGender_Original { get { return idfsAnimalGender; } }
        protected Int64? idfsAnimalGender_Previous { get { return idfsAnimalGender; } }
        #else
        protected Int64? idfsAnimalGender_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalGender).OriginalValue; } }
        protected Int64? idfsAnimalGender_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAnimalGender).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strAnimalCode)]
        [MapField(_str_strAnimalCode)]
        public abstract String strAnimalCode { get; set; }
        #if MONO
        protected String strAnimalCode_Original { get { return strAnimalCode; } }
        protected String strAnimalCode_Previous { get { return strAnimalCode; } }
        #else
        protected String strAnimalCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strAnimalCode).OriginalValue; } }
        protected String strAnimalCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAnimalCode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfSpecies)]
        [MapField(_str_idfSpecies)]
        public abstract Int64? idfSpecies { get; set; }
        #if MONO
        protected Int64? idfSpecies_Original { get { return idfSpecies; } }
        protected Int64? idfSpecies_Previous { get { return idfSpecies; } }
        #else
        protected Int64? idfSpecies_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).OriginalValue; } }
        protected Int64? idfSpecies_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strName)]
        [MapField(_str_strName)]
        public abstract String strName { get; set; }
        #if MONO
        protected String strName_Original { get { return strName; } }
        protected String strName_Previous { get { return strName; } }
        #else
        protected String strName_Original { get { return ((EditableValue<String>)((dynamic)this)._strName).OriginalValue; } }
        protected String strName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strColor)]
        [MapField(_str_strColor)]
        public abstract String strColor { get; set; }
        #if MONO
        protected String strColor_Original { get { return strColor; } }
        protected String strColor_Previous { get { return strColor; } }
        #else
        protected String strColor_Original { get { return ((EditableValue<String>)((dynamic)this)._strColor).OriginalValue; } }
        protected String strColor_Previous { get { return ((EditableValue<String>)((dynamic)this)._strColor).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSpeciesType)]
        [MapField(_str_idfsSpeciesType)]
        public abstract Int64 idfsSpeciesType { get; set; }
        #if MONO
        protected Int64 idfsSpeciesType_Original { get { return idfsSpeciesType; } }
        protected Int64 idfsSpeciesType_Previous { get { return idfsSpeciesType; } }
        #else
        protected Int64 idfsSpeciesType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSpeciesType).OriginalValue; } }
        protected Int64 idfsSpeciesType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSpeciesType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfMonitoringSession)]
        [MapField(_str_idfMonitoringSession)]
        public abstract Int64? idfMonitoringSession { get; set; }
        #if MONO
        protected Int64? idfMonitoringSession_Original { get { return idfMonitoringSession; } }
        protected Int64? idfMonitoringSession_Previous { get { return idfMonitoringSession; } }
        #else
        protected Int64? idfMonitoringSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).OriginalValue; } }
        protected Int64? idfMonitoringSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<AsSessionAnimal, object> _get_func;
            internal Action<AsSessionAnimal, string> _set_func;
            internal Action<AsSessionAnimal, AsSessionAnimal, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfAnimal = "idfAnimal";
        internal const string _str_idfsAnimalAge = "idfsAnimalAge";
        internal const string _str_idfsAnimalGender = "idfsAnimalGender";
        internal const string _str_strAnimalCode = "strAnimalCode";
        internal const string _str_idfSpecies = "idfSpecies";
        internal const string _str_strName = "strName";
        internal const string _str_strColor = "strColor";
        internal const string _str_idfsSpeciesType = "idfsSpeciesType";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_AnimalGender = "AnimalGender";
        internal const string _str_AnimalAge = "AnimalAge";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfAnimal, _type = "Int64",
              _get_func = o => o.idfAnimal,
              _set_func = (o, val) => { o.idfAnimal = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfAnimal != c.idfAnimal || o.IsRIRPropChanged(_str_idfAnimal, c)) 
                  m.Add(_str_idfAnimal, o.ObjectIdent + _str_idfAnimal, "Int64", o.idfAnimal == null ? "" : o.idfAnimal.ToString(), o.IsReadOnly(_str_idfAnimal), o.IsInvisible(_str_idfAnimal), o.IsRequired(_str_idfAnimal)); }
              }, 
        
            new field_info {
              _name = _str_idfsAnimalAge, _type = "Int64?",
              _get_func = o => o.idfsAnimalAge,
              _set_func = (o, val) => { o.idfsAnimalAge = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalAge != c.idfsAnimalAge || o.IsRIRPropChanged(_str_idfsAnimalAge, c)) 
                  m.Add(_str_idfsAnimalAge, o.ObjectIdent + _str_idfsAnimalAge, "Int64?", o.idfsAnimalAge == null ? "" : o.idfsAnimalAge.ToString(), o.IsReadOnly(_str_idfsAnimalAge), o.IsInvisible(_str_idfsAnimalAge), o.IsRequired(_str_idfsAnimalAge)); }
              }, 
        
            new field_info {
              _name = _str_idfsAnimalGender, _type = "Int64?",
              _get_func = o => o.idfsAnimalGender,
              _set_func = (o, val) => { o.idfsAnimalGender = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalGender != c.idfsAnimalGender || o.IsRIRPropChanged(_str_idfsAnimalGender, c)) 
                  m.Add(_str_idfsAnimalGender, o.ObjectIdent + _str_idfsAnimalGender, "Int64?", o.idfsAnimalGender == null ? "" : o.idfsAnimalGender.ToString(), o.IsReadOnly(_str_idfsAnimalGender), o.IsInvisible(_str_idfsAnimalGender), o.IsRequired(_str_idfsAnimalGender)); }
              }, 
        
            new field_info {
              _name = _str_strAnimalCode, _type = "String",
              _get_func = o => o.strAnimalCode,
              _set_func = (o, val) => { o.strAnimalCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strAnimalCode != c.strAnimalCode || o.IsRIRPropChanged(_str_strAnimalCode, c)) 
                  m.Add(_str_strAnimalCode, o.ObjectIdent + _str_strAnimalCode, "String", o.strAnimalCode == null ? "" : o.strAnimalCode.ToString(), o.IsReadOnly(_str_strAnimalCode), o.IsInvisible(_str_strAnimalCode), o.IsRequired(_str_strAnimalCode)); }
              }, 
        
            new field_info {
              _name = _str_idfSpecies, _type = "Int64?",
              _get_func = o => o.idfSpecies,
              _set_func = (o, val) => { o.idfSpecies = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSpecies != c.idfSpecies || o.IsRIRPropChanged(_str_idfSpecies, c)) 
                  m.Add(_str_idfSpecies, o.ObjectIdent + _str_idfSpecies, "Int64?", o.idfSpecies == null ? "" : o.idfSpecies.ToString(), o.IsReadOnly(_str_idfSpecies), o.IsInvisible(_str_idfSpecies), o.IsRequired(_str_idfSpecies)); }
              }, 
        
            new field_info {
              _name = _str_strName, _type = "String",
              _get_func = o => o.strName,
              _set_func = (o, val) => { o.strName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strName != c.strName || o.IsRIRPropChanged(_str_strName, c)) 
                  m.Add(_str_strName, o.ObjectIdent + _str_strName, "String", o.strName == null ? "" : o.strName.ToString(), o.IsReadOnly(_str_strName), o.IsInvisible(_str_strName), o.IsRequired(_str_strName)); }
              }, 
        
            new field_info {
              _name = _str_strColor, _type = "String",
              _get_func = o => o.strColor,
              _set_func = (o, val) => { o.strColor = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strColor != c.strColor || o.IsRIRPropChanged(_str_strColor, c)) 
                  m.Add(_str_strColor, o.ObjectIdent + _str_strColor, "String", o.strColor == null ? "" : o.strColor.ToString(), o.IsReadOnly(_str_strColor), o.IsInvisible(_str_strColor), o.IsRequired(_str_strColor)); }
              }, 
        
            new field_info {
              _name = _str_idfsSpeciesType, _type = "Int64",
              _get_func = o => o.idfsSpeciesType,
              _set_func = (o, val) => { o.idfsSpeciesType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_idfsSpeciesType, c)) 
                  m.Add(_str_idfsSpeciesType, o.ObjectIdent + _str_idfsSpeciesType, "Int64", o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(), o.IsReadOnly(_str_idfsSpeciesType), o.IsInvisible(_str_idfsSpeciesType), o.IsRequired(_str_idfsSpeciesType)); }
              }, 
        
            new field_info {
              _name = _str_idfMonitoringSession, _type = "Int64?",
              _get_func = o => o.idfMonitoringSession,
              _set_func = (o, val) => { o.idfMonitoringSession = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfMonitoringSession != c.idfMonitoringSession || o.IsRIRPropChanged(_str_idfMonitoringSession, c)) 
                  m.Add(_str_idfMonitoringSession, o.ObjectIdent + _str_idfMonitoringSession, "Int64?", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_idfMonitoringSession), o.IsInvisible(_str_idfMonitoringSession), o.IsRequired(_str_idfMonitoringSession)); }
              }, 
        
            new field_info {
              _name = _str_AnimalGender, _type = "Lookup",
              _get_func = o => { if (o.AnimalGender == null) return null; return o.AnimalGender.idfsBaseReference; },
              _set_func = (o, val) => { o.AnimalGender = o.AnimalGenderLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalGender != c.idfsAnimalGender || o.IsRIRPropChanged(_str_AnimalGender, c)) 
                  m.Add(_str_AnimalGender, o.ObjectIdent + _str_AnimalGender, "Lookup", o.idfsAnimalGender == null ? "" : o.idfsAnimalGender.ToString(), o.IsReadOnly(_str_AnimalGender), o.IsInvisible(_str_AnimalGender), o.IsRequired(_str_AnimalGender)); }
              }, 
        
            new field_info {
              _name = _str_AnimalAge, _type = "Lookup",
              _get_func = o => { if (o.AnimalAge == null) return null; return o.AnimalAge.idfsReference; },
              _set_func = (o, val) => { o.AnimalAge = o.AnimalAgeLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalAge != c.idfsAnimalAge || o.IsRIRPropChanged(_str_AnimalAge, c)) 
                  m.Add(_str_AnimalAge, o.ObjectIdent + _str_AnimalAge, "Lookup", o.idfsAnimalAge == null ? "" : o.idfsAnimalAge.ToString(), o.IsReadOnly(_str_AnimalAge), o.IsInvisible(_str_AnimalAge), o.IsRequired(_str_AnimalAge)); }
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
            AsSessionAnimal obj = (AsSessionAnimal)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAnimalGender)]
        public BaseReference AnimalGender
        {
            get { return _AnimalGender == null ? null : ((long)_AnimalGender.Key == 0 ? null : _AnimalGender); }
            set 
            { 
                _AnimalGender = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAnimalGender = _AnimalGender == null 
                    ? new Int64?()
                    : _AnimalGender.idfsBaseReference; 
                OnPropertyChanged(_str_AnimalGender); 
            }
        }
        private BaseReference _AnimalGender;

        
        public BaseReferenceList AnimalGenderLookup
        {
            get { return _AnimalGenderLookup; }
        }
        private BaseReferenceList _AnimalGenderLookup = new BaseReferenceList("rftAnimalGenderList");
            
        [Relation(typeof(AnimalAgeLookup), eidss.model.Schema.AnimalAgeLookup._str_idfsReference, _str_idfsAnimalAge)]
        public AnimalAgeLookup AnimalAge
        {
            get { return _AnimalAge == null ? null : ((long)_AnimalAge.Key == 0 ? null : _AnimalAge); }
            set 
            { 
                _AnimalAge = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAnimalAge = _AnimalAge == null 
                    ? new Int64?()
                    : _AnimalAge.idfsReference; 
                OnPropertyChanged(_str_AnimalAge); 
            }
        }
        private AnimalAgeLookup _AnimalAge;

        
        public List<AnimalAgeLookup> AnimalAgeLookup
        {
            get { return _AnimalAgeLookup; }
        }
        private List<AnimalAgeLookup> _AnimalAgeLookup = new List<AnimalAgeLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_AnimalGender:
                    return new BvSelectList(AnimalGenderLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AnimalGender, _str_idfsAnimalGender);
            
                case _str_AnimalAge:
                    return new BvSelectList(AnimalAgeLookup, eidss.model.Schema.AnimalAgeLookup._str_idfsReference, null, AnimalAge, _str_idfsAnimalAge);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AsSessionAnimal";

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
            var ret = base.Clone() as AsSessionAnimal;
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
            var ret = base.Clone() as AsSessionAnimal;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public AsSessionAnimal CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AsSessionAnimal;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfAnimal; } }
        public string KeyName { get { return "idfAnimal"; } }
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
        
            var _prev_idfsAnimalGender_AnimalGender = idfsAnimalGender;
            var _prev_idfsAnimalAge_AnimalAge = idfsAnimalAge;
            base.RejectChanges();
        
            if (_prev_idfsAnimalGender_AnimalGender != idfsAnimalGender)
            {
                _AnimalGender = _AnimalGenderLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAnimalGender);
            }
            if (_prev_idfsAnimalAge_AnimalAge != idfsAnimalAge)
            {
                _AnimalAge = _AnimalAgeLookup.FirstOrDefault(c => c.idfsReference == idfsAnimalAge);
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

      private bool IsRIRPropChanged(string fld, AsSessionAnimal c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public AsSessionAnimal()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AsSessionAnimal_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AsSessionAnimal_PropertyChanged);
        }
        private void AsSessionAnimal_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AsSessionAnimal).Changed(e.PropertyName);
            
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
            AsSessionAnimal obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AsSessionAnimal obj = this;
            
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


        public Dictionary<string, Func<AsSessionAnimal, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsSessionAnimal, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsSessionAnimal, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<AsSessionAnimal, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<AsSessionAnimal, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<AsSessionAnimal, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AsSessionAnimal()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftAnimalGenderList", this);
                
                LookupManager.RemoveObject("AnimalAgeLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftAnimalGenderList")
                _getAccessor().LoadLookup_AnimalGender(manager, this);
            
            if (lookup_object == "AnimalAgeLookup")
                _getAccessor().LoadLookup_AnimalAge(manager, this);
            
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
        : DataAccessor<AsSessionAnimal>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(AsSessionAnimal obj);
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
            private BaseReference.Accessor AnimalGenderAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private AnimalAgeLookup.Accessor AnimalAgeAccessor { get { return eidss.model.Schema.AnimalAgeLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<AsSessionAnimal> SelectList(DbManagerProxy manager
                , Int64? idfMonitoringSession
                )
            {
                return _SelectList(manager
                    , idfMonitoringSession
                    , delegate(AsSessionAnimal obj)
                        {
                        }
                    , delegate(AsSessionAnimal obj)
                        {
                        }
                    );
            }

            
            private List<AsSessionAnimal> _SelectList(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<AsSessionAnimal> objs = new List<AsSessionAnimal>();
                    sets[0] = new MapResultSet(typeof(AsSessionAnimal), objs);
                    
                    manager
                        .SetSpCommand("spASSessionAnimals_SelectDetail"
                            , manager.Parameter("@idfMonitoringSession", idfMonitoringSession)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsSessionAnimal obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AsSessionAnimal obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AsSessionAnimal _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    AsSessionAnimal obj = AsSessionAnimal.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfAnimal = (new GetNewIDExtender<AsSessionAnimal>()).GetScalar(manager, obj);
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

            
            public AsSessionAnimal CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public AsSessionAnimal CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public AsSessionAnimal CreateAnimalCopyT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is AsSessionAnimal)) 
                    throw new TypeMismatchException("animal", typeof(AsSessionAnimal));
                
                return CreateAnimalCopy(manager, Parent
                    , (AsSessionAnimal)pars[0]
                    );
            }
            public IObject CreateAnimalCopy(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateAnimalCopyT(manager, Parent, pars);
            }
            public AsSessionAnimal CreateAnimalCopy(DbManagerProxy manager, IObject Parent
                , AsSessionAnimal animal
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.AnimalAge = animal.AnimalAge;
                obj.AnimalGender = animal.AnimalGender;
                obj.idfSpecies = animal.idfSpecies;
                obj.strAnimalCode = "(new animal)";
                obj.idfMonitoringSession = animal.idfMonitoringSession;
                }
                    , obj =>
                {
                }
                );
            }
            
            public AsSessionAnimal CreateInSessionT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is AsSessionTableViewItem)) 
                    throw new TypeMismatchException("line", typeof(AsSessionTableViewItem));
                
                return CreateInSession(manager, Parent
                    , (AsSessionTableViewItem)pars[0]
                    );
            }
            public IObject CreateInSession(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateInSessionT(manager, Parent, pars);
            }
            public AsSessionAnimal CreateInSession(DbManagerProxy manager, IObject Parent
                , AsSessionTableViewItem line
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfMonitoringSession = line.idfMonitoringSession;
                obj.idfSpecies = line.idfSpecies;
                obj.strAnimalCode = line.strAnimalCode;
                obj.idfsAnimalAge = line.idfsAnimalAge;
                obj.idfsAnimalGender = line.idfsAnimalGender;
                obj.strName = line.strName;
                obj.strColor = line.strColor;
                }
                    , obj =>
                {
                }
                );
            }
            
            public AsSessionAnimal CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 6) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long?)) 
                    throw new TypeMismatchException("idfSpecies", typeof(long?));
                if (pars[1] != null && !(pars[1] is string)) 
                    throw new TypeMismatchException("strAnimalCode", typeof(string));
                if (pars[2] != null && !(pars[2] is long?)) 
                    throw new TypeMismatchException("idfsAnimalAge", typeof(long?));
                if (pars[3] != null && !(pars[3] is long?)) 
                    throw new TypeMismatchException("idfsAnimalSex", typeof(long?));
                if (pars[4] != null && !(pars[4] is string)) 
                    throw new TypeMismatchException("strName", typeof(string));
                if (pars[5] != null && !(pars[5] is string)) 
                    throw new TypeMismatchException("strColor", typeof(string));
                
                return Create(manager, Parent
                    , (long?)pars[0]
                    , (string)pars[1]
                    , (long?)pars[2]
                    , (long?)pars[3]
                    , (string)pars[4]
                    , (string)pars[5]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public AsSessionAnimal Create(DbManagerProxy manager, IObject Parent
                , long? idfSpecies
                , string strAnimalCode
                , long? idfsAnimalAge
                , long? idfsAnimalSex
                , string strName
                , string strColor
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfSpecies = idfSpecies;
                obj.strAnimalCode = strAnimalCode;
                obj.idfsAnimalAge = idfsAnimalAge;
                obj.idfsAnimalGender = idfsAnimalSex;
                obj.strName = strName;
                obj.strColor = strColor;
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(AsSessionAnimal obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AsSessionAnimal obj)
            {
                
            }
    
            public void LoadLookup_AnimalGender(DbManagerProxy manager, AsSessionAnimal obj)
            {
                
                obj.AnimalGenderLookup.Clear();
                
                obj.AnimalGenderLookup.Add(AnimalGenderAccessor.CreateNewT(manager, null));
                
                obj.AnimalGenderLookup.AddRange(AnimalGenderAccessor.rftAnimalGenderList_SelectList(manager
                    
                    )
                    .Where(c => ((c.intHACode.GetValueOrDefault() & (int)HACode.Livestock) != 0) || !c.intHACode.HasValue || c.idfsBaseReference == obj.idfsAnimalGender)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAnimalGender))
                    
                    .ToList());
                
                if (obj.idfsAnimalGender != null && obj.idfsAnimalGender != 0)
                {
                    obj.AnimalGender = obj.AnimalGenderLookup
                        .Where(c => c.idfsBaseReference == obj.idfsAnimalGender)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftAnimalGenderList", obj, AnimalGenderAccessor.GetType(), "rftAnimalGenderList_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_AnimalAge(DbManagerProxy manager, AsSessionAnimal obj)
            {
                
                obj.AnimalAgeLookup.Clear();
                
                obj.AnimalAgeLookup.Add(AnimalAgeAccessor.CreateNewT(manager, null));
                
                obj.AnimalAgeLookup.AddRange(AnimalAgeAccessor.SelectLookupList(manager
                    
                    , new Func<AsSessionAnimal, string>(c => c.idfsSpeciesType.ToString())(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsAnimalAge))
                    
                    .ToList());
                
                if (obj.idfsAnimalAge != null && obj.idfsAnimalAge != 0)
                {
                    obj.AnimalAge = obj.AnimalAgeLookup
                        .Where(c => c.idfsReference == obj.idfsAnimalAge)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("AnimalAgeLookup", obj, AnimalAgeAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, AsSessionAnimal obj)
            {
                
                LoadLookup_AnimalGender(manager, obj);
                
                LoadLookup_AnimalAge(manager, obj);
                
            }
    
            [SprocName("spASSessionAnimals_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strAnimalCode", "strName", "strColor")] AsSessionAnimal obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strAnimalCode", "strName", "strColor")] AsSessionAnimal obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    AsSessionAnimal bo = obj as AsSessionAnimal;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        long mainObject = bo.idfAnimal;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            
                        }
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as AsSessionAnimal, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AsSessionAnimal obj, bool bChildObject) 
            { 
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
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(AsSessionAnimal obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AsSessionAnimal obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as AsSessionAnimal, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsSessionAnimal obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(AsSessionAnimal obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(AsSessionAnimal obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AsSessionAnimal) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AsSessionAnimal) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AsSessionAnimalDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spASSessionAnimals_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spASSessionAnimals_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsSessionAnimal, bool>> RequiredByField = new Dictionary<string, Func<AsSessionAnimal, bool>>();
            public static Dictionary<string, Func<AsSessionAnimal, bool>> RequiredByProperty = new Dictionary<string, Func<AsSessionAnimal, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strAnimalCode, 200);
                Sizes.Add(_str_strName, 200);
                Sizes.Add(_str_strColor, 200);
                Actions.Add(new ActionMetaItem(
                    "CreateAnimalCopy",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateAnimalCopy(manager, c, pars)),
                        
                    null,
                    
                    null,
                      false,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "CreateInSession",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateInSession(manager, c, pars)),
                        
                    null,
                    
                    null,
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
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).Create(manager, c, pars)),
                        
                    null,
                    
                    null,
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
                    (manager, c, pars) => ((AsSessionAnimal)c).MarkToDelete(),
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	