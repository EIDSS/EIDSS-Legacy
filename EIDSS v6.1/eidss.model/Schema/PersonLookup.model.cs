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
    public abstract partial class PersonLookup : 
        EditableObject<PersonLookup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfPerson), NonUpdatable, PrimaryKey]
        public abstract Int64 idfPerson { get; set; }
                
        [LocalizedDisplayName(_str_FullName)]
        [MapField(_str_FullName)]
        public abstract String FullName { get; set; }
        protected String FullName_Original { get { return ((EditableValue<String>)((dynamic)this)._fullName).OriginalValue; } }
        protected String FullName_Previous { get { return ((EditableValue<String>)((dynamic)this)._fullName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFamilyName)]
        [MapField(_str_strFamilyName)]
        public abstract String strFamilyName { get; set; }
        protected String strFamilyName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFamilyName).OriginalValue; } }
        protected String strFamilyName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFamilyName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFirstName)]
        [MapField(_str_strFirstName)]
        public abstract String strFirstName { get; set; }
        protected String strFirstName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).OriginalValue; } }
        protected String strFirstName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_Organization)]
        [MapField(_str_Organization)]
        public abstract String Organization { get; set; }
        protected String Organization_Original { get { return ((EditableValue<String>)((dynamic)this)._organization).OriginalValue; } }
        protected String Organization_Previous { get { return ((EditableValue<String>)((dynamic)this)._organization).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfOffice)]
        [MapField(_str_idfOffice)]
        public abstract Int64? idfOffice { get; set; }
        protected Int64? idfOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOffice).OriginalValue; } }
        protected Int64? idfOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_Position)]
        [MapField(_str_Position)]
        public abstract String Position { get; set; }
        protected String Position_Original { get { return ((EditableValue<String>)((dynamic)this)._position).OriginalValue; } }
        protected String Position_Previous { get { return ((EditableValue<String>)((dynamic)this)._position).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intRowStatus)]
        [MapField(_str_intRowStatus)]
        public abstract Int32 intRowStatus { get; set; }
        protected Int32 intRowStatus_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).OriginalValue; } }
        protected Int32 intRowStatus_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int32? intHACode { get; set; }
        protected Int32? intHACode_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32? intHACode_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnHuman)]
        [MapField(_str_blnHuman)]
        public abstract Boolean? blnHuman { get; set; }
        protected Boolean? blnHuman_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnHuman).OriginalValue; } }
        protected Boolean? blnHuman_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnHuman).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnVet)]
        [MapField(_str_blnVet)]
        public abstract Boolean? blnVet { get; set; }
        protected Boolean? blnVet_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnVet).OriginalValue; } }
        protected Boolean? blnVet_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnVet).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnLivestock)]
        [MapField(_str_blnLivestock)]
        public abstract Boolean? blnLivestock { get; set; }
        protected Boolean? blnLivestock_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnLivestock).OriginalValue; } }
        protected Boolean? blnLivestock_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnLivestock).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnAvian)]
        [MapField(_str_blnAvian)]
        public abstract Boolean? blnAvian { get; set; }
        protected Boolean? blnAvian_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnAvian).OriginalValue; } }
        protected Boolean? blnAvian_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnAvian).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnVector)]
        [MapField(_str_blnVector)]
        public abstract Boolean? blnVector { get; set; }
        protected Boolean? blnVector_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnVector).OriginalValue; } }
        protected Boolean? blnVector_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnVector).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnSyndromic)]
        [MapField(_str_blnSyndromic)]
        public abstract Boolean? blnSyndromic { get; set; }
        protected Boolean? blnSyndromic_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnSyndromic).OriginalValue; } }
        protected Boolean? blnSyndromic_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnSyndromic).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<PersonLookup, object> _get_func;
            internal Action<PersonLookup, string> _set_func;
            internal Action<PersonLookup, PersonLookup, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfPerson = "idfPerson";
        internal const string _str_FullName = "FullName";
        internal const string _str_strFamilyName = "strFamilyName";
        internal const string _str_strFirstName = "strFirstName";
        internal const string _str_Organization = "Organization";
        internal const string _str_idfOffice = "idfOffice";
        internal const string _str_Position = "Position";
        internal const string _str_intRowStatus = "intRowStatus";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_blnHuman = "blnHuman";
        internal const string _str_blnVet = "blnVet";
        internal const string _str_blnLivestock = "blnLivestock";
        internal const string _str_blnAvian = "blnAvian";
        internal const string _str_blnVector = "blnVector";
        internal const string _str_blnSyndromic = "blnSyndromic";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfPerson, _formname = _str_idfPerson, _type = "Int64",
              _get_func = o => o.idfPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfPerson != newval) o.idfPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfPerson != c.idfPerson || o.IsRIRPropChanged(_str_idfPerson, c)) 
                  m.Add(_str_idfPerson, o.ObjectIdent + _str_idfPerson, o.ObjectIdent2 + _str_idfPerson, o.ObjectIdent3 + _str_idfPerson, "Int64", 
                    o.idfPerson == null ? "" : o.idfPerson.ToString(),                  
                  o.IsReadOnly(_str_idfPerson), o.IsInvisible(_str_idfPerson), o.IsRequired(_str_idfPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_FullName, _formname = _str_FullName, _type = "String",
              _get_func = o => o.FullName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.FullName != newval) o.FullName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.FullName != c.FullName || o.IsRIRPropChanged(_str_FullName, c)) 
                  m.Add(_str_FullName, o.ObjectIdent + _str_FullName, o.ObjectIdent2 + _str_FullName, o.ObjectIdent3 + _str_FullName, "String", 
                    o.FullName == null ? "" : o.FullName.ToString(),                  
                  o.IsReadOnly(_str_FullName), o.IsInvisible(_str_FullName), o.IsRequired(_str_FullName)); 
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
              _name = _str_idfOffice, _formname = _str_idfOffice, _type = "Int64?",
              _get_func = o => o.idfOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfOffice != newval) o.idfOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfOffice != c.idfOffice || o.IsRIRPropChanged(_str_idfOffice, c)) 
                  m.Add(_str_idfOffice, o.ObjectIdent + _str_idfOffice, o.ObjectIdent2 + _str_idfOffice, o.ObjectIdent3 + _str_idfOffice, "Int64?", 
                    o.idfOffice == null ? "" : o.idfOffice.ToString(),                  
                  o.IsReadOnly(_str_idfOffice), o.IsInvisible(_str_idfOffice), o.IsRequired(_str_idfOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Position, _formname = _str_Position, _type = "String",
              _get_func = o => o.Position,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.Position != newval) o.Position = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.Position != c.Position || o.IsRIRPropChanged(_str_Position, c)) 
                  m.Add(_str_Position, o.ObjectIdent + _str_Position, o.ObjectIdent2 + _str_Position, o.ObjectIdent3 + _str_Position, "String", 
                    o.Position == null ? "" : o.Position.ToString(),                  
                  o.IsReadOnly(_str_Position), o.IsInvisible(_str_Position), o.IsRequired(_str_Position)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intRowStatus, _formname = _str_intRowStatus, _type = "Int32",
              _get_func = o => o.intRowStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intRowStatus != newval) o.intRowStatus = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intRowStatus != c.intRowStatus || o.IsRIRPropChanged(_str_intRowStatus, c)) 
                  m.Add(_str_intRowStatus, o.ObjectIdent + _str_intRowStatus, o.ObjectIdent2 + _str_intRowStatus, o.ObjectIdent3 + _str_intRowStatus, "Int32", 
                    o.intRowStatus == null ? "" : o.intRowStatus.ToString(),                  
                  o.IsReadOnly(_str_intRowStatus), o.IsInvisible(_str_intRowStatus), o.IsRequired(_str_intRowStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intHACode, _formname = _str_intHACode, _type = "Int32?",
              _get_func = o => o.intHACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intHACode != newval) o.intHACode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intHACode != c.intHACode || o.IsRIRPropChanged(_str_intHACode, c)) 
                  m.Add(_str_intHACode, o.ObjectIdent + _str_intHACode, o.ObjectIdent2 + _str_intHACode, o.ObjectIdent3 + _str_intHACode, "Int32?", 
                    o.intHACode == null ? "" : o.intHACode.ToString(),                  
                  o.IsReadOnly(_str_intHACode), o.IsInvisible(_str_intHACode), o.IsRequired(_str_intHACode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnHuman, _formname = _str_blnHuman, _type = "Boolean?",
              _get_func = o => o.blnHuman,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnHuman != newval) o.blnHuman = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnHuman != c.blnHuman || o.IsRIRPropChanged(_str_blnHuman, c)) 
                  m.Add(_str_blnHuman, o.ObjectIdent + _str_blnHuman, o.ObjectIdent2 + _str_blnHuman, o.ObjectIdent3 + _str_blnHuman, "Boolean?", 
                    o.blnHuman == null ? "" : o.blnHuman.ToString(),                  
                  o.IsReadOnly(_str_blnHuman), o.IsInvisible(_str_blnHuman), o.IsRequired(_str_blnHuman)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnVet, _formname = _str_blnVet, _type = "Boolean?",
              _get_func = o => o.blnVet,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnVet != newval) o.blnVet = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnVet != c.blnVet || o.IsRIRPropChanged(_str_blnVet, c)) 
                  m.Add(_str_blnVet, o.ObjectIdent + _str_blnVet, o.ObjectIdent2 + _str_blnVet, o.ObjectIdent3 + _str_blnVet, "Boolean?", 
                    o.blnVet == null ? "" : o.blnVet.ToString(),                  
                  o.IsReadOnly(_str_blnVet), o.IsInvisible(_str_blnVet), o.IsRequired(_str_blnVet)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnLivestock, _formname = _str_blnLivestock, _type = "Boolean?",
              _get_func = o => o.blnLivestock,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnLivestock != newval) o.blnLivestock = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnLivestock != c.blnLivestock || o.IsRIRPropChanged(_str_blnLivestock, c)) 
                  m.Add(_str_blnLivestock, o.ObjectIdent + _str_blnLivestock, o.ObjectIdent2 + _str_blnLivestock, o.ObjectIdent3 + _str_blnLivestock, "Boolean?", 
                    o.blnLivestock == null ? "" : o.blnLivestock.ToString(),                  
                  o.IsReadOnly(_str_blnLivestock), o.IsInvisible(_str_blnLivestock), o.IsRequired(_str_blnLivestock)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnAvian, _formname = _str_blnAvian, _type = "Boolean?",
              _get_func = o => o.blnAvian,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnAvian != newval) o.blnAvian = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnAvian != c.blnAvian || o.IsRIRPropChanged(_str_blnAvian, c)) 
                  m.Add(_str_blnAvian, o.ObjectIdent + _str_blnAvian, o.ObjectIdent2 + _str_blnAvian, o.ObjectIdent3 + _str_blnAvian, "Boolean?", 
                    o.blnAvian == null ? "" : o.blnAvian.ToString(),                  
                  o.IsReadOnly(_str_blnAvian), o.IsInvisible(_str_blnAvian), o.IsRequired(_str_blnAvian)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnVector, _formname = _str_blnVector, _type = "Boolean?",
              _get_func = o => o.blnVector,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnVector != newval) o.blnVector = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnVector != c.blnVector || o.IsRIRPropChanged(_str_blnVector, c)) 
                  m.Add(_str_blnVector, o.ObjectIdent + _str_blnVector, o.ObjectIdent2 + _str_blnVector, o.ObjectIdent3 + _str_blnVector, "Boolean?", 
                    o.blnVector == null ? "" : o.blnVector.ToString(),                  
                  o.IsReadOnly(_str_blnVector), o.IsInvisible(_str_blnVector), o.IsRequired(_str_blnVector)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnSyndromic, _formname = _str_blnSyndromic, _type = "Boolean?",
              _get_func = o => o.blnSyndromic,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnSyndromic != newval) o.blnSyndromic = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnSyndromic != c.blnSyndromic || o.IsRIRPropChanged(_str_blnSyndromic, c)) 
                  m.Add(_str_blnSyndromic, o.ObjectIdent + _str_blnSyndromic, o.ObjectIdent2 + _str_blnSyndromic, o.ObjectIdent3 + _str_blnSyndromic, "Boolean?", 
                    o.blnSyndromic == null ? "" : o.blnSyndromic.ToString(),                  
                  o.IsReadOnly(_str_blnSyndromic), o.IsInvisible(_str_blnSyndromic), o.IsRequired(_str_blnSyndromic)); 
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
            PersonLookup obj = (PersonLookup)o;
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
        internal string m_ObjectName = "PersonLookup";

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
            var ret = base.Clone() as PersonLookup;
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
            var ret = base.Clone() as PersonLookup;
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
        public PersonLookup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as PersonLookup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfPerson; } }
        public string KeyName { get { return "idfPerson"; } }
        public object KeyLookup { get { return idfPerson; } }
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

        private bool IsRIRPropChanged(string fld, PersonLookup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, PersonLookup c)
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
        

      
        public override string ToString()
        {
            return new Func<PersonLookup, string>(c => c.FullName)(this);
        }
        

        public PersonLookup()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(PersonLookup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(PersonLookup_PropertyChanged);
        }
        private void PersonLookup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as PersonLookup).Changed(e.PropertyName);
            
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
            PersonLookup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            PersonLookup obj = this;
            
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


        internal Dictionary<string, Func<PersonLookup, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<PersonLookup, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<PersonLookup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<PersonLookup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<PersonLookup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<PersonLookup, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<PersonLookup, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~PersonLookup()
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
        : DataAccessor<PersonLookup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<PersonLookup>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfPerson"; } }
            #endregion
        
            public delegate void on_action(PersonLookup obj);
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
            
            public virtual List<PersonLookup> SelectLookupList(DbManagerProxy manager
                , Int64? OfficeID
                , Int64? ID
                , Boolean ShowUsersOnly
                , Int32? intHACode
                )
            {
                return _SelectList(manager
                    , OfficeID
                    , ID
                    , ShowUsersOnly
                    , intHACode
                    , null, null
                    );
            }
            
            public static string GetLookupTableName(string method)
            {
                return "Person";
            }
            
            public virtual List<PersonLookup> SelectList(DbManagerProxy manager
                , Int64? OfficeID
                , Int64? ID
                , Boolean ShowUsersOnly
                , Int32? intHACode
                )
            {
                return _SelectList(manager
                    , OfficeID
                    , ID
                    , ShowUsersOnly
                    , intHACode
                    , delegate(PersonLookup obj)
                        {
                        }
                    , delegate(PersonLookup obj)
                        {
                        }
                    );
            }

            

            public List<PersonLookup> _SelectList(DbManagerProxy manager
                , Int64? OfficeID
                , Int64? ID
                , Boolean ShowUsersOnly
                , Int32? intHACode
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , OfficeID
                    , ID
                    , ShowUsersOnly
                    , intHACode
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            [InstanceCache(typeof(BvCacheAspect))]
            public virtual List<PersonLookup> _SelectListInternal(DbManagerProxy manager
                , Int64? OfficeID
                , Int64? ID
                , Boolean ShowUsersOnly
                , Int32? intHACode
                , on_action loading, on_action loaded
                )
            {
                PersonLookup _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<PersonLookup> objs = new List<PersonLookup>();
                    sets[0] = new MapResultSet(typeof(PersonLookup), objs);
                    
                    manager
                        .SetSpCommand("spPerson_SelectLookup"
                            , manager.Parameter("@OfficeID", OfficeID)
                            , manager.Parameter("@ID", ID)
                            , manager.Parameter("@ShowUsersOnly", ShowUsersOnly)
                            , manager.Parameter("@intHACode", intHACode)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, PersonLookup obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, PersonLookup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private PersonLookup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                PersonLookup obj = null;
                try
                {
                    obj = PersonLookup.CreateInstance();
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

            
            public PersonLookup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public PersonLookup CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public PersonLookup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(PersonLookup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(PersonLookup obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, PersonLookup obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(PersonLookup obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(PersonLookup obj, bool bRethrowException)
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
                return Validate(manager, obj as PersonLookup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, PersonLookup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(PersonLookup obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(PersonLookup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as PersonLookup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as PersonLookup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "PersonLookupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spPerson_SelectLookup";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<PersonLookup, bool>> RequiredByField = new Dictionary<string, Func<PersonLookup, bool>>();
            public static Dictionary<string, Func<PersonLookup, bool>> RequiredByProperty = new Dictionary<string, Func<PersonLookup, bool>>();
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
                
                Sizes.Add(_str_FullName, 400);
                Sizes.Add(_str_strFamilyName, 200);
                Sizes.Add(_str_strFirstName, 200);
                Sizes.Add(_str_Organization, 2000);
                Sizes.Add(_str_Position, 2000);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<PersonLookup>().Post(manager, (PersonLookup)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<PersonLookup>().Post(manager, (PersonLookup)c), c),
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
                    (manager, c, pars) => new ActResult(((PersonLookup)c).MarkToDelete() && ObjectAccessor.PostInterface<PersonLookup>().Post(manager, (PersonLookup)c), c),
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
	