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
    public abstract partial class VsSessionListItem : 
        EditableObject<VsSessionListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfVectorSurveillanceSession), NonUpdatable, PrimaryKey]
        public abstract Int64 idfVectorSurveillanceSession { get; set; }
                
        [LocalizedDisplayName(_str_strSessionID)]
        [MapField(_str_strSessionID)]
        public abstract String strSessionID { get; set; }
        protected String strSessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strSessionID).OriginalValue; } }
        protected String strSessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSessionID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strVectors)]
        [MapField(_str_strVectors)]
        public abstract String strVectors { get; set; }
        protected String strVectors_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectors).OriginalValue; } }
        protected String strVectors_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectors).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strVectorTypeIds)]
        [MapField(_str_strVectorTypeIds)]
        public abstract String strVectorTypeIds { get; set; }
        protected String strVectorTypeIds_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorTypeIds).OriginalValue; } }
        protected String strVectorTypeIds_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorTypeIds).PreviousValue; } }
                
        [LocalizedDisplayName("strDisease")]
        [MapField(_str_strDiagnoses)]
        public abstract String strDiagnoses { get; set; }
        protected String strDiagnoses_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnoses).OriginalValue; } }
        protected String strDiagnoses_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnoses).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFieldSessionID)]
        [MapField(_str_strFieldSessionID)]
        public abstract String strFieldSessionID { get; set; }
        protected String strFieldSessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldSessionID).OriginalValue; } }
        protected String strFieldSessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldSessionID).PreviousValue; } }
                
        [LocalizedDisplayName("idfsVectorSurveillanceStatus")]
        [MapField(_str_strVSStatus)]
        public abstract String strVSStatus { get; set; }
        protected String strVSStatus_Original { get { return ((EditableValue<String>)((dynamic)this)._strVSStatus).OriginalValue; } }
        protected String strVSStatus_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVSStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsVectorSurveillanceStatus)]
        [MapField(_str_idfsVectorSurveillanceStatus)]
        public abstract Int64 idfsVectorSurveillanceStatus { get; set; }
        protected Int64 idfsVectorSurveillanceStatus_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSurveillanceStatus).OriginalValue; } }
        protected Int64 idfsVectorSurveillanceStatus_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSurveillanceStatus).PreviousValue; } }
                
        [LocalizedDisplayName("idfsCountry")]
        [MapField(_str_strCountry)]
        public abstract String strCountry { get; set; }
        protected String strCountry_Original { get { return ((EditableValue<String>)((dynamic)this)._strCountry).OriginalValue; } }
        protected String strCountry_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCountry).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCountry)]
        [MapField(_str_idfsCountry)]
        public abstract Int64? idfsCountry { get; set; }
        protected Int64? idfsCountry_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).OriginalValue; } }
        protected Int64? idfsCountry_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRegion)]
        [MapField(_str_strRegion)]
        public abstract String strRegion { get; set; }
        protected String strRegion_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegion).OriginalValue; } }
        protected String strRegion_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegion).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRegion)]
        [MapField(_str_idfsRegion)]
        public abstract Int64? idfsRegion { get; set; }
        protected Int64? idfsRegion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).OriginalValue; } }
        protected Int64? idfsRegion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRayon)]
        [MapField(_str_strRayon)]
        public abstract String strRayon { get; set; }
        protected String strRayon_Original { get { return ((EditableValue<String>)((dynamic)this)._strRayon).OriginalValue; } }
        protected String strRayon_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRayon).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSettlement)]
        [MapField(_str_idfsSettlement)]
        public abstract Int64? idfsSettlement { get; set; }
        protected Int64? idfsSettlement_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).OriginalValue; } }
        protected Int64? idfsSettlement_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSettlement)]
        [MapField(_str_strSettlement)]
        public abstract String strSettlement { get; set; }
        protected String strSettlement_Original { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).OriginalValue; } }
        protected String strSettlement_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRayon)]
        [MapField(_str_idfsRayon)]
        public abstract Int64? idfsRayon { get; set; }
        protected Int64? idfsRayon_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).OriginalValue; } }
        protected Int64? idfsRayon_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).PreviousValue; } }
                
        [LocalizedDisplayName("VsSessionListItem.dblLatitude")]
        [MapField(_str_dblLatitude)]
        public abstract Double? dblLatitude { get; set; }
        protected Double? dblLatitude_Original { get { return ((EditableValue<Double?>)((dynamic)this)._dblLatitude).OriginalValue; } }
        protected Double? dblLatitude_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._dblLatitude).PreviousValue; } }
                
        [LocalizedDisplayName("VsSessionListItem.dblLongitude")]
        [MapField(_str_dblLongitude)]
        public abstract Double? dblLongitude { get; set; }
        protected Double? dblLongitude_Original { get { return ((EditableValue<Double?>)((dynamic)this)._dblLongitude).OriginalValue; } }
        protected Double? dblLongitude_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._dblLongitude).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datStartDate)]
        [MapField(_str_datStartDate)]
        public abstract DateTime datStartDate { get; set; }
        protected DateTime datStartDate_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datStartDate).OriginalValue; } }
        protected DateTime datStartDate_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datStartDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datCloseDate)]
        [MapField(_str_datCloseDate)]
        public abstract DateTime? datCloseDate { get; set; }
        protected DateTime? datCloseDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCloseDate).OriginalValue; } }
        protected DateTime? datCloseDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCloseDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfOutbreak)]
        [MapField(_str_idfOutbreak)]
        public abstract Int64? idfOutbreak { get; set; }
        protected Int64? idfOutbreak_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOutbreak).OriginalValue; } }
        protected Int64? idfOutbreak_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOutbreak).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfLocation)]
        [MapField(_str_idfLocation)]
        public abstract Int64? idfLocation { get; set; }
        protected Int64? idfLocation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfLocation).OriginalValue; } }
        protected Int64? idfLocation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfLocation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64 idfsSite { get; set; }
        protected Int64 idfsSite_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64 idfsSite_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<VsSessionListItem, object> _get_func;
            internal Action<VsSessionListItem, string> _set_func;
            internal Action<VsSessionListItem, VsSessionListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_strSessionID = "strSessionID";
        internal const string _str_strVectors = "strVectors";
        internal const string _str_strVectorTypeIds = "strVectorTypeIds";
        internal const string _str_strDiagnoses = "strDiagnoses";
        internal const string _str_strFieldSessionID = "strFieldSessionID";
        internal const string _str_strVSStatus = "strVSStatus";
        internal const string _str_idfsVectorSurveillanceStatus = "idfsVectorSurveillanceStatus";
        internal const string _str_strCountry = "strCountry";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_strRegion = "strRegion";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_strRayon = "strRayon";
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_strSettlement = "strSettlement";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_dblLatitude = "dblLatitude";
        internal const string _str_dblLongitude = "dblLongitude";
        internal const string _str_datStartDate = "datStartDate";
        internal const string _str_datCloseDate = "datCloseDate";
        internal const string _str_idfOutbreak = "idfOutbreak";
        internal const string _str_idfLocation = "idfLocation";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_idfsVectorSubType = "idfsVectorSubType";
        internal const string _str_idfsDiagnosisGroup = "idfsDiagnosisGroup";
        internal const string _str_VsStatus = "VsStatus";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Settlement = "Settlement";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_VsVectorType = "VsVectorType";
        internal const string _str_VsVectorSubType = "VsVectorSubType";
        internal const string _str_Outbreak = "Outbreak";
        internal const string _str_DiagnosisGroup = "DiagnosisGroup";
        internal const string _str_Site = "Site";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _formname = _str_idfVectorSurveillanceSession, _type = "Int64",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVectorSurveillanceSession != newval) o.idfVectorSurveillanceSession = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, o.ObjectIdent2 + _str_idfVectorSurveillanceSession, o.ObjectIdent3 + _str_idfVectorSurveillanceSession, "Int64", 
                    o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(),                  
                  o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSessionID, _formname = _str_strSessionID, _type = "String",
              _get_func = o => o.strSessionID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSessionID != newval) o.strSessionID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSessionID != c.strSessionID || o.IsRIRPropChanged(_str_strSessionID, c)) 
                  m.Add(_str_strSessionID, o.ObjectIdent + _str_strSessionID, o.ObjectIdent2 + _str_strSessionID, o.ObjectIdent3 + _str_strSessionID, "String", 
                    o.strSessionID == null ? "" : o.strSessionID.ToString(),                  
                  o.IsReadOnly(_str_strSessionID), o.IsInvisible(_str_strSessionID), o.IsRequired(_str_strSessionID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strVectors, _formname = _str_strVectors, _type = "String",
              _get_func = o => o.strVectors,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVectors != newval) o.strVectors = newval; },
              _compare_func = (o, c, m) => {
                if (o.strVectors != c.strVectors || o.IsRIRPropChanged(_str_strVectors, c)) 
                  m.Add(_str_strVectors, o.ObjectIdent + _str_strVectors, o.ObjectIdent2 + _str_strVectors, o.ObjectIdent3 + _str_strVectors, "String", 
                    o.strVectors == null ? "" : o.strVectors.ToString(),                  
                  o.IsReadOnly(_str_strVectors), o.IsInvisible(_str_strVectors), o.IsRequired(_str_strVectors)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strVectorTypeIds, _formname = _str_strVectorTypeIds, _type = "String",
              _get_func = o => o.strVectorTypeIds,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVectorTypeIds != newval) o.strVectorTypeIds = newval; },
              _compare_func = (o, c, m) => {
                if (o.strVectorTypeIds != c.strVectorTypeIds || o.IsRIRPropChanged(_str_strVectorTypeIds, c)) 
                  m.Add(_str_strVectorTypeIds, o.ObjectIdent + _str_strVectorTypeIds, o.ObjectIdent2 + _str_strVectorTypeIds, o.ObjectIdent3 + _str_strVectorTypeIds, "String", 
                    o.strVectorTypeIds == null ? "" : o.strVectorTypeIds.ToString(),                  
                  o.IsReadOnly(_str_strVectorTypeIds), o.IsInvisible(_str_strVectorTypeIds), o.IsRequired(_str_strVectorTypeIds)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDiagnoses, _formname = _str_strDiagnoses, _type = "String",
              _get_func = o => o.strDiagnoses,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDiagnoses != newval) o.strDiagnoses = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDiagnoses != c.strDiagnoses || o.IsRIRPropChanged(_str_strDiagnoses, c)) 
                  m.Add(_str_strDiagnoses, o.ObjectIdent + _str_strDiagnoses, o.ObjectIdent2 + _str_strDiagnoses, o.ObjectIdent3 + _str_strDiagnoses, "String", 
                    o.strDiagnoses == null ? "" : o.strDiagnoses.ToString(),                  
                  o.IsReadOnly(_str_strDiagnoses), o.IsInvisible(_str_strDiagnoses), o.IsRequired(_str_strDiagnoses)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFieldSessionID, _formname = _str_strFieldSessionID, _type = "String",
              _get_func = o => o.strFieldSessionID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFieldSessionID != newval) o.strFieldSessionID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFieldSessionID != c.strFieldSessionID || o.IsRIRPropChanged(_str_strFieldSessionID, c)) 
                  m.Add(_str_strFieldSessionID, o.ObjectIdent + _str_strFieldSessionID, o.ObjectIdent2 + _str_strFieldSessionID, o.ObjectIdent3 + _str_strFieldSessionID, "String", 
                    o.strFieldSessionID == null ? "" : o.strFieldSessionID.ToString(),                  
                  o.IsReadOnly(_str_strFieldSessionID), o.IsInvisible(_str_strFieldSessionID), o.IsRequired(_str_strFieldSessionID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strVSStatus, _formname = _str_strVSStatus, _type = "String",
              _get_func = o => o.strVSStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVSStatus != newval) o.strVSStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.strVSStatus != c.strVSStatus || o.IsRIRPropChanged(_str_strVSStatus, c)) 
                  m.Add(_str_strVSStatus, o.ObjectIdent + _str_strVSStatus, o.ObjectIdent2 + _str_strVSStatus, o.ObjectIdent3 + _str_strVSStatus, "String", 
                    o.strVSStatus == null ? "" : o.strVSStatus.ToString(),                  
                  o.IsReadOnly(_str_strVSStatus), o.IsInvisible(_str_strVSStatus), o.IsRequired(_str_strVSStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsVectorSurveillanceStatus, _formname = _str_idfsVectorSurveillanceStatus, _type = "Int64",
              _get_func = o => o.idfsVectorSurveillanceStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsVectorSurveillanceStatus != newval) 
                  o.VsStatus = o.VsStatusLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsVectorSurveillanceStatus != newval) o.idfsVectorSurveillanceStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorSurveillanceStatus != c.idfsVectorSurveillanceStatus || o.IsRIRPropChanged(_str_idfsVectorSurveillanceStatus, c)) 
                  m.Add(_str_idfsVectorSurveillanceStatus, o.ObjectIdent + _str_idfsVectorSurveillanceStatus, o.ObjectIdent2 + _str_idfsVectorSurveillanceStatus, o.ObjectIdent3 + _str_idfsVectorSurveillanceStatus, "Int64", 
                    o.idfsVectorSurveillanceStatus == null ? "" : o.idfsVectorSurveillanceStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsVectorSurveillanceStatus), o.IsInvisible(_str_idfsVectorSurveillanceStatus), o.IsRequired(_str_idfsVectorSurveillanceStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCountry, _formname = _str_strCountry, _type = "String",
              _get_func = o => o.strCountry,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCountry != newval) o.strCountry = newval; },
              _compare_func = (o, c, m) => {
                if (o.strCountry != c.strCountry || o.IsRIRPropChanged(_str_strCountry, c)) 
                  m.Add(_str_strCountry, o.ObjectIdent + _str_strCountry, o.ObjectIdent2 + _str_strCountry, o.ObjectIdent3 + _str_strCountry, "String", 
                    o.strCountry == null ? "" : o.strCountry.ToString(),                  
                  o.IsReadOnly(_str_strCountry), o.IsInvisible(_str_strCountry), o.IsRequired(_str_strCountry)); 
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
              _name = _str_strRegion, _formname = _str_strRegion, _type = "String",
              _get_func = o => o.strRegion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRegion != newval) o.strRegion = newval; },
              _compare_func = (o, c, m) => {
                if (o.strRegion != c.strRegion || o.IsRIRPropChanged(_str_strRegion, c)) 
                  m.Add(_str_strRegion, o.ObjectIdent + _str_strRegion, o.ObjectIdent2 + _str_strRegion, o.ObjectIdent3 + _str_strRegion, "String", 
                    o.strRegion == null ? "" : o.strRegion.ToString(),                  
                  o.IsReadOnly(_str_strRegion), o.IsInvisible(_str_strRegion), o.IsRequired(_str_strRegion)); 
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
              _name = _str_strRayon, _formname = _str_strRayon, _type = "String",
              _get_func = o => o.strRayon,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRayon != newval) o.strRayon = newval; },
              _compare_func = (o, c, m) => {
                if (o.strRayon != c.strRayon || o.IsRIRPropChanged(_str_strRayon, c)) 
                  m.Add(_str_strRayon, o.ObjectIdent + _str_strRayon, o.ObjectIdent2 + _str_strRayon, o.ObjectIdent3 + _str_strRayon, "String", 
                    o.strRayon == null ? "" : o.strRayon.ToString(),                  
                  o.IsReadOnly(_str_strRayon), o.IsInvisible(_str_strRayon), o.IsRequired(_str_strRayon)); 
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
              _name = _str_strSettlement, _formname = _str_strSettlement, _type = "String",
              _get_func = o => o.strSettlement,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSettlement != newval) o.strSettlement = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSettlement != c.strSettlement || o.IsRIRPropChanged(_str_strSettlement, c)) 
                  m.Add(_str_strSettlement, o.ObjectIdent + _str_strSettlement, o.ObjectIdent2 + _str_strSettlement, o.ObjectIdent3 + _str_strSettlement, "String", 
                    o.strSettlement == null ? "" : o.strSettlement.ToString(),                  
                  o.IsReadOnly(_str_strSettlement), o.IsInvisible(_str_strSettlement), o.IsRequired(_str_strSettlement)); 
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
              _name = _str_datStartDate, _formname = _str_datStartDate, _type = "DateTime",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTime(val); if (o.datStartDate != newval) o.datStartDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) 
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, o.ObjectIdent2 + _str_datStartDate, o.ObjectIdent3 + _str_datStartDate, "DateTime", 
                    o.datStartDate == null ? "" : o.datStartDate.ToString(),                  
                  o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datCloseDate, _formname = _str_datCloseDate, _type = "DateTime?",
              _get_func = o => o.datCloseDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datCloseDate != newval) o.datCloseDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datCloseDate != c.datCloseDate || o.IsRIRPropChanged(_str_datCloseDate, c)) 
                  m.Add(_str_datCloseDate, o.ObjectIdent + _str_datCloseDate, o.ObjectIdent2 + _str_datCloseDate, o.ObjectIdent3 + _str_datCloseDate, "DateTime?", 
                    o.datCloseDate == null ? "" : o.datCloseDate.ToString(),                  
                  o.IsReadOnly(_str_datCloseDate), o.IsInvisible(_str_datCloseDate), o.IsRequired(_str_datCloseDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfOutbreak, _formname = _str_idfOutbreak, _type = "Int64?",
              _get_func = o => o.idfOutbreak,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfOutbreak != newval) 
                  o.Outbreak = o.OutbreakLookup.FirstOrDefault(c => c.idfOutbreak == newval);
                if (o.idfOutbreak != newval) o.idfOutbreak = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfOutbreak != c.idfOutbreak || o.IsRIRPropChanged(_str_idfOutbreak, c)) 
                  m.Add(_str_idfOutbreak, o.ObjectIdent + _str_idfOutbreak, o.ObjectIdent2 + _str_idfOutbreak, o.ObjectIdent3 + _str_idfOutbreak, "Int64?", 
                    o.idfOutbreak == null ? "" : o.idfOutbreak.ToString(),                  
                  o.IsReadOnly(_str_idfOutbreak), o.IsInvisible(_str_idfOutbreak), o.IsRequired(_str_idfOutbreak)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfLocation, _formname = _str_idfLocation, _type = "Int64?",
              _get_func = o => o.idfLocation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfLocation != newval) o.idfLocation = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfLocation != c.idfLocation || o.IsRIRPropChanged(_str_idfLocation, c)) 
                  m.Add(_str_idfLocation, o.ObjectIdent + _str_idfLocation, o.ObjectIdent2 + _str_idfLocation, o.ObjectIdent3 + _str_idfLocation, "Int64?", 
                    o.idfLocation == null ? "" : o.idfLocation.ToString(),                  
                  o.IsReadOnly(_str_idfLocation), o.IsInvisible(_str_idfLocation), o.IsRequired(_str_idfLocation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSite, _formname = _str_idfsSite, _type = "Int64",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsSite != newval) 
                  o.Site = o.SiteLookup.FirstOrDefault(c => c.idfsSite == newval);
                if (o.idfsSite != newval) o.idfsSite = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_idfsSite, c)) 
                  m.Add(_str_idfsSite, o.ObjectIdent + _str_idfsSite, o.ObjectIdent2 + _str_idfsSite, o.ObjectIdent3 + _str_idfsSite, "Int64", 
                    o.idfsSite == null ? "" : o.idfsSite.ToString(),                  
                  o.IsReadOnly(_str_idfsSite), o.IsInvisible(_str_idfsSite), o.IsRequired(_str_idfsSite)); 
                  }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "long?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) {
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis,  "long?", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                    o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsVectorType, _formname = _str_idfsVectorType, _type = "long?",
              _get_func = o => o.idfsVectorType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsVectorType != newval) o.idfsVectorType = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_idfsVectorType, c)) {
                  m.Add(_str_idfsVectorType, o.ObjectIdent + _str_idfsVectorType, o.ObjectIdent2 + _str_idfsVectorType, o.ObjectIdent3 + _str_idfsVectorType,  "long?", 
                    o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(),                  
                    o.IsReadOnly(_str_idfsVectorType), o.IsInvisible(_str_idfsVectorType), o.IsRequired(_str_idfsVectorType));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsVectorSubType, _formname = _str_idfsVectorSubType, _type = "long?",
              _get_func = o => o.idfsVectorSubType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsVectorSubType != newval) o.idfsVectorSubType = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsVectorSubType != c.idfsVectorSubType || o.IsRIRPropChanged(_str_idfsVectorSubType, c)) {
                  m.Add(_str_idfsVectorSubType, o.ObjectIdent + _str_idfsVectorSubType, o.ObjectIdent2 + _str_idfsVectorSubType, o.ObjectIdent3 + _str_idfsVectorSubType,  "long?", 
                    o.idfsVectorSubType == null ? "" : o.idfsVectorSubType.ToString(),                  
                    o.IsReadOnly(_str_idfsVectorSubType), o.IsInvisible(_str_idfsVectorSubType), o.IsRequired(_str_idfsVectorSubType));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosisGroup, _formname = _str_idfsDiagnosisGroup, _type = "long?",
              _get_func = o => o.idfsDiagnosisGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsDiagnosisGroup != newval) o.idfsDiagnosisGroup = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsDiagnosisGroup != c.idfsDiagnosisGroup || o.IsRIRPropChanged(_str_idfsDiagnosisGroup, c)) {
                  m.Add(_str_idfsDiagnosisGroup, o.ObjectIdent + _str_idfsDiagnosisGroup, o.ObjectIdent2 + _str_idfsDiagnosisGroup, o.ObjectIdent3 + _str_idfsDiagnosisGroup,  "long?", 
                    o.idfsDiagnosisGroup == null ? "" : o.idfsDiagnosisGroup.ToString(),                  
                    o.IsReadOnly(_str_idfsDiagnosisGroup), o.IsInvisible(_str_idfsDiagnosisGroup), o.IsRequired(_str_idfsDiagnosisGroup));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_VsStatus, _formname = _str_VsStatus, _type = "Lookup",
              _get_func = o => { if (o.VsStatus == null) return null; return o.VsStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.VsStatus = o.VsStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorSurveillanceStatus != c.idfsVectorSurveillanceStatus || o.IsRIRPropChanged(_str_VsStatus, c)) {
                  m.Add(_str_VsStatus, o.ObjectIdent + _str_VsStatus, o.ObjectIdent2 + _str_VsStatus, o.ObjectIdent3 + _str_VsStatus, "Lookup", o.idfsVectorSurveillanceStatus == null ? "" : o.idfsVectorSurveillanceStatus.ToString(), o.IsReadOnly(_str_VsStatus), o.IsInvisible(_str_VsStatus), o.IsRequired(_str_VsStatus)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_VsStatus + "Lookup", _formname = _str_VsStatus + "Lookup", _type = "LookupContent",
              _get_func = o => o.VsStatusLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
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
              _name = _str_Diagnosis, _formname = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnosis, c)) {
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, o.ObjectIdent2 + _str_Diagnosis, o.ObjectIdent3 + _str_Diagnosis, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Diagnosis + "Lookup", _formname = _str_Diagnosis + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_VsVectorType, _formname = _str_VsVectorType, _type = "Lookup",
              _get_func = o => { if (o.VsVectorType == null) return null; return o.VsVectorType.idfsBaseReference; },
              _set_func = (o, val) => { o.VsVectorType = o.VsVectorTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_VsVectorType, c)) {
                  m.Add(_str_VsVectorType, o.ObjectIdent + _str_VsVectorType, o.ObjectIdent2 + _str_VsVectorType, o.ObjectIdent3 + _str_VsVectorType, "Lookup", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_VsVectorType), o.IsInvisible(_str_VsVectorType), o.IsRequired(_str_VsVectorType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_VsVectorType + "Lookup", _formname = _str_VsVectorType + "Lookup", _type = "LookupContent",
              _get_func = o => o.VsVectorTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_VsVectorSubType, _formname = _str_VsVectorSubType, _type = "Lookup",
              _get_func = o => { if (o.VsVectorSubType == null) return null; return o.VsVectorSubType.idfsBaseReference; },
              _set_func = (o, val) => { o.VsVectorSubType = o.VsVectorSubTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorSubType != c.idfsVectorSubType || o.IsRIRPropChanged(_str_VsVectorSubType, c)) {
                  m.Add(_str_VsVectorSubType, o.ObjectIdent + _str_VsVectorSubType, o.ObjectIdent2 + _str_VsVectorSubType, o.ObjectIdent3 + _str_VsVectorSubType, "Lookup", o.idfsVectorSubType == null ? "" : o.idfsVectorSubType.ToString(), o.IsReadOnly(_str_VsVectorSubType), o.IsInvisible(_str_VsVectorSubType), o.IsRequired(_str_VsVectorSubType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_VsVectorSubType + "Lookup", _formname = _str_VsVectorSubType + "Lookup", _type = "LookupContent",
              _get_func = o => o.VsVectorSubTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Outbreak, _formname = _str_Outbreak, _type = "Lookup",
              _get_func = o => { if (o.Outbreak == null) return null; return o.Outbreak.idfOutbreak; },
              _set_func = (o, val) => { o.Outbreak = o.OutbreakLookup.Where(c => c.idfOutbreak.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfOutbreak != c.idfOutbreak || o.IsRIRPropChanged(_str_Outbreak, c)) {
                  m.Add(_str_Outbreak, o.ObjectIdent + _str_Outbreak, o.ObjectIdent2 + _str_Outbreak, o.ObjectIdent3 + _str_Outbreak, "Lookup", o.idfOutbreak == null ? "" : o.idfOutbreak.ToString(), o.IsReadOnly(_str_Outbreak), o.IsInvisible(_str_Outbreak), o.IsRequired(_str_Outbreak)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Outbreak + "Lookup", _formname = _str_Outbreak + "Lookup", _type = "LookupContent",
              _get_func = o => o.OutbreakLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_DiagnosisGroup, _formname = _str_DiagnosisGroup, _type = "Lookup",
              _get_func = o => { if (o.DiagnosisGroup == null) return null; return o.DiagnosisGroup.idfsBaseReference; },
              _set_func = (o, val) => { o.DiagnosisGroup = o.DiagnosisGroupLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosisGroup != c.idfsDiagnosisGroup || o.IsRIRPropChanged(_str_DiagnosisGroup, c)) {
                  m.Add(_str_DiagnosisGroup, o.ObjectIdent + _str_DiagnosisGroup, o.ObjectIdent2 + _str_DiagnosisGroup, o.ObjectIdent3 + _str_DiagnosisGroup, "Lookup", o.idfsDiagnosisGroup == null ? "" : o.idfsDiagnosisGroup.ToString(), o.IsReadOnly(_str_DiagnosisGroup), o.IsInvisible(_str_DiagnosisGroup), o.IsRequired(_str_DiagnosisGroup)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_DiagnosisGroup + "Lookup", _formname = _str_DiagnosisGroup + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisGroupLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Site, _formname = _str_Site, _type = "Lookup",
              _get_func = o => { if (o.Site == null) return null; return o.Site.idfsSite; },
              _set_func = (o, val) => { o.Site = o.SiteLookup.Where(c => c.idfsSite.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_Site, c)) {
                  m.Add(_str_Site, o.ObjectIdent + _str_Site, o.ObjectIdent2 + _str_Site, o.ObjectIdent3 + _str_Site, "Lookup", o.idfsSite == null ? "" : o.idfsSite.ToString(), o.IsReadOnly(_str_Site), o.IsInvisible(_str_Site), o.IsRequired(_str_Site)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Site + "Lookup", _formname = _str_Site + "Lookup", _type = "LookupContent",
              _get_func = o => o.SiteLookup,
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
            VsSessionListItem obj = (VsSessionListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_VsStatus)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsVectorSurveillanceStatus)]
        public BaseReference VsStatus
        {
            get { return _VsStatus == null ? null : ((long)_VsStatus.Key == 0 ? null : _VsStatus); }
            set 
            { 
                var oldVal = _VsStatus;
                _VsStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_VsStatus != oldVal)
                {
                    if (idfsVectorSurveillanceStatus != (_VsStatus == null
                            ? new Int64()
                            : (Int64)_VsStatus.idfsBaseReference))
                        idfsVectorSurveillanceStatus = _VsStatus == null 
                            ? new Int64()
                            : (Int64)_VsStatus.idfsBaseReference; 
                    OnPropertyChanged(_str_VsStatus); 
                }
            }
        }
        private BaseReference _VsStatus;

        
        public BaseReferenceList VsStatusLookup
        {
            get { return _VsStatusLookup; }
        }
        private BaseReferenceList _VsStatusLookup = new BaseReferenceList("rftVectorSurveillanceSessionStatus");
            
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
            
        [LocalizedDisplayName(_str_Diagnosis)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                var oldVal = _Diagnosis;
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Diagnosis != oldVal)
                {
                    if (idfsDiagnosis != (_Diagnosis == null
                            ? new long?()
                            : _Diagnosis.idfsDiagnosis))
                        idfsDiagnosis = _Diagnosis == null 
                            ? new long?()
                            : _Diagnosis.idfsDiagnosis; 
                    OnPropertyChanged(_str_Diagnosis); 
                }
            }
        }
        private DiagnosisLookup _Diagnosis;

        
        public List<DiagnosisLookup> DiagnosisLookup
        {
            get { return _DiagnosisLookup; }
        }
        private List<DiagnosisLookup> _DiagnosisLookup = new List<DiagnosisLookup>();
            
        [LocalizedDisplayName(_str_VsVectorType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsVectorType)]
        public BaseReference VsVectorType
        {
            get { return _VsVectorType == null ? null : ((long)_VsVectorType.Key == 0 ? null : _VsVectorType); }
            set 
            { 
                var oldVal = _VsVectorType;
                _VsVectorType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_VsVectorType != oldVal)
                {
                    if (idfsVectorType != (_VsVectorType == null
                            ? new long?()
                            : _VsVectorType.idfsBaseReference))
                        idfsVectorType = _VsVectorType == null 
                            ? new long?()
                            : _VsVectorType.idfsBaseReference; 
                    OnPropertyChanged(_str_VsVectorType); 
                }
            }
        }
        private BaseReference _VsVectorType;

        
        public BaseReferenceList VsVectorTypeLookup
        {
            get { return _VsVectorTypeLookup; }
        }
        private BaseReferenceList _VsVectorTypeLookup = new BaseReferenceList("rftVectorType");
            
        [LocalizedDisplayName(_str_VsVectorSubType)]
        [Relation(typeof(VectorSubTypeLookup), eidss.model.Schema.VectorSubTypeLookup._str_idfsBaseReference, _str_idfsVectorSubType)]
        public VectorSubTypeLookup VsVectorSubType
        {
            get { return _VsVectorSubType == null ? null : ((long)_VsVectorSubType.Key == 0 ? null : _VsVectorSubType); }
            set 
            { 
                var oldVal = _VsVectorSubType;
                _VsVectorSubType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_VsVectorSubType != oldVal)
                {
                    if (idfsVectorSubType != (_VsVectorSubType == null
                            ? new long?()
                            : _VsVectorSubType.idfsBaseReference))
                        idfsVectorSubType = _VsVectorSubType == null 
                            ? new long?()
                            : _VsVectorSubType.idfsBaseReference; 
                    OnPropertyChanged(_str_VsVectorSubType); 
                }
            }
        }
        private VectorSubTypeLookup _VsVectorSubType;

        
        public List<VectorSubTypeLookup> VsVectorSubTypeLookup
        {
            get { return _VsVectorSubTypeLookup; }
        }
        private List<VectorSubTypeLookup> _VsVectorSubTypeLookup = new List<VectorSubTypeLookup>();
            
        [LocalizedDisplayName(_str_Outbreak)]
        [Relation(typeof(OutbreakLookup), eidss.model.Schema.OutbreakLookup._str_idfOutbreak, _str_idfOutbreak)]
        public OutbreakLookup Outbreak
        {
            get { return _Outbreak == null ? null : ((long)_Outbreak.Key == 0 ? null : _Outbreak); }
            set 
            { 
                var oldVal = _Outbreak;
                _Outbreak = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Outbreak != oldVal)
                {
                    if (idfOutbreak != (_Outbreak == null
                            ? new Int64?()
                            : (Int64?)_Outbreak.idfOutbreak))
                        idfOutbreak = _Outbreak == null 
                            ? new Int64?()
                            : (Int64?)_Outbreak.idfOutbreak; 
                    OnPropertyChanged(_str_Outbreak); 
                }
            }
        }
        private OutbreakLookup _Outbreak;

        
        public List<OutbreakLookup> OutbreakLookup
        {
            get { return _OutbreakLookup; }
        }
        private List<OutbreakLookup> _OutbreakLookup = new List<OutbreakLookup>();
            
        [LocalizedDisplayName(_str_DiagnosisGroup)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsDiagnosisGroup)]
        public BaseReference DiagnosisGroup
        {
            get { return _DiagnosisGroup == null ? null : ((long)_DiagnosisGroup.Key == 0 ? null : _DiagnosisGroup); }
            set 
            { 
                var oldVal = _DiagnosisGroup;
                _DiagnosisGroup = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_DiagnosisGroup != oldVal)
                {
                    if (idfsDiagnosisGroup != (_DiagnosisGroup == null
                            ? new long?()
                            : _DiagnosisGroup.idfsBaseReference))
                        idfsDiagnosisGroup = _DiagnosisGroup == null 
                            ? new long?()
                            : _DiagnosisGroup.idfsBaseReference; 
                    OnPropertyChanged(_str_DiagnosisGroup); 
                }
            }
        }
        private BaseReference _DiagnosisGroup;

        
        public BaseReferenceList DiagnosisGroupLookup
        {
            get { return _DiagnosisGroupLookup; }
        }
        private BaseReferenceList _DiagnosisGroupLookup = new BaseReferenceList("rftDiagnosisGroup");
            
        [LocalizedDisplayName(_str_Site)]
        [Relation(typeof(SiteLookup), eidss.model.Schema.SiteLookup._str_idfsSite, _str_idfsSite)]
        public SiteLookup Site
        {
            get { return _Site == null ? null : ((long)_Site.Key == 0 ? null : _Site); }
            set 
            { 
                var oldVal = _Site;
                _Site = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Site != oldVal)
                {
                    if (idfsSite != (_Site == null
                            ? new Int64()
                            : (Int64)_Site.idfsSite))
                        idfsSite = _Site == null 
                            ? new Int64()
                            : (Int64)_Site.idfsSite; 
                    OnPropertyChanged(_str_Site); 
                }
            }
        }
        private SiteLookup _Site;

        
        public List<SiteLookup> SiteLookup
        {
            get { return _SiteLookup; }
        }
        private List<SiteLookup> _SiteLookup = new List<SiteLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_VsStatus:
                    return new BvSelectList(VsStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, VsStatus, _str_idfsVectorSurveillanceStatus);
            
                case _str_Country:
                    return new BvSelectList(CountryLookup, eidss.model.Schema.CountryLookup._str_idfsCountry, null, Country, _str_idfsCountry);
            
                case _str_Region:
                    return new BvSelectList(RegionLookup, eidss.model.Schema.RegionLookup._str_idfsRegion, null, Region, _str_idfsRegion);
            
                case _str_Rayon:
                    return new BvSelectList(RayonLookup, eidss.model.Schema.RayonLookup._str_idfsRayon, null, Rayon, _str_idfsRayon);
            
                case _str_Settlement:
                    return new BvSelectList(SettlementLookup, eidss.model.Schema.SettlementLookup._str_idfsSettlement, null, Settlement, _str_idfsSettlement);
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_VsVectorType:
                    return new BvSelectList(VsVectorTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, VsVectorType, _str_idfsVectorType);
            
                case _str_VsVectorSubType:
                    return new BvSelectList(VsVectorSubTypeLookup, eidss.model.Schema.VectorSubTypeLookup._str_idfsBaseReference, null, VsVectorSubType, _str_idfsVectorSubType);
            
                case _str_Outbreak:
                    return new BvSelectList(OutbreakLookup, eidss.model.Schema.OutbreakLookup._str_idfOutbreak, null, Outbreak, _str_idfOutbreak);
            
                case _str_DiagnosisGroup:
                    return new BvSelectList(DiagnosisGroupLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, DiagnosisGroup, _str_idfsDiagnosisGroup);
            
                case _str_Site:
                    return new BvSelectList(SiteLookup, eidss.model.Schema.SiteLookup._str_idfsSite, null, Site, _str_idfsSite);
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str_idfsDiagnosis)]
        public long? idfsDiagnosis
        {
            get { return m_idfsDiagnosis; }
            set { if (m_idfsDiagnosis != value) { m_idfsDiagnosis = value; OnPropertyChanged(_str_idfsDiagnosis); } }
        }
        private long? m_idfsDiagnosis;
        
          [LocalizedDisplayName(_str_idfsVectorType)]
        public long? idfsVectorType
        {
            get { return m_idfsVectorType; }
            set { if (m_idfsVectorType != value) { m_idfsVectorType = value; OnPropertyChanged(_str_idfsVectorType); } }
        }
        private long? m_idfsVectorType;
        
          [LocalizedDisplayName("idfSpecies")]
        public long? idfsVectorSubType
        {
            get { return m_idfsVectorSubType; }
            set { if (m_idfsVectorSubType != value) { m_idfsVectorSubType = value; OnPropertyChanged(_str_idfsVectorSubType); } }
        }
        private long? m_idfsVectorSubType;
        
          [LocalizedDisplayName(_str_idfsDiagnosisGroup)]
        public long? idfsDiagnosisGroup
        {
            get { return m_idfsDiagnosisGroup; }
            set { if (m_idfsDiagnosisGroup != value) { m_idfsDiagnosisGroup = value; OnPropertyChanged(_str_idfsDiagnosisGroup); } }
        }
        private long? m_idfsDiagnosisGroup;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "VsSessionListItem";

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
            var ret = base.Clone() as VsSessionListItem;
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
            var ret = base.Clone() as VsSessionListItem;
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
        public VsSessionListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VsSessionListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfVectorSurveillanceSession; } }
        public string KeyName { get { return "idfVectorSurveillanceSession"; } }
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
        
            var _prev_idfsVectorSurveillanceStatus_VsStatus = idfsVectorSurveillanceStatus;
            var _prev_idfsCountry_Country = idfsCountry;
            var _prev_idfsRegion_Region = idfsRegion;
            var _prev_idfsRayon_Rayon = idfsRayon;
            var _prev_idfsSettlement_Settlement = idfsSettlement;
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfsVectorType_VsVectorType = idfsVectorType;
            var _prev_idfsVectorSubType_VsVectorSubType = idfsVectorSubType;
            var _prev_idfOutbreak_Outbreak = idfOutbreak;
            var _prev_idfsDiagnosisGroup_DiagnosisGroup = idfsDiagnosisGroup;
            var _prev_idfsSite_Site = idfsSite;
            base.RejectChanges();
        
            if (_prev_idfsVectorSurveillanceStatus_VsStatus != idfsVectorSurveillanceStatus)
            {
                _VsStatus = _VsStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorSurveillanceStatus);
            }
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
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsVectorType_VsVectorType != idfsVectorType)
            {
                _VsVectorType = _VsVectorTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorType);
            }
            if (_prev_idfsVectorSubType_VsVectorSubType != idfsVectorSubType)
            {
                _VsVectorSubType = _VsVectorSubTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorSubType);
            }
            if (_prev_idfOutbreak_Outbreak != idfOutbreak)
            {
                _Outbreak = _OutbreakLookup.FirstOrDefault(c => c.idfOutbreak == idfOutbreak);
            }
            if (_prev_idfsDiagnosisGroup_DiagnosisGroup != idfsDiagnosisGroup)
            {
                _DiagnosisGroup = _DiagnosisGroupLookup.FirstOrDefault(c => c.idfsBaseReference == idfsDiagnosisGroup);
            }
            if (_prev_idfsSite_Site != idfsSite)
            {
                _Site = _SiteLookup.FirstOrDefault(c => c.idfsSite == idfsSite);
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

        private bool IsRIRPropChanged(string fld, VsSessionListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public VsSessionListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VsSessionListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VsSessionListItem_PropertyChanged);
        }
        private void VsSessionListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VsSessionListItem).Changed(e.PropertyName);
            
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
            VsSessionListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VsSessionListItem obj = this;
            
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
        
        private static string[] readonly_names3 = "Settlement,idfsSettlement".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "VectorSubType,idfsVectorSubType".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VsSessionListItem, bool>(c => c.idfsCountry == null)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VsSessionListItem, bool>(c => c.idfsRegion == null)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VsSessionListItem, bool>(c => c.idfsRayon == null)(this);
            
            if (readonly_names4.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VsSessionListItem, bool>(c => c.idfsVectorType == null)(this);
            
            return ReadOnly || new Func<VsSessionListItem, bool>(c => false)(this);
                
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


        internal Dictionary<string, Func<VsSessionListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VsSessionListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VsSessionListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VsSessionListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VsSessionListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<VsSessionListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<VsSessionListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~VsSessionListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftVectorSurveillanceSessionStatus", this);
                
                LookupManager.RemoveObject("CountryLookup", this);
                
                LookupManager.RemoveObject("RegionLookup", this);
                
                LookupManager.RemoveObject("RayonLookup", this);
                
                LookupManager.RemoveObject("SettlementLookup", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftVectorType", this);
                
                LookupManager.RemoveObject("VectorSubTypeLookup", this);
                
                LookupManager.RemoveObject("OutbreakLookup", this);
                
                LookupManager.RemoveObject("rftDiagnosisGroup", this);
                
                LookupManager.RemoveObject("SiteLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftVectorSurveillanceSessionStatus")
                _getAccessor().LoadLookup_VsStatus(manager, this);
            
            if (lookup_object == "CountryLookup")
                _getAccessor().LoadLookup_Country(manager, this);
            
            if (lookup_object == "RegionLookup")
                _getAccessor().LoadLookup_Region(manager, this);
            
            if (lookup_object == "RayonLookup")
                _getAccessor().LoadLookup_Rayon(manager, this);
            
            if (lookup_object == "SettlementLookup")
                _getAccessor().LoadLookup_Settlement(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftVectorType")
                _getAccessor().LoadLookup_VsVectorType(manager, this);
            
            if (lookup_object == "VectorSubTypeLookup")
                _getAccessor().LoadLookup_VsVectorSubType(manager, this);
            
            if (lookup_object == "OutbreakLookup")
                _getAccessor().LoadLookup_Outbreak(manager, this);
            
            if (lookup_object == "rftDiagnosisGroup")
                _getAccessor().LoadLookup_DiagnosisGroup(manager, this);
            
            if (lookup_object == "SiteLookup")
                _getAccessor().LoadLookup_Site(manager, this);
            
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
        public class VsSessionListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfVectorSurveillanceSession { get; set; }
        
            public String strSessionID { get; set; }
        
            public String strVSStatus { get; set; }
        
            public String strVectors { get; set; }
        
            public String strDiagnoses { get; set; }
        
            public String strRegion { get; set; }
        
            public String strRayon { get; set; }
        
            public Double? dblLongitude { get; set; }
        
            public Double? dblLatitude { get; set; }
        
            public DateTime datStartDate { get; set; }
        
            public DateTime? datCloseDate { get; set; }
        
        }
        public partial class VsSessionListItemGridModelList : List<VsSessionListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public VsSessionListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VsSessionListItem>, errMes);
            }
            public VsSessionListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VsSessionListItem>, errMes);
            }
            public VsSessionListItemGridModelList(long key, IEnumerable<VsSessionListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public VsSessionListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<VsSessionListItem>(), null);
            }
            partial void filter(List<VsSessionListItem> items);
            private void LoadGridModelList(long key, IEnumerable<VsSessionListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strSessionID,_str_strVSStatus,_str_strVectors,_str_strDiagnoses,_str_strRegion,_str_strRayon,_str_dblLongitude,_str_dblLatitude,_str_datStartDate,_str_datCloseDate};
                    
                Hiddens = new List<string> {_str_idfVectorSurveillanceSession};
                Keys = new List<string> {_str_idfVectorSurveillanceSession};
                Labels = new Dictionary<string, string> {{_str_strSessionID, _str_strSessionID},{_str_strVSStatus, "idfsVectorSurveillanceStatus"},{_str_strVectors, _str_strVectors},{_str_strDiagnoses, "strDisease"},{_str_strRegion, _str_strRegion},{_str_strRayon, _str_strRayon},{_str_dblLongitude, "VsSessionListItem.dblLongitude"},{_str_dblLatitude, "VsSessionListItem.dblLatitude"},{_str_datStartDate, _str_datStartDate},{_str_datCloseDate, _str_datCloseDate}};
                Actions = new Dictionary<string, ActionMetaItem> {{_str_strSessionID, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "ActionEditVsSession")}};
                VsSessionListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<VsSessionListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VsSessionListItemGridModel()
                {
                    ItemKey=c.idfVectorSurveillanceSession,strSessionID=c.strSessionID,strVSStatus=c.strVSStatus,strVectors=c.strVectors,strDiagnoses=c.strDiagnoses,strRegion=c.strRegion,strRayon=c.strRayon,dblLongitude=c.dblLongitude,dblLatitude=c.dblLatitude,datStartDate=c.datStartDate,datCloseDate=c.datCloseDate
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
        : DataAccessor<VsSessionListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<VsSessionListItem>
            
            , IObjectSelectList
            , IObjectSelectList<VsSessionListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfVectorSurveillanceSession"; } }
            #endregion
        
            private delegate void on_action(VsSessionListItem obj);
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
            private BaseReference.Accessor VsStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private CountryLookup.Accessor CountryAccessor { get { return eidss.model.Schema.CountryLookup.Accessor.Instance(m_CS); } }
            private RegionLookup.Accessor RegionAccessor { get { return eidss.model.Schema.RegionLookup.Accessor.Instance(m_CS); } }
            private RayonLookup.Accessor RayonAccessor { get { return eidss.model.Schema.RayonLookup.Accessor.Instance(m_CS); } }
            private SettlementLookup.Accessor SettlementAccessor { get { return eidss.model.Schema.SettlementLookup.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor VsVectorTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private VectorSubTypeLookup.Accessor VsVectorSubTypeAccessor { get { return eidss.model.Schema.VectorSubTypeLookup.Accessor.Instance(m_CS); } }
            private OutbreakLookup.Accessor OutbreakAccessor { get { return eidss.model.Schema.OutbreakLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor DiagnosisGroupAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private SiteLookup.Accessor SiteAccessor { get { return eidss.model.Schema.SiteLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<VsSessionListItem> SelectListT(DbManagerProxy manager
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
            
            private List<VsSessionListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_VsSession_SelectList.* from dbo.fn_VsSession_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("idfsVectorSubType"))
                {
                    
                    sql.Append(" " + @"
            left outer join
            (
            select distinct idfVectorSurveillanceSession, idfsVectorSubType from tlbVector as vi
            where vi.intRowStatus = 0
            union
            select distinct idfsVectorSubType from dbo.tlbVectorSurveillanceSessionSummary Vss
            where Vss.intRowStatus = 0
            ) as v
            on v.idfVectorSurveillanceSession = fn_VsSession_SelectList.idfVectorSurveillanceSession
          ");
                      
                }
                
                if (filters.Contains("idfsVectorType"))
                {
                    
                    sql.Append(" " + @"
            left outer join
            (
            select distinct idfVectorSurveillanceSession, idfsVectorType from tlbVector as vi1
            where vi1.intRowStatus = 0
            union
            select distinct idfVectorSurveillanceSession, idfsVectorType from dbo.tlbVectorSurveillanceSessionSummary Vss
            Inner Join dbo.trtVectorSubType Vst On Vss.idfsVectorSubType = Vst.idfsVectorSubType And Vst.intRowStatus = 0
            where Vss.intRowStatus = 0
            ) as v1
            on v1.idfVectorSurveillanceSession = fn_VsSession_SelectList.idfVectorSurveillanceSession
          ");
                      
                }
                
                if (filters.Contains("idfsDiagnosis") || filters.Contains("bWithDiagnosisOnly"))
                {
                    
                    sql.Append(" " + @"
            left outer join (
            select distinct mi.idfVectorSurveillanceSession, ti.idfsDiagnosis from tlbTesting ti
            inner join dbo.tlbMaterial mi
            on
            ti.idfMaterial = mi.idfMaterial
            and mi.intRowStatus = 0
            and ti.intRowStatus = 0
            UNION
            select distinct mi1.idfVectorSurveillanceSession, pt.idfsDiagnosis from tlbPensideTest pt
            inner join dbo.tlbMaterial mi1
            on
            pt.idfMaterial = mi1.idfMaterial
            and mi1.intRowStatus = 0
            and pt.intRowStatus = 0
            inner join trtPensideTestTypeToTestResult tr
            on
            pt.idfsPensideTestName = tr.idfsPensideTestName
            and pt.idfsPensideTestResult = tr.idfsPensideTestResult
            and pt.intRowStatus = 0
            and tr.intRowStatus = 0
            and tr.blnIndicative = 1
            UNION
            Select distinct Vss.idfVectorSurveillanceSession, Vssd.[idfsDiagnosis]
            From  dbo.tlbVectorSurveillanceSessionSummary Vss
            Inner Join dbo.tlbVectorSurveillanceSessionSummaryDiagnosis Vssd On
            Vss.[idfsVSSessionSummary] = Vssd.[idfsVSSessionSummary]
            ) as t
            on t.idfVectorSurveillanceSession = fn_VsSession_SelectList.idfVectorSurveillanceSession

          ");
                      
                }
                
                if (filters.Contains("idfsDiagnosisGroup"))
                {
                    
                    sql.Append(" " + @"
            left outer join (
              select distinct mi.idfVectorSurveillanceSession, ti.idfsDiagnosis from tlbTesting ti
              inner join dbo.tlbMaterial mi
              on
              ti.idfMaterial = mi.idfMaterial
              and mi.intRowStatus = 0
              and ti.intRowStatus = 0
              UNION
              select distinct mi1.idfVectorSurveillanceSession, pt.idfsDiagnosis from tlbPensideTest pt
              inner join dbo.tlbMaterial mi1
              on
              pt.idfMaterial = mi1.idfMaterial
              and mi1.intRowStatus = 0
              and pt.intRowStatus = 0
              inner join trtPensideTestTypeToTestResult tr
              on
              pt.idfsPensideTestName = tr.idfsPensideTestName
              and pt.idfsPensideTestResult = tr.idfsPensideTestResult
              and pt.intRowStatus = 0
              and tr.intRowStatus = 0
              and tr.blnIndicative = 1
            ) as t1
            on t1.idfVectorSurveillanceSession = fn_VsSession_SelectList.idfVectorSurveillanceSession
            inner join trtDiagnosisToDiagnosisGroup as dg
                on dg.idfsDiagnosis = t1.idfsDiagnosis
                  and dg.intRowStatus = 0
          ");
                      
                }
                
                sql.Append(" where 0 = 0");
                
                if (ModelUserContext.IsWebContext && EidssSiteContext.Instance.SiteType == SiteType.TLVL)
                {
                    sql.Append(@" and exists (select * from  tflVectorSurveillanceSessionFiltered f inner join tflSiteToSiteGroup on tflSiteToSiteGroup.idfSiteGroup = f.idfSiteGroup and tflSiteToSiteGroup.idfsSite = " + EidssSiteContext.Instance.SiteID.ToString() + " where f.idfVectorSurveillanceSession = fn_VsSession_SelectList.idfVectorSurveillanceSession)");
                }
                
                if (filters.Contains("idfsVectorSubType"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsVectorSubType") == 1)
                    {
                        sql.AppendFormat("v.idfsVectorSubType {0} @idfsVectorSubType", filters.Operation("idfsVectorSubType"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsVectorSubType"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsVectorSubType") ? " or " : " and ");
                            sql.AppendFormat("v.idfsVectorSubType {0} @idfsVectorSubType_{1}", filters.Operation("idfsVectorSubType", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsVectorType"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsVectorType") == 1)
                    {
                        sql.AppendFormat("v1.idfsVectorType {0} @idfsVectorType", filters.Operation("idfsVectorType"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsVectorType"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsVectorType") ? " or " : " and ");
                            sql.AppendFormat("v1.idfsVectorType {0} @idfsVectorType_{1}", filters.Operation("idfsVectorType", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsDiagnosis") == 1)
                    {
                        sql.AppendFormat("t.idfsDiagnosis {0} @idfsDiagnosis", filters.Operation("idfsDiagnosis"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsDiagnosis"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsDiagnosis") ? " or " : " and ");
                            sql.AppendFormat("t.idfsDiagnosis {0} @idfsDiagnosis_{1}", filters.Operation("idfsDiagnosis", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("bWithDiagnosisOnly"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("bWithDiagnosisOnly") == 1)
                    {
                        sql.AppendFormat("t.idfsDiagnosis is not null", filters.Operation("bWithDiagnosisOnly"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("bWithDiagnosisOnly"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("bWithDiagnosisOnly") ? " or " : " and ");
                            sql.AppendFormat("@bWithDiagnosisOnly_{1}", filters.Operation("bWithDiagnosisOnly", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsDiagnosisGroup"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsDiagnosisGroup") == 1)
                    {
                        sql.AppendFormat("dg.idfsDiagnosisGroup {0} @idfsDiagnosisGroup", filters.Operation("idfsDiagnosisGroup"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsDiagnosisGroup"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsDiagnosisGroup") ? " or " : " and ");
                            sql.AppendFormat("dg.idfsDiagnosisGroup {0} @idfsDiagnosisGroup_{1}", filters.Operation("idfsDiagnosisGroup", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfVectorSurveillanceSession"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfVectorSurveillanceSession"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfVectorSurveillanceSession") ? " or " : " and ");
                        
                        if (filters.Operation("idfVectorSurveillanceSession", i) == "&")
                          sql.AppendFormat("(isnull(fn_VsSession_SelectList.idfVectorSurveillanceSession,0) {0} @idfVectorSurveillanceSession_{1} = @idfVectorSurveillanceSession_{1})", filters.Operation("idfVectorSurveillanceSession", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VsSession_SelectList.idfVectorSurveillanceSession,0) {0} @idfVectorSurveillanceSession_{1}", filters.Operation("idfVectorSurveillanceSession", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSessionID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSessionID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSessionID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VsSession_SelectList.strSessionID {0} @strSessionID_{1}", filters.Operation("strSessionID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strVectors"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strVectors"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strVectors") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VsSession_SelectList.strVectors {0} @strVectors_{1}", filters.Operation("strVectors", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strVectorTypeIds"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strVectorTypeIds"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strVectorTypeIds") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VsSession_SelectList.strVectorTypeIds {0} @strVectorTypeIds_{1}", filters.Operation("strVectorTypeIds", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strDiagnoses"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strDiagnoses"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strDiagnoses") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VsSession_SelectList.strDiagnoses {0} @strDiagnoses_{1}", filters.Operation("strDiagnoses", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFieldSessionID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFieldSessionID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFieldSessionID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VsSession_SelectList.strFieldSessionID {0} @strFieldSessionID_{1}", filters.Operation("strFieldSessionID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strVSStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strVSStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strVSStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VsSession_SelectList.strVSStatus {0} @strVSStatus_{1}", filters.Operation("strVSStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsVectorSurveillanceStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsVectorSurveillanceStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsVectorSurveillanceStatus") ? " or " : " and ");
                        
                        if (filters.Operation("idfsVectorSurveillanceStatus", i) == "&")
                          sql.AppendFormat("(isnull(fn_VsSession_SelectList.idfsVectorSurveillanceStatus,0) {0} @idfsVectorSurveillanceStatus_{1} = @idfsVectorSurveillanceStatus_{1})", filters.Operation("idfsVectorSurveillanceStatus", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VsSession_SelectList.idfsVectorSurveillanceStatus,0) {0} @idfsVectorSurveillanceStatus_{1}", filters.Operation("idfsVectorSurveillanceStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCountry"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCountry"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCountry") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VsSession_SelectList.strCountry {0} @strCountry_{1}", filters.Operation("strCountry", i), i);
                            
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
                        
                        if (filters.Operation("idfsCountry", i) == "&")
                          sql.AppendFormat("(isnull(fn_VsSession_SelectList.idfsCountry,0) {0} @idfsCountry_{1} = @idfsCountry_{1})", filters.Operation("idfsCountry", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VsSession_SelectList.idfsCountry,0) {0} @idfsCountry_{1}", filters.Operation("idfsCountry", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strRegion"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strRegion"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strRegion") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VsSession_SelectList.strRegion {0} @strRegion_{1}", filters.Operation("strRegion", i), i);
                            
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
                        
                        if (filters.Operation("idfsRegion", i) == "&")
                          sql.AppendFormat("(isnull(fn_VsSession_SelectList.idfsRegion,0) {0} @idfsRegion_{1} = @idfsRegion_{1})", filters.Operation("idfsRegion", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VsSession_SelectList.idfsRegion,0) {0} @idfsRegion_{1}", filters.Operation("idfsRegion", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strRayon"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strRayon"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strRayon") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VsSession_SelectList.strRayon {0} @strRayon_{1}", filters.Operation("strRayon", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSettlement"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSettlement"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSettlement") ? " or " : " and ");
                        
                        if (filters.Operation("idfsSettlement", i) == "&")
                          sql.AppendFormat("(isnull(fn_VsSession_SelectList.idfsSettlement,0) {0} @idfsSettlement_{1} = @idfsSettlement_{1})", filters.Operation("idfsSettlement", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VsSession_SelectList.idfsSettlement,0) {0} @idfsSettlement_{1}", filters.Operation("idfsSettlement", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSettlement"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSettlement"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSettlement") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VsSession_SelectList.strSettlement {0} @strSettlement_{1}", filters.Operation("strSettlement", i), i);
                            
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
                        
                        if (filters.Operation("idfsRayon", i) == "&")
                          sql.AppendFormat("(isnull(fn_VsSession_SelectList.idfsRayon,0) {0} @idfsRayon_{1} = @idfsRayon_{1})", filters.Operation("idfsRayon", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VsSession_SelectList.idfsRayon,0) {0} @idfsRayon_{1}", filters.Operation("idfsRayon", i), i);
                            
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
                        
                        sql.AppendFormat("fn_VsSession_SelectList.dblLatitude {0} @dblLatitude_{1}", filters.Operation("dblLatitude", i), i);
                            
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
                        
                        sql.AppendFormat("fn_VsSession_SelectList.dblLongitude {0} @dblLongitude_{1}", filters.Operation("dblLongitude", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datStartDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datStartDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datStartDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_VsSession_SelectList.datStartDate, 112) {0} CONVERT(NVARCHAR(8), @datStartDate_{1}, 112)", filters.Operation("datStartDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datCloseDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datCloseDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datCloseDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_VsSession_SelectList.datCloseDate, 112) {0} CONVERT(NVARCHAR(8), @datCloseDate_{1}, 112)", filters.Operation("datCloseDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfOutbreak"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfOutbreak"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfOutbreak") ? " or " : " and ");
                        
                        if (filters.Operation("idfOutbreak", i) == "&")
                          sql.AppendFormat("(isnull(fn_VsSession_SelectList.idfOutbreak,0) {0} @idfOutbreak_{1} = @idfOutbreak_{1})", filters.Operation("idfOutbreak", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VsSession_SelectList.idfOutbreak,0) {0} @idfOutbreak_{1}", filters.Operation("idfOutbreak", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfLocation"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfLocation"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfLocation") ? " or " : " and ");
                        
                        if (filters.Operation("idfLocation", i) == "&")
                          sql.AppendFormat("(isnull(fn_VsSession_SelectList.idfLocation,0) {0} @idfLocation_{1} = @idfLocation_{1})", filters.Operation("idfLocation", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VsSession_SelectList.idfLocation,0) {0} @idfLocation_{1}", filters.Operation("idfLocation", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSite"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSite"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSite") ? " or " : " and ");
                        
                        if (filters.Operation("idfsSite", i) == "&")
                          sql.AppendFormat("(isnull(fn_VsSession_SelectList.idfsSite,0) {0} @idfsSite_{1} = @idfsSite_{1})", filters.Operation("idfsSite", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VsSession_SelectList.idfsSite,0) {0} @idfsSite_{1}", filters.Operation("idfsSite", i), i);
                            
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
                    
                    if (filters.Contains("idfsVectorType"))
                        
                        if (filters.Count("idfsVectorType") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsVectorType", ParsingHelper.CorrectLikeValue(filters.Operation("idfsVectorType"), filters.Value("idfsVectorType"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsVectorType"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsVectorType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsVectorType", i), filters.Value("idfsVectorType", i))));
                        }
                            
                    if (filters.Contains("idfsVectorSubType"))
                        
                        if (filters.Count("idfsVectorSubType") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsVectorSubType", ParsingHelper.CorrectLikeValue(filters.Operation("idfsVectorSubType"), filters.Value("idfsVectorSubType"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsVectorSubType"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsVectorSubType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsVectorSubType", i), filters.Value("idfsVectorSubType", i))));
                        }
                            
                    if (filters.Contains("idfsDiagnosis"))
                        
                        if (filters.Count("idfsDiagnosis") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosis", ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosis"), filters.Value("idfsDiagnosis"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsDiagnosis"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosis", i), filters.Value("idfsDiagnosis", i))));
                        }
                            
                    if (filters.Contains("idfsDiagnosisGroup"))
                        
                        if (filters.Count("idfsDiagnosisGroup") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosisGroup", ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosisGroup"), filters.Value("idfsDiagnosisGroup"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsDiagnosisGroup"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosisGroup_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosisGroup", i), filters.Value("idfsDiagnosisGroup", i))));
                        }
                            
                    if (filters.Contains("idfVectorSurveillanceSession"))
                        for (int i = 0; i < filters.Count("idfVectorSurveillanceSession"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfVectorSurveillanceSession_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfVectorSurveillanceSession", i), filters.Value("idfVectorSurveillanceSession", i))));
                      
                    if (filters.Contains("strSessionID"))
                        for (int i = 0; i < filters.Count("strSessionID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSessionID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSessionID", i), filters.Value("strSessionID", i))));
                      
                    if (filters.Contains("strVectors"))
                        for (int i = 0; i < filters.Count("strVectors"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strVectors_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strVectors", i), filters.Value("strVectors", i))));
                      
                    if (filters.Contains("strVectorTypeIds"))
                        for (int i = 0; i < filters.Count("strVectorTypeIds"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strVectorTypeIds_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strVectorTypeIds", i), filters.Value("strVectorTypeIds", i))));
                      
                    if (filters.Contains("strDiagnoses"))
                        for (int i = 0; i < filters.Count("strDiagnoses"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strDiagnoses_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strDiagnoses", i), filters.Value("strDiagnoses", i))));
                      
                    if (filters.Contains("strFieldSessionID"))
                        for (int i = 0; i < filters.Count("strFieldSessionID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFieldSessionID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFieldSessionID", i), filters.Value("strFieldSessionID", i))));
                      
                    if (filters.Contains("strVSStatus"))
                        for (int i = 0; i < filters.Count("strVSStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strVSStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strVSStatus", i), filters.Value("strVSStatus", i))));
                      
                    if (filters.Contains("idfsVectorSurveillanceStatus"))
                        for (int i = 0; i < filters.Count("idfsVectorSurveillanceStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsVectorSurveillanceStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsVectorSurveillanceStatus", i), filters.Value("idfsVectorSurveillanceStatus", i))));
                      
                    if (filters.Contains("strCountry"))
                        for (int i = 0; i < filters.Count("strCountry"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCountry_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCountry", i), filters.Value("strCountry", i))));
                      
                    if (filters.Contains("idfsCountry"))
                        for (int i = 0; i < filters.Count("idfsCountry"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCountry_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCountry", i), filters.Value("idfsCountry", i))));
                      
                    if (filters.Contains("strRegion"))
                        for (int i = 0; i < filters.Count("strRegion"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strRegion", i), filters.Value("strRegion", i))));
                      
                    if (filters.Contains("idfsRegion"))
                        for (int i = 0; i < filters.Count("idfsRegion"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion", i), filters.Value("idfsRegion", i))));
                      
                    if (filters.Contains("strRayon"))
                        for (int i = 0; i < filters.Count("strRayon"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strRayon", i), filters.Value("strRayon", i))));
                      
                    if (filters.Contains("idfsSettlement"))
                        for (int i = 0; i < filters.Count("idfsSettlement"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSettlement_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSettlement", i), filters.Value("idfsSettlement", i))));
                      
                    if (filters.Contains("strSettlement"))
                        for (int i = 0; i < filters.Count("strSettlement"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSettlement_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSettlement", i), filters.Value("strSettlement", i))));
                      
                    if (filters.Contains("idfsRayon"))
                        for (int i = 0; i < filters.Count("idfsRayon"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon", i), filters.Value("idfsRayon", i))));
                      
                    if (filters.Contains("dblLatitude"))
                        for (int i = 0; i < filters.Count("dblLatitude"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@dblLatitude_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("dblLatitude", i), filters.Value("dblLatitude", i))));
                      
                    if (filters.Contains("dblLongitude"))
                        for (int i = 0; i < filters.Count("dblLongitude"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@dblLongitude_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("dblLongitude", i), filters.Value("dblLongitude", i))));
                      
                    if (filters.Contains("datStartDate"))
                        for (int i = 0; i < filters.Count("datStartDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datStartDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datStartDate", i), filters.Value("datStartDate", i))));
                      
                    if (filters.Contains("datCloseDate"))
                        for (int i = 0; i < filters.Count("datCloseDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datCloseDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datCloseDate", i), filters.Value("datCloseDate", i))));
                      
                    if (filters.Contains("idfOutbreak"))
                        for (int i = 0; i < filters.Count("idfOutbreak"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfOutbreak_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfOutbreak", i), filters.Value("idfOutbreak", i))));
                      
                    if (filters.Contains("idfLocation"))
                        for (int i = 0; i < filters.Count("idfLocation"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfLocation_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfLocation", i), filters.Value("idfLocation", i))));
                      
                    if (filters.Contains("idfsSite"))
                        for (int i = 0; i < filters.Count("idfsSite"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSite_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSite", i), filters.Value("idfsSite", i))));
                      
                    List<VsSessionListItem> objs = manager.ExecuteList<VsSessionListItem>();
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
            partial void ListSelected(DbManagerProxy manager, List<VsSessionListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spVsSession_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, VsSessionListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, VsSessionListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private VsSessionListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    VsSessionListItem obj = VsSessionListItem.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.datStartDate = new Func<VsSessionListItem, DateTime>(c => DateTime.Now)(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.Country = new Func<VsSessionListItem, CountryLookup>(c => 
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

            
            public VsSessionListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public VsSessionListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public VsSessionListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult ActionEditVsSession(DbManagerProxy manager, VsSessionListItem obj, List<object> pars)
            {
                
                return ActionEditVsSession(manager, obj
                    );
            }
            public ActResult ActionEditVsSession(DbManagerProxy manager, VsSessionListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ActionEditVsSession"))
                    throw new PermissionException("VsSession", "ActionEditVsSession");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(VsSessionListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VsSessionListItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.Region = new Func<VsSessionListItem, RegionLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.Rayon = new Func<VsSessionListItem, RayonLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                obj.Settlement = new Func<VsSessionListItem, SettlementLookup>(c => null)(obj);
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
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                obj.VsVectorSubType = new Func<VsSessionListItem, VectorSubTypeLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_VsVectorSubType(manager, obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_VsStatus(DbManagerProxy manager, VsSessionListItem obj)
            {
                
                obj.VsStatusLookup.Clear();
                
                obj.VsStatusLookup.Add(VsStatusAccessor.CreateNewT(manager, null));
                
                obj.VsStatusLookup.AddRange(VsStatusAccessor.rftVectorSurveillanceSessionStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorSurveillanceStatus))
                    
                    .ToList());
                
                if (obj.idfsVectorSurveillanceStatus != 0)
                {
                    obj.VsStatus = obj.VsStatusLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsVectorSurveillanceStatus);
                    
                }
              
                
                LookupManager.AddObject("rftVectorSurveillanceSessionStatus", obj, VsStatusAccessor.GetType(), "rftVectorSurveillanceSessionStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Country(DbManagerProxy manager, VsSessionListItem obj)
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
            
            public void LoadLookup_Region(DbManagerProxy manager, VsSessionListItem obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<VsSessionListItem, long>(c => c.idfsCountry ?? 0)(obj)
                            
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
            
            public void LoadLookup_Rayon(DbManagerProxy manager, VsSessionListItem obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<VsSessionListItem, long>(c => c.idfsRegion ?? 0)(obj)
                            
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
            
            public void LoadLookup_Settlement(DbManagerProxy manager, VsSessionListItem obj)
            {
                
                obj.SettlementLookup.Clear();
                
                obj.SettlementLookup.Add(SettlementAccessor.CreateNewT(manager, null));
                
                obj.SettlementLookup.AddRange(SettlementAccessor.SelectLookupList(manager
                    
                    , new Func<VsSessionListItem, long>(c => c.idfsRayon ?? 0)(obj)
                            
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
            
            public void LoadLookup_Diagnosis(DbManagerProxy manager, VsSessionListItem obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.Vector) != 0) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != null && obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosis);
                    
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_VsVectorType(DbManagerProxy manager, VsSessionListItem obj)
            {
                
                obj.VsVectorTypeLookup.Clear();
                
                obj.VsVectorTypeLookup.Add(VsVectorTypeAccessor.CreateNewT(manager, null));
                
                obj.VsVectorTypeLookup.AddRange(VsVectorTypeAccessor.rftVectorType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorType))
                    
                    .ToList());
                
                if (obj.idfsVectorType != null && obj.idfsVectorType != 0)
                {
                    obj.VsVectorType = obj.VsVectorTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsVectorType);
                    
                }
              
                
                LookupManager.AddObject("rftVectorType", obj, VsVectorTypeAccessor.GetType(), "rftVectorType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_VsVectorSubType(DbManagerProxy manager, VsSessionListItem obj)
            {
                
                obj.VsVectorSubTypeLookup.Clear();
                
                obj.VsVectorSubTypeLookup.Add(VsVectorSubTypeAccessor.CreateNewT(manager, null));
                
                obj.VsVectorSubTypeLookup.AddRange(VsVectorSubTypeAccessor.SelectLookupList(manager
                    
                    , new Func<VsSessionListItem, long>(c => c.idfsVectorType ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorSubType))
                    
                    .ToList());
                
                if (obj.idfsVectorSubType != null && obj.idfsVectorSubType != 0)
                {
                    obj.VsVectorSubType = obj.VsVectorSubTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsVectorSubType);
                    
                }
              
                
                LookupManager.AddObject("VectorSubTypeLookup", obj, VsVectorSubTypeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Outbreak(DbManagerProxy manager, VsSessionListItem obj)
            {
                
                obj.OutbreakLookup.Clear();
                
                obj.OutbreakLookup.Add(OutbreakAccessor.CreateNewT(manager, null));
                
                obj.OutbreakLookup.AddRange(OutbreakAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfOutbreak == obj.idfOutbreak))
                    
                    .ToList());
                
                if (obj.idfOutbreak != null && obj.idfOutbreak != 0)
                {
                    obj.Outbreak = obj.OutbreakLookup
                        .SingleOrDefault(c => c.idfOutbreak == obj.idfOutbreak);
                    
                }
              
                
                LookupManager.AddObject("OutbreakLookup", obj, OutbreakAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_DiagnosisGroup(DbManagerProxy manager, VsSessionListItem obj)
            {
                
                obj.DiagnosisGroupLookup.Clear();
                
                obj.DiagnosisGroupLookup.Add(DiagnosisGroupAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisGroupLookup.AddRange(DiagnosisGroupAccessor.rftDiagnosisGroup_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsDiagnosisGroup))
                    
                    .ToList());
                
                if (obj.idfsDiagnosisGroup != null && obj.idfsDiagnosisGroup != 0)
                {
                    obj.DiagnosisGroup = obj.DiagnosisGroupLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsDiagnosisGroup);
                    
                }
              
                
                LookupManager.AddObject("rftDiagnosisGroup", obj, DiagnosisGroupAccessor.GetType(), "rftDiagnosisGroup_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Site(DbManagerProxy manager, VsSessionListItem obj)
            {
                
                obj.SiteLookup.Clear();
                
                obj.SiteLookup.Add(SiteAccessor.CreateNewT(manager, null));
                
                obj.SiteLookup.AddRange(SiteAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSite == obj.idfsSite))
                    
                    .ToList());
                
                if (obj.idfsSite != 0)
                {
                    obj.Site = obj.SiteLookup
                        .SingleOrDefault(c => c.idfsSite == obj.idfsSite);
                    
                }
              
                
                LookupManager.AddObject("SiteLookup", obj, SiteAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, VsSessionListItem obj)
            {
                
                LoadLookup_VsStatus(manager, obj);
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Settlement(manager, obj);
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_VsVectorType(manager, obj);
                
                LoadLookup_VsVectorSubType(manager, obj);
                
                LoadLookup_Outbreak(manager, obj);
                
                LoadLookup_DiagnosisGroup(manager, obj);
                
                LoadLookup_Site(manager, obj);
                
            }
    
            [SprocName("spVsSession_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spVsSession_Delete")]
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
                    VsSessionListItem bo = obj as VsSessionListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("VsSession", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("VsSession", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("VsSession", "Update");
                    }
                    
                    long mainObject = bo.idfVectorSurveillanceSession;
                    
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoVectorSurveillanceSession;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbVectorSurveillanceSession;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as VsSessionListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VsSessionListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfVectorSurveillanceSession
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
            
            public bool ValidateCanDelete(VsSessionListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, VsSessionListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfVectorSurveillanceSession
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
        
      
            protected ValidationModelException ChainsValidate(VsSessionListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(VsSessionListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as VsSessionListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VsSessionListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(VsSessionListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(VsSessionListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VsSessionListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VsSessionListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VsSessionListItemDetail"; } }
            public string HelpIdWin { get { return "vss_list"; } }
            public string HelpIdWeb { get { return "VS_W01"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private VsSessionListItem m_obj;
            internal Permissions(VsSessionListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_VsSession_SelectList";
            public static string spCount = "spVsSession_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spVsSession_Delete";
            public static string spCanDelete = "spVsSession_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VsSessionListItem, bool>> RequiredByField = new Dictionary<string, Func<VsSessionListItem, bool>>();
            public static Dictionary<string, Func<VsSessionListItem, bool>> RequiredByProperty = new Dictionary<string, Func<VsSessionListItem, bool>>();
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
                
                Sizes.Add(_str_strSessionID, 50);
                Sizes.Add(_str_strVectors, 1000);
                Sizes.Add(_str_strVectorTypeIds, 2147483647);
                Sizes.Add(_str_strDiagnoses, 1000);
                Sizes.Add(_str_strFieldSessionID, 50);
                Sizes.Add(_str_strVSStatus, 2000);
                Sizes.Add(_str_strCountry, 300);
                Sizes.Add(_str_strRegion, 300);
                Sizes.Add(_str_strRayon, 300);
                Sizes.Add(_str_strSettlement, 300);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strSessionID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strSessionID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFieldSessionID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strFieldSessionID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsVectorSurveillanceStatus",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsVectorSurveillanceStatus",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "VsStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsVectorType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsVectorType",
                    null, null, c => false, false, SearchPanelLocation.Main, true, "idfsVectorSubType", "VsVectorTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsVectorSubType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsSpeciesType",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, "VsVectorSubTypeLookup", typeof(VectorSubTypeLookup), (o) => { var c = (VectorSubTypeLookup)o; return c.idfsBaseReference; }, (o) => { var c = (VectorSubTypeLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsDiagnosis",
                    EditorType.Lookup,
                    EditorControlWidth.Large, true, true, false, false, 
                    "FT.strDisease",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, "DiagnosisLookup", typeof(DiagnosisLookup), (o) => { var c = (DiagnosisLookup)o; return c.idfsDiagnosis; }, (o) => { var c = (DiagnosisLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsDiagnosisGroup",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strDiagnosisGroup",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, "DiagnosisGroupLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRegion",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsRegion",
                    null, null, c => false, false, SearchPanelLocation.Main, false, "idfsRayon", "RegionLookup", typeof(RegionLookup), (o) => { var c = (RegionLookup)o; return c.idfsRegion; }, (o) => { var c = (RegionLookup)o; return c.strRegionName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRayon",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsRayon",
                    null, null, c => false, false, SearchPanelLocation.Main, false, "idfsSettlement", "RayonLookup", typeof(RayonLookup), (o) => { var c = (RayonLookup)o; return c.idfsRayon; }, (o) => { var c = (RayonLookup)o; return c.strRayonName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSettlement",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "VsSession.idfsSettlement",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "SettlementLookup", typeof(SettlementLookup), (o) => { var c = (SettlementLookup)o; return c.idfsSettlement; }, (o) => { var c = (SettlementLookup)o; return c.strSettlementName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "dblLongitude",
                    EditorType.Numeric,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "dblLongitude",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "dblLatitude",
                    EditorType.Numeric,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "dblLatitude",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datStartDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datStartDate",
                    c => DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter), null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datCloseDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datCloseDate",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfOutbreak",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfOutbreak",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "OutbreakLookup", typeof(OutbreakLookup), (o) => { var c = (OutbreakLookup)o; return c.idfOutbreak; }, (o) => { var c = (OutbreakLookup)o; return c.strOutbreakID; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSite",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "lbDataEntrySiteID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "SiteLookup", typeof(SiteLookup), (o) => { var c = (SiteLookup)o; return c.idfsSite; }, (o) => { var c = (SiteLookup)o; return c.strSiteName; }, new List<Tuple<string, string>>(){new Tuple<string, string>("strSiteName", eidss.model.Resources.EidssFields.Get("strSiteName")),new Tuple<string, string>("strSiteID", eidss.model.Resources.EidssFields.Get("strSiteID")),},false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfVectorSurveillanceSession,
                    _str_idfVectorSurveillanceSession, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSessionID,
                    _str_strSessionID, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVSStatus,
                    "idfsVectorSurveillanceStatus", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectors,
                    _str_strVectors, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnoses,
                    "strDisease", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRegion,
                    _str_strRegion, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRayon,
                    _str_strRayon, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_dblLongitude,
                    "VsSessionListItem.dblLongitude", "{0:F5}", true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_dblLatitude,
                    "VsSessionListItem.dblLatitude", "{0:F5}", true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datStartDate,
                    _str_datStartDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datCloseDate,
                    _str_datCloseDate, null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "ActionEditVsSession",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ActionEditVsSession(manager, (VsSessionListItem)c, pars),
                        
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<VsSession>().CreateNew(manager, c, pars == null ? null : (int?)pars[0])),
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<VsSession>().SelectDetail(manager, pars[0])),
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
                                c = ObjectAccessor.CreatorInterface<VsSessionListItem>().CreateWithParams(manager, null, pars);
                                ((VsSessionListItem)c).idfVectorSurveillanceSession = (long)pars[0];
                                ((VsSessionListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((VsSessionListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<VsSessionListItem>().Post(manager, (VsSessionListItem)c), c);
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
	