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
    public abstract partial class PatientListItem : 
        EditableObject<PatientListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfHumanActual), NonUpdatable, PrimaryKey]
        public abstract Int64 idfHumanActual { get; set; }
                
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
                
        [LocalizedDisplayName(_str_strLastName)]
        [MapField(_str_strLastName)]
        public abstract String strLastName { get; set; }
        protected String strLastName_Original { get { return ((EditableValue<String>)((dynamic)this)._strLastName).OriginalValue; } }
        protected String strLastName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strLastName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datDateofBirth)]
        [MapField(_str_datDateofBirth)]
        public abstract DateTime? datDateofBirth { get; set; }
        protected DateTime? datDateofBirth_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateofBirth).OriginalValue; } }
        protected DateTime? datDateofBirth_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateofBirth).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfCurrentResidenceAddress)]
        [MapField(_str_idfCurrentResidenceAddress)]
        public abstract Int64? idfCurrentResidenceAddress { get; set; }
        protected Int64? idfCurrentResidenceAddress_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCurrentResidenceAddress).OriginalValue; } }
        protected Int64? idfCurrentResidenceAddress_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCurrentResidenceAddress).PreviousValue; } }
                
        [LocalizedDisplayName(_str_AddressName)]
        [MapField(_str_AddressName)]
        public abstract String AddressName { get; set; }
        protected String AddressName_Original { get { return ((EditableValue<String>)((dynamic)this)._addressName).OriginalValue; } }
        protected String AddressName_Previous { get { return ((EditableValue<String>)((dynamic)this)._addressName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsPersonIDType)]
        [MapField(_str_idfsPersonIDType)]
        public abstract Int64? idfsPersonIDType { get; set; }
        protected Int64? idfsPersonIDType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPersonIDType).OriginalValue; } }
        protected Int64? idfsPersonIDType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPersonIDType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPersonID)]
        [MapField(_str_strPersonID)]
        public abstract String strPersonID { get; set; }
        protected String strPersonID_Original { get { return ((EditableValue<String>)((dynamic)this)._strPersonID).OriginalValue; } }
        protected String strPersonID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPersonID).PreviousValue; } }
                
        [LocalizedDisplayName("Patient.datEnteredDate")]
        [MapField(_str_datEnteredDate)]
        public abstract DateTime? datEnteredDate { get; set; }
        protected DateTime? datEnteredDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).OriginalValue; } }
        protected DateTime? datEnteredDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).PreviousValue; } }
                
        [LocalizedDisplayName("Patient.datModificationDate")]
        [MapField(_str_datModificationDate)]
        public abstract DateTime? datModificationDate { get; set; }
        protected DateTime? datModificationDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datModificationDate).OriginalValue; } }
        protected DateTime? datModificationDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datModificationDate).PreviousValue; } }
                
        [LocalizedDisplayName("idfsPersonIDType")]
        [MapField(_str_strPersonIDType)]
        public abstract String strPersonIDType { get; set; }
        protected String strPersonIDType_Original { get { return ((EditableValue<String>)((dynamic)this)._strPersonIDType).OriginalValue; } }
        protected String strPersonIDType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPersonIDType).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<PatientListItem, object> _get_func;
            internal Action<PatientListItem, string> _set_func;
            internal Action<PatientListItem, PatientListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfHumanActual = "idfHumanActual";
        internal const string _str_strFirstName = "strFirstName";
        internal const string _str_strSecondName = "strSecondName";
        internal const string _str_strLastName = "strLastName";
        internal const string _str_datDateofBirth = "datDateofBirth";
        internal const string _str_idfCurrentResidenceAddress = "idfCurrentResidenceAddress";
        internal const string _str_AddressName = "AddressName";
        internal const string _str_idfsPersonIDType = "idfsPersonIDType";
        internal const string _str_strPersonID = "strPersonID";
        internal const string _str_datEnteredDate = "datEnteredDate";
        internal const string _str_datModificationDate = "datModificationDate";
        internal const string _str_strPersonIDType = "strPersonIDType";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_PersonIDType = "PersonIDType";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfHumanActual, _formname = _str_idfHumanActual, _type = "Int64",
              _get_func = o => o.idfHumanActual,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfHumanActual != newval) o.idfHumanActual = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfHumanActual != c.idfHumanActual || o.IsRIRPropChanged(_str_idfHumanActual, c)) 
                  m.Add(_str_idfHumanActual, o.ObjectIdent + _str_idfHumanActual, o.ObjectIdent2 + _str_idfHumanActual, o.ObjectIdent3 + _str_idfHumanActual, "Int64", 
                    o.idfHumanActual == null ? "" : o.idfHumanActual.ToString(),                  
                  o.IsReadOnly(_str_idfHumanActual), o.IsInvisible(_str_idfHumanActual), o.IsRequired(_str_idfHumanActual)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFirstName, _formname = _str_strFirstName, _type = "String",
              _get_func = o => o.strFirstName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFirstName != newval) o.strFirstName = newval; },
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
                if (o.strSecondName != c.strSecondName || o.IsRIRPropChanged(_str_strSecondName, c)) 
                  m.Add(_str_strSecondName, o.ObjectIdent + _str_strSecondName, o.ObjectIdent2 + _str_strSecondName, o.ObjectIdent3 + _str_strSecondName, "String", 
                    o.strSecondName == null ? "" : o.strSecondName.ToString(),                  
                  o.IsReadOnly(_str_strSecondName), o.IsInvisible(_str_strSecondName), o.IsRequired(_str_strSecondName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strLastName, _formname = _str_strLastName, _type = "String",
              _get_func = o => o.strLastName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strLastName != newval) o.strLastName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strLastName != c.strLastName || o.IsRIRPropChanged(_str_strLastName, c)) 
                  m.Add(_str_strLastName, o.ObjectIdent + _str_strLastName, o.ObjectIdent2 + _str_strLastName, o.ObjectIdent3 + _str_strLastName, "String", 
                    o.strLastName == null ? "" : o.strLastName.ToString(),                  
                  o.IsReadOnly(_str_strLastName), o.IsInvisible(_str_strLastName), o.IsRequired(_str_strLastName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDateofBirth, _formname = _str_datDateofBirth, _type = "DateTime?",
              _get_func = o => o.datDateofBirth,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDateofBirth != newval) o.datDateofBirth = newval; },
              _compare_func = (o, c, m) => {
                if (o.datDateofBirth != c.datDateofBirth || o.IsRIRPropChanged(_str_datDateofBirth, c)) 
                  m.Add(_str_datDateofBirth, o.ObjectIdent + _str_datDateofBirth, o.ObjectIdent2 + _str_datDateofBirth, o.ObjectIdent3 + _str_datDateofBirth, "DateTime?", 
                    o.datDateofBirth == null ? "" : o.datDateofBirth.ToString(),                  
                  o.IsReadOnly(_str_datDateofBirth), o.IsInvisible(_str_datDateofBirth), o.IsRequired(_str_datDateofBirth)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfCurrentResidenceAddress, _formname = _str_idfCurrentResidenceAddress, _type = "Int64?",
              _get_func = o => o.idfCurrentResidenceAddress,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfCurrentResidenceAddress != newval) o.idfCurrentResidenceAddress = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfCurrentResidenceAddress != c.idfCurrentResidenceAddress || o.IsRIRPropChanged(_str_idfCurrentResidenceAddress, c)) 
                  m.Add(_str_idfCurrentResidenceAddress, o.ObjectIdent + _str_idfCurrentResidenceAddress, o.ObjectIdent2 + _str_idfCurrentResidenceAddress, o.ObjectIdent3 + _str_idfCurrentResidenceAddress, "Int64?", 
                    o.idfCurrentResidenceAddress == null ? "" : o.idfCurrentResidenceAddress.ToString(),                  
                  o.IsReadOnly(_str_idfCurrentResidenceAddress), o.IsInvisible(_str_idfCurrentResidenceAddress), o.IsRequired(_str_idfCurrentResidenceAddress)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_AddressName, _formname = _str_AddressName, _type = "String",
              _get_func = o => o.AddressName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.AddressName != newval) o.AddressName = newval; },
              _compare_func = (o, c, m) => {
                if (o.AddressName != c.AddressName || o.IsRIRPropChanged(_str_AddressName, c)) 
                  m.Add(_str_AddressName, o.ObjectIdent + _str_AddressName, o.ObjectIdent2 + _str_AddressName, o.ObjectIdent3 + _str_AddressName, "String", 
                    o.AddressName == null ? "" : o.AddressName.ToString(),                  
                  o.IsReadOnly(_str_AddressName), o.IsInvisible(_str_AddressName), o.IsRequired(_str_AddressName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsPersonIDType, _formname = _str_idfsPersonIDType, _type = "Int64?",
              _get_func = o => o.idfsPersonIDType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsPersonIDType != newval) 
                  o.PersonIDType = o.PersonIDTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsPersonIDType != newval) o.idfsPersonIDType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsPersonIDType != c.idfsPersonIDType || o.IsRIRPropChanged(_str_idfsPersonIDType, c)) 
                  m.Add(_str_idfsPersonIDType, o.ObjectIdent + _str_idfsPersonIDType, o.ObjectIdent2 + _str_idfsPersonIDType, o.ObjectIdent3 + _str_idfsPersonIDType, "Int64?", 
                    o.idfsPersonIDType == null ? "" : o.idfsPersonIDType.ToString(),                  
                  o.IsReadOnly(_str_idfsPersonIDType), o.IsInvisible(_str_idfsPersonIDType), o.IsRequired(_str_idfsPersonIDType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPersonID, _formname = _str_strPersonID, _type = "String",
              _get_func = o => o.strPersonID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPersonID != newval) o.strPersonID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPersonID != c.strPersonID || o.IsRIRPropChanged(_str_strPersonID, c)) 
                  m.Add(_str_strPersonID, o.ObjectIdent + _str_strPersonID, o.ObjectIdent2 + _str_strPersonID, o.ObjectIdent3 + _str_strPersonID, "String", 
                    o.strPersonID == null ? "" : o.strPersonID.ToString(),                  
                  o.IsReadOnly(_str_strPersonID), o.IsInvisible(_str_strPersonID), o.IsRequired(_str_strPersonID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datEnteredDate, _formname = _str_datEnteredDate, _type = "DateTime?",
              _get_func = o => o.datEnteredDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datEnteredDate != newval) o.datEnteredDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datEnteredDate != c.datEnteredDate || o.IsRIRPropChanged(_str_datEnteredDate, c)) 
                  m.Add(_str_datEnteredDate, o.ObjectIdent + _str_datEnteredDate, o.ObjectIdent2 + _str_datEnteredDate, o.ObjectIdent3 + _str_datEnteredDate, "DateTime?", 
                    o.datEnteredDate == null ? "" : o.datEnteredDate.ToString(),                  
                  o.IsReadOnly(_str_datEnteredDate), o.IsInvisible(_str_datEnteredDate), o.IsRequired(_str_datEnteredDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datModificationDate, _formname = _str_datModificationDate, _type = "DateTime?",
              _get_func = o => o.datModificationDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datModificationDate != newval) o.datModificationDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datModificationDate != c.datModificationDate || o.IsRIRPropChanged(_str_datModificationDate, c)) 
                  m.Add(_str_datModificationDate, o.ObjectIdent + _str_datModificationDate, o.ObjectIdent2 + _str_datModificationDate, o.ObjectIdent3 + _str_datModificationDate, "DateTime?", 
                    o.datModificationDate == null ? "" : o.datModificationDate.ToString(),                  
                  o.IsReadOnly(_str_datModificationDate), o.IsInvisible(_str_datModificationDate), o.IsRequired(_str_datModificationDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPersonIDType, _formname = _str_strPersonIDType, _type = "String",
              _get_func = o => o.strPersonIDType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPersonIDType != newval) o.strPersonIDType = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPersonIDType != c.strPersonIDType || o.IsRIRPropChanged(_str_strPersonIDType, c)) 
                  m.Add(_str_strPersonIDType, o.ObjectIdent + _str_strPersonIDType, o.ObjectIdent2 + _str_strPersonIDType, o.ObjectIdent3 + _str_strPersonIDType, "String", 
                    o.strPersonIDType == null ? "" : o.strPersonIDType.ToString(),                  
                  o.IsReadOnly(_str_strPersonIDType), o.IsInvisible(_str_strPersonIDType), o.IsRequired(_str_strPersonIDType)); 
                  }
              }, 
        
            new field_info {
              _name = _str_idfsCountry, _formname = _str_idfsCountry, _type = "long?",
              _get_func = o => o.idfsCountry,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsCountry != newval) o.idfsCountry = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_idfsCountry, c)) {
                  m.Add(_str_idfsCountry, o.ObjectIdent + _str_idfsCountry, o.ObjectIdent2 + _str_idfsCountry, o.ObjectIdent3 + _str_idfsCountry,  "long?", 
                    o.idfsCountry == null ? "" : o.idfsCountry.ToString(),                  
                    o.IsReadOnly(_str_idfsCountry), o.IsInvisible(_str_idfsCountry), o.IsRequired(_str_idfsCountry));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsRegion, _formname = _str_idfsRegion, _type = "long?",
              _get_func = o => o.idfsRegion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsRegion != newval) o.idfsRegion = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_idfsRegion, c)) {
                  m.Add(_str_idfsRegion, o.ObjectIdent + _str_idfsRegion, o.ObjectIdent2 + _str_idfsRegion, o.ObjectIdent3 + _str_idfsRegion,  "long?", 
                    o.idfsRegion == null ? "" : o.idfsRegion.ToString(),                  
                    o.IsReadOnly(_str_idfsRegion), o.IsInvisible(_str_idfsRegion), o.IsRequired(_str_idfsRegion));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsRayon, _formname = _str_idfsRayon, _type = "long?",
              _get_func = o => o.idfsRayon,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsRayon != newval) o.idfsRayon = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_idfsRayon, c)) {
                  m.Add(_str_idfsRayon, o.ObjectIdent + _str_idfsRayon, o.ObjectIdent2 + _str_idfsRayon, o.ObjectIdent3 + _str_idfsRayon,  "long?", 
                    o.idfsRayon == null ? "" : o.idfsRayon.ToString(),                  
                    o.IsReadOnly(_str_idfsRayon), o.IsInvisible(_str_idfsRayon), o.IsRequired(_str_idfsRayon));
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
              _name = _str_PersonIDType, _formname = _str_PersonIDType, _type = "Lookup",
              _get_func = o => { if (o.PersonIDType == null) return null; return o.PersonIDType.idfsBaseReference; },
              _set_func = (o, val) => { o.PersonIDType = o.PersonIDTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsPersonIDType != c.idfsPersonIDType || o.IsRIRPropChanged(_str_PersonIDType, c)) {
                  m.Add(_str_PersonIDType, o.ObjectIdent + _str_PersonIDType, o.ObjectIdent2 + _str_PersonIDType, o.ObjectIdent3 + _str_PersonIDType, "Lookup", o.idfsPersonIDType == null ? "" : o.idfsPersonIDType.ToString(), o.IsReadOnly(_str_PersonIDType), o.IsInvisible(_str_PersonIDType), o.IsRequired(_str_PersonIDType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_PersonIDType + "Lookup", _formname = _str_PersonIDType + "Lookup", _type = "LookupContent",
              _get_func = o => o.PersonIDTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
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
            PatientListItem obj = (PatientListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
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
                            ? new long?()
                            : _Region.idfsRegion))
                        idfsRegion = _Region == null 
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
                            ? new long?()
                            : _Rayon.idfsRayon))
                        idfsRayon = _Rayon == null 
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
            
        [LocalizedDisplayName(_str_PersonIDType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsPersonIDType)]
        public BaseReference PersonIDType
        {
            get { return _PersonIDType == null ? null : ((long)_PersonIDType.Key == 0 ? null : _PersonIDType); }
            set 
            { 
                var oldVal = _PersonIDType;
                _PersonIDType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_PersonIDType != oldVal)
                {
                    if (idfsPersonIDType != (_PersonIDType == null
                            ? new Int64?()
                            : (Int64?)_PersonIDType.idfsBaseReference))
                        idfsPersonIDType = _PersonIDType == null 
                            ? new Int64?()
                            : (Int64?)_PersonIDType.idfsBaseReference; 
                    OnPropertyChanged(_str_PersonIDType); 
                }
            }
        }
        private BaseReference _PersonIDType;

        
        public BaseReferenceList PersonIDTypeLookup
        {
            get { return _PersonIDTypeLookup; }
        }
        private BaseReferenceList _PersonIDTypeLookup = new BaseReferenceList("rftPersonIDType");
            
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
            
                case _str_PersonIDType:
                    return new BvSelectList(PersonIDTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, PersonIDType, _str_idfsPersonIDType);
            
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
        
          [LocalizedDisplayName(_str_idfsRegion)]
        public long? idfsRegion
        {
            get { return m_idfsRegion; }
            set { if (m_idfsRegion != value) { m_idfsRegion = value; OnPropertyChanged(_str_idfsRegion); } }
        }
        private long? m_idfsRegion;
        
          [LocalizedDisplayName(_str_idfsRayon)]
        public long? idfsRayon
        {
            get { return m_idfsRayon; }
            set { if (m_idfsRayon != value) { m_idfsRayon = value; OnPropertyChanged(_str_idfsRayon); } }
        }
        private long? m_idfsRayon;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "PatientListItem";

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
            var ret = base.Clone() as PatientListItem;
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
            var ret = base.Clone() as PatientListItem;
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
        public PatientListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as PatientListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfHumanActual; } }
        public string KeyName { get { return "idfHumanActual"; } }
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
            var _prev_idfsPersonIDType_PersonIDType = idfsPersonIDType;
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
            if (_prev_idfsPersonIDType_PersonIDType != idfsPersonIDType)
            {
                _PersonIDType = _PersonIDTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsPersonIDType);
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

        private bool IsRIRPropChanged(string fld, PatientListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public PatientListItem()
        {
            
            m_permissions = new Permissions(this);
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(PatientListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(PatientListItem_PropertyChanged);
        }
        private void PatientListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as PatientListItem).Changed(e.PropertyName);
            
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
            PatientListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            PatientListItem obj = this;
            
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

    
        private static string[] readonly_names1 = "Region,idfsRegion".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "Rayon,idfsRayon".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<PatientListItem, bool>(c => c.idfsCountry == null)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<PatientListItem, bool>(c => c.idfsRegion == null)(this);
            
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


        internal Dictionary<string, Func<PatientListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<PatientListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<PatientListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<PatientListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<PatientListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<PatientListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<PatientListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~PatientListItem()
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
                
                LookupManager.RemoveObject("rftPersonIDType", this);
                
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
            
            if (lookup_object == "rftPersonIDType")
                _getAccessor().LoadLookup_PersonIDType(manager, this);
            
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
    
        #region Class for web grid
        public class PatientListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfHumanActual { get; set; }
        
            public String strLastName { get; set; }
        
            public String strFirstName { get; set; }
        
            public String strSecondName { get; set; }
        
            public DateTime? datDateofBirth { get; set; }
        
            public String AddressName { get; set; }
        
            public String strPersonIDType { get; set; }
        
            public String strPersonID { get; set; }
        
            public DateTime? datEnteredDate { get; set; }
        
            public DateTime? datModificationDate { get; set; }
        
        }
        public partial class PatientListItemGridModelList : List<PatientListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public PatientListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<PatientListItem>, errMes);
            }
            public PatientListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<PatientListItem>, errMes);
            }
            public PatientListItemGridModelList(long key, IEnumerable<PatientListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public PatientListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<PatientListItem>(), null);
            }
            partial void filter(List<PatientListItem> items);
            private void LoadGridModelList(long key, IEnumerable<PatientListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strLastName,_str_strFirstName,_str_strSecondName,_str_datDateofBirth,_str_AddressName,_str_strPersonIDType,_str_strPersonID,_str_datEnteredDate,_str_datModificationDate};
                    
                Hiddens = new List<string> {_str_idfHumanActual};
                Keys = new List<string> {_str_idfHumanActual};
                Labels = new Dictionary<string, string> {{_str_strLastName, _str_strLastName},{_str_strFirstName, _str_strFirstName},{_str_strSecondName, _str_strSecondName},{_str_datDateofBirth, _str_datDateofBirth},{_str_AddressName, _str_AddressName},{_str_strPersonIDType, "idfsPersonIDType"},{_str_strPersonID, _str_strPersonID},{_str_datEnteredDate, "Patient.datEnteredDate"},{_str_datModificationDate, "Patient.datModificationDate"}};
                Actions = new Dictionary<string, ActionMetaItem> {{_str_strLastName, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "ActionEditPerson")}};
                PatientListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<PatientListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new PatientListItemGridModel()
                {
                    ItemKey=c.idfHumanActual,strLastName=c.strLastName,strFirstName=c.strFirstName,strSecondName=c.strSecondName,datDateofBirth=c.datDateofBirth,AddressName=c.AddressName,strPersonIDType=c.strPersonIDType,strPersonID=c.strPersonID,datEnteredDate=c.datEnteredDate,datModificationDate=c.datModificationDate
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
        : DataAccessor<PatientListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<PatientListItem>
            
            , IObjectSelectList
            , IObjectSelectList<PatientListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfHumanActual"; } }
            #endregion
        
            private delegate void on_action(PatientListItem obj);
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
            private BaseReference.Accessor PersonIDTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<PatientListItem> SelectListT(DbManagerProxy manager
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
            
            private List<PatientListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_Patient_SelectList.* from dbo.fn_Patient_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("idfsRegion") || filters.Contains("idfsRayon"))
                {
                    
                    sql.Append(" " + @"
						LEFT JOIN	tlbGeoLocationShared geo
						ON			geo.idfGeoLocationShared = fn_Patient_SelectList.idfCurrentResidenceAddress
					");
                      
                }
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfsRegion"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsRegion") == 1)
                    {
                        sql.AppendFormat("geo.idfsRegion {0} @idfsRegion", filters.Operation("idfsRegion"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsRegion"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsRegion") ? " or " : " and ");
                            sql.AppendFormat("geo.idfsRegion {0} @idfsRegion_{1}", filters.Operation("idfsRegion", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsRayon"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsRayon") == 1)
                    {
                        sql.AppendFormat("geo.idfsRayon {0} @idfsRayon", filters.Operation("idfsRayon"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsRayon"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsRayon") ? " or " : " and ");
                            sql.AppendFormat("geo.idfsRayon {0} @idfsRayon_{1}", filters.Operation("idfsRayon", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfHumanActual"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfHumanActual"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfHumanActual") ? " or " : " and ");
                        
                        if (filters.Operation("idfHumanActual", i) == "&")
                          sql.AppendFormat("(isnull(fn_Patient_SelectList.idfHumanActual,0) {0} @idfHumanActual_{1} = @idfHumanActual_{1})", filters.Operation("idfHumanActual", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Patient_SelectList.idfHumanActual,0) {0} @idfHumanActual_{1}", filters.Operation("idfHumanActual", i), i);
                            
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
                        
                        sql.AppendFormat("fn_Patient_SelectList.strFirstName {0} @strFirstName_{1}", filters.Operation("strFirstName", i), i);
                            
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
                        
                        sql.AppendFormat("fn_Patient_SelectList.strSecondName {0} @strSecondName_{1}", filters.Operation("strSecondName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strLastName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strLastName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strLastName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Patient_SelectList.strLastName {0} @strLastName_{1}", filters.Operation("strLastName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datDateofBirth"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datDateofBirth"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datDateofBirth") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_Patient_SelectList.datDateofBirth, 112) {0} CONVERT(NVARCHAR(8), @datDateofBirth_{1}, 112)", filters.Operation("datDateofBirth", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfCurrentResidenceAddress"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfCurrentResidenceAddress"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfCurrentResidenceAddress") ? " or " : " and ");
                        
                        if (filters.Operation("idfCurrentResidenceAddress", i) == "&")
                          sql.AppendFormat("(isnull(fn_Patient_SelectList.idfCurrentResidenceAddress,0) {0} @idfCurrentResidenceAddress_{1} = @idfCurrentResidenceAddress_{1})", filters.Operation("idfCurrentResidenceAddress", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Patient_SelectList.idfCurrentResidenceAddress,0) {0} @idfCurrentResidenceAddress_{1}", filters.Operation("idfCurrentResidenceAddress", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("AddressName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("AddressName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("AddressName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Patient_SelectList.AddressName {0} @AddressName_{1}", filters.Operation("AddressName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsPersonIDType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsPersonIDType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsPersonIDType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsPersonIDType", i) == "&")
                          sql.AppendFormat("(isnull(fn_Patient_SelectList.idfsPersonIDType,0) {0} @idfsPersonIDType_{1} = @idfsPersonIDType_{1})", filters.Operation("idfsPersonIDType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Patient_SelectList.idfsPersonIDType,0) {0} @idfsPersonIDType_{1}", filters.Operation("idfsPersonIDType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strPersonID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strPersonID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strPersonID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Patient_SelectList.strPersonID {0} @strPersonID_{1}", filters.Operation("strPersonID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datEnteredDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datEnteredDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datEnteredDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_Patient_SelectList.datEnteredDate, 112) {0} CONVERT(NVARCHAR(8), @datEnteredDate_{1}, 112)", filters.Operation("datEnteredDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datModificationDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datModificationDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datModificationDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_Patient_SelectList.datModificationDate, 112) {0} CONVERT(NVARCHAR(8), @datModificationDate_{1}, 112)", filters.Operation("datModificationDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strPersonIDType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strPersonIDType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strPersonIDType") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Patient_SelectList.strPersonIDType {0} @strPersonIDType_{1}", filters.Operation("strPersonIDType", i), i);
                            
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
                    
                    if (filters.Contains("idfsRegion"))
                        
                        if (filters.Count("idfsRegion") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion", ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion"), filters.Value("idfsRegion"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsRegion"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion", i), filters.Value("idfsRegion", i))));
                        }
                            
                    if (filters.Contains("idfsRayon"))
                        
                        if (filters.Count("idfsRayon") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon", ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon"), filters.Value("idfsRayon"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsRayon"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon", i), filters.Value("idfsRayon", i))));
                        }
                            
                    if (filters.Contains("idfHumanActual"))
                        for (int i = 0; i < filters.Count("idfHumanActual"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfHumanActual_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfHumanActual", i), filters.Value("idfHumanActual", i))));
                      
                    if (filters.Contains("strFirstName"))
                        for (int i = 0; i < filters.Count("strFirstName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFirstName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFirstName", i), filters.Value("strFirstName", i))));
                      
                    if (filters.Contains("strSecondName"))
                        for (int i = 0; i < filters.Count("strSecondName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSecondName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSecondName", i), filters.Value("strSecondName", i))));
                      
                    if (filters.Contains("strLastName"))
                        for (int i = 0; i < filters.Count("strLastName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strLastName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strLastName", i), filters.Value("strLastName", i))));
                      
                    if (filters.Contains("datDateofBirth"))
                        for (int i = 0; i < filters.Count("datDateofBirth"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datDateofBirth_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datDateofBirth", i), filters.Value("datDateofBirth", i))));
                      
                    if (filters.Contains("idfCurrentResidenceAddress"))
                        for (int i = 0; i < filters.Count("idfCurrentResidenceAddress"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfCurrentResidenceAddress_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfCurrentResidenceAddress", i), filters.Value("idfCurrentResidenceAddress", i))));
                      
                    if (filters.Contains("AddressName"))
                        for (int i = 0; i < filters.Count("AddressName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@AddressName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("AddressName", i), filters.Value("AddressName", i))));
                      
                    if (filters.Contains("idfsPersonIDType"))
                        for (int i = 0; i < filters.Count("idfsPersonIDType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsPersonIDType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsPersonIDType", i), filters.Value("idfsPersonIDType", i))));
                      
                    if (filters.Contains("strPersonID"))
                        for (int i = 0; i < filters.Count("strPersonID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strPersonID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strPersonID", i), filters.Value("strPersonID", i))));
                      
                    if (filters.Contains("datEnteredDate"))
                        for (int i = 0; i < filters.Count("datEnteredDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datEnteredDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datEnteredDate", i), filters.Value("datEnteredDate", i))));
                      
                    if (filters.Contains("datModificationDate"))
                        for (int i = 0; i < filters.Count("datModificationDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datModificationDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datModificationDate", i), filters.Value("datModificationDate", i))));
                      
                    if (filters.Contains("strPersonIDType"))
                        for (int i = 0; i < filters.Count("strPersonIDType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strPersonIDType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strPersonIDType", i), filters.Value("strPersonIDType", i))));
                      
                    List<PatientListItem> objs = manager.ExecuteList<PatientListItem>();
                    if (bTransactionStarted)
                    {
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
                    }
                    throw DbModelException.Create(e);
                }
            }
            partial void ListSelected(DbManagerProxy manager, List<PatientListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spPatient_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, PatientListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, PatientListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private PatientListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    PatientListItem obj = PatientListItem.CreateInstance();
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
                obj.Country = new Func<PatientListItem, CountryLookup>(c => 
                                     c.CountryLookup.Where(a => a.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID)
                                     .SingleOrDefault())(obj);
                obj.Region = new Func<PatientListItem, RegionLookup>(c => 
                                     BaseSettings.DefaultRegionInSearch == true?
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
                    throw DbModelException.Create(e);
                }
            }

            
            public PatientListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public PatientListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public PatientListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult ActionEditPerson(DbManagerProxy manager, PatientListItem obj, List<object> pars)
            {
                
                return ActionEditPerson(manager, obj
                    );
            }
            public ActResult ActionEditPerson(DbManagerProxy manager, PatientListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ActionEditPerson"))
                    throw new PermissionException("Patient", "ActionEditPerson");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(PatientListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(PatientListItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.Region = new Func<PatientListItem, RegionLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.Rayon = new Func<PatientListItem, RayonLookup>(c => null)(obj);
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
    
            public void LoadLookup_Country(DbManagerProxy manager, PatientListItem obj)
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
              
                
                LookupManager.AddObject("CountryLookup", obj, CountryAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Region(DbManagerProxy manager, PatientListItem obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<PatientListItem, long>(c => c.idfsCountry ?? 0)(obj)
                            
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
            
            public void LoadLookup_Rayon(DbManagerProxy manager, PatientListItem obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<PatientListItem, long>(c => c.idfsRegion ?? 0)(obj)
                            
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
            
            public void LoadLookup_PersonIDType(DbManagerProxy manager, PatientListItem obj)
            {
                
                obj.PersonIDTypeLookup.Clear();
                
                obj.PersonIDTypeLookup.Add(PersonIDTypeAccessor.CreateNewT(manager, null));
                
                obj.PersonIDTypeLookup.AddRange(PersonIDTypeAccessor.rftPersonIDType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsPersonIDType))
                    
                    .ToList());
                
                if (obj.idfsPersonIDType != null && obj.idfsPersonIDType != 0)
                {
                    obj.PersonIDType = obj.PersonIDTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsPersonIDType);
                    
                }
              
                
                LookupManager.AddObject("rftPersonIDType", obj, PersonIDTypeAccessor.GetType(), "rftPersonIDType_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, PatientListItem obj)
            {
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_PersonIDType(manager, obj);
                
            }
    
            [SprocName("spPatientActual_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spPatientActual_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    PatientListItem bo = obj as PatientListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("Patient", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("Patient", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("Patient", "Update");
                    }
                    
                    long mainObject = bo.idfHumanActual;
                    
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoPatient;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbHuman;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as PatientListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, PatientListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfHumanActual
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
            
            public bool ValidateCanDelete(PatientListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, PatientListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfHumanActual
                            , out result
                            );
                        if (!result) 
                        {
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, false, obj);
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
        
      
            protected ValidationModelException ChainsValidate(PatientListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(PatientListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as PatientListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, PatientListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Patient.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Patient.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Patient.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Patient.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(PatientListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(PatientListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as PatientListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as PatientListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "PatientListItemDetail"; } }
            public string HelpIdWin { get { return "HC_H03"; } }
            public string HelpIdWeb { get { return "HC_H03"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private PatientListItem m_obj;
            internal Permissions(PatientListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Patient.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Patient.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Patient.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Patient.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_Patient_SelectList";
            public static string spCount = "spPatient_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spPatientActual_Delete";
            public static string spCanDelete = "spPatientActual_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<PatientListItem, bool>> RequiredByField = new Dictionary<string, Func<PatientListItem, bool>>();
            public static Dictionary<string, Func<PatientListItem, bool>> RequiredByProperty = new Dictionary<string, Func<PatientListItem, bool>>();
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
                Sizes.Add(_str_strLastName, 200);
                Sizes.Add(_str_AddressName, 2000);
                Sizes.Add(_str_strPersonID, 100);
                Sizes.Add(_str_strPersonIDType, 2000);
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
                    "strLastName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strLastName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datDateofBirth",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datDateofBirth",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRegion",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsRegion",
                    null, "=", c => false, false, SearchPanelLocation.Main, true, "idfsRayon", "RegionLookup", typeof(RegionLookup), (o) => { var c = (RegionLookup)o; return c.idfsRegion; }, (o) => { var c = (RegionLookup)o; return c.strRegionName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRayon",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsRayon",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, "RayonLookup", typeof(RayonLookup), (o) => { var c = (RayonLookup)o; return c.idfsRayon; }, (o) => { var c = (RayonLookup)o; return c.strRayonName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsPersonIDType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsPersonIDType",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "PersonIDTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strPersonID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strPersonID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfHumanActual,
                    _str_idfHumanActual, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strLastName,
                    _str_strLastName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFirstName,
                    _str_strFirstName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSecondName,
                    _str_strSecondName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datDateofBirth,
                    _str_datDateofBirth, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AddressName,
                    _str_AddressName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPersonIDType,
                    "idfsPersonIDType", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPersonID,
                    _str_strPersonID, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datEnteredDate,
                    "Patient.datEnteredDate", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datModificationDate,
                    "Patient.datModificationDate", null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "ActionEditPerson",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ActionEditPerson(manager, (PatientListItem)c, pars),
                        
                    null,
                    
                    null,
                      true,
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<Patient>().CreateNew(manager, c, pars == null ? null : (int?)pars[0])),
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<Patient>().SelectDetail(manager, pars[0])),
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
                                c = ObjectAccessor.CreatorInterface<PatientListItem>().CreateWithParams(manager, null, pars);
                                ((PatientListItem)c).idfHumanActual = (long)pars[0];
                                ((PatientListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((PatientListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<PatientListItem>().Post(manager, (PatientListItem)c), c);
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
	