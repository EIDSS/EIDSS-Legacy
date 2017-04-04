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
    public abstract partial class OrganizationListItem : 
        EditableObject<OrganizationListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfInstitution), NonUpdatable, PrimaryKey]
        public abstract Int64 idfInstitution { get; set; }
                
        [LocalizedDisplayName("Organization.Name")]
        [MapField(_str_FullName)]
        public abstract String FullName { get; set; }
        protected String FullName_Original { get { return ((EditableValue<String>)((dynamic)this)._fullName).OriginalValue; } }
        protected String FullName_Previous { get { return ((EditableValue<String>)((dynamic)this)._fullName).PreviousValue; } }
                
        [LocalizedDisplayName("Abbreviation")]
        [MapField(_str_name)]
        public abstract String name { get; set; }
        protected String name_Original { get { return ((EditableValue<String>)((dynamic)this)._name).OriginalValue; } }
        protected String name_Previous { get { return ((EditableValue<String>)((dynamic)this)._name).PreviousValue; } }
                
        [LocalizedDisplayName("Organization.Address")]
        [MapField(_str_Address)]
        public abstract String Address { get; set; }
        protected String Address_Original { get { return ((EditableValue<String>)((dynamic)this)._address).OriginalValue; } }
        protected String Address_Previous { get { return ((EditableValue<String>)((dynamic)this)._address).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int64? intHACode { get; set; }
        protected Int64? intHACode_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int64? intHACode_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._intHACode).PreviousValue; } }
                
        [LocalizedDisplayName("strOrganizationID")]
        [MapField(_str_strOrganizationID)]
        public abstract String strOrganizationID { get; set; }
        protected String strOrganizationID_Original { get { return ((EditableValue<String>)((dynamic)this)._strOrganizationID).OriginalValue; } }
        protected String strOrganizationID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOrganizationID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32? intOrder { get; set; }
        protected Int32? intOrder_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32? intOrder_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<OrganizationListItem, object> _get_func;
            internal Action<OrganizationListItem, string> _set_func;
            internal Action<OrganizationListItem, OrganizationListItem, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfInstitution = "idfInstitution";
        internal const string _str_FullName = "FullName";
        internal const string _str_name = "name";
        internal const string _str_Address = "Address";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_strOrganizationID = "strOrganizationID";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_idfsRegion1 = "idfsRegion1";
        internal const string _str_idfsRayon1 = "idfsRayon1";
        internal const string _str_idfsSettlement1 = "idfsSettlement1";
        internal const string _str_blnForeignAddress = "blnForeignAddress";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Settlement = "Settlement";
        internal const string _str_HACode = "HACode";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfInstitution, _formname = _str_idfInstitution, _type = "Int64",
              _get_func = o => o.idfInstitution,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfInstitution != newval) o.idfInstitution = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfInstitution != c.idfInstitution || o.IsRIRPropChanged(_str_idfInstitution, c)) 
                  m.Add(_str_idfInstitution, o.ObjectIdent + _str_idfInstitution, o.ObjectIdent2 + _str_idfInstitution, o.ObjectIdent3 + _str_idfInstitution, "Int64", 
                    o.idfInstitution == null ? "" : o.idfInstitution.ToString(),                  
                  o.IsReadOnly(_str_idfInstitution), o.IsInvisible(_str_idfInstitution), o.IsRequired(_str_idfInstitution)); 
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
              _name = _str_name, _formname = _str_name, _type = "String",
              _get_func = o => o.name,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.name != newval) o.name = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.name != c.name || o.IsRIRPropChanged(_str_name, c)) 
                  m.Add(_str_name, o.ObjectIdent + _str_name, o.ObjectIdent2 + _str_name, o.ObjectIdent3 + _str_name, "String", 
                    o.name == null ? "" : o.name.ToString(),                  
                  o.IsReadOnly(_str_name), o.IsInvisible(_str_name), o.IsRequired(_str_name)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Address, _formname = _str_Address, _type = "String",
              _get_func = o => o.Address,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.Address != newval) o.Address = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.Address != c.Address || o.IsRIRPropChanged(_str_Address, c)) 
                  m.Add(_str_Address, o.ObjectIdent + _str_Address, o.ObjectIdent2 + _str_Address, o.ObjectIdent3 + _str_Address, "String", 
                    o.Address == null ? "" : o.Address.ToString(),                  
                  o.IsReadOnly(_str_Address), o.IsInvisible(_str_Address), o.IsRequired(_str_Address)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intHACode, _formname = _str_intHACode, _type = "Int64?",
              _get_func = o => o.intHACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.intHACode != newval) 
                  o.HACode = o.HACodeLookup.FirstOrDefault(c => c.intHACode == newval);
                if (o.intHACode != newval) o.intHACode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intHACode != c.intHACode || o.IsRIRPropChanged(_str_intHACode, c)) 
                  m.Add(_str_intHACode, o.ObjectIdent + _str_intHACode, o.ObjectIdent2 + _str_intHACode, o.ObjectIdent3 + _str_intHACode, "Int64?", 
                    o.intHACode == null ? "" : o.intHACode.ToString(),                  
                  o.IsReadOnly(_str_intHACode), o.IsInvisible(_str_intHACode), o.IsRequired(_str_intHACode)); 
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
              _name = _str_intOrder, _formname = _str_intOrder, _type = "Int32?",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intOrder != newval) o.intOrder = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, o.ObjectIdent2 + _str_intOrder, o.ObjectIdent3 + _str_intOrder, "Int32?", 
                    o.intOrder == null ? "" : o.intOrder.ToString(),                  
                  o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); 
                  }
              }, 
        
            new field_info {
              _name = _str_idfsCountry, _formname = _str_idfsCountry, _type = "long?",
              _get_func = o => o.idfsCountry,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsCountry != newval) o.idfsCountry = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_idfsCountry, c)) {
                  m.Add(_str_idfsCountry, o.ObjectIdent + _str_idfsCountry, o.ObjectIdent2 + _str_idfsCountry, o.ObjectIdent3 + _str_idfsCountry,  "long?", 
                    o.idfsCountry == null ? "" : o.idfsCountry.ToString(),                  
                    o.IsReadOnly(_str_idfsCountry), o.IsInvisible(_str_idfsCountry), o.IsRequired(_str_idfsCountry));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsRegion1, _formname = _str_idfsRegion1, _type = "long?",
              _get_func = o => o.idfsRegion1,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsRegion1 != newval) o.idfsRegion1 = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsRegion1 != c.idfsRegion1 || o.IsRIRPropChanged(_str_idfsRegion1, c)) {
                  m.Add(_str_idfsRegion1, o.ObjectIdent + _str_idfsRegion1, o.ObjectIdent2 + _str_idfsRegion1, o.ObjectIdent3 + _str_idfsRegion1,  "long?", 
                    o.idfsRegion1 == null ? "" : o.idfsRegion1.ToString(),                  
                    o.IsReadOnly(_str_idfsRegion1), o.IsInvisible(_str_idfsRegion1), o.IsRequired(_str_idfsRegion1));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsRayon1, _formname = _str_idfsRayon1, _type = "long?",
              _get_func = o => o.idfsRayon1,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsRayon1 != newval) o.idfsRayon1 = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsRayon1 != c.idfsRayon1 || o.IsRIRPropChanged(_str_idfsRayon1, c)) {
                  m.Add(_str_idfsRayon1, o.ObjectIdent + _str_idfsRayon1, o.ObjectIdent2 + _str_idfsRayon1, o.ObjectIdent3 + _str_idfsRayon1,  "long?", 
                    o.idfsRayon1 == null ? "" : o.idfsRayon1.ToString(),                  
                    o.IsReadOnly(_str_idfsRayon1), o.IsInvisible(_str_idfsRayon1), o.IsRequired(_str_idfsRayon1));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsSettlement1, _formname = _str_idfsSettlement1, _type = "long?",
              _get_func = o => o.idfsSettlement1,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSettlement1 != newval) o.idfsSettlement1 = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsSettlement1 != c.idfsSettlement1 || o.IsRIRPropChanged(_str_idfsSettlement1, c)) {
                  m.Add(_str_idfsSettlement1, o.ObjectIdent + _str_idfsSettlement1, o.ObjectIdent2 + _str_idfsSettlement1, o.ObjectIdent3 + _str_idfsSettlement1,  "long?", 
                    o.idfsSettlement1 == null ? "" : o.idfsSettlement1.ToString(),                  
                    o.IsReadOnly(_str_idfsSettlement1), o.IsInvisible(_str_idfsSettlement1), o.IsRequired(_str_idfsSettlement1));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_blnForeignAddress, _formname = _str_blnForeignAddress, _type = "bool?",
              _get_func = o => o.blnForeignAddress,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnForeignAddress != newval) o.blnForeignAddress = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.blnForeignAddress != c.blnForeignAddress || o.IsRIRPropChanged(_str_blnForeignAddress, c)) {
                  m.Add(_str_blnForeignAddress, o.ObjectIdent + _str_blnForeignAddress, o.ObjectIdent2 + _str_blnForeignAddress, o.ObjectIdent3 + _str_blnForeignAddress,  "bool?", 
                    o.blnForeignAddress == null ? "" : o.blnForeignAddress.ToString(),                  
                    o.IsReadOnly(_str_blnForeignAddress), o.IsInvisible(_str_blnForeignAddress), o.IsRequired(_str_blnForeignAddress));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_Country, _formname = _str_Country, _type = "Lookup",
              _get_func = o => { if (o.Country == null) return null; return o.Country.idfsCountry; },
              _set_func = (o, val) => { o.Country = o.CountryLookup.Where(c => c.idfsCountry.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Country, c);
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_Country, c) || bChangeLookupContent) {
                  m.Add(_str_Country, o.ObjectIdent + _str_Country, o.ObjectIdent2 + _str_Country, o.ObjectIdent3 + _str_Country, "Lookup", o.idfsCountry == null ? "" : o.idfsCountry.ToString(), o.IsReadOnly(_str_Country), o.IsInvisible(_str_Country), o.IsRequired(_str_Country),
                  bChangeLookupContent ? o.CountryLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Country + "Lookup", _formname = _str_Country + "Lookup", _type = "LookupContent",
              _get_func = o => o.CountryLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Region, _formname = _str_Region, _type = "Lookup",
              _get_func = o => { if (o.Region == null) return null; return o.Region.idfsRegion; },
              _set_func = (o, val) => { o.Region = o.RegionLookup.Where(c => c.idfsRegion.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Region, c);
                if (o.idfsRegion1 != c.idfsRegion1 || o.IsRIRPropChanged(_str_Region, c) || bChangeLookupContent) {
                  m.Add(_str_Region, o.ObjectIdent + _str_Region, o.ObjectIdent2 + _str_Region, o.ObjectIdent3 + _str_Region, "Lookup", o.idfsRegion1 == null ? "" : o.idfsRegion1.ToString(), o.IsReadOnly(_str_Region), o.IsInvisible(_str_Region), o.IsRequired(_str_Region),
                  bChangeLookupContent ? o.RegionLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Region + "Lookup", _formname = _str_Region + "Lookup", _type = "LookupContent",
              _get_func = o => o.RegionLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Rayon, _formname = _str_Rayon, _type = "Lookup",
              _get_func = o => { if (o.Rayon == null) return null; return o.Rayon.idfsRayon; },
              _set_func = (o, val) => { o.Rayon = o.RayonLookup.Where(c => c.idfsRayon.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Rayon, c);
                if (o.idfsRayon1 != c.idfsRayon1 || o.IsRIRPropChanged(_str_Rayon, c) || bChangeLookupContent) {
                  m.Add(_str_Rayon, o.ObjectIdent + _str_Rayon, o.ObjectIdent2 + _str_Rayon, o.ObjectIdent3 + _str_Rayon, "Lookup", o.idfsRayon1 == null ? "" : o.idfsRayon1.ToString(), o.IsReadOnly(_str_Rayon), o.IsInvisible(_str_Rayon), o.IsRequired(_str_Rayon),
                  bChangeLookupContent ? o.RayonLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Rayon + "Lookup", _formname = _str_Rayon + "Lookup", _type = "LookupContent",
              _get_func = o => o.RayonLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Settlement, _formname = _str_Settlement, _type = "Lookup",
              _get_func = o => { if (o.Settlement == null) return null; return o.Settlement.idfsSettlement; },
              _set_func = (o, val) => { o.Settlement = o.SettlementLookup.Where(c => c.idfsSettlement.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Settlement, c);
                if (o.idfsSettlement1 != c.idfsSettlement1 || o.IsRIRPropChanged(_str_Settlement, c) || bChangeLookupContent) {
                  m.Add(_str_Settlement, o.ObjectIdent + _str_Settlement, o.ObjectIdent2 + _str_Settlement, o.ObjectIdent3 + _str_Settlement, "Lookup", o.idfsSettlement1 == null ? "" : o.idfsSettlement1.ToString(), o.IsReadOnly(_str_Settlement), o.IsInvisible(_str_Settlement), o.IsRequired(_str_Settlement),
                  bChangeLookupContent ? o.SettlementLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Settlement + "Lookup", _formname = _str_Settlement + "Lookup", _type = "LookupContent",
              _get_func = o => o.SettlementLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_HACode, _formname = _str_HACode, _type = "Lookup",
              _get_func = o => { if (o.HACode == null) return null; return o.HACode.intHACode; },
              _set_func = (o, val) => { o.HACode = o.HACodeLookup.Where(c => c.intHACode.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_HACode, c);
                if (o.intHACode != c.intHACode || o.IsRIRPropChanged(_str_HACode, c) || bChangeLookupContent) {
                  m.Add(_str_HACode, o.ObjectIdent + _str_HACode, o.ObjectIdent2 + _str_HACode, o.ObjectIdent3 + _str_HACode, "Lookup", o.intHACode == null ? "" : o.intHACode.ToString(), o.IsReadOnly(_str_HACode), o.IsInvisible(_str_HACode), o.IsRequired(_str_HACode),
                  bChangeLookupContent ? o.HACodeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_HACode + "Lookup", _formname = _str_HACode + "Lookup", _type = "LookupContent",
              _get_func = o => o.HACodeLookup,
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
            OrganizationListItem obj = (OrganizationListItem)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Country)]
        [Relation(typeof(CountryLookup), eidss.model.Schema.CountryLookup._str_idfsCountry, _str_idfsCountry)]
        public CountryLookup Country
        {
            get { return _Country == null ? null : ((long)_Country.Key == 0 ? null : _Country); }
            set 
            { 
                var oldVal = _Country;
                _Country = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Country != oldVal)
                {
                    if (idfsCountry != (_Country == null
                            ? new long?()
                            : _Country.idfsCountry))
                        idfsCountry = _Country == null 
                            ? new long?()
                            : _Country.idfsCountry; 
                    OnPropertyChanged(_str_Country); 
                }
            }
        }
        private CountryLookup _Country;

        
        public List<CountryLookup> CountryLookup
        {
            get { return _CountryLookup; }
        }
        private List<CountryLookup> _CountryLookup = new List<CountryLookup>();
            
        [LocalizedDisplayName(_str_Region)]
        [Relation(typeof(RegionLookup), eidss.model.Schema.RegionLookup._str_idfsRegion, _str_idfsRegion1)]
        public RegionLookup Region
        {
            get { return _Region == null ? null : ((long)_Region.Key == 0 ? null : _Region); }
            set 
            { 
                var oldVal = _Region;
                _Region = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Region != oldVal)
                {
                    if (idfsRegion1 != (_Region == null
                            ? new long?()
                            : _Region.idfsRegion))
                        idfsRegion1 = _Region == null 
                            ? new long?()
                            : _Region.idfsRegion; 
                    OnPropertyChanged(_str_Region); 
                }
            }
        }
        private RegionLookup _Region;

        
        public List<RegionLookup> RegionLookup
        {
            get { return _RegionLookup; }
        }
        private List<RegionLookup> _RegionLookup = new List<RegionLookup>();
            
        [LocalizedDisplayName(_str_Rayon)]
        [Relation(typeof(RayonLookup), eidss.model.Schema.RayonLookup._str_idfsRayon, _str_idfsRayon1)]
        public RayonLookup Rayon
        {
            get { return _Rayon == null ? null : ((long)_Rayon.Key == 0 ? null : _Rayon); }
            set 
            { 
                var oldVal = _Rayon;
                _Rayon = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Rayon != oldVal)
                {
                    if (idfsRayon1 != (_Rayon == null
                            ? new long?()
                            : _Rayon.idfsRayon))
                        idfsRayon1 = _Rayon == null 
                            ? new long?()
                            : _Rayon.idfsRayon; 
                    OnPropertyChanged(_str_Rayon); 
                }
            }
        }
        private RayonLookup _Rayon;

        
        public List<RayonLookup> RayonLookup
        {
            get { return _RayonLookup; }
        }
        private List<RayonLookup> _RayonLookup = new List<RayonLookup>();
            
        [LocalizedDisplayName(_str_Settlement)]
        [Relation(typeof(SettlementLookup), eidss.model.Schema.SettlementLookup._str_idfsSettlement, _str_idfsSettlement1)]
        public SettlementLookup Settlement
        {
            get { return _Settlement == null ? null : ((long)_Settlement.Key == 0 ? null : _Settlement); }
            set 
            { 
                var oldVal = _Settlement;
                _Settlement = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Settlement != oldVal)
                {
                    if (idfsSettlement1 != (_Settlement == null
                            ? new long?()
                            : _Settlement.idfsSettlement))
                        idfsSettlement1 = _Settlement == null 
                            ? new long?()
                            : _Settlement.idfsSettlement; 
                    OnPropertyChanged(_str_Settlement); 
                }
            }
        }
        private SettlementLookup _Settlement;

        
        public List<SettlementLookup> SettlementLookup
        {
            get { return _SettlementLookup; }
        }
        private List<SettlementLookup> _SettlementLookup = new List<SettlementLookup>();
            
        [LocalizedDisplayName(_str_HACode)]
        [Relation(typeof(HACodeLookup), eidss.model.Schema.HACodeLookup._str_intHACode, _str_intHACode)]
        public HACodeLookup HACode
        {
            get { return _HACode == null ? null : ((long)_HACode.Key == 0 ? null : _HACode); }
            set 
            { 
                var oldVal = _HACode;
                _HACode = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_HACode != oldVal)
                {
                    if (intHACode != (_HACode == null
                            ? new Int64?()
                            : (Int64?)_HACode.intHACode))
                        intHACode = _HACode == null 
                            ? new Int64?()
                            : (Int64?)_HACode.intHACode; 
                    OnPropertyChanged(_str_HACode); 
                }
            }
        }
        private HACodeLookup _HACode;

        
        public List<HACodeLookup> HACodeLookup
        {
            get { return _HACodeLookup; }
        }
        private List<HACodeLookup> _HACodeLookup = new List<HACodeLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Country:
                    return new BvSelectList(CountryLookup, eidss.model.Schema.CountryLookup._str_idfsCountry, null, Country, _str_idfsCountry);
            
                case _str_Region:
                    return new BvSelectList(RegionLookup, eidss.model.Schema.RegionLookup._str_idfsRegion, null, Region, _str_idfsRegion1);
            
                case _str_Rayon:
                    return new BvSelectList(RayonLookup, eidss.model.Schema.RayonLookup._str_idfsRayon, null, Rayon, _str_idfsRayon1);
            
                case _str_Settlement:
                    return new BvSelectList(SettlementLookup, eidss.model.Schema.SettlementLookup._str_idfsSettlement, null, Settlement, _str_idfsSettlement1);
            
                case _str_HACode:
                    return new BvSelectList(HACodeLookup, eidss.model.Schema.HACodeLookup._str_intHACode, null, HACode, _str_intHACode);
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str_idfsCountry)]
        public long? idfsCountry
        {
            get { return m_idfsCountry; }
            set { if (m_idfsCountry != value) { m_idfsCountry = value; OnPropertyChanged(_str_idfsCountry); } }
        }
        private long? m_idfsCountry;
        
          [LocalizedDisplayName(_str_idfsRegion1)]
        public long? idfsRegion1
        {
            get { return m_idfsRegion1; }
            set { if (m_idfsRegion1 != value) { m_idfsRegion1 = value; OnPropertyChanged(_str_idfsRegion1); } }
        }
        private long? m_idfsRegion1;
        
          [LocalizedDisplayName(_str_idfsRayon1)]
        public long? idfsRayon1
        {
            get { return m_idfsRayon1; }
            set { if (m_idfsRayon1 != value) { m_idfsRayon1 = value; OnPropertyChanged(_str_idfsRayon1); } }
        }
        private long? m_idfsRayon1;
        
          [LocalizedDisplayName(_str_idfsSettlement1)]
        public long? idfsSettlement1
        {
            get { return m_idfsSettlement1; }
            set { if (m_idfsSettlement1 != value) { m_idfsSettlement1 = value; OnPropertyChanged(_str_idfsSettlement1); } }
        }
        private long? m_idfsSettlement1;
        
          [LocalizedDisplayName(_str_blnForeignAddress)]
        public bool? blnForeignAddress
        {
            get { return m_blnForeignAddress; }
            set { if (m_blnForeignAddress != value) { m_blnForeignAddress = value; OnPropertyChanged(_str_blnForeignAddress); } }
        }
        private bool? m_blnForeignAddress;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "OrganizationListItem";

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
            var ret = base.Clone() as OrganizationListItem;
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
            var ret = base.Clone() as OrganizationListItem;
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
        public OrganizationListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as OrganizationListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfInstitution; } }
        public string KeyName { get { return "idfInstitution"; } }
        public object KeyLookup { get { return idfInstitution; } }
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
        
            var _prev_idfsCountry_Country = idfsCountry;
            var _prev_idfsRegion1_Region = idfsRegion1;
            var _prev_idfsRayon1_Rayon = idfsRayon1;
            var _prev_idfsSettlement1_Settlement = idfsSettlement1;
            var _prev_intHACode_HACode = intHACode;
            base.RejectChanges();
        
            if (_prev_idfsCountry_Country != idfsCountry)
            {
                _Country = _CountryLookup.FirstOrDefault(c => c.idfsCountry == idfsCountry);
            }
            if (_prev_idfsRegion1_Region != idfsRegion1)
            {
                _Region = _RegionLookup.FirstOrDefault(c => c.idfsRegion == idfsRegion1);
            }
            if (_prev_idfsRayon1_Rayon != idfsRayon1)
            {
                _Rayon = _RayonLookup.FirstOrDefault(c => c.idfsRayon == idfsRayon1);
            }
            if (_prev_idfsSettlement1_Settlement != idfsSettlement1)
            {
                _Settlement = _SettlementLookup.FirstOrDefault(c => c.idfsSettlement == idfsSettlement1);
            }
            if (_prev_intHACode_HACode != intHACode)
            {
                _HACode = _HACodeLookup.FirstOrDefault(c => c.intHACode == intHACode);
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

        private bool IsRIRPropChanged(string fld, OrganizationListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, OrganizationListItem c)
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
        

      

        public OrganizationListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(OrganizationListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(OrganizationListItem_PropertyChanged);
        }
        private void OrganizationListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as OrganizationListItem).Changed(e.PropertyName);
            
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
            OrganizationListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            OrganizationListItem obj = this;
            
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

    
        private static string[] readonly_names1 = "Region,idfsRegion1".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "Rayon,idfsRayon1".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "Settlement,idfsSettlement1".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<OrganizationListItem, bool>(c => c.blnForeignAddress == true || c.idfsCountry == null || c.idfsCountry != eidss.model.Core.EidssSiteContext.Instance.CountryID)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<OrganizationListItem, bool>(c => c.blnForeignAddress == true || c.idfsRegion1 == null)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<OrganizationListItem, bool>( c => c.blnForeignAddress == true || c.idfsRayon1 == null)(this);
            
            return ReadOnly || new Func<OrganizationListItem, bool>(c => false)(this);
                
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


        internal Dictionary<string, Func<OrganizationListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<OrganizationListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<OrganizationListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<OrganizationListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<OrganizationListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<OrganizationListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<OrganizationListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~OrganizationListItem()
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
                
                LookupManager.RemoveObject("CountryLookup", this);
                
                LookupManager.RemoveObject("RegionLookup", this);
                
                LookupManager.RemoveObject("RayonLookup", this);
                
                LookupManager.RemoveObject("SettlementLookup", this);
                
                LookupManager.RemoveObject("HACodeLookup", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "CountryLookup")
                _getAccessor().LoadLookup_Country(manager, this);
            
            if (lookup_object == "RegionLookup")
                _getAccessor().LoadLookup_Region(manager, this);
            
            if (lookup_object == "RayonLookup")
                _getAccessor().LoadLookup_Rayon(manager, this);
            
            if (lookup_object == "SettlementLookup")
                _getAccessor().LoadLookup_Settlement(manager, this);
            
            if (lookup_object == "HACodeLookup")
                _getAccessor().LoadLookup_HACode(manager, this);
            
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
        public class OrganizationListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfInstitution { get; set; }
        
            public String name { get; set; }
        
            public String FullName { get; set; }
        
            public String strOrganizationID { get; set; }
        
            public String Address { get; set; }
        
            public Int32? intOrder { get; set; }
        
        }
        public partial class OrganizationListItemGridModelList : List<OrganizationListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public OrganizationListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<OrganizationListItem>, errMes);
            }
            public OrganizationListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<OrganizationListItem>, errMes);
            }
            public OrganizationListItemGridModelList(long key, IEnumerable<OrganizationListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public OrganizationListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<OrganizationListItem>(), null);
            }
            partial void filter(List<OrganizationListItem> items);
            private void LoadGridModelList(long key, IEnumerable<OrganizationListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_name,_str_FullName,_str_strOrganizationID,_str_Address,_str_intOrder};
                    
                Hiddens = new List<string> {_str_idfInstitution};
                Keys = new List<string> {_str_idfInstitution};
                Labels = new Dictionary<string, string> {{_str_name, "Abbreviation"},{_str_FullName, "Organization.Name"},{_str_strOrganizationID, "strOrganizationID"},{_str_Address, "Organization.Address"},{_str_intOrder, _str_intOrder}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                OrganizationListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<OrganizationListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new OrganizationListItemGridModel()
                {
                    ItemKey=c.idfInstitution,name=c.name,FullName=c.FullName,strOrganizationID=c.strOrganizationID,Address=c.Address,intOrder=c.intOrder
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
        : DataAccessor<OrganizationListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<OrganizationListItem>
            
            , IObjectSelectList
            , IObjectSelectList<OrganizationListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfInstitution"; } }
            #endregion
        
            public delegate void on_action(OrganizationListItem obj);
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
            private CountryLookup.Accessor CountryAccessor { get { return eidss.model.Schema.CountryLookup.Accessor.Instance(m_CS); } }
            private RegionLookup.Accessor RegionAccessor { get { return eidss.model.Schema.RegionLookup.Accessor.Instance(m_CS); } }
            private RayonLookup.Accessor RayonAccessor { get { return eidss.model.Schema.RayonLookup.Accessor.Instance(m_CS); } }
            private SettlementLookup.Accessor SettlementAccessor { get { return eidss.model.Schema.SettlementLookup.Accessor.Instance(m_CS); } }
            private HACodeLookup.Accessor HACodeAccessor { get { return eidss.model.Schema.HACodeLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<OrganizationListItem> SelectListT(DbManagerProxy manager
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
            
            protected virtual List<OrganizationListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_Organization_SelectList.* from dbo.fn_Organization_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("idfsRegion1") || filters.Contains("idfsRayon1") || filters.Contains("idfsSettlement1") || filters.Contains("blnForeignAddress"))
                {
                    
                    sql.Append(" " + @"
						INNER JOIN fnInstitution(@LangID)
						ON fn_Organization_SelectList.idfInstitution = fnInstitution.idfOffice
						INNER JOIN tlbGeoLocationShared geo
						ON fnInstitution.idfLocation = geo.idfGeoLocationShared
					");
                      
                }
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfsRegion1"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsRegion1") == 1)
                    {
                        sql.AppendFormat("geo.idfsRegion {0} @idfsRegion1", filters.Operation("idfsRegion1"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsRegion1"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsRegion1") ? " or " : " and ");
                            sql.AppendFormat("geo.idfsRegion {0} @idfsRegion1_{1}", filters.Operation("idfsRegion1", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsRayon1"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsRayon1") == 1)
                    {
                        sql.AppendFormat("geo.idfsRayon {0} @idfsRayon1", filters.Operation("idfsRayon1"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsRayon1"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsRayon1") ? " or " : " and ");
                            sql.AppendFormat("geo.idfsRayon {0} @idfsRayon1_{1}", filters.Operation("idfsRayon1", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsSettlement1"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsSettlement1") == 1)
                    {
                        sql.AppendFormat("geo.idfsSettlement {0} @idfsSettlement1", filters.Operation("idfsSettlement1"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsSettlement1"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsSettlement1") ? " or " : " and ");
                            sql.AppendFormat("geo.idfsSettlement {0} @idfsSettlement1_{1}", filters.Operation("idfsSettlement1", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("blnForeignAddress"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("blnForeignAddress") == 1)
                    {
                        sql.AppendFormat("(isnull(@blnForeignAddress,0) = 0 or geo.blnForeignAddress {0} @blnForeignAddress)", filters.Operation("blnForeignAddress"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("blnForeignAddress"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("blnForeignAddress") ? " or " : " and ");
                            sql.AppendFormat("(isnull(@blnForeignAddress_{1},0) = 0 or geo.blnForeignAddress {0} @blnForeignAddress)", filters.Operation("blnForeignAddress", i), i);
                        }
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
                          sql.AppendFormat("(isnull(fn_Organization_SelectList.idfInstitution,0) {0} @idfInstitution_{1} = @idfInstitution_{1})", filters.Operation("idfInstitution", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Organization_SelectList.idfInstitution,0) {0} @idfInstitution_{1}", filters.Operation("idfInstitution", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("FullName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("FullName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("FullName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Organization_SelectList.FullName {0} @FullName_{1}", filters.Operation("FullName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("name"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("name"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("name") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Organization_SelectList.name {0} @name_{1}", filters.Operation("name", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("Address"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("Address"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("Address") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Organization_SelectList.Address {0} @Address_{1}", filters.Operation("Address", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intHACode"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intHACode"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intHACode") ? " or " : " and ");
                        
                        if (filters.Operation("intHACode", i) == "&")
                          sql.AppendFormat("(isnull(fn_Organization_SelectList.intHACode,0) {0} @intHACode_{1} = @intHACode_{1})", filters.Operation("intHACode", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Organization_SelectList.intHACode,0) {0} @intHACode_{1}", filters.Operation("intHACode", i), i);
                            
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
                        
                        sql.AppendFormat("fn_Organization_SelectList.strOrganizationID {0} @strOrganizationID_{1}", filters.Operation("strOrganizationID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intOrder"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intOrder"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intOrder") ? " or " : " and ");
                        
                        if (filters.Operation("intOrder", i) == "&")
                          sql.AppendFormat("(isnull(fn_Organization_SelectList.intOrder,0) {0} @intOrder_{1} = @intOrder_{1})", filters.Operation("intOrder", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Organization_SelectList.intOrder,0) {0} @intOrder_{1}", filters.Operation("intOrder", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                sql.Append(" order by ISNULL(dbo.fn_Organization_SelectList.intOrder,0), dbo.fn_Organization_SelectList.name ");
                  

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
                    
                    if (filters.Contains("blnForeignAddress"))
                        
                        if (filters.Count("blnForeignAddress") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@blnForeignAddress", ParsingHelper.CorrectLikeValue(filters.Operation("blnForeignAddress"), filters.Value("blnForeignAddress"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("blnForeignAddress"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@blnForeignAddress_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("blnForeignAddress", i), filters.Value("blnForeignAddress", i))));
                        }
                            
                    if (filters.Contains("idfsRegion1"))
                        
                        if (filters.Count("idfsRegion1") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion1", ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion1"), filters.Value("idfsRegion1"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsRegion1"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion1_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion1", i), filters.Value("idfsRegion1", i))));
                        }
                            
                    if (filters.Contains("idfsRayon1"))
                        
                        if (filters.Count("idfsRayon1") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon1", ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon1"), filters.Value("idfsRayon1"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsRayon1"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon1_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon1", i), filters.Value("idfsRayon1", i))));
                        }
                            
                    if (filters.Contains("idfsSettlement1"))
                        
                        if (filters.Count("idfsSettlement1") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSettlement1", ParsingHelper.CorrectLikeValue(filters.Operation("idfsSettlement1"), filters.Value("idfsSettlement1"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsSettlement1"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSettlement1_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSettlement1", i), filters.Value("idfsSettlement1", i))));
                        }
                            
                    if (filters.Contains("idfInstitution"))
                        for (int i = 0; i < filters.Count("idfInstitution"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfInstitution_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfInstitution", i), filters.Value("idfInstitution", i))));
                      
                    if (filters.Contains("FullName"))
                        for (int i = 0; i < filters.Count("FullName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@FullName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("FullName", i), filters.Value("FullName", i))));
                      
                    if (filters.Contains("name"))
                        for (int i = 0; i < filters.Count("name"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@name_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("name", i), filters.Value("name", i))));
                      
                    if (filters.Contains("Address"))
                        for (int i = 0; i < filters.Count("Address"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@Address_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("Address", i), filters.Value("Address", i))));
                      
                    if (filters.Contains("intHACode"))
                        for (int i = 0; i < filters.Count("intHACode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intHACode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intHACode", i), filters.Value("intHACode", i))));
                      
                    if (filters.Contains("strOrganizationID"))
                        for (int i = 0; i < filters.Count("strOrganizationID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strOrganizationID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strOrganizationID", i), filters.Value("strOrganizationID", i))));
                      
                    if (filters.Contains("intOrder"))
                        for (int i = 0; i < filters.Count("intOrder"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intOrder_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intOrder", i), filters.Value("intOrder", i))));
                      
                    List<OrganizationListItem> objs = manager.ExecuteList<OrganizationListItem>();
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
            partial void ListSelected(DbManagerProxy manager, List<OrganizationListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spOrganization_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, OrganizationListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, OrganizationListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private OrganizationListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                OrganizationListItem obj = null;
                try
                {
                    obj = OrganizationListItem.CreateInstance();
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
                obj.Country = new Func<OrganizationListItem, CountryLookup>(c => 
                                     c.CountryLookup.Where(a => a.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID)
                                     .SingleOrDefault())(obj);
                obj.Region = new Func<OrganizationListItem, RegionLookup>(c => 
                                     EidssUserContext.User.Options.Prefs.DefaultRegion == true?
                                     c.RegionLookup.Where(a => a.idfsRegion == eidss.model.Core.EidssSiteContext.Instance.RegionID)
                                     .SingleOrDefault(): null)(obj);
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

            
            public OrganizationListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public OrganizationListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public OrganizationListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public OrganizationListItem CreateWithHACodeT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is int)) 
                    throw new TypeMismatchException("code", typeof(int));
                
                return CreateWithHACode(manager, Parent
                    , (int)pars[0]
                    );
            }
            public IObject CreateWithHACode(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateWithHACodeT(manager, Parent, pars);
            }
            public OrganizationListItem CreateWithHACode(DbManagerProxy manager, IObject Parent
                , int code
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                }
                    , obj =>
                {
                obj.intHACode = new Func<OrganizationListItem, int>(o => code)(obj);
                }
                );
            }
            
            private void _SetupChildHandlers(OrganizationListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(OrganizationListItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_blnForeignAddress)
                        {
                    
                obj.Country = new Func<OrganizationListItem, CountryLookup>(c => c.blnForeignAddress == true? null:c.CountryLookup.Where(a => a.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID).SingleOrDefault())(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.Region = new Func<OrganizationListItem, RegionLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion1)
                        {
                    
                obj.Rayon = new Func<OrganizationListItem, RayonLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon1)
                        {
                    
                obj.Settlement = new Func<OrganizationListItem, SettlementLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Region(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion1)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Rayon(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon1)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Settlement(manager, obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Country(DbManagerProxy manager, OrganizationListItem obj)
            {
                
                obj.CountryLookup.Clear();
                
                obj.CountryLookup.Add(CountryAccessor.CreateNewT(manager, null));
                
                obj.CountryLookup.AddRange(CountryAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsCountry == obj.idfsCountry))
                    
                    .ToList());
                
                if (obj.idfsCountry != null && obj.idfsCountry != 0)
                {
                    obj.Country = obj.CountryLookup
                        .SingleOrDefault(c => c.idfsCountry == obj.idfsCountry);
                    
                }
              
                LookupManager.AddObject("CountryLookup", obj, CountryAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Region(DbManagerProxy manager, OrganizationListItem obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<OrganizationListItem, long>(c => c.idfsCountry ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRegion == obj.idfsRegion1))
                    
                    .ToList());
                
                if (obj.idfsRegion1 != null && obj.idfsRegion1 != 0)
                {
                    obj.Region = obj.RegionLookup
                        .SingleOrDefault(c => c.idfsRegion == obj.idfsRegion1);
                    
                }
              
                LookupManager.AddObject("RegionLookup", obj, RegionAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Rayon(DbManagerProxy manager, OrganizationListItem obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<OrganizationListItem, long>(c => c.idfsRegion1 ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRayon == obj.idfsRayon1))
                    
                    .ToList());
                
                if (obj.idfsRayon1 != null && obj.idfsRayon1 != 0)
                {
                    obj.Rayon = obj.RayonLookup
                        .SingleOrDefault(c => c.idfsRayon == obj.idfsRayon1);
                    
                }
              
                LookupManager.AddObject("RayonLookup", obj, RayonAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Settlement(DbManagerProxy manager, OrganizationListItem obj)
            {
                
                obj.SettlementLookup.Clear();
                
                obj.SettlementLookup.Add(SettlementAccessor.CreateNewT(manager, null));
                
                obj.SettlementLookup.AddRange(SettlementAccessor.SelectLookupList(manager
                    
                    , new Func<OrganizationListItem, long>(c => c.idfsRayon1 ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSettlement == obj.idfsSettlement1))
                    
                    .ToList());
                
                if (obj.idfsSettlement1 != null && obj.idfsSettlement1 != 0)
                {
                    obj.Settlement = obj.SettlementLookup
                        .SingleOrDefault(c => c.idfsSettlement == obj.idfsSettlement1);
                    
                }
              
                LookupManager.AddObject("SettlementLookup", obj, SettlementAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_HACode(DbManagerProxy manager, OrganizationListItem obj)
            {
                
                obj.HACodeLookup.Clear();
                
                obj.HACodeLookup.Add(HACodeAccessor.CreateNewT(manager, null));
                
                obj.HACodeLookup.Last().CodeName = eidss.model.Resources.EidssFields.Get("SelectAll");
                
                obj.HACodeLookup.AddRange(HACodeAccessor.SelectLookupList(manager
                    
                    , new Func<OrganizationListItem, int>(c => (int)(Enums.HACode.Human | Enums.HACode.Avian | Enums.HACode.Livestock | Enums.HACode.Vector | Enums.HACode.Syndromic))(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.intHACode == obj.intHACode))
                    
                    .ToList());
                
                if (obj.intHACode != null && obj.intHACode != 0)
                {
                    obj.HACode = obj.HACodeLookup
                        .SingleOrDefault(c => c.intHACode == obj.intHACode);
                    
                }
              
                LookupManager.AddObject("HACodeLookup", obj, HACodeAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, OrganizationListItem obj)
            {
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Settlement(manager, obj);
                
                LoadLookup_HACode(manager, obj);
                
            }
    
            [SprocName("spOrganization_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spOrganization_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? idfOffice
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? idfOffice
                )
            {
                
                _postDelete(manager, idfOffice);
                
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
                        OrganizationListItem bo = obj as OrganizationListItem;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            if (!CanDelete)
                                throw new PermissionException("Organization", "Delete");
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            if (!CanInsert)
                                throw new PermissionException("Organization", "Insert");
                        }
                        else if (!bo.IsMarkedToDelete && bo.HasChanges) // update
                        {
                            if (!CanUpdate)
                                throw new PermissionException("Organization", "Update");
                        }
                        
                        long mainObject = bo.idfInstitution;
                        
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
                              
                              manager.SetEventParams(false, "Organization", new object[] { eventType, null, "Organization" });
                              
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
                            
                            eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoOrganization;
                            eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbOffice;
                            manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                            
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as OrganizationListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, OrganizationListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfInstitution
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
            
            public bool ValidateCanDelete(OrganizationListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, OrganizationListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfInstitution
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
        
      
            protected ValidationModelException ChainsValidate(OrganizationListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(OrganizationListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as OrganizationListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, OrganizationListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Organization.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Organization.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Organization.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Organization.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(OrganizationListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(OrganizationListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as OrganizationListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as OrganizationListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "OrganizationListItemDetail"; } }
            public string HelpIdWin { get { return "Organisations"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private OrganizationListItem m_obj;
            internal Permissions(OrganizationListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Organization.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Organization.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Organization.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Organization.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_Organization_SelectList";
            public static string spCount = "spOrganization_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spOrganization_Delete";
            public static string spCanDelete = "spOrganization_CanDelete";
            public static string sqlSortOrder = "ISNULL(dbo.fn_Organization_SelectList.intOrder,0), dbo.fn_Organization_SelectList.name";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<OrganizationListItem, bool>> RequiredByField = new Dictionary<string, Func<OrganizationListItem, bool>>();
            public static Dictionary<string, Func<OrganizationListItem, bool>> RequiredByProperty = new Dictionary<string, Func<OrganizationListItem, bool>>();
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
                
                Sizes.Add(_str_FullName, 2000);
                Sizes.Add(_str_name, 2000);
                Sizes.Add(_str_Address, 2000);
                Sizes.Add(_str_strOrganizationID, 100);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strOrganizationID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strOrganizationID",
                    c => String.Empty, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "name",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "Abbreviation",
                    c => String.Empty, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "FullName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "Organization.Name",
                    c => String.Empty, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "intHACode",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strOrganizationHACode",
                    null, null, c => false, true, SearchPanelLocation.Main, false, null, "HACodeLookup", typeof(HACodeLookup), (o) => { var c = (HACodeLookup)o; return c.intHACode; }, (o) => { var c = (HACodeLookup)o; return c.CodeName; }, null,true
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "blnForeignAddress",
                    EditorType.Flag,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "lblShowForeignOrganization",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRegion1",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsRegion",
                    null, "=", c => false, false, SearchPanelLocation.Main, true, "idfsRayon1", "RegionLookup", typeof(RegionLookup), (o) => { var c = (RegionLookup)o; return c.idfsRegion; }, (o) => { var c = (RegionLookup)o; return c.strRegionName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRayon1",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsRayon",
                    null, null, c => false, false, SearchPanelLocation.Main, true, "idfsSettlement1", "RayonLookup", typeof(RayonLookup), (o) => { var c = (RayonLookup)o; return c.idfsRayon; }, (o) => { var c = (RayonLookup)o; return c.strRayonName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSettlement1",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "Settlement",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, "SettlementLookup", typeof(SettlementLookup), (o) => { var c = (SettlementLookup)o; return c.idfsSettlement; }, (o) => { var c = (SettlementLookup)o; return c.strSettlementName; }, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfInstitution,
                    _str_idfInstitution, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_name,
                    "Abbreviation", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_FullName,
                    "Organization.Name", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strOrganizationID,
                    "strOrganizationID", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Address,
                    "Organization.Address", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intOrder,
                    _str_intOrder, null, false, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "CreateWithHACode",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithHACode(manager, c, pars)),
                        
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<Personnel>().CreateNew(manager, c, pars == null ? null : (int?)pars[0])),
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<Personnel>().SelectDetail(manager, pars[0])),
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
                                c = ObjectAccessor.CreatorInterface<OrganizationListItem>().CreateWithParams(manager, null, pars);
                                ((OrganizationListItem)c).idfInstitution = (long)pars[0];
                                ((OrganizationListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((OrganizationListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<OrganizationListItem>().Post(manager, (OrganizationListItem)c), c);
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
	