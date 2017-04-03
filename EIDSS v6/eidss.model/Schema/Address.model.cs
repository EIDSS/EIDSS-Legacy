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
    public abstract partial class Address : 
        EditableObject<Address>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfGeoLocation), NonUpdatable, PrimaryKey]
        public abstract Int64 idfGeoLocation { get; set; }
                
        [LocalizedDisplayName(_str_strApartment)]
        [MapField(_str_strApartment)]
        public abstract String strApartment { get; set; }
        protected String strApartment_Original { get { return ((EditableValue<String>)((dynamic)this)._strApartment).OriginalValue; } }
        protected String strApartment_Previous { get { return ((EditableValue<String>)((dynamic)this)._strApartment).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strBuilding)]
        [MapField(_str_strBuilding)]
        public abstract String strBuilding { get; set; }
        protected String strBuilding_Original { get { return ((EditableValue<String>)((dynamic)this)._strBuilding).OriginalValue; } }
        protected String strBuilding_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBuilding).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHouse)]
        [MapField(_str_strHouse)]
        public abstract String strHouse { get; set; }
        protected String strHouse_Original { get { return ((EditableValue<String>)((dynamic)this)._strHouse).OriginalValue; } }
        protected String strHouse_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHouse).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPostCode)]
        [MapField(_str_strPostCode)]
        public abstract String strPostCode { get; set; }
        protected String strPostCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strPostCode).OriginalValue; } }
        protected String strPostCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPostCode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strStreetName)]
        [MapField(_str_strStreetName)]
        public abstract String strStreetName { get; set; }
        protected String strStreetName_Original { get { return ((EditableValue<String>)((dynamic)this)._strStreetName).OriginalValue; } }
        protected String strStreetName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strStreetName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCountry)]
        [MapField(_str_idfsCountry)]
        public abstract Int64? idfsCountry { get; set; }
        protected Int64? idfsCountry_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).OriginalValue; } }
        protected Int64? idfsCountry_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRegion)]
        [MapField(_str_idfsRegion)]
        public abstract Int64? idfsRegion { get; set; }
        protected Int64? idfsRegion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).OriginalValue; } }
        protected Int64? idfsRegion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRayon)]
        [MapField(_str_idfsRayon)]
        public abstract Int64? idfsRayon { get; set; }
        protected Int64? idfsRayon_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).OriginalValue; } }
        protected Int64? idfsRayon_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSettlement)]
        [MapField(_str_idfsSettlement)]
        public abstract Int64? idfsSettlement { get; set; }
        protected Int64? idfsSettlement_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).OriginalValue; } }
        protected Int64? idfsSettlement_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strAddressStringTranslate)]
        [MapField(_str_strAddressStringTranslate)]
        public abstract String strAddressStringTranslate { get; set; }
        protected String strAddressStringTranslate_Original { get { return ((EditableValue<String>)((dynamic)this)._strAddressStringTranslate).OriginalValue; } }
        protected String strAddressStringTranslate_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAddressStringTranslate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strAddressDefaultString)]
        [MapField(_str_strAddressDefaultString)]
        public abstract String strAddressDefaultString { get; set; }
        protected String strAddressDefaultString_Original { get { return ((EditableValue<String>)((dynamic)this)._strAddressDefaultString).OriginalValue; } }
        protected String strAddressDefaultString_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAddressDefaultString).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnForeignAddress)]
        [MapField(_str_blnForeignAddress)]
        public abstract Boolean blnForeignAddress { get; set; }
        protected Boolean blnForeignAddress_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnForeignAddress).OriginalValue; } }
        protected Boolean blnForeignAddress_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnForeignAddress).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strForeignAddress)]
        [MapField(_str_strForeignAddress)]
        public abstract String strForeignAddress { get; set; }
        protected String strForeignAddress_Original { get { return ((EditableValue<String>)((dynamic)this)._strForeignAddress).OriginalValue; } }
        protected String strForeignAddress_Previous { get { return ((EditableValue<String>)((dynamic)this)._strForeignAddress).PreviousValue; } }
                
        [LocalizedDisplayName(_str_dblLatitude)]
        [MapField(_str_dblLatitude)]
        public abstract Double? dblLatitude { get; set; }
        protected Double? dblLatitude_Original { get { return ((EditableValue<Double?>)((dynamic)this)._dblLatitude).OriginalValue; } }
        protected Double? dblLatitude_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._dblLatitude).PreviousValue; } }
                
        [LocalizedDisplayName(_str_dblLongitude)]
        [MapField(_str_dblLongitude)]
        public abstract Double? dblLongitude { get; set; }
        protected Double? dblLongitude_Original { get { return ((EditableValue<Double?>)((dynamic)this)._dblLongitude).OriginalValue; } }
        protected Double? dblLongitude_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._dblLongitude).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<Address, object> _get_func;
            internal Action<Address, string> _set_func;
            internal Action<Address, Address, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfGeoLocation = "idfGeoLocation";
        internal const string _str_strApartment = "strApartment";
        internal const string _str_strBuilding = "strBuilding";
        internal const string _str_strHouse = "strHouse";
        internal const string _str_strPostCode = "strPostCode";
        internal const string _str_strStreetName = "strStreetName";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_strAddressStringTranslate = "strAddressStringTranslate";
        internal const string _str_strAddressDefaultString = "strAddressDefaultString";
        internal const string _str_blnForeignAddress = "blnForeignAddress";
        internal const string _str_strForeignAddress = "strForeignAddress";
        internal const string _str_dblLatitude = "dblLatitude";
        internal const string _str_dblLongitude = "dblLongitude";
        internal const string _str_HCase = "HCase";
        internal const string _str_VCase = "VCase";
        internal const string _str_FPanel = "FPanel";
        internal const string _str_blnGeoLocationShared = "blnGeoLocationShared";
        internal const string _str_blnReadOnlyRegion = "blnReadOnlyRegion";
        internal const string _str_bCancelCoordinationValidation = "bCancelCoordinationValidation";
        internal const string _str_blnNeedForeignAddressStr = "blnNeedForeignAddressStr";
        internal const string _str_blnForceReadOnly = "blnForceReadOnly";
        internal const string _str_FullName = "FullName";
        internal const string _str_IsReadOnlyParent = "IsReadOnlyParent";
        internal const string _str_strReadOnlyCountry = "strReadOnlyCountry";
        internal const string _str_strReadOnlyRegion = "strReadOnlyRegion";
        internal const string _str_strReadOnlyRayon = "strReadOnlyRayon";
        internal const string _str_strReadOnlySettlement = "strReadOnlySettlement";
        internal const string _str_strReadOnlyStreet = "strReadOnlyStreet";
        internal const string _str_strReadOnlyPostCode = "strReadOnlyPostCode";
        internal const string _str_strReadOnlyBuilding = "strReadOnlyBuilding";
        internal const string _str_strReadOnlyApartment = "strReadOnlyApartment";
        internal const string _str_strReadOnlyHouse = "strReadOnlyHouse";
        internal const string _str_strReadOnlyFullName = "strReadOnlyFullName";
        internal const string _str_strReadOnlyAdaptiveFullName = "strReadOnlyAdaptiveFullName";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Settlement = "Settlement";
        internal const string _str_Street = "Street";
        internal const string _str_PostCode = "PostCode";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfGeoLocation, _formname = _str_idfGeoLocation, _type = "Int64",
              _get_func = o => o.idfGeoLocation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfGeoLocation != newval) o.idfGeoLocation = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfGeoLocation != c.idfGeoLocation || o.IsRIRPropChanged(_str_idfGeoLocation, c)) 
                  m.Add(_str_idfGeoLocation, o.ObjectIdent + _str_idfGeoLocation, o.ObjectIdent2 + _str_idfGeoLocation, o.ObjectIdent3 + _str_idfGeoLocation, "Int64", 
                    o.idfGeoLocation == null ? "" : o.idfGeoLocation.ToString(),                  
                  o.IsReadOnly(_str_idfGeoLocation), o.IsInvisible(_str_idfGeoLocation), o.IsRequired(_str_idfGeoLocation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strApartment, _formname = _str_strApartment, _type = "String",
              _get_func = o => o.strApartment,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strApartment != newval) o.strApartment = newval; },
              _compare_func = (o, c, m) => {
                if (o.strApartment != c.strApartment || o.IsRIRPropChanged(_str_strApartment, c)) 
                  m.Add(_str_strApartment, o.ObjectIdent + _str_strApartment, o.ObjectIdent2 + _str_strApartment, o.ObjectIdent3 + _str_strApartment, "String", 
                    o.strApartment == null ? "" : o.strApartment.ToString(),                  
                  o.IsReadOnly(_str_strApartment), o.IsInvisible(_str_strApartment), o.IsRequired(_str_strApartment)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strBuilding, _formname = _str_strBuilding, _type = "String",
              _get_func = o => o.strBuilding,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strBuilding != newval) o.strBuilding = newval; },
              _compare_func = (o, c, m) => {
                if (o.strBuilding != c.strBuilding || o.IsRIRPropChanged(_str_strBuilding, c)) 
                  m.Add(_str_strBuilding, o.ObjectIdent + _str_strBuilding, o.ObjectIdent2 + _str_strBuilding, o.ObjectIdent3 + _str_strBuilding, "String", 
                    o.strBuilding == null ? "" : o.strBuilding.ToString(),                  
                  o.IsReadOnly(_str_strBuilding), o.IsInvisible(_str_strBuilding), o.IsRequired(_str_strBuilding)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHouse, _formname = _str_strHouse, _type = "String",
              _get_func = o => o.strHouse,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHouse != newval) o.strHouse = newval; },
              _compare_func = (o, c, m) => {
                if (o.strHouse != c.strHouse || o.IsRIRPropChanged(_str_strHouse, c)) 
                  m.Add(_str_strHouse, o.ObjectIdent + _str_strHouse, o.ObjectIdent2 + _str_strHouse, o.ObjectIdent3 + _str_strHouse, "String", 
                    o.strHouse == null ? "" : o.strHouse.ToString(),                  
                  o.IsReadOnly(_str_strHouse), o.IsInvisible(_str_strHouse), o.IsRequired(_str_strHouse)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPostCode, _formname = _str_strPostCode, _type = "String",
              _get_func = o => o.strPostCode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); 
                if (o.strPostCode != newval) 
                  o.PostCode = o.PostCodeLookup.FirstOrDefault(c => c.strPostCode == newval);
                if (o.strPostCode != newval) o.strPostCode = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPostCode != c.strPostCode || o.IsRIRPropChanged(_str_strPostCode, c)) 
                  m.Add(_str_strPostCode, o.ObjectIdent + _str_strPostCode, o.ObjectIdent2 + _str_strPostCode, o.ObjectIdent3 + _str_strPostCode, "String", 
                    o.strPostCode == null ? "" : o.strPostCode.ToString(),                  
                  o.IsReadOnly(_str_strPostCode), o.IsInvisible(_str_strPostCode), o.IsRequired(_str_strPostCode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strStreetName, _formname = _str_strStreetName, _type = "String",
              _get_func = o => o.strStreetName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); 
                if (o.strStreetName != newval) 
                  o.Street = o.StreetLookup.FirstOrDefault(c => c.strStreetName == newval);
                if (o.strStreetName != newval) o.strStreetName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strStreetName != c.strStreetName || o.IsRIRPropChanged(_str_strStreetName, c)) 
                  m.Add(_str_strStreetName, o.ObjectIdent + _str_strStreetName, o.ObjectIdent2 + _str_strStreetName, o.ObjectIdent3 + _str_strStreetName, "String", 
                    o.strStreetName == null ? "" : o.strStreetName.ToString(),                  
                  o.IsReadOnly(_str_strStreetName), o.IsInvisible(_str_strStreetName), o.IsRequired(_str_strStreetName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCountry, _formname = _str_idfsCountry, _type = "Int64?",
              _get_func = o => o.idfsCountry,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsCountry != newval) 
                  o.Country = o.CountryLookup.FirstOrDefault(c => c.idfsCountry == newval);
                if (o.idfsCountry != newval) o.idfsCountry = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_idfsCountry, c)) 
                  m.Add(_str_idfsCountry, o.ObjectIdent + _str_idfsCountry, o.ObjectIdent2 + _str_idfsCountry, o.ObjectIdent3 + _str_idfsCountry, "Int64?", 
                    o.idfsCountry == null ? "" : o.idfsCountry.ToString(),                  
                  o.IsReadOnly(_str_idfsCountry), o.IsInvisible(_str_idfsCountry), o.IsRequired(_str_idfsCountry)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsRegion, _formname = _str_idfsRegion, _type = "Int64?",
              _get_func = o => o.idfsRegion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsRegion != newval) 
                  o.Region = o.RegionLookup.FirstOrDefault(c => c.idfsRegion == newval);
                if (o.idfsRegion != newval) o.idfsRegion = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_idfsRegion, c)) 
                  m.Add(_str_idfsRegion, o.ObjectIdent + _str_idfsRegion, o.ObjectIdent2 + _str_idfsRegion, o.ObjectIdent3 + _str_idfsRegion, "Int64?", 
                    o.idfsRegion == null ? "" : o.idfsRegion.ToString(),                  
                  o.IsReadOnly(_str_idfsRegion), o.IsInvisible(_str_idfsRegion), o.IsRequired(_str_idfsRegion)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsRayon, _formname = _str_idfsRayon, _type = "Int64?",
              _get_func = o => o.idfsRayon,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsRayon != newval) 
                  o.Rayon = o.RayonLookup.FirstOrDefault(c => c.idfsRayon == newval);
                if (o.idfsRayon != newval) o.idfsRayon = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_idfsRayon, c)) 
                  m.Add(_str_idfsRayon, o.ObjectIdent + _str_idfsRayon, o.ObjectIdent2 + _str_idfsRayon, o.ObjectIdent3 + _str_idfsRayon, "Int64?", 
                    o.idfsRayon == null ? "" : o.idfsRayon.ToString(),                  
                  o.IsReadOnly(_str_idfsRayon), o.IsInvisible(_str_idfsRayon), o.IsRequired(_str_idfsRayon)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSettlement, _formname = _str_idfsSettlement, _type = "Int64?",
              _get_func = o => o.idfsSettlement,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsSettlement != newval) 
                  o.Settlement = o.SettlementLookup.FirstOrDefault(c => c.idfsSettlement == newval);
                if (o.idfsSettlement != newval) o.idfsSettlement = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_idfsSettlement, c)) 
                  m.Add(_str_idfsSettlement, o.ObjectIdent + _str_idfsSettlement, o.ObjectIdent2 + _str_idfsSettlement, o.ObjectIdent3 + _str_idfsSettlement, "Int64?", 
                    o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(),                  
                  o.IsReadOnly(_str_idfsSettlement), o.IsInvisible(_str_idfsSettlement), o.IsRequired(_str_idfsSettlement)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strAddressStringTranslate, _formname = _str_strAddressStringTranslate, _type = "String",
              _get_func = o => o.strAddressStringTranslate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strAddressStringTranslate != newval) o.strAddressStringTranslate = newval; },
              _compare_func = (o, c, m) => {
                if (o.strAddressStringTranslate != c.strAddressStringTranslate || o.IsRIRPropChanged(_str_strAddressStringTranslate, c)) 
                  m.Add(_str_strAddressStringTranslate, o.ObjectIdent + _str_strAddressStringTranslate, o.ObjectIdent2 + _str_strAddressStringTranslate, o.ObjectIdent3 + _str_strAddressStringTranslate, "String", 
                    o.strAddressStringTranslate == null ? "" : o.strAddressStringTranslate.ToString(),                  
                  o.IsReadOnly(_str_strAddressStringTranslate), o.IsInvisible(_str_strAddressStringTranslate), o.IsRequired(_str_strAddressStringTranslate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strAddressDefaultString, _formname = _str_strAddressDefaultString, _type = "String",
              _get_func = o => o.strAddressDefaultString,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strAddressDefaultString != newval) o.strAddressDefaultString = newval; },
              _compare_func = (o, c, m) => {
                if (o.strAddressDefaultString != c.strAddressDefaultString || o.IsRIRPropChanged(_str_strAddressDefaultString, c)) 
                  m.Add(_str_strAddressDefaultString, o.ObjectIdent + _str_strAddressDefaultString, o.ObjectIdent2 + _str_strAddressDefaultString, o.ObjectIdent3 + _str_strAddressDefaultString, "String", 
                    o.strAddressDefaultString == null ? "" : o.strAddressDefaultString.ToString(),                  
                  o.IsReadOnly(_str_strAddressDefaultString), o.IsInvisible(_str_strAddressDefaultString), o.IsRequired(_str_strAddressDefaultString)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnForeignAddress, _formname = _str_blnForeignAddress, _type = "Boolean",
              _get_func = o => o.blnForeignAddress,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnForeignAddress != newval) o.blnForeignAddress = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnForeignAddress != c.blnForeignAddress || o.IsRIRPropChanged(_str_blnForeignAddress, c)) 
                  m.Add(_str_blnForeignAddress, o.ObjectIdent + _str_blnForeignAddress, o.ObjectIdent2 + _str_blnForeignAddress, o.ObjectIdent3 + _str_blnForeignAddress, "Boolean", 
                    o.blnForeignAddress == null ? "" : o.blnForeignAddress.ToString(),                  
                  o.IsReadOnly(_str_blnForeignAddress), o.IsInvisible(_str_blnForeignAddress), o.IsRequired(_str_blnForeignAddress)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strForeignAddress, _formname = _str_strForeignAddress, _type = "String",
              _get_func = o => o.strForeignAddress,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strForeignAddress != newval) o.strForeignAddress = newval; },
              _compare_func = (o, c, m) => {
                if (o.strForeignAddress != c.strForeignAddress || o.IsRIRPropChanged(_str_strForeignAddress, c)) 
                  m.Add(_str_strForeignAddress, o.ObjectIdent + _str_strForeignAddress, o.ObjectIdent2 + _str_strForeignAddress, o.ObjectIdent3 + _str_strForeignAddress, "String", 
                    o.strForeignAddress == null ? "" : o.strForeignAddress.ToString(),                  
                  o.IsReadOnly(_str_strForeignAddress), o.IsInvisible(_str_strForeignAddress), o.IsRequired(_str_strForeignAddress)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_dblLatitude, _formname = _str_dblLatitude, _type = "Double?",
              _get_func = o => o.dblLatitude,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDoubleNullable(val); if (o.dblLatitude != newval) o.dblLatitude = newval; },
              _compare_func = (o, c, m) => {
                if (o.dblLatitude != c.dblLatitude || o.IsRIRPropChanged(_str_dblLatitude, c)) 
                  m.Add(_str_dblLatitude, o.ObjectIdent + _str_dblLatitude, o.ObjectIdent2 + _str_dblLatitude, o.ObjectIdent3 + _str_dblLatitude, "Double?", 
                    o.dblLatitude == null ? "" : o.dblLatitude.Value.ToString(new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = ".", NumberGroupSeparator = "" }),                  
                  o.IsReadOnly(_str_dblLatitude), o.IsInvisible(_str_dblLatitude), o.IsRequired(_str_dblLatitude)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_dblLongitude, _formname = _str_dblLongitude, _type = "Double?",
              _get_func = o => o.dblLongitude,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDoubleNullable(val); if (o.dblLongitude != newval) o.dblLongitude = newval; },
              _compare_func = (o, c, m) => {
                if (o.dblLongitude != c.dblLongitude || o.IsRIRPropChanged(_str_dblLongitude, c)) 
                  m.Add(_str_dblLongitude, o.ObjectIdent + _str_dblLongitude, o.ObjectIdent2 + _str_dblLongitude, o.ObjectIdent3 + _str_dblLongitude, "Double?", 
                    o.dblLongitude == null ? "" : o.dblLongitude.Value.ToString(new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = ".", NumberGroupSeparator = "" }),                  
                  o.IsReadOnly(_str_dblLongitude), o.IsInvisible(_str_dblLongitude), o.IsRequired(_str_dblLongitude)); 
                  }
              }, 
        
            new field_info {
              _name = _str_blnGeoLocationShared, _formname = _str_blnGeoLocationShared, _type = "bool",
              _get_func = o => o.blnGeoLocationShared,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnGeoLocationShared != newval) o.blnGeoLocationShared = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.blnGeoLocationShared != c.blnGeoLocationShared || o.IsRIRPropChanged(_str_blnGeoLocationShared, c)) {
                  m.Add(_str_blnGeoLocationShared, o.ObjectIdent + _str_blnGeoLocationShared, o.ObjectIdent2 + _str_blnGeoLocationShared, o.ObjectIdent3 + _str_blnGeoLocationShared,  "bool", 
                    o.blnGeoLocationShared == null ? "" : o.blnGeoLocationShared.ToString(),                  
                    o.IsReadOnly(_str_blnGeoLocationShared), o.IsInvisible(_str_blnGeoLocationShared), o.IsRequired(_str_blnGeoLocationShared));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_blnReadOnlyRegion, _formname = _str_blnReadOnlyRegion, _type = "bool",
              _get_func = o => o.blnReadOnlyRegion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnReadOnlyRegion != newval) o.blnReadOnlyRegion = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.blnReadOnlyRegion != c.blnReadOnlyRegion || o.IsRIRPropChanged(_str_blnReadOnlyRegion, c)) {
                  m.Add(_str_blnReadOnlyRegion, o.ObjectIdent + _str_blnReadOnlyRegion, o.ObjectIdent2 + _str_blnReadOnlyRegion, o.ObjectIdent3 + _str_blnReadOnlyRegion,  "bool", 
                    o.blnReadOnlyRegion == null ? "" : o.blnReadOnlyRegion.ToString(),                  
                    o.IsReadOnly(_str_blnReadOnlyRegion), o.IsInvisible(_str_blnReadOnlyRegion), o.IsRequired(_str_blnReadOnlyRegion));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_bCancelCoordinationValidation, _formname = _str_bCancelCoordinationValidation, _type = "bool",
              _get_func = o => o.bCancelCoordinationValidation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.bCancelCoordinationValidation != newval) o.bCancelCoordinationValidation = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.bCancelCoordinationValidation != c.bCancelCoordinationValidation || o.IsRIRPropChanged(_str_bCancelCoordinationValidation, c)) {
                  m.Add(_str_bCancelCoordinationValidation, o.ObjectIdent + _str_bCancelCoordinationValidation, o.ObjectIdent2 + _str_bCancelCoordinationValidation, o.ObjectIdent3 + _str_bCancelCoordinationValidation,  "bool", 
                    o.bCancelCoordinationValidation == null ? "" : o.bCancelCoordinationValidation.ToString(),                  
                    o.IsReadOnly(_str_bCancelCoordinationValidation), o.IsInvisible(_str_bCancelCoordinationValidation), o.IsRequired(_str_bCancelCoordinationValidation));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_blnNeedForeignAddressStr, _formname = _str_blnNeedForeignAddressStr, _type = "bool",
              _get_func = o => o.blnNeedForeignAddressStr,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnNeedForeignAddressStr != newval) o.blnNeedForeignAddressStr = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.blnNeedForeignAddressStr != c.blnNeedForeignAddressStr || o.IsRIRPropChanged(_str_blnNeedForeignAddressStr, c)) {
                  m.Add(_str_blnNeedForeignAddressStr, o.ObjectIdent + _str_blnNeedForeignAddressStr, o.ObjectIdent2 + _str_blnNeedForeignAddressStr, o.ObjectIdent3 + _str_blnNeedForeignAddressStr,  "bool", 
                    o.blnNeedForeignAddressStr == null ? "" : o.blnNeedForeignAddressStr.ToString(),                  
                    o.IsReadOnly(_str_blnNeedForeignAddressStr), o.IsInvisible(_str_blnNeedForeignAddressStr), o.IsRequired(_str_blnNeedForeignAddressStr));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_blnForceReadOnly, _formname = _str_blnForceReadOnly, _type = "bool",
              _get_func = o => o.blnForceReadOnly,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnForceReadOnly != newval) o.blnForceReadOnly = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.blnForceReadOnly != c.blnForceReadOnly || o.IsRIRPropChanged(_str_blnForceReadOnly, c)) {
                  m.Add(_str_blnForceReadOnly, o.ObjectIdent + _str_blnForceReadOnly, o.ObjectIdent2 + _str_blnForceReadOnly, o.ObjectIdent3 + _str_blnForceReadOnly,  "bool", 
                    o.blnForceReadOnly == null ? "" : o.blnForceReadOnly.ToString(),                  
                    o.IsReadOnly(_str_blnForceReadOnly), o.IsInvisible(_str_blnForceReadOnly), o.IsRequired(_str_blnForceReadOnly));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_HCase, _formname = _str_HCase, _type = "HumanCase",
              _get_func = o => o.HCase,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_VCase, _formname = _str_VCase, _type = "VetCase",
              _get_func = o => o.VCase,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_FPanel, _formname = _str_FPanel, _type = "FarmPanel",
              _get_func = o => o.FPanel,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_FullName, _formname = _str_FullName, _type = "string",
              _get_func = o => o.FullName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.FullName != c.FullName || o.IsRIRPropChanged(_str_FullName, c)) {
                  m.Add(_str_FullName, o.ObjectIdent + _str_FullName, o.ObjectIdent2 + _str_FullName, o.ObjectIdent3 + _str_FullName, "string", o.FullName == null ? "" : o.FullName.ToString(), o.IsReadOnly(_str_FullName), o.IsInvisible(_str_FullName), o.IsRequired(_str_FullName));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_IsReadOnlyParent, _formname = _str_IsReadOnlyParent, _type = "bool",
              _get_func = o => o.IsReadOnlyParent,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.IsReadOnlyParent != c.IsReadOnlyParent || o.IsRIRPropChanged(_str_IsReadOnlyParent, c)) {
                  m.Add(_str_IsReadOnlyParent, o.ObjectIdent + _str_IsReadOnlyParent, o.ObjectIdent2 + _str_IsReadOnlyParent, o.ObjectIdent3 + _str_IsReadOnlyParent, "bool", o.IsReadOnlyParent == null ? "" : o.IsReadOnlyParent.ToString(), o.IsReadOnly(_str_IsReadOnlyParent), o.IsInvisible(_str_IsReadOnlyParent), o.IsRequired(_str_IsReadOnlyParent));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyCountry, _formname = _str_strReadOnlyCountry, _type = "string",
              _get_func = o => o.strReadOnlyCountry,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyCountry != c.strReadOnlyCountry || o.IsRIRPropChanged(_str_strReadOnlyCountry, c)) {
                  m.Add(_str_strReadOnlyCountry, o.ObjectIdent + _str_strReadOnlyCountry, o.ObjectIdent2 + _str_strReadOnlyCountry, o.ObjectIdent3 + _str_strReadOnlyCountry, "string", o.strReadOnlyCountry == null ? "" : o.strReadOnlyCountry.ToString(), o.IsReadOnly(_str_strReadOnlyCountry), o.IsInvisible(_str_strReadOnlyCountry), o.IsRequired(_str_strReadOnlyCountry));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyRegion, _formname = _str_strReadOnlyRegion, _type = "string",
              _get_func = o => o.strReadOnlyRegion,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyRegion != c.strReadOnlyRegion || o.IsRIRPropChanged(_str_strReadOnlyRegion, c)) {
                  m.Add(_str_strReadOnlyRegion, o.ObjectIdent + _str_strReadOnlyRegion, o.ObjectIdent2 + _str_strReadOnlyRegion, o.ObjectIdent3 + _str_strReadOnlyRegion, "string", o.strReadOnlyRegion == null ? "" : o.strReadOnlyRegion.ToString(), o.IsReadOnly(_str_strReadOnlyRegion), o.IsInvisible(_str_strReadOnlyRegion), o.IsRequired(_str_strReadOnlyRegion));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyRayon, _formname = _str_strReadOnlyRayon, _type = "string",
              _get_func = o => o.strReadOnlyRayon,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyRayon != c.strReadOnlyRayon || o.IsRIRPropChanged(_str_strReadOnlyRayon, c)) {
                  m.Add(_str_strReadOnlyRayon, o.ObjectIdent + _str_strReadOnlyRayon, o.ObjectIdent2 + _str_strReadOnlyRayon, o.ObjectIdent3 + _str_strReadOnlyRayon, "string", o.strReadOnlyRayon == null ? "" : o.strReadOnlyRayon.ToString(), o.IsReadOnly(_str_strReadOnlyRayon), o.IsInvisible(_str_strReadOnlyRayon), o.IsRequired(_str_strReadOnlyRayon));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strReadOnlySettlement, _formname = _str_strReadOnlySettlement, _type = "string",
              _get_func = o => o.strReadOnlySettlement,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlySettlement != c.strReadOnlySettlement || o.IsRIRPropChanged(_str_strReadOnlySettlement, c)) {
                  m.Add(_str_strReadOnlySettlement, o.ObjectIdent + _str_strReadOnlySettlement, o.ObjectIdent2 + _str_strReadOnlySettlement, o.ObjectIdent3 + _str_strReadOnlySettlement, "string", o.strReadOnlySettlement == null ? "" : o.strReadOnlySettlement.ToString(), o.IsReadOnly(_str_strReadOnlySettlement), o.IsInvisible(_str_strReadOnlySettlement), o.IsRequired(_str_strReadOnlySettlement));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyStreet, _formname = _str_strReadOnlyStreet, _type = "string",
              _get_func = o => o.strReadOnlyStreet,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyStreet != c.strReadOnlyStreet || o.IsRIRPropChanged(_str_strReadOnlyStreet, c)) {
                  m.Add(_str_strReadOnlyStreet, o.ObjectIdent + _str_strReadOnlyStreet, o.ObjectIdent2 + _str_strReadOnlyStreet, o.ObjectIdent3 + _str_strReadOnlyStreet, "string", o.strReadOnlyStreet == null ? "" : o.strReadOnlyStreet.ToString(), o.IsReadOnly(_str_strReadOnlyStreet), o.IsInvisible(_str_strReadOnlyStreet), o.IsRequired(_str_strReadOnlyStreet));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyPostCode, _formname = _str_strReadOnlyPostCode, _type = "string",
              _get_func = o => o.strReadOnlyPostCode,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyPostCode != c.strReadOnlyPostCode || o.IsRIRPropChanged(_str_strReadOnlyPostCode, c)) {
                  m.Add(_str_strReadOnlyPostCode, o.ObjectIdent + _str_strReadOnlyPostCode, o.ObjectIdent2 + _str_strReadOnlyPostCode, o.ObjectIdent3 + _str_strReadOnlyPostCode, "string", o.strReadOnlyPostCode == null ? "" : o.strReadOnlyPostCode.ToString(), o.IsReadOnly(_str_strReadOnlyPostCode), o.IsInvisible(_str_strReadOnlyPostCode), o.IsRequired(_str_strReadOnlyPostCode));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyBuilding, _formname = _str_strReadOnlyBuilding, _type = "string",
              _get_func = o => o.strReadOnlyBuilding,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyBuilding != c.strReadOnlyBuilding || o.IsRIRPropChanged(_str_strReadOnlyBuilding, c)) {
                  m.Add(_str_strReadOnlyBuilding, o.ObjectIdent + _str_strReadOnlyBuilding, o.ObjectIdent2 + _str_strReadOnlyBuilding, o.ObjectIdent3 + _str_strReadOnlyBuilding, "string", o.strReadOnlyBuilding == null ? "" : o.strReadOnlyBuilding.ToString(), o.IsReadOnly(_str_strReadOnlyBuilding), o.IsInvisible(_str_strReadOnlyBuilding), o.IsRequired(_str_strReadOnlyBuilding));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyApartment, _formname = _str_strReadOnlyApartment, _type = "string",
              _get_func = o => o.strReadOnlyApartment,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyApartment != c.strReadOnlyApartment || o.IsRIRPropChanged(_str_strReadOnlyApartment, c)) {
                  m.Add(_str_strReadOnlyApartment, o.ObjectIdent + _str_strReadOnlyApartment, o.ObjectIdent2 + _str_strReadOnlyApartment, o.ObjectIdent3 + _str_strReadOnlyApartment, "string", o.strReadOnlyApartment == null ? "" : o.strReadOnlyApartment.ToString(), o.IsReadOnly(_str_strReadOnlyApartment), o.IsInvisible(_str_strReadOnlyApartment), o.IsRequired(_str_strReadOnlyApartment));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyHouse, _formname = _str_strReadOnlyHouse, _type = "string",
              _get_func = o => o.strReadOnlyHouse,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyHouse != c.strReadOnlyHouse || o.IsRIRPropChanged(_str_strReadOnlyHouse, c)) {
                  m.Add(_str_strReadOnlyHouse, o.ObjectIdent + _str_strReadOnlyHouse, o.ObjectIdent2 + _str_strReadOnlyHouse, o.ObjectIdent3 + _str_strReadOnlyHouse, "string", o.strReadOnlyHouse == null ? "" : o.strReadOnlyHouse.ToString(), o.IsReadOnly(_str_strReadOnlyHouse), o.IsInvisible(_str_strReadOnlyHouse), o.IsRequired(_str_strReadOnlyHouse));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyFullName, _formname = _str_strReadOnlyFullName, _type = "string",
              _get_func = o => o.strReadOnlyFullName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyFullName != c.strReadOnlyFullName || o.IsRIRPropChanged(_str_strReadOnlyFullName, c)) {
                  m.Add(_str_strReadOnlyFullName, o.ObjectIdent + _str_strReadOnlyFullName, o.ObjectIdent2 + _str_strReadOnlyFullName, o.ObjectIdent3 + _str_strReadOnlyFullName, "string", o.strReadOnlyFullName == null ? "" : o.strReadOnlyFullName.ToString(), o.IsReadOnly(_str_strReadOnlyFullName), o.IsInvisible(_str_strReadOnlyFullName), o.IsRequired(_str_strReadOnlyFullName));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyAdaptiveFullName, _formname = _str_strReadOnlyAdaptiveFullName, _type = "string",
              _get_func = o => o.strReadOnlyAdaptiveFullName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyAdaptiveFullName != c.strReadOnlyAdaptiveFullName || o.IsRIRPropChanged(_str_strReadOnlyAdaptiveFullName, c)) {
                  m.Add(_str_strReadOnlyAdaptiveFullName, o.ObjectIdent + _str_strReadOnlyAdaptiveFullName, o.ObjectIdent2 + _str_strReadOnlyAdaptiveFullName, o.ObjectIdent3 + _str_strReadOnlyAdaptiveFullName, "string", o.strReadOnlyAdaptiveFullName == null ? "" : o.strReadOnlyAdaptiveFullName.ToString(), o.IsReadOnly(_str_strReadOnlyAdaptiveFullName), o.IsInvisible(_str_strReadOnlyAdaptiveFullName), o.IsRequired(_str_strReadOnlyAdaptiveFullName));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Country, _formname = _str_Country, _type = "Lookup",
              _get_func = o => { if (o.Country == null) return null; return o.Country.idfsCountry; },
              _set_func = (o, val) => { o.Country = o.CountryLookup.Where(c => c.idfsCountry.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_Country, c)) {
                  m.Add(_str_Country, o.ObjectIdent + _str_Country, o.ObjectIdent2 + _str_Country, o.ObjectIdent3 + _str_Country, "Lookup", o.idfsCountry == null ? "" : o.idfsCountry.ToString(), o.IsReadOnly(_str_Country), o.IsInvisible(_str_Country), o.IsRequired(_str_Country)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Country + "Lookup", _formname = _str_Country + "Lookup", _type = "LookupContent",
              _get_func = o => o.CountryLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Region, _formname = _str_Region, _type = "Lookup",
              _get_func = o => { if (o.Region == null) return null; return o.Region.idfsRegion; },
              _set_func = (o, val) => { o.Region = o.RegionLookup.Where(c => c.idfsRegion.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_Region, c)) {
                  m.Add(_str_Region, o.ObjectIdent + _str_Region, o.ObjectIdent2 + _str_Region, o.ObjectIdent3 + _str_Region, "Lookup", o.idfsRegion == null ? "" : o.idfsRegion.ToString(), o.IsReadOnly(_str_Region), o.IsInvisible(_str_Region), o.IsRequired(_str_Region)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Region + "Lookup", _formname = _str_Region + "Lookup", _type = "LookupContent",
              _get_func = o => o.RegionLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Rayon, _formname = _str_Rayon, _type = "Lookup",
              _get_func = o => { if (o.Rayon == null) return null; return o.Rayon.idfsRayon; },
              _set_func = (o, val) => { o.Rayon = o.RayonLookup.Where(c => c.idfsRayon.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_Rayon, c)) {
                  m.Add(_str_Rayon, o.ObjectIdent + _str_Rayon, o.ObjectIdent2 + _str_Rayon, o.ObjectIdent3 + _str_Rayon, "Lookup", o.idfsRayon == null ? "" : o.idfsRayon.ToString(), o.IsReadOnly(_str_Rayon), o.IsInvisible(_str_Rayon), o.IsRequired(_str_Rayon)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Rayon + "Lookup", _formname = _str_Rayon + "Lookup", _type = "LookupContent",
              _get_func = o => o.RayonLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Settlement, _formname = _str_Settlement, _type = "Lookup",
              _get_func = o => { if (o.Settlement == null) return null; return o.Settlement.idfsSettlement; },
              _set_func = (o, val) => { o.Settlement = o.SettlementLookup.Where(c => c.idfsSettlement.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_Settlement, c)) {
                  m.Add(_str_Settlement, o.ObjectIdent + _str_Settlement, o.ObjectIdent2 + _str_Settlement, o.ObjectIdent3 + _str_Settlement, "Lookup", o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(), o.IsReadOnly(_str_Settlement), o.IsInvisible(_str_Settlement), o.IsRequired(_str_Settlement)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Settlement + "Lookup", _formname = _str_Settlement + "Lookup", _type = "LookupContent",
              _get_func = o => o.SettlementLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Street, _formname = _str_Street + "_input", _type = "Lookup",
              _get_func = o => o.strStreetName,
              _set_func = (o, val) => { o.strStreetName = val; },
              _compare_func = (o, c, m) => {
                if (o.strStreetName != c.strStreetName || o.IsRIRPropChanged(_str_Street, c)) {
                  m.Add(_str_Street, o.ObjectIdent + _str_Street, o.ObjectIdent2 + _str_Street, o.ObjectIdent3 + _str_Street, "Lookup", o.strStreetName == null ? "" : o.strStreetName.ToString(), o.IsReadOnly(_str_Street), o.IsInvisible(_str_Street), o.IsRequired(_str_Street)); 
                  }
                }
              },
        
            new field_info {
              _name = _str_PostCode, _formname = _str_PostCode + "_input", _type = "Lookup",
              _get_func = o => o.strPostCode,
              _set_func = (o, val) => { o.strPostCode = val; },
              _compare_func = (o, c, m) => {
                if (o.strPostCode != c.strPostCode || o.IsRIRPropChanged(_str_PostCode, c)) {
                  m.Add(_str_PostCode, o.ObjectIdent + _str_PostCode, o.ObjectIdent2 + _str_PostCode, o.ObjectIdent3 + _str_PostCode, "Lookup", o.strPostCode == null ? "" : o.strPostCode.ToString(), o.IsReadOnly(_str_PostCode), o.IsInvisible(_str_PostCode), o.IsRequired(_str_PostCode)); 
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
            Address obj = (Address)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Country)]
        [Relation(typeof(CountryLookup), eidss.model.Schema.CountryLookup._str_idfsCountry, _str_idfsCountry)]
        public CountryLookup Country
        {
            get { return _Country; }
            set 
            { 
                var oldVal = _Country;
                _Country = value;
                if (_Country != oldVal)
                {
                    if (idfsCountry != (_Country == null
                            ? new Int64?()
                            : (Int64?)_Country.idfsCountry))
                        idfsCountry = _Country == null 
                            ? new Int64?()
                            : (Int64?)_Country.idfsCountry; 
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
        [Relation(typeof(RegionLookup), eidss.model.Schema.RegionLookup._str_idfsRegion, _str_idfsRegion)]
        public RegionLookup Region
        {
            get { return _Region == null ? null : ((long)_Region.Key == 0 ? null : _Region); }
            set 
            { 
                var oldVal = _Region;
                _Region = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Region != oldVal)
                {
                    if (idfsRegion != (_Region == null
                            ? new Int64?()
                            : (Int64?)_Region.idfsRegion))
                        idfsRegion = _Region == null 
                            ? new Int64?()
                            : (Int64?)_Region.idfsRegion; 
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
        [Relation(typeof(RayonLookup), eidss.model.Schema.RayonLookup._str_idfsRayon, _str_idfsRayon)]
        public RayonLookup Rayon
        {
            get { return _Rayon == null ? null : ((long)_Rayon.Key == 0 ? null : _Rayon); }
            set 
            { 
                var oldVal = _Rayon;
                _Rayon = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Rayon != oldVal)
                {
                    if (idfsRayon != (_Rayon == null
                            ? new Int64?()
                            : (Int64?)_Rayon.idfsRayon))
                        idfsRayon = _Rayon == null 
                            ? new Int64?()
                            : (Int64?)_Rayon.idfsRayon; 
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
        [Relation(typeof(SettlementLookup), eidss.model.Schema.SettlementLookup._str_idfsSettlement, _str_idfsSettlement)]
        public SettlementLookup Settlement
        {
            get { return _Settlement == null ? null : ((long)_Settlement.Key == 0 ? null : _Settlement); }
            set 
            { 
                var oldVal = _Settlement;
                _Settlement = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Settlement != oldVal)
                {
                    if (idfsSettlement != (_Settlement == null
                            ? new Int64?()
                            : (Int64?)_Settlement.idfsSettlement))
                        idfsSettlement = _Settlement == null 
                            ? new Int64?()
                            : (Int64?)_Settlement.idfsSettlement; 
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
            
        [LocalizedDisplayName(_str_Street)]
        [Relation(typeof(StreetLookup), eidss.model.Schema.StreetLookup._str_strStreetName, _str_strStreetName)]
        public StreetLookup Street
        {
            get { return _Street; }
            set 
            { 
                var oldVal = _Street;
                _Street = value;
                if (_Street != oldVal)
                {
                    if (strStreetName != (_Street == null
                            ? strStreetName
                            : (String)_Street.strStreetName))
                        strStreetName = _Street == null 
                            ? strStreetName
                            : (String)_Street.strStreetName; 
                    OnPropertyChanged(_str_Street); 
                }
            }
        }
        private StreetLookup _Street;

        
        public List<StreetLookup> StreetLookup
        {
            get { return _StreetLookup; }
        }
        private List<StreetLookup> _StreetLookup = new List<StreetLookup>();
            
        [LocalizedDisplayName(_str_PostCode)]
        [Relation(typeof(PostalCodeLookup), eidss.model.Schema.PostalCodeLookup._str_strPostCode, _str_strPostCode)]
        public PostalCodeLookup PostCode
        {
            get { return _PostCode; }
            set 
            { 
                var oldVal = _PostCode;
                _PostCode = value;
                if (_PostCode != oldVal)
                {
                    if (strPostCode != (_PostCode == null
                            ? strPostCode
                            : (String)_PostCode.strPostCode))
                        strPostCode = _PostCode == null 
                            ? strPostCode
                            : (String)_PostCode.strPostCode; 
                    OnPropertyChanged(_str_PostCode); 
                }
            }
        }
        private PostalCodeLookup _PostCode;

        
        public List<PostalCodeLookup> PostCodeLookup
        {
            get { return _PostCodeLookup; }
        }
        private List<PostalCodeLookup> _PostCodeLookup = new List<PostalCodeLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Country:
                    return new BvSelectList(CountryLookup, eidss.model.Schema.CountryLookup._str_idfsCountry, null, Country, _str_idfsCountry);
            
                case _str_Region:
                    return new BvSelectList(RegionLookup, eidss.model.Schema.RegionLookup._str_idfsRegion, null, Region, _str_idfsRegion);
            
                case _str_Rayon:
                    return new BvSelectList(RayonLookup, eidss.model.Schema.RayonLookup._str_idfsRayon, null, Rayon, _str_idfsRayon);
            
                case _str_Settlement:
                    return new BvSelectList(SettlementLookup, eidss.model.Schema.SettlementLookup._str_idfsSettlement, null, Settlement, _str_idfsSettlement);
            
                case _str_Street:
                    return new BvSelectList(StreetLookup, eidss.model.Schema.StreetLookup._str_strStreetName, null, Street, _str_strStreetName);
            
                case _str_PostCode:
                    return new BvSelectList(PostCodeLookup, eidss.model.Schema.PostalCodeLookup._str_strPostCode, null, PostCode, _str_strPostCode);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_HCase)]
        public HumanCase HCase
        {
            get { return new Func<Address, HumanCase>(c => c.Parent is Patient ? (c.Parent as Patient).Parent as HumanCase : c.Parent is HumanCase ? c.Parent as HumanCase : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_VCase)]
        public VetCase VCase
        {
            get { return new Func<Address, VetCase>(c => c.Parent is FarmPanel ? (c.Parent as FarmPanel).Parent as VetCase : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_FPanel)]
        public FarmPanel FPanel
        {
            get { return new Func<Address, FarmPanel>(c => c.Parent is FarmPanel ? c.Parent as FarmPanel : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_FullName)]
        public string FullName
        {
            get { return new Func<Address, string>(c => c.strAddressStringTranslate)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsReadOnlyParent)]
        public bool IsReadOnlyParent
        {
            get { return new Func<Address, bool>(c => c.HCase == null ? (c.FPanel == null ? (c.VCase == null ? false : c.VCase.IsClosed || c.VCase.ReadOnly) : c.FPanel.IsReadOnlyParent || c.FPanel.IsReadOnlyByPermissions) : c.HCase.IsClosed || c.HCase.ReadOnly)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyCountry)]
        public string strReadOnlyCountry
        {
            get { return new Func<Address, string>(c => c.idfsCountry == null ? (string)null : c.Country.strCountryName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyRegion)]
        public string strReadOnlyRegion
        {
            get { return new Func<Address, string>(c => c.idfsRegion == null ? (string)null : c.Region.strRegionName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyRayon)]
        public string strReadOnlyRayon
        {
            get { return new Func<Address, string>(c => c.idfsRayon == null ? (string)null : c.Rayon.strRayonName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlySettlement)]
        public string strReadOnlySettlement
        {
            get { return new Func<Address, string>(c => c.idfsSettlement == null ? (string)null : c.Settlement.strSettlementName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyStreet)]
        public string strReadOnlyStreet
        {
            get { return new Func<Address, string>(c => c.strStreetName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyPostCode)]
        public string strReadOnlyPostCode
        {
            get { return new Func<Address, string>(c => c.strPostCode)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyBuilding)]
        public string strReadOnlyBuilding
        {
            get { return new Func<Address, string>(c => c.strBuilding)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyApartment)]
        public string strReadOnlyApartment
        {
            get { return new Func<Address, string>(c => c.strApartment)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyHouse)]
        public string strReadOnlyHouse
        {
            get { return new Func<Address, string>(c => c.strHouse)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyFullName)]
        public string strReadOnlyFullName
        {
            get { return new Func<Address, string>(c => c.strAddressStringTranslate)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyAdaptiveFullName)]
        public string strReadOnlyAdaptiveFullName
        {
            get { return new Func<Address, string>(c => c.IsDirty ? c.CreateAddressString() : c.strAddressStringTranslate)(this); }
            
        }
        
          [LocalizedDisplayName(_str_blnGeoLocationShared)]
        public bool blnGeoLocationShared
        {
            get { return m_blnGeoLocationShared; }
            set { if (m_blnGeoLocationShared != value) { m_blnGeoLocationShared = value; OnPropertyChanged(_str_blnGeoLocationShared); } }
        }
        private bool m_blnGeoLocationShared;
        
          [LocalizedDisplayName(_str_blnReadOnlyRegion)]
        public bool blnReadOnlyRegion
        {
            get { return m_blnReadOnlyRegion; }
            set { if (m_blnReadOnlyRegion != value) { m_blnReadOnlyRegion = value; OnPropertyChanged(_str_blnReadOnlyRegion); } }
        }
        private bool m_blnReadOnlyRegion;
        
          [LocalizedDisplayName(_str_bCancelCoordinationValidation)]
        public bool bCancelCoordinationValidation
        {
            get { return m_bCancelCoordinationValidation; }
            set { if (m_bCancelCoordinationValidation != value) { m_bCancelCoordinationValidation = value; OnPropertyChanged(_str_bCancelCoordinationValidation); } }
        }
        private bool m_bCancelCoordinationValidation;
        
          [LocalizedDisplayName(_str_blnNeedForeignAddressStr)]
        public bool blnNeedForeignAddressStr
        {
            get { return m_blnNeedForeignAddressStr; }
            set { if (m_blnNeedForeignAddressStr != value) { m_blnNeedForeignAddressStr = value; OnPropertyChanged(_str_blnNeedForeignAddressStr); } }
        }
        private bool m_blnNeedForeignAddressStr;
        
          [LocalizedDisplayName(_str_blnForceReadOnly)]
        public bool blnForceReadOnly
        {
            get { return m_blnForceReadOnly; }
            set { if (m_blnForceReadOnly != value) { m_blnForceReadOnly = value; OnPropertyChanged(_str_blnForceReadOnly); } }
        }
        private bool m_blnForceReadOnly;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "Address";

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
            var ret = base.Clone() as Address;
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
            var ret = base.Clone() as Address;
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
        public Address CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Address;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfGeoLocation; } }
        public string KeyName { get { return "idfGeoLocation"; } }
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
            var _prev_idfsRegion_Region = idfsRegion;
            var _prev_idfsRayon_Rayon = idfsRayon;
            var _prev_idfsSettlement_Settlement = idfsSettlement;
            base.RejectChanges();
        
            if (_prev_idfsCountry_Country != idfsCountry)
            {
                _Country = _CountryLookup.FirstOrDefault(c => c.idfsCountry == idfsCountry);
            }
            if (_prev_idfsRegion_Region != idfsRegion)
            {
                _Region = _RegionLookup.FirstOrDefault(c => c.idfsRegion == idfsRegion);
            }
            if (_prev_idfsRayon_Rayon != idfsRayon)
            {
                _Rayon = _RayonLookup.FirstOrDefault(c => c.idfsRayon == idfsRayon);
            }
            if (_prev_idfsSettlement_Settlement != idfsSettlement)
            {
                _Settlement = _SettlementLookup.FirstOrDefault(c => c.idfsSettlement == idfsSettlement);
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

        private bool IsRIRPropChanged(string fld, Address c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public Address()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Address_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Address_PropertyChanged);
        }
        private void Address_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Address).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_HCase);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_VCase);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_FPanel);
                  
            if (e.PropertyName == _str_HCase)
                OnPropertyChanged(_str_IsReadOnlyParent);
                  
            if (e.PropertyName == _str_idfsCountry)
                OnPropertyChanged(_str_strReadOnlyCountry);
                  
            if (e.PropertyName == _str_idfsRegion)
                OnPropertyChanged(_str_strReadOnlyRegion);
                  
            if (e.PropertyName == _str_idfsRayon)
                OnPropertyChanged(_str_strReadOnlyRayon);
                  
            if (e.PropertyName == _str_idfsSettlement)
                OnPropertyChanged(_str_strReadOnlySettlement);
                  
            if (e.PropertyName == _str_strStreetName)
                OnPropertyChanged(_str_strReadOnlyStreet);
                  
            if (e.PropertyName == _str_strPostCode)
                OnPropertyChanged(_str_strReadOnlyPostCode);
                  
            if (e.PropertyName == _str_strBuilding)
                OnPropertyChanged(_str_strReadOnlyBuilding);
                  
            if (e.PropertyName == _str_strApartment)
                OnPropertyChanged(_str_strReadOnlyApartment);
                  
            if (e.PropertyName == _str_strHouse)
                OnPropertyChanged(_str_strReadOnlyHouse);
                  
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
            Address obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Address obj = this;
            
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
    
        private static string[] invisible_names1 = "strForeignAddress".Split(new char[] { ',' });
        
        private bool _isInvisible(string name)
        {
            
            if (invisible_names1.Where(c => c == name).Count() > 0)
                return new Func<Address, bool>(c => c.idfsCountry != null && c.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID)(this);
            
            return new Func<Address, bool>(c => false)(this);
                
        }

    
        private static string[] readonly_names1 = "strReadOnlyCountry,strReadOnlyRegion,strReadOnlyRayon,strReadOnlySettlement".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strReadOnlyStreet,strReadOnlyPostCode".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "strReadOnlyBuilding,strReadOnlyApartment,strReadOnlyHouse".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "strReadOnlyFullName,strReadOnlyAdaptiveFullName".Split(new char[] { ',' });
        
        private static string[] readonly_names5 = "Country,idfsCountry".Split(new char[] { ',' });
        
        private static string[] readonly_names6 = "Region,idfsRegion".Split(new char[] { ',' });
        
        private static string[] readonly_names7 = "Rayon,idfsRayon".Split(new char[] { ',' });
        
        private static string[] readonly_names8 = "Settlement,idfsSettlement".Split(new char[] { ',' });
        
        private static string[] readonly_names9 = "Street,strStreetName,PostCode,strPostCode,strHouse,strBuilding,strApartment".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Address, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Address, bool>(c => true)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Address, bool>(c => true)(this);
            
            if (readonly_names4.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Address, bool>(c => true)(this);
            
            if (readonly_names5.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Address, bool>(c => c.IsReadOnlyParent || c.blnForceReadOnly || c.IsHiddenPersonalData("Street"))(this);
            
            if (readonly_names6.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Address, bool>(c => c.IsReadOnlyParent || c.blnForceReadOnly || c.IsHiddenPersonalData("Street") || blnNeedForeignAddressStr && c.idfsCountry != null && c.idfsCountry != eidss.model.Core.EidssSiteContext.Instance.CountryID || blnReadOnlyRegion || c.idfsCountry == null)(this);
            
            if (readonly_names7.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Address, bool>(c => c.IsReadOnlyParent || c.blnForceReadOnly || c.IsHiddenPersonalData("Street") || c.idfsRegion == null)(this);
            
            if (readonly_names8.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Address, bool>(c => c.IsReadOnlyParent || c.blnForceReadOnly || c.IsHiddenPersonalData("Street") || c.idfsRayon == null)(this);
            
            if (readonly_names9.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Address, bool>(c => c.IsReadOnlyParent || c.blnForceReadOnly || c.idfsSettlement == null)(this);
            
            return ReadOnly || new Func<Address, bool>(c => c.IsReadOnlyParent || c.blnForceReadOnly)(this);
                
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


        internal Dictionary<string, Func<Address, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<Address, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Address, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Address, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<Address, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<Address, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<Address, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~Address()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("CountryLookup", this);
                
                LookupManager.RemoveObject("RegionLookup", this);
                
                LookupManager.RemoveObject("RayonLookup", this);
                
                LookupManager.RemoveObject("SettlementLookup", this);
                
                LookupManager.RemoveObject("StreetLookup", this);
                
                LookupManager.RemoveObject("PostalCodeLookup", this);
                
            }
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
            
            if (lookup_object == "StreetLookup")
                _getAccessor().LoadLookup_Street(manager, this);
            
            if (lookup_object == "PostalCodeLookup")
                _getAccessor().LoadLookup_PostCode(manager, this);
            
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
        : DataAccessor<Address>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<Address>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<Address>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfGeoLocation"; } }
            #endregion
        
            private delegate void on_action(Address obj);
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
            private StreetLookup.Accessor StreetAccessor { get { return eidss.model.Schema.StreetLookup.Accessor.Instance(m_CS); } }
            private PostalCodeLookup.Accessor PostCodeAccessor { get { return eidss.model.Schema.PostalCodeLookup.Accessor.Instance(m_CS); } }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual Address SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual Address SelectByKey(DbManagerProxy manager
                , Int64? idfAddress
                )
            {
                return _SelectByKey(manager
                    , idfAddress
                    , null, null
                    );
            }
            
      
            private Address _SelectByKey(DbManagerProxy manager
                , Int64? idfAddress
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<Address> objs = new List<Address>();
                sets[0] = new MapResultSet(typeof(Address), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spAddress_SelectDetail"
                            , manager.Parameter("@idfAddress", idfAddress)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    Address obj = objs[0];
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, Address obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, Address obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private Address _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    Address obj = Address.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfGeoLocation = (new GetNewIDExtender<Address>()).GetScalar(manager, obj, isFake);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.Country = new Func<Address, CountryLookup>(c => 
                                     c.CountryLookup.Where(a => a.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID)
                                     .SingleOrDefault())(obj);
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

            
            public Address CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public Address CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public Address CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(Address obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Address obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.Region = (new SetScalarHandler()).Handler(obj,
                    obj.idfsCountry, obj.idfsCountry_Previous, obj.Region,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.Rayon = (new SetScalarHandler()).Handler(obj,
                    obj.idfsRegion, obj.idfsRegion_Previous, obj.Rayon,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                obj.Settlement = (new SetScalarHandler()).Handler(obj,
                    obj.idfsRayon, obj.idfsRayon_Previous, obj.Settlement,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsSettlement)
                        {
                    
                obj.Street = (new SetScalarHandler()).Handler(obj,
                    obj.idfsSettlement, obj.idfsSettlement_Previous, obj.Street,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsSettlement)
                        {
                    
                obj.PostCode = (new SetScalarHandler()).Handler(obj,
                    obj.idfsSettlement, obj.idfsSettlement_Previous, obj.PostCode,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsSettlement)
                        {
                    
                obj.strStreetName = (new SetScalarHandler()).Handler(obj,
                    obj.idfsSettlement, obj.idfsSettlement_Previous, obj.strStreetName,
                    (o, fld, prev_fld) => "");
            
                        }
                    
                        if (e.PropertyName == _str_idfsSettlement)
                        {
                    
                obj.strPostCode = (new SetScalarHandler()).Handler(obj,
                    obj.idfsSettlement, obj.idfsSettlement_Previous, obj.strPostCode,
                    (o, fld, prev_fld) => "");
            
                        }
                    
                        if (e.PropertyName == _str_idfsSettlement)
                        {
                    
                obj.strHouse = (new SetScalarHandler()).Handler(obj,
                    obj.idfsSettlement, obj.idfsSettlement_Previous, obj.strHouse,
                    (o, fld, prev_fld) => "");
            
                        }
                    
                        if (e.PropertyName == _str_idfsSettlement)
                        {
                    
                obj.strBuilding = (new SetScalarHandler()).Handler(obj,
                    obj.idfsSettlement, obj.idfsSettlement_Previous, obj.strBuilding,
                    (o, fld, prev_fld) => "");
            
                        }
                    
                        if (e.PropertyName == _str_idfsSettlement)
                        {
                    
                obj.strApartment = (new SetScalarHandler()).Handler(obj,
                    obj.idfsSettlement, obj.idfsSettlement_Previous, obj.strApartment,
                    (o, fld, prev_fld) => "");
            
                        }
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.strForeignAddress = (new SetScalarHandler()).Handler(obj,
                    obj.idfsCountry, obj.idfsCountry_Previous, obj.strForeignAddress,
                    (o, fld, prev_fld) => "");
            
                        }
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Region(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Rayon(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Settlement(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSettlement)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Street(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSettlement)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_PostCode(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.strForeignAddress = new Func<Address, string>(c => (c.idfsCountry != null && c.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID) ? null : c.strForeignAddress)(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Country(DbManagerProxy manager, Address obj)
            {
                
                obj.CountryLookup.Clear();
                
                obj.CountryLookup.AddRange(CountryAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsCountry == obj.idfsCountry))
                    
                    .ToList());
                
                if (obj.idfsCountry != null && obj.idfsCountry != 0)
                {
                    obj.Country = obj.CountryLookup
                        .SingleOrDefault(c => c.idfsCountry == obj.idfsCountry);
                    
                }
              
                
                LookupManager.AddObject("CountryLookup", obj, CountryAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Region(DbManagerProxy manager, Address obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<Address, long>(c => c.idfsCountry ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRegion == obj.idfsRegion))
                    
                    .ToList());
                
                if (obj.idfsRegion != null && obj.idfsRegion != 0)
                {
                    obj.Region = obj.RegionLookup
                        .SingleOrDefault(c => c.idfsRegion == obj.idfsRegion);
                    
                }
              
                
                LookupManager.AddObject("RegionLookup", obj, RegionAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Rayon(DbManagerProxy manager, Address obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<Address, long>(c => c.idfsRegion ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRayon == obj.idfsRayon))
                    
                    .ToList());
                
                if (obj.idfsRayon != null && obj.idfsRayon != 0)
                {
                    obj.Rayon = obj.RayonLookup
                        .SingleOrDefault(c => c.idfsRayon == obj.idfsRayon);
                    
                }
              
                
                LookupManager.AddObject("RayonLookup", obj, RayonAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Settlement(DbManagerProxy manager, Address obj)
            {
                
                obj.SettlementLookup.Clear();
                
                obj.SettlementLookup.Add(SettlementAccessor.CreateNewT(manager, null));
                
                obj.SettlementLookup.AddRange(SettlementAccessor.SelectLookupList(manager
                    
                    , new Func<Address, long>(c => c.idfsRayon ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSettlement == obj.idfsSettlement))
                    
                    .ToList());
                
                if (obj.idfsSettlement != null && obj.idfsSettlement != 0)
                {
                    obj.Settlement = obj.SettlementLookup
                        .SingleOrDefault(c => c.idfsSettlement == obj.idfsSettlement);
                    
                }
              
                
                LookupManager.AddObject("SettlementLookup", obj, SettlementAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Street(DbManagerProxy manager, Address obj)
            {
                
                obj.StreetLookup.Clear();
                
                obj.StreetLookup.Add(StreetAccessor.CreateNewT(manager, null));
                
                obj.StreetLookup.AddRange(StreetAccessor.SelectLookupList(manager
                    
                    , new Func<Address, long>(c => c.idfsSettlement ?? 0)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.strStreetName == obj.strStreetName))
                    
                    .ToList());
                
                if (!string.IsNullOrEmpty(obj.strStreetName))
                {
                    obj.Street = obj.StreetLookup
                        .SingleOrDefault(c => c.strStreetName == obj.strStreetName);
                    
                    if (obj.Street == null)
                    {
                        var a = StreetAccessor.CreateNewT(manager, null);
                        a.strStreetName = obj.strStreetName;
                        obj.StreetLookup.Add(a);
                        obj.Street = obj.StreetLookup
                            .SingleOrDefault(c => c.strStreetName == obj.strStreetName);
                    }
                    
                }
              
                
                LookupManager.AddObject("StreetLookup", obj, StreetAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_PostCode(DbManagerProxy manager, Address obj)
            {
                
                obj.PostCodeLookup.Clear();
                
                obj.PostCodeLookup.Add(PostCodeAccessor.CreateNewT(manager, null));
                
                obj.PostCodeLookup.AddRange(PostCodeAccessor.SelectLookupList(manager
                    
                    , new Func<Address, long>(c => c.idfsSettlement ?? 0)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.strPostCode == obj.strPostCode))
                    
                    .ToList());
                
                if (!string.IsNullOrEmpty(obj.strPostCode))
                {
                    obj.PostCode = obj.PostCodeLookup
                        .SingleOrDefault(c => c.strPostCode == obj.strPostCode);
                    
                    if (obj.PostCode == null)
                    {
                        var a = PostCodeAccessor.CreateNewT(manager, null);
                        a.strPostCode = obj.strPostCode;
                        obj.PostCodeLookup.Add(a);
                        obj.PostCode = obj.PostCodeLookup
                            .SingleOrDefault(c => c.strPostCode == obj.strPostCode);
                    }
                    
                }
              
                
                LookupManager.AddObject("PostalCodeLookup", obj, PostCodeAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, Address obj)
            {
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Settlement(manager, obj);
                
                LoadLookup_Street(manager, obj);
                
                LoadLookup_PostCode(manager, obj);
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spAddress_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] Address obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] Address obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    Address bo = obj as Address;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as Address, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, Address obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                obj.blnForeignAddress = new Func<Address, bool>(c => c.idfsCountry == null || c.idfsCountry != eidss.model.Core.EidssSiteContext.Instance.CountryID)(obj);
                    // posting extenters - end
            
                    if (!obj.IsMarkedToDelete && bHasChanges)
                        _postPredicate(manager, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(Address obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, Address obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(Address obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(Address obj, bool bRethrowException)
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
                return Validate(manager, obj as Address, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Address obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(Address obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(Address obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Address) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Address) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AddressDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spAddress_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spAddress_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Address, bool>> RequiredByField = new Dictionary<string, Func<Address, bool>>();
            public static Dictionary<string, Func<Address, bool>> RequiredByProperty = new Dictionary<string, Func<Address, bool>>();
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
                
                Sizes.Add(_str_strApartment, 200);
                Sizes.Add(_str_strBuilding, 200);
                Sizes.Add(_str_strHouse, 200);
                Sizes.Add(_str_strPostCode, 200);
                Sizes.Add(_str_strStreetName, 200);
                Sizes.Add(_str_strAddressStringTranslate, 2000);
                Sizes.Add(_str_strAddressDefaultString, 1000);
                Sizes.Add(_str_strForeignAddress, 200);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Address>().Post(manager, (Address)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Address>().Post(manager, (Address)c), c),
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
                    (manager, c, pars) => new ActResult(((Address)c).MarkToDelete() && ObjectAccessor.PostInterface<Address>().Post(manager, (Address)c), c),
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
	