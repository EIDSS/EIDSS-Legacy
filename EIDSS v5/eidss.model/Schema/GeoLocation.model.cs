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
    public abstract partial class GeoLocation : 
        EditableObject<GeoLocation>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfGeoLocation), NonUpdatable, PrimaryKey]
        public abstract Int64 idfGeoLocation { get; set; }
                
        [LocalizedDisplayName(_str_idfsResidentType)]
        [MapField(_str_idfsResidentType)]
        public abstract Int64? idfsResidentType { get; set; }
        #if MONO
        protected Int64? idfsResidentType_Original { get { return idfsResidentType; } }
        protected Int64? idfsResidentType_Previous { get { return idfsResidentType; } }
        #else
        protected Int64? idfsResidentType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsResidentType).OriginalValue; } }
        protected Int64? idfsResidentType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsResidentType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsGroundType)]
        [MapField(_str_idfsGroundType)]
        public abstract Int64? idfsGroundType { get; set; }
        #if MONO
        protected Int64? idfsGroundType_Original { get { return idfsGroundType; } }
        protected Int64? idfsGroundType_Previous { get { return idfsGroundType; } }
        #else
        protected Int64? idfsGroundType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGroundType).OriginalValue; } }
        protected Int64? idfsGroundType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGroundType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsGeoLocationType)]
        [MapField(_str_idfsGeoLocationType)]
        public abstract Int64? idfsGeoLocationType { get; set; }
        #if MONO
        protected Int64? idfsGeoLocationType_Original { get { return idfsGeoLocationType; } }
        protected Int64? idfsGeoLocationType_Previous { get { return idfsGeoLocationType; } }
        #else
        protected Int64? idfsGeoLocationType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGeoLocationType).OriginalValue; } }
        protected Int64? idfsGeoLocationType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGeoLocationType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCountry)]
        [MapField(_str_idfsCountry)]
        public abstract Int64? idfsCountry { get; set; }
        #if MONO
        protected Int64? idfsCountry_Original { get { return idfsCountry; } }
        protected Int64? idfsCountry_Previous { get { return idfsCountry; } }
        #else
        protected Int64? idfsCountry_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).OriginalValue; } }
        protected Int64? idfsCountry_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsRegion)]
        [MapField(_str_idfsRegion)]
        public abstract Int64? idfsRegion { get; set; }
        #if MONO
        protected Int64? idfsRegion_Original { get { return idfsRegion; } }
        protected Int64? idfsRegion_Previous { get { return idfsRegion; } }
        #else
        protected Int64? idfsRegion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).OriginalValue; } }
        protected Int64? idfsRegion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsRayon)]
        [MapField(_str_idfsRayon)]
        public abstract Int64? idfsRayon { get; set; }
        #if MONO
        protected Int64? idfsRayon_Original { get { return idfsRayon; } }
        protected Int64? idfsRayon_Previous { get { return idfsRayon; } }
        #else
        protected Int64? idfsRayon_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).OriginalValue; } }
        protected Int64? idfsRayon_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("GeoLocation.idfsSettlement")]
        [MapField(_str_idfsSettlement)]
        public abstract Int64? idfsSettlement { get; set; }
        #if MONO
        protected Int64? idfsSettlement_Original { get { return idfsSettlement; } }
        protected Int64? idfsSettlement_Previous { get { return idfsSettlement; } }
        #else
        protected Int64? idfsSettlement_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).OriginalValue; } }
        protected Int64? idfsSettlement_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64 idfsSite { get; set; }
        #if MONO
        protected Int64 idfsSite_Original { get { return idfsSite; } }
        protected Int64 idfsSite_Previous { get { return idfsSite; } }
        #else
        protected Int64 idfsSite_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64 idfsSite_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strPostCode)]
        [MapField(_str_strPostCode)]
        public abstract String strPostCode { get; set; }
        #if MONO
        protected String strPostCode_Original { get { return strPostCode; } }
        protected String strPostCode_Previous { get { return strPostCode; } }
        #else
        protected String strPostCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strPostCode).OriginalValue; } }
        protected String strPostCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPostCode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strStreetName)]
        [MapField(_str_strStreetName)]
        public abstract String strStreetName { get; set; }
        #if MONO
        protected String strStreetName_Original { get { return strStreetName; } }
        protected String strStreetName_Previous { get { return strStreetName; } }
        #else
        protected String strStreetName_Original { get { return ((EditableValue<String>)((dynamic)this)._strStreetName).OriginalValue; } }
        protected String strStreetName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strStreetName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strHouse)]
        [MapField(_str_strHouse)]
        public abstract String strHouse { get; set; }
        #if MONO
        protected String strHouse_Original { get { return strHouse; } }
        protected String strHouse_Previous { get { return strHouse; } }
        #else
        protected String strHouse_Original { get { return ((EditableValue<String>)((dynamic)this)._strHouse).OriginalValue; } }
        protected String strHouse_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHouse).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strBuilding)]
        [MapField(_str_strBuilding)]
        public abstract String strBuilding { get; set; }
        #if MONO
        protected String strBuilding_Original { get { return strBuilding; } }
        protected String strBuilding_Previous { get { return strBuilding; } }
        #else
        protected String strBuilding_Original { get { return ((EditableValue<String>)((dynamic)this)._strBuilding).OriginalValue; } }
        protected String strBuilding_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBuilding).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strApartment)]
        [MapField(_str_strApartment)]
        public abstract String strApartment { get; set; }
        #if MONO
        protected String strApartment_Original { get { return strApartment; } }
        protected String strApartment_Previous { get { return strApartment; } }
        #else
        protected String strApartment_Original { get { return ((EditableValue<String>)((dynamic)this)._strApartment).OriginalValue; } }
        protected String strApartment_Previous { get { return ((EditableValue<String>)((dynamic)this)._strApartment).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strDescription)]
        [MapField(_str_strDescription)]
        public abstract String strDescription { get; set; }
        #if MONO
        protected String strDescription_Original { get { return strDescription; } }
        protected String strDescription_Previous { get { return strDescription; } }
        #else
        protected String strDescription_Original { get { return ((EditableValue<String>)((dynamic)this)._strDescription).OriginalValue; } }
        protected String strDescription_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDescription).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_dblDistance)]
        [MapField(_str_dblDistance)]
        public abstract Double? dblDistance { get; set; }
        #if MONO
        protected Double? dblDistance_Original { get { return dblDistance; } }
        protected Double? dblDistance_Previous { get { return dblDistance; } }
        #else
        protected Double? dblDistance_Original { get { return ((EditableValue<Double?>)((dynamic)this)._dblDistance).OriginalValue; } }
        protected Double? dblDistance_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._dblDistance).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_dblLatitude)]
        [MapField(_str_dblLatitude)]
        public abstract Double? dblLatitude { get; set; }
        #if MONO
        protected Double? dblLatitude_Original { get { return dblLatitude; } }
        protected Double? dblLatitude_Previous { get { return dblLatitude; } }
        #else
        protected Double? dblLatitude_Original { get { return ((EditableValue<Double?>)((dynamic)this)._dblLatitude).OriginalValue; } }
        protected Double? dblLatitude_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._dblLatitude).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_dblLongitude)]
        [MapField(_str_dblLongitude)]
        public abstract Double? dblLongitude { get; set; }
        #if MONO
        protected Double? dblLongitude_Original { get { return dblLongitude; } }
        protected Double? dblLongitude_Previous { get { return dblLongitude; } }
        #else
        protected Double? dblLongitude_Original { get { return ((EditableValue<Double?>)((dynamic)this)._dblLongitude).OriginalValue; } }
        protected Double? dblLongitude_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._dblLongitude).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_dblRelLatitude)]
        [MapField(_str_dblRelLatitude)]
        public abstract Double? dblRelLatitude { get; set; }
        #if MONO
        protected Double? dblRelLatitude_Original { get { return dblRelLatitude; } }
        protected Double? dblRelLatitude_Previous { get { return dblRelLatitude; } }
        #else
        protected Double? dblRelLatitude_Original { get { return ((EditableValue<Double?>)((dynamic)this)._dblRelLatitude).OriginalValue; } }
        protected Double? dblRelLatitude_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._dblRelLatitude).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_dblRelLongitude)]
        [MapField(_str_dblRelLongitude)]
        public abstract Double? dblRelLongitude { get; set; }
        #if MONO
        protected Double? dblRelLongitude_Original { get { return dblRelLongitude; } }
        protected Double? dblRelLongitude_Previous { get { return dblRelLongitude; } }
        #else
        protected Double? dblRelLongitude_Original { get { return ((EditableValue<Double?>)((dynamic)this)._dblRelLongitude).OriginalValue; } }
        protected Double? dblRelLongitude_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._dblRelLongitude).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_dblAccuracy)]
        [MapField(_str_dblAccuracy)]
        public abstract Double? dblAccuracy { get; set; }
        #if MONO
        protected Double? dblAccuracy_Original { get { return dblAccuracy; } }
        protected Double? dblAccuracy_Previous { get { return dblAccuracy; } }
        #else
        protected Double? dblAccuracy_Original { get { return ((EditableValue<Double?>)((dynamic)this)._dblAccuracy).OriginalValue; } }
        protected Double? dblAccuracy_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._dblAccuracy).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_dblAlignment)]
        [MapField(_str_dblAlignment)]
        public abstract Double? dblAlignment { get; set; }
        #if MONO
        protected Double? dblAlignment_Original { get { return dblAlignment; } }
        protected Double? dblAlignment_Previous { get { return dblAlignment; } }
        #else
        protected Double? dblAlignment_Original { get { return ((EditableValue<Double?>)((dynamic)this)._dblAlignment).OriginalValue; } }
        protected Double? dblAlignment_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._dblAlignment).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strAddressStringTranslate)]
        [MapField(_str_strAddressStringTranslate)]
        public abstract String strAddressStringTranslate { get; set; }
        #if MONO
        protected String strAddressStringTranslate_Original { get { return strAddressStringTranslate; } }
        protected String strAddressStringTranslate_Previous { get { return strAddressStringTranslate; } }
        #else
        protected String strAddressStringTranslate_Original { get { return ((EditableValue<String>)((dynamic)this)._strAddressStringTranslate).OriginalValue; } }
        protected String strAddressStringTranslate_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAddressStringTranslate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strAddressDefaultString)]
        [MapField(_str_strAddressDefaultString)]
        public abstract String strAddressDefaultString { get; set; }
        #if MONO
        protected String strAddressDefaultString_Original { get { return strAddressDefaultString; } }
        protected String strAddressDefaultString_Previous { get { return strAddressDefaultString; } }
        #else
        protected String strAddressDefaultString_Original { get { return ((EditableValue<String>)((dynamic)this)._strAddressDefaultString).OriginalValue; } }
        protected String strAddressDefaultString_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAddressDefaultString).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<GeoLocation, object> _get_func;
            internal Action<GeoLocation, string> _set_func;
            internal Action<GeoLocation, GeoLocation, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfGeoLocation = "idfGeoLocation";
        internal const string _str_idfsResidentType = "idfsResidentType";
        internal const string _str_idfsGroundType = "idfsGroundType";
        internal const string _str_idfsGeoLocationType = "idfsGeoLocationType";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_strPostCode = "strPostCode";
        internal const string _str_strStreetName = "strStreetName";
        internal const string _str_strHouse = "strHouse";
        internal const string _str_strBuilding = "strBuilding";
        internal const string _str_strApartment = "strApartment";
        internal const string _str_strDescription = "strDescription";
        internal const string _str_dblDistance = "dblDistance";
        internal const string _str_dblLatitude = "dblLatitude";
        internal const string _str_dblLongitude = "dblLongitude";
        internal const string _str_dblRelLatitude = "dblRelLatitude";
        internal const string _str_dblRelLongitude = "dblRelLongitude";
        internal const string _str_dblAccuracy = "dblAccuracy";
        internal const string _str_dblAlignment = "dblAlignment";
        internal const string _str_strAddressStringTranslate = "strAddressStringTranslate";
        internal const string _str_strAddressDefaultString = "strAddressDefaultString";
        internal const string _str_VCase = "VCase";
        internal const string _str_IsReadOnlyParent = "IsReadOnlyParent";
        internal const string _str_blnGeoLocationShared = "blnGeoLocationShared";
        internal const string _str_bNeedCreateGeoLocationString = "bNeedCreateGeoLocationString";
        internal const string _str_bCancelCoordinationValidation = "bCancelCoordinationValidation";
        internal const string _str_FullName = "FullName";
        internal const string _str_IsNull = "IsNull";
        internal const string _str_strReadOnlyFullName = "strReadOnlyFullName";
        internal const string _str_strReadOnlyAdaptiveFullName = "strReadOnlyAdaptiveFullName";
        internal const string _str_strReadOnlyCountry = "strReadOnlyCountry";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Settlement = "Settlement";
        internal const string _str_Street = "Street";
        internal const string _str_PostCode = "PostCode";
        internal const string _str_ResidentType = "ResidentType";
        internal const string _str_GroundType = "GroundType";
        internal const string _str_GeoLocationType = "GeoLocationType";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfGeoLocation, _type = "Int64",
              _get_func = o => o.idfGeoLocation,
              _set_func = (o, val) => { o.idfGeoLocation = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfGeoLocation != c.idfGeoLocation || o.IsRIRPropChanged(_str_idfGeoLocation, c)) 
                  m.Add(_str_idfGeoLocation, o.ObjectIdent + _str_idfGeoLocation, "Int64", o.idfGeoLocation == null ? "" : o.idfGeoLocation.ToString(), o.IsReadOnly(_str_idfGeoLocation), o.IsInvisible(_str_idfGeoLocation), o.IsRequired(_str_idfGeoLocation)); }
              }, 
        
            new field_info {
              _name = _str_idfsResidentType, _type = "Int64?",
              _get_func = o => o.idfsResidentType,
              _set_func = (o, val) => { o.idfsResidentType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsResidentType != c.idfsResidentType || o.IsRIRPropChanged(_str_idfsResidentType, c)) 
                  m.Add(_str_idfsResidentType, o.ObjectIdent + _str_idfsResidentType, "Int64?", o.idfsResidentType == null ? "" : o.idfsResidentType.ToString(), o.IsReadOnly(_str_idfsResidentType), o.IsInvisible(_str_idfsResidentType), o.IsRequired(_str_idfsResidentType)); }
              }, 
        
            new field_info {
              _name = _str_idfsGroundType, _type = "Int64?",
              _get_func = o => o.idfsGroundType,
              _set_func = (o, val) => { o.idfsGroundType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsGroundType != c.idfsGroundType || o.IsRIRPropChanged(_str_idfsGroundType, c)) 
                  m.Add(_str_idfsGroundType, o.ObjectIdent + _str_idfsGroundType, "Int64?", o.idfsGroundType == null ? "" : o.idfsGroundType.ToString(), o.IsReadOnly(_str_idfsGroundType), o.IsInvisible(_str_idfsGroundType), o.IsRequired(_str_idfsGroundType)); }
              }, 
        
            new field_info {
              _name = _str_idfsGeoLocationType, _type = "Int64?",
              _get_func = o => o.idfsGeoLocationType,
              _set_func = (o, val) => { o.idfsGeoLocationType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsGeoLocationType != c.idfsGeoLocationType || o.IsRIRPropChanged(_str_idfsGeoLocationType, c)) 
                  m.Add(_str_idfsGeoLocationType, o.ObjectIdent + _str_idfsGeoLocationType, "Int64?", o.idfsGeoLocationType == null ? "" : o.idfsGeoLocationType.ToString(), o.IsReadOnly(_str_idfsGeoLocationType), o.IsInvisible(_str_idfsGeoLocationType), o.IsRequired(_str_idfsGeoLocationType)); }
              }, 
        
            new field_info {
              _name = _str_idfsCountry, _type = "Int64?",
              _get_func = o => o.idfsCountry,
              _set_func = (o, val) => { o.idfsCountry = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_idfsCountry, c)) 
                  m.Add(_str_idfsCountry, o.ObjectIdent + _str_idfsCountry, "Int64?", o.idfsCountry == null ? "" : o.idfsCountry.ToString(), o.IsReadOnly(_str_idfsCountry), o.IsInvisible(_str_idfsCountry), o.IsRequired(_str_idfsCountry)); }
              }, 
        
            new field_info {
              _name = _str_idfsRegion, _type = "Int64?",
              _get_func = o => o.idfsRegion,
              _set_func = (o, val) => { o.idfsRegion = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_idfsRegion, c)) 
                  m.Add(_str_idfsRegion, o.ObjectIdent + _str_idfsRegion, "Int64?", o.idfsRegion == null ? "" : o.idfsRegion.ToString(), o.IsReadOnly(_str_idfsRegion), o.IsInvisible(_str_idfsRegion), o.IsRequired(_str_idfsRegion)); }
              }, 
        
            new field_info {
              _name = _str_idfsRayon, _type = "Int64?",
              _get_func = o => o.idfsRayon,
              _set_func = (o, val) => { o.idfsRayon = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_idfsRayon, c)) 
                  m.Add(_str_idfsRayon, o.ObjectIdent + _str_idfsRayon, "Int64?", o.idfsRayon == null ? "" : o.idfsRayon.ToString(), o.IsReadOnly(_str_idfsRayon), o.IsInvisible(_str_idfsRayon), o.IsRequired(_str_idfsRayon)); }
              }, 
        
            new field_info {
              _name = _str_idfsSettlement, _type = "Int64?",
              _get_func = o => o.idfsSettlement,
              _set_func = (o, val) => { o.idfsSettlement = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_idfsSettlement, c)) 
                  m.Add(_str_idfsSettlement, o.ObjectIdent + _str_idfsSettlement, "Int64?", o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(), o.IsReadOnly(_str_idfsSettlement), o.IsInvisible(_str_idfsSettlement), o.IsRequired(_str_idfsSettlement)); }
              }, 
        
            new field_info {
              _name = _str_idfsSite, _type = "Int64",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { o.idfsSite = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_idfsSite, c)) 
                  m.Add(_str_idfsSite, o.ObjectIdent + _str_idfsSite, "Int64", o.idfsSite == null ? "" : o.idfsSite.ToString(), o.IsReadOnly(_str_idfsSite), o.IsInvisible(_str_idfsSite), o.IsRequired(_str_idfsSite)); }
              }, 
        
            new field_info {
              _name = _str_strPostCode, _type = "String",
              _get_func = o => o.strPostCode,
              _set_func = (o, val) => { o.strPostCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strPostCode != c.strPostCode || o.IsRIRPropChanged(_str_strPostCode, c)) 
                  m.Add(_str_strPostCode, o.ObjectIdent + _str_strPostCode, "String", o.strPostCode == null ? "" : o.strPostCode.ToString(), o.IsReadOnly(_str_strPostCode), o.IsInvisible(_str_strPostCode), o.IsRequired(_str_strPostCode)); }
              }, 
        
            new field_info {
              _name = _str_strStreetName, _type = "String",
              _get_func = o => o.strStreetName,
              _set_func = (o, val) => { o.strStreetName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strStreetName != c.strStreetName || o.IsRIRPropChanged(_str_strStreetName, c)) 
                  m.Add(_str_strStreetName, o.ObjectIdent + _str_strStreetName, "String", o.strStreetName == null ? "" : o.strStreetName.ToString(), o.IsReadOnly(_str_strStreetName), o.IsInvisible(_str_strStreetName), o.IsRequired(_str_strStreetName)); }
              }, 
        
            new field_info {
              _name = _str_strHouse, _type = "String",
              _get_func = o => o.strHouse,
              _set_func = (o, val) => { o.strHouse = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strHouse != c.strHouse || o.IsRIRPropChanged(_str_strHouse, c)) 
                  m.Add(_str_strHouse, o.ObjectIdent + _str_strHouse, "String", o.strHouse == null ? "" : o.strHouse.ToString(), o.IsReadOnly(_str_strHouse), o.IsInvisible(_str_strHouse), o.IsRequired(_str_strHouse)); }
              }, 
        
            new field_info {
              _name = _str_strBuilding, _type = "String",
              _get_func = o => o.strBuilding,
              _set_func = (o, val) => { o.strBuilding = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strBuilding != c.strBuilding || o.IsRIRPropChanged(_str_strBuilding, c)) 
                  m.Add(_str_strBuilding, o.ObjectIdent + _str_strBuilding, "String", o.strBuilding == null ? "" : o.strBuilding.ToString(), o.IsReadOnly(_str_strBuilding), o.IsInvisible(_str_strBuilding), o.IsRequired(_str_strBuilding)); }
              }, 
        
            new field_info {
              _name = _str_strApartment, _type = "String",
              _get_func = o => o.strApartment,
              _set_func = (o, val) => { o.strApartment = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strApartment != c.strApartment || o.IsRIRPropChanged(_str_strApartment, c)) 
                  m.Add(_str_strApartment, o.ObjectIdent + _str_strApartment, "String", o.strApartment == null ? "" : o.strApartment.ToString(), o.IsReadOnly(_str_strApartment), o.IsInvisible(_str_strApartment), o.IsRequired(_str_strApartment)); }
              }, 
        
            new field_info {
              _name = _str_strDescription, _type = "String",
              _get_func = o => o.strDescription,
              _set_func = (o, val) => { o.strDescription = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strDescription != c.strDescription || o.IsRIRPropChanged(_str_strDescription, c)) 
                  m.Add(_str_strDescription, o.ObjectIdent + _str_strDescription, "String", o.strDescription == null ? "" : o.strDescription.ToString(), o.IsReadOnly(_str_strDescription), o.IsInvisible(_str_strDescription), o.IsRequired(_str_strDescription)); }
              }, 
        
            new field_info {
              _name = _str_dblDistance, _type = "Double?",
              _get_func = o => o.dblDistance,
              _set_func = (o, val) => { o.dblDistance = ParsingHelper.ParseDoubleNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.dblDistance != c.dblDistance || o.IsRIRPropChanged(_str_dblDistance, c)) 
                  m.Add(_str_dblDistance, o.ObjectIdent + _str_dblDistance, "Double?", o.dblDistance == null ? "" : o.dblDistance.ToString(), o.IsReadOnly(_str_dblDistance), o.IsInvisible(_str_dblDistance), o.IsRequired(_str_dblDistance)); }
              }, 
        
            new field_info {
              _name = _str_dblLatitude, _type = "Double?",
              _get_func = o => o.dblLatitude,
              _set_func = (o, val) => { o.dblLatitude = ParsingHelper.ParseDoubleNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.dblLatitude != c.dblLatitude || o.IsRIRPropChanged(_str_dblLatitude, c)) 
                  m.Add(_str_dblLatitude, o.ObjectIdent + _str_dblLatitude, "Double?", o.dblLatitude == null ? "" : o.dblLatitude.ToString(), o.IsReadOnly(_str_dblLatitude), o.IsInvisible(_str_dblLatitude), o.IsRequired(_str_dblLatitude)); }
              }, 
        
            new field_info {
              _name = _str_dblLongitude, _type = "Double?",
              _get_func = o => o.dblLongitude,
              _set_func = (o, val) => { o.dblLongitude = ParsingHelper.ParseDoubleNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.dblLongitude != c.dblLongitude || o.IsRIRPropChanged(_str_dblLongitude, c)) 
                  m.Add(_str_dblLongitude, o.ObjectIdent + _str_dblLongitude, "Double?", o.dblLongitude == null ? "" : o.dblLongitude.ToString(), o.IsReadOnly(_str_dblLongitude), o.IsInvisible(_str_dblLongitude), o.IsRequired(_str_dblLongitude)); }
              }, 
        
            new field_info {
              _name = _str_dblRelLatitude, _type = "Double?",
              _get_func = o => o.dblRelLatitude,
              _set_func = (o, val) => { o.dblRelLatitude = ParsingHelper.ParseDoubleNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.dblRelLatitude != c.dblRelLatitude || o.IsRIRPropChanged(_str_dblRelLatitude, c)) 
                  m.Add(_str_dblRelLatitude, o.ObjectIdent + _str_dblRelLatitude, "Double?", o.dblRelLatitude == null ? "" : o.dblRelLatitude.ToString(), o.IsReadOnly(_str_dblRelLatitude), o.IsInvisible(_str_dblRelLatitude), o.IsRequired(_str_dblRelLatitude)); }
              }, 
        
            new field_info {
              _name = _str_dblRelLongitude, _type = "Double?",
              _get_func = o => o.dblRelLongitude,
              _set_func = (o, val) => { o.dblRelLongitude = ParsingHelper.ParseDoubleNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.dblRelLongitude != c.dblRelLongitude || o.IsRIRPropChanged(_str_dblRelLongitude, c)) 
                  m.Add(_str_dblRelLongitude, o.ObjectIdent + _str_dblRelLongitude, "Double?", o.dblRelLongitude == null ? "" : o.dblRelLongitude.ToString(), o.IsReadOnly(_str_dblRelLongitude), o.IsInvisible(_str_dblRelLongitude), o.IsRequired(_str_dblRelLongitude)); }
              }, 
        
            new field_info {
              _name = _str_dblAccuracy, _type = "Double?",
              _get_func = o => o.dblAccuracy,
              _set_func = (o, val) => { o.dblAccuracy = ParsingHelper.ParseDoubleNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.dblAccuracy != c.dblAccuracy || o.IsRIRPropChanged(_str_dblAccuracy, c)) 
                  m.Add(_str_dblAccuracy, o.ObjectIdent + _str_dblAccuracy, "Double?", o.dblAccuracy == null ? "" : o.dblAccuracy.ToString(), o.IsReadOnly(_str_dblAccuracy), o.IsInvisible(_str_dblAccuracy), o.IsRequired(_str_dblAccuracy)); }
              }, 
        
            new field_info {
              _name = _str_dblAlignment, _type = "Double?",
              _get_func = o => o.dblAlignment,
              _set_func = (o, val) => { o.dblAlignment = ParsingHelper.ParseDoubleNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.dblAlignment != c.dblAlignment || o.IsRIRPropChanged(_str_dblAlignment, c)) 
                  m.Add(_str_dblAlignment, o.ObjectIdent + _str_dblAlignment, "Double?", o.dblAlignment == null ? "" : o.dblAlignment.ToString(), o.IsReadOnly(_str_dblAlignment), o.IsInvisible(_str_dblAlignment), o.IsRequired(_str_dblAlignment)); }
              }, 
        
            new field_info {
              _name = _str_strAddressStringTranslate, _type = "String",
              _get_func = o => o.strAddressStringTranslate,
              _set_func = (o, val) => { o.strAddressStringTranslate = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strAddressStringTranslate != c.strAddressStringTranslate || o.IsRIRPropChanged(_str_strAddressStringTranslate, c)) 
                  m.Add(_str_strAddressStringTranslate, o.ObjectIdent + _str_strAddressStringTranslate, "String", o.strAddressStringTranslate == null ? "" : o.strAddressStringTranslate.ToString(), o.IsReadOnly(_str_strAddressStringTranslate), o.IsInvisible(_str_strAddressStringTranslate), o.IsRequired(_str_strAddressStringTranslate)); }
              }, 
        
            new field_info {
              _name = _str_strAddressDefaultString, _type = "String",
              _get_func = o => o.strAddressDefaultString,
              _set_func = (o, val) => { o.strAddressDefaultString = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strAddressDefaultString != c.strAddressDefaultString || o.IsRIRPropChanged(_str_strAddressDefaultString, c)) 
                  m.Add(_str_strAddressDefaultString, o.ObjectIdent + _str_strAddressDefaultString, "String", o.strAddressDefaultString == null ? "" : o.strAddressDefaultString.ToString(), o.IsReadOnly(_str_strAddressDefaultString), o.IsInvisible(_str_strAddressDefaultString), o.IsRequired(_str_strAddressDefaultString)); }
              }, 
        
            new field_info {
              _name = _str_blnGeoLocationShared, _type = "bool",
              _get_func = o => o.blnGeoLocationShared,
              _set_func = (o, val) => { o.blnGeoLocationShared = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.blnGeoLocationShared != c.blnGeoLocationShared || o.IsRIRPropChanged(_str_blnGeoLocationShared, c)) 
                  m.Add(_str_blnGeoLocationShared, o.ObjectIdent + _str_blnGeoLocationShared, "bool", o.blnGeoLocationShared == null ? "" : o.blnGeoLocationShared.ToString(), o.IsReadOnly(_str_blnGeoLocationShared), o.IsInvisible(_str_blnGeoLocationShared), o.IsRequired(_str_blnGeoLocationShared));
                 }
              }, 
        
            new field_info {
              _name = _str_bNeedCreateGeoLocationString, _type = "bool",
              _get_func = o => o.bNeedCreateGeoLocationString,
              _set_func = (o, val) => { o.bNeedCreateGeoLocationString = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.bNeedCreateGeoLocationString != c.bNeedCreateGeoLocationString || o.IsRIRPropChanged(_str_bNeedCreateGeoLocationString, c)) 
                  m.Add(_str_bNeedCreateGeoLocationString, o.ObjectIdent + _str_bNeedCreateGeoLocationString, "bool", o.bNeedCreateGeoLocationString == null ? "" : o.bNeedCreateGeoLocationString.ToString(), o.IsReadOnly(_str_bNeedCreateGeoLocationString), o.IsInvisible(_str_bNeedCreateGeoLocationString), o.IsRequired(_str_bNeedCreateGeoLocationString));
                 }
              }, 
        
            new field_info {
              _name = _str_bCancelCoordinationValidation, _type = "bool",
              _get_func = o => o.bCancelCoordinationValidation,
              _set_func = (o, val) => { o.bCancelCoordinationValidation = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.bCancelCoordinationValidation != c.bCancelCoordinationValidation || o.IsRIRPropChanged(_str_bCancelCoordinationValidation, c)) 
                  m.Add(_str_bCancelCoordinationValidation, o.ObjectIdent + _str_bCancelCoordinationValidation, "bool", o.bCancelCoordinationValidation == null ? "" : o.bCancelCoordinationValidation.ToString(), o.IsReadOnly(_str_bCancelCoordinationValidation), o.IsInvisible(_str_bCancelCoordinationValidation), o.IsRequired(_str_bCancelCoordinationValidation));
                 }
              }, 
        
            new field_info {
              _name = _str_VCase, _type = "VetCase",
              _get_func = o => o.VCase,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_IsReadOnlyParent, _type = "bool",
              _get_func = o => o.IsReadOnlyParent,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.IsReadOnlyParent != c.IsReadOnlyParent || o.IsRIRPropChanged(_str_IsReadOnlyParent, c)) 
                  m.Add(_str_IsReadOnlyParent, o.ObjectIdent + _str_IsReadOnlyParent, "bool", o.IsReadOnlyParent == null ? "" : o.IsReadOnlyParent.ToString(), o.IsReadOnly(_str_IsReadOnlyParent), o.IsInvisible(_str_IsReadOnlyParent), o.IsRequired(_str_IsReadOnlyParent));
                 }
              }, 
        
            new field_info {
              _name = _str_FullName, _type = "string",
              _get_func = o => o.FullName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.FullName != c.FullName || o.IsRIRPropChanged(_str_FullName, c)) 
                  m.Add(_str_FullName, o.ObjectIdent + _str_FullName, "string", o.FullName == null ? "" : o.FullName.ToString(), o.IsReadOnly(_str_FullName), o.IsInvisible(_str_FullName), o.IsRequired(_str_FullName));
                 }
              }, 
        
            new field_info {
              _name = _str_IsNull, _type = "bool",
              _get_func = o => o.IsNull,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.IsNull != c.IsNull || o.IsRIRPropChanged(_str_IsNull, c)) 
                  m.Add(_str_IsNull, o.ObjectIdent + _str_IsNull, "bool", o.IsNull == null ? "" : o.IsNull.ToString(), o.IsReadOnly(_str_IsNull), o.IsInvisible(_str_IsNull), o.IsRequired(_str_IsNull));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyFullName, _type = "string",
              _get_func = o => o.strReadOnlyFullName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyFullName != c.strReadOnlyFullName || o.IsRIRPropChanged(_str_strReadOnlyFullName, c)) 
                  m.Add(_str_strReadOnlyFullName, o.ObjectIdent + _str_strReadOnlyFullName, "string", o.strReadOnlyFullName == null ? "" : o.strReadOnlyFullName.ToString(), o.IsReadOnly(_str_strReadOnlyFullName), o.IsInvisible(_str_strReadOnlyFullName), o.IsRequired(_str_strReadOnlyFullName));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyAdaptiveFullName, _type = "string",
              _get_func = o => o.strReadOnlyAdaptiveFullName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyAdaptiveFullName != c.strReadOnlyAdaptiveFullName || o.IsRIRPropChanged(_str_strReadOnlyAdaptiveFullName, c)) 
                  m.Add(_str_strReadOnlyAdaptiveFullName, o.ObjectIdent + _str_strReadOnlyAdaptiveFullName, "string", o.strReadOnlyAdaptiveFullName == null ? "" : o.strReadOnlyAdaptiveFullName.ToString(), o.IsReadOnly(_str_strReadOnlyAdaptiveFullName), o.IsInvisible(_str_strReadOnlyAdaptiveFullName), o.IsRequired(_str_strReadOnlyAdaptiveFullName));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyCountry, _type = "string",
              _get_func = o => o.strReadOnlyCountry,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyCountry != c.strReadOnlyCountry || o.IsRIRPropChanged(_str_strReadOnlyCountry, c)) 
                  m.Add(_str_strReadOnlyCountry, o.ObjectIdent + _str_strReadOnlyCountry, "string", o.strReadOnlyCountry == null ? "" : o.strReadOnlyCountry.ToString(), o.IsReadOnly(_str_strReadOnlyCountry), o.IsInvisible(_str_strReadOnlyCountry), o.IsRequired(_str_strReadOnlyCountry));
                 }
              }, 
        
            new field_info {
              _name = _str_Country, _type = "Lookup",
              _get_func = o => { if (o.Country == null) return null; return o.Country.idfsCountry; },
              _set_func = (o, val) => { o.Country = o.CountryLookup.Where(c => c.idfsCountry.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_Country, c)) 
                  m.Add(_str_Country, o.ObjectIdent + _str_Country, "Lookup", o.idfsCountry == null ? "" : o.idfsCountry.ToString(), o.IsReadOnly(_str_Country), o.IsInvisible(_str_Country), o.IsRequired(_str_Country)); }
              }, 
        
            new field_info {
              _name = _str_Region, _type = "Lookup",
              _get_func = o => { if (o.Region == null) return null; return o.Region.idfsRegion; },
              _set_func = (o, val) => { o.Region = o.RegionLookup.Where(c => c.idfsRegion.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_Region, c)) 
                  m.Add(_str_Region, o.ObjectIdent + _str_Region, "Lookup", o.idfsRegion == null ? "" : o.idfsRegion.ToString(), o.IsReadOnly(_str_Region), o.IsInvisible(_str_Region), o.IsRequired(_str_Region)); }
              }, 
        
            new field_info {
              _name = _str_Rayon, _type = "Lookup",
              _get_func = o => { if (o.Rayon == null) return null; return o.Rayon.idfsRayon; },
              _set_func = (o, val) => { o.Rayon = o.RayonLookup.Where(c => c.idfsRayon.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_Rayon, c)) 
                  m.Add(_str_Rayon, o.ObjectIdent + _str_Rayon, "Lookup", o.idfsRayon == null ? "" : o.idfsRayon.ToString(), o.IsReadOnly(_str_Rayon), o.IsInvisible(_str_Rayon), o.IsRequired(_str_Rayon)); }
              }, 
        
            new field_info {
              _name = _str_Settlement, _type = "Lookup",
              _get_func = o => { if (o.Settlement == null) return null; return o.Settlement.idfsSettlement; },
              _set_func = (o, val) => { o.Settlement = o.SettlementLookup.Where(c => c.idfsSettlement.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_Settlement, c)) 
                  m.Add(_str_Settlement, o.ObjectIdent + _str_Settlement, "Lookup", o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(), o.IsReadOnly(_str_Settlement), o.IsInvisible(_str_Settlement), o.IsRequired(_str_Settlement)); }
              }, 
        
            new field_info {
              _name = _str_ResidentType, _type = "Lookup",
              _get_func = o => { if (o.ResidentType == null) return null; return o.ResidentType.idfsBaseReference; },
              _set_func = (o, val) => { o.ResidentType = o.ResidentTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsResidentType != c.idfsResidentType || o.IsRIRPropChanged(_str_ResidentType, c)) 
                  m.Add(_str_ResidentType, o.ObjectIdent + _str_ResidentType, "Lookup", o.idfsResidentType == null ? "" : o.idfsResidentType.ToString(), o.IsReadOnly(_str_ResidentType), o.IsInvisible(_str_ResidentType), o.IsRequired(_str_ResidentType)); }
              }, 
        
            new field_info {
              _name = _str_GroundType, _type = "Lookup",
              _get_func = o => { if (o.GroundType == null) return null; return o.GroundType.idfsBaseReference; },
              _set_func = (o, val) => { o.GroundType = o.GroundTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsGroundType != c.idfsGroundType || o.IsRIRPropChanged(_str_GroundType, c)) 
                  m.Add(_str_GroundType, o.ObjectIdent + _str_GroundType, "Lookup", o.idfsGroundType == null ? "" : o.idfsGroundType.ToString(), o.IsReadOnly(_str_GroundType), o.IsInvisible(_str_GroundType), o.IsRequired(_str_GroundType)); }
              }, 
        
            new field_info {
              _name = _str_GeoLocationType, _type = "Lookup",
              _get_func = o => { if (o.GeoLocationType == null) return null; return o.GeoLocationType.idfsBaseReference; },
              _set_func = (o, val) => { o.GeoLocationType = o.GeoLocationTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsGeoLocationType != c.idfsGeoLocationType || o.IsRIRPropChanged(_str_GeoLocationType, c)) 
                  m.Add(_str_GeoLocationType, o.ObjectIdent + _str_GeoLocationType, "Lookup", o.idfsGeoLocationType == null ? "" : o.idfsGeoLocationType.ToString(), o.IsReadOnly(_str_GeoLocationType), o.IsInvisible(_str_GeoLocationType), o.IsRequired(_str_GeoLocationType)); }
              }, 
        
            new field_info {
              _name = _str_Street, _type = "Lookup",
              _get_func = o => o.strStreetName,
              _set_func = (o, val) => { o.strStreetName = val; },
              _compare_func = (o, c, m) => {
                if (o.strStreetName != c.strStreetName || o.IsRIRPropChanged(_str_Street, c)) 
                  m.Add(_str_Street, o.ObjectIdent + _str_Street, "Lookup", o.strStreetName == null ? "" : o.strStreetName.ToString(), o.IsReadOnly(_str_Street), o.IsInvisible(_str_Street), o.IsRequired(_str_Street)); }
              },
        
            new field_info {
              _name = _str_PostCode, _type = "Lookup",
              _get_func = o => o.strPostCode,
              _set_func = (o, val) => { o.strPostCode = val; },
              _compare_func = (o, c, m) => {
                if (o.strPostCode != c.strPostCode || o.IsRIRPropChanged(_str_PostCode, c)) 
                  m.Add(_str_PostCode, o.ObjectIdent + _str_PostCode, "Lookup", o.strPostCode == null ? "" : o.strPostCode.ToString(), o.IsReadOnly(_str_PostCode), o.IsInvisible(_str_PostCode), o.IsRequired(_str_PostCode)); }
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
            GeoLocation obj = (GeoLocation)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(CountryLookup), eidss.model.Schema.CountryLookup._str_idfsCountry, _str_idfsCountry)]
        public CountryLookup Country
        {
            get { return _Country == null ? null : ((long)_Country.Key == 0 ? null : _Country); }
            set 
            { 
                _Country = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsCountry = _Country == null 
                    ? new Int64?()
                    : _Country.idfsCountry; 
                OnPropertyChanged(_str_Country); 
            }
        }
        private CountryLookup _Country;

        
        public List<CountryLookup> CountryLookup
        {
            get { return _CountryLookup; }
        }
        private List<CountryLookup> _CountryLookup = new List<CountryLookup>();
            
        [Relation(typeof(RegionLookup), eidss.model.Schema.RegionLookup._str_idfsRegion, _str_idfsRegion)]
        public RegionLookup Region
        {
            get { return _Region == null ? null : ((long)_Region.Key == 0 ? null : _Region); }
            set 
            { 
                _Region = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsRegion = _Region == null 
                    ? new Int64?()
                    : _Region.idfsRegion; 
                OnPropertyChanged(_str_Region); 
            }
        }
        private RegionLookup _Region;

        
        public List<RegionLookup> RegionLookup
        {
            get { return _RegionLookup; }
        }
        private List<RegionLookup> _RegionLookup = new List<RegionLookup>();
            
        [Relation(typeof(RayonLookup), eidss.model.Schema.RayonLookup._str_idfsRayon, _str_idfsRayon)]
        public RayonLookup Rayon
        {
            get { return _Rayon == null ? null : ((long)_Rayon.Key == 0 ? null : _Rayon); }
            set 
            { 
                _Rayon = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsRayon = _Rayon == null 
                    ? new Int64?()
                    : _Rayon.idfsRayon; 
                OnPropertyChanged(_str_Rayon); 
            }
        }
        private RayonLookup _Rayon;

        
        public List<RayonLookup> RayonLookup
        {
            get { return _RayonLookup; }
        }
        private List<RayonLookup> _RayonLookup = new List<RayonLookup>();
            
        [Relation(typeof(SettlementLookup), eidss.model.Schema.SettlementLookup._str_idfsSettlement, _str_idfsSettlement)]
        public SettlementLookup Settlement
        {
            get { return _Settlement == null ? null : ((long)_Settlement.Key == 0 ? null : _Settlement); }
            set 
            { 
                _Settlement = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsSettlement = _Settlement == null 
                    ? new Int64?()
                    : _Settlement.idfsSettlement; 
                OnPropertyChanged(_str_Settlement); 
            }
        }
        private SettlementLookup _Settlement;

        
        public List<SettlementLookup> SettlementLookup
        {
            get { return _SettlementLookup; }
        }
        private List<SettlementLookup> _SettlementLookup = new List<SettlementLookup>();
            
        [Relation(typeof(StreetLookup), eidss.model.Schema.StreetLookup._str_strStreetName, _str_strStreetName)]
        public StreetLookup Street
        {
            get { return _Street; }
            set 
            { 
                _Street = value;
                strStreetName = _Street == null 
                    ? strStreetName
                    : _Street.strStreetName; 
                OnPropertyChanged(_str_Street); 
            }
        }
        private StreetLookup _Street;

        
        public List<StreetLookup> StreetLookup
        {
            get { return _StreetLookup; }
        }
        private List<StreetLookup> _StreetLookup = new List<StreetLookup>();
            
        [Relation(typeof(PostalCodeLookup), eidss.model.Schema.PostalCodeLookup._str_strPostCode, _str_strPostCode)]
        public PostalCodeLookup PostCode
        {
            get { return _PostCode; }
            set 
            { 
                _PostCode = value;
                strPostCode = _PostCode == null 
                    ? strPostCode
                    : _PostCode.strPostCode; 
                OnPropertyChanged(_str_PostCode); 
            }
        }
        private PostalCodeLookup _PostCode;

        
        public List<PostalCodeLookup> PostCodeLookup
        {
            get { return _PostCodeLookup; }
        }
        private List<PostalCodeLookup> _PostCodeLookup = new List<PostalCodeLookup>();
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsResidentType)]
        public BaseReference ResidentType
        {
            get { return _ResidentType == null ? null : ((long)_ResidentType.Key == 0 ? null : _ResidentType); }
            set 
            { 
                _ResidentType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsResidentType = _ResidentType == null 
                    ? new Int64?()
                    : _ResidentType.idfsBaseReference; 
                OnPropertyChanged(_str_ResidentType); 
            }
        }
        private BaseReference _ResidentType;

        
        public BaseReferenceList ResidentTypeLookup
        {
            get { return _ResidentTypeLookup; }
        }
        private BaseReferenceList _ResidentTypeLookup = new BaseReferenceList("rftResidentType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsGroundType)]
        public BaseReference GroundType
        {
            get { return _GroundType == null ? null : ((long)_GroundType.Key == 0 ? null : _GroundType); }
            set 
            { 
                _GroundType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsGroundType = _GroundType == null 
                    ? new Int64?()
                    : _GroundType.idfsBaseReference; 
                OnPropertyChanged(_str_GroundType); 
            }
        }
        private BaseReference _GroundType;

        
        public BaseReferenceList GroundTypeLookup
        {
            get { return _GroundTypeLookup; }
        }
        private BaseReferenceList _GroundTypeLookup = new BaseReferenceList("rftGroundType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsGeoLocationType)]
        public BaseReference GeoLocationType
        {
            get { return _GeoLocationType == null ? null : ((long)_GeoLocationType.Key == 0 ? null : _GeoLocationType); }
            set 
            { 
                _GeoLocationType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsGeoLocationType = _GeoLocationType == null 
                    ? new Int64?()
                    : _GeoLocationType.idfsBaseReference; 
                OnPropertyChanged(_str_GeoLocationType); 
            }
        }
        private BaseReference _GeoLocationType;

        
        public BaseReferenceList GeoLocationTypeLookup
        {
            get { return _GeoLocationTypeLookup; }
        }
        private BaseReferenceList _GeoLocationTypeLookup = new BaseReferenceList("rftGeoLocType");
            
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
            
                case _str_ResidentType:
                    return new BvSelectList(ResidentTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, ResidentType, _str_idfsResidentType);
            
                case _str_GroundType:
                    return new BvSelectList(GroundTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, GroundType, _str_idfsGroundType);
            
                case _str_GeoLocationType:
                    return new BvSelectList(GeoLocationTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, GeoLocationType, _str_idfsGeoLocationType);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_VCase)]
        public VetCase VCase
        {
            get { return new Func<GeoLocation, VetCase>(c => c.Parent is FarmPanel ? (c.Parent as FarmPanel).Parent as VetCase : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsReadOnlyParent)]
        public bool IsReadOnlyParent
        {
            get { return new Func<GeoLocation, bool>(c => c.VCase == null ? false : c.VCase.IsClosed || c.VCase.ReadOnly)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_FullName)]
        public string FullName
        {
            get { return new Func<GeoLocation, string>(c => c.strAddressStringTranslate)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsNull)]
        public bool IsNull
        {
            get { return new Func<GeoLocation, bool>(c => c.idfsCountry == null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyFullName)]
        public string strReadOnlyFullName
        {
            get { return new Func<GeoLocation, string>(c => c.strAddressStringTranslate)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyAdaptiveFullName)]
        public string strReadOnlyAdaptiveFullName
        {
            get { return new Func<GeoLocation, string>(c => c.CreateGeoLocationString())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyCountry)]
        public string strReadOnlyCountry
        {
            get { return new Func<GeoLocation, string>(c => c.idfsCountry == null ? (string)null : c.Country.strCountryName)(this); }
            
        }
        
          [LocalizedDisplayName(_str_blnGeoLocationShared)]
        public bool blnGeoLocationShared
        {
            get { return m_blnGeoLocationShared; }
            set { if (m_blnGeoLocationShared != value) { m_blnGeoLocationShared = value; OnPropertyChanged(_str_blnGeoLocationShared); } }
        }
        private bool m_blnGeoLocationShared;
        
          [LocalizedDisplayName(_str_bNeedCreateGeoLocationString)]
        public bool bNeedCreateGeoLocationString
        {
            get { return m_bNeedCreateGeoLocationString; }
            set { if (m_bNeedCreateGeoLocationString != value) { m_bNeedCreateGeoLocationString = value; OnPropertyChanged(_str_bNeedCreateGeoLocationString); } }
        }
        private bool m_bNeedCreateGeoLocationString;
        
          [LocalizedDisplayName(_str_bCancelCoordinationValidation)]
        public bool bCancelCoordinationValidation
        {
            get { return m_bCancelCoordinationValidation; }
            set { if (m_bCancelCoordinationValidation != value) { m_bCancelCoordinationValidation = value; OnPropertyChanged(_str_bCancelCoordinationValidation); } }
        }
        private bool m_bCancelCoordinationValidation;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "GeoLocation";

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
            var ret = base.Clone() as GeoLocation;
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
            var ret = base.Clone() as GeoLocation;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public GeoLocation CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as GeoLocation;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfGeoLocation; } }
        public string KeyName { get { return "idfGeoLocation"; } }
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
        
            var _prev_idfsCountry_Country = idfsCountry;
            var _prev_idfsRegion_Region = idfsRegion;
            var _prev_idfsRayon_Rayon = idfsRayon;
            var _prev_idfsSettlement_Settlement = idfsSettlement;
            var _prev_idfsResidentType_ResidentType = idfsResidentType;
            var _prev_idfsGroundType_GroundType = idfsGroundType;
            var _prev_idfsGeoLocationType_GeoLocationType = idfsGeoLocationType;
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
            if (_prev_idfsResidentType_ResidentType != idfsResidentType)
            {
                _ResidentType = _ResidentTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsResidentType);
            }
            if (_prev_idfsGroundType_GroundType != idfsGroundType)
            {
                _GroundType = _GroundTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsGroundType);
            }
            if (_prev_idfsGeoLocationType_GeoLocationType != idfsGeoLocationType)
            {
                _GeoLocationType = _GeoLocationTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsGeoLocationType);
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

      private bool IsRIRPropChanged(string fld, GeoLocation c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public GeoLocation()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(GeoLocation_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(GeoLocation_PropertyChanged);
        }
        private void GeoLocation_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as GeoLocation).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_VCase);
                  
            if (e.PropertyName == _str_VCase)
                OnPropertyChanged(_str_IsReadOnlyParent);
                  
            if (e.PropertyName == _str_idfsCountry)
                OnPropertyChanged(_str_IsNull);
                  
            if (e.PropertyName == _str_idfsCountry)
                OnPropertyChanged(_str_strReadOnlyCountry);
                  
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
            GeoLocation obj = this;
            
        }
        private void _DeletedExtenders()
        {
            GeoLocation obj = this;
            
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

    
        private static string[] readonly_names1 = "strReadOnlyFullName,strReadOnlyAdaptiveFullName".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "Region,idfsRegion".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "Rayon,idfsRayon".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "Settlement,idfsSettlement".Split(new char[] { ',' });
        
        private static string[] readonly_names5 = "Street,strStreetName,PostCode,strPostCode,strHouse,strBuilding,strApartment".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<GeoLocation, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<GeoLocation, bool>(c => c.IsReadOnlyParent || c.idfsCountry == null)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<GeoLocation, bool>(c => c.IsReadOnlyParent || c.idfsRegion == null)(this);
            
            if (readonly_names4.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<GeoLocation, bool>(c => c.IsReadOnlyParent || c.idfsRayon == null)(this);
            
            if (readonly_names5.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<GeoLocation, bool>(c => c.IsReadOnlyParent || c.idfsSettlement == null)(this);
            
            return ReadOnly || new Func<GeoLocation, bool>(c => c.IsReadOnlyParent)(this);
                
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


        public Dictionary<string, Func<GeoLocation, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<GeoLocation, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<GeoLocation, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<GeoLocation, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<GeoLocation, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<GeoLocation, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~GeoLocation()
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
                
                LookupManager.RemoveObject("rftResidentType", this);
                
                LookupManager.RemoveObject("rftGroundType", this);
                
                LookupManager.RemoveObject("rftGeoLocType", this);
                
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
            
            if (lookup_object == "rftResidentType")
                _getAccessor().LoadLookup_ResidentType(manager, this);
            
            if (lookup_object == "rftGroundType")
                _getAccessor().LoadLookup_GroundType(manager, this);
            
            if (lookup_object == "rftGeoLocType")
                _getAccessor().LoadLookup_GeoLocationType(manager, this);
            
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
        : DataAccessor<GeoLocation>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(GeoLocation obj);
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
            private BaseReference.Accessor ResidentTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor GroundTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor GeoLocationTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            

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

            
            public virtual GeoLocation SelectByKey(DbManagerProxy manager
                , Int64? idfGeoLocation
                )
            {
                return _SelectByKey(manager
                    , idfGeoLocation
                    , null, null
                    );
            }
            
      
            private GeoLocation _SelectByKey(DbManagerProxy manager
                , Int64? idfGeoLocation
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<GeoLocation> objs = new List<GeoLocation>();
                sets[0] = new MapResultSet(typeof(GeoLocation), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spGeoLocation_SelectDetail"
                            , manager.Parameter("@idfGeoLocation", idfGeoLocation)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    GeoLocation obj = objs[0];
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, GeoLocation obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, GeoLocation obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private GeoLocation _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    GeoLocation obj = GeoLocation.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfGeoLocation = (new GetNewIDExtender<GeoLocation>()).GetScalar(manager, obj);
                obj.bCancelCoordinationValidation = false;
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.GeoLocationType = new Func<GeoLocation, BaseReference>(c => c.GeoLocationTypeLookup.Where(a => a.idfsBaseReference == (long)GeoLocationTypeEnum.ExactPoint).SingleOrDefault())(obj);
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

            
            public GeoLocation CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public GeoLocation CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public GeoLocation CreateWithCountryT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                return CreateWithCountry(manager, Parent
                    );
            }
            public IObject CreateWithCountry(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateWithCountryT(manager, Parent, pars);
            }
            public GeoLocation CreateWithCountry(DbManagerProxy manager, IObject Parent
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                }
                    , obj =>
                {
                obj.Country = new Func<GeoLocation, CountryLookup>(c => 
                                       c.CountryLookup.Where(a => a.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID)
                                       .SingleOrDefault())(obj);
                }
                );
            }
            
            public GeoLocation CreateWithoutCountryT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                return CreateWithoutCountry(manager, Parent
                    );
            }
            public IObject CreateWithoutCountry(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateWithoutCountryT(manager, Parent, pars);
            }
            public GeoLocation CreateWithoutCountry(DbManagerProxy manager, IObject Parent
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
            
            private void _SetupChildHandlers(GeoLocation obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(GeoLocation obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsGeoLocationType)
                        {
                    
                obj.bNeedCreateGeoLocationString = true;
                        }
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.bNeedCreateGeoLocationString = true;
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.bNeedCreateGeoLocationString = true;
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                obj.bNeedCreateGeoLocationString = true;
                        }
                    
                        if (e.PropertyName == _str_idfsSettlement)
                        {
                    
                obj.bNeedCreateGeoLocationString = true;
                        }
                    
                        if (e.PropertyName == _str_dblLatitude)
                        {
                    
                obj.bNeedCreateGeoLocationString = true;
                        }
                    
                        if (e.PropertyName == _str_dblLongitude)
                        {
                    
                obj.bNeedCreateGeoLocationString = true;
                        }
                    
                        if (e.PropertyName == _str_dblAlignment)
                        {
                    
                obj.bNeedCreateGeoLocationString = true;
                        }
                    
                        if (e.PropertyName == _str_dblDistance)
                        {
                    
                obj.bNeedCreateGeoLocationString = true;
                        }
                    
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
                    
                        if (e.PropertyName == _str_Settlement)
                        {
                    
              obj.CalcCoordinates();
            
                        }
                    
                        if (e.PropertyName == _str_dblAlignment)
                        {
                    
              obj.CalcCoordinates();
            
                        }
                    
                        if (e.PropertyName == _str_dblAlignment)
                        {
                    
                obj.CalcCoordinates();
              
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Country(DbManagerProxy manager, GeoLocation obj)
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
                        .Where(c => c.idfsCountry == obj.idfsCountry)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("CountryLookup", obj, CountryAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Region(DbManagerProxy manager, GeoLocation obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<GeoLocation, long>(c => c.idfsCountry ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRegion == obj.idfsRegion))
                    
                    .ToList());
                
                if (obj.idfsRegion != null && obj.idfsRegion != 0)
                {
                    obj.Region = obj.RegionLookup
                        .Where(c => c.idfsRegion == obj.idfsRegion)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("RegionLookup", obj, RegionAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Rayon(DbManagerProxy manager, GeoLocation obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<GeoLocation, long>(c => c.idfsRegion ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRayon == obj.idfsRayon))
                    
                    .ToList());
                
                if (obj.idfsRayon != null && obj.idfsRayon != 0)
                {
                    obj.Rayon = obj.RayonLookup
                        .Where(c => c.idfsRayon == obj.idfsRayon)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("RayonLookup", obj, RayonAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Settlement(DbManagerProxy manager, GeoLocation obj)
            {
                
                obj.SettlementLookup.Clear();
                
                obj.SettlementLookup.Add(SettlementAccessor.CreateNewT(manager, null));
                
                obj.SettlementLookup.AddRange(SettlementAccessor.SelectLookupList(manager
                    
                    , new Func<GeoLocation, long>(c => c.idfsRayon ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSettlement == obj.idfsSettlement))
                    
                    .ToList());
                
                if (obj.idfsSettlement != null && obj.idfsSettlement != 0)
                {
                    obj.Settlement = obj.SettlementLookup
                        .Where(c => c.idfsSettlement == obj.idfsSettlement)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("SettlementLookup", obj, SettlementAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Street(DbManagerProxy manager, GeoLocation obj)
            {
                
                obj.StreetLookup.Clear();
                
                obj.StreetLookup.Add(StreetAccessor.CreateNewT(manager, null));
                
                obj.StreetLookup.AddRange(StreetAccessor.SelectLookupList(manager
                    
                    , new Func<GeoLocation, long>(c => c.idfsSettlement ?? 0)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.strStreetName == obj.strStreetName))
                    
                    .ToList());
                
                if (!string.IsNullOrEmpty(obj.strStreetName))
                {
                    obj.Street = obj.StreetLookup
                        .Where(c => c.strStreetName == obj.strStreetName)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("StreetLookup", obj, StreetAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_PostCode(DbManagerProxy manager, GeoLocation obj)
            {
                
                obj.PostCodeLookup.Clear();
                
                obj.PostCodeLookup.Add(PostCodeAccessor.CreateNewT(manager, null));
                
                obj.PostCodeLookup.AddRange(PostCodeAccessor.SelectLookupList(manager
                    
                    , new Func<GeoLocation, long>(c => c.idfsSettlement ?? 0)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.strPostCode == obj.strPostCode))
                    
                    .ToList());
                
                if (!string.IsNullOrEmpty(obj.strPostCode))
                {
                    obj.PostCode = obj.PostCodeLookup
                        .Where(c => c.strPostCode == obj.strPostCode)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("PostalCodeLookup", obj, PostCodeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_ResidentType(DbManagerProxy manager, GeoLocation obj)
            {
                
                obj.ResidentTypeLookup.Clear();
                
                obj.ResidentTypeLookup.Add(ResidentTypeAccessor.CreateNewT(manager, null));
                
                obj.ResidentTypeLookup.AddRange(ResidentTypeAccessor.rftResidentType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsResidentType))
                    
                    .ToList());
                
                if (obj.idfsResidentType != null && obj.idfsResidentType != 0)
                {
                    obj.ResidentType = obj.ResidentTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsResidentType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftResidentType", obj, ResidentTypeAccessor.GetType(), "rftResidentType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_GroundType(DbManagerProxy manager, GeoLocation obj)
            {
                
                obj.GroundTypeLookup.Clear();
                
                obj.GroundTypeLookup.Add(GroundTypeAccessor.CreateNewT(manager, null));
                
                obj.GroundTypeLookup.AddRange(GroundTypeAccessor.rftGroundType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsGroundType))
                    
                    .ToList());
                
                if (obj.idfsGroundType != null && obj.idfsGroundType != 0)
                {
                    obj.GroundType = obj.GroundTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsGroundType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftGroundType", obj, GroundTypeAccessor.GetType(), "rftGroundType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_GeoLocationType(DbManagerProxy manager, GeoLocation obj)
            {
                
                obj.GeoLocationTypeLookup.Clear();
                
                obj.GeoLocationTypeLookup.Add(GeoLocationTypeAccessor.CreateNewT(manager, null));
                
                obj.GeoLocationTypeLookup.AddRange(GeoLocationTypeAccessor.rftGeoLocType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsGeoLocationType))
                    
                    .ToList());
                
                if (obj.idfsGeoLocationType != null && obj.idfsGeoLocationType != 0)
                {
                    obj.GeoLocationType = obj.GeoLocationTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsGeoLocationType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftGeoLocType", obj, GeoLocationTypeAccessor.GetType(), "rftGeoLocType_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, GeoLocation obj)
            {
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Settlement(manager, obj);
                
                LoadLookup_Street(manager, obj);
                
                LoadLookup_PostCode(manager, obj);
                
                LoadLookup_ResidentType(manager, obj);
                
                LoadLookup_GroundType(manager, obj);
                
                LoadLookup_GeoLocationType(manager, obj);
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spGeoLocation_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] GeoLocation obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] GeoLocation obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    GeoLocation bo = obj as GeoLocation;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as GeoLocation, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, GeoLocation obj, bool bChildObject) 
            { 
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
                    // posting extenters - end
            
                    if (!obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(GeoLocation obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, GeoLocation obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as GeoLocation, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, GeoLocation obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new PredicateValidator("GeoLocation_LongtitudeExceedsValues", "dblLongitude", "dblLongitude", "dblLongitude",
              new object[] {
              },
                        false
                    )).Validate(obj, c=>!c.dblLongitude.HasValue || (c.dblLongitude >= -180 && c.dblLongitude <= 180)
                    );
            
                (new PredicateValidator("GeoLocation_LatitudeExceedsValues", "dblLatitude", "dblLatitude", "dblLatitude",
              new object[] {
              },
                        false
                    )).Validate(obj, c=>!c.dblLatitude.HasValue || (c.dblLatitude >= -90 && c.dblLatitude <= 90)
                    );
            
                (new RequiredValidator( "idfsCountry", "Country","",
                false
              )).Validate(c => !c.IsNull, obj, obj.idfsCountry);
            
                (new RequiredValidator( "idfsRegion", "Region","",
                false
              )).Validate(c => !c.IsNull, obj, obj.idfsRegion);
            
                (new RequiredValidator( "idfsRayon", "Rayon","",
                false
              )).Validate(c => !c.IsNull, obj, obj.idfsRayon);
            
                (new RequiredValidator( "idfsSettlement", "Settlement","",
                false
              )).Validate(c => !c.IsNull && c.idfsGeoLocationType == (long)GeoLocationTypeEnum.RelativePoint, obj, obj.idfsSettlement);
            
                ValidateLocationCoordinates(obj);
            
                  
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
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                        return false;
                    }
                }
                
                return true;
            }
           
    
            private void _SetupRequired(GeoLocation obj)
            {
            
                obj
                    .AddRequired("Country", c => !c.IsNull);
                    
                obj
                    .AddRequired("Region", c => !c.IsNull);
                    
                obj
                    .AddRequired("Rayon", c => !c.IsNull);
                    
                obj
                    .AddRequired("Settlement", c => !c.IsNull && c.idfsGeoLocationType == (long)GeoLocationTypeEnum.RelativePoint);
                    
            }
    
    private void _SetupPersonalDataRestrictions(GeoLocation obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as GeoLocation) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as GeoLocation) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "GeoLocationDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spGeoLocation_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spGeoLocation_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<GeoLocation, bool>> RequiredByField = new Dictionary<string, Func<GeoLocation, bool>>();
            public static Dictionary<string, Func<GeoLocation, bool>> RequiredByProperty = new Dictionary<string, Func<GeoLocation, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strPostCode, 200);
                Sizes.Add(_str_strStreetName, 200);
                Sizes.Add(_str_strHouse, 200);
                Sizes.Add(_str_strBuilding, 200);
                Sizes.Add(_str_strApartment, 200);
                Sizes.Add(_str_strDescription, 200);
                Sizes.Add(_str_strAddressStringTranslate, 2000);
                Sizes.Add(_str_strAddressDefaultString, 1000);
                if (!RequiredByField.ContainsKey("idfsCountry")) RequiredByField.Add("idfsCountry", c => !c.IsNull);
                if (!RequiredByProperty.ContainsKey("Country")) RequiredByProperty.Add("Country", c => !c.IsNull);
                
                if (!RequiredByField.ContainsKey("idfsRegion")) RequiredByField.Add("idfsRegion", c => !c.IsNull);
                if (!RequiredByProperty.ContainsKey("Region")) RequiredByProperty.Add("Region", c => !c.IsNull);
                
                if (!RequiredByField.ContainsKey("idfsRayon")) RequiredByField.Add("idfsRayon", c => !c.IsNull);
                if (!RequiredByProperty.ContainsKey("Rayon")) RequiredByProperty.Add("Rayon", c => !c.IsNull);
                
                if (!RequiredByField.ContainsKey("idfsSettlement")) RequiredByField.Add("idfsSettlement", c => !c.IsNull && c.idfsGeoLocationType == (long)GeoLocationTypeEnum.RelativePoint);
                if (!RequiredByProperty.ContainsKey("Settlement")) RequiredByProperty.Add("Settlement", c => !c.IsNull && c.idfsGeoLocationType == (long)GeoLocationTypeEnum.RelativePoint);
                
                Actions.Add(new ActionMetaItem(
                    "CreateWithCountry",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithCountry(manager, c, pars)),
                        
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
                    "CreateWithoutCountry",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithoutCountry(manager, c, pars)),
                        
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
                    (manager, c, pars) => new ActResult(((GeoLocation)c).MarkToDelete() && ObjectAccessor.PostInterface<GeoLocation>().Post(manager, (GeoLocation)c), c),
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
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<GeoLocation>().Post(manager, (GeoLocation)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<GeoLocation>().Post(manager, (GeoLocation)c), c),
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
	