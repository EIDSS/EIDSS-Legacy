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
    public abstract partial class SpeciesVectorInfoLookup : 
        EditableObject<SpeciesVectorInfoLookup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfSpeciesVectorInfo), NonUpdatable, PrimaryKey]
        public abstract Int64 idfSpeciesVectorInfo { get; set; }
                
        [LocalizedDisplayName(_str_idfSpecies)]
        [MapField(_str_idfSpecies)]
        public abstract Int64? idfSpecies { get; set; }
        protected Int64? idfSpecies_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).OriginalValue; } }
        protected Int64? idfSpecies_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfAnimal)]
        [MapField(_str_idfAnimal)]
        public abstract Int64? idfAnimal { get; set; }
        protected Int64? idfAnimal_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAnimal).OriginalValue; } }
        protected Int64? idfAnimal_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAnimal).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfVector)]
        [MapField(_str_idfVector)]
        public abstract Int64? idfVector { get; set; }
        protected Int64? idfVector_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVector).OriginalValue; } }
        protected Int64? idfVector_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVector).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfCaseOrSession)]
        [MapField(_str_idfCaseOrSession)]
        public abstract Int64 idfCaseOrSession { get; set; }
        protected Int64 idfCaseOrSession_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfCaseOrSession).OriginalValue; } }
        protected Int64 idfCaseOrSession_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfCaseOrSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_SpeciesOrVectorType)]
        [MapField(_str_SpeciesOrVectorType)]
        public abstract String SpeciesOrVectorType { get; set; }
        protected String SpeciesOrVectorType_Original { get { return ((EditableValue<String>)((dynamic)this)._speciesOrVectorType).OriginalValue; } }
        protected String SpeciesOrVectorType_Previous { get { return ((EditableValue<String>)((dynamic)this)._speciesOrVectorType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_AnimalOrVectorSpecies)]
        [MapField(_str_AnimalOrVectorSpecies)]
        public abstract String AnimalOrVectorSpecies { get; set; }
        protected String AnimalOrVectorSpecies_Original { get { return ((EditableValue<String>)((dynamic)this)._animalOrVectorSpecies).OriginalValue; } }
        protected String AnimalOrVectorSpecies_Previous { get { return ((EditableValue<String>)((dynamic)this)._animalOrVectorSpecies).PreviousValue; } }
                
        [LocalizedDisplayName(_str_name)]
        [MapField(_str_name)]
        public abstract String name { get; set; }
        protected String name_Original { get { return ((EditableValue<String>)((dynamic)this)._name).OriginalValue; } }
        protected String name_Previous { get { return ((EditableValue<String>)((dynamic)this)._name).PreviousValue; } }
                
        [LocalizedDisplayName(_str_HumanName)]
        [MapField(_str_HumanName)]
        public abstract String HumanName { get; set; }
        protected String HumanName_Original { get { return ((EditableValue<String>)((dynamic)this)._humanName).OriginalValue; } }
        protected String HumanName_Previous { get { return ((EditableValue<String>)((dynamic)this)._humanName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRegion)]
        [MapField(_str_strRegion)]
        public abstract String strRegion { get; set; }
        protected String strRegion_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegion).OriginalValue; } }
        protected String strRegion_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegion).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRayon)]
        [MapField(_str_strRayon)]
        public abstract String strRayon { get; set; }
        protected String strRayon_Original { get { return ((EditableValue<String>)((dynamic)this)._strRayon).OriginalValue; } }
        protected String strRayon_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRayon).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intRowStatus)]
        [MapField(_str_intRowStatus)]
        public abstract Int32? intRowStatus { get; set; }
        protected Int32? intRowStatus_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intRowStatus).OriginalValue; } }
        protected Int32? intRowStatus_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intRowStatus).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<SpeciesVectorInfoLookup, object> _get_func;
            internal Action<SpeciesVectorInfoLookup, string> _set_func;
            internal Action<SpeciesVectorInfoLookup, SpeciesVectorInfoLookup, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfSpeciesVectorInfo = "idfSpeciesVectorInfo";
        internal const string _str_idfSpecies = "idfSpecies";
        internal const string _str_idfAnimal = "idfAnimal";
        internal const string _str_idfVector = "idfVector";
        internal const string _str_idfCaseOrSession = "idfCaseOrSession";
        internal const string _str_SpeciesOrVectorType = "SpeciesOrVectorType";
        internal const string _str_AnimalOrVectorSpecies = "AnimalOrVectorSpecies";
        internal const string _str_name = "name";
        internal const string _str_HumanName = "HumanName";
        internal const string _str_strRegion = "strRegion";
        internal const string _str_strRayon = "strRayon";
        internal const string _str_intRowStatus = "intRowStatus";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfSpeciesVectorInfo, _formname = _str_idfSpeciesVectorInfo, _type = "Int64",
              _get_func = o => o.idfSpeciesVectorInfo,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfSpeciesVectorInfo != newval) o.idfSpeciesVectorInfo = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfSpeciesVectorInfo != c.idfSpeciesVectorInfo || o.IsRIRPropChanged(_str_idfSpeciesVectorInfo, c)) 
                  m.Add(_str_idfSpeciesVectorInfo, o.ObjectIdent + _str_idfSpeciesVectorInfo, o.ObjectIdent2 + _str_idfSpeciesVectorInfo, o.ObjectIdent3 + _str_idfSpeciesVectorInfo, "Int64", 
                    o.idfSpeciesVectorInfo == null ? "" : o.idfSpeciesVectorInfo.ToString(),                  
                  o.IsReadOnly(_str_idfSpeciesVectorInfo), o.IsInvisible(_str_idfSpeciesVectorInfo), o.IsRequired(_str_idfSpeciesVectorInfo)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSpecies, _formname = _str_idfSpecies, _type = "Int64?",
              _get_func = o => o.idfSpecies,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfSpecies != newval) o.idfSpecies = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfSpecies != c.idfSpecies || o.IsRIRPropChanged(_str_idfSpecies, c)) 
                  m.Add(_str_idfSpecies, o.ObjectIdent + _str_idfSpecies, o.ObjectIdent2 + _str_idfSpecies, o.ObjectIdent3 + _str_idfSpecies, "Int64?", 
                    o.idfSpecies == null ? "" : o.idfSpecies.ToString(),                  
                  o.IsReadOnly(_str_idfSpecies), o.IsInvisible(_str_idfSpecies), o.IsRequired(_str_idfSpecies)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfAnimal, _formname = _str_idfAnimal, _type = "Int64?",
              _get_func = o => o.idfAnimal,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfAnimal != newval) o.idfAnimal = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfAnimal != c.idfAnimal || o.IsRIRPropChanged(_str_idfAnimal, c)) 
                  m.Add(_str_idfAnimal, o.ObjectIdent + _str_idfAnimal, o.ObjectIdent2 + _str_idfAnimal, o.ObjectIdent3 + _str_idfAnimal, "Int64?", 
                    o.idfAnimal == null ? "" : o.idfAnimal.ToString(),                  
                  o.IsReadOnly(_str_idfAnimal), o.IsInvisible(_str_idfAnimal), o.IsRequired(_str_idfAnimal)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfVector, _formname = _str_idfVector, _type = "Int64?",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfVector != newval) o.idfVector = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) 
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, o.ObjectIdent2 + _str_idfVector, o.ObjectIdent3 + _str_idfVector, "Int64?", 
                    o.idfVector == null ? "" : o.idfVector.ToString(),                  
                  o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfCaseOrSession, _formname = _str_idfCaseOrSession, _type = "Int64",
              _get_func = o => o.idfCaseOrSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfCaseOrSession != newval) o.idfCaseOrSession = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfCaseOrSession != c.idfCaseOrSession || o.IsRIRPropChanged(_str_idfCaseOrSession, c)) 
                  m.Add(_str_idfCaseOrSession, o.ObjectIdent + _str_idfCaseOrSession, o.ObjectIdent2 + _str_idfCaseOrSession, o.ObjectIdent3 + _str_idfCaseOrSession, "Int64", 
                    o.idfCaseOrSession == null ? "" : o.idfCaseOrSession.ToString(),                  
                  o.IsReadOnly(_str_idfCaseOrSession), o.IsInvisible(_str_idfCaseOrSession), o.IsRequired(_str_idfCaseOrSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_SpeciesOrVectorType, _formname = _str_SpeciesOrVectorType, _type = "String",
              _get_func = o => o.SpeciesOrVectorType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.SpeciesOrVectorType != newval) o.SpeciesOrVectorType = newval; },
              _compare_func = (o, c, m) => {
                if (o.SpeciesOrVectorType != c.SpeciesOrVectorType || o.IsRIRPropChanged(_str_SpeciesOrVectorType, c)) 
                  m.Add(_str_SpeciesOrVectorType, o.ObjectIdent + _str_SpeciesOrVectorType, o.ObjectIdent2 + _str_SpeciesOrVectorType, o.ObjectIdent3 + _str_SpeciesOrVectorType, "String", 
                    o.SpeciesOrVectorType == null ? "" : o.SpeciesOrVectorType.ToString(),                  
                  o.IsReadOnly(_str_SpeciesOrVectorType), o.IsInvisible(_str_SpeciesOrVectorType), o.IsRequired(_str_SpeciesOrVectorType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_AnimalOrVectorSpecies, _formname = _str_AnimalOrVectorSpecies, _type = "String",
              _get_func = o => o.AnimalOrVectorSpecies,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.AnimalOrVectorSpecies != newval) o.AnimalOrVectorSpecies = newval; },
              _compare_func = (o, c, m) => {
                if (o.AnimalOrVectorSpecies != c.AnimalOrVectorSpecies || o.IsRIRPropChanged(_str_AnimalOrVectorSpecies, c)) 
                  m.Add(_str_AnimalOrVectorSpecies, o.ObjectIdent + _str_AnimalOrVectorSpecies, o.ObjectIdent2 + _str_AnimalOrVectorSpecies, o.ObjectIdent3 + _str_AnimalOrVectorSpecies, "String", 
                    o.AnimalOrVectorSpecies == null ? "" : o.AnimalOrVectorSpecies.ToString(),                  
                  o.IsReadOnly(_str_AnimalOrVectorSpecies), o.IsInvisible(_str_AnimalOrVectorSpecies), o.IsRequired(_str_AnimalOrVectorSpecies)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_name, _formname = _str_name, _type = "String",
              _get_func = o => o.name,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.name != newval) o.name = newval; },
              _compare_func = (o, c, m) => {
                if (o.name != c.name || o.IsRIRPropChanged(_str_name, c)) 
                  m.Add(_str_name, o.ObjectIdent + _str_name, o.ObjectIdent2 + _str_name, o.ObjectIdent3 + _str_name, "String", 
                    o.name == null ? "" : o.name.ToString(),                  
                  o.IsReadOnly(_str_name), o.IsInvisible(_str_name), o.IsRequired(_str_name)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_HumanName, _formname = _str_HumanName, _type = "String",
              _get_func = o => o.HumanName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.HumanName != newval) o.HumanName = newval; },
              _compare_func = (o, c, m) => {
                if (o.HumanName != c.HumanName || o.IsRIRPropChanged(_str_HumanName, c)) 
                  m.Add(_str_HumanName, o.ObjectIdent + _str_HumanName, o.ObjectIdent2 + _str_HumanName, o.ObjectIdent3 + _str_HumanName, "String", 
                    o.HumanName == null ? "" : o.HumanName.ToString(),                  
                  o.IsReadOnly(_str_HumanName), o.IsInvisible(_str_HumanName), o.IsRequired(_str_HumanName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRegion, _formname = _str_strRegion, _type = "String",
              _get_func = o => o.strRegion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRegion != newval) o.strRegion = newval; },
              _compare_func = (o, c, m) => {
                if (o.strRegion != c.strRegion || o.IsRIRPropChanged(_str_strRegion, c)) 
                  m.Add(_str_strRegion, o.ObjectIdent + _str_strRegion, o.ObjectIdent2 + _str_strRegion, o.ObjectIdent3 + _str_strRegion, "String", 
                    o.strRegion == null ? "" : o.strRegion.ToString(),                  
                  o.IsReadOnly(_str_strRegion), o.IsInvisible(_str_strRegion), o.IsRequired(_str_strRegion)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRayon, _formname = _str_strRayon, _type = "String",
              _get_func = o => o.strRayon,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRayon != newval) o.strRayon = newval; },
              _compare_func = (o, c, m) => {
                if (o.strRayon != c.strRayon || o.IsRIRPropChanged(_str_strRayon, c)) 
                  m.Add(_str_strRayon, o.ObjectIdent + _str_strRayon, o.ObjectIdent2 + _str_strRayon, o.ObjectIdent3 + _str_strRayon, "String", 
                    o.strRayon == null ? "" : o.strRayon.ToString(),                  
                  o.IsReadOnly(_str_strRayon), o.IsInvisible(_str_strRayon), o.IsRequired(_str_strRayon)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intRowStatus, _formname = _str_intRowStatus, _type = "Int32?",
              _get_func = o => o.intRowStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intRowStatus != newval) o.intRowStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.intRowStatus != c.intRowStatus || o.IsRIRPropChanged(_str_intRowStatus, c)) 
                  m.Add(_str_intRowStatus, o.ObjectIdent + _str_intRowStatus, o.ObjectIdent2 + _str_intRowStatus, o.ObjectIdent3 + _str_intRowStatus, "Int32?", 
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
            SpeciesVectorInfoLookup obj = (SpeciesVectorInfoLookup)o;
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
        internal string m_ObjectName = "SpeciesVectorInfoLookup";

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
            var ret = base.Clone() as SpeciesVectorInfoLookup;
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
            var ret = base.Clone() as SpeciesVectorInfoLookup;
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
        public SpeciesVectorInfoLookup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as SpeciesVectorInfoLookup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfSpeciesVectorInfo; } }
        public string KeyName { get { return "idfSpeciesVectorInfo"; } }
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
          return null;
        }
      #endregion

        private bool IsRIRPropChanged(string fld, SpeciesVectorInfoLookup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      
        public override string ToString()
        {
            return new Func<SpeciesVectorInfoLookup, string>(c => c.name)(this);
        }
        

        public SpeciesVectorInfoLookup()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SpeciesVectorInfoLookup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(SpeciesVectorInfoLookup_PropertyChanged);
        }
        private void SpeciesVectorInfoLookup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as SpeciesVectorInfoLookup).Changed(e.PropertyName);
            
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
            SpeciesVectorInfoLookup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            SpeciesVectorInfoLookup obj = this;
            
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


        internal Dictionary<string, Func<SpeciesVectorInfoLookup, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<SpeciesVectorInfoLookup, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<SpeciesVectorInfoLookup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<SpeciesVectorInfoLookup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<SpeciesVectorInfoLookup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<SpeciesVectorInfoLookup, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<SpeciesVectorInfoLookup, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~SpeciesVectorInfoLookup()
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
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<SpeciesVectorInfoLookup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<SpeciesVectorInfoLookup>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfSpeciesVectorInfo"; } }
            #endregion
        
            private delegate void on_action(SpeciesVectorInfoLookup obj);
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
            
            public virtual List<SpeciesVectorInfoLookup> SelectLookupList(DbManagerProxy manager
                , Int64? idfCaseOrSession
                )
            {
                return _SelectList(manager
                    , idfCaseOrSession
                    , null, null
                    );
            }
            
            public virtual List<SpeciesVectorInfoLookup> SelectList(DbManagerProxy manager
                , Int64? idfCaseOrSession
                )
            {
                return _SelectList(manager
                    , idfCaseOrSession
                    , delegate(SpeciesVectorInfoLookup obj)
                        {
                        }
                    , delegate(SpeciesVectorInfoLookup obj)
                        {
                        }
                    );
            }

            
            private List<SpeciesVectorInfoLookup> _SelectList(DbManagerProxy manager
                , Int64? idfCaseOrSession
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<SpeciesVectorInfoLookup> objs = new List<SpeciesVectorInfoLookup>();
                    sets[0] = new MapResultSet(typeof(SpeciesVectorInfoLookup), objs);
                    
                    manager
                        .SetSpCommand("spSpeciesVectorInfo_SelectLookup"
                            , manager.Parameter("@idfCaseOrSession", idfCaseOrSession)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, SpeciesVectorInfoLookup obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, SpeciesVectorInfoLookup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private SpeciesVectorInfoLookup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    SpeciesVectorInfoLookup obj = SpeciesVectorInfoLookup.CreateInstance();
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

            
            public SpeciesVectorInfoLookup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public SpeciesVectorInfoLookup CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public SpeciesVectorInfoLookup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(SpeciesVectorInfoLookup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(SpeciesVectorInfoLookup obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, SpeciesVectorInfoLookup obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(SpeciesVectorInfoLookup obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(SpeciesVectorInfoLookup obj, bool bRethrowException)
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
                return Validate(manager, obj as SpeciesVectorInfoLookup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, SpeciesVectorInfoLookup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(SpeciesVectorInfoLookup obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(SpeciesVectorInfoLookup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as SpeciesVectorInfoLookup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as SpeciesVectorInfoLookup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "SpeciesVectorInfoLookupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spSpeciesVectorInfo_SelectLookup";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<SpeciesVectorInfoLookup, bool>> RequiredByField = new Dictionary<string, Func<SpeciesVectorInfoLookup, bool>>();
            public static Dictionary<string, Func<SpeciesVectorInfoLookup, bool>> RequiredByProperty = new Dictionary<string, Func<SpeciesVectorInfoLookup, bool>>();
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
                
                Sizes.Add(_str_SpeciesOrVectorType, 2000);
                Sizes.Add(_str_AnimalOrVectorSpecies, 2000);
                Sizes.Add(_str_name, 4000);
                Sizes.Add(_str_HumanName, 602);
                Sizes.Add(_str_strRegion, 300);
                Sizes.Add(_str_strRayon, 300);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<SpeciesVectorInfoLookup>().Post(manager, (SpeciesVectorInfoLookup)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<SpeciesVectorInfoLookup>().Post(manager, (SpeciesVectorInfoLookup)c), c),
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
                    (manager, c, pars) => new ActResult(((SpeciesVectorInfoLookup)c).MarkToDelete() && ObjectAccessor.PostInterface<SpeciesVectorInfoLookup>().Post(manager, (SpeciesVectorInfoLookup)c), c),
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
	