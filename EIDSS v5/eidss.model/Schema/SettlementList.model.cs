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
    public abstract partial class SettlementListItem : 
        EditableObject<SettlementListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsSettlement), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsSettlement { get; set; }
                
        [LocalizedDisplayName(_str_SettlementDefaultName)]
        [MapField(_str_SettlementDefaultName)]
        public abstract String SettlementDefaultName { get; set; }
        #if MONO
        protected String SettlementDefaultName_Original { get { return SettlementDefaultName; } }
        protected String SettlementDefaultName_Previous { get { return SettlementDefaultName; } }
        #else
        protected String SettlementDefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._settlementDefaultName).OriginalValue; } }
        protected String SettlementDefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._settlementDefaultName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_SettlementNationalName)]
        [MapField(_str_SettlementNationalName)]
        public abstract String SettlementNationalName { get; set; }
        #if MONO
        protected String SettlementNationalName_Original { get { return SettlementNationalName; } }
        protected String SettlementNationalName_Previous { get { return SettlementNationalName; } }
        #else
        protected String SettlementNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._settlementNationalName).OriginalValue; } }
        protected String SettlementNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._settlementNationalName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSettlementType)]
        [MapField(_str_idfsSettlementType)]
        public abstract Int64 idfsSettlementType { get; set; }
        #if MONO
        protected Int64 idfsSettlementType_Original { get { return idfsSettlementType; } }
        protected Int64 idfsSettlementType_Previous { get { return idfsSettlementType; } }
        #else
        protected Int64 idfsSettlementType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSettlementType).OriginalValue; } }
        protected Int64 idfsSettlementType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSettlementType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_SettlementTypeDefaultName)]
        [MapField(_str_SettlementTypeDefaultName)]
        public abstract String SettlementTypeDefaultName { get; set; }
        #if MONO
        protected String SettlementTypeDefaultName_Original { get { return SettlementTypeDefaultName; } }
        protected String SettlementTypeDefaultName_Previous { get { return SettlementTypeDefaultName; } }
        #else
        protected String SettlementTypeDefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._settlementTypeDefaultName).OriginalValue; } }
        protected String SettlementTypeDefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._settlementTypeDefaultName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_SettlementTypeNationalName)]
        [MapField(_str_SettlementTypeNationalName)]
        public abstract String SettlementTypeNationalName { get; set; }
        #if MONO
        protected String SettlementTypeNationalName_Original { get { return SettlementTypeNationalName; } }
        protected String SettlementTypeNationalName_Previous { get { return SettlementTypeNationalName; } }
        #else
        protected String SettlementTypeNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._settlementTypeNationalName).OriginalValue; } }
        protected String SettlementTypeNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._settlementTypeNationalName).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_CountryDefaultName)]
        [MapField(_str_CountryDefaultName)]
        public abstract String CountryDefaultName { get; set; }
        #if MONO
        protected String CountryDefaultName_Original { get { return CountryDefaultName; } }
        protected String CountryDefaultName_Previous { get { return CountryDefaultName; } }
        #else
        protected String CountryDefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._countryDefaultName).OriginalValue; } }
        protected String CountryDefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._countryDefaultName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsCountry")]
        [MapField(_str_CountryNationalName)]
        public abstract String CountryNationalName { get; set; }
        #if MONO
        protected String CountryNationalName_Original { get { return CountryNationalName; } }
        protected String CountryNationalName_Previous { get { return CountryNationalName; } }
        #else
        protected String CountryNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._countryNationalName).OriginalValue; } }
        protected String CountryNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._countryNationalName).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_RegionDefaultName)]
        [MapField(_str_RegionDefaultName)]
        public abstract String RegionDefaultName { get; set; }
        #if MONO
        protected String RegionDefaultName_Original { get { return RegionDefaultName; } }
        protected String RegionDefaultName_Previous { get { return RegionDefaultName; } }
        #else
        protected String RegionDefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._regionDefaultName).OriginalValue; } }
        protected String RegionDefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._regionDefaultName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsRegion")]
        [MapField(_str_RegionNationalName)]
        public abstract String RegionNationalName { get; set; }
        #if MONO
        protected String RegionNationalName_Original { get { return RegionNationalName; } }
        protected String RegionNationalName_Previous { get { return RegionNationalName; } }
        #else
        protected String RegionNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._regionNationalName).OriginalValue; } }
        protected String RegionNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._regionNationalName).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_RayonDefaultName)]
        [MapField(_str_RayonDefaultName)]
        public abstract String RayonDefaultName { get; set; }
        #if MONO
        protected String RayonDefaultName_Original { get { return RayonDefaultName; } }
        protected String RayonDefaultName_Previous { get { return RayonDefaultName; } }
        #else
        protected String RayonDefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._rayonDefaultName).OriginalValue; } }
        protected String RayonDefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._rayonDefaultName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsRayon")]
        [MapField(_str_RayonNationalName)]
        public abstract String RayonNationalName { get; set; }
        #if MONO
        protected String RayonNationalName_Original { get { return RayonNationalName; } }
        protected String RayonNationalName_Previous { get { return RayonNationalName; } }
        #else
        protected String RayonNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._rayonNationalName).OriginalValue; } }
        protected String RayonNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._rayonNationalName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSettlementCode)]
        [MapField(_str_strSettlementCode)]
        public abstract String strSettlementCode { get; set; }
        #if MONO
        protected String strSettlementCode_Original { get { return strSettlementCode; } }
        protected String strSettlementCode_Previous { get { return strSettlementCode; } }
        #else
        protected String strSettlementCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strSettlementCode).OriginalValue; } }
        protected String strSettlementCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSettlementCode).PreviousValue; } }
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
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<SettlementListItem, object> _get_func;
            internal Action<SettlementListItem, string> _set_func;
            internal Action<SettlementListItem, SettlementListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_SettlementDefaultName = "SettlementDefaultName";
        internal const string _str_SettlementNationalName = "SettlementNationalName";
        internal const string _str_idfsSettlementType = "idfsSettlementType";
        internal const string _str_SettlementTypeDefaultName = "SettlementTypeDefaultName";
        internal const string _str_SettlementTypeNationalName = "SettlementTypeNationalName";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_CountryDefaultName = "CountryDefaultName";
        internal const string _str_CountryNationalName = "CountryNationalName";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_RegionDefaultName = "RegionDefaultName";
        internal const string _str_RegionNationalName = "RegionNationalName";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_RayonDefaultName = "RayonDefaultName";
        internal const string _str_RayonNationalName = "RayonNationalName";
        internal const string _str_strSettlementCode = "strSettlementCode";
        internal const string _str_dblLongitude = "dblLongitude";
        internal const string _str_dblLatitude = "dblLatitude";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_SettlementType = "SettlementType";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfsSettlement, _type = "Int64",
              _get_func = o => o.idfsSettlement,
              _set_func = (o, val) => { o.idfsSettlement = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_idfsSettlement, c)) 
                  m.Add(_str_idfsSettlement, o.ObjectIdent + _str_idfsSettlement, "Int64", o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(), o.IsReadOnly(_str_idfsSettlement), o.IsInvisible(_str_idfsSettlement), o.IsRequired(_str_idfsSettlement)); }
              }, 
        
            new field_info {
              _name = _str_SettlementDefaultName, _type = "String",
              _get_func = o => o.SettlementDefaultName,
              _set_func = (o, val) => { o.SettlementDefaultName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.SettlementDefaultName != c.SettlementDefaultName || o.IsRIRPropChanged(_str_SettlementDefaultName, c)) 
                  m.Add(_str_SettlementDefaultName, o.ObjectIdent + _str_SettlementDefaultName, "String", o.SettlementDefaultName == null ? "" : o.SettlementDefaultName.ToString(), o.IsReadOnly(_str_SettlementDefaultName), o.IsInvisible(_str_SettlementDefaultName), o.IsRequired(_str_SettlementDefaultName)); }
              }, 
        
            new field_info {
              _name = _str_SettlementNationalName, _type = "String",
              _get_func = o => o.SettlementNationalName,
              _set_func = (o, val) => { o.SettlementNationalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.SettlementNationalName != c.SettlementNationalName || o.IsRIRPropChanged(_str_SettlementNationalName, c)) 
                  m.Add(_str_SettlementNationalName, o.ObjectIdent + _str_SettlementNationalName, "String", o.SettlementNationalName == null ? "" : o.SettlementNationalName.ToString(), o.IsReadOnly(_str_SettlementNationalName), o.IsInvisible(_str_SettlementNationalName), o.IsRequired(_str_SettlementNationalName)); }
              }, 
        
            new field_info {
              _name = _str_idfsSettlementType, _type = "Int64",
              _get_func = o => o.idfsSettlementType,
              _set_func = (o, val) => { o.idfsSettlementType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlementType != c.idfsSettlementType || o.IsRIRPropChanged(_str_idfsSettlementType, c)) 
                  m.Add(_str_idfsSettlementType, o.ObjectIdent + _str_idfsSettlementType, "Int64", o.idfsSettlementType == null ? "" : o.idfsSettlementType.ToString(), o.IsReadOnly(_str_idfsSettlementType), o.IsInvisible(_str_idfsSettlementType), o.IsRequired(_str_idfsSettlementType)); }
              }, 
        
            new field_info {
              _name = _str_SettlementTypeDefaultName, _type = "String",
              _get_func = o => o.SettlementTypeDefaultName,
              _set_func = (o, val) => { o.SettlementTypeDefaultName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.SettlementTypeDefaultName != c.SettlementTypeDefaultName || o.IsRIRPropChanged(_str_SettlementTypeDefaultName, c)) 
                  m.Add(_str_SettlementTypeDefaultName, o.ObjectIdent + _str_SettlementTypeDefaultName, "String", o.SettlementTypeDefaultName == null ? "" : o.SettlementTypeDefaultName.ToString(), o.IsReadOnly(_str_SettlementTypeDefaultName), o.IsInvisible(_str_SettlementTypeDefaultName), o.IsRequired(_str_SettlementTypeDefaultName)); }
              }, 
        
            new field_info {
              _name = _str_SettlementTypeNationalName, _type = "String",
              _get_func = o => o.SettlementTypeNationalName,
              _set_func = (o, val) => { o.SettlementTypeNationalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.SettlementTypeNationalName != c.SettlementTypeNationalName || o.IsRIRPropChanged(_str_SettlementTypeNationalName, c)) 
                  m.Add(_str_SettlementTypeNationalName, o.ObjectIdent + _str_SettlementTypeNationalName, "String", o.SettlementTypeNationalName == null ? "" : o.SettlementTypeNationalName.ToString(), o.IsReadOnly(_str_SettlementTypeNationalName), o.IsInvisible(_str_SettlementTypeNationalName), o.IsRequired(_str_SettlementTypeNationalName)); }
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
              _name = _str_CountryDefaultName, _type = "String",
              _get_func = o => o.CountryDefaultName,
              _set_func = (o, val) => { o.CountryDefaultName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.CountryDefaultName != c.CountryDefaultName || o.IsRIRPropChanged(_str_CountryDefaultName, c)) 
                  m.Add(_str_CountryDefaultName, o.ObjectIdent + _str_CountryDefaultName, "String", o.CountryDefaultName == null ? "" : o.CountryDefaultName.ToString(), o.IsReadOnly(_str_CountryDefaultName), o.IsInvisible(_str_CountryDefaultName), o.IsRequired(_str_CountryDefaultName)); }
              }, 
        
            new field_info {
              _name = _str_CountryNationalName, _type = "String",
              _get_func = o => o.CountryNationalName,
              _set_func = (o, val) => { o.CountryNationalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.CountryNationalName != c.CountryNationalName || o.IsRIRPropChanged(_str_CountryNationalName, c)) 
                  m.Add(_str_CountryNationalName, o.ObjectIdent + _str_CountryNationalName, "String", o.CountryNationalName == null ? "" : o.CountryNationalName.ToString(), o.IsReadOnly(_str_CountryNationalName), o.IsInvisible(_str_CountryNationalName), o.IsRequired(_str_CountryNationalName)); }
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
              _name = _str_RegionDefaultName, _type = "String",
              _get_func = o => o.RegionDefaultName,
              _set_func = (o, val) => { o.RegionDefaultName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.RegionDefaultName != c.RegionDefaultName || o.IsRIRPropChanged(_str_RegionDefaultName, c)) 
                  m.Add(_str_RegionDefaultName, o.ObjectIdent + _str_RegionDefaultName, "String", o.RegionDefaultName == null ? "" : o.RegionDefaultName.ToString(), o.IsReadOnly(_str_RegionDefaultName), o.IsInvisible(_str_RegionDefaultName), o.IsRequired(_str_RegionDefaultName)); }
              }, 
        
            new field_info {
              _name = _str_RegionNationalName, _type = "String",
              _get_func = o => o.RegionNationalName,
              _set_func = (o, val) => { o.RegionNationalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.RegionNationalName != c.RegionNationalName || o.IsRIRPropChanged(_str_RegionNationalName, c)) 
                  m.Add(_str_RegionNationalName, o.ObjectIdent + _str_RegionNationalName, "String", o.RegionNationalName == null ? "" : o.RegionNationalName.ToString(), o.IsReadOnly(_str_RegionNationalName), o.IsInvisible(_str_RegionNationalName), o.IsRequired(_str_RegionNationalName)); }
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
              _name = _str_RayonDefaultName, _type = "String",
              _get_func = o => o.RayonDefaultName,
              _set_func = (o, val) => { o.RayonDefaultName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.RayonDefaultName != c.RayonDefaultName || o.IsRIRPropChanged(_str_RayonDefaultName, c)) 
                  m.Add(_str_RayonDefaultName, o.ObjectIdent + _str_RayonDefaultName, "String", o.RayonDefaultName == null ? "" : o.RayonDefaultName.ToString(), o.IsReadOnly(_str_RayonDefaultName), o.IsInvisible(_str_RayonDefaultName), o.IsRequired(_str_RayonDefaultName)); }
              }, 
        
            new field_info {
              _name = _str_RayonNationalName, _type = "String",
              _get_func = o => o.RayonNationalName,
              _set_func = (o, val) => { o.RayonNationalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.RayonNationalName != c.RayonNationalName || o.IsRIRPropChanged(_str_RayonNationalName, c)) 
                  m.Add(_str_RayonNationalName, o.ObjectIdent + _str_RayonNationalName, "String", o.RayonNationalName == null ? "" : o.RayonNationalName.ToString(), o.IsReadOnly(_str_RayonNationalName), o.IsInvisible(_str_RayonNationalName), o.IsRequired(_str_RayonNationalName)); }
              }, 
        
            new field_info {
              _name = _str_strSettlementCode, _type = "String",
              _get_func = o => o.strSettlementCode,
              _set_func = (o, val) => { o.strSettlementCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSettlementCode != c.strSettlementCode || o.IsRIRPropChanged(_str_strSettlementCode, c)) 
                  m.Add(_str_strSettlementCode, o.ObjectIdent + _str_strSettlementCode, "String", o.strSettlementCode == null ? "" : o.strSettlementCode.ToString(), o.IsReadOnly(_str_strSettlementCode), o.IsInvisible(_str_strSettlementCode), o.IsRequired(_str_strSettlementCode)); }
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
              _name = _str_dblLatitude, _type = "Double?",
              _get_func = o => o.dblLatitude,
              _set_func = (o, val) => { o.dblLatitude = ParsingHelper.ParseDoubleNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.dblLatitude != c.dblLatitude || o.IsRIRPropChanged(_str_dblLatitude, c)) 
                  m.Add(_str_dblLatitude, o.ObjectIdent + _str_dblLatitude, "Double?", o.dblLatitude == null ? "" : o.dblLatitude.ToString(), o.IsReadOnly(_str_dblLatitude), o.IsInvisible(_str_dblLatitude), o.IsRequired(_str_dblLatitude)); }
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
              _name = _str_SettlementType, _type = "Lookup",
              _get_func = o => { if (o.SettlementType == null) return null; return o.SettlementType.idfsReference; },
              _set_func = (o, val) => { o.SettlementType = o.SettlementTypeLookup.Where(c => c.idfsReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlementType != c.idfsSettlementType || o.IsRIRPropChanged(_str_SettlementType, c)) 
                  m.Add(_str_SettlementType, o.ObjectIdent + _str_SettlementType, "Lookup", o.idfsSettlementType == null ? "" : o.idfsSettlementType.ToString(), o.IsReadOnly(_str_SettlementType), o.IsInvisible(_str_SettlementType), o.IsRequired(_str_SettlementType)); }
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
            SettlementListItem obj = (SettlementListItem)o;
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
            
        [Relation(typeof(SettlementTypeLookup), eidss.model.Schema.SettlementTypeLookup._str_idfsReference, _str_idfsSettlementType)]
        public SettlementTypeLookup SettlementType
        {
            get { return _SettlementType == null ? null : ((long)_SettlementType.Key == 0 ? null : _SettlementType); }
            set 
            { 
                _SettlementType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsSettlementType = _SettlementType == null 
                    ? new Int64()
                    : _SettlementType.idfsReference; 
                OnPropertyChanged(_str_SettlementType); 
            }
        }
        private SettlementTypeLookup _SettlementType;

        
        public List<SettlementTypeLookup> SettlementTypeLookup
        {
            get { return _SettlementTypeLookup; }
        }
        private List<SettlementTypeLookup> _SettlementTypeLookup = new List<SettlementTypeLookup>();
            
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
            
                case _str_SettlementType:
                    return new BvSelectList(SettlementTypeLookup, eidss.model.Schema.SettlementTypeLookup._str_idfsReference, null, SettlementType, _str_idfsSettlementType);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "SettlementListItem";

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
            var ret = base.Clone() as SettlementListItem;
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
            var ret = base.Clone() as SettlementListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public SettlementListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as SettlementListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsSettlement; } }
        public string KeyName { get { return "idfsSettlement"; } }
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
            var _prev_idfsSettlementType_SettlementType = idfsSettlementType;
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
            if (_prev_idfsSettlementType_SettlementType != idfsSettlementType)
            {
                _SettlementType = _SettlementTypeLookup.FirstOrDefault(c => c.idfsReference == idfsSettlementType);
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

      private bool IsRIRPropChanged(string fld, SettlementListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public SettlementListItem()
        {
            
            m_permissions = new Permissions(this);
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SettlementListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(SettlementListItem_PropertyChanged);
        }
        private void SettlementListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as SettlementListItem).Changed(e.PropertyName);
            
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
            SettlementListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            SettlementListItem obj = this;
            
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


        public Dictionary<string, Func<SettlementListItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<SettlementListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<SettlementListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<SettlementListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<SettlementListItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<SettlementListItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~SettlementListItem()
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
                
                LookupManager.RemoveObject("SettlementTypeLookup", this);
                
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
            
            if (lookup_object == "SettlementTypeLookup")
                _getAccessor().LoadLookup_SettlementType(manager, this);
            
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
    
        #region Class for web grid
        public class SettlementListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfsSettlement { get; set; }
        
            public String SettlementDefaultName { get; set; }
        
            public String SettlementNationalName { get; set; }
        
            public String SettlementTypeNationalName { get; set; }
        
            public String CountryNationalName { get; set; }
        
            public String RegionNationalName { get; set; }
        
            public String RayonNationalName { get; set; }
        
            public String strSettlementCode { get; set; }
        
            public Double? dblLongitude { get; set; }
        
            public Double? dblLatitude { get; set; }
        
        }
        public partial class SettlementListItemGridModelList : List<SettlementListItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public SettlementListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<SettlementListItem>, errMes);
            }
            public SettlementListItemGridModelList(long key, IEnumerable<SettlementListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<SettlementListItem> items);
            private void LoadGridModelList(long key, IEnumerable<SettlementListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_SettlementDefaultName,_str_SettlementNationalName,_str_SettlementTypeNationalName,_str_CountryNationalName,_str_RegionNationalName,_str_RayonNationalName,_str_strSettlementCode,_str_dblLongitude,_str_dblLatitude};
                    
                Hiddens = new List<string> {_str_idfsSettlement};
                Keys = new List<string> {_str_idfsSettlement};
                Labels = new Dictionary<string, string> {{_str_SettlementDefaultName, _str_SettlementDefaultName},{_str_SettlementNationalName, _str_SettlementNationalName},{_str_SettlementTypeNationalName, _str_SettlementTypeNationalName},{_str_CountryNationalName, "idfsCountry"},{_str_RegionNationalName, "idfsRegion"},{_str_RayonNationalName, "idfsRayon"},{_str_strSettlementCode, _str_strSettlementCode},{_str_dblLongitude, _str_dblLongitude},{_str_dblLatitude, _str_dblLatitude}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<SettlementListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new SettlementListItemGridModel()
                {
                    ItemKey=c.idfsSettlement,SettlementDefaultName=c.SettlementDefaultName,SettlementNationalName=c.SettlementNationalName,SettlementTypeNationalName=c.SettlementTypeNationalName,CountryNationalName=c.CountryNationalName,RegionNationalName=c.RegionNationalName,RayonNationalName=c.RayonNationalName,strSettlementCode=c.strSettlementCode,dblLongitude=c.dblLongitude,dblLatitude=c.dblLatitude
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
        : DataAccessor<SettlementListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectList
                    
            , IObjectPost
                    
        {
            private delegate void on_action(SettlementListItem obj);
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
            private SettlementTypeLookup.Accessor SettlementTypeAccessor { get { return eidss.model.Schema.SettlementTypeLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<SettlementListItem> SelectListT(DbManagerProxy manager
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
            
            private List<SettlementListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_Settlement_SelectList.* from dbo.fn_Settlement_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfsSettlement"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSettlement"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSettlement") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Settlement_SelectList.idfsSettlement,0) {0} @idfsSettlement_{1}", filters.Operation("idfsSettlement", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("SettlementDefaultName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("SettlementDefaultName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("SettlementDefaultName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Settlement_SelectList.SettlementDefaultName {0} @SettlementDefaultName_{1}", filters.Operation("SettlementDefaultName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("SettlementNationalName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("SettlementNationalName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("SettlementNationalName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Settlement_SelectList.SettlementNationalName {0} @SettlementNationalName_{1}", filters.Operation("SettlementNationalName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSettlementType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSettlementType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSettlementType") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Settlement_SelectList.idfsSettlementType,0) {0} @idfsSettlementType_{1}", filters.Operation("idfsSettlementType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("SettlementTypeDefaultName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("SettlementTypeDefaultName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("SettlementTypeDefaultName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Settlement_SelectList.SettlementTypeDefaultName {0} @SettlementTypeDefaultName_{1}", filters.Operation("SettlementTypeDefaultName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("SettlementTypeNationalName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("SettlementTypeNationalName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("SettlementTypeNationalName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Settlement_SelectList.SettlementTypeNationalName {0} @SettlementTypeNationalName_{1}", filters.Operation("SettlementTypeNationalName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCountry"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCountry"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCountry") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Settlement_SelectList.idfsCountry,0) {0} @idfsCountry_{1}", filters.Operation("idfsCountry", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("CountryDefaultName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("CountryDefaultName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("CountryDefaultName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Settlement_SelectList.CountryDefaultName {0} @CountryDefaultName_{1}", filters.Operation("CountryDefaultName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("CountryNationalName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("CountryNationalName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("CountryNationalName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Settlement_SelectList.CountryNationalName {0} @CountryNationalName_{1}", filters.Operation("CountryNationalName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsRegion"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsRegion"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsRegion") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Settlement_SelectList.idfsRegion,0) {0} @idfsRegion_{1}", filters.Operation("idfsRegion", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("RegionDefaultName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("RegionDefaultName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("RegionDefaultName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Settlement_SelectList.RegionDefaultName {0} @RegionDefaultName_{1}", filters.Operation("RegionDefaultName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("RegionNationalName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("RegionNationalName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("RegionNationalName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Settlement_SelectList.RegionNationalName {0} @RegionNationalName_{1}", filters.Operation("RegionNationalName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsRayon"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsRayon"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsRayon") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_Settlement_SelectList.idfsRayon,0) {0} @idfsRayon_{1}", filters.Operation("idfsRayon", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("RayonDefaultName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("RayonDefaultName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("RayonDefaultName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Settlement_SelectList.RayonDefaultName {0} @RayonDefaultName_{1}", filters.Operation("RayonDefaultName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("RayonNationalName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("RayonNationalName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("RayonNationalName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Settlement_SelectList.RayonNationalName {0} @RayonNationalName_{1}", filters.Operation("RayonNationalName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSettlementCode"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSettlementCode"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSettlementCode") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Settlement_SelectList.strSettlementCode {0} @strSettlementCode_{1}", filters.Operation("strSettlementCode", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("dblLongitude"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("dblLongitude"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("dblLongitude") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Settlement_SelectList.dblLongitude {0} @dblLongitude_{1}", filters.Operation("dblLongitude", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("dblLatitude"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("dblLatitude"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("dblLatitude") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Settlement_SelectList.dblLatitude {0} @dblLatitude_{1}", filters.Operation("dblLatitude", i), i);
                            
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
                    manager
                        .SetCommand(sql.ToString()
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                        );
                    
                    if (filters.Contains("idfsSettlement"))
                        for (int i = 0; i < filters.Count("idfsSettlement"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSettlement_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSettlement", i), filters.Value("idfsSettlement", i))));
                      
                    if (filters.Contains("SettlementDefaultName"))
                        for (int i = 0; i < filters.Count("SettlementDefaultName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@SettlementDefaultName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("SettlementDefaultName", i), filters.Value("SettlementDefaultName", i))));
                      
                    if (filters.Contains("SettlementNationalName"))
                        for (int i = 0; i < filters.Count("SettlementNationalName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@SettlementNationalName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("SettlementNationalName", i), filters.Value("SettlementNationalName", i))));
                      
                    if (filters.Contains("idfsSettlementType"))
                        for (int i = 0; i < filters.Count("idfsSettlementType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSettlementType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSettlementType", i), filters.Value("idfsSettlementType", i))));
                      
                    if (filters.Contains("SettlementTypeDefaultName"))
                        for (int i = 0; i < filters.Count("SettlementTypeDefaultName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@SettlementTypeDefaultName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("SettlementTypeDefaultName", i), filters.Value("SettlementTypeDefaultName", i))));
                      
                    if (filters.Contains("SettlementTypeNationalName"))
                        for (int i = 0; i < filters.Count("SettlementTypeNationalName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@SettlementTypeNationalName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("SettlementTypeNationalName", i), filters.Value("SettlementTypeNationalName", i))));
                      
                    if (filters.Contains("idfsCountry"))
                        for (int i = 0; i < filters.Count("idfsCountry"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCountry_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCountry", i), filters.Value("idfsCountry", i))));
                      
                    if (filters.Contains("CountryDefaultName"))
                        for (int i = 0; i < filters.Count("CountryDefaultName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@CountryDefaultName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("CountryDefaultName", i), filters.Value("CountryDefaultName", i))));
                      
                    if (filters.Contains("CountryNationalName"))
                        for (int i = 0; i < filters.Count("CountryNationalName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@CountryNationalName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("CountryNationalName", i), filters.Value("CountryNationalName", i))));
                      
                    if (filters.Contains("idfsRegion"))
                        for (int i = 0; i < filters.Count("idfsRegion"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion", i), filters.Value("idfsRegion", i))));
                      
                    if (filters.Contains("RegionDefaultName"))
                        for (int i = 0; i < filters.Count("RegionDefaultName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@RegionDefaultName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("RegionDefaultName", i), filters.Value("RegionDefaultName", i))));
                      
                    if (filters.Contains("RegionNationalName"))
                        for (int i = 0; i < filters.Count("RegionNationalName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@RegionNationalName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("RegionNationalName", i), filters.Value("RegionNationalName", i))));
                      
                    if (filters.Contains("idfsRayon"))
                        for (int i = 0; i < filters.Count("idfsRayon"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon", i), filters.Value("idfsRayon", i))));
                      
                    if (filters.Contains("RayonDefaultName"))
                        for (int i = 0; i < filters.Count("RayonDefaultName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@RayonDefaultName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("RayonDefaultName", i), filters.Value("RayonDefaultName", i))));
                      
                    if (filters.Contains("RayonNationalName"))
                        for (int i = 0; i < filters.Count("RayonNationalName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@RayonNationalName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("RayonNationalName", i), filters.Value("RayonNationalName", i))));
                      
                    if (filters.Contains("strSettlementCode"))
                        for (int i = 0; i < filters.Count("strSettlementCode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSettlementCode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSettlementCode", i), filters.Value("strSettlementCode", i))));
                      
                    if (filters.Contains("dblLongitude"))
                        for (int i = 0; i < filters.Count("dblLongitude"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@dblLongitude_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("dblLongitude", i), filters.Value("dblLongitude", i))));
                      
                    if (filters.Contains("dblLatitude"))
                        for (int i = 0; i < filters.Count("dblLatitude"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@dblLatitude_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("dblLatitude", i), filters.Value("dblLatitude", i))));
                      
                    List<SettlementListItem> objs = manager.ExecuteList<SettlementListItem>();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                    }
                    return objs;
                }
                catch(DataException e)
                {
                    if (bTransactionStarted)
                    {
                        manager.RollbackTransaction();
                    }
                    throw DbModelException.Create(e);
                }
            }
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spSettlement_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, SettlementListItem obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, SettlementListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private SettlementListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    SettlementListItem obj = SettlementListItem.CreateInstance();
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
                obj.Country = new Func<SettlementListItem, CountryLookup>(c => 
                                     c.CountryLookup.Where(a => a.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID)
                                     .SingleOrDefault())(obj);
                obj.Region = new Func<SettlementListItem, RegionLookup>(c => 
                                     c.RegionLookup.Where(a => a.idfsRegion == eidss.model.Core.EidssSiteContext.Instance.RegionID)
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

            
            public SettlementListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public SettlementListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(SettlementListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(SettlementListItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.Region = new Func<SettlementListItem, RegionLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.Rayon = new Func<SettlementListItem, RayonLookup>(c => null)(obj);
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
                    
                    };
                
            }
    
            public void LoadLookup_Country(DbManagerProxy manager, SettlementListItem obj)
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
            
            public void LoadLookup_Region(DbManagerProxy manager, SettlementListItem obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<SettlementListItem, long>(c => c.idfsCountry ?? 0)(obj)
                            
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
            
            public void LoadLookup_Rayon(DbManagerProxy manager, SettlementListItem obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<SettlementListItem, long>(c => c.idfsRegion ?? 0)(obj)
                            
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
            
            public void LoadLookup_SettlementType(DbManagerProxy manager, SettlementListItem obj)
            {
                
                obj.SettlementTypeLookup.Clear();
                
                obj.SettlementTypeLookup.Add(SettlementTypeAccessor.CreateNewT(manager, null));
                
                obj.SettlementTypeLookup.AddRange(SettlementTypeAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsReference == obj.idfsSettlementType))
                    
                    .ToList());
                
                if (obj.idfsSettlementType != 0)
                {
                    obj.SettlementType = obj.SettlementTypeLookup
                        .Where(c => c.idfsReference == obj.idfsSettlementType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("SettlementTypeLookup", obj, SettlementTypeAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, SettlementListItem obj)
            {
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_SettlementType(manager, obj);
                
            }
    
            [SprocName("spSettlement_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spSettlement_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? idfsSettlement
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? idfsSettlement
                )
            {
                
                _postDelete(manager, idfsSettlement);
                
            }
        
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    SettlementListItem bo = obj as SettlementListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("GisReference", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("GisReference", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("GisReference", "Update");
                    }
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        long mainObject = bo.idfsSettlement;
                        
                        eidss.model.Enums.EventType eventType = eidss.model.Enums.EventType.ReferenceTableChanged;
                        manager.SetEventParams("ReferenceTableChanged", new object[] { eventType, null, "Settlement" });
                        
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoSettlement;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.gisSettlement;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as SettlementListItem, bChildObject);
                    if (bTransactionStarted)
                    {
                        if (bSuccess)
                        {
                            manager.CommitTransaction();
                            
                            LookupManager.ClearByTable("Settlement");
                            
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
            private bool _PostNonTransaction(DbManagerProxy manager, SettlementListItem obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfsSettlement
                        );
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(SettlementListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, SettlementListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfsSettlement
                            , out result
                            );
                        if (!result) 
                        {
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, false);
                        }
                     }
                }
                catch(ValidationModelException ex)
                {
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                        return false;
                    }
                    else
                        obj.m_IsForcedToDelete = true;
                }
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as SettlementListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, SettlementListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("GisReference.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("GisReference.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("GisReference.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("GisReference.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(SettlementListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(SettlementListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as SettlementListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as SettlementListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "SettlementListItemDetail"; } }
            public string HelpIdWin { get { return "settlements"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private SettlementListItem m_obj;
            internal Permissions(SettlementListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("GisReference.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("GisReference.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("GisReference.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("GisReference.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_Settlement_SelectList";
            public static string spCount = "spSettlement_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spSettlement_Delete";
            public static string spCanDelete = "spSettlement_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<SettlementListItem, bool>> RequiredByField = new Dictionary<string, Func<SettlementListItem, bool>>();
            public static Dictionary<string, Func<SettlementListItem, bool>> RequiredByProperty = new Dictionary<string, Func<SettlementListItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_SettlementDefaultName, 255);
                Sizes.Add(_str_SettlementNationalName, 255);
                Sizes.Add(_str_SettlementTypeDefaultName, 255);
                Sizes.Add(_str_SettlementTypeNationalName, 255);
                Sizes.Add(_str_CountryDefaultName, 255);
                Sizes.Add(_str_CountryNationalName, 255);
                Sizes.Add(_str_RegionDefaultName, 255);
                Sizes.Add(_str_RegionNationalName, 255);
                Sizes.Add(_str_RayonDefaultName, 255);
                Sizes.Add(_str_RayonNationalName, 255);
                Sizes.Add(_str_strSettlementCode, 200);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "SettlementDefaultName",
                    EditorType.Text,
                    false, false, 
                    "SettlementDefaultName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "SettlementNationalName",
                    EditorType.Text,
                    false, false, 
                    "SettlementNationalName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSettlementType",
                    EditorType.Lookup,
                    false, false, 
                    "SettlementTypeNationalName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "SettlementTypeLookup", typeof(SettlementTypeLookup), (o) => { var c = (SettlementTypeLookup)o; return c.idfsReference; }, (o) => { var c = (SettlementTypeLookup)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsCountry",
                    EditorType.Lookup,
                    false, false, 
                    "idfsCountry",
                    null, null, false, false, SearchPanelLocation.Main, false, "idfsRegion", "CountryLookup", typeof(CountryLookup), (o) => { var c = (CountryLookup)o; return c.idfsCountry; }, (o) => { var c = (CountryLookup)o; return c.strCountryName; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRegion",
                    EditorType.Lookup,
                    false, false, 
                    "idfsRegion",
                    null, "=", false, false, SearchPanelLocation.Main, false, "idfsRayon", "RegionLookup", typeof(RegionLookup), (o) => { var c = (RegionLookup)o; return c.idfsRegion; }, (o) => { var c = (RegionLookup)o; return c.strRegionName; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRayon",
                    EditorType.Lookup,
                    false, false, 
                    "idfsRayon",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "RayonLookup", typeof(RayonLookup), (o) => { var c = (RayonLookup)o; return c.idfsRayon; }, (o) => { var c = (RayonLookup)o; return c.strRayonName; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strSettlementCode",
                    EditorType.Text,
                    false, false, 
                    "strSettlementCode",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "dblLongitude",
                    EditorType.Numeric,
                    false, false, 
                    "dblLongitude",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "dblLatitude",
                    EditorType.Numeric,
                    false, false, 
                    "dblLatitude",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsSettlement,
                    _str_idfsSettlement, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_SettlementDefaultName,
                    _str_SettlementDefaultName, null, true, true, ListSortDirection.Ascending
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_SettlementNationalName,
                    _str_SettlementNationalName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_SettlementTypeNationalName,
                    _str_SettlementTypeNationalName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_CountryNationalName,
                    "idfsCountry", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_RegionNationalName,
                    "idfsRegion", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_RayonNationalName,
                    "idfsRayon", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSettlementCode,
                    _str_strSettlementCode, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_dblLongitude,
                    _str_dblLongitude, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_dblLatitude,
                    _str_dblLatitude, null, true, true, null
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<Settlement>().CreateNew(manager, null, pars == null ? null : (int?)pars[0])),
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<Settlement>().SelectDetail(manager, pars[0])),
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
                                c = ObjectAccessor.CreatorInterface<SettlementListItem>().CreateWithParams(manager, null, pars);
                                ((SettlementListItem)c).idfsSettlement = (long)pars[0];
                                ((SettlementListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((SettlementListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<SettlementListItem>().Post(manager, (SettlementListItem)c), c);
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	