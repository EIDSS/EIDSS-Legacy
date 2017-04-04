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
    public abstract partial class SystemPreferences : 
        EditableObject<SystemPreferences>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfSystemPreferences), NonUpdatable, PrimaryKey]
        public abstract Int64 idfSystemPreferences { get; set; }
                
        [LocalizedDisplayName(_str_intListGridPageSize)]
        [MapField(_str_intListGridPageSize)]
        public abstract Int32? intListGridPageSize { get; set; }
        protected Int32? intListGridPageSize_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intListGridPageSize).OriginalValue; } }
        protected Int32? intListGridPageSize_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intListGridPageSize).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intPopupGridPageSize)]
        [MapField(_str_intPopupGridPageSize)]
        public abstract Int32? intPopupGridPageSize { get; set; }
        protected Int32? intPopupGridPageSize_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intPopupGridPageSize).OriginalValue; } }
        protected Int32? intPopupGridPageSize_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intPopupGridPageSize).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intDetailGridPageSize)]
        [MapField(_str_intDetailGridPageSize)]
        public abstract Int32? intDetailGridPageSize { get; set; }
        protected Int32? intDetailGridPageSize_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intDetailGridPageSize).OriginalValue; } }
        protected Int32? intDetailGridPageSize_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intDetailGridPageSize).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intLabSectionPageSize)]
        [MapField(_str_intLabSectionPageSize)]
        public abstract Int32? intLabSectionPageSize { get; set; }
        protected Int32? intLabSectionPageSize_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intLabSectionPageSize).OriginalValue; } }
        protected Int32? intLabSectionPageSize_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intLabSectionPageSize).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnDefaultRegion)]
        [MapField(_str_blnDefaultRegion)]
        public abstract Boolean? blnDefaultRegion { get; set; }
        protected Boolean? blnDefaultRegion_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnDefaultRegion).OriginalValue; } }
        protected Boolean? blnDefaultRegion_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnDefaultRegion).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intDefaultDays)]
        [MapField(_str_intDefaultDays)]
        public abstract Int32? intDefaultDays { get; set; }
        protected Int32? intDefaultDays_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intDefaultDays).OriginalValue; } }
        protected Int32? intDefaultDays_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intDefaultDays).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnFilterByDiagnosis)]
        [MapField(_str_blnFilterByDiagnosis)]
        public abstract Boolean? blnFilterByDiagnosis { get; set; }
        protected Boolean? blnFilterByDiagnosis_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnFilterByDiagnosis).OriginalValue; } }
        protected Boolean? blnFilterByDiagnosis_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnFilterByDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnPrintMapInVetInvestigationForm)]
        [MapField(_str_blnPrintMapInVetInvestigationForm)]
        public abstract Boolean? blnPrintMapInVetInvestigationForm { get; set; }
        protected Boolean? blnPrintMapInVetInvestigationForm_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnPrintMapInVetInvestigationForm).OriginalValue; } }
        protected Boolean? blnPrintMapInVetInvestigationForm_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnPrintMapInVetInvestigationForm).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnShowWharningForFinalCaseDefinition)]
        [MapField(_str_blnShowWharningForFinalCaseDefinition)]
        public abstract Boolean? blnShowWharningForFinalCaseDefinition { get; set; }
        protected Boolean? blnShowWharningForFinalCaseDefinition_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnShowWharningForFinalCaseDefinition).OriginalValue; } }
        protected Boolean? blnShowWharningForFinalCaseDefinition_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnShowWharningForFinalCaseDefinition).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<SystemPreferences, object> _get_func;
            internal Action<SystemPreferences, string> _set_func;
            internal Action<SystemPreferences, SystemPreferences, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfSystemPreferences = "idfSystemPreferences";
        internal const string _str_intListGridPageSize = "intListGridPageSize";
        internal const string _str_intPopupGridPageSize = "intPopupGridPageSize";
        internal const string _str_intDetailGridPageSize = "intDetailGridPageSize";
        internal const string _str_intLabSectionPageSize = "intLabSectionPageSize";
        internal const string _str_blnDefaultRegion = "blnDefaultRegion";
        internal const string _str_intDefaultDays = "intDefaultDays";
        internal const string _str_blnFilterByDiagnosis = "blnFilterByDiagnosis";
        internal const string _str_blnPrintMapInVetInvestigationForm = "blnPrintMapInVetInvestigationForm";
        internal const string _str_blnShowWharningForFinalCaseDefinition = "blnShowWharningForFinalCaseDefinition";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfSystemPreferences, _formname = _str_idfSystemPreferences, _type = "Int64",
              _get_func = o => o.idfSystemPreferences,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfSystemPreferences != newval) o.idfSystemPreferences = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfSystemPreferences != c.idfSystemPreferences || o.IsRIRPropChanged(_str_idfSystemPreferences, c)) 
                  m.Add(_str_idfSystemPreferences, o.ObjectIdent + _str_idfSystemPreferences, o.ObjectIdent2 + _str_idfSystemPreferences, o.ObjectIdent3 + _str_idfSystemPreferences, "Int64", 
                    o.idfSystemPreferences == null ? "" : o.idfSystemPreferences.ToString(),                  
                  o.IsReadOnly(_str_idfSystemPreferences), o.IsInvisible(_str_idfSystemPreferences), o.IsRequired(_str_idfSystemPreferences)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intListGridPageSize, _formname = _str_intListGridPageSize, _type = "Int32?",
              _get_func = o => o.intListGridPageSize,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intListGridPageSize != newval) o.intListGridPageSize = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intListGridPageSize != c.intListGridPageSize || o.IsRIRPropChanged(_str_intListGridPageSize, c)) 
                  m.Add(_str_intListGridPageSize, o.ObjectIdent + _str_intListGridPageSize, o.ObjectIdent2 + _str_intListGridPageSize, o.ObjectIdent3 + _str_intListGridPageSize, "Int32?", 
                    o.intListGridPageSize == null ? "" : o.intListGridPageSize.ToString(),                  
                  o.IsReadOnly(_str_intListGridPageSize), o.IsInvisible(_str_intListGridPageSize), o.IsRequired(_str_intListGridPageSize)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intPopupGridPageSize, _formname = _str_intPopupGridPageSize, _type = "Int32?",
              _get_func = o => o.intPopupGridPageSize,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intPopupGridPageSize != newval) o.intPopupGridPageSize = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intPopupGridPageSize != c.intPopupGridPageSize || o.IsRIRPropChanged(_str_intPopupGridPageSize, c)) 
                  m.Add(_str_intPopupGridPageSize, o.ObjectIdent + _str_intPopupGridPageSize, o.ObjectIdent2 + _str_intPopupGridPageSize, o.ObjectIdent3 + _str_intPopupGridPageSize, "Int32?", 
                    o.intPopupGridPageSize == null ? "" : o.intPopupGridPageSize.ToString(),                  
                  o.IsReadOnly(_str_intPopupGridPageSize), o.IsInvisible(_str_intPopupGridPageSize), o.IsRequired(_str_intPopupGridPageSize)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intDetailGridPageSize, _formname = _str_intDetailGridPageSize, _type = "Int32?",
              _get_func = o => o.intDetailGridPageSize,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intDetailGridPageSize != newval) o.intDetailGridPageSize = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intDetailGridPageSize != c.intDetailGridPageSize || o.IsRIRPropChanged(_str_intDetailGridPageSize, c)) 
                  m.Add(_str_intDetailGridPageSize, o.ObjectIdent + _str_intDetailGridPageSize, o.ObjectIdent2 + _str_intDetailGridPageSize, o.ObjectIdent3 + _str_intDetailGridPageSize, "Int32?", 
                    o.intDetailGridPageSize == null ? "" : o.intDetailGridPageSize.ToString(),                  
                  o.IsReadOnly(_str_intDetailGridPageSize), o.IsInvisible(_str_intDetailGridPageSize), o.IsRequired(_str_intDetailGridPageSize)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intLabSectionPageSize, _formname = _str_intLabSectionPageSize, _type = "Int32?",
              _get_func = o => o.intLabSectionPageSize,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intLabSectionPageSize != newval) o.intLabSectionPageSize = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intLabSectionPageSize != c.intLabSectionPageSize || o.IsRIRPropChanged(_str_intLabSectionPageSize, c)) 
                  m.Add(_str_intLabSectionPageSize, o.ObjectIdent + _str_intLabSectionPageSize, o.ObjectIdent2 + _str_intLabSectionPageSize, o.ObjectIdent3 + _str_intLabSectionPageSize, "Int32?", 
                    o.intLabSectionPageSize == null ? "" : o.intLabSectionPageSize.ToString(),                  
                  o.IsReadOnly(_str_intLabSectionPageSize), o.IsInvisible(_str_intLabSectionPageSize), o.IsRequired(_str_intLabSectionPageSize)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnDefaultRegion, _formname = _str_blnDefaultRegion, _type = "Boolean?",
              _get_func = o => o.blnDefaultRegion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnDefaultRegion != newval) o.blnDefaultRegion = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnDefaultRegion != c.blnDefaultRegion || o.IsRIRPropChanged(_str_blnDefaultRegion, c)) 
                  m.Add(_str_blnDefaultRegion, o.ObjectIdent + _str_blnDefaultRegion, o.ObjectIdent2 + _str_blnDefaultRegion, o.ObjectIdent3 + _str_blnDefaultRegion, "Boolean?", 
                    o.blnDefaultRegion == null ? "" : o.blnDefaultRegion.ToString(),                  
                  o.IsReadOnly(_str_blnDefaultRegion), o.IsInvisible(_str_blnDefaultRegion), o.IsRequired(_str_blnDefaultRegion)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intDefaultDays, _formname = _str_intDefaultDays, _type = "Int32?",
              _get_func = o => o.intDefaultDays,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intDefaultDays != newval) o.intDefaultDays = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intDefaultDays != c.intDefaultDays || o.IsRIRPropChanged(_str_intDefaultDays, c)) 
                  m.Add(_str_intDefaultDays, o.ObjectIdent + _str_intDefaultDays, o.ObjectIdent2 + _str_intDefaultDays, o.ObjectIdent3 + _str_intDefaultDays, "Int32?", 
                    o.intDefaultDays == null ? "" : o.intDefaultDays.ToString(),                  
                  o.IsReadOnly(_str_intDefaultDays), o.IsInvisible(_str_intDefaultDays), o.IsRequired(_str_intDefaultDays)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnFilterByDiagnosis, _formname = _str_blnFilterByDiagnosis, _type = "Boolean?",
              _get_func = o => o.blnFilterByDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnFilterByDiagnosis != newval) o.blnFilterByDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnFilterByDiagnosis != c.blnFilterByDiagnosis || o.IsRIRPropChanged(_str_blnFilterByDiagnosis, c)) 
                  m.Add(_str_blnFilterByDiagnosis, o.ObjectIdent + _str_blnFilterByDiagnosis, o.ObjectIdent2 + _str_blnFilterByDiagnosis, o.ObjectIdent3 + _str_blnFilterByDiagnosis, "Boolean?", 
                    o.blnFilterByDiagnosis == null ? "" : o.blnFilterByDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_blnFilterByDiagnosis), o.IsInvisible(_str_blnFilterByDiagnosis), o.IsRequired(_str_blnFilterByDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnPrintMapInVetInvestigationForm, _formname = _str_blnPrintMapInVetInvestigationForm, _type = "Boolean?",
              _get_func = o => o.blnPrintMapInVetInvestigationForm,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnPrintMapInVetInvestigationForm != newval) o.blnPrintMapInVetInvestigationForm = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnPrintMapInVetInvestigationForm != c.blnPrintMapInVetInvestigationForm || o.IsRIRPropChanged(_str_blnPrintMapInVetInvestigationForm, c)) 
                  m.Add(_str_blnPrintMapInVetInvestigationForm, o.ObjectIdent + _str_blnPrintMapInVetInvestigationForm, o.ObjectIdent2 + _str_blnPrintMapInVetInvestigationForm, o.ObjectIdent3 + _str_blnPrintMapInVetInvestigationForm, "Boolean?", 
                    o.blnPrintMapInVetInvestigationForm == null ? "" : o.blnPrintMapInVetInvestigationForm.ToString(),                  
                  o.IsReadOnly(_str_blnPrintMapInVetInvestigationForm), o.IsInvisible(_str_blnPrintMapInVetInvestigationForm), o.IsRequired(_str_blnPrintMapInVetInvestigationForm)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnShowWharningForFinalCaseDefinition, _formname = _str_blnShowWharningForFinalCaseDefinition, _type = "Boolean?",
              _get_func = o => o.blnShowWharningForFinalCaseDefinition,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnShowWharningForFinalCaseDefinition != newval) o.blnShowWharningForFinalCaseDefinition = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnShowWharningForFinalCaseDefinition != c.blnShowWharningForFinalCaseDefinition || o.IsRIRPropChanged(_str_blnShowWharningForFinalCaseDefinition, c)) 
                  m.Add(_str_blnShowWharningForFinalCaseDefinition, o.ObjectIdent + _str_blnShowWharningForFinalCaseDefinition, o.ObjectIdent2 + _str_blnShowWharningForFinalCaseDefinition, o.ObjectIdent3 + _str_blnShowWharningForFinalCaseDefinition, "Boolean?", 
                    o.blnShowWharningForFinalCaseDefinition == null ? "" : o.blnShowWharningForFinalCaseDefinition.ToString(),                  
                  o.IsReadOnly(_str_blnShowWharningForFinalCaseDefinition), o.IsInvisible(_str_blnShowWharningForFinalCaseDefinition), o.IsRequired(_str_blnShowWharningForFinalCaseDefinition)); 
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
            SystemPreferences obj = (SystemPreferences)o;
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
        internal string m_ObjectName = "SystemPreferences";

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
            var ret = base.Clone() as SystemPreferences;
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
            var ret = base.Clone() as SystemPreferences;
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
        public SystemPreferences CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as SystemPreferences;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfSystemPreferences; } }
        public string KeyName { get { return "idfSystemPreferences"; } }
        public object KeyLookup { get { return idfSystemPreferences; } }
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

        private bool IsRIRPropChanged(string fld, SystemPreferences c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, SystemPreferences c)
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
        

      

        public SystemPreferences()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SystemPreferences_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(SystemPreferences_PropertyChanged);
        }
        private void SystemPreferences_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as SystemPreferences).Changed(e.PropertyName);
            
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
            SystemPreferences obj = this;
            
        }
        private void _DeletedExtenders()
        {
            SystemPreferences obj = this;
            
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


        internal Dictionary<string, Func<SystemPreferences, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<SystemPreferences, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<SystemPreferences, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<SystemPreferences, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<SystemPreferences, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<SystemPreferences, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<SystemPreferences, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~SystemPreferences()
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
        : DataAccessor<SystemPreferences>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<SystemPreferences>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<SystemPreferences>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfSystemPreferences"; } }
            #endregion
        
            public delegate void on_action(SystemPreferences obj);
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
            public virtual SystemPreferences SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
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

            
            public virtual SystemPreferences SelectByKey(DbManagerProxy manager
                )
            {
                return _SelectByKey(manager
                    , null, null
                    );
            }
            

            private SystemPreferences _SelectByKey(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual SystemPreferences _SelectByKeyInternal(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<SystemPreferences> objs = new List<SystemPreferences>();
                sets[0] = new MapResultSet(typeof(SystemPreferences), objs);
                SystemPreferences obj = null;
                try
                {
                    manager
                        .SetSpCommand("spSystemPreferences_SelectDetail"
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    obj = objs[0];
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
                    throw DbModelException.Create(obj, e);
                  }
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, SystemPreferences obj, bool bCloning = false)
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
                obj.intListGridPageSize = new Func<SystemPreferences, int?>(c => EidssUserContext.User.Options.Prefs.ListGridPageSize)(obj);
                obj.intPopupGridPageSize = new Func<SystemPreferences, int?>(c => EidssUserContext.User.Options.Prefs.PopupGridPageSize)(obj);
                obj.intDetailGridPageSize = new Func<SystemPreferences, int?>(c => EidssUserContext.User.Options.Prefs.DetailGridPageSize)(obj);
                obj.intLabSectionPageSize = new Func<SystemPreferences, int?>(c => EidssUserContext.User.Options.Prefs.LabSectionPageSize)(obj);
                obj.intDefaultDays = new Func<SystemPreferences, int?>(c => EidssUserContext.User.Options.Prefs.DefaultDays)(obj);
                obj.blnDefaultRegion = new Func<SystemPreferences, bool?>(c => EidssUserContext.User.Options.Prefs.DefaultRegion)(obj);
                obj.blnFilterByDiagnosis = new Func<SystemPreferences, bool?>(c => EidssUserContext.User.Options.Prefs.FilterByDiagnosis)(obj);
                obj.blnPrintMapInVetInvestigationForm = new Func<SystemPreferences, bool?>(c => EidssUserContext.User.Options.Prefs.PrintMapInVetInvestigationForm)(obj);
                obj.blnShowWharningForFinalCaseDefinition = new Func<SystemPreferences, bool?>(c => EidssUserContext.User.Options.Prefs.ShowWharningForFinalCaseDefinition)(obj);
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, SystemPreferences obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private SystemPreferences _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                SystemPreferences obj = null;
                try
                {
                    obj = SystemPreferences.CreateInstance();
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

            
            public SystemPreferences CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public SystemPreferences CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public SystemPreferences CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult Save(DbManagerProxy manager, SystemPreferences obj, List<object> pars)
            {
                
                return Save(manager, obj
                    );
            }
            public ActResult Save(DbManagerProxy manager, SystemPreferences obj
                )
            {
                
              EidssUserContext.User.Options.Prefs.ListGridPageSize = obj.intListGridPageSize.Value;
              EidssUserContext.User.Options.Prefs.PopupGridPageSize = obj.intPopupGridPageSize.Value;
              EidssUserContext.User.Options.Prefs.DetailGridPageSize = obj.intDetailGridPageSize.Value;
              EidssUserContext.User.Options.Prefs.LabSectionPageSize = obj.intLabSectionPageSize.Value;
              EidssUserContext.User.Options.Prefs.DefaultDays = obj.intDefaultDays.Value;
              EidssUserContext.User.Options.Prefs.DefaultRegion = obj.blnDefaultRegion.Value;
              EidssUserContext.User.Options.Prefs.FilterByDiagnosis = obj.blnFilterByDiagnosis.Value;
              EidssUserContext.User.Options.Prefs.PrintMapInVetInvestigationForm = obj.blnPrintMapInVetInvestigationForm.Value;
              EidssUserContext.User.Options.Prefs.ShowWharningForFinalCaseDefinition = obj.blnShowWharningForFinalCaseDefinition.Value;
              return true;
            
            }
            
      
            public ActResult ToDefault(DbManagerProxy manager, SystemPreferences obj, List<object> pars)
            {
                
                return ToDefault(manager, obj
                    );
            }
            public ActResult ToDefault(DbManagerProxy manager, SystemPreferences obj
                )
            {
                
              obj.intListGridPageSize = BaseSettings.ListGridPageSize;
              obj.intPopupGridPageSize = BaseSettings.PopupGridPageSize;
              obj.intDetailGridPageSize = BaseSettings.DetailGridPageSize;
              obj.intLabSectionPageSize = BaseSettings.LabSectionPageSize;
              obj.intDefaultDays = BaseSettings.DefaultDateFilter;
              obj.blnDefaultRegion = BaseSettings.DefaultRegionInSearch;
              obj.blnFilterByDiagnosis = false;
              obj.blnPrintMapInVetInvestigationForm = false;
              obj.blnShowWharningForFinalCaseDefinition = false;
              return true;
            
            }
            
      
            private void _SetupChildHandlers(SystemPreferences obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(SystemPreferences obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, SystemPreferences obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(SystemPreferences obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(SystemPreferences obj, bool bRethrowException)
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
                return Validate(manager, obj as SystemPreferences, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, SystemPreferences obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "intListGridPageSize", "intListGridPageSize","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.intListGridPageSize);
            
                (new RequiredValidator( "intPopupGridPageSize", "intPopupGridPageSize","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.intPopupGridPageSize);
            
                (new RequiredValidator( "intDetailGridPageSize", "intDetailGridPageSize","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.intDetailGridPageSize);
            
                (new RequiredValidator( "intLabSectionPageSize", "intLabSectionPageSize","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.intLabSectionPageSize);
            
                (new RequiredValidator( "intDefaultDays", "intDefaultDays","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.intDefaultDays);
            
                  
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
           
    
            private void _SetupRequired(SystemPreferences obj)
            {
            
                obj
                    .AddRequired("intListGridPageSize", c => true);
                    
                obj
                    .AddRequired("intPopupGridPageSize", c => true);
                    
                obj
                    .AddRequired("intDetailGridPageSize", c => true);
                    
                obj
                    .AddRequired("intLabSectionPageSize", c => true);
                    
                obj
                    .AddRequired("intDefaultDays", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(SystemPreferences obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as SystemPreferences) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as SystemPreferences) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "SystemPreferencesDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spSystemPreferences_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<SystemPreferences, bool>> RequiredByField = new Dictionary<string, Func<SystemPreferences, bool>>();
            public static Dictionary<string, Func<SystemPreferences, bool>> RequiredByProperty = new Dictionary<string, Func<SystemPreferences, bool>>();
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
                
                if (!RequiredByField.ContainsKey("intListGridPageSize")) RequiredByField.Add("intListGridPageSize", c => true);
                if (!RequiredByProperty.ContainsKey("intListGridPageSize")) RequiredByProperty.Add("intListGridPageSize", c => true);
                
                if (!RequiredByField.ContainsKey("intPopupGridPageSize")) RequiredByField.Add("intPopupGridPageSize", c => true);
                if (!RequiredByProperty.ContainsKey("intPopupGridPageSize")) RequiredByProperty.Add("intPopupGridPageSize", c => true);
                
                if (!RequiredByField.ContainsKey("intDetailGridPageSize")) RequiredByField.Add("intDetailGridPageSize", c => true);
                if (!RequiredByProperty.ContainsKey("intDetailGridPageSize")) RequiredByProperty.Add("intDetailGridPageSize", c => true);
                
                if (!RequiredByField.ContainsKey("intLabSectionPageSize")) RequiredByField.Add("intLabSectionPageSize", c => true);
                if (!RequiredByProperty.ContainsKey("intLabSectionPageSize")) RequiredByProperty.Add("intLabSectionPageSize", c => true);
                
                if (!RequiredByField.ContainsKey("intDefaultDays")) RequiredByField.Add("intDefaultDays", c => true);
                if (!RequiredByProperty.ContainsKey("intDefaultDays")) RequiredByProperty.Add("intDefaultDays", c => true);
                
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).Save(manager, (SystemPreferences)c, pars),
                        
                    null,
                    
                    null,
                      false,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "ToDefault",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ToDefault(manager, (SystemPreferences)c, pars),
                        
                    null,
                    
                    null,
                      false,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<SystemPreferences>().Post(manager, (SystemPreferences)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<SystemPreferences>().Post(manager, (SystemPreferences)c), c),
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
                    (manager, c, pars) => new ActResult(((SystemPreferences)c).MarkToDelete() && ObjectAccessor.PostInterface<SystemPreferences>().Post(manager, (SystemPreferences)c), c),
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
	