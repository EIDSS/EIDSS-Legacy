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
    public abstract partial class PersonListItem : 
        EditableObject<PersonListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfEmployee), NonUpdatable, PrimaryKey]
        public abstract Int64 idfEmployee { get; set; }
                
        [LocalizedDisplayName(_str_strFirstName)]
        [MapField(_str_strFirstName)]
        public abstract String strFirstName { get; set; }
        protected String strFirstName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).OriginalValue; } }
        protected String strFirstName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSecondName)]
        [MapField(_str_strSecondName)]
        public abstract String strSecondName { get; set; }
        protected String strSecondName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSecondName).OriginalValue; } }
        protected String strSecondName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSecondName).PreviousValue; } }
                
        [LocalizedDisplayName("strLastName")]
        [MapField(_str_strFamilyName)]
        public abstract String strFamilyName { get; set; }
        protected String strFamilyName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFamilyName).OriginalValue; } }
        protected String strFamilyName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFamilyName).PreviousValue; } }
                
        [LocalizedDisplayName("Abbreviation")]
        [MapField(_str_Organization)]
        public abstract String Organization { get; set; }
        protected String Organization_Original { get { return ((EditableValue<String>)((dynamic)this)._organization).OriginalValue; } }
        protected String Organization_Previous { get { return ((EditableValue<String>)((dynamic)this)._organization).PreviousValue; } }
                
        [LocalizedDisplayName("Organization.Name")]
        [MapField(_str_OrganizationFullName)]
        public abstract String OrganizationFullName { get; set; }
        protected String OrganizationFullName_Original { get { return ((EditableValue<String>)((dynamic)this)._organizationFullName).OriginalValue; } }
        protected String OrganizationFullName_Previous { get { return ((EditableValue<String>)((dynamic)this)._organizationFullName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strOrganizationID)]
        [MapField(_str_strOrganizationID)]
        public abstract String strOrganizationID { get; set; }
        protected String strOrganizationID_Original { get { return ((EditableValue<String>)((dynamic)this)._strOrganizationID).OriginalValue; } }
        protected String strOrganizationID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOrganizationID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfInstitution)]
        [MapField(_str_idfInstitution)]
        public abstract Int64? idfInstitution { get; set; }
        protected Int64? idfInstitution_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInstitution).OriginalValue; } }
        protected Int64? idfInstitution_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInstitution).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRankName)]
        [MapField(_str_strRankName)]
        public abstract String strRankName { get; set; }
        protected String strRankName_Original { get { return ((EditableValue<String>)((dynamic)this)._strRankName).OriginalValue; } }
        protected String strRankName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRankName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfRankName)]
        [MapField(_str_idfRankName)]
        public abstract Int64? idfRankName { get; set; }
        protected Int64? idfRankName_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRankName).OriginalValue; } }
        protected Int64? idfRankName_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRankName).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<PersonListItem, object> _get_func;
            internal Action<PersonListItem, string> _set_func;
            internal Action<PersonListItem, PersonListItem, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfEmployee = "idfEmployee";
        internal const string _str_strFirstName = "strFirstName";
        internal const string _str_strSecondName = "strSecondName";
        internal const string _str_strFamilyName = "strFamilyName";
        internal const string _str_Organization = "Organization";
        internal const string _str_OrganizationFullName = "OrganizationFullName";
        internal const string _str_strOrganizationID = "strOrganizationID";
        internal const string _str_idfInstitution = "idfInstitution";
        internal const string _str_strRankName = "strRankName";
        internal const string _str_idfRankName = "idfRankName";
        internal const string _str_Institution = "Institution";
        internal const string _str_Position = "Position";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfEmployee, _formname = _str_idfEmployee, _type = "Int64",
              _get_func = o => o.idfEmployee,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfEmployee != newval) o.idfEmployee = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfEmployee != c.idfEmployee || o.IsRIRPropChanged(_str_idfEmployee, c)) 
                  m.Add(_str_idfEmployee, o.ObjectIdent + _str_idfEmployee, o.ObjectIdent2 + _str_idfEmployee, o.ObjectIdent3 + _str_idfEmployee, "Int64", 
                    o.idfEmployee == null ? "" : o.idfEmployee.ToString(),                  
                  o.IsReadOnly(_str_idfEmployee), o.IsInvisible(_str_idfEmployee), o.IsRequired(_str_idfEmployee)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFirstName, _formname = _str_strFirstName, _type = "String",
              _get_func = o => o.strFirstName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFirstName != newval) o.strFirstName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFirstName != c.strFirstName || o.IsRIRPropChanged(_str_strFirstName, c)) 
                  m.Add(_str_strFirstName, o.ObjectIdent + _str_strFirstName, o.ObjectIdent2 + _str_strFirstName, o.ObjectIdent3 + _str_strFirstName, "String", 
                    o.strFirstName == null ? "" : o.strFirstName.ToString(),                  
                  o.IsReadOnly(_str_strFirstName), o.IsInvisible(_str_strFirstName), o.IsRequired(_str_strFirstName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSecondName, _formname = _str_strSecondName, _type = "String",
              _get_func = o => o.strSecondName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSecondName != newval) o.strSecondName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSecondName != c.strSecondName || o.IsRIRPropChanged(_str_strSecondName, c)) 
                  m.Add(_str_strSecondName, o.ObjectIdent + _str_strSecondName, o.ObjectIdent2 + _str_strSecondName, o.ObjectIdent3 + _str_strSecondName, "String", 
                    o.strSecondName == null ? "" : o.strSecondName.ToString(),                  
                  o.IsReadOnly(_str_strSecondName), o.IsInvisible(_str_strSecondName), o.IsRequired(_str_strSecondName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFamilyName, _formname = _str_strFamilyName, _type = "String",
              _get_func = o => o.strFamilyName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFamilyName != newval) o.strFamilyName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFamilyName != c.strFamilyName || o.IsRIRPropChanged(_str_strFamilyName, c)) 
                  m.Add(_str_strFamilyName, o.ObjectIdent + _str_strFamilyName, o.ObjectIdent2 + _str_strFamilyName, o.ObjectIdent3 + _str_strFamilyName, "String", 
                    o.strFamilyName == null ? "" : o.strFamilyName.ToString(),                  
                  o.IsReadOnly(_str_strFamilyName), o.IsInvisible(_str_strFamilyName), o.IsRequired(_str_strFamilyName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Organization, _formname = _str_Organization, _type = "String",
              _get_func = o => o.Organization,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.Organization != newval) o.Organization = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.Organization != c.Organization || o.IsRIRPropChanged(_str_Organization, c)) 
                  m.Add(_str_Organization, o.ObjectIdent + _str_Organization, o.ObjectIdent2 + _str_Organization, o.ObjectIdent3 + _str_Organization, "String", 
                    o.Organization == null ? "" : o.Organization.ToString(),                  
                  o.IsReadOnly(_str_Organization), o.IsInvisible(_str_Organization), o.IsRequired(_str_Organization)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_OrganizationFullName, _formname = _str_OrganizationFullName, _type = "String",
              _get_func = o => o.OrganizationFullName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.OrganizationFullName != newval) o.OrganizationFullName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.OrganizationFullName != c.OrganizationFullName || o.IsRIRPropChanged(_str_OrganizationFullName, c)) 
                  m.Add(_str_OrganizationFullName, o.ObjectIdent + _str_OrganizationFullName, o.ObjectIdent2 + _str_OrganizationFullName, o.ObjectIdent3 + _str_OrganizationFullName, "String", 
                    o.OrganizationFullName == null ? "" : o.OrganizationFullName.ToString(),                  
                  o.IsReadOnly(_str_OrganizationFullName), o.IsInvisible(_str_OrganizationFullName), o.IsRequired(_str_OrganizationFullName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strOrganizationID, _formname = _str_strOrganizationID, _type = "String",
              _get_func = o => o.strOrganizationID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOrganizationID != newval) o.strOrganizationID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strOrganizationID != c.strOrganizationID || o.IsRIRPropChanged(_str_strOrganizationID, c)) 
                  m.Add(_str_strOrganizationID, o.ObjectIdent + _str_strOrganizationID, o.ObjectIdent2 + _str_strOrganizationID, o.ObjectIdent3 + _str_strOrganizationID, "String", 
                    o.strOrganizationID == null ? "" : o.strOrganizationID.ToString(),                  
                  o.IsReadOnly(_str_strOrganizationID), o.IsInvisible(_str_strOrganizationID), o.IsRequired(_str_strOrganizationID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfInstitution, _formname = _str_idfInstitution, _type = "Int64?",
              _get_func = o => o.idfInstitution,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfInstitution != newval) 
                  o.Institution = o.InstitutionLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfInstitution != newval) o.idfInstitution = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfInstitution != c.idfInstitution || o.IsRIRPropChanged(_str_idfInstitution, c)) 
                  m.Add(_str_idfInstitution, o.ObjectIdent + _str_idfInstitution, o.ObjectIdent2 + _str_idfInstitution, o.ObjectIdent3 + _str_idfInstitution, "Int64?", 
                    o.idfInstitution == null ? "" : o.idfInstitution.ToString(),                  
                  o.IsReadOnly(_str_idfInstitution), o.IsInvisible(_str_idfInstitution), o.IsRequired(_str_idfInstitution)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRankName, _formname = _str_strRankName, _type = "String",
              _get_func = o => o.strRankName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRankName != newval) o.strRankName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strRankName != c.strRankName || o.IsRIRPropChanged(_str_strRankName, c)) 
                  m.Add(_str_strRankName, o.ObjectIdent + _str_strRankName, o.ObjectIdent2 + _str_strRankName, o.ObjectIdent3 + _str_strRankName, "String", 
                    o.strRankName == null ? "" : o.strRankName.ToString(),                  
                  o.IsReadOnly(_str_strRankName), o.IsInvisible(_str_strRankName), o.IsRequired(_str_strRankName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfRankName, _formname = _str_idfRankName, _type = "Int64?",
              _get_func = o => o.idfRankName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfRankName != newval) 
                  o.Position = o.PositionLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfRankName != newval) o.idfRankName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfRankName != c.idfRankName || o.IsRIRPropChanged(_str_idfRankName, c)) 
                  m.Add(_str_idfRankName, o.ObjectIdent + _str_idfRankName, o.ObjectIdent2 + _str_idfRankName, o.ObjectIdent3 + _str_idfRankName, "Int64?", 
                    o.idfRankName == null ? "" : o.idfRankName.ToString(),                  
                  o.IsReadOnly(_str_idfRankName), o.IsInvisible(_str_idfRankName), o.IsRequired(_str_idfRankName)); 
                  }
              }, 
        
            new field_info {
              _name = _str_Institution, _formname = _str_Institution, _type = "Lookup",
              _get_func = o => { if (o.Institution == null) return null; return o.Institution.idfInstitution; },
              _set_func = (o, val) => { o.Institution = o.InstitutionLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Institution, c);
                if (o.idfInstitution != c.idfInstitution || o.IsRIRPropChanged(_str_Institution, c) || bChangeLookupContent) {
                  m.Add(_str_Institution, o.ObjectIdent + _str_Institution, o.ObjectIdent2 + _str_Institution, o.ObjectIdent3 + _str_Institution, "Lookup", o.idfInstitution == null ? "" : o.idfInstitution.ToString(), o.IsReadOnly(_str_Institution), o.IsInvisible(_str_Institution), o.IsRequired(_str_Institution),
                  bChangeLookupContent ? o.InstitutionLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Institution + "Lookup", _formname = _str_Institution + "Lookup", _type = "LookupContent",
              _get_func = o => o.InstitutionLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Position, _formname = _str_Position, _type = "Lookup",
              _get_func = o => { if (o.Position == null) return null; return o.Position.idfsBaseReference; },
              _set_func = (o, val) => { o.Position = o.PositionLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Position, c);
                if (o.idfRankName != c.idfRankName || o.IsRIRPropChanged(_str_Position, c) || bChangeLookupContent) {
                  m.Add(_str_Position, o.ObjectIdent + _str_Position, o.ObjectIdent2 + _str_Position, o.ObjectIdent3 + _str_Position, "Lookup", o.idfRankName == null ? "" : o.idfRankName.ToString(), o.IsReadOnly(_str_Position), o.IsInvisible(_str_Position), o.IsRequired(_str_Position),
                  bChangeLookupContent ? o.PositionLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Position + "Lookup", _formname = _str_Position + "Lookup", _type = "LookupContent",
              _get_func = o => o.PositionLookup,
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
            PersonListItem obj = (PersonListItem)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Institution)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfInstitution)]
        public OrganizationLookup Institution
        {
            get { return _Institution == null ? null : ((long)_Institution.Key == 0 ? null : _Institution); }
            set 
            { 
                var oldVal = _Institution;
                _Institution = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Institution != oldVal)
                {
                    if (idfInstitution != (_Institution == null
                            ? new Int64?()
                            : (Int64?)_Institution.idfInstitution))
                        idfInstitution = _Institution == null 
                            ? new Int64?()
                            : (Int64?)_Institution.idfInstitution; 
                    OnPropertyChanged(_str_Institution); 
                }
            }
        }
        private OrganizationLookup _Institution;

        
        public List<OrganizationLookup> InstitutionLookup
        {
            get { return _InstitutionLookup; }
        }
        private List<OrganizationLookup> _InstitutionLookup = new List<OrganizationLookup>();
            
        [LocalizedDisplayName(_str_Position)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfRankName)]
        public BaseReference Position
        {
            get { return _Position == null ? null : ((long)_Position.Key == 0 ? null : _Position); }
            set 
            { 
                var oldVal = _Position;
                _Position = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Position != oldVal)
                {
                    if (idfRankName != (_Position == null
                            ? new Int64?()
                            : (Int64?)_Position.idfsBaseReference))
                        idfRankName = _Position == null 
                            ? new Int64?()
                            : (Int64?)_Position.idfsBaseReference; 
                    OnPropertyChanged(_str_Position); 
                }
            }
        }
        private BaseReference _Position;

        
        public BaseReferenceList PositionLookup
        {
            get { return _PositionLookup; }
        }
        private BaseReferenceList _PositionLookup = new BaseReferenceList("rftPosition");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Institution:
                    return new BvSelectList(InstitutionLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, Institution, _str_idfInstitution);
            
                case _str_Position:
                    return new BvSelectList(PositionLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Position, _str_idfRankName);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "PersonListItem";

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
            var ret = base.Clone() as PersonListItem;
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
            var ret = base.Clone() as PersonListItem;
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
        public PersonListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as PersonListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfEmployee; } }
        public string KeyName { get { return "idfEmployee"; } }
        public object KeyLookup { get { return idfEmployee; } }
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
        
            var _prev_idfInstitution_Institution = idfInstitution;
            var _prev_idfRankName_Position = idfRankName;
            base.RejectChanges();
        
            if (_prev_idfInstitution_Institution != idfInstitution)
            {
                _Institution = _InstitutionLookup.FirstOrDefault(c => c.idfInstitution == idfInstitution);
            }
            if (_prev_idfRankName_Position != idfRankName)
            {
                _Position = _PositionLookup.FirstOrDefault(c => c.idfsBaseReference == idfRankName);
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

        private bool IsRIRPropChanged(string fld, PersonListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, PersonListItem c)
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
        

      

        public PersonListItem()
        {
            
            m_permissions = new Permissions(this);
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(PersonListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(PersonListItem_PropertyChanged);
        }
        private void PersonListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as PersonListItem).Changed(e.PropertyName);
            
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
            PersonListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            PersonListItem obj = this;
            
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


        internal Dictionary<string, Func<PersonListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<PersonListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<PersonListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<PersonListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<PersonListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<PersonListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<PersonListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~PersonListItem()
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
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("rftPosition", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_Institution(manager, this);
            
            if (lookup_object == "rftPosition")
                _getAccessor().LoadLookup_Position(manager, this);
            
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
        public class PersonListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfEmployee { get; set; }
        
            public String strFamilyName { get; set; }
        
            public String strFirstName { get; set; }
        
            public String strSecondName { get; set; }
        
            public String Organization { get; set; }
        
            public String OrganizationFullName { get; set; }
        
            public String strRankName { get; set; }
        
        }
        public partial class PersonListItemGridModelList : List<PersonListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public PersonListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<PersonListItem>, errMes);
            }
            public PersonListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<PersonListItem>, errMes);
            }
            public PersonListItemGridModelList(long key, IEnumerable<PersonListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public PersonListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<PersonListItem>(), null);
            }
            partial void filter(List<PersonListItem> items);
            private void LoadGridModelList(long key, IEnumerable<PersonListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strFamilyName,_str_strFirstName,_str_strSecondName,_str_Organization,_str_OrganizationFullName,_str_strRankName};
                    
                Hiddens = new List<string> {_str_idfEmployee};
                Keys = new List<string> {_str_idfEmployee};
                Labels = new Dictionary<string, string> {{_str_strFamilyName, "strLastName"},{_str_strFirstName, _str_strFirstName},{_str_strSecondName, _str_strSecondName},{_str_Organization, "Abbreviation"},{_str_OrganizationFullName, "Organization.Name"},{_str_strRankName, _str_strRankName}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                PersonListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<PersonListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new PersonListItemGridModel()
                {
                    ItemKey=c.idfEmployee,strFamilyName=c.strFamilyName,strFirstName=c.strFirstName,strSecondName=c.strSecondName,Organization=c.Organization,OrganizationFullName=c.OrganizationFullName,strRankName=c.strRankName
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
        : DataAccessor<PersonListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<PersonListItem>
            
            , IObjectSelectList
            , IObjectSelectList<PersonListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfEmployee"; } }
            #endregion
        
            public delegate void on_action(PersonListItem obj);
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
            private OrganizationLookup.Accessor InstitutionAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor PositionAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<PersonListItem> SelectListT(DbManagerProxy manager
                , FilterParams filters = null
                , KeyValuePair<string, ListSortDirection>[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager
                , null, null
                , filters
                , sorts
                , serverSort
                );
            }
            public virtual List<IObject> SelectList(DbManagerProxy manager
                , FilterParams filters = null
                , KeyValuePair<string, ListSortDirection>[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager
                , null, null
                , filters
                , sorts
                , serverSort
                ).Cast<IObject>().ToList();
            }
            
            protected virtual List<PersonListItem> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                , FilterParams filters
                , KeyValuePair<string, ListSortDirection>[] sorts
                , bool serverSort = false
                )
            {
                if (filters == null) filters = new FilterParams();
                
                var sql = new StringBuilder();
                string maxtop = BaseSettings.SelectTopMaxCount.ToString();
                sql.Append(@"select ");
                
                sql.Append(@"top ");
                sql.Append(maxtop);
                sql.Append(@" dbo.fn_Person_SelectList.* from dbo.fn_Person_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfEmployee"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfEmployee"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfEmployee") ? " or " : " and ");
                        
                        if (filters.Operation("idfEmployee", i) == "&")
                          sql.AppendFormat("(isnull(fn_Person_SelectList.idfEmployee,0) {0} @idfEmployee_{1} = @idfEmployee_{1})", filters.Operation("idfEmployee", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Person_SelectList.idfEmployee,0) {0} @idfEmployee_{1}", filters.Operation("idfEmployee", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFirstName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFirstName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFirstName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Person_SelectList.strFirstName {0} @strFirstName_{1}", filters.Operation("strFirstName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSecondName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSecondName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSecondName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Person_SelectList.strSecondName {0} @strSecondName_{1}", filters.Operation("strSecondName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFamilyName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFamilyName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFamilyName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Person_SelectList.strFamilyName {0} @strFamilyName_{1}", filters.Operation("strFamilyName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("Organization"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("Organization"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("Organization") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Person_SelectList.Organization {0} @Organization_{1}", filters.Operation("Organization", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("OrganizationFullName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("OrganizationFullName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("OrganizationFullName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Person_SelectList.OrganizationFullName {0} @OrganizationFullName_{1}", filters.Operation("OrganizationFullName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strOrganizationID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strOrganizationID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strOrganizationID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Person_SelectList.strOrganizationID {0} @strOrganizationID_{1}", filters.Operation("strOrganizationID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfInstitution"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfInstitution"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfInstitution") ? " or " : " and ");
                        
                        if (filters.Operation("idfInstitution", i) == "&")
                          sql.AppendFormat("(isnull(fn_Person_SelectList.idfInstitution,0) {0} @idfInstitution_{1} = @idfInstitution_{1})", filters.Operation("idfInstitution", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Person_SelectList.idfInstitution,0) {0} @idfInstitution_{1}", filters.Operation("idfInstitution", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strRankName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strRankName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strRankName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Person_SelectList.strRankName {0} @strRankName_{1}", filters.Operation("strRankName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfRankName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfRankName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfRankName") ? " or " : " and ");
                        
                        if (filters.Operation("idfRankName", i) == "&")
                          sql.AppendFormat("(isnull(fn_Person_SelectList.idfRankName,0) {0} @idfRankName_{1} = @idfRankName_{1})", filters.Operation("idfRankName", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Person_SelectList.idfRankName,0) {0} @idfRankName_{1}", filters.Operation("idfRankName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (serverSort && sorts != null && sorts.Length > 0)
                {
                    sql.Append(" order by");
                    bool bFirst = true;
                        foreach(var sort in sorts)
                        {
                            sql.Append((bFirst ? " " : ", ") + sort.Key + " " + (sort.Value == ListSortDirection.Ascending ? "ASC" : "DESC"));
                            bFirst = false;
                        }
                }
                  

                bool bTransactionStarted = false;
                try
                {
                    if (!manager.IsTransactionStarted)
                    {
                        bTransactionStarted = true;
                        manager.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                    }
                    
                    sql.Append(" option (OPTIMIZE FOR UNKNOWN)");
                    manager
                        .SetCommand(sql.ToString()
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                        );
                    
                    if (filters.Contains("idfInstitution"))
                        
                        if (filters.Count("idfInstitution") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfInstitution", ParsingHelper.CorrectLikeValue(filters.Operation("idfInstitution"), filters.Value("idfInstitution"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfInstitution"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfInstitution_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfInstitution", i), filters.Value("idfInstitution", i))));
                        }
                            
                    if (filters.Contains("idfEmployee"))
                        for (int i = 0; i < filters.Count("idfEmployee"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfEmployee_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfEmployee", i), filters.Value("idfEmployee", i))));
                      
                    if (filters.Contains("strFirstName"))
                        for (int i = 0; i < filters.Count("strFirstName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFirstName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFirstName", i), filters.Value("strFirstName", i))));
                      
                    if (filters.Contains("strSecondName"))
                        for (int i = 0; i < filters.Count("strSecondName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSecondName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSecondName", i), filters.Value("strSecondName", i))));
                      
                    if (filters.Contains("strFamilyName"))
                        for (int i = 0; i < filters.Count("strFamilyName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFamilyName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFamilyName", i), filters.Value("strFamilyName", i))));
                      
                    if (filters.Contains("Organization"))
                        for (int i = 0; i < filters.Count("Organization"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@Organization_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("Organization", i), filters.Value("Organization", i))));
                      
                    if (filters.Contains("OrganizationFullName"))
                        for (int i = 0; i < filters.Count("OrganizationFullName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@OrganizationFullName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("OrganizationFullName", i), filters.Value("OrganizationFullName", i))));
                      
                    if (filters.Contains("strOrganizationID"))
                        for (int i = 0; i < filters.Count("strOrganizationID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strOrganizationID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strOrganizationID", i), filters.Value("strOrganizationID", i))));
                      
                    if (filters.Contains("idfInstitution"))
                        for (int i = 0; i < filters.Count("idfInstitution"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfInstitution_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfInstitution", i), filters.Value("idfInstitution", i))));
                      
                    if (filters.Contains("strRankName"))
                        for (int i = 0; i < filters.Count("strRankName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strRankName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strRankName", i), filters.Value("strRankName", i))));
                      
                    if (filters.Contains("idfRankName"))
                        for (int i = 0; i < filters.Count("idfRankName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfRankName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfRankName", i), filters.Value("idfRankName", i))));
                      
                    List<PersonListItem> objs = manager.ExecuteList<PersonListItem>();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                        
                        // restore default isolation level for pool connection
                        manager.BeginTransaction();
                        manager.TestConnection();
                        manager.CommitTransaction();
                    }
                    ListSelected(manager, objs);
                    return objs;
                }
                catch(DataException e)
                {
                    if (bTransactionStarted)
                    {
                        manager.RollbackTransaction();
                        
                        // restore default isolation level for pool connection
                        manager.BeginTransaction();
                        manager.TestConnection();
                        manager.RollbackTransaction();
                    }
                    throw DbModelException.Create(null, e);
                }
            }
            partial void ListSelected(DbManagerProxy manager, List<PersonListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spPerson_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, PersonListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, PersonListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private PersonListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                PersonListItem obj = null;
                try
                {
                    obj = PersonListItem.CreateInstance();
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

            
            public PersonListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public PersonListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public PersonListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(PersonListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(PersonListItem obj)
            {
                
            }
    
            public void LoadLookup_Institution(DbManagerProxy manager, PersonListItem obj)
            {
                
                obj.InstitutionLookup.Clear();
                
                obj.InstitutionLookup.Add(InstitutionAccessor.CreateNewT(manager, null));
                
                obj.InstitutionLookup.AddRange(InstitutionAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfInstitution))
                    
                    .ToList());
                
                if (obj.idfInstitution != null && obj.idfInstitution != 0)
                {
                    obj.Institution = obj.InstitutionLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfInstitution);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, InstitutionAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Position(DbManagerProxy manager, PersonListItem obj)
            {
                
                obj.PositionLookup.Clear();
                
                obj.PositionLookup.Add(PositionAccessor.CreateNewT(manager, null));
                
                obj.PositionLookup.AddRange(PositionAccessor.rftPosition_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfRankName))
                    
                    .ToList());
                
                if (obj.idfRankName != null && obj.idfRankName != 0)
                {
                    obj.Position = obj.PositionLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfRankName);
                    
                }
              
                LookupManager.AddObject("rftPosition", obj, PositionAccessor.GetType(), "rftPosition_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, PersonListItem obj)
            {
                
                LoadLookup_Institution(manager, obj);
                
                LoadLookup_Position(manager, obj);
                
            }
    
            [SprocName("spPerson_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spPerson_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? idfPerson
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? idfPerson
                )
            {
                
                _postDelete(manager, idfPerson);
                
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
                        PersonListItem bo = obj as PersonListItem;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            if (!CanDelete)
                                throw new PermissionException("Person", "Delete");
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            if (!CanInsert)
                                throw new PermissionException("Person", "Insert");
                        }
                        else if (!bo.IsMarkedToDelete && bo.HasChanges) // update
                        {
                            if (!CanUpdate)
                                throw new PermissionException("Person", "Update");
                        }
                        
                        long mainObject = bo.idfEmployee;
                        
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
                              
                              manager.SetEventParams(false, "Person", new object[] { eventType, null, "Person" });
                              
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
                            
                            eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoEmployee;
                            eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbPerson;
                            manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                            
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as PersonListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, PersonListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfEmployee
                        );
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(PersonListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, PersonListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfEmployee
                            , out result
                            );
                        if (!result) 
                        {
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, ValidationEventType.Error, obj);
                        }
                     }
                }
                catch(ValidationModelException ex)
                {
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                    else
                        obj.m_IsForcedToDelete = true;
                }
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(PersonListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(PersonListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as PersonListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, PersonListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(PersonListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(PersonListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as PersonListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as PersonListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "PersonListItemDetail"; } }
            public string HelpIdWin { get { return "Persons_List"; } }
            public string HelpIdWeb { get { return "Persons_List"; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private PersonListItem m_obj;
            internal Permissions(PersonListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_Person_SelectList";
            public static string spCount = "spPerson_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spPerson_Delete";
            public static string spCanDelete = "spPerson_CanDelete";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<PersonListItem, bool>> RequiredByField = new Dictionary<string, Func<PersonListItem, bool>>();
            public static Dictionary<string, Func<PersonListItem, bool>> RequiredByProperty = new Dictionary<string, Func<PersonListItem, bool>>();
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
                
                Sizes.Add(_str_strFirstName, 200);
                Sizes.Add(_str_strSecondName, 200);
                Sizes.Add(_str_strFamilyName, 200);
                Sizes.Add(_str_Organization, 2000);
                Sizes.Add(_str_OrganizationFullName, 2000);
                Sizes.Add(_str_strOrganizationID, 100);
                Sizes.Add(_str_strRankName, 2000);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfRankName",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strRankName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "PositionLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFamilyName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strLastName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFirstName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strFirstName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strSecondName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strSecondName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfInstitution",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, false, true, false, false, 
                    "idfInstitution",
                    c => (c as PersonListItem).InstitutionLookup.FirstOrDefault(i=>i.idfInstitution == eidss.model.Core.EidssSiteContext.Instance.OrganizationID), null, c => false, false, SearchPanelLocation.Main, true, null, "InstitutionLookup", typeof(OrganizationLookup), (o) => { var c = (OrganizationLookup)o; return c.idfInstitution; }, (o) => { var c = (OrganizationLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strOrganizationID",
                    EditorType.Text,
                    EditorControlWidth.Normal, false, true, false, false, 
                    "strOrganizationID",
                    c => String.Empty, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfEmployee,
                    _str_idfEmployee, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFamilyName,
                    "strLastName", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFirstName,
                    _str_strFirstName, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSecondName,
                    _str_strSecondName, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Organization,
                    "Abbreviation", null, true, true, true, true, true, ListSortDirection.Ascending
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_OrganizationFullName,
                    "Organization.Name", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRankName,
                    _str_strRankName, null, false, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "SelectAll",
                    ActionTypes.SelectAll,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelectAll_Id",
                        "selectall",
                        /*from BvMessages*/"tooltipSelectAll_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSelectAll_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
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
                    "Select",
                    ActionTypes.Select,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelect_Id",
                        "select",
                        /*from BvMessages*/"tooltipSelect_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSelect_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
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
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<Person>().CreateNew(manager, c, pars == null ? null : (int?)pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<Person>().SelectDetail(manager, pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strEdit_Id",
                        "edit",
                        /*from BvMessages*/"tooltipEdit_Id",
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"tooltipEdit_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
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
                    (manager, c, pars) => 
                        {
                            if (c == null)
                            {
                                c = ObjectAccessor.CreatorInterface<PersonListItem>().CreateWithParams(manager, null, pars);
                                ((PersonListItem)c).idfEmployee = (long)pars[0];
                                ((PersonListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((PersonListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<PersonListItem>().Post(manager, (PersonListItem)c), c);
                        }
                                            ,
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
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
                    "Refresh",
                    ActionTypes.Refresh,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strRefresh_Id",
                        "iconRefresh_Id",
                        /*from BvMessages*/"tooltipRefresh_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipRefresh_Id",
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
                    "Close",
                    ActionTypes.Close,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strClose_Id",
                        "Close",
                        /*from BvMessages*/"tooltipClose_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipClose_Id",
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
	