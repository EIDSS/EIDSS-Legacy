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
    public abstract partial class ContactedCasePerson : 
        EditableObject<ContactedCasePerson>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfContactedCasePerson), NonUpdatable, PrimaryKey]
        public abstract Int64 idfContactedCasePerson { get; set; }
                
        [LocalizedDisplayName(_str_idfHumanCase)]
        [MapField(_str_idfHumanCase)]
        public abstract Int64 idfHumanCase { get; set; }
        protected Int64 idfHumanCase_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfHumanCase).OriginalValue; } }
        protected Int64 idfHumanCase_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfHumanCase).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfHuman)]
        [MapField(_str_idfHuman)]
        public abstract Int64 idfHuman { get; set; }
        protected Int64 idfHuman_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfHuman).OriginalValue; } }
        protected Int64 idfHuman_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfHuman).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsPersonContactType)]
        [MapField(_str_idfsPersonContactType)]
        public abstract Int64 idfsPersonContactType { get; set; }
        protected Int64 idfsPersonContactType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsPersonContactType).OriginalValue; } }
        protected Int64 idfsPersonContactType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsPersonContactType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datDateOfLastContact)]
        [MapField(_str_datDateOfLastContact)]
        public abstract DateTime? datDateOfLastContact { get; set; }
        protected DateTime? datDateOfLastContact_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateOfLastContact).OriginalValue; } }
        protected DateTime? datDateOfLastContact_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateOfLastContact).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPlaceInfo)]
        [MapField(_str_strPlaceInfo)]
        public abstract String strPlaceInfo { get; set; }
        protected String strPlaceInfo_Original { get { return ((EditableValue<String>)((dynamic)this)._strPlaceInfo).OriginalValue; } }
        protected String strPlaceInfo_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPlaceInfo).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strComments)]
        [MapField(_str_strComments)]
        public abstract String strComments { get; set; }
        protected String strComments_Original { get { return ((EditableValue<String>)((dynamic)this)._strComments).OriginalValue; } }
        protected String strComments_Previous { get { return ((EditableValue<String>)((dynamic)this)._strComments).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfRootHuman)]
        [MapField(_str_idfRootHuman)]
        public abstract Int64? idfRootHuman { get; set; }
        protected Int64? idfRootHuman_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootHuman).OriginalValue; } }
        protected Int64? idfRootHuman_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootHuman).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strName)]
        [MapField(_str_strName)]
        public abstract String strName { get; set; }
        protected String strName_Original { get { return ((EditableValue<String>)((dynamic)this)._strName).OriginalValue; } }
        protected String strName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datDateofBirth)]
        [MapField(_str_datDateofBirth)]
        public abstract DateTime? datDateofBirth { get; set; }
        protected DateTime? datDateofBirth_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateofBirth).OriginalValue; } }
        protected DateTime? datDateofBirth_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateofBirth).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPersonContactType)]
        [MapField(_str_strPersonContactType)]
        public abstract String strPersonContactType { get; set; }
        protected String strPersonContactType_Original { get { return ((EditableValue<String>)((dynamic)this)._strPersonContactType).OriginalValue; } }
        protected String strPersonContactType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPersonContactType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPatientInformation)]
        [MapField(_str_strPatientInformation)]
        public abstract String strPatientInformation { get; set; }
        protected String strPatientInformation_Original { get { return ((EditableValue<String>)((dynamic)this)._strPatientInformation).OriginalValue; } }
        protected String strPatientInformation_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPatientInformation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_bitIsRootMain)]
        [MapField(_str_bitIsRootMain)]
        public abstract Byte? bitIsRootMain { get; set; }
        protected Byte? bitIsRootMain_Original { get { return ((EditableValue<Byte?>)((dynamic)this)._bitIsRootMain).OriginalValue; } }
        protected Byte? bitIsRootMain_Previous { get { return ((EditableValue<Byte?>)((dynamic)this)._bitIsRootMain).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_idfsCountry)]
        [MapField(_str_idfsCountry)]
        public abstract Int64? idfsCountry { get; set; }
        protected Int64? idfsCountry_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).OriginalValue; } }
        protected Int64? idfsCountry_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_strHouse)]
        [MapField(_str_strHouse)]
        public abstract String strHouse { get; set; }
        protected String strHouse_Original { get { return ((EditableValue<String>)((dynamic)this)._strHouse).OriginalValue; } }
        protected String strHouse_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHouse).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strBuilding)]
        [MapField(_str_strBuilding)]
        public abstract String strBuilding { get; set; }
        protected String strBuilding_Original { get { return ((EditableValue<String>)((dynamic)this)._strBuilding).OriginalValue; } }
        protected String strBuilding_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBuilding).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strApartment)]
        [MapField(_str_strApartment)]
        public abstract String strApartment { get; set; }
        protected String strApartment_Original { get { return ((EditableValue<String>)((dynamic)this)._strApartment).OriginalValue; } }
        protected String strApartment_Previous { get { return ((EditableValue<String>)((dynamic)this)._strApartment).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsHumanGender)]
        [MapField(_str_idfsHumanGender)]
        public abstract Int64? idfsHumanGender { get; set; }
        protected Int64? idfsHumanGender_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanGender).OriginalValue; } }
        protected Int64? idfsHumanGender_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanGender).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPatientAddressString)]
        [MapField(_str_strPatientAddressString)]
        public abstract String strPatientAddressString { get; set; }
        protected String strPatientAddressString_Original { get { return ((EditableValue<String>)((dynamic)this)._strPatientAddressString).OriginalValue; } }
        protected String strPatientAddressString_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPatientAddressString).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<ContactedCasePerson, object> _get_func;
            internal Action<ContactedCasePerson, string> _set_func;
            internal Action<ContactedCasePerson, ContactedCasePerson, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfContactedCasePerson = "idfContactedCasePerson";
        internal const string _str_idfHumanCase = "idfHumanCase";
        internal const string _str_idfHuman = "idfHuman";
        internal const string _str_idfsPersonContactType = "idfsPersonContactType";
        internal const string _str_datDateOfLastContact = "datDateOfLastContact";
        internal const string _str_strPlaceInfo = "strPlaceInfo";
        internal const string _str_strComments = "strComments";
        internal const string _str_idfRootHuman = "idfRootHuman";
        internal const string _str_strName = "strName";
        internal const string _str_datDateofBirth = "datDateofBirth";
        internal const string _str_strPersonContactType = "strPersonContactType";
        internal const string _str_strPatientInformation = "strPatientInformation";
        internal const string _str_bitIsRootMain = "bitIsRootMain";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_strPostCode = "strPostCode";
        internal const string _str_strStreetName = "strStreetName";
        internal const string _str_strHouse = "strHouse";
        internal const string _str_strBuilding = "strBuilding";
        internal const string _str_strApartment = "strApartment";
        internal const string _str_idfsHumanGender = "idfsHumanGender";
        internal const string _str_strPatientAddressString = "strPatientAddressString";
        internal const string _str_NewObject = "NewObject";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_strFullName = "strFullName";
        internal const string _str_strCurrentResidenceAddress = "strCurrentResidenceAddress";
        internal const string _str_GeoLocationNameWithHiddenPersonalData = "GeoLocationNameWithHiddenPersonalData";
        internal const string _str_PersonContactType = "PersonContactType";
        internal const string _str_Person = "Person";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfContactedCasePerson, _formname = _str_idfContactedCasePerson, _type = "Int64",
              _get_func = o => o.idfContactedCasePerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfContactedCasePerson != newval) o.idfContactedCasePerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfContactedCasePerson != c.idfContactedCasePerson || o.IsRIRPropChanged(_str_idfContactedCasePerson, c)) 
                  m.Add(_str_idfContactedCasePerson, o.ObjectIdent + _str_idfContactedCasePerson, o.ObjectIdent2 + _str_idfContactedCasePerson, o.ObjectIdent3 + _str_idfContactedCasePerson, "Int64", 
                    o.idfContactedCasePerson == null ? "" : o.idfContactedCasePerson.ToString(),                  
                  o.IsReadOnly(_str_idfContactedCasePerson), o.IsInvisible(_str_idfContactedCasePerson), o.IsRequired(_str_idfContactedCasePerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfHumanCase, _formname = _str_idfHumanCase, _type = "Int64",
              _get_func = o => o.idfHumanCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfHumanCase != newval) o.idfHumanCase = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfHumanCase != c.idfHumanCase || o.IsRIRPropChanged(_str_idfHumanCase, c)) 
                  m.Add(_str_idfHumanCase, o.ObjectIdent + _str_idfHumanCase, o.ObjectIdent2 + _str_idfHumanCase, o.ObjectIdent3 + _str_idfHumanCase, "Int64", 
                    o.idfHumanCase == null ? "" : o.idfHumanCase.ToString(),                  
                  o.IsReadOnly(_str_idfHumanCase), o.IsInvisible(_str_idfHumanCase), o.IsRequired(_str_idfHumanCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfHuman, _formname = _str_idfHuman, _type = "Int64",
              _get_func = o => o.idfHuman,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfHuman != newval) o.idfHuman = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfHuman != c.idfHuman || o.IsRIRPropChanged(_str_idfHuman, c)) 
                  m.Add(_str_idfHuman, o.ObjectIdent + _str_idfHuman, o.ObjectIdent2 + _str_idfHuman, o.ObjectIdent3 + _str_idfHuman, "Int64", 
                    o.idfHuman == null ? "" : o.idfHuman.ToString(),                  
                  o.IsReadOnly(_str_idfHuman), o.IsInvisible(_str_idfHuman), o.IsRequired(_str_idfHuman)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsPersonContactType, _formname = _str_idfsPersonContactType, _type = "Int64",
              _get_func = o => o.idfsPersonContactType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsPersonContactType != newval) 
                  o.PersonContactType = o.PersonContactTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsPersonContactType != newval) o.idfsPersonContactType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsPersonContactType != c.idfsPersonContactType || o.IsRIRPropChanged(_str_idfsPersonContactType, c)) 
                  m.Add(_str_idfsPersonContactType, o.ObjectIdent + _str_idfsPersonContactType, o.ObjectIdent2 + _str_idfsPersonContactType, o.ObjectIdent3 + _str_idfsPersonContactType, "Int64", 
                    o.idfsPersonContactType == null ? "" : o.idfsPersonContactType.ToString(),                  
                  o.IsReadOnly(_str_idfsPersonContactType), o.IsInvisible(_str_idfsPersonContactType), o.IsRequired(_str_idfsPersonContactType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDateOfLastContact, _formname = _str_datDateOfLastContact, _type = "DateTime?",
              _get_func = o => o.datDateOfLastContact,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDateOfLastContact != newval) o.datDateOfLastContact = newval; },
              _compare_func = (o, c, m) => {
                if (o.datDateOfLastContact != c.datDateOfLastContact || o.IsRIRPropChanged(_str_datDateOfLastContact, c)) 
                  m.Add(_str_datDateOfLastContact, o.ObjectIdent + _str_datDateOfLastContact, o.ObjectIdent2 + _str_datDateOfLastContact, o.ObjectIdent3 + _str_datDateOfLastContact, "DateTime?", 
                    o.datDateOfLastContact == null ? "" : o.datDateOfLastContact.ToString(),                  
                  o.IsReadOnly(_str_datDateOfLastContact), o.IsInvisible(_str_datDateOfLastContact), o.IsRequired(_str_datDateOfLastContact)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPlaceInfo, _formname = _str_strPlaceInfo, _type = "String",
              _get_func = o => o.strPlaceInfo,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPlaceInfo != newval) o.strPlaceInfo = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPlaceInfo != c.strPlaceInfo || o.IsRIRPropChanged(_str_strPlaceInfo, c)) 
                  m.Add(_str_strPlaceInfo, o.ObjectIdent + _str_strPlaceInfo, o.ObjectIdent2 + _str_strPlaceInfo, o.ObjectIdent3 + _str_strPlaceInfo, "String", 
                    o.strPlaceInfo == null ? "" : o.strPlaceInfo.ToString(),                  
                  o.IsReadOnly(_str_strPlaceInfo), o.IsInvisible(_str_strPlaceInfo), o.IsRequired(_str_strPlaceInfo)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strComments, _formname = _str_strComments, _type = "String",
              _get_func = o => o.strComments,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strComments != newval) o.strComments = newval; },
              _compare_func = (o, c, m) => {
                if (o.strComments != c.strComments || o.IsRIRPropChanged(_str_strComments, c)) 
                  m.Add(_str_strComments, o.ObjectIdent + _str_strComments, o.ObjectIdent2 + _str_strComments, o.ObjectIdent3 + _str_strComments, "String", 
                    o.strComments == null ? "" : o.strComments.ToString(),                  
                  o.IsReadOnly(_str_strComments), o.IsInvisible(_str_strComments), o.IsRequired(_str_strComments)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfRootHuman, _formname = _str_idfRootHuman, _type = "Int64?",
              _get_func = o => o.idfRootHuman,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfRootHuman != newval) o.idfRootHuman = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfRootHuman != c.idfRootHuman || o.IsRIRPropChanged(_str_idfRootHuman, c)) 
                  m.Add(_str_idfRootHuman, o.ObjectIdent + _str_idfRootHuman, o.ObjectIdent2 + _str_idfRootHuman, o.ObjectIdent3 + _str_idfRootHuman, "Int64?", 
                    o.idfRootHuman == null ? "" : o.idfRootHuman.ToString(),                  
                  o.IsReadOnly(_str_idfRootHuman), o.IsInvisible(_str_idfRootHuman), o.IsRequired(_str_idfRootHuman)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strName, _formname = _str_strName, _type = "String",
              _get_func = o => o.strName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strName != newval) o.strName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strName != c.strName || o.IsRIRPropChanged(_str_strName, c)) 
                  m.Add(_str_strName, o.ObjectIdent + _str_strName, o.ObjectIdent2 + _str_strName, o.ObjectIdent3 + _str_strName, "String", 
                    o.strName == null ? "" : o.strName.ToString(),                  
                  o.IsReadOnly(_str_strName), o.IsInvisible(_str_strName), o.IsRequired(_str_strName)); 
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
              _name = _str_strPersonContactType, _formname = _str_strPersonContactType, _type = "String",
              _get_func = o => o.strPersonContactType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPersonContactType != newval) o.strPersonContactType = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPersonContactType != c.strPersonContactType || o.IsRIRPropChanged(_str_strPersonContactType, c)) 
                  m.Add(_str_strPersonContactType, o.ObjectIdent + _str_strPersonContactType, o.ObjectIdent2 + _str_strPersonContactType, o.ObjectIdent3 + _str_strPersonContactType, "String", 
                    o.strPersonContactType == null ? "" : o.strPersonContactType.ToString(),                  
                  o.IsReadOnly(_str_strPersonContactType), o.IsInvisible(_str_strPersonContactType), o.IsRequired(_str_strPersonContactType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPatientInformation, _formname = _str_strPatientInformation, _type = "String",
              _get_func = o => o.strPatientInformation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPatientInformation != newval) o.strPatientInformation = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPatientInformation != c.strPatientInformation || o.IsRIRPropChanged(_str_strPatientInformation, c)) 
                  m.Add(_str_strPatientInformation, o.ObjectIdent + _str_strPatientInformation, o.ObjectIdent2 + _str_strPatientInformation, o.ObjectIdent3 + _str_strPatientInformation, "String", 
                    o.strPatientInformation == null ? "" : o.strPatientInformation.ToString(),                  
                  o.IsReadOnly(_str_strPatientInformation), o.IsInvisible(_str_strPatientInformation), o.IsRequired(_str_strPatientInformation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_bitIsRootMain, _formname = _str_bitIsRootMain, _type = "Byte?",
              _get_func = o => o.bitIsRootMain,
              _set_func = (o, val) => { var newval = o.bitIsRootMain; if (o.bitIsRootMain != newval) o.bitIsRootMain = newval; },
              _compare_func = (o, c, m) => {
                if (o.bitIsRootMain != c.bitIsRootMain || o.IsRIRPropChanged(_str_bitIsRootMain, c)) 
                  m.Add(_str_bitIsRootMain, o.ObjectIdent + _str_bitIsRootMain, o.ObjectIdent2 + _str_bitIsRootMain, o.ObjectIdent3 + _str_bitIsRootMain, "Byte?", 
                    o.bitIsRootMain == null ? "" : o.bitIsRootMain.ToString(),                  
                  o.IsReadOnly(_str_bitIsRootMain), o.IsInvisible(_str_bitIsRootMain), o.IsRequired(_str_bitIsRootMain)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsRegion, _formname = _str_idfsRegion, _type = "Int64?",
              _get_func = o => o.idfsRegion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsRegion != newval) o.idfsRegion = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsRayon != newval) o.idfsRayon = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSettlement != newval) o.idfsSettlement = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_idfsSettlement, c)) 
                  m.Add(_str_idfsSettlement, o.ObjectIdent + _str_idfsSettlement, o.ObjectIdent2 + _str_idfsSettlement, o.ObjectIdent3 + _str_idfsSettlement, "Int64?", 
                    o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(),                  
                  o.IsReadOnly(_str_idfsSettlement), o.IsInvisible(_str_idfsSettlement), o.IsRequired(_str_idfsSettlement)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCountry, _formname = _str_idfsCountry, _type = "Int64?",
              _get_func = o => o.idfsCountry,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsCountry != newval) o.idfsCountry = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_idfsCountry, c)) 
                  m.Add(_str_idfsCountry, o.ObjectIdent + _str_idfsCountry, o.ObjectIdent2 + _str_idfsCountry, o.ObjectIdent3 + _str_idfsCountry, "Int64?", 
                    o.idfsCountry == null ? "" : o.idfsCountry.ToString(),                  
                  o.IsReadOnly(_str_idfsCountry), o.IsInvisible(_str_idfsCountry), o.IsRequired(_str_idfsCountry)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPostCode, _formname = _str_strPostCode, _type = "String",
              _get_func = o => o.strPostCode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPostCode != newval) o.strPostCode = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strStreetName != newval) o.strStreetName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strStreetName != c.strStreetName || o.IsRIRPropChanged(_str_strStreetName, c)) 
                  m.Add(_str_strStreetName, o.ObjectIdent + _str_strStreetName, o.ObjectIdent2 + _str_strStreetName, o.ObjectIdent3 + _str_strStreetName, "String", 
                    o.strStreetName == null ? "" : o.strStreetName.ToString(),                  
                  o.IsReadOnly(_str_strStreetName), o.IsInvisible(_str_strStreetName), o.IsRequired(_str_strStreetName)); 
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
              _name = _str_idfsHumanGender, _formname = _str_idfsHumanGender, _type = "Int64?",
              _get_func = o => o.idfsHumanGender,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsHumanGender != newval) o.idfsHumanGender = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsHumanGender != c.idfsHumanGender || o.IsRIRPropChanged(_str_idfsHumanGender, c)) 
                  m.Add(_str_idfsHumanGender, o.ObjectIdent + _str_idfsHumanGender, o.ObjectIdent2 + _str_idfsHumanGender, o.ObjectIdent3 + _str_idfsHumanGender, "Int64?", 
                    o.idfsHumanGender == null ? "" : o.idfsHumanGender.ToString(),                  
                  o.IsReadOnly(_str_idfsHumanGender), o.IsInvisible(_str_idfsHumanGender), o.IsRequired(_str_idfsHumanGender)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPatientAddressString, _formname = _str_strPatientAddressString, _type = "String",
              _get_func = o => o.strPatientAddressString,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPatientAddressString != newval) o.strPatientAddressString = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPatientAddressString != c.strPatientAddressString || o.IsRIRPropChanged(_str_strPatientAddressString, c)) 
                  m.Add(_str_strPatientAddressString, o.ObjectIdent + _str_strPatientAddressString, o.ObjectIdent2 + _str_strPatientAddressString, o.ObjectIdent3 + _str_strPatientAddressString, "String", 
                    o.strPatientAddressString == null ? "" : o.strPatientAddressString.ToString(),                  
                  o.IsReadOnly(_str_strPatientAddressString), o.IsInvisible(_str_strPatientAddressString), o.IsRequired(_str_strPatientAddressString)); 
                  }
              }, 
        
            new field_info {
              _name = _str_NewObject, _formname = _str_NewObject, _type = "bool",
              _get_func = o => o.NewObject,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.NewObject != newval) o.NewObject = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.NewObject != c.NewObject || o.IsRIRPropChanged(_str_NewObject, c)) {
                  m.Add(_str_NewObject, o.ObjectIdent + _str_NewObject, o.ObjectIdent2 + _str_NewObject, o.ObjectIdent3 + _str_NewObject,  "bool", 
                    o.NewObject == null ? "" : o.NewObject.ToString(),                  
                    o.IsReadOnly(_str_NewObject), o.IsInvisible(_str_NewObject), o.IsRequired(_str_NewObject));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_GeoLocationNameWithHiddenPersonalData, _formname = _str_GeoLocationNameWithHiddenPersonalData, _type = "string",
              _get_func = o => o.GeoLocationNameWithHiddenPersonalData,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.GeoLocationNameWithHiddenPersonalData != newval) o.GeoLocationNameWithHiddenPersonalData = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.GeoLocationNameWithHiddenPersonalData != c.GeoLocationNameWithHiddenPersonalData || o.IsRIRPropChanged(_str_GeoLocationNameWithHiddenPersonalData, c)) {
                  m.Add(_str_GeoLocationNameWithHiddenPersonalData, o.ObjectIdent + _str_GeoLocationNameWithHiddenPersonalData, o.ObjectIdent2 + _str_GeoLocationNameWithHiddenPersonalData, o.ObjectIdent3 + _str_GeoLocationNameWithHiddenPersonalData,  "string", 
                    o.GeoLocationNameWithHiddenPersonalData == null ? "" : o.GeoLocationNameWithHiddenPersonalData.ToString(),                  
                    o.IsReadOnly(_str_GeoLocationNameWithHiddenPersonalData), o.IsInvisible(_str_GeoLocationNameWithHiddenPersonalData), o.IsRequired(_str_GeoLocationNameWithHiddenPersonalData));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_CaseObjectIdent, _formname = _str_CaseObjectIdent, _type = "string",
              _get_func = o => o.CaseObjectIdent,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.CaseObjectIdent != c.CaseObjectIdent || o.IsRIRPropChanged(_str_CaseObjectIdent, c)) {
                  m.Add(_str_CaseObjectIdent, o.ObjectIdent + _str_CaseObjectIdent, o.ObjectIdent2 + _str_CaseObjectIdent, o.ObjectIdent3 + _str_CaseObjectIdent, "string", o.CaseObjectIdent == null ? "" : o.CaseObjectIdent.ToString(), o.IsReadOnly(_str_CaseObjectIdent), o.IsInvisible(_str_CaseObjectIdent), o.IsRequired(_str_CaseObjectIdent));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strFullName, _formname = _str_strFullName, _type = "string",
              _get_func = o => o.strFullName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strFullName != c.strFullName || o.IsRIRPropChanged(_str_strFullName, c)) {
                  m.Add(_str_strFullName, o.ObjectIdent + _str_strFullName, o.ObjectIdent2 + _str_strFullName, o.ObjectIdent3 + _str_strFullName, "string", o.strFullName == null ? "" : o.strFullName.ToString(), o.IsReadOnly(_str_strFullName), o.IsInvisible(_str_strFullName), o.IsRequired(_str_strFullName));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strCurrentResidenceAddress, _formname = _str_strCurrentResidenceAddress, _type = "string",
              _get_func = o => o.strCurrentResidenceAddress,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strCurrentResidenceAddress != c.strCurrentResidenceAddress || o.IsRIRPropChanged(_str_strCurrentResidenceAddress, c)) {
                  m.Add(_str_strCurrentResidenceAddress, o.ObjectIdent + _str_strCurrentResidenceAddress, o.ObjectIdent2 + _str_strCurrentResidenceAddress, o.ObjectIdent3 + _str_strCurrentResidenceAddress, "string", o.strCurrentResidenceAddress == null ? "" : o.strCurrentResidenceAddress.ToString(), o.IsReadOnly(_str_strCurrentResidenceAddress), o.IsInvisible(_str_strCurrentResidenceAddress), o.IsRequired(_str_strCurrentResidenceAddress));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_PersonContactType, _formname = _str_PersonContactType, _type = "Lookup",
              _get_func = o => { if (o.PersonContactType == null) return null; return o.PersonContactType.idfsBaseReference; },
              _set_func = (o, val) => { o.PersonContactType = o.PersonContactTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsPersonContactType != c.idfsPersonContactType || o.IsRIRPropChanged(_str_PersonContactType, c)) {
                  m.Add(_str_PersonContactType, o.ObjectIdent + _str_PersonContactType, o.ObjectIdent2 + _str_PersonContactType, o.ObjectIdent3 + _str_PersonContactType, "Lookup", o.idfsPersonContactType == null ? "" : o.idfsPersonContactType.ToString(), o.IsReadOnly(_str_PersonContactType), o.IsInvisible(_str_PersonContactType), o.IsRequired(_str_PersonContactType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_PersonContactType + "Lookup", _formname = _str_PersonContactType + "Lookup", _type = "LookupContent",
              _get_func = o => o.PersonContactTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Person, _formname = _str_Person, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Person != null) o.Person._compare(c.Person, m); }
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
            ContactedCasePerson obj = (ContactedCasePerson)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Person)]
        [Relation(typeof(Patient), eidss.model.Schema.Patient._str_idfHuman, _str_idfHuman)]
        public Patient Person
        {
            get 
            {   
                if (!_PersonLoaded)
                {
                    _PersonLoaded = true;
                    _getAccessor()._LoadPerson(this);
                    if (_Person != null) 
                        _Person.Parent = this;
                }
                return _Person; 
            }
            set 
            {   
                if (!_PersonLoaded) { _PersonLoaded = true; }
                _Person = value;
                if (_Person != null) 
                { 
                    _Person.m_ObjectName = _str_Person;
                    _Person.Parent = this;
                }
                idfHuman = _Person == null 
                        ? new Int64()
                        : _Person.idfHuman;
                
            }
        }
        protected Patient _Person;
                    
        private bool _PersonLoaded = false;
                    
        [LocalizedDisplayName(_str_PersonContactType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsPersonContactType)]
        public BaseReference PersonContactType
        {
            get { return _PersonContactType; }
            set 
            { 
                var oldVal = _PersonContactType;
                _PersonContactType = value;
                if (_PersonContactType != oldVal)
                {
                    if (idfsPersonContactType != (_PersonContactType == null
                            ? new Int64()
                            : (Int64)_PersonContactType.idfsBaseReference))
                        idfsPersonContactType = _PersonContactType == null 
                            ? new Int64()
                            : (Int64)_PersonContactType.idfsBaseReference; 
                    OnPropertyChanged(_str_PersonContactType); 
                }
            }
        }
        private BaseReference _PersonContactType;

        
        public BaseReferenceList PersonContactTypeLookup
        {
            get { return _PersonContactTypeLookup; }
        }
        private BaseReferenceList _PersonContactTypeLookup = new BaseReferenceList("rftContact_Type");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_PersonContactType:
                    return new BvSelectList(PersonContactTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, PersonContactType, _str_idfsPersonContactType);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<ContactedCasePerson, string>(c => "HumanCase_" + c.idfHumanCase + "_")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("strName")]
        public string strFullName
        {
            get { return new Func<ContactedCasePerson, string>(c => c.Person.strLastName + " " + c.Person.strFirstName + " " + c.Person.strSecondName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("strRegistrationAddress")]
        public string strCurrentResidenceAddress
        {
            get { return new Func<ContactedCasePerson, string>(c => c._Person == null ? c.strPatientInformation : bv.common.Core.Utils.Join(", ", new List<string>(){ c._Person.CurrentResidenceAddress != null ? c._Person.CurrentResidenceAddress.strReadOnlyAdaptiveFullName : "", c._Person.strHomePhone }))(this); }
            
        }
        
          [LocalizedDisplayName(_str_NewObject)]
        public bool NewObject
        {
            get { return m_NewObject; }
            set { if (m_NewObject != value) { m_NewObject = value; OnPropertyChanged(_str_NewObject); } }
        }
        private bool m_NewObject;
        
          [LocalizedDisplayName("strRegistrationAddress")]
        public string GeoLocationNameWithHiddenPersonalData
        {
            get { return m_GeoLocationNameWithHiddenPersonalData; }
            set { if (m_GeoLocationNameWithHiddenPersonalData != value) { m_GeoLocationNameWithHiddenPersonalData = value; OnPropertyChanged(_str_GeoLocationNameWithHiddenPersonalData); } }
        }
        private string m_GeoLocationNameWithHiddenPersonalData;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "ContactedCasePerson";

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
        
            if (_Person != null) { _Person.Parent = this; }
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as ContactedCasePerson;
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
            var ret = base.Clone() as ContactedCasePerson;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Person != null)
              ret.Person = _Person.CloneWithSetup(manager, bRestricted) as Patient;
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public ContactedCasePerson CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as ContactedCasePerson;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfContactedCasePerson; } }
        public string KeyName { get { return "idfContactedCasePerson"; } }
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
        
                    || (_Person != null && _Person.HasChanges)
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsPersonContactType_PersonContactType = idfsPersonContactType;
            base.RejectChanges();
        
            if (_prev_idfsPersonContactType_PersonContactType != idfsPersonContactType)
            {
                _PersonContactType = _PersonContactTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsPersonContactType);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (Person != null) Person.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Person != null) _Person.DeepAcceptChanges();
                
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
        
            if (_Person != null) _Person.SetChange();
                
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

        private bool IsRIRPropChanged(string fld, ContactedCasePerson c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public ContactedCasePerson()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ContactedCasePerson_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(ContactedCasePerson_PropertyChanged);
        }
        private void ContactedCasePerson_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as ContactedCasePerson).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfHumanCase)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
            if (e.PropertyName == _str_Person)
                OnPropertyChanged(_str_strFullName);
                  
            if (e.PropertyName == _str_Person)
                OnPropertyChanged(_str_strCurrentResidenceAddress);
                  
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
            ContactedCasePerson obj = this;
            
        }
        private void _DeletedExtenders()
        {
            ContactedCasePerson obj = this;
            
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

    
        private static string[] readonly_names1 = "strName,strCurrentResidenceAddress".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<ContactedCasePerson, bool>(c => true)(this);
            
            return ReadOnly;
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                if (_Person != null)
                    _Person.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<ContactedCasePerson, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<ContactedCasePerson, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<ContactedCasePerson, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<ContactedCasePerson, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<ContactedCasePerson, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<ContactedCasePerson, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<ContactedCasePerson, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~ContactedCasePerson()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                if (_Person != null)
                    Person.Dispose();
                
                LookupManager.RemoveObject("rftContact_Type", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftContact_Type")
                _getAccessor().LoadLookup_PersonContactType(manager, this);
            
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
        
            if (_Person != null) _Person.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
            ParsedFormCollection(form);
        }
    
        #region Class for web grid
        public class ContactedCasePersonGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfContactedCasePerson { get; set; }
        
            public Int64 idfHuman { get; set; }
        
            public string strFullName { get; set; }
        
            public Int64 idfsPersonContactType { get; set; }
        
            public string strPersonContactType { get; set; }
        
            public DateTime? datDateOfLastContact { get; set; }
        
            public string strPlaceInfo { get; set; }
        
            public string strCurrentResidenceAddress { get; set; }
        
            public Int64? idfsSettlement { get; set; }
        
            public Int64? idfsRegion { get; set; }
        
            public Int64? idfsRayon { get; set; }
        
            public string GeoLocationNameWithHiddenPersonalData { get; set; }
        
            public string strComments { get; set; }
        
        }
        public partial class ContactedCasePersonGridModelList : List<ContactedCasePersonGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public ContactedCasePersonGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<ContactedCasePerson>, errMes);
            }
            public ContactedCasePersonGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<ContactedCasePerson>, errMes);
            }
            public ContactedCasePersonGridModelList(long key, IEnumerable<ContactedCasePerson> items)
            {
                LoadGridModelList(key, items, null);
            }
            public ContactedCasePersonGridModelList(long key)
            {
                LoadGridModelList(key, new List<ContactedCasePerson>(), null);
            }
            partial void filter(List<ContactedCasePerson> items);
            private void LoadGridModelList(long key, IEnumerable<ContactedCasePerson> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strFullName,_str_strPersonContactType,_str_datDateOfLastContact,_str_strPlaceInfo,_str_strCurrentResidenceAddress,_str_GeoLocationNameWithHiddenPersonalData,_str_strComments};
                    
                Hiddens = new List<string> {_str_idfContactedCasePerson,_str_idfHuman,_str_idfsPersonContactType,_str_idfsSettlement,_str_idfsRegion,_str_idfsRayon};
                Keys = new List<string> {_str_idfContactedCasePerson};
                Labels = new Dictionary<string, string> {{_str_strFullName, "strName"},{_str_strPersonContactType, _str_strPersonContactType},{_str_datDateOfLastContact, _str_datDateOfLastContact},{_str_strPlaceInfo, _str_strPlaceInfo},{_str_strCurrentResidenceAddress, "strRegistrationAddress"},{_str_GeoLocationNameWithHiddenPersonalData, "strRegistrationAddress"},{_str_strComments, _str_strComments}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                ContactedCasePerson.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<ContactedCasePerson>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new ContactedCasePersonGridModel()
                {
                    ItemKey=c.idfContactedCasePerson,idfHuman=c.idfHuman,strFullName=c.strFullName,idfsPersonContactType=c.idfsPersonContactType,strPersonContactType=c.strPersonContactType,datDateOfLastContact=c.datDateOfLastContact,strPlaceInfo=c.strPlaceInfo,strCurrentResidenceAddress=c.strCurrentResidenceAddress,idfsSettlement=c.idfsSettlement,idfsRegion=c.idfsRegion,idfsRayon=c.idfsRayon,GeoLocationNameWithHiddenPersonalData=c.GeoLocationNameWithHiddenPersonalData,strComments=c.strComments
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
        : DataAccessor<ContactedCasePerson>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<ContactedCasePerson>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfContactedCasePerson"; } }
            #endregion
        
            private delegate void on_action(ContactedCasePerson obj);
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
            private Patient.Accessor PersonAccessor { get { return eidss.model.Schema.Patient.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor PersonContactTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<ContactedCasePerson> SelectList(DbManagerProxy manager
                , Int64? idfCase
                )
            {
                return _SelectList(manager
                    , idfCase
                    , delegate(ContactedCasePerson obj)
                        {
                        }
                    , delegate(ContactedCasePerson obj)
                        {
                        }
                    );
            }

            
            private List<ContactedCasePerson> _SelectList(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<ContactedCasePerson> objs = new List<ContactedCasePerson>();
                    sets[0] = new MapResultSet(typeof(ContactedCasePerson), objs);
                    
                    manager
                        .SetSpCommand("spContactedCasePerson_SelectDetail"
                            , manager.Parameter("@idfCase", idfCase)
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
    
            internal void _LoadPerson(ContactedCasePerson obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadPerson(manager, obj);
                }
            }
            internal void _LoadPerson(DbManagerProxy manager, ContactedCasePerson obj)
            {
                
                if (obj.Person == null && obj.idfHuman != 0)
                {
                    obj.Person = PersonAccessor.SelectByKey(manager
                        
                        , obj.idfHuman
                        );
                    if (obj.Person != null)
                    {
                        obj.Person.m_ObjectName = _str_Person;
                    }
                }
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, ContactedCasePerson obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, ContactedCasePerson obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    PersonAccessor._SetPermitions(obj._permissions, obj.Person);
                    
                    }
                }
            }

    

            private ContactedCasePerson _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    ContactedCasePerson obj = ContactedCasePerson.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfContactedCasePerson = (new GetNewIDExtender<ContactedCasePerson>()).GetScalar(manager, obj, isFake);
                obj.Person = new Func<ContactedCasePerson, Patient>(c => PersonAccessor.Create(manager, c, c.idfHuman))(obj);
                obj.Person.idfRootHuman = (new GetNewIDExtender<ContactedCasePerson>()).GetScalar(manager, obj, isFake);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.PersonContactType = new Func<ContactedCasePerson, BaseReference>(c => c.PersonContactTypeLookup.Where(a => a.idfsBaseReference == (long)PersonContactTypeEnum.Family).SingleOrDefault())(obj);
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

            
            public ContactedCasePerson CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public ContactedCasePerson CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public ContactedCasePerson CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ContactedCasePerson CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfHumanCase", typeof(long));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public ContactedCasePerson Create(DbManagerProxy manager, IObject Parent
                , long idfHumanCase
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfHumanCase = new Func<ContactedCasePerson, long>(c => idfHumanCase)(obj);
                obj.Person = new Func<ContactedCasePerson, Patient>(c => PersonAccessor.Create(manager, c, idfHumanCase))(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(ContactedCasePerson obj, object newobj)
            {
                
                    if (newobj == null || newobj == obj.Person)
                    {
                        var o = obj.Person;
                            
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "datDateofBirth")
                                {
                                
                (new PredicateValidator("Date of Birth_Date of last contact", "datDateofBirth", "Person", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datDateOfLastContact)
                    );
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datDateofBirth");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        
                    }
                            
            }
            
            private void _SetupHandlers(ContactedCasePerson obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsPersonContactType)
                        {
                    
                obj.strPersonContactType = new Func<ContactedCasePerson, string>(c => c.PersonContactType == null ? "" : c.PersonContactType.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfHuman)
                        {
                    
                obj.strName = new Func<ContactedCasePerson, string>(c => c.Person == null ? "" : c.Person.strName)(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_PersonContactType(DbManagerProxy manager, ContactedCasePerson obj)
            {
                
                obj.PersonContactTypeLookup.Clear();
                
                obj.PersonContactTypeLookup.AddRange(PersonContactTypeAccessor.rftContact_Type_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsPersonContactType))
                    
                    .ToList());
                
                if (obj.idfsPersonContactType != 0)
                {
                    obj.PersonContactType = obj.PersonContactTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsPersonContactType);
                    
                }
              
                
                LookupManager.AddObject("rftContact_Type", obj, PersonContactTypeAccessor.GetType(), "rftContact_Type_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, ContactedCasePerson obj)
            {
                
                LoadLookup_PersonContactType(manager, obj);
                
            }
    
            [SprocName("spContactedCasePerson_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            [SprocName("spContactedCasePerson_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] ContactedCasePerson obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] ContactedCasePerson obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    ContactedCasePerson bo = obj as ContactedCasePerson;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as ContactedCasePerson, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, ContactedCasePerson obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                                
                    _postDeletePredicate(manager
                        , obj.idfContactedCasePerson
                        );
                                        
                    if (obj.Person != null)
                    {
                        obj.Person.MarkToDelete();
                        if (!PersonAccessor.Post(manager, obj.Person, true))
                            return false;
                    }
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (obj.IsNew)
                    {
                        if (obj.Person != null) // forced load potential lazy subobject for new object
                            if (!PersonAccessor.Post(manager, obj.Person, true))
                                return false;
                    }
                    else
                    {
                        if (obj._Person != null) // do not load lazy subobject for existing object
                            if (!PersonAccessor.Post(manager, obj.Person, true))
                                return false;
                    }
                                    
                    if (!obj.IsMarkedToDelete && bHasChanges)
                        _postPredicate(manager, obj);
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(ContactedCasePerson obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, ContactedCasePerson obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(ContactedCasePerson obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(ContactedCasePerson obj, bool bRethrowException)
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
                return Validate(manager, obj as ContactedCasePerson, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, ContactedCasePerson obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "Person.strLastName", "Person.strLastName","",
                false
              )).Validate(c => true, obj, obj.Person.strLastName);
            
                (new RequiredValidator( "idfsPersonContactType", "PersonContactType","",
                false
              )).Validate(c => true, obj, obj.idfsPersonContactType);
            
                (new PredicateValidator("mbContactExist", "", "", "",
              new object[] {
              new Func<ContactedCasePerson, string>(c => c.strFullName)(obj)
                        },
                        false
                    )).Validate(obj, c => c.Parent is HumanCase ? (c.Parent as HumanCase).ContactedPerson.Count(j => 
                        !j.IsMarkedToDelete 
                        && j.idfContactedCasePerson != c.idfContactedCasePerson
                        && j.Person.strFirstName == c.Person.strFirstName
                        && j.Person.strLastName == c.Person.strLastName
                        && j.Person.strSecondName == c.Person.strSecondName
                        && j.Person.datDateofBirth == c.Person.datDateofBirth
                        && j.Person.idfsHumanGender == c.Person.idfsHumanGender
                        && j.Person.CurrentResidenceAddress.idfsCountry == c.Person.CurrentResidenceAddress.idfsCountry
                        && j.Person.CurrentResidenceAddress.idfsRegion == c.Person.CurrentResidenceAddress.idfsRegion
                        && j.Person.CurrentResidenceAddress.idfsRayon == c.Person.CurrentResidenceAddress.idfsRayon
                        && j.Person.CurrentResidenceAddress.idfsSettlement == c.Person.CurrentResidenceAddress.idfsSettlement
                        && j.Person.CurrentResidenceAddress.strStreetName == c.Person.CurrentResidenceAddress.strStreetName
                        && j.Person.CurrentResidenceAddress.strPostCode == c.Person.CurrentResidenceAddress.strPostCode
                        && j.Person.CurrentResidenceAddress.strBuilding == c.Person.CurrentResidenceAddress.strBuilding
                        && j.Person.CurrentResidenceAddress.strApartment == c.Person.CurrentResidenceAddress.strApartment
                        && j.Person.CurrentResidenceAddress.strHouse == c.Person.CurrentResidenceAddress.strHouse
                        ) == 0 : true
                    );
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                        {
                            var item = obj.Person;
                        
                (new PredicateValidator("Date of Birth_Date of last contact", "datDateofBirth", "Person", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datDateOfLastContact)
                    );
            
                        }
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Person != null)
                            PersonAccessor.Validate(manager, obj.Person, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
           
    
            private void _SetupRequired(ContactedCasePerson obj)
            {
            
                obj
                    .Person
                        .AddRequired("strLastName", c => true);
                        
                obj
                    .AddRequired("PersonContactType", c => true);
                    
                  obj
                    .AddRequired("PersonContactType", c => true);
                
            }
    
    private void _SetupPersonalDataRestrictions(ContactedCasePerson obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as ContactedCasePerson) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as ContactedCasePerson) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "ContactedCasePersonDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spContactedCasePerson_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spContactedCasePerson_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spContactedCasePerson_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<ContactedCasePerson, bool>> RequiredByField = new Dictionary<string, Func<ContactedCasePerson, bool>>();
            public static Dictionary<string, Func<ContactedCasePerson, bool>> RequiredByProperty = new Dictionary<string, Func<ContactedCasePerson, bool>>();
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
                
                Sizes.Add(_str_strPlaceInfo, 200);
                Sizes.Add(_str_strComments, 500);
                Sizes.Add(_str_strName, 400);
                Sizes.Add(_str_strPersonContactType, 2000);
                Sizes.Add(_str_strPatientInformation, 2202);
                Sizes.Add(_str_strPostCode, 200);
                Sizes.Add(_str_strStreetName, 200);
                Sizes.Add(_str_strHouse, 200);
                Sizes.Add(_str_strBuilding, 200);
                Sizes.Add(_str_strApartment, 200);
                Sizes.Add(_str_strPatientAddressString, 2000);
                if (!RequiredByField.ContainsKey("Person.strLastName")) RequiredByField.Add("Person.strLastName", c => true);
                if (!RequiredByProperty.ContainsKey("Person.strLastName")) RequiredByProperty.Add("Person.strLastName", c => true);
                
                if (!RequiredByField.ContainsKey("idfsPersonContactType")) RequiredByField.Add("idfsPersonContactType", c => true);
                if (!RequiredByProperty.ContainsKey("PersonContactType")) RequiredByProperty.Add("PersonContactType", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfContactedCasePerson,
                    _str_idfContactedCasePerson, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfHuman,
                    _str_idfHuman, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFullName,
                    "strName", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsPersonContactType,
                    _str_idfsPersonContactType, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPersonContactType,
                    _str_strPersonContactType, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datDateOfLastContact,
                    _str_datDateOfLastContact, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPlaceInfo,
                    _str_strPlaceInfo, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCurrentResidenceAddress,
                    "strRegistrationAddress", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsSettlement,
                    _str_idfsSettlement, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsRegion,
                    _str_idfsRegion, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsRayon,
                    _str_idfsRayon, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_GeoLocationNameWithHiddenPersonalData,
                    "strRegistrationAddress", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strComments,
                    _str_strComments, null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).Create(manager, c, pars)),
                        
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
                    "Edit",
                    ActionTypes.Edit,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strEdit_Id",
                        "edit",
                        /*from BvMessages*/"tooltipEdit_Id",
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"tooltipEdit_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
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
                    (manager, c, pars) => ((ContactedCasePerson)c).MarkToDelete(),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
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
                    (manager, c, pars) => new ActResult(true, c),
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
	