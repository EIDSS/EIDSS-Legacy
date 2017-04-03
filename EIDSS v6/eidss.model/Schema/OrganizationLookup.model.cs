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
    public abstract partial class OrganizationLookup : 
        EditableObject<OrganizationLookup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfInstitution), NonUpdatable, PrimaryKey]
        public abstract Int64 idfInstitution { get; set; }
                
        [LocalizedDisplayName(_str_name)]
        [MapField(_str_name)]
        public abstract String name { get; set; }
        protected String name_Original { get { return ((EditableValue<String>)((dynamic)this)._name).OriginalValue; } }
        protected String name_Previous { get { return ((EditableValue<String>)((dynamic)this)._name).PreviousValue; } }
                
        [LocalizedDisplayName(_str_FullName)]
        [MapField(_str_FullName)]
        public abstract String FullName { get; set; }
        protected String FullName_Original { get { return ((EditableValue<String>)((dynamic)this)._fullName).OriginalValue; } }
        protected String FullName_Previous { get { return ((EditableValue<String>)((dynamic)this)._fullName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsOfficeName)]
        [MapField(_str_idfsOfficeName)]
        public abstract Int64? idfsOfficeName { get; set; }
        protected Int64? idfsOfficeName_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOfficeName).OriginalValue; } }
        protected Int64? idfsOfficeName_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOfficeName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsOfficeAbbreviation)]
        [MapField(_str_idfsOfficeAbbreviation)]
        public abstract Int64? idfsOfficeAbbreviation { get; set; }
        protected Int64? idfsOfficeAbbreviation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOfficeAbbreviation).OriginalValue; } }
        protected Int64? idfsOfficeAbbreviation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOfficeAbbreviation).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int32? intHACode { get; set; }
        protected Int32? intHACode_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32? intHACode_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64? idfsSite { get; set; }
        protected Int64? idfsSite_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64? idfsSite_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSite).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strOrganizationID)]
        [MapField(_str_strOrganizationID)]
        public abstract String strOrganizationID { get; set; }
        protected String strOrganizationID_Original { get { return ((EditableValue<String>)((dynamic)this)._strOrganizationID).OriginalValue; } }
        protected String strOrganizationID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOrganizationID).PreviousValue; } }
                
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
            internal Func<OrganizationLookup, object> _get_func;
            internal Action<OrganizationLookup, string> _set_func;
            internal Action<OrganizationLookup, OrganizationLookup, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfInstitution = "idfInstitution";
        internal const string _str_name = "name";
        internal const string _str_FullName = "FullName";
        internal const string _str_idfsOfficeName = "idfsOfficeName";
        internal const string _str_idfsOfficeAbbreviation = "idfsOfficeAbbreviation";
        internal const string _str_blnHuman = "blnHuman";
        internal const string _str_blnVet = "blnVet";
        internal const string _str_blnLivestock = "blnLivestock";
        internal const string _str_blnAvian = "blnAvian";
        internal const string _str_blnVector = "blnVector";
        internal const string _str_blnSyndromic = "blnSyndromic";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_strOrganizationID = "strOrganizationID";
        internal const string _str_intRowStatus = "intRowStatus";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfInstitution, _formname = _str_idfInstitution, _type = "Int64",
              _get_func = o => o.idfInstitution,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfInstitution != newval) o.idfInstitution = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfInstitution != c.idfInstitution || o.IsRIRPropChanged(_str_idfInstitution, c)) 
                  m.Add(_str_idfInstitution, o.ObjectIdent + _str_idfInstitution, o.ObjectIdent2 + _str_idfInstitution, o.ObjectIdent3 + _str_idfInstitution, "Int64", 
                    o.idfInstitution == null ? "" : o.idfInstitution.ToString(),                  
                  o.IsReadOnly(_str_idfInstitution), o.IsInvisible(_str_idfInstitution), o.IsRequired(_str_idfInstitution)); 
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
              _name = _str_FullName, _formname = _str_FullName, _type = "String",
              _get_func = o => o.FullName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.FullName != newval) o.FullName = newval; },
              _compare_func = (o, c, m) => {
                if (o.FullName != c.FullName || o.IsRIRPropChanged(_str_FullName, c)) 
                  m.Add(_str_FullName, o.ObjectIdent + _str_FullName, o.ObjectIdent2 + _str_FullName, o.ObjectIdent3 + _str_FullName, "String", 
                    o.FullName == null ? "" : o.FullName.ToString(),                  
                  o.IsReadOnly(_str_FullName), o.IsInvisible(_str_FullName), o.IsRequired(_str_FullName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsOfficeName, _formname = _str_idfsOfficeName, _type = "Int64?",
              _get_func = o => o.idfsOfficeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsOfficeName != newval) o.idfsOfficeName = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsOfficeName != c.idfsOfficeName || o.IsRIRPropChanged(_str_idfsOfficeName, c)) 
                  m.Add(_str_idfsOfficeName, o.ObjectIdent + _str_idfsOfficeName, o.ObjectIdent2 + _str_idfsOfficeName, o.ObjectIdent3 + _str_idfsOfficeName, "Int64?", 
                    o.idfsOfficeName == null ? "" : o.idfsOfficeName.ToString(),                  
                  o.IsReadOnly(_str_idfsOfficeName), o.IsInvisible(_str_idfsOfficeName), o.IsRequired(_str_idfsOfficeName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsOfficeAbbreviation, _formname = _str_idfsOfficeAbbreviation, _type = "Int64?",
              _get_func = o => o.idfsOfficeAbbreviation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsOfficeAbbreviation != newval) o.idfsOfficeAbbreviation = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsOfficeAbbreviation != c.idfsOfficeAbbreviation || o.IsRIRPropChanged(_str_idfsOfficeAbbreviation, c)) 
                  m.Add(_str_idfsOfficeAbbreviation, o.ObjectIdent + _str_idfsOfficeAbbreviation, o.ObjectIdent2 + _str_idfsOfficeAbbreviation, o.ObjectIdent3 + _str_idfsOfficeAbbreviation, "Int64?", 
                    o.idfsOfficeAbbreviation == null ? "" : o.idfsOfficeAbbreviation.ToString(),                  
                  o.IsReadOnly(_str_idfsOfficeAbbreviation), o.IsInvisible(_str_idfsOfficeAbbreviation), o.IsRequired(_str_idfsOfficeAbbreviation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnHuman, _formname = _str_blnHuman, _type = "Boolean?",
              _get_func = o => o.blnHuman,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnHuman != newval) o.blnHuman = newval; },
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
                if (o.blnSyndromic != c.blnSyndromic || o.IsRIRPropChanged(_str_blnSyndromic, c)) 
                  m.Add(_str_blnSyndromic, o.ObjectIdent + _str_blnSyndromic, o.ObjectIdent2 + _str_blnSyndromic, o.ObjectIdent3 + _str_blnSyndromic, "Boolean?", 
                    o.blnSyndromic == null ? "" : o.blnSyndromic.ToString(),                  
                  o.IsReadOnly(_str_blnSyndromic), o.IsInvisible(_str_blnSyndromic), o.IsRequired(_str_blnSyndromic)); 
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
              _name = _str_idfsSite, _formname = _str_idfsSite, _type = "Int64?",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSite != newval) o.idfsSite = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_idfsSite, c)) 
                  m.Add(_str_idfsSite, o.ObjectIdent + _str_idfsSite, o.ObjectIdent2 + _str_idfsSite, o.ObjectIdent3 + _str_idfsSite, "Int64?", 
                    o.idfsSite == null ? "" : o.idfsSite.ToString(),                  
                  o.IsReadOnly(_str_idfsSite), o.IsInvisible(_str_idfsSite), o.IsRequired(_str_idfsSite)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strOrganizationID, _formname = _str_strOrganizationID, _type = "String",
              _get_func = o => o.strOrganizationID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOrganizationID != newval) o.strOrganizationID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strOrganizationID != c.strOrganizationID || o.IsRIRPropChanged(_str_strOrganizationID, c)) 
                  m.Add(_str_strOrganizationID, o.ObjectIdent + _str_strOrganizationID, o.ObjectIdent2 + _str_strOrganizationID, o.ObjectIdent3 + _str_strOrganizationID, "String", 
                    o.strOrganizationID == null ? "" : o.strOrganizationID.ToString(),                  
                  o.IsReadOnly(_str_strOrganizationID), o.IsInvisible(_str_strOrganizationID), o.IsRequired(_str_strOrganizationID)); 
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
            OrganizationLookup obj = (OrganizationLookup)o;
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
        internal string m_ObjectName = "OrganizationLookup";

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
            var ret = base.Clone() as OrganizationLookup;
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
            var ret = base.Clone() as OrganizationLookup;
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
        public OrganizationLookup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as OrganizationLookup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfInstitution; } }
        public string KeyName { get { return "idfInstitution"; } }
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

        private bool IsRIRPropChanged(string fld, OrganizationLookup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      
        public override string ToString()
        {
            return new Func<OrganizationLookup, string>(c => c.name)(this);
        }
        

        public OrganizationLookup()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(OrganizationLookup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(OrganizationLookup_PropertyChanged);
        }
        private void OrganizationLookup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as OrganizationLookup).Changed(e.PropertyName);
            
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
            OrganizationLookup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            OrganizationLookup obj = this;
            
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


        internal Dictionary<string, Func<OrganizationLookup, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<OrganizationLookup, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<OrganizationLookup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<OrganizationLookup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<OrganizationLookup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<OrganizationLookup, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<OrganizationLookup, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~OrganizationLookup()
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
        : DataAccessor<OrganizationLookup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<OrganizationLookup>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfInstitution"; } }
            #endregion
        
            private delegate void on_action(OrganizationLookup obj);
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
            [InstanceCache(typeof(BvCacheAspect))]
            public virtual List<OrganizationLookup> SelectLookupList(DbManagerProxy manager
                , Int64? ID
                , Int32? intHACode
                )
            {
                return _SelectList(manager
                    , ID
                    , intHACode
                    , null, null
                    );
            }
            
            public static string GetLookupTableName(string method)
            {
                return "Organization";
            }
            
            public virtual List<OrganizationLookup> SelectList(DbManagerProxy manager
                , Int64? ID
                , Int32? intHACode
                )
            {
                return _SelectList(manager
                    , ID
                    , intHACode
                    , delegate(OrganizationLookup obj)
                        {
                        }
                    , delegate(OrganizationLookup obj)
                        {
                        }
                    );
            }

            
            private List<OrganizationLookup> _SelectList(DbManagerProxy manager
                , Int64? ID
                , Int32? intHACode
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<OrganizationLookup> objs = new List<OrganizationLookup>();
                    sets[0] = new MapResultSet(typeof(OrganizationLookup), objs);
                    
                    manager
                        .SetSpCommand("spOrganization_SelectLookup"
                            , manager.Parameter("@ID", ID)
                            , manager.Parameter("@intHACode", intHACode)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, OrganizationLookup obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, OrganizationLookup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private OrganizationLookup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    OrganizationLookup obj = OrganizationLookup.CreateInstance();
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

            
            public OrganizationLookup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public OrganizationLookup CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public OrganizationLookup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(OrganizationLookup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(OrganizationLookup obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, OrganizationLookup obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(OrganizationLookup obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(OrganizationLookup obj, bool bRethrowException)
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
                return Validate(manager, obj as OrganizationLookup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, OrganizationLookup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(OrganizationLookup obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(OrganizationLookup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as OrganizationLookup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as OrganizationLookup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "OrganizationLookupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spOrganization_SelectLookup";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<OrganizationLookup, bool>> RequiredByField = new Dictionary<string, Func<OrganizationLookup, bool>>();
            public static Dictionary<string, Func<OrganizationLookup, bool>> RequiredByProperty = new Dictionary<string, Func<OrganizationLookup, bool>>();
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
                
                Sizes.Add(_str_name, 2000);
                Sizes.Add(_str_FullName, 2000);
                Sizes.Add(_str_strOrganizationID, 100);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<OrganizationLookup>().Post(manager, (OrganizationLookup)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<OrganizationLookup>().Post(manager, (OrganizationLookup)c), c),
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
                    (manager, c, pars) => new ActResult(((OrganizationLookup)c).MarkToDelete() && ObjectAccessor.PostInterface<OrganizationLookup>().Post(manager, (OrganizationLookup)c), c),
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
	